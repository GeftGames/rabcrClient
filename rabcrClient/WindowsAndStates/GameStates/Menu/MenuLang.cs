using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

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
                Text.Draw(sb);

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
        Effect effectBlur/*, effectBlur2*/;
        Button buttonMenu;
        int yy;
        //int startWindowPosX;
     //   LItem[] LangSections;
        Text header;
     //   Texture2D star;

        int DocumentSize=400;
        int start/*,end*/;
        float smoothMouse=0;
     //   bool loading;
        List<LItem> LanguageList;
        int deepSelected;
        LCategory current;
       // int yybef;
        int xxx;
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
           // buttonBadTranslation.,
            //buttonBadTranslation.Click+=ClickWrongTranslation;

            effectBlur=Effects.BluredTopDownBounds;
            //effectBlur2=Effects.BluredTopDownBounds.Clone();
            //star=GetDataTexture(@"Menu\Star");
            scrollbar=new Scrollbar(GetDataTexture(@"Buttons\Scrollbar\Top"), GetDataTexture(@"Buttons\Scrollbar\Center"), GetDataTexture(@"Buttons\Scrollbar\Bottom")) {

                PositionY=76
            };
            scrollbar.MoveScollBar+=Move;
            header=new Text(Lang.Texts[121],10, 10,BitmapFont.bitmapFont34);

            BuildList();
           // SetPage();
            Resize();
            Move(null,null);
        }

        void ClickMenu(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MainMenu());
        
        void ClickWrongTranslation() { 
            using (FormBadTranslation fbt = new FormBadTranslation()){ 
                fbt.ShowDialog();    
            }
        }

        void BuildList(){
             DocumentSize=(int)(Global.WindowWidth*0.6f);
           if (DocumentSize<300) DocumentSize=200;
         if (DocumentSize>550) DocumentSize=550;
         xxx=Global.WindowWidthHalf-DocumentSize/2;
            int y=0;

           // LCategory unknown;
          //  int xx=Global.WindowWidthHalf-DocumentSize/2;
           // int ym=-60/*, ys=-60*/;
            LanguageList=new List<LItem>();//{
            //    // Worldwide
            //    new LCategory{
            //        Name="Worldwide",
            //        //X=xxx,
            //        //Y=ym+=60,
            //        //W=DocumentSize,
            //        //Text=new Text(Lang.Texts[300],xxx+60,ym+20,BitmapFont.bitmapFont18),
            //    },

            //    // Europan
            //    new LCategory{
            //        Name="European",
            //        //X=xxx,
            //        //Y=ym+=60,
            //        //W=DocumentSize,
            //        //Text=new Text(Lang.Texts[305],xxx+60,ym+20,BitmapFont.bitmapFont18),
            //    //    SubCategories=new List<LCategory>{

            //    //        // Germanic
            //    //        new LCategory{
            //    //            Name="Germanic",
            //    //            X=xxx,
            //    //            Y=ys+=60,
            //    //            W=DocumentSize,
            //    //            Text=new Text(Lang.Texts[307],xxx+60,ys,BitmapFont.bitmapFont18),
            //    //        },

            //    //        // Romance
            //    //        new LCategory{
            //    //            Name="Romance",
            //    //            X=xxx,
            //    //            Y=ys+=60,
            //    //            W=DocumentSize,
            //    //            Text=new Text(Lang.Texts[309],xxx+60,ys,BitmapFont.bitmapFont18),
            //    //        },

            //    //        // Slavic
            //    //        new LCategory{
            //    //            Name="Slavic",
            //    //            X=xxx,
            //    //            Y=ys+=60,
            //    //            W=DocumentSize,
            //    //            Text=new Text(Lang.Texts[308],xxx+60,ys,BitmapFont.bitmapFont18),
            //    //        },

            //    //        // Celtic
            //    //        new LCategory{
            //    //            Name="Celtic",
            //    //            X=xxx,
            //    //            Y=ys+=60,
            //    //            W=DocumentSize,
            //    //            Text=new Text(Lang.Texts[310],xxx+60,ys,BitmapFont.bitmapFont18),
            //    //        },

            //    //        // Finno-Ugric
            //    //        new LCategory{
            //    //            Name="Finno-Ugric",
            //    //            X=xxx,
            //    //            Y=ys+=60,
            //    //            W=DocumentSize,
            //    //            Text=new Text(Lang.Texts[312],xxx+60,ys,BitmapFont.bitmapFont18),
            //    //        },

            //    //        // Other
            //    //        new LCategory{
            //    //            Name="Other",
            //    //            X=xxx,
            //    //            Y=ys+=60,
            //    //            W=DocumentSize,
            //    //            Text=new Text(Lang.Texts[313],xxx+60,ys,BitmapFont.bitmapFont18),
            //    //        },
            //    //    }
            //    },

            //    // Asian
            //    new LCategory{
            //        Name="Asian",
            //        //X=xxx,
            //        //Y=ym+=60,
            //        //W=DocumentSize,
            //        //Text=new Text(Lang.Texts[302],xxx+60,ym+20,BitmapFont.bitmapFont18),
            //    },

            //    // American
            //    new LCategory{
            //        Name="American",
            //        //X=xxx,
            //        //Y=ym+=60,
            //        //W=DocumentSize,
            //        //Text=new Text(Lang.Texts[304],xxx+60,ym+20,BitmapFont.bitmapFont18),
            //    },

            //    // African
            //    new LCategory{
            //        Name="African",
            //        //X=xxx,
            //        //Y=ym+=60,
            //        //W=DocumentSize,
            //      //  Text=new Text(Lang.Texts[303],xxx+60,ym+20,BitmapFont.bitmapFont18),
            //    },

            //    // African
            //    new LCategory{
            //        Name="Australian",
            //        //X=xxx,
            //        //Y=ym+=60,
            //        //W=DocumentSize,
            //      //  Text=new Text(Lang.Texts[303],xxx+60,ym+20,BitmapFont.bitmapFont18),
            //    },

            //    // Contructed
            //    new LCategory{
            //        Name="Constructed",
            //        //X=xxx,
            //        //Y=ym+=60,
            //        //W=DocumentSize,
            //        //Text=new Text(Lang.Texts[301],xxx+60,ym+20,BitmapFont.bitmapFont18),
            //    },

            //    // Not specified
            //    (unknown=new LCategory{
            //        //X=xxx,
            //        //Y=ym+=60,
            //        //W=DocumentSize,
            //        //Text=new Text(Lang.Texts[313],xxx+60,ym+20,BitmapFont.bitmapFont18),
            //    }),
            //};
            Texture2D ok=GetDataTexture("Menu/Styles/Used");
            foreach (Language l in Lang.Languages) {

                //// No spacifed category
                //if (l.Category==null) {
                //    LanguageList.Add(new LLanguage{
                //        id=l.id,
                //        Text=new Text(l.EnglishName,xxx+15+65,y+15,BitmapFont.bitmapFont18)
                //    });
                //     y+=60;
                //    continue;
                //}
               // System.Diagnostics.Debug.WriteLine(l.EnglishName);

                // Known category
                foreach (string strCategory in l.Category){
                    string[] path=strCategory.Split('>');
                    InsertInto(LanguageList,path,l,null);
     //                           bool finded=false;
     //               foreach (LItem ci in LanguageList) {
     //                   if (ci is LCategory){
     //                       LCategory c=(LCategory)ci;
     //                       if (c.Name==path[0]) {
     //                           //if (path.Length>1){
     //                           //    string sub=path[1];

     //                           //    foreach (LCategory sc in c.SubCategories) {
     //                           //        if (sc.Name==sub) {
     //                           //            if (sc.Languages==null)sc.Languages=new List<LItem>();
     //                           //            sc.Languages.Add(
     //                           //                new LItem{
     //                           //                    id=l.id,
     //                           //                    TextureStar=star,
     //                           //                }
     //                           //            );
     //                           //            break;
     //                           //        }
     //                           //    }
     //                           //}else{

     //                               if (path.Length==3){
     //                                  // bool f=false;
     //                                   if (c.Languages==null)c.Languages=new List<LItem>(){
     //                                           new LCategory{ Text=new Text( path[1], xxx+15+65, yy+15, BitmapFont.bitmapFont18),Name=path[1] }
     //                                       };

     //                                   foreach(LItem o in c.Languages ){
     //                                       if (o.IsCategory) {
     //                                           LCategory jk=(LCategory)o;
     //                                           if (jk.Name==path[1]) {
     //                                                LLanguage n=new LLanguage{
     //                                                   id=l.id,
     //                                                   TextureStar=star,
     //                                                   TextureOK=ok,

     //                                               };
     //                                               n.Text=new Text(l.Name, xxx+15+65, yy+15, BitmapFont.bitmapFont18);
     //                                               jk.Languages.Add(n);
     //                                               finded=true;
     //                                               break;
     //                                           }
     //                                       }
     //                                   }
     //                                   //if (!f){
     //                                   //   LLanguage n=new LLanguage{
     //                                   //        id=l.id,
     //                                   //        TextureStar=star,
     //                                   //        TextureOK=ok,

     //                                   //    };
     //                                   //    n.Text=new Text(l.Name, xxx+15+65, yy+15, BitmapFont.bitmapFont18);
     //                                   //    c.Languages.Add(n);
     //                                   //}
     //                               } else {


     //                                   if (c.Languages==null)c.Languages=new List<LItem>();
     //                                   LLanguage n=new LLanguage{
     //                                           id=l.id,
     //                                           TextureStar=star,
     //                                           TextureOK=ok,

     //                                       };
     //                                   n.Text=new Text(l.Name,xxx+15+65, yy+15, BitmapFont.bitmapFont18);
     //    //try {

     //    //                               n.Flag=GetDataTexture(@"Menu\Flags\"+l.Name);
     //    //                               } catch { }
     //                                   c.Languages.Add(n);
     //                               }
     //                             finded=true;
     //                           //}
     //                           break;
     //                       }
     //                   }
     //               }

     //               if (!finded){
     //                   if (path.Length==3){
     //                       LCategory cat0=new LCategory();
     //                       cat0.Name=path[0];
     //                       cat0.Text=new Text(cat0.Name,xxx,y,BitmapFont.bitmapFont18);
     //                       cat0.SetPos(xxx,y,DocumentSize);

     //                       LCategory cat1=new LCategory();
     //                       cat1.Name=path[1];
     //                       cat1.Text=new Text(cat1.Name,xxx,y,BitmapFont.bitmapFont18);
     //                       cat1.SetPos(xxx,y,DocumentSize);

     //                        y+=60;

     //                        LLanguage n=new LLanguage{
     //                           id=l.id,
     //                           TextureStar=star,
     //                           TextureOK=ok,
     //                       };
     //                       n.Text=new Text(l.Name,xxx+15+65, yy+15, BitmapFont.bitmapFont18);

     //                       cat1.Languages=new List<LItem>{n };
     //                       cat0.Languages=new List<LItem>{ cat1};

     //                       LanguageList.Add(cat0);
     //                   }else{
     //                       LCategory cat=new LCategory();
     //                       cat.Name=path[0];
     //                       cat.Text=new Text(cat.Name,xxx,y,BitmapFont.bitmapFont18);
     //                       cat.SetPos(xxx,y,DocumentSize);

     //                        y+=60;

     //                        LLanguage n=new LLanguage{
     //                           id=l.id,
     //                           TextureStar=star,
     //                           TextureOK=ok,
     //                       };
     //                       n.Text=new Text(l.Name,xxx+15+65, yy+15, BitmapFont.bitmapFont18);
     ////try {
     ////                               n.Flag=GetDataTexture(@"Menu\Flags\"+l.Name);
     ////                               } catch { }
     //                       cat.Languages=new List<LItem>{n };
     //                       LanguageList.Add(cat);
     //                   }

     //               }
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

           // if (unknown.Languages==null)LanguageList.Remove(unknown);

            //// Sort
            //foreach (LCategory c in Categories){
            //    if (c.SubCategories!=null){
            //        Categories.OrderBy(i => c.Languages.Count);
            //    }
            //}


            {
                current=null;
                deepSelected=0;

                yy=(int)(-scrollbar.scale*((/*LangSections.Length*/+1)*60-(Global.WindowHeight-75-40-65)-85/*+30*/))/*+70*/+15;/*+140+90*/
                //startWindowPosX=Global.WindowWidthHalf-DocumentSize/2;

                foreach (LItem f in LanguageList){
                    if (f is LCategory category) {
                    //    LCategory c= (LCategory)f;
                    //    c.Text=new Text(c.Name,xxx+15+65, yy+15, BitmapFont.bitmapFont18);
                    //    c.Y=yy;
                    //    c.W=DocumentSize;
                    //    c.X=xxx;
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
                throw new Exception("Missing translation of category");
                #else
                return name;
                #endif
            }
        }

        //int Mh(){
        //    if (deepSelected==0) return Categories.Count*60+60;
        //    if (deepSelected==1){
        //        if (current.SubCategories==null){
        //            return current.Languages.Count*60;
        //        }else{
        //            return current.SubCategories.Count*60;
        //        }
        //    }
        //    if (deepSelected==2) return current.Languages.Count*60;

        //    return 0;
        //}

        private void Move(object sender, EventArgs e) {
            start=0;
            //foreach (SettingItem si in settings)si.ChangePos(Global.WindowWidth-210,yy);
            yy=(int)(-scrollbar.scale*(PageHeight()-(Global.WindowHeight-75-40-65)/*-85*//*+30*/))/*+70*/+15;/*+140+90*/
         //   int delta=yy-yybef;
            //yybef=yy;

            //startWindowPosX=Global.WindowWidthHalf-DocumentSize/2;

         //   start-=delta/60;
           // if (start<0)start=0;
          //  end=start+(Global.WindowHeight-75-40-65)/60;

            if ((deepSelected!=0 && current.Languages!=null)){
                List<LItem> langs=current.Languages;

                for (int i = 0; i<langs.Count; i++) {
                    if (yy<0)start=i;
                    LItem c=langs[i];
                    c.SetPos(xxx,yy,DocumentSize);
                  //  if (yy>Global.WindowHeight-75-40-65+60){end=i; /*break;*/}

                    yy+=60;
                }
            //    end=start+(Global.WindowHeight-75-40-65+60)/60;
            }else{
                 List<LItem> cc;
                if (deepSelected==0) cc=LanguageList;
                else cc=current.Languages;

                for (int i = 0; i<cc.Count; i++) {
                    if (yy<0)start=i;
                    LItem c=cc[i];
                    c.SetPos(xxx,yy,DocumentSize);
                  //  if (yy>Global.WindowHeight-75-40-65+60) {end=i; /*break;*/}

                    yy+=60;
                }
              //  end=start+(Global.WindowHeight-75-40-65+60)/60;
            }

            //  SetPage();
            // #region Settings
            //////for (int i = 0; i<LangSections.Length; i++) {
            //////    if (yy>-50&&yy<Global.WindowHeight-160+20) {
            //////        if (start==-1)
            //////            start=i;
            //////        Language l = Lang.Languages[i];
            //////        bool displayEnglishName = true;
            //////        if (l.TwoLetterISOLanguageName=="en")
            //////            displayEnglishName=false;
            //////        if (l.EnglishName==l.NativeName)
            //////            displayEnglishName=false;
            //////        if (DocumentSize<400)
            //////            displayEnglishName=false;
            //////        string dis = l.NativeName;
            //////        if (displayEnglishName)
            //////            dis+=" ("+l.EnglishName+")";
            //////        end=i;
            //////        LangSections[i].stars=l.Quality;
            //////        LangSections[i].y=yy;
            //////        // LangSections[i].x=yy;
            //////        if (LangSections[i].ButtonApply!=null)
            //////            LangSections[i].ButtonApply.Position=new Vector2(startWindowPosX+/*48+*/DocumentSize-128, yy);
            //////        //   if (l.TwoLetterISOLanguageName=="en") LangSections[i].Info=new Text(BitmapFont.bitmapFont18.MaxSizeOfString(l.NativeName,DocumentSize-185-5),startWindowPosX+65,yy+1,BitmapFont.bitmapFont18);
            //////        //else
            //////        LangSections[i].Info=new Text(BitmapFont.bitmapFont18.MaxSizeOfString(dis/*l.NativeName+" ("+l.EnglishName+")"*/, DocumentSize-185-5-5), startWindowPosX+65, yy+1, BitmapFont.bitmapFont18);


            //////        //if (Global.WindowWidth>600) {

            //////        //   // LangSections[i].ChangePos(Global.WindowWidthHalf+DocumentSize/2-150, yy);
            //////        //} else {

            //////        //    LangSections[i].X=20;
            //////        //    LangSections[i].ChangePos(Global.WindowWidth-200, yy);
            //////        //}

            //////        //  settings[i].Draw(spriteBatch/*,new Vector2(20,yy),Global.WindowWidth-210*/);
            //////        //  settings[i].ChangePos(Global.WindowWidthHalf+DocumentSize/2-150,yy);
            //////    }
            //////    yy+=60;
            //////}

            //    //foreach (SettingItem si in settings)si.ChangePos(Global.WindowWidth-210,yy);
            //     yy=(int)(-scrollbar.scale*(1290+60+70+60+90+90+90+30-Global.WindowHeight/*+60+60+90+30*/))/*+70*/;/*+140+90*/;
            //   // #region Settings
            //    for (int i=0; i<settings.Count; i++){
            //        if (yy>-50 &&yy<Global.WindowHeight-160){
            //            if (start==-1)start=i;
            //            end=i;
            //            if (Global.WindowWidth>600){
            //                settings[i].X=Global.WindowWidthHalf-DocumentSize/2;
            //                settings[i].ChangePos(Global.WindowWidthHalf+DocumentSize/2-150,yy);
            //            } else {

            //                settings[i].X=20;
            //                settings[i].ChangePos(Global.WindowWidth-200,yy);
            //            }

            //          //  settings[i].Draw(spriteBatch/*,new Vector2(20,yy),Global.WindowWidth-210*/);
            //          //  settings[i].ChangePos(Global.WindowWidthHalf+DocumentSize/2-150,yy);
            //        }
            //        yy+=settings[i].Value;
            //    }
        }

        public override void Shutdown() {
            Rabcr.SaveSetting();
            //return false;
           // worldsTarget.Dispose();
        }

        public override void Update(GameTime gameTime) {
            if (Menu.newKeyboardState.IsKeyDown(Keys.Up)) smoothMouse-=2f;
            if (Menu.newKeyboardState.IsKeyDown(Keys.Down)) smoothMouse+=2f;

            if (Menu.newKeyboardState.IsKeyDown(Keys.PageUp)) smoothMouse-=5;
            if (Menu.newKeyboardState.IsKeyDown(Keys.PageDown)) smoothMouse+=5;

            if (Menu.newMouseState.ScrollWheelValue!=Menu.oldMouseState.ScrollWheelValue) {
                smoothMouse+=(Menu.oldMouseState.ScrollWheelValue-Menu.newMouseState.ScrollWheelValue)/3f;
            }

            if (smoothMouse!=0){
                if (Constants.AnimationsControls){
                scrollbar.Scroll(smoothMouse/1.5f);
                smoothMouse/=1.3f;
                if (smoothMouse>0){
                    if (smoothMouse<0.049f) smoothMouse=0;
                } else {
                    if (smoothMouse>-0.049f) smoothMouse=0;
                }
                }else{
                    scrollbar.Scroll(smoothMouse);
                    smoothMouse=0;
                }
            }

            buttonMenu.Update();

            if (buttonBadTranslation.Click)ClickWrongTranslation();

           // buttonBadTranslation.Update();

            List<LItem> langs;

            if (deepSelected!=0) langs =current.Languages;
            else langs=LanguageList;

            for (int i = start; i<langs.Count; i++) {
                LItem c=langs[i];
                if (c.Update()){
                    if (c.IsCategory){
                        current=(LCategory)c;
                        deepSelected++;
                        scrollbar.scale=0;
                        foreach (LItem x in current.Languages){
                            if (x.IsCategory){
                                ((LCategory)x).Prepare();
                            }
                        }

                        SetSubLangs();
                        Resize();
                        Move(null,null);
                    }else{
                        SetNewLanguage((LLanguage)c);
                    }
                }
            }

            // Go back
            if (deepSelected!=0){
                if (MouseInBackButton()) {
                    if (Menu.mouseDown){
                        needBackAlpha=1f;
                        clicked=true;
                    }else{
                        if (clicked){
                            deepSelected--;
                            scrollbar.scale=0;
                            if (deepSelected==0){
                                current=null;
                                clicked=false;

                                worldsTarget?.Dispose();
                                worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65);

                                  scrollbar=new Scrollbar(GetDataTexture(@"Buttons\Scrollbar\Top"), GetDataTexture(@"Buttons\Scrollbar\Center"), GetDataTexture(@"Buttons\Scrollbar\Bottom")) {

                PositionY=76
            };
            scrollbar.MoveScollBar+=Move;
                                Resize();
                            }else{
                                Resize();
                                  current=current.Parent;
                                clicked=false;
                                 foreach (LItem x in current.Languages){
                            if (x.IsCategory){
                                ((LCategory)x).Prepare();
                            }
                        }
                                SetSubLangs();
                            }



                          //  Resize();
                        }
                        needBackAlpha=0.9f;
                    }
                }else{
                    needBackAlpha=0.7f;
                }

                if (needBackAlpha!=backAlpha){
                    if (Constants.AnimationsControls){
                        float delta=needBackAlpha-backAlpha;
                        if (delta<0)delta=-delta;
                        if (delta<0.05f) backAlpha=needBackAlpha;

                        if (backAlpha<needBackAlpha){
                            backAlpha+=0.01f+delta/8f;
                        }else{
                            backAlpha-=0.01f+delta/8f;
                        }
                    }else{
                        backAlpha=needBackAlpha;
                    }
                    backbuttonColor=new Color(1f, 1f, 1f)*backAlpha;
                }
            }
            //}else{
            //    List<LItem> cc;
            //    if (deepSelected==0)cc=LanguageList;
            //    else cc=current.Languages;

            //     for (int i = start; /*i<=end &&*/ i<cc.Count; i++) {
            //        LItem c=cc[i];
            //        if (c.Update()){
            //            if (c.IsCategory){
            //                LCategory z=(LCategory)c;

            //              //  if (deepSelected!=0){

            //                //} else {
            //                  //  current=null;
            //                  //  deepSelected=0;
            //                   // if (c==null){
            //                      //  SetSubLangs();
            //                   // }else{
            //                       // if (end>current.Count)end=current.Count-1;
            //                   // }


            //           // }
            //          //  Console.WriteLine("selected: "+c.Name);

            //            }



            //        }
            //    }
            //}

         //   int i2=0;
            ////foreach (LItem s in LangSections){
            ////    if (s.ButtonApply!=null){
            ////    if (s.ButtonApply.Click){
            ////        loading=true;
            ////        bool jpl=Lang.IsJapanese;
            ////        Setting.CurrentLanguage=i2;

            ////        Lang.SetUp(false);

            ////        if (jpl!=Lang.IsJapanese){

            ////            GC.Collect();
            ////            GC.WaitForPendingFinalizers();
            ////            if (Lang.IsJapanese) {
            ////                BitmapFont.bitmapFont34=new BitmapFont(34, Properties.Resources.FontInfo_ja_34);
            ////                GC.Collect();
            ////                GC.WaitForPendingFinalizers();
            ////                BitmapFont.bitmapFont18=new BitmapFont(18, Properties.Resources.FontInfo_ja_18);
            ////            } else {
            ////                BitmapFont.bitmapFont34=new BitmapFont(34, Properties.Resources.FontInfo_wja_34);
            ////                GC.Collect();
            ////                GC.WaitForPendingFinalizers();
            ////                BitmapFont.bitmapFont18=new BitmapFont(18, Properties.Resources.FontInfo_wja_18);
            ////            }
            ////            GC.Collect();
            ////            GC.WaitForPendingFinalizers();
            ////        }
            ////        //SetTexts();

            ////        header=new Text(Lang.Texts[121],10, 10,BitmapFont.bitmapFont34);

            ////            buttonMenu=new Button(Textures.ButtonLongLeft, Lang.Texts[1]) {
            ////                Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-54)
            ////            };
            ////            //buttonWrongTranslation=new ButtonCenter(Textures.ButtonLong){
            ////            //     Text=Lang.Texts[297]
            ////            //};
            ////            //buttonWrongTranslation.Position=new Vector2(10, Global.WindowHeight-54);

            ////            //Resize();
            ////            yy=(int)(-scrollbar.scale*((LangSections.Length+1)*60-(Global.WindowHeight-75-40-65)-85/*+30*/))/*+70*/+15;/*+140+90*/
            ////          for (int i = 0; i<LangSections.Length; i++) {
            ////   // if (yy>-50&&yy<Global.WindowHeight-160+20) {
            ////      //  if (start==-1) start=i;
            ////       // Language l=Lang.Languages[i];
            ////        //end=i;
            ////      //  LangSections[i].y=yy;

            ////                LangSections[i].ButtonApply.Text=Lang.Texts[58];
            ////                LangSections[i].ButtonApply.Position=new Vector2(startWindowPosX+/*48+*/DocumentSize-128,yy);
            ////                   yy+=60;
            ////       // LangSections[i].ButtonApply.Position=new Vector2(startWindowPosX+/*48+*/DocumentSize-128,yy);
            ////        //if (l.TwoLetterISOLanguageName=="en") LangSections[i].Info=new Text(BitmapFont.bitmapFont18.MaxSizeOfStríng(l.NativeName,DocumentSize-185),startWindowPosX+65,yy+1,BitmapFont.bitmapFont18);
            ////        //else LangSections[i].Info=new Text(BitmapFont.bitmapFont18.MaxSizeOfStríng(l.NativeName+" ("+l.EnglishName+")",DocumentSize-185),startWindowPosX+65,yy+1,BitmapFont.bitmapFont18);
            ////        //if (Global.WindowWidth>600) {

            ////        //   // LangSections[i].ChangePos(Global.WindowWidthHalf+DocumentSize/2-150, yy);
            ////        //} else {

            ////        //    LangSections[i].X=20;
            ////        //    LangSections[i].ChangePos(Global.WindowWidth-200, yy);
            ////        //}

            ////        //  settings[i].Draw(spriteBatch/*,new Vector2(20,yy),Global.WindowWidth-210*/);
            ////        //  settings[i].ChangePos(Global.WindowWidthHalf+DocumentSize/2-150,yy);
            ////   // }
            ////   // yy+=60;
            ////}
            ////        Move(null,null);
            ////          loading=false;

            ////            break;
            ////    } }
            ////    i2++;
            ////}
           // Vector2 mouse=new Vector2(newMouseState.X,newMouseState.Y-75);



            base.Update(gameTime);
        }

        //void Scroll(float delta) {
        //    scrollbar.Scroll(delta);
        //    start=-1;
        //    //foreach (SettingItem si in settings)si.ChangePos(Global.WindowWidth-210,yy);
        //     yy=(int)(-scrollbar.scale*(1290+60+70+60+90+90+90+30-Global.WindowHeight+60+60+90+30))/*+70*/;/*+140+90*/;
        //   // #region Settings
        //    for (int i=0; i<settings.Count; i++){
        //        if (yy>-50 &&yy<Global.WindowHeight-160){
        //            if (start==-1)start=i;
        //            end=i;
        //          //  settings[i].Draw(spriteBatch/*,new Vector2(20,yy),Global.WindowWidth-210*/);
        //            settings[i].ChangePos(Global.WindowWidth-210,yy);
        //        }
        //        yy+=settings[i].Value;
        //    }
        //}

        void SetSubLangs(){

            goBack=new Text(Lang.Texts[364],Global.WindowWidthHalf-BitmapFont.bitmapFont18.MeasureTextSingleLineX(Lang.Texts[364])/2,10+65+10+2,BitmapFont.bitmapFont18);
            backbuttonColor=Color.White*0.7f;
            backTarget?.Dispose();
            worldsTarget?.Dispose();
            backTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,65);
            worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight/*-75*/-65-160/*+60*/);
            effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65/*-75*/-160/*+60*/));
            effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65/*-75*/-160/*+60*/))*5);

          ///  effectBlur2.Parameters["v"].SetValue(1f/(65));
            //effectBlur2.Parameters["pos"].SetValue((1f/(65))*5);

            scrollbar=new Scrollbar(GetDataTexture(@"Buttons\Scrollbar\Top"), GetDataTexture(@"Buttons\Scrollbar\Center"), GetDataTexture(@"Buttons\Scrollbar\Bottom")) {
                PositionY=160
            };
            scrollbar.MoveScollBar+=Move;
             scrollbar.maxheight=PageHeight();//mh
            scrollbar.scale=0;
            yy=15+5;
             buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-54);
            scrollbar.PositionX=Global.WindowWidth-35;
            scrollbar.Scroll(0);

         //   int i=0;
            foreach (LItem lll in current.Languages){
                if (!lll.IsCategory){
                    LLanguage l=(LLanguage)lll;

                Language ll=Lang.Languages[l.id];
                bool displayEnglishName=true;

                if (ll.EnglishName==ll.NativeName) displayEnglishName=false;
                else if (ll.Name=="eng" || ll.Name=="enu" || ll.Name=="ena" || ll.Name=="enc") displayEnglishName=false;
                else if (DocumentSize<450) displayEnglishName=false;
           //     System.Diagnostics.Debug.WriteLine(ll.EnglishName);
                string dis=ll.NativeName;


                if (BitmapFont.bitmapFont18.IsUjgur(dis)) {
                    char[] g = dis.ToCharArray();
                    dis="";
                    for (int i = g.Length-1; i>=0; i--) {
                        if (g[i]!='\u200E')
                            dis+=g[i]; //Stringbuilder
                    }
                }
                if (displayEnglishName) dis+= " ("+ll.EnglishName+")";
                //System.Diagnostics.Debug.WriteLine(dis);
                //if (ll.Flags!=null){
                //    if (ll.Flags.Length>0) {

                //        l.Flag=new List<Texture2D>();
                //        foreach (string s in ll.Flags) {
                //            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
                //            if (File.Exists(path+"\\"+Setting.StyleName+@"\Textures\Menu\Flags\"+s+".xnb")){
                //                  Texture2D tex=null;
                //            try {
                //               // tex=GetDataTexture(@"Menu\Flags\"+s);
                //               tex= Content.Load<Texture2D>(Setting.StyleName+@"/Textures/Menu\Flags\"+s);
                //            }catch{ }
                //                if (tex!=null)l.Flag.Add(tex);


                //            }

                //        }
                //    }
                //    if (l.Flag.Count>0){
                //        l.hasFlags=true;
                //        if (l.hasFlags) l.flagPos=new Vector2(xxx+10,yy+15);
                //        if (l.Flag.Count>1)l.multipleFlags=true;
                //    }
                //}


                //l.ButtonApply=new ButtonCenterLang(GetDataTexture("Buttons/Setting/Center")) {
                //    Text=Lang.Texts[58]
                //    }
                //};
                //try { l.Flag=GetDataTexture(@"Menu\Flags\"+ll.Name); } catch { }



               // LItems.Add(item);//;new LItem{
                                 // Flag=GetDataTexture(@"Menu\Flags\"+l.Name),
                l.recBack=new Rectangle(xxx,yy,DocumentSize,60);
                l.X=xxx;
                l.W=DocumentSize;
                l.Y=yy;
                l.Text=new Text(BitmapFont.bitmapFont18.MaxSizeOfString(dis,DocumentSize-128-5), xxx+60+10, yy+15, BitmapFont.bitmapFont18);
                //);

            //LangSections=LItems.ToArray();

//            l.Text=new Text(l.,,,BitmapFont.bitmapFont18);

               // if (yy<Global.WindowHeight-60)end=i;
                yy+=60;//i++;
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


            //if (DisplayedLangs){
            //    List<LItem> langs=current.Languages;

            //    for (int i = start; /*i<=end &&*/ i<langs.Count; i++) {
            //        LItem c=langs[i];
            //        if (c is LCategory) ((LCategory)c).Draw(spriteBatch);
            //        else c.Draw(spriteBatch);
            //        //c.Info.Draw(spriteBatch);
            //        //if (c.Flag!=null)spriteBatch.Draw(c.Flag, new Vector2(startWindowPosX,c.y),Color.White);
            //    }
            //}else{
                List<LItem> cc;
                if (deepSelected==0) cc=LanguageList;
                else cc=current.Languages;

                  for (int i = start; /*i<=end &&*/ i<cc.Count; i++) {
                        LItem c=cc[i];
                        //if (c is LCategory) ((LCategory)c).Draw(spriteBatch);
                        //else
                    c.Draw(spriteBatch);
                    }
              //  }


          ////////  yy=-(int)(scrollbar.scale*((LangSections.Length+1)*60-(Global.WindowHeight-75-40-65)));//(int)(-scrollbar.scale*((LangSections.Length+1)*60/*-Global.WindowHeight+60+60+90+30*/))/*+70*/;/*+140+90*/;
          //////  if (start!=-1) {
          //////  for (int i = start; i<=end&&i<LangSections.Length; i++) {
          //////          LItem it=LangSections[i];
          //////      // if (yy>-50 &&yy<Global.WindowHeight-160){
          //////      if (it.Flag!=null)spriteBatch.Draw(it.Flag, new /*Rectangle*/Vector2(startWindowPosX,it.y/*,48,29*/),Color.White);//(spriteBatch/*,new Vector2(20,yy),Global.WindowWidth-210*/);
          //////      if (!loading) { if (it.ButtonApply!=null)it.ButtonApply.ButtonDrawCorectionY(spriteBatch); }
          //////      if (!loading) {
          //////          if (DocumentSize>=300) it.Info.Draw(spriteBatch);
          //////      }
          //////      { float z=it.stars*3-(int)(it.stars*3);
          //////              //Console.WriteLine(it.stars);
          //////      int x=startWindowPosX-(int)(it.stars*3)*8/*4*/+24+(z>=.333f ? -4 : 0)+(z>=.666f ? -4 : 0);
          //////      for (int s=0; s<(int)(it.stars*3); s++) {
          //////              spriteBatch.Draw(star,new Vector2(x,it.y+31),Color.White);
          //////              x+=16;

          //////      }

          //////      if (z>=0.333f) {

          //////                  if (z>=0.666f) {
          //////               spriteBatch.Draw(star,new Vector2(x,it.y+31),new Rectangle(0,0,/*(int)(z*16)*/16,16), Color.White);
          //////              }else{
          //////                        spriteBatch.Draw(star,new Vector2(x,it.y+31),new Rectangle(0,0,8,16), Color.White);
          //////                      }

          //////                  }

          //////      }
          //////          //  }
          //////    }
          //////  //yy+=60/*settings[i].Value*/;

          //////  }
            // yy=(int)(-scrollbar.scale*(1290+60+70+60+90+90+90+30-Global.WindowHeight+60+60+90+30))/*+70*/;/*+140+90*/;
            //#region Settings
            //for (int i=start; i<=end && i<settings.Count; i++){
            //   // if (yy>-50 &&yy<Global.WindowHeight-160){
            //        settings[i].Draw(spriteBatch/*,new Vector2(20,yy),Global.WindowWidth-210*/);
            //  //  }
            //  //  yy+=settings[i].Value;
            //}

            //DrawHeader("Klávesnice","Keyboard");


            //if (IfDInt()) {  DrawItem("Pohyb doleva","Pohybování hráče vlevo","Move left","Move the player to the left");
            //    keyMoveLeft.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50));
            //}


            //if (IfDInt()) {  DrawItem("Pohyb doprava","Pohybování hráče doprava","Move right","Move the player to the right");
            //    keyMoveRight.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50));
            //}


            //if (IfDInt()) {   DrawItem("Skákání","Výskok hráče","Jump","Jump player");
            //    keyJump.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50));
            //}


            //if (IfDInt()) {   DrawItem("Běh","Zrychlení pohybu hráče","Run","Accelerate player movement");
            //    keyRun.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50));
            //}


            //if (IfDInt()) {  DrawItem("Inventář","Otevření inventáře","Run","Accelerate player movement");
            //    keyInventory.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50));
            //}


            //if (IfDInt()) {   DrawItem("Zpráva","Otevřít bublinu ke psaní","Message","Open bubble and write into some text");
            //    keyMessage.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50));
            //}


            //if (IfDInt()) {   DrawItem("Vyhození itemu","Vyhození z intentáře","Drop item","Drop item from inventory");
            //    keyDropDInt.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50));
            //}


            //if (IfDInt()) {   DrawItem("Menu","Ze hry do menu","Menu","Go from game to the menu");
            //    keyMenu.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50));
            //}


            //DrawHeader("Písmo","Font");


            //if (IfDInt()) {   DrawItem("Stínované písmo","Povolit stín, písmo se stane nepatrně tučnější","Shadow","Shadow and little bold");
            //    if (ONFontShadow.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50),newMouseState)) {
            //        Setting.TextShadow=ONFontShadow.ON;
            //    }
            //}

            //if (IfDInt()) {   DrawItem("Hladké písmo","Hezčí vyhlazenější písmo, ale pozor na výkon","Smooth","Smooth edges of fonts - performance!");
            //    if (ONFontBetter.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50),newMouseState)) {
            //        Setting.BetterFont=ONFontBetter.ON;
            //    }
            //}

            //if (IfDInt()) {    DrawItem("Jazyk","Pouze v menu, hra prakticky nemá texty, ale pozor na výkon","Language","It's language of the game.");
            //    SwitcherLanguage.Draw(spriteBatch, newMouseState, new Vector2(Global.WindowWidth-225, yy-50));
            //}


            //DrawHeader("Herních prvky","Game");


            //if (IfDInt()) {  DrawItem("Vyhlazování","Pokud je podporováno, dojde k vyhlazování okrajů a vnitřku textur","Menu","Smoothing edges and inside of textures");
            //    SwitcherSmoother.Draw(spriteBatch, newMouseState, new Vector2(Global.WindowWidth-225, yy-50));
            //}

            //if (IfDInt()) {   DrawItem("Animace","Lze povolit/zakázat některé nepotřebné animace","Animations","Switch by choice some unnecessary animations");
            //    if (ONAnimations.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50),newMouseState)) {
            //        Setting.Animations=ONAnimations.ON;
            //    }
            //}

            //if (IfDInt()) {   DrawItem("Přiblížení","Zvětší velikost všech bloků, hráče, rostlin, ...","Zoom","Make bigger your blocks");
            //    SwitcherZoom.Draw(spriteBatch, newMouseState, new Vector2(Global.WindowWidth-225, yy-50));
            //}

            //if (IfDInt()) {   DrawItem("Typ roztáhnutí","Roztáhne textur podle zvolení","Type scale","Scale textures by choice");
            //    SwitcherTypeOfScale.Draw(spriteBatch, newMouseState, new Vector2(Global.WindowWidth-225, yy-50));
            //}

            //if (IfDInt()) {  DrawItem("Okno","Velikost okna - pozor textury se roztáhnou","Window","Size of window - Attentation to scale of textures");
            //    SwitcherWindow.Draw(spriteBatch, newMouseState, new Vector2(Global.WindowWidth-225, yy-50));
            //}

            //if (IfDInt()) {   DrawItem("Fps","Zobrazí rychlost snímků za sekundu ve hře","Fps","Display frames per second in game");
            //    if (ONfps.Draw(spriteBatch,new Vector2(Global.WindowWidth-225, yy-50),newMouseState)) {
            //        Setting.Fps=ONfps.ON;
            //    }
            //}


            //DrawHeader("Hlasitost","Volume");

            //DrawItem("Hlasitost písní","hlasitost písniček hrající na pozadí","Music","songs volume");
            //if (IfDInt()) {
            //    if (volumeSong.Draw(spriteBatch,Global.WindowWidth-225-10, yy-50,newMouseState,oldMouseState)) {
            //        Setting.VolumeMusic=volumeSong.Value;
            //    MediaPlayer.Volume= Setting.VolumeMusic;
            //    }
            //}
            //DrawItem("Hlasitost efektů","hlasitost zvuků, způsobené hráčem","Effects","game effects volume");
            //if (IfDInt()) {
            //    if (volumeEffects.Draw(spriteBatch,Global.WindowWidth-225-10, yy-50,newMouseState,oldMouseState)) {
            //        Setting.VolumeEffects=volumeEffects.Value;
            //    }
            //}

            //DrawHeader("Přechody v menu", "Transitions in the menu");
            //DrawItem("Rychlost přechodu","Možnost změny rychlosti prostředí","Type of changing","Change changing in the menu");
            //if (IfDInt()) {
            //    SwitherSlideChangeTime.Draw(spriteBatch, newMouseState, new Vector2(Global.WindowWidth-225, yy-50));
            //}

            //#endregion

            spriteBatch.End();
            Graphics.SetRenderTarget(null);
            //if (DisplayedLangs){
            //        Graphics.SetRenderTarget(backTarget);
            //    Graphics.Clear(/*Color.Transparent*/backbuttonColor*0.75f);
            //    spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend);
            //        goBack.Draw(spriteBatch);
            //    spriteBatch.End();
            //    Graphics.SetRenderTarget(null);
            //}
        }

        public override void Draw(GameTime gameTime, float a) {
           // bool mouse= newMouseState.LeftButton==ButtonState.Pressed;
            effectBlur.Parameters["alpha"].SetValue(a);
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,effectBlur);
            effectBlur.Techniques[0].Passes[0].Apply();

            if (deepSelected!=0){
                spriteBatch.Draw(worldsTarget, new Vector2(0, 160), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight/*-75*/-65/*-2*/-160/*+60*/), Color.White);
                spriteBatch.End();

                spriteBatch.Begin();
                for (int i=0; i<5; i++){
                    spriteBatch.Draw(Rabcr.Pixel,new Rectangle(0,76+i,Global.WindowWidth,1),backbuttonColor*(i/5f));
                }
                spriteBatch.Draw(Rabcr.Pixel,new Rectangle(0,76+5,Global.WindowWidth,60-5),backbuttonColor);
                for (int i=5; i>-1; i--){
                    spriteBatch.Draw(Rabcr.Pixel,new Rectangle(0,76+i+60,Global.WindowWidth,1),backbuttonColor*((5-i)/5f));
                }

                goBack.Draw(spriteBatch);
            }else{
                 spriteBatch.Draw(worldsTarget, new Vector2(0, 76), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight-75-65-2), Color.White);
            }

            spriteBatch.End();



            spriteBatch.Begin();
            //DrawTextHeader(10, 10,Lang.Texts[8],a);
            header.Draw(spriteBatch,Color.Black*a);

           // if (!loading) {
               //  if (Global.WindowWidth>700) buttonWrongTranslation.ButtonDraw(spriteBatch,a);
               buttonMenu.ButtonDraw(spriteBatch, /*mouse,*/a/*, new Vector2(newMouseState.X,newMouseState.Y)*/);
            buttonBadTranslation.ButtonDraw(spriteBatch, /*mouse,*/a/*, new Vector2(newMouseState.X,newMouseState.Y)*/);
           // }
            scrollbar.ButtonDraw(spriteBatch,/*mouse,*/a/*,new Vector2(newMouseState.X,newMouseState.Y),new Vector2(Global.WindowWidth-35,76)*/);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        int PageHeight(){
            if (deepSelected!=0){
                return current.Languages.Count*60+60+10;
            }else{
                return LanguageList.Count*60+10/*+60*/;
                //else return current.Languages.Count*60/*+60*/;
            }
        }

        public override void Resize() {
           // SetPage();
             DocumentSize=(int)(Global.WindowWidth*0.6f);
            if (DocumentSize<300) DocumentSize=200;
            if (DocumentSize>550) DocumentSize=550;
            xxx=Global.WindowWidthHalf-DocumentSize/2;
            scrollbar.Scroll(0);
         //   Move(null,new EventArgs());


            if (deepSelected!=0){
                 goBack.ChangePosition(Global.WindowWidthHalf-BitmapFont.bitmapFont18.MeasureTextSingleLineX("< Zpět na kategorie jazyků")/2,10+75+5+2);
                backTarget?.Dispose();
                backTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,50);
               if (Global.WindowHeight/*-75*/-65-160>0) {
                    worldsTarget?.Dispose();
                    worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight/*-75*/-65-160);
                }
               effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75-160+60));
                effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75-160+60))*5);
                scrollbar.height=Global.WindowHeight-75-65-2-100+15/*+8*/;

                //effectBlur2.Parameters["v"].SetValue(1f/(65));
               // effectBlur2.Parameters["pos"].SetValue((1f/(65))*5);
            }else{
                worldsTarget?.Dispose();
                worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65);
                effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
                effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);
                scrollbar.height=Global.WindowHeight-75-65-2/*-100*/;
            }



        //    scrollbar.scale=0;
            scrollbar.maxheight=/*Mh*/PageHeight();//LangSections.Length*60-Global.WindowHeight/*+60+60+90+30*/;

            buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-54);
            buttonBadTranslation.Position=new Vector2(0, Global.WindowHeight-54);
            //buttonWrongTranslation.Position=new Vector2(10, Global.WindowHeight-54);
            scrollbar.PositionX=Global.WindowWidth-35;

            //set start and end
             if ((deepSelected!=0 && current.Languages!=null)){
               // int len=(int)(-scrollbar.scale*(pageHeight()-(Global.WindowHeight-75-40-65)-85/*+30*/))/*+70*/+15;/*+140+90*/
                List<LItem> langs=current.Languages;
                foreach (LItem l in langs){
                    l.SetPos(xxx,l.Y,DocumentSize);

                    }
               // end=start+(Global.WindowHeight-75-40-65+60)/60;

            }else{
                // for (int i = start; i<=end; i++) {
                //    //LCategory c=Categories[i];
                //    //c.Update();
                //    end=start+(Global.WindowHeight-75-40-65+60)/60;
                //}
            }
        }

        bool MouseInBackButton() {
            if (Menu.mousePosX<0) return false;
            if (Menu.mousePosY<76) return false;
            if (Menu.mousePosX>Global.WindowWidth) return false;
            if (Menu.mousePosY>76+65) return false;
            return true;
        }

       // void SetPage(){

       //     DocumentSize=(int)(Global.WindowWidth*0.6f);
       //     if (DocumentSize<300) DocumentSize=200;
       //     if (DocumentSize>550) DocumentSize=550;

       ////     Console.WriteLine(DocumentSize);
       //     List<LItem> LItems=new List<LItem>();
       //     for (int i=0; i<Lang.Languages.Length; i++){
       //         Language l= Lang.Languages[i];
       //       //  bool displayEnglishName=true;
       //        // if (l.TwoLetterISOLanguageName=="en") displayEnglishName=false;
       //        // if (l.EnglishName==l.NativeName) displayEnglishName=false;
       //        // if (DocumentSize<450) displayEnglishName=false;

       //        // string dis=l.NativeName;
       //        // if (displayEnglishName) dis+= " ("+l.EnglishName+")";

       //         LItem item=new LItem{
       //           ButtonApply=new ButtonCenterLang(GetDataTexture("Buttons/Setting/Center")){
       //                 Text=Lang.Texts[58]
       //           } };
       //         try{item.Flag=GetDataTexture(@"Menu\Flags\"+l.Name); }catch{ }
       //         LItems.Add(item);//;new LItem{
       //            // Flag=GetDataTexture(@"Menu\Flags\"+l.Name),


       //            // Info=new Text(BitmapFont.bitmapFont18.MaxSizeOfString(dis/*l.NativeName+(displayEnglishName ? " ("+l.EnglishName+")": "")*/,DocumentSize-128-5), 0, 0, BitmapFont.bitmapFont18)
       //         //);
       //     }
       //      LangSections=LItems.ToArray();

       // }

        //void DrawHeader(string cz, string en) {
        //    DrawTextShadowMaxMedium(35, yy+30, Setting.czechLanguage ? cz: en);
        //    yy+=60;
        //}

        //void DrawItem(string czText, string czDeepText,string enText, string enDeepText) {
        //    if (Setting.czechLanguage) {
        //        DrawTextShadowMinMedium(25, yy,czText+":",1);
        //        DrawTextShadowMinSmall(25, yy+30, "("+czDeepText+")",1);
        //    } else {
        //        DrawTextShadowMinMedium(25, yy,enText+":",1);
        //        DrawTextShadowMinSmall(25, yy+30, "("+enDeepText+")",1);
        //    }
        //}

