using System;
using BorderSkin.BorderSkinning.Forms;
using LayeredForms;

namespace BorderSkin.BorderSkinning.Forms
{
    class MinimizeButton : LayeredImageButton
    {
        public MinimizeButton(LayeredForm parent) : base(parent)
        {
            var window = ((SkinBorder)Parent).Parent;

            Visible = window.MinimizeBox || (window.CloseBox && window.MaximizeBox);
            Enabled = window.MinimizeBox;

        }

        protected override void OnClick(System.Windows.Forms.MouseEventArgs e)
        {
            var window = ((SkinBorder)Parent).Parent;
            window.Minimize();
            base.OnClick(e);
        }
    }
}
