//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Threading;

//namespace rabcrClient {
//    class MenuStyle :MenuScreen {

//        #region Varibles
//        List<Style>styles=new List<Style>();
//        Button AddPackButton,OpenfolderButton;
//        //int height;
//        Texture2D scrollbarTopTexture,scrollbarBottomTexture,scrollbarCenterTexture;
//     //   SpriteFont Fonts.Small, Fonts.SmallItalic, Fonts.Medium, Fonts.Big;
//        Button buttonMenu;
//      //  KeyboardState newKeyboardState/*, oldKeyboardState*/;
//      //  MouseState Menu.newMouseState, Menu.oldMouseState;
//        Texture2D packChecking,packUsed,/*webPacks,*/packError,packInfo;
//      //  string header=Lang.Texts[9];
//        //int pressed;

//        bool Error;
//        Thread packCheckingProcess;
//        string errors;
//      bool mouse;
//        int gameStyle;
////        Texture2D buttonPlayTexture;
////        Texture2D longButton;
//        bool finish;
//        float angleChecking;   Effect effectBlur;
//       RenderTarget2D worldsTarget;
//   //     SpriteFont Fonts.Biggest;
//        Scrollbar scrollbar;
//        int timer;
//        #endregion

//        public override void Init() {
//      //      Fonts.SmallItalic = GetDataFont("SmallItalic");
//      //      Fonts.Small = GetDataFont("Small");
//		    //Fonts.Medium = GetDataFont("Medium");
//      //      Fonts.Big = GetDataFont("Big");
//      //      if (Setting.BetterFont) Fonts.Biggest=GetDataFont("Biggest");
//          //   worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65-2);

//          //  buttonPlayTexture = Textures.ButtonLeft;
//            buttonMenu = new Button(Textures.ButtonLongLeft/*, Fonts.Medium, Fonts.Big,true*/);
//            AddPackButton = new Button(Textures.ButtonLeft/*, Fonts.Medium, Fonts.Big,true*/);
//            OpenfolderButton = new Button(Textures.ButtonRight/*, Fonts.Medium, Fonts.Big,true*/);
//            scrollbarTopTexture = GetDataTexture("Buttons/Scrollbar/Top");
//            scrollbarCenterTexture = GetDataTexture("Buttons/Scrollbar/Center");
//            scrollbarBottomTexture = GetDataTexture("Buttons/Scrollbar/Bottom");
//            //webPacks=GetDataTexture("Menu/Styles/Find");
//            packInfo=GetDataTexture("Menu/Styles/Info");
//            packUsed=GetDataTexture("Menu/Styles/Used");
//            packChecking=GetDataTexture("Menu/Styles/Checking");
//            packError=GetDataTexture("Menu/Styles/Error");



//            {
//                Style def = new Style("Default", Version.This, "GeftGames", "Výchozí styl hry", Version.This) {
//                    Image=GetDataTexture("Menu/Styles/Default"),
//                    DirectoryName="Default",
//                    state=Style.State.UsingThisGameStyle
//                };
//                def.geDo=new GeDo(Fonts.Small,def.Message);
//              //  def.geDo.BuildString();
//                styles.Add(def);
//            }

//            scrollbar=new Scrollbar(scrollbarTopTexture,scrollbarCenterTexture,scrollbarBottomTexture){
//              //  height=Global.WindowHeight-75-65-2
//            };

//            effectBlur=Effects.BluredTopDownBounds;

//            //effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
//            //effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);

//            scrollbar.PositionY=76;
//            FindStyles();
//            //InicializeTransform();
//           // SetTexts();
//             buttonMenu.Text=Lang.Texts[1];
//            AddPackButton.Text=Lang.Texts[16];
//            OpenfolderButton.Text=Lang.Texts[19];


//            AddPackButton.center=true;
//            OpenfolderButton.center=true;
//            Resize();
//        }

//        public override void Update(GameTime gameTime) {
//            //Menu.oldMouseState=Menu.newMouseState;
//            ////oldKeyboardState=newKeyboardState;

//            //newKeyboardState=Keyboard.GetState();
//            //Menu.newMouseState=Mouse.GetState();

//            //UpdateTransform();
//            //back.Update();


//             if (Menu.newKeyboardState.IsKeyDown(Keys.Up)) scrollbar.Scroll(-2);
//            if (Menu.newKeyboardState.IsKeyDown(Keys.Down)) scrollbar.Scroll(2);

//            if (Menu.newKeyboardState.IsKeyDown(Keys.PageUp)) scrollbar.Scroll(-5);
//            if (Menu.newKeyboardState.IsKeyDown(Keys.PageDown)) scrollbar.Scroll(5);

//            if (Menu.newMouseState.ScrollWheelValue!=Menu.oldMouseState.ScrollWheelValue) {
//                scrollbar.Scroll((Menu.oldMouseState.ScrollWheelValue-Menu.newMouseState.ScrollWheelValue)/2f);
//            }

//            if (buttonMenu.Click) {
//                //goingA=true;
//                ((Menu)Rabcr.screen).GoToMenu(new MainMenu());
//            }

//            if (AddPackButton.Click) {
//             using(   System.Windows.Forms.OpenFileDialog ofd=new System.Windows.Forms.OpenFileDialog()){
//               // if (Setting.czechLanguage) {
//                    ofd.Filter=Lang.Texts[79]+"|*.zip";
//                    ofd.Title=Lang.Texts[9];
//                //} else {
//                //    ofd.Filter="Zip Archive|*.zip";
//                //    ofd.Title="Game style";
//                //}
//                ofd.ShowDialog();

//                if (File.Exists(ofd.FileName)) {
//                    //ICSharpCode.SharpZipLib.Zip.FastZip zip=new ICSharpCode.SharpZipLib.Zip.FastZip();
//                    //zip.EntryFactory=new ICSharpCode.SharpZipLib.Zip.IEntryFactory();
//                    Extract(ofd.FileName, new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).Directory.FullName+@"\RabcrData\"+(new FileInfo(ofd.FileName).Name).Substring(0, (new FileInfo(ofd.FileName).Name).LastIndexOf(".")));
//                    // zip.ExtractZip(ofd.FileName,(new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).Directory.FullName+@"\RabcrData\"+new FileInfo(ofd.FileName).Name).Substring(0,(new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).Directory.FullName+@"\RabcrData\"+new FileInfo(ofd.FileName).Name).LastIndexOf(".")),null);
//                } }
//            }

//             int yy=(int)(-(styles.Count-(Global.WindowHeight-75-65)/100f)*100*scrollbar.scale)-65/*-55*/;

//            for (int i = 0;i<styles.Count; i++) {
//                  //if (i>=Worlds.Count)break;
//                if (yy>-70-70 && yy<Global.WindowHeight-75-65-70) {



//                    //if (styles[i].ButtonSetting.Click) {
//                    //    EditSingleWorld(styles[i].directoryName);
//                    //    if (Worlds.Count==0)break;
//                    //}
//                    //if (styles[i].ButtonPlay.Click){
//                    //    RunGame(styles[i].directoryName);
//                    //    }// (spriteBatch,Menu.newMouseState.LeftButton==ButtonState.Pressed,1,new Vector2(Menu.newMouseState.X,Menu.newMouseState.Y-75),new Vector2(105+38,yy+100));
//                    ////                    #region Button join

//                } }

//            if (OpenfolderButton.Click) {
//                System.Diagnostics.Process.Start(new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).Directory.FullName+"\\RabcrData");
//            }

//            if (finish){
//                if (Error){
//                    styles[gameStyle].Errored=true;
//                    styles[gameStyle].ContentErrors=errors;
//                    styles[gameStyle].state=Style.State.Errored;
//                    Error=false;
//                    errors="";
//                }else{
//                    //styles[gameStyle].state=Style.State.ApplyingOk;
//                    Setting.StyleName=styles[gameStyle].DirectoryName;
//                    SetPack();

//                    if (Error){
//                        styles[gameStyle].Errored=true;
//                        styles[gameStyle].ContentErrors=errors;
//                        styles[gameStyle].state=Style.State.Errored;
//                    }else{
//                        styles[gameStyle].state=Style.State.UsingThisGameStyle;
//                        //Setting.StyleName=styles[gameStyle].DirectoryName;
//                       // SetPack();
//                    }
//                }

//                finish=false;
//            }

//            if (timer<0){
//            FindStyles();
//                timer=60;
//            }else timer--;
//            //if (packCheckingProcess!=null) {
//            //    if (!packCheckingProcess.IsAlive) {

//                   // if (xtimer<0) {
//                     //   FindStyles();
//                        //List<Style> styles=new List<Style>();

