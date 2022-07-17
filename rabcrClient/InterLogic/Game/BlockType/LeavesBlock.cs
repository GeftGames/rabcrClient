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
         //   float len=(float)vecOrigin.Length();
            float sin=(float)Math.Sin(tree.angle);
            float cos=(float)Math.Cos(tree.angle);

            Vector4 rect=new Vector4();
            rect.X=Position.X+vecOrigin.X+cos*(-vecOrigin.X)-sin*(-vecOrigin.Y);
            rect.Y=Position.Y+vecOrigin.Y+sin*(-vecOrigin.X)+cos*(-vecOrigin.Y);
            rect.Z=Position.X+16/*-16*/+vecOrigin.X+16/*-16*/+cos*(-vecOrigin.X-16)-sin*(-vecOrigin.Y-16);
            rect.W=Position.Y+16/*-16*/+vecOrigin.Y+16/*-16*/+sin*(-vecOrigin.X-16)+cos*(-vecOrigin.Y-16);
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