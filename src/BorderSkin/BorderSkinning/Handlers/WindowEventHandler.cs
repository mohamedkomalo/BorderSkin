using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsHook;
using BorderSkin.BorderSkinning.Explorer.Forms;
using LayeredForms;
using WinApiWrappers;
using Padding = System.Windows.Forms.Padding;

namespace BorderSkin.BorderSkinning.Handlers
{
    class WindowEventHandler : IDisposable
    {
        public const int BorderRemove = 1;

        private SkinableWindowBorder _skinWindow;
        private Timer _maximizeCheckTimer;
        private TopLevelWindow _parent;
        private IWindowsHook _windowsHook;


        public WindowEventHandler(SkinableWindowBorder skinWindow, TopLevelWindow parent)
        {
            _skinWindow = skinWindow;
            
            _parent = parent;

            CreateMaximizeTimer();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_skinWindow.IsClosing)
            {
                BorderSkinningManager.RestoreBorder(_skinWindow.Parent);
            }

            DisposeTimer();
            _skinWindow = null;
            
            DeattachFromWindowsHook();
        }

        public void AdjustSkinWindowPropertiesToParent()
        {
            _skinWindow.LockUpdate = true;
            _skinWindow.Parent.Bounds = _skinWindow.Parent.Bounds;
            _skinWindow.UpdateBounds = _skinWindow.Parent.Bounds;
            _skinWindow.Text = _skinWindow.Parent.Title;
            _skinWindow.Icon = _skinWindow.Parent.Icon;
            _skinWindow.Visible = _skinWindow.Parent.Visible;
            _skinWindow.Maximized = _skinWindow.Parent.Maximized;
            _skinWindow.TopMost = _skinWindow.Parent.TopMost;
            _skinWindow.LockUpdate = false;
            _skinWindow.Update();
        }

        private Timer MaximizeCheckTimer
        {
            get { return _maximizeCheckTimer; }
            set
            {
                if (_maximizeCheckTimer != null)
                {
                    _maximizeCheckTimer.Tick -= MaximizeBoundsChecking;
                }
                _maximizeCheckTimer = value;
                if (_maximizeCheckTimer != null)
                {
                    _maximizeCheckTimer.Tick += MaximizeBoundsChecking;
                }
            }

        }

        private Rectangle ParentMaximizedBounds
        {
            get
            {
                Rectangle maximizedBounds = _skinWindow.Parent.Screen.WorkingArea;
                maximizedBounds.Y += _skinWindow.TopBorder1.Height - TopIncreament;
                maximizedBounds.Height += TopIncreament - _skinWindow.TopBorder1.Height;
                return maximizedBounds;
            }
        }

        private void DisposeTimer()
        {
            MaximizeCheckTimer.Enabled = false;
            MaximizeCheckTimer.Dispose();
        }

        public int TopIncreament
        {
            get
            {
                if (ExplorerSkinWindow.IsExplorerWindow(_skinWindow.Parent))
                {
                    if (Settings.Settings.HideAddressbar)
                    {
                        return Convert.ToInt32(BarsHeight.AddressBarHeight);
                    }
                    else if (Settings.Settings.HideMenuBar)
                    {
                        return Convert.ToInt32(BarsHeight.MenuBarHeight);
                    }
                }
                return 0;
            }
        }

        private enum BarsHeight : int
        {
            AddressBarHeight = 35,
            MenuBarHeight = 22
        }

        public void CreateMaximizeTimer()
        {
            MaximizeCheckTimer = new Timer();
            MaximizeCheckTimer.Interval = 500;
        }

        private void MaximizeBoundsChecking(object sender, EventArgs e)
        {
            if (!_skinWindow.IsClosing && _skinWindow.Parent.Maximized && _skinWindow.Parent.Bounds != ParentMaximizedBounds)
            {
                _skinWindow.Parent.Bounds = ParentMaximizedBounds;
            }
        }

