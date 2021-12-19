using Microsoft.Xna.Framework;
using MessageBox=System.Windows.Forms.MessageBox;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace rabcrClient {
    class Message: Game {

        #region Varibles
        MouseState newMouseState, oldMouseState;
        SpriteBatch spriteBatch;
        readonly GraphicsDeviceManager GraphicsManager;
        //readonly GraphicsDevice Graphics;

        GeDo gedo;
        GameButtonMedium ok;
        readonly string Text;
        readonly Effect effectColorize;
        #endregion

        public Message(int language, string text, string Header="Message") {
            Rabcr.Game=this;

            GraphicsManager= new GraphicsDeviceManager(this);
            Content.RootDirectory = "RabcrData";
            IsMouseVisible = true;

            // Set up settings
            Setting.CurrentLanguage=language;
            Constants.AnimationsControls=true;
            Text=text;

            Lang.SetUp(false);

        //    Text=Environment.GetCommandLineArgs()[2].Replace("\r\n","<NewLine>")+"<NewLine>";


            Window.Title = Header;

            GraphicsManager.ApplyChanges();

            SetLangUp();
          //  BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_latin_18);
            effectColorize=Content.Load<Effect>("Default/Effects/Colorize");

            oldMouseState=new MouseState();

            //   if (runWithArgs) {
            //         Setting.Name=Environment.GetCommandLineArgs()[3];
            //      //   Global.Logged=true;
            //        // Global.OnlineAccount=false;
            //         Setting.Path=Environment.GetCommandLineArgs()[2]+"\\"+Setting.Name+"\\";
            //         //if (!Directory.Exists(Setting.Path+"\\RabcrData")){
            //         //    MessageBox.Show("Nenalezeny data hry, pravděpodobně hra byla spuštěna z archivu","Nenalezeny data hry");
            //         //    Environment.Exit(-1);
            //         //    return;
            //         //}
            //      //   if (!File.Exists(Path.GetTempPath()+"\\rabcrLastPassword.txt")) File.WriteAllText(Path.GetTempPath()+"\\rabcrLastPassword.txt",Setting.Name);
            //     } else {
            //         Setting.Name="Player";
            //        // Global.Logged=false;
            //        // Global.OnlineAccount=false;

            //         Setting.Path=GetPathIfNotArgs();

            //         //if (File.Exists(Path.GetTempPath()+"\\rabcrLastPassword.txt")) File.Delete(Path.GetTempPath()+"\\rabcrLastPassword.txt");
            //     }

            //     if (!Directory.Exists(Setting.Path))Directory.CreateDirectory(Setting.Path);
            ////     if (!Directory.Exists(Setting.Path+"\\Logs"))Directory.CreateDirectory(Setting.Path+"\\Logs");
            //     if (!Directory.Exists(Setting.Path+"\\Worlds"))Directory.CreateDirectory(Setting.Path+"\\Worlds");
            //   //  if (!Directory.Exists(Setting.Path+"\\Servers"))Directory.CreateDirectory(Setting.Path+"\\Servers");

            //     //Log.Init();

            //     if (!Directory.Exists(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"\\RabcrData")) {
            //         switch (System.Globalization.CultureInfo.CurrentCulture.EnglishName){
            //              default:
            //                 MessageBox.Show("Game data not found, game was probably runned from archive"
            //                 #if DEBUG
            //                 +"\r\nCheck dir: "+new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName
            //                 #endif
            //                 ,"Error - Game data not found");
            //                 break;

            //              case "Czech":
            //                 MessageBox.Show("Nenalezeny data hry, pravděpodobně hra byla spuštěna z archivu"
            //                 #if DEBUG
            //                 +"\r\nZkontrolujte složku: "+new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName
            //                 #endif
            //                 ,"Chyba - Nenalezeny data hry");
            //                 break;
            //         }


            //         Environment.Exit(-1);
            //         return;
            //     }

            //     if (!File.Exists(Setting.Path+@"\Setting.bin")) Setting.CreateSettings();
            //     else {
            //         try {
            //             Setting.LoadSetting();
            //         } catch {
            //             Setting.CreateSettings();
            //         }
            //     }

            //#endregion


            //Graphics = GraphicsManager.GraphicsDevice;

           /* Rabcr.*/GraphicsManager.PreferredBackBufferHeight =(int)(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height*0.66667f);
           /* Rabcr.*/GraphicsManager.PreferredBackBufferWidth = (int)(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width*0.66667f);


            try {
                GraphicsManager.ApplyChanges();
            } catch{ }

            //Lang.Load();
            //SetLangUp();


        }


        public static void SetLangUp(){
            GC.Collect();
            GC.WaitForPendingFinalizers();

            switch (Lang.Languages[Setting.CurrentLanguage].FontFile) {
                case "arabic":
                 //   BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_arabic_34);
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_arabic_18);
                    break;

                case "cyrillic":
                    //BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_cyrillic_34);
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_cyrillic_18);
                    break;

                case "japanese":
                    //BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_japanese_34);
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_japanese_18);
                    break;

                case "traditionalChinese":
                    //BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_traditionalChinese_34);
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_traditionalChinese_18);
                    break;

                case "korean":
                    //BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_korean_34);
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_korean_18);
                    break;

                default:
                    //BitmapFont.bitmapFont34=new BitmapFont(34,Properties.Resources.FontInfo_latin_34);
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                    BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_latin_18);
                    break;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        //    Rabcr.random=new FastRandom();
            Rabcr.ActiveWindow=IsActive;
            (Rabcr.Pixel=new Texture2D(GraphicsDevice, 1, 1)).SetData(new[] { Color.White });

            Textures.ButtonCenter=GetDataTexture(@"Buttons\Menu\Center");

            GraphicsManager.PreferredBackBufferWidth=840;

            gedo=new GeDo(5, 5);
            gedo.changeHeight+=ChangeH;
            gedo.width=GraphicsManager.PreferredBackBufferWidth-10-20;
            #if !DEBUG
            try{
            #endif
            gedo.BuildString(Text.Replace("<NewLine>","\r\n"));
            #if !DEBUG
            }catch (Exception ex){

                gedo.BuildString(string.IsNullOrEmpty(ex.Message) ? "Error, nesprávná syntaxe": ex.Message);
            }
            #endif

            ok=new GameButtonMedium(Textures.ButtonCenter) {
                Text=Lang.Texts[1498]
            };

            GraphicsManager.PreferredBackBufferHeight=50+gedo.GetHeight;

            ok.Position=new Vector2(245+100, GraphicsManager.PreferredBackBufferHeight-50);
            GraphicsManager.ApplyChanges();
        }

        //string GetPathIfNotArgs(){
        //    return new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"\\"+Setting.Name+"\\";
        //}

        private void ChangeH(object sender, EventArgs e) {
            GraphicsManager.PreferredBackBufferHeight = 50+gedo.GetHeight;
            GraphicsManager.PreferredBackBufferWidth = 840;

            ok.Position=new Vector2(245+100, GraphicsManager.PreferredBackBufferHeight-50);
            GraphicsManager.ApplyChanges();
        }

        protected override void Update(GameTime gameTime) {
            Rabcr.ActiveWindow=IsActive;
            ok.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            Rabcr.newMouseState=newMouseState =Mouse.GetState();
            Rabcr.spriteBatch=spriteBatch;
            MousePos.mouseLeftDown=newMouseState.LeftButton==ButtonState.Pressed;
            MousePos.mouseLeftRelease=newMouseState.LeftButton==ButtonState.Released && oldMouseState.LeftButton==ButtonState.Pressed;
            MousePos.mouseRealPosX=newMouseState.X;
            MousePos.mouseRealPosY=newMouseState.Y;
            GraphicsManager.GraphicsDevice.Clear(Color.White);
            effectColorize.CurrentTechnique.Passes[0].Apply();

            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,effectColorize,null);

            gedo.DrawGedo(255, spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin();

            ok.ButtonDraw();
            if (ok.Update()){Exit();  }

            spriteBatch.End();
            oldMouseState=newMouseState;
        }

        Texture2D GetDataTexture(string path) {
            try {
                return Content.Load<Texture2D>(Setting.StyleName+"\\Textures\\"+path);
            } catch {
                Console.WriteLine("Nelze načíst texturu: "+Setting.StyleName+"\\Textures\\"+path+Environment.NewLine);
                Environment.Exit(0);
            }

            return null;
        }
    }
}