using System;
using System.Reflection;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class LanguageInfo : Form {

        //public string Output1, OutputIp, OutputPort;
        //public bool ReturnSmt;

        private void GButton2_Click(object sender, EventArgs e) {
            Close();
        }

        private void SelectLanguage_Shown(object sender, EventArgs e) {
            Invalidate();
        }

        public LanguageInfo(string text) {
            InitializeComponent();
            Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            textPanel8.Resize+=TextPanel8_Resize;
            Text=textPanel8.Text=Lang.Texts[231];
                        //userControlLangs1.SetUp();
            //xTextbox1.textBox.Text="Nový server";
            gTextPanelText.Text=text;
        }

        private void TextPanel8_Resize(object sender, EventArgs e) {
              textPanel8.Location=new System.Drawing.Point(Width/2-textPanel8.Width/2,textPanel8.Location.Y);
        }

        private void GButton3_Click(object sender, EventArgs e) {
            //if (xTextBoxIp.textBox.Text=="") xTextBoxIp.textBox.Text=xTextBoxIp.PlaceHolder;
            //if (xTextBoxName.textBox.Text=="") xTextBoxName.textBox.Text=xTextBoxName.PlaceHolder;
            //Output1=xTextBoxName.textBox.Text;
            //try {        
            //    if (xTextBoxIp.textBox.Text.Contains(":")) {
            //         OutputIp=xTextBoxIp.textBox.Text.Substring(0,xTextBoxIp.textBox.Text.IndexOf(":"));
            //         OutputPort=xTextBoxIp.textBox.Text.Substring(xTextBoxIp.textBox.Text.IndexOf(":")+1);
            //    } else {
            //        OutputIp=xTextBoxIp.textBox.Text;
            //        OutputPort="";
            //    } 
            //    ReturnSmt=true;
            //    Close();
            //} catch { MessageBox.Show("Zkontolujte zápis adresy serveru.","Chybný zápis adresy");}
            Close();

        }
    }
}
