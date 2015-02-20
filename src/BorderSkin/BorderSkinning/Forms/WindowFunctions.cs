using System;
using System.Collections.Generic;
using System.Linq;
using WinApiWrappers;

namespace BorderSkin.BorderSkinning.Forms
{
    class WindowFunctions
    {
        public static void ToggleMaximize(TopLevelWindow window){
            if (window.MaximizeBox)
            {
                if (window.Maximized)
                {
                    window.Restore();
                }
                else
                {
                    window.Maximize();
                }
            }
        }

        public static void ForceParentCommand(TopLevelWindow window, SystemCommands HitTest)
        {
            TopLevelWindow.ReleaseCapture();
            window.Activate();
            window.PostMessage(WindowMessages.SysCommand, new IntPtr((int)HitTest), IntPtr.Zero);
        }
    }
}
