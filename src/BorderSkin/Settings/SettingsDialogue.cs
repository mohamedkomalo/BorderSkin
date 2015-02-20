using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using BorderSkin.BorderSkinning;
using BorderSkin.BorderSkinning.Explorer.Skin;
using BorderSkin.BorderSkinning.Skin;
using BorderSkin.ErrorHandling;
using BorderSkin.Language;

namespace BorderSkin.Settings
{
    partial class SettingsDialogue
    {

        public SettingsDialogue()
        {
            VisibleChanged += Me_VisibleChanged;
            InitializeComponent();

            ReBuildGroups();
            Application.EnableVisualStyles();

            TrayIcon.Icon = Icon;
            TrayIcon.Visible = Settings.ShowTrayIcon;

            this.Text = Application.ProductName;
            ProgramName.Text = Application.ProductName;
            ProgramVersion.Text = Application.ProductVersion;
            Developer.Text = Application.CompanyName;
            ProductWebsite.Text = Program.BorderSkinWebsite;
            DefaultWebsite.Text = Program.KomaloWebsite;
            GithubWebsite.Text = Program.KomaloGithubWebsite;
            SourceCodeWebsite.Text = Program.SourceCodeWebsite;

            InclusionManager.IsInclusionList = true;
            InclusionManager.RebuildList();
            ExclusionManager.RebuildList();

            BlurStrength.Value = Settings.BlurStrength;
            double Ref1 = Settings.ReflectionSpeed - 1;
            double Ref2 = Ref1 * 10;
            try {
                ReflectionSpeed.Value = Convert.ToInt32(Ref2);
            } catch (Exception ex) {
                ErrorManager.ProccessError(ex, "Reflection Value Error, Value =" + Ref2);
            }

            BlurStrength_Scroll(null, null);
            ReflectionSpeed_Scroll(null, null);

            SetSettingsCheck(Controls);
            AddHandlers(Controls);
            ApplyLanguage();

        }

        static SettingsDialogue set;
        public static void StartTray()
        {
            set = new SettingsDialogue();
        }

        public static void UnLoad()
        {
            set.Visible = false;
            set.Dispose();
        }

        private void ReBuildGroups()
        {
            ReBuildLangGroups();
            ReBuildSkinGroups();
            RebuildSkinsLists();
            RebuildColorsLists();
            ReBuildLanguageList();
        }

        //---------------------- Language ---------------------------------

        public void ApplyLanguage()
        {
            Settings.Language.ApplyTranslation(Controls);
            Settings.Language.ApplyTranslation(TrayMenu.Items);
        }

        private void LanguageList_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (LanguageList.Text == Settings.Language.Name)
                return;
            Settings.Language = LanguageFile.LoadFromDefault(LanguageList.Text);
            ApplyLanguage();
            ReBuildLangGroups();
        }

        private void ReBuildLangGroups()
        {
            LangAuthor.Text = Settings.Language.Author;
            LangWebsite.Text = Settings.Language.Website;
            LanguageList.SelectedItem = Settings.Language.Name;
        }

        private void ReBuildLanguageList()
        {
            LanguageList.Items.Clear();
            DirectoryInfo Root = new DirectoryInfo(LanguageFile.LanguagesFolder);
            foreach (FileInfo File in Root.GetFiles()) {
                try {
                    if (File.Extension == ".ini") {
                        LanguageList.Items.Add(Path.GetFileNameWithoutExtension(File.Name));
                    }
                } catch (Exception) {
                }
            }
            ReBuildLangGroups();
        }

        //------------------------------- Skins --------------------------------

