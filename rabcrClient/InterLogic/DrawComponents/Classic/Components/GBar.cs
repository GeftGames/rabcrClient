using System;
using System.Drawing;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class GBar : Control {
        float fill=0;
        readonly Timer timer;

        public GBar() {
            DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint, true);
            TabStop=false;
            (timer=new Timer {
                Enabled=true,
                Interval=40
            }).Tick+=Timer_Tick;
        }

        public float Value {
            get { return fill; }
            set => fill=value;
        }

        void Timer_Tick(object sender, EventArgs e) {
            if (this.IsDisposed)timer.Stop();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
			Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(new SolidBrush(Color.Gray)),0,0,Width-1,Height-1);

			if (fill!=0) {
				int f=255;
				for (int i=0; i<30; i++) {
                    g.DrawLine(new Pen(new SolidBrush(Color.FromArgb(0, f, 0))),1, i,(Width-2)*fill,i );
					f-=5;
				}
            }
        }

        protected override void OnCreateControl() {
            base.OnCreateControl();
            try {
                Region=Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width+1, Height+1, 5, 5));
            } catch { }
        }

        protected override void Dispose(bool disposing) {
            if (timer.Enabled)timer.Stop();
            timer?.Dispose();
            base.Dispose(disposing);
        }
    }
}
