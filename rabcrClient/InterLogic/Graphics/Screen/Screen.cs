using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Media;

namespace rabcrClient {
    public abstract class Screen: IDisposable {
        protected GraphicsDevice Graphics{ get{ return  Game.GraphicsDevice;} }
        protected ContentManager Content;
        protected SpriteBatch spriteBatch;
        protected GraphicsDeviceManager GraphicsManager;
        protected Game Game;
       // public static FastRandom random;
        readonly string fastloadtexturespath;

        protected Screen() {
            Content=Rabcr.content;
            GraphicsManager=Rabcr.GraphicsManager;
            Game=Rabcr.Game;
            spriteBatch=Rabcr.spriteBatch;
         //   random=Rabcr.random;

            fastloadtexturespath=Setting.StyleName+"/Textures/";
        }

        public virtual void Init() { }

        public virtual void Shutdown() { isDisposed=true;}

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(GameTime gameTime) { }

        public virtual void Resize() { }

        public Texture2D GetDataTexture(string path) => Content.Load<Texture2D>(fastloadtexturespath+path);

        public Song GetDataSong(string path) => Content.Load<Song>(Setting.StyleName+"/Songs/"+path);

        public void DrawFrame(int x, int y, int w, int h, int size, Color color) {
            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+size, y, w-size, size), color);
            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x, y, size, h), color);
            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+size, y+h-size, w-size-size, size), color);
            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x+w-size, y+size, size, h-size), color);
        }

        public bool isDisposed;

        public void Dispose() {
            //Dispose(true);
            //GC.SuppressFinalize(this);
        }

        //protected virtual void Dispose(bool disposing){
        //    if (isDisposed) return;
        //    isDisposed = true;
        //    Shutdown();
        //}

        ~Screen() {
            Shutdown();
            }// Dispose(false);
    }
}