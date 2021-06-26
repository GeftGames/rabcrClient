using System;
using System.Windows.Forms;
using System.Drawing;

//namespace rabcrClient {
    public class GPreTextBox : TextBox {
        public int round=6;
        public GPreTextBox() {
            BorderStyle=BorderStyle.None;
            SetStyle(ControlStyles.SupportsTransparentBackColor,true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer,true);
            Resize+=RoundedTextBox_Resize;
        //    Font=Constants.font14;
        }

        void RoundedTextBox_Resize(object sender, EventArgs e) => OnCreateControl();

        protected override void OnCreateControl() {
            base.OnCreateControl();
            try {
                Region=Region.FromHrgn(NativeMethods.CreateRoundRectRgn(0, 0, Width+1, Height+1, round, round));
            } catch { }
        }

        public void SetRound(int v){
            round=v;
            OnCreateControl();
        }
    }
//}