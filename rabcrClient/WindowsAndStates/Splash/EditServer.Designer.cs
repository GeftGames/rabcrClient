namespace rabcrClient {
    partial class EditServer {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditServer));
            this.textPanel1 = new GTextPanel();
            this.customButton3 = new GButton();
            this.customButton2 = new GButton();
            this.textPanel4 = new GTextPanel();
            this.customButton1 = new GButton();
            this.xTextBoxName = new GTextBox();
            this.xTextBoxIp = new GTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.textPanel2 = new GTextPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // textPanel1
            //
            this.textPanel1.BackColor = System.Drawing.Color.Transparent;
            this.textPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel1.Location = new System.Drawing.Point(43, 60);
            this.textPanel1.Name = "textPanel1";
            this.textPanel1.Size = new System.Drawing.Size(138, 23);
            this.textPanel1.SmallFont = false;
            this.textPanel1.TabIndex = 0;
            this.textPanel1.TabStop = false;
            this.textPanel1.Text = "Název připojení";
            //
            // customButton3
            //
            this.customButton3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton3.BackColor = System.Drawing.Color.Transparent;
            this.customButton3.Disamble = false;
            this.customButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton3.Location = new System.Drawing.Point(267, 317);
            this.customButton3.Name = "customButton3";
            this.customButton3.SetOrientation = GButton.Orientation.Left;
            this.customButton3.Size = new System.Drawing.Size(149, 36);
            this.customButton3.TabIndex = 4;
            this.customButton3.Text = "Použít";
            this.customButton3.Click += new System.EventHandler(this.GButton3_Click);
            //
            // customButton2
            //
            this.customButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton2.BackColor = System.Drawing.Color.Transparent;
            this.customButton2.Disamble = false;
            this.customButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton2.Location = new System.Drawing.Point(112, 317);
            this.customButton2.Name = "customButton2";
            this.customButton2.SetOrientation = GButton.Orientation.Right;
            this.customButton2.Size = new System.Drawing.Size(149, 36);
            this.customButton2.TabIndex = 3;
            this.customButton2.Text = "Zrušit";
            this.customButton2.Click += new System.EventHandler(this.GButton2_Click);
            //
            // textPanel4
            //
            this.textPanel4.BackColor = System.Drawing.Color.Transparent;
            this.textPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel4.Location = new System.Drawing.Point(43, 141);
            this.textPanel4.Name = "textPanel4";
            this.textPanel4.Size = new System.Drawing.Size(136, 23);
            this.textPanel4.SmallFont = false;
            this.textPanel4.TabIndex = 0;
            this.textPanel4.TabStop = false;
            this.textPanel4.Text = "Adresa serveru";
            //
            // customButton1
            //
            this.customButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton1.BackColor = System.Drawing.Color.Transparent;
            this.customButton1.Disamble = false;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton1.Location = new System.Drawing.Point(341, 233);
            this.customButton1.Name = "customButton1";
            this.customButton1.SetOrientation = GButton.Orientation.Center;
            this.customButton1.Size = new System.Drawing.Size(149, 36);
            this.customButton1.TabIndex = 2;
            this.customButton1.Text = "Smazat";
            this.customButton1.Click += new System.EventHandler(this.GButton1_Click);
            //
            // xTextBoxName
            //
            this.xTextBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xTextBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xTextBoxName.Location = new System.Drawing.Point(43, 89);
            this.xTextBoxName.Name = "xTextBoxName";
            this.xTextBoxName.PlaceHolder = null;
            this.xTextBoxName.Size = new System.Drawing.Size(447, 29);
            this.xTextBoxName.StateSelect = GBounds.StateSelect.Between;
            this.xTextBoxName.TabIndex = 0;
            this.xTextBoxName.TextInTextBox = "";
            //
            // xTextBoxIp
            //
            this.xTextBoxIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xTextBoxIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xTextBoxIp.Location = new System.Drawing.Point(43, 170);
            this.xTextBoxIp.Name = "xTextBoxIp";
            this.xTextBoxIp.PlaceHolder = null;
            this.xTextBoxIp.Size = new System.Drawing.Size(447, 29);
            this.xTextBoxIp.StateSelect = GBounds.StateSelect.Between;
            this.xTextBoxIp.TabIndex = 1;
            this.xTextBoxIp.TextInTextBox = "";
            //
            // panel1
            //
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.textPanel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 34);
            this.panel1.TabIndex = 11;
            //
            // textPanel8
            //
            this.textPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel8.BackColor = System.Drawing.Color.Transparent;
            this.textPanel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel8.Location = new System.Drawing.Point(152, 6);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(229, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 9;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Upravit připojení k serveru";
            //
            // textPanel2
            //
            this.textPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel2.BackColor = System.Drawing.Color.Transparent;
            this.textPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textPanel2.Location = new System.Drawing.Point(43, 237);
            this.textPanel2.Name = "textPanel2";
            this.textPanel2.Size = new System.Drawing.Size(149, 23);
            this.textPanel2.SmallFont = false;
            this.textPanel2.TabIndex = 13;
            this.textPanel2.TabStop = false;
            this.textPanel2.Text = "Smazat připojení";
            //
            // EditServer
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(526, 364);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.textPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xTextBoxIp);
            this.Controls.Add(this.xTextBoxName);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton3);
            this.Controls.Add(this.textPanel4);
            this.Controls.Add(this.textPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "EditServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upravit připojení k serveru";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GTextPanel textPanel1;
        private GButton customButton3;
        private GButton customButton2;
        private GTextPanel textPanel4;
        private GButton customButton1;
        private GTextBox xTextBoxName;
        private GTextBox xTextBoxIp;
        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
        private GTextPanel textPanel2;
    }
}