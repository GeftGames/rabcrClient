using System;
using System.Diagnostics;
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



#if !DEBUG
            try{
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);

            /*
            Args
            Use: "...\rabcrClient.exe" Path="C:\Users\..." Type="Message" Name="Player" Text=""


            */


            if (args.Length>0) {
                switch (args[0]) {
                    case "/Game":
                        if (args.Length==3) {
                          //  if (BanStateProcedure()){
                            Setting.Name=args[2];
                            Setting.Path=args[1]+"\\"+Setting.Name+"\\";
                            new Rabcr().Run();
                            //}
                        } else if (args.Length==4 && (args[2].ToLower()=="geft"||args[2].ToLower()=="geftgames") && args[3].StartsWith("%") && args[3].Replace("%", "")==DateTime.Now.Day.ToString()) {
                           // if (BanStateProcedure()){
                              //  Global.Logged=true;
                               // Global.OnlineAccount=false;
                                Setting.Name="Geft";
                                Setting.Path=args[1]+"\\"+Setting.Name+"\\";
                            using var game = new Rabcr(); game.Run();
                            //  }
                        } else ShowError("Zkontrolujte si dvojté uvozovky v argumentu programu");
                        break;

                    case "/Message":{
                        int language=-1;
                        /*langFilePath="",*/string  Text="Error no text found", Header="Message";

                            foreach (string arg in args) {
                                string[] a=arg.Split('=');
                                switch (a[0]) {
                                    case "Language":
                                        int.TryParse(a[1], out language);
                                        break;

                                    case "Header":
                                        Header=a[1];
                                        break;

                                    case "Text":
                                        Text=arg.Substring(5);
                                        break;
                                }
                            }

                        using Message message = new(language: language, Header: Header, text: Text); message.Run();
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
                        ShowError("Chybný 1. argument");
                        break;
                }
            } else {
                //bool x=BanStateProcedure();
                //if (x){
                using var game = new Rabcr(); game.Run();
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

            static void ShowError(string error) {
                Console.WriteLine("ERROR - Hra by se měla spouštět: rabcr.exe /Game <cesta> <jméno>");
                MessageBox.Show("Hra by se měla spouštět: rabcr.exe /Game <cesta> <jméno>\r\n\r\nPodrobnosti:\r\n"+error,"Chyba - špatné argumenty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #if !DEBUG
            } catch (Exception ex) {


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
                            string trace="&r="+fi2.Name+"-method: "+sf2.GetMethod().Name.ToString()+ ", line: "+sf2.GetFileLineNumber() +Environment.NewLine;
                            trace=trace.Replace(" ","%20");
                            send+=trace;
                        } else send+="&r=";

                        // trace inner
                        if (count>0) {
                            System.Diagnostics.StackFrame sf = st.GetFrame(0);
                            FileInfo fi = new FileInfo(sf.GetFileName());
                            string trace = "&h="+fi.Name+"-method: "+sf.GetMethod().Name.ToString()+", line: "+sf.GetFileLineNumber()+Environment.NewLine;
                            trace=trace.Replace(" ", "%20");
                            send+=trace;
                        } else send+="&h=";


        Clipboard.SetText(Release.stringRRE+send);
                        // Antispawn
                        System.Threading.Thread.Sleep(200);

                        // Run
                        WebClient wc=new WebClient();
                        string result=wc.DownloadString(Release.stringRRE+send);
                        //System.Diagnostics.Process.Start();
                        if (result.StartsWith("O|")){
                            Console.WriteLine("send");
                        }else Console.WriteLine("not send");


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

            }
            #endif
        }
    }
}