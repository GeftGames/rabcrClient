using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormAchDetail: Form {

        public bool setted=false;
        public bool Done;
        public string More, NameText;
        public int Level;

        public FormAchDetail(string name, bool done, string more, int level) {
            InitializeComponent();
            DoubleBuffered=true;
            gTextPanel2.Text=NameText=name;
            buttonShare.Disamble=!(Done=done);
            gTextPanel1.Text=More=more;
            textPanel8.Text=Text=Lang.Texts[1487];
            Level=level;
            buttonClose.Text=Lang.Texts[1498];
            buttonShare.Text=Lang.Texts[1491];
            gTextPanel3.Text= done ? Lang.Texts[1496] : Lang.Texts[1497];

            textPanel8.Resize+=TextPanel8_Resize;
        }

        private void TextPanel8_Resize(object sender, System.EventArgs e) {
            textPanel8.Location=new System.Drawing.Point(Width/2-textPanel8.Width/2, textPanel8.Location.Y);
        }

        private void ButtonShare_Click(object sender, System.EventArgs e) {
            if (!buttonShare.Disamble) { 
                using (FormAchGameJolt fagj=new FormAchGameJolt(Level,NameText)) { 
                    fagj.ShowDialog();
                }
            }
        }

        void ButtonClose_Click(object sender, System.EventArgs e) {
            Close();
        }
    }
}