//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;

//namespace rabcrClient {
//    class Line {
//       // readonly Texture2D pixel;
//		int Zoom;
//		float angle;
//		Rectangle rectangle;

//		public Vector2 Point1, Point2;
//		public Color color;

//		public Line(Vector2 p1, Vector2 p2, Color c/*, Texture2D pix*/) {
//			Point1 = p1;
//			Point2 = p2;
//			color = c;
//			//pixel=pix;

//			Refresh();
//		}

//		public void Refresh() {
//			rectangle = new Rectangle((int)Point1.X, (int)Point1.Y, (int)(Point2 - Point1).Length()+1, 1);
//			angle = (float)Math.Acos(Vector2.Dot(Vector2.Normalize(Point1 - Point2), -Vector2.UnitX));
//			if (Point1.Y > Point2.Y) angle = MathHelper.TwoPi - angle;
//		}

//		public void Refresh(float zoom) {
//			Zoom=(int)(1/zoom);
//			rectangle = new Rectangle((int)Point1.X, (int)Point1.Y, (int)(Point2 - Point1).Length()+Zoom,Zoom);
//			angle = (float)Math.Acos(Vector2.Dot(Vector2.Normalize(Point1 - Point2), -Vector2.UnitX));
//			if (Point1.Y > Point2.Y) angle = MathHelper.TwoPi - angle;
//		}

//		public void Draw(SpriteBatch spriteBatch) {
//			spriteBatch.Draw(Rabcr.Pixel, rectangle, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
//		}
//	}
//}