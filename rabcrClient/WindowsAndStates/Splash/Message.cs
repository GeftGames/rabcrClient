using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace rabcrClient {
    class Message: Game {

        #region Varibles
        readonly GraphicsDeviceManager graphics;
        MouseState newMouseState, oldMouseState;
        SpriteBatch spriteBatch;

        GeDo gedo;
        readonly string _txt;
        GameButtonMedium ok;
        readonly Effect  effectColorize;
        #endregion

        public Message(string Error) {
            Constants.AnimationsControls=true;
            if (Error=="") {
               if (Environment.GetCommandLineArgs().Length>2)  _txt=Environment.GetCommandLineArgs()[2].Replace("\r\n","<NewLine>")+"<NewLine>";
               else _txt="";
            }
            else {
                _txt=Error;
            }
            Rabcr.Game=this;
            graphics = Rabcr.GraphicsManager=  new GraphicsDeviceManager(this);

            Content.RootDirectory = "RabcrData";
            IsMouseVisible = true;
            Window.Title = "Zpráva";

            Rabcr.GraphicsManager.ApplyChanges();

            BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_latin_18);
            effectColorize=Content.Load<Effect>("Default/Effects/Colorize");

            oldMouseState=new MouseState();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Rabcr.random=new FastRandom();
            Rabcr.ActiveWindow=IsActive;
            (Rabcr.Pixel=new Texture2D(GraphicsDevice, 1, 1)).SetData(new[] { Color.White });

            Textures.ButtonCenter=GetDataTexture(@"Buttons\Menu\Center");

            gedo=new GeDo(5, 5);
            gedo.changeHeight+=ChangeH;
            gedo.width=graphics.PreferredBackBufferWidth-10-20;
            #if !DEBUG
            try{
            #endif
            gedo.BuildString(_txt.Replace("<NewLine>","\r\n"));
            #if !DEBUG
            }catch (Exception ex){

                gedo.BuildString(string.IsNullOrEmpty(ex.Message) ? "Error, nesprávná syntaxe": ex.Message);
            }
            #endif

            ok=new GameButtonMedium(Textures.ButtonCenter) {
                Text="OK"
            };

            graphics.PreferredBackBufferHeight = 50+gedo.GetHeight;
            graphics.PreferredBackBufferWidth = 840;

            ok.Position=new Vector2(245+100, graphics.PreferredBackBufferHeight-50);
            graphics.ApplyChanges();
        }

        private void ChangeH(object sender, EventArgs e) {
            graphics.PreferredBackBufferHeight = 50+gedo.GetHeight;
            graphics.PreferredBackBufferWidth = 840;
          
            ok.Position=new Vector2(245+100, graphics.PreferredBackBufferHeight-50);
            graphics.ApplyChanges();
        }

        protected override void Update(GameTime gameTime) {
         Rabcr.ActiveWindow=IsActive;
            ok.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            Rabcr.newMouseState=newMouseState =Mouse.GetState();
            Rabcr.spriteBatch=spriteBatch;
            MousePos.mouseLeftDown=newMouseState.LeftButton==ButtonState.Pressed;
            MousePos.mouseLeftRelease=newMouseState.LeftButton==ButtonState.Released && oldMouseState.LeftButton==ButtonState.Pressed;
            MousePos.mouseRealPosX=newMouseState.X;
            MousePos.mouseRealPosY=newMouseState.Y;
            graphics.GraphicsDevice.Clear(Color.White);
            effectColorize.CurrentTechnique.Passes[0].Apply();

            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,effectColorize,null);

            gedo.DrawGedo(255, spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin();

            ok.ButtonDraw();
            if (ok.Update()){Exit();  }

            spriteBatch.End();
            oldMouseState=newMouseState;
        }

        Texture2D GetDataTexture(string path) {
            try {
                return Content.Load<Texture2D>(Setting.StyleName+"\\Textures\\"+path);
            } catch {
                Console.WriteLine("Nelze načíst texturu: "+Setting.StyleName+"\\Textures\\"+path+Environment.NewLine);
                Environment.Exit(0);
            }

            return null;
        }
    }
}