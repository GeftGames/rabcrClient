using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    abstract class SettingItem{
        public int Value;
        public int X=20;

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update();

        public abstract void ChangePos(int x, int y);
    }
}