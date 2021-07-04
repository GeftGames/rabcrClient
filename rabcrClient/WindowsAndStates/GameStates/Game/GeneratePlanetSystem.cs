using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient {
    public enum AstrO {
        Rocky,
        Gas,
        Life,
        IceRocky,
        Lava,
        MoonRocky,
        MoonAsteroid,
        Satellite,
        Star,
        Station,
    }

    public class AstronomicalObject {
//        public Color Colorful;
        public string NameTranslated;
        public double fakeMeanDiameter;
        public double MeanDiameter;//poloměr
        public double Mass;
        public double PositionX, PositionY;
        public AstronomicalObject[] Childs;
        public Texture2D texture;
//        public bool Visible;
        public double dis,pos;
        public double fakeSemiMajorAxis;
        public double Speed;// km/s
        public string Name;
        public double Eccentricity;
        public double SemiMajorAxis;// km
//        public double OrbitalPeriod;//In days
      //  public double CurrentTime;
        public double Inclination;//angle
        public double LongitudeOfAscendingNode;
        public double Size;
        public Ellipsoid elipse;
        public double DayLenght;
        public double Perihelion,Aphelion;
        public bool Builded=true;
        public bool Landable;
    //}
        public  string GetNamesChilds(){
            if (Childs==null) return "{"+1558+"}";
        string ret="";
            foreach (AstronomicalObject a in Childs){
                ret+=a.Name+", ";
            }
            if (ret.Length>20) return ret.Substring(0,20)+"...";
            return ret;
        }
        public AstrO astrO;


   //     public double pos;
//        double TrueAnom(double ec, double E,double dp) {
//            double K=Math.PI/180.0;
//            double S=Math.Sin(E);

//            double C=Math.Cos(E);

//            double fak=Math.Sqrt(1.0-ec*ec);

//            double phi=Math.Atan2(fak*S,C-ec)/K;

//            return Math.Round(phi*Math.Pow(10,dp))/Math.Pow(10,dp);
//        }

//        double EccAnom(double ec,double m,double dp) {
//            // arguments:
//            // ec=eccentricity, m=mean anomaly,
//            // dp=number of decimal places
//            double  pi=Math.PI, K=pi/180.0;

//            double  maxIter=30, i=0;

//            double  delta=Math.Pow(10,-dp);

//            double  E, F;

//            m=m/360.0;

//            m=2.0*pi*(m-Math.Floor(m));

//            if (ec<0.8) E=m; else E=pi;

//            F = E - ec*Math.Sin(m) - m;

//            while ((Math.Abs(F)>delta) && (i<maxIter)) {

//            E = E - F/(1.0-ec*Math.Cos(E));
//            F = E - ec*Math.Sin(E) - m;

//            i = i + 1;

//            }

//            E=E/K;

//            return Math.Round(E*Math.Pow(10,dp))/Math.Pow(10,dp);

//        }

//        Double2 position(double a, double ec, double E) {

//// a=semimajor axis, ec=eccentricity, E=eccentric anomaly
//// x,y = coordinates of the planet with respect to the Sun

//double C = Math.Cos(E);

//double S = Math.Sin(E);
//double x = a*(C-ec);
//            double y = a*Math.Sqrt(1.0-ec*ec)*S;
//            return new Double2(x,y);



//}

        public Double2 GetPos(){
            if (Name=="Sun")return new Double2(0,0);

       //     if (LongitudeOfAscendingNode==0)Console.WriteLine(NameCz+" LongitudeOfAscendingNode");


          //  if (CurrentTime>OrbitalPeriod) CurrentTime-=OrbitalPeriod;

            double MeanAnomaly=0;//(CurrentTime/OrbitalPeriod)*Math.PI*2d;

            //  double TrueAnomaly=(Math.Sqrt(1-Eccentricity*Eccentricity)*Math.Sin(MeanAnomaly))/(1+Eccentricity*Math.Cos(MeanAnomaly));
           // double TrueAnomaly=Math.Tanh(Math.Sqrt((1+Eccentricity)/(1-Eccentricity))*Math.Tan(T/2))*2;

           // double TrueAnomaly=TrueAnom(Eccentricity,EccAnom(Eccentricity,MeanAnomaly/(180/Math.PI),5),5);
           double Angle=pos=MeanAnomaly-/*Eccentricity*Eccentricity**/Eccentricity*(/*1-*/Math.Sin(MeanAnomaly+LongitudeOfAscendingNode))*2/*pi*/+LongitudeOfAscendingNode;
           // double Alpha=t;
         //   pos=Alpha;
          //  if (this.NameCz=="Merkur")Console.WriteLine(Alpha);

            double
                zAphelion = /*(SemiMajorAxis+SemiMajorAxis*Eccentricity)*/Aphelion/**zoom*/,
                zPerihelion = /*(SemiMajorAxis-SemiMajorAxis*Eccentricity)*/Perihelion/**zoom*/;

          //   double RealCenter=SemiMajorAxis-Eccentricity*SemiMajorAxis;

            double delta=zAphelion-zPerihelion;
            //double ep=zAphelion*Math.Cos(Inclination);

            double
                X = zAphelion*Math.Cos(Angle)*Math.Cos(LongitudeOfAscendingNode)-zPerihelion*Math.Sin(Angle)*Math.Sin(LongitudeOfAscendingNode)+Math.Cos(LongitudeOfAscendingNode)*delta,
                Y = zAphelion*Math.Cos(Angle)*Math.Sin(LongitudeOfAscendingNode)+zPerihelion*Math.Sin(Angle)*Math.Cos(LongitudeOfAscendingNode)+Math.Sin(LongitudeOfAscendingNode)*delta;

    //        double
    //X = Perihelion*Math.Cos(Alpha),
    //Y = Aphelion*Math.Sin(Alpha);

            return new Double2(X,Y);//position(SemiMajorAxis*zoom,Eccentricity,EccAnom(Eccentricity,MeanAnomaly,5));

    ////////  //     float v=Math.Sinh(()/(Math.Abs()));
    ////////  double h=(CurrentTime/OrbitalPeriod)*Math.PI*2;
    ////////if (CurrentTime>OrbitalPeriod)CurrentTime-=OrbitalPeriod;
    //////////  double p=SemiMajorAxis-(Eccentricity*SemiMajorAxis/2)+(Eccentricity*SemiMajorAxis);
    ////////          //double v=Speed;//;;
    ////////        //double TrueAnomaly=h;//(Math.Sqrt(1-Eccentricity*Eccentricity)*Math.Sin(v))/(1+Eccentricity*Math.Cos(v));
    ////////     //   v=TrueAnomaly;
    ////////       // TrueAnomaly=p;
    ////////       double X=SemiMajorAxis * Math.Sin(h), Y=SemiMajorAxis * Math.Cos(h);
    ////////        //double X = SemiMajorAxis * (Math.Cos(LongitudeOfAscendingNode) * Math.Cos(TrueAnomaly + p - LongitudeOfAscendingNode) - Math.Sin(LongitudeOfAscendingNode) * Math.Sin(TrueAnomaly + p - LongitudeOfAscendingNode) * Math.Cos(Inclination)),
    ////////        //Y = SemiMajorAxis * (Math.Sin(LongitudeOfAscendingNode) * Math.Cos(TrueAnomaly + p - LongitudeOfAscendingNode) + Math.Cos(LongitudeOfAscendingNode) * Math.Sin(TrueAnomaly + p - LongitudeOfAscendingNode) * Math.Cos(Inclination));
    ////////        return new Vector2((float)X,(float)Y);
    //////////r is radius vector
    //////////v is true anomaly
    //////////o is longitude of ascending node
    //////////p is longitude of perihelion
    //////////i is inclination of plane of orbit=úhel do výšky
        }
    }

    class GeneratePlanetSystem {
       // Texture2D DarkHoleTexture,EarthTexture,GasTexture,Gas2Texture, SunTexture,MagmaticTexture,RockyTexture, StoneTexture;
        //private float Speed;


        //public List<AstronomicalObject> Generate(Random r) {
        //    List <AstronomicalObject> tmp=new List<AstronomicalObject>();
        //    for (int sX=-25; sX<25; sX++) {
        //        for (int sY=-25; sY<25; sY++) {
        //            AstronomicalObject a=GenerateChilds(r, 6000);
        //            a.Position=new Vector2(sX*1000+r.Next(750),sY*1000+r.Next(750));
        //            tmp.Add(a);
        //        }
        //    }
        //    return tmp;
        //}

        //public AstronomicalObject GenerateChilds(Random r, int mass) {
        //    if (mass>5000){
        //        AstronomicalObject a=new AstronomicalObject{Mass=(int)(r.Next(mass)*0.5f),Colorful=Color.White, Name="", Size=r.Next(4)+8,Type=AstrO.DarkHole};

        //        a.Childs=GenerateChilds(r,a.Mass);
        //        return a;
        //    }

        //        // Dark hole
        //        case 0:


        //    }
        //}


        /*random names
        "Arhode", "Aether", "Eros", "Hypne", "Hypnethea", "Apoa", "Plutonia", "Semidea", "Plutode", "Plutothea", "Polynome", "Polyneme", "Hestia", "Hesthes", "Hemidea", "Symdea", "Phedea", "Xedeus", "Arthene", "Demeon", "Hadea", "Furirhoe", "Enyodene", "Europa", "Flora", "Fledus", "Solos", "Helemis", "Iophene", "Hiacinia", "Hiacinede", "Iris", "Irius", "Zeu", "Let"

        */

        public AstronomicalObject[] SunSystem(/*Random r*/){ //jupiter 69173,25
            return new AstronomicalObject[]{new AstronomicalObject {
                NameTranslated=Lang.Texts[1537],
                Name="Sun",
                Mass=1.9891e30,// 2*10^30
                //Colorful=Color.Orange,
                MeanDiameter=696342,
                astrO=AstrO.Star,
          //      Type=AstrO.Star,
               // texture=SunTexture,
                Childs=new AstronomicalObject[] {
                    new AstronomicalObject {
                        NameTranslated=Lang.Texts[1538],
                        Name="Mercur",
                        Mass=3.3e23,// 3,3×10^23
                        //Colorful=Color.LightGray,
                        MeanDiameter=4800d,
                     //   Type=AstrO.Rocky,
                       // texture=StoneTexture,
                        SemiMajorAxis=57909050d,
                        ///OrbitalPeriod=87.9691d,
                        Speed=47.36d,
                        Inclination=0.122260314d,
                        LongitudeOfAscendingNode=0.843535081d,
                        Eccentricity=0.205630d,//0.90d,
                         astrO=AstrO.Rocky,
                         DayLenght=1.408,
                    },
                    new AstronomicalObject {
                        NameTranslated=Lang.Texts[1539],
                        Name="Venus",
                        Mass=4.8685e24,// 3,3×10^23
                        //Colorful=Color.OrangeRed,
                        MeanDiameter=6051.5d,
                      //  Type=AstrO.Rocky,
                     //   texture=StoneTexture,
                        SemiMajorAxis=108208000d,
                        Speed=35.020d,
                        //OrbitalPeriod=224.701d,
                        Inclination=0.0673697091d,
                        LongitudeOfAscendingNode=1.33831847,
                        Eccentricity=0.006772d,
                        astrO=AstrO.Lava,
                        DayLenght=5.832,
                    },
                    new AstronomicalObject {
                        NameTranslated=Lang.Texts[1533],
                        Name="Earth",
                        Mass=5.9736e24,// 3,3×10^23
                        //Colorful=Color.OrangeRed,
                        MeanDiameter=6367.4425d,
                       // canBreathe=true,
                        astrO=AstrO.Life,
                   //     Type=AstrO.Life,
                   //     texture=EarthTexture,
                        SemiMajorAxis=149598023d,
                        Speed=29.783d,
                        DayLenght=24,
                        //OrbitalPeriod=365.256363004d,
                        Inclination=0.124878308d,
                        LongitudeOfAscendingNode=-0.196535244d,
                        Eccentricity=0.0167086,
                        Landable=true,
                        Childs=new AstronomicalObject[] {
                            new AstronomicalObject {
                                NameTranslated=Lang.Texts[1536],
                                Name="Space station",
                                Mass=125e17d,// 3,3×10^23
                                //Colorful=Color.Gray,
                                Builded=false,
                                //Size=,
                                astrO=AstrO.Station,
                              //  texture=EarthTexture,
                                SemiMajorAxis=20447.5+6378d,
                                Speed=100d,
                                MeanDiameter=1000d,
                                Eccentricity=0.01d,
                                Landable=true,
                                LongitudeOfAscendingNode=1d,
                                //OrbitalPeriod=0.506090278d,
                               // Inclination=0.901288026d,
                            },

                            new AstronomicalObject {
                                NameTranslated=Lang.Texts[1534],
                                Name="Moon",
                               // Mass=*(10^ ),// 3,3×10^23
                                //Colorful=Color.Gray,
                                //Size=,
                             //   Type=AstrO.Rocky,
                                Mass=7.342e22,
                           //     texture=EarthTexture,
                                SemiMajorAxis=384399d,
                                Eccentricity=0.0549d,
                                Speed=1.022d,
                                DayLenght=28,
                                MeanDiameter=1737.1d,
                                Landable=true,
                                //OrbitalPeriod=27.321661d,
                                Inclination=0.08979719d,
                                LongitudeOfAscendingNode=5d,
                                astrO=AstrO.MoonRocky,
                            },

                        }
                    },
                    new AstronomicalObject {
                        NameTranslated=Lang.Texts[1535],
                        Name="Mars",
                        Mass=6.4185e23,// 3,3×10^23
                        //Colorful=Color.OrangeRed,
                        MeanDiameter=3389.5d,
                    //    Type=AstrO.Rocky,
                     //   texture=EarthTexture,
                        SemiMajorAxis=227939200d,
                        Speed=29.783d,
                        DayLenght=24.62,
                        //OrbitalPeriod=779.96d,
                        Landable=true,
                        Eccentricity=0.0934,
                        Inclination=0.0322885912d,
                        LongitudeOfAscendingNode=0.864950271d,
                        astrO=AstrO.Rocky,
                        Childs=new AstronomicalObject[] {
                            new AstronomicalObject {
                                Name="Phobos",
                                NameTranslated=Lang.Texts[1541],
                                Mass=1*(10^16),
                                //Colorful=Color.Gray,
                                MeanDiameter=22.2d,
                                Eccentricity=0.0151d,
                                astrO=AstrO.MoonAsteroid,
                               // texture=EarthTexture,
                                SemiMajorAxis=9376d,
                                Speed=2.138d,
                                //OrbitalPeriod=0.31891023,
                                Inclination=0.454483737d,
                            },
                            new AstronomicalObject {
                                Name="Deimos",
                                NameTranslated=Lang.Texts[1542],
                                Mass=2.244e15,
                                //Colorful=Color.Gray,
                                MeanDiameter=6.2d,
                                Eccentricity=0.00033d,
                                astrO=AstrO.MoonAsteroid,
                               // texture=EarthTexture,
                                SemiMajorAxis=23463.2d,
                                Speed=1.3513d,
                                //OrbitalPeriod=1.2624407d,
                                Inclination=0.481361808,
                            },
                        }
                    },
                    //new AstronomicalObject {
                    //    NameCz="Ceres",
                    //    Mass=9.5e20,// 3,3×10^23
                    //    Colorful=Color.OrangeRed,
                    //    MeanDiameter=473d,
                    //    Eccentricity=0.075823d,
                    //    Type=AstrO.Rocky,
                    //   // texture=EarthTexture,
                    //    SemiMajorAxis=414010000d,
                    //    Speed=17.905d,
                    //    OrbitalPeriod=466.6d,
                    //    Inclination=0.184882728d,
                    //    LongitudeOfAscendingNode=1.40201077d,
                    //},
                    //new AstronomicalObject {
                    //    NameCz="Pallas",
                    //    Mass=2.2e20,// 3,3×10^23
                    //    Colorful=Color.White,
                    //    MeanDiameter=512d,
                    //    Type=AstrO.Rocky,
                    //  //  texture=EarthTexture,
                    //    SemiMajorAxis=414804976d,
                    //    Speed=17.65d,
                    //    Eccentricity=0.2305d,
                    //    OrbitalPeriod=1686.87d,
                    //    LongitudeOfAscendingNode=3.02081587d,
                    //    Inclination=0.608020352,
                    //},
                    //new AstronomicalObject {
                    //    NameCz="Vesta",
                    //    Mass=5.9736e24,// 3,3×10^23
                    //    Colorful=Color.OrangeRed,
                    //    MeanDiameter=525.4d,
                    //    Type=AstrO.Rocky,
                    //   // texture=EarthTexture,
                    //    SemiMajorAxis=353318755d,
                    //    Speed=19.34d,
                    //    OrbitalPeriod=1325.654,
                    //    LongitudeOfAscendingNode=1.81254816d,
                    //    Inclination=0.124624014d,
                    //    Eccentricity=0.08874,
                    //},

                    new AstronomicalObject {
                        Name="Jupiter",
                        NameTranslated=Lang.Texts[1542],
                        Mass=1.8982e27,// 3,3×10^23
                        //Colorful=Color.OrangeRed,
                        MeanDiameter=69911d,
                    //    Type=AstrO.Rocky,
                     //   texture=EarthTexture,
                        SemiMajorAxis=778.57e+06,// d*(10^6),
                        Speed=13.07d,
                        DayLenght=10,
                        Inclination=0.0227416402d,
                        Eccentricity=0.0489d,
                        LongitudeOfAscendingNode=1.75342758d,
                        //LongitudeOfAscendingNode=1.75342758d,
                        //OrbitalPeriod=4332.59d,
                        astrO=AstrO.Gas,
                         Childs=new AstronomicalObject[] {
                            new AstronomicalObject {
                                NameTranslated=Lang.Texts[1543],
                                Name="Io",
                                Mass=8931900e16,
                                //Colorful=Color.White,
                                MeanDiameter=3637.4,
                                Eccentricity=0.0041,
                                astrO=AstrO.Rocky,
                                SemiMajorAxis=421700,
                                Speed=17.334,
                                //OrbitalPeriod=1.7691,
                                Inclination=0.050,
                            },
                            new AstronomicalObject {
                                Name="Europa",
                                NameTranslated=Lang.Texts[1544],
                                Mass=4800000e16,
                               // Colorful=Color.White,
                                MeanDiameter=3121.6,
                                Eccentricity=0.0094,
                                astrO=AstrO.MoonRocky,
                                SemiMajorAxis=671034,
                                Speed=13.740,
                                //OrbitalPeriod=3.5512,
                                Inclination=0.471,
                            },
                              new AstronomicalObject {
                                Name="Ganymed",
                                NameTranslated=Lang.Texts[1545],
                                Mass=14819000e16,
                                //Colorful=Color.White,
                                MeanDiameter=5262.4,
                                Eccentricity=0.0011,
                                astrO=AstrO.Rocky,
                                SemiMajorAxis=1070412,
                                Speed=10.880,
                                //OrbitalPeriod=7.1546,
                                Inclination=0.204,
                            },
                            new AstronomicalObject {
                                Name="Callisto",
                                NameTranslated=Lang.Texts[1546],
                                Mass=10759000e16,
                                //Colorful=Color.White,
                                MeanDiameter=4820.6,
                                Eccentricity=0.0074,
                                astrO=AstrO.Rocky,
                                SemiMajorAxis=1882709,
                                Speed=8.204,
                                //OrbitalPeriod=16.689,
                                Inclination=0.205,
                            },


                        }
                    },
                    new AstronomicalObject {
                        Name="Saturn",
                        NameTranslated=Lang.Texts[1547],
                        Mass=5.9736e24,// 3,3×10^23
                        //Colorful=Color.Orange,
                        MeanDiameter=58232d,
                   //     Type=AstrO.Gas,
                     //   texture=EarthTexture,
                        SemiMajorAxis=1433.53e+6,
                        Speed=9.68d,
                        DayLenght=9.7,
                        //OrbitalPeriod=10759.22d,
                        LongitudeOfAscendingNode=1.98382849d,
                        Eccentricity=0.0565d,
                        Inclination=0.0433714319d,
                         astrO=AstrO.Gas,
                        Childs=new AstronomicalObject[]{
                            new AstronomicalObject{
                                NameTranslated=Lang.Texts[1548],
                                Name="Titan",
                                MeanDiameter=5149.46d,
                                Mass=134520000e15,
                                SemiMajorAxis=1221930d,
                                //OrbitalPeriod=15.94542d,
                                Inclination=0.00608247244d,
                                Eccentricity=0.0288d,
                            },
                        //    new AstronomicalObject{
                        //        NameCz="Rhea",
                        //        MeanDiameter=1527.0d,
                        //        Mass=2306518e15,
                        //        SemiMajorAxis=527108d,
                        //        OrbitalPeriod=4.518212d,
                        //        Inclination=0.00570722665d,
                        //        Eccentricity=0.001258d,
                        //    },
                        //    new AstronomicalObject{
                        //        NameCz="Iapetus",
                        //        MeanDiameter=1468.6d,
                        //        Mass=1805635e15,
                        //        SemiMajorAxis=3560820d,
                        //        OrbitalPeriod=79.3215d,
                        //        Inclination=0.270002435d,
                        //        Eccentricity=0.028613d,
                        //    },
                        //    new AstronomicalObject{
                        //        NameCz="Dione",
                        //        MeanDiameter=1122.8d,
                        //        Mass=1095452e15,
                        //        SemiMajorAxis=377396d,
                        //        OrbitalPeriod=2.736915d,
                        //        Inclination=3.4906585e-5,
                        //        Eccentricity=0.0022d,
                        //    },
                        //    new AstronomicalObject{
                        //        NameCz="Tethys",
                        //        MeanDiameter=1062d,
                        //        Mass=617449e15,
                        //        SemiMajorAxis=294619d,
                        //        OrbitalPeriod=1.887802d,
                        //        Inclination=1.74532925e-6,
                        //        Eccentricity=0.0001d,
                        //    },
                        //    new AstronomicalObject{
                        //        NameCz="Enceladus",
                        //        MeanDiameter=504.2d,
                        //        Mass=108022e15,
                        //        SemiMajorAxis=237950d,
                        //        OrbitalPeriod=1.370218d,
                        //        Inclination=0.000174532925d,
                        //        Eccentricity=0.0047d,
                        //    },
                        //    new AstronomicalObject{
                        //        NameCz="Mimas",
                        //        MeanDiameter=396.4d,
                        //        Mass=37493e15,
                        //        SemiMajorAxis=185404d,
                        //        OrbitalPeriod=0.942422d,
                        //        Inclination=0.0273318561d,
                        //        Eccentricity=0.0202d,
                        //    },
                        }
                    },
                    new AstronomicalObject {
                        NameTranslated=Lang.Texts[1549],
                        Name="Uranus",
                        Mass=5.9736e24,// 3,3×10^23
                        //Colorful=Color.OrangeRed,
                        MeanDiameter=6367.4425d,
                        //Type=AstrO.Rocky,
                  //      texture=EarthTexture,
                        SemiMajorAxis=2.87503172e9,
                        Speed=29.783d,
                        //OrbitalPeriod=30688.5d,
                        LongitudeOfAscendingNode=1.29164837d,
                        Eccentricity=0.046381d,
                         astrO=AstrO.Gas,
                         DayLenght=17.23,
                        Inclination=0.113097336d,
                        Childs=new AstronomicalObject[]{
                            new AstronomicalObject{
                                Name="Titania",
                                NameTranslated=Lang.Texts[1550],
                                MeanDiameter=1576.8d,
                                Mass=3527e18,
                                SemiMajorAxis=435910,
                                //OrbitalPeriod=8.705872d,
                                Inclination=0.00593411946d,
                                Eccentricity=0.0011d,
                            },
                        //    new AstronomicalObject{
                        //        NameCz="Oberon",
                        //        MeanDiameter=1522.8d,
                        //        Mass=3014e18,
                        //        SemiMajorAxis=583520,
                        //        OrbitalPeriod=13.463239d,
                        //        Inclination=0.00101229097d,
                        //        Eccentricity=0.0014d,
                        //    },
                        //    new AstronomicalObject{
                        //        NameCz="Umbriel",
                        //        MeanDiameter=1169.4d,
                        //        Mass=1172e18,
                        //        SemiMajorAxis=266300,
                        //        OrbitalPeriod=4.144177d,
                        //        Inclination=0.00357792497d,
                        //        Eccentricity=0.0039d,
                        //    },
                        //    new AstronomicalObject{
                        //        NameCz="Ariel",
                        //        MeanDiameter=1157.8d,
                        //        Mass=1353e18,
                        //        SemiMajorAxis=191020,
                        //        OrbitalPeriod=2.520379d,
                        //        Inclination=0.00453785606d,
                        //        Eccentricity=0.0012d,
                        //    },
                        //    new AstronomicalObject{
                        //        NameCz="Miranda",
                        //        MeanDiameter=471.6d,
                        //        Mass=65.9e18,
                        //        SemiMajorAxis=129390,
                        //        OrbitalPeriod=1.413479d,
                        //        Inclination=0.0738623339d,
                        //        Eccentricity=0.0013d,
                        //    },
                        }
                    },
                    new AstronomicalObject {
                        NameTranslated=Lang.Texts[1551],
                        Name="Neptune",
                        Mass=1.02413e26,// 3,3×10^23
                        //Colorful=Color.OrangeRed,
                        MeanDiameter=24622d,
                       // Type=AstrO.Rocky,
                   //     texture=EarthTexture,
                        SemiMajorAxis=4.50439189e9,
                         astrO=AstrO.Gas,
                         DayLenght=16.12,
                        Eccentricity=0.009456d,
                        //OrbitalPeriod=30708.16d,
                        LongitudeOfAscendingNode=2.3000647d,
                        Inclination=0.112224671d,
                        Speed=5.43d,
                        Childs=new AstronomicalObject[]{
                            new AstronomicalObject{
                                Name="Proteus",
                                NameTranslated=Lang.Texts[1552],
                                MeanDiameter=210d,
                                Mass=5035e16,
                                SemiMajorAxis=117646d,
                                //OrbitalPeriod=1.122d,
                                Inclination=0.075d,
                                Eccentricity=8.72664626e-6,
                            },
                            new AstronomicalObject{
                                Name="Triton",
                                NameTranslated=Lang.Texts[1553],
                                MeanDiameter=2705.2d,
                                Mass=2140800e16,
                                SemiMajorAxis=354759d,
                                //OrbitalPeriod=-5.877d,
                                Inclination=0.27381598d,// /10smaller
                                Eccentricity=0.000016d,
                            },
                        }
                    },
                    new AstronomicalObject {
                        Name="Pluto",
                        NameTranslated=Lang.Texts[1554],
                        Mass=1.3e22,// 3,3×10^23
                        //Colorful=Color.OrangeRed,
                        MeanDiameter=2376.6d,
                     //  Type=AstrO.Rocky,
                   //     texture=EarthTexture,
                        SemiMajorAxis=7.37592301e9,
                        Speed=4.67d,
                        //OrbitalPeriod=90560d,
                        Eccentricity=0.2488,
                        DayLenght=6.4*24,
                         astrO=AstrO.IceRocky,
                        Inclination=0.2994985,
                        LongitudeOfAscendingNode=1.92508071d,
                        Childs=new AstronomicalObject[] {
                            new AstronomicalObject {
                                Name="Charon",
                                NameTranslated=Lang.Texts[1555],
                                MeanDiameter=1212,
                                SemiMajorAxis=17536,
                                //OrbitalPeriod=6.387230d,
                                Inclination=1.74532925e-5,
                                Eccentricity=0.0022d,
                                Mass=158.7e19,
                            }
                        }
                    },
                    new AstronomicalObject {
                        NameTranslated=Lang.Texts[1556],
                        Name="Eris",
                        Mass=5.9736e24,// 3,3×10^23
                        //Colorful=Color.OrangeRed,
                        MeanDiameter=2326d,
                        astrO=AstrO.Rocky,
                 //       texture=EarthTexture,
                        SemiMajorAxis=10.166e9,
                        Speed=3.4338d,
                      //  OrbitalPeriod=203830d,
                        Eccentricity=0.44068d,
                        Inclination=0.768721542d,
                        LongitudeOfAscendingNode=0.627499971d,
                        Childs=new AstronomicalObject[]{
                            new AstronomicalObject{
                                Name="Dysnomia",
                                NameTranslated=Lang.Texts[1557],
                                Eccentricity=0.013d,
                                //OrbitalPeriod=15.774d,
                                Speed=0.172d,
                                Inclination=0.106988683d,//10*smaller
                                SemiMajorAxis=37350d,
                                MeanDiameter=350d,

                            }
                        }
                    },
                 //   new AstronomicalObject {
                 //       NameCz="Makemake",
                 //       Mass=5.9736e24,// 3,3×10^23
                 //       Colorful=Color.OrangeRed,
                 //       MeanDiameter=6367.4425d,
                 //       Type=AstrO.Rocky,
                 // //      texture=EarthTexture,
                 //       SemiMajorAxis=6.8158e9,
                 //       Speed=4.419d,
                 //       OrbitalPeriod=112327d,
                 //       Eccentricity=0.15804d,
                 //       Inclination=0.505801653,
                 //       LongitudeOfAscendingNode=1.39008319,
                 //   },
                 //   new AstronomicalObject {
                 //       NameCz="Haumea",
                 //       Mass=5.9736e24,// 3,3×10^23
                 //       Colorful=Color.OrangeRed,
                 //       MeanDiameter=798d,
                 //       Type=AstrO.Rocky,
                 // //      texture=EarthTexture,
                 //       SemiMajorAxis=6.46532078e9,
                 //       Speed=4.531d,
                 //       OrbitalPeriod=103774d,
                 //       Eccentricity=0.19126,
                 //       Inclination=0.492008316,
                 //       LongitudeOfAscendingNode=2.1256365,
                 //   },
                 //   new AstronomicalObject {
                 //       NameCz="Sedna",
                 //       Mass=5.9736e24,// 3,3×10^23
                 //       Colorful=Color.OrangeRed,
                 //       MeanDiameter=497.5d,
                 //       Type=AstrO.Rocky,
                 // //      texture=EarthTexture,
                 //       SemiMajorAxis=7.58162009e10,
                 //       Speed=1.04d,
                 //       OrbitalPeriod=4163761.07d,
                 //       Inclination=0.20819544,
                 //       LongitudeOfAscendingNode=2.52280362,
                 //       Eccentricity=0.85491,
                 //   },
                 //   new AstronomicalObject {
                 //       NameCz="Orcus",
                 //       Mass=1*(10^2),// 3,3×10^23
                 //       Colorful=Color.OrangeRed,
                 //       MeanDiameter=917d,
                 //       Type=AstrO.Rocky,
                 //   //    texture=EarthTexture,
                 //       SemiMajorAxis=5.89385691e9,
                 //       Speed=29.783d,
                 //       OrbitalPeriod=90324d,
                 //       Inclination=0.359223667,
                 //       Eccentricity=0.2201,
                 //       LongitudeOfAscendingNode=4.69004877,
                 //       Childs=new AstronomicalObject[]{
                 //           new AstronomicalObject{
                 //               NameCz="Vanth",
                 //               SemiMajorAxis=9030d,
                 //               Eccentricity=0.007d,
                 //               OrbitalPeriod=9.5406d,
                 //               Inclination=0.366519143d,
                 //               Mass=4*(10^19),
                 //               MeanDiameter=221.5d,
                 //               Speed=0.447d,

                 //           }
                 //       }
                 //   },
                 //   new AstronomicalObject {
                 //       NameCz="2007 OR10",
                 //       Mass=5.9736e24,// 3,3×10^23
                 //       Colorful=Color.OrangeRed,
                 //       MeanDiameter=1253d,
                 //       Type=AstrO.Rocky,
                 //  //     texture=EarthTexture,
                 //       SemiMajorAxis=1.0079306e10,
                 //       Speed=29.783d,
                 //       OrbitalPeriod=201863d,
                 //       Eccentricity=0.503d,
                 //       Inclination=0.536496759,
                 //       LongitudeOfAscendingNode=5.87903687,
                 //   },
                 //   new AstronomicalObject {
                 //       NameCz="Quaoar",
                 //       Mass=5.9736e24,// 3,3×10^23
                 //       Colorful=Color.OrangeRed,
                 //       MeanDiameter=6367.4425d,
                 //       Type=AstrO.Rocky,
                 //    //   texture=EarthTexture,
                 //       SemiMajorAxis=6.46554517e9,
                 //       Speed=29.783d,
                 //       LongitudeOfAscendingNode=3.29583089d,
                 //       OrbitalPeriod=105416,
                 //       Eccentricity=0.0396,
                 //       Inclination=0.139418646,
                 //   },
                 //   new AstronomicalObject{
                 //       NameCz="Salacia",
                 //       SemiMajorAxis=6.27518188e9d,
                 //       Eccentricity=0.1097,
                 //       OrbitalPeriod=99233d,
                 //       Inclination=0.417570024d,
                 //       LongitudeOfAscendingNode=4.88622377d,
                 //       Mass=4.38e20,
                 //       MeanDiameter=425,
                 //       Speed=1.04,

                 //       Childs=new AstronomicalObject[]{
                 //           new AstronomicalObject(){
                 //           NameCz="Actaea"   ,
                 //           Eccentricity=0.0084,
                 //           SemiMajorAxis=5619,
                 //           OrbitalPeriod=5.49380,
                 //           MeanDiameter=303,
                 //           Mass=1.86e19,
                 //           Speed=0.0743d,
                 //           }
                 //       },
                 //   },

                }
            } };

        //    return sun;
        }
    }
}
