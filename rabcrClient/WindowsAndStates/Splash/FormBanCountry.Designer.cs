namespace rabcrClient {
    partial class FormBanCountry {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBanCountry));
            this.gButton1 = new GButton();
            this.geDoPanel1 = new rabcrClient.GeDoPanel();
            this.gButton2 = new GButton();
            this.SuspendLayout();
            //
            // gButton1
            //
            this.gButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gButton1.BackColor = System.Drawing.Color.Transparent;
            this.gButton1.Disamble = false;
            this.gButton1.Location = new System.Drawing.Point(502, 446);
            this.gButton1.Name = "gButton1";
            this.gButton1.SetOrientation = GButton.Orientation.Right;
            this.gButton1.Size = new System.Drawing.Size(75, 36);
            this.gButton1.TabIndex = 1;
            this.gButton1.Text = "Exit";
            this.gButton1.Click += new System.EventHandler(this.GButton1_Click);
            //
            // geDoPanel1
            //
            this.geDoPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.geDoPanel1.Location = new System.Drawing.Point(12, 12);
            this.geDoPanel1.Name = "geDoPanel1";
            this.geDoPanel1.Size = new System.Drawing.Size(693, 428);
            this.geDoPanel1.TabIndex = 0;
            this.geDoPanel1.TabStop = false;
            this.geDoPanel1.Text = "geDoPanel1";
            //
            // gButton2
            //
            this.gButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gButton2.BackColor = System.Drawing.Color.Transparent;
            this.gButton2.Disamble = false;
            this.gButton2.Location = new System.Drawing.Point(583, 446);
            this.gButton2.Name = "gButton2";
            this.gButton2.SetOrientation = GButton.Orientation.Left;
            this.gButton2.Size = new System.Drawing.Size(123, 36);
            this.gButton2.TabIndex = 2;
            this.gButton2.Text = "Run game";
            this.gButton2.Click += new System.EventHandler(this.GButton2_Click);
            //
            // FormBanCountry
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(718, 494);
            this.Controls.Add(this.geDoPanel1);
            this.Controls.Add(this.gButton2);
            this.Controls.Add(this.gButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBanCountry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "We don\'t like your country";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private GButton gButton1;
        private GeDoPanel geDoPanel1;
        private GButton gButton2;
    }
}