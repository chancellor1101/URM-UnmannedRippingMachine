namespace URM_Unmanned_Ripping_Machine
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tb_console = new System.Windows.Forms.TabPage();
            this.txt_console = new System.Windows.Forms.ListBox();
            this.tb_pendEncoding = new System.Windows.Forms.TabPage();
            this.lst_PendingEncoding = new System.Windows.Forms.ListBox();
            this.ds_Encoding = new System.Data.DataSet();
            this.pendingEncoding = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.tb_pendTransfer = new System.Windows.Forms.TabPage();
            this.lst_pendingTransfer = new System.Windows.Forms.ListBox();
            this.tb_library = new System.Windows.Forms.TabPage();
            this.lst_MovieLibrary = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_diskRead = new System.Windows.Forms.Label();
            this.lbl_statusEncoding = new System.Windows.Forms.Label();
            this.progress_Disk = new System.Windows.Forms.ProgressBar();
            this.pb_encodeStatus = new System.Windows.Forms.ProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.JackTheRipper = new System.ComponentModel.BackgroundWorker();
            this.RawVideoChecker = new System.Windows.Forms.Timer(this.components);
            this.EncodingOnTheFly = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tb_console.SuspendLayout();
            this.tb_pendEncoding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds_Encoding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingEncoding)).BeginInit();
            this.tb_pendTransfer.SuspendLayout();
            this.tb_library.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tb_console);
            this.tabControl1.Controls.Add(this.tb_pendEncoding);
            this.tabControl1.Controls.Add(this.tb_pendTransfer);
            this.tabControl1.Controls.Add(this.tb_library);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 131);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 286);
            this.tabControl1.TabIndex = 0;
            // 
            // tb_console
            // 
            this.tb_console.Controls.Add(this.txt_console);
            this.tb_console.Location = new System.Drawing.Point(4, 22);
            this.tb_console.Name = "tb_console";
            this.tb_console.Size = new System.Drawing.Size(823, 260);
            this.tb_console.TabIndex = 3;
            this.tb_console.Text = "Console";
            this.tb_console.UseVisualStyleBackColor = true;
            // 
            // txt_console
            // 
            this.txt_console.BackColor = System.Drawing.Color.Black;
            this.txt_console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_console.ForeColor = System.Drawing.Color.Lime;
            this.txt_console.FormattingEnabled = true;
            this.txt_console.Location = new System.Drawing.Point(0, 0);
            this.txt_console.Name = "txt_console";
            this.txt_console.Size = new System.Drawing.Size(823, 260);
            this.txt_console.TabIndex = 0;
            // 
            // tb_pendEncoding
            // 
            this.tb_pendEncoding.Controls.Add(this.lst_PendingEncoding);
            this.tb_pendEncoding.Location = new System.Drawing.Point(4, 22);
            this.tb_pendEncoding.Name = "tb_pendEncoding";
            this.tb_pendEncoding.Size = new System.Drawing.Size(823, 260);
            this.tb_pendEncoding.TabIndex = 0;
            this.tb_pendEncoding.Text = "Pending Encoding";
            this.tb_pendEncoding.UseVisualStyleBackColor = true;
            // 
            // lst_PendingEncoding
            // 
            this.lst_PendingEncoding.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_PendingEncoding.DataSource = this.ds_Encoding;
            this.lst_PendingEncoding.DisplayMember = "PendingEncoding.MovieName";
            this.lst_PendingEncoding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_PendingEncoding.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_PendingEncoding.FormattingEnabled = true;
            this.lst_PendingEncoding.ItemHeight = 20;
            this.lst_PendingEncoding.Location = new System.Drawing.Point(0, 0);
            this.lst_PendingEncoding.Name = "lst_PendingEncoding";
            this.lst_PendingEncoding.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lst_PendingEncoding.Size = new System.Drawing.Size(823, 260);
            this.lst_PendingEncoding.TabIndex = 0;
            this.lst_PendingEncoding.ValueMember = "PendingEncoding.MovieName";
            // 
            // ds_Encoding
            // 
            this.ds_Encoding.DataSetName = "pendingEncoding";
            this.ds_Encoding.Tables.AddRange(new System.Data.DataTable[] {
            this.pendingEncoding});
            // 
            // pendingEncoding
            // 
            this.pendingEncoding.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
            this.pendingEncoding.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "MovieLocation"}, true)});
            this.pendingEncoding.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn2};
            this.pendingEncoding.TableName = "PendingEncoding";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "MovieName";
            // 
            // dataColumn2
            // 
            this.dataColumn2.AllowDBNull = false;
            this.dataColumn2.ColumnName = "MovieLocation";
            // 
            // tb_pendTransfer
            // 
            this.tb_pendTransfer.Controls.Add(this.lst_pendingTransfer);
            this.tb_pendTransfer.Location = new System.Drawing.Point(4, 22);
            this.tb_pendTransfer.Name = "tb_pendTransfer";
            this.tb_pendTransfer.Size = new System.Drawing.Size(823, 260);
            this.tb_pendTransfer.TabIndex = 1;
            this.tb_pendTransfer.Text = "Pending Transfer";
            this.tb_pendTransfer.UseVisualStyleBackColor = true;
            // 
            // lst_pendingTransfer
            // 
            this.lst_pendingTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_pendingTransfer.FormattingEnabled = true;
            this.lst_pendingTransfer.Location = new System.Drawing.Point(0, 0);
            this.lst_pendingTransfer.Name = "lst_pendingTransfer";
            this.lst_pendingTransfer.Size = new System.Drawing.Size(823, 260);
            this.lst_pendingTransfer.TabIndex = 0;
            // 
            // tb_library
            // 
            this.tb_library.Controls.Add(this.lst_MovieLibrary);
            this.tb_library.Location = new System.Drawing.Point(4, 22);
            this.tb_library.Name = "tb_library";
            this.tb_library.Size = new System.Drawing.Size(823, 260);
            this.tb_library.TabIndex = 2;
            this.tb_library.Text = "Movie Library";
            this.tb_library.UseVisualStyleBackColor = true;
            // 
            // lst_MovieLibrary
            // 
            this.lst_MovieLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_MovieLibrary.FormattingEnabled = true;
            this.lst_MovieLibrary.Location = new System.Drawing.Point(0, 0);
            this.lst_MovieLibrary.Name = "lst_MovieLibrary";
            this.lst_MovieLibrary.Size = new System.Drawing.Size(823, 260);
            this.lst_MovieLibrary.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 106);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_diskRead, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_statusEncoding, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.progress_Disk, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pb_encodeStatus, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(831, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbl_diskRead
            // 
            this.lbl_diskRead.AutoSize = true;
            this.lbl_diskRead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_diskRead.Location = new System.Drawing.Point(3, 0);
            this.lbl_diskRead.Name = "lbl_diskRead";
            this.lbl_diskRead.Size = new System.Drawing.Size(825, 20);
            this.lbl_diskRead.TabIndex = 0;
            this.lbl_diskRead.Text = "Waiting On Disk";
            this.lbl_diskRead.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl_statusEncoding
            // 
            this.lbl_statusEncoding.AutoSize = true;
            this.lbl_statusEncoding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_statusEncoding.Location = new System.Drawing.Point(3, 50);
            this.lbl_statusEncoding.Name = "lbl_statusEncoding";
            this.lbl_statusEncoding.Size = new System.Drawing.Size(825, 20);
            this.lbl_statusEncoding.TabIndex = 1;
            this.lbl_statusEncoding.Text = "Nothing to Encode";
            this.lbl_statusEncoding.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // progress_Disk
            // 
            this.progress_Disk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progress_Disk.Location = new System.Drawing.Point(3, 23);
            this.progress_Disk.Name = "progress_Disk";
            this.progress_Disk.Size = new System.Drawing.Size(825, 24);
            this.progress_Disk.TabIndex = 2;
            // 
            // pb_encodeStatus
            // 
            this.pb_encodeStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_encodeStatus.Location = new System.Drawing.Point(3, 73);
            this.pb_encodeStatus.Name = "pb_encodeStatus";
            this.pb_encodeStatus.Size = new System.Drawing.Size(825, 24);
            this.pb_encodeStatus.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(53, 22);
            this.toolStripButton1.Text = "Settings";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton2.Text = "Eject Disk";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton3.Text = "About";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // JackTheRipper
            // 
            this.JackTheRipper.WorkerReportsProgress = true;
            this.JackTheRipper.WorkerSupportsCancellation = true;
            this.JackTheRipper.DoWork += new System.ComponentModel.DoWorkEventHandler(this.JackTheRipper_DoWork);
            this.JackTheRipper.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.JackTheRipper.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.JackTheRipper_RunWorkerCompleted);
            // 
            // RawVideoChecker
            // 
            this.RawVideoChecker.Enabled = true;
            this.RawVideoChecker.Interval = 500;
            this.RawVideoChecker.Tick += new System.EventHandler(this.RawVideoChecker_Tick);
            // 
            // EncodingOnTheFly
            // 
            this.EncodingOnTheFly.WorkerReportsProgress = true;
            this.EncodingOnTheFly.WorkerSupportsCancellation = true;
            this.EncodingOnTheFly.DoWork += new System.ComponentModel.DoWorkEventHandler(this.EncodingOnTheFly_DoWork);
            this.EncodingOnTheFly.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.EncodingOnTheFly.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.EncodingOnTheFly_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 417);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Unmanned Ripping Machine";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tb_console.ResumeLayout(false);
            this.tb_pendEncoding.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ds_Encoding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pendingEncoding)).EndInit();
            this.tb_pendTransfer.ResumeLayout(false);
            this.tb_library.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tb_pendEncoding;
        private System.Windows.Forms.TabPage tb_pendTransfer;
        private System.Windows.Forms.TabPage tb_library;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_diskRead;
        private System.Windows.Forms.Label lbl_statusEncoding;
        private System.Windows.Forms.ProgressBar progress_Disk;
        private System.Windows.Forms.ProgressBar pb_encodeStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListBox lst_pendingTransfer;
        private System.Windows.Forms.ListBox lst_MovieLibrary;
        private System.Windows.Forms.ListBox lst_PendingEncoding;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.ComponentModel.BackgroundWorker JackTheRipper;
        private System.Windows.Forms.TabPage tb_console;
        private System.Windows.Forms.ListBox txt_console;
        private System.Windows.Forms.Timer RawVideoChecker;
        private System.ComponentModel.BackgroundWorker EncodingOnTheFly;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Data.DataSet ds_Encoding;
        private System.Data.DataTable pendingEncoding;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
    }
}

