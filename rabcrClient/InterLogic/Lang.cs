using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace rabcrClient {
    enum SpacialLanguages{
        Latin,
        Japanese,

        Arabic,
        Ujgur,
        Urdu,
    }

    static class Lang {
        public static string[] Texts;
        public static Language[] Languages;
        static string cl;

        //public static bool IsJapaneseFontFile {
        //    get {
        //        if (Languages!=null) return Languages[Setting.CurrentLanguage].FontFile=="japanese";
        //        return false;
        //    }
        //}

        //public static bool IsArabicFontFile {
        //    get {
        //        if (Languages!=null) return Languages[Setting.CurrentLanguage].FontFile=="arabic";
        //        return false;
        //    }
        //}

        //public static bool IsLatin {
        //    get {
        //        if (Languages!=null) return Languages[Setting.CurrentLanguage].FontFile=="latin";
        //        return false;
        //    }
        //}
        public static bool IsUjgur {
            get {
                if (Languages!=null){
                    if (Languages[Setting.CurrentLanguage].Name=="uig") return true;
                }
                return false;
            }
        }
        public static bool IsArabic {
            get {
                if (Languages!=null){
                    if (Languages[Setting.CurrentLanguage].Name=="ara") return true;
                }
                return false;
            }
        }

        public static void Load() {
            SetUp(false);
        }

        public static void SetUp(bool sameLanguageAsSystem) {
            XmlDocument file = new XmlDocument();
            XmlNode data=null;
            
            try {
                file.Load(new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"\\RabcrData\\"+Setting.StyleName+"\\Lang\\lang.xml");
            } catch (Exception ex) {
                MessageBox.Show("Language file is corrupted/Jazykový soubor je poškozen\r\nCheck file \"Lang.xml\"\r\n\r\nDetails/Podrobnosti:\r\n"+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            List<Language> l=new List<Language>();


            foreach(XmlNode node in file.DocumentElement.ChildNodes) {
                if (node.Name=="Langs") {
                    foreach (XmlNode n in node.ChildNodes) {
                        if (n.Attributes["EnglishName"].Value==null) continue;
                        if (n.Attributes["NativeName"].Value==null) continue;
                        if (n.Attributes["Name"].Value==null) continue;

                        Language ll=new Language {
                            EnglishName=n.Attributes["EnglishName"].Value,
                            NativeName=n.Attributes["NativeName"].Value,
                            Name=n.Attributes["Name"].Value,
                            FontFile=n.Attributes["FontFile"]?.Value,
                            _Base=n.Attributes["Base"]?.Value,
                           // TwoLetterISOLanguageName=n.Attributes["TwoLetterISOLanguageName"]?.Value,
                         //   ThreeLetterISOLanguageName=n.Attributes["ThreeLetterISOLanguageName"]?.Value,
                          //  TranslationQuality=int.Parse(n.Attributes["TranslationQuality"]?.Value),
                        //    UseBase=n.Attributes["UseBase"]?.Value=="true",
                        };
                        {
                            // Solve category
                            XmlAttribute cat=n.Attributes["Flag"];
                            if (cat!=null){
                                string rawCategory=cat.Value;
                                ll.Flags=rawCategory.Split(',');
                            }
                        }
                        {
                            // Solve flags
                            XmlAttribute cat=n.Attributes["Category"];
                            if (cat!=null){
                                string rawCategory=cat.Value;
                                ll.Category=rawCategory.Split(';');
                            }
                        }
                        //if (ll.TranslationQuality>6)ll.TranslationQuality=6;
                        //if (ll.TranslationQuality<0)ll.TranslationQuality=0;


                        l.Add(ll);
                    }
                    break;
                }
            }

            Languages=l.OrderBy(i => i.NativeName).ToArray();
            {
                int ii=0;

                //bool baseA=false;
                foreach (Language ll in Languages){
                    if (!string.IsNullOrEmpty(ll._Base)) {
                        foreach (Language l2 in Languages){
                            if (l2.Name==ll._Base){
                                ll.Base=l2;
                    //            baseA=true;
                                break;
                            }
                        }
                   //     if (baseA)break;
                    }

                    ll.id=ii;
                    ii++;
                }
            }

            foreach (XmlNode node in file.DocumentElement.ChildNodes) {
                if (node.Name=="Data") {
                    data=node;
                    break;
                }
            }

            foreach (XmlNode node in data.ChildNodes) {
                foreach (XmlNode n in node.ChildNodes) {
                    foreach (Language ll in Languages){
                        if (n.Name==ll.Name) {
                            ll.Capacity++;
                            break;//
                        }
                    }
                }
            }


            {
                int max=0;

                foreach (XmlNode node in data.ChildNodes) {
                    if (int.TryParse(node.Attributes[0].Value, out int v)) {
                        if (v>max)max=v;
                    }
                }

                Texts=new string[max+1];
                if (sameLanguageAsSystem){
                    string ci = CultureInfo.InstalledUICulture.ThreeLetterWindowsLanguageName.ToLower();
                    int en=-1;
                    bool find=false;

                    for (int i=0; i<Languages.Length; i++) {
                        Language ll=Languages[i];

                        if (ll.Name=="eng") en=i;

                        if (ll.Name==ci) {
                            Setting.CurrentLanguage=i;
                            find=true;
                            break;
                        }
                        i++;
                    }

                    // find eng-US
                    //if (!find) { 
                    //   // ci = CultureInfo.InstalledUICulture.Name.Replace("en", "eng");

                    //    for (int i=0; i<Languages.Length; i++) {
                    //        Language ll=Languages[i];

                    //        if (ll.Name==ci) {
                    //            Setting.CurrentLanguage=i;
                    //            find=true;
                    //            break;
                    //        }
                    //        i++;
                    //    }
                    //}

                    if (!find) Setting.CurrentLanguage=en;
                }
                #if DEBUG
                System.Diagnostics.Debug.WriteLine("Setting.CurrentLanguage is smaller than 0");
                #endif
                if (Setting.CurrentLanguage<0)Setting.CurrentLanguage=0;
                if (Languages.Length<=Setting.CurrentLanguage)Setting.CurrentLanguage=0;
                cl=Languages[Setting.CurrentLanguage].Name;

                foreach (XmlNode node in data.ChildNodes) {
                    if (int.TryParse(node.Attributes[0].Value, out int v)) {
                        Texts[v]=GetTmpText(node,cl);
                    }
                }
            }
            {
                int max=0;
                foreach (Language ll in Languages) {
                    if (max<ll.Capacity)max=ll.Capacity;
                }

                foreach (Language ll in Languages) {
                    ll.Filled=ll.Capacity/(float)max;
                }
            }

            Global.GameName=Texts[182]/*.Text*/;
    //     try{   Rabcr.Game.Window.Title = Global.GameName; }catch{ }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        static string GetTmpText(XmlNode node, string x) {
            if (x=="ara" || x=="uig"){
                foreach (XmlNode n in node.ChildNodes) {
                    if (n.Name==cl) return /*new LangText{ Text=*/ArabicReverse(n.InnerText)/*, BaseLanguage=x }*/;
                }
            }else{
                foreach (XmlNode n in node.ChildNodes) {
                    if (n.Name==cl) return /*new LangText{ Text=*/n.InnerText/*, BaseLanguage=x }*/;
                }
            }

            Language base1=Languages[Setting.CurrentLanguage].Base;
            if (base1!=null) {
                foreach (XmlNode n in node.ChildNodes) {
                    if (n.Name==base1.Name) return /*new LangText{ Text=*/n.InnerText/*, BaseLanguage=x }*/;
                }
                Language base2=Languages[Setting.CurrentLanguage].Base;
                if (base2!=null) {
                    foreach (XmlNode n in node.ChildNodes) {
                        if (n.Name==base2.Name) return /*new LangText{ Text=*/n.InnerText/*, BaseLanguage=x }*/;
                    }
                }
            }
            if (node.ChildNodes.Count>0) {
                return /*new LangText{ Text=*/node.ChildNodes[0].InnerText/*, BaseLanguage=x }*/;
            }
            return null;
        }

        static string ArabicReverse(string s){
            char[] chs=s.ToCharArray();

            if (LTRText(chs)) {
                string s2="";
                for (int i = s.Length-1; i>=0; i--) {
                    if (chs[i]!='\u200E') s2+=chs[i];
                }
                return s2;
            }

            return s;
        }

        static bool LTRText(char[] chs) {
            for (int i = chs.Length-1; i>=0; i--) {
                if (chs[i]!='\u200E') return true;
            }
            return false;
        }
    }

    public class Language {
        ///<summary>
        ///"Czech"
        ///</summary>
        public string EnglishName;

        public int id;

        ///<summary>
        ///"Čeština"
        ///</summary>
        public string NativeName;

        ///<summary>
        ///"cze", "eng", ...
        ///</summary>
        public string Name;

        ///<summary>
        ///"cs"
        ///</summary>
     //   public string TwoLetterISOLanguageName;

        ///<summary>
        ///"ces"
        ///</summary>
    //    public string ThreeLetterISOLanguageName;

        ///<summary>
        ///Language
        ///</summary>
        public Language Base;

        public string[] Flags;

        public string[] Category;
      //  public bool Worldwide;

        public string _Base;
       // public bool UseBase;
        public float Filled;
        public int Capacity;

        //public float Quality{ //0-1
        //    get {

        //        if (UseBase) {
        //            if (TranslationQuality==-1) return Base.Filled;
        //            else return (Base.Filled+TranslationQuality/6f)/2f;
        //        } else {
        //            if (TranslationQuality==-1) return Filled;
        //            else return (Filled+TranslationQuality/6f)/2f;
        //        }
        //    }
        //}
      //  public int TranslationQuality=-1;
        public string FontFile;
    }
}