using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace rabcrClient {
    public class GeDoEvent{
        public string ID;
        public EventHandler Event;
    }

   public class GGeDo: IDisposable{
        #region Varibles
        const int lineSize=30;
        public int mouseAdd;
        public EventHandler changeHeight;

        int gedoLen;
        public string Text; public List<GeDoEvent> GeDoEvents;
        public bool Click;
      //  readonly List<GGeDoString> gedoLine=new List<GGeDoString>();
        public int mouseX, mouseY;
        readonly SolidBrush brushBlack=new SolidBrush(Color.Black);
        readonly Graphics g;
       // const int LineHeight=30;
        readonly Bitmap b;
        float TextW;
        List<GGeDoString> gedoBuilding;
        private readonly int X;
        private int Y;
        private readonly int yy2;

        GGeDoString[] gedoParts;
        #endregion

        public int GetHeight=>Y-yy2;

        public GGeDo(int x, int y) {
            X=x;
            Y=yy2=y;
            Text=null;
            GeDoEvents=new List<GeDoEvent>();
            b=new Bitmap(1,1);
            g=Graphics.FromImage(b);
        }

        public void BuildString(string txtBody) {
            Y=yy2;
            TextW=0;
            gedoBuilding=new List<GGeDoString>();

            while (true) {
                int gr=txtBody.IndexOf('<');
                if (gr>=0) {
                    if (!txtBody.Contains(">"))throw new Exception("Tag není jasně definován (chybí znak '>')");
                    int lw=txtBody.IndexOf('>');

                    int x1=gr+1,x2=lw-gr-1;

                    string itag=txtBody.Substring(x1,x2);
                    if (gr!=0) BuildNormal(Symbols(txtBody.Substring(0,gr)));
                    txtBody=txtBody.Substring(lw+1);

                    string moreInfo="";
                    if (itag.Contains("|")){
                        int sep=itag.IndexOf('|');
                        moreInfo=itag.Substring(sep+1);
                        itag=itag.Substring(0,sep);
                    }


                    int x=txtBody.IndexOf("</"+itag+">");
                    if (x==-1)throw new Exception("Chybí uzavření tagu");
                    string inTag=Symbols(txtBody.Substring(0, x));

                    if (Enum.TryParse(itag, out GeDoType tag)){
                        switch (tag) {
                            case GeDoType.Bold:
                                BuildPartBold(inTag);
                                break;

                            case GeDoType.Animated:
                                BuildPartAnimated(inTag,moreInfo);
                                break;

                            case GeDoType.Italic:
                                BuildPartItalic(inTag);
                                break;

                            case GeDoType.Link:
                                BuildPartLink(inTag,moreInfo);
                                break;

                            case GeDoType.Mark:
                                BuildPartMark(inTag,moreInfo);
                                break;

                            case GeDoType.Random:
                                BuildPartRandom(inTag);
                                break;

                            case GeDoType.Spoiler:
                                BuildPartSpoiler(inTag, moreInfo);
                                break;

                            case GeDoType.Underline:
                                BuildPartUnderline(inTag);
                                break;

                            case GeDoType.Superscript:
                                BuildPartSuperscript(inTag);
                                break;

                            case GeDoType.Subscript:
                                BuildPartSubscript(inTag);
                                break;

                            default:
                                BuildPartColored(tag, inTag);
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
            //string[] t=txt.Split('/');
            //if (t.Length>1) t[0]=t[0].Substring(1);
            //for (int i=0; i<t.Length; i++){
            //    string part=t[i].Substring(t[i].IndexOf('>')+1);
            //    if (part.Contains('<')){
            //        int gr=part.IndexOf('<'), lw=part.IndexOf('>');
            //        NewBuildNormal(part.Substring(0,gr));
            //        string itag=part.Substring(gr,lw-gr);
            //        if (Enum.TryParse(itag, out GeDoType tag)){
            //            switch (tag) {
            //                case GeDoType.Bold:
            //                    NewBuildPartBold(part.Substring(lw,part.Length-1-lw));
            //                    break;

            //                case GeDoType.Animated:
            //                    NewBuildPartAnimated(part.Substring(lw,part.Length-1-lw));
            //                    break;

            //                case GeDoType.Italic:
            //                    NewBuildPartItalic(part.Substring(lw,part.Length-1-lw));
            //                    break;

            //                case GeDoType.Link:
            //                    NewBuildPartLink(part.Substring(lw,part.Length-1-lw));
            //                    break;

            //                case GeDoType.Mark:
            //                    NewBuildPartMark(part.Substring(lw,part.Length-1-lw));
            //                    break;

            //                case GeDoType.Random:
            //                    NewBuildPartRandom(part.Substring(lw,part.Length-1-lw));
            //                    break;

            //                case GeDoType.Spoiler:
            //                    NewBuildPartSpoiler(part.Substring(lw,part.Length-1-lw));
            //                    break;

            //                case GeDoType.Underline:
            //                    NewBuildPartUnderline(part.Substring(lw,part.Length-1-lw));
            //                    break;

            //                default:
            //                    NewBuildPartColored(tag,part.Substring(lw,part.Length-1-lw));
            //                    break;
            //            }
            //            if (error) return;
            //        } else {
            //            ShowError(itag+" is not defined");
            //            return;
            //        }
            //    }else{
            //        NewBuildNormal(part);
            //    }
            //}
            //changeHeight.Invoke(this,null);

        }

        void BuildNormal(string tmpText) {
            if (tmpText.Contains(Environment.NewLine)) {
                string[] lines=tmpText.Split('\n');
                for (int i=0; i<lines.Length; i++) {

                    //first
                    if (i==0) {
                        GGeDoStringNormal gg = new GGeDoStringNormal {
                            X= X+(int)TextW,
                            Y=Y,
                            text=lines[i],
                        };
                        gedoBuilding.Add(gg);
                        Y+=lineSize;
                        TextW=0;

                    //last
                    } else if (i==lines.Length-1) {
                        GGeDoStringNormal gg = new GGeDoStringNormal {
                            X= X+(int)TextW,
                            Y=Y,
                            text=lines[i]
                        };
                        gedoBuilding.Add(gg);
                        TextW+=g.MeasureString(lines[i],Constants.font14).Width;

                    //middle
                    } else {
                        GGeDoStringNormal gg = new GGeDoStringNormal {
                            X= X+(int)TextW,
                            Y=Y,
                            text=lines[i]
                        };
                        gedoBuilding.Add(gg);
                        Y+=lineSize;
                    }
                }
            } else {
                GGeDoStringNormal gg = new GGeDoStringNormal {
                    X=(int)(X+TextW),
                    Y=Y,
                    text=tmpText,
                };
                gedoBuilding.Add(gg);
                TextW+=g.MeasureString(tmpText,Constants.font14).Width;
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
                GGeDoStringNormal gg = new GGeDoStringNormal {
                    X=(int)(X+TextW),
                    Y=Y-10,
                   // str=tmpText,
                    text=tmpText//new TextWithMeasure(, (int)(X+TextW), Y-10, BitmapFont.bitmapFont18)
                };
                gedoBuilding.Add(gg);
                TextW+=g.MeasureString(tmpText,Constants.font14).Width;
          //  }
        }

        void BuildPartSubscript(string tmpText) {
            //if (tmpText.Contains(Environment.NewLine)) {
            //    string[] lines=tmpText.Split('\n');
            //    for (int i=0; i<lines.Length; i++) {

            //        //first
            //        if (i==0) {
            //            GeDoStringNormal g = new GeDoStringNormal {
            //                //str=lines[i],
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y+10, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //            TextW=0;

            //        //last
            //        } else if (i==lines.Length-1) {
            //            GeDoStringNormal g = new GeDoStringNormal {
            //               // str=lines[i],
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y+10, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            TextW=g.text.X;

            //        //middle
            //        } else {
            //            GeDoStringNormal g = new GeDoStringNormal {
            //               // str=lines[i],
            //                text=new TextWithMeasure(lines[i], (int)(X+TextW), Y+10, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //        }
            //    }
            //} else {
                GGeDoStringNormal gg = new GGeDoStringNormal {
                    X=(int)(X+TextW),
                    Y=Y+10,
                   // str=tmpText,
                    text=tmpText//=new TextWithMeasure(, (int)(X+TextW), Y+10, BitmapFont.bitmapFont18)
                };
                gedoBuilding.Add(gg);
                TextW+=g.MeasureString(tmpText,Constants.font14).Width;
            //}
        }

        void BuildPartColored(GeDoType tag, string tmpText) {
            Color c=GetColorByTag(tag);
            //if (tmpText.Contains(Environment.NewLine)) {
            //    string[] lines=tmpText.Split('\n');
            //    for (int i=0; i<lines.Length; i++) {

            //        //first
            //        if (i==0) {
            //            GeDoStringColoredText g= new GeDoStringColoredText {
            //                color=c,
            //                //str=lines[i],
            //                text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //            TextW=0;

            //        //last
            //        } else if (i==lines.Length-1) {
            //            GeDoStringColoredText g= new GeDoStringColoredText {
            //                color=c,
            //               // str=lines[i],
            //                text=new TextWithMeasure(lines[i],X+(int)TextW, Y,BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            TextW=g.text.X;

            //        //middle
            //        } else {
            //            GeDoStringColoredText g= new GeDoStringColoredText {
            //                color=c,
            //               // str=lines[i],
            //                text=new TextWithMeasure(lines[i],(int)(X+TextW), Y,BitmapFont.bitmapFont18)
            //            };
            //            gedoBuilding.Add(g);
            //            Y+=lineSize;
            //        }
            //    }
            //} else {
                GGeDoStringColoredText gg= new GGeDoStringColoredText {
                    brush=new SolidBrush(c),
                    X=(int)(X+TextW),
                    Y=Y,
                    //str=tmpText,
                    text=tmpText//new TextWithMeasure(,(int)(X+TextW), Y,BitmapFont.bitmapFont18)
                };
                gedoBuilding.Add(gg);
                TextW+=g.MeasureString(tmpText,Constants.font14).Width;
           // }
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
                GGeDoStringBold gg= new GGeDoStringBold {
                    //str=tmpText,
                    X=(int)(X+TextW),
                    Y=Y,
                   text=tmpText//new TextWithMeasure(,, Y,BitmapFont.bitmapFont18)
                };
                gedoBuilding.Add(gg);
                TextW+=g.MeasureString(tmpText,Constants.font14).Width;
            //}
        }

        void BuildPartItalic(string tmpText) {
            if (tmpText.Contains(Environment.NewLine)) {
                string[] lines = tmpText.Split('\n');
                for (int i = 0; i<lines.Length; i++) {

                    //first
                    if (i==0) {
                        GGeDoStringItalic g = new GGeDoStringItalic {
                             X=(int)(X+TextW),
                    Y=Y,
                    text=lines[i]
                          //  text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18)
                        };
                        gedoBuilding.Add(g);
                        Y+=lineSize;
                        TextW=0;

                        //last
                    } else if (i==lines.Length-1) {
                        GGeDoStringItalic gg = new GGeDoStringItalic {
                             X=(int)(X+TextW),
                    Y=Y,
                    text=lines[i]
                       //     text=new TextWithMeasure(lines[i], X+(int)TextW, Y, BitmapFont.bitmapFont18)
                        };
                        gedoBuilding.Add(gg);
                       // TextW=g.text.X;
                        TextW+=g.MeasureString(tmpText,Constants.font14).Width;

                        //middle
                    } else {
                        GGeDoStringItalic g = new GGeDoStringItalic {
                             X=(int)(X+TextW),
                    Y=Y,
                    text=lines[i]
                            //text=new TextWithMeasure(lines[i], (int)(X+TextW), Y, BitmapFont.bitmapFont18)
                        };
                        gedoBuilding.Add(g);
                        Y+=lineSize;
                    }
                }
            } else {
                GGeDoStringItalic gg = new GGeDoStringItalic {
                    X=(int)(X+TextW),
                    Y=Y,
                    text=tmpText
                    //text=new TextWithMeasure(tmpText, (int)(X+TextW), Y, BitmapFont.bitmapFont18)
                };
                gedoBuilding.Add(gg);
                TextW+=g.MeasureString(tmpText,Constants.font14).Width;
            }
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
                GGeDoStringAnimated gg= new GGeDoStringAnimated {
                    X=(int)(X+TextW),
                    Y=Y,
                   text=/*new TextWithMeasure(*/tmpText/*,, Y,BitmapFont.bitmapFont18)*/
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
                            gg.colorBack=new SolidBrush(StringToColor(what));//new Color(clrColor.R, clrColor.G, clrColor.B, (byte)255);
                            backset=true;
                        }
                        if (name=="fore"){
                            //CColor clrColor = CColor.FromName(what);
                            gg.colorGoing=new SolidBrush(StringToColor(what));//(new Color(clrColor.R, clrColor.G, clrColor.B, (byte)255);
                            foreset=true;
                        }
                    }
                }


                if (!backset) gg.colorBack=new SolidBrush(Color.Black);
                if (!foreset) gg.colorGoing=new SolidBrush(Color.White);
                gg.colorBeet=new SolidBrush(Color.FromArgb((gg.colorBack.Color.R+gg.colorGoing.Color.R)/2, (gg.colorBack.Color.G+gg.colorGoing.Color.G)/2, (gg.colorBack.Color.B+gg.colorGoing.Color.B)/2));

                gg.len=tmpText.Length;
                //if (gedoBuilding==null)return;
                gedoBuilding.Add(gg);
               TextW+=g.MeasureString(tmpText,Constants.font14).Width;
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
                GGeDoStringUnderline gg= new GGeDoStringUnderline {
                    X=(int)TextW+X,
                    Y=Y,
                    text=tmpText
                };
               // gg.text=new TextWithMeasure(,(int)(X+TextW), Y,BitmapFont.bitmapFont18);
                gedoBuilding.Add(gg);
                TextW+=g.MeasureString(tmpText,Constants.font14).Width;
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
            int w=(int)g.MeasureString(tmpText,Constants.font14).Width;
                GGeDoStringMark gg= new GGeDoStringMark((int)TextW+X,Y,w) {
                    X=(int)(X+TextW),
                    Y=Y,
                    text=/*new TextWithMeasure(*/tmpText/*,(int)(X+TextW), Y,BitmapFont.bitmapFont18)*/
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
                            gg.brushBack=new SolidBrush(StringToColor(what));// new Color(clrColor.R, clrColor.G, clrColor.B, (byte)255);
                            set=true;
                        }
                    }
                }

                if (!set) gg.brushBack=new SolidBrush(Color.FromArgb(173, 216, 255));

                gedoBuilding.Add(gg);
                TextW+=w;
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
            int w=(int)g.MeasureString(tmpText,Constants.font14).Width;

            GGeDoStringLink gg = new GGeDoStringLink(tmpText, (int)(X+TextW), Y, w) {
                mouseAdd2=mouseAdd,
            };

            string[] moreinforaw=more.Split('|');

            for (int i=0; i<moreinforaw.Length; i++){
                string str=moreinforaw[i];
                if (str.Contains("=")) {
                    int sep=str.IndexOf('=');
                    string name=str.Substring(0,sep);
                    string what=str.Substring(sep+1);
                    if (name=="url") {
                        gg.url=what;
                        gg.action=GGeDoStringLink.Action.Url;
                    }
                    if (name=="event"){
                        gg.action=GGeDoStringLink.Action.Event;

                        foreach (GeDoEvent ge in GeDoEvents) {
                            if (ge.ID==what) {
                                gg.ev=ge.Event;
                                break;
                            }
                        }
                    }
                }
            }

            gedoBuilding.Add(gg);
            TextW+=w;
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
                GGeDoStringRandom gg = new GGeDoStringRandom {
                    X=(int)(X+TextW),
                    Y=Y,
                    text=/*new TextWithMeasure(*/tmpText/*, , Y, BitmapFont.bitmapFont18)*/
                };
                gedoBuilding.Add(gg);
                TextW+=g.MeasureString(tmpText,Constants.font14).Width;
           // }
        }

        void BuildPartSpoiler(string tmpText, string more) {
            string showText="", hideText="";
            string[] moreinforaw=more.Split('|');

            for (int i=0; i<moreinforaw.Length; i++){
                 string str=moreinforaw[i];
                int sep=str.IndexOf('=');
                string name=str.Substring(0,sep);
                string what=str.Substring(sep+1);
                if (name=="show")showText=what;
                if (name=="hide")hideText=what;
            }

            if (showText=="") showText=Lang.Texts[292];
            if (hideText=="") hideText=Lang.Texts[293];

            GGeDoStringSpoiler gg = new GGeDoStringSpoiler(tmpText, (int)(X+TextW), Y, mouseAdd) {

                textShow=showText,
                textHide=hideText
            };
            gg.ev=ChangeGeDoStrucBySpoiler;

            gg.Build();
            gedoBuilding.Add(gg);
            TextW=0;

          //  Y+=/*g.innerGedo.GetHeight+*/lineSize;
        }

        Color GetColorByTag(GeDoType tag){
            switch (tag) {
                case GeDoType.Blue: return Color.FromArgb(20,64,224);
                case GeDoType.Green: return Color.FromArgb(32,128,0);
                case GeDoType.Red: return Color.FromArgb(255,0,0);
                case GeDoType.DarkBlue: return Color.FromArgb(0,0,128);
                case GeDoType.DarkGreen: return Color.FromArgb(0,64,0);
                case GeDoType.DarkRed: return Color.FromArgb(128,0,0);
                case GeDoType.Orange: return Color.FromArgb(255,92,0);
                case GeDoType.LightGreen: return Color.FromArgb(0,255,0);
                case GeDoType.LightBlue: return Color.FromArgb(128,192,255);
                case GeDoType.DarkGray: return Color.FromArgb(64,64,64);
                case GeDoType.Gold: return Color.FromArgb(120,120,0);
                case GeDoType.Yellow: return Color.FromArgb(220,220,0);
                case GeDoType.Gray: return Color.FromArgb(128,128,128);
                case GeDoType.Teal: return Color.FromArgb(0,128,128);
                case GeDoType.Purple: return Color.FromArgb(255,0,255);
                case GeDoType.Pink: return Color.FromArgb(255,128,172);
                case GeDoType.Brown: return Color.FromArgb(128,30,0);
                case GeDoType.Black: return Color.FromArgb(0,0,0);
                case GeDoType.White: return Color.FromArgb(255,255,255);
                default: return Color.Black;
            }
        }

        void ChangeGeDoStrucBySpoiler(object o, EventArgs e) {

            GGeDoString g2 = o as GGeDoString;
            GGeDoStringSpoiler spoiler=(GGeDoStringSpoiler)g2;
            bool start=false;
            int yAdd;
            if (spoiler.Show) yAdd=spoiler.innerGedo.GetHeight;
            else yAdd=-spoiler.innerGedo.GetHeight;
            foreach (GGeDoString gs in gedoParts) {
                if (!start){
                    if (gs==g2) {
                        start=true;

                    }
                }else{
                    gs.Y+=yAdd;
                    // foreach (DrawingChar s in gs.text.Chars){
                    //  ///  s.Pos.X=s.Pos.X-X+newX;
                    //    s.Pos.Y+=yAdd;
                    //}
                    //{
                    //    if (gs is GeDoStringLink g) g.Y+=yAdd;
                    //}
                    //{
                    //    if (gs is GeDoStringMark g) g.Y+=yAdd;
                    //}

                    //{
                    //    if (gs is GeDoStringUnderline g) g.Y+=yAdd;
                    //}
                }
            }
            Y+=yAdd;
            if (changeHeight!=null)changeHeight.Invoke(null,null);
        }

        string Symbols(string s) {
            return s
                .Replace("&g;",">")
                .Replace("&l;","<")
                .Replace("&h;","♥")
                .Replace("&s;","☺")
                .Replace("&w;","☹")
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

        public void DrawGedo(float a, Graphics g) {
            Constants.alpha=a;

            //Pos();
            for (int i=0; i<gedoLen; i++) {
                if (gedoParts[i] is GGeDoStringLink gg) {
                    gg.Click=Click;
                    gg.MouseX=mouseX;
                    gg.MouseY=mouseY;
                }
                if (gedoParts[i] is GGeDoStringSpoiler gg2) {
                    gg2.Click=Click;
                    gg2.MouseX=mouseX;
                    gg2.MouseY=mouseY;
                }
                gedoParts[i].Draw(g);
            }
        }

        bool isDisposed;

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing){
            if (isDisposed) return;

            g.Dispose();
            b.Dispose();
            brushBlack.Dispose();
            if (gedoParts!=null)foreach (var g in gedoParts)g.Dispose();

            isDisposed = true;
        }

        ~GGeDo() => Dispose(false);
    }

    public abstract class GGeDoString: IDisposable{
        public string text;
        public int X, Y;
        bool isDisposed;

        public abstract void Draw(Graphics g);

        public abstract void XDisponse();

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing){
            if (isDisposed) return;
            XDisponse();
            isDisposed = true;
        }

        ~GGeDoString() => Dispose(false);
    }

    public class GGeDoStringColoredText : GGeDoString{
        public SolidBrush brush;

        public override void Draw(Graphics g) {
            NativeMethods.Text(g, text, X, Y, brush);
        }

        public override void XDisponse() {
            brush.Dispose();
        }
    }

    public class GGeDoStringNormal : GGeDoString{
        readonly SolidBrush brush;

        public GGeDoStringNormal() {
            brush=new SolidBrush(Color.Black);
        }

        public override void XDisponse() {
            brush.Dispose();
        }

        public override void Draw(Graphics g) => NativeMethods.Text(g, text, X, Y, brush);
    }

    public class GGeDoStringRandom : GGeDoString{
        SolidBrush brush;

        public GGeDoStringRandom() {
            brush=new SolidBrush(Color.Black);
        }

        public override void XDisponse() => brush.Dispose();

        public override void Draw(Graphics g) {
            brush.Dispose();
            brush=new SolidBrush(FastRandom.ColorSystemDrawing()/* Color.FromArgb(FastRandom.Byte(),FastRandom.Byte(),FastRandom.Byte())*/);
            NativeMethods.Text(g, text, X, Y, brush);
        }
    }

    public class GSubscript: GGeDoString{
        readonly SolidBrush brush;

        public GSubscript() {
            brush=new SolidBrush(Color.Black);
        }

        public override void XDisponse() => brush.Dispose();

        public override void Draw(Graphics g) => NativeMethods.Text(g, text, X, Y, brush);
    }

    public class GSuperscript: GGeDoString{
        readonly SolidBrush brush;

        public GSuperscript() => brush=new SolidBrush(Color.Black);

        public override void XDisponse() => brush.Dispose();

        public override void Draw(Graphics g) => NativeMethods.Text(g, text, X, Y, brush);
    }

    public class GGeDoStringLink : GGeDoString{
        public string url;
        public enum Action: byte{
            None,
            Url,
            Event
        }
        public Action action;

       // const int underlinecount=25;

        bool click;
        public EventHandler ev;

        int colorChanger;
        public int mouseAdd2;
        public int y2;
        SolidBrush brush;
       // readonly Font font;
        readonly int w;
        public int MouseX, MouseY;
        public bool Click;

        public GGeDoStringLink(string txt, int x, int y, int ww){
            brush=new SolidBrush(Color.Black);
            X=x;
            text=txt;
            w=X+ww;
            Y=y;
        }

        public override void Draw(Graphics g) {
            int needAlpha;
           // if (Click)Debug.WriteLine(2);

            if (In()) {
               // if (Click)Debug.WriteLine(3);
                if (Click) {
                    needAlpha=110;
                    click=true;
                } else {
                //    if (Click)Debug.WriteLine(4);
                    needAlpha=80;

                    if (click) {
                        click=false;
                        switch (action){
                            case Action.Event:
                                ev.Invoke(this, null);
                                break;

                            case Action.Url:
                                try {
                                    Process.Start(url);
                                } catch {
                                    Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location, " /Message \"<Red>Web nenalezen.</Red><NewLine>Nejprve zkontrolujte zda se jedná o webovou adresu, pukud problém přetrvává<NewLine>zkuste přidat <Green>www</Green>, <Green>\"http://\"</Green> či <Green>\"https://\"</Green>.\"");
                                }
                                break;
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
             brush=new SolidBrush(Color.FromArgb(0, colorChanger, 255));

            NativeMethods.TextUnderline(g,text,X,Y,brush);
        }

        bool In() {
            if (MouseX < X) return false;
            if (MouseY+mouseAdd2< Y) return false;
            if (MouseX > w) return false;
            if (MouseY+mouseAdd2> Y+30) return false;
            return true;
        }

        public override void XDisponse() {
            brush.Dispose();
        }
    }

    public class GGeDoStringSpoiler : GGeDoString{
        public string textShow, textHide;
        public bool Show;
        public GGeDo innerGedo;
        public string Text;
        public string Link;

       // const int underlinecount=25;
        bool click;
        public EventHandler ev;
        SolidBrush brush;
        int colorChanger;
        public int mouseAdd2;
     //   readonly int y2;
        public bool Click;
        public int MouseX, MouseY;
        int w;

        public GGeDoStringSpoiler(string txt, int x, int y, int mouseAdd2) {
            this.mouseAdd2=mouseAdd2;
            innerGedo=new GGeDo(x, y+30) {
                mouseAdd=mouseAdd2-Y
            };

            innerGedo.BuildString(txt);
            w=0;
            X=x;
            /*y2=*/ Y=y;

        }

        public void Build(){
            text=textShow;
        }

        public override void Draw(Graphics g) {
            int needAlpha;
            if (w==0) w=(int)g.MeasureString(text,Constants.font14).Width;
            if (In()) {
                if (Click) {
                    needAlpha=110;
                    click=true;
                } else {
                    needAlpha=80;

                    if (click) {
                        click=false;
                        if (Rabcr.ActiveWindow) {
                            Show=!Show;
                            ev.Invoke(this,null);
                            if (!Show)text=textShow;
                            else text=textHide;
                            w=(int)g.MeasureString(text,Constants.font14).Width;
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
            brush=new SolidBrush(Color.FromArgb(0, colorChanger, 255));

            NativeMethods.TextUnderline(g,text,X,Y,brush);

            if (Show) innerGedo.DrawGedo(1,g);
        }

        bool In() {
            if (MouseX < X) return false;
            if (MouseY+mouseAdd2< Y) return false;
            if (MouseX > w) return false;
            if (MouseY+mouseAdd2> Y+30) return false;
            return true;
        }

        public override void XDisponse() => brush.Dispose();
    }

    public class GGeDoStringAnimated : GGeDoString{
        public int on, timer, len;
        public SolidBrush colorGoing, colorBack, colorBeet;

        public override void XDisponse() {
            colorGoing.Dispose();
            colorBack.Dispose();
            colorBeet.Dispose();
        }

        public override void Draw(Graphics g) {
            timer--;
            if (timer<0) {
                timer=10;
                on++;
            }
            if (on>len) on=0;
            if (text.Length>2){
                string b1=(on==0)?"":text.Substring(0,on);
                NativeMethods.Text(g, b1, X, Y, colorBack);

                int w=b1==""? 0:(int)g.MeasureString(b1, Constants.font14).Width;
                string b2=(text.Length>on)?text.Substring(on, 1):"";
                NativeMethods.Text(g, b2, X+w, Y, colorBeet);

                w+=(int)g.MeasureString(b2, Constants.font14).Width;
                string b3=(text.Length>on+1)?text.Substring(on+1, 1):"";
                NativeMethods.Text(g, b3, X+w, Y, colorGoing);

                w+=(int)g.MeasureString(b3, Constants.font14).Width;
                string b4=(text.Length>on+2)?text.Substring(on+2, 1):"";
                NativeMethods.Text(g, b4, X+w, Y, colorBeet);

                w+=(int)g.MeasureString(b4, Constants.font14).Width;
                NativeMethods.Text(g, (on+3<text.Length) ?text.Substring(on+3):"", X+w, Y, colorBack);
            }else{
                if (text.Length==2){
                    if (on==0){
                        string s=text[0].ToString();
                        NativeMethods.Text(g, s, X, Y, colorBack);
                        NativeMethods.Text(g, text[1].ToString(), X+(int)g.MeasureString(s, Constants.font14).Width, Y, colorGoing);
                    }else{
                        string s=text[0].ToString();
                        NativeMethods.Text(g, s, X, Y, colorGoing);
                        NativeMethods.Text(g, text[1].ToString(), X+(int)g.MeasureString(s, Constants.font14).Width, Y, colorBack);
                    }
                }else if (text.Length==1){
                    if (on==0){
                        NativeMethods.Text(g, text, X, Y, colorBack);
                    }else{
                        NativeMethods.Text(g, text, X, Y, colorGoing);

                    }
                }
            }
        }
    }

    public class GGeDoStringBold: GGeDoString{
        readonly SolidBrush brush;
        readonly Font font;

        public override void XDisponse() {
            brush.Dispose();
            font.Dispose();
        }

        public GGeDoStringBold() {
            brush=new SolidBrush(Color.Black);
            font=new Font(Constants.font14.FontFamily, 14, FontStyle.Bold);
        }

        public override void Draw(Graphics g) => NativeMethods.Text(g, font, text, X, Y, 255);
    }

    public class GGeDoStringItalic: GGeDoString{
      //  readonly Color color;
        readonly Font font;

        public GGeDoStringItalic() {
           // color=Color.Black;
            font=new Font(Constants.font14.FontFamily, 14, FontStyle.Italic);
        }

        public override void XDisponse() {
            font.Dispose();
        }

        public override void Draw(Graphics g) => NativeMethods.Text(g, font, text, X, Y, 255);
    }

    public class GGeDoStringMark: GGeDoString{
        readonly SolidBrush brush;
        public SolidBrush brushBack;
        Rectangle rec;

        public GGeDoStringMark(int X, int Y, int W) {
            brush=new SolidBrush(Color.Black);
            rec=new Rectangle(X,Y-5,W,30);
        }

        public override void XDisponse() {
            brush.Dispose();
            brushBack.Dispose();
        }

        public override void Draw(Graphics g) {
            g.FillRectangle(brushBack,rec);
            NativeMethods.Text(g, text, X, Y, brush);
        }
    }

    public class GGeDoStringUnderline: GGeDoString {
        readonly SolidBrush brush;
        readonly Font font;

        public GGeDoStringUnderline() {
            brush=new SolidBrush(Color.Black);
            font=new Font(Constants.font14.FontFamily, 14, FontStyle.Underline);
        }

        public override void XDisponse() {
            brush.Dispose();
            font.Dispose();
        }

        public override void Draw(Graphics g) => NativeMethods.Text(g, font, text, X, Y, 255);
    }
}