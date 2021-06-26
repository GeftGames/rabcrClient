using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class ImgButton {

        int fill=255;
        readonly Texture2D texture;
        Color color;

        public Vector2 Position;

        public ImgButton(Texture2D newtexture) {
            texture = newtexture;
            color=Color.White;
        }

        public bool Update() {
            if (In()) {
                if (MousePos.mouseLeftDown) {
                    if (fill!=150){
                        if (fill>150) fill-=5;
                        else fill+=5;
                        color=new Color(fill, fill, fill);
                    }
                } else {
					if (MousePos.mouseLeftRelease) {
                        if (Rabcr.ActiveWindow) {
                            if (Rabcr.Game.IsActive) {
                                return true;
                            }
                        }
                    }
                    if (fill!=200){
                        if (fill>200) fill-=5;
                        else fill+=5;
                        color=new Color(fill, fill, fill);
                    }
                }
            } else {
                if (fill<255) {
                    fill+=5;
                    color=new Color(fill, fill, fill);
                }
            }

            return false;
        }

        public void ButtonDraw() => Rabcr.spriteBatch.Draw(texture, Position, color);

        bool In() {
            if (MousePos.mouseRealPosX < Position.X) return false;
            if (MousePos.mouseRealPosY < Position.Y) return false;
            if (MousePos.mouseRealPosX > Position.X + 32) return false;
            if (MousePos.mouseRealPosY > Position.Y + 32) return false;
            return true;
        }
    }
}