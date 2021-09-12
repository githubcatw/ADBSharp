using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUDev.ADBSharp {
    public static class HighLevelADB {

        /// <summary>
        /// Install an APK.
        /// </summary>
        /// <param name="apkPath">The APK path.</param>
        /// <param name="pid">The package name.</param>
        public static void Install(this ADB adb, string apkPath, string pid) {
            adb.Run("uninstall " + pid);
            adb.Run("install \"" + apkPath + "\"");
        }

        /// <summary>
        /// Download a file.
        /// </summary>
        /// <param name="localPath">The path of the file on the phone.</param>
        /// <param name="destPath">The destination path.</param>
        public static void DownloadFile(this ADB adb, string localPath, string destPath) {
            adb.Run("pull " + localPath + " " + destPath);
        }
    }
}
