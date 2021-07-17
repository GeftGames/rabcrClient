using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class SettingMessage:SettingItem{
        readonly Text text;
        public int centerDelta;
        public SettingMessage(string t) {
            Value=60;
            text=new Text(t,0,0,BitmapFont.bitmapFont18);
        
            centerDelta=(int)(text.MeasureX()/2f);
        }

        public override void ChangePos(int x, int y) {
            text.ChangePosition(X,y);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            text.Draw(spriteBatch);
        }

        public override void Update() { }
    }
}