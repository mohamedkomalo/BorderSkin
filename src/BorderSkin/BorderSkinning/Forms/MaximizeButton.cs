using System;
using BorderSkin.BorderSkinning.Forms;
using LayeredForms;

namespace BorderSkin.BorderSkinning.Forms
{
    class MaximizeButton : LayeredImageButton
    {
        public MaximizeButton(LayeredForm parent)
            : base(parent)
        {
            var window = ((SkinBorder)Parent).Parent;
            Enabled = window.MaximizeBox;
            Visible = window.MaximizeBox || (window.CloseBox && window.MinimizeBox);
        }

        protected override void OnClick(System.Windows.Forms.MouseEventArgs e)
        {
            var window = ((SkinBorder)Parent).Parent;
            WindowFunctions.ToggleMaximize(window);

            base.OnClick(e);
        }
    }
}
