using System.Drawing;
using System.Windows.Forms;
using BorderSkin.BorderSkinning.Forms;
using BorderSkin.BorderSkinning.Skin;
using LayeredForms;
using LayeredForms.Utilities;

namespace BorderSkin.BorderSkinning.Explorer.Forms
{
    class LayeredButtonWithSkinElement : LayeredButton
    {
        public bool DefaultLocation = false;

        public LayeredButtonWithSkinElement(SkinBorder Parent) : base(Parent)
        {
        }

        public override Padding ContentPadding
        {
            get { return Padding.Empty; }
        }

        public override Padding TextPadding
        {
            get { return SkinElement.ContentPadding; }
        }

        public override Size Size {
            get {
                Size size = SkinElement.FrameSize;
                if (SizeType == SizingType.SizeToText) {
                    size.Width = TextWidth + SkinElement.StretchPadding.Left + SkinElement.StretchPadding.Right;

                } else if (SizeType == SizingType.SizeToRightWidth) {
                    size.Width = RightWidth;
                }
                return size;
            }
        }
        
        public override StringFormat StringFormat
        {
            get { return SkinElement.TextFormat; }
        }

        public override SolidBrush TextColorBrush
        {
            get { return SkinElement.GetTextBrush(Parent.Maximized); }
        }

        public new SkinBorder Parent
        {
            get { return (SkinBorder)base.Parent; }
        }

        public override Font Font
        {
            get { return SkinElement.Font; }
        }

        /**********
         */

//        public override Point Location
//        {
//            get { return SkinElement.GetEdges(Parent.Width, Parent.Maximized, Size.Width).Location; }
//        }
//
//
//        public override Size Size
//        {
//            get { return SkinElement.FrameSize; }
//
//        }

        private int Frames
        {
            get { return SkinElement.Frames.Length / 2; }
        }

        public override ImageWithDeviceContext BackgroundImage
        {
            get { return SkinElement.Frames[0 + (Parent.Activated ? 0 : Frames)]; }
        }

        public override ImageWithDeviceContext HoverBackgroundImage
        {
            get { return SkinElement.Frames[1 + (Parent.Activated ? 0 : Frames)]; }
        }

        public override ImageWithDeviceContext PressedBackgroundImage
        {
            get { return SkinElement.Frames[2 + (Parent.Activated ? 0 : Frames)]; }
        }

        public override Padding BackgroundImageStretchExcludeMargin
        {
            get { return SkinElement.StretchPadding; }
        }

        public override VerticalAlignment TextVerticalAlignment
        {
            get { return SkinElement.TextAlign; }
        }


        public SkinElement SkinElement { get; set; }
    }
}
