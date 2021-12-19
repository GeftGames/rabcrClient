using Microsoft.Xna.Framework;
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
            HSpeed+=gravity*0.5f;
            Position.Y+=HSpeed;

            Position.X+=VSpeed;

            if (Position.Y>=LimitY) Position.Y=LimitY;
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

        public ParticleRain(float size, float vSpeed) {
            Color=Color.Blue*(Size=size);
            VSpeed=vSpeed*(size*0.5f+0.5f);
        }

        public void Update() {
            Position.X+=HSpeed*Size;
            Position.Y+=VSpeed;
        }

        public void Draw(float x, float y,float a) => Rabcr.spriteBatch.Draw(
                texture: Rabcr.Pixel,
                destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y), 1, Size<0.5f ? 2 : 3),
                color: Color*a
            );
    }

    class ParticleSnow {
        public Vector2 Position;

        public float HSpeed;
        public float VSpeed;
        public Color Color;
        //	public float Angle;
        int time;
        public float Size;
        float amplitude=1;
        public ParticleSnow(float size, float vSpeed) {
            Color=Color.White*(Size=size);
            VSpeed=vSpeed*size;
        }

        public void Update() {
            time++;
            if (time%10==0) amplitude=FastRandom.Float()*2-1;

            Position.X+=HSpeed+amplitude*((float)Math.Cos(time/10f))*0.25f;
            Position.Y+=VSpeed+((float)Math.Sin(time/10f))*HSpeed*0.5f/*+0.2f*/;
        }

        public void Draw(float x, float y,float A) => Rabcr.spriteBatch.Draw(
                texture: Rabcr.Pixel,
                destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y), Size>0.5f ? 2 : 1, Size>0.5f ? 2 : 1),
                color: Color*A
            );

    }

    class FallingLeave {
        public Texture2D texture;
        public Vector2 Position;
        public float angle;
        public float time;
        //	public float size;
        Vector2 vecOrigin;
        public float VSpeed;
        public Rectangle srcrec;
        public Color Color = Color.White;
        public FallingLeave(int x, int y, float size, bool leftWind, bool rain, Rectangle src) {
            Position=new Vector2(x, y);
            vecOrigin=new Vector2(size, size);
            if (rain) {
                if (leftWind) VSpeed=-0.01f; else VSpeed=0.01f;
            } else {
                if (leftWind) VSpeed=-0.09f; else VSpeed=0.09f;
            }
            srcrec=src;
        }

        public void Update() {
            time+=0.07f;
            Position.X+=VSpeed;
            Position.Y+=(float)Math.Cos(time)*0.125f+0.35f;
            angle=(float)Math.Cos(time)*0.3f+FastMath.PI/2f;
        }

        public void Draw() {
            Rabcr.spriteBatch.Draw(
                texture: texture,
                position: new Vector2(Position.X, Position.Y),
                sourceRectangle: srcrec,
                effects: SpriteEffects.None,
                color: Color,
				scale: 1f,
                rotation: angle,
                origin: vecOrigin,
                layerDepth: 1f);
        }
    }
}