using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;

namespace rabcrClient {
    static class FastMath {
        /// <summary>Pi constant </summary>
        public const float PI=3.14159265359f;

        public const float PIHalf=1.57079632679f;

        public const float PI1_5=4.71238898038f;

        const float B = 4 / PI;
        const float C = -4 / (PI*PI);
        const float A = PI*PI / 4;

        const float D = 4 / (PI*PI);
        const float E = 3*PI*PI / 4;
        const float F = - 2*PI;

        const float G = - 4*PI;
        const float H = 15*PI*PI / 4;

        /// <summary>Fast nonprecise sin, x from -pi to pi</summary>
        public static float Sin(float x) => B * x + C * x * ((x > 0) ? x : -x);

        ///// <summary>Fast nonprecise sin, x from 0 to pi</summary>
        //public static float SinFrom0toPI(float x) => (B + C * x) * x;

        ///// <summary>Fast nonprecise sin, x from 0 to pi</summary>
        //public static float SinFrommPIto0(float x) => -(B + C * x) * x;

        /// <summary>Fast nonprecise cos -pi/2 to 5/2pi</summary>
        public static float Cos(float x) {
            if (x<PI/2) return C*(x*x - A);
            if (x<3*PI/2) return D*(x*x + E + F*x);
            return C*(x*x + G * x + H);
        }

        ///// <summary>Fast nonprecise cos, x from -pi/2 to +pi/2</summary>
        //public static float CosFrommPIhtopPih(float x) => C*(x*x - A);

        ///// <summary>Fast nonprecise cos, x from +pi/2 to +3pi/2</summary>
        //public static float CosFrompPIhtop3Pih(float x) => D*(x*x + E + F*x);

        ///// <summary>Fast nonprecise cos, x from +3pi/2 to +5pi/2</summary>
        //public static float CosFromp3Pihtop5Pih(float x) => C*(x*x + G * x + H);

        public static int Round(float x) => (int)(x+0.5f);

        public static float Distance(float x1, float y1, float x2, float y2) {
            float dx=x1-x2, dy=y1-y2;
            return (float)System.Math.Sqrt(dx*dx+dy*dy);
        }

        public static int Distance(int x1, int y1, float x2, float y2) {
            float dx=x1-x2, dy=y1-y2;
            return (int)System.Math.Sqrt(dx*dx+dy*dy);
        }

        public static int Distance(int x1, int y1, int x2, int y2) {
            float dx=x1-x2, dy=y1-y2;
            return (int)System.Math.Sqrt(dx*dx+dy*dy);
        }

        /// <summary>
        /// Smooth linear function
        /// </summary>
        /// <param name="input">If it's distance*sqrt(2)>comp </param>
        /// <returns></returns>
        public static int DistanceInt(float x1, float y1, float x2, float y2) {
            float dx=x1-x2, dy=y1-y2;
            return (int)System.Math.Sqrt(dx*dx+dy*dy);
        }

        //public static float Distance(int x1, int y1, int x2, int y2) {
        //    int dx=x1-x2, dy=y1-y2;
        //    return (float)System.Math.Sqrt(dx*dx+dy*dy);
        //}

        public static int DistanceInt(int x1, int y1, int x2, int y2) {
            int dx=x1-x2, dy=y1-y2;
            return (int)System.Math.Sqrt(dx*dx+dy*dy);
        }

        public static Color Lerp(Color value1, Color value2, float amount) {
            float _amount=1-amount;
            return new Color(
                (byte)(value1.R*_amount + value2.R*amount + .5f),
                (byte)(value1.G*_amount + value2.G*amount + .5f),
                (byte)(value1.B*_amount + value2.B*amount + .5f),
                (byte)255/*(value1.A*_amount + value2.A*amount)*/
            );
        }

        //         ┌---               ╭-
        //        ╱                 〳
        //       ╱                 ╱
        //      ╱          ->     │
        //     ╱                 ╱
        //    ╱                 〳
        //---┘                -╯
        /// <summary>Smooth linear function</summary>
        /// <param name="input">From 0 to 1</param>
        public static float Smooth(float input) {
            if (input<0.5f) return 2*input*input;
            else return -2*(input-1)*(input-1)+1;
        }
      
        public unsafe static float InvSqrt3(float x) {
           float xhalf = 0.5f*x;
           int i = *(int*)&x;
           i = 0x5f3759df - (i>>1);
           x = *(float*)&i;
           x *= (1.5f - xhalf*x*x);
           return x;
        }

        public static int Abs(int input) => input>=0 ? input  : -input;

        public static float Abs(float input) => input>=0f ? input : -input;

        //public static Color bilinear(Color[,] corners, Vector2 uv) {
        //     Color cTop = Lerp(corners[0, 1], corners[1, 1], uv.X);
        //     Color cBot = Lerp(corners[0, 0], corners[1, 0], uv.X);
        //     Color cUV  = Lerp(cBot, cTop, uv.Y);
        //     return cUV;
        // } 
         
        // public static Color bilinear(Color c1, Color c2, Color c3, Color c4, float a1, float a2, float a3, float a4) {
        //     Color cTop = Lerp(c3, c4, uv.X);
        //     Color cBot = Lerp(c1, c2, uv.X);
        //     Color cUV  = Lerp(cBot, cTop, uv.Y);
        //     return cUV;
        // }
    }
}
