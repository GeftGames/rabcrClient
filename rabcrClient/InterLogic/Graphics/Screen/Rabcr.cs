using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Color = Microsoft.Xna.Framework.Color;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using MessageBox = System.Windows.Forms.MessageBox;

namespace rabcrClient {
    public class Rabcr : Game {
        public static Screen screen;
        public static ContentManager content;
        public static GraphicsDevice Graphics;
        public static GraphicsDeviceManager GraphicsManager;
        public static Game Game;
        public static Texture2D Pixel;
        public static FastRandom random;
        public static SpriteBatch spriteBatch;
        static bool exiting=false;
        static bool saved=false;
        public static bool ActiveWindow;
        public static MouseState newMouseState;
        public static bool IsBannedCountry, IsLimitedCountry;
        public static Color color_r0_g0_b0_a100 = new Color(0,0,0,100);

        public Rabcr() {
            newMouseState=new MouseState();
            //Activated += ActivateMyGame;
            //Deactivated += DeactivateMyGame;
            bool runWithArgs=Environment.GetCommandLineArgs().Length>=3;
            Game=this;

            #region Load enviroment
          //  bool set=false;
            //if (File.Exists(Path.GetTempPath()+"\\rabcrLastPassword.txt")){

            //    string[] lines=File.ReadAllLines(Path.GetTempPath()+"\\rabcrLastPassword.txt");

            //    if (lines.Length==2){
            //        if (!runWithArgs) Setting.Name=lines[0];

            //        //if (lines[0]==Setting.Name) {
            //        //    Global.Pass=lines[1];
            //        //}
            //    } else if (lines.Length==1) {
            //        if (!runWithArgs){

            //            // autologin offline account
            //            Setting.Name=lines[0];
            //            Global.Logged=true;
            //           // Global.OnlineAccount=false;

            //            Setting.Path=GetPathIfNotArgs();

            //            set=true;

            //            if (!Directory.Exists(Setting.Path))Directory.CreateDirectory(Setting.Path);

            //            //Log.Init();

            //            if (!File.Exists(Setting.Path+@"\Setting.bin")) CreateSettings();
            //            else {
            //                try {
            //                    LoadSetting();
            //                } catch {
            //                    CreateSettings();
            //                }
            //            }
            //        }
            //    }
            //}


            //if (set) {
            //    if (!Directory.Exists(Setting.Path))Directory.CreateDirectory(Setting.Path);
            // //   if (!Directory.Exists(Setting.Path+"\\Logs"))Directory.CreateDirectory(Setting.Path+"\\Logs");
            //    if (!Directory.Exists(Setting.Path+"\\Worlds"))Directory.CreateDirectory(Setting.Path+"\\Worlds");
            //  //  if (!Directory.Exists(Setting.Path+"\\Servers"))Directory.CreateDirectory(Setting.Path+"\\Servers");
            //} else {
                if (runWithArgs) {
                    Setting.Name=Environment.GetCommandLineArgs()[3];
                 //   Global.Logged=true;
                   // Global.OnlineAccount=false;
                    Setting.Path=Environment.GetCommandLineArgs()[2]+"\\"+Setting.Name+"\\";
                    //if (!Directory.Exists(Setting.Path+"\\RabcrData")){
                    //    MessageBox.Show("Nenalezeny data hry, pravděpodobně hra byla spuštěna z archivu","Nenalezeny data hry");
                    //    Environment.Exit(-1);
                    //    return;
                    //}
                 //   if (!File.Exists(Path.GetTempPath()+"\\rabcrLastPassword.txt")) File.WriteAllText(Path.GetTempPath()+"\\rabcrLastPassword.txt",Setting.Name);
                } else {
                    Setting.Name="Player";
                   // Global.Logged=false;
                   // Global.OnlineAccount=false;

                    Setting.Path=GetPathIfNotArgs();
                    
                    //if (File.Exists(Path.GetTempPath()+"\\rabcrLastPassword.txt")) File.Delete(Path.GetTempPath()+"\\rabcrLastPassword.txt");
                }

                if (!Directory.Exists(Setting.Path))Directory.CreateDirectory(Setting.Path);
           //     if (!Directory.Exists(Setting.Path+"\\Logs"))Directory.CreateDirectory(Setting.Path+"\\Logs");
                if (!Directory.Exists(Setting.Path+"\\Worlds"))Directory.CreateDirectory(Setting.Path+"\\Worlds");
              //  if (!Directory.Exists(Setting.Path+"\\Servers"))Directory.CreateDirectory(Setting.Path+"\\Servers");

                //Log.Init();

                if (!Directory.Exists(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"\\RabcrData")) {
                    switch (System.Globalization.CultureInfo.CurrentCulture.EnglishName){ 
                         default:
                            MessageBox.Show("Game data not found, game was probably runned from archive"
                            #if DEBUG
                            +"\r\nCheck dir: "+new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName
                            #endif
                            ,"Error - Game data not found");
                            break;

                         case "Czech":
                            MessageBox.Show("Nenalezeny data hry, pravděpodobně hra byla spuštěna z archivu"
                            #if DEBUG
                            +"\r\nZkontrolujte složku: "+new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName
                            #endif
                            ,"Chyba - Nenalezeny data hry");
                            break;
                    }
                   

                    Environment.Exit(-1);
                    return;
                }

                if (!File.Exists(Setting.Path+@"\Setting.bin")) Setting.CreateSettings();
                else {
                    try {
                        Setting.LoadSetting();
                    } catch {
                        Setting.CreateSettings();
                    }
                }

            #endregion

            GraphicsManager = new GraphicsDeviceManager(this);
            Graphics=GraphicsManager.GraphicsDevice;

            GraphicsManager.PreferredBackBufferHeight =(int)(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height*0.6667f);
            GraphicsManager.PreferredBackBufferWidth = (int)(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width*0.6667f);
           

            try {
                GraphicsManager.ApplyChanges();
            } catch{ }

            Lang.Load();
            SetLangUp();
            Content = new ContentManager(Services, "RabcrData");
            content=Content;
       
            (Pixel = new Texture2D(GraphicsDevice, 1, 1)).SetData(new[] { Color.White });

            random=new FastRandom();

            Window.Position=new Microsoft.Xna.Framework.Point((int)(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width/6f),(int)(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height/7f));
            {
                Form MyGameForm = (Form)Control.FromHandle(Window.Handle);
                MyGameForm.LocationChanged+=Window_ClientSizeChanged;
                MyGameForm.FormClosing+=MyGameForm_FormClosing;
                MyGameForm.MinimumSize=new Size(320, 200);
                MyGameForm.SizeChanged+=Window_ClientSizeChanged;
                MyGameForm.StartPosition=FormStartPosition.CenterScreen;
            } 
        }

