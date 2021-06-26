//using Microsoft.WindowsAPICodePack.Taskbar;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    class Bar {
        Color black25;
        public int X, Y;
        public int Size;
        public float Filled;
      //  const int height=32;
        public bool Green;
        public bool visible;
        const int bcolorh=100;
        float FilledBefore;
        readonly int[,] connerLeftA, shadow, shadowDownLeft;
        float textW, textEW;
        string text, errorText;
      //  readonly bool set;
       // bool lastG;
        public Bar() {
            visible=true;
            Filled=0.25f;
            connerLeftA=new int[,]{
                {  0,  32, 55, 218},
                { 25, 223,128, 36},
                { 159,131,  0,  0},
                { 224, 27,  0,  0},
            };
            shadow=new int[,] {
                {   0,   0,   0, 255, 148,  73,  22},
                {   0,   0,   0, 190, 121,  56,  15},
                {   0,   0, 190, 128,  82,  34,   7},
                { 160, 146, 119,  81,  42,  15,   2},
                {  82,  72,  55,  33,  15,   4,   0},
                {  26,  21,  14,   7,   2,   0,   0},
            };
            shadowDownLeft=new int[,] {
                {  19, 172,   0,   0},
                {  17,  80,   0,   0},
                {  10,  52,  86,  92},
                {   5,  28,  66,  86},
                {   0,  10,  19,  52},
                {   0,   0,   0,  10},
            };
            Green=true;
            black25=Color.Black*0.25f;


            text="0%";
            textW=X+Size/2f-Fonts.Medium.MeasureString(text).X/2f;
        }

        public void SetError(string txt) {
            Green=false;
            errorText=txt;
            textEW=textW=X+Size/2f-Fonts.Medium.MeasureString(errorText).X/2f;
        }

        public void ChangePos(int x, int y) {
            if (Global.WindowWidth>550){
                Size=500;
                visible=true;
            } else if (Global.WindowWidth>200) {
                Size=Global.WindowWidth-50;
                visible=true;
            } else visible=false;
            X=x-Size/2;//Global.WindowWidthHalf-250+1
            Y=y;//Global.WindowHeightHalf+32+0+1
            if (!Green)textEW=textW=X+Size/2f-Fonts.Medium.MeasureString(errorText).X/2f;
            else if (text!=null)textW=X+Size/2f-Fonts.Medium.MeasureString(text).X/2f;
        }

        public void Draw(SpriteBatch spriteBatch) {

            // Calculate
            int PercentageFore=(int)(Filled*(Size-1));
            int PercentageBack=(Size-1)-PercentageFore;
            bool drawFirstPixels=PercentageFore==0;
            bool drawEndPixels=PercentageBack==0;
            /*bool finished=PercentageBack==0;*/

            // Background (gray)
            if (PercentageFore!=Size-1){
                int c=(drawFirstPixels? 1:0);
                int cor=-c- (drawEndPixels? 1:0);
                 spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+1+ c+PercentageFore, Y+1, PercentageBack+cor, 1), new Color(200, 200, 200));
                for (int i = 2; i<31; i++) {
                    spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+1+PercentageFore, Y+i, PercentageBack, 1), new Color(200+i, 200+i, 200+i));
                }
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+1+ c+PercentageFore, Y+31, PercentageBack+cor, 1), new Color(200+30, 200+30, 200+30));
            }

            // Shadow
            if (Constants.AnimationsControls){
                //up
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+2, Y-1, Size-6+2, 1), Color.Black*0.05f);

                //left
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X-1, Y+2, 1, 32-6+2), Color.Black*0.05f);

                //down
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+3, Y+33, Size-6, 1), Color.Black*0.2f);
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+3, Y+34, Size-6, 1), Color.Black*0.11f);
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+3, Y+35, Size-6, 1), Color.Black*0.05f);

                //right
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size+1, Y+3, 1, 32-6+1), Color.Black*0.2f);
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size+2, Y+3, 1, 32-6+1), Color.Black*0.1f);
                spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size+3, Y+3, 1, 32-6+1), Color.Black*0.05f);

                //down right
                for (int x=0; x<7; x++) {
                    for (int y=0; y<6; y++){

                        int a=shadow[y,x];
                        if (a>0) {
                            Color c=Color.Black*(a/255f/3f);
                            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size+x-2-1,   Y+33+y-2-1, 1, 1), c);
                            //spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size-x,    Y+y, 1, 1), c);
                            //spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+x,      Y+32-y, 1, 1), c);
                            //spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size-x, Y+32-y, 1, 1), c);
                        }
                    }
                }

                //Down left
                for (int x=0; x<4; x++) {
                    for (int y=0; y<6; y++){

                        int a=shadowDownLeft[y,x];
                        if (a>0) {
                            Color c=Color.Black*(a/255f/3f);
                            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+x-1,   Y+33+y-2-1, 1, 1), c);

                            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size+y-2,   Y+x-1, 1, 1), c);
                            //spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size-x,    Y+y, 1, 1), c);
                            //spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+x,      Y+32-y, 1, 1), c);
                            //spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size-x, Y+32-y, 1, 1), c);
                        }
                    }
                }
            }

            // Bounds
            Color bColor=new Color(bcolorh,bcolorh,bcolorh);
            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+3, Y, Size-6, 1), bColor);
            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+3, Y+32, Size-6, 1), bColor);
            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X, Y+3, 1, 32-6), bColor);
            spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size, Y+3, 1, 32-6), bColor);

            //Fore (green or red)
            if (PercentageBack!=Size-1){
                if (Green){
                    int c=(drawFirstPixels? 1:0);
                    int cor=-c- (drawEndPixels? 1:0);
                     spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+1+ c, Y+1, PercentageFore+cor, 1), new Color(0,230,  0));
                    for (int i = 2; i<31; i++) {
                        spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+1, Y+i, PercentageFore, 1), new Color( 0,230-i, 0));
                    }
                    spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+1+ c, Y+31, PercentageFore+cor, 1), new Color(0,200,  0));
                } else {
                    int c=(drawFirstPixels? 1:0);
                    int cor=-c- (drawEndPixels? 1:0);
                     spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+1+ c, Y+1, PercentageFore+cor, 1), new Color(230, 0, 0));
                    for (int i = 2; i<31; i++) {
                        spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+1, Y+i, PercentageFore, 1), new Color(230-i, 0, 0));
                    }
                    spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+1+ c, Y+31, PercentageFore+cor, 1), new Color(200, 0, 0));
                }
            }

            //conners
            for (int y=0; y<4; y++){
                for (int x=0; x<4; x++) {
                    int a=connerLeftA[x,y];
                    if (a>0) {
                        Color c=new Color(bcolorh,bcolorh,bcolorh/*,a*/)*(a/255f);
                        spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+x,         Y+y, 1, 1), c);
                        spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size-x,    Y+y, 1, 1), c);
                        spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+x,      Y+32-y, 1, 1), c);
                        spriteBatch.Draw(Rabcr.Pixel, new Rectangle(X+Size-x, Y+32-y, 1, 1), c);
                    }
                }
            }

            if (Filled==1){
                if (Green) {
                    if (FilledBefore!=Filled){
                        text="Loaded";//"100%";
                        textW=X+Size/2f-Fonts.Medium.MeasureString(text).X/2f;
                    }
                    DrawTextShadowMinMedium(spriteBatch,textW,Y+2,text);
                } else {
                    DrawTextShadowMinMedium(spriteBatch,textEW,Y+2,errorText);
                }
            } else {
                if (FilledBefore!=Filled){
                    text=(int)(Filled*100)+"%";
                    textW=X+Size/2f-Fonts.Medium.MeasureString(text).X/2f;
                }
                DrawTextShadowMinMedium(spriteBatch,textW,Y+2,text);
            }
            if (FilledBefore!=Filled){
                //if (!set){
                    //if (Green) TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                    //else TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                //} else {
                //    if (lastG!=Green){
                //        if (Green) TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                //        else TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Error);
                //    }
                //}

                //try { TaskbarManager.Instance.SetProgressValue((int)(Filled*48), 48); } catch { }
                }

            FilledBefore=Filled;
            //lastG=Green;
            //Inner
            //int f = 255;
            //for (int i = 0; i<30; i++) {
            //    spriteBatch.Draw(Rabcr.Pixel, new Rectangle(Global.WindowWidthHalf-250+1, Global.WindowHeightHalf+32+i+1, (int)(Process()*498), 1), new Color(f, 0, 0));
            //    if (Process()!=0)
            //        spriteBatch.Draw(Rabcr.Pixel, new Rectangle(Global.WindowWidthHalf+(int)(Process()*498), Global.WindowHeightHalf+32+1, 1, 1), new Color(f, 0, 0, 128));
            //    f-=5;
            //}
            //if (finish) {
            //    try { TaskbarManager.Instance.SetProgressValue(1, 1); } catch { }
            //    spriteBatch.DrawString(Fonts.Medium, (errored==1 ? Lang.Texts[239] : Lang.Texts[240].Replace("%count%", errored.ToString()))+Environment.NewLine+errors, new Vector2(Global.WindowWidthHalf-250+0.5f, Global.WindowHeightHalf+35+32+0.5f), color_r0_g0_b0_a128);
            //    spriteBatch.DrawString(Fonts.Medium, (errored==1 ? Lang.Texts[239] : Lang.Texts[240].Replace("%count%", errored.ToString()))+Environment.NewLine+errors, new Vector2(Global.WindowWidthHalf-250, Global.WindowHeightHalf+35+32), Color.Black);
            //} else {
            //    spriteBatch.DrawString(Fonts.Medium, (int)(Process()*100)+"%", new Vector2(Global.WindowWidthHalf-Fonts.Medium.MeasureString((int)(Process()*100)+"%").X/2f, Global.WindowHeightHalf+35), Color.Black);
            //    try { TaskbarManager.Instance.SetProgressValue((int)(Process()*48), 48); } catch { }
            //}
        }

        void DrawTextShadowMinMedium(SpriteBatch sb, float x, float y, string str) {
		        /*if (Constants.Shadow)*/ sb.DrawString(Fonts.Medium, str, new Vector2(x+0.5f, y+0.5f), black25);
                sb.DrawString(Fonts.Medium, str, new Vector2(x, y), Color.Black);
        }
    }
}
