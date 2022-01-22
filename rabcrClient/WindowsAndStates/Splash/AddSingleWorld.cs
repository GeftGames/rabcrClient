using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class AddSingleWorld : Form {
        readonly string DirName;
        Thread thread;
        string name;
        int max=0;


        readonly string[] codes={
            "Yellow",
            "Gold",
            "Orange",
            "Red",
            "DarkRed",
            "Purple",
            "Pink",
            "LightBlue",
            "Blue",
            "DarkBlue",
            "Teal",
            "LightGreen",
            "Green",
            "DarkGreen",
            "Brown",
        };
        readonly string newWorld;

        public AddSingleWorld(string rndName) {
            DirName=rndName;
            InitializeComponent();

            textPanel8.Resize+=TextPanel8_Resize;
            textPanel8.Text=Lang.Texts[188];
            textPanel1.Text=Lang.Texts[59];
            link1.Text=Lang.Texts[60];
            textPanel4.Text=Lang.Texts[61];
            textPanel7.Text=Lang.Texts[62];
            customButton6.Text=Lang.Texts[63];
            customButton2.Text=Lang.Texts[57];
            customButton3.Text=Lang.Texts[167];
            gTextPanel1.Text=Lang.Texts[323];
            textPanel3.Text=Lang.Texts[72];
            customButton4.Text=Lang.Texts[194];
            changeButtonStartUpItems.List= new string[]{ Lang.Texts[148],Lang.Texts[320],Lang.Texts[321],Lang.Texts[322]};
            changeButtonStartUpItems.selected=0;
            changeButton1.List = new string[] { Lang.Texts[195], Lang.Texts[198], Lang.Texts[183]};

            changeButton3.List = new string[] { Lang.Texts[197], Lang.Texts[155], Lang.Texts[196/*8*/]};

            Text=Lang.Texts[188];

            timer1.Start();
            newWorld=Lang.Texts[17];
            string o="";
            for (int i=0; i<newWorld.Length; i++){
                if (newWorld[i]==' '){
                    o+=" ";
                }else{
                    string code=codes[FastRandom.Int(codes.Length-1)];
                    o+="<"+code+">"+newWorld[i]+"</"+code+">";
                }
            }

            xTextBoxName.textBox.Text=o;
            xTextBoxName.textBox.TextChanged+=TextBoxName_TextChanged;
        }

        void TextPanel8_Resize(object sender, System.EventArgs e) => textPanel8.Location=new System.Drawing.Point(Width/2-textPanel8.Width/2, textPanel8.Location.Y);


        void TextBoxName_TextChanged(object sender, EventArgs e) {
             if (!panel2.Visible) {
                if (xTextBoxName.textBox.Text.Contains("<") || xTextBoxName.textBox.Text.Contains("<")) {
                    panel2.Visible=true;
                    link1.Text=Lang.Texts[189];
                    link1.Invalidate();
                    panel3.Location=new System.Drawing.Point(panel3.Location.X,panel3.Location.Y+70);
                    Height+=70;
                }
            } /*else*/ news1.Load(xTextBoxName.textBox.Text);
        }

        void GButton2_Click(object sender, EventArgs e) => Close();

        void GButton3_Click(object sender, EventArgs e) {
            if (!customButton3.Disamble) {
                Directory.CreateDirectory(Setting.Path + @"\Worlds\"+DirName);
                File.WriteAllText(Setting.Path + @"\Worlds\"+DirName+"\\Options.txt",changeButton1.selected+Environment.NewLine+changeButton3.selected+Environment.NewLine+changeButtonStartUpItems.selected);
                File.WriteAllText(Setting.Path + @"\Worlds\"+DirName+"\\SplashText.txt",xTextBoxName.textBox.Text);
                timer1.Stop();
                Close();
            }
        }

        void GButton4_Click(object sender, EventArgs e) =>  Global.ShowgeDoHelp();//Global.RunMessage(Lang.Texts[1559],Lang.Texts[194]);/*System.Diagnostics.Process.Start(Environment.GetCommandLineArgs()[0],Global.MessageGedoInfo);*/

        void GButton6_Click(object sender, EventArgs e) {
            using (OpenFileDialog sfd = new OpenFileDialog {
                Filter=Lang.Texts[218]+"|*.rw|"+Lang.Texts[79]+"|*.zip|"+Lang.Texts[217]+"|*",
                Title=Lang.Texts[216]
            }){
                sfd.ShowDialog();

                if (File.Exists(sfd.FileName)) {
                    customButton6.Visible=false;
                    textPanel6.Visible=true;
                    bar1.Visible=true;
                    bounds3.Visible=true;
                    customButton3.Disamble=true;
                    name=sfd.FileName;

                    thread=new Thread(Extraction) {
                        Priority=ThreadPriority.Highest,
                        IsBackground=true
                    };
                    thread.Start();
                }

            }
        }

        void Extraction() {
            using (ZipArchive newFile = ZipFile.OpenRead(name)) {

                int working=0;
                string wDir="";

                max=newFile.Entries.Count;

                foreach (ZipArchiveEntry en in newFile.Entries) {

                    string path=en.FullName;

                    if (working==0) wDir=path.Substring(0,path.IndexOf("\\"));
                    path=path.Substring(wDir.Length);

                    string dir=new FileInfo(Setting.Path + @"\Worlds\"+DirName+@"\"+path).Directory.FullName;
                    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                    byte[] bytes;

                    using (Stream s = en.Open()) {
                        BinaryReader br = new BinaryReader(s);
                        bytes=br.ReadBytes((int)en.Length);
                    }

                    using (StreamWriter sw = new StreamWriter(Setting.Path + @"\Worlds\"+DirName+@"\"+path)) {
                        BinaryWriter bw = new BinaryWriter(sw.BaseStream);
                        bw.Write(bytes);
                    }
                    working++;
                    bar1.Value=(float)working/max;
                }
            }
            File.WriteAllText(Setting.Path + @"\Worlds\"+DirName+"\\SplashText.txt",xTextBoxName.textBox.Text);
        }

        void Timer1_Tick(object sender, EventArgs e) {
            if (thread!=null) {
                if (!thread.IsAlive) {
                    timer1.Stop();
                    Close();
                }
            }
        }

        private void Link1_Click(object sender, EventArgs e) {
            if (panel2.Visible){
                panel2.Visible=false;
                link1.Text=Lang.Texts[60];
                panel3.Location=new System.Drawing.Point(panel3.Location.X,panel3.Location.Y-70);
                Height-=70;
            } else {
                panel2.Visible=true;
                link1.Text=Lang.Texts[189];
                link1.Invalidate();
                panel3.Location=new System.Drawing.Point(panel3.Location.X,panel3.Location.Y+70);Height+=70;news1.Load(xTextBoxName.textBox.Text);
            }
        }
    }
}