namespace rabcrClient {
    partial class GTextBox {
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
                if (timer.Enabled)timer.Stop();
                timer?.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.textBox = new GPreTextBox();
            this.bounds = new GBounds();
            this.SuspendLayout();
            //
            // textBox
            //
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox.Location = new System.Drawing.Point(3, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(220, 25);
            this.textBox.TabIndex = 4;
            //
            // bounds
            //
            this.bounds.BackColor = System.Drawing.Color.Transparent;
            this.bounds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bounds.Location = new System.Drawing.Point(0, 0);
            this.bounds.Name = "bounds";
            this.bounds.Size = new System.Drawing.Size(227, 30);
            this.bounds.TabIndex = 3;
            this.bounds.TabStop = false;
            //
            // GTextBox
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.bounds);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "GTextBox";
            this.Size = new System.Drawing.Size(227, 30);
            this.Move += new System.EventHandler(this.AdvancedTextbox_Resize);
            this.Resize += new System.EventHandler(this.AdvancedTextbox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public GPreTextBox textBox;
        public GBounds bounds;
    }
}