//        void SetTexts() {

//            //SpriteFont tmp;
//            //if (Setting.BetterFont)tmp= Fonts.Big; else tmp=Fonts.Medium;

//            //settings=new List<SettingItem>();

//            //int zoom=4;
//            //switch (Setting.Zoom){
//            //    case 1: zoom=0; break;
//            //    case 1.25f: zoom=1; break;
//            //    case 1.5f:zoom=2; break;
//            //    case 1.75f: zoom=3; break;
//            //    case 2:zoom=4; break;
//            //    case 2.5f: zoom=5; break;
//            //    case 3: zoom=6; break;
//            //    case 4: zoom=7; break;
//            //    case 5: zoom=8; break;
//            //}

//            // Postavička
//         //   buttonMenu.Text=Lang.Texts[26];
//            //settings.Add(new SettingHeader(Lang.Texts[82]));
//            //settings.Add(new SettingSwitcher(tex,Lang.Texts[83],/*Lang.Texts[84],*/new string[]{Lang.Texts[85],Lang.Texts[88]},(int)Setting.sex));
//            //settings.Add(new SettingOnOff(tex,Lang.Texts[89],/*Lang.Texts[90],*/Setting.MaturePlayer));
//            //settings.Add(new SettingSwitcher(tex,Lang.Texts[91],/*Lang.Texts[92],*/new string[]{Lang.Texts[93],Lang.Texts[97],Lang.Texts[95],Lang.Texts[96],Lang.Texts[97]},(int)Setting.hairColor));

