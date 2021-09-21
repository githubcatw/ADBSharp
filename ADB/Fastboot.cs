using System;
using System.Diagnostics;
using System.IO;

namespace NUDev.ADBSharp {
    public class Fastboot {
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
        /// Run Fastboot with arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="silentError">If true an InvalidOperationException will be thrown if an error is returned. </param>
        public string Run(string args, bool silentError = true) {
            if (fbPath == "" || !File.Exists(fbPath)) {
                throw new InvalidFileException("Fastboot path is invalid.");
            }
            else {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = fbPath,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false
                };
                var process = Process.Start(processStartInfo);
                LastStdout = process.StandardOutput.ReadToEnd();
                LastStderr = process.StandardError.ReadToEnd();
                if (LastStderr != "" && silentError) {
                    throw new InvalidOperationException(LastStderr);
                }
                process.WaitForExit();
            }
            return LastStdout;
        }
    }
}
