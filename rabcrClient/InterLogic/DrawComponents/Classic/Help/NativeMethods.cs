using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace rabcrClient {
    static class NativeMethods{
     //   public static FontFamily ff;
   // public static PrivateFontCollection pf;

        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nheightRect,
            int nweightRect
        );

        public static void SetPlaceholder(string text,IntPtr handle)=> SendMessage(handle, 0x1501, IntPtr.Zero, text);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static GraphicsPath RoundedRect(RectangleF bounds, float radius) {
            float diameter = radius * 2f;

            RectangleF arc = new RectangleF(bounds.Location.X,bounds.Location.Y,diameter, diameter);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0) {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc
            path.AddArc(arc, 180, 90);

            // top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius) {
            using (GraphicsPath path = RoundedRect(bounds, cornerRadius)) {
                graphics.DrawPath(pen, path);
            }
        }

        public static void FillRoundedRectangle(this Graphics graphics, Brush brush, RectangleF bounds, float cornerRadius) {
            using (GraphicsPath path = RoundedRect(bounds, cornerRadius)) {
                graphics.FillPath(brush, path);
            }
        }

        //public static Bitmap SetBitmapOpacity(Bitmap image, float opacity) {
        //    Bitmap bmp = new Bitmap(image.Width, image.Height);

        //    using (Graphics gfx = Graphics.FromImage(bmp)) {

        //        ColorMatrix matrix = new ColorMatrix {
        //            Matrix33=opacity,
        //            Matrix00=-1
        //        };
        //        matrix.Matrix11 = matrix.Matrix22 = -1;

        //        ImageAttributes attributes = new ImageAttributes();

        //        attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

        //        gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
        //    }
        //    return bmp;
        //}

        public static Bitmap SetBitmapOpacity(Bitmap image, float opacity) {
            Bitmap bmp = new Bitmap(image.Width, image.Height);

            using (Graphics gfx = Graphics.FromImage(bmp)) {
                ColorMatrix matrix = new ColorMatrix {
                    Matrix33=opacity
                };

                ImageAttributes attributes = new ImageAttributes();

                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        public static void Text(Graphics g, Font f,string text, int x, int y,int a) {
            g.CompositingQuality=CompositingQuality.HighQuality;
            g.InterpolationMode=InterpolationMode.HighQualityBicubic;
            g.SmoothingMode=SmoothingMode.HighQuality;
            g.TextRenderingHint=TextRenderingHint.AntiAlias;
            g.PixelOffsetMode=PixelOffsetMode.None;
            g.TextContrast=0;

          //  if (Constants.Shadow) {
                using (Bitmap img = new Bitmap((int)g.MeasureString(text, f).Width+4, (int)g.MeasureString(text, f).Height+4)) {
                    using (Graphics gg = Graphics.FromImage(img)) {
                        gg.CompositingQuality=CompositingQuality.HighQuality;
                        gg.InterpolationMode=InterpolationMode.HighQualityBicubic;
                        gg.SmoothingMode=SmoothingMode.HighQuality;
                        gg.TextContrast=0;
                        gg.PixelOffsetMode=PixelOffsetMode.Half;
                        gg.TextRenderingHint=TextRenderingHint.AntiAlias;
                        gg.DrawString(text, f, new SolidBrush(Color.FromArgb(a,Color.Black)), new PointF(Constants.TextBlur, Constants.TextBlur));
                      //  gg.PixelOffsetMode=PixelOffsetMode.HighQuality;
                    }
                    using (Bitmap img2 = new Bitmap(img, new Size((int)(img.Size.Width*Constants.TextBlur), (int)(img.Size.Height*Constants.TextBlur))))
                        g.DrawImage(SetBitmapOpacity(img2, Constants.TextTransparentry), new RectangleF(x+0.5f, y+0.5f, img.Size.Width, img.Size.Height));
                }
          //  }

            g.DrawString(text, f, new SolidBrush(Color.FromArgb(a,Color.Black)), new Point(x, y));
        }

        public static void Text(Graphics g, string text, float x, float y, Brush c) {
            g.CompositingQuality=CompositingQuality.HighQuality;
           // g.InterpolationMode=InterpolationMode.HighQualityBicubic;
            g.SmoothingMode=SmoothingMode.HighQuality;
            g.TextRenderingHint=TextRenderingHint.AntiAlias;
            g.PixelOffsetMode=PixelOffsetMode.None;
            g.TextContrast=0;

           // if (Constants.Shadow) {
                SizeF m=g.MeasureString(text, Constants.font14);
                using (Bitmap img = new Bitmap((int)m.Width+4, (int)m.Height+4)) {
                    using (Graphics gg = Graphics.FromImage(img)) {
                        gg.CompositingQuality=CompositingQuality.HighQuality;
                      //  gg.InterpolationMode=InterpolationMode.HighQualityBicubic;
                        gg.SmoothingMode=SmoothingMode.HighQuality;
                        gg.TextContrast=0;
                        gg.PixelOffsetMode=PixelOffsetMode.Half;
                        gg.TextRenderingHint=TextRenderingHint.AntiAlias;

                        gg.DrawString(text, Constants.font14, Brushes.Black, new PointF(Constants.TextBlur, Constants.TextBlur));
                    }
                    using (Bitmap img2 = new Bitmap(img, new Size((int)(img.Size.Width*Constants.TextBlur), (int)(img.Size.Height*Constants.TextBlur))))
                        g.DrawImage(SetBitmapOpacity(img2, Constants.TextTransparentry), new RectangleF(x+0.5f, y+0.5f, img.Size.Width, img.Size.Height));
                }
          //  }

            g.DrawString(text, Constants.font14, c, new PointF(x, y));
        }

        public static void TextUnderline(Graphics g, string text, float x, float y, Brush c) {
            g.CompositingQuality=CompositingQuality.HighQuality;
          //  g.InterpolationMode=InterpolationMode.HighQualityBicubic;
            g.SmoothingMode=SmoothingMode.HighQuality;
            g.TextRenderingHint=TextRenderingHint.AntiAlias;
            g.PixelOffsetMode=PixelOffsetMode.None;
            g.TextContrast=0;

            Font f2=new Font(Constants.font14,FontStyle.Underline);

           // if (Constants.Shadow) {
                SizeF m=g.MeasureString(text, Constants.font14);
                using (Bitmap img = new Bitmap((int)m.Width+4, (int)m.Height+4)) {
                    using (Graphics gg = Graphics.FromImage(img)) {
                        gg.CompositingQuality=CompositingQuality.HighQuality;
                       // gg.InterpolationMode=InterpolationMode.HighQualityBicubic;
                        gg.SmoothingMode=SmoothingMode.HighQuality;
                        gg.TextContrast=0;
                        gg.PixelOffsetMode=PixelOffsetMode.Half;
                        gg.TextRenderingHint=TextRenderingHint.AntiAlias;

                        gg.DrawString(text, f2, Brushes.Black, new PointF(Constants.TextBlur, Constants.TextBlur));

                      //  gg.PixelOffsetMode=PixelOffsetMode.HighQuality;
                    }
                    using (Bitmap img2 = new Bitmap(img, new Size((int)(img.Size.Width*Constants.TextBlur), (int)(img.Size.Height*Constants.TextBlur))))
                        g.DrawImage(SetBitmapOpacity(img2, Constants.TextTransparentry), new RectangleF(x+0.5f, y+0.5f, img.Size.Width, img.Size.Height));
                }
           // }

            g.DrawString(text, f2, c, new PointF(x, y));
        }

        //public static int Abs(int x) {
        //    return x>0 ? x: -x;
        //}
    }
}