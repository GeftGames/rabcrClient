using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#if DEBUG
using System.Diagnostics;
#endif


namespace rabcrClient {
    public class CraftingIn{
        public ItemNonInv[] ItemSlot;
        public bool HaveItemInInventory;
        public int SelectedItem, TmpSelected;
        public Texture2D Texture;

        public CraftingIn(ItemNonInv[] itemSlot) {
            ItemSlot=itemSlot;
            SelectedItem=-1;
        }

        public CraftingIn(ItemNonInv itemSlot) {
            ItemSlot=new ItemNonInv[]{itemSlot };
            SelectedItem=0;
        }

        //public CraftingIn(int id) {
        //    ItemSlot=new ItemNonInv[]{new ItemNonInv(id,1) };
        //    SelectedItem=0;
        //}

        //public CraftingIn(int id, int count) {
        //    ItemSlot=new ItemNonInv[]{new ItemNonInv(id, count) };
        //    SelectedItem=0;
        //}

    }

    public class CraftingRecipe {
            public CraftingIn[] Input;
            public CraftingOut[] Output;

            public CraftingRecipe(ItemNonInv input, ItemNonInv output) {
                Input=new CraftingIn[]{new CraftingIn(new ItemNonInv[]{input })};
                Output=new CraftingOut[]{new CraftingOut{Item=output, EveryTime=true} };
            }

            public CraftingRecipe(CraftingIn[] input, ItemNonInv output) {
                Input=input;
                Output=new CraftingOut[]{ new CraftingOut{ Item=output, EveryTime=true} };
            }

            public CraftingRecipe(ItemNonInv input, CraftingOut[] output) {
                Input=new CraftingIn[]{ new CraftingIn(input) };
                Output=output;
            }

            public CraftingRecipe(ItemNonInv input, CraftingOut output) {
                Input=new CraftingIn[]{ new CraftingIn(input) };
                Output=new CraftingOut[]{ output };
            }

            public CraftingRecipe(CraftingIn input, CraftingOut output) {
                Input=new CraftingIn[]{ input };
                Output=new CraftingOut[]{ output };
            }

            public CraftingRecipe(CraftingIn[] input, CraftingOut[] output) {
                Input=input;
                Output=output;
            }

            public CraftingRecipe(CraftingIn input, CraftingOut[] output) {
                Input=new CraftingIn[]{input };
                Output=output;
            }

            public static CraftingIn AnySaw() {
                return new CraftingIn(
                    new ItemNonInv[]{
                        new ItemNonInvTool((ushort)Items.SawIron,1),
                        new ItemNonInvTool((ushort)Items.SawBronze,1),
                        new ItemNonInvTool((ushort)Items.SawCopper,1),
                        new ItemNonInvTool((ushort)Items.SawAluminium,1),
                        new ItemNonInvTool((ushort)Items.SawGold,1),
                        new ItemNonInvTool((ushort)Items.SawSteel,1),
                        new ItemNonInvTool((ushort)Items.ElectricSaw,1)
                    }
                );
            }

            public static CraftingIn AnyShears() {
                return new CraftingIn(
                    new ItemNonInv[]{
                        new ItemNonInvTool((ushort)Items.ShearsBronze,1),
                        new ItemNonInvTool((ushort)Items.ShearsCopper,1),
                        new ItemNonInvTool((ushort)Items.ShearsIron,1),
                        new ItemNonInvTool((ushort)Items.ShearsAluminium,1),
                        new ItemNonInvTool((ushort)Items.ShearsSteel,1),
                        new ItemNonInvTool((ushort)Items.ShearsGold,1),
                    }
                );
            }

            public static CraftingIn AnyHammer() {
                return new CraftingIn(
                    new ItemNonInv[]{
                        new ItemNonInvTool((ushort)Items.HammerBronze, 1),
                        new ItemNonInvTool((ushort)Items.HammerIron, 1),
                        new ItemNonInvTool((ushort)Items.HammerCopper, 1),
                        new ItemNonInvTool((ushort)Items.HammerGold, 1),
                        new ItemNonInvTool((ushort)Items.HammerSteel, 1),
                        new ItemNonInvTool((ushort)Items.HammerAluminium, 1),
                    }
                );
            }

            public static CraftingIn AnyWater(int a) {
                return new CraftingIn(new ItemNonInv[]{new ItemNonInvTool((ushort)Items.BottleWater,a), new ItemNonInvTool((ushort)Items.BucketWater,a)/*,new ItemNonInv((ushort)Items.JugWithWater,a)*/});
            }

            public static CraftingIn AnyOil(int a) {
                return new CraftingIn(new ItemNonInv[]{new ItemNonInvTool((ushort)Items.BottleOil,a), new ItemNonInvTool((ushort)Items.BucketOil,a)});
            }

            public static CraftingIn AnyWood(int a) {
                return new CraftingIn(
                    new ItemNonInv[]{
                        new ItemNonInvBasic((ushort)Items.WoodApple,a),
                        new ItemNonInvBasic((ushort)Items.WoodCherry,a),
                        new ItemNonInvBasic((ushort)Items.WoodLemon,a),
                        new ItemNonInvBasic((ushort)Items.WoodLinden,a),
                        new ItemNonInvBasic((ushort)Items.WoodOak,a),
                        new ItemNonInvBasic((ushort)Items.WoodOrange,a),
                        new ItemNonInvBasic((ushort)Items.WoodPine,a),
                        new ItemNonInvBasic((ushort)Items.WoodPlum,a),
                        new ItemNonInvBasic((ushort)Items.WoodSpruce,a),
                        new ItemNonInvBasic((ushort)Items.AcaciaWood,a),
                        new ItemNonInvBasic((ushort)Items.EucalyptusWood,a),
                        new ItemNonInvBasic((ushort)Items.WillowWood,a),
                        new ItemNonInvBasic((ushort)Items.OliveWood,a),
                        new ItemNonInvBasic((ushort)Items.MangroveWood,a),
                        new ItemNonInvBasic((ushort)Items.KapokWood,a),
                    }
                );
            }

            public static CraftingIn AnySapling(int a) {
                return new CraftingIn(
                    new ItemNonInv[]{
                        new ItemNonInvBasic((ushort)Items.AppleSapling,a),
                        new ItemNonInvBasic((ushort)Items.AcaciaSapling,a),
                        new ItemNonInvBasic((ushort)Items.CherrySapling,a),
                        new ItemNonInvBasic((ushort)Items.EucalyptusSapling,a),
                        new ItemNonInvBasic((ushort)Items.KapokSapling,a),
                        new ItemNonInvBasic((ushort)Items.LemonSapling,a),
                        new ItemNonInvBasic((ushort)Items.LindenSapling,a),
                        new ItemNonInvBasic((ushort)Items.MangroveSapling,a),
                        new ItemNonInvBasic((ushort)Items.OakSapling,a),
                        new ItemNonInvBasic((ushort)Items.OliveSapling,a),
                        new ItemNonInvBasic((ushort)Items.OrangeSapling,a),
                        new ItemNonInvBasic((ushort)Items.PineSapling,a),
                        new ItemNonInvBasic((ushort)Items.PlumSapling,a),
                        new ItemNonInvBasic((ushort)Items.RubberTreeSapling,a),
                        new ItemNonInvBasic((ushort)Items.WillowSapling,a),
                    }
                );
            }
        }

    public class CraftingOut {

        public ItemNonInv Item;
        public float ChanceToDrop;//% 100%=everytime, 50%=half, 0%=100%
        // public int ChanceMax;
        public bool EveryTime;

        public CraftingOut() {}

        public CraftingOut(ItemNonInv item) {
            Item=item;
            EveryTime=true;
        }

        public CraftingOut(ItemNonInv x, float chanceToDrop) {
            Item=x;
           // new ItemNonInv(x, Rabcr.random.Next(chanceMin, chanceMax));
            EveryTime=false;
            ChanceToDrop=chanceToDrop;
        }
    }

    static class GameMethods {


        public static bool IsHalfShadowBlock(ushort id) { 
			switch (id) { 
				case (ushort)BlockId.AcaciaLeaves: return true;
				case (ushort)BlockId.AppleLeaves: return true;
				case (ushort)BlockId.AppleLeavesWithApples: return true;
				case (ushort)BlockId.AppleLeavesBlossom: return true;
				case (ushort)BlockId.CherryLeaves: return true;
				case (ushort)BlockId.CherryLeavesBlossom: return true;
				case (ushort)BlockId.CherryLeavesWithCherries: return true;
				case (ushort)BlockId.EucalyptusLeaves: return true;
				case (ushort)BlockId.KapokLeaves: return true;
				case (ushort)BlockId.LemonLeaves: return true;
				case (ushort)BlockId.LemonLeavesWithLemons: return true;
				case (ushort)BlockId.LindenLeaves: return true;
				case (ushort)BlockId.MangroveLeaves: return true;
				case (ushort)BlockId.OakLeaves: return true;
				case (ushort)BlockId.OliveLeaves: return true;
				case (ushort)BlockId.OliveLeavesWithOlives: return true;
				case (ushort)BlockId.OrangeLeaves: return true;
				case (ushort)BlockId.OrangeLeavesWithOranges: return true;
				case (ushort)BlockId.PineLeaves: return true;
				case (ushort)BlockId.PlumLeaves: return true;
				case (ushort)BlockId.PlumLeavesBlossom: return true;
				case (ushort)BlockId.PlumLeavesWithPlums: return true;
				case (ushort)BlockId.RubberTreeLeaves: return true;
				case (ushort)BlockId.SpruceLeaves: return true;
				case (ushort)BlockId.WillowLeaves: return true;

				case (ushort)BlockId.Ice: return true;
				case (ushort)BlockId.WaterBlock: return true;
				case (ushort)BlockId.WaterSalt: return true;
			}
			return false;
		}

        public static bool IsLeaves(ushort id) { 
			switch (id) { 
				case (ushort)BlockId.AcaciaLeaves: return true;
				case (ushort)BlockId.AppleLeaves: return true;
				case (ushort)BlockId.AppleLeavesWithApples: return true;
				case (ushort)BlockId.AppleLeavesBlossom: return true;
				case (ushort)BlockId.CherryLeaves: return true;
				case (ushort)BlockId.CherryLeavesBlossom: return true;
				case (ushort)BlockId.CherryLeavesWithCherries: return true;
				case (ushort)BlockId.EucalyptusLeaves: return true;
				case (ushort)BlockId.KapokLeaves: return true;
				case (ushort)BlockId.LemonLeaves: return true;
				case (ushort)BlockId.LemonLeavesWithLemons: return true;
				case (ushort)BlockId.LindenLeaves: return true;
				case (ushort)BlockId.MangroveLeaves: return true;
				case (ushort)BlockId.OakLeaves: return true;
				case (ushort)BlockId.OliveLeaves: return true;
				case (ushort)BlockId.OliveLeavesWithOlives: return true;
				case (ushort)BlockId.OrangeLeaves: return true;
				case (ushort)BlockId.OrangeLeavesWithOranges: return true;
				case (ushort)BlockId.PineLeaves: return true;
				case (ushort)BlockId.PlumLeaves: return true;
				case (ushort)BlockId.PlumLeavesBlossom: return true;
				case (ushort)BlockId.PlumLeavesWithPlums: return true;
				case (ushort)BlockId.RubberTreeLeaves: return true;
				case (ushort)BlockId.SpruceLeaves: return true;
				case (ushort)BlockId.WillowLeaves: return true;
			}
			return false;
		}

        public static bool IsSelectedShears(ushort id) { 
            switch (id) { 
                case (ushort)Items.ShearsCopper: return true;	
                case (ushort)Items.ShearsBronze: return true;
			    case (ushort)Items.ShearsGold: return true;
			    case (ushort)Items.ShearsIron: return true;
			    case (ushort)Items.ShearsSteel: return true;
			    case (ushort)Items.ShearsAluminium: return true;
            }
	
			return false;
		}

		public static bool IsSelectedKnife(ushort id) { 
            switch (id) {
			    case (ushort)Items.KnifeCopper: return true;
			    case (ushort)Items.KnifeBronze: return true;
			    case (ushort)Items.KnifeGold: return true;
			    case (ushort)Items.KnifeIron: return true;
			    case (ushort)Items.KnifeSteel: return true;
			    case (ushort)Items.KnifeAluminium: return true;
            }
			return false;
		}