//                        //{
//                        //    Texture2D x=null;
//                        //    try {
//                        //        x=Content.Load<Texture2D>("Default\\GameStyle\\DefaultPack");
//                        //    } finally {
//                        //        Style style = new Style("Výchozí", "", "Geft", "<Blue>V</Blue><Brown>ý</Brown><Yellow>ch</Yellow><LightGreen>o</LightGreen><Pink>z</Pink><Gray>í</Gray> <Green>s</Green><Red>t</Red><LightBlue>y</LightBlue><Purple>l</Purple> <Azure>h</Azure><Gold>r</Gold><Orange>y</Orange>", "", x) {
//                        //            fileName="none",
//                        //            geDo=new GeDo(Fonts.Small, Fonts.SmallItalic, pixel)
//                        //        };
//                        //        style.geDo.BuildString("<Blue>V</Blue><Brown>ý</Brown><Yellow>ch</Yellow><LightGreen>o</LightGreen><Pink>z</Pink><Gray>í</Gray> <Green>s</Green><Red>t</Red><LightBlue>y</LightBlue><Purple>l</Purple> <Azure>h</Azure><Gold>r</Gold><Orange>y</Orange>");

//                        //        bool t=true;
//                        //        foreach (Style s in styles) {
//                        //        if (style.fileName==s.fileName)t=false;
//                        //        }
//                        //        if (t)styles.Add(style);

//                        //    }
//                        //}
//                        //int xx=0;

//                        // foreach (Style s in styles) {
//                        //if (!Directory.Exists(s.fileName) && s.fileName!="none") {
//                        // styles.Remove(s);
//                        // break;
//                        // }
//                        //}

//                        //foreach (string x in Directory.GetDirectories(System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0,System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf("\\"))+"\\RabcrData")) {
//                        //    xx++;
//                        //    if (new DirectoryInfo(x).Name!="Default") {  //  Console.WriteLine(x);
//                        //        if (File.Exists(x+"\\Style.txt")) {
//                        //            using (StreamReader sr=new StreamReader(x+"\\Style.txt")) {

//                        //            Style style=null;
//                        //           // try {
//                        //           //Console.WriteLine(x+"\\Image.xnb");
//                        //                if (File.Exists(x+"\\Image.xnb")) {
//                        //                 //   try {
//                        //                        style=new Style(sr.ReadLine(),sr.ReadLine(),sr.ReadLine(),sr.ReadLine(),sr.ReadLine(),Content.Load<Texture2D>(new DirectoryInfo(x).Name+"\\Image"));
//                        //                   // } catch {}
//                        //                } else style=new Style(sr.ReadLine(),sr.ReadLine(),sr.ReadLine(),sr.ReadLine(),sr.ReadLine());
//                        //                style.fileName=new DirectoryInfo(x).Name;
//                        //                  //style.Checking= styles[xx].Checking;

//                        //                style.geDo=new GeDo(Fonts.Small,Fonts.SmallItalic,pixel);
//                        //                style.geDo.BuildString(style.Message);

//                        //                   bool t=true;
//                        //        foreach (Style s in styles) {
//                        //        if (style.fileName==s.fileName)t=false;
//                        //        }
//                        //        if (t)styles.Add(style);


//                        //         //styles.Add(style);
//                        //        //stylesMessages.Add(def);
//                        //               // }catch {}
//                        //            }
//                        //        }
//                        //    }


//                        //    //int c=0;
//                        //    //foreach (Style s in styles2) {
//                        //    //    if (styles.Count>c) {
//                        //    //        if (s!=styles[c]) {
//                        //    //            styles[c]=s;

//                        //    //        }
//                        //    //    } else {
//                        //    //        styles.Add(s);

//                        //    //    }
//                        //    //c++;
//                        //    //}


//                        //   // styles.Add(x);
//                        //}
//                       //     xtimer=120;
//                     //   }else xtimer--;
//                        //}
//                    //}

//            base.Update(gameTime);
//        }

//        public override void PreDraw() {

//            // Set
//            mouse=Menu.newMouseState.LeftButton == ButtonState.Pressed;
//            Vector2 mousePos=new Vector2(Menu.newMouseState.X,Menu.newMouseState.Y-75);
//            Graphics.SetRenderTarget(worldsTarget);
//            Graphics.Clear(Color.Transparent);
//            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend);

//            int yy=(int)(-(styles.Count-(Global.WindowHeight-75-65)/100f)*100*scrollbar.scale)-65/*-55*/;

//            for (int i = 0;i<styles.Count; i++) {
//                  //if (i>=Worlds.Count)break;
//                if (yy>-70-70 && yy<Global.WindowHeight-75-65-70) {
//         Style style=styles[i];
//                      if (style.AlphaButtonWant!=style.AlphaButton){
//                    if (style.AlphaButtonWant>style.AlphaButton){
//                        style.AlphaButton+=5;
//                    } else {
//                        style.AlphaButton-=5;
//                    }
//                }
//                if (mousePos.Y>70+80+yy-75 && mousePos.Y<70+80+yy-75+70   && Rabcr.ActiveWindow) {
//              //  if (Global.Active && (70+80+i*70-height+pressed>70 && 70+80+i*70-height+pressed<Global.WindowHeight-70)) {
//                    if (mouse) {
//                         if (style.state==Style.State.UsingThisGameStyle) style.AlphaButtonWant=200; else style.AlphaButtonWant=150;
//                    } else {
//                        if (Menu.oldMouseState.LeftButton==ButtonState.Pressed) {
//                            if (style.state==Style.State.NotTouch) {
//                                gameStyle=i;
//                                //CheckingPack();
//                                StartChechingPack();
//                            }

//                            if (style.state==Style.State.Ok) {
//                                Setting.StyleName=style.DirectoryName;
//                                SetPack();
//                                if (Error){
//                                    Error=false;
//                                    styles[gameStyle].state=Style.State.Errored;
//                                }else{
//                                     styles[gameStyle].state=Style.State.UsingThisGameStyle;
//                                }

//                            }
//                        }
//                        if (style.state==Style.State.UsingThisGameStyle) style.AlphaButtonWant=150; else style.AlphaButtonWant=100;
//                    }
//                } else {
//                    if (style.state==Style.State.UsingThisGameStyle) style.AlphaButtonWant=100; else style.AlphaButtonWant=0;
//                }


//                if (mousePos.X>28+64+5 && mousePos.Y>70+80+yy-75+20+5
//                && mousePos.X<28+64+5+32 && mousePos.Y<70+80+yy-75+20+5+32) {
//                    if (Rabcr.ActiveWindow) {
//                        if (mouse) {
//                            if (Menu.oldMouseState.LeftButton==ButtonState.Pressed) {
//                                if (i==0) {
//                                    System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//                                        "Verze: "+style.Version+Environment.NewLine+
//                                        "Autor: "+style.Author+Environment.NewLine+
//                                        "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//                                        "Název složky: "+style.DirectoryName,"Informace", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
//                                } else {
//                                    if (!style.Errored) {
//                                        System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//                                        "Verze: "+style.Version+Environment.NewLine+
//                                        "Autor: "+style.Author+Environment.NewLine+
//                                        "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//                                        "Název složky: "+style.DirectoryName,
//                                        "Informace", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
//                                    } else {

//                                        if (style.ContentErrors.Length>500) System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//                                                "Verze: "+style.Version+Environment.NewLine+
//                                                "Autor: "+style.Author+Environment.NewLine+
//                                                "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//                                                "Název složky: "+style.DirectoryName+Environment.NewLine+Environment.NewLine+
//                                                "Chyby: "+Environment.NewLine+style.ContentErrors.Substring(0, 500)+"...",
//                                                "Informace", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

//                                        else System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//                                            "Verze: "+style.Version+Environment.NewLine+
//                                            "Autor: "+style.Author+Environment.NewLine+
//                                            "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//                                            "Název složky: "+style.DirectoryName+Environment.NewLine+Environment.NewLine+
//                                            "Chyby: "+Environment.NewLine+style.ContentErrors,
//                                            "Informace", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//     //Console.WriteLine(70+80+yy-75-3);
//             //   if (70+80+yy-75>70 && 70+80+yy-75<Global.WindowHeight) {
//                    spriteBatch.Draw(Rabcr.Pixel,new Rectangle(28-3,70+80+yy-75-3,Global.WindowWidth-70,70),new Color(style.AlphaButton,style.AlphaButton,style.AlphaButton,style.AlphaButton));
//                    if (style.Image!=null) spriteBatch.Draw(style.Image,new Rectangle(28,70+80+yy-75,64,64),Color.White);
//                    DrawTextShadowMinSmall(100,70+80+yy-75+3,style.Name+" "+style.Version);

//                    spriteBatch.Draw(packInfo, new Vector2(28+64+5, 70+80+yy-75+20+5), Color.White);
//                    style.geDo.DrawGedo(spriteBatch, 28+64+5+2+24+8, 70+80+yy-75+20+5+5, 1);
//               // }

