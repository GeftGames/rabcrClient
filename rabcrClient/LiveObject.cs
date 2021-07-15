using System.Collections.Generic;

namespace rabcrClient {

    public abstract class LiveObject {  
        public UShortAndByte Root;
        public float angle;
    }

    public class Cactus : LiveObject{ 
        public List<UShortAndByte> Titles;

        public Cactus(int x, int y) { 
            Root=new UShortAndByte((ushort)x, (byte)y);
            Titles=new List<UShortAndByte>();
        }

        public void Add(int x, int y) => Titles.Add(new UShortAndByte((ushort)x, (byte)y));
    }

    public class Tree : LiveObject { 
        public List<UShortAndByte> TitlesLeaves, TitlesWood;

        public Tree(int x, int y) { 
            Root=new UShortAndByte((ushort)x, (byte)y);
            TitlesLeaves=new List<UShortAndByte>();
            TitlesWood=new List<UShortAndByte>();
        }

        public void AddLeave(int x, int y) => TitlesLeaves.Add(new UShortAndByte((ushort)x, (byte)y));

        public void AddWood(int x, int y) => TitlesLeaves.Add(new UShortAndByte((ushort)x, (byte)y));
    }
}