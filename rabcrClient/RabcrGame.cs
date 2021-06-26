//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;

//namespace rabcrClient {
//    public class RabcrGame: Screen {

//        #region Varibles
//        #region Constants
//        public const float divider_16=1f/16f;
//        public readonly float divider_zoom=1f/Setting.Zoom;
//		public Color ColorGray=Color.Gray;
//		public Color black=Color.Black;
//		public const float DescaySpeed=0.001f;
//        #endregion

//        #region Time
//		public const int hour=200;
//		public int dayLenght=4800;
//		public const float dayStart=5.5f;
//		public const float dayEnd=17.5f;
//        #endregion

//        #region Achievement & Statistics
//        public bool 
//			AchievementStoneAge,
//			AchievementBronzeAge,
//			AchievementIronAge,
//			AchievementFutureAge;
//        #endregion

//        #region World
//        public string world;
//		public static float gravity;
//        public bool notNeedScafander;
//        #endregion

//        #region Player
//		public bool fly;
//		public const float acceleration=0.19f;
//		public float needSpeed, speed;
//		public int speedDir;
//		public bool keyLeft, keyRight;/*, run*/
//		public const float WalkingHandMaxAngle=0.4f;

//        #region Clothes
//        public ClothesTypeUnderwearDown
//            ClothesUnderwearDown,

//			ClothesUnderpants,
//			ClothesBoxerShorts,
//			ClothesPanties,
//			ClothesSwimsuit,
//			ClothesBikiniDown;

//		public ClothesTypeUnderwearUp
//			ClothesUnderwearUp,

//			ClothesBra,
//			ClothesBikiniTop;

//		public ClothesTypeBoots
//			ClothesFeet,

//			ClothesFormalShoes,
//			ClothesPumps,
//			ClothesSneakers,
//			ClothesSpaceBoots;

//		public ClothesTypeTrousers
//			ClothesLegs,

//			ClothesJeans,
//			ClothesShorts,
//			ClothesSkirt,
//			ClothesArmyTrousers,
//			ClothesSpaceTrousers;

//		public ClothesTypeTShirt
//			ClothesChest,

//			ClothesTShirt,
//			ClothesShirt,
//			ClothesDress,
//			ClothesTop;

//		public ClothesTypeCoat
//			ClothesChestTop,

//			ClothesCoatArmy,
//			ClothesCoat,
//			ClothesJacketDenim,
//			ClothesJacketFormal,
//			ClothesJacketShort,
//			ClothesSpaceSuit;

//		public ClothesTypeHelmet
//			ClothesHead,

//			ClothesCap,
//			ClothesHad,
//			ClothesCrown,
//			ClothesSpaceHelmet;
//        #endregion
//        #endregion

//        #region Inventory
//        public const int
//			InventoryClothesSlotCap=0,
//			InventoryClothesSlotTShirt=1,
//			InventoryClothesSlotTrousers=2,
//			InventoryClothesSlotShoes=3,
//			InventoryClothesSlotCoat=4,
//			InventoryClothesSlotBra=5,
//			InventoryClothesSlotUnderwear=6,
//			InventoryClothesSlotBackpack=7;
//        #endregion

//        #region Textures
//		public Texture2D

//		#region Dye
//			TextureDyeWhite,
//			TextureDyeYellow,
//			TextureDyeGold,
//			TextureDyeOrange,
//			TextureDyeRed,
//			TextureDyeDarkRed,
//			TextureDyePink,
//			TextureDyePurple,
//			TextureDyeLightBlue,
//			TextureDyeBlue,
//			TextureDyeDarkBlue,
//			TextureDyeTeal,
//			TextureDyeLightGreen,
//			TextureDyeGreen,
//			TextureDyeDarkGreen,
//			TextureDyeBrown,
//			TextureDyeLightGray,
//			TextureDyeGray,
//			TextureDyeDarkGray,
//			TextureDyeBlack,
//			TextureDyeArmy,
//			TextureDyeMagenta,
//			TextureDyeRoseQuartz,
//			TextureDyeSpringGreen,
//			TextureDyeViolet,
//			TextureDyeOlive,
//		#endregion

//			TextureTestTube,

//		#region Ore
//			TextureOreCoal,
//			TextureOreCopper,
//			TextureOreTin,
//			TextureOreGold,
//			TextureOreIron,
//			TextureOreSilver,
//			TextureOreAluminium,
//			TextureOreSulfur,
//			TextureOreSaltpeter,
//		#endregion

