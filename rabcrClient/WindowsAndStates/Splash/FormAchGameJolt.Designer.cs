namespace rabcrClient {
    partial class FormAchGameJolt {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAchGameJolt));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPanel8 = new GTextPanel();
            this.buttonCancel = new GButton();
            this.textBoxNick = new GTextBox();
            this.textPanelNick = new GTextPanel();
            this.textBoxToken = new GTextBox();
            this.textPanelToken = new GTextPanel();
            this.buttonSubmit = new GButton();
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
            this.textPanel8.Location = new System.Drawing.Point(84, 8);
            this.textPanel8.Name = "textPanel8";
            this.textPanel8.Size = new System.Drawing.Size(267, 23);
            this.textPanel8.SmallFont = false;
            this.textPanel8.TabIndex = 0;
            this.textPanel8.TabStop = false;
            this.textPanel8.Text = "Share stone age acheavement";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonCancel.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancel.Disamble = false;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(76, 272);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.SetOrientation = GButton.Orientation.Right;
            this.buttonCancel.Size = new System.Drawing.Size(146, 36);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // textBoxNick
            // 
            this.textBoxNick.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxNick.Location = new System.Drawing.Point(84, 118);
            this.textBoxNick.Name = "textBoxNick";
            this.textBoxNick.PlaceHolder = null;
            this.textBoxNick.Size = new System.Drawing.Size(286, 29);
            this.textBoxNick.StateSelect = GBounds.StateSelect.Between;
            this.textBoxNick.TabIndex = 3;
            this.textBoxNick.TextInTextBox = "";
            // 
            // textPanelNick
            // 
            this.textPanelNick.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textPanelNick.BackColor = System.Drawing.Color.Transparent;
            this.textPanelNick.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanelNick.Location = new System.Drawing.Point(84, 89);
            this.textPanelNick.Name = "textPanelNick";
            this.textPanelNick.Size = new System.Drawing.Size(136, 23);
            this.textPanelNick.SmallFont = false;
            this.textPanelNick.TabIndex = 0;
            this.textPanelNick.TabStop = false;
            this.textPanelNick.Text = "Game Jolt Nick";
            // 
            // textBoxToken
            // 
            this.textBoxToken.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxToken.Location = new System.Drawing.Point(84, 194);
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.PlaceHolder = null;
            this.textBoxToken.Size = new System.Drawing.Size(286, 29);
            this.textBoxToken.StateSelect = GBounds.StateSelect.Between;
            this.textBoxToken.TabIndex = 3;
            this.textBoxToken.TextInTextBox = "";
            // 
            // textPanelToken
            // 
            this.textPanelToken.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textPanelToken.BackColor = System.Drawing.Color.Transparent;
            this.textPanelToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textPanelToken.Location = new System.Drawing.Point(84, 165);
            this.textPanelToken.Name = "textPanelToken";
            this.textPanelToken.Size = new System.Drawing.Size(152, 23);
            this.textPanelToken.SmallFont = false;
            this.textPanelToken.TabIndex = 0;
            this.textPanelToken.TabStop = false;
            this.textPanelToken.Text = "Game Jolt Token";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSubmit.BackColor = System.Drawing.Color.Transparent;
            this.buttonSubmit.Disamble = true;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSubmit.Location = new System.Drawing.Point(228, 272);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.SetOrientation = GButton.Orientation.Left;
            this.buttonSubmit.Size = new System.Drawing.Size(146, 36);
            this.buttonSubmit.TabIndex = 2;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.Click += new System.EventHandler(this.CustomButton1_Click);
            // 
            // FormAchGameJolt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 330);
            this.Controls.Add(this.textPanelToken);
            this.Controls.Add(this.textBoxToken);
            this.Controls.Add(this.textPanelNick);
            this.Controls.Add(this.textBoxNick);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(395, 313);
            this.Name = "FormAchGameJolt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Share acheavements";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GTextPanel textPanel8;
        private GButton buttonCancel;
        private GTextBox textBoxNick;
        private GTextPanel textPanelNick;
        private GTextBox textBoxToken;
        private GTextPanel textPanelToken;
        private GButton buttonSubmit;
    }
}