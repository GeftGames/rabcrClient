namespace rabcrClient {
    partial class Password {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Password));
            this.textPanel2 = new GTextPanel();
            this.textPanel1 = new GTextPanel();
            this.customButton2 = new GButton();
            this.customButton1 = new GButton();
            this.xTextBoxPassword1 = new GTextBox();
            this.xTextBoxPassword2 = new GTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textPanel2
            // 
            this.textPanel2.BackColor = System.Drawing.Color.Transparent;
            this.textPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel2.Location = new System.Drawing.Point(43, 138);
            this.textPanel2.Name = "textPanel2";
            this.textPanel2.Size = new System.Drawing.Size(265, 23);
            this.textPanel2.SmallFont = false;
            this.textPanel2.TabIndex = 3;
            this.textPanel2.TabStop = false;
            this.textPanel2.Text = "Pro jistotu své heslo zopakujte";
            // 
            // textPanel1
            // 
            this.textPanel1.BackColor = System.Drawing.Color.Transparent;
            this.textPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel1.Location = new System.Drawing.Point(43, 60);
            this.textPanel1.Name = "textPanel1";
            this.textPanel1.Size = new System.Drawing.Size(214, 23);
            this.textPanel1.SmallFont = false;
            this.textPanel1.TabIndex = 0;
            this.textPanel1.TabStop = false;
            this.textPanel1.Text = "Zadejte vaše nové heslo";
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.Color.Transparent;
            this.customButton2.Disamble = false;
            this.customButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton2.ForeColor = System.Drawing.Color.Black;
            this.customButton2.Location = new System.Drawing.Point(123, 223);
            this.customButton2.Name = "customButton2";
            this.customButton2.SetOrientation = GButton.Orientation.Right;
            this.customButton2.Size = new System.Drawing.Size(146, 36);
            this.customButton2.TabIndex = 2;
            this.customButton2.Text = "Zrušit";
            this.customButton2.Click += new System.EventHandler(this.GButton2_Click);
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.Transparent;
            this.customButton1.Disamble = true;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton1.Location = new System.Drawing.Point(275, 223);
            this.customButton1.Name = "customButton1";
            this.customButton1.SetOrientation = GButton.Orientation.Left;
            this.customButton1.Size = new System.Drawing.Size(146, 36);
            this.customButton1.TabIndex = 3;
            this.customButton1.Text = "Podtvrdit";
            this.customButton1.Click += new System.EventHandler(this.GButton1_Click);
            // 
            // xTextBoxPassword1
            // 
            this.xTextBoxPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xTextBoxPassword1.Location = new System.Drawing.Point(43, 89);
            this.xTextBoxPassword1.Name = "xTextBoxPassword1";
            this.xTextBoxPassword1.PlaceHolder = null;
            this.xTextBoxPassword1.Size = new System.Drawing.Size(433, 29);
            this.xTextBoxPassword1.StateSelect = GBounds.StateSelect.Between;
            this.xTextBoxPassword1.TabIndex = 0;
            this.xTextBoxPassword1.TextInTextBox = "";
            // 
            // xTextBoxPassword2
            // 
            this.xTextBoxPassword2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xTextBoxPassword2.Location = new System.Drawing.Point(43, 167);
            this.xTextBoxPassword2.Name = "xTextBoxPassword2";
            this.xTextBoxPassword2.PlaceHolder = null;
            this.xTextBoxPassword2.Size = new System.Drawing.Size(433, 29);
            this.xTextBoxPassword2.StateSelect = GBounds.StateSelect.Between;
            this.xTextBoxPassword2.TabIndex = 1;
            this.xTextBoxPassword2.TextInTextBox = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.textPanel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 34);
            this.panel1.TabIndex = 13;
            // 
            // textPanel8
            // 
            this.textPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel8.BackColor = System.Drawing.Color.Transparent;
            this.textPanel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel8.Location = new System.Drawing.Point(148, 8);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(241, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 9;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Server vyžaduje nové heslo";
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(529, 269);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xTextBoxPassword2);
            this.Controls.Add(this.xTextBoxPassword1);
            this.Controls.Add(this.textPanel2);
            this.Controls.Add(this.textPanel1);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Password";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server vyžaduje nové heslo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Password_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GButton customButton1;
        private GButton customButton2;
        private GTextPanel textPanel1;
        private GTextPanel textPanel2;
        private GTextBox xTextBoxPassword1;
        private GTextBox xTextBoxPassword2;
        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
    }
}