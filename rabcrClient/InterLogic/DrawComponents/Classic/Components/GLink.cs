using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

//namespace rabcrClient {
    class GLink : Control{

        readonly Timer timer;
        int alpha=0;
        int need=0;
        readonly SolidBrush brushShadow=new SolidBrush(Color.FromArgb(22, 0, 0, 0));

		public GLink() {
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			BackColor=Color.Transparent;
            (timer=new Timer {
                Enabled=true,
                Interval=40
            }).Tick+=Timer_Tick;
          //  Font=new Font(Font.FontFamily,Font.Size,FontStyle.Underline);
		}

        private void Timer_Tick(object sender, EventArgs e) {
            if (IsDisposed)timer.Stop();

            if (need!=alpha) {
                if (need<alpha) {
                    alpha-=4+NativeMethods.Abs(need-alpha)/6;
                    Invalidate();
                }
                if (need>alpha) {
                    alpha+=4+NativeMethods.Abs(need-alpha)/6;
                    Invalidate();
                }
                if (alpha-need<4 && alpha-need>-4) alpha=need;
            }
        }

        //int ToArt(int x) {
        //    if (x>0) return x; else return -x;
        //}

        protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			Refresh();
		}

		protected override void OnLeave(EventArgs e) {
			base.OnLeave(e);
            need=0;
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			base.OnMouseUp(e);
            need=0;
		}

		protected override void OnMouseEnter(EventArgs e) {
			base.OnMouseEnter(e);
			need=125;
		}

		protected override void OnMouseLeave(EventArgs e) {
			base.OnMouseLeave(e);
			need=0;
		}

		protected override void OnMouseDown(MouseEventArgs mevent) {
			base.OnMouseDown(mevent);
			need=175;
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            SizeF s=g.MeasureString(Text,Constants.font14);
            Size=new Size((int)s.Width,(int)s.Height);
			Brush b = new LinearGradientBrush(ClientRectangle, Color.FromArgb(0, alpha, 255), Color.FromArgb(0, alpha, 230), 90);
          //  Font=new Font(Constants.font14.FontFamily,Constants.font14.Size,FontStyle.Underline);
            //g.TextContrast=0;
            //g.TextRenderingHint=System.Drawing.Text.TextRenderingHint.AntiAlias;
            //if (Constants.Shadow) {
            //    g.PixelOffsetMode = PixelOffsetMode.Half;

            //    g.DrawString(Text, Font, brushShadow, new Point(1, 0));
            //    g.DrawString(Text, Font, brushShadow, new Point(0, 1));
            //    g.DrawString(Text, Font, brushShadow, new Point(1, 1));

            //    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //}

            //g.DrawString(Text, Font, b, Point.Empty);


            g.CompositingQuality=CompositingQuality.HighQuality;
            g.InterpolationMode=InterpolationMode.HighQualityBicubic;
            g.SmoothingMode=SmoothingMode.HighQuality;
            g.TextRenderingHint=System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.PixelOffsetMode=PixelOffsetMode.None;
            g.TextContrast=0;


            //if (Constants.Shadow) {
                using (Bitmap img = new Bitmap((int)g.MeasureString(Text, Constants.font14).Width+4, (int)g.MeasureString(Text, Constants.font14).Height+4)){
                    using (Graphics gg = Graphics.FromImage(img)) {
                        gg.CompositingQuality=CompositingQuality.HighQuality;
                        gg.InterpolationMode=InterpolationMode.HighQualityBicubic;
                        gg.SmoothingMode=SmoothingMode.HighQuality;
                        gg.TextContrast=0;
                        gg.PixelOffsetMode=PixelOffsetMode.Half;
                        gg.TextRenderingHint=System.Drawing.Text.TextRenderingHint.AntiAlias;

                        gg.DrawString(Text, Constants.font14, new SolidBrush(Color.Black), new PointF(Constants.TextBlur, Constants.TextBlur));

                        gg.PixelOffsetMode=PixelOffsetMode.HighQuality;
                    }

                    using (Bitmap img2 = new Bitmap(img, new Size((int)(img.Size.Width*Constants.TextBlur), (int)(img.Size.Height*Constants.TextBlur))))
                        g.DrawImage(NativeMethods.SetBitmapOpacity(img2, Constants.TextTransparentry), new RectangleF(0, 0, img.Size.Width, img.Size.Height));
                    g.DrawLine(new Pen(b),2,23,Width,23);
                }
          //  }

            g.DrawString(Text, Constants.font14, b, new Point(0, 0));
        }

        protected override void OnLostFocus(EventArgs e) {
            need=0;
            base.OnLostFocus(e);
        }

        protected override void OnGotFocus(EventArgs e) {
            need=125;
            base.OnGotFocus(e);
        }

        protected override void Dispose(bool disposing) {
        brushShadow?.Dispose();
        if (timer.Enabled)timer.Stop();
        timer?.Dispose();
        base.Dispose(disposing);
    }
	//}
}
