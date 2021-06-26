using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {

    class GameDraw {
        static readonly Color
            //color_r200_g200_b200_a100= new Color(200,200,200,100),
            //color_r0_g0_b0_a200 = new Color(0,0,0,200),
            //color_r10_g140_b255 = new Color(10,140,255),
            //color_r128_g128_b128= new Color(128,128,128),
            //color_r128_g128_b128_a128= new Color(128,128,128,128),
            //color_r150_g150_b150= new Color(150,150,150),
            color_r0_g0_b0_a100 = new Color(0,0,0,100)//,
            //color_r255_g0_b0_a100 = new Color(255, 0, 0, 100),
            //color_r200_g200_b200=new Color(200, 200, 200),
         //   lampColorLight=new Color(255, 255, 220, 255)
            ;
       // static Vector2 vector_x0_y4;
        // public static void DrawItemInInventory(Texture2D texture, ItemInv inv, int x, int y) {
        //    switch (inv){
        //        case ItemInvTool16 item:
        //            Rabcr.spriteBatch.Draw(texture, new Rectangle(x, y,texture.Width*2,texture.Height*2), Color.White);

        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+1, y+28, 30, 5), Color.Black);
        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2, y+29, (int)(item.GetCount*0.3f), 3), Color.Green);
        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2+(int)(item.GetCount*0.3f), y+29, 28-(int)(item.GetCount*0.3), 3), Color.Red);
        //            return;

        //        case ItemInvTool32 item:
        //            Rabcr.spriteBatch.Draw(texture, new Vector2(x, y), Color.White);

        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+1, y+28, 30, 5), Color.Black);
        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2, y+29, (int)(item.GetCount*0.3f), 3), Color.Green);
        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2+(int)(item.GetCount*0.3f), y+29, 28-(int)(item.GetCount*0.3), 3), Color.Red);
        //            return;

        //        case ItemInvBasic16 item:
        //            Rabcr.spriteBatch.Draw(texture, new Rectangle(x, y,texture.Width*2,texture.Height*2), Color.White);
        //            return;

        //        case ItemInvBasic32 item:
        //            Rabcr.spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        //            return;
        //    }

        //    //if (texture.Width==16 && texture.Height==16) Rabcr.spriteBatch.Draw(texture, new Rectangle(x, y,texture.Width*2,texture.Height*2), Color.White);
        //    //else if (texture.Width==32 && texture.Height==32) Rabcr.spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        //    //else Rabcr.spriteBatch.Draw(texture, new Rectangle(x+(16-texture.Width), y+(16-texture.Height),texture.Width*2,texture.Height*2), Color.White);

        //    //if (inv.X<(short)Items._SystemMaxTools){
        //    //    Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+1, y+28, 30, 5), Color.Black);
        //    //    Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2, y+29, (int)(inv.Y*0.3f), 3), Color.Green);
        //    //    Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2+(int)(inv.Y*0.3f), y+29, 28-(int)(inv.Y*0.3), 3), Color.Red);
        //    //}else if (inv.Y!=1) DrawTextShadowMin(x, y+20,inv.Y/*.ToString()*/);
        //}

        //public static void DrawItemInInventory(Texture2D texture, ItemNonInv inv, int x, int y) {
        //    switch (inv){
        //        case ItemNonInvTool item:
        //            Rabcr.spriteBatch.Draw(texture, new Rectangle(x, y,texture.Width*2,texture.Height*2), Color.White);

        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+1, y+28, 30, 5), Color.Black);
        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2, y+29, (int)(item.Count*0.3f), 3), Color.Green);
        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2+(int)(item.Count*0.3f), y+29, 28-(int)(item.Count*0.3), 3), Color.Red);
        //            return;

        //        case ItemNonInvBasicColoritzedNonStackable item:
        //            Rabcr.spriteBatch.Draw(texture, new Vector2(x, y), item.color);
        //            return;

        //        case ItemNonInvBasic item:
        //            Rabcr.spriteBatch.Draw(texture, new Rectangle(x, y,texture.Width*2,texture.Height*2), Color.White);
        //            return;

        //        case ItemNonInvNonStackable item:
        //            Rabcr.spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        //            return;

        //        case ItemNonInvFood item:
        //            Rabcr.spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+1, y+28, 30, 5), Color.Black);
        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2, y+29, (int)(item.Count*0.3f), 3), new Color(item.Descay/item.DescayMaximum,1-item.Descay/item.DescayMaximum,0));
        //            Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2+(int)(item.Count*0.3f), y+29, 28-(int)(item.Count*0.3), 3), Color.White);
        //            return;
        //    }

        //    //if (texture.Width==16 && texture.Height==16) Rabcr.spriteBatch.Draw(texture, new Rectangle(x, y,texture.Width*2,texture.Height*2), Color.White);
        //    //else if (texture.Width==32 && texture.Height==32) Rabcr.spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        //    //else Rabcr.spriteBatch.Draw(texture, new Rectangle(x+(16-texture.Width), y+(16-texture.Height),texture.Width*2,texture.Height*2), Color.White);

        //    //if (inv.X<(short)Items._SystemMaxTools){
        //    //    Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+1, y+28, 30, 5), Color.Black);
        //    //    Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2, y+29, (int)(inv.Y*0.3f), 3), Color.Green);
        //    //    Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2+(int)(inv.Y*0.3f), y+29, 28-(int)(inv.Y*0.3), 3), Color.Red);
        //    //}else if (inv.Y!=1) DrawTextShadowMin(x, y+20,inv.Y/*.ToString()*/);
        //}

        //public static void DrawItemInInventory(Texture2D texture, int invX, int invY, int x, int y) {

        //    if (texture.Width==16 && texture.Height==16) Rabcr.spriteBatch.Draw(texture, new Rectangle(x, y,texture.Width*2,texture.Height*2), Color.White);
        //    else if (texture.Width==32 && texture.Height==32) Rabcr.spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        //    else Rabcr.spriteBatch.Draw(texture, new Rectangle(x+(16-texture.Width), y+(16-texture.Height),texture.Width*2,texture.Height*2), Color.White);

        //    if (invX<(short)Items._SystemMaxTools){
        //        int invYY=(int)(invY*0.3f);
        //        Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+1, y+28, 30, 5), Color.Black);
        //        Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2, y+29, invYY/*(int)(invY*0.3f)*/, 3), Color.Green);
        //        Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+2+invYY/*(int)(invY*0.3f)*/, y+29, 28-invYY/*(int)(invY*0.3)*/, 3), Color.Red);
        //    }else if (invY!=1) DrawTextShadowMin(x, y+20,invY/*.ToString()*/);
        //}

        //public static void DrawItemInInventory(Texture2D texture, int count, int x, int y) {
        //    if (texture.Width==16 && texture.Height==16) Rabcr.spriteBatch.Draw(texture, new Rectangle(x, y, 32, 32), Color.White);
        //    else if (texture.Width==32 && texture.Height==32) Rabcr.spriteBatch.Draw(texture, new Vector2(x, y), Color.White);
        //    else Rabcr.spriteBatch.Draw(texture, new Rectangle(x+16-texture.Width, y+16-texture.Height, texture.Width*2, texture.Height*2), Color.White);

        //    if (count!=1) DrawTextShadowMin(x, y+20, count/*.ToString()*/);
        //}

        public static void DrawTextShadowMin(int x, int y, int i) {
            string str=i.ToString();
            //if (Setting.BetterFont) {
            //    if (Constants.Shadow)Rabcr.spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x+0.5f, y+0.5f), color_r0_g0_b0_a100, 0, vector_x0_y4, Global.ScaleMediumToSmall, SpriteEffects.None, 0);
            //    Rabcr.spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x, y), Color.Black, 0, vector_x0_y4, Global.ScaleMediumToSmall, SpriteEffects.None, 0);
            //} else {
		       /* if (Constants.Shadow)*/Rabcr.spriteBatch.DrawString(Fonts.Small, str, new Vector2(x+0.5f, y+0.5f), color_r0_g0_b0_a100);
                Rabcr.spriteBatch.DrawString(Fonts.Small, str, new Vector2(x,y), Color.Black);
            //}
        }

         public static void DrawTextShadowMin(int x, int y, string str, Color c) {

            //if (Setting.BetterFont) {
            //    if (Constants.Shadow)Rabcr.spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x+0.5f, y+0.5f), color_r0_g0_b0_a100, 0, vector_x0_y4, Global.ScaleMediumToSmall, SpriteEffects.None, 0);
            //    Rabcr.spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x, y), Color.Black, 0, vector_x0_y4, Global.ScaleMediumToSmall, SpriteEffects.None, 0);
            //} else {
		        /*if (Constants.Shadow)*/Rabcr.spriteBatch.DrawString(Fonts.Small, str, new Vector2(x+0.5f, y+0.5f), color_r0_g0_b0_a100);
                Rabcr.spriteBatch.DrawString(Fonts.Small, str, new Vector2(x,y), c);
            //}
        }

        //public static void DrawTextShadowMin(int x, int y, string str, Color c) {
        //    if (Setting.BetterFont) {
        //        if (Constants.Shadow) Rabcr.spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x+0.5f, y+0.5f), color_r128_g128_b128_a128*(c.A/255f), 0, vector_x0_y4, Global.ScaleMediumToSmall, SpriteEffects.None,0);
        //        Rabcr.spriteBatch.DrawString(Fonts.Medium, str, new Vector2(x, y), c, 0, vector_x0_y4, Global.ScaleMediumToSmall, SpriteEffects.None, 0);
        //    } else {
        //        if (Constants.Shadow) Rabcr.spriteBatch.DrawString(Fonts.Small, str, new Vector2(x+0.5f, y+0.5f), color_r128_g128_b128_a128*(c.A/255f));
        //        Rabcr.spriteBatch.DrawString(Fonts.Small, str, new Vector2(x, y), c);
        //    }
        //}
    }
}
