using System;
using System.Drawing;
using System.Windows.Forms;

namespace rabcrClient{
    public class GTextPanel : Control{

      //  bool small=false;

	    public GTextPanel() {
            TabStop=false;
		    DoubleBuffered = true;
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    BackColor=Color.Transparent;
	    }

        public bool SmallFont=false;
     //   {
		   // get { return small; }
		   // set { small = value; }
	    //}

	    protected override void OnResize(EventArgs e) {
		    base.OnResize(e);
		    Invalidate();
	    }

	    protected override void OnPaint(PaintEventArgs e) {
            Text = Text.Replace("|", Environment.NewLine);
		    Graphics g=e.Graphics;

            if (SmallFont) {
                Width=(int)g.MeasureString(Text, Constants.font10).Width;
                Height=(int)g.MeasureString(Text, Constants.font10).Height;
                NativeMethods.Text(g, Constants.font10, Text, 0, 0, 255);
            } else {
                Width=(int)g.MeasureString(Text, Constants.font14).Width;
                Height=(int)g.MeasureString(Text, Constants.font14).Height;
                NativeMethods.Text(g, Constants.font14, Text, 0, 0, 255);
            }
        }
    }
}