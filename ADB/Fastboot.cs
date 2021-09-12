using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void RunFastboot(string args) {
            if (fbPath == "") {
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
                process.WaitForExit();
            }
        }
    }
}
