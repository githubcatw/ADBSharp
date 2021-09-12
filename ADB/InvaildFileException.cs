using System;

namespace NUDev.ADBSharp {
    /// <summary>
    /// Thrown when the ADB/Fastboot path is invalid;
    /// </summary>
    public class InvalidFileException : Exception {
        public InvalidFileException() {
        }

        public InvalidFileException(string message)
            : base(message) {
        }

        public InvalidFileException(string message, Exception inner)
            : base(message, inner) {
        }
    }
}
