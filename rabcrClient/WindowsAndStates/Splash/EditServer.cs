using System.Windows.Forms;

namespace rabcrClient {
    public partial class EditServer : Form {

        public string Output1, OutputIp, OutputPort;
        public bool ReturnSmt;
        public bool Remove;

        public EditServer(string name, string ip) {
            InitializeComponent();
            textPanel8.Resize+=TextPanel8_Resize;
            Text=textPanel8.Text=Lang.Texts[244];
            textPanel1.Text=Lang.Texts[55];
            textPanel4.Text=Lang.Texts[56];
            textPanel2.Text=Lang.Texts[245];
            customButton1.Text=Lang.Texts[193];
            customButton2.Text=Lang.Texts[57];
            customButton3.Text=Lang.Texts[58];
            xTextBoxName.textBox.Text=name;
            xTextBoxName.PlaceHolder=name;
            xTextBoxIp.textBox.Text=ip;
            xTextBoxIp.PlaceHolder=ip;
        }

        private void TextPanel8_Resize(object sender, System.EventArgs e) {
            textPanel8.Location=new System.Drawing.Point(Width/2-textPanel8.Width/2,textPanel8.Location.Y);
        }

        void GButton3_Click(object sender, System.EventArgs e) {
            if (xTextBoxIp.textBox.Text=="") xTextBoxIp.textBox.Text=xTextBoxIp.PlaceHolder;
            if (xTextBoxName.textBox.Text=="") xTextBoxName.textBox.Text=xTextBoxName.PlaceHolder;

             Output1=xTextBoxName.textBox.Text;

            try {
                if (xTextBoxIp.textBox.Text.Contains(":")) {
                     OutputIp=xTextBoxIp.textBox.Text.Substring(0,xTextBoxIp.textBox.Text.IndexOf(":"));
                     OutputPort=xTextBoxIp.textBox.Text.Substring(xTextBoxIp.textBox.Text.IndexOf(":")+1);
                } else {
                    OutputIp=xTextBoxIp.textBox.Text;
                    OutputPort="";
                }
                ReturnSmt=true;
            } catch { MessageBox.Show("Zkontolujte zápis adresy serveru.","Chybný zápis adresy");}
            Close();
        }

        void GButton2_Click(object sender, System.EventArgs e) {
            Close();
        }

        void GButton1_Click(object sender, System.EventArgs e) {
            ReturnSmt=true;
            Remove=true;
            Close();
        }
    }
}
