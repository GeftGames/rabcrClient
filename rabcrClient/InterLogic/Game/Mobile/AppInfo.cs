using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabcrClient.Mobile {
    class ScreenInfo:DrawingScreen {
          SpriteFont font;

        public override void Init() {
            font=GetDataFont("Medium");
            base.Init();
        }

        public override void Draw(SpriteBatch sb, int X, int Y, int W, int H) {
            sb.DrawString(font,
                "Název: Rab Mobile\r\n"+
               // "Model: Rab Mobile "+ Release.VersionName+"\r\n"+
                "OS: RabOS\r\n"+
                "Výrobce: GeftGames\r\n"+
                "\r\n"+
                "Obrazovka:\r\n"+
                "Šířka: "+W+"px\r\n"+
                "Výška: "+H+"px\r\n"+
                "\r\n"
                ,new Vector2(X+5,Y+5), Color.White);
            base.Draw(sb, X, Y, W, H);
        }
    }
}
