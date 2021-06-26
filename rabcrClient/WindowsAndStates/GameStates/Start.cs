using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.IO;
using System.Threading;
#if DEBUG
using System.Diagnostics;
#endif

namespace rabcrClient {
    class Start :Screen {
        enum AnimationState{ 
            No,
            Initing,
            StandBy,
            Ending,
            Finish,
        }
        AnimationState CurrentAnimationState;
      //  volatile int state;
        double LastChangeAnimation;
        double StartChangeAnimation;
        private Thread checking;

        volatile bool finish;
        //float disepearing;
      //  volatile bool ready=false;
        bool go=false;
       // Bar bar;
        float alpha;

  //      public float Process() {
  //          if (checking==null) return 1;
  //          if (!checking.IsAlive) return 1;
		//	//return state/1249f;
		//}

        public override void Init() {
            CurrentAnimationState=AnimationState.No;
            try {
                Textures.Logo=Content.Load<Texture2D>("Default\\Textures\\logo");
                Fonts.Medium=Content.Load<SpriteFont>("Default\\Fonts\\Medium");
            } catch (Microsoft.Xna.Framework.Content.ContentLoadException ex) {
                #if DEBUG
                Debug.WriteLine("Nelze načíst v RabCrData texturu \"Default\\Textures\\logo\" či písmo \"Default\\Fonts\\Medium\".");
                #endif
                System.Windows.Forms.MessageBox.Show(Lang.Texts[46]+":\r\n"+Lang.Texts[22]+".\r\n\r\n"+Lang.Texts[23]+":\r\n"+ex.Message);
                Environment.Exit(ex.HResult);
            }
          //  bar=new Bar();
         //   bar.ChangePos(Global.WindowWidthHalf,Global.WindowHeightHalf+32);
            LoadData();

            if (Constants.AnimationsControls)alpha=0;
            else alpha=1;

            (checking=new Thread(Check) {
                Priority=ThreadPriority.Highest
            }).Start();
        }

        public override void Update(GameTime gameTime) {
             if (gameTime.TotalGameTime.TotalMilliseconds>5000){
                if (!go) {
                    go=true;
                    Rabcr.GoTo(new Menu());
                    CurrentAnimationState=AnimationState.Finish;
                    //#if DEBUG
                    //Debug.WriteLine("Total state load: "+state);
                    //#endif
                }
            }

            switch (CurrentAnimationState) {
                case AnimationState.No:
                    if (gameTime.TotalGameTime.TotalMilliseconds>500) { 
                        StartChangeAnimation=gameTime.TotalGameTime.TotalMilliseconds-500;
                        CurrentAnimationState=AnimationState.Initing;
                    }
                    break;

                case AnimationState.Initing: 
                    if (alpha!=1) {
                        alpha+=gameTime.ElapsedGameTime.Milliseconds/500f;
                        if (alpha>1)alpha=1;
                    }

                    if (gameTime.TotalGameTime.TotalMilliseconds-StartChangeAnimation>1000) {
                        alpha=1;
                        CurrentAnimationState=AnimationState.StandBy;
                        LastChangeAnimation=gameTime.TotalGameTime.TotalMilliseconds-1000;
                    }
                    break;

                case AnimationState.StandBy:
                    if (finish) {

                        if (gameTime.TotalGameTime.TotalMilliseconds-StartChangeAnimation>2000+LastChangeAnimation) {
                            alpha=0;
                            CurrentAnimationState=AnimationState.Ending;
                        }
                    }
                    break;

                case AnimationState.Ending:
                    if (alpha!=1) {
                        alpha+=gameTime.ElapsedGameTime.Milliseconds/500f;
                        if (alpha>1)alpha=1;
                    }

                    if (gameTime.TotalGameTime.TotalMilliseconds-StartChangeAnimation>2500+LastChangeAnimation) {
                        alpha=0;
                        CurrentAnimationState=AnimationState.Finish;
                    }
                    break;

                case AnimationState.Finish:
                    if (gameTime.TotalGameTime.TotalMilliseconds-StartChangeAnimation>3000+LastChangeAnimation) {
                        if (!go) {
                            go=true;
                            Rabcr.GoTo(new Menu());
                            //#if DEBUG
                            //Debug.WriteLine("Total state load: "+state);
                            //#endif
                        }
                    }
                    break;
            }
        }

