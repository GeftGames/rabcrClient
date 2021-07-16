using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace rabcrClient{
    public class GColor : Control {
        enum State :byte{
		    None,
		    Enter,
		    Click
	    }

        #region Varibles
        const int SizeBounds=20;
	    bool selected=false;
        int alpha=250;
        int need=255;
        State currentState;
        readonly SolidBrush brushShadow=new SolidBrush(Color.FromArgb(80, 0, 0, 0));
        Size buttonSize;
        Bitmap shadow;
        readonly Timer timer;
        public Color color;
        public bool Custom;
        public delegate void IsSelectHandler();
        public event IsSelectHandler IsSelect;
        #endregion

        public bool Selected {
            get => selected; 
            set { 
                selected = value; 
                Invalidate(); 
            }
        }

        public GColor() {
		    currentState=State.None;
		    DoubleBuffered = true;
		    SetStyle(ControlStyles.UserPaint, true);
		    SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		    BackColor=Color.Transparent;

            (timer=new Timer {
                Enabled=true,
                Interval=40
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

        protected override void OnResize(EventArgs e) {
		    base.OnResize(e);
            buttonSize=new Size(Size.Width-3,Size.Height-4);
            Size=new Size(Size.Width,36);
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
                IsSelect.Invoke();
		    }
	    }

        protected override void OnPaint(PaintEventArgs e) {
		    Graphics g = e.Graphics;

		    Pen sb;
		    Brush b;

            if (selected) {
                sb = new Pen(new LinearGradientBrush(ClientRectangle,Color.Black, Color.Black,60f));
                b= new LinearGradientBrush(ClientRectangle, Color.White, Color.Black, 60f);
            } else {
                b= new LinearGradientBrush(ClientRectangle, Color.FromArgb(alpha, alpha, alpha), Color.FromArgb(alpha-40, alpha-40, alpha-40), 90);
                sb = new Pen(new SolidBrush(Color.Black));
            }

            int SizeBounds3=SizeBounds/3;
            int SizeBounds6=SizeBounds/6;
            int SizeBounds2=SizeBounds/2;
            using (Bitmap nb=new Bitmap(buttonSize.Width, buttonSize.Height)) {
                using (Graphics g2 = Graphics.FromImage(nb)) {
                //    switch (currentOrientation){

                //        case Orientation.Left:
                //            //Inside
                //            g2.FillRectangle(b, /*0*/SizeBounds3, 0, buttonSize.Width - SizeBounds2-SizeBounds3, buttonSize.Height);
                //            g2.FillRectangle(b, buttonSize.Width - SizeBounds2, SizeBounds2, SizeBounds2 - 1, buttonSize.Height - SizeBounds);
                //            g2.FillEllipse(b, new Rectangle(buttonSize.Width - SizeBounds - 1, 0, SizeBounds, SizeBounds));
                //            g2.FillEllipse(b, new Rectangle(buttonSize.Width - SizeBounds - 1, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds));

                //            //small
                //            g2.FillEllipse(b, new Rectangle(0, 0, SizeBounds3, SizeBounds3));
                //            g2.FillEllipse(b, new Rectangle(0, buttonSize.Height - SizeBounds3 - 1, SizeBounds3, SizeBounds3));
                //            g2.FillRectangle(b, 0, SizeBounds6, SizeBounds2, buttonSize.Height-SizeBounds3);

                //            // Bounds
                //            g2.DrawLine(sb, SizeBounds6, 0, buttonSize.Width - SizeBounds2/*-1*/+1-SizeBounds6, 0);
                //            g2.DrawLine(sb, 0, SizeBounds6, 0, buttonSize.Height-1/*+1*/-SizeBounds6);
                //            g2.DrawLine(sb, SizeBounds6, buttonSize.Height - 1, buttonSize.Width - SizeBounds2/*-1*/+1-SizeBounds6, buttonSize.Height - 1);
                //            g2.DrawLine(sb, buttonSize.Width - 1, SizeBounds2-1, buttonSize.Width - 1, buttonSize.Height - SizeBounds2 - 1-1);

                //            g2.SmoothingMode = SmoothingMode.HighQuality;
                //            g2.DrawArc(sb, new Rectangle(buttonSize.Width - SizeBounds-1, 0/*+1*/, SizeBounds, SizeBounds + 6-6/**/), 270F, 90F);
                //            g2.DrawArc(sb, new Rectangle(buttonSize.Width - SizeBounds - 1, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds), 0F, 90F);

                //            //small
                //            g2.DrawArc(sb, new Rectangle(0, 0, SizeBounds3, SizeBounds3/**/), 180F, 90F);
                //            g2.DrawArc(sb, new Rectangle(0, buttonSize.Height-SizeBounds3-1, SizeBounds3, SizeBounds3/**/),90F,  90F);
                //            break;

                //        case Orientation.Right:
                //            //Inside
                //            g2.FillRectangle(b, SizeBounds2, 0, buttonSize.Width - SizeBounds2-SizeBounds3, buttonSize.Height);
				            //g2.FillRectangle(b, 0, SizeBounds2, SizeBounds2, buttonSize.Height - SizeBounds);
				            //g2.FillEllipse(b, new Rectangle(1, 0, SizeBounds, SizeBounds));
				            //g2.FillEllipse(b, new Rectangle(0, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds));

                //            //small
                //            g2.FillEllipse(b, new Rectangle(buttonSize.Width-SizeBounds3-1, 0, SizeBounds3, SizeBounds3));
                //            g2.FillEllipse(b, new Rectangle(buttonSize.Width-SizeBounds3-1, buttonSize.Height - SizeBounds3 - 1, SizeBounds3, SizeBounds3));
                //            g2.FillRectangle(b, buttonSize.Width-SizeBounds3-1, SizeBounds6, SizeBounds2, buttonSize.Height-SizeBounds3);

				            //// Bounds
				            //g2.DrawLine(sb, SizeBounds2, 0, buttonSize.Width /*+*//*- SizeBounds2*/-SizeBounds6, 0);
				            //g2.DrawLine(sb, buttonSize.Width - 1, /*0*/SizeBounds6, buttonSize.Width -1, buttonSize.Height-SizeBounds6);
				            //g2.DrawLine(sb, SizeBounds2, buttonSize.Height - 1, buttonSize.Width /*+*//*- SizeBounds2*/-SizeBounds6, buttonSize.Height - 1);
				            //g2.DrawLine(sb, 0, SizeBounds2, 0, buttonSize.Height - SizeBounds2 - 1);

				            //g2.SmoothingMode = SmoothingMode.HighQuality;
				            //g2.DrawArc(sb, new Rectangle(0, 0, SizeBounds, SizeBounds + 6), 180F, 90F);
				            //g2.DrawArc(sb, new Rectangle(0, buttonSize.Height - SizeBounds - 1, SizeBounds, SizeBounds), 90F, 90F);

                //            //small
                //            g2.DrawArc(sb, new Rectangle(buttonSize.Width-SizeBounds3-1, 0, SizeBounds3, SizeBounds3/**/), 270F, 90F);
                //            g2.DrawArc(sb, new Rectangle(buttonSize.Width-SizeBounds3-1, buttonSize.Height-SizeBounds3-1, SizeBounds3, SizeBounds3/**/),0F,  90F);
                //            break;

                //        default:
                            //old
                            //g2.FillRectangle(b, 1, 1, buttonSize.Width-2, buttonSize.Height-2);
				            //g2.DrawRectangle(sb, new Rectangle(0, 0, buttonSize.Width-1, buttonSize.Height-1));

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
                            g2.DrawArc(sb, new Rectangle(buttonSize.Width-SizeBounds3-1, 0, SizeBounds3, SizeBounds3), 270F, 90F);
                            g2.DrawArc(sb, new Rectangle(buttonSize.Width-SizeBounds3-1, buttonSize.Height-SizeBounds3-1, SizeBounds3, SizeBounds3),0F,  90F);
                            g2.DrawArc(sb, new Rectangle(0, 0, SizeBounds3, SizeBounds3), 180F, 90F);
                            g2.DrawArc(sb, new Rectangle(0, buttonSize.Height-SizeBounds3-1, SizeBounds3, SizeBounds3),90F,  90F);


                           // break;
                    //}
                }

               // if (Constants.Shadow) {
                    //using (Bitmap bit = NativeMethods.SetBitmapOpacity(nb, .3f)){
                    //    using (Bitmap bz2 = new Bitmap((int)(buttonSize.Width/Global.TextBlur), (int)(buttonSize.Height/Global.TextBlur))){
                    //        using (Graphics gT = Graphics.FromImage(bz2)) {
                    //            gT.CompositingQuality=CompositingQuality.HighQuality;
                    //            gT.InterpolationMode=InterpolationMode.HighQualityBicubic;
                    //            gT.PixelOffsetMode=PixelOffsetMode.HighQuality;
                    //            gT.SmoothingMode=SmoothingMode.HighQuality;

                    //            gT.DrawImage(bit, new Rectangle(0, 0, bz2.Width, bz2.Height));
                    //        }

                    //        g.CompositingQuality=CompositingQuality.HighQuality;
                    //        g.InterpolationMode=InterpolationMode.HighQualityBicubic;
                    //        g.PixelOffsetMode=PixelOffsetMode.HighQuality;
                    //        g.SmoothingMode=SmoothingMode.HighQuality;

                    //        g.DrawImage(bz2, new RectangleF(3f, 2.5f, buttonSize.Width, buttonSize.Height));
                    //        g.DrawImage(bz2, new RectangleF(2.5f, 3f, bit.Width, bit.Height));

                    //        g.DrawImage(nb, new Point(1, 1));
                    //    }
                    //}

                    //using (Bitmap small=new Bitmap((int)(buttonSize.Width*Global.TextBlur)+2, (int)(buttonSize.Height*Global.TextBlur)+2)){
                    //    using (Graphics gT = Graphics.FromImage(small)) {
                    //        gT.CompositingQuality=CompositingQuality.HighQuality;
                    //        gT.InterpolationMode=InterpolationMode.HighQualityBicubic;
                    //        gT.PixelOffsetMode=PixelOffsetMode.Half;
                    //        gT.SmoothingMode=SmoothingMode.HighQuality;

                    //        gT.DrawImage(nb, new Rectangle(1, 1, small.Width-2, small.Height-2));
                    //        gT.PixelOffsetMode=PixelOffsetMode.HighQuality;
                    //    }

                    //    using (Bitmap shadow=BlackStyle(small)) {

                g.PixelOffsetMode=PixelOffsetMode.Half;
                    if (State.None==currentState){
                            if (shadow!=null) {
                            g.DrawImage(shadow, new RectangleF(3f-0.5f, 2.5f+1, buttonSize.Width+1, buttonSize.Height+1));
                            g.DrawImage(shadow, new RectangleF(2.5f-0.5f, 3f+1, buttonSize.Width+1, buttonSize.Height+1));
                        } else SetButton();

                        g.DrawImage(nb, new Point(1, 1));
                    if (!Custom) g.FillRectangle(new SolidBrush(color),new Rectangle(4,4,buttonSize.Width-4-2,buttonSize.Height-4-2));
               
                           // NativeMethods.Text(g, Constants.font14,Text,pos.X,pos.Y,255);
                    }else if (State.Click==currentState){
                        //    if (shadow!=null) {
                        //    g.DrawImage(shadow, new RectangleF(3f, 2.5f, buttonSize.Width+1, buttonSize.Height+1));
                        //    g.DrawImage(shadow, new RectangleF(2.5f, 3f, buttonSize.Width+1, buttonSize.Height+1));
                        //} else SetButton();

                        g.DrawImage(nb, new Point(1, 1+1));
                       if (!Custom)  g.FillRectangle(new SolidBrush(color),new Rectangle(4,4+1,buttonSize.Width-4-2,buttonSize.Height-4-2));
                           // NativeMethods.Text(g, Constants.font14,Text,pos.X,pos.Y+1,255);
                    }else{
                            if (shadow!=null) {
                            g.DrawImage(shadow, new RectangleF(3f-0.5f, 2.5f+1, buttonSize.Width+1, buttonSize.Height+1));
                            g.DrawImage(shadow, new RectangleF(2.5f-0.5f, 3f+1, buttonSize.Width+1, buttonSize.Height+1));
                        } else SetButton();

                        g.DrawImage(nb, new Point(1, 1));
                       if (!Custom)  g.FillRectangle(new SolidBrush(color),new Rectangle(4,4,buttonSize.Width-4-2,buttonSize.Height-4-2));
                          //  NativeMethods.Text(g, Constants.font14,Text,pos.X,pos.Y,255);
                    }
                        g.PixelOffsetMode=PixelOffsetMode.HighQuality;

                    //    }
                    //}
               // }
                //else {
                //    g.DrawImage(nb, new Point(1, 1));

                //    NativeMethods.Text(g, Constants.font14,Text,pos.X,pos.Y,255);
                //}
            }

            //g.TextContrast=0;
            //g.TextRenderingHint=System.Drawing.Text.TextRenderingHint.AntiAlias;
            //if (Constants.Shadow) {
            //    g.PixelOffsetMode = PixelOffsetMode.Half;

            //    if (disamble) {
            //        g.DrawString(Text, Font, brushShadow, new Point(pos.X+1, pos.Y));
            //        //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(30, Color.Gray)), new Point(pos.X, pos.Y+1));
            //        //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(30, Color.Gray)), new Point(pos.X+1, pos.Y+1));
            //        //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(30, Color.Gray)), new Point(pos.X+2, pos.Y+1));
            //        //g.DrawString(Text, Font, new SolidBrush(Color.FromArgb(30, Color.Gray)), new Point(pos.X+1, pos.Y+2));
            //    } else {
            //        //g.DrawString(Text, Font, brushShadow, new Point(pos.X+1, pos.Y));
            //        //g.DrawString(Text, Font, brushShadow, new Point(pos.X, pos.Y+1));
            //        g.DrawString(Text, Font, brushShadow, new Point(pos.X+1, pos.Y+1));
            //    }
            //    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //}

            //if (disamble) g.DrawString(Text, Font, new SolidBrush(Color.Gray), pos);
            //else g.DrawString(Text, Font, new SolidBrush(Color.Black), pos);

            // g.TextContrast=0;
            //g.TextRenderingHint=System.Drawing.Text.TextRenderingHint.AntiAlias;
            //if (Constants.Shadow) {
            //    g.PixelOffsetMode = PixelOffsetMode.Half;
            // // Console.WriteLine( g.TextContrast);
            //    if (disamble) {
            //        g.DrawString(Text, Font, brushShadow, new Point(pos.X+1, pos.Y));
            //      //  g.DrawString(list[selected], Font, new SolidBrush(Color.FromArgb(30, Color.Gray)), new Point(pos.X, pos.Y+1));
            //        //g.DrawString(list[selected], Font, new SolidBrush(Color.FromArgb(30, Color.Gray)), new Point(pos.X+1, pos.Y+1));

            //        //g.DrawString(list[selected], Font, new SolidBrush(Color.FromArgb(30, Color.Gray)), new Point(pos.X+2, pos.Y+1));
            //        //g.DrawString(list[selected], Font, new SolidBrush(Color.FromArgb(30, Color.Gray)), new Point(pos.X+1, pos.Y+2));
            //    } else {
            //      // g.DrawString(list[selected], Font, brushShadow, new Point(pos.X+1, pos.Y));
            //       // g.DrawString(list[selected], Font, brushShadow, new Point(pos.X, pos.Y+1));
            //        g.DrawString(Text, Font, brushShadow, new Point(pos.X+1, pos.Y+1));
            //    }
            //    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //}

            //if (disamble) g.DrawString(Text, Font, new SolidBrush(Color.Gray), pos);
            //else g.DrawString(Text, Font, new SolidBrush(Color.Black), pos);


        }

        protected override void OnLostFocus(EventArgs e) {
            need=255;
            base.OnLostFocus(e);
        }

        protected override void OnGotFocus(EventArgs e) {
            need=190;
            base.OnGotFocus(e);
        }

       Bitmap BlackStyle(Bitmap b) {
            Bitmap ret=new Bitmap(b.Width,b.Height);
        //   BitmapData bd=   b.LockBits(new Rectangle(0,0,b.Width,b.Height), ImageLockMode.ReadOnly, PixelFormat.Alpha);

            for (int x=0; x<b.Width; x++) {
                for (int y=0; y<b.Height; y++) {
                    ret.SetPixel(x, y, Color.FromArgb(b.GetPixel(x,y).A/3, 0, 0, 0));
                }
            }
        //    b.UnlockBits(bd);

            return ret;
        }

        void SetButton(){
            Size buttonSize=new Size(Size.Width-3,Size.Height-3);

		    Pen sb= new Pen(new SolidBrush(Color.Black));
		    Brush b= new LinearGradientBrush(ClientRectangle, Color.FromArgb(alpha, alpha, alpha), Color.FromArgb(alpha-40, alpha-40, alpha-40), 90);

            using (Bitmap nb=new Bitmap(buttonSize.Width,buttonSize.Height)) {
                using (Graphics g2 = Graphics.FromImage(nb)) {
                    g2.FillRectangle(b, 1, 1, buttonSize.Width-2, buttonSize.Height-2);

				    g2.DrawRectangle(sb, new Rectangle(0, 0, buttonSize.Width-1, buttonSize.Height-1));
                }
             
                using (Bitmap small=new Bitmap((int)(buttonSize.Width*Constants.TextBlur)+2, (int)(buttonSize.Height*Constants.TextBlur)+2)){
                    using (Graphics gT = Graphics.FromImage(small)) {
                        gT.CompositingQuality=CompositingQuality.HighQuality;
                        gT.InterpolationMode=InterpolationMode.HighQualityBicubic;
                        gT.PixelOffsetMode=PixelOffsetMode.Half;
                        gT.SmoothingMode=SmoothingMode.HighQuality;
                        using (Bitmap h=NativeMethods.SetBitmapOpacity(nb,0.5f))
                        gT.DrawImage(h, new Rectangle(1, 1, small.Width-2, small.Height-2));
                    //    gT.PixelOffsetMode=PixelOffsetMode.HighQuality;
                    }

                    if (shadow!=null) shadow.Dispose();
                    shadow=BlackStyle(small);
                }
            }
        }

        protected override void Dispose(bool disposing) {
            if (timer.Enabled) timer.Stop();
            shadow?.Dispose();
            brushShadow?.Dispose();
            timer?.Dispose();

            base.Dispose(disposing);
        }
    }
}