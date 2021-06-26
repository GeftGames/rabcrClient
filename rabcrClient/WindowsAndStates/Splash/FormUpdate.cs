using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormUpdate: Form {
        readonly WebClient wc=new WebClient();
        readonly List<string[]> verFile=new List<string[]>();
        string download;
        public FormUpdate() {
            InitializeComponent();
            GetFile();
        }

        void GetFile(){
            try{
                wc.DownloadStringCompleted+=Wc_DownloadStringCompleted;
                wc.DownloadStringAsync(new Uri(Release.CheckNewVersion));
            }catch{ }
        }
        private void Wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e) {
            if (e.Error==null){

                string[] lines=e.Result.Split('\n');
                foreach (string s in lines){
                    verFile.Add(s.Split('='));
                }

                if (verFile.Count>0){
                    if (verFile[0][0]==Release.VersionString){

                        textPanel1.Text="Používáte nejnovější verzi";
                        textPanel1.Invalidate();
                    } else {
                        textPanel1.Text="Nalezena nová verze '"+verFile[0][0]+"'.";
                        download=verFile[0][1];
                        textPanel1.Invalidate();
                        customButton1.Visible=false;
                        customButton2.Visible=true;
                    }

                }else{
                    textPanel1.Text="Při hledání nové verze se vyskytla chyba";
                    textPanel1.Invalidate();
                }
            } else{
                textPanel1.Text="Při hledání nové verze se vyskytla chyba";
                textPanel1.Invalidate();
            }
        }

        private void GButton2_Click(object sender, EventArgs e) {
            try {
                Process.Start(download);
            } catch {
                try {
                    Process.Start(Release.WebFull);
                } catch { }
            }
        }

        private void GButton1_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
