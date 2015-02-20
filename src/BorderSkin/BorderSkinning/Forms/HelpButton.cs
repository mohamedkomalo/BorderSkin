using System;
using BorderSkin.BorderSkinning.Forms;
using LayeredForms;
using WinApiWrappers;

namespace BorderSkin.BorderSkinning.Forms
{
    class HelpButton : LayeredImageButton
    {
        public HelpButton(LayeredForm parent)
            : base(parent)
        {
            var window = ((SkinBorder)Parent).Parent;
            Visible = window.HelpBox;
        }

        protected override void OnClick(System.Windows.Forms.MouseEventArgs e)
        {
            var window = ((SkinBorder)Parent).Parent;
            WindowFunctions.ForceParentCommand(window, SystemCommands.ContextHelp);
            base.OnClick(e);
        }
    }
}
