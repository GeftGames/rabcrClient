using System;
using System.Drawing;
using System.Windows.Forms;

namespace RabcrServer {
	public class GTextPanelLined : Control{
      //  const bool center=true;

		public GTextPanelLined() {
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			BackColor=Color.Transparent;
		}

		//public bool Center {
		//	get { return center; }
		//	set { center = value; Invalidate(); }
		//}

		protected override void OnResize(EventArgs e) {
			base.OnResize(e);

			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e) {
			Graphics g=e.Graphics;

            int w=(int)g.MeasureString(Text,Constants.font14).Width;
            int h=(int)g.MeasureString(Text,Constants.font14).Height;

            g.DrawLine(new Pen(new SolidBrush(Color.Black),2),new Point(0,h/2),new Point(Width/2-w/2-5,h/2));
            g.DrawLine(new Pen(new SolidBrush(Color.Black),2),new Point(Width/2+w/2+5,h/2),new Point(Width,h/2));

            //if (Constants.Shadow) {
                g.DrawLine(new Pen(new SolidBrush(Color.FromArgb((int)(Constants.TextTransparentry*255),0,0,0)),2),new Point(Width/2+w/2+5+1,h/2+1),new Point(Width+1,h/2+1));
                g.DrawLine(new Pen(new SolidBrush(Color.FromArgb((int)(Constants.TextTransparentry*255),0,0,0)),2),new Point(1,h/2+1),new Point(Width/2-w/2-5+1,h/2+1));
            //}

            NativeMethods.Text(g,Constants.font14,Text,Width/2-w/2, 0,255);
        }
    }
}