//            //// Klávesnice
//            //settings.Add(new SettingHeader(Lang.Texts[98]));
//            //settings.Add(new SettingKey(tex, Lang.Texts[100],/*Lang.Texts[101],*/Setting.KeyLeft));
//            //settings.Add(new SettingKey(tex, Lang.Texts[102],/*Lang.Texts[103],*/Setting.KeyRight));
//            //settings.Add(new SettingKey(tex, Lang.Texts[104],/*Lang.Texts[105],*/Setting.KeyJump));
//            //settings.Add(new SettingKey(tex, Lang.Texts[106],/*Lang.Texts[107],*/Setting.KeyRun));
//            //settings.Add(new SettingKey(tex, Lang.Texts[108],/*Lang.Texts[109],*/Setting.KeyInventory));
//            //settings.Add(new SettingKey(tex, Lang.Texts[110],/*Lang.Texts[111],*/Setting.KeyMessage));
//            //settings.Add(new SettingKey(tex, Lang.Texts[112],/*Lang.Texts[113],*/Setting.KeyDropItem));
//            //settings.Add(new SettingKey(tex, Lang.Texts[114],/*Lang.Texts[115],*/Setting.KeyExit));

//            // Písmo
//           // settings.Add(new SettingHeader(Lang.Texts[116]));
//            //settings.Add(new SettingOnOff(tex, Lang.Texts[117],/*Lang.Texts[118],*/Constants.Shadow));
//            //settings.Add(new SettingOnOff(tex, Lang.Texts[119],/*Lang.Texts[120],*/Setting.BetterFont));
////            settings.Add(new SettingButton(tex,Lang.Texts[121]/*,Lang.Texts[122],nullfrom l in Lang.Laguages select l.EnglishName,Setting.CurrentLanguage*/));

