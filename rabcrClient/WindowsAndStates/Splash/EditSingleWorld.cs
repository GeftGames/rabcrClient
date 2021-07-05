using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class EditSingleWorld : Form {

        public string path;
        Thread thread;
        bool finish=false;

        public EditSingleWorld(string path) {
            InitializeComponent();
            textPanel8.Resize+=TextPanel8_Resize;
           Text= textPanel8.Text=Lang.Texts[71];
            textPanel1.Text=Lang.Texts[59];
            textPanel5.Text=Lang.Texts[190];
            textPanel7.Text=Lang.Texts[191];
            //textPanel10.Text=Lang.Texts[190];
            //textPanel9.Text=Lang.Texts[191];
            textPanel6.Text=Lang.Texts[72];

            link1.Text=Lang.Texts[60];

            customButton5.Text=Lang.Texts[193];
            customButton7.Text=Lang.Texts[74];
            customButton1.Text=Lang.Texts[194];
            customButton2.Text=Lang.Texts[57];
            customButton3.Text=Lang.Texts[58];
            customButton6.Text=Lang.Texts[75];

         //   textPanel3.Text=Lang.Texts[191];
            textPanel2.Text=Lang.Texts[219];

            this.path=path;
            if (!File.Exists(path+"\\SplashText.txt")) {
                File.WriteAllText(path+"\\SplashText.txt",Lang.Texts[17]);
            }
            bounds1.drawClearPix=true;

            xTextBoxName.textBox.Text=File.ReadAllText(path+"\\SplashText.txt");

            xTextBoxName.textBox.TextChanged+=TextBox_TextChanged;
        }

        void TextPanel8_Resize(object sender, EventArgs e) => textPanel8.Location=new System.Drawing.Point(Width/2-textPanel8.Width/2, textPanel8.Location.Y);


        void TextBox_TextChanged(object sender, EventArgs e) {
            if (!panel2.Visible) {
                panel2.Visible=true;
                link1.Text=Lang.Texts[189];
                link1.Invalidate();
                panel3.Location=new System.Drawing.Point(panel3.Location.X,panel3.Location.Y+70);
                Height+=70;
            }
            news2.Load(xTextBoxName.textBox.Text);
        }

        void GButton2_Click(object sender, EventArgs e) {
            if (thread!=null) {
                if (thread.IsAlive) thread.Abort();
            }
            timer1.Stop();
            Close();
        }

        void GButton3_Click(object sender, EventArgs e) {
            if (!customButton3.Disamble) {
                File.WriteAllText(path+"\\SplashText.Txt",xTextBoxName.textBox.Text);
                timer1.Stop();
                Close();
            }
        }

      //  void GButton4_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0],"/Message Info");

        void GButton5_Click(object sender, EventArgs e) {
            if (!customButton5.Disamble) {
                bar1.Visible=true;
                textPanel4.Visible=true;
                bounds3.Visible=true;

                //customButton6.Disamble=true;
                //customButton5.Disamble=true;
                //customButton3.Disamble=true;
                HideInfo();
                StartRemoveWorld();
            }
        }

        void GButton6_Click(object sender, EventArgs e) {
            if (!customButton6.Disamble) {
                bar1.Visible=true;
                textPanel4.Visible=true;
                bounds3.Visible=true;

                //customButton6.Disamble=true;
                //customButton5.Disamble=true;
                //customButton3.Disamble=true;
                 HideInfo();
                StartCleanWorld();
            }
        }

        void StartCleanWorld() {
            thread=new Thread(CleaningWorld) {
                IsBackground=true,
                Priority=ThreadPriority.Lowest
            };
            thread.Start();
        }

        void CleaningWorld() {
            int done=0;
            string[] fls=Directory.GetFiles(path,"*",SearchOption.AllDirectories);
            foreach (string file in fls) {
                if (file!=path+"\\SplashText.txt" && file!=path+"\\Options.txt") {
                    File.Delete(file);
                    done++;
                    bar1.Value=(float)done/fls.Length;

                }
            }
            finish=true;
        }

        void StartRemoveWorld() {
            thread=new Thread(RemovingWorld) {
                IsBackground=true,
                Priority=ThreadPriority.Lowest
            };
            thread.Start();
        }

        void RemovingWorld() {
            int done=0;
            if (Directory.Exists(path)) {
                string[] files=Directory.GetFiles(path,"*",SearchOption.AllDirectories);

                foreach (string f in files) {
                    File.Delete(f);
                    done++;
                    bar1.Value=(float)done/files.Length;
                }

                try {
                    Directory.Delete(path,true);
                } catch { }
                finish=true;
            }
        }

        void Timer1_Tick(object sender, EventArgs e) {
            if (thread!=null) {
                if (finish) {
                    timer1.Stop();
                    Close();
                }
            }
        }

        void GButton7_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog{
                Filter=Lang.Texts[218]+"|*.rw|"+Lang.Texts[79]+"|*.zip|"+Lang.Texts[217]+"|*",
                Title=Lang.Texts[191]
            }){;
                DialogResult dr=sfd.ShowDialog();

                if (dr!=DialogResult.Cancel) {
                    if (sfd.FileName!="" || sfd.FileName!=null) {
                        Directory.Move(path,path+"_");
                        try {
                            if (File.Exists(sfd.FileName)) File.Delete(sfd.FileName);
                            ZipFile.CreateFromDirectory(path+"_", sfd.FileName, CompressionLevel.Fastest, true);
                            Directory.Move(path+"_",path);
                        } catch (Exception ex) {MessageBox.Show(ex.Message);}
                    }
                }
            }
        }

        private void Link1_Click(object sender, EventArgs e) {
            if (panel2.Visible){
                panel2.Visible=false;
                link1.Text=Lang.Texts[60];
                panel3.Location=new System.Drawing.Point(panel3.Location.X,panel3.Location.Y-70);
                Height-=70;//news1.Invalidate();

            }else{
                panel2.Visible=true;
                link1.Text=Lang.Texts[189];
                link1.Invalidate();
                panel3.Location=new System.Drawing.Point(panel3.Location.X,panel3.Location.Y+70);
                Height+=70;
                news2.Load(xTextBoxName.textBox.Text);
            }
        }

        void HideInfo(){
            customButton6.Visible=false;
            customButton5.Visible=false;
            textPanel2.Visible=false;
            textPanel7.Visible=false;
            textPanel5.Visible=false;
        }

        private void GButton1_Click(object sender, EventArgs e) => Global.ShowgeDoHelp();/*Global.RunMessage(Lang.Texts[1559],Lang.Texts[194]);*///System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0], Global.MessageGedoInfo);
    }
}