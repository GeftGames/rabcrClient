using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rabcrClient {
    class MenuLang: MenuScreen {
        abstract class LItem{
            public abstract void SetPos(int x, int y, int w);
            public abstract void Draw(SpriteBatch sb);
            public abstract bool Update();

            public delegate void ClickEvent();

            public bool IsCategory => this is LCategory;

            public int Y;
            //    {
            //    get{
            //        if (/*IsCategory*/this is LCategory category) {
            //            return category.Y;
            //        }else{
            //            return ((LLanguage)this).Y;
            //        }
            //    }
            //}
            public bool IsOnStartUpPage;
        }

        class LLanguage: LItem {
         //   public event ClickEvent Click;
            public List<Texture2D> Flag;
            public Text Text;
         //   public ButtonCenterLang ButtonApply;
            public Texture2D /*TextureStar,*/ TextureOK;
            public bool hasFlags, multipleFlags;
            //public float SetStars{
            //    set{
            //        Stars=value;
            //        StarsCnt=Stars*3-(int)(Stars*3);

            //        if (StarsCnt>=0.333f) {
            //            if (StarsCnt<0.666f) {
            //                starPart=new Rectangle(0, 0, 8, 16);
            //            }
            //        }
            //    }
            //}
            public int id;

          //  Rectangle starPart;
            public Vector2 flagPos;
            public int X,/* Y,*/ W;
          //  public int Y;
            //private readonly float StarsCnt;
            //private readonly float Stars;
            Color back;
            public  Rectangle recBack;
            float alpha, needAlpha;
            bool clicked=false;
            float way;
            int wayIndex=0;
            bool cl;

            public int Quality;

            public override bool Update() {
                cl=id==Setting.CurrentLanguage;
                if (multipleFlags){
                    way+=0.02f;
                    if (way>1){
                        way=0;
                        wayIndex++;
                        if (wayIndex>=Flag.Count)wayIndex=0;
                    }
                }
                if (MouseIn()) {
                    if (Menu.mouseDown) {
                        if (cl) needAlpha=0.4f;
                        else needAlpha=0.9f;
                        clicked=true;
                    } else {
                        if (clicked) {
                            if (Rabcr.Game.IsActive){
                                clicked=false;
                                //Click.Invoke();
                                return true;
                            }
                        }

                        if (cl) needAlpha=0.5f;
                        else needAlpha=0.6f;
                    }
                } else {
                    if (cl) needAlpha=0.7f;
                    else needAlpha=0;
                    clicked=false;
                }

                if (needAlpha!=alpha) {
                    if (Constants.AnimationsControls) {
                        if (alpha>needAlpha){
                            alpha-=0.02f;
                        }else{
                            alpha+=0.02f;
                        }
                    } else {
                        alpha=needAlpha;
                    }
                    back=Color.White*alpha;

                }

                return false;
            }

            bool MouseIn() {
                if (IsOnStartUpPage){
                    //if (Menu.mousePosY>Global.WindowHeight-67) return false;
                    //if (Menu.mousePosY<160) return false;
                    //if (Menu.mousePosX<X) return false;
                    //if (Menu.mousePosYCorrection-100+6+5+2<Y) return false;
                    //if (Menu.mousePosX>X+W) return false;
                    //if (Menu.mousePosYCorrection-100+6+5+2>Y+59) return false;
                     if (Menu.mousePosY>Global.WindowHeight-67) return false;
                    if (Menu.mousePosY<70) return false;
                    if (Menu.mousePosX<X) return false;
                    if (Menu.mousePosYCorrection<Y) return false;
                    if (Menu.mousePosX>X+W) return false;
                    if (Menu.mousePosYCorrection>Y+60) return false;
                }else{
                    if (Menu.mousePosY>Global.WindowHeight-67) return false;
                    if (Menu.mousePosY<160) return false;
                    if (Menu.mousePosX<X) return false;
                    if (Menu.mousePosYCorrection-100+6+5+2<Y) return false;
                    if (Menu.mousePosX>X+W) return false;
                    if (Menu.mousePosYCorrection-100+6+5+2>Y+59) return false;
                }
                return true;
            }

            public override void SetPos(int x, int y, int w) {
                X=x;
                W=w;
                Y=y;
                flagPos=new Vector2(x+10,y+15);
                Text.ChangePosition(x+60+15+5,y+15);
                recBack=new Rectangle(X,Y,W,60);
            }

            public override void Draw(SpriteBatch sb) {

                sb.Draw(Rabcr.Pixel, recBack, back);

                // Name of language
                   switch (Quality){
                        default:
                            Text.Draw(sb);
                            break;

                        case 0:
                            Text.Draw(sb, Color.Red);
                            break;

                        case 1:
                            Text.Draw(sb, Color.Orange);
                            break;

                        //case 2:
                        //    Text.Draw(sb, Color.Orange);
                         //   break;

                }
                ////// Flag
                ////if (Flag!=null) sb.Draw(Flag, flagPos, Color.White);

                // Draw flags
                if (hasFlags) {
                    if (multipleFlags){
                        float w=way*3f;
                        if (w>1)w=1;

                        float w2;
                        if (way>0.666f)w2=1-(way-0.666f)*3f;
                        else w2=1;

                        sb.Draw(Flag[wayIndex],new Vector2(X+(1-way)*5+10,Y+(1-way)*5+10),Color.White*w2);

                        Texture2D t2;
                        if (wayIndex+1==Flag.Count)t2=Flag[0];
                        else t2=Flag[wayIndex+1];

                        sb.Draw(t2,new Vector2(X+(2-way)*5+10,Y+(2-way)*5+10),Color.White*w);
                    }else{
                        sb.Draw(Flag[0],new Vector2(X+15,Y+15),Color.White);
                    }
                }

                // Stars
                //{
                //    int x = X+(int)(Stars*3)*8+24+(StarsCnt>=.333f ? -4 : 0)+(StarsCnt>=.666f ? -4 : 0);
                //    for (int s = 0; s<(int)(Stars*3); s++) {
                //        sb.Draw(TextureStar, new Vector2(x, Y+31), Color.White);
                //        x+=16;
                //    }

                //    if (StarsCnt>=0.333f) {
                //        if (StarsCnt>=0.666f) {
                //            sb.Draw(TextureStar, new Vector2(x, Y+31), Color.White);
                //        } else {
                //            sb.Draw(TextureStar, new Vector2(x, Y+31), starPart, Color.White);
                //        }
                //    }
                //}

                if (cl){
                    sb.Draw(TextureOK, new Vector2(X+5, Y+5), Color.White);
                }
            }
        }

        class LCategory:LItem {
            public List<LItem> Languages;
            public LCategory Parent;
            public string Name;

            public Text Text;
            float alpha, needAlpha;
            bool clicked=false;
            public int X, /*Y,*/ W;
         //   int Y;
            Color back;
            float way;
            int wayIndex=0;
            List<Texture2D> texs;
          //  public event ClickEvent Click;
            Rectangle rec;

            public void Prepare(){
                texs=new List<Texture2D>();

                Add(Languages);
                //for (int i=0; i<Languages.Count; i++){
                //    LItem l = Languages[i];
                //    if (!l.IsCategory){
                //        LLanguage ll=(LLanguage)l;
                //        if (ll.Flag!=null){
                //            texs.AddRange(ll.Flag);
                //        }
                //    }

                //}

                void Add(List<LItem> z) {
                    if (z==null) return;

                    foreach (LItem i in z){
                        if (i.IsCategory){
                            Add(((LCategory)i).Languages);
                        }else{
                            LLanguage ll=(LLanguage)i;
                            if (ll.Flag!=null){
                                texs.AddRange(ll.Flag);
                            }

                        }
                    }
                }

                rec=new Rectangle(X,Y,W,60);
            }

            public override bool Update() {
                way+=0.02f;
                if (way>1){
                    way=0;
                    wayIndex++;
                    if (wayIndex>=texs.Count)wayIndex=0;
                }
                if (MouseIn()) {
                    if (Menu.mouseDown) {
                        if (Rabcr.Game.IsActive){
                            needAlpha=0.9f;
                            clicked=true;
                        }
                    } else {
                        if (clicked) {
                            clicked=false;
                            return true;
                            //Click.Invoke();
                        }

                        needAlpha=0.6f;
                    }
                } else {
                    needAlpha=0;
                }

                if (needAlpha!=alpha) {
                    if (Constants.AnimationsControls) {
                        if (alpha>needAlpha){
                            alpha-=alpha/8f+0.02f;
                        }else{
                            alpha+=alpha/8f+0.02f;
                        }
                        float x=alpha-needAlpha;
                        if (x<0) x=-x;
                        if (x<0.05)alpha=needAlpha;
                    } else {
                        alpha=needAlpha;
                    }
                    back=/*new Color(0.75f-alpha/8f, 0.75f-alpha/8f, .75f-alpha/8f)*/Color.White*alpha;

                }

                return false;
            }

            bool MouseIn() {
                if (IsOnStartUpPage){
                    //if (Menu.mousePosY>Global.WindowHeight-67+60/*?*/) return false;
                    //if (Menu.mousePosY<0/*70*/) return false;
                    //if (Menu.mousePosX<X) return false;
                    //if (Menu.mousePosY<Y) return false;
                    //if (Menu.mousePosX>X+W) return false;
                    //if (Menu.mousePosY>Y+60) return false;
                    if (Menu.mousePosY>Global.WindowHeight-67) return false;
                    if (Menu.mousePosY<70) return false;
                    if (Menu.mousePosX<X) return false;
                    if (Menu.mousePosYCorrection<Y) return false;
                    if (Menu.mousePosX>X+W) return false;
                    if (Menu.mousePosYCorrection>Y+60) return false;
                }else{
                     if (Menu.mousePosY>Global.WindowHeight-67) return false;
                    if (Menu.mousePosY<160) return false;
                    if (Menu.mousePosX<X) return false;
                    if (Menu.mousePosYCorrection-100+6+5+2<Y) return false;
                    if (Menu.mousePosX>X+W) return false;
                    if (Menu.mousePosYCorrection-100+6+5+2>Y+59) return false;
                }
                return true;
            }

            public override void SetPos(int x, int y, int w) {
                X=x;
                W=w;
                Y=y;
             //   flagPos=new Vector2(x,y);
               Text.ChangePosition(x+65+15,y+15);
                rec=new Rectangle(X,Y,W,60);

                    //    LCategory c= (LCategory)f;
                    //    c.Text=new Text(c.Name,xxx+15+65, yy+15, BitmapFont.bitmapFont18);
                    //    c.Y=yy;
                    //    c.W=DocumentSize;
                    //    c.X=xxx;
                    //    c.Prepare();
                    //    yy+=60;
            }

            public override void Draw(SpriteBatch sb) {

                sb.Draw(Rabcr.Pixel, rec, back);

                // Name of category
                Text.Draw(sb);

                // Draw flags
                if (texs.Count>1) {
                    float w=way*3f;
                    if (w>1)w=1;

                    float w2;
                    if (way>0.666f)w2=1-(way-0.666f)*3f;
                    else w2=1;

                    sb.Draw(texs[wayIndex],new Vector2(X+(1-way)*5+10,Y+(1-way)*5+10),Color.White*w2);

                    Texture2D t2;
                    if (wayIndex+1==texs.Count)t2=texs[0];
                    else t2=texs[wayIndex+1];

                    sb.Draw(t2,new Vector2(X+(2-way)*5+10,Y+(2-way)*5+10),Color.White*w);
                }else if (texs.Count==1){
                    sb.Draw(texs[0],new Vector2(X+10+2.5f,Y+2.5f+10),Color.White);
                }

            }
        }

        #region Varibles
        Text goBack;
        float backAlpha=0.7f;
        float needBackAlpha=0.7f;
        Color backbuttonColor;
        bool clicked;
        ButtonCenter buttonBadTranslation;
        Scrollbar scrollbar;
        RenderTarget2D worldsTarget, backTarget;
        Effect effectBlur;
        Button buttonMenu;
        int yy;
        Text header;
        int DocumentSize=400;
        int start;
        float smoothMouse=0;
        List<LItem> LanguageList;
        int deepSelected;
        LCategory current;
        int xxx;
        ImgButton categorySwitch;
        int langStart;
        #endregion

        void SetNewLanguage(LLanguage l) {
            Setting.CurrentLanguage=l.id;
            Lang.SetUp(false);
            Rabcr.SetLangUp();

            header=new Text(Lang.Texts[121], 10, 10, BitmapFont.bitmapFont34);

            buttonBadTranslation=new ButtonCenter(Textures.ButtonLong){ Text= Lang.Texts[348]};
            buttonBadTranslation.Position=new Vector2(0, Global.WindowHeight-54);

            buttonMenu=new Button(Textures.ButtonLongLeft, Lang.Texts[1]) {
                Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-54)
            };
            goBack=new Text(Lang.Texts[364],Global.WindowWidthHalf-BitmapFont.bitmapFont18.MeasureTextSingleLineX(Lang.Texts[364])/2,10+65+10+2,BitmapFont.bitmapFont18);

            buttonMenu.Click+=ClickMenu;
        }
        public override void Init() {
            buttonMenu= new Button(Textures.ButtonLongLeft, Lang.Texts[1]);
            buttonMenu.Click+=ClickMenu;

            buttonBadTranslation=new ButtonCenter(Textures.ButtonLong){ Text= Lang.Texts[348]};

            effectBlur=Effects.BluredTopDownBounds;

            scrollbar=new Scrollbar(GetDataTexture(@"Buttons\Scrollbar\Top"), GetDataTexture(@"Buttons\Scrollbar\Center"), GetDataTexture(@"Buttons\Scrollbar\Bottom")) {
                PositionY=76
            };
            scrollbar.MoveScollBar+=Move;
            header=new Text(Lang.Texts[121],10, 10,BitmapFont.bitmapFont34);

            categorySwitch=new ImgButton(GetDataTexture("Buttons/Other/list")) {
                Position=new Vector2(2, 80)
            };

            langStart=Setting.CurrentLanguage;
            if (Setting.LangSortByList) BuildListByList(); else BuildListByCategory();

            Resize();
            Move(null,null);
        }

        void ClickMenu(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MainMenu());

        void ClickWrongTranslation() {
            using (FormBadTranslation fbt = new FormBadTranslation()){
                fbt.ShowDialog();
            }
        }

        void BuildListByCategory(){
            DocumentSize=(int)(Global.WindowWidth*0.6f);
            if (DocumentSize<300) DocumentSize=200;
            if (DocumentSize>550) DocumentSize=550;
            xxx=Global.WindowWidthHalf-DocumentSize/2;
            int y=0;
         //    yy=0;


            LanguageList=new List<LItem>();//{

            Texture2D ok=GetDataTexture("Menu/Styles/Used");
            foreach (Language l in Lang.Languages) {


                // Known category
                foreach (string strCategory in l.Category) {
                    string[] path=strCategory.Split('>');
                    InsertInto(LanguageList,path,l,null);

                }
            }

            void InsertInto(List<LItem> langs, string[] path, Language lang, LCategory par){
                bool exists=false;
                foreach (LItem item in langs) {
                    if (item.IsCategory) {
                        LCategory cat=(LCategory)item;
                        if (cat.Name==path[0]) {
                            if (path.Length==1) {
                                LLanguage l = new LLanguage {
                                    Text=new Text(lang.EnglishName, xxx, y, BitmapFont.bitmapFont18),
                                    TextureOK=ok,
                                    id=lang.id
                                };
                                if (lang.Flags!=null) {

                                    if (lang.Flags.Length>0) {
                                        l.Quality=lang.Quality;
                                        l.Flag=new List<Texture2D>();
                                        foreach (string s in lang.Flags) {
                                            var pth = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                                            if (File.Exists(pth+"\\RabcrData\\"+Setting.StyleName+@"\Textures\Menu\Flags\"+s+".xnb")){
                                            Texture2D tex=null;
                                            try {
                                                tex=GetDataTexture(@"Menu\Flags\"+s);
                                               //tex= Content.Load<Texture2D>(Setting.StyleName+@"/Textures/Menu\Flags\"+s);
                                            }catch{ }
                                                if (tex!=null)l.Flag.Add(tex);
                                            }
                                        }
                                    }
                                    if (l.Flag.Count>0){
                                        l.hasFlags=true;
                                        if (l.hasFlags) l.flagPos=new Vector2(xxx+10,yy+15);
                                        if (l.Flag.Count>1)l.multipleFlags=true;
                                    }
                                }

                                if (cat.Languages==null) cat.Languages=new List<LItem>{ l };
                                else cat.Languages.Add(l);
                            } else {
                                if (cat.Languages==null) cat.Languages=new List<LItem>();
                                string[] p=new string[path.Length-1];
                                Array.Copy(path,1,p,0,path.Length-1);

                                InsertInto(cat.Languages,p,lang,cat);
                            }
                            return;
                        }
                    }
                }

                if (!exists) {
                    string trns=TranslateLanguageCategory(path[0]);
                    LCategory cat = new LCategory {
                        Name=path[0],
                        Text=new Text(trns, xxx, y, BitmapFont.bitmapFont18),
                        Parent=par
                    };
                    langs.Add(cat);
                    InsertInto(langs,path,lang,cat);
                }
            }



            {
                current=null;
                deepSelected=0;

                yy=(int)(-scrollbar.scale*((/*LangSections.Length*/+1)*60-(Global.WindowHeight-75-40-65)-85/*+30*/))/*+70*/+15;/*+140+90*/
                //startWindowPosX=Global.WindowWidthHalf-DocumentSize/2;

                foreach (LItem f in LanguageList){
                    if (f is LCategory category) {

                        category.Prepare();
                    //    yy+=60;
                    }else{
                        f.SetPos(xxx,yy+60,DocumentSize);

                    }
                    f.IsOnStartUpPage=true;
                }
            }

           // Console.WriteLine("");

            string TranslateLanguageCategory(string name) {
                switch (name) {
                    case "Worldwide":
                        if (Lang.Texts[300]=="Worldwide") return Lang.Texts[300];
                        else return Lang.Texts[300]+" (Worldwide)";

                    case "Constructed":
                        if (Lang.Texts[301]=="Constructed") return Lang.Texts[301];
                        else return Lang.Texts[301]+" (Constructed)";

                    case "Asian":
                        if (Lang.Texts[302]=="Asian") return Lang.Texts[302];
                        else return Lang.Texts[302]+" (Asian)";

                    case "African":
                        if (Lang.Texts[303]=="African") return Lang.Texts[303];
                        else return Lang.Texts[303]+" (African)";

                    case "American":
                        if (Lang.Texts[304]=="American") return Lang.Texts[304];
                        else return Lang.Texts[304]+" (American)";

                    case "European":
                        if (Lang.Texts[305]=="European") return Lang.Texts[305];
                        else return Lang.Texts[305]+" (European)";

                    case "Australian":
                        if (Lang.Texts[306]=="Australian") return Lang.Texts[306];
                        else return Lang.Texts[306]+" (Australian)";

                    case "Germanic":
                        if (Lang.Texts[307]=="Germanic") return Lang.Texts[307];
                        else return Lang.Texts[307]+" (Germanic)";

                    case "Slavic":
                        if (Lang.Texts[308]=="Slavic") return Lang.Texts[308];
                        else return Lang.Texts[308]+" (Slavic)";

                    case "Romance":
                        if (Lang.Texts[309]=="Romance") return Lang.Texts[309];
                        else return Lang.Texts[309]+" (Romance)";

                    case "Celtic":
                        if (Lang.Texts[310]=="Celtic") return Lang.Texts[310];
                        else return Lang.Texts[310]+" (Celtic)";

                    case "Baltic":
                        if (Lang.Texts[311]=="Baltic") return Lang.Texts[311];
                        else return Lang.Texts[311]+" (Baltic)";

                    case "Finno-Ugric":
                        if (Lang.Texts[312]=="Finno-Ugric") return Lang.Texts[312];
                        else return Lang.Texts[312]+" (Finno-Ugric)";

                    case "Other":
                        if (Lang.Texts[313]=="Other") return Lang.Texts[313];
                        else return Lang.Texts[313]+" (Other)";

                    case "Czech":
                        if (Lang.Texts[357]=="Czech") return Lang.Texts[357];
                        else return Lang.Texts[357]+" (Czech)";

                    case "Oceanic":
                        if (Lang.Texts[358]=="Oceanic") return Lang.Texts[358];
                        else return Lang.Texts[358]+" (Oceanic)";

                    case "Japanese":
                        if (Lang.Texts[359]=="Japanese") return Lang.Texts[359];
                        else return Lang.Texts[359]+" (Japanese)";

                }
                #if DEBUG
                throw new Exception("Unknown category '"+name+"'");
                #else
                return name;
                #endif
            }
        }

        void BuildListByList(){
            DocumentSize=(int)(Global.WindowWidth*0.6f);
            if (DocumentSize<300) DocumentSize=200;
            if (DocumentSize>550) DocumentSize=550;
            xxx=Global.WindowWidthHalf-DocumentSize/2;
            int y=0;

            LanguageList=new List<LItem>();
            Texture2D ok=GetDataTexture("Menu/Styles/Used");

            List<Language> z= Lang.Languages.ToList();
            z.Sort((Language x, Language u) => x.NativeName.CompareTo(u.NativeName));

            foreach (Language l in z) {
                InsertInto(LanguageList, l);
            }

            void InsertInto(List<LItem> langs, Language lang) {
                LLanguage l = new LLanguage {
                    TextureOK=ok,
                    id=lang.id
                };

                bool displayEnglishName=true;
                Language langO=Lang.Languages[l.id];
                if (langO.EnglishName==langO.NativeName) displayEnglishName=false;
                else if (langO.Name=="eng" || langO.Name=="enu" || langO.Name=="ena" || langO.Name=="enc") displayEnglishName=false;
                else if (DocumentSize<450) displayEnglishName=false;

                string dis=langO.NativeName;

                if (BitmapFont.bitmapFont18.IsUjgur(dis)) {
                    char[] g = dis.ToCharArray();
                    dis="";
                    for (int i = g.Length-1; i>=0; i--) {
                        if (g[i]!='\u200E') dis+=g[i];
                    }
                }
                if (displayEnglishName) {
                    dis+= " ("+langO.EnglishName+")";
                }
                l.Text=new Text(dis, xxx, y, BitmapFont.bitmapFont18);

                l.Quality=lang.Quality;

                if (lang.Flags!=null) {

                    if (lang.Flags.Length>0) {

                        l.Flag=new List<Texture2D>();
                        foreach (string s in lang.Flags) {
                            var pth = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                            if (File.Exists(pth+"\\RabcrData\\"+Setting.StyleName+@"\Textures\Menu\Flags\"+s+".xnb")){
                            Texture2D tex=null;
                            try {
                                tex=GetDataTexture(@"Menu\Flags\"+s);
                            }catch{ }
                                if (tex!=null)l.Flag.Add(tex);
                            }
                        }
                    }
                    if (l.Flag.Count>0){
                        l.hasFlags=true;
                        if (l.hasFlags) l.flagPos=new Vector2(xxx+10,yy+15);
                        if (l.Flag.Count>1)l.multipleFlags=true;
                    }
                }

                langs.Add(l);
            }

            {
                current=null;
                deepSelected=0;

                yy=(int)(-scrollbar.scale*((+1)*60-(Global.WindowHeight-75-40-65)-85/*+30*/))/*+70*/+15;

                foreach (LItem f in LanguageList){
                    f.SetPos(xxx, yy+60, DocumentSize);
                    f.IsOnStartUpPage=true;
                }
            }
        }

        private void Move(object sender, EventArgs e) {
            start=0;
            yy=(int)(-scrollbar.scale*(PageHeight()-(Global.WindowHeight-75-40-65)))+15;

            if (deepSelected!=0 && current.Languages!=null){
                List<LItem> langs=current.Languages;

                for (int i = 0; i<langs.Count; i++) {
                    if (yy<0)start=i;
                    LItem c=langs[i];
                    c.SetPos(xxx,yy,DocumentSize);

                    yy+=60;
                }
            }else{
                 List<LItem> cc;
                if (deepSelected==0) cc=LanguageList;
                else cc=current.Languages;

                for (int i = 0; i<cc.Count; i++) {
                    if (yy<0)start=i;
                    LItem c=cc[i];
                    c.SetPos(xxx,yy,DocumentSize);
                    yy+=60;
                }
            }
        }

        public override void Shutdown() {
            // Save changed language
            if (Setting.CurrentLanguage!=langStart) Setting.SaveSetting();
        }

        public override void Update(GameTime gameTime) {
            MousePos.mouseRealPosX=Menu.mousePosX;
            MousePos.mouseRealPosY=Menu.mousePosY;
            MousePos.mouseLeftDown=Menu.mouseDown;
            MousePos.mouseLeftRelease=Menu.oldMouseState.LeftButton==ButtonState.Pressed && !Menu.mouseDown;
            if (Menu.newKeyboardState.IsKeyDown(Keys.Up)) smoothMouse-=2f;
            if (Menu.newKeyboardState.IsKeyDown(Keys.Down)) smoothMouse+=2f;

            if (Menu.newKeyboardState.IsKeyDown(Keys.PageUp)) smoothMouse-=5;
            if (Menu.newKeyboardState.IsKeyDown(Keys.PageDown)) smoothMouse+=5;

            if (Menu.newMouseState.ScrollWheelValue!=Menu.oldMouseState.ScrollWheelValue) {
                smoothMouse+=(Menu.oldMouseState.ScrollWheelValue-Menu.newMouseState.ScrollWheelValue)/3f;
            }

            if (categorySwitch.Update()) {

                Setting.LangSortByList=!Setting.LangSortByList;

                if (Setting.LangSortByList) {
                    BuildListByList();
                    categorySwitch=new ImgButton(GetDataTexture("Buttons/Other/list"));
                } else {
                    BuildListByCategory();
                    categorySwitch=new ImgButton(GetDataTexture("Buttons/Other/category"));
                }

                categorySwitch.Position=new Vector2(2, 80);
                Resize();
                Move(null,null);
            }

            if (smoothMouse!=0) {
                if (Constants.AnimationsControls) {
                    scrollbar.Scroll(smoothMouse/1.5f);
                    smoothMouse/=1.3f;
                    if (smoothMouse>0){
                        if (smoothMouse<0.049f) smoothMouse=0;
                    } else {
                        if (smoothMouse>-0.049f) smoothMouse=0;
                    }
                } else {
                    scrollbar.Scroll(smoothMouse);
                    smoothMouse=0;
                }
            }

            buttonMenu.Update();

            if (buttonBadTranslation.Click)ClickWrongTranslation();

            List<LItem> langs;

            if (deepSelected!=0) langs =current.Languages;
            else langs=LanguageList;

            for (int i = start; i<langs.Count; i++) {
                LItem c=langs[i];
                if (c.Update()) {
                    if (c.IsCategory) {
                        current=(LCategory)c;
                        deepSelected++;
                        scrollbar.scale=0;
                        foreach (LItem x in current.Languages) {
                            if (x.IsCategory) {
                                ((LCategory)x).Prepare();
                            }
                        }

                        SetSubLangs();
                        Resize();
                        Move(null,null);
                    } else {
                        LLanguage lang=(LLanguage)c;
                        if (lang.Quality==0 || lang.Quality==1) {
                            System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("This translation of the game is not very good. Some parts of text may not be rendered correctly or the translations may not be good. Do you want to switch?","Low quality translation", System.Windows.Forms.MessageBoxButtons.YesNo);
                            if (dr==System.Windows.Forms.DialogResult.Yes)SetNewLanguage(lang);
                        }else SetNewLanguage(lang);
                    }
                }
            }

            // Go back
            if (deepSelected!=0) {
                if (MouseInBackButton()) {
                    if (Menu.mouseDown) {
                        needBackAlpha=1f;
                        clicked=true;
                    } else {
                        if (clicked){
                            deepSelected--;
                            scrollbar.scale=0;
                            if (deepSelected==0) {
                                current=null;
                                clicked=false;

                                worldsTarget?.Dispose();
                                worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65);

                                scrollbar=new Scrollbar(GetDataTexture(@"Buttons\Scrollbar\Top"), GetDataTexture(@"Buttons\Scrollbar\Center"), GetDataTexture(@"Buttons\Scrollbar\Bottom")) {
                                    PositionY=76
                                };
                                scrollbar.MoveScollBar+=Move;
                                Resize();
                            } else {
                                Resize();
                                current=current.Parent;
                                clicked=false;

                                foreach (LItem x in current.Languages) {
                                    if (x.IsCategory) {
                                        ((LCategory)x).Prepare();
                                    }
                                }

                                SetSubLangs();
                            }
                        }
                        needBackAlpha=0.9f;
                    }
                } else {
                    needBackAlpha=0.7f;
                }

                if (needBackAlpha!=backAlpha) {
                    if (Constants.AnimationsControls) {
                        float delta=needBackAlpha-backAlpha;
                        if (delta<0)delta=-delta;
                        if (delta<0.05f) backAlpha=needBackAlpha;

                        if (backAlpha<needBackAlpha){
                            backAlpha+=0.01f+delta/8f;
                        }else{
                            backAlpha-=0.01f+delta/8f;
                        }
                    } else {
                        backAlpha=needBackAlpha;
                    }
                    backbuttonColor=new Color(1f, 1f, 1f)*backAlpha;
                }
            }

            base.Update(gameTime);
        }

        void SetSubLangs() {
            goBack=new Text(Lang.Texts[364],Global.WindowWidthHalf-BitmapFont.bitmapFont18.MeasureTextSingleLineX(Lang.Texts[364])/2,10+65+10+2,BitmapFont.bitmapFont18);
            backbuttonColor=Color.White*0.7f;
            backTarget?.Dispose();
            worldsTarget?.Dispose();
            backTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,65);
            worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-65-160);
            effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-160));
            effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-160))*5);

            scrollbar=new Scrollbar(GetDataTexture(@"Buttons\Scrollbar\Top"), GetDataTexture(@"Buttons\Scrollbar\Center"), GetDataTexture(@"Buttons\Scrollbar\Bottom")) {
                PositionY=160
            };
            scrollbar.MoveScollBar+=Move;
            scrollbar.maxheight=PageHeight();
            scrollbar.scale=0;
            yy=15+5;
            buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-54);
            scrollbar.PositionX=Global.WindowWidth-35;
            scrollbar.Scroll(0);

            foreach (LItem lll in current.Languages) {
                if (!lll.IsCategory){
                    LLanguage l=(LLanguage)lll;

                    Language ll=Lang.Languages[l.id];
                    bool displayEnglishName=true;

                    if (ll.EnglishName==ll.NativeName) displayEnglishName=false;
                    else if (ll.Name=="eng" || ll.Name=="enu" || ll.Name=="ena" || ll.Name=="enc") displayEnglishName=false;
                    //else if (ll.Base.Name=="eng"/* || ll.Name=="enu" || ll.Name=="ena" || ll.Name=="enc"*/) displayEnglishName=false;
                    else if (DocumentSize<450) displayEnglishName=false;

                    string dis=ll.NativeName;

                    if (BitmapFont.bitmapFont18.IsUjgur(dis)) {
                        char[] g = dis.ToCharArray();
                        dis="";
                        for (int i = g.Length-1; i>=0; i--) {
                            if (g[i]!='\u200E') dis+=g[i];
                        }
                    }
                    if (displayEnglishName) dis+= " ("+ll.EnglishName+")";

                    l.recBack=new Rectangle(xxx,yy,DocumentSize,60);
                    l.X=xxx;
                    l.W=DocumentSize;
                    l.Y=yy;
                    l.Text=new Text(BitmapFont.bitmapFont18.MaxSizeOfString(dis,DocumentSize-128-5), xxx+60+10, yy+15, BitmapFont.bitmapFont18);

                    yy+=60;
                } else {
                    lll.SetPos(xxx,yy,DocumentSize);yy+=60;
                }
            }
            Resize();
        }

        public override void PreDraw() {
            Graphics.SetRenderTarget(worldsTarget);
            Graphics.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend);

            List<LItem> cc;
            if (deepSelected==0) cc=LanguageList;
            else cc=current.Languages;

            for (int i = start; i<cc.Count; i++) {
                LItem c=cc[i];
                c.Draw(spriteBatch);
            }

            spriteBatch.End();
            Graphics.SetRenderTarget(null);
        }

        public override void Draw(GameTime gameTime, float a) {
            effectBlur.Parameters["alpha"].SetValue(a);
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,effectBlur);
            effectBlur.Techniques[0].Passes[0].Apply();

            if (deepSelected!=0) {
                spriteBatch.Draw(worldsTarget, new Vector2(0, 160), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight-65-160), Color.White);
                spriteBatch.End();

                spriteBatch.Begin();
                for (int i=0; i<5; i++){
                    spriteBatch.Draw(Rabcr.Pixel,new Rectangle(0,76+i,Global.WindowWidth,1),backbuttonColor*(i/5f));
                }
                spriteBatch.Draw(Rabcr.Pixel,new Rectangle(0,76+5,Global.WindowWidth,60-5),backbuttonColor);

                for (int i=5; i>-1; i--){
                    spriteBatch.Draw(Rabcr.Pixel,new Rectangle(0,76+i+60, Global.WindowWidth,1), backbuttonColor*((5-i)/5f));
                }

                goBack.Draw(spriteBatch);
            } else {
                 spriteBatch.Draw(worldsTarget, new Vector2(0, 76), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight-75-65-2), Color.White);
            }

            spriteBatch.End();

            spriteBatch.Begin();
            header.Draw(spriteBatch,Color.Black*a);
            categorySwitch.ButtonDraw();

            buttonMenu.ButtonDraw(spriteBatch, a);
            buttonBadTranslation.ButtonDraw(spriteBatch, a);

            scrollbar.ButtonDraw(spriteBatch, a);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        int PageHeight(){
            if (deepSelected!=0) return current.Languages.Count*60+60+10;
            else return LanguageList.Count*60+10;
        }

        public override void Resize() {
            DocumentSize=(int)(Global.WindowWidth*0.6f);
            if (DocumentSize<300) DocumentSize=200;
            if (DocumentSize>550) DocumentSize=550;
            xxx=Global.WindowWidthHalf-DocumentSize/2;
            scrollbar.Scroll(0);

            categorySwitch.Position=new Vector2(2,80);
            if (deepSelected!=0){
                goBack.ChangePosition(Global.WindowWidthHalf-BitmapFont.bitmapFont18.MeasureTextSingleLineX(Lang.Texts[364])/2,10+75+5+2);
                backTarget?.Dispose();
                backTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,50);

                if (Global.WindowHeight-65-160>0) {
                    worldsTarget?.Dispose();
                    worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-65-160);
                }
                effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75-160+60));
                effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75-160+60))*5);
                scrollbar.height=Global.WindowHeight-75-65-2-100+15;
            } else {
                worldsTarget?.Dispose();
                worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65);
                effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
                effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);
                scrollbar.height=Global.WindowHeight-75-65-2;
            }

            scrollbar.maxheight=PageHeight();

            buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-54);
            buttonBadTranslation.Position=new Vector2(0, Global.WindowHeight-54);
            scrollbar.PositionX=Global.WindowWidth-35;

            //set start and end
             if (deepSelected!=0 && current.Languages!=null){
                List<LItem> langs=current.Languages;
                foreach (LItem l in langs) {
                    l.SetPos(xxx,l.Y,DocumentSize);
                }
            }
        }

        bool MouseInBackButton() {
            if (Menu.mousePosX<0) return false;
            if (Menu.mousePosY<76) return false;
            if (Menu.mousePosX>Global.WindowWidth) return false;
            if (Menu.mousePosY>76+65) return false;
            return true;
        }
    }
}