using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace rabcrClient {
    public class Text{
        readonly DrawingChar[] Chars;
        readonly BitmapFont font;
        int X, Y;
        readonly int Length;
        // connect on the right side and never connect on the left side
      //  static readonly char[] selfishArabicCharsL={' '};//, 'و', 'ز', 'ر', 'ذ', 'د', 'ا' ,/*?*/'ۇ','\uFEFB','ە'};//

        // never connect on the right side and  onnect on the left side
       // static readonly char[] selfishArabicCharsR = { ' ' };//, /*'و',*/ /*'ز',*/ /*'ر',*/ /*'ذ', 'د',*/ 'ا', /*?'ۇ',*/'ي' };
      //  static readonly char[] arabicDisconnecters = {/* '\uFC62', '\u064B', '\u064C', '\u064D', '\u064E', '\u064F', '\u0650', '\u0651', '\u0652', '\u0653', '\u0654', '\u0655'*/ };

        //static bool IsSelfishL(char ch) {
        //    foreach (char c in selfishArabicCharsL) {
        //        if (c==ch) return true;
        //    }
        //    return false;
        //}

        //static bool IsSelfishR(char ch) {
        ////    if ((int)ch==ArabicFinalFormConventer((int)ch))return true;
        //    foreach (char c in selfishArabicCharsR) {
        //        if (c==ch) return true;
        //    }
        //    return false;
        //}

        //static bool IsAsrabicDisconecter(char ch) {
        //  //  if ((int)ch==ArabicInitialFormConventer((int)ch))return true;
        //    foreach (char c in arabicDisconnecters) {
        //        if (c==ch) return true;
        //    }
        //    return false;
        //}

        public Text(string txt, int x, int y, BitmapFont f) {
            if (txt==null) {
                Chars=new DrawingChar[0];
                return;
            }

            font=f;
            List<DrawingChar> tmpChs=new List<DrawingChar>();
            //txt=txt.Replace("\u200E","");
            //txt=txt.Replace(((char)1617).ToString()+((char)1614).ToString(),"\uFC62");
            //txt=txt.Replace(((char)1575).ToString()+((char)1604).ToString(),"\uFEFB");
            //txt=txt.Replace(((char)1573).ToString()+((char)1604).ToString(),"\uFEF9");//ل ا  ء <- ل إ
           // txt=
            char[] chs=BuildArabicText(txt);//txt.ToCharArray();
            int posx=x;

//#if DEBUG
//            bool add=false;
//#endif

            //if (IsUjgur(txt) || IsArabic(txt)){

            //    Glyph g;
            //    for (int ch = 0; ch<chs.Length; ch++) {

            //        #if DEBUG
            //        bool add=false;
            //        #endif

            //     //for (int ch = chs.Length-1; ch>=0; ch--) {
            //        int numChar=chs[ch];
            //        bool spaceBef, spaceAf;
            //        //if (ch==0)spaceBef=true;
            //        //else {
            //        //    if (IsAsrabicDisconecter(chs[ch-1])) {
            //        //        if (ch==1) spaceBef=true;
            //        //        else spaceBef=IsSelfishR(chs[ch-2]);
            //        //    } else {
            //        //        spaceBef=IsSelfishR(chs[ch-1]);
            //        //    }
            //        //}
            //        //if (ch==chs.Length-1)spaceAf=true;
            //        //else {
            //        //    if (IsAsrabicDisconecter(chs[ch+1])) {
            //        //        if (ch==chs.Length-2) spaceAf =true;
            //        //        else spaceAf=IsSelfishL(chs[ch+2]);
            //        //    }else{
            //        //        spaceAf =IsSelfishL(chs[ch+1]);
            //        //    }
            //        //}
            //        //System.Diagnostics.Debug.WriteLine((char)numChar+" "+numChar+" bef:"+spaceBef+" af:"+spaceAf);

            //        //if (ch==0) spaceBef=true;
            //        //else {
            //        //    if (IsAsrabicDisconecter(chs[ch-1])) {
            //        //        if (ch==1) spaceBef=true;
            //        //        else spaceBef=IsSelfishR(chs[ch-2]);
            //        //    } else {
            //        //        spaceBef=IsSelfishR(chs[ch-1]);
            //        //    }
            //        //}
            //        //if (ch==chs.Length-1) spaceAf=true;
            //        //else {
            //        //    if (IsAsrabicDisconecter(chs[ch+1])) {
            //        //        if (ch==chs.Length-2) spaceAf=true;
            //        //        else spaceAf=IsSelfishL(chs[ch+2]);
            //        //    } else {
            //        //        spaceAf=IsSelfishL(chs[ch+1]);
            //        //    }
            //        //}
            //        //System.Diagnostics.Debug.WriteLine((char)numChar+" "+numChar+" bef:"+spaceBef+" af:"+spaceAf);



            //        //if (spaceBef){
            //        //    if (spaceAf){

            //        //    }else{
            //        //        numChar=ArabicFinalFormConventer(numChar);

            //        //    }
            //        //}else{
            //        //    if (spaceAf){
            //        //       numChar=ArabicInitialFormConventer(numChar);
            //        //    } else{
            //        //       numChar=ArabicMedialFormConventer(numChar);
            //        //    }
            //        //}
            //        //System.Diagnostics.Debug.Write((char)numChar+" "+numChar+" -> ");

            //        //System.Diagnostics.Debug.Write((char)numChar+" "+numChar);
            //        //System.Diagnostics.Debug.WriteLine(" b:"+spaceBef+" a:"+spaceAf);

            //        if (ch==0) {
            //            if (chs.Length>1) { 
            //                if (IsArabicLetter(chs[1])) {
            //                    if (HaveInitialForm(chs[1])) numChar=ArabicFinalFormConventer(numChar);
            //                }
            //            }
            //        } else if (ch==chs.Length-1) {
            //            if (chs.Length>1) { 
            //                if (IsArabicLetter(chs[chs.Length-1-1])) {
            //                    if (HaveFinalForm(chs[chs.Length-1-1])) numChar=ArabicInitialFormConventer(numChar);
            //                }
            //            }
            //        } else { 
            //            bool start=IsArabicLetter(chs[ch+1]); // if starts with arabic letter
            //            bool end=IsArabicLetter(chs[ch-1]); // if ends with arabic letter

            //          //  if (start || end) { 
            //                bool e=end;
            //                bool s=start;

            //                if (e) e=HaveFinalForm(chs[ch-1]);
            //                if (s) s=HaveInitialForm(chs[ch+1]);
            //                int old=numChar;
            //                if (s && e) numChar=ArabicMedialFormConventer(numChar);
            //                else if (s && !e) numChar=ArabicFinalFormConventer(numChar);
            //                else if (!s && e) numChar=ArabicInitialFormConventer(numChar);

            //              //  System.Diagnostics.Debug.WriteLine(txt+": ch:"+ch+" s:"+s+" e:"+e+" "+(char)old+" > "+(char)numChar);
            //            //bool s=HaveInitialForm(chs[ch-1]);
                       

            //            //    if (start && !end) start=HaveInitialForm(chs[ch-1]);
            //            //    bool hif=


            //            //    if (hif) numChar=ArabicFinalFormConventer(numChar);
            //            //    else numChar=ArabicInitialFormConventer(numChar);
            //           // }
            //        }

//                    for (int gg = 0; gg<font.Glyphs.Length; gg++) {
//                        if (numChar==(char)(g = font.Glyphs[gg]).Code) {
//                            if (g.visible) {
//                                tmpChs.Add(
//                                    new DrawingChar{
//                                        Pos=new Vector2(posx+g.X,y+g.Y),
//                                        Rectangle=g.DrawRectangle,
//                                    }
//                                );
//                             //   if (!IsAsrabicDisconecter((char)numChar))
//                                posx+=g.DrawRectangle.Width+g.X+g.W;
//                            } else {
//                                posx+=g.W;
//                            }
//#if DEBUG
//                                add=true;
//                                //if (g.DrawRectangle.Width>10)Debug.WriteLine("Char '"+(char)numChar+"' has g.DrawRectangle.Width "+g.DrawRectangle.Width);
//                                //if (g.W>10 || g.W<0)Debug.WriteLine("Char '"+(char)numChar+"' has g.W "+g.W);
//                                //if (g.X>10|| g.X<0)Debug.WriteLine("Char '"+(char)numChar+"' has g.X "+g.X);
//#endif
//                            break;
//                        }
//                    }
//#if DEBUG
//                // Unknown char
//                if (!add) {
//                    for (int gg = 0; gg<font.Glyphs.Length; gg++) {
//                        if ('�'==(char)(g = font.Glyphs[gg]).Code) {
//                            tmpChs.Add(
//                                new DrawingChar {
//                                    Pos=new Vector2(posx+g.X, y+g.Y),
//                                    Rectangle=g.DrawRectangle,
//                                }
//                            );
//                            posx+=g.DrawRectangle.Width+g.X+g.W;
//                            Debug.WriteLine("Nonsuported char "+(int)numChar);
//                            break;
//                        }
//                    }
//                }
//#endif
//                }
//            } else {
                Glyph g;
                for (int ch = 0; ch<chs.Length; ch++) {

                    #if DEBUG
                    bool add=false;
                    #endif

                    for (int gg = 0; gg<font.Glyphs.Length; gg++) {
                        if (chs[ch]==(char)(g = font.Glyphs[gg]).Code) {
                            if (g.visible) {
                                tmpChs.Add(
                                    new DrawingChar{
                                        Pos=new Vector2(posx+g.X,y+g.Y),
                                        Rectangle=g.DrawRectangle,
                                    }
                                );

                                posx+=g.DrawRectangle.Width+g.X+g.W;
                            } else {
                                posx+=g.W;
                            }
                            #if DEBUG
                            add=true;
                            #endif
                            break;
                        }
                    }
                
                    #if DEBUG
                    // Unknown char
                    if (!add){///continue;  //if (add)///continue;
                        for (int gg = 0; gg<font.Glyphs.Length; gg++) {
                            if ('�'==(char)(g = font.Glyphs[gg]).Code) {
                                tmpChs.Add(
                                    new DrawingChar {
                                        Pos=new Vector2(posx+g.X, y+g.Y),
                                        Rectangle=g.DrawRectangle,
                                    }
                                );
                                posx+=g.DrawRectangle.Width+g.X+g.W;
                                Debug.WriteLine("Nonsuported char '"+(int)chs[ch]+"', font: "+Lang.Languages[Setting.CurrentLanguage].FontFile);
                                break;
                            }
                        } 
                    }
                    #endif
               // }
            }
            Chars=tmpChs.ToArray();
            X=x;
            Y=y;

            Length=Chars.Length;
        }

        public void Draw(SpriteBatch sb) {
            for (int i=0; i<Length; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(font.Bitmap, ch.Pos, ch.Rectangle, Color.Black);
            }
        }

        public void Draw(SpriteBatch sb, Color c) {
            for (int i=0; i<Length; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(font.Bitmap, ch.Pos, ch.Rectangle, c);
            }
        }

        public float MeasureX() {
            if (/*Chars.*/Length>1) return Chars[/*Chars.*/Length-1].Pos.X-Chars[0].Pos.X+Chars[/*Chars.*/Length-1].Rectangle.Width;
            if (/*Chars.*/Length==1) return Chars[0].Rectangle.Width;
            return 0;
        }

      //  public float MeasureY() => font.Size*2;

        public void ChangePosition(int newX, int newY) {
        //    if (newX!=X || newY!=Y) {
            int deltaX=newX-X,
                deltaY=newY-Y;

            foreach (DrawingChar ch in Chars) {
                ch.Pos.X+=deltaX;
                ch.Pos.Y+=deltaY;
            }

            X=newX;
            Y=newY;
        }

        //bool IsUjgur(string s) {
        //    if (Lang.IsUjgur) {
        //        return true;
        //    } else {
        //        foreach (char ch in s) {
        //            switch (ch) {
        //                case 'ى':
        //                    return true;
        //                case 'ل':
        //                    return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
        //bool IsArabic(string s) {
        //    if (Lang.IsArabic) {

        //        return true;
        //    } else {
        //        foreach (char ch in s) {
        //            switch (ch) {
        //                case 'ى':
        //                    return true;
        //                case 'ل':
        //                    return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
        //bool isArabic(string s){
        //    if (Lang.IsUjgur){

        //        return true;
        //    }else{
        //        foreach (char ch in s) {
        //            switch (ch) {
        //                case 'ى': return true;
        //                case 'ل': return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        static int ArabicFinalFormConventer(int s){
            switch (s){
                case 1609: return 65264;
                case 1577: return 65172;
                case 1570: return 65154;
                case 1610: return 65266;
                case 1578: return 65174;
                case 1594: return 65230;
                case 1576: return 65168;
                case 1604: return 65246;
                case 1583: return 65193;
                case 1601: return 65234;
                case 1606: return 65254;
                case 1593: return 65226;
                case 1605: return 65250;
                case 1585: return 65198;
                case 1603: return 65242;
                case 1749: return 65258;//?
                case 1574: return 65162;
                case 1735: return 64472;
                case 1670: return 64379;
                case 1575: return 65166;
                case 1579: return 65178;
                case 1580: return 65182;
                case 1581: return 65186;
                case 1582: return 65190;
                case 1584: return 65196;
                case 1586: return 65200;
                case 1587: return 65202;
                case 1588: return 65206;
                case 1589: return 65210;
                case 1590: return 65214;
                case 1591: return 65218;
                case 1592: return 65222;
                case 1602: return 65238;
                case 1607: return 65258;
                case 1608: return 65262;
                case 1571: return 65156;
                case 1573: return 65160;
                case 1572: return 65158;
                case 1709: return 64468;
                case 1736: return 64476;
                case 1726: return 64427;
                case 1711: return 64403;
            }
            return s;
        }

        static int ArabicInitialFormConventer(int s){
            switch (s){
                case 1578: return 65175;
                case 1594: return 65231;
                case 1574: return 65163;
                case 1610: return 65267;
                case 1576: return 65169;
                case 1601: return 65235;
                case 1606: return 65255;
                case 1593: return 65227;
                case 1605: return 65251;
                case 1603: return 65243;
                case 1670: return 64380;
                case 1579: return 65179;
                case 1580: return 65183;
                case 1581: return 65187;
                case 1582: return 65191;
                case 1587: return 65203;
                case 1588: return 65207;
                case 1589: return 65211;
                case 1590: return 65215;
                case 1591: return 65219;
                case 1592: return 65223;
                case 1602: return 65239;
                case 1604: return 65247;
                case 1607: return 65259;
                case 1709: return 64469;
                case 1609: return 64488;
                case 1726: return 64428;
                case 1711: return 64404;
            }
            return s;
        }

        static int ArabicMedialFormConventer(int s){
            switch (s){
                case 1610: return 65268;
                case 1578: return 65176;
                case 1604: return 65248;
                case 1594: return 65232;
                case 1609: return 64489;
                case 1576: return 65170;
                case 1601: return 65236;
                case 1606: return 65256;
                case 1593: return 65228;
                case 1605: return 65252;
                case 1603: return 65244;
                case 1574: return 65164;
                case 1670: return 64381;
                case 1575: return 65166;
                case 1579: return 65180;
                case 1580: return 65184;
                case 1581: return 65188;
                case 1582: return 65192;
                case 1583: return 65193;
                case 1584: return 65196;
                case 1585: return 65198;
                case 1586: return 65200;
                case 1587: return 65204;
                case 1588: return 65208;
                case 1589: return 65212;
                case 1590: return 65216;
                case 1591: return 65220;
                case 1592: return 65224;
                case 1602: return 65240;
                case 1607: return 65260;
                case 1608: return 65262;
                case 1571: return 65156;
                case 1573: return 65160;
                case 1572: return 65158;
                case 1570: return 65154;
                case 1735: return 64472;
                case 1749: return 65258;//?
                case 1709: return 64470;
                case 1736: return 64476;
                case 1726: return 64429;
                case 1711: return 64405;
            }
            return s;
        }

        static bool HaveInitialForm(char ch){ 
            switch (ch){ 
                case 'ا': return false; 
                case 'ب': return true; 
                case 'ت': return true; 
                case 'ث': return true; 
                case 'ج': return true; 
                case 'ح': return true; 
                case 'خ': return true; 
                case 'د': return false; 
                case 'ذ': return false; 
                case 'ر': return false; 
                case 'ز': return false; 
                case 'س': return true; 
                case 'ش': return true; 
                case 'ص': return true; 
                case 'ض': return true; 
                case 'ط': return true; 
                case 'ظ': return true; 
                case 'ع': return true; 
                case 'غ': return true; 
                case 'ف': return true; 
                case 'ق': return true; 
                case 'ك': return true; 
                case 'ل': return true; 
                case 'م': return true; 
                case 'ه': return true; 
                case 'ي': return true; 
                case 'و': return false;
                case 'ۇ': return false; 
                case 'ۈ': return false; 
                case 'أ': return false; 
                case 'إ': return false; 
                case 'ؤ': return false; 
                case 'ئ': return true; 
                case 'آ': return false; 
                case 'ن': return true; 
                case 'ﻹ': return false; 
                case 'ﻻ': return false; 
                case 'چ': return true; 
                case 'ڭ': return true; 
                case 'ک': return true;   
                case 'ڑ': return false;  
                case 'ی': return true;
                case 'گ': return true;
                case 'ې': return true;  
                case 'ۆ': return false;
                //?
                case 'ى': return true; 
                case 'ة': return true; 
                case 'ە': return false; 
                case 'ہ': return true;
                case 'ھ': return true;
                    case 'ں': return false; 
                    case 'ے': return false; 
            }
#if DEBUG
            throw new Exception("Missing arabic letter "+ch);
            #else
            return true;
#endif
        }

        static bool HaveFinalForm(char ch){ 
            switch (ch){ 
                case 'ا': return true; 
                case 'ب': return true; 
                case 'ت': return true; 
                case 'ث': return true; 
                case 'ج': return true; 
                case 'ح': return true; 
                case 'خ': return true; 
                case 'د': return true; 
                case 'ذ': return true; 
                case 'ر': return true; 
                case 'ز': return true; 
                case 'س': return true; 
                case 'ش': return true; 
                case 'ص': return true; 
                case 'ض': return true; 
                case 'ط': return true; 
                case 'ظ': return true; 
                case 'ع': return true; 
                case 'غ': return true; 
                case 'ف': return true; 
                case 'ق': return true; 
                case 'ك': return true; 
                case 'ل': return true; 
                case 'م': return true; 
                case 'ه': return true; 
                case 'ي': return true; 
                case 'و': return true;  
                case 'ۇ': return true; 
                case 'أ': return true; 
                case 'إ': return true; 
                case 'ؤ': return true; 
                case 'ئ': return true; 
                case 'آ': return true; 
                case 'ن': return true;  
                case 'ڭ': return true; 
                case 'ﻹ': return false; 
                case 'ﻻ': return false;  
                case 'چ': return true; 
                case 'ھ' : return true;
                case 'ۈ' : return true;
                case 'ک' : return true;  
                case 'ڑ' : return true; 
                case 'ہ' : return true;
                case 'ی' : return true;
                case 'ے' : return true;
                case 'ۆ' : return true;
                case 'گ' : return true;
                case 'ې' : return true;

                //?
                case 'ى': return true; 
                case 'ة': return true;  
                case 'ە': return true; 
            }

            #if DEBUG
            throw new Exception("Missing arabic letter "+ch);
            #else
            return true;
            #endif
        }
               
        static bool IsArabicLetter(char ch){ 
            switch (ch){ 
                case 'ا': return true; 
                case 'ب': return true; 
                case 'ت': return true; 
                case 'ث': return true; 
                case 'ج': return true; 
                case 'ح': return true; 
                case 'خ': return true; 
                case 'د': return true; 
                case 'ذ': return true; 
                case 'ر': return true; 
                case 'ز': return true; 
                case 'س': return true; 
                case 'ش': return true; 
                case 'ص': return true; 
                case 'ض': return true; 
                case 'ط': return true; 
                case 'ظ': return true; 
                case 'ع': return true; 
                case 'غ': return true; 
                case 'ف': return true; 
                case 'ق': return true; 
                case 'ك': return true; 
                case 'ل': return true; 
                case 'م': return true; 
                case 'ه': return true; 
                case 'ي': return true; 
                case 'و': return true; 
                case 'أ': return true; 
                case 'إ': return true; 
                case 'ؤ': return true; 
                case 'ئ': return true; 
                case 'آ': return true; 
                case 'ى': return true; 
                case 'ة': return true; 
                case 'ﻻ': return true; 
                case 'ن': return true; 
                case 'ﻹ': return true; 
                case 'ڭ': return true; 
                case 'ە': return true; 
                case 'ۇ': return true; 
                case 'چ': return true; 
                case 'ۈ': return true;  
                case 'ھ': return true;    
                case 'ک': return true;  
                case 'ی': return true;   
                case 'ہ': return true; 
                case 'ڑ': return true;  
                case 'ے': return true; 
                case 'ې': return true;
                case 'ۆ': return true;
                case 'ں': return true;
                case 'گ': return true;
              //  case 'ﻢ': return true; 
              //  case 'ء': return true; 
            }
         //   Debug.WriteLine(ch+" is not arabic");
            return false;
        }

        public static char[] BuildArabicText(string txt) {

            // Detect if is arabic
            bool isArabic=false;
            foreach (char c in txt) { 
                if (IsArabicLetter(c)){ 
                    isArabic=true;
                    break;
                }
            }
            if (!isArabic) return txt.ToCharArray();

            // ltr
            txt=txt.Replace("\u200E","");

            //combined
            txt=txt.Replace(((char)1617).ToString()+((char)1614).ToString(),"\uFC62");
            txt=txt.Replace(((char)1575).ToString()+((char)1604).ToString(),"\uFEFB");
            txt=txt.Replace(((char)1573).ToString()+((char)1604).ToString(),"\uFEF9"); //ل ا  ء <- ل إ

        //    Debug.WriteLine(txt);
            char[] chs=txt.ToCharArray();
            char[] _out=new char[chs.Length];
            
            if (chs.Length<2) return txt.ToCharArray();

            // start
            int ch = 0;
            if (IsArabicLetter(chs[1])) {
                if (HaveInitialForm(chs[1])) _out[0]=(char)ArabicFinalFormConventer((int)chs[0]);
                else _out[0]=chs[0];
            } else _out[0]=chs[0];

            for (ch = 1; ch<chs.Length-1; ch++) {
                //bool start=IsArabicLetter(chs[ch+1]); // if starts with arabic letter
                //bool end=IsArabicLetter(chs[ch-1]); // if ends with arabic letter
                                      
                //bool e=end ? HaveFinalForm(chs[ch-1]) : false;
                //bool s=start ? HaveInitialForm(chs[ch+1]) : false; 

                                  
                bool e=IsArabicLetter(chs[ch-1])&&HaveFinalForm(chs[ch-1]);
                bool s=IsArabicLetter(chs[ch+1])&&HaveInitialForm(chs[ch+1]); 

                //if (e) e=;
                //if (s) s=;
               // char old=chs[ch];
                if (s && e) _out[ch]=(char)ArabicMedialFormConventer((int)chs[ch]);
                else if (s && !e) _out[ch]=(char)ArabicFinalFormConventer((int)chs[ch]);
                else if (!s && e) _out[ch]=(char)ArabicInitialFormConventer((int)chs[ch]);
                else _out[ch]=chs[ch];

            //    Debug.WriteLine(old+" -> "+chs[ch]+" s:"+s+" e:"+e);
            } 
            ch=chs.Length-1;
            // end
            if (IsArabicLetter(chs[chs.Length-1-1])) {
                if (HaveFinalForm(chs[chs.Length-1-1])) _out[ch]=(char)ArabicInitialFormConventer((int)chs[ch]);
                else _out[ch]=chs[ch];
            }else _out[ch]=chs[ch];

            return /*new string(*/_out/*)*/;
        }
    }

    public class TextWithMeasure{
        public DrawingChar[] Chars;
        readonly Texture2D Bitmap;
        public int X, NewLines;
        readonly int len;


        public TextWithMeasure(string txt, int x, int y/*, BitmapFont f*/){
            if (txt==null){
                Chars=new DrawingChar[0];
                return;
            }
            Glyph[] Glyphs=BitmapFont.bitmapFont18.Glyphs;
            Bitmap=BitmapFont.bitmapFont18.Bitmap;
           // font=f;
            List<DrawingChar> tmpChs=new List<DrawingChar>();
         //   txt=
            char[] chs=Text.BuildArabicText(txt);//txt.ToCharArray();
            int posx=x;
            Glyph g;
            NewLines=1;
#if DEBUG
            bool add=false;
#endif
            int glyphsLen=Glyphs.Length;
            for (int i = 0; i<chs.Length; i++) {
                for (int gg = 0; gg<glyphsLen; gg++) {
                    if (chs[i]==(char)(g = /*font.*/Glyphs[gg]).Code) {
                        if (g.visible) {
                            tmpChs.Add(
                                new DrawingChar{
                                    Pos=new Vector2(posx+g.X,y+g.Y),
                                    Rectangle=g.DrawRectangle,
                                }
                            );
                            posx+=g.DrawRectangle.Width+g.X+g.W;
                        } else {
                            if (chs[i]=='\n')NewLines++;
                            //tmpChs.Add(
                            //    new DrawingChar{
                            //        //Pos=new Vector2(posx+g.X,y+g.Y),
                            //        //Rectangle=g.DrawRectangle,
                            //    }
                            //);
                            posx+=g.W;
                        }

#if DEBUG
                        add=true;
#endif
                        break;
                    }
                }

#if DEBUG
                // Unknown char
                if (add)continue;
                if (chs[i]=='\r')continue;
                for (int gg = 0; gg</*font.*/Glyphs.Length; gg++) {
                    if ('�'==(char)(g = /*font.*/Glyphs[gg]).Code) {
                        tmpChs.Add(
                            new DrawingChar {
                                Pos=new Vector2(posx+g.X, y+g.Y),
                                Rectangle=g.DrawRectangle,
                            }
                        );
                        posx+=g.DrawRectangle.Width+g.X+g.W;
                        break;
                    }
                }
#endif
            }

            Chars=tmpChs.ToArray();
            X=posx-x;
            len=Chars.Length;
        }

        public void Draw(SpriteBatch sb) {
            for (int i=0; i<len; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(/*font.*/Bitmap, ch.Pos, ch.Rectangle, Color.Black);
            }
        }

        public void Draw(SpriteBatch sb, Color c) {
            for (int i=0; i<len; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(/*font.*/Bitmap,ch.Pos,ch.Rectangle,c);
            }
        }

        public void Draw(SpriteBatch sb, Color c, int start, int end) {
            for (int i=start; i<len && i<end; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(/*font.*/Bitmap,ch.Pos,ch.Rectangle,c);
            }
        }

        public void DrawBold(SpriteBatch sb, Color c) {
            for (int i=0; i<len; i++){
                DrawingChar ch=Chars[i];
                sb.Draw(/*font.*/Bitmap,ch.Pos,ch.Rectangle,c);
                ch.Pos.X--;
                sb.Draw(/*font.*/Bitmap,ch.Pos,ch.Rectangle,c);
                ch.Pos.X++;
            }
        }

        public void DrawItalic(SpriteBatch sb, Color c) {
            for (int i=0; i<len; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(/*font.*/Bitmap,ch.Pos, ch.Rectangle,c,0.2f,new Vector2(),1,SpriteEffects.None,1);
            }
        }
    }

    class DynamicText{
        readonly Glyph[] Chars;
        //readonly BitmapFont font;
        public int X=0, Y=0;
        readonly Texture2D Bitmap;
        public DynamicText(string txt, int x, int y/*, BitmapFont f*/){
            if (txt==null) {
                Chars=new Glyph[0];
                return;
            }
            Glyph[] Glyphs=BitmapFont.bitmapFont34.Glyphs;
            Bitmap=BitmapFont.bitmapFont34.Bitmap;
           // font=f;
        //   txt=
            List<Glyph> tmpChs=new List<Glyph>();
            char[] chs=Text.BuildArabicText(txt);//txt.ToCharArray();
            int posx=x;

            Glyph g;
            int glyphsLen=Glyphs.Length;

            for (int i = 0; i<chs.Length; i++) {

                #if DEBUG
                bool add=false;
                #endif

                for (int gg = 0; gg<glyphsLen; gg++) {
                    if (chs[i]==(char)/*font.*/Glyphs[gg].Code){
                        g = /*font.*/Glyphs[gg];

                        if (g.visible) {
                            tmpChs.Add(
                                new Glyph{
                                    X=g.X,
                                    Y=g.Y,
                                    W=g.W,
                                    H=g.H,
                                    DrawRectangle=g.DrawRectangle,
                                    visible=true
                                }
                            );

                            if (Y<g.DrawRectangle.Height+g.Y)Y=g.DrawRectangle.Height+g.Y;
                            posx+=g.DrawRectangle.Width+g.X+g.W;

                        } else {
                             tmpChs.Add(
                                new Glyph{
                                   // X=g.X,
                                   // Y=g.Y,
                                    W=g.W,
                                   // H=g.H,
                                  //  DrawRectangle=g.DrawRectangle,
                                    visible=false
                                }
                            );
                            posx+=g.W;

                        }

                        #if DEBUG
                        add=true;
                        #endif
                        break;
                    }
                }

                #if DEBUG
                // Unknown char
                if (add) continue;
                for (int gg = 0; gg<glyphsLen; gg++) {
                    if ('�'==(char)(g = /*font.*/Glyphs[gg]).Code) {
                        tmpChs.Add(
                            new Glyph {
                                X=g.X,
                                Y=g.Y,
                                W=g.W,
                                H=g.H,
                                DrawRectangle=g.DrawRectangle,
                                visible=g.visible
                            }
                        );
                        posx+=g.DrawRectangle.Width+g.X+g.W;
                        add=true;
                        break;
                    }
                }

                if (!add) throw new Exception("Something is wrong with CustomTextRender at pos "+i);
                #endif
            }
            Chars=tmpChs.ToArray();
            X=posx-x;
        }

        public void Draw(SpriteBatch sb, int x, int y, Color c, float angle) {
            int posX=-X/2;

            float
                sin=(float)Math.Sin(angle),
                cos=(float)Math.Cos(angle);

            int half=Y/2;

            for (int i=0; i<Chars.Length; i++){
                Glyph ch=Chars[i];
                if (ch.visible) {

                    sb.Draw(
                        /*font.*/Bitmap,
                        new Vector2(posX*cos+x, y+posX*sin),
                        ch.DrawRectangle,
                        c,
                        angle,
                        new Vector2(0,-ch.Y+half),
                        1,
                        SpriteEffects.None,
                        1f);

                    posX+=ch.DrawRectangle.Width+ch.X+ch.W;
                } else posX+=ch.W;
            }
        }
    }

    public class BitmapFont {
        public static BitmapFont
            bitmapFont18,
            bitmapFont34;
        readonly int w3dots;
        public Glyph[] Glyphs;
        public Texture2D Bitmap;
        public int Size;

        public BitmapFont(int size, byte[] bytes) {
            Size=size;
            List<Glyph> tmpGlyphs=new List<Glyph>();

            for (int i=0; i<bytes.Length; ) {
                Glyph g = new Glyph {
                    Code=(int)(uint)(bytes[i+3] | bytes[i+2]<<8 | bytes[i+1]<<16 | bytes[i]<<24),
                };
                if (g.visible=bytes[i+4]==1){

                    g.DrawRectangle=new Rectangle(
                        (ushort)(bytes[i+5+1] | bytes[i+4+1]<<8),
                        (ushort)(bytes[i+7+1] | bytes[i+6+1]<<8),
                        bytes[i+8+1]/*-1*//*+1*/,//
                        bytes[i+9+1]/*-1*//*+1*///
                    );

                    g.X=bytes[i+10+1]-128;
                    g.Y=bytes[i+11+1]-128;
                    g.W=bytes[i+12+1];//?-1
                    g.H=bytes[i+13+1];
                    i+=15;
                } else {
                    g.W=bytes[i+5];
                    g.H=bytes[i+6];

                    i+=7;
                }

                tmpGlyphs.Add(g);
            }

            Glyphs=tmpGlyphs.ToArray();
            //bytes=null;
            if (Environment.GetCommandLineArgs().Length>2){ 
                if (Environment.GetCommandLineArgs()[1]=="/Message"){ 
                       using (FileStream fileStream = new FileStream(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"/RabcrData/Default/Fonts/Font latin 18.png", FileMode.Open)){
       //    Bitmap=Rabcr.Game.Content.Load<Texture2D>("Default/Fonts/font"+size);
                /*BitmapFont.bitmapFont16.*/Bitmap=Texture2D.FromStream(Rabcr.Game.GraphicsDevice, fileStream);

           // fileStream.Dispose();
           }  //
                    }
            }else{
            using (FileStream fileStream = new FileStream(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"/RabcrData/Default/Fonts/Font "+Lang.Languages[Setting.CurrentLanguage].FontFile+" "+size+".png", FileMode.Open)){
       //    Bitmap=Rabcr.Game.Content.Load<Texture2D>("Default/Fonts/font"+size);
                /*BitmapFont.bitmapFont16.*/Bitmap=Texture2D.FromStream(Rabcr.Game.GraphicsDevice, fileStream);

           // fileStream.Dispose();
           } } // GC.Collect();
            //GC.WaitForPendingFinalizers();
        //    string[] lines = strs/*((string)Properties.Resources.ResourceManager.GetObject("FontInfo"+size+".txt"))*/./*; .FontInfo.*/Split('*');
        ////    string[] lines=Properties.Resources.ResourceManager.GetString("FontInfo"+size+".txt")./*; .FontInfo.*/Split('*');
        //    foreach (string line in lines){
        //        if (line=="")break;
        //        string[] info=line.Split('|');
        //        if (info.Length==3) {
        //            Glyphs.Add(
        //                new Glyph{
        //                    Code=int.Parse(info[0]),
        //                  //  DrawRectangle=new Rectangle(int.Parse(info[1]),int.Parse(info[2]),int.Parse(info[3]),int.Parse(info[4])),
        //                   // X=int.Parse(info[5]),
        //                    //Y=int.Parse(info[6]),
        //                    W=int.Parse(info[1]),
        //                    H=int.Parse(info[2]),
        //                    visible=false,
        //                }
        //            );
        //        } else {
        //            Glyphs.Add(
        //                new Glyph{
        //                    Code=int.Parse(info[0]),
        //                    DrawRectangle=new Rectangle(int.Parse(info[1]),int.Parse(info[2]),int.Parse(info[3]),int.Parse(info[4])),
        //                    X=int.Parse(info[5]),
        //                    Y=int.Parse(info[6]),
        //                    W=int.Parse(info[7]),
        //                    H=int.Parse(info[8]),
        //                    visible=true,
        //                }
        //            );
        //        }
        //    }
        w3dots=MeasureTextSingleLineX("...");
        }

#region Measure Width and Height
        //public DInt MeasureText(string txt){
        //    if (txt==null)// {
        //        //X=0;
        //        //Y=0;
        //        return new DInt{ X=0, Y=0 };
        //    //}

        //    char[] chs=txt.ToCharArray();

        //    if (txt.Contains('\n')){
        //        int maxX=0;
        //        int X=0;

        //        for (int i = 0; i<chs.Length; i++) {
        //            if (chs[i]=='\n') {
        //                if (maxX<X)maxX=X;
        //                X=0;
        //            } else {
        //                foreach (Glyph g in Glyphs) {
        //                    if (chs[i]==(char)g.Code) {
        //                       // if (g.visible) {
        //                            X+=g.DrawRectangle.Width+g.X;
        //                        //} else {
        //                        //    X+=/*g.DrawRectangle.Width+*/g.W;
        //                        //}
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        return new DInt{X=maxX, Y=MeasureTextSingleLineY*(txt.Count(c=>c=='\n')+1) }/*(maxX,MeasureTextSingleLineY*(txt.Count(c=>c=='\n')+1))*/;
        //    } else {
        //        int X= 0, Y = 0;
        //        for (int i = 0; i<chs.Length; i++) {
        //                foreach (Glyph g in Glyphs) {
        //                    if (chs[i]==(char)g.Code) {
        //                       // if (g.visible) {
        //                            X+=g.DrawRectangle.Width+g.X;
        //                            if (Y<g.DrawRectangle.Height+g.H+g.Y) Y=g.DrawRectangle.Height+g.H+g.Y;
        //                        //}
        //                        break;
        //                    }
        //                }
        //        }
        //        return new DInt{X=X, Y=Y }/*(X, Y/*Size/)*/;
        //    }
        //}

        public DInt MeasureTextSingleLineWithPresision(string txt) {
            if (txt==null) return new DInt{X=0, Y=0 }/*(0,0)*/;

            char[] chs=txt.ToCharArray();

            int X=0, Y = 0;
            for (int i = 0; i<chs.Length; i++) {
                for (int ii = 0; ii<Glyphs.Length; ii++) {
                    if (chs[i]==(char)Glyphs[ii].Code) {
                        Glyph g = Glyphs[ii];
                        X+=g.DrawRectangle.Width+g.X;
                        if (Y<g.DrawRectangle.Height+g.H+g.Y) Y=g.DrawRectangle.Height+g.H+g.Y;
                        break;
                    }
                }
            }
            return new DInt{X=X, Y=Y }/*(X, Y)*/;
        }

        public DInt MeasureTextSingleLine(string txt) {
            if (txt==null) return new DInt{X=0, Y=0 }/*(0,0)*/;

            char[] chs=txt.ToCharArray();

            int X=0;
            for (int i = 0; i<chs.Length; i++) {
                for (int ii = 0; ii<Glyphs.Length; ii++) {
                    if (chs[i]==(char)Glyphs[ii].Code) {
                        Glyph g = Glyphs[ii];
                        X+=g.DrawRectangle.Width+g.X;
                        break;
                    }
                }
            }
            return new DInt{X=X, Y=MeasureTextSingleLineY }/*(X, MeasureTextSingleLineY)*/;
        }
#endregion

#region Measure Width
        public int MeasureTextSingleLineX(string txt){
            if (txt==null) return 0;
            int X=0;

            char[] chs=txt.ToCharArray();

            for (int i = 0; i<chs.Length; i++) {
                for (int ii = 0; ii<Glyphs.Length; ii++) {
                    if (chs[i]==(char)Glyphs[ii].Code) {
                        Glyph g = Glyphs[ii];
                        if (g.visible) {
                            X+=g.DrawRectangle.Width+g.X+g.W;
                        } else X+=g.W;
                        break;
                    }
                }
            }
            return X;
        }
#endregion

#region Measure Height
        public int MeasureTextSingleLineYWithPresision(string txt) {
            if (txt==null) return 0;
            char[] chs=txt.ToCharArray();
            int Y = 0;

            for (int i = 0; i<chs.Length; i++) {
                for (int ii = 0; ii<Glyphs.Length; ii++) {
                    if (chs[i]==(char)Glyphs[ii].Code) {
                        Glyph g = Glyphs[ii];
                        if (Y<g.DrawRectangle.Height+g.H+g.Y) Y=g.DrawRectangle.Height+g.H+g.Y;
                        break;
                    }
                }
            }
            return Y;
        }

        public const int MeasureTextSingleLineY=30;

        public const int MeasureTextY=20;

        public int MeasureTextMultiLineY(string txt)=> MeasureTextSingleLineY*(txt.Count(c=>c=='\n')+1);
#endregion

#region Draw text
        public void DrawText(SpriteBatch sb, string str, int x, int y) {
            if (str==null) return;

            char[] chs=str.ToCharArray();
            int posx=x;

            Glyph g;
            for (int ch = 0; ch<chs.Length; ch++) {
                for (int gg = 0; gg<Glyphs.Length; gg++) {
                    if (chs[ch]==(char)(g = Glyphs[gg]).Code) {
                        if (g.visible) {
                            sb.Draw(Bitmap,new Vector2(posx,y+g.Y), g.DrawRectangle,Color.White);
                            posx+=g.DrawRectangle.Width+g.X+g.W;
                        } else {
                            posx+=g.W;
                        }
                        break;
                    }
                }
            }
        }

        public void DrawText(SpriteBatch sb, string str, int x, int y, Color color) {
            if (str==null) return;

            char[] chs=str.ToCharArray();
            int posx=x;

            Glyph g;
            for (int ch = 0; ch<chs.Length; ch++) {
                for (int gg = 0; gg<Glyphs.Length; gg++) {
                    if (chs[ch]==(char)(g = Glyphs[gg]).Code) {
                        if (g.visible) {
                            sb.Draw(Bitmap,new Vector2(posx,y+g.Y), g.DrawRectangle,color);
                            posx+=g.DrawRectangle.Width+g.X+g.W;
                        } else// {
                            posx+=g.W;
                        //}
                        break;
                    }
                }
            }
        }

        //public void DrawTextMultiline(SpriteBatch sb, string str, int x, int y) {
        //    if (str==null) return;

        //    char[] chs=str.ToCharArray();
        //    int posx=x, posy=0;

        //    Glyph g;
        //    for (int ch = 0; ch<chs.Length; ch++) {
        //        if (chs[ch]=='\n'){
        //            posx=0;
        //            posy+=30;
        //        }else{
        //        for (int gg = 0; gg<Glyphs.Length; gg++) {
        //            if (chs[ch]==(char)(g = Glyphs[gg]).Code) {
        //                if (g.visible) {
        //                    sb.Draw(Bitmap,new Vector2(posx,y+g.Y+posy), g.DrawRectangle,Color.White);
        //                    posx+=g.DrawRectangle.Width+g.X+g.W;
        //                } else// {
        //                    posx+=g.W;
        //                //}
        //                break;
        //            }
        //        }  }
        //    }
        //}

        public void DrawTextItalic(SpriteBatch sb, string str, int x, int y, Color color) {
            if (str==null) return;

            char[] chs=str.ToCharArray();
            int posx=x;

            Glyph g;
            for (int ch = 0; ch<chs.Length; ch++) {
                for (int gg = 0; gg<Glyphs.Length; gg++) {
                    if (chs[ch]==(char)(g = Glyphs[gg]).Code) {
                        if (g.visible) {
                            sb.Draw(Bitmap,new Vector2(posx,y/*+g.Y*/), g.DrawRectangle,color,0.2f,new Vector2(-g.X, -g.Y),1,SpriteEffects.None,1);
                            posx+=g.DrawRectangle.Width+g.X+g.W;
                        } else {
                            posx+=g.W;
                        }
                        break;
                    }
                }
            }
        }
#endregion

        public string MaxSizeOfString(string s, int w) {
          //  System.Diagnostics.Debug.WriteLine("Shorting: "+s);
            int ww=w-w3dots;
            int x=MeasureTextSingleLineX(s);
            if (x>ww) {
                //if (s.StartsWith("Ma")){
                //    Console.WriteLine(w);
                //    }

                // string need to be smaller
             //   int w2=0;
                char[] chs=s.ToCharArray();
                int ch/*=-1*/;
                Glyph g;


                for (ch = 0; ch<chs.Length; ch++) {
                    if (ww<=/*w2*/0)break;
                    for (int gg = 0; gg<Glyphs.Length; gg++) {
                        if (chs[ch]==(char)(g = Glyphs[gg]).Code) {
                            if (g.visible) {
                                ww-=g.DrawRectangle.Width+g.X+g.W;
                            } else {
                                ww-=g.W;
                            }
                            break;
                        }
                    }
                }
            //    if (ch==-1)return s;
                if (ch==0)return"";
             //   if (ch!=chs.Length) {
                    // String need to be smller
                   //if (x<MeasureTextSingleLineX(s.Substring(0,ch-1)+"...")){
                   // Console.WriteLine("!");
                   // }
                   //if (s.Contains('\u8206')) System.Diagnostics.Debug.WriteLine("..."+s.Substring(0,ch-1));
                 //else

                //if (isArabic(s)) {
                //    System.Diagnostics.Debug.WriteLine("..."+s.Substring(0,ch-1));
                //    return "..."+s.Substring(0,ch-1);
                //}else{
                  //  System.Diagnostics.Debug.WriteLine(s.Substring(0,ch-1)+"...");
                    return s.Substring(0,ch-1)+"...";
             //   }

                //}
              //  else return s;
            }

            return s;

        }

        public bool IsUjgur(string s){
            if (Lang.IsUjgur){

                return true;
            }else{
                foreach (char ch in s) {
                    switch (ch) {
                        case 'ى': return true;
                        case 'ل': return true;
                    }
                }
            }
            return false;
        }

        public bool IsArabic(string s){
            if (Lang.IsArabic){

                return true;
            }else{
                foreach (char ch in s) {
                    switch (ch) {
                        case 'ى': return true;
                        case 'ل': return true;
                    }
                }
            }
            return false;
        }
    }

    public class Glyph {
        public Rectangle DrawRectangle;
        public int Code;
        public int X, Y, W, H;
        public bool visible;
    }

    public class DrawingChar {
        public Rectangle Rectangle;
        public Vector2 Pos;
    }
}