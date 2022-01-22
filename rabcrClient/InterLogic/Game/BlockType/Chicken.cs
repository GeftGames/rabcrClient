using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class Chicken :Mob{

        public byte Frame;
        public bool Eat;

        readonly Texture2D TextureWalk, TextureEat;

        public bool move;
        public byte moveCount;
        public short lastChunkID;
        public bool needToChangeChunk;
        public MoveType moveType;

        public Chicken(byte height, int x, bool dir, Texture2D chTextureWalk, Texture2D chTextureEat) {
            Position=new Vector2(x*16,height*16);
            TextureWalk = chTextureWalk;
            TextureEat = chTextureEat;

            Frame=0;
            Eat=false;
            Dir=dir;
            Id=(ushort)BlockId.Chicken;
        }

        public Chicken(int height, int x, bool dir, Texture2D chTextureWalk, Texture2D chTextureEat) {
            Position=new Vector2(x*16,height*16);
            TextureWalk = chTextureWalk;
            TextureEat = chTextureEat;

            Frame=0;
            Eat=false;
            Dir=dir;
            Id=(ushort)BlockId.Chicken;
        }

        public unsafe override byte[] Save() {
            ushort id=Id;
			byte* mbytes=(byte*)&id;

            return new byte[] {
                mbytes[1],
                mbytes[0],
                Height,
                Dir ? (byte)1 : (byte)0
            };
        }

        public override void Draw() {
            Frame+=8;

            if (Eat) {
                if (Frame>=TextureEat.Width) {
                    Frame=0;
                    Eat=false;
                    if (FastRandom.Int(3)==1)Dir=!Dir;
                }

                if (Dir) Rabcr.spriteBatch.Draw(TextureEat, Position,new Rectangle(Frame/16*16,0,16,16), Color.White);
                else Rabcr.spriteBatch.Draw(TextureEat, Position, new Rectangle(Frame/16*16,0,16,16), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
            } else {
                if (move) {
                    switch (moveType){
                        case MoveType.Walk:
                            moveCount--;
                            if (moveCount==0) {
                                move=false;
                                needToChangeChunk=true;
                            }

                            if (Frame>=TextureWalk.Width) {
                                Frame=0;
                            }

                            if (Dir) Position.X+=0.25f;
                            else Position.X-=0.25f;
                            break;

                        case MoveType.Fall:
                            moveCount--;
                            if (moveCount==0) {
                                move=false;
                                needToChangeChunk=true;
                            }

                            if (Frame>=TextureWalk.Width) {
                                Frame=0;
                            }

                            if (Dir) {Position.X+=0.25f; Position.Y+=0.25f;}
                            else {Position.X-=0.25f; Position.Y+=0.25f;}
                            break;

                        case MoveType.Jump:
                            moveCount--;
                            if (moveCount==0) {
                                move=false;
                                needToChangeChunk=true;
                            }

                            if (Frame>=TextureWalk.Width) {
                                Frame=0;
                            }

                            if (Dir) {Position.X+=0.25f; Position.Y-=0.25f;}
                            else {Position.X-=0.25f; Position.Y-=0.25f;}
                            break;
                    }
                } else {
                    if (Frame>=TextureWalk.Width) {
                        Frame=0;
                        Eat=FastRandom.Int(5)==1;
                        if (FastRandom.Bool_20Percent())Dir=!Dir;
                    }
                }

                if (Dir) Rabcr.spriteBatch.Draw(TextureWalk, Position,new Rectangle(Frame/16*16,0,16,16), Color.White);
                else Rabcr.spriteBatch.Draw(TextureWalk, Position, new Rectangle(Frame/16*16,0,16,16), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
            }
        }
    }
    #if MULTIPLAYER
    class MChicken :MMob{

        public byte Frame;
        public bool Eat;

        readonly Texture2D TextureWalk, TextureEat;

        public bool move;
        public byte moveCount;
       // public short lastChunkID;
        public bool needToChangeChunk;
        public MoveType moveType;

        public MChicken(byte height, int x, bool dir, Texture2D chTextureWalk, Texture2D chTextureEat) {
            Position=new Vector2(x*16,height*16);
            TextureWalk = chTextureWalk;
            TextureEat = chTextureEat;

            Frame=0;
            Eat=false;
            Dir=dir;
            Id=(ushort)BlockId.Chicken;
        }

        public MChicken(int height, int x, bool dir, Texture2D chTextureWalk, Texture2D chTextureEat) {
            Position=new Vector2(x*16,height*16);
            TextureWalk = chTextureWalk;
            TextureEat = chTextureEat;

            Frame=0;
            Eat=false;
            Dir=dir;
            Id=(ushort)BlockId.Chicken;
        }

        public unsafe override byte[] Save() {
            ushort id=Id;
			byte* mbytes=(byte*)&id;

            return new byte[] {
                mbytes[1],
                mbytes[0],
                Height,
                Dir ? (byte)1 : (byte)0
            };
        }

        public override void Draw() {
            Frame+=8;

            if (Eat) {
                if (Frame>=TextureEat.Width) {
                    Frame=0;
                    Eat=false;
                    if (FastRandom.Int(3)==1)Dir=!Dir;
                }

                if (Dir) Rabcr.spriteBatch.Draw(TextureEat, Position,new Rectangle(Frame/16*16,0,16,16), Color.White);
                else Rabcr.spriteBatch.Draw(TextureEat, Position, new Rectangle(Frame/16*16,0,16,16), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
            } else {
                if (move) {
                    switch (moveType){
                        case MoveType.Walk:
                            moveCount--;
                            if (moveCount==0) {
                                move=false;
                                needToChangeChunk=true;
                            }

                            if (Frame>=TextureWalk.Width) {
                                Frame=0;
                            }

                            if (Dir) Position.X+=0.25f;
                            else Position.X-=0.25f;
                            break;

                        case MoveType.Fall:
                            moveCount--;
                            if (moveCount==0) {
                                move=false;
                                needToChangeChunk=true;
                            }

                            if (Frame>=TextureWalk.Width) {
                                Frame=0;
                            }

                            if (Dir) {Position.X+=0.25f; Position.Y+=0.25f;}
                            else {Position.X-=0.25f; Position.Y+=0.25f;}
                            break;

                        case MoveType.Jump:
                            moveCount--;
                            if (moveCount==0) {
                                move=false;
                                needToChangeChunk=true;
                            }

                            if (Frame>=TextureWalk.Width) {
                                Frame=0;
                            }

                            if (Dir) {Position.X+=0.25f; Position.Y-=0.25f;}
                            else {Position.X-=0.25f; Position.Y-=0.25f;}
                            break;
                    }
                } else {
                    if (Frame>=TextureWalk.Width) {
                        Frame=0;
                        Eat=FastRandom.Int(5)==1;
                        if (FastRandom.Bool_20Percent())Dir=!Dir;
                    }
                }

                if (Dir) Rabcr.spriteBatch.Draw(TextureWalk, Position,new Rectangle(Frame/16*16,0,16,16), Color.White);
                else Rabcr.spriteBatch.Draw(TextureWalk, Position, new Rectangle(Frame/16*16,0,16,16), Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
            }
        }
    }
    #endif
}