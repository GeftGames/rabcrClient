using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace rabcrClient {
    class Menu : Screen {

        #region Varibles
        #region Changes
        float glowIndex =0;
        bool goingS=true;
        bool goingA=false;
        #endregion
        public static KeyboardState newKeyboardState;
        public static MouseState newMouseState, oldMouseState;
        public static bool mouseDown;
        public static int  mousePosX, mousePosY, mousePosYCorrection;

        Background back;
        MenuScreen menuScreen,nextScreen;
        float playing;
        #endregion

        public Menu(MenuScreen screen) {
            menuScreen=screen;
        }

        public Menu() {
            menuScreen=new MainMenu();
        }

        public override void Init() {
            MediaPlayer.Volume=Setting.VolumeMusic;

            back=new Background(Graphics);

            menuScreen.Init();
        }

        public override void Shutdown() {
            if (Global.HasSoundGraphics)MediaPlayer.Stop();
        }

        public override void Update(GameTime gameTime) {
            // Set keyboard and mouse
            oldMouseState=newMouseState;
            newKeyboardState=Keyboard.GetState();
            newMouseState=Rabcr.newMouseState;

            // background world update
            back.Update(gameTime);

            // Set keyboard and mouse (full size and white rectangle, it's complicated)
            mouseDown=newMouseState.LeftButton == ButtonState.Pressed;
            mousePosX=newMouseState.X;
            mousePosY=newMouseState.Y;
            mousePosYCorrection=newMouseState.Y-75;
            UpdateTransform();

            // draw menu on background
            menuScreen.Update(gameTime);

            // Play songs
            if (Global.HasSoundGraphics){
                if (playing < 0) {
                    Song play/*=null*/;
                    switch (FastRandom.Int4()) {
                        case 0:  play = Songs.Happend;  break;
                        case 1:  play = Songs.Medium;   break;
                        case 2:  play = Songs.Root;     break;
                        default: play = Songs.Storm;    break;
                    }

                    try {
                        MediaPlayer.Play(play);
                        playing = (int)play.Duration.TotalMilliseconds;
                    } catch{ }
                } else playing-=16.66666666f;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            menuScreen.PreDraw();

            if (Setting.Background) back.Draw(spriteBatch);
            else Graphics.Clear(Color.CornflowerBlue);
            menuScreen.Draw(gameTime, glowIndex);

            base.Draw(gameTime);
        }

        public override void Resize() {
            menuScreen.Resize();
            base.Resize();
        }

        internal void RefreshBackground() => back.Refresh();

        public void GoToMenu(MenuScreen ms) {
            if (!goingS && !goingA) {
                if (nextScreen!=null) nextScreen.Shutdown();

                MediaPlayer.Volume=Setting.VolumeMusic;
                (nextScreen=ms).Init();
                goingA=true;
            }
        }

        void UpdateTransform() {
            if (goingA) {
                glowIndex-=Setting.slideChangeTime;
                if (glowIndex<0 || Setting.slideChangeTime==0) {
                    glowIndex=0;
                    goingA=false;
                    goingS=true;
                    menuScreen = nextScreen;
                }
            } else if (goingS) {
                glowIndex+=Setting.slideChangeTime;
                if (glowIndex>1f || Setting.slideChangeTime==0) {
                    glowIndex=1f;
                    goingS=false;
                }
            }
        }
    }
}