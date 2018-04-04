namespace GD3
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtArchive = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAutoConvert = new System.Windows.Forms.CheckBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.chkMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkAutoUpload = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGarminUsername = new System.Windows.Forms.TextBox();
            this.txtGarminPassword = new System.Windows.Forms.TextBox();
            this.btnSourceBrowse = new System.Windows.Forms.Button();
            this.btnDestinationBrowse = new System.Windows.Forms.Button();
            this.btnArchiveBrowse = new System.Windows.Forms.Button();
            this.nico = new System.Windows.Forms.NotifyIcon(this.components);
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.fswAutoConvert = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fswAutoConvert)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Enabled = false;
            this.txtSource.Location = new System.Drawing.Point(82, 12);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(294, 20);
            this.txtSource.TabIndex = 0;
            // 
            // txtDestination
            // 
            this.txtDestination.Enabled = false;
            this.txtDestination.Location = new System.Drawing.Point(82, 38);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(294, 20);
            this.txtDestination.TabIndex = 1;
            // 
            // txtArchive
            // 
            this.txtArchive.Enabled = false;
            this.txtArchive.Location = new System.Drawing.Point(82, 64);
            this.txtArchive.Name = "txtArchive";
            this.txtArchive.Size = new System.Drawing.Size(294, 20);
            this.txtArchive.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Destination:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Archive";
            // 
            // chkAutoConvert
            // 
            this.chkAutoConvert.AutoSize = true;
            this.chkAutoConvert.Location = new System.Drawing.Point(82, 90);
            this.chkAutoConvert.Name = "chkAutoConvert";
            this.chkAutoConvert.Size = new System.Drawing.Size(88, 17);
            this.chkAutoConvert.TabIndex = 6;
            this.chkAutoConvert.Text = "Auto-Convert";
            this.chkAutoConvert.UseVisualStyleBackColor = true;
            this.chkAutoConvert.CheckedChanged += new System.EventHandler(this.chkAutoConvert_CheckedChanged);
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(82, 114);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(117, 17);
            this.chkAutoStart.TabIndex = 7;
            this.chkAutoStart.Text = "Auto-Start on Login";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // chkMinimizeToTray
            // 
            this.chkMinimizeToTray.AutoSize = true;
            this.chkMinimizeToTray.Location = new System.Drawing.Point(82, 138);
            this.chkMinimizeToTray.Name = "chkMinimizeToTray";
            this.chkMinimizeToTray.Size = new System.Drawing.Size(139, 17);
            this.chkMinimizeToTray.TabIndex = 8;
            this.chkMinimizeToTray.Text = "Minimize to System Tray";
            this.chkMinimizeToTray.UseVisualStyleBackColor = true;
            this.chkMinimizeToTray.CheckedChanged += new System.EventHandler(this.chkMinimizeToTray_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(382, 234);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start/Enable";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkAutoUpload
            // 
            this.chkAutoUpload.AutoSize = true;
            this.chkAutoUpload.Location = new System.Drawing.Point(82, 184);
            this.chkAutoUpload.Name = "chkAutoUpload";
            this.chkAutoUpload.Size = new System.Drawing.Size(85, 17);
            this.chkAutoUpload.TabIndex = 10;
            this.chkAutoUpload.Text = "Auto-Upload";
            this.chkAutoUpload.UseVisualStyleBackColor = true;
            this.chkAutoUpload.CheckedChanged += new System.EventHandler(this.chkAutoUpload_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Garmin Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Garmin Password";
            // 
            // txtGarminUsername
            // 
            this.txtGarminUsername.Location = new System.Drawing.Point(176, 210);
            this.txtGarminUsername.Name = "txtGarminUsername";
            this.txtGarminUsername.Size = new System.Drawing.Size(200, 20);
            this.txtGarminUsername.TabIndex = 13;
            this.txtGarminUsername.TextChanged += new System.EventHandler(this.txtGarminUsername_TextChanged);
            // 
            // txtGarminPassword
            // 
            this.txtGarminPassword.HideSelection = false;
            this.txtGarminPassword.Location = new System.Drawing.Point(176, 236);
            this.txtGarminPassword.Name = "txtGarminPassword";
            this.txtGarminPassword.PasswordChar = '*';
            this.txtGarminPassword.Size = new System.Drawing.Size(200, 20);
            this.txtGarminPassword.TabIndex = 14;
            this.txtGarminPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtGarminPassword_MouseClick);
            this.txtGarminPassword.TextChanged += new System.EventHandler(this.txtGarminPassword_TextChanged);
            // 
            // btnSourceBrowse
            // 
            this.btnSourceBrowse.Location = new System.Drawing.Point(382, 10);
            this.btnSourceBrowse.Name = "btnSourceBrowse";
            this.btnSourceBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSourceBrowse.TabIndex = 15;
            this.btnSourceBrowse.Text = "Browse...";
            this.btnSourceBrowse.UseVisualStyleBackColor = true;
            this.btnSourceBrowse.Click += new System.EventHandler(this.btnSourceBrowse_Click);
            // 
            // btnDestinationBrowse
            // 
            this.btnDestinationBrowse.Location = new System.Drawing.Point(382, 36);
            this.btnDestinationBrowse.Name = "btnDestinationBrowse";
            this.btnDestinationBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDestinationBrowse.TabIndex = 16;
            this.btnDestinationBrowse.Text = "Browse...";
            this.btnDestinationBrowse.UseVisualStyleBackColor = true;
            this.btnDestinationBrowse.Click += new System.EventHandler(this.btnDestinationBrowse_Click);
            // 
            // btnArchiveBrowse
            // 
            this.btnArchiveBrowse.Location = new System.Drawing.Point(382, 62);
            this.btnArchiveBrowse.Name = "btnArchiveBrowse";
            this.btnArchiveBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnArchiveBrowse.TabIndex = 17;
            this.btnArchiveBrowse.Text = "Browse...";
            this.btnArchiveBrowse.UseVisualStyleBackColor = true;
            this.btnArchiveBrowse.Click += new System.EventHandler(this.btnArchiveBrowse_Click);
            // 
            // nico
            // 
            this.nico.Icon = ((System.Drawing.Icon)(resources.GetObject("nico.Icon")));
            this.nico.Text = "GD3";
            this.nico.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nico_MouseDoubleClick);
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.Location = new System.Drawing.Point(82, 161);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(97, 17);
            this.chkStartMinimized.TabIndex = 18;
            this.chkStartMinimized.Text = "Start Minimized";
            this.chkStartMinimized.UseVisualStyleBackColor = true;
            this.chkStartMinimized.CheckedChanged += new System.EventHandler(this.chkStartMinimized_CheckedChanged);
            // 
            // fswAutoConvert
            // 
            this.fswAutoConvert.Filter = "*.fit*";
            this.fswAutoConvert.SynchronizingObject = this;
            this.fswAutoConvert.Created += new System.IO.FileSystemEventHandler(this.fswAutoConvert_Created);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 268);
            this.Controls.Add(this.chkStartMinimized);
            this.Controls.Add(this.btnArchiveBrowse);
            this.Controls.Add(this.btnDestinationBrowse);
            this.Controls.Add(this.btnSourceBrowse);
            this.Controls.Add(this.txtGarminPassword);
            this.Controls.Add(this.txtGarminUsername);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAutoUpload);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.chkMinimizeToTray);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.chkAutoConvert);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArchive);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.txtSource);
            this.Name = "frmMain";
            this.Text = "GD3";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.fswAutoConvert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtArchive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAutoConvert;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.CheckBox chkMinimizeToTray;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox chkAutoUpload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGarminUsername;
        private System.Windows.Forms.TextBox txtGarminPassword;
        private System.Windows.Forms.Button btnSourceBrowse;
        private System.Windows.Forms.Button btnDestinationBrowse;
        private System.Windows.Forms.Button btnArchiveBrowse;
        private System.Windows.Forms.NotifyIcon nico;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.IO.FileSystemWatcher fswAutoConvert;
    }
}

