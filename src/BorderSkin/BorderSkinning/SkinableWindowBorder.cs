using System;
using System.Drawing;
using System.Windows.Forms;
using BorderSkin.BorderSkinning.Forms;
using BorderSkin.BorderSkinning.Handlers;
using BorderSkin.BorderSkinning.Skin;
using LayeredForms;
using WinApiWrappers;

namespace BorderSkin.BorderSkinning
{
    class SkinableWindowBorder : IDisposable
    {
        protected SkinBorder TopBorder;
        protected SkinBorder LeftBorder;
        protected SkinBorder RightBorder;
        protected SkinBorder BottomBorder;

        protected MinimizeButton MinimizeButton;
        protected MaximizeButton MaximizeButton;
        protected CloseButton CloseButton;
        protected HelpButton HelpButton;

        protected LayeredLabel TitleControl;
        protected LayeredControl TitleBackgroundControl;

        protected LayeredIcon IconControl;

        public Rectangle UpdateBounds;
        public bool IsClosing;
        public bool IsMoving;

        private bool _maximized;
        private bool _active;

        private WindowBorderSkin _skin;

        private TopLevelWindow _parent;

        private ProcessExitHandler _processExitHandler;
        private SettingsUpdater _settingsUpdater;
        private SkinWindowButtonsHandler _skinWindowButtonsHandler;
        private WindowEventHandler _windowEventHandler;
        private LayeredControlsChangeHandler _controlsChangeHandler;

        private bool _disposed;

        public event Action<SkinableWindowBorder> Disposed;

        protected virtual void OnDisposed(SkinableWindowBorder obj)
        {
            Action<SkinableWindowBorder> handler = Disposed;
            if (handler != null) handler(obj);
        }

        public SkinableWindowBorder(TopLevelWindow Window, WindowBorderSkin skin, bool IsExecluded)
        {
            _parent = Window;

            TopBorder = new SkinBorder(this);
            LeftBorder = new SkinBorder(this);
            RightBorder = new SkinBorder(this);
            BottomBorder = new SkinBorder(this);

            TitleBackgroundControl = new LayeredControl(TopBorder);
            TitleControl = new LayeredLabel(TopBorder);

            IconControl = new LayeredIcon(TopBorder);
            IconControl.Size = new Size(16, 16);

            MinimizeButton = new MinimizeButton(TopBorder);
            MaximizeButton = new MaximizeButton(TopBorder);
            CloseButton = new CloseButton(TopBorder);
            HelpButton = new HelpButton(TopBorder);

            if (Window.SizeBox)
            {
                TopBorder.LeftCornerCursor = Cursors.SizeNWSE;
                TopBorder.RightCornerCursor = Cursors.SizeNESW;
                TopBorder.TopCursor = Cursors.SizeNS;
                LeftBorder.NormalCursor = Cursors.SizeWE;
                RightBorder.NormalCursor = Cursors.SizeWE;
                BottomBorder.NormalCursor = Cursors.SizeNS;
                BottomBorder.LeftCornerCursor = Cursors.SizeNESW;
                BottomBorder.RightCornerCursor = Cursors.SizeNWSE;
            }
            
            _windowEventHandler = new WindowEventHandler(this, Parent);
            _settingsUpdater = new SettingsUpdater(IsExecluded, this);
            _processExitHandler = new ProcessExitHandler(this, Parent.Process);
            _skinWindowButtonsHandler = new SkinWindowButtonsHandler(this);
            _controlsChangeHandler = new SkinWindowControlsChangeHandler(this);

            Skin = skin;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed){
                OnDisposed(this);

                WindowEventHandler.Dispose();

                _processExitHandler.Dispose();
                _skinWindowButtonsHandler.Dispose();
                _settingsUpdater.Dispose();

            
                TopBorder.Dispose();
                LeftBorder.Dispose();
                RightBorder.Dispose();
                BottomBorder.Dispose();
                 
                TopBorder = null;
                LeftBorder = null;
                RightBorder = null;
                BottomBorder = null;

                MinimizeButton = null;
                MaximizeButton = null;
                CloseButton = null;
                HelpButton = null;

                TitleControl = null;
                TitleBackgroundControl = null;

                IconControl = null;

                _skin = null;

                _parent = null;

                _processExitHandler = null;
                _settingsUpdater = null;
                _skinWindowButtonsHandler = null;
                _windowEventHandler = null;
                _controlsChangeHandler = null;

                _disposed = true;
            }
        }

        public static bool operator ==(SkinableWindowBorder Value1, IntPtr Value2)
        {
            if (Value1.LeftBorder.Handle == Value2 || Value1.TopBorder.Handle == Value2 || Value1.RightBorder.Handle == Value2 || Value1.BottomBorder.Handle == Value2) {
                return true;
            }
            return false;
        }

        public static bool operator !=(SkinableWindowBorder Value1, IntPtr Value2)
        {
            return !(Value1 == Value2);
        }

