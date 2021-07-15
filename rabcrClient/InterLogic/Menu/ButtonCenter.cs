using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class ButtonCenter {

        #region Varibles
        int fill=255;
        int needBeFill=255;
        Color color;

        bool oldmouseState;
        bool click;
        readonly Color blacksh;
        public bool center;
        public Texture2D texture;

        Text text;
        string str;
        float XP,YP;
        Vector2 position;
        int w2,h2;

        public string Text {
            set {
                str=value;
                if (position!=null)ReSet();
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
                    if (Rabcr.Game.IsActive) {
                        click=false;
                        return true;
                    }
                }
                return false;
            }
        }

        public ButtonCenter(Texture2D newtexture) {
            texture = newtexture;
            color=Color.White;
            blacksh=Color.Black*0.015f;
        }

        void ReSet(){
            XP=(texture.Width-BitmapFont.bitmapFont18.MeasureTextSingleLineX(str))/2f;
            YP=(texture.Height-/*30*/24)/2f;
            text=new Text(str, (int)(position.X+XP), (int)(position.Y+YP), BitmapFont.bitmapFont18);

            w2=(int)position.X + texture.Width;
            h2=(int)position.Y + texture.Height;
        }

        public void ButtonDrawCorectionY(SpriteBatch spriteBatch, float f) {
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
			if (needBeFill!=150){
                if (Constants.AnimationsControls) DrawShadow(spriteBatch); 
            }
            spriteBatch.Draw(texture, position, color*f);

            text.Draw(spriteBatch, Color.Black*f);
		}

        public void ButtonDraw(SpriteBatch spriteBatch, float f) {
            click=false;
            if (In()) {
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
			if (needBeFill!=150){
                if (Constants.AnimationsControls) DrawShadow(spriteBatch); 
            }
            spriteBatch.Draw(texture, position, color*f);

            text.Draw(spriteBatch, Color.Black*f);
		}

        public void ButtonDraw(SpriteBatch spriteBatch) {
            click=false;
            if (In()) {
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
            if (needBeFill!=fill) {
                if (fill<needBeFill) fill+=5;
                else fill-=5;

                color=new Color(fill, fill, fill);
            }
            if (needBeFill!=150){
                if (Constants.AnimationsControls) DrawShadow(spriteBatch);
            }
            spriteBatch.Draw(texture, position, color);

            text.Draw(spriteBatch,color);
        }

        public void ButtonDraw(SpriteBatch spriteBatch, Color color) {
            click=false;
            if (In()) {
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
            if (needBeFill!=fill) {
                if (fill<needBeFill) fill+=5;
                else fill-=5;

                color=new Color(fill, fill, fill);
            }

            if (needBeFill!=150){
                if (Constants.AnimationsControls) DrawShadow(spriteBatch);
            }
            spriteBatch.Draw(texture, position, new Color(color.R*(fill/255f), color.G*(fill/255f), color.B*(fill/255f)));

            text.Draw(spriteBatch,Color.Black);
        }

        void DrawShadow(SpriteBatch spriteBatch) {
            Color ca=blacksh*((fill-150)/105f);
            Vector2 vec=new Vector2(position.X,position.Y);

            for (float x=0.5f; x<3; x+=0.5f) {
                vec.X+=0.5f;
                vec.Y=position.Y;

                for (float y=0.5f; y<3; y+=0.5f) {
                    vec.Y+=0.5f;
                    spriteBatch.Draw(texture, vec, ca);
                }
            }
        }

        bool In() {
            if (Menu.mousePosX < position.X) return false;
            if (Menu.mousePosY < position.Y) return false;
            if (Menu.mousePosX > /*position.X + texture.Width*/w2) return false;
            if (Menu.mousePosY > /*position.Y + texture.Height*/h2) return false;
            return true;
        }

        bool InCY() {
            if (Menu.mousePosX < position.X) return false;
            if (Menu.mousePosYCorrection < position.Y) return false;
            if (Menu.mousePosX > /*position.X + texture.Width*/w2) return false;
            if (Menu.mousePosYCorrection > /*position.Y + texture.Height*/h2) return false;
            return true;
        }
    }
}