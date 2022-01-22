namespace rabcrClient {
    partial class EditSingleWorld {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSingleWorld));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.news2 = new rabcrClient.GeDoPanel();
            this.bounds1 = new GBounds();
            this.customButton1 = new GButton();
            this.textPanel6 = new GTextPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.customButton5 = new GButton();
            this.textPanel7 = new GTextPanel();
            this.textPanel2 = new GTextPanel();
            this.textPanel5 = new GTextPanel();
            this.bar1 = new GBar();
            this.customButton7 = new GButton();
            this.bounds3 = new GBounds();
            this.customButton6 = new GButton();
            this.textPanel4 = new GTextPanel();
            this.link1 = new GLink();
            this.xTextBoxName = new GTextBox();
            this.textPanel1 = new GTextPanel();
            this.customButton3 = new GButton();
            this.customButton2 = new GButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            //
            // timer1
            //
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            //
            // panel1
            //
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.textPanel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 34);
            this.panel1.TabIndex = 10;
            //
            // textPanel8
            //
            this.textPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel8.BackColor = System.Drawing.Color.Transparent;
            this.textPanel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel8.Location = new System.Drawing.Point(201, 7);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(107, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 9;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Upravit svět";
            //
            // panel2
            //
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.news2);
            this.panel2.Controls.Add(this.bounds1);
            this.panel2.Controls.Add(this.customButton1);
            this.panel2.Controls.Add(this.textPanel6);
            this.panel2.Location = new System.Drawing.Point(33, 158);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 82);
            this.panel2.TabIndex = 2;
            this.panel2.Visible = false;
            //
            // news2
            //
            this.news2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.news2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.news2.Location = new System.Drawing.Point(14, 8);
            this.news2.Name = "news2";
            this.news2.Size = new System.Drawing.Size(436, 30);
            this.news2.TabIndex = 9;
            this.news2.TabStop = false;
            this.news2.Text = "news2";
            //
            // bounds1
            //
            this.bounds1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bounds1.BackColor = System.Drawing.Color.Transparent;
            this.bounds1.Location = new System.Drawing.Point(11, 5);
            this.bounds1.Name = "bounds1";
            this.bounds1.Size = new System.Drawing.Size(442, 36);
            this.bounds1.TabIndex = 0;
            this.bounds1.TabStop = false;
            this.bounds1.Text = "bounds1";
            //
            // customButton1
            //
            this.customButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customButton1.BackColor = System.Drawing.Color.Transparent;
            this.customButton1.Disamble = false;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton1.Location = new System.Drawing.Point(281, 43);
            this.customButton1.Name = "customButton1";
            this.customButton1.SetOrientation = GButton.Orientation.Center;
            this.customButton1.Size = new System.Drawing.Size(171, 36);
            this.customButton1.TabIndex = 2;
            this.customButton1.Text = "Pomoc s GeDo";
            this.customButton1.Click += new System.EventHandler(this.GButton1_Click);
            //
            // textPanel6
            //
            this.textPanel6.BackColor = System.Drawing.Color.Transparent;
            this.textPanel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel6.ForeColor = System.Drawing.Color.Black;
            this.textPanel6.Location = new System.Drawing.Point(8, 48);
            this.textPanel6.Name = "textPanel6";
            this.textPanel6.Size = new System.Drawing.Size(246, 23);
            this.textPanel6.SmallFont = false;
            this.textPanel6.TabIndex = 9;
            this.textPanel6.TabStop = false;
            this.textPanel6.Text = "Můžete použít GeDo značky";
            //
            // panel3
            //
            this.panel3.Controls.Add(this.customButton5);
            this.panel3.Controls.Add(this.textPanel7);
            this.panel3.Controls.Add(this.textPanel2);
            this.panel3.Controls.Add(this.textPanel5);
            this.panel3.Controls.Add(this.bar1);
            this.panel3.Controls.Add(this.customButton7);
            this.panel3.Controls.Add(this.bounds3);
            this.panel3.Controls.Add(this.customButton6);
            this.panel3.Controls.Add(this.textPanel4);
            this.panel3.Location = new System.Drawing.Point(40, 169);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 222);
            this.panel3.TabIndex = 3;
            //
            // customButton5
            //
            this.customButton5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton5.BackColor = System.Drawing.Color.Transparent;
            this.customButton5.Disamble = false;
            this.customButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton5.Location = new System.Drawing.Point(298, 80);
            this.customButton5.Name = "customButton5";
            this.customButton5.SetOrientation = GButton.Orientation.Center;
            this.customButton5.Size = new System.Drawing.Size(149, 36);
            this.customButton5.TabIndex = 4;
            this.customButton5.Text = "Smazat";
            this.customButton5.Click += new System.EventHandler(this.GButton5_Click);
            //
            // textPanel7
            //
            this.textPanel7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel7.BackColor = System.Drawing.Color.Transparent;
            this.textPanel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textPanel7.Location = new System.Drawing.Point(0, 85);
            this.textPanel7.Name = "textPanel7";
            this.textPanel7.Size = new System.Drawing.Size(111, 23);
            this.textPanel7.SmallFont = false;
            this.textPanel7.TabIndex = 0;
            this.textPanel7.TabStop = false;
            this.textPanel7.Text = "Smazat svět";
            //
            // textPanel2
            //
            this.textPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel2.BackColor = System.Drawing.Color.Transparent;
            this.textPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textPanel2.Location = new System.Drawing.Point(0, 37);
            this.textPanel2.Name = "textPanel2";
            this.textPanel2.Size = new System.Drawing.Size(107, 23);
            this.textPanel2.SmallFont = false;
            this.textPanel2.TabIndex = 0;
            this.textPanel2.TabStop = false;
            this.textPanel2.Text = "Vyčistit svět";
            //
            // textPanel5
            //
            this.textPanel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel5.BackColor = System.Drawing.Color.Transparent;
            this.textPanel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textPanel5.Location = new System.Drawing.Point(0, 131);
            this.textPanel5.Name = "textPanel5";
            this.textPanel5.Size = new System.Drawing.Size(98, 23);
            this.textPanel5.SmallFont = false;
            this.textPanel5.TabIndex = 0;
            this.textPanel5.TabStop = false;
            this.textPanel5.Text = "Exportovat";
            //
            // bar1
            //
            this.bar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bar1.Location = new System.Drawing.Point(7, 188);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(428, 22);
            this.bar1.TabIndex = 0;
            this.bar1.TabStop = false;
            this.bar1.Value = 0F;
            this.bar1.Visible = false;
            //
            // customButton7
            //
            this.customButton7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.customButton7.BackColor = System.Drawing.Color.Transparent;
            this.customButton7.Disamble = false;
            this.customButton7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton7.Location = new System.Drawing.Point(298, 124);
            this.customButton7.Name = "customButton7";
            this.customButton7.SetOrientation = GButton.Orientation.Center;
            this.customButton7.Size = new System.Drawing.Size(149, 36);
            this.customButton7.TabIndex = 5;
            this.customButton7.Text = "Exportovat";
            this.customButton7.Click += new System.EventHandler(this.GButton7_Click);
            //
            // bounds3
            //
            this.bounds3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bounds3.BackColor = System.Drawing.Color.Transparent;
            this.bounds3.Location = new System.Drawing.Point(4, 185);
            this.bounds3.Name = "bounds3";
            this.bounds3.Size = new System.Drawing.Size(434, 28);
            this.bounds3.TabIndex = 0;
            this.bounds3.TabStop = false;
            this.bounds3.Text = "bounds1";
            this.bounds3.Visible = false;
            //
            // customButton6
            //
            this.customButton6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton6.BackColor = System.Drawing.Color.Transparent;
            this.customButton6.Disamble = false;
            this.customButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton6.Location = new System.Drawing.Point(298, 35);
            this.customButton6.Name = "customButton6";
            this.customButton6.SetOrientation = GButton.Orientation.Center;
            this.customButton6.Size = new System.Drawing.Size(149, 36);
            this.customButton6.TabIndex = 3;
            this.customButton6.Text = "Vyčistit";
            this.customButton6.Click += new System.EventHandler(this.GButton6_Click);
            //
            // textPanel4
            //
            this.textPanel4.BackColor = System.Drawing.Color.Transparent;
            this.textPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel4.Location = new System.Drawing.Point(1, 160);
            this.textPanel4.Name = "textPanel4";
            this.textPanel4.Size = new System.Drawing.Size(66, 23);
            this.textPanel4.SmallFont = false;
            this.textPanel4.TabIndex = 0;
            this.textPanel4.TabStop = false;
            this.textPanel4.Text = "Proces";
            this.textPanel4.Visible = false;
            //
            // link1
            //
            this.link1.BackColor = System.Drawing.Color.Transparent;
            this.link1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline);
            this.link1.Location = new System.Drawing.Point(40, 132);
            this.link1.Name = "link1";
            this.link1.Size = new System.Drawing.Size(138, 23);
            this.link1.TabIndex = 1;
            this.link1.Text = "Zobrazit náhled";
            this.link1.Click += new System.EventHandler(this.Link1_Click);
            //
            // xTextBoxName
            //
            this.xTextBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.xTextBoxName.Location = new System.Drawing.Point(40, 89);
            this.xTextBoxName.Name = "xTextBoxName";
            this.xTextBoxName.PlaceHolder = null;
            this.xTextBoxName.Size = new System.Drawing.Size(447, 29);
            this.xTextBoxName.StateSelect = GBounds.StateSelect.Between;
            this.xTextBoxName.TabIndex = 0;
            this.xTextBoxName.TextInTextBox = "";
            //
            // textPanel1
            //
            this.textPanel1.BackColor = System.Drawing.Color.Transparent;
            this.textPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel1.Location = new System.Drawing.Point(40, 60);
            this.textPanel1.Name = "textPanel1";
            this.textPanel1.Size = new System.Drawing.Size(111, 23);
            this.textPanel1.SmallFont = false;
            this.textPanel1.TabIndex = 4;
            this.textPanel1.TabStop = false;
            this.textPanel1.Text = "Název světa";
            //
            // customButton3
            //
            this.customButton3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton3.BackColor = System.Drawing.Color.Transparent;
            this.customButton3.Disamble = false;
            this.customButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton3.Location = new System.Drawing.Point(270, 392);
            this.customButton3.Name = "customButton3";
            this.customButton3.SetOrientation = GButton.Orientation.Left;
            this.customButton3.Size = new System.Drawing.Size(149, 36);
            this.customButton3.TabIndex = 7;
            this.customButton3.Text = "Použít";
            this.customButton3.Click += new System.EventHandler(this.GButton3_Click);
            //
            // customButton2
            //
            this.customButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.customButton2.BackColor = System.Drawing.Color.Transparent;
            this.customButton2.Disamble = false;
            this.customButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton2.Location = new System.Drawing.Point(115, 392);
            this.customButton2.Name = "customButton2";
            this.customButton2.SetOrientation = GButton.Orientation.Right;
            this.customButton2.Size = new System.Drawing.Size(149, 36);
            this.customButton2.TabIndex = 6;
            this.customButton2.Text = "Zrušit";
            this.customButton2.Click += new System.EventHandler(this.GButton2_Click);
            //
            // EditSingleWorld
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(530, 440);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.link1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xTextBoxName);
            this.Controls.Add(this.textPanel1);
            this.Controls.Add(this.customButton3);
            this.Controls.Add(this.customButton2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditSingleWorld";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upravit svět";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
      //  private GButton customButton1;
        private GButton customButton2;
        private GButton customButton3;
        private GTextPanel textPanel1;
        private GButton customButton5;
        private GButton customButton6;
        private GBar bar1;
        private GBounds bounds3;
        private GTextPanel textPanel4;
        private System.Windows.Forms.Timer timer1;
        private GButton customButton7;
        private GTextPanel textPanel5;
        private GTextBox xTextBoxName;
        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
        private GLink link1;
        private System.Windows.Forms.Panel panel2;
        public GeDoPanel news2;
        private GBounds bounds1;
        private GButton customButton1;
        private GTextPanel textPanel6;
        private System.Windows.Forms.Panel panel3;
        private GTextPanel textPanel7;
        private GTextPanel textPanel2;
    }
}