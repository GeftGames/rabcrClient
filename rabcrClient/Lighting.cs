using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class Lighting {
        Vector2[] Points;
        int Length;
        Color Color=Color.White;
        public Lighting() {

        }

        void Generate(Vector2 from, Vector2 to) {
            float len=(to+from).Length();
            Length=(int)(len/10);
            Points=new Vector2[Length];

            Points[0]=from;
            Points[Length]=to;

            if (len/2!=0) Insert(0, Length, Length/2, Length/2f);
        }

        void Insert(int i, int i2, int ins, float step) {
            Vector2 from=Points[i];
            Vector2 to=Points[i2];

            float len=(to+from).Length();
            Vector2 half=(to+from)*step;

            Points[ins]=new Vector2(half.X+FastRandom.Int((int)(len/4)), half.Y+FastRandom.Int((int)(len/4)));
            
            if (ins-i  == 1) return;
            if (i2-ins == 1) return;

          //  if ((ins-i)>1)
          {
                int l=ins-i;
                Insert(i, ins, l/2, step-l/2f);
            }

          //  if ((i2-ins)>1)
           {
                int l = i2-ins;
                Insert(ins, i2, l/2, step+l/2f);
            }
        }

        public void Draw() {
            if (Length==0) return;

            Vector2 last=Points[0];

            for (int i=1; i<Length; i++){
                Vector2 current=Points[i];
                DrawLine(last, current, Color);
                last=current;
            }
        }

        void DrawLine(Vector2 start, Vector2 end, Color c) {
            float _x=end.X-start.X,
                  _y=end.Y-start.Y;

            Rabcr.spriteBatch.Draw(
                Rabcr.Pixel,
                new Rectangle(
                    (int)start.X,
                    (int)start.Y,
                    (int)Math.Sqrt(_x*_x + _y*_y),
                    1
                ),
                null,
                c,
                (float)Math.Atan2(_y, _x),
                new Vector2(0, 0),
                SpriteEffects.None,
                0
            );
        }
    }
}