//		#region Back blocks
//			TextureBackSulfurOre,
//			TextureBackSaltpeterOre,

//			backgroundDirtTexture,
//			backgroundGravelTexture,
//			backgroundSandTexture,
//			backgroundCobblestoneTexture,
//			backgroundRegoliteTexture,
//			backgroundRedSandTexture,
//			backgroundClayTexture,

//			backgroundAnorthositeTexture,
//			backgroundBasaltTexture,
//			backgroundDioritTexture,
//			backgroundDolomiteTexture,
//			backgroundFlintTexture,
//			backgroundGabbroTexture,
//			backgroundGneissTexture,
//			backgroundLimestoneTexture,
//			backgroundMudstoneTexture,
//			backgroundRhyoliteTexture,
//			backgroundSandstoneTexture,
//			backgroundSchistTexture,

//			backgroundCoalTexture,
//			backgroundCopperTexture,
//			backgroundTinTexture,
//			backgroundIronTexture,
//			backgroundAluminiumTexture,
//			backgroundSilverTexture,
//			backgroundGoldTexture,
//		#endregion

//		#region Tools
//			// Axe
//			TextureAxeStone,
//			TextureAxeCopper,
//			TextureAxeBronze,
//			TextureAxeGold,
//			TextureAxeIron,
//			TextureAxeSteel,
//			TextureAxeAluminium,

//			// Pickaxe
//			TexturePickaxeStone,
//			TexturePickaxeCopper,
//			TexturePickaxeBronze,
//			TexturePickaxeGold,
//			TexturePickaxeIron,
//			TexturePickaxeSteel,
//			TexturePickaxeAluminium,

//			// Shovel
//			TextureShovelStone,
//			TextureShovelCopper,
//			TextureShovelBronze,
//			TextureShovelGold,
//			TextureShovelIron,
//			TextureShovelSteel,
//			TextureShovelAluminium,

//			// Hoe
//			TextureHoeStone,
//			TextureHoeCopper,
//			TextureHoeBronze,
//			TextureHoeGold,
//			TextureHoeIron,
//			TextureHoeSteel,
//			TextureHoeAluminium,

//			// Saw
//			TextureSawCopper,
//			TextureSawBronze,
//			TextureSawIron,
//			TextureSawSteel,
//			TextureSawAluminium,
//			TextureSawGold,

//			// Hammer
//			TextureHammerCopper,
//			TextureHammerBronze,
//			TextureHammerGold,
//			TextureHammerIron,
//			TextureHammerSteel,
//			TextureHammerAluminium,

//			// Shears
//			TextureShearsCopper,
//			TextureShearsBronze,
//			TextureShearsGold,
//			TextureShearsIron,
//			TextureShearsSteel,
//			TextureShearsAluminium,

//			// Knife
//		   // TextureKnifeStone,
//			TextureKnifeCopper,
//			TextureKnifeBronze,
//			TextureKnifeGold,
//			TextureKnifeIron,
//			TextureKnifeSteel,
//			TextureKnifeAluminium,

//			// Electric
//			TextureDrillElectric,
//			TextureGun,
//			TextureTorchOff,
//			electricSawTexture,
//		#endregion

//		#region Tools head
//			// Pickaxe
//			TexturePickaxeHeadCopper,
//			TexturePickaxeHeadBronze,
//			TexturePickaxeHeadGold,
//			TexturePickaxeHeadIron,
//			TexturePickaxeHeadSteel,
//			TexturePickaxeHeadAluminium,

//			// Shovel
//			TextureShovelHeadCopper,
//			TextureShovelHeadBronze,
//			TextureShovelHeadGold,
//			TextureShovelHeadIron,
//			TextureShovelHeadSteel,
//			TextureShovelHeadAluminium,

//			// Axe
//			TextureAxeHeadCopper,
//			TextureAxeHeadBronze,
//			TextureAxeHeadGold,
//			TextureAxeHeadIron,
//			TextureAxeHeadSteel,
//			TextureAxeHeadAluminium,

//			// Hoe
//			TextureHoeHeadCopper,
//			TextureHoeHeadBronze,
//			TextureHoeHeadGold,
//			TextureHoeHeadIron,
//			TextureHoeHeadSteel,
//			TextureHoeHeadAluminium,

