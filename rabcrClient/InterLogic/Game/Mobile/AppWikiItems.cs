using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace rabcrClient.Mobile {
    class ScreenWikiItemsList:DrawingScreen {
        SpriteFont font;

        public override void Init() {
            font=GetDataFont("Medium");

            PageLenght=((int)Items._ItemsEnd*25)-398+15;
            base.Init();
        }

        public override void Draw(SpriteBatch sb, int X, int Y, int W, int H) {
            int totalItems=(int)Items._ItemsEnd+3;
            int nodesW=H/25;
            int start=(int)((totalItems-nodesW)*ScrollbarValue)<0 ? 0 :(int)((totalItems-nodesW)*ScrollbarValue);

            for (int i=start; i<=totalItems-3; i++){
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
                sb.DrawString(font, ((Items)i).ToString(),new Vector2(X+5,Y+i*25-(totalItems-nodesW)*ScrollbarValue*25+5+5+5), Color.White);
            }
            lastMouse=mouseDown;
            base.Draw(sb, X, Y, W, H);
        }
    }

    class ScreenWikiItemDetails:DrawingScreen {
        SpriteFont font;
        bool worked;

        public override void Init() {
            foreach (Items i in new List<Items>{
            //    Items.Underpants,
                Items.Backpack,
                Items.BackDirt,
                Items.BackSand,
                Items.BackCobblestone,
                Items.BareLabel,
                //Items.Biscuit,
                //Items.Boots,
                //Items.BottleLemonade,
                //Items.Bread,
                //Items.Cap,
                Items.Coral,
                Items.Door,
                Items.FewSticks,
                Items.FishMeat,
                Items.FishMeatCooked,
                //Items.Had,
                //Items.Jacket,
                //Items.Jeans,
              //  Items.JugWithWater,
                Items.KnifeBronze,
                Items.KnifeCopper,
                Items.KnifeIron,
             //   Items.KnifeStone,
               // Items.Lingerie,
                Items.Mobile,
                Items.Paper,
                Items.Radio,
               // Items.Ring,
                Items.Rod,
                //Items.ScafanderHelmet,
                //Items.ScafanderSuit,
                Items.Seaweed,
                //Items.Shorts,
                //Items.Socks,
                Items.SugarCane,
              //  Items.Tee,
                Items.TorchElectricOFF,
                Items.TorchElectricON,
                //Items.Trousers,
                //Items.TShirt,
                //Items.Underpants,
              //  Items.Vase,
                Items._ItemsEnd,
            }){
                if (i==(Items)((DataWiki)data).SelectedItem) worked=true;
            }


            font=GetDataFont("Medium");
        }

        public override void Draw(SpriteBatch sb, int X, int Y, int W, int H) {
            int id=((DataWiki)data).SelectedItem;
            Items item=(Items)id;
            BlockId blockId=BlockId.None;
            string type="";
            //{
            //    BlockId t=GameMethods.BackBlockFromItem(item);
            //    if (t!=BlockId.None) {
            //        blockId=t;
            //        type="BackBlock";
            //    }
            //}
            //{
            //    BlockId t=GameMethods.SolidBlockFromItem(item);
            //    if (t!=BlockId.None) {
            //        blockId=t;
            //        type="SolidBlock";
            //    }
            //}
            //{
            //    BlockId t=GameMethods.TopBlockFromItem(item);
            //    if (t!=BlockId.None) {
            //        blockId=t;
            //        type="TopBlock";
            //    }
            //}
            //{
            //    BlockId t=GameMethods.PlantFromItem(item);
            //    if (t!=BlockId.None) {
            //        blockId=t;
            //        type="Plant";
            //    }
           // }
            string add="";
            if (blockId==BlockId.None){
                add="\r\nPoložit: Ne";
            }else{
                add="\r\nPoložit: Ano";
                add+="\r\nPolož. jako: "+type;
                add+="\r\nPolož. block: "+blockId.ToString();
            }
            sb.DrawString(font,"Název: "+item.ToString()
                +"\r\nID: "+id
              //  +"\r\nSystémový: "+(item==Items._ItemsEnd || item==Items.None || item==Items._SystemMaxTools ? "Ano":"Ne")
                +"\r\nExperimentální: "+(worked ? "Ano":"Ne")
             //   +"\r\nNástroj: "+(id<(int)Items._SystemMaxTools && id!=0 ? "Ano":"Ne")
               // +"\r\nTopení: "+(GameMethods.BurnWoodInFurnace(item)==0 ? "Ne" : GameMethods.BurnWoodInFurnace(item)+"%")
                +add
                ,new Vector2(X+5,Y+5), Color.White);
            base.Draw(sb, X, Y, W, H);
        }
    }

    class DataWiki : InterAppData {
        public int SelectedItem;
    }
}
