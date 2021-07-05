using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace rabcrClient {
    class MenuCharacter: MenuScreen {

        #region Varibles
        Scrollbar scrollbar;
        RenderTarget2D worldsTarget/*, characterTarget*/;
        Effect effectBlur;
        Button buttonMenu;
        int yy;
        Texture2D /*line,*/tex/*,movemer*/;
        List<SettingItem>settings;
        Text header;
        int DocumentSize=500;
        int start,end;
        float smoothMouse=0;
        const int SettingsPageHeight=1000-60/*+70+60+70+60+90+90+90+30+60*/;
        int PageHeight;
        Character character;
        int DocumentStartXPos;
        #endregion
            float pointer=0;
            bool pointerDir;
        float alpha=0;
        public override void Init() {
            PageHeight=SettingsPageHeight+400;
            buttonMenu= new Button(Textures.ButtonLongLeft,Lang.Texts[1]);
            buttonMenu.Click+=ClickMenu;
            effectBlur=Effects.BluredTopDownBounds;
            character=new Character();
            character.Load(Content,Graphics);
            scrollbar=new Scrollbar(GetDataTexture(@"Buttons\Scrollbar\Top"), GetDataTexture(@"Buttons\Scrollbar\Center"), GetDataTexture(@"Buttons\Scrollbar\Bottom")){
                maxheight=PageHeight/*-Global.WindowHeight+65+75*//*+90+30*/,
                height=Global.WindowHeight-75-65-2
            };
            scrollbar.MoveScollBar+=Move;

         //   line = GetDataTexture("Buttons/Setting/TrackBar/Line");
            tex=GetDataTexture("Buttons/Setting/Center");
            //movemer = GetDataTexture(@"Buttons\Setting\TrackBar\Movemer");
            scrollbar.PositionY=76;
            header=new Text(Lang.Texts[8], 10, 10, BitmapFont.bitmapFont34);
            SetTexts();
            Resize();

            //Move(null,null);
        }

        void ClickMenu(object sender, EventArgs e) => ((Menu)Rabcr.screen).GoToMenu(new MainMenu());

        void Move(object sender, EventArgs e) {
            start=-1;

            yy=(int)(-scrollbar.scale*(PageHeight-Global.WindowHeight));

            for (int i=0; i<settings.Count; i++){
                SettingItem item=settings[i];
                if (yy>-50 &&yy<Global.WindowHeight-160){
                    if (start==-1)start=i;
                    end=i;
                    if (Global.WindowWidth>600) {
                        item.X=/*Global.WindowWidth/3*2-DocumentSize/2;*/DocumentStartXPos+(Global.WindowWidth-DocumentStartXPos-DocumentSize)/2;

                        if (Global.WindowWidth>800) item.ChangePos(Global.WindowWidth-(Global.WindowWidth-DocumentStartXPos-DocumentSize)/2-128/*Global.WindowWidth*3/4+DocumentSize/2-150*/,yy);
                        else item.ChangePos(Global.WindowWidth/**3/4+DocumentSize/2*/-150,yy);
                    } else {
                        item.X=20;
                        item.ChangePos(Global.WindowWidth-200,yy);

                        if (Global.WindowWidth<500) item.ChangePos(Global.WindowWidth-200,yy);
                        else item.ChangePos(Global.WindowWidth/**3/4+DocumentSize/2*/-200,yy);
                    }
                }
                yy+=item.Value;
            }
            if (start<0)start=0;
        }

        public override void Shutdown() {
            Setting.SaveSetting();
            character.Dispose();
        }

        public override void Update(GameTime gameTime) {

            if (Menu.newKeyboardState.IsKeyDown(Keys.Up)) smoothMouse-=2f;
            if (Menu.newKeyboardState.IsKeyDown(Keys.Down)) smoothMouse+=2f;

            if (Menu.newKeyboardState.IsKeyDown(Keys.PageUp)) smoothMouse-=5;
            if (Menu.newKeyboardState.IsKeyDown(Keys.PageDown)) smoothMouse+=5;

            if (Menu.newMouseState.ScrollWheelValue!=Menu.oldMouseState.ScrollWheelValue) {
                smoothMouse+=(Menu.oldMouseState.ScrollWheelValue-Menu.newMouseState.ScrollWheelValue)/3f;
            }

            buttonMenu.Update();

            if (pointerDir){
                pointer+=0.01f;
                if (pointer>1){pointer=1;pointerDir=false; }
            }else{
                pointer-=0.01f;
                if (pointer<-1){pointer=-1;pointerDir=true; }
            }

            character.handPos=new Vector2(/*Menu.mousePosX*/FastMath.Sin(pointer)*20,300/*Menu.mousePosY*/);

            if (smoothMouse!=0){
                if (Constants.AnimationsControls) {
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

            for (int i = 0; i<settings.Count; i++) {
                settings[i].Update();
            }

            base.Update(gameTime);
        }

        public override void PreDraw() {
          //  Graphics.SetRenderTarget(characterTarget);
            character.PreDraw(spriteBatch);
            Graphics.SetRenderTarget(worldsTarget);
            Graphics.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend,SamplerState.PointClamp);
               if (DocumentStartXPos!=0) character.Draw(spriteBatch, 0.5f+alpha*0.5f);
           // yy=(int)(-scrollbar.scale*(1290+60+70+60+90+90+90+30-Global.WindowHeight+60+60+90+30))/*+70*/;/*+140+90*/;
            #region Settings
            int imax=end+1;
            if (imax>=settings.Count)imax=settings.Count;
            for (int i=start; i<imax/*i<=end && i<settings.Count*/; i++){
               // if (yy>-50 &&yy<Global.WindowHeight-160){
                    settings[i].Draw(spriteBatch/*,new Vector2(20,yy),Global.WindowWidth-210*/);
            }

            #endregion

            spriteBatch.End();
            Graphics.SetRenderTarget(null);
        }

        public override void Draw(GameTime gameTime, float a) {
            alpha=a;
            effectBlur.Parameters["alpha"].SetValue(a);
            spriteBatch.Begin(SpriteSortMode.Deferred,null,null,null,null,effectBlur);
            effectBlur.Techniques[0].Passes[0].Apply();
            spriteBatch.Draw(worldsTarget, new Vector2(0, 76), new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight-75-65-2), Color.White*a);
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred,null,SamplerState.PointWrap);
            header.Draw(spriteBatch,Color.Black*a);

            //character.Y=Global.WindowHeightHalf-128/2;
            //character.X=10;




            buttonMenu.ButtonDraw(spriteBatch, /*mouse,*/a/*, new Vector2(newMouseState.X,newMouseState.Y)*/);
            scrollbar.ButtonDraw(spriteBatch,/*mouse,*/a/*,new Vector2(newMouseState.X,newMouseState.Y),new Vector2(Global.WindowWidth-35,76)*/);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Resize() {
            scrollbar.Scroll(0);

            worldsTarget?.Dispose();
            worldsTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight-75-65);
            //characterTarget?.Dispose();
            //characterTarget=new RenderTarget2D(GraphicsManager.GraphicsDevice,Global.WindowWidth,Global.WindowHeight);
            effectBlur.Parameters["v"].SetValue(1f/(Global.WindowHeight-65-75));
            effectBlur.Parameters["pos"].SetValue((1f/(Global.WindowHeight-65-75))*5);

            scrollbar.height=Global.WindowHeight-75-65-2;
            scrollbar.scale=0;

            // mobile?
            if (Global.WindowWidth<600){

                Rectangle z= character.SetRegion(new Rectangle(0, /*75*/0, 500,Global.WindowWidth));
                //if (Global.WindowWidth<200 && Global.WindowWidth>0){

                //    PageHeight=SettingsPageHeight+Global.WindowWidth;
                //}else{
                //    character.SetRegion(new Rectangle(0, /*75*/0, 500,500));

                //}
                if ((Global.WindowWidth-z.Width)-50>500)DocumentSize=500;
                else DocumentSize=(Global.WindowWidth-z.Width)-50;
                PageHeight=SettingsPageHeight;


               DocumentStartXPos=0;
            } else {
                if ((Global.WindowWidth/3)*2>500)DocumentSize=500-50;
                else DocumentSize=(Global.WindowWidth/3)*2-50;
                int height=Global.WindowHeight-75-65;
                int width=Global.WindowWidth/3;

                Rectangle z= character.SetRegion(new Rectangle(0, /*75*/0, width,height));
                PageHeight=SettingsPageHeight;
                DocumentStartXPos=z.Width;
            }

            scrollbar.maxheight=PageHeight/*-Global.WindowHeight+65+75*/;

            buttonMenu.Position=new Vector2(Global.WindowWidth-400+70, Global.WindowHeight-54);

            scrollbar.PositionX=Global.WindowWidth-35;

            Move(null,new EventArgs());
        }

        void SetTexts() {
            settings=new List<SettingItem> {

                // Cardinal
                new SettingHeader(Lang.Texts[324])
            };
            // Sex
            {
                SettingSwitcher button=new SettingSwitcher(tex,Lang.Texts[83], new string[]{ Lang.Texts[85], Lang.Texts[88] }, (int)Setting.sex);
                button.Click+=ClickChangeSex;
                settings.Add(button);

                void ClickChangeSex() {
                    Setting.sex=(Sex)button.selected;
                    Global.ChangedSettings=true;
                    character.ChangeOld();
                }
            }
            // Mature
            {
                SettingSwitcher button=new SettingSwitcher(tex,Lang.Texts[89], new string[]{Lang.Texts[336],Lang.Texts[337],Lang.Texts[338] },Setting.MaturePlayer);
                button.Click+=ClickMaturePlayer;
                settings.Add(button);

                void ClickMaturePlayer() {
                    Setting.MaturePlayer=button.selected;
                    Global.ChangedSettings=true;
                    character.ChangeOld();
                }
            }
            //SkinColor
            {
                SettingColor button=new SettingColor(tex,Lang.Texts[325],
                    new Color[] {
                        // yellow
                        new Color(248, 235, 184),
                        new Color(252, 223, 151),
                        new Color(235, 203, 152),

                        //orange
                        new Color(242, 168, 95),

                        //facial
                        new Color(250, 205, 173),
                        new Color(242, 201, 193),
                        new Color(186, 142, 114),
                        new Color(223, 141, 122),
                        new Color(168, 74, 55),
                        new Color(227, 141, 125),
                        new Color(149, 87, 52),

                        //brown
                        new Color(120, 8, 41),
                        new Color(56, 34, 7),
                        new Color(41, 13, 5),
                    }
                );
                button.Click+=ClickSkinColor;
                settings.Add(button);

                void ClickSkinColor() {
                    Setting.ColorSkin=button.selectedColor;
                    Global.ChangedSettings=true;

                    character.ChangeSkinColor();
                }
            }

            // Hair
            settings.Add(new SettingHeader(Lang.Texts[326]));
            //type
            {
                SettingSwitcherTexture button=new SettingSwitcherTexture(tex, Lang.Texts[327],
                    new Texture2D[]{
                        GetDataTexture(@"ClothesAnimations\InMenu\Hair\0"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Hair\1"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Hair\2"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Hair\3"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Hair\4"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Hair\5"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Hair\6"),
                    },
                    Setting.hairType);
                button.Click+=ClickHairType;
                settings.Add(button);

                void ClickHairType() {
                    Setting.hairType=button.selected;
                    Global.ChangedSettings=true;
                    character.SetTextureHair();
                }
            }
            //Color
            {
                SettingColor button=new SettingColor(tex, Lang.Texts[328],
                    new Color[]{
                        // Brown
                        new Color(15,3,1),
                        new Color(65,17,5),
                        new Color(60,26,11),

                        // Light brown
                        new Color(203,120,78),

                        // Orange
                        new Color(239,107,72),
                        new Color(233,47,0),

                        // Light yellow
                        new Color(240,221,188),

                        // yellow
                        new Color(223,213,22),

                        // Pink
                        new Color(203,107,10),

                        // Blue
                        new Color(0,124,197),
                        new Color(0,41,223),
                        new Color(0,0,42),

                        // Green
                        new Color(5,10,1),
                        new Color(136,175,85),
                        new Color(18,41,28),

                        // Purple
                        new Color(79,80,184),
                        new Color(28,14,101),
                        new Color(52,39,105),

                        // Gray
                        new Color(213,227,231),
                        new Color(195,227,211),
                        new Color(138,161,154),

                        // Black
                        new Color(4,5,4),
                        new Color(0,0,1),
                        new Color(0,0,0),
                    });
                button.Click+=Button_Click;
                settings.Add(button);

                void Button_Click() {
                    Setting.hairColor=button.selectedColor;
                    Global.ChangedSettings=true;
                    character.SetColorHair();
                }
            }

            // Eyes
            settings.Add(new SettingHeader(Lang.Texts[329]));
            // type
            {
                SettingSwitcherTexture button=new SettingSwitcherTexture(tex, Lang.Texts[330], new Texture2D[]{
                    GetDataTexture(@"ClothesAnimations\InMenu\Eyes\0"),
                    GetDataTexture(@"ClothesAnimations\InMenu\Eyes\1"),
                    GetDataTexture(@"ClothesAnimations\InMenu\Eyes\2"),
                    GetDataTexture(@"ClothesAnimations\InMenu\Eyes\3"),
                }, Setting.eyesType);
                button.Click+=Button_Click;
                settings.Add(button);

                void Button_Click() {
                    Setting.eyesType=button.selected;
                    Global.ChangedSettings=true;
                    character.SetTextureEyes();
                }
            }
            //color
            {
                SettingColor button=new SettingColor(tex, Lang.Texts[331],
                    new Color[]{
                        // blue
                        new Color(140,182,211),
                        new Color(95,151,173),
                        new Color(37,86,138),
                        new Color(23,53,114),
                        new Color(2,7,13),

                        //teal
                        new Color(90,130,135),
                        new Color(79,103,101),
                        new Color(51,78,92),
                        new Color(27,43,47),
                        new Color(28,53,54),

                        //orange - brown
                        new Color(77,29,13),
                        new Color(71,43,24),
                        new Color(40,21,16),
                        new Color(10,6,2),

                        // green
                        new Color(3,11,1),
                        new Color(1,16,5),
                        new Color(80,209,83),
                        new Color(2,90,8),
                        new Color(16,41,15),

                        // red
                        new Color(177,151,101),
                        new Color(175,103,81),
                        new Color(170,37,35),
                    }
                );
                button.Click+=Button_Click;
                settings.Add(button);

                void Button_Click() {
                    Setting.eyesColor=button.selectedColor;
                    Global.ChangedSettings=true;
                    character.SetColorEyes();
                }
            }

            // Moustage
            settings.Add(new SettingHeader(Lang.Texts[332]));
            //type
            {
                SettingSwitcherTexture button=new SettingSwitcherTexture(tex, Lang.Texts[333],
                    new Texture2D[]{
                        GetDataTexture(@"ClothesAnimations\InMenu\Moustage\0"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Moustage\1"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Moustage\2"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Moustage\3"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Moustage\4"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Moustage\5"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Moustage\6"),
                        GetDataTexture(@"ClothesAnimations\InMenu\Moustage\7"),
                    },
                    Setting.moustageType);

                button.Click+=Button_Click;
                settings.Add(button);

                void Button_Click() {
                    Setting.moustageType=button.selected;
                    Global.ChangedSettings=true;
                    character.SetTextureMoustage();
                }
            }
            //color
            {
                SettingColor button=new SettingColor(tex, Lang.Texts[334], new Color[]{
                     // Brown
                        new Color(15,3,1),
                        new Color(65,17,5),
                        new Color(60,26,11),

                        // Light brown
                        new Color(203,120,78),

                        // Orange
                        new Color(239,107,72),
                        new Color(233,47,0),

                        // Light yellow
                        new Color(240,221,188),

                        // yellow
                        new Color(223,213,22),

                        // Pink
                        new Color(203,107,10),

                        // Blue
                        new Color(0,124,197),
                        new Color(0,41,223),
                        new Color(0,0,42),

                        // Green
                        new Color(5,10,1),
                        new Color(136,175,85),
                        new Color(18,41,28),

                        // Purple
                        new Color(79,80,184),
                        new Color(28,14,101),
                        new Color(52,39,105),

                        // Gray
                        new Color(213,227,231),
                        new Color(195,227,211),
                        new Color(138,161,154),

                        // Black
                        new Color(4,5,4),
                        new Color(0,0,1),
                        new Color(0,0,0),
                });
                button.Click+=ClickMoustageColor;
                settings.Add(button);

                void ClickMoustageColor() {
                    Setting.moustageColor=button.selectedColor;
                    Global.ChangedSettings=true;
                    character.SetColorMoustage();
                }
            }

            Move(null,new EventArgs());
        }

       class Character : IDisposable{

            #region Varibles
          //  public int X,Y;

            public Texture2D
                TextureStaticClothesLegs,
                TextureStaticClothesHead,
                TextureStaticDownCensored,
                TextureStaticClothesFeet,
                TextureStaticClothesChestTop,
                TextureStaticClothesChest,
                TextureStaticUpCensored,
                TexturePlayerStaticFeet,
                TexturePlayerStaticLegs,

                // Clothes textures
                TextureStaticDress,
                TextureStaticJacketShort,
                TextureStaticClothesUnderwearUp,
                TextureStaticShorts,
                TextureStaticSkirt,
                TextureStaticClothesUnderwearDown,
                TexturePlayerStaticChest,
                TexturePlayerStaticFace,
                TexturePlayerStaticHair,
                TexturePlayerStaticMoustage,
                TexturePlayerStaticMouth,

                TextureStaticArmyTrousers,
                TextureStaticCap,
                TextureStaticHad,
                TextureStaticFormalShoes,
                TextureStaticPumps,
                TextureStaticCrown,
                TextureStaticSpaceHelmet,
                TextureStaticUnderpants,
                TextureStaticSpaceTrousers,
                TextureStaticTShirt,
                TextureStaticBoxerShorts,
                TextureStaticPanties,
                TextureStaticSwimsuit,
                TextureStaticBikiniDown,
                TextureStaticBra,
                TextureStaticBikiniTop,
                TextureStaticCoatArmy,
                TextureStaticCoat,
                TexturePlayerStaticEyes,

                TextureHandUp,
                TextureHandDown,

                
            TextureStaticSpaceSuit,
                TextureStaticShirt,
                TextureStaticSneakers,
                TextureStaticSpaceBoots,
                TextureStaticJeans,
                TextureStaticJacketDenim,
                TextureStaticJacketFormal,
                TextureStaticJacket;

            Color
                white,
            ColorClothesLegs,
                ColorClothesChest,
                ColorClothesUpUnderwear,
                ColorClothesChestTop,
                ColorClothesHead,
                ColorClothesFeet;
            Texture2D newFace;
            string fastloadtexturespath;
            ContentManager Content;
GraphicsDevice Graphics;
            int zoom=1; RenderTarget2D rt;  public  Vector2 handPos;
            #endregion
            Matrix matrix;
            Rectangle region;
            const int PlayerHeight=41;
            public void Load(ContentManager con,GraphicsDevice g){
                Content=con;
                Graphics=g;
                white=Color.White;
                fastloadtexturespath=Setting.StyleName+"/Textures/";

                TexturePlayerStaticFeet=/*Rabcr.ColorizeTexture(*/GetDataTexture("ClothesAnimations/Static/Body/Feet")/*, Setting.ColorSkin)*/;
               // TexturePlayerStaticLegs=GetDataTexture("ClothesAnimations/Static/Body/Legs/"+((Setting.MaturePlayer>0) ? "":"Young" )+(Setting.sex==Sex.Girl ? "Girl" : "Men"));
               // TexturePlayerStaticChest=GetDataTexture("ClothesAnimations/Static/Body/Chest/"+(Setting.sex==Sex.Men ? "0" : Setting.MaturePlayer.ToString()));



                TexturePlayerStaticMouth=GetDataTexture("ClothesAnimations/Static/Body/Mouth/Normal");
                TextureStaticDownCensored=GetDataTexture("ClothesAnimations/Static/DownUnderwear/Censored");
                TexturePlayerStaticFace=GetDataTexture("ClothesAnimations/Static/Body/Face");

                TextureHandUp=GetDataTexture("ClothesAnimations/Static/Body/Hands/Up");
                TextureHandDown=GetDataTexture("ClothesAnimations/Static/Body/Hands/Down");

                //TexturePlayerStaticEyes=GetDataTexture("ClothesAnimations/Static/Face/Eyes/Eyes"+Setting.eyesType);

                //TexturePlayerStaticMoustage=GetDataTexture("ClothesAnimations/Static/Face/Moustage/Moustage"+Setting.moustageType);

            //    TextureStaticFormalShoes=GetDataTexture("ClothesAnimations/Static/Feet/FormalShoes");
             //   TextureStaticPumps=GetDataTexture("ClothesAnimations/Static/Feet/Pumps");
             //   TextureStaticSneakers=GetDataTexture("ClothesAnimations/Static/Feet/Sneakers");
            //    TextureStaticSpaceBoots=GetDataTexture("ClothesAnimations/Static/Feet/SpaceBoots");

                //TextureStaticJeans=GetDataTexture("ClothesAnimations/Static/Legs/Jeans");
                //TextureStaticShorts=GetDataTexture("ClothesAnimations/Static/Legs/Shorts");
                //TextureStaticSkirt=GetDataTexture("ClothesAnimations/Static/Legs/BlackSkirt");
                //TextureStaticArmyTrousers=GetDataTexture("ClothesAnimations/Static/Legs/ArmyTrousers");
                //TextureStaticSpaceTrousers=GetDataTexture("ClothesAnimations/Static/Legs/SpaceTrousers");

                //TextureStaticTShirt=GetDataTexture("ClothesAnimations/Static/Chest/"+(Setting.sex==Sex.Girl ? (Setting.MaturePlayer ? "Girl" :"Men") : "Men")+"/LightBlueTShirt");
                //TextureStaticSpaceSuit=GetDataTexture("ClothesAnimations/Static/ChestTop/"+(Setting.sex==Sex.Girl ? (Setting.MaturePlayer ? "Girl" :"Men") : "Men")+"/SpaceSuit");
                //TextureStaticShirt=GetDataTexture("ClothesAnimations/Static/Chest/"+(Setting.sex==Sex.Girl ? (Setting.MaturePlayer ? "Girl" :"Men") : "Men")+"/Shirt");
                //TextureStaticDress=GetDataTexture("ClothesAnimations/Static/Chest/"+(Setting.sex==Sex.Girl ? (Setting.MaturePlayer ? "Girl" :"Men") : "Men")+"/BlueDress");

                //TextureStaticCap=GetDataTexture("ClothesAnimations/Static/Head/Cap");
                //TextureStaticHad=GetDataTexture("ClothesAnimations/Static/Head/Had");
                //TextureStaticCrown=GetDataTexture("ClothesAnimations/Static/Head/Crown");
                //TextureStaticSpaceHelmet=GetDataTexture("ClothesAnimations/Static/Head/SpaceHelmet");

                //TextureStaticUnderpants=GetDataTexture("ClothesAnimations/Static/DownUnderwear/GrayUnderpants");
                //TextureStaticBoxerShorts=GetDataTexture("ClothesAnimations/Static/DownUnderwear/BoxerShorts");
                //TextureStaticPanties=GetDataTexture("ClothesAnimations/Static/DownUnderwear/PantiesRed");
                //TextureStaticSwimsuit=GetDataTexture("ClothesAnimations/Static/DownUnderwear/Swimsuit");
                //TextureStaticBikiniDown=GetDataTexture("ClothesAnimations/Static/DownUnderwear/BlackBikini");

                //TextureStaticBra=GetDataTexture("ClothesAnimations/Static/UpUnderwear/GrayBra");
                //TextureStaticBikiniTop=GetDataTexture("ClothesAnimations/Static/UpUnderwear/BlackBikini");

                //TextureStaticCoatArmy=GetDataTexture("ClothesAnimations/Static/ChestTop/"+(Setting.sex==Sex.Men ? "Men":(Setting.MaturePlayer ? "Girl" :"Men"))+"/CoatArmy");
                //TextureStaticCoat=GetDataTexture("ClothesAnimations/Static/ChestTop/"+(Setting.sex==Sex.Men ? "Men":(Setting.MaturePlayer ? "Girl" :"Men"))+"/CoatGray");
                //TextureStaticJacketDenim=GetDataTexture("ClothesAnimations/Static/ChestTop/"+(Setting.sex==Sex.Men ? "Men":(Setting.MaturePlayer ? "Girl" :"Men"))+"/JacketDenim");
                //TextureStaticJacketFormal=GetDataTexture("ClothesAnimations/Static/ChestTop/"+(Setting.sex==Sex.Men ? "Men":(Setting.MaturePlayer ? "Girl" :"Men") )+"/JacketFormal");
                //TextureStaticJacket=GetDataTexture("ClothesAnimations/Static/ChestTop/"+(Setting.sex==Sex.Men ? "Men":(Setting.MaturePlayer ? "Girl" :"Men"))+"/JacketRed");
                //TextureStaticJacketShort=GetDataTexture("ClothesAnimations/Static/ChestTop/"+(Setting.sex==Sex.Men ? "Men":(Setting.MaturePlayer ? "Girl" :"Men"))+"/JacketShort");

               ChangeOld();

                SetTextureHair();
                SetTextureMoustage();
                SetTextureEyes();

                //SetColorHair();
                //SetColorEyes();
                //setcol
                ChangeSkinColor();

                rt=new RenderTarget2D(g,40,40);

            }

            Texture2D Texture2DEyes, Texture2DMoustage, Texture2DHair;
            Texture2D GetDataTexture(string path) => Content.Load<Texture2D>(fastloadtexturespath+path);

            public Rectangle SetRegion(Rectangle newRec){
                if (newRec.Width>newRec.Height) {
                    region=new Rectangle(newRec.X+newRec.Width/2-newRec.Height/2,newRec.Y,newRec.Height,newRec.Height);
                } else {
                    region=new Rectangle(newRec.X,newRec.Y+newRec.Height/2-newRec.Width/2,newRec.Width,newRec.Width);
                }

               // region=newRec;
                zoom=region.Width/PlayerHeight;
                rt?.Dispose();
                  rt=new RenderTarget2D(Graphics,region.Width,region.Height);

                matrix =
                    Matrix.CreateScale(zoom, zoom, 0) *
                    Matrix.CreateTranslation(new Vector3(region.Width/2, region.Height/2, 0));

                return region;
            }

            public void ChangeOld(){
                TextureStaticUpCensored=GetDataTexture("ClothesAnimations/Static/UpUnderwear/Censored");
                 TexturePlayerStaticChest=GetDataTexture("ClothesAnimations/Static/Body/Chest/"+(Setting.sex==Sex.Men ? "0" : Setting.MaturePlayer.ToString()));
                TexturePlayerStaticLegs=GetDataTexture("ClothesAnimations/Static/Body/Legs/"+((Setting.MaturePlayer>0) ? "":"Young" )+(Setting.sex==Sex.Girl ? "Girl" : "Men"));
            }

            public void SetTextureHair(){
                if (Setting.hairType==0)TexturePlayerStaticHair=null;
                else TexturePlayerStaticHair=GetDataTexture("ClothesAnimations/Static/Body/Hair/"+Setting.hairType);
                SetColorHair();
            }

            public void SetTextureEyes(){
                TexturePlayerStaticEyes=GetDataTexture("ClothesAnimations/Static/Body/Eyes/"+Setting.eyesType);
                SetColorEyes();
            }

            public void SetColorEyes(){
                Texture2DEyes=/*Rabcr.ColorizeTexture(*/TexturePlayerStaticEyes/*,Setting.eyesColor)*/;
            }

            public void SetColorMoustage(){
               if (TexturePlayerStaticMoustage!=null) Texture2DMoustage=/*Rabcr.ColorizeTexture(*/TexturePlayerStaticMoustage/*,Setting.moustageColor)*/;
               else Texture2DMoustage=null;
            }

            public void SetColorHair(){
                if (TexturePlayerStaticHair!=null) Texture2DHair=/*Rabcr.ColorizeTexture(*/TexturePlayerStaticHair/*,Setting.hairColor)*/;
                else Texture2DHair=null;
            }

            public void SetTextureMoustage(){
                if (Setting.moustageType==0)TexturePlayerStaticMoustage=null;
                else TexturePlayerStaticMoustage=GetDataTexture("ClothesAnimations/Static/Body/Moustage/"+Setting.moustageType);
                SetColorMoustage();
            }

            public void ChangeSkinColor(){
              //  newFace?.Dispose();
                newFace=/*Rabcr.ColorizeTexture(*/TexturePlayerStaticFace/*, Setting.ColorSkin)*/;
            }

            public void Draw(SpriteBatch spriteBatch, float z){
                if (rt!=null)spriteBatch.Draw(rt,new Vector2(region.X,region.Y), white*z);
            }

            public void PreDraw(SpriteBatch spriteBatch) {
                if (rt==null)return;
                Graphics.SetRenderTarget(rt);
                spriteBatch.Begin(SpriteSortMode.Deferred,null,SamplerState.PointClamp,null,null,null,matrix);
                Graphics.Clear(Color.Transparent);

                int y=((region.Height-zoom*PlayerHeight)/2)/zoom/*+39/2*/;
                int x=/*11+*/(PlayerHeight-22)/2-9;

                if (TextureStaticClothesLegs!=null) {
                    if (TextureStaticClothesLegs==TextureStaticShorts || TextureStaticClothesLegs==TextureStaticSkirt) spriteBatch.Draw(TexturePlayerStaticLegs, new Vector2(x-11, y-39/2), white);
                    spriteBatch.Draw(TextureStaticClothesLegs, new Vector2(x-11, y-39/2), ColorClothesLegs);
                } else {
                    spriteBatch.Draw(TexturePlayerStaticLegs, new Vector2(x-11, y-39/2), Setting.ColorSkin);
                    if (TextureStaticClothesUnderwearDown!=null) {
                        if (TextureStaticClothesChest!=TextureStaticDress) spriteBatch.Draw(TextureStaticClothesUnderwearDown, new Vector2(x-11, y-39/2), white);
                    } else {
                        if (Global.YoungPlayer) spriteBatch.Draw(TextureStaticDownCensored, new Vector2(x-11, y-39/2), /*white*/Setting.ColorSkin);
                    }
                }
                if (TextureStaticClothesChestTop==null || TextureStaticClothesChestTop==TextureStaticJacketShort) {
                    if (TextureStaticClothesChest!=null) spriteBatch.Draw(TextureStaticClothesChest, new Vector2(x-11, y-39/2), ColorClothesChest);
                    else {
                        spriteBatch.Draw(TexturePlayerStaticChest, new Vector2(x-11, y-39/2), /*white*/Setting.ColorSkin);
                        if (TextureStaticClothesUnderwearUp!=null) spriteBatch.Draw(TextureStaticClothesUnderwearUp, new Vector2(x-11, y-39/2), ColorClothesUpUnderwear);
                        else {
                            if (Setting.sex==Sex.Girl) {
                                if (Global.YoungPlayer){
                                    if (Setting.MaturePlayer>0) spriteBatch.Draw(TextureStaticUpCensored, new Vector2(x-11, y-39/2), white);
                                }
                            }
                        }
                    }
                }

                if (TextureStaticClothesChestTop!=null) spriteBatch.Draw(TextureStaticClothesChestTop, new Vector2(x-11, y-39/2), ColorClothesChestTop);

                if (TextureStaticClothesFeet!=null) spriteBatch.Draw(TextureStaticClothesFeet, new Vector2(x-11, y-39/2), ColorClothesFeet);
                else spriteBatch.Draw(TexturePlayerStaticFeet, new Vector2(x-11, y-39/2), Setting.ColorSkin);

                spriteBatch.Draw(/*TexturePlayerStaticFace*/newFace, new Vector2(x-11, y-39/2-1), /*Color.White*/Setting.ColorSkin);
                spriteBatch.Draw(Texture2DEyes, new Vector2(x-11, y-39/2-1), Setting.eyesColor/*white*/);
                spriteBatch.Draw(TexturePlayerStaticMouth, new Vector2(x-11, y-39/2-1), white);
               if (Texture2DHair!=null) spriteBatch.Draw(Texture2DHair, new Vector2(x-11, y-39/2-1), /*white*/Setting.hairColor);
                if (Texture2DMoustage!=null) spriteBatch.Draw(Texture2DMoustage, new Vector2(x-11, y-39/2-1), /*white*/Setting.moustageColor);

                if (TextureStaticClothesHead!=null) {
                    if (TextureStaticClothesHead!=TextureStaticSpaceHelmet){
                        if (Texture2DHair!=null)
                        spriteBatch.Draw(Texture2DHair, new Vector2(x-11, y-39/2-1), white);
                    }
                    spriteBatch.Draw(TextureStaticClothesHead, new Vector2(x-11, y-39/2-2), ColorClothesHead);
                } else {
                  if (Texture2DHair!=null)  spriteBatch.Draw(Texture2DHair, new Vector2(x-11, y-39/2-1), /*white*/Setting.hairColor);
                }

                //left
                {
                    float scaleDown=1f, scaleUp=1f;
                    // Pozice bodu ramena
                    Vector2 rameno=new Vector2(x-11+2+1,y-39/2+12-1);

                    // velikost ruky
                    int maxdistance=6*2;

                    // Vzdálenost koncového bodu a ramena (vždy menší jak maxdistance) !!!
                    float dis=Vector2.Distance(handPos,new Vector2(0,0))/10;

                    bool bigger=dis>=11.9999;
                    if (bigger) dis=maxdistance;

                    // Nelomený relativní vektor ruky (složené z jedné kosti)
                    Vector2 hand=Vector2.Normalize(handPos)*maxdistance*(dis/maxdistance);

                    // Z vektoru udělat koncový bod ruky
                    hand.X+=/*x-11*/+rameno.X;
                    hand.Y+=/*y-39/2+*/rameno.Y;



                    // Bod střed - uprostřed (mezi) ramenem a rukou
                    Vector2 center=(hand+rameno)/2;

                    Vector2 nlocket,iii;

                    // float is not precise...
                    if (bigger){
                        //dis=12;

                        nlocket=center;iii=nlocket;
                    } else {
                        Vector2 z=center-rameno;
                         // Vektor na kterém leží loket
                        Vector2 loket=new Vector2(-z.Y,z.X);

                        // Vzdálenost loket a bod střed
                        float toloket=(float)Math.Sqrt(6*6-dis*dis/4);

                        // vektor - k určení pozice loktu (od bodu střed)
                        nlocket=Vector2.Normalize(loket)*toloket;
              //  bool polePlus=false;
                        // fix not normal mooving with hand
                        float angle=(float)Math.Atan2(rameno.Y-hand.Y,rameno.X-hand.X);
                        if (angle>-0.75f && angle<1.5f){
                            nlocket=-nlocket;
                        }else{

                              //polePlus=true;

                        }

                     //  iii=nlocket;

                        // z vektoru bod
                        nlocket.X+=center.X;
                        nlocket.Y+=center.Y;

                        //if (polePlus) {
                          //  if (nlocket.X>hand.X) {
                               // float index=FastMath.SinFrom0toPI(angle);

                              //  float delta = /**index+(1-index)*(nlocket.X-rameno.X)*/;
                                //float from=6;
                                //Vector2 newPoint=new Vector2(delta,nlocket.Y);


                                //scaleUp=to/from;

                            iii=new Vector2(((hand.X+rameno.X)/2f+nlocket.X)/2f, nlocket.Y);
                          //  }
                        //}else{
                        //     iii=nlocket;
                        //}

                    scaleUp= Vector2.Distance(iii,rameno)/maxdistance;
                        scaleDown= Vector2.Distance(iii,hand)/maxdistance;
                    }

                    // Bod mezi loktem a ramenem
                    Vector2 v1=(iii+rameno)/2f;

                    // Bod mezi loktem a rukou
                    Vector2 v2=(iii+hand)/2f;

                  ///  Debug.WriteLine((/*/Math.PI)*180+180*/));

                    spriteBatch.Draw(TextureHandDown, v1,new Rectangle(0,0,4,4+FastMath.Round(6*scaleUp)), /*white*/Setting.ColorSkin, (float)Math.Atan2(v1.Y-rameno.Y, v1.X-rameno.X)+(float)Math.PI/2f, new Vector2(2,2+FastMath.Round(3*scaleUp)), 1, SpriteEffects.None,1f);
                    spriteBatch.Draw(TextureHandUp, v2,new Rectangle(0,0,4,4+FastMath.Round(6*scaleDown)), /*white*/Setting.ColorSkin, (float)Math.Atan2(v2.Y-iii.Y, v2.X-iii.X)+(float)Math.PI/2f, new Vector2(2,2+FastMath.Round(3*scaleDown)), 1, SpriteEffects.None,1f);

                    //spriteBatch.Draw(Rabcr.Pixel,hand,Color.Red);
                    //spriteBatch.Draw(Rabcr.Pixel,rameno,Color.Green);

                    //spriteBatch.Draw(Rabcr.Pixel,center,Color.Blue);
                    //spriteBatch.Draw(Rabcr.Pixel,nlocket,Color.Pink);

                    //spriteBatch.Draw(Rabcr.Pixel,v1,Color.Teal);
                    //spriteBatch.Draw(Rabcr.Pixel,v2,Color.Purple);

                    //spriteBatch.Draw(Rabcr.Pixel,iii,Color.Gray);
                }

                //right
                 {
                    handPos.X=-handPos.X;

                    int add=16;
                    float scaleDown=1f, scaleUp=1f;
                    // Pozice bodu ramena
                    Vector2 rameno=new Vector2(x-11+2+1+add,y-39/2+12-1);

                    // velikost ruky
                    int maxdistance=6*2;

                    // Vzdálenost koncového bodu a ramena (vždy menší jak maxdistance) !!!
                    float dis=Vector2.Distance(handPos,new Vector2(0,0))/10;

                    bool bigger=dis>=11.9999;
                    if (bigger) dis=maxdistance;

                    // Nelomený relativní vektor ruky (složené z jedné kosti)
                    Vector2 hand=Vector2.Normalize(handPos)*maxdistance*(dis/maxdistance);

                    // Z vektoru udělat koncový bod ruky
                    hand.X+=/*x-11*/+rameno.X;
                    hand.Y+=/*y-39/2+*/rameno.Y;



                    // Bod střed - uprostřed (mezi) ramenem a rukou
                    Vector2 center=(hand+rameno)/2;

                    Vector2 nlocket,iii;

                    // float is not precise...
                    if (bigger){
                      //  dis=12;

                        nlocket=center;iii=nlocket;
                    } else {
                        Vector2 z=center-rameno;
                         // Vektor na kterém leží loket
                        Vector2 loket=new Vector2(-z.Y,z.X);

                        // Vzdálenost loket a bod střed
                        float toloket=(float)Math.Sqrt(6*6-dis*dis/4);

                        // vektor - k určení pozice loktu (od bodu střed)
                        nlocket=Vector2.Normalize(loket)*toloket;
              //  bool polePlus=false;
                        // fix not normal mooving with hand
                        float angle=(float)Math.Atan2(rameno.Y-hand.Y,rameno.X-hand.X);
                        if (angle>-0.75f && angle<1.5f){
                            nlocket=-nlocket;
                        }else{

                              //polePlus=true;

                        }

                      // iii=nlocket;

                        // z vektoru bod
                        nlocket.X+=center.X;
                        nlocket.Y+=center.Y;

                        //if (polePlus) {
                          //  if (nlocket.X>hand.X) {
                               // float index=FastMath.SinFrom0toPI(angle);

                              //  float delta = /**index+(1-index)*(nlocket.X-rameno.X)*/;
                                //float from=6;
                                //Vector2 newPoint=new Vector2(delta,nlocket.Y);


                                //scaleUp=to/from;

                            iii=new Vector2(((hand.X+rameno.X)/2f+nlocket.X)/2f, nlocket.Y);
                          //  }
                        //}else{
                        //     iii=nlocket;
                        //}

                    scaleUp= Vector2.Distance(iii,rameno)/maxdistance;
                        scaleDown= Vector2.Distance(iii,hand)/maxdistance;
                    }

                    // Bod mezi loktem a ramenem
                    Vector2 v1=(iii+rameno)/2f;

                    // Bod mezi loktem a rukou
                    Vector2 v2=(iii+hand)/2f;

                  ///  Debug.WriteLine((/*/Math.PI)*180+180*/));

                    spriteBatch.Draw(TextureHandDown, v1,new Rectangle(0,0,4,4+FastMath.Round(6*scaleUp)), /*white*/Setting.ColorSkin, (float)Math.Atan2(v1.Y-rameno.Y, v1.X-rameno.X)+(float)Math.PI/2f, new Vector2(2,2+FastMath.Round(3*scaleUp)), 1, SpriteEffects.None,1f);
                    spriteBatch.Draw(TextureHandUp, v2,new Rectangle(0,0,4,4+FastMath.Round(6*scaleDown)), /*white*/Setting.ColorSkin, (float)Math.Atan2(v2.Y-iii.Y, v2.X-iii.X)+(float)Math.PI/2f, new Vector2(2,2+FastMath.Round(3*scaleDown)), 1, SpriteEffects.None,1f);

                    //spriteBatch.Draw(Rabcr.Pixel,hand,Color.Red);
                    //spriteBatch.Draw(Rabcr.Pixel,rameno,Color.Green);

                    //spriteBatch.Draw(Rabcr.Pixel,center,Color.Blue);
                    //spriteBatch.Draw(Rabcr.Pixel,nlocket,Color.Pink);

                    //spriteBatch.Draw(Rabcr.Pixel,v1,Color.Teal);
                    //spriteBatch.Draw(Rabcr.Pixel,v2,Color.Purple);

                    //spriteBatch.Draw(Rabcr.Pixel,iii,Color.Gray);
                }
                spriteBatch.End();
                Graphics.SetRenderTarget(null);
            }

            public void Dispose() {
                rt?.Dispose();
                rt=null;
            }
        }
    }
}