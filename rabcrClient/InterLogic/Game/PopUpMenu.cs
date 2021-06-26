using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace rabcrClient {
 //   class PopUpMenu {

	//	Vector2 position;
	//	List<string> members;
	//	public float height,width;
 //       readonly SpriteFont spriteFont;
	//	public bool show;
	//	public string select;
	//	public float hs;
	//	int countStart=0;
	//	MouseState ms,oms;

	//	public PopUpMenu(string[] mem, int h, SpriteFont sf) {
	//		members=mem.ToList();
	//		height=h;
	//		spriteFont=sf;
	//		select=mem[0];
	//		{
	//			string big="";
	//			foreach (string x in members) {
	//				if (sf.MeasureString(x).X>sf.MeasureString(big).X) big=x;
	//				if (hs<sf.MeasureString(x).Y)hs=sf.MeasureString(x).Y;
	//			}
	//			width=sf.MeasureString(big).X+20;
	//			hs+=5;
	//		}
	//	}

	//	public bool Update(Vector2 pos, MouseState newMouseState, MouseState oldMouseState) {
	//		ms=newMouseState;
	//		oms=oldMouseState;
	//		position=pos;

	//		if (show) {
	//			if (newMouseState.LeftButton == ButtonState.Released) {
	//				if (oldMouseState.LeftButton == ButtonState.Pressed) {
	//					show =false;
	//					return false;
	//				}
	//			}

	//			if (newMouseState.ScrollWheelValue<oldMouseState.ScrollWheelValue) {
	//				countStart++;
	//				if (countStart>members.Count-(int)(height/hs))countStart=members.Count-(int)(height/hs);
	//			}
	//			if (newMouseState.ScrollWheelValue>oldMouseState.ScrollWheelValue) {
	//				countStart--;
	//				if (countStart==-1)countStart=0;
	//			}
	//		} else {
	//			if (oldMouseState.LeftButton == ButtonState.Pressed) {
	//				if (newMouseState.LeftButton == ButtonState.Released) {
	//					if (newMouseState.X > position.X) {
	//						if (newMouseState.Y > position.Y) {
	//							if (newMouseState.Y < position.Y + hs) {
	//								if (newMouseState.X<position.X+width) show=true;
	//							}
	//						}
	//					}
	//				}
	//			}
	//		}
	//		return false;
	//	}

	//	public void Draw(SpriteBatch spriteBatch) {
	//		spriteBatch.Draw(Rabcr.Pixel, new Rectangle((int)position.X,(int)position.Y,(int)width,(int)hs), Color.WhiteSmoke);
	//		DrawFrame(spriteBatch,(int)position.X,(int)position.Y,(int)width,(int)hs,1,Color.LightGray);
	//		DrawSpoiler((int)(position.X+width-10),(int)(hs/2-3+position.Y),spriteBatch);
	//		DrawTextShadowMin(spriteBatch,spriteFont,new Vector2(position.X+3,position.Y+3),select);

	//		if (show) {
	//			spriteBatch.Draw(Rabcr.Pixel, new Rectangle((int)position.X,(int)position.Y+(int)hs,(int)width,(int)(height-hs)), Color.WhiteSmoke);
	//			DrawFrame(spriteBatch,(int)position.X,(int)position.Y+(int)hs,(int)width,(int)height-(int)hs,1,Color.LightGray);
	//			int c=0;
	//			foreach (string m in members) {

	//				//if ((c-countStart)*hs>height) break;
	//				if (c-countStart+1>0 && (c-countStart+1)*(int)hs<(int)height) {
	//					if (m==select) spriteBatch.Draw(Rabcr.Pixel, new Rectangle((int)position.X,(int)(position.Y+(c-countStart+1)*hs),(int)width,(int)(hs)), Color.LightGray);
	//					bool drw=false;
	//					if (ms.X>position.X) {
	//						if (ms.Y>position.Y+(c-countStart+1)*hs) {
	//							if (ms.X<position.X+width) {
	//								if (ms.Y<position.Y+(c-countStart+2)*hs) {
	//									if (ms.LeftButton==ButtonState.Pressed && oms.LeftButton==ButtonState.Released)	select = m;
	//									drw=true;
	//								}
	//							}
	//						}
	//					}
	//					if (drw) spriteBatch.Draw(Rabcr.Pixel, new Rectangle((int)position.X,(int)(position.Y+(c-countStart+1)*hs),(int)width,(int)(hs)), Color.LightGray);

	//					spriteBatch.DrawString(spriteFont,m,new Vector2(position.X,position.Y+(c-countStart+1)*hs),Color.Black);
	//				}
	//				c++;
	//			}
	//		}
	//	}

	//	void DrawSpoiler(int x, int y, SpriteBatch sb) {
	//		sb.Draw(Rabcr.Pixel,new Vector2(x,y),     Color.Black);
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+1,y+1), Color.Black);
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+2,y+2), Color.Black);
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+3,y+3), Color.Black);
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+4,y+2), Color.Black);
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+5,y+1), Color.Black);
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+6,y),   Color.Black);
	//		sb.Draw(Rabcr.Pixel,new Vector2(x,y+1),   new Color(0,0,0,128));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+1,y+2), new Color(0,0,0,128));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+2,y+3), new Color(0,0,0,128));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+3,y+4), new Color(0,0,0,64));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+4,y+3), new Color(0,0,0,128));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+4,y+3), new Color(0,0,0,128));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+5,y+2), new Color(0,0,0,128));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+6,y+1), new Color(0,0,0,128));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+1,y),   new Color(0,0,0,128));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+2,y+1), new Color(0,0,0,128));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+3,y+2), new Color(0,0,0,192));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+4,y+1), new Color(0,0,0,128));
	//		sb.Draw(Rabcr.Pixel,new Vector2(x+5,y),   new Color(0,0,0,128));
	//	}

	//	void DrawTextShadowMax(SpriteBatch spriteBatch,SpriteFont newSpriteFont, Vector2 pos, string str) {
	//		spriteBatch.DrawString(newSpriteFont, str, pos, Color.Black);
	//		if (Constants.Shadow) {
	//			spriteBatch.DrawString(newSpriteFont, str, new Vector2(pos.X + 1.5f, pos.Y + 1.5f), Color.Black * 0.25f);
	//			spriteBatch.DrawString(newSpriteFont, str, new Vector2(pos.X + 0.75f, pos.Y + 0.75f), Color.Black * 0.75f);
	//		} else spriteBatch.DrawString(newSpriteFont, str, new Vector2(pos.X + 1, pos.Y + 1), Color.Black * 0.5f);
	//	}

	//	void DrawTextShadowMin(SpriteBatch spriteBatch,SpriteFont newSpriteFont, Vector2 pos, string str) {
	//		spriteBatch.DrawString(newSpriteFont, str, pos, Color.Black);
	//		if (Constants.Shadow) spriteBatch.DrawString(newSpriteFont, str, new Vector2(pos.X + 0.5f, pos.Y + 0.5f), Color.Black * .5f);
	//	}

	//	void DrawFrame(SpriteBatch spriteBatch,int x, int y, int w, int h, int size, Color color) {
	//		spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x + size, y, w - size, size), color);
	//		spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x, y, size, h), color);
	//		spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x + size, y + h - size, w - size - size, size), color);
	//		spriteBatch.Draw(Rabcr.Pixel, new Rectangle(x + w - size, y + size, size, h - size), color);
	//	}
	//}
}