        private void ReBuildSkinGroups()
        {
            SkinPreview.ImageLocation = Settings.Skin.TopFrame.ImagePath;
            ExpSkinPreview.ImageLocation = Settings.ExplorerSkin.TopFrame.ImagePath;

            SkinName.Text = Settings.Skin.Name;
            SkinAuthor.Text = Settings.Skin.Author;
            SkinWebsite.Text = Settings.Skin.Website;

            ExpSkinName.Text = Settings.ExplorerSkin.Name;
            ExpSkinAuthor.Text = Settings.ExplorerSkin.Author;
            ExpSkinWebsite.Text = Settings.ExplorerSkin.Website;
        }

        private void RebuildColorsLists()
        {
            SkinColorList.Items.Clear();
            ExpColorList.Items.Clear();
            foreach (string ExplorerColorSchemeName in Settings.ExplorerSkin.ColorSchemes) {
                ExpColorList.Items.Add(ExplorerColorSchemeName);
            }
            foreach (string ColorSchemeName in Settings.Skin.ColorSchemes) {
                SkinColorList.Items.Add(ColorSchemeName);
            }
            SkinColorList.SelectedItem = Settings.Skin.ColorScheme.Name;
            ExpColorList.SelectedItem = Settings.ExplorerSkin.ColorScheme.Name;
        }

        private void RebuildSkinsLists()
        {
            SkinList.Items.Clear();
            ExpSkinList.Items.Clear();
            DirectoryInfo Root = new DirectoryInfo(SkinPaths.SkinsFolder);
            foreach (DirectoryInfo DirectoryName in Root.GetDirectories()) {
                try {
                    if (ExplorerSkin.IsExplorerSkin(DirectoryName.Name)) {
                        ExpSkinList.Items.Add(DirectoryName.Name);
                    } else {
                        SkinList.Items.Add(DirectoryName.Name);
                    }
                } catch (Exception) {
                }
            }
            SkinList.SelectedItem = Settings.Skin.Name;
            ExpSkinList.SelectedItem = Settings.ExplorerSkin.Name;
        }

        //--------------------------- Skins Options -------------------------------

