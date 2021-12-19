using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class AnimatedBlock:Block {
        public float screen;
        public float imageSpeed = 0;
        readonly int height, width;
        readonly float divideC;
        public Vector2 Position;
        public Texture2D Texture;
        Rectangle rec;

        public AnimatedBlock(Texture2D texture, Vector2 position, int w, int h, ushort id) {
            Texture = texture;
            Position=position;
            width = w;
            height = h;
            Id=id;
            divideC=(Texture.Width-w)/(float)width;
            rec=new Rectangle(width*(int)screen, 0, width, height);
        }

        private AnimatedBlock(){ }

        public override void Draw() {
			screen+=imageSpeed;
			if (screen>=divideC) screen = 0;
            rec.X=width*(int)screen;

			Rabcr.spriteBatch.Draw(Texture, Position, rec/*new Rectangle(width*(int)screen, 0, width, height)*/, ColorWhite);
        }

        public override Block CloneDown() {
            AnimatedBlock a = new AnimatedBlock(Texture, Position, width, height, Id);
           /* AnimatedBlock a = new AnimatedBlock{
                Texture=Texture,
                Id=Id,
                height=height,
                width=width,
                divideC=divideC,
                Position=Position,
                rec=rec,
            };*/
            Position.Y+=16;
            return a;
        }
    }
}