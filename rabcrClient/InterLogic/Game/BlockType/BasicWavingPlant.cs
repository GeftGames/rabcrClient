using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace rabcrClient {
    public class BasicWavingPlant: Block{

        #region Varibles
        public Vector2 Position;
        public Texture2D Texture;
        
        readonly Vector2 vecOrigin;
        public int ticks;
        public float offsed;
        #endregion

        public BasicWavingPlant(Texture2D texture, ushort id, Vector2 position, bool right) {
            Texture = texture;
            Id = id;
            Position = position;

            vecOrigin=new Vector2(8, 16);
            if (!right)offsed=FastMath.PI;
            ticks=0;
        }

        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, Position+vecOrigin, null, ColorWhite, (float)System.Math.Sin(ticks/10f+offsed)*0.25f*(1-ticks/100f)/*(ticks/100f)*/, vecOrigin, 1f, SpriteEffects.None, 0); 

        public NormalBlock TurnOff() => new NormalBlock { 
            Texture=Texture,
            Position=Position,
            Id=Id 
        };

        public override Block CloneDown() => null;
    }
}