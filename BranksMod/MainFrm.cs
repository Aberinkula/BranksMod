using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;

namespace BranksMod
{
    public partial class MainFrm : Form
    {
        public static readonly int UPDATER_VERSION = 1;
        private bool FirstRun = false;
        private Object injectionLock = new Object();
        Boolean IsInjected = false;
        string updaterStorePath = Path.GetTempPath() + "\\bmupdate.zip";
        string SafeVersion = "";
        string UpdateURL;
        string rocketLeagueDirectory;
        string bakkesModDirectory;
        String InjectionStatus = "";

        private static readonly string BAKKESMOD_FILES_ZIP_DIR = "bminstall.zip";
        private static readonly string REGISTRY_CURRENTUSER_BASE_DIR = @"Software\BranksMod";
        private static readonly string REGISTRY_BASE_DIR = @"HKEY_CURRENT_USER\SOFTWARE\BranksMod\AppPath";
        private static readonly string APPLICATION_NAME = "BranksMod";
        private static readonly string REGISTRY_RUN = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private static readonly string REGISTRY_ROCKET_LEAGUE_PATH = "RocketLeaguePath";
        private static readonly string REGISTRY_BAKKESMOD_PATH = "BranksModPath";

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            CheckSafeMode();
            CheckWarnings();
            CheckAutoUpdates();
            //CheckAutoRun();
            //CheckInstall();
            GetFolderPath();
            ProcessTmr.Start();
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            CheckMiniHide();
        }

        public void GetFolderPath()
        {
            string Path = RLLauncher.GetRocketLeagueDirFromLog();
            Properties.Settings.Default.FolderPath = Path;
            Properties.Settings.Default.Save();
        }

        private void ProcessTmr_Tick(object sender, EventArgs e)
        {
            Process[] Name = Process.GetProcessesByName("RocketLeague");
            if (Name.Length == 0)
            {
                RLLbl.Text = "Rocket League is not running.";
                StatusLbl.Text = "Status: Uninjected.";
            }
            else
            {
                RLLbl.Text = "Rocket League is running.";
                try
                {
                    InjectionTmr.Interval = Properties.Settings.Default.Timeout;
                } catch (System.Exception ex)
                {
                    InjectionTmr.Interval = 2500;
                }
                InjectionTmr.Start();
            }
        }

        private void InjectionTmr_Tick(object sender, EventArgs e)
        {
            if (IsInjected == false)
            {
                if (Properties.Settings.Default.InjectionType == "Automatic")
                {
                    InjectBtn.Visible = false;
                    InjectionTmr.Stop();
                    InjectDLL();
                }
                else if (Properties.Settings.Default.InjectionType == "Manual")
                {
                    InjectionTmr.Stop();
                    InjectBtn.Visible = true;
                }
            } else
            {
           
            }
        }

        void InjectDLL()
        {
            InjectionResult Result = DllInjector.Instance.Inject("RocketLeague", Properties.Settings.Default.FolderPath + "\\BakkesMod\\bakkesmod.dll");
            switch (Result)
            {
                case InjectionResult.DLL_NOT_FOUND:
                    StatusLbl.Text = "Status: Could Not Find DLL File.";
                    InjectionStatus = StatusStrings.INSTALLATION_WRONG;
                    break;
                case InjectionResult.GAME_PROCESS_NOT_FOUND:
                    StatusLbl.Text = "Status: Uninjected.";
                    InjectionStatus = StatusStrings.PROCESS_NOT_ACTIVE;
                    break;
                case InjectionResult.INJECTION_FAILED:
                    StatusLbl.Text = "Status: Injection Failed.";
                    InjectionStatus = StatusStrings.INJECTION_FAILED;
                    break;
                case InjectionResult.SUCCESS:
                    StatusLbl.Text = "Status: Successfully Injected.";
                    InjectionStatus = StatusStrings.INJECTED;
                    IsInjected = true;
                    break;
            }
        }

        private bool IsSafeToInject()
        {
            string Version = RLLauncher.GetRocketLeagueSteamVersion(rocketLeagueDirectory + "/../../../../");
            return Version.Equals(SafeVersion) || !Properties.Settings.Default.EnableSafeMode;
        }

        void CheckInstall()
        {
            string InstallPath = (string)Registry.GetValue(REGISTRY_BASE_DIR, REGISTRY_ROCKET_LEAGUE_PATH, null);
            if (InstallPath == null)
            {
                Install();
            }
            else
            {
                rocketLeagueDirectory = InstallPath;
                string bakkesModDir = (string)Registry.GetValue(REGISTRY_BASE_DIR, REGISTRY_BAKKESMOD_PATH, null);
                if (!Directory.Exists(bakkesModDir))
                {
                    RegistryKey keys = Registry.CurrentUser.OpenSubKey(REGISTRY_CURRENTUSER_BASE_DIR, true);
                    keys.DeleteSubKeyTree("apppath");
                    Install();
                }
                else
                {
                    bakkesModDirectory = bakkesModDir;
                }
            }
        }

        public void CheckForUpdates()
        {

        }

