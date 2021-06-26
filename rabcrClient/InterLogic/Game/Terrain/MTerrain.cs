using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace rabcrClient {
    public enum MChunkState:byte{
        NotDownloaded,
        SendRequest,
        Downloaded
    }

    public class MTerrain {
        public MChunkState state=MChunkState.NotDownloaded;
        public DateTime sended;

        public byte LightPos;
        public int LightPos16;
        public byte StartSomething;

        public Block[] Background=new Block[125];
        public Block[] SolidBlocks=new Block[125];
        public Block[] TopBlocks=new Block[125];

        public MBlockState[] IsBackground=new MBlockState[125];
        public MBlockState[] IsSolidBlocks=new MBlockState[125];
        public MBlockState[] IsTopBlocks=new MBlockState[125];



        public List<MMob> Mobs=new List<MMob>();
        public List<Plant> Plants=new List<Plant>();

        public Vector2 LightVec;//new Vector2(x*16-48+8, terrain[x].LightPos*16-48+8)
    }

    public enum MBlockState:byte{
        None,
        Exists,
        TmpRemoved,
    }

    class ChangeTerrain { 
        public DateTime sended;

        enum ChangeTerrainType{ 
            BasicRemove,
            BasicAdd,

            

        }
    }

    class SendedBlockToRemove:ChangeTerrain {
        public Mob animal;
        public DInt blockPos;
        public BlockType blockType;
        public List<DInt> items;
        public string World;
    }

    //class SendedBlockToRemove:ChangeTerrain {
    //    public Mob animal;
    //    public DInt blockPos;
    //    public BlockType blockType;
    //    public List<DInt> items;
    //    public string World;
    //}

    class SendedBlockToAdd:ChangeTerrain {
        public Mob animal;
        public DInt blockPos;
        public BlockType blockType;
        public List<DInt> items;
        public string World;
    }


}