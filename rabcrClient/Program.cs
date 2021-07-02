using System;
using System.Globalization;
using System.IO;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace rabcrClient {
    public static class Program {

        [STAThread]
        static void Main(string[] args) {
            
           // // Testing speed of code
           //// #if DEBUG
           // int max=1000000;
           // System.Threading.Thread.Sleep(4000);
           // long _1=0, _2=0;
           // Stopwatch sw=new Stopwatch();
           // _1Code();
           // _2Code();
           // _1Code();
           // _2Code();
           // Console.WriteLine("1: "+_1);
           // Console.WriteLine("2: "+_2);

           // void _1Code(){
           //     sw.Start();
           //     for (int i=0; i<max; i++) BitConverter.GetBytes(i);
           //     sw.Stop();
           //     _1+=sw.ElapsedMilliseconds;
           //     sw.Reset();
           // }

           // void _2Code(){
           //     sw.Start();
           //     for (int i=0; i<max; i++) FastBitConverter.GetBytes(i);
           //     sw.Stop();
           //     _2+=sw.ElapsedMilliseconds;
           //      sw.Reset();
           // }

           //// #endif
           
            #if !DEBUG
            try{
            #endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            if (args.Length>0) {
                switch (args[0]) {
                    case "/Game":
                        if (args.Length==3) {
                          //  if (BanStateProcedure()){
                            Setting.Name=args[2];
                            Setting.Path=args[1]+"\\"+Setting.Name+"\\";
                            new Rabcr().Run();
                            //}
                        } else if (args.Length==4 && (args[2].ToLower()=="geft"||args[2].ToLower()=="geftgames") && args[3].StartsWith("%") && args[3].Replace("%", "")==DateTime.Now.Day.ToString()){
                           // if (BanStateProcedure()){
                              //  Global.Logged=true;
                               // Global.OnlineAccount=false;
                                Setting.Name="Geft";
                                Setting.Path=args[1]+"\\"+Setting.Name+"\\";
                                using (var game = new Rabcr()) game.Run();
                          //  }
                        } else ShowError("Zkontrolujte si dvojté uvozovky v argumentu programu");
                        break;

                    case "/Message":
                        if (args.Length==1){ 
                            new Message("<Red>Error</Red> Missing text").Run();
                        }else{
                            new Message(args[1]).Run();
                       // else new Message("").Run();
                        }
                        break;

                    case "/CheckServer":
                        if (Environment.GetCommandLineArgs().Length==4) {
                            try {
                                new CheckServer(args);
                            } catch { }
                        } else Console.WriteLine("E|");
                        break;

                    default:
                        if (File.Exists(args[0]))new Message(File.ReadAllText(args[0])).Run();
                        else ShowError("Chybný 1. argument");
                        break;
                }
            } else {
                //bool x=BanStateProcedure();
                //if (x){
                    using (var game = new Rabcr()) game.Run();
               // }
            }

            //bool BanStateProcedure() {
            //    string cc= RegionInfo.CurrentRegion.TwoLetterISORegionName;

            //    if (Rabcr.IsBannedCountry=IfBanedCountry()){
            //        string day=SomeImportantDay();
            //        if (day==null){
            //            if ((Rabcr.random=new FastRandom()).Int(10)==1) {
            //                FormBanCountry fbc=new FormBanCountry(null);
            //                fbc.ShowDialog();
            //                return fbc.RunGame;
            //            }else return true;
            //        } else {
            //            FormBanCountry fbc=new FormBanCountry(day);
            //            fbc.ShowDialog();
            //            return fbc.RunGame;
            //        }
            //    } else if (Rabcr.IsLimitedCountry=IfLimitedCountry()) {
            //        string day=SomeImportantDay();
            //        if (day!=null) {
            //            if ((Rabcr.random=new FastRandom()).Int(3)==1) {
            //                FormBanCountry fbc=new FormBanCountry(day);
            //                fbc.ShowDialog();
            //                return fbc.RunGame;
            //            }else return true;
            //        } else return true;
            //    } else return true;

            //    bool IfBanedCountry() {
            //        foreach (string c in Release.BannedStates) {
            //            if (c==cc)return true;
            //        }
            //        return false;
            //    }

            //    bool IfLimitedCountry() {
            //        foreach (string c in Release.LimitedStates) {
            //            if (c==cc) return true;
            //        }
            //        return false;
            //    }

            //    string SomeImportantDay(){
            //        DateTime now=DateTime.Now;
            //        int day=now.Day,
            //            month=now.Month;

            //        foreach (Release.GDay c in Release.Sometime) {
            //            if (c.Day==day) {
            //                if (c.Month==month) return c.Name;
            //            }
            //        }
            //        return null;
            //    }
            //}

            void ShowError(string error) {
                Console.WriteLine("ERROR - Hra by se měla spouštět: rabcr.exe /Game <cesta> <jméno>");
                MessageBox.Show("Hra by se měla spouštět: rabcr.exe /Game <cesta> <jméno>\r\n\r\nPodrobnosti:\r\n"+error,"Chyba - špatné argumenty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #if !DEBUG
            } catch (Exception ex) {
                //if (Release.EditedVersion) {
                //    Environment.Exit(-1);
                //    return;
                //}

                // if today aready send (antispawn)
              //  try{
                  //  File.WriteAllText(Path.GetTempPath()+"\\rabcrErrorDetail.txt", ex.StackTrace);
              //  }catch{ }
              //  try {
                    //string temp=Path.GetTempPath()+"\\rabcrError.txt";
                    //if (File.Exists(temp)) {
                    //    string rawday=File.ReadAllText(temp);
                    //    int day=int.Parse(rawday);
                    //    if (day==DateTime.Now.Day) {
                    //        Environment.Exit(-1);
                    //        return;
                    //    }
                    //}
                    //File.WriteAllText(temp, DateTime.Now.Day.ToString());
              //  } catch { }

                CultureInfo ci = CultureInfo.InstalledUICulture;
                string cap, text, details;

                switch (ci.TwoLetterISOLanguageName) {
                    case "cs":
                        cap="Chyba hry";
                        text="Nastala chyba hry, chcete poslat vývojářům anonymní informace o chybě?";
                        details="Detail chyby";
                        break;

                    case "pl":
                        cap="Błąd gry";
                        text="Wystąpił błąd w grze, czy chcesz wysłać anonimowe informacje o błędzie do programistów?";
                        details="Szczegóły błędu";
                        break;

                    case "sk":
                        cap="Chyba hry";
                        text="Nastala chyba hry, chcete poslať vývojárom anonymné informácie o chybe?";
                        details="Detail chyby";
                        break;

                    case "de":
                        cap="Spielfehler";
                        text="Es ist ein Spielfehler aufgetreten. Möchten Sie anonyme Fehlerinformationen an Entwickler senden?";
                        details="Fehlerdetail";
                        break;

                    case "jp":
                        cap="ゲームエラー";
                        text="ゲームエラーが発生しました。匿名のエラー情報を開発者に送信しますか？";
                        details="エラーの詳細";
                        break;

                    default:
                        cap="Game error";
                        text="A game error has occurred, do you want to send anonymous error information to developers?";
                        details="Error detail";
                        break;
                }

                //try {
                    DialogResult dr=MessageBox.Show(text+Environment.NewLine+Environment.NewLine+details+Environment.NewLine+ex.Message, cap, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (dr==DialogResult.Yes) {
                       ManagementObjectSearcher searcher  = new ManagementObjectSearcher("SELECT * FROM Win32_DisplayConfiguration");

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
                        ManagementObjectSearcher search = new ManagementObjectSearcher("Select * From Win32_PhysicalMemory");
                        ulong total = 0;
                        foreach (ManagementObject ram in search.Get()) {
                            total += (ulong)ram.GetPropertyValue("Capacity");
                        }

                        string send=
                            "?a="+Release.VersionString +
                            "&b="+Release.Date.Replace(" ", "%20") +
                            "&c="+GetOsVersionText()+ "%20"+RuntimeInformation.OSArchitecture +
                            "&d="+ Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")+
                            "&e="+Environment.ProcessorCount.ToString() +
                            "&f="+graphicsCard.Replace(" ", "%20")  +
                            "&g="+ex.Message.Replace(" ", "%20") +
                            "&p="+CultureInfo.InstalledUICulture.Name;

                        // StackTrace
                        System.Diagnostics.StackTrace st=new System.Diagnostics.StackTrace(ex, true);
                        int count = st.FrameCount;
                    

                        if (count>1) {
                            System.Diagnostics.StackFrame sf2=st.GetFrame(1);
                            FileInfo fi2 =new FileInfo(sf2.GetFileName());
                            string trace="&r="+/*sf.GetFileName()*/fi2.Name+"-method: "+sf2.GetMethod().Name.ToString()+ ", line: "+sf2.GetFileLineNumber() +Environment.NewLine;
                            //trace=trace.Replace(@"C:\Users\GeftGames\rabcr\rabcrClient\rabcrClient","...");
                            trace=trace.Replace(" ","%20");
                            send+=trace;
                        } else send+="&r=";

                        // trace inner
                        if (count>0) {
                            System.Diagnostics.StackFrame sf = st.GetFrame(0);
                            FileInfo fi = new FileInfo(sf.GetFileName());
                            string trace = "&h="+/*sf.GetFileName()*/fi.Name+"-method: "+sf.GetMethod().Name.ToString()+", line: "+sf.GetFileLineNumber()+Environment.NewLine;
                            //trace=trace.Replace(@"C:\Users\GeftGames\rabcr\rabcrClient\rabcrClient","...");
                            trace=trace.Replace(" ", "%20");
                            send+=trace;
                        } else send+="&h=";
                        
                      
        System.Windows.Forms.Clipboard.SetText("https://geftgames.ga/rre.php"+send);
                        // Antispawn
                        System.Threading.Thread.Sleep(200);
                        //Console.WriteLine("send.Length: "+("https://geftgames.ga/rre.php"+send).Length);
                        // Run
                        WebClient wc=new WebClient();
                        string result=wc.DownloadString("https://geftgames.ga/rre.php"+send);
                        //System.Diagnostics.Process.Start();
                    
                   

                        // Antispawn
                        System.Threading.Thread.Sleep(200);
                        Environment.Exit(-1);

                        string GetOsVersionText(){
                            switch (Environment.OSVersion.Version.Major) {
                                case 10: return "win10";
                                case 6:
                                    switch (Environment.OSVersion.Version.Minor){
                                        case 1: return "win 7 (or 2008 R2)";
                                        case 2: return "win 8";
                                        case 3: return "win 8.1";
                                        case 0: return "win Vista (or 2008)";
                                        default: return "win";
                                    }

                                case 5:
                                    switch (Environment.OSVersion.Version.Minor) {
                                        case 0: return "win 2000";
                                        case 1: return "win XP";
                                        case 2: return "win 2003";
                                        default: return "win";
                                    }
                                default: return "win";
                            }
                        }
                    }
              //  } catch { }
            }
            #endif
        }
    }
}