//            // Herních prvky
//            //settings.Add(new SettingHeader(Lang.Texts[123]));
//            //settings.Add(new SettingOnOff(tex, Lang.Texts[124], /*Lang.Texts[125],*/ Constants.Animations));
//            //settings.Add(new SettingSwitcher(tex, Lang.Texts[126], /*Lang.Texts[127],*/ new string[]{Lang.Texts[272],Lang.Texts[273],Lang.Texts[274],Lang.Texts[275],Lang.Texts[276],Lang.Texts[277],Lang.Texts[278],Lang.Texts[279],Lang.Texts[280]},zoom));
//            //settings.Add(new SettingSwitcher(tex, Lang.Texts[128], /*Lang.Texts[129],*/new string[]{Lang.Texts[148],Lang.Texts[149],Lang.Texts[150]},(int)Setting.currentScale));
//            //settings.Add(new SettingSwitcher(tex, Lang.Texts[130], /*Lang.Texts[131],*/new string[]{Lang.Texts[151],Lang.Texts[152],Lang.Texts[153]},(int)Setting.currentWindow));
//            //settings.Add(new SettingOnOff(tex, Lang.Texts[132],/*Lang.Texts[133],*/Setting.Fps));

//            //// Hlasitost
//            //settings.Add(new SettingHeader(Lang.Texts[134]));
//            //settings.Add(new SettingMovemer(Lang.Texts[135],/*Lang.Texts[136],*/line,movemer){ Scale=Setting.VolumeMusic});
//            //settings.Add(new SettingMovemer(Lang.Texts[137],/*Lang.Texts[138],*/line,movemer){ Scale=Setting.VolumeEffects});

