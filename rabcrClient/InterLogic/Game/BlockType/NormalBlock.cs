using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace rabcrClient {
    public class NormalBlock:Block{

        #region Varibles
        public Vector2 Position;
        public Texture2D Texture;
        #endregion

        public NormalBlock() { }

        public NormalBlock(Texture2D texture, ushort id, Vector2 position) {
            Texture = texture;
            Id = id;
            Position = position;
        }

        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, Global.ColorWhite);

        public override Block CloneDown() => new NormalBlock{
                Texture=Texture,
                Id=Id,
                Position=new Vector2(/*n.*/Position.X, /*n.*/Position.Y+16)/*Position*/
            };
          //  n.Position.Y+=16;
           // return n;
        //}
    }
}