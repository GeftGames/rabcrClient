using System;
using System.Globalization;
using System.Windows.Forms;

namespace rabcrClient {
    public partial class FormBanCountry: Form {
        public bool RunGame;

        public FormBanCountry(string day) {
            InitializeComponent();
            Focus();
            RegionInfo ri=RegionInfo.CurrentRegion;
            geDoPanel1.Load(
                "<Bold>Your country ("+ri.EnglishName+") is on the ban-country-list</Bold>"+Environment.NewLine+
                "<Italic>What does it mean?</Italic>" +Environment.NewLine+
                "Well, it means that your country has problems with:" +Environment.NewLine+
                "<DarkRed>Human rights</DarkRed>, <DarkGreen>government</DarkGreen>, <DarkBlue>censorship</DarkBlue> or <Purple>corruption</Purple>, ..." +Environment.NewLine+

                "<Italic>Why we show this window?</Italic>" +Environment.NewLine+
                "We want to improve the position of people in the world."+Environment.NewLine+
                "<Italic>What if I live outside and it shows?</Italic>" + Environment.NewLine+
                "If you live outside this country, change country in computer settings"+Environment.NewLine+
                "to your's current country." + Environment.NewLine+
                (day!=null?   Environment.NewLine+"Do you know that today is '"+day+"'?":"")+
                Environment.NewLine+
                "<Mark>Despite this limitation, you can run the game.</Mark>"
            );
        }

        void GButton1_Click(object sender, EventArgs e) {
            Environment.Exit(0);
            Close();
        }

        void GButton2_Click(object sender, EventArgs e) {
            RunGame=true;
            Close();
        }
    }
}
