using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace rabcrClient {
    enum Sex:byte{
        Men,
        Girl
    }

    struct Setting {  
        //public enum Scale :byte{
        //    Without,
        //    Proportions,
        //    Fill,
        //} 
        public enum Window:byte {
            Normal,
            Maxi,
            Fullscreen
        }   
        public enum FogTypes:byte { 
            No,
            Plain,
            Fancy
        }

        // Character
        public static Sex sex=Sex.Men;
        public static int hairType=1;
        public static Color hairColor=Color.Brown;
        public static Color ColorSkin=new(244,158,107);
        public static int moustageType=0;
        public static Color moustageColor=Color.Brown;
        public static int eyesType;
        public static Color eyesColor=Color.DarkBlue;
        public static int MaturePlayer=1;

        // Save
        public static string Path=@"C:\GeftGames\"+Global.GameName+@"\";
        
        // Account
        public static string Name="Player";

        // Functional
        public static bool FirstRun;
        public static bool LangSortByList=true;
        public static bool SnowAndRain=true;
        public static bool SunAndMoon=true;

        // Settings
        public static bool Background=true;
        public static bool Fps=false;
      public static Window currentWindow;
        public static bool Vignetting=true;
     //   public static Scale currentScale;
        public static float Zoom=3;
        public static float VolumeMusic=.5f;
        public static float VolumeEffects=1;
        public static int CurrentLanguage;
        public static float UpScalingSuperSapling=1f;
        public static int Multisapling=1;
        public static bool BackgroundFancy=true;
        public static bool Clouds=true;
        public static bool InteractionMess=true;
        public static bool FallingLeaves=true;
        public static bool WavingElements=true;
        public static FogTypes Fog=FogTypes.Fancy;
        public static bool BetterSnowAndRain=true;
        public static float SlideChangeTimeInTicks => 0.006f/slideChangeTime;
        public static float NightBrightness=0.6f;
        public static float slideChangeTime=0.05f;

        public const string StyleName="Default";
     
        #region Keys
        public static Microsoft.Xna.Framework.Input.Keys KeyLeft=Microsoft.Xna.Framework.Input.Keys.Left;

        public static Microsoft.Xna.Framework.Input.Keys KeyRight=Microsoft.Xna.Framework.Input.Keys.Right;

        public static Microsoft.Xna.Framework.Input.Keys KeyJump=Microsoft.Xna.Framework.Input.Keys.Space;

        public static Microsoft.Xna.Framework.Input.Keys KeyRun=Microsoft.Xna.Framework.Input.Keys.LeftShift;

        public static Microsoft.Xna.Framework.Input.Keys KeyInventory=Microsoft.Xna.Framework.Input.Keys.I;

        public static Microsoft.Xna.Framework.Input.Keys KeyMessage=Microsoft.Xna.Framework.Input.Keys.T;

        public static Microsoft.Xna.Framework.Input.Keys KeyDropItem=Microsoft.Xna.Framework.Input.Keys.LeftControl;

        public static Microsoft.Xna.Framework.Input.Keys KeyExit=Microsoft.Xna.Framework.Input.Keys.Escape;
        public static Microsoft.Xna.Framework.Input.Keys KeyFlyMode=Microsoft.Xna.Framework.Input.Keys.F4;
        public static Microsoft.Xna.Framework.Input.Keys KeyShowInfo=Microsoft.Xna.Framework.Input.Keys.F1;
        #endregion

        public static void CreateSettings() {
           // Debug.WriteLine("Creating new settings");
            try {
                if (File.Exists(Path+@"\Setting.bin")) File.Delete(Path+@"\Setting.bin");
            } catch {}

            Lang.SetUp(true);
            FirstRun=true;

            SaveSetting();
        }

        public static void SaveSetting() {
            //if (!Global.ChangedSettings){
            //    return;
            //}
            Global.ChangedSettings=false;

            #if DEBUG
            Debug.WriteLine("Ukládání nastavení... ");
            #endif

            List<byte> bytes = new() {
                (byte)sex,
                (byte)MaturePlayer,
                (byte)hairType,
                (byte)moustageType,
                hairColor.R,
                hairColor.G,
                hairColor.B,

                ColorSkin.R,
                ColorSkin.G,
                ColorSkin.B,

                eyesColor.R,
                eyesColor.G,
                eyesColor.B,

                moustageColor.R,
                moustageColor.G,
                moustageColor.B,

                (byte)KeyLeft,
                (byte)KeyRight,
                (byte)KeyJump,
                (byte)KeyRun,
                (byte)KeyFlyMode,
                (byte)KeyInventory,
                (byte)KeyMessage,
                (byte)KeyDropItem,
                (byte)KeyExit,
                (byte)KeyShowInfo,

                (byte)CurrentLanguage,
                Constants.AnimationsControls ? (byte)1 : (byte)0,
                WavingElements ? (byte)1 : (byte)0,
                Clouds ? (byte)1 : (byte)0,
                BackgroundFancy ? (byte)1 : (byte)0,
                BetterSnowAndRain ? (byte)1 : (byte)0,
                FallingLeaves ? (byte)1 : (byte)0,
                InteractionMess ? (byte)1 : (byte)0,
                SnowAndRain ? (byte)1 : (byte)0,
                Vignetting ? (byte)1 : (byte)0,
                SunAndMoon ? (byte)1 : (byte)0,
                (byte)(UpScalingSuperSapling*10),
                (byte)Fog,
              //  (byte)GraphicsProfile,

               //   (byte)currentScale,
              (byte)currentWindow,
                Background ? (byte)1: (byte)0,
                Global.YoungPlayer ? (byte)1: (byte)0,
                Fps ? (byte)1: (byte)0,
            };
            bytes.AddRange(BitConverter.GetBytes(VolumeMusic));
            bytes.AddRange(BitConverter.GetBytes(VolumeEffects));
            bytes.AddRange(BitConverter.GetBytes(slideChangeTime));
            bytes.AddRange(BitConverter.GetBytes(Zoom));
            bytes.AddRange(BitConverter.GetBytes(NightBrightness));

            File.WriteAllBytes(Path+@"\Setting.bin",bytes.ToArray());
            //Debug.Write(" Uloženo!");

            //if (Global.OnlineAccount && Global.Logged) UploadAccountSetting();
            //else
          //  if (exiting)saved=true;
        }

        public unsafe static void LoadSetting() {
            #if DEBUG
            Debug.WriteLine("Načítání nastavení... ");
            #endif
            string pth=Path+@"\Setting.bin";

            if (File.Exists(pth)) {
                byte[] bytes=File.ReadAllBytes(pth);

                fixed (byte* pointer=&bytes[0]) {
                    byte* current=pointer;

                    sex =(Sex)(*current++);
                    MaturePlayer = *current++;
                    hairType= *current++;
                    moustageType= *current++;
                    hairColor = new Color(*current++,*current++,*current++);
                    ColorSkin = new Color(*current++,*current++,*current++);
                    eyesColor = new Color(*current++,*current++,*current++);
                    moustageColor = new Color(*current++,*current++,*current++);

                    KeyLeft = (Keys)(*current++);
                    KeyRight =(Keys)(*current++);
                    KeyJump=(Keys)(*current++);
                    KeyRun=(Keys)(*current++);
                    KeyFlyMode=(Keys)(*current++);
                    KeyInventory=(Keys)(*current++);
                    KeyMessage=(Keys)(*current++);
                    KeyDropItem=(Keys)(*current++);
                    KeyExit=(Keys)(*current++);
                    KeyShowInfo=(Keys)(*current++);


      

                    CurrentLanguage=*current++;
                    Constants.AnimationsControls=(*current++) == 1;
                    WavingElements=(*current++) == 1;
                    Clouds=(*current++) == 1;
                    BackgroundFancy=(*current++) == 1;
                    BetterSnowAndRain=(*current++) == 1;
                    FallingLeaves=(*current++) == 1;
                    InteractionMess=(*current++) == 1;
                    SnowAndRain=(*current++) == 1;
                    Vignetting=(*current++) == 1;
                    SunAndMoon=(*current++) == 1;
                    UpScalingSuperSapling=(*current++)/10f;
                    Fog=(FogTypes)(*current++);


                    //GraphicsProfile=(Setting.GraphicsProfile)(*current++);


                 //     currentScale=(Scale)(*current++);
                  currentWindow=(Window)(*current++);

                    Background = (*current++) == 1;
                    Global.YoungPlayer = (*current++) == 1;
                    Fps= (*current++) == 1;

                    VolumeMusic=GetFloat();
                    VolumeEffects=GetFloat();
                    slideChangeTime=GetFloat();
                    Zoom=GetFloat();
                    NightBrightness=GetFloat();

                    if (Zoom<=0) Zoom=3;

                    if (Global.HasSoundGraphics) MediaPlayer.Volume=VolumeMusic;

                    float GetFloat() {
                        int n=(*current++) | (*current++ << 8) | (*current++ << 16) | (*current++ << 24);
                        return *(float*)&n;
                    }
                }
            }

            #if DEBUG
            else Debug.Write("Soubor nastavení neexistuje!");
            #endif
        }
    }
}