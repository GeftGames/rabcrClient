using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class AnimatedBlock :Block{
        public float screen;
        public float imageSpeed = 0;
        readonly int height, width;
        readonly float divideC;
        public Vector2 Position;
        public Texture2D Texture;
 

        public AnimatedBlock(Texture2D texture, Vector2 position, int w, int h, ushort id) {
            Texture = texture;
            Position=position;
            width = w;
            height = h;
            Id=id;
            divideC=(Texture.Width-w)/(float)width;
        }

        public override void Draw() {
			screen+=imageSpeed;
			if (screen>=divideC) screen = 0;

			Rabcr.spriteBatch.Draw(Texture, Position, new Rectangle(width*(int)screen,0,width,height), ColorWhite);
        }

        public override Block CloneDown() {
            AnimatedBlock a = new AnimatedBlock(Texture, Position, width, height, Id);
            Position.Y+=16;
            return a;
        }
    }
}