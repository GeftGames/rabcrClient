using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace rabcrClient {

    // Item of world in the list in the menu
    struct Singleworld {
        public string directoryName;
        public GeDo gedo;
        public bool generated;
        public ButtonCenter ButtonPlay;
        public ImgButton ButtonSetting;
    }

    class MenuSingleplayer :MenuScreen {

        #region Varibles
        RenderTarget2D worldsTarget;
        List<Singleworld> Worlds=new List< Singleworld>();
        Text header;
        int timer=1;
        Effect effectBlur, effectColorize;

        // Buttons
        ButtonCenter buttonNewWorld,  OpenfolderButton;
        Button buttonMenu;
        Texture2D scrollbarTopTexture,scrollbarCenterTexture,scrollbarBottomTexture, buttonPlayTexture, buttonSettingTexture, buttonRightTexture,buttonLeftTexture, worldOpen;
        Scrollbar scrollbar;
        float smoothMouse=0;
        #endregion

        public override void Init() {

            // Load textures
            scrollbarTopTexture = GetDataTexture("Buttons/Scrollbar/Top");
            scrollbarCenterTexture = GetDataTexture("Buttons/Scrollbar/Center");
            scrollbarBottomTexture = GetDataTexture("Buttons/Scrollbar/Bottom");

			buttonSettingTexture = GetDataTexture("Buttons/Other/Setting");

            worldOpen=GetDataTexture("Menu/Worlds types/forest");

            buttonPlayTexture = Textures.ButtonPlay;
			buttonLeftTexture = Textures.ButtonLeft;
            buttonRightTexture = Textures.ButtonRight;

            // Set up buttons
            buttonNewWorld = new ButtonCenter(buttonLeftTexture) {
                Text = Lang.Texts[17]
            };
            OpenfolderButton = new ButtonCenter(buttonRightTexture) {
                Text = Lang.Texts[18]
            };

            buttonMenu =new Button(Textures.ButtonLongLeft,Lang.Texts[1]);
            buttonMenu.Click+=ClickMenu;

            scrollbar=new Scrollbar(scrollbarTopTexture, scrollbarCenterTexture, scrollbarBottomTexture) {
                PositionY=76
            };

            // Setup menu white background
            effectBlur=Effects.BluredTopDownBounds;
            effectColorize=Content.Load<Effect>("Default/Effects/Colorize");

            // Header
            header=new Text(Lang.Texts[6], 10, 10,BitmapFont.bitmapFont34);

            // Init
            PrepereWorlds();
            Resize();
            Move(null,new EventArgs());
            scrollbar.MoveScollBar+=Move;
        }

        void ClickMenu(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MainMenu());

        void Move(object sender, EventArgs e) {
             int yy=(int)(-(Worlds.Count-(Global.WindowHeight-75-65)/100f)*100*scrollbar.scale)-65;

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
                }
                yy+=100;
            }
        }

        public override void Update(GameTime gameTime) {
            // Set controls keyboard and mouse
            MousePos.mouseRealPosX=Menu.mousePosX;
            MousePos.mouseRealPosY=Menu.mousePosYCorrection;
            MousePos.mouseLeftDown=Menu.mouseDown;
            MousePos.mouseLeftRelease=Menu.oldMouseState.LeftButton==ButtonState.Pressed && !Menu.mouseDown;

            if (Menu.newKeyboardState.IsKeyDown(Keys.Up)) scrollbar.Scroll(-2);
            if (Menu.newKeyboardState.IsKeyDown(Keys.Down)) scrollbar.Scroll(2);

            if (Menu.newKeyboardState.IsKeyDown(Keys.PageUp)) scrollbar.Scroll(-5);
            if (Menu.newKeyboardState.IsKeyDown(Keys.PageDown)) scrollbar.Scroll(5);

            if (Menu.newMouseState.ScrollWheelValue!=Menu.oldMouseState.ScrollWheelValue) smoothMouse+=(Menu.oldMouseState.ScrollWheelValue-Menu.newMouseState.ScrollWheelValue)/2f;

            // Scrollbar
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

            // Foreach items in list with worlds
            int yy=(int)(-(Worlds.Count-(Global.WindowHeight-75-65)/100f)*100*scrollbar.scale)-65;

            for (int i = 0;i<Worlds.Count; i++) {
                if (yy>-70-70 && yy<Global.WindowHeight-75-65-70) {
                    if (Worlds[i].ButtonSetting.Update()) {
                        EditSingleWorld(Worlds[i].directoryName);
                        break;
                    }
                    if (Worlds[i].ButtonPlay.Click) RunGame(Worlds[i].directoryName);
                }
            }

            if (timer == 0) {
                PrepereWorlds();
				timer = 60;
			} else timer--;

            if (OpenfolderButton.Click) {
                Process.Start(Setting.Path);
            }

            if (buttonNewWorld.Click) {
                string worldName = (FastRandom.Int(1000)+""+FastRandom.Int(1000)+""+FastRandom.Int(1000)).ToString();

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
                    Worlds[i].gedo.mouseAdd=-75;
                    Worlds[i].gedo.DrawGedo(/*35+64+8,yy+73,*/1f,spriteBatch);
                }
                yy+=100;
            }
            spriteBatch.End();

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
                    Worlds[i].ButtonSetting.Position.X=105;
                    Worlds[i].ButtonSetting.Position.Y=yy+100;
                    Worlds[i].ButtonSetting.ButtonDraw();
                    Worlds[i].ButtonPlay.ButtonDrawCorectionY(spriteBatch, 1);
                }
                yy+=100;
            }
            spriteBatch.End();


            Graphics.SetRenderTarget(null);
        }

        public override void Draw(GameTime gameTime, float f) {

            // draw stuff on full window
            spriteBatch.Begin();

            header.Draw(spriteBatch,Color.Black*f);

            buttonNewWorld.ButtonDraw(spriteBatch, f);
            OpenfolderButton.ButtonDraw(spriteBatch,f);
            buttonMenu.ButtonDraw(spriteBatch, f);

			spriteBatch.End();

            // Draw predraw (inside white rectangle)
            effectBlur.Parameters["alpha"].SetValue(f);
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,effectBlur);
            effectBlur.Techniques[0].Passes[0].Apply();
            spriteBatch.Draw(worldsTarget, new Vector2(0, 76), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight-75-65-2), Color.White*f);
            spriteBatch.End();

            // Dont mess with effects
            spriteBatch.Begin();
            scrollbar.ButtonDraw(spriteBatch, f);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        ///<summary>Creale list with worlds</summary>
        void PrepereWorlds() {
            // Dir check
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
                            gedo=new GeDo(File.ReadAllText(w+"\\SplashText.txt"),35+64+8,0+73),
                            directoryName=w,

                            ButtonSetting=new ImgButton(buttonSettingTexture),
                        };

                        if (s.generated){
                              s.ButtonPlay=new ButtonCenter(buttonPlayTexture) {
                                  Text=Lang.Texts[80],
                                  //center=true,
                            };
                        } else {
                              s.ButtonPlay=new ButtonCenter(buttonRightTexture) {
                                  Text=Lang.Texts[81],
                               //   center=true,
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

        void EditSingleWorld(string worldName) {
            using (EditSingleWorld esw = new EditSingleWorld(worldName)) {
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
