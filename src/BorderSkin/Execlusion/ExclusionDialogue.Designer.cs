using BorderSkin.Settings;

namespace BorderSkin.Execlusion
{
    partial class ExclusionDialogue : System.Windows.Forms.Form
    {

        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try {
                if (disposing && components != null) {
                    components.Dispose();
                }
            } finally {
                base.Dispose(disposing);
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExclusionDialogue));
            this.WindowsIcons = new System.Windows.Forms.ImageList(this.components);
            this.Panel1 = new System.Windows.Forms.Panel();
            this.pnlButtonBright3d = new System.Windows.Forms.Panel();
            this.pnlButtonDark3d = new System.Windows.Forms.Panel();
            this.RefreshButton = new IconButton();
            this.Cancel = new IconButton();
            this.OkButton = new IconButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ProgramLbl = new System.Windows.Forms.Label();
            this.ProcessLbl = new System.Windows.Forms.Label();
            this.ClassesLbl = new System.Windows.Forms.Label();
            this.ProgramTxt = new System.Windows.Forms.TextBox();
            this.ProcessTxt = new System.Windows.Forms.TextBox();
            this.ClassesTxt = new System.Windows.Forms.TextBox();
            this.SkinGroup = new System.Windows.Forms.GroupBox();
            this.SkinLbl = new System.Windows.Forms.Label();
            this.ColorSchemeTxt = new System.Windows.Forms.ComboBox();
            this.ColorSchemeLbl = new System.Windows.Forms.Label();
            this.SkinTxt = new System.Windows.Forms.ComboBox();
            this.SkinedCheckBox = new System.Windows.Forms.CheckBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.WindowsList = new System.Windows.Forms.ListView();
            this.WindowInfoLbl = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SkinGroup.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowsIcons
            // 
            this.WindowsIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("WindowsIcons.ImageStream")));
            this.WindowsIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.WindowsIcons.Images.SetKeyName(0, "MaximizedTop.png");
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel1.Controls.Add(this.pnlButtonBright3d);
            this.Panel1.Controls.Add(this.pnlButtonDark3d);
            this.Panel1.Controls.Add(this.RefreshButton);
            this.Panel1.Controls.Add(this.Cancel);
            this.Panel1.Controls.Add(this.OkButton);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel1.Location = new System.Drawing.Point(0, 302);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(507, 58);
            this.Panel1.TabIndex = 103;
            // 
            // pnlButtonBright3d
            // 
            this.pnlButtonBright3d.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlButtonBright3d.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonBright3d.Location = new System.Drawing.Point(0, 1);
            this.pnlButtonBright3d.Name = "pnlButtonBright3d";
            this.pnlButtonBright3d.Size = new System.Drawing.Size(507, 1);
            this.pnlButtonBright3d.TabIndex = 17;
            // 
            // pnlButtonDark3d
            // 
            this.pnlButtonDark3d.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlButtonDark3d.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtonDark3d.Location = new System.Drawing.Point(0, 0);
            this.pnlButtonDark3d.Name = "pnlButtonDark3d";
            this.pnlButtonDark3d.Size = new System.Drawing.Size(507, 1);
            this.pnlButtonDark3d.TabIndex = 18;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshButton.Image = global::BorderSkin.Properties.Resources.RefreshImage;
            this.RefreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefreshButton.Location = new System.Drawing.Point(12, 20);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(91, 25);
            this.RefreshButton.TabIndex = 101;
            this.RefreshButton.Tag = "Refresh List";
            this.RefreshButton.Text = "Refresh List";
            this.RefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // Cancel
            // 
            this.Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel.Image = global::BorderSkin.Properties.Resources.CancelImage;
            this.Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Cancel.Location = new System.Drawing.Point(414, 20);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(66, 25);
            this.Cancel.TabIndex = 101;
            this.Cancel.Tag = "Cancel";
            this.Cancel.Text = "Cancel";
            this.Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // OkButton
            // 
            this.OkButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OkButton.Image = global::BorderSkin.Properties.Resources.OKImage;
            this.OkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkButton.Location = new System.Drawing.Point(345, 20);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(48, 25);
            this.OkButton.TabIndex = 101;
            this.OkButton.Tag = "OK";
            this.OkButton.Text = "OK";
            this.OkButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ProgramLbl);
            this.GroupBox1.Controls.Add(this.ProcessLbl);
            this.GroupBox1.Controls.Add(this.ClassesLbl);
            this.GroupBox1.Controls.Add(this.ProgramTxt);
            this.GroupBox1.Controls.Add(this.ProcessTxt);
            this.GroupBox1.Controls.Add(this.ClassesTxt);
            this.GroupBox1.Location = new System.Drawing.Point(240, 13);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(247, 134);
            this.GroupBox1.TabIndex = 104;
            this.GroupBox1.TabStop = false;
            // 
            // ProgramLbl
            // 
            this.ProgramLbl.AutoSize = true;
            this.ProgramLbl.ForeColor = System.Drawing.Color.Navy;
            this.ProgramLbl.Location = new System.Drawing.Point(12, 32);
            this.ProgramLbl.Name = "ProgramLbl";
            this.ProgramLbl.Size = new System.Drawing.Size(77, 13);
            this.ProgramLbl.TabIndex = 94;
            this.ProgramLbl.Tag = "Program Name";
            this.ProgramLbl.Text = "Program Name";
            // 
            // ProcessLbl
            // 
            this.ProcessLbl.AutoSize = true;
            this.ProcessLbl.ForeColor = System.Drawing.Color.Navy;
            this.ProcessLbl.Location = new System.Drawing.Point(12, 62);
            this.ProcessLbl.Name = "ProcessLbl";
            this.ProcessLbl.Size = new System.Drawing.Size(74, 13);
            this.ProcessLbl.TabIndex = 93;
            this.ProcessLbl.Tag = "Process Name";
            this.ProcessLbl.Text = "Process Name";
            // 
            // ClassesLbl
            // 
            this.ClassesLbl.AutoSize = true;
            this.ClassesLbl.ForeColor = System.Drawing.Color.Navy;
            this.ClassesLbl.Location = new System.Drawing.Point(12, 93);
            this.ClassesLbl.Name = "ClassesLbl";
            this.ClassesLbl.Size = new System.Drawing.Size(43, 13);
            this.ClassesLbl.TabIndex = 92;
            this.ClassesLbl.Tag = "Classes";
            this.ClassesLbl.Text = "Classes";
            // 
            // ProgramTxt
            // 
            this.ProgramTxt.Location = new System.Drawing.Point(102, 29);
            this.ProgramTxt.Name = "ProgramTxt";
            this.ProgramTxt.Size = new System.Drawing.Size(133, 20);
            this.ProgramTxt.TabIndex = 97;
            // 
            // ProcessTxt
            // 
            this.ProcessTxt.Location = new System.Drawing.Point(102, 59);
            this.ProcessTxt.Name = "ProcessTxt";
            this.ProcessTxt.Size = new System.Drawing.Size(133, 20);
            this.ProcessTxt.TabIndex = 96;
            // 
            // ClassesTxt
            // 
            this.ClassesTxt.Location = new System.Drawing.Point(102, 90);
            this.ClassesTxt.Name = "ClassesTxt";
            this.ClassesTxt.Size = new System.Drawing.Size(133, 20);
            this.ClassesTxt.TabIndex = 95;
            // 
            // SkinGroup
            // 
            this.SkinGroup.Controls.Add(this.SkinLbl);
            this.SkinGroup.Controls.Add(this.ColorSchemeTxt);
            this.SkinGroup.Controls.Add(this.ColorSchemeLbl);
            this.SkinGroup.Controls.Add(this.SkinTxt);
            this.SkinGroup.Enabled = false;
            this.SkinGroup.Location = new System.Drawing.Point(240, 167);
            this.SkinGroup.Name = "SkinGroup";
            this.SkinGroup.Size = new System.Drawing.Size(247, 115);
            this.SkinGroup.TabIndex = 105;
            this.SkinGroup.TabStop = false;
            // 
            // SkinLbl
            // 
            this.SkinLbl.AutoSize = true;
            this.SkinLbl.ForeColor = System.Drawing.Color.Navy;
            this.SkinLbl.Location = new System.Drawing.Point(20, 36);
            this.SkinLbl.Name = "SkinLbl";
            this.SkinLbl.Size = new System.Drawing.Size(26, 13);
            this.SkinLbl.TabIndex = 95;
            this.SkinLbl.Tag = "Skin";
            this.SkinLbl.Text = "Skin";
            // 
            // ColorSchemeTxt
            // 
            this.ColorSchemeTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorSchemeTxt.FormattingEnabled = true;
            this.ColorSchemeTxt.Location = new System.Drawing.Point(100, 68);
            this.ColorSchemeTxt.Name = "ColorSchemeTxt";
            this.ColorSchemeTxt.Size = new System.Drawing.Size(131, 21);
            this.ColorSchemeTxt.TabIndex = 99;
            // 
            // ColorSchemeLbl
            // 
            this.ColorSchemeLbl.AutoSize = true;
            this.ColorSchemeLbl.ForeColor = System.Drawing.Color.Navy;
            this.ColorSchemeLbl.Location = new System.Drawing.Point(20, 71);
            this.ColorSchemeLbl.Name = "ColorSchemeLbl";
            this.ColorSchemeLbl.Size = new System.Drawing.Size(72, 13);
            this.ColorSchemeLbl.TabIndex = 98;
            this.ColorSchemeLbl.Tag = "Color Scheme";
            this.ColorSchemeLbl.Text = "Color Scheme";
            // 
            // SkinTxt
            // 
            this.SkinTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SkinTxt.FormattingEnabled = true;
            this.SkinTxt.Location = new System.Drawing.Point(100, 31);
            this.SkinTxt.Name = "SkinTxt";
            this.SkinTxt.Size = new System.Drawing.Size(131, 21);
            this.SkinTxt.TabIndex = 97;
            this.SkinTxt.SelectedIndexChanged += new System.EventHandler(this.SkinTxt_SelectedIndexChanged);
            // 
            // SkinedCheckBox
            // 
            this.SkinedCheckBox.AutoSize = true;
            this.SkinedCheckBox.ForeColor = System.Drawing.Color.Blue;
            this.SkinedCheckBox.Location = new System.Drawing.Point(248, 164);
            this.SkinedCheckBox.Name = "SkinedCheckBox";
            this.SkinedCheckBox.Size = new System.Drawing.Size(92, 17);
            this.SkinedCheckBox.TabIndex = 96;
            this.SkinedCheckBox.Tag = "Specify a Skin";
            this.SkinedCheckBox.Text = "Specify a Skin";
            this.SkinedCheckBox.UseVisualStyleBackColor = true;
            this.SkinedCheckBox.CheckedChanged += new System.EventHandler(this.SkinedCheckBox_CheckedChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.WindowsList);
            this.GroupBox3.Location = new System.Drawing.Point(15, 13);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.GroupBox3.Size = new System.Drawing.Size(211, 269);
            this.GroupBox3.TabIndex = 106;
            this.GroupBox3.TabStop = false;
            // 
            // WindowsList
            // 
            this.WindowsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WindowsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WindowsList.FullRowSelect = true;
            this.WindowsList.Location = new System.Drawing.Point(3, 18);
            this.WindowsList.Name = "WindowsList";
            this.WindowsList.Size = new System.Drawing.Size(205, 248);
            this.WindowsList.SmallImageList = this.WindowsIcons;
            this.WindowsList.TabIndex = 103;
            this.WindowsList.UseCompatibleStateImageBehavior = false;
            this.WindowsList.View = System.Windows.Forms.View.List;
            this.WindowsList.SelectedIndexChanged += new System.EventHandler(this.WindowsList_SelectedIndexChanged);
            // 
            // WindowInfoLbl
            // 
            this.WindowInfoLbl.AutoSize = true;
            this.WindowInfoLbl.BackColor = System.Drawing.Color.White;
            this.WindowInfoLbl.ForeColor = System.Drawing.Color.Blue;
            this.WindowInfoLbl.Location = new System.Drawing.Point(247, 12);
            this.WindowInfoLbl.Name = "WindowInfoLbl";
            this.WindowInfoLbl.Size = new System.Drawing.Size(68, 13);
            this.WindowInfoLbl.TabIndex = 107;
            this.WindowInfoLbl.Text = "Window Info";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.ForeColor = System.Drawing.Color.Blue;
            this.Label3.Location = new System.Drawing.Point(21, 13);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(84, 13);
            this.Label3.TabIndex = 108;
            this.Label3.Tag = "Select a window";
            this.Label3.Text = "Select a window";
            // 
            // ExclusionDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(507, 360);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.WindowInfoLbl);
            this.Controls.Add(this.SkinedCheckBox);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.SkinGroup);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExclusionDialogue";
            this.Text = "Border Skin";
            this.Panel1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.SkinGroup.ResumeLayout(false);
            this.SkinGroup.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.ImageList WindowsIcons;
        internal IconButton RefreshButton;
        internal IconButton OkButton;
        internal IconButton Cancel;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Panel pnlButtonBright3d;
        private System.Windows.Forms.Panel pnlButtonDark3d;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label ProgramLbl;
        internal System.Windows.Forms.Label ProcessLbl;
        internal System.Windows.Forms.Label ClassesLbl;
        internal System.Windows.Forms.TextBox ProgramTxt;
        internal System.Windows.Forms.TextBox ProcessTxt;
        internal System.Windows.Forms.TextBox ClassesTxt;
        internal System.Windows.Forms.GroupBox SkinGroup;
        internal System.Windows.Forms.Label SkinLbl;
        internal System.Windows.Forms.ComboBox ColorSchemeTxt;
        internal System.Windows.Forms.CheckBox SkinedCheckBox;
        internal System.Windows.Forms.Label ColorSchemeLbl;
        internal System.Windows.Forms.ComboBox SkinTxt;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label WindowInfoLbl;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.ListView WindowsList;
    }
}
