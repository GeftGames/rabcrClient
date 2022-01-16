using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormError : Form {
        Exception exception;
        DateTime errorTime;
        public FormError(Exception ex, DateTime dt) {
            InitializeComponent();
            exception=ex;
            errorTime=dt;
            label2.Text="Error details: "+ex.Message;
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e) {
            MessageBox.Show("Error in code appeard. You can save error detail or send anonymously to developers or just close and do nothing.");
        }

        private void button3_Click(object sender, EventArgs e) {
            Close();
            Environment.Exit(0);
        }

        private void buttonSend_Click(object sender, EventArgs e) {
            //   DialogResult dr=MessageBox.Show(text+Environment.NewLine+Environment.NewLine+details+Environment.NewLine+ex.Message, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                   // if (dr==DialogResult.Yes) {
                ManagementObjectSearcher searcher  = new("SELECT * FROM Win32_DisplayConfiguration");

            // graphics
            string graphicsCard = string.Empty;
            foreach (ManagementObject mo in searcher.Get()) {
                foreach (PropertyData property in mo.Properties) {
                    if (property.Name == "Description") {
                        graphicsCard = property.Value.ToString();
                    }
                }
            }

            // Ram
            //ManagementObjectSearcher search = new ManagementObjectSearcher("Select * From Win32_PhysicalMemory");
            //ulong total = 0;
            //foreach (ManagementObject ram in search.Get()) {
            //    total += (ulong)ram.GetPropertyValue("Capacity");
            //}

            string send=
                    "?a="+Release.VersionString +
                    "&b="+Release.Date.Replace(" ", "%20") +
                    "&c="+GetOsVersionText()+ "%20"+RuntimeInformation.OSArchitecture +
                    "&d="+ Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")+
                    "&e="+Environment.ProcessorCount.ToString() +
                    "&f="+graphicsCard.Replace(" ", "%20")  +
                    "&g="+exception.Message.Replace(" ", "%20") +
                    "&p="+CultureInfo.InstalledUICulture.Name;

            // StackTrace
            StackTrace st=new(exception, true);
                int count = st.FrameCount;


                if (count>1) {
                StackFrame sf2=st.GetFrame(1);
                    FileInfo fi2 =new(sf2.GetFileName());
                    string trace="&r="+fi2.Name+"-method: "+sf2.GetMethod().Name.ToString()+ ", line: "+sf2.GetFileLineNumber() +Environment.NewLine;
                    trace=trace.Replace(" ","%20");
                    send+=trace;
                } else send+="&r=";

                // trace inner
                if (count>0) {
                StackFrame sf = st.GetFrame(0);
                    FileInfo fi = new(sf.GetFileName());
                    string trace = "&h="+fi.Name+"-method: "+sf.GetMethod().Name.ToString()+", line: "+sf.GetFileLineNumber()+Environment.NewLine;
                    trace=trace.Replace(" ", "%20");
                    send+=trace;
                } else send+="&h=";


//Clipboard.SetText(Release.stringRRE+send);
                // Antispawn
                System.Threading.Thread.Sleep(200);

                // Run
                WebClient wc=new();
                string result=wc.DownloadString(Release.stringRRE+send);
                //System.Diagnostics.Process.Start();
                if (result.StartsWith("O|")){
                    Console.WriteLine("send");
                }else Console.WriteLine("not send");


                // Antispawn
                System.Threading.Thread.Sleep(200);
                Environment.Exit(-1);

            //static string GetOsVersionText(){
            //    return Environment.OSVersion.Version.Major switch {
            //        10 => "win10",
            //        6 => Environment.OSVersion.Version.Minor switch {
            //            1 => "win 7 (or 2008 R2)",
            //            2 => "win 8",
            //            3 => "win 8.1",
            //            0 => "win Vista (or 2008)",
            //            _ => "win",
            //        },
            //        5 => Environment.OSVersion.Version.Minor switch {
            //            0 => "win 2000",
            //            1 => "win XP",
            //            2 => "win 2003",
            //            _ => "win",
            //        },
            //        _ => "win",
            //    };
            //}
                //    }

        }
        

        private void ButtonSaveRep_Click(object sender, EventArgs e) {
            SaveFileDialog sfd = new() {
                Filter = "Log file|*.log|Text file|*.txt|All files|*.*",
                FileName = "Error detail "+errorTime.Year+" "+errorTime.Day+"-"+errorTime.Month+" "+errorTime.Hour+"-"+errorTime.Minute+"-"+errorTime.Second,
                Title = "Save error report",
              //  CheckFileExists = true
            };

            DialogResult dr=sfd.ShowDialog();
            if (dr==DialogResult.OK) {
                string text="";
                ManagementObjectSearcher searcher  = new("SELECT * FROM Win32_DisplayConfiguration");

                // graphics
                string graphicsCard = string.Empty;
                foreach (ManagementObject mo in searcher.Get()) {
                    foreach (PropertyData property in mo.Properties) {
                        if (property.Name == "Description") {
                            graphicsCard = property.Value.ToString();
                        }
                    }
                }

                // Ram
                ManagementObjectSearcher search = new("Select * From Win32_PhysicalMemory");
                ulong total = 0;
                foreach (ManagementObject ram in search.Get()) {
                    total += (ulong)ram.GetPropertyValue("Capacity");
                }


                text +=Release.ShortGameName+" error report\r\n";
                text+="<Game>\r\n";
                text+="Game version: "+Release.VersionString+"\r\n";
                text+="Game version released: "+Release.Date+"\r\n";
                text+="Game dev email: "+Release.Email+"\r\n";
                text+="Game website: "+Release.WebFullGame+"\r\n";
                text+="\r\n";
                text+="<OS>\r\n";
                text+="OS: "+GetOsVersionText()+ " "+RuntimeInformation.OSArchitecture+"\r\n";
                text+="Procesor cores: "+Environment.ProcessorCount.ToString()+"\r\n";
                text+="Graphics card: "+graphicsCard+"\r\n";
                text+="Ram: "+(total/1024/1024)+"MB\r\n";
                text+="CultureInfo: "+CultureInfo.InstalledUICulture.Name+"\r\n";
                text+="\r\n";
                text+="<Exception>\r\n";
                text+="Error time: "+errorTime.ToLongDateString()+"\r\n";
                text+="Message: "+exception.Message+"\r\n";
                if (exception.InnerException!=null) text+="Message inner: "+exception.InnerException.Message+"\r\n";

                // StackTrace
                StackTrace st=new(exception, true);
                int count = st.FrameCount;


                if (count>1) {
                    StackFrame sf2=st.GetFrame(1);
                    string finename=sf2.GetFileName();
                    if (finename!=null){
                        FileInfo fi2 =new(finename);
                        
                        text+="Trace: "+fi2.Name+"-method: "+sf2.GetMethod().Name.ToString()+ ", line: "+sf2.GetFileLineNumber()+"\r\n";
                    }
                }

                // trace inner
                if (count>0) {
                    StackFrame sf = st.GetFrame(0);
                    string finename=sf.GetFileName();
                    if (finename!=null){
                        FileInfo fi = new(finename);
                        text+="Trace: "+fi.Name+"-method: "+sf.GetMethod().Name.ToString()+", line: "+sf.GetFileLineNumber()+"\r\n";
                    }
                } 
                
                text+="Full trace: "+exception.StackTrace+"\r\n";


                //Clipboard.SetText(Release.stringRRE+send);
                // Antispawn
                System.Threading.Thread.Sleep(200);

                // Run
               // WebClient wc=new();
               // string result=wc.DownloadString(Release.stringRRE+send);
                //System.Diagnostics.Process.Start();
               // if (result.StartsWith("O|")){
              //      Console.WriteLine("send");
              //  }else Console.WriteLine("not send");
              try{
              File.WriteAllText(sfd.FileName,text);
                }catch{ }
                // Antispawn
                System.Threading.Thread.Sleep(200);
          //      Environment.Exit(-1);

             }
        }

        static string GetOsVersionText() {
            return Environment.OSVersion.Version.Major switch {
                10 => "win10",
                6 => Environment.OSVersion.Version.Minor switch {
                    1 => "win 7 (or 2008 R2)",
                    2 => "win 8",
                    3 => "win 8.1",
                    0 => "win Vista (or 2008)",
                    _ => "win",
                },
                5 => Environment.OSVersion.Version.Minor switch {
                    0 => "win 2000",
                    1 => "win XP",
                    2 => "win 2003",
                    _ => "win",
                },
                _ => "win",
            };
        }
    }
}
