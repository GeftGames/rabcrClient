using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace rabcrClient {
    public class Ellipsoid {
        readonly List<Double2> Points=new List<Double2>();
        const int precision=60;
        double delta;
        readonly AstronomicalObject ao;
        bool drawPart=false;
        double zAphelion, zPerihelion/*, zDelta*/;

        public Ellipsoid(AstronomicalObject o) {
            ao=o;
        }


        void ReCount(){
            Points.Clear();
            zAphelion = ao.Aphelion*z;
             zPerihelion = ao.Perihelion*z;
             delta =zAphelion- zPerihelion;


                if (ao.dis>5000) {
               //     double MeanAnomaly = (ao.CurrentTime/ao.OrbitalPeriod)*Math.PI*2d;
              //    double t=MeanAnomaly-/*Eccentricity*Eccentricity**/ao.Eccentricity*(/*1-*/Math.Sin(MeanAnomaly+ao.LongitudeOfAscendingNode))*2+ao.LongitudeOfAscendingNode;


                    double deltaTime = ((/*Global.WindowWidthHalf*/(ao.SemiMajorAxis/4)/z)/(ao.Speed*60*20d*1000))/2;//s->20min//(Math.PI*2)*z;
           if (deltaTime>Math.PI)deltaTime=Math.PI;
                    drawPart=true;

                    for (int i = 0; i<precision; i++) {
                        double angle = ao.pos-deltaTime+2*deltaTime*((double)i/precision)/**Math.PI*2*/; //Console.WriteLine(angle);

                        Points.Add(new Double2(
                            zAphelion*Math.Cos(angle)*Math.Cos(ao.LongitudeOfAscendingNode)-zPerihelion*Math.Sin(angle)*Math.Sin(ao.LongitudeOfAscendingNode)+Math.Cos(ao.LongitudeOfAscendingNode)*delta,
                            zAphelion*Math.Cos(angle)*Math.Sin(ao.LongitudeOfAscendingNode)+zPerihelion*Math.Sin(angle)*Math.Cos(ao.LongitudeOfAscendingNode)+Math.Sin(ao.LongitudeOfAscendingNode)*delta
                        ));
                    }
                } else {
                    drawPart=false;
                for (int i = 0; i<precision; i++) {
                    double angle = ((double)i/precision)*Math.PI*2; //Console.WriteLine(angle);

                    //   double realSemiMajorAxis=Math.Sqrt(SemiMajorAxis*SemiMajorAxis*(1-Math.Tan(Inclination)*Math.Tan(Inclination)));

                    //double
                    //    Aphelion = realSemiMajorAxis-realSemiMajorAxis*Eccentricity,
                    //    Perihelion = realSemiMajorAxis+realSemiMajorAxis*Eccentricity;
                    // double ep=Aphelion*Math.Cos(Inclination);
                    Points.Add(new Double2(zAphelion*Math.Cos(angle)*Math.Cos(ao.LongitudeOfAscendingNode)-zPerihelion*Math.Sin(angle)*Math.Sin(ao.LongitudeOfAscendingNode)+Math.Cos(ao.LongitudeOfAscendingNode)*delta,
                    zAphelion*Math.Cos(angle)*Math.Sin(ao.LongitudeOfAscendingNode)+zPerihelion*Math.Sin(angle)*Math.Cos(ao.LongitudeOfAscendingNode)+Math.Sin(ao.LongitudeOfAscendingNode)*delta
                //Perihelion*Math.Cos(angle)
                //                ,Perihelion*Math.Sin(angle)
                ));//CalculatePos(i/(double)precision,Inclination, Aphelion, Perihelion)
                }
            }
        }

        //double[] CalculatePos(double angle, double Inclination, double Aphelion, double Perihelion) {
        //    return ;
        //}
        double z;
        public void Draw(SpriteBatch sb, Double2 pos, Color c,double zoom) {
            if (zoom!=z){
                z=zoom;
                ReCount();


            }
         // if (Points.Count>0)
         if (drawPart){
                     double deltaTime = ((/*Global.WindowWidthHalf*/ao.SemiMajorAxis/z)/(ao.Speed*60*20d*1000))/2;//s->20min//(Math.PI*2)*z;


                        double angle = ao.pos-deltaTime+2*deltaTime;
                if (angle>ao.pos)ReCount();
                DrawPart(sb, pos, c);
            } else
                DrawFull(sb, pos, c);
        }

        void DrawFull(SpriteBatch sb, Double2 pos, Color c){

             for (int i=0; i<precision-1; i++) {//   Console.WriteLine(Points [i].X);
                DrawLine(sb,new Double2(pos.X+Points[i].X,pos.Y+Points[i].Y),new Double2(pos.X+Points[i+1].X,pos.Y+Points[i+1].Y),c);
            }
            DrawLine(sb,new Double2(pos.X+Points[precision-1].X,pos.Y+Points[precision-1].Y),new Double2(pos.X+Points[0].X,pos.Y+Points[0].Y),c);
        }
 void DrawPart(SpriteBatch sb, Double2 pos, Color c){

             for (int i=0; i<precision-1; i++) {//   Console.WriteLine(Points [i].X);
                DrawLine(sb,new Double2(pos.X+Points[i].X,pos.Y+Points[i].Y),new Double2(pos.X+Points[i+1].X,pos.Y+Points[i+1].Y),c);
            }
         //   DrawLine(sb,new Vector2((float)(pos.X+Points[precision-1].X),(float)(pos.Y+Points[precision-1].Y)),new Vector2((float)(pos.X+Points[0].X),(float)(pos.Y+Points[0].Y)),c);
        }
         void DrawLine(SpriteBatch sb, Double2 start, Double2 end, Color c) {
         //   Vector2 edge = end.toVector() - start.toVector();
            // calculate angle to rotate line
            double
                _x=end.X-start.X,
                _y=end.Y-start.Y;

            sb.Draw(Rabcr.Pixel,
                new Rectangle(// rectangle defines shape of line and position of start of line
                    (int)start.X,
                    (int)start.Y,
                    (int)Math.Sqrt(_x*_x+_y*_y)/*edge.Length()*/, //sb will strech the texture to fill this rectangle
                    1), //width of line, change this to make thicker line
                null,
                c, //colour of line
                (float)Math.Atan2(_y,_x/*edge.Y , edge.X*/),     //angle of line (calulated above)
                new Vector2(0, 0), // point in line about which to rotate
                SpriteEffects.None,
                0);


        }
    }

    class PlanetSystem :Screen{
        enum Displayed{
            SolarSystem,
            PlanetSystem,
        }

        public override void Resize(){
              buttonGoUp.Position=new Vector2(0,0);
        }

        readonly Color
            //color_r200_g200_b200_a100= new Color(200,200,200,100),
            color_r0_g0_b0_a200 = new Color(0,0,0,200),
            color_r10_g140_b255 = new Color(10,140,255),
            //color_r128_g128_b128= new Color(128,128,128),
            //color_r150_g150_b150= new Color(150,150,150),
            color_r0_g0_b0_a100 = new Color(0,0,0,100)
            //color_r255_g0_b0_a100 = new Color(255, 0, 0, 100),
            /*color_r200_g200_b200=new Color(200, 200, 200)*//*,*/
            /*lampColorLight=new Color(255, 255, 220, 255)*/;

        Texture2D TextureAdbBlock,TextureAdvBackBlock, TextureAdvFloor,TextureAdvWindow,textureSlot;
        Displayed displayed;
      //  readonly Vector2 vector_x0_y4 = new Vector2(0,4);
       // const double kappa=6.67259e-11;
        KeyboardState newKeyboardState/*, oldKeyboardState*/;
        MouseState newMouseState=new MouseState(), oldMouseState;
        //Random random;
        //Camera camera;
        GameButtonMedium buttonLand, buttonGoUp, buttonCreate;
     //   MyTrackBar movemer;
      //  const int SidePanelSize=350;
     //   Line line;
   //     PopUpMenu popUpMenu; bool mouse=false;
       // Planet canOrbit, mercur, venus, earth, mars, jupiter, saturn, uran, neptun, pluto, moon, io, callisto, galimedes, europa, titan, triton,station;
      //  ContentManager Content;
        Texture2D /*pixel,*/ /*SunTexture,*/ /*rocketTexture,*/ buttonCenter, buttonAround;
      // Vector2 ;
        Double2 windowPosition=new Double2(0,0)/*,*//*rocketPos=new Double2(0,0), selectedPos=new Double2(0,0),*/ /*mousePos=new Double2(0,0)*//*, lastPos=new Double2(0,0)*/;
        SpriteFont spriteFont_medium,spriteFont_small;
        AstronomicalObject[] sun;
       // List<Star> stars;
       // List<Planet> asteroidK, asteroidB;
       bool dialogLand=false;
      //  double zoom=0.5, rocketAngle;
      //  bool click = false;
     //  const double rocketSpeed = 0.001f;
    //  const  int rocketFlyLineColor = 0;
      //  bool fly = false;
      //  Button buttonOpenPanel;
        readonly string[] worlds = new string[] {
            "Země","Měsíc", "Mars","Vesmírná stanice"


          //  "Slunce",
           // "Merkur",
          //  "Venuše",
             /*"Vesmírná stanice",*/
          //  "Mars", /*"Phobos", "Deimos",*/
          //  "Ceres",/*"Pallas","Vesta",*/
          //  "Jupiter",/* "Io", "Europa", "Ganymed", "Callisto", */
          //  "Saturn", /*"Titan", "Rhea", "Iapetus","Dione","Tethys","Enceladus","Mimas",*/
          //  "Uran", /*"Titania","Oberon","Umbriel","Ariel","Miranda",*/
          //  "Neptun", /*"Triton", "Proteus",*/
          //  "Pluto", /*"Charon",*/
            //"Eris","Dysnomia",
            //"Makemake",
            //"Haumea",
            //"Sedna",
            //"Orcus","Vanth",
            //"2007 OR10",
            //"Quaoar",
            //"Salacia",
            //"Actaea",
            };
        string potencialLand;

        //   const string path="";
        // string onPlanet="Země";
        //public DInt Window;
        readonly string pathToWorld="";

        ImgButton buttonClose;
        string selectedAO="";
        readonly List<DInt>Inventory=new List<DInt>();
        public PlanetSystem(string p)=>pathToWorld=p;

        bool CanGenerateWorld(string nameCz) {
            foreach (string w in worlds){
                if (w==nameCz)return true;
            }
            return false;
        }

        public override void Init() {
            //random=Rabcr.random;
            spriteBatch=Rabcr.spriteBatch;

            TextureAdbBlock=GetDataTexture("Blocks/Advanced/AdvancedSpaceBlok");
            TextureAdvBackBlock=GetDataTexture("Blocks/Advanced/AdvancedSpaceBack");
            TextureAdvFloor=GetDataTexture("Blocks/Advanced/AdvancedSpaceFloor");
            TextureAdvWindow=GetDataTexture("Blocks/Advanced/AdvancedSpaceWindow");
            textureSlot=GetDataTexture("Inventories/Slot");

        //    pixel = new Texture2D(Graphics, 1, 1);
       //     pixel.SetData(new[] { Color.White });
         //   back=new Background(Content,Graphics);
            //path = plW;
            //zoom = 0.25f;
            //Content = content;
            //spriteFont = sf;
            //Pixel = pixel;

          //  stars=new List<Star>();
          //  asteroidB =new List<Planet>();
           // asteroidK=new List<Planet>();
          //  random =new Random();
            spriteFont_small=Fonts.Small;
            buttonClose=new ImgButton(GetDataTexture("Buttons/Square/Close"));
            buttonGoUp=new GameButtonMedium(Textures.ButtonRight/*,Fonts.Medium, Fonts.Big*/);
            //addStation=new Button(GetDataTexture(@"Buttons\Menu\Right"),GetDataFont(@"Medium"), GetDataFont(@"Big"));
            //buttonGoUp.Text="Zpět";
            spriteFont_medium=Fonts.Medium;
            buttonCenter =GetDataTexture(@"Buttons\Other\ToSelected");
            buttonAround=GetDataTexture(@"Buttons\Other\Move");
            buttonLand=new GameButtonMedium(Textures.ButtonRight/*,Fonts.Medium, Fonts.Big*/);
            buttonCreate=new GameButtonMedium(Textures.ButtonRight/*,Fonts.Medium, Fonts.Big*/);
            //SunTexture =GetDataTexture(@"Space\Sun");
            //rocketTexture =GetDataTexture(@"Blocks\ForInventory\Rocket");
            File.WriteAllText(pathToWorld+"LastWorld.txt","Space");
sun=new GeneratePlanetSystem().SunSystem();

            //mercur=new Planet(1950, 0.000003393098f, 0.2f, GetDataTexture(@"Space\Mercur"), random/*,0.3f*/);
            //venus=new Planet(4000, 0.000002482270565f, 0.01f, GetDataTexture(@"Space\Venus"), random/*,4.8675f*/);
            //earth=new Planet(5900, 0.000002181732953f, 0.01f, GetDataTexture(@"Space\Earth"), random/*,6*/);
            //mars=new Planet(8500, 0.000001706614175f, 0.2f, GetDataTexture(@"Space\Mars"), random/*,0.6f*/);
            //jupiter=new Planet(15000, 0.0000009264213675f/4, 0.2f, GetDataTexture(@"Space\Jupiter"), random/*,898*/);
            //saturn=new Planet(30000, 0.0000006868418554f/4, 0.1f, GetDataTexture(@"Space\Saturn"), random/*,568*/);
            //uran=new Planet(50000, 0.0000004827031f/4, 0.1f, GetDataTexture(@"Space\Uran"), random/*,86*/);
            //neptun=new Planet(70000, 0.0000003848866125f/2, 0.01f, GetDataTexture(@"Space\Neptun"), random/*,102*/);
            //pluto=new Planet(80000, 0.000000331016663f/2, 0.4f, GetDataTexture(@"Space\Pluto"), random/*,0.013f*/);
            //moon=new Planet(400, 0.000009f, 0.001f, GetDataTexture(@"Space\Moon"), random/*,0.073f)*/);
            //station=new Planet(150, 0.000009f, 0.001f*2, GetDataTexture(@"Space\SpaceStation"), random/*,0.073f)*/);
            //io=new Planet(422, OrbitalSpeed(17), 0.001f, GetDataTexture(@"Space\Io"), random/*,0.09f)*/);
            //europa =new Planet(671, OrbitalSpeed(13), 0.001f, GetDataTexture(@"Space\Europa"), random/*,0.05f*/);
            //galimedes=new Planet(1070, OrbitalSpeed(11), 0.001f, GetDataTexture(@"Space\Galimedes"), random/*,0.15f*/);
            //callisto =new Planet(1883, OrbitalSpeed(8), 0.001f, GetDataTexture(@"Space\Callisto"), random/*,0.1f*/);
            //titan=new Planet(1221, OrbitalSpeed(5.5f), 0.001f, GetDataTexture(@"Space\Titan"), random/*,0.13f*/);
            //triton=new Planet(455, OrbitalSpeed(4.39f)/2, 0.001f, GetDataTexture(@"Space\Triton"), random/*,0.02f*/);
            //for (int i = 1; i<10; i++) {
            //    asteroidB.Add(new Planet(10000, OrbitalSpeed(0.0001f), 0.2f, GetDataTexture(@"Space\Asteroids\asteroid"+i.ToString()), random));
            //    asteroidK.Add(new Planet(80000, OrbitalSpeed(0.001f), 0.2f, GetDataTexture(@"Space\Asteroids\K_asteroid"+i.ToString()), random));
            //}

         //   movemer =new MyTrackBar(GetDataTexture(@"Buttons\Setting\TrackBar\Line"),GetDataTexture(@"Buttons\Setting\TrackBar\Movemer")/*Content, zoom, new Vector2(848-64-32-32-128-16, 32+8)*/);
          //  popUpMenu=new PopUpMenu(worlds, 300, spriteFont);
            //camera=new Camera();
            //line=new Line(Vector2.Zero, Vector2.Zero, Color.Red, pixel);

           // rocketPos =earth.Position;
          //  selectedPos=rocketPos;

            //int mx = 1000;
            //while (mx!=0) {
            //    if (random.Next(6)==1) stars.Add(new Star(5000-random.Next(10000), 5000-random.Next(10000), Color.LightBlue));
            //    else if (random.Next(5)==1) stars.Add(new Star(5000-random.Next(10000), 5000-random.Next(10000), Color.LightGreen));
            //    else if (random.Next(4)==1) stars.Add(new Star(5000-random.Next(10000), 5000-random.Next(10000), Color.Red));
            //    else if (random.Next(3)==1) stars.Add(new Star(5000-random.Next(10000), 5000-random.Next(10000), Color.Orange));
            //    else if (random.Next(2)==1) stars.Add(new Star(5000-random.Next(10000), 5000-random.Next(10000), Color.White));
            //    else stars.Add(new Star(5000-random.Next(10000), 5000-random.Next(10000), Color.Yellow));
            //    mx--;
            //}

            Load();
            //buttonOpenPanel=new Button(GetDataTexture("Buttons/Menu/Right"), spriteFont, spriteFont) {
            //    Text="Zobrazit podrobnosti",
            //    center=true
            //};
          //  windowPosition.X=-Global.WindowWidthHalf;windowPosition.Y=-Global.WindowHeightHalf;
            InitForeachAo(sun,0);
            SetAOTextures(sun);
          displayed=Displayed.SolarSystem;

            //buttonLand.center=true;
            //    buttonCreate.center=true;
            //  buttonGoUp.center=true;
            SetUpTexts();
            if (Global.WorldDifficulty==2) {
                for (int i = 0; i<600; i++) Inventory.Add(new DInt());
            } else for (int i = 0; i<200; i++) Inventory.Add(new DInt());

            Console.WriteLine(pathToWorld+@"\Inventory.txt");
              if (File.Exists(pathToWorld+@"\Inventory.txt")) {Console.WriteLine("txt");
                using (StreamReader sr = new StreamReader(pathToWorld+@"\Inventory.txt")) {
                    foreach (DInt x in Inventory) {
                       x.X= int.Parse(sr.ReadLine());
                       x.Y= int.Parse(sr.ReadLine());
                    }
                }
            }
          //   ForeachPreAo(sun,0,0); ForeachPostAo(sun);

        }
        bool ok;
        void SetAOTextures(AstronomicalObject[] o) {

            foreach (AstronomicalObject x in o){
                if (!x.Builded){ if (File.Exists(pathToWorld+@"\Builded"+x.NameEn+".txt")) x.Builded=true;}
                if (x.Builded){
                    if (string.IsNullOrEmpty(x.NameEn)) x.texture=GetDataTexture("Space/"+x.NameCz);
                    else x.texture=GetDataTexture("Space/"+x.NameEn);
                }else{

                    x.texture=GetDataTexture("Menu/Styles/Find");
                }
                //x.Size=(int)(10.5f+(Math.Log(x.MeanDiameter,1.0005d)+1)/1000d+(x.MeanDiameter/5500f));
                if (x.Childs!=null) SetAOTextures(x.Childs);


                x.Aphelion = (x.fakeSemiMajorAxis+x.fakeSemiMajorAxis*x.Eccentricity)*Math.Cos(x.Inclination);
                x.Perihelion = x.fakeSemiMajorAxis-x.fakeSemiMajorAxis*x.Eccentricity;
                //x.Delta = x.Perihelionx.Aphelion-;
                x.elipse=new Ellipsoid(x);
            }
        }

         void ForeachPreAo(AstronomicalObject[] o, double parentX, double parentY) {
            foreach (AstronomicalObject x in o){

              //  x.CurrentTime+=x.Speed/(1000*60*20d);// cca den==20min

                 // x.Size=(int)(x.MeanDiameter*zoom);//
                //if (x.Size<5)
                    x.Size=(Math.Pow(x.MeanDiameter,0.3f)/1d)/**(Math.Log(1+zoom,1.0005f)/4)*//*Math.Log(x.MeanDiameter,1.0005d)*/+2;
             //   Console.WriteLine(x.MeanDiameter*zoom+" "+zoom);
             //  (int)(x.MeanDiameter*zoom);//
                Double2 p=x.GetPos();

                x.PositionX=p.X+parentX;
                x.PositionY=p.Y+parentY;
                x.dis=Vector2.Distance(new Vector2((float)x.PositionX,(float)x.PositionY),new Vector2((float)parentX,(float)parentY));
//x.Visible=x.dis>10f || x.NameCz=="Slunce";

           //    Console.WriteLine(x.Visible);


               // int size=(int)(10.5f+(Math.Log(x.MeanDiameter,1.0005d)+1)/1000d+(x.MeanDiameter/5500f));
             //   double posX=p.X+pX,posY=p.Y+pY;

                if (x.Childs!=null) ForeachPreAo(x.Childs,x.PositionX,x.PositionY);
 //if (popUpMenu.select==x.NameCz) windowPosition=new Vector2((float)(x.PositionX-Global.WindowWidthHalf),(float)(x.PositionY-Global.WindowHeightHalf));
               // x.Position=new Vector2((float)posX,(float)posY);



            }


        }

 //        void ForeachPostAo(AstronomicalObject[] o) {
 //           foreach (AstronomicalObject x in o){

 //               if (x.Childs!=null) ForeachPostAo(x.Childs);
 //if (SidePanel){
 //                if (popUpMenu.select==x.NameCz) windowPosition=new Double2(x.PositionX-Global.WindowWidthHalf-SidePanelSize/2d,x.PositionY-Global.WindowHeightHalf);
 //                   }else{
 //               if (popUpMenu.select==x.NameCz) windowPosition=new Double2(x.PositionX-Global.WindowWidthHalf,x.PositionY-Global.WindowHeightHalf);
 //               }
 //           }
 //       }

        public override void Update(GameTime gameTime) {
            oldMouseState=newMouseState;
            //oldKeyboardState=newKeyboardState;
            newKeyboardState = Keyboard.GetState();
            newMouseState = Mouse.GetState();

            MousePos.mouseRealPosX=newMouseState.X;
            MousePos.mouseRealPosY=newMouseState.Y;
            MousePos.mouseLeftDown=newMouseState.LeftButton==ButtonState.Pressed;
            MousePos.mouseLeftRelease=!MousePos.mouseLeftDown && oldMouseState.LeftButton==ButtonState.Pressed;
            //mousePos = new Double2(newMouseState.X+windowPosition.X,newMouseState.Y+windowPosition.Y);

            //mousePos = new Double2((newMouseState.X-Global.WindowWidth/2)/zoom+windowPosition.X,(newMouseState.Y-Global.WindowHeight/2)/zoom+windowPosition.Y);
            //mouse=newMouseState.LeftButton==ButtonState.Pressed;
            ForeachPreAo(sun,0,0);// if (popUpMenu.select==o.NameCz) windowPosition=new Vector2(drawingRec.X-Global.WindowWidthHalf,drawingRec.Y-Global.WindowHeightHalf);

            if (buttonClose.Update()){
                dialogLand=false;
                }
            if (buttonGoUp.Update()){
                displayed=Displayed.SolarSystem;
                selectedAO="";
                }

            if (dialogLand){
                if (buttonLand.Update()){
                    File.WriteAllText(pathToWorld+"LastWorld.txt",GetAOByName(potencialLand,sun).NameEn);
                   // File.WriteAllText(pathToWorld+"UseRocket.txt","");
                    Rabcr.GoTo(new SinglePlayer(pathToWorld));

                }
                if (buttonCreate.Update()){
                    if (ok){
                    InventoryRemove((int)Items.AdvancedSpaceBlock,99);
                    InventoryRemove((int)Items.AdvancedSpaceBack,64);
                    InventoryRemove((int)Items.AdvancedSpaceFloor,38);
                    InventoryRemove((int)Items.AdvancedSpaceWindow,8);

                     using (StreamWriter sr = new StreamWriter(pathToWorld+@"\Inventory.txt")) {
                        foreach (DInt x in Inventory) {
                            sr.WriteLine(x.X);
                            sr.WriteLine(x.Y);
                        }
                    }
                   File.WriteAllText(pathToWorld+@"\Builded"+potencialLand+".txt","");
                  GetAOByName(potencialLand,sun).Builded=true;
                        GenerateSpaceStation();


                    }
                    }
            }
            //if (buttonOpenPanel.Click){
            //    if (SidePanel) {
            //        SidePanel=false;
            //        buttonOpenPanel.Text="Zobrazit podrobnosti";
            //    } else {
            //        SidePanel=true;
            //        buttonOpenPanel.Text="Skrýt podrobnosti";
            //    }
            //}

            //if (zoom != movemer.Value) {
            //    double z=movemer.Value;
            //    //if (zoom<0.000000000000005) zoom=0.000000000000005f;
            //    if (z>1) z=1;
            //    z=Math.Pow(10d,-z*10d);

            //    if (z!=zoom)ChangeZoom(z);
            //}

            //if (oldMouseState.LeftButton==ButtonState.Pressed) {
            //    if (newMouseState.LeftButton==ButtonState.Released) {
            //        if (!popUpMenu.show) {
            //            if (!click) {
            //                if (newMouseState.X<Global.WindowWidth-165||newMouseState.Y<100||newMouseState.X>popUpMenu.width+Global.WindowWidth-165||newMouseState.Y>popUpMenu.hs+100) {

            //                    if (newMouseState.X<Global.WindowWidth-286||newMouseState.Y>99) {// if (newMouseState.X<848-64-32-32-128-16-64 || newMouseState.Y>32+8+8+32 || newMouseState.X>848-64-32-32-128-16+152+64) {
            //                        if (newMouseState.X>200||newMouseState.Y>100) {
            //                            if (newMouseState.X>0&&newMouseState.X<Global.WindowWidth&&newMouseState.Y>0&&newMouseState.Y<Global.WindowHeight) {
            //                                selectedPos.X=(newMouseState.X+windowPosition.X)/zoom;
            //                                selectedPos.Y=(newMouseState.Y+windowPosition.Y)/zoom;
            //                                fly=true;
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //AstronomicalObject ao=GetAOByName("Země",sun);
            //rocketPos=new Double2(ao.PositionX,ao.PositionY);
            //if (fly) {
            //    if (rocketPos!=selectedPos) {

            //        double distance=Double2.Distance(rocketPos, selectedPos);
            //        if (distance>1) {

            //            rocketPos.X+=(rocketPos.X-selectedPos.X)/distance*0.05f;
            //            rocketPos.Y+=(rocketPos.Y-selectedPos.Y)/distance*0.05f;
            //        } else fly=false;
            //    }
            //}

            //if (newKeyboardState.IsKeyDown(Keys.Space)) {
            //    if (oldKeyboardState.IsKeyUp(Keys.Space)) fly=false;
            //}

            //if (newKeyboardState.IsKeyDown(Keys.Add)) {
            //    double z=zoom;

            //    z*=1.005f;
            //    if (z>1) z=1;
            // //   movemer.Value=z;

            //    ChangeZoom(z);
            //}
            //if (newKeyboardState.IsKeyDown(Keys.Subtract)) {
            //    double z=zoom;
            //    z/=1.005f;
            //    if (z<0.005f)z=0.005f;
            //  //  movemer.Value=z;

            //    ChangeZoom(z);
            //}

          //  popUpMenu.Update(new Vector2(Global.WindowWidth-165, 100), newMouseState, oldMouseState);

            #region Update planets
            //mercur.Update();
            //venus.Update();
            //earth.Update();
            //mars.Update();
            //jupiter.Update();
            //saturn.Update();
            //uran.Update();
            //neptun.Update();
            //pluto.Update();
            //triton.Update();
            //moon.Update();
            //europa.Update();
            //io.Update();
            //titan.Update();
            //galimedes.Update();
            //callisto.Update();
            //station.Update();
            //callisto.Center=jupiter.Position;
            //io.Center=jupiter.Position;
            //europa.Center=jupiter.Position;
            //galimedes.Center=jupiter.Position;
            //moon.Center=earth.Position;
            //titan.Center=saturn.Position;
            //triton.Center=neptun.Position;
            //station.Center=earth.Position;

            //foreach (Planet a in asteroidK)
            //    a.Update();
            //foreach (Planet a in asteroidB)
            //    a.Update();
            #endregion

            #region Move camera
            if (newKeyboardState.IsKeyDown(Keys.Left)) {
                windowPosition.X-=5;
            }
            if (newKeyboardState.IsKeyDown(Keys.Right)) {
                windowPosition.X+=5;
            }
            if (newKeyboardState.IsKeyDown(Keys.Up)) {
                windowPosition.Y-=5;
            }
            if (newKeyboardState.IsKeyDown(Keys.Down)) {
                windowPosition.Y+=5;
            }
            #endregion

          //  line.Point1=rocketPos.toVector();
           // line.Point2=selectedPos.toVector();
            //line.Refresh(1);

            #region To Obrit
            //canOrbit=null;
            //Orbit(earth);
            //Orbit(moon);
            //Orbit(mars);
            //Orbit(venus);
            //Orbit(mercur);
            //Orbit(station);
            #endregion

            #region Menu
          //  if (popUpMenu.select!="<nepřipoutáno>") {
               // if (popUpMenu.select=="<Raketa>")
                //    windowPosition=rocketPos;
                //if (popUpMenu.select=="Slunce")
                //    windowPosition=Vector2.Zero;
                //if (popUpMenu.select=="Merkur")
                //    windowPosition=mercur.Position;
                //if (popUpMenu.select=="Venuše")
                //    windowPosition=venus.Position;
                //if (popUpMenu.select=="Země")
                //    windowPosition=earth.Position;
                //if (popUpMenu.select=="Měsíc")
                //    windowPosition=moon.Position;
                //if (popUpMenu.select=="Mars")
                //    windowPosition=mars.Position;
                //if (popUpMenu.select=="Pás asteroidů")
                //    windowPosition=mars.Position;
                //if (popUpMenu.select=="Jupiter")
                //    windowPosition=jupiter.Position;
                //if (popUpMenu.select=="Io")
                //    windowPosition=io.Position;
                //if (popUpMenu.select=="Callisto")
                //    windowPosition=callisto.Position;
                //if (popUpMenu.select=="Europa")
                //    windowPosition=europa.Position;
                //if (popUpMenu.select=="Galimedes")
                //    windowPosition=galimedes.Position;
                //if (popUpMenu.select=="Saturn")
                //    windowPosition=saturn.Position;
                //if (popUpMenu.select=="Titan")
                //    windowPosition=titan.Position;
                //if (popUpMenu.select=="Uran")
                //    windowPosition=uran.Position;
                //if (popUpMenu.select=="Neptun")
                //    windowPosition=neptun.Position;
                //if (popUpMenu.select=="Triton")
                //    windowPosition=triton.Position;
                //if (popUpMenu.select=="Kuiperův pás")
                //    windowPosition=triton.Position;
                //if (popUpMenu.select=="Pluto")
                //    windowPosition=pluto.Position;
                //if (popUpMenu.select=="Vesmírná stanice")
                //    windowPosition=station.Position;
         //   }
            #endregion
            //  movemer.Up(new Vector2(newMouseState.X, newMouseState.Y));
    //ForeachPostAo(sun);
            //oldKeyboardState=newKeyboardState;
            //oldMouseState=newMouseState;
        }

        void InventoryRemove(int x, int y) {
            int needToRemove=y;

            foreach (DInt i in Inventory){
                if (i.X==x) {
                    if (i.Y<needToRemove){
                        needToRemove-=i.Y;
                        i.Y=0;
                        i.X=0;
                    } else if (needToRemove==i.Y) {
                        i.Y=0;
                        needToRemove=0;
                        i.X=0;
                        return;
                    } else {
                        int z=i.Y;
                        i.Y-=needToRemove;
                        needToRemove+=z;
                        return;
                    }
                }
            }
        }

        //void ChangeZoom(double newZoom) {
        //    //Double2 w=windowPosition.Clone();
        ////    double oldZoom=zoom;
        //   if (newZoom!=zoom){

        //      //  Console.WriteLine(windowPosition.X+" "+windowPosition.Y);
        //        Double2 centerScreen = new Double2(windowPosition.X+Global.WindowWidthHalf, windowPosition.Y+Global.WindowHeightHalf);
        //      //  double disBef = Math.Sqrt(centerScreen.X*centerScreen.X+centerScreen.Y*centerScreen.Y);
        //        //double disAf = disBef*newZoom;
        //        double deltaZoom=newZoom/zoom;
        //        Double2 newCenter=new Double2(centerScreen.X*deltaZoom,centerScreen.Y*deltaZoom);
        //        windowPosition=new Double2(newCenter.X-Global.WindowWidthHalf,newCenter.Y-Global.WindowHeightHalf);
        //        //windowPosition.X+=windowPosition.X*(newZoom-zoom);
        //        //windowPosition.Y+=windowPosition.Y*(newZoom-zoom);
        //        zoom=newZoom;
        //        movemer.Value=-Math.Log(zoom)/(10*Math.Log(10));
        //     //   Console.WriteLine(windowPosition.X+" "+windowPosition.Y);
        //    }
        //}

        public override void Draw(GameTime gameTime) {

            /*> Space <*/
            spriteBatch.Begin(/*SpriteSortMode.BackToFront, BlendState.NonPremultiplied, null, null, null, null,
                 Matrix.CreateTranslation(new Vector3(-windowPosition.X, -windowPosition.Y, 0))
               *Matrix.CreateScale(zoom, zoom, 0)*
                Matrix.CreateTranslation(new Vector3(Global.WindowWidth/2, Global.WindowHeight/2, zoom))*/);
            spriteBatch.GraphicsDevice.Clear(Color.Black);
            //foreach (Star s in stars) spriteBatch.Draw(pixel, s.position, s.color);

            #region Draw Planets
          //  spriteBatch.Draw(SunTexture, new Vector2(-256, -256), Color.White);

        //   windowPosition=new Vector2()
              //spriteBatch.Draw(SunTexture,new Rectangle(-(int)sun.MeanDiameter,-(int)sun.MeanDiameter,(int)sun.MeanDiameter*2,(int)sun.MeanDiameter*2),Color.White);
                //spriteBatch.DrawString(spriteFont,sun.Name,new Vector2(-(int)sun.MeanDiameter,-(int)sun.MeanDiameter),Color.White,0,Vector2.Zero, 1000, SpriteEffects.None,1);
            if (displayed==Displayed.SolarSystem){
                //DrawObjects(sun,0,0);
                //DrawObjects(sun[0].Childs,0,0);
                DrawObjectsSunSystem();
            }
            if (displayed==Displayed.PlanetSystem){
                //AstronomicalObject ao=GetAOByName(selectedAO,sun);
                //DrawObjects(new AstronomicalObject[]{ao },0,0);
                //DrawObjects(ao.Childs,0,0);,
                DrawObjectsPlanetSystem();

                buttonGoUp.ButtonDraw(/*spriteBatch,newMouseState.LeftButton==ButtonState.Pressed,new DInt(newMouseState.X,newMouseState.Y)*/);
            }
            //mercur.Draw(spriteBatch);
            //venus.Draw(spriteBatch);
            //earth.Draw(spriteBatch);
            //mars.Draw(spriteBatch);
            //jupiter.Draw(spriteBatch);
            //saturn.Draw(spriteBatch);
            //uran.Draw(spriteBatch);
            //neptun.Draw(spriteBatch);
            //triton.Draw(spriteBatch);
            //pluto.Draw(spriteBatch);
            //moon.Draw(spriteBatch);
            //europa.Draw(spriteBatch);
            //io.Draw(spriteBatch);
            //callisto.Draw(spriteBatch);
            //galimedes.Draw(spriteBatch);
            //titan.Draw(spriteBatch);
            //station.Draw(spriteBatch);
            //foreach (Planet a in asteroidK) a.Draw(spriteBatch);
            //foreach (Planet a in asteroidB) a.Draw(spriteBatch);
            #endregion


          //  mousePos
          //  if (fly) line.Draw(spriteBatch);
 //spriteBatch.Draw(rocketTexture,new Vector2((float)(mousePos.X*zoom),(float)(mousePos.Y*zoom)), Color.White);

           // spriteBatch.Draw(rocketTexture, new Rectangle((int)rocketPos.X, (int)rocketPos.Y, rocketTexture.Width, rocketTexture.Height), null, Color.White, (float)XCV(), new Vector2(rocketTexture.Width/2, rocketTexture.Height/2), SpriteEffects.None, 0);


            //new Line(new Vector2((float)(rocketPos.X-windowPosition.X),(float)(rocketPos.Y-windowPosition.Y)),new Vector2((float)(selectedPos.X*zoom-windowPosition.X),(float)(selectedPos.Y*zoom-windowPosition.Y)),Color.Gray,Rabcr.Pixel).Draw(spriteBatch);

            spriteBatch.End();


            /*> GUI <*/
            spriteBatch.Begin();


            #region Buttons
            //click =false;

            if (MouseInRectangle(new Rectangle(Global.WindowWidth+720-784, 5, 32, 32-5))) {
                if (newMouseState.LeftButton==ButtonState.Pressed) {
                    spriteBatch.Draw(buttonAround, new Vector2(Global.WindowWidth+720-784, 5), Color.Gray);
                    windowPosition.Y-=5/*/zoom*/;
                 //   click=true;
                } else spriteBatch.Draw(buttonAround, new Vector2(Global.WindowWidth+720-784, 5), Color.LightGray);
            } else spriteBatch.Draw(buttonAround, new Vector2(Global.WindowWidth+720-784*(Global.WindowWidth/848), 5*(Global.WindowHeight/560)), Color.White);

            if (MouseInRectangle(new Rectangle(Global.WindowWidth+720-784+32, 32, 32-5, 32))) {
                if (newMouseState.LeftButton==ButtonState.Pressed) {
                    spriteBatch.Draw(buttonAround, new Rectangle(Global.WindowWidth+720-784+32+32-5, 32, 32, 32), null, Color.Gray, 1.570796327f, Vector2.Zero, SpriteEffects.None, 0);
                    windowPosition.X+=5/*/zoom*/;
                  //  click=true;
                } else spriteBatch.Draw(buttonAround, new Rectangle(Global.WindowWidth+720-784+32+32-5, 32, 32, 32), null, Color.LightGray, 1.570796327f, Vector2.Zero, SpriteEffects.None, 0);
            } else spriteBatch.Draw(buttonAround, new Rectangle(Global.WindowWidth+720-784+32+32-5, 32, 32, 32), null, Color.White, 1.570796327f, Vector2.Zero, SpriteEffects.None, 0);

            if (MouseInRectangle(new Rectangle(Global.WindowWidth+720-784, 32+32, 32, 32-5))) {
                if (newMouseState.LeftButton==ButtonState.Pressed) {
                    spriteBatch.Draw(buttonAround, new Rectangle(Global.WindowWidth+720-784+32, 32+32+32-5, 32, 32), null, Color.Gray, 3.141592654f, Vector2.Zero, SpriteEffects.None, 0);
                    windowPosition.Y+=5/*/zoom*/;
                 //   click=true;
                } else spriteBatch.Draw(buttonAround, new Rectangle(Global.WindowWidth+720-784+32, 32+32+32-5, 32, 32), null, Color.LightGray, 3.141592654f, Vector2.Zero, SpriteEffects.None, 0);
            } else spriteBatch.Draw(buttonAround, new Rectangle(Global.WindowWidth+720-784+32, 32+32+32-5, 32, 32), null, Color.White, 3.141592654f, Vector2.Zero, SpriteEffects.None, 0);

            if (MouseInRectangle(new Rectangle(Global.WindowWidth+720-784-32, 32, 32-5, 32))) {
                if (newMouseState.LeftButton==ButtonState.Pressed) {
                    spriteBatch.Draw(buttonAround, new Rectangle(Global.WindowWidth+720-784-32+5, 32+32, 32, 32), null, Color.Gray, 4.71238898f, Vector2.Zero, SpriteEffects.None, 0);
                    windowPosition.X-=5/*/zoom*/;
                    //click=true;
                } else spriteBatch.Draw(buttonAround, new Rectangle(Global.WindowWidth+720-784-32+5, 32+32, 32, 32), null, Color.LightGray, 4.71238898f, Vector2.Zero, SpriteEffects.None, 0);
            } else spriteBatch.Draw(buttonAround, new Rectangle(Global.WindowWidth+720-784-32+5, 32+32, 32, 32), null, Color.White, 4.71238898f, Vector2.Zero, SpriteEffects.None, 0);

            if (MouseInRectangle(new Rectangle(Global.WindowWidth+720-784, 32, 32, 32))) {
                spriteBatch.Draw(buttonCenter, new Vector2(Global.WindowWidth+720-784, 32), Color.LightGray);
                if (newMouseState.LeftButton==ButtonState.Pressed){
                       windowPosition=new Double2(0,0);
                }
                //    fly =false;
              //  click=true;
            } else spriteBatch.Draw(buttonCenter, new Vector2(Global.WindowWidth+720-784, 32), Color.White);
            #endregion

         //   if (fly) DrawX(spriteBatch, (int)((selectedPos.X-windowPosition.X)*zoom+Global.WindowWidth/2), (int)((selectedPos.Y-windowPosition.Y)*zoom+Global.WindowHeight/2));

            //popUpMenu.Draw(spriteBatch);
            //movemer.Draw(spriteBatch,Global.WindowWidth-64-32-32-128-16, 32+8,newMouseState,oldMouseState);

            //if (canOrbit!=null) {
            //    DrawMessageOrbit(spriteBatch);
            // //   buttonOrbit.ButtonDraw(spriteBatch, newMouseState, new Vector2(newMouseState.X, newMouseState.Y), new Vector2(30, 50));
            //    spriteBatch.DrawString(spriteFont, "Přistát", new Vector2(70, 53), Color.Black);

            //    if (buttonOrbit.Click) {
            //        //go to planet -> X
            //    }
            ////}
            //if (SidePanel){

            //    AstronomicalObject a=GetAOByName(popUpMenu.select,sun);

            //    if (a!=null) {
            //        spriteBatch.Draw(Rabcr.Pixel,new Rectangle(0, 0, SidePanelSize, Global.WindowHeight), new Color(255, 255, 255, 200));
            //       // spriteBatch.DrawString(spriteFont, popUpMenu.select, new Vector2(20, 50), Color.Black);

            //        spriteBatch.Draw(a.texture, new Rectangle(SidePanelSize/2-20, 10, 50, 50), Color.White);

            //        spriteBatch.DrawString(spriteFont,
            //            "Název: "+a.NameCz+ ((string.IsNullOrEmpty(a.NameEn) && string.IsNullOrEmpty(a.NameCz) && a.NameEn!=a.NameCz) ? " ("+a.NameEn+")" : "") +Environment.NewLine+
            //            "Střední vzdálenost: "+a.SemiMajorAxis.ToString("G5")+"km"+Environment.NewLine+
            //            "Aphelium: "+a.Aphelion.ToString("G5")+"km"+Environment.NewLine+
            //            "Perihelium: "+a.Perihelion.ToString("G5")+"km"+Environment.NewLine+
            //            "Oběžná doba: "+a.OrbitalPeriod.ToString("G5")+"dnů"+Environment.NewLine+
            //            "Oběhnuto: "+((a.CurrentTime/a.OrbitalPeriod)*100).ToString("G5")+"%"+Environment.NewLine+
            //            "Rychlost: "+a.Speed.ToString("G5")+"km/s"+Environment.NewLine+
            //            "Poloměr: "+a.MeanDiameter.ToString("G5")+"km"+Environment.NewLine+
            //            "Průměr: "+(a.MeanDiameter*2).ToString("G5")+"km"+Environment.NewLine+
            //            "Hmotnost: "+a.Mass.ToString("G5")+"kg"+Environment.NewLine+
            //            "Pootočení dráhy: "+a.LongitudeOfAscendingNode+"rad"+Environment.NewLine+
            //            "Sklon: "+a.Inclination+"rad"+Environment.NewLine+
            //            "Excentricita: "+a.Eccentricity+Environment.NewLine+
            //            "Satelity: "+a.GetNamesChilds(), new Vector2(20, 20+40), Color.Black);
            //        } else {
            //         spriteBatch.Draw(Rabcr.Pixel,new Rectangle(0, 0, SidePanelSize, Global.WindowHeight), new Color(255, 255, 255, 200));
            //         spriteBatch.DrawString(spriteFont, "Vyberte objekt", new Vector2(20, 50), Color.Black);
            //    }

            //    //buttonOpenPanel.ButtonDraw(spriteBatch, newMouseState,new Vector2(newMouseState.X, newMouseState.Y), new Vector2(20, Global.WindowHeight-50));
            //} else {
            //    buttonOpenPanel.ButtonDraw(spriteBatch, newMouseState,new Vector2(newMouseState.X, newMouseState.Y), new Vector2(0, 0));
            //}

            if (dialogLand){
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), color_r0_g0_b0_a100);

                DrawFrame(Global.WindowWidthHalf-150-2, Global.WindowHeightHalf-134,304,264+2,1, color_r0_g0_b0_a100);
                DrawFrame(Global.WindowWidthHalf-150-1, Global.WindowHeightHalf-133,302,264,1, color_r0_g0_b0_a200);
                spriteBatch.Draw(Rabcr.Pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-132,300,34), color_r10_g140_b255);
                spriteBatch.Draw(Rabcr.Pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-98,300,230), Color.LightBlue);

                buttonClose.ButtonDraw(/*spriteBatch,newMouseState.X,newMouseState.Y,Global.WindowWidthHalf+150-32,Global.WindowHeightHalf-132+1,newMouseState.LeftButton==ButtonState.Pressed*/);

                AstronomicalObject o=GetAOByName(potencialLand,sun);
                    DrawTextShadowMin(Global.WindowWidthHalf-150-2+12, Global.WindowHeightHalf-125, /*Setting.czechLanguage ? o.NameCz :*/ o.NameEn);
                 //   spriteBatch.Draw(rocketTexture,new Rectangle(Global.WindowWidthHalf-62, Global.WindowHeightHalf-190,123,380), Color.White);
                string type="";
                switch (o.astrO){
                    case AstrO.Star:type="ke Slunci"; break;
                    case AstrO.Gas:type="k plynnému obru"; break;
                    case AstrO.Life:type="k životaschopné planetě"; break;
                    case AstrO.Lava:type="k horké planetě"; break;
                    case AstrO.Rocky:type="ke kamenné planetě"; break;
                    case AstrO.IceRocky:type="ke zmrzlé planetce"; break;
                    case AstrO.MoonRocky:type="ke kamennému měsíci"; break;
                }
                if (o.Builded) {
                    DrawTextShadowMin(Global.WindowWidthHalf-150-2+12, Global.WindowHeightHalf-90, "Chcete přiletnout\r\n   "+type+"?");
                    if (CanGenerateWorld(potencialLand)) {
                        buttonLand.Position=new Vector2(Global.WindowWidthHalf-buttonLand.texture.Width/2, Global.WindowHeightHalf-98+230-buttonLand.texture.Height-5);
                        buttonLand.ButtonDraw(/*spriteBatch, newMouseState.LeftButton==ButtonState.Pressed, new DInt(newMouseState.X,newMouseState.Y)*/);
                    } else {
                        DrawTextShadowMin(Global.WindowWidthHalf-buttonLand.texture.Width/2, Global.WindowHeightHalf-98+230-buttonLand.texture.Height-5, "Na tuto planetu nelze letět");
                    }
                }else{
                    DrawTextShadowMin(Global.WindowWidthHalf-150-2+12, Global.WindowHeightHalf-90, "Tento objekt je třeba postavit z:");
                    ok=true;
                    DrawInv(Global.WindowWidthHalf-150+10+64, Global.WindowHeightHalf-98+8+64,99,TextureAdbBlock,(int)Items.AdvancedSpaceBlock);
                    DrawInv(Global.WindowWidthHalf-150+10+64+40, Global.WindowHeightHalf-98+8+64,64,TextureAdvBackBlock,(int)Items.AdvancedSpaceBack);
                    DrawInv(Global.WindowWidthHalf-150+10+64+40+40, Global.WindowHeightHalf-98+8+64,38,TextureAdvFloor,(int)Items.AdvancedSpaceFloor);
                    DrawInv(Global.WindowWidthHalf-150+10+64+40+40+40, Global.WindowHeightHalf-98+8+64,8,TextureAdvWindow,(int)Items.AdvancedSpaceWindow);

                    // spriteBatch.Draw(textureSlot, new Rectangle(Global.WindowWidthHalf-150+10+64+64, Global.WindowHeightHalf-98+8,32,32), Color.White);
                    //   TextureAdbBlock=GetDataTexture("Blocks/Advanced/AdvancedSpaceBlok");
                    //    TextureAdvBackBlock=GetDataTexture("Blocks/Advanced/AdvancedSpaceBack");
          //  TextureAdvFloor=GetDataTexture("Blocks/Advanced/AdvancedSpaceFloor");
          //  TextureAdvwindow=GetDataTexture("Blocks/Advanced/AdvancedSpaceWindow");

                    if (ok) {

                        if (CanGenerateWorld(potencialLand)) {
                            buttonCreate.Position=new Vector2(Global.WindowWidthHalf-buttonCreate.texture.Width/2, Global.WindowHeightHalf-98+230-buttonCreate.texture.Height-5);
                            buttonCreate.ButtonDraw(/*spriteBatch, newMouseState.LeftButton==ButtonState.Pressed, new DInt(newMouseState.X,newMouseState.Y)*/);
                        }
                    } else {
                        DrawTextShadowMin(Global.WindowWidthHalf-buttonCreate.texture.Width+20, Global.WindowHeightHalf-98+230-buttonCreate.texture.Height-5-20, "Nemáte dostatek materiálu\r\n   pro vytvoření");
                    }
                }
            }

            spriteBatch.End();
        }
      int TerrainLenght;
        void GenerateSpaceStation() {
            string[] file=File.ReadAllLines(pathToWorld+"\\Options.txt");
            TerrainLenght=  GetWorldSize( (GenerateWorld.WorldSize)int.Parse(file[1]));

            pos=0;

            //Prepare
            for (int i = 0; i<TerrainLenght; i++) terrain.Add(new GChunk());

         //   BiomeEmpty(624);

            BiomeEmpty(1500);
  //BiomeStation();
             BiomeEmpty(TerrainLenght);
            // Save
            //TerrainSave();
            //Save("Space station");
		///	File.WriteAllText(playedWorld + @"\Generated.txt", ((terrain.Count-7)).ToString());
		//	Finish=true;
          //  Console.WriteLine("Vygenerováno za "+(((DateTime.Now-now).TotalMilliseconds)/1000f).ToString(".000")+"s");
         //   Console.WriteLine("state "+state);
        }

        //void Save(string name) {
        // //   world++;
        //    using (FileStream stream= new FileStream(pathToWorld+"\\"+name+".ter", FileMode.Create, FileAccess.Write)) {
        //        for (int x=0; x<terrain.Count-7; x++) {
        //            List<byte> backBlocks=new List<byte>(),
        //                solidBlocks= new List<byte>(),
        //                topBlocks= new List<byte>();

        //            int backTotalValues=0, backLastValue=0,
        //                solidTotalValues = 0, solidLastValue=0,
        //                topTotalValues = 0, topLastValue=0;

        //            for (int i=0; i<125; i++) {

        //                // Back blocks
        //                {
        //                    ushort id=terrain[x].BackBlocks[i];
        //                    if (id!=backLastValue) {
        //                        if (backLastValue==0) {
        //                            if (backTotalValues>2) {
        //                                backBlocks.Add(1);
        //                                backBlocks.Add((byte)(backTotalValues-1));
        //                            } else {
        //                                for (int j=0; j<backTotalValues; j++) backBlocks.Add(0);
        //                            }
        //                        } else {
        //                            if (backTotalValues>3) {
        //                                backBlocks.Add(2);
        //                                backBlocks.Add((byte)(backTotalValues-1));
        //                                backBlocks.Add((byte)backLastValue);
        //                            } else {
        //                                for (int j=0; j<backTotalValues; j++) backBlocks.Add((byte)backLastValue);
        //                            }
        //                        }

        //                        backLastValue=id;
        //                        backTotalValues=1;
        //                    }else{
        //                        backTotalValues++;
        //                    }
        //                }

        //                // Solid blocks
        //                {
        //                    byte id=terrain[x].SolidBlocks[i];
        //                    if (id!=solidLastValue) {
        //                        if (solidLastValue==0) {
        //                            if (solidTotalValues>2){
        //                                solidBlocks.Add(1);
        //                                solidBlocks.Add((byte)(solidTotalValues-1));
        //                            } else {
        //                                for (int j=0; j<solidTotalValues; j++) solidBlocks.Add(0);
        //                            }
        //                        } else {
        //                            if (solidTotalValues>3) {
        //                                solidBlocks.Add(2);
        //                                solidBlocks.Add((byte)(solidTotalValues-1));
        //                                solidBlocks.Add((byte)solidLastValue);
        //                            } else {
        //                                for (int j=0; j<solidTotalValues; j++) solidBlocks.Add((byte)solidLastValue);
        //                            }
        //                        }

        //                        solidLastValue=id;
        //                        solidTotalValues=1;
        //                    }else{
        //                        solidTotalValues++;
        //                    }
        //                }

        //                // Top blocks
        //                {
        //                    byte id=terrain[x].TopBlocks[i];
        //                    if (id!=topLastValue) {
        //                        if (topLastValue==0) {
        //                            if (topTotalValues>2) {
        //                                topBlocks.Add(1);
        //                                topBlocks.Add((byte)(topTotalValues-1));
        //                            } else {
        //                                for (int j=0; j<topTotalValues; j++) topBlocks.Add(0);
        //                            }
        //                        } else {
        //                            if (topTotalValues>3) {
        //                                topBlocks.Add(2);
        //                                topBlocks.Add((byte)(topTotalValues-1));
        //                                topBlocks.Add((byte)topLastValue);
        //                            } else {
        //                                for (int j=0; j<topTotalValues; j++) topBlocks.Add((byte)topLastValue);
        //                            }
        //                        }

        //                        topLastValue=id;
        //                        topTotalValues=1;
        //                    }else{
        //                        topTotalValues++;
        //                    }
        //                }
        //            }


        //            if (backLastValue==0) {
        //                if (backTotalValues>2) {
        //                    backBlocks.Add(1);
        //                    backBlocks.Add((byte)(backTotalValues-1));
        //                } else {
        //                    for (int j = 0; j<backTotalValues; j++) backBlocks.Add(0);
        //                }
        //            } else {
        //                if (backTotalValues>3) {
        //                    backBlocks.Add(2);
        //                    backBlocks.Add((byte)(backTotalValues-1));
        //                    backBlocks.Add((byte)backLastValue);
        //                } else {
        //                    for (int j = 0; j<backTotalValues; j++) backBlocks.Add((byte)backLastValue);
        //                }
        //            }

        //            if (solidLastValue==0) {
        //                if (solidTotalValues>2) {
        //                    solidBlocks.Add(1);
        //                    solidBlocks.Add((byte)(solidTotalValues-1));
        //                } else {
        //                    for (int j = 0; j<solidTotalValues; j++) solidBlocks.Add(0);
        //                }
        //            } else {
        //                if (solidTotalValues>3) {
        //                    solidBlocks.Add(2);
        //                    solidBlocks.Add((byte)(solidTotalValues-1));
        //                    solidBlocks.Add((byte)solidLastValue);
        //                } else {
        //                    for (int j = 0; j<solidTotalValues; j++) solidBlocks.Add((byte)solidLastValue);
        //                }
        //            }

        //            if (topLastValue==0) {
        //                if (topTotalValues>2) {
        //                    topBlocks.Add(1);
        //                    topBlocks.Add((byte)(topTotalValues-1));
        //                } else {
        //                    for (int j = 0; j<topTotalValues; j++) topBlocks.Add(0);
        //                }
        //            } else {
        //                if (topTotalValues>3) {
        //                    topBlocks.Add(2);
        //                    topBlocks.Add((byte)(topTotalValues-1));
        //                    topBlocks.Add((byte)topLastValue);
        //                } else {
        //                    for (int j = 0; j<topTotalValues; j++) topBlocks.Add((byte)topLastValue);
        //                }
        //            }

        //            stream.WriteByte(terrain[x].LightPos);

        //            stream.Write(backBlocks.ToArray(),0,backBlocks.Count);
        //            stream.Write(solidBlocks.ToArray(),0,solidBlocks.Count);
        //            stream.Write(topBlocks.ToArray(),0,topBlocks.Count);

        //            stream.Write(terrain[x].Plants.ToArray(),0,terrain[x].Plants.Count);
        //            stream.WriteByte(1);
        //            stream.Write(terrain[x].Mobs.ToArray(),0,terrain[x].Mobs.Count);
        //            stream.WriteByte(1);
        //        }
        //    }

        //    File.WriteAllText(pathToWorld + @"\"+name+"Generated.txt", (terrain.Count-7).ToString());
        //   // terrain.Clear();
        //   // world++;
        //}

        int GetWorldSize(GenerateWorld.WorldSize currentWorldSize) {
            if (currentWorldSize==GenerateWorld.WorldSize.Small) return 5000;
            if (currentWorldSize==GenerateWorld.WorldSize.Medium) return 7500;
            return 10000;
        }

        void BiomeEmpty(int max) {
            for (; pos<max; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                chunk.LightPosFull=125;


            }
            pos=max;
        }

        readonly List<GChunk> terrain=new List<GChunk>();
        int pos=0;

        //void BiomeStation() {
        //    //1
        //    {//Console.WriteLine(pos);
        //        //terrain.Add(new GChunk());
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        chunk.SolidBlocks[52]=(byte)BlockId.AdvancedSpacePart1;
        //        chunk.SolidBlocks[53]=(byte)BlockId.AdvancedSpaceBlock;
        //        chunk.SolidBlocks[54]=(byte)BlockId.AdvancedSpaceBlock;
        //        chunk.SolidBlocks[55]=(byte)BlockId.AdvancedSpaceBlock;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceBlock;
        //        chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpacePart4;
        //        pos++;

        //    }
        //    //2
        //    {
        //        //terrain.Add(new GChunk());
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        chunk.SolidBlocks[52]=(byte)BlockId.AdvancedSpaceBlock;
        //        chunk.BackBlocks[53]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[54]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[55]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //        chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpaceBlock;
        //        pos++;

        //    }

        //     //3
        //    {
        //        //terrain.Add(new GChunk());
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        chunk.SolidBlocks[52]=(byte)BlockId.AdvancedSpaceBlock;
        //        chunk.BackBlocks[53]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[54]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[55]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //        chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpaceBlock;
        //        pos++;

        //    }

        //   //4
        //    {
        //        //terrain.Add(new GChunk());
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        //                chunk.SolidBlocks[48]=(byte)BlockId.AdvancedSpacePart2;
        //        //chunk.SolidBlocks[49]=(byte)BlockId.AdvancedSpaceBlock;
        //        //chunk.SolidBlocks[50]=(byte)BlockId.AdvancedSpacePart1;
        //          chunk.SolidBlocks[51]=(byte)BlockId.SolarPanel;
        //        chunk.TopBlocks[52]=(byte)BlockId.Label;
        //        chunk.TopBlocks[53]=(byte)BlockId.Lamp;
        //         chunk.TopBlocks[51]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.TopBlocks[52]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[53]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[54]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[55]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //        chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpaceBlock;
        //        pos++;

        //    }

        //    //5
        //    {
        //        //terrain.Add(new GChunk());
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=52;
        //        //chunk.SolidBlocks[48]=(byte)BlockId.SolarPanel;
        //        //chunk.SolidBlocks[49]=(byte)BlockId.Label;
        //        //chunk.SolidBlocks[50]=(byte)BlockId.AdvancedSpaceBlock;

        //        chunk.SolidBlocks[51]=(byte)BlockId.AdvancedSpaceBlock;
        //        chunk.BackBlocks[52]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[53]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[54]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[55]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //        chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpaceBlock;
        //        pos++;

        //    }

        //    //6
        //    {
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=52;
        //        //chunk.SolidBlocks[48]=(byte)BlockId.SolarPanel;
        //        //chunk.SolidBlocks[49]=(byte)BlockId.Label;
        //        chunk.SolidBlocks[51]=(byte)BlockId.SolarPanel;
        //        chunk.TopBlocks[52]=(byte)BlockId.Label;
        //        chunk.TopBlocks[53]=(byte)BlockId.Lamp;
        //         chunk.BackBlocks[52]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[53]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[54]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[55]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //        chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpaceBlock;
        //        pos++;

        //    }

        //    //7
        //    {
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=50;
        //        //chunk.TopBlocks[48]=(byte)BlockId.SolarPanel;
        //        //chunk.TopBlocks[49]=(byte)BlockId.Label;
        //        //chunk.SolidBlocks[50]=(byte)BlockId.AdvancedSpaceBlock;

        //        chunk.SolidBlocks[52]=(byte)BlockId.AdvancedSpaceBlock;
        //        chunk.BackBlocks[53]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[54]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[55]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //        chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpaceBlock;
        //        pos++;

        //    }

        //    //8
        //    {
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        chunk.SolidBlocks[52]=(byte)BlockId.AdvancedSpaceBlock;
        //        chunk.BackBlocks[53]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[54]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.BackBlocks[55]=(byte)BlockId.AdvancedSpaceBack;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //        chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpaceBlock;
        //        pos++;

        //    }

        //     //9
        //    {
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        chunk.SolidBlocks[52]=(byte)BlockId.AdvancedSpacePart2;
        //        chunk.SolidBlocks[53]=(byte)BlockId.DoorClose;
        //        //chunk.SolidBlocks[54]=(byte)BlockId.None;
        //        //chunk.SolidBlocks[55]=(byte)BlockId.None;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //        chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpacePart3;
        //        pos++;

        //    }
        //     //10
        //    {
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //     //   chunk.SolidBlocks[52]=(byte)BlockId.AdvancedSpacePart2;
        //      //  chunk.SolidBlocks[53]=(byte)BlockId.DoorClose;
        //        //chunk.SolidBlocks[54]=(byte)BlockId.None;
        //        //chunk.SolidBlocks[55]=(byte)BlockId.None;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //      //  chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpacePart3;
        //        pos++;

        //    }

        //      //11
        //    {
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //       chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpacePart4;
        //        pos++;

        //    }
        //       //12
        //    {
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //       chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpaceBlock;
        //        pos++;

        //    }
        //      //13
        //    {
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //       chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpaceBlock;
        //        pos++;

        //    }
        //      //14
        //    {
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //       chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpaceBlock;
        //        pos++;

        //    }
        //      //15
        //    {
        //        GChunk chunk = terrain[pos];
        //        chunk.LightPos=53;
        //        chunk.SolidBlocks[56]=(byte)BlockId.AdvancedSpaceFloor;
        //       chunk.SolidBlocks[57]=(byte)BlockId.AdvancedSpacePart3;
        //        pos++;

        //    }

        //}

        int TotalItemsInInventory(int id) {
            int inInv = 0;
            foreach (DInt ii in Inventory) {
                if (id==ii.X) inInv+=ii.Y;
            }
            return inInv;
        }

        void DrawInv(int x, int y, int count, Texture2D tex, int id) { //Global.WindowWidthHalf-150+10+64+64, Global.WindowHeightHalf-98+8
            if (TotalItemsInInventory(id)<count) {
                spriteBatch.Draw(textureSlot, new Vector2(x,y), Color.Red);
                ok=false;
            }  else spriteBatch.Draw(textureSlot, new Vector2(x,y), Color.White);
            spriteBatch.Draw(tex, new Rectangle(x+4,y+4,32,32), null, Color.White);
            DrawTextShadowMin(x+4,y+24,count.ToString());
        }

        void DrawTextShadowMin(int x, int y, string str) {
            //if (Setting.BetterFont) {
            //    if (Constants.Shadow)spriteBatch.DrawString(spriteFont_medium, str, new Vector2(x+0.5f, y+0.5f), color_r0_g0_b0_a100, 0, vector_x0_y4, 0.74074f, SpriteEffects.None, 0);
            //    spriteBatch.DrawString(spriteFont_medium, str, new Vector2(x, y), Color.Black, 0, vector_x0_y4, 0.74074f, SpriteEffects.None, 0);
            //} else {
		        /*if (Constants.Shadow)*/spriteBatch.DrawString(spriteFont_small, str, new Vector2(x+0.5f, y+0.5f), color_r0_g0_b0_a100);
                spriteBatch.DrawString(spriteFont_small, str, new Vector2(x,y), Color.Black);
            //}
        }

        AstronomicalObject GetAOByName(string name, AstronomicalObject[] x) {
            foreach (AstronomicalObject f in x){
                if (f.NameCz==name){
                    return f;
                }
                if (f.Childs!=null){
                    AstronomicalObject z=GetAOByName(name,f.Childs);
                    if (z!=null) return z;
                }
            }
            return null;
        }

        void DrawObjectsSunSystem() {
            DrawObjects(sun[0],0,0);
            planetPosZoom=new Double2(0,0);
            foreach (AstronomicalObject o in sun[0].Childs) {
                 DrawObjects(o,sun[0].PositionX,sun[0].PositionY);
            }
        }

        void DrawObjectsPlanetSystem() {
            AstronomicalObject ao=GetAOByName(selectedAO,sun);
            planetPosZoom=new Double2(ao.PositionX,ao.PositionY);
            DrawObjects(ao,0,0);

            if (ao.Childs!=null){
                foreach (AstronomicalObject o in ao.Childs) {
                     DrawObjects(o,ao.PositionX,ao.PositionY);
                }
            }
        }

        Double2 planetPosZoom=new Double2(0,0);

        void DrawObjects(AstronomicalObject o, double parentX, double parentY) {
            //foreach (AstronomicalObject o in objs){
                if (o==null)return;
 //o.CurrentTime+=o.Speed/3600f;

               // Vector2 p=o.GetPos(zoom);
              //  int size=(int)(10.5f+(Math.Log(o.MeanDiameter,1.0005d)+1)/1000d+(o.MeanDiameter/5500f));
               // double posX=p.X+parentX,posY=p.Y+parentY;
             //   o.Position=new Vector2((float)posX,(float)posY);
             //   Console.WriteLine(Math.Log(2,o.MeanDiameter));
              //  Vector2 pos=new Vector2(p.X/*+parent.X*/,p.Y/*+parent.Y*/);
               // if (o.OrbitalPeriod==0)Console.WriteLine("OrbitalPeriod missing "+o.Name);
               // if (o.Name=="Merkur") windowPosition=new Vector2((int)posX,(int)posY);


                //Vector2 pos=new Vector2
           //     o.Position=new Vector2((float)posX,(float)posY);
              //  Rectangle originalRec=new Rectangle((int)posX,(int)posY,(int)o.MeanDiameter*2,(int)o.MeanDiameter*2);
               // Rectangle drawingRec=new Rectangle((int)(originalRec.X*zoom - windowPosition.X),(int)(originalRec.Y*zoom- windowPosition.Y),(int)(originalRec.Width*zoom),(int)(originalRec.Height*zoom));

                   o.Size=o.fakeMeanDiameter;//(o.MeanDiameter/2f);

                    Rectangle drawingRec =new Rectangle((int)(o.PositionX-planetPosZoom.X-windowPosition.X-o.Size+Global.WindowWidthHalf),(int)(o.PositionY-planetPosZoom.Y-windowPosition.Y+Global.WindowHeightHalf-o.Size),(int)(o.Size*2),(int)(o.Size*2));



                //   if (drawingRec.X>-500 && drawingRec.Y>-500 && drawingRec.X<Global.WindowWidth+500  && drawingRec.Y<Global.WindowHeight+500){
               // if (Vector2.Distance(new Vector2((float)parentX,(float)parentY),new Vector2(drawingRec.X-Global.WindowWidthHalf,drawingRec.Y-Global.WindowHeightHalf))>20 || o.NameCz=="Slunce"){
                    //  new Ellipsoid(o.LongitudeOfAscendingNode,o.Inclination,o.SemiMajorAxis*zoom,o.Eccentricity).Draw(spriteBatch,new Vector2((float)parentX-windowPosition.X,(float)parentY-windowPosition.Y),Color.Gray);

            if (o.PositionX!=planetPosZoom.X)o.elipse.Draw(spriteBatch,new Double2(parentX-planetPosZoom.X-windowPosition.X+Global.WindowWidthHalf,parentY-planetPosZoom.Y-windowPosition.Y+Global.WindowHeightHalf),Color.Gray,1);
                if (MouseInRectangle(drawingRec)){
                    spriteBatch.Draw(o.texture,new Rectangle(drawingRec.X-5,drawingRec.Y-5,drawingRec.Width+10,drawingRec.Height+10),Color.DarkGreen*0.25f);
                    spriteBatch.Draw(o.texture,new Rectangle(drawingRec.X-4,drawingRec.Y-4,drawingRec.Width+8,drawingRec.Height+8),Color.Green*0.25f);
                     spriteBatch.Draw(o.texture,new Rectangle(drawingRec.X-3,drawingRec.Y-3,drawingRec.Width+6,drawingRec.Height+6),Color.LightGreen*0.25f);
                     spriteBatch.Draw(o.texture,new Rectangle(drawingRec.X-2,drawingRec.Y-2,drawingRec.Width+4,drawingRec.Height+4),Color.GreenYellow*0.25f);
                      spriteBatch.Draw(o.texture,new Rectangle(drawingRec.X-1,drawingRec.Y-1,drawingRec.Width+2,drawingRec.Height+2),Color.White);
                if (newMouseState.LeftButton==ButtonState.Released && oldMouseState.LeftButton==ButtonState.Pressed){
                    if (displayed==Displayed.PlanetSystem){
                          //   displayed=Displayed.PlanetSystem;
                        //selectedAO=o.NameCz;

                             if (o.NameEn!="Sun"){
                                dialogLand=true;
                                potencialLand=o.NameCz;

                            }else displayed=Displayed.SolarSystem;
                        }else{
                             displayed=Displayed.PlanetSystem;
                        selectedAO=o.NameCz;
                        }

                        }
                    } else {
                       spriteBatch.Draw(o.texture,drawingRec,Color.White);
                }

                      //  Console.WriteLine(drawingRec);
                    spriteBatch.DrawString(spriteFont_medium,o.NameCz,new Vector2((int)(drawingRec.X+o.Size-spriteFont_medium.MeasureString(o.NameCz).X/2d), (int)(drawingRec.Y/*+o.Size*2*/)),Color.Black,0,Vector2.Zero,1,SpriteEffects.None,1);
                      spriteBatch.DrawString(spriteFont_medium,o.NameCz,new Vector2((int)(drawingRec.X+o.Size-spriteFont_medium.MeasureString(o.NameCz).X/2d), (int)(drawingRec.Y/*+o.Size*2*/)),Color.White,0,Vector2.Zero,1,SpriteEffects.None,1);
             //   }



               //     if (o.Childs!=null){
               //         DrawObjects(o.Childs,o.PositionX,o.PositionY);
               //// }




               //     }

               // Console.WriteLine(o.Name+" "+posX+" "+posY+" "+drawingRec);
                //if (drawingRec.X<int.MaxValue && drawingRec.X>int.MinValue
                //    && drawingRec.Y<int.MaxValue && drawingRec.Y>int.MinValue
                //     && drawingRec.X>windowPosition.X && drawingRec.X<windowPosition.X+Global.WindowWidth
                //     && drawingRec.Y>windowPosition.Y && drawingRec.Y<windowPosition.Y+Global.WindowHeight
                //    ){
                //if (popUpMenu.select==o.NameCz) windowPosition=new Vector2(drawingRec.X-Global.WindowWidthHalf,drawingRec.Y-Global.WindowHeightHalf);
                     //  }
             //   spriteBatch.DrawString(spriteFont,o.Name,new Vector2((int)posX, (int)posY),Color.White,0,Vector2.Zero,1000,SpriteEffects.None,1);
             //   Console.WriteLine(pos);

          //  }

        }

        //int CountPos(double i){
        //    double c=i*zoom - windowPosition.X;
        //    if (c<int.MaxValue && c>int.MinValue){
        //        return (int)c;
        //    }

        //    return int.MinValue;
        //}
        //int CountNum(double i){
        //    double c=i*zoom;
        //    if (c<int.MaxValue && c>int.MinValue){
        //        return (int)c;
        //    }

        //    return int.MinValue;
        //}

        bool MouseInRectangle(Rectangle rec) {
            if (rec.X<newMouseState.X) {
                if (rec.Y < newMouseState.Y) {
                    if (rec.Width+rec.X > newMouseState.X) {
                        if (rec.Height+rec.Y>newMouseState.Y) return true;
                    }
                }
            }
            return false;
        }

        //double XCV() {
        //    if (lastPos==rocketPos) {
        //        lastPos =rocketPos;
        //        return rocketAngle;
        //    }

        //    rocketAngle=Math.Atan2((rocketPos.Y-lastPos.Y), (rocketPos.X-lastPos.X)) + 1.570796327f;
        //    lastPos =rocketPos;
        //    return rocketAngle;
        //}

        //void DrawX(SpriteBatch sb, int X, int Y) {
        //    sb.Draw(Rabcr.Pixel, new Rectangle(X-4, Y, 8, 1), Color.Aqua);
        //    sb.Draw(Rabcr.Pixel, new Rectangle(X, Y-4, 1, 8), Color.Aqua);
        //}

        //void Orbit(Planet x) {
        //    if (x.texture.Width+rocketTexture.Width>Vector2.Distance(rocketPos, x.Position))
        //        canOrbit=x;
        //}

        //void DrawMessageOrbit(SpriteBatch spriteBatch) {
        //    string g = "";
        //    if (canOrbit==moon) g="Měsíci";
        //    if (canOrbit==earth) g="Zemi";
        //    if (canOrbit==mars) g="Marsu";
        //    if (canOrbit==venus) g="Venuši";
        //    if (canOrbit==mercur) g="Merkuru";

        //    spriteBatch.Draw(pixel, new Rectangle(10, 10, 200, 100), new Color(255, 255, 255, 100));
        //    spriteBatch.DrawString(spriteFont, "Lze přistát "+g, new Vector2(15, 15), Color.Black);
        //}

        //public void Save() {
        //    if (!Directory.Exists(path+@"\Space"))
        //        Directory.CreateDirectory(path+@"\Space");
        //    File.WriteAllText(path+@"\Space\Rocket.txt",
        //        rocketPos.X+Environment.NewLine+
        //        rocketPos.Y+Environment.NewLine+
        //        selectedPos.X+Environment.NewLine+
        //        selectedPos.Y);

        //    File.WriteAllText(path+@"\Space\Planets.txt",
        //        mercur.Angle+Environment.NewLine+
        //        venus.Angle+Environment.NewLine+
        //        earth.Angle+Environment.NewLine+
        //        moon.Angle+Environment.NewLine+
        //        jupiter.Angle+Environment.NewLine+
        //        io.Angle+Environment.NewLine+
        //        europa.Angle+Environment.NewLine+
        //        callisto.Angle+Environment.NewLine+
        //        galimedes.Angle+Environment.NewLine+
        //        saturn.Angle+Environment.NewLine+
        //        titan.Angle+Environment.NewLine+
        //        uran.Angle+Environment.NewLine+
        //        neptun.Angle+Environment.NewLine+
        //        triton.Angle+Environment.NewLine+
        //        pluto.Angle);
        //}

        void Load() {
            //if (!Directory.Exists(path+@"\Space"))
            //    Directory.CreateDirectory(path+@"\Space");

            //if (File.Exists(path+@"\Space\Rocket.txt")) {
            //    StreamReader sr = new StreamReader(path+@"\Space\Rocket.txt");
            //    double.TryParse(sr.ReadLine(), out rocketPos.X);
            //    double.TryParse(sr.ReadLine(), out rocketPos.Y);
            //    double.TryParse(sr.ReadLine(), out selectedPos.X);
            //    double.TryParse(sr.ReadLine(), out selectedPos.Y);
            //    sr.Close();
            //}

            //if (File.Exists(path+@"\Space\Planets.txt")) {
            //    StreamReader sr = new StreamReader(path+@"\Space\Rocket.txt");
            //    float.TryParse(sr.ReadLine(), out mercur.Angle);
            //    float.TryParse(sr.ReadLine(), out venus.Angle);
            //    float.TryParse(sr.ReadLine(), out earth.Angle);
            //    float.TryParse(sr.ReadLine(), out moon.Angle);
            //    float.TryParse(sr.ReadLine(), out jupiter.Angle);
            //    float.TryParse(sr.ReadLine(), out io.Angle);
            //    float.TryParse(sr.ReadLine(), out europa.Angle);
            //    float.TryParse(sr.ReadLine(), out callisto.Angle);
            //    float.TryParse(sr.ReadLine(), out galimedes.Angle);
            //    float.TryParse(sr.ReadLine(), out saturn.Angle);
            //    float.TryParse(sr.ReadLine(), out titan.Angle);
            //    float.TryParse(sr.ReadLine(), out uran.Angle);
            //    float.TryParse(sr.ReadLine(), out neptun.Angle);
            //    float.TryParse(sr.ReadLine(), out triton.Angle);
            //    float.TryParse(sr.ReadLine(), out pluto.Angle);
            //    sr.Close();
            //}
        }

        //VectorDouble CalculateGravityToobject(AstronomicalObject ao) {
        //    VectorDouble dis= new VectorDouble(rocketPos.X-ao.PositionX, rocketPos.Y-ao.PositionY);

        //    double distance=Math.Sqrt(dis.X*dis.X+dis.Y*dis.Y);

        //    double force = kappa*ao.Mass/(distance*distance);

        //    double angle;
        //   /* if (dis.X>0 && dis.Y<0)*/ angle=Math.Sinh(dis.Y/distance);

        //    return new VectorDouble(distance*Math.Cos(angle),distance/Math.Sin(angle));
        //    //VectorDouble smallDis;
        //    //if (dis.X<dis.Y)smallDis=new VectorDouble(dis.X/dis.X,dis.Y/dis.X);
        //    //else smallDis=new VectorDouble(dis.X/dis.Y,dis.Y/dis.Y);

        //    //VectorDouble ret=new VectorDouble(smallDis.X*force,smallDis*force);
        //}

        void InitForeachAo(AstronomicalObject[] o, int depth) {
            double beforeFakeSemiMajorAxis=0;
            double beforeSemiMajorAxis=0;
            foreach (AstronomicalObject x in o){
                double deltaSemiMajorAxis=x.SemiMajorAxis-beforeSemiMajorAxis;

                double fakeDeltaSemiMajorAxis=0;//=6*Math.Log10(deltaSemiMajorAxis);
if (depth==1 || depth==0){
                    fakeDeltaSemiMajorAxis=6*Math.Log10(deltaSemiMajorAxis);

                    }

if (depth==2){
                    fakeDeltaSemiMajorAxis=20*Math.Log10(deltaSemiMajorAxis);

                    }
                x.fakeSemiMajorAxis=beforeFakeSemiMajorAxis+fakeDeltaSemiMajorAxis;

                beforeFakeSemiMajorAxis+=fakeDeltaSemiMajorAxis;
                beforeSemiMajorAxis=x.SemiMajorAxis;


                 x.fakeMeanDiameter=Math.Log(x.MeanDiameter,1.25)*0.6d;

                //x.CurrentTime+=x.Speed/(1000*60*20d);// cca den==20min

                //x.Size=(int)(x.MeanDiameter*zoom);//
                //if (x.Size<5)
                //    x.Size=(Math.Pow(x.MeanDiameter, 0.3f)/1d)/**(Math.Log(1+zoom,1.0005f)/4)*//*Math.Log(x.MeanDiameter,1.0005d)*/+2;
                //Console.WriteLine(x.MeanDiameter*zoom+" "+zoom);
                //(int)(x.MeanDiameter*zoom);//
                //Double2 p = x.GetPos();

                //x.PositionX=p.X+parentX;
                //x.PositionY=p.Y+parentY;
                //x.dis=Vector2.Distance(new Vector2((float)x.PositionX, (float)x.PositionY), new Vector2((float)parentX, (float)parentY));
                //x.Visible=x.dis>10f||x.NameCz=="Slunce";

                //Console.WriteLine(x.Visible);


                //int size = (int)(10.5f+(Math.Log(x.MeanDiameter, 1.0005d)+1)/1000d+(x.MeanDiameter/5500f));
                //double posX = p.X+pX, posY = p.Y+pY;

                if (x.Childs!=null) InitForeachAo(x.Childs,depth+1);
 //if (popUpMenu.select==x.NameCz) windowPosition=new Vector2((float)(x.PositionX-Global.WindowWidthHalf),(float)(x.PositionY-Global.WindowHeightHalf));
               // x.Position=new Vector2((float)posX,(float)posY);



            }
        }

        void SetUpTexts() {
            buttonGoUp.Text=Lang.Texts[1];
            buttonLand.Text=Lang.Texts[166];
            buttonCreate.Text=Lang.Texts[167];
            //if (Setting.czechLanguage) {
            //    buttonGoUp.Text="Zpět";
            //    buttonLand.Text="Přiletět";
            //    buttonCreate.Text="Vytvořit";
            //}else{
            //    buttonGoUp.Text="Back";
            //    buttonLand.Text="Fly";
            //    buttonCreate.Text="Create";
            //}
        }
    }

    //class VectorDouble{
    //    public VectorDouble(double x, double y) {
    //        X=x;
    //        Y=y;
    //    }
    //    public double X,Y;
    //}

    //class Star {
    //    public Vector2 position;
    //    public Color color;

    //    public Star(int x, int y, Color c) {
    //        position=new Vector2(x, y);
    //        color=c;
    //    }
    //}

    public class Double2 {
        public Double2(double x, double y){
            X=x;
            Y=y;
        }
        public double X,Y;

        public Vector2 ToVector(){
            return new Vector2((float)X,(float)Y);
        }

        public Double2 Clone() {
            return new Double2(X,Y);
        }

        public static double Distance(Double2 p1, Double2 p2) {
            double dX=p1.X-p2.Y,dY=p1.Y-p2.Y;
            return Math.Sqrt(dX*dX+dY*dY);
        }
    }
}