        private void SkinList_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (SkinList.Text == Settings.Skin.Name)
                return;
            ChangeSkin(SkinList.Text, "Default");
        }

        private void SkinColorList_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (SkinColorList.Text == Settings.Skin.ColorScheme.Name)
                return;
            Settings.Skin.ChangeColorScheme(SkinColorList.Text);

            Settings.OnBorderUISettingsChanged();
            Settings.OnPropertyChanged("Skin");
        }

        private void ExpSkinList_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (ExpSkinList.Text == Settings.ExplorerSkin.Name)
                return;
            ChangeExpSkin(ExpSkinList.Text, "Default");
        }

        private void ExpColorList_SelectedIndexChanged(object sender, EventArgs args)
        {
            if (ExpColorList.Text == Settings.ExplorerSkin.ColorScheme.Name)
                return;

            Settings.ExplorerSkin.ChangeColorScheme(ExpColorList.Text);

            Settings.OnBorderUISettingsChanged();
            Settings.OnPropertyChanged("ExplorerSkin");
        }

        private void UpdateWindowsFromList(List<SkinableWindowBorder> list)
        {
            foreach (SkinableWindowBorder sw in list) {
                sw.Update();
            }
        }

        public void ChangeSkin(string Name, string Color)
        {
            Settings.Skin.Dispose();
            Settings.Skin = WindowBorderSkinProvider.LoadTheme(SkinList.Text, SkinColorList.Text);
            RebuildColorsLists();
            ReBuildSkinGroups();
        }

        public void ChangeExpSkin(string Name, string Color)
        {
            Settings.ExplorerSkin.Dispose();
            Settings.ExplorerSkin = ExplorerSkin.LoadTheme(Name, Color);
            RebuildColorsLists();
            ReBuildSkinGroups();
        }

        //------------------------- Auto Boolean Options ----------------------------------

        private void AddHandlers(Control.ControlCollection Controls)
        {
            foreach (Control c in Controls) {
                if ((c) is CheckBox) {
                    CheckBox cb = (CheckBox)c;
                    cb.CheckedChanged += Setting_CheckedChanged;
                }
                AddHandlers(c.Controls);
            }
        }

        private void SetSettingsCheck(Control.ControlCollection Controls)
        {
            foreach (Control c in Controls) {
                if ((c) is CheckBox) {
                    CheckBox cb = (CheckBox)c;
                    cb.SuspendLayout();
                    cb.Checked = Convert.ToBoolean(typeof(Settings).GetProperty(cb.Name).GetValue(null, null));
                    cb.ResumeLayout();
                }
                SetSettingsCheck(c.Controls);
            }
        }

        private void Setting_CheckedChanged(Object sender, EventArgs e)
        {
            CheckBox SettingCheck = (CheckBox)sender;
            string SettingName = SettingCheck.Name;
            PropertyInfo p = typeof(Settings).GetProperty(SettingName);
            p.SetValue(null, SettingCheck.Checked, null);
        }

        //------------------------- Other Options ----------------------------------

        private void BlurStrength_Scroll(object sender, EventArgs args)
        {
            BlurValue.Text = BlurStrength.Value.ToString();
            Settings.BlurStrength = BlurStrength.Value;
        }

        private void ReflectionSpeed_Scroll(object sender, EventArgs args)
        {
            ReflectionValue.Text = ReflectionSpeed.Value.ToString();
            double Ref1 = ReflectionSpeed.Value / 10;
            Settings.ReflectionSpeed = Ref1 + 1;
        }

        //---------------------------- On Check Group Enable Handlers ---------------

        private void Transparency_CheckedChanged(object sender, EventArgs args)
        {
            BlurGroup.Enabled = Transparency.Enabled;
        }

        private void ExplorerSkinning_CheckedChanged(Object sender, EventArgs e)
        {
            ExpSkinGroup.Enabled = ExplorerSkinning.Checked;
        }

        private void BorderSkinning_CheckedChanged(Object sender, EventArgs e)
        {
            SkinGroup.Enabled = BorderSkinning.Checked;
        }

        private void Reflection_CheckedChanged(object sender, EventArgs args)
        {
            ReflectionGroup.Enabled = Reflection.Checked;
        }

        //------------------------------ Close/Hide ----------------------------------


        private void ExitButton_Click(object sender, EventArgs args)
        {
            Program.Exit();
        }

        private void HideButton_Click(object sender, EventArgs args)
        {
            Close();
        }

        private void SettingsDialogue_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {
                WindowState = FormWindowState.Minimized;
                Hide();
                e.Cancel = true;
            }
        }

        //------------------------------ Options Need Update --------------------------

        private void ShowTrayIcon_CheckedChanged(object sender, EventArgs e)
        {
            TrayIcon.Visible = ShowTrayIcon.Checked;
        }

        //------------------------------ Website Links Handler -------------------------

        private void LinkLabel_LinkClicked(Object sender, LinkLabelLinkClickedEventArgs e)
        {
            try {
                string Link = ((LinkLabel)sender).Text;
                if (string.IsNullOrEmpty(Link))
                    return;
                if (!Link.Contains("https://")) {
                    Link = Link.Insert(0, "https://");
                }
                Process.Start(Link);
            } catch (Exception) {
            }
        }

        private void MoreExpThemes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Program.MoreExpSkinsWebsite);
        }

        private void MoreLang_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Program.MoreLangWebsite);
        }

        private void MoreThemes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Program.MoreSkinsWebsite);
        }

        private void AddSkin_Click(object sender, EventArgs args)
        {
            FolderBrowserDialog FolderDialogue = new FolderBrowserDialog();
            FolderDialogue.ShowDialog();
            //TTSkinConverter.ConvertSkin(FolderDialogue.SelectedPath);
            RebuildSkinsLists();
        }

        private void Me_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) {
                BringToFront();
                Invalidate();
            }
        }

        private void PreferenceItem_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            ExitButton_Click(null, null);
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

    }
}
