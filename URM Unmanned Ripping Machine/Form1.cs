using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using URM_Unmanned_Ripping_Machine.Properties;
using static System.String;

namespace URM_Unmanned_Ripping_Machine
{
    public partial class Form1 : Form
    {
        private ManagementEventWatcher _watcher;
        //Disk Reading Variables
        private string _diskName;
        private string _driveLetter;
        private bool _jackTheRipperIsFinished = true, _diskEncoderIsFinished = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (var settingsWindow = new Settings())
            {
                settingsWindow.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Eject any media that is CD first
            if (IsNullOrWhiteSpace(Properties.Settings.Default.pathToMakeMKV) ||
                IsNullOrWhiteSpace(Properties.Settings.Default.pathToHandBreak) ||
                IsNullOrWhiteSpace(Properties.Settings.Default.pathToKodi))
            {
                var settingsWindow = new Settings();
                settingsWindow.ShowDialog();
            }

            EjectAllCDs();

            try
            {
                var q = new WqlEventQuery
                {
                    EventClassName = "__InstanceModificationEvent",
                    WithinInterval = new TimeSpan(0, 0, 1),
                    Condition = @"TargetInstance ISA 'Win32_LogicalDisk' and TargetInstance.DriveType = 5"
                };

                var opt = new ConnectionOptions
                {
                    EnablePrivileges = true,
                    Authority = null,
                    Authentication = AuthenticationLevel.Default
                };
                //opt.Username = "Administrator";
                //opt.Password = "";
                var scope = new ManagementScope("\\root\\CIMV2", opt);

                _watcher = new ManagementEventWatcher(scope, q);
                _watcher.EventArrived += watcher_EventArrived;
                _watcher.Start();
            }
            catch (ManagementException v)
            {
                Console.WriteLine(v.Message);
            }

            if (IsNullOrWhiteSpace(Properties.Settings.Default.pathToKodi) ||
                !Properties.Settings.Default.runKodiOnStartup) return;
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Properties.Settings.Default.pathToKodi,
                    Arguments = "",
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    CreateNoWindow = false
                }
            };
            proc.Start();
        }

        private static void EjectAllCDs()
        {
            foreach (var drive in DriveInfo.GetDrives())
                if (drive.DriveType == DriveType.CDRom)
                    EjectMedia.Eject(@"\\.\" + drive.Name.Replace('\\', ' ').TrimEnd());
        }

        private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            var wmiDevice = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            var volName = wmiDevice.Properties["VolumeName"].Value;
            if (volName != null)
            {
                _diskName = wmiDevice.Properties["VolumeName"].Value.ToString();
                _driveLetter = wmiDevice.Properties["Name"].Value.ToString();

                lbl_diskRead.Invoke(
                    (Action)
                    delegate { lbl_diskRead.Text = Resources.Form1_watcher_EventArrived_Ripping_DVD_ + _diskName; });

                if ((Properties.Settings.Default.pathToMakeMKV != "") &&
                    Directory.Exists(_driveLetter + "/VIDEO_TS"))
                    JackTheRipper.RunWorkerAsync(new RunDataForRipper
                    {
                        DriveName = _driveLetter,
                        MovieName = CleaningFunctions.MakeValidFileName(_diskName)
                    });
            }
            else
                lbl_diskRead.Invoke(
                    (Action)delegate { lbl_diskRead.Text = Resources.Form1_watcher_EventArrived_Disk_ejected_; });
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress_Disk.Invoke((Action)delegate { progress_Disk.Value = e.ProgressPercentage; });

            if (e.UserState.ToString() != "")
                Log("RIP: " + e.UserState);
        }

        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pb_encodeStatus.Value = e.ProgressPercentage;
            if (e.UserState.ToString() != "")
                Log("ENC: " + e.UserState);
        }

        private void Log(string message)
        {
            txt_console.Invoke((Action)delegate { txt_console.Items.Insert(0, DateTime.Now.ToShortTimeString() + " " + message); });
        }

        private void JackTheRipper_DoWork(object sender, DoWorkEventArgs e)
        {
            _jackTheRipperIsFinished = false;
            var ripperData = (RunDataForRipper)e.Argument;
            //make sure the destination exists
            Directory.CreateDirectory(Properties.Settings.Default.tempFiles + "/" + ripperData.MovieName);
            var lockfile =
                File.Create(Properties.Settings.Default.tempFiles + "/" + ripperData.MovieName + "/" + "lockfile");
            lockfile.Close();

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Properties.Settings.Default.pathToMakeMKV,
                    Arguments =
                        "--r --decrypt --progress=-same --directio=true --minlength=" +
                        Properties.Settings.Default.minTitleTimeToRip + " mkv disc:0 all " +
                        Properties.Settings.Default.tempFiles + "/" + ripperData.MovieName,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            //Create a lock file - need to lock it out so that Encoder wont touch it
            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                var line = proc.StandardOutput.ReadLine();
                // PRGV:62,62,65536 is the progress update
                var progress = 0;
                if ((line != null) && line.Contains("PRGV"))
                    progress = GetProgress(ref line);
                JackTheRipper.ReportProgress(progress, line);
                if (JackTheRipper.CancellationPending)
                    break;
            }
            if (JackTheRipper.CancellationPending)
                proc.Kill();
            // We are done!
            EjectMedia.Eject(@"\\.\" + _driveLetter);
            File.Delete(Properties.Settings.Default.tempFiles + "/" + ripperData.MovieName + "/" + "lockfile");
            var alertWindow = new Notification(e.Cancel ? "Rip process was canceled" : "Finished Rip Process!");
            alertWindow.Left = Screen.PrimaryScreen.Bounds.Width - alertWindow.Width;
            alertWindow.Top = Screen.PrimaryScreen.Bounds.Height - alertWindow.Height;
            alertWindow.Show();
        }

        private static int GetProgress(ref string line)
        {
            if (line.Contains("Encoding"))
            {
                var workingLine = line;
                // Dealing with the encoder
                //Encoding: task 1 of 1, 1.64 % (189.87 fps, avg 188.33 fps, ETA 00h10m04s)
                workingLine = workingLine.Remove(0, 22);
                var percentage = Convert.ToDouble(workingLine.Remove(workingLine.IndexOf('%')));
                if (percentage > 0)
                    line = "";
                return Convert.ToInt32(Math.Round(percentage));
            }
            line = line.Remove(0, 5);
            var messageDetails = line.Split(',');
            var currentProgress = Convert.ToDouble(messageDetails[0]);
            var maxiumumProgress = Convert.ToDouble(messageDetails[2]);
            var progress = Convert.ToInt32(currentProgress / maxiumumProgress * 100);
            line = "";
            return progress;
        }

        private void RawVideoChecker_Tick(object sender, EventArgs e)
        {
            if ((Properties.Settings.Default.tempFiles == "") ||
                (Properties.Settings.Default.finishedEncodings == ""))
            {
                lbl_statusEncoding.Text = Resources.Form1_RawVideoChecker_Tick____Check_Settings___;
                return;
            }
            var directoryListing = Directory.GetDirectories(Properties.Settings.Default.tempFiles);
            if (!directoryListing.Any()) return; // No point in continuing
            if (EncodingOnTheFly.IsBusy && !EncodingOnTheFly.CancellationPending) // why continue, there is nothing we can do anyhow..
            {
                UpdateGuiMovieListing(directoryListing);
                return;
            }

            // Enumerate through all the directories and hit the first available movie
            foreach (var movie in directoryListing)
            {
                var filesInDirectory = Directory.GetFiles(movie);
                if (filesInDirectory.Contains(movie + "\\lockfile")) continue; // this file is still being processed
                // search for mkv files
                var moviefiles = filesInDirectory.Where(a => a.ToUpper().Contains("MKV")).Select(a => a);
                // Let's take the first one and encode it, we will come back for the rest of them
                var movieName = movie.Remove(0, movie.LastIndexOf('\\') + 1);
                lbl_statusEncoding.Text = @"Encoding " + movieName;
                var moviefile = moviefiles.First();
                Directory.CreateDirectory(Properties.Settings.Default.finishedEncodings + "\\" + movieName);
                var finalDestination = Properties.Settings.Default.finishedEncodings + "\\" + movieName + "\\" +
                                       movieName + ".mp4";
                Log("ENC: Starting to encode " + movieName);

                EncodingOnTheFly.RunWorkerAsync(new RunDataForEncoder
                {
                    Destination = finalDestination,
                    MovieName = movieName,
                    Source = moviefile
                });
                // Well, we started the encoder, no point in going through the rest
                break;
            }

            CleanUpMovieFolder(directoryListing);
        }

        /// <summary>
        ///     Clean up the movie folders
        /// </summary>
        /// <param name="directoryListing">Directory of the movies</param>
        /// <param name="cleanStale">clena up old files if over a certain age (see properties)</param>
        private static void CleanUpMovieFolder(IEnumerable<string> directoryListing, bool cleanStale = false)
        {
            foreach (var dir in directoryListing)
            {
                // Go through the folders, if the folders have no files, kill em
                var filesInFolder = Directory.GetFiles(dir);
                if (!filesInFolder.Any())
                {
                    Directory.Delete(dir);
                    continue;
                }
                if (!cleanStale) continue;
                // to clean up for any process that might have gone rogue and terminated
                // look for any files over 6 hours old.
                var folderStillNew =
                    filesInFolder.Select(fileLoc => new FileInfo(fileLoc))
                        .Any(
                            file =>
                                DateTime.Now.Subtract(file.CreationTime).TotalSeconds <
                                Properties.Settings.Default.maxFileAge);
                if (folderStillNew) continue;
                try
                {
                    Directory.Delete(dir, true);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }

        /// <summary>
        ///     Update the Movie Listing in the GUI
        /// </summary>
        /// <param name="directoryListing">The Directory listing to pull the move list from</param>
        private void UpdateGuiMovieListing(IEnumerable<string> directoryListing)
        {
            var pendingEncodingTable = ds_Encoding.Tables["pendingEncoding"];
            if (pendingEncodingTable == null) return;
            var movieLocs = directoryListing as string[] ?? directoryListing.ToArray();
            foreach (var movieLoc in movieLocs)
            {
                // Add to the dataset
                if (pendingEncodingTable.Rows.Find(movieLoc) != null) continue;
                var newRow = pendingEncodingTable.NewRow();
                newRow["MovieName"] = movieLoc.Remove(0, movieLoc.LastIndexOf('\\') + 1);
                newRow["MovieLocation"] = movieLoc;
                pendingEncodingTable.Rows.Add(newRow);
            }

            foreach (DataRow foundMovie in pendingEncodingTable.Rows)
            {
                if (!movieLocs.Contains(foundMovie["MovieLocation"]))
                    pendingEncodingTable.Rows.Remove(foundMovie);
            }
        }

        private void EncodingOnTheFly_DoWork(object sender, DoWorkEventArgs e)
        {
            //HandBrakeCLI -i source -o destination
            _diskEncoderIsFinished = false;
            var runOptions = (RunDataForEncoder)e.Argument;
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Properties.Settings.Default.pathToHandBreak,
                    Arguments = "-i " + runOptions.Source + " -o " + runOptions.Destination,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();

            while (!proc.StandardOutput.EndOfStream)
            {
                var line = proc.StandardOutput.ReadLine();
                // PRGV:62,62,65536 is the progress update
                var progress = 0;
                if ((line != null) && line.Contains("Encoding: task 1 of 1, "))
                    progress = GetProgress(ref line);
                EncodingOnTheFly.ReportProgress(progress, line);
                if (EncodingOnTheFly.CancellationPending)
                    break;
            }
            if (EncodingOnTheFly.CancellationPending)
            {
                proc.Kill();
                e.Cancel = true;
                _diskEncoderIsFinished = true;
                return;
            }
            // Remove File, since we are done
            File.Delete(runOptions.Source);

            EncodingOnTheFly.Dispose();
            var fileMovingData = new RunDataForFileMover
            {
                FileLocation = runOptions.Source,
                Destination = Properties.Settings.Default.finalDestination,
                MovieName = runOptions.MovieName
            };
            //// Move the file?             
            if (Properties.Settings.Default.finalDestination == null) return;
            var moveFile = new Thread(MoveFile);
            moveFile.Start(fileMovingData);
        }

        private static void MoveFile(object runData)
        {
            var fileMovingData = (RunDataForFileMover)runData;
            Directory.CreateDirectory(fileMovingData.Destination + "\\" + fileMovingData.MovieName);
            File.Copy(fileMovingData.FileLocation,
                fileMovingData.Destination + "\\" + fileMovingData.MovieName + "\\" + fileMovingData.MovieName + ".mp4");
        }

        private void JackTheRipper_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbl_diskRead.Invoke((Action)delegate { lbl_diskRead.Text = @"Rip Complete. Insert new media"; });
            _jackTheRipperIsFinished = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            EjectAllCDs();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _watcher.Stop();
            RawVideoChecker.Stop();
            EncodingOnTheFly.CancelAsync();
            JackTheRipper.CancelAsync();
            while (!_jackTheRipperIsFinished || !_diskEncoderIsFinished)
            {
                Thread.Sleep(50);
            }
        }

        private void EncodingOnTheFly_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                lbl_statusEncoding.Invoke(
                    (Action) delegate { lbl_statusEncoding.Text = @"Encoding Complete. Ready for next media."; });
                _diskEncoderIsFinished = true;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var newWindowAboutBox = new AboutBox();
            newWindowAboutBox.ShowDialog();
        }
    }
}