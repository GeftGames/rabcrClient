﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient {
    class Parrot:Mob {
        
        #region Varibles
        const float BirdSpeed=5f;

       public bool Flying;
        Vector2 SpeedVector;
        Texture2D TextureStill, TextureFlying;

        public bool FlyRight;
        public int Frame;
        public Vector2 PositionFlyTo;

        public delegate bool EventStopFly();
        public event EventStopFly StopFlying;
        #endregion

        public Parrot(byte height, int x, bool dir, bool Flying, Texture2D textureStill, Texture2D textureFlying) {
          //  Position.Y=height*16;
            Position=new Vector2(x*16, height*16);
            TextureStill = textureStill;
            TextureFlying = textureFlying;
          
            Frame=0;
            FlyRight=dir;
            Id=(ushort)BlockId.MobParrot;
        } 
        public unsafe override byte[] Save(){ 
            ushort id=Id;
			byte* mbytes=(byte*)&id ;
 
            return new byte[]{ mbytes[1], mbytes[0], Height, Dir ? (byte)1 : (byte)0, Flying? (byte)1 : (byte)0 };
        }
        
        public Parrot(int height, int x, bool dir, bool Flying, Texture2D textureStill, Texture2D textureFlying) {
          //  Position.Y=height*16;
            Position=new Vector2(x*16, height*16);
            TextureStill = textureStill;
            TextureFlying = textureFlying;
          
            Frame=0;
            FlyRight=dir;
            Id=(ushort)BlockId.MobParrot;
        }

        public void UpdateFlying() { 
            if (FastMath.DistanceInt(Position.X,Position.Y,PositionFlyTo.X,PositionFlyTo.Y)<BirdSpeed*2) { 
                
                Position=PositionFlyTo;
                // invoke to check existence of destination flight
                if (StopFlying.Invoke()) { 
                    Flying=false;    
                }

            } else { 
                Position+=SpeedVector;
            }
        }

        public void SetFlying(int x, int y) { 
            Flying=true;
           
            PositionFlyTo.X=x;
            PositionFlyTo.Y=y;

            Vector2 RawSpeedVector=new Vector2(PositionFlyTo.X-Position.X, PositionFlyTo.Y-Position.Y);
            float vecSize=RawSpeedVector.X*RawSpeedVector.X+RawSpeedVector.Y*RawSpeedVector.Y;

            SpeedVector=RawSpeedVector/vecSize*BirdSpeed;
            FlyRight=SpeedVector.X>0;
        }

        public override void Draw() {
            if (Flying) {
                UpdateFlying();
                // Frames
                Frame+=10;
                if (Frame>TextureFlying.Width)Frame-=TextureFlying.Width;

                if (FlyRight) Rabcr.spriteBatch.Draw(TextureFlying, Position, new Rectangle((int)(Frame/35f)*16,0,35,35), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.FlipHorizontally, 0);
                else Rabcr.spriteBatch.Draw(TextureFlying, Position, new Rectangle((int)(Frame/35f)*16,0,35,35), Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
            } else Rabcr.spriteBatch.Draw(TextureStill, Position, Color.White);
        }
    }
}