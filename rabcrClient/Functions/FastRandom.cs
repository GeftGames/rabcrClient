using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace rabcrClient {
    public static class FastRandom {
        #region Data Members

        // Constants
        const double DOUBLE_UNIT = 1.0 / ( int.MaxValue + 1.0 );
        const double DOUBLE_UNIT_HALF = 0.5 / ( int.MaxValue + 1.0 );
        const double DOUBLE_UNIT_TWO = 2.0 / ( int.MaxValue + 1.0 );
        // State Fields
        static ulong
            x_ = (ulong)Guid.NewGuid().GetHashCode(),
            y_ = (ulong)Guid.NewGuid().GetHashCode();

        // Buffer for optimized bit generation
        static ulong buffer;

        static int freeBuffer;
        #endregion

        #region Constructor

        /// <summary>Constructs a new generator using two random Guid hash codes as a seed.</summary>
        //public static FastRandom() {
        //    y_;
        //    x_
        //}

        /// <summary>Constructs a new generator with the supplied seed.</summary>
        /// <param name = "seed">The seed value.</param>
        public static void SetSeed(ulong seed) {
            x_=seed<<3;
            x_=seed>>3;
        }
        #endregion

        #region Public Methods
        /// <summary>Generates a pseudorandom boolean.</summary>
        /// <returns>A pseudorandom boolean.</returns>
        public static bool Bool() {
            if (freeBuffer > 0) {
                freeBuffer--;
                return ((buffer>>=1) & 1) == 0;
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-1;
            return (buffer & 1) == 0;
        }

        public static int Int2() {
            if (freeBuffer > 0) {
                freeBuffer--;
                return (int)((buffer>>=1) & 1);
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-1;
            return (int)(buffer & 1);
        }

        public static int IntPlusMinusOne() {
            if (freeBuffer > 0) {
                freeBuffer--;
                return (int)((buffer>>=1) & 1);
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-1;
            int z=(int)(buffer & 2);
            #if DEBUG
            if (z!=2 && z!=0) throw new Exception();
            #endif

            return z-1;
        }

        public static int Int4() {
            if (freeBuffer > 1) {
                freeBuffer-=2;
                return (int)((buffer>>=2) & 0x00000000000003);
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-2;
            return (int)(buffer & 0x00000000000003);
        }

        public static int Int8() {
            if (freeBuffer > 2) {
                freeBuffer-=3;
                return (int)((buffer>>=3) & 0x00000000000007);
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-3;
            return (int)(buffer & 0x00000000000007);
        }

        public static int Int16() {
            if (freeBuffer > 3) {
                freeBuffer-=4;
                return (int)((buffer>>=3) & 0x0000000000000F);
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;
            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-4;
            return (int)(buffer & 0x0000000000000F);
        }

         public static void Byte2(List<byte> list) {
            if (freeBuffer > 0) {
                freeBuffer--;
                list.Add((byte)((buffer>>=1) & 1));
                return;
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-1;
            list.Add((byte)(buffer & 1));
            return;
        }

        /// <summary>Generates a pseudorandom byte.</summary>
        /// <returns>A pseudorandom byte.</returns>
        public static byte Byte() {
            if (freeBuffer >= 8) {
                freeBuffer-=8;
                return (byte)((buffer>>=8) & 0x000000000000FF);
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-8;
            return (byte)(buffer & 0x000000000000FF);
        }

        public static byte Byte128_Plus128() {
            if (freeBuffer >= 7) {
                freeBuffer-=7;
                return (byte)((buffer>>=7) & 0x0000000000007F + 128);
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-7;
            return (byte)(buffer & 0x0000000000007F + 128);
        }

        public static void Byte(List<byte> list) {
            if (freeBuffer >= 8) {
                freeBuffer-=8;
                list.Add((byte)((buffer>>=8) & 0x000000000000FF));
                return;
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-8;
            list.Add((byte)(buffer & 0x000000000000FF));
            return;
        }

        /// <summary>Generates a pseudorandom 32-bit unsigned integer.</summary>
        /// <returns>A pseudorandom 32-bit unsigned integer.</returns>
        public static uint UInt() {

            x_^=x_<<23;

            ulong temp_x=y_;

            y_=x_^y_^(x_>>17)^(y_>>26);
            x_=temp_x;

            return (uint)(y_+temp_x);
        }

        /// <summary>Generates a pseudorandom double between 0 and 1 non-inclusive.</summary>
        /// <returns>A pseudorandom double.</returns>
        public static double Double() {

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return DOUBLE_UNIT * (0x7FFFFFFF & (y_ + temp_x));
        }

        /// <summary>Generates a pseudorandom float between 0 and 1 non-inclusive.</summary>
        /// <returns>A pseudorandom double.</returns>
        public static float Float() {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (float)(DOUBLE_UNIT * (0x7FFFFFFF & (y_ + temp_x)));
        }
        
        public static float FloatHalf() {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (float)(DOUBLE_UNIT_HALF * (0x7FFFFFFF & (y_ + temp_x)));
        }
        
        public static float FloatTWO() {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (float)(DOUBLE_UNIT_TWO * (0x7FFFFFFF & (y_ + temp_x)));
        }

        public static float Rotatin() {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (float)(DOUBLE_UNIT * (0x7FFFFFFF & (y_ + temp_x)))*6.28318530717958647693f;
        }
    #endregion

        public static bool Bool_20Percent() {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.2;
        }

        public static bool Bool_33_333Percent() {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.33333333333;
        }

        public static bool Bool_10Percent() {

            x_ ^= x_ << 23;
            ulong temp_x = y_;
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.1;
        }

        public static bool Bool_11_111Percent() {

            x_ ^= x_ << 23;
            ulong temp_x = y_;
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.11111111111111;
        }

        public static bool Bool_5_555Percent() {

            x_ ^= x_ << 23;
            ulong temp_x = y_;
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.0555555555555556;
        }

        public static bool Bool_2Percent() {

            x_ ^= x_ << 23;
            ulong temp_x = y_;
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.02;
        }

        public static bool Bool_5Percent() {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.05;
        }

        public static  bool Bool_75Percent() {
            x_^=x_<<23;

            ulong temp_x = y_;

            y_=x_^y_^(x_>>17)^(y_>>26);
            x_=temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x+y_))) < 0.75;
        }

        public static bool Bool_1Percent() {
            x_^=x_<<23;
            ulong temp_x = y_;
            y_=x_^y_^(x_>>17)^(y_>>26);
            x_=temp_x;
            return (DOUBLE_UNIT*(0x7FFFFFFF&(temp_x+y_)))<0.01;
        }

        public static bool Bool_25Percent() {
            if (freeBuffer > 1) {
                freeBuffer-=2;
                return (int)((buffer>>=2) & 0x00000000000003)==1;
            }

            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-2;
            return (int)(buffer & 0x00000000000003)==1;
        }

        public static bool Bool_12_5Percent() {
            x_^=x_<<23;

            ulong temp_x = y_;

            y_=x_^y_^(x_>>17)^(y_>>26);
            x_=temp_x;

            return (DOUBLE_UNIT*(0x7FFFFFFF&(temp_x+y_)))<0.125;
        }

        public static byte Byte3() {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (byte)(DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_)) * 3);
        }

        public static int Int3() {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (int)(DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_)) * 3);
        }

        public static int Int5() {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (int)(DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_)) * 5);
        }

        public static Color ColorMonogame() { 
            x_^=x_<<23;

            ulong temp_x=y_;

            y_=x_^y_^(x_>>17)^(y_>>26);
            x_=temp_x;

            return new((uint)(y_+temp_x) | 0xFF000000);
        }

        public static unsafe System.Drawing.Color ColorSystemDrawing() {
            uint r = UInt() | 0xFF000000;
            return System.Drawing.Color.FromArgb(*(int*)&r);
        }

        public static int Int(int minValue, int maxValue) {
            x_ ^= x_ << 23;

           ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (int)(DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_)) * (maxValue-minValue)) + minValue;
        }

        public static int Int(int value) {
            x_ ^= x_ << 23;

            ulong temp_x = y_;

            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (int)(DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_)) * value);
        }
    }
}