        public void Update()
        {
            if (LockUpdate)
                return;

//            System.Diagnostics.Debug.WriteLine("Updaing Window " + Parent.Title + " with thread @ " + Thread.CurrentThread.ToString());

            bool topBlur = Settings.Settings.BlurEnabled && Settings.Settings.Transparency;
            bool sideBlur = topBlur && Settings.Settings.FullBlur;
            if (IsMoving)
            {
                topBlur = topBlur && !Settings.Settings.DisableBlurOnMove;
                sideBlur = topBlur && sideBlur && !Settings.Settings.DisableFullBlurOnMove;
            }

            TopBorder.BackgroundBlur = topBlur;
            RightBorder.BackgroundBlur = sideBlur;
            LeftBorder.BackgroundBlur = sideBlur;
            BottomBorder.BackgroundBlur = sideBlur;

            TopBorder.BackgroundCustomBlurStrength = Settings.Settings.BlurStrength;
            RightBorder.BackgroundCustomBlurStrength = Settings.Settings.BlurStrength;
            LeftBorder.BackgroundCustomBlurStrength = Settings.Settings.BlurStrength;
            BottomBorder.BackgroundCustomBlurStrength = Settings.Settings.BlurStrength;

            TopBorder.Update();
            RightBorder.Update();
            LeftBorder.Update();
            BottomBorder.Update();
        }


        public void Move(int X, int Y, int Width, int Height)
        {
            TopBorder.Left = X;
            TopBorder.Top = Y;
            TopBorder.Width = Width;

            LeftBorder.Left = X;
            LeftBorder.Top = Y + TopBorder.Height;
            LeftBorder.Height = Height - (TopBorder.Height + BottomBorder.Height);

            RightBorder.Left = X + Width - (RightBorder.Width);
            RightBorder.Top = LeftBorder.Top;
            RightBorder.Height = LeftBorder.Height;

            BottomBorder.Left = X;
            BottomBorder.Top = Y + Height - BottomBorder.Height;
            BottomBorder.Width = Width;

            Update();
        }

        public bool LockUpdate {
            get { return TopBorder.IsUpdateLocked(); }
            set {
                TopBorder.SuspendUpdate(value);
                LeftBorder.SuspendUpdate(value);
                RightBorder.SuspendUpdate(value);
                BottomBorder.SuspendUpdate(value);
            }
        }

        public virtual int Width {
            get { return UpdateBounds.Width; }
            set { UpdateBounds.Width = value; }
        }

        public virtual Icon Icon {
            set { IconControl.Icon = value; }
        }

        public virtual string Text {
            get { return TitleControl.Text; }
            set {
                TitleControl.Text = value;
                TitleBackgroundControl.Width = TitleControl.Width + TitleBackgroundControl.BackgroundImageStretchExcludeMargin.Left +  TitleBackgroundControl.BackgroundImageStretchExcludeMargin.Right;
                TopBorder.Update();
            }
        }

        public bool Visible {
            set {
                TopBorder.Visible = value;
                if (!Maximized) {
                    LeftBorder.Visible = value;
                    RightBorder.Visible = value;
                    BottomBorder.Visible = value;
                }
            }
        }

        public bool VisibleSideBorders {
            set {
                LeftBorder.Visible = value;
                RightBorder.Visible = value;
                BottomBorder.Visible = value;
            }
        }

        public bool TopMost {
            get { return TopBorder.TopMost; }
            set {
                TopBorder.TopMost = value;
                LeftBorder.TopMost = value;
                RightBorder.TopMost = value;
                BottomBorder.TopMost = value;
            }
        }

        public bool Enabled {
            set {
                TopBorder.Enabled = value;
                LeftBorder.Enabled = value;
                RightBorder.Enabled = value;
                BottomBorder.Enabled = value;
            }
        }

        public bool Activated {
            get { return _active; }
            set {
                _active = value;
                ControlsChangeHandler.UpdateSkinElementsOnControls();

                Update();
            }
        }

        public TopLevelWindow Parent {
            get { return _parent; }
        }

        public virtual WindowBorderSkin Skin {
            get { return _skin; }
            set {
                
                _skin = value;

                TopBorder.SkinElement = value.TopFrame;
                LeftBorder.SkinElement = value.LeftFrame;
                RightBorder.SkinElement = value.RightFrame;
                BottomBorder.SkinElement = value.BottomFrame;

                ControlsChangeHandler.UpdateSkinElementsOnControls();

                if (Maximized) {
                    WindowEventHandler.UpdateMaximizeChangesToParent();
                }
                _windowEventHandler.AdjustSkinWindowToParentBounds();
                Update();
            }
        }

        public virtual bool Maximized
        {
            get { return _maximized; }
            set
            {
                _maximized = value;

                ControlsChangeHandler.UpdateSkinElementsOnControls();
                _windowEventHandler.UpdateMaximizeChangesToParent();

                Update();
            }
        }

        public SkinBorder TopBorder1
        {
            get { return TopBorder; }
        }

        public SkinBorder LeftBorder1
        {
            get { return LeftBorder; }
        }

        public SkinBorder RightBorder1
        {
            get { return RightBorder; }
        }

        public SkinBorder BottomBorder1
        {
            get { return BottomBorder; }
        }

        public LayeredImageButton MinimizeButton1
        {
            get { return MinimizeButton; }
        }

        public LayeredImageButton MaximizeButton1
        {
            get { return MaximizeButton; }
        }

        public LayeredImageButton CloseButton1
        {
            get { return CloseButton; }
        }

        public LayeredImageButton HelpButton1
        {
            get { return HelpButton; }
        }

        public LayeredIcon IconControl1
        {
            get { return IconControl; }
        }

        public LayeredControl TitleBackgroundControl1
        {
            get { return TitleBackgroundControl; }
        }

        public LayeredLabel TitleControl1
        {
            get { return TitleControl; }
        }

        public WindowEventHandler WindowEventHandler
        {
            get { return _windowEventHandler; }
        }

        protected virtual LayeredControlsChangeHandler ControlsChangeHandler
        {
            get { return _controlsChangeHandler; }
        }
    }
}