//                switch (style.state) {
//                    case Style.State.Ok:
//                    //    spriteBatch.Draw(packUsed,new Vector2(28+16,70+80+i*70-height+pressed+16),Color.White);
//                        break;

//                    case Style.State.Errored:
//                        spriteBatch.Draw(packError,new Vector2(28+16,70+80+yy-75+16),Color.White);
//                        break;

//                    case Style.State.FindingOK:
//                        spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+yy-75+32,32,32),null,Color.White,angleChecking,new Vector2(16,16),SpriteEffects.None,1);
//                        break;

//                    case Style.State.FindingError:
//                        spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+yy-75+32,32,32),null,Color.Red,angleChecking,new Vector2(16,16),SpriteEffects.None,1);
//                        break;

//                    //case Style.State.ApplyingOk:
//                    //    spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+i*70-height+pressed+32,32,32),null,Color.Green,angleChecking,new Vector2(16,16),SpriteEffects.None,1);
//                    //    break;

//                    //case Style.State.ApplyingErrored:
//                    //    spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+i*70-height+pressed+32,32,32),null,Color.Orange,angleChecking,new Vector2(16,16),SpriteEffects.None,1);
//                    //    break;

//                    case Style.State.UsingThisGameStyle:
//                        spriteBatch.Draw(packUsed,new Vector2(28+32,70+80+yy-75+32),Color.White);
//                        break;
//                }
//                angleChecking+=0.02f;


//                    }
//                        yy+=100;
//                    }
//            spriteBatch.End();
//            Graphics.SetRenderTarget(null);
//        }

//        public override void Draw(GameTime gameTime, float a) {

//            spriteBatch.Begin();
//            DrawTextHeader( 10, 10,Lang.Texts[9] /*Setting.czechLanguage ? "Styl hry" : "Style of game"*/, a);

//            AddPackButton.ButtonDraw(spriteBatch,/* mouse,*/a);
//            OpenfolderButton.ButtonDraw(spriteBatch, /*mouse,*/ a);
//            buttonMenu.ButtonDraw(spriteBatch, /*mouse,*/ a);

//            spriteBatch.End();

//            effectBlur.Parameters["alpha"].SetValue(a);
//            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,effectBlur);
//            effectBlur.Techniques[0].Passes[0].Apply();
//            spriteBatch.Draw(worldsTarget, new Vector2(0, 76), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight-75-65-2), Color.White*a);
//            spriteBatch.End();

//             spriteBatch.Begin();
//             scrollbar.ButtonDraw(spriteBatch,/*mouse,*/a/*,new Vector2(Menu.newMouseState.X,Menu.newMouseState.Y),new Vector2(Global.WindowWidth-35,76)*/);
//             spriteBatch.End();

//            /*
//            //StartDraw();

//            //bool mouse=Menu.newMouseState.LeftButton==ButtonState.Pressed;
//            // Frame
//            //DrawFrame(20,70,Global.WindowWidth-40,Global.WindowHeight-70-60, 1,  Color.White*a);
//            //DrawRectangle(20+1,70+1,Global.WindowWidth-40-2,Global.WindowHeight-70-60-2,  Color.White * 0.5f*a);

//            //if (Menu.newMouseState.X>Global.WindowWidth-32 && Menu.newMouseState.Y>0 && Menu.newMouseState.X<Global.WindowWidth && Menu.newMouseState.Y<32) {
//            //    if (mouse) spriteBatch.Draw(webPacks,new Vector2(Global.WindowWidth-32,0),Color.LightGray*a);
//            //    else {
//            //        if (Menu.oldMouseState.LeftButton==ButtonState.Pressed) System.Diagnostics.Process.Start("http://geftgames.sweb.cz/programs/rabcrStyles/rabcrStyles.html");
//            //        spriteBatch.Draw(webPacks,new Vector2(Global.WindowWidth-32,0),Color.WhiteSmoke*a);
//            //    }
//            //} else spriteBatch.Draw(webPacks,new Vector2(Global.WindowWidth-32,0),Color.White*a);

//            //if (oldKeyboardState.IsKeyDown(Keys.Down)) height++;
//            //if (oldKeyboardState.IsKeyDown(Keys.Up)) height--;
//            //if (Menu.newMouseState.X>Global.WindowWidth-(848-809) && Menu.newMouseState.X<Global.WindowWidth-(848-829) && Menu.newMouseState.Y>height && Menu.newMouseState.Y<height+69) {
//            //    if (Menu.newMouseState.LeftButton == ButtonState.Pressed && Menu.oldMouseState.LeftButton == ButtonState.Released) pressed=Menu.newMouseState.Y-height;
//            //}
//            //if (pressed>0) height=Menu.newMouseState.Y;
//            //if (Menu.newMouseState.LeftButton == ButtonState.Released && Menu.oldMouseState.LeftButton == ButtonState.Pressed) {
//            //    height-=pressed;
//            //    pressed=0;
//            //}
//            //if (height<70+pressed) height=70+pressed;
//            //if (height>Global.WindowHeight+pressed-70-69+10) height=Global.WindowHeight+pressed-70-69+10;
//            //if (pressed>0) spriteBatch.Draw(scrollbarTopTexture,new Vector2(Global.WindowWidth-(848-809),height-pressed),Color.WhiteSmoke*a);
//            //else spriteBatch.Draw(scrollbarTopTexture,new Vector2(Global.WindowWidth-(848-809),height-pressed),Color.White*a);
//                  //  try { Console.WriteLine(styles[gameStyle].Errors);}catch {}

//        //for (int i=0; i<styles.Count; i++){
//            //    Style style=styles[i];

//            //    if (style.AlphaButtonWant!=style.AlphaButton){
//            //        if (style.AlphaButtonWant>style.AlphaButton){
//            //            style.AlphaButton+=5;
//            //        } else {
//            //            style.AlphaButton-=5;
//            //        }
//            //    }
//            //    if ((Menu.newMouseState.Y>70+80+i*70-height+pressed && Menu.newMouseState.Y<70+80+i*70-height+pressed+70)   && Rabcr.Game.IsActive) {
//            //  //  if (Global.Active && (70+80+i*70-height+pressed>70 && 70+80+i*70-height+pressed<Global.WindowHeight-70)) {
//            //        if (mouse) {
//            //             if (style.state==Style.State.UsingThisGameStyle) style.AlphaButtonWant=200; else style.AlphaButtonWant=150;
//            //        } else {
//            //            if (Menu.oldMouseState.LeftButton==ButtonState.Pressed) {
//            //                if (style.state==Style.State.NotTouch) {
//            //                    gameStyle=i;
//            //                    //CheckingPack();
//            //                    StartChechingPack();
//            //                }

//            //                if (style.state==Style.State.Ok) {
//            //                    Setting.StyleName=style.DirectoryName;
//            //                    SetPack();
//            //                    if (Error){
//            //                        Error=false;
//            //                        styles[gameStyle].state=Style.State.Errored;
//            //                    }else{
//            //                         styles[gameStyle].state=Style.State.UsingThisGameStyle;
//            //                    }

//            //                }
//            //            }
//            //            if (style.state==Style.State.UsingThisGameStyle) style.AlphaButtonWant=150; else style.AlphaButtonWant=100;
//            //        }
//            //    } else {
//            //        if (style.state==Style.State.UsingThisGameStyle) style.AlphaButtonWant=100; else style.AlphaButtonWant=0;
//            //    }


//            //    if (Menu.newMouseState.X>28+64+5 && Menu.newMouseState.Y>70+80+i*70-height+pressed+20+5
//            //    && Menu.newMouseState.X<28+64+5+32 && Menu.newMouseState.Y<70+80+i*70-height+pressed+20+5+32) {
//            //        if (Rabcr.Game.IsActive) {
//            //            if (mouse) {
//            //                if (Menu.oldMouseState.LeftButton==ButtonState.Pressed) {
//            //                    if (i==0) {
//            //                        System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//            //                            "Verze: "+style.Version+Environment.NewLine+
//            //                            "Autor: "+style.Author+Environment.NewLine+
//            //                            "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//            //                            "Název složky: "+style.DirectoryName,"Informace", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
//            //                    } else {
//            //                        if (!style.Errored) {
//            //                            System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//            //                            "Verze: "+style.Version+Environment.NewLine+
//            //                            "Autor: "+style.Author+Environment.NewLine+
//            //                            "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//            //                            "Název složky: "+style.DirectoryName,
//            //                            "Informace", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
//            //                        } else {

