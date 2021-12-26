using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace rabcrClient {
    public class WoodBlock:Block{

        #region Varibles
        public Vector2 Position;
        public Texture2D Texture;
        public Tree tree;
        #endregion

        public WoodBlock() { }

        public WoodBlock(Texture2D texture, ushort id, Vector2 position) {
            Texture = texture;
            Id = id;
            Position = position;
        }

        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, Global.ColorWhite);

        public override Block CloneDown() => new WoodBlock{
                Texture=Texture,
                Id=Id,
                Position=new Vector2(Position.X,Position.Y+16)/*Position*/
            };
          //  n.Position.Y+=16;
          //  return n;
      //  }
    }
}