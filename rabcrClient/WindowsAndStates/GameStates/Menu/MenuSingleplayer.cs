using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace rabcrClient {
    struct Singleworld{
        public string directoryName;
        public GeDo gedo;
        public bool generated;
        public ButtonCenter ButtonPlay;
        public ImgButton ButtonSetting;

      //  public int TerrainType;
    }

    class MenuSingleplayer :MenuScreen {
       // string header=Lang.Texts[6];
        #region vars
        RenderTarget2D worldsTarget;
        List<Singleworld> Worlds=new List< Singleworld>();
      Text header;
        ButtonCenter buttonNewWorld,  OpenfolderButton;
Button buttonMenu;
        int timer=1;
        //KeyboardState newKeyboardState;
        //MouseState newMouseState, oldMouseState;
        Effect effectBlur, effectColorize;
        Scrollbar scrollbar;
        Texture2D scrollbarTopTexture,scrollbarCenterTexture,scrollbarBottomTexture, buttonPlayTexture, buttonSettingTexture, buttonRightTexture,buttonLeftTexture,
            /*worldFlat,worldIsland,*/ worldOpen;
      //  bool mouse;
        #endregion
            float smoothMouse=0;
        public override void Init() {
           // worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65-2);

            //achievementTexture=GetDataTexture("Buttons/Other/Achievements");

            scrollbarTopTexture = GetDataTexture("Buttons/Scrollbar/Top");
            scrollbarCenterTexture = GetDataTexture("Buttons/Scrollbar/Center");
            scrollbarBottomTexture = GetDataTexture("Buttons/Scrollbar/Bottom");

            buttonPlayTexture = Textures.ButtonPlay;
			buttonLeftTexture = Textures.ButtonLeft;
            buttonRightTexture = Textures.ButtonRight;
			buttonSettingTexture = GetDataTexture("Buttons/Other/Setting");

            //worldFlat=GetDataTexture("Menu/Worlds types/plain");
            //worldIsland=GetDataTexture("Menu/Worlds types/iceland");
            worldOpen=GetDataTexture("Menu/Worlds types/forest");

			buttonNewWorld=new ButtonCenter(buttonLeftTexture/*, Fonts.Medium, Fonts.Big,true*/){ center=true };
 buttonNewWorld.Text=Lang.Texts[17];
            OpenfolderButton=new ButtonCenter(buttonRightTexture/*, Fonts.Medium, Fonts.Big,true*/){ center=true };
 OpenfolderButton.Text=Lang.Texts[18];
            buttonMenu=new Button(Textures.ButtonLongLeft,Lang.Texts[1]);
            buttonMenu.Click+=ClickMenu;
            ///*,Fonts.Medium,Fonts.Big,true*/) {
            //    Text=Lang.Texts[26]
            //};



            scrollbar=new Scrollbar(scrollbarTopTexture, scrollbarCenterTexture, scrollbarBottomTexture) {
                PositionY=76
            };

            effectBlur=Effects.BluredTopDownBounds;
             effectColorize=Content.Load<Effect>("Default/Effects/Colorize");
          //  effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
        //    effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);
            header=new Text(Lang.Texts[6], 10, 10,BitmapFont.bitmapFont34);
            PrepereWorlds();
            Resize();
            Move(null,new EventArgs());
            scrollbar.MoveScollBar+=Move;
        }

        void ClickMenu(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MainMenu());

        void Move(object sender, EventArgs e) {
             int yy=(int)(-(Worlds.Count-(Global.WindowHeight-75-65)/100f)*100*scrollbar.scale)-65/*-55*/;

            for (int i = 0;i<Worlds.Count; i++) {
                if (yy>-70-70 && yy<Global.WindowHeight-75-65-70) {

                    //switch (Worlds[i].TerrainType) {
                    //    case 0:
                         //   spriteBatch.Draw(worldOpen,new Vector2(35,yy+73),Color.White);
                    //        break;

                    //    case 1:
                    //        spriteBatch.Draw(worldFlat,new Vector2(35,yy+73),Color.White);
                    //        break;

                    //    case 2:
                    //        spriteBatch.Draw(worldIsland,new Vector2(35,yy+73),Color.White);
                    //        break;
                    //}

                    //Name
                    Worlds[i].gedo.SetPos(35+64+8,yy+73);
                       Worlds[i].ButtonPlay.Position=new Vector2(105+38,yy+100);
                 //   Worlds[i].gedo.DrawGedo(spriteBatch,/*35+64+8,yy+73,*/255);
                   // Worlds[i].ButtonSetting.ButtonDraw(spriteBatch,Menu.mousePosX,Menu.mousePosY-75,105,yy+100,Menu.mouseDown);
                    //Worlds[i].ButtonPlay.mou
                  //  Worlds[i].ButtonPlay.Position=new Vector2(105+38,yy+100);
                  //  Worlds[i].ButtonPlay.ButtonDrawCorectionY(spriteBatch,/*newMouseState.LeftButton==ButtonState.Pressed,*/1/*,new Vector2(newMouseState.X,newMouseState.Y-75)*/);
                }
                yy+=100;
            }
        }

        //public override void Shutdown() {
        //    base.Shutdown();
        //}

        public override void Update(GameTime gameTime) {
            MousePos.mouseRealPosX=Menu.mousePosX;
            MousePos.mouseRealPosY=Menu.mousePosYCorrection;
            MousePos.mouseLeftDown=Menu.mouseDown;
            MousePos.mouseLeftRelease=Menu.oldMouseState.LeftButton==ButtonState.Pressed && !Menu.mouseDown;
            //oldMouseState=newMouseState;

            //newMouseState=Mouse.GetState();
            //newKeyboardState=Keyboard.GetState();

            if (Menu.newKeyboardState.IsKeyDown(Keys.Up)) scrollbar.Scroll(-2);
            if (Menu.newKeyboardState.IsKeyDown(Keys.Down)) scrollbar.Scroll(2);

            if (Menu.newKeyboardState.IsKeyDown(Keys.PageUp)) scrollbar.Scroll(-5);
            if (Menu.newKeyboardState.IsKeyDown(Keys.PageDown)) scrollbar.Scroll(5);

            if (Menu.newMouseState.ScrollWheelValue!=Menu.oldMouseState.ScrollWheelValue) {
                smoothMouse+=((Menu.oldMouseState.ScrollWheelValue-Menu.newMouseState.ScrollWheelValue)/2f);
                /*scrollbar.Scroll*/
            }
            if (smoothMouse!=0){
                scrollbar.Scroll(smoothMouse/1.25f);
                smoothMouse/=1.4f;
                if (smoothMouse>0){
                    if (smoothMouse<0.049f) smoothMouse=0;
                } else {
                    if (smoothMouse>-0.049f) smoothMouse=0;
                }
            }

            buttonMenu.Update();

            int yy=(int)(-(Worlds.Count-(Global.WindowHeight-75-65)/100f)*100*scrollbar.scale)-65;

            for (int i = 0;i<Worlds.Count; i++) {
                if (yy>-70-70 && yy<Global.WindowHeight-75-65-70) {
                    if (Worlds[i].ButtonSetting.Update()) {
                        EditSingleWorld(Worlds[i].directoryName);
                        /*if (Worlds.Count==0)*/break;
                    }
                   // try{
                    if (Worlds[i].ButtonPlay.Click) {
                        RunGame(Worlds[i].directoryName);
                    } //}catch{ }
                }
            }

            if (timer == 0) {
                PrepereWorlds();
				timer = 60;
			} else timer--;

            //if (buttonMenu.Click) {
            //    ((Menu)Rabcr.screen).GoToMenu(new MainMenu());
            //}

            if (OpenfolderButton.Click) {
                Process.Start(Setting.Path);
            }

            if (buttonNewWorld.Click) {
                string worldName = (Rabcr.random.Int(1000)+""+Rabcr.random.Int(1000)+""+Rabcr.random.Int(1000)).ToString();

                using (AddSingleWorld asw = new AddSingleWorld(worldName)) {
                    asw.ShowDialog();
                    asw.news1.Stop();
                    timer=60;
                    PrepereWorlds();
                }
            }
            base.Update(gameTime);
        }

        public override void PreDraw() {
           // Rabcr.spriteBatch=spriteBatch;
            // Set
         //   mouse=newMouseState.LeftButton == ButtonState.Pressed;

            Graphics.SetRenderTarget(worldsTarget);
            Graphics.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,effectColorize);
            int yy=(int)(-(Worlds.Count-(Global.WindowHeight-75-65)/100f)*100*scrollbar.scale)-65/*-55*/;

            for (int i = 0;i<Worlds.Count; i++) {
                if (yy>-70-70 && yy<Global.WindowHeight-75-65-70) {

                    //switch (Worlds[i].TerrainType) {
                    //    case 0:
                            spriteBatch.Draw(worldOpen,new Vector2(35,yy+73),Color.White);
                    //        break;

                    //    case 1:
                    //        spriteBatch.Draw(worldFlat,new Vector2(35,yy+73),Color.White);
                    //        break;

                    //    case 2:
                    //        spriteBatch.Draw(worldIsland,new Vector2(35,yy+73),Color.White);
                    //        break;
                    //}

                    //Name
                 //   Worlds[i].gedo.SetPos(35+64+8,yy+73);
                 Worlds[i].gedo.mouseAdd=-75;
                    Worlds[i].gedo.DrawGedo(/*35+64+8,yy+73,*/1f,spriteBatch);
                //    Worlds[i].ButtonSetting.ButtonDraw(spriteBatch,Menu.mousePosX,Menu.mousePosY-75,105,yy+100,Menu.mouseDown);
                    //Worlds[i].ButtonPlay.mou
                //    Worlds[i].ButtonPlay.Position=new Vector2(105+38,yy+100);
                  //  Worlds[i].ButtonPlay.ButtonDrawCorectionY(spriteBatch,/*newMouseState.LeftButton==ButtonState.Pressed,*/1/*,new Vector2(newMouseState.X,newMouseState.Y-75)*/);
                }
                yy+=100;
            }
            spriteBatch.End();
            // Graphics.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend);
        yy=(int)(-(Worlds.Count-(Global.WindowHeight-75-65)/100f)*100*scrollbar.scale)-65/*-55*/;

            for (int i = 0;i<Worlds.Count; i++) {
                if (yy>-70-70 && yy<Global.WindowHeight-75-65-70) {

                    //switch (Worlds[i].TerrainType) {
                    //    case 0:
                            spriteBatch.Draw(worldOpen,new Vector2(35,yy+73),Color.White);
                    //        break;

                    //    case 1:
                    //        spriteBatch.Draw(worldFlat,new Vector2(35,yy+73),Color.White);
                    //        break;

                    //    case 2:
                    //        spriteBatch.Draw(worldIsland,new Vector2(35,yy+73),Color.White);
                    //        break;
                    //}

                    //Name
                 //   Worlds[i].gedo.SetPos(35+64+8,yy+73);
                  //  Worlds[i].gedo.DrawGedo(spriteBatch,/*35+64+8,yy+73,*/255);
                    Worlds[i].ButtonSetting.Position.X=105;
                    Worlds[i].ButtonSetting.Position.Y=yy+100;
                    Worlds[i].ButtonSetting.ButtonDraw(/*spriteBatch,Menu.mousePosX,Menu.mousePosY-75,105,yy+100,Menu.mouseDown*/);
                    //Worlds[i].ButtonPlay.mou
                    //Worlds[i].ButtonPlay.Position=new Vector2(105+38,yy+100);
                    Worlds[i].ButtonPlay.ButtonDrawCorectionY(spriteBatch,/*newMouseState.LeftButton==ButtonState.Pressed,*/1/*,new Vector2(newMouseState.X,newMouseState.Y-75)*/);
                }
                yy+=100;
            }
            spriteBatch.End();


            Graphics.SetRenderTarget(null);
        }

        public override void Draw(GameTime gameTime, float f) {
            spriteBatch.Begin();
           // DrawTextHeader(10, 10, Lang.Texts[6],f);
            header.Draw(spriteBatch,Color.Black*f);

            buttonNewWorld.ButtonDraw(spriteBatch, /*mouse,*/ f/*, Menu.mousePos*/);
            OpenfolderButton.ButtonDraw(spriteBatch, /*mouse,*/ f/*, Menu.mousePos*/);
            buttonMenu.ButtonDraw(spriteBatch,/* mouse,*/f/*, new Menu.mousePos*/);

			spriteBatch.End();

            effectBlur.Parameters["alpha"].SetValue(f);
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,effectBlur);
            effectBlur.Techniques[0].Passes[0].Apply();
            spriteBatch.Draw(worldsTarget, new Vector2(0, 76), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight-75-65-2), Color.White*f);
            spriteBatch.End();

            spriteBatch.Begin();
            scrollbar.ButtonDraw(spriteBatch,/*mouse,*/f/*,Menu.mousePos,new Vector2(Global.WindowWidth-35,76)*/);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        void PrepereWorlds() {
            if (!Directory.Exists(Setting.Path + "\\Worlds"))Directory.CreateDirectory(Setting.Path + "\\Worlds");
            string[] potencialWorlds = Directory.GetDirectories(Setting.Path + "\\Worlds");
            List<Singleworld>ret=new List<Singleworld>();

            foreach (string w in potencialWorlds){
                if (File.Exists(w+"\\SplashText.txt")) {

                    bool nexistsInList=true;
                    foreach (Singleworld s in Worlds) {
                        if (s.directoryName==w) {
                             ret.Add(s);
                            nexistsInList=false;
                            break;
                        }
                    }

                    if (nexistsInList) {
                        Singleworld s=new Singleworld(){
                            generated=File.Exists(w+"\\EarthGenerated.txt"),
                            gedo=new GeDo(/*Fonts.Small,*//*Fonts.SmallItalic,*/ File.ReadAllText(w+"\\SplashText.txt")/*,false*/,35+64+8,0+73/*,BitmapFont.bitmapFont18*/),
                            directoryName=w,

                            ButtonSetting=new ImgButton(buttonSettingTexture),
                        };

                        if (s.generated){
                              s.ButtonPlay=new ButtonCenter(buttonPlayTexture/*,Fonts.Medium,Fonts.Big,true*/){
                                  Text=Lang.Texts[80]/*;Setting.czechLanguage ? "Hrát" : "Play"*/,
                                  center=true,
                            };
                        } else {
                              s.ButtonPlay=new ButtonCenter(buttonRightTexture/*,Fonts.Medium,Fonts.Big,true*/){
                                  Text=Lang.Texts[81]/*. Setting.czechLanguage ? "Vygenerovat" : "Generate"*/,
                                  center=true,
                            };
                        }

                        string[] options=File.ReadAllLines(w+"\\Options.txt");

                        //try {

                        //    if (int.TryParse(options[1], out int mm)) s.TerrainType=mm;
                        //    else s.TerrainType=-1;
                        //} catch { }

                        if (options.Length==4) {
                            if (int.TryParse(options[2], out int m)) ret.Insert(m, s);
                            else ret.Add(s);
                        } else ret.Add(s);
                    }
                }
            }

            Worlds=ret;
            scrollbar.maxheight=Worlds.Count*100;
             Move(null,new EventArgs());
        }

        public override void Resize() {
            if (Global.WindowWidth!=0){
                worldsTarget?.Dispose();
                worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65);
            }
            scrollbar.scale=0;

            effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
            effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);
            scrollbar.height=Global.WindowHeight-75-65-2;

            buttonNewWorld.Position=new Vector2(40, Global.WindowHeight-50+3);
            OpenfolderButton.Position=new Vector2(37+128+10+29, Global.WindowHeight-50+3);
            buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-55);

            scrollbar.PositionX=Global.WindowWidth-35;

        }

        //void SetTexts() {
        //    buttonMenu.Text=Lang.Texts[1);
        //    buttonNewWorld.Text=Lang.Texts[17);
        //    OpenfolderButton.Text=Lang.Texts[18);
        //    if (Setting.czechLanguage) {
        //        buttonMenu.Text="Zpět";
        //        buttonNewWorld.Text="Nový svět";
        //        OpenfolderButton.Text="Složka";
        //    } else {
        //        buttonMenu.Text="Back";
        //        buttonNewWorld.Text="New world";
        //        OpenfolderButton.Text="Folder";
        //    }
        //}

     //   void AddSingleWorld(string worldName) => Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location,"/AddSingleWorld \""+worldName+"\"");

        void EditSingleWorld(string worldName) {
            using (EditSingleWorld esw= new EditSingleWorld(worldName)){
                esw.ShowDialog();
                timer=60;
                esw.news2.Stop();

            }
            Worlds.Clear();
            PrepereWorlds();
        }

        void RunGame(string w) {
            string[] options=File.ReadAllLines(w+"\\Options.txt");
            Global.WorldDifficulty=int.Parse(options[0]);

            if (File.Exists(w+ @"\Settings.txt")) {
                string[] settings=File.ReadAllLines(w+"\\Settings.txt");
                if (settings[0]!= Release.VersionString) {
                    System.Windows.Forms.MessageBox.Show(Lang.Texts[344], Lang.Texts[343]);
                    return;
                }
            }

            if (File.Exists(w+ @"\EarthGenerated.txt")) {
                if (File.Exists(w+"\\LastWorld.txt")) {
                    string world=File.ReadAllText(w+"\\LastWorld.txt");
                    if (world=="Space") {
                        Rabcr.GoTo(new PlanetSystem(w+"\\"));
                        return;
                    }
                }
                #if DEBUG
                Stopwatch sw=new Stopwatch();
                sw.Start();
                #else
                try {
                #endif
                Rabcr.GoTo(new SinglePlayer(w));
                #if DEBUG
                sw.Stop();
                Debug.WriteLine("Game loaded in "+sw.ElapsedMilliseconds+"ms");
                #else
                } catch (Exception ex) {
                    System.Windows.Forms.MessageBox.Show(
                        Lang.Texts[347]+
                        Environment.NewLine+
                        Environment.NewLine+
                        ex.Message+Environment.NewLine+
                        ex.StackTrace,
                        Lang.Texts[46]);
                    Rabcr.GoTo(new SinglePlayer(w));
                }
                #endif
            } else {
                Rabcr.GoTo(new GWorld(w));
            }
        }
    }
}
