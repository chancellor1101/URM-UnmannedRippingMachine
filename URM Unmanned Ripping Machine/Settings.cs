using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace URM_Unmanned_Ripping_Machine
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txt_TempDirectory.Text = Properties.Settings.Default.tempFiles;
            txt_finishedEncodings.Text = Properties.Settings.Default.finishedEncodings;
            txt_finalDestination.Text = Properties.Settings.Default.finalDestination;
            txt_pathToHandbreak.Text = Properties.Settings.Default.pathToHandBreak;
            txt_pathToMakeMKV.Text = Properties.Settings.Default.pathToMakeMKV;
            txt_pathToKodi.Text = Properties.Settings.Default.pathToKodi;
            chk_startupShell.Checked = Properties.Settings.Default.setAsWindowsShell;
            chk_startKodi.Checked = Properties.Settings.Default.runKodiOnStartup;
            if (string.IsNullOrWhiteSpace(txt_pathToKodi.Text))
            {
                chk_startKodi.Hide();
                chk_startupShell.Hide();
            }
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.pathToMakeMKV))
            {
                //Try the typical hiding spots
                var x64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\MakeMKV\\makemkvcon.exe";
                var x86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Replace(" (x86)", "") + "\\MakeMKV\\makemkvcon.exe";
                if (File.Exists(x64))
                    txt_pathToMakeMKV.Text = x64;
                else if (File.Exists(x86))
                    txt_pathToMakeMKV.Text = x86;

            }
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.pathToHandBreak))
            {
                var x64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Handbrake\\HandBrakeCLI.exe";
                var x86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Replace(" (x86)", "") + "\\Handbrake\\HandBrakeCLI.exe";
                if (File.Exists(x64))
                    txt_pathToHandbreak.Text = x64;
                else if (File.Exists(x86))
                    txt_pathToHandbreak.Text = x86;

            }
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.pathToKodi))
            {
                //Try the typical hiding spots
                var x64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Kodi\\Kodi.exe";
                var x86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Replace(" (x86)", "") + "\\Kodi\\Kodi.exe";
                if (File.Exists(x64))
                    txt_pathToKodi.Text = x64;
                else if (File.Exists(x86))
                    txt_pathToKodi.Text = x86;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txt_TempDirectory.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btn_setEncodingsFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txt_finishedEncodings.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btn_setFinalDestincation_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txt_finalDestination.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Make those switches work..
            // Make the call to the helper program
            // Let's make sure we even have to do this!
            if (Properties.Settings.Default.setAsWindowsShell != chk_startupShell.Checked)
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "PressOKToSaveChanges.exe",
                        // Takes two arguments, whether to set or not, and the path of this program
                        Arguments = chk_startupShell.Checked + " \"" + Application.ExecutablePath + "\"",
                        UseShellExecute = true,
                        RedirectStandardOutput = false,
                        CreateNoWindow = true
                    }
                };
                try
                {
                    //Create a lock file - need to lock it out so that Encoder wont touch it
                    proc.Start();
                    MessageBox.Show(@"Updated shell settings for windows.", @"Update Windows Shell", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Unable to update shell, UAC was canceled");
                }
            }
            Properties.Settings.Default.tempFiles = txt_TempDirectory.Text;
            Properties.Settings.Default.finishedEncodings = txt_finishedEncodings.Text;
            Properties.Settings.Default.finalDestination = txt_finalDestination.Text;
            Properties.Settings.Default.pathToMakeMKV = txt_pathToMakeMKV.Text;
            Properties.Settings.Default.pathToHandBreak = txt_pathToHandbreak.Text;
            Properties.Settings.Default.setAsWindowsShell = chk_startupShell.Checked;
            Properties.Settings.Default.runKodiOnStartup = chk_startKodi.Checked;
            Properties.Settings.Default.pathToKodi = txt_pathToKodi.Text;
            Properties.Settings.Default.Save();
            Close();
        }


        private void btn_PathToMakeMKV_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = @"Make MKV Executable | makemkvcon.exe";
            openFileDialog1.FileName = "";
            if (!string.IsNullOrWhiteSpace(txt_pathToMakeMKV.Text))
                openFileDialog1.InitialDirectory = txt_pathToMakeMKV.Text;
            else
            {
                //Try the typical hiding spots
                var x64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\MakeMKV\\makemkvcon.exe";
                var x86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Replace(" (x86)", "") + "\\MakeMKV\\makemkvcon.exe";
                if (File.Exists(x64))
                    openFileDialog1.FileName = x64;
                else if (File.Exists(x86))
                    openFileDialog1.FileName = x86;
            }

            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txt_pathToMakeMKV.Text = openFileDialog1.FileName;
        }

        private void btn_PathToHandBreak_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = @"Handbreak Executable | HandBrakeCLI.exe";
            openFileDialog1.FileName = "";
            if (!string.IsNullOrWhiteSpace(txt_pathToHandbreak.Text))
                openFileDialog1.InitialDirectory = txt_pathToHandbreak.Text;
            else
            {
                //Try the typical hiding spots
                var x64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Handbrake\\HandBrakeCLI.exe";
                var x86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Replace(" (x86)", "") + "\\Handbrake\\HandBrakeCLI.exe";
                if (File.Exists(x64))
                    openFileDialog1.FileName = x64;
                else if (File.Exists(x86))
                    openFileDialog1.FileName = x86;
            }


            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txt_pathToHandbreak.Text = openFileDialog1.FileName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = @"Kodi Executable | Kodi.exe";
            openFileDialog1.FileName = "";
            if (!string.IsNullOrWhiteSpace(txt_pathToKodi.Text))
                openFileDialog1.InitialDirectory = txt_pathToKodi.Text;
            else
            {
                //Try the typical hiding spots
                var x64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Kodi\\Kodi.exe";
                var x86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles).Replace(" (x86)", "") + "\\Kodi\\Kodi.exe";
                if (File.Exists(x64))
                    openFileDialog1.FileName = x64;
                else if (File.Exists(x86))
                    openFileDialog1.FileName = x86;
            }
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_pathToKodi.Text = openFileDialog1.FileName;
                chk_startKodi.Show();
                chk_startupShell.Show();
            }
        }

        /// <summary>
        /// This will search for a program by name in the program files directories
        /// </summary>
        /// <param name="name">Name Of Program</param>
        private string findExecutable(string name)
        {
            switch (Environment.Is64BitOperatingSystem)
            {
                case true:
                    var x86FolderFor64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                    var X64FolderFor64 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                    var foundFilesFor64 = searchFile(x86FolderFor64, name);
                    //System.IO.Directory.GetFiles(x86FolderFor64, name, System.IO.SearchOption.AllDirectories);
                    if (!string.IsNullOrWhiteSpace(foundFilesFor64))
                        return foundFilesFor64;

                    foundFilesFor64 = searchFile(X64FolderFor64, name);
                    //System.IO.Directory.GetFiles(X64FolderFor64, name, System.IO.SearchOption.AllDirectories);
                    return foundFilesFor64;
                case false:
                    var x86Folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

                    var foundFiles = searchFile(x86Folder, name);
                    //System.IO.Directory.GetFiles(x86Folder, name, System.IO.SearchOption.AllDirectories);
                    return foundFiles;

            }
            return ""; // This typicaly should never be hit..
        }

        private string searchFile(string folder, string filename)
        {
            foreach (string file in Directory.GetFiles(folder))
            {
                if (file.Contains(filename)) return file;
            }
            var subDirectories = Directory.GetDirectories(folder);
            foreach (string subDir in Directory.GetDirectories(folder))
            {
                try
                {
                    var anythingFound = searchFile(subDir, filename);
                    if (!string.IsNullOrWhiteSpace(anythingFound))
                        return anythingFound;
                    searchFile(subDir, filename);
                }
                catch
                {
                    // swallow, log, whatever
                }
            }

            // Should never get here..
            return "";
        }

        private void txt_pathToKodi_TextChanged(object sender, EventArgs e)
        {
            // Does the directory exist?
            if (File.Exists(txt_pathToKodi.Text))
            {
                chk_startKodi.Show();
                chk_startupShell.Show();
            }
            else
            {
                chk_startKodi.Hide();
                chk_startupShell.Hide();
            }
        }
    }
}
