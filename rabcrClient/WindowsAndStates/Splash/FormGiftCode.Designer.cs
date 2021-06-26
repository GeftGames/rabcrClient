namespace rabcrClient {
    partial class FormGiftCode {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGiftCode));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.buttonCancel = new GButton();
            this.gTextBox1 = new GTextBox();
            this.gTextPanel1 = new GTextPanel();
            this.buttonApply = new GButton();
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
            this.panel1.Size = new System.Drawing.Size(440, 34);
            this.panel1.TabIndex = 0;
            // 
            // textPanel8
            // 
            this.textPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel8.BackColor = System.Drawing.Color.Transparent;
            this.textPanel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel8.Location = new System.Drawing.Point(182, 8);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(83, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 0;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Gift code";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.Disamble = false;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(76, 216);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.SetOrientation = GButton.Orientation.Right;
            this.buttonCancel.Size = new System.Drawing.Size(146, 36);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // gTextBox1
            // 
            this.gTextBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gTextBox1.Location = new System.Drawing.Point(82, 118);
            this.gTextBox1.Name = "gTextBox1";
            this.gTextBox1.PlaceHolder = null;
            this.gTextBox1.Size = new System.Drawing.Size(286, 29);
            this.gTextBox1.StateSelect = GBounds.StateSelect.Between;
            this.gTextBox1.TabIndex = 3;
            this.gTextBox1.TextInTextBox = "";
            // 
            // gTextPanel1
            // 
            this.gTextPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gTextPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.gTextPanel1.Location = new System.Drawing.Point(82, 89);
            this.gTextPanel1.Name = "gTextPanel1";
            this.gTextPanel1.Size = new System.Drawing.Size(83, 23);
            this.gTextPanel1.SmallFont = false;
            this.gTextPanel1.TabIndex = 0;
            this.gTextPanel1.TabStop = false;
            this.gTextPanel1.Text = "Gift code";
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonApply.BackColor = System.Drawing.Color.Transparent;
            this.buttonApply.Disamble = true;
            this.buttonApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonApply.Location = new System.Drawing.Point(228, 216);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.SetOrientation = GButton.Orientation.Left;
            this.buttonApply.Size = new System.Drawing.Size(146, 36);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.Click += new System.EventHandler(this.CustomButton1_Click);
            // 
            // FormGiftCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 274);
            this.Controls.Add(this.gTextPanel1);
            this.Controls.Add(this.gTextBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(395, 313);
            this.Name = "FormGiftCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gift code";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
        private GButton buttonCancel;
        private GTextBox gTextBox1;
        private GTextPanel gTextPanel1;
        private GButton buttonApply;
    }
}