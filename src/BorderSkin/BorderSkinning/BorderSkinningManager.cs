using System;
using System.Collections.Generic;
using System.Drawing;
using WindowsHook;
using WinApiWrappers;

namespace BorderSkin.BorderSkinning
{
    class BorderSkinningManager
    {
        private readonly IWindowsHookController _hookController;
        private readonly IDictionary<IntPtr, SkinableWindowBorder> _skinnedWindows = new Dictionary<IntPtr, SkinableWindowBorder>();

        private readonly IList<INewWindowHandler> _newWindowHandlers = new List<INewWindowHandler>();

        public BorderSkinningManager(IWindowsHookController hookController)
        {
            _hookController = hookController;

            _newWindowHandlers.Add(new DefaultNewWindowHandler());
        }

        public void Start()
        {
            IWindowsHook windowsHook = _hookController.HookAllWindows();

            windowsHook.WindowActivating += WindowsHookOnWindowActivating;
            windowsHook.WindowLocationChanging += WindowsHookOnWindowLocationChanging;
            windowsHook.WindowSizeChanging += WindowsHookOnWindowSizeChanging;
            windowsHook.WindowVisibleChanging += WindowsHookOnWindowVisibleChanging;
        }

        public void Stop()
        {
            IWindowsHook windowsHook = _hookController.HookAllWindows();

            windowsHook.WindowActivating -= WindowsHookOnWindowActivating;
            windowsHook.WindowLocationChanging -= WindowsHookOnWindowLocationChanging;
            windowsHook.WindowSizeChanging -= WindowsHookOnWindowSizeChanging;
            windowsHook.WindowVisibleChanging -= WindowsHookOnWindowVisibleChanging;
        }

        public IList<INewWindowHandler> NewWindowHandlers
        {
            get { return _newWindowHandlers; }
        }

        public void AddSkinWindow(SkinableWindowBorder newSkinWindow)
        {
            _skinnedWindows[newSkinWindow.Parent.Handle] = newSkinWindow;
            newSkinWindow.Disposed += SkinWindowOnDisposed;
            newSkinWindow.WindowEventHandler.AttachToWindowsHook(_hookController.HookWindowByHandle(newSkinWindow.Parent.Handle));
            newSkinWindow.WindowEventHandler.AdjustSkinWindowPropertiesToParent();

        }

        private bool IsSkinned(TopLevelWindow window)
        {
            return _skinnedWindows.ContainsKey(window.Handle);
        }

        private void SkinWindowOnDisposed(SkinableWindowBorder skinWindow)
        {
            skinWindow.Disposed -= SkinWindowOnDisposed;
            _skinnedWindows.Remove(skinWindow.Parent.Handle);
        }

        private void HandleNewWindow(TopLevelWindow window)
        {
            if (IsSkinned(window)) return;

            foreach (var handler in _newWindowHandlers)
            {
                if(handler.HandleNewWindow(window, this))
                {
                    return;
                }
            }
        }

        private void WindowsHookOnWindowSizeChanging(IntPtr windowHandle, WindowSizeChangingEventArgs args)
        {
            TopLevelWindow window = TopLevelWindow.FromHandle(windowHandle);

            if (window.Visible && !window.Minimized)
                HandleNewWindow(window);
        }

        private void WindowsHookOnWindowLocationChanging(IntPtr windowHandle, NewValueEventArgs<Point> args)
        {
            TopLevelWindow window = TopLevelWindow.FromHandle(windowHandle);

            if(window.Visible && !window.Minimized)
                HandleNewWindow(window);
        }

        private void WindowsHookOnWindowActivating(IntPtr windowHandle, EventArgs args)
        {
            TopLevelWindow window = TopLevelWindow.FromHandle(windowHandle);

            if (window.Visible && !window.Minimized)
                HandleNewWindow(window);
        }

        private void WindowsHookOnWindowVisibleChanging(IntPtr windowHandle, NewValueEventArgs<bool> args)
        {
            TopLevelWindow window = TopLevelWindow.FromHandle(windowHandle);

            if (args.NewValue && !window.Minimized)
                HandleNewWindow(window);
        }

        public static void RestoreBorder(TopLevelWindow window)
        {
            window.Region = IntPtr.Zero;
            if (window.Maximized | window.Minimized)
            {
                unchecked
                {
                    window.Styles = (window.Styles & ~(unchecked((int)(WindowStyles.Popup)))) | (int)(WindowStyles.Caption | WindowStyles.Border | WindowStyles.Sizebox);
                }
                window.ExStyles = (window.ExStyles & ~(int)WindowExtendedStyles.StaticEdge) | (int)WindowExtendedStyles.WindowEdge;
                window.Bounds = window.Screen.WorkingArea;
            }
            window.PostMessage(WindowMessages.Themechanged);
            window.FrameChanged();
        }
    }
}