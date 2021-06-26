using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormAchGameJolt: Form {

        readonly int Level;

        public FormAchGameJolt(int level, string name) {
            InitializeComponent();
            Level=level;
            DoubleBuffered=true;
            textBoxNick.textBox.TextChanged+=TextBox_TextChanged;
            textBoxToken.textBox.TextChanged+=TextBox_TextChanged1;  
            textPanel8.Text=Text=name;
            textPanelNick.Text=Lang.Texts[1488];
            textPanelToken.Text=Lang.Texts[1489];
            buttonSubmit.Text=Lang.Texts[1490];
            buttonCancel.Text=Lang.Texts[57];

            textPanel8.Resize+=TextPanel8_Resize;
        }

        void TextPanel8_Resize(object sender, System.EventArgs e) => textPanel8.Location=new System.Drawing.Point(Width/2-textPanel8.Width/2, textPanel8.Location.Y);

        void TextBox_TextChanged1(object sender, System.EventArgs e) => buttonSubmit.Disamble=textBoxNick.textBox.Text.Length<3 || textBoxToken.textBox.Text.Length<3; 

        void TextBox_TextChanged(object sender, System.EventArgs e) => buttonSubmit.Disamble=textBoxNick.textBox.Text.Length<3 || textBoxToken.textBox.Text.Length<3; 
 
        void CustomButton1_Click(object sender, System.EventArgs e) {
            if (!buttonCancel.Disamble) {
                WebClient wc = new WebClient();

                // Agains dissasemblers, useless code
                string secretKey="4k5s4df5g696sfdg4l65sk92f";
                secretKey="url"+secretKey.Substring(1,9);
                secretKey="";

                switch (Level) { 

                    // Bronze
                    case 0:
                        {
                            string url="https://geftgames.ga/rabcrGameJoltSignature.php?username="+textBoxNick.textBox.Text+"&token="+textBoxToken.textBox.Text+"&id=134205&version="+Release.VersionString+secretKey;
                            string get = wc.DownloadString(url);

                            if (get=="SUCCESS") { 
                                MessageBox.Show(Lang.Texts[1499]);
                            } else { 
                                MessageBox.Show(Lang.Texts[1500],Lang.Texts[46]);
                            }

                            #if DEBUG
                            Debug.WriteLine("Send: "+url);
                            Debug.WriteLine("Get: "+get);
                            #endif
                        }
                        break;

                    // Silver
                    case 1:
                        {
                            string url="https://geftgames.ga/rabcrGameJoltSignature.php?username="+textBoxNick.textBox.Text+"&token="+textBoxToken.textBox.Text+"&id=13407&version="+Release.VersionString+secretKey;
                            string get = wc.DownloadString(url);

                            if (get=="SUCCESS") { 
                                MessageBox.Show(Lang.Texts[1499]);
                            } else { 
                                MessageBox.Show(Lang.Texts[1500],Lang.Texts[46]);
                            }

                            #if DEBUG
                            Debug.WriteLine("Send: "+url);
                            Debug.WriteLine("Get: "+get);
                            #endif
                        }
                        break;

                    // Gold
                    case 2:
                        {
                            string url="https://geftgames.ga/rabcrGameJoltSignature.php?username="+textBoxNick.textBox.Text+"&token="+textBoxToken.textBox.Text+"&id=134208&version="+Release.VersionString+secretKey;
                            string get = wc.DownloadString(url);

                            if (get=="SUCCESS") { 
                                MessageBox.Show(Lang.Texts[1499]);
                            } else { 
                                MessageBox.Show(Lang.Texts[1500],Lang.Texts[46]);
                            }

                            #if DEBUG
                            Debug.WriteLine("Send: "+url);
                            Debug.WriteLine("Get: "+get);
                            #endif
                        }
                        break;

                    // Platium
                    case 3:
                        {
                            string url="https://geftgames.ga/rabcrGameJoltSignature.php?username="+textBoxNick.textBox.Text+"&token="+textBoxToken.textBox.Text+"&id=134209&version="+Release.VersionString+secretKey;
                            string get = wc.DownloadString(url);

                            if (get=="SUCCESS") { 
                                MessageBox.Show(Lang.Texts[1499]);
                            } else { 
                                MessageBox.Show(Lang.Texts[1500],Lang.Texts[46]);
                            }

                            #if DEBUG
                            Debug.WriteLine("Send: "+url);
                            Debug.WriteLine("Get: "+get);
                            #endif
                        }
                        break;
                }
                
                Close();
            }
        }

        void ButtonCancel_Click(object sender, System.EventArgs e) => Close();
    }
}