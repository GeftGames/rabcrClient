using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
//using Microsoft.WindowsAPICodePack.Taskbar;
using System.IO;
using System.Diagnostics;

namespace rabcrClient {
    class GWorld :Screen {

        #region Varibles
        readonly Color black25=Color.Black*0.25f;
        Button buttonMenu;
        GenerateWorld generateWorld;
        readonly string dir, strBuildingW;
        Bar bar;
        Vector2 centerTS, centerTSSH;
        bool go;
        bool showExit;
        float showing=0.1f;
        MouseState ms;
        float time;
        #endregion

        public GWorld(string Dir) {
            dir=Dir;
            strBuildingW=Lang.Texts[314];
        }

        public override void Init() {

            bar=new Bar();
            try{
                string[] file=File.ReadAllLines(dir+"\\Options.txt");
                generateWorld=new GenerateWorld(dir, (GenerateWorld.WorldSize)int.Parse(file[1]));
                generateWorld.Action();
            } catch {
                System.Windows.Forms.MessageBox.Show("Bylo zjištěno, že nastavení světa v souboru \"Options.txt\" namá vhodné parametry nebo soubor neexistuje. Může to být tím, že se pokoušíte spustit svět, z minulích verzí hry.","Špatné nastavení světa");
                Rabcr.GoTo(new Menu(new MenuSingleplayer()));
            }
            showing=0;
            time=0;
            Resize();
        }

        public override void Update(GameTime gameTime) {
            time+=gameTime.ElapsedGameTime.Milliseconds;

            if (showExit) {
                ms=Mouse.GetState();
                Menu.mouseDown=ms.LeftButton==ButtonState.Pressed;
                Menu.mousePosX=ms.X;
                Menu.mousePosY=ms.Y;
                if (Constants.AnimationsControls){
                    if (showing<1){
                        showing+=0.1f;
                    }
                }else showing=1f;

                //if (buttonMenu.Click) {
                //    generateWorld.Stop();
                //    Rabcr.GoTo(new Menu(new MenuSingleplayer()));
                //}
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            spriteBatch.Begin();

            // Background
            for (int i = 0; i <Global.WindowHeight; i++) {
                float x=(float)i/3/255;
                if (x>1f)x=1f;
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(0, i, Global.WindowWidth, 1), new Color(x, 1, 1));
            }

            // Bar
            bar.Filled=generateWorld.Process;
            bar.Draw(spriteBatch);

            // Draw "Building world..."
            DrawTextShadowMinMedium();

            if (generateWorld.Finish) {
                if (!go) {
                    //TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                    go=true;
                    #if DEBUG
                    Stopwatch sw=new Stopwatch();
                    sw.Start();
                    #endif

                    Rabcr.GoTo(new SinglePlayer(dir));

                    #if DEBUG
                    sw.Stop();
                    Debug.WriteLine("First game run after generation in "+sw.ElapsedMilliseconds+" ms");
                    #endif
                }
            }

            if (time>1000){
                if (!showExit){
                    ms=new MouseState();
                    buttonMenu=new Button(Textures.ButtonLongLeft, Lang.Texts[1]) {
                        Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-55)
                    };
                    buttonMenu.Click=ClickMenu;
                    showExit=true;
                }
            }

            if (showExit) {
                buttonMenu.ButtonDraw(spriteBatch,showing);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        void ClickMenu(object sender, EventArgs e) {
            generateWorld.Stop();
            Rabcr.GoTo(new Menu(new MenuSingleplayer()));
        }

        public override void Resize() {
            if (showExit)buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-55);
            bar.ChangePos(Global.WindowWidthHalf,Global.WindowHeightHalf);

            // Text building world
            {
                Vector2 s=Fonts.Medium.MeasureString(strBuildingW);
                centerTS.X=Global.WindowWidthHalf-s.X/2f;
                centerTS.Y=Global.WindowHeightHalf-40;
            }
            /*if (Constants.Shadow)*/ centerTSSH=new Vector2(centerTS.X+0.5f, centerTS.Y+0.5f);
        }

        void DrawTextShadowMinMedium() {
            /*if (Constants.Shadow)*/ spriteBatch.DrawString(Fonts.Medium, strBuildingW, centerTSSH, black25);
            spriteBatch.DrawString(Fonts.Medium, strBuildingW, centerTS, Color.Black);
        }
    }
}