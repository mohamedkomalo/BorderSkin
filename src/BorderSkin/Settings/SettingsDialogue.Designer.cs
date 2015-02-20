using BorderSkin.Execlusion;

namespace BorderSkin.Settings
{
    partial class SettingsDialogue : System.Windows.Forms.Form
    {

        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer

        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialogue));
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PreferenceItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DefaultWebsite = new System.Windows.Forms.LinkLabel();
            this.SkinsPage = new System.Windows.Forms.TabPage();
            this.ExplorerSkinning = new System.Windows.Forms.CheckBox();
            this.BorderSkinning = new System.Windows.Forms.CheckBox();
            this.ExpSkinGroup = new System.Windows.Forms.GroupBox();
            this.MoreExpThemes = new System.Windows.Forms.LinkLabel();
            this.ExpSkinAuthor = new System.Windows.Forms.Label();
            this.ExpSkinPreview = new System.Windows.Forms.PictureBox();
            this.ExpSkinName = new System.Windows.Forms.Label();
            this.ExpSkinWebsite = new System.Windows.Forms.LinkLabel();
            this.Label41 = new System.Windows.Forms.Label();
            this.ExpColorList = new System.Windows.Forms.ComboBox();
            this.Label42 = new System.Windows.Forms.Label();
            this.ExpSkinList = new System.Windows.Forms.ComboBox();
            this.SkinGroup = new System.Windows.Forms.GroupBox();
            this.SkinAuthor = new System.Windows.Forms.Label();
            this.MoreThemes = new System.Windows.Forms.LinkLabel();
            this.SkinPreview = new System.Windows.Forms.PictureBox();
            this.SkinName = new System.Windows.Forms.Label();
            this.SkinWebsite = new System.Windows.Forms.LinkLabel();
            this.Label32 = new System.Windows.Forms.Label();
            this.SkinColorList = new System.Windows.Forms.ComboBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.SkinList = new System.Windows.Forms.ComboBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.GroupBox18 = new System.Windows.Forms.GroupBox();
            this.ShowTrayIcon = new System.Windows.Forms.CheckBox();
            this.RunStartUp = new System.Windows.Forms.CheckBox();
            this.Label96 = new System.Windows.Forms.Label();
            this.GroupBox14 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label81 = new System.Windows.Forms.Label();
            this.PictureBox5 = new System.Windows.Forms.PictureBox();
            this.ProductWebsite = new System.Windows.Forms.LinkLabel();
            this.Developer = new System.Windows.Forms.Label();
            this.ProgramVersion = new System.Windows.Forms.Label();
            this.ProgramName = new System.Windows.Forms.Label();
            this.Label86 = new System.Windows.Forms.Label();
            this.Label87 = new System.Windows.Forms.Label();
            this.Label89 = new System.Windows.Forms.Label();
            this.Label90 = new System.Windows.Forms.Label();
            this.GroupBox17 = new System.Windows.Forms.GroupBox();
            this.Label95 = new System.Windows.Forms.Label();
            this.LangWebsite = new System.Windows.Forms.LinkLabel();
            this.MoreLang = new System.Windows.Forms.LinkLabel();
            this.Label91 = new System.Windows.Forms.Label();
            this.LangAuthor = new System.Windows.Forms.Label();
            this.Label93 = new System.Windows.Forms.Label();
            this.LanguageList = new System.Windows.Forms.ComboBox();
            this.Label94 = new System.Windows.Forms.Label();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.Reflection = new System.Windows.Forms.CheckBox();
            this.ReflectionGroup = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.ReflectionValue = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.ReflectionSpeed = new System.Windows.Forms.TrackBar();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.Label67 = new System.Windows.Forms.Label();
            this.HideAddressbar = new System.Windows.Forms.CheckBox();
            this.HideMenuBar = new System.Windows.Forms.CheckBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.BlurEnabled = new System.Windows.Forms.CheckBox();
            this.Transparency = new System.Windows.Forms.CheckBox();
            this.BlurGroup = new System.Windows.Forms.GroupBox();
            this.DisableFullBlurOnMove = new System.Windows.Forms.CheckBox();
            this.DisableBlurOnMove = new System.Windows.Forms.CheckBox();
            this.BlurValue = new System.Windows.Forms.Label();
            this.FullBlur = new System.Windows.Forms.CheckBox();
            this.Label75 = new System.Windows.Forms.Label();
            this.BlurStrength = new System.Windows.Forms.TrackBar();
            this.TabPage4 = new System.Windows.Forms.TabPage();
            this.TabPage5 = new System.Windows.Forms.TabPage();
            this.SourceCodeWebsite = new System.Windows.Forms.LinkLabel();
            this.GithubWebsite = new System.Windows.Forms.LinkLabel();
            this.RemoveExpSkin = new BorderSkin.Settings.IconButton();
            this.AddExpSkin = new BorderSkin.Settings.IconButton();
            this.RemoveSkin = new BorderSkin.Settings.IconButton();
            this.AddSkin = new BorderSkin.Settings.IconButton();
            this.InclusionManager = new BorderSkin.Execlusion.ExclusionManagerControl();
            this.ExclusionManager = new BorderSkin.Execlusion.ExclusionManagerControl();
            this.ExitButton = new BorderSkin.Settings.IconButton();
            this.HideButton = new BorderSkin.Settings.IconButton();
            this.TrayMenu.SuspendLayout();
            this.SkinsPage.SuspendLayout();
            this.ExpSkinGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExpSkinPreview)).BeginInit();
            this.SkinGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkinPreview)).BeginInit();
            this.TabControl1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.GroupBox18.SuspendLayout();
            this.GroupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).BeginInit();
            this.GroupBox17.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.ReflectionGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReflectionSpeed)).BeginInit();
            this.GroupBox7.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.BlurGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlurStrength)).BeginInit();
            this.TabPage4.SuspendLayout();
            this.TabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.TrayMenu;
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // TrayMenu
            // 
            this.TrayMenu.AllowMerge = false;
            this.TrayMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PreferenceItem,
            this.ToolStripMenuItem1,
            this.ExitItem});
            this.TrayMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TrayMenu.Name = "ContextMenuStrip1";
            this.TrayMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.TrayMenu.ShowCheckMargin = true;
            this.TrayMenu.ShowImageMargin = false;
            this.TrayMenu.Size = new System.Drawing.Size(137, 54);
            // 
            // PreferenceItem
            // 
            this.PreferenceItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreferenceItem.Name = "PreferenceItem";
            this.PreferenceItem.Size = new System.Drawing.Size(136, 22);
            this.PreferenceItem.Tag = "Preference";
            this.PreferenceItem.Text = "Preference";
            this.PreferenceItem.ToolTipText = "Import A TTSkin";
            this.PreferenceItem.Click += new System.EventHandler(this.PreferenceItem_Click);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // ExitItem
            // 
            this.ExitItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(136, 22);
            this.ExitItem.Tag = "Exit";
            this.ExitItem.Text = "Exit";
            this.ExitItem.Click += new System.EventHandler(this.ExitItem_Click);
            // 
            // DefaultWebsite
            // 
            this.DefaultWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DefaultWebsite.AutoSize = true;
            this.DefaultWebsite.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultWebsite.Location = new System.Drawing.Point(123, 115);
            this.DefaultWebsite.Name = "DefaultWebsite";
            this.DefaultWebsite.Size = new System.Drawing.Size(41, 13);
            this.DefaultWebsite.TabIndex = 31;
            this.DefaultWebsite.TabStop = true;
            this.DefaultWebsite.Text = "(value)";
            this.DefaultWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // SkinsPage
            // 
            this.SkinsPage.Controls.Add(this.ExplorerSkinning);
            this.SkinsPage.Controls.Add(this.BorderSkinning);
            this.SkinsPage.Controls.Add(this.ExpSkinGroup);
            this.SkinsPage.Controls.Add(this.SkinGroup);
            this.SkinsPage.Location = new System.Drawing.Point(4, 22);
            this.SkinsPage.Name = "SkinsPage";
            this.SkinsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SkinsPage.Size = new System.Drawing.Size(655, 310);
            this.SkinsPage.TabIndex = 7;
            this.SkinsPage.Tag = "Skins & Themes";
            this.SkinsPage.Text = "Skins & Themes";
            this.SkinsPage.UseVisualStyleBackColor = true;
            // 
            // ExplorerSkinning
            // 
            this.ExplorerSkinning.AutoSize = true;
            this.ExplorerSkinning.ForeColor = System.Drawing.Color.Blue;
            this.ExplorerSkinning.Location = new System.Drawing.Point(338, 13);
            this.ExplorerSkinning.Name = "ExplorerSkinning";
            this.ExplorerSkinning.Size = new System.Drawing.Size(143, 17);
            this.ExplorerSkinning.TabIndex = 36;
            this.ExplorerSkinning.Tag = "Enable Explorer Skinning";
            this.ExplorerSkinning.Text = "Enable Explorer Skinning";
            this.ExplorerSkinning.UseVisualStyleBackColor = true;
            this.ExplorerSkinning.CheckedChanged += new System.EventHandler(this.ExplorerSkinning_CheckedChanged);
            // 
            // BorderSkinning
            // 
            this.BorderSkinning.AutoSize = true;
            this.BorderSkinning.ForeColor = System.Drawing.Color.Blue;
            this.BorderSkinning.Location = new System.Drawing.Point(16, 13);
            this.BorderSkinning.Name = "BorderSkinning";
            this.BorderSkinning.Size = new System.Drawing.Size(135, 17);
            this.BorderSkinning.TabIndex = 8;
            this.BorderSkinning.Tag = "Enable Border Skinning";
            this.BorderSkinning.Text = "Enable Border Skinning";
            this.BorderSkinning.UseVisualStyleBackColor = true;
            this.BorderSkinning.CheckedChanged += new System.EventHandler(this.BorderSkinning_CheckedChanged);
            // 
            // ExpSkinGroup
            // 
            this.ExpSkinGroup.Controls.Add(this.MoreExpThemes);
            this.ExpSkinGroup.Controls.Add(this.ExpSkinAuthor);
            this.ExpSkinGroup.Controls.Add(this.RemoveExpSkin);
            this.ExpSkinGroup.Controls.Add(this.AddExpSkin);
            this.ExpSkinGroup.Controls.Add(this.ExpSkinPreview);
            this.ExpSkinGroup.Controls.Add(this.ExpSkinName);
            this.ExpSkinGroup.Controls.Add(this.ExpSkinWebsite);
            this.ExpSkinGroup.Controls.Add(this.Label41);
            this.ExpSkinGroup.Controls.Add(this.ExpColorList);
            this.ExpSkinGroup.Controls.Add(this.Label42);
            this.ExpSkinGroup.Controls.Add(this.ExpSkinList);
            this.ExpSkinGroup.Location = new System.Drawing.Point(333, 16);
            this.ExpSkinGroup.Name = "ExpSkinGroup";
            this.ExpSkinGroup.Size = new System.Drawing.Size(308, 265);
            this.ExpSkinGroup.TabIndex = 37;
            this.ExpSkinGroup.TabStop = false;
            this.ExpSkinGroup.Tag = "";
            // 
            // MoreExpThemes
            // 
            this.MoreExpThemes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoreExpThemes.AutoSize = true;
            this.MoreExpThemes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoreExpThemes.LinkArea = new System.Windows.Forms.LinkArea(0, 100);
            this.MoreExpThemes.Location = new System.Drawing.Point(180, 108);
            this.MoreExpThemes.Name = "MoreExpThemes";
            this.MoreExpThemes.Size = new System.Drawing.Size(76, 18);
            this.MoreExpThemes.TabIndex = 40;
            this.MoreExpThemes.TabStop = true;
            this.MoreExpThemes.Tag = "More Skins ....";
            this.MoreExpThemes.Text = "More Skins ....";
            this.MoreExpThemes.UseCompatibleTextRendering = true;
            this.MoreExpThemes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MoreExpThemes_LinkClicked);
            // 
            // ExpSkinAuthor
            // 
            this.ExpSkinAuthor.AutoEllipsis = true;
            this.ExpSkinAuthor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpSkinAuthor.Location = new System.Drawing.Point(20, 65);
            this.ExpSkinAuthor.Name = "ExpSkinAuthor";
            this.ExpSkinAuthor.Size = new System.Drawing.Size(154, 21);
            this.ExpSkinAuthor.TabIndex = 14;
            this.ExpSkinAuthor.Text = "(value)";
            // 
            // ExpSkinPreview
            // 
            this.ExpSkinPreview.Location = new System.Drawing.Point(180, 28);
            this.ExpSkinPreview.Name = "ExpSkinPreview";
            this.ExpSkinPreview.Size = new System.Drawing.Size(111, 77);
            this.ExpSkinPreview.TabIndex = 34;
            this.ExpSkinPreview.TabStop = false;
            // 
            // ExpSkinName
            // 
            this.ExpSkinName.AutoEllipsis = true;
            this.ExpSkinName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpSkinName.Location = new System.Drawing.Point(15, 33);
            this.ExpSkinName.Name = "ExpSkinName";
            this.ExpSkinName.Size = new System.Drawing.Size(159, 30);
            this.ExpSkinName.TabIndex = 33;
            this.ExpSkinName.Tag = "";
            this.ExpSkinName.Text = "(Value)";
            // 
            // ExpSkinWebsite
            // 
            this.ExpSkinWebsite.AutoEllipsis = true;
            this.ExpSkinWebsite.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpSkinWebsite.Location = new System.Drawing.Point(17, 87);
            this.ExpSkinWebsite.Name = "ExpSkinWebsite";
            this.ExpSkinWebsite.Size = new System.Drawing.Size(157, 45);
            this.ExpSkinWebsite.TabIndex = 32;
            this.ExpSkinWebsite.TabStop = true;
            this.ExpSkinWebsite.Tag = "";
            this.ExpSkinWebsite.Text = "No Website";
            // 
            // Label41
            // 
            this.Label41.AutoSize = true;
            this.Label41.Location = new System.Drawing.Point(14, 186);
            this.Label41.Name = "Label41";
            this.Label41.Size = new System.Drawing.Size(72, 13);
            this.Label41.TabIndex = 10;
            this.Label41.Tag = "Change Color";
            this.Label41.Text = "Change Color";
            // 
            // ExpColorList
            // 
            this.ExpColorList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpColorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExpColorList.FormattingEnabled = true;
            this.ExpColorList.Location = new System.Drawing.Point(102, 183);
            this.ExpColorList.MaxDropDownItems = 100;
            this.ExpColorList.Name = "ExpColorList";
            this.ExpColorList.Size = new System.Drawing.Size(189, 21);
            this.ExpColorList.Sorted = true;
            this.ExpColorList.TabIndex = 9;
            this.ExpColorList.SelectedIndexChanged += new System.EventHandler(this.ExpColorList_SelectedIndexChanged);
            // 
            // Label42
            // 
            this.Label42.AutoSize = true;
            this.Label42.Location = new System.Drawing.Point(14, 148);
            this.Label42.Name = "Label42";
            this.Label42.Size = new System.Drawing.Size(66, 13);
            this.Label42.TabIndex = 8;
            this.Label42.Tag = "Change Skin";
            this.Label42.Text = "Change Skin";
            // 
            // ExpSkinList
            // 
            this.ExpSkinList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExpSkinList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExpSkinList.FormattingEnabled = true;
            this.ExpSkinList.Location = new System.Drawing.Point(102, 145);
            this.ExpSkinList.MaxDropDownItems = 100;
            this.ExpSkinList.Name = "ExpSkinList";
            this.ExpSkinList.Size = new System.Drawing.Size(189, 21);
            this.ExpSkinList.Sorted = true;
            this.ExpSkinList.TabIndex = 5;
            this.ExpSkinList.SelectedIndexChanged += new System.EventHandler(this.ExpSkinList_SelectedIndexChanged);
            // 
            // SkinGroup
            // 
            this.SkinGroup.Controls.Add(this.SkinAuthor);
            this.SkinGroup.Controls.Add(this.MoreThemes);
            this.SkinGroup.Controls.Add(this.RemoveSkin);
            this.SkinGroup.Controls.Add(this.AddSkin);
            this.SkinGroup.Controls.Add(this.SkinPreview);
            this.SkinGroup.Controls.Add(this.SkinName);
            this.SkinGroup.Controls.Add(this.SkinWebsite);
            this.SkinGroup.Controls.Add(this.Label32);
            this.SkinGroup.Controls.Add(this.SkinColorList);
            this.SkinGroup.Controls.Add(this.Label33);
            this.SkinGroup.Controls.Add(this.SkinList);
            this.SkinGroup.Location = new System.Drawing.Point(11, 16);
            this.SkinGroup.Name = "SkinGroup";
            this.SkinGroup.Size = new System.Drawing.Size(308, 265);
            this.SkinGroup.TabIndex = 9;
            this.SkinGroup.TabStop = false;
            this.SkinGroup.Tag = "";
            // 
            // SkinAuthor
            // 
            this.SkinAuthor.AutoEllipsis = true;
            this.SkinAuthor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkinAuthor.Location = new System.Drawing.Point(17, 65);
            this.SkinAuthor.Name = "SkinAuthor";
            this.SkinAuthor.Size = new System.Drawing.Size(157, 21);
            this.SkinAuthor.TabIndex = 14;
            this.SkinAuthor.Text = "(value)";
            // 
            // MoreThemes
            // 
            this.MoreThemes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoreThemes.AutoSize = true;
            this.MoreThemes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoreThemes.LinkArea = new System.Windows.Forms.LinkArea(0, 100);
            this.MoreThemes.Location = new System.Drawing.Point(180, 108);
            this.MoreThemes.Name = "MoreThemes";
            this.MoreThemes.Size = new System.Drawing.Size(76, 18);
            this.MoreThemes.TabIndex = 40;
            this.MoreThemes.TabStop = true;
            this.MoreThemes.Tag = "More Skins ....";
            this.MoreThemes.Text = "More Skins ....";
            this.MoreThemes.UseCompatibleTextRendering = true;
            this.MoreThemes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MoreThemes_LinkClicked);
            // 
            // SkinPreview
            // 
            this.SkinPreview.Location = new System.Drawing.Point(180, 28);
            this.SkinPreview.Name = "SkinPreview";
            this.SkinPreview.Size = new System.Drawing.Size(111, 77);
            this.SkinPreview.TabIndex = 34;
            this.SkinPreview.TabStop = false;
            // 
            // SkinName
            // 
            this.SkinName.AutoEllipsis = true;
            this.SkinName.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkinName.Location = new System.Drawing.Point(12, 33);
            this.SkinName.Name = "SkinName";
            this.SkinName.Size = new System.Drawing.Size(162, 30);
            this.SkinName.TabIndex = 33;
            this.SkinName.Tag = "";
            this.SkinName.Text = "(Value)";
            // 
            // SkinWebsite
            // 
            this.SkinWebsite.AutoEllipsis = true;
            this.SkinWebsite.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkinWebsite.Location = new System.Drawing.Point(20, 88);
            this.SkinWebsite.Name = "SkinWebsite";
            this.SkinWebsite.Size = new System.Drawing.Size(154, 45);
            this.SkinWebsite.TabIndex = 32;
            this.SkinWebsite.TabStop = true;
            this.SkinWebsite.Tag = "";
            this.SkinWebsite.Text = "No Website";
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Location = new System.Drawing.Point(14, 186);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(72, 13);
            this.Label32.TabIndex = 10;
            this.Label32.Tag = "Change Color";
            this.Label32.Text = "Change Color";
            // 
            // SkinColorList
            // 
            this.SkinColorList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SkinColorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SkinColorList.FormattingEnabled = true;
            this.SkinColorList.Location = new System.Drawing.Point(102, 183);
            this.SkinColorList.MaxDropDownItems = 100;
            this.SkinColorList.Name = "SkinColorList";
            this.SkinColorList.Size = new System.Drawing.Size(189, 21);
            this.SkinColorList.Sorted = true;
            this.SkinColorList.TabIndex = 9;
            this.SkinColorList.SelectedIndexChanged += new System.EventHandler(this.SkinColorList_SelectedIndexChanged);
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Location = new System.Drawing.Point(14, 148);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(66, 13);
            this.Label33.TabIndex = 8;
            this.Label33.Tag = "Change Skin";
            this.Label33.Text = "Change Skin";
            // 
            // SkinList
            // 
            this.SkinList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SkinList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SkinList.FormattingEnabled = true;
            this.SkinList.Location = new System.Drawing.Point(102, 145);
            this.SkinList.MaxDropDownItems = 100;
            this.SkinList.Name = "SkinList";
            this.SkinList.Size = new System.Drawing.Size(189, 21);
            this.SkinList.Sorted = true;
            this.SkinList.TabIndex = 5;
            this.SkinList.SelectedIndexChanged += new System.EventHandler(this.SkinList_SelectedIndexChanged);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.SkinsPage);
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage4);
            this.TabControl1.Controls.Add(this.TabPage5);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TabControl1.Location = new System.Drawing.Point(10, 10);
            this.TabControl1.Multiline = true;
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(663, 336);
            this.TabControl1.TabIndex = 11;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.GroupBox18);
            this.TabPage2.Controls.Add(this.GroupBox14);
            this.TabPage2.Controls.Add(this.GroupBox17);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(655, 310);
            this.TabPage2.TabIndex = 10;
            this.TabPage2.Tag = "General";
            this.TabPage2.Text = "General";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // GroupBox18
            // 
            this.GroupBox18.Controls.Add(this.ShowTrayIcon);
            this.GroupBox18.Controls.Add(this.RunStartUp);
            this.GroupBox18.Controls.Add(this.Label96);
            this.GroupBox18.Location = new System.Drawing.Point(15, 15);
            this.GroupBox18.Name = "GroupBox18";
            this.GroupBox18.Size = new System.Drawing.Size(284, 128);
            this.GroupBox18.TabIndex = 52;
            this.GroupBox18.TabStop = false;
            this.GroupBox18.Tag = "";
            // 
            // ShowTrayIcon
            // 
            this.ShowTrayIcon.AutoSize = true;
            this.ShowTrayIcon.Location = new System.Drawing.Point(21, 30);
            this.ShowTrayIcon.Name = "ShowTrayIcon";
            this.ShowTrayIcon.Size = new System.Drawing.Size(101, 17);
            this.ShowTrayIcon.TabIndex = 54;
            this.ShowTrayIcon.Tag = "Show Tray Icon";
            this.ShowTrayIcon.Text = "Show Tray Icon";
            this.ShowTrayIcon.UseVisualStyleBackColor = true;
            this.ShowTrayIcon.CheckedChanged += new System.EventHandler(this.ShowTrayIcon_CheckedChanged);
            // 
            // RunStartUp
            // 
            this.RunStartUp.AutoSize = true;
            this.RunStartUp.Location = new System.Drawing.Point(20, 53);
            this.RunStartUp.Name = "RunStartUp";
            this.RunStartUp.Size = new System.Drawing.Size(98, 17);
            this.RunStartUp.TabIndex = 53;
            this.RunStartUp.Tag = "Run At Startup";
            this.RunStartUp.Text = "Run At Startup";
            this.RunStartUp.UseVisualStyleBackColor = true;
            // 
            // Label96
            // 
            this.Label96.AutoSize = true;
            this.Label96.BackColor = System.Drawing.Color.White;
            this.Label96.ForeColor = System.Drawing.Color.Blue;
            this.Label96.Location = new System.Drawing.Point(7, -1);
            this.Label96.Name = "Label96";
            this.Label96.Size = new System.Drawing.Size(44, 13);
            this.Label96.TabIndex = 51;
            this.Label96.Tag = "Options";
            this.Label96.Text = "Options";
            // 
            // GroupBox14
            // 
            this.GroupBox14.Controls.Add(this.label1);
            this.GroupBox14.Controls.Add(this.DefaultWebsite);
            this.GroupBox14.Controls.Add(this.Label81);
            this.GroupBox14.Controls.Add(this.PictureBox5);
            this.GroupBox14.Controls.Add(this.ProductWebsite);
            this.GroupBox14.Controls.Add(this.Developer);
            this.GroupBox14.Controls.Add(this.ProgramVersion);
            this.GroupBox14.Controls.Add(this.ProgramName);
            this.GroupBox14.Controls.Add(this.Label86);
            this.GroupBox14.Controls.Add(this.Label87);
            this.GroupBox14.Controls.Add(this.Label89);
            this.GroupBox14.Controls.Add(this.Label90);
            this.GroupBox14.Location = new System.Drawing.Point(15, 148);
            this.GroupBox14.Name = "GroupBox14";
            this.GroupBox14.Size = new System.Drawing.Size(624, 146);
            this.GroupBox14.TabIndex = 50;
            this.GroupBox14.TabStop = false;
            this.GroupBox14.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 44;
            this.label1.Tag = "Website";
            this.label1.Text = "Website";
            // 
            // Label81
            // 
            this.Label81.AutoSize = true;
            this.Label81.BackColor = System.Drawing.Color.White;
            this.Label81.ForeColor = System.Drawing.Color.Blue;
            this.Label81.Location = new System.Drawing.Point(6, -1);
            this.Label81.Name = "Label81";
            this.Label81.Size = new System.Drawing.Size(36, 13);
            this.Label81.TabIndex = 33;
            this.Label81.Text = "About";
            // 
            // PictureBox5
            // 
            this.PictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox5.Image = global::BorderSkin.Properties.Resources.BorderSkinImage;
            this.PictureBox5.Location = new System.Drawing.Point(301, 21);
            this.PictureBox5.Name = "PictureBox5";
            this.PictureBox5.Size = new System.Drawing.Size(313, 100);
            this.PictureBox5.TabIndex = 43;
            this.PictureBox5.TabStop = false;
            // 
            // ProductWebsite
            // 
            this.ProductWebsite.AutoSize = true;
            this.ProductWebsite.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductWebsite.Location = new System.Drawing.Point(123, 92);
            this.ProductWebsite.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.ProductWebsite.Name = "ProductWebsite";
            this.ProductWebsite.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ProductWebsite.Size = new System.Drawing.Size(41, 16);
            this.ProductWebsite.TabIndex = 42;
            this.ProductWebsite.TabStop = true;
            this.ProductWebsite.Text = "(value)";
            this.ProductWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // Developer
            // 
            this.Developer.AutoSize = true;
            this.Developer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Developer.Location = new System.Drawing.Point(123, 74);
            this.Developer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.Developer.Name = "Developer";
            this.Developer.Size = new System.Drawing.Size(41, 13);
            this.Developer.TabIndex = 41;
            this.Developer.Tag = "";
            this.Developer.Text = "(value)";
            // 
            // ProgramVersion
            // 
            this.ProgramVersion.AutoSize = true;
            this.ProgramVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramVersion.Location = new System.Drawing.Point(123, 51);
            this.ProgramVersion.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.ProgramVersion.Name = "ProgramVersion";
            this.ProgramVersion.Size = new System.Drawing.Size(41, 13);
            this.ProgramVersion.TabIndex = 39;
            this.ProgramVersion.Tag = "";
            this.ProgramVersion.Text = "(value)";
            // 
            // ProgramName
            // 
            this.ProgramName.AutoSize = true;
            this.ProgramName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramName.Location = new System.Drawing.Point(123, 26);
            this.ProgramName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.ProgramName.Name = "ProgramName";
            this.ProgramName.Size = new System.Drawing.Size(41, 13);
            this.ProgramName.TabIndex = 38;
            this.ProgramName.Tag = "";
            this.ProgramName.Text = "(value)";
            // 
            // Label86
            // 
            this.Label86.AutoSize = true;
            this.Label86.Location = new System.Drawing.Point(21, 95);
            this.Label86.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.Label86.Name = "Label86";
            this.Label86.Size = new System.Drawing.Size(46, 13);
            this.Label86.TabIndex = 37;
            this.Label86.Tag = "Website";
            this.Label86.Text = "Website";
            // 
            // Label87
            // 
            this.Label87.AutoSize = true;
            this.Label87.Location = new System.Drawing.Point(21, 74);
            this.Label87.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.Label87.Name = "Label87";
            this.Label87.Size = new System.Drawing.Size(56, 13);
            this.Label87.TabIndex = 35;
            this.Label87.Tag = "Developer";
            this.Label87.Text = "Developer";
            // 
            // Label89
            // 
            this.Label89.AutoSize = true;
            this.Label89.Location = new System.Drawing.Point(21, 51);
            this.Label89.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.Label89.Name = "Label89";
            this.Label89.Size = new System.Drawing.Size(82, 13);
            this.Label89.TabIndex = 34;
            this.Label89.Tag = "Product Version";
            this.Label89.Text = "Product Version";
            // 
            // Label90
            // 
            this.Label90.AutoSize = true;
            this.Label90.Location = new System.Drawing.Point(21, 26);
            this.Label90.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.Label90.Name = "Label90";
            this.Label90.Size = new System.Drawing.Size(74, 13);
            this.Label90.TabIndex = 32;
            this.Label90.Tag = "Product Name";
            this.Label90.Text = "Product Name";
            // 
            // GroupBox17
            // 
            this.GroupBox17.Controls.Add(this.Label95);
            this.GroupBox17.Controls.Add(this.LangWebsite);
            this.GroupBox17.Controls.Add(this.MoreLang);
            this.GroupBox17.Controls.Add(this.Label91);
            this.GroupBox17.Controls.Add(this.LangAuthor);
            this.GroupBox17.Controls.Add(this.Label93);
            this.GroupBox17.Controls.Add(this.LanguageList);
            this.GroupBox17.Controls.Add(this.Label94);
            this.GroupBox17.Location = new System.Drawing.Point(313, 15);
            this.GroupBox17.Name = "GroupBox17";
            this.GroupBox17.Size = new System.Drawing.Size(329, 128);
            this.GroupBox17.TabIndex = 49;
            this.GroupBox17.TabStop = false;
            this.GroupBox17.Tag = "";
            // 
            // Label95
            // 
            this.Label95.AutoSize = true;
            this.Label95.BackColor = System.Drawing.Color.White;
            this.Label95.ForeColor = System.Drawing.Color.Blue;
            this.Label95.Location = new System.Drawing.Point(7, 0);
            this.Label95.Name = "Label95";
            this.Label95.Size = new System.Drawing.Size(54, 13);
            this.Label95.TabIndex = 51;
            this.Label95.Tag = "Language";
            this.Label95.Text = "Language";
            // 
            // LangWebsite
            // 
            this.LangWebsite.AutoSize = true;
            this.LangWebsite.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LangWebsite.Location = new System.Drawing.Point(77, 78);
            this.LangWebsite.Name = "LangWebsite";
            this.LangWebsite.Size = new System.Drawing.Size(41, 13);
            this.LangWebsite.TabIndex = 43;
            this.LangWebsite.TabStop = true;
            this.LangWebsite.Tag = "";
            this.LangWebsite.Text = "(value)";
            // 
            // MoreLang
            // 
            this.MoreLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoreLang.AutoSize = true;
            this.MoreLang.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoreLang.LinkArea = new System.Windows.Forms.LinkArea(0, 24);
            this.MoreLang.Location = new System.Drawing.Point(199, 107);
            this.MoreLang.Name = "MoreLang";
            this.MoreLang.Size = new System.Drawing.Size(124, 13);
            this.MoreLang.TabIndex = 39;
            this.MoreLang.TabStop = true;
            this.MoreLang.Tag = "More Language Files ....";
            this.MoreLang.Text = "More Language Files ....";
            this.MoreLang.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MoreLang_LinkClicked);
            // 
            // Label91
            // 
            this.Label91.AutoSize = true;
            this.Label91.Location = new System.Drawing.Point(24, 78);
            this.Label91.Name = "Label91";
            this.Label91.Size = new System.Drawing.Size(46, 13);
            this.Label91.TabIndex = 42;
            this.Label91.Tag = "Website";
            this.Label91.Text = "Website";
            // 
            // LangAuthor
            // 
            this.LangAuthor.AutoSize = true;
            this.LangAuthor.Location = new System.Drawing.Point(77, 55);
            this.LangAuthor.Name = "LangAuthor";
            this.LangAuthor.Size = new System.Drawing.Size(41, 13);
            this.LangAuthor.TabIndex = 41;
            this.LangAuthor.Text = "(value)";
            // 
            // Label93
            // 
            this.Label93.AutoSize = true;
            this.Label93.Location = new System.Drawing.Point(23, 55);
            this.Label93.Name = "Label93";
            this.Label93.Size = new System.Drawing.Size(40, 13);
            this.Label93.TabIndex = 40;
            this.Label93.Tag = "Author";
            this.Label93.Text = "Author";
            // 
            // LanguageList
            // 
            this.LanguageList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LanguageList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageList.FormattingEnabled = true;
            this.LanguageList.Location = new System.Drawing.Point(80, 25);
            this.LanguageList.Name = "LanguageList";
            this.LanguageList.Size = new System.Drawing.Size(194, 21);
            this.LanguageList.TabIndex = 37;
            this.LanguageList.SelectedIndexChanged += new System.EventHandler(this.LanguageList_SelectedIndexChanged);
            // 
            // Label94
            // 
            this.Label94.AutoSize = true;
            this.Label94.Location = new System.Drawing.Point(24, 28);
            this.Label94.Name = "Label94";
            this.Label94.Size = new System.Drawing.Size(34, 13);
            this.Label94.TabIndex = 38;
            this.Label94.Tag = "Name";
            this.Label94.Text = "Name";
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.Reflection);
            this.TabPage1.Controls.Add(this.ReflectionGroup);
            this.TabPage1.Controls.Add(this.GroupBox7);
            this.TabPage1.Controls.Add(this.GroupBox2);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(655, 310);
            this.TabPage1.TabIndex = 9;
            this.TabPage1.Tag = "Effects";
            this.TabPage1.Text = "Effects";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // Reflection
            // 
            this.Reflection.AutoSize = true;
            this.Reflection.BackColor = System.Drawing.Color.White;
            this.Reflection.ForeColor = System.Drawing.Color.Blue;
            this.Reflection.Location = new System.Drawing.Point(340, 15);
            this.Reflection.Name = "Reflection";
            this.Reflection.Size = new System.Drawing.Size(74, 17);
            this.Reflection.TabIndex = 38;
            this.Reflection.Tag = "Reflection";
            this.Reflection.Text = "Reflection";
            this.Reflection.UseVisualStyleBackColor = false;
            this.Reflection.CheckedChanged += new System.EventHandler(this.Reflection_CheckedChanged);
            // 
            // ReflectionGroup
            // 
            this.ReflectionGroup.Controls.Add(this.Label2);
            this.ReflectionGroup.Controls.Add(this.Label5);
            this.ReflectionGroup.Controls.Add(this.ReflectionValue);
            this.ReflectionGroup.Controls.Add(this.Label8);
            this.ReflectionGroup.Controls.Add(this.ReflectionSpeed);
            this.ReflectionGroup.Location = new System.Drawing.Point(333, 15);
            this.ReflectionGroup.Name = "ReflectionGroup";
            this.ReflectionGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.ReflectionGroup.Size = new System.Drawing.Size(308, 134);
            this.ReflectionGroup.TabIndex = 48;
            this.ReflectionGroup.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(252, 33);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(29, 13);
            this.Label2.TabIndex = 53;
            this.Label2.Tag = "Slow";
            this.Label2.Text = "Slow";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(15, 30);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(51, 13);
            this.Label5.TabIndex = 52;
            this.Label5.Tag = "Constant";
            this.Label5.Text = "Constant";
            // 
            // ReflectionValue
            // 
            this.ReflectionValue.AutoSize = true;
            this.ReflectionValue.Location = new System.Drawing.Point(171, 92);
            this.ReflectionValue.Name = "ReflectionValue";
            this.ReflectionValue.Size = new System.Drawing.Size(41, 13);
            this.ReflectionValue.TabIndex = 15;
            this.ReflectionValue.Text = "(value)";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(77, 92);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(88, 13);
            this.Label8.TabIndex = 11;
            this.Label8.Tag = "Reflection Speed";
            this.Label8.Text = "Reflection Speed";
            // 
            // ReflectionSpeed
            // 
            this.ReflectionSpeed.AutoSize = false;
            this.ReflectionSpeed.BackColor = System.Drawing.Color.White;
            this.ReflectionSpeed.Location = new System.Drawing.Point(23, 47);
            this.ReflectionSpeed.Name = "ReflectionSpeed";
            this.ReflectionSpeed.Size = new System.Drawing.Size(264, 42);
            this.ReflectionSpeed.TabIndex = 4;
            this.ReflectionSpeed.Scroll += new System.EventHandler(this.ReflectionSpeed_Scroll);
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.Label67);
            this.GroupBox7.Controls.Add(this.HideAddressbar);
            this.GroupBox7.Controls.Add(this.HideMenuBar);
            this.GroupBox7.Location = new System.Drawing.Point(14, 214);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(308, 80);
            this.GroupBox7.TabIndex = 46;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Tag = "";
            // 
            // Label67
            // 
            this.Label67.AutoSize = true;
            this.Label67.BackColor = System.Drawing.Color.White;
            this.Label67.ForeColor = System.Drawing.Color.Blue;
            this.Label67.Location = new System.Drawing.Point(7, 0);
            this.Label67.Name = "Label67";
            this.Label67.Size = new System.Drawing.Size(84, 13);
            this.Label67.TabIndex = 48;
            this.Label67.Tag = "Explorer Effects";
            this.Label67.Text = "Explorer Effects";
            // 
            // HideAddressbar
            // 
            this.HideAddressbar.AutoSize = true;
            this.HideAddressbar.Location = new System.Drawing.Point(25, 47);
            this.HideAddressbar.Name = "HideAddressbar";
            this.HideAddressbar.Size = new System.Drawing.Size(216, 17);
            this.HideAddressbar.TabIndex = 107;
            this.HideAddressbar.Tag = "Hide Explorer AddressBar (Vista/Seven)";
            this.HideAddressbar.Text = "Hide Explorer AddressBar (Vista/Seven)";
            this.HideAddressbar.UseVisualStyleBackColor = true;
            // 
            // HideMenuBar
            // 
            this.HideMenuBar.AutoSize = true;
            this.HideMenuBar.Location = new System.Drawing.Point(25, 23);
            this.HideMenuBar.Name = "HideMenuBar";
            this.HideMenuBar.Size = new System.Drawing.Size(158, 17);
            this.HideMenuBar.TabIndex = 106;
            this.HideMenuBar.Tag = "Hide Explorer MenuBar (XP)";
            this.HideMenuBar.Text = "Hide Explorer MenuBar (XP)";
            this.HideMenuBar.UseVisualStyleBackColor = true;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.BlurEnabled);
            this.GroupBox2.Controls.Add(this.Transparency);
            this.GroupBox2.Controls.Add(this.BlurGroup);
            this.GroupBox2.Location = new System.Drawing.Point(14, 16);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(308, 192);
            this.GroupBox2.TabIndex = 43;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Tag = "";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.White;
            this.Label9.ForeColor = System.Drawing.Color.Blue;
            this.Label9.Location = new System.Drawing.Point(10, -1);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(115, 13);
            this.Label9.TabIndex = 48;
            this.Label9.Tag = "Transparency and Blur";
            this.Label9.Text = "Transparency and Blur";
            // 
            // BlurEnabled
            // 
            this.BlurEnabled.AutoSize = true;
            this.BlurEnabled.BackColor = System.Drawing.Color.White;
            this.BlurEnabled.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BlurEnabled.Location = new System.Drawing.Point(24, 42);
            this.BlurEnabled.Name = "BlurEnabled";
            this.BlurEnabled.Size = new System.Drawing.Size(44, 17);
            this.BlurEnabled.TabIndex = 40;
            this.BlurEnabled.Tag = "Blur";
            this.BlurEnabled.Text = "Blur";
            this.BlurEnabled.UseVisualStyleBackColor = false;
            // 
            // Transparency
            // 
            this.Transparency.AutoSize = true;
            this.Transparency.BackColor = System.Drawing.Color.White;
            this.Transparency.Checked = true;
            this.Transparency.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Transparency.Enabled = false;
            this.Transparency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Transparency.Location = new System.Drawing.Point(24, 21);
            this.Transparency.Name = "Transparency";
            this.Transparency.Size = new System.Drawing.Size(92, 17);
            this.Transparency.TabIndex = 39;
            this.Transparency.Tag = "Transparency";
            this.Transparency.Text = "Transparency";
            this.Transparency.UseVisualStyleBackColor = false;
            this.Transparency.CheckedChanged += new System.EventHandler(this.Transparency_CheckedChanged);
            // 
            // BlurGroup
            // 
            this.BlurGroup.Controls.Add(this.DisableFullBlurOnMove);
            this.BlurGroup.Controls.Add(this.DisableBlurOnMove);
            this.BlurGroup.Controls.Add(this.BlurValue);
            this.BlurGroup.Controls.Add(this.FullBlur);
            this.BlurGroup.Controls.Add(this.Label75);
            this.BlurGroup.Controls.Add(this.BlurStrength);
            this.BlurGroup.Location = new System.Drawing.Point(13, 44);
            this.BlurGroup.Name = "BlurGroup";
            this.BlurGroup.Padding = new System.Windows.Forms.Padding(3, 4, 3, 3);
            this.BlurGroup.Size = new System.Drawing.Size(283, 135);
            this.BlurGroup.TabIndex = 34;
            this.BlurGroup.TabStop = false;
            // 
            // DisableFullBlurOnMove
            // 
            this.DisableFullBlurOnMove.AutoSize = true;
            this.DisableFullBlurOnMove.Location = new System.Drawing.Point(24, 110);
            this.DisableFullBlurOnMove.Name = "DisableFullBlurOnMove";
            this.DisableFullBlurOnMove.Size = new System.Drawing.Size(166, 17);
            this.DisableFullBlurOnMove.TabIndex = 14;
            this.DisableFullBlurOnMove.Tag = "Disable FullBlur On Move/Size";
            this.DisableFullBlurOnMove.Text = "Disable FullBlur On Move/Size";
            this.DisableFullBlurOnMove.UseVisualStyleBackColor = true;
            // 
            // DisableBlurOnMove
            // 
            this.DisableBlurOnMove.AutoSize = true;
            this.DisableBlurOnMove.Location = new System.Drawing.Point(24, 90);
            this.DisableBlurOnMove.Name = "DisableBlurOnMove";
            this.DisableBlurOnMove.Size = new System.Drawing.Size(150, 17);
            this.DisableBlurOnMove.TabIndex = 13;
            this.DisableBlurOnMove.Tag = "Disable Blur On Move/Size";
            this.DisableBlurOnMove.Text = "Disable Blur On Move/Size";
            this.DisableBlurOnMove.UseVisualStyleBackColor = true;
            // 
            // BlurValue
            // 
            this.BlurValue.AutoSize = true;
            this.BlurValue.Location = new System.Drawing.Point(161, 54);
            this.BlurValue.Name = "BlurValue";
            this.BlurValue.Size = new System.Drawing.Size(41, 13);
            this.BlurValue.TabIndex = 12;
            this.BlurValue.Text = "(value)";
            // 
            // FullBlur
            // 
            this.FullBlur.AutoSize = true;
            this.FullBlur.Location = new System.Drawing.Point(24, 70);
            this.FullBlur.Name = "FullBlur";
            this.FullBlur.Size = new System.Drawing.Size(60, 17);
            this.FullBlur.TabIndex = 3;
            this.FullBlur.Tag = "FullBlur";
            this.FullBlur.Text = "FullBlur";
            this.FullBlur.UseVisualStyleBackColor = true;
            // 
            // Label75
            // 
            this.Label75.AutoSize = true;
            this.Label75.Location = new System.Drawing.Point(85, 54);
            this.Label75.Name = "Label75";
            this.Label75.Size = new System.Drawing.Size(70, 13);
            this.Label75.TabIndex = 11;
            this.Label75.Tag = "Blur Strength";
            this.Label75.Text = "Blur Strength";
            // 
            // BlurStrength
            // 
            this.BlurStrength.AutoSize = false;
            this.BlurStrength.BackColor = System.Drawing.Color.White;
            this.BlurStrength.Dock = System.Windows.Forms.DockStyle.Top;
            this.BlurStrength.Location = new System.Drawing.Point(3, 17);
            this.BlurStrength.Minimum = 2;
            this.BlurStrength.Name = "BlurStrength";
            this.BlurStrength.Size = new System.Drawing.Size(277, 39);
            this.BlurStrength.TabIndex = 4;
            this.BlurStrength.Value = 2;
            this.BlurStrength.Scroll += new System.EventHandler(this.BlurStrength_Scroll);
            // 
            // TabPage4
            // 
            this.TabPage4.Controls.Add(this.InclusionManager);
            this.TabPage4.Location = new System.Drawing.Point(4, 22);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage4.Size = new System.Drawing.Size(655, 310);
            this.TabPage4.TabIndex = 11;
            this.TabPage4.Tag = "Included Windows";
            this.TabPage4.Text = "Included Windows";
            this.TabPage4.UseVisualStyleBackColor = true;
            // 
            // TabPage5
            // 
            this.TabPage5.Controls.Add(this.ExclusionManager);
            this.TabPage5.Location = new System.Drawing.Point(4, 22);
            this.TabPage5.Name = "TabPage5";
            this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage5.Size = new System.Drawing.Size(655, 310);
            this.TabPage5.TabIndex = 12;
            this.TabPage5.Tag = "Excluded Windows";
            this.TabPage5.Text = "Excluded Windows";
            this.TabPage5.UseVisualStyleBackColor = true;
            // 
            // SourceCodeWebsite
            // 
            this.SourceCodeWebsite.AutoSize = true;
            this.SourceCodeWebsite.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceCodeWebsite.Location = new System.Drawing.Point(26, 349);
            this.SourceCodeWebsite.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.SourceCodeWebsite.Name = "SourceCodeWebsite";
            this.SourceCodeWebsite.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.SourceCodeWebsite.Size = new System.Drawing.Size(41, 16);
            this.SourceCodeWebsite.TabIndex = 42;
            this.SourceCodeWebsite.TabStop = true;
            this.SourceCodeWebsite.Text = "(value)";
            this.SourceCodeWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // GithubWebsite
            // 
            this.GithubWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GithubWebsite.AutoSize = true;
            this.GithubWebsite.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GithubWebsite.Location = new System.Drawing.Point(26, 373);
            this.GithubWebsite.Name = "GithubWebsite";
            this.GithubWebsite.Size = new System.Drawing.Size(41, 13);
            this.GithubWebsite.TabIndex = 104;
            this.GithubWebsite.TabStop = true;
            this.GithubWebsite.Text = "(value)";
            this.GithubWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
            // 
            // RemoveExpSkin
            // 
            this.RemoveExpSkin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveExpSkin.Enabled = false;
            this.RemoveExpSkin.Image = global::BorderSkin.Properties.Resources.RemoveImage;
            this.RemoveExpSkin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveExpSkin.Location = new System.Drawing.Point(207, 229);
            this.RemoveExpSkin.Name = "RemoveExpSkin";
            this.RemoveExpSkin.Size = new System.Drawing.Size(89, 16);
            this.RemoveExpSkin.TabIndex = 35;
            this.RemoveExpSkin.Tag = "Remove Skin";
            this.RemoveExpSkin.Text = "Remove Skin";
            this.RemoveExpSkin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddExpSkin
            // 
            this.AddExpSkin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddExpSkin.Enabled = false;
            this.AddExpSkin.Image = global::BorderSkin.Properties.Resources.AddImage;
            this.AddExpSkin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddExpSkin.Location = new System.Drawing.Point(133, 229);
            this.AddExpSkin.Name = "AddExpSkin";
            this.AddExpSkin.Size = new System.Drawing.Size(69, 16);
            this.AddExpSkin.TabIndex = 35;
            this.AddExpSkin.Tag = "Add Skin";
            this.AddExpSkin.Text = "Add Skin";
            this.AddExpSkin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RemoveSkin
            // 
            this.RemoveSkin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveSkin.Enabled = false;
            this.RemoveSkin.Image = global::BorderSkin.Properties.Resources.RemoveImage;
            this.RemoveSkin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveSkin.Location = new System.Drawing.Point(207, 229);
            this.RemoveSkin.Name = "RemoveSkin";
            this.RemoveSkin.Size = new System.Drawing.Size(89, 16);
            this.RemoveSkin.TabIndex = 35;
            this.RemoveSkin.Tag = "Remove Skin";
            this.RemoveSkin.Text = "Remove Skin";
            this.RemoveSkin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddSkin
            // 
            this.AddSkin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddSkin.Enabled = false;
            this.AddSkin.Image = global::BorderSkin.Properties.Resources.AddImage;
            this.AddSkin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddSkin.Location = new System.Drawing.Point(130, 229);
            this.AddSkin.Name = "AddSkin";
            this.AddSkin.Size = new System.Drawing.Size(69, 16);
            this.AddSkin.TabIndex = 35;
            this.AddSkin.Tag = "Add Skin";
            this.AddSkin.Text = "Add Skin";
            this.AddSkin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddSkin.Click += new System.EventHandler(this.AddSkin_Click);
            // 
            // InclusionManager
            // 
            this.InclusionManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InclusionManager.IsInclusionList = false;
            this.InclusionManager.Location = new System.Drawing.Point(3, 3);
            this.InclusionManager.Name = "InclusionManager";
            this.InclusionManager.Size = new System.Drawing.Size(649, 304);
            this.InclusionManager.TabIndex = 0;
            // 
            // ExclusionManager
            // 
            this.ExclusionManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExclusionManager.IsInclusionList = false;
            this.ExclusionManager.Location = new System.Drawing.Point(3, 3);
            this.ExclusionManager.Name = "ExclusionManager";
            this.ExclusionManager.Size = new System.Drawing.Size(649, 304);
            this.ExclusionManager.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Image = global::BorderSkin.Properties.Resources.ExitAppImage;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(557, 362);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(109, 24);
            this.ExitButton.TabIndex = 103;
            this.ExitButton.Tag = "Exit Application";
            this.ExitButton.Text = "Exit Application";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // HideButton
            // 
            this.HideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HideButton.Image = global::BorderSkin.Properties.Resources.CloseImage;
            this.HideButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HideButton.Location = new System.Drawing.Point(435, 361);
            this.HideButton.Name = "HideButton";
            this.HideButton.Size = new System.Drawing.Size(116, 25);
            this.HideButton.TabIndex = 102;
            this.HideButton.Tag = "Close Preference";
            this.HideButton.Text = "Close Preference";
            this.HideButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.HideButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // SettingsDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(683, 397);
            this.Controls.Add(this.GithubWebsite);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.SourceCodeWebsite);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.HideButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsDialogue";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "(value)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsDialogue_FormClosing);
            this.TrayMenu.ResumeLayout(false);
            this.SkinsPage.ResumeLayout(false);
            this.SkinsPage.PerformLayout();
            this.ExpSkinGroup.ResumeLayout(false);
            this.ExpSkinGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExpSkinPreview)).EndInit();
            this.SkinGroup.ResumeLayout(false);
            this.SkinGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkinPreview)).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.GroupBox18.ResumeLayout(false);
            this.GroupBox18.PerformLayout();
            this.GroupBox14.ResumeLayout(false);
            this.GroupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox5)).EndInit();
            this.GroupBox17.ResumeLayout(false);
            this.GroupBox17.PerformLayout();
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.ReflectionGroup.ResumeLayout(false);
            this.ReflectionGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReflectionSpeed)).EndInit();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.BlurGroup.ResumeLayout(false);
            this.BlurGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlurStrength)).EndInit();
            this.TabPage4.ResumeLayout(false);
            this.TabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.NotifyIcon TrayIcon;
        internal System.Windows.Forms.ContextMenuStrip TrayMenu;
        internal System.Windows.Forms.ToolStripSeparator ToolStripMenuItem1;
        internal System.Windows.Forms.ToolStripMenuItem ExitItem;
        internal System.Windows.Forms.LinkLabel DefaultWebsite;
        internal System.Windows.Forms.ToolStripMenuItem PreferenceItem;
        internal IconButton ExitButton;
        internal IconButton HideButton;
        internal System.Windows.Forms.TabPage SkinsPage;
        internal System.Windows.Forms.CheckBox ExplorerSkinning;
        internal System.Windows.Forms.CheckBox BorderSkinning;
        internal System.Windows.Forms.GroupBox ExpSkinGroup;
        internal IconButton RemoveExpSkin;
        internal IconButton AddExpSkin;
        internal System.Windows.Forms.PictureBox ExpSkinPreview;
        internal System.Windows.Forms.Label ExpSkinName;
        internal System.Windows.Forms.LinkLabel ExpSkinWebsite;
        internal System.Windows.Forms.Label ExpSkinAuthor;
        internal System.Windows.Forms.Label Label41;
        internal System.Windows.Forms.ComboBox ExpColorList;
        internal System.Windows.Forms.Label Label42;
        internal System.Windows.Forms.ComboBox ExpSkinList;
        internal System.Windows.Forms.GroupBox SkinGroup;
        internal IconButton RemoveSkin;
        internal IconButton AddSkin;
        internal System.Windows.Forms.PictureBox SkinPreview;
        internal System.Windows.Forms.Label SkinName;
        internal System.Windows.Forms.LinkLabel SkinWebsite;
        internal System.Windows.Forms.Label SkinAuthor;
        internal System.Windows.Forms.Label Label32;
        internal System.Windows.Forms.ComboBox SkinColorList;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.ComboBox SkinList;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.GroupBox BlurGroup;
        internal System.Windows.Forms.CheckBox DisableFullBlurOnMove;
        internal System.Windows.Forms.CheckBox DisableBlurOnMove;
        internal System.Windows.Forms.Label BlurValue;
        internal System.Windows.Forms.CheckBox FullBlur;
        internal System.Windows.Forms.Label Label75;
        internal System.Windows.Forms.TrackBar BlurStrength;
        internal System.Windows.Forms.Label Label67;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.CheckBox HideAddressbar;
        internal System.Windows.Forms.CheckBox HideMenuBar;
        internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.GroupBox GroupBox14;
        internal System.Windows.Forms.Label Label81;
        internal System.Windows.Forms.PictureBox PictureBox5;
        internal System.Windows.Forms.LinkLabel ProductWebsite;
        internal System.Windows.Forms.Label Developer;
        internal System.Windows.Forms.Label ProgramVersion;
        internal System.Windows.Forms.Label ProgramName;
        internal System.Windows.Forms.Label Label86;
        internal System.Windows.Forms.Label Label87;
        internal System.Windows.Forms.Label Label89;
        internal System.Windows.Forms.Label Label90;
        internal System.Windows.Forms.GroupBox GroupBox17;
        internal System.Windows.Forms.Label Label95;
        internal System.Windows.Forms.LinkLabel LangWebsite;
        internal System.Windows.Forms.LinkLabel MoreLang;
        internal System.Windows.Forms.Label Label91;
        internal System.Windows.Forms.Label LangAuthor;
        internal System.Windows.Forms.Label Label93;
        internal System.Windows.Forms.ComboBox LanguageList;
        internal System.Windows.Forms.Label Label94;
        internal System.Windows.Forms.GroupBox GroupBox18;
        internal System.Windows.Forms.CheckBox ShowTrayIcon;
        internal System.Windows.Forms.CheckBox RunStartUp;
        internal System.Windows.Forms.Label Label96;
        internal System.Windows.Forms.GroupBox ReflectionGroup;
        internal System.Windows.Forms.CheckBox Reflection;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.TrackBar ReflectionSpeed;
        internal System.Windows.Forms.Label ReflectionValue;
        internal System.Windows.Forms.CheckBox Transparency;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.CheckBox BlurEnabled;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TabPage TabPage4;
        internal ExclusionManagerControl InclusionManager;
        internal System.Windows.Forms.TabPage TabPage5;
        internal ExclusionManagerControl ExclusionManager;
        internal System.Windows.Forms.LinkLabel MoreExpThemes;
        internal System.Windows.Forms.LinkLabel MoreThemes;
        internal System.Windows.Forms.LinkLabel GithubWebsite;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.LinkLabel SourceCodeWebsite;
    }
}
