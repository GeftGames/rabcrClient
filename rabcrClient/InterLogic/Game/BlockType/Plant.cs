using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    public class Plant{
        public ushort Id;
        public int Grow, Height;
        public Texture2D GrowTexture;
        public bool Growing;
        public Vector2 Position;
        public /*readonly*/ int chunkId;

       public Rectangle drawRectangle;

      //  public bool IsGrow() => Grow==255;//drawRectangle.X+16==GrowTexture.Width;
      public Plant(){}

        public Plant(ushort id, byte height, byte grow, short x, Texture2D texture) {
            Id=id;
            Grow=grow;
            chunkId=x;
            Height=height;
            GrowTexture=texture;
            drawRectangle=new Rectangle((int)((Grow*GrowTexture.Width-16)/255f),0,16,16);
            Position=new Vector2(((float)x)*16,Height*16);
            Update();
            Growing=grow!=255;
        }

        public void Update() {
            if (Grow<255) Grow++;
            else Growing=false;
            drawRectangle.X=(int)(Grow*(GrowTexture.Width-16)/255f)/16*16;
        }

        public virtual void Draw() => Rabcr.spriteBatch.Draw(GrowTexture, Position, drawRectangle, Color.White);


        public FruitPlantWaving TurnToWavingPlant(bool right)=>new FruitPlantWaving(right){
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
