using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormTextInput: Form {
        public string ret;
        public bool save;
        public FormTextInput(string txt) {
            InitializeComponent();
            save=false;
            gTextBox1.textBox.Text=txt;
           Text= gTextPanel1.Text=Lang.Texts[142];
            gButton1.Text=Lang.Texts[58];
            gButton2.Text=Lang.Texts[57];
        }

        private void GButton1_Click(object sender, EventArgs e) {
            ret=gTextBox1.textBox.Text;
            save=true;
            Close();
        }

        private void GButton2_Click(object sender, EventArgs e) {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e) {
            gTextBox1.textBox.Text+="☺️";
        }

        private void Button1_Click(object sender, EventArgs e) {
            gTextBox1.textBox.Text+="☹️";
        }

        private void Button3_Click(object sender, EventArgs e) {
            gTextBox1.textBox.Text+="❤️";
        }
    }
}
