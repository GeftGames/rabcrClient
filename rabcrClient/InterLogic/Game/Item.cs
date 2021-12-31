using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class Item {
        public int X, Y;
        public Texture2D Texture;
        public ItemNonInv item;

        public Item() {}

        //public Item(Vector2 i) {
        //    X=(int)i.X/16*16;
        //    Y=(int)i.Y/16*16;
        //}

        public void DrawItem() {
            int W=Texture.Width,H=Texture.Height;

           // if (Count==0) return;
           // if (Count==1){
                if (W==16 && H==16) {
                    int ww=(int)(Global.ItemAnimation*W*0.75f);
                    if (Global.ItemAnimation>=0) Rabcr.spriteBatch.Draw(Texture,new Rectangle(X+(int)((W-ww)/2f),(int)(Y+H*0.25f),ww,(int)(H*0.75f)), Global.ColorWhite);
                    else Rabcr.spriteBatch.Draw(Texture,new Rectangle(X+(int)((W+ww)/2f),(int)(Y+H*0.25f),-ww,(int)(H*0.75f)),null, Color.DarkGray,0,Vector2.Zero,SpriteEffects.FlipHorizontally,0);

                    //if (Global.ItemAnimation>=0) Rabcr.spriteBatch.Draw(Texture,new Rectangle(X+(int)((W-Global.ItemAnimation*W*0.75f)/2f),(int)(Y+H*0.25f),(int)(W*Global.ItemAnimation*0.75f),(int)(H*0.75f)),Color.White);
                    //else Rabcr.spriteBatch.Draw(Texture,new Rectangle(X+(int)((W+Global.ItemAnimation*W*0.75f)/2f),(int)(Y+H*0.25f),-(int)(W*Global.ItemAnimation*0.75f),(int)(H*0.75f)),null, Color.DarkGray,0,Vector2.Zero,SpriteEffects.FlipHorizontally,0);
                } else if (W==32 && H==32) {
                    int ww=(int)(Global.ItemAnimation*W*0.75f*0.5f/**2.66666f*/);
                    int hh=(int)(H*0.5f*0.75f/*2.66666f*/);
                    if (Global.ItemAnimation>=0) Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W-ww)/2f), Y+(16-hh)/*+hh*/,ww, hh), Color.White);
                    else Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W+ww)/2f), Y+(16-hh)/*+hh*/, -ww, hh), null, Color.DarkGray, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                } else {
                    if (Global.ItemAnimation>=0) Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W-Global.ItemAnimation*W)/2f), Y, (int)(W*Global.ItemAnimation), H), Color.White);
                    else Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W+Global.ItemAnimation*W)/2f), Y, -(int)(W*Global.ItemAnimation), H), null, Color.DarkGray, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                }
            //}else{
            //    if (W==16 && H==16) {
            //        if (Global.ItemAnimation>=0) Rabcr.spriteBatch.Draw(Texture,new Rectangle(X+(int)((W-Global.ItemAnimation*W*0.75f)/2f),(int)(Y+H*0.25f),(int)(W*Global.ItemAnimation*0.75f),(int)(H*0.75f)),Color.White);
            //        else Rabcr.spriteBatch.Draw(Texture,new Rectangle(X+(int)((W+Global.ItemAnimation*W*0.75f)/2f),(int)(Y+H*0.25f),-(int)(W*Global.ItemAnimation*0.75f),(int)(H*0.75f)),null, Color.DarkGray,0,Vector2.Zero,SpriteEffects.FlipHorizontally,0);

            //        if (Global.ItemAnimation>=0) Rabcr.spriteBatch.Draw(Texture,new Rectangle(X+(int)((W-Global.ItemAnimation2*W*0.75f)/2f),(int)(Y+H*0.25f)-2,(int)(W*Global.ItemAnimation2*0.75f),(int)(H*0.75f)),Color.White*0.5f);
            //        else Rabcr.spriteBatch.Draw(Texture,new Rectangle(X+(int)((W+Global.ItemAnimation2*W*0.75f)/2f),(int)(Y+H*0.25f),-(int)(W*Global.ItemAnimation2*0.75f),(int)(H*0.75f)),null, Color.DarkGray,0,Vector2.Zero,SpriteEffects.FlipHorizontally,0);
            //    } else if (W==32 && H==32) {
            //        if (Global.ItemAnimation>=0) Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W-Global.ItemAnimation*W*2.66666f)/2f), (int)(Y+H*2.66666f), (int)(W*Global.ItemAnimation*2.66666f), (int)(H*2.66666f)), Color.White);
            //        else Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W+Global.ItemAnimation*W*2.66666f)/2f), (int)(Y+H*2.66666f), -(int)(W*Global.ItemAnimation*2.66666f), (int)(H*2.66666f)), null, Color.DarkGray, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);

            //        if (Global.ItemAnimation>=0) Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W-Global.ItemAnimation2*W*2.66666f)/2f), (int)(Y+H*2.66666f)-2, (int)(W*Global.ItemAnimation2*2.66666f), (int)(H*2.66666f)), Color.White*0.5f);
            //        else Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W+Global.ItemAnimation2*W*2.66666f)/2f), (int)(Y+H*2.66666f), -(int)(W*Global.ItemAnimation*2.66666f), (int)(H*2.66666f)), null, Color.DarkGray*0.5f, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            //    } else {
            //        if (Global.ItemAnimation>=0) Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W-Global.ItemAnimation*W)/2f), Y, (int)(W*Global.ItemAnimation), H), Color.White);
            //        else Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W+Global.ItemAnimation*W)/2f), Y, -(int)(W*Global.ItemAnimation), H), null, Color.DarkGray, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);

            //        if (Global.ItemAnimation>=0) Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W-Global.ItemAnimation2*W)/2f), Y-2, (int)(W*Global.ItemAnimation2), H), Color.White*0.5f);
            //        else Rabcr.spriteBatch.Draw(Texture, new Rectangle(X+(int)((W+Global.ItemAnimation2*W)/2f), Y, -(int)(W*Global.ItemAnimation2), H), null, Color.DarkGray*0.5f, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            //    }
            //}
        }


        //public List<byte> SaveBytes(){
        //    List<byte> bytes=item.SaveBytes();
        //    bytes.AddRange(BitConverter.GetBytes(X));
        //    bytes.AddRange(BitConverter.GetBytes(Y));
        //    return bytes;
        //}
    }
}