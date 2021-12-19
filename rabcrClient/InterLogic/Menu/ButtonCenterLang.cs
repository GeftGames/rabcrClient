using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class ButtonCenterLang {

        #region Varibles
        int fill=255;
        int needBeFill=255;
        Color color;

        Vector2 position;
        bool oldmouseState;
        bool click;

      //  public bool center;
        public Texture2D texture;

        Text text;
        string str;
        float XP,YP;

        public string Text {
            set {
                str=value;
                /*if (position!=null)*/ReSet();
            }
        }
        #endregion

        public  Vector2 Position{
            set {
                position=value;
                ReSet();
            }
        }

        public bool Click {
            get {
                if (click) {
                    if (Rabcr.ActiveWindow) {
                        click=false;
                        return true;
                    }
                }
                return false;
            }
        }

        public ButtonCenterLang(Texture2D newtexture) {
            texture = newtexture;
            color=Color.White;
        }

        void ReSet(){
            XP=(texture.Width-BitmapFont.bitmapFont18.MeasureTextSingleLineX(str))/2f;
            YP=(texture.Height-30)/2f;
            text=new Text(str, (int)(position.X+XP), (int)(position.Y+YP), BitmapFont.bitmapFont18);
        }

        public void ButtonDrawCorectionY(SpriteBatch spriteBatch) {
            click=false;
            if (InCY()) {
                if (Menu.mouseDown && Rabcr.ActiveWindow) {
                    needBeFill=150;
                    oldmouseState=true;
                } else {
					if (oldmouseState) {
                        click=true;
                        oldmouseState=false;
                    }
                    needBeFill=200;
                }
            } else {
                oldmouseState=false;
                needBeFill=255;
            }

            if (needBeFill!=fill){
                if (fill<needBeFill) fill+=5;
                else fill-=5;
                color=new Color(fill,fill,fill);
            }

            spriteBatch.Draw(texture, position, color);

            text.Draw(spriteBatch, Color.Black);
		}

        bool InCY() {
            if (Menu.mousePosX < position.X) return false;
            if (Menu.mousePosYCorrection < position.Y) return false;
            if (Menu.mousePosX > position.X + texture.Width) return false;
            if (Menu.mousePosYCorrection > position.Y + texture.Height) return false;
            return true;
        }

    }
}