//            //// Menu
//            //settings.Add(new SettingHeader(Lang.Texts[114]));
//            //settings.Add(new SettingSwitcher(tex,Lang.Texts[139],/*Lang.Texts[140],*/ new string[] { Lang.Texts[148], Lang.Texts[154], Lang.Texts[155],Lang.Texts[156]}, Setting.slideChangeTime==0 ? 0 : (Setting.slideChangeTime==0.1f ? 1 : (Setting.slideChangeTime==0.05f ? 2 : (Setting.slideChangeTime==0.01f ? 3 : 0)))));
//            //settings.Add(new SettingOnOff(tex, Lang.Texts[141],/*Lang.Texts[142],*/Setting.Background));

//            //// Hráč
//            //if (!Global.OnlineAccount) {
//            //    settings.Add(new SettingHeader(Lang.Texts[99]));
//            //    settings.Add(new SettingOnOff(tex,Lang.Texts[143],/*Lang.Texts[144],*/!Global.YoungPlayer));
//            //} else {
//            //    settings.Add(new SettingHeader(Lang.Texts[145]+" "+(Global.YoungPlayer ? Lang.Texts[146]: Lang.Texts[147])));
//            //}

//            Move(null,new EventArgs());

//            //if (Setting.czechLanguage) {
//            //   ///* "Zpět"*/;
//            //  //  settings.Add(new SettingHeader(/*tmp,*/"Postavička"));
//            //    //settings.Add(new SettingSwitcher(tex/*,Fonts.Small,Fonts.Medium,Fonts.Big*/,"Pohlaví","Podle pohlaví bude vygenerováno oblečení",new string[]{"Muž","Žena"},(int)Setting.sex));
//            //    settings.Add(new SettingOnOff(tex/*,Fonts.Small,Fonts.Medium,Fonts.Big*/,"Hrát za dospělého","Huňatá srst",Setting.MaturePlayer));
//            //    settings.Add(new SettingSwitcher(tex/*,Fonts.Small,Fonts.Medium,Fonts.Big*/,"Barva vlasů","Není potřeba si kupovat barvu na vlavy",new string[]{"Bílé","Blond","Zrzaté","Hnědé","Černé"},(int)Setting.hairColor));

