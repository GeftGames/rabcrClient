namespace rabcrClient {
    partial class FormUpdate {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdate));
            this.textPanel1 = new GTextPanel();
            this.customButton1 = new GButton();
            this.customButton2 = new GButton();
            this.SuspendLayout();
            // 
            // textPanel1
            // 
            this.textPanel1.BackColor = System.Drawing.Color.Transparent;
            this.textPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel1.Location = new System.Drawing.Point(13, 13);
            this.textPanel1.Name = "textPanel1";
            this.textPanel1.Size = new System.Drawing.Size(218, 23);
            this.textPanel1.SmallFont = false;
            this.textPanel1.TabIndex = 0;
            this.textPanel1.TabStop = false;
            this.textPanel1.Text = "Hledání nové verze hry...";
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.Transparent;
            this.customButton1.Disamble = false;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton1.Location = new System.Drawing.Point(196, 115);
            this.customButton1.Name = "customButton1";
            this.customButton1.SetOrientation = GButton.Orientation.Center;
            this.customButton1.Size = new System.Drawing.Size(147, 36);
            this.customButton1.TabIndex = 2;
            this.customButton1.Text = "Zavřít";
            this.customButton1.Click += new System.EventHandler(this.GButton1_Click);
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.Color.Transparent;
            this.customButton2.Disamble = false;
            this.customButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton2.Location = new System.Drawing.Point(106, 94);
            this.customButton2.Name = "customButton2";
            this.customButton2.SetOrientation = GButton.Orientation.Center;
            this.customButton2.Size = new System.Drawing.Size(147, 36);
            this.customButton2.TabIndex = 2;
            this.customButton2.Text = "Stáhnout";
            this.customButton2.Visible = false;
            this.customButton2.Click += new System.EventHandler(this.GButton2_Click);
            // 
            // FormUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(355, 162);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.textPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormUpdate";
            this.ResumeLayout(false);

        }

        #endregion

        private GTextPanel textPanel1;
        private GButton customButton1;
        private GButton customButton2;
    }
}