using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class GLangButton : Control{

    public Image image;
    public bool select=false;
    public int id;
    readonly Timer timer;

	enum State :byte{
		None,
		Enter,
		Click
    }
	State currentState;

    float alpha=0;

	public GLangButton() {
		currentState =State.None;
		DoubleBuffered = true;
		SetStyle(ControlStyles.UserPaint, true);
		SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		BackColor =Color.FromArgb(0,255,255,255);
        (timer = new Timer(){
            Interval=40
        }).Tick+=Timer_Tick;
        Size=new Size(Size.Width, 32);
	}

    private void Timer_Tick(object sender, EventArgs e) {
        if (this.IsDisposed)timer.Stop();

         if (currentState==State.Click || currentState==State.Enter) {
                 alpha+=alpha/5f+2;
                 if (alpha>30) {
                    alpha=30;
                    timer.Stop();
                    Invalidate();
                    return;
                }
                Invalidate();
            }

            if (currentState==State.None) {
                alpha-=alpha/5f+2;
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
			//	Invalidate();
			}
		}

		protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			 Size=new Size(Size.Width, 32);
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
			base.OnMouseDown(mevent);
			if (currentState!=State.Click) {
				currentState = State.Click;
                //timer.Start();
				 //   Invalidate();
			}
		}

	protected override void OnPaint(PaintEventArgs e) {
		Graphics g = e.Graphics;
   // Bitmap b=new Bitmap(200,200);
       // Graphics g=Graphics.FromImage(b);

        if (select) g.FillRectangle(new SolidBrush(Color.FromArgb(Math.Abs((int)alpha-50), 0,0,0)),g.ClipBounds);
        else g.FillRectangle(new SolidBrush(Color.FromArgb((int)alpha, 0,0,0)),g.ClipBounds);

          int xx=(int)((image.Width/(float)image.Height)*22)/*,yy=22*/;
        if (image!=null) {
            g.PixelOffsetMode=PixelOffsetMode.Half;

            //// Shadow
            //if (Constants.Shadow) {
            //    for (float x = -0.5f; x<3; x+=0.5f) {
            //        for (float y = -.5f; y<3; y+=0.5f) {
            //            g.FillRectangle(new SolidBrush(Color.FromArgb((int)(4-Math.Abs((x+1)/4f)*Math.Abs((y+1)/4f)*4), 0, 0, 0)), new RectangleF(2+2+x, 2+y+2, /*36*/xx-2+x, /*22*/yy-2+y));
            //        }
            //    }
            //}

            g.PixelOffsetMode=PixelOffsetMode.HighQuality;

            //using (Bitmap img=new Bitmap(/*38,24*/xx,22)) {
            //using (Graphics g2=Graphics.FromImage(img)) {

                // Black brevel
                //int size=4;
                //using (Bitmap brevel=new Bitmap(/*38,24*/xx,22)){
                //    using (Graphics gg=Graphics.FromImage(brevel)) {

                        //for (int x=0; x<size; x++) {
                        //    float a=1-(float)Math.Sin((x/(float)size)*1.57f);

                        //    // light line
                        //    if (x>=size/3f){
                        //        if (x<(size/3f)*2f){
                        //            gg.FillRectangle(new SolidBrush(Color.FromArgb((int)(x/(float)size*255f/5f),255,255,255)),new Rectangle(x,x,1,1));
                        //            gg.DrawLine(
                        //                new Pen(
                        //                    new LinearGradientBrush(
                        //                        new Rectangle(0,0,(int)(/*38*/xx/size*3f)+1,/*24*/22),
                        //                        Color.FromArgb((int)((x/(float)size)*255f/size),255,255,255),
                        //                        Color.FromArgb(0,255,255,255),
                        //                        LinearGradientMode.Horizontal
                        //                    )
                        //                ),
                        //                x+1,x,(int)(/*38*/xx/size*3f),x
                        //            );
                        //            gg.DrawLine(
                        //                new Pen(
                        //                    new LinearGradientBrush(
                        //                        new Rectangle(0,0,/*38*/xx,(int)(/*24*/22f/size*3f)+1),
                        //                        Color.FromArgb((int)((x/(float)size)*255f/size),255,255,255),
                        //                        Color.FromArgb(0,255,255,255),
                        //                        LinearGradientMode.Vertical
                        //                    )
                        //                ),
                        //                x,x,x,(int)(/*24*/22f/size*3f)
                        //            );
                        //        } else {
                        //            gg.FillRectangle(new SolidBrush(Color.FromArgb((int)((1-x/(float)size)*255f/5f),255,255,255)),new Rectangle(x,x,1,1));
                        //            gg.DrawLine(
                        //                new Pen(
                        //                    new LinearGradientBrush(
                        //                        new Rectangle(0,0,(int)(/*38*/xx/size*3f)+1,/*24*/24),
                        //                        Color.FromArgb((int)((1-x/(float)size)*255f/size),255,255,255),
                        //                        Color.FromArgb(0,255,255,255),
                        //                        LinearGradientMode.Horizontal
                        //                    )
                        //                ),
                        //                x,x,(int)(/*38*/xx/size*3f),x
                        //            );
                        //            gg.DrawLine(
                        //                new Pen(
                        //                    new LinearGradientBrush(
                        //                        new Rectangle(0,0,/*38*/xx,(int)(/*24*/24f/size*3f)+1),
                        //                        Color.FromArgb((int)((1-x/(float)size)*255f/size),255,255,255),
                        //                        Color.FromArgb(0,255,255,255),
                        //                        LinearGradientMode.Vertical
                        //                    )
                        //                ),
                        //                x,x,x,(int)(/*24*/24f/size*3f)
                        //            );
                        //        }
                        //    }

                            ////bottom
                            //gg.DrawLine(new Pen(Color.FromArgb((int)(a*255f/5f),0,0,0)),x,(/*24*/24-x),(/*38*/xx-x)+1-2,(/*24*/24-x));
                            ////right
                            //gg.DrawLine(new Pen(Color.FromArgb((int)(a*255f/5f),0,0,0)),/*38*/xx-x,x,(/*38*/xx-x),(/*24*/24-x));

                        //}

                        g.DrawImage(image,new RectangleF(3,3,/*38*/xx,/*24*/22));

                        //using (Bitmap brevel25=NativeMethods.SetBitmapOpacity(brevel,0.25f)) {
                        //    for (float x=-0.5f; x<1; x+=0.5f) {
                        //        for (float y=-0.5f; y<1; y+=0.5f) g2.DrawImage(brevel25,new RectangleF(x,y,/*38*/xx,/*24*/24));
                        //    }
                        //}
                //    }
                //}

                ////bottom
                //g2.DrawLine(new Pen(Color.FromArgb(40,0,0,0)),0,(/*24*/24-1),(/*38*/xx-1)+1-2,(/*24*/24-1));

                ////right
                //g2.DrawLine(new Pen(Color.FromArgb(40,0,0,0)),/*38*/xx-1,0,(/*38*/xx-1),(/*24*/24-1));

    //g.SmoothingMode=SmoothingMode.HighQuality;
    //    g.CompositingQuality=CompositingQuality.HighQuality;
        //g.InterpolationMode = InterpolationMode.HighQualityBilinear;
    //    g.PixelOffsetMode=PixelOffsetMode.HighQuality;


                //g.DrawImage(img,new RectangleF(2+2,2+2,/*38*/xx,/*24*/22));
            //    }
            //}
        }
        NativeMethods.Text(g,Constants.font14,Text,2+44-10,3,255);
      //  b.Save("lang "+Text+".png");
	}

    protected override void Dispose(bool disposing) {
        if (timer.Enabled)timer.Stop();
        timer?.Dispose();
        base.Dispose(disposing);
    }

}