        public override void Draw(GameTime gameTime) {
            Graphics.Clear(Color.Black);
            spriteBatch.Begin();

          //  for (int i=0; i<Global.WindowHeight; i++) spriteBatch.Draw(Rabcr.Pixel,new Rectangle(0,i,Global.WindowWidth,1), new Color(i/765f,1,1));

            if (Textures.Logo!=null) {
                switch (CurrentAnimationState) {
                    case AnimationState.Initing: 
                        spriteBatch.Draw(Textures.Logo,new Vector2(Global.WindowWidthHalf-Textures.Logo.Width/2,Global.WindowHeightHalf-Textures.Logo.Height+20), Color.White*(float)Math.Sin(alpha*Math.PI/2f));
                        break;

                    case AnimationState.StandBy:
                        spriteBatch.Draw(Textures.Logo,new Vector2(Global.WindowWidthHalf-Textures.Logo.Width/2,Global.WindowHeightHalf-Textures.Logo.Height+20), Color.White);
                        break;

                    case AnimationState.Ending:
                        spriteBatch.Draw(Textures.Logo,new Vector2(Global.WindowWidthHalf-Textures.Logo.Width/2,Global.WindowHeightHalf-Textures.Logo.Height+20), Color.White*(1f-(float)Math.Sin(alpha*Math.PI/2f)));
                        break;
                } 
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

       // public override void Resize() {
            //bar.ChangePos(Global.WindowWidthHalf,Global.WindowHeightHalf+32);
        //}

        void Check() {
            if (File.Exists(Setting.Path+"GameStyle.txt")) {
                Setting.StyleName=File.ReadAllText(Setting.Path+"GameStyle.txt");
            }

            if (!File.Exists(Setting.Path+@"\\MenuBackground.ter")) {
                BGenerateWorld gwm = new BGenerateWorld();
                gwm.Action();
            }

            finish=true;
        }

        SpriteFont LoadDataFont(string str) => Content.Load<SpriteFont>(Setting.StyleName+"\\Fonts\\"+str);
		
        Effect LoadDataEffect(string str) => Content.Load<Effect>(Setting.StyleName+"\\Effects\\"+str);

        Song LoadDataSong(string str) => Content.Load<Song>(Setting.StyleName+"\\Songs\\"+str);
		
        SoundEffect LoadDataSoundEffect(string str) => Content.Load<SoundEffect>(Setting.StyleName+"\\SoundEffects\\"+str);
		
        Texture2D LoadDataTexture(string str) => Content.Load<Texture2D>(Setting.StyleName+"\\Textures\\"+str);
		
        void LoadData() {
            Fonts.Medium=LoadDataFont("Medium");
            Fonts.Small=LoadDataFont("Small");
            Fonts.SmallItalic=LoadDataFont("SmallItalic");

            Effects.BluredTopDownBounds=LoadDataEffect("BluredTopDownBounds");

            Songs.Happend=LoadDataSong("Happend");
            Songs.Medium=LoadDataSong("Medium");
            Songs.Root=LoadDataSong("Root");
            Songs.Storm=LoadDataSong("Storm");
            Songs.Spacelandia=LoadDataSong("Spacelandia");

            SoundEffects.Eat=LoadDataSoundEffect("Eat");
            SoundEffects.Eat=LoadDataSoundEffect("Shot");
            SoundEffects.Rain=LoadDataSoundEffect("Weather/Rain");
            SoundEffects.Steps=LoadDataSoundEffect("Movements/Steps");
            SoundEffects.StepsInSnow=LoadDataSoundEffect("Movements/StepsInSnow");
            SoundEffects.Jump=LoadDataSoundEffect("Movements/Jump");
            SoundEffects.JumpInSnow=LoadDataSoundEffect("Movements/JumpInToSnow");
            SoundEffects.Wind=LoadDataSoundEffect("Weather/Wind");

            Textures.ButtonCenter=LoadDataTexture("Buttons/Menu/Center");
            Textures.ButtonLeft=LoadDataTexture("Buttons/Menu/Left");
            Textures.ButtonLongLeft=LoadDataTexture("Buttons/Menu/LongLeft");
            Textures.ButtonPlay=LoadDataTexture("Buttons/Menu/Play");
            Textures.ButtonRight=LoadDataTexture("Buttons/Menu/Right");
            Textures.ButtonLong=LoadDataTexture("Buttons/Menu/Long");
        }
        // void SetWindow() {
        //    if (Setting.currentWindow==Setting.Window.Fullscreen) {
        //        System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
        //        System.Windows.Forms.Screen myScreen = System.Windows.Forms.Screen.AllScreens[0];

        //        gameForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
        //        GraphicsManager.PreferredBackBufferWidth = myScreen.Bounds.Width;
        //        GraphicsManager.PreferredBackBufferHeight = myScreen.Bounds.Height;
        //        GraphicsManager.ApplyChanges(); // Not necessary, however this is a method in my code


        //        gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

        //        gameForm.Left = myScreen.WorkingArea.Left;
        //        gameForm.Top = myScreen.WorkingArea.Top;
        //    }
        //    if (Setting.currentWindow==Setting.Window.Maxi) {
        //        System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
        //        if (gameForm.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None) {
        //             gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;


        //            gameForm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(
        //            System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe");
        //        }

        //        gameForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        //    }
        //    //if (Setting.currentWindow==Setting.Window.Normal) {
        //    //    System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
        //    //    if (gameForm.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None) {
        //    //         gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;


        //    //        gameForm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(
        //    //        System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe");
        //    //    }

        //    //    GraphicsManager.PreferredBackBufferWidth = 848;
        //    //    GraphicsManager.PreferredBackBufferHeight = 560;
        //    //    GraphicsManager.ApplyChanges();
        //    //}
        //}
    }
}