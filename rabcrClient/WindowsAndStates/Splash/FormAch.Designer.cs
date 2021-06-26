namespace rabcrClient {
    partial class FormAch {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.buttonClose = new GButton();
            this.achievmentControl3 = new rabcr.AchievmentControl();
            this.achievmentControl2 = new rabcr.AchievmentControl();
            this.achievmentControl0 = new rabcr.AchievmentControl();
            this.achievmentControl1 = new rabcr.AchievmentControl();
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
            this.textPanel8.Location = new System.Drawing.Point(222, 8);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(127, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 0;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Achievements";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.Disamble = false;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClose.Location = new System.Drawing.Point(209, 372);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.SetOrientation = GButton.Orientation.Center;
            this.buttonClose.Size = new System.Drawing.Size(146, 36);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.CustomButton1_Click);
            // 
            // achievmentControl3
            // 
            this.achievmentControl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.achievmentControl3.BackColor = System.Drawing.Color.Transparent;
            this.achievmentControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.achievmentControl3.Image = global::rabcrClient.Properties.Resources.rocket;
            this.achievmentControl3.Location = new System.Drawing.Point(129, 273);
            this.achievmentControl3.Name = "achievmentControl3";
            this.achievmentControl3.Size = new System.Drawing.Size(312, 64);
            this.achievmentControl3.TabIndex = 3;
            this.achievmentControl3.Text = "Future age";
            this.achievmentControl3.Click += new System.EventHandler(this.AchievmentControl3_Click);
            // 
            // achievmentControl2
            // 
            this.achievmentControl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.achievmentControl2.BackColor = System.Drawing.Color.Transparent;
            this.achievmentControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.achievmentControl2.Image = global::rabcrClient.Properties.Resources.Iron;
            this.achievmentControl2.Location = new System.Drawing.Point(129, 203);
            this.achievmentControl2.Name = "achievmentControl2";
            this.achievmentControl2.Size = new System.Drawing.Size(312, 64);
            this.achievmentControl2.TabIndex = 3;
            this.achievmentControl2.Text = "Iron age";
            this.achievmentControl2.Click += new System.EventHandler(this.achievmentControl2_Click);
            // 
            // achievmentControl0
            // 
            this.achievmentControl0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.achievmentControl0.BackColor = System.Drawing.Color.Transparent;
            this.achievmentControl0.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.achievmentControl0.Image = global::rabcrClient.Properties.Resources.stones;
            this.achievmentControl0.Location = new System.Drawing.Point(129, 63);
            this.achievmentControl0.Name = "achievmentControl0";
            this.achievmentControl0.Size = new System.Drawing.Size(312, 64);
            this.achievmentControl0.TabIndex = 3;
            this.achievmentControl0.Text = "Stone age";
            this.achievmentControl0.Click += new System.EventHandler(this.AchievmentControl0_Click);
            // 
            // achievmentControl1
            // 
            this.achievmentControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.achievmentControl1.BackColor = System.Drawing.Color.Transparent;
            this.achievmentControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.achievmentControl1.Image = global::rabcrClient.Properties.Resources.Bronze1;
            this.achievmentControl1.Location = new System.Drawing.Point(129, 133);
            this.achievmentControl1.Name = "achievmentControl1";
            this.achievmentControl1.Size = new System.Drawing.Size(312, 64);
            this.achievmentControl1.TabIndex = 3;
            this.achievmentControl1.Text = "Bronze age";
            this.achievmentControl1.Click += new System.EventHandler(this.AchievmentControl1_Click);
            // 
            // FormAch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 420);
            this.Controls.Add(this.achievmentControl3);
            this.Controls.Add(this.achievmentControl2);
            this.Controls.Add(this.achievmentControl0);
            this.Controls.Add(this.achievmentControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(595, 313);
            this.Name = "FormAch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acheavements";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
        private GButton buttonClose;
        private rabcr.AchievmentControl achievmentControl1;
        private rabcr.AchievmentControl achievmentControl0;
        private rabcr.AchievmentControl achievmentControl2;
        private rabcr.AchievmentControl achievmentControl3;
    }
}