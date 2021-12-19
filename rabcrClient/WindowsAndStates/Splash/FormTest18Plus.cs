using System;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormTest18Plus: Form {
        int NumOne;
        string NumTwo;
      //  string NumThree;
        public bool OK=false;

        public int time;


        void Generate(){
            NumOne=(FastRandom.Int(5)+3);

            time=FastRandom.Int(3)+2;
           // int time2=FastRandom.Next(3)+2;
            //length=time*10;
            //=length/rRnd;
             gTextPanel1.Text=Text=Lang.Texts[283];
           gButton1.Text=Lang.Texts[58];
            gButton2.Text=Lang.Texts[57];
            //speed=(length*time2)/time;

            int m=FastRandom.Int(3)+1;

            geDoPanel1.Load(Lang.Texts[281].Replace("%num%",(NumOne*2).ToString()));

            geDoPanel2.Load(Lang.Texts[282].Replace("%smt%",num2()));

            geDoPanel3.Load(Lang.Texts[291].Replace("%speed%",(10*m).ToString()).Replace("%length%",(time*10*m).ToString()));

            string num2(){
                switch (FastRandom.Int(6)){
                    default:
                        NumTwo=Lang.Texts[284];
                        return "H<Subscript>2</Subscript>O";

                    case 1:
                        NumTwo=Lang.Texts[285];
                        return "CO<Subscript>2</Subscript>";

                    case 2:
                        NumTwo=Lang.Texts[286];
                        return "H<Subscript>2</Subscript>SO<Subscript>4</Subscript>";

                    case 3:
                        NumTwo=Lang.Texts[287];
                        return "NaOH";

                    case 4:
                        NumTwo=Lang.Texts[288];
                        return "Fe";

                    case 5:
                        NumTwo=Lang.Texts[289];
                        return "HCl";
                }
            }

            //string num3(){
            //    switch (FastRandom.Next(6)){
            //        default:
            //            NumThree="služba";
            //            return "service";

            //        case 1:
            //            NumThree="konec";
            //            return "end";

            //        case 2:
            //            NumThree="hledat";
            //            return "find";

            //        case 3:
            //            NumThree="práce";
            //            return "job";

            //        case 4:
            //            NumThree="přihlásit se";
            //            return "sign in";

            //        case 5:
            //            NumThree="chyba";
            //            return "error";
            //    }
            //}
        }

        public FormTest18Plus() {
            InitializeComponent();
          Generate();
        }

        private void GeDoPanel2_Resize(object sender, EventArgs e) {
            Refresh();
        }

        private void GButton1_Click(object sender, EventArgs e) {
            if (gTextBox1.textBox.Text==NumOne.ToString() && gTextBox2.textBox.Text.ToString()==NumTwo.ToString() && gTextBox3.textBox.Text.ToLower()==time.ToString().ToLower()){ OK=true; /*Hide()*/Close();}
            else {
                MessageBox.Show(Lang.Texts[290]);
                Generate();
                gTextBox1.textBox.Text="";
                gTextBox2.textBox.Text="";
                gTextBox3.textBox.Text="";
            }
        }

        private void GButton2_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
