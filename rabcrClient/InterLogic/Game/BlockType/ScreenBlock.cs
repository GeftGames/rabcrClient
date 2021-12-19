using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class ScreenBlock : Block{//static =no animation (fence,label)

        Rectangle rectangle;
        public int screen;
        public Vector2 Position;
        public Texture2D Texture;

        public ScreenBlock(Texture2D texture, Vector2 position, int w, int h, ushort id) {
            Texture = texture;
            Position=position;
            Id=id;
            rectangle=new Rectangle(w* screen,0, w, h);
        }

        public int Screen {
            set {
                screen=value;
                rectangle.X=rectangle.Width * screen;
              //  rectangle = new Rectangle(rectangle.Width * screen,0, rectangle.Width, rectangle.Height);
            }
        }

        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, rectangle, ColorWhite);

        public override Block CloneDown() {
            ScreenBlock s=new ScreenBlock(Texture, Position, rectangle.Width, rectangle.Height, Id);
            s.Position.Y+=16;
            return s;
        }
    }
}
