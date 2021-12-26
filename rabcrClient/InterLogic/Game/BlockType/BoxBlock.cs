using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    public class BoxBlock:Block {
        public ItemInv[] Inv;
        public Vector2 Position;
        public Texture2D Texture;

        public BoxBlock(Texture2D texture, ushort id, Vector2 position, int max) {
            Texture = texture;
            Position=position;
            Id=id;
            Inv=new ItemInv[max];
        }

        private BoxBlock(){ }

        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, Global.ColorWhite);

        public override Block CloneDown() => new BoxBlock{
                Texture=Texture,
                Position=new Vector2(Position.X,Position.Y+16),
                Id=Id,
            };//Texture, Id, Position, Inv.Length);
         //   b.Position.Y+=16;
           // return b;
       // }
    }
}