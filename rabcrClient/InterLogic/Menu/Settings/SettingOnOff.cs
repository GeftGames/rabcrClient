using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class SettingOnOff:SettingItem{

        #region Varibles
        Text TText;
        readonly string Text;
        Color color=Color.White;
        int fill=255, needFill=255;
        public bool ON;
        readonly Texture2D texture;
        bool oldmouseState=false;
        Vector2 Position;
        Text text;

        public delegate void ClickEventHandler();
        public event ClickEventHandler Click;
        #endregion

        public SettingOnOff(Texture2D tex, string t, bool active){
            Text=t;
            Value=60;
            texture=tex;
            ON=active;
        }

        public override void Update() {
            if (In()) {
               if (Menu.mouseDown) {
                    needFill=200;
                    oldmouseState=true;
                } else {
					if (oldmouseState) {
                        if (Rabcr.Game.IsActive){
                            oldmouseState=false;
                            ON=!ON;
                            ChangePos((int)Position.X,(int)Position.Y);

                            if (Rabcr.ActiveWindow){
                                if (Rabcr.Game.IsActive){
                                    Click.Invoke();
                                }
                            }
                        }
                    }
                    needFill=220;
                }
            } else {
                needFill=255;
            }

            if (needFill!=fill){
                if (fill<needFill) fill+=5;
                else fill-=5;

                color=new Color(fill,fill,fill);
            }
        }

        public override void ChangePos(int x, int y) {
            Position.X=x;
            Position.Y=y;

            string buttonText;
            if (ON) buttonText=Lang.Texts[86];
            else buttonText=Lang.Texts[87];

            DInt m=BitmapFont.bitmapFont18.MeasureTextSingleLineWithPresision(buttonText);
            text=new Text(buttonText,x+(texture.Width-m.X)/2,y+(texture.Height-m.Y)/2,BitmapFont.bitmapFont18);

            TText = new Text(Text, X, y, BitmapFont.bitmapFont18);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, Position, color);

            text.Draw(spriteBatch);

            TText.Draw(spriteBatch);
        }

        bool In() {
            if (Menu.mousePosX < Position.X) return false;
            if (Menu.mousePosYCorrection < Position.Y) return false;
            if (Menu.mousePosX > Position.X + texture.Width) return false;
            if (Menu.mousePosYCorrection > Position.Y + texture.Height) return false;

            return true;
        }
    }
}
