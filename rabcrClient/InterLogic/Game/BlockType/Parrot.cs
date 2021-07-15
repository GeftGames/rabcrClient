using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient {
    class Parrot:Mob {
        
        #region Varibles
        const float BirdSpeed=1f;

        public bool Flying;
        public int Frame;
        public Vector2 PositionFlyTo;

        public delegate bool EventStopFly();
        public event EventStopFly StopFlying;

        readonly Texture2D TextureStill, TextureFlying;
        Vector2 SpeedVector;
        #endregion

        public unsafe Parrot(byte height, int x, bool dir, Texture2D textureStill, Texture2D textureFlying) {
           // PositionFlyTo=Pos;
            Position=new Vector2(x*16, height*16);
            Flying=false;
            Dir=dir;
            TextureStill = textureStill;
            TextureFlying = textureFlying;
            Frame=0;
            Id=(ushort)BlockId.MobParrot;
        } 

        public unsafe Parrot(byte height, int x, bool dir, Vector2 Pos, Texture2D textureStill, Texture2D textureFlying) {
            PositionFlyTo=Pos;
            Position=new Vector2(x*16, height*16);
            Flying=true;
            Dir=dir;
            TextureStill = textureStill;
            TextureFlying = textureFlying;
            Frame=0;
            Id=(ushort)BlockId.MobParrot;
        } 

        public unsafe override byte[] Save(){ 
            ushort 
                id=Id, 
                flyToX=(ushort)PositionFlyTo.X;
			byte* 
                mbytes=(byte*)&id,
                mbytesFlyToX=(byte*)&flyToX;

            if (Flying) 
                return new byte[]{ 
                        mbytes[1], 
                        mbytes[0], 
                        Flying? (byte)1 : (byte)0, 
                        Height, 
                        Dir ? (byte)1 : (byte)0, 

                        mbytesFlyToX[1], 
                        mbytesFlyToX[0], 
                        (byte)(PositionFlyTo.Y/16f)
                    };
            else return 
                new byte[]{ 
                    mbytes[1], 
                    mbytes[0], 
                    Flying? (byte)1 : (byte)0, 
                    Height, 
                    Dir ? (byte)1 : (byte)0, 
                };
        }
        
        public Parrot(int height, int x, bool dir, bool Flying, Texture2D textureStill, Texture2D textureFlying) {
            Position=new Vector2(x*16, height*16);
            TextureStill = textureStill;
            TextureFlying = textureFlying;
            this.Flying=Flying;
            Frame=0;
            Dir=dir;
            Id=(ushort)BlockId.MobParrot;
        }

        public void UpdateFlying() { 
            if (FastMath.DistanceInt(Position.X,Position.Y, PositionFlyTo.X,PositionFlyTo.Y)<=BirdSpeed*2) { 
                
                Position=PositionFlyTo;
                Flying=false;

                // invoke to check existence of destination flight
                /*if (*/StopFlying.Invoke();//) {
                //}

            } else { 
                Position+=SpeedVector;
            }
        }

        public void SetFlying(int x, int y) { 
            Flying=true;
           
            PositionFlyTo.X=x;
            PositionFlyTo.Y=y;

            Vector2 RawSpeedVector=new Vector2(PositionFlyTo.X-Position.X, PositionFlyTo.Y-Position.Y);
            float vecSize=(float)Math.Sqrt(RawSpeedVector.X*RawSpeedVector.X+RawSpeedVector.Y*RawSpeedVector.Y);

            SpeedVector=RawSpeedVector/vecSize*BirdSpeed;
            Dir=SpeedVector.X>0;
        }

        public override void Draw() {
            if (Flying) {
                UpdateFlying();

                // Frames
                Frame+=10;
                if (Frame>TextureFlying.Width-35)Frame-=TextureFlying.Width-35;

                // Draw
                if (Dir) Rabcr.spriteBatch.Draw(TextureFlying/*Rabcr.Pixel*/, Position, new Rectangle((int)(Frame/35)*35+4,0,35,35), Color.White, 0, Vector2.Zero, /*1f*/.5f, SpriteEffects.FlipHorizontally, 0);
                else Rabcr.spriteBatch.Draw(TextureFlying, Position, new Rectangle((int)(Frame/35f)*35+4,0,35,35), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            } else Rabcr.spriteBatch.Draw(TextureStill, new Vector2(Position.X+5,Position.Y-10), Color.White);
        }
    }
}