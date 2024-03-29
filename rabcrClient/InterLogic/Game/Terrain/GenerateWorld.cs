﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace rabcrClient {
    public class GenDataBasic {
        public ushort Id;

        public virtual void SaveTop(List<byte> list) { }
    }

    struct GenBiomeData{
        public ushort Start, End;
        public Biome Name;
    }

    struct BiomeData{
        public int Start, End;
        public Biome Name;
    }

    enum Biome :byte {
        None,
            SaltOcean,
          //  SugarOcean,

            HotPlains,
            //_polar,
            Arctic,
            //CoolTemperateDesertScrub,
            //ArticMountains,

            // _Subarctic,
            Tundra,
           // ArcticAlpineDesert,

            //_Mild,
            Bog,
           // Wetland,
           // TemperateFreshWaterSwampForest,
          //  Saltmarsh,
            Subtropics,
          //  Heath,

            //_Tropical,
            Desert,
            Savanna,
            Mangrove,

            //WarmTemperateDesert,

            TropicalRainforest,
            WetTundra,
            Taiga,
            Swamp,
            Plains,
            LeaveForest,
            Jungle,
            ColdTaiga,
            DryTundra,
            Fen,
            ArcticPlains,
            BothForest,
            Beach,
            SpruceForest,
            HumidSubtropical,
            ExtremeColdBeach,
            ColdBeach,
            HotBeach,

            Moon,
            Mars,
            SpaceStation,
        }

    public class GenDataWater: GenDataBasic{
        public override void SaveTop(List<byte> list) {
            list.Add(255);
        }
    }

    public class GenerateWorld {
     
        void SetLeave(GChunk chunk, int x, int y, ushort id, GenTree tree) {
            if (chunk.TopBlocks[y]==0) {
                chunk.TopBlocks[y]=id;
            //    byte by=(byte)y;
                tree.TitlesLeaves.Add(new UShortAndByte((ushort)x, (byte)y));
              //  tree.AddLeave(x, by);

                if (chunk.SetLightPosHalf) {
                    if (y<chunk.LightPosHalf) chunk.LightPosHalf=(byte)y;
                } else {
                    chunk.LightPosHalf=(byte)y;
                    chunk.SetLightPosHalf=true;
                }
            }
        }

        void SetWood(GChunk chunk, int x, int y, ushort id, GenTree tree){
            if (chunk.SolidBlocks[y]==0) {
                chunk.BackBlocks[y]=id;
//                chunk.T[y]==0;

               // tree.AddWood(x, y);
               tree.TitlesWood.Add(new UShortAndByte((ushort)x, (byte)y));
            }
        }

        readonly List<GenLiveObject> LiveObjects = new();
       
        enum HotBiome:byte{
            None,

            Ocean,

            Arctic,
            Subarctic,
            ColdTaiga,
            Taiga,
            SpruceForest,
            BothForest,
            LeaveForest,
            Subtropics,
            Bushes,
            Desert,
            Savanna,
            Tropical,
        }

        //struct BiomeData{
        //    public int Start, End;
        //    public Biome Name;
        //}

        enum WetBiome: byte{
            None,

            High,
            Medium,
            Low,
        }

        readonly List<GenBiomeData> BiomeDataList=new List<GenBiomeData>();
        enum ChangerBiome: byte{
            None,

            High,
            Medium,
            Low,
        }

        void GenerateBiome(WetBiome wet, HotBiome hot, ChangerBiome changer, bool IsOceanNear) {
            switch (hot) {

                case HotBiome.Ocean:
                    BiomeOcean();
                    BiomeOceanUp();
                    return;


                case HotBiome.Arctic:
                    switch (wet) {
                        case WetBiome.Low:
                            BiomeCoolTemperateDesertScrub();
                            return;

                        default:
                            BiomePoles(changer);
                            return;
                    }


                case HotBiome.Subarctic:
                    switch (wet) {
                        case WetBiome.Low:
                            BiomeDryTundra(/*changer*/);
                            return;

                        case WetBiome.High:
                            BiomeWetTundra();
                            return;

                        default:
                            BiomeTundra(/*changer*/);
                            return;
                    }


                case HotBiome.ColdTaiga:
                    switch (wet) {
                        case WetBiome.Low:
                            BiomePlains(/*changer,wet,hot*/);
                            return;

                        case WetBiome.High:
                            BiomeFen(/*changer,hot*/);
                            return;

                        default:
                            BiomeColdTaiga(/*changer*/);
                            return;
                    }


                case HotBiome.Taiga:
                    switch (wet) {
                        case WetBiome.Low:
                            BiomePlains(/*changer,wet,hot*/);
                            return;

                        case WetBiome.High:
                            BiomeFen(/*changer,hot*/);
                            return;

                        default:
                            BiomeTaiga(/*changer*/);
                            return;
                    }


                case HotBiome.SpruceForest:
                    switch (wet) {
                        case WetBiome.Low:
                            BiomePlains(/*changer,wet,hot*/);
                            return;

                        case WetBiome.High:
                            BiomeFen(/*changer,hot*/);
                            return;

                        default:
                            BiomeSpruceForest(/*changer*/);
                            return;
                    }


                case HotBiome.BothForest:
                    switch (wet) {
                        case WetBiome.Low:
                            BiomePlains(/*changer,wet,hot*/);
                            return;

                        case WetBiome.High:
                            BiomeSwamps(/*changer,hot*/);
                            return;

                        default:
                            BiomeBothForest(/*changer*/);
                            return;
                    }


                case HotBiome.LeaveForest:
                    switch (wet) {
                        case WetBiome.Low:
                            BiomePlains(/*changer,wet,hot*/);
                            return;

                        case WetBiome.High:
                            BiomeSwamps(/*changer,hot*/);
                            return;

                        default:
                            BiomeLeaveForest(/*changer*/);
                            return;
                    }


                case HotBiome.Subtropics:
                    switch (wet) {
                        case WetBiome.Low:
                            BiomeSubtropicsPlains(/*changer*/);
                            return;

                        case WetBiome.High:
                            BiomeHumidSubtropical(/*changer*/);
                            return;

                        default:
                            BiomeSubtropics(/*changer*/);
                            return;
                    }


                case HotBiome.Desert:
                    BiomeDesert(/*changer,wet*/);
                    return;


                case HotBiome.Savanna:
                    switch (wet) {
                        case WetBiome.Low:
                            BiomeSubtropicsPlains(/*changer*/);
                            return;

                        case WetBiome.High:
                            if (IsOceanNear){
                                BiomeMangrove();
                            } else {
                                BiomeSavana(/*changer,wet*/);
                            }
                            return;

                        default:
                            BiomeSavana(/*changer,wet*/);
                            return;
                    }


                case HotBiome.Tropical:
                    if (IsOceanNear){
                        BiomeMangrove();
                        return;
                    } else {
                        switch (wet) {
                            case WetBiome.Low:
                                BiomeJungle(/*changer,*/WetBiome.Low);
                                return;

                            case WetBiome.High:
                                BiomeJungle(/*changer,*/wet);
                                return;

                            default:
                                BiomeJungle(/*changer,*/wet);
                                return;
                        }
                    }

            }
        }

        List<BiomeExt> GeneratePartOfBiomes(){
            List<BiomeExt> Biomes=new List<BiomeExt>();

            int ocean=FastRandom.Int(12)+1;
          //  int ocean2=FastRandom.Int(12);

            for (int i = 1; i<13; i++) {
                if (i==ocean) {
                    Biomes.Add(new BiomeExt(){ Temterature=HotBiome.Ocean });
                } else {
                    switch (FastRandom.Int3()){
                        case 2:
                            Biomes.Add(new BiomeExt(){
                                Temterature=(HotBiome)(i+2),
                                Changer=ChangerBiome.Medium,
                            });
                            break;

                        case 1:
                            Biomes.Add(new BiomeExt(){
                                Temterature=(HotBiome)(i+2),
                                Changer=ChangerBiome.Low,
                            });
                            break;

                        case 0:
                            Biomes.Add(new BiomeExt(){
                                Temterature=(HotBiome)(i+2),
                                Changer=ChangerBiome.High,
                            });
                            break;
                    }
                }
            }

            return Biomes;
        }

        int lastLakePos=-1000;

        #region Varibles
        List<GChunk> terrain=new List<GChunk>();
        List<byte> biomes;  int world=0;
        public enum WorldSize : byte{
            Small,
            Medium,
            Big
        }

        readonly WorldSize currentWorldSize;
        bool seabedSand;
        int seabedChange=10;
        byte terrainHeight=50;
        int terrainChange=2;
        int pos=0;
        int generatePos;

        int dirtChange=2;
     //   readonly int type;

        int height12 =85;//sedimentary/meta
        int height23=100;//meta/gabro
        int height34=115;//gabro->(ushort)BlockId.Lava

        int height12Change=2;//sedimentary/meta
        int height23Change=1;//meta/gabro
        int height34Change=3;//gabro->(ushort)BlockId.Lava

        int level1Type=0;
        int level2Type=0;
        int level3Type=0;

        int level1TypeLast=0;
        int level2TypeLast=0;
        int level3TypeLast=0;

        int level1Lenght=0;
        int level2Lenght=0;
        int level3Lenght=0;

        int level1Crossing=0;
        int level2Crossing=0;
        int level3Crossing=0;

		byte dirtHeight = 4;

		bool grass=true;
		bool hill=true;
		int treeChange=/*9*/2;

		//FastRandom FastRandom;

        int biomeSize;
        readonly string playedWorld;
		public bool Finish=false;
		public bool NotStarted=true;
		#endregion

        Thread thread;

		public float Process => world/(3*2f);

        ushort plantPrefer;
        int plantSeek;
       // readonly FastRandom FastRandom;

        public GenerateWorld(string dir, WorldSize ws) {
            playedWorld=dir;
         //   FastRandom=Rabcr.FastRandom;
           // _boolBits=(uint)/*~*/FastRandom.Int();
            // type=ntype;
            currentWorldSize=ws;
        }

        void AddCactus(int x, int y, int height, ushort id) {


            GChunk chunk = terrain[x];

            GenCactus cactus = new(x, y);
            LiveObjects.Add(cactus);

            int to=y-height;

            for (; y>to; y--) {
                if (chunk.TopBlocks[y]!=0) break;
                chunk.TopBlocks[y]=id;
                cactus.Add(x, y);
            }
        }

        public void Action() {
			NotStarted=false;
            thread = new Thread(Generate) {
                IsBackground=true,
                Priority=ThreadPriority.AboveNormal,
                Name="rabcrGeneratingWorld"
            };
            thread.Start();
		}

        public void Stop() {
            if (thread!=null) thread.Abort();
        }

        void Generate() {
            #if DEBUG
            Stopwatch sw=new Stopwatch();
            sw.Start();
            #endif
            GenerateMoon();

            GenerateMars();

           // if (type==0)
                GenerateEarth();
           // else if (type==1) GenerateFlat();
           // else GenerateEmpty();

            Finish=true;

            #if DEBUG
            sw.Stop();
            Debug.WriteLine("Vygenerováno za "+sw.ElapsedMilliseconds+"ms");
            #endif
		}

        void GenerateEarth() {
            if (!Directory.Exists(playedWorld+@"\Earth")) Directory.CreateDirectory(playedWorld+@"\Earth");
            generatePos=0;
            pos=0;

            terrain=new List<GChunk> {
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk()
            };

            List<BiomeExt> Biomes=GeneratePartOfBiomes();
            {
                List<BiomeExt> Biomes2=GeneratePartOfBiomes();
                Biomes2.Reverse();
                Biomes.AddRange(Biomes2);
            }
            Biomes.AddRange(GeneratePartOfBiomes());
            {
                List<BiomeExt> Biomes2=GeneratePartOfBiomes();
                Biomes2.Reverse();
                Biomes.AddRange(Biomes2);
            }


            int lastOcean=-10000;
            for (int i = 0; i<Biomes.Count; i++) {
                if (Biomes[i].Temterature==HotBiome.Ocean) {
                    lastOcean=i;
                } else {
                    Biomes[i].oceanIndex=i-lastOcean;
                }
            }

            lastOcean=10000;
            for (int i = Biomes.Count-1; i>=0; i--) {
                if (Biomes[i].Temterature==HotBiome.Ocean) lastOcean=i;

                if (Biomes[i].oceanIndex>lastOcean-i) { Biomes[i].oceanIndex=lastOcean-i; }

                if (Biomes[i].oceanIndex<=2)Biomes[i].Humidity=WetBiome.High;
                else if (Biomes[i].oceanIndex<=4)Biomes[i].Humidity=WetBiome.Medium;
                else Biomes[i].Humidity=WetBiome.Low;
            }

            foreach (BiomeExt biome in Biomes) {
                GenerateBiome(biome.Humidity,biome.Temterature,biome.Changer,biome.oceanIndex==1);
            }

            for (int i=100; i<terrain.Count-100; i+=40+FastRandom.Int(20+20)) {
                CaveGenerator(i, FastRandom.Int(terrain[i].LightPosFull+5+2, 80));
            }

            for (int x=0; x<terrain.Count; x++) {
                GChunk chunk=terrain[x];
                int nLp=0;
             //   if (chunk.LightPosFull < 124) {
                 //   if (chunk.SolidBlocks[chunk.LightPosFull-1]==0) {
                       // int y=chunk.LightPosFull-1;
                        for (; nLp<125; nLp++) { 
                            if (chunk.SolidBlocks[nLp]!=0) {
                                chunk.LightPosFull=(byte)nLp;
                                break;
                            }
                        } 
                 //   }
              //  }
            }

            Save("Earth");


            {
                List<byte> bytes = new() {
                    (byte)BiomeDataList.Count
                };

                foreach (GenBiomeData b in BiomeDataList) {
                    bytes.Add((byte)(int)b.Name);
                    bytes.Add((byte)b.Start);
                    bytes.Add((byte)(b.Start>>8));
                    bytes.Add((byte)b.End);
                    bytes.Add((byte)(b.End>>8));
                }
                File.WriteAllBytes(playedWorld+"\\"+"Earth"+"Biomes.ter", bytes.ToArray());
            }
		}

        void GenerateMoon() {

      pos=0;
            generatePos=0;

            //   biomes.Clear();
            biomes=new List<byte> {
                (byte)(/*FastRandom.Int2()*/FastRandom.Int2()-1),
                (byte)(/*FastRandom.Int2()*/FastRandom.Int2()-1),
                0,
                (byte)(/*FastRandom.Int2()*/FastRandom.Int2()-1),

                (byte)(/*FastRandom.Int2()*/FastRandom.Int2()-1),
                1,
                (byte)(/*FastRandom.Int2()*/FastRandom.Int2()-1),
                (byte)(/*FastRandom.Int2()*/FastRandom.Int2()-1)
            };


            terrain=new List<GChunk> {
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk()
            };


            biomeSize= (int)(GetWorldSize()*0.0204545454545455f);

            // generate
            foreach (byte biome in biomes) {
               if (biome==0) {
                   BiomeLightMoonBiome();
                }else{
                     BiomeDarkMoonBiome();
                }
            }

            Save("Moon");
		}

        void GenerateMars() {

            pos=0;
            generatePos=0;

            biomes=new List<byte> {
                0,
                FastRandom.Byte3(),
                1,
                FastRandom.Byte3(),
                3,
                FastRandom.Byte3(),
                0,
                0,
                FastRandom.Byte3(),
                1,
                FastRandom.Byte3(),
                2,
                FastRandom.Byte3(),
                0,
            };


            terrain=new List<GChunk> {
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk(),
                new GChunk()
            };


            biomeSize= (int)(GetWorldSize()*0.0204545454545455f);

            // generate
            foreach (byte biome in biomes) {
               switch (biome) {
                    case 0:
                        BiomeMarsPoles();
                        break;

                    case 1:
                        BiomeMarsNormalRed();
                        break;

                    case 2:
                        BiomeMarsNormalYellow();
                        break;

                    case 3:
                        BiomeMarsNormalWhite();
                        break;
                }
            }

            Save("Mars");
		}

        #region Earth biomes
        void BiomeOcean() {
             for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk=terrain[pos];

                // Terrain height
                 if (terrainChange<0) {
                    if (terrainHeight>52+5+2) terrainHeight--;
                    else if (terrainHeight<49+6+2) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=4+FastRandom.Int5();
                } else terrainChange--;

                if (seabedChange<0) {
                    seabedSand=!seabedSand;
                    seabedChange=10+FastRandom.Int(20);
                } else seabedChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }

                // Water
                for (int yy=53; yy<terrainHeight; yy++) {
					chunk.TopBlocks[yy]=(ushort)BlockId.WaterSalt;
                    if (FastRandom.Bool_5Percent()){
                        chunk.AddFish((byte)yy);
                    }
				}

                // Corals or Seaweed
                if (terrainHeight>54){
                    if (FastRandom.Bool()) {
                        if (FastRandom.Bool()) chunk.BackBlocks[terrainHeight-1]=(ushort)BlockId.Seaweed;
                        else chunk.BackBlocks[terrainHeight-1]=(ushort)BlockId.Coral;
                    }
                }

                // Seabed
                if (seabedSand) chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Sand;
                else chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Gravel;

                // Lithosphere
                GenerateUnderSurface(chunk,terrainHeight+1);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.SaltOcean, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeOceanUp() {
            int start=pos;
            for (; terrainHeight>53; pos++) {
                terrain.Add(new GChunk());
                 GChunk chunk=terrain[pos];
                 generatePos++;

                // Terrain height
                if (terrainChange<0) {
                    terrainHeight--;
                    terrainChange=3+FastRandom.Int3();
                } else terrainChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }

                // Water
                for (int yy=53; yy<terrainHeight; yy++) {
					chunk.TopBlocks[yy]=(ushort)BlockId.WaterSalt;
                    if (FastRandom.Bool_5Percent()){
                        chunk.AddFish((byte)yy);
                    }
				}

                // Corals or Seaweed
                if (FastRandom.Bool()) {
                    if (terrainHeight<53){
                        if (FastRandom.Bool()) chunk.BackBlocks[terrainHeight-1]=(ushort)BlockId.Seaweed;
                        else chunk.BackBlocks[terrainHeight-1]=(ushort)BlockId.Coral;
                    }
                }

                // Seabed
                if (seabedSand) chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Sand;
                else chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Gravel;

                if (seabedChange<0) {
                    seabedSand=!seabedSand;
                    seabedChange=10+FastRandom.Int(20);
                } else seabedChange--;

                // Lithosphere
                GenerateUnderSurface(chunk,terrainHeight+1);
            }

             BiomeDataList.Add(new GenBiomeData{ Name=Biome.SaltOcean, Start=(ushort)start, End=(ushort)generatePos});
        }

    //    void BiomeBeachDown() {
    //        int start=pos;
    //         for (; terrainHeight/*+2*/<53; pos++ ) {
    //            terrain.Add(new GChunk());
    //            GChunk chunk=terrain[pos];
    //            generatePos++;

    //            // Terrain height
    //            if (terrainChange<0) {
    //                 terrainHeight++;
    //                 terrainChange=1+FastRandom.Int3();
    //            } else terrainChange--;

    //            // Height (ushort)BlockId.Dirt
    //            if (dirtChange<0) {
    //                if (dirtHeight>3) dirtHeight--;
    //                else if (dirtHeight<2) dirtHeight++;
    //                else {
    //                    if (FastRandom.Bool()) dirtHeight++;
    //                    else dirtHeight--;
    //                }
    //                dirtChange=1+FastRandom.Int3();
    //            } else dirtChange--;

    //            chunk.LightPos=terrainHeight;

    //            // Sand
    //            if (seabedSand) {
    //                for (int yy=terrainHeight; yy<terrainHeight+dirtHeight; yy++) chunk.SolidBlocks[yy]=(ushort)BlockId.Sand;
    //            } else {
    //                for (int yy=terrainHeight; yy<terrainHeight+dirtHeight; yy++) chunk.SolidBlocks[yy]=(ushort)BlockId.Gravel;
    //             }

    //            if (FastRandom.Bool()) {
    //                switch (FastRandom.Int(9)) {
    //                    case 2:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
    //                        break;

    //                    case 3:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle1;
    //                        break;

    //                    case 4:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle2;
    //                        break;

    //                    case 5:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchWithout;
    //                        break;

    //                    case 6:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
    //                        break;

    //                    case 7:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
    //                        break;

    //                    case 8:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
    //                        break;
    //                }
    //            }

    //            GenerateUnderSurface(chunk,dirtHeight+terrainHeight);
    //        }
    //        BiomeDataList.Add(new BiomeData{ Name=Biome.Beach, Start=start, End=generatePos});
    //    }

    //    void BiomeBeachUp() {
    //       for (; terrainHeight>51; pos++) {
    //            terrain.Add(new GChunk());
    //            GChunk chunk=terrain[pos];
    //            generatePos++;

    //            // Terrain height
    //            if (terrainChange<0) {
    //                 terrainHeight--;

    //                 terrainChange=1+FastRandom.Int3();
    //            } else terrainChange--;

    //            // Sand height
    //            if (dirtChange<0) {
    //                if (dirtHeight>3) dirtHeight--;
    //                else if (dirtHeight<2) dirtHeight++;
    //                else {
    //                    if (FastRandom.Bool()) dirtHeight++;
    //                    else dirtHeight--;
    //                }
    //                dirtChange=1+FastRandom.Int3();
    //            } else dirtChange--;

    //            chunk.LightPos=terrainHeight;

    //            // Sand
    //            if (seabedSand) {
    //                for (int yy=terrainHeight; yy<terrainHeight+dirtHeight; yy++) chunk.SolidBlocks[yy]=(ushort)BlockId.Sand;
				//} else {
    //                for (int yy=terrainHeight; yy<terrainHeight+dirtHeight; yy++) chunk.SolidBlocks[yy]=(ushort)BlockId.Gravel;
    //            }

    //            if (FastRandom.Bool()) {
    //                switch (FastRandom.Int(9)) {
    //                    case 2:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
    //                        break;

    //                    case 3:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle1;
    //                        break;

    //                    case 4:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle2;
    //                        break;

    //                    case 5:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchWithout;
    //                        break;

    //                    case 6:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
    //                        break;

    //                    case 7:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
    //                        break;

    //                    case 8:
    //                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
    //                        break;
    //                }
    //            }

    //            // Lithosphere
    //            GenerateUnderSurface(chunk,dirtHeight+terrainHeight);
    //        }
    //        BiomeDataList.Add(new BiomeData{ Name=Biome.Beach, Start=generatePos, End=generatePos+biomeSize});
    //    }

        void BiomePoles(ChangerBiome changer) {
            for (; pos<generatePos+biomeSize; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk =terrain[pos];

                // Terrain height
                 if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }
                    if (changer==ChangerBiome.Low) terrainChange=2+FastRandom.Int3();
                    else if (changer==ChangerBiome.Medium) terrainChange=2+FastRandom.Int2();
                    else terrainChange=1+FastRandom.Int2();
                } else terrainChange--;

                // Height (ushort)BlockId.Dirt
                 if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Snow;

                if (FastRandom.Bool_33_333Percent()) chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.SnowTop;

                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Ice;

                GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.Arctic, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeCoolTemperateDesertScrub(/*ChangerBiome changer*/) {
            for (; pos<generatePos+biomeSize; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk =terrain[pos];

                // Terrain height
                 if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                // Height (ushort)BlockId.Dirt
                 if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }

                if (FastRandom.Bool_33_333Percent()) chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                else if (FastRandom.Bool_10Percent())chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.SnowTop;

                if (seabedChange<0) {
                    grass=!grass;
                    seabedChange=10+FastRandom.Int(20);
                } else seabedChange--;

                if (grass) {
                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Snow;
                    GenerateUnderSurface(chunk,terrainHeight+1);
                } else GenerateUnderSurface(chunk,terrainHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.ArcticPlains, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeTundra(/*ChangerBiome changer*/) {
             for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Int(80)==1) Lake((ushort)BlockId.Ice);
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>52) terrainHeight--;
                    else if (terrainHeight<49) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }
                    terrainChange=4+FastRandom.Int5();
                } else terrainChange--;

                // Height Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (FastRandom.Bool()) {
                    if (FastRandom.Bool_5Percent()){
                        chunk.AddRabbit((byte)(terrainHeight-1));
                    }
                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockHills;
                    if (FastRandom.Bool_20Percent()) {
                        if (FastRandom.Bool()) chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Heather;
                        else chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                    }
                } else {
                    if (FastRandom.Bool()) chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Ice;
                    else chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Snow;

                    if (FastRandom.Bool_33_333Percent()) chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.SnowTop;
                }

                for (int b=terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Ice;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[dirtHeight+terrainHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
             }
             BiomeDataList.Add(new GenBiomeData{ Name=Biome.Tundra, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
             generatePos+=biomeSize;
        }

        void BiomeDryTundra(/*ChangerBiome changer*/) {
            for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Int(120)==1) Lake((ushort)BlockId.Ice);
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>52) terrainHeight--;
                    else if (terrainHeight<47) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }
                    terrainChange=4+FastRandom.Int5();
                } else terrainChange--;

                // Height Dirt
                if (dirtChange<0) {
                    if (dirtHeight>2) dirtHeight--;
                    else if (dirtHeight<1) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (FastRandom.Bool_20Percent()){
                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockHills;
                    if (FastRandom.Bool_12_5Percent()) {
                        if (FastRandom.Bool()) chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                        else chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                    }

                } else chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Cobblestone;

                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[1/*dirtHeight*/+terrainHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+1);
             }
             BiomeDataList.Add(new GenBiomeData{ Name=Biome./*Dry*/Tundra, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
             generatePos+=biomeSize;
        }

        void BiomeWetTundra() {
             for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Int(40)==1) Lake((ushort)BlockId.Ice);
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>52) terrainHeight--;
                    else if (terrainHeight<50) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }
                    terrainChange=4+FastRandom.Int5();
                } else terrainChange--;

                // Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (FastRandom.Bool()) {
                    if (FastRandom.Bool_5Percent()) chunk.AddRabbit((byte)(terrainHeight-1));

                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockHills;
                    if (FastRandom.Bool_20Percent()) {
                        if (FastRandom.Bool()) chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Heather;
                        else chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                    }
                } else {
                    if (FastRandom.Bool()) chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Ice;
                    else chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Snow;

                    if (FastRandom.Bool_33_333Percent()) chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.SnowTop;
                }

                for (int b=terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Ice;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[dirtHeight+terrainHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
             }
             BiomeDataList.Add(new GenBiomeData{ Name=Biome./*Wet*/Tundra, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
             generatePos+=biomeSize;
        }

        void BiomeColdTaiga() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                if (FastRandom.Int(45)==1)Lake((ushort)BlockId.Gravel);

                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>52) terrainHeight--;
                    else if (terrainHeight<49) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=4+FastRandom.Int5();
                } else terrainChange--;

                // Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (FastRandom.Bool_1Percent())chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Cobblestone;
                else if (FastRandom.Bool_1Percent())chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Gravel;
                else chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockHills;

                if (FastRandom.Bool()) {
                    if (FastRandom.Bool_2Percent()) ClayPlace(pos-5, terrainHeight-1);

                    // Add animals
                    if (FastRandom.Int(15)==1) chunk.AddRabbit((byte)(terrainHeight-1));

                    bool placed=false;
                    if (plantSeek!=0){
                        if (plantPrefer!=0){
                        if (FastRandom.Bool()){
                            chunk.AddPlant(plantPrefer,(byte)(terrainHeight-1));
                            placed=true;
                        }
                    }

                    } plantSeek--;
                    if (!placed){
                        switch (FastRandom.Int(10)) {
                            case 1:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Heather;
                                break;

                            case 2:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                                break;

                            case 3:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                                break;

                            case 4:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchWithout;
                                break;

                            case 5:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                                break;

                            case 6:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.SnowTop;
                                break;

                            case 7:
                                if (FastRandom.Bool()){
                                    if (plantSeek<-20){
                                        plantPrefer=(ushort)BlockId.Blueberry;
                                        plantSeek=3+FastRandom.Int(10);
                                    }
                                }
                                break;

                            case 9: chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                                break;

                            case 10: chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                                break;
                        }
                    }
                }

                if (treeChange<0) {
                    if (FastRandom.Bool_20Percent()) TreeSpruceLittle(pos, terrainHeight);
                } else treeChange--;

                //Add dirt
                for (int b=terrainHeight+1; b<dirtHeight+terrainHeight; b++) {
                    if (FastRandom.Bool_1Percent())chunk.SolidBlocks[b]=(ushort)BlockId.Cobblestone;
                    else if (FastRandom.Bool_1Percent())chunk.SolidBlocks[b]=(ushort)BlockId.Gravel;
                    else chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[dirtHeight+terrainHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, dirtHeight+1+terrainHeight);
                } else GenerateUnderSurface(chunk, dirtHeight+terrainHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.ColdTaiga, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeTaiga(/*ChangerBiome changer*/) {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                if (FastRandom.Bool_2Percent())Lake((ushort)BlockId.Gravel);
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>52) terrainHeight--;
                    else if (terrainHeight<49) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=4+FastRandom.Int5();
                } else terrainChange--;

                // Height (ushort)BlockId.Dirt
                   if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (FastRandom.Bool_1Percent())chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Cobblestone;
                else if (FastRandom.Bool_1Percent())chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.Gravel;
                else chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockHills;

                if (FastRandom.Bool()) {
                    if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);

                    if (FastRandom.Int(15)==1){
                        chunk.AddRabbit((byte)(terrainHeight-1));
                    }
                    bool placed=false;
                    if (plantSeek!=0){
                        if (plantPrefer!=0){
                            if (FastRandom.Bool()){
                                chunk.AddPlant(plantPrefer,(byte)(terrainHeight-1));
                                placed=true;
                            }
                        }
                    }
                    plantSeek--;
                    if (!placed){
                        switch (FastRandom.Int(10)) {
                            case 1: chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Heather;
                            break;

                            case 2: chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                            case 3: chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                            case 4: chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
                            break;

                            case 5: chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                            case 6: chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                            case 7:
                                if (FastRandom.Bool()){
                                    if (plantSeek<-15){
                                        plantPrefer=(ushort)BlockId.Blueberry;
                                        plantSeek=3+FastRandom.Int(10);
                                    }
                                }
                            break;

                            case 9: chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                                 case 10: chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;
                        }
                    }
                }

                if (treeChange<0) {
                    if (FastRandom.Bool_20Percent()) TreeSpruceLittle(pos,terrainHeight);
                    else TreeSpruceBig(pos, terrainHeight);
                }else treeChange--;

                for (int b=terrainHeight+1; b<dirtHeight+terrainHeight; b++) {
                    if (FastRandom.Bool_1Percent())chunk.SolidBlocks[b]=(ushort)BlockId.Cobblestone;
                    else if (FastRandom.Bool_1Percent())chunk.SolidBlocks[b]=(ushort)BlockId.Gravel;
                    else chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[dirtHeight+terrainHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, dirtHeight+1+terrainHeight);
                } else GenerateUnderSurface(chunk, dirtHeight+terrainHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.Taiga, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeSpruceForest(/*ChangerBiome changer*/) {
             for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Bool_1Percent())LakeGravel(/*BlockId.*/);
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                //Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockForest;

                if (FastRandom.Bool()) {

                    if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);
                    if (FastRandom.Int(14)==1){
                        chunk.AddRabbit((byte)(terrainHeight-1));
                    }

                    switch (FastRandom.Int(9)) {
                        case 1:
                            if (FastRandom.Bool()) {
                                if (FastRandom.Bool()){
                                    chunk.AddPlant((ushort)BlockId.Blueberry,(byte)(terrainHeight-1));
                                } else {
                                    chunk.AddPlant((ushort)BlockId.Rashberry,(byte)(terrainHeight-1));
                                }
                            }
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Dandelion;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle2;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;

                        case 8:
                            if (FastRandom.Bool_20Percent()) {
                                if (FastRandom.Bool()) chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Toadstool;
                                else chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Boletus;
                            }
                            break;
                    }
                }

                if (treeChange<0) {
                    switch (FastRandom.Int3()) {
                        case 1:
                            TreeSpruceLittle(pos, terrainHeight);
                            break;

                        case 2:
                            TreeSpruceBig(pos, terrainHeight);
                            break;
                    }
                } else treeChange--;

                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.SpruceForest, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeBothForest(/*ChangerBiome changer*/) {
            for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Bool_1Percent()) LakeGravel(/*BlockId.Gravel*/);
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                //Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockForest;

                if (FastRandom.Bool()) {
                    if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);

                    if (FastRandom.Int(13)==1){
                       chunk.AddRabbit((byte)(terrainHeight-1));
                    }

                    switch (FastRandom.Int(7)) {
                        case 0:
                            switch (FastRandom.Int4()){
                                case 0:
                                    chunk.AddPlant((ushort)BlockId.Rashberry,(byte)(terrainHeight-1));
                                    break;

                                case 1:
                                    chunk.AddPlant((ushort)BlockId.Strawberry,(byte)(terrainHeight-1));
                                    break;

                                case 2:
                                    chunk.AddPlant((ushort)BlockId.Blueberry,(byte)(terrainHeight-1));
                                    break;

                                case 3:
                                    chunk.AddPlant((ushort)BlockId.Flax,(byte)(terrainHeight-1));
                                    break;
                            }

                            break;

                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;

                        case 6:
                            switch (FastRandom.Int4()) {
                                case 1:chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Boletus;
                                break;
                                case 2:chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Toadstool;
                                break;
                                case 3:chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Champignon;
                                break;
                            }
                            break;
                    }
                }

                if (treeChange<0) {
                    switch (FastRandom.Int(9)) {
                        case 1:
                            TreeSpruceLittle(pos, terrainHeight);
                            break;
                        case 2:
                            TreeOakLittle(pos, terrainHeight);
                            break;
                        case 3:
                            TreeSpruceBig(pos, terrainHeight);
                            break;
                        case 4:
                            TreeOakMedium(pos, terrainHeight);
                            break;
                        case 5:
                            TreeOakMedium(pos, terrainHeight);
                            break;
                        case 6:
                            TreeSpruceBig(pos, terrainHeight);
                            break;
                        case 7:
                            TreeLinden(pos, terrainHeight);
                            break;
                        case 8:
                            TreeApple(pos, terrainHeight);
                            break;
                    }
                } else treeChange--;

                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.BothForest, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeFen(/*ChangerBiome changer,HotBiome hot*/) {
            for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Int(40)==1)LakeDirt(/*BlockId.*/);
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                //Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);

                switch (FastRandom.Int(7)) {
                    case 0:
                        switch (FastRandom.Int4()){
                            case 0:
                                chunk.AddPlant((ushort)BlockId.Rashberry,(byte)(terrainHeight-1));
                                break;

                            case 1:
                                chunk.AddPlant((ushort)BlockId.Strawberry,(byte)(terrainHeight-1));
                                break;

                            case 2:
                                chunk.AddPlant((ushort)BlockId.Blueberry,(byte)(terrainHeight-1));
                                break;

                            case 3:
                                chunk.AddPlantFlax(/*(ushort)BlockId.,*/(byte)(terrainHeight-1));
                                break;
                        }

                        break;

                    case 1:
                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                        break;

                    case 2:
                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassPlains;
                        break;

                    case 3:
                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassPlains;
                        break;

                    case 4:
                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                        break;

                    case 5:
                        chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassPlains;
                        break;

                    case 9:chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassPlains;

                        break;

                }

                if (treeChange<0) {
                    switch (FastRandom.Int(9)) {
                        case 1:
                            TreeSpruceLittle(pos, terrainHeight);
                            break;
                        case 2:
                            TreeWillow(pos, terrainHeight);
                            break;
                        case 3:
                            TreeSpruceBig(pos, terrainHeight);
                            break;
                        case 4:
                            TreeOakMedium(pos, terrainHeight);
                            break;
                        case 5:
                            TreeWillow(pos, terrainHeight);
                            break;
                        case 6:
                            TreeSpruceBig(pos, terrainHeight);
                            break;
                        case 7:
                            TreeWillow(pos, terrainHeight);
                            break;
                        case 8:
                            TreeApple(pos, terrainHeight);
                            break;
                    }
                } else treeChange--;


                if (seabedChange<0) {
                    if (grass) seabedChange=10+FastRandom.Int(20);
                    else seabedChange=3+FastRandom.Int5();
                    grass=!grass;
                } else seabedChange--;

                if (grass) {
                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockForest;
                    for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;
                } else {
                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockCompost;
                    for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) {
                        chunk.SolidBlocks[b]=FastRandom.Bool_33_333Percent() ? (ushort)BlockId.Dirt : (ushort)BlockId.Compost;
                    }
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.Fen, Start=(ushort)(generatePos), End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeSwamps(/*ChangerBiome changer, HotBiome hot*/) {
            for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Int(60)==1)LakeGravel(/*BlockId.*/);
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-3) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                //Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockForest;

                if (FastRandom.Bool()) {
                    if (FastRandom.Int(13)==1) {
                        chunk.AddRabbit((byte)(terrainHeight-1));
                    }

                    switch (FastRandom.Int(7)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;

                        case 6:
                            switch (FastRandom.Int4()) {
                                case 1:chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Boletus;
                                break;
                                case 2:chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Toadstool;
                                break;
                                case 3:chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Champignon;
                                break;
                            }
                            break;
                    }
                }

                if (treeChange<0) {
                    switch (FastRandom.Int(9)) {
                        case 1:
                            TreeSpruceLittle(pos, terrainHeight);
                            break;
                        case 2:
                            TreeOakLittle(pos, terrainHeight);
                            break;
                        case 3:
                            TreeSpruceBig(pos, terrainHeight);
                            break;
                        case 4:
                            TreeOakMedium(pos, terrainHeight);
                            break;
                        case 5:
                            TreeOakMedium(pos, terrainHeight);
                            break;
                        case 6:
                            TreeSpruceBig(pos, terrainHeight);
                            break;
                        case 7:
                            TreeLinden(pos, terrainHeight);
                            break;
                        case 8:
                            TreeApple(pos, terrainHeight);
                            break;
                    }
                } else treeChange--;

                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.Swamp, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeLeaveForest(/*ChangerBiome changer*/) {
             for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Int(80)==1)LakeGravel(/*BlockId.*/);
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                //Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }

                chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockForest;

                if (FastRandom.Bool()) {
                    if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);

                    if (FastRandom.Int(13)==1) {
                         chunk.AddRabbit((byte)(terrainHeight-1));
                    }

                    switch (FastRandom.Int(13)) {
                        case 1:
                            chunk.AddPlant((ushort)BlockId.Rashberry,(byte)(terrainHeight-1));
                            break;

                        case 2:
                            chunk.AddPlant((ushort)BlockId.Strawberry,(byte)(terrainHeight-1));
                            break;

                        case 3:
                            chunk.AddPlantFlax((byte)(terrainHeight-1));
                            break;

                        case 4:
                            if (FastRandom.Bool()) chunk.AddPlantCarrot((byte)(terrainHeight-1));
                            break;

                        case 5:
                            chunk.AddPlant((ushort)BlockId.Blueberry,(byte)(terrainHeight-1));
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle2;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 9:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 10:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 11:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 12:
                            switch (FastRandom.Int4()) {
                                case 1:chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Boletus;
                                break;
                                case 2:chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Toadstool;
                                break;
                                case 3:chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Champignon;
                                break;
                            }
                            break;
                    }
                }

                if (treeChange<0) {
                    switch (FastRandom.Int(9)) {
                        case 1:
                            TreePlum(pos, terrainHeight);
                            break;
                        case 2:
                            TreeOakLittle(pos, terrainHeight);
                            break;
                        case 3:
                            TreeCherry(pos, terrainHeight);
                            break;
                        case 4:
                            TreeOakMedium(pos, terrainHeight);
                            break;
                        case 5:
                            TreeOakMedium(pos, terrainHeight);
                            break;
                        case 6:
                            TreeSpruceBig(pos, terrainHeight);
                            break;
                        case 7:
                            TreeLinden(pos, terrainHeight);
                            break;
                        case 8:
                            TreeApple(pos, terrainHeight);
                            break;


                    }
                } else treeChange--;

                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.LeaveForest, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomePlains(/*ChangerBiome changer, WetBiome wet, HotBiome hot*/) {
            for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Bool_1Percent())LakeDirt(/*BlockId.*/);
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }

                // Add grass
                chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockPlains;

                if (FastRandom.Bool()) {
                    if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);

                    // Animals
                    if (FastRandom.Int(13)==1) chunk.AddRabbit((byte)(terrainHeight-1));
                    else if (FastRandom.Int(15)==1)  chunk.AddChicken((byte)(terrainHeight-1));

                    // Add something on grass
                    switch (FastRandom.Int(10)) {
                        case 1:
                            if (FastRandom.Bool()) chunk.AddPlant((ushort)BlockId.Onion,(byte)(terrainHeight-1));
                            else chunk.AddPlantCarrot((byte)(terrainHeight-1));
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassPlains;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Dandelion;
                            break;

                        //case 4:
                        //    chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
                        //    break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassPlains;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassPlains;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Violet;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;

                        case 9:
                            if (FastRandom.Bool()) chunk.AddPlantFlax((byte)(terrainHeight-1));
                            break;
                    }
                }

                // Add dirt
                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.Plains, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeSubtropicsPlains(/*ChangerBiome changer*/) {

            for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Bool_1Percent())LakeDirt();
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                // Height Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockDesert;

                if (FastRandom.Bool_1Percent()) ClayPlace(pos-5,terrainHeight-1);

                // Add something on grass
                if (FastRandom.Bool()) {
                    double z=FastRandom.Double();
                    if (z<0.5) chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassDesert;
                    else {
                        if (z<0.66)chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
                        else if (z<0.88)chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Dandelion;
                        else chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                    }
                }

                // Add dirt
                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }

            BiomeDataList.Add(new GenBiomeData{ Name=Biome.HotPlains, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize) });
            generatePos+=biomeSize;
        }

        void BiomeSubtropics(/*ChangerBiome changer*/) {
            for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Bool_1Percent()) LakeSand();
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                //Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                // Sub
                if (seabedChange<0) {
                    grass=!grass;
                    seabedChange=5+FastRandom.Int(10);
                } else seabedChange--;

                chunk.LightPosFull=terrainHeight;
               if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (grass) {
                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockDesert;
                    if (FastRandom.Bool()) {
                        // Add animals
                        if (FastRandom.Int(15)==1) chunk.AddRabbit((byte)(terrainHeight-1));
                        else if (FastRandom.Bool_10Percent()) chunk.AddChicken((byte)(terrainHeight-1));

                        switch (FastRandom.Int(10)) {
                            case 1:
                                chunk.AddPlantWheat((byte)(terrainHeight-1));
                                break;

                            case 2:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassDesert;
                                break;

                            case 3:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Dandelion;
                                break;

                            case 4:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle1;
                                break;

                            case 5:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                                break;

                            case 6:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassDesert;
                                break;

                            case 7:
                                if (FastRandom.Bool()) chunk.AddPlant((ushort)BlockId.Onion,(byte)(terrainHeight-1));
                                else chunk.AddPlantCarrot((byte)(terrainHeight-1));
                                break;

                            case 8:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                                break;

                            case 9:
                                if (FastRandom.Bool()) chunk.AddPlantFlax((byte)(terrainHeight-1));
                                break;
                            }
                        }
                } else {
                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockForest;

                    if (FastRandom.Bool()) {
                        if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);
                        switch (FastRandom.Int(11)) {
                            case 1:
                                chunk.AddPlant((ushort)BlockId.Strawberry,(byte)(terrainHeight-1));
                                break;

                            case 2:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassPlains;
                                break;

                            case 3:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Dandelion;
                                break;

                            case 4:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle2;
                                break;

                            case 5:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassDesert;
                                break;

                            case 6:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                                break;

                            case 7:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rose;
                                break;

                            case 8:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                                break;

                            case 9:
                                if (FastRandom.Bool()) chunk.AddPlantFlax((byte)(terrainHeight-1));
                                break;

                            case 10:
                                if (FastRandom.Bool_33_333Percent()) chunk.AddPlantWheat((byte)(terrainHeight-1));
                                break;
                        }
                    }
                }

                if (treeChange<0) {
                    switch (FastRandom.Int(9)) {
                        case 1:
                            TreeEucalyptus(pos, terrainHeight);
                            break;
                        case 2:
                            TreeOlive(pos, terrainHeight);
                            break;
                        case 3:
                            TreePine(pos, terrainHeight);
                            break;
                        case 4:
                            TreeEucalyptus(pos, terrainHeight);
                            break;
                        case 5:
                            TreePine(pos, terrainHeight);
                            break;
                        case 6:
                            TreeLemon(pos, terrainHeight);
                            break;
                        case 7:
                            TreeOrange(pos, terrainHeight);
                            break;
                        case 8:
                            TreeCherry(pos, terrainHeight);
                            break;
                    }
                } else treeChange--;

                // Add dirt
                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{Name=Biome.Subtropics, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeHumidSubtropical(/*ChangerBiome changer*/) {
            for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Bool_1Percent()) LakeSand();
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                //Height Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                // Sub
                if (seabedChange<0) {
                    grass=!grass;
                    seabedChange=5+FastRandom.Int(10);
                } else seabedChange--;

                chunk.LightPosFull=terrainHeight;
               if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (FastRandom.Bool()) {

                    // Add animals
                    if (FastRandom.Int(15)==1) chunk.AddRabbit((byte)(terrainHeight-1));
                    else if (FastRandom.Bool_10Percent()) chunk.AddChicken((byte)(terrainHeight-1));

                    // Add something on grass
                    switch (FastRandom.Int(10)) {
                        case 1:
                            chunk.AddPlantWheat((byte)(terrainHeight-1));
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassDesert;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Dandelion;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle1;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassForest;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassDesert;
                            break;

                        case 7:
                            if (FastRandom.Bool()) chunk.AddPlant((ushort)BlockId.Onion,(byte)(terrainHeight-1));
                            else chunk.AddPlantCarrot((byte)(terrainHeight-1));
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;

                        case 9:
                            if (FastRandom.Bool()) chunk.AddPlantFlax((byte)(terrainHeight-1));
                            break;
                        }
                    }

                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockForest;

                if (treeChange<0) {
                    switch (FastRandom.Int(9)) {
                        case 1:
                            TreeEucalyptus(pos, terrainHeight);
                            break;
                        case 2:
                            TreeOlive(pos, terrainHeight);
                            break;
                        case 3:
                            TreePine(pos, terrainHeight);
                            break;
                        case 4:
                            TreePine(pos, terrainHeight);
                            break;
                        case 5:
                            TreePine(pos, terrainHeight);
                            break;
                        case 6:
                            TreeLemon(pos, terrainHeight);
                            break;
                        case 7:
                            TreeOrange(pos, terrainHeight);
                            break;
                        case 8:
                            TreeCherry(pos, terrainHeight);
                            break;
                    }
                } else treeChange--;

                // Add dirt
                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.HumidSubtropical, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize) });
            generatePos+=biomeSize;
        }

        void BiomeDesert() {
            for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Int(150)==1) LakeSand();
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                //Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
               if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (seabedChange<0) {
                    if (grass) seabedChange=20+FastRandom.Int(50);
                    else seabedChange=3+FastRandom.Int5();
                    grass=!grass;
                } else seabedChange--;

                if (grass) {
                    // Add grass
                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockDesert;

                    // Add sand
                    for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Sand;

                    // Add something on grass
                    if (FastRandom.Bool()) {
                        switch (FastRandom.Int(9)) {
                            case 1:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Alore;
                                break;

                            case 2:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassDesert;
                                break;

                            case 3:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Dandelion;
                                break;

                            case 4:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
                                break;

                            case 8:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                                break;
                        }
                    }
                } else {
                    // Add sand
                    for (int b = terrainHeight; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Sand;

                    // Add somrthing on sand
                    if (FastRandom.Bool_10Percent()) {
                        switch (FastRandom.Int(6)) {
                            case 1:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Alore;
                                break;

                            case 2:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassDesert;
                                break;

                            default:
                                AddCactus(pos, terrainHeight-1, FastRandom.Int(6), (ushort)BlockId.CactusBig);
                                break;

                            case 4:
                                AddCactus(pos, terrainHeight-1, FastRandom.Int5(), (ushort)BlockId.CactusSmall);
                                break;

                            case 5:
                                chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                                break;
                        }
                    }
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{Name=Biome.Desert, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeSavana() {
              for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Bool_1Percent()) LakeDirt();
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
              if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (seabedChange<0) {
                    if (grass) seabedChange=20+FastRandom.Int(50);
                    else seabedChange=3+FastRandom.Int5();
                    grass=!grass;
                } else seabedChange--;

                if (grass) {

                    // Add animals
                    if (FastRandom.Int(25)==1) chunk.AddChicken((byte)(terrainHeight-1));

                    // Add grass
                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockDesert;

                    // Add dirt
                    for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                    switch (FastRandom.Int(6)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Alore;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassDesert;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassPlains;
                            break;

                        //case 4:
                        //    chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
                        //    break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;
                    }
                } else {
                    // Add grass
                    chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockPlains;

                    // Add dirt
                    for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                    if (FastRandom.Bool()){
                        if (treeChange<0) {
                           switch (FastRandom.Int8()){
                                case 0:TreePine(pos,terrainHeight);break;
                                case 1:TreeAcacia(pos,terrainHeight);break;
                                case 2:if (FastRandom.Bool_33_333Percent())TreeEucalyptus(pos,terrainHeight);break;
                            }
                        } else treeChange--;
                    }

                    if (FastRandom.Int(120)==1) ClayPlace(pos-5,terrainHeight-1);

                    switch (FastRandom.Int(9)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Alore;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassDesert;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassPlains;
                            break;

                        case 5:
                            if (FastRandom.Bool_12_5Percent()) {
                                if (FastRandom.Bool()) AddCactus(pos, terrainHeight-1, FastRandom.Int(6), (ushort)BlockId.CactusBig);
                                else AddCactus(pos, terrainHeight-1, FastRandom.Int(6), (ushort)BlockId.CactusSmall);
                            }
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;
                    }
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }

            BiomeDataList.Add(new GenBiomeData{ Name=Biome.Savanna, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeMangrove() {
            for (; pos<biomeSize+generatePos; pos++) {
                if (FastRandom.Int(40)==1) LakeDirt();
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-2) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=3+FastRandom.Int3();
                } else terrainChange--;

                //Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>2) dirtHeight--;
                    else if (dirtHeight<1) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
        if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                for (int b = terrainHeight; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                if (FastRandom.Bool()) {
                    switch (FastRandom.Int(20)) {
                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle2;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchWithout;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle1;
                            break;
                    }
                }

                // Add trees
                if (treeChange<0) {
                    if (FastRandom.Bool()) TreeMangrove(pos, terrainHeight);
                } else treeChange--;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.Mangrove, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeJungle(WetBiome wet) {
             for (; pos<biomeSize+generatePos; pos++) {
                if (wet==WetBiome.High) {
                    if (FastRandom.Int(60)==1) LakeDirt();
                } else if (FastRandom.Int(80)==1)LakeDirt();
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
               if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (FastRandom.Bool()) {

                    if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);

                    // Add animals
                    if (FastRandom.Int(15)==1) chunk.AddChicken((byte)(terrainHeight-1));


                    switch (FastRandom.Int(9)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Orchid;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassJungle;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassJungle;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchFull;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassJungle;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassJungle;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassJungle;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;
                    }
                }

                // Add grass
                if (terrainHeight>60) chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockJungle;
                else chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockForest;

                if (treeChange<0) {
                   switch (FastRandom.Int4()){
                       default:
                            TreePineJunle(pos, terrainHeight);
                            break;

                        case 1:
                            TreeKapok(pos-1, terrainHeight);
                            break;

                        case 2:
                            TreeRubber(pos, terrainHeight);
                            break;
                   }
                } else treeChange--;

                // Add dirt
                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            BiomeDataList.Add(new GenBiomeData{ Name=Biome.Jungle, Start=(ushort)generatePos, End=(ushort)(generatePos+biomeSize)});
            generatePos+=biomeSize;
        }

        void BiomeMountainsCold() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) {
                        terrainHeight--;
                        hill =false;
                    } else if (terrainHeight<53-10) {
                         terrainHeight++;
                         hill =true;
                    } else {
                        if (hill)terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=1+FastRandom.Int3();
                } else terrainChange--;

                //Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
             if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                // Add grass
                chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockHills;

                if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);

                // Add something on grass
                if (FastRandom.Bool()) {
                    switch (FastRandom.Int(9)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle2;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Violet;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Dandelion;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;
                    }
                }

                if (treeChange<0) {
                    if (FastRandom.Bool_10Percent()) {
                       if (FastRandom.Bool()) TreeSpruceLittle(pos, terrainHeight);
                       else TreeOakLittle(pos, terrainHeight);
                   }
                } else treeChange--;

                // Add dirt
                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeMountainsMild() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) {
                        terrainHeight--;
                        hill=false;
                    } else if (terrainHeight<53-10) {
                         terrainHeight++;
                         hill=true;
                    } else {
                        if (hill)terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=1+FastRandom.Int3();
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
             if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockHills;
                if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);
                if (FastRandom.Bool()) {
                    switch (FastRandom.Int(9)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle2;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Violet;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Dandelion;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;
                    }
                }

                if (treeChange<0) {
                    if (FastRandom.Bool_10Percent()) {
                       if (FastRandom.Bool()) TreeSpruceLittle(pos, terrainHeight);
                       else TreeOakLittle(pos, terrainHeight);
                   }
                } else treeChange--;

                // Add dirt
                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeMountainsWarm() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) {
                        terrainHeight--;
                        hill =false;
                    } else if (terrainHeight<53-10) {
                         terrainHeight++;
                         hill =true;
                    } else {
                        if (hill)terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=1+FastRandom.Int3();
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
              if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                // Add grass
                chunk.SolidBlocks[terrainHeight]=(ushort)BlockId.GrassBlockForest;

                if (FastRandom.Bool_2Percent()) ClayPlace(pos-5,terrainHeight-1);

                if (FastRandom.Bool()) {
                    switch (FastRandom.Int(9)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.GrassHills;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.BranchALittle2;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Violet;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Dandelion;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                            break;
                    }
                }

                if (treeChange<0) {
                    if (FastRandom.Bool_10Percent()) {
                       if (FastRandom.Bool()) TreeSpruceLittle(pos, terrainHeight);
                       else TreePine(pos, terrainHeight);
                   }
                } else treeChange--;

                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.SolidBlocks[b]=(ushort)BlockId.Dirt;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }
        #endregion

        void BiomeDarkMoonBiome() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
               if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                ushort[] chunk_SolidBlocks=chunk.SolidBlocks;

                if (FastRandom.Int(9)==1) {
                    if (FastRandom.Bool()) chunk_SolidBlocks[terrainHeight-1]=(ushort)BlockId.Cobblestone;
                    else chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                }

                if (FastRandom.Int(9)==1) chunk_SolidBlocks[terrainHeight]=(ushort)BlockId.StoneBasalt;
                else if (FastRandom.Int(9)==1) chunk_SolidBlocks[terrainHeight]=(ushort)BlockId.Cobblestone;
                else chunk_SolidBlocks[terrainHeight]=(ushort)BlockId.Regolite;

                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) {
                     if (FastRandom.Int(6)==1) chunk_SolidBlocks[b]=(ushort)BlockId.Cobblestone;
                     else chunk_SolidBlocks[b]=(ushort)BlockId.StoneBasalt;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk_SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurfaceMoonDark(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurfaceMoonDark(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeLightMoonBiome() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
               if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                ushort[] chunk_SolidBlocks=chunk.SolidBlocks;

                if (FastRandom.Bool_12_5Percent()) {
                    if (FastRandom.Bool()) chunk_SolidBlocks[terrainHeight-1]=(ushort)BlockId.Cobblestone;
                    else chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                }

                if (FastRandom.Int(9)==1) chunk_SolidBlocks[terrainHeight]=(ushort)BlockId.Anorthosite;
                else if (FastRandom.Int(9)==1) chunk_SolidBlocks[terrainHeight]=(ushort)BlockId.Cobblestone;
                else chunk_SolidBlocks[terrainHeight]=(ushort)BlockId.Regolite;


                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) {
                     if (FastRandom.Int(6)==1) chunk_SolidBlocks[b]=(ushort)BlockId.Cobblestone;
                     else chunk_SolidBlocks[b]=(ushort)BlockId.Anorthosite;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk_SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurfaceMoonLight(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurfaceMoonLight(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeMarsPoles() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                //Height (ushort)BlockId.Dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=(byte)(terrainHeight-2);
            if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                if (FastRandom.Bool_12_5Percent()) chunk.TopBlocks[terrainHeight-3]=(ushort)BlockId.SnowTop;

                ushort[] chunk_SolidBlocks=chunk.SolidBlocks;

                chunk_SolidBlocks[terrainHeight-2]=(ushort)BlockId.Ice;
                chunk_SolidBlocks[terrainHeight-1]=(ushort)BlockId.Ice;

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk_SolidBlocks[terrainHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurfaceMars(chunk, terrainHeight+1);
                } else GenerateUnderSurfaceMars(chunk, terrainHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeMarsNormalYellow() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
               if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                ushort[] chunk_SolidBlocks=chunk.SolidBlocks;

                if (FastRandom.Int(6)==1) {
                    if (FastRandom.Bool_20Percent()) chunk_SolidBlocks[terrainHeight-1]=(ushort)BlockId.Cobblestone;
                    else chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                }

                for (int b =terrainHeight; b<terrainHeight+dirtHeight; b++) {
                    if (FastRandom.Int(6)==1) chunk_SolidBlocks[b]=(ushort)BlockId.Cobblestone;
                    else chunk_SolidBlocks[b]=(ushort)BlockId.Sand;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk_SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurfaceMars(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurfaceMars(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeMarsNormalWhite() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
            if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                ushort[] chunk_SolidBlocks=chunk.SolidBlocks;

                if (FastRandom.Int(6)==1) {
                    if (FastRandom.Bool_20Percent()) chunk_SolidBlocks[terrainHeight-1]=(ushort)BlockId.Cobblestone;
                    else chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                }

                for (int b = terrainHeight; b<terrainHeight+dirtHeight; b++) {
                    if (FastRandom.Int(6)==1) chunk_SolidBlocks[b]=(ushort)BlockId.Cobblestone;
                    else chunk_SolidBlocks[b]=(ushort)BlockId.Regolite;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk_SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurfaceMars(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurfaceMars(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeMarsNormalRed() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk = terrain[pos];

                // Terrain height
                if (terrainChange<0) {
                    if (terrainHeight>53-1) terrainHeight--;
                    else if (terrainHeight<53-6) terrainHeight++;
                    else {
                        if (FastRandom.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+FastRandom.Int3();
                } else terrainChange--;

                // height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (FastRandom.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+FastRandom.Int3();
                } else dirtChange--;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }
                ushort[] chunk_SolidBlocks=chunk.SolidBlocks;

                if (FastRandom.Int(6)==1) {
                    if (FastRandom.Bool_20Percent())chunk_SolidBlocks[terrainHeight-1]=(ushort)BlockId.Cobblestone;
                    else chunk.TopBlocks[terrainHeight-1]=(ushort)BlockId.Rocks;
                }

                for (int b = terrainHeight; b<terrainHeight+dirtHeight; b++) {
                    if (FastRandom.Int(6)==1) chunk_SolidBlocks[b]=(ushort)BlockId.Cobblestone;
                    else chunk_SolidBlocks[b]=(ushort)BlockId.RedSand;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk_SolidBlocks[terrainHeight+dirtHeight]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurfaceMars(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurfaceMars(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        ushort block1, block2, block3;

        void GenerateUnderSurface(GChunk chunk, int height) {

            // Change height of levels
            if (height12Change==0) {
                if (height12<65) height12++;
                else if (height12>70) height12--;
                else {
                    if (FastRandom.Bool()) height12++;
                    else height12--;
                }
                height12Change=FastRandom.Int2()+1;
            } else height12Change--;


            if (height23Change==0) {
                if (height23<80)height23++;
                else if (height23>85)height23--;
                else if (FastRandom.Bool()) height23++;
                else height23--;

                height23Change=FastRandom.Int3()+1;
            } else height23Change--;

            if (height34Change==0) {
                if (height34<105)height34++;
                else if (height34>110)height34--;
                else if (FastRandom.Bool()) height34++;
                else height34--;
                height34Change=FastRandom.Int4()+1;
            } else height34Change--;

            //Type
            if (level1Lenght==0) {
                level1TypeLast=level1Type;
                level1Crossing=2;
                level1Type=FastRandom.Int(10);

                level1Lenght=FastRandom.Int(12)+8+8;
                block1 =GetByIdHeight1(level1Type);
            } else {
                level1Lenght--;
                level1Crossing--;
            }

            if (level2Lenght==0) {
                level2TypeLast=level2Type;
                level2Crossing=2;
                level2Type=FastRandom.Int(10);

                level2Lenght=FastRandom.Int16()+8+8+8;
                block2 =GetByIdHeight2(level2Type);
            } else {
                level2Lenght--;
                level2Crossing--;
            }

            if (level3Lenght==0) {
                level3TypeLast=level3Type;
                level3Crossing=2;
                level3Type=FastRandom.Int(10);

                level3Lenght=FastRandom.Int(20)+8+8+24;
                block3 =GetByIdHeight3(level3Type);
            } else {
                level3Lenght--;
                level3Crossing--;
            }

            //Generate 1
           // ushort block1 =GetByIdHeight1(level1Type);

            ushort[] chunk_SolidBlocks=chunk.SolidBlocks;

            if (level1Crossing==2) {
                ushort oldTop = GetByIdHeight1(level1TypeLast);
                for (int y = height; y<height12; y++) {
                    if (FastRandom.Bool_33_333Percent()) chunk_SolidBlocks[y]=oldTop;
                    else chunk_SolidBlocks[y]=block1;
                }
            } else if (level1Crossing==1) {
                ushort oldTop = GetByIdHeight1(level1TypeLast);
                for (int y = height; y<height12; y++) {
                    if (FastRandom.Bool()) chunk_SolidBlocks[y]=oldTop;
                    else chunk_SolidBlocks[y]=block1;
                }
            } else {
                for (int y=height; y<height12;y++) chunk_SolidBlocks[y]=block1;
            }


            //Generate 2
             //ushort block2 =GetByIdHeight2(level2Type);
             if (level2Crossing==2) {
                ushort oldTop = GetByIdHeight2(level2TypeLast);
                for (int y = height12; y<height23; y++) {
                    if (FastRandom.Bool_33_333Percent()) chunk_SolidBlocks[y]=oldTop;
                    else chunk_SolidBlocks[y]=block2;
                }
            } else if (level2Crossing==1) {
                ushort oldTop = GetByIdHeight2(level2TypeLast);
                for (int y = height12; y<height23; y++) {
                    if (FastRandom.Bool_33_333Percent()) chunk_SolidBlocks[y]=block2;
                    else chunk_SolidBlocks[y]=oldTop;
                }
            } else {
                for (int y=height12; y<height23; y++) chunk_SolidBlocks[y]=block2;
            }

            //Generate 3
           // ushort block3 =GetByIdHeight3(level3Type);

            if (level3Crossing==2) {
                ushort oldTop = GetByIdHeight3(level3TypeLast);
                for (int y = height23; y<height34; y++) {
                    if (FastRandom.Bool_33_333Percent()) chunk_SolidBlocks[y]=oldTop;
                    else chunk_SolidBlocks[y]=block3;
                }
            } else if (level3Crossing==1) {
                ushort oldTop = GetByIdHeight3(level3TypeLast);
                for (int y = height23; y<height34; y++) {
                    if (FastRandom.Bool_33_333Percent()) chunk_SolidBlocks[y]=block3;
                    else chunk_SolidBlocks[y]=oldTop;
                }
            } else {
                for (int y=height23; y<height34; y++) chunk_SolidBlocks[y]=block3;
            }

            chunk_SolidBlocks[height+FastRandom.Int(height34-height)]=(ushort)BlockId.Cobblestone;

            // Generate (ushort)BlockId.Lava
            for (int y=height34; y<125; y++) chunk.TopBlocks[y]=(ushort)BlockId.Lava;

            // Generate ores
            if (FastRandom.Bool_20Percent()) {
                if (pos>15) {
                    switch (FastRandom.Int(35)) {
                        case 1:
                            OreCoal(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 2:
                            OreCoal(height+3+FastRandom.Int(45));
                            break;
                        case 3:
                            OreCoal(height+3+FastRandom.Int(10));
                            break;
                        case 4:
                            OreCoal(height+3+FastRandom.Int(10));
                            break;
                        case 5:
                            OreCoal(height+3+30+FastRandom.Int(10));
                            break;
                        case 6:
                            OreCoal(height+3+30+FastRandom.Int(10));
                            break;


                        case 7:
                            OreCopper(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 8:
                            OreCopper(height+3+FastRandom.Int(45));
                            break;
                        case 9:
                            OreCopper(height+3+FastRandom.Int(15));
                            break;
                        case 10:
                            OreCopper(height+3+FastRandom.Int(10));
                            break;
                        case 11:
                            OreCopper(height+10+FastRandom.Int(10));
                            break;


                        case 12:
                            OreIron(height+3+FastRandom.Int(height34-height-10)+2);
                            break;
                        case 13:
                            OreIron(height+3+FastRandom.Int(45)+2);
                            break;
                        case 14:
                            OreIron(height+10+FastRandom.Int(20));
                            break;
                        case 15:
                            OreIron(height+3+FastRandom.Int(45)+2);
                            break;


                        case 16:
                            OreOil(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 17:
                            OreOil(height+3+FastRandom.Int(45));
                            break;
                        case 18:
                            OreOil(height+3+FastRandom.Int(34));
                            break;
                        case 19:
                            OreOil(height+3+FastRandom.Int(35));
                            break;


                        case 20:
                            OreTin(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 21:
                            OreTin(height+3+FastRandom.Int(35));
                            break;
                        case 22:
                            OreTin(height+6+FastRandom.Int(25));
                            break;


                        case 23:
                            OreSilver(height+3+FastRandom.Int(height34-height-5));
                            break;


                        case 24:
                            OreGold(height+3+FastRandom.Int(height34-height-5));
                            break;

                        case 25:
                            OreAliminium(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 26:
                            OreAliminium(height+3+FastRandom.Int(45));
                            break;
                        case 27:
                            OreAliminium(height+3+FastRandom.Int(35));
                            break;

                        case 28:
                            OreSulfur(height+3+FastRandom.Int(height12-height/*-10*/));
                            break;

                        case 29:
                            OreSaltpeter(height+3+FastRandom.Int(height12-height/*-10*/));
                            break;

                            case 30:
                            OreSulfur(height+3+FastRandom.Int(height12-height/*-10*/));
                            break;

                        case 31:
                            OreSaltpeter(height+3+FastRandom.Int(height12-height/*-10*/));
                            break;
                    }
                }
            }
        }

        void GenerateUnderSurfaceMoonDark(GChunk chunk, int height) {
            if (height34Change==0) {
                if (height34<105)height34++;
                else if (height34>110)height34--;
                else if (FastRandom.Bool()) height34++;
                else height34--;
                height34Change=FastRandom.Int4()+1;
            } else height34Change--;

            if (level3Lenght==0) {
                level3TypeLast=level3Type;
                level3Crossing=2;
                level3Type=FastRandom.Int(10);

                level3Lenght=FastRandom.Int(20)+8+8+24;
            } else {
                level3Lenght--;
                level3Crossing--;
            }


            ushort[]chunk_SolidBlocks=chunk.SolidBlocks;

            for (int y=height; y<height34;y++) chunk_SolidBlocks[y]=(ushort)BlockId.StoneBasalt;


            chunk_SolidBlocks[height+FastRandom.Int(height34-height)]=(ushort)BlockId.Cobblestone;

            // Generate (ushort)BlockId.Lava
            for (int y=height34; y<125; y++) chunk.TopBlocks[y]=(ushort)BlockId.Lava;

            // Generate ores
            if (FastRandom.Bool_20Percent()/* Int(5)==1*/) {
                if (pos>15) {
                    switch (FastRandom.Int(25)) {


                        case 7:
                            OreCopper(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 8:
                            OreCopper(height+3+FastRandom.Int(45));
                            break;
                        case 9:
                            OreIron(height+3+FastRandom.Int(15));
                            break;
                        case 10:
                            OreCopper(height+3+FastRandom.Int(10));
                            break;
                        case 11:
                            OreCopper(height+10+FastRandom.Int(10));
                            break;


                        case 12:
                            OreIron(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 13:
                            OreIron(height+3+FastRandom.Int(45));
                            break;
                        case 14:
                            OreIron(height+10+FastRandom.Int(20));
                            break;
                        case 15:
                            OreIron(height+3+FastRandom.Int(45));
                            break;


                        case 20:
                            OreTin(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 21:
                            OreTin(height+3+FastRandom.Int(35));
                            break;
                        case 22:
                            OreTin(height+6+FastRandom.Int(25));
                            break;


                        case 23:
                            OreSilver(height+3+FastRandom.Int(height34-height-5));
                            break;


                        case 24:
                            OreGold(height+3+FastRandom.Int(height34-height-5));
                            break;

                        case 25:
                            OreAliminium(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 26:
                            OreAliminium(height+3+FastRandom.Int(45));
                            break;
                        case 27:
                            OreAliminium(height+3+FastRandom.Int(35));
                            break;
                    }
                }
            }
        }

        void GenerateUnderSurfaceMoonLight(GChunk chunk, int height) {
            if (height34Change==0) {
                if (height34<105)height34++;
                else if (height34>110)height34--;
                else if (FastRandom.Bool()) height34++;
                else height34--;
                height34Change=FastRandom.Int4()+1;
            } else height34Change--;


            if (level3Lenght==0) {
                level3TypeLast=level3Type;
                level3Crossing=2;
                level3Type=FastRandom.Int(10);

                level3Lenght=FastRandom.Int(20)+8+8+24;
            } else {
                level3Lenght--;
                level3Crossing--;
            }

            ushort[] chunk_SolidBlocks=chunk.SolidBlocks;

            for (int y=height; y<height34;y++) chunk_SolidBlocks[y]=(ushort)BlockId.Anorthosite;

            chunk_SolidBlocks[height+FastRandom.Int(height34-height)]=(ushort)BlockId.Cobblestone;

            // Generate (ushort)BlockId.Lava
            for (int y=height34; y<125; y++) chunk.TopBlocks[y]=(ushort)BlockId.Lava;

            // Generate ores
            if (FastRandom.Bool_20Percent()) {
                if (pos>15) {
                    switch (FastRandom.Int(25)) {


                        case 7:
                            OreCopper(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 8:
                            OreCopper(height+3+FastRandom.Int(45));
                            break;
                        case 9:
                            OreIron(height+3+FastRandom.Int(15));
                            break;
                        case 10:
                            OreCopper(height+3+FastRandom.Int(10));
                            break;
                        case 11:
                            OreCopper(height+10+FastRandom.Int(10));
                            break;


                        case 12:
                            OreIron(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 13:
                            OreIron(height+3+FastRandom.Int(45));
                            break;
                        case 14:
                            OreIron(height+10+FastRandom.Int(20));
                            break;
                        case 15:
                            OreIron(height+3+FastRandom.Int(45));
                            break;





                        case 20:
                            OreTin(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 21:
                            OreTin(height+3+FastRandom.Int(35));
                            break;
                        case 22:
                            OreTin(height+6+FastRandom.Int(25));
                            break;


                        case 23:
                            OreSilver(height+3+FastRandom.Int(height34-height-5));
                            break;


                        case 24:
                            OreGold(height+3+FastRandom.Int(height34-height-5));
                            break;

                        case 25:
                            OreAliminium(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 26:
                            OreAliminium(height+3+FastRandom.Int(45));
                            break;
                        case 27:
                            OreAliminium(height+3+FastRandom.Int(35));
                            break;
                    }
                }
            }
        }

        void GenerateUnderSurfaceMars(GChunk chunk, int height) {

            // Change height of levels
            if (height12Change==0) {
                if (height12<65) height12++;
                else if (height12>70) height12--;
                else {
                    if (FastRandom.Bool()) height12++;
                    else height12--;
                }
                height12Change=FastRandom.Int2()+1;
            } else height12Change--;



            //Type
            if (level1Lenght==0) {
                level1TypeLast=level1Type;
                level1Crossing=2;
                level1Type=FastRandom.Int5();

                level1Lenght=FastRandom.Int(20)+20;
            } else {
                level1Lenght--;
                level1Crossing--;
            }


             ushort[]chunk_SolidBlocks=chunk.SolidBlocks;

            //Generate 1
            ushort block1 =GetByIdHeightMars(level1Type);

            if (level1Crossing==2) {
                ushort oldTop = GetByIdHeight1(level1TypeLast);
                for (int y = height; y<height23; y++) {
                    if (FastRandom.Bool_33_333Percent()) chunk_SolidBlocks[y]=oldTop;
                    else chunk_SolidBlocks[y]=block1;
                }
            } else if (level1Crossing==1) {
                ushort oldTop = GetByIdHeight1(level1TypeLast);
                for (int y = height; y<height23; y++) {
                    if (FastRandom.Bool()) chunk_SolidBlocks[y]=oldTop;
                    else chunk_SolidBlocks[y]=block1;
                }
            } else {
                for (int y=height; y<height34;y++) chunk_SolidBlocks[y]=block1;
            }



                for (int y=height23; y<height34; y++) chunk_SolidBlocks[y]=(ushort)BlockId.StoneBasalt;
           // }

            chunk_SolidBlocks[height+FastRandom.Int(height34-height)]=(ushort)BlockId.Cobblestone;

            // Generate (ushort)BlockId.Lava
            for (int y=height34; y<125; y++) chunk.TopBlocks[y]=(ushort)BlockId.Lava;

            // Generate ores
            if (FastRandom.Bool_20Percent()) {
                if (pos>15) {
                    switch (FastRandom.Int(25)) {
                        case 1:
                            OreIron(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 2:
                            OreIron(height+3+FastRandom.Int(45));
                            break;


                        case 7:
                            OreCopper(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 8:
                            OreCopper(height+3+FastRandom.Int(45));
                            break;
                        case 9:
                            OreCopper(height+3+FastRandom.Int(15));
                            break;
                        case 10:
                            OreCopper(height+3+FastRandom.Int(10));
                            break;
                        case 11:
                            OreCopper(height+10+FastRandom.Int(10));
                            break;


                        case 12:
                            OreIron(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 13:
                            OreIron(height+3+FastRandom.Int(45));
                            break;
                        case 14:
                            OreIron(height+10+FastRandom.Int(20));
                            break;
                        case 15:
                            OreIron(height+3+FastRandom.Int(45));
                            break;



                        case 20:
                            OreTin(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 21:
                            OreTin(height+3+FastRandom.Int(35));
                            break;
                        case 22:
                            OreTin(height+6+FastRandom.Int(25));
                            break;


                        case 23:
                            OreSilver(height+3+FastRandom.Int(height34-height-5));
                            break;


                        case 24:
                            OreGold(height+3+FastRandom.Int(height34-height-5));
                            break;

                        case 25:
                            OreAliminium(height+3+FastRandom.Int(height34-height-10));
                            break;
                        case 26:
                            OreAliminium(height+3+FastRandom.Int(45));
                            break;
                        case 27:
                            OreAliminium(height+3+FastRandom.Int(35));
                            break;
                    }
                }
            }
        }

        ushort GetByIdHeight1(int v) {
            switch (v) {
                case 1: return (ushort)BlockId.StoneSandstone;
                case 2: return (ushort)BlockId.StoneLimestone;
                case 3: return (ushort)BlockId.StoneSchist;
                case 4: return (ushort)BlockId.StoneGneiss;
                case 5: return (ushort)BlockId.StoneDolomite;

                case 11: return (ushort)BlockId.StoneSandstone;
                case 12: return (ushort)BlockId.StoneLimestone;
                case 13: return (ushort)BlockId.StoneSchist;
                case 14: return (ushort)BlockId.StoneDolomite;
                case 15: return (ushort)BlockId.StoneDolomite;

                case 6:  return (ushort)BlockId.StoneDiorit;
                case 7:  return (ushort)BlockId.StoneGabbro;
                case 8:  return (ushort)BlockId.StoneGneiss;
                case 9:  return (ushort)BlockId.StoneBasalt;
                case 10: return (ushort)BlockId.StoneRhyolite;

                default: return (ushort)BlockId.StoneDolomite;
            }
        }

        ushort GetByIdHeight2(int v) {
            switch (v) {
                case 1: return (ushort)BlockId.StoneBasalt;
                case 2: return (ushort)BlockId.StoneGabbro;
                case 3: return (ushort)BlockId.StoneDiorit;
                case 4: return (ushort)BlockId.StoneGneiss;

                case 5: return  (ushort)BlockId.StoneBasalt;
                case 11: return (ushort)BlockId.StoneGabbro;
                case 12: return (ushort)BlockId.StoneDiorit;
                case 13: return (ushort)BlockId.StoneGneiss;

                case 14: return (ushort)BlockId.StoneGneiss;
                case 15: return (ushort)BlockId.StoneGneiss;

                case 6: return  (ushort)BlockId.StoneSandstone;
                case 7: return  (ushort)BlockId.StoneLimestone;
                case 8: return  (ushort)BlockId.StoneSchist;
                case 9: return  (ushort)BlockId.StoneDolomite;
                case 10: return (ushort)BlockId.StoneRhyolite;

                default: return (ushort)BlockId.StoneDolomite;
            }
        }

        ushort GetByIdHeight3(int v) {
            return v switch {
                1 => (ushort)BlockId.StoneBasalt,
                2 => (ushort)BlockId.StoneGabbro,
                3 => (ushort)BlockId.StoneDiorit,
                4 => (ushort)BlockId.StoneGneiss,
                5 => (ushort)BlockId.StoneBasalt,
                11 => (ushort)BlockId.StoneGabbro,
                12 => (ushort)BlockId.StoneDiorit,
                13 => (ushort)BlockId.StoneGneiss,
                14 => (ushort)BlockId.StoneBasalt,
                15 => (ushort)BlockId.StoneBasalt,
                6 => (ushort)BlockId.StoneSandstone,
                7 => (ushort)BlockId.StoneLimestone,
                8 => (ushort)BlockId.StoneSchist,
                9 => (ushort)BlockId.StoneDolomite,
                10 => (ushort)BlockId.StoneRhyolite,
                _ => (ushort)BlockId.StoneDolomite,
            };
        }

        ushort GetByIdHeightMars(int v) {
            return v switch {
                1 => (ushort)BlockId.StoneSandstone,
                2 => (ushort)BlockId.StoneBasalt,
                3 => (ushort)BlockId.StoneBasalt,
                4 => (ushort)BlockId.MudStone,
                _ => (ushort)BlockId.StoneSandstone,
            };
        }

        unsafe void Save(string name) {
            world++;

            List<byte> bytes=new();
            List<byte> bytesLiveObject = new() {
                (byte)LiveObjects.Count,
                (byte)(LiveObjects.Count>>8),
                (byte)(LiveObjects.Count>>16)
            };

            List<byte> tmpBytes=new();

            for (int x=0; x<generatePos-7; x++) {
                GChunk chunk=terrain[x];
                ushort solidBlockId= (ushort)BlockId.None,
                    topBlockId  = (ushort)BlockId.None,
                    backBlockId = (ushort)BlockId.None;

                SaveType lastType=SaveType.Unknown;
                int lastTypeCount=-1;
                bytes.Add(chunk.LightPosFull);
               // bytes.Add(chunk.Half);
                bytes.Add(chunk.LightPosHalf);

                for (int y=0; y<125; y++) {
                    ushort newSolidBlockId=chunk.SolidBlocks[y];

                    if (newSolidBlockId!=0) {

                        // solid
                        switch (lastType) {
                            case SaveType.SolidBlock:
                                if (newSolidBlockId==solidBlockId) {
                                    lastType=SaveType.SolidBlockMultiple;
                                    lastTypeCount=2;
                                } else goto default;
                                break;

                            case SaveType.SolidBlockMultiple:
                                if (newSolidBlockId==solidBlockId) {
                                    lastTypeCount++;
                                } else goto default;
                                break;

                            default:
                                SaveLast();

                                lastType=SaveType.SolidBlock;
                                lastTypeCount=1;
                                solidBlockId=newSolidBlockId;
                                topBlockId=0;
                                backBlockId=0;
                                break;
                        }
                    } else {
                        ushort newTopBlockId=chunk.TopBlocks[y],
                            newBackBlockId=chunk.BackBlocks[y];

                        if (newTopBlockId!=0) {
                            if (newBackBlockId!=0) {

                                // back and top
                                switch (lastType) {
                                    case SaveType.BackBlockAndTopBlock:
                                        if (newBackBlockId==backBlockId && newTopBlockId==topBlockId) {
                                            lastTypeCount=2;
                                            lastType=SaveType.BackBlockAndTopBlockMultiple;
                                        } else goto default;
                                        break;

                                    case SaveType.BackBlockAndTopBlockMultiple:
                                        if (newBackBlockId==backBlockId && newTopBlockId==topBlockId) {
                                            lastTypeCount++;
                                        } else goto default;
                                        break;

                                    case SaveType.BackBlockAndTopBlockMoreLoad:
                                        if (newBackBlockId==backBlockId && newTopBlockId==topBlockId) {
                                           //  chunk.TopBlocks[y].SaveTop(tmpBytes);
                                           SaveMachineTop(chunk.TopBlocks[y]);
                                            lastTypeCount=2;
                                            lastType=SaveType.BackBlockAndTopBlockMoreLoadMultiple;
                                        } else goto default;
                                        break;

                                    case SaveType.BackBlockAndTopBlockMoreLoadMultiple:
                                        if (newBackBlockId==backBlockId && newTopBlockId==topBlockId) {
                                           // chunk.TopBlocks[y].SaveTop(tmpBytes);
                                            SaveMachineTop(chunk.TopBlocks[y]);
                                            lastTypeCount++;
                                        } else goto default;
                                        break;

                                    default:
                                        SaveLast();

                                        if (newTopBlockId<(int)BlockId._MoreInLoad) {
                                            lastType=SaveType.BackBlockAndTopBlockMoreLoad;
                                           // chunk.TopBlocks[y].SaveTop(tmpBytes);
                                            SaveMachineTop(chunk.TopBlocks[y]);
                                        } else {
                                            lastType=SaveType.BackBlockAndTopBlock;
                                        }

                                        lastTypeCount=1;
                                        topBlockId=newTopBlockId;
                                        backBlockId=newBackBlockId;
                                        solidBlockId=0;
                                        break;
                                }

                            } else {

                                // only top
                                switch (lastType) {
                                    case SaveType.TopBlock:
                                        if (newTopBlockId==topBlockId) {
                                            // Before was one TopBlock + now same => convert to multiple
                                            lastType=SaveType.TopBlockMultiple;
                                            lastTypeCount=2;
                                        } else goto default;
                                        break;

                                    case SaveType.TopBlockMultiple:
                                        if (newTopBlockId==topBlockId) {

                                            // Before was senquence of basic TopBlock + now same => add to list
                                            lastTypeCount++;
                                        } else goto default;
                                        break;

                                    case SaveType.TopBlockMoreLoad:
                                        if (newTopBlockId==topBlockId) {
                                           // chunk.TopBlocks[y].SaveTop(tmpBytes);
                                            SaveMachineTop(chunk.TopBlocks[y]);
                                            lastType=SaveType.TopBlockMoreLoadMultiple;
                                            lastTypeCount=2;
                                        } else goto default;
                                        break;

                                    case SaveType.TopBlockMoreLoadMultiple:
                                        if (newTopBlockId==topBlockId) {
                                          //  chunk.TopBlocks[y].SaveTop(tmpBytes);
                                            SaveMachineTop(chunk.TopBlocks[y]);
                                            lastTypeCount++;
                                        } else goto default;
                                        break;

                                    default:
                                        SaveLast();

                                        if (newTopBlockId<(int)BlockId._MoreInLoad) {
                                            lastType=SaveType.TopBlockMoreLoad;
                                            //chunk.TopBlocks[y].SaveTop(tmpBytes);
                                            SaveMachineTop(chunk.TopBlocks[y]);
                                        } else {
                                            lastType=SaveType.TopBlock;
                                        }

                                        lastTypeCount=1;
                                        topBlockId=newTopBlockId;
                                        solidBlockId=0;
                                        backBlockId=0;
                                        break;
                                }
                            }
                        } else if (newBackBlockId!=0) {

                            // only back
                            switch (lastType){
                                case SaveType.BackBlock:
                                    if (backBlockId==newBackBlockId){
                                        lastType=SaveType.BackBlockMultiple;
                                        lastTypeCount=2;
                                    } else {
                                        goto default;
                                    }
                                    break;

                                case SaveType.BackBlockMultiple:
                                    if (backBlockId==newBackBlockId) {
                                        lastTypeCount++;
                                    } else goto default;
                                    break;

                                default:
                                    SaveLast();

                                    lastType=SaveType.BackBlock;
                                    lastTypeCount=1;
                                    backBlockId=newBackBlockId;
                                    break;
                            }
                        } else {

                            // air
                            if (lastType==SaveType.Air) {
                                lastType=SaveType.AirMultiple;
                                lastTypeCount=2;
                            } else if (lastType==SaveType.AirMultiple) {
                                lastTypeCount++;
                            } else {
                                SaveLast();

                                lastType=SaveType.Air;
                                lastTypeCount=1;

                                topBlockId=0;
                                solidBlockId=0;
                                backBlockId=0;
                            }
                        }
                    }
                }
                SaveLast();

                unsafe void SaveLast() {
                    if (lastType==SaveType.Unknown) return;

                    switch (lastType) {
                        #if DEBUG
                        case SaveType.Unknown:
                            throw new System.Exception("Špatně naprogramováno");
                        #endif

                        case SaveType.Air:
                            bytes.Add((byte)lastType);
                            return;

                        case SaveType.AirMultiple:
                            bytes.Add((byte)lastType);
                            bytes.Add((byte)lastTypeCount);
                            return;

                        case SaveType.SolidBlock:
                            if (solidBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.SolidBlockWithLowId);

                                // Id
                                bytes.Add((byte)solidBlockId);
                            } else {

                                // SaveType
                                bytes.Add((byte)SaveType.SolidBlock);

                                // Id
                                ushort id=solidBlockId;
                                byte* bytesSolidBlockId = (byte*)&id;
                                bytes.Add(bytesSolidBlockId[0]);
                                bytes.Add(bytesSolidBlockId[1]);
                            }
                            return;

                        case SaveType.SolidBlockMultiple:
                            if (solidBlockId<256) {
                                    // SaveType
                                bytes.Add((byte)SaveType.SolidBlockWithLowIdMultiple);

                                // id
                                bytes.Add((byte)solidBlockId);
                            } else {

                                // SaveType
                                bytes.Add((byte)SaveType.SolidBlockMultiple);

                                // id
                                ushort id=solidBlockId;
                                byte* bytesSolidBlockId = (byte*)&id;
                                bytes.Add(bytesSolidBlockId[0]);
                                bytes.Add(bytesSolidBlockId[1]);
                            }

                            // Count
                            bytes.Add((byte)lastTypeCount);
                            return;

                        case SaveType.TopBlock:
                            if (topBlockId<256) {

                                // SaveType
                                bytes.Add((byte)SaveType.TopBlockWithLowId);

                                // id
                                bytes.Add((byte)topBlockId);
                            } else {

                                // SaveType
                                bytes.Add((byte)SaveType.TopBlock);

                                // id
                                ushort id=topBlockId;
                                byte* bytesTopBlockId = (byte*)&id;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);
                            }
                            return;

                        case SaveType.TopBlockMultiple:
                            if (topBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.TopBlockWithLowIdMultiple);

                                // Id
                                bytes.Add((byte)topBlockId);
                            } else {
                                // SaveType
                                bytes.Add((byte)SaveType.TopBlockMultiple);

                                // Id
                                ushort id=topBlockId;
                                byte* bytesTopBlockId = (byte*)&id;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);
                            }

                            // Count
                            bytes.Add((byte)lastTypeCount);
                            return;

                        case SaveType.BackBlock:
                            if (backBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockWithLowId);

                                // Id
                                bytes.Add((byte)backBlockId);
                            } else {

                                // SaveType
                                bytes.Add((byte)SaveType.BackBlock);

                                // Id
                                ushort id=backBlockId;
                                byte* bytesBackBlockId = (byte*)&id;
                                bytes.Add(bytesBackBlockId[0]);
                                bytes.Add(bytesBackBlockId[1]);
                            }
                            return;

                        case SaveType.BackBlockMultiple:
                            if (backBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockWithLowIdMultiple);

                                // Id
                                bytes.Add((byte)backBlockId);
                            } else {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockMultiple);

                                // id
                                ushort id=backBlockId;
                                byte* bytesBackBlockId = (byte*)&id;
                                bytes.Add(bytesBackBlockId[0]);
                                bytes.Add(bytesBackBlockId[1]);
                            }

                            // Count
                            bytes.Add((byte)lastTypeCount);
                            return;

                        case SaveType.BackBlockAndTopBlock:
                            if (backBlockId<256 && topBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockWithLowIdAndTopBlockWithLowId);

                                // back block id
                                bytes.Add((byte)backBlockId);

                                // top block id
                                bytes.Add((byte)topBlockId);

                            } else if (backBlockId>255 && topBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockAndTopBlockWithLowId);

                                // back block id
                                ushort backId=backBlockId;
                                byte* bytesBackBlockId = (byte*)&backId;
                                bytes.Add(bytesBackBlockId[0]);
                                bytes.Add(bytesBackBlockId[1]);

                                // top block id
                                bytes.Add((byte)topBlockId);

                            } else if (backBlockId<256 && topBlockId>255) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockWithLowIdAndTopBlock);

                                // back block id
                                bytes.Add((byte)backBlockId);

                                // top block id
                                ushort topId=topBlockId;
                                byte* bytesTopBlockId = (byte*)&topId;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);

                            } else {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockAndTopBlock);

                                // back block id
                                ushort backId=backBlockId;
                                byte* bytesBackBlockId = (byte*)&backId;
                                bytes.Add(bytesBackBlockId[0]);
                                bytes.Add(bytesBackBlockId[1]);

                                // top block id
                                ushort topId=topBlockId;
                                byte* bytesTopBlockId = (byte*)&topId;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);
                            }
                            return;

                        case SaveType.BackBlockAndTopBlockMultiple:
                            if (backBlockId<256 && topBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockWithLowIdAndTopBlockWithLowIdMultiple);

                                // back block id
                                bytes.Add((byte)backBlockId);

                                // top block id
                                bytes.Add((byte)topBlockId);

                            } else if (backBlockId>255 && topBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockAndTopBlockWithLowIdMultiple);

                                // back block id
                                ushort backId=backBlockId;
                                byte* bytesBackBlockId = (byte*)&backId;
                                bytes.Add(bytesBackBlockId[0]);
                                bytes.Add(bytesBackBlockId[1]);

                                // top block id
                                bytes.Add((byte)topBlockId);

                            } else if (backBlockId<256 && topBlockId>255) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockWithLowIdAndTopBlockMultiple);

                                // back block id
                                bytes.Add((byte)backBlockId);

                                // top block id
                                ushort topId=topBlockId;
                                byte* bytesTopBlockId = (byte*)&topId;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);

                            } else {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockAndTopBlockMultiple);

                                // back block id
                                ushort backId=backBlockId;
                                byte* bytesBackBlockId = (byte*)&backId;
                                bytes.Add(bytesBackBlockId[0]);
                                bytes.Add(bytesBackBlockId[1]);

                                // top block id
                                ushort topId=topBlockId;
                                byte* bytesTopBlockId = (byte*)&topId;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);
                            }

                            // Count
                            bytes.Add((byte)lastTypeCount);
                            return;

                        case SaveType.TopBlockMoreLoad:
                            if (topBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.TopBlockWithLowIdMoreLoad);

                                // Id
                                bytes.Add((byte)topBlockId);

                            } else {
                                // SaveType
                                bytes.Add((byte)SaveType.TopBlockMoreLoad);

                                // Id
                                ushort id=topBlockId;
                                byte* bytesTopBlockId = (byte*)&id;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);
                            }

                            // More info
                            bytes.AddRange(tmpBytes);
                            tmpBytes.Clear();
                            return;

                        case SaveType.TopBlockMoreLoadMultiple:
                            if (topBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.TopBlockWithLowIdMoreLoadMultiple);

                                // id
                                bytes.Add((byte)topBlockId);

                            } else {
                                // SaveType
                                bytes.Add((byte)SaveType.TopBlockMoreLoadMultiple);

                                // id
                                ushort id=topBlockId;
                                byte* bytesTopBlockId = (byte*)&id;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);
                            }

                            // Count
                            bytes.Add((byte)lastTypeCount);

                            // More info
                            bytes.AddRange(tmpBytes);
                            tmpBytes.Clear();
                            return;

                        case SaveType.BackBlockAndTopBlockMoreLoad:
                            if (topBlockId<256 && backBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockWithLowIdAndTopBlockWithLowIdMoreLoad);

                                // back block id
                                bytes.Add((byte)backBlockId);

                                // top block id
                                bytes.Add((byte)topBlockId);

                            } else if (topBlockId<256 && backBlockId>255) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockAndTopBlockWithLowIdMoreLoad);

                                // back block id
                                ushort backId=backBlockId;
                                byte* bytesBackBlockId = (byte*)&backId;
                                bytes.Add(bytesBackBlockId[0]);
                                bytes.Add(bytesBackBlockId[1]);

                                // top block id
                                bytes.Add((byte)topBlockId);

                            } else if (topBlockId>255 && backBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockWithLowIdAndTopBlockMoreLoad);

                                // back block id
                                bytes.Add((byte)backBlockId);

                                // top block id
                                ushort topId=topBlockId;
                                byte* bytesTopBlockId = (byte*)&topId;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);

                            } else {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockAndTopBlockMoreLoad);

                                // back block id
                                ushort backId=backBlockId;
                                byte* bytesBackBlockId = (byte*)&backId;
                                bytes.Add(bytesBackBlockId[0]);
                                bytes.Add(bytesBackBlockId[1]);

                                // top block id
                                ushort topId=topBlockId;
                                byte* bytesTopBlockId = (byte*)&topId;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);
                            }

                            // More info
                            bytes.AddRange(tmpBytes);
                            tmpBytes.Clear();
                            return;

                        case SaveType.BackBlockAndTopBlockMoreLoadMultiple:
                            if (topBlockId<256 && backBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockWithLowIdAndTopBlockWithLowIdMoreLoadMultiple);

                                // back block id
                                bytes.Add((byte)backBlockId);

                                // top block id
                                bytes.Add((byte)topBlockId);

                            } else if (topBlockId<256 && backBlockId>255) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockAndTopBlockWithLowIdMoreLoadMultiple);

                                // back block id
                                ushort backId=backBlockId;
                                byte* bytesBackBlockId = (byte*)&backId;
                                bytes.Add(bytesBackBlockId[0]);
                                bytes.Add(bytesBackBlockId[1]);

                                // top block id
                                bytes.Add((byte)topBlockId);

                            } else if (topBlockId>255 && backBlockId<256) {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockWithLowIdAndTopBlockMoreLoadMultiple);

                                // back block id
                                bytes.Add((byte)backBlockId);

                                // top block id
                                ushort topId=topBlockId;
                                byte* bytesTopBlockId = (byte*)&topId;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);

                            } else {
                                // SaveType
                                bytes.Add((byte)SaveType.BackBlockAndTopBlockMoreLoadMultiple);

                                // back block id
                                ushort backId=backBlockId;
                                byte* bytesBackBlockId = (byte*)&backId;
                                bytes.Add(bytesBackBlockId[0]);
                                bytes.Add(bytesBackBlockId[1]);

                                // top block id
                                ushort topId=topBlockId;
                                byte* bytesTopBlockId = (byte*)&topId;
                                bytes.Add(bytesTopBlockId[0]);
                                bytes.Add(bytesTopBlockId[1]);
                            }

                            // Count
                            bytes.Add((byte)lastTypeCount);

                            // More info
                            bytes.AddRange(tmpBytes);
                            tmpBytes.Clear();
                            return;
                    }
                }

                bytes.Add((byte)chunk.PlantsCount);
                if (chunk.PlantsCount>0) bytes.AddRange(chunk.Plants);

                bytes.Add((byte)chunk.MobsCount);
                if (chunk.MobsCount>0) bytes.AddRange(chunk.Mobs);

            }

            foreach (GenLiveObject lo in LiveObjects) SaveLiveObject(lo);

            File.WriteAllBytes(playedWorld+"\\"+name+".ter", bytes.ToArray());

            File.WriteAllText(playedWorld + @"\"+name+"Generated.txt", (generatePos-7).ToString());
            File.WriteAllBytes(playedWorld + @"\"+name+"LiveObjects.bin", bytesLiveObject.ToArray());
            world++;

            void SaveLiveObject(GenLiveObject lo) {
                    switch (lo) {
                        case GenTree tree:
                            // Basic info
                            bytesLiveObject.Add((byte)LiveObjectType.Tree);

                            bytesLiveObject.Add((byte)tree.Root.X);
                            bytesLiveObject.Add((byte)(tree.Root.X>>8));
                            bytesLiveObject.Add(tree.Root.Y);

                            // Wood
                            int countWood=tree.TitlesWood.Count;
                            bytesLiveObject.Add((byte)countWood);

                            for (int i=0; i<countWood; i++) {
                                UShortAndByte sab=tree.TitlesWood[i];
                                bytesLiveObject.Add((byte)sab.X);
                                bytesLiveObject.Add((byte)(sab.X>>8));
                                bytesLiveObject.Add(sab.Y);
                            }

                            // Leaves
                            int countLeaves=tree.TitlesLeaves.Count;
                            bytesLiveObject.Add((byte)countLeaves);

                            for (int i=0; i<countLeaves; i++) {
                                UShortAndByte sab=tree.TitlesLeaves[i];

                                bytesLiveObject.Add((byte)sab.X);
                                bytesLiveObject.Add((byte)(sab.X>>8));
                                bytesLiveObject.Add(sab.Y);
                            }
                            break;

                        case GenCactus cactus:
                            // Basic info
                            bytesLiveObject.Add((byte)LiveObjectType.Cactus);

                            bytesLiveObject.Add((byte)cactus.Root.X);
                            bytesLiveObject.Add((byte)(cactus.Root.X>>8));
                            bytesLiveObject.Add(cactus.Root.Y);

                            // Material
                            int count=cactus.Titles.Count;
                            bytesLiveObject.Add((byte)count);

                            for (int i=0; i<count; i++) {
                                UShortAndByte sab=cactus.Titles[i];

                                bytesLiveObject.Add((byte)sab.X);
                                bytesLiveObject.Add((byte)(sab.X>>8));
                                bytesLiveObject.Add(sab.Y);
                            }
                            break;
                    }

                }

            void SaveMachineTop(ushort i) {
                switch (i) {
                    case (ushort)BlockId.WaterBlock:
                        tmpBytes.Add(255);
                        return;

                    case (ushort)BlockId.WaterSalt:
                        tmpBytes.Add(255);
                        return;

                    //case (ushort)BlockId.OakWood:
                    //case (ushort)BlockId.OakLeaves:
                    //case (ushort)BlockId.SpruceLeaves:
                    //case (ushort)BlockId.SpruceWood:
                    //case (ushort)BlockId.PineLeaves:
                    //case (ushort)BlockId.PineWood:
                    //case (ushort)BlockId.LindenLeaves:
                    //case (ushort)BlockId.LindenWood:
                    //case (ushort)BlockId.AppleLeaves:
                    //case (ushort)BlockId.AppleLeavesWithApples:
                    //case (ushort)BlockId.AppleWood:
                    //case (ushort)BlockId.CherryLeaves:
                    //case (ushort)BlockId.CherryLeavesWithCherries:
                    //case (ushort)BlockId.CherryWood:
                    //case (ushort)BlockId.PlumLeaves:
                    //case (ushort)BlockId.PlumLeavesWithPlums:
                    //case (ushort)BlockId.PlumWood:
                    //case (ushort)BlockId.LemonWood:
                    //case (ushort)BlockId.LemonLeaves:
                    //case (ushort)BlockId.LemonLeavesWithLemons:
                    //case (ushort)BlockId.OrangeWood:
                    //case (ushort)BlockId.OrangeLeaves:
                    //case (ushort)BlockId.OrangeLeavesWithOranges:
                    //case (ushort)BlockId.WillowLeaves:
                    //case (ushort)BlockId.WillowWood:
                    //case (ushort)BlockId.MangroveLeaves:
                    //case (ushort)BlockId.MangroveWood:
                    //case (ushort)BlockId.EucalyptusLeaves:
                    //case (ushort)BlockId.EucalyptusWood:
                    //case (ushort)BlockId.OliveLeavesWithOlives:
                    //case (ushort)BlockId.OliveLeaves:
                    //case (ushort)BlockId.OliveWood:
                    //case (ushort)BlockId.RubberTreeLeaves:
                    //case (ushort)BlockId.RubberTreeWood:
                    //case (ushort)BlockId.AcaciaLeaves:
                    //case (ushort)BlockId.AcaciaWood:
                    //case (ushort)BlockId.KapokLeacesFlowering:
                    //case (ushort)BlockId.KapokLeacesFibre:
                    //case (ushort)BlockId.KapokLeaces:
                    //case (ushort)BlockId.KapokWood: {
                    //    uint num = (uint)((GenDataLiveObject)i).Object.IdNumber;
                    //    tmpBytes.Add((byte)num);
                    //    tmpBytes.Add((byte)(num>>8));
                    //    tmpBytes.Add((byte)(num>>16));
                    //}
                    //return;
                }
            }
        }

        #region Structures
        void Lake(ushort floor) {
            //if (pos-lastLakePos<9) return;

            //int len=4+FastRandom.Int4();
            //for (int xx=pos; xx<pos+len; xx++) {
            //    terrain.Add(new GChunk());
            //    GChunk chunk=terrain[xx];

            //    chunk.TopBlocks[terrainHeight]=(ushort)BlockId.WaterBlock;
            //    chunk.SolidBlocks[terrainHeight+1]=floor;

            //    chunk.LightPos=terrainHeight;

            //    // Lithosphere
            //    if (FastRandom.Bool()) {
            //        chunk.SolidBlocks[terrainHeight+2]=(ushort)BlockId.Cobblestone;
            //        GenerateUnderSurface(chunk, terrainHeight+3);
            //    } else GenerateUnderSurface(chunk, terrainHeight+2);
            //}
            //pos+=len;
            //terrainChange+=2;
            //lastLakePos=pos;
             if (pos-lastLakePos<9) return;

            int len=pos+4+FastRandom.Int4();
            for (; pos<len; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk=terrain[pos];

                chunk.TopBlocks[terrainHeight]=(ushort)BlockId.WaterBlock;
                chunk.SolidBlocks[terrainHeight+1]=floor;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+2]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+3);
                } else GenerateUnderSurface(chunk, terrainHeight+2);
            }
          //  pos+=len;
            terrainChange+=2;
            lastLakePos=pos;
        }

        void LakeDirt() {
            if (pos-lastLakePos<9) return;

            int len=pos+4+FastRandom.Int4();

            for (; pos<len; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk=terrain[pos];

                chunk.TopBlocks[terrainHeight]=(ushort)BlockId.WaterBlock;
                chunk.SolidBlocks[terrainHeight+1]=(ushort)BlockId.Dirt;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+2]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+3);
                } else GenerateUnderSurface(chunk, terrainHeight+2);
            }
            terrainChange+=2;
            lastLakePos=pos;
        }

        void LakeSand() {
            if (pos-lastLakePos<9) return;

            int len=pos+4+FastRandom.Int4();

            for (; pos<len; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk=terrain[pos];

                chunk.TopBlocks[terrainHeight]=(ushort)BlockId.WaterBlock;
                chunk.SolidBlocks[terrainHeight+1]=(ushort)BlockId.Sand;

                chunk.LightPosFull=terrainHeight;
                if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+2]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+3);
                } else GenerateUnderSurface(chunk, terrainHeight+2);
            }
            terrainChange+=2;
            lastLakePos=pos;
        }

        void LakeGravel() {
            if (pos-lastLakePos<9) return;

            int len=pos+4+FastRandom.Int4();

            for (; pos<len; pos++) {
                terrain.Add(new GChunk());
                GChunk chunk=terrain[pos];

                chunk.TopBlocks[terrainHeight]=(ushort)BlockId.WaterBlock;
                chunk.SolidBlocks[terrainHeight+1]=(ushort)BlockId.Gravel;

                chunk.LightPosFull=terrainHeight;
               if (!chunk.SetLightPosHalf) {
                    if (terrainHeight>53) chunk.LightPosHalf=53; else chunk.LightPosHalf=terrainHeight;
                }

                // Lithosphere
                if (FastRandom.Bool()) {
                    chunk.SolidBlocks[terrainHeight+2]=(ushort)BlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+3);
                } else GenerateUnderSurface(chunk, terrainHeight+2);
            }
            terrainChange+=2;
            lastLakePos=pos;
        }

        //void LakeSalt(BlockId floor) {
        //    if (pos-lastLakePos<9) return;

        //    int len=4+FastRandom.Int4();
        //    for (int xx=pos; xx<pos+len; xx++) {

        //        terrain.Add(new GChunk());
        //        GChunk chunk=terrain[xx];

        //        /*terrain[xx]*/chunk.TopBlocks[terrainHeight]=(ushort)BlockId.WaterSalt;
        //        /*terrain[xx]*/chunk.SolidBlocks[terrainHeight+1]=(byte)floor;

        //        /*terrain[xx]*/chunk.LightPos=terrainHeight;

        //        // Lithosphere
        //        if (FastRandom.Bool()) {
        //            chunk.SolidBlocks[terrainHeight+2]=(ushort)BlockId.Cobblestone;
        //            GenerateUnderSurface(chunk, terrainHeight+1+2);
        //        } else GenerateUnderSurface(chunk, terrainHeight+2);
        //    }
        //    pos+=len;
        //    terrainChange+=2;
        //    lastLakePos=pos;
        //}

        void ClayPlace(int x, int y) {
            if (y>120) return;
            if (x<5) return;
            if (y<5) return;

            for (int xx=x-1; xx<x+1; xx++) ConvertToClay(xx,y);
            for (int xx=x-2; xx<x+2; xx++) ConvertToClay(xx,y+1);
            for (int xx=x-3; xx<x+3; xx++) ConvertToClay(xx,y+2);
            for (int xx=x-2; xx<x+2; xx++) ConvertToClay(xx,y+3);
            for (int xx=x-1; xx<x+1; xx++) ConvertToClay(xx,y+4);
            return;
        }

        void ConvertToClay(int x, int y) {
            ushort[] chunk_SolidBlocks=terrain[x].SolidBlocks;
            if (chunk_SolidBlocks[y]==0) return;
            switch ((BlockId)chunk_SolidBlocks[y]) {
                case BlockId.Dirt:
                    chunk_SolidBlocks[y]=(ushort)BlockId.Clay;
                    return;

                case BlockId.GrassBlockForest:
                    chunk_SolidBlocks[y]=(ushort)BlockId.GrassBlockClay;
                    return;

                case BlockId.GrassBlockHills:
                    chunk_SolidBlocks[y]=(ushort)BlockId.GrassBlockClay;
                    return;

                case BlockId.GrassBlockJungle:
                    chunk_SolidBlocks[y]=(ushort)BlockId.GrassBlockClay;
                    return;

                case BlockId.GrassBlockPlains:
                    chunk_SolidBlocks[y]=(ushort)BlockId.GrassBlockClay;
                    return;

                case BlockId.GrassDesert:
                    chunk_SolidBlocks[y]=(ushort)BlockId.GrassBlockClay;
                    return;
            }
        }

        void TreeMangrove(int x, int y) {
            treeChange=1+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-1);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1];

            SetWood(chunkX, x, y-1, (ushort)BlockId.MangroveWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.MangroveWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.MangroveWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.MangroveWood, tree);

            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-4, (ushort)BlockId.MangroveWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-3, (ushort)BlockId.MangroveWood, tree);

            SetLeave(chunkXP1, x+1, y-3, (ushort)BlockId.MangroveLeaves, tree);
            SetLeave(chunkXM1, x-1, y-3, (ushort)BlockId.MangroveLeaves, tree);
            SetLeave(chunkX,   x  , y-3, (ushort)BlockId.MangroveLeaves, tree);
            SetLeave(chunkX,   x  , y-4, (ushort)BlockId.MangroveLeaves, tree);
            SetLeave(chunkXP1, x+1, y-4, (ushort)BlockId.MangroveLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, (ushort)BlockId.MangroveLeaves, tree);
            SetLeave(chunkX,   x  , y-5, (ushort)BlockId.MangroveLeaves, tree);
        }

        void TreeWillow(int x, int y) {
            treeChange=2+FastRandom.Int2();

            GenTree tree=new GenTree(x, y);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX, x, y-1, (ushort)BlockId.WillowWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.WillowWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.WillowWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.WillowWood, tree);
            if (FastRandom.Bool()) SetWood(chunkX, x, y-4, (ushort)BlockId.WillowWood, tree);

            switch (FastRandom.Int3()){
                case 0:
                    SetWood(chunkXM1, x-1, y-3, (ushort)BlockId.WillowWood, tree);

                    SetLeave(chunkXM1, x-1, y-2, (ushort)BlockId.WillowLeaves, tree);
                    SetLeave(chunkXM2, x-2, y-1, (ushort)BlockId.WillowLeaves, tree);
                    break;

                case 1:
                    SetWood(chunkXM1, x-1, y-3, (ushort)BlockId.WillowWood, tree);

                    SetLeave(chunkXM1, x-1, y-2, (ushort)BlockId.WillowLeaves, tree);
                    SetLeave(chunkXM2, x-2, y-1, (ushort)BlockId.WillowLeaves, tree);
                    break;

                case 2:
                    SetWood(chunkXM1, x-1, y-3,(ushort)BlockId.WillowWood, tree);
                    SetWood(chunkXP1, x+1, y-3,(ushort)BlockId.WillowWood, tree);
                    break;
            }

            SetLeave(chunkXP2, x+2, y-2, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkX,   x-2, y-2, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkXP1, x+1, y-3, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkXM1, x-1, y-3, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkX,   x,   y-3, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkXP2, x+2, y-3, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkXM2, x-2, y-3, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkX,   x,   y-4, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkXP1, x+1, y-4, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkX,   x-2, y-4, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkXP2, x+2, y-4, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkX,   x,   y-5, (ushort)BlockId.WillowLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, (ushort)BlockId.WillowLeaves, tree);
        }

        void TreeEucalyptus(int x, int y) {
            treeChange=3+FastRandom.Int2();
            GenTree tree=new GenTree(x, y-1);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2],
                chunkXP3 = terrain[x+3],
                chunkXM3 = terrain[x-3];

            SetWood(chunkX, x, y-1, (ushort)BlockId.EucalyptusWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.EucalyptusWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.EucalyptusWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.EucalyptusWood, tree);
            SetWood(chunkX, x, y-5, (ushort)BlockId.EucalyptusWood, tree);
            SetWood(chunkX, x, y-6, (ushort)BlockId.EucalyptusWood, tree);

            if (FastRandom.Bool()) {
                SetWood(chunkXM1, x-1, y-3, (ushort)BlockId.EucalyptusWood, tree);
                SetWood(chunkXM2, x-2, y-4, (ushort)BlockId.EucalyptusWood, tree);
                SetWood(chunkXM2, x-2, y-5, (ushort)BlockId.EucalyptusWood, tree);

                SetLeave(chunkXM3, x-3, y-4,(ushort)BlockId.EucalyptusLeaves, tree);
            } else {
                SetWood(chunkXM1, x-1, y-4, (ushort)BlockId.EucalyptusWood, tree);
                SetWood(chunkXM2, x-2, y-5, (ushort)BlockId.EucalyptusWood, tree);
            }

            if (FastRandom.Bool()) {
                SetWood(chunkXP1, x+1, y-3, (ushort)BlockId.EucalyptusWood, tree);
                SetWood(chunkXP2, x+2, y-4, (ushort)BlockId.EucalyptusWood, tree);
                SetWood(chunkXP2, x+2, y-5, (ushort)BlockId.EucalyptusWood, tree);

                SetLeave(chunkXP3, x+3, y-4, (ushort)BlockId.EucalyptusLeaves, tree);
            } else {
                SetWood(chunkXP1, x+1, y-4, (ushort)BlockId.EucalyptusWood, tree);
                SetWood(chunkXP2, x+2, y-5, (ushort)BlockId.EucalyptusWood, tree);
            }


            SetLeave(chunkXP2, x+2, y-4, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXM2, x-2, y-4, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkX,   x  , y-5, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXM2, x-2, y-5, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXP3, x+3, y-5, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXM3, x-3, y-5, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkX,   x  , y-6, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXM1, x-1, y-6, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXM2, x-2, y-6, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXP2, x+2, y-6, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXM1, x-1, y-7, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkX,   x  , y-7, (ushort)BlockId.EucalyptusLeaves, tree);
            SetLeave(chunkXP1, x+1, y-7, (ushort)BlockId.EucalyptusLeaves, tree);
        }

        void TreeOlive(int x, int y) {
            treeChange=2+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-1);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX, x, y-1, (ushort)BlockId.OliveWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.OliveWood, tree);

            if (FastRandom.Bool()) {
                SetWood(chunkX,   x   ,y-3,(ushort)BlockId.OliveWood, tree);
                SetWood(chunkXM1, x-1, y-3, (ushort)BlockId.OliveWood, tree);
                SetWood(chunkXM1, x-1, y-4, (ushort)BlockId.OliveWood, tree);
                SetWood(chunkXM1, x-1, y-5, (ushort)BlockId.OliveWood, tree);
                SetWood(chunkXP1, x+1, y-4, (ushort)BlockId.OliveWood, tree);
            } else {
                SetWood(chunkXM1, x-1, y-3, (ushort)BlockId.OliveWood, tree);
                SetWood(chunkXP1, x+1, y-3, (ushort)BlockId.OliveWood, tree);
                SetWood(chunkXM1, x-1, y-4, (ushort)BlockId.OliveWood, tree);
            }

            SetLeave(chunkXM1, x-1, y-3, FastRandom.Bool() ? (ushort)BlockId.OliveLeaves : (ushort)BlockId.OliveLeavesWithOlives, tree);
            SetLeave(chunkX,   x  , y-3, (ushort)BlockId.OliveLeaves, tree);
            SetLeave(chunkXP1, x+1, y-3, (ushort)BlockId.OliveLeaves, tree);
            SetLeave(chunkXP1, x+1, y-4, (ushort)BlockId.OliveLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, FastRandom.Bool() ? (ushort)BlockId.OliveLeaves : (ushort)BlockId.OliveLeavesWithOlives, tree);
            SetLeave(chunkX,   x  , y-4, (ushort)BlockId.OliveLeaves, tree);
            SetLeave(chunkXP2, x+2, y-4, (ushort)BlockId.OliveLeaves, tree);
            SetLeave(chunkXM2, x-2, y-4, FastRandom.Bool() ? (ushort)BlockId.OliveLeaves : (ushort)BlockId.OliveLeavesWithOlives, tree);
            SetLeave(chunkX,   x  , y-5, (ushort)BlockId.OliveLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, (ushort)BlockId.OliveLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, FastRandom.Bool() ? (ushort)BlockId.OliveLeaves : (ushort)BlockId.OliveLeavesWithOlives, tree);
            SetLeave(chunkXM2, x-2, y-5, (ushort)BlockId.OliveLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5, FastRandom.Bool() ? (ushort)BlockId.OliveLeaves : (ushort)BlockId.OliveLeavesWithOlives, tree);
            SetLeave(chunkXM1, x-1, y-6, (ushort)BlockId.OliveLeaves, tree);
            SetLeave(chunkX,   x  , y-6, FastRandom.Bool() ? (ushort)BlockId.OliveLeaves : (ushort)BlockId.OliveLeavesWithOlives, tree);
            SetLeave(chunkXP1, x+1, y-6, (ushort)BlockId.OliveLeaves, tree);
        }

        void TreeApple(int x, int y) {
            treeChange=2+FastRandom.Int2();

            GenTree tree=new(x, y-1);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX, x,   y-1, (ushort)BlockId.AppleWood, tree);
            SetWood(chunkX, x,   y-2, (ushort)BlockId.AppleWood, tree);
            SetWood(chunkX, x,   y-3, (ushort)BlockId.AppleWood, tree);
            SetWood(chunkXP1, x+1, y-3, (ushort)BlockId.AppleWood, tree);
            SetWood(chunkX, x,   y-4, (ushort)BlockId.AppleWood, tree);
            SetWood(chunkXP1, x+1, y-5, (ushort)BlockId.AppleWood, tree);
            SetWood(chunkXM1, x-1, y-5, (ushort)BlockId.AppleWood, tree);
            SetWood(chunkXP1, x+1, y-6, (ushort)BlockId.AppleWood, tree);

            SetLeave(chunkXP2, x+2, y-3, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.AppleLeaves : (ushort)BlockId.AppleLeavesWithApples, tree);
            SetLeave(chunkXM2, x-2, y-3, (ushort)BlockId.AppleLeaves, tree);
            SetLeave(chunkXP1, x+1, y-3, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.AppleLeaves : (ushort)BlockId.AppleLeavesWithApples, tree);
            SetLeave(chunkXM1, x-1, y-3, (ushort)BlockId.AppleLeaves, tree);
            SetLeave(chunkX,   x  , y-3, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.AppleLeaves : (ushort)BlockId.AppleLeavesWithApples, tree);
            SetLeave(chunkXP2, x+2, y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.AppleLeaves : (ushort)BlockId.AppleLeavesWithApples, tree);
            SetLeave(chunkXM2, x-2, y-4, (ushort)BlockId.AppleLeaves, tree);
            SetLeave(chunkXP1, x+1, y-4, FastRandom.Bool_33_333Percent()? (ushort)BlockId.AppleLeaves : (ushort)BlockId.AppleLeavesWithApples, tree);
            SetLeave(chunkXM1, x-1, y-4, (ushort)BlockId.AppleLeaves, tree);
            SetLeave(chunkX,   x  , y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.AppleLeaves : (ushort)BlockId.AppleLeavesWithApples, tree);
            SetLeave(chunkXP1, x+1, y-5, (ushort)BlockId.AppleLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.AppleLeaves : (ushort)BlockId.AppleLeavesWithApples, tree);
            SetLeave(chunkX,   x  , y-5, (ushort)BlockId.AppleLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.AppleLeaves : (ushort)BlockId.AppleLeavesWithApples, tree);
            SetLeave(chunkXM1, x-1, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.AppleLeaves : (ushort)BlockId.AppleLeavesWithApples, tree);
            SetLeave(chunkX,   x  , y-6, (ushort)BlockId.AppleLeaves, tree);
        }

        void TreeOrange(int x, int y) {
            treeChange=2+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-1);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX, x, y-1, (ushort)BlockId.OrangeWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.OrangeWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.OrangeWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.OrangeWood, tree);
            SetWood(chunkX, x, y-5, (ushort)BlockId.OrangeWood, tree);
            SetWood(chunkX, x, y-6, (ushort)BlockId.OrangeWood, tree);

            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-4, (ushort)BlockId.OrangeWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-5, (ushort)BlockId.OrangeWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-7, (ushort)BlockId.OrangeWood, tree);

            if (FastRandom.Bool()) {
                SetWood(chunkXP1, x+1, y-7, (ushort)BlockId.OrangeWood, tree);
                if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-8, (ushort)BlockId.OrangeWood, tree);
            }

            SetLeave(chunkXP1, x+1, y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkX,   x  , y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkX,   x  , y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5, (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXM2, x-2, y-5, (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkX,   x  , y-6, (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXP2, x+2, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXM2, x-2, y-6, (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkX,   x  , y-7, (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXP2, x+2, y-7, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXM2, x-2, y-7, (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXP1, x+1, y-7, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-7, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkX,   x  , y-8, (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXP2, x+2, y-8, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXM2, x-2, y-8, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXP1, x+1, y-8, (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-8, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXP1, x+1, y-9, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-9, (ushort)BlockId.OrangeLeaves, tree);
            SetLeave(chunkX,   x  , y-9, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.OrangeLeavesWithOranges : (ushort)BlockId.OrangeLeaves, tree);
        }

        void TreeLemon(int x, int y) {
            treeChange=2+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-1);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX, x, y-1, (ushort)BlockId.LemonWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.LemonWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.LemonWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.LemonWood, tree);

            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-4, (ushort)BlockId.LemonWood, tree);
            else SetWood(chunkXP1, x+1, y-5, (ushort)BlockId.LemonWood, tree);

            SetLeave(chunkXP1, x+1, y-3, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXM1, x-1, y-3, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkX,   x  , y-3, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkX,   x  , y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXP2, x+2, y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXM2, x-2, y-4, (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXP1, x+1, y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkX,   x  , y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXM2, x-2, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkX,   x  , y-6, (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
            SetLeave(chunkXM1, x-1, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.LemonLeavesWithLemons : (ushort)BlockId.LemonLeaves, tree);
        }

        void TreeCherry(int x, int y) {
            treeChange=2+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-1);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX,   x,   y-1, (ushort)BlockId.CherryWood, tree);
            SetWood(chunkX,   x,   y-2, (ushort)BlockId.CherryWood, tree);
            SetWood(chunkX,   x,   y-3, (ushort)BlockId.CherryWood, tree);
            SetWood(chunkXM1, x-1, y-3, (ushort)BlockId.CherryWood, tree);
            SetWood(chunkX,   x,   y-4, (ushort)BlockId.CherryWood, tree);
            SetWood(chunkXM1, x-1, y-5, (ushort)BlockId.CherryWood, tree);
            SetWood(chunkXP1, x+1, y-5, (ushort)BlockId.CherryWood, tree);
            SetWood(chunkXM1, x-1, y-6, (ushort)BlockId.CherryWood, tree);

            SetLeave(chunkXP1, x+1, y-3, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXM1, x-1, y-3, (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkX,   x  , y-3, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXP2, x+2, y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXM2, x-2, y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXP1, x+1, y-4, (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkX,   x  , y-4, (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXM2, x-2, y-5, (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkX,   x  , y-5, (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXM1, x-1, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkX,   x  , y-6, (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXP1, x+1, y-7, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkXM1, x-1, y-7, (ushort)BlockId.CherryLeaves, tree);
            SetLeave(chunkX,   x  , y-7, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.CherryLeavesWithCherries : (ushort)BlockId.CherryLeaves, tree);
        }

        void TreePlum(int x, int y) {
            treeChange=2+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-1);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX,   x,   y-1, (ushort)BlockId.PlumWood, tree);
            SetWood(chunkX,   x,   y-2, (ushort)BlockId.PlumWood, tree);
            SetWood(chunkX,   x,   y-3, (ushort)BlockId.PlumWood, tree);
            SetWood(chunkXM1, x-1, y-3, (ushort)BlockId.PlumWood, tree);
            SetWood(chunkX,   x,   y-4, (ushort)BlockId.PlumWood, tree);
            SetWood(chunkXM1, x-1, y-5, (ushort)BlockId.PlumWood, tree);
            SetWood(chunkXP1, x+1, y-5, (ushort)BlockId.PlumWood, tree);
            SetWood(chunkXM1, x-1, y-6, (ushort)BlockId.PlumWood, tree);

            SetLeave(chunkXP1, x+1, y-3, (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXM1, x-1, y-3, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.PlumLeavesWithPlums : (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkX,   x  , y-3, (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXP2, x+2, y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.PlumLeavesWithPlums : (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXM2, x-2, y-4, (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXP1, x+1, y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.PlumLeavesWithPlums : (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.PlumLeavesWithPlums : (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkX,   x  , y-4, (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.PlumLeavesWithPlums : (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXM2, x-2, y-5, (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.PlumLeavesWithPlums : (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.PlumLeavesWithPlums : (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkX,   x  , y-5, (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.PlumLeavesWithPlums : (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkXM1, x-1, y-6, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.PlumLeavesWithPlums : (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkX,   x  , y-6, (ushort)BlockId.PlumLeaves, tree);
            SetLeave(chunkX,   x  , y-7, FastRandom.Bool_33_333Percent() ? (ushort)BlockId.PlumLeavesWithPlums : (ushort)BlockId.PlumLeaves, tree);
        }

        void TreeOakMedium(int x, int y) {
            treeChange=2+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-2);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX, x, y-1, (ushort)BlockId.OakWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.OakWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.OakWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.OakWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-4, (ushort)BlockId.OakWood, tree);
            SetWood(chunkX, x,   y-6, (ushort)BlockId.OakWood, tree);
            SetWood(chunkX, x,   y-5, (ushort)BlockId.OakWood, tree);
            SetWood(chunkXM1, x-1, y-7, (ushort)BlockId.OakWood, tree);
            SetWood(chunkXP1, x+1, y-7, (ushort)BlockId.OakWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-8, (ushort)BlockId.OakWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-8, (ushort)BlockId.OakWood, tree);
            if (FastRandom.Bool_20Percent()) SetWood(chunkXM2, x-2, y-7, (ushort)BlockId.OakWood, tree);

            SetLeave(chunkXP1, x+1, y-4, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkX,   x  , y-4, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkX,   x  , y-5, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM2, x-2, y-5, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkX,   x  , y-6, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM1, x-1, y-6, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXP2, x+2, y-6, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM2, x-2, y-6, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXP1, x+1, y-7, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkX,   x  , y-7, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM1, x-1, y-7, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXP2, x+2, y-7, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM2, x-2, y-7, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXP1, x+1, y-8, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkX,   x  , y-8, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM1, x-1, y-8, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM2, x-2, y-8, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXP2, x+2, y-8, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXP1, x+1, y-9, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkX,   x  , y-9, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM1, x-1, y-9, (ushort)BlockId.OakLeaves, tree);
        }

        void TreePine(int x, int y) {
            treeChange=3+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-3);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX, x, y-1, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-5, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-6, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-7, (ushort)BlockId.PineWood, tree);
            if (FastRandom.Bool()) SetWood(chunkX, x, y-8, (ushort)BlockId.PineWood, tree);

            SetLeave(chunkXP2, x+2, y-6 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXM2, x-2, y-6 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXP1, x+1, y-7 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkX,   x  , y-7 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXM1, x-1, y-7 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXP2, x+2, y-8 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkX,   x  , y-8 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXM2, x-2, y-8 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkX,   x  , y-9 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXM1, x-1, y-10, (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXP1, x+1, y-10, (ushort)BlockId.PineLeaves, tree);
        }

        void TreePineJunle(int x, int y) {
            treeChange=3+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-3);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX, x, y-1, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-5, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-6, (ushort)BlockId.PineWood, tree);
            SetWood(chunkX, x, y-7, (ushort)BlockId.PineWood, tree);
            if (FastRandom.Bool()) SetWood(chunkX, x, y-8, (ushort)BlockId.PineWood, tree);

            SetLeave(chunkXP2, x+2, y-6 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXM2, x-2, y-6 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXP1, x+1, y-7 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkX,   x  , y-7 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXM1, x-1, y-7 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkX,   x  , y-8 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXP2, x+2, y-8 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkX,   x  , y-8 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXM2, x-2, y-8 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkX,   x  , y-9 , (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXM1, x-1, y-10, (ushort)BlockId.PineLeaves, tree);
            SetLeave(chunkXP1, x+1, y-10, (ushort)BlockId.PineLeaves, tree);

            //if (FastRandom.Int(15)==1) chunkX.AddParrot((byte)(y-10));
            //if (FastRandom.Int(15)==1) chunkXP2.AddParrot((byte)(y-8));
            //if (FastRandom.Int(15)==1) chunkXM1.AddParrot((byte)(y-10));
        }

        void TreeKapok(int x, int y) {
            treeChange=2+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-12);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2],
                chunkXP3 = terrain[x+3],
                chunkXM3 = terrain[x-3];

            //SetWood(x,   y, (ushort)BlockId.KapokWood, tree);

            SetWood(chunkXP1, x+1, y, (ushort)BlockId.KapokWood, tree);
            SetWood(chunkXM1, x-1, y, (ushort)BlockId.KapokWood, tree);

            SetWood(chunkX, x,   y-1, (ushort)BlockId.KapokWood, tree);
            SetWood(chunkXP1, x+1, y-1, (ushort)BlockId.KapokWood, tree);
            SetWood(chunkXM1, x-1, y-1, (ushort)BlockId.KapokWood, tree);

            if (FastRandom.Bool()) {
                SetWood(chunkXP1, x+1, y-2, (ushort)BlockId.KapokWood, tree);
                SetWood(chunkXM1, x-1, y-2, (ushort)BlockId.KapokWood, tree);
            }
            SetWood(chunkX, x, y-2,  (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-3,  (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-4,  (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-5,  (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-6,  (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-7,  (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-8,  (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-9,  (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-10, (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-11, (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-12, (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-13, (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-14, (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-15, (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-16, (ushort)BlockId.KapokWood, tree);
            SetWood(chunkX, x, y-17, (ushort)BlockId.KapokWood, tree);

            if (FastRandom.Bool()) {
                SetWood(chunkXM1, x-1, y-14, (ushort)BlockId.KapokWood, tree);
                SetWood(chunkXM2, x-2, y-15, (ushort)BlockId.KapokWood, tree);
                SetWood(chunkXP1, x+1, y-13, (ushort)BlockId.KapokWood, tree);
                SetWood(chunkXP1, x+1, y-14, (ushort)BlockId.KapokWood, tree);
                SetWood(chunkXP2, x+2, y-15, (ushort)BlockId.KapokWood, tree);
            } else {
                SetWood(chunkXP1, x+1, y-14, (ushort)BlockId.KapokWood, tree);
                SetWood(chunkXP2, x+2, y-15, (ushort)BlockId.KapokWood, tree);
                SetWood(chunkXM1, x-1, y-13, (ushort)BlockId.KapokWood, tree);
                SetWood(chunkXM1, x-1, y-14, (ushort)BlockId.KapokWood, tree);
                SetWood(chunkXM2, x-2, y-15, (ushort)BlockId.KapokWood, tree);
            }

            SetLeave(chunkXM3, x-3, y-15, FastRandom.Bool() ? (ushort)BlockId.KapokLeacesFlowering: (ushort)BlockId.KapokLeacesFibre, tree);
            SetLeave(chunkXM2, x-2, y-15, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXM1, x-1, y-15, FastRandom.Bool() ? (ushort)BlockId.KapokLeaves: (ushort)BlockId.KapokLeacesFlowering, tree);
            SetLeave(chunkXP1, x+1, y-15, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXP2, x+2, y-15, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXP3, x+3, y-15, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXM3, x-3, y-16, FastRandom.Bool() ? (ushort)BlockId.KapokLeacesFlowering: (ushort)BlockId.KapokLeacesFibre, tree);
            SetLeave(chunkXM2, x-2, y-16, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXM1, x-1, y-16, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkX,   x  , y-16, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXP1, x+1, y-16, FastRandom.Bool() ? (ushort)BlockId.KapokLeaves: (ushort)BlockId.KapokLeacesFlowering, tree);
            SetLeave(chunkXP2, x+2, y-16, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXP3, x+3, y-16, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXP3, x+3, y-17, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXP2, x+2, y-17, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXP1, x+1, y-17, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkX,   x  , y-17, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXM1, x-1, y-17, FastRandom.Bool() ? (ushort)BlockId.KapokLeaves: (ushort)BlockId.KapokLeacesFibre, tree);
            SetLeave(chunkXM2, x-2, y-17, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXP3, x+3, y-17, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkX,   x  , y-18, FastRandom.Bool() ? (ushort)BlockId.KapokLeaves: (ushort)BlockId.KapokLeacesFlowering, tree);
            SetLeave(chunkXM1, x-1, y-18, (ushort)BlockId.KapokLeaves, tree);
            SetLeave(chunkXP1, x+1, y-18, FastRandom.Bool() ? (ushort)BlockId.KapokLeaves: (ushort)BlockId.KapokLeacesFibre, tree);

            if (FastRandom.Int(15)==1) chunkXM3.AddParrot((byte)(y-17));
            if (FastRandom.Int(15)==1) chunkXM2.AddParrot((byte)(y-17));
            if (FastRandom.Int(15)==1) chunkXM1.AddParrot((byte)(y-18));
            if (FastRandom.Int(15)==1) chunkX.AddParrot((byte)(y-18));
            if (FastRandom.Int(15)==1) chunkXP1.AddParrot((byte)(y-18));
            if (FastRandom.Int(15)==1) chunkXP2.AddParrot((byte)(y-17));
            if (FastRandom.Int(15)==1) chunkXP3.AddParrot((byte)(y-17));
        }

        void TreeSpruceBig(int x,int y) {
            treeChange=3+FastRandom.Int2();

            GenTree tree= new GenTree(x, y-2);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

           // SetWood(x, y,   (ushort)BlockId.SpruceWood, tree);
            SetWood(chunkX, x, y-1, (ushort)BlockId.SpruceWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.SpruceWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.SpruceWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.SpruceWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-4, (ushort)BlockId.SpruceWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-4, (ushort)BlockId.SpruceWood, tree);
            SetWood(chunkX, x, y-5, (ushort)BlockId.SpruceWood, tree);
            SetWood(chunkX, x, y-6, (ushort)BlockId.SpruceWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-6, (ushort)BlockId.SpruceWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-6, (ushort)BlockId.SpruceWood, tree);
            SetWood(chunkX, x, y-7, (ushort)BlockId.SpruceWood, tree);
            SetWood(chunkX, x, y-8, (ushort)BlockId.SpruceWood, tree);

            SetLeave(chunkXP2, x+2, y-3, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXP1, x+1, y-3, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x  , y-3, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXM1, x-1, y-3, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXM2, x-2, y-3, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXP2, x+2, y-4, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXP1, x+1, y-4, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x  , y-4, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXM2, x-2, y-4, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXM2, x-2, y-5, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x  , y-5, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x  , y-6, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXM1, x-1, y-6, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x  , y-7, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXP1, x+1, y-7, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXM1, x-1, y-7, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXP1, x+1, y-8, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x  , y-8, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXM1, x-1, y-8, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x  , y-9, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x  , y-10,(ushort)BlockId.SpruceLeaves, tree);
        }

        void TreeLinden(int x, int y) {
            treeChange=3+FastRandom.Int2();

            GenTree tree=new GenTree(x, y);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX, x, y-1, (ushort)BlockId.LindenWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.LindenWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.LindenWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.LindenWood, tree);
            SetWood(chunkX, x, y-5, (ushort)BlockId.LindenWood, tree);

            if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-4, (ushort)BlockId.LindenWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-4, (ushort)BlockId.LindenWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-5, (ushort)BlockId.LindenWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-5, (ushort)BlockId.LindenWood, tree);

            SetWood(chunkX, x, y-6, (ushort)BlockId.LindenWood, tree);
            SetWood(chunkX, x, y-7, (ushort)BlockId.LindenWood, tree);
            SetWood(chunkX, x, y-8, (ushort)BlockId.LindenWood, tree);
            SetWood(chunkXM2, x-2, y-6, (ushort)BlockId.LindenWood, tree);

            SetLeave(chunkXP1, x+1, y-4, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkX,   x  , y-4, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkX,   x  , y-5, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXM2, x-2, y-5, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkX,   x  , y-6, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXM1, x-1, y-6, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXP2, x+2, y-6, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXM2, x-2, y-6, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXP1, x+1, y-7, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkX,   x  , y-7, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXM1, x-1, y-7, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXP2, x+2, y-7, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXM2, x-2, y-7, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXP1, x+1, y-8, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkX,   x  , y-8, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXM1, x-1, y-8, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXP1, x+1, y-9, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkX,   x  , y-9, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkXM1, x-1, y-9, (ushort)BlockId.LindenLeaves, tree);
            SetLeave(chunkX,   x  , y-10,(ushort)BlockId.LindenLeaves, tree);
        }

        void TreeRubber(int x, int y) {
            treeChange=3+FastRandom.Int2();

            GenTree tree=new GenTree(x, y-2);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2];

            SetWood(chunkX, x, y-1, (ushort)BlockId.RubberTreeWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.RubberTreeWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.RubberTreeWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.RubberTreeWood, tree);
            SetWood(chunkX, x, y-5, (ushort)BlockId.RubberTreeWood, tree);

            if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-4, (ushort)BlockId.RubberTreeWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-4, (ushort)BlockId.RubberTreeWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXM1, x-1, y-5, (ushort)BlockId.RubberTreeWood, tree);
            if (FastRandom.Bool()) SetWood(chunkXP1, x+1, y-5, (ushort)BlockId.RubberTreeWood, tree);

            SetWood(chunkX, x,   y-6, (ushort)BlockId.RubberTreeWood, tree);
            SetWood(chunkX, x,   y-7, (ushort)BlockId.RubberTreeWood, tree);
            SetWood(chunkX, x,   y-8, (ushort)BlockId.RubberTreeWood, tree);
            SetWood(chunkXM2, x-2, y-6, (ushort)BlockId.RubberTreeWood, tree);

            SetLeave(chunkXP1, x+1, y-4,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkX,   x  , y-4,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkX,   x  , y-5,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXM2, x-2, y-5,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkX,   x  , y-6,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-6,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXP2, x+2, y-6,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXM2, x-2, y-6,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXP1, x+1, y-7,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkX,   x  , y-7,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-7,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXP2, x+2, y-7,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXM2, x-2, y-7,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXP1, x+1, y-8,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkX,   x  , y-8,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-8,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXP1, x+1, y-9,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkX,   x  , y-9,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkXM1, x-1, y-9,  (ushort)BlockId.RubberTreeLeaves, tree);
            SetLeave(chunkX,   x  , y-10, (ushort)BlockId.RubberTreeLeaves, tree);
        }

        void TreeOakLittle(int x, int y) {
            treeChange=1+FastRandom.Int2();

            GenTree tree = new GenTree(x, y);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1];

            SetWood(chunkX, x, y-1, (ushort)BlockId.OakWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.OakWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.OakWood, tree);

            SetLeave(chunkXP1, x+1, y-3, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkX,   x,   y-3, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM1, x-1, y-3, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXP1, x+1, y-4, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkX,   x,   y-4, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkXM1, x-1, y-4, (ushort)BlockId.OakLeaves, tree);
            SetLeave(chunkX,   x,   y-5, (ushort)BlockId.OakLeaves, tree);
        }

        void TreeSpruceLittle(int x, int y) {
            treeChange=1+FastRandom.Int2();

            GenTree tree = new GenTree(x, y);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1];

            SetWood(chunkX, x, y-1, (ushort)BlockId.SpruceWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.SpruceWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.SpruceWood, tree);

            SetLeave(chunkXM1, x-1, y-2, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x,   y-2, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXP1, x+1, y-2, (ushort)BlockId.SpruceLeaves, tree);

            SetLeave(chunkXM1, x-1, y-3, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x,   y-3, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkXP1, x+1, y-3, (ushort)BlockId.SpruceLeaves, tree);

            if (FastRandom.Bool()) SetLeave(chunkXM1, x-1, y-4, (ushort)BlockId.SpruceLeaves, tree);
            SetLeave(chunkX,   x, y-4, (ushort)BlockId.SpruceLeaves, tree);
            if (FastRandom.Bool()) SetLeave(chunkXP1, x+1, y-4, (ushort)BlockId.SpruceLeaves, tree);

            SetLeave(chunkX,   x,   y-5, (ushort)BlockId.SpruceLeaves, tree);
        }

        void TreeAcacia(int x, int y) {
            treeChange=1+FastRandom.Int(6);

            GenTree tree = new GenTree(x, y-2);
            LiveObjects.Add(tree);

            GChunk
                chunkX   = terrain[x  ],
                chunkXP1 = terrain[x+1],
                chunkXM1 = terrain[x-1],
                chunkXP2 = terrain[x+2],
                chunkXM2 = terrain[x-2],
                chunkXP3 = terrain[x+3],
                chunkXM3 = terrain[x-3];

            SetWood(chunkX, x, y-1, (ushort)BlockId.AcaciaWood, tree);
            SetWood(chunkX, x, y-2, (ushort)BlockId.AcaciaWood, tree);
            SetWood(chunkX, x, y-3, (ushort)BlockId.AcaciaWood, tree);
            SetWood(chunkX, x, y-4, (ushort)BlockId.AcaciaWood, tree);
            SetWood(chunkX, x, y-5, (ushort)BlockId.AcaciaWood, tree);

            if (FastRandom.Bool()) {
                SetWood(chunkXM1, x-1, y-4, (ushort)BlockId.AcaciaWood, tree);
                SetWood(chunkXM2, x-2, y-5, (ushort)BlockId.AcaciaWood, tree);
                SetWood(chunkXP1, x+1, y-3, (ushort)BlockId.AcaciaWood, tree);
                SetWood(chunkXP2, x+2, y-4, (ushort)BlockId.AcaciaWood, tree);

                SetLeave(chunkXM2, x-2, y-6, (ushort)BlockId.AcaciaLeaves, tree);
                SetLeave(chunkXP3, x+3, y-4, (ushort)BlockId.AcaciaLeaves, tree);
                SetLeave(chunkXP2, x+2, y-4, (ushort)BlockId.AcaciaLeaves, tree);
            } else {
                SetWood(chunkXP1, x+1, y-4, (ushort)BlockId.AcaciaWood, tree);
                SetWood(chunkXP2, x+2, y-5, (ushort)BlockId.AcaciaWood, tree);
                SetWood(chunkXM1, x-1, y-3, (ushort)BlockId.AcaciaWood, tree);
                SetWood(chunkXM2, x-2, y-4, (ushort)BlockId.AcaciaWood, tree);

                SetLeave(chunkXP2, x+2, y-6, (ushort)BlockId.AcaciaLeaves, tree);
                SetLeave(chunkXM3, x-3, y-4, (ushort)BlockId.AcaciaLeaves, tree);
                SetLeave(chunkXM2, x-2, y-4, (ushort)BlockId.AcaciaLeaves, tree);
            }

            SetLeave(chunkX,   x  , y-5, (ushort)BlockId.AcaciaLeaves, tree);
            SetLeave(chunkXP1, x+1, y-5, (ushort)BlockId.AcaciaLeaves, tree);
            SetLeave(chunkXM1, x-1, y-5, (ushort)BlockId.AcaciaLeaves, tree);
            SetLeave(chunkXP2, x+2, y-5, (ushort)BlockId.AcaciaLeaves, tree);
            SetLeave(chunkXM2, x-2, y-5, (ushort)BlockId.AcaciaLeaves, tree);
            SetLeave(chunkXP3, x+3, y-5, (ushort)BlockId.AcaciaLeaves, tree);
            SetLeave(chunkXM3, x-3, y-5, (ushort)BlockId.AcaciaLeaves, tree);
            SetLeave(chunkXM1, x-1, y-6, (ushort)BlockId.AcaciaLeaves, tree);
            SetLeave(chunkXP1, x+1, y-6, (ushort)BlockId.AcaciaLeaves, tree);
            SetLeave(chunkX,   x  , y-6, (ushort)BlockId.AcaciaLeaves, tree);
        }

        void OreCoal(int y) {
            ushort[] chunk10_SolidBlocks=terrain[pos-10].SolidBlocks;
            chunk10_SolidBlocks[y-1]=(ushort)BlockId.OreCoal;
            chunk10_SolidBlocks[y]  =(ushort)BlockId.OreCoal;
            chunk10_SolidBlocks[y+1]=(ushort)BlockId.OreCoal;

            ushort[] chunk9_SolidBlocks=terrain[pos-9].SolidBlocks;
            chunk9_SolidBlocks[y]  =(ushort)BlockId.OreCoal;
            chunk9_SolidBlocks[y+1]=(ushort)BlockId.OreCoal;

            ushort[] chunk8_SolidBlocks=terrain[pos-8].SolidBlocks;
            chunk8_SolidBlocks[y]  =(ushort)BlockId.OreCoal;
            chunk8_SolidBlocks[y+1]=(ushort)BlockId.OreCoal;

            ushort[] chunk7_SolidBlocks=terrain[pos-7].SolidBlocks;
            chunk7_SolidBlocks[y  ]=(ushort)BlockId.OreCoal;
            chunk7_SolidBlocks[y+1]=(ushort)BlockId.OreCoal;

            terrain[pos-10+4].SolidBlocks[y]=(ushort)BlockId.OreCoal;
            terrain[pos-10+5].SolidBlocks[y]=(ushort)BlockId.OreCoal;

            ushort[] chunk11_SolidBlocks=terrain[pos-11].SolidBlocks;
            chunk11_SolidBlocks[y+1]=(ushort)BlockId.OreCoal;
            chunk11_SolidBlocks[y  ]=(ushort)BlockId.OreCoal;
            chunk11_SolidBlocks[y-1]=(ushort)BlockId.OreCoal;

            ushort[] chunk12_SolidBlocks=terrain[pos-12].SolidBlocks;
            chunk12_SolidBlocks[y+1]=(ushort)BlockId.OreCoal;
            chunk12_SolidBlocks[y  ]=(ushort)BlockId.OreCoal;
            chunk12_SolidBlocks[y-1]=(ushort)BlockId.OreCoal;

            ushort[] chunk13_SolidBlocks=terrain[pos-13].SolidBlocks;
            chunk13_SolidBlocks[y  ]=(ushort)BlockId.OreCoal;
            chunk13_SolidBlocks[y-1]=(ushort)BlockId.OreCoal;

            ushort[] chunk14_SolidBlocks=terrain[pos-14].SolidBlocks;
            chunk14_SolidBlocks[y  ]=(ushort)BlockId.OreCoal;
            chunk14_SolidBlocks[y-1]=(ushort)BlockId.OreCoal;

            terrain[pos-10-5].SolidBlocks[y]=(ushort)BlockId.OreCoal;
        }

        void OreIron(int y) {
            ushort[] chunk10_SolidBlocks=terrain[pos-10].SolidBlocks;
            chunk10_SolidBlocks[y  ]=(ushort)BlockId.OreIron;
            chunk10_SolidBlocks[y-1]=(ushort)BlockId.OreIron;
            chunk10_SolidBlocks[y+1]=(ushort)BlockId.OreIron;
            chunk10_SolidBlocks[y+2]=(ushort)BlockId.OreIron;
            chunk10_SolidBlocks[y+3]=(ushort)BlockId.OreIron;
            chunk10_SolidBlocks[y+4]=(ushort)BlockId.OreIron;
            chunk10_SolidBlocks[y+5]=(ushort)BlockId.OreIron;

            ushort[] chunk11_SolidBlocks=terrain[pos-11].SolidBlocks;
            chunk11_SolidBlocks[y  ]=(ushort)BlockId.OreIron;
            chunk11_SolidBlocks[y-1]=(ushort)BlockId.OreIron;
            chunk11_SolidBlocks[y-2]=(ushort)BlockId.OreIron;
            chunk11_SolidBlocks[y-3]=(ushort)BlockId.OreIron;
            chunk11_SolidBlocks[y-4]=(ushort)BlockId.OreIron;
            chunk11_SolidBlocks[y-5]=(ushort)BlockId.OreIron;
        }

        void OreGold(int y) {
             terrain[pos-8 ].SolidBlocks[y  ]=(ushort)BlockId.OreGold;
             terrain[pos-9 ].SolidBlocks[y  ]=(ushort)BlockId.OreGold;
             terrain[pos-10].SolidBlocks[y  ]=(ushort)BlockId.OreGold;
             terrain[pos-13].SolidBlocks[y  ]=(ushort)BlockId.OreGold;
             terrain[pos-15].SolidBlocks[y-1]=(ushort)BlockId.OreGold;
             terrain[pos-16].SolidBlocks[y-1]=(ushort)BlockId.OreGold;
        }

        void OreCopper(int y) {
            ushort[] chunk10_SolidBlocks=terrain[pos-10].SolidBlocks;
            chunk10_SolidBlocks[y  ]=(ushort)BlockId.OreCopper;
            chunk10_SolidBlocks[y+1]=(ushort)BlockId.OreCopper;
            chunk10_SolidBlocks[y+2]=(ushort)BlockId.OreCopper;

            ushort[] chunk9_SolidBlocks=terrain[pos-9].SolidBlocks;
            chunk9_SolidBlocks[y+2]=(ushort)BlockId.OreCopper;
            chunk9_SolidBlocks[y+3]=(ushort)BlockId.OreCopper;

            terrain[pos-10+2].SolidBlocks[y+3]=(ushort)BlockId.OreCopper;

            terrain[pos-10+3].SolidBlocks[y+4]=(ushort)BlockId.OreCopper;

            ushort[] chunk11_SolidBlocks=terrain[pos-11].SolidBlocks;
            chunk11_SolidBlocks[y-1]=(ushort)BlockId.OreCopper;
            chunk11_SolidBlocks[y-2]=(ushort)BlockId.OreCopper;

            ushort[] chunk12_SolidBlocks=terrain[pos-12].SolidBlocks;
            chunk12_SolidBlocks[y-2]=(ushort)BlockId.OreCopper;
            chunk12_SolidBlocks[y-3]=(ushort)BlockId.OreCopper;

            terrain[pos-10-3].SolidBlocks[y-4]=(ushort)BlockId.OreCopper;
        }

        void OreTin(int y) {
            ushort[] chunk10_SolidBlocks=terrain[pos-10].SolidBlocks;
            chunk10_SolidBlocks[y  ]=(ushort)BlockId.OreTin;
            chunk10_SolidBlocks[y-1]=(ushort)BlockId.OreTin;

            ushort[] chunk11_SolidBlocks=terrain[pos-11].SolidBlocks;
            chunk11_SolidBlocks[y+1]=(ushort)BlockId.OreTin;
            chunk11_SolidBlocks[y+2]=(ushort)BlockId.OreTin;
        }

        void OreSilver(int y) {
             terrain[pos-8 ].SolidBlocks[y  ]=(ushort)BlockId.OreSilver;
             terrain[pos-9 ].SolidBlocks[y  ]=(ushort)BlockId.OreSilver;
             terrain[pos-10].SolidBlocks[y  ]=(ushort)BlockId.OreSilver;
             terrain[pos-13].SolidBlocks[y  ]=(ushort)BlockId.OreSilver;
             terrain[pos-14].SolidBlocks[y-1]=(ushort)BlockId.OreSilver;
             terrain[pos-16].SolidBlocks[y-1]=(ushort)BlockId.OreSilver;
        }

        void OreAliminium(int y) {
            terrain[pos-7 ].SolidBlocks[y+1]=(ushort)BlockId.OreAluminium;
            terrain[pos-8 ].SolidBlocks[y  ]=(ushort)BlockId.OreAluminium;

            ushort[] chunk9_SolidBlocks=terrain[pos-9].SolidBlocks;
            chunk9_SolidBlocks[y  ]=(ushort)BlockId.OreAluminium;
            chunk9_SolidBlocks[y+1]=(ushort)BlockId.OreAluminium;

            terrain[pos-10].SolidBlocks[y  ]=(ushort)BlockId.OreAluminium;
            terrain[pos-13].SolidBlocks[y  ]=(ushort)BlockId.OreAluminium;
            terrain[pos-14].SolidBlocks[y-1]=(ushort)BlockId.OreAluminium;
            terrain[pos-16].SolidBlocks[y  ]=(ushort)BlockId.OreAluminium;
        }

        void OreSulfur(int y) {
            if (FastRandom.Bool()){
                if (FastRandom.Bool()) terrain[pos-9 ].SolidBlocks[y+1]=(ushort)BlockId.OreSulfur;
                if (FastRandom.Bool()) terrain[pos-9 ].SolidBlocks[y-1]=(ushort)BlockId.OreSulfur;
                if (FastRandom.Bool()) terrain[pos-10].SolidBlocks[y+1]=(ushort)BlockId.OreSulfur;
                if (FastRandom.Bool()) terrain[pos-10].SolidBlocks[y  ]=(ushort)BlockId.OreSulfur;
                if (FastRandom.Bool()) terrain[pos-10].SolidBlocks[y-1]=(ushort)BlockId.OreSulfur;
                if (FastRandom.Bool()) terrain[pos-13].SolidBlocks[y  ]=(ushort)BlockId.OreSulfur;
            } else {
                if (FastRandom.Bool()) terrain[pos-10].SolidBlocks[y+1]=(ushort)BlockId.OreSulfur;
                if (FastRandom.Bool()) terrain[pos-10].SolidBlocks[y  ]=(ushort)BlockId.OreSulfur;
                if (FastRandom.Bool()) terrain[pos-9 ].SolidBlocks[y+1]=(ushort)BlockId.OreSulfur;
                if (FastRandom.Bool()) terrain[pos-9 ].SolidBlocks[y  ]=(ushort)BlockId.OreSulfur;
                if (FastRandom.Bool()) terrain[pos-8 ].SolidBlocks[y+1]=(ushort)BlockId.OreSulfur;
                if (FastRandom.Bool()) terrain[pos-8 ].SolidBlocks[y  ]=(ushort)BlockId.OreSulfur;
            }
        }

        void OreSaltpeter(int y) {
            if (FastRandom.Bool()){
                 terrain[pos-7 ].SolidBlocks[y+1]=(ushort)BlockId.OreSaltpeter;
                 terrain[pos-8 ].SolidBlocks[y+1]=(ushort)BlockId.OreSaltpeter;
                 terrain[pos-9 ].SolidBlocks[y  ]=(ushort)BlockId.OreSaltpeter;
                 terrain[pos-10].SolidBlocks[y  ]=(ushort)BlockId.OreSaltpeter;
                 terrain[pos-12].SolidBlocks[y  ]=(ushort)BlockId.OreSaltpeter;
                 if (FastRandom.Bool()) terrain[pos-13].SolidBlocks[y]=(ushort)BlockId.OreSaltpeter;
            } else {
                terrain[pos-13].SolidBlocks[y-1]=(ushort)BlockId.OreSaltpeter;
                terrain[pos-12].SolidBlocks[y-1]=(ushort)BlockId.OreSaltpeter;
                terrain[pos-11].SolidBlocks[y  ]=(ushort)BlockId.OreSaltpeter;
                terrain[pos-10].SolidBlocks[y  ]=(ushort)BlockId.OreSaltpeter;
                terrain[pos-10+2].SolidBlocks[y]=(ushort)BlockId.OreSaltpeter;
                if (FastRandom.Bool()) terrain[pos-7].SolidBlocks[y]=(ushort)BlockId.OreSaltpeter;
            }
        }

        void OreOil(int y) {
            if (FastRandom.Bool()) {
                 terrain[pos-4].TopBlocks[y  ]=(ushort)BlockId.Oil;
                 terrain[pos-5].TopBlocks[y-1]=(ushort)BlockId.Oil;
            }

            terrain[pos-5].TopBlocks[y]=(ushort)BlockId.Oil;

            ushort[] chunk6_TopBlocks=terrain[pos-6].TopBlocks;
            chunk6_TopBlocks[y  ]=(ushort)BlockId.Oil;
            chunk6_TopBlocks[y-1]=(ushort)BlockId.Oil;
            ushort[] chunk6_SolidBlocks=terrain[pos-6].SolidBlocks;
            chunk6_SolidBlocks[y  ]=0;
            chunk6_SolidBlocks[y-1]=0;

            ushort[] chunk7_TopBlocks=terrain[pos-7].TopBlocks;
            chunk7_TopBlocks[y  ]=(ushort)BlockId.Oil;
            chunk7_TopBlocks[y-1]=(ushort)BlockId.Oil;
            ushort[] chunk7_SolidBlocks=terrain[pos-7].SolidBlocks;
            chunk7_SolidBlocks[y  ]=0;
            chunk7_SolidBlocks[y-1]=0;

            ushort[] chunk8_TopBlocks=terrain[pos-8].TopBlocks;
            chunk8_TopBlocks[y]=(ushort)BlockId.Oil;
            chunk8_TopBlocks[y-1]=(ushort)BlockId.Oil;
            ushort[] chunk8_SolidBlocks=terrain[pos-8].SolidBlocks;
            chunk8_SolidBlocks[y  ]=0;
            chunk8_SolidBlocks[y-1]=0;
            if (FastRandom.Bool()) {
                chunk8_TopBlocks[y+1]=(ushort)BlockId.Oil;
                chunk8_SolidBlocks[y+1]=0;
            }

            ushort[] chunk9_TopBlocks=terrain[pos-9].TopBlocks;
            chunk9_TopBlocks[y]=(ushort)BlockId.Oil;
            chunk9_TopBlocks[y-1]=(ushort)BlockId.Oil;
            chunk9_TopBlocks[y+1]=(ushort)BlockId.Oil;
            ushort[] chunk9_SolidBlocks=terrain[pos-9].SolidBlocks;
            chunk9_SolidBlocks[y-1]=0;
            chunk9_SolidBlocks[y  ]=0;
            chunk9_SolidBlocks[y+1]=0;

            ushort[] chunk10_TopBlocks=terrain[pos-10].TopBlocks;
            chunk10_TopBlocks[y-1]=(ushort)BlockId.Oil;
            chunk10_TopBlocks[y]=  (ushort)BlockId.Oil;
            chunk10_TopBlocks[y+1]=(ushort)BlockId.Oil;
            ushort[] chunk10_SolidBlocks=terrain[pos-10].SolidBlocks;
            chunk10_SolidBlocks[y-1]=0;
            chunk10_SolidBlocks[y  ]=0;
            chunk10_SolidBlocks[y+1]=0;

            ushort[] chunk11_TopBlocks=terrain[pos-11].TopBlocks;
            chunk11_TopBlocks[y+1]=(ushort)BlockId.Oil;
            chunk11_TopBlocks[y  ]=(ushort)BlockId.Oil;
            chunk11_TopBlocks[y-1]=(ushort)BlockId.Oil;
            chunk11_TopBlocks[y-2]=(ushort)BlockId.Oil;
            ushort[] chunk11_SolidBlocks=terrain[pos-11].SolidBlocks;
            chunk11_SolidBlocks[y+1]=0;
            chunk11_SolidBlocks[y  ]=0;
            chunk11_SolidBlocks[y-1]=0;
            chunk11_SolidBlocks[y-2]=0;

            ushort[] chunk12_SolidBlocks=terrain[pos-12].SolidBlocks;
            ushort[] chunk12_TopBlocks=terrain[pos-12].TopBlocks;
            chunk12_TopBlocks[y]=(ushort)BlockId.Oil;   chunk12_SolidBlocks[y]=0;
            chunk12_TopBlocks[y-1]=(ushort)BlockId.Oil; chunk12_SolidBlocks[y-1]=0;
            chunk12_TopBlocks[y-2]=(ushort)BlockId.Oil; chunk12_SolidBlocks[y-2]=0;
            chunk12_TopBlocks[y+1]=(ushort)BlockId.Oil; chunk12_SolidBlocks[y+1]=0;

            ushort[] chunk13_TopBlocks=terrain[pos-13].TopBlocks;
            chunk13_TopBlocks[y-1]=(ushort)BlockId.Oil;
            chunk13_TopBlocks[y  ]=(ushort)BlockId.Oil;
            chunk13_TopBlocks[y+1]=(ushort)BlockId.Oil;
            ushort[] chunk13_SolidBlocks=terrain[pos-13].SolidBlocks;
            chunk13_SolidBlocks[y-1]=0;
            chunk13_SolidBlocks[y  ]=0;
            chunk13_SolidBlocks[y+1]=0;

            ushort[] chunk14_TopBlocks=terrain[pos-14].TopBlocks;
            chunk14_TopBlocks[y-1]=(ushort)BlockId.Oil;
            chunk14_TopBlocks[y  ]=(ushort)BlockId.Oil;
            ushort[] chunk14_SolidBlocks=terrain[pos-14].SolidBlocks;
            chunk14_SolidBlocks[y-1]=0;
            chunk14_SolidBlocks[y  ]=0;

            if (FastRandom.Bool()) terrain[pos-15].TopBlocks[y]=(ushort)BlockId.Oil;
        }
        #endregion

        int GetWorldSize() {
            if (currentWorldSize==WorldSize.Medium) return 7500;
            if (currentWorldSize==WorldSize.Small) return 5000;
            return 10000;
        }
        void CaveGenerator(int x, int y) {

            // cave lenght
            int len=FastRandom.Int(32)+16;

            float angle=FastRandom.Rotatin();
            (Vector2, float, float)[] points=new (Vector2, float, float)[len];

            Vector2 lastPoint=new(x,y);

            float lastRnd=FastRandom.Float();
            for (int i=0; i<len; i++) {
                points[i].Item1=new Vector2(lastPoint.X, lastPoint.Y);

                float ta=angle;

                // Cave asymetry
                float add=(FastRandom.FloatHalf()/**0.5f*/-1f)*0.3f;

                if (add+lastRnd>1f)add=1f;
                if (add+lastRnd<0f)add=0f;

                lastRnd+=add;

                float half=(float)i/len;
                points[i].Item2=lastRnd*(1f-(2f*half-1f)*(2f*half-1f));

                // Next acc
                float nextLen=FastRandom.Float()+0.5f;
                lastPoint.X+=((float)Math.Cos(angle))*nextLen;
                lastPoint.Y+=((float)Math.Sin(angle))*nextLen;

                angle+=(FastRandom.Float()-0.5f)*0.1f;
                points[i].Item3=(angle*ta)/2f;
            }

            Vector2[] fin=new Vector2[len];
            for (int i=0; i<len; i++) {
                float vecrot=points[i].Item3+FastMath.PIHalf;

                fin[i]=new Vector2(points[i].Item1.X+((float)Math.Cos(vecrot))*points[i].Item2, points[i].Item1.Y+((float)Math.Sin(vecrot)*points[i].Item2));
            }

            for (int i=0; i<len; i++) {
                int xx=(int)fin[i].X, yy=(int)fin[i].Y;
                if (yy<100 && yy>40) RemoveRound(1+FastRandom.Int(7),xx,yy);
            }

            void RemoveRound(int size, int xx, int yy) {
                RemoveBlock(xx,yy);

                RemoveBlock(xx, yy+1);
                RemoveBlock(xx, yy-1);
                if (size>2) return;

                RemoveBlock(xx-1, yy);
                RemoveBlock(xx+1, yy);
                if (size>3) return;

                RemoveBlock(xx+1, yy+1);
                RemoveBlock(xx-1, yy-1);
                if (size>4) return;

                RemoveBlock(xx+1, yy-1);
                RemoveBlock(xx-1, yy+1);
                if (size>5) return;

                RemoveBlock(xx+2, yy);
                RemoveBlock(xx-2, yy);
                if (size>6) return;

                RemoveBlock(xx, yy+2);
                RemoveBlock(xx, yy-2);
                if (size>7) return;
            }

            void RemoveBlock(int xx, int yy) {
                GChunk chunk=terrain[xx];
                ushort solidId=terrain[xx].SolidBlocks[yy];

                if (solidId!=0) {

                    switch (solidId) {
                        case (ushort)BlockId.StoneBasalt:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackBasalt;
                            break;

                        case (ushort)BlockId.StoneDiorit:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackDiorit;
                            break;

                        case (ushort)BlockId.StoneDolomite:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackDolomite;
                            break;

                        case (ushort)BlockId.StoneGabbro:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackGabbro;
                            break;

                        case (ushort)BlockId.StoneGneiss:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackGneiss;
                            break;

                        case (ushort)BlockId.StoneLimestone:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackLimestone;
                            break;

                        case (ushort)BlockId.StoneRhyolite:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackRhyolite;
                            break;

                        case (ushort)BlockId.StoneSandstone:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackSandstone;
                            break;

                        case (ushort)BlockId.StoneSchist:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackSchist;
                            break;

                        case (ushort)BlockId.OreAluminium:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackAluminium;
                            break;

                        case (ushort)BlockId.OreCoal:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackCoal;
                            break;

                        case (ushort)BlockId.OreCopper:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackCopper;
                            break;

                        case (ushort)BlockId.OreGold:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackGold;
                            break;

                        case (ushort)BlockId.OreIron:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackIron;
                            break;

                        case (ushort)BlockId.OreSaltpeter:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackSaltpeter;
                            break;

                        case (ushort)BlockId.OreSilver:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackSilver;
                            break;

                        case (ushort)BlockId.OreSulfur:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackSulfur;
                            break;

                        case (ushort)BlockId.OreTin:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackTin;
                            break;

                        case (ushort)BlockId.Dirt:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackDirt;
                            break;

                        case (ushort)BlockId.Sand:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackSand;
                            break;

                        case (ushort)BlockId.Gravel:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackGravel;
                            break;

                        case (ushort)BlockId.Cobblestone:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackCobblestone;
                            break;

                        case (ushort)BlockId.Clay:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackClay;
                            break;

                        case (ushort)BlockId.GrassBlockClay:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackClay;
                            break;

                        case (ushort)BlockId.GrassBlockCompost:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackDirt;
                            break;

                        case (ushort)BlockId.GrassBlockDesert:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackDirt;
                            break;

                        case (ushort)BlockId.GrassBlockForest:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackDirt;
                            break;

                        case (ushort)BlockId.GrassBlockHills:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackDirt;
                            break;

                        case (ushort)BlockId.GrassBlockJungle:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackDirt;
                            break;

                        case (ushort)BlockId.GrassBlockPlains:
                            chunk.SolidBlocks[yy]=0;
                            chunk.BackBlocks[yy]=(ushort)BlockId.BackDirt;
                            break;
                    }

                    if (chunk.SolidBlocks[yy-1]!=0) {
                        ushort idTop=chunk.TopBlocks[yy-1];
                        if (idTop!=0) {
                            switch (idTop) {
                                case (ushort)BlockId.GrassDesert:   chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.GrassForest:   chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.GrassHills:    chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.GrassJungle:   chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.GrassPlains:   chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.Heather:       chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.Dandelion:     chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.Violet:        chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.Rose:          chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.BranchALittle1:chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.BranchALittle2:chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.BranchFull:    chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.BranchWithout: chunk.TopBlocks[yy-1]=0; break;
                                case (ushort)BlockId.Alore:         chunk.TopBlocks[yy-1]=0; break;
                            }
                        }
                    }
                }
            }
        }

        class BiomeExt{
            public HotBiome Temterature;
            public WetBiome Humidity;
            public ChangerBiome Changer;
            public int oceanIndex;
        }
    }

    public class GChunk {
        public ushort[]
            SolidBlocks = new ushort[125],
            TopBlocks   = new ushort[125],
            BackBlocks  = new ushort[125];

        public List<byte>
            Plants = new List<byte>(),
            Mobs   = new();

        public unsafe void AddPlant(ushort id, byte height) {
            #if DEBUG
            if (id==0)throw new System.ArgumentException("id is 0");
            #endif

            byte* ids=(byte*)&id;
            Plants.Add(ids[1]);
            Plants.Add(ids[0]);
            Plants.Add(height);
            FastRandom.Byte(Plants);
            PlantsCount++;
        }

        public unsafe void AddPlantWheat(byte height) {
            Plants.Add(byteWheat1);
            Plants.Add(byteWheat0);
            Plants.Add(height);
            FastRandom.Byte(Plants);
            PlantsCount++;
        }

        public unsafe void AddPlantCarrot(byte height) {
            Plants.Add(byteCarrot1);
            Plants.Add(byteCarrot0);
            Plants.Add(height);
            FastRandom.Byte(Plants);
            PlantsCount++;
        }

        public unsafe void AddPlantFlax(byte height) {
            Plants.Add(byteFlax1);
            Plants.Add(byteFlax0);
            Plants.Add(height);
            FastRandom.Byte(Plants);
            PlantsCount++;
        }

        const byte
            byteWheat0=(byte)(ushort)BlockId.Wheat,
            byteWheat1=(byte)(ushort)(((ushort)BlockId.Wheat)>>8),

            byteFlax0=(byte)(ushort)BlockId.Flax,
            byteFlax1=(byte)(ushort)(((ushort)BlockId.Flax)>>8),

            byteCarrot0=(byte)(ushort)BlockId.Carrot,
            byteCarrot1=(byte)(ushort)(((ushort)BlockId.Carrot)>>8),


            byteFish0=(byte)(ushort)BlockId.Fish,
            byteFish1=(byte)(ushort)(((ushort)BlockId.Fish)>>8),

            byteRabbit0=(byte)(ushort)BlockId.Rabbit,
            byteRabbit1=(byte)(ushort)(((ushort)BlockId.Rabbit)>>8),

            byteParrot0=(byte)(ushort)BlockId.MobParrot,
            byteParrot1=(byte)(ushort)(((ushort)BlockId.MobParrot)>>8),

            byteChicken0=(byte)(ushort)BlockId.Chicken,
            byteChicken1=(byte)(ushort)(((ushort)BlockId.Chicken)>>8);

        public unsafe void AddFish(byte height) {
            Mobs.Add(byteFish1);
            Mobs.Add(byteFish0);
            Mobs.Add(height);
            FastRandom.Byte2(Mobs);
            MobsCount++;
        }

        public unsafe void AddRabbit(byte height) {
            Mobs.Add(byteRabbit1);
            Mobs.Add(byteRabbit0);
            Mobs.Add(height);
            FastRandom.Byte2(Mobs);
            MobsCount++;
        }

        public unsafe void AddChicken(byte height) {
            Mobs.Add(byteChicken1);
            Mobs.Add(byteChicken0);
            Mobs.Add(height);
            FastRandom.Byte2(Mobs);
            MobsCount++;
        }

        public unsafe void AddParrot(byte height) {
            Mobs.Add(byteParrot1);
            Mobs.Add(byteParrot0);

            // no flying
            Mobs.Add(0);

            Mobs.Add(height);
            FastRandom.Byte2(Mobs);

            MobsCount++;
        }

        public int PlantsCount, MobsCount;

        public byte LightPosFull;
        public byte LightPosHalf;
        public bool SetLightPosHalf;
        public byte Half;

    }

    public class GPreChunk {
        public byte RoundedHeight;//(average)
        public byte Height;//(ending)

        public float TerrainChangeIndex;

        public int distanceWater;
        public int distanceEquator;

        public bool Water;
    }
}