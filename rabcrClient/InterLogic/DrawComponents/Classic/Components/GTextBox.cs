using System;
using System.Windows.Forms;

//namespace rabcrClient {
    public partial class GTextBox:UserControl {

        string placeholder;
       public readonly Timer timer;

        public GTextBox() {
            InitializeComponent();
            DoubleBuffered=true;

            textBox.Font=Constants.font14;

            textBox.LostFocus+=TextBox_LostFocus;
            textBox.GotFocus+=TextBox_GotFocus;

            (timer=new Timer {
                Enabled=true,
                Interval=100,
            }).Tick+=XTextBox_Tick;

            if (textBox.SelectionLength>0) {
                if (bounds.drawClearPix) {
                    bounds.drawClearPix=false;
                    bounds.Invalidate();
                    textBox.SetRound(5);
                }
            } else {
                if (!bounds.drawClearPix) {
                    bounds.drawClearPix=true;
                    bounds.Invalidate();
                    textBox.SetRound(6);
                }
            }

            AdvancedTextbox_Resize(this,new EventArgs());
        }

        void XTextBox_Tick(object sender, EventArgs e) {
            if (this.IsDisposed)timer.Stop();
            if (textBox.SelectionLength>0){
                if (bounds.drawClearPix) {
                    bounds.drawClearPix=false;
                    bounds.Invalidate();
                    textBox.SetRound(5);
                }
            } else {
                if (!bounds.drawClearPix) {
                    bounds.drawClearPix=true;
                    bounds.Invalidate();
                    textBox.SetRound(6);
                }
            }
        }

        protected override void OnVisibleChanged(EventArgs e) {
            base.OnVisibleChanged(e);

            if (Visible && !Disposing) NativeMethods.SetPlaceholder(placeholder, textBox.Handle);
        }

        void TextBox_GotFocus(object sender, EventArgs e) {
            bounds.Selected=false;
            bounds.Invalidate();
        }

        void TextBox_LostFocus(object sender, EventArgs e) {
            bounds.Selected=true;
            bounds.Invalidate();
        }

        void AdvancedTextbox_Resize(object sender, EventArgs e) {
            if (Width<7)Width=7;

            textBox.Location=new System.Drawing.Point(3,3);
            textBox.Width=Width-7;
            Height = textBox.Height+7;
        }

        public string PlaceHolder {
            get { return placeholder; }
            set { placeholder=value;  }
        }

        public string TextInTextBox {
            get { return textBox.Text; }
            set => textBox.Text=value;
        }

        public override string Text {
            get { return textBox.Text; }
        }

        public GBounds.StateSelect StateSelect {
            get { return bounds.state; }
            set => bounds.state=value;
        }

      //protected override void Dispose(bool disposing) {
      //  if (timer.Enabled)timer.Stop();
      //  timer?.Dispose();
      //  base.Dispose(disposing);
    }
    //}
//}