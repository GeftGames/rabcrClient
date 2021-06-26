using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace rabcrClient {
    public class GeDo {

        #region Varibles
        public List<GeDoEvent> GeDoEvents;
        public string Text;

        GeDoString[] gedoParts;
        List<GeDoString> gedoBuilding;
        const int lineSize=30;
        public int mouseAdd;
        float TextW;
        int X, Y, yy2;
        int gedoLen;
        bool changingPos=false;    
        public int width;
        public EventHandler changeHeight;
        #endregion

        public GeDo(string text, int xx, int yy) {
            X=xx;
            yy2=Y=yy;

            try{
                BuildString(text);
            } catch {

            }
        }

        public GeDo(int xx, int yy) {
            X=xx;
            yy2=Y=yy;
            //Font=BitmapFont.bitmapFont18;
        }

        #region Build string
        public void BuildString(string txtBody) {
            Y=yy2;
            TextW=0;
            gedoBuilding=new List<GeDoString>();

            while (true) {
                int gr=txtBody.IndexOf('<');
                if (gr>=0) {
                    if (!txtBody.Contains(">"))throw new Exception("Tag není jasně definován (chybí znak '>')");
                    int lw=txtBody.IndexOf('>');
                    string itag=txtBody.Substring(gr+1,lw-gr-1);

                    if (gr!=0) {
                        BuildNormal(Symbols(txtBody.Substring(0,gr)));
                    }
                    txtBody=txtBody.Substring(lw+1);

                    string moreInfo="";
                    if (itag.Contains("|")){
                        int sep=itag.IndexOf('|');
                        moreInfo=itag.Substring(sep+1);
                        itag=itag.Substring(0,sep);
                    }

                    int x=txtBody.IndexOf("</"+itag+">");
                    if (x==-1)throw new Exception("Chybí uzavření tagu");
                    string inTag=txtBody.Substring(0, x);

                    if (Enum.TryParse(itag, out GeDoType tag)){
                        switch (tag) {
                            case GeDoType.Bold:
                                BuildPartBold(Symbols(inTag));
                                break;

                            case GeDoType.Animated:
                                BuildPartAnimated(Symbols(inTag),moreInfo);
                                break;

                            case GeDoType.Italic:
                                BuildPartItalic(Symbols(inTag));
                                break;

                            case GeDoType.Link:
                                BuildPartLink(Symbols(inTag),moreInfo);
                                break;

                            case GeDoType.Mark:
                                BuildPartMark(Symbols(inTag),moreInfo);
                                break;

                            case GeDoType.Random:
                                BuildPartRandom(Symbols(inTag));
                                break;

                            case GeDoType.Spoiler:
                                BuildPartSpoiler(inTag, moreInfo,x==txtBody.IndexOf("</"+itag+">"+Environment.NewLine));
                                break;

                            case GeDoType.Underline:
                                BuildPartUnderline(Symbols(inTag));
                                break;

                            case GeDoType.Superscript:
                                BuildPartSuperscript(Symbols(inTag));
                                break;

                            case GeDoType.Subscript:
                                BuildPartSubscript(Symbols(inTag));
                                break;

                            case GeDoType.Article:
                                BuildArticle(inTag,moreInfo,x==txtBody.IndexOf("</"+itag+">"+Environment.NewLine));
                                break;

                            default:
                                BuildPartColored(tag, Symbols(inTag));
                                break;
                        }
                    }
                    txtBody=txtBody.Substring(x+itag.Length+3);
                } else {
                    BuildNormal(Symbols(txtBody));
                    break;
                }
            }
            Y+=lineSize+lineSize/2;
            gedoParts=gedoBuilding.ToArray();
            gedoLen=gedoParts.Length;
            gedoBuilding.Clear();
            gedoBuilding=null;
        }

        void BuildNormal(string tmpText) {
            if (tmpText.Contains(Environment.NewLine)) {
                string[] lines=tmpText.Split('\n');
                for (int i=0; i<lines.Length; i++) {

                    //first
                    if (i==0) {
                        GeDoStringNormal g = new GeDoStringNormal {
                            //str=lines[i],
                            text=new TextWithMeasure(lines[i], X+(int)TextW, Y/*, BitmapFont.bitmapFont18*/)
                        };
                        gedoBuilding.Add(g);
                        Y+=lineSize;
                        TextW=0;

                    //last
                    } else if (i==lines.Length-1) {
                        GeDoStringNormal g = new GeDoStringNormal {
                           // str=lines[i],
                            text=new TextWithMeasure(lines[i], X+(int)TextW, Y/*, BitmapFont.bitmapFont18*/)
                        };
                        gedoBuilding.Add(g);
                        TextW=g.text.X;

                    //middle
                    } else {
                        GeDoStringNormal g = new GeDoStringNormal {
                           // str=lines[i],
                            text=new TextWithMeasure(lines[i], (int)(X+TextW), Y/*, BitmapFont.bitmapFont18*/)
                        };
                        gedoBuilding.Add(g);
                        Y+=lineSize;
                    }
                }
            } else {
                GeDoStringNormal g = new GeDoStringNormal {
                    //X=(int)(X+TextW),
                    //Y=Y,
                   // str=tmpText,
                    text=new TextWithMeasure(tmpText, (int)(X+TextW), Y/*, BitmapFont.bitmapFont18*/)
                };
                gedoBuilding.Add(g);
                TextW+=g.text.X;
            }
        }

        void BuildPartSuperscript(string tmpText) {
            //if (tmpText.Contains(Environment.NewLine)) {
            //    string[] lines=tmpText.Split('\n');
            //    for (int i=0; i<lines.Length; i++) {

            //        //first
            //        if (i==0) {
            //            GeDoStringNormal g = new GeDoStringNormal {
            //                //str=lines[i],
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y-10, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //            TextW=0;

            //        //last
            //        } else if (i==lines.Length-1) {
            //            GeDoStringNormal g = new GeDoStringNormal {
            //               // str=lines[i],
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y-10, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            TextW=g.text.X;

            //        //middle
            //        } else {
            //            GeDoStringNormal g = new GeDoStringNormal {
            //               // str=lines[i],
            //                text=new TextWithMeasure(lines[i], (int)(X+TextW), Y-10, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //        }
            //    }
            //} else {
                GeDoStringNormal g = new GeDoStringNormal {
                    //X=(int)(X+TextW),
                    //Y=Y-10,
                   // str=tmpText,
                    text=new TextWithMeasure(tmpText, (int)(X+TextW), Y-10/*, BitmapFont.bitmapFont18*/)
                };
                gedoBuilding.Add(g);
                TextW+=g.text.X;
           // }
        }

        void BuildPartSubscript(string tmpText) {
            if (tmpText.Contains(Environment.NewLine)) {
                string[] lines = tmpText.Split('\n');
                for (int i = 0; i<lines.Length; i++) {

                    //first
                    if (i==0) {
                        Subscript g = new Subscript {
                            //str=lines[i],
                            text=new TextWithMeasure(lines[i], X+(int)TextW, Y+10/*, BitmapFont.bitmapFont18*/)
                        };
                        gedoBuilding.Add(g);
                        Y+=lineSize;
                        TextW=0;

                        //last
                    } else if (i==lines.Length-1) {
                        Subscript g = new Subscript {
                            // str=lines[i],
                            text=new TextWithMeasure(lines[i], X+(int)TextW, Y+10/*, BitmapFont.bitmapFont18*/)
                        };
                        gedoBuilding.Add(g);
                        TextW=g.text.X;

                        //middle
                    } else {
                        Subscript g = new Subscript {
                            // str=lines[i],
                            text=new TextWithMeasure(lines[i], (int)(X+TextW), Y+10/*, BitmapFont.bitmapFont18*/)
                        };
                        gedoBuilding.Add(g);
                        Y+=lineSize;
                    }
                }
            } else {
                Subscript g = new Subscript {
                 //   X=(int)(X+TextW),
                    //Y=Y,
                   // str=tmpText,
                    text=new TextWithMeasure(tmpText, (int)(X+TextW), Y+10/*, BitmapFont.bitmapFont18*/)
                };
                gedoBuilding.Add(g);
                TextW+=g.text.X;
            }
        }

        void BuildPartColored(GeDoType tag, string tmpText) {
            Color c=GetColorByTag(tag);
            if (tmpText.Contains(Environment.NewLine)) {
                string[] lines = tmpText.Split('\n');
                for (int i = 0; i<lines.Length; i++) {

                    //first
                    if (i==0) {
                        GeDoStringColoredText g = new GeDoStringColoredText {
                            color=c,
                            //X=(int)(X+TextW),
                            //Y=Y,
                            //str=lines[i],
                            text=new TextWithMeasure(lines[i], X+(int)TextW, Y/*, BitmapFont.bitmapFont18*/)
                        };
                        gedoBuilding.Add(g);
                        Y+=lineSize;
                        TextW=0;

                        //last
                    } else if (i==lines.Length-1) {
                        GeDoStringColoredText g = new GeDoStringColoredText {
                            color=c,
                            //X=(int)(X+TextW),
                            //Y=Y,
                            // str=lines[i],
                            text=new TextWithMeasure(lines[i], X+(int)TextW, Y/*, BitmapFont.bitmapFont18*/)
                        };
                        gedoBuilding.Add(g);
                        TextW=g.text.X;

                        //middle
                    } else {
                        GeDoStringColoredText g = new GeDoStringColoredText {
                            color=c,
                            //X=(int)(X+TextW),
                            //Y=Y,
                            // str=lines[i],
                            text=new TextWithMeasure(lines[i], (int)(X+TextW), Y/*, BitmapFont.bitmapFont18*/)
                        };
                        gedoBuilding.Add(g);
                        Y+=lineSize;
                    }
                }
            } else {
                GeDoStringColoredText g= new GeDoStringColoredText {
                    color=c,
                    //X=(int)(X+TextW),
                    //Y=Y,
                    //str=tmpText,
                    text=new TextWithMeasure(tmpText,(int)(X+TextW), Y/*,BitmapFont.bitmapFont18*/)
                };
                gedoBuilding.Add(g);
                TextW+=g.text.X;
            }
        }

        void BuildPartBold(string tmpText) {
            //if (tmpText.Contains(Environment.NewLine)) {
            //    string[] lines=tmpText.Split('\n');
            //    for (int i=0; i<lines.Length; i++) {

            //        //first
            //        if (i==0) {
            //            GeDoStringBold g= new GeDoStringBold {
            //                //str=lines[i],
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //            TextW=0;

            //        //last
            //        } else if (i==lines.Length-1) {
            //            GeDoStringBold g= new GeDoStringBold {
            //                //str=lines[i],
            //               text=new TextWithMeasure(lines[i],X+(int)TextW, Y,BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            TextW=g.text.X;

            //        //middle
            //        } else {
            //            GeDoStringBold g= new GeDoStringBold {
            //                //str=lines[i],
            //                text=new TextWithMeasure(lines[i],(int)(X+TextW), Y,BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //        }
            //    }
            //} else {
                GeDoStringBold g= new GeDoStringBold {
                    //str=tmpText,
                   text=new TextWithMeasure(tmpText,(int)(X+TextW), Y/*,BitmapFont.bitmapFont18*/)
                };
                gedoBuilding.Add(g);
                TextW+=g.text.X;
            //}
        }

        void BuildPartItalic(string tmpText) {
            //if (tmpText.Contains(Environment.NewLine)) {
            //    string[] lines=tmpText.Split('\n');
            //    for (int i=0; i<lines.Length; i++) {

            //        //first
            //        if (i==0) {
            //            GeDoStringItalic g = new GeDoStringItalic {
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //            TextW=0;

            //        //last
            //        } else if (i==lines.Length-1) {
            //            GeDoStringItalic g = new GeDoStringItalic {
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            TextW=g.text.X;

            //        //middle
            //        } else {
            //            GeDoStringItalic g = new GeDoStringItalic {
            //                text=new TextWithMeasure(lines[i], (int)(X+TextW), Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //        }
            //    }
            //} else {
                GeDoStringItalic g = new GeDoStringItalic {
                    text=new TextWithMeasure(tmpText, (int)(X+TextW), Y/*, BitmapFont.bitmapFont18*/)
                };
                gedoBuilding.Add(g);
                TextW+=g.text.X;
           // }
        }

        void BuildPartAnimated(string tmpText, string more) {
            //if (tmpText.Contains(Environment.NewLine)) {
            //    string[] lines=tmpText.Split('\n');
            //    for (int i=0; i<lines.Length; i++) {

            //        //first
            //        if (i==0) {
            //            GeDoStringAnimated g= new GeDoStringAnimated {
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18)
            //            };
            //            g.len=g.text.Chars.Length;
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //            TextW=0;

            //        //last
            //        } else if (i==lines.Length-1) {
            //            GeDoStringAnimated g= new GeDoStringAnimated {
            //                text=new TextWithMeasure(lines[i],X+(int)TextW, Y,BitmapFont.bitmapFont18)
            //            };
            //            g.len=g.text.Chars.Length;
            //            gedoBuilding.Add(g);
            //            TextW=g.text.X;

            //        //middle
            //        } else {
            //            GeDoStringAnimated g= new GeDoStringAnimated {
            //                text=new TextWithMeasure(lines[i],(int)(X+TextW), Y,BitmapFont.bitmapFont18)
            //            };
            //            g.len=g.text.Chars.Length;
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //        }
            //    }
            //} else {
                GeDoStringAnimated g= new GeDoStringAnimated {
                   text=new TextWithMeasure(tmpText,(int)(X+TextW), Y/*,BitmapFont.bitmapFont18*/)
                };

                string[] moreinforaw=more.Split('|');
                bool backset=false, foreset=false;
                for (int i=0; i<moreinforaw.Length; i++){
                    string str=moreinforaw[i];
                    if (str.Contains("=")){
                        int sep=str.IndexOf('=');
                        string name=str.Substring(0,sep);
                        string what=str.Substring(sep+1);
                        if (name=="back") {
                            //CColor clrColor = CColor.FromName(what);
                            g.colorBack=StringToColor(what);//new Color(clrColor.R, clrColor.G, clrColor.B, (byte)255);
                            backset=true;
                        }
                        if (name=="fore"){
                            //CColor clrColor = CColor.FromName(what);
                            g.colorGoing=StringToColor(what);//(new Color(clrColor.R, clrColor.G, clrColor.B, (byte)255);
                            foreset=true;
                        }
                    }
                }


                if (!backset) g.colorBack=Color.Black;
                if (!foreset) g.colorGoing=Color.White;
                g.colorBeet=new Color((g.colorBack.R+g.colorGoing.R)/2, (g.colorBack.G+g.colorGoing.G)/2, (g.colorBack.B+g.colorGoing.B)/2);

                g.len=g.text.Chars.Length;
                //if (gedoBuilding==null)return;
                gedoBuilding.Add(g);
                TextW+=g.text.X;
            //}
        }

        void BuildPartUnderline(string tmpText) {
            //if (tmpText.Contains(Environment.NewLine)) {
            //    string[] lines=tmpText.Split('\n');
            //    for (int i=0; i<lines.Length; i++) {

            //        //first
            //        if (i==0) {
            //            GeDoStringUnderline g= new GeDoStringUnderline {
            //                X=(int)TextW+X,
            //            };
            //            g.text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18);
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //            TextW=0;

            //        //last
            //        } else if (i==lines.Length-1) {
            //            GeDoStringUnderline g= new GeDoStringUnderline {
            //                X=(int)TextW+X,
            //            };
            //            g.text=new TextWithMeasure(lines[i],X+(int)TextW, Y,BitmapFont.bitmapFont18);
            //            gedoBuilding.Add(g);
            //            TextW=g.text.X;

            //        //middle
            //        } else {
            //            GeDoStringUnderline g= new GeDoStringUnderline {
            //                X=(int)TextW+X,
            //            };
            //            g.text=new TextWithMeasure(lines[i],(int)(X+TextW), Y,BitmapFont.bitmapFont18);
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //        }
            //    }
            //} else {
                GeDoStringUnderline g= new GeDoStringUnderline {
                    X=(int)TextW+X,
                    Y=Y,
                };
                g.text=new TextWithMeasure(tmpText,(int)(X+TextW), Y/*,BitmapFont.bitmapFont18*/);
                gedoBuilding.Add(g);
                TextW+=g.text.X;
           // }
        }

        void BuildPartMark(string tmpText, string more) {
            //if (tmpText.Contains(Environment.NewLine)) {
            //    string[] lines=tmpText.Split('\n');
            //    for (int i=0; i<lines.Length; i++) {

            //        //first
            //        if (i==0) {
            //            GeDoStringMark g= new GeDoStringMark {
            //                Y=Y,
            //                X=(int)TextW+X,
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //            TextW=0;

            //        //last
            //        } else if (i==lines.Length-1) {
            //            GeDoStringMark g= new GeDoStringMark {
            //                Y=Y,
            //                X=(int)TextW+X,
            //                text=new TextWithMeasure(lines[i],X+(int)TextW, Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            TextW=g.text.X;

            //        //middle
            //        } else {
            //            GeDoStringMark g= new GeDoStringMark {
            //                Y=Y,
            //                X=(int)TextW+X,
            //                text=new TextWithMeasure(lines[i],(int)(X+TextW), Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //        }
            //    }
            //} else {
                GeDoStringMark g= new GeDoStringMark {
                    Y=Y,
                    X=(int)TextW+X,
                    text=new TextWithMeasure(tmpText,(int)(X+TextW), Y/*,BitmapFont.bitmapFont18*/)
                };

                string[] moreinforaw=more.Split('|');
                bool set=false;
                for (int i=0; i<moreinforaw.Length; i++){
                    string str=moreinforaw[i];
                    if (str.Contains("=")){
                        int sep=str.IndexOf('=');
                        string name=str.Substring(0,sep);
                        string what=str.Substring(sep+1);
                        if (name=="color") {
                           // CColor clrColor = CColor.FromName(what);
                            g.color=StringToColor(what);// new Color(clrColor.R, clrColor.G, clrColor.B, (byte)255);
                            set=true;
                        }
                    }
                }

                if (!set) g.color=new Color(173,216,255);

                gedoBuilding.Add(g);
                TextW+=g.text.X;
           // }
        }

        Color StringToColor(string l){
            if (Enum.TryParse(l, out GeDoType tag)){
                return GetColorByTag(tag);
            }else {

                return Color.Black;
            }
        }

        void BuildPartLink(string tmpText, string more) {
            //if (tmpText.Contains(Environment.NewLine)) {
            //    //ShowError("Multiline link");
            //} else {
                GeDoStringLink g = new GeDoStringLink(tmpText, (int)(X+TextW), Y) {
                    mouseAdd2=mouseAdd,
                };

                string[] moreinforaw=more.Split('|');

                for (int i=0; i<moreinforaw.Length; i++) {
                    string str=moreinforaw[i];
                    if (str.Contains("=")) {
                        int sep=str.IndexOf('=');
                        string name=str.Substring(0,sep);
                        string what=str.Substring(sep+1);
                        if (name=="url") {
                            g.url=what;
                            g.action=GeDoStringLink.Action.Url;
                        }
                        if (name=="event") {
                            g.action=GeDoStringLink.Action.Event;
                            if (GeDoEvents!=null){
                                foreach (GeDoEvent ge in GeDoEvents) {
                                    if (ge.ID==what) {
                                        g.ev=ge.Event;
                                        break;
                                    }
                                }
                            }else Console.WriteLine("Chybí zaregistrovat event v GeDoEvents");
                        }
                        if (name=="run") {
                            g.action=GeDoStringLink.Action.Execute;
                            g.url=what;
                        }
                        if (name=="args") {
                         //   g.action=GeDoStringLink.Action.Execute;
                            g.args=what;
                        }
                    }
                }

                gedoBuilding.Add(g);
                TextW+=g.text.X;
           // }
        }

        void BuildPartRandom(string tmpText) {
            //if (tmpText.Contains(Environment.NewLine)) {
            //    string[] lines=tmpText.Split('\n');
            //    for (int i=0; i<lines.Length; i++) {

            //        //first
            //        if (i==0) {
            //            GeDoStringRandom g = new GeDoStringRandom {
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //            TextW=0;

            //        //last
            //        } else if (i==lines.Length-1) {
            //            GeDoStringRandom g = new GeDoStringRandom {
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            TextW=g.text.X;

            //        //middle
            //        } else {
            //            GeDoStringRandom g = new GeDoStringRandom {
            //                text=new TextWithMeasure(lines[i], (int)(X+TextW), Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //        }
            //    }
            //} else {
                GeDoStringRandom g = new GeDoStringRandom {
                    text=new TextWithMeasure(tmpText, (int)(X+TextW), Y/*, BitmapFont.bitmapFont18*/)
                };
                gedoBuilding.Add(g);
                TextW+=g.text.X;
           // }
        }

        void BuildPartSpoiler(string tmpText, string more, bool n) {
            string showText="", hideText="";
            if (more!=""){
                string[] moreinforaw=more.Split('|');

                for (int i=0; i<moreinforaw.Length; i++){
                     string str=moreinforaw[i];
                    int sep=str.IndexOf('=');
                    string name=str.Substring(0,sep);
                    string what=str.Substring(sep+1);
                    if (name=="show")showText=what;
                    if (name=="hide")hideText=what;
                }
            }
            if (Lang.Texts==null){
                if (showText=="") showText="Zobrazit";
                if (hideText=="") hideText="Skrýt";
            }else{
                if (showText=="") showText=Lang.Texts[292];
                if (hideText=="") hideText=Lang.Texts[293];
            }
            GeDoStringSpoiler g = new GeDoStringSpoiler(tmpText, X,(int)(X+TextW), Y, mouseAdd) {
                textShow=showText,
                textHide=hideText
            };
            g.ev=ChangeGeDoStrucBySpoiler;

            g.Build();
            gedoBuilding.Add(g);
            TextW=0;
           if (!n) Y+=lineSize;
        }

        void BuildArticle(string tmpText, string more, bool n) {
            bool wrap=true;
            if (more!="") {
                string[] moreinforaw=more.Split('|');

                for (int i=0; i<moreinforaw.Length; i++){
                     string str=moreinforaw[i];
                    int sep=str.IndexOf('=');
                    string name=str.Substring(0,sep);
                    string what=str.Substring(sep+1);
                    if (name=="wrap") wrap=what=="true";
                }
            }

            GeDoStringArticle g = new GeDoStringArticle(tmpText, X, Y, width, mouseAdd, wrap);

            gedoBuilding.Add(g);
            TextW=0;
            Y+=g.innerGedo.GetHeight;
            if (n)Y-=30;
        }

        Color GetColorByTag(GeDoType tag){
            switch (tag) {
                case GeDoType.Blue: return new Color(20,64,224);
                case GeDoType.Green: return new Color(32,128,0);
                case GeDoType.Red: return new Color(255,0,0);
                case GeDoType.DarkBlue: return new Color(0,0,128);
                case GeDoType.DarkGreen: return new Color(0,64,0);
                case GeDoType.DarkRed: return new Color(128,0,0);
                case GeDoType.Orange: return new Color(255,92,0);
                case GeDoType.LightGreen: return new Color(0,255,0);
                case GeDoType.LightBlue: return new Color(128,192,255);
                case GeDoType.DarkGray: return new Color(64,64,64);
                case GeDoType.Gold: return new Color(120,120,0);
                case GeDoType.Yellow: return new Color(220,220,0);
                case GeDoType.Gray: return new Color(128,128,128);
                case GeDoType.Teal: return new Color(0,128,128);
                case GeDoType.Purple: return new Color(255,0,255);
                case GeDoType.Pink: return new Color(255,128,172);
                case GeDoType.Brown: return new Color(128,30,0);
                case GeDoType.Black: return new Color(0,0,0);
                case GeDoType.White: return new Color(255,255,255);
                default:/* ShowError("Unknown tag");*/ return Color.Black;
            }
        }

        string Symbols(string s) {
            return s
                .Replace("&g;",">")
                .Replace("&l;","<")
                .Replace("&t;","     ")
                .Replace("&n;","\r\n");
                //.Replace("&n;","\n")
                //.Replace("&a;","@")
                //.Replace("&e;","€")
                //.Replace("&mc;","Kč")
                //.Replace("&mu;","$")
                //.Replace("&mn;","円")
                //.Replace("&mg;","£");
        }
        #endregion

        #region changing
        public void SetPos(int newX, int newY) {
            if (changingPos)return;
            changingPos=true;
            int nY=newY-yy2;

            foreach (GeDoString gs in gedoParts){

                {
                    if (gs is GeDoStringColoredText g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        continue;
                    }
                }
                {
                    if (gs is GeDoStringNormal g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        continue;
                    }
                }
                {
                    if (gs is GeDoStringBold g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        continue;
                    }
                }
                {
                    if (gs is GeDoStringItalic g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        continue;
                    }
                }
                {
                    if (gs is GeDoStringLink g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        g.Y+=nY;
                        continue;
                    }
                }
                {
                    if (gs is GeDoStringMark g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        g.Y+=nY;
                        continue;
                    }
                }
                {
                    if (gs is GeDoStringRandom g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        continue;
                    }
                }
                {
                    if (gs is GeDoStringUnderline g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        g.Y+=nY;
                        continue;
                    }
                }
                {
                    if (gs is Superscript g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        continue;
                    }
                }
                {
                    if (gs is Subscript g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        continue;
                    }
                }

                {
                    if (gs is GeDoStringSpoiler g) {
                        foreach (DrawingChar s in g.text.Chars) {
                            s.Pos.X=s.Pos.X-X+newX;
                            s.Pos.Y+=nY;
                        }
                        g.innerGedo.SetPos(g.X, g.Y+30);
                        g.Y+=nY;
                        continue;
                    }
                }
                {
                    if (gs is GeDoStringArticle g) {
                        g.Y+=nY;
                        g.innerGedo.SetPos(g.X, g.Y);
                        continue;
                    }
                }
            }
            X=newX;
            yy2=newY;
            Y+=nY;
            changingPos=false;
        }

        //public void ChangeWidth(int w){
        //    width=w;
        //    int y=Y;
        //    bool changeY=false;
        //    foreach (GeDoString gs in gedoParts){
        //        if (changeY){
        //            SetPos(X,Y);
        //            //gs.Y+=y;
        //        }

        //        if (gs is GeDoStringArticle g) {
        //            int bef=g.innerGedo.GetHeight;
        //            g.ChangeWrap(w);
        //            int after=g.innerGedo.GetHeight;
        //            if (after!=bef){
        //                changeY=true;
        //                Y+=after-bef;
        //            }
        //        }
        //    }
        //}

        void ChangeGeDoStrucBySpoiler(object o, EventArgs e) {
           if (changingPos) while (changingPos){ }
           changingPos=true;
            GeDoString g2 = o as GeDoString;
            GeDoStringSpoiler spoiler=(GeDoStringSpoiler)g2;
            bool start=false;//begin with y change
            int yAdd=0;

            foreach (GeDoString gs in gedoParts) {
                if (gs==g2) {
                    {
                        GeDoStringSpoiler g=(GeDoStringSpoiler)gs;
                        if (start){
                            foreach (DrawingChar s in g.text.Chars) {
                                s.Pos.Y+=yAdd;
                            }
                            g.Y+=yAdd;
                        }
                        start=true;

                        if (spoiler.Show) yAdd+=spoiler.innerGedo.GetHeight;
                        else yAdd-=spoiler.innerGedo.GetHeight;
                        continue;
                    }
                } else {
                    if (start) {

                        // Hide spoiler after
                        {
                            if (gs is GeDoStringSpoiler g) {
                                g.Y+=yAdd;

                                foreach (DrawingChar s in g.text.Chars) {
                                    s.Pos.Y+=yAdd;
                                }

                                if (g.Show) {
                                    yAdd-=g.innerGedo.GetHeight;
                                    g.Hide();
                                }
                                continue;
                            }
                        }

                        {
                            if (gs is GeDoStringNormal g) {
                                foreach (DrawingChar s in g.text.Chars) {
                                    s.Pos.Y+=yAdd;
                                }
                                continue;
                            }
                        }
                        {
                            if (gs is GeDoStringColoredText g) {
                                foreach (DrawingChar s in g.text.Chars) {
                                    s.Pos.Y+=yAdd;
                                }
                                continue;
                            }
                        }
                        {
                            if (gs is GeDoStringBold g){
                                foreach (DrawingChar s in g.text.Chars) {
                                    s.Pos.Y+=yAdd;
                                }
                                continue;
                            }
                        }
                        {
                            if (gs is GeDoStringItalic g) {
                                foreach (DrawingChar s in g.text.Chars) {
                                    s.Pos.Y+=yAdd;
                                }
                                continue;
                            }
                        }
                        {
                            if (gs is GeDoStringMark g) {
                                foreach (DrawingChar s in g.text.Chars) {
                                    s.Pos.Y+=yAdd;
                                }
                                g.Y+=yAdd;
                                continue;
                            }
                        }
                        {
                            if (gs is GeDoStringLink g) {
                                foreach (DrawingChar s in g.text.Chars) {
                                    s.Pos.Y+=yAdd;
                                }
                                g.Y+=yAdd;
                                continue;
                            }
                        }
                        {
                            if (gs is GeDoStringRandom g){
                                foreach (DrawingChar s in g.text.Chars){
                                    s.Pos.Y+=yAdd;
                                }
                                continue;
                            }
                        }
                        {
                            if (gs is Superscript g){
                                foreach (DrawingChar s in g.text.Chars){
                                    s.Pos.Y+=yAdd;
                                }
                                continue;
                            }
                        }
                        {
                            if (gs is Subscript g){
                                foreach (DrawingChar s in g.text.Chars){
                                    s.Pos.Y+=yAdd;
                                }
                                continue;
                            }
                        }
                        {
                            if (gs is GeDoStringArticle g){
                                g.Y+=yAdd;
                                g.innerGedo.SetPos(g.X,g.Y);
                                continue;
                            }
                        }

                    } else {

                        // Skryj spoilery před
                        if (gs is GeDoStringSpoiler g) {
                            if (g.Show){
                                start=true;
                                yAdd-=g.innerGedo.GetHeight;
                                g.Hide();
                            }
                        }
                    }
                }
            }
            Y+=yAdd;
            changingPos=false;
         //   Console.WriteLine("spoiler after: "+Y);
          //  Console.WriteLine("s after: "+Y);
            if (changeHeight!=null)changeHeight.Invoke(null,null);
        }
        #endregion

        public void DrawGedo(float a, SpriteBatch sb) {
            Constants.alpha=a;

            //Pos();
            for (int i=0; i<gedoLen; i++) gedoParts[i].Draw(sb);

        }

        public int GetHeight=>Y-yy2;
    }

    public enum GeDoType:byte {
        None,
        Bold,
        Italic,
        Underline,
        Animated,
        Gray,
        LightGreen,
        Red,
        Blue,
        Purple,
        Teal,
        Pink,
        LightBlue,
        Gold,
        Green,
        Yellow,
        Orange,
        Brown,
        Link,
        Black,
        Mark,
        Random,
        DarkRed,
        DarkBlue,
        DarkGreen,
        DarkGray,
        White,
        Spoiler,
        Subscript,
        Superscript,
        Article,
    }

    public abstract class GeDoString {
        //public TextWithMeasure text;
        //public int X, Y;

        public abstract int Height();
        //public bool selected;
        //public string str;

        //public void SetFrom(int from) {
        //   // if (from!=selectingFrom) {
        //   //Console.WriteLine((from+X)+" "+from);
        //        (int, int) fit=text.FitToCharRight(from/*+X*/,str);

        //        selectingFrom=fit.Item1-X;
        //        selectingCharFrom=fit.Item2;
        //    //}
        //}

        //public void SetTo(int to) {
        //   // if (to!=selectingTo) {
        //        (int, int) fit=text.FitToCharRight(to/*+selectingFrom*/,str);
        //        selectingTo=fit.Item1-selectingFrom-X;
        //        selectingCharTo=fit.Item2-selectingCharFrom;
        //   // }
        //}

        public abstract void Draw(SpriteBatch sb);

        //public void DrawSelection(SpriteBatch sb){
        //    if (selected) sb.Draw(Rabcr.Pixel,new Rectangle(X+selectingFrom, Y, selectingTo,30), new Color(173,216,255)*Constants.alpha);
        //}
    }

    public class GeDoStringColoredText : GeDoString {
        public Color color;
        public TextWithMeasure text;

        public override void Draw(SpriteBatch sb) {
            text.Draw(sb, color);
        }

        public override int Height() => text.NewLines*30;
    }

    public class GeDoStringNormal : GeDoString{
        public TextWithMeasure text;

        public override void Draw(SpriteBatch sb) {
            text.Draw(sb);
        }

        public override int Height() => text.NewLines*30;
    }

    public class GeDoStringRandom : GeDoString{
        public TextWithMeasure text;

        public override void Draw(SpriteBatch sb) {
            text.Draw(sb, Rabcr.random.ColorMonogame());/* new Color(Rabcr.random.Int255(),Rabcr.random.Int255(),Rabcr.random.Int255()));;*/
        }

        public override int Height() => text.NewLines*30;
    }

    public class Subscript: GeDoString{
        public TextWithMeasure text;

        public override void Draw(SpriteBatch sb) {
            text.Draw(sb);
        }

        public override int Height() => text.NewLines*30;
    }

    public class Superscript: GeDoString{
        public TextWithMeasure text;

        public override void Draw(SpriteBatch sb) {
            text.Draw(sb);
        }

        public override int Height() => text.NewLines*30;
    }

    public class GeDoStringLink : GeDoString{
        public TextWithMeasure text;
        public int X, Y;
        public string /*evID,*/ url,args;
        public enum Action:byte{
            None,
            Url,
            Event,
            Execute,
        }
        public Action action;
      //  public string Link;
      //  public int X, Y;
        const int underlinecount=25;
       // MouseState oldMouseState;
       bool click;
        public EventHandler ev;
        Color color;
        int colorChanger;
        public int mouseAdd2;
      // public int y2;
        public GeDoStringLink(string txt, int x, int y){
            text=new TextWithMeasure(txt, x, y/*,BitmapFont.bitmapFont18*/);
            X=x;
          //  y2=y;
           Y= y/*+underlinecount*/;
            //y2=Y-10;
        }

        public override int Height() => text.NewLines*30;

        public override void Draw(SpriteBatch sb) {
            int needAlpha;
            //MouseState ms=Rabcr.newMouseState;
            //int mouseHeight = ms.Y+mouseAdd;

          //  DrawSelection(sb);

            if (In()) {
                if (Rabcr.newMouseState.LeftButton==ButtonState.Pressed) {
                    needAlpha=110;
                    click=true;
                } else {
                    needAlpha=80;

                    if (click) {
                        click=false;

                        if (Rabcr.ActiveWindow /*&& !selected*/) {   Console.WriteLine(action);
                            switch (action){
                                case Action.Event:
                                    if (ev!=null) ev.Invoke(this, null);
                                    else System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location, " /Message \"<Red>Event nenalezen.</Red>\"");
                                    break;

                                case Action.Url:
                                    bool run=false;
                                    if (url.StartsWith("https") || url.StartsWith("http") || url.StartsWith("mailto:")){
                                        run=true;
                                    } else {
                                        bool notsafe=false;
                                        if (url.Contains("\\"))notsafe=true;
                                        if (url.Contains(".exe"))notsafe=true;
                                        if (url.Contains("C:"))notsafe=true;
                                        if (url.Contains("cmd"))notsafe=true;
                                        if (url.Contains("ads"))notsafe=true;
                                        if (!url.Contains("."))notsafe=true;
                                        if (notsafe){
                                            System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Tento odkaz může být nebezpečný!\r\nVážně chcete spustit tento odkaz?\r\n\r\n"+url,"Upozornění",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Exclamation);
                                            if (dr==System.Windows.Forms.DialogResult.Yes)run=true;
                                        } else {
                                            System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Tento odkaz není standartním odkazem!\r\nPravděpodobně chybí http:\\\\, https:\\\\ nebo mailto:\\\\.\r\nI přesto jej chcete spustit?","Upozornění",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Information);
                                            if (dr==System.Windows.Forms.DialogResult.Yes)run=true;
                                        }
                                    }

                                    if (run) {
                                        try {
                                            System.Diagnostics.Process.Start(url);
                                        } catch {
                                            System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location, " /Message \"<Red>Web nenalezen.</Red><NewLine>Nejprve zkontrolujte zda se jedná o webovou adresu, pukud problém přetrvává<NewLine>zkuste přidat <Green>www</Green>, <Green>\"http://\"</Green> či <Green>\"https://\"</Green>.\"");
                                        }
                                    }
                                    break;

                                case Action.Execute:
                                    {
                                        System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Tento odkaz opouští externí aplikaci nebo soubor.\r\nOdkaz může být nebezpečný. Chcete spustit tento odkaz?\r\n\r\n"+url,"Upozornění",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Information);
                                            if (dr==System.Windows.Forms.DialogResult.Yes){
                                            try {
                                                System.Diagnostics.Process.Start(url,args);
                                            } catch {

                                            Console.WriteLine(url);
                                                System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location, " /Message \"<Red>Nelze spustit</Red>\"");
                                            }
                                        }
                                    }
                                    break;

                                    //FormUpdate f = new FormUpdate();
                                //f.Show/*Dialog*/();
                            }
                        }
                    }
                }
            } else needAlpha=0;

            if (needAlpha!=colorChanger) {/*Console.WriteLine(Constants.Animations);*/
                if (Constants.AnimationsControls) {
                    if (needAlpha<colorChanger) colorChanger-=5;
                    else colorChanger+=5;
                } else colorChanger=needAlpha;
            }
            color=new Color(0, colorChanger, 255);
            text.Draw(sb, color/**Constants.alpha*/);

            sb.Draw(Rabcr.Pixel, new Rectangle(X, Y+underlinecount/*+y2*/, text.X+2, 1), color/**Constants.alpha*/);
            sb.Draw(Rabcr.Pixel, new Rectangle(X, Y+1+underlinecount/*+y2*/, text.X+2, 1), color/**(Constants.alpha/2)*/);

          //  oldMouseState=Rabcr.newMouseState;
        }

        bool In() {
         //   Console.WriteLine("X: "+X+", Y: "+Y+", M.X: "+Rabcr.newMouseState.X+", M.Y: "+(Rabcr.newMouseState.Y-mouseAdd2)+", t.X:"+text.X+", ma: "+mouseAdd2);
            if (Rabcr.newMouseState.X < X) return false;
            if (Rabcr.newMouseState.Y+mouseAdd2< Y) return false;
            if (Rabcr.newMouseState.X > X+text.X) return false;
            if (Rabcr.newMouseState.Y+mouseAdd2> Y+30) return false;
            return true;
        }
    }

    public class GeDoStringSpoiler : GeDoString{
        public string textShow, textHide;
        public bool Show;
        public GeDo innerGedo;
        public string Text;
        public string Link;
      public TextWithMeasure text;
        const int underlinecount=25;
       // MouseState oldMouseState;
       bool click;
        public EventHandler ev;
        Color color;
        int colorChanger;
        public int mouseAdd2;
       // readonly int y2;
       // string b;
       // public int X,Y;
        //EventHandler changeHeight;
       // int gedoY, gedoX;
       public int X, X2, Y;

        public GeDoStringSpoiler(string txt, int x, int xx, int y, int mouseAdd2) {
            this.mouseAdd2=mouseAdd2;

            innerGedo=new GeDo(x, y+30) {
                mouseAdd=mouseAdd2-Y
            };
            //b=txt;
            innerGedo.BuildString(txt/*.Replace('[','<').Replace(']','>')*/);

            X=x;
           /* y2=*/ Y=y;
           X2=xx;
        }

        public void Build(){
            //if (textShow=="") textShow=Lang.Texts[292];
            //if (textHide=="") textHide=Lang.Texts[293];
            text=new TextWithMeasure(textShow, X2, Y/*, BitmapFont.bitmapFont18*/);
        }

        public bool Hide() {
            if (Show) {
                Show=false;
                if (!Show)text=new TextWithMeasure(textShow, X2, Y/*, BitmapFont.bitmapFont18*/);
                else text=new TextWithMeasure(textHide, X2, Y/*, BitmapFont.bitmapFont18*/);
                return true;
            }
            return false;
        }

        public override void Draw(SpriteBatch sb) {
            //DrawSelection(sb);
            int needAlpha;
          //  MouseState ms=Rabcr.newMouseState;
          //  int mouseHeight = ms.Y+mouseAdd2;

            if (In()) {
                if (Rabcr.newMouseState.LeftButton==ButtonState.Pressed) {
                    needAlpha=110;
                    click=true;
                } else {
                    needAlpha=80;

                    if (click) {
                        click=false;
                        if (Rabcr.ActiveWindow) {
                            Show=!Show;
                            ev.Invoke(this,null);
                            innerGedo.SetPos(X,Y+30);

                            if (!Show)text=new TextWithMeasure(textShow, X2, Y/*, BitmapFont.bitmapFont18*/);
                            else text=new TextWithMeasure(textHide, X2, Y/*, BitmapFont.bitmapFont18*/);
                        }
                    }
                }
            } else needAlpha=0;

            if (needAlpha!=colorChanger) {
                if (Constants.AnimationsControls) {
                    if (needAlpha<colorChanger) colorChanger-=5;
                    else colorChanger+=5;
                } else colorChanger=needAlpha;
            }
            color=new Color(0, colorChanger, 255);
            text.Draw(sb, color/**Constants.alpha*/);

            sb.Draw(Rabcr.Pixel, new Rectangle(X2, Y+underlinecount/*+y2*/, text.X+2, 1), color/**Constants.alpha*/);
            sb.Draw(Rabcr.Pixel, new Rectangle(X2, Y+1+underlinecount/*+y2*/, text.X+2, 1), color*0.5f/**(Constants.alpha)*/);

            if (Show) innerGedo.DrawGedo(Constants.alpha, sb);
        }

        bool In() {
         //   Console.WriteLine("X: "+X+", Y: "+Y+", M.X: "+Rabcr.newMouseState.X+", M.Y: "+(Rabcr.newMouseState.Y-mouseAdd2)+", t.X:"+text.X+", ma: "+mouseAdd2);
            if (Rabcr.newMouseState.X < X2) return false;
            if (Rabcr.newMouseState.Y+mouseAdd2< Y) return false;
            if (Rabcr.newMouseState.X > X2+text.X) return false;
            if (Rabcr.newMouseState.Y+mouseAdd2> Y+30) return false;
            return true;
        }

        public override int Height() {
            return text.NewLines*30+(Show ? innerGedo.GetHeight:0);
        }
    }

    public class GeDoStringAnimated : GeDoString{
        public int on, timer, len;
       public Color colorGoing, colorBack, colorBeet;
        public TextWithMeasure text;
        public override void Draw(SpriteBatch sb) {
            //DrawSelection(sb);
            timer--;
            if (timer<0) {
                timer=10;
                on++;
            }
            if (on>len) on=0;

            text.Draw(sb, colorBack/**Constants.alpha*/,0,on-1);
            if (on!=0)text.Draw(sb, colorBeet/**Constants.alpha*/,on-1,on);

            text.Draw(sb, colorGoing/**Constants.alpha*/,on,on+1);
            text.Draw(sb, colorBeet/**Constants.alpha*/,on+1,on+2);
            text.Draw(sb, colorBack/**Constants.alpha*/,on+2,len);

            //for (int ii = 0; ii<Text.Length; ii++) {
            //    if (on==ii)

            //        BitmapFont.bitmapFont18.DrawText(spriteBatch,g.Text[ii].ToString(),/*g.X x+*/X+(int)g.X+BitmapFont.bitmapFont18.MeasureTextSingleLineX(g.Text.Substring(0, ii)),Y+/*g. y+*/g.Line*30, new Color(255, 255, 255, alpha));
            //    else if (g2.on==ii+1||g2.on-1==ii)
            //        BitmapFont.bitmapFont18.DrawText(spriteBatch,g.Text[ii].ToString(),/*g.X x+*/X+(int)g.X+BitmapFont.bitmapFont18.MeasureTextSingleLineX(g.Text.Substring(0, ii)),Y+/*g. y+*/g.Line*30, new Color(128, 128, 128, alpha));
            //    else if (g2.on==ii-1||g2.on+1==ii)
            //    BitmapFont.bitmapFont18.DrawText(spriteBatch,g.Text[ii].ToString(),/*g.X x+*/X+(int)g.X+BitmapFont.bitmapFont18.MeasureTextSingleLineX(g.Text.Substring(0, ii)),Y+/*g. y+*/g.Line*30, new Color(128, 128, 128, alpha));
            //    //    spriteBatch.DrawString(spriteFont_small, g.Text[ii].ToString(), new Vector2(x+g.X+spriteFont_small.MeasureString(g.Text.Substring(0, ii)).X, y+g.Line*30), new Color(128, 128, 128, alpha));
            //    else
            //    BitmapFont.bitmapFont18.DrawText(spriteBatch,g.Text[ii].ToString(),/*g.X x+*/X+(int)g.X+BitmapFont.bitmapFont18.MeasureTextSingleLineX(g.Text.Substring(0, ii)),Y+/*g. y+*/g.Line*30, new Color(0, 0, 0, alpha));
            //    //    spriteBatch.DrawString(spriteFont_small, g.Text[ii].ToString(), new Vector2(x+g.X+spriteFont_small.MeasureString(g.Text.Substring(0, ii)).X, y+g.Line*30), new Color(0, 0, 0, alpha));
            //}
            //            g2.text.Draw(spriteBatch, g2.color*alpha/* new Color(255, 0, 0, alpha)*/);
            //
        }

        public override int Height() => text.NewLines*30;
    }

    public class GeDoStringBold: GeDoString{
        public TextWithMeasure text;
        public override void Draw(SpriteBatch sb) {
            //DrawSelection(sb);
            text.DrawBold(sb, Color.Black*Constants.alpha);
        }
        public override int Height() => text.NewLines*30;
    }

    public class GeDoStringItalic: GeDoString{
        readonly Color color;
        public TextWithMeasure text;
        public GeDoStringItalic() {
            color=Color.Black;
        }

        public override void Draw(SpriteBatch sb) {
            //DrawSelection(sb);
            text.DrawItalic(sb, color/**Constants.alpha*/);
        }
        public override int Height() => text.NewLines*30;
    }

    public class GeDoStringMark: GeDoString{
        public int X, Y;
        public TextWithMeasure text;
        public Color color;

        public override void Draw(SpriteBatch sb) {
            sb.Draw(Rabcr.Pixel,new Rectangle(X, Y, text.X+2,30), color/*new Color(173,216,255)*//**Constants.alpha*/);
            text.Draw(sb, Color.Black/**Constants.alpha*/);
        }
        public override int Height() => text.NewLines*30;
    }

    public class GeDoStringUnderline: GeDoString{
      //  public int X,Y;
      public int X, Y;

      public TextWithMeasure text;
        public override void Draw(SpriteBatch sb) {
            //DrawSelection(sb);
            sb.Draw(Rabcr.Pixel,new Rectangle(X, Y+27, text.X+2,1), new Color(0,0,0)/**Constants.alpha*/);
            text.Draw(sb, Color.Black/**Constants.alpha*/);
        }
        public override int Height() => text.NewLines*30;
    }

    public class GeDoStringArticle : GeDoString{
        public GeDo innerGedo;
        public int X, Y;
       // const int underlinecount=25;
    public string rawGedo;
       // public EventHandler ev;
       // Color color;
     public   bool wrap=false;
      //  int colorChanger;
        public int mouseAdd2;
      //  public TextWithMeasure text;
       // readonly int y2;
       // string b;
       // public int X,Y;
        //EventHandler changeHeight;
       // int gedoY, gedoX;
       int w;
        public GeDoStringArticle(string txt, int x, int y, int ww, int mouseAdd2, bool wr) {
            this.mouseAdd2=mouseAdd2;
         wrap=wr; w=ww;
            innerGedo=new GeDo(x, y) {
                mouseAdd=mouseAdd2-Y
            };
            innerGedo.width=w;
            rawGedo=txt;
            innerGedo.BuildString(Wrap());
            X=x;
            /*y2=*/ Y=y;

        }

        //public void Build(){
        //    ChangeWrap();

        //}



        public override void Draw(SpriteBatch sb) {
            innerGedo.DrawGedo(Constants.alpha, sb);
        }

        public void ChangeWrap(int max){
            w=max;
            //float spaceWidth = BitmapFont.bitmapFont18.MeasureTextSingleLineX(" ");
            //int maxLineWidth=w;
            //string[] words = rawGedo.Split(' ');
            //string sb = "";
            //float lineWidth = 0f;

            //foreach (string word in words) {
            //    int size;
            //    if (word.Contains("<") || word.Contains(">")) {
            //      //  int countgr = word.Count(f => f == '>');
            //      //  int countlw = word.Count(f => f == '<');

            //        string e=word;
            //        while (word.Contains("<")) {
            //            int lw=e.IndexOf('<');
            //            int gr=e.IndexOf('>');
            //            if (gr==-1) throw new Exception("Mezi <Article> a </Article> je (jsou) chybně zapsané tagy (zkontrolujte znaky < a >)");
            //            e=e.Substring(lw, gr-lw);
            //        }
            //        size = BitmapFont.bitmapFont18.MeasureTextSingleLineX(e);
            //    } else {
            //        size = BitmapFont.bitmapFont18.MeasureTextSingleLineX(word);
            //    }

            //    if (word.Contains("\r\n")){
            //        sb+= word + " ";
            //        lineWidth = size + spaceWidth;
            //    } else {
            //        if (lineWidth + size < maxLineWidth) {
            //            sb+=word + " ";
            //            lineWidth += size + spaceWidth;
            //        } else {
            //            sb+="\n" + word + " ";
            //            lineWidth = size + spaceWidth;
            //        }
            //    }
            //}

            innerGedo.BuildString(Wrap());

           // return ;
        }

        string Wrap(){
            if (!wrap) return rawGedo;
            float spaceWidth = BitmapFont.bitmapFont18.MeasureTextSingleLineX(" ");
            int maxLineWidth=w;
            string[] words = rawGedo.Split(' ');
            string sb = "";
            float lineWidth = 0f;

            foreach (string word in words) {
                int size;
                if (word.Contains("<") || word.Contains(">")) {
                  //  int countgr = word.Count(f => f == '>');
                  //  int countlw = word.Count(f => f == '<');

                    string e=word;
                    for (int i=0; i<Enum.GetNames(typeof(GeDoType)).Length; i++){
                        e=e.Replace("<"+((GeDoType)i)+">","");
                        e=e.Replace("</"+((GeDoType)i)+">","");
                    }
                    //while (word.Contains("<")) {
                    //    int lw=e.IndexOf('<');
                    //    int gr=e.IndexOf('>');
                    //    if (gr==-1) throw new Exception("Mezi <Article> a </Article> je (jsou) chybně zapsané tagy (zkontrolujte znaky < a >)");
                    //    e=e.Replace(e.Substring(lw,gr-lw),"");
                    //}
                    size = BitmapFont.bitmapFont18.MeasureTextSingleLineX(e);
                } else {
                    size = BitmapFont.bitmapFont18.MeasureTextSingleLineX(word);
                }

                if (word.Contains("\r\n")){
                    sb+= word + " ";
                    lineWidth = size + spaceWidth;
                } else {
                    if (lineWidth + size < maxLineWidth) {
                        sb+=word + " ";
                        lineWidth += size + spaceWidth;
                    } else {
                        sb+="\r\n" + word + " ";
                        lineWidth = size + spaceWidth;
                    }
                }
            }
          //  Console.WriteLine(sb);
            return sb;
        }
        public override int Height() => innerGedo.GetHeight;
    }
}