        public void UpdateMaximizeChangesToParent()
        {
            if (Maximized)
            {
                _skinWindow.Parent.ExStyles = (_skinWindow.Parent.ExStyles & ~(int)WindowExtendedStyles.WindowEdge);
                _skinWindow.Parent.Styles = (_skinWindow.Parent.Styles & ~(int)WindowStyles.Caption & ~(int)WindowStyles.Sizebox & ~(int)WindowStyles.Border & ~(int)WindowStyles.OverLapped) | unchecked((int)(WindowStyles.Popup));

                _skinWindow.VisibleSideBorders = false;
                _skinWindow.Parent.Bounds = ParentMaximizedBounds;
                _skinWindow.UpdateBounds = _skinWindow.Parent.Bounds;

                AdjustSkinWindowToParentBounds();
                
                MaximizeCheckTimer.Start();
            }
            else
            {
                MaximizeCheckTimer.Stop();

                _skinWindow.Parent.ExStyles = (_skinWindow.Parent.ExStyles) | (int)WindowExtendedStyles.WindowEdge;
                _skinWindow.Parent.Styles = (_skinWindow.Parent.Styles & ~unchecked((int)(WindowStyles.Popup))) | (int)(WindowStyles.Caption | WindowStyles.Border | WindowStyles.Sizebox | WindowStyles.OverLapped);

                _skinWindow.VisibleSideBorders = _skinWindow.Parent.Visible && !_skinWindow.Parent.Minimized;
                _skinWindow.UpdateBounds = _skinWindow.Parent.Bounds;

                AdjustSkinWindowToParentBounds();
            }
            _skinWindow.Parent.FrameChanged();
        }

        public void AdjustSkinWindowToParentBounds()
        {
            Padding adjustBounds = new Padding {Top = TopIncreament};

            if (_skinWindow.Maximized)
            {
                adjustBounds.Top += -_skinWindow.TopBorder1.Height;
            }
            else
            {
                adjustBounds.Left = ParentBorderSize.Width - _skinWindow.LeftBorder1.Width;
                adjustBounds.Top += (SystemInformation.CaptionHeight + ParentBorderSize.Height) - _skinWindow.TopBorder1.Height;
                adjustBounds.Right = (ParentBorderSize.Width - _skinWindow.RightBorder1.Width) + adjustBounds.Left;
                adjustBounds.Bottom = (ParentBorderSize.Height - _skinWindow.BottomBorder1.Height) + adjustBounds.Top;
            }

            _skinWindow.Move(_skinWindow.UpdateBounds.X + adjustBounds.Left, _skinWindow.UpdateBounds.Y + adjustBounds.Top, _skinWindow.UpdateBounds.Width - adjustBounds.Right, _skinWindow.UpdateBounds.Height - adjustBounds.Bottom);
        }


        private Size ParentBorderSize
        {
            get
            {
                if (_parent.SizeBox || Environment.OSVersion.Version.Major == 6)
                {
                    return SystemInformation.FrameBorderSize;
                }
                return SystemInformation.FixedFrameBorderSize;
            }
        }

        private bool Maximized
        {
            get { return _skinWindow.Maximized; }
        }

        public void AttachToWindowsHook(IWindowsHook windowsHook)
        {
            DeattachFromWindowsHook();

            _windowsHook = windowsHook;

            _windowsHook.ManualUpdate += WindowsHookOnManualUpdate;
            _windowsHook.WindowActivating += WindowsHookOnWindowActivating;
            _windowsHook.WindowClosed += WindowsHookOnWindowClosed;

            _windowsHook.WindowDeactivating += WindowsHookOnWindowDeactivating;
            _windowsHook.WindowEnableChanging += WindowsHookOnWindowEnableChanging;
            _windowsHook.WindowIconChanging += WindowsHookOnWindowIconChanging;
            _windowsHook.WindowLocationChanging += WindowsHookOnWindowLocationChanging;

            _windowsHook.WindowMaximized += WindowsHookOnWindowMaximized;
            _windowsHook.WindowSizeChanging += WindowsHookOnWindowSizeChanging;
            _windowsHook.WindowSizeMoveBegins += WindowsHookOnWindowSizeMoveBegins;
            _windowsHook.WindowSizeMoveEnds += WindowsHookOnWindowSizeMoveEnds;

            _windowsHook.WindowTitleChanging += WindowsHookOnWindowTitleChanging;
            _windowsHook.WindowVisibleChanging += WindowsHookOnWindowVisibleChanging;
        }

