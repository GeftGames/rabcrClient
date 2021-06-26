using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class SettingButton:SettingItem{

        #region Varibles
        readonly string Text;
        readonly Text TText;

        public Texture2D texture;
        int fill, needFill;
        bool oldmouseState;
        Color color;

        Vector2 Position;
        Text text;
        int w2,h2;

        public delegate void ClickEventHandler();
        public event ClickEventHandler Click;
        #endregion

        public SettingButton(Texture2D tex, string t) {
            Text=t;
            fill=255;
            needFill=255;
            Value=60;
            texture=tex;

            color=Color.White;

            TText=new Text(Text, 0, 0,BitmapFont.bitmapFont18);

            ChangePos(0,0);
        }

        public override void ChangePos(int x, int y) {
            Position.X=x;
            Position.Y=y;

            DInt m=BitmapFont.bitmapFont18.MeasureTextSingleLine(Lang.Texts[24]);
            text=new Text(Lang.Texts[24],x+(texture.Width-m.X)/2,y+(texture.Height-m.Y)/2,BitmapFont.bitmapFont18);

            TText.ChangePosition(/*x*/X,y);

            w2=(int)Position.X + texture.Width;
            h2= (int)Position.Y + texture.Height;
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
                            Click.Invoke();
                        }
                    }
                    needFill=220;
                }
            } else needFill=255;

            if (needFill!=fill) {
                if (fill<needFill) fill+=5;
                else fill-=5;

                color=new Color(fill,fill,fill);
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, Position, color);
            text.Draw(spriteBatch);
            TText.Draw(spriteBatch);
        }

        bool In() {
            if (Menu.mousePosX < Position.X) return false;
            if (Menu.mousePosYCorrection < Position.Y) return false;
            if (Menu.mousePosX > w2) return false;
            if (Menu.mousePosYCorrection > h2) return false;

            return true;
        }
    }
}
