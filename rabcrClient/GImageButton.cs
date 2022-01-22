using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

//namespace rabcrServer {
	class GImageButton : Control{
        public bool left=true;
        public bool select=false;
	    public enum State :byte{
			None,
			Enter,
			Click
		}

        public 	State currentState;
        bool deactivated=false;
		public Image image;
        int alpha=0;
    readonly Timer timer;

		public GImageButton() {
			currentState =State.None;
			DoubleBuffered = true;
		    SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			BackColor =Color.FromArgb(0,255,255,255);
            (timer=new Timer {
                Interval=40
            }).Tick+=Timer_Tick;
		}

        private void Timer_Tick(object sender, EventArgs e) {
         if (currentState==State.Click || currentState==State.Enter) {
                 alpha+=alpha/3+1;
                 if (alpha>50) {
                    alpha=50;
                    timer.Stop();
                    Invalidate();
                    return;
                }
                Invalidate();
            }

            if (currentState==State.None) {
                alpha-=alpha/3-1;
                if (alpha<0) {
                    alpha=0;
                    timer.Stop();
                    Invalidate();
                    return;
                }
                Invalidate();
            }
        }

        public Image Image {
			get { return image; }
			set {
                image = value;
				Invalidate();
			}
		}

        public bool Deactivated {
			get {
                if (deactivated) {
                deactivated=false;

                    return true;
                }
                return false;
            }
		}

		protected override void OnResize(EventArgs e) {
			base.OnResize(e);

			Invalidate();
		}

		protected override void OnLeave(EventArgs e) {
			base.OnLeave(e);
			currentState=State.None;

            timer.Start();
			Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e) {
			base.OnMouseUp(e);
			if (currentState!=State.Enter) {
				currentState = State.Enter;
                timer.Start();
				Invalidate();
			}
		}

		protected override void OnMouseEnter(EventArgs e) {
			base.OnMouseEnter(e);
			if (currentState!=State.Enter) {


				currentState = State.Enter;
                timer.Start();
				Invalidate();
			}
		}

		protected override void OnMouseLeave(EventArgs e) {
			base.OnMouseLeave(e);
			if (currentState!=State.None) {
				currentState = State.None;
                timer.Start();
				Invalidate();
			}
		}

		protected override void OnMouseDown(MouseEventArgs mevent) {
            MouseDown += ((o, ee) => {
                left=MouseButtons.Left==ee.Button;
            });
            base.OnMouseDown(mevent);
			if (currentState!=State.Click) {
			currentState = State.Click;
                if (!select) {
                    select=true;
				    Invalidate();
                } else {
                    select=false;
                    deactivated=true;
				    Invalidate();
                }
                //timer.Start();
			}
		}

		protected override void OnPaint(PaintEventArgs e) {

			Graphics g = e.Graphics;

            Size=new Size(26,26);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
		    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
		    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Color back1=Color.FromArgb(alpha/2,0, 0,0);
            Color back2=Color.FromArgb(alpha,0, 0,0);

            g.FillRectangle(new LinearGradientBrush(ClientRectangle, back1, back2, 90),g.ClipBounds);

            if (image!=null) {
                g.DrawImage(image,new Rectangle(1,1,24,24));
            }
	    }
    }
//}