//            //                            if (style.ContentErrors.Length>500) System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//            //                                    "Verze: "+style.Version+Environment.NewLine+
//            //                                    "Autor: "+style.Author+Environment.NewLine+
//            //                                    "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//            //                                    "Název složky: "+style.DirectoryName+Environment.NewLine+Environment.NewLine+
//            //                                    "Chyby: "+Environment.NewLine+style.ContentErrors.Substring(0, 500)+"...",
//            //                                    "Informace", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

//            //                            else System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//            //                                "Verze: "+style.Version+Environment.NewLine+
//            //                                "Autor: "+style.Author+Environment.NewLine+
//            //                                "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//            //                                "Název složky: "+style.DirectoryName+Environment.NewLine+Environment.NewLine+
//            //                                "Chyby: "+Environment.NewLine+style.ContentErrors,
//            //                                "Informace", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
//            //                        }
//            //                    }
//            //                }
//            //            }
//            //        }
//            //    }

//            //    if (70+80+i*70-height+pressed>70 && 70+80+i*70-height+pressed<Global.WindowHeight) {
//            //        spriteBatch.Draw(Pixel,new Rectangle(28-3,70+80+i*70-height+pressed-3,Global.WindowWidth-70,70),new Color(style.AlphaButton,style.AlphaButton,style.AlphaButton,style.AlphaButton)*a);
//            //        if (style.Image!=null) spriteBatch.Draw(style.Image,new Rectangle(28,70+80+i*70-height+pressed,64,64),Color.White*a);
//            //        DrawTextShadowMin(Fonts.Small,100,70+80+i*70-height+pressed+3,style.Name+" "+style.Version,a);

//            //        spriteBatch.Draw(packInfo, new Vector2(28+64+5, 70+80+i*70-height+pressed+20+5), Color.White*a);
//            //        style.geDo.DrawGedo(spriteBatch, 28+64+5+2+24+8, 70+80+i*70-height+pressed+20+5+5, a);
//            //    }

//            //    switch (style.state) {
//            //        case Style.State.Ok:
//            //        //    spriteBatch.Draw(packUsed,new Vector2(28+16,70+80+i*70-height+pressed+16),Color.White);
//            //            break;

//            //        case Style.State.Errored:
//            //            spriteBatch.Draw(packError,new Vector2(28+16,70+80+i*70-height+pressed+16),Color.White*a);
//            //            break;

//            //        case Style.State.FindingOK:
//            //            spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+i*70-height+pressed+32,32,32),null,Color.White*a,angleChecking,new Vector2(16,16),SpriteEffects.None,1);
//            //            break;

//            //        case Style.State.FindingError:
//            //            spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+i*70-height+pressed+32,32,32),null,Color.Red*a,angleChecking,new Vector2(16,16),SpriteEffects.None,1);
//            //            break;

//            //        //case Style.State.ApplyingOk:
//            //        //    spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+i*70-height+pressed+32,32,32),null,Color.Green,angleChecking,new Vector2(16,16),SpriteEffects.None,1);
//            //        //    break;

//            //        //case Style.State.ApplyingErrored:
//            //        //    spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+i*70-height+pressed+32,32,32),null,Color.Orange,angleChecking,new Vector2(16,16),SpriteEffects.None,1);
//            //        //    break;

//            //        case Style.State.UsingThisGameStyle:
//            //            spriteBatch.Draw(packUsed,new Vector2(28+32,70+80+i*70-height+pressed+32),Color.White*a);
//            //            break;
//            //    }
//            //    angleChecking+=0.02f;


//            //}>*/


//            //            for (int he=0; he<styles.Count; he++) {

//            //

//            //                if (70+80+he*70-height+pressed>70 && 70+80+he*70-height+pressed<Global.WindowHeight-70) {

//            //                    if (gameStyle==he) spriteBatch.Draw(pixel,new Rectangle(28-3,70+80+he*70-height+pressed-3,Global.WindowWidth-70,70),new Color(100,100,100,50));

//            //                    if (Menu.newMouseState.Y>70+80+he*70-height+pressed && Menu.newMouseState.Y<70+80+he*70-height+pressed+70) {

//            //                        if (!(Menu.newMouseState.X>28+64+5 && Menu.newMouseState.Y>70+80+he*70-height+pressed+20+5
//            //                        && Menu.newMouseState.X<28+64+5+32 && Menu.newMouseState.Y<70+80+he*70-height+pressed+20+5+32) && Global.Active) {

//            //
//            //                                gameStyle=he;

//            //                                if (style.DirectoryName!=Setting.StyleName){
//            //                                    if (he==0) {
//            //                                        Setting.StyleName="Default";
//            //                                        SetPack();
//            //                                    } else {
//            //                                        if (packCheckingProcess==null) {
//            //                                            if (!packCheckingProcess.IsAlive) {
//            //                                                if (!style.Errored){
//            //                                                    Setting.StyleName=style.DirectoryName;
//            //                                                    SetPack();
//            //                                                } else if (style.state==Style.State.Nothing) {
//            //                                                    gameStyle=he;
//            //                                                    StartChechingPack();
//            //                                                }
//            //                                            }
//            //                                        }
//            //                                    }
//            //                                }
//            //                            }
//            //                        }

//            //
//            //                    }

//            //

//            //

//            //                    if (he!=0) {
//            //                        if (Menu.newMouseState.X>28+64+5 && Menu.newMouseState.Y>70+80+he*70-height+pressed+20+5
//            //                        && Menu.newMouseState.X<28+64+5+32 && Menu.newMouseState.Y<70+80+he*70-height+pressed+20+5+32) {

//            //                            if (Menu.newMouseState.LeftButton==ButtonState.Pressed)
//            //                            else {
//            //                                if (Menu.oldMouseState.LeftButton==ButtonState.Pressed) {
//            //                                    if (style.Errored) {
//            //                                        System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//            //                                        "Verze: "+style.Version+Environment.NewLine+
//            //                                        "Autor: "+style.Author+Environment.NewLine+
//            //                                        "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//            //                                        "Název složky: "+style.DirectoryName,
//            //                                        "Informace",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
//            //                                    } else {

//            //                                        if (style.ContentErrors.Length>500) System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//            //                                                "Verze: "+style.Version+Environment.NewLine+
//            //                                                "Autor: "+style.Author+Environment.NewLine+
//            //                                                "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//            //                                                "Název složky: "+style.DirectoryName+Environment.NewLine+Environment.NewLine+
//            //                                                "Chyby: "+Environment.NewLine+style.ContentErrors.Substring(0,500)+"...",
//            //                                                "Informace",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);

//            //                                            else System.Windows.Forms.MessageBox.Show("Název: "+style.Name+Environment.NewLine+
//            //                                                "Verze: "+style.Version+Environment.NewLine+
//            //                                                "Autor: "+style.Author+Environment.NewLine+
//            //                                                "Vhodné pro verzi: "+style.ForVersion+Environment.NewLine+
//            //                                                "Název složky: "+style.DirectoryName+Environment.NewLine+Environment.NewLine+
//            //                                                "Chyby: "+Environment.NewLine+style.ContentErrors,
//            //                                                "Informace",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Information);
//            //                                    }
//            //                                }

//            //                                spriteBatch.Draw(packInfo, new Vector2(28+64+5, 70+80+he*70-height+pressed+20+5), Color.WhiteSmoke);
//            //                            }
//            //                        } else spriteBatch.Draw(packInfo, new Vector2(28+64+5, 70+80+he*70-height+pressed+20+5), Color.White);

//            //                        style.geDo.DrawGedo(spriteBatch,Global.Active,28+64+5+2+32 ,70+80+he*70-height+pressed+20+5+5,255);

//            //                    } else style.geDo.DrawGedo(spriteBatch,Global.Active,28+64+5+2 ,70+80+he*70-height+pressed+20+5+5,255);


//            //                    if (he!=0) {
//            //                        switch (style.state){
//            //                            case Style.State.Errored:

//            //                                break;

//            //                        }


//            //                        if (gameStyle==he) {
//            //                            if (checkingPack) {

//            //                                if (style.Errored) spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+he*70-height+pressed+32,32,32),null,Color.Blue,angleChecking,new Vector2(16,16),SpriteEffects.None,1);
//            //                                else spriteBatch.Draw(packChecking,new Rectangle(28+32,70+80+he*70-height+pressed+32,32,32),null,Color.White,angleChecking,new Vector2(16,16),SpriteEffects.None,1);
//            //                                angleChecking+=0.02f;
//            //                            } else if (style.Errored) spriteBatch.Draw(packError,new Vector2(28+16,70+80+he*70-height+pressed+16),Color.White);

//            //                            else spriteBatch.Draw(packUsed,new Vector2(28+16,70+80+he*70-height+pressed+16),Color.White);