//			// Shears
//			TextureShearsHeadCopper,
//			TextureShearsHeadBronze,
//			TextureShearsHeadGold,
//			TextureShearsHeadIron,
//			TextureShearsHeadSteel,
//			TextureShearsHeadAluminium,

//			// Knife
//			TextureKnifeHeadCopper,
//			TextureKnifeHeadBronze,
//			TextureKnifeHeadGold,
//			TextureKnifeHeadIron,
//			TextureKnifeHeadSteel,
//			TextureKnifeHeadAluminium,



//		#endregion

//		#region player
//			TextureHand,
//		 //   TextureHandDown,

//			// Static
//			TexturePlayerStaticFeet,
//			TexturePlayerStaticLegs,
//			TexturePlayerStaticChest,
//		   // TexturePlayerStaticHead,
//			TexturePlayerStaticHair,
//			TexturePlayerStaticFace,
//			TexturePlayerStaticMoustage,
//			TexturePlayerStaticMouth,
//			TexturePlayerStaticEyes,

//			// Walking
//			TexturePlayerWalkingFeet,
//			TexturePlayerWalkingFeetForShoes,
//			TexturePlayerWalkingLegs,
//			TexturePlayerWalkingChest,
//			TexturePlayerWalkingFace,
//			TexturePlayerWalkingHair,
//			TexturePlayerWalkingMoustage,
//			TexturePlayerWalkingMouth,
//			TexturePlayerWalkingEyes,
//		  //  TexturePlayerWalkingLegsWoman,

//			// Swimming
//		   TexturePlayerSwimmingFeet,
//			TexturePlayerSwimmingLegs,
//		  //  TexturePlayerSwimmingChest,
//		 //   TexturePlayerSwimmingLegsWoman,


//			TextureInventoryClothes,
//			//TextureWalkingClothesHead,
//			//TextureWalkingClothesFeet,
//			//TextureWalkingClothesChest,
//			//TextureWalkingClothesChestTop,
//			//TextureWalkingClothesLegs,
//			//TextureWalkingClothesUnderwearUp,
//			//TextureWalkingClothesUnderwearDown,
//			 //ClothesHead,
//			 //ClothesFeet,
//			 //ClothesChest,
//			 //ClothesChestTop,
//			 //ClothesLegs,
//			 //ClothesUnderwearUp,
//			 //ClothesUnderwearDown,
//			//TextureSwimmingClothesFeet,
//			//TextureSwimmingClothesChest,
//			//TextureSwimmingClothesChestTop,
//			//TextureSwimmingClothesLegs,
//			//TextureSwimmingClothesUnderwearUp,
//			//TextureSwimmingClothesUnderwearDown,


//			TextureWalkingUpCensored,
//			TextureWalkingDownCensored,

//			TextureStaticUpCensored,
//			TextureStaticDownCensored,

//			TextureSwimmingUpCensored,
//			TextureSwimmingDownCensored,


//			//TextureWalkingFormalShoes,
//			//TextureWalkingPumps,
//			//TextureWalkingSneakers,
//			//TextureWalkingSpaceBoots,

//			//TextureWalkingJeans,
//			//TextureWalkingShorts,
//			//TextureWalkingSkirt,
//			//TextureWalkingArmyTrousers,
//			//TextureWalkingSpaceTrousers,

//			//TextureWalkingTShirt,
//			//TextureWalkingSpaceSuit,
//			//TextureWalkingShirt,
//			//TextureWalkingDress,

//			//TextureWalkingCap,
//			//TextureWalkingHad,
//			//TextureWalkingCrown,
//			//TextureWalkingSpaceHelmet,

//			//TextureWalkingUnderpants,
//			//TextureWalkingBoxerShorts,
//			//TextureWalkingPanties,
//			//TextureWalkingSwimsuit,
//			//TextureWalkingBikiniDown,

//			//TextureWalkingCoatArmy,
//			//TextureWalkingCoat,
//			//TextureWalkingJacketDenim,
//			//TextureWalkingJacketFormal,
//			//TextureWalkingJacketShort,

//			//TextureWalkingBra,
//			//TextureWalkingBikiniTop,

//		  //  TextureStaticFormalShoes,
//		  //  TextureStaticPumps,
//		  //  TextureStaticSneakers,
//		  //  TextureStaticSpaceBoots,

