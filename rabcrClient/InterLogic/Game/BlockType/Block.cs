using Microsoft.Xna.Framework;

namespace rabcrClient {
    public abstract class Block{

     //   public static Color ColorWhite=Color.White;

        public ushort Id;

     //   public Block() { }

        public abstract void Draw();

        public abstract Block CloneDown();
    }
}