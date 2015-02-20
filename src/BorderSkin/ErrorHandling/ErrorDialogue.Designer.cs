namespace BorderSkin.ErrorHandling
{
    partial class ErrorDialogue
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.OK = new System.Windows.Forms.Label();
            this.ErrorTxt = new System.Windows.Forms.TextBox();
            this.DetailsTxt = new System.Windows.Forms.TextBox();
            this.DetailsLbl = new System.Windows.Forms.Label();
            this.ErrorLbl = new System.Windows.Forms.Label();
            this.lblBorderSkinError = new System.Windows.Forms.Label();
            this.ErrorImg = new System.Windows.Forms.PictureBox();
            this.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImg)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel2
            // 
            this.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Panel2.Controls.Add(this.Panel3);
            this.Panel2.Controls.Add(this.Panel4);
            this.Panel2.Controls.Add(this.OK);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 400);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(477, 58);
            this.Panel2.TabIndex = 112;
            // 
            // Panel3
            // 
            this.Panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 1);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(477, 1);
            this.Panel3.TabIndex = 17;
            // 
            // Panel4
            // 
            this.Panel4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(477, 1);
            this.Panel4.TabIndex = 18;
            // 
            // OK
            // 
            this.OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OK.Image = global::BorderSkin.Properties.Resources.OKImage;
            this.OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OK.Location = new System.Drawing.Point(381, 17);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(45, 25);
            this.OK.TabIndex = 101;
            this.OK.Tag = "OK";
            this.OK.Text = "OK";
            this.OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ErrorTxt
            // 
            this.ErrorTxt.BackColor = System.Drawing.Color.White;
            this.ErrorTxt.Location = new System.Drawing.Point(64, 45);
            this.ErrorTxt.Multiline = true;
            this.ErrorTxt.Name = "ErrorTxt";
            this.ErrorTxt.ReadOnly = true;
            this.ErrorTxt.Size = new System.Drawing.Size(390, 68);
            this.ErrorTxt.TabIndex = 110;
            this.ErrorTxt.Text = "(errormessage)";
            // 
            // DetailsTxt
            // 
            this.DetailsTxt.BackColor = System.Drawing.Color.White;
            this.DetailsTxt.Location = new System.Drawing.Point(64, 146);
            this.DetailsTxt.Multiline = true;
            this.DetailsTxt.Name = "DetailsTxt";
            this.DetailsTxt.ReadOnly = true;
            this.DetailsTxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DetailsTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DetailsTxt.Size = new System.Drawing.Size(390, 230);
            this.DetailsTxt.TabIndex = 109;
            this.DetailsTxt.Text = "Exception Source    : (soruce)\r\nException Type       : (type)\r\nException Message " +
    ": (message)\r\nException Site         : (targetsite)\r\n\r\n------------- : Stack Trac" +
    "e : -------------\r\n(stacktrace)";
            this.DetailsTxt.WordWrap = false;
            // 
            // DetailsLbl
            // 
            this.DetailsLbl.AutoSize = true;
            this.DetailsLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsLbl.Location = new System.Drawing.Point(61, 130);
            this.DetailsLbl.Name = "DetailsLbl";
            this.DetailsLbl.Size = new System.Drawing.Size(86, 13);
            this.DetailsLbl.TabIndex = 108;
            this.DetailsLbl.Text = "Error Details : ";
            // 
            // ErrorLbl
            // 
            this.ErrorLbl.AutoSize = true;
            this.ErrorLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLbl.Location = new System.Drawing.Point(61, 29);
            this.ErrorLbl.Name = "ErrorLbl";
            this.ErrorLbl.Size = new System.Drawing.Size(35, 13);
            this.ErrorLbl.TabIndex = 107;
            this.ErrorLbl.Text = "Error";
            // 
            // lblBorderSkinError
            // 
            this.lblBorderSkinError.AutoSize = true;
            this.lblBorderSkinError.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBorderSkinError.ForeColor = System.Drawing.Color.Black;
            this.lblBorderSkinError.Location = new System.Drawing.Point(61, 9);
            this.lblBorderSkinError.Name = "lblBorderSkinError";
            this.lblBorderSkinError.Size = new System.Drawing.Size(118, 16);
            this.lblBorderSkinError.TabIndex = 105;
            this.lblBorderSkinError.Text = "Border Skin Error";
            // 
            // ErrorImg
            // 
            this.ErrorImg.Image = global::BorderSkin.Properties.Resources.ErrorImage;
            this.ErrorImg.Location = new System.Drawing.Point(8, 9);
            this.ErrorImg.Name = "ErrorImg";
            this.ErrorImg.Size = new System.Drawing.Size(47, 49);
            this.ErrorImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ErrorImg.TabIndex = 111;
            this.ErrorImg.TabStop = false;
            // 
            // ErrorDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(477, 458);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.ErrorTxt);
            this.Controls.Add(this.DetailsTxt);
            this.Controls.Add(this.DetailsLbl);
            this.Controls.Add(this.ErrorLbl);
            this.Controls.Add(this.lblBorderSkinError);
            this.Controls.Add(this.ErrorImg);
            this.Name = "ErrorDialogue";
            this.Text = "BorderSkin Error";
            this.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.Panel Panel3;
        private System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label OK;
        internal System.Windows.Forms.TextBox ErrorTxt;
        internal System.Windows.Forms.TextBox DetailsTxt;
        internal System.Windows.Forms.Label DetailsLbl;
        internal System.Windows.Forms.Label ErrorLbl;
        internal System.Windows.Forms.Label lblBorderSkinError;
        internal System.Windows.Forms.PictureBox ErrorImg;

    }
}