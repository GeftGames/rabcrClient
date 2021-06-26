using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient.Mobile {
    class ScreenNotes:DrawingScreen {
         SpriteFont font;

        public override void Init() {
            font=GetDataFont("Medium");
            base.Init();
        }

        public override void Draw(SpriteBatch sb, int X, int Y, int W, int H) {
            sb.DrawString(font,
                "<WikiItems>\r\n"+
                "? Experimentální item\r\n"+
                "je takový item, který možná\r\n"+
                "bude v příští verzi přidán\r\n"+
                "nebo bude odstraněn.\r\n"+
                "V této verzi nemusí\r\n"+
                "zcela plně fungovat.\r\n"
                ,new Vector2(X+5,Y+5), Color.White);
            base.Draw(sb, X, Y, W, H);
        }
    }
}