//            //                        }
//            //                            if (finish) {Console.WriteLine(finish);
//            //                            //
//            //                                if (style.Errored) {
//            //                                    finish=false;   checkingPack=false;
//            //                                } else {
//            //                                Setting.StyleName=style.DirectoryName;
//            //                                    SetPack();

//            //                                    //gameStyle=Setting.St;
//            //                                    //try {
//            //                                    checkingPack=false;

//            //                                    //} catch {
//            //                                    //    checkIndex=2;
//            //                                    //} finally {
//            //                                        //checkIndex=3;
//            //                                        finish=false;
//            //                                    //}
//            //                                }
//            //                            //}
//            //                        }
//            //                    }else {
//            //                        if (gameStyle==0) { spriteBatch.Draw(packUsed,new Vector2(28+16,70+80+he*70-height+pressed+16),Color.White);

//            //                }
//            //            } }
//            //                }


//            //                if (Menu.newMouseState.X>10 && Menu.newMouseState.Y>Global.WindowHeight-50 && Menu.newMouseState.X<10+128 && Menu.newMouseState.Y<Global.WindowHeight-50+32) {
//            //                    if (Menu.newMouseState.LeftButton==ButtonState.Pressed) spriteBatch.Draw(buttonPlayTexture,new Vector2(10,Global.WindowHeight-50),Color.Gray);
//            //                    else {
//            //                        if (Menu.oldMouseState.LeftButton==ButtonState.Pressed && Global.Active) {
//            //                            System.Windows.Forms.OpenFileDialog ofd=new System.Windows.Forms.OpenFileDialog();
//            //                            if (Setting.czechLanguage) {
//            //                                ofd.Filter="Zip Archiv|*.zip";
//            //                                ofd.Title="Styl hry";
//            //                            } else {
//            //                                ofd.Filter="Zip Archive|*.zip";
//            //                                ofd.Title="Game style";
//            //                            }
//            //                            ofd.ShowDialog();

//            //                            if (File.Exists(ofd.FileName)) {
//            //                                //ICSharpCode.SharpZipLib.Zip.FastZip zip=new ICSharpCode.SharpZipLib.Zip.FastZip();
//            //                                //zip.EntryFactory=new ICSharpCode.SharpZipLib.Zip.IEntryFactory();
//            //                                Extract(ofd.FileName,new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).Directory.FullName+@"\RabcrData\"+(new FileInfo(ofd.FileName).Name).Substring(0,(new FileInfo(ofd.FileName).Name).LastIndexOf(".")));
//            //                               // zip.ExtractZip(ofd.FileName,(new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).Directory.FullName+@"\RabcrData\"+new FileInfo(ofd.FileName).Name).Substring(0,(new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).Directory.FullName+@"\RabcrData\"+new FileInfo(ofd.FileName).Name).LastIndexOf(".")),null);
//            //                            }
//            //                        }
//            //                        spriteBatch.Draw(buttonPlayTexture,new Vector2(10,Global.WindowHeight-50),Color.LightGray);
//            //                    }
//            //                    DrawTextShadowMax(Fonts.Medium, 40, Global.WindowHeight-50+3, "Přidat");
//            //                } else {
//            //                    spriteBatch.Draw(buttonPlayTexture,new Vector2(10,Global.WindowHeight-50),Color.White);
//            //                    DrawTextShadowMin(Fonts.Medium, 40, Global.WindowHeight-50+3, "Přidat");
//            //                }

//            //                if (Menu.newMouseState.X>15+128 && Menu.newMouseState.Y>Global.WindowHeight-50 && Menu.newMouseState.X<10+200+128 && Menu.newMouseState.Y<Global.WindowHeight-50+35) {
//            //                    if (Menu.newMouseState.LeftButton==ButtonState.Pressed) {
//            //                        spriteBatch.Draw(longButton,new Vector2(15+128,Global.WindowHeight-50),new Color(120,120,120));
//            //                    } else {
//            //                        spriteBatch.Draw(longButton,new Vector2(15+128,Global.WindowHeight-50),new Color(170,170,170));
//            //                        if (Menu.oldMouseState.LeftButton==ButtonState.Pressed) System.Diagnostics.Process.Start(new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).Directory.FullName+"\\RabcrData");
//            //                    }
//            //                    if (Setting.czechLanguage) DrawTextShadowMax(Fonts.Medium, 37+128, Global.WindowHeight-50+3, "Otevřít složku");
//            //                    else DrawTextShadowMax(Fonts.Medium, 37+128, Global.WindowHeight-50+3, "Open folder");
//            //                } else {
//            //                    spriteBatch.Draw(longButton,new Vector2(15+128,Global.WindowHeight-50),Color.LightGray);
//            //                    if (Setting.czechLanguage) DrawTextShadowMin(Fonts.Medium, 37+128, Global.WindowHeight-50+3, "Otevřít složku");
//            //                    else DrawTextShadowMin(Fonts.Medium, 37+128, Global.WindowHeight-50+3, "Open folder");
//            //                }

//            //                if (Setting.czechLanguage) DrawTextShadowMax(Fonts.Big, 10, 10,  "Styl", Color.White);
//            //                else DrawTextShadowMax(Fonts.Big, 10, 10,  "Style", Color.White);
//            //// Button back
//            //				buttonMenu.ButtonDraw(spriteBatch, new Vector2(Menu.newMouseState.X,Menu.newMouseState.Y),new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-50-4));
//            //				//	if (Setting.czechLanguage) DrawTextShadowMax(Fonts.Medium, Global.WindowWidth-384+70, Global.WindowHeight-50, "Zpět do menu");
//            //    //                else DrawTextShadowMax(Fonts.Medium, Global.WindowWidth-384+70, Global.WindowHeight-50, "Go to the menu");
//            //				//} else if (Setting.czechLanguage) DrawTextShadowMin(Fonts.Medium, Global.WindowWidth-384+70, Global.WindowHeight-50, "Zpět do menu");
//            //    //            else DrawTextShadowMin(Fonts.Medium, Global.WindowWidth-384+70, Global.WindowHeight-50, "Go to the menu");
//            //EndDraw();
//       //     spriteBatch.End();
//            //base.Draw(gameTime);
//        }

//        public override void Resize() {
//            //if (Global.WindowWidth)
//            worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65);
//            scrollbar.scale=0;

//            effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
//            effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);
//            scrollbar.height=Global.WindowHeight-75-65-2;

//            AddPackButton.position=new Vector2(40, Global.WindowHeight-50+3);
//            OpenfolderButton.position= new Vector2(37+128+40, Global.WindowHeight-50+3);
//            buttonMenu.position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-55);


//            //=const scrollbar.Position.Y=76;
//            scrollbar.PositionX=Global.WindowWidth-35;
//        }

//        //void SetTexts() {
//        //    buttonMenu.Text=Lang.Texts[1);
//        //    AddPackButton.Text=Lang.Texts[16);
//        //    OpenfolderButton.Text=Lang.Texts[19);


//        //    AddPackButton.center=true;
//        //    OpenfolderButton.center=true;
//        //}

//        #region Help Draw
//		//void DrawTextShadowMax(SpriteFont newSpriteFont, int x, int y, string str, float a) {
//  //          if (Setting.BetterFont) {
//  //              if (newSpriteFont==Fonts.Medium) {
//  //                  if (Setting.TextShadow) {
//  //                      spriteBatch.DrawString(Fonts.Big, str, new Vector2(x+0.5f, y+0.5f), Color.Black*0.5f,0,new Vector2(0,4),0.45f,SpriteEffects.None,0);
//  //                      spriteBatch.DrawString(Fonts.Big, str, new Vector2(x+1f, y+1f), Color.Black*0.5f,0,new Vector2(0,4),0.45f,SpriteEffects.None,0);
//  //                  }
//  //                  spriteBatch.DrawString(Fonts.Big, str, new Vector2(x, y), Color.Black, 0, new Vector2(0,4),0.45f,SpriteEffects.None,0);
//  //              } else if (newSpriteFont==Fonts.Small) {
//  //                  if (Setting.TextShadow) {
//  //                      spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x+0.5f, y+0.5f), Color.Black*0.5f,0,new Vector2(0,4),0.74074f,SpriteEffects.None,0);
//  //                      spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x+1f, y+1f), Color.Black*0.5f,0,new Vector2(0,4),0.74074f,SpriteEffects.None,0);
//  //                  }
//  //                  spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x, y), Color.Black,0,new Vector2(0,4),0.74074f,SpriteEffects.None,0);
//  //              } else {
//  //                  if (Setting.TextShadow) {
//  //                      spriteBatch.DrawString(Fonts.Biggest, str, new Vector2(x+0.5f, y+0.5f), Color.Black*0.5f,0,new Vector2(0,4),0.5f,SpriteEffects.None,0);
//  //                      spriteBatch.DrawString(Fonts.Biggest, str, new Vector2(x+1f, y+1f), Color.Black*0.5f,0,new Vector2(0,4),0.5f,SpriteEffects.None,0);
//  //                  }
//  //                  spriteBatch.DrawString(Fonts.Biggest, str, new Vector2(x, y), Color.Black,0,new Vector2(0,4),0.5f,SpriteEffects.None,0);
//  //              }
//  //          } else {
//  //              spriteBatch.DrawString(newSpriteFont, str, new Vector2(x, y), Color.Black);
//  //              if (Setting.TextShadow) {
//	 //               spriteBatch.DrawString(newSpriteFont, str, new Vector2(x+1.5f,y+1.5f), Color.Black*0.25f);
//	 //               spriteBatch.DrawString(newSpriteFont, str, new Vector2(x+0.75f, y+0.75f), Color.Black*0.25f);
//  //              }
//  //          }
//  //      }

