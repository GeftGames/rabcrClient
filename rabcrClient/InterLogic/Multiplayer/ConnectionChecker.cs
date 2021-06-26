using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace rabcrClient {
    class ConnectionChecker:IDisposable {

        #region Varibles
        Process p;
        Thread checker;
        bool exited;
        bool started;
        string get="";
        readonly string Ip;
        readonly int Port;
        #endregion

        public bool Error=false;
        public string ErrorText="";
        public int ErrorDeep;
        public string Received;

        public ConnectionChecker(string ip, int port) {
            checker=new Thread(ThreadStart);
            Error=false;
            Port=port;
            if (ip=="localhost" || ip=="*" || ip=="0.0.0.0")  Ip=IPAddress.Loopback.ToString();
            else Ip=ip;
        }

        public void Start() {
            started=true;
            checker.Start();
        }

        public bool Check() {
            try {  if (checker!=null) {
                if (started) {
                    if (checker.IsAlive) {
                            if (p!=null){
                if ((int)(DateTime.Now-p.StartTime).TotalSeconds>5) {
                    Error=true;
                    ErrorText="Server nenalezen v časovém intervalu";
                    ErrorDeep=2;
                } }


                    } else {
                        string[] lines=SplitByString(get,Environment.NewLine);
                       //
                        foreach (string data in lines) {
                             if (data.StartsWith("E")) {
                            Error=true;
                            string[] parts=get.Split('|');
                         ErrorDeep =  int.Parse(parts[2]);
                           ErrorText=parts[3];
                            } else if (data=="I|Started "+Release.VersionString) {
                                //info=true;
                            } else if (data=="I|Exited") {
                                exited=true;
                            } else if (data.StartsWith("G")) {
                                Received=data;
                                return true;
                            }}
                        }
                    }
                }
            }catch {}
            return false;
        }

        public string[] SplitByString(string input,string spliter) {
            return input.Split(new string[] { spliter }, StringSplitOptions.None);
        }

        public void Dispose() {
            if (!exited) {
                try {
                p.Kill();
                p.Close();
                p.Dispose();
                }catch {}
            }
            if (checker!=null) {
                if (checker.IsAlive) {
                    checker.Abort();
                }
            }
        }

        void ThreadStart() {
            p=new Process {
                EnableRaisingEvents=true,
                StartInfo=new ProcessStartInfo() {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    FileName=System.Reflection.Assembly.GetExecutingAssembly().Location,
                    Arguments="/CheckServer "+Ip+" "+Port,
                }
            };

			p.OutputDataReceived += OutputDataReceived;
			p.Start();

			p.BeginOutputReadLine();
			p.BeginErrorReadLine();

			p.WaitForExit();
        }

        void OutputDataReceived(object sender, DataReceivedEventArgs e) {
            string data=e.Data;

            if (data!=null) {
                if (data.Length>2)get+=data+Environment.NewLine;
            }
        }
    }
}