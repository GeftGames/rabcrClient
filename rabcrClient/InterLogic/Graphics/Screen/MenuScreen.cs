using Microsoft.Xna.Framework;

namespace rabcrClient {
    public class MenuScreen: Screen {

        readonly Color color_0_0_0_64=Color.Black*0.25f;

        public MenuScreen() { }

        public virtual void Draw(GameTime gameTime, float f) { }

        public virtual void PreDraw() { }

        public void DrawTextShadowMinSmall(int x, int y, string str) {
            /*if (Constants.Shadow)*/ spriteBatch.DrawString(Fonts.Small, str, new Vector2(x+0.5f, y+0.5f), color_0_0_0_64);
            spriteBatch.DrawString(Fonts.Small, str, new Vector2(x, y), Color.Black);
        }

        public void DrawTextShadowMinSmall(int x, int y, string str, float a) {
            /*if (Constants.Shadow) */spriteBatch.DrawString(Fonts.Small, str, new Vector2(x+0.5f, y+0.5f), color_0_0_0_64*a);
            spriteBatch.DrawString(Fonts.Small, str, new Vector2(x, y), Color.Black*a);
        }

        public void DrawTextShadowMinSmall(int x, int y, string str, Color c) {
            /*if (Constants.Shadow)*/ spriteBatch.DrawString(Fonts.Small, str, new Vector2(x+0.5f, y+0.5f), c*0.5f);
            spriteBatch.DrawString(Fonts.Small, str, new Vector2(x, y), c);
        }
    }
}