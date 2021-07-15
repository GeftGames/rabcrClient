using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class SettingHeader:SettingItem{
        readonly Text text;

        public SettingHeader(string t) {
            Value=60;
            text=new Text(t,0,0,BitmapFont.bitmapFont18);
        }

        public override void ChangePos(int x, int y) => text.ChangePosition(X,y+30);

        public override void Draw(SpriteBatch spriteBatch) => text.DrawBold(spriteBatch);

        public override void Update() { }
    }
}