using Microsoft.Xna.Framework;

namespace rabcrClient {
    class Energy {
        public int X, Y;
        public byte Direction;

        public Energy(int x, int y, byte direction) {
            X = x;
            Y = y;
            Direction=direction;
        }

        public void Draw() => Rabcr.spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X*16,Y*16,16,16), Color.White);
    }
}