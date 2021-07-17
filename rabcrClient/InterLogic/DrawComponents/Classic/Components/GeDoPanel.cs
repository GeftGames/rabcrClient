using System;
using System.Drawing;
using System.Windows.Forms;

namespace rabcrClient {
    public class GeDoPanel : Control{

        #region Varibles
        GGeDo gedo;
        readonly Timer timer;
        Point point=Point.Empty;
        #if DEBUG
        readonly bool designMode;
        #endif
        #endregion

        public GeDoPanel() {
            TabStop=false;

            #if DEBUG
            designMode=System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";

            if (!designMode) {
            #endif
			    ResizeRedraw = true;
			    DoubleBuffered = true;
			    SetStyle(ControlStyles.UserPaint, true);
			    BackColor=Color.White;

                (timer=new Timer {
                    Enabled=true,
                    Interval=40
                }).Tick+=Timer_Tick;

                gedo=new GGeDo(0,4);
            #if DEBUG
            }
            #endif
            Disposed+=GeDoPanel_Disposed;
		}

        private void GeDoPanel_Disposed(object sender, EventArgs e) {
            timer.Enabled=false;
           // gedo.Dispose();
            gedo=null;
        }

        public void AddEvent(GeDoEvent e) {
            gedo.GeDoEvents.Add(e);
        }

        public void ClearEvents() {
            gedo.GeDoEvents.Clear();
        }

        public void Stop() {
            gedo=null;
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            if (IsDisposed)timer.Stop();

            if (this==null)timer.Stop();
            if (Disposing) timer.Stop();

            if (gedo!=null) {
                point=PointToClient(MousePosition);

                gedo.mouseX=point.X;
                gedo.mouseY=point.Y;
            }

            Invalidate();
        }

        public void Load(string text) {
            try {
                gedo.BuildString(text);
            } catch (Exception ex) {
                gedo.BuildString(string.IsNullOrEmpty(ex.Message) ? "Error, nesprávná syntaxe": ex.Message);
            }
            Invalidate();
        }

        public void Disponse() {
            timer.Stop();
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            base.OnMouseDown(e);
            if (gedo!=null) 
                gedo.Click=true;
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            if (gedo!=null) 
                gedo.Click=false;
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            base.OnMouseMove(e);
            if (gedo!=null) {
                gedo.Click=false;

                gedo.mouseX=e.X;
                gedo.mouseY=e.Y;
            }
        }

        protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			Refresh();
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g=e.Graphics;
            g.Clear(BackColor);
            #if DEBUG
            if (!designMode) {
            #endif
                if (gedo!=null) gedo.DrawGedo(1,g/*g,0,2*/);
            #if DEBUG
            }
            #endif
        }

        protected override void OnCreateControl() {
            base.OnCreateControl();
            try {
                Region=Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width+1, Height+1, 6, 6));
            } catch { }
        }

        protected override void Dispose(bool disposing) {
            if (timer.Enabled)timer.Stop();
            timer?.Dispose();
            base.Dispose(disposing);
        }
    }
}