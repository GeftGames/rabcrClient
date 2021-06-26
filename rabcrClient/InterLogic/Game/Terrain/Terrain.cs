using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace rabcrClient {
    public class Terrain {
        public int 
            // Total (With half)
            LightPosFull,
            LightPosFull16,
            LightPosHalf,
            LightPosHalf16;
        public bool Half;

        public int /*LightPos, LightPos16, */StartSomething;

        public Block[]
            Background=new Block[125],
            SolidBlocks=new Block[125],
            TopBlocks=new Block[125];

        public bool[]
            IsBackground=new bool[125],
            IsSolidBlocks=new bool[125],
            IsTopBlocks=new bool[125];

        public List<Mob> Mobs=new List<Mob>();
        public List<Plant> Plants=new List<Plant>();

        public Vector2 LightVec;
    }
}