namespace rabcrClient {
    partial class FormBadTranslation {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBadTranslation));
            this.customButton2 = new GButton();
            this.customButton1 = new GButton();
            this.gTextPanel1 = new GTextPanel();
            this.gTextPanel2 = new GTextPanel();
            this.gTextPanel3 = new GTextPanel();
            this.xTextboxRight = new GTextBox();
            this.xTextboxWrong = new GTextBox();
            this.gTextBoxWhere = new GTextBox();
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
            this.customButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton2.Location = new System.Drawing.Point(150, 316);
            this.customButton2.Name = "customButton2";
            this.customButton2.SetOrientation = GButton.Orientation.Right;
            this.customButton2.Size = new System.Drawing.Size(87, 36);
            this.customButton2.TabIndex = 3;
            this.customButton2.Text = "Zrušit";
            this.customButton2.Click += new System.EventHandler(this.GButton2_Click);
            // 
            // customButton1
            // 
            this.customButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton1.BackColor = System.Drawing.Color.Transparent;
            this.customButton1.Disamble = false;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton1.Location = new System.Drawing.Point(243, 316);
            this.customButton1.Name = "customButton1";
            this.customButton1.SetOrientation = GButton.Orientation.Left;
            this.customButton1.Size = new System.Drawing.Size(145, 36);
            this.customButton1.TabIndex = 4;
            this.customButton1.Text = "Podtvrdit";
            this.customButton1.Click += new System.EventHandler(this.GButton1_Click);
            // 
            // gTextPanel1
            // 
            this.gTextPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gTextPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.gTextPanel1.Location = new System.Drawing.Point(37, 61);
            this.gTextPanel1.Name = "gTextPanel1";
            this.gTextPanel1.Size = new System.Drawing.Size(321, 23);
            this.gTextPanel1.SmallFont = false;
            this.gTextPanel1.TabIndex = 11;
            this.gTextPanel1.TabStop = false;
            this.gTextPanel1.Text = "Write down what is currently showing";
            // 
            // gTextPanel2
            // 
            this.gTextPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gTextPanel2.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.gTextPanel2.Location = new System.Drawing.Point(37, 141);
            this.gTextPanel2.Name = "gTextPanel2";
            this.gTextPanel2.Size = new System.Drawing.Size(259, 23);
            this.gTextPanel2.SmallFont = false;
            this.gTextPanel2.TabIndex = 11;
            this.gTextPanel2.TabStop = false;
            this.gTextPanel2.Text = "Write down what should show";
            // 
            // gTextPanel3
            // 
            this.gTextPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gTextPanel3.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.gTextPanel3.Location = new System.Drawing.Point(37, 220);
            this.gTextPanel3.Name = "gTextPanel3";
            this.gTextPanel3.Size = new System.Drawing.Size(193, 23);
            this.gTextPanel3.SmallFont = false;
            this.gTextPanel3.TabIndex = 11;
            this.gTextPanel3.TabStop = false;
            this.gTextPanel3.Text = "Write down where is it";
            // 
            // xTextboxRight
            // 
            this.xTextboxRight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.xTextboxRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xTextboxRight.Location = new System.Drawing.Point(37, 170);
            this.xTextboxRight.Name = "xTextboxRight";
            this.xTextboxRight.PlaceHolder = "Singleplayer";
            this.xTextboxRight.Size = new System.Drawing.Size(351, 29);
            this.xTextboxRight.StateSelect = GBounds.StateSelect.Between;
            this.xTextboxRight.TabIndex = 1;
            this.xTextboxRight.TextInTextBox = "";
            // 
            // xTextboxWrong
            // 
            this.xTextboxWrong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.xTextboxWrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xTextboxWrong.Location = new System.Drawing.Point(37, 90);
            this.xTextboxWrong.Name = "xTextboxWrong";
            this.xTextboxWrong.PlaceHolder = "Sngleplayer";
            this.xTextboxWrong.Size = new System.Drawing.Size(351, 29);
            this.xTextboxWrong.StateSelect = GBounds.StateSelect.Between;
            this.xTextboxWrong.TabIndex = 0;
            this.xTextboxWrong.TextInTextBox = "";
            // 
            // gTextBoxWhere
            // 
            this.gTextBoxWhere.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gTextBoxWhere.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gTextBoxWhere.Location = new System.Drawing.Point(37, 249);
            this.gTextBoxWhere.Name = "gTextBoxWhere";
            this.gTextBoxWhere.PlaceHolder = "Button in the menu";
            this.gTextBoxWhere.Size = new System.Drawing.Size(351, 29);
            this.gTextBoxWhere.StateSelect = GBounds.StateSelect.Between;
            this.gTextBoxWhere.TabIndex = 2;
            this.gTextBoxWhere.TextInTextBox = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.textPanel8);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 34);
            this.panel1.TabIndex = 11;
            // 
            // textPanel8
            // 
            this.textPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel8.BackColor = System.Drawing.Color.Transparent;
            this.textPanel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel8.Location = new System.Drawing.Point(115, 6);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(195, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 9;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Report bad translation";
            // 
            // FormBadTranslation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(426, 376);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.gTextPanel3);
            this.Controls.Add(this.gTextPanel2);
            this.Controls.Add(this.gTextBoxWhere);
            this.Controls.Add(this.gTextPanel1);
            this.Controls.Add(this.xTextboxRight);
            this.Controls.Add(this.xTextboxWrong);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(375, 415);
            this.Name = "FormBadTranslation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report bad translation";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

      //  private GTextPanel textPanel1;
      //  private System.Windows.Forms.Panel panel1;
        public GTextBox xTextboxWrong;
        public GTextBox xTextboxRight;
        public GTextBox gTextBoxWhere;
        private GTextPanel gTextPanel1;
        private GTextPanel gTextPanel2;
        private GTextPanel gTextPanel3;
        private GButton customButton1;
        private GButton customButton2;
        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
    }
}