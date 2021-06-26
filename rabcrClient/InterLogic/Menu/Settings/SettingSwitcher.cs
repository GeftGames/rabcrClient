using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient {
    class SettingSwitcher:SettingItem{

        #region Varibles
        public string txt;
        readonly Text TText;
        public string[] list;
        public int selected;
        public Texture2D texture;
        int fill=255, needFill=255;
        bool oldmouseState;
        Color color=Color.White;

        Vector2 Position;
        string buttonText;
        Text text;
        int w2, h2;
        int textSizeX, textSizeY;

        public delegate void ClickEventHandler();
        public event ClickEventHandler Click;

        public int Selected {
            set {
                buttonText=list[selected=value];
                DInt s=BitmapFont.bitmapFont18.MeasureTextSingleLine(buttonText);
                textSizeX=(texture.Width-s.X)/2;
                textSizeY=(texture.Height-s.Y)/2;
                text=new Text(buttonText,(int)Position.X+textSizeX, (int)Position.Y+textSizeY, BitmapFont.bitmapFont18);
            }
        }

        public string Text{
            set {
                txt=value;
                DInt s=BitmapFont.bitmapFont18.MeasureTextSingleLine(buttonText);
                textSizeX=(texture.Width-s.X)/2;
                textSizeY=(texture.Height-s.Y)/2;

                text=new Text(buttonText, (int)Position.X+textSizeX, (int)Position.Y+textSizeX, BitmapFont.bitmapFont18);
            }
        }
        #endregion

        public SettingSwitcher(Texture2D tex, string t, string[] sw, int slct) {
            txt=t;
            list=sw;

            Value=60;
            texture=tex;
            Selected=slct;

            TText=new Text(txt, 0, 0, BitmapFont.bitmapFont18);

            DInt s=BitmapFont.bitmapFont18.MeasureTextSingleLineWithPresision(buttonText);
            textSizeX=(texture.Width-s.X)/2;
            textSizeY=(texture.Height-s.Y)/2;

            text=new Text(buttonText, textSizeX, textSizeY, BitmapFont.bitmapFont18);
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

                            if (Rabcr.ActiveWindow){
                                if (Rabcr.Game.IsActive){
                                    Click.Invoke();
                                }
                            }
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

            text.ChangePosition(x+textSizeX, y+textSizeY);

            w2=x + texture.Width;
            h2=y + texture.Height;
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