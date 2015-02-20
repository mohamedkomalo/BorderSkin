using System;
using System.Diagnostics;
using System.Windows.Forms;
using BorderSkin.BorderSkinning.Forms;
using LayeredForms;
using WinApiWrappers;

namespace BorderSkin.BorderSkinning.Handlers
{
    class SkinWindowButtonsHandler : IDisposable
    {
        private SkinableWindowBorder _skinWindow;

        public SkinWindowButtonsHandler(SkinableWindowBorder skinWindow)
        {
            _skinWindow = skinWindow;
            AddButtonsHandlers();
        }

        protected virtual void Dispose(bool disposing)
        {
            RemoveButtonsHandlers();
            _skinWindow = null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        

        private void AddButtonsHandlers()
        {
            _skinWindow.TitleControl1.MouseDown += TopClick;
            _skinWindow.TitleBackgroundControl1.MouseDown += TopClick;

            _skinWindow.TopBorder1.MouseDown += TopClick;
            _skinWindow.TopBorder1.Click += TopRightClick;

            _skinWindow.IconControl1.Click += IconClick;

            _skinWindow.TopBorder1.SizingMouseDown += TopSizingClick;
            _skinWindow.LeftBorder1.SizingMouseDown += LeftSizingClick;
            _skinWindow.RightBorder1.SizingMouseDown += RightSizingClick;
            _skinWindow.BottomBorder1.SizingMouseDown += BottomSizingClick;
        }

        private void RemoveButtonsHandlers()
        {
            _skinWindow.TitleControl1.MouseDown -= TopClick;
            _skinWindow.TitleBackgroundControl1.MouseDown -= TopClick;

            _skinWindow.TopBorder1.MouseDown -= TopClick;
            _skinWindow.TopBorder1.Click -= TopRightClick;

            _skinWindow.IconControl1.Click -= IconClick;

            _skinWindow.TopBorder1.SizingMouseDown -= TopSizingClick;
            _skinWindow.LeftBorder1.SizingMouseDown -= LeftSizingClick;
            _skinWindow.RightBorder1.SizingMouseDown -= RightSizingClick;
            _skinWindow.BottomBorder1.SizingMouseDown -= BottomSizingClick;
        }

        private void TopClick(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 2)
            {
                WindowFunctions.ToggleMaximize(_skinWindow.Parent);
            }
            else if (_skinWindow.Maximized)
            {
                _skinWindow.Parent.Activate();
            }
            else
            {
                ForceParentCommand(SystemCommands.DragMove);
            }
        }

        private void TopSizingClick(ResizingClickPosition Type, MouseEventArgs e)
        {
            if (Type == ResizingClickPosition.LeftCorner)
            {
                ForceParentCommand(SystemCommands.UpLeftSize);
            }
            else if (Type == ResizingClickPosition.RightCorner)
            {
                ForceParentCommand(SystemCommands.UpRightSize);
            }
            else if (Type == ResizingClickPosition.TopSizing)
            {
                ForceParentCommand(SystemCommands.UpSize);
            }
        }

        private void LeftSizingClick(ResizingClickPosition Type, MouseEventArgs e)
        {
            ForceParentCommand(SystemCommands.LeftSize);
        }

        private void RightSizingClick(ResizingClickPosition Type, MouseEventArgs e)
        {
            ForceParentCommand(SystemCommands.RightSize);
        }

        private void BottomSizingClick(ResizingClickPosition Type, MouseEventArgs e)
        {
            if (Type == ResizingClickPosition.LeftCorner)
            {
                ForceParentCommand(SystemCommands.DnLeftSize);
            }
            else if (Type == ResizingClickPosition.RightCorner)
            {
                ForceParentCommand(SystemCommands.DnRightSize);
            }
            else
            {
                ForceParentCommand(SystemCommands.DnSize);
            }
        }

        private void TopRightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TopLevelWindow.ReleaseCapture();
                _skinWindow.Parent.Activate();
                _skinWindow.Parent.PostMessage(WindowMessages.Getsysmenu, IntPtr.Zero, MakeDWord(Cursor.Position.X, Cursor.Position.Y));
            }
        }
        private void IconClick(object sender, MouseEventArgs e)
        {
            try
            {
                Debug.WriteLine("Icon Clicked");
                TopLevelWindow.ReleaseCapture();
                _skinWindow.Parent.Activate();
                if (_skinWindow.IconControl1.VerticalAlignment == VerticalAlignment.left)
                {
                    _skinWindow.Parent.PostMessage(WindowMessages.Getsysmenu, IntPtr.Zero, MakeDWord(_skinWindow.LeftBorder1.Left + _skinWindow.LeftBorder1.Width, _skinWindow.TopBorder1.Top + _skinWindow.TopBorder1.Height));
                }
                else
                {
                    _skinWindow.Parent.PostMessage(WindowMessages.Getsysmenu, IntPtr.Zero, MakeDWord(_skinWindow.TopBorder1.Left + (_skinWindow.TopBorder1.Width - _skinWindow.RightBorder1.Width), _skinWindow.TopBorder1.Top + _skinWindow.TopBorder1.Height));
                }
            }
            catch (Exception)
            {
            }
        }

        private void ForceParentCommand(SystemCommands HitTest)
        {
            TopLevelWindow.ReleaseCapture();
            _skinWindow.Parent.Activate();
            //Parent.SendMessageTimeOut(WindowMessages.SysCommand, _
            //                          New IntPtr(HitTest), _
            //                          IntPtr.Zero, _
            //                          SendMessageTimeOutFlags.Normal Or SendMessageTimeOutFlags.AbortIfHang, _
            //                          0, IntPtr.Zero)
            _skinWindow.Parent.PostMessage(WindowMessages.SysCommand, new IntPtr((int)HitTest), IntPtr.Zero);
            //using SendMessageTimeOut make hang when trying to close a window
            // and hangs the window on vista when moving so much because it causes the thread to hold until it return
        }

        private static IntPtr MakeDWord(int HiWord, int LoWord)
        {
            return new IntPtr(LoWord*0x10000 | (HiWord & 0xffff));
        }
    }
}