        public static int GetItemNameId(ushort id) {
            switch (id) {
                // Blocks
                #region Wood
                case (ushort)Items.WoodOak: return 1085;
                case (ushort)Items.WoodSpruce: return 1086;
                case (ushort)Items.WoodLinden: return 1087;
                case (ushort)Items.WoodPine: return 1088;
                case (ushort)Items.WoodApple: return 1089;
                case (ushort)Items.WoodCherry: return 1090;
                case (ushort)Items.WoodPlum: return 1091;
                case (ushort)Items.WoodLemon: return 1092;
                case (ushort)Items.WoodOrange: return 1093;
                case (ushort)Items.WillowWood: return 1112;
                case (ushort)Items.MangroveWood: return 1114;
                case (ushort)Items.EucalyptusWood: return 1116;
                case (ushort)Items.OliveWood: return 1119;
                #endregion

                #region Leaves
                case (ushort)Items.AppleLeaves: return 1096;
                case (ushort)Items.LemonLeavesWithLemons: return 1097;
                case (ushort)Items.LindenLeaves: return 1098;
                case (ushort)Items.OakLeaves: return 1099;
                case (ushort)Items.OrangeLeaves: return 1100;
                case (ushort)Items.SpruceLeaves: return 1101;
                case (ushort)Items.PlumLeavesWithPlums: return 1102;
                case (ushort)Items.PlumLeaves: return 1103;
                case (ushort)Items.PineLeaves: return 1104;
                case (ushort)Items.OrangeLeavesWithOranges: return 1105;
                case (ushort)Items.AppleLeavesWithApples: return 1106;
                case (ushort)Items.CherryLeaves: return 1107;
                case (ushort)Items.CherryLeavesWithCherries: return 1108;
                case (ushort)Items.LemonLeaves: return 1109;
                case (ushort)Items.KapokFibre: return 1110;
                case (ushort)Items.WillowLeaves: return 1111;
                case (ushort)Items.MangroveLeaves: return 1113;
                case (ushort)Items.EucalyptusLeaves: return 1115;
                case (ushort)Items.OliveLeavesWithOlives: return 1117;
                case (ushort)Items.OliveLeaves: return 1118;
                #endregion

                #region Ore
                case (ushort)Items.OreCoal: return 1248;
                case (ushort)Items.OreGold: return 1249;
                case (ushort)Items.OreTin: return 1250;
                case (ushort)Items.OreSilver: return 1251;
                case (ushort)Items.OreIron: return 1252;
                case (ushort)Items.OreCopper: return 1253;
                case (ushort)Items.OreAluminium: return 1254;
                #endregion

                #region Stone
                case (ushort)Items.StoneAnorthosite: return 1064;
                case (ushort)Items.StoneBasalt: return 1065;
                case (ushort)Items.StoneLimestone: return 1066;
                case (ushort)Items.StoneRhyolite: return 1067;
                case (ushort)Items.StoneGneiss: return 1068;
                case (ushort)Items.StoneSandstone: return 1069;
                case (ushort)Items.StoneSchist: return 1070;
                case (ushort)Items.StoneGabbro: return 1071;
                case (ushort)Items.StoneDiorit: return 1072;
                case (ushort)Items.StoneDolomite: return 1073;
                case (ushort)Items.StoneMudstone: return 1074;
                case (ushort)Items.StoneFlint: return 1075;
                #endregion

                #region BackStone
                case (ushort)Items.BackAnorthosite: return 1143;
                case (ushort)Items.BackBasalt: return 1144;
                case (ushort)Items.BackLimestone: return 1151;
                case (ushort)Items.BackRhyolite: return 1155;
                case (ushort)Items.BackGneiss: return 1150;
                case (ushort)Items.BackSandstone: return 1156;
                case (ushort)Items.BackSchist: return 1157;
                case (ushort)Items.BackGabbro: return 1149;
                case (ushort)Items.BackDiorit: return 1146;
                case (ushort)Items.BackDolomite: return 1147;
                case (ushort)Items.BackMudstone: return 1152;
                case (ushort)Items.BackFlint: return 1148;
                #endregion

                #region Basic blocks
                case (ushort)Items.Dirt: return 1077;
                case (ushort)Items.Sand: return 1078;
                case (ushort)Items.Gravel: return 1081;
                case (ushort)Items.Snow: return 1082;
                case (ushort)Items.Ice: return 1083;
                case (ushort)Items.Clay: return 1084;
                #endregion

                #region Saplings
                case (ushort)Items.OakSapling: return 1281;
                case (ushort)Items.LindenSapling: return 1282;
                case (ushort)Items.PineSapling: return 1283;
                case (ushort)Items.AppleSapling: return 1284;
                case (ushort)Items.LemonSapling: return 1285;
                case (ushort)Items.CherrySapling: return 1286;
                case (ushort)Items.PlumSapling: return 1287;
                case (ushort)Items.SpruceSapling: return 1288;
                case (ushort)Items.OrangeSapling: return 1289;
                case (ushort)Items.AcaciaSapling: return 1133;
                case (ushort)Items.KapokSapling: return 1134;
                case (ushort)Items.RubberTreeSapling: return 1132;
                case (ushort)Items.OliveSapling: return 1131;
                case (ushort)Items.EucalyptusSapling: return 1130;
                case (ushort)Items.MangroveSapling: return 1129;
                case (ushort)Items.WillowSapling: return 1128;
                #endregion

                #region Plants
                case (ushort)Items.Dandelion: return 1290;
                case (ushort)Items.PlantRose: return 1291;
                case (ushort)Items.PlantViolet: return 1293;
                case (ushort)Items.PlantOrchid: return 1292;

                case (ushort)Items.Heater: return 1317;
                case (ushort)Items.Alore: return 1318;

                case (ushort)Items.PlantStrawberry: return 1294;
                case (ushort)Items.PlantBlueberry: return 1296;
                case (ushort)Items.PlantRashberry: return 1295;

                case (ushort)Items.CactusBig: return 1297;
                case (ushort)Items.CactusSmall: return 1298;
                #endregion

                #region Grass block
                case (ushort)Items.GrassBlockDesert: return 1135;
                case (ushort)Items.GrassBlockForest: return 1136;
                case (ushort)Items.GrassBlockHills: return 1137;
                case (ushort)Items.GrassBlockJungle: return 1138;
                case (ushort)Items.GrassBlockPlains: return 1139;
                case (ushort)Items.GrassBlockClay: return 1140;
                case (ushort)Items.GrassBlockCompost: return 1141;
                #endregion

                #region Electrical mashines
                case (ushort)Items.Macerator: return 1194;
                case (ushort)Items.Miner: return 1193;
                case (ushort)Items.OxygenMachine: return 1192;
                case (ushort)Items.Lamp: return 1195;
                case (ushort)Items.Radio: return 1196;
                case (ushort)Items.FurnaceElectric: return 1199;
                case (ushort)Items.Charger: return 1204;
                #endregion

                #region Generating
                case (ushort)Items.WindMill: return 1189;
                case (ushort)Items.WaterMill: return 1190;
                case (ushort)Items.SolarPanel: return 1191;
                #endregion

                #region Mechanical
                case (ushort)Items.FurnaceStone: return 1200;
                case (ushort)Items.Shelf: return 1201;
                case (ushort)Items.Barrel: return 1433;
                case (ushort)Items.BoxAdv: return 1202;
                case (ushort)Items.BoxWooden: return 1203;
                case (ushort)Items.Rocket: return 1198;
                #endregion

                // Items
                #region Rocks
                case (ushort)Items.ItemCoal: return 1239;
                case (ushort)Items.ItemGold: return 1240;
                case (ushort)Items.ItemSilver: return 1242;
                case (ushort)Items.ItemTin: return 1241;
                case (ushort)Items.ItemIron: return 1243;
                case (ushort)Items.ItemCopper: return 1244;
                case (ushort)Items.Aluminium: return 1247;

                case (ushort)Items.Saphirite: return 1255;
                case (ushort)Items.Diamond: return 1256;
                case (ushort)Items.Smaragd: return 1257;
                case (ushort)Items.Ruby: return 1258;

                case (ushort)Items.SmallStone: return 1259;
                case (ushort)Items.BigStone: return 1260;
                case (ushort)Items.MediumStone: return 1261;
                #endregion

                #region Tools
                case (ushort)Items.AxeStone: return 1001;
                case (ushort)Items.ShovelStone: return 1002;
                case (ushort)Items.PickaxeStone: return 1003;

                case (ushort)Items.AxeIron: return 1004;
                case (ushort)Items.ShovelIron: return 1005;
                case (ushort)Items.PickaxeIron: return 1006;

                case (ushort)Items.HammerBronze: return 1007;
                case (ushort)Items.HammerIron: return 1008;

                case (ushort)Items.ShearsCopper: return 1009;
                case (ushort)Items.ShearsBronze: return 1010;
                case (ushort)Items.ShearsIron: return 1011;

                case (ushort)Items.SawCopper: return 1012;
                case (ushort)Items.SawBronze: return 1013;
                case (ushort)Items.SawIron: return 1014;

                case (ushort)Items.ElectricDrill: return 1015;
                case (ushort)Items.ElectricSaw: return 1016;

                case (ushort)Items.ElectricDrillOff: return 1015;
                case (ushort)Items.ElectricSawOff: return 1016;

                case (ushort)Items.KnifeIron: return 1017;
                case (ushort)Items.KnifeCopper: return 1018;
                case (ushort)Items.KnifeBronze: return 1019;

                case (ushort)Items.LighterON: return 1020;
                case (ushort)Items.LighterOFF: return 1020;
                case (ushort)Items.TorchElectricOFF: return 1021;
                case (ushort)Items.TorchElectricON: return 1021;

                case (ushort)Items.TorchON: return 1022;
                case (ushort)Items.TorchOFF: return 1022;

                case (ushort)Items.HoeStone: return 1028;
                case (ushort)Items.HoeCopper: return 1029;
                case (ushort)Items.HoeBronze: return 1030;
                case (ushort)Items.HoeIron: return 1031;

                case (ushort)Items.Gun: return 1033;
                #endregion

                #region Liquids
                case (ushort)Items.BottleWater: return 1023;
                case (ushort)Items.BottleOil: return 1025;
                case (ushort)Items.BucketWater: return 1026;
                case (ushort)Items.BucketOil: return 1027;
                #endregion

                #region Electronics
                case (ushort)Items.Bulb: return 1262;
                case (ushort)Items.Circuit: return 1263;
                case (ushort)Items.Battery: return 1264;
                case (ushort)Items.BigCircuit: return 1265;
                case (ushort)Items.Condenser: return 1271;
                case (ushort)Items.Diode: return 1272;
                case (ushort)Items.BareLabel: return 1273;
                case (ushort)Items.Motor: return 1274;
                case (ushort)Items.Rezistance: return 1275;
                case (ushort)Items.Tranzistor: return 1276;
                #endregion

                #region Clothes
                case (ushort)Items.Backpack: return 1377;
                case (ushort)Items.JacketShort: return 1376;
                case (ushort)Items.JacketFormal: return 1374;
                case (ushort)Items.JacketDenim: return 1373;
                case (ushort)Items.Coat: return 1372;
                case (ushort)Items.CoatArmy: return 1371;
                case (ushort)Items.BikiniTop: return 1370;
                case (ushort)Items.Bra: return 1368;
                case (ushort)Items.BikiniDown: return 1365;
                case (ushort)Items.Swimsuit: return 1363;
                case (ushort)Items.Panties: return 1362;
                case (ushort)Items.BoxerShorts: return 1360;
                case (ushort)Items.Underpants: return 1358;
                case (ushort)Items.SpaceHelmet: return 1357;
                case (ushort)Items.Crown: return 1356;
                case (ushort)Items.Hat: return 1355;
                case (ushort)Items.Cap: return 1354;
                case (ushort)Items.Shirt: return 1353;
                case (ushort)Items.Dress: return 1352;
                case (ushort)Items.SpaceSuit: return 1350;
                case (ushort)Items.TShirt: return 1148;
                case (ushort)Items.Skirt: return 1346;
                case (ushort)Items.ArmyTrousers: return 1345;
                case (ushort)Items.SpaceTrousers: return 1344;
                case (ushort)Items.Shorts: return 1343;
                case (ushort)Items.Jeans: return 1342;
                case (ushort)Items.SpaceBoots: return 1341;
                case (ushort)Items.Sneakers: return 1340;
                case (ushort)Items.Pumps: return 1339;
                case (ushort)Items.FormalShoes: return 1338;
                #endregion


                #region Natureful items
                case (ushort)Items.FlaxSeeds: return 1321;
                case (ushort)Items.Hay: return 1323;
                case (ushort)Items.Seeds: return 1320;
                case (ushort)Items.WheatSeeds: return 1319;

                #endregion

                #region Foods
                case (ushort)Items.Banana: return 1205;
                case (ushort)Items.Cherry: return 1206;
                case (ushort)Items.Lemon: return 1207;
                case (ushort)Items.Orange: return 1208;
                case (ushort)Items.Plum: return 1209;
                case (ushort)Items.Apple: return 1210;

                case (ushort)Items.Rashberry: return 1211;
                case (ushort)Items.Strawberry: return 1212;
                case (ushort)Items.Blueberries: return 1213;

                case (ushort)Items.RabbitMeatCooked: return 1214;
                case (ushort)Items.RabbitMeat: return 1215;

                case (ushort)Items.FishMeat: return 1216;
                case (ushort)Items.FishMeatCooked: return 1217;
                #endregion

                case (ushort)Items.AngelHair: return 1502;

                case (ushort)Items.ChristmasBallGray: return 1503;
                case (ushort)Items.ChristmasBallBlue: return 1504;
                case (ushort)Items.ChristmasBallLightGreen: return 1511;
                case (ushort)Items.ChristmasBallOrange: return 1506;
                case (ushort)Items.ChristmasBallPink: return 1508;
                case (ushort)Items.ChristmasBallPurple: return 1509;
                case (ushort)Items.ChristmasBallRed: return 1507;
                case (ushort)Items.ChristmasBallTeal: return 1512;
                case (ushort)Items.ChristmasBallYellow: return 1505;

                case (ushort)Items.ChristmasStar: return 1473;

                case (ushort)Items.Lava: return 1079;

                 case (ushort)Items.Label: return 1197;

                case (ushort)Items.SnowTop: return 1094;
                case (ushort)Items.Oil: return 1095;
              case (ushort)Items.CoalWood: return 1246;


                case (ushort)Items.Ash: return 1245;
                case (ushort)Items.OneBrick: return 1266;
                case (ushort)Items.Nail: return 1267;
                case (ushort)Items.Cloth: return 1268;
                case (ushort)Items.Yarn: return 1269;
                case (ushort)Items.MudIngot: return 1270;

                case (ushort)Items.Silicium: return 1277;
                case (ushort)Items.Rod: return 1278;
                case (ushort)Items.Plastic: return 1279;
                case (ushort)Items.Paper: return 1280;



                case (ushort)Items.Resin: return 1336;
                case (ushort)Items.BucketForRubber: return 1335;
                case (ushort)Items.HoeHeadCopper: return 1334;
                case (ushort)Items.Sticks: return 1047;

                case (ushort)Items.PickaxeCopper: return 1406;
                case (ushort)Items.AxeCopper: return 1407;
                case (ushort)Items.ShovelCopper: return 1408;

                case (ushort)Items.HammerGold: return 1409;
                case (ushort)Items.HammerSteel: return 1410;
                case (ushort)Items.HammerAluminium: return 1411;
                case (ushort)Items.HammerCopper: return 1412;
                case (ushort)Items.SewingMachine: return 1332;
                case (ushort)Items.Ladder: return 1177;
                case (ushort)Items.Composter: return 181;
                case (ushort)Items.BackClay: return 1145;
                case (ushort)Items.OreSulfur: return 1062;
                case (ushort)Items.Saltpeter: return 1061;
                case (ushort)Items.OreSaltpeter: return 1063;
                case (ushort)Items.Compost: return 1331;
                case (ushort)Items.HayBlock: return 1180;
                case (ushort)Items.Desk: return 158;
                case (ushort)Items.Stonerubble: return 1080;
                case (ushort)Items.KapokLeacesFlowering: return 1124;
                case (ushort)Items.KapokLeavesFibre: return 1125;
                case (ushort)Items.AcaciaLeaves: return 1122;
                case (ushort)Items.AcaciaWood: return 1123;
                case (ushort)Items.RubberTreeLeaves: return 1120;
                case (ushort)Items.RubberTreeWood: return 1121;
                case (ushort)Items.KapokLeaves: return 1126;
                case (ushort)Items.KapokWood: return 1127;
                case (ushort)Items.Planks: return 1174;
                case (ushort)Items.Glass: return 1172;
                case (ushort)Items.Bricks: return 1173;
                case (ushort)Items.Roof1: return 1167;
                case (ushort)Items.Roof2: return 1168;
                case (ushort)Items.AdvancedSpaceBlock: return 1183;
                case (ushort)Items.AdvancedSpaceFloor: return 1184;
                case (ushort)Items.AdvancedSpaceWindow: return 1182;
                case (ushort)Items.AdvancedSpacePart1: return 1185;
                case (ushort)Items.AdvancedSpacePart2: return 1186;
                case (ushort)Items.AdvancedSpacePart3: return 1187;
                case (ushort)Items.AdvancedSpacePart4: return 1188;
                case (ushort)Items.BackCopper: return 1159;
                case (ushort)Items.BackCoal: return 1158;
                case (ushort)Items.BackTin: return 1160;
                case (ushort)Items.BackIron: return 1161;
                case (ushort)Items.BackAluminium: return 1162;
                case (ushort)Items.BackSilver: return 1163;
                case (ushort)Items.BackGold: return 1164;
                case (ushort)Items.BackSulfur: return 1165;
                case (ushort)Items.BackSaltpeter: return 1166;
                case (ushort)Items.AdvancedSpaceBack: return 1181;
                case (ushort)Items.BackCobblestone: return 1169;
                case (ushort)Items.BackSand: return 1170;
                case (ushort)Items.BackRegolite: return 1154;
                case (ushort)Items.BackDirt: return 1171;
                case (ushort)Items.Door: return 1176;
                case (ushort)Items.StoneHead: return 1053;
                case (ushort)Items.KnifeGold: return 1413;
                case (ushort)Items.HoeGold: return 1414;
                case (ushort)Items.ShovelGold: return 1415;
                case (ushort)Items.PickaxeGold: return 1416;
                case (ushort)Items.ShearsGold: return 1417;
                case (ushort)Items.SawGold: return 1418;
                case (ushort)Items.PickaxeSteel: return 1419;
                case (ushort)Items.SawAluminium: return 1420;
                case (ushort)Items.ShearsAluminium: return 1421;
                case (ushort)Items.KnifeAluminium: return 1422;
                case (ushort)Items.HoeAluminium: return 1423;
                case (ushort)Items.ShovelAluminium: return 1424;
                case (ushort)Items.PickaxeAluminium: return 1430;
                case (ushort)Items.SawSteel: return 1429;
                case (ushort)Items.ShearsSteel: return 1428;
                case (ushort)Items.KnifeSteel: return 1427;
                case (ushort)Items.HoeSteel: return 1426;
                case (ushort)Items.ShovelSteel: return 1425;
                case (ushort)Items.Ammo: return 1058;
                case (ushort)Items.AirTank: return 1034;
                case (ushort)Items.AirTank2: return 1035;
                case (ushort)Items.Bucket: return 1048;
                case (ushort)Items.Bottle: return 1045;
                case (ushort)Items.Boletus: return 1307;
                case (ushort)Items.Champignon: return 1308;
                case (ushort)Items.Toadstool: return 1306;
                case (ushort)Items.Coral: return 1309;
                case (ushort)Items.Seaweed: return 1310;
                case (ushort)Items.PlantSeaweed: return 1310;
                case (ushort)Items.GrassPlains: return 1316;
                case (ushort)Items.GrassJungle: return 1315;
                case (ushort)Items.GrassHills: return 1314;
                case (ushort)Items.GrassForest: return 1313;
                case (ushort)Items.GrassDesert: return 1312;
                case (ushort)Items.Flax: return 1311;
                case (ushort)Items.PlantOnion: return 1301;
                case (ushort)Items.PlantPeas: return 1304;
                case (ushort)Items.PlantCarrot: return 1302;
                case (ushort)Items.SugarCane: return 1299;
                case (ushort)Items.Leave: return 1324;
                case (ushort)Items.Stick: return 1325;
                case (ushort)Items.WheatStraw: return 1322;
                case (ushort)Items.Onion: return 1301;
                case (ushort)Items.Carrot: return 1302;
                case (ushort)Items.Peas: return 1305;
                case (ushort)Items.boiledEgg: return 1044;
                case (ushort)Items.Egg: return 1043;
                case (ushort)Items.BowlWithVegetables: return 1052;
                case (ushort)Items.BowlWithMushrooms: return 1051;
                case (ushort)Items.BowlEmpty: return 1050;
                case (ushort)Items.SulfurDust: return 1059;
                case (ushort)Items.Gunpowder: return 1060;
                case (ushort)Items.CoalDust: return 1218;
                case (ushort)Items.BronzeDust: return 1219;
                case (ushort)Items.CopperDust: return 1223;
                case (ushort)Items.PlateBronze: return 1235;
                case (ushort)Items.plateAluminium: return 1236;
                case (ushort)Items.TinIngot: return 1230;
                case (ushort)Items.SilverIngot: return 1231;
                case (ushort)Items.IronIngot: return 1229;
                case (ushort)Items.GoldIngot: return 1228;
                case (ushort)Items.CopperIngot: return 1232;
                case (ushort)Items.BronzeIngot: return 1227;
                case (ushort)Items.SteelIngot: return 1472;
                case (ushort)Items.TinDust: return 1224;
                case (ushort)Items.SilverDust: return 1222;
                case (ushort)Items.IronDust: return 1221;
                case (ushort)Items.GoldDust: return 1220;
                case (ushort)Items.AnimalChicken: return 1328;
                case (ushort)Items.AnimalFish: return 1216;
                case (ushort)Items.Rubber: return 1327;
                case (ushort)Items.Rope: return 1179;
                case (ushort)Items.AnimalRabbit: return 1329;
                case (ushort)Items.AnimalParrot: return 1584;
                case (ushort)Items.ItemBattery: return 1264;
                case (ushort)Items.PlateIron: return 1234;
                case (ushort)Items.PlateGold: return 1238;
                case (ushort)Items.PlateCopper: return 1237;
                case (ushort)Items.AxeGold: return 1431;
                case (ushort)Items.AxeAluminium: return 1432;
                case (ushort)Items.WoodDust: return 1226;
                case (ushort)Items.AluminiumDust: return 1225;
                case (ushort)Items.Olive: return 1076;

                case (ushort)Items.DyeArmy: return 1399;
                case (ushort)Items.DyeBlack: return 1398;
                case (ushort)Items.DyeBlue: return 1388;
                case (ushort)Items.DyeBrown: return 1394;
                case (ushort)Items.DyeDarkBlue: return 1389;
                case (ushort)Items.DyeDarkGray: return 1397;
                case (ushort)Items.DyeDarkGreen: return 1393;
                case (ushort)Items.DyeDarkRed: return 1384;
                case (ushort)Items.DyeGold: return 1381;
                case (ushort)Items.DyeGray: return 1396;
                case (ushort)Items.DyeGreen: return 1392;
                case (ushort)Items.DyeLightBlue: return 1387;
                case (ushort)Items.DyeLightGray: return 1395;
                case (ushort)Items.DyeLightGreen: return 1391;
                case (ushort)Items.DyeMagenta: return 1400;
                case (ushort)Items.DyeOlive: return 1404;
                case (ushort)Items.DyeOrange: return 1382;
                case (ushort)Items.DyePink: return 1385;
                case (ushort)Items.DyePurple: return 1386;
                case (ushort)Items.DyeRed: return 1383;
                case (ushort)Items.DyeRoseQuartz: return 1401;
                case (ushort)Items.DyeSpringGreen: return 1402;
                case (ushort)Items.DyeTeal: return 1390;
                case (ushort)Items.DyeViolet: return 1403;
                case (ushort)Items.DyeWhite: return 1378;
                case (ushort)Items.DyeYellow: return 1380;
                case (ushort)Items.TestTube: return 1405;

                case (ushort)Items.Flag: return 1178;

                case (ushort)Items.ShearsHeadCopper: return 1435;
                case (ushort)Items.ShearsHeadBronze: return 1434;
                case (ushort)Items.ShearsHeadGold: return 1436;
                case (ushort)Items.ShearsHeadIron: return 1437;
                case (ushort)Items.ShearsHeadSteel: return 1438;
                case (ushort)Items.ShearsHeadAluminium: return 1439;

                case (ushort)Items.AxeHeadCopper: return 1440;
                case (ushort)Items.AxeHeadBronze: return 1441;
                case (ushort)Items.AxeHeadGold: return 1442;
                case (ushort)Items.AxeHeadIron: return 1443;
                case (ushort)Items.AxeHeadSteel: return 1444;
                case (ushort)Items.AxeHeadAluminium: return 1445;

                case (ushort)Items.HoeHeadBronze: return 1458;
                case (ushort)Items.HoeHeadGold: return 1459;
                case (ushort)Items.HoeHeadIron: return 1460;
                case (ushort)Items.HoeHeadSteel: return 1461;
                case (ushort)Items.HoeHeadAluminium: return 1462;

                case (ushort)Items.ShovelHeadCopper: return 1452;
                case (ushort)Items.ShovelHeadBronze: return 1453;
                case (ushort)Items.ShovelHeadGold: return 1454;
                case (ushort)Items.ShovelHeadIron: return 1455;
                case (ushort)Items.ShovelHeadSteel: return 1456;
                case (ushort)Items.ShovelHeadAluminium: return 1457;

                case (ushort)Items.PickaxeHeadCopper: return 1446;
                case (ushort)Items.PickaxeHeadBronze: return 1447;
                case (ushort)Items.PickaxeHeadGold: return 1448;
                case (ushort)Items.PickaxeHeadIron: return 1449;
                case (ushort)Items.PickaxeHeadSteel: return 1450;
                case (ushort)Items.PickaxeHeadAluminium: return 1451;

                case (ushort)Items.AxeSteel: return 1463;
                case (ushort)Items.ShovelBronze: return 1464;
                case (ushort)Items.PickaxeBronze: return 1465;

                case (ushort)Items.KnifeHeadCopper: return 1466;
                case (ushort)Items.KnifeHeadBronze: return 1467;
                case (ushort)Items.KnifeHeadGold: return 1468;
                case (ushort)Items.KnifeHeadIron: return 1469;
                case (ushort)Items.KnifeHeadSteel: return 1470;
                case (ushort)Items.KnifeHeadAluminium: return 1471;
            }
            #if DEBUG
            System.Diagnostics.Debug.WriteLine("Nenalezen popis itemu s id="+id+" ("+((Items)id)+")");
            #endif
            return 999;
        }

        public static ushort ToolToBasic(ushort i) {
            switch (i) {
                case (ushort)Items.BucketOil: return (ushort)Items.Bucket;
                case (ushort)Items.BucketWater: return (ushort)Items.Bucket;
                case (ushort)Items.TorchElectricON: return (ushort)Items.TorchElectricOFF;
                case (ushort)Items.LighterON: return (ushort)Items.LighterOFF;

                case (ushort)Items.BottleOil: return (ushort)Items.Bottle;
                case (ushort)Items.BottleWater: return (ushort)Items.Bottle;

                case (ushort)Items.ElectricDrill: return (ushort)Items.ElectricDrillOff;
                case (ushort)Items.ElectricSaw: return (ushort)Items.ElectricSawOff;
            }
            return (ushort)Items.None;
        }

        public static int ToolMax(ushort id) {
            //max uses
            switch (id) {

                case (ushort)Items.AxeStone: return 50;
                case (ushort)Items.PickaxeStone: return 50;
                case (ushort)Items.ShovelStone: return 50;
                case (ushort)Items.HoeStone: return 50;
                case (ushort)Items.HoeCopper: return 200;
                case (ushort)Items.KnifeCopper: return 200;
                case (ushort)Items.SawCopper: return 200;
                case (ushort)Items.ShearsCopper: return 200;
                case (ushort)Items.HammerCopper: return 200;
                case (ushort)Items.PickaxeCopper: return 200;
                case (ushort)Items.ShovelCopper: return 200;
                case (ushort)Items.AxeCopper: return 200;

                case (ushort)Items.HammerBronze: return 250;
                case (ushort)Items.HoeBronze: return 250;
                case (ushort)Items.KnifeBronze: return 250;
                case (ushort)Items.SawBronze: return 250;
                case (ushort)Items.ShearsBronze: return 250;
                case (ushort)Items.PickaxeBronze: return 250;
                case (ushort)Items.ShovelBronze: return 250;
                case (ushort)Items.AxeBronze: return 250;

                case (ushort)Items.AxeIron: return 300;
                case (ushort)Items.HammerIron: return 300;
                case (ushort)Items.HoeIron: return 300;
                case (ushort)Items.PickaxeIron: return 300;
                case (ushort)Items.ShovelIron: return 300;
                case (ushort)Items.KnifeIron: return 300;
                case (ushort)Items.SawIron: return 300;
                case (ushort)Items.ShearsIron: return 300;

                case (ushort)Items.AxeSteel: return 350;
                case (ushort)Items.HammerSteel: return 350;
                case (ushort)Items.HoeSteel: return 350;
                case (ushort)Items.PickaxeSteel: return 350;
                case (ushort)Items.ShovelSteel: return 350;
                case (ushort)Items.KnifeSteel: return 350;
                case (ushort)Items.SawSteel: return 350;
                case (ushort)Items.ShearsSteel: return 350;

                case (ushort)Items.AxeAluminium: return 150;
                case (ushort)Items.HammerAluminium: return 150;
                case (ushort)Items.HoeAluminium: return 150;
                case (ushort)Items.PickaxeAluminium: return 150;
                case (ushort)Items.ShovelAluminium: return 150;
                case (ushort)Items.KnifeAluminium: return 150;
                case (ushort)Items.SawAluminium: return 150;
                case (ushort)Items.ShearsAluminium: return 150;

                case (ushort)Items.AxeGold: return 5;
                case (ushort)Items.HammerGold: return 5;
                case (ushort)Items.HoeGold: return 5;
                case (ushort)Items.PickaxeGold: return 5;
                case (ushort)Items.ShovelGold: return 5;
                case (ushort)Items.KnifeGold: return 5;
                case (ushort)Items.SawGold: return 5;
                case (ushort)Items.ShearsGold: return 5;

                case (ushort)Items.ElectricDrill: return 400;
                case (ushort)Items.ElectricSaw: return 400;

                case (ushort)Items.TorchElectricON: return 400;

                case (ushort)Items.Gun: return 1000;
                case (ushort)Items.AirTank: return 1000;
                case (ushort)Items.AirTank2: return 2000;

                case (ushort)Items.BucketWater: return 255;
                case (ushort)Items.BucketOil: return 255;
                case (ushort)Items.BottleOil: return 50;
                case (ushort)Items.BottleWater: return 50;

                    case (ushort)Items.TorchON : return 100;

                    case (ushort)Items.DyeArmy: return 50;
                case (ushort)Items.DyeBlack: return 50;
                case (ushort)Items.DyeBlue: return 50;
                case (ushort)Items.DyeBrown: return 50;
                case (ushort)Items.DyeDarkBlue: return 50;
                case (ushort)Items.DyeDarkGray: return 50;
                case (ushort)Items.DyeDarkGreen: return 50;
                case (ushort)Items.DyeDarkRed: return 50;
                case (ushort)Items.DyeGold: return 50;
                case (ushort)Items.DyeGray: return 50;
                case (ushort)Items.DyeGreen: return 50;
                case (ushort)Items.DyeLightBlue: return 50;
                case (ushort)Items.DyeLightGray: return 50;
                case (ushort)Items.DyeLightGreen: return 50;
                case (ushort)Items.DyeMagenta: return 50;
                case (ushort)Items.DyeOlive: return 50;
                case (ushort)Items.DyeOrange: return 50;
                case (ushort)Items.DyePink: return 50;
                case (ushort)Items.DyePurple: return 50;
                case (ushort)Items.DyeRed: return 50;
                case (ushort)Items.DyeRoseQuartz: return 50;
                case (ushort)Items.DyeSpringGreen: return 50;
                case (ushort)Items.DyeTeal: return 50;
                case (ushort)Items.DyeViolet: return 50;
                case (ushort)Items.DyeWhite: return 50;
                case (ushort)Items.DyeYellow: return 50;
                case (ushort)Items.ItemBattery: return 99;
            }
            #if DEBUG
            throw new System.Exception("Tool "+(Items)id+" not found in switch above");
            #else
            return -1;
            #endif
        }