//        //void DrawTextShadowMin(SpriteFont newSpriteFont, int x, int y, string str, float a) {
//        //    if (Setting.BetterFont) {
//        //        if (newSpriteFont==Fonts.Medium) {
//        //            if (Constants.Shadow)spriteBatch.DrawString(Fonts.Big, str, new Vector2(x+0.5f, y+0.5f), Color.Black*0.5f*a,0,new Vector2(0,4),0.45f,SpriteEffects.None,0);
//        //            spriteBatch.DrawString(Fonts.Big, str, new Vector2(x, y), Color.Black*a,0,new Vector2(0,4),0.45f,SpriteEffects.None,0);
//        //        } else if (newSpriteFont==Fonts.Small) {
//        //            if (Constants.Shadow)spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x+0.5f, y+0.5f), Color.Black*0.5f*a,0,new Vector2(0,4),0.74074f,SpriteEffects.None,0);
//        //            spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x, y), Color.Black*a,0,new Vector2(0,4),0.74074f,SpriteEffects.None,0);
//        //        } else {
//        //            if (Constants.Shadow)spriteBatch.DrawString(Fonts.Biggest, str, new Vector2(x+0.5f, y+0.5f), Color.Black*0.5f*a,0,new Vector2(0,4),0.5f,SpriteEffects.None,0);
//        //            spriteBatch.DrawString(Fonts.Biggest, str, new Vector2(x, y), Color.Black*a,0,new Vector2(0,4),0.5f,SpriteEffects.None,0);
//        //        }
//        //    } else {
//		      //  if (Constants.Shadow)spriteBatch.DrawString(newSpriteFont, str, new Vector2(x+0.5f, y+0.5f), Color.Black*0.5f*a);
//        //        spriteBatch.DrawString(newSpriteFont, str, new Vector2(x,y), Color.Black*a);
//        //    }
//        //}

//        //void DrawTextShadowMax(SpriteFont newSpriteFont, int x, int y, string str, Color c) {
//        //    if (Setting.BetterFont) {
//        //        if (newSpriteFont==Fonts.Medium) {
//        //            if (Constants.Shadow) {
//        //                spriteBatch.DrawString(Fonts.Big, str, new Vector2(x+1.5f, y+1.5f), c*0.4f,0,new Vector2(0,4),0.45f,SpriteEffects.None,0);
//        //                spriteBatch.DrawString(Fonts.Big, str, new Vector2(x+0.5f, y+0.5f), c*0.4f,0,new Vector2(0,4),0.45f,SpriteEffects.None,0);
//        //            }
//        //            spriteBatch.DrawString(Fonts.Big, str, new Vector2(x, y), c,0,new Vector2(0,4),0.45f,SpriteEffects.None,0);
//        //        } else if (newSpriteFont==Fonts.Small){
//        //            if (Constants.Shadow) {
//        //                spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x+1.5f, y+1.5f), c*0.4f,0,new Vector2(0,4),0.74074f,SpriteEffects.None,0);
//        //                spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x+0.5f, y+0.5f), c*0.4f,0,new Vector2(0,4),0.74074f,SpriteEffects.None,0);
//        //            }
//        //            spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x, y), c,0,new Vector2(0,4),0.74074f,SpriteEffects.None,0);
//        //        } else {
//        //            if (Constants.Shadow) {
//        //                spriteBatch.DrawString(Fonts.Biggest, str, new Vector2(x+1.5f, y+1.5f), c*0.4f,0,new Vector2(0,4),0.5f,SpriteEffects.None,0);
//        //                spriteBatch.DrawString(Fonts.Biggest, str, new Vector2(x+0.5f, y+0.5f), c*0.4f,0,new Vector2(0,4),0.5f,SpriteEffects.None,0);
//        //            }
//        //            spriteBatch.DrawString(Fonts.Biggest, str, new Vector2(x, y), c,0,new Vector2(0,4),0.5f,SpriteEffects.None,0);
//        //        }
//        //    } else {
//        //        spriteBatch.DrawString(newSpriteFont, str, new Vector2(x,y), c);
//        //        if (Constants.Shadow) {
//			     //    spriteBatch.DrawString(newSpriteFont, str, new Vector2(x+1.5f, y+1.5f), c*0.4f);
//			     //    spriteBatch.DrawString(newSpriteFont, str, new Vector2(x+0.75f, y+0.75f), c*0.4f);
//		      //  }// else spriteBatch.DrawString(newSpriteFont, str, new Vector2(x+1, y+1), c*0.5f);
//        //    }
//        //}

//        //void DrawTextShadowMin(SpriteFont newSpriteFont, int x,int y, string str, Color c) {
//        //    if (Setting.BetterFont) {
//        //        if (newSpriteFont==Fonts.Medium) {
//        //            if (Constants.Shadow)spriteBatch.DrawString(Fonts.Big, str, new Vector2(x+0.5f, y+0.5f), c*0.5f, 0, new Vector2(0,4),0.45f,SpriteEffects.None,0);
//        //            spriteBatch.DrawString(Fonts.Big, str, new Vector2(x, y), c, 0, new Vector2(0,4),0.45f,SpriteEffects.None,0);
//        //        } else if (newSpriteFont==Fonts.Small){
//        //            if (Constants.Shadow)spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x+0.5f, y+0.5f), c*0.5f, 0, new Vector2(0,4),0.74074f,SpriteEffects.None,0);
//        //            spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x, y), c, 0,new Vector2(0,4),0.74074f,SpriteEffects.None,0);
//        //        } else {
//        //            if (Constants.Shadow)spriteBatch.DrawString(Fonts.Biggest, str, new Vector2(x+0.5f, y+0.5f), c*0.5f, 0, new Vector2(0,4),0.5f,SpriteEffects.None,0);
//        //            spriteBatch.DrawString(Fonts.Biggest, str, new Vector2(x, y), c, 0, new Vector2(0,4),0.5f,SpriteEffects.None,0);
//        //        }
//        //    } else {
//		      //  if (Constants.Shadow)spriteBatch.DrawString(newSpriteFont, str, new Vector2(x+0.5f, y+0.5f), c*0.5f);
//        //        spriteBatch.DrawString(newSpriteFont, str, new Vector2(x,y), c);
//        //    }
//        //}

//		//void DrawRectangle(int x, int y, int w, int h, Color color) => spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x, y, w, h), color);

//		//void DrawFrame(int x, int y, int w, int h, int size, Color color) {
//		//	spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x + size, y, w - size, size), color);
//		//	spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x, y, size, h), color);
//		//	spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x + size, y + h - size, w - size - size, size), color);
//		//	spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x + w - size, y + size, size, h - size), color);
//		//}

//        void DrawTextHighSmall(string text,int x, int y) {
//            spriteBatch.DrawString(Fonts.Big,text,new Vector2(x,y),Color.Black,0,Vector2.Zero,0.33333333333333f,SpriteEffects.None,0);
//        }
//		#endregion

//        void FindStyles() {
//            string dir=System.Reflection.Assembly.GetEntryAssembly().Location.Substring(0,System.Reflection.Assembly.GetEntryAssembly().Location.LastIndexOf("\\"))+"\\RabcrData\\";

//            // Remove not existing
//            foreach (Style s in styles){
//                if (s.Name!="Default") {
//                    if (!Directory.Exists(dir+s.DirectoryName)){
//                        styles.Remove(s);
//                        break;
//                    }
//                }
//            }


//            // Add new
//            foreach (string x in Directory.GetDirectories(dir)) {
//                if (new DirectoryInfo(x).Name!="Default") {
//                    Console.WriteLine(x);

//                    bool exists=false;
//                    foreach (Style s in styles){
//                        if (s.DirectoryName==new DirectoryInfo(x).Name) {
//                            exists=true;
//                            break;
//                        }
//                    }

