using System;
using SHDocVw;

namespace BorderSkin.BorderSkinning.Explorer
{
    class ExplorerWindows
    {
        public static readonly ShellWindows AllExplorerWindows = new ShellWindows();

        public static ShellBrowserWindow GetExplorerWindow(IntPtr windowHandle)
        {
            foreach (ShellBrowserWindow explorerWindow in AllExplorerWindows)
            {
                if (explorerWindow.HWND == windowHandle.ToInt32())
                    return explorerWindow;
            }

            return null;
        }
    }
}
