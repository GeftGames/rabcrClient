namespace rabcrClient {
    partial class AddSingleWorld {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSingleWorld));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.news1 = new rabcrClient.GeDoPanel();
            this.bounds2 = new GBounds();
            this.customButton4 = new GButton();
            this.textPanel3 = new GTextPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textPanel4 = new GTextPanel();
            this.gTextPanel1 = new GTextPanel();
            this.textPanel7 = new GTextPanel();
            this.changeButton1 = new GChangeButton();
            this.bar1 = new GBar();
            this.changeButtonStartUpItems = new GChangeButton();
            this.changeButton3 = new GChangeButton();
            this.textPanel6 = new GTextPanel();
            this.customButton6 = new GButton();
            this.bounds3 = new GBounds();
            this.customButton2 = new GButton();
            this.customButton3 = new GButton();
            this.link1 = new GLink();
            this.xTextBoxName = new GTextBox();
            this.textPanel1 = new GTextPanel();
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
            this.panel1.TabIndex = 9;
            // 
            // textPanel8
            // 
            this.textPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel8.BackColor = System.Drawing.Color.Transparent;
            this.textPanel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel8.Location = new System.Drawing.Point(201, 7);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(142, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 9;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Přidat nový svět";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.news1);
            this.panel2.Controls.Add(this.bounds2);
            this.panel2.Controls.Add(this.customButton4);
            this.panel2.Controls.Add(this.textPanel3);
            this.panel2.Location = new System.Drawing.Point(32, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 82);
            this.panel2.TabIndex = 2;
            this.panel2.Visible = false;
            // 
            // news1
            // 
            this.news1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.news1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.news1.Location = new System.Drawing.Point(14, 8);
            this.news1.Name = "news1";
            this.news1.Size = new System.Drawing.Size(436, 28);
            this.news1.TabIndex = 9;
            this.news1.TabStop = false;
            this.news1.Text = "news1";
            // 
            // bounds2
            // 
            this.bounds2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bounds2.BackColor = System.Drawing.Color.Transparent;
            this.bounds2.Location = new System.Drawing.Point(11, 5);
            this.bounds2.Name = "bounds2";
            this.bounds2.Size = new System.Drawing.Size(442, 34);
            this.bounds2.TabIndex = 0;
            this.bounds2.TabStop = false;
            this.bounds2.Text = "bounds1";
            // 
            // customButton4
            // 
            this.customButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customButton4.BackColor = System.Drawing.Color.Transparent;
            this.customButton4.Disamble = false;
            this.customButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.customButton4.Location = new System.Drawing.Point(281, 41);
            this.customButton4.Name = "customButton4";
            this.customButton4.SetOrientation = GButton.Orientation.Center;
            this.customButton4.Size = new System.Drawing.Size(171, 36);
            this.customButton4.TabIndex = 2;
            this.customButton4.Text = "Pomoc s GeDo";
            this.customButton4.Click += new System.EventHandler(this.GButton4_Click);
            // 
            // textPanel3
            // 
            this.textPanel3.BackColor = System.Drawing.Color.Transparent;
            this.textPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel3.ForeColor = System.Drawing.Color.Black;
            this.textPanel3.Location = new System.Drawing.Point(8, 46);
            this.textPanel3.Name = "textPanel3";
            this.textPanel3.Size = new System.Drawing.Size(246, 23);
            this.textPanel3.SmallFont = false;
            this.textPanel3.TabIndex = 9;
            this.textPanel3.TabStop = false;
            this.textPanel3.Text = "Můžete použít GeDo značky";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.Controls.Add(this.textPanel4);
            this.panel3.Controls.Add(this.gTextPanel1);
            this.panel3.Controls.Add(this.textPanel7);
            this.panel3.Controls.Add(this.changeButton1);
            this.panel3.Controls.Add(this.bar1);
            this.panel3.Controls.Add(this.changeButtonStartUpItems);
            this.panel3.Controls.Add(this.changeButton3);
            this.panel3.Controls.Add(this.textPanel6);
            this.panel3.Controls.Add(this.customButton6);
            this.panel3.Controls.Add(this.bounds3);
            this.panel3.Location = new System.Drawing.Point(40, 164);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(447, 223);
            this.panel3.TabIndex = 3;
            // 
            // textPanel4
            // 
            this.textPanel4.BackColor = System.Drawing.Color.Transparent;
            this.textPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel4.Location = new System.Drawing.Point(6, 44);
            this.textPanel4.Name = "textPanel4";
            this.textPanel4.Size = new System.Drawing.Size(164, 23);
            this.textPanel4.SmallFont = false;
            this.textPanel4.TabIndex = 0;
            this.textPanel4.TabStop = false;
            this.textPanel4.Text = "Obtížnost ve světě";
            // 
            // gTextPanel1
            // 
            this.gTextPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gTextPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.gTextPanel1.Location = new System.Drawing.Point(6, 119);
            this.gTextPanel1.Name = "gTextPanel1";
            this.gTextPanel1.Size = new System.Drawing.Size(170, 23);
            this.gTextPanel1.SmallFont = false;
            this.gTextPanel1.TabIndex = 0;
            this.gTextPanel1.TabStop = false;
            this.gTextPanel1.Text = "Začátečnické itemy";
            // 
            // textPanel7
            // 
            this.textPanel7.BackColor = System.Drawing.Color.Transparent;
            this.textPanel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel7.Location = new System.Drawing.Point(6, 80);
            this.textPanel7.Name = "textPanel7";
            this.textPanel7.Size = new System.Drawing.Size(124, 23);
            this.textPanel7.SmallFont = false;
            this.textPanel7.TabIndex = 0;
            this.textPanel7.TabStop = false;
            this.textPanel7.Text = "Velikost světa";
            // 
            // changeButton1
            // 
            this.changeButton1.BackColor = System.Drawing.Color.Transparent;
            this.changeButton1.Disamble = false;
            this.changeButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeButton1.List = new string[] {
        "Realistická",
        "Výzkum",
        "Kreativní"};
            this.changeButton1.Location = new System.Drawing.Point(277, 32);
            this.changeButton1.Name = "changeButton1";
            this.changeButton1.Selected = 0;
            this.changeButton1.Size = new System.Drawing.Size(167, 35);
            this.changeButton1.TabIndex = 3;
            this.changeButton1.Text = "changeButton1";
            // 
            // bar1
            // 
            this.bar1.Location = new System.Drawing.Point(5, 179);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(436, 22);
            this.bar1.TabIndex = 9;
            this.bar1.TabStop = false;
            this.bar1.Value = 0F;
            this.bar1.Visible = false;
            // 
            // changeButtonStartUpItems
            // 
            this.changeButtonStartUpItems.BackColor = System.Drawing.Color.Transparent;
            this.changeButtonStartUpItems.Disamble = false;
            this.changeButtonStartUpItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeButtonStartUpItems.List = new string[] {
        "Žádné",
        "Základní",
        "Rozšířené",
        "Pokročilé"};
            this.changeButtonStartUpItems.Location = new System.Drawing.Point(278, 114);
            this.changeButtonStartUpItems.Name = "changeButtonStartUpItems";
            this.changeButtonStartUpItems.Selected = 0;
            this.changeButtonStartUpItems.Size = new System.Drawing.Size(167, 35);
            this.changeButtonStartUpItems.TabIndex = 5;
            // 
            // changeButton3
            // 
            this.changeButton3.BackColor = System.Drawing.Color.Transparent;
            this.changeButton3.Disamble = false;
            this.changeButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.changeButton3.List = new string[] {
        "Malý",
        "Střední",
        "Velký"};
            this.changeButton3.Location = new System.Drawing.Point(277, 73);
            this.changeButton3.Name = "changeButton3";
            this.changeButton3.Selected = 1;
            this.changeButton3.Size = new System.Drawing.Size(167, 35);
            this.changeButton3.TabIndex = 5;
            this.changeButton3.Text = "changeButton1";
            // 
            // textPanel6
            // 
            this.textPanel6.BackColor = System.Drawing.Color.Transparent;
            this.textPanel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel6.Location = new System.Drawing.Point(4, 153);
            this.textPanel6.Name = "textPanel6";
            this.textPanel6.Size = new System.Drawing.Size(66, 23);
            this.textPanel6.SmallFont = false;
            this.textPanel6.TabIndex = 9;
            this.textPanel6.TabStop = false;
            this.textPanel6.Text = "Proces";
            this.textPanel6.Visible = false;
            // 
            // customButton6
            // 
            this.customButton6.BackColor = System.Drawing.Color.Transparent;
            this.customButton6.Disamble = false;
            this.customButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.customButton6.Location = new System.Drawing.Point(128, 166);
            this.customButton6.Name = "customButton6";
            this.customButton6.SetOrientation = GButton.Orientation.Center;
            this.customButton6.Size = new System.Drawing.Size(216, 36);
            this.customButton6.TabIndex = 6;
            this.customButton6.Text = "Načíst svět ze souboru";
            this.customButton6.Click += new System.EventHandler(this.GButton6_Click);
            // 
            // bounds3
            // 
            this.bounds3.BackColor = System.Drawing.Color.Transparent;
            this.bounds3.Location = new System.Drawing.Point(2, 176);
            this.bounds3.Name = "bounds3";
            this.bounds3.Size = new System.Drawing.Size(442, 28);
            this.bounds3.TabIndex = 9;
            this.bounds3.TabStop = false;
            this.bounds3.Text = "bounds1";
            this.bounds3.Visible = false;
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
            this.customButton2.TabIndex = 7;
            this.customButton2.Text = "Zrušit";
            this.customButton2.Click += new System.EventHandler(this.GButton2_Click);
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
            this.customButton3.TabIndex = 8;
            this.customButton3.Text = "Vytvořit";
            this.customButton3.Click += new System.EventHandler(this.GButton3_Click);
            // 
            // link1
            // 
            this.link1.BackColor = System.Drawing.Color.Transparent;
            this.link1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline);
            this.link1.Location = new System.Drawing.Point(40, 129);
            this.link1.Name = "link1";
            this.link1.Size = new System.Drawing.Size(138, 23);
            this.link1.TabIndex = 1;
            this.link1.Text = "Zobrazit náhled";
            this.link1.Click += new System.EventHandler(this.Link1_Click);
            // 
            // xTextBoxName
            // 
            this.xTextBoxName.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.textPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel1.BackColor = System.Drawing.Color.Transparent;
            this.textPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanel1.Location = new System.Drawing.Point(40, 60);
            this.textPanel1.Name = "textPanel1";
            this.textPanel1.Size = new System.Drawing.Size(111, 23);
            this.textPanel1.SmallFont = false;
            this.textPanel1.TabIndex = 9;
            this.textPanel1.TabStop = false;
            this.textPanel1.Text = "Název světa";
            // 
            // AddSingleWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(530, 439);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton3);
            this.Controls.Add(this.link1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xTextBoxName);
            this.Controls.Add(this.textPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddSingleWorld";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Přidat nový svět";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
      // private GButton customButton1;
        private GButton customButton2;
        private GButton customButton3;
        private GTextPanel textPanel1;
        private GBounds bounds2;
        private GButton customButton4;
        private GTextPanel textPanel3;
        private GTextPanel textPanel4;
        private GChangeButton changeButton1;
        public GeDoPanel news1;
        private GButton customButton6;
        private GBar bar1;
        private GTextPanel textPanel6;
        private GBounds bounds3;
        private System.Windows.Forms.Timer timer1;
        private GTextPanel textPanel7;
        private GChangeButton changeButton3;
        private GTextBox xTextBoxName;
        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
        private System.Windows.Forms.Panel panel2;
        private GLink link1;
        private System.Windows.Forms.Panel panel3;
        private GTextPanel gTextPanel1;
        private GChangeButton changeButtonStartUpItems;
    }
}