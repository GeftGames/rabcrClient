using System;
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
                        } else ShowError("Zkontrolujte si dvojté uvozovky v argumentu programu");
                        break;

                    case "/Message":{
                        int language=-1;
                        string  Text="Error no text found", 
                                Header="Message";

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
                using var game = new Rabcr(); 
                game.Run();
                // }
            }

            static void ShowError(string error) {
                Console.WriteLine("ERROR - Hra by se měla spouštět: rabcr.exe /Game <cesta> <jméno>");
                MessageBox.Show("Hra by se měla spouštět: rabcr.exe /Game <cesta> <jméno>\r\n\r\nPodrobnosti:\r\n"+error,"Chyba - špatné argumenty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #if !DEBUG
            } catch (Exception ex) {
                FormError fe=new(ex,  DateTime.Now);
                fe.ShowDialog();
            }
            #endif
        }
    }
}