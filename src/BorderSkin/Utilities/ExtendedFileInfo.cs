using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace BorderSkin.Utilities
{
    public sealed class ExtendedFileInfo
    {
        public static Icon GetFolderIcon(bool small)
        {
            return GetIconForFilename(Environment.GetFolderPath(Environment.SpecialFolder.System), small);
        }

        public static Icon GetIconForFilename(string fileName, bool small)
        {
            SHFILEINFO shinfo = new SHFILEINFO();

            if (small) {
                IntPtr hImgSmall = SHGetFileInfo(fileName, 0, ref shinfo, Convert.ToUInt32(Marshal.SizeOf(shinfo)), SHGFI_ICON | SHGFI_SMALLICON);
            } else {
                IntPtr hImgLarge = SHGetFileInfo(fileName, 0, ref shinfo, Convert.ToUInt32(Marshal.SizeOf(shinfo)), SHGFI_ICON | SHGFI_LARGEICON);
            }

            if (shinfo.hIcon == IntPtr.Zero) {
                return null;
            }

            Icon myIcon = Icon.FromHandle(shinfo.hIcon);
            return myIcon;
        }

        public static string GetDisplayName(string fileName)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            SHGetFileInfo(fileName, 0, ref shinfo, Convert.ToUInt32(Marshal.SizeOf(shinfo)), SHGFI_DISPLAYNAME);
            return shinfo.szDisplayName;
        }

        #region "PInvoke Declarations"
        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_LARGEICON = 0x0;
        private const uint SHGFI_SMALLICON = 0x1;

        private const uint SHGFI_DISPLAYNAME = 512;
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool GetDiskFreeSpace(string lpRootPathName, uint lpSectorsPerCluster, uint lpBytesPerSector, uint lpNumberOfFreeClusters, uint lpTotalNumberOfClusters);

        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }
        #endregion
    }
}
