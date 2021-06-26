using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace rabcrClient {
    class SettingKey:SettingItem{

        #region Varibles
        public int ButtonX, Y;
        public string KeyName;
        public Keys Key;
        private readonly Text TText;
        private Text text;
        int alpha=255, needAlpha=255;
        Vector2 Position;
        Color color=Color.White;
        bool oldMs, selected=false;

        readonly Keys[] KeysArray;
        readonly string Text;
        readonly Texture2D texture;
        int w2, h2;
        #endregion

        public delegate void ClickEventHandler();
        public event ClickEventHandler Click;

        public SettingKey(Texture2D tex, string t, Keys key) {
            Text=t;
            Key=key;
            Value=60;

            texture=tex;
            KeyName=SetKeyName();

            Keys[] DeniedKeys=new Keys[] {
                Keys.LeftWindows,
                Keys.RightWindows,
                Keys.CapsLock,
                Keys.Scroll,
                Keys.NumLock,
                Keys.LaunchApplication2,
                Keys.LaunchApplication1,
                Keys.Zoom,
                Keys.VolumeUp,
                Keys.VolumeMute,
                Keys.VolumeDown,
                Keys.Sleep,
                Keys.Print,
                Keys.BrowserSearch,
                Keys.Kanji,
                Keys.Kana
            };
            List<Keys> keys=new List<Keys>();
            foreach (Keys k in Enum.GetValues(typeof(Keys))) keys.Add(k);
            foreach (Keys k in DeniedKeys) keys.Remove(k);

            KeysArray=keys.ToArray();

            TText = new Text(Text, 0, 0, BitmapFont.bitmapFont18);

        }

        public override void Update() {
           // bool _ret=false;
            if (selected) {
                if (Menu.mouseDown) {
                    if (!oldMs) {
                        selected=false;
                        ChangePos(ButtonX,Y);
                    }
                }

                Keys oldK=Key;
                Key=SetNew(Menu.newKeyboardState);

                if (oldK!=Key) {
                    KeyName=SetKeyName();
                    selected=false;
                    ChangePos(ButtonX,Y);
                   //_ret=true;
                    if (Rabcr.ActiveWindow){
                        if (Rabcr.Game.IsActive){
                            Click.Invoke();
                        }
                    }
                }
                needAlpha=50;
            } else {
                if (In()) {
                    if (Menu.mouseDown) {
                        if (!oldMs) {
                            if (Rabcr.Game.IsActive){
                                selected=true;
                                ChangePos(ButtonX,Y);
                            }
                        }
                        needAlpha=200;
                    } else {
                        needAlpha=220;
                    }
                } else {
                    needAlpha=255;
                }
            }

            if (needAlpha!=alpha) {
                if (alpha>needAlpha) alpha-=5;
                else alpha+=5;

                color=new Color(alpha,alpha,alpha);
            }

            oldMs=Menu.mouseDown;
        }

        //void ChangeSelected() {
        //    string buttonText=selected ?  "???" : KeyName;
        //    int m=BitmapFont.bitmapFont18.MeasureTextSingleLineX(buttonText);
        //}

        public override void ChangePos(int x, int y) {
            Position.X=ButtonX=x;
            Position.Y=Y=y;

            string buttonText=selected ?  "???" : KeyName;
            int m=BitmapFont.bitmapFont18.MeasureTextSingleLineX(buttonText);
            text=new Text(buttonText, ButtonX+(texture.Width-m)/2,Y+texture.Height/2-BitmapFont.bitmapFont18.MeasureTextSingleLineYWithPresision(buttonText)/2, BitmapFont.bitmapFont18);

        //    TText = new Text(Text, X, Y,BitmapFont.bitmapFont18);

            w2=ButtonX + texture.Width;
            h2=(int)Position.Y + texture.Height;

            TText.ChangePosition(X, Y);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, Position, color);
            text.Draw(spriteBatch);
            TText.Draw(spriteBatch);
        }

        bool In() {
            if (Menu.mousePosX < ButtonX) return false;
            if (Menu.mousePosYCorrection < Position.Y) return false;
            if (Menu.mousePosX > w2/*ButtonX + texture.Width*/) return false;
            if (Menu.mousePosYCorrection > h2/*Position.Y + texture.Height*/) return false;

            return true;
        }

        Keys SetNew(KeyboardState ks) {
            foreach (Keys k in KeysArray) {
                if (ks.IsKeyDown(k)) return k;
            }
            return Key;
        }

        public void ResetKeyName() {
            KeyName=SetKeyName();
        }

        string SetKeyName() {
            switch (Key){
                case Keys.Multiply: return "*";
                case Keys.Divide: return "/";

                case Keys.OemPlus: return "+";//ΩPlus
                case Keys.OemQuestion: return "?";//ΩQuestion
                case Keys.OemPipe: return "ΩLine";
                case Keys.OemQuotes: return "\"";//ΩQuotes
                case Keys.OemSemicolon: return ";";//ΩSemicolon
                case Keys.OemPeriod: return ".";//ΩPeriod
                case Keys.OemMinus: return "-";//ΩMinus
                case Keys.OemComma: return ",";//ΩComma
                case Keys.OemCloseBrackets: return ")";
                case Keys.OemOpenBrackets: return "(";//ΩBracketsO
                case Keys.PageUp: return Lang.Texts[262];
                case Keys.PageDown: return Lang.Texts[263];
                case Keys.OemTilde: return "~";
                case Keys.Decimal: return Lang.Texts[271];//"Del"

                case Keys.Escape: return Lang.Texts[269];
                case Keys.Tab: return Lang.Texts[270];
                case Keys.Insert: return Lang.Texts[268];
                case Keys.Delete: return Lang.Texts[267];
                case Keys.End: return Lang.Texts[266];
                case Keys.Home: return Lang.Texts[265];
                case Keys.Enter: return Lang.Texts[264];

                case Keys.Up: return Lang.Texts[260];
                case Keys.Down: return Lang.Texts[261];
                case Keys.Left: return Lang.Texts[259];
                case Keys.Right: return Lang.Texts[258];
                case Keys.Apps: return Lang.Texts[257];
                case Keys.Back: return Lang.Texts[256];
                case Keys.LeftShift: return Lang.Texts[254];
                case Keys.RightShift: return Lang.Texts[255];
                case Keys.Space: return Lang.Texts[253];
                case Keys.LeftAlt: return Lang.Texts[252];
                case Keys.LeftControl: return Lang.Texts[251];
                case Keys.RightControl: return Lang.Texts[250];

                case Keys.NumPad0: return "0";
                case Keys.NumPad1: return "1";
                case Keys.NumPad2: return "2";
                case Keys.NumPad3: return "3";
                case Keys.NumPad4: return "4";
                case Keys.NumPad5: return "5";
                case Keys.NumPad6: return "6";
                case Keys.NumPad7: return "7";
                case Keys.NumPad8: return "8";
                case Keys.NumPad9: return "9";
                default: return Key.ToString();
            }
        }
    }
}