//		  //  TextureStaticJeans,
//		  //  TextureStaticShorts,
//		  //  TextureStaticSkirt,
//		  //  TextureStaticArmyTrousers,
//		  //  TextureStaticSpaceTrousers,

//		  //  TextureStaticTShirt,
//		  //  TextureStaticSpaceSuit,
//		  //  TextureStaticShirt,
//		  //  TextureStaticDress,

//		  //  TextureStaticCap,
//		  //  TextureStaticHad,
//		  //  TextureStaticCrown,
//		  //  TextureStaticSpaceHelmet,

//		  //  TextureStaticUnderpants,
//		  //  TextureStaticBoxerShorts,
//		  //  TextureStaticPanties,
//		  //  TextureStaticSwimsuit,
//		  //  TextureStaticBikiniDown,

//		  //  TextureStaticCoatArmy,
//		  //  TextureStaticCoat,
//		  //  TextureStaticJacketDenim,
//		  //  TextureStaticJacketFormal,
//		  ////  TextureStaticJacket,
//		  //  TextureStaticJacketShort,

//		  //  TextureStaticBra,
//		  //  TextureStaticBikiniTop,

//		  //  TextureSwimmingFormalShoes,
//		  //  TextureSwimmingPumps,
//		  //  TextureSwimmingSneakers,
//		  //  TextureSwimmingSpaceBoots,

//		  //  TextureSwimmingJeans,
//		  //  TextureSwimmingShorts,
//		  //  TextureSwimmingSkirt,
//		  //  TextureSwimmingArmyTrousers,
//		  //  TextureSwimmingSpaceTrousers,

//		  //  TextureSwimmingTShirt,
//		  //  TextureSwimmingSpaceSuit,
//		  //  TextureSwimmingShirt,
//		  //  TextureSwimmingDress,

//		  //  TextureSwimmingUnderpants,
//		  //  TextureSwimmingBoxerShorts,
//		  //  TextureSwimmingPanties,
//		  //  TextureSwimmingSwimsuit,
//		  //  TextureSwimmingBikiniDown,

//		  //  TextureSwimmingCoatArmy,
//		  //  TextureSwimmingCoat,
//		  //  TextureSwimmingJacketDenim,
//		  //  TextureSwimmingJacketFormal,
//		  ////  TextureSwimmingJacket,
//		  //  TextureSwimmingJacketShort,

//		  //  TextureSwimmingBra,
//		  //  TextureSwimmingBikiniTop,
//		#endregion

//		#region Trees
//			TextureBranches,

//			//  Oak
//			TextureOakWood,
//			TextureOakLeaves,
//			oakSaplingTexture,

//			// Pine
//			pineWoodTexture,
//			pineLeavesTexture,
//			pineSaplingTexture,

//			//Spruce
//			spruceWoodTexture,
//			spruceLeavesTexture,
//			spruceSaplingTexture,

//			// Linden
//			TextureLindenWood,
//			TextureLindenLeaves,
//			TextureLindenSapling,

//			// Apple
//			TextureAppleWood,
//			TextureAppleLeaves,
//			TextureAppleBlossom,
//			TextureAppleSapling,
//			TextureAppleLeavesWithApples,

//			// Plum
//			TexturePlumWood,
//			TexturePlumLeaves,
//			TexturePlumBlossom,
//			plumSaplingTexture,
//			TexturePlumLeavesWithPlums,

//			// Cherry
//			cherryWoodTexture,
//			TextureCherryBlossom,
//			TextureCherryLeaves,
//			cherrySaplingTexture,
//			TextureCherryLeavesWithCherries,

//			// Orange
//			TextureOrangeWood,
//			TextureOrangeLeaves,
//			TextureOrangeLeavesWithOranges,
//			orangeSaplingTexture,

//			// Lemon
//			TextureLemonWood,
//			TextureLemonLeaves,
//			lemonLeavesWithLemonsTexture,
//			lemonSaplingTexture,

//			// Willow
//			TextureWillowLeaves,
//			TextureWillowWood,
//			TextureWillowSapling,

//			// Mangrove
//			TextureMangroveLeaves,
//			TextureMangroveWood,
//			TextureMangroveSapling,

