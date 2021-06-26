using System.Net;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormGiftCode: Form {

        public string giftData;
        public bool DropGift;
       
        public FormGiftCode() {
            InitializeComponent();
            DoubleBuffered=true;
            Text=textPanel8.Text=gTextPanel1.Text=Lang.Texts[1476];
            textPanel8.Resize+=TextPanel8_Resize;
            
            gTextBox1.textBox.TextChanged+=TextBox_TextChanged;

            buttonApply.Text=Lang.Texts[58];
            buttonCancel.Text=Lang.Texts[57];
        }

        void TextPanel8_Resize(object sender, System.EventArgs e) {
            textPanel8.Location=new System.Drawing.Point(Width/2-textPanel8.Width/2, textPanel8.Location.Y);
        }

        void TextBox_TextChanged(object sender, System.EventArgs e) {
            buttonApply.Disamble=gTextBox1.textBox.Text.Length<3;
        }

        void CustomButton1_Click(object sender, System.EventArgs e) {
            if (!buttonCancel.Disamble) {

                WebClient wc=new WebClient();
                string result=wc.DownloadString("https://geftgames.ga/RabcrGiftCode.php?code="+gTextBox1.textBox.Text+"&version="+Release.VersionString);

                #if DEBUG
                System.Diagnostics.Debug.WriteLine("Gift result: "+result);
                #endif
                if (result.Length==0) { 
                    MessageBox.Show(Lang.Texts[46]);    
                } else if (result.Contains("|")) { 
                    string[] raw=result.Split('|');
                    switch (raw[0]) { 
                        case "E":
                            if (int.TryParse(raw[1], out int eid)) {
                                switch (eid){ 
                                    case 1:
                                        MessageBox.Show(Lang.Texts[46]); 
                                        break;

                                    case 2:
                                        MessageBox.Show(Lang.Texts[1494]);
                                        break;

                                    case 3:
                                        MessageBox.Show(Lang.Texts[46]); 
                                        break;

                                    case 4:
                                        MessageBox.Show(Lang.Texts[1493]);
                                        break;

                                    case 5:
                                        MessageBox.Show(Lang.Texts[1495]);
                                        break;

                                    default: 
                                        MessageBox.Show(Lang.Texts[46]);
                                        break;
                                }
                            } else MessageBox.Show(Lang.Texts[46]); 
                            break;

                        case "O":
                            MessageBox.Show(Lang.Texts[1492]);  
                            giftData=raw[1];
                            DropGift=true;
                            break;

                        default:
                            MessageBox.Show(Lang.Texts[46]); 
                            break;
                    }
                } else {
                    MessageBox.Show(Lang.Texts[46]);   
                }
            }

            Close();
        }

        void ButtonCancel_Click(object sender, System.EventArgs e) {
            Close();
        }
    }
}