using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace rabcrClient {
    public class FastRandom {
        #region Data Members

        // Constants
        const double DOUBLE_UNIT = 1.0 / ( int.MaxValue + 1.0 );

        // State Fields
        ulong x_, y_;

        // Buffer for optimized bit generation
        ulong buffer;

        int freeBuffer;
        #endregion

        #region Constructor

        /// <summary>Constructs a new generator using two random Guid hash codes as a seed.</summary>
        public FastRandom() {
            y_ = (ulong)Guid.NewGuid().GetHashCode();
            x_ = (ulong)Guid.NewGuid().GetHashCode();
        }

        /// <summary>Constructs a new generator with the supplied seed.</summary>
        /// <param name = "seed">The seed value.</param>
        public FastRandom(ulong seed) {
            x_=seed<<3;
            x_=seed>>3;
        }
        #endregion

        #region Public Methods
        /// <summary>Generates a pseudorandom boolean.</summary>
        /// <returns>A pseudorandom boolean.</returns>
        public bool Bool() {
            if (freeBuffer > 0) {
                freeBuffer--;
                return ((buffer>>=1) & 1) == 0;
            }

            ulong temp_x = y_;
            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-1;
            return (buffer & 1) == 0;
        }

        public int Int2() {
            if (freeBuffer > 0) {
                freeBuffer--;
                return (int)((buffer>>=1) & 1);
            }

            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;
            
            buffer = y_ + temp_x;

            freeBuffer=64-1;
            return (int)(buffer & 1);
        }

        public int Int4() {
            if (freeBuffer > 1) {
                freeBuffer-=2;
                return (int)((buffer>>=2) & 0x00000000000003);
            }

            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-2;
            return (int)(buffer & 0x00000000000003);
        }

        public int Int8() {
            if (freeBuffer > 2) {
                freeBuffer-=3;
                return (int)((buffer>>=3) & 0x00000000000007);
            }

            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;
            
            freeBuffer=64-3;
            return (int)(buffer & 0x00000000000007);
        }

        public int Int16() {
            if (freeBuffer > 3) {
                freeBuffer-=4;
                int y=(int)((buffer>>=3) & 0x0000000000000F);
                return y;
            }

            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-4;
            return (int)(buffer & 0x0000000000000F);
        }

         public void Byte2(List<byte> list) {
            if (freeBuffer > 0) {
                freeBuffer--;
                list.Add((byte)((buffer>>=1) & 1));
                return;
            }

            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;
                        
            buffer = y_ + temp_x;

            freeBuffer=64-1;
            list.Add((byte)(buffer & 1));
            return;
        }

        /// <summary>Generates a pseudorandom byte.</summary>
        /// <returns>A pseudorandom byte.</returns>
        public byte Byte() {
            if (freeBuffer >= 8) {
                freeBuffer-=8;
                return (byte)((buffer>>=8) & 0x000000000000FF);
            }

            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-8;
            return (byte)(buffer & 0x000000000000FF);
        }

        public byte Byte128_Plus128() {
            if (freeBuffer >= 7) {
                freeBuffer-=7;
                return (byte)((buffer>>=7) & 0x0000000000007F + 128);
            }

            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-7;
            return (byte)(buffer & 0x0000000000007F + 128);
        }

        public void Byte(List<byte> list) {
            if (freeBuffer >= 8) {
                freeBuffer-=8;
                list.Add((byte)((buffer>>=8) & 0x000000000000FF));
                return;
            }

            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ ( x_ >> 17 ) ^ ( y_ >> 26 );
            x_ = temp_x;

            buffer = y_ + temp_x;

            freeBuffer=64-8;
            list.Add((byte)(buffer & 0x000000000000FF));
            return;
        }

        /// <summary>Generates a pseudorandom 32-bit unsigned integer.</summary>
        /// <returns>A pseudorandom 32-bit unsigned integer.</returns>
        public uint UInt() {
            ulong temp_x=y_;

            x_^=x_<<23;
            y_=x_^y_^(x_>>17)^(y_>>26);
            x_=temp_x;

            return (uint)(y_+temp_x);
        }
       
        /// <summary>Generates a pseudorandom double between 0 and 1 non-inclusive.</summary>
        /// <returns>A pseudorandom double.</returns>
        public double Double() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return DOUBLE_UNIT * (0x7FFFFFFF & (y_ + temp_x));
        }

        /// <summary>Generates a pseudorandom float between 0 and 1 non-inclusive.</summary>
        /// <returns>A pseudorandom double.</returns>
        public float Float() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (float)(DOUBLE_UNIT * (0x7FFFFFFF & (y_ + temp_x)));
        }
    #endregion

        public bool Bool_20Percent() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.2;
        }

        public bool Bool_33_333Percent() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.33333333333;
        }

        public bool Bool_10Percent() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.1;
        }

        public bool Bool_11_111Percent() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.11111111111111;
        }

        public bool Bool_5_555Percent() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.0555555555555556;
        }

        public bool Bool_2Percent() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.02;
        }

        public bool Bool_5Percent() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_))) < 0.05;
        }

        public bool Bool_75Percent() {
            ulong temp_x = y_;
            x_^=x_<<23;
            y_=x_^y_^(x_>>17)^(y_>>26);
            x_=temp_x;
            return (DOUBLE_UNIT*(0x7FFFFFFF&(temp_x+y_)))<0.75;
        }
        
        public bool Bool_1Percent() {
            ulong temp_x = y_;
            x_^=x_<<23;
            y_=x_^y_^(x_>>17)^(y_>>26);
            x_=temp_x;
            return (DOUBLE_UNIT*(0x7FFFFFFF&(temp_x+y_)))<0.01;
        }
        
        public bool Bool_25Percent() => Int4()==1;

        public bool Bool_12_5Percent() {
            ulong temp_x = y_;
            x_^=x_<<23;
            y_=x_^y_^(x_>>17)^(y_>>26);
            x_=temp_x;
            return (DOUBLE_UNIT*(0x7FFFFFFF&(temp_x+y_)))<0.125;
        }

        public byte Byte3() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (byte)(DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_)) * 3);
        }

        public int Int3() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (int)(DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_)) * 3);
        }
        
        public int Int5() {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (int)(DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_)) * 5);
        }

        public Color ColorMonogame() => new Color(UInt() | 0xFF000000);

        public unsafe System.Drawing.Color ColorSystemDrawing() {
            uint r=UInt() | 0xFF000000;
            return System.Drawing.Color.FromArgb(*(int*)&r);
        }

        public int Int(int minValue, int maxValue) {
           ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (int)(DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_)) * (maxValue-minValue)) + minValue;
        }
        
        public int Int(int value) {
            ulong temp_x = y_;

            x_ ^= x_ << 23; 
            y_ = x_ ^ y_ ^ (x_ >> 17) ^ (y_ >> 26);
            x_ = temp_x;

            return (int)(DOUBLE_UNIT * (0x7FFFFFFF & (temp_x + y_)) * value);
        }
    }
}