//			// Eucalyptus
//			TextureEucalyptusLeaves,
//			TextureEucalyptusWood,
//			TextureEucalyptusSapling,

//			// Olive
//			TextureOliveLeavesWithOlives,
//			TextureOliveLeaves,
//			TextureOliveWood,
//			TextureOliveSapling,

//			// Rubber
//			TextureRubberTreeLeaves,
//			TextureRubberTreeWood,
//			TextureRubberTreeSapling,

//			// Accacia
//			TextureAcaciaLeaves,
//			TextureAcaciaWood,
//			TextureAcaciaSapling,

//			// Kapok
//			TextureKapokBlossom,
//			TextureKapokLeavesFibre,
//			TextureKapokLeaves,
//			TextureKapokSapling,
//			TextureKapokWood,
//		#endregion

//		#region Clothes
//			// Shoes
//			TextureItemFormalShoes,
//			TextureItemPumps,
//			TextureItemSneakers,
//			TextureItemSpaceBoots,

//			// Trousers + skirt
//			TextureItemJeans,
//			TextureItemShorts,
//			TextureItemSpaceTrousers,
//			TextureItemArmyTrousers,
//			TextureItemSkirt,

//			// T-shirts + dress
//			TextureItemTShirt,
//			TextureItemSpaceSuit,
//			TextureItemDress,
//			TextureItemShirt,

//			// head
//			TextureItemCap,
//			TextureItemHat,
//			TextureItemCrown,
//			TextureItemSpaceHelmet,

//			// bottom
//			TextureItemUnderpants,
//			TextureItemBoxerShorts,
//			TextureItemPanties,
//			TextureItemSwimsuit,
//			TextureItemBikiniDown,

//			// Top
//			TextureItemBra,
//			TextureItemBikiniTop,

//			// Coat
//			TextureItemCoatArmy,
//			TextureItemCoat,
//			ItemJacketDenimTexture,
//			ItemJacketFormalTexture,
//		  //  ItemJacketTexture,
//			TextureItemJacketShort,
//		#endregion

//		#region Foods

//			// Fruit
//			ItemOrangeTexture,
//			ItemLemonTexture,
//			ItemAppleTexture,
//			ItemBananaTexture,
//			ItemCherryTexture,
//			ItemPlumTexture,

//			rashberryTexture,
//			strawberryTexture,
//			blueberryTexture,

//			// Wegetable
//			ItemOnionTexture,

//			// Meat
//			ItemRabbtCookedMeatTexture,
//			ItemRabbitMeatTexture,


//		#endregion

//			TextureSulfur,
//			TextureSaltpeter,
//			TextureGunpowder,
//			TextureAmmo,


//			TextureBucketForRubber,
//			TextureBucketWithLatex,
//			TextureResin,
//			TextureSelectCrafting,
//			RadioButtonPause,
//			RadioButtonPlay,
//			sewingMachineTexture,

//			ItemOliveTexture,
//			ItemKapokFibreTexture,

//			CompostTexture,
//			ComposterTexture,
//			ComposterFullTexture,
//			LightElectricTexture,
//			lightMaskLineTexture,
//			lightMaskRoundTexture,
//			rabbitStillTexture,
//			chickenStillTexture,
//			lightMaskTexture,
//			RodTexture,
//			chargerTexture,
//			TextureRedSand,
//			mudstoneTexture,
//			flintTexture,
//			stoneHeadTexture,

//			rocketTexture,
//			anorthositeTexture,
//			regoliteTexture,
//			solidFuelSmokeTexture,
//			mobileTexture,
//			bucketOilTexture,
//			bottleOilTexture,
//			bowlEmptyTexture,
//			bowlMushroomsTexture,
//			bowlVegetablesTexture,
//			messageLeft,
//			bottleEmptyTexture,
//			bottleWaterTexture,
//			boxWoodenTexture,
//			messageCenter,
//			messageRight,
//			flaxSeedsTexture,
//			fishCookedTexture,
//			flaxInvTexture,
//			invStrawberryTexture,
//			invRashberryTexture,
//			invBlueberryTexture,
//			shelfTexture,
//			boxAdvTexture,
//			nailTexture,
//			siliciumTexture,

//			//Items
//			condenserTexture,
//			diodeTexture,
//			tranzistorTexture,
//			resistanceTexture,
//			motorTexture,
//			bareLabelTexture,

