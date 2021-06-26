using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace rabcrClient {
    public abstract class ItemNonInv {
        public ushort Id;

        public abstract void SaveBytes(List<byte> arr);
    }

    class ItemNonInvBasic: ItemNonInv {

        public int Count;

        public ItemNonInvBasic(ushort id, int c) {
            Id=id;
            Count=c;
        }

        public ItemNonInvBasic(ushort id) {
            Id=id;
            Count=1;
        }

        #region Save
        public override void SaveBytes(List<byte> arr) {

            // Id
            arr.Add((byte)Id);
            arr.Add((byte)(Id >> 8));

            // Count
            ushort c = (ushort)Count;
            arr.Add((byte)c);
            arr.Add((byte)(c >> 8));
        }
        #endregion
    }

    class ItemNonInvTool: ItemNonInv {

        public int Count, Maximum;

        public ItemNonInvTool(ushort id, int count, int max) {
            Maximum=max;
            Id=id;
            Count=count;
        }

        public ItemNonInvTool(ushort id, int count)  {
            Maximum=GameMethods.ToolMax(id);
            Id=id;
            Count=count;
        }

        public ItemNonInvTool(ushort id) {
            Count=Maximum=GameMethods.ToolMax(id);
            Id=id;
        }

        #region Save
        public override void SaveBytes(List<byte> arr) {
            // Id
            arr.Add((byte)Id);
            arr.Add((byte)(Id >> 8));

            // Count
            ushort c = (ushort)Count;
            arr.Add((byte)c);
            arr.Add((byte)(c >> 8));
        }
        #endregion
    }

    class ItemNonInvFood: ItemNonInv {

        public int Count, CountMaximum;
        public float Descay, DescayMaximum;

        public ItemNonInvFood(ushort id, int count, int maxcount, float descay, float descayMax){
            Id=id;
            DescayMaximum=descayMax;
            CountMaximum=maxcount;

            Count=count;
            Descay=descay;
        }

        public ItemNonInvFood(ushort id, int count, float descay){
            Id=id;
            DescayMaximum=GameMethods.FoodMaxDescay(id);
            CountMaximum=GameMethods.FoodMaxCount(id);

            Count=count;
            Descay=descay;
        }

        #region Save
        public override unsafe void SaveBytes(List<byte> arr) {
            ushort c=(ushort)Count;

            float descay=Descay;
            byte* pointerDescay=(byte*)&descay;

            arr.AddRange(new List<byte>{

                // Id
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


      //  public ItemInvFood32 ToItemInvFood32(Texture2D tex, int x, int y) => new ItemInvFood32(tex,Id,Count,CountMaximum,Descay,DescayMaximum,x,y);
    }

    class ItemNonInvNonStackable: ItemNonInv {
        public ItemNonInvNonStackable(ushort id){
            Id=id;
        }

        public override void SaveBytes(List<byte> arr) {
            // Id
            arr.Add((byte)Id);
            arr.Add((byte)(Id >> 8));
        }
    }

    class ItemNonInvBasicColoritzedNonStackable: ItemNonInv{
        public Color color;

        public ItemNonInvBasicColoritzedNonStackable(ushort id, Color c) {
            Id=id;
            color=c;
        }

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
    }
}