using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dynastream.Fit;
using System.IO;
using fileupload;
using System.Reflection;

namespace GD3
{
    public partial class frmMain : Form
    {
        static Dictionary<ushort, int> mesgCounts = new Dictionary<ushort, int>();
        static FileStream fitSource;
        static FileStream fitDest;
        static Encode GD3encoder;
        static bool startup = true;

        public frmMain()
        {
            InitializeComponent();
        }

        private void nico_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            nico.Visible = false;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                if (Properties.Settings.Default.MinimizeToTray)
                {
                    this.ShowInTaskbar = false;
                    nico.Visible = true;
                }
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.StartMinimized == true)
            {
                this.WindowState = FormWindowState.Minimized;
                if (Properties.Settings.Default.MinimizeToTray)
                {
                    this.ShowInTaskbar = false;
                    nico.Visible = true;
                }
            }
        }

        private void chkAutoConvert_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoConvert = chkAutoConvert.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoStart = chkAutoStart.Checked;
            Properties.Settings.Default.Save();

            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                Assembly curAssembly = Assembly.GetExecutingAssembly();
                if (chkAutoStart.Checked)
                {
                    key.SetValue(curAssembly.GetName().Name, curAssembly.Location);
                }
                else
                {
                    key.DeleteValue(curAssembly.GetName().Name,false);
                }
            }
            catch
            {
            }
        }

        private void chkMinimizeToTray_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MinimizeToTray = chkMinimizeToTray.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartMinimized = chkStartMinimized.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkAutoUpload_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoUpload = chkAutoUpload.Checked;
            Properties.Settings.Default.Save();

            if (!startup && chkAutoUpload.Checked)
            {
                MessageBox.Show("Garmin Upload requires fileupload.exe that is bundled with the Fit File Repair Tool. Due to Copyright concerns it is not included with this software. The file must be placed alongside this executable.");
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtSource.Text = Properties.Settings.Default.Source;
            txtDestination.Text = Properties.Settings.Default.Destination;
            txtArchive.Text = Properties.Settings.Default.Archive;
            chkAutoConvert.Checked = Properties.Settings.Default.AutoConvert;
            chkAutoStart.Checked = Properties.Settings.Default.AutoStart;
            chkMinimizeToTray.Checked = Properties.Settings.Default.MinimizeToTray;
            chkStartMinimized.Checked = Properties.Settings.Default.StartMinimized;
            chkAutoUpload.Checked = Properties.Settings.Default.AutoUpload;
            txtGarminUsername.Text = Properties.Settings.Default.GarminUsername;
            txtGarminPassword.Text = Properties.Settings.Default.GarminPassword;

            startup = false;

            this.Show();
            this.Refresh();

            if (Properties.Settings.Default.Enabled == true)
            {
                btnStart_Click(new object(),new EventArgs());
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (chkAutoConvert.Checked && btnStart.Text == "Start/Enable")
            {
                Properties.Settings.Default.Enabled = true;
                fswAutoConvert.Path = txtSource.Text;
                fswAutoConvert.EnableRaisingEvents = true;
                disableControls();
                if (chkAutoUpload.Checked)
                {
                    convertFilesGarmin();
                }
                else
                {
                    convertFiles();
                }
            }
            else if (btnStart.Text == "Disable")
            {
                Properties.Settings.Default.Enabled = false;
                fswAutoConvert.EnableRaisingEvents = false;
                enableControls();
            }
            else
            {
                disableControls();
                if (chkAutoUpload.Checked)
                {
                    convertFilesGarmin();
                }
                else
                {
                    convertFiles();
                }
                enableControls();
            }
            Properties.Settings.Default.Save();
        }

        static void OnMesg(object sender, MesgEventArgs e)
        {
            if (e.mesg.Num == 207)
            {
                var developerIdMesg = new DeveloperDataIdMesg();
                byte[] appId = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

                for (int w = 0; w < appId.Length; w++)
                {
                    developerIdMesg.SetApplicationId(w, appId[w]);
                }

                developerIdMesg.SetDeveloperDataIndex((byte)e.mesg.GetFieldValue((byte)3));
                GD3encoder.Write(developerIdMesg);
            }
            else
            {
                GD3encoder.Write(e.mesg);
            }
        }

        private void btnSourceBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(folderBrowser.SelectedPath))
                {
                    txtSource.Text = folderBrowser.SelectedPath;
                    Properties.Settings.Default.Source = folderBrowser.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("Selected Path is Invalid");
                }
            }
        }

        private void btnDestinationBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(folderBrowser.SelectedPath))
                {
                    txtDestination.Text = folderBrowser.SelectedPath;
                    Properties.Settings.Default.Destination = folderBrowser.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("Selected Path is Invalid");
                }
            }
        }

        private void btnArchiveBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(folderBrowser.SelectedPath))
                {
                    txtArchive.Text = folderBrowser.SelectedPath;
                    Properties.Settings.Default.Archive = folderBrowser.SelectedPath;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    MessageBox.Show("Selected Path is Invalid");
                }
            }
        }

        private void disableControls()
        {
            btnSourceBrowse.Enabled = false;
            btnDestinationBrowse.Enabled = false;
            btnArchiveBrowse.Enabled = false;
            chkAutoConvert.Enabled = false;
            chkAutoStart.Enabled = false;
            chkMinimizeToTray.Enabled = false;
            chkStartMinimized.Enabled = false;
            chkAutoUpload.Enabled = false;
            txtGarminUsername.Enabled = false;
            txtGarminPassword.Enabled = false;

            if (chkAutoConvert.Checked == true)
            {
                btnStart.Text = "Disable";
            }
        }

        private void enableControls()
        {
            btnSourceBrowse.Enabled = true;
            btnDestinationBrowse.Enabled = true;
            btnArchiveBrowse.Enabled = true;
            chkAutoConvert.Enabled = true;
            chkAutoStart.Enabled = true;
            chkMinimizeToTray.Enabled = true;
            chkStartMinimized.Enabled = true;
            chkAutoUpload.Enabled = true;
            txtGarminUsername.Enabled = true;
            txtGarminPassword.Enabled = true;

            btnStart.Text = "Start/Enable";
        }

        private void txtGarminUsername_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GarminUsername = txtGarminUsername.Text;
            Properties.Settings.Default.Save();
        }

        private void txtGarminPassword_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.GarminPassword = txtGarminPassword.Text;
            Properties.Settings.Default.Save();
        }

        private void txtGarminPassword_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Warning: Password is stored in plaintext on local machine in AppData folder");
        }

        private void fswAutoConvert_Created(object sender, FileSystemEventArgs e)
        {
            if (chkAutoUpload.Checked)
            {
                convertFilesGarmin();
            }
            else
            {
                convertFiles();
            }
        }

        private void convertFilesGarmin()
        {
            int result;
            string gcUploadFileName = "GCupload.fit";
            HttpGarmin garminUpload = new HttpGarmin(txtGarminUsername.Text, txtGarminPassword.Text, gcUploadFileName);

            result = garminUpload.GarminLogin();

            foreach (string sourceFile in Directory.GetFiles(txtSource.Text, "*.fit"))
            {
                string sourceFileName = Path.GetFileName(sourceFile);
                string destinationFile = txtDestination.Text + "\\" + sourceFileName;
                string archiveFile = txtArchive.Text + "\\" + sourceFileName;
                string gcUploadFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + gcUploadFileName;

                fitSource = new FileStream(sourceFile, FileMode.Open);

                Decode GD3decoder = new Decode();
                MesgBroadcaster mesgBroadcaster = new MesgBroadcaster();

                GD3encoder = new Encode(ProtocolVersion.V20);
                fitDest = new FileStream(destinationFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                GD3encoder.Open(fitDest);

                GD3decoder.MesgEvent += mesgBroadcaster.OnMesg;

                mesgBroadcaster.MesgEvent += OnMesg;

                bool status = GD3decoder.IsFIT(fitSource);
                status &= GD3decoder.CheckIntegrity(fitSource);

                if (status)
                {
                    GD3decoder.Read(fitSource);
                }

                fitSource.Close();
                GD3encoder.Close();
                fitDest.Close();

                System.IO.File.Move(sourceFile, archiveFile);

                System.IO.File.Copy(destinationFile, gcUploadFile, true);
                result = garminUpload.GarminUpload();
                System.IO.File.Delete(gcUploadFile);
            }

            result = garminUpload.GarminLogout();
        }

        private void convertFiles()
        {
            string gcUploadFileName = "GCupload.fit";

            foreach (string sourceFile in Directory.GetFiles(txtSource.Text, "*.fit"))
            {
                string sourceFileName = Path.GetFileName(sourceFile);
                string destinationFile = txtDestination.Text + "\\" + sourceFileName;
                string archiveFile = txtArchive.Text + "\\" + sourceFileName;
                string gcUploadFile = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\" + gcUploadFileName;

                fitSource = new FileStream(sourceFile, FileMode.Open);

                Decode GD3decoder = new Decode();
                MesgBroadcaster mesgBroadcaster = new MesgBroadcaster();

                GD3encoder = new Encode(ProtocolVersion.V20);
                fitDest = new FileStream(destinationFile, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
                GD3encoder.Open(fitDest);

                GD3decoder.MesgEvent += mesgBroadcaster.OnMesg;

                mesgBroadcaster.MesgEvent += OnMesg;

                bool status = GD3decoder.IsFIT(fitSource);
                status &= GD3decoder.CheckIntegrity(fitSource);

                if (status)
                {
                    GD3decoder.Read(fitSource);
                }

                fitSource.Close();
                GD3encoder.Close();
                fitDest.Close();

                System.IO.File.Move(sourceFile, archiveFile);
            }
        }
    }
}
