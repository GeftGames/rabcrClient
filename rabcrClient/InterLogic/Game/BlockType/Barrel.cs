using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient {
    class Barrel:Block{
        public ItemInv[] Inv;
        public int LiquidAmount;
        public const int LiquidAmountMax=255;
        public byte LiquidId;

        public Vector2 Position;
        public Texture2D Texture;

      //  public DateTime SealTimeTo;
     //   public bool Sealing;

      //  public ReceipeSeal receipe;

        public Barrel(Texture2D texture, ushort id, Vector2 position) {
            Texture = texture;
            Position=position;
            Id=id;
            Inv=new ItemInv[2];
        }

        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, Global.ColorWhite);

        public override Block CloneDown() => new Barrel(Texture, Id, new Vector2(Position.X, Position.Y));
            //s.Position.Y+=16;
           // return s;
       // }
    }
}