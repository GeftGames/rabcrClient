using System;
using System.Threading;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormBadTranslation: Form {
        public bool OK=false;
        public string getdata;

        public FormBadTranslation() {
            InitializeComponent();

            customButton1.Text=Lang.Texts[77];
            customButton2.Text=Lang.Texts[57];
            textPanel8.Text=Text=Lang.Texts[348];

            gTextPanel1.Text=Lang.Texts[349];
            gTextPanel2.Text=Lang.Texts[350];
            gTextPanel3.Text=Lang.Texts[351];

            textPanel8.Resize+=TextPanel8_Resize;
        }

        void TextPanel8_Resize(object sender, System.EventArgs e) => textPanel8.Location=new System.Drawing.Point(Width/2-textPanel8.Width/2, textPanel8.Location.Y);

        void GButton2_Click(object sender, EventArgs e) {
            Close();
        }

        void GButton1_Click(object sender, EventArgs e) {
            if (xTextboxWrong.textBox.Text.Length>0 && xTextboxRight.textBox.Text.Length>0) {
                string send=
                    "?a="+xTextboxWrong.textBox.Text +
                    "&b="+xTextboxRight.textBox.Text +
                    "&c="+gTextBoxWhere.textBox.Text +
                    "&d="+Release.VersionString;

                if (send.Length<700){

                    // Run
                    Thread.Sleep(1000);
                    System.Diagnostics.Process.Start("https://geftgames.ga/rbt.php"+send);
                } else MessageBox.Show(Lang.Texts[352], Lang.Texts[241]);
            } else MessageBox.Show(Lang.Texts[353], Lang.Texts[241]);
            Close();
        }
    }
}