//			//Blocks
//			roof1Texture,
//			roof2Texture,
//			scrollbarUpTexture,
//			scrollbarBetweenTexture,
//			scrollbarDownTexture,
//			inventoryNeedTexture,
//			inventorySlotTexture,
//			inventorySlotInTexture,
//			inventorySlotOutTexture,

//			clothTexture,
//			yarnTexture,
//			chickenEatTexture,
//			chickenWalkTexture,
//			rabbitEatTexture,
//			rabbitJumpTexture,
//			rabbitWalkTexture,
//			sunTexture,

//			barEnergyTexture,

//			plateCopperTexture,
//			plateIronTexture,
//			plateBronzeTexture,
//			plateAluminiumTexture,
//			plateGoldTexture,

//			oneBrickTexture,
//			oneMudBrickTexture,

//			boletusTexture,

//			coralTexture,
//			flaxTexture,
//			toadstoolTexture,
//			champignonTexture,
//			sugarCaneTexture,
//			seaweedTexture,
//			heatherTexture,

//			dolomiteTexture,
//			basaltTexture,
//			limestoneTexture,
//			rhyoliteTexture,
//			gneissTexture,
//			sandstoneTexture,
//			schistTexture,
//			gabbroTexture,
//			dioritTexture,

//			lavaTexture,

//			radioInvTexture,
//			advancedSpaceBackTexture,
//			advancedSpaceWindowTexture,
//			advancedSpaceBlockTexture,
//			advancedSpacePart1Texture,
//			advancedSpacePart2Texture,
//			advancedSpacePart3Texture,
//			advancedSpacePart4Texture,
//			advancedSpaceFloorTexture,
//			doorInvTexture,

//			oilTexture,
//			lianaTexture,

//			branchWithoutTexture,
//			branchALittle1Texture,
//			branchALittle2Texture,
//			branchFullTexture,

//			// Still Items
//			furnaceStoneOneTexture,
//			maceratorOneTexture,
//			furnaceElectricOneTexture,
//			labelOneTexture,
//			ashTexture,
//			coalWoodTexture,
//			snowTopTexture,

//			// Bars
//			barEatTexture,
//			barWaterTexture,
//			barOxygenTexture,
//			barHeartTexture,

//			// Textures blocks
//			//rocks0Texture,
//			//rocks1Texture,
//			//rocks2Texture,
//			//rocks3Texture,
//			TextureDirt,
//			gravelTexture,
//			sandTexture,
//			waterTexture,
//			snowTexture,
//			iceTexture,
//			cobblestoneTexture,

//			//GrassBlock
//			TextureGrassBlockPlains,
//			TextureGrassBlockHills,
//			TextureGrassBlockForest,
//			TextureGrassBlockDesert,
//			TextureGrassBlockJungle,
//			TextureGrassBlockClay,
//			TextureGrassBlockCompost,
//			TextureGrassBlockSnow,

//			//CraftingBlocks
//			bricksTexture,
//			deskTexture,
//			doorOpenTexture,
//			doorCloseTexture,
//			furnaceElectricTexture,
//			furnaceStoneTexture,
//			glassTexture,
//			hayBlockTexture,
//			labelTexture,
//			ladderTexture,
//			lampTexture,

//			maceratorTexture,
//			minerTexture,
//			TextureMoon,
//			radioTexture,

//			solarPanelTexture,
//			planksTexture,

//			torchTexture,
//			flagTexture,
//			waterMillTexture,
//			windMillTexture,

//			// Plants
//			plantAloreTexture,
//			plantCarrotTexture,
//			plantOnionTexture,
//			plantPeasTexture,

//			ItemPeasTexture,
//			ItemCarrotTexture,

//			blueberryPlantTexture,
//			strawberryPlantTexture,
//			rashberryPlantTexture,

//			wheatTexture,

//			cactusBigTexture,
//			cactusLittleTexture,

//			grassJungleTexture,
//			grassDesertTexture,
//			grassForestTexture,
//			grassHillsTexture,
//			grassPlainsTexture,

//			plantVioletTexture,
//			plantRoseTexture,
//			plantOrchidTexture,
//			plantDandelionTexture,

//			torchInvTexture,
//			clayTexture,



//			// Animals
//			fishTexture0,
//			fishTexture1,

//			// Animations
//			destructionTexture,

