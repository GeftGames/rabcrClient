using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace rabcrClient.Mobile {
    class ScreenWikiBlocksList:DrawingScreen {
        SpriteFont font;

        public override void Init() {
            font=GetDataFont("Medium");

            PageLenght=(Enum.GetNames(typeof(BlockId)).Length*25)-398+15;
            base.Init();
        }

        public override void Draw(SpriteBatch sb, int X, int Y, int W, int H) {
            int totalItems = Enum.GetNames(typeof(BlockId)).Length+3;
            int nodesW=H/25;
            int start=(int)((totalItems-nodesW)*ScrollbarValue)<0 ? 0 :(int)((totalItems-nodesW)*ScrollbarValue);

            for (int i=start; i<=totalItems-4; i++){
                if (i>start+nodesW-1) break;
                float a=0;
                if (In(mouse,X+5,(int)(Y+i*25-(totalItems-nodesW)*ScrollbarValue*25+5+5+5),W-25,24)) {
                    if (mouseDown)a=0.33f;
                    else {
                        a=0.2f;
                        if (lastMouse){
                            thisWindow=1;
                            ((DataWiki)data).SelectedItem=i;
                        }
                    }
                }
                sb.Draw(Rabcr.Pixel, new Rectangle(X+5,(int)(Y+i*25-(totalItems-nodesW)*ScrollbarValue*25+5+5+5),W-25,24), Color.White*a);
                sb.DrawString(font, ((BlockId)i).ToString(),new Vector2(X+5,Y+i*25-(totalItems-nodesW)*ScrollbarValue*25+5+5+5), Color.White);
            }
            lastMouse=mouseDown;
            base.Draw(sb, X, Y, W, H);
        }
    }

    class ScreenWikiBlockDetails:DrawingScreen {
       // public int selectedItem;
        SpriteFont font;

        public override void Init() {
            font=GetDataFont("Medium");
        }

        public override void Draw(SpriteBatch sb, int X, int Y, int W, int H) {
            int id=((DataWiki)data).SelectedItem;
            BlockId item=(BlockId)id;
            sb.DrawString(font,"Název: "+item.ToString()
                +"\r\nID: "+id
                +"\r\nSystémový: "+(item==BlockId.None || ((BlockId)item).ToString().StartsWith("_") ? "Ano":"Ne")
                +(id==1 ? "\r\nInfo:\r\nTento block\r\nslouží ke kompresi\r\nuloženého světa":"")
                //+"\r\nTopení: "+(GameMethods.BurnWoodInFurnace(item)==0 ? "Ne" : GameMethods.BurnWoodInFurnace(item)+"%")
                ,new Vector2(X+5,Y+5), Color.White);
            base.Draw(sb, X, Y, W, H);
        }
    }
}
