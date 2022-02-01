using System;
using System.Linq;

namespace NUDev.ADBSharp.Extensions {
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

        /// <summary>
        /// Upload a file.
        /// </summary>
        /// <param name="localPath">The path of the file on this machine.</param>
        /// <param name="destPath">The destination path on the phone.</param>
        public static void UploadFile(this ADB adb, string localPath, string destPath) {
            adb.Run("push " + localPath + " " + destPath);
        }

        /// <summary>
        /// Restarts the ADB server.
        /// </summary>
        public static void RestartServer(this ADB adb) {
            adb.Run("start-server");
            adb.Run("kill-server");
        }

        /// <summary>
        /// Lists devices.
        /// </summary>
        public static string[] Devices(this ADB adb) {
            var devices = adb.Run("devices").Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (devices[0].StartsWith("* daemon")) return devices.Skip(3).ToArray();
            else return devices.Skip(1).ToArray();
        }

        /// <summary>
        /// Reboots the connected phone.
        /// </summary>
        public static void Reboot(this ADB adb, BootMode mode) {
            if (mode == BootMode.Android) adb.Run("reboot");
            else {
                var smode = (mode == BootMode.Bootloader ? "bootloader" : "recovery");
                adb.Run("reboot " + smode);
            }
        }

        /// <summary>
        /// Run a shell command and return the output.
        /// </summary>
        /// <param name="cmd">The command.</param>
        public static string RunShell(this ADB adb, string cmd)
            => adb.Run("shell " + cmd);

        /// <summary>
        /// Run an app.
        /// </summary>
        /// <param name="pkg">The package ID.</param>
        public static void RunApp(this ADB adb, string pkg) {
            adb.Run("shell am start " + pkg);
        }
    }
}
