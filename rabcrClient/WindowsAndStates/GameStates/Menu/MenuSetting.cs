using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace rabcrClient {
    class MenuSetting: MenuScreen {

        #region Varibles
        Scrollbar scrollbar;
        RenderTarget2D worldsTarget;
        Effect effectBlur;
        Button buttonMenu;
        int yy;
        Texture2D line,tex,movemer;
        List<SettingItem>settings;
        Text header;
        const int DocumentSize=500;
        int start,end;
        float smoothMouse=0;
        const int PageHeight=1290+60+70+60+90+90+90+90+90+90;
        #endregion

        public override void Init() {
            buttonMenu= new Button(Textures.ButtonLongLeft,Lang.Texts[1]);
            buttonMenu.Click+=ClickMenu;
            effectBlur=Effects.BluredTopDownBounds;

            scrollbar=new Scrollbar(GetDataTexture(@"Buttons\Scrollbar\Top"), GetDataTexture(@"Buttons\Scrollbar\Center"), GetDataTexture(@"Buttons\Scrollbar\Bottom")){
                maxheight=PageHeight-Global.WindowHeight+60+60+90+30,
                height=Global.WindowHeight-75-65-2
            };
            scrollbar.MoveScollBar+=Move;

            line = GetDataTexture(@"Buttons\Setting\TrackBar\Line");
            tex=GetDataTexture("Buttons/Setting/Center");
            movemer = GetDataTexture(@"Buttons\Setting\TrackBar\Movemer");
            scrollbar.PositionY=76;
            header=new Text(Lang.Texts[8],10, 10,BitmapFont.bitmapFont34);
            SetTexts();
            Resize();
        }

        void ClickMenu(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MainMenu());

        void Move(object sender, EventArgs e) {
            start=-1;

            yy=(int)(-scrollbar.scale*(PageHeight-Global.WindowHeight));

            for (int i=0; i<settings.Count; i++){
                SettingItem item=settings[i];
                if (yy>-50 &&yy<Global.WindowHeight-160){
                    if (start==-1)start=i;
                    end=i;
                    if (Global.WindowWidth>600){
                        item.X=Global.WindowWidthHalf-DocumentSize/2;
                        item.ChangePos(Global.WindowWidthHalf+DocumentSize/2-150,yy);
                    } else {
                        item.X=20;
                        item.ChangePos(Global.WindowWidth-200,yy);
                    }
                }
                yy+=item.Value;
            }
        }

        public override void Shutdown() {
            Rabcr.SaveSetting();
        }

        public override void Update(GameTime gameTime) {

            if (Menu.newKeyboardState.IsKeyDown(Keys.Up)) smoothMouse-=2f;
            if (Menu.newKeyboardState.IsKeyDown(Keys.Down)) smoothMouse+=2f;

            if (Menu.newKeyboardState.IsKeyDown(Keys.PageUp)) smoothMouse-=5;
            if (Menu.newKeyboardState.IsKeyDown(Keys.PageDown)) smoothMouse+=5;

            if (Menu.newMouseState.ScrollWheelValue!=Menu.oldMouseState.ScrollWheelValue) {
                smoothMouse+=(Menu.oldMouseState.ScrollWheelValue-Menu.newMouseState.ScrollWheelValue)/3f;
            }
            if (smoothMouse!=0){
                if (Constants.AnimationsControls){
                scrollbar.Scroll(smoothMouse/1.5f);
                smoothMouse/=1.3f;
                if (smoothMouse>0){
                    if (smoothMouse<0.049f) smoothMouse=0;
                } else {
                    if (smoothMouse>-0.049f) smoothMouse=0;
                }
                }else{
                    scrollbar.Scroll(smoothMouse);
                    smoothMouse=0;
                }
            }

            buttonMenu.Update();

            for (int i = 0; i<settings.Count; i++) {
                settings[i].Update();
            }

            base.Update(gameTime);
        }

        public override void PreDraw() {
            Graphics.SetRenderTarget(worldsTarget);
            Graphics.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend);

            #region Settings
            int imax=end+1;
            if (imax>=settings.Count)imax=settings.Count;
            for (int i=start; i<imax; i++){
                settings[i].Draw(spriteBatch);
            }
            #endregion

            spriteBatch.End();
            Graphics.SetRenderTarget(null);
        }

        public override void Draw(GameTime gameTime, float a) {
            effectBlur.Parameters["alpha"].SetValue(a);
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,effectBlur);
            effectBlur.Techniques[0].Passes[0].Apply();
            spriteBatch.Draw(worldsTarget, new Vector2(0, 76), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight-75-65-2), Color.White*a);
            spriteBatch.End();

            spriteBatch.Begin();
            header.Draw(spriteBatch, Color.Black*a);

            buttonMenu.ButtonDraw(spriteBatch, a);
            scrollbar.ButtonDraw(spriteBatch, a);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Resize() {
            scrollbar.Scroll(0);
            Move(null,new EventArgs());
            worldsTarget?.Dispose();
            worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65);

            effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
            effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);

            scrollbar.height=Global.WindowHeight-75-65-2;
            scrollbar.scale=0;
            scrollbar.maxheight=PageHeight-Global.WindowHeight;

            buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-54);

            scrollbar.PositionX=Global.WindowWidth-35;
        }

        void SetTexts() {
            settings=new List<SettingItem> {
                // Klávesnice
                new SettingHeader(Lang.Texts[98])
            };
            {
                SettingKey button=new SettingKey(tex, Lang.Texts[100], Setting.KeyLeft);
                button.Click+=ClickKeyLeft;
                settings.Add(button);

                void ClickKeyLeft() {
                    Setting.KeyLeft=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new SettingKey(tex, Lang.Texts[102], Setting.KeyRight);
                button.Click+=ClickKeyRight;
                settings.Add(button);

                void ClickKeyRight() {
                    Setting.KeyRight=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new SettingKey(tex, Lang.Texts[104], Setting.KeyJump);
                button.Click+=ClickKeyJump;
                settings.Add(button);

                void ClickKeyJump() {
                    Setting.KeyJump=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new SettingKey(tex, Lang.Texts[106], Setting.KeyRun);
                button.Click+=ClickKeyRun;
                settings.Add(button);

                void ClickKeyRun() {
                    Setting.KeyRun=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new SettingKey(tex, Lang.Texts[1513], Setting.KeyFlyMode);
                button.Click+=ClickKeyRun;
                settings.Add(button);

                void ClickKeyRun() {
                    Setting.KeyFlyMode=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new SettingKey(tex, Lang.Texts[108], Setting.KeyInventory);
                button.Click+=ClickKeyInventory;
                settings.Add(button);

                void ClickKeyInventory() {
                    Setting.KeyInventory=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new SettingKey(tex, Lang.Texts[110], Setting.KeyMessage);
                button.Click+=ClickKeyMessage;
                settings.Add(button);

                void ClickKeyMessage() {
                    Setting.KeyMessage=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new SettingKey(tex, Lang.Texts[112], Setting.KeyDropItem);
                button.Click+=ClickKeyDropItem;
                settings.Add(button);

                void ClickKeyDropItem() {
                    Setting.KeyDropItem=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new SettingKey(tex, Lang.Texts[114], Setting.KeyExit);
                button.Click+=ClickKeyExit;
                settings.Add(button);

                void ClickKeyExit() {
                    Setting.KeyExit=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new SettingKey(tex, Lang.Texts[1514], Setting.KeyShowInfo);
                button.Click+=ClickKeyRun;
                settings.Add(button);

                void ClickKeyRun() {
                    Setting.KeyShowInfo=button.Key;
                    Global.ChangedSettings=true;
                }
            }

            // Herních prvky
            settings.Add(new SettingHeader(Lang.Texts[123]));
            {
                SettingOnOff button = new SettingOnOff(tex, Lang.Texts[124], Constants.AnimationsControls);
                button.Click+=ClickAnimations;
                settings.Add(button);

                void ClickAnimations() {
                    Constants.AnimationsControls=button.ON;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingOnOff button = new SettingOnOff(tex, Lang.Texts[125], Constants.AnimationsGame);
                button.Click+=ClickAnimations;
                settings.Add(button);

                void ClickAnimations() {
                    Constants.AnimationsGame=button.ON;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingMovemer button=new SettingMovemer(Lang.Texts[354], line, movemer) { 
                    Scale=Setting.NightBrightness
                };
                button.Click+=ClickNightBrightness;
                settings.Add(button);

                void ClickNightBrightness() {
                    Setting.NightBrightness=button.Scale;
                    Global.ChangedSettings=true;
                }
            }
            //{
            //    SettingOnOff button = new SettingOnOff(tex, Lang.Texts[339], Constants.Shadow);
            //    button.Click+=ClickAnimations;
            //    settings.Add(button);

            //    void ClickAnimations() {
            //        Constants.Shadow=button.ON;
            //        Global.ChangedSettings=true;
            //    }
            //}
            {
                int zoom=4;
                switch (Setting.Zoom){
                    case 1: zoom=0; break;
                    case 1.25f: zoom=1; break;
                    case 1.5f:zoom=2; break;
                    case 1.75f: zoom=3; break;
                    case 2:zoom=4; break;
                    case 2.5f: zoom=5; break;
                    case 3: zoom=6; break;
                    case 4: zoom=7; break;
                    case 5: zoom=8; break;
                }

                SettingSwitcher button=new SettingSwitcher(tex, Lang.Texts[126], new string[]{ Lang.Texts[272], Lang.Texts[273], Lang.Texts[274], Lang.Texts[275],Lang.Texts[276],Lang.Texts[277],Lang.Texts[278],Lang.Texts[279],Lang.Texts[280]},zoom);
                button.Click+=ClickZoom;
                settings.Add(button);

                void ClickZoom() {
                    switch (button.selected){
                        case 0: Setting.Zoom=1; break;
                        case 1: Setting.Zoom=1.25f; break;
                        case 2: Setting.Zoom=1.5f; break;
                        case 3: Setting.Zoom=1.75f; break;
                        case 4: Setting.Zoom=2; break;
                        case 5: Setting.Zoom=2.5f; break;
                        case 6: Setting.Zoom=3f; break;
                        case 7: Setting.Zoom=4f; break;
                        case 8: Setting.Zoom=5f; break;
                    }
                    ((Menu)Rabcr.screen).RefreshBackground();
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingSwitcher button=new SettingSwitcher(tex, Lang.Texts[128], new string[]{ Lang.Texts[148], Lang.Texts[149], Lang.Texts[150]}, (int)Setting.currentScale);
                button.Click+=ClickScale;
                settings.Add(button);

                void ClickScale() {
                    Setting.currentScale=(Setting.Scale)button.selected;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingSwitcher button=new SettingSwitcher(tex, Lang.Texts[130], new string[]{ Lang.Texts[151], Lang.Texts[152], Lang.Texts[153]}, (int)Setting.currentWindow);
                button.Click+=ClickWindow;
                settings.Add(button);

                void ClickWindow() {
                    Setting.currentWindow=(Setting.Window)button.selected;
                    SetWindow();
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingSwitcher button=new SettingSwitcher(tex, Lang.Texts[319], new string[]{ Lang.Texts[317], Lang.Texts[318]},(int)Setting.GraphicsProfile);
                button.Click+=ClickGraphicsProfile;
                settings.Add(button);

                void ClickGraphicsProfile() {
                    Setting.GraphicsProfile=(GraphicsProfile)button.selected;
                    Global.ChangedSettings=true;
                    System.Windows.Forms.MessageBox.Show(Lang.Texts[343]);
                }
            }
            if (File.Exists(@"C:\Program Files\NVIDIA Corporation\Control Panel Client\nvcplui.exe")){
                SettingButton button=new SettingButton(tex,Lang.Texts[342]);
                button.Click+=ClickGraphicsProfile;
                settings.Add(button);

                void ClickGraphicsProfile() {
                    Process.Start(@"C:\Program Files\NVIDIA Corporation\Control Panel Client\nvcplui.exe");
                    System.Windows.Forms.MessageBox.Show(Lang.Texts[341].Replace("|",Environment.NewLine));
                 //   Setting.GraphicsProfile=(GraphicsProfile)button.selected;
                //    Global.ChangedSettings=true;
                 //   System.Windows.Forms.MessageBox.Show(Lang.Texts[320]);
                }
            } else {
                SettingMessage button=new SettingMessage(Lang.Texts[340]);
                settings.Add(button);
            }

           // {
               // SettingHeader button=new SettingHeader(Lang.Texts[319]);
                //button.Click+=ClickGraphicsProfile;
                //settings.Add(button);

                //void ClickGraphicsProfile() {
                //    Setting.GraphicsProfile=(GraphicsProfile)button.selected;
                //    Global.ChangedSettings=true;
                //    System.Windows.Forms.MessageBox.Show(Lang.Texts[320]);
                //}
          //  }
            {
                SettingOnOff button=new SettingOnOff(tex, Lang.Texts[132], Setting.Fps);
                button.Click+=ClickFps;
                settings.Add(button);

                void ClickFps() {
                    Setting.Fps=button.ON;
                    Global.ChangedSettings=true;
                }
            }

            // Hlasitost
            settings.Add(new SettingHeader(Lang.Texts[134]));
            {
                SettingMovemer button=new SettingMovemer(Lang.Texts[135], line, movemer){ Scale=Setting.VolumeMusic };
                button.Click+=ClickVolumeMusic;
                settings.Add(button);

                void ClickVolumeMusic() {
                    Setting.VolumeMusic=button.Scale;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingMovemer button=new SettingMovemer(Lang.Texts[137], line, movemer){ Scale=Setting.VolumeEffects };
                button.Click+=ClickVolumeEffects;
                settings.Add(button);

                void ClickVolumeEffects() {
                    Setting.VolumeEffects=button.Scale;
                    Global.ChangedSettings=true;
                }
            }

            // Menu
            settings.Add(new SettingHeader(Lang.Texts[114]));
            {
                SettingSwitcher button=new SettingSwitcher(tex,Lang.Texts[139], new string[] { Lang.Texts[148], Lang.Texts[154], Lang.Texts[155],Lang.Texts[156]}, Setting.slideChangeTime==0 ? 0 : (Setting.slideChangeTime==0.1f ? 1 : (Setting.slideChangeTime==0.05f ? 2 : (Setting.slideChangeTime==0.01f ? 3 : 0))));
                button.Click+=ClickSlideChangeTime;
                settings.Add(button);

                void ClickSlideChangeTime() {
                    switch (button.selected) {
                        case 0: Setting.slideChangeTime=0; break;
                        case 1: Setting.slideChangeTime=0.1f; break;
                        case 2: Setting.slideChangeTime=0.05f; break;
                        case 3: Setting.slideChangeTime=0.01f; break;
                    }
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingOnOff button=new SettingOnOff(tex, Lang.Texts[141], Setting.Background);
                button.Click+=ClickBackground;
                settings.Add(button);

                void ClickBackground() {
                    Setting.Background=button.ON;
                    Global.ChangedSettings=true;
                }
            }

            // Hráč
            //if (!Global.OnlineAccount) {
            settings.Add(new SettingHeader(Lang.Texts[99]));
            {
                SettingOnOff button = new SettingOnOff(tex, Lang.Texts[143], !Global.YoungPlayer);
                button.Click+=ClickMaturePlayer;
                settings.Add(button);

                void ClickMaturePlayer() {
                    button.ON=false;
                    if (Global.YoungPlayer) {
                        FormTest18Plus formTest = new FormTest18Plus();
                        formTest.ShowDialog();
                        if (formTest.OK) {
                            button.ON=true;
                            Global.YoungPlayer=false;
                            Global.ChangedSettings=true;
                        }
                    } else {
                        button.ON=false;
                        Global.YoungPlayer=true;
                        Global.ChangedSettings=true;
                    }
                }
            }
      //  } else {
            //    settings.Add(new SettingHeader(Lang.Texts[145]+" "+(Global.YoungPlayer ? Lang.Texts[146]: Lang.Texts[147])));
           // }

            Move(null, new EventArgs());
        }

        void SetWindow() {
            if (Setting.currentWindow==Setting.Window.Fullscreen) {
                System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
                System.Windows.Forms.Screen myScreen = System.Windows.Forms.Screen.AllScreens[0];

                gameForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                GraphicsManager.PreferredBackBufferWidth = myScreen.Bounds.Width;
                GraphicsManager.PreferredBackBufferHeight = myScreen.Bounds.Height;
                GraphicsManager.ApplyChanges(); // Not necessary, however this is a method in my code


                gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

                gameForm.Left = myScreen.WorkingArea.Left;
                gameForm.Top = myScreen.WorkingArea.Top;
            }
            if (Setting.currentWindow==Setting.Window.Maxi) {
                System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
                if (gameForm.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None) {
                     gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;


                //    gameForm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(
                //    Process.GetCurrentProcess().ProcessName + ".exe");
                }

                gameForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            if (Setting.currentWindow==Setting.Window.Normal) {
                System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
                if (gameForm.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None) {
                     gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;


                //    gameForm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(
                //    Process.GetCurrentProcess().ProcessName + ".exe");
                }

                GraphicsManager.PreferredBackBufferWidth = 848;
                GraphicsManager.PreferredBackBufferHeight = 560;
                GraphicsManager.ApplyChanges();
            }
        }
    }
}