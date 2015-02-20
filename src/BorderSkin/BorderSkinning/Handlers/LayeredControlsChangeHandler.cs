using System.Drawing;
using System.Windows.Forms;
using BorderSkin.BorderSkinning.Skin;
using LayeredForms;

namespace BorderSkin.BorderSkinning.Handlers
{
    abstract class LayeredControlsChangeHandler
    {
        protected readonly SkinableWindowBorder _skinWindow;

        public LayeredControlsChangeHandler(SkinableWindowBorder skinWindow)
        {
            _skinWindow = skinWindow;
        }

        public abstract void UpdateSkinElementsOnControls();

        protected void ResetHeight(LayeredControl control, SkinElement element)
        {
            if (element == null) return;

            control.Height = element.FrameHeight;
        }

        protected void UpdateControlAppearance(LayeredControl control, SkinElement element)
        {
            if (element == null) return;

            if (element.Frames != null && element.Frames.Length > 1)
            {   
                control.BackgroundImage = _skinWindow.Activated
                    ? element.Frames[0]
                    : element.Frames[1];
            }

            control.BackgroundImageStretchExcludeMargin = element.StretchPadding;
            control.ContentPadding = element.ContentPadding;
            UpdateVerticalAlign(control, element);
        }

        protected static void UpdateVerticalAlign(LayeredControl control, SkinElement element)
        {
            if (element == null) return;

            control.VerticalAlignment = element.ElementAlign;
        }

        protected void UpdateBaseButtonAppearance(LayeredImageButton button, SkinElement element)
        {
            if (element == null) return;

            int activated = _skinWindow.Activated ? 0 : 1;

            UpdateControlAppearance(button, element);

            UpdateLocation(button, element);
            button.Size = element.FrameSize;

            if (element.Frames == null)
                return;

            int frames = element.Frames.Length / 2;

            if (frames == 1)
                return;

            button.BackgroundImage = element.Frames[0 + frames * activated];
            button.HoverBackgroundImage = element.Frames[1 + frames * activated];
            button.PressedBackgroundImage = (2 + frames * activated) < element.Frames.Length ? element.Frames[2 + frames * activated] : null;
            button.DisabledBackgroundImage = (3 + frames * activated) < element.Frames.Length ?  element.Frames[3 + frames * activated] : null;
        }

        protected void UpdateLocation(LayeredControl control, SkinElement element)
        {
            if (element == null) return;
            Padding location = _skinWindow.Maximized ? element.MaxEdges : element.NormalEdges;
            control.Location = new Point(location.Left, location.Top);

            UpdateVerticalAlign(control, element);
        }

        protected void UpdateLabel(LayeredLabel control, SkinElement element)
        {
            if (element == null) return;

            control.TextColorBrush = element.GetTextBrush(_skinWindow.Maximized); ;

            control.ContentPadding = element.ContentPadding;
            control.Font = element.Font;
            UpdateLocation(control, element);

            control.StringFormat = element.TextFormat;
        }
    }
}
