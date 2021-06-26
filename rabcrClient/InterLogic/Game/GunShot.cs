using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient{
    class GunShot {

        #region Varibles
        public float X, Y;
        public float Angle;
        public int Time;

        const int GunShotSize=3;
        const int Speed=10;
       // readonly Rectangle rec;
        Vector2 origin;
        #endregion

        public GunShot() {
            //rec=new Rectangle(0,0,0,0);
            origin=new Vector2(0.5f,GunShotSize/2f);
            Time=0;
        }

        public void Update(){
            X+=(float)Math.Cos(Angle)*Speed;
            Y+=(float)Math.Sin(Angle)*Speed;
        }

        public void Draw(){
            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle((int)X,(int)Y,GunShotSize,1), null, Color.Black*((100-Time)/100f), Angle, origin, SpriteEffects.None, 0);
        }
    }
}