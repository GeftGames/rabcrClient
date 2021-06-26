namespace rabcrClient {
    partial class LanguageInfo {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.customButton3 = new GButton();
            this.gTextPanelText = new GTextPanel();
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
            this.panel1.Size = new System.Drawing.Size(477, 34);
            this.panel1.TabIndex = 10;
            // 
            // textPanel8
            // 
            this.textPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel8.BackColor = System.Drawing.Color.Transparent;
            this.textPanel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel8.Location = new System.Drawing.Point(145, 7);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(167, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 9;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Informace o jazyku";
            // 
            // customButton3
            // 
            this.customButton3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton3.BackColor = System.Drawing.Color.Transparent;
            this.customButton3.Disamble = false;
            this.customButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton3.Location = new System.Drawing.Point(158, 214);
            this.customButton3.Name = "customButton3";
            this.customButton3.SetOrientation = GButton.Orientation.Center;
            this.customButton3.Size = new System.Drawing.Size(149, 36);
            this.customButton3.TabIndex = 3;
            this.customButton3.Text = "Zavřít";
            this.customButton3.Click += new System.EventHandler(this.GButton3_Click);
            // 
            // gTextPanelText
            // 
            this.gTextPanelText.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.gTextPanelText.Location = new System.Drawing.Point(12, 51);
            this.gTextPanelText.Name = "gTextPanelText";
            this.gTextPanelText.Size = new System.Drawing.Size(107, 23);
            this.gTextPanelText.SmallFont = false;
            this.gTextPanelText.TabIndex = 9;
            this.gTextPanelText.TabStop = false;
            this.gTextPanelText.Text = "Informace...";
            // 
            // LanguageInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(477, 262);
            this.Controls.Add(this.gTextPanelText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customButton3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LanguageInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informace o jazyku";
            this.Shown += new System.EventHandler(this.SelectLanguage_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GButton customButton3;
        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
        private GTextPanel gTextPanelText;
    }
}