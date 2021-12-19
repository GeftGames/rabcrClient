using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient {
    class Button {

        #region Varibles
        const int XP=15;

        readonly int YP;
        readonly Color blacksh;
        readonly string str;

        int fill=255;
        int needBeFill=255;
        Color color;

        bool oldmouseState;
        public Texture2D texture;
        Text text;

        int posXWithW, posYWithH;

        Vector2 position;
        bool needToSet;

        public EventHandler Click;
        #endregion

        public Vector2 Position {
            set {
                position=value;
                int x=(int)position.X,
                    y=(int)position.Y;

                posXWithW=x+texture.Width;
                posYWithH=y+texture.Height;

                if (needToSet) {
                    text=new Text(str, x+XP, y+YP, BitmapFont.bitmapFont18);
                    needToSet=false;
                } else text.ChangePosition(x+XP, y+YP);
            }
        }

        public Button(Texture2D newtexture, string text) {
            texture = newtexture;
            color=Color.White;
            YP=(texture.Height-/*30*/26)/2;
            blacksh=Color.Black*0.025f;

            str=text;
            needToSet=true;
        }

        public void Update(){
             if (In()) {
                if (Menu.mouseDown && Rabcr.ActiveWindow) {
                    needBeFill=150;
                    oldmouseState=true;
                } else {
					if (oldmouseState) {
                        if (Rabcr.Game.IsActive) {
                            if (Click==null)throw new Exception("Programmer forget to register click event");
                            Click.Invoke(this,null);
                        }
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
                color=new Color(fill,fill,fill);
            }
        }

        #region ButtonDraw
        public void ButtonDraw(SpriteBatch spriteBatch, float f) {
			if (needBeFill!=150) {
                if (Constants.AnimationsControls) DrawShadow(spriteBatch, blacksh*f);
            }
            spriteBatch.Draw(texture, position, color*f);

            text.Draw(spriteBatch, Color.Black*f);
		}
        #endregion

        void DrawShadow(SpriteBatch spriteBatch, Color c) {
            Color ca=c*((fill-150)/105f);
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
            if (Menu.mousePosX > posXWithW) return false;
            if (Menu.mousePosY > posYWithH) return false;
            return true;
        }
    }
}