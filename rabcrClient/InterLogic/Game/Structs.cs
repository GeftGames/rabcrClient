using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

public class DInt : IEquatable<DInt>{

    public int X, Y;

    public DInt () { }

    public DInt (int x, int y) {
        X = x;
        Y = y;
    }

	public Vector2 ToVector() => new Vector2(X, Y);

    public DInt Clone() => (DInt)MemberwiseClone();

    public bool Equals(DInt other) => X==other.X && Y==other.Y;

    public void Deconstruct(out int x, out int y) {
        x = X;
        y = Y;
    }

    public static bool operator != (DInt value1, DInt value2) => value1.X != value2.X || value1.Y != value2.Y;
    public static bool operator == (DInt value1, DInt value2) => value1.X == value2.X && value1.Y == value2.Y;

}

public struct ShortAndByte {
    public short X;
    public byte Y;

    public ShortAndByte(int x, int y) {
        X=(short)x;
        Y=(byte)y;
    }

    public ShortAndByte(short x, byte y) {
        X = x;
        Y = y;
    }
}

public struct UShortAndByte {
    public ushort X;
    public byte Y;

    public UShortAndByte(ushort x, byte y) {
        X = x;
        Y = y;
    }
}