        public static int BurnWoodInFurnace(ushort id){
            switch (id){
                case (ushort)Items.ItemCoal: return 45;
                case (ushort)Items.CoalWood: return 40;
                case (ushort)Items.WoodOak: return 32;
                case (ushort)Items.WoodLinden: return 32;
                case (ushort)Items.WoodCherry: return 29;
                case (ushort)Items.WoodApple: return 30;
                case (ushort)Items.WoodLemon: return 29;
                case (ushort)Items.WoodSpruce: return 30;
                case (ushort)Items.WoodPlum: return 30;
                case (ushort)Items.WoodPine: return 29;
                case (ushort)Items.WoodOrange: return 30;
                case (ushort)Items.Stick: return 11;
                case (ushort)Items.CoalDust: return 10;
                case (ushort)Items.Sticks: return 9;
                case (ushort)Items.WoodDust: return 5;
                case (ushort)Items.Paper: return 2;
                case (ushort)Items.Gunpowder: return 1;
            }
            return 0;
        }

        public static bool IsCompostable(ushort id) {
            switch (id) {
                case (ushort)Items.Alore: return true;
                case (ushort)Items.Apple: return true;
                case (ushort)Items.AppleLeaves: return true;
                case (ushort)Items.AppleLeavesWithApples: return true;
                case (ushort)Items.AppleSapling: return true;
                case (ushort)Items.Ash: return true;
                case (ushort)Items.Banana: return true;
                case (ushort)Items.Blueberries: return true;
                case (ushort)Items.Boletus: return true;
                case (ushort)Items.CactusBig: return true;
                case (ushort)Items.CactusSmall: return true;
                case (ushort)Items.Carrot: return true;
                case (ushort)Items.Champignon: return true;
                case (ushort)Items.Cherry: return true;
                case (ushort)Items.CherryLeaves: return true;
                case (ushort)Items.CherryLeavesWithCherries: return true;
                case (ushort)Items.CherrySapling: return true;
                case (ushort)Items.Cloth: return true;
                case (ushort)Items.CoalDust: return true;
                case (ushort)Items.Coral: return true;
                case (ushort)Items.Dandelion: return true;
                case (ushort)Items.FishMeat: return true;
                case (ushort)Items.Flax: return true;
                case (ushort)Items.FlaxSeeds: return true;
                case (ushort)Items.GrassBlockClay: return true;
                case (ushort)Items.GrassBlockDesert: return true;
                case (ushort)Items.GrassBlockForest: return true;
                case (ushort)Items.GrassBlockHills: return true;
                case (ushort)Items.GrassBlockJungle: return true;
                case (ushort)Items.GrassBlockPlains: return true;
                case (ushort)Items.GrassDesert: return true;
                case (ushort)Items.GrassForest: return true;
                case (ushort)Items.GrassHills: return true;
                case (ushort)Items.GrassJungle: return true;
                case (ushort)Items.GrassPlains: return true;
                case (ushort)Items.Hay: return true;
                case (ushort)Items.HayBlock: return true;
                case (ushort)Items.Heater: return true;
                case (ushort)Items.Leave: return true;
                case (ushort)Items.Lemon: return true;
                case (ushort)Items.LemonLeaves: return true;
                case (ushort)Items.LemonLeavesWithLemons: return true;
                case (ushort)Items.LemonSapling: return true;
                case (ushort)Items.LindenLeaves: return true;
                case (ushort)Items.LindenSapling: return true;
                case (ushort)Items.MudIngot: return true;
                case (ushort)Items.OakLeaves: return true;
                case (ushort)Items.OakSapling: return true;
                case (ushort)Items.Onion: return true;
                case (ushort)Items.Orange: return true;
                case (ushort)Items.OrangeLeaves: return true;
                case (ushort)Items.OrangeLeavesWithOranges: return true;
                case (ushort)Items.OrangeSapling: return true;
                case (ushort)Items.Paper: return true;
                case (ushort)Items.Peas: return true;
                case (ushort)Items.PineLeaves: return true;
                case (ushort)Items.PineSapling: return true;
                case (ushort)Items.PlantBlueberry: return true;
                case (ushort)Items.PlantCarrot: return true;
                case (ushort)Items.PlantOnion: return true;
                case (ushort)Items.PlantOrchid: return true;
                case (ushort)Items.PlantPeas: return true;
                case (ushort)Items.PlantRashberry: return true;
                case (ushort)Items.PlantRose: return true;
                case (ushort)Items.PlantStrawberry: return true;
                case (ushort)Items.PlantViolet: return true;
                case (ushort)Items.Plum: return true;
                case (ushort)Items.PlumLeaves: return true;
                case (ushort)Items.PlumLeavesWithPlums: return true;
                case (ushort)Items.PlumSapling: return true;
                case (ushort)Items.RabbitMeat: return true;
                case (ushort)Items.RabbitMeatCooked: return true;
                case (ushort)Items.Rashberry: return true;
                case (ushort)Items.Rope: return true;
                case (ushort)Items.Seaweed: return true;
                case (ushort)Items.Seeds: return true;
                case (ushort)Items.Stick: return true;
                case (ushort)Items.Sticks: return true;
                case (ushort)Items.Strawberry: return true;
                case (ushort)Items.SugarCane: return true;
                case (ushort)Items.WheatStraw: return true;
                case (ushort)Items.Yarn: return true;
                case (ushort)Items.GrassBlockCompost: return true;
                case (ushort)Items.Egg: return true;
                case (ushort)Items.boiledEgg: return true;
                case (ushort)Items.Saltpeter: return true;
                default: return false;
            }
        }

        public static bool IsLeave(ushort id) { 
           switch (id) {
                // Frequent leaves
				case (ushort)BlockId.SpruceLeaves: return true;

                // Frequent branches
				case (ushort)BlockId.OakBranches: return true;
				case (ushort)BlockId.LindenBranches: return true;
				case (ushort)BlockId.WillowBranches: return true;

                // Fruit branches
				case (ushort)BlockId.AppleBranches: return true;
				case (ushort)BlockId.CherryBranches: return true;
				case (ushort)BlockId.PlumBranches: return true;

                // Non-frequent leaves
				case (ushort)BlockId.WillowLeaves: return true;
				case (ushort)BlockId.OakLeaves: return true;
				case (ushort)BlockId.LindenLeaves: return true;

                // Fruit leaves
				case (ushort)BlockId.AppleLeaves: return true;
				case (ushort)BlockId.AppleLeavesBlossom: return true;
				case (ushort)BlockId.AppleLeavesWithApples: return true;

				case (ushort)BlockId.CherryLeaves: return true;
				case (ushort)BlockId.CherryLeavesBlossom: return true;
				case (ushort)BlockId.CherryLeavesWithCherries: return true;

				case (ushort)BlockId.PlumLeaves: return true;
				case (ushort)BlockId.PlumLeavesBlossom: return true;
				case (ushort)BlockId.PlumLeavesWithPlums: return true;

                // Leaves in Hot biomes
				case (ushort)BlockId.OrangeLeaves: return true;
				case (ushort)BlockId.OrangeLeavesWithOranges: return true;

				case (ushort)BlockId.OliveLeaves: return true;
				case (ushort)BlockId.OliveLeavesWithOlives: return true;

				case (ushort)BlockId.LemonLeaves: return true;
				case (ushort)BlockId.LemonLeavesWithLemons: return true;

				case (ushort)BlockId.PineLeaves: return true;
                case (ushort)BlockId.AcaciaLeaves: return true;
				case (ushort)BlockId.EucalyptusLeaves: return true;
				case (ushort)BlockId.MangroveLeaves: return true;

				case (ushort)BlockId.RubberTreeLeaves: return true;

				case (ushort)BlockId.KapokLeaves: return true;
				case (ushort)BlockId.KapokLeacesFlowering: return true;
				case (ushort)BlockId.KapokLeacesFibre: return true;

            }
            return false;
        }

        #region Blocks from Items
        public static ushort BackBlockFromItem(ushort item) {
            switch (item) {

                // Blocks
                case (ushort)Items.Lava: return (ushort)BlockId.Lava;

                // Backs
                case (ushort)Items.BackCobblestone: return (ushort)BlockId.BackCobblestone;
                case (ushort)Items.BackSand: return (ushort)BlockId.BackSand;
                case (ushort)Items.BackDirt: return (ushort)BlockId.BackDirt;
                case (ushort)Items.BackAluminium: return (ushort)BlockId.BackAluminium;
                case (ushort)Items.BackAnorthosite: return (ushort)BlockId.BackAnorthosite;
                case (ushort)Items.BackBasalt: return (ushort)BlockId.BackBasalt;
                case (ushort)Items.BackClay: return (ushort)BlockId.BackClay;
                case (ushort)Items.BackCoal: return (ushort)BlockId.BackCoal;
                case (ushort)Items.BackCopper: return (ushort)BlockId.BackCopper;
                case (ushort)Items.BackDiorit: return (ushort)BlockId.BackDiorit;
                case (ushort)Items.BackDolomite: return (ushort)BlockId.BackDolomite;
                case (ushort)Items.BackFlint: return (ushort)BlockId.BackFlint;
                case (ushort)Items.BackGabbro: return (ushort)BlockId.BackGabbro;
                case (ushort)Items.BackGneiss: return (ushort)BlockId.BackGneiss;
                case (ushort)Items.BackGold: return (ushort)BlockId.BackGold;
                case (ushort)Items.BackGravel: return (ushort)BlockId.BackGravel;
                case (ushort)Items.BackIron: return (ushort)BlockId.BackIron;
                case (ushort)Items.BackLimestone: return (ushort)BlockId.BackLimestone;
                case (ushort)Items.BackMudstone: return (ushort)BlockId.BackMudstone;
                case (ushort)Items.BackRedSand: return (ushort)BlockId.BackRedSand;
                case (ushort)Items.BackRegolite: return (ushort)BlockId.BackRegolite;
                case (ushort)Items.BackRhyolite: return (ushort)BlockId.BackRhyolite;
                case (ushort)Items.BackSaltpeter: return (ushort)BlockId.BackSaltpeter;
                case (ushort)Items.BackSandstone: return (ushort)BlockId.BackSandstone;
                case (ushort)Items.BackSchist: return (ushort)BlockId.BackSchist;
                case (ushort)Items.BackSilver: return (ushort)BlockId.BackSilver;
                case (ushort)Items.BackSulfur: return (ushort)BlockId.BackSulfur;
                case (ushort)Items.BackTin: return (ushort)BlockId.BackTin;

                // Wood
                case (ushort)Items.WoodApple: return (ushort)BlockId.AppleWood;
                case (ushort)Items.WoodCherry: return (ushort)BlockId.CherryWood;
                case (ushort)Items.WoodLemon: return (ushort)BlockId.LemonWood;
                case (ushort)Items.WoodLinden: return (ushort)BlockId.LindenWood;
                case (ushort)Items.WoodOak: return (ushort)BlockId.OakWood;
                case (ushort)Items.WoodOrange: return (ushort)BlockId.OrangeWood;
                case (ushort)Items.WoodPine: return (ushort)BlockId.PineWood;
                case (ushort)Items.WoodPlum: return (ushort)BlockId.PlumWood;
                case (ushort)Items.WoodSpruce: return (ushort)BlockId.SpruceWood;
                case (ushort)Items.AcaciaWood: return (ushort)BlockId.AcaciaWood;
                case (ushort)Items.EucalyptusWood: return (ushort)BlockId.EucalyptusWood;
                case (ushort)Items.KapokWood: return (ushort)BlockId.KapokWood;
                case (ushort)Items.MangroveWood: return (ushort)BlockId.MangroveWood;
                case (ushort)Items.OliveWood: return (ushort)BlockId.OliveWood;
                case (ushort)Items.RubberTreeWood: return (ushort)BlockId.RubberTreeWood;
                case (ushort)Items.WillowWood: return (ushort)BlockId.WillowWood;


                case (ushort)Items.Glass: return (ushort)BlockId.Glass;
                case (ushort)Items.AdvancedSpaceBack: return (ushort)BlockId.AdvancedSpaceBack;
                case (ushort)Items.AdvancedSpaceWindow: return (ushort)BlockId.AdvancedSpaceWindow;
            }

            return (ushort)BlockId.None;
        }

        public static ushort SolidBlockFromItem(ushort item) {
            switch (item) {
                // Stone
                case (ushort)Items.StoneBasalt: return (ushort)BlockId.StoneBasalt;
                case (ushort)Items.StoneDiorit: return (ushort)BlockId.StoneDiorit;
                case (ushort)Items.StoneDolomite: return (ushort)BlockId.StoneDolomite;
                case (ushort)Items.StoneGabbro: return (ushort)BlockId.StoneGabbro;
                case (ushort)Items.StoneGneiss: return (ushort)BlockId.StoneGneiss;
                case (ushort)Items.StoneLimestone: return (ushort)BlockId.StoneLimestone;
                case (ushort)Items.StoneRhyolite: return (ushort)BlockId.StoneRhyolite;
                case (ushort)Items.StoneSandstone: return (ushort)BlockId.StoneSandstone;
                case (ushort)Items.StoneSchist: return (ushort)BlockId.StoneSchist;

                // Ore
                case (ushort)Items.OreAluminium: return (ushort)BlockId.OreAluminium;
                case (ushort)Items.OreCopper: return (ushort)BlockId.OreCopper;
                case (ushort)Items.OreGold: return (ushort)BlockId.OreGold;
                case (ushort)Items.OreIron: return (ushort)BlockId.OreIron;
                case (ushort)Items.OreSilver: return (ushort)BlockId.OreSilver;
                case (ushort)Items.OreTin: return (ushort)BlockId.OreTin;
                case (ushort)Items.OreCoal: return (ushort)BlockId.OreCoal;
                case (ushort)Items.OreSulfur: return (ushort)BlockId.OreSulfur;
                case (ushort)Items.OreSaltpeter: return (ushort)BlockId.OreSaltpeter;

                // Blocks
                case (ushort)Items.Dirt: return (ushort)BlockId.Dirt;
                case (ushort)Items.Gravel: return (ushort)BlockId.Gravel;
                case (ushort)Items.Stonerubble: return (ushort)BlockId.Cobblestone;
                case (ushort)Items.Sand: return (ushort)BlockId.Sand;
                case (ushort)Items.Ice: return (ushort)BlockId.Ice;
                case (ushort)Items.Compost: return (ushort)BlockId.Compost;

                // Grass
                case (ushort)Items.GrassBlockDesert: return (ushort)BlockId.GrassBlockDesert;
                case (ushort)Items.GrassBlockForest: return (ushort)BlockId.GrassBlockForest;
                case (ushort)Items.GrassBlockHills: return (ushort)BlockId.GrassBlockHills;
                case (ushort)Items.GrassBlockJungle: return (ushort)BlockId.GrassBlockJungle;
                case (ushort)Items.GrassBlockPlains: return (ushort)BlockId.GrassBlockPlains;
                case (ushort)Items.GrassBlockCompost: return (ushort)BlockId.GrassBlockCompost;

                // Artifical
                case (ushort)Items.Roof1: return (ushort)BlockId.Roof1;
                case (ushort)Items.Roof2: return (ushort)BlockId.Roof2;
                case (ushort)Items.Bricks: return (ushort)BlockId.Bricks;

                case (ushort)Items.Door: return (ushort)BlockId.DoorClose;
                case (ushort)Items.Planks: return (ushort)BlockId.Planks;

                case (ushort)Items.AdvancedSpaceBlock: return (ushort)BlockId.AdvancedSpaceBlock;
                case (ushort)Items.AdvancedSpaceFloor: return (ushort)BlockId.AdvancedSpaceFloor;
                case (ushort)Items.AdvancedSpacePart1: return (ushort)BlockId.AdvancedSpacePart1;
                case (ushort)Items.AdvancedSpacePart2: return (ushort)BlockId.AdvancedSpacePart2;
                case (ushort)Items.AdvancedSpacePart3: return (ushort)BlockId.AdvancedSpacePart3;
                case (ushort)Items.AdvancedSpacePart4: return (ushort)BlockId.AdvancedSpacePart4;

                case (ushort)Items.Snow: return (ushort)BlockId.Snow;

            }

            return (ushort)BlockId.None;
        }

        public static ushort TopBlockFromItem(ushort item) {
            switch (item) {
                case (ushort)Items.ChristmasStar: return (ushort)BlockId.ChristmasStar;

                case (ushort)Items.Egg: return (ushort)BlockId.EggDrop;
                case (ushort)Items.BucketForRubber: return (ushort)BlockId.BucketForRubber;
                case (ushort)Items.Shelf: return (ushort)BlockId.Shelf;
                case (ushort)Items.Barrel: return (ushort)BlockId.Barrel;
                case (ushort)Items.BoxWooden: return (ushort)BlockId.BoxWooden;
                case (ushort)Items.BoxAdv: return (ushort)BlockId.BoxAdv;
                case (ushort)Items.OxygenMachine: return (ushort)BlockId.OxygenMachine;

                // Leaves
                case (ushort)Items.AppleLeaves: return (ushort)BlockId.AppleLeaves;
                case (ushort)Items.LemonLeavesWithLemons: return (ushort)BlockId.LemonLeavesWithLemons;
                case (ushort)Items.LindenLeaves: return (ushort)BlockId.LindenLeaves;
                case (ushort)Items.OakLeaves: return (ushort)BlockId.OakLeaves;
                case (ushort)Items.OrangeLeaves: return (ushort)BlockId.OrangeLeaves;
                case (ushort)Items.SpruceLeaves: return (ushort)BlockId.SpruceLeaves;
                case (ushort)Items.PlumLeavesWithPlums: return (ushort)BlockId.PlumLeavesWithPlums;
                case (ushort)Items.PlumLeaves: return (ushort)BlockId.PlumLeaves;
                case (ushort)Items.PineLeaves: return (ushort)BlockId.PineLeaves;
                case (ushort)Items.OrangeLeavesWithOranges: return (ushort)BlockId.OrangeLeavesWithOranges;
                case (ushort)Items.AppleLeavesWithApples: return (ushort)BlockId.AppleLeavesWithApples;
                case (ushort)Items.CherryLeaves: return (ushort)BlockId.CherryLeaves;
                case (ushort)Items.CherryLeavesWithCherries: return (ushort)BlockId.CherryLeavesWithCherries;
                case (ushort)Items.LemonLeaves: return (ushort)BlockId.LemonLeaves;

                case (ushort)Items.WillowLeaves: return (ushort)BlockId.WillowLeaves;
                case (ushort)Items.WillowWood: return (ushort)BlockId.WillowWood;
                case (ushort)Items.MangroveLeaves: return (ushort)BlockId.MangroveLeaves;
                case (ushort)Items.MangroveWood: return (ushort)BlockId.MangroveWood;
                case (ushort)Items.EucalyptusLeaves: return (ushort)BlockId.EucalyptusLeaves;
                case (ushort)Items.EucalyptusWood: return (ushort)BlockId.EucalyptusWood;
                case (ushort)Items.OliveLeavesWithOlives: return (ushort)BlockId.OliveLeavesWithOlives;
                case (ushort)Items.OliveLeaves: return (ushort)BlockId.OliveLeaves;
                case (ushort)Items.OliveWood: return (ushort)BlockId.OliveWood;
                case (ushort)Items.RubberTreeLeaves: return (ushort)BlockId.RubberTreeLeaves;
                case (ushort)Items.RubberTreeWood: return (ushort)BlockId.RubberTreeWood;
                case (ushort)Items.AcaciaLeaves: return (ushort)BlockId.AcaciaLeaves;
                case (ushort)Items.AcaciaWood: return (ushort)BlockId.AcaciaWood;
                case (ushort)Items.KapokLeacesFlowering: return (ushort)BlockId.KapokLeacesFlowering;
                case (ushort)Items.KapokLeavesFibre: return (ushort)BlockId.KapokLeacesFibre;
                case (ushort)Items.KapokLeaves: return (ushort)BlockId.KapokLeaves;
                case (ushort)Items.KapokWood: return (ushort)BlockId.KapokWood;
                case (ushort)Items.WillowSapling: return (ushort)BlockId.WillowSapling;
                case (ushort)Items.MangroveSapling: return (ushort)BlockId.MangroveSapling;
                case (ushort)Items.EucalyptusSapling: return (ushort)BlockId.EucalyptusSapling;
                case (ushort)Items.OliveSapling: return (ushort)BlockId.OliveSapling;
                case (ushort)Items.RubberTreeSapling: return (ushort)BlockId.RubberTreeSapling;
                case (ushort)Items.AcaciaSapling: return (ushort)BlockId.AcaciaSapling;
                case (ushort)Items.KapokSapling: return (ushort)BlockId.KapokSapling;

                // Blocks
                case (ushort)Items.SnowTop: return (ushort)BlockId.SnowTop;
                case (ushort)Items.Glass: return (ushort)BlockId.Glass;
                case (ushort)Items.Oil: return (ushort)BlockId.Oil;
                case (ushort)Items.BucketWater: return (ushort)BlockId.WaterBlock;
                case (ushort)Items.Stick: return (ushort)BlockId.BranchWithout;

                // Saplings
                case (ushort)Items.AppleSapling: return (ushort)BlockId.AppleSapling;
                case (ushort)Items.OrangeSapling: return (ushort)BlockId.OrangeSapling;
                case (ushort)Items.PineSapling: return (ushort)BlockId.PineSapling;
                case (ushort)Items.CherrySapling: return (ushort)BlockId.CherrySapling;
                case (ushort)Items.PlumSapling: return (ushort)BlockId.PlumSapling;
                case (ushort)Items.LemonSapling: return (ushort)BlockId.LemonSapling;

                case (ushort)Items.OakSapling: return (ushort)BlockId.OakSapling;
                case (ushort)Items.SpruceSapling: return (ushort)BlockId.SpruceSapling;
                case (ushort)Items.LindenSapling: return (ushort)BlockId.LindenSapling;

                // Flowers
                case (ushort)Items.Alore: return (ushort)BlockId.Alore;
                case (ushort)Items.PlantRose: return (ushort)BlockId.Rose;
                case (ushort)Items.PlantViolet: return (ushort)BlockId.Violet;
                case (ushort)Items.Dandelion: return (ushort)BlockId.Dandelion;
                case (ushort)Items.PlantOrchid: return (ushort)BlockId.Orchid;
                case (ushort)Items.CactusBig: return (ushort)BlockId.CactusBig;
                case (ushort)Items.CactusSmall: return (ushort)BlockId.CactusSmall;

                // Grass
                case (ushort)Items.GrassDesert: return (ushort)BlockId.GrassDesert;
                case (ushort)Items.GrassForest: return (ushort)BlockId.GrassForest;
                case (ushort)Items.GrassHills: return (ushort)BlockId.GrassHills;
                case (ushort)Items.GrassJungle: return (ushort)BlockId.GrassJungle;
                case (ushort)Items.GrassPlains: return (ushort)BlockId.GrassPlains;

                // Artifical Blocks
                case (ushort)Items.Door: return (ushort)BlockId.DoorOpen;

                // Mechanical
                case (ushort)Items.Desk: return (ushort)BlockId.Desk;
                case (ushort)Items.Flag: return (ushort)BlockId.Flag;
                case (ushort)Items.Ladder: return (ushort)BlockId.Ladder;
                case (ushort)Items.TorchON: return (ushort)BlockId.BurningTorch;

                // Electrical
                case (ushort)Items.Lamp: return (ushort)BlockId.Lamp;
                case (ushort)Items.Radio: return (ushort)BlockId.Radio;
                case (ushort)Items.WindMill: return (ushort)BlockId.Windmill;
                case (ushort)Items.Label: return (ushort)BlockId.Label;
                case (ushort)Items.Rocket: return (ushort)BlockId.Rocket;
                case (ushort)Items.SewingMachine: return (ushort)BlockId.SewingMachine;

                case (ushort)Items.FurnaceElectric: return (ushort)BlockId.FurnaceElectric;
                case (ushort)Items.Macerator: return (ushort)BlockId.Macerator;
                case (ushort)Items.WaterMill: return (ushort)BlockId.Watermill;
                case (ushort)Items.SolarPanel: return (ushort)BlockId.SolarPanel;
                case (ushort)Items.Miner: return (ushort)BlockId.Miner;
                case (ushort)Items.Charger: return (ushort)BlockId.Charger;
                case (ushort)Items.FurnaceStone: return (ushort)BlockId.FurnaceStone;
                case (ushort)Items.Composter: return (ushort)BlockId.Composter;
            }

            return (ushort)BlockId.None;
        }