//                    if (!exists) {
//                        if (File.Exists(x+"\\Style.txt")) {
//                            using (StreamReader sr = new StreamReader(x+"\\Style.txt")) {

//                                Style style = new Style {
//                                    DirectoryName=new DirectoryInfo(x).Name,
//                                    state=Style.State.NotTouch
//                                };

//                                if (File.Exists(x+"\\Image.xnb")) {
//                                    Texture2D tex;
//                                    try {
//                                       tex=Content.Load<Texture2D>(new DirectoryInfo(x).Name+"\\Image.xnb");
//                                    } catch{
//                                        tex=null;
//                                    }
//                                    if (tex!=null) {
//                                         style=new Style(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(),tex);
//                                    }else{
//                                        style=new Style(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine());
//                                    }
//                                } else style=new Style(sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine(), sr.ReadLine());
//                                if (style.Message==null)style.Message="";
//                                style.geDo=new GeDo(Fonts.Small, /*Fonts.SmallItalic,*/style.Message/*,false*/);
//                                styles.Add(style);
//                            }
//                        }
//                    }
//                }
//            }

//            scrollbar.maxheight=styles.Count*100;
//        }

//         void StartChechingPack() {
//            packCheckingProcess=new Thread(CheckingPack);
//           // finish=false;
//           styles[gameStyle].state=Style.State.FindingOK;
//            Error=false;
//            packCheckingProcess.Start();
//        }

//        void CheckingPack() {
//            Log.WriteLine("Kontrola herních prvků");

//            //string[] lines = Properties.Resources.Content.Split(
//            //    new[] { Environment.NewLine },
//            //    StringSplitOptions.None
//            //);

//           // int i;
//            //foreach (string data in lines){
//            //for (i=0; i<lines.Length;i++){
//            //    string data=lines[i];
//            //    if (data=="songs")break;
//            //    ExistsInPackTexture(data);
//            //}
//            //for (i++; i<lines.Length;i++){
//            //    string data=lines[i];
//            //    if (data=="soundEffects")break;
//            //    ExistsInPackSong(data);
//            //}
//            //for (i++; i<lines.Length;i++){
//            //    string data=lines[i];
//            //    if (data=="fonts")break;
//            //    ExistsInPackSoundEffect(data);
//            //}
//            //for (i++; i<lines.Length;i++){
//            //    string data=lines[i];
//            //    if (data!="")break;
//            //    ExistsInPackFont(data);
//            //}

//            finish=true;
//        }

//        void SetPack() {
//            {
//                if (Setting.StyleName=="") {
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                    Error=true;
//                    System.Windows.Forms.MessageBox.Show("Nelze načíst tento styl, protože styl nemá existující složku "+Setting.StyleName,"Chyba");
//                    return;
//                }

//                //styles[gameStyle].state=Style.State.ApplyingOk;
//                //MediaPlayer.Stop();

//                {
//                    Texture2D tex=Textures.ButtonLongLeft;
//                    if (tex==null){
//                         Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\Menu\ButtonLongLeft""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                        Error=true;
//                        errors+="Buttons/Menu/ButtonLongLeft";
//                        System.Windows.Forms.MessageBox.Show("Nelze načíst tento styl, protože chybovala položka Buttons/Menu/ButtonLongLeft","Chyba");
//                        Setting.StyleName="Default";
//                        SetStyleFile();
//                    }else{
//                        buttonMenu.texture=tex;
//                    }
//                }

//                Texture2D ButtonCenter = null;
//                try {
//                    ButtonCenter=Content.Load<Texture2D>(Setting.StyleName+@"\Buttons\Menu\ButtonCenter");
//                } catch {
//                    errors+=Setting.StyleName+@"\Buttons\Menu\ButtonCenter";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\Menu\ButtonCenter""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }

//                if (ButtonCenter!=null) {
//                    //buttonInfoKeyBoard.texture=ButtonCenter;
//                    //buttonInfoHow.texture=ButtonCenter;
//                    //buttonInfoTechnic.texture=ButtonCenter;

//                }

//                //Texture2D ButtonLeft = null;
//                //try {
//                //    ButtonLeft=Content.Load<Texture2D>(Setting.StyleName+@"\Buttons\Menu\ButtonLeft");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Buttons\Menu\ButtonLeft";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\Menu\ButtonLeft""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}

//                //if (ButtonLeft!=null) buttonInfoMain.texture=ButtonLeft;

//                //Texture2D ButtonRight = null;
//                //try {
//                //    ButtonRight=Content.Load<Texture2D>(Setting.StyleName+@"\Buttons\Menu\ButtonRight");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Buttons\Menu\ButtonRight";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\Menu\ButtonRight""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}

//                //if (ButtonRight!=null) buttonInfoFuture.texture=ButtonRight;

//                Texture2D pack = null;
//                try {
//                    pack=Content.Load<Texture2D>(Setting.StyleName+@"\GameStyle\PackInfo");
//                } catch {
//                    errors+=Setting.StyleName+@"\GameStyle\PackInfo";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\GameStyle\PackInfo""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }

//                if (pack!=null) packInfo=pack;

//                Texture2D checking = null;
//                try {
//                    checking=Content.Load<Texture2D>(Setting.StyleName+@"\GameStyle\CheckingPack");
//                } catch {
//                    errors+=Setting.StyleName+@"\GameStyle\CheckingPack";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\GameStyle\CheckingPack""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }

//                if (checking!=null) packChecking=checking;

//                //Texture2D web = null;
//                //try {
//                //    web=Content.Load<Texture2D>(Setting.StyleName+@"\GameStyle\PackWeb");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\GameStyle\PackWeb";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\GameStyle\PackWeb""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}

//              //  if (web!=null) webPacks=web;

//                //Texture2D play = null;
//                //try {
//                //    play=Content.Load<Texture2D>(Setting.StyleName+@"\Buttons\Menu\ButtonLeft");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Buttons\Menu\ButtonLeft";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\Menu\ButtonLeft""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}

//              //  if (play!=null) buttonPlayTexture=play;

//                //Texture2D setting = null;
//                //try {
//                //    setting=Content.Load<Texture2D>(Setting.StyleName+@"\Buttons\ButtonSetting");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Buttons\ButtonSetting";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\ButtonSetting""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}

//                //if (setting!=null) buttonSettingTexture=setting;

//                Texture2D scroll = null;
//                try {
//                    scroll=Content.Load<Texture2D>(Setting.StyleName+@"\Buttons\ScrollBar");
//                } catch {
//                    errors+=Setting.StyleName+@"\Buttons\ScrollBar";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\ScrollBar""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }

//                if (scroll!=null) scrollbarTopTexture=scroll;

//                //Texture2D but = null;
//                //try {
//                //    but=Content.Load<Texture2D>(Setting.StyleName+@"\Buttons\Menu\NewServer");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Buttons\Menu\NewServer";
//                //    Output.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\Menu\NewServer""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}

//             //   if (but!=null) longButton=but;

//                Texture2D not = null;
//                try {
//                    not=Content.Load<Texture2D>(Setting.StyleName+@"\GameStyle\PackError");
//                } catch {
//                    errors+=Setting.StyleName+@"\GameStyle\PackError";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\GameStyle\PackError""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }

//                if (not!=null) packError=not;


//                Texture2D yes = null;
//                try {
//                    yes=Content.Load<Texture2D>(Setting.StyleName+@"\GameStyle\PackUsed");
//                } catch {
//                    errors+=Setting.StyleName+@"\GameStyle\PackUsed";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\GameStyle\PackUsed""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }

//                if (yes!=null) packUsed=yes;

//                Texture2D wait = null;
//                try {
//                    wait=Content.Load<Texture2D>(Setting.StyleName+@"\GameStyle\CheckingPack");
//                } catch {
//                    errors+=Setting.StyleName+@"\GameStyle\CheckingPack";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\GameStyle\CheckingPack""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }

//                if (wait!=null) packChecking=wait;

//                //Texture2D movemer = null;
//                //try {
//                //    movemer=Content.Load<Texture2D>(Setting.StyleName+@"\Buttons\Setting\TrackBar\TrackBarMovemer");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Buttons\Setting\TrackBar\TrackBarMovemer";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\Setting\TrackBar\TrackBarMovemer""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}

//                //if (movemer!=null) {
//                //    volumeSong.movemer=movemer;
//                //    volumeEffects.movemer=movemer;
//                //}

//                //Texture2D zip = null;
//                //try {
//                //    zip=Content.Load<Texture2D>(Setting.StyleName+@"\Buttons\Setting\TrackBar\TrackBarLine");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Buttons\Setting\TrackBar\TrackBarLine";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\Setting\TrackBar\TrackBarLine""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}

//                //if (zip!=null) {
//                //    volumeSong.line=zip;
//                //    volumeEffects.line=zip;
//                //}

