using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class AnimatedBlockOffset :Block{
        public float screen;
        public float imageSpeed = 0;
        readonly int height, width;
        readonly float divideC;
        readonly int ox,oy;
        public Vector2 Position;
        public Texture2D Texture;

        public AnimatedBlockOffset(Texture2D texture, Vector2 position, int w, int h, ushort id, int ox, int oy) /*:base (texture,id,position)*/{
            Texture = texture;
            Position=position;
            width = w;
            height = h;
            Id=id;
            divideC=(Texture.Width-w)/(float)width;

            this.ox=ox;
            this.oy=oy;
        }

        public override void Draw() {
			screen+=imageSpeed;
			if (screen>=divideC) screen = 0;

			Rabcr.spriteBatch.Draw(Texture, new Vector2(Position.X+ox,Position.Y+oy), new Rectangle(width*(int)screen,0,width,height), Global.ColorWhite);
        }

        public override Block CloneDown() => new AnimatedBlockOffset(Texture, new Vector2(Position.X, Position.Y+16), width, height, Id, ox, oy);
          //  a.Position.Y+=16;
        ///    return a;
        //}
    }
}