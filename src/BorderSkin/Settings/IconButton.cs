using System;
using System.Drawing;
using System.Windows.Forms;

namespace BorderSkin.Settings
{
    class IconButton : Label
    {


        private const int WidthPadding = 5;

        public IconButton()
        {
            SizeChanged += OnEvent;
            Invalidated += OnEvent;
            TextChanged += OnEvent;
        }

        private void OnEvent(object sender, EventArgs e)
        {
            if (Image != null) {
                Width = Image.Width + PreferredSize.Width + WidthPadding;
                //Me.Height = Image.Height

                if (!(ImageAlign == ContentAlignment.MiddleLeft)) {
                    ImageAlign = ContentAlignment.MiddleLeft;
                }
                if (!(TextAlign == ContentAlignment.MiddleRight)) {
                    TextAlign = ContentAlignment.MiddleRight;
                }
            }
        }
    }
}
