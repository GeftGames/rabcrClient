using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace rabcrClient {
    public class CactusBlock:Block{

        #region Varibles
        public Vector2 Position;
        public Texture2D Texture;
        public Cactus cactus;
        Vector2 vecOrigin;
        #endregion

        public CactusBlock() { }

        //public CactusBlock(Texture2D texture, ushort id, Vector2 position) {
        //    Texture = texture;
        //    Id = id;
        //    Position = position;
        //}

        public void SetOrigin() {
            vecOrigin=-new Vector2(Position.X-cactus.Root.X*16/*+*/-8, Position.Y-cactus.Root.Y*16/*-8*/-8/*-16*/);
        }

        public override void Draw() {
            if (cactus!=null) Rabcr.spriteBatch.Draw(Texture, Position+vecOrigin, null, Global.ColorWhite, cactus.angle, vecOrigin, 1f, SpriteEffects.None, 0);
        }

        public override Block CloneDown() => new CactusBlock{
                Texture=Texture,
                Id=Id,
                Position=new Vector2(Position.X, Position.Y+16)
            };
           // n.Position.Y+=16;
           // return n;
       // }
    }
}