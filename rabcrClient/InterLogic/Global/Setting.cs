using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    enum Sex:byte{
        Men,
        Girl
    }

    struct Setting {
        public static bool LangSortByList=true;
        public static Sex sex=Sex.Men;
        public static int hairType=1;
        public static Color hairColor=Color.Brown;
        public static Color ColorSkin=new Color(244,158,107);
        public static int moustageType=0;
        public static Color moustageColor=Color.Brown;
        public static int eyesType;
        public static Color eyesColor=Color.DarkBlue;
        public static int MaturePlayer=1;
        public static string Name="Player";

        public static string Path=@"C:\GeftGames\"+Global.GameName+@"\";

        public static bool Background=true;

        public static bool Fps=false;

        public enum Window:byte {
            Normal,
            Maxi,
            Fullscreen
        }

        public static Window currentWindow;

        public enum Scale :byte{
            Without,
            Proportions,
            Fill,
        }

        public static Scale currentScale;

        public static float Zoom=2;

        public static float VolumeMusic=1;

        public static float VolumeEffects=1;

        public static int CurrentLanguage;

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

        public static string StyleName="Default";

        public static float slideChangeTime=0.05f;

        public static float SlideChangeTimeInTicks => 0.006f/slideChangeTime;

        public static float NightBrightness=0.6f;

        public static GraphicsProfile GraphicsProfile;
    }
}