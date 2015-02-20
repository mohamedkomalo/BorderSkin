using System.Drawing;
using System.Windows.Forms;
using BorderSkin.BorderSkinning.Skin;
using LayeredForms;
using LayeredForms.Utilities;
using WinApiWrappers;
using Padding = System.Windows.Forms.Padding;

namespace BorderSkin.BorderSkinning.Forms
{
    public enum ResizingClickPosition
    {
        LeftCorner,
        RightCorner,
        TopSizing,
        None
    }

    public delegate void SizingMouseMoveEventHandler(ResizingClickPosition Type, MouseEventArgs e);
    public delegate void SizingMouseDownEventHandler(ResizingClickPosition Type, MouseEventArgs e);

    partial class SkinBorder : LayeredForm
    {
        private SkinableWindowBorder _SkinWindow;

        public Cursor TopCursor { get; set; }
        public Cursor LeftCornerCursor { get; set; }
        public Cursor RightCornerCursor { get; set; }

        private Cursor _normalCursor = Cursors.Default;

        public event SizingMouseMoveEventHandler SizingMouseMove;
        public event SizingMouseDownEventHandler SizingMouseDown;

        public SkinBorder(SkinableWindowBorder SkinWindow)
        {
            _SkinWindow = SkinWindow;
            Parent = SkinWindow.Parent;
            Width = 100;
            Height = 100;
            InitMouseHandlers();
            ExcludeWindowBehindBlur = Parent.Handle;
        }

        private void DrawColorSchemeOverlay(ImageWithDeviceContext destImage)
        {
//            ImageRenderer.StretchImage(destImage, BackgroundColorImageOverlay, Width, Height, ContentRect, !Settings.Settings.Transparency);
            using (var g = Graphics.FromHdc(destImage.GetHdc()))
            {
                Rectangle bounds = new Rectangle(Point.Empty, Size);
                bounds.X = ContentPadding.Left;
                bounds.Y = ContentPadding.Top;
                bounds.Width -= ContentPadding.Right + ContentPadding.Left;
                bounds.Height -= ContentPadding.Bottom + ContentPadding.Top;

                g.FillRectangle(BackgroundColorBrushOverlay, bounds);
            }
        }

        private void MaskOut(ImageWithDeviceContext destImage)
        {
            ImageRenderer.MaskOutCorners(destImage,
                                        Width, SkinElement.FrameSize, SkinElement.MaskOutBitmap,
                                        SkinElement.StretchPadding, SkinElement.MaskOutColor, SkinElement.GetStateYPosition(Activated));
        }

        private SkinElement _skinElement;

        public SkinElement SkinElement
        {
            get { return _skinElement; }
            set
            {
                _skinElement = value;
            }
        }

        protected override void DrawBackground(ImageWithDeviceContext destImage)
        {
                DrawColorSchemeOverlay(destImage);

                MaskOut(destImage);

                base.DrawBackground(destImage);

                DrawReflection(BackgroundReflectionImage, destImage, Bounds, Activated, 150, Settings.Settings.ReflectionSpeed);
        }

        public ImageWithDeviceContext BackgroundReflectionImage
        {
            get { return _SkinWindow.Skin.ReflectionImage == null ? null : _SkinWindow.Skin.ReflectionImage.Frames[0]; }
            set { }
        }

        public Brush BackgroundColorBrushOverlay
        {
            get { return _SkinWindow.Skin.ColorScheme.GetBrush(Activated); }
            set { }
        }

        public bool Activated
        {
            get { return _SkinWindow.Activated; }
            set
            {
            }
        }

        public bool Maximized
        {
            get { return _SkinWindow.Maximized; }
        }

        public new TopLevelWindow Parent
        {
            get { return NativeWindow.Parent; }
            set { NativeWindow.Parent = value; }
        }

        public new bool TopMost
        {
            get { return NativeWindow.TopMost; }
            set { NativeWindow.TopMost = value; }
        }

        public new TopLevelWindow NativeWindow
        {
            get { return TopLevelWindow.FromHandle(Handle); }
        }

        private WindowBorderSkin Skin 
        {
            get { return _SkinWindow.Skin; }
        }

        public bool AllowSizing
        {
            get { return !Maximized && Parent.SizeBox; }
        }

        public Cursor NormalCursor
        {
            get { return _normalCursor; }
            set
            {
                _normalCursor = value;
                Cursor = value;
            }
        }

