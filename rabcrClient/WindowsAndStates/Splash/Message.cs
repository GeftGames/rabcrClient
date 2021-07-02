using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace rabcrClient {
    class Message: Game {

        #region Varibles
        GraphicsDeviceManager graphics;
        MouseState newMouseState, oldMouseState;
      //  SpriteFont spriteFont_small,spriteFont_medium,spriteFont_small_italic;
        SpriteBatch spriteBatch;
       // Texture2D buttonTexture;

        //readonly Color
        //    black5=Color.Black*0.5f,
        //    black25=Color.Black*0.25f;
        GeDo gedo;
        string _txt;
        GameButtonMedium ok;
        #endregion
        Effect  effectColorize;
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
        /* Rabcr.Game.GraphicsDevice= */ /* Rabcr.GraphicsManager =*/graphics = Rabcr.GraphicsManager=  new GraphicsDeviceManager(this);
         //  new GraphicsDeviceManager(this);
          //  GraphicsDevice=

            Content.RootDirectory = "RabcrData";
            IsMouseVisible = true;
            Window.Title = "Zpráva";





             Rabcr.GraphicsManager.ApplyChanges();

     BitmapFont.bitmapFont18=new BitmapFont(18,Properties.Resources.FontInfo_latin_18);
             effectColorize=Content.Load<Effect>("Default/Effects/Colorize");
        //    DInt x= BitmapFont.bitmapFont18.MeasureText(_txt.Replace("<NewLine>","\n"));

            //graphics.PreferredBackBufferHeight = 200;
           // graphics.PreferredBackBufferWidth = x.X+10/*640*/;
          //   Rabcr.GraphicsManager.ApplyChanges();
           //  GC.Collect();
            //GC.WaitForPendingFinalizers();
            oldMouseState=new MouseState();
        }



        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Rabcr.random=new FastRandom();
            Rabcr.ActiveWindow=IsActive;
            (Rabcr.Pixel=new Texture2D(GraphicsDevice, 1, 1)).SetData(new[] { Color.White });

            Textures.ButtonCenter=GetDataTexture(@"Buttons\Menu\Center");
            //Fonts.Small = GetDataFont(@"Small");
            //Fonts.Medium = GetDataFont(@"Medium");
            //Fonts.SmallItalic = GetDataFont(@"SmallItalic");
            //Fonts.Big= GetDataFont(@"Big");
            gedo=new GeDo(/*Fonts.Small,*//*Fonts.SmallItalic,*//*,false*/5,5/*,BitmapFont.bitmapFont18*/);
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

            ok=new GameButtonMedium(Textures.ButtonCenter/*, Fonts.Small, Fonts.Medium*/) {

               // center=true
            };

            ok.Text="OK";

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

        protected override void Initialize() {
			//oldMouseState = Mouse.GetState();
			base.Initialize();
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
        //    GraphicsDevice.Clear(Color.White);
graphics.GraphicsDevice.Clear(Color.White);
            effectColorize.CurrentTechnique.Passes[0].Apply();

            //spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            //Vector2 vec=new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf);

            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,null,null,null,effectColorize,null);
           // graphics.GraphicsDevice.Clear(Color.White);

  gedo.DrawGedo(/*5,5,*/255,spriteBatch);
 spriteBatch.End();

            spriteBatch.Begin();

            ok.ButtonDraw(/*spriteBatch,newMouseState.LeftButton==ButtonState.Pressed,new DInt(newMouseState.X, newMouseState.Y)*/);
            if (ok.Update()){Exit(); /*Environment.Exit(0);*/ }



            //if (newMouseState.X>245 && newMouseState.Y>150 && newMouseState.X<397 && newMouseState.Y<180) {
            //    if (newMouseState.LeftButton==ButtonState.Pressed) {
            //        spriteBatch.Draw(Textures.ButtonCenter, new Vector2(245, 150), Color.LightGray);
            //    } else {
            //        if (oldMouseState.LeftButton==ButtonState.Pressed && IsActive) Environment.Exit(0);
            //        spriteBatch.Draw(Textures.ButtonCenter, new Vector2(245, 150), Color.WhiteSmoke);
            //    }
            //    DrawTextShadowMax(Fonts.Medium, new Vector2(302, 152), "OK");
            //} else {
            //    spriteBatch.Draw(Textures.ButtonCenter, new Vector2(245, 150), Color.White);
            //    DrawTextShadowMin(Fonts.Medium, new Vector2(302, 152), "OK");
            //}
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



        //    SpriteFont GetDataFont(string path) {
        //        try {
        //            return Content.Load<SpriteFont>(Setting.StyleName+"\\Fonts\\"+path);
        //        } catch {
        //            Console.WriteLine("Nelze načíst písmo: "+Setting.StyleName+"\\Fonts\\"+path+Environment.NewLine);
        //Environment.Exit(0);
        //        }

        //        return null;
        //    }

        //void DrawTextShadowMax(SpriteFont newSpriteFont, Vector2 position, string str) {
        //    spriteBatch.DrawString(newSpriteFont, str, position, Color.Black);

        //    spriteBatch.DrawString(newSpriteFont, str, new Vector2(position.X+1.5f, position.Y+1.5f), black25);
        //    spriteBatch.DrawString(newSpriteFont, str, new Vector2(position.X+0.75f, position.Y+0.75f), black25);
        //    spriteBatch.DrawString(newSpriteFont, str, new Vector2(position.X+1, position.Y+1), black25);
        //}

        //void DrawTextShadowMin(SpriteFont newSpriteFont, Vector2 position, string str) {
        //    spriteBatch.DrawString(newSpriteFont, str, position, Color.Black);
        //    spriteBatch.DrawString(newSpriteFont, str, new Vector2(position.X+0.5f, position.Y+0.5f), black5);
        //}
    }
}