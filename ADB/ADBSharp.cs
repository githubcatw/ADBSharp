using System.Diagnostics;

namespace NUDev.ADBSharp {
    public class ADB {
        /// <summary>
        /// The path to ADB.
        /// </summary>
        public string adbPath;

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
        public string Run(string args) {
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
            return LastStdout;
        }
    }
}
