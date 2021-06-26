using Microsoft.Xna.Framework;
using System.Collections.Generic;

//namespace rabcrClient {
public class/*struct*/ DInt {
    public int X, Y;
  //  public bool Defined;
    //static DInt zero=new DInt(0, 0),
    //    notDefined=new DInt(0, 0){ Defined=false };

    //public static DInt Zero => zero;

    //public static DInt NotDefined => notDefined;

    public DInt () { }

    public DInt (int x, int y) {
        X = x;
        Y = y;
      //  Defined=true;
    }

	//public DInt (Vector2 vec) {
 //       X = (int)vec.X;
 //       Y = (int)vec.Y;
 //      // Defined=true;
 //   }

//	public Vector2 Vector() => new Vector2(X, Y);

    public DInt Clone() => (DInt)MemberwiseClone();
}

//public class InventorySlot {
//    public Texture2D Texture;
//    public int Id, Count;

//    public InventorySlot() {
//        Id = 0;
//        Count = 0;
//    }

//    public InventorySlot(int id, int count) {
//        Id = id;
//        Count = count;
//    }
//}

public /*class*/struct ShortAndByte {
    public short X;
    public byte Y;

    //public ShortAndByte() {
    //    X = 0;
    //    Y = 0;
    //}

    public ShortAndByte(int x, int y) {
        X=(short)x;
        Y=(byte)y;
    }

    public ShortAndByte(short x, byte y) {
        X = x;
        Y = y;
    }

//	public Vector2 Vector() => new Vector2(X, Y);
}

public struct UShortAndByte {
    public ushort X;
    public byte Y;

    //public UShortAndByte(int x, int y) {
    //    X=(short)x;
    //    Y=(byte)y;
    //}

    public UShortAndByte(ushort x, byte y) {
        X = x;
        Y = y;
    }

	//public Vector2 Vector() => new Vector2(X, Y);
}

public class DListInt {
    public List<DInt> List1, List2;

    //public DListInt () {
    //    List1=new List<DInt>();
    //    List2=new List<DInt>();
    //}

    //public DListInt (List<DInt> list1, List<DInt> list2) {
    //    List1=list1;
    //    List2=list2;
    //}

    //public DListInt (List<DInt> list1, DInt list2Item) {
    //    List1=list1;
    //    List2=new List<DInt> {
    //        list2Item
    //    };
    //}

    //public DListInt (DInt list1Item, List<DInt> list2) {
    //    List2=list2;
    //    List1=new List<DInt> {
    //        list1Item
    //    };
    //}

    //public DListInt (DInt list1Item, DInt list2Item) {
    //    List1=new List<DInt> {
    //        list1Item
    //    };

    //    List2=new List<DInt> {
    //        list2Item
    //    };
    //}

    //public DListInt (List<DInt> list) {
    //    List1=list;
    //    List2=list;
    //}

    //public DListInt (List<DInt> list1, DInt[] list2) {
    //    List1=list1;
    //    List2=list2.ToList();
    //}
}