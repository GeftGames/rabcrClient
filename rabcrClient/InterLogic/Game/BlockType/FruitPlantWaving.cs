using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    public class FruitPlantWaving:Plant{
        readonly Vector2 vecOrigin;
        public int ticks;
        public float offsed;

        public FruitPlantWaving(bool right) {
            vecOrigin=new Vector2(8, 16);
            if (!right)offsed=FastMath.PI;
            ticks=0;
        }

        public override void Draw() => Rabcr.spriteBatch.Draw(GrowTexture, Position+vecOrigin, drawRectangle, Color.White, (float)System.Math.Sin(ticks/10f+offsed)*0.25f*(1-ticks/100f), vecOrigin, 1f, SpriteEffects.None, 0);

        public Plant TurnOff() => new Plant {
            GrowTexture=GrowTexture,
            Position=Position,
            Id=Id,
            Grow=Grow,
            Growing=Growing,
            Height=Height,
            chunkId=chunkId,
            drawRectangle=drawRectangle,
        };
    }
}