        public static void SetLangUp(){
            GC.Collect();
            GC.WaitForPendingFinalizers();

            switch (Lang.Languages[Setting.CurrentLanguage].FontFile){
                case "arabic":
                    BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_arabic_34);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_arabic_18);
                    break;

                case "cyrillic":
                    BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_cyrillic_34);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_cyrillic_18);
                    break;

                case "japanese":
                    BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_japanese_34);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_japanese_18);
                    break;

                case "traditionalChinese":
                    BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_traditionalChinese_34);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_traditionalChinese_18);
                    break;
                    
                case "korean":
                    BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_korean_34);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_korean_18);
                    break;

                default:
                    BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_latin_34);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_latin_18);
                    break;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        string GetPathIfNotArgs(){
           // string path="";

            //try {
            //    RegistryKey myKey = Registry.CurrentUser.OpenSubKey(@"Software\rabcr", false);
            //    path = (string)myKey.GetValue("InstallLocation");
            //} catch { }
            //if (path!="") return path;

            //try {
            //    RegistryKey myKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\rabcr", false);
            //    path = (string)myKey.GetValue("InstallLocation");
            //} catch { }
            //if (path!="") return path;

            //try {
            //    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)+"\\rabcr\\InstallLocation.txt")) path=File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)+"\\rabcr\\InstallLocation.txt");
            //} catch { }
            //if (path!="") return path;

            return new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"\\"+Setting.Name+"\\";
        }

        void MyGameForm_FormClosing(object sender, FormClosingEventArgs e) {
            Console.WriteLine("Closing game");
            exiting=true;
            screen.Shutdown();

            if (Global.ChangedSettings || !File.Exists(Setting.Path+@"\Setting.bin")) {Setting.SaveSetting(); if (exiting) saved=true;}
            else {
                saved=true;
            }

            if (!saved) e.Cancel=true;
        }

        void Window_ClientSizeChanged(object sender, EventArgs e) {
            int befW=Window.ClientBounds.Width,
                befH=Window.ClientBounds.Height;
            bool resize=false;

            if (Global.WindowWidth!=befW){
                Global.WindowWidthHalf=(Global.WindowWidth=befW)/2;

                if (Global.WindowWidthHalf!=0){
                    GraphicsManager.PreferredBackBufferWidth = befW;
                    resize=true;
                }
            }

            if (Global.WindowHeight!=befH){
                Global.WindowHeightHalf=(Global.WindowHeight=befH)/2;

                if (Global.WindowHeightHalf!=0){
                    GraphicsManager.PreferredBackBufferHeight = befH;
                    resize=true;
                }
            }

            if (resize){
                GraphicsManager.ApplyChanges();
                if (screen!=null) screen.Resize();
            }
        }

        protected override void LoadContent() {
            spriteBatch=new SpriteBatch(GraphicsDevice);
 IsMouseVisible = true;
            Window.AllowUserResizing = true;

            GoTo(new Start());
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime) {
            newMouseState=Mouse.GetState();
            ActiveWindow=IsActive;
            screen.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            screen.Draw(gameTime);
            base.Draw(gameTime);
        }

        public static void GoTo(Screen name) {
            if (screen!=null) {
                if (!screen.isDisposed) screen.Shutdown(); 
            }
            name.Init();
            screen=name;
        }

        //public void CreateSettings() {
        //   // Console.WriteLine("Creating new settings");
        //    try {
        //        if (File.Exists(Setting.Path+@"\Setting.bin")) File.Delete(Setting.Path+@"\Setting.bin");
        //    } catch {}

        //    Lang.SetUp(true);

        //    SaveSetting();
        //}

        //public static void SaveSetting() {
        //    //if (!Global.ChangedSettings){
        //    //    return;
        //    //}
        //    Global.ChangedSettings=false;
        //    #if DEBUG
        //    Debug.WriteLine("Ukládání nastavení... ");
        //    #endif

        //    List<byte> bytes = new List<byte> {
        //        (byte)Setting.sex,
        //        (byte)Setting.MaturePlayer,
        //        (byte)Setting.hairType,
        //        (byte)Setting.moustageType,
        //        Setting.hairColor.R,
        //        Setting.hairColor.G,
        //        Setting.hairColor.B,

        //        Setting.ColorSkin.R,
        //        Setting.ColorSkin.G,
        //        Setting.ColorSkin.B,

        //        Setting.eyesColor.R,
        //        Setting.eyesColor.G,
        //        Setting.eyesColor.B,

        //        Setting.moustageColor.R,
        //        Setting.moustageColor.G,
        //        Setting.moustageColor.B,

        //        (byte)Setting.KeyLeft,
        //        (byte)Setting.KeyRight,
        //        (byte)Setting.KeyJump,
        //        (byte)Setting.KeyRun,
        //        (byte)Setting.KeyFlyMode,
        //        (byte)Setting.KeyInventory,
        //        (byte)Setting.KeyMessage,
        //        (byte)Setting.KeyDropItem,
        //        (byte)Setting.KeyExit,
        //        (byte)Setting.KeyShowInfo,

        //        (byte)Setting.CurrentLanguage,
        //        Constants.AnimationsControls ? (byte)1 : (byte)0,
        //        Constants.AnimationsGame ? (byte)1 : (byte)0,
        //      //  Constants.Shadow ? (byte)1 : (byte)0,
        //        (byte)Setting.GraphicsProfile,

        //        (byte)Setting.currentScale,
        //        (byte)Setting.currentWindow,
        //        Setting.Background ? (byte)1: (byte)0,
        //        Global.YoungPlayer ? (byte)1: (byte)0,
        //        Setting.Fps ? (byte)1: (byte)0,
        //    };
        //    bytes.AddRange(BitConverter.GetBytes(Setting.VolumeMusic));
        //    bytes.AddRange(BitConverter.GetBytes(Setting.VolumeEffects));
        //    bytes.AddRange(BitConverter.GetBytes(Setting.slideChangeTime));
        //    bytes.AddRange(BitConverter.GetBytes(Setting.Zoom));
        //    bytes.AddRange(BitConverter.GetBytes(Setting.NightBrightness));
                
          

        //    File.WriteAllBytes(Setting.Path+@"\Setting.bin",bytes.ToArray());
        //    //Debug.Write(" Uloženo!");

        //    //if (Global.OnlineAccount && Global.Logged) UploadAccountSetting();
        //    //else 
        //    if (exiting)saved=true;
        //}

        //public static void UploadAccountSetting() {
        //    if (Global.OnlineAccount && Global.Logged) {
        //        #if DEBUG
        //        Debug.WriteLine("Ukládání nastavení na server...");
        //        #endif
        //        byte[] file=File.ReadAllBytes(Setting.Path+@"\Setting.bin");
        //        var settingFile=Convert.ToBase64String(file);
        //        string url="https://geftgames.ga/System/rabcr/setdata.php?username="+Setting.Name+"&password="+Global.Pass+"&data="+settingFile;
        //        MyWebClient wc = new MyWebClient {
        //            Encoding=Encoding.UTF8
        //        };

        //        wc.DownloadStringCompleted+=Wc_DownloadStringCompleted;
        //        wc.DownloadStringAsync(new Uri(url));
        //    }
        //}

        //static void Wc_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e) {
        //    if (Global.OnlineAccount && Global.Logged) {
        //        string get=e.Result;
        //         //Log.WriteLine(get);
        //        if (string.IsNullOrEmpty(get)){
        //            #if DEBUG
        //            throw new Exception("Error get is empty");
        //            #endif
        //        } else {
        //            string[]g=get.Split('|');

        //            if (g.Length>1){
        //                switch (g[0]) {
        //                    case "E":
        //                        #if DEBUG
        //                        Debug.Write("Error "+g[1]);
        //                        #endif
        //                        break;

        //                    case "I":
        //                        #if DEBUG
        //                        Debug.Write("Inicialized");
        //                        #endif
        //                        break;

        //                    case "O":
        //                        #if DEBUG
        //                        Debug.Write("OK");
        //                        #endif
        //                        break;

        //                    #if DEBUG
        //                    default: throw new Exception("Neznámá chyba");
        //                    #endif
        //                }
        //            } else Debug.Write("Neznámá chyba");
        //        }
        //    }

        //    #if DEBUG
        //    else Debug.Write("Jejda odhlásili jste se");
        //    #endif
        //    if (exiting){
        //        saved=true;
        //        Environment.Exit(0);
        //    }
        //}

        //public unsafe static void LoadSetting() {
        //    #if DEBUG
        //    Debug.WriteLine("Načítání nastavení... ");
        //    #endif
        //    string pth=Setting.Path+@"\Setting.bin";

        //    if (File.Exists(pth)) {
        //        byte[] bytes=File.ReadAllBytes(pth);

        //        fixed (byte* pointer=&bytes[0]) {
        //            byte* current=pointer;

        //            Setting.sex =(Sex)(*current++);
        //            Setting.MaturePlayer = *current++;
        //            Setting.hairType= *current++;
        //            Setting.moustageType= *current++;
        //            Setting.hairColor = new Color(*current++,*current++,*current++);
        //            Setting.ColorSkin = new Color(*current++,*current++,*current++);
        //            Setting.eyesColor = new Color(*current++,*current++,*current++);
        //            Setting.moustageColor = new Color(*current++,*current++,*current++);

        //            Setting.KeyLeft = (Keys)(*current++);
        //            Setting.KeyRight =(Keys)(*current++);
        //            Setting.KeyJump=(Keys)(*current++);
        //            Setting.KeyRun=(Keys)(*current++);
        //            Setting.KeyFlyMode=(Keys)(*current++);
        //            Setting.KeyInventory=(Keys)(*current++);
        //            Setting.KeyMessage=(Keys)(*current++);
        //            Setting.KeyDropItem=(Keys)(*current++);
        //            Setting.KeyExit=(Keys)(*current++);
        //            Setting.KeyShowInfo=(Keys)(*current++);

        //            Setting.CurrentLanguage=*current++;
        //            Constants.AnimationsControls=(*current++) == 1;
        //            Constants.AnimationsGame=(*current++) == 1;
        //           // Constants.Shadow=(*current++) == 1;
        //            Setting.GraphicsProfile=(GraphicsProfile)(*current++);


        //            Setting.currentScale=(Setting.Scale)(*current++);
        //            Setting.currentWindow=(Setting.Window)(*current++);

        //            Setting.Background = (*current++) == 1;
        //            Global.YoungPlayer = (*current++) == 1;
        //            Setting.Fps= (*current++) == 1;

        //            Setting.VolumeMusic=GetFloat();
        //            Setting.VolumeEffects=GetFloat();
        //            Setting.slideChangeTime=GetFloat();
        //            Setting.Zoom=GetFloat();
        //            Setting.NightBrightness=GetFloat();

        //            if (Setting.Zoom<=0)Setting.Zoom=2;

        //            if (Global.HasSoundGraphics) MediaPlayer.Volume=Setting.VolumeMusic;

        //            float GetFloat() {
        //                int n=(*current++) | (*current++ << 8) | (*current++ << 16) | (*current++ << 24);
        //                return *(float*)&n;
        //            }
        //        }
        //    }
        //    #if DEBUG
        //    else Debug.Write("Soubor nastavení neexistuje!");
        //    #endif

        //    //Log.Write("Načteno!");
        //}

        //void ActivateMyGame(object sendet, EventArgs args) => ActiveWindow = true;

        //void DeactivateMyGame(object sendet, EventArgs args) => ActiveWindow = false;

       //public unsafe static Texture2D ColorizeTexture(Texture2D source, Color colorize){
       //     return source;
       //     //Color[] data = new Color[source.Width * source.Height];
       //     //source.GetData(data);

       //     //Texture2D ret=new Texture2D(GraphicsManager.GraphicsDevice,source.Width,source.Height);

       //     //fixed (Color* pointerColor=&data[0]){
       //     //    byte* pointerByte=(byte*)pointerColor;

       //     //    int len=data.Length-1;
       //     //    for (int i=0; i<len; i++) {
       //     //        // A
       //     //        pointerByte++;
       //     //        float z=(*(pointerByte+3))/255f;

       //     //        // B
       //     //        *pointerByte=(byte)((*pointerByte)*z);
       //     //        pointerByte++;

       //     //        //G
       //     //        *pointerByte=(byte)((*pointerByte)*z);
       //     //        pointerByte++;

       //     //        //R
       //     //        *pointerByte=(byte)((*pointerByte)*z);
       //     //        pointerByte++;
       //     //    }
       //     //    {
       //     //      pointerByte++;
       //     //       // float divider = 1;
       //     //        float z=(*(pointerByte+3))/255f;


       //     //        *pointerByte=(byte)((*pointerByte)*z);
       //     //        pointerByte++;
       //     //        *pointerByte=(byte)((*pointerByte)*z);
       //     //        pointerByte++;
       //     //        *pointerByte=(byte)((*pointerByte)*z);
       //     //    }
       //     //}

       //     //int len=data.Length;
       //     //for (int i=0; i<len; i++) {
       //     //    Color s=data[i];

       //     //    if (s.A!=0){
       //     //      //  float gray=(s.R+s.G+s.B)/6f+128;
       //     //        int z=s.R;
       //     //        float divider = 1/255f;
       //     //        data[i] = new Color(
       //     //           (byte)(colorize.R*z*divider/*/255f*/)/* DoChanel(colorize.R)*/,
       //     //           (byte)(colorize.G*z*divider/*/255f*/)/* DoChanel(colorize.G)*/,
       //     //           (byte)(colorize.B*z*divider/*/255f*/)/* DoChanel(colorize.B)*/,
       //     //            s.A);

       //     //        //int DoChanel(int col){
       //     //        //   //int n;
       //     //        //    //int delta=col-sou;
       //     //        //    //if (gray<sou)
       //     //        //    //    n= sou+(int)(delta*((float)gray/sou));
       //     //        //    //else
       //     //        //    //    n= sou+(int)(delta*((float)sou/gray));

       //     //        //    //if (col>sou){

       //     //        //    //    return col*0;
       //     //        //    //}else{
       //     //        //    //    return col+(255-col)
       //     //        //    //}
       //     //        //   // if (gray>col){
       //     //        //        //make lighter
       //     //        //        return (int) (col*z/255f);
       //     //        //   // }else{
       //     //        //   //     return col*gray;
       //     //        //   // }
       //     //        //   // return (int)(col);

       //     //        //   // return n;
       //     //        //}
       //     //    }


       //     //}


       //     //ret.SetData(data);

       //     //return ret;
       // }
    }
}