using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient {
    class Scrollbar {

        public float scale;
        public EventHandler MoveScollBar;
        public int PositionX, PositionY;
        public int height;
        public int maxheight;
        public Texture2D
            textureTop,
            textureCenter,
            textureBottom;
        //public float mightbeScale;

        int fill=255;
        int shoundBeFill=255;
        bool oldmouseState;
        readonly EventArgs ea;
        bool move=false;
        int pressHeight=0;

        Color color=Color.White;

        int drawingAmought;
        int drawingPos;


        float bscale;
        float drawscale;

        public void Scroll(float x) {
            if (height>maxheight)return;
            if (height<19)return;
            scale=(scale*maxheight+x)/maxheight;
            drawscale=scale;
            if (scale>1) {scale=1+(scale-1)/2f; drawscale=1; }
            else if (scale<0) {scale/=2f; drawscale=0;}

        }

        public Scrollbar(Texture2D tTop, Texture2D tCenter, Texture2D tBottom) {
            textureTop = tTop;
            textureCenter=tCenter;
            textureBottom=tBottom;
            ea=new EventArgs();
        }

        public void ButtonDraw(SpriteBatch spriteBatch, float f) {
            if (bscale!=scale) {
                bscale=scale;
                MoveScollBar.Invoke(this,ea);
            }
            if (height>maxheight)return;
            if (height<19)return;

            drawingAmought=(int)((float)height/maxheight*(height-19));
            drawingPos=(int)((height-drawingAmought-8)*/*scale*/drawscale);

            if (In()) {
                if (Menu.mouseDown) {
                    shoundBeFill=220;

                    if (!oldmouseState && Rabcr.ActiveWindow){
                        move=true;
                        pressHeight=Menu.mousePosY-drawingPos-PositionY;
                    }
                }else{
                    shoundBeFill=230;
                }

            }else{
                shoundBeFill=255;
            }

            if (move){
                float msH=Menu.mousePosY-PositionY;

               drawscale= scale =(msH-pressHeight)/(height-drawingAmought-8);

                if (scale<0) drawscale=scale=0;
                if (scale>1) drawscale=scale=1;

                shoundBeFill=200;
            }

            if (!Menu.mouseDown){
                move=false;
            }
            oldmouseState=Menu.mouseDown;


            if (shoundBeFill!=fill){
                if (shoundBeFill<fill){
                    fill-=5;
                } else {
                    fill+=5;
                }
                color=new Color(fill,fill,fill);
            }

            int _drawingPos=(int)((height-drawingAmought-8)*/*scale*/drawscale);

            Color c=color*f;
            spriteBatch.Draw(textureTop,new Vector2(PositionX,PositionY+_drawingPos),c);
            spriteBatch.Draw(textureCenter,new Rectangle(PositionX,PositionY+_drawingPos+9,20,drawingAmought-9),c);
            spriteBatch.Draw(textureBottom,new Vector2(PositionX,PositionY+_drawingPos+9+drawingAmought-9),c);
	    }

        public void ButtonDraw(SpriteBatch spriteBatch, float f, int mouseY) {
            if (height>maxheight)return;
            if (height<19)return;

            drawingAmought=(int)((float)height/maxheight*(height-19));
            drawingPos=(int)((height-drawingAmought-8)*/*scale*/drawscale);

            if (In(mouseY)){
                if (Menu.mouseDown){
                    shoundBeFill=220;

                    if (!oldmouseState && Rabcr.ActiveWindow){
                        move=true;
                        pressHeight=Menu.mousePosY-drawingPos-PositionY;
                    }
                }else{
                    shoundBeFill=230;
                }

            }else{
                shoundBeFill=255;
            }

            if (move){
                float msH=Menu.mousePosY-PositionY;
               drawscale= scale =(msH-pressHeight)/(height-drawingAmought-8);

                if (scale<0) drawscale=scale=0;
                if (scale>1) drawscale=scale=1;

                shoundBeFill=200;
            }

            if (!Menu.mouseDown){
                move=false;
            }
            oldmouseState=Menu.mouseDown;


            if (shoundBeFill!=fill){
                if (shoundBeFill<fill){
                    fill-=5;
                }else{
                    fill+=5;
                }
                color=new Color(fill,fill,fill);
            }

            int _drawingPos=(int)((height-drawingAmought-8)*/*scale*/drawscale);

            Color c=color*f;
            spriteBatch.Draw(textureTop,new Vector2(PositionX,PositionY+_drawingPos),c);
            spriteBatch.Draw(textureCenter,new Rectangle(PositionX,PositionY+_drawingPos+9,20,drawingAmought-9),c);
            spriteBatch.Draw(textureBottom,new Vector2(PositionX,PositionY+_drawingPos+9+drawingAmought-9),c);
		}

        bool In() {
            if (Menu.mousePosX < PositionX) return false;
            if (Menu.mousePosY < PositionY+drawingPos) return false;
            if (Menu.mousePosX > PositionX+20) return false;
            if (Menu.mousePosY > PositionY+drawingPos+drawingAmought+9) return false;
            return true;
        }

        bool In(int mouseY) {
            if (Menu.mousePosX < PositionX) return false;
            if (mouseY < PositionY+drawingPos) return false;
            if (Menu.mousePosX > PositionX+20) return false;
            if (mouseY > PositionY+drawingPos+drawingAmought+9) return false;
            return true;
        }
    }
}