using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace rabcrClient {
    public abstract class ItemInv {
        public ushort Id;

        public abstract void Draw();

        public abstract void DrawCreative();

        public abstract void SaveBytes(List<byte> arr);

        public abstract void SetPos(int x, int y);

        public virtual void SetPos(DInt d) => SetPos(d.X, d.Y);

        public abstract DInt GetPos();

        public abstract int GetPosX();

        public abstract int GetPosY();

        public abstract Vector2 GetPosVector2();

        public abstract ItemNonInv ToNon();
    }

    class ItemInvBlank :ItemInv{
        public ItemInvBlank() {
            Id=(int)Items.None;
        }

        #region Draw
        public override void Draw() { }

        public override void DrawCreative() { }
        #endregion

        #region Position
        public override void SetPos(int x, int y) { }

        public override void SetPos(DInt z) { }

        public override DInt GetPos() => null;
        #endregion

        public override ItemNonInv ToNon() => null;

        public override void SaveBytes(List<byte> arr) {
            arr.Add(0);
            arr.Add(0);
        }

        public override int GetPosX() => 0;

        public override int GetPosY() => 0;

        public override Vector2 GetPosVector2() => Vector2.Zero;
    }

    class ItemInvBasic16: ItemInv {

        #region Varibles
        public int GetCount;
        public readonly Texture2D Texture;
        public Rectangle posTex;
        Vector2 posNum, posNumSh;
        string strItem;
        bool drawText;
        Color white;
        #endregion

        public int SetCount {
            set {
                //if (GetCount==1 && value>GetCount){ 
                //    strItem=GetCount.ToString();
                //    drawText=true;
                //    if (posNum==null){
                //        posNum=new Vector2(posTex.X, posTex.Y+20);
                //        posNumSh=new Vector2(posNum.X+0.5f, posNum.Y+0.5f);
                //    }
                //}
 
                //if (GetCount>1 && value==1){ 

                //}


                if (drawText) {
                    if (value==1) {

                        // Foget
                        strItem=null;
                        drawText=false;
                    } else {

                        // Rewrite bigger number
                        strItem=value.ToString();
                    }
                } else {

                    // new big num
                    if (value>1) {
                        strItem=value.ToString();
                        drawText=true;
                        if (GetCount==1) {
                            posNum=new Vector2(posTex.X, posTex.Y+20);
                            posNumSh=new Vector2(posNum.X+0.5f, posNum.Y+0.5f);
                        }
                    }
                }

                GetCount=value;
            }
        }

        public ItemInvBasic16(Texture2D tex, ushort id, int c, int x, int y) {
            posTex=new Rectangle(x, y, 32, 32);
            Texture=tex;
            Id=id;
            GetCount=c;
            white=Color.White;

            if (c!=1) {
                strItem=c.ToString();
                drawText=true;
                posNum=new Vector2(x, y+20);
                posNumSh=new Vector2(posNum.X+0.5f, posNum.Y+0.5f);
            }
        }

        public ItemInvBasic16(Texture2D tex, ushort id, int c) {
            posTex=new Rectangle(0, 0, 32, 32);
            Texture=tex;
            Id=id;
            GetCount=c;
            white=Color.White;

            if (c!=1) {
                strItem=GetCount.ToString();
                drawText=true;
                //posNum=new Vector2(x, y+20);
                //posNumSh=new Vector2(posNum.X+0.5f, posNum.Y+0.5f);
            }
        }

        #region Draw
        public override void Draw() {
            Rabcr.spriteBatch.Draw(Texture, posTex, white);

            if (drawText) {
                Rabcr.spriteBatch.DrawString(Fonts.Small, strItem, posNum, Rabcr.color_r0_g0_b0_a100);
                Rabcr.spriteBatch.DrawString(Fonts.Small, strItem, posNumSh, Color.Black);
            }
        }

        public override void DrawCreative() => Rabcr.spriteBatch.Draw(Texture, posTex, white);
        #endregion

        #region Position
        public override void SetPos(int x, int y) {
            posTex.X=x;
            posTex.Y=y;

            posNum.X=x;
            posNum.Y=y+20;

            posNumSh.X=posNum.X+0.5f;
            posNumSh.Y=posNum.Y+0.5f;
        }

        public override DInt GetPos() => new DInt{X=posTex.X, Y=posTex.Y };
        #endregion

       // public void AddOne() => SetCount=GetCount+1;

        public void RemoveOne() => SetCount=GetCount-1;

        #region Save
        //public override List<byte> SaveBytes() {
        //    ushort c=(ushort)GetCount;

        //    return new List<byte>{
        //        // Id
        //        (byte)(Id >> 8),
        //        (byte)Id,

        //        // Count
        //        (byte)(c >> 8),
        //        (byte)c,
        //    };
        //}

        public override void SaveBytes(List<byte> arr) {
            //Id
            arr.Add((byte)Id);
            arr.Add((byte)(Id >> 8));

            // Count
            ushort c=(ushort)GetCount;
            arr.Add((byte)c);
            arr.Add((byte)(c >> 8));
        }
        #endregion

        public override ItemNonInv ToNon() => new ItemNonInvBasic(Id,GetCount);

        public override int GetPosX() => posTex.X;

        public override int GetPosY() => posTex.Y;

        public override Vector2 GetPosVector2() => new Vector2{ X=posTex.X, Y=posTex.Y };
    }

    class ItemInvBasic32: ItemInv{

        #region Varibles
        public int GetCount;
        public readonly Texture2D Texture;

        Vector2 posNum, posNumSh;
        Vector2 posTex;
        Color white;
        string strItem;
        bool drawText;
        #endregion

        public int SetCount {
            set {
                GetCount=value;

                if (drawText) {
                    if (GetCount==1) {

                        // Foget
                        strItem=null;
                    } else {

                        // Rewrite bigger number
                        strItem=GetCount.ToString();
                    }
                } else {

                    // new big num
                    if (GetCount!=1) {
                        strItem=GetCount.ToString();
                        drawText=true;
                        if (posNum==null){
                            posNum=new Vector2(posTex.X, posTex.Y+20);
                            posNumSh=new Vector2(posNum.X+0.5f, posNum.Y+0.5f);
                        }
                    }
                }
            }
        }

      //  public void AddOne() => SetCount=GetCount+1;

        public void RemoveOne() => SetCount=GetCount-1;

        public ItemInvBasic32(Texture2D tex, ushort id, int c, int x, int y){
            posTex=new Vector2(x, y);
            Id=id;
            Texture=tex;
            GetCount=c;
            white=Color.White;

            if (c!=1){
                strItem=GetCount.ToString();
                drawText=true;
                posNum=new Vector2(x, y+20);
                posNumSh=new Vector2(posNum.X+0.5f, posNum.Y+0.5f);
            }
        }

        public ItemInvBasic32(Texture2D tex, ushort id, int c){
           // posTex=new Vector2(x, y);
            Id=id;
            Texture=tex;
            GetCount=c;
            white=Color.White;

            if (c!=1){
                strItem=GetCount.ToString();
                drawText=true;
               // posNum=new Vector2(x, y+20);
               // posNumSh=new Vector2(posNum.X+0.5f, posNum.Y+0.5f);
            }
        }

        public ItemInvBasic32(Texture2D tex, ushort id, int c, Vector2 pos){
            posTex=pos;
            Id=id;
            Texture=tex;
            GetCount=c;
            white=Color.White;

            if (c!=1){
                strItem=GetCount.ToString();
                drawText=true;
                posNum=new Vector2(pos.X, pos.Y+20);
                posNumSh=new Vector2(posNum.X+0.5f, posNum.Y+0.5f);
            }
        }

        #region Draw
        public override void Draw() {
            Rabcr.spriteBatch.Draw(Texture, posTex, white);
            if (strItem!=null){
                if (drawText) {
		            /*if (Constants.Shadow) */Rabcr.spriteBatch.DrawString(Fonts.Small, strItem, posNum, Rabcr.color_r0_g0_b0_a100);
                    Rabcr.spriteBatch.DrawString(Fonts.Small, strItem, posNumSh, Color.Black);
                }
            }
        }

        public override void DrawCreative() => Rabcr.spriteBatch.Draw(Texture, posTex, white);
        #endregion

        #region Save
        public override unsafe void SaveBytes(List<byte> arr) {

            //Id
            arr.Add((byte)Id);
            arr.Add((byte)(Id >> 8));

            // Count
            ushort c=(ushort)GetCount;
            arr.Add((byte)c);
            arr.Add((byte)(c >> 8));
        }
        #endregion

        public override DInt GetPos() => new DInt{X=(int)posTex.X, Y=(int)posTex.Y };

        public override void SetPos(int x, int y){
            posTex.X=x;
            posTex.Y=y;

            posNum.X=x;
            posNum.Y=y+20;

            posNumSh.X=posNum.X+0.5f;
            posNumSh.Y=posNum.Y+0.5f;
        }

        public override ItemNonInv ToNon() => new ItemNonInvBasic(Id, GetCount);

        public override int GetPosX() => (int)posTex.X;

        public override int GetPosY() => (int)posTex.Y;

        public override Vector2 GetPosVector2() => posTex;
    }

    class ItemInvTool32: ItemInv {

        #region Varibles
        public int GetCount, Maximum;
        public readonly Texture2D Texture;
        Rectangle bar1, bar2, bar3;
        public Vector2 posTex;
        Color ColorWhite, ColorBlack, ColorGreen, ColorRed;
        bool DrawRed;
        #endregion

        public int SetCount {
            set {
                GetCount=value;
                int v=(int)(GetCount/(float)Maximum*30);

                if (v!=bar2.Width){
                    int x=(int)posTex.X, y=(int)posTex.Y;
                    bar1= new Rectangle(x, y+28, 32, 5);
                    bar2=new Rectangle(x+1, y+29, v, 3);
                    DrawRed=30!=v;
                    if (DrawRed) bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
                }
            }
        }

        public ItemInvTool32(Texture2D tex, ushort id, int count, int max, int x, int y){
            posTex=new Vector2(x,y);
            Maximum=max;
            Id=id;
            GetCount=count;
            Texture=tex;

            ColorWhite=Color.White;
            ColorBlack=Color.Black;
            ColorRed=Color.Red;
            ColorGreen=Color.Green;

            int v=(int)(GetCount/(float)Maximum*30);
            bar1= new Rectangle(x, y+28, 32, 5);
            bar2=new Rectangle(x+1, y+29, v, 3);
            DrawRed=30!=v;
            if (DrawRed) bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

        public ItemInvTool32(Texture2D tex, ushort id, int count, int x, int y){
            posTex=new Vector2(x,y);
            Maximum=GameMethods.ToolMax(id);
            Id=id;
            GetCount=count;
            Texture=tex;

            ColorWhite=Color.White;
            ColorBlack=Color.Black;
            ColorRed=Color.Red;
            ColorGreen=Color.Green;

            int v=(int)(GetCount/(float)Maximum*30);
            bar1= new Rectangle(x, y+28, 32, 5);
            bar2=new Rectangle(x+1, y+29, v, 3);
            DrawRed=30!=v;
            if (DrawRed) bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

        public ItemInvTool32(Texture2D tex, ushort id, int count, int max) {
            // posTex=new Vector2(x,y);
            Maximum=max;
            Id=id;
            GetCount=count;
            Texture=tex;

            ColorWhite=Color.White;
            ColorBlack=Color.Black;
            ColorRed=Color.Red;
            ColorGreen=Color.Green;

            //  int v=(int)(GetCount/(float)Maximum*30);
            //  bar1= new Rectangle(x, y+28, 32, 5);
            // bar2=new Rectangle(x+1, y+29, v, 3);
            bar2.Width=-1;
            // DrawRed=30!=v;
            //if (DrawRed) bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

        public ItemInvTool32(Texture2D tex, ushort id, int count) {
           // posTex=new Vector2(x,y);
            Maximum=GameMethods.ToolMax(id);
            Id=id;
            GetCount=count;
            Texture=tex;

            ColorWhite=Color.White;
            ColorBlack=Color.Black;
            ColorRed=Color.Red;
            ColorGreen=Color.Green;

          //  int v=(int)(GetCount/(float)Maximum*30);
          //  bar1= new Rectangle(x, y+28, 32, 5);
           // bar2=new Rectangle(x+1, y+29, v, 3);
            bar2.Width=-1;
           // DrawRed=30!=v;
            //if (DrawRed) bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

         public ItemInvTool32(Texture2D tex, ushort id) {
            GetCount=Maximum=GameMethods.ToolMax(id);
            Id=id;
            Texture=tex;

            ColorWhite=Color.White;
            ColorBlack=Color.Black;
            ColorRed=Color.Red;
            ColorGreen=Color.Green;

          //  int v=(int)(GetCount/(float)Maximum*30);
          //  bar1= new Rectangle(x, y+28, 32, 5);
           // bar2=new Rectangle(x+1, y+29, v, 3);
            bar2.Width=-1;
           // DrawRed=30!=v;
            //if (DrawRed) bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

        #region Draw
        public override void Draw() {
            Rabcr.spriteBatch.Draw(Texture, posTex, ColorWhite);

            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar1, ColorBlack);
            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar2, ColorGreen);
            if (DrawRed) Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar3, ColorRed);
        }

        public override void DrawCreative() => Rabcr.spriteBatch.Draw(Texture, posTex, ColorWhite);
        #endregion

        #region Save
        public override void SaveBytes(List<byte> arr) {
           //Id
            arr.Add((byte)Id);
            arr.Add((byte)(Id >> 8));

            // Count
            ushort c=(ushort)GetCount;
            arr.Add((byte)c);
            arr.Add((byte)(c >> 8));
        }
        #endregion

        public override void SetPos(int x, int y){
            posTex.X=x;
            posTex.Y=y;

            bar1.X=x;
            bar1.Y=y+28;

            bar2.X=x+1;
            bar2.Y=y+29;

            bar3.X=x+1+bar2.Width;
            bar3.Y=y+29;
        }

        public override DInt GetPos() => new DInt{X=(int)posTex.X, Y=(int)posTex.Y };

        public override ItemNonInv ToNon() => new ItemNonInvTool(Id, GetCount);

        public override int GetPosX() => (int)posTex.X;

        public override int GetPosY() => (int)posTex.Y;

        public override Vector2 GetPosVector2() => new Vector2{ X=posTex.X, Y=posTex.Y };
    }

    class ItemInvTool16: ItemInv {

        #region Varibles
        public int GetCount, Maximum;
        public Rectangle posTex;
        public readonly Texture2D Texture;

        Rectangle bar1, bar2, bar3;
        #endregion

        public int SetCount {
            set {
                GetCount=value;
                int v = (int)(GetCount/(float)Maximum*30);

                if (v!=bar2.Width) {
                    int x = posTex.X, y = posTex.Y;
                    bar1=new Rectangle(x, y+28, 32, 5);
                    bar2=new Rectangle(x+1, y+29, v, 3);
                    bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
                }
            }
        }

        public ItemInvTool16(Texture2D tex, ushort id, int c, int max, int x, int y) {
            posTex=new Rectangle(x, y, 32, 32);
            Id=id;
            GetCount=c;
            Maximum=max;
            Texture=tex;

            int v = (int)(GetCount/(float)Maximum*30);
            bar1=new Rectangle(x, y+28, 32, 5);
            bar2=new Rectangle(x+1, y+29, v, 3);
            bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

        public ItemInvTool16(Texture2D tex, ushort id, int c, int x, int y) {
            posTex=new Rectangle(x, y, 32, 32);
            Id=id;
            GetCount=c;
            Maximum=GameMethods.ToolMax(id);
            Texture=tex;

            int v = (int)(GetCount/(float)Maximum*30);
            bar1=new Rectangle(x, y+28, 32, 5);
            bar2=new Rectangle(x+1, y+29, v, 3);
            bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }
        public ItemInvTool16(Texture2D tex, ushort id, int c, int max) {
            posTex=new Rectangle(0, 0, 32, 32);
            Id=id;
            GetCount=c;
            Maximum=max;
            Texture=tex;

            bar2.Width=-1;
            // int v = (int)(GetCount/(float)Maximum*30);
            // bar1=new Rectangle(x, y+28, 32, 5);
            // bar2=new Rectangle(x+1, y+29, v, 3);
            // bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

        public ItemInvTool16(Texture2D tex, ushort id) {
            posTex=new Rectangle(0, 0, 32, 32);
            Id=id;
            GetCount=Maximum=GameMethods.ToolMax(id);
           
            Texture=tex;

            bar2.Width=-1;
        }
        #region Draw
        public override void Draw() {
            Rabcr.spriteBatch.Draw(Texture, posTex, Color.White);

            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar1, Color.Black);
            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar3, Color.Red);
            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar2, Color.Green);
        }

        public override void DrawCreative() => Rabcr.spriteBatch.Draw(Texture, posTex, Color.White);
        #endregion

        #region Save
        public override void SaveBytes(List<byte> arr) {
           //Id
            arr.Add((byte)Id);
            arr.Add((byte)(Id >> 8));

            // Count
            ushort c=(ushort)GetCount;
            arr.Add((byte)c);
            arr.Add((byte)(c >> 8));
        }
        #endregion

        public override DInt GetPos() => new DInt{ X=posTex.X, Y=posTex.Y };

        public override void SetPos(int x, int y) {
            posTex.X=x;
            posTex.Y=y;

            bar1.X=x;
            bar1.Y=y+28;

            bar2.X=x+1;
            bar2.Y=y+29;

            bar3.X=x+1+bar2.Width;
            bar3.Y=y+29;
        }

        public override ItemNonInv ToNon() => new ItemNonInvTool(Id, GetCount);

        public override int GetPosX() => posTex.X;

        public override int GetPosY() => posTex.Y;

        public override Vector2 GetPosVector2() => new Vector2{ X=posTex.X, Y=posTex.Y };
    }

    class ItemInvFood16: ItemInv {

        #region Varibles
        public int GetCount, CountMaximum;
        public readonly Texture2D Texture;
        public float GetDescay, DescayMaximum;

        Rectangle posTex, bar1, bar2, bar3;
        Color colorDescay, ColorWhite;
        #endregion

        public int SetCount {
            set {
                int oldv=(int)((GetCount/(float)CountMaximum)*30);
                GetCount=value;
                int v=(int)((GetCount/(float)CountMaximum)*30);

                if (v!=oldv){
                    int x=posTex.X, y=posTex.Y;
                    bar1=new Rectangle(x, y+28, 32, 5);
                    bar2=new Rectangle(x+1, y+29, v, 3);
                    bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
                }
            }
        }

        public float SetDescay{
            set {
                GetDescay=value;
                int d=(int)((GetDescay/DescayMaximum)*255);
                colorDescay=new Color((uint)((255 << 24) | (d << 8) | (255-d)));
            }
        }

        public ItemInvFood16(Texture2D tex, ushort id, int count, int maxcount, float descay, float descayMax, int x, int y){
            posTex=new Rectangle(x, y, 32, 32);
            DescayMaximum=descayMax;
            GetCount=count;
            ColorWhite=Color.White;
            Id=id;
            Texture=tex;
            CountMaximum=maxcount;

            // Descay
            GetDescay=descay;
            int d=(int)(GetDescay/DescayMaximum*255);
            colorDescay=new Color((uint)((255 << 24) | (d << 8) | (255-d)));

            // Count
            int v=(int)((GetCount/(float)CountMaximum*30)+0.49f);
            bar1= new Rectangle(x, y+28, 32, 5);
            bar2=new Rectangle(x+1, y+29, v, 3);
            bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

        public ItemInvFood16(Texture2D tex, ushort id, int count, float descay, int x, int y) {
            posTex=new Rectangle(x, y, 32, 32);
            DescayMaximum=GameMethods.FoodMaxDescay(id);
            GetCount=count;
            ColorWhite=Color.White;
            Id=id;
            Texture=tex;
            CountMaximum=GameMethods.FoodMaxCount(id);

            // Descay
            GetDescay=descay;
            int d=(int)(GetDescay/DescayMaximum*255);
            colorDescay=new Color((uint)((255 << 24) | (d << 8) | (255-d)));

            // Count
            int v=(int)((GetCount/(float)CountMaximum*30)+0.49f);
            bar1= new Rectangle(x, y+28, 32, 5);
            bar2=new Rectangle(x+1, y+29, v, 3);
            bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

        public ItemInvFood16(Texture2D tex, ushort id, int count, int maxcount, float descay, float descayMax) {
             posTex=new Rectangle(0, 0, 32, 32);
            DescayMaximum=descayMax;
            GetCount=count;
            ColorWhite=Color.White;
            Id=id;
            Texture=tex;
            CountMaximum=maxcount;

            // Descay
            GetDescay=descay;
            int d = (int)(GetDescay/DescayMaximum*255);
            colorDescay=new Color((uint)((255 << 24) | (d << 8) | (255-d)));

            bar2.Width=-1;
        }

        public ItemInvFood16(Texture2D tex, ushort id, int count, float descay) {
            posTex=new Rectangle(0, 0, 32, 32);
            DescayMaximum=GameMethods.FoodMaxDescay(id);
            GetCount=count;
            ColorWhite=Color.White;
            Id=id;
            Texture=tex;
            CountMaximum=GameMethods.FoodMaxCount(id);

            // Descay
            GetDescay=descay;
            int d=(int)(GetDescay/DescayMaximum*255);

           colorDescay=new Color((uint)((255 << 24) | (d << 8) | (255-d)));

            bar2.Width=-1;
        }

        #region Draw
        public override void Draw() {
            Rabcr.spriteBatch.Draw(Texture, posTex, ColorWhite);

            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar1, Color.Black);
            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar3, ColorWhite);
            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar2, colorDescay);
        }

        public override void DrawCreative() => Rabcr.spriteBatch.Draw(Texture, posTex, ColorWhite);
        #endregion

        #region Save
        public unsafe override void SaveBytes(List<byte> arr) {
            ushort c=(ushort)GetCount;
            float descay=GetDescay;
            byte* pointerDescay=(byte*)&descay;

            arr.AddRange(new List<byte>{

                //Id
                (byte)Id,
                (byte)(Id >> 8),

                // Count
                (byte)c,
                (byte)(c >> 8),

                // Descay
                pointerDescay[0],
                pointerDescay[1],
                pointerDescay[2],
                pointerDescay[3]
            });
        }
        #endregion

        public override DInt GetPos() => new DInt{ X=posTex.X, Y=posTex.Y };

        public override void SetPos(int x, int y){
            posTex.X=x;
            posTex.Y=y;

            bar1.X=x;
            bar1.Y=y+28;

            bar2.X=x+1;
            bar2.Y=y+29;

            bar3.X=x+1+bar2.Width;
            bar3.Y=y+29;
        }

        public override ItemNonInv ToNon() => new ItemNonInvFood(Id,GetCount,CountMaximum,GetDescay,DescayMaximum);

        public override int GetPosX() => posTex.X;

        public override int GetPosY() => posTex.Y;

        public override Vector2 GetPosVector2() => new Vector2{ X=posTex.X, Y=posTex.Y };
    }

    class ItemInvFood32: ItemInv {

        #region Varibles
        public int GetCount, CountMaximum;
        public readonly Texture2D Texture;
        Vector2 posTex;
        Rectangle bar1, bar2, bar3;
        Color colorDescay, ColorWhite;
        public float GetDescay, DescayMaximum;
        #endregion

        public int SetCount {
            set {
                GetCount=value;
                int v=(int)(GetCount/(float)CountMaximum*30+0.49f);

                if (v!=bar2.Width){
                    int x=(int)posTex.X, y=(int)posTex.Y;
                    bar1= new Rectangle(x, y+28, 32, 5);
                    bar2=new Rectangle(x+1, y+29, v, 3);
                    bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
                }
            }
        }

        public float SetDescay {
            set {
                GetDescay=value;
                int d=(int)(GetDescay/DescayMaximum*255);
                colorDescay=new Color((uint)((255 << 24) | (d << 8) | (255-d)));
            }
        }

        public ItemInvFood32(Texture2D tex, ushort id, int count, int maxcount, float descay, float descayMax, int x, int y) {
            posTex=new Vector2(x, y);
            DescayMaximum=descayMax;
            GetCount=count;
            Id=id;
            Texture=tex;

            ColorWhite=Color.White;

            // Descay
            GetDescay=descay;
            int d=(int)(GetDescay/DescayMaximum*255);
            colorDescay=new Color((uint)((255 << 24) | (d << 8) | (255-d)));

            // Count
            CountMaximum=maxcount;
            int v=(int)(GetCount/(float)CountMaximum*30+0.49f);
            bar1=new Rectangle(x, y+28, 32, 5);
            bar2=new Rectangle(x+1, y+29, v, 3);
            bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

        public ItemInvFood32(Texture2D tex, ushort id, int count, float descay, int x, int y) {
            posTex=new Vector2(x, y);
            DescayMaximum=GameMethods.FoodMaxDescay(id);
            GetCount=count;
            Id=id;
            Texture=tex;

            ColorWhite=Color.White;

            // Descay
            GetDescay=descay;
            int d=(int)((GetDescay/DescayMaximum)*255);
            colorDescay=new Color((uint)((255 << 24) | (d << 8) | (255-d)));

            // Count
            CountMaximum=GameMethods.FoodMaxCount(id);
            int v=(int)(GetCount/(float)CountMaximum*30+0.49f);
            bar1=new Rectangle(x, y+28, 32, 5);
            bar2=new Rectangle(x+1, y+29, v, 3);
            bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

        //public ItemInvFood32(Texture2D tex, ushort id, int count, int maxcount, float descay, float descayMax) {
        //    //  posTex=new Vector2(x, y);
        //    DescayMaximum=descayMax;
        //    GetCount=count;
        //    Id=id;
        //    Texture=tex;

        //    ColorWhite=Color.White;

        //    // Descay
        //    GetDescay=descay;
        //    int d = (int)(GetDescay/DescayMaximum*255);
        //    colorDescay=new Color(255-d, d, 0);

        //    // Count
        //    CountMaximum=maxcount;
        //    // int v=(int)(GetCount/(float)CountMaximum*30+0.49f);
        //    bar2.Width=-1;
        //    //bar1=new Rectangle(x, y+28, 32, 5);
        //    // bar2=new Rectangle(x+1, y+29, v, 3);
        //    //bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        //}

        public ItemInvFood32(Texture2D tex, ushort id, int count, float descay) {
          //  posTex=new Vector2(x, y);
            DescayMaximum=GameMethods.FoodMaxDescay(id);
            GetCount=count;
            Id=id;
            Texture=tex;

            ColorWhite=Color.White;

            // Descay
            GetDescay=descay;
            int d=(int)(GetDescay/DescayMaximum*255);
            colorDescay=new Color((uint)((255 << 24) | (d << 8) | (255-d)));

            // Count
            CountMaximum=GameMethods.FoodMaxCount(id);
           // int v=(int)(GetCount/(float)CountMaximum*30+0.49f);
            bar2.Width=-1;
            //bar1=new Rectangle(x, y+28, 32, 5);
           // bar2=new Rectangle(x+1, y+29, v, 3);
            //bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }

          public ItemInvFood32(Texture2D tex, ushort id) {
            DescayMaximum=GameMethods.FoodMaxDescay(id);
            GetCount=GetCount=GameMethods.FoodMaxCount(id);
            Id=id;
            Texture=tex;

            ColorWhite=Color.White;

            // Descay
            int d=(int)(GetDescay/DescayMaximum*255);
      //      colorDescay=new Color((byte)(255-d),(byte)d,0);
               colorDescay=new Color((uint)((255 << 24) | (d << 8) | (255-d)));

            // Count
           // CountMaximum=GameMethods.FoodMaxCount(id);
           // int v=(int)(GetCount/(float)CountMaximum*30+0.49f);
            bar2.Width=-1;
            //bar1=new Rectangle(x, y+28, 32, 5);
           // bar2=new Rectangle(x+1, y+29, v, 3);
            //bar3=new Rectangle(x+1+v, y+29, 30-v, 3);
        }
        #region Draw
        public override void Draw() {
            Rabcr.spriteBatch.Draw(Texture, posTex, ColorWhite);

            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar1, Color.Black);
            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar2, colorDescay);
            Rabcr.spriteBatch.Draw(Rabcr.Pixel, bar3, ColorWhite);
        }

        public override void DrawCreative() => Rabcr.spriteBatch.Draw(Texture, posTex, ColorWhite);
        #endregion

        #region Save
        public override unsafe void SaveBytes(List<byte> arr) {
           ushort c=(ushort)GetCount;
            float descay=GetDescay;
            byte* pointerDescay=(byte*)&descay;

            arr.AddRange(new List<byte>{

                //Id
                (byte)Id,
                (byte)(Id >> 8),

                // Count
                (byte)c,
                (byte)(c >> 8),

                // Descay
                pointerDescay[0],
                pointerDescay[1],
                pointerDescay[2],
                pointerDescay[3]
            });
        }
        #endregion

        public override DInt GetPos() => new DInt{ X=(int)posTex.X, Y=(int)posTex.Y };

        public override void SetPos(int x, int y){
            posTex.X=x;
            posTex.Y=y;

            bar1.X=x;
            bar1.Y=y+28;

            bar2.X=x+1;
            bar2.Y=y+29;

            bar3.X=x+1+bar2.Width;
            bar3.Y=y+29;
        }

        public override ItemNonInv ToNon() => new ItemNonInvFood(Id,GetCount,CountMaximum,GetDescay,DescayMaximum);

        public override int GetPosX() => (int)posTex.X;

        public override int GetPosY() => (int)posTex.Y;

        public override Vector2 GetPosVector2() => posTex;
    }

    class ItemInvNonStackable16: ItemInv {
        public readonly Texture2D Texture;
        Rectangle posTex;
        Color ColorWhite=Color.White;

        public ItemInvNonStackable16(Texture2D tex, ushort id, int x, int y){
            posTex=new Rectangle(x, y, 32, 32);
            Texture=tex;
            Id=id;
        }

        public ItemInvNonStackable16(Texture2D tex, ushort id) {
            Texture=tex;
            posTex=new Rectangle(0, 0, 32, 32);
            Id=id;
        }

        #region Draw
        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, posTex, ColorWhite);

        public override void DrawCreative() => Rabcr.spriteBatch.Draw(Texture, posTex, ColorWhite);
        #endregion

        public override DInt GetPos() => new DInt{X=posTex.X, Y=posTex.Y }/*(posTex.X, posTex.Y)*/;

        public override void SetPos(int x, int y) {
            posTex.X=x;
            posTex.Y=y;
        }

        public override ItemNonInv ToNon() => new ItemNonInvNonStackable(Id);

        public override void SaveBytes(List<byte> arr) {
            arr.Add((byte)Id);
            arr.Add((byte)(Id >> 8));
        }

        public override int GetPosX() => posTex.X;

        public override int GetPosY() => posTex.Y;

        public override Vector2 GetPosVector2() => new Vector2{ X=posTex.X, Y=posTex.Y };
    }

    class ItemInvNonStackable32: ItemInv {

        #region Varibles
        public readonly Texture2D Texture;
        Vector2 posTex;
        Color ColorWhite=Color.White;
        #endregion

        public ItemInvNonStackable32(Texture2D tex, ushort id, int x, int y){
            posTex=new Vector2(x,y);
            Texture=tex;
            Id=id;
        }

        public ItemInvNonStackable32(Texture2D tex, ushort id, Vector2 pos){
            posTex=pos;
            Texture=tex;
            Id=id;
        }

        public ItemInvNonStackable32(Texture2D tex, ushort id) {
            Texture=tex;
            Id=id;
        }

        #region Draw
        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, posTex, ColorWhite);

        public override void DrawCreative() => Rabcr.spriteBatch.Draw(Texture, posTex, ColorWhite);
        #endregion

        #region Save
        public override void SaveBytes(List<byte> arr) {
            arr.Add((byte)Id);
            arr.Add((byte)(Id >> 8));
        }
        #endregion

        public override void SetPos(int x, int y) {
            posTex.X=x;
            posTex.Y=y;
        }

        public override DInt GetPos() => new DInt{X=(int)posTex.X, Y=(int)posTex.Y }/*(, )*/;

        public override ItemNonInv ToNon() => new ItemNonInvNonStackable(Id);

        public override int GetPosX() => (int)posTex.X;

        public override int GetPosY() => (int)posTex.Y;

        public override Vector2 GetPosVector2() => posTex;
    }

    class ItemInvBasicColoritzed32NonStackable: ItemInv{

        #region Varibles
        public Color color;
        public readonly Texture2D Texture;
        Vector2 posTex;
        #endregion

        public ItemInvBasicColoritzed32NonStackable(Texture2D tex, ushort id, Color c, int x, int y){
            posTex=new Vector2(x,y);
            Id=id;
            Texture=tex;
            color=c;
        }

        public ItemInvBasicColoritzed32NonStackable(Texture2D tex, ushort id, Color c, Vector2 vec){
            posTex=vec;
            Id=id;
            Texture=tex;
            color=c;
        }

        public ItemInvBasicColoritzed32NonStackable(Texture2D tex, ushort id, Color c){
            Id=id;
            Texture=tex;
            color=c;
        }

        #region Draw
        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, posTex, color);

        public override void DrawCreative() => Rabcr.spriteBatch.Draw(Texture, posTex, color);
        #endregion

        #region Save
        public override void SaveBytes(List<byte> arr) {
            // Id
            arr.Add((byte)Id);
            arr.Add((byte)(Id >> 8));

            // Color
            arr.Add(color.R);
            arr.Add(color.G);
            arr.Add(color.B);
        }
        #endregion

        #region positions
        // Set
        public override void SetPos(int x, int y) {
            posTex.X=x;
            posTex.Y=y;
        }

        public void SetPos(Vector2 pos) => posTex=pos;

        // Get
        public override DInt GetPos() => new DInt{ X=(int)posTex.X, Y=(int)posTex.Y };

        public override Vector2 GetPosVector2() => posTex;

        public override int GetPosX() => (int)posTex.X;
        public override int GetPosY() => (int)posTex.Y;
        #endregion

        public override ItemNonInv ToNon() => new ItemNonInvBasicColoritzedNonStackable(Id,color);
    }
}