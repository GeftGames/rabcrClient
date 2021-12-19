﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace rabcrClient {
    public class LeavesBlock:Block{

        #region Varibles
        public Vector2 Position;
        public Texture2D Texture;
        public Tree tree;

        Vector2 vecOrigin;
        public Color Color;
        #endregion

        private LeavesBlock() {
           // Color=ColorWhite;
        }

        public LeavesBlock(Texture2D texture, ushort id, Vector2 position) {
            Texture = texture;
            Id = id;
            Position = position;
            Color=ColorWhite;
        }

        public void SetOrigin() {
            vecOrigin=-new Vector2(Position.X-tree.Root.X*16/*+*/-8, Position.Y-tree.Root.Y*16/*-8*/+8/*-16*/);
        }

        public override void Draw() {
            if (tree!=null) Rabcr.spriteBatch.Draw(Texture, Position+vecOrigin, null, Color, tree.angle, vecOrigin, 1f, SpriteEffects.None, 0f);
            else Rabcr.spriteBatch.Draw(Texture, Position, Color);
        }

        public override Block CloneDown() {
            LeavesBlock n = new LeavesBlock {
                Texture=Texture,
                Id=Id,
                Position=Position,
                Color=ColorWhite,
            };
            n.Position.Y+=16;
            return n;
        }
    }
}