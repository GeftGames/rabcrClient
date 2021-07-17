using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace rabcrClient {
    public class GBounds : Control {

        public bool Selected;
        float v;
        public StateSelect state;
        readonly Timer timer;
        public enum StateSelect :byte {
            Between,
		    True,
		    False
	    }

        public bool drawClearPix;

        public GBounds() {
            TabStop=false;
            Selected=true;
		    ResizeRedraw = true;
		    DoubleBuffered = true;
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor,true);
		    BackColor=Color.Transparent;
            (timer=new Timer {
                Interval=35,
                Enabled=true
            }).Tick+=Timer_Tick;
	    }

        private void Timer_Tick(object sender, EventArgs e) {
            if (this.IsDisposed)timer.Stop();
            float z=v;

            if (Selected) {
                if (v<1) v+=0.09f;
            } else {
                if (v>0) v-=0.09f;
            }
            if (v<0)v=0;
            if (v>1)v=1;

            if (v!=z)Invalidate();
        }

	    protected override void OnResize(EventArgs e) {
		    base.OnResize(e);
		    Refresh();
	    }

	    protected override void OnPaint(PaintEventArgs e) {
		    Graphics g=e.Graphics;
            g.InterpolationMode=InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode=PixelOffsetMode.HighQuality;
            g.SmoothingMode=SmoothingMode.AntiAlias;
            g.PixelOffsetMode=PixelOffsetMode.Half;

            Color c;
            int grayIndex=150;
            switch (state) {
                default:
                    c=Color.FromArgb((int)(159+(grayIndex-159)*v), (int)(208+(grayIndex-208)*v), (int)(255+(grayIndex-255)*v));
                    break;

                case StateSelect.True:
                    c=Color.FromArgb((int)(25+(grayIndex-25)*v), (int)(225+(grayIndex-225)*v), (int)(115+(grayIndex-155)*v));
                    break;

                case StateSelect.False:
                    c=Color.FromArgb((int)(255+(grayIndex-255)*v), (int)(15+(grayIndex-15)*v), (int)(115+(grayIndex-115)*v));
                    break;
            }
            for (float f=0; f<5; f+=0.25f) NativeMethods.FillRoundedRectangle(g,new SolidBrush(Color.FromArgb((int)((f*3+0.9f)*f+7+v),c)),new RectangleF(f, f, Size.Width-f*2-1, Size.Height-f*2-1),5);

            //NativeMethods.FillRoundedRectangle(g,new SolidBrush(Color.FromArgb(25,c)),new Rectangle(0, 0, Size.Width-1, Size.Height-1-1),4);
            //NativeMethods.FillRoundedRectangle(g,new SolidBrush(Color.FromArgb(25,c)),new Rectangle(1, 1, Size.Width-3, Size.Height-3-1),4);
            //NativeMethods.FillRoundedRectangle(g,new SolidBrush(Color.FromArgb(25,c)),new Rectangle(2, 2, Size.Width-4, Size.Height-4-1),4);

            g.PixelOffsetMode=PixelOffsetMode.None;
            g.SmoothingMode=SmoothingMode.None;
            g.InterpolationMode=InterpolationMode.NearestNeighbor;


            if (drawClearPix) {
                g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(3,4,1,1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(3,5,1,1));

                g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(4,3,1,1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(5,3,1,1));

                g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(Width-3+2-1-3,4,1,1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(Width-3-1+2-3,5,1,1));

                g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(Width-4-1+2-3,3,1,1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(Width-5-1+2-3,3,1,1));


                g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(Width-3-1+2-3,Height-4+1-3,1,1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(Width-3-1+2-3,Height-5+1-3,1,1));

                g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(Width-4-1+2-3,Height-3+1-3,1,1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(Width-5-1+2-3,Height-3+1-3,1,1));


                g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(3,Height-4+1-3,1,1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(3,Height-5+1-3,1,1));

                g.FillRectangle(new SolidBrush(Color.FromArgb(129,255,255,255)),new Rectangle(4,Height-3+1-3,1,1));
                g.FillRectangle(new SolidBrush(Color.FromArgb(219,255,255,255)),new Rectangle(5,Height-3+1-3,1,1));
		    }
        }
        protected override void Dispose(bool disposing) {
            if (timer.Enabled)timer.Stop();
            timer?.Dispose();
            base.Dispose(disposing);
        }
    }
}