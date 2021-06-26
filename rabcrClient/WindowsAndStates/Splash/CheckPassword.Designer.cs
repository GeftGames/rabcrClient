namespace rabcrClient {
    partial class CheckPassword {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckPassword));
            this.customButton2 = new GButton();
            this.customButton1 = new GButton();
            this.textPanel1 = new GTextPanel();
            this.xTextBoxPassword = new GTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customButton2
            // 
            this.customButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton2.BackColor = System.Drawing.Color.Transparent;
            this.customButton2.Disamble = false;
            this.customButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton2.ForeColor = System.Drawing.Color.Black;
            this.customButton2.Location = new System.Drawing.Point(116, 145);
            this.customButton2.Name = "customButton2";
            this.customButton2.SetOrientation = GButton.Orientation.Right;
            this.customButton2.Size = new System.Drawing.Size(146, 36);
            this.customButton2.TabIndex = 2;
            this.customButton2.Text = "Zrušit";
            this.customButton2.Click += new System.EventHandler(this.GButton2_Click);
            // 
            // customButton1
            // 
            this.customButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton1.BackColor = System.Drawing.Color.Transparent;
            this.customButton1.Disamble = true;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton1.Location = new System.Drawing.Point(268, 145);
            this.customButton1.Name = "customButton1";
            this.customButton1.SetOrientation = GButton.Orientation.Left;
            this.customButton1.Size = new System.Drawing.Size(146, 36);
            this.customButton1.TabIndex = 3;
            this.customButton1.Text = "Podtvrdit";
            this.customButton1.Click += new System.EventHandler(this.GButton1_Click);
            // 
            // textPanel1
            // 
            this.textPanel1.BackColor = System.Drawing.Color.Transparent;
            this.textPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel1.Location = new System.Drawing.Point(43, 60);
            this.textPanel1.Name = "textPanel1";
            this.textPanel1.Size = new System.Drawing.Size(167, 23);
            this.textPanel1.SmallFont = false;
            this.textPanel1.TabIndex = 0;
            this.textPanel1.TabStop = false;
            this.textPanel1.Text = "Zadejte vaše heslo";
            // 
            // xTextBoxPassword
            // 
            this.xTextBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xTextBoxPassword.Location = new System.Drawing.Point(43, 89);
            this.xTextBoxPassword.Name = "xTextBoxPassword";
            this.xTextBoxPassword.PlaceHolder = null;
            this.xTextBoxPassword.Size = new System.Drawing.Size(447, 29);
            this.xTextBoxPassword.StateSelect = GBounds.StateSelect.Between;
            this.xTextBoxPassword.TabIndex = 1;
            this.xTextBoxPassword.TextInTextBox = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.textPanel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 34);
            this.panel1.TabIndex = 12;
            // 
            // textPanel8
            // 
            this.textPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel8.BackColor = System.Drawing.Color.Transparent;
            this.textPanel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel8.Location = new System.Drawing.Point(173, 6);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(195, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 9;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Server vyžaduje heslo";
            // 
            // CheckPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(529, 197);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xTextBoxPassword);
            this.Controls.Add(this.textPanel1);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CheckPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server vyžaduje heslo";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GButton customButton1;
        private GButton customButton2;
        private GTextPanel textPanel1;
        private GTextBox xTextBoxPassword;
        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
    }
}