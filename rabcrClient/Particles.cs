﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient {
    class ParticleMess {
        public static float gravity=1f;
        public Vector2 Position;
        public Rectangle Source;
        public Texture2D Texture;
        public int Disepeard;

        public float LimitY;
        public float HSpeed;
        public float VSpeed;
        public Color Color;

        public void Update() {
            VSpeed+=gravity*0.5f;
            if (VSpeed>3)VSpeed=3;

            Position.Y+=VSpeed;

            

            if (Position.Y>=LimitY) Position.Y=LimitY;
            else Position.X+=HSpeed;
        }

        public void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, Source, Color*(Disepeard/50f));
    }

    class ParticleRain {
        public Vector2 Position;

        public float HSpeed;
        public float VSpeed;
        public Color Color;
        //	public float Angle;

        public float Size;
        readonly int Height, Width;

        public ParticleRain(float size, float vSpeed) {
            Size=size;
            Color = FastRandom.Int(6) switch {
                1 => new Color(97, 111, 166) * size,
                2 => new Color(67, 75, 127) * size,
                //case : 
                // //   Color=Color.Blue*size;
                //    break;
                4 => new Color(164, 173, 211) * size,
                3 => new Color(42, 50, 92) * size,
                _ => new Color(127, 139, 189) * size,
            };
            //   Color=Color.Blue*();
            VSpeed =vSpeed*(size*0.5f+0.5f);
            Height=Size<0.25f ? 3 : (Size<0.75f ? 4 : 5);
            Width=Size<0.5f ? 1 : 2;
        }

        public void Update() {
            Position.X+=HSpeed*Size;
            Position.Y+=VSpeed;
        }

        public void Draw(float x, float y,float a) {
            Rabcr.spriteBatch.Draw(
                texture: Rabcr.Pixel,
                destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y), Width, Height),
                color: Color*a
            );
        }

        public void DrawBetterQuality(float x, float y,float a) {
            Rabcr.spriteBatch.Draw(
                texture: Rabcr.Pixel,
                destinationRectangle: new Rectangle((int)(Position.X+0.5f+x)+1, (int)(Position.Y+0.5f+y)+1, Width, Height),
                color: Color.Black*a*0.05f
            );

            Rabcr.spriteBatch.Draw(
                texture: Rabcr.Pixel,
                destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y)-1, Width, Height),
                color: Color.White*a*0.05f
            );

            Rabcr.spriteBatch.Draw(
                texture: Rabcr.Pixel,
                destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y), Width, Height),
                color: Color*a
            );
        }
    }

    class ParticleSnow {
        public Vector2 Position;

        public float HSpeed, VSpeed;
      //  public Color Color;
        //	public float Angle;
        float time=0f;
      //  public float Size;
        float amplitude=1;
        public ParticleSnow(float size, float vSpeed) {
        //    Color=Color.White*(Size=size);
            VSpeed=vSpeed*size;
        }

        public void Update(bool right) {
            time+=0.1f;
            if (time==(int)time) amplitude=FastRandom.FloatTWO()-1;

            if (right) Position.X+=HSpeed+amplitude*((float)Math.Cos(time))*0.25f;
            else Position.X-=HSpeed+amplitude*((float)Math.Cos(time))*0.25f;
            Position.Y+=VSpeed+((float)Math.Sin(time))*HSpeed*0.5f/*+0.2f*/;
        }

        public void Draw(float x, float y, Color c) { 
            Rabcr.spriteBatch.Draw(
                texture: Rabcr.Pixel2,
                new Vector2(Position.X/*+0.5f*/+x, Position.Y/*+0.5f*/+y),
                color: c
            );
        }
    }

    class ParticleSnowSmall {
        public Vector2 Position;

        public float HSpeed;
        public float VSpeed;
       // public Color Color;
        //	public float Angle;
        float time=0f;
        public float Size;
        float amplitude=1f;
        public ParticleSnowSmall(float vSpeed) {
            Size=FastRandom.FloatHalf()+0.5f;
         //   Color=Color.White*Size;
            VSpeed=vSpeed*Size;
        }

        public void Update(bool right) {
            time+=0.1f;
            if (time==(int)time) amplitude=FastRandom.FloatTWO()-1;

            if (right) Position.X+=HSpeed+amplitude*((float)Math.Cos(time))*0.25f;
            else Position.X-=HSpeed+amplitude*((float)Math.Cos(time))*0.25f;
            Position.Y+=VSpeed+((float)Math.Sin(time))*HSpeed*0.5f/*+0.2f*/;
        }

        public void Draw(float x, float y, Color c) 
            => Rabcr.spriteBatch.Draw(
                Rabcr.Pixel,
                new Vector2(Position.X+x, Position.Y+y),
                c
            );
    }

    class FallingLeave {
        public Texture2D texture;
        public Vector2 Position;
        public float angle;
        public float time;
        public float alpha=1f;

        //	public float size;
      //  readonly Vector2 vecOrigin;
        public float VSpeed;
        public Rectangle srcrec;

        public Color color = Color.White;
        readonly float size;
        public FallingLeave(int x, int y, /*float size,*/ bool leftWind, bool rain, Rectangle src) {
            
            Position=new Vector2(x, y);
          // vecOrigin=new Vector2(/*size*/src.Width*0.5f, src.Height*0.5f/*size*/);
            if (rain) {
                if (leftWind) VSpeed=-0.01f; else VSpeed=0.01f;
            } else {
                if (leftWind) VSpeed=-0.09f; else VSpeed=0.09f;
            }
            size=FastRandom.Float();
            srcrec=src;
        }

        public void Update() {
            time+=0.07f;
            Position.X+=VSpeed;
            Position.Y+=(float)Math.Cos(time)*0.125f+0.35f;
            angle=(float)Math.Cos(time)*0.3f+FastMath.PIHalf;
        }

        public void Draw() {
            Rabcr.spriteBatch.Draw(
                texture: texture,
                position: /*new Vector2(*/Position/*.X, Position.Y)*/,
                sourceRectangle: srcrec,
                effects: SpriteEffects.None,
                color: color*alpha,
				scale: /*1f*/0.5f*size+0.5f,
                rotation: angle,
                origin: /*vecOrigin*/Vector2.Zero,
                layerDepth: 1f);
        }
    }
    public class FallingBlockInfo {
        public NormalBlock block;
        public DInt to, to16, from;
        public bool side;
        public float Speed;
    }
}