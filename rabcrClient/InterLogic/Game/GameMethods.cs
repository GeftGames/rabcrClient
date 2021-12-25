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


        public static bool IsHalfShadowBlock(ushort id) 
            => id switch {
                (ushort)BlockId.AcaciaLeaves => true,
                (ushort)BlockId.AppleLeaves => true,
                (ushort)BlockId.AppleLeavesWithApples => true,
                (ushort)BlockId.AppleLeavesBlossom => true,
                (ushort)BlockId.CherryLeaves => true,
                (ushort)BlockId.CherryLeavesBlossom => true,
                (ushort)BlockId.CherryLeavesWithCherries => true,
                (ushort)BlockId.EucalyptusLeaves => true,
                (ushort)BlockId.KapokLeaves => true,
                (ushort)BlockId.LemonLeaves => true,
                (ushort)BlockId.LemonLeavesWithLemons => true,
                (ushort)BlockId.LindenLeaves => true,
                (ushort)BlockId.MangroveLeaves => true,
                (ushort)BlockId.OakLeaves => true,
                (ushort)BlockId.OliveLeaves => true,
                (ushort)BlockId.OliveLeavesWithOlives => true,
                (ushort)BlockId.OrangeLeaves => true,
                (ushort)BlockId.OrangeLeavesWithOranges => true,
                (ushort)BlockId.PineLeaves => true,
                (ushort)BlockId.PlumLeaves => true,
                (ushort)BlockId.PlumLeavesBlossom => true,
                (ushort)BlockId.PlumLeavesWithPlums => true,
                (ushort)BlockId.RubberTreeLeaves => true,
                (ushort)BlockId.SpruceLeaves => true,
                (ushort)BlockId.WillowLeaves => true,
                (ushort)BlockId.Ice => true,
                (ushort)BlockId.WaterBlock => true,
                (ushort)BlockId.WaterSalt => true,
                _ => false,
            };
        
        public static bool IsLeaves(ushort id) => id switch {
                (ushort)BlockId.AcaciaLeaves => true,
                (ushort)BlockId.AppleLeaves => true,
                (ushort)BlockId.AppleLeavesWithApples => true,
                (ushort)BlockId.AppleLeavesBlossom => true,
                (ushort)BlockId.CherryLeaves => true,
                (ushort)BlockId.CherryLeavesBlossom => true,
                (ushort)BlockId.CherryLeavesWithCherries => true,
                (ushort)BlockId.EucalyptusLeaves => true,
                (ushort)BlockId.KapokLeaves => true,
                (ushort)BlockId.LemonLeaves => true,
                (ushort)BlockId.LemonLeavesWithLemons => true,
                (ushort)BlockId.LindenLeaves => true,
                (ushort)BlockId.MangroveLeaves => true,
                (ushort)BlockId.OakLeaves => true,
                (ushort)BlockId.OliveLeaves => true,
                (ushort)BlockId.OliveLeavesWithOlives => true,
                (ushort)BlockId.OrangeLeaves => true,
                (ushort)BlockId.OrangeLeavesWithOranges => true,
                (ushort)BlockId.PineLeaves => true,
                (ushort)BlockId.PlumLeaves => true,
                (ushort)BlockId.PlumLeavesBlossom => true,
                (ushort)BlockId.PlumLeavesWithPlums => true,
                (ushort)BlockId.RubberTreeLeaves => true,
                (ushort)BlockId.SpruceLeaves => true,
                (ushort)BlockId.WillowLeaves => true,
                _ => false,
            };
        
        public static bool IsSelectedShears(ushort id) => id switch {
            (ushort)Items.ShearsCopper => true,
            (ushort)Items.ShearsBronze => true,
            (ushort)Items.ShearsGold => true,
            (ushort)Items.ShearsIron => true,
            (ushort)Items.ShearsSteel => true,
            (ushort)Items.ShearsAluminium => true,
            _ => false,
        };
        

		public static bool IsSelectedKnife(ushort id) 
            => id switch {
                (ushort)Items.KnifeCopper => true,
                (ushort)Items.KnifeBronze => true,
                (ushort)Items.KnifeGold => true,
                (ushort)Items.KnifeIron => true,
                (ushort)Items.KnifeSteel => true,
                (ushort)Items.KnifeAluminium => true,
                _ => false,
            };
        
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

        public static ushort ToolToBasic(ushort i) => i switch {
            (ushort)Items.BucketOil => (ushort)Items.Bucket,
            (ushort)Items.BucketWater => (ushort)Items.Bucket,
            (ushort)Items.TorchElectricON => (ushort)Items.TorchElectricOFF,
            (ushort)Items.LighterON => (ushort)Items.LighterOFF,
            (ushort)Items.BottleOil => (ushort)Items.Bottle,
            (ushort)Items.BottleWater => (ushort)Items.Bottle,
            (ushort)Items.ElectricDrill => (ushort)Items.ElectricDrillOff,
            (ushort)Items.ElectricSaw => (ushort)Items.ElectricSawOff,
            _ => (ushort)Items.None,
        };
        
        public static int ToolMax(ushort id)
            => id switch {
                (ushort)Items.AxeStone => 50,
                (ushort)Items.PickaxeStone => 50,
                (ushort)Items.ShovelStone => 50,
                (ushort)Items.HoeStone => 50,
                (ushort)Items.HoeCopper => 200,
                (ushort)Items.KnifeCopper => 200,
                (ushort)Items.SawCopper => 200,
                (ushort)Items.ShearsCopper => 200,
                (ushort)Items.HammerCopper => 200,
                (ushort)Items.PickaxeCopper => 200,
                (ushort)Items.ShovelCopper => 200,
                (ushort)Items.AxeCopper => 200,
                (ushort)Items.HammerBronze => 250,
                (ushort)Items.HoeBronze => 250,
                (ushort)Items.KnifeBronze => 250,
                (ushort)Items.SawBronze => 250,
                (ushort)Items.ShearsBronze => 250,
                (ushort)Items.PickaxeBronze => 250,
                (ushort)Items.ShovelBronze => 250,
                (ushort)Items.AxeBronze => 250,
                (ushort)Items.AxeIron => 300,
                (ushort)Items.HammerIron => 300,
                (ushort)Items.HoeIron => 300,
                (ushort)Items.PickaxeIron => 300,
                (ushort)Items.ShovelIron => 300,
                (ushort)Items.KnifeIron => 300,
                (ushort)Items.SawIron => 300,
                (ushort)Items.ShearsIron => 300,
                (ushort)Items.AxeSteel => 350,
                (ushort)Items.HammerSteel => 350,
                (ushort)Items.HoeSteel => 350,
                (ushort)Items.PickaxeSteel => 350,
                (ushort)Items.ShovelSteel => 350,
                (ushort)Items.KnifeSteel => 350,
                (ushort)Items.SawSteel => 350,
                (ushort)Items.ShearsSteel => 350,
                (ushort)Items.AxeAluminium => 150,
                (ushort)Items.HammerAluminium => 150,
                (ushort)Items.HoeAluminium => 150,
                (ushort)Items.PickaxeAluminium => 150,
                (ushort)Items.ShovelAluminium => 150,
                (ushort)Items.KnifeAluminium => 150,
                (ushort)Items.SawAluminium => 150,
                (ushort)Items.ShearsAluminium => 150,
                (ushort)Items.AxeGold => 5,
                (ushort)Items.HammerGold => 5,
                (ushort)Items.HoeGold => 5,
                (ushort)Items.PickaxeGold => 5,
                (ushort)Items.ShovelGold => 5,
                (ushort)Items.KnifeGold => 5,
                (ushort)Items.SawGold => 5,
                (ushort)Items.ShearsGold => 5,
                (ushort)Items.ElectricDrill => 400,
                (ushort)Items.ElectricSaw => 400,
                (ushort)Items.TorchElectricON => 400,
                (ushort)Items.Gun => 1000,
                (ushort)Items.AirTank => 1000,
                (ushort)Items.AirTank2 => 2000,
                (ushort)Items.BucketWater => 255,
                (ushort)Items.BucketOil => 255,
                (ushort)Items.BottleOil => 50,
                (ushort)Items.BottleWater => 50,
                (ushort)Items.TorchON => 100,
                (ushort)Items.DyeArmy => 50,
                (ushort)Items.DyeBlack => 50,
                (ushort)Items.DyeBlue => 50,
                (ushort)Items.DyeBrown => 50,
                (ushort)Items.DyeDarkBlue => 50,
                (ushort)Items.DyeDarkGray => 50,
                (ushort)Items.DyeDarkGreen => 50,
                (ushort)Items.DyeDarkRed => 50,
                (ushort)Items.DyeGold => 50,
                (ushort)Items.DyeGray => 50,
                (ushort)Items.DyeGreen => 50,
                (ushort)Items.DyeLightBlue => 50,
                (ushort)Items.DyeLightGray => 50,
                (ushort)Items.DyeLightGreen => 50,
                (ushort)Items.DyeMagenta => 50,
                (ushort)Items.DyeOlive => 50,
                (ushort)Items.DyeOrange => 50,
                (ushort)Items.DyePink => 50,
                (ushort)Items.DyePurple => 50,
                (ushort)Items.DyeRed => 50,
                (ushort)Items.DyeRoseQuartz => 50,
                (ushort)Items.DyeSpringGreen => 50,
                (ushort)Items.DyeTeal => 50,
                (ushort)Items.DyeViolet => 50,
                (ushort)Items.DyeWhite => 50,
                (ushort)Items.DyeYellow => 50,
                (ushort)Items.ItemBattery => 99,
                #if DEBUG
                _ => throw new System.Exception("Tool " + (Items)id + " not found in switch above"),
                #else
                _=>-1,
                #endif
            };
        
        //public static int BurnWoodInFurnace(ushort id){
        //    switch (id){
        //        case (ushort)Items.ItemCoal: return 45;
        //        case (ushort)Items.CoalWood: return 40;
        //        case (ushort)Items.WoodOak: return 32;
        //        case (ushort)Items.WoodLinden: return 32;
        //        case (ushort)Items.WoodCherry: return 29;
        //        case (ushort)Items.WoodApple: return 30;
        //        case (ushort)Items.WoodLemon: return 29;
        //        case (ushort)Items.WoodSpruce: return 30;
        //        case (ushort)Items.WoodPlum: return 30;
        //        case (ushort)Items.WoodPine: return 29;
        //        case (ushort)Items.WoodOrange: return 30;
        //        case (ushort)Items.Stick: return 11;
        //        case (ushort)Items.CoalDust: return 10;
        //        case (ushort)Items.Sticks: return 9;
        //        case (ushort)Items.WoodDust: return 5;
        //        case (ushort)Items.Paper: return 2;
        //        case (ushort)Items.Gunpowder: return 1;
        //    }
        //    return 0;
        //}

        public static bool IsCompostable(ushort id)
            => id switch {
                (ushort)Items.Alore => true,
                (ushort)Items.Apple => true,
                (ushort)Items.AppleLeaves => true,
                (ushort)Items.AppleLeavesWithApples => true,
                (ushort)Items.AppleSapling => true,
                (ushort)Items.Ash => true,
                (ushort)Items.Banana => true,
                (ushort)Items.Blueberries => true,
                (ushort)Items.Boletus => true,
                (ushort)Items.CactusBig => true,
                (ushort)Items.CactusSmall => true,
                (ushort)Items.Carrot => true,
                (ushort)Items.Champignon => true,
                (ushort)Items.Cherry => true,
                (ushort)Items.CherryLeaves => true,
                (ushort)Items.CherryLeavesWithCherries => true,
                (ushort)Items.CherrySapling => true,
                (ushort)Items.Cloth => true,
                (ushort)Items.CoalDust => true,
                (ushort)Items.Coral => true,
                (ushort)Items.Dandelion => true,
                (ushort)Items.FishMeat => true,
                (ushort)Items.Flax => true,
                (ushort)Items.FlaxSeeds => true,
                (ushort)Items.GrassBlockClay => true,
                (ushort)Items.GrassBlockDesert => true,
                (ushort)Items.GrassBlockForest => true,
                (ushort)Items.GrassBlockHills => true,
                (ushort)Items.GrassBlockJungle => true,
                (ushort)Items.GrassBlockPlains => true,
                (ushort)Items.GrassDesert => true,
                (ushort)Items.GrassForest => true,
                (ushort)Items.GrassHills => true,
                (ushort)Items.GrassJungle => true,
                (ushort)Items.GrassPlains => true,
                (ushort)Items.Hay => true,
                (ushort)Items.HayBlock => true,
                (ushort)Items.Heater => true,
                (ushort)Items.Leave => true,
                (ushort)Items.Lemon => true,
                (ushort)Items.LemonLeaves => true,
                (ushort)Items.LemonLeavesWithLemons => true,
                (ushort)Items.LemonSapling => true,
                (ushort)Items.LindenLeaves => true,
                (ushort)Items.LindenSapling => true,
                (ushort)Items.MudIngot => true,
                (ushort)Items.OakLeaves => true,
                (ushort)Items.OakSapling => true,
                (ushort)Items.Onion => true,
                (ushort)Items.Orange => true,
                (ushort)Items.OrangeLeaves => true,
                (ushort)Items.OrangeLeavesWithOranges => true,
                (ushort)Items.OrangeSapling => true,
                (ushort)Items.Paper => true,
                (ushort)Items.Peas => true,
                (ushort)Items.PineLeaves => true,
                (ushort)Items.PineSapling => true,
                (ushort)Items.PlantBlueberry => true,
                (ushort)Items.PlantCarrot => true,
                (ushort)Items.PlantOnion => true,
                (ushort)Items.PlantOrchid => true,
                (ushort)Items.PlantPeas => true,
                (ushort)Items.PlantRashberry => true,
                (ushort)Items.PlantRose => true,
                (ushort)Items.PlantStrawberry => true,
                (ushort)Items.PlantViolet => true,
                (ushort)Items.Plum => true,
                (ushort)Items.PlumLeaves => true,
                (ushort)Items.PlumLeavesWithPlums => true,
                (ushort)Items.PlumSapling => true,
                (ushort)Items.RabbitMeat => true,
                (ushort)Items.RabbitMeatCooked => true,
                (ushort)Items.Rashberry => true,
                (ushort)Items.Rope => true,
                (ushort)Items.Seaweed => true,
                (ushort)Items.Seeds => true,
                (ushort)Items.Stick => true,
                (ushort)Items.Sticks => true,
                (ushort)Items.Strawberry => true,
                (ushort)Items.SugarCane => true,
                (ushort)Items.WheatStraw => true,
                (ushort)Items.Yarn => true,
                (ushort)Items.GrassBlockCompost => true,
                (ushort)Items.Egg => true,
                (ushort)Items.boiledEgg => true,
                (ushort)Items.Saltpeter => true,
                _ => false,
            };
        
        public static bool IsLeave(ushort id) 
            => id switch {
                // Frequent leaves
                (ushort)BlockId.SpruceLeaves => true,
                // Frequent branches
                (ushort)BlockId.OakBranches => true,
                (ushort)BlockId.LindenBranches => true,
                (ushort)BlockId.LindenBranchesSnow => true,
                (ushort)BlockId.WillowBranches => true,
                (ushort)BlockId.WillowBranchesSnow => true,
                // Fruit branches
                (ushort)BlockId.AppleBranches => true,
                (ushort)BlockId.AppleBranchesSnow => true,
                (ushort)BlockId.CherryBranches => true,
                (ushort)BlockId.CherryBranchesSnow => true,
                (ushort)BlockId.PlumBranches => true,
                (ushort)BlockId.PlumBranchesSnow => true,
                // Non-frequent leaves
                (ushort)BlockId.WillowLeaves => true,
                (ushort)BlockId.OakLeaves => true,
                (ushort)BlockId.LindenLeaves => true,
                // Fruit leaves
                (ushort)BlockId.AppleLeaves => true,
                (ushort)BlockId.AppleLeavesBlossom => true,
                (ushort)BlockId.AppleLeavesWithApples => true,
                (ushort)BlockId.CherryLeaves => true,
                (ushort)BlockId.CherryLeavesBlossom => true,
                (ushort)BlockId.CherryLeavesWithCherries => true,
                (ushort)BlockId.PlumLeaves => true,
                (ushort)BlockId.PlumLeavesBlossom => true,
                (ushort)BlockId.PlumLeavesWithPlums => true,
                // Leaves in Hot biomes
                (ushort)BlockId.OrangeLeaves => true,
                (ushort)BlockId.OrangeLeavesWithOranges => true,
                (ushort)BlockId.OliveLeaves => true,
                (ushort)BlockId.OliveLeavesWithOlives => true,
                (ushort)BlockId.LemonLeaves => true,
                (ushort)BlockId.LemonLeavesWithLemons => true,
                (ushort)BlockId.PineLeaves => true,
                (ushort)BlockId.AcaciaLeaves => true,
                (ushort)BlockId.EucalyptusLeaves => true,
                (ushort)BlockId.MangroveLeaves => true,
                (ushort)BlockId.RubberTreeLeaves => true,
                (ushort)BlockId.KapokLeaves => true,
                (ushort)BlockId.KapokLeacesFlowering => true,
                (ushort)BlockId.KapokLeacesFibre => true,
                _ => false,
            };
        
        #region Blocks from Items
        public static ushort BackBlockFromItem(ushort item) 
            => item switch {
                // Blocks
                (ushort)Items.Lava => (ushort)BlockId.Lava,
                // Backs
                (ushort)Items.BackCobblestone => (ushort)BlockId.BackCobblestone,
                (ushort)Items.BackSand => (ushort)BlockId.BackSand,
                (ushort)Items.BackDirt => (ushort)BlockId.BackDirt,
                (ushort)Items.BackAluminium => (ushort)BlockId.BackAluminium,
                (ushort)Items.BackAnorthosite => (ushort)BlockId.BackAnorthosite,
                (ushort)Items.BackBasalt => (ushort)BlockId.BackBasalt,
                (ushort)Items.BackClay => (ushort)BlockId.BackClay,
                (ushort)Items.BackCoal => (ushort)BlockId.BackCoal,
                (ushort)Items.BackCopper => (ushort)BlockId.BackCopper,
                (ushort)Items.BackDiorit => (ushort)BlockId.BackDiorit,
                (ushort)Items.BackDolomite => (ushort)BlockId.BackDolomite,
                (ushort)Items.BackFlint => (ushort)BlockId.BackFlint,
                (ushort)Items.BackGabbro => (ushort)BlockId.BackGabbro,
                (ushort)Items.BackGneiss => (ushort)BlockId.BackGneiss,
                (ushort)Items.BackGold => (ushort)BlockId.BackGold,
                (ushort)Items.BackGravel => (ushort)BlockId.BackGravel,
                (ushort)Items.BackIron => (ushort)BlockId.BackIron,
                (ushort)Items.BackLimestone => (ushort)BlockId.BackLimestone,
                (ushort)Items.BackMudstone => (ushort)BlockId.BackMudstone,
                (ushort)Items.BackRedSand => (ushort)BlockId.BackRedSand,
                (ushort)Items.BackRegolite => (ushort)BlockId.BackRegolite,
                (ushort)Items.BackRhyolite => (ushort)BlockId.BackRhyolite,
                (ushort)Items.BackSaltpeter => (ushort)BlockId.BackSaltpeter,
                (ushort)Items.BackSandstone => (ushort)BlockId.BackSandstone,
                (ushort)Items.BackSchist => (ushort)BlockId.BackSchist,
                (ushort)Items.BackSilver => (ushort)BlockId.BackSilver,
                (ushort)Items.BackSulfur => (ushort)BlockId.BackSulfur,
                (ushort)Items.BackTin => (ushort)BlockId.BackTin,
                // Wood
                (ushort)Items.WoodApple => (ushort)BlockId.AppleWood,
                (ushort)Items.WoodCherry => (ushort)BlockId.CherryWood,
                (ushort)Items.WoodLemon => (ushort)BlockId.LemonWood,
                (ushort)Items.WoodLinden => (ushort)BlockId.LindenWood,
                (ushort)Items.WoodOak => (ushort)BlockId.OakWood,
                (ushort)Items.WoodOrange => (ushort)BlockId.OrangeWood,
                (ushort)Items.WoodPine => (ushort)BlockId.PineWood,
                (ushort)Items.WoodPlum => (ushort)BlockId.PlumWood,
                (ushort)Items.WoodSpruce => (ushort)BlockId.SpruceWood,
                (ushort)Items.AcaciaWood => (ushort)BlockId.AcaciaWood,
                (ushort)Items.EucalyptusWood => (ushort)BlockId.EucalyptusWood,
                (ushort)Items.KapokWood => (ushort)BlockId.KapokWood,
                (ushort)Items.MangroveWood => (ushort)BlockId.MangroveWood,
                (ushort)Items.OliveWood => (ushort)BlockId.OliveWood,
                (ushort)Items.RubberTreeWood => (ushort)BlockId.RubberTreeWood,
                (ushort)Items.WillowWood => (ushort)BlockId.WillowWood,
                (ushort)Items.Glass => (ushort)BlockId.Glass,
                (ushort)Items.AdvancedSpaceBack => (ushort)BlockId.AdvancedSpaceBack,
                (ushort)Items.AdvancedSpaceWindow => (ushort)BlockId.AdvancedSpaceWindow,
                _ => (ushort)BlockId.None,
            };
        
        public static ushort SolidBlockFromItem(ushort item) 
            => item switch {
                // Stone
                (ushort)Items.StoneBasalt => (ushort)BlockId.StoneBasalt,
                (ushort)Items.StoneDiorit => (ushort)BlockId.StoneDiorit,
                (ushort)Items.StoneDolomite => (ushort)BlockId.StoneDolomite,
                (ushort)Items.StoneGabbro => (ushort)BlockId.StoneGabbro,
                (ushort)Items.StoneGneiss => (ushort)BlockId.StoneGneiss,
                (ushort)Items.StoneLimestone => (ushort)BlockId.StoneLimestone,
                (ushort)Items.StoneRhyolite => (ushort)BlockId.StoneRhyolite,
                (ushort)Items.StoneSandstone => (ushort)BlockId.StoneSandstone,
                (ushort)Items.StoneSchist => (ushort)BlockId.StoneSchist,
                // Ore
                (ushort)Items.OreAluminium => (ushort)BlockId.OreAluminium,
                (ushort)Items.OreCopper => (ushort)BlockId.OreCopper,
                (ushort)Items.OreGold => (ushort)BlockId.OreGold,
                (ushort)Items.OreIron => (ushort)BlockId.OreIron,
                (ushort)Items.OreSilver => (ushort)BlockId.OreSilver,
                (ushort)Items.OreTin => (ushort)BlockId.OreTin,
                (ushort)Items.OreCoal => (ushort)BlockId.OreCoal,
                (ushort)Items.OreSulfur => (ushort)BlockId.OreSulfur,
                (ushort)Items.OreSaltpeter => (ushort)BlockId.OreSaltpeter,
                // Blocks
                (ushort)Items.Dirt => (ushort)BlockId.Dirt,
                (ushort)Items.Gravel => (ushort)BlockId.Gravel,
                (ushort)Items.Stonerubble => (ushort)BlockId.Cobblestone,
                (ushort)Items.Sand => (ushort)BlockId.Sand,
                (ushort)Items.Ice => (ushort)BlockId.Ice,
                (ushort)Items.Compost => (ushort)BlockId.Compost,
                // Grass
                (ushort)Items.GrassBlockDesert => (ushort)BlockId.GrassBlockDesert,
                (ushort)Items.GrassBlockForest => (ushort)BlockId.GrassBlockForest,
                (ushort)Items.GrassBlockHills => (ushort)BlockId.GrassBlockHills,
                (ushort)Items.GrassBlockJungle => (ushort)BlockId.GrassBlockJungle,
                (ushort)Items.GrassBlockPlains => (ushort)BlockId.GrassBlockPlains,
                (ushort)Items.GrassBlockCompost => (ushort)BlockId.GrassBlockCompost,
                // Artifical
                (ushort)Items.Roof1 => (ushort)BlockId.Roof1,
                (ushort)Items.Roof2 => (ushort)BlockId.Roof2,
                (ushort)Items.Bricks => (ushort)BlockId.Bricks,
                (ushort)Items.Door => (ushort)BlockId.DoorClose,
                (ushort)Items.Planks => (ushort)BlockId.Planks,
                (ushort)Items.AdvancedSpaceBlock => (ushort)BlockId.AdvancedSpaceBlock,
                (ushort)Items.AdvancedSpaceFloor => (ushort)BlockId.AdvancedSpaceFloor,
                (ushort)Items.AdvancedSpacePart1 => (ushort)BlockId.AdvancedSpacePart1,
                (ushort)Items.AdvancedSpacePart2 => (ushort)BlockId.AdvancedSpacePart2,
                (ushort)Items.AdvancedSpacePart3 => (ushort)BlockId.AdvancedSpacePart3,
                (ushort)Items.AdvancedSpacePart4 => (ushort)BlockId.AdvancedSpacePart4,
                (ushort)Items.Snow => (ushort)BlockId.Snow,
                _ => (ushort)BlockId.None,
            };
        
        public static ushort TopBlockFromItem(ushort item) 
            => item switch {
                (ushort)Items.ChristmasStar => (ushort)BlockId.ChristmasStar,
                (ushort)Items.Egg => (ushort)BlockId.EggDrop,
                (ushort)Items.BucketForRubber => (ushort)BlockId.BucketForRubber,
                (ushort)Items.Shelf => (ushort)BlockId.Shelf,
                (ushort)Items.Barrel => (ushort)BlockId.Barrel,
                (ushort)Items.BoxWooden => (ushort)BlockId.BoxWooden,
                (ushort)Items.BoxAdv => (ushort)BlockId.BoxAdv,
                (ushort)Items.OxygenMachine => (ushort)BlockId.OxygenMachine,
                // Leaves
                (ushort)Items.AppleLeaves => (ushort)BlockId.AppleLeaves,
                (ushort)Items.LemonLeavesWithLemons => (ushort)BlockId.LemonLeavesWithLemons,
                (ushort)Items.LindenLeaves => (ushort)BlockId.LindenLeaves,
                (ushort)Items.OakLeaves => (ushort)BlockId.OakLeaves,
                (ushort)Items.OrangeLeaves => (ushort)BlockId.OrangeLeaves,
                (ushort)Items.SpruceLeaves => (ushort)BlockId.SpruceLeaves,
                (ushort)Items.PlumLeavesWithPlums => (ushort)BlockId.PlumLeavesWithPlums,
                (ushort)Items.PlumLeaves => (ushort)BlockId.PlumLeaves,
                (ushort)Items.PineLeaves => (ushort)BlockId.PineLeaves,
                (ushort)Items.OrangeLeavesWithOranges => (ushort)BlockId.OrangeLeavesWithOranges,
                (ushort)Items.AppleLeavesWithApples => (ushort)BlockId.AppleLeavesWithApples,
                (ushort)Items.CherryLeaves => (ushort)BlockId.CherryLeaves,
                (ushort)Items.CherryLeavesWithCherries => (ushort)BlockId.CherryLeavesWithCherries,
                (ushort)Items.LemonLeaves => (ushort)BlockId.LemonLeaves,
                (ushort)Items.WillowLeaves => (ushort)BlockId.WillowLeaves,
                (ushort)Items.WillowWood => (ushort)BlockId.WillowWood,
                (ushort)Items.MangroveLeaves => (ushort)BlockId.MangroveLeaves,
                (ushort)Items.MangroveWood => (ushort)BlockId.MangroveWood,
                (ushort)Items.EucalyptusLeaves => (ushort)BlockId.EucalyptusLeaves,
                (ushort)Items.EucalyptusWood => (ushort)BlockId.EucalyptusWood,
                (ushort)Items.OliveLeavesWithOlives => (ushort)BlockId.OliveLeavesWithOlives,
                (ushort)Items.OliveLeaves => (ushort)BlockId.OliveLeaves,
                (ushort)Items.OliveWood => (ushort)BlockId.OliveWood,
                (ushort)Items.RubberTreeLeaves => (ushort)BlockId.RubberTreeLeaves,
                (ushort)Items.RubberTreeWood => (ushort)BlockId.RubberTreeWood,
                (ushort)Items.AcaciaLeaves => (ushort)BlockId.AcaciaLeaves,
                (ushort)Items.AcaciaWood => (ushort)BlockId.AcaciaWood,
                (ushort)Items.KapokLeacesFlowering => (ushort)BlockId.KapokLeacesFlowering,
                (ushort)Items.KapokLeavesFibre => (ushort)BlockId.KapokLeacesFibre,
                (ushort)Items.KapokLeaves => (ushort)BlockId.KapokLeaves,
                (ushort)Items.KapokWood => (ushort)BlockId.KapokWood,
                (ushort)Items.WillowSapling => (ushort)BlockId.WillowSapling,
                (ushort)Items.MangroveSapling => (ushort)BlockId.MangroveSapling,
                (ushort)Items.EucalyptusSapling => (ushort)BlockId.EucalyptusSapling,
                (ushort)Items.OliveSapling => (ushort)BlockId.OliveSapling,
                (ushort)Items.RubberTreeSapling => (ushort)BlockId.RubberTreeSapling,
                (ushort)Items.AcaciaSapling => (ushort)BlockId.AcaciaSapling,
                (ushort)Items.KapokSapling => (ushort)BlockId.KapokSapling,
                // Blocks
                (ushort)Items.SnowTop => (ushort)BlockId.SnowTop,
                (ushort)Items.Glass => (ushort)BlockId.Glass,
                (ushort)Items.Oil => (ushort)BlockId.Oil,
                (ushort)Items.BucketWater => (ushort)BlockId.WaterBlock,
                (ushort)Items.Stick => (ushort)BlockId.BranchWithout,
                // Saplings
                (ushort)Items.AppleSapling => (ushort)BlockId.AppleSapling,
                (ushort)Items.OrangeSapling => (ushort)BlockId.OrangeSapling,
                (ushort)Items.PineSapling => (ushort)BlockId.PineSapling,
                (ushort)Items.CherrySapling => (ushort)BlockId.CherrySapling,
                (ushort)Items.PlumSapling => (ushort)BlockId.PlumSapling,
                (ushort)Items.LemonSapling => (ushort)BlockId.LemonSapling,
                (ushort)Items.OakSapling => (ushort)BlockId.OakSapling,
                (ushort)Items.SpruceSapling => (ushort)BlockId.SpruceSapling,
                (ushort)Items.LindenSapling => (ushort)BlockId.LindenSapling,
                // Flowers
                (ushort)Items.Alore => (ushort)BlockId.Alore,
                (ushort)Items.PlantRose => (ushort)BlockId.Rose,
                (ushort)Items.PlantViolet => (ushort)BlockId.Violet,
                (ushort)Items.Dandelion => (ushort)BlockId.Dandelion,
                (ushort)Items.PlantOrchid => (ushort)BlockId.Orchid,
                (ushort)Items.CactusBig => (ushort)BlockId.CactusBig,
                (ushort)Items.CactusSmall => (ushort)BlockId.CactusSmall,
                // Grass
                (ushort)Items.GrassDesert => (ushort)BlockId.GrassDesert,
                (ushort)Items.GrassForest => (ushort)BlockId.GrassForest,
                (ushort)Items.GrassHills => (ushort)BlockId.GrassHills,
                (ushort)Items.GrassJungle => (ushort)BlockId.GrassJungle,
                (ushort)Items.GrassPlains => (ushort)BlockId.GrassPlains,
                // Artifical Blocks
                (ushort)Items.Door => (ushort)BlockId.DoorOpen,
                // Mechanical
                (ushort)Items.Desk => (ushort)BlockId.Desk,
                (ushort)Items.Flag => (ushort)BlockId.Flag,
                (ushort)Items.Ladder => (ushort)BlockId.Ladder,
                (ushort)Items.TorchON => (ushort)BlockId.BurningTorch,
                // Electrical
                (ushort)Items.Lamp => (ushort)BlockId.Lamp,
                (ushort)Items.Radio => (ushort)BlockId.Radio,
                (ushort)Items.WindMill => (ushort)BlockId.Windmill,
                (ushort)Items.Label => (ushort)BlockId.Label,
                (ushort)Items.Rocket => (ushort)BlockId.Rocket,
                (ushort)Items.SewingMachine => (ushort)BlockId.SewingMachine,
                (ushort)Items.FurnaceElectric => (ushort)BlockId.FurnaceElectric,
                (ushort)Items.Macerator => (ushort)BlockId.Macerator,
                (ushort)Items.WaterMill => (ushort)BlockId.Watermill,
                (ushort)Items.SolarPanel => (ushort)BlockId.SolarPanel,
                (ushort)Items.Miner => (ushort)BlockId.Miner,
                (ushort)Items.Charger => (ushort)BlockId.Charger,
                (ushort)Items.FurnaceStone => (ushort)BlockId.FurnaceStone,
                (ushort)Items.Composter => (ushort)BlockId.Composter,
                _ => (ushort)BlockId.None,
            };
        
        public static ushort PlantFromItem(ushort item) 
            => item switch {
                (ushort)Items.Strawberry => (ushort)BlockId.Strawberry,
                (ushort)Items.PlantBlueberry => (ushort)BlockId.Blueberry,
                (ushort)Items.PlantRashberry => (ushort)BlockId.Rashberry,
                (ushort)Items.PlantOnion => (ushort)BlockId.Onion,
                (ushort)Items.PlantPeas => (ushort)BlockId.Peas,
                (ushort)Items.PlantCarrot => (ushort)BlockId.Carrot,
                (ushort)Items.Peas => (ushort)BlockId.Peas,
                (ushort)Items.Carrot => (ushort)BlockId.Carrot,
                (ushort)Items.Onion => (ushort)BlockId.Onion,
                _ => (ushort)BlockId.None,
            };
        
        public static ushort MobFromItem(ushort item) 
            => item switch {
                (ushort)Items.AnimalRabbit => (ushort)BlockId.Rabbit,
                (ushort)Items.AnimalChicken => (ushort)BlockId.Chicken,
                (ushort)Items.AnimalFish => (ushort)BlockId.Fish,
                (ushort)Items.AnimalParrot => (ushort)BlockId.MobParrot,
                _ => (ushort)BlockId.None,
            };
        
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

        public static bool IsBlockOnGrowing(ushort id) 
            => id switch {
                (ushort)BlockId.Dirt => true,
                (ushort)BlockId.Compost => true,
                (ushort)BlockId.Clay => true,
                (ushort)BlockId.GrassBlockPlains => true,
                (ushort)BlockId.GrassBlockHills => true,
                (ushort)BlockId.GrassBlockJungle => true,
                (ushort)BlockId.GrassBlockDesert => true,
                (ushort)BlockId.GrassBlockForest => true,
                (ushort)BlockId.GrassBlockClay => true,
                (ushort)BlockId.GrassBlockCompost => true,
                (ushort)BlockId.GrassBlockSnowPlains => true,
                (ushort)BlockId.GrassBlockSnowHills => true,
                (ushort)BlockId.GrassBlockSnowJungle => true,
                (ushort)BlockId.GrassBlockSnowDesert => true,
                (ushort)BlockId.GrassBlockSnowForest => true,
                (ushort)BlockId.GrassBlockSnowClay => true,
                (ushort)BlockId.GrassBlockSnowCompost => true,
                _ => false,
            };
        
        public static bool IsDirtPlaceable(ushort id) 
            => id switch {
                (ushort)BlockId.OakSapling => true,
                (ushort)BlockId.OrangeSapling => true,
                (ushort)BlockId.PineSapling => true,
                (ushort)BlockId.PlumSapling => true,
                (ushort)BlockId.SpruceSapling => true,
                (ushort)BlockId.AppleSapling => true,
                (ushort)BlockId.CherrySapling => true,
                (ushort)BlockId.LemonSapling => true,
                (ushort)BlockId.LindenSapling => true,
                (ushort)BlockId.AcaciaSapling => true,
                (ushort)BlockId.EucalyptusSapling => true,
                (ushort)BlockId.KapokSapling => true,
                (ushort)BlockId.MangroveSapling => true,
                (ushort)BlockId.OliveSapling => true,
                (ushort)BlockId.RubberTreeSapling => true,
                (ushort)BlockId.WillowSapling => true,
                (ushort)BlockId.Rose => true,
                (ushort)BlockId.Dandelion => true,
                (ushort)BlockId.Heather => true,
                (ushort)BlockId.Orchid => true,
                (ushort)BlockId.Violet => true,
                (ushort)BlockId.Alore => true,
                (ushort)BlockId.Boletus => true,
                (ushort)BlockId.BranchFull => true,
                (ushort)BlockId.Champignon => true,
                (ushort)BlockId.GrassDesert => true,
                (ushort)BlockId.GrassForest => true,
                (ushort)BlockId.GrassHills => true,
                (ushort)BlockId.GrassJungle => true,
                (ushort)BlockId.GrassPlains => true,
                (ushort)BlockId.Toadstool => true,
                (ushort)BlockId.EggDrop => true,
                (ushort)BlockId.Rocks => true,
                _ => false,
            };
        
        public static CraftingRecipe[] Craft(ushort id) {
            return id switch {
                (ushort)Items.AngelHair => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateGold, 1)),
                                CraftingRecipe.AnyShears(),
                            },
                            new ItemNonInvBasic((ushort)Items.AngelHair,2)
                        ),
                    },
                (ushort)Items.MediumStone => new CraftingRecipe[] {
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
                    },
                (ushort)Items.SmallStone => new CraftingRecipe[] {
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
                    },
                (ushort)Items.HammerCopper => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CopperIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HammerCopper)
                        )
                    },
                (ushort)Items.HammerAluminium => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HammerAluminium)
                        )
                    },
                (ushort)Items.HammerSteel => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.SteelIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HammerSteel)
                        )
                    },
                (ushort)Items.ShearsSteel => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsHeadSteel,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,2)),
                            },
                            new ItemNonInvTool((ushort)Items.ShearsSteel)
                        )
                    },
                (ushort)Items.ShovelBronze => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadBronze,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.ShovelBronze)
                        )
                    },
                (ushort)Items.DyeBrown => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlack)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeOrange)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeBrown)
                        )
                    },
                (ushort)Items.DyeMagenta => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlue)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeRed)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeMagenta)
                        )
                    },
                (ushort)Items.DyeOrange => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeYellow)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeRed)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeOrange)
                        )
                    },
                (ushort)Items.DyeTeal => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlue)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeGreen)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeTeal)
                        )
                    },
                (ushort)Items.DyeArmy => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBrown)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeGreen)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeOlive)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeArmy)
                        )
                    },
                (ushort)Items.DyeRoseQuartz => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeWhite)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeDarkRed)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeRoseQuartz)
                        )
                    },
                (ushort)Items.DyePink => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeWhite)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeRed)),
                            },
                            new ItemNonInvTool((ushort)Items.DyePink)
                        )
                    },
                (ushort)Items.DyeLightBlue => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeWhite)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlue)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeLightBlue)
                        )
                    },
                (ushort)Items.DyeLightGreen => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeWhite)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeGreen)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeLightGreen)
                        )
                    },
                (ushort)Items.DyeDarkGreen => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlack)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeGreen)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeDarkGreen)
                        )
                    },
                (ushort)Items.DyeDarkBlue => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlack)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlue)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeDarkBlue)
                        )
                    },
                (ushort)Items.DyeDarkRed => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeBlack)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.DyeRed)),
                            },
                            new ItemNonInvTool((ushort)Items.DyeDarkRed)
                        )
                    },
                (ushort)Items.OxygenMachine => new CraftingRecipe[] {
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
                    },
                (ushort)Items.AirTank => new CraftingRecipe[] {
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
                    },
                (ushort)Items.AirTank2 => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Gun => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Ammo => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper,2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 2)),
                                CraftingRecipe.AnyHammer(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Gunpowder,3)),
                            },
                            new ItemNonInvBasic((ushort)Items.Ammo,5)
                        )
                    },
                (ushort)Items.Gunpowder => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Saltpeter, 5)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CoalDust, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Saltpeter, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Gunpowder,7)
                        )
                    },
                (ushort)Items.BucketForRubber => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bucket,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.BucketForRubber,1)
                        )
                    },
                (ushort)Items.HoeBronze => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadBronze,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeBronze)
                        )
                    },
                (ushort)Items.HoeCopper => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadCopper, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeCopper)
                        )
                    },
                (ushort)Items.HoeIron => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadIron, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeIron)
                        )
                    },
                (ushort)Items.HoeGold => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadGold, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeGold)
                        )
                    },
                (ushort)Items.HoeAluminium => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadAluminium, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeAluminium)
                        )
                    },
                (ushort)Items.Composter => new CraftingRecipe[] {
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
                    },
                (ushort)Items.BowlEmpty => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks,1)),
                                CraftingRecipe.AnySaw()
                            },
                            new ItemNonInvBasic((ushort)Items.BowlEmpty,1)
                        )
                    },
                (ushort)Items.TorchOFF => new CraftingRecipe[] {
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
                    },
                (ushort)Items.PickaxeIron => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadIron,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeIron)
                        )
                    },
                (ushort)Items.PickaxeCopper => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadCopper,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeCopper)
                        )
                    },
                (ushort)Items.PickaxeGold => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadGold,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeGold)
                        )
                    },
                (ushort)Items.PickaxeSteel => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadSteel,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeSteel)
                        )
                    },
                (ushort)Items.PickaxeAluminium => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadAluminium,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeAluminium)
                        )
                    },
                (ushort)Items.PickaxeBronze => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PickaxeHeadBronze,1)),
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeCopper)
                        )
                    },
                (ushort)Items.KnifeCopper => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadCopper,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeCopper)
                        )
                    },
                (ushort)Items.KnifeBronze => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadBronze,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeBronze)
                        )
                    },
                (ushort)Items.KnifeGold => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadGold,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeGold)
                        )
                    },
                (ushort)Items.KnifeSteel => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadSteel,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeSteel)
                        )
                    },
                (ushort)Items.HoeSteel => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HoeHeadSteel,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeSteel)
                        )
                    },
                (ushort)Items.AxeSteel => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadSteel,1)),
                            },
                            new ItemNonInvTool((ushort)Items.AxeSteel)
                        )
                    },
                (ushort)Items.AxeBronze => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadBronze,1)),
                            },
                            new ItemNonInvTool((ushort)Items.AxeBronze)
                        )
                    },
                (ushort)Items.AxeCopper => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadCopper,1)),
                            },
                            new ItemNonInvTool((ushort)Items.AxeCopper)
                        )
                    },
                (ushort)Items.AxeAluminium => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadAluminium,1)),
                            },
                            new ItemNonInvTool((ushort)Items.AxeAluminium)
                        )
                    },
                (ushort)Items.KnifeIron => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadIron,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeIron)
                        )
                    },
                (ushort)Items.KnifeAluminium => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.KnifeHeadAluminium,1)),
                            },
                            new ItemNonInvTool((ushort)Items.KnifeAluminium)
                        )
                    },
                (ushort)Items.SewingMachine => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Motor,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.SewingMachine, 1)
                        )
                    },
                (ushort)Items.Charger => new CraftingRecipe[] {
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
                  },
                (ushort)Items.HoeStone => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.StoneHead,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.HoeStone)
                        )
                    },
                (ushort)Items.AxeIron => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.AxeIron)
                        )
                    },
                (ushort)Items.TorchElectricON => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bulb,1)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.ItemBattery)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Plastic,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                            },
                            new ItemNonInvTool((ushort)Items.TorchElectricON)
                        )
                    },
                (ushort)Items.ShovelIron => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.ShovelIron)
                        )
                    },
                (ushort)Items.ShovelAluminium => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.ShovelAluminium)
                        )
                    },
                (ushort)Items.ShovelCopper => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadCopper,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                            },
                            new ItemNonInvTool((ushort)Items.ShovelCopper)
                        )
                    },
                (ushort)Items.AxeHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInv[]{new ItemNonInvBasic((ushort)Items.HammerIron, 5) }),
                            },
                            new ItemNonInvBasic((ushort)Items.AxeHeadIron, 4)
                        )
                    },
                (ushort)Items.PickaxeHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 5)),
                            },
                            new ItemNonInvBasic((ushort)Items.PickaxeHeadIron, 4)
                        )
                    },
                (ushort)Items.ShovelHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 5)),
                            },
                            new ItemNonInvBasic((ushort)Items.ShovelHeadIron, 4)
                        )
                    },
                (ushort)Items.BronzeDust => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CopperDust, 3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TinDust,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.CopperDust, 4)
                        )
                    },
                (ushort)Items.WaterMill => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper, 2)),
                                CraftingRecipe.AnyHammer(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Motor,1)),
                                new CraftingIn(new ItemNonInvTool((ushort)Items.ItemBattery,-1)),
                            },
                            new ItemNonInvBasic((ushort)Items.WaterMill,1)
                        )
                    },
                (ushort)Items.Stonerubble => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SmallStone, 4),new ItemNonInvBasic((ushort)Items.Stonerubble, 4))
                    },
                (ushort)Items.Bricks => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.OneBrick, 4)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BucketWater, 25)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Sand,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Dirt,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Bricks,1)
                        )
                    },
                (ushort)Items.Leave => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Ladder => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 10)),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Rope, 4), new ItemNonInvBasic((ushort)Items.Nail, 4) })
                            },
                            new ItemNonInvBasic((ushort)Items.Ladder,1)
                        )
                    },
                (ushort)Items.Flag => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Flag,1)
                        )
                    },
                (ushort)Items.Shelf => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks, 5)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Nail, 5)),
                               CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.Shelf,1)
                        )
                    },
                (ushort)Items.Barrel => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks, 10)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Nail, 5)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 2)),
                               CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.Barrel,1)
                        )
                    },
                (ushort)Items.BoxWooden => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks, 7)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Nail, 5)),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.BoxWooden,1)
                        )
                    },
                (ushort)Items.BoxAdv => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock, 2)),
                                CraftingRecipe.AnyHammer(),
                                CraftingRecipe.AnyShears(),
                            },
                            new ItemNonInvBasic((ushort)Items.Shelf,1)
                        )
                    },
                (ushort)Items.Sticks => new CraftingRecipe[] {
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
                    },
                (ushort)Items.WheatSeeds => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.WheatStraw,1),
                            new CraftingOut[] {
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.Hay, 1)),
                                new CraftingOut(new ItemNonInvBasic((ushort)Items.WheatSeeds, 1))
                            }
                        )
                    },
                (ushort)Items.Seeds => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Desk => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BigStone,1)),
                                CraftingRecipe.AnyWood(1)
                            },
                            new ItemNonInvBasic((ushort)Items.Desk,1)
                        )
                    },
                (ushort)Items.CoalDust => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.ItemCoal,1), new ItemNonInvBasic((ushort)Items.OreCoal,1),new ItemNonInvBasic((ushort)Items.CoalWood,1) }),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.CoalDust,2)
                        )
                    },
                (ushort)Items.Hay => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Gravel => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.BigStone,1) , new ItemNonInvBasic((ushort)Items.MediumStone,2),new ItemNonInvBasic((ushort)Items.SmallStone,4)}),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.Gravel,1)
                        )
                    },
                (ushort)Items.Stick => new CraftingRecipe[] {
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
                    },
                (ushort)Items.StoneHead => new CraftingRecipe[] {
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
                    },
                (ushort)Items.PickaxeStone => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.StoneHead,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.PickaxeStone)
                        )
                    },
                (ushort)Items.AxeStone => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.StoneHead,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.AxeStone)
                        )
                    },
                (ushort)Items.ShovelStone => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.StoneHead,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.ShovelStone)
                        )
                    },
                (ushort)Items.HayBlock => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Hay,4),new ItemNonInvBasic((ushort)Items.HayBlock, 1))
                    },
                (ushort)Items.PlateCopper => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CopperIngot,1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.PlateCopper, 2)
                        )
                    },
                (ushort)Items.plateAluminium => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.plateAluminium, 2)
                        )
                    },
                (ushort)Items.PlateIron => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.PlateIron, 2)
                        )
                    },
                (ushort)Items.PlateBronze => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BronzeIngot, 1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.PlateBronze, 2)
                        )
                    },
                (ushort)Items.PlateGold => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.GoldIngot, 1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.PlateGold, 2)
                        )
                    },
                (ushort)Items.FurnaceElectric => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 4)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel, 6)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.FurnaceElectric,1)
                        )
                    },
                (ushort)Items.Macerator => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Radio => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BigCircuit, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateBronze,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Radio,1)
                        )
                    },
                (ushort)Items.Label => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rubber,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Label,1)
                        )
                    },
                (ushort)Items.BareLabel => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper,1)),
                                CraftingRecipe.AnyShears()
                            },
                            new ItemNonInvBasic((ushort)Items.BareLabel, 4)
                        )
                    },
                (ushort)Items.Sand => new CraftingRecipe[] {
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
                    },
                (ushort)Items.ShearsCopper => new CraftingRecipe[] {
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
                    },
                (ushort)Items.ShearsBronze => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsHeadBronze,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                              //  CraftingRecipe.AnyShears()
                            },
                            new ItemNonInvTool((ushort)Items.ShearsBronze)
                        )
                    },
                (ushort)Items.ShearsIron => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsHeadIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                               // CraftingRecipe.AnyShears()
                            },
                            new ItemNonInvTool((ushort)Items.ShearsIron)
                        )
                    },
                (ushort)Items.AdvancedSpaceBlock => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Plastic, 1)),
                                CraftingRecipe.AnyHammer()
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock, 2)
                        )
                    },
                (ushort)Items.Miner => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Diode => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Silicium,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Diode, 4)
                        )
                    },
                (ushort)Items.HammerBronze => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BronzeIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1))
                            },
                            new ItemNonInvBasic((ushort)Items.HammerBronze,1)
                        )
                    },
                (ushort)Items.HammerIron => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1))
                            },
                            new ItemNonInvBasic((ushort)Items.HammerIron,1)
                        )
                    },
                (ushort)Items.SawCopper => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper,1)),
                                CraftingRecipe.AnyShears(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.SawCopper)
                        )
                    },
                (ushort)Items.SawBronze => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateBronze,1)),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.ShearsBronze, 2),new ItemNonInvBasic((ushort)Items.ShearsIron, 1) }),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.SawBronze)
                        )
                    },
                (ushort)Items.SawIron => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsIron,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1))
                            },
                            new ItemNonInvTool((ushort)Items.SawIron)
                        )
                    },
                (ushort)Items.ElectricDrill => new CraftingRecipe[] {
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
                    },
                (ushort)Items.ElectricSaw => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Rocket => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Door => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Nail, 10)),
                                CraftingRecipe.AnyHammer(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Planks, 3)),
                            },
                            new ItemNonInvBasic((ushort)Items.Door,1)
                        )
                    },
                (ushort)Items.Yarn => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick,1)),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Flax, 1), new ItemNonInvBasic((ushort)Items.KapokFibre, 1) })
                            },
                            new ItemNonInvBasic((ushort)Items.Yarn,1)
                        )
                    },
                (ushort)Items.Rope => new CraftingRecipe[] { new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Yarn, 3), new ItemNonInvBasic((ushort)Items.Rope, 1)) },
                (ushort)Items.Nail => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron, 5))
                            },
                            new ItemNonInvBasic((ushort)Items.Nail, 10)
                        )
                    },
                (ushort)Items.Roof1 => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bricks,1)),
                                CraftingRecipe.AnySaw()
                            },
                            new ItemNonInvBasic((ushort)Items.Roof1, 2)
                        )
                    },
                (ushort)Items.Roof2 => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bricks,1)),
                                CraftingRecipe.AnySaw()
                            },
                            new ItemNonInvBasic((ushort)Items.Roof2, 2)
                        )
                    },
                (ushort)Items.FurnaceStone => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.MediumStone, 6), new ItemNonInvBasic((ushort)Items.BigStone,4), new ItemNonInvBasic((ushort)Items.SmallStone,8)}),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Dirt, 2), new ItemNonInvBasic((ushort)Items.Clay, 2) })
                            },
                            new ItemNonInvBasic((ushort)Items.FurnaceStone,1)
                        )
                    },
                (ushort)Items.MudIngot => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Clay, 1), new ItemNonInvBasic((ushort)Items.MudIngot, 1)),
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Dirt,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Hay,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BucketWater,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.MudIngot,1)
                        )
                    },
                (ushort)Items.ItemBattery => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Lemon,1)),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.PlateCopper, 2), new ItemNonInvBasic((ushort)Items.PlateGold, 2)}),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.PlateIron, 2),new ItemNonInvBasic((ushort)Items.plateAluminium, 2) })
                            },
                            new ItemNonInvTool((ushort)Items.ItemBattery,1)
                        )
                    },
                (ushort)Items.BigCircuit => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Bucket => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Bulb => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                                CraftingRecipe.AnyShears()
                            },
                            new ItemNonInvBasic((ushort)Items.Bulb,1)
                        )
                    },
                (ushort)Items.Circuit => new CraftingRecipe[] {
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
                    },
                (ushort)Items.SolarPanel => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Silicium, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateCopper, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.SolarPanel,1)
                        )
                    },
                (ushort)Items.WindMill => new CraftingRecipe[] {
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
                    },
                (ushort)Items.AdvancedSpaceWindow => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsIron,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpaceWindow,1)
                        )
                    },
                (ushort)Items.AdvancedSpaceFloor => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1))
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpaceFloor,1)
                        )
                    },
                (ushort)Items.AdvancedSpacePart1 => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1))
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpacePart1,1)
                        )
                    },
                (ushort)Items.AdvancedSpacePart2 => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1))
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpacePart2,1)
                        )
                    },
                (ushort)Items.AdvancedSpacePart3 => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1))
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpacePart3,1)
                        )
                    },
                (ushort)Items.AdvancedSpacePart4 => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AdvancedSpaceBlock,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.HammerIron,1))
                            },
                            new ItemNonInvBasic((ushort)Items.AdvancedSpacePart4,1)
                        )
                    },
                (ushort)Items.Lamp => new CraftingRecipe[] {
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
                    },
                (ushort)Items.Cloth => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Yarn, 4))
                            },
                            new ItemNonInvBasic((ushort)Items.Cloth,1)
                        )
                    },
                (ushort)Items.AxeGold => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.AxeHeadGold, 1))
                            },
                            new ItemNonInvTool((ushort)Items.AxeGold)
                        )
                    },
                (ushort)Items.ShovelGold => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadGold, 1))
                            },
                            new ItemNonInvTool((ushort)Items.ShovelGold)
                        )
                    },
                (ushort)Items.ShovelSteel => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadSteel, 1))
                            },
                            new ItemNonInvTool((ushort)Items.ShovelSteel)
                        )
                    },
                (ushort)Items.ShearsAluminium => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShovelHeadAluminium, 1))
                            },
                            new ItemNonInvTool((ushort)Items.ShearsAluminium)
                        )
                    },
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
                (ushort)Items.ShearsGold => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.ShearsHeadGold, 1))
                            },
                            new ItemNonInvTool((ushort)Items.ShearsGold)
                        )
                    },
                (ushort)Items.HammerGold => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.GoldIngot, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope, 1))
                            },
                            new ItemNonInvTool((ushort)Items.HammerGold)
                        )
                    },
                (ushort)Items.Motor => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.IronIngot, 1)),
                                CraftingRecipe.AnyHammer(),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.Motor,1)
                        )
                    },
                (ushort)Items.Rod => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.IronIngot, 1), new ItemNonInvBasic((ushort)Items.BronzeIngot, 1) }),
                                CraftingRecipe.AnyHammer(),
                            },
                            new ItemNonInvBasic((ushort)Items.Rod, 2)
                        )
                    },
                (ushort)Items.Condenser => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.plateAluminium, 1), new ItemNonInvBasic((ushort)Items.PlateCopper, 1) }),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                                CraftingRecipe.AnyShears(),
                            },
                            new ItemNonInvBasic((ushort)Items.Condenser, 5)
                        )
                    },
                (ushort)Items.Rezistance => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CoalWood,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BareLabel,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Rezistance, 5)
                        )
                    },
                (ushort)Items.Tranzistor => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Diode, 2), new ItemNonInvBasic((ushort)Items.Tranzistor, 1))
                    },
                (ushort)Items.Planks => new CraftingRecipe[] {
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
                    },
                _ => null,
            };
        }

        public static CraftingRecipe[] Bake(ushort id) {
            return id switch {
                (ushort)Items.ChristmasBallGray => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.ChristmasBallGray)
                        )
                    },
                (ushort)Items.ChristmasStar => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.GoldDust,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.ChristmasStar)
                        )
                    },
                (ushort)Items.SteelIngot => new CraftingRecipe[] {
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
                    },
                (ushort)Items.DyeBlue => new CraftingRecipe[] {
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
                    },
                (ushort)Items.DyeViolet => new CraftingRecipe[] {
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
                    },
                (ushort)Items.boiledEgg => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Egg, 1), new ItemNonInvFood((ushort)Items.boiledEgg, 1, 0))
                    },
                (ushort)Items.DyeRed => new CraftingRecipe[] {
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
                    },
                (ushort)Items.DyeGreen => new CraftingRecipe[] {
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
                    },
                (ushort)Items.DyeOrange => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvFood((ushort)Items.Carrot, 1, 0.5f)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeOrange, 1)
                        )
                    },
                (ushort)Items.DyeSpringGreen => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvFood((ushort)Items.Peas, 1, 0.5f)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeSpringGreen, 1)
                        )
                    },
                (ushort)Items.DyeYellow => new CraftingRecipe[] {
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
                    },
                (ushort)Items.DyeDarkGreen => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvFood((ushort)Items.Seaweed, 1, 0.5f)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeDarkGreen, 1)
                        )
                    },
                (ushort)Items.DyeBrown => new CraftingRecipe[] {
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
                    },
                (ushort)Items.DyeLightGray => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Ash, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeLightGray, 1)
                        )
                    },
                (ushort)Items.DyeGray => new CraftingRecipe[] {
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
                    },
                (ushort)Items.DyeBlack => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CoalDust, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeBlack, 1)
                        )
                    },
                (ushort)Items.DyeWhite => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Saltpeter, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeWhite, 1)
                        )
                    },
                (ushort)Items.DyeGold => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.GoldDust, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeGold, 1)
                        )
                    },
                (ushort)Items.DyeRoseQuartz => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlantRose, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube, 1))
                            },
                            new ItemNonInvBasic((ushort)Items.DyeRoseQuartz, 1)
                        )
                    },
                (ushort)Items.TestTube => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn(
                                new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.Sand,1),
                                    new ItemNonInvBasic((ushort)Items.RedSand,1)
                                }
                            ),
                            new CraftingOut(new ItemNonInvBasic((ushort)Items.TestTube,1))
                        ),
                    },
                (ushort)Items.TorchON => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.TorchOFF,1),new ItemNonInvTool((ushort)Items.TorchON,1)),
                    },
                (ushort)Items.Bottle => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Plastic,1),new ItemNonInvBasic((ushort)Items.Bottle,1)),
                    },
                (ushort)Items.ShovelHeadSteel => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadSteel,1)),
                    },
                (ushort)Items.AxeHeadGold => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadGold,1)),
                    },
                (ushort)Items.DyeOlive => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Olive,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TestTube,1))
                            },

                            new ItemNonInvBasic((ushort)Items.DyeOlive,1)
                        )
                    },
                (ushort)Items.HoeHeadBronze => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadBronze,1)),
                    },
                (ushort)Items.HoeHeadCopper => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadCopper,1)),
                    },
                (ushort)Items.HoeHeadAluminium => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadAluminium,1)),
                    },
                (ushort)Items.HoeHeadSteel => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadSteel,1)),
                    },
                (ushort)Items.HoeHeadGold => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadGold,1)),
                    },
                (ushort)Items.HoeHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1), new ItemNonInvBasic((ushort)Items.HoeHeadIron,1)),
                    },
                (ushort)Items.RabbitMeatCooked => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.RabbitMeat,1), new ItemNonInvBasic((ushort)Items.RabbitMeatCooked,1)),
                    },
                (ushort)Items.RabbitMeatCookedWithSalt => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.RabbitMeat,1), new ItemNonInvBasic((ushort)Items.RabbitMeatCookedWithSalt,1)),
                    },
                (ushort)Items.Plastic => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rubber,1)),
                                CraftingRecipe.AnyOil(25),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Ash,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Plastic,1)
                        ),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Bottle,1), new ItemNonInvBasic((ushort)Items.Plastic,1))
                    },
                (ushort)Items.BowlWithMushrooms => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BowlEmpty,1)),
                                CraftingRecipe.AnyWater(25),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Boletus,1), new ItemNonInvBasic((ushort)Items.Champignon,1) }),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Champignon,1), new ItemNonInvBasic((ushort)Items.Boletus,1) }),

                            },
                            new ItemNonInvBasic((ushort)Items.BowlWithMushrooms,1)
                        )
                    },
                (ushort)Items.BowlWithVegetables => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.BowlEmpty,1)),
                                CraftingRecipe.AnyWater(25),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Carrot,1), new ItemNonInvBasic((ushort)Items.Onion,1),new ItemNonInvBasic((ushort)Items.Peas,1)}),
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.Carrot,1), new ItemNonInvBasic((ushort)Items.Onion,1),new ItemNonInvBasic((ushort)Items.Peas,1)}),

                            },
                            new ItemNonInvBasic((ushort)Items.BowlWithVegetables,1)
                        )
                    },
                (ushort)Items.plateAluminium => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1), new ItemNonInvBasic((ushort)Items.plateAluminium, 2))
                    },
                (ushort)Items.OneBrick => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.MudIngot,1), new ItemNonInvBasic((ushort)Items.OneBrick, 1))
                    },
                (ushort)Items.BareLabel => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.BareLabel, 3))
                    },
                (ushort)Items.PlateBronze => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1), new ItemNonInvBasic((ushort)Items.PlateBronze, 2))
                    },
                (ushort)Items.PlateCopper => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1), new ItemNonInvBasic((ushort)Items.PlateCopper, 2))
                    },
                (ushort)Items.PlateGold => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1),new ItemNonInvBasic((ushort)Items.PlateGold, 2))
                    },
                (ushort)Items.PlateIron => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot, 1), new ItemNonInvBasic((ushort)Items.PlateIron, 2))
                    },
                (ushort)Items.FishMeatCooked => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.FishMeat,1), new ItemNonInvBasic((ushort)Items.FishMeatCooked,1))
                    },
                (ushort)Items.AxeHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadIron,1))
                    },
                (ushort)Items.AxeHeadCopper => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadCopper,1))
                    },
                (ushort)Items.AxeHeadBronze => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadBronze,1))
                    },
                (ushort)Items.AxeHeadAluminium => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadAluminium,1))
                    },
                (ushort)Items.AxeHeadSteel => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadSteel,1))
                    },
                (ushort)Items.PickaxeHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadIron,1))
                    },
                (ushort)Items.PickaxeHeadCopper => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadCopper,1))
                    },
                (ushort)Items.PickaxeHeadBronze => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadBronze,1))
                    },
                (ushort)Items.PickaxeHeadGold => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadGold,1))
                    },
                (ushort)Items.PickaxeHeadAluminium => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadAluminium,1))
                    },
                (ushort)Items.PickaxeHeadSteel => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadSteel,1))
                    },
                (ushort)Items.ShovelHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadIron,1))
                    },
                (ushort)Items.ShovelHeadCopper => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadCopper,1))
                    },
                (ushort)Items.ShovelHeadBronze => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadBronze,1))
                    },
                (ushort)Items.ShovelHeadGold => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadGold,1))
                    },
                (ushort)Items.ShovelHeadAluminium => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1),new ItemNonInvBasic((ushort)Items.ShovelHeadAluminium,1))
                    },
                (ushort)Items.ShearsHeadAluminium => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadAluminium,1))
                    },
                (ushort)Items.ShearsHeadCopper => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadCopper,1))
                    },
                (ushort)Items.ShearsHeadBronze => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadBronze,1))
                    },
                (ushort)Items.ShearsHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadIron,1))
                    },
                (ushort)Items.ShearsHeadGold => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadGold,1))
                    },
                (ushort)Items.ShearsHeadSteel => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1),new ItemNonInvBasic((ushort)Items.ShearsHeadSteel,1))
                    },
                (ushort)Items.KnifeHeadSteel => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SteelIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadSteel,1))
                    },
                (ushort)Items.KnifeHeadCopper => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadCopper,1))
                    },
                (ushort)Items.KnifeHeadBronze => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadBronze,1))
                    },
                (ushort)Items.KnifeHeadGold => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadGold,1))
                    },
                (ushort)Items.KnifeHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadIron,1))
                    },
                (ushort)Items.KnifeHeadAluminium => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot,1),new ItemNonInvBasic((ushort)Items.KnifeHeadAluminium,1))
                    },
                (ushort)Items.Glass => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Sand,1), new ItemNonInvBasic((ushort)Items.Glass,1))
                    },
                (ushort)Items.Rubber => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.Resin, 1),
                                    new ItemNonInvBasic((ushort)Items.Ash, 1)/*,new ItemNonInv((ushort)Items., 1), new ItemNonInv((ushort)Items.OakLeaves, 1)*/ }),
                            },
                            new ItemNonInvBasic((ushort)Items.Rubber,1)
                        )
                        //new CraftingRecipe((ushort)Items.Resin, (ushort)Items.Rubber)
                    },
                (ushort)Items.Ash => new CraftingRecipe[] {
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
                    },
                (ushort)Items.CoalWood => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Planks, 2), new ItemNonInvBasic((ushort)Items.CoalWood, 1))
                    },
                (ushort)Items.Silicium => new CraftingRecipe[] {
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
                    },
                (ushort)Items.AluminiumIngot => new CraftingRecipe[] {
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
                    },
                (ushort)Items.IronIngot => new CraftingRecipe[] {
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
                            new ItemNonInvBasic((ushort)Items.IronIngot,1)
                        )
                    },
                (ushort)Items.SilverIngot => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn( new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.ItemSilver, 1),
                                    new ItemNonInvBasic((ushort)Items.SilverDust, 2),
                                    new ItemNonInvBasic((ushort)Items.OreSilver, 1)})
                            },
                            new ItemNonInvBasic((ushort)Items.SilverIngot,1)
                        )
                    },
                (ushort)Items.CopperIngot => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.ItemCopper, 1),
                                new ItemNonInvBasic((ushort)Items.CopperDust, 2),
                                new ItemNonInvBasic((ushort)Items.PlateCopper, 2),
                                new ItemNonInvBasic((ushort)Items.BareLabel, 2),
                                new ItemNonInvBasic((ushort)Items.OreCopper, 1)})
                            },
                            new ItemNonInvBasic((ushort)Items.CopperIngot,1)
                        )
                    },
                (ushort)Items.GoldIngot => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{new CraftingIn(
                                new ItemNonInv[]{
                                    new ItemNonInvBasic((ushort)Items.ItemGold, 1),
                                    new ItemNonInvBasic((ushort)Items.GoldDust, 2),
                                    new ItemNonInvBasic((ushort)Items.PlateGold, 2),
                                    new ItemNonInvBasic((ushort)Items.OreGold, 1)})
                            },
                            new ItemNonInvBasic((ushort)Items.GoldIngot,1)
                        )
                    },
                (ushort)Items.BronzeIngot => new CraftingRecipe[] {
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
                    },
                (ushort)Items.TinIngot => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInv[]{ new ItemNonInvBasic((ushort)Items.ItemTin, 1), new ItemNonInvBasic((ushort)Items.TinDust, 2), new ItemNonInvBasic((ushort)Items.OreTin, 1)})
                            },
                            new ItemNonInvBasic((ushort)Items.TinIngot,1)
                        )
                    },
                _ => null,
            };
        }

        public static CraftingRecipe[] Clothes(ushort id) {
            return id switch {
                (ushort)Items.boiledEgg => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Egg,1), new ItemNonInvBasic((ushort)Items.boiledEgg,1))
                    },
                (ushort)Items.BucketForRubber => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Bucket, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Stick, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.BucketForRubber, 1)
                         )
                    },
                (ushort)Items.Hat => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Hat, 1)
                         )
                    },
                (ushort)Items.Crown => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlateGold, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Ruby, 2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Smaragd, 1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Saphirite, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Crown, 1)
                        )
                    },
                (ushort)Items.Cap => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlantViolet, 2)),
                            },
                        new ItemNonInvBasic((ushort)Items.Cap, 1)
                         )
                    },
                (ushort)Items.SpaceHelmet => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Circuit,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Glass,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.SpaceHelmet, 1)
                        )
                    },
                (ushort)Items.FormalShoes => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Cloth,1), new ItemNonInvBasic((ushort)Items.FormalShoes,1))
                    },
                (ushort)Items.Pumps => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.PlantRose,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Pumps, 1)
                         )
                    },
                (ushort)Items.Sneakers => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Cloth,1),new ItemNonInvBasic((ushort)Items.Sneakers,1))
                    },
                (ushort)Items.SpaceBoots => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.SpaceBoots, 1)
                        )
                    },
                (ushort)Items.BikiniDown => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1))
                            },
                            new ItemNonInvBasic((ushort)Items.BikiniDown,1)
                        )
                    },
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
                (ushort)Items.Underpants => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Underpants, 1)
                        )
                    },
                (ushort)Items.BoxerShorts => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new ItemNonInvBasic((ushort)Items.Cloth,1),
                            new ItemNonInvBasic((ushort)Items.BoxerShorts,1)
                        )
                    },
                //case (ushort)Items.GrayUnderpants:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe((ushort)Items.Cloth, (ushort)Items.GrayUnderpants)
                //    };
                (ushort)Items.Panties => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                               new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Panties, 1)
                        )
                    },
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
                (ushort)Items.Swimsuit => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Swimsuit, 1)
                        )
                    },
                (ushort)Items.Dress => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,3))
                            },
                            new ItemNonInvBasic((ushort)Items.Dress, 1)
                        )
                    },
                (ushort)Items.TShirt => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                           new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,2))
                        },
                        new ItemNonInvBasic((ushort)Items.TShirt, 1)
                         )
                    },
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
                (ushort)Items.Shirt => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Cloth,2), new ItemNonInvBasic((ushort)Items.Shirt, 1))
                    },
                //case (ushort)Items.Dress:
                //    return new CraftingRecipe[] {
                //        new CraftingRecipe(new ItemNonInv((ushort)Items.Cloth,3), new ItemNonInv((ushort)Items.WhiteDress, 1))
                //    };
                (ushort)Items.CoatArmy => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Leave,2)),
                            },
                            new ItemNonInvBasic((ushort)Items.CoatArmy, 1)
                        )
                    },
                (ushort)Items.Coat => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Cloth,3), new ItemNonInvBasic((ushort)Items.Coat, 1))
                    },
                (ushort)Items.JacketDenim => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries,2)),
                            },
                            new ItemNonInvBasic((ushort)Items.JacketDenim,1)
                        )
                    },
                (ushort)Items.JacketFormal => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,2)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CoalDust,2)),
                            },
                            new ItemNonInvBasic((ushort)Items.JacketFormal,1)
                        )
                    },
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
                (ushort)Items.JacketShort => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.JacketShort,1)
                        )
                    },
                (ushort)Items.SpaceSuit => new CraftingRecipe[] {
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
                    },
                (ushort)Items.ArmyTrousers => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Leave,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.ArmyTrousers,1)
                        )
                    },
                (ushort)Items.Skirt => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1))
                            },
                            new ItemNonInvBasic((ushort)Items.Skirt,1)
                        )
                    },
                (ushort)Items.Jeans => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Jeans,1)
                        )
                    },
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
                (ushort)Items.Shorts => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Blueberries,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Shorts, 1)
                        )
                    },
                (ushort)Items.SpaceTrousers => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.plateAluminium,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Label,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.SpaceTrousers,1)
                        )
                    },
                (ushort)Items.Bra => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Bra,1)
                        )
                    },
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
                (ushort)Items.BikiniTop => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CoalDust,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.BikiniTop,1)
                        )
                    },
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
                (ushort)Items.Backpack => new CraftingRecipe[] {
                        new CraftingRecipe(
                            new CraftingIn[]{
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Cloth,1)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.Rope,1)),
                            },
                            new ItemNonInvBasic((ushort)Items.Backpack,1)
                        )
                    },
                _ => null,
            };
        }

        public static CraftingRecipe[] ToDust(ushort id) {
            return id switch {
                (ushort)Items.StoneHead => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BigStone,1), new ItemNonInvBasic((ushort)Items.StoneHead, 1)),
                    },
                (ushort)Items.IronDust => new CraftingRecipe[] {
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
                    },
                (ushort)Items.CopperDust => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CopperIngot,1), new ItemNonInvBasic((ushort)Items.CopperDust,2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.ItemCopper,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.CopperDust,3),0.75f))
                    },
                (ushort)Items.BareLabel => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BareLabel,1), new ItemNonInvBasic((ushort)Items.CopperDust,1)),
                    },
                (ushort)Items.TinDust => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.TinIngot,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.TinDust,2),0.75f)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.ItemTin,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.TinDust,1),0.75f))
                    },
                (ushort)Items.BronzeDust => new CraftingRecipe[] {
                        new CraftingRecipe (
                            new CraftingIn[] {
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.CopperIngot, 3)),
                                new CraftingIn(new ItemNonInvBasic((ushort)Items.TinIngot, 1)),
                            },
                            new ItemNonInvBasic((ushort)Items.BronzeDust, 8)
                        ),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BronzeIngot,1), new ItemNonInvBasic((ushort)Items.BronzeDust,2))
                    },
                (ushort)Items.AluminiumDust => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.AluminiumIngot, 1), new ItemNonInvBasic((ushort)Items.AluminiumDust, 2))
                    },
                (ushort)Items.WoodDust => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Stick,1), new ItemNonInvBasic((ushort)Items.WoodDust, 4))
                    },
                (ushort)Items.GoldDust => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.GoldIngot,1), new ItemNonInvBasic((ushort)Items.GoldDust, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.ItemGold,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.GoldDust,3), 0.75f))
                    },
                (ushort)Items.CoalDust => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.OreCoal,1), new ItemNonInvBasic((ushort)Items.CoalDust, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CoalWood,1), new ItemNonInvBasic((ushort)Items.CoalDust, 2))
                    },
                (ushort)Items.SilverDust => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SilverIngot,1), new ItemNonInvBasic((ushort)Items.SilverDust, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.ItemSilver,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.SilverDust,3), 0.75f))
                    },
                (ushort)Items.CopperIngot => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Label,1), new ItemNonInvBasic((ushort)Items.BareLabel,1)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.CoalWood,1), new ItemNonInvBasic((ushort)Items.BareLabel, 2))
                    },
                (ushort)Items.Gravel => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BigStone,1),new ItemNonInvBasic((ushort)Items.Gravel,1)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.MediumStone, 2), new ItemNonInvBasic((ushort)Items.Gravel,1)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SmallStone, 4), new ItemNonInvBasic((ushort)Items.Gravel,1)),
                    },
                (ushort)Items.Sand => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Gravel,1), new ItemNonInvBasic((ushort)Items.Sand, 1)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Bricks,1), new ItemNonInvBasic((ushort)Items.Sand, 1))
                    },
                (ushort)Items.WheatSeeds => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.WheatStraw,1), new ItemNonInvBasic((ushort)Items.WheatSeeds,1))
                    },
                (ushort)Items.AxeHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1),new ItemNonInvBasic((ushort)Items.AxeHeadIron,1))
                    },
                (ushort)Items.PickaxeHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1), new ItemNonInvBasic((ushort)Items.PickaxeHeadIron,1))
                    },
                (ushort)Items.ShovelHeadIron => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.IronIngot,1), new ItemNonInvBasic((ushort)Items.ShovelHeadIron,1))
                    },
                (ushort)Items.Seeds => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Hay,1), new ItemNonInvBasic((ushort)Items.Seeds,1))
                    },
                (ushort)Items.Leave => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.OakLeaves,1), new ItemNonInvBasic((ushort)Items.Seeds, 4))
                    },
                (ushort)Items.Yarn => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Cloth,1), new ItemNonInvBasic((ushort)Items.Yarn, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Rope,1), new ItemNonInvBasic((ushort)Items.Yarn, 1)),
                    },
                (ushort)Items.Cloth => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Flag,1), new ItemNonInvBasic((ushort)Items.Cloth, 2))
                    },
                (ushort)Items.Hay => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.HayBlock,1), new ItemNonInvBasic((ushort)Items.Hay, 2))
                    },
                (ushort)Items.BucketWater => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Bucket,1), new ItemNonInvBasic((ushort)Items.Lemon, 4)),
                    },
                (ushort)Items.FlaxSeeds => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Flax,1), new CraftingOut(new ItemNonInvBasic((ushort)Items.FlaxSeeds,2),0.75f))
                    },
                (ushort)Items.Label => new CraftingRecipe[] {
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
                    },
                (ushort)Items.SmallStone => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.MediumStone,1), new ItemNonInvBasic((ushort)Items.SmallStone, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BigStone,1), new ItemNonInvBasic((ushort)Items.SmallStone, 4)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Stonerubble,1), new ItemNonInvBasic((ushort)Items.SmallStone, 4)),
                    },
                (ushort)Items.MediumStone => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.BigStone,1), new ItemNonInvBasic((ushort)Items.MediumStone, 2)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.Stonerubble,1), new ItemNonInvBasic((ushort)Items.MediumStone, 2)),
                    },
                (ushort)Items.Stonerubble => new CraftingRecipe[] {
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.SmallStone, 4), new ItemNonInvBasic((ushort)Items.Stonerubble, 1)),
                        new CraftingRecipe(new ItemNonInvBasic((ushort)Items.MediumStone, 2), new ItemNonInvBasic((ushort)Items.Stonerubble, 1))
                    },
                (ushort)Items.Stick => new CraftingRecipe[] {
                        new CraftingRecipe(new CraftingIn[]{ CraftingRecipe.AnyWood(1) }, new ItemNonInvBasic((ushort)Items.Stick, 4))
                    },
                _ => null,
            };
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
              default: return -1;
                    //break; 
                    }
           
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
                default:  return false;
                    //break;
            }
          
        }

        public static bool IsItemInvBasic32(ushort id) 
            => id switch {
                (ushort)Items.AngelHair => true,
                (ushort)Items.ChristmasBallGray => true,
                (ushort)Items.ChristmasBallBlue => true,
                (ushort)Items.ChristmasBallLightGreen => true,
                (ushort)Items.ChristmasBallOrange => true,
                (ushort)Items.ChristmasBallPink => true,
                (ushort)Items.ChristmasBallPurple => true,
                (ushort)Items.ChristmasBallRed => true,
                (ushort)Items.ChristmasBallYellow => true,
                (ushort)Items.ChristmasBallTeal => true,
                (ushort)Items.Rope => true,
                (ushort)Items.Nail => true,
                (ushort)Items.Bottle => true,
                (ushort)Items.Flag => true,
                (ushort)Items.Diode => true,
                (ushort)Items.Tranzistor => true,
                (ushort)Items.Rezistance => true,
                (ushort)Items.Motor => true,
                (ushort)Items.ElectricDrillOff => true,
                (ushort)Items.ElectricSawOff => true,
                (ushort)Items.LighterOFF => true,
                (ushort)Items.TorchElectricOFF => true,
                (ushort)Items.Condenser => true,
                (ushort)Items.Rod => true,
                (ushort)Items.Ammo => true,
                //case (ushort)Items.ItemBattery: return true;
                (ushort)Items.Label => true,
                (ushort)Items.BareLabel => true,
                (ushort)Items.Bricks => true,
                (ushort)Items.plateAluminium => true,
                (ushort)Items.PlateBronze => true,
                (ushort)Items.PlateIron => true,
                (ushort)Items.PlateGold => true,
                (ushort)Items.PlateCopper => true,
                (ushort)Items.MudIngot => true,
                (ushort)Items.Bulb => true,
                (ushort)Items.CopperIngot => true,
                (ushort)Items.TinIngot => true,
                (ushort)Items.BronzeIngot => true,
                (ushort)Items.GoldIngot => true,
                (ushort)Items.SilverIngot => true,
                (ushort)Items.IronIngot => true,
                (ushort)Items.SteelIngot => true,
                (ushort)Items.AluminiumIngot => true,
                (ushort)Items.Egg => true,
                (ushort)Items.TinEmpty => true,
                (ushort)Items.Circuit => true,
                (ushort)Items.BigCircuit => true,
                (ushort)Items.WindMill => true,
                (ushort)Items.OneBrick => true,
                (ushort)Items.TestTube => true,
                (ushort)Items.AxeHeadCopper => true,
                (ushort)Items.AxeHeadBronze => true,
                (ushort)Items.AxeHeadGold => true,
                (ushort)Items.AxeHeadIron => true,
                (ushort)Items.AxeHeadSteel => true,
                (ushort)Items.AxeHeadAluminium => true,
                (ushort)Items.ShovelHeadCopper => true,
                (ushort)Items.ShovelHeadBronze => true,
                (ushort)Items.ShovelHeadGold => true,
                (ushort)Items.ShovelHeadIron => true,
                (ushort)Items.ShovelHeadSteel => true,
                (ushort)Items.ShovelHeadAluminium => true,
                (ushort)Items.PickaxeHeadCopper => true,
                (ushort)Items.PickaxeHeadBronze => true,
                (ushort)Items.PickaxeHeadGold => true,
                (ushort)Items.PickaxeHeadIron => true,
                (ushort)Items.PickaxeHeadSteel => true,
                (ushort)Items.PickaxeHeadAluminium => true,
                (ushort)Items.ShearsHeadCopper => true,
                (ushort)Items.ShearsHeadBronze => true,
                (ushort)Items.ShearsHeadGold => true,
                (ushort)Items.ShearsHeadIron => true,
                (ushort)Items.ShearsHeadSteel => true,
                (ushort)Items.ShearsHeadAluminium => true,
                (ushort)Items.KnifeHeadCopper => true,
                (ushort)Items.KnifeHeadBronze => true,
                (ushort)Items.KnifeHeadGold => true,
                (ushort)Items.KnifeHeadIron => true,
                (ushort)Items.KnifeHeadSteel => true,
                (ushort)Items.KnifeHeadAluminium => true,
                _ => false,
            };
        

        public static bool IsItemInvTool32(ushort id) 
            => id switch {
                // Hoe
                (ushort)Items.HoeStone => true,
                (ushort)Items.HoeCopper => true,
                (ushort)Items.HoeBronze => true,
                (ushort)Items.HoeIron => true,
                (ushort)Items.HoeGold => true,
                (ushort)Items.HoeAluminium => true,
                (ushort)Items.HoeSteel => true,
                // Knife
                (ushort)Items.KnifeCopper => true,
                (ushort)Items.KnifeBronze => true,
                (ushort)Items.KnifeIron => true,
                (ushort)Items.KnifeSteel => true,
                (ushort)Items.KnifeAluminium => true,
                (ushort)Items.KnifeGold => true,
                // Pickaxe
                (ushort)Items.PickaxeStone => true,
                (ushort)Items.PickaxeIron => true,
                (ushort)Items.PickaxeCopper => true,
                (ushort)Items.PickaxeBronze => true,
                (ushort)Items.PickaxeSteel => true,
                (ushort)Items.PickaxeGold => true,
                (ushort)Items.PickaxeAluminium => true,
                // Axe
                (ushort)Items.AxeStone => true,
                (ushort)Items.AxeIron => true,
                (ushort)Items.AxeSteel => true,
                (ushort)Items.AxeAluminium => true,
                (ushort)Items.AxeCopper => true,
                (ushort)Items.AxeBronze => true,
                (ushort)Items.AxeGold => true,
                // Shovel
                (ushort)Items.ShovelStone => true,
                (ushort)Items.ShovelIron => true,
                (ushort)Items.ShovelSteel => true,
                (ushort)Items.ShovelAluminium => true,
                (ushort)Items.ShovelGold => true,
                (ushort)Items.ShovelCopper => true,
                (ushort)Items.ShovelBronze => true,
                // Saw
                (ushort)Items.SawCopper => true,
                (ushort)Items.SawBronze => true,
                (ushort)Items.SawIron => true,
                (ushort)Items.SawGold => true,
                (ushort)Items.SawSteel => true,
                (ushort)Items.SawAluminium => true,
                // Hammer
                (ushort)Items.HammerBronze => true,
                (ushort)Items.HammerIron => true,
                (ushort)Items.HammerCopper => true,
                (ushort)Items.HammerAluminium => true,
                (ushort)Items.HammerGold => true,
                (ushort)Items.HammerSteel => true,
                // Shears
                (ushort)Items.ShearsCopper => true,
                (ushort)Items.ShearsBronze => true,
                (ushort)Items.ShearsIron => true,
                (ushort)Items.ShearsAluminium => true,
                (ushort)Items.ShearsGold => true,
                (ushort)Items.ShearsSteel => true,
                // Electric
                (ushort)Items.ElectricDrill => true,
                (ushort)Items.ElectricSaw => true,
                (ushort)Items.TorchElectricON => true,
                (ushort)Items.BottleOil => true,
                (ushort)Items.BottleSaltWater => true,
                (ushort)Items.BottleWater => true,
                (ushort)Items.Gun => true,
                (ushort)Items.LighterON => true,
                (ushort)Items.AirTank2 => true,
                (ushort)Items.AirTank => true,
                (ushort)Items.DyeArmy => true,
                (ushort)Items.DyeBlack => true,
                (ushort)Items.DyeBlue => true,
                (ushort)Items.DyeBrown => true,
                (ushort)Items.DyeDarkBlue => true,
                (ushort)Items.DyeDarkGray => true,
                (ushort)Items.DyeDarkGreen => true,
                (ushort)Items.DyeDarkRed => true,
                (ushort)Items.DyeGold => true,
                (ushort)Items.DyeGray => true,
                (ushort)Items.DyeGreen => true,
                (ushort)Items.DyeLightBlue => true,
                (ushort)Items.DyeLightGray => true,
                (ushort)Items.DyeLightGreen => true,
                (ushort)Items.DyeMagenta => true,
                (ushort)Items.DyeOlive => true,
                (ushort)Items.DyeOrange => true,
                (ushort)Items.DyePink => true,
                (ushort)Items.DyePurple => true,
                (ushort)Items.DyeRed => true,
                (ushort)Items.DyeRoseQuartz => true,
                (ushort)Items.DyeSpringGreen => true,
                (ushort)Items.DyeTeal => true,
                (ushort)Items.DyeViolet => true,
                (ushort)Items.DyeWhite => true,
                (ushort)Items.DyeYellow => true,
                _ => false,
            };
        
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
             default:return false;
              //      break; 
                    
                    }
            
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
                    default:  return false;
                    //break;
            }
          
        }

        public static bool IsItemInvNonStackable32(ushort id) 
            => id switch {
                (ushort)Items.Crown => true,
                (ushort)Items.Hat => true,
                (ushort)Items.SpaceBoots => true,
                (ushort)Items.Mobile => true,
                (ushort)Items.SpaceHelmet => true,
                (ushort)Items.SpaceSuit => true,
                (ushort)Items.SpaceTrousers => true,
                _ => false,
            };

        public static bool IsItemInvBasicColoritzed32NonStackable(ushort id) 
            => id switch {
                // Head
                (ushort)Items.Cap => true,
                (ushort)Items.SpaceHelmet => true,
                // Chest
                (ushort)Items.Dress => true,
                (ushort)Items.TShirt => true,
                (ushort)Items.Shirt => true,
                // ChestTop
                (ushort)Items.Coat => true,
                (ushort)Items.CoatArmy => true,
                (ushort)Items.JacketFormal => true,
                (ushort)Items.JacketShort => true,
                (ushort)Items.JacketDenim => true,
                (ushort)Items.SpaceSuit => true,
                // Legs
                (ushort)Items.Skirt => true,
                (ushort)Items.Jeans => true,
                (ushort)Items.Shorts => true,
                (ushort)Items.SpaceTrousers => true,
                (ushort)Items.ArmyTrousers => true,
                // Feet
                (ushort)Items.Pumps => true,
                (ushort)Items.SpaceBoots => true,
                (ushort)Items.Sneakers => true,
                (ushort)Items.FormalShoes => true,
                // UpUnderwear
                (ushort)Items.Bra => true,
                (ushort)Items.BikiniTop => true,
                // DownUnderwear
                (ushort)Items.BikiniDown => true,
                (ushort)Items.Underpants => true,
                (ushort)Items.BoxerShorts => true,
                (ushort)Items.Panties => true,
                (ushort)Items.Swimsuit => true,
                (ushort)Items.Backpack => true,
                _ => false,
            };
        
        public static bool IsItemInvTool16(ushort id) 
            => id switch {
                (ushort)Items.TorchON => true,
                (ushort)Items.BucketOil => true,
                (ushort)Items.BucketWater => true,
                (ushort)Items.ItemBattery => true,
                _ => false,
            };

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
                default:
                   return -1;
            }
          //  return -1;
        }

        public static Color DyeToColor(byte liquid)
            => liquid switch {
                (byte)LiquidId.DyeArmy => new Color(34, 48, 17),
                (byte)LiquidId.DyeBlack => Color.Black,
                (byte)LiquidId.DyeBlue => Color.Blue,
                (byte)LiquidId.DyeBrown => Color.Brown,
                (byte)LiquidId.DyeGray => Color.Gray,
                (byte)LiquidId.DyeWhite => Color.White,
                (byte)LiquidId.DyeYellow => Color.Yellow,
                (byte)LiquidId.DyeViolet => Color.Violet,
                (byte)LiquidId.DyeTeal => Color.Teal,
                (byte)LiquidId.DyeSpringGreen => new Color(143, 225, 44),
                (byte)LiquidId.DyeRoseQuartz => new Color(170, 152, 169),
                (byte)LiquidId.DyeRed => Color.Red,
                (byte)LiquidId.DyeDarkRed => Color.DarkRed,
                (byte)LiquidId.DyePurple => Color.Purple,
                (byte)LiquidId.DyePink => Color.Pink,
                (byte)LiquidId.DyeOrange => Color.Orange,
                (byte)LiquidId.DyeOlive => Color.Olive,
                (byte)LiquidId.DyeMagenta => Color.Magenta,
                (byte)LiquidId.DyeLightGreen => Color.LightGreen,
                (byte)LiquidId.DyeLightGray => Color.LightGray,
                (byte)LiquidId.DyeLightBlue => Color.LightBlue,
                (byte)LiquidId.DyeGreen => Color.Green,
                (byte)LiquidId.DyeDarkGreen => Color.DarkGreen,
                (byte)LiquidId.DyeGold => Color.Gold,
                (byte)LiquidId.DyeDarkBlue => Color.DarkBlue,
                _ => Color.Transparent,
            };
        
        public static bool HasLiquid(ushort id)
            => id switch {
                //Bottle
                (ushort)Items.BottleSaltWater => true,
                (ushort)Items.BottleWater => true,
                (ushort)Items.BottleOil => true,
                // Bucket
                (ushort)Items.BucketWater => true,
                (ushort)Items.BucketOil => true,
                // Blocks
                (ushort)Items.Lava => true,
                (ushort)Items.Oil => true,
                (ushort)Items.DyeGold => true,
                (ushort)Items.DyeWhite => true,
                (ushort)Items.DyeYellow => true,
                (ushort)Items.DyeOrange => true,
                (ushort)Items.DyeRed => true,
                (ushort)Items.DyeDarkRed => true,
                (ushort)Items.DyeOlive => true,
                (ushort)Items.DyePurple => true,
                (ushort)Items.DyePink => true,
                (ushort)Items.DyeTeal => true,
                (ushort)Items.DyeLightBlue => true,
                (ushort)Items.DyeBlue => true,
                (ushort)Items.DyeMagenta => true,
                (ushort)Items.DyeDarkBlue => true,
                (ushort)Items.DyeBlack => true,
                (ushort)Items.DyeBrown => true,
                (ushort)Items.DyeLightGray => true,
                (ushort)Items.DyeGray => true,
                (ushort)Items.DyeDarkGray => true,
                (ushort)Items.DyeViolet => true,
                (ushort)Items.DyeSpringGreen => true,
                (ushort)Items.DyeRoseQuartz => true,
                (ushort)Items.DyeLightGreen => true,
                (ushort)Items.DyeGreen => true,
                (ushort)Items.DyeArmy => true,
                (ushort)Items.DyeDarkGreen => true,
                _ => false,
            };
        
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

        public static (byte, int, ushort) ItemsIdToLiquid(ushort itemId) 
            => itemId switch {
                //Bottle
                (ushort)Items.BottleSaltWater => ((byte)LiquidId.WaterSalt, 100, (ushort)Items.Bottle),
                (ushort)Items.BottleWater => ((byte)LiquidId.Water, 100, (ushort)Items.Bottle),
                (ushort)Items.BottleOil => ((byte)LiquidId.Oil, 100, (ushort)Items.Bottle),
                // Bucket
                (ushort)Items.BucketWater => ((byte)LiquidId.Water, 255, (ushort)Items.Bucket),
                (ushort)Items.BucketOil => ((byte)LiquidId.Oil, 255, (ushort)Items.Bucket),
                // Blocks
                (ushort)Items.Lava => ((byte)LiquidId.Lava, 255, (ushort)Items.None),
                (ushort)Items.Oil => ((byte)LiquidId.Oil, 255, (ushort)Items.None),
                (ushort)Items.DyeArmy => ((byte)LiquidId.DyeArmy, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeBlack => ((byte)LiquidId.DyeBlack, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeBlue => ((byte)LiquidId.DyeBlue, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeBrown => ((byte)LiquidId.DyeBrown, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeDarkBlue => ((byte)LiquidId.DyeDarkBlue, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeDarkGray => ((byte)LiquidId.DyeDarkGray, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeDarkGreen => ((byte)LiquidId.DyeDarkGreen, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeDarkRed => ((byte)LiquidId.DyeDarkRed, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeGold => ((byte)LiquidId.DyeGold, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeGray => ((byte)LiquidId.DyeGray, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeGreen => ((byte)LiquidId.DyeGreen, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeLightBlue => ((byte)LiquidId.DyeLightBlue, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeLightGray => ((byte)LiquidId.DyeLightGray, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeLightGreen => ((byte)LiquidId.DyeLightGreen, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeMagenta => ((byte)LiquidId.DyeMagenta, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeOlive => ((byte)LiquidId.DyeOlive, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeOrange => ((byte)LiquidId.DyeOrange, 50, (ushort)Items.TestTube),
                (ushort)Items.DyePink => ((byte)LiquidId.DyePink, 50, (ushort)Items.TestTube),
                (ushort)Items.DyePurple => ((byte)LiquidId.DyePurple, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeRed => ((byte)LiquidId.DyeRed, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeRoseQuartz => ((byte)LiquidId.DyeRoseQuartz, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeSpringGreen => ((byte)LiquidId.DyeTeal, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeViolet => ((byte)LiquidId.DyeViolet, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeWhite => ((byte)LiquidId.DyeWhite, 50, (ushort)Items.TestTube),
                (ushort)Items.DyeYellow => ((byte)LiquidId.DyeYellow, 50, (ushort)Items.TestTube),
                _ => ((byte)LiquidId.None, 0, (ushort)Items.None),
            };
        
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

        public static float FurnaceStoneBurnWood(ushort id) 
            => id switch {
                (ushort)Items.WoodOak => 0.25f,
                (ushort)Items.WoodPine => 0.25f,
                (ushort)Items.WoodLinden => 0.25f,
                (ushort)Items.WoodSpruce => 0.25f,
                (ushort)Items.WoodApple => 0.2f,
                (ushort)Items.WoodCherry => 0.2f,
                (ushort)Items.WoodPlum => 0.2f,
                (ushort)Items.WoodLemon => 0.2f,
                (ushort)Items.OliveWood => 0.2f,
                (ushort)Items.WoodOrange => 0.2f,
                (ushort)Items.MangroveWood => 0.195f,
                (ushort)Items.WillowWood => 0.195f,
                (ushort)Items.RubberTreeWood => 0.195f,
                (ushort)Items.EucalyptusWood => 0.225f,
                (ushort)Items.AcaciaWood => 0.225f,
                (ushort)Items.KapokWood => 0.22f,
                (ushort)Items.OreCoal => 0.5f,
                (ushort)Items.Stick => 0.02f,
                (ushort)Items.Paper => 0.05f,
                (ushort)Items.CoalDust => 0.02f,
                (ushort)Items.CoalWood => 0.25f,
                (ushort)Items.ItemCoal => 0.5f,
                (ushort)Items.Plastic => 0.01f,
                (ushort)Items.Sticks => 0.02f,
                (ushort)Items.FewSticks => 0.1f,
                (ushort)Items.Shelf => 0.3f,
                (ushort)Items.BoxWooden => 0.3f,
                (ushort)Items.Flag => 0.05f,
                (ushort)Items.Hay => 0.01f,
                (ushort)Items.Ladder => 0.2f,
                (ushort)Items.OakSapling => 0.02f,
                (ushort)Items.OliveSapling => 0.02f,
                (ushort)Items.OrangeSapling => 0.02f,
                (ushort)Items.PineSapling => 0.02f,
                (ushort)Items.PlumSapling => 0.02f,
                (ushort)Items.RubberTreeSapling => 0.02f,
                (ushort)Items.SpruceSapling => 0.02f,
                (ushort)Items.WillowSapling => 0.02f,
                (ushort)Items.MangroveSapling => 0.02f,
                (ushort)Items.AcaciaSapling => 0.02f,
                (ushort)Items.Yarn => 0.02f,
                (ushort)Items.Bucket => 0.05f,
                (ushort)Items.Cloth => 0.05f,
                (ushort)Items.Desk => 0.1f,
                (ushort)Items.Planks => 0.1f,
                _ => -1f,
            };

    }
}