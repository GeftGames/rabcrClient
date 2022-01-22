using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace rabcrClient {
    #if MULTIPLAYER
    public partial class FormLogin : Form {

        //  bool offline=false;
        public bool OK = false;
        public string getdata;
        //MyWebClient wc;

        public FormLogin() {
            InitializeComponent();

            xTextbox2.textBox.PasswordChar = '*';
            customButton1.Text = Lang.Texts[12];
            customButton2.Text = Lang.Texts[57];
            textPanel3.Text = Lang.Texts[65];
            textPanel2.Text = Lang.Texts[64];
            geDoPanel1.BackColor = BackColor;
            Text = textPanel1.Text = Lang.Texts[215];
            textPanel4.Text = Lang.Texts[30];
            textPanel1.Resize += TextPanel1_Resize;

            //SwitchToOnline(null,new EventArgs());


        }

        private void TextPanel1_Resize(object sender, EventArgs e) {
            textPanel1.Location = new System.Drawing.Point(Width / 2 - textPanel1.Width / 2, textPanel1.Location.Y);
        }

        void SwitchToOffline(object sender, EventArgs e) {
            xTextbox2.Visible = false;
            textPanel3.Visible = false;

            // offline=true;
            ///geDoPanel1.ClearEvents();
            //GeDoEvent ev=new GeDoEvent(){ID="#E1"};

            //ev.Event+=SwitchToOnline;
            //geDoPanel1.AddEvent(ev);
            //geDoPanel1.Load(
            //    "<Link|event=#E1>"+Lang.Texts[214]+"</Link> "+Environment.NewLine+
            //    Lang.Texts[66]+" <Link|web=https://geftgames.ga/account/register/>"+Lang.Texts[213]+"</Link> "+Environment.NewLine+
            //    Lang.Texts[69]+" <Link|web=https://geftgames.ga/>"+Lang.Texts[70]+"</Link>"
            //);
        }

        //void SwitchToOnline(object sender, EventArgs e) {
        //    xTextbox2.Visible=true;
        //    textPanel3.Visible=true;
        //    offline=false;
        //   // geDoPanel1.ClearEvents();
        //   // GeDoEvent ev=new GeDoEvent(){ID="#E1"};

        //   // ev.Event+=SwitchToOffline;
        //   // geDoPanel1.AddEvent(ev);
        //    //geDoPanel1.Load(
        //    //    "<Link|event=#E1>"+Lang.Texts[67]+"</Link> "+Environment.NewLine+
        //    //    Lang.Texts[66]+" <Link|url=https://geftgames.ga/account/register/>"+Lang.Texts[213]+"</Link> "+Environment.NewLine+
        //    //    Lang.Texts[69]+" <Link|url=https://geftgames.ga/>"+Lang.Texts[70]+"</Link>"
        //    //);
        //}

        void GButton2_Click(object sender, EventArgs e) {
            Close();
        }

        void GButton1_Click(object sender, EventArgs e) {
            if (xTextbox1.textBox.Text.Length <= 2) {
                MessageBox.Show(Lang.Texts[232].Replace("%nick%", xTextbox1.textBox.Text));
                return;
            }
            // if (offline){
            if (xTextbox1.textBox.Text.ToLower() != "geftgames" && xTextbox1.textBox.Text.ToLower() != "geft" && xTextbox1.textBox.Text.ToLower() != "player") {
                Setting.Name = xTextbox1.textBox.Text;
                Global.Logged = true;
                //Global.OnlineAccount=false;
                File.WriteAllText(Path.GetTempPath() + "\\rabcrLastPassword.txt", Setting.Name);
                OK = true;
                Close();
            } else {
                MessageBox.Show(Lang.Texts[232].Replace("%nick%", xTextbox1.textBox.Text));
            }
            //} else {
            //    string name=xTextbox1.textBox.Text;
            //    //Global.Pass=CreateMD5(xTextbox2.textBox.Text);
            //    //string url="https://geftgames.ga/System/rabcr/getdata.php?username="+name+"&password="+Global.Pass;
            //    //wc=new MyWebClient {
            //    //    Encoding=Encoding.UTF8
            //    //};
            //    //wc.DownloadStringCompleted+=Wc_DownloadStringCompleted;
            //    //wc.DownloadStringAsync(new Uri(url));
            //    textPanel4.Visible=true;
            //    textPanel2.Visible=false;
            //    xTextbox1.Visible=false;
            //    xTextbox2.Visible=false;
            //    textPanel3.Visible=false;
            //    customButton1.Visible=false;
            //    customButton2.Visible=false;
            //}
        }

        //void ShowLogin(){
        //    textPanel4.Visible=false;
        //    textPanel2.Visible=true;
        //    xTextbox1.Visible=true;
        //    xTextbox2.Visible=true;
        //    textPanel3.Visible=true;
        //    customButton1.Visible=true;
        //    customButton2.Visible=true;
        //}

        //void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) {
        //    if (e.Error==null) {
        //        string get=e.Result;
        //        Console.WriteLine("GET: "+get);
        //        if (string.IsNullOrEmpty(get)) {
        //            MessageBox.Show(Lang.Texts[233]);
        //            Close();

        //        } else {
        //            string[]g=get.Split('|');

        //            if (g.Length>1){
        //                switch (g[0]) {
        //                    case "E":
        //                        MessageBox.Show("ERROR, "+g[1]);
        //                        ShowLogin();
        //                        return;

        //                    case "I":
        //                        OK=true;
        //                        getdata=null;
        //                        Setting.Name=xTextbox1.textBox.Text;
        //                        if (Environment.GetCommandLineArgs().Length>=3){
        //                            Setting.Path=Environment.GetCommandLineArgs()[2]+"\\"+Setting.Name+"\\";
        //                        } else {
        //                            Setting.Path=new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"\\"+Setting.Name+"\\";
        //                        }
        //                      //  Global.OnlineAccount=true;
        //                        Global.Logged=true;
        //                         File.WriteAllText(Path.GetTempPath()+"\\rabcrLastPassword.txt",Setting.Name+"\r\n"+Global.Pass);
        //                        Close();
        //                        return;

        //                    case "O":
        //                        getdata=g[1];
        //                        OK=true;
        //                        Global.OnlineAccount=true;
        //                        Global.Logged=true;
        //                        Setting.Name=xTextbox1.textBox.Text;
        //                        if (Environment.GetCommandLineArgs().Length>=3){
        //                            Setting.Path=Environment.GetCommandLineArgs()[2]+"\\"+Setting.Name+"\\";
        //                        } else {
        //                            Setting.Path=new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"\\"+Setting.Name+"\\";
        //                        }
        //                         File.WriteAllText(Path.GetTempPath()+"\\rabcrLastPassword.txt",Setting.Name+"\r\n"+Global.Pass);
        //                        Close();
        //                        return;

        //                    default:
        //                        MessageBox.Show(Lang.Texts[233]+"\r\n\r\n"+Lang.Texts[234]+"\r\n"+Lang.Texts[235]);
        //                        ShowLogin();
        //                        return;
        //                }
        //            } else {
        //                MessageBox.Show(Lang.Texts[233]);
        //                ShowLogin();
        //                return;
        //            }
        //        }
        //    } else {
        //        MessageBox.Show(Lang.Texts[233]+"\r\n\r\n"+Lang.Texts[234]+"\r\n"+e.Error.Message);
        //        ShowLogin();
        //        return;
        //    }
        //}

        //public static string CreateMD5(string input) {
        //    using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create()) {
        //        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        //        byte[] hashBytes = md5.ComputeHash(inputBytes);

        //        StringBuilder sb = new StringBuilder();
        //        for (int i = 0; i < hashBytes.Length; i++) sb.Append(hashBytes[i].ToString("X2"));
        //        return sb.ToString();
        //    }
        //}

        // void LinkLabel1_LinkClicked(object sender, EventArgs e) => Process.Start("https://geftgames.ga/Account/register.php");

        //  void Link2_Click(object sender, EventArgs e) => Process.Start("https://geftgames.ga/");

        //void Flush(){
        //    xTextbox1.Dis
        //}
    }

    //class MyWebClient : WebClient{
    //    protected override WebRequest GetWebRequest(Uri uri) {
    //        WebRequest w = base.GetWebRequest(uri);
    //        w.Timeout = 5000;
    //        return w;
    //    }
    //}
    #endif
}