//            //    settings.Add(new SettingHeader(/*tmp,*/"Klávesnice"));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Pohyb doleva","Pohybování hráče vlevo",Setting.KeyLeft));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Pohyb doprava","Pohybování hráče doprava",Setting.KeyRight));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Skákání","Výskok hráče",Setting.KeyJump));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Běh","Zrychlení pohybu hráče",Setting.KeyRun));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Inventář","Otevření inventáře",Setting.KeyInventory));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Zpráva","Otevřít bublinu ke psaní",Setting.KeyMessage));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Vyhození itemu","Vyhození z intentáře",Setting.KeyDropItem));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Menu","Ze hry do menu",Setting.KeyExit));

//            //    settings.Add(new SettingHeader(/*tmp,*/"Písmo"));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Stínované písmo","Povolit stín, písmo se stane nepatrně tučnější",Constants.Shadow));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Hladké písmo","Hezčí vyhlazenější písmo, ale pozor na výkon",Setting.BetterFont));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Jazyk","Pouze v menu, hra prakticky nemá texty",Lang.Laguages,Setting.CurrentLanguage));

//            //    settings.Add(new SettingHeader(/*tmp,*/"Herních prvky"));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Animace","V případě zakázaní se nemusí vypnou všechny animace",Constants.Animations));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Přiblížení","Zvětší velikost všech bloků, hráče, rostlin, ...",new string[]{"1×","1,25×","1,5×","1,75×","2×","2,5×","3×","4×","5×"},zoom));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Typ roztáhnutí","Roztáhne textur podle zvolení",new string[]{"Bez","Dle poměru","Vyplnit"},(int)Setting.currentScale));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Obrazovka","Velikost okna, přepne se po startu",new string[]{"Okenní","Maxi","Fullscreen" },(int)Setting.currentWindow));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Fps","Zobrazí rychlost snímků za sekundu ve hře",Setting.Fps));

