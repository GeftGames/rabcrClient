using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rabcrClient {
    class Informations :MenuScreen{

        #region Varibles
        Scrollbar scrollbar;
        RenderTarget2D worldsTarget;
        Effect effectBlur, effectColorize;

        int infoTabPage = 0;
        ButtonCenter
            buttonInfoMain,
            buttonInfoHow,
            buttonInfoKeyBoard;
        Button buttonMenu;

        GeDo geDo;
        Text header;
        string strMain, strKeys;
        private float smoothMouse;
        readonly string strHowTo =Lang.Texts[296];
        #endregion

        public override void Init() {
            effectColorize=Content.Load<Effect>("Default/Effects/Colorize");
            header=new Text(Lang.Texts[5],10, 10,BitmapFont.bitmapFont34);

            buttonMenu=new Button(Textures.ButtonLongLeft, Lang.Texts[1]);

            buttonMenu.Click+=ClickMenu;
            buttonInfoMain=new ButtonCenter(Textures.ButtonLeft) {
                center=true,
                Text=Lang.Texts[2]
            };
            buttonInfoKeyBoard=new ButtonCenter(Textures.ButtonCenter) {
                center=true,
                Text=Lang.Texts[3]
            };
            buttonInfoHow=new ButtonCenter(Textures.ButtonRight) {
                center=true,
                Text=Lang.Texts[4]
            };
               
            effectBlur=Effects.BluredTopDownBounds;

            scrollbar=new Scrollbar(GetDataTexture(@"Buttons\Scrollbar\Top"), GetDataTexture(@"Buttons\Scrollbar\Center"), GetDataTexture(@"Buttons\Scrollbar\Bottom")) {
                PositionY=76+40
            };

            strMain="<DarkGreen>"+Lang.Texts[199]+"</DarkGreen>: <Green>"+Release.Authors+"</Green>" + Environment.NewLine;
     
            strMain+="<DarkGreen>"+Lang.Texts[201]+"</DarkGreen>: <Green>"+Release.VersionString+"</Green>"+ (Release.VersionSpecialName!="" ? " (<Green>"+Release.VersionSpecialName+"</Green>)": "") +Environment.NewLine;

            strMain+=
                "<DarkGreen>"+Lang.Texts[200]+"</DarkGreen>: <Green>"+Release.Company+"</Green>" + Environment.NewLine +
                "<DarkGreen>"+Lang.Texts[209]+"</DarkGreen>: <Green>"+Lang.Texts[315]+"</Green>" +Environment.NewLine +
                "<DarkGreen>"+Lang.Texts[205]+"</DarkGreen>: <Green>"+Release.Date+"</Green>" + Environment.NewLine +
                "<DarkGreen>"+Lang.Texts[121]+"</DarkGreen>: <Green>"+Lang.Languages[Setting.CurrentLanguage].NativeName+"</Green>" + Environment.NewLine +
                "<DarkGreen>"+Lang.Texts[202]+"</DarkGreen>: <Link|url=https://geftgames.ga/Licence2020.txt>"+Lang.Texts[208]+" (GeftGames © 2020)</Link>" + Environment.NewLine+

                "<DarkGreen>"+Lang.Texts[203]+"</DarkGreen>: <Link|url="+Release.WebFullGame+">"+Release.WebShortGame+"</Link>" + Environment.NewLine +
                "<DarkGreen>"+Lang.Texts[204]+"</DarkGreen>: <Link|url=mailto:"+Release.Email+">"+Release.Email+"</Link>" + Environment.NewLine +

                "<DarkGreen>"+Lang.Texts[206]+"</DarkGreen>: <Green>"+Lang.Texts[210]+" 2019</Green> (<Green>C#</Green>)" + Environment.NewLine +
                "      (<Green>"+Lang.Texts[207]+" 3.8.0.1641</Green>)" +Environment.NewLine + Environment.NewLine +

                "<DarkGreen>"+Lang.Texts[360]+"</DarkGreen>"+ Environment.NewLine +
                "     <Link|url=https://fonts.google.com/specimen/M+PLUS+Rounded+1c|info=Licence: https://scripts.sil.org/cms/scripts/page.php?site_id=nrsi&id=OFL>M PLUS Rounded 1c</Link> (<Green>"+Lang.Texts[363]+"</Green>)" + Environment.NewLine+
                "     <Link|url=https://fonts.google.com/specimen/Sunflower|info=Licence: https://scripts.sil.org/cms/scripts/page.php?site_id=nrsi&id=OFL>Sunflower</Link> (<Green>"+Lang.Texts[361]+"</Green>)" + Environment.NewLine +
                "     <Link|url=https://fonts.google.com/specimen/Tajawal?subset=arabic|info=Licence: Open-Source>Tajawal</Link> (<Green>"+Lang.Texts[365]+"</Green>)" + Environment.NewLine +
                "     <Link|url=https://www.freechinesefont.com/traditional-han-wang-yen-light-rounded-font-download|info=Licence: Free for personal and commercial-use.>HanWangYenLight</Link> (<Green>"+Lang.Texts[362]+"</Green>)"+ Environment.NewLine +
                "     <Link|url=https://github.com/Omnibus-Type/Jaldi|info=Licence: https://scripts.sil.org/cms/scripts/page.php?site_id=nrsi&id=OFL>Jaldi</Link> (<Green>"+Lang.Texts[1585]+"</Green>)";


            geDo=new GeDo(24, 10-(int)(scrollbar.scale*(BitmapFont.bitmapFont18.MeasureTextMultiLineY(strMain)+10-(Global.WindowHeight-75-40-65)))) {
                mouseAdd=-76-40
            };

            geDo.changeHeight=ChangeHeight;
            geDo.BuildString(strMain);
            strKeys=
                "<Bold>"+Lang.Texts[227]+"</Bold>" + Environment.NewLine +
                "<DarkBlue>"+KeyName(Setting.KeyLeft)+"</DarkBlue> a <DarkBlue>"+KeyName(Setting.KeyRight)+"</DarkBlue>: <Blue>"+Lang.Texts[230]+"</Blue>" + Environment.NewLine +
                "<DarkBlue>"+KeyName(Setting.KeyJump)+"</DarkBlue>: <Blue>"+Lang.Texts[104]+"</Blue>" + Environment.NewLine +
                "<DarkBlue>"+KeyName(Setting.KeyDropItem)+"</DarkBlue>: <Blue>"+Lang.Texts[112]+"</Blue>" + Environment.NewLine +
                "<DarkBlue>"+KeyName(Setting.KeyInventory)+"</DarkBlue>: <Blue>"+Lang.Texts[108]+"</Blue>" + Environment.NewLine +
                "<DarkBlue>"+KeyName(Setting.KeyMessage)+"</DarkBlue>: <Blue>"+Lang.Texts[111]+"</Blue>" + Environment.NewLine +
                "<DarkBlue>"+KeyName(Setting.KeyExit)+"</DarkBlue>: <Blue>"+Lang.Texts[115]+"</Blue>" + Environment.NewLine +
                Environment.NewLine +
                "<Bold>"+Lang.Texts[220]+"</Bold>" + Environment.NewLine +
                "<DarkRed>"+Lang.Texts[221]+"</DarkRed>:  <Red>"+Lang.Texts[228]+"</Red>" + Environment.NewLine +
                "<DarkRed>"+Lang.Texts[222]+"</DarkRed>:  <Red>"+Lang.Texts[229]+"</Red>" + Environment.NewLine +
				"<DarkRed>F2</DarkRed>: <Red>"+Lang.Texts[225]+"</Red>" + Environment.NewLine +
				"<DarkRed>F3</DarkRed>: <Red>"+Lang.Texts[224]+"</Red>" + Environment.NewLine +
				"<DarkRed>F12</DarkRed>: <Red>"+Lang.Texts[223]+"</Red>";

            scrollbar.MoveScollBar+=Move;
            Resize();
        }

        void ClickMenu(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MainMenu());

        void Move(object sender, EventArgs e) {
            int m=geDo.GetHeight;

            float more=(m+10)-(Global.WindowHeight-75-40-65);
            geDo.SetPos(24, (int)(10-scrollbar.scale*more));
        }

        public void ChangeHeight(object o, EventArgs e){
            scrollbar.maxheight=geDo.GetHeight;
            scrollbar.scale=0;
        }

        public override void Update(GameTime gameTime) {
            if (Menu.newKeyboardState.IsKeyDown(Keys.Up)) scrollbar.Scroll(-2);
            if (Menu.newKeyboardState.IsKeyDown(Keys.Down)) scrollbar.Scroll(2);

            if (Menu.newKeyboardState.IsKeyDown(Keys.PageUp)) scrollbar.Scroll(-5);
            if (Menu.newKeyboardState.IsKeyDown(Keys.PageDown)) scrollbar.Scroll(5);

            if (Menu.newMouseState.ScrollWheelValue!=Menu.oldMouseState.ScrollWheelValue) {
                smoothMouse+=((Menu.oldMouseState.ScrollWheelValue-Menu.newMouseState.ScrollWheelValue)/1f);
            }
            if (smoothMouse!=0){
                scrollbar.Scroll(smoothMouse/1.25f);
                smoothMouse/=1.4f;
                if (smoothMouse>0){
                    if (smoothMouse<0.049f) smoothMouse=0;
                } else {
                    if (smoothMouse>-0.049f) smoothMouse=0;
                }
            }

            buttonMenu.Update();

            if (buttonInfoMain.Click) {
                infoTabPage = 0;
                scrollbar.scale=0;
                geDo.BuildString(strMain);
                ChangeHeight(null,null);
            }
            if (buttonInfoKeyBoard.Click) {
                infoTabPage = 1;

                scrollbar.scale=0;

                geDo.BuildString(strKeys);
                ChangeHeight(null,null);
            }
            if (buttonInfoHow.Click) {
                infoTabPage = 2;

                scrollbar.scale=0;

                geDo.width=Global.WindowWidth-80-24;
                geDo.BuildString(strHowTo);
                ChangeHeight(null,null);
            }
          
            base.Update(gameTime);
        }

        public override void PreDraw() {
            Graphics.SetRenderTarget(worldsTarget);
            Graphics.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,null,null,null,effectColorize);

            #region Information Text
            switch (infoTabPage) {
                case 0:
                    geDo.DrawGedo(1f, spriteBatch);
                    break;

                case 1:
                    geDo.DrawGedo(1f, spriteBatch);
                    break;

                case 2:
                    geDo.DrawGedo(1f, spriteBatch);
                    break;
            }
            #endregion

            spriteBatch.End();
            Graphics.SetRenderTarget(null);
        }

        public override void Draw(GameTime gameTime, float a) {
            effectBlur.Parameters["alpha"].SetValue(a);
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,effectBlur);
            effectBlur.Techniques[0].Passes[0].Apply();
            spriteBatch.Draw(worldsTarget, new Vector2(0, 76+40), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight-75-65-2-40), Color.White);
            spriteBatch.End();


            spriteBatch.Begin();

            // Button back
			buttonMenu.ButtonDraw(spriteBatch, a);
			header.Draw(spriteBatch,Color.Black*a);
         
            #region Category Buttons
            buttonInfoMain.ButtonDraw(spriteBatch, a);
            buttonInfoKeyBoard.ButtonDraw(spriteBatch, a);
            buttonInfoHow.ButtonDraw(spriteBatch, a);
          
            #endregion

            scrollbar.ButtonDraw(spriteBatch, a);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Resize() {
            if (Global.WindowWidth!=0){
                worldsTarget?.Dispose();
                worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65-40);

                effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75-40));
                effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75-40))*5);

                scrollbar.height=Global.WindowHeight-75-65-2-40;
                scrollbar.scale=0;

                scrollbar.maxheight=geDo.GetHeight;

               if (infoTabPage == 2) {
                    geDo.width=Global.WindowWidth-80;
                    geDo.BuildString(strHowTo);
                }

                buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-50-4);
			    buttonInfoMain.Position=new Vector2(Global.WindowWidthHalf-(25 + 130 + 154 + 154 + 154+154)/2+25-20+4-10-15-1+154, 75);
                buttonInfoKeyBoard.Position=new Vector2(Global.WindowWidthHalf-(25 + 130 + 154 + 154 + 154+154)/2+25 + 130+5-20+4-10+16+154, 75);
                buttonInfoHow.Position=new Vector2(Global.WindowWidthHalf-(25 + 130 + 154 + 154 + 154+154)/2+25 + 130 + 154+10-20+4-10+16+154, 75);


                scrollbar.PositionX=Global.WindowWidth-35;
            }
        }


        string KeyName(Keys Key) {
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
                case Keys.OemCloseBrackets: return ")";//ΩBracketsC
                case Keys.OemOpenBrackets: return "(";//ΩBracketsO
                case Keys.PageUp: return Lang.Texts[262];
                case Keys.PageDown: return Lang.Texts[263];
                case Keys.OemTilde: return "~";//Tilde
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