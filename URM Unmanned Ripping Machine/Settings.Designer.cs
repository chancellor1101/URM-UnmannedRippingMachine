namespace URM_Unmanned_Ripping_Machine
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_FinishedEncodings = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TempDirectory = new System.Windows.Forms.TextBox();
            this.txt_finishedEncodings = new System.Windows.Forms.TextBox();
            this.txt_finalDestination = new System.Windows.Forms.TextBox();
            this.btn_setFinalDestincation = new System.Windows.Forms.Button();
            this.btn_setEncodingsFolder = new System.Windows.Forms.Button();
            this.btn_setTempFile = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_pathToHandbreak = new System.Windows.Forms.TextBox();
            this.txt_pathToMakeMKV = new System.Windows.Forms.TextBox();
            this.btn_PathToHandBreak = new System.Windows.Forms.Button();
            this.btn_PathToMakeMKV = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chk_startKodi = new System.Windows.Forms.CheckBox();
            this.chk_startupShell = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_pathToKodi = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory for saving raw DVD/Blueray file";
            // 
            // lbl_FinishedEncodings
            // 
            this.lbl_FinishedEncodings.AutoSize = true;
            this.lbl_FinishedEncodings.Location = new System.Drawing.Point(12, 48);
            this.lbl_FinishedEncodings.Name = "lbl_FinishedEncodings";
            this.lbl_FinishedEncodings.Size = new System.Drawing.Size(206, 13);
            this.lbl_FinishedEncodings.TabIndex = 1;
            this.lbl_FinishedEncodings.Text = "Temp directory to save finished encodings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Final Directory for finished Encodings";
            // 
            // txt_TempDirectory
            // 
            this.txt_TempDirectory.Location = new System.Drawing.Point(15, 25);
            this.txt_TempDirectory.Name = "txt_TempDirectory";
            this.txt_TempDirectory.Size = new System.Drawing.Size(197, 20);
            this.txt_TempDirectory.TabIndex = 3;
            // 
            // txt_finishedEncodings
            // 
            this.txt_finishedEncodings.Location = new System.Drawing.Point(15, 64);
            this.txt_finishedEncodings.Name = "txt_finishedEncodings";
            this.txt_finishedEncodings.Size = new System.Drawing.Size(197, 20);
            this.txt_finishedEncodings.TabIndex = 4;
            // 
            // txt_finalDestination
            // 
            this.txt_finalDestination.Location = new System.Drawing.Point(15, 103);
            this.txt_finalDestination.Name = "txt_finalDestination";
            this.txt_finalDestination.Size = new System.Drawing.Size(197, 20);
            this.txt_finalDestination.TabIndex = 5;
            // 
            // btn_setFinalDestincation
            // 
            this.btn_setFinalDestincation.Location = new System.Drawing.Point(218, 101);
            this.btn_setFinalDestincation.Name = "btn_setFinalDestincation";
            this.btn_setFinalDestincation.Size = new System.Drawing.Size(36, 23);
            this.btn_setFinalDestincation.TabIndex = 6;
            this.btn_setFinalDestincation.Text = ", , ,";
            this.btn_setFinalDestincation.UseVisualStyleBackColor = true;
            this.btn_setFinalDestincation.Click += new System.EventHandler(this.btn_setFinalDestincation_Click);
            // 
            // btn_setEncodingsFolder
            // 
            this.btn_setEncodingsFolder.Location = new System.Drawing.Point(218, 62);
            this.btn_setEncodingsFolder.Name = "btn_setEncodingsFolder";
            this.btn_setEncodingsFolder.Size = new System.Drawing.Size(36, 23);
            this.btn_setEncodingsFolder.TabIndex = 7;
            this.btn_setEncodingsFolder.Text = ", , ,";
            this.btn_setEncodingsFolder.UseVisualStyleBackColor = true;
            this.btn_setEncodingsFolder.Click += new System.EventHandler(this.btn_setEncodingsFolder_Click);
            // 
            // btn_setTempFile
            // 
            this.btn_setTempFile.Location = new System.Drawing.Point(218, 23);
            this.btn_setTempFile.Name = "btn_setTempFile";
            this.btn_setTempFile.Size = new System.Drawing.Size(36, 23);
            this.btn_setTempFile.TabIndex = 8;
            this.btn_setTempFile.Text = ", , ,";
            this.btn_setTempFile.UseVisualStyleBackColor = true;
            this.btn_setTempFile.Click += new System.EventHandler(this.button3_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(538, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Save Settings";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Path to HandBreak";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Path to MakeMKV";
            // 
            // txt_pathToHandbreak
            // 
            this.txt_pathToHandbreak.Location = new System.Drawing.Point(275, 64);
            this.txt_pathToHandbreak.Name = "txt_pathToHandbreak";
            this.txt_pathToHandbreak.Size = new System.Drawing.Size(196, 20);
            this.txt_pathToHandbreak.TabIndex = 12;
            // 
            // txt_pathToMakeMKV
            // 
            this.txt_pathToMakeMKV.Location = new System.Drawing.Point(275, 25);
            this.txt_pathToMakeMKV.Name = "txt_pathToMakeMKV";
            this.txt_pathToMakeMKV.Size = new System.Drawing.Size(196, 20);
            this.txt_pathToMakeMKV.TabIndex = 13;
            // 
            // btn_PathToHandBreak
            // 
            this.btn_PathToHandBreak.Location = new System.Drawing.Point(477, 62);
            this.btn_PathToHandBreak.Name = "btn_PathToHandBreak";
            this.btn_PathToHandBreak.Size = new System.Drawing.Size(32, 23);
            this.btn_PathToHandBreak.TabIndex = 14;
            this.btn_PathToHandBreak.Text = ". . .";
            this.btn_PathToHandBreak.UseVisualStyleBackColor = true;
            this.btn_PathToHandBreak.Click += new System.EventHandler(this.btn_PathToHandBreak_Click);
            // 
            // btn_PathToMakeMKV
            // 
            this.btn_PathToMakeMKV.Location = new System.Drawing.Point(477, 23);
            this.btn_PathToMakeMKV.Name = "btn_PathToMakeMKV";
            this.btn_PathToMakeMKV.Size = new System.Drawing.Size(32, 23);
            this.btn_PathToMakeMKV.TabIndex = 15;
            this.btn_PathToMakeMKV.Text = ". . .";
            this.btn_PathToMakeMKV.UseVisualStyleBackColor = true;
            this.btn_PathToMakeMKV.Click += new System.EventHandler(this.btn_PathToMakeMKV_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // chk_startKodi
            // 
            this.chk_startKodi.AutoSize = true;
            this.chk_startKodi.Location = new System.Drawing.Point(527, 82);
            this.chk_startKodi.Name = "chk_startKodi";
            this.chk_startKodi.Size = new System.Drawing.Size(105, 17);
            this.chk_startKodi.TabIndex = 16;
            this.chk_startKodi.Text = "Start Kodi on run";
            this.chk_startKodi.UseVisualStyleBackColor = true;
            // 
            // chk_startupShell
            // 
            this.chk_startupShell.AutoSize = true;
            this.chk_startupShell.Location = new System.Drawing.Point(527, 105);
            this.chk_startupShell.Name = "chk_startupShell";
            this.chk_startupShell.Size = new System.Drawing.Size(115, 17);
            this.chk_startupShell.TabIndex = 17;
            this.chk_startupShell.Text = "Set as startup shell";
            this.chk_startupShell.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Path to Kodi";
            // 
            // txt_pathToKodi
            // 
            this.txt_pathToKodi.Location = new System.Drawing.Point(275, 103);
            this.txt_pathToKodi.Name = "txt_pathToKodi";
            this.txt_pathToKodi.Size = new System.Drawing.Size(196, 20);
            this.txt_pathToKodi.TabIndex = 19;
            this.txt_pathToKodi.TextChanged += new System.EventHandler(this.txt_pathToKodi_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = ". . .";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Settings
            // 
            this.AcceptButton = this.button4;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 133);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_pathToKodi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chk_startupShell);
            this.Controls.Add(this.chk_startKodi);
            this.Controls.Add(this.btn_PathToMakeMKV);
            this.Controls.Add(this.btn_PathToHandBreak);
            this.Controls.Add(this.txt_pathToMakeMKV);
            this.Controls.Add(this.txt_pathToHandbreak);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_setTempFile);
            this.Controls.Add(this.btn_setEncodingsFolder);
            this.Controls.Add(this.btn_setFinalDestincation);
            this.Controls.Add(this.txt_finalDestination);
            this.Controls.Add(this.txt_finishedEncodings);
            this.Controls.Add(this.txt_TempDirectory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_FinishedEncodings);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_FinishedEncodings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TempDirectory;
        private System.Windows.Forms.TextBox txt_finishedEncodings;
        private System.Windows.Forms.TextBox txt_finalDestination;
        private System.Windows.Forms.Button btn_setFinalDestincation;
        private System.Windows.Forms.Button btn_setEncodingsFolder;
        private System.Windows.Forms.Button btn_setTempFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_pathToHandbreak;
        private System.Windows.Forms.TextBox txt_pathToMakeMKV;
        private System.Windows.Forms.Button btn_PathToHandBreak;
        private System.Windows.Forms.Button btn_PathToMakeMKV;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chk_startKodi;
        private System.Windows.Forms.CheckBox chk_startupShell;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_pathToKodi;
        private System.Windows.Forms.Button button1;
    }
}