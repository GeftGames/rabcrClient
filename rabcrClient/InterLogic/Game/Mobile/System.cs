using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace rabcrClient.Mobile {
    class System {
        public App[] apps;
        public int selectedApp=-1;
        public ContentManager Content;
        Texture2D TextureDown;
        SpriteFont font;
        //public int mouse;
        public bool mouseDown;
        bool lastMouse;
        int X, Y, W, H;
        int downButtonValue;
        bool click;

        public void Init(){
            TextureDown=GetDataTexture("Mobile/MobileDown");
            font=GetDataFont("Medium");
            apps=new App[] {
                new App(){
                    Name="WikiItem",
                    NameContent="Wiki",
                     data=new DataWiki(),
                    windows=new Window[] {
                        new Window {
                            IsScrollBar=true,
                            //ShowBackground=false,
                            screen=new ScreenWikiItemsList(),
                        },
                        new Window {
                            IsScrollBar=true,
                         //   ShowBackground=false,
                            backIndex=0,
                            ShowGoBack=true,
                            screen=new ScreenWikiItemDetails(),
                        }
                    }
                },
                new App(){
                    Name="WikiBlock",
                    NameContent="Wiki",
                     data=new DataWiki(),
                    windows=new Window[] {
                        new Window {
                            IsScrollBar=true,
                            //ShowBackground=false,
                            screen=new ScreenWikiBlocksList(),
                        },
                        new Window {
                            IsScrollBar=true,
                         //   ShowBackground=false,
                            backIndex=0,
                            ShowGoBack=true,
                            screen=new ScreenWikiBlockDetails(),
                        }
                    }
                },
                //new App(){
                //    Name=Setting.czechLanguage ? "Foťák":"Camera",
                //    NameContent="Camera",
                //    windows=new Window[] {
                //        new Window {
                //            IsScrollBar=false,
                //         //   ShowBackground=false,
                //            screen=new ScreenCamera(),
                //        }
                //    }
                //},
                new App(){
                    Name=Lang.Texts[78]/* Setting.czechLanguage ? "Poznámky":"Notes"*/,
                    NameContent="Notes",
                    windows=new Window[] {
                        new Window {
                            IsScrollBar=false,
                           // ShowBackground=false,
                            screen=new ScreenNotes(),
                        }
                    }
                },
                //new App(){
                //    Name=Setting.czechLanguage ? "Možnosti": "Settings",
                //    NameContent="Settings",
                //    windows=new Window[] {
                //        new Window {
                //            IsScrollBar=false,
                //           // ShowBackground=false,
                //            screen=new ScreenSettings(),
                //        }
                //    }
                //},
                new App(){
                    Name="Info",
                    NameContent="Info",
                    windows=new Window[] {
                        new Window {
                            IsScrollBar=false,
                         //   ShowBackground=false,
                            screen=new ScreenInfo(),
                        }
                    }
                },
            };
            foreach (App app in apps){
                app.Content=Content;
                app.NameMeasurement=font.MeasureString(app.Name);
                app.TetureApp=GetDataTexture("Mobile/Icons/"+app.NameContent);
            }
        }

        public void Update() {
            if (!mouseDown && lastMouse) click=true;
            if (selectedApp==-1) {
                //for (int i=0; i<apps.Length; i++){
                //    App app=apps[selectedApp];
                //    if (In(mouse,X,Y+i*70,64,64)) {
                //        if (mouseDown){
                //            app.MouseValue=150;
                //        }else{
                //           //  if (lastMouse) GoToApp(app,selectedApp);
                //             app.MouseValue=200;
                //        }
                //    } else app.MouseValue=255;
                //}
            } else {
                App app=apps[selectedApp];

                //app.mouse=mouse;
                app.mouseDown=mouseDown;

                app.Update();
            }

            if (In(/*mouse,*/ X, Y+H-32, W, 32)) {
                if (mouseDown) {
                    downButtonValue=75;
                } else {
                    downButtonValue=100;
                }
                if (click) {
                    selectedApp=-1;
                }
            } else downButtonValue=50;


            lastMouse=mouseDown;
        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h) {
            X=x;
            Y=y;
            W=w;
            H=h;

            if (selectedApp==-1) {
                int iconW=0;
                int ih=y+10;
                for (int i=0; i<apps.Length; i++){
                    int a=0;

                    App app=apps[i];
                    if (In(/*mouse,*/iconW*100+x-5+1-5+5,ih,74+10,90)) {
                        if (mouseDown) a=75;
                        else a=50;
                        if (click){
                            GoToApp(app,i);
                        }
                    }

                    sb.Draw(Rabcr.Pixel,new Rectangle(iconW*100+x-5+10-5+5,ih,74+10,95),new Color(a,a,a,a));
                    sb.Draw(app.TetureApp, new Vector2(iconW*100+x+10+5, ih), Color.White);
                    sb.DrawString(font,app.Name,new Vector2(iconW*100+x+32-app.NameMeasurement.X/2f+10+5, ih+65),Color.White);

                    iconW++;
                    if (iconW>2){
                        iconW=0;
                        ih+=90;
                    }
                }

            } else {
                apps[selectedApp].Draw(sb, X, Y, W, H-32);
            }

            sb.Draw(Rabcr.Pixel,new Rectangle(x,y+H-32,W,32), new Color(downButtonValue,downButtonValue,downButtonValue));
            sb.Draw(TextureDown, new Vector2(x+W/2-16, y+h-(32+24)/2f),Color.White);
            click=false;
        }

        bool In(/*DInt m, */int x, int y, int w, int h) {
            if (MousePos.mouseRealPosX < x)   return false;
            if (MousePos.mouseRealPosY < y)   return false;
            if (MousePos.mouseRealPosX > x+w) return false;
            if (MousePos.mouseRealPosY > y+h) return false;
            return true;
        }

        void GoToApp(App app, int ind) {
            app.Content=Content;
            app.selectedWindow=0;
            app.Init();
            selectedApp=ind;
            lastMouse=false;
            click=false;
            mouseDown=false;
        }

        Texture2D GetDataTexture(string path) {
            return Content.Load<Texture2D>(Setting.StyleName+"/Textures/"+path);
        }

        SpriteFont GetDataFont(string path) {
            return Content.Load<SpriteFont>(Setting.StyleName+"/Fonts/"+path);
        }
    }

    class App {
        public Texture2D TetureApp;
        //public Color ColorBackground;
        public Window[] windows;
        public int selectedWindow;
        public ContentManager Content;
        public DInt mouse;
        public bool mouseDown;
        public string Name,NameContent;
        public Vector2 NameMeasurement;
        //public int MouseValue;
        public InterAppData data;

        public virtual void Init() {
           mouseDown=false;
            windows[selectedWindow].Content=Content;
            windows[selectedWindow].thisWindow=selectedWindow;
            windows[selectedWindow].data=data;
            windows[selectedWindow].Init();
        }

        public void Update() {
            windows[selectedWindow].mouse=mouse;
            windows[selectedWindow].mouseDown=mouseDown;
            windows[selectedWindow].Update();
            if (windows[selectedWindow].switchWindow){
                if (windows[selectedWindow].thisWindow!=selectedWindow){
                    windows[selectedWindow].switchWindow=false;

                    selectedWindow=windows[selectedWindow].thisWindow;

                    windows[selectedWindow].switchWindow=false;
                    windows[selectedWindow].thisWindow=selectedWindow;
                    windows[selectedWindow].Content=Content;
                    windows[selectedWindow].data=data;
                    windows[selectedWindow].Init();
                }
            }
        }

        public void Draw(SpriteBatch sb, int X, int Y, int W, int H) {
            windows[selectedWindow].Draw(sb, X, Y, W, H);
        }

        //public Texture2D GetDataTexture(string path) {
        //    return Content.Load<Texture2D>(Setting.StyleName+"/Textures/"+path);
        //}

        //SpriteFont GetDataFont(string path) {
        //    return Content.Load<SpriteFont>(Setting.StyleName+"/Fonts/"+path);
        //}
    }

    class Window {
        //public int Height;
        public bool IsScrollBar;
        public bool ShowGoBack;
       // public Texture2D TextureBackground;
       // public bool ShowBackground;
        public int backIndex;
        public ContentManager Content;
        public DrawingScreen screen;
       // public App thisApp;
        public DInt mouse;
        public bool mouseDown;
        Texture2D TextureGoBack;
        SpriteFont font;
        GameScrollbar scrollbar;
        public int thisWindow;
        public bool switchWindow=false;
        bool lastMouse;
        public InterAppData data;

        public virtual void Init() {
            screen.Content=Content;
            screen.thisWindow=thisWindow;
            screen.data=data;
            lastMouse=false;
            mouseDown=false;
            screen.Init();

            if (ShowGoBack) {
                TextureGoBack=GetDataTexture("Mobile/GoBack");
                font=GetDataFont("Medium");
            }

            if (IsScrollBar) scrollbar=new GameScrollbar(
                GetDataTexture("Buttons/Scrollbar/Top"),
                GetDataTexture("Buttons/Scrollbar/Center"),
                GetDataTexture("Buttons/Scrollbar/Bottom")
            ){
                height=398,
              //  maxheight=1000
            };
        }

        public virtual void Update() {
            if (IsScrollBar) {
                scrollbar.maxheight=screen.PageLenght;
                screen.ScrollbarValue=scrollbar.scale;
            }
            screen.mouse=mouse;
            screen.mouseDown=mouseDown;

            if (thisWindow!=screen.thisWindow){
                if (!switchWindow){
                    thisWindow=screen.thisWindow;
                    switchWindow=true;
                }
            }

            screen.Update();
        }

        public virtual void Draw(SpriteBatch sb, int X, int Y, int W, int H) {
            if (ShowGoBack) {
                float a=0.25f;
                if (In(mouse,X,Y,W,32)){
                    if (mouseDown)a=.45f;
                    else{
                        if (lastMouse){
                            if (!switchWindow){
                                thisWindow=backIndex;
                                switchWindow=true;
                            }
                        }
                        a=.33f;
                    }
                }
                sb.Draw(Rabcr.Pixel, new Rectangle(X,Y,W,32), Color.White*a);
                sb.Draw(TextureGoBack, new Vector2(X,Y), Color.White);
                sb.DrawString(font, "Zpět", new Vector2(X+32+4,Y+4),Color.White);

                if (IsScrollBar) {
                    scrollbar.ButtonDraw(/*sb, mouse.X, mouse.Y, mouseDown,*/ X+W-20,Y+32);
                }
                screen.Draw(sb, X, Y+32, W, H-32);
            } else {
                if (IsScrollBar) {

                    scrollbar.ButtonDraw(/*sb, mouse.X, mouse.Y, mouseDown,*/ X+W-20, Y);
                }
                screen.Draw(sb, X, Y, W, H);
            }


            lastMouse=mouseDown;
        }

        Texture2D GetDataTexture(string path) {
            return Content.Load<Texture2D>(Setting.StyleName+"/Textures/"+path);
        }

        SpriteFont GetDataFont(string path) {
            return Content.Load<SpriteFont>(Setting.StyleName+"/Fonts/"+path);
        }

        bool In(DInt m, int x, int y, int w, int h) {
            if (m.X < x)   return false;
            if (m.Y < y)   return false;
            if (m.X > x+w) return false;
            if (m.Y > y+h) return false;
            return true;
        }
    }

    class DrawingScreen {
        public ContentManager Content;
        public float ScrollbarValue;
        public int PageLenght;
        public DInt mouse;
        public bool mouseDown;
        public int thisWindow;
        public bool lastMouse;
        public InterAppData data;

        public virtual void Init() {
            lastMouse=false;
            mouseDown=false;
        }

        public virtual void Update() {
              //lastMouse=mouseDown;
        }

        public virtual void Draw(SpriteBatch sb, int X, int Y, int W, int H) { }

        //public Texture2D GetDataTexture(string path) {
        //    return Content.Load<Texture2D>(Setting.StyleName+"/Textures/"+path);
        //}

        public SpriteFont GetDataFont(string path) {
            return Content.Load<SpriteFont>(Setting.StyleName+"/Fonts/"+path);
        }

        public bool In(DInt m, int x, int y, int w, int h) {
            if (m.X < x)   return false;
            if (m.Y < y)   return false;
            if (m.X > x+w) return false;
            if (m.Y > y+h) return false;
            return true;
        }
    }

    class InterAppData {

    }


}
