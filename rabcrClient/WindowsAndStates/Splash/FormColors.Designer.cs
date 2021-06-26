namespace rabcrClient {
    partial class FormColors {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormColors));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.customButton2 = new GButton();
            this.customButton1 = new GButton();
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
            this.textPanel8.Size = new System.Drawing.Size(125, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 0;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Vyberte barvu";
            // 
            // customButton2
            // 
            this.customButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton2.BackColor = System.Drawing.Color.Transparent;
            this.customButton2.Disamble = false;
            this.customButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton2.ForeColor = System.Drawing.Color.Black;
            this.customButton2.Location = new System.Drawing.Point(143, 226);
            this.customButton2.Name = "customButton2";
            this.customButton2.SetOrientation = GButton.Orientation.Right;
            this.customButton2.Size = new System.Drawing.Size(146, 36);
            this.customButton2.TabIndex = 1;
            this.customButton2.Text = "Zrušit";
            this.customButton2.Click += new System.EventHandler(this.CustomButton2_Click);
            // 
            // customButton1
            // 
            this.customButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton1.BackColor = System.Drawing.Color.Transparent;
            this.customButton1.Disamble = true;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton1.Location = new System.Drawing.Point(295, 226);
            this.customButton1.Name = "customButton1";
            this.customButton1.SetOrientation = GButton.Orientation.Left;
            this.customButton1.Size = new System.Drawing.Size(146, 36);
            this.customButton1.TabIndex = 2;
            this.customButton1.Text = "Použít";
            this.customButton1.Click += new System.EventHandler(this.CustomButton1_Click);
            // 
            // FormColors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 274);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(595, 313);
            this.Name = "FormColors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vyberte barvu";
            this.Resize += new System.EventHandler(this.FormColors_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
        private GButton customButton2;
        private GButton customButton1;
    }
}