//                //Texture2D set = null;
//                //try {
//                //    set=Content.Load<Texture2D>(Setting.StyleName+@"\Buttons\Setting\ButtonSettingCenter");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Buttons\Setting\TrackBar\ButtonSettingCenter";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Buttons\Setting\TrackBar\ButtonSettingCenter""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}



//                //back=new Background(Content,Graphics);

//                SpriteFont small=null;
//                try {
//                    small=Content.Load<SpriteFont>(Setting.StyleName+@"\Fonts\FontSmall");
//                } catch {
//                    errors+=Setting.StyleName+@"\Fonts\FontSmall";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Fonts\FontSmall""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }
//                if (small!=null)Fonts.Small=small;

//                SpriteFont smallItalic=null;
//                try {
//                    smallItalic=Content.Load<SpriteFont>(Setting.StyleName+@"\Fonts\FontSmallItalic");
//                } catch {
//                    errors+=Setting.StyleName+@"\Fonts\FontSmallItalic";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Fonts\FontSmallItalic""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }
//                if (smallItalic!=null)Fonts.SmallItalic=smallItalic;

//                SpriteFont medium=null;
//                try {
//                    medium=Content.Load<SpriteFont>(Setting.StyleName+@"\Fonts\FontMedium");
//                } catch {
//                    errors+=Setting.StyleName+@"\Fonts\FontMedium";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Fonts\FontMedium""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }
//                if (medium!=null)Fonts.Medium=medium;

//                SpriteFont big=null;
//                try {
//                    big=Content.Load<SpriteFont>(Setting.StyleName+@"\Fonts\FontBig");
//                } catch {
//                    errors+=Setting.StyleName+@"\Fonts\FontBig";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Fonts\FontBig""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }
//                if (big!=null)Fonts.Big=big;

//                SpriteFont biggest=null;
//                try {
//                    biggest=Content.Load<SpriteFont>(Setting.StyleName+@"\Fonts\FontBiggest");
//                } catch {
//                    errors+=Setting.StyleName+@"\Fonts\FontBiggest";
//                    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Fonts\FontBiggest""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                    Error=true;
//                    Setting.StyleName="Default";
//                    SetStyleFile();
//                }
//                if (biggest!=null)Fonts.Biggest=biggest;


//                //Song main1=null;
//                //try {
//                //    main1=Content.Load<Song>(Setting.StyleName+@"\Sounds\SoundMain1");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Sounds\SoundMain1";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Sounds\SoundMain1""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}
//                //if (main1!=null)mainSound=main1;

//                //Song main2=null;
//                //try {
//                //    main2=Content.Load<Song>(Setting.StyleName+@"\Sounds\SoundMain2");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Sounds\SoundMain2";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Sounds\SoundMain2""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}
//                //if (main2!=null)mainSound=main2;

//                //Song main3=null;
//                //try {
//                //    main3=Content.Load<Song>(Setting.StyleName+@"\Sounds\SoundMain3");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Sounds\SoundMain3";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Sounds\SoundMain3""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}
//                //if (main3!=null)mainSound=main3;

//                //Song main4=null;
//                //try {
//                //    main4=Content.Load<Song>(Setting.StyleName+@"\Sounds\SoundMain4");
//                //} catch {
//                //    errors+=Setting.StyleName+@"\Sounds\SoundMain4";
//                //    Console.WriteLine("Nelze načíst \""+Setting.StyleName+@"\Sounds\SoundMain4""."+Environment.NewLine+"Vrací se výchozí styl hry."+Environment.NewLine+Environment.NewLine);
//                //    Error=true;
//                //    Setting.StyleName="Default";
//                //    SetStyleFile();
//                //}
//                //if (main4!=null)mainSound=main4;

//                //MediaPlayer.Play(mainSound);
//            }
//        }

//        void ExistsInPackTexture(string str) {
//			try {
//				Content.Load<Texture2D>(styles[gameStyle].DirectoryName+"\\"+str);
//			} catch {
//              //  styles[gameStyle].Errored=true;
//                //styles[gameStyle].ContentErrors+=str+Environment.NewLine;
//                Error=true;
//                errors+=str+Environment.NewLine;
//			}
//		}

//        void ExistsInPackFont(string str) {
//			try {
//				Content.Load<SpriteFont>(styles[gameStyle].DirectoryName+"\\"+str);
//			} catch {
//				//styles[gameStyle].Errored=true;
//    //            styles[gameStyle].ContentErrors+=str+Environment.NewLine;
//       Error=true;
//                errors+=str+Environment.NewLine;
//			}
//		}

//        void ExistsInPackSong(string str) {
//			try {
//				Content.Load<Song>(styles[gameStyle].DirectoryName+"\\"+str);
//			} catch {
//				//styles[gameStyle].Errored=true;
//    //            styles[gameStyle].ContentErrors+=str+Environment.NewLine;
//       Error=true;
//                errors+=str+Environment.NewLine;
//			}
//		}

//        void ExistsInPackSoundEffect(string str) {
//			try {
//				Content.Load<SoundEffect>(styles[gameStyle].DirectoryName+"\\"+str);
//			} catch {
//				//styles[gameStyle].Errored=true;
//    //            styles[gameStyle].ContentErrors+=str+Environment.NewLine;
//       Error=true;
//                errors+=str+Environment.NewLine;
//			}
//		}

//        void Extract(string file, string directory) {
//            string powerShellFile=Path.GetTempPath()+"\\rabcrExtractZip.ps1";
//            string batchFile=Path.GetTempPath()+"\\rabcrExtractZip.bat";

//            if (File.Exists(powerShellFile)) File.Delete(powerShellFile);
//            if (File.Exists(batchFile)) File.Delete(batchFile);

//            File.WriteAllText(powerShellFile,"Expand-Archive -Path \""+file+"\" -DestinationPath \""+directory+"\"",System.Text.Encoding.ASCII);
//            File.WriteAllText(batchFile,"@echo off"+Environment.NewLine+"title Pridavani stylu..."+Environment.NewLine+"powershell -executionpolicy bypass -File \""+powerShellFile+"\"",System.Text.Encoding.ASCII);
//            System.Diagnostics.Process p= new System.Diagnostics.Process();
//            p.StartInfo.FileName=batchFile;

//            p.Start();
//            p.WaitForExit();
//            p.Dispose();
//        }

//        void SetStyleFile() => File.WriteAllText(Setting.Path+"GameStyle.txt",Setting.StyleName);

//        void SetWindow() {
//            if (Setting.currentWindow==Setting.Window.Fullscreen) {
//                System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
//                System.Windows.Forms.Screen myScreen = System.Windows.Forms.Screen.AllScreens[0];

//                gameForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
//                GraphicsManager.PreferredBackBufferWidth = myScreen.Bounds.Width;
//                GraphicsManager.PreferredBackBufferHeight = myScreen.Bounds.Height;
//                GraphicsManager.ApplyChanges(); // Not necessary, however this is a method in my code


//                gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

//                gameForm.Left = myScreen.WorkingArea.Left;
//                gameForm.Top = myScreen.WorkingArea.Top;
//            }
//            if (Setting.currentWindow==Setting.Window.Maxi) {
//                System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
//                if (gameForm.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None) {
//                     gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;


//                    gameForm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(
//                    System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe");
//                }

//                gameForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            }
//            if (Setting.currentWindow==Setting.Window.Normal) {
//                System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
//                if (gameForm.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None) {
//                     gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;


//                    gameForm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(
//                    System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe");
//                }

//                GraphicsManager.PreferredBackBufferWidth = 848;
//                GraphicsManager.PreferredBackBufferHeight = 560;
//                GraphicsManager.ApplyChanges();
//            }
//        }
//    }

//    class Style {public Style(){ }
//        public Style(string name, string version, string author, string message, string forVersion, Texture2D image) {
//            Name=name;
//            Version=version;
//            Author=author;
//            Message=message;
//            ForVersion=forVersion;
//            Image=image;
//        }

//        public Style(string name, string version, string author, string message, string forVersion) {
//            Name=name;
//            Version=version;
//            Author=author;
//            Message=message;
//            ForVersion=forVersion;
//        }

//        public string Name;
//        public string Version;
//        public string Author;
//        public string Message;
//        public string ForVersion;
//        public Texture2D Image;
//        public GeDo geDo;

//        public string DirectoryName = "";

//        public bool Errored=false;
//        public string ContentErrors="";

//        public enum State{
//            NotTouch,
//            FindingOK,
//            FindingError,
//            Ok,
//            Errored,
//            //ApplyingOk,
//            //ApplyingErrored,
//            UsingThisGameStyle
//        }

//        public State state;

//        public int AlphaButton;
//        public int AlphaButtonWant;

//    }
//}