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

        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, ColorWhite);

        public override Block CloneDown() {
            NormalBlock n = new NormalBlock {
                Texture=Texture,
                Id=Id,
                Position=Position
            };
            n.Position.Y+=16;
            return n;
        }
    }
}