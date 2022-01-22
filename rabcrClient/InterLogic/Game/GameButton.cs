using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class GameButtonMedium {

        #region Varibles
        int fill=255;
        Color color;

        public Texture2D texture;
        public string text;

        int Xp,Yp;
        int TextPositionX, TextPositionY;
        Vector2 TexturePositon;
        Text Ttext;
        int PosToX, PosToY;
        #endregion

        public GameButtonMedium(Texture2D newtexture) {
            texture = newtexture;

            color=Color.White;
        }

        public string Text {
            set {
                text=value;
                DInt m=BitmapFont.bitmapFont18.MeasureTextSingleLine(text);
                Xp=(texture.Width-m.X)/2;
                Yp=(texture.Height-m.Y)/2+5;
                SetText();
            }
        }

        public Vector2 Position {
            set {
                TexturePositon=value;
                TextPositionX=(int)TexturePositon.X+Xp;
                TextPositionY=(int)TexturePositon.Y+Yp;
                SetText();

                PosToX=(int)TexturePositon.X + texture.Width;
                PosToY=(int)TexturePositon.Y + texture.Height;
            }
        }

        void SetText(){
            Ttext=new Text(text,TextPositionX, TextPositionY, BitmapFont.bitmapFont18);
        }

        public bool Update() {
            if (In()) {
                if (MousePos.mouseLeftDown) {
                    if (150!=fill) {
                        if (fill<150) fill+=5;
                        else fill-=5;
                        color=new Color(fill, fill, fill);
                    }
                } else {
                    if (MousePos.mouseLeftRelease) {
                        if (Rabcr.Game.IsActive){
                            return true;
                        }
                    }
                    if (200!=fill) {
                        if (fill<200) fill+=5;
                        else fill-=5;
                        color=new Color(fill, fill, fill);
                    }
                }
            } else {
                //if (255!=fill) {
                    if (fill<255){
                        fill+=5;
                        color=new Color(fill, fill, fill);
                    }
               // }
            }
            return false;
        }

        public void ButtonDraw() {
            Rabcr.spriteBatch.Draw(texture, TexturePositon, color);
            Ttext.Draw(Rabcr.spriteBatch);
        }

        //public void ButtonDrawRed() {
        //    Rabcr.spriteBatch.Draw(texture, TexturePositon, new Color(fill,fill/2,fill/2));
        //    Ttext.Draw(Rabcr.spriteBatch);
        //}

        bool In() {
            if (MousePos.mouseRealPosY < TexturePositon.Y) return false;
            if (MousePos.mouseRealPosX < TexturePositon.X) return false;
            if (MousePos.mouseRealPosX > PosToX /*TexturePositon.X + texture.Width*/) return false;
            if (MousePos.mouseRealPosY > PosToY /*TexturePositon.Y + texture.Height*/) return false;
            return true;
        }
    }

     class GameButtonSmall {

        #region Varibles
        int fill=255;
       // int needBeFill=255;
        Color color;

        public Texture2D texture;
        public string text;

        int Xp,Yp;
        int TextPositionX, TextPositionY;
        Vector2 TexturePositon;
        int PosToX, PosToY;
        Text tText;
        #endregion

        public GameButtonSmall(Texture2D newtexture) {
            texture = newtexture;

            color=Color.White;
        }

        public string Text {
            set {
                text=value;
                Xp=(texture.Width-BitmapFont.bitmapFont18.MeasureTextSingleLineX(text))/2;
                Yp=texture.Height/2-15;
                SetText();
            }
        }

        void SetText(){
            tText=new Text(text,TextPositionX, TextPositionY, BitmapFont.bitmapFont18);
        }

        public Vector2 Position {
            set {
                TexturePositon=value;
                TextPositionX=(int)TexturePositon.X+Xp;
                TextPositionY=(int)TexturePositon.Y+Yp;

                tText.ChangePosition(TextPositionX, TextPositionY);
               // SetText();
                PosToX=(int)TexturePositon.X + texture.Width;
                PosToY=(int)TexturePositon.Y + texture.Height;
            }
        }

        public bool Update() {
            if (In()) {
                if (MousePos.mouseLeftDown) {
                   // needBeFill=150;
                    if (150!=fill) {
                        if (fill<150) fill+=5;
                        else fill-=5;
                        color=new Color(fill, fill, fill);
                    }
                } else {
                    if (MousePos.mouseLeftRelease) {
                        if (Rabcr.Game.IsActive){
                            return true;
                        }
                    }
                 //   needBeFill=200;
                    if (200!=fill) {
                        if (fill<200) fill+=5;
                        else fill-=5;
                        color=new Color(fill, fill, fill);
                    }
                }
            } else {
                //needBeFill=255;
                 //if (255!=fill) {
                if (fill<255) {
                    fill+=5;
                    // else fill-=5;
                    color=new Color(fill, fill, fill);
                }
               //}
            }
            //if (needBeFill!=fill) {
            //    if (fill<needBeFill) fill+=5;
            //    else fill-=5;
            //    color=new Color(fill, fill, fill);
            //}
            return false;
        }

        public void ButtonDraw() {
            Rabcr.spriteBatch.Draw(texture, TexturePositon, color);
            tText.Draw(Rabcr.spriteBatch);
        }

        public void ButtonDrawRed() {
            int divide=fill/2;
            Rabcr.spriteBatch.Draw(texture, TexturePositon, new Color(fill, divide, divide));
            tText.Draw(Rabcr.spriteBatch);
        }

        public void ButtonDrawSelected() {
            int divide=fill/2;
            Rabcr.spriteBatch.Draw(texture, TexturePositon, new Color(divide, divide, divide));
            tText.Draw(Rabcr.spriteBatch);
        }

        bool In() {
            if (MousePos.mouseRealPosY < TexturePositon.Y) return false;
            if (MousePos.mouseRealPosX < TexturePositon.X) return false;
            if (MousePos.mouseRealPosX > /*TexturePositon.X + texture.Width*/PosToX) return false;
            if (MousePos.mouseRealPosY >/* TexturePositon.Y + texture.Height*/PosToY) return false;
            return true;
        }
    }
}