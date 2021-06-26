using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

//namespace rabcrClient {
    public partial class GChangeButton : Control {

		int textX, textY;
		bool disamble=false;
        readonly Timer timer;
        int alpha=200;
        int need=255;
        string[] list;
        public int selected;
        State currentState;
        Size buttonSize;

        bool flyText=false;
        bool directionLeft=false;const int SizeBounds=20;
        int timing=0;
        string oldtext;

    enum State :byte{
			None,
			Enter,
			Click
		}

		public GChangeButton() {
			textX=5;
			textY=5;
            selected=0;
			currentState =State.None;
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			BackColor=Color.Transparent;

            (timer=new Timer {
                Enabled=true,
                Interval=35
            }).Tick+=Timer_Tick;

            Size =new Size(Size.Width,35);
            buttonSize=new Size(Size.Width-3,Size.Height-3);
		}

        private void Timer_Tick(object sender, EventArgs e) {
        if (this.IsDisposed)timer.Stop();

            if (need!=alpha) {
                if (need<alpha) {
                    alpha-=1+NativeMethods.Abs(need-alpha)/6;
                    Invalidate();
                }
                if (need>alpha) {
                    alpha+=1+NativeMethods.Abs(need-alpha)/6;
                    Invalidate();
                }
                if (alpha-need<4 && alpha-need>-4) alpha=need;
            }

            if (flyText){
            timing--;
            if (timing<0){
                flyText=false;
                timing=0;

                }
            }  Invalidate();
        }

        public bool Disamble {
            get { return disamble; }
            set { disamble = value; Invalidate(); }
        }

        public string[] List {
            get { return list; }
            set { list = value; Invalidate(); }
        }

        public int Selected {
            get { return selected; }
            set { selected = value;
            if (selected>list.Length)selected=0; Invalidate(); }
        }

        protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			textX=Size.Width/2;
			textY=Size.Height/2;
            buttonSize=new Size(Size.Width-3,Size.Height-3);
            Invalidate();
		}

		protected override void OnLeave(EventArgs e) {
			base.OnLeave(e);
			currentState=State.None;
            need=255;
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			base.OnMouseUp(e);
			if (currentState!=State.Enter) {
				currentState = State.Enter;
                need=190;
			}
		}

		protected override void OnMouseEnter(EventArgs e) {
			base.OnMouseEnter(e);
			if (currentState!=State.Enter) {
				currentState = State.Enter;
                need=190;
			}
		}

		protected override void OnMouseLeave(EventArgs e) {
			base.OnMouseLeave(e);
			if (currentState!=State.None) {
				currentState = State.None;
                need=255;
			}
		}

		protected override void OnMouseDown(MouseEventArgs e) {
			base.OnMouseDown(e);
			if (currentState!=State.Click) {
				currentState = State.Click;
                need=150;

                if (e.X<Width/2){
                    if (Constants.AnimationsControls){
                        flyText=true;
                        directionLeft=true;
                        oldtext=list[selected];
                        timing=10;
                    }
                    Selected--;
                    if (selected==-1) selected=list.Length-1;
                } else {
                    if (Constants.AnimationsControls){
                        flyText=true;
                        directionLeft=false;
                        oldtext=list[selected];
                        timing=10;
                    }
                    Selected++;
                    if (selected==list.Length)selected=0;
                }
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
			Pen sb;
			Brush b;

            if (disamble) {
                sb = new Pen(new SolidBrush(Color.DarkGray));
                b= new LinearGradientBrush(ClientRectangle, Color.FromArgb(alpha-20, alpha-20, alpha-20), Color.FromArgb(alpha-40-20, alpha-40-20, alpha-40-20), 90);
            } else {
                b= new LinearGradientBrush(ClientRectangle, Color.FromArgb(alpha, alpha, alpha), Color.FromArgb(alpha-40, alpha-40, alpha-40), 90);
                sb = new Pen(new SolidBrush(Color.Black));
            }
            SizeF textsize=g.MeasureString(list[selected], Constants.font14);
            Point pos=new Point(
                textX - (int)(textsize.Width /2f),
                textY - (int)(textsize.Height/2f)
            );

            using (Bitmap nb=new Bitmap(buttonSize.Width,buttonSize.Height)) {
                using (Graphics g2 = Graphics.FromImage(nb)) {
                    g2.PixelOffsetMode=PixelOffsetMode.None;
                    g2.InterpolationMode=InterpolationMode.HighQualityBicubic;
                    g2.SmoothingMode=SmoothingMode.HighQuality;

                    //Inside
                    int SizeBounds3=SizeBounds/3;
                    int SizeBounds6=SizeBounds/6;
                    int SizeBounds2=SizeBounds/2;
                    g2.FillEllipse(b, new Rectangle(buttonSize.Width-SizeBounds3-1, 0, SizeBounds3, SizeBounds3));
                    g2.FillEllipse(b, new Rectangle(buttonSize.Width-SizeBounds3-1, buttonSize.Height - SizeBounds3 - 1, SizeBounds3, SizeBounds3));
                    g2.FillRectangle(b, buttonSize.Width-SizeBounds3-1, SizeBounds6, SizeBounds2, buttonSize.Height-SizeBounds3);

                    g2.FillEllipse(b, new Rectangle(0, 0, SizeBounds3, SizeBounds3));
                    g2.FillEllipse(b, new Rectangle(0, buttonSize.Height - SizeBounds3 - 1, SizeBounds3, SizeBounds3));
                    g2.FillRectangle(b, 0, SizeBounds6, SizeBounds2, buttonSize.Height-SizeBounds3);


                    g2.FillRectangle(b, SizeBounds6, 0, buttonSize.Width-SizeBounds3, buttonSize.Height-1);

                    // Bounds
                    g2.DrawLine(sb, SizeBounds6, 0, buttonSize.Width-SizeBounds6, 0);
				    g2.DrawLine(sb, buttonSize.Width - 1, SizeBounds6, buttonSize.Width -1, buttonSize.Height-SizeBounds6);
				    g2.DrawLine(sb, SizeBounds6, buttonSize.Height - 1, buttonSize.Width-SizeBounds6, buttonSize.Height - 1);
				    g2.DrawLine(sb, 0, SizeBounds6, 0, buttonSize.Height - SizeBounds6 - 1);

                    g2.SmoothingMode = SmoothingMode.HighQuality;
                    g2.DrawArc(sb, new Rectangle(buttonSize.Width-SizeBounds3-1, 0, SizeBounds3, SizeBounds3/**/), 270F, 90F);
                    g2.DrawArc(sb, new Rectangle(buttonSize.Width-SizeBounds3-1, buttonSize.Height-SizeBounds3-1, SizeBounds3, SizeBounds3/**/),0F,  90F);
                    g2.DrawArc(sb, new Rectangle(0, 0, SizeBounds3, SizeBounds3/**/), 180F, 90F);
                    g2.DrawArc(sb, new Rectangle(0, buttonSize.Height-SizeBounds3-1, SizeBounds3, SizeBounds3/**/),90F,  90F);
                }

             //   if (Constants.Shadow) {
                    using (Bitmap bit = NativeMethods.SetBitmapOpacity(nb, .3f)) {
                        using (Bitmap bz2 = new Bitmap((int)(buttonSize.Width/Constants.TextBlur), (int)(buttonSize.Height/Constants.TextBlur))) {

                            using (Graphics gT = Graphics.FromImage(bz2)) {
                                gT.CompositingQuality=CompositingQuality.HighQuality;
                                gT.InterpolationMode=InterpolationMode.HighQualityBicubic;
                                gT.PixelOffsetMode=PixelOffsetMode.HighQuality;
                                gT.SmoothingMode=SmoothingMode.HighQuality;

                                gT.DrawImage(bit, new Rectangle(0, 0, bz2.Width, bz2.Height));
                            }

                            g.CompositingQuality=CompositingQuality.HighQuality;
                            g.InterpolationMode=InterpolationMode.HighQualityBicubic;
                            g.PixelOffsetMode=PixelOffsetMode.HighQuality;
                            g.SmoothingMode=SmoothingMode.HighQuality;

                            g.DrawImage(bz2, new RectangleF(3f, 2.5f, buttonSize.Width, buttonSize.Height));
                            g.DrawImage(bz2, new RectangleF(2.5f, 3f, bit.Width, bit.Height));

                            g.DrawImage(nb, new Point(1, 1));
                        }
                    }
               // }
            }

            g.DrawImage(rabcrClient.Properties.Resources.page_right,buttonSize.Width-21-4,7/*-5*/);
            g.DrawImage(rabcrClient.Properties.Resources.page_left,4,7/*-5*/);

            if (flyText) {
                if (directionLeft){
                    NativeMethods.Text(g,Constants.font14,oldtext,pos.X+10*timing-100,pos.Y,(int)(255*(timing/10f)));
                    NativeMethods.Text(g,Constants.font14,list[selected],pos.X+timing*10,pos.Y,(int)(255*(1-timing/10f)));
                } else {
                    NativeMethods.Text(g,Constants.font14,oldtext,pos.X-10*timing+100,pos.Y,(int)(255*(timing/10f)));
                    NativeMethods.Text(g,Constants.font14,list[selected],pos.X-timing*10,pos.Y,(int)(255*(1-timing/10f)));
                }

            } else {
                NativeMethods.Text(g,Constants.font14,list[selected],pos.X,pos.Y,255);
            }
        }

        protected override void OnLostFocus(EventArgs e) {
            need=255;
            base.OnLostFocus(e);
        }

        protected override void OnGotFocus(EventArgs e) {
            need=190;
            base.OnGotFocus(e);
        }

        protected override void Dispose(bool disposing) {
            if (timer.Enabled)timer.Stop();
            timer?.Dispose();
            base.Dispose(disposing);
        }
//	}
}