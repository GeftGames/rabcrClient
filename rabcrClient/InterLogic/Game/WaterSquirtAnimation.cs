//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;

//namespace rabcrClient {
//    class WaterSquirtAnimation {
//        readonly Texture2D Texture;
//        Vector2 Vector;
//        int Frame;

//        public WaterSquirtAnimation(Vector2 vector, Texture2D texture) {
//            Vector = vector;
//            Texture = texture;
//            Frame = 0;
//        }
//        public void Draw() {
//            Rabcr.spriteBatch.Draw(Texture, Vector, new Rectangle(Frame*16, 0, 16, 16), Color.White);
//            Frame++;
//        }
//        public bool Destroy() {
//            if (Frame > 18) return true;
//            return false;
//        }
//    }
//}