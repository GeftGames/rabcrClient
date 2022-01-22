using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    #if MULTIPLAYER
    class MFish :MMob{
     //   public bool IsLeft;
        public float speed;
        bool Frame;
        readonly Texture2D Texture1, Texture2;

        public MFish(/*ushort id, */byte height, int x, bool dir, Texture2D fishTexture1, Texture2D fishTexture2) {
          //  Height=height;
            Position=new Vector2(x*16+2,/*Height*/height*16+3);
            Texture1 = fishTexture1;
            Texture2 = fishTexture2;
            Dir=dir;
           // random=rnd;
            //Lives=lives;
            Frame=false;
            speed = 1;
            Id=(ushort)BlockId.Fish;
        }

        public MFish(/*ushort id,*/ int height, int x, bool dir, Texture2D fishTexture1, Texture2D fishTexture2) {
          //  Height=height;
            Position=new Vector2(x*16+2,/*Height*/height*16+3);
            Texture1 = fishTexture1;
            Texture2 = fishTexture2;
            Dir=dir;
           // random=rnd;
            //Lives=lives;
            Frame=false;
            speed = 1;
          Id=(ushort)BlockId.Fish;
        }

        public unsafe override byte[] Save(){
            ushort id=Id;
			byte* mbytes=(byte*)&id;

            return new byte[]{
                mbytes[1],
                mbytes[0],
                Height,
                Dir ? (byte)1 : (byte)0
            };
        }

        public override void Update() {
            if (Dir) Position.X-=speed;
            else Position.X+=speed;


            if (FastRandom.Bool()) speed += .01f; else speed -= .01f;
            if (speed < .01) speed += .01f;
            if (speed >  2) speed -= .01f;
        }

        public override void Draw() {
            if (FastRandom.Bool_10Percent()){
                if (FastRandom.Bool_12_5Percent()) Frame=!Frame;
                if (FastRandom.Bool_5Percent()) Dir=!Dir;
            }

            if (Dir){
                if (Frame) Rabcr.spriteBatch.Draw(Texture1, Position, Color.White);
                else Rabcr.spriteBatch.Draw(Texture2, Position, Color.White);
            } else {
                if (Frame) Rabcr.spriteBatch.Draw(Texture1, Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                else Rabcr.spriteBatch.Draw(Texture2, Position, null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
            }

        }
    }
    #endif
}