namespace rabcrClient {
    partial class FormAchDetail {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing&&(components!=null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAchDetail));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.buttonClose = new GButton();
            this.gTextPanel1 = new GTextPanel();
            this.buttonShare = new GButton();
            this.gTextPanel2 = new GTextPanel();
            this.gTextPanel3 = new GTextPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.textPanel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 34);
            this.panel1.TabIndex = 0;
            // 
            // textPanel8
            // 
            this.textPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel8.BackColor = System.Drawing.Color.Transparent;
            this.textPanel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel8.Location = new System.Drawing.Point(206, 8);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(168, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 0;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Achievement detail";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Disamble = false;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.Location = new System.Drawing.Point(219, 226);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.SetOrientation = GButton.Orientation.Center;
            this.buttonClose.Size = new System.Drawing.Size(146, 36);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // gTextPanel1
            // 
            this.gTextPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.gTextPanel1.Location = new System.Drawing.Point(31, 110);
            this.gTextPanel1.Name = "gTextPanel1";
            this.gTextPanel1.Size = new System.Drawing.Size(322, 23);
            this.gTextPanel1.SmallFont = false;
            this.gTextPanel1.TabIndex = 0;
            this.gTextPanel1.TabStop = false;
            this.gTextPanel1.Text = "This is text about acheavement detail";
            // 
            // buttonShare
            // 
            this.buttonShare.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonShare.BackColor = System.Drawing.Color.Transparent;
            this.buttonShare.Disamble = true;
            this.buttonShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonShare.Location = new System.Drawing.Point(153, 153);
            this.buttonShare.Name = "buttonShare";
            this.buttonShare.SetOrientation = GButton.Orientation.Center;
            this.buttonShare.Size = new System.Drawing.Size(298, 36);
            this.buttonShare.TabIndex = 2;
            this.buttonShare.Text = "Share as Game Jolt Trophy";
            this.buttonShare.Click += new System.EventHandler(this.ButtonShare_Click);
            // 
            // gTextPanel2
            // 
            this.gTextPanel2.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.gTextPanel2.Location = new System.Drawing.Point(31, 51);
            this.gTextPanel2.Name = "gTextPanel2";
            this.gTextPanel2.Size = new System.Drawing.Size(164, 23);
            this.gTextPanel2.SmallFont = false;
            this.gTextPanel2.TabIndex = 0;
            this.gTextPanel2.TabStop = false;
            this.gTextPanel2.Text = "Base achievement";
            // 
            // gTextPanel3
            // 
            this.gTextPanel3.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.gTextPanel3.Location = new System.Drawing.Point(31, 80);
            this.gTextPanel3.Name = "gTextPanel3";
            this.gTextPanel3.Size = new System.Drawing.Size(115, 23);
            this.gTextPanel3.SmallFont = false;
            this.gTextPanel3.TabIndex = 0;
            this.gTextPanel3.TabStop = false;
            this.gTextPanel3.Text = "Not acquired";
            // 
            // FormAchDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 274);
            this.Controls.Add(this.gTextPanel3);
            this.Controls.Add(this.gTextPanel2);
            this.Controls.Add(this.gTextPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonShare);
            this.Controls.Add(this.buttonClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(595, 313);
            this.Name = "FormAchDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acheavement detail";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
        private GButton buttonClose;
        private GTextPanel gTextPanel1;
        private GButton buttonShare;
        private GTextPanel gTextPanel2;
        private GTextPanel gTextPanel3;
    }
}