using Microsoft.Xna.Framework;

namespace rabcrClient {
    class GameDraw {
        static readonly Color color_r0_g0_b0_a100 = new Color(0,0,0,100);

       /* public static void DrawTextShadowMin(int x, int y, int i) {
            string str=i.ToString();

		    Rabcr.spriteBatch.DrawString(Fonts.Small, str, new Vector2(x+0.5f, y+0.5f), color_r0_g0_b0_a100);
            Rabcr.spriteBatch.DrawString(Fonts.Small, str, new Vector2(x, y), Color.Black);
        }*/

         public static void DrawTextShadowMin(int x, int y, string str, Color c) {
            Rabcr.spriteBatch.DrawString(Fonts.Small, str, new Vector2(x+0.5f, y+0.5f), color_r0_g0_b0_a100);
            Rabcr.spriteBatch.DrawString(Fonts.Small, str, new Vector2(x, y), c);
        }
    }
}