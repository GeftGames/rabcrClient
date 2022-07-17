using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;

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
        int PageHeight=1290+60+70+60+90+90+90+90+90+90+500+90;
        #endregion
        bool afterrestart;
        public override void Init() {
            buttonMenu= new Button(Textures.ButtonLongLeft,Lang.Texts[1]);
            buttonMenu.Click+=ClickMenu;
            effectBlur=Effects.BluredTopDownBounds;

         //   PageHeight=1290+settings.Count*90;
            scrollbar=new Scrollbar(GetDataTexture(@"Buttons\Scrollbar\Top"), GetDataTexture(@"Buttons\Scrollbar\Center"), GetDataTexture(@"Buttons\Scrollbar\Bottom")){
                maxheight=PageHeight/*-Global.WindowHeight+60+60+90+30*/,
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

        void ClickMenu(object sender, EventArgs e) {
            if (afterrestart) System.Windows.Forms.MessageBox.Show(Lang.Texts[1616]);

            ((Menu)Rabcr.screen).GoToMenu(new MainMenu());
        }

        void Move(object sender, EventArgs e) {
            start=-1;

            yy=(int)(-scrollbar.scale*(PageHeight-Global.WindowHeight+75+65));

            for (int i=0; i<settings.Count; i++){
                SettingItem item=settings[i];
                if (yy>-50 &&yy<Global.WindowHeight-160){
                    if (start==-1)start=i;
                    end=i;
                    if (Global.WindowWidth>600){
                        if (item  is SettingMessage message) item.X=Global.WindowWidthHalf-DocumentSize+DocumentSize/*/2*/-message.centerDelta;
                      else  item.X=Global.WindowWidthHalf-DocumentSize/2;
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
            Setting.SaveSetting();
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
            for (int i=start; i<imax && i>=0; i++){
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
           // PageHeight=settings.Count*90-Global.WindowHeight;
            scrollbar.Scroll(0);
            Move(null,new EventArgs());
            worldsTarget?.Dispose();
            worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65);

            effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
            effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);

            scrollbar.height=Global.WindowHeight-75-65-2;
            scrollbar.scale=0;
          //  scrollbar.maxheight=PageHeight-Global.WindowHeight;

            buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-54);

            scrollbar.PositionX=Global.WindowWidth-35;
        }

        void SetTexts() {
            settings=new List<SettingItem> {

            #region Keyboard
                new SettingHeader(Lang.Texts[98])
            };
            {
                SettingKey button=new(tex, Lang.Texts[100], Setting.KeyLeft);
                button.Click+=ClickKeyLeft;
                settings.Add(button);

                void ClickKeyLeft() {
                    Setting.KeyLeft=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new(tex, Lang.Texts[102], Setting.KeyRight);
                button.Click+=ClickKeyRight;
                settings.Add(button);

                void ClickKeyRight() {
                    Setting.KeyRight=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new(tex, Lang.Texts[104], Setting.KeyJump);
                button.Click+=ClickKeyJump;
                settings.Add(button);

                void ClickKeyJump() {
                    Setting.KeyJump=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new(tex, Lang.Texts[106], Setting.KeyRun);
                button.Click+=ClickKeyRun;
                settings.Add(button);

                void ClickKeyRun() {
                    Setting.KeyRun=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new(tex, Lang.Texts[1513], Setting.KeyFlyMode);
                button.Click+=ClickKeyRun;
                settings.Add(button);

                void ClickKeyRun() {
                    Setting.KeyFlyMode=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new(tex, Lang.Texts[108], Setting.KeyInventory);
                button.Click+=ClickKeyInventory;
                settings.Add(button);

                void ClickKeyInventory() {
                    Setting.KeyInventory=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new(tex, Lang.Texts[110], Setting.KeyMessage);
                button.Click+=ClickKeyMessage;
                settings.Add(button);

                void ClickKeyMessage() {
                    Setting.KeyMessage=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new(tex, Lang.Texts[112], Setting.KeyDropItem);
                button.Click+=ClickKeyDropItem;
                settings.Add(button);

                void ClickKeyDropItem() {
                    Setting.KeyDropItem=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new(tex, Lang.Texts[114], Setting.KeyExit);
                button.Click+=ClickKeyExit;
                settings.Add(button);

                void ClickKeyExit() {
                    Setting.KeyExit=button.Key;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingKey button=new(tex, Lang.Texts[1514], Setting.KeyShowInfo);
                button.Click += () => {
                    Setting.KeyShowInfo=button.Key;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }
            {
                SettingOnOff button=new(tex, Lang.Texts[1615], Setting.InvertedMouse);
                button.Click += () => {
                    Setting.InvertedMouse=button.ON;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }
            #endregion

            #region Camera options
            // Camera text
            settings.Add(new SettingHeader(Lang.Texts[123]));

            //Brightness
            { 
                SettingMovemer button=new(Lang.Texts[354], line, movemer) {
                    Scale=Setting.NightBrightness
                };
                button.Click += () => { 
                    Setting.NightBrightness=button.Scale;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }   
            
            // Zoom
            {
                int zoom=4;
                switch (Setting.Zoom) {
                    case 1: zoom=0; break;
                    case 1.25f: zoom=1; break;
                    case 1.5f:zoom=2; break;
                    case 1.75f: zoom=3; break;
                    case 2:zoom=4; break;
                    case 2.5f: zoom=5; break;
                    case 3: zoom=6; break;
                    case 4: zoom=7; break;
                    case 5: zoom=8; break;
                    case 6: zoom=9; break;
                    case 7: zoom=10; break;
                }

                SettingSwitcher button=new(tex, Lang.Texts[126], new string[]{ Lang.Texts[272], Lang.Texts[273], Lang.Texts[274], Lang.Texts[275],Lang.Texts[276],Lang.Texts[277],Lang.Texts[278],Lang.Texts[279],Lang.Texts[1595],Lang.Texts[1596],Lang.Texts[280]},zoom);
                button.Click+=ClickZoom;
                settings.Add(button);

                void ClickZoom() {
                    Setting.Zoom = button.selected switch {
                        0 => 1,
                        1 => 1.25f,
                        2 => 1.5f,
                        3 => 1.75f,
                        4 => 2,
                        5 => 2.5f,
                        6 => 3f,
                        7 => 4f,
                        8 => 5f,
                        9 => 6f,
                        10 => 7f,
                        _ => throw new NotImplementedException(),
                    };
                    ((Menu)Rabcr.screen).RefreshBackground();
                    Global.ChangedSettings=true;
                }
            }
            
            // Window scale
            {
                SettingSwitcher button=new(tex, Lang.Texts[130], new string[]{ Lang.Texts[151], Lang.Texts[152], Lang.Texts[153]}, (int)Setting.currentWindow);
                button.Click+=ClickWindow;
                settings.Add(button);

                void ClickWindow() {
                    Setting.currentWindow=(Setting.Window)button.selected;
                    SetWindow();
                    Global.ChangedSettings=true;
                }
            }

            //FPS
            {
                SettingOnOff button=new(tex, Lang.Texts[132], Setting.Fps);
                button.Click+=ClickFps;
                settings.Add(button);

                void ClickFps() {
                    Setting.Fps=button.ON;
                    Global.ChangedSettings=true;
                }
            }
            #endregion

            #region Graphics

            #endregion

            // Animations
            settings.Add(new SettingHeader(Lang.Texts[1612]));
          
            // Vignetting
            {
                SettingOnOff button = new(tex, Lang.Texts[1597], Setting.Vignetting);
                button.Click += () => {
                    Setting.Vignetting=button.ON;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }

            // Fog
            {
                SettingSwitcher button = new(tex, Lang.Texts[1598], new string[]{Lang.Texts[1602], Lang.Texts[154], Lang.Texts[1603] }, (int)Setting.Fog);
                button.Click += () => {
                    Setting.Fog=(Setting.FogTypes)button.selected;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }

            // Half shadows / polo stin
            {
                SettingOnOff button = new(tex, Lang.Texts[366], Setting.HalfShadows);
                button.Click += () => {
                    Setting.HalfShadows=button.ON;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }

            // Waving elements
            {
                SettingOnOff button = new(tex, Lang.Texts[1599], Setting.WavingElements);
                button.Click += () => {
                    Setting.WavingElements=button.ON;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }

            // Interaction mess - jump, destroing mess
            {
                SettingOnOff button = new(tex, Lang.Texts[1600], Setting.InteractionMess);
                button.Click += () => {
                    Setting.InteractionMess=button.ON;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }

            // Clouds
            {
                SettingOnOff button = new(tex, Lang.Texts[1601], Setting.Clouds);
                button.Click += () => {
                    Setting.Clouds=button.ON;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }
               
            // FallingLeaves
            {
                SettingOnOff button = new(tex, Lang.Texts[1608], Setting.FallingLeaves);
                button.Click += () => {
                    Setting.FallingLeaves=button.ON;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }
             
            // BackgroundFancy
            {
                SettingOnOff button = new(tex, Lang.Texts[1610], Setting.BackgroundFancy);
                button.Click += () => {
                    Setting.BackgroundFancy=button.ON;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }
            
            // BetterSnowAndRain
            {
                SettingOnOff button = new(tex, Lang.Texts[1611], Setting.BetterSnowAndRain);
                button.Click += () => {
                    Setting.BetterSnowAndRain=button.ON;
                    Global.ChangedSettings=true;
                };
                settings.Add(button);
            }

            // AA
            settings.Add(new SettingHeader(Lang.Texts[1613]));
          
            // MultiSampling
            {
                int index=-1;
                index = (int)Setting.Multisapling switch {
                    2 => 1,
                    4 => 2,
                    8 => 3,
                    16 => 4,
                    _ => 0,
                };
                SettingSwitcher button = new(tex, Lang.Texts[1609], new string[]{ Lang.Texts[87/*272*/], Lang.Texts[276], Lang.Texts[279], Lang.Texts[1604], Lang.Texts[1605]}, index);
                button.Click += () => {
                    Setting.Multisapling = button.selected switch {
                        0 => 1,
                        1 => 2,
                        2 => 4,
                        3 => 8,
                        4 => 16,
                        _ => 0
                    };
                    Global.ChangedSettings = true;
                    afterrestart=true;
                  //  System.Windows.Forms.MessageBox.Show(Lang.Texts[1616]);
                };
                settings.Add(button);
            }

            // Upscaling
            {
                //float maxUpscaling=20f;
                //if (Graphics.GraphicsProfile==GraphicsProfile.HiDef){
                //    float scale = 8192f / GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                //    if (scale<maxUpscaling)maxUpscaling=scale;

                //    float scale2 = 8192f / GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                //    if (scale2<maxUpscaling) maxUpscaling=scale2;
                //} else { 
                //    float scale = 4096f / GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                //    if (scale<maxUpscaling) maxUpscaling=scale;

                //    float scale2 = 4096f / GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                //    if (scale2<maxUpscaling) maxUpscaling=scale2;
                //}
                //if (Setting.UpScalingSuperSapling>maxUpscaling) { 
                //    if (Setting.UpScalingSuperSapling==16) Setting.UpScalingSuperSapling=8;
                //} 
                //if (Setting.UpScalingSuperSapling>maxUpscaling) { 
                //    if (Setting.UpScalingSuperSapling==8) Setting.UpScalingSuperSapling=4;
                //}
                //if (Setting.UpScalingSuperSapling>maxUpscaling) { 
                //    if (Setting.UpScalingSuperSapling==4) Setting.UpScalingSuperSapling=2;
                //}

                //if (Setting.UpScalingSuperSapling>maxUpscaling) { 
                //    if (Setting.UpScalingSuperSapling==2) Setting.UpScalingSuperSapling=1;
                //}
               // Setting.UpScalingSuperSapling=1;
                int index=-1;
                index = (int)Setting.UpScalingSuperSapling switch {
                    -1 => 0,
                    0 => 0,
                    1 => 1,
                    2 => 2,
                    4 => 3,
                   // 8 => 4,
                  //  16 => 5,
                    _ => 0,
                };
                string[] res;
               // if (maxUpscaling>=16) res=new string[]{ Lang.Texts[1607], Lang.Texts[/*272*/87], Lang.Texts[276], Lang.Texts[279], Lang.Texts[1604], Lang.Texts[1605]};
              //  else if (maxUpscaling>=8) res=new string[]{ Lang.Texts[1607], Lang.Texts[272], Lang.Texts[276], Lang.Texts[279], Lang.Texts[1604]};
               // else 
               /* if (maxUpscaling>=8) */res=new string[]{ Lang.Texts[1607], Lang.Texts[/*272*/87], Lang.Texts[276], Lang.Texts[279]/*, Lang.Texts[1604]*/};
                //if (maxUpscaling>=4) res=new string[]{ Lang.Texts[1607], Lang.Texts[/*272*/87], Lang.Texts[276], Lang.Texts[279]};
                //else if (maxUpscaling>=2) res=new string[]{ Lang.Texts[1607], Lang.Texts[/*272*/87], Lang.Texts[276]};
                //else res=new string[]{ Lang.Texts[1607], Lang.Texts[/*272*/87]};
                SettingSwitcher button = new(tex, Lang.Texts[1606], res, index);
                button.Click += () => {
                    Setting.UpScalingSuperSapling = button.selected switch {
                        0 => 0,
                        1 => 1,
                        2 => 2,
                        3 => 4,
                    //    4 => 8,
                       // 5 => 16,
                        _ => -1
                    };
                  //  if (Setting.UpScalingSuperSapling>maxUpscaling) Setting.UpScalingSuperSapling=1;
                    Global.ChangedSettings = true;
                };
                settings.Add(button);
            }

            // Graphics profile
            {
                SettingSwitcher button = new(tex, Lang.Texts[319], new string[]{ Lang.Texts[318], Lang.Texts[317] }, (int)Setting.GraphicsProfile);
                button.Click += () => {
                    Setting.GraphicsProfile=(GraphicsProfile)button.selected;
                    Global.ChangedSettings=true;
                    afterrestart=true;
                    //System.Windows.Forms.MessageBox.Show(Lang.Texts[1616]);
                };
                settings.Add(button);
            }

            //{
            //    SettingSwitcher button = new(tex, Lang.Texts[125], new string[]{ Lang.Texts[1587], Lang.Texts[1588], Lang.Texts[1589], Lang.Texts[1590]}, (int)Setting.AnimationsGame);
            //    button.Click+=ClickAnimations;
            //    settings.Add(button);

            //    void ClickAnimations() {
            //        Setting.AnimationsGame=(Setting.GameAnimations)button.selected;
            //        Global.ChangedSettings=true;
            //    }
            //}


            //{
            //    SettingSwitcher button=new SettingSwitcher(tex, Lang.Texts[319], new string[]{ Lang.Texts[317], Lang.Texts[318]},(int)Setting.GraphicsProfile);
            //    button.Click+=ClickGraphicsProfile;
            //    settings.Add(button);

            //    void ClickGraphicsProfile() {
            //        Setting.GraphicsProfile=(GraphicsProfile)button.selected;
            //        Global.ChangedSettings=true;
            //        System.Windows.Forms.MessageBox.Show(Lang.Texts[343]);
            //    }
            //}
            if (File.Exists(@"C:\Program Files\NVIDIA Corporation\Control Panel Client\nvcplui.exe")){
                SettingButton button=new(tex,Lang.Texts[342]);
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
                SettingMessage button=new(Lang.Texts[340]);
                settings.Add(button);
            }
            {
                try {
                    List<(string,long)> AdapterNames = new();
                    using (var searcher = new ManagementObjectSearcher("select * from Win32_VideoController")) {
                        foreach (ManagementObject obj in searcher.Get()) {
                            long.TryParse(obj["AdapterRAM"].ToString(), out long u);
                            AdapterNames.Add(new (obj["Name"].ToString(), u));
                        }
                    }
                    if (AdapterNames.Count>1){ 
                        var GraphicsCard = Rabcr.Game.GraphicsDevice;
                        foreach (GraphicsAdapter EnumeratedAdapter in GraphicsAdapter.Adapters) {

                            if (EnumeratedAdapter == GraphicsCard.Adapter) {
                                string usingGPU=EnumeratedAdapter.Description;
                                foreach (var z in AdapterNames) { 
                                    if (z.Item1==usingGPU) {
                                        long best=0;
                                        foreach (var p in AdapterNames) {
                                            if (p.Item2>best) best=p.Item2;
                                        }
                                        if (z.Item2!=best) { 
                                            settings.Add(new SettingHeader(Lang.Texts[1591]));
                                            settings.Add(new SettingMessage(Lang.Texts[1592]));
                                            settings.Add(new SettingMessage(Lang.Texts[1593]));
                                            settings.Add(new SettingMessage(Lang.Texts[1594]+usingGPU));
                                        }
                                        break;
                                    }
                                }
                            }
                        }    
                    }
                } catch { }
            }
            Move(null, new EventArgs());
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

            #region Volume
            settings.Add(new SettingHeader(Lang.Texts[134]));
            {
                SettingMovemer button=new(Lang.Texts[135], line, movemer){ Scale=Setting.VolumeMusic };
                button.Click+=ClickVolumeMusic;
                settings.Add(button);

                void ClickVolumeMusic() {
                    Setting.VolumeMusic=button.Scale;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingMovemer button=new(Lang.Texts[137], line, movemer){ Scale=Setting.VolumeEffects };
                button.Click+=ClickVolumeEffects;
                settings.Add(button);

                void ClickVolumeEffects() {
                    Setting.VolumeEffects=button.Scale;
                    Global.ChangedSettings=true;
                }
            }
            #endregion

            #region Menu
            settings.Add(new SettingHeader(Lang.Texts[114]));
            {
                SettingOnOff button = new(tex, Lang.Texts[124], Constants.AnimationsControls);
                button.Click+=ClickAnimations;
                settings.Add(button);

                void ClickAnimations() {
                    Constants.AnimationsControls=button.ON;
                    Global.ChangedSettings=true;
                }
            }
            {
                SettingSwitcher button=new(tex,Lang.Texts[139], new string[] { Lang.Texts[148], Lang.Texts[154], Lang.Texts[155],Lang.Texts[156]}, Setting.slideChangeTime==0 ? 0 : (Setting.slideChangeTime==0.1f ? 1 : (Setting.slideChangeTime==0.05f ? 2 : (Setting.slideChangeTime==0.01f ? 3 : 0))));
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
                SettingOnOff button=new(tex, Lang.Texts[141], Setting.Background);
                button.Click+=ClickBackground;
                settings.Add(button);

                void ClickBackground() {
                    Setting.Background=button.ON;
                    Global.ChangedSettings=true;
                }
            }
            #endregion

            #region Player
            //if (!Global.OnlineAccount) {
            settings.Add(new SettingHeader(Lang.Texts[99]));
            {
                SettingOnOff button = new(tex, Lang.Texts[143], !Global.YoungPlayer);
                button.Click+=ClickMaturePlayer;
                settings.Add(button);

                void ClickMaturePlayer() {
                    button.ON=false;
                    if (Global.YoungPlayer) {
                        FormTest18Plus formTest = new();
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
            #endregion
            //  } else {
            //    settings.Add(new SettingHeader(Lang.Texts[145]+" "+(Global.YoungPlayer ? Lang.Texts[146]: Lang.Texts[147])));
            // }


        
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