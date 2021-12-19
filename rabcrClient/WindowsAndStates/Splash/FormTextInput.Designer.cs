namespace rabcrClient {
    partial class FormTextInput {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTextInput));
            this.gButton1 = new rabcrClient.GButton();
            this.gTextPanel1 = new rabcrClient.GTextPanel();
            this.gTextBox1 = new rabcrClient.GTextBox();
            this.gButton2 = new rabcrClient.GButton();
            this.gImageButton1 = new GImageButton();
            this.gImageButton2 = new GImageButton();
            this.gImageButton3 = new GImageButton();
            this.gTextPanel2 = new rabcrClient.GTextPanel();
            this.SuspendLayout();
            //
            // gButton1
            //
            this.gButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gButton1.BackColor = System.Drawing.Color.Transparent;
            this.gButton1.Disamble = false;
            this.gButton1.Location = new System.Drawing.Point(448, 122);
            this.gButton1.Name = "gButton1";
            this.gButton1.SetOrientation = rabcrClient.GButton.Orientation.Left;
            this.gButton1.Size = new System.Drawing.Size(99, 36);
            this.gButton1.TabIndex = 0;
            this.gButton1.Text = "Použít";
            this.gButton1.Click += new System.EventHandler(this.GButton1_Click);
            //
            // gTextPanel1
            //
            this.gTextPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanel1.Location = new System.Drawing.Point(17, 16);
            this.gTextPanel1.Name = "gTextPanel1";
            this.gTextPanel1.Size = new System.Drawing.Size(106, 23);
            this.gTextPanel1.TabIndex = 1;
            this.gTextPanel1.TabStop = false;
            this.gTextPanel1.Text = "Zadajte text";
            //
            // gTextBox1
            //
            this.gTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gTextBox1.Location = new System.Drawing.Point(12, 45);
            this.gTextBox1.Name = "gTextBox1";
            this.gTextBox1.Size = new System.Drawing.Size(538, 29);
            this.gTextBox1.StateSelect = rabcrClient.GBounds.StateSelect.Between;
            this.gTextBox1.TabIndex = 2;
            this.gTextBox1.TextInTextBox = "";
            //
            // gButton2
            //
            this.gButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gButton2.BackColor = System.Drawing.Color.Transparent;
            this.gButton2.Disamble = false;
            this.gButton2.Location = new System.Drawing.Point(343, 122);
            this.gButton2.Name = "gButton2";
            this.gButton2.SetOrientation = rabcrClient.GButton.Orientation.Right;
            this.gButton2.Size = new System.Drawing.Size(99, 36);
            this.gButton2.TabIndex = 0;
            this.gButton2.Text = "Zrušit";
            this.gButton2.Click += new System.EventHandler(this.GButton2_Click);
            //
            // gImageButton1
            //
            this.gImageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gImageButton1.Image = null;
            this.gImageButton1.Location = new System.Drawing.Point(27, 116);
            this.gImageButton1.Name = "gImageButton1";
            this.gImageButton1.Size = new System.Drawing.Size(26, 26);
            this.gImageButton1.TabIndex = 3;
            this.gImageButton1.Text = "gImageButton1";
            this.gImageButton1.Click += new System.EventHandler(this.Button3_Click);
            //
            // gImageButton2
            //
            this.gImageButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gImageButton2.Image = null;
            this.gImageButton2.Location = new System.Drawing.Point(59, 116);
            this.gImageButton2.Name = "gImageButton2";
            this.gImageButton2.Size = new System.Drawing.Size(26, 26);
            this.gImageButton2.TabIndex = 3;
            this.gImageButton2.Text = "gImageButton1";
            this.gImageButton2.Click += new System.EventHandler(this.Button1_Click);
            //
            // gImageButton3
            //
            this.gImageButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gImageButton3.Image = null;
            this.gImageButton3.Location = new System.Drawing.Point(91, 116);
            this.gImageButton3.Name = "gImageButton3";
            this.gImageButton3.Size = new System.Drawing.Size(26, 26);
            this.gImageButton3.TabIndex = 3;
            this.gImageButton3.Text = "gImageButton1";
            this.gImageButton3.Click += new System.EventHandler(this.Button2_Click);
            //
            // gTextPanel2
            //
            this.gTextPanel2.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanel2.Location = new System.Drawing.Point(27, 89);
            this.gTextPanel2.Name = "gTextPanel2";
            this.gTextPanel2.Size = new System.Drawing.Size(54, 23);
            this.gTextPanel2.TabIndex = 1;
            this.gTextPanel2.TabStop = false;
            this.gTextPanel2.Text = "Emoji";
            //
            // FormTextInput
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(559, 166);
            this.Controls.Add(this.gImageButton3);
            this.Controls.Add(this.gImageButton2);
            this.Controls.Add(this.gImageButton1);
            this.Controls.Add(this.gTextBox1);
            this.Controls.Add(this.gTextPanel2);
            this.Controls.Add(this.gTextPanel1);
            this.Controls.Add(this.gButton2);
            this.Controls.Add(this.gButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTextInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pole pro zadání textu";
            this.ResumeLayout(false);

        }

        #endregion

        private GButton gButton1;
        private GTextPanel gTextPanel1;
        private GTextBox gTextBox1;
        private GButton gButton2;
        private GImageButton gImageButton1;
        private GImageButton gImageButton2;
        private GImageButton gImageButton3;
        private GTextPanel gTextPanel2;
    }
}