        void Install()
        {
            string Path = RLLauncher.GetRocketLeagueDirFromLog() + "RocketLeague.exe";

            if (!File.Exists(Path))
            {
                MessageBox.Show("It seems that this is the first time you run BakkesMod. Please select the Rocket League executable. \r\nExecutable can be found in [STEAM_FOLDER]/steamapps/common/rocketleague/binaries/win32/");
                DialogResult result = FileDialog.ShowDialog();
                if (result != DialogResult.OK)
                {
                    MessageBox.Show("No executable selected. Exiting...");
                    Application.Exit();
                    return;
                }
                Path = FileDialog.FileName;
                if (!Path.ToLower().EndsWith("rocketleague.exe"))
                {
                    MessageBox.Show("This is not the Rocket League executable!");
                    Application.Exit();
                    return;
                }
            }
            Properties.Settings.Default.FolderPath = RLLauncher.GetRocketLeagueDirFromLog() + "RocketLeague.exe";
            //rocketLeagueDirectory = Path.Substring(0, Path.LastIndexOf("\\") + 1);
           // bakkesModDirectory = rocketLeagueDirectory + "bakkesmod\\";
            //if (!Directory.Exists(bakkesModDirectory))
           // {
                //Directory.Delete(bakkesModDirectory, true);
           //     Directory.CreateDirectory(bakkesModDirectory);
          //  }

          //  Registry.SetValue(REGISTRY_BASE_DIR, REGISTRY_ROCKET_LEAGUE_PATH, rocketLeagueDirectory);
          //  Registry.SetValue(REGISTRY_BASE_DIR, REGISTRY_BAKKESMOD_PATH, bakkesModDirectory);

          //  if (!File.Exists(BAKKESMOD_FILES_ZIP_DIR))
         //   {
         //       FirstRun = true;
         //       return;
         //   }

          //  using (FileStream zipToOpen = new FileStream(BAKKESMOD_FILES_ZIP_DIR, FileMode.Open))
           // {
                //using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read))
           //     {
                    // archive.ExtractToDirectory(bakkesModDirectory, true);
           //     }
         //   }
        }

        #region "Form Buttons"
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void OpenTrayBtn_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ExitTrayBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenFolderMenuBtn_Click(object sender, EventArgs e)
        {
            string BranksModDirectory = Properties.Settings.Default.FolderPath + "bakkesmod\\";
            if (Directory.Exists(BranksModDirectory))
            {
                Process.Start(BranksModDirectory);
            }
            else
            {
                MessageBox.Show("Could not find the BranksMod folder, its either deleted or corrupted.", "BranksMod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CheckUpdatesMenuBtn_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void ReinstallMenuBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will fully remove all bakkesmod files, are you sure you want to continue?", "Confirm reinstall", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string BranksModDirectory = Properties.Settings.Default.FolderPath + "bakkesmod\\";
                if (Directory.Exists(BranksModDirectory))
                {
                    Directory.Delete(BranksModDirectory, true);
                }
                CheckInstall();
                CheckForUpdates();
                FirstRun = false;
            }
        }

        private void UninstallMenuBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BranKs dumbass forgot to add this part.");
        }

        private void ExitMenuBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsMenuBtn_Click(object sender, EventArgs e)
        {
            SettingsFrm Settings = new SettingsFrm();
            Settings.Show();

        }

        private void TroubleshootingMenuBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Troubleshooting is not complete yet.", "BranksMod", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //HelpFrm HF = new HelpFrm();
            //HF.Show();
        }

        private void InjectBtn_Click(object sender, EventArgs e)
        {
            InjectDLL();
        }
        #endregion

        #region "Apply Settings"
        public void CheckSafeMode()
        {
            if (Properties.Settings.Default.EnableSafeMode == true)
            {

            }
            else if (Properties.Settings.Default.EnableSafeMode == false)
            {

            }
        }

        public void CheckWarnings()
        {
            if (Properties.Settings.Default.DisableWarnings == true)
            {

            }
            else if (Properties.Settings.Default.DisableWarnings == false)
            {
                CheckD3D9();
            }
        }

        public void CheckD3D9()
        {
            if (File.Exists(Properties.Settings.Default.FolderPath + "d3d9.dll"))
            {
                DialogResult DialogResult = MessageBox.Show(@"WARNING: d3d9.dll detected. This file is used by ReShade/uMod and might prevent the GUI from working. Would you like BranksMod to remove this file?", "BakkesMod", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    File.Delete(Properties.Settings.Default.RunOnStart + "d3d9.dll");
                }
                else if (DialogResult == DialogResult.No)
                {

                }
            }
        }

        public void CheckAutoUpdates()
        {
            if (Properties.Settings.Default.AutoUpdate == true)
            {
                CheckForUpdates();
            }
            else if (Properties.Settings.Default.AutoUpdate == false)
            {

            }
        }

        public void CheckMiniHide()
        {
            if (Properties.Settings.Default.MinimizeHide == true)
            {
                this.Hide();
                TrayIcon.Visible = true;
            }
            else if (Properties.Settings.Default.MinimizeHide == false)
            {
                TrayIcon.Visible = false;
            }
        }

        public void CheckAutoRun()
        {
            if (Properties.Settings.Default.AutoRun == true)
            {
                Process P = new Process();
                P.StartInfo.FileName = "RocketLeague.exe";
                P.Start();
            } else if (Properties.Settings.Default.AutoRun == false)
            {

            }
        }
        #endregion


        static class StatusStrings
        {
            public static readonly string PROCESS_NOT_ACTIVE = "Status: Uninjected.";
            public static readonly string INSTALLATION_WRONG = "Status: Could Not Find DLL File.";
            public static readonly string INJECTED = "Status: Successfully Injected.";
            public static readonly string INJECTION_FAILED = "Status: Injection Failed.";
            public static readonly string CHECKING_FOR_UPDATES = "Status: Checking for updates...";
            public static readonly string DOWNLOADING_UPDATE = "Status: Downloading update...";
            public static readonly string EXTRACTING_UPDATE = "Status: Extracting update...";
        }
    }
}