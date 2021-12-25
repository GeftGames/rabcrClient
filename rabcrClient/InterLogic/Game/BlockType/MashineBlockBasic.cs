using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class MashineBlockBasic : Block{
        public float Energy;
        public float screen;
        public float imageSpeed;
        public Vector2 Position;
        public Texture2D Texture;
      //  readonly int X, Y;
        readonly float divideC;

        public bool Working=false;
        public ItemInv[] Inv;

        public MashineBlockBasic(Texture2D texture,  ushort id, Vector2 position, int max){
            Texture = texture;
            Position=position;
            //X=(int)position.X;
            //Y=(int)position.Y;
            Energy=0;
            Id=id;
            divideC=Texture.Width/16f;
            imageSpeed=0;
            if (max!=0)Inv=new ItemInv[max];
        }

        public override void Draw() {
			screen+=imageSpeed;
			if (screen>=divideC) screen = 0;
          //  if (Working)Energy--;

            int e=(int)(Energy*18f);

			Rabcr.spriteBatch.Draw(Texture, Position, new Rectangle(16*((int)screen),0,16,16), ColorWhite);
			Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle((int)Position.X-2, (int)Position.Y-6,20,5), Color.Black);
			Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle((int)Position.X-1, (int)Position.Y-5,e,3), Color.Green);
			Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle((int)Position.X-1+e,(int)Position.Y-5,18-e,3), Color.Red);
        }

        public void AddEnergy() {
            if (Energy<1f) Energy+=0.05f;
        }

        public override Block CloneDown() {
            MashineBlockBasic mb=new(Texture,Id, Position, Inv.Length);
            mb.Position.Y+=16;
            return mb;
        }
    }
}