using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class ShelfBlock:Block{
        public ItemInv[] Inv;
        public Texture2D SmalItemTexture;
        public bool IsSmallItem;
        public Color ColorItem;
        public Vector2 Position;
        public Texture2D Texture;
        readonly Rectangle SmalItemRectangle;

        public ShelfBlock(Texture2D texture, ushort id, Vector2 position, int max) {
            Texture = texture;
            Position=position;
            Id=id;
            Inv=new ItemInv[max];
            ColorItem=Global.ColorWhite;
            SmalItemRectangle=new Rectangle((int)position.X+2, (int)position.Y+2, 12, 12);
        }

        public override void Draw() {
			Rabcr.spriteBatch.Draw(Texture, Position, Global.ColorWhite);

            if (IsSmallItem) Rabcr.spriteBatch.Draw(SmalItemTexture, SmalItemRectangle, ColorItem);
        }

        public override Block CloneDown() => new ShelfBlock(Texture, Id, new Vector2(Position.X, Position.Y+16), Inv.Length);
          //  s.Position.Y+=16;
          //  return s;
       // }
    }
}