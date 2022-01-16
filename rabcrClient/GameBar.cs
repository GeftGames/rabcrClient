using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class GameBar {
        public float Value{ 
            get => barValue;
            set { SetBarValue(value); }
        }
        float barValue=-10;
        Texture2D texture;

        Vector2 PosNor, PosGray;
        Rectangle RecNor, RecGray;
        int Pos;

        public GameBar(Texture2D tex, int pos) {  
            texture=tex;
            Pos=pos;
        }

        void SetBarValue(float newBarValue) {
            if ((int)newBarValue!=(int)barValue) {
                int rndValue=(int)newBarValue;
                PosNor = new Vector2(Global.WindowWidth/*-150*/-36-Pos, 8+rndValue);
                PosGray = new Vector2(Global.WindowWidth/*-150*/-36-Pos, 8);

                RecNor = new Rectangle(0, rndValue, 32, 32-rndValue);
                RecGray = new Rectangle(0, 0, 32, rndValue);
            }
            barValue=newBarValue;
   //         if (barValue<0f) barValue=0f;
			//else if (barValue>32f) barValue=32f;
        }

        public void Resize() {
            int rndValue=(int)barValue;
            PosNor = new Vector2(Global.WindowWidth/*-150*/-36-Pos, 8+rndValue);
            PosGray = new Vector2(Global.WindowWidth/*-150*/-36-Pos, 8);

            RecNor = new Rectangle(0, rndValue, 32, 32-rndValue);
            RecGray = new Rectangle(0, 0, 32, rndValue);
        }

        public void Draw() { 
            Rabcr.spriteBatch.Draw(texture, PosGray, RecGray, Color.Gray);
			Rabcr.spriteBatch.Draw(texture, PosNor, RecNor, Color.White);
        }
    }
}
