using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rabcrClient {
    class SettingMovemer:SettingItem{

        #region Varibles
        readonly Text TText, TextMin, TextMax;
        int Y, ButtonX;
        readonly string Text;
        int fill=255, needFill=255;
        bool oldmouseState;
        Color color=Color.White;
        public float Scale=0.5f;

        bool moving=false;

        public Texture2D line;
        public Texture2D movemer;
        const int Size=147+8;

        readonly int w;
        int w2, h2,h3;
        public delegate void ClickEventHandler();
        public event ClickEventHandler Click;
        #endregion
        private readonly int SizeMax, SizeMin;

        public SettingMovemer(string t, Texture2D newLine, Texture2D newMovemer){
            Text=t;

			line=newLine;
            movemer=newMovemer;
            Value=60;
            w=line.Width-movemer.Width;
            TText = new Text(Text, X, 0, BitmapFont.bitmapFont18);
            TextMin = new Text(Lang.Texts[355], X, 0, BitmapFont.bitmapFont18);
            TextMax = new Text(Lang.Texts[356], X, 0, BitmapFont.bitmapFont18);

            SizeMax=(int)(TextMin.MeasureX()/2f)+5;
            SizeMin=(int)(TextMax.MeasureX()/2f)+3;
        }

        public override void Update() {
            if (moving) {
                Scale=(Menu.newMouseState.X-ButtonX-8f)/(Size-16f);

                if (Scale>1) Scale=1;
                if (Scale<0) Scale=0;
                needFill=50;

                if (needFill!=fill){
                    if (fill<needFill) fill+=5;
                    else fill-=5;

                    color=new Color(fill,fill,fill);
                }

                if (Menu.newMouseState.LeftButton==ButtonState.Released) moving=false;
                if (Rabcr.ActiveWindow){
                        if (Rabcr.Game.IsActive){
                            Click.Invoke();
                        }
                    }
            }else{
                if (InMovemer()){
                    if (Menu.newMouseState.LeftButton==ButtonState.Released) {
                        if (oldmouseState){
                            moving=false;
                            oldmouseState=false;
                        }
                        needFill=230;
                    } else {
                        if (!oldmouseState){
                            if (Rabcr.Game.IsActive){
                            moving=true;
                            oldmouseState=true;
                            }
                        }
                        needFill=200;
                    }
                } else {
                    if (InLine()) needFill=240;
                    else needFill=255;
                }
            }

            if (needFill!=fill) {
                if (fill<needFill) fill+=5;
                else fill-=5;

                color=new Color(fill, fill, fill);
            }
        }

        public override void ChangePos(int x, int y) {
            Y=y;
            ButtonX=x-10;
            TText.ChangePosition(X, Y);

            w2=ButtonX + line.Width;
            h2=Y + line.Height;
            h3=Y + movemer.Height;

            TextMin.ChangePosition(ButtonX-SizeMin, Y+18);
            TextMax.ChangePosition(ButtonX+line.Width-SizeMax, Y+18);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(line, new Vector2(ButtonX, Y+6), Color.White);
            spriteBatch.Draw(movemer, new Vector2(ButtonX+(int)(Scale*(Size-16)), Y), color);

            TText.Draw(spriteBatch);

            TextMin.Draw(spriteBatch);
            TextMax.Draw(spriteBatch);
        }

        bool InLine() {
            if (Menu.mousePosX < ButtonX) return false;
            if (Menu.mousePosYCorrection < Y) return false;
            if (Menu.mousePosX > w2) return false;
            if (Menu.mousePosYCorrection > h2) return false;

            return true;
        }

        bool InMovemer() {
            if (Menu.mousePosX < ButtonX+Scale*w) return false;
            if (Menu.mousePosYCorrection < Y) return false;
            if (Menu.mousePosX > ButtonX+Scale*w + movemer.Width) return false;
            if (Menu.mousePosYCorrection > h3) return false;

            return true;
        }
    }
}