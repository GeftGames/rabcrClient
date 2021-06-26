using System.Windows.Forms;

namespace rabcrClient {
    public partial class Password : Form {

        public string Output;
        public bool Done;

        public Password() {
            InitializeComponent();
            xTextBoxPassword1.textBox.PasswordChar='*';
            xTextBoxPassword2.textBox.PasswordChar='*';
        }

        void TextBox1_TextChanged(object sender, System.EventArgs e) {
            if (xTextBoxPassword1.Text.Length>3 && !xTextBoxPassword1.Text.Contains("|")) xTextBoxPassword1.StateSelect=GBounds.StateSelect.True;
            else xTextBoxPassword1.StateSelect=GBounds.StateSelect.False;

            if (xTextBoxPassword2.Text==xTextBoxPassword1.Text) xTextBoxPassword2.StateSelect=GBounds.StateSelect.True;
            else xTextBoxPassword2.StateSelect=GBounds.StateSelect.False;

            if (xTextBoxPassword1.StateSelect==GBounds.StateSelect.True && xTextBoxPassword2.StateSelect==GBounds.StateSelect.True){
                customButton1.Disamble=false;
            } else customButton1.Disamble=true;
        }

        void TextBox2_TextChanged(object sender, System.EventArgs e) {
            if (xTextBoxPassword2.Text==xTextBoxPassword1.Text) xTextBoxPassword2.StateSelect=GBounds.StateSelect.True;
            else xTextBoxPassword2.StateSelect=GBounds.StateSelect.False;

            if (xTextBoxPassword1.StateSelect==GBounds.StateSelect.True && xTextBoxPassword2.StateSelect==GBounds.StateSelect.True){
                customButton1.Disamble=false;
            } else customButton1.Disamble=true;
        }

        void GButton1_Click(object sender, System.EventArgs e) {
            if (!customButton1.Disamble) {
                Output=xTextBoxPassword1.Text;
                Done=true;
                Hide();
            }
        }

        void GButton2_Click(object sender, System.EventArgs e) {
            Hide();
        }

        void Password_FormClosing(object sender, FormClosingEventArgs e) {
            Hide();
        }
    }
}