        private void CornerCheck_MouseMove(object sender, MouseEventArgs e)
        {
            if (AllowSizing)
            {
                var sizingRect = Skin.SizingPadding;
                if (LeftCornerCursor == null)
                    sizingRect.Left = 0;
                if (RightCornerCursor == null)
                    sizingRect.Right = 0;
                if (TopCursor == null)
                    sizingRect.Top = 0;

                ResizingClickPosition SizeTest = TestResizingClickPosition(e.Location, Size.Width, sizingRect);
                if (e.Clicks == 1 && e.Button == MouseButtons.Left)
                {
                    if (SizingMouseDown != null)
                    {
                        SizingMouseDown(SizeTest, e);
                    }
                }
                else
                {
                    if (SizingMouseMove != null)
                    {
                        SizingMouseMove(SizeTest, e);
                    }
                }
            }
        }

        private void InitMouseHandlers()
        {
            SizingMouseMove += CornerCursorHandler;
            MouseDown += CornerCheck_MouseMove;
            MouseMove += CornerCheck_MouseMove;
        }

        private void CornerCursorHandler(ResizingClickPosition Type, MouseEventArgs e)
        {
            switch (Type)
            {
                case ResizingClickPosition.LeftCorner:
                    Cursor = LeftCornerCursor;
                    break;
                case ResizingClickPosition.RightCorner:
                    Cursor = RightCornerCursor;
                    break;
                case ResizingClickPosition.TopSizing:
                    Cursor = TopCursor;
                    break;
                case ResizingClickPosition.None:
                    if (Cursor == RightCornerCursor || Cursor == LeftCornerCursor || Cursor == TopCursor)
                    {
                        Cursor = NormalCursor;
                    }
                    break;
            }
        }

        private static ResizingClickPosition TestResizingClickPosition(Point MousePos, int BlockWidth, Padding sizingPadding)
        {
            if (MousePos.X < sizingPadding.Left)
            {
                return ResizingClickPosition.LeftCorner;
            }
            if (MousePos.X > (BlockWidth - sizingPadding.Right))
            {
                return ResizingClickPosition.RightCorner;
            }
            if (MousePos.Y < sizingPadding.Top)
            {
                return ResizingClickPosition.TopSizing;
            }
            return ResizingClickPosition.None;
        }

        private void DrawReflection(ImageWithDeviceContext ReflectionImage, ImageWithDeviceContext destImage, Rectangle WindowBounds, bool Active, byte InActiveReflection, double RefSpeed)
        {
            if (ReflectionImage == null)
                return;

            Point srcLocation = new Point(ContentPadding.Left + (int)(WindowBounds.X / RefSpeed), ContentPadding.Top + (int)(WindowBounds.Y / RefSpeed));
            Point destLocation = new Point(ContentPadding.Left, ContentPadding.Top);

            if (srcLocation.X < 0)
            {
                destLocation.X = (srcLocation.X * -1) + ContentPadding.Left;
                srcLocation.X = 0;
            }
            if (srcLocation.Y < 0)
            {
                destLocation.Y = (srcLocation.Y * -1) + ContentPadding.Top;
                srcLocation.Y = 0;
            }

            //>> 1 change the size of the reflection image to the max window track size
            //LeftPositionOnScreen >>>>>>>> WindowScreen
            //LeftPositionOnImage  >>>>>>>> MaxWindowTrackWidth

            Size reflectionSize = WindowBounds.Size;
            reflectionSize.Width -= (ContentPadding.Right + destLocation.X);
            reflectionSize.Height -= (ContentPadding.Bottom + destLocation.Y);

            //BitBlt(ReflectionImage.Buffer.Image.DC, 0, 0, _
            //                ReflectionSize.Width, ReflectionSize.Height, _
            //           ReflectionImage.Image.DC, SrcLocation.X, SrcLocation.Y, _
            //                CopyPixelOperation.SourceCopy)

            //ReflectionImage.MaskOut(ReflectionImage.Buffer.Image, Active, WindowBounds.Width)

            //AlphaBlend(BorderImage.Buffer.Image.DC, DestLocation.X, DestLocation.Y, _
            //                ReflectionSize.Width, ReflectionSize.Height, _
            //           ReflectionImage.Buffer.Image.DC, 0, 0, _
            //                ReflectionSize.Width, ReflectionSize.Height, Blend)

            destImage.AlphaBlendImage(ReflectionImage, srcLocation, destLocation, reflectionSize, Active ? (byte)255 : InActiveReflection);
        }
    }
}
