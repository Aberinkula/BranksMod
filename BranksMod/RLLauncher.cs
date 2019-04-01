using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

    class RLLauncher
    {
        public static string GetRocketLeagueDirFromLog()
        {
            string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string LogDir = MyDocuments + @"\My Games\Rocket League\TAGame\Logs\";
            string LogFile = LogDir + "launch.log";
            string ReturnDir = "";
            if (File.Exists(LogFile))
            {
                string Line;
                using (FileStream Stream = File.Open(LogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    StreamReader File = new StreamReader(Stream);
                    while ((Line = File.ReadLine()) != null)
                    {
                        if (Line.Contains("Init: Base directory: "))
                        {
                        Line = Line.Replace("Init: Base directory: ", "");
                        ReturnDir = Line;
                            break;
                        }
                    }
                }
            }
            return ReturnDir;
        }

        public static string GetRocketLeagueSteamVersion(String Path)
        {
            string AppInfo = Path + "\\appmanifest_252950.acf";
            string Version = "0";
            string Pattern = "(\"([^ \"]|\"\")*\")";

            if (File.Exists(AppInfo))
            {
                string Line;
                using (FileStream Stream = File.Open(AppInfo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    StreamReader File = new StreamReader(Stream);
                    while ((Line = File.ReadLine()) != null)
                    {
                        if (Line.Contains("buildid"))
                        {
                            Version = Regex.Match(Line, Pattern, RegexOptions.IgnoreCase | RegexOptions.RightToLeft).Groups[1].Value.Replace("\"", "");
                            break;
                        }
                    }
                }
            }
            return Version;
        }

        void Launch()
        {
            var P = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "F:\\SteamLibrary\\steamapps\\common\\rocketleague\\Binaries\\Win32\\RocketLeague.exe",
                    Arguments = "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            P.Start();
            while (!P.StandardOutput.EndOfStream)
            {
                string Line = P.StandardOutput.ReadLine();
                MessageBox.Show(Line);
            }
        }
    }