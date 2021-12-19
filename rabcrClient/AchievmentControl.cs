using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace rabcr {
	class AchievmentControl : Control{

		//const int SizeBounds=20;
		//int textX, textY;
		public bool Done;
        readonly Timer timer;
        int alpha=200;
        int need=255;
        Image image;

		enum State :byte{
			None,
			Enter,
			Click
		}
		State currentState;

		public AchievmentControl() {
			//textX=5;
			//textY=5;

			currentState =State.None;
            //currentOrientation=Orientation.Center;
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			BackColor=Color.Transparent;
            timer=new Timer();
            timer.Enabled=true;
            timer.Interval=35;
            timer.Tick+=Timer_Tick;
		}

        private void Timer_Tick(object sender, EventArgs e) {
            if (need!=alpha) {
                if (need<alpha) {
                    alpha-=1+ToArt(need-alpha)/6;
                    Invalidate();
                }
                if (need>alpha) {
                    alpha+=1+ToArt(need-alpha)/6;
                    Invalidate();
                }
                if (alpha-need<4 && alpha-need>-4) alpha=need;
            }
        }

        int ToArt(int x) {
            if (x>0) return x; else return -x;
        }

        public Image Image {
			get { return image; }
			set { image = value; Invalidate(); }
		}

        //public bool Done {
        //    get { return disamble; }
        //    set { disamble = value; Invalidate(); }
        //}

        protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			//textX=Size.Width/2;
			//textY=Size.Height/2;
			Refresh();
		}

		protected override void OnLeave(EventArgs e) {
			base.OnLeave(e);
			currentState=State.None;
            need=255;
			Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			base.OnMouseUp(e);
			if (currentState!=State.Enter) {
				currentState = State.Enter;
                need=190;
				Invalidate();
			}
		}

		protected override void OnMouseEnter(EventArgs e) {
			base.OnMouseEnter(e);
			if (currentState!=State.Enter) {
				currentState = State.Enter;
                need=190;
				Invalidate();
			}
		}

		protected override void OnMouseLeave(EventArgs e) {
			base.OnMouseLeave(e);
			if (currentState!=State.None) {
				currentState = State.None;
                need=255;
				Invalidate();
			}
		}

		protected override void OnMouseDown(MouseEventArgs mevent) {
			base.OnMouseDown(mevent);
			if (currentState!=State.Click) {
				currentState = State.Click;
                need=150;
				Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
           // Size buttonSize=new Size(Size.Width-3,Size.Height-3);
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
			//g.SmoothingMode = SmoothingMode.None;
            Font=new Font(Font.FontFamily,14);
            Size =new Size(Size.Width,64);

			Brush b = new LinearGradientBrush(ClientRectangle, Color.FromArgb((int)alpha,(int)alpha,(int)alpha), Color.FromArgb((int)alpha-40,(int)alpha-40,(int)alpha-40), 90);

          //    Pen sb = new Pen(new SolidBrush(Color.Black));

            //Back
            g.DrawRectangle(new Pen(new LinearGradientBrush(ClientRectangle, Color.FromArgb(100,(int)alpha,(int)alpha,(int)alpha), Color.FromArgb(100,(int)alpha-40,(int)alpha-40,(int)alpha-40), 90)),new Rectangle(0, 0, Size.Width-1, Size.Height-1));
			g.DrawRectangle(new Pen(new LinearGradientBrush(ClientRectangle, Color.FromArgb(200,(int)alpha,(int)alpha,(int)alpha), Color.FromArgb(200,(int)alpha-40,(int)alpha-40,(int)alpha-40), 90)),new Rectangle(1, 1, Size.Width-3, Size.Height-3));
			g.FillRectangle(b,new Rectangle(2, 2, Size.Width-4, Size.Height-4));
            g.InterpolationMode=InterpolationMode.NearestNeighbor;

            if (Image!=null)g.DrawImage(image, 0,0,64,64);
            if (Done) {
                g.DrawImage(rabcrClient.Properties.Resources.Done,new Point(Width-60,6));
            }
           g.InterpolationMode=InterpolationMode.HighQualityBicubic;

            g.TextContrast=0;
            g.TextRenderingHint=System.Drawing.Text.TextRenderingHint.AntiAlias;
           // if (Setting.TextShadow) {
                g.PixelOffsetMode = PixelOffsetMode.Half;
                //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(50, 0, 0, 0)), new Point(textX + 1 - (int)(g.MeasureString(Text, Font).Width / 2), textY + 1 - (int)(g.MeasureString(Text, Font).Height / 2)));
                //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(50, 0, 0, 0)), new Point(textX + 1 - (int)(g.MeasureString(Text, Font).Width / 2), textY - (int)(g.MeasureString(Text, Font).Height / 2)));
                //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(50, 0, 0, 0)), new Point(textX - (int)(g.MeasureString(Text, Font).Width / 2), textY + 1 - (int)(g.MeasureString(Text, Font).Height / 2)));

                    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(30, 0, 0, 0)), new Point(70+1, 32 - (int)(g.MeasureString(Text, Font).Height / 2)+0));
                    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(30, 0, 0, 0)), new Point(70+0, 32 - (int)(g.MeasureString(Text, Font).Height / 2)+1));
                    g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(30, 0, 0, 0)), new Point(70+1, 32 - (int)(g.MeasureString(Text, Font).Height / 2)+1));

                    //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(40, 0, 0, 0)), new Point(textX - (int)(g.MeasureString(Text, Font).Width / 2)+2, textY - (int)(g.MeasureString(Text, Font).Height / 2)+0));
                    //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(40, 0, 0, 0)), new Point(textX - (int)(g.MeasureString(Text, Font).Width / 2)+0, textY - (int)(g.MeasureString(Text, Font).Height / 2)+2));

                    //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(30, 0, 0, 0)), new Point(textX - (int)(g.MeasureString(Text, Font).Width / 2)+2, textY - (int)(g.MeasureString(Text, Font).Height / 2)+1));
                    //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(30, 0, 0, 0)), new Point(textX - (int)(g.MeasureString(Text, Font).Width / 2)+1, textY - (int)(g.MeasureString(Text, Font).Height / 2)+2));

                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
          //}
  //Draw.Text(g, Font, Text, textX + 1 - (int)(g.MeasureString(Text, Font).Width / 2), textY + 1 - (int)(g.MeasureString(Text, Font).Height / 2));
            //Draw.TextBig(g,Text, (int)((buttonSize.Width - g.MeasureString(Text, Font).Width)/2), (int)((buttonSize.Height - g.MeasureString(Text, Font).Height) / 2));

                g.DrawString(Text, Font, new SolidBrush(Color.Black), new Point(70, 32 - (int)(g.MeasureString(Text, Font).Height / 2)));
            //ds.DrawText(g, textX - (int)(g.MeasureString(Text, Font).Width / 2), textY - (int)(g.MeasureString(Text, Font).Height / 2), new SolidBrush(Color.Gray));
            //else ds.DrawText(g, textX - (int)(g.MeasureString(Text, Font).Width / 2), textY - (int)(g.MeasureString(Text, Font).Height / 2), new SolidBrush(Color.Black));
        }

        public static Bitmap SetBitmapOpacity(Bitmap image, float opacity) {
            //create a Bitmap the size of the image provided
            Bitmap bmp = new Bitmap(image.Width, image.Height);

            //create a graphics object from the image
            using (Graphics gfx = Graphics.FromImage(bmp)) {

                //create a color matrix object
                ColorMatrix matrix = new ColorMatrix();

                //set the opacity
                matrix.Matrix33 = opacity;
                matrix.Matrix00=-1;
                matrix.Matrix11 = matrix.Matrix22 = -1;

                //create image attributes
                ImageAttributes attributes = new ImageAttributes();

                //set the color(opacity) of the image
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                //now draw the image
                gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }
	}
}
