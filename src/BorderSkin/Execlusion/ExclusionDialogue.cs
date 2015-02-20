using System;
using System.Drawing;
using System.Windows.Forms;
using BorderSkin.BorderSkinning.Skin;
using BorderSkin.BorderSkinning.Skin.Ini;
using WinApiWrappers;

namespace BorderSkin.Execlusion
{
    partial class ExclusionDialogue
    {
        public ExclusionDialogue()
        {
            Application.EnableVisualStyles();
            InitializeComponent();

            RebuildWindowsList();
            RebuildSkinsLists();

            Settings.Settings.Language.ApplyTranslation(Controls);
        }

        private void RebuildColorsList()
        {
            ColorSchemeTxt.Items.Clear();
            foreach (string ColorSchemeName in SkinIniLoader.GetColorSchemes(SkinTxt.Text)) {
                ColorSchemeTxt.Items.Add(ColorSchemeName);
            }
            ColorSchemeTxt.SelectedItem = "Default";
        }

        private void RebuildSkinsLists()
        {
            SkinTxt.Items.Clear();
            foreach (string Name in WindowBorderSkinProvider.AllSkins) {
                SkinTxt.Items.Add(Name);
            }
            SkinTxt.SelectedItem = Settings.Settings.Skin.Name;
        }

        private void SkinTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebuildColorsList();
        }

        private void RebuildWindowsList()
        {
            foreach (Bitmap b in WindowsIcons.Images) {
                b.Dispose();
            }
            WindowsIcons.Images.Clear();
            WindowsList.Items.Clear();

            foreach (TopLevelWindow w in TopLevelWindow.Windows) {

                if (w.CloseBox && w.HasCaption && w.Visible && !string.IsNullOrEmpty(w.Title)) {
                    if (!WindowsIcons.Images.ContainsKey(w.Title)) {
                        if (w.Icon != null) {
                            WindowsIcons.Images.Add(w.Title, w.Icon.ToBitmap());
                        }
                    }
                    WindowsList.Items.Add(w.Title, w.Title);
                }
            }
        }

        public ExcludedWindow ExcludeInfo {
            get {
                ExcludedWindow functionReturnValue = default(ExcludedWindow);
                functionReturnValue = new ExcludedWindow(ProgramTxt.Text, ProcessTxt.Text, ClassesTxt.Text, SkinTxt.Text, ColorSchemeTxt.Text, SkinedCheckBox.Checked);
                return functionReturnValue;
            }
            set {
                ProgramTxt.Text = value.ExclusionName;
                ProcessTxt.Text = value.ProcessName;
                ClassesTxt.Text = value.ClassNames;
                SkinTxt.Text = value.SkinName;
                ColorSchemeTxt.Text = value.ColorSchemeName;
                SkinedCheckBox.Checked = value.HasSkin;
            }
        }

        private void WindowsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (WindowsList.SelectedItems.Count > 0) {
                TopLevelWindow w = new TopLevelWindow(WindowsList.SelectedItems[0].Text);
                if (w.Exists) {
                    ProgramTxt.Text = w.Title;
                    ProcessTxt.Text = w.ProcessName;
                    ClassesTxt.Text = w.ClassName;
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SkinedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SkinGroup.Enabled = SkinedCheckBox.Checked;
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RebuildWindowsList();
        }



    }
}