        public void DeattachFromWindowsHook()
        {
            if (_windowsHook == null)
                return;

            _windowsHook.ManualUpdate -= WindowsHookOnManualUpdate;
            _windowsHook.WindowActivating -= WindowsHookOnWindowActivating;
            _windowsHook.WindowClosed -= WindowsHookOnWindowClosed;

            _windowsHook.WindowDeactivating -= WindowsHookOnWindowDeactivating;
            _windowsHook.WindowEnableChanging -= WindowsHookOnWindowEnableChanging;
            _windowsHook.WindowIconChanging -= WindowsHookOnWindowIconChanging;
            _windowsHook.WindowLocationChanging -= WindowsHookOnWindowLocationChanging;

            _windowsHook.WindowMaximized -= WindowsHookOnWindowMaximized;
            _windowsHook.WindowSizeChanging -= WindowsHookOnWindowSizeChanging;
            _windowsHook.WindowSizeMoveBegins -= WindowsHookOnWindowSizeMoveBegins;
            _windowsHook.WindowSizeMoveEnds -= WindowsHookOnWindowSizeMoveEnds;

            _windowsHook.WindowTitleChanging -= WindowsHookOnWindowTitleChanging;
            _windowsHook.WindowVisibleChanging -= WindowsHookOnWindowVisibleChanging;

            _windowsHook = null;
        }

        public void WindowsHookOnWindowTitleChanging(IntPtr windowHandle, NewValueEventArgs<string> args)
        {
            _skinWindow.Text = args.NewValue;
        }

        public void WindowsHookOnWindowSizeMoveEnds(IntPtr windowHandle, EventArgs args)
        {
            _skinWindow.IsMoving = false;
            if (Settings.Settings.DisableBlurOnMove || Settings.Settings.DisableFullBlurOnMove)
            {
                _skinWindow.Update();
            }
        }

        public void WindowsHookOnWindowSizeMoveBegins(IntPtr windowHandle, EventArgs args)
        {
            _skinWindow.IsMoving = true;
        }

        public void WindowsHookOnWindowSizeChanging(IntPtr windowHandle, WindowSizeChangingEventArgs args)
        {
            int result = 0;
            if (!_skinWindow.Parent.Minimized)
            {
                _skinWindow.Width = args.NewValue.Width;
                _skinWindow.UpdateBounds.Height = args.NewValue.Height;

                result = TopIncreament;
                if (result == 0)
                {
                    result = BorderRemove;
                }
            }
            args.Result = result;
        }

        public void WindowsHookOnWindowMaximized(IntPtr windowHandle, EventArgs args)
        {
            // TODO: REALLY NEEDS REFACTORING, THIS EVENTS REALLY EXCUTED FROM WM_MOVE MESSAGE
            if (_skinWindow.Parent.Maximized)
            {
                _skinWindow.Maximized = true;
                UpdateMaximizeChangesToParent();
            }
            else if (_skinWindow.Maximized && !_skinWindow.Parent.Maximized)
            {
                _skinWindow.Maximized = false;
                UpdateMaximizeChangesToParent();
            }
        }

        public void WindowsHookOnWindowLocationChanging(IntPtr windowHandle, NewValueEventArgs<Point> args)
        {
            if (!_skinWindow.Parent.Minimized)
            {
                _skinWindow.UpdateBounds.X = args.NewValue.X;
                _skinWindow.UpdateBounds.Y = args.NewValue.Y;
            }
        }

        public void WindowsHookOnWindowIconChanging(IntPtr windowHandle, NewValueEventArgs<Icon> args)
        {
            _skinWindow.Icon = args.NewValue;
            _skinWindow.Update();
        }

        public void WindowsHookOnWindowEnableChanging(IntPtr windowHandle, NewValueEventArgs<bool> args)
        {
            _skinWindow.Enabled = _skinWindow.Parent.Enabled;
        }

        public void WindowsHookOnWindowDeactivating(IntPtr windowHandle, WindowDeactivatingEventArgs args)
        {
            if (_skinWindow != args.WillBeActivated)
            {
                _skinWindow.Activated = true;
            }
        }

        public void WindowsHookOnWindowClosed(IntPtr windowHandle, EventArgs args)
        {
            _skinWindow.Dispose();
        }

        public void WindowsHookOnWindowActivating(IntPtr windowHandle, EventArgs args)
        {
            _skinWindow.Activated = true;
        }

        public void WindowsHookOnManualUpdate(IntPtr windowHandle, EventArgs args)
        {
            AdjustSkinWindowToParentBounds();
        }

        public void WindowsHookOnWindowVisibleChanging(IntPtr windowHandle, NewValueEventArgs<bool> args)
        {
            if (!_skinWindow.Parent.Minimized)
            {
                _skinWindow.Visible = args.NewValue;
            }
        }
    }
}