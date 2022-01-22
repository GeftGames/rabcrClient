using System.Drawing;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormAch: Form {

        public FormAch(bool ach0, bool ach1, bool ach2, bool ach3) {
            InitializeComponent();

            achievmentControl0.Text=Lang.Texts[1479];
            achievmentControl0.Done=ach0;

            achievmentControl1.Text=Lang.Texts[1481];
            achievmentControl1.Done=ach1;

            achievmentControl2.Text=Lang.Texts[1483];
            achievmentControl2.Done=ach2;

            achievmentControl3.Text=Lang.Texts[1485];
            achievmentControl3.Done=ach3;

            DoubleBuffered=true;
            buttonClose.Text=Lang.Texts[1498];
            Text=textPanel8.Text=Lang.Texts[1477];
            textPanel8.Resize+=TextPanel8_Resize;
        }

        void TextPanel8_Resize(object sender, System.EventArgs e) {
            textPanel8.Location=new Point(Width/2-textPanel8.Width/2, textPanel8.Location.Y);
        }

        void CustomButton1_Click(object sender, System.EventArgs e) {
            Close();
        }

        void AchievmentControl0_Click(object sender, System.EventArgs e) {
            using (FormAchDetail fad=new FormAchDetail(achievmentControl0.Text,achievmentControl0.Done,Lang.Texts[1480],0)) {
                fad.ShowDialog();
            }
        }

        void AchievmentControl1_Click(object sender, System.EventArgs e) {
            using (FormAchDetail fad=new FormAchDetail(achievmentControl1.Text,achievmentControl1.Done, Lang.Texts[1482],1)) {
                fad.ShowDialog();
            }
        }

        void achievmentControl2_Click(object sender, System.EventArgs e) {
            using (FormAchDetail fad=new FormAchDetail(achievmentControl2.Text,achievmentControl2.Done, Lang.Texts[1484],2)) {
                fad.ShowDialog();
            }
        }

        void AchievmentControl3_Click(object sender, System.EventArgs e) {
            using (FormAchDetail fad=new FormAchDetail(achievmentControl3.Text,achievmentControl3.Done, Lang.Texts[1486],3)) {
                fad.ShowDialog();
            }
        }
    }
}