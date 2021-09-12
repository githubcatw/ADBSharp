using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUDev.ADBSharp {
    public class ADB {
        /// <summary>
        /// The path to ADB.
        /// </summary>
        public string adbPath;

        /// <summary>
        /// The path to Fastboot.
        /// </summary>
        public string fbPath;

        /// <summary>
        /// The standard output of the latest command.
        /// </summary>
        public string LastStdout;

        /// <summary>
        /// The standard error of the latest command.
        /// </summary>
        public string LastStderr;

        /// <summary>
        /// Run ADB with arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void RunAdb(string args) {
            if (adbPath == "") {
                throw new InvalidFileException("ADB path is invalid.");
            } else {
                var processStartInfo = new ProcessStartInfo {
                    FileName = adbPath,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                };
                var process = Process.Start(processStartInfo);
                LastStdout = process.StandardOutput.ReadToEnd();
                LastStderr = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
        }

        /// <summary>
        /// Run Fastboot with arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void RunFastboot(string args) {
            if (fbPath == "") {
                throw new InvalidFileException("Fastboot path is invalid.");
            } else {
                var processStartInfo = new ProcessStartInfo {
                    FileName = fbPath,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                };
                var process = Process.Start(processStartInfo);
                LastStdout = process.StandardOutput.ReadToEnd();
                LastStderr = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
        }

        /// <summary>
        /// Install an APK.
        /// </summary>
        /// <param name="apkPath">The APK path.</param>
        /// <param name="pid">The package name.</param>
        public void Install(string apkPath, string pid) {
            RunAdb("uninstall " + pid);
            RunAdb("install \"" + apkPath + "\"");
        }
		
		/// <summary>
        /// Download a file.
        /// </summary>
        /// <param name="localPath">The path of the file on the phone.</param>
        /// <param name="destPath">The destination path.</param>
        public void DownloadFile(string localPath, string destPath) {
            RunAdb("pull " + localPath + " " + destPath);
        }
    }
}