//            //    settings.Add(new SettingHeader(/*tmp,*/"Hlasitost"));
//            //    settings.Add(new SettingMovemer(/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Hlasitost písní","hlasitost písniček hrající na pozadí",line,movemer){ Scale=Setting.VolumeMusic});
//            //    settings.Add(new SettingMovemer(/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Hlasitost efektů","hlasitost zvuků, způsobené hráčem",line,movemer){ Scale=Setting.VolumeEffects});

//            //    settings.Add(new SettingHeader(/*tmp,*/"Menu"));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Rychlost přechodu","Možnost změny rychlosti prostředí", new string[] { "Bez", "Rychlé", "Střední","Pomalé"}, Setting.slideChangeTime==0 ? 0 : (Setting.slideChangeTime==0.1f ? 1 : (Setting.slideChangeTime==0.05f ? 2 : (Setting.slideChangeTime==0.01f ? 3 : 0)))));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Pozadí","Může u někoho zpomalovat hru",Setting.Background));

//            //    if (!Global.OnlineAccount) {
//            //        settings.Add(new SettingHeader(/*tmp,*/"Hráč"));
//            //        settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"18+","Dosáhl jsem 18 let (jsem zletilý)",!Global.YoungPlayer));
//            //    } else {
//            //        settings.Add(new SettingHeader(/*tmp,*/"Dle Vášeho GG účtu "+(Global.YoungPlayer ? "jste nezletilý": "jste zletilý")));
//            //    }
//            //}else{
//            //   // buttonMenu.Text="Back";
//            //   // settings.Add(new SettingHeader(/*tmp,*/"Player"));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Sex","Depending on sex will be generated clothes",new string[]{"Women","Men"},(int)Setting.sex));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Mature player","If you donť have 18, it have to be off",Setting.MaturePlayer));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Hair color","You donť have to buy hair color",new string[]{"White","Blond","Red","Brown","Black"},(int)Setting.hairColor));

