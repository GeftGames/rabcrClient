using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace rabcrClient {
	#if MULTIPLAYER
    public enum MChunkState:byte{
        NotDownloaded,
        SendRequest,
        Downloaded
    }

    public class MTerrain {
        public int
            // Total (With half)
            LightPosFull,
            LightPosFull16,
            LightPosHalf,
            LightPosHalf16,
			StartSomething;

        public MChunkState state=MChunkState.NotDownloaded;
        public DateTime sended;

        public Block[] Background=new Block[125];
        public Block[] SolidBlocks=new Block[125];
        public Block[] TopBlocks=new Block[125];

        public bool[]
            IsBackground=new bool[125],
            IsSolidBlocks=new bool[125],
            IsTopBlocks=new bool[125];

      //  public bool BackgroundExists(int h) => IsBackground[h]==MBlockState.Exist;//((int)IsBackground[h] & 1)==1;

      //  public bool SolidBlocksExists(int h) => IsSolidBlocks[h]==MBlockState.Exist/* || IsSolidBlocks[h]==MBlockState.TmpAdded*/;//((int)IsSolidBlocks[h] & 1)==1;

      //  public bool TopBlocksExists(int h) => IsTopBlocks[h]==MBlockState.Exist;//((int)IsTopBlocks[h] & 1)==1;


        public List<MMob> Mobs=new();
        public List<Plant> Plants=new();

        public Vector2 LightVec;

        ///<summary> After you removed New Block on Y pos terrain</summary>
        public void RefreshLightingRemoveTop(int newBlockOnY, ushort id) {
			if (newBlockOnY==LightPosHalf) {
				if (GameMethods.IsHalfShadowBlock(id)) {

					for (int i=LightPosHalf; i<125; i++) {
						if (i==LightPosFull) {
							LightPosHalf=i;
							LightPosHalf16=i*16;
							//StartSomething=newBlockOnY;
							return;
						}

						if (IsTopBlocks[i]) {
							if (GameMethods.IsHalfShadowBlock(TopBlocks[i].Id)) {
								LightPosHalf=i;
								LightPosHalf16=i*16;
							//	StartSomething=newBlockOnY;
								return;
							}
						}
					}
				}
			}
		}

		///<summary> After you Added New Block on Y pos terrain</summary>
        public void RefreshLightingAddTop(int newBlockOnY, ushort id) {
			if (GameMethods.IsHalfShadowBlock(id)) {
				//if (newBlockOnY<LightPosFull) {
					if (newBlockOnY<LightPosHalf) {
						LightPosHalf=newBlockOnY;
						LightPosHalf16=newBlockOnY*16;
					}
				//}
			}
		}

        public void RefreshLightingAddSolid(int pos, int y) {
			if (y<StartSomething) StartSomething=y;

			if (y<LightPosFull) {
				LightPosFull=y;
				LightPosFull16=y*16;
				LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);

                if (y<LightPosHalf) {
                    LightPosHalf=y;
                    LightPosHalf16=y*16;
                }
            }
		}

		public void RefreshLightingRemoveSolid(int pos, int y) {
			if (y==LightPosFull) {

				// starting something in chunk
				int sStartSomething=0;
				for (; sStartSomething<125; sStartSomething++) {
					if (IsTopBlocks[sStartSomething]) break;
					if (IsSolidBlocks[sStartSomething]) break;
					if (IsBackground[sStartSomething]) break;
				}
				StartSomething=sStartSomething;


				int LightPos=StartSomething;
				for (; LightPos<125; LightPos++) {
					if (IsSolidBlocks[LightPos]) {
						LightPosFull=LightPos;
						LightVec=new Vector2(pos*16-48+8, LightPos*16-48+8+48);
						LightPosFull16=LightPos*16;
						break;
					}
				}


				// first solid block in chunk
				int LightPos2=StartSomething;
				for (; LightPos2<LightPosFull; LightPos2++) {
					if (IsTopBlocks[LightPos2]){
						LightPosHalf=LightPos2;
						LightPosHalf16=LightPos2*16;
						break;
					}
				}
				if (LightPos2==LightPosFull){
					LightPosHalf=LightPos2;
						LightPosHalf16=LightPos2*16;
				}





				//int LightPos=y;
				//for (; LightPos<125; LightPos++) {
				//	if (IsSolidBlocks[LightPos]) break;
				//}

				//if (LightPosFull!=LightPos) {

				//	int sStartSomething;
				//	for (sStartSomething=0; sStartSomething<125; sStartSomething++) {
				//		if (IsTopBlocks[sStartSomething]) break;
				//		if (IsSolidBlocks[sStartSomething]) break;
				//		if (IsBackground[sStartSomething]) break;
				//	}

				//	StartSomething=sStartSomething;

				//	for (int i=StartSomething; i<125; i++) {
				//		if (IsTopBlocks[i]) {
				//			if (GameMethods.IsHalfShadowBlock(TopBlocks[i].Id)) {
				//				LightPosHalf=i;
				//				LightPosHalf16=i*16;
				//				break;
				//			}
				//		}

				//	}
				//}

				//LightPosFull=LightPos;
				//LightVec=new Vector2(pos*16-48+8, LightPos*16-48+8+48);
				//LightPosFull16=LightPos*16;
			}
		}
    }

    public enum MBlockState:byte {
        NotExists=0, //00
        Exist=1,     //01

        ///<summary>Looks like notexisting, but not, but server need check if player can remove</summary>
        TmpRemoved=2, //10

        ///<summary>Looks like existing, but not, but server need check if player can add</summary>
        TmpAdded=3,     //11
    }

    class ChangeTerrain {
        public DateTime sended;

        enum ChangeTerrainType:byte{
            BasicRemove,
            BasicAdd,
            Changed,



        }
    }

    class SendedBlockToRemove:ChangeTerrain {
       // public MMob animal;
        public DInt blockPos;
        public BlockType blockType;
       // public List<DInt> items;
        public string World;

        public int SelectedInv;
    }

    class SendedBlockToChange : ChangeTerrain {
     //   public MMob animal;
        public DInt blockPos;
        public BlockType blockType;
      //  public List<DInt> items;
        public string World;
    }

    class SendedBlockToAdd:ChangeTerrain {
       // public MMob animal;
        public DInt blockPos;
        public BlockType blockType;
     //   public List<DInt> items;
        public string World;

        public int SelectedInv;
    }
	#endif

}