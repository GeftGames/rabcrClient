using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    internal class BoxBlock:Block{
        public ItemInv[] Inv;
        public Vector2 Position;
        public Texture2D Texture;

        public BoxBlock(Texture2D texture, ushort id, Vector2 position, int max) {
            Texture = texture;
            Position=position;
            Id=id;
            Inv=new ItemInv[max];
        }

        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, ColorWhite);

        public override Block CloneDown() {
            BoxBlock b=new BoxBlock(Texture, Id, Position, Inv.Length);
            b.Position.Y+=16;
            return b;
        }
    }
}