        public static ushort PlantFromItem(ushort item) {
            switch (item) {
                case (ushort)Items.Strawberry: return (ushort)BlockId.Strawberry;
                case (ushort)Items.PlantBlueberry: return (ushort)BlockId.Blueberry;
                case (ushort)Items.PlantRashberry: return (ushort)BlockId.Rashberry;

                case (ushort)Items.PlantOnion: return (ushort)BlockId.Onion;
                case (ushort)Items.PlantPeas: return (ushort)BlockId.Peas;
                case (ushort)Items.PlantCarrot: return (ushort)BlockId.Carrot;
                case (ushort)Items.Peas: return (ushort)BlockId.Peas;
                case (ushort)Items.Carrot: return (ushort)BlockId.Carrot;
                case (ushort)Items.Onion: return (ushort)BlockId.Onion;
            }

            return (ushort)BlockId.None;
        }

        public static ushort MobFromItem(ushort item) {
            switch (item) {
                case (ushort)Items.AnimalRabbit: return (ushort)BlockId.Rabbit;
                case (ushort)Items.AnimalChicken: return (ushort)BlockId.Chicken;
                case (ushort)Items.AnimalFish: return (ushort)BlockId.Fish;
                case (ushort)Items.AnimalParrot: return (ushort)BlockId.MobParrot;
            }

            return (ushort)BlockId.None;
        }
        #endregion

        static readonly ushort[] nonBreaktableBlocks={
            (ushort)BlockId.WaterBlock,
            (ushort)BlockId.WaterSalt,
            (ushort)BlockId.Lava,
            (ushort)BlockId.Oil
        };

        static readonly ushort[] FallingBlocks={
            (ushort)BlockId.Sand,
            (ushort)BlockId.Dirt,
            (ushort)BlockId.GrassBlockClay,
            (ushort)BlockId.GrassBlockCompost,
            (ushort)BlockId.GrassBlockDesert,
            (ushort)BlockId.GrassBlockForest,
            (ushort)BlockId.GrassBlockHills,
            (ushort)BlockId.GrassBlockJungle,
            (ushort)BlockId.GrassBlockPlains,
            (ushort)BlockId.RedSand,
            (ushort)BlockId.Regolite,
            (ushort)BlockId.Cobblestone
        };

        public static bool IsFallingBlock(ushort blockId) {
            foreach (ushort i in FallingBlocks) {
                if (blockId==i) return true;
            }
            return true;
        }

        public static bool CanDestroy(ushort blockId) {
            foreach (ushort i in nonBreaktableBlocks) {
                if (blockId==i) return false;
            }
            return true;
        }

        public static bool IsBlockOnGrowing(ushort id) { 
            switch (id){
                case (ushort)BlockId.Dirt: return true;
				case (ushort)BlockId.Compost: return true;
				case (ushort)BlockId.Clay: return true;

				case (ushort)BlockId.GrassBlockPlains: return true;
				case (ushort)BlockId.GrassBlockHills: return true;
				case (ushort)BlockId.GrassBlockJungle: return true;
				case (ushort)BlockId.GrassBlockDesert: return true;
				case (ushort)BlockId.GrassBlockForest: return true;
				case (ushort)BlockId.GrassBlockClay: return true;
				case (ushort)BlockId.GrassBlockCompost: return true;

				case (ushort)BlockId.GrassBlockSnowPlains: return true;
				case (ushort)BlockId.GrassBlockSnowHills: return true;
				case (ushort)BlockId.GrassBlockSnowJungle: return true;
				case (ushort)BlockId.GrassBlockSnowDesert: return true;
				case (ushort)BlockId.GrassBlockSnowForest: return true;
				case (ushort)BlockId.GrassBlockSnowClay: return true;
				case (ushort)BlockId.GrassBlockSnowCompost: return true;
                
                default: return false;
            }
        }

        public static bool IsDirtPlaceable(ushort id) {
             switch (id) {
                case (ushort)BlockId.OakSapling: return true;
                case (ushort)BlockId.OrangeSapling: return true;
                case (ushort)BlockId.PineSapling: return true;
                case (ushort)BlockId.PlumSapling: return true;
                case (ushort)BlockId.SpruceSapling: return true;
                case (ushort)BlockId.AppleSapling: return true;
                case (ushort)BlockId.CherrySapling: return true;
                case (ushort)BlockId.LemonSapling: return true;
                case (ushort)BlockId.LindenSapling: return true;
                case (ushort)BlockId.AcaciaSapling: return true;
                case (ushort)BlockId.EucalyptusSapling: return true;
                case (ushort)BlockId.KapokSapling: return true;
                case (ushort)BlockId.MangroveSapling: return true;
                case (ushort)BlockId.OliveSapling: return true;
                case (ushort)BlockId.RubberTreeSapling: return true;
                case (ushort)BlockId.WillowSapling: return true;
                case (ushort)BlockId.Rose: return true;
                case (ushort)BlockId.Dandelion: return true;
                case (ushort)BlockId.Heather: return true;
                case (ushort)BlockId.Orchid: return true;
                case (ushort)BlockId.Violet: return true;
                case (ushort)BlockId.Alore: return true;
                case (ushort)BlockId.Boletus: return true;
                case (ushort)BlockId.BranchFull: return true;
                case (ushort)BlockId.Champignon: return true;
                case (ushort)BlockId.GrassDesert: return true;
                case (ushort)BlockId.GrassForest: return true;
                case (ushort)BlockId.GrassHills: return true;
                case (ushort)BlockId.GrassJungle: return true;
                case (ushort)BlockId.GrassPlains: return true;
                case (ushort)BlockId.Toadstool: return true;
                case (ushort)BlockId.EggDrop: return true;
                case (ushort)BlockId.Rocks: return true;
            }
            return false;
        }

