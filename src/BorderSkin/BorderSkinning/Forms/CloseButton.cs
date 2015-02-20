using System;
using BorderSkin.BorderSkinning.Forms;
using LayeredForms;

namespace BorderSkin.BorderSkinning.Forms
{
    class CloseButton : LayeredImageButton
    {
        public CloseButton(LayeredForm parent)
            : base(parent)
        {
            var window = ((SkinBorder)Parent).Parent;
            Visible = window.CloseBox;
        }

        protected override void OnClick(System.Windows.Forms.MouseEventArgs e)
        {
            var window = ((SkinBorder)Parent).Parent;
            window.Close();

            base.OnClick(e);
        }
    }
}