//			//Dusts
//			ItemAluminiumDustTexture,
//			ItemBronzeDustTexture,
//			ItemCoalDustTexture,
//			ItemCopperDustTexture,
//			ItemGoldDustTexture,
//			ItemIronDustTexture,
//			ItemSilverDustTexture,
//			ItemStoneDustTexture,
//			ItemTinDustTexture,
//			ItemWoodDustTexture,

//			//Electronic
//			ItemBatteryTexture,
//			ItemBigCircuitTexture,
//			ItemBulbTexture,
//			ItemCircuitTexture,
//			ItemRubberTexture,



//		#region Ingots
//			ItemAluminiumIngotTexture,
//			ItemBronzeIngotTexture,
//			ItemCopperIngotTexture,
//			ItemGoldIngotTexture,
//			ItemIronIngotTexture,
//			ItemSilverIngotTexture,
//			ItemTinIngotTexture,
//		#endregion

//			// MashinesBlocks
//			ItemDoorTexture,
//			ItemFlagTexture,
//			ItemRocketTexture,
//			ItemWaterMillTexture,
//			ItemWindMillTexture,

//			//Nature
//			ItemHayTexture,
//			ItemLeaveTexture,
//			ItemSeedsTexture,
//			ItemStickTexture,
//			ItemSticksTexture,
//			ItemWheatSeedsTexture,
//			ItemWheatStrawTexture,

//		#region Rocks
//			ItemCoalTexture,
//			ItemCopperTexture,
//			ItemDiamondTexture,
//			ItemAluminiumTexture,
//			ItemGoldTexture,
//			ItemIronTexture,
//			ItemPlasticTexture,
//			ItemRubyTexture,
//			ItemSaphiriteTexture,
//			ItemSilverTexture,
//			ItemSmaragdTexture,
//			ItemBigStoneTexture,
//			ItemMediumStoneTexture,
//			ItemSmallStoneTexture,
//			ItemTinTexture,
//		#endregion

//			ItemBackpackTexture,
//			ItemBucketTexture,
//			ItemBucketWaterTexture,
//			ItemRopeTexture;
//		#endregion
//        #endregion


//        #endregion

//        public void CountGravity(AstronomicalObject[] objects) {
//			for (int oi=0; oi<objects.Length; oi++) {
//				AstronomicalObject o = objects[oi];

//				if (o.NameEn!=null) {
//					if (o.NameEn==world) {
//						gravity=(float)(6.67259e-11*o.Mass/(o.MeanDiameter*o.MeanDiameter*1000000))/20f;
//						notNeedScafander=o.astrO==AstrO.Life;
//						dayLenght=(int)(o.DayLenght*200);
//						return;
//					}
//				}
//				if (o.Childs!=null) {
//					CountGravity(o.Childs);
//					if (gravity!=0) return;
//				}
//			}
//		}

//        public class ParticleMess { 
//			public Vector2 Position;
//			public Rectangle Source;
//			public Texture2D Texture;
//			public int Disepeard;

//			public float LimitY;
//			public float HSpeed;
//			public float VSpeed;
//			public Color Color;

//			public void Update() {
//				HSpeed+=gravity*0.5f;
//				Position.Y+=HSpeed;

//				Position.X+=VSpeed;

//				if (Position.Y>=LimitY) Position.Y=LimitY;
//			}

//			public void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, Source, Color*(Disepeard/50f));
//		}

//		public class ParticleRain { 
//			public Vector2 Position;

//			public float HSpeed;
//			public float VSpeed;
//			public Color Color;
//		//	public float Angle;

//			public float Size;

//			public ParticleRain(float size, float vSpeed) { 
//				Color=Color.Blue*(Size=size);
//				VSpeed=vSpeed*(size*0.5f+0.5f);
//			}

//			public void Update() {
//				Position.X+=HSpeed*Size;
//				Position.Y+=VSpeed;
//			}

//			public void Draw(float x, float y) => Rabcr.spriteBatch.Draw(
//					texture: Rabcr.Pixel,
//					destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y), 1, Size<0.5f ? 2 : 3),
//					//sourceRectangle: null,
//					//effects:SpriteEffects.None,
//					color: Color/*,*/
//					//rotation: Angle,
//					//origin: Vector2.Zero,
//					//layerDepth: 1f
//				); 
//		}