        public static CraftingRecipe[] Craft(ushort id) {
            switch (id) { 
                case (ushort)Items.AngelHair:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateGold, 1)),
                                CraftingRecipe.AnyShears(),
                            },
                            new ItemNonInvBasic((ushort)Items.AngelHair,2)
                        ),
                    };
                case (ushort)Items.MediumStone:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BigStone, 1)),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.MediumStone,2)
                        ),
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BigStone, 2)),
                            },
                            new ItemNonInvBasic((ushort)Items.MediumStone, 3)
                        ),
                    };

                case (ushort)Items.SmallStone:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.MediumStone, 1)),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.SmallStone,2)
                        ),
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BigStone, 1)),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.SmallStone, 4)
                        ),
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.MediumStone, 2)),
                            },
                            new ItemNonInvBasic((ushort)Items.SmallStone, 3)
                        ),
                    };

                case (ushort)Items.HammerCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CopperIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HammerCopper)
                        )
                    };

                case (ushort)Items.HammerAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HammerAluminium)
                        )
                    };
                    
                case (ushort)Items.HammerSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.SteelIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HammerSteel)
                        )
                    };

                case (ushort)Items.ShearsSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsHeadSteel,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,2)),
                            },
                            new ItemNonInvTool((ushort)Items.ShearsSteel)
                        )
                    };
                    
                case (ushort)Items.ShovelBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadBronze,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.ShovelBronze)
                        )
                    };

                case (ushort)Items.DyeBrown:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlack)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeOrange)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeBrown)
                        )
                    };
                    
                case (ushort)Items.DyeMagenta:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlue)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeRed)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeMagenta)
                        )
                    };
                    
                case (ushort)Items.DyeOrange:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeYellow)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeRed)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeOrange)
                        )
                    };

                case (ushort)Items.DyeTeal:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlue)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeGreen)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeTeal)
                        )
                    };

                case (ushort)Items.DyeArmy:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBrown)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeGreen)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeOlive)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeArmy)
                        )
                    };

                case (ushort)Items.DyeRoseQuartz:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeWhite)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeDarkRed)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeRoseQuartz)
                        )
                    };

                case (ushort)Items.DyePink:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeWhite)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeRed)),
                            },
                            new ItemNonInvTool((ushort)Items.DyePink)
                        )
                    };

                case (ushort)Items.DyeLightBlue:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeWhite)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlue)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeLightBlue)
                        )
                    };

                case (ushort)Items.DyeLightGreen:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeWhite)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeGreen)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeLightGreen)
                        )
                    };

                case (ushort)Items.DyeDarkGreen:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlack)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeGreen)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeDarkGreen)
                        )
                    };

                case (ushort)Items.DyeDarkBlue:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlack)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlue)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeDarkBlue)
                        )
                    };

                case (ushort)Items.DyeDarkRed:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlack)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeRed)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeDarkRed)
                        )
                    };

                case (ushort)Items.OxygenMachine:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Charger,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AirTank, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bulb, 1)),
                                CraftingRecipe.AnyHammer(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Compost, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BottleWater, 1)),
                                new CraftingIn(new ItemNonInvBasic[]{
                                    new ItemNonInvBasic((ushort)Items.Dandelion,3),
                                    new ItemNonInvBasic((ushort)Items.PlantOrchid,3),
                                }),
                            },
                            new ItemNonInvBasic((ushort)Items.OxygenMachine,1)
                        )
                    };

                case (ushort)Items.AirTank:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bottle, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Resin, 1)),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.AirTank,1)
                        )
                    };

                case (ushort)Items.AirTank2:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium, 4)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bottle,2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Resin, 2)),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.AirTank2,1)
                        )
                    };

                case (ushort)Items.Gun:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Nail, 3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,2)),
                            },
                            new ItemNonInvBasic((ushort)Items.Gun,1)
                        )
                    };

                case (ushort)Items.Ammo:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper,2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 2)),
                                CraftingRecipe.AnyHammer(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Gunpowder,3)),
                            },
                            new ItemNonInvBasic((ushort)Items.Ammo,5)
                        )
                    };

                case (ushort)Items.Gunpowder:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Saltpeter, 5)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CoalDust, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Saltpeter, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Gunpowder,7)
                        )
                    };

                 case (ushort)Items.BucketForRubber:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bucket,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.BucketForRubber,1)
                        )
                    };

                case (ushort)Items.HoeBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadBronze,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeBronze)
                        )
                    };

                case (ushort)Items.HoeCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadCopper, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeCopper)
                        )
                    };

                case (ushort)Items.HoeIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadIron, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeIron)
                        )
                    };

                case (ushort)Items.HoeGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadGold, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeGold)
                        )
                    };

                case (ushort)Items.HoeAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadAluminium, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeAluminium)
                        )
                    };

                case (ushort)Items.Composter:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks,4)),
                                new CraftingIn(new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.Rope,2),
                                    new ItemNonInvBasic((ushort)Items.Nail,4),
                                }),
                            },
                            new ItemNonInvBasic((ushort)Items.BowlEmpty,1)
                        )
                    };

                case (ushort)Items.BowlEmpty:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks,1)),
                                CraftingRecipe.AnySaw()
                            },
                            new ItemNonInvBasic((ushort)Items.BowlEmpty,1)
                        )
                    };

                case (ushort)Items.TorchOFF:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(
                                    new ItemNonInv[]{
                                        new ItemNonInvBasic((ushort)Items.Cloth,1),
                                        new ItemNonInvBasic((ushort)Items.Yarn, 2),
                                    }
                                ),
                                new CraftingIn(
                                    new ItemNonInv[]{
                                        new ItemNonInvTool((ushort)Items.BottleOil,10),
                                        new ItemNonInvTool((ushort)Items.BucketOil,10),
                                        new ItemNonInvBasic((ushort)Items.WoodDust, 3),
                                    }
                                ),
                            },
                            new ItemNonInvBasic((ushort)Items.TorchOFF,1)
                        )
                    };

                case (ushort)Items.PickaxeIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadIron,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeIron)
                        )
                    };

                case (ushort)Items.PickaxeCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadCopper,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeCopper)
                        )
                    };

                case (ushort)Items.PickaxeGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadGold,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeGold)
                        )
                    };

                case (ushort)Items.PickaxeSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadSteel,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeSteel)
                        )
                    };

                case (ushort)Items.PickaxeAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadAluminium,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeAluminium)
                        )
                    };

                case (ushort)Items.PickaxeBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadBronze,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeCopper)
                        )
                    };

                case (ushort)Items.KnifeCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadCopper,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeCopper)
                        )
                    };

                case (ushort)Items.KnifeBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadBronze,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeBronze)
                        )
                    };

                case (ushort)Items.KnifeGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadGold,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeGold)
                        )
                    };

                case (ushort)Items.KnifeSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadSteel,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeSteel)
                        )
                    };

                case (ushort)Items.HoeSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadSteel,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeSteel)
                        )
                    };

                case (ushort)Items.AxeSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadSteel,1)),
                            },
                            new ItemNonInvTool((ushort)Items.AxeSteel)
                        )
                    };

                case (ushort)Items.AxeBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadBronze,1)),
                            },
                            new ItemNonInvTool((ushort)Items.AxeBronze)
                        )
                    };

                case (ushort)Items.AxeCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadCopper,1)),
                            },
                            new ItemNonInvTool((ushort)Items.AxeCopper)
                        )
                    };

                case (ushort)Items.AxeAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadAluminium,1)),
                            },
                            new ItemNonInvTool((ushort)Items.AxeAluminium)
                        )
                    };

                case (ushort)Items.KnifeIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadIron,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeIron)
                        )
                    };

                case (ushort)Items.KnifeAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadAluminium,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeAluminium)
                        )
                    };


                case (ushort)Items.SewingMachine:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Motor,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.SewingMachine, 1)
                        )
                    };

                case (ushort)Items.Charger:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.PlateCopper,1),
                                    new ItemNonInvBasic((ushort)Items.PlateBronze,1),
                                    new ItemNonInvBasic((ushort)Items.PlateIron,1),
                                    new ItemNonInvBasic((ushort)Items.plateAluminium,1)}),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Charger,1)
                        )
                  };

                case (ushort)Items.HoeStone:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.StoneHead,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeStone)
                        )
                    };

                case (ushort)Items.AxeIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.AxeIron)
                        )
                    };

                case (ushort)Items.TorchElectricON:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bulb,1)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.ItemBattery)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Plastic,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                            },
                            new ItemNonInvTool((ushort)Items.TorchElectricON)
                        )
                    };

                case (ushort)Items.ShovelIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.ShovelIron)
                        )
                    };

                case (ushort)Items.ShovelAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.ShovelAluminium)
                        )
                    };

                case (ushort)Items.ShovelCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadCopper,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.ShovelCopper)
                        )
                    };

                case (ushort)Items.AxeHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInv[]{new ItemNonInvBasic((ushort)Items.HammerIron, 5) }),
                            },
                            new ItemNonInvBasic((ushort)Items.AxeHeadIron, 4)
                        )
                    };

                case (ushort)Items.PickaxeHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 5)),
                            },
                            new ItemNonInvBasic((ushort)Items.PickaxeHeadIron, 4)
                        )
                    };

                case (ushort)Items.ShovelHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 5)),
                            },
                            new ItemNonInvBasic((ushort)Items.ShovelHeadIron, 4)
                        )
                    };


                case (ushort)Items.BronzeDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CopperDust, 3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TinDust,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.CopperDust, 4)
                        )
                    };

                case (ushort)Items.WaterMill:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper, 2)),
                                CraftingRecipe.AnyHammer(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Motor,1)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.ItemBattery,-1)),
                            },
                            new ItemNonInvBasic((ushort)Items.WaterMill,1)
                        )
                    };


                case (ushort)Items.Stonerubble:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SmallStone, 4),new ItemNonInvBasic((ushort)Items.Stonerubble, 4))
                    };

                case (ushort)Items.Bricks:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.OneBrick, 4)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BucketWater, 25)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Sand,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Dirt,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Bricks,1)
                        )
                    };

                case (ushort)Items.Leave:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn(new ItemNonInvBasic((ushort)Items.Sticks,1)),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Leave, 2)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            }
                        ),
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.OakLeaves,1)),
                            },
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Leave, 4)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Stick, 2))
                            }
                        ),
                    };

                case (ushort)Items.Ladder:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 10)),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Rope, 4), new ItemNonInvBasic((ushort)Items.Nail, 4) })
                            },
                            new ItemNonInvBasic((ushort)Items.Ladder,1)
                        )
                    };

                case (ushort)Items.Flag:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Flag,1)
                        )
                    };

                case (ushort)Items.Shelf:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks, 5)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Nail, 5)),
                               CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.Shelf,1)
                        )
                    };

                case (ushort)Items.Barrel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks, 10)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Nail, 5)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 2)),
                               CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.Barrel,1)
                        )
                    };

                case (ushort)Items.BoxWooden:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks, 7)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Nail, 5)),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.BoxWooden,1)
                        )
                    };

                case (ushort)Items.BoxAdv:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock, 2)),
                                CraftingRecipe.AnyHammer(),
                                CraftingRecipe.AnyShears(),
                            },
                            new ItemNonInvBasic((ushort)Items.Shelf,1)
                        )
                    };

                case (ushort)Items.Sticks:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.OakLeaves,1)),
                            },
                            new CraftingOut[]{ new CraftingOut(new ItemNonInvBasic((ushort)Items.Sticks, 2)), new CraftingOut(new ItemNonInvBasic((ushort)Items.Leave, 1)) }
                        ),
                        new CraftingRecipe(
                            new CraftingIn[]{CraftingRecipe.AnySapling(1)},
                            new CraftingOut[]{ new CraftingOut(new ItemNonInvBasic((ushort)Items.Sticks, 1)) }
                        )
                    };

                case (ushort)Items.WheatSeeds:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.WheatStraw,1),
                            new CraftingOut[] {
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Hay, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.WheatSeeds, 1))
                            }
                        )
                    };

                case (ushort)Items.Seeds:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{new ItemNonInvBasic((ushort)Items.WheatSeeds,1), new ItemNonInvBasic((ushort)Items.FlaxSeeds,1) })
                            },
                            new ItemNonInvBasic((ushort)Items.Seeds,1)
                        ),
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.WheatStraw,1)),
                            },
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Seeds, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Hay, 1)),
                            }
                        )
                    };

                case (ushort)Items.Desk:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BigStone,1)),
                                CraftingRecipe.AnyWood(1)
                            },
                            new ItemNonInvBasic((ushort)Items.Desk,1)
                        )
                    };

                case (ushort)Items.CoalDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.ItemCoal,1), new ItemNonInvBasic((ushort)Items.OreCoal,1),new ItemNonInvBasic((ushort)Items.CoalWood,1) }),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.CoalDust,2)
                        )
                    };

                case (ushort)Items.Hay:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HayBlock,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Hay, 4)
                        ),
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.WheatStraw,1)),
                            },
                            new CraftingOut[]{ new CraftingOut( new ItemNonInvBasic((ushort)Items.Hay, 4)),new CraftingOut(new ItemNonInvBasic((ushort)Items.WheatSeeds,1)) }
                        ),
                    };

                case (ushort)Items.Gravel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.BigStone,1) , new ItemNonInvBasic((ushort)Items.MediumStone,2),new ItemNonInvBasic((ushort)Items.SmallStone,4)}),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.Gravel,1)
                        )
                    };

                case (ushort)Items.Stick:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.Sticks,1),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Leave, 2))
                            }
                        ),
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.OakLeaves,1),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Leave, 3))
                            }
                        ),
                    };

                case (ushort)Items.StoneHead:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BigStone,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.MediumStone,1))
                            },
                            new CraftingOut[] {
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.StoneHead, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.SmallStone,3), 0.3f),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.MediumStone,3), 0.3f)
                            }
                        )
                    };

                case (ushort)Items.PickaxeStone:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.StoneHead,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeStone)
                        )
                    };

                case (ushort)Items.AxeStone:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.StoneHead,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.AxeStone)
                        )
                    };

                case (ushort)Items.ShovelStone:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.StoneHead,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.ShovelStone)
                        )
                    };

                case (ushort)Items.HayBlock:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Hay,4),new ItemNonInvBasic((ushort)Items.HayBlock, 1))
                    };


                case (ushort)Items.PlateCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CopperIngot,1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.PlateCopper, 2)
                        )
                    };

                case (ushort)Items.plateAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.plateAluminium, 2)
                        )
                    };

                case (ushort)Items.PlateIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.PlateIron, 2)
                        )
                    };

                case (ushort)Items.PlateBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BronzeIngot, 1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.PlateBronze, 2)
                        )
                    };

                case (ushort)Items.PlateGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.GoldIngot, 1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.PlateGold, 2)
                        )
                    };

                case (ushort)Items.FurnaceElectric:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 4)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel, 6)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.FurnaceElectric,1)
                        )
                    };

                case (ushort)Items.Macerator:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Diamond,1))

                            },
                            new ItemNonInvBasic((ushort)Items.Macerator,1)
                        )
                    };

                case (ushort)Items.Radio:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BigCircuit, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateBronze,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Radio,1)
                        )
                    };

                case (ushort)Items.Label:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rubber,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Label,1)
                        )
                    };

                case (ushort)Items.BareLabel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper,1)),
                                CraftingRecipe.AnyShears()
                            },
                            new ItemNonInvBasic((ushort)Items.BareLabel, 4)
                        )
                    };

                case (ushort)Items.Sand:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Gravel,1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.Sand,1)
                        ),
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(
                                    new ItemNonInv[] {
                                        new ItemNonInvBasic((ushort)Items.BronzeDust, 2),
                                        new ItemNonInvBasic((ushort)Items.CopperDust, 2),
                                        new ItemNonInvBasic((ushort)Items.GoldDust, 2),
                                        new ItemNonInvBasic((ushort)Items.SilverDust, 2),
                                        new ItemNonInvBasic((ushort)Items.TinDust, 2)
                                    }
                                ),
                            },
                            new ItemNonInvBasic((ushort)Items.Sand,1)
                        ),
                    };

                case (ushort)Items.ShearsCopper:
                    return new CraftingRecipe[] {
                        //new CraftingRecipe(
                        //    new CraftingIn[]{
                        //        new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper,1)),
                        //        new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                        //        new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.MediumStone, 2), new ItemNonInvBasic((ushort)Items.BigStone, 1) }),
                        //    },
                        //    new ItemNonInvTool((ushort)Items.ShearsCopper)
                        //),
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsHeadCopper,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                               // CraftingRecipe.AnyShears()
                            },
                            new ItemNonInvTool((ushort)Items.ShearsCopper)
                        )
                    };

                case (ushort)Items.ShearsBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsHeadBronze,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                              //  CraftingRecipe.AnyShears()
                            },
                            new ItemNonInvTool((ushort)Items.ShearsBronze)
                        )
                    };


                case (ushort)Items.ShearsIron:
                     return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsHeadIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                               // CraftingRecipe.AnyShears()
                            },
                            new ItemNonInvTool((ushort)Items.ShearsIron)
                        )
                    };


                case (ushort)Items.AdvancedSpaceBlock:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Plastic, 1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock, 2)
                        )
                    };

                case (ushort)Items.Miner:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ElectricDrill,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BigCircuit,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope, 10))
                            },
                            new ItemNonInvBasic((ushort)Items.Miner,1)
                        )
                    };

                case (ushort)Items.Diode:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Silicium,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Diode, 4)
                        )
                    };

                case (ushort)Items.HammerBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BronzeIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1))
                            },
                            new ItemNonInvBasic((ushort)Items.HammerBronze,1)
                        )
                    };

                case (ushort)Items.HammerIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1))
                            },
                            new ItemNonInvBasic((ushort)Items.HammerIron,1)
                        )
                    };

                case (ushort)Items.SawCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper,1)),
                                CraftingRecipe.AnyShears(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.SawCopper)
                        )
                    };

                case (ushort)Items.SawBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateBronze,1)),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.ShearsBronze, 2),new ItemNonInvBasic((ushort)Items.ShearsIron, 1) }),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.SawBronze)
                        )
                    };

                case (ushort)Items.SawIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.SawIron)
                        )
                    };

                case (ushort)Items.ElectricDrill:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 4)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Motor, 1)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.ItemBattery)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit, 1))
                            },
                            new ItemNonInvTool((ushort)Items.ElectricDrill)
                        )
                    };


                case (ushort)Items.ElectricSaw:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 4)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsIron, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Motor, 1)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.ItemBattery)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit, 1))
                            },
                            new ItemNonInvTool((ushort)Items.ElectricSaw)
                        )
                    };

                case (ushort)Items.Rocket:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium, 16)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock, 4)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceWindow, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 8)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Lamp, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label, 3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BigCircuit, 4)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Plastic, 4)),
                            },
                            new ItemNonInvBasic((ushort)Items.Rocket,1)
                        )
                    };


                case (ushort)Items.Door:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Nail, 10)),
                                CraftingRecipe.AnyHammer(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks, 3)),
                            },
                            new ItemNonInvBasic((ushort)Items.Door,1)
                        )
                    };

                case (ushort)Items.Yarn:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Flax, 1), new ItemNonInvBasic((ushort)Items.KapokFibre, 1) })
                            },
                            new ItemNonInvBasic((ushort)Items.Yarn,1)
                        )
                    };

                case (ushort)Items.Rope:
                    return new CraftingRecipe[] {new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Yarn, 3), new ItemNonInvBasic((ushort)Items.Rope,1))};

                case (ushort)Items.Nail:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 5))
                            },
                            new ItemNonInvBasic((ushort)Items.Nail, 10)
                        )
                    };

                case (ushort)Items.Roof1:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bricks,1)),
                                CraftingRecipe.AnySaw()
                            },
                            new ItemNonInvBasic((ushort)Items.Roof1, 2)
                        )
                    };

                case (ushort)Items.Roof2:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bricks,1)),
                                CraftingRecipe.AnySaw()
                            },
                            new ItemNonInvBasic((ushort)Items.Roof2, 2)
                        )
                    };


                case (ushort)Items.FurnaceStone:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.MediumStone, 6), new ItemNonInvBasic((ushort)Items.BigStone,4), new ItemNonInvBasic((ushort)Items.SmallStone,8)}),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Dirt, 2), new ItemNonInvBasic((ushort)Items.Clay, 2) })
                            },
                            new ItemNonInvBasic((ushort)Items.FurnaceStone,1)
                        )
                    };

                case (ushort)Items.MudIngot:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Clay, 1), new ItemNonInvBasic((ushort)Items.MudIngot, 1)),
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Dirt,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Hay,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BucketWater,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.MudIngot,1)
                        )
                    };

                case (ushort)Items.ItemBattery:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Lemon,1)),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.PlateCopper, 2), new ItemNonInvBasic((ushort)Items.PlateGold, 2)}),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.PlateIron, 2),new ItemNonInvBasic((ushort)Items.plateAluminium, 2) })
                            },
                            new ItemNonInvTool((ushort)Items.ItemBattery,1)
                        )
                    };

                case (ushort)Items.BigCircuit:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Diode, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Tranzistor, 1)),
                                new CraftingIn(new ItemNonInvBasic[]{new ItemNonInvBasic((ushort)Items.Rezistance, 2), new ItemNonInvBasic((ushort)Items.Condenser, 1) }),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel, 2))
                            },
                            new ItemNonInvBasic((ushort)Items.BigCircuit,1)
                        ),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Circuit, 3),new ItemNonInvBasic((ushort)Items.BigCircuit,1))
                    };

                case (ushort)Items.Bucket:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Bucket,1)
                        ),
                        new CraftingRecipe(
                            new CraftingIn[]{
                                CraftingRecipe.AnyWood(1),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Bucket,1)
                        )
                    };

                case (ushort)Items.Bulb:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                                CraftingRecipe.AnyShears()
                            },
                            new ItemNonInvBasic((ushort)Items.Bulb,1)
                        )
                    };

                case (ushort)Items.Circuit:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel, 2)),
                                new CraftingIn(new ItemNonInvBasic[]{ new ItemNonInvBasic((ushort)Items.Rezistance, 1), new ItemNonInvBasic((ushort)Items.Condenser, 1)}),
                                new CraftingIn(new ItemNonInvBasic[]{ new ItemNonInvBasic((ushort)Items.Diode, 2),new ItemNonInvBasic((ushort)Items.Tranzistor, 1)  }),
                                CraftingRecipe.AnyShears()
                            },
                            new ItemNonInvBasic((ushort)Items.Circuit,1)
                        )
                    };

                case (ushort)Items.SolarPanel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Silicium, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.SolarPanel,1)
                        )
                    };



                case (ushort)Items.WindMill:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Motor, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label, 1)),
                                new CraftingIn(new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.PlateCopper, 2),
                                    new ItemNonInvBasic((ushort)Items.PlateIron, 2),
                                    new ItemNonInvBasic((ushort)Items.plateAluminium, 2) }),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateBronze, 1)),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.WindMill,1)
                        )
                    };

                case (ushort)Items.AdvancedSpaceWindow:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsIron,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpaceWindow,1)
                        )
                    };

                case (ushort)Items.AdvancedSpaceFloor:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1))
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpaceFloor,1)
                        )
                    };

                case (ushort)Items.AdvancedSpacePart1:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1))
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpacePart1,1)
                        )
                    };

                case (ushort)Items.AdvancedSpacePart2:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1))
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpacePart2,1)
                        )
                    };

                case (ushort)Items.AdvancedSpacePart3:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1))
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpacePart3,1)
                        )
                    };

                case (ushort)Items.AdvancedSpacePart4:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1))
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpacePart4,1)
                        )
                    };

                case (ushort)Items.Lamp:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bulb, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label, 2)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.ItemBattery)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit, 1)),
                                new CraftingIn(new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.PlateIron, 1),
                                    new ItemNonInvBasic((ushort)Items.plateAluminium, 1),
                                    new ItemNonInvBasic((ushort)Items.PlateBronze, 1),
                                    new ItemNonInvBasic((ushort)Items.PlateCopper, 1) })
                            },
                            new ItemNonInvBasic((ushort)Items.Lamp,1)
                        )
                    };

                case (ushort)Items.Cloth:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Yarn, 4))
                            },
                            new ItemNonInvBasic((ushort)Items.Cloth,1)
                        )
                    };

                case (ushort)Items.AxeGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadGold, 1))
                            },
                            new ItemNonInvTool((ushort)Items.AxeGold)
                        )
                    };

                case (ushort)Items.ShovelGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadGold, 1))
                            },
                            new ItemNonInvTool((ushort)Items.ShovelGold)
                        )
                    };
                    
                case (ushort)Items.ShovelSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadSteel, 1))
                            },
                            new ItemNonInvTool((ushort)Items.ShovelSteel)
                        )
                    };
                    
                case (ushort)Items.ShearsAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadAluminium, 1))
                            },
                            new ItemNonInvTool((ushort)Items.ShearsAluminium)
                        )
                    };

               // case (ushort)Items.ShovelGold:
                    //return new CraftingRecipe[] {
                    //    new CraftingRecipe(
                    //        new CraftingIn[]{
                    //            new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                    //            new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadGold, 1))
                    //        },
                    //        new ItemNonInvTool((ushort)Items.ShovelGold)
                    //    )
                    //};
                case (ushort)Items.ShearsGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsHeadGold, 1))
                            },
                            new ItemNonInvTool((ushort)Items.ShearsGold)
                        )
                    };

                case (ushort)Items.HammerGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.GoldIngot, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope, 1))
                            },
                            new ItemNonInvTool((ushort)Items.HammerGold)
                        )
                    };

                case (ushort)Items.Motor:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot, 1)),
                                CraftingRecipe.AnyHammer(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.Motor,1)
                        )
                    };

                case (ushort)Items.Rod:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.IronIngot, 1), new ItemNonInvBasic((ushort)Items.BronzeIngot, 1) }),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.Rod, 2)
                        )
                    };

                case (ushort)Items.Condenser:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.plateAluminium, 1), new ItemNonInvBasic((ushort)Items.PlateCopper, 1) }),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                                CraftingRecipe.AnyShears(),
                            },
                            new ItemNonInvBasic((ushort)Items.Condenser, 5)
                        )
                    };

                case (ushort)Items.Rezistance:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CoalWood,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Rezistance, 5)
                        )
                    };

                case (ushort)Items.Tranzistor:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Diode, 2), new ItemNonInvBasic((ushort)Items.Tranzistor, 1))
                    };

                case (ushort)Items.Planks:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                CraftingRecipe.AnyWood(1),
                                CraftingRecipe.AnySaw()
                            },
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Planks, 3)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.WoodDust,1), 0.5f)
                            }
                        )
                    };

                default: return null;
            }
        }

        public static CraftingRecipe[] Bake(ushort id) {
            switch (id) {
                case (ushort)Items.ChristmasBallGray:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.ChristmasBallGray)
                        )
                    };

                case (ushort)Items.ChristmasStar:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.GoldDust,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.ChristmasStar)
                        )
                    };

                case (ushort)Items.SteelIngot:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(
                                    new ItemNonInv[]{
                                        new ItemNonInvBasic((ushort)Items.CoalDust),
                                        new ItemNonInvBasic((ushort)Items.ItemCoal),
                                        new ItemNonInvBasic((ushort)Items.OreCoal),
                                    }
                                ),
                                new CraftingIn(
                                    new ItemNonInv[]{
                                        new ItemNonInvBasic((ushort)Items.IronDust),
                                        new ItemNonInvBasic((ushort)Items.IronIngot),
                                        new ItemNonInvBasic((ushort)Items.ItemIron),
                                        new ItemNonInvBasic((ushort)Items.OreIron),
                                    }
                                ),
                                new CraftingIn(
                                    new ItemNonInv[]{
                                        new ItemNonInvBasic((ushort)Items.Gravel, 1),
                                        new ItemNonInvBasic((ushort)Items.Sand, 1),
                                        new ItemNonInvBasic((ushort)Items.RedSand, 1)
                                    }
                                )
                            },
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.SteelIngot, 1))
                            }
                        )
                    };
                   case (ushort)Items.DyeBlue:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.DyeBlue, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Leave, 1))
                            }
                        )
                    };

                case (ushort)Items.DyeViolet:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlantViolet, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.DyeViolet, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Leave, 1))
                            }
                        )
                    };
                    
                case (ushort)Items.boiledEgg:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Egg, 1), new ItemNonInvFood((ushort)Items.boiledEgg, 1, 0))
                    };

                case (ushort)Items.DyeRed:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(
                                    new ItemNonInv[]{
                                        new ItemNonInvFood((ushort)Items.Strawberry, 1, 0.5f),
                                        new ItemNonInvFood((ushort)Items.Rashberry, 1, 0.5f),
                                    }
                                ),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeRed, 1)
                        )
                    };

                case (ushort)Items.DyeGreen:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Leave, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.DyeGreen, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Leave, 1))
                            }
                        )
                    };

                case (ushort)Items.DyeOrange:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvFood((ushort)Items.Carrot, 1, 0.5f)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeOrange, 1)
                        )
                    };

                case (ushort)Items.DyeSpringGreen:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvFood((ushort)Items.Peas, 1, 0.5f)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeSpringGreen, 1)
                        )
                    };

                case (ushort)Items.DyeYellow:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(
                                    new ItemNonInv[]{
                                        new ItemNonInvBasic((ushort)Items.Dandelion, 1),
                                        new ItemNonInvBasic((ushort)Items.SulfurDust, 1),
                                    }
                                ),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeYellow, 1)
                        )
                    };

                case (ushort)Items.DyeDarkGreen:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvFood((ushort)Items.Seaweed, 1, 0.5f)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeDarkGreen, 1)
                        )
                    };

                case (ushort)Items.DyeBrown:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(
                                    new ItemNonInv[] {
                                        new ItemNonInvFood((ushort)Items.Onion, 1, 0.5f),
                                        new ItemNonInvBasic((ushort)Items.Dirt, 1),
                                        new ItemNonInvBasic((ushort)Items.Compost, 1),
                                    }
                                ),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeBrown, 1)
                        )
                    };

                case (ushort)Items.DyeLightGray:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Ash, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeLightGray, 1)
                        )
                    };

                case (ushort)Items.DyeGray:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(
                                    new ItemNonInv[]{
                                        new ItemNonInvBasic((ushort)Items.AluminiumDust, 1),
                                        new ItemNonInvBasic((ushort)Items.TinDust, 1),
                                        new ItemNonInvBasic((ushort)Items.SilverDust, 1),
                                        new ItemNonInvBasic((ushort)Items.IronDust, 1),
                                    }
                                ),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeGray, 1)
                        )
                    };

                case (ushort)Items.DyeBlack:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CoalDust, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeBlack, 1)
                        )
                    };
                    
                case (ushort)Items.DyeWhite:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Saltpeter, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeWhite, 1)
                        )
                    };

                case (ushort)Items.DyeGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.GoldDust, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeGold, 1)
                        )
                    };

                case (ushort)Items.DyeRoseQuartz:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlantRose, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeRoseQuartz, 1)
                        )
                    };

                case (ushort)Items.TestTube:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn(
                                new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.Sand,1),
                                    new ItemNonInvBasic((ushort)Items.RedSand,1)
                                }
                            ),
                            new CraftingOut(new ItemNonInvBasic((ushort)Items.TestTube,1))
                        ),
                    };

                case (ushort)Items.TorchON:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.TorchOFF,1),new ItemNonInvTool((ushort)Items.TorchON,1)),
                    };

                case (ushort)Items.Bottle:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Plastic,1),new ItemNonInvBasic((ushort)Items.Bottle,1)),
                    };
                    
                case (ushort)Items.ShovelHeadSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadSteel,1)),
                    };
                    
                case (ushort)Items.AxeHeadGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadGold,1)),
                    };

                case (ushort)Items.DyeOlive:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Olive,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube,1))
                            },
                                
                            new ItemNonInvBasic((ushort)Items.DyeOlive,1)
                        )
                    };

                case (ushort)Items.HoeHeadBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadBronze,1)),
                    };

                case (ushort)Items.HoeHeadCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadCopper,1)),
                    };

                case (ushort)Items.HoeHeadAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadAluminium,1)),
                    };

                case (ushort)Items.HoeHeadSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadSteel,1)),
                    };

                case (ushort)Items.HoeHeadGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadGold,1)),
                    };

                case (ushort)Items.HoeHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadIron,1)),
                    };

                case (ushort)Items.RabbitMeatCooked:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.RabbitMeat,1), new ItemNonInvBasic((ushort)Items.RabbitMeatCooked,1)),
                    };

                case (ushort)Items.RabbitMeatCookedWithSalt:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.RabbitMeat,1), new ItemNonInvBasic((ushort)Items.RabbitMeatCookedWithSalt,1)),
                    };

                case (ushort)Items.Plastic:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rubber,1)),
                                CraftingRecipe.AnyOil(25),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Ash,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Plastic,1)
                        ),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Bottle,1), new ItemNonInvBasic((ushort)Items.Plastic,1))
                    };

                case (ushort)Items.BowlWithMushrooms:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BowlEmpty,1)),
                                CraftingRecipe.AnyWater(25),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Boletus,1), new ItemNonInvBasic((ushort)Items.Champignon,1) }),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Champignon,1), new ItemNonInvBasic((ushort)Items.Boletus,1) }),

                            },
                            new ItemNonInvBasic((ushort)Items.BowlWithMushrooms,1)
                        )
                    };

                case (ushort)Items.BowlWithVegetables:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BowlEmpty,1)),
                                CraftingRecipe.AnyWater(25),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Carrot,1), new ItemNonInvBasic((ushort)Items.Onion,1),new ItemNonInvBasic((ushort)Items.Peas,1)}),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Carrot,1), new ItemNonInvBasic((ushort)Items.Onion,1),new ItemNonInvBasic((ushort)Items.Peas,1)}),

                            },
                            new ItemNonInvBasic((ushort)Items.BowlWithVegetables,1)
                        )
                    };

                case (ushort)Items.plateAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1), new ItemNonInvBasic((ushort)Items.plateAluminium, 2))
                    };

                case (ushort)Items.OneBrick:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.MudIngot,1), new ItemNonInvBasic((ushort)Items.OneBrick, 1))
                    };

                case (ushort)Items.BareLabel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.BareLabel, 3))
                    };

                case (ushort)Items.PlateBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1), new ItemNonInvBasic((ushort)Items.PlateBronze, 2))
                    };

                case (ushort)Items.PlateCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1), new ItemNonInvBasic((ushort)Items.PlateCopper, 2))
                    };

                case (ushort)Items.PlateGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1),new ItemNonInvBasic((ushort)Items.PlateGold, 2))
                    };

                case (ushort)Items.PlateIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot, 1), new ItemNonInvBasic((ushort)Items.PlateIron, 2))
                    };

                case (ushort)Items.FishMeatCooked:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.FishMeat,1), new ItemNonInvBasic((ushort)Items.FishMeatCooked,1))
                    };

                case (ushort)Items.AxeHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadIron,1))
                    };

                case (ushort)Items.AxeHeadCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadCopper,1))
                    };

                case (ushort)Items.AxeHeadBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadBronze,1))
                    };

                case (ushort)Items.AxeHeadAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadAluminium,1))
                    };

                case (ushort)Items.AxeHeadSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadSteel,1))
                    };

                case (ushort)Items.PickaxeHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadIron,1))
                    };

                case (ushort)Items.PickaxeHeadCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadCopper,1))
                    };

                case (ushort)Items.PickaxeHeadBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadBronze,1))
                    };

                case (ushort)Items.PickaxeHeadGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadGold,1))
                    };

                case (ushort)Items.PickaxeHeadAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadAluminium,1))
                    };

                case (ushort)Items.PickaxeHeadSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadSteel,1))
                    };

                case (ushort)Items.ShovelHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadIron,1))
                    };

                case (ushort)Items.ShovelHeadCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadCopper,1))
                    };

                case (ushort)Items.ShovelHeadBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadBronze,1))
                    };

                case (ushort)Items.ShovelHeadGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadGold,1))
                    };

                case (ushort)Items.ShovelHeadAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadAluminium,1))
                    };

                case (ushort)Items.ShearsHeadAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadAluminium,1))
                    };

                case (ushort)Items.ShearsHeadCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadCopper,1))
                    };

                case (ushort)Items.ShearsHeadBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadBronze,1))
                    };

                case (ushort)Items.ShearsHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadIron,1))
                    };

                case (ushort)Items.ShearsHeadGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadGold,1))
                    };

                case (ushort)Items.ShearsHeadSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadSteel,1))
                    };

                case (ushort)Items.KnifeHeadSteel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadSteel,1))
                    };

                case (ushort)Items.KnifeHeadCopper:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadCopper,1))
                    };

                case (ushort)Items.KnifeHeadBronze:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadBronze,1))
                    };

                case (ushort)Items.KnifeHeadGold:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadGold,1))
                    };

                case (ushort)Items.KnifeHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadIron,1))
                    };

                case (ushort)Items.KnifeHeadAluminium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadAluminium,1))
                    };

                case (ushort)Items.Glass:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Sand,1), new ItemNonInvBasic((ushort)Items.Glass,1))
                    };

                case (ushort)Items.Rubber:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.Resin, 1),
                                    new ItemNonInvBasic((ushort)Items.Ash, 1)/*,new ItemNonInv((ushort)Items., 1), new ItemNonInv((ushort)Items.OakLeaves, 1)*/ }),
                            },
                            new ItemNonInvBasic((ushort)Items.Rubber,1)
                        )
                        //new CraftingRecipe((ushort)Items.Resin, (ushort)Items.Rubber)
                    };

                case (ushort)Items.Ash:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.Sticks, 1),
                                    new ItemNonInvBasic((ushort)Items.Leave, 2),
                                    new ItemNonInvBasic((ushort)Items.Stick, 1),
                                    new ItemNonInvBasic((ushort)Items.OakLeaves, 1) }),
                            },
                            new ItemNonInvBasic((ushort)Items.Ash,1)
                        )
                    };

                case (ushort)Items.CoalWood:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Planks, 2), new ItemNonInvBasic((ushort)Items.CoalWood, 1))
                    };

                case (ushort)Items.Silicium:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvTool((ushort)Items.ItemBattery)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.SmallStone, 1)),
                            },
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Silicium,1), 0.5f),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.BareLabel, 1)),
                                new CraftingOut(new ItemNonInvTool((ushort)Items.ItemBattery, 1)),
                            }
                        )
                    };

                case (ushort)Items.AluminiumIngot:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvTool((ushort)Items.ItemBattery)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel, 1)),
                                new CraftingIn(new ItemNonInv[]{new ItemNonInvBasic((ushort)Items.Aluminium, 1), new ItemNonInvBasic((ushort)Items.OreAluminium, 1)}),
                            },
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.AluminiumIngot, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.BareLabel, 1)),
                                new CraftingOut(new ItemNonInvTool((ushort)Items.ItemBattery, 1)),
                            }
                        ),
                        new CraftingRecipe(
                            new CraftingIn[]{new CraftingIn(
                                new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.AluminiumDust, 2), new ItemNonInvBasic((ushort)Items.plateAluminium, 2)})
                            },
                            new ItemNonInvBasic((ushort)Items.AluminiumIngot,1)
                        )
                    };

                case (ushort)Items.IronIngot:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn( new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.ItemIron, 1),
                                    new ItemNonInvBasic((ushort)Items.IronDust, 2),
                                    new ItemNonInvBasic((ushort)Items.PlateIron, 2),
                                    new ItemNonInvBasic((ushort)Items.HammerIron, 1),
                                    new ItemNonInvBasic((ushort)Items.AxeHeadIron, 1),
                                    new ItemNonInvBasic((ushort)Items.HoeHeadIron, 1),
                                    new ItemNonInvBasic((ushort)Items.PickaxeHeadIron, 1),
                                    new ItemNonInvBasic((ushort)Items.ShovelHeadIron, 2),
                                    new ItemNonInvBasic((ushort)Items.OreIron, 1)})
                            },
                            new ItemNonInvBasic((ushort)Items.ItemIron,1)
                        )
                    };

                case (ushort)Items.SilverIngot:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn( new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.ItemSilver, 1),
                                    new ItemNonInvBasic((ushort)Items.SilverDust, 2),
                                    new ItemNonInvBasic((ushort)Items.OreSilver, 1)})
                            },
                            new ItemNonInvBasic((ushort)Items.SilverIngot,1)
                        )
                    };

                case (ushort)Items.CopperIngot:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.ItemCopper, 1),
                                new ItemNonInvBasic((ushort)Items.CopperDust, 2),
                                new ItemNonInvBasic((ushort)Items.PlateCopper, 2),
                                new ItemNonInvBasic((ushort)Items.BareLabel, 2),
                                new ItemNonInvBasic((ushort)Items.OreCopper, 1)})
                            },
                            new ItemNonInvBasic((ushort)Items.ItemCopper,1)
                        )
                    };

                case (ushort)Items.GoldIngot:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{new CraftingIn(
                                new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.ItemGold, 1),
                                    new ItemNonInvBasic((ushort)Items.GoldDust, 2),
                                    new ItemNonInvBasic((ushort)Items.PlateGold, 2),
                                    new ItemNonInvBasic((ushort)Items.OreGold, 1)})
                            },
                            new ItemNonInvBasic((ushort)Items.ItemCopper,1)
                        )
                    };

                case (ushort)Items.BronzeIngot:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.ItemCopper, 3), new ItemNonInvBasic((ushort)Items.CopperIngot, 3)}),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.ItemTin, 1), new ItemNonInvBasic((ushort)Items.TinIngot, 3)}),
                            },
                            new ItemNonInvBasic((ushort)Items.BronzeIngot, 4)
                        ),
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInv[] {new ItemNonInvBasic((ushort)Items.CopperDust, 3),new ItemNonInvBasic((ushort)Items.PlateCopper, 3) }),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TinDust, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.BronzeIngot, 2)
                        ),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.PlateBronze, 2),new ItemNonInvBasic((ushort)Items.BronzeIngot, 2)),
                    };

                case (ushort)Items.TinIngot:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.ItemTin, 1), new ItemNonInvBasic((ushort)Items.TinDust, 2), new ItemNonInvBasic((ushort)Items.OreTin, 1)})
                            },
                            new ItemNonInvBasic((ushort)Items.TinIngot,1)
                        )
                    };

                default: return null;
            }
        }

        public static CraftingRecipe[] Clothes(ushort id) {
            switch (id) {
                case (ushort)Items.boiledEgg:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Egg,1), new ItemNonInvBasic((ushort)Items.boiledEgg,1))
                    };

                case (ushort)Items.BucketForRubber:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bucket, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.BucketForRubber, 1)
                         )
                    };

                case (ushort)Items.Hat:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Hat, 1)
                         )
                    };

                case (ushort)Items.Crown:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateGold, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Ruby, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Smaragd, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Saphirite, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Crown, 1)
                        )
                    };


                case (ushort)Items.Cap:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlantViolet, 2)),
                            },
                        new ItemNonInvBasic((ushort)Items.Cap, 1)
                         )
                    };


                case (ushort)Items.SpaceHelmet:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.SpaceHelmet, 1)
                        )
                    };

                case (ushort)Items.FormalShoes:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Cloth,1), new ItemNonInvBasic((ushort)Items.FormalShoes,1))
                    };

                case (ushort)Items.Pumps:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlantRose,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Pumps, 1)
                         )
                    };

                case (ushort)Items.Sneakers:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Cloth,1),new ItemNonInvBasic((ushort)Items.Sneakers,1))
                    };

                case (ushort)Items.SpaceBoots:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.SpaceBoots, 1)
                        )
                    };


                case (ushort)Items.BikiniDown:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1))
                            },
                            new ItemNonInvBasic((ushort)Items.BikiniDown,1)
                        )
                    };

                //case (ushort)Items.BlueBikini:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe(
                //            new CraftingIn[]{
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth),
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries),
                //            },
                //            new ItemNonInv((ushort)Items.BlueBikini, 1)
                //        )
                //    };


                case (ushort)Items.Underpants:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Underpants, 1)
                        )
                    };


                case (ushort)Items.BoxerShorts:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.Cloth,1),
                            new ItemNonInvBasic((ushort)Items.BoxerShorts,1)
                        )
                    };


                //case (ushort)Items.GrayUnderpants:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe((ushort)Items.Cloth, (ushort)Items.GrayUnderpants)
                //    };


                case (ushort)Items.Panties:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                               new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Panties, 1)
                        )
                    };


                //case (ushort)Items.PantiesRed:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe(
                //            new CraftingIn[]{
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth),
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlantRose),
                //            },
                //            new ItemNonInv((ushort)Items.PantiesRed, 1)
                //         )
                //    };


                case (ushort)Items.Swimsuit:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Swimsuit, 1)
                        )
                    };


                case (ushort)Items.Dress:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,3))
                            },
                            new ItemNonInvBasic((ushort)Items.Dress, 1)
                        )
                    };


                case (ushort)Items.TShirt:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                           new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,2))
                        },
                        new ItemNonInvBasic((ushort)Items.TShirt, 1)
                         )
                    };


                 //case (ushort)Items.LightBlueTShirt:
                 //   return new CraftingRecipe[] {
                 //       new CraftingRecipe(
                 //           new CraftingIn[]{
                 //         new CraftingIn(new ItemNonInv((ushort)Items.Cloth,2)),
                 //         new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries),
                 //       },
                 //       new ItemNonInv((ushort)Items.LightBlueTShirt, 1)
                 //        )
                 //   };


                case (ushort)Items.Shirt:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Cloth,2), new ItemNonInvBasic((ushort)Items.Shirt, 1))
                    };

                //case (ushort)Items.Dress:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe(new ItemNonInv((ushort)Items.Cloth,3), new ItemNonInv((ushort)Items.WhiteDress, 1))
                //    };

                case (ushort)Items.CoatArmy:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Leave,2)),
                            },
                            new ItemNonInvBasic((ushort)Items.CoatArmy, 1)
                        )
                    };

                case (ushort)Items.Coat:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Cloth,3), new ItemNonInvBasic((ushort)Items.Coat, 1))
                    };

                case (ushort)Items.JacketDenim:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries,2)),
                            },
                            new ItemNonInvBasic((ushort)Items.JacketDenim,1)
                        )
                    };

                case (ushort)Items.JacketFormal:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CoalDust,2)),
                            },
                            new ItemNonInvBasic((ushort)Items.JacketFormal,1)
                        )
                    };

                //case (ushort)Items.jac:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe(
                //            new CraftingIn[]{
                //                new CraftingIn(new ItemNonInv((ushort)Items.Cloth,2)),
                //                new CraftingIn(new ItemNonInv((ushort)Items.PlantRose,2)),
                //            },
                //            new ItemNonInvBasic((ushort)Items.Jacket
                //        )
                //    };

                case (ushort)Items.JacketShort:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.JacketShort,1)
                        )
                    };


                case (ushort)Items.SpaceSuit:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit,1)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.ItemBattery, -1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1))
                            },
                            new ItemNonInvBasic((ushort)Items.SpaceSuit,1)
                        )
                    };

                case (ushort)Items.ArmyTrousers:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Leave,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.ArmyTrousers,1)
                        )
                    };

                case (ushort)Items.Skirt:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Skirt,1)
                        )
                    };

                case (ushort)Items.Jeans:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Jeans,1)
                        )
                    };

                //case (ushort)Items.Skirt:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe(
                //            new CraftingIn[]{
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth),
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries),
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlantRose),
                //            },
                //            new ItemNonInvBasic((ushort)Items.PinkSkirt
                //        )
                //    };


                case (ushort)Items.Shorts:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Shorts, 1)
                        )
                    };


                case (ushort)Items.SpaceTrousers:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.SpaceTrousers,1)
                        )
                    };

                case (ushort)Items.Bra:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Bra,1)
                        )
                    };

                //case (ushort)Items.PurpleBra:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe(
                //            new CraftingIn[]{
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth),
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope),
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries),
                //            },
                //            new ItemNonInv((ushort)Items.PurpleBra, 1)
                //        )
                //    };


                //case (ushort)Items.RedBra:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe(
                //            new CraftingIn[]{
                //            new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth),
                //            new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope),
                //        },
                //        new ItemNonInv((ushort)Items.RedBra, 1)
                //         )
                //    };

                case (ushort)Items.BikiniTop:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CoalDust,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.BikiniTop,1)
                        )
                    };

                //case (ushort)Items.TopBlueBikini:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe(
                //            new CraftingIn[]{
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth),
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope),
                //                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries),
                //            },
                //            new ItemNonInvBasic((ushort)Items.TopBlueBikini
                //        )
                //    };

                case (ushort)Items.Backpack:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Backpack,1)
                        )
                    };

                default: return null;
            }
        }

        public static CraftingRecipe[] ToDust(ushort id) {
            switch (id) {
                case (ushort)Items.StoneHead:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BigStone,1), new ItemNonInvBasic((ushort)Items.StoneHead, 1)),
                    };

                case (ushort)Items.IronDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1), new ItemNonInvBasic((ushort)Items.IronDust, 2)),
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.ItemIron,1),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.IronDust,3),0.75f),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Gravel,1),0.5f),
                            }
                        ),
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(
                                    new ItemNonInv[]{
                                        new ItemNonInvBasic((ushort)Items.AxeHeadIron,1),
                                        new ItemNonInvBasic((ushort)Items.PickaxeHeadIron,1),
                                        new ItemNonInvBasic((ushort)Items.ShovelHeadIron,1)
                                    }
                                )
                            },
                            new ItemNonInvBasic((ushort)Items.IronDust,2)
                        )
                    };

                case (ushort)Items.CopperDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1), new ItemNonInvBasic((ushort)Items.CopperDust,2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.ItemCopper,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.CopperDust,3),0.75f))
                    };

                case (ushort)Items.BareLabel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BareLabel,1), new ItemNonInvBasic((ushort)Items.CopperDust,1)),
                    };

                case (ushort)Items.TinDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.TinIngot,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.TinDust,2),0.75f)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.ItemTin,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.TinDust,1),0.75f))
                    };

                case (ushort)Items.BronzeDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CopperIngot, 3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TinIngot, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.BronzeDust, 8)
                        ),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1), new ItemNonInvBasic((ushort)Items.BronzeDust,2))
                    };

                case (ushort)Items.AluminiumDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot, 1), new ItemNonInvBasic((ushort)Items.AluminiumDust, 2))
                    };

                case (ushort)Items.WoodDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Stick,1), new ItemNonInvBasic((ushort)Items.WoodDust, 4))
                    };

                case (ushort)Items.GoldDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1), new ItemNonInvBasic((ushort)Items.GoldDust, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.ItemGold,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.GoldDust,3), 0.75f))
                    };

                case (ushort)Items.CoalDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.OreCoal,1), new ItemNonInvBasic((ushort)Items.CoalDust, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CoalWood,1), new ItemNonInvBasic((ushort)Items.CoalDust, 2))
                    };

                case (ushort)Items.SilverDust:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SilverIngot,1), new ItemNonInvBasic((ushort)Items.SilverDust, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.ItemSilver,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.SilverDust,3), 0.75f))
                    };

                case (ushort)Items.CopperIngot:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Label,1), new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CoalWood,1), new ItemNonInvBasic((ushort)Items.BareLabel, 2))
                    };

                case (ushort)Items.Gravel:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BigStone,1),new ItemNonInvBasic((ushort)Items.Gravel,1)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.MediumStone, 2), new ItemNonInvBasic((ushort)Items.Gravel,1)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SmallStone, 4), new ItemNonInvBasic((ushort)Items.Gravel,1)),
                    };

                case (ushort)Items.Sand:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Gravel,1), new ItemNonInvBasic((ushort)Items.Sand, 1)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Bricks,1), new ItemNonInvBasic((ushort)Items.Sand, 1))
                    };

                case (ushort)Items.WheatSeeds:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.WheatStraw,1), new ItemNonInvBasic((ushort)Items.WheatSeeds,1))
                    };

                case (ushort)Items.AxeHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadIron,1))
                    };

                case (ushort)Items.PickaxeHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadIron,1))
                    };

                case (ushort)Items.ShovelHeadIron:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1), new ItemNonInvBasic((ushort)Items.ShovelHeadIron,1))
                    };

                case (ushort)Items.Seeds:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Hay,1), new ItemNonInvBasic((ushort)Items.Seeds,1))
                    };

                case (ushort)Items.Leave:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.OakLeaves,1), new ItemNonInvBasic((ushort)Items.Seeds, 4))
                    };

                case (ushort)Items.Yarn:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Cloth,1), new ItemNonInvBasic((ushort)Items.Yarn, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Rope,1), new ItemNonInvBasic((ushort)Items.Yarn, 1)),
                    };

                case (ushort)Items.Cloth:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Flag,1), new ItemNonInvBasic((ushort)Items.Cloth, 2))
                    };

                case (ushort)Items.Hay:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.HayBlock,1), new ItemNonInvBasic((ushort)Items.Hay, 2))
                    };

                case (ushort)Items.BucketWater:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Bucket,1), new ItemNonInvBasic((ushort)Items.Lemon, 4)),
                    };

                case (ushort)Items.FlaxSeeds:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Flax,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.FlaxSeeds,2),0.75f))
                    };

                case (ushort)Items.Label:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.Lamp,1),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Label, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Bulb, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Circuit, 1))
                            }
                        ),
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.Macerator,1),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Label, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Diamond, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Circuit, 1))
                            }
                        ),
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.FurnaceElectric,1),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.IronDust, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Label, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Circuit, 1))
                            }
                        ),
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.Rocket,1),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.IronDust, 3)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Label, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.BigCircuit, 1))
                            }
                        ),
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.SolarPanel,1),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Sand, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Circuit, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.BareLabel, 1))
                            }
                        ),
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.WaterMill,1),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Label, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Motor, 1))
                            }
                        ),
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.WindMill,1),
                            new CraftingOut[]{
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Label, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Motor, 1))
                            }
                        ),
                    };

                case (ushort)Items.SmallStone:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.MediumStone,1), new ItemNonInvBasic((ushort)Items.SmallStone, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BigStone,1), new ItemNonInvBasic((ushort)Items.SmallStone, 4)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Stonerubble,1), new ItemNonInvBasic((ushort)Items.SmallStone, 4)),
                    };

                case (ushort)Items.MediumStone:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BigStone,1), new ItemNonInvBasic((ushort)Items.MediumStone, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Stonerubble,1), new ItemNonInvBasic((ushort)Items.MediumStone, 2)),
                    };

                case (ushort)Items.Stonerubble:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SmallStone, 4), new ItemNonInvBasic((ushort)Items.Stonerubble, 1)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.MediumStone, 2), new ItemNonInvBasic((ushort)Items.Stonerubble, 1))
                    };

                case (ushort)Items.Stick:
                    return new CraftingRecipe[] {
                        new CraftingRecipe(new CraftingIn[]{ CraftingRecipe.AnyWood(1) }, new ItemNonInvBasic((ushort)Items.Stick, 4))
                    };

                default: return null;
            }
        }

        public static int FoodMaxCount(ushort id) {
            switch (id) {
                #region Fruit
                // Mild
                case (ushort)Items.Apple: return 10;
                case (ushort)Items.Cherry: return 10;
                case (ushort)Items.Plum: return 10;

                // Subtropical
                case (ushort)Items.Orange: return 10;
                case (ushort)Items.Lemon: return 10;
                case (ushort)Items.Olive: return 10;

                // Tropical
                case (ushort)Items.Banana: return 10;
                #endregion

                #region Vegetable
                case (ushort)Items.Carrot: return 99;
                case (ushort)Items.Peas: return 99;
                case (ushort)Items.Onion: return 99;
                case (ushort)Items.Seaweed: return 99;

                // bush
                case (ushort)Items.Blueberries: return 99;
                case (ushort)Items.Strawberry: return 99;
                case (ushort)Items.Rashberry: return 99;
                #endregion

                #region Soup
                case (ushort)Items.BowlWithMushrooms: return 1;
                case (ushort)Items.BowlWithVegetables: return 1;
                #endregion

                #region Meat
                case (ushort)Items.FishMeat: return 99;
                case (ushort)Items.FishMeatWithSalt: return 99;
                case (ushort)Items.FishMeatCooked: return 99;
                case (ushort)Items.FishMeatCookedWithSalt: return 99;

                case (ushort)Items.RabbitMeat: return 99;
                case (ushort)Items.RabbitMeatWithSalt: return 99;
                case (ushort)Items.RabbitMeatCooked: return 99;
                case (ushort)Items.RabbitMeatCookedWithSalt: return 99;
                #endregion

                #region Foods
                case (ushort)Items.Bread: return 99;
                case (ushort)Items.Sandwich: return 99;
                case (ushort)Items.Sushi: return 99;
                #endregion

                #region Seeds
                case (ushort)Items.Seeds: return 99;
                case (ushort)Items.FlaxSeeds: return 99;
                case (ushort)Items.WheatSeeds: return 99;
                case (ushort)Items.RiceSeeds: return 99;
                #endregion

                #region Tin
                case (ushort)Items.TinOfPeas: return 99;
                case (ushort)Items.TinOfPlums: return 99;
                case (ushort)Items.TinOfCherries: return 99;
                case (ushort)Items.TinOfBlueberries: return 99;
                case (ushort)Items.TinOfRashberries: return 99;
                case (ushort)Items.TinOfStrawberries: return 99;
                #endregion
            }
            return -1;
        }

        public static bool IsItemInvBasic16(ushort id) {
            switch (id) {
                #region Wood
                case (ushort)Items.WoodApple: return true;
                case (ushort)Items.AcaciaWood: return true;
                case (ushort)Items.WoodPlum: return true;
                case (ushort)Items.WoodSpruce: return true;
                case (ushort)Items.WoodCherry: return true;
                case (ushort)Items.WoodLemon: return true;
                case (ushort)Items.WoodLinden: return true;
                case (ushort)Items.WoodOak: return true;
                case (ushort)Items.WoodOrange: return true;
                case (ushort)Items.EucalyptusWood: return true;
                case (ushort)Items.WillowWood: return true;
                case (ushort)Items.KapokWood: return true;
                case (ushort)Items.RubberTreeWood: return true;
                case (ushort)Items.WoodPine: return true;
                case (ushort)Items.MangroveWood: return true;
                case (ushort)Items.OliveWood: return true;
                #endregion

                #region Leaves
                case (ushort)Items.AcaciaLeaves: return true;
                case (ushort)Items.AppleLeaves: return true;
                case (ushort)Items.AppleLeavesWithApples: return true;
                case (ushort)Items.CherryLeaves: return true;
                case (ushort)Items.CherryLeavesWithCherries: return true;
                case (ushort)Items.EucalyptusLeaves: return true;
                case (ushort)Items.LemonLeaves: return true;
                case (ushort)Items.LemonLeavesWithLemons: return true;
                case (ushort)Items.LindenLeaves: return true;
                case (ushort)Items.MangroveLeaves: return true;
                case (ushort)Items.OakLeaves: return true;
                case (ushort)Items.OliveLeaves: return true;
                case (ushort)Items.OliveLeavesWithOlives: return true;
                case (ushort)Items.OrangeLeaves: return true;
                case (ushort)Items.OrangeLeavesWithOranges: return true;
                case (ushort)Items.PineLeaves: return true;
                case (ushort)Items.RubberTreeLeaves: return true;
                case (ushort)Items.WillowLeaves: return true;
                case (ushort)Items.PlumLeaves: return true;
                case (ushort)Items.PlumLeavesWithPlums: return true;
                case (ushort)Items.SpruceLeaves: return true;
                case (ushort)Items.KapokLeaves: return true;
                case (ushort)Items.KapokLeavesFibre: return true;
                case (ushort)Items.KapokLeacesFlowering: return true;
                #endregion

                #region Sapling
                case (ushort)Items.AcaciaSapling: return true;
                case (ushort)Items.AppleSapling: return true;
                case (ushort)Items.CherrySapling: return true;
                case (ushort)Items.EucalyptusSapling: return true;
                case (ushort)Items.KapokSapling: return true;
                case (ushort)Items.LemonSapling: return true;
                case (ushort)Items.LindenSapling: return true;
                case (ushort)Items.MangroveSapling: return true;
                case (ushort)Items.OakSapling: return true;
                case (ushort)Items.OliveSapling: return true;
                case (ushort)Items.OrangeSapling: return true;
                case (ushort)Items.PineSapling: return true;
                case (ushort)Items.PlumSapling: return true;
                case (ushort)Items.RubberTreeSapling: return true;
                case (ushort)Items.SpruceSapling: return true;
                case (ushort)Items.WillowSapling: return true;
                #endregion

                #region Stone
                case (ushort)Items.StoneAnorthosite: return true;
                case (ushort)Items.StoneBasalt: return true;
                case (ushort)Items.StoneDiorit: return true;
                case (ushort)Items.StoneDolomite: return true;
                case (ushort)Items.StoneFlint: return true;
                case (ushort)Items.StoneGabbro: return true;
                case (ushort)Items.StoneGneiss: return true;
                case (ushort)Items.StoneLimestone: return true;
                case (ushort)Items.StoneMudstone: return true;
                case (ushort)Items.StoneRhyolite: return true;
                case (ushort)Items.StoneSandstone: return true;
                case (ushort)Items.StoneSchist: return true;
                #endregion

                #region GrassBlock
                case (ushort)Items.GrassBlockClay: return true;
                case (ushort)Items.GrassBlockCompost: return true;
                case (ushort)Items.GrassBlockDesert: return true;
                case (ushort)Items.GrassBlockForest: return true;
                case (ushort)Items.GrassBlockHills: return true;
                case (ushort)Items.GrassBlockJungle: return true;
                case (ushort)Items.GrassBlockPlains: return true;
                #endregion

                #region Grass
                case (ushort)Items.GrassDesert: return true;
                case (ushort)Items.GrassForest: return true;
                case (ushort)Items.GrassHills: return true;
                case (ushort)Items.GrassJungle: return true;
                case (ushort)Items.GrassPlains: return true;
                #endregion

                #region Plants
                case (ushort)Items.PlantBlueberry: return true;
                case (ushort)Items.PlantCarrot: return true;
                case (ushort)Items.PlantOnion: return true;
                case (ushort)Items.PlantOrchid: return true;
                case (ushort)Items.PlantPeas: return true;
                case (ushort)Items.PlantRashberry: return true;
                case (ushort)Items.PlantRose: return true;
                case (ushort)Items.PlantSeaweed: return true;
                case (ushort)Items.PlantStrawberry: return true;
                case (ushort)Items.PlantViolet: return true;
                case (ushort)Items.Alore: return true;
                case (ushort)Items.CactusBig: return true;
                case (ushort)Items.CactusSmall: return true;
                #endregion

                #region Basic blocks
                case (ushort)Items.Dirt: return true;
                case (ushort)Items.Sand: return true;
                case (ushort)Items.Gravel: return true;
                case (ushort)Items.Stonerubble: return true;
                case (ushort)Items.Compost: return true;
                case (ushort)Items.Ice: return true;
                case (ushort)Items.Snow: return true;
                #endregion

                #region Back
                // Stone
                case (ushort)Items.BackAnorthosite: return true;
                case (ushort)Items.BackBasalt: return true;
                case (ushort)Items.BackDiorit: return true;
                case (ushort)Items.BackDolomite: return true;
                case (ushort)Items.BackFlint: return true;
                case (ushort)Items.BackGabbro: return true;
                case (ushort)Items.BackGneiss: return true;
                case (ushort)Items.BackLimestone: return true;
                case (ushort)Items.BackMudstone: return true;
                case (ushort)Items.BackRhyolite: return true;
                case (ushort)Items.BackSandstone: return true;
                case (ushort)Items.BackSchist: return true;

                // Basic
                case (ushort)Items.BackClay: return true;
                case (ushort)Items.BackCobblestone: return true;
                case (ushort)Items.BackDirt: return true;
                case (ushort)Items.BackRegolite: return true;
                case (ushort)Items.BackRedSand: return true;
                case (ushort)Items.BackSand: return true;

                // Ore
                case (ushort)Items.BackTin: return true;
                case (ushort)Items.BackSulfur: return true;
                case (ushort)Items.BackSilver: return true;
                case (ushort)Items.BackCoal: return true;
                case (ushort)Items.BackCopper: return true;
                case (ushort)Items.BackIron: return true;
                case (ushort)Items.BackGold: return true;

                // Crafted
                case (ushort)Items.AdvancedSpaceBack: return true;
                #endregion

                #region Crafted
                case (ushort)Items.HayBlock: return true;
                case (ushort)Items.Glass: return true;
                case (ushort)Items.Bricks: return true;
                case (ushort)Items.AdvancedSpaceBlock: return true;
                case (ushort)Items.AdvancedSpaceFloor: return true;
                case (ushort)Items.AdvancedSpacePart1: return true;
                case (ushort)Items.AdvancedSpacePart2: return true;
                case (ushort)Items.AdvancedSpacePart3: return true;
                case (ushort)Items.AdvancedSpacePart4: return true;
                case (ushort)Items.AdvancedSpaceWindow: return true;
                #endregion

                case (ushort)Items.Seeds: return true;
                case (ushort)Items.FlaxSeeds: return true;
                case (ushort)Items.Yarn: return true;
                case (ushort)Items.Cloth: return true;
                case (ushort)Items.Stick: return true;
                case (ushort)Items.Sticks: return true;
                case (ushort)Items.SmallStone: return true;
                case (ushort)Items.MediumStone: return true;
                case (ushort)Items.BigStone: return true;
                case (ushort)Items.CopperDust: return true;
                case (ushort)Items.AluminiumDust: return true;
                case (ushort)Items.Clay: return true;
                case (ushort)Items.Desk: return true;
                case (ushort)Items.Diamond: return true;
                case (ushort)Items.GoldDust: return true;
                case (ushort)Items.OreGold: return true;
                case (ushort)Items.OreCopper: return true;
                case (ushort)Items.OreCoal: return true;
                case (ushort)Items.OreAluminium: return true;
                case (ushort)Items.Miner: return true;
                case (ushort)Items.IronDust: return true;
                case (ushort)Items.SolarPanel: return true;
                case (ushort)Items.WaterMill: return true;
                case (ushort)Items.Rocket: return true;
                case (ushort)Items.FurnaceStone: return true;
                case (ushort)Items.FurnaceElectric: return true;
                case (ushort)Items.Radio: return true;
             //   case (ushort)Items.Banana: return true;
                //case (ushort)Items.Apple: return true;
                //case (ushort)Items.Cherry: return true;
                //case (ushort)Items.Plum: return true;
                //case (ushort)Items.Rashberry: return true;
                //case (ushort)Items.Blueberries: return true;
              //  case (ushort)Items.Lemon: return true;
              //  case (ushort)Items.Orange: return true;
                case (ushort)Items.OreIron: return true;
                case (ushort)Items.Saltpeter: return true;
                case (ushort)Items.SilverDust: return true;
                case (ushort)Items.ItemSilver: return true;
                case (ushort)Items.Hat: return true;
                case (ushort)Items.Gunpowder: return true;
                case (ushort)Items.Lava: return true;
                case (ushort)Items.Label: return true;
                case (ushort)Items.Lamp: return true;
                case (ushort)Items.Macerator: return true;
                case (ushort)Items.Oil: return true;
               // case (ushort)Items.Olive: return true;
                case (ushort)Items.Ladder: return true;
                case (ushort)Items.StoneHead: return true;
                case (ushort)Items.ItemCopper: return true;
                case (ushort)Items.TorchOFF: return true;
                case (ushort)Items.Hay: return true;
                case (ushort)Items.Dandelion: return true;
                case (ushort)Items.ItemCoal: return true;
                case (ushort)Items.OxygenMachine: return true;
                case (ushort)Items.Ruby: return true;
                case (ushort)Items.Smaragd: return true;
                case (ushort)Items.Saphirite: return true;
                case (ushort)Items.WheatStraw: return true;
                case (ushort)Items.Leave: return true;
                case (ushort)Items.Planks: return true;
                case (ushort)Items.Roof1: return true;
                case (ushort)Items.Roof2: return true;
                case (ushort)Items.Door: return true;
                case (ushort)Items.Composter: return true;
                case (ushort)Items.Shelf: return true;
                case (ushort)Items.BoxWooden: return true;
                case (ushort)Items.BoxAdv: return true;
                case (ushort)Items.BucketForRubber: return true;
                case (ushort)Items.BronzeDust: return true;
                case (ushort)Items.Charger: return true;
                case (ushort)Items.SewingMachine: return true;
                case (ushort)Items.Bucket: return true;
                case (ushort)Items.Silicium: return true;
                case (ushort)Items.CoalWood: return true;
                case (ushort)Items.WheatSeeds: return true;
                case (ushort)Items.RiceSeeds: return true;
                case (ushort)Items.OreTin: return true;
                case (ushort)Items.OreSilver: return true;
                case (ushort)Items.OreSulfur: return true;
                case (ushort)Items.OreSaltpeter: return true;
                case (ushort)Items.SnowTop: return true;
                case (ushort)Items.BackAluminium: return true;
                case (ushort)Items.BackSaltpeter: return true;
                case (ushort)Items.BowlEmpty: return true;
                case (ushort)Items.ItemTin: return true;
                case (ushort)Items.ItemIron: return true;
                case (ushort)Items.ItemGold: return true;
                case (ushort)Items.Aluminium: return true;
                case (ushort)Items.SulfurDust: return true;
                case (ushort)Items.Heater: return true;
                case (ushort)Items.Boletus: return true;
                case (ushort)Items.Toadstool: return true;
                case (ushort)Items.SugarCane: return true;
                case (ushort)Items.Champignon: return true;
                case (ushort)Items.CoalDust: return true;
                case (ushort)Items.Coral: return true;
                case (ushort)Items.Flax: return true;
                case (ushort)Items.WoodDust: return true;
                case (ushort)Items.TinDust: return true;
                case (ushort)Items.Rubber: return true;
                case (ushort)Items.Plastic: return true;
                case (ushort)Items.Ash: return true;
                case (ushort)Items.KapokFibre: return true;
                case (ushort)Items.AnimalRabbit: return true;
                case (ushort)Items.AnimalParrot: return true;
                case (ushort)Items.AnimalChicken: return true;
                case (ushort)Items.AnimalFish: return true;
                case (ushort)Items.Barrel: return true;

                case (ushort)Items.HoeHeadCopper: return true;
                case (ushort)Items.HoeHeadBronze: return true;
                case (ushort)Items.HoeHeadGold: return true;
                case (ushort)Items.HoeHeadIron: return true;
                case (ushort)Items.HoeHeadSteel: return true;
                case (ushort)Items.HoeHeadAluminium: return true;
                case (ushort)Items.RedSand: return true;
                case (ushort)Items.Resin: return true;
                case (ushort)Items.ChristmasStar: return true;
            }
            return false;
        }

        public static bool IsItemInvBasic32(ushort id) {
            switch (id) {
                case (ushort)Items.AngelHair: return true;
                case (ushort)Items.ChristmasBallGray: return true;
                case (ushort)Items.ChristmasBallBlue: return true;
                case (ushort)Items.ChristmasBallLightGreen: return true;
                case (ushort)Items.ChristmasBallOrange: return true;
                case (ushort)Items.ChristmasBallPink: return true;
                case (ushort)Items.ChristmasBallPurple: return true;
                case (ushort)Items.ChristmasBallRed: return true;
                case (ushort)Items.ChristmasBallYellow: return true;
                case (ushort)Items.ChristmasBallTeal: return true;
                case (ushort)Items.Rope: return true;
                case (ushort)Items.Nail: return true;
                case (ushort)Items.Bottle: return true;
                case (ushort)Items.Flag: return true;
                case (ushort)Items.Diode: return true;
                case (ushort)Items.Tranzistor: return true;
                case (ushort)Items.Rezistance: return true;
                case (ushort)Items.Motor: return true;
                case (ushort)Items.ElectricDrillOff: return true;
                case (ushort)Items.ElectricSawOff: return true;
                case (ushort)Items.LighterOFF: return true;
                case (ushort)Items.TorchElectricOFF: return true;
                case (ushort)Items.Condenser: return true;
                case (ushort)Items.Rod: return true;
                case (ushort)Items.Ammo: return true;
                //case (ushort)Items.ItemBattery: return true;
                case (ushort)Items.Label: return true;
                case (ushort)Items.BareLabel: return true;
                case (ushort)Items.Bricks: return true;
                case (ushort)Items.plateAluminium: return true;
                case (ushort)Items.PlateBronze: return true;
                case (ushort)Items.PlateIron: return true;
                case (ushort)Items.PlateGold: return true;
                case (ushort)Items.PlateCopper: return true;
                case (ushort)Items.MudIngot: return true;
                case (ushort)Items.Bulb: return true;

                case (ushort)Items.CopperIngot: return true;
                case (ushort)Items.TinIngot: return true;
                case (ushort)Items.BronzeIngot: return true;
                case (ushort)Items.GoldIngot: return true;
                case (ushort)Items.SilverIngot: return true;
                case (ushort)Items.IronIngot: return true;
                case (ushort)Items.SteelIngot: return true;
                case (ushort)Items.AluminiumIngot: return true;


                case (ushort)Items.Egg: return true;
                case (ushort)Items.TinEmpty: return true;
                case (ushort)Items.Circuit: return true;
                case (ushort)Items.BigCircuit: return true;
                case (ushort)Items.WindMill: return true;
                case (ushort)Items.OneBrick: return true;
                case (ushort)Items.TestTube: return true;


                case (ushort)Items.AxeHeadCopper: return true;
                case (ushort)Items.AxeHeadBronze: return true;
                case (ushort)Items.AxeHeadGold: return true;
                case (ushort)Items.AxeHeadIron: return true;
                case (ushort)Items.AxeHeadSteel: return true;
                case (ushort)Items.AxeHeadAluminium: return true;

                case (ushort)Items.ShovelHeadCopper: return true;
                case (ushort)Items.ShovelHeadBronze: return true;
                case (ushort)Items.ShovelHeadGold: return true;
                case (ushort)Items.ShovelHeadIron: return true;
                case (ushort)Items.ShovelHeadSteel: return true;
                case (ushort)Items.ShovelHeadAluminium: return true;

                case (ushort)Items.PickaxeHeadCopper: return true;
                case (ushort)Items.PickaxeHeadBronze: return true;
                case (ushort)Items.PickaxeHeadGold: return true;
                case (ushort)Items.PickaxeHeadIron: return true;
                case (ushort)Items.PickaxeHeadSteel: return true;
                case (ushort)Items.PickaxeHeadAluminium: return true;

                case (ushort)Items.ShearsHeadCopper: return true;
                case (ushort)Items.ShearsHeadBronze: return true;
                case (ushort)Items.ShearsHeadGold: return true;
                case (ushort)Items.ShearsHeadIron: return true;
                case (ushort)Items.ShearsHeadSteel: return true;
                case (ushort)Items.ShearsHeadAluminium: return true;

                case (ushort)Items.KnifeHeadCopper: return true;
                case (ushort)Items.KnifeHeadBronze: return true;
                case (ushort)Items.KnifeHeadGold: return true;
                case (ushort)Items.KnifeHeadIron: return true;
                case (ushort)Items.KnifeHeadSteel: return true;
                case (ushort)Items.KnifeHeadAluminium: return true;

            }
            return false;
        }

        public static bool IsItemInvTool32(ushort id) {
            switch (id) {
                // Hoe
                case (ushort)Items.HoeStone: return true;
                case (ushort)Items.HoeCopper: return true;
                case (ushort)Items.HoeBronze: return true;
                case (ushort)Items.HoeIron: return true;
                case (ushort)Items.HoeGold: return true;
                case (ushort)Items.HoeAluminium: return true;
                case (ushort)Items.HoeSteel: return true;

                // Knife
                case (ushort)Items.KnifeCopper: return true;
                case (ushort)Items.KnifeBronze: return true;
                case (ushort)Items.KnifeIron: return true;
                case (ushort)Items.KnifeSteel: return true;
                case (ushort)Items.KnifeAluminium: return true;
                case (ushort)Items.KnifeGold: return true;

                // Pickaxe
                case (ushort)Items.PickaxeStone: return true;
                case (ushort)Items.PickaxeIron: return true;
                case (ushort)Items.PickaxeCopper: return true;
                case (ushort)Items.PickaxeBronze: return true;
                case (ushort)Items.PickaxeSteel: return true;
                case (ushort)Items.PickaxeGold: return true;
                case (ushort)Items.PickaxeAluminium: return true;

                // Axe
                case (ushort)Items.AxeStone: return true;
                case (ushort)Items.AxeIron: return true;
                case (ushort)Items.AxeSteel: return true;
                case (ushort)Items.AxeAluminium: return true;
                case (ushort)Items.AxeCopper: return true;
                case (ushort)Items.AxeBronze: return true;
                case (ushort)Items.AxeGold: return true;

                // Shovel
                case (ushort)Items.ShovelStone: return true;
                case (ushort)Items.ShovelIron: return true;
                case (ushort)Items.ShovelSteel: return true;
                case (ushort)Items.ShovelAluminium: return true;
                case (ushort)Items.ShovelGold: return true;
                case (ushort)Items.ShovelCopper: return true;
                case (ushort)Items.ShovelBronze: return true;

                // Saw
                case (ushort)Items.SawCopper: return true;
                case (ushort)Items.SawBronze: return true;
                case (ushort)Items.SawIron: return true;
                case (ushort)Items.SawGold: return true;
                case (ushort)Items.SawSteel: return true;
                case (ushort)Items.SawAluminium: return true;

                // Hammer
                case (ushort)Items.HammerBronze: return true;
                case (ushort)Items.HammerIron: return true;
                case (ushort)Items.HammerCopper: return true;
                case (ushort)Items.HammerAluminium: return true;
                case (ushort)Items.HammerGold: return true;
                case (ushort)Items.HammerSteel: return true;

                // Shears
                case (ushort)Items.ShearsCopper: return true;
                case (ushort)Items.ShearsBronze: return true;
                case (ushort)Items.ShearsIron: return true;
                case (ushort)Items.ShearsAluminium: return true;
                case (ushort)Items.ShearsGold: return true;
                case (ushort)Items.ShearsSteel: return true;

                // Electric
                case (ushort)Items.ElectricDrill: return true;
                case (ushort)Items.ElectricSaw: return true;

                case (ushort)Items.TorchElectricON: return true;

                case (ushort)Items.BottleOil: return true;
                case (ushort)Items.BottleSaltWater: return true;
                case (ushort)Items.BottleWater: return true;
                case (ushort)Items.Gun: return true;

                case (ushort)Items.LighterON: return true;
                case (ushort)Items.AirTank2: return true;
                case (ushort)Items.AirTank: return true;

                case (ushort)Items.DyeArmy: return true;
                case (ushort)Items.DyeBlack: return true;
                case (ushort)Items.DyeBlue: return true;
                case (ushort)Items.DyeBrown: return true;
                case (ushort)Items.DyeDarkBlue: return true;
                case (ushort)Items.DyeDarkGray: return true;
                case (ushort)Items.DyeDarkGreen: return true;
                case (ushort)Items.DyeDarkRed: return true;
                case (ushort)Items.DyeGold: return true;
                case (ushort)Items.DyeGray: return true;
                case (ushort)Items.DyeGreen: return true;
                case (ushort)Items.DyeLightBlue: return true;
                case (ushort)Items.DyeLightGray: return true;
                case (ushort)Items.DyeLightGreen: return true;
                case (ushort)Items.DyeMagenta: return true;
                case (ushort)Items.DyeOlive: return true;
                case (ushort)Items.DyeOrange: return true;
                case (ushort)Items.DyePink: return true;
                case (ushort)Items.DyePurple: return true;
                case (ushort)Items.DyeRed: return true;
                case (ushort)Items.DyeRoseQuartz: return true;
                case (ushort)Items.DyeSpringGreen: return true;
                case (ushort)Items.DyeTeal: return true;
                case (ushort)Items.DyeViolet: return true;
                case (ushort)Items.DyeWhite: return true;
                case (ushort)Items.DyeYellow: return true;
            }
            return false;
        }

        public static bool IsItemInvFood16(ushort id) {
            switch (id) {
                #region Fruit
                // Mild
                case (ushort)Items.Apple: return true;
                case (ushort)Items.Cherry: return true;
                case (ushort)Items.Plum: return true;

                // Subtropical
                case (ushort)Items.Orange: return true;
                case (ushort)Items.Lemon: return true;
                case (ushort)Items.Olive: return true;

                // Tropical
                case (ushort)Items.Banana: return true;
                #endregion

                #region Vegetable
                case (ushort)Items.Carrot: return true;
                case (ushort)Items.Peas: return true;
                case (ushort)Items.Onion: return true;
                case (ushort)Items.Seaweed: return true;

                // bush
                case (ushort)Items.Blueberries:
                    return true;
                case (ushort)Items.Strawberry:
                    return true;
                case (ushort)Items.Rashberry:
                    return true;
                #endregion

                #region Soup
                case (ushort)Items.BowlWithMushrooms: return true;
                case (ushort)Items.BowlWithVegetables: return true;
                #endregion

                #region Meat
                case (ushort)Items.FishMeat: return true;
                case (ushort)Items.FishMeatWithSalt: return true;
                case (ushort)Items.FishMeatCooked: return true;
                case (ushort)Items.FishMeatCookedWithSalt: return true;

                case (ushort)Items.RabbitMeat: return true;
                case (ushort)Items.RabbitMeatWithSalt: return true;
                case (ushort)Items.RabbitMeatCooked: return true;
                case (ushort)Items.RabbitMeatCookedWithSalt: return true;
                #endregion

                #region Seeds
               // case (ushort)Items.Seeds: return true;
               // case (ushort)Items.FlaxSeeds: return true;
              //  case (ushort)Items.WheatSeeds: return true;
              //  case (ushort)Items.RiceSeeds: return true;
                #endregion
            }
            return false;
        }

        public static bool IsItemInvFood32(ushort id) {
            switch (id) {
                #region Foods
                case (ushort)Items.Bread: return true;
                case (ushort)Items.Sandwich: return true;
                case (ushort)Items.Sushi: return true;
                case (ushort)Items.boiledEgg: return true;
                #endregion

                #region Tin
                case (ushort)Items.TinOfPeas: return true;
                case (ushort)Items.TinOfPlums: return true;
                case (ushort)Items.TinOfCherries: return true;
                case (ushort)Items.TinOfBlueberries: return true;
                case (ushort)Items.TinOfRashberries: return true;
                case (ushort)Items.TinOfStrawberries: return true;
                case (ushort)Items.TinOfOnions: return true;

                case (ushort)Items.TinOfLemons: return true;
                case (ushort)Items.TinOfOranges: return true;
                #endregion
            }
            return false;
        }

        public static bool IsItemInvNonStackable32(ushort id) {
            switch (id) {
                case (ushort)Items.Crown: return true;
                case (ushort)Items.Hat: return true;
                case (ushort)Items.SpaceBoots: return true;
                case (ushort)Items.Mobile: return true;
                case (ushort)Items.SpaceHelmet: return true;
                case (ushort)Items.SpaceSuit: return true;
                case (ushort)Items.SpaceTrousers: return true;
            }
            return false;
        }

        public static bool IsItemInvBasicColoritzed32NonStackable(ushort id) {
            switch (id) {
                // Head
                case (ushort)Items.Cap: return true;
                case (ushort)Items.SpaceHelmet: return true;

                // Chest
                case (ushort)Items.Dress: return true;
                case (ushort)Items.TShirt: return true;
                case (ushort)Items.Shirt: return true;

                // ChestTop
                case (ushort)Items.Coat: return true;
                case (ushort)Items.CoatArmy: return true;
                case (ushort)Items.JacketFormal: return true;
                case (ushort)Items.JacketShort: return true;
                case (ushort)Items.JacketDenim: return true;
                case (ushort)Items.SpaceSuit: return true;

                // Legs
                case (ushort)Items.Skirt: return true;
                case (ushort)Items.Jeans: return true;
                case (ushort)Items.Shorts: return true;
                case (ushort)Items.SpaceTrousers: return true;
                case (ushort)Items.ArmyTrousers: return true;

                // Feet
                case (ushort)Items.Pumps: return true;
                case (ushort)Items.SpaceBoots: return true;
                case (ushort)Items.Sneakers: return true;
                case (ushort)Items.FormalShoes: return true;

                // UpUnderwear
                case (ushort)Items.Bra: return true;
                case (ushort)Items.BikiniTop: return true;

                // DownUnderwear
                case (ushort)Items.BikiniDown: return true;
                case (ushort)Items.Underpants: return true;
                case (ushort)Items.BoxerShorts: return true;
                case (ushort)Items.Panties: return true;
                case (ushort)Items.Swimsuit: return true;

                case (ushort)Items.Backpack: return true;
            }
            return false;
        }

        public static bool IsItemInvTool16(ushort id) {
            switch (id) {
                case (ushort)Items.TorchON: return true;
                case (ushort)Items.BucketOil: return true;
                case (ushort)Items.BucketWater: return true;

                    case (ushort)Items.ItemBattery: return true;
            }
            return false;
        }

        public static float FoodMaxDescay(ushort id) {
            switch (id) {
                #region Fruit
                // Mild
                case (ushort)Items.Apple: return 200;
                case (ushort)Items.Cherry: return 50;
                case (ushort)Items.Plum: return 150;

                // Subtropical
                case (ushort)Items.Orange: return 13;
                case (ushort)Items.Lemon: return 15;
                case (ushort)Items.Olive: return 10;

                // Tropical
                case (ushort)Items.Banana: return 10;
                #endregion

                #region Vegetable
                case (ushort)Items.Carrot: return 100;
                case (ushort)Items.Peas: return 150;
                case (ushort)Items.Onion: return 200;
                case (ushort)Items.Seaweed: return 300;

                // bush
                case (ushort)Items.Blueberries: return 15;
                case (ushort)Items.Strawberry: return 10;
                case (ushort)Items.Rashberry: return 10;
                #endregion

                #region Soup
                case (ushort)Items.BowlWithMushrooms: return 10;
                case (ushort)Items.BowlWithVegetables: return 10;
                #endregion

                #region Meat
                case (ushort)Items.FishMeat: return 10;
                case (ushort)Items.FishMeatWithSalt: return 20;
                case (ushort)Items.FishMeatCooked: return 12;
                case (ushort)Items.FishMeatCookedWithSalt: return 14;

                case (ushort)Items.RabbitMeat: return 10;
                case (ushort)Items.RabbitMeatWithSalt: return 20;
                case (ushort)Items.RabbitMeatCooked: return 12;
                case (ushort)Items.RabbitMeatCookedWithSalt: return 14;
                #endregion

                #region Foods
                case (ushort)Items.Bread: return 60;
                case (ushort)Items.Sandwich: return 30;
                case (ushort)Items.Sushi: return 20;
                #endregion

                #region Seeds
                case (ushort)Items.Seeds: return 1000;
                case (ushort)Items.FlaxSeeds: return 1000;
                case (ushort)Items.WheatSeeds: return 1000;
                case (ushort)Items.RiceSeeds: return 1000;
                #endregion

                #region Tin
                case (ushort)Items.TinOfPeas: return 800;
                case (ushort)Items.TinOfPlums: return 800;
                case (ushort)Items.TinOfCherries: return 800;
                case (ushort)Items.TinOfBlueberries: return 800;
                case (ushort)Items.TinOfRashberries: return 800;
                case (ushort)Items.TinOfStrawberries: return 800;
                #endregion
            }
            return -1;
        }

        public static Color DyeToColor(byte liquid){
            switch (liquid){
                case (byte)LiquidId.DyeArmy: return new Color(34,48,17);
                case (byte)LiquidId.DyeBlack: return Color.Black;
                case (byte)LiquidId.DyeBlue: return Color.Blue;
                case (byte)LiquidId.DyeBrown: return Color.Brown;
                case (byte)LiquidId.DyeGray: return Color.Gray;
                case (byte)LiquidId.DyeWhite: return Color.White;
                case (byte)LiquidId.DyeYellow: return Color.Yellow;
                case (byte)LiquidId.DyeViolet: return Color.Violet;
                case (byte)LiquidId.DyeTeal: return Color.Teal;
                case (byte)LiquidId.DyeSpringGreen: return new Color(143, 225, 44);
                case (byte)LiquidId.DyeRoseQuartz: return new Color(170, 152, 169);
                case (byte)LiquidId.DyeRed: return Color.Red;
                case (byte)LiquidId.DyeDarkRed: return Color.DarkRed;
                case (byte)LiquidId.DyePurple: return Color.Purple;
                case (byte)LiquidId.DyePink: return Color.Pink;
                case (byte)LiquidId.DyeOrange: return Color.Orange;
                case (byte)LiquidId.DyeOlive: return Color.Olive;
                case (byte)LiquidId.DyeMagenta: return Color.Magenta;
                case (byte)LiquidId.DyeLightGreen: return Color.LightGreen;
                case (byte)LiquidId.DyeLightGray: return Color.LightGray;
                case (byte)LiquidId.DyeLightBlue: return Color.LightBlue;
                case (byte)LiquidId.DyeGreen: return Color.Green;
                case (byte)LiquidId.DyeDarkGreen: return Color.DarkGreen;
                case (byte)LiquidId.DyeGold: return Color.Gold;
                case (byte)LiquidId.DyeDarkBlue: return Color.DarkBlue;
            }
            return Color.Transparent;
        }

        public static bool HasLiquid(ushort id){
             switch (id) {
                //Bottle
                case (ushort)Items.BottleSaltWater: return true;
                case (ushort)Items.BottleWater: return true;
                case (ushort)Items.BottleOil: return true;

                // Bucket
                case (ushort)Items.BucketWater: return true;
                case (ushort)Items.BucketOil: return true;

                // Blocks
                case (ushort)Items.Lava: return true;
                case (ushort)Items.Oil: return true;

                case (ushort)Items.DyeGold: return true;
                case (ushort)Items.DyeWhite: return true;
                case (ushort)Items.DyeYellow: return true;
                case (ushort)Items.DyeOrange: return true;
                case (ushort)Items.DyeRed: return true;
                case (ushort)Items.DyeDarkRed: return true;
                case (ushort)Items.DyeOlive: return true;
                case (ushort)Items.DyePurple: return true;
                case (ushort)Items.DyePink: return true;
                case (ushort)Items.DyeTeal: return true;
                case (ushort)Items.DyeLightBlue: return true;
                case (ushort)Items.DyeBlue: return true;
                case (ushort)Items.DyeMagenta: return true;
                case (ushort)Items.DyeDarkBlue: return true;
                case (ushort)Items.DyeBlack: return true;
                case (ushort)Items.DyeBrown: return true;
                case (ushort)Items.DyeLightGray: return true;
                case (ushort)Items.DyeGray: return true;
                case (ushort)Items.DyeDarkGray: return true;
                case (ushort)Items.DyeViolet: return true;
                case (ushort)Items.DyeSpringGreen: return true;
                case (ushort)Items.DyeRoseQuartz: return true;
                case (ushort)Items.DyeLightGreen: return true;
                case (ushort)Items.DyeGreen: return true;
                case (ushort)Items.DyeArmy: return true;
                case (ushort)Items.DyeDarkGreen: return true;
            }
            return false;
        }

        public static bool ItemsCanBeFill(ushort itemId, byte Liquid, ref int max, ref ushort newId){
            switch (Liquid) {
              
                case (byte)LiquidId.Water:
                    switch (itemId) {
                        case (ushort)Items.Bucket:
                            newId=(ushort)Items.BucketWater;
                            max=255;
                            return true;

                        case (ushort)Items.Bottle:
                            newId=(ushort)Items.BottleWater;
                            max=100;
                            return true;

                        default:
                            return false;
                    }

                case (byte)LiquidId.Oil:
                    switch (itemId) {
                        case (ushort)Items.Bucket:
                            newId=(ushort)Items.BucketOil;
                            max=255;
                            return true;

                        case (ushort)Items.Bottle:
                            newId=(ushort)Items.BottleOil;
                            max=255;
                            return true;

                        default: return false;
                    }

                case (byte)LiquidId.DyeWhite:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeWhite;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeArmy:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeArmy;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeBlack:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeBlack;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeBlue:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeBlue;
                            max=50;
                            return true;

                        case (ushort)Items.ChristmasBallGray:
                            newId=(ushort)Items.ChristmasBallBlue;
                            max=50;
                            return true;

                        default: return false;
                    }

                case (byte)LiquidId.DyeBrown:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeBrown;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeDarkBlue:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeDarkBlue;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeDarkGray:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeDarkGray;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeDarkGreen:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeDarkGreen;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeDarkRed:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeDarkRed;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeGold:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeGold;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeGray:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeGray;
                            max=50;
                            return true;
                        default: return false;

                        case (ushort)Items.ChristmasBallBlue:
                            newId=(ushort)Items.ChristmasBallGray;
                            max=50;
                            return true;
                            
                        case (ushort)Items.ChristmasBallYellow:
                            newId=(ushort)Items.ChristmasBallGray;
                            max=50;
                            return true;

                        case (ushort)Items.ChristmasBallOrange:
                            newId=(ushort)Items.ChristmasBallGray;
                            max=50;
                            return true;

                        case (ushort)Items.ChristmasBallRed:
                            newId=(ushort)Items.ChristmasBallGray;
                            max=50;
                            return true;

                        case (ushort)Items.ChristmasBallPink:
                            newId=(ushort)Items.ChristmasBallGray;
                            max=50;
                            return true;

                        case (ushort)Items.ChristmasBallPurple:
                            newId=(ushort)Items.ChristmasBallGray;
                            max=50;
                            return true;

                        case (ushort)Items.ChristmasBallLightGreen:
                            newId=(ushort)Items.ChristmasBallGray;
                            max=50;
                            return true;
                    }

                case (byte)LiquidId.DyeGreen:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeGreen;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeLightBlue:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeLightBlue;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeLightGray:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeLightGray;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeLightGreen:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeLightGreen;
                            max=50;
                            return true;
                        default: return false;

                        case (ushort)Items.ChristmasBallGray:
                            newId=(ushort)Items.ChristmasBallLightGreen;
                            max=50;
                            return true;
                    }

                case (byte)LiquidId.DyeMagenta:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeMagenta;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeOlive:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeOlive;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeOrange:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeOrange;
                            max=50;
                            return true;
                        default: return false;

                        case (ushort)Items.ChristmasBallGray:
                            newId=(ushort)Items.ChristmasBallOrange;
                            max=50;
                            return true;
                    }

                case (byte)LiquidId.DyePink:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyePink;
                            max=50;
                            return true;
                        default: return false;

                        case (ushort)Items.ChristmasBallGray:
                            newId=(ushort)Items.ChristmasBallPink;
                            max=50;
                            return true;
                    }

                case (byte)LiquidId.DyePurple:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyePurple;
                            max=50;
                            return true;
                        default: return false;

                        case (ushort)Items.ChristmasBallGray:
                            newId=(ushort)Items.ChristmasBallPurple;
                            max=50;
                            return true;
                    }

                case (byte)LiquidId.DyeRed:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeRed;
                            max=50;
                            return true;
                        default: return false;

                        case (ushort)Items.ChristmasBallGray:
                            newId=(ushort)Items.ChristmasBallRed;
                            max=50;
                            return true;
                    }

                case (byte)LiquidId.DyeRoseQuartz:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeRoseQuartz;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeSpringGreen:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeSpringGreen;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeTeal:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeTeal;
                            max=50;
                            return true;
                        default: return false;

                        case (ushort)Items.ChristmasBallGray:
                            newId=(ushort)Items.ChristmasBallTeal;
                            max=50;
                            return true;
                    }

                case (byte)LiquidId.DyeViolet:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeViolet;
                            max=50;
                            return true;
                        default: return false;
                    }

                case (byte)LiquidId.DyeYellow:
                    switch (itemId) {
                        case (ushort)Items.TestTube:
                            newId=(ushort)Items.DyeYellow;
                            max=50;
                            return true;
                        default: return false;

                        case (ushort)Items.ChristmasBallGray:
                            newId=(ushort)Items.ChristmasBallYellow;
                            max=50;
                            return true;
                    }
            }
            return false;
        }

        public static (byte, int, ushort) ItemsIdToLiquid(ushort itemId) {
            switch (itemId) {
                //Bottle
                case (ushort)Items.BottleSaltWater: return ((byte)LiquidId.WaterSalt, 100, (ushort)Items.Bottle);
                case (ushort)Items.BottleWater: return ((byte)LiquidId.Water, 100, (ushort)Items.Bottle);
                case (ushort)Items.BottleOil: return ((byte)LiquidId.Oil, 100, (ushort)Items.Bottle);

                // Bucket
                case (ushort)Items.BucketWater: return ((byte)LiquidId.Water, 255, (ushort)Items.Bucket);
                case (ushort)Items.BucketOil: return ((byte)LiquidId.Oil, 255, (ushort)Items.Bucket);

                // Blocks
                case (ushort)Items.Lava: return ((byte)LiquidId.Lava, 255, (ushort)Items.None);
                case (ushort)Items.Oil: return ((byte)LiquidId.Oil, 255, (ushort)Items.None);


                case (ushort)Items.DyeArmy: return ((byte)LiquidId.DyeArmy, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeBlack: return ((byte)LiquidId.DyeBlack, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeBlue: return ((byte)LiquidId.DyeBlue, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeBrown: return ((byte)LiquidId.DyeBrown, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeDarkBlue: return ((byte)LiquidId.DyeDarkBlue, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeDarkGray: return ((byte)LiquidId.DyeDarkGray, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeDarkGreen: return ((byte)LiquidId.DyeDarkGreen, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeDarkRed: return ((byte)LiquidId.DyeDarkRed, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeGold: return ((byte)LiquidId.DyeGold, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeGray: return ((byte)LiquidId.DyeGray, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeGreen: return ((byte)LiquidId.DyeGreen, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeLightBlue: return ((byte)LiquidId.DyeLightBlue, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeLightGray: return ((byte)LiquidId.DyeLightGray, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeLightGreen: return ((byte)LiquidId.DyeLightGreen, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeMagenta: return ((byte)LiquidId.DyeMagenta, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeOlive: return ((byte)LiquidId.DyeOlive, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeOrange: return ((byte)LiquidId.DyeOrange, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyePink: return ((byte)LiquidId.DyePink, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyePurple: return ((byte)LiquidId.DyePurple, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeRed: return ((byte)LiquidId.DyeRed, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeRoseQuartz: return ((byte)LiquidId.DyeRoseQuartz, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeSpringGreen: return ((byte)LiquidId.DyeTeal, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeViolet: return ((byte)LiquidId.DyeViolet, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeWhite: return ((byte)LiquidId.DyeWhite, 50, (ushort)Items.TestTube);
                case (ushort)Items.DyeYellow: return ((byte)LiquidId.DyeYellow, 50, (ushort)Items.TestTube);

                //    case (ushort)Items.TShirt: return ((byte)LiquidId.None, 50, (ushort)Items.TestTube);


                //case (ushort)Items.DyeWhite: return ((byte)LiquidId.DyeWhite,);
                //case (ushort)Items.DyeYellow: return (byte)LiquidId.DyeYellow;
                //case (ushort)Items.DyeGold: return (byte)LiquidId.DyeGold;
                //case (ushort)Items.DyeOrange: return (byte)LiquidId.DyeOrange;
                //case (ushort)Items.DyeRed: return (byte)LiquidId.DyeRed;
                //case (ushort)Items.DyeDarkRed: return (byte)LiquidId.DyeDarkRed;
                //case (ushort)Items.DyePink: return (byte)LiquidId.DyePink;
                //case (ushort)Items.DyePurple: return (byte)LiquidId.DyePurple;
                //case (ushort)Items.DyeLightBlue: return (byte)LiquidId.DyeLightBlue;
                //case (ushort)Items.DyeBlue: return (byte)LiquidId.DyeBlue;
                //case (ushort)Items.DyeDarkBlue: return (byte)LiquidId.DyeDarkBlue;
                //case (ushort)Items.DyeTeal: return (byte)LiquidId.DyeTeal;
                //case (ushort)Items.DyeLightGreen: return (byte)LiquidId.DyeLightGreen;
                //case (ushort)Items.DyeGreen: return (byte)LiquidId.DyeGreen;
                //case (ushort)Items.DyeDarkGreen: return (byte)LiquidId.DyeDarkGreen;
                //case (ushort)Items.DyeBrown: return (byte)LiquidId.DyeBrown;
                //case (ushort)Items.DyeLightGray: return (byte)LiquidId.DyeLightGray;
                //case (ushort)Items.DyeGray: return (byte)LiquidId.DyeGray;
                //case (ushort)Items.DyeDarkGray: return (byte)LiquidId.DyeDarkGray;
                //case (ushort)Items.DyeBlack: return (byte)LiquidId.DyeBlack;
                //case (ushort)Items.DyeArmy: return (byte)LiquidId.DyeArmy;
                //case (ushort)Items.DyeMagenta: return (byte)LiquidId.DyeMagenta;
                //case (ushort)Items.DyeRoseQuartz: return (byte)LiquidId.DyeRoseQuartz;
                //case (ushort)Items.DyeSpringGreen: return (byte)LiquidId.DyeSpringGreen;
                //case (ushort)Items.DyeViolet: return (byte)LiquidId.DyeViolet;
                //case (ushort)Items.DyeOlive: return (byte)LiquidId.DyeOlive;

                //case (ushort)BlockId.WaterBlock: return (byte)LiquidId.Vinegar;
                //case (ushort)BlockId.WaterBlock: return (byte)LiquidId.Alcohol;
                //case (ushort)BlockId.WaterBlock: return (byte)LiquidId.Brine;
            }
            return ((byte)LiquidId.None, 0, (ushort)Items.None);
        }

        public static void SealReceipe(ushort id, byte liquid, ref ushort newId, ref ushort newLiquid, ref int liquidAmount, ref TimeSpan timeSpan) {
            switch (id) {
                case (ushort)Items.Apple:
                    if (liquid==0) {
                        newId=0;
                        newLiquid=(byte)LiquidId.Alcohol;
                        liquidAmount=50;
                        timeSpan=new TimeSpan(0, 60*3, 0);
                    }
                    return;

                case (ushort)Items.Cherry:
                    if (liquid==0) {
                        newId=0;
                        newLiquid=(byte)LiquidId.Alcohol;
                        liquidAmount=50;
                        timeSpan=new TimeSpan(0, 60*3, 0);
                    }
                    return;

                case (ushort)Items.Plum:
                    if (liquid==0) {
                        newId=0;
                        newLiquid=(byte)LiquidId.Alcohol;
                        liquidAmount=50;
                        timeSpan=new TimeSpan(0, 60*3, 0);
                    }
                    return;

                case (ushort)Items.Banana:
                    if (liquid==0) {
                        newId=0;
                        newLiquid=(byte)LiquidId.Alcohol;
                        liquidAmount=50;
                        timeSpan=new TimeSpan(0, 60*3, 0);
                    }
                    return;

                case (ushort)Items.Orange:
                    if (liquid==0) {
                        newId=0;
                        newLiquid=(byte)LiquidId.Alcohol;
                        liquidAmount=50;
                        timeSpan=new TimeSpan(0, 60*3, 0);
                    }
                    return;

            }
            return;
        }
    }
}