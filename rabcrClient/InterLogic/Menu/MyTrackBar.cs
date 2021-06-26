using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rabcrClient {
  //  class MyTrackBar {

  //      public double Value=0.5f;
  //      bool moving=false;
  //      public Texture2D line;
  //      public Texture2D movemer;
  //      const int Size=147+8;

  //      public MyTrackBar(Texture2D newLine, Texture2D newMovemer) {
		//	line=newLine;
  //          movemer=newMovemer;
		//}

		//public bool Draw(SpriteBatch spriteBatch, int X, int Y, MouseState newMouseState, MouseState oldMouseState) {
  //          spriteBatch.Draw(line, new Vector2(X,Y+6),Color.White);

  //          if (newMouseState.LeftButton==ButtonState.Released) {
  //              if (oldMouseState.LeftButton==ButtonState.Released) {
  //                  if (newMouseState.X>X+Value*(Size-16)
  //                      && newMouseState.Y>Y+2
  //                      && newMouseState.X<X+Value*(Size-8)+16
  //                      && newMouseState.Y<Y+32+2) {
  //                          spriteBatch.Draw(movemer, new Vector2(X+(int)(Value*(Size-16)),Y),Color.WhiteSmoke);
  //                      } else {
  //                          spriteBatch.Draw(movemer, new Vector2(X+(int)(Value*(Size-16)),Y),Color.White);
  //                      }
  //                  } else {
  //                      if (newMouseState.X>X+Value*(Size-16)
  //                      && newMouseState.Y>Y+2
  //                      && newMouseState.X<X+Value*(Size-8)+16
  //                      && newMouseState.Y<Y+32+2) {
  //                          spriteBatch.Draw(movemer, new Vector2(X+(int)(Value*(Size-16)),Y),Color.LightGray);
  //                      } else {
  //                          spriteBatch.Draw(movemer, new Vector2(X+(int)(Value*(Size-16)),Y),Color.White);
  //                      }
  //                      moving=false;
  //                  }
  //              } else {
  //                  if (newMouseState.X>X+Value*(Size-16)
  //                  && newMouseState.Y>Y+2
  //                  && newMouseState.X<X+Value*(Size-8)+16
  //                  && newMouseState.Y<Y+32+2) {
  //                      if (oldMouseState.LeftButton==ButtonState.Released) {
  //                          spriteBatch.Draw(movemer, new Vector2(X+(int)(Value*(Size-16)),Y),Color.Gray);
  //                          moving=true;
  //                      } else {
  //                          spriteBatch.Draw(movemer, new Vector2(X+(int)(Value*(Size-16)),Y),Color.DarkGray);
  //                      }
  //                  } else {
  //                      spriteBatch.Draw(movemer, new Vector2(X+(int)(Value*(Size-16)),Y),Color.White);
  //                  }
  //              }

  //          if (moving) {
  //              double value=Value;
  //              Value=(newMouseState.X-8-X)/(float)(Size-16);

  //              if (Value>1) Value=1;
  //              if (Value<0) Value=0;

  //              return true;
  //          }
		//	return false;
  //      }
  //  }
}