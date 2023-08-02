using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace rabcrClient {
    public class LeavesBlock:Block{

        #region Varibles
        public Vector2 Position;
        public Texture2D Texture;
        public Tree tree;

        Vector2 vecOrigin;

        public Vector4 GetRealSquare(){
            //float rotX=-vecOrigin.X;
            //float rotY=-vecOrigin.Y;

            //float rotX2=-(vecOrigin.X)+16;
            //float rotY2=-(vecOrigin.Y)+16;

            //float len=(float)vecOrigin.Length();
            //float sin=(float)Math.Sin(tree.angle);
            //float cos=(float)Math.Cos(tree.angle);

            float posX=Position.X+vecOrigin.X;
            float posY=Position.Y+vecOrigin.Y;
            
            //float posX2=Position.X+vecOrigin.X+16;
            //float posY2=Position.Y+vecOrigin.Y+16;
           
            //Vector4 rect = new() {
            //    X=posX    + rotX*cos   - sin*rotY,
            //    Y=posY    + rotY*cos   + sin*rotX,
            //    Z=posX2   + rotX2*cos  - sin*rotY2,
            //    W=posY2   + rotY2*cos  + sin*rotX2,
            //};
            Vector2 toPoint=-vecOrigin;//new(rotX, rotY);
            Vector2 toPoint2=new(-(vecOrigin.X)+16/*rotX2*/, -(vecOrigin.Y)+16/*rotY2*/);

            var m = Matrix.CreateRotationZ(tree.angle);
            Vector2 p1 = Vector2.Transform(toPoint, m);
            Vector2 p2 = Vector2.Transform(toPoint2, m);

            Vector4 rect = new() {
                X = posX+p1.X,
                Y = posY+p1.Y,
                Z = posX+p2.X,
                W = posY+p2.Y
            };
            //Vector4 rect = new() {
            //    X=Position.X+vecOrigin.X+cos*(-vecOrigin.X)-sin*(-vecOrigin.Y),
            //    Y=Position.Y+vecOrigin.Y+sin*(-vecOrigin.X)+cos*(-vecOrigin.Y),
            //    Z=Position.X+16/*-16*/+vecOrigin.X+16/*-16*/+cos*(-vecOrigin.X-16)-sin*(-vecOrigin.Y-16),
            //    W=Position.Y+16/*-16*/+vecOrigin.Y+16/*-16*/+sin*(-vecOrigin.X-16)+cos*(-vecOrigin.Y-16)
            //};
            return rect;
        }

        // Autumn color
        public Color Color;
        #endregion

        private LeavesBlock() { }

        public LeavesBlock(Texture2D texture, ushort id, Vector2 position) {
            Texture = texture;
            Id = id;
            Position = position;
            Color=Global.ColorWhite;
        }

        public void SetOrigin() {
            vecOrigin=-new Vector2(Position.X-tree.Root.X*16/*+*/-8, Position.Y-tree.Root.Y*16/*-8*/+8/*-16*/);
        }

        public override void Draw() {
            if (tree!=null) Rabcr.spriteBatch.Draw(Texture, Position+vecOrigin, null, Color, tree.angle, vecOrigin, 1f, SpriteEffects.None, 0f);
            else Rabcr.spriteBatch.Draw(Texture, Position, Color);
        }

        public override Block CloneDown() => new LeavesBlock() {
                Texture=Texture,
                Id=Id,
                Position=new Vector2(Position.X,Position.Y+16),
                Color=Global.ColorWhite,
            };
        //    n.Position.Y+=16;
        //    return n;
      //  }
    }
}