//            //    settings.Add(new SettingHeader(/*tmp,*/"Keyboard"));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Move left","Move the player to the left",Setting.KeyLeft));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Move right","Move the player to the right",Setting.KeyRight));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Jump","Player's jump",Setting.KeyJump));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Run","Accelerate player movement",Setting.KeyRun));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Inventory","Open inventory",Setting.KeyInventory));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Message","Open bubble and write some text",Setting.KeyMessage));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Drop item","Drop item from inventory",Setting.KeyDropItem));
//            //    settings.Add(new SettingKey(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Menu","Go from game to the menu",Setting.KeyExit));

//            //    settings.Add(new SettingHeader(/*tmp,*/"Font"));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Shadow","Shadow and little bold",Constants.Shadow));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Smooth","Smooth edges of fonts - performance!",Setting.BetterFont));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Language","It's language of the game.",Lang.Laguages, Setting.CurrentLanguage/*new string[]{ "Čestina","English"},Setting.czechLanguage ? 0 :1)*/));

//            //    settings.Add(new SettingHeader(/*tmp,*/"Game"));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Animations","Switch by choice some unnecessary animations",Constants.Animations));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Zoom","Make bigger your blocks",new string[]{"1×","1,25×","1,5×","1,75×","2×","2,5×","3×","4×","5×"},zoom));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Type scale","Scale textures by choice",new string[]{"Without","Proportion","Fill"},(int)Setting.currentScale));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Window","Size of window - Attentation to scale of textures",new string[]{"Window","Maximalized","FullScreen"},(int)Setting.currentWindow));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Fps","Display frames per second in game",Setting.Fps));

//            //    settings.Add(new SettingHeader(/*tmp,*/"Hlasitost"));
//            //    settings.Add(new SettingMovemer(/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Music","Songs volume",line,movemer));
//            //    settings.Add(new SettingMovemer(/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Effects","game effects volume",line,movemer));

//            //    settings.Add(new SettingHeader(/*tmp,*/"Menu"));
//            //    settings.Add(new SettingSwitcher(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Type of changing","Change changing in the menu", new string[] { "Without", "Fast", "Medium","Slow"},Setting.slideChangeTime==0 ? 0 : (Setting.slideChangeTime==0.1f ? 1 : (Setting.slideChangeTime==0.05f ? 2 : (Setting.slideChangeTime==0.01f ? 3 : 0)))));
//            //    settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"Background","Display background",Setting.Background));

//            //    if (!Global.OnlineAccount) {
//            //        settings.Add(new SettingHeader(/*tmp,*/"Player"));
//            //        settings.Add(new SettingOnOff(tex,/*Fonts.Small,Fonts.Medium,Fonts.Big,*/"18+","I've had 18 years",!Global.YoungPlayer));
//            //    } else {
//            //        settings.Add(new SettingHeader(/*tmp,*/"According GG account "+(Global.YoungPlayer ? "you havent 18": "you had 18")));
//            //    }
//            //}
//            //System.Console.WriteLine();
//        }

        //void SetWindow() {
        //    if (Setting.currentWindow==Setting.Window.Fullscreen) {
        //        System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
        //        System.Windows.Forms.Screen myScreen = System.Windows.Forms.Screen.AllScreens[0];

        //        gameForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
        //        GraphicsManager.PreferredBackBufferWidth = myScreen.Bounds.Width;
        //        GraphicsManager.PreferredBackBufferHeight = myScreen.Bounds.Height;
        //        GraphicsManager.ApplyChanges(); // Not necessary, however this is a method in my code


        //        gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

        //        gameForm.Left = myScreen.WorkingArea.Left;
        //        gameForm.Top = myScreen.WorkingArea.Top;
        //    }
        //    if (Setting.currentWindow==Setting.Window.Maxi) {
        //        System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
        //        if (gameForm.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None) {
        //             gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;


        //            gameForm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(
        //            System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe");
        //        }

        //        gameForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        //    }
        //    if (Setting.currentWindow==Setting.Window.Normal) {
        //        System.Windows.Forms.Form gameForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Game.Window.Handle);
        //        if (gameForm.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None) {
        //             gameForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;


        //            gameForm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(
        //            System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe");
        //        }

        //        GraphicsManager.PreferredBackBufferWidth = 848;
        //        GraphicsManager.PreferredBackBufferHeight = 560;
        //        GraphicsManager.ApplyChanges();
        //    }
        //}
    }
}