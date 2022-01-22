using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class XColor {
        public float
            R,G,B,
            deltaR, deltaG, deltaB,
            gR,gG,gB,
            rotation,
            speed,
            dir;

        int change;

        const float divider255=1/255f;

        public XColor() {
            dir=FastRandom.IntPlusMinusOne();
         //   Console.WriteLine(dir);
           // if (Rabcr.random.Bool()) dir = 1; else dir = -1;
            speed=(FastRandom.Float()*5+5f) * 0.0001f;
            rotation=FastRandom.Rotatin();//.Int(360)*0.0174533f;

            gR=R=FastRandom.Float();
            gG=G=FastRandom.Float();
            gB=B=FastRandom.Float();

            change=120;
        }

        public void Update(){
            R+=deltaR;
            G+=deltaG;
            B+=deltaB;

            rotation += speed * dir;

            change--;

            if (change<0) {
                gR=FastRandom.Float();
                gG=FastRandom.Float();
                gB=FastRandom.Float();

                deltaR=(gR-R)*divider255;
                deltaG=(gG-G)*divider255;
                deltaB=(gB-B)*divider255;
                change=255;
            }
        }

        public Color ToColor() => new(R, G, B);
    }

    class MainMenu :MenuScreen {

        XColor[] colors;
        Effect effectBlur, effectColorize,effectNeon;
        Button[] buttonsSide;
        RenderTarget2D rtColorize,rtBlur,rtBlur2,rtNeon;

        DynamicText gameName;

        public override void Init() {
            Rabcr.spriteBatch=spriteBatch;

            #region For texts
            effectBlur=Content.Load<Effect>("Default/Effects/GaussianBlur");
            effectColorize=Content.Load<Effect>("Default/Effects/Colorize");
            effectNeon=Content.Load<Effect>("Default/Effects/Neon");

            colors=new XColor[]{
                new XColor(),
                new XColor(),
                new XColor(),
                new XColor()
            };
            #endregion

            {
                var buttonCharacter = new Button(Textures.ButtonLongLeft, Lang.Texts[82]);
                buttonCharacter.Click+=GoToCharacter;

                var buttonSingleplayer = new Button(Textures.ButtonLongLeft, Lang.Texts[6]);
                buttonSingleplayer.Click+=GoToSingleplayer;

               // var buttonMultiplayer = new Button(Textures.ButtonLongLeft, Lang.Texts[7]);
               // buttonMultiplayer.Click+=GoToMultiplayer;

                var buttonSetting = new Button(Textures.ButtonLongLeft, Lang.Texts[8]);
                buttonSetting.Click+=GoToSettings;

			    var buttonInformation = new Button(Textures.ButtonLongLeft, Lang.Texts[5]);
                buttonInformation.Click+=GoToInformations;

                var buttonLanguage=new Button(Textures.ButtonLongLeft, (Lang.Texts[121]=="Language" ?  Lang.Texts[121]: Lang.Texts[121])+" (Language)");
			    buttonLanguage.Click+=GoToLanguages;

                var buttonEnd = new Button(Textures.ButtonLongLeft, Lang.Texts[10]);
                buttonEnd.Click+=GoToEnd;

                buttonsSide=new Button[]{
                    buttonSingleplayer,

                    //#if DEBUG
                    //buttonMultiplayer,
                    //#endif

                    buttonCharacter,
                    buttonSetting,
                    buttonLanguage,
                    buttonInformation,
                    buttonEnd,
                };
            }

            //if (Global.Logged) {
            //    //if (Global.OnlineAccount) {
            //    //    buttonLogin = new Button(Textures.ButtonRight, Lang.Texts[11]);
            //    //    buttonLogin.Click+=LogStuff;
            //    //} else {
            //        buttonLogin = new Button(Textures.ButtonRight, Lang.Texts[11]);
            //        buttonLogin.Click+=LogStuff;
            //  //  }
            //} else {
            //    buttonLogin = new Button(Textures.ButtonRight, Lang.Texts[12]);
            //    buttonLogin.Click+=LogStuff;
            //}


            //if (Setting.FirstRun) { 
            //    var GraphicsCard = Rabcr.Game.GraphicsDevice;

            //      string usingGPU="";
            //    int NumberOfAdapters = GraphicsAdapter.Adapters.Count;

            //    List<string> AdapterNames = new();

            //    foreach (GraphicsAdapter EnumeratedAdapter in GraphicsAdapter.Adapters)

            //    {

            //        if (EnumeratedAdapter == GraphicsCard.Adapter)

            //        {

            //            //This is the one being used.
            //             usingGPU=EnumeratedAdapter.Description;
            //            break;
            //        }

            //        AdapterNames.Add(EnumeratedAdapter.Description);

            //    }   
            //      Debug.WriteLine(AdapterNames);
            //}

            SetTexts();

            Resize();
        }

        void GoToSettings(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MenuSetting());

        //void LogStuff(object sender, EventArgs e) {
        //    if (!Rabcr.IsBannedCountry) {
        //        if (Global.Logged){
        //            Rabcr.SaveSetting();
        //            Global.Logged=false;
        //            //Global.OnlineAccount=false;
        //            Global.Pass=null;
        //            Setting.Name="Player";
        //            if (Environment.GetCommandLineArgs().Length>=3){
        //                Setting.Path=Environment.GetCommandLineArgs()[2]+"\\"+Setting.Name+"\\";
        //            } else {
        //                Setting.Path=new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"\\"+Setting.Name+"\\";
        //            }

        //            if (File.Exists(Path.GetTempPath()+"\\rabcrLastPassword.txt")) File.Delete(Path.GetTempPath()+"\\rabcrLastPassword.txt");
        //        } else {
        //           using( FormLogin login=new FormLogin()){
        //            login.ShowDialog();
        //            if (login.OK){
        //                if (!Directory.Exists(Setting.Path))Directory.CreateDirectory(Setting.Path);
        //                if (!string.IsNullOrEmpty(login.getdata)) {
        //                    string data=login.getdata.Replace("/",Environment.NewLine);
        //                    data=data.Replace("_","=");
        //                    data=data.Replace("*","#");
        //                    File.WriteAllText(Setting.Path+@"\Setting.ini",data);
        //                    try{
        //                        Rabcr.LoadSetting();
        //                    }catch{
        //                        Rabcr.SaveSetting();
        //                    }
        //                }

        //                if (!File.Exists(Setting.Path+@"MenuWorld\Generated.txt")) {
        //                    BGenerateWorld gwm = new BGenerateWorld();
        //                    gwm.Action();
        //                }
        //            }

        //            login.geDoPanel1.Stop();
        //            }
        //        }
        //        SetTexts();
        //    }
        //}

        void GoToEnd(object sender, EventArgs e) {
            Game.Exit();
            System.Windows.Forms.Application.Exit();
            Environment.Exit(0);
        }

        void GoToCharacter(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MenuCharacter());

        void GoToLanguages(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MenuLang());

        void GoToInformations(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new Informations());

        void GoToSingleplayer(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MenuSingleplayer());
        #if MULTIPLAYER
        void GoToMultiplayer(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MenuMultiplayer());
        #endif

        public override void Update(GameTime gameTime) {
            //mouseState=Mouse.GetState();

            //for (int i=0; i<colors.Length; i++){
            colors[0].Update();
            colors[1].Update();
            colors[2].Update();
            colors[3].Update();
            //}

            for (int i=0; i<buttonsSide.Length; i++){
                buttonsSide[i].Update();
            }

            //buttonLogin.Update();

            base.Update(gameTime);
        }

        public override void PreDraw() {

            Graphics.SetRenderTarget(rtColorize);
            effectColorize.CurrentTechnique.Passes[0].Apply();
            Graphics.Clear(Color.Transparent);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, effectColorize, null);

            for (int i=0; i<colors.Length; i++){
                gameName.Draw(spriteBatch, Global.WindowWidthHalf, Global.WindowHeightHalf, colors[i].ToColor(), colors[i].rotation);
            }

            spriteBatch.End();

            Graphics.SetRenderTarget(rtNeon);

            Graphics.Clear(Color.Transparent);
            effectNeon.CurrentTechnique.Passes[0].Apply();


            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, effectNeon, null);
            spriteBatch.Draw(rtColorize, new Vector2(0, 0), Color.White);

            spriteBatch.End();

            Graphics.SetRenderTarget(rtBlur);
            BlurImage(6, 4);
            effectBlur.CurrentTechnique.Passes[0].Apply();
            Graphics.Clear(Color.Transparent);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, effectBlur, null);
            spriteBatch.Draw(rtColorize, new Vector2(0, 0), Color.White);

            spriteBatch.End();

            Graphics.SetRenderTarget(rtBlur2);
            BlurImage(6, 4);
            effectBlur.CurrentTechnique.Passes[0].Apply();
            Graphics.Clear(Color.Transparent);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, effectBlur, null);
            spriteBatch.Draw(rtBlur, new Vector2(0, 0), Color.White);

            spriteBatch.End();
            Graphics.SetRenderTarget(null);
        }

        void BlurImage(int radius = 2, float amount = 1.0F) {
            int radius2a1=radius * 2 + 1;
            float sigma = radius / amount;
            float[] kernel = new float[radius2a1];
            int index/* = 0*/;
            float twoSigmaSquare = 2 * sigma * sigma;
            float sigmaRoot = (float)Math.Sqrt(twoSigmaSquare * Math.PI);
            Vector2[] offsetsHoriz = new Vector2[radius2a1],
            offsetsVert = new Vector2[radius2a1];

            for (int i = -radius; i <= radius; i++) {
                index = i + radius;
                offsetsHoriz[index] = new Vector2((float)i/ Global.WindowWidth, 0f);
                offsetsVert[index] = new Vector2(0f, (float)i/ Global.WindowHeight);
            }

            float total = 0f;
            float distance /*= 0f*/;
           // index = 0;

            for (int i = -radius; i <= radius; i++) {
                distance = i * i;
                index = i + radius;
                kernel[index] =(float)Math.Exp(-distance /(double)twoSigmaSquare) /sigmaRoot;
                total += kernel[index];
            }

            for (int i = 0; i <= kernel.Length - 1; i++) kernel[i] /= total;

            effectBlur.CurrentTechnique = effectBlur.Techniques[0];
            effectBlur.Parameters["SampleWeights"].SetValue(kernel);
            effectBlur.Parameters["SampleOffsets"].SetValue(offsetsHoriz);
        }

        public override void Draw(GameTime gameTime, float f) {
            Color whitef = Color.White*f;

            #region Draw blured texts
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(rtBlur2, Vector2.Zero, whitef);
            spriteBatch.Draw(rtNeon, Vector2.Zero, whitef);
            spriteBatch.End();
            #endregion

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            #region Buttons
            {
                for (int i=0; i<buttonsSide.Length; i++){
                    buttonsSide[i].ButtonDraw(spriteBatch,f);
                }

             //  if (!Rabcr.IsBannedCountry){ buttonLogin.ButtonDraw(spriteBatch, f); }
            }
            spriteBatch.End();
            #endregion

            //if (!Rabcr.IsBannedCountry){
            // //   if (Global.Logged) {
            //        spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, effectColorize);
            //        effectColorize.CurrentTechnique.Passes[0].Apply();
            //        //logInText.Draw(spriteBatch, Color.White*f);
            //        spriteBatch.End();
            //  //  }
            //}
            base.Draw(gameTime);
        }

        //void ChangeLogIn(){
        //  //  if (Global.Logged) {
        //       // if (Global.OnlineAccount) {
        //        //    DInt s=BitmapFont.bitmapFont18.MeasureTextSingleLine(Setting.Name);
        //        //    logInText=new Text(Setting.Name, 80-s.X/2, Global.WindowHeight-50-s.Y-5,BitmapFont.bitmapFont18);
        //        //} else {
        //            DInt s=BitmapFont.bitmapFont18.MeasureTextSingleLine(/*"Offline: "+*/Setting.Name);
        //            logInText=new Text(/*"Offline: "+*/Setting.Name, 80-s.X/2, Global.WindowHeight-50-s.Y-5,BitmapFont.bitmapFont18);
        //       // }
        //   // }
        //}

        public override void Resize() {
            while (Global.WindowWidth==0 && Global.WindowHeight==0){
                System.Windows.Forms.Form MyGameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Rabcr.Game.Window.Handle);
                MyGameForm.WindowState =System.Windows.Forms.FormWindowState.Normal;
            }

            rtBlur2?.Dispose();
            rtBlur?.Dispose();
            rtColorize?.Dispose();
            rtNeon?.Dispose();

            rtBlur2=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight);
            rtBlur=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight);
            rtColorize=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight);
            rtNeon=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight);

            int x=Global.WindowWidth-400+70;
            int y=Global.WindowHeightHalf-280+178;
            for (int i=0; i<buttonsSide.Length; i++) {
                buttonsSide[i].Position=new Vector2(x, y);
                y+=89/2;
            }

            //buttonLogin.Position=new Vector2(0, Global.WindowHeight-50);
            //gameName.
            gameName=new DynamicText(Global.GameName, Global.WindowWidthHalf, Global.WindowHeightHalf/*, BitmapFont.bitmapFont34*/);
            //ChangeLogIn();
            base.Resize();
        }

        void SetTexts() {
          //  ChangeLogIn();
            gameName=new DynamicText(Global.GameName, Global.WindowWidthHalf, Global.WindowHeightHalf/*, BitmapFont.bitmapFont34*/);
        }
    }
}