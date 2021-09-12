using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUDev.ADBSharp {
    public enum BootMode {
        /// <summary>
        /// The installed OS.
        /// </summary>
        Android,
        /// <summary>
        /// The recovery mode.
        /// </summary>
        Recovery,
        /// <summary>
        /// The bootloader, or download/Odin mode on Samsung devices.
        /// </summary>
        Bootloader
    }
}
