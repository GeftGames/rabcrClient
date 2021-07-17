using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace rabcrClient{
    public class GButton : Control {
        enum State :byte{
		    None,
		    Enter,
		    Click
	    }

        public enum Orientation :byte{
		    Left,
		    Center,
		    Right
	    }

        #region Varibles
        const int SizeBounds=20;
	    int textX, textY;
	    bool disamble=false;
        int alpha=250;
        int need=255;
        State currentState;
        Orientation currentOrientation;
        readonly SolidBrush brushShadow=new SolidBrush(Color.FromArgb(80, 0, 0, 0));
        Size buttonSize;
        Bitmap shadow;
        readonly Timer timer;
        #endregion


        public GButton() {
		    textX=Size.Width/2;
		    textY=Size.Height/2;

		    currentState=State.None;
            currentOrientation=Orientation.Center;
		    DoubleBuffered = true;
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    BackColor=Color.Transparent;
            (timer=new Timer {
                Enabled=true,
                Interval=35
            }).Tick+=Timer_Tick;
            buttonSize=new Size(Size.Width-3,Size.Height-4);
            Size =new Size(Size.Width,36);
	    }

        void Timer_Tick(object sender, EventArgs e) {
            if (IsDisposed) timer.Stop();

            if (need!=alpha) {
                if (need<alpha) {
                    alpha-=1+FastMath.Abs(need-alpha)/6;
                    Invalidate();
                }
                if (need>alpha) {
                    alpha+=1+FastMath.Abs(need-alpha)/6;
                    Invalidate();
                }
                if (alpha-need<4 && alpha-need>-4) alpha=need;
            }
        }

        public Orientation SetOrientation {
		    get => currentOrientation; 
		    set { 
                currentOrientation = value;
                Invalidate();
            }
	    }

        public bool Disamble {
            get => disamble; 
            set { 
                disamble = value; 
                Invalidate(); 
            }
        }

        protected override void OnResize(EventArgs e) {
		    base.OnResize(e);
		    textX=Size.Width/2;
		    textY=Size.Height/2;
            buttonSize=new Size(Size.Width-3,Size.Height-4);
            Size =new Size(Size.Width,36);
		    Refresh();
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
                need=200;
		    }
	    }

	    protected override void OnMouseEnter(EventArgs e) {
		    base.OnMouseEnter(e);
		    if (currentState!=State.Enter) {
			    currentState = State.Enter;
                need=200;
		    }
	    }

	    protected override void OnMouseLeave(EventArgs e) {
		    base.OnMouseLeave(e);
		    if (currentState!=State.None) {
			    currentState = State.None;
                need=255;
		    }
	    }

	    protected override void OnMouseDown(MouseEventArgs mevent) {
		    base.OnMouseDown(mevent);
		    if (currentState!=State.Click) {
			    currentState = State.Click;
                need=150;
		    }
	    }

        protected override void OnPaint(PaintEventArgs e) {
		    Graphics g = e.Graphics;
            g.PixelOffsetMode=PixelOffsetMode.HighQuality;

            SizeF textsize=g.MeasureString(Text, Constants.font14);
            Point pos=new Point(
                textX - (int)(textsize.Width/2f),
                textY - (int)(textsize.Height/2f)
            );
		    Pen sb;
		    Brush b;

            if (disamble) {
                sb = new Pen(new SolidBrush(Color.DarkGray));
                b = new LinearGradientBrush(ClientRectangle, Color.FromArgb(alpha-20, alpha-20, alpha-20), Color.FromArgb(alpha-40-20, alpha-40-20, alpha-40-20), 90);
            } else {
                b = new LinearGradientBrush(ClientRectangle, Color.FromArgb(alpha, alpha, alpha), Color.FromArgb(alpha-40, alpha-40, alpha-40), 90);
                sb = new Pen(new SolidBrush(Color.Black));
            }

            int SizeBounds3=SizeBounds/3, 
                SizeBounds6=SizeBounds/6, 
                SizeBounds2=SizeBounds/2;

            using (Bitmap nb=new Bitmap(buttonSize.Width, buttonSize.Height)) {
                using (Graphics g2 = Graphics.FromImage(nb)) {
                    switch (currentOrientation){

                        case Orientation.Left:
                            //Inside
                            g2.FillRectangle(b, /*0*/SizeBounds3, 0, buttonSize.Width - SizeBounds2-SizeBounds3, buttonSize.Height);
                            g2.FillRectangle(b, buttonSize.Width - SizeBounds2, SizeBounds2, SizeBounds2 - 1, buttonSize.Height - SizeBounds);
                            g2.FillEllipse(b, new Rectangle(buttonSize.Width - SizeBounds - 1, 0, SizeBounds, SizeBounds));
                            g2.FillEllipse(b, new Rectangle(buttonSize.Width - SizeBounds - 1, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds));

                            //small
                            g2.FillEllipse(b, new Rectangle(0, 0, SizeBounds3, SizeBounds3));
                            g2.FillEllipse(b, new Rectangle(0, buttonSize.Height - SizeBounds3 - 1, SizeBounds3, SizeBounds3));
                            g2.FillRectangle(b, 0, SizeBounds6, SizeBounds2, buttonSize.Height-SizeBounds3);

                            // Bounds
                            g2.DrawLine(sb, SizeBounds6, 0, buttonSize.Width - SizeBounds2/*-1*/+1-SizeBounds6, 0);
                            g2.DrawLine(sb, 0, SizeBounds6, 0, buttonSize.Height-1-SizeBounds6);
                            g2.DrawLine(sb, SizeBounds6, buttonSize.Height - 1, buttonSize.Width - SizeBounds2/*-1*/+1-SizeBounds6, buttonSize.Height - 1);
                            g2.DrawLine(sb, buttonSize.Width - 1, SizeBounds2-1, buttonSize.Width - 1, buttonSize.Height - SizeBounds2 - 1-1);

                            g2.SmoothingMode = SmoothingMode.HighQuality;
                            g2.DrawArc(sb, new Rectangle(buttonSize.Width - SizeBounds-1, 0, SizeBounds, SizeBounds + 6-6), 270F, 90F);
                            g2.DrawArc(sb, new Rectangle(buttonSize.Width - SizeBounds - 1, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds), 0F, 90F);

                            //small
                            g2.DrawArc(sb, new Rectangle(0, 0, SizeBounds3, SizeBounds3), 180F, 90F);
                            g2.DrawArc(sb, new Rectangle(0, buttonSize.Height-SizeBounds3-1, SizeBounds3, SizeBounds3/**/),90F,  90F);
                            break;

                        case Orientation.Right:
                            //Inside
                            g2.FillRectangle(b, SizeBounds2, 0, buttonSize.Width - SizeBounds2-SizeBounds3, buttonSize.Height);
				            g2.FillRectangle(b, 0, SizeBounds2, SizeBounds2, buttonSize.Height - SizeBounds);
				            g2.FillEllipse(b, new Rectangle(1, 0, SizeBounds, SizeBounds));
				            g2.FillEllipse(b, new Rectangle(0, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds));

                            //small
                            g2.FillEllipse(b, new Rectangle(buttonSize.Width-SizeBounds3-1, 0, SizeBounds3, SizeBounds3));
                            g2.FillEllipse(b, new Rectangle(buttonSize.Width-SizeBounds3-1, buttonSize.Height - SizeBounds3 - 1, SizeBounds3, SizeBounds3));
                            g2.FillRectangle(b, buttonSize.Width-SizeBounds3-1, SizeBounds6, SizeBounds2, buttonSize.Height-SizeBounds3);

				            // Bounds
				            g2.DrawLine(sb, SizeBounds2, 0, buttonSize.Width /*+*//*- SizeBounds2*/-SizeBounds6, 0);
				            g2.DrawLine(sb, buttonSize.Width - 1, /*0*/SizeBounds6, buttonSize.Width -1, buttonSize.Height-SizeBounds6);
				            g2.DrawLine(sb, SizeBounds2, buttonSize.Height - 1, buttonSize.Width -SizeBounds6, buttonSize.Height - 1);
				            g2.DrawLine(sb, 0, SizeBounds2, 0, buttonSize.Height - SizeBounds2 - 1);

				            g2.SmoothingMode = SmoothingMode.HighQuality;
				            g2.DrawArc(sb, new Rectangle(0, 0, SizeBounds, SizeBounds + 6), 180F, 90F);
				            g2.DrawArc(sb, new Rectangle(0, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds), 90F, 90F);

                            //small
                            g2.DrawArc(sb, new Rectangle(buttonSize.Width-SizeBounds3-1, 0, SizeBounds3, SizeBounds3), 270F, 90F);
                            g2.DrawArc(sb, new Rectangle(buttonSize.Width-SizeBounds3-1, buttonSize.Height-SizeBounds3-1, SizeBounds3, SizeBounds3),0F,  90F);
                            break;

                        default:
                            //Inside
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
                            break;
                    }
                }

                g.PixelOffsetMode=PixelOffsetMode.Half;

                if (State.None==currentState) {
                    if (shadow!=null) {
                        g.DrawImage(shadow, new RectangleF(3f-0.5f, 2.5f+1, buttonSize.Width+1, buttonSize.Height+1));
                        g.DrawImage(shadow, new RectangleF(2.5f-0.5f, 3f+1, buttonSize.Width+1, buttonSize.Height+1));
                    } else SetButton();

                    g.DrawImage(nb, new Point(1, 1));
                    NativeMethods.Text(g, Constants.font14, Text, pos.X, pos.Y, 255);
                } else if (State.Click==currentState) {
                    g.DrawImage(nb, new Point(1, 1+1));
                    NativeMethods.Text(g, Constants.font14, Text, pos.X, pos.Y+1,255);
                } else {
                    if (shadow!=null) {
                        g.DrawImage(shadow, new RectangleF(3f-0.5f, 2.5f+1, buttonSize.Width+1, buttonSize.Height+1));
                        g.DrawImage(shadow, new RectangleF(2.5f-0.5f, 3f+1, buttonSize.Width+1, buttonSize.Height+1));
                    } else SetButton();

                    g.DrawImage(nb, new Point(1, 1));
                    NativeMethods.Text(g, Constants.font14, Text, pos.X, pos.Y, 255);
                }
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

        unsafe  void SetButton() {
            Size buttonSize=new Size(Size.Width-3,Size.Height-3);
		    Pen sb = new Pen(new SolidBrush(Color.Black));
		    Brush b = new LinearGradientBrush(ClientRectangle, Color.FromArgb(alpha, alpha, alpha), Color.FromArgb(alpha-40, alpha-40, alpha-40), 90);
           
            using (Bitmap nb=new Bitmap(buttonSize.Width,buttonSize.Height)) {
                if (Orientation.Left==currentOrientation) {
                    using (Graphics g2 = Graphics.FromImage(nb)) {
                        int SizeBounds2=SizeBounds/2;

                        //Inside
                        g2.FillRectangle(b, 0, 0, buttonSize.Width -SizeBounds2, buttonSize.Height);
                        g2.FillRectangle(b, buttonSize.Width - SizeBounds2, SizeBounds2, SizeBounds2 - 1, buttonSize.Height - SizeBounds);
                        g2.FillEllipse(b, new Rectangle(buttonSize.Width - SizeBounds - 1, 0, SizeBounds, SizeBounds));
                        g2.FillEllipse(b, new Rectangle(buttonSize.Width - SizeBounds - 1, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds));

                        // Bounds
                        g2.DrawLine(sb, 0, 0, buttonSize.Width - SizeBounds2-1, 0);
                        g2.DrawLine(sb, 0, 0, 0, buttonSize.Height-1);
                        g2.DrawLine(sb, 0, buttonSize.Height - 1, buttonSize.Width - SizeBounds2-1, buttonSize.Height - 1);
                        g2.DrawLine(sb, buttonSize.Width - 1, SizeBounds2-1, buttonSize.Width - 1, buttonSize.Height - SizeBounds2 - 2);

                        g2.SmoothingMode = SmoothingMode.HighQuality;
                        g2.DrawArc(sb, new Rectangle(buttonSize.Width - SizeBounds-1, 0, SizeBounds, SizeBounds), 270F, 90F);
                        g2.DrawArc(sb, new Rectangle(buttonSize.Width - SizeBounds - 1, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds), 0F, 90F);
                    }
                } else if (Orientation.Right==currentOrientation) {
                    using (Graphics g2 = Graphics.FromImage(nb)) {
                        int SizeBounds2=SizeBounds/2;

                        g2.FillRectangle(b, SizeBounds2, 0, buttonSize.Width - SizeBounds2, buttonSize.Height);
				        g2.FillRectangle(b, 0, SizeBounds2, SizeBounds2, buttonSize.Height - SizeBounds);
				        g2.FillEllipse(b, new Rectangle(1, 0, SizeBounds, SizeBounds));
				        g2.FillEllipse(b, new Rectangle(0, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds));

				        // Bounds
				        g2.DrawLine(sb, SizeBounds2, 0, buttonSize.Width + SizeBounds2, 0);
				        g2.DrawLine(sb, buttonSize.Width - 1, 0, buttonSize.Width -1, buttonSize.Height);
				        g2.DrawLine(sb, SizeBounds2, buttonSize.Height - 1, buttonSize.Width + SizeBounds2, buttonSize.Height - 1);
				        g2.DrawLine(sb, 0, SizeBounds2, 0, buttonSize.Height - SizeBounds2 - 1);

				        g2.SmoothingMode = SmoothingMode.HighQuality;
				        g2.DrawArc(sb, new Rectangle(0, 0, SizeBounds, SizeBounds + 6), 180F, 90F);
				        g2.DrawArc(sb, new Rectangle(0, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds), 90F, 90F);
                    }
			    } else {
                    using (Graphics g2 = Graphics.FromImage(nb)) {
                        g2.FillRectangle(b, 1, 1, buttonSize.Width-2, buttonSize.Height-2);

				        g2.DrawRectangle(sb, new Rectangle(0, 0, buttonSize.Width-1, buttonSize.Height-1));
                    }
                }

                int smallW=(int)(buttonSize.Width*Constants.TextBlur)+2, 
                    smallH=(int)(buttonSize.Height*Constants.TextBlur)+2;

                shadow?.Dispose();
                shadow=new Bitmap(smallW, smallH);

                using (Graphics gT = Graphics.FromImage(shadow)) {
                    gT.CompositingQuality=CompositingQuality.HighQuality;
                    gT.InterpolationMode=InterpolationMode.HighQualityBicubic;
                    gT.PixelOffsetMode=PixelOffsetMode.Half;
                    gT.SmoothingMode=SmoothingMode.HighQuality;
                    using (Bitmap h=NativeMethods.SetBitmapOpacity(nb,0.5f)) gT.DrawImage(h, new Rectangle(1, 1, shadow.Width-2, shadow.Height-2));
                }

                BitmapData bdout=shadow.LockBits(new Rectangle(0, 0, smallW, smallH), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            
                byte* pointer = (byte*)bdout.Scan0.ToPointer();
              
                // one third of alpha
                byte* max=pointer+smallW*smallH*4;
                for (pointer+=3; pointer<max; pointer+=4) *pointer=(byte)((*pointer)/3);
       
                shadow.UnlockBits(bdout);
            }
        }

        protected override void Dispose(bool disposing) {
            shadow?.Dispose();
            brushShadow?.Dispose();
            if (timer.Enabled)timer.Stop();
            timer?.Dispose();
            base.Dispose(disposing);
        }
    }
}