//		public class ParticleSnow { 
//			public Vector2 Position;

//			public float HSpeed;
//			public float VSpeed;
//			public Color Color;
//		//	public float Angle;
//			int time;
//			public float Size;

//			public ParticleSnow(float size, float vSpeed) { 
//				Color=Color.White*(Size=size);
//				VSpeed=vSpeed*size;
//			}

//			public void Update() {
//				time++;
//				Position.X+=HSpeed+((float)Math.Cos(time/10f))*0.25f;
//				Position.Y+=VSpeed+((float)Math.Sin(time/10f))*HSpeed*0.5f/*+0.2f*/;
//			}

//			public void Draw(float x, float y) => Rabcr.spriteBatch.Draw(
//					texture: Rabcr.Pixel,
//					destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y), Size>0.5f ? 2 : 1, Size>0.5f ? 2 : 1),
//					//sourceRectangle: null,
//					//effects:SpriteEffects.None,
//					color: Color//,
//					//rotation: Angle,
//					//origin: Vector2.Zero,
//					//layerDepth: 1f
//				); 

//		}

//		public class FallingLeave{ 
//			public Texture2D texture;
//			public Vector2 Position;
//			public float angle;
//			public float time;
//		//	public float size;
//			Vector2 vecOrigin;
//			public float VSpeed;
//			public Rectangle srcrec;
//			public Color Color=Color.White;
//			public FallingLeave(int x, int y, float size, bool leftWind, bool rain, Rectangle src) {
//				Position=new Vector2(x, y);
//				vecOrigin=new Vector2(size, size);
//				if (rain){ 
//					if (leftWind) VSpeed=-0.01f; else VSpeed=0.01f; 
//				} else {
//					if (leftWind) VSpeed=-0.09f; else VSpeed=0.09f; 
//				}
//				srcrec=src;
//			}

//			public void Update() {
//				time+=0.07f;
//				Position.X+=VSpeed;
//				Position.Y+=(float)Math.Cos(time)*0.1f+0.2f;
//				angle=(float)Math.Cos(time)*0.3f+FastMath.PI/2f;
//			}

//			public void Draw(){ 
//				Rabcr.spriteBatch.Draw(
//					texture: texture, 
//					destinationRectangle: new Rectangle((int)Position.X, (int)Position.Y, srcrec.Width, srcrec.Height), 
//					sourceRectangle: srcrec/*new Rectangle(0,0,2,3)*/,
//					effects:SpriteEffects.None,
//					color: Color, 
//					rotation: angle,
//					origin: vecOrigin,
//					layerDepth: 1f);    
//			}
//		}

//		public Color BiomeColor(Biome biome) { 
//			switch (biome) { 
//				case Biome.Desert: return Color.Yellow;
//				case Biome.Savanna: return new Color(110,85,32);
//				case Biome.SaltOcean: return new Color(10,48,96);
//				case Biome.Arctic: return Color.White;
//				case Biome.Bog: return new Color(111,81,14);
//				case Biome.ColdTaiga: return new Color(25,21,3);
//				case Biome.Taiga: return new Color(47,59,11);
//				case Biome.Tundra: return new Color(188,7,1);
//				case Biome.WetTundra: return new Color(20,16,3);
//				case Biome.Swamp: return new Color(26,46,12);
//				case Biome.TropicalRainforest: return new Color(3,36,2);
//				case Biome.Subtropics: return new Color(39,42,14);
//				case Biome.ArcticPlains: return new Color(163,169,186);
//				case Biome.Beach: return new Color(213,159,109);
//				case Biome.BothForest: return new Color(107,146,15);
//				case Biome.DryTundra: return new Color(9,8,5);
//				case Biome.Fen: return new Color(61,84,21);
//				case Biome.HotPlains: return new Color(128,54,8);
//				case Biome.HumidSubtropical: return new Color(28,59,13);
//				case Biome.LeaveForest: return new Color(11,57,10);
//				case Biome.Mangrove: return new Color(60,85,16);
//				case Biome.Plains: return new Color(57,59,9);
//				case Biome.SpruceForest: return new Color(53,54,13);
//				case Biome.Jungle: return new Color(2,61,0);
//			}
//			//#if DEBUG
//			//throw new Exception("Missing biome color");
//			//#else
//			return Color.Green;
//		   // #endif
//		}
//    }
//}
