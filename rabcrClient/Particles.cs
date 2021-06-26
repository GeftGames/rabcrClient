//using System;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;

//namespace rabcrClient {
//    partial class SinglePlayer : Screen {
//        //class ParticleMess {
//        //    public Vector2 Position;
//        //    public Rectangle Source;
//        //    public Texture2D Texture;
//        //    public int Disepeard;

//        //    public float LimitY;
//        //    public float HSpeed;
//        //    public float VSpeed;
//        //    public Color Color;

//        //    public void Update() {
//        //        HSpeed+=gravity*0.5f;
//        //        Position.Y+=HSpeed;

//        //        Position.X+=VSpeed;

//        //        if (Position.Y>=LimitY) Position.Y=LimitY;
//        //    }

//        //    public void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, Source, Color*(Disepeard/50f));
//        //}

//        //class ParticleRain {
//        //    public Vector2 Position;

//        //    public float HSpeed;
//        //    public float VSpeed;
//        //    public Color Color;
//        //    //	public float Angle;

//        //    public float Size;

//        //    public ParticleRain(float size, float vSpeed) {
//        //        Color=Color.Blue*(Size=size);
//        //        VSpeed=vSpeed*(size*0.5f+0.5f);
//        //    }

//        //    public void Update() {
//        //        Position.X+=HSpeed*Size;
//        //        Position.Y+=VSpeed;
//        //    }

//        //    public void Draw(float x, float y) => Rabcr.spriteBatch.Draw(
//        //            texture: Rabcr.Pixel,
//        //            destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y), 1, Size<0.5f ? 2 : 3),
//        //            //sourceRectangle: null,
//        //            //effects:SpriteEffects.None,
//        //            color: Color/*,*/
//        //        //rotation: Angle,
//        //        //origin: Vector2.Zero,
//        //        //layerDepth: 1f
//        //        );
//        //}

//        //class ParticleSnow {
//        //    public Vector2 Position;

//        //    public float HSpeed;
//        //    public float VSpeed;
//        //    public Color Color;
//        //    //	public float Angle;
//        //    int time;
//        //    public float Size;

//        //    public ParticleSnow(float size, float vSpeed) {
//        //        Color=Color.White*(Size=size);
//        //        VSpeed=vSpeed*size;
//        //    }

//        //    public void Update() {
//        //        time++;
//        //        Position.X+=HSpeed+((float)Math.Cos(time/10f))*0.25f;
//        //        Position.Y+=VSpeed+((float)Math.Sin(time/10f))*HSpeed*0.5f/*+0.2f*/;
//        //    }

//        //    public void Draw(float x, float y) => Rabcr.spriteBatch.Draw(
//        //            texture: Rabcr.Pixel,
//        //            destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y), Size>0.5f ? 2 : 1, Size>0.5f ? 2 : 1),
//        //            //sourceRectangle: null,
//        //            //effects:SpriteEffects.None,
//        //            color: Color//,
//        //                        //rotation: Angle,
//        //                        //origin: Vector2.Zero,
//        //                        //layerDepth: 1f
//        //        );

//        //}

//        //class FallingLeave {
//        //    public Texture2D texture;
//        //    public Vector2 Position;
//        //    public float angle;
//        //    public float time;
//        //    //	public float size;
//        //    Vector2 vecOrigin;
//        //    public float VSpeed;
//        //    public Rectangle srcrec;
//        //    public Color Color = Color.White;
//        //    public FallingLeave(int x, int y, float size, bool leftWind, bool rain, Rectangle src) {
//        //        Position=new Vector2(x, y);
//        //        vecOrigin=new Vector2(size, size);
//        //        if (rain) {
//        //            if (leftWind) VSpeed=-0.01f; else VSpeed=0.01f;
//        //        } else {
//        //            if (leftWind) VSpeed=-0.09f; else VSpeed=0.09f;
//        //        }
//        //        srcrec=src;
//        //    }

//        //    public void Update() {
//        //        time+=0.07f;
//        //        Position.X+=VSpeed;
//        //        Position.Y+=(float)Math.Cos(time)*0.1f+0.2f;
//        //        angle=(float)Math.Cos(time)*0.3f+FastMath.PI/2f;
//        //    }

//        //    public void Draw() {
//        //        Rabcr.spriteBatch.Draw(
//        //            texture: texture,
//        //            destinationRectangle: new Rectangle((int)Position.X, (int)Position.Y, srcrec.Width, srcrec.Height),
//        //            sourceRectangle: srcrec/*new Rectangle(0,0,2,3)*/,
//        //            effects: SpriteEffects.None,
//        //            color: Color,
//        //            rotation: angle,
//        //            origin: vecOrigin,
//        //            layerDepth: 1f);
//        //    }
//        //}
//    }
//}
