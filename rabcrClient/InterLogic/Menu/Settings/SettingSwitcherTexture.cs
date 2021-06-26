using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient {
    class SettingSwitcherTexture:SettingItem{

        #region Varibles
        public string txt;
        Rectangle rec;
        readonly Text TText;
        public Texture2D[] list;
        public int selected;
        public Texture2D texture;
        int fill=255, needFill=255;
        bool oldmouseState;
        Color color=Color.White;

        Vector2 Position;
        Texture2D buttonTex;
        int w2, h2;

        public delegate void ClickEventHandler();
        public event ClickEventHandler Click;

        public int Selected {
            set {
                buttonTex=list[selected=value];
                int w=(int)(list[selected].Width*(32f/list[selected].Height));
                rec=new Rectangle((int)Position.X+texture.Width/2-w/2,(int)Position.Y,w,32);
            }
        }
        #endregion

        public SettingSwitcherTexture(Texture2D tex, string t, Texture2D[] sw, int slct) {
            txt=t;
            list=sw;

            Value=60;
            texture=tex;
            Selected=slct;

            TText=new Text(txt, 0, 0, BitmapFont.bitmapFont18);

            int w=(int)(buttonTex.Width*(32f/buttonTex.Height));
            rec=new Rectangle((int)Position.X+texture.Width/2-w/2,(int)Position.Y,w,32);
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
                            selected++;
                            if (selected==list.Length)selected=0;
                            Selected=selected;
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

        public override void ChangePos(int x, int y) {
            Position.X=x;
            Position.Y=y;

            TText.ChangePosition(X,y);

            w2=x + texture.Width;
            h2=y + texture.Height;

            int w=(int)(buttonTex.Width*(32f/buttonTex.Height));
            rec=new Rectangle((int)Position.X+texture.Width/2-w/2, (int)Position.Y, w, 32);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, Position, color);
            spriteBatch.Draw(buttonTex, rec, color);
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