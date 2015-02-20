using BorderSkin.Settings;

namespace BorderSkin.Execlusion
{
    partial class ExclusionManagerControl : System.Windows.Forms.UserControl
    {

        //UserControl overrides dispose to clean up the component list.
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
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.RemoveAllExc = new IconButton();
            this.RemoveExc = new IconButton();
            this.EditExc = new IconButton();
            this.AddExc = new IconButton();
            this.ExcList = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SkinnedColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SkinColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GroupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox6
            // 
            this.GroupBox6.BackColor = System.Drawing.Color.White;
            this.GroupBox6.Controls.Add(this.TitleLabel);
            this.GroupBox6.Controls.Add(this.RemoveAllExc);
            this.GroupBox6.Controls.Add(this.RemoveExc);
            this.GroupBox6.Controls.Add(this.EditExc);
            this.GroupBox6.Controls.Add(this.AddExc);
            this.GroupBox6.Controls.Add(this.ExcList);
            this.GroupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox6.Location = new System.Drawing.Point(0, 0);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Padding = new System.Windows.Forms.Padding(10, 5, 10, 40);
            this.GroupBox6.Size = new System.Drawing.Size(680, 454);
            this.GroupBox6.TabIndex = 1;
            this.GroupBox6.TabStop = false;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.White;
            this.TitleLabel.ForeColor = System.Drawing.Color.Blue;
            this.TitleLabel.Location = new System.Drawing.Point(7, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(95, 13);
            this.TitleLabel.TabIndex = 104;
            this.TitleLabel.Tag = "Windows Manager";
            this.TitleLabel.Text = "Windows Manager";
            // 
            // RemoveAllExc
            // 
            this.RemoveAllExc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveAllExc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveAllExc.Image = global::BorderSkin.Properties.Resources.RemoveAllImage;
            this.RemoveAllExc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveAllExc.Location = new System.Drawing.Point(429, 421);
            this.RemoveAllExc.Name = "RemoveAllExc";
            this.RemoveAllExc.Size = new System.Drawing.Size(87, 22);
            this.RemoveAllExc.TabIndex = 103;
            this.RemoveAllExc.Tag = "Remove All";
            this.RemoveAllExc.Text = "Remove All";
            this.RemoveAllExc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RemoveAllExc.Click += new System.EventHandler(this.RemoveAllExc_Click);
            // 
            // RemoveExc
            // 
            this.RemoveExc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveExc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RemoveExc.Image = global::BorderSkin.Properties.Resources.RemoveImage;
            this.RemoveExc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveExc.Location = new System.Drawing.Point(285, 421);
            this.RemoveExc.Name = "RemoveExc";
            this.RemoveExc.Size = new System.Drawing.Size(67, 22);
            this.RemoveExc.TabIndex = 103;
            this.RemoveExc.Tag = "Remove";
            this.RemoveExc.Text = "Remove";
            this.RemoveExc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RemoveExc.Click += new System.EventHandler(this.RemoveExc_Click);
            // 
            // EditExc
            // 
            this.EditExc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditExc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditExc.Image = global::BorderSkin.Properties.Resources.EditImage;
            this.EditExc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditExc.Location = new System.Drawing.Point(361, 421);
            this.EditExc.Name = "EditExc";
            this.EditExc.Size = new System.Drawing.Size(52, 22);
            this.EditExc.TabIndex = 103;
            this.EditExc.Tag = "Edit";
            this.EditExc.Text = "Edit";
            this.EditExc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditExc.Click += new System.EventHandler(this.EditExc_Click);
            // 
            // AddExc
            // 
            this.AddExc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddExc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddExc.Image = global::BorderSkin.Properties.Resources.AddImage;
            this.AddExc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddExc.Location = new System.Drawing.Point(223, 421);
            this.AddExc.Name = "AddExc";
            this.AddExc.Size = new System.Drawing.Size(47, 22);
            this.AddExc.TabIndex = 103;
            this.AddExc.Tag = "Add";
            this.AddExc.Text = "Add";
            this.AddExc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddExc.Click += new System.EventHandler(this.AddExc_Click);
            // 
            // ExcList
            // 
            this.ExcList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.ColumnHeader1,
                this.ColumnHeader2,
                this.ColumnHeader3,
                this.SkinnedColumn,
                this.SkinColumn});
            this.ExcList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExcList.FullRowSelect = true;
            this.ExcList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ExcList.LabelWrap = false;
            this.ExcList.Location = new System.Drawing.Point(10, 18);
            this.ExcList.MultiSelect = false;
            this.ExcList.Name = "ExcList";
            this.ExcList.Size = new System.Drawing.Size(660, 396);
            this.ExcList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ExcList.TabIndex = 31;
            this.ExcList.UseCompatibleStateImageBehavior = false;
            this.ExcList.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Tag = "Name";
            this.ColumnHeader1.Text = "Name";
            this.ColumnHeader1.Width = 149;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Tag = "Process";
            this.ColumnHeader2.Text = "Process";
            this.ColumnHeader2.Width = 99;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Tag = "Classes";
            this.ColumnHeader3.Text = "Classes";
            this.ColumnHeader3.Width = 149;
            // 
            // SkinnedColumn
            // 
            this.SkinnedColumn.Tag = "Has Skin";
            this.SkinnedColumn.Text = "Has Skin";
            this.SkinnedColumn.Width = 101;
            // 
            // SkinColumn
            // 
            this.SkinColumn.Tag = "Skin";
            this.SkinColumn.Text = "Skin";
            this.SkinColumn.Width = 103;
            // 
            // ExclusionManagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GroupBox6);
            this.Name = "ExclusionManagerControl";
            this.Size = new System.Drawing.Size(680, 454);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.Label TitleLabel;
        internal IconButton RemoveAllExc;
        internal IconButton RemoveExc;
        internal IconButton EditExc;
        internal IconButton AddExc;
        internal System.Windows.Forms.ListView ExcList;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader SkinnedColumn;

        internal System.Windows.Forms.ColumnHeader SkinColumn;
    }
}
