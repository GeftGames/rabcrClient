using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace rabcrClient {
    public class Text {

        #region Varibles
        DrawingChar[] Chars;
        readonly BitmapFont font;
        int X, Y, Length;
        #endregion

        public Text(string txt, int x, int y, BitmapFont f) {
            if (txt==null) {
                Chars=new DrawingChar[0];
                return;
            }

            font=f;
            X=x;
            Y=y;
            if (IsDevanagari(txt)){
                BuildTextDevanagari(txt);
                return;
            }
            if (IsArabic(txt)){
                BuildTextArabic(txt);
                return;
            }

            BuildTextNormal(txt);
        }

        #region Devanagari
        static bool IsDevanagari(string input) {
            foreach (char i in input) {
                if (IsDevanagariChar(i)) return true;
            }
            return false;
        }

        static bool IsDevanagariChar(char input) {
            return input switch {
                'क' => true,
                'ख' => true,
                'ग' => true,
                'घ' => true,
                'ङ' => true,
                'च' => true,
                'छ' => true,
                'ज' => true,
                'झ' => true,
                'ञ' => true,
                'ट' => true,
                'ठ' => true,
                'ड' => true,
                'ढ' => true,
                'ण' => true,
                'त' => true,
                'थ' => true,
                'द' => true,
                'ध' => true,
                'न' => true,
                'प' => true,
                'फ' => true,
                'ब' => true,
                'भ' => true,
                'म' => true,
                'य' => true,
                'र' => true,
                'ल' => true,
                'व' => true,
                'श' => true,
                'ष' => true,
                'स' => true,
                'ह' => true,
                _ => false,
            };
        }

        void BuildTextDevanagari(string txt){
            List<DrawingChar> tmpChs=new();
            char[] chs=new RenderEnngineDevanagari(txt).Output.ToCharArray();
            int posx=X;

            Glyph g;
            for (int ch = 0; ch<chs.Length; ch++) {

                #if DEBUG
                bool add=false;
                #endif

                for (int gg = 0; gg<font.Glyphs.Length; gg++) {
                    if (chs[ch] == font.Glyphs[gg].Char) {
                        g=font.Glyphs[gg];
                   
                        if (g.visible) {
                            tmpChs.Add(
                                new DrawingChar{
                                    Pos=new Vector2(posx+g.X,Y+g.Y),
                                    Rectangle=g.DrawRectangle,
                                }
                            );
                            posx+=g.DrawRectangle.Width+g.X+g.W-3;

                            // Devanagari special character
                            if (chs[ch]=='媪') {posx-=14-3/*+3+3*/; }  //ि
                            // if (chs[ch]=='媪') {posx-=14-3/*+3+3*/; }  //ि
                        } else {
                            posx+=g.W;
                        }
                        #if DEBUG
                        add=true;
                        #endif
                        break;
                    }
                }

                // Unknown char
                #if DEBUG
                if (!add){
                    for (int gg = 0; gg<font.Glyphs.Length; gg++) {
                        if ('�' == font.Glyphs[gg].Char) {
                            g = font.Glyphs[gg];

                            tmpChs.Add(
                                new DrawingChar {
                                    Pos=new Vector2(posx+g.X, Y+g.Y),
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
            }
            Debug.WriteLine("");
            Chars=tmpChs.ToArray();

            Length=Chars.Length;
        }
        #endregion

        #region Arabic
        static bool IsArabic(string input) {
            foreach (char i in input) {
                if (IsArabicChar(i)) return true;
            }
            return false;
        }

        static bool IsArabicChar(char ch){
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

        void BuildTextArabic(string txt){
            List<DrawingChar> tmpChs=new();
            char[] chs=BuildArabicText(txt);
            int posx=X;

            Glyph g;
            for (int ch = 0; ch<chs.Length; ch++) {
                #if DEBUG
                bool add=false;
                #endif

                for (int gg = 0; gg<font.Glyphs.Length; gg++) {
                    if (chs[ch]==font.Glyphs[gg].Char) {
                        g = font.Glyphs[gg];
                        if (g.visible) {
                            tmpChs.Add(
                                new DrawingChar{
                                    Pos=new Vector2(posx+g.X,Y+g.Y),
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

                // Unknown char
                #if DEBUG
                if (!add){
                    for (int gg = 0; gg<font.Glyphs.Length; gg++) {
                        if ('�'==font.Glyphs[gg].Char) {
                            g = font.Glyphs[gg];
                            tmpChs.Add(
                                new DrawingChar {
                                    Pos=new Vector2(posx+g.X, Y+g.Y),
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
            }
            //Debug.WriteLine(" ");
            Chars=tmpChs.ToArray();
            //X=x;
            //Y=y;

            Length=Chars.Length;
        }

        static int ArabicFinalFormConventer(int s){
            return s switch {
                1609 => 65264,
                1577 => 65172,
                1570 => 65154,
                1610 => 65266,
                1578 => 65174,
                1594 => 65230,
                1576 => 65168,
                1604 => 65246,
                1583 => 65193,
                1601 => 65234,
                1606 => 65254,
                1593 => 65226,
                1605 => 65250,
                1585 => 65198,
                1603 => 65242,
                1749 => 65258,//?
                1574 => 65162,
                1735 => 64472,
                1670 => 64379,
                1575 => 65166,
                1579 => 65178,
                1580 => 65182,
                1581 => 65186,
                1582 => 65190,
                1584 => 65196,
                1586 => 65200,
                1587 => 65202,
                1588 => 65206,
                1589 => 65210,
                1590 => 65214,
                1591 => 65218,
                1592 => 65222,
                1602 => 65238,
                1607 => 65258,
                1608 => 65262,
                1571 => 65156,
                1573 => 65160,
                1572 => 65158,
                1709 => 64468,
                1736 => 64476,
                1726 => 64427,
                1711 => 64403,
                _ => s,
            };
        }

        static int ArabicInitialFormConventer(int s){
            return s switch {
                1578 => 65175,
                1594 => 65231,
                1574 => 65163,
                1610 => 65267,
                1576 => 65169,
                1601 => 65235,
                1606 => 65255,
                1593 => 65227,
                1605 => 65251,
                1603 => 65243,
                1670 => 64380,
                1579 => 65179,
                1580 => 65183,
                1581 => 65187,
                1582 => 65191,
                1587 => 65203,
                1588 => 65207,
                1589 => 65211,
                1590 => 65215,
                1591 => 65219,
                1592 => 65223,
                1602 => 65239,
                1604 => 65247,
                1607 => 65259,
                1709 => 64469,
                1609 => 64488,
                1726 => 64428,
                1711 => 64404,
                _ => s,
            };
        }

        static int ArabicMedialFormConventer(int s){
            return s switch {
                1610 => 65268,
                1578 => 65176,
                1604 => 65248,
                1594 => 65232,
                1609 => 64489,
                1576 => 65170,
                1601 => 65236,
                1606 => 65256,
                1593 => 65228,
                1605 => 65252,
                1603 => 65244,
                1574 => 65164,
                1670 => 64381,
                1575 => 65166,
                1579 => 65180,
                1580 => 65184,
                1581 => 65188,
                1582 => 65192,
                1583 => 65193,
                1584 => 65196,
                1585 => 65198,
                1586 => 65200,
                1587 => 65204,
                1588 => 65208,
                1589 => 65212,
                1590 => 65216,
                1591 => 65220,
                1592 => 65224,
                1602 => 65240,
                1607 => 65260,
                1608 => 65262,
                1571 => 65156,
                1573 => 65160,
                1572 => 65158,
                1570 => 65154,
                1735 => 64472,
                1749 => 65258,//?
                1709 => 64470,
                1736 => 64476,
                1726 => 64429,
                1711 => 64405,
                _ => s,
            };
        }

        static bool HaveInitialForm(char ch){
            return ch switch {
                'ا' => false,
                'ب' => true,
                'ت' => true,
                'ث' => true,
                'ج' => true,
                'ح' => true,
                'خ' => true,
                'د' => false,
                'ذ' => false,
                'ر' => false,
                'ز' => false,
                'س' => true,
                'ش' => true,
                'ص' => true,
                'ض' => true,
                'ط' => true,
                'ظ' => true,
                'ع' => true,
                'غ' => true,
                'ف' => true,
                'ق' => true,
                'ك' => true,
                'ل' => true,
                'م' => true,
                'ه' => true,
                'ي' => true,
                'و' => false,
                'ۇ' => false,
                'ۈ' => false,
                'أ' => false,
                'إ' => false,
                'ؤ' => false,
                'ئ' => true,
                'آ' => false,
                'ن' => true,
                'ﻹ' => false,
                'ﻻ' => false,
                'چ' => true,
                'ڭ' => true,
                'ک' => true,
                'ڑ' => false,
                'ی' => true,
                'گ' => true,
                'ې' => true,
                'ۆ' => false,
                //?
                'ى' => true,
                'ة' => true,
                'ە' => false,
                'ہ' => true,
                'ھ' => true,
                'ں' => false,
                'ے' => false,
                _ => throw new Exception("Missing arabic letter " + ch),
            };

#if DEBUG
#else
            return true;
#endif
        }

        static bool HaveFinalForm(char ch){
            return ch switch {
                'ا' => true,
                'ب' => true,
                'ت' => true,
                'ث' => true,
                'ج' => true,
                'ح' => true,
                'خ' => true,
                'د' => true,
                'ذ' => true,
                'ر' => true,
                'ز' => true,
                'س' => true,
                'ش' => true,
                'ص' => true,
                'ض' => true,
                'ط' => true,
                'ظ' => true,
                'ع' => true,
                'غ' => true,
                'ف' => true,
                'ق' => true,
                'ك' => true,
                'ل' => true,
                'م' => true,
                'ه' => true,
                'ي' => true,
                'و' => true,
                'ۇ' => true,
                'أ' => true,
                'إ' => true,
                'ؤ' => true,
                'ئ' => true,
                'آ' => true,
                'ن' => true,
                'ڭ' => true,
                'ﻹ' => false,
                'ﻻ' => false,
                'چ' => true,
                'ھ' => true,
                'ۈ' => true,
                'ک' => true,
                'ڑ' => true,
                'ہ' => true,
                'ی' => true,
                'ے' => true,
                'ۆ' => true,
                'گ' => true,
                'ې' => true,
                //?
                'ى' => true,
                'ة' => true,
                'ە' => true,
                _ => throw new Exception("Missing arabic letter " + ch),
            };

#if DEBUG
#else
            return true;
#endif
        }

        public static char[] BuildArabicText(string txt) {

            // Detect if is arabic
            bool isArabic=false;
            foreach (char c in txt) {
                if (IsArabicChar(c)){
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
            int ch /*= 0*/;
            if (IsArabicChar(chs[1])) {
                if (HaveInitialForm(chs[1])) _out[0]=(char)ArabicFinalFormConventer((int)chs[0]);
                else _out[0]=chs[0];
            } else _out[0]=chs[0];

            for (ch = 1; ch<chs.Length-1; ch++) {
                //bool start=IsArabicLetter(chs[ch+1]); // if starts with arabic letter
                //bool end=IsArabicLetter(chs[ch-1]); // if ends with arabic letter

                //bool e=end ? HaveFinalForm(chs[ch-1]) : false;
                //bool s=start ? HaveInitialForm(chs[ch+1]) : false;


                bool e=IsArabicChar(chs[ch-1])&&HaveFinalForm(chs[ch-1]);
                bool s=IsArabicChar(chs[ch+1])&&HaveInitialForm(chs[ch+1]);

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
            if (IsArabicChar(chs[chs.Length-1-1])) {
                if (HaveFinalForm(chs[chs.Length-1-1])) _out[ch]=(char)ArabicInitialFormConventer((int)chs[ch]);
                else _out[ch]=chs[ch];
            }else _out[ch]=chs[ch];

            return /*new string(*/_out/*)*/;
        }
        #endregion

        #region Normal
        void BuildTextNormal(string txt){
            List<DrawingChar> tmpChs=new();
            char[] chs=txt.ToArray();
            int posx=X, 
                posY=Y;

            Glyph g;
            for (int ch = 0; ch<chs.Length; ch++) {
                #if DEBUG
                bool add=false;
                #endif

                for (int gg = 0; gg<font.Glyphs.Length; gg++) {
                    if (chs[ch]==font.Glyphs[gg].Char) {
                        g = font.Glyphs[gg];
                        if (g.visible) {
                            tmpChs.Add(
                                new DrawingChar{
                                    Pos=new Vector2(posx+g.X,posY+g.Y),
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

                if (chs[ch]=='\n') {
                    posx=X;
                    posY+=30;
                    #if DEBUG
                    add=true;
                    #endif
                    continue;
                }

                // Unknown char
                #if DEBUG
                if (!add){
                    for (int gg = 0; gg<font.Glyphs.Length; gg++) {
                        if ('�' == font.Glyphs[gg].Char) {
                            g = font.Glyphs[gg];
                            tmpChs.Add(
                                new DrawingChar {
                                    Pos=new Vector2(posx+g.X, posY+g.Y),
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
            }
            Chars=tmpChs.ToArray();
            Length=Chars.Length;
        }
        #endregion

        #region Draw
        public void Draw(SpriteBatch sb) {
            for (int i=0; i<Length; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(font.Bitmap, ch.Pos, ch.Rectangle, Color.Black);
            }
        }

        public void DrawBold(SpriteBatch sb) {
            for (int i=0; i<Length; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(font.Bitmap, ch.Pos, ch.Rectangle, Color.Black);
                sb.Draw(font.Bitmap, new Vector2(ch.Pos.X+1, ch.Pos.Y), ch.Rectangle, Color.Black);
            }
        }

        public void Draw(SpriteBatch sb, Color c) {
            for (int i=0; i<Length; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(font.Bitmap, ch.Pos, ch.Rectangle, c);
            }
        }
        #endregion

        #region Measure
        public float MeasureX() {
            if (Length>1) {
                DrawingChar dch=Chars[Length-1];
                return dch.Pos.X-Chars[0].Pos.X+dch.Rectangle.Width;
            }
            if (/*Chars.*/Length==1) return Chars[0].Rectangle.Width;
            return 0;
        }
        #endregion

        #region Change Pos
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
        #endregion

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
    }

    public class TextWithMeasure {
        public DrawingChar[] Chars;
        readonly Texture2D Bitmap;
        public int MeasureX, NewLines;
        readonly int len;
        int X, Y;

        public const int MeasureY =30;

        public TextWithMeasure(string txt, int x, int y) {
            if (txt==null) {
                Chars=new DrawingChar[0];
                return;
            }
            Glyph[] Glyphs=BitmapFont.bitmapFont18.Glyphs;
            Bitmap=BitmapFont.bitmapFont18.Bitmap;
            X=y;
            Y=y;
            List<DrawingChar> tmpChs=new();

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
                    if (chs[i] == Glyphs[gg].Char) {
                        g = Glyphs[gg];
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
                for (int gg = 0; gg<Glyphs.Length; gg++) {
                    if ('�' == Glyphs[gg].Char) {
                        g = Glyphs[gg];
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
            MeasureX=posx-x;
            len=Chars.Length;
        }

        public void Draw(SpriteBatch sb) {
            for (int i=0; i<len; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(Bitmap, ch.Pos, ch.Rectangle, Color.Black);
            }
        }

        public void Draw(SpriteBatch sb, Color c) {
            for (int i=0; i<len; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(Bitmap, ch.Pos, ch.Rectangle, c);
            }
        }

        public void Draw(SpriteBatch sb, Color c, int start, int end) {
            for (int i=start; i<len && i<end; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(Bitmap,ch.Pos,ch.Rectangle,c);
            }
        }

        public void DrawBold(SpriteBatch sb, Color c) {
            for (int i=0; i<len; i++){
                DrawingChar ch=Chars[i];
                sb.Draw(Bitmap,ch.Pos,ch.Rectangle,c);
                ch.Pos.X--;
                sb.Draw(Bitmap,ch.Pos,ch.Rectangle,c);
                ch.Pos.X++;
            }
        }

        public void DrawItalic(SpriteBatch sb, Color c) {
            for (int i=0; i<len; i++) {
                DrawingChar ch=Chars[i];
                sb.Draw(/*font.*/Bitmap,ch.Pos, ch.Rectangle, c, 0.2f, Vector2.Zero, 1, SpriteEffects.None, 1);
            }
        }

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
            List<Glyph> tmpChs=new();
            char[] chs=Text.BuildArabicText(txt);//txt.ToCharArray();
            int posx=x;

            Glyph g;
            int glyphsLen=Glyphs.Length;

            for (int i = 0; i<chs.Length; i++) {

                #if DEBUG
                bool add=false;
                #endif

                for (int gg = 0; gg<glyphsLen; gg++) {
                    if (chs[i]==Glyphs[gg].Char){
                        g = Glyphs[gg];

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
                    if ('�' == Glyphs[gg].Char) {
                        g = Glyphs[gg];
                        tmpChs.Add(
                            new Glyph {
                                X=g.X,
                                Y=g.Y,
                                W=g.W,
                                H=g.H,
                                DrawRectangle=g.DrawRectangle,
                                visible=g.visible,
                                
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
            List<Glyph> tmpGlyphs=new();

            for (int i=0; i<bytes.Length; ) {
                int code=(int)(uint)(bytes[i+3] | bytes[i+2]<<8 | bytes[i+1]<<16 | bytes[i]<<24);
                Glyph g = new() {
                 //   Code=,
                };
                g.Char=(char)code;
                if (g.visible=bytes[i+4]==1) {

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
       //     if (Environment.GetCommandLineArgs().Length>2){
       //         if (Environment.GetCommandLineArgs()[1]=="/Message"){
       //                using (FileStream fileStream = new FileStream(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"/RabcrData/Default/Fonts/Font latin 18.png", FileMode.Open)){
       ////    Bitmap=Rabcr.Game.Content.Load<Texture2D>("Default/Fonts/font"+size);
       //         /*BitmapFont.bitmapFont16.*/Bitmap=Texture2D.FromStream(Rabcr.Game.GraphicsDevice, fileStream);

       //    // fileStream.Dispose();
       //    }  //
       //             }
       //     }else{
            using (FileStream fileStream = new FileStream(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"/RabcrData/Default/Fonts/Font "+Lang.Languages[Setting.CurrentLanguage].FontFile+" "+size+".png", FileMode.Open)){
       //    Bitmap=Rabcr.Game.Content.Load<Texture2D>("Default/Fonts/font"+size);
                /*BitmapFont.bitmapFont16.*/Bitmap=Texture2D.FromStream(Rabcr.Game.GraphicsDevice, fileStream);

           // fileStream.Dispose();
           }// } // GC.Collect();
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
            Glyph g;
            int X=0, Y = 0;
            for (int i = 0; i<chs.Length; i++) {
                for (int ii = 0; ii<Glyphs.Length; ii++) {
                    if (chs[i]==Glyphs[ii].Char) {
                        g = Glyphs[ii];
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
            Glyph g;
            int X=0;
            for (int i = 0; i<chs.Length; i++) {
                for (int ii = 0; ii<Glyphs.Length; ii++) {
                    if (chs[i]==Glyphs[ii].Char) {
                        g = Glyphs[ii];
                        X+=g.DrawRectangle.Width+g.X;
                        break;
                    }
                }
            }
            return new DInt{X=X, Y=MeasureTextSingleLineY }/*(X, MeasureTextSingleLineY)*/;
        }
#endregion

#region Measure Width
        //public void Test() { 
        //    Stopwatch sw1=new Stopwatch();
        //    Stopwatch sw2=new Stopwatch();
        //    int len1=0;
        //    int len2=0;
        //    Thread.Sleep(1000);
        //       sw2.Start();
        //    for (int j=0; j<1600; j++) { 
        //        for (int i=0; i<1600; i++) { 
        //            if (!string.IsNullOrEmpty(Lang.Texts[i])) len2+=MeasureTextSingleLineX2(Lang.Texts[i]);
        //        }
        //    }
        //    sw2.Stop();  
            
        //    sw1.Start();
        //    for (int j=0; j<1600; j++) { 
        //        for (int i=0; i<1600; i++) { 
        //            if (!string.IsNullOrEmpty(Lang.Texts[i])) len1+=MeasureTextSingleLineX(Lang.Texts[i]);
        //        }
        //    }
        //    sw1.Stop();

        //    sw2.Start();
        //    for (int j=0; j<1600; j++) { 
        //        for (int i=0; i<1600; i++) { 
        //            if (!string.IsNullOrEmpty(Lang.Texts[i])) len2+=MeasureTextSingleLineX2(Lang.Texts[i]);
        //        }
        //    }
        //    sw2.Stop();

        //    sw1.Start();
        //    for (int j=0; j<1600; j++) { 
        //        for (int i=0; i<1600; i++) { 
        //            if (!string.IsNullOrEmpty(Lang.Texts[i])) len1+=MeasureTextSingleLineX(Lang.Texts[i]);
        //        }
        //    }
        //    sw1.Stop();
     

       


        //    Debug.WriteLine("MeasureTextSingleLineX "+sw1.Elapsed.TotalMilliseconds+" "+len1);
        //    Debug.WriteLine("MeasureTextSingleLineX2 "+sw2.Elapsed.TotalMilliseconds+" "+len2);
        //}
     
        public int MeasureTextSingleLineX(string txt) {
            if (txt==null) return 0;
            int X=0;

            char[] chs=txt.ToCharArray();
            Glyph g;

            for (int i = 0; i<chs.Length; i++) {
                for (int ii = 0; ii<Glyphs.Length; ii++) {
                    if (chs[i]==Glyphs[ii].Char) {
                        g = Glyphs[ii];
                        if (g.visible) X+=g.DrawRectangle.Width+g.X+g.W;
                        else X+=g.W;
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
            Glyph g;

            for (int i = 0; i<chs.Length; i++) {
                for (int ii = 0; ii<Glyphs.Length; ii++) {
                    if (chs[i] == Glyphs[ii].Char) {
                        g = Glyphs[ii];
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
                    if (chs[ch]==Glyphs[gg].Char) {
                        g = Glyphs[gg];
                        if (g.visible) {
                            sb.Draw(Bitmap, new Vector2(posx, y+g.Y), g.DrawRectangle, Color.White);
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
                    if (chs[ch]==Glyphs[gg].Char) {
                        g = Glyphs[gg];
                        if (g.visible) {
                            sb.Draw(Bitmap,new Vector2(posx,y+g.Y), g.DrawRectangle,color);
                            posx+=g.DrawRectangle.Width+g.X+g.W;
                        } else posx+=g.W;
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
                    if (chs[ch] == Glyphs[gg].Char) {
                        g = Glyphs[gg];

                        if (g.visible) {
                            sb.Draw(Bitmap, new Vector2(posx, y), g.DrawRectangle, color, 0.2f, new Vector2(-g.X, -g.Y), 1f, SpriteEffects.None, 1f);
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
            int ww=w-w3dots;
            int x=MeasureTextSingleLineX(s);
            if (x>ww) {
                char[] chs=s.ToCharArray();
                int ch;
                Glyph g;


                for (ch = 0; ch<chs.Length; ch++) {
                    if (ww<=0)break;
                    for (int gg = 0; gg<Glyphs.Length; gg++) {
                        if (chs[ch]==Glyphs[gg].Char) {
                            g = Glyphs[gg];

                            if (g.visible) {
                                ww-=g.DrawRectangle.Width+g.X+g.W;
                            } else {
                                ww-=g.W;
                            }
                            break;
                        }
                    }
                }

                if (ch==0) return"";
           
                return s.Substring(0, ch-1)+"...";
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
            if (Lang.IsArabic) {
                return true;
            } else {
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
        // public int Code;
        public char Char;
        public int X, Y, W, H;
        public bool visible;
    }

    public class DrawingChar {
        public Rectangle Rectangle;
        public Vector2 Pos;
    }

    class RenderEnngineDevanagari {
        readonly char[] Consonants ={'क', 'ख', 'ग', 'घ', 'ङ', 'च', 'छ', 'ज', 'झ', 'ञ', 'ट', 'ठ', 'ड', 'ढ', 'ण', 'त', 'थ', 'द', 'ध', 'न', 'प', 'फ', 'ब', 'भ', 'म', 'य', 'र', 'ल', 'व', 'श', 'ष', 'स', 'ह' };
        readonly char[] DevandariPreCh ={ 'ँ','ऻ','ः','ं', 'े','ा','ि','ी','्','ो','़','ए','इ','ॉ','आ','ू','ू','ै','ई', };


        public char[][] tableMoveBack = new char[][]{
            new char[]{'य', (char)2369},
        };
        public string Output;

        readonly (char[],char)[] Replacements=new (char[],char)[]{
            // Nukta...
            (new char[]{ 'क', '़'}, 'क़'),
            (new char[]{ 'फ', '़'}, 'फ़'),
            (new char[]{ 'ज', '़'}, 'ज़'),
            (new char[]{ 'ख', '़'}, 'ख़'),
            (new char[]{ 'ग', '़'}, 'ग़'),
            (new char[]{ 'ड', '़'}, 'ड़'),
            (new char[]{ 'ढ', '़'}, 'ढ़'),
            (new char[]{ 'य', '़'}, 'य़'),
            (new char[]{ 'ळ', '़'}, 'ऴ'),
            (new char[]{ 'न', '़'}, 'ऩ'),
            (new char[]{ 'र', '़'}, 'ऱ'),

            (new char[]{ 'ा', 'े'}, 'ो'),
            (new char[]{ 'ा', 'ै'}, 'ौ'),

            (new char[]{ 'अ', 'ा'}, 'आ'),
            (new char[]{ 'अ', 'ो'}, 'ओ'),
            (new char[]{ 'अ', 'ौ'}, 'औ'),
            (new char[]{ 'ए', 'े'}, 'ऐ'),
        };

        bool IdDevanagariChar(char ch) {
            foreach (char i in Consonants) { if (ch==i) return true; }
            foreach (char i in DevandariPreCh) { if (ch==i) return true; }
            return false;
        }

        public RenderEnngineDevanagari(string input) {
            // Split text by Devanagari and other font text (combined text->noncombined parts)
            List<(bool,string)> DevanagariWords=new List<(bool, string)>();
            bool WasLastDevanagari=false;
            int lastpos=-1;

            for (int i=0; i<input.Length; i++) {
                char ch=input[i];
                bool nowDev=IdDevanagariChar(ch);
                if (lastpos==-1) {
                    WasLastDevanagari=nowDev;
                    lastpos=0;
                }

                if (nowDev == WasLastDevanagari){
                //   lastpos++;
                } else {
                    DevanagariWords.Add((WasLastDevanagari,input.Substring(lastpos,i-lastpos)));
                    WasLastDevanagari=nowDev;
                    lastpos=i;
                }
            }
            DevanagariWords.Add((WasLastDevanagari,input.Substring(lastpos)));

            Output="";
            // Parse devanagari words into syllables
            foreach ((bool, string) h in DevanagariWords) {
                if (h.Item1) {
                    string[] Syllables=ToSyllables(h.Item2);

                    foreach (string s in Syllables) Output+=/*"s"+*/s/*+"e"*/;
                } else {
                    Output+=/*"S"+*/h.Item2/*+"E"*/;
                }
            }

            //string LastSyllable="";
            //bool Devanagari;

            string[] ToSyllables(string txt){
                List<string> Syllables=null;
                string LastSyllable="";

                for (int i = 0; i<txt.Length; i++) {
                    char ch = txt[i];

                    foreach (char con in Consonants) {
                        if (ch==con) {
                            if (Syllables==null) {
                                Syllables=new List<string>();
                            } else {
                                Syllables.Add(TryReplaceSyllable(LastSyllable));
                                LastSyllable="";
                            }
                            break;
                        }
                    }
                    LastSyllable+=ch;
                }

                Syllables.Add(TryReplaceSyllable(LastSyllable));
                return Syllables.ToArray();
            }

            string TryReplaceSyllable(string s) {
                if (s.Length>1){
                    foreach ((char[], char) r in Replacements) {
                        bool make=true;
                        foreach (char x in r.Item1) {
                            if (s.Contains(x)){
                            } else {
                                make=false;
                                break;
                            }
                        }
                        if (make) {
                            string g=s.Replace(r.Item1[0],r.Item2);
                            g=g.Replace(r.Item1[1].ToString(),"");
                            return r.Item2.ToString();
                        }
                    }
                    if (s.Contains('ा')){ //f
                       return s.Replace('ा'.ToString(),"发");
                    }
                    if (s.Contains('ो')){ //T´
                        return s.Replace('ो'.ToString(),"飞");
                    }
                    if (s.Contains('ी')){ // o + obraceny f
                      return s.Replace('ी'.ToString(),"汉");
                    }
                    if (s.Contains('ु')){ // o + obraceny f
                      return s.Replace('ु'.ToString(),"习");
                    }
                    if (s.Contains('ू')){ // o + obraceny f
                      return s.Replace('ू'.ToString(),"韦");
                    }
                    if (s.Contains('्')){ // o + obraceny f
                      return s.Replace('्'.ToString(),"专");
                    }
                    if (s.Contains('े')){ // o + obraceny f
                      return s.Replace('े'.ToString(),"车");
                    }
                    if (s.Contains('ं')){ // tečka nad
                      return s.Replace('ं'.ToString(),"见");
                    }
                    if (s.Contains('ै')){ // dvojte carka nad
                      return s.Replace('ै'.ToString(),"齿");
                    }
                     if (s.Contains('ृ')){ //m ृ
                      return s.Replace('ृ'.ToString(),"义");
                    }
                    if (s.Contains('ॄ')){ //m ॄ
                      return s.Replace('ॄ'.ToString(),"宾");
                    }
                    if (s.Contains('ॢ')){ //m ॢ
                      return s.Replace('ॢ'.ToString(),"继");
                    }
                    if (s.Contains('ॣ')){ // o + obraceny f
                      return s.Replace('ॣ'.ToString(),"历");
                    }
                    if (s.Contains('ॅ')){ //m ॅ
                      return s.Replace('ॅ'.ToString(),"妇");
                    }
                    if (s.Contains('ॉ')){ // o + obraceny f
                      return s.Replace('ॉ'.ToString(),"焕");
                    }

                    if (s.Contains('ौ')){ //m ौ o + obraceny f
                      return s.Replace('ौ'.ToString(),"头");
                    }
                    // f+o
                    if (s.Contains('ि')){
                        string o=s.Replace('ि'.ToString(),"");
                        return '媪'+o;
                    }
                  //   'ि'
                }

                return s;
            }
        }




            //class Replace{
            //    public char[] From;
            //    public char To;
            //}
        }
    }