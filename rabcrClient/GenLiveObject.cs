using System.Collections.Generic;

namespace rabcrClient {

    public abstract class GenLiveObject { 
        public int IdNumber;

        public static int TotalCreated;
    }

    class GenCactus : GenLiveObject{ 
        public GenCactus(int x, int y) { 
            Root=new UShortAndByte((ushort)x, (byte)y);
            Titles=new List<UShortAndByte>();
            IdNumber=TotalCreated;
            TotalCreated++;
        }

        public UShortAndByte Root;

        public List<UShortAndByte> Titles;
        public void Add(int x, int y) { 
            Titles.Add(new UShortAndByte((ushort)x, (byte)y));
        }
    }

    public class GenTree : GenLiveObject { 

        public GenTree(int x, int y) { 
            Root=new UShortAndByte((ushort)x, (byte)y);
            TitlesLeaves=new List<UShortAndByte>();
            TitlesWood=new List<UShortAndByte>();
            IdNumber=TotalCreated;
            TotalCreated++;
        }

        public UShortAndByte Root;
        public List<UShortAndByte> TitlesLeaves;
        public List<UShortAndByte> TitlesWood;

        public void AddLeave(int x, int y) { 
            TitlesLeaves.Add(new UShortAndByte((ushort)x, (byte)y));
        }

        public void AddWood(int x, int y) { 
            TitlesWood.Add(new UShortAndByte((ushort)x, (byte)y));
        }
    }

    enum LiveObjectType : byte{ 
        Grass,
        Plant,
        Cactus,
        Tree,
    }
}