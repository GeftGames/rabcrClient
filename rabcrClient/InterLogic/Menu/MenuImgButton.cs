//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
////using Microsoft.Xna.Framework.Input;

//namespace rabcrClient {
//    class MenuImgButton {

//        public Vector2 Position;
//        int fill=255;
//        int needFill=255;
//        bool oldmouseState;
//        public Texture2D texture;
//        bool click;
//        Color color=Color.White;
//       // public int mouseYCorrection;

//        public bool Click {
//            get {
//                if (click) {
//                    if (Rabcr.ActiveWindow) {
//                        click=false;
//                        return true;
//                    }
//                }
//                return false;
//            }
//        }

//        public MenuImgButton(Texture2D newtexture) {
//            texture = newtexture;
//        }

//        public void ButtonDraw(SpriteBatch spriteBatch/*, int mouseX, int mouseY, int positionX, int positionY, bool mouseLeft*/) {
//         //   MouseState mouseState = Mouse.GetState();
//            click=false;
//            if (In(/*mouseX, mouseY, positionX, positionY*/)) {
//                if (Menu.mouseDown) {
//                    needFill=150;
//                    oldmouseState=true;
//                } else {
//					if (oldmouseState) {
//                        if (Rabcr.ActiveWindow) {
//                            click=true;
//                        }
//                        oldmouseState=false;
//                    }
//                    needFill=200;
//                }
//            } else {
//                needFill=255;
//                oldmouseState=false;
//                click=false;
//            }

//            if (fill!=needFill){
//                if (fill>needFill)fill-=5;
//                else fill++;
//                color=new Color(fill,fill,fill);
//            }

//            spriteBatch.Draw(texture, Position, color);
//		}

//        bool In(/*int mouseX, int mouseY, int positionX, int positionY*/) {
//            if (Menu.mousePosX < Position.X) return false;
//            if (Menu.mousePosYCorrection/*-mouseYCorrection*/ < Position.Y) return false;
//            if (Menu.mousePosX > Position.X + 32) return false;
//            if (Menu.mousePosYCorrection/*-mouseYCorrection*/ > Position.Y + 32) return false;

//            return true;
//        }
//    }
//}