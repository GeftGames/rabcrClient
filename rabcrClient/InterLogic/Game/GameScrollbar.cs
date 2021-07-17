using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class GameScrollbar {

        public float scale;
        int fill=255;
        int shoundBeFill=255;
        bool oldmouseState;
        bool move=false;
        int pressHeight=0;
        public Texture2D textureTop, textureCenter, textureBottom;

        public int height;
        public int maxheight;
        Color color;

        public delegate void MoveEvent();

       // public event MoveEvent Move;

        public void Scroll(float x){
            if (height>maxheight)return;
          //  float s=scale;
            if (height<19)return;
            scale=(scale*maxheight+x)/maxheight;
            if (scale>1) scale=1;
            if (scale<0)scale=0;
           // if (scale!=s) Move.Invoke();
        }

        public GameScrollbar(Texture2D tTop, Texture2D tCenter, Texture2D tBottom) {
            textureTop = tTop;
            textureCenter=tCenter;
            textureBottom=tBottom;
            color=Color.White;
        }

        public void ButtonDraw(/*int mouseX, int mouseY, bool down,*/ int posX, int posY) {
            int mouseY=MousePos.mouseRealPosY;
            if (height>maxheight)return;
            if (height<19)return;

            int drawingAmought=(int)((float)height/maxheight*(height-19));
            int drawingPos=(int)((height-drawingAmought-8)*scale);

            if (In(/*mouseX, mouseY, */posX, posY,drawingPos,drawingAmought)){
                 if (/*down*/ MousePos.mouseLeftDown){
                       shoundBeFill=220;

                    if (!oldmouseState){
                        if (Rabcr.ActiveWindow){
                            move=true;
                            pressHeight=mouseY-drawingPos-posY;
                        }
                    }
                } else {
                    shoundBeFill=230;
                }
            } else {
                shoundBeFill=255;
            }

            if (move) {
                float msH=mouseY-posY;
             //   float s=scale;

                scale =(msH-pressHeight)/(height-drawingAmought-8);

                if (scale<0) scale=0;
                if (scale>1) scale=1;

               // if (scale!=s) Move.Invoke();

                shoundBeFill=200;
            }

            if (!/*down*/MousePos.mouseLeftDown){
                move=false;
            }
            oldmouseState=/*down*/MousePos.mouseLeftDown;

            if (shoundBeFill!=fill) {
                if (shoundBeFill<fill) {
                    fill-=5;
                } else {
                    fill+=5;
                }
                color=new Color(fill,fill,fill);
            }

            int _drawingPos=(int)((height-drawingAmought-8)*scale);

           Rabcr.spriteBatch.Draw(textureTop,new Vector2(posX,posY+_drawingPos),color);
           Rabcr.spriteBatch.Draw(textureCenter,new Rectangle(posX,posY+_drawingPos+9,20,drawingAmought-9),color);
           Rabcr.spriteBatch.Draw(textureBottom,new Vector2(posX,posY+_drawingPos+9+drawingAmought-9),color);
		}

        bool In(/*int mouseX, int mouseY, */int posX, int posY, int drawingPos, int drawingAmought) {
            if (MousePos.mouseRealPosX < posX) return false;
            if (MousePos.mouseRealPosY < posY+drawingPos) return false;
            if (MousePos.mouseRealPosX > posX+20) return false;
            if (MousePos.mouseRealPosY > posY+drawingPos+drawingAmought+9) return false;
            return true;
        }
    }
}