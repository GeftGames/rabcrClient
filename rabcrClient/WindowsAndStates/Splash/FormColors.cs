using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormColors: Form {

        GColor[] colors;
        const int SizeW=60, SizeH=40;
        readonly Microsoft.Xna.Framework.Color[] xnaCols;
        bool setting=false;
        public Microsoft.Xna.Framework.Color current;
        public bool setted=false;
        public bool ok;

        private void FormColors_Resize(object sender, System.EventArgs e) {
            SetColors();
        }

        public FormColors(Microsoft.Xna.Framework.Color[] col) {
            InitializeComponent();
            xnaCols=col;
            DoubleBuffered=true;
            textPanel8.Resize+=TextPanel8_Resize;
            SetColors();
        }

        void TextPanel8_Resize(object sender, System.EventArgs e) => textPanel8.Location=new Point(Width/2-textPanel8.Width/2, textPanel8.Location.Y);

        private void CustomButton1_Click(object sender, System.EventArgs e) {
            if (!customButton1.Disamble){
                ok=true;
                Close();
            }
        }

        private void CustomButton2_Click(object sender, System.EventArgs e) {
            Close();
        }

        void SetColors(){
            if (xnaCols==null)return;
            if (setting)return;
            setting=true;
            if (colors!=null){
                foreach (GColor cc in colors){
                    Controls.Remove(cc);
                }
            }
            List<GColor> c=new List<GColor>();
            int x=10, y=60;

            foreach (Microsoft.Xna.Framework.Color u in xnaCols) {
                Color z = Color.FromArgb(u.R, u.G, u.B);

                GColor n = new GColor {
                    color=z
                };

                n.Location=new Point(x, y);
                n.Size=new Size(SizeW, SizeH);
                n.IsSelect += SetColor;

                void SetColor(){
                    foreach (GColor p in colors) {
                        if (p==n){
                             p.Selected=true;
                            Color l=p.color;
                            current=new Microsoft.Xna.Framework.Color(l.R,l.G,l.B);
                            setted=true;
                        }else{
                            p.Selected=false;
                        }
                    }
                    customButton1.Disamble=false;
                }
                x+=SizeW+10;

                if (x+SizeW+10>Width){x=10; y+=SizeH+10;}

                c.Add(n);
                Controls.Add(n);
            }

            GColor customColor = new GColor {
                color=Color.Transparent
            };

            customColor.Location=new Point(x, y);
            customColor.Size=new Size(SizeW, SizeH);
            customColor.IsSelect += SetCustomColor;

             c.Add(customColor);
                Controls.Add(customColor);

            Height=20+y+120;

            colors=c.ToArray();
            setting=false;

            void SetCustomColor() {
                ColorDialog cd=new ColorDialog();
                DialogResult dr=cd.ShowDialog();

                if (dr==DialogResult.OK) {
                    current=new Microsoft.Xna.Framework.Color(cd.Color.R, cd.Color.G, cd.Color.B);
                    setted=true;
                    ok=true;
                    Close();
                }
            }
        }
    }
}