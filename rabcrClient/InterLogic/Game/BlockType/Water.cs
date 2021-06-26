using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class Water : Block{

        public Vector2 Position;
        public Texture2D Texture;
        public bool Fill;
        public int GetMass;
        Vector2 pos;
        public Rectangle rec;

        public void Mass(int value){
            if ((GetMass=value)==255){
                Fill=true;
                return;
            } else {
                Fill=false;
                int h=(int)(16*(GetMass/255f));
                pos = new Vector2(Position.X,Position.Y+16-h);
                rec = new Rectangle(0, 16-h, 16, h);
            }
        }
        public void MassNoFill(int value){
            GetMass=value;

            Fill=false;
            int h=(int)(16*(GetMass/255f));
            pos = new Vector2(Position.X,Position.Y+16-h);
            rec = new Rectangle(0, 16-h, 16, h);
        }

        public Water(){ }

        public Water(Texture2D texture, ushort type, Vector2 position) {
            Texture = texture;
            Position=position;
            Id=type;
        }

        public Water(Texture2D texture, ushort type, Vector2 position, int mass) {
            Texture = texture;
            Position=position;
            Id=type;

            GetMass=mass;
            if (GetMass==255) {
                Fill=true;
            } else {
                int h=(int)(16*(GetMass/255f));
                pos = new Vector2(Position.X, Position.Y+16-h);
                rec = new Rectangle(0, 16-h, 16, h);
            }
        }

        public override void Draw() {

            #if DEBUG
            if (GetMass>255) { Rabcr.spriteBatch.Draw(Texture, Position, Color.Red); return; }
            if (GetMass<0) { Rabcr.spriteBatch.Draw(Texture, Position, Color.Purple); return; }
            if (GetMass==0) { Rabcr.spriteBatch.Draw(Texture, Position, Color.Black); return; }
            #endif

            if (Fill) Rabcr.spriteBatch.Draw(Texture, Position, ColorWhite);
            else Rabcr.spriteBatch.Draw(Texture, pos, rec, ColorWhite);
        }

        public override Block CloneDown() {
            Water w = new Water{
                Texture=Texture,
                Id=Id,
                Position=Position,
                GetMass=GetMass,
                rec=rec,
                Fill=Fill,
                pos=pos
            };
            w.Position.Y+=16;
            return w;
        }
    }
}