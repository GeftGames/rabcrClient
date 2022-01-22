namespace rabcrClient {
    #if MULTIPLAYER
    partial class FormLogin {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel1 = new GTextPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.geDoPanel1 = new rabcrClient.GeDoPanel();
            this.textPanel4 = new GTextPanel();
            this.customButton2 = new GButton();
            this.customButton1 = new GButton();
            this.textPanel3 = new GTextPanel();
            this.textPanel2 = new GTextPanel();
            this.xTextbox2 = new GTextBox();
            this.xTextbox1 = new GTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // panel1
            //
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.textPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 34);
            this.panel1.TabIndex = 0;
            //
            // textPanel1
            //
            this.textPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel1.BackColor = System.Drawing.Color.Transparent;
            this.textPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel1.Location = new System.Drawing.Point(157, 7);
            this.textPanel1.Name = "textPanel1";
            this.textPanel1.Size = new System.Drawing.Size(90, 23);
            this.textPanel1.SmallFont = false;
            this.textPanel1.TabIndex = 0;
            this.textPanel1.TabStop = false;
            this.textPanel1.Text = "Přihlášení";
            //
            // panel2
            //
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Location = new System.Drawing.Point(0, 260);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 2);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            //
            // geDoPanel1
            //
            this.geDoPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.geDoPanel1.Location = new System.Drawing.Point(38, 268);
            this.geDoPanel1.Name = "geDoPanel1";
            this.geDoPanel1.Size = new System.Drawing.Size(351, 100);
            this.geDoPanel1.TabIndex = 7;
            this.geDoPanel1.TabStop = false;
            this.geDoPanel1.Text = "geDoPanel1";
            this.geDoPanel1.Visible = false;
            //
            // textPanel4
            //
            this.textPanel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel4.BackColor = System.Drawing.Color.Transparent;
            this.textPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel4.Location = new System.Drawing.Point(157, 161);
            this.textPanel4.Name = "textPanel4";
            this.textPanel4.Size = new System.Drawing.Size(127, 23);
            this.textPanel4.SmallFont = false;
            this.textPanel4.TabIndex = 0;
            this.textPanel4.TabStop = false;
            this.textPanel4.Text = "Přihlašování...";
            this.textPanel4.Visible = false;
            //
            // customButton2
            //
            this.customButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.customButton2.BackColor = System.Drawing.Color.Transparent;
            this.customButton2.Disamble = false;
            this.customButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton2.Location = new System.Drawing.Point(144, 246);
            this.customButton2.Name = "customButton2";
            this.customButton2.SetOrientation = GButton.Orientation.Right;
            this.customButton2.Size = new System.Drawing.Size(87, 36);
            this.customButton2.TabIndex = 2;
            this.customButton2.Text = "Zrušit";
            this.customButton2.Click += new System.EventHandler(this.GButton2_Click);
            //
            // customButton1
            //
            this.customButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.customButton1.BackColor = System.Drawing.Color.Transparent;
            this.customButton1.Disamble = false;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton1.Location = new System.Drawing.Point(237, 246);
            this.customButton1.Name = "customButton1";
            this.customButton1.SetOrientation = GButton.Orientation.Left;
            this.customButton1.Size = new System.Drawing.Size(145, 36);
            this.customButton1.TabIndex = 3;
            this.customButton1.Text = "Přihlásit se";
            this.customButton1.Click += new System.EventHandler(this.GButton1_Click);
            //
            // textPanel3
            //
            this.textPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel3.BackColor = System.Drawing.Color.Transparent;
            this.textPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel3.Location = new System.Drawing.Point(38, 165);
            this.textPanel3.Name = "textPanel3";
            this.textPanel3.Size = new System.Drawing.Size(55, 23);
            this.textPanel3.SmallFont = false;
            this.textPanel3.TabIndex = 0;
            this.textPanel3.TabStop = false;
            this.textPanel3.Text = "Heslo";
            //
            // textPanel2
            //
            this.textPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel2.BackColor = System.Drawing.Color.Transparent;
            this.textPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel2.Location = new System.Drawing.Point(38, 88);
            this.textPanel2.Name = "textPanel2";
            this.textPanel2.Size = new System.Drawing.Size(90, 23);
            this.textPanel2.SmallFont = false;
            this.textPanel2.TabIndex = 0;
            this.textPanel2.TabStop = false;
            this.textPanel2.Text = "Přezdívka";
            //
            // xTextbox2
            //
            this.xTextbox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.xTextbox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xTextbox2.Location = new System.Drawing.Point(38, 195);
            this.xTextbox2.Name = "xTextbox2";
            this.xTextbox2.PlaceHolder = "********";
            this.xTextbox2.Size = new System.Drawing.Size(351, 29);
            this.xTextbox2.StateSelect = GBounds.StateSelect.Between;
            this.xTextbox2.TabIndex = 1;
            this.xTextbox2.TextInTextBox = "";
            //
            // xTextbox1
            //
            this.xTextbox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.xTextbox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xTextbox1.Location = new System.Drawing.Point(38, 122);
            this.xTextbox1.Name = "xTextbox1";
            this.xTextbox1.PlaceHolder = "Mimonitko8";
            this.xTextbox1.Size = new System.Drawing.Size(351, 29);
            this.xTextbox1.StateSelect = GBounds.StateSelect.Between;
            this.xTextbox1.TabIndex = 0;
            this.xTextbox1.TextInTextBox = "";
            //
            // FormLogin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(426, 376);
            this.Controls.Add(this.textPanel4);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.textPanel3);
            this.Controls.Add(this.textPanel2);
            this.Controls.Add(this.xTextbox2);
            this.Controls.Add(this.xTextbox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.geDoPanel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(375, 415);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Přihlášení";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GTextPanel textPanel1;
        private System.Windows.Forms.Panel panel1;
        public GTextBox xTextbox1;
        public GTextBox xTextbox2;
        private GTextPanel textPanel2;
        private GTextPanel textPanel3;
        private GButton customButton1;
        private GButton customButton2;
        private System.Windows.Forms.Panel panel2;
        private GTextPanel textPanel4;
        public GeDoPanel geDoPanel1;
    }
    #endif
}