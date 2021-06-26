using System;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class CheckPassword : Form {

        public CheckPassword() {
            InitializeComponent();
            textPanel8.Resize+=TextPanel8_Resize;
            Text=textPanel8.Text=Lang.Texts[76];
            textPanel1.Text=Lang.Texts[246];
            customButton2.Text=Lang.Texts[57];
            customButton1.Text=Lang.Texts[58];
            xTextBoxPassword.textBox.PasswordChar='*';
            xTextBoxPassword.PlaceHolder="********";
        }

        private void TextPanel8_Resize(object sender, EventArgs e) {
         textPanel8.Location=new System.Drawing.Point(Width/2-textPanel8.Width/2,textPanel8.Location.Y);
        }

        public bool done=false;
        public string Output;

        private void TextBox1_TextChanged(object sender, EventArgs e) {
            if (xTextBoxPassword.Text.Length>3 && !xTextBoxPassword.Text.Contains("|")) {
                xTextBoxPassword.StateSelect=GBounds.StateSelect.True;
                customButton1.Disamble=false;
            } else {
                customButton1.Disamble=true;
                xTextBoxPassword.StateSelect=GBounds.StateSelect.False;
            }
        }

        private void GButton1_Click(object sender, EventArgs e) {
            if (!customButton1.Disamble) {
                done=true;
                Output=xTextBoxPassword.Text;
                Hide();
            }
        }

        private void GButton2_Click(object sender, EventArgs e) {
            done=true;
            Hide();
        }
    }
}