using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class Rabbit:Mob {

        public byte Frame;
        public bool needToChangeChunk;
        public bool move;
        public short lastChunkID;
        public byte moveCount;
        public bool switchtoWalk;
        public MoveType moveType;

        readonly Texture2D TextureWalk, TextureEat, TextureJump;
        public Texture2D thisTexture;

        public Rabbit(/*ushort id,*/ byte height, /*byte lives,*/ int x, bool dir, Texture2D textureWalk, Texture2D textureEat,Texture2D textureJump) {
          //  Height=height;
         //   Position.Y=height*16;
            Position=new Vector2(x*16,height*16);
            TextureWalk = textureWalk;
            TextureEat = textureEat;
            TextureJump = textureJump;
         //   Lives=lives;
            Frame=0;
            Dir=dir;
            Id=(ushort)BlockId.Rabbit;
            thisTexture=TextureEat;
        }

        public Rabbit(/*ushort id,*/ int height, /*byte lives,*/ int x, bool dir, Texture2D textureWalk, Texture2D textureEat,Texture2D textureJump) {
           // Height=height;
            Position.Y=height*16;
            Position=new Vector2(x*16,Height*16);
            TextureWalk = textureWalk;
            TextureEat = textureEat;
            TextureJump = textureJump;
         //   Lives=lives;
            Frame=0;
            Dir=dir;
             Id=(ushort)BlockId.Rabbit;
            thisTexture=TextureEat;
        }

        public unsafe override byte[] Save() { 
            ushort id=Id;
			byte* mbytes=(byte*)&id ;
 
            return new byte[]{ mbytes[1], mbytes[0], Height, Dir ? (byte)1 : (byte)0 };
        }

        public override void Draw() {
            Frame+=/*4*/10;
            if (move) {
                switch (moveType){
                    case MoveType.Walk:
                        if (Dir) Position.X+=0.25f;
                        else Position.X-=0.25f;

                        moveCount--;
                        if (moveCount==0) {
                            move=false;
                            needToChangeChunk=true;
                            thisTexture=TextureEat;
                        }

                        if (Frame>=thisTexture.Width) {
                            Frame=0;
                        }
                        break;

                    case MoveType.Fall:
                        if (Dir){ Position.X+=0.25f; Position.Y+=0.25f; }
                        else {Position.X-=0.25f; Position.Y+=0.25f; }

                        moveCount--;
                        if (moveCount==0) {
                            move=false;
                            needToChangeChunk=true;
                            thisTexture=TextureEat;
                        }

                        if (Frame>=thisTexture.Width) {
                            Frame=0;
                        }
                        break;

                    case MoveType.Jump:
                        if (Dir) {Position.X+=0.25f; Position.Y-=0.25f; }
                        else {Position.X-=0.25f; Position.Y-=0.25f; }

                        moveCount--;
                        if (moveCount==0) {
                            move=false;
                            needToChangeChunk=true;
                            thisTexture=TextureEat;
                        }

                        if (Frame>=thisTexture.Width) {
                            Frame=0;
                        }
                        break;

                }
            } else {
                if (Frame>=thisTexture.Width){
                    Frame=0;

                    if (switchtoWalk){
                        move=true;
                        thisTexture=TextureJump;
                        switchtoWalk=false;/*System.Console.WriteLine("switch walk");*/
                    } else {
                      //  System.Console.WriteLine(thisTexture.Name);
                       if (Rabcr.random.Bool()){
                        if (thisTexture==TextureEat) {
                            if (Rabcr.random.Bool()){thisTexture=TextureWalk; /*System.Console.WriteLine("switch tex jump");*/}
                        }else{ //System.Console.WriteLine("?");
                             thisTexture=TextureEat;//System.Console.WriteLine("switch tex eat");
                        }
                            if (Rabcr.random.Bool()){Dir=!Dir;/*System.Console.WriteLine("switch dir");*/ }
                        }


                    }
                }
            }

            if (Dir) Rabcr.spriteBatch.Draw(thisTexture, Position,new Rectangle((int)(Frame/16f)*16,0,16,16), Color.White);
            else Rabcr.spriteBatch.Draw(thisTexture, Position, new Rectangle((int)(Frame/16f)*16,0,16,16), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
        }
    }
}