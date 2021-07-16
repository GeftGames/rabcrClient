using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace rabcrClient {
    class SinglePlayer: Screen {
		#region Varibles
		static Color 
			ColorArmy= new Color(0xff113022), // R 34, G 48, B 17, A 255
			ColorSpringGreen=new Color(0xff2cff8f), //R 143, G 225, B 44, A 255
			ColorRoseQuartz=new Color(0xffa998aa); //R 170, G 152, B 169

		float actualRainForce=0.75f;
		float rainWaveForce;

		#region Textures
		Texture2D
			TextureParrotStill,
			TextureParrotFly,
			TextureBin,
			TextureEggDrop,TextureOxygenMachine, TextureAirTank, TextureAirTank2, TextureBarrel, TextureIngotSteel,
			TextureItemEgg, TextureItemBoiledEgg, TextureWaterGraystyle, TextureChristmasStar,
			TextureBarBarrel, pixel,
			TextureClouds,
			TextureSunGradient,
		
			TextureChristmasBall, 
			TextureChristmasBallYellow, 
			TextureChristmasBallOrange, 
			TextureChristmasBallRed, 
			TextureChristmasBallPurple, 
			TextureChristmasBallPink, 
			TextureChristmasBallLightGreen, 
			TextureChristmasBallBlue, 
			TextureChristmasBallTeal,
			TextureAngelHair,
			TextureAngelHairWithSpruceLeaves,
			
			TextureChristmasBallGrayWithLeaves,
			TextureChristmasBallYellowWithLeaves,
			TextureChristmasBallOrangeWithLeaves,
			TextureChristmasBallRedWithLeaves,
			TextureChristmasBallPurpleWithLeaves,
			TextureChristmasBallPinkWithLeaves,
			TextureChristmasBallLightGreenWithLeaves,
			TextureChristmasBallBlueWithLeaves,
			TextureChristmasBallTealWithLeaves,

		#region Dye
			TextureDyeWhite,
			TextureDyeYellow,
			TextureDyeGold,
			TextureDyeOrange,
			TextureDyeRed,
			TextureDyeDarkRed,
			TextureDyePink,
			TextureDyePurple,
			TextureDyeLightBlue,
			TextureDyeBlue,
			TextureDyeDarkBlue,
			TextureDyeTeal,
			TextureDyeLightGreen,
			TextureDyeGreen,
			TextureDyeDarkGreen,
			TextureDyeBrown,
			TextureDyeLightGray,
			TextureDyeGray,
			TextureDyeDarkGray,
			TextureDyeBlack,
			TextureDyeArmy,
			TextureDyeMagenta,
			TextureDyeRoseQuartz,
			TextureDyeSpringGreen,
			TextureDyeViolet,
			TextureDyeOlive,
		#endregion

			TextureTestTube,

		#region Ore
			TextureOreCoal,
			TextureOreCopper,
			TextureOreTin,
			TextureOreGold,
			TextureOreIron,
			TextureOreSilver,
			TextureOreAluminium,
			TextureOreSulfur,
			TextureOreSaltpeter,
		#endregion

		#region Back blocks
			TextureBackSulfurOre,
			TextureBackSaltpeterOre,

			backgroundDirtTexture,
			backgroundGravelTexture,
			backgroundSandTexture,
			backgroundCobblestoneTexture,
			backgroundRegoliteTexture,
			backgroundRedSandTexture,
			backgroundClayTexture,

			backgroundAnorthositeTexture,
			backgroundBasaltTexture,
			backgroundDioritTexture,
			backgroundDolomiteTexture,
			backgroundFlintTexture,
			backgroundGabbroTexture,
			backgroundGneissTexture,
			backgroundLimestoneTexture,
			backgroundMudstoneTexture,
			backgroundRhyoliteTexture,
			backgroundSandstoneTexture,
			backgroundSchistTexture,

			backgroundCoalTexture,
			backgroundCopperTexture,
			backgroundTinTexture,
			backgroundIronTexture,
			backgroundAluminiumTexture,
			backgroundSilverTexture,
			backgroundGoldTexture,
		#endregion

		#region Tools
			// Axe
			TextureAxeStone,
			TextureAxeCopper,
			TextureAxeBronze,
			TextureAxeGold,
			TextureAxeIron,
			TextureAxeSteel,
			TextureAxeAluminium,

			// Pickaxe
			TexturePickaxeStone,
			TexturePickaxeCopper,
			TexturePickaxeBronze,
			TexturePickaxeGold,
			TexturePickaxeIron,
			TexturePickaxeSteel,
			TexturePickaxeAluminium,

			// Shovel
			TextureShovelStone,
			TextureShovelCopper,
			TextureShovelBronze,
			TextureShovelGold,
			TextureShovelIron,
			TextureShovelSteel,
			TextureShovelAluminium,

			// Hoe
			TextureHoeStone,
			TextureHoeCopper,
			TextureHoeBronze,
			TextureHoeGold,
			TextureHoeIron,
			TextureHoeSteel,
			TextureHoeAluminium,

			// Saw
			TextureSawCopper,
			TextureSawBronze,
			TextureSawIron,
			TextureSawSteel,
			TextureSawAluminium,
			TextureSawGold,

			// Hammer
			TextureHammerCopper,
			TextureHammerBronze,
			TextureHammerGold,
			TextureHammerIron,
			TextureHammerSteel,
			TextureHammerAluminium,

			// Shears
			TextureShearsCopper,
			TextureShearsBronze,
			TextureShearsGold,
			TextureShearsIron,
			TextureShearsSteel,
			TextureShearsAluminium,

			// Knife
		   // TextureKnifeStone,
			TextureKnifeCopper,
			TextureKnifeBronze,
			TextureKnifeGold,
			TextureKnifeIron,
			TextureKnifeSteel,
			TextureKnifeAluminium,

			// Electric
			TextureDrillElectric,
			TextureGun,
			TextureTorchOff,
			electricSawTexture,
		#endregion

		#region Tools head
			// Pickaxe
			TexturePickaxeHeadCopper,
			TexturePickaxeHeadBronze,
			TexturePickaxeHeadGold,
			TexturePickaxeHeadIron,
			TexturePickaxeHeadSteel,
			TexturePickaxeHeadAluminium,

			// Shovel
			TextureShovelHeadCopper,
			TextureShovelHeadBronze,
			TextureShovelHeadGold,
			TextureShovelHeadIron,
			TextureShovelHeadSteel,
			TextureShovelHeadAluminium,

			// Axe
			TextureAxeHeadCopper,
			TextureAxeHeadBronze,
			TextureAxeHeadGold,
			TextureAxeHeadIron,
			TextureAxeHeadSteel,
			TextureAxeHeadAluminium,

			// Hoe
			TextureHoeHeadCopper,
			TextureHoeHeadBronze,
			TextureHoeHeadGold,
			TextureHoeHeadIron,
			TextureHoeHeadSteel,
			TextureHoeHeadAluminium,

			// Shears
			TextureShearsHeadCopper,
			TextureShearsHeadBronze,
			TextureShearsHeadGold,
			TextureShearsHeadIron,
			TextureShearsHeadSteel,
			TextureShearsHeadAluminium,

			// Knife
			TextureKnifeHeadCopper,
			TextureKnifeHeadBronze,
			TextureKnifeHeadGold,
			TextureKnifeHeadIron,
			TextureKnifeHeadSteel,
			TextureKnifeHeadAluminium,



		#endregion

		#region player
			TextureHand,
		 //   TextureHandDown,

			// Static
			TexturePlayerStaticFeet,
			TexturePlayerStaticLegs,
			TexturePlayerStaticChest,
		   // TexturePlayerStaticHead,
			TexturePlayerStaticHair,
			TexturePlayerStaticFace,
			TexturePlayerStaticMoustage,
			TexturePlayerStaticMouth,
			TexturePlayerStaticEyes,

			// Walking
			TexturePlayerWalkingFeet,
			TexturePlayerWalkingFeetForShoes,
			TexturePlayerWalkingLegs,
			TexturePlayerWalkingChest,
			TexturePlayerWalkingFace,
			TexturePlayerWalkingHair,
			TexturePlayerWalkingMoustage,
			TexturePlayerWalkingMouth,
			TexturePlayerWalkingEyes,
		  //  TexturePlayerWalkingLegsWoman,

			// Swimming
		   TexturePlayerSwimmingFeet,
			TexturePlayerSwimmingLegs,
		  //  TexturePlayerSwimmingChest,
		 //   TexturePlayerSwimmingLegsWoman,


			TextureInventoryClothes,
			//TextureWalkingClothesHead,
			//TextureWalkingClothesFeet,
			//TextureWalkingClothesChest,
			//TextureWalkingClothesChestTop,
			//TextureWalkingClothesLegs,
			//TextureWalkingClothesUnderwearUp,
			//TextureWalkingClothesUnderwearDown,
			 //ClothesHead,
			 //ClothesFeet,
			 //ClothesChest,
			 //ClothesChestTop,
			 //ClothesLegs,
			 //ClothesUnderwearUp,
			 //ClothesUnderwearDown,
			//TextureSwimmingClothesFeet,
			//TextureSwimmingClothesChest,
			//TextureSwimmingClothesChestTop,
			//TextureSwimmingClothesLegs,
			//TextureSwimmingClothesUnderwearUp,
			//TextureSwimmingClothesUnderwearDown,


			TextureWalkingUpCensored,
			TextureWalkingDownCensored,

			TextureStaticUpCensored,
			TextureStaticDownCensored,

			TextureSwimmingUpCensored,
			TextureSwimmingDownCensored,


			//TextureWalkingFormalShoes,
			//TextureWalkingPumps,
			//TextureWalkingSneakers,
			//TextureWalkingSpaceBoots,

			//TextureWalkingJeans,
			//TextureWalkingShorts,
			//TextureWalkingSkirt,
			//TextureWalkingArmyTrousers,
			//TextureWalkingSpaceTrousers,

			//TextureWalkingTShirt,
			//TextureWalkingSpaceSuit,
			//TextureWalkingShirt,
			//TextureWalkingDress,

			//TextureWalkingCap,
			//TextureWalkingHad,
			//TextureWalkingCrown,
			//TextureWalkingSpaceHelmet,

			//TextureWalkingUnderpants,
			//TextureWalkingBoxerShorts,
			//TextureWalkingPanties,
			//TextureWalkingSwimsuit,
			//TextureWalkingBikiniDown,

			//TextureWalkingCoatArmy,
			//TextureWalkingCoat,
			//TextureWalkingJacketDenim,
			//TextureWalkingJacketFormal,
			//TextureWalkingJacketShort,

			//TextureWalkingBra,
			//TextureWalkingBikiniTop,

		  //  TextureStaticFormalShoes,
		  //  TextureStaticPumps,
		  //  TextureStaticSneakers,
		  //  TextureStaticSpaceBoots,

		  //  TextureStaticJeans,
		  //  TextureStaticShorts,
		  //  TextureStaticSkirt,
		  //  TextureStaticArmyTrousers,
		  //  TextureStaticSpaceTrousers,

		  //  TextureStaticTShirt,
		  //  TextureStaticSpaceSuit,
		  //  TextureStaticShirt,
		  //  TextureStaticDress,

		  //  TextureStaticCap,
		  //  TextureStaticHad,
		  //  TextureStaticCrown,
		  //  TextureStaticSpaceHelmet,

		  //  TextureStaticUnderpants,
		  //  TextureStaticBoxerShorts,
		  //  TextureStaticPanties,
		  //  TextureStaticSwimsuit,
		  //  TextureStaticBikiniDown,

		  //  TextureStaticCoatArmy,
		  //  TextureStaticCoat,
		  //  TextureStaticJacketDenim,
		  //  TextureStaticJacketFormal,
		  ////  TextureStaticJacket,
		  //  TextureStaticJacketShort,

		  //  TextureStaticBra,
		  //  TextureStaticBikiniTop,

		  //  TextureSwimmingFormalShoes,
		  //  TextureSwimmingPumps,
		  //  TextureSwimmingSneakers,
		  //  TextureSwimmingSpaceBoots,

		  //  TextureSwimmingJeans,
		  //  TextureSwimmingShorts,
		  //  TextureSwimmingSkirt,
		  //  TextureSwimmingArmyTrousers,
		  //  TextureSwimmingSpaceTrousers,

		  //  TextureSwimmingTShirt,
		  //  TextureSwimmingSpaceSuit,
		  //  TextureSwimmingShirt,
		  //  TextureSwimmingDress,

		  //  TextureSwimmingUnderpants,
		  //  TextureSwimmingBoxerShorts,
		  //  TextureSwimmingPanties,
		  //  TextureSwimmingSwimsuit,
		  //  TextureSwimmingBikiniDown,

		  //  TextureSwimmingCoatArmy,
		  //  TextureSwimmingCoat,
		  //  TextureSwimmingJacketDenim,
		  //  TextureSwimmingJacketFormal,
		  ////  TextureSwimmingJacket,
		  //  TextureSwimmingJacketShort,

		  //  TextureSwimmingBra,
		  //  TextureSwimmingBikiniTop,
		#endregion

		#region Trees
			TextureBranches,

			//  Oak
			TextureOakWood,
			TextureOakLeaves,
			oakSaplingTexture,

			// Pine
			pineWoodTexture,
			pineLeavesTexture,
			pineSaplingTexture,

			//Spruce
			spruceWoodTexture,
			spruceLeavesTexture,
			spruceSaplingTexture,

			// Linden
			TextureLindenWood,
			TextureLindenLeaves,
			TextureLindenSapling,

			// Apple
			TextureAppleWood,
			TextureAppleLeaves,
			TextureAppleBlossom,
			TextureAppleSapling,
			TextureAppleLeavesWithApples,

			// Plum
			TexturePlumWood,
			TexturePlumLeaves,
			TexturePlumBlossom,
			plumSaplingTexture,
			TexturePlumLeavesWithPlums,

			// Cherry
			cherryWoodTexture,
			TextureCherryBlossom,
			TextureCherryLeaves,
			cherrySaplingTexture,
			TextureCherryLeavesWithCherries,

			// Orange
			TextureOrangeWood,
			TextureOrangeLeaves,
			TextureOrangeLeavesWithOranges,
			orangeSaplingTexture,

			// Lemon
			TextureLemonWood,
			TextureLemonLeaves,
			lemonLeavesWithLemonsTexture,
			lemonSaplingTexture,

			// Willow
			TextureWillowLeaves,
			TextureWillowWood,
			TextureWillowSapling,

			// Mangrove
			TextureMangroveLeaves,
			TextureMangroveWood,
			TextureMangroveSapling,

			// Eucalyptus
			TextureEucalyptusLeaves,
			TextureEucalyptusWood,
			TextureEucalyptusSapling,

			// Olive
			TextureOliveLeavesWithOlives,
			TextureOliveLeaves,
			TextureOliveWood,
			TextureOliveSapling,

			// Rubber
			TextureRubberTreeLeaves,
			TextureRubberTreeWood,
			TextureRubberTreeSapling,

			// Accacia
			TextureAcaciaLeaves,
			TextureAcaciaWood,
			TextureAcaciaSapling,

			// Kapok
			TextureKapokBlossom,
			TextureKapokLeavesFibre,
			TextureKapokLeaves,
			TextureKapokSapling,
			TextureKapokWood,
		#endregion

		#region Clothes
			// Shoes
			TextureItemFormalShoes,
			TextureItemPumps,
			TextureItemSneakers,
			TextureItemSpaceBoots,

			// Trousers + skirt
			TextureItemJeans,
			TextureItemShorts,
			TextureItemSpaceTrousers,
			TextureItemArmyTrousers,
			TextureItemSkirt,

			// T-shirts + dress
			TextureItemTShirt,
			TextureItemSpaceSuit,
			TextureItemDress,
			TextureItemShirt,

			// head
			TextureItemCap,
			TextureItemHat,
			TextureItemCrown,
			TextureItemSpaceHelmet,

			// bottom
			TextureItemUnderpants,
			TextureItemBoxerShorts,
			TextureItemPanties,
			TextureItemSwimsuit,
			TextureItemBikiniDown,

			// Top
			TextureItemBra,
			TextureItemBikiniTop,

			// Coat
			TextureItemCoatArmy,
			TextureItemCoat,
			ItemJacketDenimTexture,
			ItemJacketFormalTexture,
		  //  ItemJacketTexture,
			TextureItemJacketShort,
		#endregion

		#region Foods

			// Fruit
			ItemOrangeTexture,
			ItemLemonTexture,
			ItemAppleTexture,
			ItemBananaTexture,
			ItemCherryTexture,
			ItemPlumTexture,

			rashberryTexture,
			strawberryTexture,
			blueberryTexture,

			// Wegetable
			ItemOnionTexture,

			// Meat
			ItemRabbtCookedMeatTexture,
			ItemRabbitMeatTexture,


		#endregion

			TextureSulfur,
			TextureSaltpeter,
			TextureGunpowder,
			TextureAmmo,


			TextureBucketForRubber,
			TextureBucketWithLatex,
			TextureResin,
			TextureSelectCrafting,
			RadioButtonPause,
			RadioButtonPlay,
			sewingMachineTexture,

			ItemOliveTexture,
			ItemKapokFibreTexture,

			CompostTexture,
			ComposterTexture,
			ComposterFullTexture,
			LightElectricTexture,
			lightMaskLineTexture,
			lightMaskRoundTexture,
			rabbitStillTexture,
			chickenStillTexture,
			lightMaskTexture,
			lightMask2Texture,
			lightMaskLine2Texture,
			RodTexture,
			chargerTexture,
			TextureRedSand,
			mudstoneTexture,
			flintTexture,
			stoneHeadTexture,

			rocketTexture,
			anorthositeTexture,
			regoliteTexture,
			solidFuelSmokeTexture,
			mobileTexture,
			bucketOilTexture,
			bottleOilTexture,
			bowlEmptyTexture,
			bowlMushroomsTexture,
			bowlVegetablesTexture,
			messageLeft,
			bottleEmptyTexture,
			bottleWaterTexture,
			boxWoodenTexture,
			messageCenter,
			messageRight,
			flaxSeedsTexture,
			fishCookedTexture,
			flaxInvTexture,
			invStrawberryTexture,
			invRashberryTexture,
			invBlueberryTexture,
			shelfTexture,
			boxAdvTexture,
			nailTexture,
			siliciumTexture,

			//Items
			condenserTexture,
			diodeTexture,
			tranzistorTexture,
			resistanceTexture,
			motorTexture,
			bareLabelTexture,

			//Blocks
			roof1Texture,
			roof2Texture,
			scrollbarUpTexture,
			scrollbarBetweenTexture,
			scrollbarDownTexture,
			inventoryNeedTexture,
			inventorySlotTexture,
			inventorySlotInTexture,
			inventorySlotOutTexture,

			clothTexture,
			yarnTexture,
			chickenEatTexture,
			chickenWalkTexture,
			rabbitEatTexture,
			rabbitJumpTexture,
			rabbitWalkTexture,
			sunTexture,

			barEnergyTexture,

			plateCopperTexture,
			plateIronTexture,
			plateBronzeTexture,
			plateAluminiumTexture,
			plateGoldTexture,

			oneBrickTexture,
			oneMudBrickTexture,

			boletusTexture,

			coralTexture,
			flaxTexture,
			toadstoolTexture,
			champignonTexture,
			sugarCaneTexture,
			seaweedTexture,
			heatherTexture,

			dolomiteTexture,
			basaltTexture,
			limestoneTexture,
			rhyoliteTexture,
			gneissTexture,
			sandstoneTexture,
			schistTexture,
			gabbroTexture,
			dioritTexture,

			lavaTexture,

			radioInvTexture,
			advancedSpaceBackTexture,
			advancedSpaceWindowTexture,
			advancedSpaceBlockTexture,
			advancedSpacePart1Texture,
			advancedSpacePart2Texture,
			advancedSpacePart3Texture,
			advancedSpacePart4Texture,
			advancedSpaceFloorTexture,
			doorInvTexture,

			oilTexture,
			lianaTexture,

			branchWithoutTexture,
			branchALittle1Texture,
			branchALittle2Texture,
			branchFullTexture,

			// Still Items
			furnaceStoneOneTexture,
			maceratorOneTexture,
			furnaceElectricOneTexture,
			labelOneTexture,
			ashTexture,
			coalWoodTexture,
			snowTopTexture,

			// Bars
			barEatTexture,
			barWaterTexture,
			barOxygenTexture,
			barHeartTexture,

			// Textures blocks
			//rocks0Texture,
			//rocks1Texture,
			//rocks2Texture,
			//rocks3Texture,
			TextureDirt,
			gravelTexture,
			sandTexture,
			waterTexture,
			snowTexture,
			iceTexture,
			cobblestoneTexture,

			//GrassBlock
			TextureGrassBlockPlains,
			TextureGrassBlockHills,
			TextureGrassBlockForest,
			TextureGrassBlockDesert,
			TextureGrassBlockJungle,
			TextureGrassBlockClay,
			TextureGrassBlockCompost,
			TextureGrassBlockSnow,

			//CraftingBlocks
			bricksTexture,
			deskTexture,
			doorOpenTexture,
			doorCloseTexture,
			furnaceElectricTexture,
			furnaceStoneTexture,
			glassTexture,
			hayBlockTexture,
			labelTexture,
			ladderTexture,
			lampTexture,

			maceratorTexture,
			minerTexture,
			TextureMoon,
			radioTexture,

			solarPanelTexture,
			planksTexture,

			torchTexture,
			flagTexture,
			waterMillTexture,
			windMillTexture,

			// Plants
			plantAloreTexture,
			plantCarrotTexture,
			plantOnionTexture,
			plantPeasTexture,

			ItemPeasTexture,
			ItemCarrotTexture,

			blueberryPlantTexture,
			strawberryPlantTexture,
			rashberryPlantTexture,

			wheatTexture,

			cactusBigTexture,
			cactusLittleTexture,

			grassJungleTexture,
			grassDesertTexture,
			grassForestTexture,
			grassHillsTexture,
			grassPlainsTexture,

			plantVioletTexture,
			plantRoseTexture,
			plantOrchidTexture,
			plantDandelionTexture,

			torchInvTexture,
			clayTexture,



			// Animals
			fishTexture0,
			fishTexture1,

			// Animations
			destructionTexture,

			//Dusts
			ItemAluminiumDustTexture,
			ItemBronzeDustTexture,
			ItemCoalDustTexture,
			ItemCopperDustTexture,
			ItemGoldDustTexture,
			ItemIronDustTexture,
			ItemSilverDustTexture,
			ItemStoneDustTexture,
			ItemTinDustTexture,
			ItemWoodDustTexture,

			//Electronic
			ItemBatteryTexture,
			ItemBigCircuitTexture,
			ItemBulbTexture,
			ItemCircuitTexture,
			ItemRubberTexture,



		#region Ingots
			ItemAluminiumIngotTexture,
			ItemBronzeIngotTexture,
			ItemCopperIngotTexture,
			ItemGoldIngotTexture,
			ItemIronIngotTexture,
			ItemSilverIngotTexture,
			ItemTinIngotTexture,
		#endregion

			// MashinesBlocks
			ItemDoorTexture,
			ItemFlagTexture,
			ItemRocketTexture,
			ItemWaterMillTexture,
			ItemWindMillTexture,

			//Nature
			ItemHayTexture,
			ItemLeaveTexture,
			ItemSeedsTexture,
			ItemStickTexture,
			ItemSticksTexture,
			ItemWheatSeedsTexture,
			ItemWheatStrawTexture,

		#region Rocks
			ItemCoalTexture,
			ItemCopperTexture,
			ItemDiamondTexture,
			ItemAluminiumTexture,
			ItemGoldTexture,
			ItemIronTexture,
			ItemPlasticTexture,
			ItemRubyTexture,
			ItemSaphiriteTexture,
			ItemSilverTexture,
			ItemSmaragdTexture,
			ItemBigStoneTexture,
			ItemMediumStoneTexture,
			ItemSmallStoneTexture,
			ItemTinTexture,
		#endregion

			ItemBackpackTexture,
			ItemBucketTexture,
			ItemBucketWaterTexture,
			ItemRopeTexture;
		#endregion

		readonly float divider_zoom=1f/Setting.Zoom;
		const float divider_16=1f/16f;
		bool AchievementStoneAge,
			AchievementBronzeAge,
			AchievementIronAge,
			AchievementFutureAge;
		int weatherWindowWidth, weatherWindowHeight;
		
		float Temperature=float.NaN;
		const float DescaySpeed=0.001f;
		List<FallingLeave> FallingLeaves;

		int waveGrassIndex=-1;
		List<ParticleMess> Particles;
		BiomeData BiomePlayer;
		Rectangle Fullscreen;
		List<object> WavingPlants;
		BiomeData[] Biomes;
		Color ColorBiome, ColorLastBiome;
		int TicksPlayerChangedBiome;
		Biome BiomeCurrent;
		Color ColorNightColorBack;
		Color ColorNightColorBackRain;
		float ConstNightAlpha;
		const float dayStart=5.5f;
		const float dayEnd=17.5f;

		const int /*day, */daysInYear=365;
		int year;

		Vector2 Vector2_2;
		const float WalkingHandMaxAngle=0.4f;
		LiveObject[] LiveObjects;
		bool windRirectionRight;
		Effect EffectClouds;
	//	Texture2D TextureClouds;
		readonly List<(Color, float)> Gradient=new List<(Color, float)>{
			(Color.CornflowerBlue, 0),
		   // (new Color(40, 120, 229), 152/542f),
			(new Color((byte)103, (byte)160, (byte)209), 268/542f),
			(new Color((byte)197, (byte)203, (byte)209), 333/542f),
			(new Color((byte)235, (byte)197, (byte)156), 375/542f),
			(new Color((byte)255, (byte)186, (byte)64), 455/542f),
			(new Color((byte)255, (byte)75, (byte)37), 1f),
		};
		//Texture2D TextureSunGradient;

		readonly Color ColorNightRain=new Color((byte)218, (byte)227, (byte)235/*40,52,63*/);
		readonly Color ColorNight=new Color((byte)222, (byte)233, (byte)237/*27,171,236*/);

		readonly Color ColorDayRain=new Color((byte)233, (byte)238, (byte)243);//Color.Lerp(new Color(51,64,77), Color.WhiteSmoke, 0.5f);
		readonly Color ColorDay= FastMath.Lerp(new Color((byte)240, (byte)243, (byte)246), Color.White, 0.5f);//Color.Lerp(new Color(96,163,231), Color.White, 0.9f);

		readonly Color ColorSun=new Color((byte)246, (byte)241, (byte)229);//Color.Lerp(new Color(244,199,74), Color.White, 0.9f);
		readonly Color ColorSunRain=new Color((byte)242, (byte)239, (byte)230);// Color.Lerp(new Color(76,69,50), Color.WhiteSmoke, 0.5f);
		Color ColorDayRainBack=new Color((byte)114, (byte)176, (byte)214);
		float swimmingTicks;
	//	Texture2D TextureBarBarrel, pixel;
		FastRandom random;
		float handAngle;
		Color ColorLightBlue=Color.LightBlue;
		DInt startMovePos;
		const int HandSize=18;
		ItemInvBlank itemBlank;
		const int
			InventoryClothesSlotCap=0,
			InventoryClothesSlotTShirt=1,
			InventoryClothesSlotTrousers=2,
			InventoryClothesSlotShoes=3,
			InventoryClothesSlotCoat=4,
			InventoryClothesSlotBra=5,
			InventoryClothesSlotUnderwear=6,
			InventoryClothesSlotBackpack=7;

		Color ColorGray=Color.Gray;
		string mouseItemName;
		List<FallingBlockInfo> fallingBlocks;
		bool dontDoGame=true;
		int mouseItemId;
		int mouseItemNameWidth;
		bool showMouseItemWhileMooving;
		Text itemText;
		ItemInv mouseItem;

		const float acceleration=0.19f;
		float needSpeed, speed;
		int speedDir;
		bool keyLeft, keyRight;/*, run*/
		int animationInvBack=0;
		Color black=Color.Black;
		Vector2 Vector2Zero;
		Color colorAlpha;
		List<GunShot> GunShots;
		Color
			ColorWhite,
			ColorSmokeWhite=new Color((byte)240,(byte)240,(byte)240);

		bool mousePosChanged;
		bool cameraMove;
		const int
			InvMaxComposter=9,
			InvMaxBarrel=2,
			InvMaxShelf=9,
			InvMaxBoxWooden=24,
			InvMaxBoxAdv=4*12,
			InvMaxFurnaceStone=4,
			InvMaxMiner=12*2;
		//null null;
		bool changePosition, canbreatheDuringSwimming;
		bool DetectLava;

	//	Texture2D TextureEggDrop,TextureOxygenMachine, TextureAirTank, TextureAirTank2, TextureBarrel, TextureIngotSteel;
		Texture2D[] TextureEggDropE;
	//	Texture2D TextureItemEgg, TextureItemBoiledEgg, TextureWaterGraystyle, TextureChristmasStar;
	   // readonly int craftingScrollbarValue;
		bool easter;
		bool radioplaying=false;  
		bool creativeTabCrafting=true;
		float scrollBarCreative;
		Text textDie, textDieInfo, textRespawnIn, textOpenInventory, textChooseItemWindow;
		TextWithMeasure textWriting;
		GameButtonSmall ButtonCrafting, ButtonItems, ButtonSeal;
		//Texture2D TextureBin;
		bool fly;

		#region Items
		List<Item> DroppedItems;
		float itemAnimationPos2=3.1f;
		#endregion

		#region Blocks in lists
		List<ShortAndByte> FurnaceStone, Chargers, windable, Miners, Composters, bucketRubber, OxygenMachines/*, Barrels*/;
		List<int> chunksWithPlants;
		List<MashineBlockBasic> lightsLamp;
		List<Mob> movingAnimals;
		#endregion

		#region Player
		bool died=false;
		float timerStayDied;
		string diedInfo;

		bool rocket;
		bool swimming, waterDown;
		bool rocketDown;
	  static  float gravity;

		bool notNeedScafander;

		float PlayerX, PlayerY;
	 //   int intPlayerX, intPlayerY;

		int playerImg;
	//	int playerImg2=100;
		int playerState;
	   int distanceToGround=0;
		float gravitySpeed=0;
		bool playerLight=false;
		#endregion

		#region Clothes
		ClothesTypeUnderwearDown
			ClothesUnderwearDown,

			ClothesUnderpants,
			ClothesBoxerShorts,
			ClothesPanties,
			ClothesSwimsuit,
			ClothesBikiniDown;

		ClothesTypeUnderwearUp
			ClothesUnderwearUp,

			ClothesBra,
			ClothesBikiniTop;

		ClothesTypeBoots
			ClothesFeet,

			ClothesFormalShoes,
			ClothesPumps,
			ClothesSneakers,
			ClothesSpaceBoots;

		ClothesTypeTrousers
			ClothesLegs,

			ClothesJeans,
			ClothesShorts,
			ClothesSkirt,
			ClothesArmyTrousers,
			ClothesSpaceTrousers;

		ClothesTypeTShirt
			ClothesChest,

			ClothesTShirt,
			ClothesShirt,
			ClothesDress,
			ClothesTop;

		ClothesTypeCoat
			ClothesChestTop,

			ClothesCoatArmy,
			ClothesCoat,
			ClothesJacketDenim,
			ClothesJacketFormal,
			ClothesJacketShort,
			ClothesSpaceSuit;

		ClothesTypeHelmet
			ClothesHead,

			ClothesCap,
			ClothesHad,
			ClothesCrown,
			ClothesSpaceHelmet;
		#endregion
		Texture2D[] TextureRocks;
		#region Weather & time (day/night)
		float windForce;
		int dayLenght=4800;
		const int hour=200;
		readonly List<Rectangle> lightsFull=new List<Rectangle>();
		readonly List<Rectangle> lightsHalf=new List<Rectangle>();

		// Rain
		int rainDuration;
		int changeRain = 1250;
		List<ParticleRain> rainDots;
		List<ParticleSnow> snowDots;
		bool wind, rain;

		//Time
		int day, timeToChageWind, timer5=1000;
		int time;
		int _secondTimer=60;
		int timerDraw60=60;

		// Day / night
		float dayAlpha;
		float moonSpeed;
		#endregion

		#region Inventory
		ItemInv[] InventoryClothes, InventoryCreative, InventoryCrafting, InventoryNormal;

		CraftingRecipe[] CurrentDeskCrafting;
		int SelectedCraftingRecipe=-1;
		int PopUpWindowChoosingPotencialdItem;
		bool displayPopUpWindow;
		int PopUpWindowSelectedItem;
		GameScrollbar inventoryScrollbar, creativeScrollbar, craftingScrollbar;
		InventoryType lastMashineType;
		InventoryType inventory =InventoryType.Normal;
		Mobile.System mobileOS;
		string[] radioSongs;
		int inventoryScrollbarValue=0;
		int selectedCraftingItem;
		int inventoryScrollbarValueCrafting=0;
		int inventoryScrollbarValueCraftingMax=0;
		int boxSelected;

		bool mouseDrawItemTextInfo =false;
		bool invMove;

		int invStartId;

		ItemInv[] invStartInventory;

		bool leftMove;
		int maxInvCount;

		DInt selectedMashine;

		GeDo gedo;

		int diserpeard=255;
		string text="";

		bool hold;
		int timeHold;
		string lastKey;
		#endregion

		#region Buttons
		GameButtonSmall
			buttonRocket,
			buttonRadio,
			buttonNext,
			buttonPrev,
			buttonCraft1x,
			buttonCraft10x,
			buttonCraft100x,
			
			buttonContinue,
			buttonExit,
			buttonUseGiftCode,
			buttonAcheavements;

		ImgButton
			buttonClose,
			buttonClosePopUp,
			buttonInvTabBlocks,
			buttonInvTabPlants,
			buttonInvTabTools,
			buttonInvTabMashines,
			buttonInvTabItems,
			buttonInvTabCeramics,
			buttonInvTabFood,
			buttonInvTabGlass,
			buttonInvTabMaterials,
			buttonInvAnimals,

			buttonInvHead,
			buttonInvChest,
			buttonInvLegs,
			buttonInvShoes,
			buttonInvUnderwear;	
		#endregion

		#region Window
		Matrix camera, ZoomMatrix, Translation;

		float WindowXWithout, WindowYWithout,
			WindowCenterX, WindowCenterY,
			WindowX, WindowY;

		float WindowXPlayer, WindowYPlayer;

		RenderTarget2D sunLightTarget, modificatedLightTarget;

		readonly BlendState Multiply = new BlendState {
			AlphaSourceBlend=Blend.Zero,
			AlphaDestinationBlend=Blend.SourceColor,
			ColorSourceBlend=Blend.Zero,
			ColorDestinationBlend=Blend.SourceColor
		};

		int terrainStartIndexX, terrainStartIndexY, terrainStartIndexW, terrainStartIndexH;
		#endregion

		#region Mouse & keyboard
		public static bool mouseLeftPress,
			mouseLeftRelease,
			mouseLeftDown,

			mouseRightPress,
			mouseRightRelease,
			mouseRightDown;

		MouseState newMouseState, oldMouseState;
		KeyboardState oldKeyboardState, newKeyboardState;

		int previousScrollValue;

		Vector2 mousePos;
		int mousePosRoundX, mousePosRoundY;
		readonly DInt mousePosDiv16=new DInt();
		  //  mousePosRound=new DInt(),
		  //  mouseRealPos=new DInt();
	   public static int mouseRealPosX, mouseRealPosY;
		#endregion

		#region Bars
		float barWater = 16;
		float barEat = 16;
		float barOxygen=0;
		float barHeart=16;
		float barEnergy=0;
		#endregion

		#region Debug
		bool debug;
	 float fps;
		float fpss=0;
		PerformanceCounter cpu;
		PerformanceCounter ram;
		PerformanceCounter cpuUsage;
		PerformanceCounter freeRam;

		float usageCpuProcess;
		float usageCpu;
		float usageRamProcess;
		float usageRam;

		bool showInventory=true;
		bool showPlayer=true;
		#endregion

		#region World
		Terrain[] terrain;
		int TerrainLength;

		readonly string pathToWorld;
		string world;
  int autoSave=300;
		List<Energy> energy;
		#endregion

		#region Block destruction
		int destroyBlockX, destroyBlockY;

		float destroingIndex;
		float destringMaxIndex;

		bool destroing;

		BlockType destroingBlockDepth;
		ushort destroingBlockType;

		const int DistanceBlockEdit=200;
		#endregion

		#region Fonts
		//SpriteFont spriteFont_small,
		//    spriteFont_small_italic,
		//    spriteFont_medium;
		#endregion

		#region Colors
		readonly Color
			color_r200_g200_b200_a100= new Color((byte)200,(byte)200,(byte)200,(byte)100),
			color_r0_g0_b0_a200 = new Color((byte)0,(byte)0,(byte)0,(byte)200),
			color_r10_g140_b255 = new Color((byte)10,(byte)140,(byte)255),
			color_r128_g128_b128= new Color((byte)128,(byte)128,(byte)128),
			color_r128_g128_b128_a128= new Color((byte)128,(byte)128,(byte)128,(byte)128),
			color_r150_g150_b150= new Color((byte)150,(byte)150,(byte)150),
			color_r0_g0_b0_a100 = new Color((byte)0,(byte)0,(byte)0,(byte)100),
			color_r255_g0_b0_a100 = new Color((byte)255, (byte)0, (byte)0, (byte)100),
			color_r200_g200_b200=new Color((byte)200, (byte)200, (byte)200),
			lampColorLight=new Color((byte)255, (byte)255, (byte)220, (byte)255);
		#endregion

		#region Other
		int walkingSoundDuration;
	  //  Vector2 vector_x0_y4;
		#endregion
		#endregion

		public SinglePlayer(string dir) => pathToWorld=dir+"\\";

		public unsafe override void Init() {
			random=Rabcr.random;
			FallingLeaves=new List<FallingLeave>();
			Particles=new List<ParticleMess>();
			WavingPlants=new List<object>();
			Fullscreen=new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight);
			ConstNightAlpha=0.1f+0.4f*Setting.NightBrightness;
			Vector2_2=new Vector2(2,2);
			float m=0.5f+Setting.NightBrightness*0.5f;
			ColorNightColorBack=new Color(m, m, m);
			ColorNightColorBackRain=new Color(m, m, (int)(m*1.1f+0.5f));

			itemBlank=new ItemInvBlank();
			ColorWhite=Color.White;
			pixel=Rabcr. Pixel;
			Vector2Zero=Vector2.Zero;
			EffectClouds=Content.Load<Effect>(Setting.StyleName+"/Effects/Clouds");
			if (File.Exists(pathToWorld+"LastWorld.txt")) world=File.ReadAllText(pathToWorld+"LastWorld.txt");

			if (string.IsNullOrEmpty(world)) world="Earth";

			if (File.Exists(pathToWorld+"UseRocket.txt")) {
				rocket=true;
				rocketDown=true;
			}
			fallingBlocks=new List<FallingBlockInfo>();
			GunShots=new List<GunShot>();
			CountGravity(new GeneratePlanetSystem().SunSystem());

			easter=IsEaster();
	
			#region Load textures
			TextureTestTube=GetDataTexture(@"Items\Dye\TestTube");

			TextureChristmasBall=GetDataTexture(@"Items/Decorations/CristmasBalls/ChristmasBall");
			TextureChristmasBallYellow=GetDataTexture(@"Items/Decorations/CristmasBalls/ChristmasBallYellow"); 
			TextureChristmasBallOrange=GetDataTexture(@"Items/Decorations/CristmasBalls/ChristmasBallOrange"); 
			TextureChristmasBallRed=GetDataTexture(@"Items/Decorations/CristmasBalls/ChristmasBallRed"); 
			TextureChristmasBallPurple=GetDataTexture(@"Items/Decorations/CristmasBalls/ChristmasBallPurple");
			TextureChristmasBallPink=GetDataTexture(@"Items/Decorations/CristmasBalls/ChristmasBallPink");
			TextureChristmasBallLightGreen=GetDataTexture(@"Items/Decorations/CristmasBalls/ChristmasBallLightGreen");
			TextureChristmasBallBlue=GetDataTexture(@"Items/Decorations/CristmasBalls/ChristmasBallBlue");
			TextureChristmasBallTeal=GetDataTexture(@"Items/Decorations/CristmasBalls/ChristmasBallTeal");

			TextureAngelHair=GetDataTexture(@"Items/Decorations/AngelHair");
			TextureAngelHairWithSpruceLeaves=GetDataTexture(@"Blocks/TreeBlocks/Spruce/AngelHair");
			
			TextureChristmasBallGrayWithLeaves=GetDataTexture(@"Blocks/TreeBlocks/Spruce/ChristmasBalls/Gray"); 
			TextureChristmasBallYellowWithLeaves=GetDataTexture(@"Blocks/TreeBlocks/Spruce/ChristmasBalls/Yellow"); 
			TextureChristmasBallOrangeWithLeaves=GetDataTexture(@"Blocks/TreeBlocks/Spruce/ChristmasBalls/Orange"); 
			TextureChristmasBallRedWithLeaves=GetDataTexture(@"Blocks/TreeBlocks/Spruce/ChristmasBalls/Red"); 
			TextureChristmasBallPurpleWithLeaves=GetDataTexture(@"Blocks/TreeBlocks/Spruce/ChristmasBalls/Purple");
			TextureChristmasBallPinkWithLeaves=GetDataTexture(@"Blocks/TreeBlocks/Spruce/ChristmasBalls/Pink");
			TextureChristmasBallLightGreenWithLeaves=GetDataTexture(@"Blocks/TreeBlocks/Spruce/ChristmasBalls/LightGreen");
			TextureChristmasBallBlueWithLeaves=GetDataTexture(@"Blocks/TreeBlocks/Spruce/ChristmasBalls/Blue");
			TextureChristmasBallTealWithLeaves=GetDataTexture(@"Blocks/TreeBlocks/Spruce/ChristmasBalls/Teal");

			TextureParrotStill=GetDataTexture(@"Animals/Parrot/Still");
			TextureParrotFly=GetDataTexture(@"Animals/Parrot/Flying");

			CreateGradientTexture();
		
			#region Imventory
			TextureBin=GetDataTexture("Inventories/bin");
			TextureSelectCrafting=GetDataTexture("Buttons/Other/SelectyCrafting");

			inventoryNeedTexture=GetDataTexture("Inventories/InventoryNeed");
			inventorySlotTexture=GetDataTexture("Inventories/Slot");
			inventorySlotInTexture=GetDataTexture("Inventories/SlotIn");
			inventorySlotOutTexture=GetDataTexture("Inventories/SlotOut");

			TextureInventoryClothes=GetDataTexture("Inventories/InventoryClothes");
			TextureBarBarrel=GetDataTexture("Inventories/BarBarrel");
			#endregion
			TextureClouds=GetDataTexture("Animations\\Clouds");
			#region Items
			#region Tools
			// Axe
			TextureAxeStone = GetDataTexture("Items/Tools/Axe/AxeStone");
			TextureAxeCopper = GetDataTexture("Items/Tools/Axe/AxeCopper");
			TextureAxeBronze = GetDataTexture("Items/Tools/Axe/AxeBronze");
			TextureAxeGold = GetDataTexture("Items/Tools/Axe/AxeGold");
			TextureAxeIron = GetDataTexture("Items/Tools/Axe/AxeIron");
			TextureAxeSteel = GetDataTexture("Items/Tools/Axe/AxeSteel");
			TextureAxeAluminium = GetDataTexture("Items/Tools/Axe/AxeAluminium");

			// Pickaxe
			TexturePickaxeStone = GetDataTexture("Items/Tools/Pickaxe/PickaxeStone");
			TexturePickaxeCopper = GetDataTexture("Items/Tools/Pickaxe/PickaxeCopper");
			TexturePickaxeBronze = GetDataTexture("Items/Tools/Pickaxe/PickaxeBronze");
			TexturePickaxeGold = GetDataTexture("Items/Tools/Pickaxe/PickaxeGold");
			TexturePickaxeIron = GetDataTexture("Items/Tools/Pickaxe/PickaxeIron");
			TexturePickaxeSteel = GetDataTexture("Items/Tools/Pickaxe/PickaxeSteel");
			TexturePickaxeAluminium = GetDataTexture("Items/Tools/Pickaxe/PickaxeAluminium");

			// Shovel
			TextureShovelStone = GetDataTexture("Items/Tools/Shovel/ShovelStone");
			TextureShovelBronze = GetDataTexture("Items/Tools/Shovel/ShovelBronze");
			TextureShovelCopper = GetDataTexture("Items/Tools/Shovel/ShovelCopper");
			TextureShovelGold = GetDataTexture("Items/Tools/Shovel/ShovelGold");
			TextureShovelIron = GetDataTexture("Items/Tools/Shovel/ShovelIron");
			TextureShovelSteel = GetDataTexture("Items/Tools/Shovel/ShovelSteel");
			TextureShovelAluminium = GetDataTexture("Items/Tools/Shovel/ShovelAluminium");

			//Hoe
			TextureHoeStone=GetDataTexture("Items/Tools/Hoe/StoneHoe");
			TextureHoeCopper=GetDataTexture("Items/Tools/Hoe/CopperHoe");
			TextureHoeBronze=GetDataTexture("Items/Tools/Hoe/BronzeHoe");
			TextureHoeGold=GetDataTexture("Items/Tools/Hoe/GoldHoe");
			TextureHoeIron=GetDataTexture("Items/Tools/Hoe/IronHoe");
			TextureHoeSteel=GetDataTexture("Items/Tools/Hoe/SteelHoe");
			TextureHoeAluminium=GetDataTexture("Items/Tools/Hoe/AluminiumHoe");

			// Saw
			TextureSawCopper=GetDataTexture("Items/Tools/Saw/SawCopper");
			TextureSawBronze=GetDataTexture("Items/Tools/Saw/SawBronze");
			TextureSawGold=GetDataTexture("Items/Tools/Saw/SawGold");
			TextureSawIron=GetDataTexture("Items/Tools/Saw/SawIron");
			TextureSawSteel=GetDataTexture("Items/Tools/Saw/SawSteel");
			TextureSawAluminium=GetDataTexture("Items/Tools/Saw/SawAluminium");

			// Shears
			TextureShearsCopper=GetDataTexture("Items/Tools/Shears/ShearsCopper");
			TextureShearsBronze=GetDataTexture("Items/Tools/Shears/ShearsBronze");
			TextureShearsGold=GetDataTexture("Items/Tools/Shears/ShearsGold");
			TextureShearsIron=GetDataTexture("Items/Tools/Shears/ShearsIron");
			TextureShearsSteel=GetDataTexture("Items/Tools/Shears/ShearsSteel");
			TextureShearsAluminium=GetDataTexture("Items/Tools/Shears/ShearsAluminium");

			// Hammer
			TextureHammerCopper=GetDataTexture("Items/Tools/Hammer/HammerCopper");
			TextureHammerBronze=GetDataTexture("Items/Tools/Hammer/HammerBronze");
			TextureHammerGold=GetDataTexture("Items/Tools/Hammer/HammerGold");
			TextureHammerIron=GetDataTexture("Items/Tools/Hammer/HammerIron");
			TextureHammerSteel=GetDataTexture("Items/Tools/Hammer/HammerSteel");
			TextureHammerAluminium=GetDataTexture("Items/Tools/Hammer/HammerAluminium");

			// Knife
			//TextureKnifeStone = GetDataTexture("Items/Tools/Knife/KnifeStone");
			TextureKnifeCopper = GetDataTexture("Items/Tools/Knife/KnifeCopper");
			TextureKnifeBronze = GetDataTexture("Items/Tools/Knife/KnifeBronze");
			TextureKnifeGold = GetDataTexture("Items/Tools/Knife/KnifeGold");
			TextureKnifeIron = GetDataTexture("Items/Tools/Knife/KnifeIron");
			TextureKnifeSteel = GetDataTexture("Items/Tools/Knife/KnifeSteel");
			TextureKnifeAluminium = GetDataTexture("Items/Tools/Knife/KnifeAluminium");

			// Electronics
			TextureTorchOff=GetDataTexture("Blocks/ForInventory/TorchOFF");
			LightElectricTexture=GetDataTexture("Items/Tools/Electric/Light");
			TextureDrillElectric=GetDataTexture("Items/Tools/Electric/Drill");
			electricSawTexture=GetDataTexture("Items/Tools/Electric/Saw");
			mobileTexture=GetDataTexture("Items/NonTools/mobile");

			// Air tank
			TextureAirTank=GetDataTexture("Items/NonTools/OxygenTank");
			TextureAirTank2=GetDataTexture("Items/NonTools/OxygenTank2");

			// Gun
			TextureAmmo = GetDataTexture("Items/NonTools/Ammo");
			TextureGun = GetDataTexture("Items/NonTools/Gun");

			// Other
			stoneHeadTexture = GetDataTexture("Items/Tools/StoneAxe");
			#endregion

			#region Tool heads
			// Axe
			TextureAxeHeadCopper = GetDataTexture("Items/ToolsHeads/Axe/Copper");
			TextureAxeHeadBronze = GetDataTexture("Items/ToolsHeads/Axe/Bronze");
			TextureAxeHeadGold = GetDataTexture("Items/ToolsHeads/Axe/Gold");
			TextureAxeHeadIron = GetDataTexture("Items/ToolsHeads/Axe/Iron");
			TextureAxeHeadSteel = GetDataTexture("Items/ToolsHeads/Axe/Steel");
			TextureAxeHeadAluminium = GetDataTexture("Items/ToolsHeads/Axe/Aluminium");

			// Shovel
			TextureShovelHeadCopper = GetDataTexture("Items/ToolsHeads/Shovel/Copper");
			TextureShovelHeadBronze = GetDataTexture("Items/ToolsHeads/Shovel/Bronze");
			TextureShovelHeadGold = GetDataTexture("Items/ToolsHeads/Shovel/Gold");
			TextureShovelHeadIron = GetDataTexture("Items/ToolsHeads/Shovel/Iron");
			TextureShovelHeadSteel = GetDataTexture("Items/ToolsHeads/Shovel/Steel");
			TextureShovelHeadAluminium = GetDataTexture("Items/ToolsHeads/Shovel/Aluminium");

			// Pickaxe
			TexturePickaxeHeadCopper= GetDataTexture("Items/ToolsHeads/Pickaxe/Copper");
			TexturePickaxeHeadBronze= GetDataTexture("Items/ToolsHeads/Pickaxe/Bronze");
			TexturePickaxeHeadGold= GetDataTexture("Items/ToolsHeads/Pickaxe/Gold");
			TexturePickaxeHeadIron= GetDataTexture("Items/ToolsHeads/Pickaxe/Iron");
			TexturePickaxeHeadSteel= GetDataTexture("Items/ToolsHeads/Pickaxe/Steel");
			TexturePickaxeHeadAluminium= GetDataTexture("Items/ToolsHeads/Pickaxe/Aluminium");

			// Shears
			TextureShearsHeadCopper= GetDataTexture("Items/ToolsHeads/Shears/Copper");
			TextureShearsHeadBronze= GetDataTexture("Items/ToolsHeads/Shears/Bronze");
			TextureShearsHeadGold= GetDataTexture("Items/ToolsHeads/Shears/Gold");
			TextureShearsHeadIron= GetDataTexture("Items/ToolsHeads/Shears/Iron");
			TextureShearsHeadSteel= GetDataTexture("Items/ToolsHeads/Shears/Steel");
			TextureShearsHeadAluminium= GetDataTexture("Items/ToolsHeads/Shears/Aluminium");

			// Knife
			TextureKnifeHeadCopper= GetDataTexture("Items/ToolsHeads/Knife/Copper");
			TextureKnifeHeadBronze= GetDataTexture("Items/ToolsHeads/Knife/Bronze");
			TextureKnifeHeadGold= GetDataTexture("Items/ToolsHeads/Knife/Gold");
			TextureKnifeHeadIron= GetDataTexture("Items/ToolsHeads/Knife/Iron");
			TextureKnifeHeadSteel= GetDataTexture("Items/ToolsHeads/Knife/Steel");
			TextureKnifeHeadAluminium= GetDataTexture("Items/ToolsHeads/Knife/Aluminium");

			// Hoe
			TextureHoeHeadCopper=GetDataTexture("Items/ToolsHeads/Hoe/Copper");
			TextureHoeHeadBronze=GetDataTexture("Items/ToolsHeads/Hoe/Bronze");
			TextureHoeHeadGold=GetDataTexture("Items/ToolsHeads/Hoe/Gold");
			TextureHoeHeadIron=GetDataTexture("Items/ToolsHeads/Hoe/Iron");
			TextureHoeHeadSteel=GetDataTexture("Items/ToolsHeads/Hoe/Steel");
			TextureHoeHeadAluminium=GetDataTexture("Items/ToolsHeads/Hoe/Aluminium");
			#endregion

			#region Clothes
			// Head
			TextureItemCap=GetDataTexture("Items/Clothes/Head/Cap");
			TextureItemHat=GetDataTexture("Items/Clothes/Head/Hat");
			TextureItemCrown=GetDataTexture("Items/Clothes/Head/Crown");
			TextureItemSpaceHelmet=GetDataTexture("Items/Clothes/Head/SpaceHelmet");

			// Feet
			TextureItemFormalShoes=GetDataTexture("Items/Clothes/Feet/FormalShoes");
			TextureItemPumps=GetDataTexture("Items/Clothes/Feet/Pumps");
			TextureItemSneakers=GetDataTexture("Items/Clothes/Feet/Sneakers");
			TextureItemSpaceBoots=GetDataTexture("Items/Clothes/Feet/SpaceBoots");

			// Chest top
			TextureItemCoatArmy=GetDataTexture("Items/Clothes/ChestTop/CoatArmy");
			TextureItemCoat=GetDataTexture("Items/Clothes/ChestTop/Coat");
			ItemJacketDenimTexture=GetDataTexture("Items/Clothes/ChestTop/JacketDenim");
			ItemJacketFormalTexture=GetDataTexture("Items/Clothes/ChestTop/JacketFormal");
			TextureItemJacketShort=GetDataTexture("Items/Clothes/ChestTop/JacketShort");

			// Legs
			TextureItemJeans=GetDataTexture("Items/Clothes/Legs/Jeans");
			TextureItemShorts=GetDataTexture("Items/Clothes/Legs/Shorts");
			TextureItemSpaceTrousers=GetDataTexture("Items/Clothes/Legs/SpaceTrousers");
			TextureItemArmyTrousers=GetDataTexture("Items/Clothes/Legs/ArmyTrousers");
			TextureItemSkirt=GetDataTexture("Items/Clothes/Legs/Skirt");
			TextureItemTShirt=GetDataTexture("Items/Clothes/Chest/TShirt");
			TextureItemSpaceSuit=GetDataTexture("Items/Clothes/ChestTop/SpaceSuit");
			TextureItemDress=GetDataTexture("Items/Clothes/Chest/Dress");
			TextureItemShirt=GetDataTexture("Items/Clothes/Chest/Shirt");

			// Underwear Down
			TextureItemUnderpants=GetDataTexture("Items/Clothes/DownUnderwear/Underpants");
			TextureItemBoxerShorts=GetDataTexture("Items/Clothes/DownUnderwear/BoxerShorts");
			TextureItemPanties=GetDataTexture("Items/Clothes/DownUnderwear/Panties");
			TextureItemSwimsuit=GetDataTexture("Items/Clothes/DownUnderwear/Swimsuit");
			TextureItemBikiniDown=GetDataTexture("Items/Clothes/DownUnderwear/Bikini");

			// Underwear Up
			TextureItemBra=GetDataTexture("Items/Clothes/UpUnderwear/Bra");
			TextureItemBikiniTop=GetDataTexture("Items/Clothes/UpUnderwear/TopBikini");

			#endregion

			#region Electronics
			condenserTexture=GetDataTexture("Items/Electronic/Condenser");
			diodeTexture=GetDataTexture("Items/Electronic/Diode");
			tranzistorTexture=GetDataTexture("Items/Electronic/Transistor");
			resistanceTexture=GetDataTexture("Items/Electronic/Resistance");
			motorTexture=GetDataTexture("Items/Electronic/Motor");
			ItemBatteryTexture = GetDataTexture("Items/Electronic/Battery");
			ItemBigCircuitTexture = GetDataTexture("Items/Electronic/BigCircuit");
			ItemBulbTexture = GetDataTexture("Items/Electronic/Bulb");
			ItemCircuitTexture = GetDataTexture("Items/Electronic/Circuit");
			bareLabelTexture=GetDataTexture("Items/Electronic/label");
			#endregion

			#region Nature
			// From plants
			flaxSeedsTexture=GetDataTexture("Items/Nature/FlaxSeeds");
			ItemHayTexture = GetDataTexture("Items/Nature/Hay");
			ItemLeaveTexture = GetDataTexture("Items/Nature/Leave");
			ItemSeedsTexture = GetDataTexture("Items/Nature/Seeds");
			ItemStickTexture = GetDataTexture("Items/Nature/Stick");
			ItemSticksTexture = GetDataTexture("Items/Nature/Sticks");
			ItemWheatSeedsTexture = GetDataTexture("Items/Nature/WheatSeeds");
			ItemWheatStrawTexture = GetDataTexture("Items/Nature/WheatStraw");
			ItemKapokFibreTexture=GetDataTexture("Items/Nature/KapokFibre");

			// Crafted
			clothTexture=GetDataTexture("Items/Nature/Cloth");
			yarnTexture=GetDataTexture("Items/Nature/Yarn");
			TextureResin=GetDataTexture("Items/Nature/Resin");
			#endregion

			#region Rocks
			ItemAluminiumTexture = GetDataTexture("Items/Rocks/Aluminium");
			ItemCoalTexture = GetDataTexture("Items/Rocks/Coal");
			ItemCopperTexture = GetDataTexture("Items/Rocks/Copper");
			ItemDiamondTexture = GetDataTexture("Items/Rocks/Diamond");
			ItemGoldTexture = GetDataTexture("Items/Rocks/Gold");
			ItemIronTexture = GetDataTexture("Items/Rocks/Iron");
			ItemPlasticTexture= GetDataTexture("Items/Rocks/Plastic");
			ItemRubyTexture = GetDataTexture("Items/Rocks/Ruby");
			ItemSaphiriteTexture = GetDataTexture("Items/Rocks/Saphirite");
			ItemSilverTexture = GetDataTexture("Items/Rocks/Silver");
			ItemSmaragdTexture = GetDataTexture("Items/Rocks/Smaragd");
			ItemBigStoneTexture = GetDataTexture("Items/Rocks/StoneBig");
			ItemMediumStoneTexture = GetDataTexture("Items/Rocks/StoneMedium");
			ItemSmallStoneTexture = GetDataTexture("Items/Rocks/StoneSmall");
			ItemTinTexture = GetDataTexture("Items/Rocks/Tin");
			#endregion

			#region Dye
			TextureDyeWhite= GetDataTexture("Items/Dye/White");
			TextureDyeYellow = GetDataTexture("Items/Dye/Yellow");
			TextureDyeGold = GetDataTexture("Items/Dye/Gold");
			TextureDyeOrange = GetDataTexture("Items/Dye/Orange");
			TextureDyeRed = GetDataTexture("Items/Dye/Red");
			TextureDyeDarkRed = GetDataTexture("Items/Dye/DarkRed");
			TextureDyePink = GetDataTexture("Items/Dye/Pink");
			TextureDyePurple = GetDataTexture("Items/Dye/Purple");
			TextureDyeLightBlue = GetDataTexture("Items/Dye/LightBlue");
			TextureDyeBlue = GetDataTexture("Items/Dye/Blue");
			TextureDyeDarkBlue = GetDataTexture("Items/Dye/DarkBlue");
			TextureDyeTeal = GetDataTexture("Items/Dye/Teal");
			TextureDyeLightGreen = GetDataTexture("Items/Dye/LightGreen");
			TextureDyeGreen = GetDataTexture("Items/Dye/Green");
			TextureDyeDarkGreen = GetDataTexture("Items/Dye/DarkGreen");
			TextureDyeBrown = GetDataTexture("Items/Dye/Brown");
			TextureDyeLightGray = GetDataTexture("Items/Dye/LightGray");
			TextureDyeGray = GetDataTexture("Items/Dye/Gray");
			TextureDyeDarkGray = GetDataTexture("Items/Dye/DarkGray");
			TextureDyeBlack = GetDataTexture("Items/Dye/Black");
			TextureDyeArmy = GetDataTexture("Items/Dye/Army");
			TextureDyeMagenta = GetDataTexture("Items/Dye/Magenta");
			TextureDyeRoseQuartz = GetDataTexture("Items/Dye/RoseQuartz");
			TextureDyeSpringGreen = GetDataTexture("Items/Dye/SpringGreen");
			TextureDyeViolet = GetDataTexture("Items/Dye/Violet");
			TextureDyeOlive = GetDataTexture("Items/Dye/Olive");
			#endregion

			#region Food
			// Raw vegetable
			ItemPeasTexture=GetDataTexture("Items/Food/Peas");
			ItemCarrotTexture=GetDataTexture("Items/Food/Carrot");

			// Raw fruit
			ItemOrangeTexture=GetDataTexture("Items/Food/Orange");
			ItemLemonTexture=GetDataTexture("Items/Food/Lemon");
			ItemOliveTexture=GetDataTexture("Items/Food/Olive");
			ItemAppleTexture = GetDataTexture("Items/Food/Apple");
			ItemBananaTexture = GetDataTexture("Items/Food/Banana");
			ItemCherryTexture = GetDataTexture("Items/Food/Cherry");
			ItemOnionTexture = GetDataTexture("Items/Food/Onion");
			ItemPlumTexture = GetDataTexture("Items/Food/Plum");
			rashberryTexture = GetDataTexture("Items/Food/Rashberry");
			blueberryTexture=GetDataTexture("Items/Food/Blueberry");
			strawberryTexture = GetDataTexture("Items/Food/Strawberry");

			// Raw other
			TextureItemEgg=GetDataTexture("Items/Food/egg");
			ItemRabbitMeatTexture = GetDataTexture("Items/Food/RabbitMeat");

			// Boiled
			TextureItemBoiledEgg=GetDataTexture("Items/Food/eggboiled");
			fishCookedTexture=GetDataTexture("Items/Food/FishCooked");
			ItemRabbtCookedMeatTexture = GetDataTexture("Items/Food/RabbitCookedMeat");

			// Combined
			bowlMushroomsTexture=GetDataTexture("Items/Food/BowlWithMushrooms");
			bowlVegetablesTexture=GetDataTexture("Items/Food/BowlWithVegetable");
			#endregion

			#region Other
			RodTexture=GetDataTexture("Items/NonTools/Rod");
			nailTexture=GetDataTexture("Items/NonTools/Nail");
			plateCopperTexture=GetDataTexture("Items/Plates/PlateCopper");
			plateIronTexture=GetDataTexture("Items/Plates/PlateIron");
			plateBronzeTexture=GetDataTexture("Items/Plates/PlateBronze");
			plateAluminiumTexture=GetDataTexture("Items/Plates/PlateAluminium");
			plateGoldTexture=GetDataTexture("Items/Plates/PlateGold");
			#endregion



			bottleWaterTexture=GetDataTexture("Items/NonTools/BottleWater");
			bottleEmptyTexture=GetDataTexture("Items/NonTools/BottleEmpty");
			bottleOilTexture=GetDataTexture("Items/NonTools/BottleOil");
			bucketOilTexture=GetDataTexture("Items/NonTools/BucketOil");

			coalWoodTexture = GetDataTexture("Items/Rocks/CoalWood");
			ItemBackpackTexture = GetDataTexture("Items/Clothes/Backpack");
			ItemBucketTexture = GetDataTexture("Items/NonTools/Bucket");
			ItemBucketWaterTexture = GetDataTexture("Items/NonTools/BucketWater");
			ItemRopeTexture = GetDataTexture("Items/NonTools/Rope");

			#region Ingots
			ItemAluminiumIngotTexture= GetDataTexture("Items/Ingots/Aluminium");
			ItemBronzeIngotTexture = GetDataTexture("Items/Ingots/Bronze");
			ItemCopperIngotTexture = GetDataTexture("Items/Ingots/Copper");
			ItemGoldIngotTexture = GetDataTexture("Items/Ingots/Gold");
			ItemIronIngotTexture = GetDataTexture("Items/Ingots/Iron");
			ItemSilverIngotTexture = GetDataTexture("Items/Ingots/Silver");
			ItemTinIngotTexture = GetDataTexture("Items/Ingots/Tin");
			TextureIngotSteel=GetDataTexture("Items/Ingots/Steel");

			siliciumTexture=GetDataTexture("Items/Ingots/Silicium");

			oneBrickTexture=GetDataTexture("Items/Ingots/Brick");
			oneMudBrickTexture=GetDataTexture("Items/Ingots/Mud");
			#endregion

			#region Dusts
			// Metal
			ItemCopperDustTexture = GetDataTexture("Items/Dusts/Copper");
			ItemTinDustTexture = GetDataTexture("Items/Dusts/Tin");
			ItemBronzeDustTexture = GetDataTexture("Items/Dusts/Bronze");
			ItemGoldDustTexture = GetDataTexture("Items/Dusts/Gold");
			ItemSilverDustTexture = GetDataTexture("Items/Dusts/Silver");
			ItemIronDustTexture = GetDataTexture("Items/Dusts/Iron");
			ItemAluminiumDustTexture= GetDataTexture("Items/Dusts/Aluminium");

			// Other
			ItemCoalDustTexture = GetDataTexture("Items/Dusts/Coal");
			ItemStoneDustTexture = GetDataTexture("Items/Dusts/Stone");
			ItemWoodDustTexture = GetDataTexture("Items/Dusts/Wood");
			ashTexture= GetDataTexture("Items/Dusts/Ash");
			TextureSulfur = GetDataTexture("Items/Dusts/Sulfur");
			TextureSaltpeter = GetDataTexture("Items/Dusts/Saltpeter");
			TextureGunpowder = GetDataTexture("Items/Dusts/Gunpowder");
			#endregion

			ItemRubberTexture = GetDataTexture("Items/Electronic/Rubber");
			bowlEmptyTexture=GetDataTexture("Items/NonTools/Bowl");
			#endregion

			#region Blocks
			#region Mashines
			// Mechanical
			ComposterTexture=GetDataTexture("Blocks/Mashines/Composter");
			TextureBucketForRubber=GetDataTexture("Blocks/Mashines/BucketForRubber");
			TextureBucketWithLatex=GetDataTexture("Blocks/Mashines/BucketWithLatex");
			ComposterFullTexture=GetDataTexture("Blocks/Mashines/ComposterFull");
			shelfTexture=GetDataTexture("Blocks/Mashines/shelf");
			boxAdvTexture=GetDataTexture("Blocks/Mashines/box");
			boxWoodenTexture=GetDataTexture("Blocks/Mashines/boxWooden");
			deskTexture = GetDataTexture("Blocks/Mashines/Desk");
			doorOpenTexture = GetDataTexture("Blocks/Mashines/DoorOpen");
			doorCloseTexture = GetDataTexture("Blocks/Mashines/DoorClose");
			furnaceStoneTexture = GetDataTexture("Blocks/Mashines/FurnaceStone");
			torchTexture = GetDataTexture("Blocks/Mashines/Torch");
			TextureBarrel = GetDataTexture("Blocks/Mashines/Barrel");

			// Electrinics
			TextureOxygenMachine=GetDataTexture("Blocks/Mashines/OxygenMachine");
			chargerTexture=GetDataTexture("Blocks/Mashines/Charger");
			rocketTexture=GetDataTexture("Space/Rocket");
			radioTexture = GetDataTexture("Blocks/Mashines/Radio");
			maceratorTexture = GetDataTexture("Blocks/Mashines/Macerator");
			minerTexture = GetDataTexture("Blocks/Mashines/Miner");
			lampTexture = GetDataTexture("Blocks/Mashines/Lamp");
			solarPanelTexture = GetDataTexture("Blocks/Mashines/SolarPanel");
			labelTexture = GetDataTexture("Blocks/Mashines/Label");
			furnaceElectricTexture = GetDataTexture("Blocks/Mashines/FurnaceElectric");
			waterMillTexture = GetDataTexture("Blocks/Mashines/Watermill");
			windMillTexture = GetDataTexture("Blocks/Mashines/Windmill");
			sewingMachineTexture=GetDataTexture("Blocks/Mashines/SewingMachine");
			#endregion

			#region Trees
			TextureBranches = GetDataTexture("Blocks/TreeBlocks/Branches");
			// Oak
			TextureOakWood = GetDataTexture("Blocks/TreeBlocks/Oak/Wood");
			TextureOakLeaves = GetDataTexture("Blocks/TreeBlocks/Oak/Leaves");

			// Spruce
			spruceWoodTexture = GetDataTexture("Blocks/TreeBlocks/Spruce/Wood");
			spruceLeavesTexture = GetDataTexture("Blocks/TreeBlocks/Spruce/Leaves");

			// Linden
			TextureLindenWood = GetDataTexture("Blocks/TreeBlocks/Linden/Wood");
			TextureLindenLeaves = GetDataTexture("Blocks/TreeBlocks/Linden/Leaves");

			// Pine
			pineLeavesTexture = GetDataTexture("Blocks/TreeBlocks/Pine/Leaves");
			pineWoodTexture = GetDataTexture("Blocks/TreeBlocks/Pine/Wood");

			// Apple
			TextureAppleWood = GetDataTexture("Blocks/TreeBlocks/Apple/Wood");
			TextureAppleLeaves = GetDataTexture("Blocks/TreeBlocks/Apple/Leaves");
			TextureAppleBlossom = GetDataTexture("Blocks/TreeBlocks/Apple/Blossom");
			TextureAppleLeavesWithApples = GetDataTexture("Blocks/TreeBlocks/Apple/LeavesWithApples");

			// Cherry
			cherryWoodTexture = GetDataTexture("Blocks/TreeBlocks/Cherry/Wood");
			TextureCherryLeaves = GetDataTexture("Blocks/TreeBlocks/Cherry/Leaves");
			TextureCherryBlossom = GetDataTexture("Blocks/TreeBlocks/Cherry/Blossom");
			TextureCherryLeavesWithCherries = GetDataTexture("Blocks/TreeBlocks/Cherry/LeavesWithCherries");

			// Plum
			TexturePlumWood = GetDataTexture("Blocks/TreeBlocks/Plum/Wood");
			TexturePlumLeaves = GetDataTexture("Blocks/TreeBlocks/Plum/Leaves");
			TexturePlumBlossom = GetDataTexture("Blocks/TreeBlocks/Plum/Blossom");
			TexturePlumLeavesWithPlums = GetDataTexture("Blocks/TreeBlocks/Plum/LeavesWithPlums");

			// Orange
			TextureOrangeLeaves=GetDataTexture("Blocks/TreeBlocks/Orange/Leaves");
			TextureOrangeLeavesWithOranges=GetDataTexture("Blocks/TreeBlocks/Orange/LeavesWithOranges");
			TextureOrangeWood=GetDataTexture("Blocks/TreeBlocks/Orange/Wood");

			// Lemon
			TextureLemonWood=GetDataTexture("Blocks/TreeBlocks/Lemon/Wood");
			TextureLemonLeaves=GetDataTexture("Blocks/TreeBlocks/Lemon/Leaves");
			lemonLeavesWithLemonsTexture=GetDataTexture("Blocks/TreeBlocks/Lemon/LeavesWithLemons");

			// Olive
			TextureOliveLeavesWithOlives=GetDataTexture("Blocks/TreeBlocks/Olive/LeavesWithOlives");
			TextureOliveLeaves=GetDataTexture("Blocks/TreeBlocks/Olive/Leaves");
			TextureOliveWood=GetDataTexture("Blocks/TreeBlocks/Olive/Wood");

			// Mangrove
			TextureMangroveLeaves=GetDataTexture("Blocks/TreeBlocks/Mangrove/Leaves");
			TextureMangroveWood=GetDataTexture("Blocks/TreeBlocks/Mangrove/Wood");

			// Willow
			TextureWillowLeaves=GetDataTexture("Blocks/TreeBlocks/Willow/Leaves");
			TextureWillowWood=GetDataTexture("Blocks/TreeBlocks/Willow/Wood");

			// Eucaliptus
			TextureEucalyptusLeaves=GetDataTexture("Blocks/TreeBlocks/Eucalyptus/Leaves");
			TextureEucalyptusWood=GetDataTexture("Blocks/TreeBlocks/Eucalyptus/Wood");

			// Rubber
			TextureRubberTreeLeaves=GetDataTexture("Blocks/TreeBlocks/RubberTree/Leaves");
			TextureRubberTreeWood=GetDataTexture("Blocks/TreeBlocks/RubberTree/Wood");

			// Accacia
			TextureAcaciaLeaves=GetDataTexture("Blocks/TreeBlocks/Acacia/Leaves");
			TextureAcaciaWood=GetDataTexture("Blocks/TreeBlocks/Acacia/Wood");

			// Kapok
			TextureKapokBlossom=GetDataTexture("Blocks/TreeBlocks/Kapok/Blossom");
			TextureKapokLeavesFibre=GetDataTexture("Blocks/TreeBlocks/Kapok/LeavesWithFibre");
			TextureKapokLeaves=GetDataTexture("Blocks/TreeBlocks/Kapok/Leaves");
			TextureKapokWood=GetDataTexture("Blocks/TreeBlocks/Kapok/Wood");
			#endregion

			#region Saplings
			cherrySaplingTexture = GetDataTexture("Plants/Saplings/Cherry");
			oakSaplingTexture = GetDataTexture("Plants/Saplings/Oak");
			spruceSaplingTexture = GetDataTexture("Plants/Saplings/Spruce");
			TextureLindenSapling = GetDataTexture("Plants/Saplings/Linden");
			TextureAppleSapling = GetDataTexture("Plants/Saplings/Apple");
			plumSaplingTexture = GetDataTexture("Plants/Saplings/Plum");
			TextureMangroveSapling=GetDataTexture("Plants/Saplings/Mangrove");
			lemonSaplingTexture=GetDataTexture("Plants/Saplings/Lemon");
			orangeSaplingTexture=GetDataTexture("Plants/Saplings/Orange");
			pineSaplingTexture = GetDataTexture("Plants/Saplings/Pine");
			TextureWillowSapling=GetDataTexture("Plants/Saplings/Willow");
			TextureEucalyptusSapling=GetDataTexture("Plants/Saplings/Eucalyptus");
			TextureOliveSapling=GetDataTexture("Plants/Saplings/Olive");
			TextureRubberTreeSapling=GetDataTexture("Plants/Saplings/RubberTree");
			TextureAcaciaSapling=GetDataTexture("Plants/Saplings/Acacia");
			TextureKapokSapling=GetDataTexture("Plants/Saplings/Kapok");
			#endregion

			#region Plants
			branchWithoutTexture=GetDataTexture("Plants/Branch/Without");
			branchALittle1Texture=GetDataTexture("Plants/Branch/Little1");
			branchALittle2Texture=GetDataTexture("Plants/Branch/Little2");
			branchFullTexture=GetDataTexture("Plants/Branch/Full");

			plantAloreTexture = GetDataTexture("Plants/Flowers/Alore");
			plantCarrotTexture = GetDataTexture("Plants/ForInventory/Carrot");
			plantOnionTexture = GetDataTexture("Plants/ForInventory/Onion");
			plantPeasTexture = GetDataTexture("Plants/ForInventory/Peas");
			grassForestTexture = GetDataTexture("Plants/Grass/Forest");
			grassPlainsTexture = GetDataTexture("Plants/Grass/Plains");
			grassJungleTexture = GetDataTexture("Plants/Grass/Jungle");
			grassDesertTexture = GetDataTexture("Plants/Grass/Desert");
			grassHillsTexture = GetDataTexture("Plants/Grass/Hills");
			strawberryPlantTexture = GetDataTexture("Plants/Grow/Strawberry");
			rashberryPlantTexture = GetDataTexture("Plants/Grow/Rashberry");
			wheatTexture = GetDataTexture("Plants/Grow/WheatGrow");
			plantDandelionTexture = GetDataTexture("Plants/Flowers/Dandelion");
			plantOrchidTexture = GetDataTexture("Plants/Flowers/Orchid");
			plantRoseTexture = GetDataTexture("Plants/Flowers/Rose");
			plantVioletTexture = GetDataTexture("Plants/Flowers/Violet");
			cactusLittleTexture = GetDataTexture("Plants/Cactus/Small");
			cactusBigTexture = GetDataTexture("Plants/Cactus/Big");
			blueberryPlantTexture=GetDataTexture("Plants/Grow/Blueberry");

			coralTexture=GetDataTexture("Plants/Flowers/Coral");
			flaxTexture=GetDataTexture("Plants/Grow/Flax");
			toadstoolTexture=GetDataTexture("Plants/Mushrooms/Toadstoll");
			champignonTexture=GetDataTexture("Plants/Mushrooms/Champignon");
			sugarCaneTexture=GetDataTexture("Plants/Flowers/Sugarcane");
			seaweedTexture=GetDataTexture("Plants/Flowers/Seaweed");
			heatherTexture=GetDataTexture("Plants/Flowers/Heather");
			boletusTexture=GetDataTexture("Plants/Mushrooms/Boletus");
			lianaTexture = GetDataTexture("Plants/Flowers/Liana");
			#endregion

			#region Stone
			mudstoneTexture=GetDataTexture("Blocks/BasicBlocks/Mudstone");
			dolomiteTexture=GetDataTexture("Blocks/BasicBlocks/Dolomite");
			basaltTexture=GetDataTexture("Blocks/BasicBlocks/Basalt");
			limestoneTexture=GetDataTexture("Blocks/BasicBlocks/Limestone");
			rhyoliteTexture=GetDataTexture("Blocks/BasicBlocks/Rhyolite");
			gneissTexture=GetDataTexture("Blocks/BasicBlocks/Gneiss");
			sandstoneTexture=GetDataTexture("Blocks/BasicBlocks/SandStone");
			schistTexture=GetDataTexture("Blocks/BasicBlocks/Schist");
			gabbroTexture=GetDataTexture("Blocks/BasicBlocks/Gabbro");
			dioritTexture=GetDataTexture("Blocks/BasicBlocks/Diorit");
			anorthositeTexture=GetDataTexture("Blocks/BasicBlocks/Anorthosite");
			regoliteTexture=GetDataTexture("Blocks/BasicBlocks/Regolite");
			flintTexture=GetDataTexture("Blocks/BasicBlocks/Flint");
			#endregion

			#region Ore
			TextureOreCoal = GetDataTexture("Blocks/OreBlocks/Coal");
			TextureOreCopper = GetDataTexture("Blocks/OreBlocks/Copper");
			TextureOreTin = GetDataTexture("Blocks/OreBlocks/Tin");
			TextureOreGold = GetDataTexture("Blocks/OreBlocks/Gold");
			TextureOreSilver = GetDataTexture("Blocks/OreBlocks/Silver");
			TextureOreIron = GetDataTexture("Blocks/OreBlocks/Iron");
			TextureOreAluminium = GetDataTexture("Blocks/OreBlocks/Aluminium");
			TextureOreSulfur = GetDataTexture("Blocks/OreBlocks/Sulfur");
			TextureOreSaltpeter = GetDataTexture("Blocks/OreBlocks/Saltpeter");


			#endregion

			#region Basic
			// Grass block
			TextureGrassBlockPlains= GetDataTexture("Blocks/GrassBlocks/Plains");
			TextureGrassBlockHills = GetDataTexture("Blocks/GrassBlocks/Hills");
			TextureGrassBlockJungle = GetDataTexture("Blocks/GrassBlocks/Jungle");
			TextureGrassBlockForest = GetDataTexture("Blocks/GrassBlocks/Forest");
			TextureGrassBlockDesert = GetDataTexture("Blocks/GrassBlocks/Desert");
			TextureGrassBlockClay= GetDataTexture("Blocks/GrassBlocks/Clay");
			TextureGrassBlockCompost= GetDataTexture("Blocks/GrassBlocks/Compost");
			TextureGrassBlockSnow= GetDataTexture("Blocks/GrassBlocks/Snow");

			// Sand
			sandTexture = GetDataTexture("Blocks/BasicBlocks/Sand");
			TextureRedSand=GetDataTexture("Blocks/BasicBlocks/Redsand");

			// Liquid
			waterTexture = GetDataTexture("Blocks/BasicBlocks/Water");
			oilTexture = GetDataTexture("Blocks/OreBlocks/Oil");

			TextureDirt = GetDataTexture("Blocks/BasicBlocks/Dirt");
			gravelTexture = GetDataTexture("Blocks/BasicBlocks/Gravel");
			clayTexture= GetDataTexture("Blocks/BasicBlocks/Clay");
			iceTexture = GetDataTexture("Blocks/BasicBlocks/Ice");
			snowTexture = GetDataTexture("Blocks/BasicBlocks/snow");
			snowTopTexture = GetDataTexture("Blocks/BasicBlocks/SnowTop");
			cobblestoneTexture = GetDataTexture("Blocks/BasicBlocks/Cobblestone");

			#endregion

			#region Backgrounds
			// Basic
			backgroundDirtTexture= GetDataTexture("Blocks/BlockBackgrounds/Other/Dirt");
			backgroundGravelTexture= GetDataTexture("Blocks/BlockBackgrounds/Other/Gravel");
			backgroundSandTexture= GetDataTexture("Blocks/BlockBackgrounds/Other/Sand");
			backgroundCobblestoneTexture= GetDataTexture("Blocks/BlockBackgrounds/Other/Cobblestone");
			backgroundRegoliteTexture= GetDataTexture("Blocks/BlockBackgrounds/Other/Regolite");
			backgroundRedSandTexture= GetDataTexture("Blocks/BlockBackgrounds/Other/RedSand");
			backgroundClayTexture=GetDataTexture("Blocks/BlockBackgrounds/Other/Clay");

			// Stone
			backgroundAnorthositeTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Anorthosite");
			backgroundBasaltTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Basalt");
			backgroundDioritTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Diorit");
			backgroundDolomiteTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Dolomite");
			backgroundFlintTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Flint");
			backgroundGabbroTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Gabbro");
			backgroundGneissTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Gneiss");
			backgroundLimestoneTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Limestone");
			backgroundMudstoneTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Mudstone");
			backgroundRhyoliteTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Rhyolite");
			backgroundSandstoneTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Sandstone");
			backgroundSchistTexture= GetDataTexture("Blocks/BlockBackgrounds/Stone/Schist");

			// Ore
			TextureBackSulfurOre= GetDataTexture("Blocks/BlockBackgrounds/Ore/Sulfur");
			TextureBackSaltpeterOre= GetDataTexture("Blocks/BlockBackgrounds/Ore/Saltpeter");
			backgroundCoalTexture= GetDataTexture("Blocks/BlockBackgrounds/Ore/Coal");
			backgroundCopperTexture= GetDataTexture("Blocks/BlockBackgrounds/Ore/Copper");
			backgroundTinTexture= GetDataTexture("Blocks/BlockBackgrounds/Ore/Tin");
			backgroundIronTexture= GetDataTexture("Blocks/BlockBackgrounds/Ore/Iron");
			backgroundAluminiumTexture= GetDataTexture("Blocks/BlockBackgrounds/Ore/Aluminium");
			backgroundSilverTexture= GetDataTexture("Blocks/BlockBackgrounds/Ore/Silver");
			backgroundGoldTexture= GetDataTexture("Blocks/BlockBackgrounds/Ore/Gold");
			#endregion

			if (easter) {
				TextureEggDropE=new Texture2D[4]{
					GetDataTexture("Blocks/BasicBlocks/eggdrop2"),
					GetDataTexture("Blocks/BasicBlocks/eggdrop3"),
					GetDataTexture("Blocks/BasicBlocks/eggdrop4"),
					GetDataTexture("Blocks/BasicBlocks/eggdrop5"),
				};
			}

			TextureChristmasStar=GetDataTexture("Blocks/CraftedBlocks/Star");

			TextureWaterGraystyle=GetDataTexture("Blocks/BasicBlocks/WaterGraystyle");
			TextureEggDrop=GetDataTexture("Blocks/BasicBlocks/eggdrop");
			CompostTexture=GetDataTexture("Blocks/BasicBlocks/Compost");

			roof1Texture=GetDataTexture("Blocks/CraftedBlocks/Roof1");
			roof2Texture=GetDataTexture("Blocks/CraftedBlocks/Roof2");
			flagTexture = GetDataTexture("Blocks/CraftedBlocks/Flag");
			ladderTexture = GetDataTexture("Blocks/CraftedBlocks/Ladder");
			TextureRocks = new Texture2D[] {
				GetDataTexture("Blocks/BasicBlocks/Rocks0"),
				GetDataTexture("Blocks/BasicBlocks/Rocks1"),
				GetDataTexture("Blocks/BasicBlocks/Rocks2"),
				GetDataTexture("Blocks/BasicBlocks/Rocks3")
			};
			bricksTexture = GetDataTexture("Blocks/CraftedBlocks/Bricks");
			glassTexture = GetDataTexture("Blocks/CraftedBlocks/Glass");
			hayBlockTexture = GetDataTexture("Blocks/CraftedBlocks/HayBlock");
			planksTexture = GetDataTexture("Blocks/CraftedBlocks/Planks");
			ItemRocketTexture = GetDataTexture("Blocks/ForInventory/Rocket");
			ItemWaterMillTexture = GetDataTexture("Blocks/ForInventory/WaterMill");
			ItemWindMillTexture = GetDataTexture("Blocks/ForInventory/WindMill");
			ItemDoorTexture = GetDataTexture("Blocks/ForInventory/Door");
			ItemFlagTexture = GetDataTexture("Blocks/ForInventory/Flag");
			labelOneTexture = GetDataTexture("Blocks/ForInventory/Label");
			maceratorOneTexture = GetDataTexture("Blocks/ForInventory/Macerator");
			furnaceStoneOneTexture = GetDataTexture("Blocks/ForInventory/FurnaceStone");
			furnaceElectricOneTexture = GetDataTexture("Blocks/ForInventory/FurnaceElectric");
			torchInvTexture = GetDataTexture("Blocks/ForInventory/Torch");
			advancedSpaceBackTexture= GetDataTexture("Blocks/Advanced/AdvancedSpaceBack");
			advancedSpaceWindowTexture= GetDataTexture("Blocks/Advanced/AdvancedSpaceWindow");
			advancedSpaceBlockTexture= GetDataTexture("Blocks/Advanced/AdvancedSpaceBlok");
			advancedSpacePart1Texture= GetDataTexture("Blocks/Advanced/AdvancedSpacePart");
			advancedSpacePart2Texture= GetDataTexture("Blocks/Advanced/AdvancedSpacePart2");
			advancedSpacePart3Texture= GetDataTexture("Blocks/Advanced/AdvancedSpacePart3");
			advancedSpacePart4Texture= GetDataTexture("Blocks/Advanced/AdvancedSpacePart4");
			advancedSpaceFloorTexture= GetDataTexture("Blocks/Advanced/AdvancedSpaceFloor");
			doorInvTexture=GetDataTexture("Blocks/ForInventory/Door");
			lavaTexture=GetDataTexture("Blocks/BasicBlocks/Lava");
			#endregion

			#region Other
			lightMaskLineTexture=GetDataTexture("Particles/lightMaskLine");
			lightMaskLine2Texture=GetDataTexture("Particles/lightMaskLine2");
			lightMaskTexture=GetDataTexture("Particles/lightMask");
			lightMask2Texture=GetDataTexture("Particles/lightMask2");
			
			lightMaskRoundTexture=GetDataTexture("Particles/lightMaskRound");

			solidFuelSmokeTexture=GetDataTexture("Particles/AnimationsRocket/Solid");

			messageLeft= GetDataTexture("Particles/MessageBox/Left");
			messageCenter = GetDataTexture("Particles/MessageBox/Center");
			messageRight = GetDataTexture("Particles/MessageBox/Right");

			invStrawberryTexture=GetDataTexture("Plants/ForInventory/Strawberry");
			invRashberryTexture=GetDataTexture("Plants/ForInventory/Rashberry");
			invBlueberryTexture=GetDataTexture("Plants/ForInventory/Blueberry");
			flaxInvTexture=GetDataTexture("Plants/ForInventory/Flax");
 barEnergyTexture=GetDataTexture("Bars/Lightning");
 scrollbarUpTexture=GetDataTexture("Buttons/Scrollbar/Top");
			scrollbarBetweenTexture=GetDataTexture("Buttons/Scrollbar/Center");
			scrollbarDownTexture=GetDataTexture("Buttons/Scrollbar/Bottom");
		radioInvTexture=GetDataTexture("Blocks/ForInventory/Radio");
  sunTexture = GetDataTexture("Particles/Sun");

			fishTexture0 = GetDataTexture("Animals/Fish/Fish0");
			fishTexture1 = GetDataTexture("Animals/Fish/Fish1");

			RadioButtonPause=GetDataTexture("Buttons/Radio/Pause");
			RadioButtonPlay=GetDataTexture("Buttons/Radio/Play");
			chickenEatTexture = GetDataTexture("Animals/Chicken/Eating");
			chickenWalkTexture = GetDataTexture("Animals/Chicken/Walking");
			rabbitStillTexture = GetDataTexture("Animals/Rabbit/Still");
			chickenStillTexture = GetDataTexture("Animals/Chicken/Still");

			rabbitEatTexture = GetDataTexture("Animals/Rabbit/Eating");
			rabbitWalkTexture = GetDataTexture("Animals/Rabbit/Walking");
			rabbitJumpTexture = GetDataTexture("Animals/Rabbit/Jumping");

destructionTexture = GetDataTexture("Animations/destruction");
			TextureMoon = GetDataTexture("Animations/Moon");
			barEatTexture= GetDataTexture("Bars/Eat");
			barWaterTexture = GetDataTexture("Bars/Water");
			barOxygenTexture = GetDataTexture("Bars/Oxygen");
			barHeartTexture = GetDataTexture("Bars/Heart");

			#endregion

			#region Player
			string dirLegs=(Setting.MaturePlayer==0 ? "Young" : "")+(Setting.sex==Sex.Girl ? "Girl" : "Men");
			string dirChest=Setting.sex==Sex.Men ? "0": Setting.MaturePlayer.ToString();

			if (Setting.sex==Sex.Girl) {
				TextureWalkingUpCensored=GetDataTexture("ClothesAnimations/Walking/UpUnderwear/Censored");
				TextureStaticUpCensored=GetDataTexture("ClothesAnimations/Static/UpUnderwear/Censored");
				TextureSwimmingUpCensored=GetDataTexture("ClothesAnimations/Swimming/UpUnderwear/Censored");
			}

			// Hair
			if (Setting.hairType!=0) {
				TexturePlayerStaticHair=GetDataTexture("ClothesAnimations/Static/Body/Hair/"+Setting.hairType);
				TexturePlayerWalkingHair=GetDataTexture("ClothesAnimations/Walking/Body/Hair/"+Setting.hairType);
			}

			// Moustage
			if (Setting.moustageType!=0) {
				TexturePlayerWalkingMoustage=GetDataTexture("ClothesAnimations/Walking/Body/Moustage/"+Setting.moustageType);
				TexturePlayerStaticMoustage=GetDataTexture("ClothesAnimations/Static/Body/Moustage/"+Setting.moustageType);
			}

			// Face
			TexturePlayerWalkingFace=GetDataTexture("ClothesAnimations/Walking/Body/Face");
			TexturePlayerStaticFace=GetDataTexture("ClothesAnimations/Static/Body/Face");

			// Mouth
			TexturePlayerStaticMouth=GetDataTexture("ClothesAnimations/Static/Body/Mouth/Normal");
			TexturePlayerWalkingMouth=GetDataTexture("ClothesAnimations/Walking/Body/Mouth/Normal");

			// Eyes
			TexturePlayerStaticEyes=GetDataTexture("ClothesAnimations/Static/Body/Eyes/"+Setting.eyesType);
			TexturePlayerWalkingEyes=GetDataTexture("ClothesAnimations/Walking/Body/Eyes/"+Setting.eyesType);

			// Feet
			TexturePlayerStaticFeet=GetDataTexture("ClothesAnimations/Static/Body/Feet");
			TexturePlayerWalkingFeet=GetDataTexture("ClothesAnimations/Walking/Body/Feet");
			TexturePlayerSwimmingFeet=GetDataTexture("ClothesAnimations/Swimming/Body/Feet");

			TexturePlayerWalkingFeetForShoes=GetDataTexture("ClothesAnimations/Walking/Body/FeetForShoes");

			// Legs
			TexturePlayerStaticLegs=GetDataTexture("ClothesAnimations/Static/Body/Legs/"+dirLegs);
			TexturePlayerWalkingLegs=GetDataTexture("ClothesAnimations/Walking/Body/Legs/"+dirLegs);
			TexturePlayerSwimmingLegs=GetDataTexture("ClothesAnimations/Swimming/Body/Legs/"+dirLegs);

			// Chest
			TexturePlayerStaticChest=GetDataTexture("ClothesAnimations/Static/Body/Chest/"+dirChest);
			TexturePlayerWalkingChest=GetDataTexture("ClothesAnimations/Walking/Body/Chest/"+dirChest);
			//TexturePlayerSwimmingChest=GetDataTexture("ClothesAnimations/Swimming/Body/Chest/"+dirChest);


			// Censored
			TextureWalkingDownCensored=GetDataTexture("ClothesAnimations/Walking/DownUnderwear/Censored");
			TextureStaticDownCensored=GetDataTexture("ClothesAnimations/Static/DownUnderwear/Censored");
			TextureSwimmingDownCensored=GetDataTexture("ClothesAnimations/Swimming/DownUnderwear/Censored");

			//TexturePlayerSwimmingLegsWoman=Rabcr.ColorizeTexture(GetDataTexture("ClothesAnimations/Swimming/Legs/YoungGirl"),Setting.ColorSkin);

			TextureHand=GetDataTexture(@"ClothesAnimations\Hand");
			//TextureHandDown=GetDataTexture(@"ClothesAnimations\Static\Hand\Down");

			#region Boots
			ClothesFormalShoes=new ClothesTypeBoots{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Feet/FormalShoes"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/Feet/FormalShoes"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Feet/FormalShoes"),
				Color=ColorWhite,
			};

			ClothesPumps=new ClothesTypeBoots{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Feet/Pumps"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/Feet/Pumps"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Feet/Pumps"),
				Colorize=true,
			};

			ClothesSneakers=new ClothesTypeBoots{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Feet/Sneakers"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/Feet/Sneakers"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Feet/Sneakers"),
				Colorize=true,
			};

			ClothesSpaceBoots=new ClothesTypeBoots{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Feet/SpaceBoots"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/Feet/SpaceBoots"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Feet/SpaceBoots"),
				Color=ColorWhite,
			};
			#endregion

			#region Trousers
			ClothesJeans = new ClothesTypeTrousers {
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Legs/Jeans"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/Legs/Jeans"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Legs/Jeans"),
				Colorize=true,
			};

			ClothesShorts=new ClothesTypeTrousers{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Legs/Shorts"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/Legs/Shorts"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Legs/Shorts"),
				ShowBodyLegs=true,
				Colorize=true,
			};
			ClothesSkirt=new ClothesTypeTrousers{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Legs/Skirt"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/Legs/Skirt"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Legs/Skirt"),
				ShowBodyLegs=true,
				Colorize=true,
			};
			ClothesArmyTrousers=new ClothesTypeTrousers{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Legs/ArmyTrousers"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/Legs/ArmyTrousers"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Legs/ArmyTrousers"),
				Colorize=true,
			};
			ClothesSpaceTrousers=new ClothesTypeTrousers{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Legs/SpaceTrousers"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/Legs/SpaceTrousers"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Legs/SpaceTrousers"),
				Color=ColorWhite,
			};
			#endregion

			#region TShirt
			ClothesTShirt=new ClothesTypeTShirt{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Chest/"+dirChest+"/TShirt"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Chest/"+dirChest+"/TShirt"),
				Texture2DClothHand=GetDataTexture("ClothesAnimations/Hand/Chest/TShirt"),
				//Texture2DClothHandDown=GetDataTexture("ClothesAnimations/Hand/Chest/Down/TShirt"),
				Colorize=true,
				handSize=HandClothSize.NearlyFull,
			};
			ClothesShirt=new ClothesTypeTShirt{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Chest/"+dirChest+"/Shirt"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Chest/"+dirChest+"/Shirt"),
			  //  Texture2DClothHandUp=GetDataTexture("ClothesAnimations/Hand/Chest/Up/Shirt"),
				Texture2DClothHand=GetDataTexture("ClothesAnimations/Hand/Chest/Shirt"),
				Colorize=true,
				handSize=HandClothSize.NearlyFull,
			};
			ClothesDress=new ClothesTypeTShirt{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Chest/"+dirChest+"/Dress"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Chest/"+dirChest+"/Dress"),
			   // Texture2DClothHandUp=GetDataTexture("ClothesAnimations/Hand/Chest/Up/Dress"),
				Texture2DClothHand=GetDataTexture("ClothesAnimations/Hand/Chest/Dress"),
				Colorize=true,
				handSize=HandClothSize.NearlyFull,
			};
			ClothesTop=new ClothesTypeTShirt{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/Chest/"+dirChest+"/Top"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Chest/"+dirChest+"/Top"),
			   // Texture2DClothHandUp=GetDataTexture("ClothesAnimations/Hand/ChestTop/Up/Top"),
			  //  Texture2DClothHandDown=GetDataTexture("ClothesAnimations/Hand/ChestTop/Down/Top"),
				Colorize=true,
				handSize=HandClothSize.None,
				ShowBodyChest=true,
			};
			#endregion

			#region Helmet
			ClothesCap=new ClothesTypeHelmet{
				TextureWalkingOrSwimming=GetDataTexture("ClothesAnimations/Walking/Head/Cap"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Head/Cap"),
				Colorize=true,
			};
			ClothesHad=new ClothesTypeHelmet{
				TextureWalkingOrSwimming=GetDataTexture("ClothesAnimations/Walking/Head/Had"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Head/Had"),
				Color=ColorWhite,
			};
			ClothesCrown=new ClothesTypeHelmet{
				TextureWalkingOrSwimming=GetDataTexture("ClothesAnimations/Walking/Head/Crown"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Head/Crown"),
				Color=ColorWhite,
			};
			ClothesSpaceHelmet=new ClothesTypeHelmet{
				TextureWalkingOrSwimming=GetDataTexture("ClothesAnimations/Walking/Head/SpaceHelmet"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/Head/SpaceHelmet"),
				Color=ColorWhite,
			};
			#endregion

			#region UnderwearDown
			ClothesUnderpants=new ClothesTypeUnderwearDown{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/DownUnderwear/Underpants"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/DownUnderwear/Underpants"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/DownUnderwear/Underpants"),
				Colorize=true,
			};
			ClothesBoxerShorts=new ClothesTypeUnderwearDown{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/DownUnderwear/BoxerShorts"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/DownUnderwear/BoxerShorts"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/DownUnderwear/BoxerShorts"),
				Colorize=true,
			};
			ClothesPanties=new ClothesTypeUnderwearDown{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/DownUnderwear/Panties"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/DownUnderwear/Panties"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/DownUnderwear/Panties"),
				Colorize=true,
			};
			ClothesSwimsuit=new ClothesTypeUnderwearDown{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/DownUnderwear/Swimsuit"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/DownUnderwear/Swimsuit"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/DownUnderwear/Swimsuit"),
				Colorize=true,
			};
			ClothesBikiniDown=new ClothesTypeUnderwearDown{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/DownUnderwear/Bikini"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/DownUnderwear/Bikini"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/DownUnderwear/Bikini"),
				Colorize=true,
			};
			#endregion

			#region UnderwearUp
			ClothesBra=new ClothesTypeUnderwearUp{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/UpUnderwear/Bra"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/UpUnderwear/Bra"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/UpUnderwear/Bra"),
				Colorize=true,
			};
			ClothesBikiniTop=new ClothesTypeUnderwearUp{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/UpUnderwear/Bikini"),
				TextureSwimming=GetDataTexture("ClothesAnimations/Swimming/UpUnderwear/Bikini"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/UpUnderwear/Bikini"),
				Colorize=true,
			};
			#endregion

			#region Coat
			ClothesCoatArmy=new ClothesTypeCoat{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/ChestTop/"+dirChest+"/CoatArmy"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/ChestTop/"+dirChest+"/CoatArmy"),
				Texture2DClothHand=GetDataTexture("ClothesAnimations/Hand/ChestTop/CoatArmy"),
				Colorize=true,
				handSize=HandClothSize.NearlyFull,
			};
			ClothesCoat=new ClothesTypeCoat{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/ChestTop/"+dirChest+"/Coat"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/ChestTop/"+dirChest+"/Coat"),
				Texture2DClothHand=GetDataTexture("ClothesAnimations/Hand/ChestTop/Coat"),
				Colorize=true,
				handSize=HandClothSize.NearlyFull,
			};
			ClothesJacketDenim=new ClothesTypeCoat{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/ChestTop/"+dirChest+"/JacketDenim"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/ChestTop/"+dirChest+"/JacketDenim"),
				Texture2DClothHand=GetDataTexture("ClothesAnimations/Hand/ChestTop/JacketDenim"),
				Colorize=true,
				handSize=HandClothSize.NearlyFull,
			};
			ClothesJacketFormal=new ClothesTypeCoat{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/ChestTop/"+dirChest+"/JacketFormal"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/ChestTop/"+dirChest+"/JacketFormal"),
				Texture2DClothHand=GetDataTexture("ClothesAnimations/Hand/ChestTop/JacketFormal"),
				Colorize=true,
				handSize=HandClothSize.NearlyFull,
			};
			ClothesJacketShort=new ClothesTypeCoat{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/ChestTop/"+dirChest+"/JacketShort"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/ChestTop/"+dirChest+"/JacketShort"),
				Texture2DClothHand=GetDataTexture("ClothesAnimations/Hand/ChestTop/JacketShort"),
				Colorize=true,
				handSize=HandClothSize.Half,
			};
			ClothesSpaceSuit=new ClothesTypeCoat{
				TextureWalking=GetDataTexture("ClothesAnimations/Walking/ChestTop/"+dirChest+"/SpaceSuit"),
				TextureStatic=GetDataTexture("ClothesAnimations/Static/ChestTop/"+dirChest+"/SpaceSuit"),
				Texture2DClothHand=GetDataTexture("ClothesAnimations/Hand/ChestTop/SpaceSuit"),
				Color=ColorWhite,
				handSize=HandClothSize.Full,
			};
			#endregion


			#endregion
			#endregion

			inventoryScrollbar=new GameScrollbar(scrollbarUpTexture,scrollbarBetweenTexture,scrollbarDownTexture);
			creativeScrollbar=new GameScrollbar(scrollbarUpTexture,scrollbarBetweenTexture,scrollbarDownTexture);
			craftingScrollbar=new GameScrollbar(scrollbarUpTexture, scrollbarBetweenTexture, scrollbarDownTexture) {
				maxheight=4*40
			};

			#region Load buttons
			buttonClose=new ImgButton(GetDataTexture("Buttons/Square/Close"));
			buttonClosePopUp=new ImgButton(GetDataTexture("Buttons/Square/Close"));
			buttonInvTabBlocks=new ImgButton(GetDataTexture("Buttons/Square/Blocks"));
			buttonInvTabPlants=new ImgButton(GetDataTexture("Buttons/Square/Plants"));
			buttonInvTabTools=new ImgButton(GetDataTexture("Buttons/Square/Tools"));
			buttonInvTabMashines=new ImgButton(GetDataTexture("Buttons/Square/Mashines"));
			buttonInvTabItems=new ImgButton(GetDataTexture("Buttons/Square/Items"));
			buttonInvTabCeramics =new ImgButton(GetDataTexture("Buttons/Square/Ceramics"));
			buttonInvTabFood=new ImgButton(GetDataTexture("Buttons/Square/Food"));
			buttonInvTabGlass=new ImgButton(GetDataTexture("Buttons/Square/Glass"));
			buttonInvTabMaterials=new ImgButton(GetDataTexture("Buttons/Square/Materials"));
			buttonInvAnimals=new ImgButton(GetDataTexture("Buttons/Square/Animals"));

			buttonInvHead=new ImgButton(GetDataTexture("Buttons/Square/Head"));
			buttonInvChest=new ImgButton(GetDataTexture("Buttons/Square/Chest"));
			buttonInvLegs=new ImgButton(GetDataTexture("Buttons/Square/Legs"));
			buttonInvShoes=new ImgButton(GetDataTexture("Buttons/Square/Shoes"));
			buttonInvUnderwear=new ImgButton(GetDataTexture("Buttons/Square/Underwear"));


			buttonRocket=new GameButtonSmall(Textures.ButtonCenter) { Text=Lang.Texts[25] };
			buttonRadio=new GameButtonSmall(Textures.ButtonCenter) { Text=Lang.Texts[24] };

			ButtonCrafting=new GameButtonSmall(Textures.ButtonCenter){ Text=Lang.Texts[248] };
			ButtonItems=new GameButtonSmall(Textures.ButtonCenter){ Text=Lang.Texts[171] };
			ButtonSeal=new GameButtonSmall(Textures.ButtonCenter){ Text=Lang.Texts[345] };

			buttonContinue=new GameButtonSmall(Textures.ButtonCenter){ Text=Lang.Texts[1474] };
			buttonExit=new GameButtonSmall(Textures.ButtonCenter){ Text=Lang.Texts[1478] };
			buttonUseGiftCode=new GameButtonSmall(Textures.ButtonCenter){ Text=Lang.Texts[1476] };
			buttonAcheavements=new GameButtonSmall(Textures.ButtonCenter){ Text=Lang.Texts[1477] };
			
			{
				Texture2D button=GetDataTexture("Buttons/Other/Craft");
				buttonNext=new GameButtonSmall(button) { Text="->" };
				buttonPrev=new GameButtonSmall(button) { Text="<-" };

				buttonCraft1x=new GameButtonSmall(button) { Text="1×" };
				buttonCraft10x=new GameButtonSmall(button) { Text="10×" };
				buttonCraft100x=new GameButtonSmall(button) { Text="100×" };
			}
			#endregion

			#region Set lists other
			DroppedItems=new List<Item>();
			windable=new List<ShortAndByte>();
			FurnaceStone=new List<ShortAndByte>();
			chunksWithPlants=new List<int>();
			Chargers=new List<ShortAndByte>();
			OxygenMachines=new List<ShortAndByte>();
			Miners=new List<ShortAndByte>();
			movingAnimals=new List<Mob>();
			Composters=new List<ShortAndByte>();
			bucketRubber =new List<ShortAndByte>();
		  //  Barrels=new List<ShortAndByte>();
			energy = new List<Energy>();
			rainDots=new List<ParticleRain>();
			snowDots=new List<ParticleSnow>();
			lightsLamp=new List<MashineBlockBasic>();
			#endregion

			#region Set basic
			ZoomMatrix = Matrix.CreateScale(Setting.Zoom, Setting.Zoom, 0);

			newKeyboardState = Keyboard.GetState();
			newMouseState = Mouse.GetState();
			oldKeyboardState = newKeyboardState;
			oldMouseState = newMouseState;
			previousScrollValue = oldMouseState.ScrollWheelValue;

			InventoryCreative=new ItemInv[600];
			InventoryCrafting=new ItemInv[600];
			InventoryNormal=new ItemInv[200];
			InventoryClothes=new ItemInv[8];

			terrain = new Terrain[TerrainLength = int.Parse(File.ReadAllText(pathToWorld + world + "Generated.txt"))];

			maxInvCount = 32+8;
			if (Global.WorldDifficulty == 1) maxInvCount+=9;
			#endregion
			int startUpItems=-1;

			#region Files
			if (File.Exists(pathToWorld+@"\Options.txt")) {
				using (StreamReader sr = new StreamReader(pathToWorld+@"\Options.txt")) {
					Global.WorldDifficulty=int.Parse(sr.ReadLine());
					sr.ReadLine();
					startUpItems=int.Parse(sr.ReadLine());
				}
			}

			if (File.Exists(pathToWorld+@"\Settings.txt")) {
			 //   int x,y;
				using (StreamReader sr = new StreamReader(pathToWorld+@"\Settings.txt")) {
				   /* string version =*/ sr.ReadLine();
					//if (version!=Release.Version){
					//    System.Windows.Forms.MessageBox.Show(Lang.Texts[344],Lang.Texts[343]);
					//    return;
					//}
					if (debug = bool.Parse(sr.ReadLine())) {
						string processName = Process.GetCurrentProcess().ProcessName;

						try {
							cpu=new PerformanceCounter {
								CategoryName="Process",
								CounterName="% Processor Time",
								InstanceName=processName,
							};
							ram=new PerformanceCounter {
								CategoryName="Process",
								CounterName="Working Set - Private",
								InstanceName=processName,
							};
							cpuUsage=new PerformanceCounter {
								CategoryName="Processor",
								CounterName="% Processor Time",
								InstanceName="_Total",
							};
							freeRam=new PerformanceCounter {
								CategoryName="Memory",
								CounterName="Available MBytes"
							};

							usageCpuProcess=cpu.NextValue();
							usageCpu=cpuUsage.NextValue();
							usageRamProcess=ram.NextValue();
							usageRam=freeRam.NextValue();

							debug=true;
						} catch {
							System.Windows.Forms.MessageBox.Show("Chyba při inicializaci PerformanceCounter, Informace pro vývojáře budou skryty", "ERROR");
							debug=false;
						}
					}

					fly =bool.Parse(sr.ReadLine());
					time =int.Parse(sr.ReadLine());
					if (time>dayLenght)time=0;
					colorAlpha = ColorWhite;
					barWater = float.Parse(sr.ReadLine());
					barEat = float.Parse(sr.ReadLine());
					barHeart = float.Parse(sr.ReadLine());
					barOxygen = float.Parse(sr.ReadLine());

					PlayerX = int.Parse(sr.ReadLine());
					PlayerY = int.Parse(sr.ReadLine());

					windForce= float.Parse(sr.ReadLine());
					wind=bool.Parse(sr.ReadLine());
					rain=bool.Parse(sr.ReadLine());
					windRirectionRight=bool.Parse(sr.ReadLine());
					timeToChageWind =int.Parse(sr.ReadLine());

					changeRain=int.Parse(sr.ReadLine());
					day=int.Parse(sr.ReadLine());
					year=int.Parse(sr.ReadLine());

					moonSpeed = float.Parse(sr.ReadLine());

					AchievementStoneAge=bool.Parse(sr.ReadLine());
					AchievementBronzeAge=bool.Parse(sr.ReadLine());
					AchievementIronAge=bool.Parse(sr.ReadLine());
					AchievementFutureAge=bool.Parse(sr.ReadLine());
				}

				SetPlayerPos(PlayerX, PlayerY);
			} else {
				SetPlayerPos(random.Int(TerrainLength*16), 600);
				time=(int)(6.5f*hour);

				rain=random.Bool();
				changeRain=random.Int(1250);
			}

			if (File.Exists(pathToWorld+@"\Clothes.bin")) {
				byte[] bytes=File.ReadAllBytes(pathToWorld+@"\Clothes.bin");
				fixed (byte* pointer = &bytes[0]) {
					byte* current=pointer;

					for (int i = 0; i<8; i++) {
						ushort id=(ushort)(*current++|(*current++<<8));
						if (id==0) InventoryClothes[i]=itemBlank;
						else {

							// Probably most popular...
							if (GameMethods.IsItemInvBasicColoritzed32NonStackable(id)) {
								InventoryClothes[i]=new ItemInvBasicColoritzed32NonStackable(
									ItemIdToTexture(id),
									id,
									new Color(*current++, *current++, *current++, (byte)255),
									InventoryGetPosClothesVector2(i)
								);
								continue;
							}

							if (GameMethods.IsItemInvNonStackable32(id)) {
								InventoryClothes[i]=new ItemInvNonStackable32(
									ItemIdToTexture(id),
									id,
									InventoryGetPosClothesVector2(i)
								);
								continue;
							}

							if (GameMethods.IsItemInvBasic16(id)) {
								DInt p = InventoryGetPosClothes(i);
								InventoryClothes[i]=new ItemInvBasic16(ItemIdToTexture(id), id, /*(ushort)*/(*current++|(*current++<<8)), p.X, p.Y);
								continue;
							}

							if (GameMethods.IsItemInvBasic32(id)) {
								InventoryClothes[i]=new ItemInvBasic32(ItemIdToTexture(id), id, /*(ushort)*/(*current++|(*current++<<8)), InventoryGetPosClothesVector2(i));
								continue;
							}

							if (GameMethods.IsItemInvFood16(id)) {
								DInt p = InventoryGetPosClothes(i);
								InventoryClothes[i]=new ItemInvFood16(ItemIdToTexture(id), id, /*(ushort)(int)*/(*current++|(*current++<<8)), /*(ushort)*/GetFloat()/*(float)(*current++|(*current++<<8))*/, p.X, p.Y);
								continue;
							}

							if (GameMethods.IsItemInvTool32(id)) {
								DInt p = InventoryGetPosClothes(i);
								InventoryClothes[i]=new ItemInvTool32(ItemIdToTexture(id), id, (ushort)(*current++|(*current++<<8)), p.X, p.Y);
								continue;
							}
							if (GameMethods.IsItemInvTool16(id)) {
								DInt p = InventoryGetPosClothes(i);
								InventoryClothes[i]=new ItemInvTool16(ItemIdToTexture(id), id, (ushort)(*current++|(*current++<<8)), p.X, p.Y);
								continue;
							}
							if (GameMethods.IsItemInvFood32(id)) {
								DInt p = InventoryGetPosClothes(i);
								InventoryClothes[i]=new ItemInvFood32(ItemIdToTexture(id), id, /*(ushort)(int)*/(*current++|(*current++<<8)), /*(ushort)*/GetFloat()/*(float)(*current++|(*current++<<8))*/, p.X, p.Y);
								continue;
							}
							#if DEBUG
							byte* idPointer=(byte*)&id;
							throw new Exception("Missing category for item "+(Items)id+".\r\nWhy?\r\nUp missing code IsItemInv... or item is not in categories, isn't reverse? rId="+(idPointer[0]<<8 | idPointer[1])+" ("+(Items)(idPointer[0]<<8 | idPointer[1])+") or check generation of clothes - manually generated");
							#else
							InventoryClothes[i]=itemBlank;
							#endif
						}
					}
					float GetFloat() {
						int n=*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24);
						return *(float*)&n;
					}
				}
			}
			bool generate=false;
			if (File.Exists(pathToWorld+@"\Inventory.bin")) {
				byte[] bytes=File.ReadAllBytes(pathToWorld+@"\Inventory.bin");
				int i= 0;

				fixed (byte* pointer=bytes) {
					byte* current=pointer;

					for ( ; i<5; i++) {
						ushort id = (ushort)(*current++ | (*current++ << 8));
						if (id==0) InventoryNormal[i]=itemBlank;
						else {
							if (GameMethods.IsItemInvBasic16(id)) {
								DInt p=InventoryGetPosNormal5(i);
								InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(id), id, *current++ | (*current++ << 8), p.X, p.Y);
								continue;
							}

							if (GameMethods.IsItemInvBasic32(id)) {
								InventoryNormal[i]=new ItemInvBasic32(ItemIdToTexture(id), id, *current++ | (*current++ << 8), InventoryGetPosNormal5Vector2(i));
								continue;
							}

							if (GameMethods.IsItemInvBasicColoritzed32NonStackable(id)) {
								InventoryNormal[i]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(id), id, new Color(*current++, *current++, *current++, (byte)255), InventoryGetPosNormal5Vector2(i));
								continue;
							}

							if (GameMethods.IsItemInvFood16(id)) {
								DInt p=InventoryGetPosNormal5(i);
								InventoryNormal[i]=new ItemInvFood16(ItemIdToTexture(id), id, *current++ | (*current++ << 8), /*GameMethods.FoodMaxCount(id),*/ /*(ushort)*/GetFloat()/*(float)(*currrent++ | (*currrent++<<8))*/, /*GameMethods.FoodMaxDescay(id), */p.X, p.Y);
								continue;
							}

							if (GameMethods.IsItemInvFood32(id)) {
								DInt p=InventoryGetPosNormal5(i);
								InventoryNormal[i]=new ItemInvFood32(ItemIdToTexture(id), id, *current++ | (*current++ << 8), /*GameMethods.FoodMaxCount(id),*/ /*(ushort)*/GetFloat()/*(float)(*currrent++ | (*currrent++<<8))*/, /*GameMethods.FoodMaxDescay(id), */p.X, p.Y);
								continue;
							}

							if (GameMethods.IsItemInvNonStackable32(id)) {
								InventoryNormal[i]=new ItemInvNonStackable32(ItemIdToTexture(id), id, InventoryGetPosNormal5Vector2(i));
								continue;
							}

							if (GameMethods.IsItemInvTool32(id)) {
								DInt p=InventoryGetPosNormal5(i);
								InventoryNormal[i]=new ItemInvTool32(ItemIdToTexture(id), id, (ushort)(*current++ | (*current++ << 8)),/* GameMethods.ToolMax(id),*/ p.X, p.Y);
								continue;
							}

							if (GameMethods.IsItemInvTool16(id)) {
								DInt p=InventoryGetPosNormal5(i);
								InventoryNormal[i]=new ItemInvTool16(ItemIdToTexture(id), id, (ushort)(*current++ | (*current++ << 8)), /*GameMethods.ToolMax(id),*/ p.X, p.Y);
								continue;
							}
							#if DEBUG
							throw new Exception("Missing category for item "+(Items)id+".\r\nWhy?\r\nUp missing code IsItemInv... or item is not in categories");
							#else
							InventoryNormal[i]=itemBlank;
							#endif
						}
					}
					for ( ; i<maxInvCount; i++) {
						ushort id = (ushort)(*current++ | (*current++ << 8));
						if (id==0) InventoryNormal[i]=itemBlank;
						else {
							if (GameMethods.IsItemInvBasic16(id)) {
								DInt p=InventoryGetPosNormalInv(i);
								InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(id), id, *current++ | (*current++ << 8), p.X, p.Y);
								continue;
							}

							if (GameMethods.IsItemInvBasic32(id)) {
								InventoryNormal[i]=new ItemInvBasic32(ItemIdToTexture(id), id, *current++ | (*current++ << 8), InventoryGetPosNormalInvVector2(i));
								continue;
							}

							if (GameMethods.IsItemInvBasicColoritzed32NonStackable(id)) {
								InventoryNormal[i]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(id), id, new Color(*current++, *current++, *current++, (byte)255), InventoryGetPosNormalInvVector2(i));
								continue;
							}

							if (GameMethods.IsItemInvFood16(id)) {
								DInt p=InventoryGetPosNormalInv(i);
								InventoryNormal[i]=new ItemInvFood16(ItemIdToTexture(id), id, *current++ | (*current++ << 8), /*GameMethods.FoodMaxCount(id),*/ /*(ushort)*/GetFloat()/*(float)(*currrent++ | (*currrent++<<8))*/, /*GameMethods.FoodMaxDescay(id),*/ p.X, p.Y);
								continue;
							}

							if (GameMethods.IsItemInvFood32(id)) {
								DInt p=InventoryGetPosNormalInv(i);
								InventoryNormal[i]=new ItemInvFood32(ItemIdToTexture(id), id, *current++ | (*current++ << 8), /*GameMethods.FoodMaxCount(id),*/ /*(ushort)*/GetFloat()/*(float)(*currrent++ | (*currrent++<<8))*/, /*GameMethods.FoodMaxDescay(id),*/ p.X, p.Y);
								continue;
							}

							if (GameMethods.IsItemInvNonStackable32(id)) {
								InventoryNormal[i]=new ItemInvNonStackable32(ItemIdToTexture(id), id, InventoryGetPosNormalInvVector2(i));
								continue;
							}

							if (GameMethods.IsItemInvTool32(id)) {
								DInt p=InventoryGetPosNormalInv(i);
								InventoryNormal[i]=new ItemInvTool32(ItemIdToTexture(id), id, *current++ | (*current++ << 8), /*GameMethods.ToolMax(id),*/ p.X, p.Y);
								continue;
							}

							if (GameMethods.IsItemInvTool16(id)) {
								DInt p=InventoryGetPosNormalInv(i);
								InventoryNormal[i]=new ItemInvTool16(ItemIdToTexture(id), id, *current++ | (*current++ << 8),/* GameMethods.ToolMax(id),*/ p.X, p.Y);
								continue;
							}
							#if DEBUG
							throw new Exception("Missing category for item "+(Items)id+".\r\nWhy?\r\nUp missing code IsItemInv... or item is not in categories");
							#else
							InventoryNormal[i]=itemBlank;
							#endif
						}
					}

					float GetFloat() {
						int n=*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24);
						return *(float*)&n;
					}
				}
				for (; i<InventoryNormal.Length; i++) {
					InventoryNormal[i]=itemBlank;
				}
			} else {
				for (int i=0; i<InventoryNormal.Length; i++) {
					InventoryNormal[i]=itemBlank;
				}

				switch (startUpItems) {
					case (int)StartUpItems.Basic:
						foreach (ItemNonInv i in Release.StartUpItemsBasic) InventoryAdd(i);
						break;

					case (int)StartUpItems.Medium:
						foreach (ItemNonInv i in Release.StartUpItemsMedium) InventoryAdd(i);
						break;

					case (int)StartUpItems.Advanced:
						foreach (ItemNonInv i in Release.StartUpItemsAdvanced) InventoryAdd(i);
						break;
				}


				generate=true;
				GenerateClothes();
			}

			#endregion

			string pathItems=pathToWorld+@"\"+world+"DroppedItems.bin";

			//Achievements=new List<Achievement>();
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.Desk});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.FurnaceStone});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.CopperIngot});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.PickaxeIron});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.ShearsHeadIron});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.ShearsIron});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.SawIron});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.Planks});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.Bucket});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.Cloth});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.TorchOFF});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.SolarPanel});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.Label});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.ElectricDrill});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.FurnaceElectric});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.Backpack});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.SewingMachine});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.Macerator});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.Lamp});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.Plastic});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.AirTank});
			//Achievements.Add(new AchievementItemCreate{ Id=(ushort)Items.Rocket});

			if (File.Exists(pathItems)) {
				byte[] bytes=File.ReadAllBytes(pathItems);
				fixed (byte* pointer=&bytes[0]) {
					byte* current=pointer;

					int DroppedItemsCount=(ushort)(*current++ | (*current++ << 8));
					for (int i=0; i<DroppedItemsCount; i++) {
						ushort id=(ushort)(*current++ | (*current++ << 8));

						if (id!=0) {
							if (GameMethods.IsItemInvBasic16(id)) {
								DropItemToPos(
									new ItemNonInvBasic(id, /*(ushort)*/(*current++ | (*current++ << 8))),

									// Position
									*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24),
									*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24)
								);
								continue;
							}

							if (GameMethods.IsItemInvBasic32(id)) {
								DropItemToPos(
									new ItemNonInvBasic(id, *current++ | *current++ << 8),

									// Position
									*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24),
									*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24)
								);
								continue;
							}

							if (GameMethods.IsItemInvBasicColoritzed32NonStackable(id)) {
								DropItemToPos(
									new ItemNonInvBasicColoritzedNonStackable(
										id,
										new Color(
											*current++,
											*current++,
											*current++,
											(byte)255
										)
									),

									// Position
									*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24),
									*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24)
								);
								continue;
							}

							if (GameMethods.IsItemInvFood16(id)) {
								DropItemToPos(
									new ItemNonInvFood(id, *current++ | *current++ << 8, GetFloat()),

									// Position
									*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24),
									*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24)
								);
								continue;
							}

							if (GameMethods.IsItemInvTool32(id)) {
								DropItemToPos(
									new ItemNonInvFood(id, *current++ | *current++ << 8, GetFloat()),

									// Position
									*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24),
									*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24)
								);
								continue;
							}

							#if DEBUG
							throw new Exception("Mising category or item "+(Items)id+" ("+id+") has not defined category");
							#endif

							float GetFloat() {
								int n=*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24);
								return *(float*)&n;
							}
						}
					}
				}
			}

			Load();

			Translation = ZoomMatrix*Matrix.CreateTranslation(new Vector3(Global.WindowWidthHalf, Global.WindowHeightHalf, 0));

			sunLightTarget = new RenderTarget2D(Graphics, Global.WindowWidth, Global.WindowHeight);

			modificatedLightTarget = new RenderTarget2D(Graphics, Global.WindowWidth, Global.WindowHeight);


			//dayAlpha
			if (time>=hour*dayStart && time<=hour*(dayStart+1)) {
			 //   dayAlpha=(((time-hour*7f)/hour/2f))+1f;
				// Sun rising
				dayAlpha=((float)(time-hour*dayStart)/hour)*(1f-ConstNightAlpha)+ConstNightAlpha;

			} else if (time>=hour*dayEnd && time<=hour*(dayEnd+1)) {
				//dayAlpha=((hour*19f-time)/hour/2f)+0.5f;
				// Sun setting
				dayAlpha=((float)(hour*(dayEnd+1)-time)/hour)*(1f-ConstNightAlpha)+ConstNightAlpha;

			} else if (time>=hour*(dayStart+1) && time<=hour*dayEnd) {
				//Day
				dayAlpha=1f;

			} else {
				//Night
				dayAlpha=ConstNightAlpha;
			}
			colorAlpha=new Color(dayAlpha, dayAlpha, dayAlpha, dayAlpha);

			if (world=="Space station") {
				PlayerX=1500*16;
				changePosition=true;
			}

			SetPlayerClothes();

			if (generate){
				day=random.Int(356);
				ChangeLeavesForceEverything();
			}
			timer5=15;

			if (Global.WorldDifficulty==2) {
				for (int i = 0; i<InventoryCrafting.Length; i++) {
					InventoryCrafting[i]=itemBlank;
				}
				for (int i = 0; i<InventoryCreative.Length; i++) {
					InventoryCreative[i]=itemBlank;
				}
			}

			void GenerateClothes() {

			   // Vector2 p2=InventoryGetPosClothesVector2(InventoryClothesSlotTShirt);

				if (Setting.sex==Sex.Girl) {
				   Color rndColor=Rabcr.random.ColorMonogame() /*new Color(random.Byte(), random.Byte(), random.Byte())*/;
					if (Setting.MaturePlayer>0) {
						InventoryClothes[InventoryClothesSlotBra]=new ItemInvBasicColoritzed32NonStackable(TextureItemBra, (ushort)Items.Bra, rndColor, InventoryGetPosClothesVector2(InventoryClothesSlotBra));
					}else{
						InventoryClothes[InventoryClothesSlotBra]=itemBlank;
					}

					switch (random.Int(3)) {

						// Dress type
						case 0:
							InventoryClothes[InventoryClothesSlotTShirt]=new ItemInvBasicColoritzed32NonStackable(TextureItemDress,(ushort)Items.Dress, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotTShirt));
							InventoryClothes[InventoryClothesSlotTrousers]=itemBlank;
							break;

						//top+down
						default:
							{
								// On chest
								if (random.Bool()) InventoryClothes[InventoryClothesSlotTShirt]=new ItemInvBasicColoritzed32NonStackable(TextureItemShirt,(ushort)Items.Shirt, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotTShirt));
								else InventoryClothes[InventoryClothesSlotTShirt]=new ItemInvBasicColoritzed32NonStackable(TextureItemTShirt,(ushort)Items.TShirt, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotTShirt));

								// on legs
								switch (random.Int4()) {
									case 0:
										InventoryClothes[InventoryClothesSlotTrousers]=new ItemInvBasicColoritzed32NonStackable(TextureItemSkirt, (ushort)Items.Skirt, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotTrousers));
										break;

									case 1:
										InventoryClothes[InventoryClothesSlotTrousers]=new ItemInvBasicColoritzed32NonStackable(TextureItemShorts, (ushort)Items.Shorts, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotTrousers));
										break;

									case 2:
										InventoryClothes[InventoryClothesSlotTrousers]=new ItemInvBasicColoritzed32NonStackable(TextureItemArmyTrousers, (ushort)Items.ArmyTrousers, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotTrousers));
										break;

									case 3:
										InventoryClothes[InventoryClothesSlotTrousers]=new ItemInvBasicColoritzed32NonStackable(TextureItemJeans, (ushort)Items.Jeans, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotTrousers));
										break;
								}

								// Panties
								InventoryClothes[InventoryClothesSlotUnderwear]=new ItemInvBasicColoritzed32NonStackable(TextureItemPanties, (ushort)Items.Panties, rndColor, InventoryGetPosClothesVector2(InventoryClothesSlotUnderwear));

								// Shoes
								switch (random.Int(3)) {
									case 0:
										InventoryClothes[InventoryClothesSlotShoes]=new ItemInvBasicColoritzed32NonStackable(TextureItemSneakers, (ushort)Items.Sneakers,Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotShoes));
										break;

									case 1:
										InventoryClothes[InventoryClothesSlotShoes]=new ItemInvBasicColoritzed32NonStackable(TextureItemFormalShoes, (ushort)Items.FormalShoes,Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotShoes));
										break;

									case 2:
										InventoryClothes[InventoryClothesSlotShoes]=new ItemInvBasicColoritzed32NonStackable(TextureItemPumps, (ushort)Items.Pumps,Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotShoes));
										break;
								}
							}
							break;
					}

					InventoryClothes[InventoryClothesSlotBackpack]=itemBlank;
					InventoryClothes[InventoryClothesSlotCap]=itemBlank;
					InventoryClothes[InventoryClothesSlotCoat]=itemBlank;
				} else {

					// On chest
					if (random.Bool()) InventoryClothes[InventoryClothesSlotTShirt]=new ItemInvBasicColoritzed32NonStackable(TextureItemShirt,(ushort)Items.Shirt,Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotTShirt));
					else InventoryClothes[InventoryClothesSlotTShirt]=new ItemInvBasicColoritzed32NonStackable(TextureItemTShirt,(ushort)Items.TShirt,Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotTShirt));

					// on legs
					if (random.Bool()) InventoryClothes[InventoryClothesSlotTrousers]=new ItemInvBasicColoritzed32NonStackable(TextureItemArmyTrousers, (ushort)Items.ArmyTrousers, Rabcr.random.ColorMonogame(),InventoryGetPosClothesVector2(InventoryClothesSlotTrousers));
					else InventoryClothes[InventoryClothesSlotTrousers]=new ItemInvBasicColoritzed32NonStackable(TextureItemJeans, (ushort)Items.Jeans,Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotTrousers));

					// Underwear
					if (random.Bool()) InventoryClothes[InventoryClothesSlotUnderwear]=new ItemInvBasicColoritzed32NonStackable(TextureItemBoxerShorts, (ushort)Items.BoxerShorts, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotUnderwear));
					else InventoryClothes[InventoryClothesSlotUnderwear]=new ItemInvBasicColoritzed32NonStackable(TextureItemUnderpants, (ushort)Items.Underpants, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotUnderwear));

					// Shoes
					if (random.Bool()) InventoryClothes[InventoryClothesSlotShoes]=new ItemInvBasicColoritzed32NonStackable(TextureItemSneakers, (ushort)Items.Sneakers, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotShoes));
					else InventoryClothes[InventoryClothesSlotShoes]=new ItemInvBasicColoritzed32NonStackable(TextureItemFormalShoes, (ushort)Items.FormalShoes, Rabcr.random.ColorMonogame(), InventoryGetPosClothesVector2(InventoryClothesSlotShoes));

					InventoryClothes[InventoryClothesSlotCap]=itemBlank;
					InventoryClothes[InventoryClothesSlotBra]=itemBlank;
					InventoryClothes[InventoryClothesSlotCoat]=itemBlank;
					InventoryClothes[InventoryClothesSlotBackpack]=itemBlank;
				}
			}

			
			BiomePlayer=GetBiomeByPos((int)(PlayerX/16));
			BiomeCurrent=BiomePlayer.Name;

			GC.Collect();
			GC.WaitForPendingFinalizers();
			dontDoGame=false;
		}

		public override void Shutdown() {
			if (dontDoGame) return;
			dontDoGame=true;
		   
			if (MediaPlayer.State==MediaState.Playing) MediaPlayer.Stop();

			#region Save data
			Save();

			SaveSettings();
			//File.WriteAllText(pathToWorld+@"\Settings.txt",
			//    Release.VersionName+"\r\n"+
			//    debug+"\r\n"+
			//    fly+"\r\n"+
			//    time+"\r\n"+
			//   // dayAlpha+"\r\n"+

			//    barWater+"\r\n"+
			//    barEat+"\r\n"+
			//    barHeart+"\r\n"+
			//    barOxygen+"\r\n"+

			//    (int)PlayerX+"\r\n"+
			//    (int)PlayerY+"\r\n"+

			//    windForce+"\r\n"+
			//    wind+"\r\n"+
			//    windRirectionRight+"\r\n"+
			//    timeToChageWind+"\r\n"+

			//    changeRain+"\r\n"+

			//    moonSpeed);

			SaveInventory("Clothes",InventoryClothes);
			SaveInventory("Inventory",InventoryNormal);

			{
				List<byte> bytes=new List<byte>();
				ushort count=(ushort)DroppedItems.Count;
				bytes.Add((byte)count);
				bytes.Add((byte)(count<<8));
				foreach (Item x in DroppedItems) {
					x.item.SaveBytes(bytes);
					bytes.AddRange(BitConverter.GetBytes(x.X));
					bytes.AddRange(BitConverter.GetBytes(x.Y));
				}
				File.WriteAllBytes(pathToWorld+@"\"+world+"DroppedItems.bin",bytes.ToArray());
			}
			#endregion

			freeRam?.Dispose();
			ram?.Dispose();
			cpu?.Dispose();
			cpuUsage?.Dispose();

			modificatedLightTarget.Dispose();
			sunLightTarget.Dispose(); 
			TextureSunGradient?.Dispose();
		}

		public override unsafe void Update(GameTime gameTime) {
			if (dontDoGame) return;

			if (died) {
				timerStayDied-=0.5f;
				if (timerStayDied<=0)died=false;
			} else {

				#region Mouse
				oldMouseState=newMouseState;
				previousScrollValue = oldMouseState.ScrollWheelValue;
				newMouseState=Rabcr.newMouseState;// Mouse.GetState();
				mouseLeftPress=false;
				MousePos.mouseLeftRelease=mouseLeftRelease=false;
				mouseRightPress=false;
				mouseRightRelease=false;

				if (newMouseState.LeftButton==ButtonState.Pressed) {
				  MousePos.mouseLeftDown=  mouseLeftDown=true;
					if (oldMouseState.LeftButton==ButtonState.Released) mouseLeftPress=true;
				} else {
					 MousePos.mouseLeftDown= mouseLeftDown=false;
					if (oldMouseState.LeftButton==ButtonState.Pressed)  MousePos.mouseLeftRelease=mouseLeftRelease=true;
				}

				if (newMouseState.RightButton==ButtonState.Pressed) {
					mouseRightDown=true;
					if (oldMouseState.RightButton==ButtonState.Released) mouseRightPress=true;
				} else {
					mouseRightDown=false;
					if (oldMouseState.RightButton==ButtonState.Pressed) mouseRightRelease=true;
				}

				if (newMouseState.X==oldMouseState.X) {
					if (newMouseState.Y==oldMouseState.Y) {
						mousePosChanged=false;
					} else mousePosChanged=true;
				} else mousePosChanged=true;

				if (mousePosChanged) {
					SetMousePos();
					mousePosDiv16.X=(int)mousePos.X/16;
					mousePosDiv16.Y=(int)mousePos.Y/16;

					mousePosRoundX=mousePosDiv16.X*16;
					mousePosRoundY=mousePosDiv16.Y*16;

				   MousePos.mouseRealPosX= mouseRealPosX=newMouseState.X;
				   MousePos.mouseRealPosY= mouseRealPosY=newMouseState.Y;
				}else if (changePosition) {
					SetMousePos();
					mousePosDiv16.X=(int)mousePos.X/16;
					mousePosDiv16.Y=(int)mousePos.Y/16;

					mousePosRoundX=mousePosDiv16.X*16;
					mousePosRoundY=mousePosDiv16.Y*16;
				}
				#endregion

				#region Keyboard
				oldKeyboardState = newKeyboardState;
				newKeyboardState=Keyboard.GetState();

				if (oldKeyboardState.IsKeyDown(Keys.F12)) {
					if (newKeyboardState.IsKeyUp(Keys.F12)) {
						Save();
						GC.Collect();
						GC.WaitForPendingFinalizers();
					}
				}

				if (oldKeyboardState.IsKeyDown(Setting.KeyFlyMode)) {
					if (newKeyboardState.IsKeyUp(Setting.KeyFlyMode)) {
						if (Global.WorldDifficulty==2) {
							fly=!fly;
						}
					}
				}

				if (oldKeyboardState.IsKeyDown(Setting.KeyShowInfo)) {
					if (newKeyboardState.IsKeyUp(Setting.KeyShowInfo)) {
						if (debug) {
							debug = false;

							cpu.Close();
							cpu.Dispose();
							cpu =null;

							ram.Close();
							ram.Dispose();
							ram=null;

							cpuUsage.Close();
							cpuUsage.Dispose();
							cpuUsage=null;

							freeRam.Close();
							freeRam.Dispose();
							freeRam=null;
						} else{
							string processName = Process.GetCurrentProcess().ProcessName;

							try{
								usageCpuProcess=(cpu=new PerformanceCounter {
									CategoryName="Process",
									CounterName="% Processor Time",
									InstanceName=processName,
								}).NextValue();

								usageCpu=(ram=new PerformanceCounter {
									CategoryName="Process",
									CounterName="Working Set - Private",
									InstanceName=processName,
								}).NextValue();

								usageRamProcess=(cpuUsage=new PerformanceCounter {
									CategoryName="Processor",
									CounterName="% Processor Time",
									InstanceName="_Total",
								}).NextValue();

								usageRam=(freeRam=new PerformanceCounter {
									CategoryName="Memory",
									CounterName="Available MBytes"
								}).NextValue();

								debug = true;
							} catch {
								System.Windows.Forms.MessageBox.Show("Chyba při inicializaci PerformanceCounter, Informace pro vývojáře budou skryty","ERROR");
								debug=false;
							}
						}
					}
				}

				if (oldKeyboardState.IsKeyDown(Keys.F2)) {
					if (newKeyboardState.IsKeyUp(Keys.F2)) {
						if (showInventory) showInventory=false; else showInventory=true;
					}
				}

				if (oldKeyboardState.IsKeyDown(Keys.F3)) {
					if (newKeyboardState.IsKeyUp(Keys.F3)) {
						if (showPlayer) showPlayer=false; else showPlayer=true;
					}
				}

				if (newKeyboardState.IsKeyDown(Setting.KeyExit)) {
					if (oldKeyboardState.IsKeyUp(Setting.KeyExit)) {
						if (inventory==InventoryType.Normal){ 
							inventory=InventoryType.GameMenu;
							
							if (Constants.AnimationsControls) animationInvBack=0;
							else animationInvBack=100;

							{
								int xx = Global.WindowWidthHalf-300+10+200+10+4;
								// Continue game
								buttonContinue.Position=new Vector2(xx,Global.WindowHeightHalf-232+1+30+60-2+50);

								// Exit game
								buttonExit.Position=new Vector2(xx,Global.WindowHeightHalf-232+1+30+60+60-2+50);
						
								// Acheavements
								buttonAcheavements.Position=new Vector2(xx,Global.WindowHeightHalf-232+1+30+60+60+60-2+50);
							
								// Use a gift code
								buttonUseGiftCode.Position=new Vector2(xx,Global.WindowHeightHalf-232+1+30+60+60+60+60-2+50);

								buttonClose.Position.X=Global.WindowWidthHalf+150-32;
								buttonClose.Position.Y=Global.WindowHeightHalf-232+1+50;
							}
							textOpenInventory=new Text(Lang.Texts[114], Global.WindowWidthHalf-300-2+10+100+50, Global.WindowHeightHalf-234+10-3+50,BitmapFont.bitmapFont18);
						} else { 
							// Double Ecs press
							if (inventory==InventoryType.GameMenu) { 
								Shutdown();
								Rabcr.GoTo(new Menu(new MenuSingleplayer()));
							} else inventory=InventoryType.Normal;
						}
					}
				}

				if (newKeyboardState.IsKeyDown(Setting.KeyInventory)) {
					if (oldKeyboardState.IsKeyUp(Setting.KeyInventory)) {
						ChangeInventoryState();
						Resize();
					}
				}

				if (newKeyboardState.IsKeyDown(Setting.KeyMessage)) {
					if (oldKeyboardState.IsKeyUp(Setting.KeyMessage)) {
						if (inventory==InventoryType.Normal) {
							inventory=InventoryType.Typing;
							text =TextEdit(text);

							timeHold=-30;
							hold = false;

							lastKey = "t";

							text="";
						}
					}
				}
				#endregion

				#region Movement
				if (inventory==InventoryType.Normal) {
					if (newMouseState.ScrollWheelValue != previousScrollValue) {
						if (newMouseState.ScrollWheelValue < previousScrollValue) {
							if (boxSelected<4) boxSelected++;
						} else if (newMouseState.ScrollWheelValue > previousScrollValue) {
							if (boxSelected!=0) boxSelected--;
						}
					}

					if (rocket) {
						if (rocketDown) PlayerY+=8;
						else PlayerY-=10;
					} else if (fly) {
						if (newKeyboardState.IsKeyDown(Keys.Up)) {
							if (newKeyboardState.IsKeyDown(Keys.LeftShift) || newKeyboardState.IsKeyDown(Keys.RightShift)) PlayerY -=10;
							else PlayerY -=3;
						}

						if (newKeyboardState.IsKeyDown(Keys.Down)) {
							if (newKeyboardState.IsKeyDown(Keys.LeftShift) || newKeyboardState.IsKeyDown(Keys.RightShift)) PlayerY +=10;
							else PlayerY +=3;
						}

						if (newKeyboardState.IsKeyDown(Keys.Right)) {
							if (newKeyboardState.IsKeyDown(Keys.LeftShift) || newKeyboardState.IsKeyDown(Keys.RightShift))PlayerX +=10;
							else PlayerX +=3;
							BiomePlayer=GetBiomeByPos((int)(PlayerX/16));
						}

						if (newKeyboardState.IsKeyDown(Keys.Left)) {
							if (newKeyboardState.IsKeyDown(Keys.LeftShift) || newKeyboardState.IsKeyDown(Keys.RightShift))PlayerX -=10;
							else PlayerX -=3;
							BiomePlayer=GetBiomeByPos((int)(PlayerX/16));
						}
					} else {
						if (changePosition) {
							swimming=CheckWater();
							canbreatheDuringSwimming=!CheckWaterUp();
							waterDown=CheckWaterDown();
							DetectLava=CheckLava();
							BiomePlayer=GetBiomeByPos((int)(PlayerX/16));
							changePosition=false;
							Temperature=GetTemperature(BiomePlayer.Name);
							//swimmingTicks+=0.016f;
							//if (swimmingTicks>1)swimmingTicks-=1;

							if (Constants.AnimationsGame)FindPlants();
						}
						bool swmove=false;
					 //   bool swim;
						if (canbreatheDuringSwimming) {
							barOxygen--;
							if (barOxygen<0)barOxygen=0;
						} else {
						   
							if (barOxygen>32) {
								barHeart+=.08f;
								if (barHeart>32) Die(Lang.Texts[161]);
							}else  barOxygen+=0.05f;
						}

						if (newKeyboardState.IsKeyDown(Setting.KeyJump)) {
							if (CheckLadder()) {
								PlayerY--;

								barEnergy+=0.01f;
								barWater+=0.01f;
								gravitySpeed=-2f;
							} else if (swimming) {
								PlayerY--;
								barEnergy+=0.01f;
								barWater+=0.01f;
								gravitySpeed=-1f;
								swmove=true;
							} else {
								if (distanceToGround==0) {
									if (gravitySpeed==0) {
										gravitySpeed=-7;
										PlayerY--;

										barEnergy+=0.05f;
									}
								}
							}
						}

						if (!swimming && !waterDown) playerState=0;

						//bool oldKeyLeft=keyLeft;
						//bool oldKeyRight=keyRight;


						keyLeft=newKeyboardState.IsKeyDown(Setting.KeyLeft);
						keyRight=newKeyboardState.IsKeyDown(Setting.KeyRight);

						if (keyLeft != keyRight) {
							if (keyLeft) {
								// move
								if (barEnergy<31) {
									if (newKeyboardState.IsKeyDown(Setting.KeyRun)) {
										needSpeed=4;
									  //  barEnergy-=0.02f;
									} else needSpeed=2;
								} else needSpeed=2;
								speedDir=-1;
							} else {
								// move
								if (barEnergy<31) {
									if (newKeyboardState.IsKeyDown(Setting.KeyRun)) {
										needSpeed=4;
									  //  barEnergy-=0.02f;
									} else needSpeed=2;
								} else needSpeed=2;
								speedDir=1;
							}
							speed+=acceleration;

							if (speed>needSpeed) {
								speed=needSpeed;
								PlayerX=(int)PlayerX;
							}
						}else{
							needSpeed=0;
							if (speed>needSpeed) {
								speed-=acceleration*1.8f;
							}else {
								speed=0;
								playerState=0;
							}
						}

						if (speed>0) {
							swmove=true;
							if (barEnergy<36+0.02f*speed)barEnergy+=0.018f*speed;

							//right
							if (speedDir==1) {
								float x=DetectSolidBlocksRight(PlayerX+speed,PlayerY);

								// No limited blocks
								if (x==int.MinValue) {
									PlayerX+=speed;
									playerState=2;

									if (walkingSoundDuration<0) {
										if (Global.HasSoundGraphics) {
											SoundEffects.Steps.Play();
											walkingSoundDuration=SoundEffects.Steps.Duration.Milliseconds/16;
										}
									} else walkingSoundDuration--;
								} else {
									//Stop moving player
								   // Console.WriteLine("b touch Playerx"+PlayerX);
									PlayerX=(int)(PlayerX+speed-x-0.05f);
									//Console.WriteLine("a touch Playerx"+PlayerX);
									speed=0;
									playerState=0;
								} changePosition=true;


							//left
							} else {
								float x=DetectSolidBlocksLeft(PlayerX-speed,PlayerY);

								// No limited blocks
								if (x==int.MinValue) {
									PlayerX-=speed;
									playerState=1;
									if (walkingSoundDuration<0) {
										if (Global.HasSoundGraphics) {
											SoundEffects.Steps.Play();
											walkingSoundDuration=SoundEffects.Steps.Duration.Milliseconds/16;
										}
									} else walkingSoundDuration--;
								} else {

									//Stop moving player
									PlayerX=(int)(PlayerX-speed+x+0.5f+16);


									speed=0;
									playerState=0;
								} changePosition=true;
							}

							playerImg+=(int)(speed*5);
							if (playerImg>=420) playerImg=0;

							//if (newKeyboardState.IsKeyDown(Keys.Add) && !oldKeyboardState.IsKeyDown(Keys.Add))playerImg2+=20;
							//if (newKeyboardState.IsKeyDown(Keys.OemMinus) && !oldKeyboardState.IsKeyDown(Keys.OemMinus))playerImg2-=20;
							//if (newKeyboardState.IsKeyDown(Keys.Multiply))
							//	Debug.WriteLine("p2: "+playerImg2+" p:"+playerImg);

						 //  playerImg2+=(int)(speed*5);
							//if (playerImg2>=420) playerImg2=0;
						}
						if (swmove){
							if (waterDown){
								swimmingTicks+=0.016f;
								if (swimmingTicks>1)swimmingTicks-=1;
							}
						}

			   //         if (newKeyboardState.IsKeyDown(Setting.KeyLeft)) {
			   //             int dis=1000;
			   //             int x=((int)PlayerX-11-16)/16;
			   //             Terrain chunk=terrain[x];

			   //             if (chunk!=null) {
			   //                 int yy=((int)PlayerY+20)/16;
			   //                 if (yy<0)yy=0;
			   //                 if (yy>124)yy=124;
			   //                 for (int y=((int)PlayerY-20-1)/16; y<yy; y++) {
			   //                     if (chunk.IsSolidBlocks[y]) {
			   //                         if ((int)PlayerX-11-x*16<dis) {
			   //                             dis=(int)PlayerX-11-x*16;
			   //                         }
			   //                     }
			   //                 }
			   //             }

			   //             if (barEnergy>31) {
			   //                 if (newKeyboardState.IsKeyDown(Setting.KeyRun)) {
			   //                     needSpeed=-4;
			   //                     acceleration=1.02f;
			   //                 }
			   //             }
			   //             needSpeed=-2;
			   //             acceleration=1.2f;

			   //             if (speed!=needSpeed) {
			   //                 speed-=acceleration;

			   //                 if (speed>needSpeed) {
			   //                     speed=needSpeed;
			   //                 }
			   //             }

			   //             PlayerX+=(int)speed;

			   //             playerImg+=(int)(speed*5);
			   //             if (playerImg>=420) playerImg=0;

			   //             if (walkingSoundDuration<0) {
			   //                 if (Global.HasSoundGraphics) {
			   //                     SoundEffects.Steps.Play();
			   //                     walkingSoundDuration=SoundEffects.Steps.Duration.Milliseconds/16;
			   //                 }
			   //             } else walkingSoundDuration--;

			   //                 //if (dis>18) {
			   //                 //    if (newKeyboardState.IsKeyDown(Setting.KeyRun)) {
			   //                 //        if (barEnergy<31) {
			   //                 //            if (dis<4)PlayerX-=dis;
			   //                 //            else PlayerX-=4;

			   //                 //            barEnergy+=0.08f;

			   //                 //            playerImg+=20;

			   //                 //            if (walkingSoundDuration<0) {
			   //                 //                if (Global.HasSoundGraphics) {
			   //                 //                    SoundEffects.Steps.Play();
			   //                 //                    walkingSoundDuration=SoundEffects.Steps.Duration.Milliseconds/16;
			   //                 //                }
			   //                 //            } else walkingSoundDuration--;

			   //                 //            if (playerImg>=420) playerImg=0;
			   //                 //        } else {
			   //                 //            if (dis==1) PlayerX-=dis;
			   //                 //            else PlayerX-=2;

			   //                 //            barEnergy+=0.045f;

			   //                 //            playerImg+=10;

			   //                 //            if (walkingSoundDuration<0) {
			   //                 //                if (Global.HasSoundGraphics) {
			   //                 //                    SoundEffects.Steps.Play();
			   //                 //                    walkingSoundDuration=SoundEffects.Steps.Duration.Milliseconds/16;
			   //                 //                }
			   //                 //            } else walkingSoundDuration--;

			   //                 //            if (playerImg>=420) playerImg=0;
			   //                 //        }
			   //                 //    } else {
			   //                 //        if (dis==1)PlayerX-=dis;
			   //                 //        else PlayerX-=2;

			   //                 //        barEnergy+=0.045f;

			   //                 //        playerImg+=10;
			   //                 //        if (playerImg>=420) playerImg=0;

			   //                 //        if (walkingSoundDuration<0) {
			   //                 //            if (Global.HasSoundGraphics) {
			   //                 //                SoundEffects.Steps.Play();
			   //                 //                walkingSoundDuration=SoundEffects.Steps.Duration.Milliseconds/16;
			   //                 //            }
			   //                 //        } else walkingSoundDuration--;

			   //                 //    }
			   //                 //    playerState=1;
			   //                 //}
			   //             }

						//if (newKeyboardState.IsKeyDown(Setting.KeyRight)) {
			   //             int dis=1000;
			   //             int x=((int)PlayerX+11+16)/16;
			   //             Terrain chunk=terrain[x];

			   //             if (chunk!=null) {
			   //                 int yy=((int)PlayerY+20)/16;
			   //                 if (yy<0)yy=0;

			   //                 for (int y=((int)PlayerY-20-1)/16; y<yy; y++) {
			   //                     if (chunk.IsSolidBlocks[y]) {
			   //                         if (x*16-(int)PlayerX-11<dis) {
			   //                             dis=x*16-(int)PlayerX-11;
			   //                         }
			   //                     }
			   //                 }
			   //             }

			   //             if (dis>2) {
			   //                 if (newKeyboardState.IsKeyDown(Setting.KeyRun)) {
			   //                     if (barEnergy<31) {
			   //                         if (dis<4)PlayerX+=dis;
			   //                         else PlayerX+=4;

			   //                         barEnergy+=0.08f;

			   //                         playerImg+=20;

			   //                         if (walkingSoundDuration<0) {
			   //                             if (Global.HasSoundGraphics) {
			   //                                 SoundEffects.Steps.Play();
			   //                                 walkingSoundDuration=SoundEffects.Steps.Duration.Milliseconds/16;
			   //                             }
			   //                         } else walkingSoundDuration--;
			   //                     } else {
			   //                         if (dis==1) PlayerX+=dis;
			   //                         else PlayerX+=2;

			   //                         barEnergy+=0.045f;

			   //                         playerImg+=10;

			   //                         if (walkingSoundDuration<0) {
			   //                             if (Global.HasSoundGraphics) {
			   //                                 SoundEffects.Steps.Play();
			   //                                 walkingSoundDuration=SoundEffects.Steps.Duration.Milliseconds/16;
			   //                             }
			   //                         } else walkingSoundDuration--;
			   //                     }

			   //                     if (playerImg>=420) playerImg=0;

			   //                 } else {
			   //                     if (dis==1)PlayerX+=dis;
			   //                     else PlayerX+=2;

			   //                     barEnergy+=0.045f;

			   //                     playerImg+=10;
			   //                     if (playerImg>=420) playerImg=0;

			   //                     if (walkingSoundDuration<0) {
			   //                         if (Global.HasSoundGraphics) {
			   //                             SoundEffects.Steps.Play();
			   //                             walkingSoundDuration=SoundEffects.Steps.Duration.Milliseconds/16;
			   //                         }
			   //                     } else walkingSoundDuration--;
			   //                 }
			   //                 playerState=2;
			   //             }
					 //   }

						if (barEnergy>32) barEnergy=32;

						PlayerGravity();
					}
					#endregion

					if (diserpeard>0) diserpeard--;

						#region Game - destruction + place blocks + drop item
						bool notshot=true;
						if (Rabcr.Game.IsActive){
						if (mouseRightDown) MouseRightAction(); 
						if (mouseRightPress) ItemEat(); 

						if (mouseLeftPress) {
							if (InventoryNormal[boxSelected].Id==(ushort)Items.Gun) {
								foreach (ItemInv i in InventoryNormal) {
									if (i.Id==(ushort)Items.Ammo) {
										ItemInvBasic32 ammo=(ItemInvBasic32)i;
										notshot=false;
										ammo.SetCount=ammo.GetCount-1;
										if (ammo.GetCount==0) InventoryNormal[boxSelected]=itemBlank;
										if (In(mouseRealPosX, mouseRealPosY, Global.WindowWidth,Global.WindowHeight)) {
											if (Game.IsActive) CreateShot();
										}
										break;
									}
								}
							}
						}

					if (mouseLeftDown) {
						if (destroing) {
							if (destroyBlockX==mousePosDiv16.X && destroyBlockY==mousePosDiv16.Y) {
								destroingIndex++;

								if (destroingIndex>destringMaxIndex) {
									//if (Global.WorldDifficulty==2) {
									//    switch (destroingBlockDepth) {
									//        case BlockType.Back:
									//            {
									//                Terrain chunk = terrain[destroyBlockX];
									//                int yy=destroyBlockY;

									//                chunk.Background[yy]=null;
									//                chunk.IsBackground[yy]=false;
									//            }
									//            break;

									//        case BlockType.Solid:
									//            {
									//                Terrain chunk = terrain[destroyBlockX];
									//              //  int yy=destroyBlockY;

									//                chunk.SolidBlocks[destroyBlockY]=new AirSolidBlock() {
									//                    Top=chunk.TopBlocks[destroyBlockY],
									//                    Back=chunk.Background[destroyBlockY],
									//                };
									//                chunk.IsSolidBlocks[destroyBlockY]=false;

									//                if (destroingBlockType==(ushort)BlockId.Dirt
									//                || destroingBlockType==(ushort)BlockId.GrassBlockDesert
									//                || destroingBlockType==(ushort)BlockId.GrassBlockForest
									//                || destroingBlockType==(ushort)BlockId.GrassBlockHills
									//                || destroingBlockType==(ushort)BlockId.GrassBlockJungle
									//                || destroingBlockType==(ushort)BlockId.GrassBlockClay
									//                || destroingBlockType==(ushort)BlockId.GrassBlockCompost
									//                || destroingBlockType==(ushort)BlockId.Compost
									//                || destroingBlockType==(ushort)BlockId.GrassBlockPlains) {
									//                    DestroyGrassUp(destroyBlockX,destroyBlockY-1);
									//                    chunk.Background[destroyBlockY]=new NormalBlock(backgroundDirtTexture,(ushort)BlockId.BackDirt,new Vector2(destroyBlockX*16,destroyBlockY*16));
									//                    chunk.IsBackground[destroyBlockY]=true;
									//                }

									//                if (destroingBlockType==(ushort)BlockId.OreAluminium) {
									//                    chunk.Background[destroyBlockY]=new NormalBlock(backgroundAluminiumTexture,(ushort)BlockId.BackAluminium,new Vector2(destroyBlockX*16,destroyBlockY*16));
									//                    chunk.IsBackground[destroyBlockY]=true;
									//                }

									//                if (destroingBlockType==(ushort)BlockId.BackDiorit) {
									//                    chunk.Background[destroyBlockY]=new NormalBlock(backgroundDioritTexture,(ushort)BlockId.BackDiorit,new Vector2(destroyBlockX*16,destroyBlockY*16));
									//                    chunk.IsBackground[destroyBlockY]=true;
									//                }

									//                if (destroingBlockType==(ushort)BlockId.StoneGneiss) {
									//                    chunk.Background[destroyBlockY]=new NormalBlock(backgroundGneissTexture,(ushort)BlockId.BackGneiss,new Vector2(destroyBlockX*16,destroyBlockY*16));
									//                    chunk.IsBackground[destroyBlockY]=true;
									//                }

									//                if (destroingBlockType==(ushort)BlockId.Sand) DestroySandUp(destroyBlockX,destroyBlockY-1);

									//                RefreshLighting(destroyBlockX);
									//            }
									//            break;

									//        case BlockType.Top:
									//            {
									//                Terrain chunk=terrain[destroyBlockX];

									//                switch (destroingBlockType) {
									//                    case (ushort)BlockId.OxygenMachine:
									//                        RemovefromOxygenMachines(destroyBlockX, destroyBlockY);
									//                        break;

									//                    case (ushort)BlockId.Charger:
									//                        RemovefromChargers(destroyBlockX, destroyBlockY);
									//                        break;

									//                    case (ushort)BlockId.Miner:
									//                        RemovefromMiners(destroyBlockX,destroyBlockY);
									//                        break;

									//                    case (ushort)BlockId.Windmill:
									//                        RemovefromWintable(destroyBlockX,destroyBlockY);
									//                        break;

									//                    case (ushort)BlockId.Flag:
									//                        RemovefromWintable(destroyBlockX,destroyBlockY);
									//                        break;

									//                    case (ushort)BlockId.Lamp:
									//                        lightsLamp.Remove((MashineBlockBasic)chunk.TopBlocks[destroyBlockY]);
									//                        break;
									//                }


									//                chunk.TopBlocks[destroyBlockY]=null;
									//                chunk.IsTopBlocks[destroyBlockY]=false;

									//                if (destroingBlockType==(ushort)BlockId.Label
									//                || destroingBlockType==(ushort)BlockId.SolarPanel
									//                || destroingBlockType==(ushort)BlockId.Watermill
									//                || destroingBlockType==(ushort)BlockId.Windmill
									//                || destroingBlockType==(ushort)BlockId.FurnaceElectric
									//                || destroingBlockType==(ushort)BlockId.Macerator
									//                || destroingBlockType==(ushort)BlockId.Radio
									//                || destroingBlockType==(ushort)BlockId.Charger
									//                || destroingBlockType==(ushort)BlockId.Lamp
									//                || destroingBlockType==(ushort)BlockId.Miner) {
									//                    RefreshAroundLabels(destroyBlockX, destroyBlockY);
									//                }
									//            }
									//            break;

									//        case BlockType.Plant:
									//            {
									//                Terrain chunk=terrain[destroyBlockX];

									//                foreach (Plant plant in chunk.Plants) {
									//                    if (plant.Height==destroyBlockY) {
									//                        chunk.Plants.Remove(plant);
									//                        RemovePlant(destroyBlockY);
									//                        break;
									//                    }
									//                }
									//            }
									//            break;

									//        case BlockType.Mob:
									//            {
									//                Terrain chunk=terrain[destroyBlockX];

									//                foreach (Mob mob in chunk.Mobs) {
									//                    if (mob.Height==destroyBlockY) {
									//                        chunk.Mobs.Remove(mob);
									//                        break;
									//                    }
									//                }
									//            }
									//            break;
									//    }
									//} else {
										switch (destroingBlockDepth) {
											case BlockType.Back:
												{
													Terrain chunk=terrain[destroyBlockX];

													chunk.Background[destroyBlockY]=null;
													chunk.IsBackground[destroyBlockY]=false;

													if (Global.WorldDifficulty!=2) {
														GetItemsFromBlock(destroingBlockType, destroyBlockX, destroyBlockY);
														RemovePartTool();
													}
												}
												break;

											case BlockType.Solid:
												{
													Terrain chunk=terrain[destroyBlockX];

													chunk.SolidBlocks[destroyBlockY]=null;
													chunk.IsSolidBlocks[destroyBlockY]=false;

													chunk.RefreshLightingRemoveSolid(destroyBlockX, destroyBlockY);

													if (destroingBlockType==(ushort)BlockId.Dirt
													|| destroingBlockType==(ushort)BlockId.GrassBlockDesert
													|| destroingBlockType==(ushort)BlockId.GrassBlockForest
													|| destroingBlockType==(ushort)BlockId.GrassBlockHills
													|| destroingBlockType==(ushort)BlockId.GrassBlockJungle
													|| destroingBlockType==(ushort)BlockId.GrassBlockClay
													|| destroingBlockType==(ushort)BlockId.GrassBlockCompost
													|| destroingBlockType==(ushort)BlockId.Compost
													|| destroingBlockType==(ushort)BlockId.GrassBlockPlains) {
														DestroyGrassUp(destroyBlockX, destroyBlockY-1);

														if (Global.WorldDifficulty!=2) {
														    chunk.Background[destroyBlockY]=new NormalBlock(backgroundDirtTexture, (ushort)BlockId.BackDirt, new Vector2(destroyBlockX*16, destroyBlockY*16));
															chunk.IsBackground[destroyBlockY]=true;
														}
													}

													if (destroingBlockType==(ushort)BlockId.Sand) DestroySandUp(destroyBlockX, destroyBlockY-1);

													if (GameMethods.IsFallingBlock(destroingBlockType))

													if (Global.WorldDifficulty!=2) {


														if (destroingBlockType==(ushort)BlockId.OreAluminium) {
															chunk.Background[destroyBlockY]=new NormalBlock(backgroundAluminiumTexture, (ushort)BlockId.BackAluminium, new Vector2(destroyBlockX*16, destroyBlockY*16));
															chunk.IsBackground[destroyBlockY]=true;
														}

														if (destroingBlockType==(ushort)BlockId.BackDiorit) {
															chunk.Background[destroyBlockY]=new NormalBlock(backgroundDioritTexture, (ushort)BlockId.BackDiorit, new Vector2(destroyBlockX*16, destroyBlockY*16));
															chunk.IsBackground[destroyBlockY]=true;
														}

														if (destroingBlockType==(ushort)BlockId.StoneGneiss) {
															chunk.Background[destroyBlockY]=new NormalBlock(backgroundGneissTexture, (ushort)BlockId.BackGneiss, new Vector2(destroyBlockX*16, destroyBlockY*16));
															chunk.IsBackground[destroyBlockY]=true;
														}

														GetItemsFromBlock(destroingBlockType, destroyBlockX, destroyBlockY);
														RemovePartTool();
													}
												}
												break;

										case BlockType.Top:
											{
												Terrain chunk=terrain[destroyBlockX];

												switch (destroingBlockType) {
													case (ushort)BlockId.Lamp:
														lightsLamp.Remove((MashineBlockBasic)chunk.TopBlocks[destroyBlockY]);
														break;

													case (ushort)BlockId.Windmill:
														RemoveFromWintable(destroyBlockX,destroyBlockY);
														break;

													//case (ushort)BlockId.Barrel:
													//    RemoveFromBarrels(destroyBlockX,destroyBlockY);
													//    break;

													case (ushort)BlockId.Flag:
														RemoveFromWintable(destroyBlockX,destroyBlockY);
														break;

													case (ushort)BlockId.CactusBig:
														DestroyCactusBig(destroyBlockX,destroyBlockY);
														break;

													case (ushort)BlockId.CactusSmall:
														DestroyCactusSmall(destroyBlockX,destroyBlockY);
														break;
												}

												if (GameMethods.IsLeave(destroingBlockType)) {
													Tree tree=((LeavesBlock)chunk.TopBlocks[destroyBlockY]).tree;
													if (tree!=null) {
														List<UShortAndByte> leaves=tree.TitlesLeaves;
														for (int i = 0; i<leaves.Count; i++) {
															if (leaves[i].X==destroyBlockX){
																if (leaves[i].Y==destroyBlockY) leaves.RemoveAt(i);
															}
														}
													}
												}

												chunk.TopBlocks[destroyBlockY]=null;
												chunk.IsTopBlocks[destroyBlockY]=false;

												chunk.RefreshLightingRemoveTop(newBlockOnY: destroyBlockY, id: destroingBlockType);

												if (destroingBlockType==(ushort)BlockId.Label
												|| destroingBlockType==(ushort)BlockId.SolarPanel
												|| destroingBlockType==(ushort)BlockId.Watermill
												|| destroingBlockType==(ushort)BlockId.Windmill
												|| destroingBlockType==(ushort)BlockId.FurnaceElectric
												|| destroingBlockType==(ushort)BlockId.Macerator
												|| destroingBlockType==(ushort)BlockId.Radio
												|| destroingBlockType==(ushort)BlockId.Lamp
												|| destroingBlockType==(ushort)BlockId.Miner) {
													RefreshAroundLabels(destroyBlockX, destroyBlockY);
												}

												if (Global.WorldDifficulty!=2) {
													GetItemsFromBlock(destroingBlockType, destroyBlockX, destroyBlockY);
													RemovePartTool();
												}
											}
											break;

										case BlockType.Plant:
											{
												Terrain chunk=terrain[destroyBlockX];

												foreach (Plant plant in chunk.Plants) {
													if ((int)plant.Position.Y/16==destroyBlockY) {
														chunk.Plants.Remove(plant);
														RemovePlant(destroyBlockY);

														if (Global.WorldDifficulty!=2) {
															GetItemsFromPlant(destroingBlockType, destroyBlockX, destroyBlockY, plant.Grow==255);
															RemovePartTool();
														}

														foreach (object p in WavingPlants) {
                                                            if (p is FruitPlantWaving pp) {
                                                                if (pp.Position.X==plant.Position.X && pp.Position.Y==plant.Position.Y) {
                                                                    WavingPlants.Remove(p);
                                                                    break;
                                                                }
                                                            }
                                                        }
														break;
													}
												}
											}
											break;

										case BlockType.Mob:
											{
												Terrain chunk=terrain[destroyBlockX];
												foreach (Mob mob in chunk.Mobs) {
													if (mob.Height==destroyBlockY) {
														chunk.Mobs.Remove(mob);

														if (Global.WorldDifficulty!=2) {
															GetItemsFromMob(destroingBlockType, destroyBlockX, destroyBlockY);
															RemovePartTool();
														}
														break;
													}
												}
											}
											break;
										//}
									}
									destroing=false;
								}
							} else destroing=false;

						} else {
							if (notshot) {
								if (mousePosDiv16.Y>0 && mousePosDiv16.Y<125) {
									if (terrain[mousePosDiv16.X]!=null) {
										Destroy(mousePosDiv16.X,mousePosDiv16.Y);
									}
								}
							}
						}
					} else destroing=false;

					if (newKeyboardState.IsKeyDown(Setting.KeyDropItem)) {
						if (oldKeyboardState.IsKeyUp(Setting.KeyDropItem)) {
						   // bool all=newKeyboardState.IsKeyDown(Setting.KeyRun);

							if (InventoryNormal[boxSelected].Id!=0) {
								Do();

								void Do() {
									switch (InventoryNormal[boxSelected]) {
										case ItemInvBasic16 i1:
											if (i1.GetCount>1) {
												i1.SetCount=i1.GetCount-1;
											} else { 
												InventoryNormal[boxSelected]=itemBlank;
											}
											if (i1.GetCount>0){
												if (PlayerX-mousePos.X>0) {
													DroppedItems.Add(new Item{
														X = (int)PlayerX-11-16-1,
														Y = (int)PlayerY-22,
														item=new ItemNonInvBasic(i1.Id,1/*i1.GetCount*/),
														Texture=i1.Texture,
													});
												} else {
														DroppedItems.Add(new Item {
														X = (int)PlayerX+11+1,
														Y = (int)PlayerY-22,
														item=new ItemNonInvBasic(i1.Id,1/*i1.GetCount*/),
														Texture=i1.Texture,
													});
												}
											}
											break;

									case ItemInvFood16 i1:
										i1.SetCount=i1.GetCount-1;

										if (PlayerX-mousePos.X>0) {
											DroppedItems.Add(new Item{
												X = (int)PlayerX-11-16-1,
												Y = (int)PlayerY-22,
												item=new ItemNonInvFood(i1.Id,i1.GetCount,i1.CountMaximum,i1.GetDescay,i1.DescayMaximum),
												Texture=i1.Texture,
											});
										} else {
											DroppedItems.Add(new Item{
												X =(int)PlayerX+11+1,
												Y=(int)PlayerY-22,
												item=new ItemNonInvFood(i1.Id,i1.GetCount,i1.CountMaximum,i1.GetDescay,i1.DescayMaximum),
												Texture=i1.Texture,
											});
										}

										if (i1.GetCount==0) InventoryNormal[boxSelected]=itemBlank;
										return;

									case ItemInvBasicColoritzed32NonStackable i1:
										if ((int)PlayerX-mousePos.X>0) {
											DroppedItems.Add(new Item{
												X =(int)PlayerX-11-16-1,
												Y=(int)PlayerY-22,
												item=new ItemNonInvBasicColoritzedNonStackable(i1.Id,i1.color),
												Texture=i1.Texture,
											});
										} else {
												DroppedItems.Add(new Item{
												X =(int)PlayerX+11+1,
												Y=(int)PlayerY-22,
												item=new ItemNonInvBasicColoritzedNonStackable(i1.Id,i1.color),
												Texture=i1.Texture,
											});
										}

										InventoryNormal[boxSelected]=itemBlank;
										return;

									case ItemInvNonStackable16 i1:
										if ((int)PlayerX-mousePos.X>0) {
											DroppedItems.Add(new Item{
												X =(int)PlayerX-11-16-1,
												Y=(int)PlayerY-22,
												item=new ItemNonInvNonStackable(i1.Id),
												Texture=i1.Texture,
											});
										} else {
												DroppedItems.Add(new Item{
												X =(int)PlayerX+11+1,
												Y=(int)PlayerY-22,
												item=new ItemNonInvNonStackable(i1.Id),
												Texture=i1.Texture,
											});
										}

										InventoryNormal[boxSelected]=itemBlank;
										return;

									case ItemInvNonStackable32 i1:
										if (PlayerX-mousePos.X>0) {
											DroppedItems.Add(new Item {
												X =(int)PlayerX-11-16-1,
												Y=(int)PlayerY-22,
												item=new ItemNonInvNonStackable(i1.Id),
												Texture=i1.Texture,
											});
										} else {
												DroppedItems.Add(new Item {
												X =(int)PlayerX+11+1,
												Y=(int)PlayerY-22,
												item=new ItemNonInvNonStackable(i1.Id),
												Texture=i1.Texture,
											});
										}

										InventoryNormal[boxSelected]=itemBlank;
										return;
									}
								}
							}
						}
					}
					}
				#endregion

				#region Player pos in Window
				if (PlayerX > TerrainLength*16-Global.WindowWidth) SetPlayerPos(Global.WindowWidth, PlayerY);
				if (PlayerX < Global.WindowWidth) SetPlayerPos(TerrainLength*16-Global.WindowWidth, PlayerY);

				float min=4;
				if (PlayerX-WindowCenterX>min || PlayerY-WindowCenterY>min || PlayerX-WindowCenterX<-min || PlayerY-WindowCenterY<-min) {
					float _WindowXPlayer=WindowXPlayer+(PlayerX-WindowCenterX)*divider_16;
					float _WindowYPlayer=WindowYPlayer+(PlayerY-WindowCenterY)*divider_16;

					if (_WindowXPlayer==WindowXPlayer) {
						if (_WindowYPlayer==WindowYPlayer) {
							 cameraMove=false;
						}else cameraMove=true;
					} else cameraMove=true;

					if (cameraMove) {
						WindowXPlayer=_WindowXPlayer;
						WindowYPlayer=_WindowYPlayer;

						WindowXWithout=/*(int)*/WindowXPlayer;
						WindowYWithout=/*(int)*/WindowYPlayer;
					}
					//WindowXPlayer=WindowXPlayer+(PlayerX-WindowCenterX)/16f;
					//WindowYPlayer=WindowYPlayer+(PlayerY-WindowCenterY)/16f;


				}
				if (cameraMove) {
					WindowCenterX=WindowXWithout+Global.WindowWidthHalf;
					WindowCenterY=WindowYWithout+Global.WindowHeightHalf;

					WindowX=WindowCenterX-/*(int)(*/Global.WindowWidthHalf*divider_zoom/*)*/;
					WindowY=WindowCenterY-/*(int)(*/Global.WindowHeightHalf*divider_zoom/*)*/;

					terrainStartIndexX=((int)WindowX-1)/16;
					terrainStartIndexY=(int)WindowY/16;

					if (terrainStartIndexX<0)terrainStartIndexX=0;
					if (terrainStartIndexY<0)terrainStartIndexY=0;

					terrainStartIndexW=(int)((WindowX+Global.WindowWidth*divider_zoom)/16)+1;
					terrainStartIndexH=(int)((WindowY+Global.WindowHeight*divider_zoom)/16)+1;

					if (terrainStartIndexW>TerrainLength)terrainStartIndexW=TerrainLength;
					if (terrainStartIndexH>124) terrainStartIndexH=124;
					if (terrainStartIndexH<0) terrainStartIndexH=0;

					if (terrainStartIndexY>terrainStartIndexH) terrainStartIndexY=terrainStartIndexH;
				}
				#endregion

					if (Constants.AnimationsGame){
						if (Particles.Count>0) {
							for (int i = 0; i<Particles.Count; ) {
								ParticleMess p = Particles[i];
								p.Disepeard--;
								if (p.Disepeard<=0) { 
									Particles.RemoveAt(i);
								} else i++;
						
								if (p.Position.Y!=p.LimitY) p.Update();
							}
						}
				
						if (WavingPlants.Count>0) {
							for (int i = 0; i<WavingPlants.Count; ) {
								if (WavingPlants[i] is BasicWavingPlant p) {
									//WavingPlant p = (BasicWavingPlant)WavingPlants[i];
									if (p.ticks<100) { 
										p.ticks++;
										i++;
									} else {
										terrain[(int)(p.Position.X/16)].TopBlocks[(int)(p.Position.Y/16)]=(NormalBlock)p.TurnOff();
										WavingPlants.RemoveAt(i);
									}
								} else if (WavingPlants[i] is FruitPlantWaving z) {
								//	WavingPlant p = (GrowingPlant)WavingPlants[i];
									if (z.ticks<100) { 
										z.ticks++;
										i++;
									} else {
										List<Plant> plants=terrain[(int)(z.Position.X/16)].Plants;
										plants[plants.IndexOf(z)]=z.TurnOff();
										WavingPlants.RemoveAt(i);
									}
								}
							}
						}

						if (wind) { 
							int rch=terrainStartIndexX+random.Int(terrainStartIndexW-terrainStartIndexX);
							Terrain chunk=terrain[rch];

							int rh=terrainStartIndexY+random.Int(terrainStartIndexH-terrainStartIndexY);
							
							if (chunk.IsTopBlocks[rh]) {
								Block block=chunk.TopBlocks[rh];
								if (block is LeavesBlock lb){
									if (lb.Id==(ushort)BlockId.SpruceLeaves){ 
										FallingLeave fl=new FallingLeave(rch*16+random.Int16(), rh*16+random.Int16(), random.Float(),windRirectionRight,rain, new Rectangle(0,0,2+random.Int2(),1)){
											texture=lb.Texture,
											Color=lb.Color,
										};
										FallingLeaves.Add(fl);
									}else{
										if (lb.Id==(ushort)BlockId.OakLeaves
										|| lb.Id==(ushort)BlockId.LindenLeaves

										|| lb.Id==(ushort)BlockId.AppleLeaves
										|| lb.Id==(ushort)BlockId.AppleLeavesWithApples
										|| lb.Id==(ushort)BlockId.AppleLeavesBlossom

										|| lb.Id==(ushort)BlockId.PlumLeaves
										|| lb.Id==(ushort)BlockId.PlumLeavesBlossom
										|| lb.Id==(ushort)BlockId.PlumLeavesWithPlums

										|| lb.Id==(ushort)BlockId.CherryLeaves
										|| lb.Id==(ushort)BlockId.CherryLeavesBlossom
										|| lb.Id==(ushort)BlockId.CherryLeavesWithCherries

										|| lb.Id==(ushort)BlockId.PineLeaves
										|| lb.Id==(ushort)BlockId.RubberTreeLeaves
										|| lb.Id==(ushort)BlockId.WillowLeaves
										|| lb.Id==(ushort)BlockId.OrangeLeaves
										|| lb.Id==(ushort)BlockId.OrangeLeavesWithOranges
										|| lb.Id==(ushort)BlockId.EucalyptusLeaves

										|| lb.Id==(ushort)BlockId.KapokLeacesFibre
										|| lb.Id==(ushort)BlockId.KapokLeacesFlowering
										|| lb.Id==(ushort)BlockId.KapokLeaves

										|| lb.Id==(ushort)BlockId.OliveLeaves
										|| lb.Id==(ushort)BlockId.OliveLeavesWithOlives

										|| lb.Id==(ushort)BlockId.LemonLeaves
										|| lb.Id==(ushort)BlockId.LemonLeavesWithLemons

										|| lb.Id==(ushort)BlockId.MangroveLeaves
										) { 
											FallingLeave fl=new FallingLeave(rch*16+random.Int16(), rh*16+random.Int16(), random.Float(),windRirectionRight,rain, new Rectangle(0,0,2,2+random.Int2())){
												texture=lb.Texture
											};
											FallingLeaves.Add(fl);
										}
									}
								}
							}
						}

						if (FallingLeaves.Count>0) {
							for (int i = 0; i<FallingLeaves.Count; ) {
								FallingLeave l = FallingLeaves[i];
								l.Update();
								int ch=(int)l.Position.X/16;
								if (terrain[ch].LightPosFull16<=l.Position.Y) { 
									FallingLeaves.RemoveAt(i);
								} else i++;
							}
						}
					}

					//DescayInventory(InventoryClothes);
				//	DescayInventory(InventoryNormal);


				// do not write here
				#region Inventory
				} else {
					switch (inventory) {
						#region 1 Typing
						case InventoryType.Typing:
							string newText=text;
							text =TextEdit(text);
							while (text.Length*13>750) text=text.Substring(0,text.Length-1);
							if (newText!=text || textWriting==null) {
								int xx=Global.WindowWidthHalf+((int)PlayerX-(int)WindowCenterX);
								while (text.Length*13>750) text=text.Substring(0,text.Length-1);

								int m = BitmapFont.bitmapFont18.MeasureTextSingleLineX(text);
								textWriting=new TextWithMeasure(text,xx-m/2+5,Global.WindowHeightHalf-55-50+5+5/*,BitmapFont.bitmapFont18*/);
							}

							if (newKeyboardState.IsKeyDown(Keys.Enter)) {
								if (oldKeyboardState.IsKeyUp(Keys.Enter)) {
									inventory=0;
									diserpeard=255;

								   // DInt m=;

									int texts= BitmapFont.bitmapFont18.MeasureTextSingleLineX(text)/2;
									int x=Global.WindowWidthHalf+((int)PlayerX-(int)WindowCenterX);
									gedo=new GeDo(text,x-texts+20-10,Global.WindowHeightHalf-40-50-3);
									textWriting=null;
								}
							}
							break;
                        #endregion

                        #region Game menu
                        case InventoryType.GameMenu:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							if (buttonClose.Update()) {
								inventory=0;
							}

							if (buttonContinue.Update()) { 
								inventory=0;
							}

							// Exit game
							if (buttonExit.Update()) {
								Shutdown();
								Rabcr.GoTo(new Menu(new MenuSingleplayer()));
							}
						
							// Achievements
							if (buttonAcheavements.Update()) { 
								if (Global.WorldDifficulty==0){
									using (FormAch form=new FormAch(AchievementStoneAge, AchievementBronzeAge, AchievementIronAge, AchievementFutureAge)) {
										form.ShowDialog();
									}
								} else { 
									System.Windows.Forms.MessageBox.Show(Lang.Texts[1501]);
								}
							}

							// Use a gift code
							if (buttonUseGiftCode.Update()) { 
								using (FormGiftCode form = new FormGiftCode()) {
									form.ShowDialog();
									if (form.DropGift) { 
										string rawItems=form.giftData;
										
										byte[] bytes = Convert.FromBase64String(rawItems);
										fixed (byte* pointer=&bytes[0]) { 
											byte* current=pointer;
											byte len=*current++;

											for (int i=0; i<len; i++) {
												ushort id = (ushort)(*current++ | (*current++ << 8));
																						
												if (id!=0) {
													if (GameMethods.IsItemInvBasic16(id)) {
														AddItemToPlayer(new ItemNonInvBasic(id, *current++ | (*current++ << 8)));
														continue;
													}

													if (GameMethods.IsItemInvBasic32(id)) {
														AddItemToPlayer(new ItemNonInvBasic(id, *current++ | (*current++ << 8)));
														continue;
													}

													if (GameMethods.IsItemInvBasicColoritzed32NonStackable(id)) {
														AddItemToPlayer(new ItemNonInvBasicColoritzedNonStackable(id, new Color(*current++, *current++, *current++, (byte)255)));
														continue;
													}

													if (GameMethods.IsItemInvFood16(id)) {
														AddItemToPlayer(new ItemNonInvFood(id, *current++ | (*current++ << 8), GetFloat()));
														continue;
													}

													if (GameMethods.IsItemInvFood32(id)) {
														AddItemToPlayer(new ItemNonInvFood(id, *current++ | (*current++ << 8), GetFloat()));
														continue;
													}

													if (GameMethods.IsItemInvNonStackable32(id)) {
														AddItemToPlayer(new ItemNonInvNonStackable(id));
														continue;
													}

													if (GameMethods.IsItemInvTool32(id)) {
														AddItemToPlayer(new ItemNonInvTool(id, (ushort)(*current++ | (*current++ << 8))));
														continue;
													}

													if (GameMethods.IsItemInvTool16(id)) {
														AddItemToPlayer(new ItemNonInvTool(id, (ushort)(*current++ | (*current++ << 8))));
														continue;
													}
													
													#if DEBUG
													throw new Exception("Missing category for item "+(Items)id+".\r\nWhy?\r\nUp missing code IsItemInv... or item is not in categories");
													#else
													InventoryNormal[i]=itemBlank;
													#endif
												}
											}

											float GetFloat() {
												int n=*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24);
												return *(float*)&n;
											}
										}
									}
									
								}
							}
							break;
                        #endregion

                        #region 2 Basic inventory
                        case InventoryType.BasicInv:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}

							if (displayPopUpWindow) {
								if (buttonClosePopUp.Update()) {
									displayPopUpWindow=false;
								}
							} else {
								if (previousScrollValue!=newMouseState.ScrollWheelValue) {
									if (In(Global.WindowWidthHalf-300+4+200+4,Global.WindowHeightHalf-200+2,Global.WindowWidthHalf+300,Global.WindowHeightHalf)) {
										inventoryScrollbar.Scroll((previousScrollValue-newMouseState.ScrollWheelValue)/2);
										inventoryScrollbarValue=(int)(inventoryScrollbar.scale*(maxInvCount-45));
									}

									if (inventoryScrollbarValueCraftingMax>6*4) {
										if (In(Global.WindowWidthHalf-300+4+40+4, Global.WindowHeightHalf-200+2+4+200+8,Global.WindowWidthHalf-300+4+40+4+40*6+10, Global.WindowHeightHalf-200+2+4+200+8+40*4+10)) {
											int d=previousScrollValue-newMouseState.ScrollWheelValue;
											if (d>0) {
												inventoryScrollbarValueCrafting+=6;
												if (inventoryScrollbarValueCrafting>inventoryScrollbarValueCraftingMax-6*3) inventoryScrollbarValueCrafting=inventoryScrollbarValueCraftingMax-6*3;
												ReSetCraftingInventoryPositions();
											}
											if (d<0) {
												inventoryScrollbarValueCrafting-=6;
												if (inventoryScrollbarValueCrafting<0) inventoryScrollbarValueCrafting=0;
												ReSetCraftingInventoryPositions();
											}

									} }
								}


								ChangeInventory();

								SelectItemCraft();
								CraftingEvents();
								CraftingEventsCraft();

								if (buttonClose.Update()) {
									inventory=0;
									SetPlayerClothes();
								}

								if (buttonInvTabBlocks.Update()) SetInvCraftingBlocks();
								if (buttonInvTabMashines.Update()) SetInvCraftingMashines();
								if (buttonInvTabTools.Update()) SetInvCraftingTools();
								if (buttonInvTabPlants.Update()) SetInvCraftingNature();
								if (buttonInvTabItems.Update()) SetInvCraftingItems();
							}
							break;
						#endregion

						#region 3 Crafting
						case InventoryType.Desk:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							if (displayPopUpWindow) {
								if (buttonClosePopUp.Update()) {
									displayPopUpWindow=false;
								}
							}else{
								if (In(Global.WindowWidthHalf-300+4+200+4,Global.WindowHeightHalf-200+2,Global.WindowWidthHalf+300,Global.WindowHeightHalf)) {
									inventoryScrollbar.Scroll((previousScrollValue-newMouseState.ScrollWheelValue)/2);
									inventoryScrollbarValue=(int)(inventoryScrollbar.scale*(maxInvCount-45));
								}
								//if (inventoryScrollbarValueCraftingMax>6*4) {
								//    if (In(Global.WindowWidthHalf-300+4+40+4, Global.WindowHeightHalf-200+2+4+200+8,Global.WindowWidthHalf-300+4+40+4+40*6+10, Global.WindowHeightHalf-200+2+4+200+8+40*4+10)) {
								//        int d=previousScrollValue-newMouseState.ScrollWheelValue;
								//        if (d>0) {
								//            inventoryScrollbarValueCrafting+=6;
								//            if (inventoryScrollbarValueCrafting>inventoryScrollbarValueCraftingMax-6*3) inventoryScrollbarValueCrafting=inventoryScrollbarValueCraftingMax-6*3;
								//            ReSetCraftingInventoryPositions();
								//        }
								//        if (d<0) {
								//            inventoryScrollbarValueCrafting-=6;
								//            if (inventoryScrollbarValueCrafting<0) inventoryScrollbarValueCrafting=0;
								//            ReSetCraftingInventoryPositions();
								//        }
								//    }
								//}
								if (inventoryScrollbarValueCraftingMax>6*4) {
									if (In(Global.WindowWidthHalf-300+4+40+4, Global.WindowHeightHalf-200+2+4+200+8,Global.WindowWidthHalf-300+4+40+4+40*6+10, Global.WindowHeightHalf-200+2+4+200+8+40*4+10)) {
										int d=previousScrollValue-newMouseState.ScrollWheelValue;
										if (d>0) {
											inventoryScrollbarValueCrafting+=6;
											if (inventoryScrollbarValueCrafting>inventoryScrollbarValueCraftingMax-6*3) inventoryScrollbarValueCrafting=inventoryScrollbarValueCraftingMax-6*3;
											ReSetCraftingInventoryPositions();
										}
										if (d<0) {
											inventoryScrollbarValueCrafting-=6;
											if (inventoryScrollbarValueCrafting<0) inventoryScrollbarValueCrafting=0;
											ReSetCraftingInventoryPositions();
										}
									}
								}


								ChangeInventory();

								SelectItemCraft();

								CraftingEvents();
								CraftingEventsCraft();

								if (buttonClose.Update()) inventory=0;

								if (buttonInvTabBlocks.Update()) SetInvCraftingBlocksA();
								if (buttonInvTabMashines.Update()) SetInvCraftingMashinesA();
								if (buttonInvTabTools.Update()) SetInvCraftingToolsA();
								if (buttonInvTabPlants.Update()) SetInvCraftingNatureA();
								if (buttonInvTabItems.Update()) SetInvCraftingItemsA();
							}
							break;
						#endregion

						#region 4 Furnace stone
						case InventoryType.FurnaceStone:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							if (displayPopUpWindow) {
								if (buttonClosePopUp.Update()) {
									displayPopUpWindow=false;
								}
							} else {
								if (In(Global.WindowWidthHalf-300+4+200+4,Global.WindowHeightHalf-200+2,Global.WindowWidthHalf+300,Global.WindowHeightHalf)) {
									inventoryScrollbar.Scroll((previousScrollValue-newMouseState.ScrollWheelValue)/2);
									inventoryScrollbarValue=(int)(inventoryScrollbar.scale*(maxInvCount-45));
								}

								if (inventoryScrollbarValueCraftingMax>6*4) {
									if (In(Global.WindowWidthHalf-300+4+40+4, Global.WindowHeightHalf-200+2+4+200+8,Global.WindowWidthHalf-300+4+40+4+40*6+10, Global.WindowHeightHalf-200+2+4+200+8+40*4+10)) {
										int d=previousScrollValue-newMouseState.ScrollWheelValue;
										if (d>0) {
											inventoryScrollbarValueCrafting+=6;
											if (inventoryScrollbarValueCrafting>inventoryScrollbarValueCraftingMax-6*3) inventoryScrollbarValueCrafting=inventoryScrollbarValueCraftingMax-6*3;
											ReSetCraftingInventoryPositions();
										}
										if (d<0) {
											inventoryScrollbarValueCrafting-=6;
											if (inventoryScrollbarValueCrafting<0) inventoryScrollbarValueCrafting=0;
											ReSetCraftingInventoryPositions();
										}
									}
								}

								ChangeInventory();

								SelectItemBake();

								if (buttonInvTabMaterials.Update()) SetInvBakeIngots();
								if (buttonInvTabGlass.Update()) SetInvBakeItems();
								if (buttonInvTabCeramics.Update()) SetInvBakeCeramics();
								if (buttonInvTabFood.Update()) SetInvBakeFood();
								if (buttonInvTabTools.Update()) SetInvBakeTools();

								if (buttonClose.Update()) inventory=0;CraftingEvents();

								if (((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Energy>0) CraftingEventsCraft();
								if (buttonClose.Update()) inventory=0;
							}
							break;
						#endregion

						#region 5 Furnace electric
						case InventoryType.FurnaceElectric:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							if (displayPopUpWindow) {
								if (buttonClosePopUp.Update()) {
									displayPopUpWindow=false;
								}
							}else{
								if (In(Global.WindowWidthHalf-300+4+200+4,Global.WindowHeightHalf-200+2,Global.WindowWidthHalf+300,Global.WindowHeightHalf)) {
									inventoryScrollbar.Scroll((previousScrollValue-newMouseState.ScrollWheelValue)/2);
									inventoryScrollbarValue=(int)(inventoryScrollbar.scale*(maxInvCount-45));

								} else if (inventoryScrollbarValueCraftingMax>6*4) {
											if (In(Global.WindowWidthHalf-300+4+40+4, Global.WindowHeightHalf-200+2+4+200+8,Global.WindowWidthHalf-300+4+40+4+40*6+10, Global.WindowHeightHalf-200+2+4+200+8+40*4+10)) {
												int d=previousScrollValue-newMouseState.ScrollWheelValue;
												if (d>0) {
													inventoryScrollbarValueCrafting+=6;
													if (inventoryScrollbarValueCrafting>inventoryScrollbarValueCraftingMax-6*3) inventoryScrollbarValueCrafting=inventoryScrollbarValueCraftingMax-6*3;
													ReSetCraftingInventoryPositions();
												}
												if (d<0) {
													inventoryScrollbarValueCrafting-=6;
													if (inventoryScrollbarValueCrafting<0) inventoryScrollbarValueCrafting=0;
													ReSetCraftingInventoryPositions();
												}
											}
										}
								ChangeInventory();

								SelectItemBake();

								if (buttonInvTabMaterials.Update()) SetInvBakeIngots();
								if (buttonInvTabGlass.Update()) SetInvBakeItems();
								if (buttonInvTabCeramics.Update()) SetInvBakeCeramics();
								if (buttonInvTabFood.Update()) SetInvBakeFood();
								if (buttonInvTabTools.Update()) SetInvBakeTools();

								if (buttonClose.Update()) inventory=0;
								CraftingEvents();
							}
							if (((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Energy>0) CraftingEventsCraft();

							break;
						#endregion

						#region 6 Macerator
						case InventoryType.Macerator:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							if (displayPopUpWindow) {
								if (buttonClosePopUp.Update()) {
									displayPopUpWindow=false;
								}
							} else {

								if (In(Global.WindowWidthHalf-300+4+200+4,Global.WindowHeightHalf-200+2,Global.WindowWidthHalf+300,Global.WindowHeightHalf)) {
									inventoryScrollbar.Scroll((previousScrollValue-newMouseState.ScrollWheelValue)/2);
									inventoryScrollbarValue=(int)(inventoryScrollbar.scale*(maxInvCount-45));
								} else if (inventoryScrollbarValueCraftingMax>6*4) {
											if (In(Global.WindowWidthHalf-300+4+40+4, Global.WindowHeightHalf-200+2+4+200+8,Global.WindowWidthHalf-300+4+40+4+40*6+10, Global.WindowHeightHalf-200+2+4+200+8+40*4+10)) {
												int d=previousScrollValue-newMouseState.ScrollWheelValue;
												if (d>0) {
													inventoryScrollbarValueCrafting+=6;
													if (inventoryScrollbarValueCrafting>inventoryScrollbarValueCraftingMax-6*3) inventoryScrollbarValueCrafting=inventoryScrollbarValueCraftingMax-6*3;
													ReSetCraftingInventoryPositions();
												}
												if (d<0) {
													inventoryScrollbarValueCrafting-=6;
													if (inventoryScrollbarValueCrafting<0) inventoryScrollbarValueCrafting=0;
													ReSetCraftingInventoryPositions();
												}
											}
										}

								ChangeInventory();

								SelectItemToDust();

								if (buttonInvTabMaterials.Update()) SetInvToDustDusts();
								if (buttonInvTabPlants.Update()) SetInvToDustNature();
								if (buttonInvTabTools.Update()) SetInvToDustTools();
								if (buttonInvTabItems.Update()) SetInvToDustStone();
								if (buttonInvTabCeramics.Update()) SetInvToDustOther();

								if (buttonClose.Update()) inventory=0;
							}

							CraftingEvents();
							if (((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Energy>0) CraftingEventsCraft();
							break;
						#endregion

						#region Creative
							case InventoryType.Creative:
								if (Constants.AnimationsControls) {
									if (animationInvBack<100) {
										animationInvBack+=5;
									}
								}

								if (displayPopUpWindow) {
									if (buttonClosePopUp.Update()) {
										displayPopUpWindow=false;
									}
								} else {
									if (In(Global.WindowWidthHalf-300+4+200+4,Global.WindowHeightHalf-200+2,Global.WindowWidthHalf+300,Global.WindowHeightHalf)) {
										inventoryScrollbar.Scroll((previousScrollValue-newMouseState.ScrollWheelValue)/2);
										inventoryScrollbarValue=(int)(inventoryScrollbar.scale*(maxInvCount-45));
									}

									if (!creativeTabCrafting) ReSetInventoryCreativePositions();

									if (!displayPopUpWindow) {
										if (buttonClose.Update()) {
											inventory=0;
											SetPlayerClothes();
										}
									}

									ChangeInventory();

									if (!displayPopUpWindow) {
										if (ButtonCrafting.Update()) {creativeTabCrafting=true; SetInvCraftingBlocks(); }
										if (ButtonItems.Update()) {creativeTabCrafting=false; SetInvCreativeBlocks(); }
									}

									if (creativeTabCrafting) {
										//if (In(Global.WindowWidthHalf-300+4+200+4-100-100+60-14,Global.WindowHeightHalf-200+2+200+16+40-8,Global.WindowWidthHalf+300,Global.WindowHeightHalf+200+16)) {
										//    inventoryScrollbar.Scroll((previousScrollValue-newMouseState.ScrollWheelValue)/2);
										//    inventoryScrollbarValue=(int)(inventoryScrollbar.scale*(inventoryScrollbarValueCraftingMax-45));
										//}

										if (inventoryScrollbarValueCraftingMax>6*4) {
											if (In(Global.WindowWidthHalf-300+4+40+4, Global.WindowHeightHalf-200+2+4+200+8,Global.WindowWidthHalf-300+4+40+4+40*6+10, Global.WindowHeightHalf-200+2+4+200+8+40*4+10)) {
												int d=previousScrollValue-newMouseState.ScrollWheelValue;
												if (d>0) {
													inventoryScrollbarValueCrafting+=6;
													if (inventoryScrollbarValueCrafting>inventoryScrollbarValueCraftingMax-6*3) inventoryScrollbarValueCrafting=inventoryScrollbarValueCraftingMax-6*3;
													ReSetCraftingInventoryPositions();
												}
												if (d<0) {
													inventoryScrollbarValueCrafting-=6;
													if (inventoryScrollbarValueCrafting<0) inventoryScrollbarValueCrafting=0;
													ReSetCraftingInventoryPositions();
												}
											}
										}

										SelectItemCraftPlus();
										CraftingEventsPlus();

										if (buttonInvTabBlocks.Update()) SetInvCraftingBlocks();
										if (buttonInvTabMashines.Update()) SetInvCraftingMashines();
										if (buttonInvTabTools.Update()) SetInvCraftingTools();
										if (buttonInvTabPlants.Update()) SetInvCraftingNature();
										if (buttonInvTabItems.Update()) SetInvCraftingItems();

									} else {
										CreativeGetItems();

										if (In(Global.WindowWidthHalf-300+4+200+4-100-100+60-14,Global.WindowHeightHalf-200+2+200+16+40-8,Global.WindowWidthHalf+300,Global.WindowHeightHalf+200+16)) {
											creativeScrollbar.Scroll((previousScrollValue-newMouseState.ScrollWheelValue)/2);
											scrollBarCreative=(int)(inventoryScrollbar.scale*(inventoryScrollbarValueCraftingMax-45));
										}

										if (buttonInvTabBlocks.Update()) SetInvCreativeBlocks();
										if (buttonInvTabMashines.Update()) SetInvCreativeMashines();
										if (buttonInvTabTools.Update()) SetInvCreativeTools();
										if (buttonInvTabPlants.Update()) SetInvCreativePlants();
										if (buttonInvTabItems.Update()) SetInvCreativeItems();
									}
								}
								break;
						#endregion

						#region 8 Shelf
						case InventoryType.Shelf:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							ChangeInventory();

							if (buttonClose.Update()) {
								inventory=0;
								ShelfBlock block=(ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y];
								if (block.Inv[4].Id==0) block.IsSmallItem=false;
								else {
									Texture2D tex=ItemIdToTexture(block.Inv[4].Id);
									if (tex!=null) {
										block.SmalItemTexture=tex;
										block.IsSmallItem=true;
									}else block.IsSmallItem=false;
								}
							}

							break;
						#endregion

						#region 9 Wooden box
						case InventoryType.BoxWooden:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							ChangeInventory();

							if (buttonClose.Update()) inventory=0;
							break;
						#endregion

						#region 10 Adv box
						case InventoryType.BoxAdv:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							ChangeInventory();

							if (buttonClose.Update()) inventory=0;
							break;
						#endregion

						#region Mobile
						case InventoryType.Mobile:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							if (buttonClose.Update()) inventory=0;
						  //  mobileOS.mouse.X=mouseRealPos;
							mobileOS.mouseDown=newMouseState.LeftButton==ButtonState.Pressed;
							mobileOS.Update();
							break;
						#endregion

						#region Rocket
						case InventoryType.Rocket:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							if (buttonClose.Update()) inventory=0;
							if (buttonRocket.Update()) {
								AchievementFutureAge=true;
								Save();
								rocket=true;
								rocketDown=false;
								PlayerX=selectedMashine.X;
								PlayerY=selectedMashine.Y;
								inventory=0;
								File.WriteAllText(pathToWorld+"UseRocket.txt","");
								Terrain chunk=terrain[selectedMashine.X];
								chunk.IsTopBlocks[selectedMashine.Y]=false;
								chunk.TopBlocks[selectedMashine.Y]=null;
							}
							break;
						#endregion

						#region Charger
						case InventoryType.Charger:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							ChangeInventory();

							if (buttonClose.Update()) {
								inventory=0;
							}
							break;
						#endregion

						#region Miner
						case InventoryType.Miner:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							ChangeInventory();

							if (buttonClose.Update()) inventory=0;
							break;
						#endregion

						#region Radio
						case InventoryType.Radio:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							if (buttonRocket.Update()) { }
							if (buttonClose.Update()) inventory=0;

							if (radioplaying) {
								if (MediaPlayer.PlayPosition==TimeSpan.MinValue) radioplaying=false;
							}
						   if (((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Energy>0) {
							if (radioSongs!=null) {
								for (int i=0; i<radioSongs.Length; i++) {
										if (newMouseState.LeftButton==ButtonState.Pressed) {
									if (newMouseState.X>Global.WindowWidthHalf-300-2+10+240 && newMouseState.Y>Global.WindowHeightHalf-234+10+40+i*40
							 && newMouseState.X<Global.WindowWidthHalf+200 && newMouseState.Y<Global.WindowHeightHalf-234+10+40+i*40+48) {
								if (radioplaying) {
									MediaPlayer.Stop();
								} radioplaying=true;
												}

												Song song = GetDataSong("Radio/"+new FileInfo(radioSongs[i]).Name.Substring(0, (new FileInfo(radioSongs[i]).Name).LastIndexOf(".")));
												MediaPlayer.Play(song);
											}

								} }
							}
							 if (newMouseState.LeftButton==ButtonState.Pressed) {
							if (newMouseState.X>Global.WindowWidthHalf-24 && newMouseState.Y>Global.WindowHeightHalf-200+2+400-50
							 && newMouseState.X<Global.WindowWidthHalf-24+48 && newMouseState.Y<Global.WindowHeightHalf-200+2+400-50+48) {
								if (radioplaying) {
									MediaPlayer.Stop();
											radioplaying=false;

								} }
							}
							break;
						#endregion

						#region Composter
						case InventoryType.Composter:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							ChangeInventory();

							if (buttonClose.Update()) inventory=0;
							break;
						#endregion

						#region SewingMachine
						case InventoryType.SewingMachine:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							if (displayPopUpWindow) {
								if (buttonClosePopUp.Update()) {
									displayPopUpWindow=false;
								}
							} else {
								if (In(Global.WindowWidthHalf-300+4+200+4,Global.WindowHeightHalf-200+2,Global.WindowWidthHalf+300,Global.WindowHeightHalf)) {
									inventoryScrollbar.Scroll((previousScrollValue-newMouseState.ScrollWheelValue)/2);
									inventoryScrollbarValue=(int)(inventoryScrollbar.scale*(maxInvCount-45));
								}else if (inventoryScrollbarValueCraftingMax>6*4) {
											if (In(Global.WindowWidthHalf-300+4+40+4, Global.WindowHeightHalf-200+2+4+200+8,Global.WindowWidthHalf-300+4+40+4+40*6+10, Global.WindowHeightHalf-200+2+4+200+8+40*4+10)) {
												int d=previousScrollValue-newMouseState.ScrollWheelValue;
												if (d>0) {
													inventoryScrollbarValueCrafting+=6;
													if (inventoryScrollbarValueCrafting>inventoryScrollbarValueCraftingMax-6*3) inventoryScrollbarValueCrafting=inventoryScrollbarValueCraftingMax-6*3;
													ReSetCraftingInventoryPositions();
												}
												if (d<0) {
													inventoryScrollbarValueCrafting-=6;
													if (inventoryScrollbarValueCrafting<0) inventoryScrollbarValueCrafting=0;
													ReSetCraftingInventoryPositions();
												}
											}
										}
								ChangeInventory();

								SelectItemClothes();

								if (buttonInvHead.Update()) SetInvClothesHead();
								if (buttonInvChest.Update()) SetInvClothesChest();
								if (buttonInvLegs.Update()) SetInvClothesLegs();
								if (buttonInvShoes.Update()) SetInvClothesShoes();
								if (buttonInvUnderwear.Update()) SetInvClothesUnderwear();

								if (buttonClose.Update()) inventory=0;
							}

							CraftingEvents();
							if (((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Energy>0) CraftingEventsCraft();
							break;
						#endregion

						#region OxygenMachine
						case InventoryType.OxygenMachine:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							ChangeInventory();

							if (buttonClose.Update()) {
								inventory=0;
							}
							break;
						#endregion

						#region Barrel
						case InventoryType.Barrel:
							if (Constants.AnimationsControls) {
								if (animationInvBack<100) {
									animationInvBack+=5;
								}
							}
							ChangeInventory();

							InventoryBarrelInSlotEvent();

							if (buttonClose.Update()) {
								inventory=0;
								//Barrel block=(Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y];
								//if (block.Inv[4].Id==0) block.IsSmallItem=false;
								//else {
								//    Texture2D tex=ItemIdToTexture(block.Inv[4].Id);
								//    if (tex!=null) {
								//        block.SmalItemTexture=tex;
								//        block.IsSmallItem=true;
								//    }else block.IsSmallItem=false;
								//}
							}

							if (ButtonSeal.Update()) {

							}

							break;
						#endregion
					}
				}
				#endregion

				#region Update items
				if (DroppedItems.Count>0) {
					Global.itemAnimationPos+=0.1047197551f;
					if (Global.itemAnimationPos>6.283185307f) Global.itemAnimationPos=0f;
					Global.ItemAnimation=(float)Math.Cos(Global.itemAnimationPos);

					itemAnimationPos2+=0.1047197551f;
					if (itemAnimationPos2>6.283185307f) itemAnimationPos2=0f;
					Global.ItemAnimation2=(float)Math.Cos(itemAnimationPos2);
					UpdateItem(DroppedItems);
				}
				#endregion

				#region  bars
				if (barEnergy<=32) {
					if (barEnergy>0) {
						if (barEat>=0) {
							if (barWater>=0) {
								barEat+=0.0006f;
								barWater+=0.0008f;
								barEnergy-=0.04f;

								if (barEat<0) barEat=0;
								if (barWater>32) barWater=32;
								if (barEnergy<0) barEnergy=0;
							}
						}
					}
				}
				#endregion

				#region Wheather
				if (actualRainForce>0f) {
					if (Temperature<0) { 
						if (wind) {
							for (int i=0; i<(weatherWindowWidth+600)/300; i++){ 
								int addSide=Global.WindowHeight/2;
								if (windRirectionRight) {
									if ((actualRainForce*0.25f+0.5f)*rainWaveForce < random.Float()) {
										snowDots.Add(
											new ParticleSnow(random.Float()*0.8f+0.2f, gravity+0.2f) { 
												Position=new Vector2 { X=random.Int(weatherWindowWidth+addSide), Y=-10 },
												HSpeed=windForce*0.5f 
										});
									}
								} else { 
									if ((actualRainForce*0.25f+0.5f)*rainWaveForce < random.Float()) {
										snowDots.Add(
										new ParticleSnow(random.Float()*0.8f+0.2f, gravity+0.2f) { 
											Position=new Vector2 { X=random.Int(weatherWindowWidth+addSide)-addSide, Y=-10 },
											HSpeed=windForce*0.5f 
										});
									}
								}
							}
							if (Global.HasSoundGraphics) {
								if (rainDuration==0) {
									SoundEffects.Wind.Play();
									rainDuration=(int)(SoundEffects.Wind.Duration.TotalMilliseconds/16.3333334d);
								} else rainDuration--;
							}
						} else {
							for (int i=0; i<(weatherWindowWidth+10)/300; i++){ 
								if ((actualRainForce*0.25f+0.5f)*rainWaveForce < random.Float()) {
									snowDots.Add(new ParticleSnow( random.Float()*0.8f+0.2f, gravity+0.2f) { 
										Position=new Vector2 {X=random.Int(/*Global.WindowWidth*/weatherWindowWidth+10)-5, Y=-10},
										HSpeed=windForce*0.5f 
									}); 
								}
							} 
						}
					
					} else { 
						if ((actualRainForce*0.25f+0.5f)*rainWaveForce < random.Float()) {
							for (int i=0; i<(Global.WindowWidth+10)/300; i++){ 
								rainDots.Add(new ParticleRain(random.Float()*0.8f+0.2f, gravity*20f+0.2f) { Position=new Vector2{X=random.Int(/*848*/weatherWindowWidth+20)-10, Y=-10 },HSpeed=windForce });
							}
						}
						if (Global.HasSoundGraphics) {
							if (rainDuration==0) {
								if (wind){ 
									SoundEffects.Wind.Play();
									rainDuration=(int)(SoundEffects.Wind.Duration.TotalMilliseconds/16.3333334d);
								} else { 
									SoundEffects.Rain.Play();
									rainDuration=(int)(SoundEffects.Rain.Duration.TotalMilliseconds/16.3333334d);
								}
							} else rainDuration--;
						}
					}
				}
				#endregion

				EnergySystem();

				{
					lightsFull.Clear();
					lightsHalf.Clear();

					int w=(int)WindowY-8, w2=(int)WindowY/*+*/-8;
					
					for (int x=(terrainStartIndexX>2 ? terrainStartIndexX-2 : terrainStartIndexX); x<terrainStartIndexW+2 && x<TerrainLength; x++) {
						Terrain chunk=terrain[x];
						int f=chunk.LightPosFull16;

						//if (chunk.Half) { 
							if (w<f) { 
								int h=chunk.LightPosHalf16-8;
							
							//	if (w<h) { 
									lightsHalf.Add(new Rectangle(x*16-40, (int)WindowY, 16+40+40, h-w2));
									lightsFull.Add(new Rectangle(x*16-40, (int)WindowY, 16+40+40, chunk.LightPosFull16-w2));
								//original:	lightsHalf.Add(new Rectangle(x*16-40,h/* /*(int)WindowY+(f-h)*/, 16+40+40, f-h+8));
								//	lightsHalf.Add(new Rectangle(x*16-40,(int)WindowY /*h*//* /*(int)WindowY+(f-h)*/, 16+40+40, f-h+8));
							//	}else{ 
								//	lightsHalf.Add(new Rectangle(x*16-40, (int)WindowY+h, 16+40+40, f-h-w2));
								//}
							} 
						//} else { 
						//	if (w<f) lightsFull.Add(new Rectangle(x*16-40, (int)WindowY, 16+40+40, f-w2));
						//	lightsHalf.Add(new Rectangle(x*16-40, (int)WindowY, 16+40+40, f-w2));
							
						//}
					}
				}
				
				// Update Shot
				for (int i=0; i<GunShots.Count; i++) {
					GunShot gs = GunShots[i];

					// Live of shot
					gs.Time++;
					if (gs.Time>60) {
						GunShots.RemoveAt(i);
						i--;
						continue;
					}
					gs.Update();

					// Kill mob with gun
					int x=(int)(gs.X*divider_16);
					Terrain chunk=terrain[x];
					if (chunk!=null) {
						int y=(int)(gs.Y*divider_16);

						for (int j = 0; j<chunk.Mobs.Count; j++) {
							Mob m = chunk.Mobs[j];
							if (m.Height==y) {
								GetItemsFromMob(m.Id, x, y);
								chunk.Mobs.RemoveAt(j);
								break;
							}
						}
					}
				}

				if (timer5==2) {
					UpdateLiquid((ushort)BlockId.WaterBlock);
					if (wind){if (Global.WindowWidth>1000) WaveGrassDuringWind(); }
				}

				if (timer5==4) {
					UpdateLiquid((ushort)BlockId.WaterSalt);
					if (wind) WaveGrassDuringWind();
					if (wind) WaveGrassDuringWind();
				}	
				
				if (actualRainForce>0f) {
					for (int i = 0; i<rainDots.Count; ) {
						ParticleRain r = rainDots[i];
							
						if (/*Global.WindowHeight*/weatherWindowHeight<r.Position.Y) {
							rainDots.RemoveAt(i);
						} else {
							r.Update();
							i++;
						}
					}
					for (int i = 0; i<snowDots.Count; ) {
						ParticleSnow r = snowDots[i];
						if (/*Global.WindowHeight*/weatherWindowHeight<r.Position.Y) {
							snowDots.RemoveAt(i);
						} else { 
							r.Update();
							i++;
						}
					}
				}

				if (timer5<-0.1f) {
					if (wind) WaveGrassDuringWind();
								rainWaveForce=((float)Math.Sin(time/600f))*0.5f+0.5f;
				//	Console.WriteLine(rainWaveForce);
					//if (rainWaveForce<0.5f)rainWaveForce+=0.05f;
					//else if (rainWaveForce>1f)rainWaveForce-=0.05f;
					//else if (random.Bool()) rainWaveForce+=0.05f;
					//else rainWaveForce-=0.05f;

					if (rain || changeRain<5f) { 
						if (actualRainForce<1f)actualRainForce+=0.05f;
					} else if (actualRainForce>0f)actualRainForce-=0.05f;

					// Create ice
					if (Temperature<0) {
						{
							int rid=random.Int(BiomePlayer.End-BiomePlayer.Start)+BiomePlayer.Start;
							if (rid<TerrainLength){
								Terrain chunk=terrain[rid];
								int ry=random.Int(125-chunk.StartSomething)+chunk.StartSomething;
								if (chunk.IsTopBlocks[ry]) { 
									if (chunk.TopBlocks[ry].Id==(ushort)BlockId.WaterBlock) { 
										if (((Water)chunk.TopBlocks[ry]).GetMass==255) {
											// Remove water
											chunk.IsTopBlocks[ry]=false;
											chunk.TopBlocks[ry]=null;

											// set ice
											chunk.IsSolidBlocks[ry]=true;
											chunk.SolidBlocks[ry]=new NormalBlock { 
												Id=(ushort)BlockId.Ice,
												Position=new Vector2(rid*16,ry*16),
												Texture=iceTexture
											};
										} 
									}
								}
							}
						}

						if (rain) { 
							int rid=random.Int(BiomePlayer.End-BiomePlayer.Start)+BiomePlayer.Start;
							if (rid<TerrainLength){
								Terrain chunk=terrain[rid];
								if (chunk.StartSomething>0) {
									if (chunk.IsSolidBlocks[chunk.LightPosFull]) { 
										switch (chunk.SolidBlocks[chunk.LightPosFull].Id) {
											case (ushort)BlockId.GrassBlockClay:
												chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockSnow, (ushort)BlockId.GrassBlockSnowClay, new Vector2(rid*16, chunk.LightPosFull*16));
												break;

											case (ushort)BlockId.GrassBlockCompost: 
												chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockSnow, (ushort)BlockId.GrassBlockSnowCompost, new Vector2(rid*16, chunk.LightPosFull*16));
												break;

											case (ushort)BlockId.GrassBlockPlains:
												chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockSnow, (ushort)BlockId.GrassBlockSnowPlains, new Vector2(rid*16, chunk.LightPosFull*16));
												break;

											case (ushort)BlockId.GrassBlockForest:
												chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockSnow, (ushort)BlockId.GrassBlockSnowForest, new Vector2(rid*16, chunk.LightPosFull*16));
												break;

											case (ushort)BlockId.GrassBlockHills:
												chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockSnow, (ushort)BlockId.GrassBlockSnowHills, new Vector2(rid*16, chunk.LightPosFull*16));
												break;

											case (ushort)BlockId.GrassBlockDesert:
												chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockSnow, (ushort)BlockId.GrassBlockSnowDesert, new Vector2(rid*16, chunk.LightPosFull*16));
												break;

											case (ushort)BlockId.GrassBlockJungle:
												chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockSnow, (ushort)BlockId.GrassBlockSnowJungle, new Vector2(rid*16, chunk.LightPosFull*16));
												break;
										} 
									}

									if (chunk.IsTopBlocks[chunk.StartSomething]) { 
										if (chunk.TopBlocks[chunk.StartSomething].Id!=(ushort)BlockId.SnowTop) {
											if (GameMethods.IsLeave(chunk.TopBlocks[chunk.StartSomething].Id)) {
												chunk.StartSomething--; 
												chunk.IsTopBlocks[chunk.StartSomething]=true;
												chunk.TopBlocks[chunk.StartSomething]=new NormalBlock(snowTopTexture, (ushort)BlockId.SnowTop, new Vector2(rid*16, chunk.StartSomething*16));
											} 

										
										}
									}
									if (chunk.IsSolidBlocks[chunk.StartSomething]) { 
										chunk.StartSomething--; 
										chunk.IsTopBlocks[chunk.StartSomething]=true;
										chunk.TopBlocks[chunk.StartSomething]=new NormalBlock(snowTopTexture, (ushort)BlockId.SnowTop, new Vector2(rid*16, chunk.StartSomething*16));
									}
								}
							}
						}
					}

					// Remove ice and snow
					if (Temperature>0.01f) {
						int rid=random.Int(BiomePlayer.End-BiomePlayer.Start)+BiomePlayer.Start;
						if (rid<TerrainLength) {
							Terrain chunk=terrain[rid];
							if (random.Float()<Temperature) {
								if (chunk.IsSolidBlocks[chunk.LightPosFull]) { 
									switch (chunk.SolidBlocks[chunk.LightPosFull].Id) {
										case (ushort)BlockId.GrassBlockSnowClay:
											chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockClay, (ushort)BlockId.GrassBlockClay, new Vector2(rid*16, chunk.LightPosFull*16));
											break;

										case (ushort)BlockId.GrassBlockSnowCompost: 
											chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockCompost, (ushort)BlockId.GrassBlockCompost, new Vector2(rid*16, chunk.LightPosFull*16));
											break;

										case (ushort)BlockId.GrassBlockSnowPlains:
											chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockPlains, (ushort)BlockId.GrassBlockPlains, new Vector2(rid*16, chunk.LightPosFull*16));
											break;

										case (ushort)BlockId.GrassBlockSnowForest:
											chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockForest, (ushort)BlockId.GrassBlockForest, new Vector2(rid*16, chunk.LightPosFull*16));
											break;

										case (ushort)BlockId.GrassBlockSnowHills:
											chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockHills, (ushort)BlockId.GrassBlockHills, new Vector2(rid*16, chunk.LightPosFull*16));
											break;

										case (ushort)BlockId.GrassBlockSnowDesert:
											chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockDesert, (ushort)BlockId.GrassBlockDesert, new Vector2(rid*16, chunk.LightPosFull*16));
											break;

										case (ushort)BlockId.GrassBlockSnowJungle:
											chunk.SolidBlocks[chunk.LightPosFull]=new NormalBlock(TextureGrassBlockJungle, (ushort)BlockId.GrassBlockJungle, new Vector2(rid*16, chunk.LightPosFull*16));
											break;
									} 
								}
							}

							int ry=random.Int(125-chunk.StartSomething)+chunk.StartSomething-1;
							if (chunk.IsSolidBlocks[ry]) { 
								if (chunk.SolidBlocks[ry].Id==(ushort)BlockId.Ice) { 
								
									// Remove ice
									chunk.IsSolidBlocks[ry]=false;
									chunk.SolidBlocks[ry]=null;
								
									// set water
									chunk.IsTopBlocks[ry]=true;
									chunk.TopBlocks[ry]=new Water(waterTexture,(ushort)BlockId.WaterBlock,new Vector2(rid*16, ry*16),255);
								} else if (chunk.SolidBlocks[ry].Id==(ushort)BlockId.Snow) { 
								
									// Remove snow
									chunk.IsSolidBlocks[ry]=false;
									chunk.SolidBlocks[ry]=null;
								} else if (chunk.SolidBlocks[ry].Id==(ushort)BlockId.SnowTop
									) { 
								
									// Remove snow
									chunk.IsSolidBlocks[ry]=false;
									chunk.SolidBlocks[ry]=null;
								}
							}
						}
					}

					foreach (ShortAndByte ch in Chargers) ChargerJob(ch);
					foreach (ShortAndByte ch in OxygenMachines) OxygenMachineJob(ch);
				   // foreach (ShortAndByte ch in Barrels) BarrelJob(ch);
					foreach (ShortAndByte ch in bucketRubber) {
					   if (BucketsForRubberJob(ch)) break;
					}

					if (rocket)  {
						if (rocketDown) {
							if (PlayerY>0) {
								rocket=false;
								PlayerY=0;
								InventoryAddOne((ushort)Items.Rocket);
								File.Delete(pathToWorld+"UseRocket.txt");
							}
						} else {
							if (PlayerY<=-10000) {
								Save();

									SaveSettings();
								//File.WriteAllText(pathToWorld+@"\Settings.txt",
								//    debug+"\r\n"+
								//    time+"\r\n"+
								// //   dayAlpha+"\r\n"+

								//    barWater+"\r\n"+
								//    barEat+"\r\n"+
								//    barHeart+"\r\n"+
								//    barOxygen+"\r\n"+

								//    PlayerX+"\r\n"+
								//    PlayerY+"\r\n"+
								//    changeRain+"\r\n"+
								//    moonSpeed);

								List<byte> bytes=new List<byte>();
								foreach (ItemInv x in InventoryNormal) x.SaveBytes(bytes);
								File.WriteAllBytes(pathToWorld+@"\Inventory.bin", bytes.ToArray());

								Rabcr.GoTo(new PlanetSystem(pathToWorld));
							}
						}
					}

					for (int x=terrainStartIndexX; x<terrainStartIndexW; x++)  {
						Terrain chunk;

						if ((chunk=terrain[x])!=null) {
							for (int y=chunk.StartSomething; y<100; y++) {
								if (chunk.IsTopBlocks[y]) {
									switch (chunk.TopBlocks[y].Id) {
										case (ushort)BlockId.SolarPanel:
											if (chunk.LightPosHalf+2>y) {
												if (dayAlpha>0.8f) NewEnergySolarPanel(x,y);
												else if (random.Double()<dayAlpha) {
													if (random.Bool_33_333Percent()) NewEnergySolarPanel(x,y);
												}
											}
											break;

										case (ushort)BlockId.Watermill:
											NewEnergyWatermill(x,y);
											break;

										case (ushort)BlockId.Windmill:
											if (notNeedScafander)NewEnergySolarPanel(x,y);
											break;
									}
								}
							}
						}
					}

					if (Global.HasSoundGraphics)  {
						if (MediaPlayer.State==MediaState.Stopped) {
							Song play/*=null*/;

							if (notNeedScafander) {
								switch (random.Int4()) {
									case 0: play=Songs.Happend;break;
									case 1: play = Songs.Medium; break;
									case 2: play = Songs.Root; break;
									default: play = Songs.Storm; break;
								}
							} else play = Songs.Spacelandia;

							MediaPlayer.Play(play);
						}
					}
				

					#region Time
					time++;//1hod=3000x zvýšení
					if (time==dayLenght) {
						day++;


						if (day>daysInYear) {
							day=0; 
							year++;
						}

						ChangeLeavesSomething();

						time=0;
					}

					// Sun rise

				//float baseDayAlpha=

					if (time>=hour*dayStart && time<=hour*(dayStart+1)) {
						dayAlpha=((time-hour*dayStart)/hour)*(1f-ConstNightAlpha)+ConstNightAlpha;

					// Sun setting
					} else if (time>hour*dayEnd && time<hour*(dayEnd+1)) {
						dayAlpha=(float)(hour*(dayEnd+1)-time)/hour*(1f-ConstNightAlpha)+ConstNightAlpha;
					} else if (time>=hour*(dayStart+1) && time<=hour*dayEnd) {

						// day
						if (dayAlpha!=1f) {
							dayAlpha=1f;
						}
					}
					else {

						// night
						if (dayAlpha!=ConstNightAlpha) {
							dayAlpha=ConstNightAlpha;
						}
					}


				//	if (rain) {
						//if (Temperature>0) { 
						float xpler=0;
						if (Temperature<10f)xpler=-(Temperature-10)/500f;

							float otp=dayAlpha*(1-rainWaveForce*0.05f*actualRainForce)*(1f-actualRainForce*0.05f/**0.75f*/)*(1f-xpler);
					//	Console.WriteLine("r "+otp);
							colorAlpha=new Color(otp, otp, otp, otp);
						//} else { 
						//	colorAlpha = new Color(otp, dayAlpha, dayAlpha, dayAlpha);
						//}
					//} else { 
					//	float otp=dayAlpha*(1f-actualRainForce*0.1f/**0.75f*/);
					//		Console.WriteLine("n "+otp);
					//	colorAlpha=new Color(otp, otp, otp, otp);

					//////	colorAlpha= new Color(dayAlpha, dayAlpha, dayAlpha, dayAlpha);
					//}

					moonSpeed += 368f/(7f*dayLenght);
					if (moonSpeed >= 368) moonSpeed = 0;
					#endregion

					#region Furnace Stone burning
					foreach (ShortAndByte d in FurnaceStone) {
						MashineBlockBasic block = (MashineBlockBasic)terrain[d.X].TopBlocks[d.Y];
						if (block==null) {
							FurnaceStone.Remove(d);
							break;
						}

						if (block.Inv[0].Id!=0 || block.Inv[1].Id!=0 || block.Inv[2].Id!=0) {
								if (block.Inv[3] is ItemInvBasic16 inv3)
									if (inv3.GetCount<99&&(inv3.Id==0||inv3.Id==(ushort)Items.Ash)) {
										//0
										int add = GameMethods.BurnWoodInFurnace(block.Inv[0].Id);
										if (add!=0) {
											if (add+block.Energy<100) {
												block.Energy+=add;

												switch (block.Inv[0]) {
													case ItemInvBasic16 inv0: {
														if (inv0.GetCount==1) {
															block.Inv[0]=itemBlank;
														} else {
															inv0.SetCount=inv0.GetCount-1;
														}
													}
													break;
												}

												if (block.Inv[3].Id==(ushort)Items.Ash) {
													ItemInvBasic16 o = (ItemInvBasic16)block.Inv[3];
													o.SetCount=o.GetCount+1;
												} else {
													block.Inv[3]=new ItemInvBasic16(ashTexture, (ushort)Items.Ash, 1, 0, 0);
												}

												// Ash
												if (random.Bool_33_333Percent()) {
													if (block.Inv[3].Id==(ushort)Items.Ash) {
														ItemInvBasic16 o = (ItemInvBasic16)block.Inv[3];
														o.SetCount=o.GetCount+1;
													} else {
														block.Inv[3]=new ItemInvBasic16(ashTexture, (ushort)Items.Ash, 1, 0, 0);
													}
												}
											}
										}
									}
							}

						if (block.Energy>0)block.Energy-=0.03f;
					}
					#endregion

					// Animatable
					if (wind) {
						if (windForce<1) {
							windForce+=.05f;
							SetWintableSources();
						}
					} else {
						if (windForce>0) {
							windForce-=.05f;
							SetWintableSources();
							if (random.Bool())windRirectionRight=!windRirectionRight;
						}
					}

					if (terrainStartIndexW-terrainStartIndexX>0) {
						#region Auto-destroy leaves
						AutoDestroyLeaves((ushort)BlockId.OakWood, (ushort)BlockId.OakLeaves);
						AutoDestroyLeaves((ushort)BlockId.SpruceWood, (ushort)BlockId.SpruceLeaves);
						AutoDestroyLeaves((ushort)BlockId.PineWood, (ushort)BlockId.PineLeaves);
						AutoDestroyLeaves((ushort)BlockId.LindenWood, (ushort)BlockId.LindenLeaves);

						AutoDestroyLeaves((ushort)BlockId.AppleWood, (ushort)BlockId.AppleLeaves, (ushort)BlockId.AppleLeavesWithApples);
						AutoDestroyLeaves((ushort)BlockId.PlumWood, (ushort)BlockId.PlumLeaves, (ushort)BlockId.PlumLeavesWithPlums);
						AutoDestroyLeaves((ushort)BlockId.CherryWood, (ushort)BlockId.CherryLeaves, (ushort)BlockId.CherryLeavesWithCherries);
						AutoDestroyLeaves((ushort)BlockId.OrangeWood, (ushort)BlockId.OrangeLeaves, (ushort)BlockId.OrangeLeavesWithOranges);
						AutoDestroyLeaves((ushort)BlockId.LemonWood, (ushort)BlockId.LemonLeaves, (ushort)BlockId.LemonLeavesWithLemons);
						AutoDestroyLeaves((ushort)BlockId.AcaciaWood, (ushort)BlockId.AcaciaLeaves);
						AutoDestroyLeaves((ushort)BlockId.EucalyptusWood, (ushort)BlockId.EucalyptusLeaves);
						AutoDestroyLeaves((ushort)BlockId.KapokWood, (ushort)BlockId.KapokLeacesFibre,(ushort)BlockId.KapokLeacesFlowering);
						AutoDestroyLeaves((ushort)BlockId.KapokWood, (ushort)BlockId.KapokLeaves);
						AutoDestroyLeaves((ushort)BlockId.MangroveWood, (ushort)BlockId.MangroveLeaves);
						AutoDestroyLeaves((ushort)BlockId.OliveWood, (ushort)BlockId.OliveLeaves,(ushort)BlockId.OliveLeavesWithOlives);
						AutoDestroyLeaves((ushort)BlockId.RubberTreeWood, (ushort)BlockId.RubberTreeWood);
						AutoDestroyLeaves((ushort)BlockId.WillowWood, (ushort)BlockId.WillowLeaves);
						#endregion

						// Start mooving
						MoveChicken();
						MoveRabbit();
						MoveParrot();

						// Finish mooving
						FinishMooving();
					}

					timer5=5;
				 } else timer5--;

				if (_secondTimer<0) {
					{
						// Descay
						DescayInventory(InventoryNormal);
						DescayInventory(InventoryClothes);

						int totalammo=TotalItemsInInventoryItemBasic16((ushort)Items.Ammo);
						if (totalammo>99)totalammo=99;
						if (totalammo==0) totalammo=1;
						foreach (ItemInv d in InventoryNormal) {
							if (d.Id==(ushort)Items.Gun) {
								ItemInvBasic16 gun=(ItemInvBasic16)d;
								gun.SetCount=totalammo;
							}
						}
					}
					if (!notNeedScafander) {
						if (Global.WorldDifficulty==0) {
							if (InventoryClothes[0].Id==(ushort)Items.SpaceHelmet
							&& InventoryClothes[1].Id==(ushort)Items.SpaceSuit
							&& InventoryClothes[4].Id==(ushort)Items.SpaceTrousers
							&& InventoryClothes[6].Id==(ushort)Items.SpaceBoots) {
								bool airj=false;

								foreach (ItemInv d in InventoryNormal) {
									if (d.Id==(ushort)Items.AirTank) {
										ItemInvTool32 airt=(ItemInvTool32)d;
										if (airt.GetCount>1) {
											if (random.Bool_11_111Percent()) {
												airt.SetCount=airt.GetCount-1;
											}
											airj=true;
											break;
										}
									}
								}
								if (!airj) {
									foreach (ItemInv d in InventoryNormal) {
										if (d.Id==(ushort)Items.AirTank2) {
											ItemInvTool32 airt=(ItemInvTool32)d;
											if (airt.GetCount>1) {
												if (random.Bool_5_555Percent()/* Int(18)==1*/) {
													airt.SetCount=airt.GetCount-1;
												}
												airj=true;
												break;
											}
										}
									}
								}
								if (!airj) {
									barOxygen+=0.25f;
									if (barOxygen>32) {
										barOxygen=32;
										barHeart+=0.3f;
										if (barHeart>32) {
											Die(Lang.Texts[297]);
										}
									}
								}
							} else {
								barHeart+=0.5f;
								if (barHeart>32) {
									Die(Lang.Texts[299]);
								}
							}
						}
					}

					Temperature=GetTemperature(BiomePlayer.Name);
									 

					for (int i=0; i<TerrainLength/100; i++) GrowTreeFood(i*100);

					if (random.Bool_20Percent()/* Int(5)==1*/) {
						for (int i = 0; i<chunksWithPlants.Count; i++) {
							foreach (Plant p in terrain[chunksWithPlants[i]].Plants) {
								if (p.Growing) p.Update();

								if (p.Growing) {
									if (terrain[p.chunkId].IsSolidBlocks[p.Height+1]) {
										if (terrain[p.chunkId].SolidBlocks[p.Height+1].Id==(ushort)BlockId.Compost) p.Update();
									}
								}
							}
						}
					}

					if (random.Bool_2Percent() /*Int(50)==1*/) {
						foreach (ShortAndByte p in Composters) {
							ShelfBlock block= (ShelfBlock)terrain[p.X].TopBlocks[p.Y];
							int i=random.Int(9);
							if (block.Inv[i].Id!=0) {
								if (GameMethods.IsCompostable(block.Inv[i].Id)) {
								 //   if (random.Int(block.Inv[i].Id)<=1) {
										block.Inv[i].Id=(ushort)Items.Compost;
								 //   }
								}
							}
						}
					}

					#region Bars
					if (barEat<5 && barWater<5) {
						barHeart-=.06f;
						if (barHeart<0) barHeart=0;
					}

					if (barEat>25 && barWater>25) {
						barHeart+=.06f;
						if (barHeart>32) Die(Lang.Texts[162]);
					}

					if (DetectLava) {
						barHeart+=.06f;
						if (barHeart>32) Die(Lang.Texts[163]);
					}

					if (barEnergy>31) {
						if (random.Bool_33_333Percent()/* Int(3)==1*/) {
							barHeart+=.01f;
							if (barHeart>32) Die(Lang.Texts[164]);
						}
					}
					#endregion

					if (debug) {
						if (cpu!=null) {
							usageCpuProcess=cpu.NextValue();
							usageCpu=cpuUsage.NextValue();
							usageRamProcess=ram.NextValue();
							usageRam=freeRam.NextValue();
						}
					}

					#region Weather
					if (changeRain<0) {
						changeRain=100+random.Int(50);
						if (rain) rain=false; else rain=true;
					} else changeRain--;

					if (timeToChageWind <0) {
						timeToChageWind = 2000 + random.Int(1000);
						wind=!wind;
						if (!wind){ 
							StopWavingTrees();
						}
					} else timeToChageWind--;

					
					#endregion

					#region Optimalize
					if (energy.Count>5000) energy.RemoveRange(5000, energy.Count-5000);
					#endregion

					switch (InventoryNormal[boxSelected].Id) {
						case (ushort)Items.TorchON:
							{
								ItemInvTool16 t=(ItemInvTool16)InventoryNormal[boxSelected];
								if (t.GetCount>1) {
									t.SetCount=t.GetCount-1;
								} else {
									InventoryAddOne((ushort)Items.Stick);
								}
								playerLight=true;
							}
							break;

						case (ushort)Items.TorchElectricON:
							{
								ItemInvTool32 t=(ItemInvTool32)InventoryNormal[boxSelected];
								if (t.GetCount>1) {
									t.SetCount=t.GetCount-1;
								} else {
									InventoryAddOne((ushort)Items.TorchElectricOFF);
								}
								playerLight=true;
							}
							break;

						default:
							playerLight=false;
							break;
					}


					foreach (ShortAndByte d in Miners) MinerJob(d);

					autoSave--;
					if (autoSave==0) {
						Save();

							SaveSettings();

						List<byte> bytes=new List<byte>();
						foreach (ItemInv x in InventoryNormal) x.SaveBytes(bytes);
						File.WriteAllBytes(pathToWorld+@"\Inventory.bin", bytes.ToArray());

						autoSave=300;
					}

					if (inventory==InventoryType.Radio) {
						try {
							if (Directory.Exists(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"\\RabcrData\\Default\\Songs\\Radio")) {
								radioSongs=Directory.GetFiles(new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName+"\\RabcrData\\Default\\Songs\\Radio");
								List<string> songs=new List<string>();
								foreach (string s in radioSongs) {
									if (s.EndsWith(".wma"))songs.Add(s);
								}
								radioSongs=songs.ToArray();
							}
						} catch { }
					}

					SetNeed();

					_secondTimer=60;
				} else _secondTimer--;

				if (cameraMove) CameraMatrix();
			}
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime) {
			if (dontDoGame) return;

			Rabcr.spriteBatch=spriteBatch;

			#region Died
			if (died) {
				Graphics.SetRenderTarget(null);
				Graphics.Clear(Color.DarkRed);
				spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
				float a;
				if (timerStayDied>200)a=1-(timerStayDied-200)/110f;
				else if (timerStayDied<100)a=timerStayDied/100f;
				else a=1;
				string m=Lang.Texts[28];
				string respawntext=Lang.Texts[29]+" "+(int)((timerStayDied/(60/2)+1));
				int meas=BitmapFont.bitmapFont18.MeasureTextSingleLineX(m);
				textDie=new Text(m,Global.WindowWidthHalf-meas/2,Global.WindowHeightHalf-60,BitmapFont.bitmapFont18);
				textDie.Draw(spriteBatch);

				int textDieInfom=BitmapFont.bitmapFont18.MeasureTextSingleLineX(diedInfo);
				textDieInfo=new Text(diedInfo,Global.WindowWidthHalf-textDieInfom/2,Global.WindowHeightHalf,BitmapFont.bitmapFont18);
				textDieInfo.Draw(spriteBatch, ColorWhite*a);

				int respawntextm=BitmapFont.bitmapFont18.MeasureTextSingleLineX(respawntext);
				textRespawnIn=new Text(respawntext,Global.WindowWidthHalf-respawntextm/2,Global.WindowHeightHalf+30,BitmapFont.bitmapFont18);
				textRespawnIn.Draw(spriteBatch, ColorWhite*a);

				spriteBatch.End();
			} else {
				#endregion

				#region Draw lighting

				// Draw full lights
				Graphics.SetRenderTarget(sunLightTarget);
				Graphics.Clear(black);
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, camera);

                foreach (Rectangle r in lightsFull) spriteBatch.Draw(lightMaskLineTexture, r, ColorWhite);

                for (int x = terrainStartIndexX>1 ? terrainStartIndexX-2:terrainStartIndexX; x<terrainStartIndexW; x++) {
                    Terrain chunk = terrain[x];
                    spriteBatch.Draw(/*pixel*/lightMaskTexture, new Vector2(chunk.LightVec.X, chunk.LightVec.Y), ColorWhite);
                }
                spriteBatch.End();

				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
				spriteBatch.Draw(pixel, new Rectangle(0, 0, Global.WindowWidth,Global.WindowHeight), new Color(0,0,0,50));
				spriteBatch.End();

				// Draw high light
				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, camera);
				
				foreach (Rectangle r in lightsHalf) spriteBatch.Draw(lightMaskLineTexture, r, ColorWhite);

				for (int x= terrainStartIndexX>1 ? terrainStartIndexX-2:terrainStartIndexX; x<terrainStartIndexW; x++) {
					Terrain chunk=terrain[x];
					spriteBatch.Draw(lightMaskTexture, new Vector2(chunk.LightVec.X, chunk.LightPosHalf16), ColorWhite);
				}
				spriteBatch.End();

				// Draw with shadows

				//Graphics.SetRenderTarget(sunLightTarget);
				//Graphics.Clear(black);
				//spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, camera);
				
				//foreach (Rectangle r in lightsFull) spriteBatch.Draw(lightMaskLineTexture, r, ColorWhite);
				//foreach (Rectangle r in lightsHalf) spriteBatch.Draw(lightMaskLine2Texture, r, ColorWhite*0.6f);

				//for (int x= terrainStartIndexX; x<terrainStartIndexW; x++) {
				//	Terrain chunk=terrain[x];
				//	if (chunk.Half) {
				//		spriteBatch.Draw(lightMask2Texture, new Vector2(chunk.LightVec.X,   chunk.LightVec.Y/*-8*/), ColorWhite*0.6f);
				//		spriteBatch.Draw(/*pixel*/lightMaskTexture, new Vector2(chunk.LightVec.X, chunk.LightPosHalf16), ColorWhite);
				//	} else spriteBatch.Draw(lightMaskTexture, chunk.LightVec, ColorWhite);
				//}
			
				//spriteBatch.End();

				// Modificate sunlight target with lamp's, lorch's or fireplace's lights
				Graphics.SetRenderTarget(modificatedLightTarget);
				spriteBatch.Begin();
				spriteBatch.Draw(sunLightTarget, Vector2Zero, colorAlpha);
				spriteBatch.End();

				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, camera);

				foreach (MashineBlockBasic m in lightsLamp) {
					if (m.Position.X>=terrainStartIndexX*16) {
						if (m.Position.X<=terrainStartIndexW*16) {
							if (m.Position.Y>=terrainStartIndexY*16) {
								if (m.Position.Y<=terrainStartIndexH*16) {
									if (m.Energy>0) {
										m.Energy-=0.01f;
										if (m.Energy<0) m.Energy=0;
										spriteBatch.Draw(lightMaskRoundTexture, new Rectangle((int)m.Position.X-48*2*2+8, (int)m.Position.Y-48*2*2+8, 96*2*2, 96*2*2), lampColorLight);
									}
								}
							}
						}
					}
				}

				if (playerLight) spriteBatch.Draw(lightMaskRoundTexture, new Rectangle((int)PlayerX-48*2+8, (int)PlayerY-48*2+8, 96*2, 96*2), lampColorLight);
				spriteBatch.End();
				#endregion

				#region Draw game
		   
				Graphics.SetRenderTarget(null);
  
				#region Draw background
				if (changeRain<10) {
					if (rain) { 
						Graphics.Clear(FastMath.Lerp(GetColorBackNoRain(), GetColorBackRain(), changeRain/10f));
					} else {
						Graphics.Clear(FastMath.Lerp(GetColorBackRain(), GetColorBackNoRain(), changeRain/10f));
					}
				} else { 
					if (rain) { 
						Graphics.Clear(GetColorBackRain());
					} else { 
						Graphics.Clear(GetColorBackNoRain());
					}
				}
                //// Day
                //if (time>=(dayStart+1)*hour && time<=dayEnd*hour) {
                //	Graphics.Clear(Color.LightSkyBlue); 

                //// Night
                //} else if (time<=dayStart*hour || time>=(dayEnd+1)*hour) {
                //	Graphics.Clear(ColorNightColorBack);

                // Sun rising (before sun)
  if (Constants.AnimationsGame) {
           /* } else */if (time>=dayStart*hour&&time<=(dayStart+0.5f)*hour) {
             //   if (Constants.AnimationsGame) {
                    float a = -(dayStart*hour-time)/(hour);
                  //  Graphics.Clear(FastMath.Lerp(ColorNightColorBack, Color.LightSkyBlue, a));
                    spriteBatch.Begin();
                    spriteBatch.Draw(TextureSunGradient, Fullscreen, ColorWhite*a);
                    spriteBatch.End();
               // } else Graphics.Clear(FastMath.Lerp(ColorNightColorBack, Color.LightSkyBlue, -(dayStart*hour-time)/(hour)));

            } else if (time>=(dayStart+0.5f)*hour&&time<=(dayStart+1)*hour) {

                // Sun rising (before sun)
               // if (Constants.AnimationsGame) {
                    float a = 0.5f+((dayStart+0.5f)*hour-time)/hour;
                 //   Debug.WriteLine(a);
                   // Graphics.Clear(FastMath.Lerp(Color.LightSkyBlue, ColorNightColorBack, a));
                    spriteBatch.Begin();
                    spriteBatch.Draw(TextureSunGradient, Fullscreen, ColorWhite*a);
                    spriteBatch.End();
                //} else Graphics.Clear(FastMath.Lerp(Color.LightSkyBlue, ColorNightColorBack, 0.5f+((dayStart+0.5f)*hour-time)/hour));

            } else if (time>=dayEnd*hour&&time<=(dayEnd+0.5f)*hour) {

                // Sun setting
              //  if (Constants.AnimationsGame) {
                    float a = 0.5f-((dayEnd+0.5f)*hour-time)/(hour*2);
                 //   Graphics.Clear(FastMath.Lerp(Color.LightSkyBlue, ColorNightColorBack, a));
                    spriteBatch.Begin();
                    spriteBatch.Draw(TextureSunGradient, Fullscreen, ColorWhite*a);
                    spriteBatch.End();
              //  } else Graphics.Clear(FastMath.Lerp(Color.LightSkyBlue, ColorNightColorBack, 0.5f-((dayEnd+0.5f)*hour-time)/(hour*2)));

            } else if (time>=(dayEnd+0.5f)*hour&&time<=(dayEnd+1)*hour) {

                // Sun setting
               // if (Constants.AnimationsGame) {
                   float a = ((dayEnd+1)*hour-time)/(hour*2);
                 //   Graphics.Clear(FastMath.Lerp(ColorNightColorBack, Color.LightSkyBlue, a));
                    spriteBatch.Begin();
                    spriteBatch.Draw(TextureSunGradient, Fullscreen, ColorWhite*a);
                    spriteBatch.End();
              //  } else Graphics.Clear(FastMath.Lerp(ColorNightColorBack, Color.LightSkyBlue, ((dayEnd+1)*hour-time)/(hour*2)));

            }
				}
            #endregion

				#region Clouds
				if (Constants.AnimationsGame) {
					int CloudsHeight=250;
					float sc=0.4f;
					float CloudsSourceScale=0.2f;

					float TextureCloudsSourcePosX =( (WindowX/(TerrainLength*16f)) * (TextureClouds.Width-(int)(Global.WindowWidth*CloudsSourceScale)) );

					float TextureCloudsSourcePosY=0;
				  //  if (time<12) TextureCloudsSourcePosY=((float)time/(12*hour)/*WindowX/(TerrainLength*16f)*/)*(TextureClouds.Height-(int)(CloudsHeight*CloudsSourceScale));
				   // else TextureCloudsSourcePosY=((float)(24*hour-time)/(12*hour)/*WindowX/(TerrainLength*16f)*/)*(TextureClouds.Height-(int)(CloudsHeight*CloudsSourceScale));
					Color ColorColorize=ColorWhite;

					// Night
					if (time<=dayStart*hour || time>=(dayEnd+1)*hour) {
						if (rain) {
							if (moonSpeed/46<4) ColorColorize=FastMath.Lerp(Color.DarkGray, ColorNightRain, moonSpeed/(46*4));
							else ColorColorize=FastMath.Lerp(Color.DarkGray, ColorNightRain, 1-moonSpeed/(46*4));
						} else {
							if (moonSpeed/46<4) ColorColorize=FastMath.Lerp(Color.DarkGray, ColorNight, moonSpeed/(46*4));
							else ColorColorize=FastMath.Lerp(Color.DarkGray, ColorNight, 1-moonSpeed/(46*4));
						}

					// Day
					} else if (time>=7f*hour && time<=17f*hour) {
						if (rain) {
							if (changeRain<100) {
								ColorColorize=FastMath.Lerp(ColorDayRain,ColorDay, changeRain/100f);
							} else ColorColorize=ColorDayRain;
						} else {
							if (changeRain<100) { 
								ColorColorize=FastMath.Lerp(ColorDay, ColorDayRain, changeRain/100f);
							} else ColorColorize=ColorDay;
						}

					// Sun rise
					} else if (time>=dayStart*hour && time<=(dayStart+0.5f)*hour){ 
						if (rain) {
							 ColorColorize=FastMath.Lerp(ColorNightRain, ColorSunRain, (time-dayStart*hour)/(hour*2));
						} else {
							 ColorColorize=FastMath.Lerp(ColorNight, ColorSun, (time-dayStart*hour)/(hour*2));
						}
					} else if (time>=(dayStart+0.5f)*hour && time<=(dayStart+1)*hour){ 
						if (rain) {
							 ColorColorize=FastMath.Lerp(ColorDayRain, ColorSunRain, 1-(time-(dayStart+0.5f)*hour)/(hour*2));
						} else {
							 ColorColorize=FastMath.Lerp(ColorDay, ColorSun, 1-(time-(dayStart+0.5f)*hour)/(hour*2));
						}

					// Sun setting
					} else if (time>=dayEnd*hour && time<=(dayEnd+0.5f)*hour) { 
						if (rain) {
							 ColorColorize=FastMath.Lerp(ColorDayRain, ColorSunRain, (time-dayEnd*hour)/(hour*2));
						} else {
							 ColorColorize=FastMath.Lerp(ColorDay, ColorSun, (time-dayEnd*hour)/(hour*2));
						}
					} else if (time>=(dayEnd+0.5f)*hour && time<=(dayEnd+1)*hour) { 
						if (rain) {
							 ColorColorize=FastMath.Lerp(ColorNightRain, ColorSunRain, 1-(time-(dayEnd+0.5f)*hour)/(hour*2));
						} else {
							 ColorColorize=FastMath.Lerp(ColorNight, ColorSun, 1-(time-(dayEnd+0.5f)*hour)/(hour*2));
						}
					} 

					float starty=(float)TextureCloudsSourcePosY/TextureClouds.Height/*CloudsHeight*/;
					EffectClouds.Parameters["StartY"].SetValue(starty);
					EffectClouds.Parameters["ColorIntestityMultipler"].SetValue(1f);
					EffectClouds.Parameters["EndY"].SetValue(starty+(CloudsHeight*CloudsSourceScale)/TextureClouds.Height/*(float)TextureCloudsSourcePosY/TextureClouds.Height*//*CloudsHeight*/ /*+ (float)((int)(CloudsHeight*CloudsSourceScale))/TextureClouds.Height*/);

					EffectClouds.Parameters["EndSize"].SetValue(sc*/*(TextureCloudsSourcePosY/TextureClouds.Height)*/CloudsSourceScale);
					EffectClouds.Parameters["ColorBase"].SetValue(ColorColorize.ToVector4());
					EffectClouds.Parameters["SourcePosSmoothCorrentor"].SetValue(new Vector2(
						(TextureCloudsSourcePosX-(int)TextureCloudsSourcePosX)/TextureClouds.Width,
						(TextureCloudsSourcePosY-(int)TextureCloudsSourcePosY)/TextureClouds.Height
					));

					EffectClouds.Parameters["Intestity"].SetValue(0.6f);
					float angle = time/(24f*hour)*2*FastMath.PI;

					float adder = 0f;
					if (time<=dayStart*hour||time>=dayEnd*hour) {
						adder=-5f;
					} else if (time>=(dayStart+1)*hour&&time<=(dayEnd+1)*hour) {
						adder=5f;
					} else if (time>=dayStart*hour&&time<=(dayStart+1)*hour) {
						adder=(time-dayStart*hour)/hour*10f-5f;
					} else if (time>=dayEnd*hour&&time<=(dayEnd+1)*hour) {
						adder=5f-(time-dayEnd*hour)/hour*10f;
					}

					EffectClouds.Parameters["SunAngle"].SetValue(new Vector2((float)Math.Cos(angle)*adder/TextureClouds.Width, (float)Math.Sin(angle)*adder/TextureClouds.Height));


					//  Biome biome=GetBiomeByPos((int)(PlayerX/16));

					if (BiomePlayer.Name!=BiomeCurrent || BiomePlayer.Name==Biome.None) {
						ColorLastBiome=ColorBiome;
						TicksPlayerChangedBiome=60;
						BiomeCurrent=BiomePlayer.Name;
					}

					if (TicksPlayerChangedBiome>0) {
						TicksPlayerChangedBiome--;
						ColorBiome=FastMath.Lerp(BiomeColor(BiomePlayer.Name), ColorLastBiome, TicksPlayerChangedBiome/60f);
					}
					spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, EffectClouds);
					EffectClouds.Techniques[0].Passes[0].Apply();

					spriteBatch.Draw(TextureClouds,
						new Rectangle(
							0,
							-(int)((WindowCenterY-831+200-100)*0.5f),
							Global.WindowWidth,
							CloudsHeight
						),
						new Rectangle(
							(int)TextureCloudsSourcePosX,
							(int)TextureCloudsSourcePosY,
							(int)(Global.WindowWidth*CloudsSourceScale),
							(int)(CloudsHeight*CloudsSourceScale)
						), 
						ColorBiome
					);

					spriteBatch.End();
				}
				#endregion

				#region Weather
				if (/*rain*/actualRainForce>0f) {
				//	int x, y;
					spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.AnisotropicClamp, null, null, null, CameraMatrixNoZoom(out int x, out int y));

					Rabcr.spriteBatch=spriteBatch;
					if (Temperature<0) {
						foreach (ParticleSnow r in snowDots)  r.Draw(x, y,actualRainForce); 
					} else {
						foreach (ParticleRain r in rainDots) r.Draw(x, y,actualRainForce);
					}
					spriteBatch.End();
				}
				#endregion

				spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera);
				float sunAngle=0;
				if (Constants.AnimationsGame) {
					if (time>6.5f*hour && time<18.5f*hour) {
						/*float*/ sunAngle=((time-6.5f*hour)/(12*hour))*FastMath.PI+FastMath.PI; // 0 až 1
						float c=(Global.WindowWidthHalf<Global.WindowHeightHalf ? Global.WindowWidthHalf : Global.WindowHeightHalf)*.5f;
						byte colorch=(byte)((dayAlpha-0.75f)*4f*255);
						spriteBatch.Draw(sunTexture, new Vector2(WindowCenterX-sunTexture.Width/2+(float)Math.Cos(sunAngle)*c, WindowCenterY-sunTexture.Height/2+FastMath.Sin(sunAngle)*c), new Color(colorch,colorch,colorch,colorch));
					}else if (time<6.5f*hour) {
						/*float*/ sunAngle=((time/(6f*hour))*FastMath.PI)*.5f+FastMath.PI1_5; // 0 až 1
						byte colorch=(byte)(1-(dayAlpha-0.5f)*4f*255);
						float c=(Global.WindowWidthHalf<Global.WindowHeightHalf ? Global.WindowWidthHalf : Global.WindowHeightHalf)*.5f;
						spriteBatch.Draw(TextureMoon, new Vector2(WindowCenterX-23+(float)Math.Cos(sunAngle)*c, WindowCenterY-23+FastMath.Sin(sunAngle)*c),new Rectangle(((int)moonSpeed/46)*46,0,46,46), new Color(colorch,colorch,colorch,colorch));
					}else if (time>18.5f*hour) {
						/*float*/ sunAngle=((time-18.5f)/(6f*hour)*FastMath.PI)+FastMath.PI; // 0 až 1
						byte colorch=(byte)(1-(dayAlpha-0.5f)*4f*255);
						float c=(Global.WindowWidthHalf<Global.WindowHeightHalf ? Global.WindowWidthHalf : Global.WindowHeightHalf)*.5f;
						spriteBatch.Draw(TextureMoon, new Vector2(WindowCenterX-23+(float)Math.Cos(sunAngle)*c, WindowCenterY-23+FastMath.Sin(sunAngle)*c),new Rectangle((int)moonSpeed/46*46,0,46,46), new Color(colorch,colorch,colorch,colorch));
					}
				}

				if (wind) {
					int x=0;
					int ms=(int)gameTime.TotalGameTime.TotalMilliseconds;
					foreach (LiveObject lo in LiveObjects) { 
						if (lo.Root.X>terrainStartIndexX-10) {
							if (lo.Root.X>terrainStartIndexW+10) break;

							if (lo is Tree tree) {
								x+=133;

								float a=((ms+x)/1000f)*2*FastMath.PI;
								float val=((float)Math.Sin(a)+(float)Math.Sin(a*0.5f+(FastMath.PI/4))*0.5f-1.5f)*0.015f;
							
								if (windRirectionRight) tree.angle=val;
								else tree.angle=-val;
							} else if (lo is Cactus cactus) {
								x+=133;
								float a=((ms+x)/1000f)*2*FastMath.PI;
								float val=((float)Math.Sin(a)+(float)Math.Sin(a*0.5f+(FastMath.PI/4))*0.5f-1.5f)*0.015f;
							
								if (windRirectionRight) cactus.angle=val;
								else cactus.angle=-val;

								// if (cactus.Root.X<terrainStartIndexW+10) break;
						  //  }
							}
						}
					}
				}

				#region Draw blocks
				int[] starts=new int[terrainStartIndexW];
			 
				// Back and solid
				for (int x = terrainStartIndexX; x<terrainStartIndexW; x++) {
					Terrain chunk=terrain[x];
					Block[] blocks=chunk.SolidBlocks;
					starts[x]=chunk.StartSomething>terrainStartIndexY? chunk.StartSomething: terrainStartIndexY;

					for (int y = starts[x]/*chunk.StartSomething>terrainStartIndexY? chunk.StartSomething: terrainStartIndexY*/; y<terrainStartIndexH; y++) {
						
						//blocks[y].Draw(); 
						if (chunk.IsBackground[y]) chunk.Background[y].Draw(); 
					}
				}

				// top and mobs
				for (int x = terrainStartIndexX; x<terrainStartIndexW; x++) {
					Terrain chunk=terrain[x];
					Block[] blocks=chunk.TopBlocks;
					for (int y = starts[x]/*chunk.StartSomething>terrainStartIndexY? chunk.StartSomething: terrainStartIndexY*/; y<terrainStartIndexH; y++) {
						if (chunk.IsSolidBlocks[y]) chunk.SolidBlocks[y].Draw(); 
						else if (chunk.IsTopBlocks[y]) blocks[y].Draw(); 
					}
				
					for (int i=0; i<chunk.Plants.Count; i++) chunk.Plants[i].Draw();
					for (int i=0; i<chunk.Mobs.Count; i++) chunk.Mobs[i].Draw();
				}

				#endregion

				foreach (FallingLeave fl in FallingLeaves) fl.Draw();

				foreach (GunShot gs in GunShots) gs.Draw();
			 
				if (destroing) spriteBatch.Draw(destructionTexture, new Vector2(mousePosRoundX, mousePosRoundY), new Rectangle((int)(destroingIndex/destringMaxIndex*336)/16*16,0,16,16),ColorWhite);

				// Draw items
				foreach (Item i in DroppedItems) i.DrawItem();

				#region Player
				if (rocket) {
					if (rocketDown) {
						spriteBatch.Draw(solidFuelSmokeTexture, new Rectangle((int)WindowCenterX-10, (int)WindowCenterY-40+rocketTexture.Height-10,26,20+random.Int(10)), ColorWhite);
						spriteBatch.Draw(rocketTexture, new Vector2(WindowCenterX-10, WindowCenterY-40), ColorWhite);
					} else {
						spriteBatch.Draw(solidFuelSmokeTexture, new Rectangle((int)WindowCenterX-10, (int)WindowCenterY-40+rocketTexture.Height-10,26,70+random.Int(15)), ColorWhite);
						spriteBatch.Draw(rocketTexture, new Vector2(WindowCenterX-10, WindowCenterY-40), ColorWhite);
					}

				} else if (showPlayer) {
					if (swimming || waterDown) {
						if (speedDir==-1) {
							// <-
							Rectangle curImg=new Rectangle(playerImg/22*39, 0, 39, 20);
							Vector2 vector=new Vector2(PlayerX-11, PlayerY+8);

							Vector2 vectorHead=new Vector2(PlayerX-11+78/2, PlayerY+8);
							Vector2 vectorChest=new Vector2(PlayerX-11+78/2-75/2-1, PlayerY+8+58/2-3-2);

							Vector2 rameno=new Vector2(vector.X-11+2+1+27/2-2+7/*?*/, vector.Y-39/2+12-1+38/2);
							handAngle=(1-swimmingTicks)*2*FastMath.PI;

							Rectangle recHand, recCloth;
							Vector2 vecOrigin;

							if (ClothesChestTop is null) {
								if (ClothesChest is null) DrawItemInHandBack(null, Color.White, 0);
								else DrawItemInHandBack(ClothesChest.Texture2DClothHand, ClothesChest.Color,(int)ClothesChest.handSize);
							} else DrawItemInHandBack(ClothesChestTop.Texture2DClothHand, ClothesChestTop.Color,(int)ClothesChestTop.handSize);

							//Feet
							if (ClothesFeet!=null) spriteBatch.Draw(ClothesFeet.TextureSwimming, vector, curImg, ClothesFeet.Color, 0, Vector2Zero, 1,SpriteEffects.None, 1f);
							else spriteBatch.Draw(TexturePlayerSwimmingFeet, vector, curImg, ColorWhite, 0, Vector2Zero, 1, SpriteEffects.None, 0);

							// Legs
							if (ClothesLegs!=null) {
								if (ClothesLegs.ShowBodyLegs) spriteBatch.Draw(TexturePlayerSwimmingLegs, vector, curImg, Setting.ColorSkin);
								spriteBatch.Draw(ClothesLegs.TextureSwimming, vector, curImg, ClothesLegs.Color, 0, Vector2Zero, 1, SpriteEffects.None, 0);
							} else {
								spriteBatch.Draw(TexturePlayerSwimmingLegs, vector, curImg, Setting.ColorSkin, 0, Vector2Zero, 1, SpriteEffects.None, 0);
								if (ClothesUnderwearDown!=null) {
									if (ClothesChest==null) spriteBatch.Draw(ClothesUnderwearDown.TextureSwimming, vector, curImg, ClothesUnderwearDown.Color, 0, Vector2Zero, 1, SpriteEffects.None, 0);
									else if (!ClothesChest.IsDress) spriteBatch.Draw(ClothesUnderwearDown.TextureSwimming, vector, curImg, ClothesUnderwearDown.Color, 0, Vector2Zero, 1, SpriteEffects.None, 0);
								} else {
									if (Global.YoungPlayer) spriteBatch.Draw(TextureSwimmingDownCensored, vector, null, ColorWhite, 0, Vector2Zero, 1, SpriteEffects.None, 0);
								}
							}

							//Head
							spriteBatch.Draw(TexturePlayerWalkingFace, vectorHead, null, Setting.ColorSkin, FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.FlipVertically, 0);
							spriteBatch.Draw(TexturePlayerWalkingEyes, vectorHead, null, Setting.eyesColor, FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.FlipVertically, 0);
							spriteBatch.Draw(TexturePlayerWalkingMouth, vectorHead, null, ColorWhite, FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.FlipVertically, 0);
							if (Setting.moustageType!=0)spriteBatch.Draw(TexturePlayerWalkingMoustage, vectorHead, null, Setting.moustageColor, FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.FlipVertically, 0);
							if (Setting.hairType!=0)spriteBatch.Draw(TexturePlayerWalkingHair, vectorHead, null, Setting.hairColor, FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.FlipVertically, 0);

							if (ClothesHead!=null) spriteBatch.Draw(ClothesHead.TextureWalkingOrSwimming, new Vector2(vectorHead.X-78/2, vectorHead.Y+46/2), null, ClothesHead.Color, FastMath.PIHalf*3, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);

							// Chest
							if (ClothesChestTop is null || ClothesChestTop?.ShowTShirt==true) {
								if (ClothesChest!=null) spriteBatch.Draw(ClothesChest.TextureWalking, /*new Vector2(vectorChest.X,vectorChest.Y-2)*/ vectorChest, null, ClothesChest.Color, FastMath.PI1_5, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
								else {
									spriteBatch.Draw(TexturePlayerWalkingChest, vectorChest, null, Setting.ColorSkin, FastMath.PI1_5, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
									if (ClothesUnderwearUp!=null) spriteBatch.Draw(ClothesUnderwearUp.TextureSwimming/*TextureWalking*/, new Vector2(vector.X,vector.Y-2)/*vectorChest*/, null, ClothesUnderwearUp.Color, 0,/*FastMath.PIHalf,*/ Vector2Zero, 1, SpriteEffects.None/*.FlipHorizontally*/, 0);
									else {
										if (Setting.sex==Sex.Girl) {
											if (Global.YoungPlayer) {
												if (Setting.MaturePlayer>0) spriteBatch.Draw(TextureSwimmingUpCensored, vector, null, ColorWhite, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
											}
										}
									}
								}
							}
							if (ClothesChestTop!=null) spriteBatch.Draw(ClothesChestTop.TextureWalking, vectorChest, null, ClothesChestTop.Color, FastMath.PI1_5, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
							if (ClothesChestTop is null) {
								if (ClothesChest is null) DrawItemInHandTop(null, Color.White, 0);
								else DrawItemInHandTop(ClothesChest.Texture2DClothHand, ClothesChest.Color,(int)ClothesChest.handSize);
							} else DrawItemInHandTop(ClothesChestTop.Texture2DClothHand, ClothesChestTop.Color,(int)ClothesChestTop.handSize);

							void DrawItemInHandTop(Texture2D texCloth, Color colorCloth, int size){
								spriteBatch.Draw(TextureHand, rameno, recHand, Setting.ColorSkin, handAngle, vecOrigin, 1, SpriteEffects.None,1f);
								if (texCloth!=null)spriteBatch.Draw(texCloth, rameno, recCloth, colorCloth, handAngle, Vector2_2, 1, SpriteEffects.None,1f);

								if (InventoryNormal[boxSelected]!=null){
									if (InventoryNormal[boxSelected].Id!=0) {
										Rectangle recItem=new Rectangle(
											(int)(((float)Math.Cos(handAngle+FastMath.PIHalf)*(HandSize-4))+rameno.X-4),
											(int)(((float)Math.Sin(handAngle+FastMath.PIHalf))*(HandSize-4)+rameno.Y-4),
											8,
											8
										);

										switch (InventoryNormal[boxSelected]) {
											case ItemInvBasic16 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											case ItemInvBasic32 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											case ItemInvBasicColoritzed32NonStackable i:
												spriteBatch.Draw(i.Texture, recItem, i.color);
												break;

											case ItemInvFood16 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											case ItemInvFood32 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											case ItemInvNonStackable32 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											case ItemInvNonStackable16 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

												case ItemInvTool16 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

												case ItemInvTool32 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											#if DEBUG
											default: throw new Exception("Unknown category");
											#endif
										}
									}
								}
							}

							void DrawItemInHandBack(Texture2D texCloth, Color colorCloth, int size){
								recHand = new Rectangle(0,0,4,HandSize-size);
								vecOrigin=new Vector2(2,2-size);
								recCloth =new Rectangle(0,0,4,size);

								spriteBatch.Draw(
									TextureHand, 
									rameno, 
									recHand, 
									new Color(
										(byte)(Setting.ColorSkin.R*0.75f), 
										(byte)(Setting.ColorSkin.G*0.75f), 
										(byte)(Setting.ColorSkin.B*0.75f),
										(byte)255
									), 
									handAngle-FastMath.PI, 
									vecOrigin, 
									1f, 
									SpriteEffects.None,
									1f);
								if (texCloth!=null) spriteBatch.Draw(texCloth, rameno, recCloth, new Color((byte)(colorCloth.R*0.75f),(byte)(colorCloth.G*0.75f),(byte)(colorCloth.B*0.75f),(byte)255), handAngle-FastMath.PI, Vector2_2, 1, SpriteEffects.None,1f);
							}
						} else {
							//->
							Rectangle curImg=new Rectangle(playerImg/22*39, 0, 39, 20);
							Vector2 vector=new Vector2(PlayerX-11-15-3, PlayerY+8);
							Vector2 vectorHead=new Vector2(PlayerX-11+46/2, PlayerY+8);
							Vector2 vectorChest=new Vector2(PlayerX-11-22+44, PlayerY+8+2-3+2);

							Vector2 rameno=new Vector2(vector.X-11+2+1+27/2-2+7+20, vector.Y-39/2+12-1+38/2);
							handAngle=swimmingTicks*2*FastMath.PI;

							Rectangle recHand, recCloth;
							Vector2 vecOrigin;

							if (ClothesChestTop is null) {
								if (ClothesChest is null) DrawItemInHandBack(null, Color.White, 0);
								else DrawItemInHandBack(ClothesChest.Texture2DClothHand, ClothesChest.Color,(int)ClothesChest.handSize);
							} else DrawItemInHandBack(ClothesChestTop.Texture2DClothHand, ClothesChestTop.Color,(int)ClothesChestTop.handSize);
							
							//feet
							if (ClothesFeet!=null) spriteBatch.Draw(ClothesFeet.TextureSwimming, vector, curImg, ClothesFeet.Color, 0, Vector2Zero, 1,SpriteEffects.FlipHorizontally, 1f);
							else spriteBatch.Draw(TexturePlayerSwimmingFeet, vector, curImg, ColorWhite, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);

							// legs
							if (ClothesLegs!=null) {
								if (ClothesLegs.ShowBodyLegs) spriteBatch.Draw(TexturePlayerSwimmingLegs, vector, curImg, Setting.ColorSkin, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
								spriteBatch.Draw(ClothesLegs.TextureSwimming, vector, curImg, ClothesLegs.Color, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
							} else {
								spriteBatch.Draw(TexturePlayerSwimmingLegs, vector, curImg, Setting.ColorSkin, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
								if (ClothesUnderwearDown!=null) {
									if (ClothesChest==null) spriteBatch.Draw(ClothesUnderwearDown.TextureSwimming, vector, curImg, ColorWhite, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
									else if (!ClothesChest.IsDress) spriteBatch.Draw(ClothesUnderwearDown.TextureSwimming, vector, curImg, ColorWhite, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
								} else {
									if (Global.YoungPlayer) spriteBatch.Draw(TextureSwimmingDownCensored, vector, null, ColorWhite, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
								}
							}

							// Head
							spriteBatch.Draw(TexturePlayerWalkingFace, vectorHead, null, Setting.ColorSkin,FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.None, 0);
							if (Setting.moustageType!=0)spriteBatch.Draw(TexturePlayerWalkingMoustage, vectorHead, null, Setting.moustageColor,FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.None, 0);
							spriteBatch.Draw(TexturePlayerWalkingMouth, vectorHead, null, ColorWhite,FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.None, 0);
							if (Setting.hairType!=0)spriteBatch.Draw(TexturePlayerWalkingHair, vectorHead, null, Setting.hairColor,FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.None, 0);
							spriteBatch.Draw(TexturePlayerWalkingEyes, vectorHead, null, Setting.eyesColor,FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.None, 0);

							if (ClothesHead!=null) spriteBatch.Draw(ClothesHead.TextureStatic, vectorHead, null, ClothesHead.Color, FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.None, 0);

							//Chest
							if (ClothesChestTop is null || ClothesChestTop?.ShowTShirt==true) {
								if (ClothesChest!=null) spriteBatch.Draw(ClothesChest.TextureWalking, /*vectorChest*/new Vector2(vectorChest.X, vectorChest.Y-2), null, ClothesChest.Color, FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
								else {
									spriteBatch.Draw(TexturePlayerWalkingChest, vectorChest, null, Setting.ColorSkin, FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.None, 0);
									if (ClothesUnderwearUp!=null) spriteBatch.Draw(ClothesUnderwearUp.TextureSwimming,new Vector2(vector.X-5,vector.Y) /*vectorChest*/, null, ClothesUnderwearUp.Color, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
									else {
										if (Setting.sex==Sex.Girl) {
											if (Global.YoungPlayer) {
												if (Setting.MaturePlayer>0) spriteBatch.Draw(TextureSwimmingUpCensored, vector, null,Color.White /*ClothesUnderwearUp.Color*/, 0, Vector2Zero, 1, SpriteEffects.None, 0);
											}
										}
									}
								}
							}
							if (ClothesChestTop!=null) spriteBatch.Draw(ClothesChestTop.TextureWalking, vectorChest, null, ClothesChestTop.Color, FastMath.PIHalf, Vector2Zero, 1, SpriteEffects.None, 0);
							if (ClothesChestTop is null) {
								if (ClothesChest is null) DrawItemInHandTop(null, Color.White, 0);
								else DrawItemInHandTop(ClothesChest.Texture2DClothHand, ClothesChest.Color,(int)ClothesChest.handSize);
							} else DrawItemInHandTop(ClothesChestTop.Texture2DClothHand, ClothesChestTop.Color,(int)ClothesChestTop.handSize);

							void DrawItemInHandTop(Texture2D texCloth, Color colorCloth, int size){
								spriteBatch.Draw(TextureHand, rameno, recHand, Setting.ColorSkin, handAngle, vecOrigin, 1, SpriteEffects.None,1f);
								if (texCloth!=null)spriteBatch.Draw(texCloth, rameno, recCloth, colorCloth, handAngle, Vector2_2, 1, SpriteEffects.None,1f);

								if (InventoryNormal[boxSelected]!=null){
									if (InventoryNormal[boxSelected].Id!=0) {
										Rectangle recItem=new Rectangle(
											(int)(((float)Math.Cos(handAngle+FastMath.PIHalf)*(HandSize-4))+rameno.X-4),
											(int)(((float)Math.Sin(handAngle+FastMath.PIHalf))*(HandSize-4)+rameno.Y-4),
											8,
											8
										);

										switch (InventoryNormal[boxSelected]) {
											case ItemInvBasic16 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											case ItemInvBasic32 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											case ItemInvBasicColoritzed32NonStackable i:
												spriteBatch.Draw(i.Texture, recItem, i.color);
												break;

											case ItemInvFood16 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											case ItemInvFood32 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											case ItemInvNonStackable32 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											case ItemInvNonStackable16 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

												case ItemInvTool16 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

												case ItemInvTool32 i:
												spriteBatch.Draw(i.Texture, recItem, ColorWhite);
												break;

											#if DEBUG
											default: throw new Exception("Unknown category");
											#endif
										}
									}
								}
							}

							void DrawItemInHandBack(Texture2D texCloth, Color colorCloth, int size){
								recHand = new Rectangle(0,0,4,HandSize-size);
								vecOrigin=new Vector2(2,2-size);
								recCloth=new Rectangle(0,0,4,size);

								spriteBatch.Draw(TextureHand, rameno, recHand, new Color((byte)(Setting.ColorSkin.R*0.75f), (byte)(Setting.ColorSkin.G*0.75f), (byte)(Setting.ColorSkin.B*0.75f),(byte)255), handAngle-FastMath.PI, vecOrigin, 1, SpriteEffects.None,1f);
								if (texCloth!=null)spriteBatch.Draw(texCloth, rameno, recCloth, new Color((byte)(colorCloth.R*0.75f),(byte)(colorCloth.G*0.75f),(byte)(colorCloth.B*0.75f),(byte)255), handAngle-FastMath.PI, Vector2_2, 1, SpriteEffects.None,1f);
							}
						}
					} else {
						switch (playerState) {
							default:
								{
									Vector2 vector=new Vector2((int)PlayerX-11, (int)PlayerY-(int)(39*0.5f));

									Vector2 pointing=new Vector2(mouseRealPosX-Global.WindowWidthHalf, mouseRealPosY-Global.WindowHeightHalf);
									Vector2 rameno=new Vector2(vector.X-11+2+1+27/2-2, vector.Y-39/2+12-1+38/2);
									Vector2 hand=Vector2.Normalize(pointing)*HandSize;
									hand.X+=rameno.X;
									hand.Y+=rameno.Y;
									Vector2 center=(hand+rameno)/2;

									handAngle=(float)Math.Atan2(rameno.Y-hand.Y, rameno.X-hand.X)+FastMath.PIHalf;

									// Legs
									if (ClothesLegs!=null) {
										if (ClothesLegs.ShowBodyLegs) spriteBatch.Draw(TexturePlayerStaticLegs, vector, Setting.ColorSkin);
										spriteBatch.Draw(ClothesLegs.TextureStatic, vector, ClothesLegs.Color);
									} else {
										spriteBatch.Draw(TexturePlayerStaticLegs, vector, Setting.ColorSkin);
										if (ClothesUnderwearDown!=null) {
											if (ClothesChest==null)spriteBatch.Draw(ClothesUnderwearDown.TextureStatic, vector, ClothesUnderwearDown.Color);
											else if (!ClothesChest.IsDress) spriteBatch.Draw(ClothesUnderwearDown.TextureStatic, vector, ClothesUnderwearDown.Color);
										} else {
											if (Global.YoungPlayer) spriteBatch.Draw(TextureStaticDownCensored, vector, ColorWhite);
										}
									}

									// Chest
									if (ClothesChestTop is null || ClothesChestTop?.ShowTShirt==true) {
										if (ClothesChest!=null) {
											spriteBatch.Draw(ClothesChest.TextureStatic, vector, ClothesChest.Color);
										} else {
											spriteBatch.Draw(TexturePlayerStaticChest, vector, Setting.ColorSkin);
											if (ClothesUnderwearUp!=null) spriteBatch.Draw(ClothesUnderwearUp.TextureStatic, vector, ClothesUnderwearUp.Color);
											else {
												if (Setting.sex==Sex.Girl) {
													if (Global.YoungPlayer) {
														if (Setting.MaturePlayer>0) spriteBatch.Draw(TextureStaticUpCensored, vector, ColorWhite);
													}
												}
											}
										}
									}

									if (ClothesChestTop!=null) spriteBatch.Draw(ClothesChestTop.TextureStatic, vector, ClothesChestTop.Color);

									// Feet
									if (ClothesFeet!=null) spriteBatch.Draw(ClothesFeet.TextureStatic, vector, ClothesFeet.Color);
									else spriteBatch.Draw(TexturePlayerStaticFeet, vector, Setting.ColorSkin);

									// Head
									spriteBatch.Draw(TexturePlayerStaticFace, vector, Setting.ColorSkin);
									if (Setting.moustageType!=0)spriteBatch.Draw(TexturePlayerStaticMoustage, vector, Setting.moustageColor);
									spriteBatch.Draw(TexturePlayerStaticMouth, vector, ColorWhite);
									if (Setting.hairType!=0)spriteBatch.Draw(TexturePlayerStaticHair, vector, Setting.hairColor);
									spriteBatch.Draw(TexturePlayerStaticEyes, vector, Setting.eyesColor);

									if (ClothesHead!=null) spriteBatch.Draw(ClothesHead.TextureStatic, vector, ClothesHead.Color);

									if (ClothesChestTop is null) {
										if (ClothesChest is null)DrawItemInHand(null, Color.White, 0);
										else DrawItemInHand(ClothesChest?.Texture2DClothHand, ClothesChest.Color, (int)ClothesChest?.handSize);
									} else DrawItemInHand(ClothesChestTop.Texture2DClothHand, ClothesChestTop.Color, (int)ClothesChestTop.handSize);
									
									void DrawItemInHand(Texture2D texCloth, Color colorCloth, int size) {
										Rectangle recHand= new Rectangle(0,0,4,HandSize-size), recCloth=new Rectangle(0,0,4,size);
										Vector2 vecOrigin=new Vector2(2,2-size);
										
										spriteBatch.Draw(TextureHand, rameno, recHand, Setting.ColorSkin, handAngle, vecOrigin, 1, SpriteEffects.None,1f);
										if (texCloth!=null)spriteBatch.Draw(texCloth, rameno, recCloth, colorCloth, handAngle, Vector2_2, 1, SpriteEffects.None,1f);

										// Right
										rameno.X+=17;
										spriteBatch.Draw(TextureHand, rameno, recHand, Setting.ColorSkin, 0, vecOrigin, 1, SpriteEffects.None,1f);
										if (texCloth!=null)spriteBatch.Draw(texCloth, rameno, recCloth, colorCloth, 0, Vector2_2, 1, SpriteEffects.None,1f);
										rameno.X-=17;

										if (InventoryNormal[boxSelected]!=null){
											if (InventoryNormal[boxSelected].Id!=0) {
												Rectangle recItem=new Rectangle(
													(int)(((float)Math.Cos(handAngle+FastMath.PIHalf)*(HandSize-4))+rameno.X-4),
													(int)(((float)Math.Sin(handAngle+FastMath.PIHalf))*(HandSize-4)+rameno.Y-4),
													8,
													8
												);

												switch (InventoryNormal[boxSelected]) {
													case ItemInvBasic16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvBasic32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvBasicColoritzed32NonStackable i:
														spriteBatch.Draw(i.Texture, recItem, i.color);
														break;

													case ItemInvFood16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvFood32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvNonStackable32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvNonStackable16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													 case ItemInvTool16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													 case ItemInvTool32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													#if DEBUG
													default: throw new Exception("Unknown category");
													#endif
												}
											}
										}

									}
								}
								break;

							case 2://->
								{
									Rectangle curImg=new Rectangle((playerImg/20)*20, 0, 20, 39);
									Vector2 vector=new Vector2(PlayerX-11, PlayerY-39/2);

									Vector2 rameno=new Vector2(vector.X-11+2+1+27/2-2+7, vector.Y-39/2+12-1+38/2+1);
									int ticks=gameTime.TotalGameTime.Milliseconds;

									Rectangle recHand, recCloth;
									Vector2 vecOrigin;

									if (ticks<250) handAngle=-ticks/250f*WalkingHandMaxAngle;
									else if (ticks<750) handAngle=((ticks-250)/250f)*WalkingHandMaxAngle-WalkingHandMaxAngle;
									else handAngle=WalkingHandMaxAngle-((ticks-750)/250f)*WalkingHandMaxAngle;

									if (ClothesChestTop is null) {
										if (ClothesChest is null) DrawItemInHandBack(null, Color.White, 0);
										else DrawItemInHandBack(ClothesChest.Texture2DClothHand, ClothesChest.Color,(int)ClothesChest.handSize);
									} else DrawItemInHandBack(ClothesChestTop.Texture2DClothHand, ClothesChestTop.Color,(int)ClothesChestTop.handSize);

									// Feet
									if (ClothesFeet!=null) {
										spriteBatch.Draw(TexturePlayerWalkingFeetForShoes, vector, curImg, Setting.ColorSkin);
										spriteBatch.Draw(ClothesFeet.TextureWalking, vector, curImg, ClothesFeet.Color);
									} else spriteBatch.Draw(TexturePlayerWalkingFeet, vector, curImg, Setting.ColorSkin);

									// Head
									spriteBatch.Draw(TexturePlayerWalkingFace, new Vector2(vector.X-1, vector.Y), Setting.ColorSkin);
									spriteBatch.Draw(TexturePlayerWalkingEyes, new Vector2(vector.X-1, vector.Y), Setting.eyesColor);
									spriteBatch.Draw(TexturePlayerWalkingMouth, new Vector2(vector.X-1, vector.Y), ColorWhite);
									if (Setting.moustageType!=0)spriteBatch.Draw(TexturePlayerWalkingMoustage, new Vector2(vector.X-1, vector.Y), Setting.moustageColor);
									if (Setting.hairType!=0)spriteBatch.Draw(TexturePlayerWalkingHair, new Vector2(vector.X-1, vector.Y), Setting.hairColor);

									// Legs
									if (ClothesLegs!=null) {
										if (ClothesLegs.ShowBodyLegs) spriteBatch.Draw(TexturePlayerWalkingLegs, vector, curImg, Setting.ColorSkin);
										spriteBatch.Draw(ClothesLegs.TextureWalking, vector, curImg, ClothesLegs.Color);
									} else {
										spriteBatch.Draw(TexturePlayerWalkingLegs, vector, curImg, Setting.ColorSkin);
										if (ClothesUnderwearDown!=null) {
											if (ClothesChest==null) spriteBatch.Draw(ClothesUnderwearDown.TextureWalking, vector, curImg, ClothesUnderwearDown.Color);
											else if (!ClothesChest.IsDress) spriteBatch.Draw(ClothesUnderwearDown.TextureWalking, vector, curImg, ClothesUnderwearDown.Color);
										} else {
											if (Global.YoungPlayer) spriteBatch.Draw(TextureWalkingDownCensored, vector, null, ColorWhite);
										}
									}
									// Chest
									if (ClothesChestTop is null || ClothesChestTop?.ShowTShirt==true) {
										if (ClothesChest!=null) spriteBatch.Draw(ClothesChest.TextureWalking, vector, null, ClothesChest.Color);
										else {
											spriteBatch.Draw(TexturePlayerWalkingChest, vector, null, Setting.ColorSkin);
											if (ClothesUnderwearUp!=null) spriteBatch.Draw(ClothesUnderwearUp.TextureWalking, vector, null, ClothesUnderwearUp.Color);
											else {
												if (Setting.sex==Sex.Girl) {
													if (Global.YoungPlayer) {
														if (Setting.MaturePlayer>0) spriteBatch.Draw(TextureWalkingUpCensored, vector, null, /*ClothesUnderwearUp.*/Color.White);
													}
												}
											}
										}
									}

									if (ClothesChestTop!=null) spriteBatch.Draw(ClothesChestTop.TextureWalking, vector, null, ClothesChestTop.Color);
									if (ClothesHead!=null) spriteBatch.Draw(ClothesHead.TextureWalkingOrSwimming, new Vector2(vector.X-1, vector.Y), ClothesHead.Color);


									if (ClothesChestTop is null) {
										if (ClothesChest is null) DrawItemInHandTop(null, Color.White, 0);
										else DrawItemInHandTop(ClothesChest.Texture2DClothHand, ClothesChest.Color, (int)ClothesChest.handSize);
									} else DrawItemInHandTop(ClothesChestTop.Texture2DClothHand, ClothesChestTop.Color, (int)ClothesChestTop.handSize);

									void DrawItemInHandTop(Texture2D texCloth, Color colorCloth, int size){
										spriteBatch.Draw(TextureHand, rameno, recHand, Setting.ColorSkin, handAngle, vecOrigin, 1, SpriteEffects.None,1f);
										if (texCloth!=null) spriteBatch.Draw(texCloth, rameno, recCloth, colorCloth, handAngle, Vector2_2, 1, SpriteEffects.None,1f);

										if (InventoryNormal[boxSelected]!=null){
											if (InventoryNormal[boxSelected].Id!=0) {
												Rectangle recItem=new Rectangle(
													(int)(((float)Math.Cos(handAngle+FastMath.PIHalf)*(HandSize-4))+rameno.X-4),
													(int)(((float)Math.Sin(handAngle+FastMath.PIHalf))*(HandSize-4)+rameno.Y-4),
													8,
													8
												);

												switch (InventoryNormal[boxSelected]) {
													case ItemInvBasic16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvBasic32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvBasicColoritzed32NonStackable i:
														spriteBatch.Draw(i.Texture, recItem, i.color);
														break;

													case ItemInvFood16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvFood32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvNonStackable32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvNonStackable16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													 case ItemInvTool16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													 case ItemInvTool32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													#if DEBUG
													default: throw new Exception("Unknown category");
													#endif
												}
											}
										}
									}

									void DrawItemInHandBack(Texture2D texCloth, Color colorCloth, int size){
										recHand= new Rectangle(0,0,4,HandSize-size);
										vecOrigin=new Vector2(2,2-size);

										spriteBatch.Draw(TextureHand, rameno, recHand, new Color((byte)(Setting.ColorSkin.R*0.75f), (byte)(Setting.ColorSkin.G*0.75f), (byte)(Setting.ColorSkin.B*0.75f),(byte)255), -handAngle, vecOrigin, 1, SpriteEffects.None,1f);
										
											recCloth=new Rectangle(0,0,4,size);
										if (texCloth!=null) {
											spriteBatch.Draw(texCloth, rameno, recCloth, new Color((byte)(colorCloth.R*0.75f),(byte)(colorCloth.G*0.75f),(byte)(colorCloth.B*0.75f),(byte)255), -handAngle, Vector2_2, 1, SpriteEffects.None,1f);
										} 
									}
								}
								break;

							case 1://<-
								{
									Rectangle curImg=new Rectangle((playerImg/20)*20, 0, 20, 39);
								//	Rectangle curImg2=new Rectangle((playerImg2/20)*20, 0, 20, 39);
						
									Vector2 vector=new Vector2(PlayerX-11, PlayerY-39/2);

									Vector2 rameno=new Vector2(vector.X-11+2+1+27/2-2+7, vector.Y-39/2+12-1+38/2+1);
									int ticks=gameTime.TotalGameTime.Milliseconds;

									Rectangle recHand, recCloth;
									Vector2 vecOrigin;

									if (ticks<250) handAngle=-ticks/250f*WalkingHandMaxAngle;
									else if (ticks<750) handAngle=((ticks-250)/250f)*WalkingHandMaxAngle-WalkingHandMaxAngle;
									else handAngle=WalkingHandMaxAngle-((ticks-750)/250f)*WalkingHandMaxAngle;

									if (ClothesChestTop is null) {
										if (ClothesChest is null) DrawItemInHandBack(null, Color.White, 0);
										else DrawItemInHandBack(ClothesChest.Texture2DClothHand, ClothesChest.Color,(int)ClothesChest.handSize);
									} else DrawItemInHandBack(ClothesChestTop.Texture2DClothHand, ClothesChestTop.Color,(int)ClothesChestTop.handSize);

									// Feet
									if (ClothesFeet!=null) {
										spriteBatch.Draw(TexturePlayerWalkingFeetForShoes, vector, curImg/*2*/, Setting.ColorSkin, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
										spriteBatch.Draw(ClothesFeet.TextureWalking, vector, curImg/*2*/, ClothesFeet.Color, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
									} else spriteBatch.Draw(TexturePlayerWalkingFeet, vector, curImg/*2*/, Setting.ColorSkin, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);


									spriteBatch.Draw(TexturePlayerWalkingFace, new Vector2(vector.X-1,vector.Y), null, Setting.ColorSkin, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
									spriteBatch.Draw(TexturePlayerWalkingEyes, new Vector2(vector.X-1,vector.Y), null, Setting.eyesColor, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
									spriteBatch.Draw(TexturePlayerWalkingMouth,new Vector2(vector.X-1,vector.Y), null, ColorWhite, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
									if (Setting.moustageType!=0)spriteBatch.Draw(TexturePlayerWalkingMoustage, new Vector2(vector.X-1,vector.Y), null, Setting.moustageColor, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
									if (Setting.hairType!=0)spriteBatch.Draw(TexturePlayerWalkingHair, new Vector2(vector.X-1,vector.Y), null, Setting.hairColor, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);

									if (ClothesHead!=null) spriteBatch.Draw(ClothesHead.TextureWalkingOrSwimming, new Vector2(vector.X-1,vector.Y), null, ClothesHead.Color, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);

									// Legs
									if (ClothesLegs!=null) {
										if (ClothesLegs.ShowBodyLegs) spriteBatch.Draw(TexturePlayerWalkingLegs, vector, curImg, Setting.ColorSkin);
										spriteBatch.Draw(ClothesLegs.TextureWalking, vector, curImg, ClothesLegs.Color, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
									} else {
										spriteBatch.Draw(TexturePlayerWalkingLegs, vector, curImg, Setting.ColorSkin, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
										if (ClothesUnderwearDown!=null) {
											if (ClothesChest==null) spriteBatch.Draw(ClothesUnderwearDown.TextureWalking, vector, curImg, ClothesUnderwearDown.Color, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
											else if (!ClothesChest.IsDress) spriteBatch.Draw(ClothesUnderwearDown.TextureWalking, vector, curImg, ClothesUnderwearDown.Color, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
										} else {
											if (Global.YoungPlayer) spriteBatch.Draw(TextureWalkingDownCensored, vector, null, ColorWhite, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
										}
									}
									// Chest
									if (ClothesChestTop is null || ClothesChestTop?.ShowTShirt==true) {
										if (ClothesChest!=null) spriteBatch.Draw(ClothesChest.TextureWalking, new Vector2(vector.X-2, vector.Y) , null, ClothesChest.Color, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
										else {
											spriteBatch.Draw(TexturePlayerWalkingChest,new Vector2(vector.X-2, vector.Y)/*vector*//*vector*/, null, Setting.ColorSkin, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
											if (ClothesUnderwearUp!=null) spriteBatch.Draw(ClothesUnderwearUp.TextureWalking, vector, null, ClothesUnderwearUp.Color, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
											else {
												if (Setting.sex==Sex.Girl) {
													if (Global.YoungPlayer) {
														if (Setting.MaturePlayer>0) spriteBatch.Draw(TextureWalkingUpCensored, vector, null, ColorWhite, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
													}
												}
											}
										}
									}
									if (ClothesChestTop!=null) spriteBatch.Draw(ClothesChestTop.TextureWalking, vector, null, ClothesChestTop.Color, 0, Vector2Zero, 1, SpriteEffects.FlipHorizontally, 0);
									

									if (ClothesChestTop is null) {
										if (ClothesChest is null) DrawItemInHandTop(null, Color.White, 0);
										else DrawItemInHandTop(ClothesChest.Texture2DClothHand, ClothesChest.Color,(int)ClothesChest.handSize);
									} else DrawItemInHandTop(ClothesChestTop.Texture2DClothHand, ClothesChestTop.Color,(int)ClothesChestTop.handSize);

									void DrawItemInHandTop(Texture2D texCloth, Color colorCloth, int size){
										spriteBatch.Draw(TextureHand, rameno, recHand, Setting.ColorSkin, handAngle, vecOrigin, 1, SpriteEffects.None,1f);
										if (texCloth!=null)spriteBatch.Draw(texCloth, rameno, recCloth/*new Rectangle(0,0,4,size)*/, colorCloth, handAngle, Vector2_2, 1, SpriteEffects.None,1f);

										if (InventoryNormal[boxSelected]!=null){
											if (InventoryNormal[boxSelected].Id!=0) {
												Rectangle recItem=new Rectangle(
													(int)(((float)Math.Cos(handAngle+FastMath.PIHalf)*(HandSize-4))+rameno.X-4),
													(int)(((float)Math.Sin(handAngle+FastMath.PIHalf))*(HandSize-4)+rameno.Y-4),
													8,
													8
												);

												switch (InventoryNormal[boxSelected]) {
													case ItemInvBasic16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvBasic32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvBasicColoritzed32NonStackable i:
														spriteBatch.Draw(i.Texture, recItem, i.color);
														break;

													case ItemInvFood16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvFood32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvNonStackable32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													case ItemInvNonStackable16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													 case ItemInvTool16 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													 case ItemInvTool32 i:
														spriteBatch.Draw(i.Texture, recItem, ColorWhite);
														break;

													#if DEBUG
													default: throw new Exception("Unknown category");
													#endif
												}
											}
										}
									}

									void DrawItemInHandBack(Texture2D texCloth, Color colorCloth, int size){
										recHand= new Rectangle(0,0,4,HandSize-size);
										vecOrigin=new Vector2(2,2-size);

										spriteBatch.Draw(TextureHand, rameno, recHand, new Color((byte)(Setting.ColorSkin.R*0.75f), (byte)(Setting.ColorSkin.G*0.75f), (byte)(Setting.ColorSkin.B*0.75f),(byte)255), -handAngle, vecOrigin, 1, SpriteEffects.None,1f);
											recCloth = new Rectangle(0,0,4,size);
										if (texCloth!=null) {
											spriteBatch.Draw(texCloth, rameno, new Rectangle(0,0,4,size), new Color((byte)(colorCloth.R*0.75f),(byte)(colorCloth.G*0.75f),(byte)(colorCloth.B*0.75f), (byte)255), -handAngle, Vector2_2, 1, SpriteEffects.None,1f);
										} 
									}
								}
							break;
						}
					}
				}
				#endregion

				if (debug) {
					foreach (Energy r in energy) r.Draw();
					spriteBatch.Draw(pixel, new Rectangle(mousePosRoundX,mousePosRoundY,16,16), null, color_r200_g200_b200_a100);
				}
				if (Particles.Count>0) {
					for (int i = 0; i<Particles.Count; i++) Particles[i].Draw();
				}
				spriteBatch.End();

				// Draw lighting on game
				spriteBatch.Begin(sortMode: SpriteSortMode.Deferred, blendState: Multiply);
				spriteBatch.Draw(texture: modificatedLightTarget, position: Vector2Zero, color: ColorWhite);
				spriteBatch.End();
				#endregion

				#region Draw inv
				if (showInventory) {
					spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointWrap/*,DepthStencilState.Default,RasterizerState.CullNone,null,null*/);
					Rabcr.spriteBatch=spriteBatch;
					#region Draw Bars
					if (Global.WorldDifficulty!=2) {
						int barE=(int)barEnergy, barO=(int)barOxygen, barW=(int)barWater, barEa=(int)barEat, barH=(int)barHeart;
						// Energy bar
						spriteBatch.Draw(barEnergyTexture,new Vector2(Global.WindowWidth-150-36,8),new Rectangle(0,0,32,barE),ColorGray);
						spriteBatch.Draw(barEnergyTexture,new Vector2(Global.WindowWidth-150-36,8+barE),new Rectangle(0,barE,32,32-barE),ColorWhite);

						// Oxygen bar
						spriteBatch.Draw(barOxygenTexture,new Vector2(Global.WindowWidth-150,8),new Rectangle(0,0,32,barO),ColorGray);
						spriteBatch.Draw(barOxygenTexture,new Vector2(Global.WindowWidth-150,8+barO),new Rectangle(0,barO,32,32-barO),ColorWhite);

						// Water bar
						spriteBatch.Draw(barWaterTexture,new Vector2(Global.WindowWidth-114,8),new Rectangle(0,0,32,barW),ColorGray);
						spriteBatch.Draw(barWaterTexture,new Vector2(Global.WindowWidth-114,8+barW),new Rectangle(0,barW,32,32-barW),ColorWhite);

						// Eat bar
						spriteBatch.Draw(barEatTexture,new Vector2(Global.WindowWidth-78,8),new Rectangle(0,0,32,barEa),ColorGray);
						spriteBatch.Draw(barEatTexture,new Vector2(Global.WindowWidth-78,8+barEa),new Rectangle(0,barEa,32,32-barEa),ColorWhite);

						// Heart bar
						spriteBatch.Draw(barHeartTexture,new Vector2(Global.WindowWidth-40,8), new Rectangle(0,0,32,barH),ColorGray);
						spriteBatch.Draw(barHeartTexture,new Vector2(Global.WindowWidth-40,8+barH), new Rectangle(0,barH,32,32-barH),ColorWhite);
					}
					#endregion

					#region Draw Inventory
					switch (inventory) {

						#region Normal
						case InventoryType.Normal:
							if (diserpeard!=0) {
								if (gedo!=null) {
#if DEBUG
									if (text.StartsWith("*")){
										if (Command()){ 
											///text="";diserpeard=0;
										}else{ 
											text="Unknown command";diserpeard=255;
										}
									}
									//if (text.StartsWith("*time-set ")) {
									//	if (int.TryParse(text.Substring("*time-set ".Length), out int num)){
									//		time=num*hour; 
									//	} else if (float.TryParse(text.Substring("*time-set ".Length), out float num2)){
									//		time=(int)(num2*hour); 
									//	}
									//	text="";
									//	diserpeard=0;
									//} 
									//if (text.StartsWith("*day-set ")){
									//	if (int.TryParse(text.Substring("*day-set ".Length), out int num)){
									//		day=num; 
									//		ChangeLeavesForceEverything();
									//	}
									//	text="";
									//	diserpeard=0;
									//} 
									//if (text=="*give-mobile") {
									//	InventoryAddOne((ushort)Items.Mobile);
									//	text="";
									//	diserpeard=0;text="";diserpeard=0;
									//} 
									//if (text=="*wd0") {
									//	Global.WorldDifficulty=0;text="";diserpeard=0;
									//} 
									//if (text=="*wd1") {
									//	Global.WorldDifficulty=1;text="";diserpeard=0;
									//} 
									//if (text=="*wd2") {
									//	Global.WorldDifficulty=2;text="";diserpeard=0;
									//} 
									//if (text=="*rain-change") {
									//	changeRain=1;
									//	text="";diserpeard=0;
									//} 
									//if (text=="*wind-change") {
									//	timeToChageWind=1;
									//	text="";diserpeard=0;
									//}
#endif
                                    if (text.StartsWith("*error")) {
                                        throw new Exception("Manual error");
                                    }
                                    int meas=BitmapFont.bitmapFont18.MeasureTextSingleLineX(gedo.Text);
									int texts=meas/2;
									int x=Global.WindowWidthHalf+((int)PlayerX-(int)WindowCenterX);
									gedo.SetPos(x-texts+20-10-5,Global.WindowHeightHalf-40-50-4);
									if (diserpeard>100) {
										spriteBatch.Draw(messageLeft,new Vector2(x-texts-10,Global.WindowHeightHalf-55-50), ColorWhite);
										spriteBatch.Draw(messageCenter,new Rectangle(x-texts+19-10,Global.WindowHeightHalf-55-50,texts*2,57), ColorWhite);
										spriteBatch.Draw(messageRight,new Vector2(x+texts+19-10,Global.WindowHeightHalf-55-50), ColorWhite);

										gedo.DrawGedo(1f,spriteBatch);
									} else {
										float alphaC =diserpeard/100f;
										Color alphaCC=new Color(alphaC,alphaC,alphaC,alphaC);

										spriteBatch.Draw(messageLeft,new Vector2(x-texts-10,Global.WindowHeightHalf-55-50), alphaCC);
										spriteBatch.Draw(messageCenter,new Rectangle(x-texts+19-10,Global.WindowHeightHalf-55-50,texts*2,57), alphaCC);
										spriteBatch.Draw(messageRight,new Vector2(x+texts+19-10,Global.WindowHeightHalf-55-50), alphaCC);

										gedo.DrawGedo(alphaC,spriteBatch);
									}
								}
							}

							#region Basic right inventory
							{
								int w=Global.WindowWidth-40, h=Global.WindowHeightHalf-80;
								for (int i = 0; i<5; i++) {
									if (boxSelected==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(w, h+i*40), ColorLightBlue);
									else spriteBatch.Draw(inventorySlotTexture, new Vector2(w, h+i*40), ColorWhite);
								}
							}

							for (int i = 0; i<5; i++) InventoryNormal[i].Draw();
							#endregion

							break;
						#endregion

						#region Writing message
						case InventoryType.Typing:
							{
								int xx=Global.WindowWidthHalf+((int)PlayerX-(int)WindowCenterX);

								int half=textWriting.X/2;
								spriteBatch.Draw(messageLeft,new Vector2(xx-half-10,Global.WindowHeightHalf-55-50), ColorWhite);
								spriteBatch.Draw(messageCenter,new Rectangle(xx-half+19-10,Global.WindowHeightHalf-55-50,textWriting.X,57), ColorWhite);
								spriteBatch.Draw(messageRight,new Vector2(xx+half+19-10,Global.WindowHeightHalf-55-50), ColorWhite);

								textWriting.Draw(spriteBatch);

								spriteBatch.Draw(pixel,new Rectangle(xx+half+20-10,Global.WindowHeightHalf-40-50+3,1,15),black);

								DrawSideInventory();
							}
							break;
						#endregion

						#region Basic inventory - clothes, inventory and basic crafting
						case InventoryType.BasicInv:
							spriteBatch.Draw(pixel, new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

							DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234,604,434+2,1, color_r0_g0_b0_a100);
							DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233,602,434,1, color_r0_g0_b0_a200);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232,600,34), color_r10_g140_b255);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2,600,400-2), ColorLightBlue);

							buttonClose.ButtonDraw();

							spriteBatch.Draw(TextureInventoryClothes,new Vector2(Global.WindowWidthHalf-300+4+60, Global.WindowHeightHalf-200+2+4), ColorWhite);
							textOpenInventory.Draw(spriteBatch);

							DrawInventoryWithDIntMoving();
							InventoryDrawClothes();

							#region Crafting
							{
								if (inventoryScrollbarValueCraftingMax>6*4) {
									int size2 =(int)( (1f/((( (int)(inventoryScrollbarValueCraftingMax/5f)+1  )*40)/160f))*160 );

									int pos2=(int)(  (inventoryScrollbarValueCrafting*5/40f) / (inventoryScrollbarValueCraftingMax-6*3)*(160-size2) )*8;
									if (size2>20) {
										spriteBatch.Draw(scrollbarUpTexture,new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
										spriteBatch.Draw(scrollbarBetweenTexture,new Rectangle(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+10-1+8,20,size2-20), ColorWhite);
										spriteBatch.Draw(scrollbarDownTexture,new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11+size2-20-2+8), ColorWhite);
									} else {
										spriteBatch.Draw(scrollbarUpTexture,new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
										spriteBatch.Draw(scrollbarDownTexture,new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11-2+8), ColorWhite);
									}
								}

								int xx =0;
								int yh=0;

								for (int i=inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
									if (i>inventoryScrollbarValueCraftingMax) break;
									if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {

									if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r128_g128_b128);
										else spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r200_g200_b200);
									} else {
										if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r150_g150_b150);
										else spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), ColorWhite);
									}

									InventoryCrafting[i].DrawCreative();
									//Texture2D tex=ItemIdToTexture(InventoryCrafting[i].X);
									//if (tex!=null) GameDraw.DrawItemInInventory(tex,1,Global.WindowWidthHalf-300+4+40+xx+4+4,Global.WindowHeightHalf-200+2+4+200+8+yh+4+8);
									xx+=40;

									if (xx==6*40) {
										xx=0;
										yh+=40;
									}
								}
							}
							#endregion

							DrawNeedNew();

							buttonInvTabBlocks.ButtonDraw();
							buttonInvTabMashines.ButtonDraw();
							buttonInvTabTools.ButtonDraw();
							buttonInvTabPlants.ButtonDraw();
							buttonInvTabItems.ButtonDraw();

							DrawSideInventory();

							if (displayPopUpWindow)DrawChooseItemWindow();
							else if (showMouseItemWhileMooving) InvMouseDraw();
							else if (mouseDrawItemTextInfo) DrawItemMouse();
							break;
						#endregion

						#region Desk
						case InventoryType.Desk:
							spriteBatch.Draw(pixel,new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

							DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234,604,434+2,1, color_r0_g0_b0_a100);
							DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233,602,434,1, color_r0_g0_b0_a200);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232,600,34), color_r10_g140_b255);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2,600,400-2), ColorLightBlue);

							buttonClose.ButtonDraw();

							spriteBatch.Draw(deskTexture, new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4, 200, 200), ColorWhite);
							textOpenInventory.Draw(spriteBatch);

							DrawInventoryNormal();

							#region Crafting
							{
								if (inventoryScrollbarValueCraftingMax>6*4) {
									int size2 = (int)((1f/((((int)(inventoryScrollbarValueCraftingMax/5f)+1)*40)/160f))*160);

									int pos2 = (int)(((float)(inventoryScrollbarValueCrafting*5/40f)/(inventoryScrollbarValueCraftingMax-3*6))*(160-size2));
									if (size2>20) {
										spriteBatch.Draw(scrollbarUpTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
										spriteBatch.Draw(scrollbarBetweenTexture, new Rectangle(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+10-1+8, 20, size2-20), ColorWhite);
										spriteBatch.Draw(scrollbarDownTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11+size2-20-2+8), ColorWhite);
									} else {
										spriteBatch.Draw(scrollbarUpTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
										spriteBatch.Draw(scrollbarDownTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11-2+8), ColorWhite);
									}
								}

								int xx =0;
								int yh=0;

								for (int i=inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
									if (i>inventoryScrollbarValueCraftingMax) break;
									if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {
									//if (newMouseState.X>Global.WindowWidthHalf-300+4+40+4+xx && newMouseState.X<Global.WindowWidthHalf-300+4+40+4+xx+40
									//&& newMouseState.Y>Global.WindowHeightHalf-200+2+4+200+8+yh+8 && newMouseState.Y<Global.WindowHeightHalf-200+2+4+200+8+yh+8+40) {
										//if (mouseLeftRelease) {
										//    selectedCraftingItem=i;

										//    craftingType=0;
										//    DListInt[]x=GameMethods.Craft(Crafting[selectedCraftingItem].X);
										//    if (x!=null) Need=x[craftingType].List1;
										//}
										if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r128_g128_b128);
										else spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8),color_r200_g200_b200);
									} else {
										if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r150_g150_b150);
										else spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), ColorWhite);
									}
									InventoryCrafting[i].DrawCreative();
									//Texture2D tex=ItemIdToTexture(InventoryCrafting[i].X);
									//if (tex!=null) GameDraw.DrawItemInInventory(tex,1,Global.WindowWidthHalf-300+4+40+xx+4+4,Global.WindowHeightHalf-200+2+4+200+8+yh+4+8);
									xx+=40;

									if (xx==6*40) {
										xx=0;
										yh+=40;
									}
								}
							}
							#endregion

							DrawNeedNew();

							buttonInvTabBlocks.ButtonDraw();
							buttonInvTabMashines.ButtonDraw();
							buttonInvTabTools.ButtonDraw();
							buttonInvTabPlants.ButtonDraw();
							buttonInvTabItems.ButtonDraw();

							DrawSideInventory();

							if (displayPopUpWindow)DrawChooseItemWindow();
							else if (showMouseItemWhileMooving) InvMouseDraw();
							else if (mouseDrawItemTextInfo) DrawItemMouse();
							break;
						#endregion

						#region Furnace stone
						case InventoryType.FurnaceStone:
							{
								spriteBatch.Draw(pixel, new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight), new Color((byte)0,(byte)0,(byte)0,(byte)animationInvBack));

								DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234, 604, 434+2, 1, color_r0_g0_b0_a100);
								DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233, 602, 434, 1, color_r0_g0_b0_a200);
								spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232, 600, 34), color_r10_g140_b255);
								spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2, 600, 400-2), ColorLightBlue);

								buttonClose.ButtonDraw();

								ItemInv[] inv=((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv;
								float energy=((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Energy;

								spriteBatch.Draw(furnaceStoneTexture, new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4, 200, 200),new Rectangle(energy>0 ?0 :16,0,16,16), ColorWhite);

								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300+4-2, Global.WindowHeightHalf-200+2+4-6,202+2,5),black);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300+4-1, Global.WindowHeightHalf-200+2+4-5,(int)(energy*2.02),3),Color.Green);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300+4-1+(int)(energy*2.02),Global.WindowHeightHalf-200+2+4-5,202-(int)(energy*2.02),3),Color.Red);
								textOpenInventory.Draw(spriteBatch);

								DrawInventoryWithDIntMoving();

								#region Bake
								{
									if (inventoryScrollbarValueCraftingMax>6*4) {
										int size2 = (int)((1f/((((int)(inventoryScrollbarValueCraftingMax/5f)+1)*40)/160f))*160);
										int pos2 = (int)(((inventoryScrollbarValueCrafting*5/40f)/inventoryScrollbarValueCraftingMax)*(160-size2))*8;
										if (size2>20) {
											spriteBatch.Draw(scrollbarUpTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
											spriteBatch.Draw(scrollbarBetweenTexture, new Rectangle(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+10-1+8, 20, size2-20), ColorWhite);
											spriteBatch.Draw(scrollbarDownTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11+size2-20-2+8), ColorWhite);
										} else {
											spriteBatch.Draw(scrollbarUpTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
											spriteBatch.Draw(scrollbarDownTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11-2+8), ColorWhite);
										}
									}

									int xx = 0;
									int yh = 0;

									for (int i = inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
										if (i>inventoryScrollbarValueCraftingMax) break;
										if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {
										//if (newMouseState.X>Global.WindowWidthHalf-300+4+40+4+xx&&newMouseState.X<Global.WindowWidthHalf-300+4+40+4+xx+40
										//&& newMouseState.Y>Global.WindowHeightHalf-200+2+4+200+8+yh+8&&newMouseState.Y<Global.WindowHeightHalf-200+2+4+200+8+yh+8+40) {
											//if (mouseLeftRelease) {
											//    selectedCraftingItem=i;
											//    craftingType=0;
											//    DListInt[] x = GameMethods.Bake(Crafting[selectedCraftingItem].X);
											//    if (x!=null) Need=x[craftingType].List1;
											//}
											if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r128_g128_b128);
											else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r200_g200_b200);
										} else {
											if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r150_g150_b150);
											else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), ColorWhite);
										}
										InventoryCrafting[i].Draw();
										//Texture2D tex = ItemIdToTexture(InventoryCrafting[i].X);
										//if (tex!=null) GameDraw.DrawItemInInventory(tex, 1, Global.WindowWidthHalf-300+4+40+xx+4+4, Global.WindowHeightHalf-200+2+4+200+8+yh+4+8);
										xx+=40;

										if (xx==6*40) {
											xx=0;
											yh+=40;
										}
									}
								}
								#endregion

								DrawNeedNew();
								#region burn wood
								spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+1+40, Global.WindowHeightHalf-200+2+4+60), ColorWhite*0.5f);
								spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+1+40+40, Global.WindowHeightHalf-200+2+4+60), ColorWhite*0.5f);
								spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+1+40*2+40, Global.WindowHeightHalf-200+2+4+60), ColorWhite*0.5f);
								spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+1+40+40, Global.WindowHeightHalf-200+2+4+60+40+8), ColorWhite*0.5f);
								spriteBatch.Draw(ashTexture, new Rectangle(Global.WindowWidthHalf-300+4+1+40+40+4, Global.WindowHeightHalf-200+2+4+60+40+8+4,32,32), ColorWhite*0.25f);

								inv[0].Draw();
								inv[1].Draw();
								inv[2].Draw();
								inv[3].Draw();
								#endregion

								buttonInvTabMaterials.ButtonDraw();
								buttonInvTabGlass.ButtonDraw();
								buttonInvTabCeramics.ButtonDraw();
								buttonInvTabFood.ButtonDraw();
								buttonInvTabTools.ButtonDraw();

								DrawSideInventory();

								if (displayPopUpWindow)DrawChooseItemWindow();
								else if (showMouseItemWhileMooving) InvMouseDraw();
								else if (mouseDrawItemTextInfo) DrawItemMouse();
								if (buttonClose.Update()) inventory=0;
							}
							break;
							#endregion

						#region Furnace electric
						case InventoryType.FurnaceElectric:
							spriteBatch.Draw(pixel, new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

							DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234, 604, 434+2, 1, color_r0_g0_b0_a100);
							DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233, 602, 434, 1, color_r0_g0_b0_a200);
							spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232, 600, 34), color_r10_g140_b255);
							spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2, 600, 400-2), ColorLightBlue);

							buttonClose.ButtonDraw();

							spriteBatch.Draw(furnaceElectricOneTexture, new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4, 200, 200), ColorWhite);
							textOpenInventory.Draw(spriteBatch);
							DrawInventoryNormal();

							#region Bake
							{
								if (inventoryScrollbarValueCraftingMax>6*4) {
									int size2 = (int)((1f/((((int)(inventoryScrollbarValueCraftingMax/5f)+1)*40)/160f))*160);
									int pos2 = (int)((((inventoryScrollbarValueCrafting*5)/40f)/inventoryScrollbarValueCraftingMax)*(160-size2))*8;
									if (size2>20) {
										spriteBatch.Draw(scrollbarUpTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
										spriteBatch.Draw(scrollbarBetweenTexture, new Rectangle(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+10-1+8, 20, size2-20), ColorWhite);
										spriteBatch.Draw(scrollbarDownTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11+size2-20-2+8), ColorWhite);
									} else {
										spriteBatch.Draw(scrollbarUpTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
										spriteBatch.Draw(scrollbarDownTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11-2+8), ColorWhite);
									}
								}

								int xx = 0;
								int yh = 0;

								for (int i = inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
									if (i>inventoryScrollbarValueCraftingMax) break;
									if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {
									//if (newMouseState.X>Global.WindowWidthHalf-300+4+40+4+xx&&newMouseState.X<Global.WindowWidthHalf-300+4+40+4+xx+40
									//&& newMouseState.Y>Global.WindowHeightHalf-200+2+4+200+8+yh+8&&newMouseState.Y<Global.WindowHeightHalf-200+2+4+200+8+yh+8+40) {
										if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r128_g128_b128);
										else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r200_g200_b200);
									} else {
										if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r150_g150_b150);
										else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), ColorWhite);
									}
									InventoryCrafting[i].Draw();
								   // Texture2D tex = ItemIdToTexture(InventoryCrafting[i].X);
								   // if (tex!=null) GameDraw.DrawItemInInventory(tex, 1, Global.WindowWidthHalf-300+4+40+xx+4+4, Global.WindowHeightHalf-200+2+4+200+8+yh+4+8);
									xx+=40;

									if (xx==6*40) {
										xx=0;
										yh+=40;
									}
								}
							}
							#endregion

							DrawNeedNew();

							buttonInvTabMaterials.ButtonDraw();
							buttonInvTabGlass.ButtonDraw();
							buttonInvTabCeramics.ButtonDraw();
							buttonInvTabFood.ButtonDraw();
							buttonInvTabTools.ButtonDraw();

							DrawSideInventory();
							if (displayPopUpWindow)DrawChooseItemWindow();
							else if (showMouseItemWhileMooving) InvMouseDraw();
							else if (mouseDrawItemTextInfo) DrawItemMouse();
							break;
						#endregion

						#region Macerator
						case InventoryType.Macerator:
							spriteBatch.Draw(pixel, new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

							DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234, 604, 434+2, 1, color_r0_g0_b0_a100);
							DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233, 602, 434, 1, color_r0_g0_b0_a200);
							spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232, 600, 34), color_r10_g140_b255 );
							spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2, 600, 400-2), ColorLightBlue);

							buttonClose.ButtonDraw();

							spriteBatch.Draw(maceratorOneTexture, new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4, 200, 200), ColorWhite);
							textOpenInventory.Draw(spriteBatch);

							DrawInventoryNormal();

							#region ToDust
							{
								if (inventoryScrollbarValueCraftingMax>6*4) {
									int size2 = (int)((1f/((((int)(inventoryScrollbarValueCraftingMax/5f)+1)*40)/160f))*160);
									int pos2 = (int)(((inventoryScrollbarValueCrafting*5)/40f)/inventoryScrollbarValueCraftingMax*(160-size2))*8;
									if (size2>20) {
										spriteBatch.Draw(scrollbarUpTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
										spriteBatch.Draw(scrollbarBetweenTexture, new Rectangle(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+10-1+8, 20, size2-20), ColorWhite);
										spriteBatch.Draw(scrollbarDownTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11+size2-20-2+8), ColorWhite);
									} else {
										spriteBatch.Draw(scrollbarUpTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
										spriteBatch.Draw(scrollbarDownTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11-2+8), ColorWhite);
									}
								}

								int xx = 0;
								int yh = 0;

								for (int i = inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
									if (i>inventoryScrollbarValueCraftingMax) break;
									if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {

										if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r128_g128_b128);
										else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r200_g200_b200);
									} else {
										if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r150_g150_b150);
										else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), ColorWhite);
									}
									InventoryCrafting[i].Draw();
									//Texture2D tex = ItemIdToTexture(InventoryCrafting[i].X);
									//if (tex!=null) GameDraw.DrawItemInInventory(tex, 1, Global.WindowWidthHalf-300+4+40+xx+4+4, Global.WindowHeightHalf-200+2+4+200+8+yh+4+8);
									xx+=40;

									if (xx==6*40) {
										xx=0;
										yh+=40;
									}
								}
							}
							#endregion

							DrawNeedNew();

							buttonInvTabMaterials.ButtonDraw();
							buttonInvTabPlants.ButtonDraw();
							buttonInvTabTools.ButtonDraw();
							buttonInvTabItems.ButtonDraw();
							buttonInvTabCeramics.ButtonDraw();

							DrawSideInventory();
							if (displayPopUpWindow)DrawChooseItemWindow();
							else if (showMouseItemWhileMooving) InvMouseDraw();
							else if (mouseDrawItemTextInfo) DrawItemMouse();
							break;
						#endregion

						#region Creative
						case InventoryType.Creative:
							spriteBatch.Draw(pixel, new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

							DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234,604,434+2+30,1, color_r0_g0_b0_a100);
							DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233,602,434+30,1, color_r0_g0_b0_a200);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232,600,34), color_r10_g140_b255);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2,600,400-2+30), ColorLightBlue);

							buttonClose.ButtonDraw();

							spriteBatch.Draw(TextureInventoryClothes, new Vector2(Global.WindowWidthHalf-300+4+60, Global.WindowHeightHalf-200+2+4), ColorWhite);

							textOpenInventory.Draw(spriteBatch);

							int AddH=35;
							DrawInventoryWithDIntMoving();
							InventoryDrawClothes();

							if (creativeTabCrafting) {
								#region Crafting
								{
									if (inventoryScrollbarValueCraftingMax>6*4) {
										int size2 =(int)( (1f/((( (int)(inventoryScrollbarValueCraftingMax/5f)+1  )*40)/160f))*160 );
										int pos2=(int)(  (inventoryScrollbarValueCrafting*5/40f) / (inventoryScrollbarValueCraftingMax-6*3)*(160-size2) )*8+50-15;
										if (size2>20) {
											spriteBatch.Draw(scrollbarUpTexture,new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
											spriteBatch.Draw(scrollbarBetweenTexture,new Rectangle(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+10-1+8,20,size2-20), ColorWhite);
											spriteBatch.Draw(scrollbarDownTexture,new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11+size2-20-2+8), ColorWhite);
										} else {
											spriteBatch.Draw(scrollbarUpTexture,new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
											spriteBatch.Draw(scrollbarDownTexture,new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11-2+8), ColorWhite);
										}
									}

									int xx =0;
									int yh=0;

									for (int i=inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
										if (i>inventoryScrollbarValueCraftingMax) break;

										if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8+AddH)) {
											if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8+AddH), color_r128_g128_b128);
											else spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8+AddH), color_r200_g200_b200);
										} else {
											if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8+AddH), color_r150_g150_b150);
											else spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8+AddH), ColorWhite);
										}
									 //   InventoryCrafting[i].SetPos(xx,yh);
										InventoryCrafting[i].DrawCreative();
										//Texture2D tex=ItemIdToTexture(InventoryInventoryCrafting[i].X);
										//if (tex!=null) GameDraw.DrawItemInInventory(tex,1,Global.WindowWidthHalf-300+4+40+xx+4+4,Global.WindowHeightHalf-200+2+4+200+8+yh+4+8+AddH);
										xx+=40;

										if (xx==6*40) {
											xx=0;
											yh+=40;
										}
									}
								}
								#endregion

								DrawNeedNewPlus();
							}

							buttonInvTabBlocks.ButtonDraw();
							buttonInvTabMashines.ButtonDraw();
							buttonInvTabTools.ButtonDraw();
							buttonInvTabPlants.ButtonDraw();
							buttonInvTabItems.ButtonDraw();

							DrawSideInventory();

							if (creativeTabCrafting) {
								ButtonCrafting.ButtonDrawSelected();
								ButtonItems.ButtonDraw();
							} else {
								DrawCreative();
								ButtonCrafting.ButtonDraw();
								ButtonItems.ButtonDrawSelected();
							}

							if (displayPopUpWindow)DrawChooseItemWindow();
							else if (showMouseItemWhileMooving) InvMouseDraw();
							else if (mouseDrawItemTextInfo) DrawItemMouse();
							break;
						#endregion

						#region Shelf
						case InventoryType.Shelf:
							{
								spriteBatch.Draw(pixel,new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

								DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234,604,434+2,1, color_r0_g0_b0_a100);
								DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233,602,434,1, color_r0_g0_b0_a200);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232,600,34), color_r10_g140_b255);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2,600,400-2), ColorLightBlue);

								buttonClose.ButtonDraw();

								spriteBatch.Draw(shelfTexture,new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4,200,200), ColorWhite);
								textOpenInventory.Draw(spriteBatch);
								ItemInv[] invShelf=((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv;

								DrawInventoryWithDIntMoving();

								DrawSideInventory();

								#region Shelf inventory
								{
								  //  int i=0;
									for (int y = 0; y<3*40; y+=40) {
										for (int x = 0; x<3*40; x+=40) {
											spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+10+x+20+5+1+2, Global.WindowHeightHalf+20-2+y+20+3+2), ColorWhite);

										  //  if (!invMove||(invMove && invStartInventory[invStartId]!=invShelf[i])) {

												//Texture2D tex = ItemIdToTexture(invShelf[i].X);
												//if (tex!=null) GameDraw.DrawItemInInventory(tex, invShelf[i], Global.WindowWidthHalf-300+10+x+20+5+1+2+4, Global.WindowHeightHalf+20-2+y+20+3+2+4);
											//}
										  //  i++;
										}
									}

									invShelf[0].Draw();
									invShelf[1].Draw();
									invShelf[2].Draw();

									invShelf[3].Draw();
									invShelf[4].Draw();
									invShelf[5].Draw();

									invShelf[6].Draw();
									invShelf[7].Draw();
									invShelf[8].Draw();
								}
								#endregion

								if (showMouseItemWhileMooving) InvMouseDraw();
								else if (mouseDrawItemTextInfo) DrawItemMouse();
							}
							break;
						#endregion

						#region Wooden box
						case InventoryType.BoxWooden:
							{
								spriteBatch.Draw(pixel,new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

								DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234,604,434+2,1, color_r0_g0_b0_a100);
								DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233,602,434,1, color_r0_g0_b0_a200);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232,600,34), color_r10_g140_b255);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2,600,400-2), ColorLightBlue);

								buttonClose.ButtonDraw();

								spriteBatch.Draw(boxWoodenTexture,new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4,200,200), ColorWhite);
								textOpenInventory.Draw(spriteBatch);
								ItemInv[] invBoxWooden=((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv;

								DrawInventoryWithDIntMoving();

								DrawSideInventory();

								#region Box
								{
									int i=0;
									for (int y = 0; y<2*40; y+=40) {
										for (int x = 0; x<12*40; x+=40) {
											spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+x+59, Global.WindowHeightHalf+59+y), ColorWhite);

										  //  if (!invMove||(invMove&&invStartInventory[invStartId]!=invBoxWooden[i])) {
											invBoxWooden[i].Draw();
												//Texture2D tex = ItemIdToTexture(invBoxWooden[i].X);
												//if (tex!=null) GameDraw.DrawItemInInventory(tex, invBoxWooden[i], Global.WindowWidthHalf-300+x+63,  Global.WindowHeightHalf+y+63);
											//}
											i++;
										}
									}
								}
								#endregion

								 if (showMouseItemWhileMooving) InvMouseDraw();
							else if (mouseDrawItemTextInfo) DrawItemMouse();
							}
							break;
						#endregion

						#region Adv box
						case InventoryType.BoxAdv:
							{
								spriteBatch.Draw(pixel,new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

								DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234,604,434+2,1, color_r0_g0_b0_a100);
								DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233,602,434,1, color_r0_g0_b0_a200);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232,600,34), color_r10_g140_b255);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2,600,400-2), ColorLightBlue);

								buttonClose.ButtonDraw();

								spriteBatch.Draw(boxAdvTexture,new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4,200,200), ColorWhite);

								textOpenInventory.Draw(spriteBatch);
								ItemInv[] invAdvBox=((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv;

								DrawInventoryWithDIntMoving();

								DrawSideInventory();

								#region Box
								{
									int i=0;
									for (int y = 0; y<4*40; y+=40) {
										for (int x = 0; x<12*40; x+=40) {
											spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+20+x, Global.WindowHeightHalf+23+y), ColorWhite);

										  //  if (!invMove||(invMove&&invStartInventory[invStartId]!=invAdvBox[i])) {
											invAdvBox[i].Draw();
												//Texture2D tex = ItemIdToTexture(invAdvBox[i].X);
												//if (tex!=null) GameDraw.DrawItemInInventory(tex, invAdvBox[i], Global.WindowWidthHalf-300+24+x, Global.WindowHeightHalf+23+4+y);
											//}
											i++;
										}
									}
								}
								#endregion

							   if (showMouseItemWhileMooving) InvMouseDraw();
							else if (mouseDrawItemTextInfo) DrawItemMouse();
							}
							break;
							#endregion

						#region Phone
						case InventoryType.Mobile:
							spriteBatch.Draw(pixel,new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

							DrawFrame(Global.WindowWidthHalf-150-2, Global.WindowHeightHalf-234,304,464+2,1, color_r0_g0_b0_a100);
							DrawFrame(Global.WindowWidthHalf-150-1, Global.WindowHeightHalf-233,302,464,1, color_r0_g0_b0_a200);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-232,300,34), color_r10_g140_b255);

							buttonClose.ButtonDraw();
							textOpenInventory.Draw(spriteBatch);

							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-198,300,430), black);
							mobileOS.Draw(spriteBatch,Global.WindowWidthHalf-150, Global.WindowHeightHalf-198,300,430);
							break;
							#endregion

						#region Rocket
						case InventoryType.Rocket:
							spriteBatch.Draw(pixel, new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

							DrawFrame(Global.WindowWidthHalf-150-2, Global.WindowHeightHalf-234,304,464+2,1, color_r0_g0_b0_a100);
							DrawFrame(Global.WindowWidthHalf-150-1, Global.WindowHeightHalf-233,302,464,1, color_r0_g0_b0_a200);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-232,300,34), color_r10_g140_b255);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-198,300,430), ColorLightBlue);

							buttonClose.ButtonDraw();

							textOpenInventory.Draw(spriteBatch);
							spriteBatch.Draw(rocketTexture,new Rectangle(Global.WindowWidthHalf-62, Global.WindowHeightHalf-190,123,380), ColorWhite);

							buttonRocket.ButtonDraw();
							break;
						#endregion

						#region Charger
						case InventoryType.Charger:
							{
								spriteBatch.Draw(pixel, new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

								DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234, 604, 434+2, 1, color_r0_g0_b0_a100);
								DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233, 602, 434, 1, color_r0_g0_b0_a200);
								spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232, 600, 34), color_r10_g140_b255);
								spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2, 600, 400-2), ColorLightBlue);

								buttonClose.ButtonDraw();

								spriteBatch.Draw(chargerTexture, new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4, 200, 200), ColorWhite);
								textOpenInventory.Draw(spriteBatch);

								ItemInv[] invCharger=((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv;

								DrawInventoryWithDIntMoving();

								#region Place for charging
								spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+10+40+20+5+1+2, Global.WindowHeightHalf+20-2+40+20+3+2), ColorWhite);

							   // if (!invMove||(invMove&&invStartInventory[invStartId]!=invCharger[0])) {
									invCharger[0].Draw();
									//Texture2D tex = ItemIdToTexture(invCharger[0].X);
									//if (tex!=null) GameDraw.DrawItemInInventory(tex, invCharger[0], Global.WindowWidthHalf-300+10+40+20+5+1+2+4, Global.WindowHeightHalf+20-2+40+20+3+2+4);
							   // }
								#endregion

								DrawSideInventory();

								if (showMouseItemWhileMooving) InvMouseDraw();
								else if (mouseDrawItemTextInfo) DrawItemMouse();
							}
							break;
						#endregion

						#region Miner
						case InventoryType.Miner:
							{
								spriteBatch.Draw(pixel,new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

								DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234,604,434+2,1, color_r0_g0_b0_a100);
								DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233,602,434,1, color_r0_g0_b0_a200);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232,600,34), color_r10_g140_b255);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2,600,400-2), ColorLightBlue);

								buttonClose.ButtonDraw();

								spriteBatch.Draw(minerTexture,new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4,200,200), ColorWhite);
								textOpenInventory.Draw(spriteBatch);

								ItemInv[] invMiner=((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv;

								DrawInventoryWithDIntMoving();

								DrawSideInventory();

								#region Box
								{
									int i=0;
									for (int y = 0; y<2*40; y+=40) {
										for (int x = 0; x<12*40; x+=40) {
											spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+x+59, Global.WindowHeightHalf+59+y), ColorWhite);

										//    if (!invMove||(invMove&&invStartInventory[invStartId]!=invMiner[i])) {
												invMiner[i].Draw();
												//Texture2D tex = ItemIdToTexture(invMiner[i].Id);
												//if (tex!=null) GameDraw.DrawItemInInventory(tex, invMiner[i], Global.WindowWidthHalf-300+x+63,  Global.WindowHeightHalf+y+63);
										  //  }
											i++;
										}
									}
								}
								#endregion

								if (showMouseItemWhileMooving) InvMouseDraw();
								else if (mouseDrawItemTextInfo) DrawItemMouse();
							}
							break;
						#endregion

						#region Radio
						case InventoryType.Radio:
							{
								spriteBatch.Draw(pixel,new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

								DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234,604,434+2,1, color_r0_g0_b0_a100);
								DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233,602,434,1, color_r0_g0_b0_a200);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232,600,34), color_r10_g140_b255);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2,600,400-2), ColorLightBlue);

								buttonClose.ButtonDraw();

								spriteBatch.Draw(radioTexture,new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4,200,200),new Rectangle(16*(int)(15*_secondTimer/60f),0,16,16), ColorWhite);
								textOpenInventory.Draw(spriteBatch);


								if (radioSongs!=null) {
									for (int i=0; i<radioSongs.Length; i++) {
										BitmapFont.bitmapFont18.DrawText(spriteBatch,new FileInfo(radioSongs[i]).Name.Substring(0,(new FileInfo(radioSongs[i]).Name).LastIndexOf(".")),Global.WindowWidthHalf-300-2+10+240, Global.WindowHeightHalf-234+10+40+i*40,black);
									}
								}

								if (radioplaying) {
									spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2+400-50,600,50), ColorGray);
									spriteBatch.Draw(RadioButtonPause,new Vector2(Global.WindowWidthHalf-24, Global.WindowHeightHalf-200+2+400-50), ColorWhite);
								}
							}
							break;
						#endregion

						#region Composter
						case InventoryType.Composter:
							{
								spriteBatch.Draw(pixel,new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

								DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234,604,434+2,1, color_r0_g0_b0_a100);
								DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233,602,434,1, color_r0_g0_b0_a200);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232,600,34), color_r10_g140_b255);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2,600,400-2), ColorLightBlue);

								buttonClose.ButtonDraw();

								spriteBatch.Draw(ComposterFullTexture,new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4,200,200), ColorWhite);
								textOpenInventory.Draw(spriteBatch);

								ItemInv[] invComposter=((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv;

								DrawInventoryWithDIntMoving();

								DrawSideInventory();

								#region Composter inventory
								{
									int i=0;
									for (int y = 0; y<3*40; y+=40) {
										for (int x = 0; x<3*40; x+=40) {
											spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+10+x+20+5+1+2, Global.WindowHeightHalf+20-2+y+20+3+2), ColorWhite);

										  //  if (!invMove||(invMove&&invStartInventory[invStartId]!=invComposter[i])) {
												invComposter[i].Draw();
												//Texture2D tex = ItemIdToTexture(invComposter[i].X);
												//if (tex!=null) GameDraw.DrawItemInInventory(tex, invComposter[i], Global.WindowWidthHalf-300+10+x+20+5+1+2+4, Global.WindowHeightHalf+20-2+y+20+3+2+4);
										   // }
											i++;
										}
									}
								}
								#endregion

								if (showMouseItemWhileMooving) InvMouseDraw();
								else if (mouseDrawItemTextInfo) DrawItemMouse();
							}
							break;
						#endregion

						#region SewingMachine
						case InventoryType.SewingMachine:
							spriteBatch.Draw(pixel, new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

							DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234, 604, 434+2, 1, color_r0_g0_b0_a100);
							DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233, 602, 434, 1, color_r0_g0_b0_a200);
							spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232, 600, 34), color_r10_g140_b255);
							spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2, 600, 400-2), ColorLightBlue);

							buttonClose.ButtonDraw();

							spriteBatch.Draw(sewingMachineTexture, new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4, 200, 200), ColorWhite);
							textOpenInventory.Draw(spriteBatch);

							DrawInventoryNormal();

							#region Clothes
							{
								if (inventoryScrollbarValueCraftingMax>6*4) {
									int size2 = (int)((1f/((((int)(inventoryScrollbarValueCraftingMax/5f)+1)*40)/160f))*160);
									int pos2 = (int)((((inventoryScrollbarValueCrafting*5)/40f)/inventoryScrollbarValueCraftingMax)*(160-size2))*8;
									if (size2>20) {
										spriteBatch.Draw(scrollbarUpTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
										spriteBatch.Draw(scrollbarBetweenTexture, new Rectangle(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+10-1+8, 20, size2-20), ColorWhite);
										spriteBatch.Draw(scrollbarDownTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11+size2-20-2+8), ColorWhite);
									} else {
										spriteBatch.Draw(scrollbarUpTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+8), ColorWhite);
										spriteBatch.Draw(scrollbarDownTexture, new Vector2(Global.WindowWidthHalf, Global.WindowHeightHalf-200+2+4+200+8+pos2+11-2+8), ColorWhite);
									}
								}

								int xx = 0;
								int yh = 0;

								for (int i = inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
									if (i>inventoryScrollbarValueCraftingMax) break;
									if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {
									//if (newMouseState.X>Global.WindowWidthHalf-300+4+40+4+xx&&newMouseState.X<Global.WindowWidthHalf-300+4+40+4+xx+40
									//&& newMouseState.Y>Global.WindowHeightHalf-200+2+4+200+8+yh+8&&newMouseState.Y<Global.WindowHeightHalf-200+2+4+200+8+yh+8+40) {
										if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r128_g128_b128);
										else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r200_g200_b200);
									} else {
										if (selectedCraftingItem==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), color_r150_g150_b150);
										else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8), ColorWhite);
									}
									InventoryCrafting[i].Draw();
									//Texture2D tex = ItemIdToTexture(InventoryCrafting[i].X);
									//if (tex!=null) GameDraw.DrawItemInInventory(tex, 1, Global.WindowWidthHalf-300+4+40+xx+4+4, Global.WindowHeightHalf-200+2+4+200+8+yh+4+8);
									xx+=40;

									if (xx==6*40) {
										xx=0;
										yh+=40;
									}
								}
							}
							#endregion


							DrawNeedNew();

							buttonInvHead.ButtonDraw();
							buttonInvChest.ButtonDraw();
							buttonInvLegs.ButtonDraw();
							buttonInvShoes.ButtonDraw();
							buttonInvUnderwear.ButtonDraw();

							DrawSideInventory();
							if (displayPopUpWindow)DrawChooseItemWindow();
						   else if (showMouseItemWhileMooving) InvMouseDraw();
							else if (mouseDrawItemTextInfo) DrawItemMouse();
							break;
						#endregion

						#region OxygenMachine
						case InventoryType.OxygenMachine:
							{
								spriteBatch.Draw(pixel, new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

								DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234, 604, 434+2, 1, color_r0_g0_b0_a100);
								DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233, 602, 434, 1, color_r0_g0_b0_a200);
								spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232, 600, 34), color_r10_g140_b255);
								spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2, 600, 400-2), ColorLightBlue);

								buttonClose.ButtonDraw();

								spriteBatch.Draw(TextureOxygenMachine, new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4, 200, 200), ColorWhite);
								textOpenInventory.Draw(spriteBatch);

								ItemInv[] invOxygenMachine=((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv;

								DrawInventoryWithDIntMoving();

								#region Place for charging
								spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+10+40+20+5+1+2, Global.WindowHeightHalf+20-2+40+20+3+2), ColorWhite);

							   // if (!invMove||(invMove&&invStartInventory[invStartId]!=invOxygenMachine[0])) {
									invOxygenMachine[0].Draw();
								//}
								#endregion

								DrawSideInventory();

								if (showMouseItemWhileMooving) InvMouseDraw();
								else if (mouseDrawItemTextInfo) DrawItemMouse();
							}
							break;
						#endregion

						#region Barrel
						case InventoryType.Barrel:
							{
								spriteBatch.Draw(pixel,new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));

								DrawFrame(Global.WindowWidthHalf-300-2, Global.WindowHeightHalf-234,604,434+2,1, color_r0_g0_b0_a100);
								DrawFrame(Global.WindowWidthHalf-300-1, Global.WindowHeightHalf-233,602,434,1, color_r0_g0_b0_a200);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-232,600,34), color_r10_g140_b255);
								spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-300, Global.WindowHeightHalf-200+2,600,400-2), ColorLightBlue);

								buttonClose.ButtonDraw();

								spriteBatch.Draw(TextureBarrel, new Rectangle(Global.WindowWidthHalf-300+4, Global.WindowHeightHalf-200+2+4,200,200), ColorWhite);
								textOpenInventory.Draw(spriteBatch);
								Barrel barrel=(Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y];
								ItemInv[] invBarrel=barrel.Inv;

								DrawInventoryWithDIntMoving();

								DrawSideInventory();

								#region Barel inventory
								Vector2 vec=new Vector2(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250);
								// In
								spriteBatch.Draw(inventorySlotInTexture, vec, ColorWhite);
								invBarrel[0].Draw();

								// Out
								vec.Y+=64;
								spriteBatch.Draw(inventorySlotOutTexture, vec, ColorWhite);
								invBarrel[1].Draw();

								//bar
								spriteBatch.Draw(TextureBarBarrel, new Vector2(Global.WindowWidthHalf-300+4+42, Global.WindowHeightHalf-200+2+4+217), ColorWhite);

								int a=(int)(barrel.LiquidAmount/255f*146);

								switch (barrel.LiquidId) {
									case (byte)LiquidId.Water:
										spriteBatch.Draw(waterTexture, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a),new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), ColorWhite);
										break;

									case (byte)LiquidId.WaterSalt:
										spriteBatch.Draw(waterTexture, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a),new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), ColorWhite);
										break;

									case (byte)LiquidId.Lava:
										spriteBatch.Draw(lavaTexture, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), ColorWhite);
										break;

									case (byte)LiquidId.DyeArmy:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), ColorArmy/* new Color((byte)34,(byte)48,(byte)17,(byte)255)*/);
										break;

									case (byte)LiquidId.DyeBlack:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Black);
										break;

									case (byte)LiquidId.DyeBlue:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Blue);
										break;

									case (byte)LiquidId.DyeBrown:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Brown);
										break;

									case (byte)LiquidId.DyeGray:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Gray);
										break;

									case (byte)LiquidId.DyeWhite:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.White);
										break;

									case (byte)LiquidId.DyeYellow:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Yellow);
										break;

									case (byte)LiquidId.DyeViolet:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Violet);
										break;

									case (byte)LiquidId.DyeTeal:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Teal);
										break;

									case (byte)LiquidId.DyeSpringGreen:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), ColorSpringGreen/* new Color(143, 225, 44)*/);
										break;

									case (byte)LiquidId.DyeRoseQuartz:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), ColorRoseQuartz/*new Color(170, 152, 169)*/);
										break;

									case (byte)LiquidId.DyeRed:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Red);
										break;

									case (byte)LiquidId.DyeDarkRed:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.DarkRed);
										break;

									case (byte)LiquidId.DyePurple:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Purple);
										break;

									case (byte)LiquidId.DyePink:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Pink);
										break;

									case (byte)LiquidId.DyeOrange:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Orange);
										break;

									case (byte)LiquidId.DyeOlive:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Olive);
										break;

									case (byte)LiquidId.DyeMagenta:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Magenta);
										break;

									case (byte)LiquidId.DyeLightGreen:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.LightGreen);
										break;

									case (byte)LiquidId.DyeLightGray:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.LightGray);
										break;

									case (byte)LiquidId.DyeLightBlue:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.LightBlue);
										break;

									case (byte)LiquidId.DyeGreen:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Green);
										break;

									case (byte)LiquidId.DyeDarkGreen:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.DarkGreen);
										break;

									case (byte)LiquidId.DyeGold:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.Gold);
										break;

									case (byte)LiquidId.DyeDarkBlue:
										spriteBatch.Draw(TextureWaterGraystyle, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), Color.DarkBlue);
										break;

									default:
										spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+42+5, Global.WindowHeightHalf-200+2+4+217+5+146-a, 25, a), new Rectangle(0,0,25,(int)(barrel.LiquidAmount/255f*16)), ColorWhite);
										break;

								}
								#endregion

								if (showMouseItemWhileMooving) InvMouseDraw();
								else if (mouseDrawItemTextInfo) DrawItemMouse();
							}
							break;
						#endregion

						#region Game menu
						case InventoryType.GameMenu:
							spriteBatch.Draw(pixel, new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), new Color((uint)(animationInvBack << 24)));
							
							DrawFrame(Global.WindowWidthHalf-150-2, Global.WindowHeightHalf-234+50, 304, 464+2-100,1, color_r0_g0_b0_a100);
							DrawFrame(Global.WindowWidthHalf-150-1, Global.WindowHeightHalf-233+50, 302, 464-100,  1, color_r0_g0_b0_a200);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-232+50,300,34), color_r10_g140_b255);
							spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-198+50,300,430-100), ColorLightBlue);
							textOpenInventory.Draw(spriteBatch);

							// Exit button [X]
							buttonClose.ButtonDraw();
													
							// Continue game
							buttonContinue.ButtonDraw();

							// Exit game
							buttonExit.ButtonDraw();
						
							// Acheavements
							buttonAcheavements.ButtonDraw();

							// Use a gift code
							buttonUseGiftCode.ButtonDraw();
							break;
						#endregion

					}
						#endregion

					#region Draw debug
					if (debug) {
						fpss+=1000f / (float)gameTime.ElapsedGameTime.TotalMilliseconds;
						timerDraw60--;
						if (timerDraw60<0) {
							timerDraw60=59;
							fps=fpss/60f;

							fpss=0;
						}
						if (gameTime.ElapsedGameTime.TotalMilliseconds!=0) {
							GameDraw.DrawTextShadowMin(5, 5,"< Information for developers > (F1 hide)" + Environment.NewLine +
							//"[Player] X: " + (int)PlayerX + ", Y: " +  (int)PlayerY + Environment.NewLine +
							"[Mouse] X: " + (int)mousePos.X + ", Y: " + (int)mousePos.Y + Environment.NewLine +

							"[World]: " + world+ Environment.NewLine +
							"[Biome]: "+BiomeCurrent+ Environment.NewLine +
							"[Temperature]: "+Math.Round(Temperature,1)+ Environment.NewLine +
							"[Gravity]: "+Math.Round(gravity*20f,2)+Environment.NewLine+
							//"[Rain]: "+rain+ Environment.NewLine +
							"[Date]: Y: "+year+", Day: "+day+", Time: " +time/hour+":" + ((int)((time- (time/hour*hour))*(60f/hour))).ToString("00")+Environment.NewLine +
						//	Environment.NewLine +
							"[Drawing surface size] "+((terrainStartIndexW-terrainStartIndexX)*(terrainStartIndexH-terrainStartIndexY))+Environment.NewLine +
							//Environment.NewLine +
							"[Items count]: "+DroppedItems.Count +Environment.NewLine+
							"[Particles count]: "+(energy.Count+snowDots.Count+rainDots.Count+FallingLeaves.Count)+Environment.NewLine+
						//	"[Light]: " +dayAlpha+Environment.NewLine +
						//	"[Moon]: " +(moonSpeed/46)+Environment.NewLine +
						//	"[Wind]: "+wind+ Environment.NewLine +
						//	"[Time to change rain]: "+changeRain+ Environment.NewLine +
							"[Fps]:  "+/*1f / (float)gameTime.ElapsedGameTime.TotalSeconds*/(int)Math.Round(fps, 3)+Environment.NewLine+
							"[Fps f]:  "+1f/(float)gameTime.ElapsedGameTime.TotalSeconds+Environment.NewLine+
							"[CPU] Proces: "+(usageCpuProcess/Environment.ProcessorCount).ToString("0.00")+"%, Volné cpu: "+(100-usageCpu).ToString("0.00")+"%"+Environment.NewLine+
							"[RAM] Proces: "+(usageRamProcess/1048576).ToString("0.00")+"MB, Volná ram: "+usageRam.ToString("0.00")+"MB"+Environment.NewLine, new Color(dayAlpha*2, dayAlpha*2, dayAlpha*2)); ;

						}
					} else if (Setting.Fps) {
						fpss+=1000f/(float)gameTime.ElapsedGameTime.TotalMilliseconds;
						timerDraw60--;
						if (timerDraw60<0) {
							timerDraw60=59;
							fps=fpss/60f;

							fpss=0;
						}
						if (gameTime.ElapsedGameTime.TotalMilliseconds!=0) BitmapFont.bitmapFont18.DrawText(spriteBatch, "Fps: "+(int)Math.Round(fps, 2), 5, 5);
					}
					#endregion

					spriteBatch.End();
				}
				#endregion
			}
			base.Draw(gameTime);
		}

		public override void Resize() {
			if (dontDoGame) return;

			SetCaptionInventory();
			Translation=ZoomMatrix*Matrix.CreateTranslation(new Vector3(Global.WindowWidthHalf, Global.WindowHeightHalf, 0));

			Fullscreen=new Rectangle(0, 0, Global.WindowWidth, Global.WindowHeight);
			CreateGradientTexture();
			sunLightTarget?.Dispose();
			sunLightTarget=new RenderTarget2D(Graphics, Global.WindowWidth, Global.WindowHeight);

			modificatedLightTarget?.Dispose();
			modificatedLightTarget=new RenderTarget2D(Graphics, Global.WindowWidth, Global.WindowHeight);

			if (Global.WorldDifficulty==2) {
				if (inventory==InventoryType.Creative) {

					buttonNext.Position=new Vector2(Global.WindowWidthHalf+20+8+10+10+40+70-4, Global.WindowHeightHalf+160-30+8+16-20-30+5+35);
					buttonPrev.Position=new Vector2(Global.WindowWidthHalf+20+8+10+10+40-4, Global.WindowHeightHalf+160-30+8+16-20-30+5+35);

					buttonCraft1x.Position=new Vector2(Global.WindowWidthHalf+20+8+10+10, Global.WindowHeightHalf+160-30+8+16+35);
					buttonCraft10x.Position=new Vector2(Global.WindowWidthHalf+10+80+8+10+10, Global.WindowHeightHalf+160-30+8+16+35);
					buttonCraft100x.Position=new Vector2(Global.WindowWidthHalf+10+170+8, Global.WindowHeightHalf+160-30+8+16+35);


					ButtonCrafting.Position=new Vector2(Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10+200+30+5);
					ButtonItems.Position=new Vector2(Global.WindowWidthHalf-300-2+10+150+10, Global.WindowHeightHalf-234+10+200+30+5);
				} else {
					buttonNext.Position=new Vector2(Global.WindowWidthHalf+20+8+10+10+40+70-4, Global.WindowHeightHalf+160-30+8+16-20-30+5);
					buttonPrev.Position=new Vector2(Global.WindowWidthHalf+20+8+10+10+40-4, Global.WindowHeightHalf+160-30+8+16-20-30+5);

					buttonCraft1x.Position=new Vector2(Global.WindowWidthHalf+20+8+10+10, Global.WindowHeightHalf+160-30+8+16);
					buttonCraft10x.Position=new Vector2(Global.WindowWidthHalf+10+80+8+10+10, Global.WindowHeightHalf+160-30+8+16);
					buttonCraft100x.Position=new Vector2(Global.WindowWidthHalf+10+170+8, Global.WindowHeightHalf+160-30+8+16);
				}
			} else {
				buttonNext.Position=new Vector2(Global.WindowWidthHalf+20+8+10+10+40+70-4, Global.WindowHeightHalf+160-30+8+16-20-30+5);
				buttonPrev.Position=new Vector2(Global.WindowWidthHalf+20+8+10+10+40-4, Global.WindowHeightHalf+160-30+8+16-20-30+5);

				buttonCraft1x.Position=new Vector2(Global.WindowWidthHalf+20+8+10+10, Global.WindowHeightHalf+160-30+8+16);
				buttonCraft10x.Position=new Vector2(Global.WindowWidthHalf+10+80+8+10+10, Global.WindowHeightHalf+160-30+8+16);
				buttonCraft100x.Position=new Vector2(Global.WindowWidthHalf+10+170+8, Global.WindowHeightHalf+160-30+8+16);
			}

			buttonRocket.Position=new Vector2(Global.WindowWidthHalf-buttonRocket.texture.Width/2, Global.WindowHeightHalf-198+430-buttonRocket.texture.Height-5);
			buttonRadio.Position=new Vector2(Global.WindowWidthHalf-300-2+10+10+10, Global.WindowHeightHalf-234+10+240+40+40);

			switch (inventory) {
				case InventoryType.GameMenu:
					{
						int xx = Global.WindowWidthHalf-300+10+200+10+4;
						// Continue game
						buttonContinue.Position=new Vector2(xx,Global.WindowHeightHalf-232+1+30+60-2+50);

						// Exit game
						buttonExit.Position=new Vector2(xx,Global.WindowHeightHalf-232+1+30+60+60-2+50);
						
						// Acheavements
						buttonAcheavements.Position=new Vector2(xx,Global.WindowHeightHalf-232+1+30+60+60+60-2+50);

						// Use a gift code
						buttonUseGiftCode.Position=new Vector2(xx,Global.WindowHeightHalf-232+1+30+60+60+60+60-2+50);

						// Save (Manual, but game using autosave every x s)
						//buttonSave.Position=new Vector2(xx,Global.WindowHeightHalf-232+1+30+60+60+60+60);

						buttonClose.Position.X=Global.WindowWidthHalf+150-32;
						buttonClose.Position.Y=Global.WindowHeightHalf-232+1+50;
					}
					break;

				case InventoryType.BasicInv: 
					{
						buttonClose.Position.X=Global.WindowWidthHalf+300-32;
						buttonClose.Position.Y=Global.WindowHeightHalf-232+1;

						int xx = Global.WindowWidthHalf-300+10;
						buttonInvTabBlocks.Position.X=xx;
						buttonInvTabBlocks.Position.Y=Global.WindowHeightHalf+20-2;

						buttonInvTabMashines.Position.X=xx;
						buttonInvTabMashines.Position.Y=Global.WindowHeightHalf+20+32+2-2;

						buttonInvTabTools.Position.X=xx;
						buttonInvTabTools.Position.Y=Global.WindowHeightHalf+20+32+32+4-2;

						buttonInvTabPlants.Position.X=xx;
						buttonInvTabPlants.Position.Y=Global.WindowHeightHalf+20+32+32+32+6-2;

						buttonInvTabItems.Position.X=xx;
						buttonInvTabItems.Position.Y=Global.WindowHeightHalf+20+32+64+32+8-2;

						//int x=Global.WindowWidthHalf-300+4+60;
						//int y=Global.WindowHeightHalf-200+2+4;

						//int i=0;
						//for (; i<4; i++) {
						//   InventoryClothes[i].SetPos(x,y+=40);
						//}
						//y=Global.WindowHeightHalf-200+2+4;
						//for (; i<8; i++) {
						//   InventoryClothes[i].SetPos(x,y+=40);
						//}
						for (int i = 0; i<8; i++) {
							InventoryClothes[i].SetPos(InventoryGetPosClothes(i));
						}
					}
					break;

				case InventoryType.Creative: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;

					int xx = Global.WindowWidthHalf-300+10;
					buttonInvTabBlocks.Position.X=xx;
					buttonInvTabBlocks.Position.Y=Global.WindowHeightHalf+20-2+35;

					buttonInvTabMashines.Position.X=xx;
					buttonInvTabMashines.Position.Y=Global.WindowHeightHalf+20+32+2-2+35;

					buttonInvTabTools.Position.X=xx;
					buttonInvTabTools.Position.Y=Global.WindowHeightHalf+20+32+32+4-2+35;

					buttonInvTabPlants.Position.X=xx;
					buttonInvTabPlants.Position.Y=Global.WindowHeightHalf+20+32+32+32+6-2+35;

					buttonInvTabItems.Position.X=xx;
					buttonInvTabItems.Position.Y=Global.WindowHeightHalf+20+32+64+32+8-2+35;

					//int x=Global.WindowWidthHalf-300+4+60;
					//int y=Global.WindowHeightHalf-200+2+4;

					//int i=0;
					//for (; i<4; i++) {
					//   InventoryClothes[i].SetPos(x,y+=40);
					//}
					//y=Global.WindowHeightHalf-200+2+4;
					//for (; i<8; i++) {
					//   InventoryClothes[i].SetPos(x,y+=40);
					//}

					for (int i = 0; i<8; i++) {
						InventoryClothes[i].SetPos(InventoryGetPosClothes(i));
					}
				}
				break;

				case InventoryType.Desk: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;

					int xx = Global.WindowWidthHalf-300+10;
					buttonInvTabBlocks.Position.X=xx;
					buttonInvTabBlocks.Position.Y=Global.WindowHeightHalf+20-2;

					buttonInvTabMashines.Position.X=xx;
					buttonInvTabMashines.Position.Y=Global.WindowHeightHalf+20+32+2-2;

					buttonInvTabTools.Position.X=xx;
					buttonInvTabTools.Position.Y=Global.WindowHeightHalf+20+32+32+4-2;

					buttonInvTabPlants.Position.X=xx;
					buttonInvTabPlants.Position.Y=Global.WindowHeightHalf+20+32+32+32+6-2;

					buttonInvTabItems.Position.X=xx;
					buttonInvTabItems.Position.Y=Global.WindowHeightHalf+20+32+64+32+8-2;
				}
				break;

				case InventoryType.FurnaceStone: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;

					int xx = Global.WindowWidthHalf-300+10;
					buttonInvTabMaterials.Position.X=xx;
					buttonInvTabMaterials.Position.Y=Global.WindowHeightHalf+20-2;

					buttonInvTabGlass.Position.X=xx;
					buttonInvTabGlass.Position.Y=Global.WindowHeightHalf+20+32+2-2;

					buttonInvTabCeramics.Position.X=xx;
					buttonInvTabCeramics.Position.Y=Global.WindowHeightHalf+20+32+32+4-2;

					buttonInvTabFood.Position.X=xx;
					buttonInvTabFood.Position.Y=Global.WindowHeightHalf+20+32+32+32+6-2;

					buttonInvTabTools.Position.X=xx;
					buttonInvTabTools.Position.Y=Global.WindowHeightHalf+20+32+64+32+8-2;
				}
				break;

				case InventoryType.FurnaceElectric: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;

					int xx = Global.WindowWidthHalf-300+10;
					buttonInvTabMaterials.Position.X=xx;
					buttonInvTabMaterials.Position.Y=Global.WindowHeightHalf+20-2;

					buttonInvTabGlass.Position.X=xx;
					buttonInvTabGlass.Position.Y=Global.WindowHeightHalf+20+32+2-2;

					buttonInvTabCeramics.Position.X=xx;
					buttonInvTabCeramics.Position.Y=Global.WindowHeightHalf+20+32+32+4-2;

					buttonInvTabFood.Position.X=xx;
					buttonInvTabFood.Position.Y=Global.WindowHeightHalf+20+32+32+32+6-2;

					buttonInvTabTools.Position.X=xx;
					buttonInvTabTools.Position.Y=Global.WindowHeightHalf+20+32+64+32+8-2;
				}
				break;

				case InventoryType.SewingMachine: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;

					int xx = Global.WindowWidthHalf-300+10;
					buttonInvHead.Position.X=xx;
					buttonInvHead.Position.Y=Global.WindowHeightHalf+20-2;

					buttonInvChest.Position.X=xx;
					buttonInvChest.Position.Y=Global.WindowHeightHalf+20+32+2-2;

					buttonInvLegs.Position.X=xx;
					buttonInvLegs.Position.Y=Global.WindowHeightHalf+20+32+32+4-2;

					buttonInvShoes.Position.X=xx;
					buttonInvShoes.Position.Y=Global.WindowHeightHalf+20+32+32+32+6-2;

					buttonInvUnderwear.Position.X=xx;
					buttonInvUnderwear.Position.Y=Global.WindowHeightHalf+20+32+64+32+8-2;
				}
				break;

				case InventoryType.Macerator: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;

					int xx = Global.WindowWidthHalf-300+10;
					buttonInvTabMaterials.Position.X=xx;
					buttonInvTabMaterials.Position.Y=Global.WindowHeightHalf+20-2;

					buttonInvTabPlants.Position.X=xx;
					buttonInvTabPlants.Position.Y=Global.WindowHeightHalf+20+32+2-2;

					buttonInvTabTools.Position.X=xx;
					buttonInvTabTools.Position.Y=Global.WindowHeightHalf+20+32+32+4-2;

					buttonInvTabItems.Position.X=xx;
					buttonInvTabItems.Position.Y=Global.WindowHeightHalf+20+32+32+32+6-2;

					buttonInvTabCeramics.Position.X=xx;
					buttonInvTabCeramics.Position.Y=Global.WindowHeightHalf+20+32+64+32+8-2;
				}
				break;

				case InventoryType.Shelf: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;

					ItemInv[] inv = ((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv;

					for (int i = 0; i<InvMaxShelf; i++) inv[i].SetPos(InventoryGetPosShelf(i));
				}
				break;

				case InventoryType.Barrel: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;

					ItemInv[] inv = ((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv;

					for (int i = 0; i<InvMaxBarrel; i++) inv[i].SetPos(InventoryGetPosBarrel(i));
				}
				break;

				case InventoryType.BoxWooden: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;
				}
				break;

				case InventoryType.BoxAdv: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;
				}
				break;

				case InventoryType.Charger: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;
				}
				break;

				case InventoryType.Miner: {
					buttonClose.Position.X=Global.WindowWidthHalf+300-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;
				}
				break;

				case InventoryType.Rocket: {
					buttonClose.Position.X=Global.WindowWidthHalf+150-32;
					buttonClose.Position.Y=Global.WindowHeightHalf-232+1;
				}
				break;
			}

			{
				int x = Global.WindowWidth-36;
				int y = Global.WindowHeightHalf-80+4-40;
				//    if (Global.WorldDifficulty==2) y+=30;
				for (int i = 0; i<5; i++) {
					InventoryNormal[i].SetPos(x, y+=40);
				}
				for (int i = 5; i<maxInvCount; i++) {
					InventoryNormal[i].SetPos(InventoryGetPosNormal(i));
				}
			}
		}

		void MouseRightAction() {
			int x = mousePosDiv16.X, 
				y = mousePosDiv16.Y;

			if (y<0) return;
			if (y>125) return;

			Terrain chunk = terrain[x];

			if (chunk!=null) {

				#region Liquits
				if (InventoryNormal[boxSelected].Id==(ushort)Items.Bottle) {
					if (chunk.IsTopBlocks[y]) {
						switch (chunk.TopBlocks[y].Id) {
							case (ushort)BlockId.Oil:
								if (Global.WorldDifficulty!=2) {
									InventoryRemoveSelectedItem();
									InventoryAdd(new ItemNonInvTool((ushort)Items.BottleOil, 99, 99));
								}

								chunk.TopBlocks[y]=null;
								chunk.IsTopBlocks[y]=false;
								return;

							case (ushort)BlockId.WaterSalt:
								if (Global.WorldDifficulty!=2) {
									InventoryRemoveSelectedItem();
									InventoryAdd(new ItemNonInvTool((ushort)Items.BottleWater,99,99));
								}
								chunk.TopBlocks[y]=null;
								chunk.IsTopBlocks[y]=false;
								return;
						}
					}
				}
				if (InventoryNormal[boxSelected].Id==(ushort)Items.Bucket) {
					if (chunk.IsTopBlocks[y]) {
						switch (chunk.TopBlocks[y].Id) {
							case (ushort)BlockId.Oil:
								if (Global.WorldDifficulty!=2) {
									InventoryRemoveSelectedItem();
									InventoryAdd(new ItemNonInvTool((ushort)Items.BottleOil,99,99));
								}
								chunk.TopBlocks[y]=null;
								chunk.IsTopBlocks[y]=false;
								return;

							case (ushort)BlockId.WaterBlock:
								if (Global.WorldDifficulty!=2) {
									InventoryRemoveSelectedItem();
									InventoryAdd(new ItemNonInvTool((ushort)Items.BottleWater,99,99));
								}
								/*((AirSolidBlock)chunk.SolidBlocks[y]).Top=*/chunk.TopBlocks[y]=null;
								chunk.IsTopBlocks[y]=false;
								return;

							case (ushort)BlockId.WaterSalt:
								if (Global.WorldDifficulty!=2) {
									InventoryRemoveSelectedItem();
									InventoryAdd(new ItemNonInvTool((ushort)Items.BottleSaltWater,99,99));
								}
								/*((AirSolidBlock)chunk.SolidBlocks[y]).Top=*/chunk.TopBlocks[y]=null;
								chunk.IsTopBlocks[y]=false;
								return;
						}
					}

				}
				#endregion

				#region Get food
				if (chunk.IsTopBlocks[y]) {
					if (Global.WorldDifficulty!=1 || FastMath.DistanceInt(mousePosDiv16.X,mousePosDiv16.Y,PlayerX,PlayerY) < 8*16){
						switch (chunk.TopBlocks[y].Id) {
							case (ushort)BlockId.BucketWithLatex:
								DropItemFromLeaves((ushort)BlockId.BucketForRubber, (ushort)Items.Resin,TextureBucketForRubber);
								//DropItemToPos(new ItemNonInvBasic((ushort)Items.Resin,1), mousePosRoundX, mousePosRoundY);

								//if (chunk.IsBackground[y]){
								//    ((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.BucketForRubber, new Vector2(mousePosRoundX, mousePosRoundY));
								//} else {
								//    chunk.SolidBlocks[y]=new AirSolidBlock{
								//        Top=TopBlockFromId((ushort)BlockId.BucketForRubber, new Vector2(mousePosRoundX, mousePosRoundY))
								//    };
								//}
								//chunk.IsTopBlocks[y]=true;

							  //  ((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.BucketForRubber, new Vector2(mousePosRoundX, mousePosRoundY));
								bucketRubber.Add(new ShortAndByte(x, y));
								//barEnergy+=0.02f;
								//if (barEnergy>32) barEnergy=32;
								return;

							case (ushort)BlockId.PlumLeavesWithPlums:
								DropFoodFromLeaves((ushort)BlockId.PlumLeaves, (ushort)Items.Plum,TexturePlumLeaves);
								//DropItemToPos(new ItemNonInvBasic((ushort)Items.Plum,1), mousePosRoundX, mousePosRoundY);
								////((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.PlumLeaves, new Vector2(mousePosRoundX, mousePosRoundY));

								//if (chunk.IsBackground[y]){
								//    ((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.PlumLeaves, new Vector2(mousePosRoundX, mousePosRoundY));
								//} else {
								//    chunk.SolidBlocks[y]=new AirSolidBlock{
								//        Top=TopBlockFromId((ushort)BlockId.PlumLeaves, new Vector2(mousePosRoundX, mousePosRoundY))
								//    };
								//}

								//barEnergy+=0.02f;
								//if (barEnergy>32) barEnergy=32;
								return;

							case (ushort)BlockId.CherryLeavesWithCherries:
								DropFoodFromLeaves((ushort)BlockId.CherryLeaves, (ushort)Items.Cherry,TextureCherryLeaves);
								//DropItemToPos(new ItemNonInvBasic((ushort)Items.Cherry,1), mousePosRoundX, mousePosRoundY);
								//((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.CherryLeaves, new Vector2(mousePosRoundX, mousePosRoundY));
								//barEnergy+=0.02f;
								//if (barEnergy>32) barEnergy=32;
								return;

							case (ushort)BlockId.AppleLeavesWithApples:
								DropFoodFromLeaves((ushort)BlockId.AppleLeaves, (ushort)Items.Apple,TextureAppleLeaves);
								//DropItemToPos(new ItemNonInvBasic((ushort)Items.Apple,1), mousePosRoundX, mousePosRoundY);
								//((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.AppleLeaves, new Vector2(mousePosRoundX, mousePosRoundY));
								//barEnergy+=0.02f;
								//if (barEnergy>32) barEnergy=32;
								return;

							case (ushort)BlockId.LemonLeavesWithLemons:
								DropFoodFromLeaves((ushort)BlockId.LemonLeaves, (ushort)Items.Lemon,TextureLemonLeaves);
								//DropItemToPos(new ItemNonInvBasic((ushort)Items.Lemon,1),mousePosRoundX, mousePosRoundY);
								//((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.LemonLeaves, new Vector2(mousePosRoundX, mousePosRoundY));
								//barEnergy+=0.02f;
								//if (barEnergy>32) barEnergy=32;
								return;

							case (ushort)BlockId.OrangeLeavesWithOranges:
								DropFoodFromLeaves((ushort)BlockId.OrangeLeaves, (ushort)Items.Orange,TextureOrangeLeaves);
								//DropItemToPos(new ItemNonInvBasic((ushort)Items.Orange,1),mousePosRoundX, mousePosRoundY);
								//((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.OrangeLeaves,new Vector2(mousePosRoundX, mousePosRoundY));
								//barEnergy+=0.02f;
								//if (barEnergy>32) barEnergy=32;
								return;

							case (ushort)BlockId.OliveLeavesWithOlives:
								DropFoodFromLeaves((ushort)BlockId.OliveLeaves, (ushort)Items.Olive,TextureOliveLeaves);
								//DropItemToPos(new ItemNonInvBasic((ushort)Items.Olive,1),mousePosRoundX, mousePosRoundY);
								//((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.OliveLeaves,new Vector2(mousePosRoundX, mousePosRoundY));
								//barEnergy+=0.02f;
								//if (barEnergy>32) barEnergy=32;
								return;

							case (ushort)BlockId.KapokLeacesFibre:
								DropItemFromLeaves((ushort)BlockId.KapokLeaves, (ushort)Items.KapokFibre, TextureKapokLeaves);
								//DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokFibre,1),mousePosRoundX, mousePosRoundY);
								//((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.KapokLeaces,new Vector2(mousePosRoundX, mousePosRoundY));
								//barEnergy+=0.02f;
								//if (barEnergy>32) barEnergy=32;
								return;
						}

						void DropFoodFromLeaves(ushort newLeavesId, ushort itemId, Texture2D leavesTexture) {
							DropItemToPos(new ItemNonInvFood(itemId, 1, GameMethods.FoodMaxDescay(itemId)), mousePosRoundX, mousePosRoundY);

							LeavesBlock leaves=(LeavesBlock)chunk.TopBlocks[y];
							leaves.Id=newLeavesId;
							leaves.Texture=leavesTexture;

							barEnergy+=0.02f;
							if (barEnergy>32) barEnergy=32;
						}
						void DropItemFromLeaves(ushort newLeavesId, ushort itemId, Texture2D leavesTexture) {
							DropItemToPos(new ItemNonInvBasic(itemId), mousePosRoundX, mousePosRoundY);

							LeavesBlock leaves=(LeavesBlock)chunk.TopBlocks[y];
							leaves.Id=newLeavesId;
							leaves.Texture=leavesTexture;

							barEnergy+=0.02f;
							if (barEnergy>32) barEnergy=32;
						}
					}
				}


				foreach (Plant m in chunk.Plants) {
					if (m.Height==y) {
						if (!m.Growing) {
							switch (m.Id) {
								case (ushort)BlockId.Blueberry:
									DropItemToPos(new ItemNonInvFood((ushort)Items.Blueberries,1,GameMethods.FoodMaxCount((ushort)Items.Blueberries),0,GameMethods.FoodMaxDescay((ushort)Items.Blueberries)), mousePosRoundX, mousePosRoundY);
									m.Grow=125;
									m.Growing=true;
									m.Update();
									barEnergy+=0.02f;
									if (barEnergy>32) barEnergy=32;
									return;

								case (ushort)BlockId.Strawberry:
									DropItemToPos(new ItemNonInvFood((ushort)Items.Strawberry,1,GameMethods.FoodMaxCount((ushort)Items.Strawberry),0,GameMethods.FoodMaxDescay((ushort)Items.Strawberry)), mousePosRoundX, mousePosRoundY);
									m.Grow=125;
									m.Growing=true;
									m.Update();
									barEnergy+=0.02f;
									if (barEnergy>32) barEnergy=32;
									return;

								case (ushort)BlockId.Rashberry:
									DropItemToPos(new ItemNonInvFood((ushort)Items.Rashberry,1,GameMethods.FoodMaxCount((ushort)Items.Rashberry),0,GameMethods.FoodMaxDescay((ushort)Items.Rashberry)), mousePosRoundX, mousePosRoundY);
									m.Grow=125;
									m.Growing=true;
									m.Update();
									barEnergy+=0.02f;
									if (barEnergy>32) barEnergy=32;
									return;
							}
						}
					}
				}
				#endregion

				#region Drink Water
				if (chunk.IsTopBlocks[y]) {
					if (chunk.TopBlocks[y].Id==(ushort)BlockId.WaterBlock) {
						barWater--;
						if (barWater<0)barWater=0;
						return;
					}
				}
				#endregion

				#region Hoe
				if (chunk.IsSolidBlocks[y]) {
					if (InventoryNormal[boxSelected].Id==(ushort)Items.HoeBronze
					|| InventoryNormal[boxSelected].Id==(ushort)Items.HoeCopper
					|| InventoryNormal[boxSelected].Id==(ushort)Items.HoeIron
					|| InventoryNormal[boxSelected].Id==(ushort)Items.HoeStone) {

						if (chunk.SolidBlocks[y].Id == (ushort)BlockId.GrassBlockDesert
						|| chunk.SolidBlocks[y].Id == (ushort)BlockId.GrassBlockForest
						|| chunk.SolidBlocks[y].Id == (ushort)BlockId.GrassBlockHills
						|| chunk.SolidBlocks[y].Id == (ushort)BlockId.GrassBlockJungle
						|| chunk.SolidBlocks[y].Id == (ushort)BlockId.GrassBlockPlains) {
							chunk.SolidBlocks[y]=SolidBlockFromId((ushort)BlockId.Dirt, new Vector2(mousePosRoundX, mousePosRoundY));
							barEnergy+=0.02f;
							barWater+=0.02f;
							if (barEnergy>32) barEnergy=32;
							if (barWater>32) barWater=32;
							RemovePartTool();
							return;
						} else if (chunk.SolidBlocks[y].Id == (ushort)BlockId.GrassBlockClay) {
							 chunk.SolidBlocks[y]=SolidBlockFromId((ushort)BlockId.Clay, new Vector2(mousePosRoundX, mousePosRoundY));
							barEnergy+=0.02f;
							barWater+=0.02f;
							if (barEnergy>32) barEnergy=32;
							if (barWater>32) barWater=32;
							RemovePartTool();
							return;
						} else if (chunk.SolidBlocks[y].Id == (ushort)BlockId.GrassBlockCompost) {
							 chunk.SolidBlocks[y]=SolidBlockFromId((ushort)BlockId.Compost, new Vector2(mousePosRoundX, mousePosRoundY));
							barEnergy+=0.02f;
							barWater+=0.02f;
							if (barEnergy>32) barEnergy=32;
							if (barWater>32) barWater=32;
							RemovePartTool();
							return;
						}
					}
				}
                #endregion

                #region Add something on
				if (chunk.IsTopBlocks[y]) {
					switch (chunk.TopBlocks[y].Id) {
						case (ushort)BlockId.SpruceLeaves:
							switch (InventoryNormal[boxSelected].Id) {
								case (ushort)Items.AngelHair:
									ChangeLeaves((ushort)BlockId.AngelHair, TextureAngelHairWithSpruceLeaves);
									return;

								case (ushort)Items.ChristmasBallGray:
									ChangeLeaves((ushort)BlockId.ChristmasBall, TextureChristmasBallGrayWithLeaves);
									return;

								case (ushort)Items.ChristmasBallBlue:
									ChangeLeaves((ushort)BlockId.ChristmasBallBlue, TextureChristmasBallBlueWithLeaves);
									return;

								case (ushort)Items.ChristmasBallLightGreen:
									ChangeLeaves((ushort)BlockId.ChristmasBallLightGreen, TextureChristmasBallLightGreenWithLeaves);
									return;

								case (ushort)Items.ChristmasBallYellow:
									ChangeLeaves((ushort)BlockId.ChristmasBallYellow, TextureChristmasBallYellowWithLeaves);
									return;

								case (ushort)Items.ChristmasBallOrange:
									ChangeLeaves((ushort)BlockId.ChristmasBallOrange, TextureChristmasBallOrangeWithLeaves);
									return;

								case (ushort)Items.ChristmasBallRed:
									ChangeLeaves((ushort)BlockId.ChristmasBallRed, TextureChristmasBallRedWithLeaves);
									return;

								case (ushort)Items.ChristmasBallPink:
									ChangeLeaves((ushort)BlockId.ChristmasBallPink,TextureChristmasBallPinkWithLeaves);
									return;

								case (ushort)Items.ChristmasBallPurple:
									ChangeLeaves((ushort)BlockId.ChristmasBallPurple,TextureChristmasBallPurpleWithLeaves);
									return;
							}
							break;
					} 

					void ChangeLeaves(ushort newLeavesId, Texture2D newLeavesTexture) {
						LeavesBlock leaves=(LeavesBlock)chunk.TopBlocks[y];
						leaves.Id=newLeavesId;
						leaves.Texture=newLeavesTexture;

						barEnergy+=0.02f;
						if (barEnergy>32) barEnergy=32;
						InventoryRemoveSelectedItem();
					}
				 }
                #endregion

                #region Inventory
                if (InventoryNormal[boxSelected].Id==(ushort)Items.Mobile) {
					MobileON();
					inventory=InventoryType.Mobile;
					SetCaptionInventory();
					return;
				}

				if (FastMath.Distance(mousePosRoundX, mousePosRoundY, PlayerX, PlayerY) < 5*16) {
					if (chunk.IsTopBlocks[y]) {
						switch (chunk.TopBlocks[y].Id) {
							case (ushort)BlockId.Desk:
								inventory=InventoryType.Desk;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								SetInvCraftingBlocks();
								if (lastMashineType!=inventory) SetUpInvToNew();
								SetNeed();
								return;

						   case (ushort)BlockId.Shelf:
								inventory=InventoryType.Shelf;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();;
								if (lastMashineType!=inventory) SetUpInvToNew();
								return;

							case (ushort)BlockId.Barrel:
								inventory=InventoryType.Barrel;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();;
								if (lastMashineType!=inventory) SetUpInvToNew();
								return;

							case (ushort)BlockId.OxygenMachine:
								inventory=InventoryType.OxygenMachine;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								if (lastMashineType!=inventory) SetUpInvToNew();
								return;

							case (ushort)BlockId.BoxWooden:
								inventory=InventoryType.BoxWooden;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();;
								if (lastMashineType!=inventory) SetUpInvToNew();
								return;

							case (ushort)BlockId.BoxAdv:
								inventory=InventoryType.BoxAdv;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								if (lastMashineType!=inventory) SetUpInvToNew();
								return;

							case (ushort)BlockId.Radio:
								inventory=InventoryType.Radio;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								if (lastMashineType!=inventory) SetUpInvToNew();
								return;

							case (ushort)BlockId.FurnaceStone:

								inventory=InventoryType.FurnaceStone;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								SetInvBakeIngots();
								if (lastMashineType!=inventory) SetUpInvToNew();
								 SetNeed();
								return;

							case (ushort)BlockId.FurnaceElectric:
								inventory=InventoryType.FurnaceElectric;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								SetInvBakeIngots();
								if (lastMashineType!=inventory) SetUpInvToNew();
								 SetNeed();
								return;

						   case (ushort)BlockId.Macerator:
								inventory=InventoryType.Macerator;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								SetInvToDustDusts();
								if (lastMashineType!=inventory) SetUpInvToNew();
								 SetNeed();
								return;

							case (ushort)BlockId.Charger:
								inventory=InventoryType.Charger;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								if (lastMashineType!=inventory) SetUpInvToNew();
								return;


							case (ushort)BlockId.SewingMachine:
								inventory=InventoryType.SewingMachine;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								if (lastMashineType!=inventory) SetUpInvToNew();
								 SetNeed();
								return;

							case (ushort)BlockId.Miner:
								inventory=InventoryType.Miner;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								if (lastMashineType!=inventory) SetUpInvToNew();
								return;

							case (ushort)BlockId.Composter:
								inventory=InventoryType.Composter;
								SetCaptionInventory();
								selectedMashine=mousePosDiv16.Clone();
								if (lastMashineType!=inventory) SetUpInvToNew();
								return;
						}
					}

					for (int potencialRocketY=y; potencialRocketY>y-5; potencialRocketY--) {
						if (potencialRocketY<0) break;

						if (chunk.IsTopBlocks[potencialRocketY]) {
							if (chunk.TopBlocks[potencialRocketY].Id==(ushort)BlockId.Rocket) {
								inventory=InventoryType.Rocket;
								SetCaptionInventory();
								selectedMashine=new DInt{X=x,Y=potencialRocketY };
								if (lastMashineType!=inventory)SetUpInvToNew();
								return;
							}
						}
						if (terrain[x-1].IsTopBlocks[potencialRocketY]) {
							 if (terrain[x-1].TopBlocks[potencialRocketY].Id==(ushort)BlockId.Rocket) {
								inventory=InventoryType.Rocket;
								SetCaptionInventory();
								selectedMashine=new DInt{X=x-1, Y=potencialRocketY };
								if (lastMashineType!=inventory)SetUpInvToNew();
								return;
							}
						}
					}
				}
				#endregion

				#region Place block
				if (FastMath.DistanceInt(mousePosRoundX,mousePosRoundY,(int)PlayerX, (int)PlayerY)<DistanceBlockEdit) {
					ushort id =InventoryNormal[boxSelected].Id;
					if (id!=0) {

						if (!chunk.IsSolidBlocks[y])  {
							ushort blockId=GameMethods.SolidBlockFromItem(id);
							if (blockId!=(ushort)BlockId.None) {
								Block block = SolidBlockFromId(blockId, new Vector2(mousePosRoundX, mousePosRoundY));

								if (block!=null) {
									if (chunk.StartSomething>y)chunk.StartSomething=y;
									chunk.SolidBlocks[y]=block;
									chunk.IsSolidBlocks[y]=true;

									chunk.RefreshLightingAddSolid(x, y);

									InventoryRemoveSelectedItem();
									return;
								}
							}

							if (y!=0) {
								if (y+1<=125)
								if (chunk.IsSolidBlocks[y+1]) {
									if (chunk.SolidBlocks[y+1].Id==(ushort)BlockId.Dirt || chunk.SolidBlocks[y+1].Id==(ushort)BlockId.Compost) {
										if (!chunk.IsTopBlocks[y]) {

											bool isNotPlant=true;
											foreach (Plant p in chunk.Plants) {
												if (p.Height==y) {
													isNotPlant=false;
													break;
												}
											}
											if (isNotPlant) {
												switch (id) {
													case (ushort)Items.Seeds:
														switch (random.Int(10)) {
															default: chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.Dandelion,new Vector2(mousePosRoundX,mousePosRoundY)); break;
															case 1: chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.Orchid, new Vector2(mousePosRoundX, mousePosRoundY)); break;
															case 2: chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.Rose, new Vector2(mousePosRoundX, mousePosRoundY)); break;
															case 3: chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.Heather, new Vector2(mousePosRoundX, mousePosRoundY)); break;
															case 4: chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.Violet, new Vector2(mousePosRoundX, mousePosRoundY)); break;
															case 5: chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.GrassDesert, new Vector2(mousePosRoundX, mousePosRoundY)); break;
															case 6: chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.GrassForest, new Vector2(mousePosRoundX, mousePosRoundY)); break;
															case 7: chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.GrassHills, new Vector2(mousePosRoundX, mousePosRoundY)); break;
															case 8: chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.GrassJungle, new Vector2(mousePosRoundX, mousePosRoundY)); break;
															case 9: chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.GrassPlains, new Vector2(mousePosRoundX, mousePosRoundY)); break;
														}
														chunk.IsTopBlocks[y]=true;
														if (chunk.StartSomething>y)chunk.StartSomething=/*(byte)*/y;
														InventoryRemoveSelectedItem();
														return;

													case (ushort)Items.WheatSeeds:
														chunk.Plants.Add(GetPlantFromId((ushort)BlockId.Wheat, (byte)y,0, (short)x));
														RegisterPlant(x);
														if (chunk.StartSomething>y)chunk.StartSomething=/*(byte)*/y;
														InventoryRemoveSelectedItem();
														return;

													case (ushort)Items.FlaxSeeds:
														chunk.Plants.Add(GetPlantFromId((ushort)BlockId.Flax, (byte)y, 0, (short)x));
														RegisterPlant(x);
														if (chunk.StartSomething>y)chunk.StartSomething=/*(byte)*/y;
														InventoryRemoveSelectedItem();
														return;

													case (ushort)Items.Carrot:
														chunk.Plants.Add(GetPlantFromId((ushort)BlockId.Carrot, (byte)y, 0, (short)x));
														RegisterPlant(x);
														if (chunk.StartSomething>y)chunk.StartSomething=/*(byte)*/y;
														InventoryRemoveSelectedItem();
														return;

													case (ushort)Items.Onion:
														chunk.Plants.Add(GetPlantFromId((ushort)BlockId.Onion, (byte)y, 0, (short)x));
														RegisterPlant(x);
														if (chunk.StartSomething>y)chunk.StartSomething=/*(byte)*/y;
														InventoryRemoveSelectedItem();
														return;

													case (ushort)Items.Peas:
														chunk.Plants.Add(GetPlantFromId((ushort)BlockId.Peas, (byte)y, 0, (short)x));
														RegisterPlant(x);
														if (chunk.StartSomething>y)chunk.StartSomething=/*(byte)*/y;
														InventoryRemoveSelectedItem();
														return;

													case (ushort)Items.PlantRashberry:
														chunk.Plants.Add(GetPlantFromId((ushort)BlockId.Rashberry, (byte)y, 0, (short)x));
														RegisterPlant(x);
														if (chunk.StartSomething>y)chunk.StartSomething=/*(byte)*/y;
														InventoryRemoveSelectedItem();
														return;

													case (ushort)Items.PlantStrawberry:
														chunk.Plants.Add(GetPlantFromId((ushort)BlockId.Strawberry, (byte)y, 0, (short)x));
														RegisterPlant(x);
														if (chunk.StartSomething>y)chunk.StartSomething=/*(byte)*/y;
														InventoryRemoveSelectedItem();
														return;

													case (ushort)Items.PlantBlueberry:
														chunk.Plants.Add(GetPlantFromId((ushort)BlockId.Blueberry, (byte)y, 0, (short)x));
														RegisterPlant(x);
														if (chunk.StartSomething>y)chunk.StartSomething=/*(byte)*/y;
														InventoryRemoveSelectedItem();
														return;
												}
											}
										}
									}

									ushort mobId=GameMethods.MobFromItem(id);

									if (mobId!=(ushort)BlockId.None) {
										bool NotExists=true;
										foreach (Mob mob in chunk.Mobs) {
											if (mob.Height==y) {
												NotExists=false;
												break;
											}
										}

										if (NotExists) {
											switch (mobId) {
												case (ushort)BlockId.Fish:
													chunk.Mobs.Add(new Fish(/*mobId,*/ y, x,random.Bool(), fishTexture0, fishTexture1));
													break;

												case (ushort)BlockId.Chicken:
													chunk.Mobs.Add(new Chicken(y, x, random.Bool(), chickenWalkTexture, chickenEatTexture));
													break;

												case (ushort)BlockId.Rabbit:
													chunk.Mobs.Add(new Rabbit(y, x, random.Bool(), rabbitWalkTexture, rabbitEatTexture, rabbitJumpTexture));
													break;
														
												case (ushort)BlockId.MobParrot:
													chunk.Mobs.Add(new Parrot(y, x, random.Bool(), false, TextureParrotStill, TextureParrotFly));
													break;
											}
											InventoryRemoveSelectedItem();
										}
									}
								}
							}
						//	}
						}

						if (!chunk.IsBackground[y]) {
							ushort blockId=GameMethods.BackBlockFromItem(id);
							if (blockId!=(ushort)BlockId.None) {
								Block block=BackBlockFromId(blockId,new Vector2(mousePosRoundX, mousePosRoundY));

								if (block!=null) {
									if (chunk.StartSomething>y)chunk.StartSomething=/*(byte)*/y;

									//if (chunk.IsTopBlocks[y]) ((AirSolidBlock)chunk.SolidBlocks[y]).Back=block;
									//else chunk.SolidBlocks[y]=new AirSolidBlock{ Back=block };

									chunk.IsBackground[y]=true;
									chunk.Background[y]=block;

									InventoryRemoveSelectedItem();
									return;
								}
							}
						}

						if (!chunk.IsTopBlocks[y]) {
							ushort blockId=GameMethods.TopBlockFromItem(id);
							if (blockId!=(ushort)BlockId.None) {
								Block block=TopBlockFromId(blockId, new Vector2(mousePosRoundX, mousePosRoundY));

								if (block!=null) {
									if (GameMethods.IsDirtPlaceable(blockId)) {
										if (chunk.IsSolidBlocks[y+1]) {
											ushort downId=chunk.SolidBlocks[y+1].Id;
											if (GameMethods.IsBlockOnGrowing(downId)) {

												//if (chunk.IsTopBlocks[y]) ((AirSolidBlock)chunk.SolidBlocks[y]).Top=block;
												//else chunk.SolidBlocks[y]=new AirSolidBlock{ Top=block };

												chunk.TopBlocks[y]=block;
												chunk.IsTopBlocks[y]=true;
										

												if (chunk.StartSomething>y) chunk.StartSomething=/*(byte)*/y;
												
												chunk.RefreshLightingAddTop(y,blockId);

												InventoryRemoveSelectedItem();
												return;
											} else return;
										} else return; 
									} else {
										if (id==(ushort)Items.BucketForRubber) {
											if (!chunk.IsBackground[y])return;
											if (chunk.Background[y].Id!=(ushort)BlockId.RubberTreeWood) return;
										}

										if (id==(ushort)Items.ChristmasStar) { 
											if (chunk.IsTopBlocks[y+1]) {
												if (chunk.TopBlocks[y+1].Id==(ushort)BlockId.SpruceLeaves) {
													LeavesBlock leavesBlock=(LeavesBlock)block;
													(leavesBlock.tree=((LeavesBlock)chunk.TopBlocks[y+1]).tree).TitlesLeaves.Add(new UShortAndByte((ushort)x, (byte)y));
													leavesBlock.SetOrigin();
											
													chunk.TopBlocks[y]=block;
													chunk.IsTopBlocks[y]=true;
												//	chunk.RefreshLightingAddTop(y,(ushort)BlockId.SpruceLeaves);
													if (chunk.StartSomething>y) chunk.StartSomething=y;
												}
											}
											
											return;
										}

										chunk.TopBlocks[y]=block;
										chunk.IsTopBlocks[y]=true;
										if (chunk.StartSomething>y) chunk.StartSomething=y;
										terrain[x].RefreshLightingAddTop(y,id: blockId);
										if (blockId<(ushort)BlockId._MoreInLoad) {
											switch (blockId) {
												case (ushort)BlockId.FurnaceStone:
													((MashineBlockBasic)block).Inv=new ItemInv[InvMaxFurnaceStone]{
														itemBlank,
														itemBlank,
														itemBlank,
														itemBlank
													};
													FurnaceStone.Add(new ShortAndByte(x, y));
													break;

												case (ushort)BlockId.Charger:
													((MashineBlockBasic)block).Inv=new ItemInv[1]{ itemBlank };
													Chargers.Add(new ShortAndByte((short)x, (byte)y));
													RefreshAroundLabels(x, y);
													break;

												case (ushort)BlockId.OxygenMachine:
													((MashineBlockBasic)block).Inv=new ItemInv[1]{ itemBlank };
													OxygenMachines.Add(new ShortAndByte((short)x, (byte)y));
													break;

												case (ushort)BlockId.Miner:
													{
														MashineBlockBasic m=(MashineBlockBasic)block;
														m.Inv=new ItemInv[InvMaxMiner];
														for (int i = 0; i<12*2; i++) m.Inv[i]=itemBlank;
														Miners.Add(new ShortAndByte((short)x, (byte)y));
														RefreshAroundLabels(x, y);
													}
													break;

												case (ushort)BlockId.Composter:
													((ShelfBlock)block).Inv=new ItemInv[InvMaxComposter]{
														itemBlank, itemBlank, itemBlank,
														itemBlank, itemBlank, itemBlank,
														itemBlank, itemBlank, itemBlank
													};
													Composters.Add(new ShortAndByte((short)x, (byte)y));
													break;

												case (ushort)BlockId.BucketForRubber:
													if (chunk.IsBackground[y]) {
														if (chunk.Background[y].Id==(ushort)BlockId.RubberTreeWood) {
															bucketRubber.Add(new ShortAndByte((short)x, (byte)y));
														}else {
														ItemDrop(new ItemNonInvBasic((ushort)Items.BucketForRubber,1),x,y);
														chunk.IsBackground[y]=false;
														/*((AirSolidBlock)chunk.SolidBlocks[y]).Back=*/chunk.Background[y]=null;
													}
													} else {
														ItemDrop(new ItemNonInvBasic((ushort)Items.BucketForRubber,1),x,y);
														chunk.IsBackground[y]=false;
														/*((AirSolidBlock)chunk.SolidBlocks[y]).Back=*/chunk.Background[y]=null;
													}
													break;

												case (ushort)BlockId.Lamp:
													RefreshAroundLabels(x, y);
													break;

												case (ushort)BlockId.Radio:
													RefreshAroundLabels(x, y);
													break;

												case (ushort)BlockId.Label:
													SetIndexLabel(x,y);
													RefreshAroundLabels(x, y);
													break;

												case (ushort)BlockId.Shelf:
													((ShelfBlock)block).Inv=new ItemInv[InvMaxShelf]{
														itemBlank, itemBlank, itemBlank,
														itemBlank, itemBlank, itemBlank,
														itemBlank, itemBlank, itemBlank
													};
													break;

												case (ushort)BlockId.Barrel:
													((Barrel)block).Inv=new ItemInv[InvMaxBarrel] {
														itemBlank,
														itemBlank
													};
													break;

												case (ushort)BlockId.BoxWooden:
													{
														ItemInv[] inv=((BoxBlock)block).Inv=new ItemInv[InvMaxBoxWooden];
														for (int i=0; i<InvMaxBoxWooden; i++) inv[i]=itemBlank;
													}
													break;

												case (ushort)BlockId.BoxAdv:
													{
														ItemInv[] inv=((BoxBlock)block).Inv=new ItemInv[InvMaxBoxAdv];
														for (int i=0; i<InvMaxBoxAdv; i++)inv[i]=itemBlank;
													}
													break;

												case (ushort)BlockId.Flag:
													windable.Add(new ShortAndByte((short)x,(byte)y));
													break;

												case (ushort)BlockId.Windmill:
													windable.Add(new ShortAndByte((short)x,(byte)y));
													RefreshAroundLabels(x, y);
													break;
											}
										}
										InventoryRemoveSelectedItem();
										return;
									}
								}
							}
						}
					}
				}
				#endregion
			}
		}

		void Die(string why) {
			if (Global.WorldDifficulty==0) {
				diedInfo=why;
				timerStayDied=255;
				died=true;

				barHeart=0;
				barOxygen=0;
				barWater=0;
				barEnergy=0;
				barEat=0;
			}
		}

		void SetPlayerClothes() {
            for (int i=0; i<InventoryClothes.Length; i++) {
				if (InventoryClothes[i]==null) InventoryClothes[i]=itemBlank;
            }
            
			switch (InventoryClothes[InventoryClothesSlotCap].Id) {
				case (ushort)Items.Cap:
					ClothesHead=ClothesCap;
					ClothesHead.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotCap]).color;
					break;

				case (ushort)Items.Hat:
					ClothesHead=ClothesHad;
					break;

				case (ushort)Items.Crown:
					ClothesHead=ClothesCrown;
					break;

				case (ushort)Items.SpaceHelmet:
					ClothesHead=ClothesSpaceHelmet;
					ClothesHead.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotCap]).color;
					break;

				default:
					ClothesHead=null;
					break;
			}

			switch (InventoryClothes[InventoryClothesSlotCoat].Id) {
				case (ushort)Items.CoatArmy:
					ClothesChestTop=ClothesCoatArmy;
					ClothesChestTop.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotCoat]).color;
					break;

				case (ushort)Items.Coat:
					ClothesChestTop=ClothesCoat;
					ClothesChestTop.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotCoat]).color;
					break;

				case (ushort)Items.JacketDenim:
					ClothesChestTop=ClothesJacketDenim;
					ClothesChestTop.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotCoat]).color;
					break;

				case (ushort)Items.JacketFormal:
					ClothesChestTop=ClothesJacketFormal;
					ClothesChestTop.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotCoat]).color;
					break;

				case (ushort)Items.JacketShort:
					ClothesChestTop=ClothesJacketShort;
					ClothesChestTop.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotCoat]).color;
					break;

				case (ushort)Items.SpaceSuit:
					ClothesChestTop=ClothesSpaceSuit;
					break;

				default:
					ClothesChestTop=null;
					break;
			}

			switch (InventoryClothes[InventoryClothesSlotTShirt].Id) {
				case (ushort)Items.Dress:
					ClothesChest=ClothesDress;
					ClothesChest.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotTShirt]).color;
					break;

				case (ushort)Items.TShirt:
					ClothesChest=ClothesTShirt;
					ClothesChest.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotTShirt]).color;
					break;

				case (ushort)Items.Shirt:
					ClothesChest=ClothesShirt;
					ClothesChest.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotTShirt]).color;
					break;

				case (ushort)Items.Top:
					ClothesChest=ClothesTop;
					ClothesChest.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotTShirt]).color;
					break;

				default:
					ClothesChest=null;
					break;
			}

			switch (InventoryClothes[InventoryClothesSlotBra].Id) {
				case (ushort)Items.BikiniTop:
					ClothesUnderwearUp=ClothesBikiniTop;
					ClothesUnderwearUp.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotBra]).color;
					break;

				case (ushort)Items.Bra:
					ClothesUnderwearUp=ClothesBra;
					ClothesUnderwearUp.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotBra]).color;
					break;

				default:
					ClothesUnderwearUp=null;
					break;
			}

			switch (InventoryClothes[InventoryClothesSlotTrousers].Id) {
				case (ushort)Items.ArmyTrousers:
					ClothesLegs=ClothesArmyTrousers;
					ClothesLegs.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotTrousers]).color;
					break;

				case (ushort)Items.Skirt:
					ClothesLegs=ClothesSkirt;
					ClothesLegs.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotTrousers]).color;
					break;

				case (ushort)Items.Jeans:
					ClothesLegs=ClothesJeans;
					ClothesLegs.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotTrousers]).color;
					break;

				case (ushort)Items.Shorts:
					ClothesLegs=ClothesShorts;
					ClothesLegs.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotTrousers]).color;
					break;

				case (ushort)Items.SpaceTrousers:
					ClothesLegs=ClothesSpaceTrousers;
					ClothesLegs.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotTrousers]).color;
					break;

				default:
					ClothesLegs=null;
					break;
			}

			switch (InventoryClothes[InventoryClothesSlotUnderwear].Id) {
				case (ushort)Items.BikiniDown:
					ClothesUnderwearDown=ClothesBikiniDown;
					ClothesUnderwearDown.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotUnderwear]).color;
					break;

				case (ushort)Items.Underpants:
					ClothesUnderwearDown=ClothesUnderpants;
					ClothesUnderwearDown.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotUnderwear]).color;
					break;

				case (ushort)Items.BoxerShorts:
					ClothesUnderwearDown=ClothesBoxerShorts;
					ClothesUnderwearDown.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotUnderwear]).color;
					break;

				case (ushort)Items.Panties:
					ClothesUnderwearDown=ClothesPanties;
					ClothesUnderwearDown.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotUnderwear]).color;
					break;

				case (ushort)Items.Swimsuit:
					ClothesUnderwearDown=ClothesSwimsuit;
					ClothesUnderwearDown.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotUnderwear]).color;
					break;

				default:
					ClothesUnderwearDown=null;
					break;
			}
		
			switch (InventoryClothes[InventoryClothesSlotShoes].Id) {
				case (ushort)Items.FormalShoes:
					ClothesFeet=ClothesFormalShoes;
					ClothesFeet.Color=ColorWhite;
					break;

				case (ushort)Items.Pumps:
					ClothesFeet=ClothesPumps;
					ClothesFeet.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotShoes]).color;
					break;

				case (ushort)Items.Sneakers:
					ClothesFeet=ClothesSneakers;
					ClothesFeet.Color=((ItemInvBasicColoritzed32NonStackable)InventoryClothes[InventoryClothesSlotShoes]).color;
					break;

				case (ushort)Items.SpaceBoots:
					ClothesFeet=ClothesSpaceBoots;
					ClothesFeet.Color=ColorWhite;
					break;

				default:
					ClothesFeet=null;
					break;
			}
			
			if (InventoryClothes[InventoryClothesSlotBackpack].Id==(ushort)Items.Backpack) {
				maxInvCount=45+49;
			} else {
				if (maxInvCount>49) {
					for (int i=49; i<maxInvCount; i++) {
						if (InventoryNormal[i].Id!=0) {
							switch (InventoryNormal[i]) {
								case ItemInvBasicColoritzed32NonStackable n:
									{
										ItemNonInv remain =InventoryAdd(new ItemNonInvBasicColoritzedNonStackable(n.Id,n.color));
										if (remain!=null) DroppedItems.Add(
											new Item {
												item=remain,
												Texture=ItemIdToTexture(remain.Id),
												X=(int)PlayerX,
												Y=(int)PlayerY
											}
										);
									}
									break;

								case ItemInvBasic16 n:
									{
										ItemNonInv remain =InventoryAdd(new ItemNonInvBasic(n.Id,n.GetCount));
										if (remain!=null) DroppedItems.Add(
											new Item {
												item=remain,
												Texture=ItemIdToTexture(remain.Id),
												X=(int)PlayerX,
												Y=(int)PlayerY
											}
										);
									}
									break;

								case ItemInvBasic32 n:
									{
										ItemNonInv remain =InventoryAdd(new ItemNonInvBasic(n.Id,n.GetCount));
										if (remain!=null) DroppedItems.Add(
											new Item {
												item=remain,
												Texture=ItemIdToTexture(remain.Id),
												X=(int)PlayerX,
												Y=(int)PlayerY
											}
										);
									}
									break;

								case ItemInvFood16 n:
									{
										ItemNonInv remain =InventoryAdd(new ItemNonInvFood(n.Id,n.GetCount,n.CountMaximum,n.GetDescay,n.DescayMaximum));
										if (remain!=null) DroppedItems.Add(
											new Item {
												item=remain,
												Texture=ItemIdToTexture(remain.Id),
												X=(int)PlayerX,
												Y=(int)PlayerY
											}
										);
									}
									break;

								case ItemInvTool32 n:
									{
										ItemNonInv remain =InventoryAdd(new ItemNonInvTool(n.Id,n.GetCount,n.Maximum));
										if (remain!=null) DroppedItems.Add(
											new Item {
												item=remain,
												Texture=ItemIdToTexture(remain.Id),
												X=(int)PlayerX,
												Y=(int)PlayerY
											}
										);
									}
									break;
							}

							InventoryNormal[i]=itemBlank;
						}
					}
				}
				maxInvCount=49;
			}
		}

		#region Destruction
		void GetItemsFromBlock(int type, int X, int Y) {
			int X16=X*16, Y16=Y*16;

			switch (type) {
				case (ushort)BlockId.AngelHair:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.AngelHair, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;
					
				case (ushort)BlockId.ChristmasBall:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.ChristmasBallGray, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;

				case (ushort)BlockId.ChristmasBallYellow:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.ChristmasBallYellow, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;

				case (ushort)BlockId.ChristmasBallOrange:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.ChristmasBallOrange, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;

				case (ushort)BlockId.ChristmasBallRed:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.ChristmasBallRed, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;

				case (ushort)BlockId.ChristmasBallPink:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.ChristmasBallPink, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;

				case (ushort)BlockId.ChristmasBallPurple:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.ChristmasBallPurple, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;
					
				case (ushort)BlockId.ChristmasBallLightGreen:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.ChristmasBallLightGreen, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;

				case (ushort)BlockId.ChristmasBallTeal:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.ChristmasBallTeal, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;

				case (ushort)BlockId.EggDrop:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Egg, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;

				case (ushort)BlockId.Macerator:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Macerator, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					return;

				case (ushort)BlockId.Miner:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Miner, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					RemovefromMiners(X16, Y16);
					return;

				case (ushort)BlockId.Composter:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Composter, 1), X16, Y16);
					RefreshAroundLabels(X, Y);
					RemovefromComposters(X16, Y16);
					return;

				case (ushort)BlockId.FurnaceElectric:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.FurnaceElectric, 1), X16, Y16);
					RefreshAroundLabels(X16, Y16);
					return;

				case (ushort)BlockId.FurnaceStone:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.FurnaceStone, 1), X16, Y16);
					RemovefromFurnaceStone(X16, Y16);
					return;

				case (ushort)BlockId.Rocket:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Rocket, 1), X16, Y16);
					return;

				case (ushort)BlockId.Desk:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Desk, 1), X16, Y16);
					return;

				case (ushort)BlockId.Ladder:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Ladder, 1), X16, Y16);
					return;

				case (ushort)BlockId.Lamp:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Lamp, 1), X16, Y16);
					RefreshAroundLabels(X16, Y16);
					foreach (MashineBlockBasic m in lightsLamp) {
						if (m.Position.X==X16) {
							if (m.Position.Y==Y16) {
								lightsLamp.Remove(m);
								return;
							}
						}
					}
					return;

				case (ushort)BlockId.Windmill:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WindMill,1), X16, Y16);
					RefreshAroundLabels(X16, Y16);
					return;

				case (ushort)BlockId.Flag:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Flag, 1), X16, Y16);
					return;

				case (ushort)BlockId.Label:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Label, 1), X16, Y16);
					RefreshAroundLabels(X16, Y16);
					return;

				case (ushort)BlockId.AppleLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.AppleSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.AppleLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick, 1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 4:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave, 1), X16, Y16);
									return;

								case 5:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.AppleSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.EucalyptusLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.EucalyptusSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.EucalyptusLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick, 1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
									return;

								case 4:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave, 1), X16, Y16);
									return;

								case 5:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.EucalyptusSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.AcaciaLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.AcaciaSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.AcaciaLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick, 1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
									return;

								case 4:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave, 1), X16, Y16);
									return;

								case 5:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.AcaciaSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.WillowLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.WillowSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.WillowLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 4:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 5:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.WillowSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.OliveLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OliveSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OliveLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 4:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 5:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OliveSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.RubberTreeLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.RubberTreeSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.RubberTreeLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 4:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 5:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.RubberTreeSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.KapokLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 4:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 5:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.KapokLeacesFlowering:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokLeacesFlowering, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokLeacesFlowering, 1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 4:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokLeacesFlowering, 1), X16, Y16);
									return;

								case 5:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.KapokLeacesFibre:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);

						DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokFibre, 1), X16, Y16); 
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokLeavesFibre, 1), X16, Y16);
						else {
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16); 
							DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokFibre, 1), X16, Y16); 
						}
					} else {
						DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokFibre, 1), X16, Y16); 

						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick, 1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
									return;
									
								case 4:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave, 1), X16, Y16);
									return;

								case 5:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.OliveLeavesWithOlives:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OliveSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OliveLeaves, 1), X16, Y16);
						else {
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Olive, 1), X16, Y16);
						}
					} else {
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Olive, 1), X16, Y16);

						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Olive, 1), X16, Y16);
									return;

								case 4:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Olive, 1), X16, Y16);
									return;

								case 5:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OliveSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.LemonLeavesWithLemons:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.AcaciaSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);

						 DropItemToPos(new ItemNonInvBasic((ushort)Items.Lemon, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.LemonLeavesWithLemons, 1), X16, Y16);
						else {
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16); 
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Lemon, 1), X16, Y16);
						}
					} else {
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Lemon, 1), X16, Y16);

						if (random.Bool_20Percent()) {
							switch (random.Int(5)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.LemonSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.LindenLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.LindenSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.LindenLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.LindenSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.OakLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OakSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OakLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(5)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OakSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.OrangeLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OrangeSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OrangeLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Orange, 1), X16, Y16);

						if (random.Bool_20Percent()) {
							switch (random.Int(5)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OrangeSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.SpruceLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SpruceSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SpruceLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick, 1), X16, Y16);
					} else {
						if (random.Bool()) {
							if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
							else if (random.Bool_20Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SpruceSapling, 1), X16, Y16);
						}
					}
					return;

				case (ushort)BlockId.PlumLeavesWithPlums:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.PlumSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);

						DropItemToPos(new ItemNonInvBasic((ushort)Items.Plum, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.PlumLeavesWithPlums, 1), X16, Y16);
						else {
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Plum, 1), X16, Y16);
						}
					} else {
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Plum, 1), X16, Y16);

						if (random.Bool_20Percent()) {
							switch (random.Int(5)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick, 1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.PlumSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.PlumLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.PlumSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.PlumLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(5)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick, 1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.PlumSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.PineLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.PineSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.PineLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(5)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.PineSapling,1),X16, Y16);
									else DropItemToPos(new ItemNonInvBasic((ushort)Items.Banana, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.OrangeLeavesWithOranges:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OrangeSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);

						DropItemToPos(new ItemNonInvBasic((ushort)Items.Orange, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OrangeLeavesWithOranges, 1), X16, Y16);
						else {
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Orange, 1), X16, Y16);
						}
					} else {
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Orange, 1), X16, Y16);

						if (random.Bool_20Percent()) {
							switch (random.Int(6)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.OrangeSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.AppleLeavesWithApples:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.AppleSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);

						DropItemToPos(new ItemNonInvBasic((ushort)Items.Apple, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.AppleLeavesWithApples, 1), X16, Y16);
						else {
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16); 
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Apple, 1), X16, Y16);
						}
					} else {
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Apple, 1), X16, Y16);

						if (random.Bool_20Percent()) {
							switch (random.Int(5)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.AppleSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.CherryLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CherrySapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CherryLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(5)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.CherrySapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.CherryLeavesWithCherries:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CherrySapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);

						DropItemToPos(new ItemNonInvBasic((ushort)Items.Cherry, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CherryLeavesWithCherries, 1), X16, Y16);
						else {
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16); 
							DropItemToPos(new ItemNonInvBasic((ushort)Items.Cherry, 1), X16, Y16);
						}
					} else {
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Cherry, 1), X16, Y16);

						if (random.Bool_20Percent()) {
							switch (random.Int(5)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.CherrySapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.LemonLeaves:
					if (GameMethods.IsSelectedKnife(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.LemonSapling, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else if (GameMethods.IsSelectedShears(InventoryNormal[boxSelected].Id)) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.LemonLeaves, 1), X16, Y16);
						else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks, 1), X16, Y16);
					} else {
						if (random.Bool_20Percent()) {
							switch (random.Int(5)) {
								case 1:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
									return;

								case 2:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick, 1), X16, Y16);
									return;

								case 3:
									DropItemToPos(new ItemNonInvBasic((ushort)Items.Leave,1), X16, Y16);
									return;

								case 4:
									if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.LemonSapling, 1), X16, Y16);
									return;
							}
						}
					}
					return;

				case (ushort)BlockId.Violet:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantViolet, 1), X16, Y16);
					return;

				case (ushort)BlockId.Dandelion:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dandelion, 1), X16, Y16);
					return;

				case (ushort)BlockId.Heather:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Heater, 1), X16, Y16);
					return;

				case (ushort)BlockId.Alore:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Alore, 1), X16, Y16);
					return;

				case (ushort)BlockId.CactusBig:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.CactusBig, 1), X16, Y16);
					return;

				case (ushort)BlockId.CactusSmall:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.CactusSmall, 1), X16, Y16);
					return;

				case (ushort)BlockId.AppleSapling:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.AppleSapling, 1), X16, Y16);
					return;

				case (ushort)BlockId.CherrySapling:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.CherrySapling, 1), X16, Y16);
					return;

				case (ushort)BlockId.LemonSapling:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.LemonSapling, 1), X16, Y16);
					return;

				case (ushort)BlockId.LindenSapling:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.LindenSapling, 1), X16, Y16);
					return;

				case (ushort)BlockId.OakSapling:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.OakSapling, 1), X16, Y16);
					return;

				case (ushort)BlockId.OrangeSapling:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.OrangeSapling, 1), X16, Y16);
					return;

				case (ushort)BlockId.PineSapling:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.PineSapling, 1), X16, Y16);
					return;

				case (ushort)BlockId.PlumSapling:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.PlumSapling, 1), X16, Y16);
					return;

				case (ushort)BlockId.SpruceSapling:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.SpruceSapling, 1), X16, Y16);
					return;

				case (ushort)BlockId.GrassDesert:
					if (random.Int(6)==1)DropItemToPos(new ItemNonInvBasic((ushort)Items.Seeds, 1), X16, Y16);
					else if (random.Bool_33_333Percent()/* Int(3)==1*/)DropItemToPos(new ItemNonInvBasic((ushort)Items.Hay,1), X16, Y16);
					return;

				case (ushort)BlockId.GrassForest:
					if (random.Bool_20Percent())DropItemToPos(new ItemNonInvBasic((ushort)Items.Seeds, 1), X16, Y16);
					else if (random.Bool_20Percent())DropItemToPos(new ItemNonInvBasic((ushort)Items.Hay,1), X16, Y16);
					else if (random.Bool_10Percent()/* Int(10)==1*/)DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds, 1), X16, Y16);
					return;

				case (ushort)BlockId.GrassHills:
					if (random.Int(7)==1)DropItemToPos(new ItemNonInvBasic((ushort)Items.Seeds, 1), X16, Y16);
					else if (random.Bool_20Percent() /*Int(5)==1*/)DropItemToPos(new ItemNonInvBasic((ushort)Items.Hay,1), X16, Y16);
					else if (random.Bool_10Percent() /*Int(10)==1*/)DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds, 1), X16, Y16);
					return;

				case (ushort)BlockId.GrassJungle:
					if (random.Bool_20Percent())DropItemToPos(new ItemNonInvBasic((ushort)Items.Seeds, 1), X16, Y16);
					else if (random.Bool_20Percent()/* Int(5)==1*/)DropItemToPos(new ItemNonInvBasic((ushort)Items.Hay,1), X16, Y16);
					else if (random.Bool_5_555Percent() /*Int(20)==1*/)DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds, 1), X16, Y16);
					return;

				case (ushort)BlockId.GrassPlains:
					if (random.Bool_20Percent())DropItemToPos(new ItemNonInvBasic((ushort)Items.Seeds, 1), X16, Y16);
					else if (random.Bool_33_333Percent() /*Int(3)==1*/)DropItemToPos(new ItemNonInvBasic((ushort)Items.Hay,1), X16, Y16);
					else if (random.Bool_10Percent() /*Int(10)==1*/)DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds, 1), X16, Y16);
					return;



				case (ushort)BlockId.Glass:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Glass, 1), X16, Y16);
					return;
					
				case (ushort)BlockId.ChristmasStar:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.ChristmasStar, 1), X16, Y16);
					return;

				case (ushort)BlockId.Orchid:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantOrchid, 1), X16, Y16);
					return;

				case (ushort)BlockId.Radio:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Radio, 1), X16, Y16);
					RefreshAroundLabels(X16, Y16);
					return;

				case (ushort)BlockId.Rose:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantRose, 1), X16, Y16);
					return;

				case (ushort)BlockId.Toadstool:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Toadstool, 1), X16, Y16);
					return;

				case (ushort)BlockId.Boletus:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Boletus, 1), X16, Y16);
					return;

				case (ushort)BlockId.BranchALittle1:
					if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
					else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
					return;

				case (ushort)BlockId.BranchALittle2:
					if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick,1), X16, Y16);
					else DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
					return;

				case (ushort)BlockId.BranchFull:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Sticks,1), X16, Y16);
					return;

				case (ushort)BlockId.BranchWithout:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Stick, 1), X16, Y16);
					return;

				case (ushort)BlockId.Champignon:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Champignon, 1), X16, Y16);
					return;

				case (ushort)BlockId.DoorOpen:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Door, 1), X16, Y16);
					return;

				case (ushort)BlockId.Charger:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Charger, 1), X16, Y16);
					RefreshAroundLabels(X16, Y16);
					RemovefromChargers(X16, Y16);
					return;

				case (ushort)BlockId.OxygenMachine:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.OxygenMachine, 1), X16, Y16);
				    RemovefromOxygenMachines(X16, Y16);
					return;

				case (ushort)BlockId.SolarPanel:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.SolarPanel, 1), X16, Y16);
					RefreshAroundLabels(X16, Y16);
					return;

				case (ushort)BlockId.Watermill:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WaterMill, 1), X16, Y16);
					RefreshAroundLabels(X16, Y16);
					return;

			case (ushort)BlockId.Rocks:
					AchievementStoneAge=true;
				switch (random.Int(100)) {
					case 0: DropItemToPos(new ItemNonInvBasic((ushort)Items.Ruby, 1), X16, Y16); return;
					case 1: DropItemToPos(new ItemNonInvBasic((ushort)Items.Smaragd, 1), X16, Y16); return;
					case 2: DropItemToPos(new ItemNonInvBasic((ushort)Items.Saphirite, 1), X16, Y16); return;
					case 3: DropItemToPos(new ItemNonInvBasic((ushort)Items.Diamond, 1), X16, Y16); return;
					case 4: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16); return;
					case 5: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16); return;
					case 6: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16); return;
					case 7: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16); return;
					case 8: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16); return;
					case 9: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16); return;
					case 10: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16); return;
					case 11: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16); return;
					case 12: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16); return;
					case 13: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16); return;
					case 14: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16); return;
					case 15: DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalWood, 1), X16, Y16); return;
					case 16: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16); return;
					case 17: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16); return;
					case 18: DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16); return;
					case 19: DropItemToPos(new ItemNonInvBasic((ushort)Items.StoneHead,1), X16, Y16); return;
					case 20: DropItemToPos(new ItemNonInvBasic((ushort)Items.StoneHead,1), X16, Y16); return;
					case 21: DropItemToPos(new ItemNonInvBasic((ushort)Items.StoneHead,1), X16, Y16); return;
					case 22: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 23: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 24: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 25: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 26: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 27: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 28: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 29: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 30: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 31: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 32: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 33: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 34: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 35: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 36: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 37: DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16); return;
					case 38: DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16); return;
					case 39: DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16); return;
					case 40: DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16); return;
					case 41: DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16); return;
					case 42: DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16); return;
					case 43: DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16); return;
					case 44: DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16); return;
					case 45: DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16); return;
					case 46: DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16); return;
					case 47: DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16); return;
					case 48: DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16); return;
					default: DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16); return;
				}

				case (ushort)BlockId.Compost:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Compost, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt, new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.Snow:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Snow, 1), X16, Y16);
					return;

				case (ushort)BlockId.Roof1:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Roof1, 1), X16, Y16);
					return;

				case (ushort)BlockId.Roof2:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Roof2, 1), X16, Y16);
					return;

				case (ushort)BlockId.DoorClose:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Door, 1), X16, Y16);
					return;

				case (ushort)BlockId.StoneBasalt:
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					else if (random.Bool_2Percent() /*Int(50)==1*/) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalDust, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Smaragd, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Ruby, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Saphirite, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Diamond, 1), X16, Y16);
					}
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackBasalt, new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.StoneDiorit:
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					else if (random.Bool_2Percent() /*Int(50)==1*/) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalDust, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Smaragd, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Ruby, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Saphirite, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Diamond, 1), X16, Y16);
					}
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackDiorit,new Vector2(X16,Y16));
					}
					return;

				case (ushort)BlockId.StoneDolomite:
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					else if (random.Bool_2Percent() /*Int(50)==1*/) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalDust, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Smaragd, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Ruby, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Saphirite, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Diamond, 1), X16, Y16);
					}
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackDolomite,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.StoneGabbro:
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					else if (random.Bool_2Percent() /*Int(50)==1*/) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalDust, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Smaragd, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Ruby, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Saphirite, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Diamond, 1), X16, Y16);
					}
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackGabbro,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.StoneGneiss:
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					else if (random.Bool_2Percent() /*Int(50)==1*/) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalDust, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Smaragd, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Ruby, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Saphirite, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Diamond, 1), X16, Y16);
					}
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=new NormalBlock(backgroundGneissTexture, (ushort)BlockId.BackGneiss, new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.StoneLimestone:
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					else if (random.Bool_2Percent() /*Int(50)==1*/) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalDust, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Smaragd, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Ruby, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Saphirite, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Diamond, 1), X16, Y16);
					}
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackLimestone,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.StoneRhyolite:
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					else if (random.Bool_2Percent() /*Int(50)==1*/) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalDust, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Smaragd, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Ruby, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Saphirite, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Diamond, 1), X16, Y16);
					}
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackRhyolite,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.StoneSandstone:
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					else if (random.Bool_2Percent() /*Int(50)==1*/) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalDust, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Smaragd, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Ruby, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Saphirite, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Diamond, 1), X16, Y16);
					}
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackSandstone,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.StoneSchist:
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					else if (random.Bool_2Percent() /*Int(50)==1*/) {
						if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalDust, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Smaragd, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Ruby, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Saphirite, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16);
						else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Diamond, 1), X16, Y16);
					}
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackSchist,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.OreCoal:
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCoal,1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalDust, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CoalWood, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackCoal,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.OreAluminium:
					if (random.Bool_75Percent() /*Int4()!=1*/) DropItemToPos(new ItemNonInvBasic((ushort)Items.Aluminium, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackAluminium,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.OreCopper:
					if (random.Bool_75Percent() /*Int4()!=1*/) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemCopper, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.CopperDust, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackCopper,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.OreGold:
					if (random.Bool_75Percent()/* Int4()!=1*/) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemGold, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.GoldDust, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackGold,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.OreIron:
					if (random.Bool_75Percent() /*Int4()!=1*/) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemIron, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.IronDust, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackIron,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.OreSilver:
					if (random.Bool_75Percent() /*Int4()!=1*/) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemSilver, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SilverDust, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Silicium, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackSilver,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.OreTin:
					if (random.Bool_75Percent() /*Int4()!=1*/) DropItemToPos(new ItemNonInvBasic((ushort)Items.ItemTin, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.TinDust, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackTin,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.OreSaltpeter:
					if (random.Bool_75Percent() /*Int4()!=1*/) DropItemToPos(new ItemNonInvBasic((ushort)Items.Saltpeter, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackSaltpeter,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.OreSulfur:
					if (random.Bool_75Percent() /*Int4()!=1*/) DropItemToPos(new ItemNonInvBasic((ushort)Items.SulfurDust, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackSulfur,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.Cobblestone:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.MediumStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.SmallStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.BigStone, 1), X16, Y16);
					else if (random.Bool()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackCobblestone,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.Gravel:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Gravel, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackGravel,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.Sand:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Sand, 1), X16, Y16);
					DestroySandUp(destroyBlockX,destroyBlockY-1);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackSand,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.Dirt:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.GrassBlockDesert:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					{
						Terrain chunk=terrain[X];
						chunk.IsBackground[Y]=true;
						chunk.Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					}
					return;

				case (ushort)BlockId.GrassBlockForest:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.GrassBlockHills:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;
					
				case (ushort)BlockId.GrassBlockSnowPlains:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.GrassBlockSnowDesert:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.GrassBlockSnowJungle:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.GrassBlockSnowHills:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.GrassBlockSnowForest:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.GrassBlockSnowClay:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.GrassBlockSnowCompost:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.GrassBlockJungle:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.GrassBlockCompost:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Compost, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.GrassBlockPlains:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Dirt, 1), X16, Y16);
					DestroyGrassUp(destroyBlockX,destroyBlockY-1);
					terrain[X].IsBackground[Y]=true;
					terrain[X].Background[Y]=BackBlockFromId((ushort)BlockId.BackDirt,new Vector2(X16, Y16));
					return;

				case (ushort)BlockId.Planks:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Planks, 1), X16, Y16);
					return;

				case (ushort)BlockId.Bricks:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Bricks, 1), X16, Y16);
					return;

				case (ushort)BlockId.AdvancedSpacePart1:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.AdvancedSpacePart1, 1), X16, Y16);
					return;

				case (ushort)BlockId.AdvancedSpacePart2:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.AdvancedSpacePart2, 1), X16, Y16);
					return;

				case (ushort)BlockId.AdvancedSpacePart3:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.AdvancedSpacePart3, 1), X16, Y16);
					return;

				case (ushort)BlockId.AdvancedSpacePart4:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.AdvancedSpacePart4, 1), X16, Y16);
					return;

				case (ushort)BlockId.Clay:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Clay, 1), X16, Y16);
					return;

				case (ushort)BlockId.GrassBlockClay:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Clay, 1), X16, Y16);
					return;

				case (ushort)BlockId.AppleWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WoodApple, 1), X16, Y16);
					return;

				case (ushort)BlockId.CherryWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WoodCherry, 1), X16, Y16);
					return;

				case (ushort)BlockId.LemonWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WoodLemon, 1), X16, Y16);
					return;

				case (ushort)BlockId.LindenWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WoodLinden, 1), X16, Y16);
					return;

				case (ushort)BlockId.OakWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WoodOak, 1), X16, Y16);
					return;

				case (ushort)BlockId.OrangeWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WoodOrange, 1), X16, Y16);
					return;

				case (ushort)BlockId.PineWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WoodPine, 1), X16, Y16);
					return;

				case (ushort)BlockId.PlumWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WoodPlum, 1), X16, Y16);
					return;

				case (ushort)BlockId.SpruceWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WoodSpruce, 1), X16, Y16);
					return;

				case (ushort)BlockId.MangroveWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.MangroveWood, 1), X16, Y16);
					return;

				case (ushort)BlockId.WillowWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.WillowWood, 1), X16, Y16);
					return;

				case (ushort)BlockId.OliveWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.OliveWood, 1), X16, Y16);
					return;

				case (ushort)BlockId.RubberTreeWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.RubberTreeWood, 1), X16, Y16);
					return;

				case (ushort)BlockId.KapokWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.KapokWood, 1), X16, Y16);
					return;

				case (ushort)BlockId.EucalyptusWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.EucalyptusWood, 1), X16, Y16);
					return;

				case (ushort)BlockId.AcaciaWood:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.AcaciaWood, 1), X16, Y16);
					return;
			}
		}

		float GetBackBlockDestroingSpeed(ushort type) {
			switch (type) {
				case (ushort)BlockId.AdvancedSpaceBack: return 400*DestroyPickaxe();

				case (ushort)BlockId.AppleWood: return 300*DestroyAxe();
				case (ushort)BlockId.CherryWood: return 300*DestroyAxe();
				case (ushort)BlockId.LemonWood: return 300*DestroyAxe();
				case (ushort)BlockId.LindenWood: return 320*DestroyAxe();
				case (ushort)BlockId.OakWood: return 320*DestroyAxe();
				case (ushort)BlockId.OrangeWood: return 300*DestroyAxe();
				case (ushort)BlockId.PineWood: return 300*DestroyAxe();
				case (ushort)BlockId.PlumWood: return 300*DestroyAxe();
				case (ushort)BlockId.SpruceWood: return 280*DestroyAxe();

				case (ushort)BlockId.KapokWood: return 280*DestroyAxe();

				case (ushort)BlockId.OliveWood: return 280*DestroyAxe();

				case (ushort)BlockId.MangroveWood: return 280*DestroyAxe();
				case (ushort)BlockId.WillowWood: return 280*DestroyAxe();
				case (ushort)BlockId.RubberTreeWood: return 280*DestroyAxe();
				case (ushort)BlockId.EucalyptusWood: return 280*DestroyAxe();
				case (ushort)BlockId.AcaciaWood: return 280*DestroyAxe();


				case (ushort)BlockId.BackCobblestone: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackGravel: return 300*DestroyShovel();
				case (ushort)BlockId.BackDirt: return 300*DestroyShovel();
				case (ushort)BlockId.BackRedSand: return 300*DestroyShovel();
				case (ushort)BlockId.BackRegolite: return 300*DestroyShovel();
				case (ushort)BlockId.BackSand: return 300*DestroyShovel();

				case (ushort)BlockId.BackCoal: return 290*DestroyPickaxe();
				case (ushort)BlockId.BackCopper: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackTin: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackIron: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackAluminium: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackSilver: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackGold: return 300*DestroyPickaxe();

				case (ushort)BlockId.BackSulfur: return 250*DestroyPickaxe();
				case (ushort)BlockId.BackSaltpeter: return 250*DestroyPickaxe();

				case (ushort)BlockId.BackAnorthosite: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackBasalt: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackClay: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackDiorit: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackDolomite: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackFlint: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackGabbro: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackGneiss: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackLimestone: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackMudstone: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackRhyolite: return 300*DestroyPickaxe();
				case (ushort)BlockId.BackSandstone: return 300*DestroyPickaxe();
			}

			return 0;
		}

		float GetSolidBlockDestroingSpeed(ushort type) {
			switch (type) {
				case (ushort)BlockId.Windmill: return 45;
				case (ushort)BlockId.FurnaceStone: return 45;
				case (ushort)BlockId.FurnaceElectric: return 45;
				case (ushort)BlockId.Macerator: return 45;
				case (ushort)BlockId.Miner: return 45;
				case (ushort)BlockId.SolarPanel: return 45;

				case (ushort)BlockId.Clay: return 110*DestroyShovel();
				case (ushort)BlockId.GrassBlockClay: return 120*DestroyShovel();
				case (ushort)BlockId.GrassBlockSnowPlains: return 250*DestroyShovel();
				case (ushort)BlockId.GrassBlockSnowDesert: return 250*DestroyShovel();
				case (ushort)BlockId.GrassBlockSnowForest: return 250*DestroyShovel();
				case (ushort)BlockId.GrassBlockSnowHills: return 250*DestroyShovel();
				case (ushort)BlockId.GrassBlockSnowJungle: return 250*DestroyShovel();
				case (ushort)BlockId.GrassBlockSnowCompost: return 250*DestroyShovel();
				case (ushort)BlockId.GrassBlockSnowClay: return 250*DestroyShovel();

				case (ushort)BlockId.GrassBlockDesert: return 100*DestroyShovel();
				case (ushort)BlockId.GrassBlockForest: return 100*DestroyShovel();
				case (ushort)BlockId.GrassBlockHills: return 105*DestroyShovel();
				case (ushort)BlockId.GrassBlockJungle: return 105*DestroyShovel();
				case (ushort)BlockId.GrassBlockPlains: return 95*DestroyShovel();
				case (ushort)BlockId.GrassBlockCompost: return 100*DestroyShovel();
				case (ushort)BlockId.Dirt: return 90*DestroyShovel();
				case (ushort)BlockId.Gravel: return 120*DestroyShovel();

				case (ushort)BlockId.Sand: return 60*DestroyShovel();
				case (ushort)BlockId.Compost: return 70*DestroyShovel();
				case (ushort)BlockId.Cobblestone: return 280*DestroyPickaxe();

				case (ushort)BlockId.Roof1: return 120*DestroyPickaxe();
				case (ushort)BlockId.Roof2: return 120*DestroyPickaxe();
				case (ushort)BlockId.DoorClose: return 280*DestroyPickaxe();

				case (ushort)BlockId.StoneBasalt: return 320*DestroyPickaxe();
				case (ushort)BlockId.StoneDiorit: return 300*DestroyPickaxe();
				case (ushort)BlockId.StoneDolomite: return 280*DestroyPickaxe();
				case (ushort)BlockId.StoneGabbro: return 320*DestroyPickaxe();
				case (ushort)BlockId.StoneGneiss: return 320*DestroyPickaxe();
				case (ushort)BlockId.StoneLimestone: return 280*DestroyPickaxe();
				case (ushort)BlockId.StoneRhyolite: return 300*DestroyPickaxe();
				case (ushort)BlockId.StoneSandstone: return 260*DestroyPickaxe();
				case (ushort)BlockId.StoneSchist: return 300*DestroyPickaxe();

				case (ushort)BlockId.OreCoal: return 260*DestroyPickaxe();
				case (ushort)BlockId.OreAluminium: return 320*DestroyPickaxe();
				case (ushort)BlockId.OreCopper: return 320*DestroyPickaxe();
				case (ushort)BlockId.OreGold: return 300*DestroyPickaxe();
				case (ushort)BlockId.OreIron: return 320*DestroyPickaxe();

				case (ushort)BlockId.OreSilver: return 300*DestroyPickaxe();

				case (ushort)BlockId.OreTin: return 300*DestroyPickaxe();

				case (ushort)BlockId.OreSaltpeter: return 250*DestroyPickaxe();
				case (ushort)BlockId.OreSulfur: return 250*DestroyPickaxe();

				case (ushort)BlockId.Ice: return 120*DestroyAxe();

				case (ushort)BlockId.AdvancedSpaceBlock: return 100*DestroyPickaxe();
				case (ushort)BlockId.AdvancedSpaceFloor: return 100*DestroyPickaxe();
				case (ushort)BlockId.AdvancedSpaceWindow: return 100*DestroyPickaxe();

				case (ushort)BlockId.Planks: return 100*DestroyAxe();
				case (ushort)BlockId.Bricks: return 160*DestroyPickaxe();

				case (ushort)BlockId.AdvancedSpacePart1: return 90*DestroyPickaxe();
				case (ushort)BlockId.AdvancedSpacePart2: return 90*DestroyPickaxe();
				case (ushort)BlockId.AdvancedSpacePart3: return 90*DestroyPickaxe();
				case (ushort)BlockId.AdvancedSpacePart4: return 90*DestroyPickaxe();
			}

			return 0;
		}

		float GetTopBlockDestroingSpeed(ushort type) {
			switch (type) {
				case (ushort)BlockId.Desk: return 45;
				case (ushort)BlockId.Rocket: return 45;

				case (ushort)BlockId.EggDrop: return 20;

				case (ushort)BlockId.Ladder: return 90*DestroyAxe();
				case (ushort)BlockId.Lamp: return 45;

				case (ushort)BlockId.Watermill: return 45;
				case (ushort)BlockId.Flag: return 45;

				case (ushort)BlockId.Label: return 30;

				case (ushort)BlockId.Snow: return 100*DestroyShovel();

				case (ushort)BlockId.AppleLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.LemonLeavesWithLemons: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.LindenLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.OakLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.OrangeLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.SpruceLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.PlumLeavesWithPlums: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.PlumLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.PineLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.OrangeLeavesWithOranges: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.AppleLeavesWithApples: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.CherryLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.CherryLeavesWithCherries: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.LemonLeaves: return 15*DestroyKnife()*DestroyShears();

				case (ushort)BlockId.AcaciaLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.EucalyptusLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.KapokLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.KapokLeacesFibre: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.KapokLeacesFlowering: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.MangroveLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.OliveLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.OliveLeavesWithOlives: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.RubberTreeLeaves: return 15*DestroyKnife()*DestroyShears();
				case (ushort)BlockId.WillowLeaves: return 15*DestroyKnife()*DestroyShears();

				case (ushort)BlockId.Violet: return 30*DestroyKnife()*DestroyShears()*DestroyShovel();
				case (ushort)BlockId.Dandelion: return 30*DestroyKnife()*DestroyShears()*DestroyShovel();
				case (ushort)BlockId.Heather: return 30*DestroyKnife()*DestroyShears()*DestroyShovel();
				case (ushort)BlockId.Alore: return 30*DestroyKnife()*DestroyShears()*DestroyShovel();
				case (ushort)BlockId.CactusBig: return 60;
				case (ushort)BlockId.CactusSmall: return 60;

				case (ushort)BlockId.AppleSapling: return 30*DestroyKnife();
				case (ushort)BlockId.CherrySapling: return 30*DestroyKnife();
				case (ushort)BlockId.LemonSapling: return 30*DestroyKnife();
				case (ushort)BlockId.LindenSapling: return 30*DestroyKnife();
				case (ushort)BlockId.OakSapling: return 30*DestroyKnife();
				case (ushort)BlockId.OrangeSapling: return 30*DestroyKnife();
				case (ushort)BlockId.PineSapling: return 30*DestroyKnife();
				case (ushort)BlockId.PlumSapling: return 30*DestroyKnife();
				case (ushort)BlockId.SpruceSapling: return 30*DestroyKnife();

				case (ushort)BlockId.GrassDesert: return 30*DestroyKnife();
				case (ushort)BlockId.GrassForest: return 30*DestroyKnife();
				case (ushort)BlockId.GrassHills: return 30*DestroyKnife();
				case (ushort)BlockId.GrassJungle: return 30*DestroyKnife();
				case (ushort)BlockId.GrassPlains: return 30*DestroyKnife();

			   // case (ushort)BlockId.Liana: return 30*DestroyAxe();

				case (ushort)BlockId.Wheat: return 30*DestroyKnife();
				case (ushort)BlockId.Onion: return 30*DestroyShovel();
				case (ushort)BlockId.Flax: return 30*DestroyKnife();
				case (ushort)BlockId.Glass: return 30;
				case (ushort)BlockId.ChristmasStar: return 30;
				case (ushort)BlockId.Orchid: return 30*DestroyShovel();
				case (ushort)BlockId.Radio: return 45;
				case (ushort)BlockId.Rose: return 30*DestroyShovel();
				case (ushort)BlockId.Seaweed: return 30*DestroyKnife();
				case (ushort)BlockId.SugarCane: return 30*DestroyKnife();
				case (ushort)BlockId.Toadstool: return 30*DestroyKnife();
				case (ushort)BlockId.Strawberry: return 30*DestroyShovel();
				case (ushort)BlockId.Rashberry: return 30*DestroyShovel();
				case (ushort)BlockId.Blueberry: return 30*DestroyShovel();
				case (ushort)BlockId.Boletus: return 30*DestroyKnife();
				case (ushort)BlockId.SnowTop: return 45*DestroyShovel();
				case (ushort)BlockId.Roof1: return 90;
				case (ushort)BlockId.Coral: return 60*DestroyKnife();
				case (ushort)BlockId.BranchALittle1: return 30;
				case (ushort)BlockId.BranchALittle2: return 30;
				case (ushort)BlockId.BranchFull: return 30;
				case (ushort)BlockId.BranchWithout: return 30;
				case (ushort)BlockId.Champignon: return 30*DestroyKnife();
				case (ushort)BlockId.DoorOpen: return 45;
			}

			return 0;
		}

		float GetPlantDestroingSpeed(ushort type) {
			switch (type) {
				case (ushort)BlockId.Wheat: return 30;
				case (ushort)BlockId.Onion: return 30;
				case (ushort)BlockId.Carrot: return 30;
				case (ushort)BlockId.Peas: return 30;
				case (ushort)BlockId.Flax: return 30;

				case (ushort)BlockId.Strawberry: return 30;
				case (ushort)BlockId.Rashberry: return 30;
				case (ushort)BlockId.Blueberry: return 30;
			}

			return 0;
		}

		float GetMobDestroingSpeed(ushort type) {
			switch (type) {
				case (ushort)BlockId.Rabbit: return 30*DestroyKnife();
				case (ushort)BlockId.Chicken: return 30*DestroyKnife();
				case (ushort)BlockId.Fish: return 30*DestroyKnife();
				case (ushort)BlockId.MobParrot: return 30*DestroyKnife();
			}

			return 0;
		}

		float DestroyPickaxe() {
			switch (InventoryNormal[boxSelected].Id) {
				case (ushort)Items.PickaxeStone: return 0.4f;
				case (ushort)Items.PickaxeGold: return 0.5f;
				case (ushort)Items.PickaxeCopper: return 0.3f;
				case (ushort)Items.PickaxeBronze: return 0.25f;
				case (ushort)Items.PickaxeAluminium: return 0.45f;
				case (ushort)Items.PickaxeIron: return 0.2f;
				case (ushort)Items.PickaxeSteel: return 0.19f;

				case (ushort)Items.ElectricDrill: return 0.1f;
				case (ushort)Items.MediumStone: return 0.93f;
				case (ushort)Items.SmallStone: return 0.96f;
				case (ushort)Items.BigStone: return 0.90f;
				case (ushort)Items.PickaxeHeadIron: return 0.80f;
				case (ushort)Items.StoneHead: return 0.80f;
			}

			return 1;
		}

		float DestroyAxe() {
			switch (InventoryNormal[boxSelected].Id) {
				case (ushort)Items.AxeStone: return 0.4f;
				case (ushort)Items.AxeIron: return 0.2f;
				case (ushort)Items.AxeGold: return 0.5f;
				case (ushort)Items.AxeCopper: return 0.3f;
				case (ushort)Items.AxeBronze: return 0.25f;
				case (ushort)Items.AxeAluminium: return 0.35f;
				case (ushort)Items.AxeSteel: return 0.19f;

				case (ushort)Items.ElectricSaw: return 0.1f;
				case (ushort)Items.AxeHeadIron: return 0.87f;
				case (ushort)Items.SawCopper: return 0.4f;
				case (ushort)Items.SawBronze: return 0.15f;
				case (ushort)Items.SawIron: return 0.08f;
				case (ushort)Items.BigStone: return 0.90f;
				case (ushort)Items.StoneHead: return 0.80f;
				case (ushort)Items.MediumStone: return 0.93f;
				case (ushort)Items.SmallStone: return 0.96f;
			}

			return 1;
		}

		float DestroyKnife() {
			switch (InventoryNormal[boxSelected].Id) {
				case (ushort)Items.KnifeCopper: return 0.35f;
				case (ushort)Items.KnifeBronze: return 0.3f;
				case (ushort)Items.KnifeGold: return 0.5f;
				case (ushort)Items.KnifeIron: return 0.25f;
				case (ushort)Items.KnifeSteel: return 0.2f;
				case (ushort)Items.KnifeAluminium: return 0.3f;
			}
			return 1;
		}

		float DestroyShears() {
			switch (InventoryNormal[boxSelected].Id) {
				case (ushort)Items.ShearsCopper: return 0.35f;
				case (ushort)Items.ShearsBronze: return 0.3f;
				case (ushort)Items.ShearsGold: return 0.5f;
				case (ushort)Items.ShearsIron: return 0.25f;
				case (ushort)Items.ShearsSteel: return 0.2f;
				case (ushort)Items.ShearsAluminium: return 0.3f;
			}
			return 1;
		}

		float DestroyShovel() {
			switch (InventoryNormal[boxSelected].Id) {
				case (ushort)Items.ShovelStone: return 0.4f;
				case (ushort)Items.ShovelGold: return 0.3f;
				case (ushort)Items.ShovelCopper: return 0.25f;
				case (ushort)Items.ShovelBronze: return 0.25f;
				case (ushort)Items.ShovelIron: return 0.2f;

				case (ushort)Items.ShovelAluminium: return 0.19f;
				case (ushort)Items.ShovelSteel: return 0.2f;

				case (ushort)Items.ElectricDrill: return 0.1f;
				case (ushort)Items.ShovelHeadIron: return 0.87f;
				case (ushort)Items.StoneHead: return 0.80f;
				case (ushort)Items.MediumStone: return 0.86f;
				case (ushort)Items.SmallStone: return 0.88f;
				case (ushort)Items.BigStone: return 0.84f;
			}

			return 1;
		}

		void GetItemsFromPlant(int type, int x, int y, bool grow) {
			DInt pos =new DInt{X=x*16, Y=y*16 };
			if (grow) {
				 switch (type) {
					  case (ushort)BlockId.Wheat:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.WheatStraw,1), pos);
						DropItemToPos(new ItemNonInvBasic((ushort)Items.WheatSeeds,1), pos);
						if (random.Bool_12_5Percent())DropItemToPos(new ItemNonInvBasic((ushort)Items.WheatSeeds,1), pos);
						return;

					case (ushort)BlockId.Onion:
						if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.Onion,1), pos);
						if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.Onion,1), pos);
						if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.Onion,1), pos);
						return;

					case (ushort)BlockId.Carrot:
						if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.Carrot,1), pos);
						if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.Carrot,1), pos);
						if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.Carrot,1), pos);
						return;

					case (ushort)BlockId.Peas:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Peas,1), pos);
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Peas,1), pos);
						if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.Peas,1), pos);
						return;

					case (ushort)BlockId.Flax:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Flax,1), pos);
						DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds,1), pos);
						DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds,1), pos);
						if (random.Bool())DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds,1), pos);
						return;

					case (ushort)BlockId.Strawberry:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantStrawberry,1), pos);
						if (random.Bool_12_5Percent())DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantStrawberry,1), pos);
						return;

					case (ushort)BlockId.Rashberry:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantRashberry,1), pos);
						if (random.Bool_12_5Percent())DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantRashberry,1), pos);
						return;

					case (ushort)BlockId.Blueberry:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantBlueberry,1), pos);
						if (random.Bool_12_5Percent())DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantBlueberry,1), pos);
						return;
				}
			} else {
				switch (type) {
					case (ushort)BlockId.Wheat:
						if (random.Bool_12_5Percent())DropItemToPos(new ItemNonInvBasic((ushort)Items.WheatSeeds,1), pos);
						return;

					case (ushort)BlockId.Onion:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Onion,1), pos);
						return;

					case (ushort)BlockId.Carrot:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.Carrot,1), pos);
						return;

					case (ushort)BlockId.Peas:
						return;

					case (ushort)BlockId.Flax:
						if (random.Bool_12_5Percent())DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds,1), pos);
						return;

					case (ushort)BlockId.Strawberry:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantStrawberry,1), pos);
						return;

					case (ushort)BlockId.Rashberry:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantRashberry,1), pos);
						return;

					case (ushort)BlockId.Blueberry:
						DropItemToPos(new ItemNonInvBasic((ushort)Items.PlantBlueberry,1), pos);
						return;
				}
			}
		}

		void GetItemsFromMob(int type, int X, int Y) {
			int X16=X*16,Y16=Y*16;

			switch (type) {
				 case (ushort)BlockId.Chicken:
					if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.WheatStraw, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.WheatSeeds, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Seeds, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Hay, 1), X16, Y16);
					DropItemToPos(new ItemNonInvBasic((ushort)Items.RabbitMeat, 1), X16, Y16);
					return;

				case (ushort)BlockId.Rabbit:
					if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.WheatStraw, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.WheatSeeds, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Seeds, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Hay, 1), X16, Y16);
					DropItemToPos(new ItemNonInvBasic((ushort)Items.RabbitMeat, 1), X16, Y16);
					return;
					
				case (ushort)BlockId.MobParrot:
					if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.WheatStraw, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.WheatSeeds, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.FlaxSeeds, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Seeds, 1), X16, Y16);
					else if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.Hay, 1), X16, Y16);
					DropItemToPos(new ItemNonInvBasic((ushort)Items.RabbitMeat, 1), X16, Y16);
					return;

				case (ushort)BlockId.Fish:
					DropItemToPos(new ItemNonInvBasic((ushort)Items.AnimalFish, 1), X16, Y16);
					if (random.Bool_12_5Percent()) DropItemToPos(new ItemNonInvBasic((ushort)Items.AnimalFish, 1), X16, Y16);
					return;
			}
		}

		void Destroy(int x, int y) {
			float destrustionSlow;
			{
				float distance=FastMath.DistanceInt(mousePosRoundX, mousePosRoundY, PlayerX, PlayerY);

				if (distance>DistanceBlockEdit) destrustionSlow=-1;
				else if (distance<DistanceBlockEdit/2) {
					destrustionSlow=1;
				} else {
					destrustionSlow=(float)Math.Pow(1.05,distance-DistanceBlockEdit/2);
				}
			}

			if (destrustionSlow>0) {
				if (Global.WorldDifficulty==2) {
					if (terrain[x].IsSolidBlocks[y]) {
						destroingIndex=0;
						destroingBlockType=terrain[x].SolidBlocks[y].Id;
						destringMaxIndex=10;
						destroyBlockX=x;
						destroyBlockY=y;

						destroingBlockDepth=BlockType.Solid;
						destroing=true;
						return;
					}

					foreach (Plant p in terrain[x].Plants) {
						if (p.Position.Y/16==y) {
							destroingIndex=0;
							destroingBlockType=p.Id;
							destringMaxIndex=10;
							destroyBlockX=x;
							destroyBlockY=y;
							destroingBlockDepth=BlockType.Plant;
							destroing=true;
							return;
						}
					}

					foreach (Mob m in terrain[x].Mobs) {
						if (m.Height==y) {
							destroingIndex=0;
							destroingBlockType=m.Id;
							destringMaxIndex=10;
							destroyBlockX=x;
							destroyBlockY=y;
							destroingBlockDepth=BlockType.Mob;
							destroing=true;
							return;
						}
					}

					if (terrain[x].IsTopBlocks[y]) {
						destroingBlockType=terrain[x].TopBlocks[y].Id;
						if (GameMethods.CanDestroy(destroingBlockType)) {
							destroingIndex=0;
							destringMaxIndex=10;
							destroyBlockX=x;
							destroyBlockY=y;
							destroingBlockDepth=BlockType.Top;
							destroing=true;
							return;
						} else destroing=false;
					}

					if (terrain[x].IsBackground[y]) {
						destroingIndex=0;
						destroingBlockType=terrain[x].Background[y].Id;
						destringMaxIndex=10;

						destroyBlockX=x;
						destroyBlockY=y;
						destroingBlockDepth=BlockType.Back;
						destroing=true;
						return;
					}
				} else {
					if (terrain[x].IsSolidBlocks[y]) {
						destroingIndex=0;
						destroingBlockType=terrain[x].SolidBlocks[y].Id;
						destringMaxIndex=GetSolidBlockDestroingSpeed(destroingBlockType)*destrustionSlow;
						destroyBlockX=x;
						destroyBlockY=y;
						destroingBlockDepth=BlockType.Solid;
						destroing=true;
						return;
					}

					foreach (Plant p in terrain[x].Plants) {
						if (p.Height==y) {
							destroingIndex=0;
							destroingBlockType=p.Id;
							destringMaxIndex=GetPlantDestroingSpeed(destroingBlockType)*destrustionSlow;
							destroyBlockX=x;
							destroyBlockY=y;
							destroingBlockDepth=BlockType.Plant;
							destroing=true;
							return;
						}
					}

					foreach (Mob m in terrain[x].Mobs) {
						if (m.Height==y) {
							destroingIndex=0;
							destroingBlockType=m.Id;
							destringMaxIndex=GetMobDestroingSpeed(destroingBlockType)*destrustionSlow;
							destroyBlockX=x;
							destroyBlockY=y;
							destroingBlockDepth=BlockType.Mob;
							destroing=true;
							return;
						}
					}

					if (terrain[x].IsTopBlocks[y]) {
						destroingBlockType=terrain[x].TopBlocks[y].Id;
						if (GameMethods.CanDestroy(destroingBlockType)) {
							destroingIndex=0;
							destringMaxIndex=GetTopBlockDestroingSpeed(destroingBlockType)*destrustionSlow;
							destroyBlockX=x;
							destroyBlockY=y;
							destroingBlockDepth=BlockType.Top;
							destroing=true;
							return;
						}else destroing=false;
					}

					if (terrain[x].IsBackground[y]) {
						destroingIndex=0;
						destroingBlockType=terrain[x].Background[y].Id;
						destringMaxIndex=GetBackBlockDestroingSpeed(destroingBlockType)*destrustionSlow;

						destroyBlockX=x;
						destroyBlockY=y;
						destroingBlockDepth=BlockType.Back;
						destroing=true;
						return;
					}
				}
			}
		}

		void RemovePartTool() {
			if (InventoryNormal[boxSelected].Id!=0) {
				switch (InventoryNormal[boxSelected]) {
					case ItemInvTool16 it:
						if (it.GetCount==1) {
							ushort newId=GameMethods.ToolToBasic(InventoryNormal[boxSelected].Id);
							if (newId==InventoryNormal[boxSelected].Id) InventoryNormal[boxSelected]=itemBlank;
							else {
								if (GameMethods.IsItemInvTool16(newId)) {
									InventoryNormal[boxSelected]=new ItemInvTool16(ItemIdToTexture(newId),newId,1,GameMethods.ToolMax(newId), it.posTex.X, it.posTex.Y);
									return;
								}
								if (GameMethods.IsItemInvTool32(newId)) {
									InventoryNormal[boxSelected]=new ItemInvTool32(ItemIdToTexture(newId),newId,1,GameMethods.ToolMax(newId), it.posTex.X, it.posTex.Y);
									return;
								}
							}
						} else {
							it.SetCount=it.GetCount-1;
							return;
						}
						break;
				}
			}
		}
		#endregion

		#region Terrain
		unsafe void Save() {
			isDisposed=true;

			List<byte> bytes=new List<byte>();
			List<byte> tmpBytes=new List<byte>();

			List<byte> bytesLiveObjects = new List<byte> {
                (byte)LiveObjects.Length,
                (byte)(LiveObjects.Length >> 8),
                (byte)(LiveObjects.Length >> 16)
            };

			for (int pos=0; pos<terrain.Length; pos++) {
				Terrain chunk=terrain[pos];
				ushort solidBlockId= (ushort)BlockId.None,
					topBlockId  = (ushort)BlockId.None,
					backBlockId = (ushort)BlockId.None;

				SaveType lastType=SaveType.Unknown;
				int lastTypeCount=-1;
				bytes.Add((byte)chunk.LightPosFull);
			//	bytes.Add(chunk.Half ? (byte)1 : (byte)0);
				bytes.Add((byte)chunk.LightPosHalf);

				for (int y=0; y<125; y++) {
					if (chunk.IsSolidBlocks[y]) {

						// solid
						ushort newSolidBlockId=chunk.SolidBlocks[y].Id;

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

								#if DEBUG
								if (SolidBlockFromId(newSolidBlockId, Vector2Zero)==null) { 
									throw new Exception("Nějaký blok je zaregistrován jako statický, ale není jako statický definován");
								}
								#endif

								solidBlockId=newSolidBlockId;
								break;
						}
					} else {
						if (chunk.IsTopBlocks[y]) {
							if (chunk.IsBackground[y]) {

								// back and top
								ushort newBackBlockId=chunk.Background[y].Id,
									newTopBlockId=chunk.TopBlocks[y].Id;

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
											SaveMachineTop(chunk.TopBlocks[y]);
											lastTypeCount=2;
											lastType=SaveType.BackBlockAndTopBlockMoreLoadMultiple;
										} else goto default;
										break;

									case SaveType.BackBlockAndTopBlockMoreLoadMultiple:
										if (newBackBlockId==backBlockId && newTopBlockId==topBlockId) {
											SaveMachineTop(chunk.TopBlocks[y]);
											lastTypeCount++;
										} else goto default;
										break;

									default:
										SaveLast();

										if (newTopBlockId<(ushort)BlockId._MoreInLoad) {
											lastType=SaveType.BackBlockAndTopBlockMoreLoad;
											SaveMachineTop(chunk.TopBlocks[y]);
										} else {
											lastType=SaveType.BackBlockAndTopBlock;
										}

										lastTypeCount=1;

										#if DEBUG
										if (TopBlockFromId(newTopBlockId, Vector2Zero)==null) { 
											throw new Exception("Nějaký blok je zaregistrován jako top, ale není jako top definován");
										}
										if (BackBlockFromId(newBackBlockId, Vector2Zero)==null) { 
											throw new Exception("Nějaký blok je zaregistrován jako top, ale není jako top definován");
										}
										#endif


										topBlockId=newTopBlockId;
										backBlockId=newBackBlockId;
										break;
								}

							} else {

								// only top
								ushort newTopBlockId=chunk.TopBlocks[y].Id;

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
											SaveMachineTop(chunk.TopBlocks[y]);
											lastType=SaveType.TopBlockMoreLoadMultiple;
											lastTypeCount=2;
										} else goto default;
										break;

									case SaveType.TopBlockMoreLoadMultiple:
										if (newTopBlockId==topBlockId) {
											SaveMachineTop(chunk.TopBlocks[y]);
											lastTypeCount++;
										} else goto default;
										break;

									default:
										SaveLast();

										if (newTopBlockId<(ushort)BlockId._MoreInLoad) {
											lastType=SaveType.TopBlockMoreLoad;
											SaveMachineTop(chunk.TopBlocks[y]);
										} else {
											lastType=SaveType.TopBlock;
										}

										lastTypeCount=1;
										topBlockId=newTopBlockId;
										break;
								}
							}
						} else if (chunk.IsBackground[y]) {

							// only back
							ushort newBackBlockId=chunk.Background[y].Id;

							switch (lastType) {
								case SaveType.BackBlock:
									if (backBlockId==newBackBlockId) {
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

									#if DEBUG
									if (BackBlockFromId(newBackBlockId, Vector2Zero)==null) { 
										throw new Exception("Nějaký blok je zaregistrován jako top, ale není jako top definován");
									}
									#endif

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
							}
						}
					}
				}

				SaveLast();

				unsafe void SaveLast() {
					if (lastType==SaveType.Unknown) return;


					switch (lastType) {
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
							break;

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

				bytes.Add((byte)chunk.Plants.Count);
				if (chunk.Plants.Count>0) {
					foreach (Plant m in chunk.Plants) {
						ushort id=m.Id;
						byte* mbytes= (byte*)&id;
						bytes.Add(mbytes[1]);
						bytes.Add(mbytes[0]);

						bytes.Add((byte)m.Height);
						bytes.Add((byte)m.Grow);
					}
				}

				bytes.Add((byte)chunk.Mobs.Count);
				if (chunk.Mobs.Count>0) {
					foreach (Mob m in chunk.Mobs) {
						bytes.AddRange(m.Save());
						//ushort id=m.Id;
						//byte* mbytes= (byte*)&id;
						//bytes.Add(mbytes[1]);
						//bytes.Add(mbytes[0]);

						//bytes.Add(m.Height);
						//bytes.Add(m.Dir ? (byte)1 : (byte)0);
					}
				}
			}

			void SaveMachineTop(Block block) {
				switch (block.Id) {
					case (ushort)BlockId.FurnaceStone:
						{
							MashineBlockBasic fs=(MashineBlockBasic)block;
							tmpBytes.Add((byte)(fs.Energy*255));
							ItemInv[] inv=fs.Inv;
							for (int i = 0; i<4; i++) inv[i].SaveBytes(tmpBytes);
							return;
						}

					case (ushort)BlockId.Charger:
						{
							MashineBlockBasic m=(MashineBlockBasic)block;
							tmpBytes.Add((byte)(m.Energy*255));
							m.Inv[0].SaveBytes(tmpBytes);
							return;
						}

					case (ushort)BlockId.OxygenMachine:
						{
							MashineBlockBasic m=(MashineBlockBasic)block;
							tmpBytes.Add((byte)(m.Energy*255));
							m.Inv[0].SaveBytes(tmpBytes);
							return;
						}

					case (ushort)BlockId.WaterBlock:
						tmpBytes.Add((byte)((Water)block).GetMass);
						return;

					case (ushort)BlockId.WaterSalt:
						tmpBytes.Add((byte)((Water)block).GetMass);
						return;

					case (ushort)BlockId.Miner:
						{
							MashineBlockBasic m=(MashineBlockBasic)block;
							tmpBytes.Add((byte)(m.Energy*255));
							ItemInv[] inv=m.Inv;
							for (int i = 0; i<InvMaxMiner; i++) inv[i].SaveBytes(tmpBytes);
							return;
						}

					case (ushort)BlockId.Shelf:
						{
							ItemInv[] inv=((ShelfBlock)block).Inv;
							for (int i = 0; i<InvMaxShelf; i++) inv[i].SaveBytes(tmpBytes);
							return;
						}

					case (ushort)BlockId.BoxWooden:
						{
							ItemInv[] inv=((BoxBlock)block).Inv;
							for (int i = 0; i<InvMaxBoxWooden; i++) inv[i].SaveBytes(tmpBytes);
							return;
						}

					case (ushort)BlockId.BoxAdv:
						{
							ItemInv[] inv=((BoxBlock)block).Inv;
							for (int i = 0; i<InvMaxBoxAdv; i++) inv[i].SaveBytes(tmpBytes);
							return;
						}

					case (ushort)BlockId.Composter:
						{
							ItemInv[] inv=((ShelfBlock)block).Inv;
							for (int i = 0; i<9; i++) inv[i].SaveBytes(tmpBytes);
							return;
						}

					case (ushort)BlockId.Barrel:
						{
							Barrel barrel=(Barrel)block;
							tmpBytes.Add(barrel.LiquidId);
							tmpBytes.Add((byte)barrel.LiquidAmount);
						   // tmpBytes.Add((byte)(barrel.LiquidAmount>>8));

							ItemInv[] inv=barrel.Inv;
							inv[0].SaveBytes(tmpBytes);
							inv[1].SaveBytes(tmpBytes);
							return;
						}
				}
				return;
			}

			File.WriteAllBytes(pathToWorld+"\\"+world+".ter",bytes.ToArray());

            for (int i = 0; i<LiveObjects.Length; i++) {
				SaveLiveObject(LiveObjects[i]);
            }

			File.WriteAllBytes(pathToWorld + @"\"+world+"LiveObjects.bin", bytesLiveObjects.ToArray());

			void SaveLiveObject(LiveObject lo) {
                switch (lo) { 
                    case Tree tree:
                        // Basic info
                        bytesLiveObjects.Add((byte)LiveObjectType.Tree);

                        bytesLiveObjects.Add((byte)tree.Root.X);
                        bytesLiveObjects.Add((byte)(tree.Root.X>>8));
                        bytesLiveObjects.Add(tree.Root.Y);

                        // Wood
                        int countWood=tree.TitlesWood.Count;
                        bytesLiveObjects.Add((byte)countWood);

                        for (int i=0; i<countWood; i++) { 
                            UShortAndByte sab=tree.TitlesWood[i];

                            bytesLiveObjects.Add((byte)sab.X);
                            bytesLiveObjects.Add((byte)(sab.X>>8));
                            bytesLiveObjects.Add(sab.Y);
                        }

                        // Leaves
                        int countLeaves=tree.TitlesLeaves.Count;
                        bytesLiveObjects.Add((byte)countLeaves);

                        for (int i=0; i<countLeaves; i++) { 
                            UShortAndByte sab=tree.TitlesLeaves[i];

                            bytesLiveObjects.Add((byte)sab.X);
                            bytesLiveObjects.Add((byte)(sab.X>>8));
                            bytesLiveObjects.Add(sab.Y);
                        }
                        break;

                    case Cactus cactus:
                        // Basic info
                        bytesLiveObjects.Add((byte)LiveObjectType.Cactus);

                        bytesLiveObjects.Add((byte)cactus.Root.X);
                        bytesLiveObjects.Add((byte)(cactus.Root.X>>8));
                        bytesLiveObjects.Add(cactus.Root.Y);

                        // Material
                        int count=cactus.Titles.Count;
                        bytesLiveObjects.Add((byte)count);

                        for (int i=0; i<count; i++) { 
                            UShortAndByte sab=cactus.Titles[i];

                            bytesLiveObjects.Add((byte)sab.X);
                            bytesLiveObjects.Add((byte)(sab.X>>8));
                            bytesLiveObjects.Add(sab.Y);
                        }
                        break;
                }
                    
            }

		}

		unsafe void Load() {
			List<DInt> labels=new List<DInt>();
			string path =pathToWorld+ world+".ter";

			if (File.Exists(path)) {
				byte[] array=File.ReadAllBytes(path);
				fixed (byte* pointer = &array[0]) {
					byte* current=pointer;

					#if DEBUG
					SaveType lastSaveType=SaveType.Unknown;
					#endif

					for (int pos=0; pos<TerrainLength; pos++) {
						Terrain chunk=terrain[pos]=new Terrain {
							LightPosFull=*current++,
						//	Half=*current++==1,
							LightPosHalf=*current++,
						};

						int pos16=pos*16;
						chunk.LightPosHalf16=chunk.LightPosHalf*16;
						chunk.LightPosFull16=chunk.LightPosFull*16;
						chunk.LightVec=new Vector2(pos16-48+8,chunk.LightPosFull16-48+8+48);

						int  StartSomething=0;
						bool startingSomething=true;

						for (int length=0; length<125;) {
							byte way = *current++;

							switch (way) {
								// 0: 1× air (nothing)
								case (byte)SaveType.Air:
									//chunk.SolidBlocks[length]=null;
									length++;
									break;

								// 1: ?× air (nothing)
								case (byte)SaveType.AirMultiple:
								//	{
									length+=*current++;
										//int to = length+*current++;
										//Block[] sb=chunk.SolidBlocks;
										//for (;length<to; length++) {
										//	sb[length]=null;
										//}
									//}
									break;

								// 1× solid block
								case (byte)SaveType.SolidBlock:
									{
									 //   ushort id=(ushort)(*current++ | (*current++ << 8));

										chunk.SolidBlocks[length]=SolidBlockFromId(/*id*/(ushort)(*current++ | (*current++ << 8)), new Vector2(pos16, length*16))
											#if DEBUG
											??throw new Exception("Solid block is null")
											#endif
										;

										chunk.IsSolidBlocks[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// 1× solid block
								case (byte)SaveType.SolidBlockWithLowId:
									{
									   // ushort id=*current++;

										chunk.SolidBlocks[length]=SolidBlockFromId(/*id*/(ushort)*current++, new Vector2(pos16, length*16))
											#if DEBUG
											??throw new Exception("Solid block is null")
											#endif
											;

										chunk.IsSolidBlocks[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// ?× solid block
								case (byte)SaveType.SolidBlockMultiple:
									{
										ushort id=(ushort)(*current++ | (*current++ << 8));

										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										Block block=SolidBlockFromId(id, new Vector2(pos16, length*16));

										chunk.SolidBlocks[length]=block
											#if DEBUG
											??throw new Exception("Solid block is null")
											#endif
											;

										chunk.IsSolidBlocks[length]=true;
										length++;

										for (; length<to; length++) {
											chunk.SolidBlocks[length]=block=block.CloneDown();

											chunk.IsSolidBlocks[length]=true;
										}
									}
									break;

								// ?× solid block
								case (byte)SaveType.SolidBlockWithLowIdMultiple:
									{
										ushort id=*current++;
										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										Block block=SolidBlockFromId(id, new Vector2(pos16, length*16));

										chunk.SolidBlocks[length]=block
											#if DEBUG
											??throw new Exception("Solid block is null");
											#endif
											;
										chunk.IsSolidBlocks[length]=true;

										length++;

										for (; length<to; length++) {
											chunk.SolidBlocks[length]=block=block.CloneDown();
											chunk.IsSolidBlocks[length]=true;
										}
									}
									break;

								// 1× back block
								case (byte)SaveType.BackBlock:
									{
									  //  ushort id=(ushort)(*current++ | (*current++ << 8));

									  //  chunk.SolidBlocks[length]=new AirSolidBlock {
										   /* Back=*/chunk.Background[length]=BackBlockFromId(/*id*/(ushort)(*current++ | (*current++ << 8)), new Vector2(pos16, length*16))
												#if DEBUG
												??throw new Exception("Back block is null")
												#endif
											  //  ,
										//}
										;
										chunk.IsBackground[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}
										length++;
									}
									break;

								// 1× back block
								case (byte)SaveType.BackBlockWithLowId:
									{
									   // ushort id=*current++;

										chunk.Background[length]=BackBlockFromId((ushort)*current++, new Vector2(pos16, length*16))
											#if DEBUG
											??throw new Exception("Back block is null")
											#endif
										;

										chunk.IsBackground[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}
										length++;
									}
									break;

								// ?× back block
								case (byte)SaveType.BackBlockMultiple:
									{
										ushort id=(ushort)(*current++ | (*current++ << 8));
										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										Block block=BackBlockFromId(id, new Vector2(pos16, length*16));



									// chunk.SolidBlocks[length]=new AirSolidBlock {
									/*Back=*/
									chunk.Background[length]=block
										#if DEBUG
										??throw new Exception("Back block is null, možná špatně naprogramováno načítání terénu, nebo v BackBlockFromId není zaregistrován block")//,
										#endif
									;
									//};
										chunk.IsBackground[length]=true;

										length++;

										for (; length<to; length++) {
											// chunk.SolidBlocks[length]=new AirSolidBlock {
												/*Back=*/chunk.Background[length]=block=block.CloneDown();/*,*/
											//};
											chunk.IsBackground[length]=true;
										}
									}
									break;

								// ?× back block
								case (byte)SaveType.BackBlockWithLowIdMultiple:
									{
										ushort id=*current++;
										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										Block block=BackBlockFromId(id, new Vector2(pos16, length*16));

									  //  chunk.SolidBlocks[length]=new AirSolidBlock {
											/*Back=*/chunk.Background[length]=block
												#if DEBUG
												??throw new Exception("Back block is null, možná špatně naprogramováno načítání terénu, nebo v BackBlockFromId není zaregistrován block")
												#endif
												;
											//,
									   // };
										chunk.IsBackground[length]=true;

										length++;

										for (; length<to; length++) {
										  //  chunk.SolidBlocks[length]=new AirSolidBlock {
												/*Back=*/chunk.Background[length]=block=block.CloneDown()/*,*/;
										   // };
											chunk.IsBackground[length]=true;
										}
									}
									break;

								// 1× only top block (no more load)
								case (byte)SaveType.TopBlock:
									{
									   // ushort id=(ushort)(*current++ | (*current++ << 8));

									   // chunk.SolidBlocks[length]=new AirSolidBlock {
										   /* Top=*/chunk.TopBlocks[length]=TopBlockFromId((ushort)(*current++ | (*current++ << 8))/*id*/, new Vector2(pos16, length*16))
												#if DEBUG
												?? throw new Exception("Top block is null, možná špatně naprogramováno načítání terénu, nebo v BackBlockFromId není zaregistrován block")
												#endif
												;
											  //  ,
									   // };
										chunk.IsTopBlocks[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// 1× only top block (no more load)
								case (byte)SaveType.TopBlockWithLowId:
									{
									  //  ushort id=*current++;

										chunk.TopBlocks[length]=TopBlockFromId(/*id*/(ushort)*current++, new Vector2(pos16, length*16))
											#if DEBUG
											??throw new Exception("Top block is null, možná špatně naprogramováno načítání terénu, nebo v BackBlockFromId není zaregistrován block")
											#endif
										;

										chunk.IsTopBlocks[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// ?× only top block (no more load)
								case (byte)SaveType.TopBlockMultiple:
									{
										ushort id=(ushort)(*current++ | (*current++ << 8));
										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										Block block=TopBlockFromId(id, new Vector2(pos16, length*16))
										#if DEBUG
										?? throw new Exception("Top block is null, možná špatně naprogramováno načítání terénu, nebo v BackBlockFromId není zaregistrován block");
										#endif
									;
									  //  chunk.SolidBlocks[length]=new AirSolidBlock {
											/*Top=*/chunk.TopBlocks[length]=block/*,*/;
										//};
										chunk.IsTopBlocks[length]=true;

										length++;

										for (; length<to; length++) {
										   // chunk.SolidBlocks[length]=new AirSolidBlock {
											   /* Top=*/chunk.TopBlocks[length]=block=block.CloneDown()/*,*/;
											//};
											chunk.IsTopBlocks[length]=true;
										}
									}
									break;

								// ?× only top block (no more load)
								case (byte)SaveType.TopBlockWithLowIdMultiple:
									{
										ushort id=*current++;
										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										Block block=TopBlockFromId(id, new Vector2(pos16, length*16))
											#if DEBUG
											?? throw new Exception("Top block is null, možná špatně naprogramováno načítání terénu, nebo v BackBlockFromId není zaregistrován block")
											#endif
										;
										chunk.TopBlocks[length]=block;
										chunk.IsTopBlocks[length]=true;

										length++;

										for (; length<to; length++) {
											chunk.TopBlocks[length]=block=block.CloneDown();
											chunk.IsTopBlocks[length]=true;
										}
									}
									break;

								// 1× back and top block
								case (byte)SaveType.BackBlockAndTopBlock:
									{
										ushort idBack=(ushort)(*current++ | (*current++ << 8)),
											   idTop=(ushort)(*current++ | (*current++ << 8));

										Vector2 vec=new Vector2(pos16, length*16);

										chunk.Background[length]=BackBlockFromId(idBack, vec) 
											#if DEBUG
											??throw new Exception("Back block is null")
											#endif
										;
										chunk.TopBlocks[length]=TopBlockFromId(idTop, vec)
											#if DEBUG
											??throw new Exception("Top block with id "+(BlockId)idTop+" is null")
											#endif
										;
									   
										chunk.IsBackground[length]=true;
										chunk.IsTopBlocks[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// 1× back and top block
								case (byte)SaveType.BackBlockWithLowIdAndTopBlock:
									{
										ushort idBack=*current++,
											   idTop=(ushort)(*current++ | (*current++ << 8));

										Vector2 vec=new Vector2(pos16, length*16);

										chunk.Background[length]=BackBlockFromId(idBack, vec)
											#if DEBUG
											?? throw new Exception("Back block is null");
											#endif
										;
										chunk.TopBlocks[length]=TopBlockFromId(idTop, vec)
											#if DEBUG
											?? throw new Exception("Top block with id "+(BlockId)idTop+" is null");
											#endif
										;
									  
										chunk.IsBackground[length]=true;
										chunk.IsTopBlocks[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// 1× back and top block
								case (byte)SaveType.BackBlockAndTopBlockWithLowId:
									{
										ushort idBack=(ushort)(*current++ | (*current++ << 8)),
											   idTop=*current++;

										Vector2 vec=new Vector2(pos16, length*16);

										chunk.Background[length]=BackBlockFromId(idBack, vec)
											#if DEBUG
											??throw new Exception("Back block is null")
											#endif
										;
										chunk.TopBlocks[length]=TopBlockFromId(idTop, vec)
											#if DEBUG
											??throw new Exception("Top block with id "+(BlockId)idTop+" is null")
											#endif
										;
									  
										chunk.IsBackground[length]=true;
										chunk.IsTopBlocks[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// 1× back and top block
								case (byte)SaveType.BackBlockWithLowIdAndTopBlockWithLowId:
									{
										ushort idBack=*current++,
											   idTop=*current++;

										Vector2 vec=new Vector2(pos16, length*16);
									  
										chunk.Background[length]=BackBlockFromId(idBack, vec)
											#if DEBUG
											?? throw new Exception("Back block is null")
											#endif
										;

										chunk.TopBlocks[length]=TopBlockFromId(idTop, vec)
											#if DEBUG
											?? throw new Exception("Top block with id "+(BlockId)idTop+" is null")
											#endif
										;

										chunk.IsBackground[length]=true;
										chunk.IsTopBlocks[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// ?× back and top block
								case (byte)SaveType.BackBlockAndTopBlockMultiple:
									{
										ushort idBack=(ushort)(*current++ | (*current++ << 8)),
											   idTop=(ushort)(*current++ | (*current++ << 8));

										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										Vector2 vec=new Vector2(pos16, length*16);

										Block blockBack = BackBlockFromId(idBack, vec)
											#if DEBUG
											?? throw new Exception("Back block is null")
											#endif
										;
										Block blockTop = TopBlockFromId(idTop, vec)
											#if DEBUG
											?? throw new Exception("Top block is null")
											#endif
										;
									
										chunk.Background[length]=blockBack;
										chunk.TopBlocks[length]=blockTop;


										chunk.IsBackground[length]=true;
										chunk.IsTopBlocks[length]=true;

										length++;

										for (; length<to; length++) {
										   // chunk.SolidBlocks[length]=new AirSolidBlock {
											   /* Back=*/chunk.Background[length]=blockBack=blockBack.CloneDown();//,
												/*Top=*/chunk.TopBlocks[length]=blockTop=blockTop.CloneDown();
										 //   };

											chunk.IsBackground[length]=true;
											chunk.IsTopBlocks[length]=true;
										}
									}
									break;

								// ?× back and top block
								case (byte)SaveType.BackBlockWithLowIdAndTopBlockMultiple:
									{
										ushort idBack=*current++,
											   idTop=(ushort)(*current++ | (*current++ << 8));

										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										for (; length<to; length++) {
											Vector2 vec=new Vector2(pos16, length*16);

											chunk.Background[length]=BackBlockFromId(idBack, vec)
												#if DEBUG
												?? throw new Exception("Back block is null")
												#endif
											;
											chunk.TopBlocks[length]=TopBlockFromId(idTop, vec)
												#if DEBUG
												?? throw new Exception("Top block is null")
												#endif
											;

											chunk.IsBackground[length]=true;
											chunk.IsTopBlocks[length]=true;
										}
									}
									break;

								// ?× back and top block
								case (byte)SaveType.BackBlockAndTopBlockWithLowIdMultiple:
									{
										ushort idBack=(ushort)(*current++ | (*current++ << 8)),
											   idTop=*current++;

										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										for (; length<to; length++) {
											Vector2 vec=new Vector2(pos16, length*16);
									   
											chunk.TopBlocks[length]=TopBlockFromId(idTop, vec)
												#if DEBUG
												?? throw new Exception("Top block is null")
												#endif
											;

											chunk.Background[length]=BackBlockFromId(idBack, vec)
												#if DEBUG
												?? throw new Exception("Back block is null");
												#endif
											;

											chunk.IsBackground[length]=true;
											chunk.IsTopBlocks[length]=true;
										}
									}
									break;

								// ?× back and top block
								case (byte)SaveType.BackBlockWithLowIdAndTopBlockWithLowIdMultiple:
									{
										ushort idBack=*current++,
											   idTop=*current++;

										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										Vector2 vec=new Vector2(pos16, length*16);


										Block blockBack=BackBlockFromId(idBack, vec)
											#if DEBUG
											?? throw new Exception("Back block is null")
											#endif
										;
										Block blockTop=TopBlockFromId(idTop, vec)
											#if DEBUG
											?? throw new Exception("Top block is null")
											#endif
										;


									   // chunk.SolidBlocks[length]=new AirSolidBlock {
										   /* Back=*/chunk.Background[length]=blockBack/*,*/;
											/*Top=*/chunk.TopBlocks[length]=blockTop;
									  //  };

										chunk.IsBackground[length]=true;
										chunk.IsTopBlocks[length]=true;

										length++;

										for (; length<to; length++) {
											//chunk.SolidBlocks[length]=new AirSolidBlock {
												/*Back=*/chunk.Background[length]=blockBack=blockBack.CloneDown()/*,*/;
												/*Top=*/chunk.TopBlocks[length]=blockTop=blockTop.CloneDown();
										   // };

											chunk.IsBackground[length]=true;
											chunk.IsTopBlocks[length]=true;
										}
									}
									break;

								// 1× top block (+ more load)
								case (byte)SaveType.TopBlockMoreLoad:
									{
										ushort id=(ushort)(*current++ | (*current++ << 8));

										Block block=TopBlockFromId(id, new Vector2(pos16, length*16));

										#if DEBUG
										if (block==null) throw new Exception("Top block is null");
										#endif

										LoadMashine(id, block);

										//chunk.SolidBlocks[length]=new AirSolidBlock {
										   /* Top=*/chunk.TopBlocks[length]=block/*,*/;
									   // };
										chunk.IsTopBlocks[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// 1× top block (+ more load)
								case (byte)SaveType.TopBlockWithLowIdMoreLoad:
									{
										ushort id=*current++;

										Block block=TopBlockFromId(id, new Vector2(pos16, length*16));

										#if DEBUG
										if (block==null) throw new Exception("Top block is null");
										#endif

										LoadMashine(id, block);

									   // chunk.SolidBlocks[length]=new AirSolidBlock {
											/*Top=*/chunk.TopBlocks[length]=block/*,*/;
										//};
										chunk.IsTopBlocks[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// ?× top block (+ more load)
								case (byte)SaveType.TopBlockMoreLoadMultiple:
									{
										ushort id=(ushort)(*current++ | (*current++ << 8));
										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										for (; length<to; length++) {
											Block block=TopBlockFromId(id, new Vector2(pos16, length*16));

											#if DEBUG
											if (block==null) throw new Exception("Top block is null");
											#endif

											LoadMashine(id,block);

										  //  chunk.SolidBlocks[length]=new AirSolidBlock {
												/*Top=*/chunk.TopBlocks[length]=block;//,
											//};
											chunk.IsTopBlocks[length]=true;
										}
									}
									break;

								// ?× top block (+ more load)
								case (byte)SaveType.TopBlockWithLowIdMoreLoadMultiple:
									{
										ushort id=*current++;
										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										Block block=TopBlockFromId(id, new Vector2(pos16, length*16));

										#if DEBUG
										if (block==null) throw new Exception("Top block is null");
										#endif

										LoadMashine(id,block);

									 //   chunk.SolidBlocks[length]=new AirSolidBlock {
											/*Top=*/chunk.TopBlocks[length]=block/*,*/;
									   // };
										chunk.IsTopBlocks[length]=true;

										length++;

										for (; length<to; length++) {
										 //   chunk.SolidBlocks[length]=new AirSolidBlock {
												/*Top=*/chunk.TopBlocks[length]=block=block.CloneDown();//,
										   // };

											LoadMashine(id,block);

											chunk.IsTopBlocks[length]=true;
										}
									}
									break;

								// 1× back and top block (+ more load)
								case (byte)SaveType.BackBlockAndTopBlockWithLowIdMoreLoad:
									{
										ushort idBack=(ushort)(*current++ | (*current++ << 8)),
											idTop=*current++;

										Vector2 vec=new Vector2(pos16, length*16);

										Block blockBack=BackBlockFromId(idBack, vec)
											#if DEBUG
											?? throw new Exception("Back block is null");
											#endif
										;
										Block blockTop=TopBlockFromId(idTop, vec)
											#if DEBUG
											?? throw new Exception("Top block is null");
											#endif
										;


										LoadMashine(idTop, blockTop);

									   // chunk.SolidBlocks[length]=new AirSolidBlock {
											/*Top=*/chunk.TopBlocks[length]=blockTop/*,*/;
											/*Back=*/chunk.Background[length]=blockBack;
										//};
										chunk.IsTopBlocks[length]=true;
										chunk.IsBackground[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// 1× back and top block (+ more load)
								case (byte)SaveType.BackBlockAndTopBlockMoreLoad:
									{
										ushort idTop=(ushort)(*current++ | (*current++ << 8));

										Vector2 vec=new Vector2(pos16, length*16);
										Block blockTop=TopBlockFromId(idTop, vec)
											#if DEBUG
											?? throw new Exception("Top block is null")
											#endif
										;
										Block blockBack=BackBlockFromId((ushort)(*current++ | (*current++ << 8)), vec)
											#if DEBUG
											?? throw new Exception("Back block is null");
											#endif
										;


										LoadMashine(idTop, blockTop);

									   // chunk.SolidBlocks[length]=new AirSolidBlock {
											/*Top=*/chunk.TopBlocks[length]=blockTop/*,*/;
											/*Back=*/chunk.Background[length]=blockBack;
									   // };
										chunk.IsTopBlocks[length]=true;
										chunk.IsBackground[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// 1× back and top block (+ more load)
								case (byte)SaveType.BackBlockWithLowIdAndTopBlockMoreLoad:
									{
										ushort idBack=*current++,
											idTop=(ushort)(*current++ | (*current++ << 8));

										Vector2 vec=new Vector2(pos16, length*16);
										Block blockTop=TopBlockFromId(idTop, vec);
									  //  Block blockBack=;


										LoadMashine(idTop, blockTop);

										chunk.TopBlocks[length]=blockTop
											#if DEBUG
											?? throw new Exception("Top block is null")
											#endif
										;

										chunk.Background[length]=BackBlockFromId(idBack, vec)
											#if DEBUG
											?? throw new Exception("Back block is null")
											#endif
										;
									   // };
										chunk.IsTopBlocks[length]=true;
										chunk.IsBackground[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// 1× back and top block (+ more load)
								case (byte)SaveType.BackBlockWithLowIdAndTopBlockWithLowIdMoreLoad:
									{
										ushort idBack=*current++,
											idTop=*current++;

										Vector2 vec=new Vector2(pos16, length*16);
										chunk.Background[length]=/*Block blockBack=*/BackBlockFromId(idBack, vec)
											#if DEBUG
											?? throw new Exception("Back block is null");
											#endif
										;
										Block blockTop=TopBlockFromId(idTop, vec)
											#if DEBUG
											?? throw new Exception("Top block is null");
											#endif
										;


										LoadMashine(idTop, blockTop);

									  //  chunk.SolidBlocks[length]=new AirSolidBlock {
											/*Top=*/chunk.TopBlocks[length]=blockTop;//,
										   // /*Back=*/blockBack;
									   // };
										chunk.IsTopBlocks[length]=true;
										chunk.IsBackground[length]=true;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										length++;
									}
									break;

								// ?× back and top block (+ more load)
								case (byte)SaveType.BackBlockAndTopBlockMoreLoadMultiple:
									{
										ushort idBack=(ushort)(*current++ | *current++ << 8),
											idTop=(ushort)(*current++ | *current++ << 8);

										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										for (; length<to; length++) {
											Vector2 vec=new Vector2(pos16, length*16);

											Block blockTop=TopBlockFromId(idTop, vec)
												#if DEBUG
												?? throw new Exception("Top block is null");
												#endif
											;
											LoadMashine(idTop, blockTop);
										
											chunk.TopBlocks[length]=blockTop;

											chunk.Background[length] = BackBlockFromId(idBack, vec)
												#if DEBUG
												?? throw new Exception("Back block is null");
												#endif
											;

											chunk.IsTopBlocks[length]=true;
											chunk.IsBackground[length]=true;

										}
									}
									break;

								// ?× back and top block (+ more load)
								case (byte)SaveType.BackBlockAndTopBlockWithLowIdMoreLoadMultiple:
									{
										ushort idBack=(ushort)(*current++ | *current++ << 8),
											idTop=*current++;

										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										for (; length<to; length++) {
											Vector2 vec=new Vector2(pos16, length*16);

											Block blockTop=TopBlockFromId(idTop, vec)
												#if DEBUG
												?? throw new Exception("Top block is null")
												#endif
											;

											LoadMashine(idTop, blockTop);

											chunk.TopBlocks[length]=blockTop;

											chunk.Background[length]=BackBlockFromId(idBack, vec)
												 #if DEBUG
												?? throw new Exception("Back block is null")
												#endif
											;

											chunk.IsTopBlocks[length]=true;
											chunk.IsBackground[length]=true;
										}
									}
									break;

								// ?× back and top block (+ more load)
								case (byte)SaveType.BackBlockWithLowIdAndTopBlockMoreLoadMultiple:
									{
										ushort idBack=*current++,
											idTop=(ushort)(*current++ | *current++ << 8);

										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										for (; length<to; length++) {
											Vector2 vec=new Vector2(pos16, length*16);

											Block blockTop=TopBlockFromId(idTop, vec);
										   // Block blockBack=BackBlockFromId(idBack, vec);

											#if DEBUG
											if (blockTop==null) throw new Exception("Top block is null");
										  //  if (blockBack==null) throw new Exception("Back block is null");
											#endif


											LoadMashine(idTop, blockTop);

										   // chunk.SolidBlocks[length]=new AirSolidBlock {
												/*Top=*/chunk.TopBlocks[length]=blockTop/*,*/;
												/*Back=*/chunk.Background[length]=/*blockBack*/BackBlockFromId(idBack, vec)
											 #if DEBUG
											?? throw new Exception("Back block is null")
											#endif
											
											;
										  //  };
											chunk.IsTopBlocks[length]=true;
											chunk.IsBackground[length]=true;
										}
									}
									break;

								// ?× back and top block (+ more load)
								case (byte)SaveType.BackBlockWithLowIdAndTopBlockWithLowIdMoreLoadMultiple:
									{
										ushort idBack=*current++,
											idTop=*current++;

										int to=length+*current++;

										if (startingSomething) {
											startingSomething=false;
											StartSomething=length;
										}

										Vector2 vec=new Vector2(pos16, length*16);

										Block blockBack=BackBlockFromId(idBack, vec)
											#if DEBUG
											?? throw new Exception("Back block is null")
											#endif
										;
										Block blockTop=TopBlockFromId(idTop, vec)
											#if DEBUG
											?? throw new Exception("Top block is null")
											#endif
										;


										LoadMashine(idTop, blockTop);

									  //  chunk.SolidBlocks[length]=new AirSolidBlock {
											/*Top=*/chunk.TopBlocks[length]=blockTop/*,*/;
										   /* Back=*/chunk.Background[length]=blockBack;
									   // };
										chunk.IsTopBlocks[length]=true;
										chunk.IsBackground[length]=true;

										length++;

										for (; length<to; length++) {
										 //   chunk.SolidBlocks[length]=new AirSolidBlock {
												/*Top=*/chunk.TopBlocks[length]=blockTop=blockTop.CloneDown()/*,*/;
											   /* Back=*/chunk.Background[length]=blockBack=blockBack.CloneDown();
										   // };

											LoadMashine(idTop, blockTop);

											chunk.IsTopBlocks[length]=true;
											chunk.IsBackground[length]=true;
										}
									}
									break;

								default:
									#if DEBUG
									throw new Exception("SaveType "+(SaveType)way+" is not defined in switch, maybe programer created mistake in "+lastSaveType);
									#else
									break;
									#endif

							}

							void LoadMashine(ushort id, Block block) {
								switch (id) {
									case (ushort)BlockId.WaterSalt:
										((Water)block).Mass(*current++);
										break;

									case (ushort)BlockId.WaterBlock:
										((Water)block).Mass(*current++);
										break;

									case (ushort)BlockId.Label:
										labels.Add(new DInt{X=pos, Y=length });
										break;

									case (ushort)BlockId.Shelf:
										LoadInventoryMashine(((ShelfBlock)block).Inv,InvMaxShelf);

										if (((ShelfBlock)block).Inv[4].Id!=0) {
											switch (((ShelfBlock)block).Inv[4]) {
												case ItemInvBasic16 item:
													((ShelfBlock)block).SmalItemTexture=item.Texture;
													((ShelfBlock)block).IsSmallItem=true;
													break;

												case ItemInvBasic32 item:
													((ShelfBlock)block).SmalItemTexture=item.Texture;
													((ShelfBlock)block).IsSmallItem=true;
													break;

												case ItemInvTool16 item:
													((ShelfBlock)block).SmalItemTexture=item.Texture;
													((ShelfBlock)block).IsSmallItem=true;
													break;

												case ItemInvTool32 item:
													((ShelfBlock)block).SmalItemTexture=item.Texture;
													((ShelfBlock)block).IsSmallItem=true;
													break;
											}
										}
										break;

									case (ushort)BlockId.BoxWooden:
										LoadInventoryMashine(((BoxBlock)block).Inv=new ItemInv[InvMaxBoxWooden], InvMaxBoxWooden);
										break;

									case (ushort)BlockId.BoxAdv:
										LoadInventoryMashine(((BoxBlock)block).Inv=new ItemInv[InvMaxBoxAdv], InvMaxBoxAdv);
										break;

									case (ushort)BlockId.Flag:
										windable.Add(new ShortAndByte(pos, length));
										break;

									case (ushort)BlockId.BucketForRubber:
										bucketRubber.Add(new ShortAndByte(pos,length));
										break;

									case (ushort)BlockId.Windmill:
										windable.Add(new ShortAndByte(pos,length));
										break;

									case (ushort)BlockId.FurnaceStone:
										{
											MashineBlockBasic fs = (MashineBlockBasic)block;
											LoadInventoryMashine(fs.Inv,InvMaxFurnaceStone);

											fs.Energy=*current++/255f;

											FurnaceStone.Add(new ShortAndByte(pos, length));
										}
									break;

									case (ushort)BlockId.Charger:
										LoadInventoryMashine(((MashineBlockBasic)block).Inv=new ItemInv[1],1);
										Chargers.Add(new ShortAndByte(pos, length));
										break;

									case (ushort)BlockId.OxygenMachine:
										LoadInventoryMashine(((MashineBlockBasic)block).Inv=new ItemInv[1],1);
										((MashineBlockBasic)block).Energy=*current++/255f;
										OxygenMachines.Add(new ShortAndByte(pos, length));
										break;

									case (ushort)BlockId.Miner:
										LoadInventoryMashine(((MashineBlockBasic)block).Inv=new ItemInv[InvMaxMiner],InvMaxMiner);
										Miners.Add(new ShortAndByte(pos, length));
										break;

									case (ushort)BlockId.Composter:
										LoadInventoryMashine(((MashineBlockBasic)block).Inv=new ItemInv[InvMaxComposter],InvMaxComposter);
										Composters.Add(new ShortAndByte(pos, length));
										break;

									//case (ushort)BlockId.OakWood:
									//case (ushort)BlockId.SpruceWood:
									//case (ushort)BlockId.PineWood:
									//case (ushort)BlockId.LindenWood:
									//case (ushort)BlockId.AppleWood:
									//case (ushort)BlockId.CherryWood:
									//case (ushort)BlockId.PlumWood:
									//case (ushort)BlockId.LemonWood:
									//case (ushort)BlockId.OrangeWood:
									//case (ushort)BlockId.WillowWood:
									//case (ushort)BlockId.MangroveWood:
									//case (ushort)BlockId.EucalyptusWood:
									//case (ushort)BlockId.OliveWood:
									//case (ushort)BlockId.RubberTreeWood:
									//case (ushort)BlockId.AcaciaWood:
									//case (ushort)BlockId.KapokWood:
									//    {
									//        int index=(*current++) | (*current++>>8) | (*current++>>16);
									//        if (treeIndex<index) LiveObjects.Add(new Tree());

									//        WoodBlock wood=(WoodBlock)block;
									//        LiveObjects[treeIndex].
									//    }
									//    break;

									//case (ushort)BlockId.LindenLeaves:
									//case (ushort)BlockId.AppleLeaves:
									//case (ushort)BlockId.AppleLeavesWithApples:
									//case (ushort)BlockId.EucalyptusLeaves:
									//case (ushort)BlockId.CherryLeavesWithCherries:
									//case (ushort)BlockId.PineLeaves:
									//case (ushort)BlockId.PlumLeaves:
									//case (ushort)BlockId.PlumLeavesWithPlums:
									//case (ushort)BlockId.CherryLeaves:
									//case (ushort)BlockId.OrangeLeaves:
									//case (ushort)BlockId.OrangeLeavesWithOranges:
									//case (ushort)BlockId.WillowLeaves:
									//case (ushort)BlockId.RubberTreeLeaves:
									//case (ushort)BlockId.LemonLeaves:
									//case (ushort)BlockId.OliveLeavesWithOlives:
									//case (ushort)BlockId.LemonLeavesWithLemons:
									//case (ushort)BlockId.MangroveLeaves:
									//case (ushort)BlockId.AcaciaLeaves:
									//case (ushort)BlockId.KapokLeacesFlowering:
									//case (ushort)BlockId.KapokLeacesFibre:
									//case (ushort)BlockId.KapokLeaces:
									//case (ushort)BlockId.OliveLeaves:
									//case (ushort)BlockId.OakLeaves:
									//case (ushort)BlockId.SpruceLeaves:
									//    {
									//        int index=(*current++) | (*current++>>8) | (*current++>>16);
									//        if (index>treeIndex)
									//    }
									//    break;

									case (ushort)BlockId.Barrel:
										{
											Barrel barrel=(Barrel)block;

											barrel.LiquidId=*current++;
											barrel.LiquidAmount=*current++ /*| (*current++ << 8)*/;

											LoadInventoryMashine(barrel.Inv=new ItemInv[InvMaxBarrel], InvMaxBarrel);

										  //  Barrels.Add(new ShortAndByte(pos, length));
										}
										break;
								}
							}

							#if DEBUG
							lastSaveType=(SaveType)way;
							#endif
						}

						void LoadInventoryMashine(ItemInv[] a, int max) {
							for (int i = 0; i<max; i++) {
								ushort id = (ushort)(*current++ | (*current++<<8));
								if (id==0) a[i]=itemBlank;
								else {
									if (GameMethods.IsItemInvBasic16(id)) {
										a[i]=new ItemInvBasic16(ItemIdToTexture(id), id, /*(ushort)*/(*current++ | (*current++<<8))/*, 0, 0*/);
										continue;
									}

									if (GameMethods.IsItemInvBasic32(id)) {
										a[i]=new ItemInvBasic32(ItemIdToTexture(id), id, /*(ushort)*/(*current++ | (*current++<<8))/*, 0, 0*/);
										continue;
									}

									if (GameMethods.IsItemInvTool32(id)) {
										a[i]=new ItemInvTool32(ItemIdToTexture(id), id, /*(ushort)*/(*current++ | (*current++<<8))/*, GameMethods.ToolMax(id), 0, 0*/);
										continue;
									}

									if (GameMethods.IsItemInvFood16(id)) {
										a[i]=new ItemInvFood16(ItemIdToTexture(id), id, /*(ushort)*/(*current++ | (*current++<<8)), /*GameMethods.FoodMaxCount(id),*/ /*(ushort)*/GetFloat()/*(float)(*current++ | (*current++<<8)), GameMethods.FoodMaxDescay(id), 0, 0*/);
										continue;
									}

									if (GameMethods.IsItemInvTool16(id)) {
										a[i]=new ItemInvTool32(ItemIdToTexture(id), id, /*(ushort)*/(*current++ | (*current++<<8)) /*,GameMethods.ToolMax(id), 0, 0*/);
										continue;
									}

									if (GameMethods.IsItemInvBasicColoritzed32NonStackable(id)) {
										a[i]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(id), id, new Color(*current++, *current++, *current++)/*, 0, 0*/);
										continue;
									}

									if (GameMethods.IsItemInvNonStackable32(id)) {
										a[i]=new ItemInvNonStackable32(ItemIdToTexture(id), id, 0, 0);
										continue;
									}

									if (GameMethods.IsItemInvFood32(id)) {
										a[i]=new ItemInvFood32(ItemIdToTexture(id), id, /*(ushort)*/(*current++ | (*current++<<8)), GetFloat()/*GameMethods.FoodMaxCount(id),*/ /*(ushort)(float)(*current++ | (*current++<<8))*//*, GameMethods.FoodMaxDescay(id), 0, 0*/);
										continue;
									}

									#if DEBUG
									throw new Exception("Missing category for item "+(Items)id+".\r\nWhy?\r\nUp missing code IsItemInv... or item is not in categories");
									#else
									a[i]=itemBlank;
									#endif
								}
							}
						}

						#region Plants
						{
							int count=*current++;
							for (int i=0; i<count; i++) {
								ushort id=(ushort)((*current++<<8) | *current++);
								Plant plant=GetPlantFromId(id, *current++, *current++, (short)pos);
								#if DEBUG
								if (plant==null)throw new Exception("plant with id='"+id+"' is null");
								#endif
								//if (plant!=null) {
								chunk.Plants.Add(plant);
								RegisterPlant(plant.chunkId);
							   // }
							}
						}
						#endregion

						#region Mobs
						{
							int count=*current++;
							for (int i=0; i<count; i++) {
								ushort id=(ushort)((*current++<<8) | *current++);

								switch (id) {
									case (ushort)BlockId.Fish:
										chunk.Mobs.Add(new Fish(/*id,*/ *current++, pos,*current++==1, fishTexture0, fishTexture1));
										break;

									case (ushort)BlockId.Chicken:
										chunk.Mobs.Add(new Chicken(/*id,*/ *current++, pos, *current++==1, chickenWalkTexture, chickenEatTexture));
										break;

									case (ushort)BlockId.Rabbit:
										chunk.Mobs.Add(new Rabbit(/*id,*/*current++, pos, *current++==1, rabbitWalkTexture, rabbitEatTexture, rabbitJumpTexture));
										break;
									
									case (ushort)BlockId.MobParrot:
										{ 
										//	bool fly=;
											if (*current++==1) chunk.Mobs.Add(new Parrot(*current++, pos, *current++==1, new Vector2( ((*current++<<8) | *current++)*16, (*current++)*16),TextureParrotStill, TextureParrotFly));
											else chunk.Mobs.Add(new Parrot(*current++, pos, *current++==1, TextureParrotStill, TextureParrotFly));
										}
										break;
										#if DEBUG
									default:
										throw new Exception("mob is null");
									 //   #else
										// Try repair
										//*current++;
									 //   *current++;
									   // break;
										#endif
								}
							}
						}
						#endregion

						chunk.StartSomething=/*(byte)*/StartSomething;
					}

					float GetFloat() {
						int n=*current++ | (*current++ << 8) | (*current++ << 16) | (*current++ << 24);
						return *(float*)&n;
					}
				}
			}

			foreach (DInt l in labels) {
				SetIndexLabel(l.X,l.Y);
				if (l.Y!=0 && l.Y!=125) RefreshAroundLabels(l.X,l.Y);
			}    
			
			byte[] arrayLO=File.ReadAllBytes(pathToWorld+ world+"LiveObjects.bin");
			fixed (byte* pointer = &arrayLO[0]) {
				byte* current=pointer;

				int totalLO=(*current++) | (*current++<<8) | (*current++<<16);
				LiveObjects=new LiveObject[totalLO];

				for (int i=0; i<totalLO; i++) { 
					switch (*current++) { 
						case (byte)LiveObjectType.Tree:
							{
								Tree tree=new Tree(
								
									// Root
									*current++ | (*current++<<8),
									*current++
								);
								LiveObjects[i]=tree;

								// Total wood
								int countWood=*current++;

								// Add wood
								for (int i2=0; i2<countWood; i2++) {
									ushort x=(ushort)(*current++ | (*current++<<8));
									byte y=*current++;
									if (terrain[x].IsBackground[y]) {                          
										((WoodBlock)terrain[x].Background[y]).tree=tree;

										tree.TitlesWood.Add(new UShortAndByte(x, y));
									}
								}

								// Total leaves
								int countLeaves=*current++;

								// Add leaves
								for (int i2=0; i2<countLeaves; i2++) { 
									ushort x=(ushort)(*current++ | (*current++<<8));
									byte y=*current++;

									if (terrain[x].TopBlocks[y] is LeavesBlock block) {
										block.tree=tree;
										block.SetOrigin();
										
										tree.TitlesLeaves.Add(new UShortAndByte(x, y));
									}
								}
							}
							break;

						case (byte)LiveObjectType.Cactus:
							{
								Cactus cactus=new Cactus(
								
									// Root
									*current++ | (*current++<<8),
									*current++
								);
								LiveObjects[i]=cactus;

								// Total
								int count=*current++;

								// Add
								for (int i2=0; i2<count; i2++) { 
									ushort x=(ushort)(*current++ | (*current++<<8));
									byte y=*current++;
									if (terrain[x].TopBlocks[y] is CactusBlock c){
										c.cactus=cactus;
										c.SetOrigin();

										cactus.Titles.Add(new UShortAndByte(x, y));
									
									}                              
								}
							}
							break;
					}
				}
				LiveObjects=LiveObjects.OrderBy(i => i.Root.X).ToArray();
			}

			if (world=="Earth"){
				if (File.Exists(pathToWorld+world+"Biomes.ter")){
					byte[] arrayBiomes=File.ReadAllBytes(pathToWorld+world+"Biomes.ter");

					fixed (byte* pointer = &arrayBiomes[0]) {
						byte* current=pointer;

						int count=*current++;
						Biomes=new BiomeData[count];
						for (int i = 0; i<count; i++) {
							Biomes[i]=new BiomeData {
								Name=(Biome)(*current++),
								Start=*current++ | (*current++<<8),
								End=*current++ | (*current++<<8),
							}; 
						}
					}
			
				} else { 
					System.Windows.Forms.MessageBox.Show("Biomes file not found","Error");
					throw new Exception("Biomes file not found");
				}
			}else{ 
				switch (world){ 
					case "Moon":	
						Biomes=new BiomeData[]{ new BiomeData{ Name=Biome.Moon, Start=0, End=TerrainLength } };
						break;

					case "Mars":	
						Biomes=new BiomeData[]{ new BiomeData{ Name=Biome.Mars, Start=0, End=TerrainLength} };
						break;

					case "SpaceStation":	
						Biomes=new BiomeData[]{ new BiomeData{ Name=Biome.Mars, Start=0, End=TerrainLength} };
						break;
				}
		
			}
		}

		//void RefreshLightingRemoveSolid(int pos, int y) {
		//	Terrain chunk=terrain[pos];

		//	if (y==chunk.LightPosFull) {

		//		int LightPos=y;
		//		for (; LightPos<125; LightPos++) {
		//			if (chunk.IsSolidBlocks[LightPos]) break;
		//		}

		//	//	chunk.Half=false;
				
		//		if (chunk.LightPosFull!=LightPos) {
					
		//			int StartSomething;
		//			for (StartSomething=0; StartSomething<125; StartSomething++) {
		//				if (chunk.IsTopBlocks[StartSomething]) break;
		//				if (chunk.IsSolidBlocks[StartSomething]) break;
		//				if (chunk.IsBackground[StartSomething]) break;
		//			}

		//			chunk.StartSomething=StartSomething;
										
		//			for (int i=StartSomething; i<125; i++) {
		//				if (chunk.IsTopBlocks[i]) { 
		//					if (GameMethods.IsHalfShadowBlock(chunk.TopBlocks[i].Id)) { 
		//					//	chunk.Half=true;
		//						chunk.LightPosHalf=i;
		//						chunk.LightPosHalf16=i*16;
		//						break;
		//					}
		//				}
					
		//			}
		//		}

		//		chunk.LightPosFull=LightPos;
		//		chunk.LightVec=new Vector2(pos*16-48+8, LightPos*16-48+8+48);
		//		chunk.LightPosFull16=LightPos*16;

		//	}
		//}

		//bool IsHalfShadowBlock(ushort id) { 
		//	switch (id) { 
		//		case (ushort)BlockId.AcaciaLeaves: return true;
		//		case (ushort)BlockId.AppleLeaves: return true;
		//		case (ushort)BlockId.AppleLeavesWithApples: return true;
		//		case (ushort)BlockId.AppleLeavesBlossom: return true;
		//		case (ushort)BlockId.CherryLeaves: return true;
		//		case (ushort)BlockId.CherryLeavesBlossom: return true;
		//		case (ushort)BlockId.CherryLeavesWithCherries: return true;
		//		case (ushort)BlockId.EucalyptusLeaves: return true;
		//		case (ushort)BlockId.KapokLeaves: return true;
		//		case (ushort)BlockId.LemonLeaves: return true;
		//		case (ushort)BlockId.LemonLeavesWithLemons: return true;
		//		case (ushort)BlockId.LindenLeaves: return true;
		//		case (ushort)BlockId.MangroveLeaves: return true;
		//		case (ushort)BlockId.OakLeaves: return true;
		//		case (ushort)BlockId.OliveLeaves: return true;
		//		case (ushort)BlockId.OliveLeavesWithOlives: return true;
		//		case (ushort)BlockId.OrangeLeaves: return true;
		//		case (ushort)BlockId.OrangeLeavesWithOranges: return true;
		//		case (ushort)BlockId.PineLeaves: return true;
		//		case (ushort)BlockId.PlumLeaves: return true;
		//		case (ushort)BlockId.PlumLeavesBlossom: return true;
		//		case (ushort)BlockId.PlumLeavesWithPlums: return true;
		//		case (ushort)BlockId.RubberTreeLeaves: return true;
		//		case (ushort)BlockId.SpruceLeaves: return true;
		//		case (ushort)BlockId.WillowLeaves: return true;
		//	}
		//	return false;
		//}

		//void RefreshLightingAddSolid(int pos, int y) {
		//	Terrain chunk=terrain[pos];

		//	//if (y<chunk.LightPos) {
		//	//	chunk.LightPos=y;
		//	//	chunk.LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);
		//	//	chunk.LightPos16=y*16;
		//	//	if (y<chunk.StartSomething)  chunk.StartSomething=y;
		//	//}
			
		//	if (y<chunk.LightPosFull) {
		//		if (y<chunk.StartSomething) chunk.StartSomething=y;

		//		//if (chunk.Half) { 
		//			if (y<chunk.LightPosHalf) {
		//			//	chunk.Half=false;
		//				chunk.LightPosFull=y;
		//				chunk.LightPosFull16=y*16;
		//				chunk.LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);
		//			} else { 
		//				chunk.LightPosFull=y;
		//				chunk.LightPosFull16=y*16;
		//				chunk.LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);
		//			//	chunk.LightVec128=new Vector2(pos*16-48+8, y*16-48+8+48);
		//			}
		//			chunk.LightPosFull=y;
		//			chunk.LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);
		//			chunk.LightPosFull16=y*16;
		//		//} else { 
		//		//	chunk.LightPosFull=y;
		//		//	chunk.LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);
		//		//	chunk.LightPosFull16=y*16;
		//		//}
				
				
		//	}


		//	//int LightPos;
		//	//for (LightPos=0; LightPos<125; LightPos++) {
		//	//    if (chunk.IsSolidBlocks[LightPos]) break;
		//	//}

		//	//if (chunk.LightPos!=LightPos) {
		//	//    chunk.LightPos=LightPos;
		//	//    chunk.LightVec=new Vector2(pos*16-48+8, LightPos*16-48+8+48);
		//	//    chunk.LightPos16=LightPos*16;

		//	//    int StartSomething;
		//	//    for (StartSomething=0; StartSomething<125; StartSomething++) {
		//	//        if (chunk.IsTopBlocks[StartSomething]) break;
		//	//        if (chunk.IsSolidBlocks[StartSomething]) break;
		//	//        if (chunk.IsBackground[StartSomething]) break;
		//	//    }

		//	//    chunk.StartSomething=StartSomething;
		//	//}
		//}

		//void RefreshLightingAddTop(int pos, int y) {
		//	Terrain chunk=terrain[pos];

		//	if (GameMethods.IsHalfShadowBlock(chunk.TopBlocks[y].Id)) { 
		//		if (y<chunk.LightPosFull) {
		//			if (y<chunk.LightPosHalf) { 
		//				chunk.LightPosHalf=y;
		//				chunk.LightPosHalf16=y*16;
		//			}
		//		}
		//	}

		//	//if (y<chunk.LightPos) {
		//	//	chunk.LightPos=y;
		//	//	chunk.LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);
		//	//	chunk.LightPos16=y*16;
		//	//	if (y<chunk.StartSomething)  chunk.StartSomething=y;
		//	//}
			
		//	//if (y<chunk.LightPosFull) {
		//	//	if (y<chunk.StartSomething) chunk.StartSomething=y;

		//	//	//if (chunk.Half) { 
		//	//		if (y<chunk.LightPosHalf) {
		//	//		//	chunk.Half=false;
		//	//			chunk.LightPosFull=y;
		//	//			chunk.LightPosFull16=y*16;
		//	//			chunk.LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);
		//	//		} else { 
		//	//			chunk.LightPosFull=y;
		//	//			chunk.LightPosFull16=y*16;
		//	//			chunk.LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);
		//	//		//	chunk.LightVec128=new Vector2(pos*16-48+8, y*16-48+8+48);
		//	//		}
		//	//		chunk.LightPosFull=y;
		//	//		chunk.LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);
		//	//		chunk.LightPosFull16=y*16;
		//	//	//} else { 
		//	//	//	chunk.LightPosFull=y;
		//	//	//	chunk.LightVec=new Vector2(pos*16-48+8, y*16-48+8+48);
		//	//	//	chunk.LightPosFull16=y*16;
		//	//	//}
				
				
		//	//}


		//	//int LightPos;
		//	//for (LightPos=0; LightPos<125; LightPos++) {
		//	//    if (chunk.IsSolidBlocks[LightPos]) break;
		//	//}

		//	//if (chunk.LightPos!=LightPos) {
		//	//    chunk.LightPos=LightPos;
		//	//    chunk.LightVec=new Vector2(pos*16-48+8, LightPos*16-48+8+48);
		//	//    chunk.LightPos16=LightPos*16;

		//	//    int StartSomething;
		//	//    for (StartSomething=0; StartSomething<125; StartSomething++) {
		//	//        if (chunk.IsTopBlocks[StartSomething]) break;
		//	//        if (chunk.IsSolidBlocks[StartSomething]) break;
		//	//        if (chunk.IsBackground[StartSomething]) break;
		//	//    }

		//	//    chunk.StartSomething=StartSomething;
		//	//}
		//}
		#endregion

		#region New blocks
		Block BackBlockFromId(ushort type, Vector2 position) {
			switch (type) {
				// Backs
				case (ushort)BlockId.BackDirt: return new NormalBlock(backgroundDirtTexture,type, position);
				case (ushort)BlockId.BackSand: return new NormalBlock(backgroundSandTexture,type, position);
				case (ushort)BlockId.BackCobblestone: return new NormalBlock(backgroundCobblestoneTexture,type, position);
				case (ushort)BlockId.BackClay: return new NormalBlock(backgroundClayTexture, type, position);

				case (ushort)BlockId.BackRedSand: return new NormalBlock(backgroundRedSandTexture, type, position);

				case (ushort)BlockId.BackRegolite: return new NormalBlock(backgroundRegoliteTexture, type, position);
				case (ushort)BlockId.BackGravel: return new NormalBlock(backgroundGravelTexture, type, position);

				case (ushort)BlockId.BackAnorthosite: return new NormalBlock(backgroundAnorthositeTexture, type, position);
				case (ushort)BlockId.BackBasalt: return new NormalBlock(backgroundBasaltTexture, type, position);
				case (ushort)BlockId.BackDiorit: return new NormalBlock(backgroundDioritTexture, type, position);
				case (ushort)BlockId.BackDolomite: return new NormalBlock(backgroundDolomiteTexture, type, position);
				case (ushort)BlockId.BackFlint: return new NormalBlock(backgroundFlintTexture, type, position);
				case (ushort)BlockId.BackGabbro: return new NormalBlock(backgroundGabbroTexture, type, position);
				case (ushort)BlockId.BackGneiss: return new NormalBlock(backgroundGneissTexture, type, position);
				case (ushort)BlockId.BackLimestone: return new NormalBlock(backgroundLimestoneTexture, type, position);
				case (ushort)BlockId.BackMudstone: return new NormalBlock(backgroundMudstoneTexture, type, position);
				case (ushort)BlockId.BackRhyolite: return new NormalBlock(backgroundRhyoliteTexture, type, position);
				case (ushort)BlockId.BackSandstone: return new NormalBlock(backgroundSandstoneTexture, type, position);
				case (ushort)BlockId.BackSchist: return new NormalBlock(backgroundSchistTexture, type, position);

				case (ushort)BlockId.BackCoal: return new NormalBlock(backgroundCoalTexture, type, position);
				case (ushort)BlockId.BackCopper: return new NormalBlock(backgroundCopperTexture, type, position);
				case (ushort)BlockId.BackTin: return new NormalBlock(backgroundTinTexture, type, position);
				case (ushort)BlockId.BackIron: return new NormalBlock(backgroundIronTexture, type, position);
				case (ushort)BlockId.BackAluminium: return new NormalBlock(backgroundAluminiumTexture, type, position);
				case (ushort)BlockId.BackSilver: return new NormalBlock(backgroundSilverTexture, type, position);
				case (ushort)BlockId.BackGold: return new NormalBlock(backgroundGoldTexture, type, position);

				case (ushort)BlockId.BackSulfur: return new NormalBlock(TextureBackSulfurOre, type, position);
				case (ushort)BlockId.BackSaltpeter: return new NormalBlock(TextureBackSaltpeterOre, type, position);

				// Wood
				case (ushort)BlockId.AppleWood: return new WoodBlock{Texture=TextureAppleWood, Id=type, Position=position};
				case (ushort)BlockId.CherryWood: return new WoodBlock{Texture=cherryWoodTexture, Id=type, Position=position};
				case (ushort)BlockId.LemonWood: return new WoodBlock{Texture=TextureLemonWood,Id=type, Position=position};
				case (ushort)BlockId.LindenWood: return new WoodBlock{Texture=TextureLindenWood, Id=type, Position=position};
				case (ushort)BlockId.OakWood: return new WoodBlock{Texture=TextureOakWood, Id=type, Position=position};
				case (ushort)BlockId.OrangeWood: return new WoodBlock{Texture=TextureOrangeWood, Id=type, Position=position};
				case (ushort)BlockId.PineWood: return new WoodBlock{Texture=pineWoodTexture, Id=type, Position=position};
				case (ushort)BlockId.PlumWood: return new WoodBlock{Texture=TexturePlumWood, Id=type, Position=position};
				case (ushort)BlockId.SpruceWood: return new WoodBlock{Texture=spruceWoodTexture, Id=type, Position=position};
				case (ushort)BlockId.WillowWood: return new WoodBlock{Texture=TextureWillowWood, Id=type, Position=position};
				case (ushort)BlockId.MangroveWood: return new WoodBlock{Texture=TextureMangroveWood, Id=type, Position=position};
				case (ushort)BlockId.EucalyptusWood: return new WoodBlock{Texture=TextureEucalyptusWood, Id=type, Position=position};
				case (ushort)BlockId.OliveWood: return new WoodBlock{Texture=TextureOliveWood, Id=type, Position=position};
				case (ushort)BlockId.RubberTreeWood: return new WoodBlock{Texture=TextureRubberTreeWood, Id=type, Position=position};
				case (ushort)BlockId.AcaciaWood: return new WoodBlock{Texture=TextureAcaciaWood, Id=type, Position=position};
				case (ushort)BlockId.KapokWood: return new WoodBlock{Texture=TextureKapokWood, Id=type, Position=position};

				// Artifical
				case (ushort)BlockId.AdvancedSpaceBack: return new NormalBlock(advancedSpaceBackTexture,type, position);
				case (ushort)BlockId.AdvancedSpaceWindow: return new NormalBlock(advancedSpaceWindowTexture, type, position);
				case (ushort)BlockId.Glass: return new NormalBlock(glassTexture, type, position);
				
				case (ushort)BlockId.Coral: return new NormalBlock(coralTexture,type, position);
				case (ushort)BlockId.Seaweed: return new NormalBlock(seaweedTexture,type, position);

				default: return null;
			}
		}

		Block SolidBlockFromId(ushort type, Vector2 position) {
			switch (type) {
				// Stone
				case (ushort)BlockId.StoneBasalt: return new NormalBlock{Texture=basaltTexture, Id=type, Position=position};
				case (ushort)BlockId.StoneDiorit: return new NormalBlock{Texture=dioritTexture, Id=type, Position=position};
				case (ushort)BlockId.StoneDolomite: return new NormalBlock{Texture=dolomiteTexture, Id=type, Position=position};
				case (ushort)BlockId.StoneGabbro: return new NormalBlock{Texture=gabbroTexture, Id=type, Position=position};
				case (ushort)BlockId.StoneGneiss: return new NormalBlock{Texture=gneissTexture, Id=type, Position=position};
				case (ushort)BlockId.StoneLimestone: return new NormalBlock{Texture=limestoneTexture, Id=type, Position=position};
				case (ushort)BlockId.StoneRhyolite: return new NormalBlock{Texture=rhyoliteTexture, Id=type, Position=position};
				case (ushort)BlockId.StoneSandstone: return new NormalBlock{Texture=sandstoneTexture, Id=type, Position=position};
				case (ushort)BlockId.StoneSchist: return new NormalBlock{Texture=schistTexture, Id=type, Position=position};
				case (ushort)BlockId.Anorthosite: return new NormalBlock{Texture=anorthositeTexture, Id=type, Position=position};
				case (ushort)BlockId.MudStone: return new NormalBlock{Texture=mudstoneTexture, Id=type, Position=position};
				case (ushort)BlockId.Regolite: return new NormalBlock{Texture=regoliteTexture, Id=type, Position=position};
				case (ushort)BlockId.RedSand: return new NormalBlock{Texture=TextureRedSand, Id=type, Position=position};

				case (ushort)BlockId.Compost: return new NormalBlock{Texture=CompostTexture, Id=type, Position=position};

				// Ore
				case (ushort)BlockId.OreAluminium: return new NormalBlock{Texture=TextureOreAluminium, Id=type, Position=position};
				case (ushort)BlockId.OreCopper: return new NormalBlock{Texture=TextureOreCopper, Id=type, Position=position};
				case (ushort)BlockId.OreGold: return new NormalBlock{Texture=TextureOreGold, Id=type, Position=position};
				case (ushort)BlockId.OreIron: return new NormalBlock{Texture=TextureOreIron, Id=type, Position=position};
				case (ushort)BlockId.OreSilver: return new NormalBlock{Texture=TextureOreSilver, Id=type, Position=position};
				case (ushort)BlockId.OreTin: return new NormalBlock{Texture=TextureOreTin, Id=type, Position=position};
				case (ushort)BlockId.OreCoal: return new NormalBlock{ Texture=TextureOreCoal, Id=type,Position=position};
				case (ushort)BlockId.OreSulfur: return new NormalBlock{Texture=TextureOreSulfur, Id=type, Position=position};
				case (ushort)BlockId.OreSaltpeter: return new NormalBlock{Texture=TextureOreSaltpeter, Id=type, Position=position};

				// Blocks
				case (ushort)BlockId.Cobblestone: return new NormalBlock{Texture=cobblestoneTexture, Id=type, Position=position};
				case (ushort)BlockId.Gravel: return new NormalBlock{Texture=gravelTexture, Id=type, Position=position};
				case (ushort)BlockId.Sand: return new NormalBlock{Texture=sandTexture, Id=type, Position=position};
				case (ushort)BlockId.Dirt: return new NormalBlock{Texture=TextureDirt, Id=type, Position=position};
				case (ushort)BlockId.Ice: return new NormalBlock{Texture=iceTexture, Id=type, Position=position};
				case (ushort)BlockId.Clay: return new NormalBlock{Texture=clayTexture, Id=type, Position=position};

				// Grass
				case (ushort)BlockId.GrassBlockDesert: return new NormalBlock{Texture=TextureGrassBlockDesert, Id=type,Position=position};
				case (ushort)BlockId.GrassBlockForest: return new NormalBlock{Texture=TextureGrassBlockForest, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockHills: return new NormalBlock{Texture=TextureGrassBlockHills, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockJungle: return new NormalBlock{Texture=TextureGrassBlockJungle, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockPlains: return new NormalBlock{Texture=TextureGrassBlockPlains, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockClay: return new NormalBlock{Texture=TextureGrassBlockClay, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockCompost: return new NormalBlock{Texture=TextureGrassBlockCompost, Id=type, Position=position};
				
				case (ushort)BlockId.GrassBlockSnowDesert: return new NormalBlock{Texture=TextureGrassBlockSnow, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockSnowForest: return new NormalBlock{Texture=TextureGrassBlockSnow, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockSnowHills: return new NormalBlock{Texture=TextureGrassBlockSnow, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockSnowJungle: return new NormalBlock{Texture=TextureGrassBlockSnow, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockSnowPlains: return new NormalBlock{Texture=TextureGrassBlockSnow, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockSnowClay: return new NormalBlock{Texture=TextureGrassBlockSnow, Id=type, Position=position};
				case (ushort)BlockId.GrassBlockSnowCompost: return new NormalBlock{Texture=TextureGrassBlockSnow, Id=type, Position=position};

				// Artifical
				case (ushort)BlockId.Roof1: return new NormalBlock{Texture=roof1Texture,Id=type, Position=position};
				case (ushort)BlockId.Roof2: return new NormalBlock{Texture=roof2Texture,Id=type, Position=position};
				case (ushort)BlockId.Bricks: return new NormalBlock{Texture=bricksTexture,Id=type, Position=position};

				case (ushort)BlockId.DoorClose: return new NormalBlock{Texture=doorCloseTexture,Id=type, Position=position};
				case (ushort)BlockId.Planks: return new NormalBlock{Texture=planksTexture,Id=type, Position=position};

				case (ushort)BlockId.AdvancedSpaceBlock: return new NormalBlock{Texture=advancedSpaceBlockTexture, Id=type, Position=position};
				case (ushort)BlockId.AdvancedSpaceFloor: return new NormalBlock{Texture=advancedSpaceFloorTexture, Id=type, Position=position};
				case (ushort)BlockId.AdvancedSpacePart1: return new NormalBlock{Texture=advancedSpacePart1Texture, Id=type, Position=position};
				case (ushort)BlockId.AdvancedSpacePart2: return new NormalBlock{Texture=advancedSpacePart2Texture, Id=type, Position=position};
				case (ushort)BlockId.AdvancedSpacePart3: return new NormalBlock{Texture=advancedSpacePart3Texture, Id=type, Position=position};
				case (ushort)BlockId.AdvancedSpacePart4: return new NormalBlock{Texture=advancedSpacePart4Texture, Id=type, Position=position};

				case (ushort)BlockId.Snow: return new NormalBlock{Texture=snowTexture, Id=type, Position=position};

				default: return null;
			}
		}

		Block TopBlockFromId(ushort type, Vector2 position) {
			switch (type) {
				case (ushort)BlockId.BucketForRubber: return new NormalBlock(TextureBucketForRubber,type, position);

				// Blocks
				case (ushort)BlockId.Lava: return new NormalBlock(lavaTexture,type, position);

				// Leaves
				case (ushort)BlockId.AppleLeaves: return new LeavesBlock(TextureAppleLeaves,type, position);
				case (ushort)BlockId.AppleLeavesWithApples: return new LeavesBlock(TextureAppleLeavesWithApples,type, position);
				case (ushort)BlockId.AppleBranches: return new LeavesBlock(TextureBranches,type, position);
				case (ushort)BlockId.AppleLeavesBlossom: return new LeavesBlock(TextureBranches,type, position);
				
				case (ushort)BlockId.CherryLeaves: return new LeavesBlock(TextureCherryLeaves,type, position);
				case (ushort)BlockId.CherryLeavesWithCherries: return new LeavesBlock(TextureCherryLeavesWithCherries,type, position);
				case (ushort)BlockId.CherryBranches: return new LeavesBlock(TextureBranches,type, position);
				case (ushort)BlockId.WillowBranches: return new LeavesBlock(TextureBranches,type, position);
				case (ushort)BlockId.CherryLeavesBlossom: return new LeavesBlock(TextureBranches,type, position);
				
				case (ushort)BlockId.PlumLeaves: return new LeavesBlock(TexturePlumLeaves,type, position);
				case (ushort)BlockId.PlumLeavesBlossom: return new LeavesBlock(TextureBranches,type, position);
				case (ushort)BlockId.PlumBranches: return new LeavesBlock(TextureBranches,type, position);
				
				case (ushort)BlockId.OakBranches: return new LeavesBlock(TextureBranches,type, position);
				case (ushort)BlockId.LindenBranches: return new LeavesBlock(TextureBranches,type, position);
				case (ushort)BlockId.LemonLeavesWithLemons: return new LeavesBlock(lemonLeavesWithLemonsTexture,type, position);
				case (ushort)BlockId.LindenLeaves: return new LeavesBlock(TextureLindenLeaves,type, position);
				case (ushort)BlockId.OakLeaves: return new LeavesBlock(TextureOakLeaves, type, position);
				case (ushort)BlockId.OrangeLeaves: return new LeavesBlock(TextureOrangeLeaves,type, position);
				case (ushort)BlockId.SpruceLeaves: return new LeavesBlock(spruceLeavesTexture,type, position);
				case (ushort)BlockId.PlumLeavesWithPlums: return new LeavesBlock(TexturePlumLeavesWithPlums,type, position);
				case (ushort)BlockId.PineLeaves: return new LeavesBlock(pineLeavesTexture,type, position);
				case (ushort)BlockId.OrangeLeavesWithOranges: return new LeavesBlock(TextureOrangeLeavesWithOranges,type, position);
				case (ushort)BlockId.LemonLeaves: return new LeavesBlock(TextureLemonLeaves,type, position);
				case (ushort)BlockId.WillowLeaves: return new LeavesBlock(TextureWillowLeaves,type, position);
				case (ushort)BlockId.MangroveLeaves:return new LeavesBlock(TextureMangroveLeaves,type, position);
				case (ushort)BlockId.EucalyptusLeaves: return new LeavesBlock(TextureEucalyptusLeaves,type, position);
				case (ushort)BlockId.OliveLeavesWithOlives:return new LeavesBlock(TextureOliveLeavesWithOlives,type, position);
				case (ushort)BlockId.OliveLeaves: return new LeavesBlock(TextureOliveLeaves,type, position);
				case (ushort)BlockId.RubberTreeLeaves: return new LeavesBlock(TextureRubberTreeLeaves,type, position);
				case (ushort)BlockId.AcaciaLeaves: return new LeavesBlock(TextureAcaciaLeaves,type, position);
				case (ushort)BlockId.KapokLeacesFlowering: return new LeavesBlock(TextureKapokBlossom,type, position);
				case (ushort)BlockId.KapokLeacesFibre: return new LeavesBlock(TextureKapokLeavesFibre,type, position);
				case (ushort)BlockId.KapokLeaves: return new LeavesBlock(TextureKapokLeaves,type, position);

				case (ushort)BlockId.EggDrop:
					if (easter) return new NormalBlock{Texture=TextureEggDropE[random.Int4()], Id=type, Position=position};
					else return new NormalBlock{Texture=TextureEggDrop, Id=type, Position=position};

				case (ushort)BlockId.WillowSapling: return new NormalBlock{Texture=TextureWillowSapling, Id=type, Position=position};
				case (ushort)BlockId.MangroveSapling: return new NormalBlock{Texture=TextureMangroveSapling, Id=type, Position=position};
				case (ushort)BlockId.EucalyptusSapling:return new NormalBlock{Texture=TextureEucalyptusSapling, Id=type, Position=position};
				case (ushort)BlockId.OliveSapling: return new NormalBlock{Texture=TextureOliveSapling, Id=type, Position=position};
				case (ushort)BlockId.RubberTreeSapling: return new NormalBlock{Texture=TextureRubberTreeSapling, Id=type, Position=position};
				case (ushort)BlockId.AcaciaSapling: return new NormalBlock{Texture=TextureAcaciaSapling, Id=type, Position=position};
				case (ushort)BlockId.KapokSapling: return new NormalBlock{Texture=TextureKapokSapling, Id=type, Position=position};

				// Blocks
				case (ushort)BlockId.SnowTop: return new NormalBlock{Texture=snowTopTexture, Id=type, Position=position };
				case (ushort)BlockId.Glass: return new NormalBlock{Texture=glassTexture, Id=type, Position=position };
				case (ushort)BlockId.ChristmasStar: return new LeavesBlock(TextureChristmasStar, type, position);
				case (ushort)BlockId.Oil: return new NormalBlock{Texture=oilTexture, Id=type, Position=position };
				case (ushort)BlockId.WaterBlock: return new Water(waterTexture,type, position);
				case (ushort)BlockId.WaterSalt: return new Water(waterTexture,type, position);
				case (ushort)BlockId.Rocks: return new NormalBlock{Texture=TextureRocks[random.Int4()], Id=type, Position=position };

				// Saplings
				case (ushort)BlockId.AppleSapling: return new NormalBlock{Texture=TextureAppleSapling, Id=type, Position=position };
				case (ushort)BlockId.CherrySapling: return new NormalBlock{Texture=cherrySaplingTexture, Id=type, Position=position };
				case (ushort)BlockId.LemonSapling: return new NormalBlock{Texture=lemonSaplingTexture, Id=type, Position=position };
				case (ushort)BlockId.LindenSapling: return new NormalBlock{Texture=TextureLindenSapling, Id=type, Position=position };
				case (ushort)BlockId.OakSapling: return new NormalBlock{Texture=oakSaplingTexture, Id=type, Position=position };
				case (ushort)BlockId.OrangeSapling: return new NormalBlock{Texture=orangeSaplingTexture, Id=type, Position=position };
				case (ushort)BlockId.PineSapling: return new NormalBlock{Texture=pineSaplingTexture, Id=type, Position=position };
				case (ushort)BlockId.PlumSapling: return new NormalBlock{Texture=plumSaplingTexture, Id=type, Position=position };
				case (ushort)BlockId.SpruceSapling: return new NormalBlock{Texture=spruceSaplingTexture, Id=type, Position=position};

				// Flowers
				case (ushort)BlockId.Violet: return new NormalBlock{Texture=plantVioletTexture, Id=type, Position=position};
				case (ushort)BlockId.Dandelion: return new NormalBlock{Texture=plantDandelionTexture, Id=type, Position=position};
				case (ushort)BlockId.Heather: return new NormalBlock{Texture=heatherTexture, Id=type, Position=position};
				case (ushort)BlockId.Alore: return new NormalBlock{Texture=plantAloreTexture, Id=type, Position=position};
				case (ushort)BlockId.Rose: return new NormalBlock{Texture=plantRoseTexture, Id=type, Position=position};
				case (ushort)BlockId.Orchid: return new NormalBlock{Texture=plantOrchidTexture, Id=type, Position=position};

				case (ushort)BlockId.CactusBig: return new CactusBlock{Texture=cactusBigTexture, Id=type, Position=position };
				case (ushort)BlockId.CactusSmall: return new CactusBlock{Texture=cactusLittleTexture, Id=type, Position=position };

			   // case (ushort)BlockId.Liana: return new NormalBlock(lianaTexture,type, position);
				case (ushort)BlockId.SugarCane: return new NormalBlock{Texture=sugarCaneTexture, Id=type, Position=position };

				case (ushort)BlockId.Toadstool: return new NormalBlock{Texture=toadstoolTexture, Id=type, Position=position};
				case (ushort)BlockId.Boletus: return new NormalBlock{Texture=boletusTexture, Id=type, Position=position};
				case (ushort)BlockId.Champignon: return new NormalBlock{Texture=champignonTexture, Id=type, Position=position};

				case (ushort)BlockId.BranchALittle1: return new NormalBlock{Texture=branchALittle1Texture, Id=type, Position=position};
				case (ushort)BlockId.BranchALittle2: return new NormalBlock{Texture=branchALittle2Texture, Id=type, Position=position};
				case (ushort)BlockId.BranchFull: return new NormalBlock{Texture=branchFullTexture, Id=type, Position=position};
				case (ushort)BlockId.BranchWithout: return new NormalBlock{Texture=branchWithoutTexture, Id=type, Position=position};

				// Grass
				case (ushort)BlockId.GrassDesert: return new NormalBlock{Texture=grassDesertTexture, Id=type, Position=position};
				case (ushort)BlockId.GrassForest: return new NormalBlock{Texture=grassForestTexture, Id=type, Position=position};
				case (ushort)BlockId.GrassHills: return new NormalBlock{Texture=grassHillsTexture, Id=type, Position=position};
				case (ushort)BlockId.GrassJungle: return new NormalBlock{Texture=grassJungleTexture, Id=type, Position=position};
				case (ushort)BlockId.GrassPlains: return new NormalBlock{Texture=grassPlainsTexture, Id=type, Position=position};

				// Artifical Blocks
				case (ushort)BlockId.DoorOpen: return new NormalBlock{Texture=doorOpenTexture, Id=type, Position=position};

				// Mechanical
				case (ushort)BlockId.Flag: return new AnimatedBlock(flagTexture, position,25,35,type);
				case (ushort)BlockId.Desk: return new NormalBlock{Texture=deskTexture, Id=type, Position=position};
				case (ushort)BlockId.Ladder: return new NormalBlock{Texture=ladderTexture, Id=type, Position=position};
				case (ushort)BlockId.BoxAdv: return new BoxBlock(boxAdvTexture, type, position,InvMaxBoxAdv);
				case (ushort)BlockId.BoxWooden: return new BoxBlock(boxWoodenTexture, type, position,InvMaxBoxWooden);
				case (ushort)BlockId.Shelf: return new ShelfBlock(shelfTexture, type, position, InvMaxShelf);
				case (ushort)BlockId.BurningTorch: return new AnimatedBlock(torchTexture, position,16,16, type);
				case (ushort)BlockId.NotBurningTorch: return new NormalBlock{Texture=torchTexture, Id=type, Position=position};
				case (ushort)BlockId.Barrel: return new Barrel(TextureBarrel, type, position);

				// Electric mashines
				case (ushort)BlockId.Lamp:
					MashineBlockBasic m=new MashineBlockBasic(lampTexture,type, position,0);
					lightsLamp.Add(m);
					return m;

				case (ushort)BlockId.Radio: return new MashineBlockBasic(radioTexture, type, position,0);
				case (ushort)BlockId.Rocket: return new NormalBlock{Texture=rocketTexture, Id=type, Position=position };

				// Generating energy
				case (ushort)BlockId.Windmill: return new AnimatedBlockOffset(windMillTexture, position,26,45,type,-5,-29);
				case (ushort)BlockId.SewingMachine: return new MashineBlockBasic(sewingMachineTexture,type, position,0);
				case (ushort)BlockId.FurnaceStone: return new MashineBlockBasic(furnaceStoneTexture,type, position, InvMaxFurnaceStone);
				case (ushort)BlockId.Miner: return new MashineBlockBasic(minerTexture,type, position, InvMaxMiner);
				case (ushort)BlockId.Macerator: return new MashineBlockBasic(maceratorTexture,type, position, 0);
				case (ushort)BlockId.FurnaceElectric: return new MashineBlockBasic(furnaceElectricTexture,type, position,0);
				case (ushort)BlockId.Charger: return new MashineBlockBasic(chargerTexture,type, position, 1);
				case (ushort)BlockId.OxygenMachine: return new MashineBlockBasic(TextureOxygenMachine,type, position, 1);
				case (ushort)BlockId.Composter: return new ShelfBlock(ComposterTexture,type, position, InvMaxComposter);
				case (ushort)BlockId.SolarPanel: return new NormalBlock{Texture=solarPanelTexture, Id=type, Position=position};
				case (ushort)BlockId.Label: return new ScreenBlock(labelTexture, position,16,16,type);
				case (ushort)BlockId.AngelHair: return new LeavesBlock(TextureAngelHairWithSpruceLeaves, type, position);
				case (ushort)BlockId.ChristmasBall: return new LeavesBlock(TextureChristmasBallGrayWithLeaves, type, position);
				case (ushort)BlockId.ChristmasBallBlue: return new LeavesBlock(TextureChristmasBallBlueWithLeaves, type, position);
				case (ushort)BlockId.ChristmasBallYellow: return new LeavesBlock(TextureChristmasBallYellowWithLeaves, type, position);
				case (ushort)BlockId.ChristmasBallLightGreen: return new LeavesBlock(TextureChristmasBallLightGreenWithLeaves, type, position);
				case (ushort)BlockId.ChristmasBallOrange: return new LeavesBlock(TextureChristmasBallOrangeWithLeaves, type, position);
				case (ushort)BlockId.ChristmasBallRed: return new LeavesBlock(TextureChristmasBallRedWithLeaves, type, position);
				case (ushort)BlockId.ChristmasBallPink: return new LeavesBlock(TextureChristmasBallPinkWithLeaves, type, position);
				case (ushort)BlockId.ChristmasBallPurple: return new LeavesBlock(TextureChristmasBallPurpleWithLeaves, type, position);


				default: return null;
			}
		}

		Plant GetPlantFromId(ushort input, byte height, byte grow, short x) {
			switch (input) {
				case (ushort)BlockId.Wheat: return new Plant(input,height,grow, x, wheatTexture);
				case (ushort)BlockId.Onion: return new Plant(input,height,grow, x, plantOnionTexture);
				case (ushort)BlockId.Peas: return new Plant(input, height, grow, x, plantPeasTexture);
				case (ushort)BlockId.Carrot: return new Plant(input, height, grow, x, plantCarrotTexture);
				case (ushort)BlockId.Flax: return new Plant(input, height, grow, x, flaxTexture);
				case (ushort)BlockId.Strawberry: return new Plant(input,height,grow, x, strawberryPlantTexture);
				case (ushort)BlockId.Rashberry: return new Plant(input,height,grow, x, rashberryPlantTexture);
				case (ushort)BlockId.Blueberry: return new Plant(input,height,grow, x, blueberryPlantTexture);

				default: return null;
			}
		}

		//Mob GetMobFromId(ushort id, byte height, bool dir, int x) {
		//     switch (id) {
		//        case (ushort)BlockId.Fish: return new Fish(id, height, x,dir, fishTexture0, fishTexture1);
		//        case (ushort)BlockId.Chicken: return new Chicken(id, height,x, dir, chickenWalkTexture, chickenEatTexture);
		//        case (ushort)BlockId.Rabbit:  return new Rabbit(id,height, x, dir, rabbitWalkTexture, rabbitEatTexture, rabbitJumpTexture);

		//        default: return null;
		//    }
		//}

		void TerrainSetBackground(int x, int y, ushort id, Texture2D texture) {
			Terrain chunk=terrain[x];

			Block block=new NormalBlock{
				Texture=texture,
				Id=id,
				Position=new Vector2(x*16, y*16)
			};

		  // if (chunk.IsTopBlocks[y]) ((AirSolidBlock)chunk.SolidBlocks[y]).Back=block;
		  //  else chunk.SolidBlocks[y]=new AirSolidBlock{  Back=block };

			chunk.Background[y]=block;
			chunk.IsBackground[y]=true;
		}

		void TerrainSetTopBlockNormal(int x, int y, ushort id, Texture2D texture) {
			Block block=new NormalBlock{
				Texture=texture,
				Id=id,
				Position=new Vector2(x*16, y*16)
			};

			Terrain chunk=terrain[x];
		   // if (chunk.IsBackground[y]) ((AirSolidBlock)chunk.SolidBlocks[y]).Top=block;
		   // else chunk.SolidBlocks[y]=new AirSolidBlock{  Top=block };

			chunk.TopBlocks[y]=block;
			chunk.IsTopBlocks[y]=true;
		}
		#endregion

		#region Plants
		void RemovePlant(int x) {
			if (terrain[x].Plants.Count==0) chunksWithPlants.Remove(x);
		}

		void RegisterPlant(int x) {
			bool isNotSomething=false;

			foreach (int i in chunksWithPlants) {
				if (i==x) {
					isNotSomething=true;
					break;
				}
			}

			if (isNotSomething) chunksWithPlants.Add(x);
		}

		void GrowTreeFood(int reg) {
			int id=random.Int(100-1)+1+reg, i=random.Int(124)+1;
			Terrain chunk=terrain[id];

			if (chunk.IsTopBlocks[i]) {
				Block[] blocks=chunk.TopBlocks;

			 //   Block block=blocks[i];

				switch (blocks[i].Id) {
					case (ushort)BlockId.AppleLeaves:
						blocks[i].Id=(ushort)BlockId.AppleLeavesWithApples;
						((LeavesBlock)blocks[i]).Texture=TextureAppleLeavesWithApples;
						return;

					case (ushort)BlockId.AppleLeavesWithApples:
						blocks[i].Id=(ushort)BlockId.AppleLeaves;
						((LeavesBlock)blocks[i]).Texture=TextureAppleLeaves;
						return;

					case (ushort)BlockId.PlumLeaves:
						blocks[i].Id=(ushort)BlockId.PlumLeavesWithPlums;
						((LeavesBlock)blocks[i]).Texture=TexturePlumLeavesWithPlums;
						return;

					case (ushort)BlockId.PlumLeavesWithPlums:
						blocks[i].Id=(ushort)BlockId.PlumLeaves;
						((LeavesBlock)blocks[i]).Texture=TexturePlumLeaves;
						return;

					case (ushort)BlockId.LemonLeaves:
						blocks[i].Id=(ushort)BlockId.LemonLeavesWithLemons;
						((LeavesBlock)blocks[i]).Texture=lemonLeavesWithLemonsTexture;
						return;

					case (ushort)BlockId.LemonLeavesWithLemons:
						blocks[i].Id=(ushort)BlockId.LemonLeaves;
						((LeavesBlock)blocks[i]).Texture=TextureLemonLeaves;
						return;

					case (ushort)BlockId.OrangeLeaves:
						blocks[i].Id=(ushort)BlockId.OrangeLeavesWithOranges;
						((LeavesBlock)blocks[i]).Texture=TextureOrangeLeavesWithOranges;
						return;

					case (ushort)BlockId.OrangeLeavesWithOranges:
						blocks[i].Id=(ushort)BlockId.OrangeLeaves;
						((LeavesBlock)blocks[i]).Texture=TextureOrangeLeaves;
						return;

					case (ushort)BlockId.CherryLeaves:
						blocks[i].Id=(ushort)BlockId.CherryLeavesWithCherries;
						((LeavesBlock)blocks[i]).Texture=TextureCherryLeavesWithCherries;
						return;

					case (ushort)BlockId.CherryLeavesWithCherries:
						blocks[i].Id=(ushort)BlockId.CherryLeaves;
						((LeavesBlock)blocks[i]).Texture=TextureCherryLeaves;
						return;

					case (ushort)BlockId.OliveLeaves:
						blocks[i].Id=(ushort)BlockId.OliveLeavesWithOlives;
						((LeavesBlock)blocks[i]).Texture=TextureOliveLeavesWithOlives;
						return;

					case (ushort)BlockId.OliveLeavesWithOlives:
						blocks[i].Id=(ushort)BlockId.OliveLeaves;
						((LeavesBlock)blocks[i]).Texture=TextureOliveLeaves;
						return;

					case (ushort)BlockId.KapokLeaves:
						blocks[i].Id=(ushort)BlockId.KapokLeacesFibre;
						((LeavesBlock)blocks[i]).Texture=TextureKapokLeavesFibre;
						return;

					case (ushort)BlockId.KapokLeacesFibre:
						blocks[i].Id=(ushort)BlockId.KapokLeaves;
						((LeavesBlock)blocks[i]).Texture=TextureKapokLeaves;
						return;

					case (ushort)BlockId.AppleSapling:
						if (i-6<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeApple(id,i+1);
						return;

					case (ushort)BlockId.CherrySapling:
						if (i-7<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeCherry(id,i+1);
						return;

					case (ushort)BlockId.PlumSapling:
						if (i-7<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreePlum(id,i+1);
						return;

					case (ushort)BlockId.LemonSapling:
						if (i-6<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeLemon(id,i+1);
						return;

					case (ushort)BlockId.PineSapling:
						if (i-10<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreePine(id,i+1);
						return;

					case (ushort)BlockId.LindenSapling:
						if (i-10<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeLinden(id,i+1);
						return;

					case (ushort)BlockId.OrangeSapling:
						if (i-9<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeOrange(id,i+1);
						return;

					case (ushort)BlockId.SpruceSapling:
						if (i-10<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						if (random.Bool())TreeSpruceLittle(id,i+1);
						else TreeSpruceBig(id,i+1);
						return;

					case (ushort)BlockId.WillowSapling:
						if (i-10<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeWillow(id,i+1);
						return;

					case (ushort)BlockId.RubberTreeSapling:
						if (i-10<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeRubber(id,i+1);
						return;

					case (ushort)BlockId.EucalyptusSapling:
						if (i-10<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeEucalyptus(id,i+1);
						return;

					case (ushort)BlockId.AcaciaSapling:
						if (i-10<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeAcacia(id,i+1);
						return;

					case (ushort)BlockId.OliveSapling:
						if (i-10<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeOlive(id,i+1);
						return;

					case (ushort)BlockId.MangroveSapling:
						if (i-10<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeMangrove(id,i+1);
						return;

					case (ushort)BlockId.KapokSapling:
						if (i-10<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						TreeKapok(id,i+1);
						return;

					case (ushort)BlockId.OakSapling:
						if (i-9<0)return;
						blocks[i]=null;
						chunk.IsTopBlocks[i]=false;
						if (random.Bool()) {
							TreeOakLittle(id,i+1);
						} else {
							TreeOakMedium(id,i+1);
						}
						return;
				}
			} else if (random.Int(10000)==1) {
			//	Terrain chunk=terrain[id];
				if (chunk.IsSolidBlocks[i]) {
					switch (chunk.SolidBlocks[i].Id) {
						case (ushort)BlockId.Compost:
							chunk.SolidBlocks[i].Id=(ushort)BlockId.Dirt;
							((NormalBlock)chunk.SolidBlocks[i]).Texture=TextureDirt;
							return;

						case (ushort)BlockId.Dirt:
							if (!chunk.IsSolidBlocks[i-1]) {
								int r=random.Bool() ? 1 : -1;
								if (terrain[id+r].IsSolidBlocks[i]) {
									switch (terrain[id+r].SolidBlocks[i].Id) {
										case (ushort)BlockId.GrassBlockDesert:
											chunk.SolidBlocks[i].Id=(ushort)BlockId.GrassBlockDesert;
											((NormalBlock)chunk.SolidBlocks[i]).Texture=TextureGrassBlockDesert;
											return;

										case (ushort)BlockId.GrassBlockForest:
											chunk.SolidBlocks[i].Id=(ushort)BlockId.GrassBlockForest;
											((NormalBlock)chunk.SolidBlocks[i]).Texture=TextureGrassBlockForest;
											return;

										case (ushort)BlockId.GrassBlockHills:
											chunk.SolidBlocks[i].Id=(ushort)BlockId.GrassBlockHills;
											((NormalBlock)chunk.SolidBlocks[i]).Texture=TextureGrassBlockHills;
											return;

										case (ushort)BlockId.GrassBlockJungle:
											chunk.SolidBlocks[i].Id=(ushort)BlockId.GrassBlockJungle;
											((NormalBlock)chunk.SolidBlocks[i]).Texture=TextureGrassBlockJungle;
											return;

										case (ushort)BlockId.GrassBlockPlains:
											chunk.SolidBlocks[i].Id=(ushort)BlockId.GrassBlockPlains;
											((NormalBlock)chunk.SolidBlocks[i]).Texture=TextureGrassBlockPlains;
											return;
									}
								}
							}
							return;

						case (ushort)BlockId.Clay:
							if (!chunk.IsSolidBlocks[i-1]) {
								int r=random.Bool() ? 1 : -1;
								if (terrain[id+r].IsSolidBlocks[i]) {
									if (terrain[id+r].SolidBlocks[i].Id==(ushort)BlockId.GrassBlockClay) {
										chunk.SolidBlocks[i].Id=(ushort)BlockId.GrassBlockClay;
										((NormalBlock)chunk.SolidBlocks[i]).Texture=TextureGrassBlockClay;
										return;
									}
								}
							}
							return;

					}
				}
			}
		}
		#endregion

		#region Player
		bool CheckLadder() {
			int yFrom=(int)PlayerY/16,
				yTo=((int)PlayerY+39/2+16)/16,
				xFrom=((int)PlayerX-16)/16,
				xTo=((int)PlayerX+22)/16;

			if (yFrom<0)yFrom=0;
			if (yTo>124)yTo=124;

			if (xFrom<0)xFrom=0;
			if (xTo>=TerrainLength)xTo=TerrainLength;

			for (int x=xFrom; x<xTo; x++) {
				Terrain chunk=terrain[x];

				for (int y=yFrom; y<yTo; y++) {
					if (chunk.IsTopBlocks[y]) {
						if (chunk.TopBlocks[y].Id==(ushort)BlockId.Ladder) return true;
					}
				}
			}
			return false;
		}

		bool CheckWater() {
			for (int x=((int)PlayerX-16)/16; x<((int)PlayerX+22)/16; x++) {
				Terrain chunk=terrain[x];

				for (int y=((int)PlayerY)/16; y<((int)PlayerY+39/2+16)/16; y++) {
					if (y>0 && y<125 && x>0 && x<TerrainLength) {
						if (chunk.IsTopBlocks[y]) {
							if (chunk.TopBlocks[y].Id==(ushort)BlockId.WaterBlock) {
								if (((Water)chunk.TopBlocks[y]).GetMass>1) return true;
							}
							if (chunk.TopBlocks[y].Id==(ushort)BlockId.WaterSalt) {
								if (((Water)chunk.TopBlocks[y]).GetMass>1) return true;
							}
						}
					}
				}
			}
			return false;
		}

		bool CheckWaterDown() {//!!! walking on waves
			for (int x=((int)PlayerX-16)/16; x<((int)PlayerX+22)/16; x++) {
				Terrain chunk=terrain[x];

				for (int y=((int)PlayerY+39/2+16-1)/16; y<((int)PlayerY+39/2+16+16+1)/16; y++) {
					if (y>0 && y<125 && x>0 && x<TerrainLength) {
						if (chunk/*terrain[x]*/.IsTopBlocks[y]) {
							if (chunk/*terrain[x]*/.TopBlocks[y].Id==(ushort)BlockId.WaterBlock) return true;
							if (chunk/*terrain[x]*/.TopBlocks[y].Id==(ushort)BlockId.WaterSalt) return true;
						}
					}
				}
			}
			return false;
		}

		bool CheckWaterUp() {// player is Swimming on waves
			for (int x=((int)PlayerX-16)/16; x<((int)PlayerX+22)/16; x++) {
				Terrain chunk=terrain[x];
				for (int y=((int)PlayerY)/16; y<((int)PlayerY+39/2)/16; y++) {
					if (y>0 && y<125 && x>0 && x<TerrainLength) {
						if (/*terrain[x]*/chunk.IsTopBlocks[y]) {
							if (/*terrain[x]*/chunk.TopBlocks[y].Id==(ushort)BlockId.WaterBlock) return true;
							if (/*terrain[x]*/chunk.TopBlocks[y].Id==(ushort)BlockId.WaterSalt) return true;
						}
					}
				}
			}
			return false;
		}

		bool CheckLava() {
			int Yfrom=(int)PlayerY/16,
				Yto=((int)PlayerY+39/2+16)/16,
				Xfrom=((int)PlayerX-16)/16,
				Xto=((int)PlayerX+22)/16;

			if (Yfrom<0)Yfrom=0;
			if (Yto>124)Yto=124;

			if (Xfrom<0)Xfrom=0;
			if (Xfrom>=TerrainLength)Xfrom=TerrainLength-1;

			for (int x=Xfrom; x<Xto; x++) {
				Terrain chunk=terrain[x];

				for (int y=Yfrom; y<Yto; y++) {
					if (chunk.IsTopBlocks[y]) {
						if (chunk.TopBlocks[y].Id==(ushort)BlockId.Lava) return true;
					}
				}
			}
			return false;
		}

		void PlayerGravity() {
			List<DInt> blocks=new List<DInt>(); 

			distanceToGround=100000;

			int Yfrom=((int)PlayerY+20-16)/16,
				Yto=((int)PlayerY+20-16)/16+6,
				Xfrom=((int)PlayerX-11)/16,
				Xto=((int)PlayerX+11+16)/16;

			if (Yfrom<0)Yfrom=0;
			if (Yto>124)Yto=124;

			for (int x = Xfrom; x<Xto; x++) {
				Terrain chunk=terrain[x];
			  //  if (chunk!=null) {
					for (int y = Yfrom; y<Yto; y++) {
						if (chunk.IsSolidBlocks[y]) {
							if (y*16-PlayerY-20<distanceToGround) {
							distanceToGround=y*16-(int)PlayerY-20; 
							blocks.Add(new DInt(x,y));
							
							//Block block=chunk.SolidBlocks[y];
							//    if (block is NormalBlock b) { 
							//        Texture2D tex=b.Texture;
							//        Particles.Add(new Particle{ 
							//            Disepeard=200,
							//            Texture=tex,
							//            Position=new Vector2(x*16,y*16-16),
							//            Source=new Rectangle(0,0,2,2)
							//        });
							//    }
						}
						}
					}
				//}
			}

			if (gravitySpeed<0) {
				int yy = ((int)PlayerY-20-4)/16;
				if (yy>=0) {
					for (int xx = ((int)PlayerX-11)/16; xx<(PlayerX+11+16)/16; xx++) {
						Terrain chunk=terrain[xx];
						if (chunk!=null) {
							if (chunk.IsSolidBlocks[yy]) {
								gravitySpeed=0;
								blocks.Add(new DInt(xx,yy));
								break;
							}
						}
					}
				}
			}

			if (distanceToGround==0) {
				gravitySpeed=0;
				return;
			}

			if (distanceToGround<=6 && gravitySpeed>0) {
				PlayerY+=distanceToGround;
				changePosition=true;


				gravitySpeed=0;

				if (Constants.AnimationsGame) CreateJumpMess(blocks);
			} else {
				if (swimming) {
					gravitySpeed+=gravity/5f;
					if (gravitySpeed>1)gravitySpeed=1;
					PlayerY+=(int)gravitySpeed;
					changePosition=true;
				} else {
					gravitySpeed+=gravity;
					if (gravitySpeed>6)gravitySpeed=6;
					PlayerY+=(int)gravitySpeed;
					changePosition=true;
				}
			}
		}

		void CameraMatrix() {
			if (Setting.Scale.Without==Setting.currentScale) {
			//	camera=Matrix.CreateTranslation(new Vector3(-((int)(WindowCenterX*Setting.Zoom+0.5f))/Setting.Zoom, -((int)(WindowCenterY*Setting.Zoom+0.5f))/Setting.Zoom, 0)) * Translation;
	
				camera=Matrix.CreateTranslation(
					new Vector3(
					-(((int)(WindowCenterX*Setting.Zoom+0.5f))/Setting.Zoom),
					-(((int)(WindowCenterY*Setting.Zoom+0.5f))/Setting.Zoom),
					//	-/*(int)(*/WindowCenterX/*+0.5f)*//*+*/,
					//	-/*(int)(*/WindowCenterY/*+0.5f)*//*+((int)((WindowCenterY-(int)WindowCenterY)*Setting.Zoom)/Setting.Zoom)*/,
						0
					)
				) * Translation;
				return;
			}

			if (Setting.Scale.Proportions==Setting.currentScale) {
				float
					_screenScaleW = Global.WindowWidth/848f,
					_screenScaleH = Global.WindowHeight/560f;

				if (_screenScaleH > _screenScaleW) {
					camera=Matrix.CreateTranslation(new Vector3(-WindowCenterX, -WindowCenterY, 0))*
						Matrix.CreateScale(_screenScaleW, _screenScaleW, 0)* Translation;
						return;
				} else {
					camera=Matrix.CreateTranslation(new Vector3(-WindowCenterX, -WindowCenterY, 0))*
						Matrix.CreateScale(_screenScaleH, _screenScaleH, 0)* Translation;
						return;
				}
			}

			camera=Matrix.CreateTranslation(new Vector3(-WindowCenterX, -WindowCenterY, 0))*
				Matrix.CreateScale(new Vector3(Global.WindowWidth/848f, Global.WindowHeight/560f, 0))* Translation;
		}

		Matrix CameraMatrixNoZoom(out int xx, out int yy) {
		//	if (Setting.Scale.Without==Setting.currentScale) {
			float z;
			if (Setting.Zoom<2.5)z=1;
			else z=2;

			xx=((int)(WindowCenterX+0.5f))-(int)(Global.WindowWidthHalf*z);
			yy=((int)(WindowCenterY+0.5f))-(int)(Global.WindowHeightHalf*z);

			weatherWindowWidth=(int)(Global.WindowWidth*z);
			weatherWindowHeight=(int)(Global.WindowHeight*z);

			return Matrix.CreateTranslation(new Vector3(-((int)(WindowCenterX+0.5f)), -((int)(WindowCenterY+0.5f)), 0)) *  Matrix.CreateScale(z, z, 0)*Matrix.CreateTranslation(new Vector3(Global.WindowWidthHalf, Global.WindowHeightHalf, 0));
			//}

			//if (Setting.Scale.Proportions==Setting.currentScale) {
			//	float
			//		_screenScaleW = Global.WindowWidth/848f,
			//		_screenScaleH = Global.WindowHeight/560f;

			//	if (_screenScaleH > _screenScaleW) {
			//		camera=Matrix.CreateTranslation(new Vector3(-WindowCenterX, -WindowCenterY, 0))*
			//			Matrix.CreateScale(_screenScaleW, _screenScaleW, 0)* Translation;
			//			return;
			//	} else {
			//		camera=Matrix.CreateTranslation(new Vector3(-WindowCenterX, -WindowCenterY, 0))*
			//			Matrix.CreateScale(_screenScaleH, _screenScaleH, 0)* Translation;
			//			return;
			//	}
			//}

			//camera=Matrix.CreateTranslation(new Vector3(-WindowCenterX, -WindowCenterY, 0))*
			//	Matrix.CreateScale(new Vector3(Global.WindowWidth/848f, Global.WindowHeight/560f, 0))* Translation;
		}

		void SetPlayerPos(float x, float y) {
			PlayerX=x;
			PlayerY=y;

			WindowXPlayer = PlayerX-1;
			WindowYPlayer =PlayerY-1;

			WindowX=(int)x-Global.WindowWidthHalf;
			WindowY=(int)y-Global.WindowHeightHalf;

			WindowCenterX =(int)WindowXPlayer-Global.WindowWidthHalf;
			WindowCenterY =(int)WindowYPlayer-Global.WindowHeightHalf;

			changePosition=true;
		}
		#endregion

		#region Inventory
		void SetUpInvToNew() {
			Resize();
			if (lastMashineType!=inventory) {
				switch (inventory) {
					case InventoryType.BasicInv:
						SetInvCraftingBlocks();
						break;

					case InventoryType.Desk:
						SetInvCraftingBlocksA();
						break;

					case InventoryType.FurnaceStone:
						SetInvBakeIngots();
						break;

					case InventoryType.FurnaceElectric:
						SetInvBakeIngots();
						break;

					case InventoryType.Macerator:
						SetInvToDustDusts();
						break;

					case InventoryType.SewingMachine:
						SetInvClothesHead();
						break;
				}
			}
			CurrentDeskCrafting=null;

			SelectedCraftingRecipe=-1;
			lastMashineType=inventory;
		}

		void InventoryRemoveSelectedItem() {
			ItemInv i=InventoryNormal[boxSelected];
			switch (i) {
				case ItemInvTool32 s:
				   // s.SetCount=s.GetCount-1;
					if (s.GetCount==1) {
						InventoryNormal[boxSelected]=itemBlank;
					} else {
						s.SetCount=s.GetCount-1;
					}
					break;

				case ItemInvTool16 s:
					if (s.GetCount==1) {
						InventoryNormal[boxSelected]=itemBlank;
					} else {
						s.SetCount=s.GetCount-1;
					}
					break;

				case ItemInvBasic16 s:
					if (s.GetCount==1) {
						InventoryNormal[boxSelected]=itemBlank;
					} else {
						s.SetCount=s.GetCount-1;
					}
					break;

				case ItemInvBasic32 s:
					if (s.GetCount==1) {
						InventoryNormal[boxSelected]=itemBlank;
					} else {
						s.SetCount=s.GetCount-1;
					}
					break;

				//case ItemInvBasicColoritzed32NonStackable s:
				//    InventoryNormal[boxSelected]=itemBlank;
				//    break;

				//case ItemInvNonStackable16 s:
				//    InventoryNormal[boxSelected]=itemBlank;
				//    break;

				//case ItemInvNonStackable32 s:
				//    InventoryNormal[boxSelected]=itemBlank;
				//    break;

				case ItemInvFood16 s:
					if (s.GetCount==1) {
						InventoryNormal[boxSelected]=itemBlank;
					} else {
						s.SetCount=s.GetCount-1;
					}
					break;

				default:
					InventoryNormal[boxSelected]=itemBlank;
					break;

			}
		}

		void StartItemMove(ItemInv[] inv, int id) {
			Debug.WriteLine("StartItemMove");
			if (inv[id].Id!=0) {
				invMove = true;
				startMovePos=inv[id].GetPos();
				mouseItem=inv[id];
				inv[id]=itemBlank;
				invStartId=id;
				invStartInventory=inv;
				showMouseItemWhileMooving=true;
				mouseDrawItemTextInfo=false;

				//Console.WriteLine("start: "+id);
			}
		}

		void StartItemMoveHalf(ItemInv[] inv, int id) {
			Debug.WriteLine("StartItemMoveHalf");
			if (id!=0) {
				invMove = true;
				invStartId=id;
				invStartInventory=inv;

				startMovePos=inv[id].GetPos();

				showMouseItemWhileMooving=true;
				mouseDrawItemTextInfo=false;

				switch (inv[id]) {
					case ItemInvBasic16 i:
						{
							int c=i.GetCount;
							if (c==1) {
								mouseItem=new ItemInvBasic16(i.Texture, i.Id, 1, mouseRealPosX, mouseRealPosY);
								inv[id]=itemBlank;
							} else {
								int stay=c/2;
								DInt z=GetPosOfItemInInventories(inv,id);
								inv[id]=new ItemInvBasic16(i.Texture, i.Id, stay, z.X, z.Y);
								mouseItem=new ItemInvBasic16(i.Texture, i.Id, c-stay, mouseRealPosX, mouseRealPosY);
							}
						}
						return;

					case ItemInvBasic32 i:
						{
							int c=i.GetCount;
							if (c==1) {
								mouseItem=new ItemInvBasic32(i.Texture, i.Id, 1, mouseRealPosX, mouseRealPosY);
								inv[id]=itemBlank;
							} else {
								int stay=c/2;
							((ItemInvBasic32)inv[id]).SetCount=stay;
							//	inv[id]=new ItemInvBasic32(i.Texture, i.Id, stay, mouseRealPosX, mouseRealPosY);
								mouseItem=new ItemInvBasic32(i.Texture, i.Id, c-stay, mouseRealPosX, mouseRealPosY);
							}
						}
						return;

					case ItemInvFood16 i:
						{
							int c=i.GetCount;
							if (c==1) {
								mouseItem=new ItemInvFood16(i.Texture, i.Id, 1, i.CountMaximum, i.GetDescay, i.DescayMaximum, mouseRealPosX, mouseRealPosY);
								inv[id]=itemBlank;
							} else {
								int stay=c/2;
								inv[id]=new ItemInvFood16(i.Texture, i.Id, stay, i.CountMaximum, i.GetDescay, i.DescayMaximum,  mouseRealPosX, mouseRealPosY);
								mouseItem=new ItemInvFood16(i.Texture, i.Id, c-stay, i.CountMaximum, i.GetDescay, i.DescayMaximum, mouseRealPosX, mouseRealPosY);
							}
						}
						return;

					case ItemInvTool16 i:
						{
							mouseItem=new ItemInvTool16(i.Texture, i.Id, 1, i.Maximum, mouseRealPosX, mouseRealPosY);
							inv[id]=itemBlank;
						}
						return;

					case ItemInvTool32 i:
						{
							mouseItem=new ItemInvTool32(i.Texture, i.Id, 1, i.Maximum, mouseRealPosX, mouseRealPosY);
							inv[id]=itemBlank;
						}
						return;

					case ItemInvNonStackable16 i:
						{
							mouseItem=new ItemInvNonStackable16(i.Texture, i.Id, mouseRealPosX, mouseRealPosY);
							inv[id]=itemBlank;
						}
						return;

					case ItemInvNonStackable32 i:
						{
							mouseItem=new ItemInvNonStackable32(i.Texture, i.Id, mouseRealPosX, mouseRealPosY);
							inv[id]=itemBlank;
						}
						return;

					case ItemInvBasicColoritzed32NonStackable i:
						{
							mouseItem=new ItemInvBasicColoritzed32NonStackable(i.Texture, i.Id, i.color, mouseRealPosX, mouseRealPosY);
							inv[id]=itemBlank;
						}
						return;
				}
			}
		}

		DInt GetPosOfItemInInventories(ItemInv[] inv, int i) {
			if (IsSameArray(inv, InventoryNormal)) {
				DInt p=InventoryGetPosNormal(i);
				if (p!=null) return p;
			}
			if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
				if (IsSameArray(inv, InventoryClothes)) {
					DInt p=InventoryGetPosClothes(i);
					if (p!=null) return p;
				}
			}
			if (inventory==InventoryType.BoxWooden) {
				if (IsSameArray(inv, ((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
					DInt p=InventoryGetPosBoxWooden(i);
					if (p!=null) return p;
				}
			}
			if (inventory==InventoryType.BoxAdv) {
				if (IsSameArray(inv, ((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
					DInt p=InventoryGetPosAdvBox(i);
					if (p!=null) return p;
				}
			}
			if (inventory==InventoryType.Miner) {
				if (IsSameArray(inv, ((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
					DInt p=InventoryGetPosBoxWooden(i);
					if (p!=null) return p;
				}
			}
			if (inventory==InventoryType.Shelf || inventory==InventoryType.Composter) {
				if (IsSameArray(inv, ((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
					DInt p=InventoryGetPosShelf(i);
					if (p!=null) return p;
				}
			}
			if (inventory==InventoryType.Charger || inventory==InventoryType.OxygenMachine) {
				if (IsSameArray(inv, ((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
					return new DInt{ X=Global.WindowWidthHalf-300+38+40+4, Y=Global.WindowHeightHalf+20-2+40+25+4 };
				}
			}
			if (inventory==InventoryType.Barrel) {
				if (IsSameArray(inv, ((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
					DInt p=InventoryGetPosBarrel(i);
					if (p!=null) return p;
				}
			}
			#if DEBUG
			throw new Exception("Unknown move to position");
			#else
			return null;
			#endif
		}

		void InvMove(ItemInv[] toA, int toI) {
			Debug.WriteLine("InvMove");
			showMouseItemWhileMooving=false;
			mouseDrawItemTextInfo=true;
			invMove=false;
			//Console.WriteLine("dest: "+toI);
			if (mouseItem.Id==toA[toI].Id) {
				switch (mouseItem) {
					case ItemInvBasic16 f:
						{
							ItemInvBasic16 t=(ItemInvBasic16)toA[toI];
							int total=f.GetCount+t.GetCount;
							if (total>100) {
								t.SetCount=99;
								f.SetCount=total-99;
								invStartInventory[invStartId]=mouseItem;
							} else {
								t.SetCount=total;
							}
						}
						return;

					case ItemInvBasic32 f:
						{
							ItemInvBasic32 t=(ItemInvBasic32)toA[toI];
							int total=f.GetCount+t.GetCount;

							if (total>100) {
								t.SetCount=99;
								f.SetCount=total-99;
								invStartInventory[invStartId]=mouseItem;
							} else {
								t.SetCount=total;
							}
						}
						return;

					case ItemInvFood16 f:
						{
							ItemInvFood16 t=(ItemInvFood16)toA[toI];
							int max=f.CountMaximum;
							int total=f.GetCount+t.GetCount;

							if (total>max) {
								t.SetCount=max;
								f.SetCount=total-max;
								invStartInventory[invStartId]=mouseItem;
							} else {
								t.SetCount=total;
							}
						}
						return;

					//case ItemInvNonStackable16 f:
					//    {
					//        ItemInv t=toA[toI];
					//        toA[toI]=mouseItem;
					//        invStartInventory[invStartId]=t;
					//    }
					//    return;

					//case ItemInvNonStackable32 f:
					//    {
					//        ItemInv t=toA[toI];
					//        toA[toI]=mouseItem;
					//        invStartInventory[invStartId]=t;
					//    }
					//    return;

					//case ItemInvBasicColoritzed32NonStackable f:
					//    {
					//        ItemInv t=toA[toI];
					//        toA[toI]=mouseItem;
					//        invStartInventory[invStartId]=t;
					//    }
					//    return;

					//case ItemInvTool32 f:
					//    {
					//        ItemInv t=toA[toI];
					//        toA[toI]=mouseItem;
					//        invStartInventory[invStartId]=t;
					//    }
					//    return;
					
					default:
						{
							ItemInv t=toA[toI];
							toA[toI]=mouseItem;
							invStartInventory[invStartId]=t;
						}
						return;
				}
			} else {
				if (toA[toI].Id==0) {

					//invStartInventory[invStartId]=itemBlank;
					//DInt p=new DInt(int.MinValue,int.MinValue);
					//if (toA==InventoryNormal) {
					//    p=InventoryGetPosNormal(toI);
					//}
					//if (inventory==InventoryType.BasicInv) {
					//    if (toA==InventoryClothes) {
					//        p=InventoryGetPosClothes(toI);
					//    }
					//}
					//if (inventory==InventoryType.BoxWooden) {
					//    p=InventoryGetPosBoxWooden();
					//}
					//if (inventory==InventoryType.BoxAdv) {
					//    p=InventoryGetPosAdvBox();
					//}
					//#if DEBUG
					//if (p.X==int.MinValue) throw new Exception("Unknown move to position");
					//#endif
					DInt p=GetPosOfItemInInventories(toA,toI);
					toA[toI]=mouseItem;
					toA[toI].SetPos(p.X, p.Y);
					mouseItem=itemBlank;
					return;
				} else {
					ItemInv t=toA[toI];
					DInt destinationPos=t.GetPos();
				  //  Vector2 sourcePos=invStartInventory[invStartId].GetPosVector2();

					toA[toI]=mouseItem;
					mouseItem.SetPos(destinationPos.X, destinationPos.Y);
					invStartInventory[invStartId]=t;
					t.SetPos(startMovePos.X, startMovePos.Y);
				  //  DInt p=null;
				  ////  if (invStartInventory==InventoryNormal) {
				  //      p=InventoryGetPosNormal(invStartId);
				  // // }
				  //  if (inventory==InventoryType.BasicInv) {
				  //      if (toA==InventoryClothes) {
				  //          p=InventoryGetPosClothes(toI);
				  //      }
				  //  }
				  //  if (inventory==InventoryType.BoxWooden) {
				  //      p=InventoryGetPosBoxWooden();
				  //  }
				  //  if (inventory==InventoryType.BoxAdv) {
				  //      p=InventoryGetPosAdvBox();
				  //  }
				  //  #if DEBUG
				  //  if (p==null) throw new Exception("Unknown move to position");
				  //  #endif
				   // DInt p=GetPosOfItemInInventories(toA,toI);
					mouseItem=itemBlank;
					return;
				}
			}
		}

		void InvMoveOne(ItemInv[] toA, int toI) {
			Debug.WriteLine("InvMoveOne");
			if (mouseItem.Id==toA[toI].Id) {
				switch (mouseItem) {
					case ItemInvBasic16 f:
						{
							ItemInvBasic16 t=(ItemInvBasic16)toA[toI];
							if (t.GetCount==99) return;

							if (f.GetCount==1) {
								t.SetCount=t.GetCount+1;
								invStartInventory[invStartId]=itemBlank;
							} else {
								t.SetCount=t.GetCount+1;
							//	t.SetCount=t.GetCount-1;
							}
							return;
						}


					case ItemInvBasic32 f:
						{
							ItemInvBasic32 t=(ItemInvBasic32)toA[toI];
							if (t.GetCount==99) return;

							if (f.GetCount==1) {
								t.SetCount=t.GetCount+1;
								invStartInventory[invStartId]=itemBlank;
							} else {
								t.SetCount=t.GetCount+1;
								//t.SetCount=t.GetCount-1;
							}
							return;
						}

					case ItemInvFood16 f:
						{
							ItemInvFood16 t=(ItemInvFood16)toA[toI];
							int max=t.CountMaximum;
							if (t.GetCount==max) return;

							if (f.GetCount==1) {
								t.SetCount=t.GetCount+1;
								invStartInventory[invStartId]=itemBlank;
							} else {
								t.SetCount=t.GetCount+1;
								t.SetCount=t.GetCount-1;
							}
							return;
						}
				}
			} else if (toA[toI].Id==(ushort)BlockId.None) {
				 switch (mouseItem) {
					case ItemInvBasic16 f:
						{
							if (f.GetCount==1) {
								DInt p=GetPosOfItemInInventories(toA, toI);
								toA[toI]=new ItemInvBasic16(f.Texture, f.Id, 1, p.X, p.Y);
								mouseItem=itemBlank;
							} else {
								int half=f.GetCount/2;
								DInt p=GetPosOfItemInInventories(toA, toI);
								toA[toI]=new ItemInvBasic16(f.Texture, f.Id, f.GetCount-half, p.X, p.Y);
								f.SetCount=half;
							}
							return;
						}

					case ItemInvBasic32 f:
						{
							if (f.GetCount==1) {
								DInt p=GetPosOfItemInInventories(toA, toI);
								toA[toI]=new ItemInvBasic32(f.Texture, f.Id, 1, p.X, p.Y);
								mouseItem=itemBlank;
							} else {
								int half=f.GetCount/2;
								DInt p=GetPosOfItemInInventories(toA, toI);
								toA[toI]=new ItemInvBasic32(f.Texture, f.Id, f.GetCount-half, p.X, p.Y);
								f.SetCount=half;
							}
							return;
						}

					#if DEBUG
					default: throw new Exception("Missing ItemInv category in switch");
					#endif
				}
			}else{
				 switch (mouseItem) {
					case ItemInvBasicColoritzed32NonStackable f:
						invMove=false;
						Vector2 toPos=toA[toI].GetPosVector2();
						invStartInventory[invStartId]=toA[toI];
						toA[toI]=mouseItem;
						f.SetPos(toPos);
						mouseItem=null;
						invStartInventory[invStartId].SetPos(startMovePos);
						mouseDrawItemTextInfo=true;
						showMouseItemWhileMooving=false;
						return;

					#if DEBUG
					default: throw new Exception("Missing ItemInv category in switch");
					#endif
				}
			}

			invMove=false;
		}

		void InvMoveHalf(ItemInv[] toA, int toI) {
			Debug.WriteLine("InvMoveHalf");
			//if (fromA[fromI].Id!=0 && toA[toI].Id==0) {
				switch (invStartInventory[invStartId]) {
					case ItemInvBasic16 item:
						{
							if (item.GetCount>1) {
								int half=(int)((float)item.GetCount/2);
								int fromY=item.GetCount-half;
							   // DInt p=GetPosOfItemInInventories(invStartInventory,invStartId);
							   // InventoryGetPosNormal(toI);
								toA[toI]=new ItemInvBasic16(item.Texture,item.Id,half, startMovePos.X, startMovePos.Y);
								((ItemInvBasic16)invStartInventory[invStartId]).SetCount=fromY;
								return;
							}
						}
						break;

					case ItemInvBasic32 item:
						{
							if (item.GetCount>1) {
								int half=(int)((float)item.GetCount/2);
								int fromY=item.GetCount-half;
								DInt p=InventoryGetPosNormal(toI);
								toA[toI]=new ItemInvBasic32(item.Texture,item.Id,half, p.X, p.Y);
								((ItemInvBasic32)invStartInventory[invStartId]).SetCount=fromY;
								return;
							}
						}
						break;
				}
		   // }
			invMove=false;
		}

		void InvDrop() {
			if (mouseRealPosX<Global.WindowWidthHalf){
				if (terrain[((int)PlayerX-30)/16].IsSolidBlocks[(int)PlayerY/16])AddItemToPlayer(mouseItem.ToNon());
				else DropItemToPos(mouseItem.ToNon(),PlayerX-30,PlayerY);
			}else{
				if (terrain[((int)PlayerX+20)/16].IsSolidBlocks[(int)PlayerY/16])AddItemToPlayer(mouseItem.ToNon());
				else DropItemToPos(mouseItem.ToNon(),PlayerX+20,PlayerY);
			}
			invMove=false;
			mouseItem=itemBlank;
			mouseItemId=0;
			showMouseItemWhileMooving=false;
			mouseDrawItemTextInfo=true;
		}

		void InvRemove() {
		 //   invStartInventory[invStartId]=itemBlank;
			invMove=false;
			showMouseItemWhileMooving=false;
			mouseItem=itemBlank;
		}

		bool InventoryAddOne(ushort index) {

			#region Nonstackable
			if (GameMethods.IsItemInvNonStackable32(index)) {
				for (int i=0; i<maxInvCount; i++) {
					if (InventoryNormal[i].Id == 0) {
						DInt pos;
						if (i<5) pos=InventoryGetPosNormal(i);
						else pos=InventoryGetPosNormalInv(i);
						InventoryNormal[i]=new ItemInvNonStackable32(ItemIdToTexture(index),index,pos.X,pos.Y);
						return true;
					}
				}
				return false;
			}
			if (GameMethods.IsItemInvFood16(index)) {
				for (int i=0; i<maxInvCount; i++) {
					if (InventoryNormal[i].Id == 0) {
						DInt pos;
						if (i<5) pos=InventoryGetPosNormal(i);
						else pos=InventoryGetPosNormalInv(i);
						InventoryNormal[i]=new ItemInvFood16(ItemIdToTexture(index),index,pos.X,pos.Y);
						return true;
					}
				}
				return false;
			}
			if (GameMethods.IsItemInvFood32(index)) {
				for (int i=0; i<maxInvCount; i++) {
					if (InventoryNormal[i].Id == 0) {
						DInt pos;
						if (i<5) pos=InventoryGetPosNormal(i);
						else pos=InventoryGetPosNormalInv(i);
						InventoryNormal[i]=new ItemInvFood32(ItemIdToTexture(index),index,pos.X,pos.Y);
						return true;
					}
				}
				return false;
			}
			#endregion

			#region Stackable
			if (GameMethods.IsItemInvBasic16(index)) {
				for (int i=0; i<maxInvCount; i++) {
					if (InventoryNormal[i].Id == 0) {
						DInt pos;
						if (i<5) pos=InventoryGetPosNormal(i);
						else pos=InventoryGetPosNormalInv(i);
						InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(index), index, 1, pos.X, pos.Y);
						return true;
					}
				}

				for (int i=0; i<maxInvCount; i++) {
					if (InventoryNormal[i].Id == index) {
						ItemInvBasic16 item=(ItemInvBasic16)InventoryNormal[i];
						if (item.GetCount<99) {
							item.SetCount=item.GetCount+1;
							return true;
						}
					}
				}
				return false;
			}

			if (GameMethods.IsItemInvBasic32(index)) {
				for (int i=0; i<maxInvCount; i++) {
					if (InventoryNormal[i].Id == 0) {
						DInt pos;
						if (i<5) pos=InventoryGetPosNormal(i);
						else pos=InventoryGetPosNormalInv(i);
						InventoryNormal[i]=new ItemInvBasic32(ItemIdToTexture(index), index, 1, pos.X, pos.Y);
						return true;
					}
				}

				for (int i=0; i<maxInvCount; i++) {
					if (InventoryNormal[i].Id == index) {
						ItemInvBasic32 item=(ItemInvBasic32)InventoryNormal[i];
						if (item.GetCount<99) {
							item.SetCount=item.GetCount+1;
							return true;
						}
					}
				}
				return false;
			}
			#endregion

			return false;
		}

		//bool InventoryAddOne(ushort index, Color color) {

		//    #region Nonstackable
		//    if (GameMethods.IsItemInvNonStackable32(index)) {
		//        for (int i=0; i<maxInvCount; i++) {
		//            if (InventoryNormal[i].Id == 0) {
		//                DInt pos;
		//                if (i<5) pos=InventoryGetPosNormal(i);
		//                else pos=InventoryGetPosNormalInv(i);
		//                InventoryNormal[i]=new ItemInvNonStackable32(ItemIdToTexture(index),index,pos.X,pos.Y);
		//                return true;
		//            }
		//        }
		//        return false;
		//    }

		//    if (GameMethods.IsItemInvBasicColoritzed32NonStackable(index)) {
		//        for (int i=0; i<maxInvCount; i++) {
		//            if (InventoryNormal[i].Id == 0) {
		//                DInt pos;
		//                if (i<5) pos=InventoryGetPosNormal(i);
		//                else pos=InventoryGetPosNormalInv(i);
		//                InventoryNormal[i]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(index),index,color,pos.X,pos.Y);
		//                return true;
		//            }
		//        }
		//        return false;
		//    }
		//    #endregion

		//    #region Stackable
		//    if (GameMethods.IsItemInvBasic16(index)) {
		//        for (int i=0; i<maxInvCount; i++) {
		//            if (InventoryNormal[i].Id == 0) {
		//                DInt pos;
		//                if (i<5) pos=InventoryGetPosNormal(i);
		//                else pos=InventoryGetPosNormalInv(i);
		//                InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(index), index, 1, pos.X, pos.Y);
		//                return true;
		//            }
		//        }

		//        for (int i=0; i<maxInvCount; i++) {
		//            if (InventoryNormal[i].Id == index) {
		//                ItemInvBasic16 item=(ItemInvBasic16)InventoryNormal[i];
		//                if (item.GetCount<99) {
		//                    item.SetCount=item.GetCount+1;
		//                    return true;
		//                }
		//            }
		//        }
		//        return false;
		//    }

		//    if (GameMethods.IsItemInvBasic32(index)) {
		//        for (int i=0; i<maxInvCount; i++) {
		//            if (InventoryNormal[i].Id == 0) {
		//                DInt pos;
		//                if (i<5) pos=InventoryGetPosNormal(i);
		//                else pos=InventoryGetPosNormalInv(i);
		//                InventoryNormal[i]=new ItemInvBasic32(ItemIdToTexture(index), index, 1, pos.X, pos.Y);
		//                return true;
		//            }
		//        }

		//        for (int i=0; i<maxInvCount; i++) {
		//            if (InventoryNormal[i].Id == index) {
		//                ItemInvBasic32 item=(ItemInvBasic32)InventoryNormal[i];
		//                if (item.GetCount<99) {
		//                    item.SetCount=item.GetCount+1;
		//                    return true;
		//                }
		//            }
		//        }
		//        return false;
		//    }
		//    #endregion

		//    return false;
		//}

		ItemNonInv InventoryAdd(ItemNonInv it) {

			switch (it) {
				#region Nonstackable
				case ItemNonInvNonStackable item:
					if (GameMethods.IsItemInvNonStackable32(it.Id)) {
						for (int i=0; i<maxInvCount; i++) {
							if (InventoryNormal[i].Id == 0) {
								DInt pos=InventoryGetPosNormal(i);
								//if (i<5) pos
								//else pos=InventoryGetPosNormalInv(i);
								InventoryNormal[i]=new ItemInvNonStackable32(ItemIdToTexture(it.Id),it.Id,pos.X,pos.Y);
								return null;
							}
						}
					} else {
						for (int i=0; i<maxInvCount; i++) {
							if (InventoryNormal[i].Id == 0) {
								DInt pos=InventoryGetPosNormal(i);
								//if (i<5) pos
								//else pos=InventoryGetPosNormalInv(i);
								InventoryNormal[i]=new ItemInvNonStackable16(ItemIdToTexture(it.Id),it.Id,pos.X,pos.Y);
								return null;
							}
						}
					}
					return it;

				case ItemNonInvBasicColoritzedNonStackable item:
					if (GameMethods.IsItemInvBasicColoritzed32NonStackable(it.Id)) {
						for (int i=0; i<maxInvCount; i++) {
							if (InventoryNormal[i].Id == 0) {
								DInt pos=InventoryGetPosNormal(i);
								//if (i<5) pos
								//else pos=InventoryGetPosNormalInv(i);
								InventoryNormal[i]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(it.Id),it.Id,item.color,pos.X,pos.Y);
								return null;
							}
						}
					}
					return it;

			#endregion

				#region stackable
				case ItemNonInvBasic item:
					if (GameMethods.IsItemInvBasic16(it.Id)) {
						int remain=item.Count;
						for (int i=0; i<maxInvCount; i++) {
							if (InventoryNormal[i].Id == it.Id) {
								ItemInvBasic16 item2=(ItemInvBasic16)InventoryNormal[i];
								if (item2.GetCount<99) {
									int needToAdd=99-item2.GetCount;
									if (needToAdd>remain) {
										item2.SetCount=item2.GetCount+remain;
										return null;
									} else if (needToAdd==remain) {
										item2.SetCount=item2.GetCount+remain;
										return null;
									} else {
										item2.SetCount=99;
										remain-=needToAdd;
									}
								}
							}
						}

						for (int i=0; i<maxInvCount; i++) {
							if (InventoryNormal[i].Id == 0) {
								DInt pos=InventoryGetPosNormal(i);
								//if (i<5) pos
								//else pos=InventoryGetPosNormalInv(i);
								if (remain<=99) {
									InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, remain, pos.X, pos.Y);
									return null;
								} else {
									InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, 99, pos.X, pos.Y);
									remain-=99;
								}
							}
						}

						return new ItemNonInvBasic(it.Id,remain);
					} else {
						int remain=item.Count;

						for (int i=0; i<maxInvCount; i++) {
							if (InventoryNormal[i]!=null) {
								if (InventoryNormal[i].Id == it.Id) {
									ItemInvBasic32 item2=(ItemInvBasic32)InventoryNormal[i];
									if (item2.GetCount<99) {
										int needToAdd=99-item2.GetCount;
										if (needToAdd>remain) {
											item2.SetCount=item2.GetCount+remain;
											return null;
										} else if (needToAdd==remain) {
											item2.SetCount=item2.GetCount+remain;
											return null;
										} else {
											item2.SetCount=99;
											remain-=needToAdd;
										}
									}
								}
							}
						}

						for (int i=0; i<maxInvCount; i++) {
							if (InventoryNormal[i]!=null) {

								if (InventoryNormal[i].Id == 0) {
									DInt pos;
									if (i<5) pos=InventoryGetPosNormal(i);
									else pos=InventoryGetPosNormalInv(i);
									if (remain<=99) {
										InventoryNormal[i]=new ItemInvBasic32(ItemIdToTexture(it.Id), it.Id, remain, pos.X, pos.Y);
										return null;
									} else {
										InventoryNormal[i]=new ItemInvBasic32(ItemIdToTexture(it.Id), it.Id, 99, pos.X, pos.Y);
										remain-=99;
									}
								}
							} 
						}
						return new ItemNonInvBasic(it.Id,remain);
					}

			case ItemNonInvFood item:
				if (GameMethods.IsItemInvFood16(it.Id)) {
					int remain=item.Count;
					//for (int i=0; i<maxInvCount; i++) {
					//	if (InventoryNormal[i]!=null) {
					//		if (InventoryNormal[i].Id == it.Id) {
					//			ItemInvFood16 item2=(ItemInvFood16)InventoryNormal[i];
					//			if (item2.GetCount<item2.CountMaximum) {
					//				int needToAdd=item2.CountMaximum-item2.GetCount;
					//				if (needToAdd>remain) {
					//					item2.SetCount=item2.GetCount+remain;
					//					return null;
					//				} else if (needToAdd==remain) {
					//					item2.SetCount=item2.GetCount+remain;
					//					return null;
					//				} else {
					//					item2.SetCount=item2.CountMaximum;
					//					remain-=needToAdd;
					//				}
					//			}
					//		}
					//	}
					//}

					for (int i=0; i<maxInvCount; i++) {
						if (InventoryNormal[i]!=null) {

						if (InventoryNormal[i].Id == 0) {
							DInt pos=InventoryGetPosNormal(i);
								if (remain<=item.CountMaximum) {
							InventoryNormal[i]=new ItemInvFood16(ItemIdToTexture(it.Id), it.Id, remain, item.CountMaximum, item.Descay, item.DescayMaximum, pos.X, pos.Y);
								 //   InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, remain, pos.X, pos.Y);
									return null;
								} else {
							InventoryNormal[i]=new ItemInvFood16(ItemIdToTexture(it.Id), it.Id, remain, item.CountMaximum, item.Descay, item.DescayMaximum, pos.X, pos.Y);
								  //  InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, 99, pos.X, pos.Y);
									remain-=item.CountMaximum;
								}
							}
						} }
					return new ItemNonInvFood(it.Id,remain,item.CountMaximum,item.Descay,item.DescayMaximum);
				} else { 
				   int remain=item.Count;
					//for (int i=0; i<maxInvCount; i++) {
					//	if (InventoryNormal[i]!=null) {

					//	if (InventoryNormal[i].Id == it.Id) {
					//		ItemInvFood32 item2=(ItemInvFood32)InventoryNormal[i];
					//		if (item2.GetCount<item2.CountMaximum) {
					//			int needToAdd=item2.CountMaximum-item2.GetCount;
					//			if (needToAdd>remain) {
					//				item2.SetCount=item2.GetCount+remain;
					//				return null;
					//			} else if (needToAdd==remain) {
					//				item2.SetCount=item2.GetCount+remain;
					//				return null;
					//			} else {
					//				item2.SetCount=item2.CountMaximum;
					//				remain-=needToAdd;
					//			}
					//		}
					//	}
					//} }

					for (int i=0; i<maxInvCount; i++) {
						if (InventoryNormal[i]!=null) {

						if (InventoryNormal[i].Id == 0) {
							DInt pos=InventoryGetPosNormal(i);
								if (remain<=item.CountMaximum) {
							InventoryNormal[i]=new ItemInvFood32(ItemIdToTexture(it.Id), it.Id, remain, item.CountMaximum, item.Descay, item.DescayMaximum, pos.X, pos.Y);
								 //   InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, remain, pos.X, pos.Y);
									return null;
								} else {
							InventoryNormal[i]=new ItemInvFood32(ItemIdToTexture(it.Id), it.Id, remain, item.CountMaximum, item.Descay, item.DescayMaximum, pos.X, pos.Y);
								  //  InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, 99, pos.X, pos.Y);
									remain-=item.CountMaximum;
								}
							}
						} }

					return new ItemNonInvFood(it.Id,remain,item.CountMaximum,item.Descay,item.DescayMaximum);    
				}

			case ItemNonInvTool item:
				if (GameMethods.IsItemInvTool32(it.Id)) {
					for (int i=0; i<maxInvCount; i++) {
						if (InventoryNormal[i]!=null) {

						if (InventoryNormal[i].Id == 0) {
							DInt pos;
							if (i<5) pos=InventoryGetPosNormal(i);
							else pos=InventoryGetPosNormalInv(i);
							InventoryNormal[i]=new ItemInvTool32(ItemIdToTexture(it.Id), it.Id, item.Count, item.Maximum, pos.X, pos.Y);
							return null;
						}
					} }

					return item;//new ItemNonInvTool(item.Id, item.Count, item.Maximum);
				}else{
				   for (int i=0; i<maxInvCount; i++) {
						if (InventoryNormal[i]!=null) {

						if (InventoryNormal[i].Id == 0) {
							DInt pos;
							if (i<5) pos=InventoryGetPosNormal(i);
							else pos=InventoryGetPosNormalInv(i);
							InventoryNormal[i]=new ItemInvTool16(ItemIdToTexture(it.Id), it.Id, item.Count, item.Maximum, pos.X, pos.Y);
							return null;
						}
					} }

					return item;//new ItemNonInvTool(item.Id, item.Count, item.Maximum);
				}
				default:
					#if DEBUG
					throw new Exception("Missing category");
					#else
					return it;
					#endif
			}
			#endregion

			//return it;
		}

		void ChangeInventoryState() {
			if (inventory==InventoryType.Normal) {

				if (Global.WorldDifficulty==2) {
					inventory=InventoryType.Creative;
					SetCaptionInventory();
					if (creativeTabCrafting)SetInvCraftingBlocks();
					else SetInvCreativeBlocks();
					return;
				}

				inventory=InventoryType.BasicInv;
				SetCaptionInventory();
				SetUpInvToNew();
				SetNeed();
				return;

			} else {
				if (inventory==InventoryType.Typing) {

					return;
				} else if (inventory==InventoryType.Shelf) {

					ShelfBlock block=(ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y];

					if (block.Inv[4].Id!=0) {
						Texture2D tex=ItemIdToTexture(block.Inv[4].Id);
						if (tex!=null) {
							block.SmalItemTexture=tex;
							block.IsSmallItem=true;

							inventory=0;
							return;
						}
					}

					block.IsSmallItem=false;
					inventory=0;
					return;
				}

				SetPlayerClothes();
				inventory=0;
				return;
			}
		}

		int InvSideMoveId() {
			// Basic right inventory
			if (In(Global.WindowWidth-40, Global.WindowHeightHalf-80, Global.WindowWidth, Global.WindowHeightHalf-80+5*40)) {
			  //  Console.WriteLine((newMouseState.Y-(Global.WindowHeightHalf-80))/40);
				return (newMouseState.Y-(Global.WindowHeightHalf-80))/40;
			}
			return -1;
		}

		int InvMoveId() {
			// Inventory
			if (In(Global.WindowWidthHalf-300+4+200+4+4, Global.WindowHeightHalf-200+2+4, Global.WindowWidthHalf-300+4+200+4+4+(9*40), Global.WindowHeightHalf-200+2+4+(5*40))) {
				int row=(mouseRealPosY-(Global.WindowHeightHalf-200+2+4))/40;
				int col=(mouseRealPosX-(Global.WindowWidthHalf-300+4+200+4+4))/40;
			  //  Console.WriteLine(row*9+" "+col+" "+inventoryScrollbarValue+" "+4);
				return row*9+col+inventoryScrollbarValue+5;
			}
			return -1;
		}

		int InvShelfMoveId() {
			// Shelf
			if (In(Global.WindowWidthHalf-300+38, Global.WindowHeightHalf+20-2+25, Global.WindowWidthHalf-300+38+40*3-1, Global.WindowHeightHalf+20-2+3*40+25-1)) {
				int row=(mouseRealPosX-(Global.WindowWidthHalf-300+38))/40;
				int col=(mouseRealPosY-(Global.WindowHeightHalf+20-2+25))/40;
				return row+col*3;
			}

			return -1;
		}

		int InvWoodenBoxMoveId() {
			// Wooden box
			if (In(Global.WindowWidthHalf-300+59, Global.WindowHeightHalf+59, Global.WindowWidthHalf-300+59+(12*40), Global.WindowHeightHalf+59+40*2)) {
				int row=(mouseRealPosX-(Global.WindowWidthHalf-300+59))/40;
				int col=(mouseRealPosY-(Global.WindowHeightHalf+59))/40;
				//Debug.WriteLine("[wooden] row: "+row+", col:"+col+", id: "+(row+col*12));
				return row+col*12;
			}

			return -1;
		}

		int InvAdvBoxMoveId() {
			// Adv box
			if (In(Global.WindowWidthHalf-300+20, Global.WindowHeightHalf+23, Global.WindowWidthHalf-300+20+12*40, Global.WindowHeightHalf+23+40*4)) {
				int row=(mouseRealPosX-(Global.WindowWidthHalf-300+20))/40;
				int col=(mouseRealPosY-(Global.WindowHeightHalf+23))/40;
			  //  Debug.WriteLine("[adv] row: "+row+", col:"+col+", id: "+(row+col*12));
				return row+col*12;
			}

			return -1;
		}

		int InvClothesMoveId() {
		  //  if (ix<4) return new DInt(Global.WindowWidthHalf-300+4+60+4,Global.WindowHeightHalf-200+2+4+4+ix*40);
		  //  else return new DInt(Global.WindowWidthHalf-300+4+60+4+40,Global.WindowHeightHalf-200+2+4+4+40*(ix-4));

			if (mouseRealPosY>Global.WindowHeightHalf-200+2+4+4+(4*40)) return -1;
			if (mouseRealPosY<Global.WindowHeightHalf-200+2+4+4) return -1;

			// Clothes
			if (mouseRealPosX>Global.WindowWidthHalf-300+4+60+4){

				if (mouseRealPosX<Global.WindowWidthHalf-300+4+60+4+40){
					return (newMouseState.Y-(Global.WindowHeightHalf-200+2+4+4))/40;
				}else if (mouseRealPosX<Global.WindowWidthHalf-300+4+60+4+40+40){
					return (newMouseState.Y-(Global.WindowHeightHalf-200+2+4+4))/40+4;
				}
			}
			//if (In(Global.WindowWidthHalf-300+4+60+4, Global.WindowHeightHalf-200+2+4+4, Global.WindowWidthHalf-300+4+60+4+40, Global.WindowHeightHalf-200+2+4+4+(4*40))) {
			//    return (newMouseState.Y-(Global.WindowHeightHalf-200+2+4+4))/40;
			//}

			//if (In(Global.WindowWidthHalf-300+4+60+4+40, Global.WindowHeightHalf-200+2+4+4, Global.WindowWidthHalf-300+4+60+4+40, Global.WindowHeightHalf-200+2+4+4+(4*40))) {
			//    return (newMouseState.Y-(Global.WindowHeightHalf-200+2+4+4))/40;
			//}

			return -1;
		}

		void ChangeInventory() {
			if (invMove) {
				if (leftMove) {
					if (mouseRightRelease) {
						int i;

						// Basic right inventory
						if ((i=InvSideMoveId())>=0) {
							InvMoveOne(InventoryNormal,i);
							return;
						}

						// Inventory
						if ((i=InvMoveId())>=0) {
							InvMoveOne(InventoryNormal,i);
							return;
						}

						// Clothes
						if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
							if ((i=InvClothesMoveId())>=0) {
								InvMoveOne(InventoryClothes, i);
								return;
							}
						}

						// Shelf
						if (inventory==InventoryType.Shelf || inventory==InventoryType.Composter) {
							if ((i=InvShelfMoveId())>=0) {
								InvMoveOne(((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								return;
							}
						}

						// BoxWooden
						if (inventory==InventoryType.BoxWooden) {
							if ((i=InvWoodenBoxMoveId())>=0) {
								InvMoveOne(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								return;
							}
						}

						// Adv box
						if (inventory==InventoryType.BoxAdv) {
							if ((i=InvAdvBoxMoveId())>=0) {
								InvMoveOne(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								return;
							}
						}


						// Miner
						if (inventory==InventoryType.Miner) {
							if ((i=InvWoodenBoxMoveId())>=0) {
								InvMoveOne(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								return;
							}
						}

						// Charger || OxygenMachine
						if (inventory==InventoryType.Charger || inventory==InventoryType.OxygenMachine) {
							if (In40(Global.WindowWidthHalf-300+38+40,Global.WindowHeightHalf+20-2+40+25)) {
								InvMoveOne(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
								return;
							}
						}

						if (inventory==InventoryType.Barrel) {
							if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250)) {
								InvMoveOne(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
								return;
							}

							if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250+64)) {
								InvMoveOne(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 1);
								return;
							}
						}

						InvDrop();

					} else if (mouseLeftRelease) {
							int i;

							// Basic right inventory
							if ((i=InvSideMoveId())>=0) {
								InvMove(InventoryNormal,i);
								return;
							}

							// Inventory
							if ((i=InvMoveId())>=0) {
								InvMove(InventoryNormal,i);
								return;
							}

							// Clothes
							if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
								if ((i=InvClothesMoveId())>=0) {
									InvMove(InventoryClothes,i);
									return;
								}
							}

							// Shelf
							if (inventory==InventoryType.Shelf || inventory==InventoryType.Composter) {
								if ((i=InvShelfMoveId())>=0) {
									InvMove(((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
									return;
								}
							}

							// BoxWooden
							if (inventory==InventoryType.BoxWooden) {
								if ((i=InvWoodenBoxMoveId())>=0) {
									InvMove(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
									return;
								}
							}

							// Adv box
							if (inventory==InventoryType.BoxAdv) {
								if ((i=InvAdvBoxMoveId())>=0) {
									InvMove(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
									return;
								}
							}

							// Miner
							if (inventory==InventoryType.Miner) {
								if ((i=InvWoodenBoxMoveId())>=0) {
									InvMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
									return;
								}
							}

							// Charger || OxygenMachine
							if (inventory==InventoryType.Charger || inventory==InventoryType.OxygenMachine) {
								if (In40(Global.WindowWidthHalf-300+38+40,Global.WindowHeightHalf+20-2+40+25)) {
									InvMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
									return;
								}
							}

							if (inventory==InventoryType.Barrel) {
								if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250)) {
									InvMove(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
									return;
								}

								if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250+64)) {
									InvMove(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 1);
									return;
								}
							}

							//delete
							if (inventory==InventoryType.Creative) {
								if (In40(Global.WindowWidthHalf-300+4+200+4+4+8*40, Global.WindowHeightHalf-200+2+4+40*5)) {
									InvRemove();
									return;
								}
							}

							InvDrop();

						}
				} else {
					if (mouseLeftRelease) {
						int i;

						// Basic right inventory
						if ((i=InvSideMoveId())>=0) {
							InvMoveHalf(InventoryNormal,i);
							return;
						}

						// Inventory
						if ((i=InvMoveId())>=0) {
							InvMoveHalf(InventoryNormal,i);
							return;
						}

						// Clothes
						if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
							if ((i=InvClothesMoveId())>=0) {
								InvMoveHalf(InventoryClothes,i);
								return;
							}
						}

						// Shelf
						if (inventory==InventoryType.Shelf || inventory==InventoryType.Composter) {
							if ((i=InvShelfMoveId())>=0) {
								InvMoveHalf(((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								return;
							}
						}

						// BoxWooden
						if (inventory==InventoryType.BoxWooden) {
							if ((i=InvWoodenBoxMoveId())>=0) {
								InvMoveHalf(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								return;
							}
						}

						// Adv box
						if (inventory==InventoryType.BoxAdv) {
							if ((i=InvAdvBoxMoveId())>=0) {
								InvMoveHalf(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								return;
							}
						}

						// Miner
						if (inventory==InventoryType.Miner) {
							if ((i=InvWoodenBoxMoveId())>=0) {
								InvMoveHalf(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								return;
							}
						}

						// Charger || OxygenMachine
						if (inventory==InventoryType.Charger || inventory==InventoryType.OxygenMachine) {
							if (In40(Global.WindowWidthHalf-300+38+40,Global.WindowHeightHalf+20-2+40+25)) {
								InvMoveHalf(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
								return;
							}
						}

						if (inventory==InventoryType.Barrel) {
							if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250)) {
								InvMoveHalf(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
								return;
							}

							if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250+64)) {
								InvMoveHalf(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 1);
								return;
							}
						}

						//delete
						if (inventory==InventoryType.Creative) {
							if (In40(Global.WindowWidthHalf-300+4+200+4+4+8*40, Global.WindowHeightHalf-200+2+4+40*5)) {
								InvRemove();
								return;
							}
						}

						InvDrop();

					} else {
						if (mouseRightRelease) {
							int i;

							// Basic right inventory
							if ((i=InvSideMoveId())>=0) {
								InvMove(InventoryNormal,i);
								return;
							}

							// Inventory
							if ((i=InvMoveId())>=0) {
								InvMove(InventoryNormal,i);
								return;
							}

							// Clothes
							if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
								if ((i=InvClothesMoveId())>=0) {
									InvMove(InventoryClothes,i);
									return;
								}
							}

							// Shelf
							if (inventory==InventoryType.Shelf || inventory==InventoryType.Composter) {
								if ((i=InvShelfMoveId())>=0) {
									InvMove(((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
									return;
								}
							}

							// BoxWooden
							if (inventory==InventoryType.BoxWooden) {
								if ((i=InvWoodenBoxMoveId())>=0) {
									InvMove(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
									return;
								}
							}

							// Adv box
							if (inventory==InventoryType.BoxAdv) {
								if ((i=InvAdvBoxMoveId())>=0) {
									InvMove(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
									return;
								}
							}

							// Miner
							if (inventory==InventoryType.Miner) {
								if ((i=InvWoodenBoxMoveId())>=0) {
									InvMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
									return;
								}
							}

							// Charger || OxygenMachine
							if (inventory==InventoryType.Charger || inventory==InventoryType.OxygenMachine) {
								if (In40(Global.WindowWidthHalf-300+38+40,Global.WindowHeightHalf+20-2+40+25)) {
									InvMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
									return;
								}
							}

							if (inventory==InventoryType.Barrel) {
								if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250)) {
									InvMove(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
									return;
								}

								if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250+64)) {
									InvMove(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 1);
									return;
								}
							}

							//delete
							if (inventory==InventoryType.Creative) {
								if (In40(Global.WindowWidthHalf-300+4+200+4+4+8*40, Global.WindowHeightHalf-200+2+4+40*5)) {
									InvRemove();
									return;
								}
							}

							InvDrop();
						}
					}
				}
			} else {
				if (mouseLeftPress) {
					int i;

					// Basic right inventory
					if ((i=InvSideMoveId())>=0) {
						StartItemMove(InventoryNormal, i);
						leftMove = true;
						return;
					}

					// Inventory
					if ((i=InvMoveId())>=0) {
						StartItemMove(InventoryNormal, i);
						leftMove = true;
						return;
					}

					// Clothes
					if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
						if ((i=InvClothesMoveId())>=0) {
							StartItemMove(InventoryClothes, i);
							leftMove = true;
							return;
						}
					}

					// Shelf
					if (inventory==InventoryType.Shelf || inventory==InventoryType.Composter) {
						if ((i=InvShelfMoveId())>=0) {
							StartItemMove(((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
							leftMove = true;
							return;
						}
					}

					// BoxWooden
					if (inventory==InventoryType.BoxWooden) {
						if ((i=InvWoodenBoxMoveId())>=0) {
							StartItemMove(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
							leftMove = true;
							return;
						}
					}

					// Adv box
					if (inventory==InventoryType.BoxAdv) {
						if ((i=InvAdvBoxMoveId())>=0) {
							StartItemMove(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
							leftMove = true;
							return;
						}
					}

					// Miner
					if (inventory==InventoryType.Miner) {
						if ((i=InvWoodenBoxMoveId())>=0) {
							StartItemMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
							leftMove = true;
							return;
						}
					}

					// Charger || OxygenMachine
					if (inventory==InventoryType.Charger || inventory==InventoryType.OxygenMachine) {
						if (In40(Global.WindowWidthHalf-300+38+40,Global.WindowHeightHalf+20-2+40+25)) {
							StartItemMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
							leftMove = true;
							return;
						}
					}

					if (inventory==InventoryType.Barrel) {
						if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250)) {
							StartItemMove(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
							leftMove = true;
							return;
						}

						if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250+64)) {
							StartItemMove(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 1);
							leftMove = true;
							return;
						}
					}

				} else {
					if (mouseRightPress) {
						int i;

						// Basic right inventory
						if ((i=InvSideMoveId())>=0) {
							StartItemMoveHalf(InventoryNormal, i);
							leftMove = false;
							return;
						}

						// Inventory
						if ((i=InvMoveId())>=0) {
							StartItemMoveHalf(InventoryNormal, i);
							leftMove = false;
							return;
						}

						// Clothes
						if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
							if ((i=InvClothesMoveId())>=0) {
								if (i<8){
								StartItemMoveHalf(InventoryClothes, i);
								leftMove = false;
								return;
								}
							}
						}

						// Shelf
						if (inventory==InventoryType.Shelf || inventory==InventoryType.Composter) {
							if ((i=InvShelfMoveId())>=0) {
								StartItemMoveHalf(((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								leftMove = false;
								return;
							}
						}

						// BoxWooden
						if (inventory==InventoryType.BoxWooden) {
							if ((i=InvWoodenBoxMoveId())>=0) {
								StartItemMoveHalf(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								leftMove = false;
								return;
							}
						}

						// Adv box
						if (inventory==InventoryType.BoxAdv) {
							if ((i=InvAdvBoxMoveId())>=0) {
								StartItemMoveHalf(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								leftMove = false;
								return;
							}
						}

						// Miner
						if (inventory==InventoryType.Miner) {
							if ((i=InvWoodenBoxMoveId())>=0) {
								StartItemMoveHalf(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
								leftMove = false;
								return;
							}
						}

						// Charger || OxygenMachine
						if (inventory==InventoryType.Charger || inventory==InventoryType.OxygenMachine) {
							if (In40(Global.WindowWidthHalf-300+38+40,Global.WindowHeightHalf+20-2+40+25)) {
								StartItemMoveHalf(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
								leftMove = false;
								return;
							}
						}

						if (inventory==InventoryType.Barrel) {
							if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250)) {
								StartItemMoveHalf(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
								leftMove = false;
								return;
							}

							if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250+64)) {
								StartItemMoveHalf(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 1);
								leftMove = false;
								return;
							}
						}
					}else{
						if (mousePosChanged) {
							int i;
							mouseDrawItemTextInfo=false;
							// Basic right inventory
							if ((i=InvSideMoveId())>=0) {
								MouseItemNameEvent(InventoryNormal[i].Id);
								return;
							}

							// Inventory
							if ((i=InvMoveId())>=0) {
								MouseItemNameEvent(InventoryNormal[i].Id);
								return;
							}

							// Clothes
							if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
								if ((i=InvClothesMoveId())>=0) {
									if (i<8) MouseItemNameEvent(InventoryClothes[i].Id);
									return;
								}
							}

							// Shelf
							if (inventory==InventoryType.Shelf || inventory==InventoryType.Composter) {
								if ((i=InvShelfMoveId())>=0) {
									MouseItemNameEvent(((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i].Id);
									return;
								}
							}

							// BoxWooden
							if (inventory==InventoryType.BoxWooden) {
								if ((i=InvWoodenBoxMoveId())>=0) {
									MouseItemNameEvent(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i].Id);
									return;
								}
							}

							// Adv box
							if (inventory==InventoryType.BoxAdv) {
								if ((i=InvAdvBoxMoveId())>=0) {
									MouseItemNameEvent(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i].Id);
									return;
								}
							}

							// Miner
							if (inventory==InventoryType.Miner) {
								if ((i=InvWoodenBoxMoveId())>=0) {
									MouseItemNameEvent(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i].Id);
									return;
								}
							}

							// Charger || OxygenMachine
							if (inventory==InventoryType.Charger || inventory==InventoryType.OxygenMachine) {
								if (In40(Global.WindowWidthHalf-300+38+40,Global.WindowHeightHalf+20-2+40+25)) {
									MouseItemNameEvent(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[0].Id);
									return;
								}
							}

							if (inventory==InventoryType.Barrel) {
								if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250)) {
									MouseItemNameEvent(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[0].Id);
									return;
								}

								if (In40(Global.WindowWidthHalf-300+119,Global.WindowHeightHalf-198+250+64)) {
									MouseItemNameEvent(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[1].Id);
									return;
								}
							}

							// Creative
							if (inventory==InventoryType.Creative) {
								if (!creativeTabCrafting){
									if ((i=GetInventoryIdCreative())>=0) {
										MouseItemNameEvent(InventoryCreative[i].Id);
										return;
									}
								}
							}

							// crafting
							if (inventory==InventoryType.BasicInv
							 || (inventory==InventoryType.Creative && creativeTabCrafting)
							 || inventory==InventoryType.Desk
							 || inventory==InventoryType.SewingMachine
							 || inventory==InventoryType.Macerator
							 || inventory==InventoryType.FurnaceStone
							 || inventory==InventoryType.FurnaceElectric) {
								if ((i=GetCraftingInventoryId())>=0) {
									MouseItemNameEvent(InventoryCrafting[i].Id);
									return;
								}
							}

							mouseDrawItemTextInfo=false;
						}
					}
				}
			}
		}

		void SelectItemCraft() {
			if (mouseLeftRelease) {
				int xx =0, yh=0;

				for (int i=inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
					if (i>inventoryScrollbarValueCraftingMax) break;

					if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {
						selectedCraftingItem=i;
						ItemInv itemToCraft=InventoryCrafting[i];

						CurrentDeskCrafting=GameMethods.Craft(itemToCraft.Id);
						SelectedCraftingRecipe=0;
						SetNeed();
						return;
					}
					xx+=40;

					if (xx==6*40) {
						xx=0;
						yh+=40;
					}
				}
			}
		}

		void SelectItemCraftPlus() {
			int AddH=35;
			if (mouseLeftRelease) {
				int xx =0, yh=0;

				for (int i=inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
					if (i>inventoryScrollbarValueCraftingMax) break;

					if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8+AddH)) {

						selectedCraftingItem=i;

						ItemInv itemToCraft=InventoryCrafting[i];

						CurrentDeskCrafting=GameMethods.Craft(itemToCraft.Id);
						SelectedCraftingRecipe=0;
						SetNeed();
						return;
					}
					xx+=40;

					if (xx==6*40) {
						xx=0;
						yh+=40;
					}
				}
			}
		}

		void SelectItemBake() {
			if (mouseLeftRelease) {
				int xx = 0, yh=0;

				for (int i=inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
					if (i>inventoryScrollbarValueCraftingMax) break;

					if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {
						selectedCraftingItem=i;
						ItemInv itemToCraft=InventoryCrafting[i];

						CurrentDeskCrafting=GameMethods.Bake(itemToCraft.Id);
						SelectedCraftingRecipe=0;
						SetNeed();
						return;
					}
					xx+=40;

					if (xx==6*40) {
						xx=0;
						yh+=40;
					}
				}
			}
		}

		void SelectItemClothes() {
			if (mouseLeftRelease) {
				int xx =0, yh=0;

				for (int i=inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
					if (i>inventoryScrollbarValueCraftingMax) break;

					if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {
						selectedCraftingItem=i;

						ItemInv itemToCraft=InventoryCrafting[i];
						SelectedCraftingRecipe=0;
						CurrentDeskCrafting=GameMethods.Clothes(itemToCraft.Id);
						SetNeed();
						return;
					}
					xx+=40;

					if (xx==6*40) {
						xx=0;
						yh+=40;
					}
				}
			}
		}

		void SelectItemToDust() {
			if (mouseLeftRelease) {
				int xx=0, yh=0;

				for (int i=inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
					if (i>inventoryScrollbarValueCraftingMax) break;

					if (In40(Global.WindowWidthHalf-300+4+40+4+xx,Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {

						selectedCraftingItem=i;

						SelectedCraftingRecipe=0;

						ItemInv itemToCraft=InventoryCrafting[i];

						CurrentDeskCrafting=GameMethods.ToDust(itemToCraft.Id);

						SetNeed();
						return;
					}

					xx+=40;

					if (xx==6*40) {
						xx=0;
						yh+=40;
					}
				}
			}
		}

		int TotalItemsInInventoryItemBasic16(ushort id) {
			int inInv = 0;
			foreach (ItemInv i in InventoryNormal) {
				if (id==i.Id) inInv+=(i as ItemInvBasic16).GetCount;
			}
			return inInv;
		}

		int TotalItemsInInventoryForAllTypes(ushort id) {
			if (GameMethods.IsItemInvBasic16(id)) {
				int inInv = 0;
				foreach (ItemInv i in InventoryNormal) {
					if (id==i.Id) inInv+=(i as ItemInvBasic16).GetCount;
				}
				return inInv;
			}

			if (GameMethods.IsItemInvBasic32(id)) {
				int inInv = 0;
				foreach (ItemInv i in InventoryNormal) {
					if (id==i.Id) inInv+=(i as ItemInvBasic32).GetCount;
				}
				return inInv;
			}

			if (GameMethods.IsItemInvTool32(id)) {
				int inInv = 0;
				foreach (ItemInv i in InventoryNormal) {
					if (id==i.Id) inInv+=(i as ItemInvTool32).GetCount;
				}
				return inInv;
			}
			
			if (GameMethods.IsItemInvFood16(id)) {
				int inInv = 0;
				foreach (ItemInv i in InventoryNormal) {
					if (id==i.Id) inInv+=(i as ItemInvFood16).GetCount;
				}
				return inInv;
			}

			if (GameMethods.IsItemInvNonStackable32(id)) {
				int inInv = 0;
				foreach (ItemInv i in InventoryNormal) {
					if (id==i.Id) inInv++;
				}
				return inInv;
			}

			if (GameMethods.IsItemInvBasicColoritzed32NonStackable(id)) {
				int inInv = 0;
				foreach (ItemInv i in InventoryNormal) {
					if (id==i.Id) inInv++;
				}
				return inInv;
			}

			if (GameMethods.IsItemInvTool16(id)) {
				int inInv = 0;
				foreach (ItemInv i in InventoryNormal) {
					if (id==i.Id) inInv+=(i as ItemInvTool16).GetCount;
				}
				return inInv;
			}

			#if DEBUG
			throw new Exception("Not detectable item '"+(Items)id+"' in categories IsItemInvNonStackable32, IsItemBasicColorized32NonStackable, ...; Add in some category");
			#else
			return 0;
			#endif
		}
		#endregion

		#region Inventory draw
		void InvMouseDraw() {
			mouseItem.SetPos(mouseRealPosX-16,mouseRealPosY-16);
			mouseItem.Draw();
		}

		//void InventoryDrawItems() {
		//    for (int i=0; i<5; i++) InventoryNormal[i].Draw();
		//}

		void DrawNeedNew() {
			if (CurrentDeskCrafting==null)return;
			if (selectedCraftingItem==-1)return;
			if (SelectedCraftingRecipe==-1)return;
			spriteBatch.Draw(inventoryNeedTexture, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8, Global.WindowHeightHalf-200+2+4+200+8+8), ColorWhite);
			CraftingIn[] slots=CurrentDeskCrafting[SelectedCraftingRecipe].Input;

			int i = 0;
			for (int y = 0; y<2; y++) {
				for (int x = 0; x<6; x++) {
					if (slots.Length==i) break;

					CraftingIn slot=slots[i];
					ItemNonInv[] item=slot.ItemSlot;
					if (slot.SelectedItem==-1) {
						if (!slot.HaveItemInInventory)
							spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8, 40, 40), color_r255_g0_b0_a100);

						/*GameDraw.DrawItemInInventory*/DrawItem(/*ItemIdToTexture(item[slot.TmpSelected].Id),*/ item[slot.TmpSelected], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8);

						spriteBatch.Draw(TextureSelectCrafting, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8+x*40+40-16, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+40-16), ColorWhite);
					}else{
					  //  ItemNonInv selectedSlot=item[slot.SelectedItem];

						if (item.Length==1) {
							if (!slot.HaveItemInInventory)
								spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8, 40, 40), color_r255_g0_b0_a100);

							if (slot.Texture!=null) /*GameDraw.DrawItemInInventory*/DrawItem(/*slot.Texture,*/ item[slot.SelectedItem], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8);
						} else {
							if (!slot.HaveItemInInventory)
								spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8, 40, 40), color_r255_g0_b0_a100);

							if (slots[i].SelectedItem==-1) {
								/*GameDraw.DrawItemInInventory*/DrawItem(/*ItemIdToTexture(item[slot.TmpSelected].Id),*/ item[slot.TmpSelected], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8);
							} else {
								/*GameDraw.DrawItemInInventory*/DrawItem(/*slot.Texture, */item[slot.SelectedItem], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8);
							}
							spriteBatch.Draw(TextureSelectCrafting, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8+x*40+40-16, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+40-16), ColorWhite);
						}
					}

					i++;
				}
			}

			if (CurrentDeskCrafting.Length!=1) {
				 buttonPrev.ButtonDraw(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
				 buttonNext.ButtonDraw(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
			}

			if (CanCraft(1)) {
				buttonCraft1x.ButtonDraw(/*spriteBatch, mouseLeftDown, mouseRealPos*/);

				if (CanCraft(10)) {
					buttonCraft10x.ButtonDraw(/*spriteBatch, mouseLeftDown, mouseRealPos*/);

					if (CanCraft(100)) buttonCraft100x.ButtonDraw(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
					else buttonCraft100x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
				} else {
					buttonCraft10x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
					buttonCraft100x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
				}
			} else {
				buttonCraft1x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
				buttonCraft10x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
				buttonCraft100x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
			}
		}

		void DrawNeedNewPlus() {
			int AddH=35;
			if (CurrentDeskCrafting==null)return;
			if (selectedCraftingItem==-1)return;
			if (SelectedCraftingRecipe==-1)return;
			spriteBatch.Draw(inventoryNeedTexture, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8, Global.WindowHeightHalf-200+2+4+200+8+8+AddH), ColorWhite);
			CraftingIn[] slots=CurrentDeskCrafting[SelectedCraftingRecipe].Input;

			int i = 0;
			for (int y = 0; y<2; y++) {
				for (int x = 0; x<6; x++) {
					if (slots.Length==i) break;

					CraftingIn slot=slots[i];
					ItemNonInv[] item=slot.ItemSlot;
					if (slot.SelectedItem==-1) {
						if (!slot.HaveItemInInventory) spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH, 40, 40), color_r255_g0_b0_a100);

						DrawItem(item[slot.TmpSelected],Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH);

					   // GameDraw.DrawItemInInventory(ItemIdToTexture(item[slot.TmpSelected].Id), , Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH);

						spriteBatch.Draw(TextureSelectCrafting, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8+x*40+40-16, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+40-16+AddH), ColorWhite);
					}else{
					 //   ItemNonInv selectedSlot=item[slot.SelectedItem];

						if (item.Length==1) {
							if (!slot.HaveItemInInventory) spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH, 40, 40), color_r255_g0_b0_a100);

							if (slot.Texture!=null) DrawItem(/*slot.Texture,*/ item[slot.SelectedItem], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH);
						} else {
							if (!slot.HaveItemInInventory)
								spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH, 40, 40), color_r255_g0_b0_a100);

							if (slots[i].SelectedItem==-1) {
								/*GameDraw.DrawItemInInventory*/DrawItem(/*ItemIdToTexture(item[slot.TmpSelected].Id),*/ item[slot.TmpSelected], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH);
							} else {
								/*GameDraw.DrawItemInInventory*/DrawItem(/*slot.Texture,*/ item[slot.SelectedItem], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH);
							}
							spriteBatch.Draw(TextureSelectCrafting, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8+x*40+40-16, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+40-16+AddH), ColorWhite);
						}
					}

					i++;
				}
			}


			if (CurrentDeskCrafting.Length!=1) {
				 buttonPrev.ButtonDraw(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
				 buttonNext.ButtonDraw(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
			}

			if (CanCraft(1)) {
				buttonCraft1x.ButtonDraw(/*spriteBatch, mouseLeftDown, mouseRealPos*/);

				if (CanCraft(10)) {
					buttonCraft10x.ButtonDraw(/*spriteBatch, mouseLeftDown, mouseRealPos*/);

					if (CanCraft(100)) buttonCraft100x.ButtonDraw(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
					else buttonCraft100x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
				} else {
					buttonCraft10x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
					buttonCraft100x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
				}
			} else {
				buttonCraft1x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
				buttonCraft10x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
				buttonCraft100x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
			}
		}

		void DrawItem(ItemNonInv item, int x, int y) {
			ushort id=item.Id;
			if (id==0) return;
			switch (item){
				case ItemNonInvBasic it:
					if (GameMethods.IsItemInvBasic16(id)) new ItemInvBasic16(ItemIdToTexture(id), id, it.Count, x, y).Draw();
					else new ItemInvBasic32(ItemIdToTexture(id), id, it.Count, x, y).Draw();
					return;

				case ItemNonInvBasicColoritzedNonStackable it:
					new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(id), id, it.color, x, y).Draw();
					return;

				case ItemNonInvFood it:
					if (GameMethods.IsItemInvFood32(id)) new ItemInvFood32(ItemIdToTexture(id), id, it.Count, it.CountMaximum, it.Descay, it.DescayMaximum, x, y).Draw();
					else new ItemInvFood16(ItemIdToTexture(id), id, it.Count, it.CountMaximum, it.Descay, it.DescayMaximum, x, y).Draw();
					return;

				case ItemNonInvNonStackable it:
					new ItemInvNonStackable32(ItemIdToTexture(id), id, x, y).Draw();
					return;

				case ItemNonInvTool it:
					 if (GameMethods.IsItemInvTool16(id)) new ItemInvTool16(ItemIdToTexture(id), id, it.Count, it.Maximum, x, y).Draw();
					 else new ItemInvTool32(ItemIdToTexture(id), id, it.Count, it.Maximum, x, y).Draw();
					 return;
			}

			#if DEBUG
			throw new Exception("Item '"+(Items)id+"' is not registrated or missing category up");
			#endif
		}

		bool CanCraft(int c) {
			foreach (CraftingIn n in CurrentDeskCrafting[SelectedCraftingRecipe].Input) {
				if (n.SelectedItem==-1) return false;
				ItemNonInv item=n.ItemSlot[n.SelectedItem];
				switch (item) {
					case ItemNonInvTool t:
						if (TotalItemsInInventoryForAllTypes(item.Id)<t.Count*c)  return false;
						break;

					case ItemNonInvNonStackable t:
						if (TotalItemsInInventoryForAllTypes(item.Id)<1*c)  return false;
						break;

					case ItemNonInvBasicColoritzedNonStackable t:
						if (TotalItemsInInventoryForAllTypes(item.Id)<1*c)  return false;
						break;

					case ItemNonInvFood t:
						if (TotalItemsInInventoryForAllTypes(item.Id)<t.Count*c)  return false;
						break;

					case ItemNonInvBasic t:
						if (TotalItemsInInventoryForAllTypes(item.Id)<t.Count*c)  return false;
						break;

					default:
						#if DEBUG
						throw new Exception("Missing type");
						#else
						return false;
						#endif
				}
			  //  if (TotalItemsInInventoryForAllTypes(item.Id)<item.Y*c)  return false;
			}
			return true;
		}

		void CraftingEventsCraft() {

			if (buttonCraft1x.Update()) {
				MakeCrafting(1);
				return;
			}

			if (buttonCraft10x.Update()) {
				MakeCrafting(10);
				return;
			}

			if (buttonCraft100x.Update()) {
				MakeCrafting(100);
				return;
			}
		}

		void CraftingEvents() {
			if (SelectedCraftingRecipe!=-1) {
				#if DEBUG
				if (CurrentDeskCrafting==null) throw new Exception("Pravděpodobně chybí recept - doplň v GameMethods ("+((Items)InventoryCrafting[selectedCraftingItem].Id)+")");
				#endif

				CraftingIn[] slots=CurrentDeskCrafting[SelectedCraftingRecipe].Input;
				if (CurrentDeskCrafting!=null) {
					if (CurrentDeskCrafting.Length!=1) {
						if (buttonNext.Update()) {
							SelectedCraftingRecipe++;
							if (SelectedCraftingRecipe==CurrentDeskCrafting.Length)SelectedCraftingRecipe=0;
							SetNeed();
						}

						if (buttonPrev.Update()) {
							SelectedCraftingRecipe--;
							if (SelectedCraftingRecipe==-1)SelectedCraftingRecipe=CurrentDeskCrafting.Length-1;
							SetNeed();
						}
					}
				}

				int i = 0;
				for (int y = 0; y<2; y++) {
					for (int x = 0; x<6; x++) {
						if (slots.Length==i) break;
						CraftingIn slot=slots[i];
						ItemNonInv[] item=slot.ItemSlot;
						if (item.Length>1) {
							if (mouseLeftDown) {
								if (In40(Global.WindowWidthHalf-300+4+200+80+40+8+x*40,y*40+Global.WindowHeightHalf-200+2+4+200+8+8)) {
									displayPopUpWindow=true;
									PopUpWindowChoosingPotencialdItem=i;
									PopUpWindowSelectedItem=-1;
									ShowPopUpWindow();
								}
							}
						}
						i++;
					}
				}
			}
		}

		void CraftingEventsPlus() {
			int AddH=35;
			if (SelectedCraftingRecipe!=-1) {
				#if DEBUG
				if (CurrentDeskCrafting==null) throw new Exception("Pravděpodobně chybí recept - doplň v GameMethods");
				#endif

				CraftingIn[] slots=CurrentDeskCrafting[SelectedCraftingRecipe].Input;
				if (CurrentDeskCrafting!=null) {
					if (CurrentDeskCrafting.Length!=1) {
						if (buttonNext.Update()) {
							SelectedCraftingRecipe++;
							if (SelectedCraftingRecipe==CurrentDeskCrafting.Length)SelectedCraftingRecipe=0;
							SetNeed();
						}

						if (buttonPrev.Update()) {
							SelectedCraftingRecipe--;
							if (SelectedCraftingRecipe==-1)SelectedCraftingRecipe=CurrentDeskCrafting.Length-1;
							SetNeed();
						}
					}
				}

				int i = 0;
				for (int y = 0; y<2; y++) {
					for (int x = 0; x<6; x++) {
						if (slots.Length==i) break;
						CraftingIn slot=slots[i];
						ItemNonInv[] item=slot.ItemSlot;
						if (item.Length>1) {
							if (mouseLeftDown) {
								if (In40(Global.WindowWidthHalf-300+4+200+80+40+8+x*40,y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH)) {
									displayPopUpWindow=true;
									PopUpWindowChoosingPotencialdItem=i;
									PopUpWindowSelectedItem=-1;
									ShowPopUpWindow();
								}
							}
						}
						i++;
					}
				}
			}
		}

		void MakeCrafting(int c) {
			if (CanCraft(c)) {
				for (int g=0; g<c; g++) {

					CraftingIn[] slots=CurrentDeskCrafting[SelectedCraftingRecipe].Input;//selectedCraftingItem

					foreach (CraftingIn d in slots) {
						if (d.SelectedItem==-1) return;
					}

					foreach (CraftingIn d in slots) {
						ItemNonInv item=d.ItemSlot[d.SelectedItem];
						ushort id=item.Id;

						if (id==(ushort)Items.BronzeIngot) AchievementBronzeAge=true;
						if (id==(ushort)Items.AxeIron) AchievementIronAge=true;
						if (id==(ushort)Items.AxeIron) AchievementIronAge=true;
						if (id==(ushort)Items.ShovelIron) AchievementIronAge=true;
						if (id==(ushort)Items.HammerIron) AchievementIronAge=true;
						if (id==(ushort)Items.HoeIron) AchievementIronAge=true;
						if (id==(ushort)Items.KnifeIron) AchievementIronAge=true;
						if (id==(ushort)Items.SawIron) AchievementIronAge=true;

						switch (item) {
							case ItemNonInvBasic it:
								if (GameMethods.IsItemInvBasic16(id)) {
									int remain=it.Count;
									for (int i=0; i<maxInvCount; i++) {
										if (InventoryNormal[i].Id==id) {
											ItemInvBasic16 ininv=(ItemInvBasic16)InventoryNormal[i];
											if (ininv.GetCount<=remain) {
												remain-=ininv.GetCount;
												InventoryNormal[i]=itemBlank;
											} else {
												ininv.SetCount=ininv.GetCount-remain;
												remain=0;
												break;
											}
										}
									}
								} else {
									int remain=it.Count;
									for (int i=0; i<maxInvCount; i++) {
										if (InventoryNormal[i].Id==id) {
											ItemInvBasic32 ininv=(ItemInvBasic32)InventoryNormal[i];
											if (ininv.GetCount<=remain) {
												remain-=ininv.GetCount;
												InventoryNormal[i]=itemBlank;
											} else {
												ininv.SetCount=ininv.GetCount-remain;
												remain=0;
												break;
											}
										}
									}
								}
								break;

							case ItemNonInvNonStackable it:
								if (GameMethods.IsItemInvNonStackable32(id)) {
									for (int i=0; i<maxInvCount; i++) {
										if (InventoryNormal[i].Id==id) {
											ItemInvNonStackable32 ininv=(ItemInvNonStackable32)InventoryNormal[i];
											InventoryNormal[i]=itemBlank;
										}
									}
								}
								break;

							case ItemNonInvBasicColoritzedNonStackable it:
								if (GameMethods.IsItemInvNonStackable32(id)) {
									for (int i=0; i<maxInvCount; i++) {
										if (InventoryNormal[i].Id==id) {
											ItemInvBasicColoritzed32NonStackable ininv=(ItemInvBasicColoritzed32NonStackable)InventoryNormal[i];
											InventoryNormal[i]=itemBlank;
										}
									}
								}
								break;

							case ItemNonInvTool it:
								if (GameMethods.IsItemInvTool16(id)) {
									int remain=it.Count;
									for (int i=0; i<maxInvCount; i++) {
										if (InventoryNormal[i].Id==id) {
											ItemInvTool16 ininv=(ItemInvTool16)InventoryNormal[i];
											if (ininv.GetCount<=remain) {
												remain-=ininv.GetCount;
												ushort newid=GameMethods.ToolToBasic(id);
												if (newid==0) InventoryNormal[i]=itemBlank;
												else InventoryNormal[i]=new ItemInvTool16(
													ItemIdToTexture(id),
													newid,
													1,
												 //   GameMethods.ToolMax(id),
													(int)ininv.posTex.X,
													(int)ininv.posTex.Y
												);
											} else {
												ininv.SetCount=ininv.GetCount-remain;
												remain=0;
												break;
											}
										}
									}
								} else {
									int remain=it.Count;
									for (int i=0; i<maxInvCount; i++) {
										if (InventoryNormal[i].Id==id) {
											ItemInvTool32 ininv=(ItemInvTool32)InventoryNormal[i];
											if (ininv.GetCount<=remain) {
												remain-=ininv.GetCount;
												ushort newid=GameMethods.ToolToBasic(id);
												if (newid==0) InventoryNormal[i]=itemBlank;
												else InventoryNormal[i]=new ItemInvTool32(
													ItemIdToTexture(id),
													newid,
													1,
												 //   GameMethods.ToolMax(id),
													(int)ininv.posTex.X,
													(int)ininv.posTex.Y
												);
											} else {
												ininv.SetCount=ininv.GetCount-remain;
												remain=0;
												break;
											}
										}
									}
								}
								break;
						}
						//int count=item.Y;
						//for (int i=0; i<maxInvCount; i++) {
						//    if (InventoryNormal[i].Id==item.X) {
						//        if (InventoryNormal[i].Y>count) {
						//            InventoryNormal[i].Y-=count;
						//            break;
						//        } else {
						//            count-=InventoryNormal[i].Y;
						//            if (item.X>(ushort)Items._SystemMaxTools) {
						//                InventoryNormal[i].X=0;
						//                InventoryNormal[i].Y=0;
						//            }  else {
						//                Items expec=GameMethods.ToolToBasic((Items)InventoryNormal[i].X);
						//                if (expec==Items.None) {
						//                    InventoryNormal[i].X=0;
						//                    InventoryNormal[i].Y=0;
						//                } else {
						//                    InventoryNormal[i].Y=1;
						//                    InventoryNormal[i].X=(int)expec;
						//                }
						//            }
						//        }
						//    }
						//}
					}

					foreach (CraftingOut d in CurrentDeskCrafting[SelectedCraftingRecipe].Output){//selectedCraftingItem
						if (d.EveryTime) AddItemToPlayer(d.Item);
						else{
							if (random.Double()<d.ChanceToDrop) AddItemToPlayer(d.Item);
						}
						//if (d.EveryTime) ItemDrop(d.Item.X,d.Item.Y, PlayerX-11, PlayerY-16);
						//else ItemDrop(d.Item.X,random.RandomInt(d.ChanceMin,d.ChanceMax), PlayerX-11, PlayerY-16);
					}
				}
			}
			SetNeed();
		}

		void SetNeed() {
			if (SelectedCraftingRecipe==-1)return;
			if (CurrentDeskCrafting==null)return;
			CraftingIn[] slots=CurrentDeskCrafting[SelectedCraftingRecipe].Input;

			int i = 0;
			for (int y = 0; y<2; y++) {
				for (int x = 0; x<6; x++) {
					if (slots.Length==i) break;
					CraftingIn slot=slots[i];
					ItemNonInv[] item=slot.ItemSlot;

					if (slot.SelectedItem==-1) {
						 slot.TmpSelected=random.Int(item.Length);
						 slot.Texture=ItemIdToTexture(item[slot.TmpSelected].Id);
					}else{
					   // ItemNonInv selectedSlot=item[slot.SelectedItem];
						if (item.Length==1) {
							switch (slot.ItemSlot[0]) {
								case ItemNonInvTool t:
									slot.Texture=ItemIdToTexture(item[0].Id);
									if (t.Count==-1){
										slot.HaveItemInInventory=TotalItemsInInventoryForAllTypes(slot.ItemSlot[0].Id)>0;
									}else{
										slot.HaveItemInInventory=TotalItemsInInventoryForAllTypes(slot.ItemSlot[0].Id)>=t.Count;
									}
									break;

								case ItemNonInvBasic t:
									slot.Texture=ItemIdToTexture(item[0].Id);
									slot.HaveItemInInventory=TotalItemsInInventoryForAllTypes(slot.ItemSlot[0].Id)>=t.Count;
									break;

								//case ItemNonInvNonStackable f:
								//    slot.Texture=ItemIdToTexture(item[0].Id);
								//    slot.HaveItemInInventory=TotalItemsInInventoryForAllTypes(slot.ItemSlot[0].Id)>=1;
								//    break;

								//case ItemNonInvBasicColoritzedNonStackable f:
								//    slot.Texture=ItemIdToTexture(item[0].Id);
								//    slot.HaveItemInInventory=TotalItemsInInventoryForAllTypes(slot.ItemSlot[0].Id)>=1;
								//    break;

								default:
									slot.Texture=ItemIdToTexture(item[0].Id);
									slot.HaveItemInInventory=TotalItemsInInventoryForAllTypes(slot.ItemSlot[0].Id)>=1;
									break;
							}

						}else{
							slot.Texture=ItemIdToTexture(item[slot.SelectedItem].Id);
						}
					}

				  i++;


				}
			}
		}

		void DrawInventoryNormal() {
			int xx=0, yh=0;

			//Slots
			for (int i=(inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
			if (i>maxInvCount) break;
				spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+200+4+4+xx, Global.WindowHeightHalf-200+2+4+yh), ColorWhite);

				//if (InventoryNormal[i].X!=0) {
				//    if (!invMove || (invMove && invStartInventory,invStartId!=i)) {
				//        Texture2D tex=ItemIdToTexture(InventoryNormal[i].X);
				//        if (tex!=null) GameDraw.DrawItemInInventory(tex,InventoryNormal[i],Global.WindowWidthHalf-300+4+200+4+4+xx+4,Global.WindowHeightHalf-200+2+4+yh+4);
				//    }
				//}
				xx+=40;

				if (xx==9*40) {
					xx=0;
					yh+=40;
				}
			}

			xx=0;

			for (int i=(inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
			if (i>maxInvCount) break;
				if (InventoryNormal[i].Id!=0) {
					InventoryNormal[i].Draw();
				}
				xx+=40;

				if (xx==9*40) {
					xx=0;
				}
			}

			if (maxInvCount>49) {
				inventoryScrollbar.maxheight=((maxInvCount-5)/9)*40;
				inventoryScrollbar.height=5*40;
				inventoryScrollbar.ButtonDraw(/*newMouseState.X,newMouseState.Y,mouseLeftDown,*/Global.WindowWidthHalf+300-20-4, Global.WindowHeightHalf-200+2+4);
			}
		}

		void DrawInventoryWithDIntMoving() {
			int xx=0, yh=0;
			for (int i=(inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
				if (i>maxInvCount) break;
				spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+200+4+4+xx, Global.WindowHeightHalf-200+2+4+yh), ColorWhite);

				xx+=40;

				if (xx==9*40) {
					xx=0;
					yh+=40;
				}
			}
			xx=0;
			yh=0;

			for (int i=(inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
				if (i>maxInvCount) break;

				if (InventoryNormal[i].Id!=0) {
					InventoryNormal[i].Draw();

					if (In40(Global.WindowWidthHalf-300+4+200+4+4+xx, Global.WindowHeightHalf-200+2+4+yh)) MouseItemNameEvent(InventoryNormal[i].Id);
				}
				xx+=40;

				if (xx==9*40) {
					xx=0;
					yh+=40;
				}
			}

			if (maxInvCount>49) {
				inventoryScrollbar.maxheight=((maxInvCount-5)/9)*40;
				inventoryScrollbar.height=5*40;
				inventoryScrollbar.ButtonDraw(Global.WindowWidthHalf+300-20-4, Global.WindowHeightHalf-200+2+4);
			}

			if (inventory==InventoryType.BoxAdv
			|| inventory==InventoryType.BoxWooden
			|| inventory==InventoryType.Charger
			|| inventory==InventoryType.Composter
			|| inventory==InventoryType.Creative
			|| inventory==InventoryType.Miner
			|| inventory==InventoryType.Shelf) {
				spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-300+4+200+4+4+8*40, Global.WindowHeightHalf-200+2+4+40*5), ColorWhite);
				spriteBatch.Draw(TextureBin,new Vector2(Global.WindowWidthHalf-300+4+200+4+4+8*40+4, Global.WindowHeightHalf-200+2+4+40*5+4), ColorWhite);
			}
		}

		//void DrawRightInventoryNormal() {

		//    // Slots
		//    for (int i = 0; i<5; i++) {
		//        if (boxSelected==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidth-40, Global.WindowHeightHalf-80+i*40), Color.LightBlue);
		//        else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidth-40, Global.WindowHeightHalf-80+i*40), ColorWhite);
		//    }

		//    // Items
		//    for (int i = 0; i<5; i++) {
		//        invStartInventory[i].Draw();
		//    }
		//}

		void DrawSideInventory() {
			int x=Global.WindowWidth-40;
			int y=Global.WindowHeightHalf-80;
		   // Vector2 vec = new Vector2(x,y);

			//slots
			for (int i = 0; i<5; i++) {
				if (boxSelected==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(x, y), ColorLightBlue);
				else spriteBatch.Draw(inventorySlotTexture, new Vector2(x, y), ColorWhite);
				y+=40;
			}

			//items
			for (int i = 0; i<5; i++) InventoryNormal[i].Draw();
		}

		void InventoryDrawClothes() {
			for (int i=0; i<8; i++) InventoryClothes[i].Draw();
		}
		#endregion

		#region Items
		void DropItemToPos(ItemNonInv i, DInt d) {
			DroppedItems.Add(new Item{
				X=d.X,
				Y=d.Y,
				item=i,
				Texture=ItemIdToTexture(i.Id)
			});
		}

		void DropItemToPos(ItemNonInv i, int x, int y) {
			DroppedItems.Add(new Item {
				X=x,
				Y=y,
				item=i,
				Texture=ItemIdToTexture(i.Id)
			});
		}

		void DropItemToPos(ItemNonInv i, float x, float y) {
			DroppedItems.Add(new Item {
				X=(int)x,
				Y=(int)y,
				item=i,
				Texture=ItemIdToTexture(i.Id)
			});
		}

		void UpdateItem(List<Item> list) {
			foreach (Item i in list) {
				if (i.X>PlayerX-11-16) {
					if (i.X<PlayerX+11) {
						if (i.Y>PlayerY-20) {
							if (i.Y<PlayerY+20) {
								AddItemToPlayer(i.item);
								list.Remove(i);
								return;
							}
						}
					}
				}

				if (terrain[i.X/16]!=null) {
					if (i.Y>0){
						if (i.Y<124*16) {
							if (!terrain[i.X/16].IsSolidBlocks[i.Y/16+1]) {
								i.Y+=2;
							}
						}
					}
				}

				if (i.Y>5000) {
					list.Remove(i);
					return;
				}
			}
		}

		void ItemEat() {
			if (barEat>1) {
			switch (InventoryNormal[boxSelected].Id) {
				case (ushort)Items.Banana:
					barEat -=10;
					barWater -=1;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Olive:
					barEat -=2;
					  barWater -=0.1f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Toadstool:
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					Die(Lang.Texts[166]);
					break;

				case (ushort)Items.Boletus:
					barEat -=1.5f;
					barWater -=0.1f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Champignon:
					barEat -=1.5f;
					barWater -=0.1f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Lemon:
					barEat -=5;
					barWater -=3;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Orange:
					barEat -=9;
					barWater -=3;
					InventoryRemoveSelectedItem();
				 if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Cherry:
					barEat -=2;
					barWater -=0.1f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics)  SoundEffects.Eat.Play();
					break;

				case (ushort)Items.BucketWater:
					barEat -=0.01f;
					barWater -=20;
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Bucket,1), PlayerX, PlayerY);
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics)  SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Dandelion:
					barEat -=2;
					barWater -=0.01f;
					InventoryRemoveSelectedItem();
				   if (Global.HasSoundGraphics)  SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Plum:
					barEat -=5;
					barWater -=0.05f;
					InventoryRemoveSelectedItem();
				  if (Global.HasSoundGraphics)   SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Rashberry:
					barEat -=2;
					barWater -=0.3f;
					InventoryRemoveSelectedItem();
				  if (Global.HasSoundGraphics)   SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Apple:
					barEat -=12;
					barWater--;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics)SoundEffects.Eat.Play();
					break;

				case (ushort)Items.RabbitMeatCooked:
					barEat -=30;
					barWater -=2;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.RabbitMeat:
					barEat -=10;
					barWater -=1;
					if (random.Bool_20Percent()) {
						barHeart +=5;
						if (barHeart>32)barHeart=32;
					}
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Strawberry:
					barEat -=3;
					barWater -=0.5f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.WheatSeeds:
					barEat--;
					barWater -=0.002f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Blueberries:
					barEat-=2;
					barWater -=0.2f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.boiledEgg:
					barEat-=2;
					barWater -=0.2f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.BowlWithMushrooms:
					barEat-=15;
					barWater -=5f;
					InventoryRemoveSelectedItem();
					AddItemToPlayer(new ItemNonInvBasic((ushort)Items.BowlEmpty,1));
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.BowlWithVegetables:
					barEat-=15;
					barWater -=5f;
					InventoryRemoveSelectedItem();
					AddItemToPlayer(new ItemNonInvBasic((ushort)Items.BowlEmpty,1));
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;
				}
			}

			//drink
			if (barWater>1) {
				switch (InventoryNormal[boxSelected].Id) {
					case (ushort)Items.BottleWater:
						{
							ItemInvTool32 bottle=(ItemInvTool32)InventoryNormal[boxSelected];
							float d=barWater-bottle.GetCount/3f;
							if (d<0) {
								barWater=0;
								InventoryNormal[boxSelected]=new ItemInvBasic32(bottleEmptyTexture,(ushort)Items.Bottle,1,(int)bottle.posTex.X,(int)bottle.posTex.Y);
							}else{
								bottle.SetCount=bottle.GetCount-(int)(barWater*3);
								barWater=d;
							}
						}
						break;

					case (ushort)Items.BucketWater:
						{
							ItemInvTool32 bottle=(ItemInvTool32)InventoryNormal[boxSelected];
							float d=barWater-bottle.GetCount/3f;
							if (d<0) {
								barWater=0;
								InventoryNormal[boxSelected]=new ItemInvBasic32(ItemBucketTexture,(ushort)Items.Bucket,1,(int)bottle.posTex.X,(int)bottle.posTex.Y);
							}else{
								bottle.SetCount=bottle.GetCount-(int)(barWater*3);
								barWater=d;
							}
						}
						break;
				}
			}

			if (barEat>32)barEat=32;
			if (barWater>32)barWater=32;
			if (barEat<0)barEat=0;
			if (barWater<0)barWater=0;
		}

		// Crafting basic
		void SetInvCraftingBlocks() {
			ushort[] items={
				(ushort)Items.Gravel,
				(ushort)Items.HayBlock,
			};
			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvCraftingMashines() {
			ushort[] items={
				(ushort)Items.Desk,
				(ushort)Items.Ladder,
			};
			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvCraftingTools() {
			ushort[] items={
				// Stone
				(ushort)Items.StoneHead,
				(ushort)Items.PickaxeStone,
				(ushort)Items.AxeStone,
				(ushort)Items.ShovelStone,
				(ushort)Items.HoeStone,

				// Copper
				(ushort)Items.PickaxeCopper,
				(ushort)Items.AxeCopper,
				(ushort)Items.ShovelCopper,
				(ushort)Items.HoeCopper,
				(ushort)Items.KnifeCopper,
				(ushort)Items.ShearsCopper,
				(ushort)Items.HammerCopper,

				//Bronze
				(ushort)Items.PickaxeBronze,
				(ushort)Items.AxeBronze,
				(ushort)Items.ShovelBronze,
				(ushort)Items.HoeBronze,
				(ushort)Items.KnifeBronze,
				(ushort)Items.ShearsBronze,
				(ushort)Items.HammerBronze,

				// Gold
				(ushort)Items.PickaxeGold,
				(ushort)Items.AxeGold,
				(ushort)Items.ShovelGold,
				(ushort)Items.HoeGold,
				(ushort)Items.KnifeGold,
				(ushort)Items.ShearsGold,
				(ushort)Items.HammerGold,

				// Iron
				(ushort)Items.PickaxeIron,
				(ushort)Items.AxeIron,
				(ushort)Items.ShovelIron,
				(ushort)Items.HoeIron,
				(ushort)Items.KnifeIron,
				(ushort)Items.ShearsIron,
				(ushort)Items.HammerIron,

				// Steel
				(ushort)Items.PickaxeSteel,
				(ushort)Items.AxeSteel,
				(ushort)Items.ShovelSteel,
				(ushort)Items.HoeSteel,
				(ushort)Items.KnifeSteel,
				(ushort)Items.ShearsSteel,
				(ushort)Items.HammerSteel,

				// Aluminium
				(ushort)Items.PickaxeAluminium,
				(ushort)Items.AxeAluminium,
				(ushort)Items.ShovelAluminium,
				(ushort)Items.HoeAluminium,
				(ushort)Items.KnifeAluminium,
				(ushort)Items.ShearsAluminium,
				(ushort)Items.HammerAluminium,

				(ushort)Items.TorchOFF,
			};
			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvCraftingNature() {
			ushort[] items={
				(ushort)Items.Stick,
				(ushort)Items.Sticks,
				(ushort)Items.Leave,
				(ushort)Items.Seeds,
				(ushort)Items.WheatSeeds,
			};
			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvCraftingItems() {
			ushort[] items={
				(ushort)Items.Flag,
				(ushort)Items.MediumStone,
				(ushort)Items.SmallStone,

				(ushort)Items.DyeOrange,
				(ushort)Items.DyeDarkRed,
				(ushort)Items.DyeRoseQuartz,
				(ushort)Items.DyePink,
				(ushort)Items.DyeMagenta,
				(ushort)Items.DyeLightBlue,
				(ushort)Items.DyeDarkBlue,
				(ushort)Items.DyeTeal,
				(ushort)Items.DyeLightGreen,
				(ushort)Items.DyeDarkGreen,
				(ushort)Items.DyeArmy,
				(ushort)Items.DyeBrown,
				  
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		// Crafting adv
		void SetInvCraftingBlocksA() {
			inventoryScrollbarValueCrafting=0;
			ushort[] items={
				(ushort)Items.Stonerubble,
				(ushort)Items.Gravel,
				(ushort)Items.Sand,
				(ushort)Items.Planks,
				(ushort)Items.AdvancedSpaceBlock,
				(ushort)Items.AdvancedSpaceFloor,
				(ushort)Items.AdvancedSpacePart1,
				(ushort)Items.AdvancedSpacePart2,
				(ushort)Items.AdvancedSpacePart3,
				(ushort)Items.AdvancedSpacePart4,
				(ushort)Items.AdvancedSpaceWindow,
				(ushort)Items.Bricks,
				(ushort)Items.Roof1,
				(ushort)Items.Roof2,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;

			ReSetCraftingInventoryPositions();
		}

		void SetInvCraftingMashinesA() {
			inventoryScrollbarValueCrafting=0;
			 ushort[] items={
				(ushort)Items.Desk,
				(ushort)Items.Ladder,
				(ushort)Items.Door,
				(ushort)Items.Composter,
				(ushort)Items.Shelf,
				(ushort)Items.BoxWooden,
				(ushort)Items.BoxAdv,
				(ushort)Items.BucketForRubber,
				(ushort)Items.Barrel,

				(ushort)Items.SolarPanel,
				(ushort)Items.WindMill,
				(ushort)Items.WaterMill,

				(ushort)Items.Label,

				(ushort)Items.FurnaceElectric,
				(ushort)Items.FurnaceStone,
				(ushort)Items.Macerator,
				(ushort)Items.Miner,
				(ushort)Items.Radio,
				(ushort)Items.Lamp,
				(ushort)Items.Charger,
				(ushort)Items.SewingMachine,
				(ushort)Items.OxygenMachine,
				(ushort)Items.Rocket
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;

			ReSetCraftingInventoryPositions();
		}

		void SetInvCraftingToolsA() {
		inventoryScrollbarValueCrafting=0;
			 ushort[] items={
				(ushort)Items.StoneHead,

				// Stone
				(ushort)Items.PickaxeStone,
				(ushort)Items.AxeStone,
				(ushort)Items.ShovelStone,
				(ushort)Items.HoeStone,

				// Copper
				(ushort)Items.PickaxeCopper,
				(ushort)Items.AxeCopper,
				(ushort)Items.ShovelCopper,
				(ushort)Items.HoeCopper,
				(ushort)Items.KnifeCopper,
				(ushort)Items.ShearsCopper,
				(ushort)Items.SawCopper,
				(ushort)Items.HammerCopper,

				// Bronze
				(ushort)Items.PickaxeCopper,
				(ushort)Items.AxeCopper,
				(ushort)Items.ShovelCopper,
				(ushort)Items.HoeCopper,
				(ushort)Items.KnifeCopper,
				(ushort)Items.ShearsCopper,
				(ushort)Items.SawCopper,
				(ushort)Items.HammerCopper,

				// Gold
				(ushort)Items.PickaxeGold,
				(ushort)Items.AxeGold,
				(ushort)Items.ShovelGold,
				(ushort)Items.HoeGold,
				(ushort)Items.KnifeGold,
				(ushort)Items.ShearsGold,
				(ushort)Items.SawGold,
				(ushort)Items.HammerGold,

				// Iron
				(ushort)Items.PickaxeIron,
				(ushort)Items.AxeIron,
				(ushort)Items.ShovelIron,
				(ushort)Items.HoeIron,
				(ushort)Items.KnifeIron,
				(ushort)Items.ShearsIron,
				(ushort)Items.SawIron,
				(ushort)Items.HammerIron,

				// Steel
				(ushort)Items.PickaxeSteel,
				(ushort)Items.AxeSteel,
				(ushort)Items.ShovelSteel,
				(ushort)Items.HoeSteel,
				(ushort)Items.KnifeSteel,
				(ushort)Items.ShearsSteel,
				(ushort)Items.SawSteel,
				(ushort)Items.HammerSteel,

				// Aluminium
				(ushort)Items.PickaxeAluminium,
				(ushort)Items.AxeAluminium,
				(ushort)Items.ShovelAluminium,
				(ushort)Items.HoeAluminium,
				(ushort)Items.KnifeAluminium,
				(ushort)Items.ShearsAluminium,
				(ushort)Items.SawAluminium,
				(ushort)Items.HammerAluminium,


				(ushort)Items.ElectricDrill,
				(ushort)Items.ElectricSaw,
				(ushort)Items.Gun,
				(ushort)Items.Bucket,
				(ushort)Items.TorchOFF,
				(ushort)Items.AirTank,
				(ushort)Items.AirTank2,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvCraftingNatureA() {
		inventoryScrollbarValueCrafting=0;
			 ushort[] items={
				(ushort)Items.Stick,
				(ushort)Items.Sticks,
				(ushort)Items.Leave,
				(ushort)Items.HayBlock,
				(ushort)Items.MudIngot,
				(ushort)Items.Leave,
				(ushort)Items.Seeds,
				(ushort)Items.WheatSeeds,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvCraftingItemsA() {
			inventoryScrollbarValueCrafting=0;
			 ushort[] items={
				(ushort)Items.Flag,
				(ushort)Items.MediumStone,
				(ushort)Items.SmallStone,

				(ushort)Items.Nail,
				(ushort)Items.Rod,
				(ushort)Items.Ammo,
				(ushort)Items.Gunpowder,
				(ushort)Items.BronzeDust,

				(ushort)Items.plateAluminium,
				(ushort)Items.PlateBronze,
				(ushort)Items.PlateCopper,
				(ushort)Items.PlateGold,
				(ushort)Items.PlateIron,

				(ushort)Items.BareLabel,
				(ushort)Items.Rezistance,
				(ushort)Items.Condenser,
				(ushort)Items.Diode,
				(ushort)Items.Tranzistor,
				(ushort)Items.Bulb,
				(ushort)Items.ItemBattery,
				(ushort)Items.Motor,

				(ushort)Items.Circuit,
				(ushort)Items.BigCircuit,

				(ushort)Items.Yarn,
				(ushort)Items.Cloth,
				(ushort)Items.Rope,

				(ushort)Items.AngelHair,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;

			ReSetCraftingInventoryPositions();
		}

		// Creative
		void SetInvCreativeBlocks() {
			ushort[] items={
				(ushort)Items.StoneSandstone,
				(ushort)Items.StoneSchist,
				(ushort)Items.StoneBasalt,
				(ushort)Items.StoneDiorit,
				(ushort)Items.StoneDolomite,
				(ushort)Items.StoneGabbro,
				(ushort)Items.StoneGneiss,
				(ushort)Items.StoneLimestone,
				(ushort)Items.StoneRhyolite,
				(ushort)Items.StoneFlint,
				(ushort)Items.StoneAnorthosite,
				(ushort)Items.StoneMudstone,

				(ushort)Items.OreCoal,
				(ushort)Items.OreCopper,
				(ushort)Items.OreTin,
				(ushort)Items.OreIron,
				(ushort)Items.OreAluminium,
				(ushort)Items.OreSilver,
				(ushort)Items.OreGold,
				(ushort)Items.OreSulfur,
				(ushort)Items.OreSaltpeter,

				(ushort)Items.Lava,
				(ushort)Items.Stonerubble,
				(ushort)Items.Gravel,
				(ushort)Items.Sand,
				(ushort)Items.Dirt,
				(ushort)Items.Compost,
				(ushort)Items.Ice,
				(ushort)Items.Snow,
				(ushort)Items.SnowTop,
				(ushort)Items.GrassBlockForest,
				(ushort)Items.GrassBlockDesert,
				(ushort)Items.GrassBlockHills,
				(ushort)Items.GrassBlockJungle,
				(ushort)Items.GrassBlockPlains,
				(ushort)Items.GrassBlockClay,
				(ushort)Items.GrassBlockCompost,

				(ushort)Items.AppleLeaves,
				(ushort)Items.AppleLeavesWithApples,
				(ushort)Items.WoodApple,
				(ushort)Items.CherryLeaves,
				(ushort)Items.CherryLeavesWithCherries,
				(ushort)Items.WoodCherry,
				(ushort)Items.PlumLeaves,
				(ushort)Items.PlumLeavesWithPlums,
				(ushort)Items.WoodPlum,
				(ushort)Items.OrangeLeaves,
				(ushort)Items.OrangeLeavesWithOranges,
				(ushort)Items.WoodOrange,
				(ushort)Items.LemonLeaves,
				(ushort)Items.LemonLeavesWithLemons,
				(ushort)Items.WoodLemon,
				(ushort)Items.LindenLeaves,
				(ushort)Items.WoodLinden,
				(ushort)Items.OakLeaves,
				(ushort)Items.WoodOak,
				(ushort)Items.PineLeaves,
				(ushort)Items.WoodPine,
				(ushort)Items.SpruceLeaves,
				(ushort)Items.WoodSpruce,

				(ushort)Items.AcaciaLeaves,
				(ushort)Items.AcaciaWood,

				(ushort)Items.EucalyptusLeaves,
				(ushort)Items.EucalyptusWood,

				(ushort)Items.MangroveLeaves,
				(ushort)Items.MangroveWood,

				(ushort)Items.OliveLeaves,
				(ushort)Items.OliveLeavesWithOlives,
				(ushort)Items.OliveWood,
				(ushort)Items.RubberTreeLeaves,
				(ushort)Items.RubberTreeWood,
				(ushort)Items.WillowLeaves,
				(ushort)Items.WillowWood,
				(ushort)Items.KapokLeaves,
				(ushort)Items.KapokLeacesFlowering,
				(ushort)Items.KapokLeavesFibre,
				(ushort)Items.KapokWood,

				(ushort)Items.Planks,
				(ushort)Items.HayBlock,
				(ushort)Items.Glass,
				(ushort)Items.Bricks,
				(ushort)Items.Roof1,
				(ushort)Items.Roof2,
				(ushort)Items.ChristmasStar,

				(ushort)Items.AdvancedSpaceBlock,
				(ushort)Items.AdvancedSpaceFloor,
				(ushort)Items.AdvancedSpaceWindow,
				(ushort)Items.AdvancedSpacePart1,
				(ushort)Items.AdvancedSpacePart2,
				(ushort)Items.AdvancedSpacePart3,
				(ushort)Items.AdvancedSpacePart4,

				(ushort)Items.BackSandstone,
				(ushort)Items.BackSchist,
				(ushort)Items.BackBasalt,
				(ushort)Items.BackDiorit,
				(ushort)Items.BackDolomite,
				(ushort)Items.BackGabbro,
				(ushort)Items.BackGneiss,
				(ushort)Items.BackLimestone,
				(ushort)Items.BackRhyolite,
				(ushort)Items.BackFlint,
				(ushort)Items.BackAnorthosite,
				(ushort)Items.BackMudstone,

				(ushort)Items.BackCoal,
				(ushort)Items.BackCopper,
				(ushort)Items.BackTin,
				(ushort)Items.BackIron,
				(ushort)Items.BackAluminium,
				(ushort)Items.BackSilver,
				(ushort)Items.BackGold,
				(ushort)Items.BackSulfur,
				(ushort)Items.BackSaltpeter,

				(ushort)Items.AdvancedSpaceBack,
				(ushort)Items.BackClay,
				(ushort)Items.BackCobblestone,
				(ushort)Items.BackSand,
				(ushort)Items.BackRegolite,
				(ushort)Items.BackDirt,
			};
			creativeScrollbar.scale=0;
			for (int i=0; i<items.Length; i++) SetItemCreative(InventoryCreative, i, items[i]);
			for (int j = items.Length; j<inventoryScrollbarValueCraftingMax; j++) InventoryCreative[j]=itemBlank;
			inventoryScrollbarValueCraftingMax=items.Length;

			ReSetInventoryCreativePositions();
		}

		void SetInvCreativePlants() {
			ushort[] items={
				(ushort)Items.Dandelion,
				(ushort)Items.PlantViolet,
				(ushort)Items.PlantRose,
				(ushort)Items.PlantOrchid,
				(ushort)Items.Heater,
				(ushort)Items.Alore,

				(ushort)Items.Boletus,
				(ushort)Items.Champignon,
				(ushort)Items.Toadstool,
				(ushort)Items.CactusSmall,
				(ushort)Items.CactusBig,
				(ushort)Items.Coral,
				(ushort)Items.PlantSeaweed,

				(ushort)Items.GrassDesert,
				(ushort)Items.GrassForest,
				(ushort)Items.GrassHills,
				(ushort)Items.GrassJungle,
				(ushort)Items.GrassPlains,

				(ushort)Items.SpruceSapling,
				(ushort)Items.WillowSapling,
				(ushort)Items.OakSapling,
				(ushort)Items.LindenSapling,
				(ushort)Items.EucalyptusSapling,
				(ushort)Items.MangroveSapling,
				(ushort)Items.PineSapling,
				(ushort)Items.RubberTreeSapling,
				(ushort)Items.KapokSapling,

				(ushort)Items.AppleSapling,
				(ushort)Items.CherrySapling,
				(ushort)Items.PlumSapling,

				(ushort)Items.OliveSapling,
				(ushort)Items.OrangeSapling,
				(ushort)Items.LemonSapling,

				(ushort)Items.PlantStrawberry,
				(ushort)Items.PlantRashberry,
				(ushort)Items.PlantRashberry,
				(ushort)Items.Flax,
				(ushort)Items.PlantOnion,
				(ushort)Items.PlantPeas,
				(ushort)Items.PlantCarrot,
				(ushort)Items.SugarCane,

				(ushort)Items.Seeds,
				(ushort)Items.WheatSeeds,
				(ushort)Items.FlaxSeeds,

				(ushort)Items.Hay,
				(ushort)Items.WheatStraw,
				(ushort)Items.Stick,
				(ushort)Items.Sticks,
				(ushort)Items.Leave,
			};
			creativeScrollbar.scale=0;
			for (int i=0; i<items.Length; i++) SetItemCreative(InventoryCreative, i, items[i]);
			for (int j = items.Length; j<inventoryScrollbarValueCraftingMax; j++) InventoryCreative[j]=itemBlank;
			inventoryScrollbarValueCraftingMax=items.Length;

			ReSetInventoryCreativePositions();
		}

		void SetInvCreativeMashines() {
			ushort[] items ={
				(ushort)Items.Desk,
				(ushort)Items.FurnaceStone,
				(ushort)Items.Shelf,
				(ushort)Items.BoxWooden,
				(ushort)Items.BoxAdv,
				(ushort)Items.Ladder,
				(ushort)Items.Composter,
				(ushort)Items.Door,
				(ushort)Items.BucketForRubber,
				(ushort)Items.Barrel,

				(ushort)Items.WindMill,
				(ushort)Items.SolarPanel,
				(ushort)Items.WaterMill,
				(ushort)Items.Label,
				(ushort)Items.Lamp,
				(ushort)Items.FurnaceElectric,
				(ushort)Items.Macerator,
				(ushort)Items.Miner,
				(ushort)Items.Radio,
				(ushort)Items.Charger,
				(ushort)Items.SewingMachine,
				(ushort)Items.OxygenMachine,
				(ushort)Items.Rocket,
			};
			creativeScrollbar.scale=0;
			for (int i=0; i<items.Length; i++) SetItemCreative(InventoryCreative, i, items[i]);
			for (int j = items.Length; j<inventoryScrollbarValueCraftingMax; j++) InventoryCreative[j]=itemBlank;
			inventoryScrollbarValueCraftingMax=items.Length;

			ReSetInventoryCreativePositions();
		}

		void SetInvCreativeTools() {
			ushort[] items ={
				(ushort)Items.StoneHead,

				// Stone
				(ushort)Items.PickaxeStone,
				(ushort)Items.AxeStone,
				(ushort)Items.ShovelStone,
				(ushort)Items.HoeStone,

				// Copper
				(ushort)Items.PickaxeCopper,
				(ushort)Items.AxeCopper,
				(ushort)Items.ShovelCopper,
				(ushort)Items.HoeCopper,
				(ushort)Items.KnifeCopper,
				(ushort)Items.ShearsCopper,
				(ushort)Items.SawCopper,
				(ushort)Items.HammerCopper,

				// Bronze
				(ushort)Items.PickaxeCopper,
				(ushort)Items.AxeCopper,
				(ushort)Items.ShovelCopper,
				(ushort)Items.HoeCopper,
				(ushort)Items.KnifeCopper,
				(ushort)Items.ShearsCopper,
				(ushort)Items.SawCopper,
				(ushort)Items.HammerCopper,

				// Gold
				(ushort)Items.PickaxeGold,
				(ushort)Items.AxeGold,
				(ushort)Items.ShovelGold,
				(ushort)Items.HoeGold,
				(ushort)Items.KnifeGold,
				(ushort)Items.ShearsGold,
				(ushort)Items.SawGold,
				(ushort)Items.HammerGold,

				// Iron
				(ushort)Items.PickaxeIron,
				(ushort)Items.AxeIron,
				(ushort)Items.ShovelIron,
				(ushort)Items.HoeIron,
				(ushort)Items.KnifeIron,
				(ushort)Items.ShearsIron,
				(ushort)Items.SawIron,
				(ushort)Items.HammerIron,

				// Steel
				(ushort)Items.PickaxeSteel,
				(ushort)Items.AxeSteel,
				(ushort)Items.ShovelSteel,
				(ushort)Items.HoeSteel,
				(ushort)Items.KnifeSteel,
				(ushort)Items.ShearsSteel,
				(ushort)Items.SawSteel,
				(ushort)Items.HammerSteel,

				// Aluminium
				(ushort)Items.PickaxeAluminium,
				(ushort)Items.AxeAluminium,
				(ushort)Items.ShovelAluminium,
				(ushort)Items.HoeAluminium,
				(ushort)Items.KnifeAluminium,
				(ushort)Items.ShearsAluminium,
				(ushort)Items.SawAluminium,
				(ushort)Items.HammerAluminium,


				(ushort)Items.ElectricDrill,
				(ushort)Items.ElectricSaw,
				(ushort)Items.TorchElectricON,
				(ushort)Items.Gun,
				(ushort)Items.Ammo,
				(ushort)Items.AirTank,
				(ushort)Items.AirTank2,

				(ushort)Items.Bucket,
				(ushort)Items.BucketWater,
				(ushort)Items.Bottle,
				(ushort)Items.BottleWater,
				(ushort)Items.TestTube,
				(ushort)Items.TorchON,
				(ushort)Items.Backpack,

				(ushort)Items.Cap,
				(ushort)Items.Hat,
				(ushort)Items.Crown,
				(ushort)Items.SpaceHelmet,

				(ushort)Items.TShirt,
				(ushort)Items.SpaceSuit,
				(ushort)Items.Dress,
				(ushort)Items.Shirt,

				(ushort)Items.Jeans,
				(ushort)Items.Shorts,
				(ushort)Items.SpaceTrousers,
				(ushort)Items.ArmyTrousers,
				(ushort)Items.Skirt,

				(ushort)Items.FormalShoes,
				(ushort)Items.Pumps,
				(ushort)Items.Sneakers,
				(ushort)Items.SpaceBoots,

				(ushort)Items.CoatArmy,
				(ushort)Items.Coat,
				(ushort)Items.JacketDenim,
				(ushort)Items.JacketFormal,
				(ushort)Items.JacketShort,

				(ushort)Items.Underpants,
				(ushort)Items.BoxerShorts,
				(ushort)Items.Panties,
				(ushort)Items.Swimsuit,
				(ushort)Items.BikiniDown,

				(ushort)Items.Bra,
				(ushort)Items.BikiniTop,
			};
			creativeScrollbar.scale=0;
			for (int i=0; i<items.Length; i++) SetItemCreative(InventoryCreative, i, items[i]);
			for (int j = items.Length; j<inventoryScrollbarValueCraftingMax; j++) InventoryCreative[j]=itemBlank;
			inventoryScrollbarValueCraftingMax=items.Length;

			ReSetInventoryCreativePositions();
		}

		void SetInvCreativeItems() {
			ushort[] items ={
				(ushort)Items.Strawberry,
				(ushort)Items.Rashberry,
				(ushort)Items.Blueberries,
				(ushort)Items.Apple,
				(ushort)Items.Cherry,
				(ushort)Items.Plum,
				(ushort)Items.Banana,
				(ushort)Items.Lemon,
				(ushort)Items.Orange,

				(ushort)Items.Onion,
				(ushort)Items.Carrot,
				(ushort)Items.Peas,
				(ushort)Items.Seaweed,
				(ushort)Items.FishMeatCooked,
				(ushort)Items.RabbitMeat,
				(ushort)Items.RabbitMeatCooked,
				(ushort)Items.BowlEmpty,
				(ushort)Items.BowlWithMushrooms,
				(ushort)Items.BowlWithVegetables,
				(ushort)Items.Egg,
				(ushort)Items.boiledEgg,

				(ushort)Items.SmallStone,
				(ushort)Items.MediumStone,
				(ushort)Items.BigStone,
				(ushort)Items.ItemCoal,
				(ushort)Items.ItemCopper,
				(ushort)Items.ItemTin,
				(ushort)Items.ItemIron,
				(ushort)Items.ItemSilver,
				(ushort)Items.ItemGold,
				(ushort)Items.Diamond,
				(ushort)Items.Ruby,
				(ushort)Items.Saphirite,
				(ushort)Items.Smaragd,

				(ushort)Items.SulfurDust,
				(ushort)Items.Saltpeter,
				(ushort)Items.Gunpowder,
				(ushort)Items.CoalDust,
				(ushort)Items.BronzeDust,
				(ushort)Items.CopperDust,
				(ushort)Items.GoldDust,
				(ushort)Items.IronDust,
				(ushort)Items.SilverDust,
				(ushort)Items.TinDust,

				(ushort)Items.CopperIngot,
				(ushort)Items.TinIngot,
				(ushort)Items.BronzeIngot,
				(ushort)Items.GoldIngot,
				(ushort)Items.SilverIngot,
				(ushort)Items.IronIngot,
				(ushort)Items.SteelIngot,
				(ushort)Items.AluminiumIngot,

				(ushort)Items.MudIngot,

				(ushort)Items.plateAluminium,
				(ushort)Items.PlateBronze,
				(ushort)Items.PlateCopper,
				(ushort)Items.PlateGold,
				(ushort)Items.PlateIron,

				(ushort)Items.BareLabel,
				(ushort)Items.Tranzistor,
				(ushort)Items.Rezistance,
				(ushort)Items.Condenser,
				(ushort)Items.Diode,
				(ushort)Items.Bulb,
				(ushort)Items.ItemBattery,
				(ushort)Items.Motor,
				(ushort)Items.Circuit,
				(ushort)Items.BigCircuit,

				(ushort)Items.MudIngot,
				(ushort)Items.Rubber,
				(ushort)Items.Plastic,
				(ushort)Items.Ash,
				(ushort)Items.CoalWood,
				(ushort)Items.KapokFibre,
				(ushort)Items.Yarn,
				(ushort)Items.Cloth,
				(ushort)Items.Rope,
				(ushort)Items.Nail,
				(ushort)Items.Rod,

				(ushort)Items.AxeHeadCopper,
				(ushort)Items.AxeHeadBronze,
				(ushort)Items.AxeHeadGold,
				(ushort)Items.AxeHeadIron,
				(ushort)Items.AxeHeadSteel,
				(ushort)Items.AxeHeadAluminium,

				(ushort)Items.ShovelHeadCopper,
				(ushort)Items.ShovelHeadBronze,
				(ushort)Items.ShovelHeadGold,
				(ushort)Items.ShovelHeadIron,
				(ushort)Items.ShovelHeadSteel,
				(ushort)Items.ShovelHeadAluminium,

				(ushort)Items.HoeHeadCopper,
				(ushort)Items.HoeHeadBronze,
				(ushort)Items.HoeHeadGold,
				(ushort)Items.HoeHeadIron,
				(ushort)Items.HoeHeadSteel,
				(ushort)Items.HoeHeadAluminium,

				(ushort)Items.PickaxeHeadCopper,
				(ushort)Items.PickaxeHeadBronze,
				(ushort)Items.PickaxeHeadGold,
				(ushort)Items.PickaxeHeadIron,
				(ushort)Items.PickaxeHeadSteel,
				(ushort)Items.PickaxeHeadAluminium,

				(ushort)Items.ShearsHeadCopper,
				(ushort)Items.ShearsHeadBronze,
				(ushort)Items.ShearsHeadGold,
				(ushort)Items.ShearsHeadIron,
				(ushort)Items.ShearsHeadSteel,
				(ushort)Items.ShearsHeadAluminium,

				(ushort)Items.KnifeHeadCopper,
				(ushort)Items.KnifeHeadBronze,
				(ushort)Items.KnifeHeadGold,
				(ushort)Items.KnifeHeadIron,
				(ushort)Items.KnifeHeadSteel,
				(ushort)Items.KnifeHeadAluminium,

				(ushort)Items.DyeArmy,
				(ushort)Items.DyeBlack,
				(ushort)Items.DyeBlue,
				(ushort)Items.DyeBrown,
				(ushort)Items.DyeDarkBlue,
				(ushort)Items.DyeDarkGray,
				(ushort)Items.DyeDarkGreen,
				(ushort)Items.DyeDarkRed,
				(ushort)Items.DyeGold,
				(ushort)Items.DyeGray,
				(ushort)Items.DyeGreen,
				(ushort)Items.DyeLightBlue,
				(ushort)Items.DyeLightGray,
				(ushort)Items.DyeLightGreen,
				(ushort)Items.DyeMagenta,
				(ushort)Items.DyeOlive,
				(ushort)Items.DyeOrange,
				(ushort)Items.DyePink,
				(ushort)Items.DyePurple,
				(ushort)Items.DyeRed,
				(ushort)Items.DyeSpringGreen,
				(ushort)Items.DyeViolet,
				(ushort)Items.DyeWhite,
				(ushort)Items.DyeYellow,

				(ushort)Items.AngelHair,

				(ushort)Items.ChristmasBallGray,
				(ushort)Items.ChristmasBallYellow,
				(ushort)Items.ChristmasBallBlue,
				(ushort)Items.ChristmasBallLightGreen,
				(ushort)Items.ChristmasBallRed,
				(ushort)Items.ChristmasBallOrange,
				(ushort)Items.ChristmasBallPink,
				(ushort)Items.ChristmasBallPurple,
				(ushort)Items.ChristmasBallTeal,


				(ushort)Items.AnimalRabbit,
				(ushort)Items.AnimalChicken,
				(ushort)Items.AnimalParrot,
				(ushort)Items.AnimalFish,
			};
			creativeScrollbar.scale=0;

			int i=0;
			for (; i<items.Length; i++) SetItemCreative(InventoryCreative, i, items[i]);
			inventoryScrollbarValueCraftingMax=i/*tems.Length*/;
			for (; i<inventoryScrollbarValueCraftingMax; i++) InventoryCreative[i]=itemBlank;

			ReSetInventoryCreativePositions();
		}

		// Bake
		void SetInvBakeTools() {
			 ushort[] items ={

				(ushort)Items.AxeHeadCopper,
				(ushort)Items.AxeHeadBronze,
				(ushort)Items.AxeHeadGold,
				(ushort)Items.AxeHeadIron,
				(ushort)Items.AxeHeadSteel,
				(ushort)Items.AxeHeadAluminium,

				(ushort)Items.ShovelHeadCopper,
				(ushort)Items.ShovelHeadBronze,
				(ushort)Items.ShovelHeadGold,
				(ushort)Items.ShovelHeadIron,
				(ushort)Items.ShovelHeadSteel,
				(ushort)Items.ShovelHeadAluminium,

				(ushort)Items.HoeHeadCopper,
				(ushort)Items.HoeHeadBronze,
				(ushort)Items.HoeHeadGold,
				(ushort)Items.HoeHeadIron,
				(ushort)Items.HoeHeadSteel,
				(ushort)Items.HoeHeadAluminium,

				(ushort)Items.PickaxeHeadCopper,
				(ushort)Items.PickaxeHeadBronze,
				(ushort)Items.PickaxeHeadGold,
				(ushort)Items.PickaxeHeadIron,
				(ushort)Items.PickaxeHeadSteel,
				(ushort)Items.PickaxeHeadAluminium,

				(ushort)Items.ShearsHeadCopper,
				(ushort)Items.ShearsHeadBronze,
				(ushort)Items.ShearsHeadGold,
				(ushort)Items.ShearsHeadIron,
				(ushort)Items.ShearsHeadSteel,
				(ushort)Items.ShearsHeadAluminium,

				(ushort)Items.Bottle,
				(ushort)Items.TestTube,
				(ushort)Items.TorchON,
			};

			//inventoryScrollbarValueCraftingMax=items.Length-1;

			//for (int i=0; i<items.Length; i++) SetItemCreative(InventoryCrafting, i, items[i]);
			//for (int j = items.Length; j<inventoryScrollbarValueCraftingMax; j++) InventoryCrafting[j]=itemBlank;

			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;

			ReSetCraftingInventoryPositions();
		}

		void SetInvBakeIngots() {
			ushort[] items ={
				(ushort)Items.CopperIngot,
				(ushort)Items.TinIngot,
				(ushort)Items.BronzeIngot,
				(ushort)Items.GoldIngot,
				(ushort)Items.SilverIngot,
				(ushort)Items.IronIngot,
				(ushort)Items.SteelIngot,
				(ushort)Items.AluminiumIngot,

				(ushort)Items.PlateCopper,
				(ushort)Items.PlateBronze,
				(ushort)Items.PlateGold,
				(ushort)Items.PlateIron,
				(ushort)Items.plateAluminium,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;

			ReSetCraftingInventoryPositions();
		}

		void SetInvBakeItems() {
			ushort[] items ={
				(ushort)Items.Glass,
				(ushort)Items.CoalWood,
				(ushort)Items.Ash,
				(ushort)Items.BareLabel,
				(ushort)Items.Rubber,
				(ushort)Items.Plastic,
				
				(ushort)Items.ChristmasStar,
				(ushort)Items.ChristmasBallGray,

			  //  (ushort)Items.DyeArmy,
				(ushort)Items.DyeBlack,
				(ushort)Items.DyeBlue,
				(ushort)Items.DyeBrown,
			  // (ushort)Items.DyeDarkBlue,
			   // (ushort)Items.DyeDarkGray,
				(ushort)Items.DyeDarkGreen,
			   // (ushort)Items.DyeDarkRed,
				(ushort)Items.DyeGold,
				(ushort)Items.DyeGray,
				(ushort)Items.DyeGreen,
			   // (ushort)Items.DyeLightBlue,
			   // (ushort)Items.DyeLightGray,
			   // (ushort)Items.DyeLightGreen,
			   // (ushort)Items.DyeMagenta,
				(ushort)Items.DyeOlive,
				(ushort)Items.DyeOrange,
			 //   (ushort)Items.DyePink,
			  //  (ushort)Items.DyePurple,
				(ushort)Items.DyeRed,
				(ushort)Items.DyeSpringGreen,
				(ushort)Items.DyeViolet,
				(ushort)Items.DyeWhite,
				(ushort)Items.DyeYellow,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;

			ReSetCraftingInventoryPositions();
		}

		void SetInvBakeFood() {
			ushort[] items ={
				(ushort)Items.FishMeatCooked,
				(ushort)Items.RabbitMeatCooked,
				(ushort)Items.BowlWithMushrooms,
				(ushort)Items.BowlWithVegetables,
				(ushort)Items.boiledEgg
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;

			ReSetCraftingInventoryPositions();
		}

		void SetInvBakeCeramics() {
			ushort[] items ={
				(ushort)Items.OneBrick
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;

			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;

			ReSetCraftingInventoryPositions();
		}

		// toDust
		void SetInvToDustDusts() {
			ushort[] items ={
				(ushort)Items.CopperDust,
				(ushort)Items.TinDust,
				(ushort)Items.BronzeDust,
				(ushort)Items.IronDust,
				(ushort)Items.AluminiumDust,
				(ushort)Items.SilverDust,
				(ushort)Items.GoldDust,
				(ushort)Items.WoodDust,
				(ushort)Items.CoalDust,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvToDustTools() {
			ushort[] items ={
				(ushort)Items.AxeHeadIron,
				(ushort)Items.PickaxeHeadIron,
				(ushort)Items.ShovelHeadIron,
				(ushort)Items.StoneHead,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvToDustStone() {
			ushort[] items ={
				(ushort)Items.Stonerubble,
				(ushort)Items.MediumStone,
				(ushort)Items.SmallStone,
				(ushort)Items.Gravel,
				(ushort)Items.Sand,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvToDustNature() {
			ushort[] items ={
				(ushort)Items.Seeds,
				(ushort)Items.WheatSeeds,
				(ushort)Items.FlaxSeeds,
				(ushort)Items.Leave,
				(ushort)Items.Stick,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvToDustOther() {
			ushort[] items ={
				(ushort)Items.Yarn,
				(ushort)Items.Hay,
				(ushort)Items.BucketWater,
				(ushort)Items.Cloth,
				(ushort)Items.Label,
				(ushort)Items.BareLabel
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		// sewing
		void SetInvClothesHead() {
			ushort[] items={
				(ushort)Items.Cap,
				(ushort)Items.Crown,
				(ushort)Items.Hat,
				(ushort)Items.SpaceHelmet,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvClothesChest() {
			ushort[] items={
				(ushort)Items.TShirt,
				(ushort)Items.Shirt,
				(ushort)Items.Dress,
				(ushort)Items.CoatArmy,
				(ushort)Items.Coat,
				(ushort)Items.JacketDenim,
				(ushort)Items.JacketFormal,
				(ushort)Items.JacketShort,
				(ushort)Items.SpaceSuit,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvClothesLegs() {
			ushort[] items={
				(ushort)Items.ArmyTrousers,
				(ushort)Items.Jeans,
				(ushort)Items.Shorts,
				(ushort)Items.Skirt,
				(ushort)Items.SpaceTrousers,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvClothesShoes() {
			ushort[] items={
				(ushort)Items.FormalShoes,
				(ushort)Items.Pumps,
				(ushort)Items.Sneakers,
				(ushort)Items.SpaceBoots,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		void SetInvClothesUnderwear() {
			ushort[] items={
				(ushort)Items.Underpants,
				(ushort)Items.BoxerShorts,
				(ushort)Items.Panties,
				(ushort)Items.Swimsuit,
				(ushort)Items.BikiniTop,
				(ushort)Items.BikiniDown,
				(ushort)Items.Bra,
			};

			inventoryScrollbarValueCraftingMax=items.Length-1;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}

		Texture2D ItemIdToTexture(ushort id) {
			switch (id) {
				 case (ushort)Items.ChristmasBallGray: return TextureChristmasBall;
				 case (ushort)Items.ChristmasBallYellow: return TextureChristmasBallYellow;
				 case (ushort)Items.ChristmasBallOrange: return TextureChristmasBallOrange;
				 case (ushort)Items.ChristmasBallRed: return TextureChristmasBallRed;
				 case (ushort)Items.ChristmasBallPurple: return TextureChristmasBallPurple;
				 case (ushort)Items.ChristmasBallPink: return TextureChristmasBallPink;
				 case (ushort)Items.ChristmasBallLightGreen: return TextureChristmasBallLightGreen;
				 case (ushort)Items.ChristmasBallBlue: return TextureChristmasBallBlue;
				 case (ushort)Items.ChristmasBallTeal: return TextureChristmasBallTeal;
				 case (ushort)Items.AngelHair: return TextureAngelHair;

				case (ushort)Items.ChristmasStar:return TextureChristmasStar;
				case (ushort)Items.AirTank:return TextureAirTank;
				case (ushort)Items.AirTank2:return TextureAirTank2;
				case (ushort)Items.OxygenMachine:return TextureOxygenMachine;
				case (ushort)Items.BackSulfur:return TextureBackSulfurOre;
				case (ushort)Items.BackSaltpeter:return TextureBackSaltpeterOre;
				case (ushort)Items.Ammo:return TextureAmmo;
				case (ushort)Items.Gun:return TextureGun;
				case (ushort)Items.Saltpeter:return TextureSaltpeter;
				case (ushort)Items.SulfurDust:return TextureSulfur;
				case (ushort)Items.OreSaltpeter:return TextureOreSaltpeter;
				case (ushort)Items.OreSulfur:return TextureOreSulfur;
				case (ushort)Items.Gunpowder:return TextureGunpowder;

				case (ushort)Items.BucketForRubber:return TextureBucketForRubber;
				case (ushort)Items.Resin:return  TextureResin;
				case (ushort)Items.Aluminium:return ItemAluminiumTexture;
				case (ushort)Items.TorchOFF:return TextureTorchOff;
				//case (ushort)Items.BronzeHeadHoe:return TextureHoeHeadBronze;
				//case (ushort)Items.CopperHeadHoe:return TextureHoeHeadCopper;
				//case (ushort)Items.HoeHeadIron:return TextureHoeHeadIron;
				case (ushort)Items.HoeCopper:return TextureHoeCopper;

				case (ushort)Items.Mobile:return mobileTexture;
				case (ushort)Items.SewingMachine:return sewingMachineTexture;
				case (ushort)Items.BucketOil:return bucketOilTexture;
				case (ushort)Items.TorchON:return torchInvTexture;

				case (ushort)Items.BottleOil:return bottleOilTexture;
				case (ushort)Items.BoxAdv:return boxAdvTexture;
				case (ushort)Items.BoxWooden:return boxWoodenTexture;
				case (ushort)Items.Shelf:return shelfTexture;
				case (ushort)Items.Heater:return heatherTexture;
				case (ushort)Items.WoodDust:return ItemWoodDustTexture;
				case (ushort)Items.AluminiumDust:return ItemAluminiumDustTexture;
				case (ushort)Items.FlaxSeeds:return flaxSeedsTexture;
				case (ushort)Items.MudIngot:return oneMudBrickTexture;
				case (ushort)Items.AluminiumIngot:return ItemAluminiumIngotTexture;
				case (ushort)Items.Nail:return nailTexture;
				case (ushort)Items.Silicium:return siliciumTexture;
				case (ushort)Items.StoneBasalt: return basaltTexture;
				case (ushort)Items.StoneLimestone: return limestoneTexture;
				case (ushort)Items.StoneRhyolite: return rhyoliteTexture;
				case (ushort)Items.StoneGneiss: return gneissTexture;
				case (ushort)Items.StoneSandstone: return sandstoneTexture;
				case (ushort)Items.StoneSchist: return schistTexture;
				case (ushort)Items.StoneGabbro: return gabbroTexture;
				case (ushort)Items.StoneDiorit: return dioritTexture;
				case (ushort)Items.StoneDolomite: return dolomiteTexture;
				case (ushort)Items.Flax: return flaxInvTexture;
				case (ushort)Items.Dirt: return TextureDirt;
				case (ushort)Items.Sand: return sandTexture;
				case (ushort)Items.Lava: return lavaTexture;
				case (ushort)Items.Stonerubble: return cobblestoneTexture;
				case (ushort)Items.Gravel: return gravelTexture;

				case (ushort)Items.WoodOak: return TextureOakWood;
				case (ushort)Items.WoodSpruce: return spruceWoodTexture;
				case (ushort)Items.WoodLinden: return TextureLindenWood;
				case (ushort)Items.WoodPine: return pineWoodTexture;
				case (ushort)Items.WoodApple: return TextureAppleWood;
				case (ushort)Items.WoodCherry: return cherryWoodTexture;
				case (ushort)Items.WoodPlum: return TexturePlumWood;
				case (ushort)Items.WoodLemon: return TextureLemonWood;
				case (ushort)Items.WoodOrange: return TextureOrangeWood;

				case (ushort)Items.OakLeaves: return TextureOakLeaves;

				case (ushort)Items.GrassBlockDesert: return TextureGrassBlockDesert;
				case (ushort)Items.GrassBlockForest: return TextureGrassBlockForest;
				case (ushort)Items.GrassBlockHills: return TextureGrassBlockHills;
				case (ushort)Items.GrassBlockJungle: return TextureGrassBlockJungle;
				case (ushort)Items.GrassBlockPlains: return TextureGrassBlockPlains;
				case (ushort)Items.GrassBlockCompost: return TextureGrassBlockCompost;

				//Crafted
				case (ushort)Items.Glass: return glassTexture;
				case (ushort)Items.Bricks: return bricksTexture;

				case (ushort)Items.Planks: return planksTexture;

				case (ushort)Items.Desk: return deskTexture;
				case (ushort)Items.Door: return ItemDoorTexture;
				case (ushort)Items.Ladder: return ladderTexture;
				case (ushort)Items.Flag: return ItemFlagTexture;

				case (ushort)Items.Rope: return ItemRopeTexture;

				case (ushort)Items.HayBlock: return hayBlockTexture;

				case (ushort)Items.Roof1: return roof1Texture;
				case (ushort)Items.Roof2: return roof2Texture;

				//Mashines
				case (ushort)Items.AdvancedSpaceBack: return advancedSpaceBackTexture;
				case (ushort)Items.AdvancedSpaceWindow: return advancedSpaceWindowTexture;
				case (ushort)Items.AdvancedSpaceBlock: return advancedSpaceBlockTexture;
				case (ushort)Items.AdvancedSpaceFloor: return advancedSpaceFloorTexture;
				case (ushort)Items.AdvancedSpacePart1: return advancedSpacePart1Texture;
				case (ushort)Items.AdvancedSpacePart2: return advancedSpacePart2Texture;
				case (ushort)Items.AdvancedSpacePart3: return advancedSpacePart3Texture;
				case (ushort)Items.AdvancedSpacePart4: return advancedSpacePart4Texture;

				case (ushort)Items.WindMill: return ItemWindMillTexture;
				case (ushort)Items.WaterMill: return ItemWaterMillTexture;
				case (ushort)Items.SolarPanel: return solarPanelTexture;

				case (ushort)Items.Miner: return minerTexture;
				case (ushort)Items.Macerator: return maceratorOneTexture;
				case (ushort)Items.Lamp: return lampTexture;
				case (ushort)Items.Radio: return radioInvTexture;
				case (ushort)Items.Label: return labelOneTexture;
				case (ushort)Items.Rocket: return ItemRocketTexture;
				case (ushort)Items.FurnaceElectric: return furnaceElectricOneTexture;
				case (ushort)Items.FurnaceStone: return furnaceStoneOneTexture;
				case (ushort)Items.Barrel: return TextureBarrel;

				//Food
				case (ushort)Items.Banana: return ItemBananaTexture;
				case (ushort)Items.Cherry: return ItemCherryTexture;
				case (ushort)Items.Lemon: return ItemLemonTexture;
				case (ushort)Items.Orange: return ItemOrangeTexture;
				case (ushort)Items.Plum: return ItemPlumTexture;
				case (ushort)Items.Apple: return ItemAppleTexture;
				case (ushort)Items.Rashberry: return rashberryTexture;
				case (ushort)Items.Strawberry: return strawberryTexture;
				case (ushort)Items.Blueberries: return blueberryTexture;

				case (ushort)Items.RabbitMeatCooked: return ItemRabbtCookedMeatTexture;
				case (ushort)Items.RabbitMeat: return ItemRabbitMeatTexture;

				case (ushort)Items.AnimalFish: return fishTexture0;
				case (ushort)Items.FishMeatCooked: return fishCookedTexture;

				case (ushort)Items.Egg: return TextureItemEgg;
				case (ushort)Items.boiledEgg: return TextureItemBoiledEgg;

				//Clothes
				case (ushort)Items.Backpack: return ItemBackpackTexture;

				//Items
				case (ushort)Items.CoalDust: return ItemCoalDustTexture;
				case (ushort)Items.BronzeDust: return ItemBronzeDustTexture;
				case (ushort)Items.GoldDust: return ItemGoldDustTexture;
				case (ushort)Items.IronDust: return ItemIronDustTexture;
				case (ushort)Items.SilverDust: return ItemSilverDustTexture;
				case (ushort)Items.CopperDust: return ItemCopperDustTexture;
				case (ushort)Items.TinDust: return ItemTinDustTexture;

				case (ushort)Items.BronzeIngot: return ItemBronzeIngotTexture;
				case (ushort)Items.SteelIngot: return TextureIngotSteel;
				case (ushort)Items.GoldIngot: return ItemGoldIngotTexture;
				case (ushort)Items.IronIngot: return ItemIronIngotTexture;
				case (ushort)Items.TinIngot: return ItemTinIngotTexture;
				case (ushort)Items.SilverIngot: return ItemSilverIngotTexture;
				case (ushort)Items.CopperIngot: return ItemCopperIngotTexture;

				case (ushort)Items.PlateIron: return plateIronTexture;
				case (ushort)Items.PlateBronze: return plateBronzeTexture;
				case (ushort)Items.plateAluminium: return plateAluminiumTexture;
				case (ushort)Items.PlateCopper: return plateCopperTexture;
				case (ushort)Items.PlateGold: return plateGoldTexture;

				case (ushort)Items.OreCoal: return TextureOreCoal;
				case (ushort)Items.ItemCoal: return ItemCoalTexture;
				case (ushort)Items.ItemGold: return ItemGoldTexture;
				case (ushort)Items.ItemTin: return ItemTinTexture;
				case (ushort)Items.ItemSilver: return ItemSilverTexture;
				case (ushort)Items.ItemIron: return ItemIronTexture;
				case (ushort)Items.ItemCopper: return ItemCopperTexture;
				case (ushort)Items.Ash: return ashTexture;
				case (ushort)Items.CoalWood: return coalWoodTexture;

				case (ushort)Items.Saphirite: return ItemSaphiriteTexture;
				case (ushort)Items.Diamond: return ItemDiamondTexture;
				case (ushort)Items.Smaragd: return ItemSmaragdTexture;
				case (ushort)Items.Ruby: return ItemRubyTexture;
				case (ushort)Items.SmallStone: return ItemSmallStoneTexture;
				case (ushort)Items.BigStone: return ItemBigStoneTexture;
				case (ushort)Items.MediumStone: return ItemMediumStoneTexture;

				case (ushort)Items.Bulb: return ItemBulbTexture;
				case (ushort)Items.Circuit: return ItemCircuitTexture;
				case (ushort)Items.ItemBattery: return ItemBatteryTexture;
				case (ushort)Items.BigCircuit: return ItemBigCircuitTexture;
				case (ushort)Items.OneBrick: return oneBrickTexture;

				case (ushort)Items.Cloth: return clothTexture;
				case (ushort)Items.Yarn: return yarnTexture;

				case (ushort)Items.Condenser: return condenserTexture;
				case (ushort)Items.Diode: return diodeTexture;
				case (ushort)Items.Tranzistor: return tranzistorTexture;
				case (ushort)Items.Rezistance: return resistanceTexture;
				case (ushort)Items.Motor: return motorTexture;
				case (ushort)Items.BareLabel: return bareLabelTexture;

				//Plants
				case (ushort)Items.OakSapling: return oakSaplingTexture;
				case (ushort)Items.LindenSapling: return TextureLindenSapling;
				case (ushort)Items.PineSapling: return pineSaplingTexture;
				case (ushort)Items.AppleSapling: return TextureAppleSapling;
				case (ushort)Items.LemonSapling: return lemonSaplingTexture;
				case (ushort)Items.CherrySapling: return cherrySaplingTexture;
				case (ushort)Items.PlumSapling: return plumSaplingTexture;
				case (ushort)Items.SpruceSapling: return spruceSaplingTexture;
				case (ushort)Items.OrangeSapling: return orangeSaplingTexture;

				case (ushort)Items.Dandelion: return plantDandelionTexture;
				case (ushort)Items.PlantRose: return plantRoseTexture;
				case (ushort)Items.PlantOrchid: return plantOrchidTexture;
				case (ushort)Items.PlantViolet: return plantVioletTexture;

				case (ushort)Items.PlantStrawberry: return invStrawberryTexture;
				case (ushort)Items.PlantRashberry: return invRashberryTexture;
				case (ushort)Items.PlantBlueberry: return invBlueberryTexture;

				case (ushort)Items.CactusBig: return cactusBigTexture;
				case (ushort)Items.CactusSmall: return cactusLittleTexture;

				case (ushort)Items.SugarCane: return sugarCaneTexture;
				case (ushort)Items.Onion: return ItemOnionTexture;

				case (ushort)Items.Toadstool: return toadstoolTexture;
				case (ushort)Items.Boletus: return boletusTexture;
				case (ushort)Items.Champignon: return champignonTexture;

				case (ushort)Items.Coral: return coralTexture;
				case (ushort)Items.Seaweed: return seaweedTexture;
				case (ushort)Items.PlantSeaweed: return seaweedTexture;
				case (ushort)Items.PlantOnion: return plantOnionTexture;

				//Nature
				case (ushort)Items.WheatSeeds: return ItemWheatSeedsTexture;
				case (ushort)Items.Seeds: return ItemSeedsTexture;

				case (ushort)Items.WheatStraw: return ItemWheatStrawTexture;
				case (ushort)Items.Hay: return ItemHayTexture;

				case (ushort)Items.Leave: return ItemLeaveTexture;
				case (ushort)Items.Stick: return ItemStickTexture;
				case (ushort)Items.Sticks: return ItemSticksTexture;
				case (ushort)Items.Rubber: return ItemRubberTexture;

				//Tools
				case (ushort)Items.Bucket: return ItemBucketTexture;
				case (ushort)Items.BucketWater: return ItemBucketWaterTexture;

				case (ushort)Items.StoneHead: return stoneHeadTexture;

				//case (ushort)Items.AxeHeadIron: return TextureHeadAxeIron;
				//case (ushort)Items.ShovelHeadIron: return TextureHeadShovelIron;
				//case (ushort)Items.PickaxeHeadIron: return TextureHeadPickaxeIron;

				//Shovel
				case (ushort)Items.ShovelStone: return TextureShovelStone;
				case (ushort)Items.ShovelCopper: return TextureShovelCopper;
				case (ushort)Items.ShovelBronze: return TextureShovelBronze;
				case (ushort)Items.ShovelGold: return TextureShovelGold;
				case (ushort)Items.ShovelIron: return TextureShovelIron;
				case (ushort)Items.ShovelSteel: return TextureShovelSteel;
				case (ushort)Items.ShovelAluminium: return TextureShovelAluminium;

				// Pickaxe
				case (ushort)Items.PickaxeStone: return TexturePickaxeStone;
				case (ushort)Items.PickaxeCopper: return TexturePickaxeCopper;
				case (ushort)Items.PickaxeBronze: return TexturePickaxeBronze;
				case (ushort)Items.PickaxeGold: return TexturePickaxeGold;
				case (ushort)Items.PickaxeIron: return TexturePickaxeIron;
				case (ushort)Items.PickaxeSteel: return TexturePickaxeSteel;
				case (ushort)Items.PickaxeAluminium: return TexturePickaxeAluminium;

				// Axe
				case (ushort)Items.AxeStone: return TextureAxeStone;
				case (ushort)Items.AxeCopper: return TextureAxeCopper;
				case (ushort)Items.AxeBronze: return TextureAxeBronze;
				case (ushort)Items.AxeGold: return TextureAxeGold;
				case (ushort)Items.AxeIron: return TextureAxeIron;
				case (ushort)Items.AxeSteel: return TextureAxeSteel;
				case (ushort)Items.AxeAluminium: return TextureAxeAluminium;

				// Hammers
				case (ushort)Items.HammerCopper: return TextureHammerCopper;
				case (ushort)Items.HammerBronze: return TextureHammerBronze;
				case (ushort)Items.HammerIron: return TextureHammerIron;
				case (ushort)Items.HammerGold: return TextureHammerGold;
				case (ushort)Items.HammerSteel: return TextureHammerSteel;
				case (ushort)Items.HammerAluminium: return TextureHammerAluminium;

				// Shears
				case (ushort)Items.ShearsCopper: return TextureShearsCopper;
				case (ushort)Items.ShearsBronze: return TextureShearsBronze;
				case (ushort)Items.ShearsGold: return TextureShearsGold;
				case (ushort)Items.ShearsIron: return TextureShearsIron;
				case (ushort)Items.ShearsSteel: return TextureShearsSteel;
				case (ushort)Items.ShearsAluminium: return TextureShearsAluminium;

				// Saw
				case (ushort)Items.SawCopper: return TextureSawCopper;
				case (ushort)Items.SawBronze: return TextureSawBronze;
				case (ushort)Items.SawGold: return TextureSawGold;
				case (ushort)Items.SawIron: return TextureSawIron;
				case (ushort)Items.SawSteel: return TextureSawSteel;
				case (ushort)Items.SawAluminium: return TextureSawAluminium;

				case (ushort)Items.ElectricDrill: return TextureDrillElectric;
				case (ushort)Items.ElectricSaw: return electricSawTexture;

				case (ushort)Items.OreAluminium: return TextureOreAluminium;
				case (ushort)Items.OreCopper: return TextureOreCopper;
				case (ushort)Items.OreGold: return TextureOreGold;
				case (ushort)Items.OreIron: return TextureOreIron;
				case (ushort)Items.OreSilver: return TextureOreSilver;
				case (ushort)Items.OreTin: return TextureOreTin;

				case (ushort)Items.AppleLeaves: return TextureAppleLeaves;
				case (ushort)Items.AppleLeavesWithApples: return TextureAppleLeavesWithApples;
				case (ushort)Items.OrangeLeaves: return TextureOrangeLeaves;
				case (ushort)Items.OrangeLeavesWithOranges: return TextureOrangeLeavesWithOranges;
				case (ushort)Items.PlumLeaves: return TexturePlumLeaves;
				case (ushort)Items.PlumLeavesWithPlums: return TexturePlumLeavesWithPlums;
				case (ushort)Items.CherryLeaves: return TextureCherryLeaves;
				case (ushort)Items.CherryLeavesWithCherries: return TextureCherryLeavesWithCherries;
				case (ushort)Items.LemonLeaves: return TextureLemonLeaves;
				case (ushort)Items.LemonLeavesWithLemons: return lemonLeavesWithLemonsTexture;
				case (ushort)Items.LindenLeaves: return TextureLindenLeaves;
				case (ushort)Items.SpruceLeaves: return spruceLeavesTexture;
				case (ushort)Items.PineLeaves: return pineLeavesTexture;

				case (ushort)Items.Snow: return snowTexture;
				case (ushort)Items.SnowTop: return snowTopTexture;
				case (ushort)Items.Ice: return iceTexture;

				case (ushort)Items.GrassDesert: return grassDesertTexture;
				case (ushort)Items.GrassForest: return grassForestTexture;
				case (ushort)Items.GrassHills: return grassHillsTexture;
				case (ushort)Items.GrassJungle: return grassJungleTexture;
				case (ushort)Items.GrassPlains: return grassPlainsTexture;

				case (ushort)Items.Alore: return plantAloreTexture;
				case (ushort)Items.Plastic: return ItemPlasticTexture;

				case (ushort)Items.Carrot: return ItemCarrotTexture;
				case (ushort)Items.PlantCarrot: return plantCarrotTexture;
				case (ushort)Items.Peas: return ItemPeasTexture;
				case (ushort)Items.PlantPeas: return plantPeasTexture;

				case (ushort)Items.Battery: return ItemBatteryTexture;

				case (ushort)Items.BottleWater: return bottleWaterTexture;
				case (ushort)Items.Bottle: return bottleEmptyTexture;
				case (ushort)Items.BowlEmpty: return bowlEmptyTexture;
				case (ushort)Items.BowlWithMushrooms: return bowlMushroomsTexture;
				case (ushort)Items.BowlWithVegetables: return bowlVegetablesTexture;

				case (ushort)Items.ElectricDrillOff: return TextureDrillElectric;
				case (ushort)Items.ElectricSawOff: return electricSawTexture;

				case (ushort)Items.HoeStone: return TextureHoeStone;
				case (ushort)Items.HoeBronze: return TextureHoeBronze;
				case (ushort)Items.HoeIron: return TextureHoeIron;

				case (ushort)Items.Charger: return chargerTexture;

				case (ushort)Items.Clay: return clayTexture;
				case (ushort)Items.GrassBlockClay: return TextureGrassBlockClay;
				case (ushort)Items.BackDirt: return backgroundDirtTexture;
				case (ushort)Items.BackSand: return backgroundSandTexture;
				case (ushort)Items.BackClay: return backgroundClayTexture;
				case (ushort)Items.BackCobblestone: return backgroundCobblestoneTexture;
				case (ushort)Items.BackGravel: return backgroundGravelTexture;
				case (ushort)Items.BackRedSand: return backgroundRedSandTexture;
				case (ushort)Items.BackRegolite: return backgroundRegoliteTexture;

				case (ushort)Items.BackCoal: return backgroundCoalTexture;
				case (ushort)Items.BackAluminium: return backgroundAluminiumTexture;
				case (ushort)Items.BackCopper: return backgroundCopperTexture;
				case (ushort)Items.BackGold: return backgroundGoldTexture;
				case (ushort)Items.BackIron: return backgroundIronTexture;
				case (ushort)Items.BackTin: return backgroundTinTexture;
				case (ushort)Items.BackSilver: return backgroundSilverTexture;


				case (ushort)Items.BackAnorthosite: return backgroundAnorthositeTexture;
				case (ushort)Items.BackBasalt: return backgroundBasaltTexture;
				case (ushort)Items.BackDiorit: return backgroundDioritTexture;
				case (ushort)Items.BackDolomite: return backgroundDolomiteTexture;
				case (ushort)Items.BackFlint: return backgroundFlintTexture;
				case (ushort)Items.BackGabbro: return backgroundGabbroTexture;
				case (ushort)Items.BackGneiss: return backgroundGneissTexture;
				case (ushort)Items.BackLimestone: return backgroundLimestoneTexture;
				case (ushort)Items.BackMudstone: return backgroundMudstoneTexture;
				case (ushort)Items.BackSandstone: return backgroundSandstoneTexture;
				case (ushort)Items.BackSchist: return backgroundSchistTexture;
				case (ushort)Items.BackRhyolite: return backgroundRhyoliteTexture;

				case (ushort)Items.StoneFlint: return flintTexture;
				case (ushort)Items.StoneMudstone: return mudstoneTexture;
				case (ushort)Items.StoneAnorthosite: return anorthositeTexture;
				case (ushort)Items.AnimalRabbit: return rabbitStillTexture;
				case (ushort)Items.AnimalParrot: return TextureParrotStill;
				case (ushort)Items.AnimalChicken: return chickenStillTexture;
				case (ushort)Items.Rod: return RodTexture;
				case (ushort)Items.TorchElectricOFF: return LightElectricTexture;
				case (ushort)Items.TorchElectricON: return LightElectricTexture;
				case (ushort)Items.Compost: return CompostTexture;
				case (ushort)Items.Composter: return ComposterTexture;

				case (ushort)Items.FormalShoes: return TextureItemFormalShoes;
				case (ushort)Items.Pumps: return TextureItemPumps;
				case (ushort)Items.Sneakers: return TextureItemSneakers;
				case (ushort)Items.SpaceBoots: return TextureItemSpaceBoots;

				case (ushort)Items.Jeans: return TextureItemJeans;
				case (ushort)Items.Shorts: return TextureItemShorts;
				case (ushort)Items.SpaceTrousers: return TextureItemSpaceTrousers;
				case (ushort)Items.ArmyTrousers: return TextureItemArmyTrousers;
				case (ushort)Items.Skirt: return TextureItemSkirt;

				case (ushort)Items.TShirt: return TextureItemTShirt;
				case (ushort)Items.SpaceSuit: return TextureItemSpaceSuit;
				case (ushort)Items.Dress: return TextureItemDress;
				case (ushort)Items.Shirt: return TextureItemShirt;

				case (ushort)Items.Cap: return TextureItemCap;
				case (ushort)Items.Hat: return TextureItemHat;
				case (ushort)Items.Crown: return TextureItemCrown;
				case (ushort)Items.SpaceHelmet: return TextureItemSpaceHelmet;

				case (ushort)Items.Underpants: return TextureItemUnderpants;
				case (ushort)Items.BoxerShorts: return TextureItemBoxerShorts;
				case (ushort)Items.Panties: return TextureItemPanties;
				case (ushort)Items.Swimsuit: return TextureItemSwimsuit;
				case (ushort)Items.BikiniDown: return TextureItemBikiniDown;

				case (ushort)Items.Bra: return TextureItemBra;
				case (ushort)Items.BikiniTop: return TextureItemBikiniTop;

				case (ushort)Items.CoatArmy: return TextureItemCoatArmy;
				case (ushort)Items.Coat: return TextureItemCoat;
				case (ushort)Items.JacketDenim: return ItemJacketDenimTexture;
				case (ushort)Items.JacketFormal: return ItemJacketFormalTexture;
				case (ushort)Items.JacketShort: return TextureItemJacketShort;

				case (ushort)Items.AcaciaLeaves: return TextureAcaciaLeaves;
				case (ushort)Items.AcaciaWood: return TextureAcaciaWood;
				case (ushort)Items.AcaciaSapling: return TextureAcaciaSapling;
				case (ushort)Items.MangroveLeaves: return TextureMangroveLeaves;
				case (ushort)Items.MangroveWood: return TextureMangroveWood;
				case (ushort)Items.MangroveSapling: return TextureMangroveSapling;
				case (ushort)Items.WillowLeaves: return TextureWillowLeaves;
				case (ushort)Items.WillowWood: return TextureWillowWood;
				case (ushort)Items.WillowSapling: return TextureWillowSapling;
				case (ushort)Items.Olive: return ItemOliveTexture;
				case (ushort)Items.OliveLeaves: return TextureOliveLeaves;
				case (ushort)Items.OliveLeavesWithOlives:return TextureOliveLeavesWithOlives;
				case (ushort)Items.OliveWood: return TextureOliveWood;
				case (ushort)Items.OliveSapling: return TextureOliveSapling;
				case (ushort)Items.EucalyptusLeaves: return TextureEucalyptusLeaves;
				case (ushort)Items.EucalyptusSapling: return TextureEucalyptusSapling;
				case (ushort)Items.EucalyptusWood: return TextureEucalyptusWood;
				case (ushort)Items.RubberTreeLeaves: return TextureRubberTreeLeaves;
				case (ushort)Items.RubberTreeSapling: return TextureRubberTreeSapling;
				case (ushort)Items.RubberTreeWood: return TextureRubberTreeWood;
				case (ushort)Items.KapokLeaves: return TextureKapokLeaves;
				case (ushort)Items.KapokLeavesFibre: return TextureKapokLeavesFibre;
				case (ushort)Items.KapokLeacesFlowering: return TextureKapokBlossom;
				case (ushort)Items.KapokSapling: return TextureKapokSapling;
				case (ushort)Items.KapokWood: return TextureKapokWood;
				case (ushort)Items.KapokFibre: return ItemKapokFibreTexture;
				case (ushort)Items.KnifeCopper: return TextureKnifeCopper;
				case (ushort)Items.KnifeBronze: return TextureKnifeBronze;
				case (ushort)Items.KnifeGold: return TextureKnifeGold;
				case (ushort)Items.KnifeIron: return TextureKnifeIron;
				case (ushort)Items.KnifeSteel: return TextureKnifeSteel;
				case (ushort)Items.KnifeAluminium: return TextureKnifeAluminium;

				case (ushort)Items.HoeGold: return TextureHoeGold;
				case (ushort)Items.HoeSteel: return TextureHoeSteel;
				case (ushort)Items.HoeAluminium: return TextureHoeAluminium;
				case (ushort)Items.DyeGold: return TextureDyeGold;
				case (ushort)Items.DyeWhite: return TextureDyeWhite;
				case (ushort)Items.DyeYellow: return TextureDyeYellow;
				case (ushort)Items.DyeOrange: return TextureDyeOrange;
				case (ushort)Items.DyeRed: return TextureDyeRed;
				case (ushort)Items.DyeDarkRed: return TextureDyeDarkRed;
				case (ushort)Items.DyeOlive: return TextureDyeOlive;
				case (ushort)Items.DyePurple: return TextureDyePurple;
				case (ushort)Items.DyePink: return TextureDyePink;
				case (ushort)Items.DyeTeal: return TextureDyeTeal;
				case (ushort)Items.DyeLightBlue: return TextureDyeLightBlue;
				case (ushort)Items.DyeBlue: return TextureDyeBlue;
				case (ushort)Items.DyeMagenta: return TextureDyeMagenta;
				case (ushort)Items.DyeDarkBlue: return TextureDyeDarkBlue;
				case (ushort)Items.DyeBlack: return TextureDyeBlack;
				case (ushort)Items.DyeBrown: return TextureDyeBrown;
				case (ushort)Items.DyeLightGray: return TextureDyeLightGray;
				case (ushort)Items.DyeGray: return TextureDyeGray;
				case (ushort)Items.DyeDarkGray: return TextureDyeDarkGray;
				case (ushort)Items.DyeViolet: return TextureDyeViolet;
				case (ushort)Items.DyeSpringGreen: return TextureDyeSpringGreen;
				case (ushort)Items.DyeRoseQuartz: return TextureDyeRoseQuartz;
				case (ushort)Items.TestTube: return TextureTestTube;
				case (ushort)Items.DyeLightGreen: return TextureDyeLightGreen;
				case (ushort)Items.DyeGreen: return TextureDyeGreen;
				case (ushort)Items.DyeArmy: return TextureDyeArmy;
				case (ushort)Items.DyeDarkGreen: return TextureDyeDarkGreen;

					 //Shovel
				case (ushort)Items.ShovelHeadCopper: return TextureShovelHeadCopper;
				case (ushort)Items.ShovelHeadBronze: return TextureShovelHeadBronze;
				case (ushort)Items.ShovelHeadGold: return TextureShovelHeadGold;
				case (ushort)Items.ShovelHeadIron: return TextureShovelHeadIron;
				case (ushort)Items.ShovelHeadSteel: return TextureShovelHeadSteel;
				case (ushort)Items.ShovelHeadAluminium: return TextureShovelHeadAluminium;

				// Pickaxe
				case (ushort)Items.PickaxeHeadCopper: return TexturePickaxeHeadCopper;
				case (ushort)Items.PickaxeHeadBronze: return TexturePickaxeHeadBronze;
				case (ushort)Items.PickaxeHeadGold: return TexturePickaxeHeadGold;
				case (ushort)Items.PickaxeHeadIron: return TexturePickaxeHeadIron;
				case (ushort)Items.PickaxeHeadSteel: return TexturePickaxeHeadSteel;
				case (ushort)Items.PickaxeHeadAluminium: return TexturePickaxeHeadAluminium;

				// Axe
				case (ushort)Items.AxeHeadCopper: return TextureAxeHeadCopper;
				case (ushort)Items.AxeHeadBronze: return TextureAxeHeadBronze;
				case (ushort)Items.AxeHeadGold: return TextureAxeHeadGold;
				case (ushort)Items.AxeHeadIron: return TextureAxeHeadIron;
				case (ushort)Items.AxeHeadSteel: return TextureAxeHeadSteel;
				case (ushort)Items.AxeHeadAluminium: return TextureAxeHeadAluminium;

				// Shears
				case (ushort)Items.ShearsHeadCopper: return TextureShearsHeadCopper;
				case (ushort)Items.ShearsHeadBronze: return TextureShearsHeadBronze;
				case (ushort)Items.ShearsHeadGold: return TextureShearsHeadGold;
				case (ushort)Items.ShearsHeadIron: return TextureShearsHeadIron;
				case (ushort)Items.ShearsHeadSteel: return TextureShearsHeadSteel;
				case (ushort)Items.ShearsHeadAluminium: return TextureShearsHeadAluminium;

				case (ushort)Items.KnifeHeadCopper: return TextureKnifeHeadCopper;
				case (ushort)Items.KnifeHeadBronze: return TextureKnifeHeadBronze;
				case (ushort)Items.KnifeHeadGold: return TextureKnifeHeadGold;
				case (ushort)Items.KnifeHeadIron: return TextureKnifeHeadIron;
				case (ushort)Items.KnifeHeadSteel: return TextureKnifeHeadSteel;
				case (ushort)Items.KnifeHeadAluminium: return TextureKnifeHeadAluminium;

				case (ushort)Items.HoeHeadCopper: return TextureHoeHeadCopper;
				case (ushort)Items.HoeHeadBronze: return TextureHoeHeadBronze;
				case (ushort)Items.HoeHeadGold: return TextureHoeHeadGold;
				case (ushort)Items.HoeHeadIron: return TextureHoeHeadIron;
				case (ushort)Items.HoeHeadSteel: return TextureHoeHeadSteel;
				case (ushort)Items.HoeHeadAluminium: return TextureHoeHeadAluminium;

				case (ushort)Items.RedSand: return TextureRedSand;
				case (ushort)Items.FishMeat: return fishTexture0;

				default:
					#if DEBUG
					throw new Exception("Missing texture for item "+(Items)id);
					#else
					return null;
					#endif
			}
		}

		//void ItemDrop(ItemNonInv item, DInt _pos) {
		//    DroppedItems.Add(new Item {
		//        X=_pos.X,
		//        Y=_pos.Y,
		//        item=item,
		//        Texture=ItemIdToTexture(item.Id),
		//    });
		//}

		void ItemDrop(ItemNonInv item, int x, int y) {
			DroppedItems.Add(new Item {
				X=x,
				Y=y,
				item=item,
				Texture=ItemIdToTexture(item.Id),
			});
		}

		//void ItemDrop(ItemNonInv item, float x, float y) {
		//    DroppedItems.Add(new Item {
		//        X=(int)x,
		//        Y=(int)y,
		//        item=item,
		//        Texture=ItemIdToTexture(item.Id),
		//    });
		//}
		#endregion

		#region Typing
		string TextEdit(string editText) {
			string newKey=Add();

			string add;

			if (newKeyboardState.IsKeyDown(Keys.RightAlt) || newKeyboardState.IsKeyDown(Keys.LeftAlt)) add=ConvertNormalToAtls(newKey);
			else if (newKeyboardState.IsKeyDown(Keys.LeftShift) || newKeyboardState.IsKeyDown(Keys.RightShift)) add=ConvertNormalToUpper(newKey);
			else if (newKeyboardState.IsKeyDown(Keys.LeftControl) || newKeyboardState.IsKeyDown(Keys.RightControl)) add=ConvertNormalToCtrls(newKey);
			else add=newKey;

			if (newKey=="") {
				hold = false;
				timeHold = 30;
			} else {
				if (hold) {
					switch (add) {
						case "Delete":
							if (editText.Length > 0) editText = editText.Substring(0, editText.Length - 1);
							break;

						case "Copy":
							if (editText!="") {
								if (editText!=null) System.Windows.Forms.Clipboard.SetText(editText);
							}
							break;

						case "ExternalTextEditor":
							FormTextInput f = new FormTextInput(editText);
							f.ShowDialog();
							if (f.save) {
								editText=f.ret;
							}
							break;

						case "Paste":
							if (System.Windows.Forms.Clipboard.ContainsText()) editText += System.Windows.Forms.Clipboard.GetText();
							break;

						default: editText += add;
						break;
					}
				} else {
					if (timeHold==0) hold = true;
					else {
						if (lastKey==newKey) {
							if (timeHold == 30) {
								switch (add) {
									 case "Delete":
										if (editText.Length>0) editText=editText.Substring(0,editText.Length-1);
										break;

									 case "Copy":
										if (editText!="") System.Windows.Forms.Clipboard.SetText(editText);
										break;

									case "ExternalTextEditor":
										// ExternalTextEditor=true;
										FormTextInput f = new FormTextInput(editText);
										f.ShowDialog();
										if (f.save) {
											editText=f.ret;
										}
										break;

									 case "Paste":
										if (System.Windows.Forms.Clipboard.ContainsText()) editText += System.Windows.Forms.Clipboard.GetText();
										break;

									default:
										editText += add;
										break;
								}
							}
							timeHold--;
						} else {
							hold = false;
							timeHold = 30;
						}
					}
				}
			}

			lastKey = newKey;

			return editText;
		}

		string Add() {
			if (newKeyboardState.IsKeyDown(Keys.Space)) return " ";

			if (newKeyboardState.IsKeyDown(Keys.Q)) return "g";
			if (newKeyboardState.IsKeyDown(Keys.W)) return "w";
			if (newKeyboardState.IsKeyDown(Keys.E)) return "e";
			if (newKeyboardState.IsKeyDown(Keys.R)) return "r";
			if (newKeyboardState.IsKeyDown(Keys.T)) return "t";
			if (newKeyboardState.IsKeyDown(Keys.Z)) return "z";
			if (newKeyboardState.IsKeyDown(Keys.U)) return "u";
			if (newKeyboardState.IsKeyDown(Keys.I)) return "i";
			if (newKeyboardState.IsKeyDown(Keys.O)) return "o";
			if (newKeyboardState.IsKeyDown(Keys.P)) return "p";
			if (newKeyboardState.IsKeyDown(Keys.A)) return "a";
			if (newKeyboardState.IsKeyDown(Keys.S)) return "s";
			if (newKeyboardState.IsKeyDown(Keys.D)) return "d";
			if (newKeyboardState.IsKeyDown(Keys.F)) return "f";
			if (newKeyboardState.IsKeyDown(Keys.G)) return "g";
			if (newKeyboardState.IsKeyDown(Keys.H)) return "h";
			if (newKeyboardState.IsKeyDown(Keys.J)) return "j";
			if (newKeyboardState.IsKeyDown(Keys.K)) return "k";
			if (newKeyboardState.IsKeyDown(Keys.L)) return "l";
			if (newKeyboardState.IsKeyDown(Keys.Y)) return "y";
			if (newKeyboardState.IsKeyDown(Keys.X)) return "x";
			if (newKeyboardState.IsKeyDown(Keys.C)) return "c";
			if (newKeyboardState.IsKeyDown(Keys.V)) return "v";
			if (newKeyboardState.IsKeyDown(Keys.B)) return "b";
			if (newKeyboardState.IsKeyDown(Keys.N)) return "n";
			if (newKeyboardState.IsKeyDown(Keys.M)) return "m";

			if (Lang.Languages[Setting.CurrentLanguage].Name=="cs-CZ") {
				if (newKeyboardState.IsKeyDown(Keys.D1)) return "ó";
				if (newKeyboardState.IsKeyDown(Keys.D2)) return "ě";
				if (newKeyboardState.IsKeyDown(Keys.D3)) return "š";
				if (newKeyboardState.IsKeyDown(Keys.D4)) return "č";
				if (newKeyboardState.IsKeyDown(Keys.D5)) return "ř";
				if (newKeyboardState.IsKeyDown(Keys.D6)) return "ž";
				if (newKeyboardState.IsKeyDown(Keys.D7)) return "ý";
				if (newKeyboardState.IsKeyDown(Keys.D8)) return "á";
				if (newKeyboardState.IsKeyDown(Keys.D9)) return "í";
				if (newKeyboardState.IsKeyDown(Keys.D0)) return "é";
			}else{
		   // if (Lang.Languages[Setting.CurrentLanguage].Name=="en-GB") {
				if (newKeyboardState.IsKeyDown(Keys.D1)) return "@";
				if (newKeyboardState.IsKeyDown(Keys.D2)) return "#";
				if (newKeyboardState.IsKeyDown(Keys.D3)) return "š";
				if (newKeyboardState.IsKeyDown(Keys.D4)) return "$";
				if (newKeyboardState.IsKeyDown(Keys.D5)) return "%";
				if (newKeyboardState.IsKeyDown(Keys.D6)) return "";
				if (newKeyboardState.IsKeyDown(Keys.D7)) return "&";
				if (newKeyboardState.IsKeyDown(Keys.D8)) return "*";
				if (newKeyboardState.IsKeyDown(Keys.D9)) return "(";
				if (newKeyboardState.IsKeyDown(Keys.D0)) return ")";
			}
			if (newKeyboardState.IsKeyDown(Keys.NumPad0)) return "0";
			if (newKeyboardState.IsKeyDown(Keys.NumPad1)) return "1";
			if (newKeyboardState.IsKeyDown(Keys.NumPad2)) return "2";
			if (newKeyboardState.IsKeyDown(Keys.NumPad3)) return "3";
			if (newKeyboardState.IsKeyDown(Keys.NumPad4)) return "4";
			if (newKeyboardState.IsKeyDown(Keys.NumPad5)) return "5";
			if (newKeyboardState.IsKeyDown(Keys.NumPad6)) return "6";
			if (newKeyboardState.IsKeyDown(Keys.NumPad7)) return "7";
			if (newKeyboardState.IsKeyDown(Keys.NumPad8)) return "8";
			if (newKeyboardState.IsKeyDown(Keys.NumPad9)) return "9";
			if (newKeyboardState.IsKeyDown(Keys.NumPad9)) return "9";

			if (newKeyboardState.IsKeyDown(Keys.Back)) return "Delete";
			if (newKeyboardState.IsKeyDown(Keys.Delete)) return "Delete";

			if (newKeyboardState.IsKeyDown(Keys.OemComma)) return ",";
			if (newKeyboardState.IsKeyDown(Keys.OemPeriod)) return ".";
			if (newKeyboardState.IsKeyDown(Keys.OemMinus)) return "-";
			if (newKeyboardState.IsKeyDown(Keys.OemQuestion)) return "'";
			if (newKeyboardState.IsKeyDown(Keys.OemPlus)) return "=";
			if (newKeyboardState.IsKeyDown(Keys.OemCloseBrackets)) return ")";
			if (newKeyboardState.IsKeyDown(Keys.OemSemicolon)) return "ů";
			if (newKeyboardState.IsKeyDown(Keys.OemOpenBrackets)) return "ú";
			if (newKeyboardState.IsKeyDown(Keys.Divide)) return "/";
			if (newKeyboardState.IsKeyDown(Keys.Add)) return "+";
			if (newKeyboardState.IsKeyDown(Keys.Divide)) return "/";
			if (newKeyboardState.IsKeyDown(Keys.Decimal)) return ",";
			if (newKeyboardState.IsKeyDown(Keys.Subtract)) return "-";
			if (newKeyboardState.IsKeyDown(Keys.Multiply)) return "*";
			if (newKeyboardState.IsKeyDown(Keys.OemQuotes)) return "§";

			return "";
		}

		string ConvertNormalToUpper(string key) {
			switch (key) {
				case "q": return "Q";
				case "w": return "W";
				case "e": return "E";
				case "r": return "R";
				case "t": return "T";
				case "z": return "Z";
				case "u": return "U";
				case "i": return "I";
				case "o": return "O";
				case "p": return "P";
				case "a": return "A";
				case "s": return "S";
				case "d": return "D";
				case "f": return "F";
				case "g": return "G";
				case "h": return "H";
				case "j": return "J";
				case "k": return "K";
				case "l": return "L";
				case "y": return "Y";
				case "x": return "X";
				case "c": return "C";
				case "v": return "V";
				case "b": return "B";
				case "n": return "N";
				case "m": return "M";

				case "ú": return "/";
				case ")": return "(";
				case ",": return "?";
				case ".": return ":";
				case "-": return "_";
				case "¨": return "'";
				case "´": return "ˇ";
				case "=": return "%";
				case "§": return "!";
			}

			return "";
		}

		string ConvertNormalToCtrls(string key) {
			switch (key) {
				case "x": return "Delete";
				case "c": return "Copy";
				case "v": return "Paste";
				case "i": return "ExternalTextEditor";
			}
			return "";
		}

		string ConvertNormalToAtls(string key) {
			 switch (key) {
				case "q": return "\"";
				case "w": return "|";
				case "f": return "[";
				case "g": return "]";
				case "x": return "#";
				case "c": return "&";
				case "v": return "@";
				case "b": return "{";
				case "n": return "}";
				case "ú": return "÷";
				case ")": return "×";
				case ",": return "<";
				case ".": return ">";
				case "-": return "*";
				case "+": return "~";
				case "š": return "^";
				case "ř": return "°";
			}
			return "";
		}
		#endregion

		#region Energy
		void EnergySystem() {
			for (int i=0; i<energy.Count; i++) {
				Energy e = energy[i];

				if (random.Int(500)==1) {
					energy.RemoveAt(i);
					i--;
				} else if (terrain[e.X].IsTopBlocks[e.Y]) {
					Terrain chunk=terrain[e.X];

					ushort id=/*terrain[e.X]*/chunk.TopBlocks[e.Y].Id;

					if (id==(ushort)BlockId.Label) MoveEnergy(((ScreenBlock)/*terrain[e.X]*/chunk.TopBlocks[e.Y]).screen, e);
					else if (id==(ushort)BlockId.Radio
					|| id==(ushort)BlockId.Lamp
					|| id==(ushort)BlockId.FurnaceElectric
					|| id==(ushort)BlockId.Macerator
					|| id==(ushort)BlockId.Charger
					|| id==(ushort)BlockId.SewingMachine
					|| id==(ushort)BlockId.Miner) {
						((MashineBlockBasic)/*terrain[e.X]*/chunk.TopBlocks[e.Y]).AddEnergy();
						energy.RemoveAt(i);
						i--;
					} else {
						energy.RemoveAt(i);
						i--;
					}
				} else {
					energy.RemoveAt(i);
					i--;
				}
			}
		}

		void MoveEnergy(int screen, Energy e) {
			//   1
			// 4 0 2
			//   3

			switch (screen) {
				case 15:
					switch (e.Direction) {
						case 1:
							switch (random.Int(3)) {
								case 0: e.X--; e.Direction=4; return;
								case 1: e.Y++; e.Direction=3; return;
								case 2: e.X++; e.Direction=2; return;
							}
							break;

						case 2:
							switch (random.Int(3)) {
								case 0: e.Y--; e.Direction=1; return;
								case 1: e.Y++; e.Direction=3; return;
								case 2: e.X++; return;
							}
							break;

						case 3:
							switch (random.Int(3)) {
								case 0: e.Y++; return;
								case 1: e.X--; e.Direction=4; return;
								case 2: e.X++; e.Direction=2; return;
							}
							break;

						case 4:
							switch (random.Int(3)) {
								case 0: e.Y--; e.Direction=1; return;
								case 1: e.X--; return;
								case 2: e.Y++; e.Direction=3; return;
							}
							break;
					}
					break;

					case 14:
						switch (e.Direction) {
							case 1:
								if (random.Bool()) {
									e.X--;
									e.Direction=4;
									return;
								} else {
									e.X++;
									e.Direction=2;
									return;
								}

							case 2:
								if (random.Bool()) {
									e.X++;
									return;
								} else {
									e.Y++;
									e.Direction=3;
									return;
								}

							case 4:
								if (random.Bool()) {
									e.X--;
									return;
								} else {
									e.Y++;
									e.Direction=3;
									return;
								}
						}
						break;

					case 13:
						switch (e.Direction) {
							case 1:
								if (random.Bool()) {
									e.Y--;
									return;
								} else {
									e.X--;
									e.Direction=4;
									return;
								}

							case 2:
								if (random.Bool()) {
									e.Y--;
									e.Direction=1;
									return;
								} else {
									e.Y++;
									e.Direction=3;
									return;
								}

							case 3:
								if (random.Bool()) {
									e.Y++;
									return;
								} else {
									e.X--;
									e.Direction=4;
									return;
								}
						}
						break;

					case 12:
						switch (e.Direction) {
							case 2:
								if (random.Bool()) {
									e.Y--;
									e.Direction=1;
									return;
								} else {
									e.X++;
									return;
								}

							case 3:
								if (random.Bool()) {
									e.X++;
									e.Direction=2;
									return;
								} else {
									e.X--;
									e.Direction=4;
									return;
								}

							case 4:
								if (random.Bool()) {
									e.Y--;
									e.Direction=1;
									return;
								} else {
									e.X--;
									return;
								}
						}
						break;

					case 11:
						switch (e.Direction) {
							case 1:
								if (random.Bool()) {
									e.Y--;
									return;
								} else {
									e.X++;
									e.Direction=2;
									return;
								}

							case 3:
								if (random.Bool()) {
									e.Y++;
									return;
								} else {
									e.X++;
									e.Direction=2;
									return;
								}

							case 4:
								if (random.Bool()) {
									e.Y++;
									e.Direction=3;
									return;
								} else {
									e.Y--;
									e.Direction=1;
									return;
								}
						}
						break;

					case 10:
						if (e.Direction==1) {
							e.Y--;
							return;
						} else if (e.Direction==3) {
							e.Y++;
							return;
						} else {
							energy.Remove(e);
							return;
						}

				   case 9:
						if (e.Direction==4) {
							e.X--;
							return;
						} else if (e.Direction==2) {
							e.X++;
							return;
						} else {
							energy.Remove(e);
							return;
						}

					case 8:
						if (e.Direction==3) {
							e.X--;
							e.Direction=4;
							return;
						} else if (e.Direction==2) {
							e.Y--;
							e.Direction=1;
							return;
						} else {
							energy.Remove(e);
							return;
						}

					case 7:
						if (e.Direction==1) {
							e.X--;
							e.Direction=4;
							return;
						} else if (e.Direction==2) {
							e.Y++;
							e.Direction=3;
							return;
						} else {
							energy.Remove(e);
							return;
						}

					case 6:
						if (e.Direction==1) {
							e.X++;
							e.Direction=2;
							return;
						} else if (e.Direction==4) {
							e.Y++;
							e.Direction=3;
							return;
						} else {
							energy.Remove(e);
							return;
						}

					case 5:
						if (e.Direction==4) {
							e.Y--;
							e.Direction=1;
							return;
						} else if (e.Direction==3) {
							e.X++;
							e.Direction=2;
							return;
						} else {
							energy.Remove(e);
							return;
						}

					case 4:
						if (e.Direction==2) e.X++;
						else energy.Remove(e);
						break;

					case 3:
						if (e.Direction==1) e.Y--;
						else energy.Remove(e);
						break;


					case 2:
						if (e.Direction==4) e.X--;
						else energy.Remove(e);
						break;

					case 1:
						if (e.Direction==3) e.Y++;
						else energy.Remove(e);
						break;

					case 0:
						energy.Remove(e);
						break;

			}
		}

		void NewEnergySolarPanel(int x, int y) {
			bool down = false, left = false, right = false;

			if (terrain[x].IsTopBlocks[y+1]) down=terrain[x].TopBlocks[y+1].Id==(ushort)BlockId.Label;

			if (terrain[x-1]!=null) {
				if (terrain[x-1].IsTopBlocks[y]) left=terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Label;
			}

			if (terrain[x+1]!=null) {
				if (terrain[x+1].IsTopBlocks[y]) right=terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.Label;
			}

			if (!down&&!left&&!right) {
				return;
			} else {
				if ( down&& left&& right) {
					switch (random.Int(3)) {
						case 0: energy.Add(new Energy(x+1, y, 2)); return;
						case 1: energy.Add(new Energy(x, y+1, 3)); return;
						case 2: energy.Add(new Energy(x-1, y, 4)); return;
					}
				}
				if (!down&& left&& right) {
					if (random.Bool()) {
						energy.Add(new Energy(x+1, y, 2));
						return;
					} else {
						energy.Add(new Energy(x-1, y, 4));
						return;
					}
				}
				if ( down&&!left&& right) {
					if (random.Bool()) {
						energy.Add(new Energy(x, y+1, 3));
						return;
					} else {
						energy.Add(new Energy(x-1, y, 4));
						return;
					}
				}
				if ( down&& left&&!right) {
					if (random.Bool()) {
						energy.Add(new Energy(x+1, y, 2));
						return;
					} else {
						energy.Add(new Energy(x, y+1, 3));
						return;
					}
				}
				if (!down&&!left&& right) { energy.Add(new Energy(x+1, y, 2)); return; }
				if (!down&& left&&!right) { energy.Add(new Energy(x-1, y, 4)); return; }
				if ( down&&!left&&!right) { energy.Add(new Energy(x,y+1,3)); return; }
			}
		}

		void NewEnergyWatermill(int x, int y) {
			bool up = false, left = false, right = false;

			if (terrain[x].IsTopBlocks[y-1]) up=terrain[x].TopBlocks[y-1].Id==(ushort)BlockId.Label;

			if (terrain[x-1]!=null) {
				if (terrain[x-1].IsTopBlocks[y]) left=terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Label;
			}

			if (terrain[x+1]!=null) {
				if (terrain[x+1].IsTopBlocks[y]) right=terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.Label;
			}

			if (!up&&!left&&!right) {
				return;
			} else {
				if (up&&left&&right) {
					switch (random.Int(3)) {
						case 0: energy.Add(new Energy(x+1, y, 2)); return;
						case 1: energy.Add(new Energy(x, y-1, 1)); return;
						case 2: energy.Add(new Energy(x-1, y, 4)); return;
					}
				}
				if (!up&&left&&right) {
					if (random.Bool()) {
						energy.Add(new Energy(x+1, y, 2));
						return;
					} else {
						energy.Add(new Energy(x-1, y, 4));
						return;
					}
				}
				if (up&&!left&&right) {
					if (random.Bool()) {
						energy.Add(new Energy(x, y-1, 1));
						return;
					} else {
						energy.Add(new Energy(x-1, y, 4));
						return;
					}
				}
				if (up&&left&&!right) {
					if (random.Bool()) {
						energy.Add(new Energy(x+1, y, 2));
						return;
					} else {
						energy.Add(new Energy(x, y-1, 1));
						return;
					}
				}
				if (!up&&!left&&right) { energy.Add(new Energy(x-1, y, 4)); return; }
				if (!up&&left&&!right) { energy.Add(new Energy(x+1, y, 2)); return; }
				if (up&&!left&&!right) { energy.Add(new Energy(x, y-1, 1)); return; }
			}
		}

		void RefreshAroundLabels(int x, int y) {
			if (y==0) return;
			if (y>124) return;
			if (x<=0) return;
			if (x>=TerrainLength) return;

			if (terrain[x].IsTopBlocks[y+1]) {
				if (terrain[x].TopBlocks[y+1].Id==(ushort)BlockId.Label) SetIndexLabel(x, y+1);
			}

			if (terrain[x].IsTopBlocks[y-1]) {
				if (terrain[x].TopBlocks[y-1].Id==(ushort)BlockId.Label) SetIndexLabel(x, y-1);
			}

			if (terrain[x+1].IsTopBlocks[y]) {
				if (terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.Label) SetIndexLabel(x+1, y);
			}

			if (terrain[x-1].IsTopBlocks[y]) {
				if (terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Label) SetIndexLabel(x-1, y);
			}
		}

		void SetIndexLabel(int x, int y) {
			bool up=false, down=false, left=false, right=false;
			Terrain chunk=terrain[x];
			if (chunk.IsTopBlocks[y-1])
				up=chunk.TopBlocks[y-1].Id==(ushort)BlockId.Label
				|| chunk.TopBlocks[y-1].Id==(ushort)BlockId.Lamp
				|| chunk.TopBlocks[y-1].Id==(ushort)BlockId.Radio
				|| chunk.TopBlocks[y-1].Id==(ushort)BlockId.Macerator
				|| chunk.TopBlocks[y-1].Id==(ushort)BlockId.Windmill
				|| chunk.TopBlocks[y-1].Id==(ushort)BlockId.SewingMachine
				|| chunk.TopBlocks[y-1].Id==(ushort)BlockId.SolarPanel
				|| chunk.TopBlocks[y-1].Id==(ushort)BlockId.Charger
				|| chunk.TopBlocks[y-1].Id==(ushort)BlockId.FurnaceElectric;;

			if (chunk.IsTopBlocks[y+1])
				down = chunk.TopBlocks[y+1].Id==(ushort)BlockId.Label
				|| chunk.TopBlocks[y+1].Id==(ushort)BlockId.Lamp
				|| chunk.TopBlocks[y+1].Id==(ushort)BlockId.Radio
				|| chunk.TopBlocks[y+1].Id==(ushort)BlockId.Windmill
				|| chunk.TopBlocks[y+1].Id==(ushort)BlockId.Charger
				|| chunk.TopBlocks[y+1].Id==(ushort)BlockId.Macerator
				|| chunk.TopBlocks[y+1].Id==(ushort)BlockId.Miner
				|| chunk.TopBlocks[y+1].Id==(ushort)BlockId.Watermill
				|| chunk.TopBlocks[y+1].Id==(ushort)BlockId.FurnaceElectric;

			if (terrain[x-1].TopBlocks[y]!=null)
				left = terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Label
				|| terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Lamp
				|| terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Radio
				|| terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Windmill
				|| terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Watermill
				|| terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.SolarPanel
				|| terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.SewingMachine
				|| terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Charger
				|| terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Miner
				|| terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.FurnaceElectric
				|| terrain[x-1].TopBlocks[y].Id==(ushort)BlockId.Macerator;

			if (terrain[x+1].IsTopBlocks[y])
				right = terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.Label
				|| terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.Lamp
				|| terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.Radio
				|| terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.Windmill
				|| terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.FurnaceElectric
				|| terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.SewingMachine
				|| terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.Macerator
				|| terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.SolarPanel
				|| terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.Charger
				|| terrain[x+1].TopBlocks[y].Id==(ushort)BlockId.Watermill;



			if ( up && down && left && right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=15; return; }
			if (!up && down && left && right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=14; return; }
			if ( up && down && left &&!right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=13; return; }
			if ( up &&!down && left && right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=12; return; }
			if ( up && down &&!left && right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=11; return; }
			if ( up && down &&!left &&!right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=10; return; }
			if (!up &&!down && left && right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=9;  return; }
			if ( up &&!down && left &&!right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=8;  return; }
			if (!up && down && left &&!right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=7;  return; }
			if (!up && down &&!left && right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=6;  return; }
			if ( up &&!down &&!left && right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=5;  return; }
			if (!up &&!down && left &&!right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=4;  return; }
			if (!up && down &&!left &&!right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=3;  return; }
			if (!up &&!down &&!left && right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=2;  return; }
			if ( up &&!down &&!left &&!right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=1;  return; }
			if (!up &&!down &&!left &&!right) { ((ScreenBlock)chunk.TopBlocks[y]).Screen=0;  return; }
		}
		#endregion

		#region Blocks in the lists
		void SetWintableSources() {
			foreach (ShortAndByte w in windable) {
				Block[] blocks=terrain[w.X].TopBlocks;

				switch (blocks[w.Y].Id) {
					case (ushort)BlockId.Windmill:
						((AnimatedBlockOffset)blocks[w.Y]).imageSpeed=windForce;
						break;

					case (ushort)BlockId.Flag:
						((AnimatedBlock)blocks[w.Y]).imageSpeed=windForce;
						break;
				}
			}
		}

		void RemoveFromWintable(int x, int y) {
			for (int i = 0; i<windable.Count; i++) {
				if (windable[i].X==x) {
					if (windable[i].Y==y) {
						windable.RemoveAt(i);
						return;
					}
				} 
			}
		}

		//void RemoveFromBarrels(int x, int y) {
		//    foreach (ShortAndByte w in Barrels) {
		//        if (w.X==x) {
		//            if (w.Y==y) {
		//                Barrels.Remove(w);
		//                return;
		//            }
		//        }
		//    }
		//}

		void RemovefromChargers(int x, int y) {
			for (int i = 0; i<Chargers.Count; i++) {
				if (Chargers[i].X==x) {
					if (Chargers[i].Y==y) {
						Chargers.RemoveAt(i);
						return;
					}
				}
			}
		}

		void RemovefromOxygenMachines(int x, int y) {
			for (int i = 0; i<OxygenMachines.Count; i++) {
				if (OxygenMachines[i].X==x) {
					if (OxygenMachines[i].Y==y) {
						OxygenMachines.RemoveAt(i);
						return;
					}
				}
			}
		}

		void RemovefromMiners(int x, int y) {
			for (int i = 0; i<Miners.Count; i++) {
				if (Miners[i].X==x) {
					if (Miners[i].Y==y) {
						Miners.RemoveAt(i);
						return;
					}
				}
			}
		}

		void RemovefromFurnaceStone(int x, int y) {
			for (int i = 0; i<FurnaceStone.Count; i++) {
				if (FurnaceStone[i].X==x) {
					if (FurnaceStone[i].Y==y) {
						FurnaceStone.RemoveAt(i);
						return;
					}
				}
			}
		}

		void RemovefromComposters(int x, int y) {
			for (int i = 0; i<Composters.Count; i++) {
				if (Composters[i].X==x) {
					if (Composters[i].Y==y) {
						Composters.RemoveAt(i);
						return;
					}
				}
			}
		}

		void RemovefromBucketsForRubber(int x, int y) {
			for (int i = 0; i<bucketRubber.Count; i++) {
				if (bucketRubber[i].X==x) {
					if (bucketRubber[i].Y==y) {
						bucketRubber.RemoveAt(i);
						return;
					}
				}
			}
		}
		#endregion

		void SetMousePos() {
			if (Setting.Scale.Without==Setting.currentScale) {
			//	float DividerZoom=1/Setting.Zoom;
				mousePos = new Vector2((newMouseState.X-Global.WindowWidthHalf)*divider_zoom/*/Setting.Zoom*/+WindowCenterX, (newMouseState.Y-Global.WindowHeightHalf)*divider_zoom/*/Setting.Zoom*/+WindowCenterY);
				return;
			}

			if (Setting.Scale.Proportions==Setting.currentScale) {
				float screenScaleH = Global.WindowHeight/560f;
				float screenScaleW = Global.WindowWidth/848f;

				if (screenScaleH>screenScaleW) {
					mousePos= new Vector2((int)((newMouseState.X-Global.WindowWidthHalf)/screenScaleW*divider_zoom+(Global.WindowWidth-(int)(screenScaleW*848f))/2)+WindowCenterX, (int)((newMouseState.Y-Global.WindowHeightHalf)/screenScaleW*divider_zoom)+WindowCenterY);
					return;
				} else {
					mousePos = new Vector2((int)((newMouseState.X-Global.WindowWidthHalf)/screenScaleH*divider_zoom)+WindowCenterX, (int)((newMouseState.Y-Global.WindowHeightHalf)/screenScaleH*divider_zoom)+WindowCenterX+(Global.WindowHeight-(int)(screenScaleH*560f))/2);
					return;
				}
			}

			mousePos= new Vector2((newMouseState.X-Global.WindowWidthHalf)/(Global.WindowWidth/848f)*divider_zoom+WindowCenterX, (newMouseState.Y-Global.WindowHeightHalf)/((float)Global.WindowHeight/560f)*divider_zoom+WindowCenterY);
		}

		void MobileON() => ( mobileOS=new Mobile.System { Content=Rabcr.content } ).Init();

		#region Jobs
		void ChargerJob(ShortAndByte ch) {
			 MashineBlockBasic charger=(MashineBlockBasic)terrain[ch.X].TopBlocks[ch.Y];
			if (charger.Inv[0].Id!=0) {
				if (charger.Energy>5) {
					switch (charger.Inv[0].Id) {
						case (ushort)Items.ElectricDrillOff:
							{
								ItemInvTool32 tool =(ItemInvTool32)charger.Inv[0];
								if (tool.GetCount==1) {
									charger.Inv[0]=new ItemInvTool32(
										ItemIdToTexture((ushort)Items.ElectricDrill),
										(ushort)Items.ElectricDrill,
										1,
										GameMethods.ToolMax((ushort)Items.ElectricDrill),
										(int)tool.posTex.X,
										(int)tool.posTex.Y
										);
								} else {
									if (tool.GetCount<99) {
										tool.SetCount=tool.GetCount+1;
									}
								}
							}
							return;

						case (ushort)Items.ElectricSawOff:
							{
								ItemInvTool32 tool =(ItemInvTool32)charger.Inv[0];
								if (tool.GetCount==1) {
									charger.Inv[0]=new ItemInvTool32(
										ItemIdToTexture((ushort)Items.ElectricSaw),
										(ushort)Items.ElectricSaw,
										1,
										GameMethods.ToolMax((ushort)Items.ElectricSaw),
										(int)tool.posTex.X,
										(int)tool.posTex.Y
										);
								} else {
									if (tool.GetCount<99) {
										tool.SetCount=tool.GetCount+1;
									}
								}
							}
							return;

						case (ushort)Items.TorchElectricOFF:
							{
								ItemInvTool32 tool =(ItemInvTool32)charger.Inv[0];
								if (tool.GetCount==1) {
									charger.Inv[0]=new ItemInvTool32(
										ItemIdToTexture((ushort)Items.TorchElectricON),
										(ushort)Items.TorchElectricON,
										1,
										GameMethods.ToolMax((ushort)Items.TorchElectricON),
										(int)tool.posTex.X,
										(int)tool.posTex.Y
									);
								} else {
									if (tool.GetCount<99) {
										tool.SetCount=tool.GetCount+1;
									}
								}
							}
							return;

						case (ushort)Items.AirTank:
							{
								if (notNeedScafander) {
									ItemInvTool32 tool =(ItemInvTool32)charger.Inv[0];
									if (tool.GetCount<99) {
										tool.SetCount=tool.GetCount+1;
									}
								}
							}
							return;

						case (ushort)Items.AirTank2:
							{
								if (notNeedScafander) {
									ItemInvTool32 tool =(ItemInvTool32)charger.Inv[0];
									if (tool.GetCount<99) {
										tool.SetCount=tool.GetCount+1;
									}
								}
							}
							return;
					}
				}
			}
		}

		void OxygenMachineJob(ShortAndByte ch) {
			MashineBlockBasic oxygenMachine=(MashineBlockBasic)terrain[ch.X].TopBlocks[ch.Y];
			if (dayAlpha>0.5f) {
				if (random.Bool_10Percent())oxygenMachine.AddEnergy();
			}

			if (oxygenMachine.Inv[0].Id!=0) {
				if (oxygenMachine.Energy>5) {
					switch (oxygenMachine.Inv[0].Id) {
						case (ushort)Items.AirTank:
							{
								ItemInvTool32 tool =(ItemInvTool32)oxygenMachine.Inv[0];
								if (tool.GetCount<99) {
									tool.SetCount=tool.GetCount+1;
								}
							}
							return;

						case (ushort)Items.AirTank2:
							{
								ItemInvTool32 tool =(ItemInvTool32)oxygenMachine.Inv[0];
								if (tool.GetCount<99) {
									tool.SetCount=tool.GetCount+1;
								}
							}
							return;
					}
				}
			}
		}

		//void BarrelJob(ShortAndByte ch) {
		//  //  Barrel barrel=(Barrel)terrain[ch.X].TopBlocks[ch.Y];
		//    //if (barrel.Sealing) {
		//    //    if (barrel.SealTimeTo<DateTime.Now) {
		//    //        ReceipeSeal receipe=barrel.receipe;

		//    //        barrel.Sealing=false;

		//    //        // Get multipler of receipe
		//    //        int multipler;
		//    //        if (receipe.LiquidInto.Id!=(ushort)LiquidId.None) multipler=barrel.LiquidAmount/receipe.LiquidInto.Mass;
		//    //        else {
		//    //            switch (barrel.Inv[0]){
		//    //                case ItemInvBasic16 i: multipler=i.GetCount/((ItemNonInvBasic)receipe.ItemIn).Count; break;
		//    //                case ItemInvBasic32 i: multipler=i.GetCount/((ItemNonInvBasic)receipe.ItemIn).Count; break;
		//    //                case ItemInvFood16 i:  multipler=i.GetCount/((ItemNonInvFood)receipe.ItemIn).Count;  break;
		//    //                case ItemInvFood32 i:  multipler=i.GetCount/((ItemNonInvFood)receipe.ItemIn).Count;  break;
		//    //                case ItemInvTool16 i:  multipler=i.GetCount/((ItemNonInvFood)receipe.ItemIn).Count;  break;
		//    //                case ItemInvTool32 i:  multipler=i.GetCount/((ItemNonInvFood)receipe.ItemIn).Count;  break;

		//    //                default: multipler=1; break;
		//    //            }
		//    //        }

		//    //        // Add items
		//    //        ushort IdOut=receipe.ItemOut.Id;
		//    //        switch (receipe.ItemOut) {
		//    //            case ItemNonInvBasic i:
		//    //                if (GameMethods.IsItemInvBasic32(IdOut)) barrel.Inv[1]=new ItemInvBasic32(ItemIdToTexture(IdOut),IdOut,i.Count*multipler);
		//    //                else barrel.Inv[1]=new ItemInvBasic16(ItemIdToTexture(IdOut),IdOut,i.Count*multipler);
		//    //                barrel.LiquidId=receipe.LiquidOut.Id;
		//    //                barrel.LiquidAmount=receipe.LiquidOut.Mass*multipler;
		//    //                break;

		//    //            case ItemNonInvFood i:
		//    //                if (GameMethods.IsItemInvFood32(IdOut)) barrel.Inv[1]=new ItemInvFood32(ItemIdToTexture(IdOut), IdOut,i.Count*multipler,i.CountMaximum,i.Descay,i.DescayMaximum);
		//    //                else barrel.Inv[1]=new ItemInvFood16(ItemIdToTexture(IdOut), IdOut, i.Count*multipler,i.CountMaximum,i.Descay,i.DescayMaximum);
		//    //                barrel.LiquidId=receipe.LiquidOut.Id;
		//    //                barrel.LiquidAmount=receipe.LiquidOut.Mass*multipler;
		//    //                break;

		//    //            case ItemNonInvTool i:
		//    //                if (GameMethods.IsItemInvFood32(IdOut)) barrel.Inv[1]=new ItemInvTool32(ItemIdToTexture(IdOut), IdOut,i.Count*multipler,i.Maximum);
		//    //                else barrel.Inv[1]=new ItemInvTool16(ItemIdToTexture(IdOut), IdOut, i.Count*multipler,i.Maximum);
		//    //                barrel.LiquidId=receipe.LiquidOut.Id;
		//    //                barrel.LiquidAmount=receipe.LiquidOut.Mass*multipler;
		//    //                break;

		//    //            case ItemNonInvNonStackable i:
		//    //                if (GameMethods.IsItemInvNonStackable32(IdOut)) barrel.Inv[1]=new ItemInvNonStackable32(ItemIdToTexture(IdOut), IdOut);
		//    //                else barrel.Inv[1]=new ItemInvNonStackable16(ItemIdToTexture(IdOut), IdOut);
		//    //                barrel.LiquidId=receipe.LiquidOut.Id;
		//    //                barrel.LiquidAmount=receipe.LiquidOut.Mass;
		//    //                break;

		//    //            case ItemNonInvBasicColoritzedNonStackable i:
		//    //                barrel.Inv[1]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(IdOut), IdOut, i.color);
		//    //                barrel.LiquidId=receipe.LiquidOut.Id;
		//    //                barrel.LiquidAmount=receipe.LiquidOut.Mass;
		//    //                break;

		//    //            #if DEBUG
		//    //            default: throw new Exception("Unknown category");
		//    //            #endif
		//    //        }
		//    //    }
		//    //}
		//}

		void MinerJob(ShortAndByte ch) {
			MashineBlockBasic miner=(MashineBlockBasic)terrain[ch.X].TopBlocks[ch.Y];

			if (miner.Energy>5) {
				for (int i = 0; i<DroppedItems.Count; i++) {
					if (DroppedItems[i].X==ch.X*16) {
						Item item = DroppedItems[i];
						if (item.Y>ch.Y*16) {
							ItemNonInv remain = MinerAddItem(item.item, miner);
							if (remain==null) return;
							if (item!=null) {
								DropItemToPos(remain, item.X, item.Y);
							}
							DroppedItems.RemoveAt(i);
							return;
						}
					} 
				}
				Terrain chunk=terrain[ch.X];
				for (int y=ch.Y+1; y<100; y++) {
					if (chunk.IsSolidBlocks[y]) {
						destroyBlockX=ch.X;
						destroyBlockY=y;
						GetItemsFromBlock(chunk.SolidBlocks[y].Id, ch.X, y);
						chunk.SolidBlocks[y]=null;
						chunk.IsSolidBlocks[y]=false;
						return;
					}
				}
			}
		}

		bool BucketsForRubberJob(ShortAndByte ch) {
		  //  Block bucket=terrain[ch.X].TopBlocks[ch.Y];

			for (int y=ch.Y+1; y<100; y++) {
				if (terrain[ch.X].IsBackground[y]) {
					if (terrain[ch.X].Background[y].Id==(ushort)BlockId.RubberTreeWood) {
						if (random.Int(2000)==1) {
							RemovefromBucketsForRubber(ch.X,ch.Y);
							TerrainSetTopBlockNormal(ch.X,ch.Y,(ushort)BlockId.BucketWithLatex,TextureBucketWithLatex);
							return true;
						}
					}
				}
			}
			return false;
		}
		#endregion

		ItemNonInv MinerAddItem(ItemNonInv item, MashineBlockBasic miner) {
			switch (item) {
				case ItemNonInvBasic ii:
					{
						ushort id=ii.Id;
						if (GameMethods.IsItemInvBasic16(id)) {

							int remain=ii.Count;

							for (int i=0; i<miner.Inv.Length; i++) {
								if (miner.Inv[i].Id == id) {
									ItemInvBasic16 slot=(ItemInvBasic16)miner.Inv[i];
									if (slot.GetCount<99) {
										if (slot.GetCount+remain<=99) {
											slot.SetCount=slot.GetCount-remain;
											return null;
										}else{
											remain-=99-slot.GetCount;
											slot.SetCount=99;
										}
									}
								}
							}

							for (int i=0; i<miner.Inv.Length; i++) {
								if (miner.Inv[i].Id == 0) {
									miner.Inv[i]=new ItemInvBasic16(ItemIdToTexture(id),id,remain/*,0,0*/);
									return null;
								}
							}
							return new ItemNonInvBasic(id, remain);
						} else{
							int remain=ii.Count;

							for (int i=0; i<miner.Inv.Length; i++) {
								if (miner.Inv[i].Id == id) {
									ItemInvBasic32 slot=(ItemInvBasic32)miner.Inv[i];
									if (slot.GetCount<99) {
										if (slot.GetCount+remain<=99) {
											slot.SetCount=slot.GetCount-remain;
											return null;
										}else{
											remain-=99-slot.GetCount;
											slot.SetCount=99;
										}
									}
								}
							}

							for (int i=0; i<miner.Inv.Length; i++) {
								if (miner.Inv[i].Id == 0) {
									miner.Inv[i]=new ItemInvBasic32(ItemIdToTexture(id),id,remain/*,0,0*/);
									return null;
								}
							}
							return new ItemNonInvBasic(id, remain);
						}
					}
			}

			return item;
		}

		void CountGravity(AstronomicalObject[] objects) {
			for (int oi=0; oi<objects.Length; oi++) {
				AstronomicalObject o = objects[oi];

				if (o.Name!=null) {
					if (o.Name==world) {
						gravity=(float)(6.67259e-11*o.Mass/(o.MeanDiameter*o.MeanDiameter*1000000))/20f;
						notNeedScafander=o.astrO==AstrO.Life;
						dayLenght=(int)(o.DayLenght*200);
						return;
					}
				}
				if (o.Childs!=null) {
					CountGravity(o.Childs);
					if (gravity!=0) return;
				}
			}
		}

		#region Destroy Upper
		void DestroyGrassUp(int x, int y) {
			Terrain chunk=terrain[x];

			if (chunk.IsTopBlocks[y]) {
				ushort id=chunk.TopBlocks[y].Id;

				if (GameMethods.IsDirtPlaceable(id)){
				//if (id==(ushort)BlockId.Alore
				//|| id==(ushort)BlockId.Rose
				//|| id==(ushort)BlockId.Orchid
				//|| id==(ushort)BlockId.Dandelion
				//|| id==(ushort)BlockId.Violet
				//|| id==(ushort)BlockId.Heather
				//|| id==(ushort)BlockId.GrassDesert
				//|| id==(ushort)BlockId.GrassForest
				//|| id==(ushort)BlockId.GrassHills
				//|| id==(ushort)BlockId.GrassJungle
				//|| id==(ushort)BlockId.GrassPlains

				//|| id==(ushort)BlockId.BranchALittle1
				//|| id==(ushort)BlockId.BranchALittle2
				//|| id==(ushort)BlockId.BranchFull
				//|| id==(ushort)BlockId.BranchWithout

				//|| id==(ushort)BlockId.CherrySapling
				//|| id==(ushort)BlockId.AppleSapling
				//|| id==(ushort)BlockId.LemonSapling
				//|| id==(ushort)BlockId.LindenSapling
				//|| id==(ushort)BlockId.OakSapling
				//|| id==(ushort)BlockId.OrangeSapling
				//|| id==(ushort)BlockId.PineSapling
				//|| id==(ushort)BlockId.PlumSapling
				//|| id==(ushort)BlockId.SpruceSapling

				//|| id==(ushort)BlockId.Rocks

				//|| id==(ushort)BlockId.Boletus
				//|| id==(ushort)BlockId.Champignon
				//|| id==(ushort)BlockId.Toadstool) {
					destroingBlockDepth=BlockType.Top;
					if (Global.WorldDifficulty!=2) GetItemsFromBlock((byte)id, x, y);
				 ///  chunk.IsTopBlocks[y]=false;
				  //  if (((AirSolidBlock)chunk.SolidBlocks[y]).Back==null)chunk.SolidBlocks[y]=null;
				 //   else ((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=null;

					RemoveTopBlock(x,y);
					return;
				}
			}

			for (int i = 0; i<chunk.Plants.Count; i++) {
				Plant p = chunk.Plants[i];
				if (p.Height==y) {
					destroingBlockDepth=0;
					if (Global.WorldDifficulty!=2) GetItemsFromBlock(p.Id, x, y);
					chunk.Plants.RemoveAt(i);
					RemovePlant(x);
					break;
				} 
			}
		}

		void DestroySandUp(int x, int y) {
			Terrain chunk=terrain[x];
			if (chunk.IsTopBlocks[y]) {
				ushort id=chunk.TopBlocks[y].Id;

				if (id==(ushort)BlockId.Alore
				|| id==(ushort)BlockId.GrassDesert
				|| id==(ushort)BlockId.BranchALittle1
				|| id==(ushort)BlockId.BranchALittle2
				|| id==(ushort)BlockId.BranchFull
				|| id==(ushort)BlockId.BranchWithout
				|| id==(ushort)BlockId.Rocks) {
					if (Global.WorldDifficulty!=2) GetItemsFromBlock((byte)id, x, y);
				  //  chunk.IsTopBlocks[y]=false;
				  //  ((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=null;
					RemoveTopBlock(x,y);
					return;
				}

				if (id==(ushort)BlockId.CactusBig) {

					// current
					if (Global.WorldDifficulty!=2) GetItemsFromBlock((byte)id,x,y);
				  //  chunk.IsTopBlocks[y]=false;
				   // ((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=null;
					RemoveTopBlock(x,y);

					//if more
					for (int yy=y-1; yy>=0; yy--) {
						if (chunk.IsTopBlocks[yy]) {
							if (chunk.TopBlocks[yy].Id==(ushort)BlockId.CactusBig) {
								if (Global.WorldDifficulty!=2) GetItemsFromBlock((byte)id, x, yy);
							   // chunk.IsTopBlocks[yy]=false;
							   //((AirSolidBlock)chunk.SolidBlocks[yy]).Top=chunk.TopBlocks[yy]=null;
								RemoveTopBlock(x,yy);
							}
						}else return;
					}
				}

				if (id==(ushort)BlockId.CactusSmall) {

					// current
					if (Global.WorldDifficulty!=2) GetItemsFromBlock((byte)id,x,y);
				 //   chunk.IsTopBlocks[y]=false;
				   // ((AirSolidBlock)chunk.SolidBlocks[y]).Top=chunk.TopBlocks[y]=null;
					RemoveTopBlock(x,y);

					//if more
					for (int yy=y-1; yy>=0; yy--) {
						if (chunk.IsTopBlocks[yy]) {
							if (chunk.TopBlocks[yy].Id==(ushort)BlockId.CactusSmall) {
								if (Global.WorldDifficulty!=2) GetItemsFromBlock((byte)id, x, yy);
							  //  chunk.IsTopBlocks[yy]=false;
							  //  ((AirSolidBlock)chunk.SolidBlocks[yy]).Top=chunk.TopBlocks[yy]=null;

								RemoveTopBlock(x,yy);
							}
						} else return;
					}
				}
			}
		}

		void DestroyCactusBig(int x, int y) {
			Terrain chunk=terrain[x];

			for (int yy=y-1; yy>=0; yy--) {
				if (chunk.IsTopBlocks[yy]) {
					if (chunk.TopBlocks[yy].Id==(ushort)BlockId.CactusBig) {
						if (Global.WorldDifficulty!=2) GetItemsFromBlock((ushort)BlockId.CactusBig, x, yy);
					  //  chunk.IsTopBlocks[yy]=false;
					 //   ((AirSolidBlock)chunk.SolidBlocks[yy]).Top=chunk.TopBlocks[yy]=null;
						RemoveTopBlock(x,yy);
					}
				} else return;
			}
		}

		void DestroyCactusSmall(int x, int y) {
			Terrain chunk=terrain[x];

			for (int yy=y-1; yy>=0; yy--) {
				if (chunk.IsTopBlocks[yy]) {
					if (chunk.TopBlocks[yy].Id==(ushort)BlockId.CactusSmall) {
						if (Global.WorldDifficulty!=2) GetItemsFromBlock((ushort)BlockId.CactusSmall, x, yy);
						//chunk.IsTopBlocks[yy]=false;
					   // ((AirSolidBlock)chunk.SolidBlocks[yy]).Top=chunk.TopBlocks[yy]=null;
						RemoveTopBlock(x,yy);
					}
				} else return;
			}
		}
		#endregion

		#region Trees
		void AutoDestroyLeaves(ushort wood, ushort leaves) {
			int Xran=terrainStartIndexX+random.Int(terrainStartIndexW-terrainStartIndexX),
				Yran=terrainStartIndexY+random.Int(terrainStartIndexH-terrainStartIndexY);

			if (terrain[Xran].IsTopBlocks[Yran]) {
				if (terrain[Xran].TopBlocks[Yran].Id==leaves) {

					//Rectangle
					int startX=Xran-4, startY=Yran-4, endX=Xran+4, endY=Yran+4;

					//Limit
					if (startX<0) startX=0;
					if (startY<0) startY=0;

					if (endX>TerrainLength) endX=TerrainLength;
					if (endY>120) endY=120;

					if (IsNotNearWood(wood, startX, startY, endX, endY)) {
						GetItemsFromBlock(leaves, Xran, Yran);
						Terrain chunk=terrain[Xran];

						List<UShortAndByte> listLeaves=((LeavesBlock)chunk.TopBlocks[Yran]).tree.TitlesLeaves;
													
						for (int i = 0; i<listLeaves.Count; i++) {
							if (listLeaves[i].X==Xran){
								if (listLeaves[i].Y==Yran) listLeaves.RemoveAt(i);
							}
						}
						chunk.TopBlocks[Yran]=null;
						chunk.IsTopBlocks[Yran]=false;
						chunk.RefreshLightingRemoveTop(Yran, leaves);
					}
				}
			}
		}

		void RemoveTopBlock(int x, int y) {
			Terrain chunk=terrain[x];

			ushort id=chunk.TopBlocks[y].Id;
			chunk.TopBlocks[y]=null;
			chunk.IsTopBlocks[y]=false;
			chunk.RefreshLightingRemoveTop(y,id);
		}

		void AutoDestroyLeaves(ushort wood, ushort leaves, ushort alternativeLeaves) {
			int Xran=terrainStartIndexX+random.Int(terrainStartIndexW-terrainStartIndexX),
				Yran=terrainStartIndexY+random.Int(terrainStartIndexH-terrainStartIndexY);

			if (terrain[Xran].IsTopBlocks[Yran]) {
				Terrain chunk=terrain[Xran];
				ushort id =chunk.TopBlocks[Yran].Id;
				if (id==leaves || id==alternativeLeaves) {

					//Rectangle
					int startX=Xran-4, startY=Yran-4, endX=Xran+4, endY=Yran+4;

					//Limit
					if (startX<0) startX=0;
					if (startY<0) startY=0;

					if (endX>TerrainLength) endX=TerrainLength;
					if (endY>120) endY=120;

					if (IsNotNearWood(wood, startX, startY, endX, endY)) {
						GetItemsFromBlock(id, Xran, Yran);

						Tree tree=((LeavesBlock)chunk.TopBlocks[Yran]).tree;

						// if not Artifical leaves (created by player)
						if (tree!=null) {
							List<UShortAndByte> listLeaves=((LeavesBlock)chunk.TopBlocks[Yran]).tree.TitlesLeaves;
													
							for (int i = 0; i<listLeaves.Count; i++) {
								if (listLeaves[i].X==destroyBlockX) {
									if (listLeaves[i].Y==Yran) listLeaves.RemoveAt(i);
								}
							}
						}

						terrain[Xran].IsTopBlocks[Yran]=false;
						terrain[Xran].TopBlocks[Yran]=null;
						chunk.RefreshLightingRemoveTop(Yran,id);
					}
				}
			}
		}

		void AutoDestroyLeaves(ushort wood, ushort leaves, ushort alternativeLeaves, ushort alternativeLeaves2) {
			int Xran=terrainStartIndexX+random.Int(terrainStartIndexW-terrainStartIndexX),
				Yran=terrainStartIndexY+random.Int(terrainStartIndexH-terrainStartIndexY);

			if (terrain[Xran].IsTopBlocks[Yran]) {
				Terrain chunk=terrain[Xran];
				ushort id=chunk.TopBlocks[Yran].Id;
				if (id==leaves || id==alternativeLeaves|| id==alternativeLeaves2) {

					//Rectangle
					int startX=Xran-4, startY=Yran-4, endX=Xran+4, endY=Yran+4;

					//Limit
					if (startX<0) startX=0;
					if (startY<0) startY=0;

					if (endX>TerrainLength) endX=TerrainLength;
					if (endY>120) endY=120;

					if (IsNotNearWood(wood, startX, startY, endX, endY)) {
						GetItemsFromBlock(id, Xran, Yran);

						Tree tree=((LeavesBlock)chunk.TopBlocks[Yran]).tree;

						// if not Artifical leaves (created by player)
						if (tree!=null) {
							List<UShortAndByte> listLeaves=((LeavesBlock)chunk.TopBlocks[Yran]).tree.TitlesLeaves;
													
							for (int i = 0; i<listLeaves.Count; i++) {
								if (listLeaves[i].X==destroyBlockX) {
									if (listLeaves[i].Y==Yran) listLeaves.RemoveAt(i);
								}
							}
						}
						terrain[Xran].IsTopBlocks[Yran]=false;
						terrain[Xran].TopBlocks[Yran]=null;
						chunk.RefreshLightingRemoveTop(Yran, id);
					}
				}
			}
		}

		bool IsNotNearWood(ushort wood, int startX, int startY, int endX, int endY) {
			for (int x=startX; x<endX; x++) {
				Terrain chunk=terrain[x];
				for (int y=startY; y<endY; y++) {
					if (chunk.IsBackground[y]) {
						if (chunk.Background[y].Id==wood) return false;
					}
				}
			}
			return true;
		}
		
		#endregion

		#region Animals
		void MoveChicken() {
			int Xran=terrainStartIndexX+random.Int(terrainStartIndexW-terrainStartIndexX);
		 //   Terrain chunk=terrain[Xran];
			if (terrain[Xran].Mobs.Count!=0) {
				foreach (Mob mob in terrain[Xran].Mobs) {
					if (mob.Id==(ushort)BlockId.Chicken) {
						int height=mob.Height;

						Chicken ch=(Chicken)mob;

						if (!ch.needToChangeChunk) {
							if (!ch.move) {
								if (!ch.Eat) {
									if (ch.Dir) {
										Terrain chunkP1=terrain[Xran+1];

										if (!chunkP1.IsSolidBlocks[height]) {
											if (chunkP1.IsSolidBlocks[height+1]) {
												ch.lastChunkID=(short)Xran;
												ch.move=true;
												ch.moveCount=16*4;
												ch.moveType=MoveType.Walk;
												movingAnimals.Add(mob);
												return;
											} else {
												bool ok=true;
												if (chunkP1.IsTopBlocks[height+1]) {
													if (chunkP1.TopBlocks[height+1].Id==(ushort)BlockId.WaterSalt) ok=false;
													else if (chunkP1.TopBlocks[height+1].Id==(ushort)BlockId.WaterBlock) ok=false;
												}
												if (ok) {
													//Fall
													ch.lastChunkID=(short)Xran;
													ch.move=true;
													ch.moveCount=16*4;
													ch.moveType=MoveType.Fall;
													movingAnimals.Add(mob);
													return;
												}
											}
										} else {
											// Jump
											if (!chunkP1.IsSolidBlocks[height-1]) {
												ch.lastChunkID=(short)Xran;
												ch.move=true;
												ch.moveCount=16*4;
												ch.moveType=MoveType.Jump;
												movingAnimals.Add(mob);
												return;
											}
										}
									} else {
										Terrain chunkM1=terrain[Xran-1];
										if (!chunkM1.IsSolidBlocks[height]) {
											if (chunkM1.IsSolidBlocks[height+1]) {
												ch.lastChunkID=(short)Xran;
												ch.move=true;
												ch.moveCount=16*4;
												ch.moveType=MoveType.Walk;
												movingAnimals.Add(mob);
												return;
											} else {
												bool ok=true;
												if (chunkM1.IsTopBlocks[height+1]) {
													if (chunkM1.TopBlocks[height+1].Id==(ushort)BlockId.WaterSalt) ok=false;
													else if (chunkM1.TopBlocks[height+1].Id==(ushort)BlockId.WaterBlock) ok=false;
												}
												if (ok) {
													//Fall
													ch.lastChunkID=(short)Xran;
													ch.move=true;
													ch.moveCount=16*4;
													ch.moveType=MoveType.Fall;
													movingAnimals.Add(mob);
													return;
												}
											}
										} else {
											// Jump
											if (!chunkM1.IsSolidBlocks[height-1]) {
												//Fall
												ch.lastChunkID=(short)Xran;
												ch.move=true;
												ch.moveCount=16*4;
												ch.moveType=MoveType.Jump;
												movingAnimals.Add(mob);
												return;
											}
										}
									}
								} else {
									if (random.Bool_1Percent()) {
										int /*x=(int)ch.Position.X/16,*/
											y=(int)ch.Position.Y/16;
										Terrain chunk=terrain[Xran];

										if (!chunk.IsTopBlocks[y]) {
											chunk.IsTopBlocks[y]=true;
											chunk.TopBlocks[y]=TopBlockFromId((ushort)BlockId.EggDrop,ch.Position);
											break;
										}
									}
								}
							}
						}
					}
				}
			}
		}

		void MoveRabbit() {
			int Xran=terrainStartIndexX+random.Int(terrainStartIndexW-terrainStartIndexX);

			if (terrain[Xran].Mobs.Count!=0) {
				foreach (Mob mob in terrain[Xran].Mobs) {
					if (mob.Id==(ushort)BlockId.Rabbit) {
						int height=mob.Height;

						Rabbit r=(Rabbit)mob;

						if (!r.needToChangeChunk) {
							if (!r.switchtoWalk) {
								if (!r.move) {
									if (r.Dir) {
										Terrain chunkP1=terrain[Xran+1];
										if (!chunkP1.IsSolidBlocks[height]) {
											if (chunkP1.IsSolidBlocks[height+1]) {
												r.lastChunkID=(short)Xran;
												r.moveCount=16*4;
												r.switchtoWalk=true;
												r.thisTexture=rabbitWalkTexture;
												r.moveType=MoveType.Walk;
												movingAnimals.Add(mob);
											}else {
												bool ok=true;
												if (chunkP1.IsTopBlocks[height+1]) {
													if (chunkP1.TopBlocks[height+1].Id==(ushort)BlockId.WaterSalt) ok=false;
													else if (chunkP1.TopBlocks[height+1].Id==(ushort)BlockId.WaterBlock) ok=false;
												}
												if (ok) {
													//Fall
													r.lastChunkID=(short)Xran;
													r.moveCount=16*4;
													r.switchtoWalk=true;
													r.thisTexture=rabbitWalkTexture;
													r.moveType=MoveType.Fall;
													movingAnimals.Add(mob);
												}
											}
										} else {
											// Jump
											if (!chunkP1.IsSolidBlocks[height-1]) {
												r.lastChunkID=(short)Xran;
												r.moveCount=16*4;
												r.switchtoWalk=true;
												r.thisTexture=rabbitWalkTexture;
												r.moveType=MoveType.Jump;
												movingAnimals.Add(mob);
											}
										}
									} else {
										Terrain chunkM1=terrain[Xran-1];

										if (!chunkM1.IsSolidBlocks[height]) {
											if (chunkM1.IsSolidBlocks[height+1]) {
												r.lastChunkID=(short)Xran;
												r.moveCount=16*4;
												r.switchtoWalk=true;
												r.moveType=MoveType.Walk;
												r.thisTexture=rabbitWalkTexture;
												movingAnimals.Add(mob);
											} else {
												bool ok=true;
												if (chunkM1.IsTopBlocks[height+1]) {
													if (chunkM1.TopBlocks[height+1].Id==(ushort)BlockId.WaterSalt) ok=false;
													else if (chunkM1.TopBlocks[height+1].Id==(ushort)BlockId.WaterBlock) ok=false;
												}
												if (ok) {
													//Fall
													r.lastChunkID=(short)Xran;
													r.moveCount=16*4;
													r.switchtoWalk=true;
													r.moveType=MoveType.Fall;
													r.thisTexture=rabbitWalkTexture;
													movingAnimals.Add(mob);
												}
											}
										} else {
											// Jump
											if (!chunkM1.IsSolidBlocks[height-1]) {
												r.lastChunkID=(short)Xran;
												r.moveCount=16*4;
												r.switchtoWalk=true;
												r.moveType=MoveType.Jump;
												r.thisTexture=rabbitWalkTexture;
												movingAnimals.Add(mob);
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		void MoveParrot() {
			int Xran=terrainStartIndexX+random.Int(terrainStartIndexW-terrainStartIndexX);
			Terrain chunk=terrain[Xran];
			if (chunk.Mobs.Count!=0) {
				foreach (Mob mob in chunk.Mobs) {
					if (mob.Id==(ushort)BlockId.MobParrot) {
						int height=mob.Height;

						Parrot r=(Parrot)mob;
						//if (!r.Flying) {
							// Sort random near chunks
							List<(int, float)> rndChunks=new List<(int, float)>();
							int src=(int)(r.Position.X)/16;
							for (int i=1; i<20; i++){ 
								(int, float) ch1 = (src+i, random.Float());
								(int, float) ch2 = (src-i, random.Float());
								rndChunks.Add(ch1);
								rndChunks.Add(ch2);
							}
					
							// sort chunks randomly 
							rndChunks.Sort((i1, i2) => i1.Item2.CompareTo(i2.Item2));

							// find leaves and move to
							foreach ((int, float) ch in rndChunks) { 
								Terrain chunkJ=terrain[ch.Item1];
								for (int i=chunkJ.StartSomething; i<125; i++) { 
									if (chunkJ.IsTopBlocks[i]){ 
										if (GameMethods.IsLeaves(chunkJ.TopBlocks[i].Id)) {
                                            r.StopFlying +=  delegate() { 
												Terrain dscChunk=terrain[(int)r.Position.X/16];

                                                if (dscChunk.IsTopBlocks[(int)r.Position.Y/16]) {
													return true;
                                                }
                                    
												return false; 
											};
                               
                                            r.SetFlying(ch.Item1*16,i*16);
											return;
										}
									}	
								}
						//	}
						}
					}
				}
			}
		}


        void FinishMooving() {
			foreach (Mob mob in movingAnimals) {
				switch (mob.Id) {
					case (ushort)BlockId.Chicken:
						{
							Chicken ch =(Chicken)mob;
							if (ch.needToChangeChunk) {
								movingAnimals.Remove(mob);
								ch.needToChangeChunk=false;
								terrain[ch.lastChunkID].Mobs.Remove(ch);
								terrain[(int)(mob.Position.X/16)].Mobs.Add(ch);
								return;
							}
							break;
						}

					 case (ushort)BlockId.Rabbit:
						{
							Rabbit r =(Rabbit)mob;
							if (r.needToChangeChunk) {
								movingAnimals.Remove(mob);
								r.needToChangeChunk=false;
								terrain[r.lastChunkID].Mobs.Remove(r);
								terrain[(int)(mob.Position.X/16)].Mobs.Add(r);
								return;
							}
							break;
						}
				}
			}
		}
		#endregion

		#region Trees
		void TreeRubber(int x, int y) {
			TerrainSetBackground(x,   y-1, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			TerrainSetBackground(x,   y-2, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			TerrainSetBackground(x,   y-3, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			TerrainSetBackground(x,   y-4, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			TerrainSetBackground(x,   y-5, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			TerrainSetBackground(x,   y-6, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			TerrainSetBackground(x,   y-7, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			TerrainSetBackground(x,   y-8, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			TerrainSetBackground(x-2, y-6, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			if (random.Bool()) TerrainSetBackground(x+1, y-4, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			if (random.Bool()) TerrainSetBackground(x-1, y-4, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			if (random.Bool()) TerrainSetBackground(x-1, y-5, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);
			if (random.Bool()) TerrainSetBackground(x+1, y-5, (ushort)BlockId.RubberTreeWood, TextureRubberTreeWood);

			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x+2, y-5, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x-2, y-5, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x+1, y-6, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x,   y-6, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x-1, y-6, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x+2, y-6, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x-2, y-6, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x+1, y-7, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x,   y-7, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x-1, y-7, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x+2, y-7, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x-2, y-7, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x+1, y-8, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x,   y-8, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x-1, y-8, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x+1, y-9, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x,   y-9, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x-1, y-9, (ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);
			TerrainSetTopBlockNormal(x,   y-10,(ushort)BlockId.RubberTreeLeaves, TextureRubberTreeLeaves);

			  Terrain chunk0=terrain[x ],
				chunkM1=terrain[x- 1],
				chunkM2=terrain[x- 2],
				chunkP1=terrain[x+ 1],
				chunkP2=terrain[x+ 2];

			if (chunkM2.StartSomething>y-6) chunkM2.StartSomething=y-6;
			if (chunkM1.StartSomething>y-9) chunkM1.StartSomething=y-9;
			if (chunk0. StartSomething>y-10) chunk0. StartSomething=y-10;
			if (chunkP1.StartSomething>y-9) chunkP1.StartSomething=y-9;
			if (chunkP2.StartSomething>y-6) chunkP2.StartSomething=y-6;
		}

		void TreeAcacia(int x, int y) {
			TerrainSetBackground(x, y-1, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);
			TerrainSetBackground(x, y-2, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);
			TerrainSetBackground(x, y-3, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);
			TerrainSetBackground(x, y-4, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);
			TerrainSetBackground(x, y-5, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);

			if (random.Bool()) {
				TerrainSetBackground(x-1, y-4, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);
				TerrainSetBackground(x-2, y-5, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);
				TerrainSetBackground(x+1, y-3, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);
				TerrainSetBackground(x+2, y-4, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);

				TerrainSetTopBlockNormal(x-2, y-4, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
				TerrainSetTopBlockNormal(x-3, y-4, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			} else {
				TerrainSetBackground(x+1, y-4, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);
				TerrainSetBackground(x+2, y-5, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);
				TerrainSetBackground(x-1, y-3, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);
				TerrainSetBackground(x-2, y-4, (ushort)BlockId.AcaciaWood, TextureAcaciaWood);

				TerrainSetTopBlockNormal(x+2,y-4, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
				TerrainSetTopBlockNormal(x+3,y-4, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			}

			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			TerrainSetTopBlockNormal(x+2, y-5, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			TerrainSetTopBlockNormal(x-2, y-5, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			TerrainSetTopBlockNormal(x+3, y-5, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			TerrainSetTopBlockNormal(x-3, y-5, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			TerrainSetTopBlockNormal(x-1, y-6, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			TerrainSetTopBlockNormal(x+1, y-6, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);
			TerrainSetTopBlockNormal(x,   y-6, (ushort)BlockId.AcaciaLeaves, TextureAcaciaLeaves);

			Terrain 
				chunk0= terrain[x   ],
				chunkM1=terrain[x- 1],
				chunkM2=terrain[x- 2],
				chunkM3=terrain[x- 3],
				chunkP1=terrain[x+ 1],
				chunkP2=terrain[x+ 2],
				chunkP3=terrain[x+ 3];

			if (chunkM3.StartSomething>y-5) chunkM3.StartSomething=y-5;
			if (chunkM2.StartSomething>y-5) chunkM2.StartSomething=y-5;
			if (chunkM1.StartSomething>y-6) chunkM1.StartSomething=y-6;
			if (chunk0. StartSomething>y-6) chunk0. StartSomething=y-6;
			if (chunkP1.StartSomething>y-6) chunkP1.StartSomething=y-6;
			if (chunkP2.StartSomething>y-5) chunkP2.StartSomething=y-5;
			if (chunkP3.StartSomething>y-5) chunkP3.StartSomething=y-5;
		}

		void TreeMangrove(int x, int y) {
			TerrainSetBackground(x, y-1, (ushort)BlockId.MangroveWood, TextureMangroveWood);
			TerrainSetBackground(x, y-2, (ushort)BlockId.MangroveWood, TextureMangroveWood);
			TerrainSetBackground(x, y-3, (ushort)BlockId.MangroveWood, TextureMangroveWood);
			TerrainSetBackground(x, y-4, (ushort)BlockId.MangroveWood, TextureMangroveWood);

			if (random.Bool()) TerrainSetBackground(x-1, y-3, (ushort)BlockId.MangroveWood, TextureMangroveWood);
			if (random.Bool()) TerrainSetBackground(x+1, y-4, (ushort)BlockId.MangroveWood, TextureMangroveWood);

			TerrainSetTopBlockNormal(x+1, y-3, (ushort)BlockId.MangroveLeaves, TextureMangroveLeaves);
			TerrainSetTopBlockNormal(x-1, y-3, (ushort)BlockId.MangroveLeaves, TextureMangroveLeaves);
			TerrainSetTopBlockNormal(x,   y-3, (ushort)BlockId.MangroveLeaves, TextureMangroveLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.MangroveLeaves, TextureMangroveLeaves);
			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.MangroveLeaves, TextureMangroveLeaves);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.MangroveLeaves, TextureMangroveLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.MangroveLeaves, TextureMangroveLeaves);

			Terrain 
				chunkM1=terrain[x- 1],
				chunk0= terrain[x   ],
				chunkP1=terrain[x+ 1];

			if (chunkM1.StartSomething>y-4) chunkM1.StartSomething=y-4;
			if (chunk0. StartSomething>y-5) chunk0. StartSomething=y-5;
			if (chunkP1.StartSomething>y-4) chunkP1.StartSomething=y-4;
		}

		void TreeWillow(int x, int y) {
			TerrainSetBackground(x, y-1, (ushort)BlockId.WillowWood, TextureWillowWood);
			TerrainSetBackground(x, y-2, (ushort)BlockId.WillowWood, TextureWillowWood);
			TerrainSetBackground(x, y-3, (ushort)BlockId.WillowWood, TextureWillowWood);
			TerrainSetBackground(x, y-4, (ushort)BlockId.WillowWood, TextureWillowWood);
			if (random.Bool()) TerrainSetBackground(x, y-4, (ushort)BlockId.WillowWood, TextureWillowWood);

			switch (Rabcr.random.Int(3)) {
				case 0:
					TerrainSetBackground(x-1, y-3, (ushort)BlockId.WillowWood,TextureWillowWood);

					TerrainSetTopBlockNormal(x-1, y-2, (ushort)BlockId.WillowLeaves,TextureWillowLeaves);
					TerrainSetTopBlockNormal(x-2, y-1, (ushort)BlockId.WillowLeaves,TextureWillowLeaves);
					break;

				case 1:
					TerrainSetBackground(x-1, y+3, (ushort)BlockId.WillowWood, TextureWillowWood);

					TerrainSetTopBlockNormal(x-1, y+2, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
					TerrainSetTopBlockNormal(x-2, y+1, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
					break;

				case 2:
					TerrainSetBackground(x-1, y-3, (ushort)BlockId.WillowWood, TextureWillowWood);
					TerrainSetBackground(x+1, y-3, (ushort)BlockId.WillowWood, TextureWillowWood);
					break;
			}

			TerrainSetTopBlockNormal(x+2, y-2, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x-2, y-2, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x+1, y-3, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x-1, y-3, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x,   y-3, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x+2, y-3, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x-2, y-3, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x-2, y-4, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x+2, y-4, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.WillowLeaves, TextureWillowLeaves);

			Terrain 
				chunkM2=terrain[x- 2],
				chunkM1=terrain[x- 1],
				chunk0 =terrain[x   ],
				chunkP1=terrain[x+ 1],
				chunkP2=terrain[x+ 2];

			if (chunkM2.StartSomething>y-4) chunkM2.StartSomething=y-4;
			if (chunkM1.StartSomething>y-5) chunkM1.StartSomething=y-5;
			if (chunk0. StartSomething>y-5) chunk0. StartSomething=y-5;
			if (chunkP1.StartSomething>y-5) chunkP1.StartSomething=y-5;
			if (chunkP2.StartSomething>y-4) chunkP2.StartSomething=y-4;
		}

		void TreeEucalyptus(int x, int y) {
			TerrainSetBackground(x, y-1, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
			TerrainSetBackground(x, y-2, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
			TerrainSetBackground(x, y-3, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
			TerrainSetBackground(x, y-4, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
			TerrainSetBackground(x, y-5, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
			TerrainSetBackground(x, y-6, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);

			if (random.Bool()) {
				TerrainSetBackground(x-1, y-3, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
				TerrainSetBackground(x-2, y-4, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
				TerrainSetBackground(x-2, y-5, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);

				TerrainSetTopBlockNormal(x-3, y-4, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			} else {
				TerrainSetBackground(x-1, y-4, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
				TerrainSetBackground(x-2, y-5, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
			}

			if (random.Bool()) {
				TerrainSetBackground(x+1, y-3, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
				TerrainSetBackground(x+2, y-4, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
				TerrainSetBackground(x+2, y-5, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
				TerrainSetBackground(x+3, y-4, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
			} else {
				TerrainSetBackground(x+1, y-4, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
				TerrainSetBackground(x+2, y-5, (ushort)BlockId.EucalyptusWood, TextureEucalyptusWood);
			}

			TerrainSetTopBlockNormal(x+2, y-4, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x-2, y-4, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x+2, y-5, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x-2, y-5, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x+3, y-5, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x-3, y-5, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x,   y-6, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x+1, y-6, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x-1, y-6, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x-2, y-6, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x+2, y-6, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x-1, y-7, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x,   y-7, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);
			TerrainSetTopBlockNormal(x+1, y-7, (ushort)BlockId.EucalyptusLeaves, TextureEucalyptusLeaves);

			Terrain 
				chunkM2=terrain[x- 2],
				chunkM1=terrain[x- 1],
				chunk0= terrain[x   ],
				chunkP1=terrain[x+ 1],
				chunkP2=terrain[x+ 2];

			if (chunkM2.StartSomething>y-6) chunkM2.StartSomething=y-6;
			if (chunkM1.StartSomething>y-7) chunkM1.StartSomething=y-7;
			if (chunk0. StartSomething>y-7) chunk0. StartSomething=y-7;
			if (chunkP1.StartSomething>y-7) chunkP1.StartSomething=y-7;
			if (chunkP2.StartSomething>y-6) chunkP2.StartSomething=y-6;
		}

		void TreeOlive(int x, int y) {
			TerrainSetBackground(x, y-1, (ushort)BlockId.OliveWood, TextureOliveWood);
			TerrainSetBackground(x, y-2, (ushort)BlockId.OliveWood, TextureOliveWood);

			if (random.Bool()) {
				TerrainSetBackground(x,   y-3, (ushort)BlockId.OliveWood, TextureOliveWood);
				TerrainSetBackground(x-1, y-3, (ushort)BlockId.OliveWood, TextureOliveWood);
				TerrainSetBackground(x-1, y-4, (ushort)BlockId.OliveWood, TextureOliveWood);
				TerrainSetBackground(x-1, y-5, (ushort)BlockId.OliveWood, TextureOliveWood);
				TerrainSetBackground(x+1, y-4, (ushort)BlockId.OliveWood, TextureOliveWood);
			} else {
				TerrainSetBackground(x-1, y-3, (ushort)BlockId.OliveWood, TextureOliveWood);
				TerrainSetBackground(x+1, y-3, (ushort)BlockId.OliveWood, TextureOliveWood);
				TerrainSetBackground(x-1, y-4, (ushort)BlockId.OliveWood, TextureOliveWood);
			}

			TerrainSetTopBlockNormal(x-1, y-3, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x,   y-3, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x+1, y-3, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x+2, y-4, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x-2, y-4, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x-2, y-5, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x+2, y-5, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x-1, y-6, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x,   y-6, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);
			TerrainSetTopBlockNormal(x+1, y-6, (ushort)BlockId.OliveLeaves, TextureOliveLeaves);

			Terrain 
				chunkM2=terrain[x- 2],
				chunkM1=terrain[x- 1],
				chunk0 =terrain[x   ],
				chunkP1=terrain[x+ 1],
				chunkP2=terrain[x+ 2];

			if (chunkM2.StartSomething>y-8) chunkM2.StartSomething=y-5;
			if (chunkM1.StartSomething>y-6) chunkM1.StartSomething=y-6;
			if (chunk0. StartSomething>y-6) chunk0. StartSomething=y-6;
			if (chunkP1.StartSomething>y-6) chunkP1.StartSomething=y-6;
			if (chunkP2.StartSomething>y-8) chunkP2.StartSomething=y-5;
		}

		void TreeKapok(int x, int y) {

			TerrainSetBackground(x, y-1, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x+1, y-1,(ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x-1, y-1,(ushort)BlockId.KapokWood, TextureKapokWood);
	
			if (random.Bool()) {
				TerrainSetBackground(x+1, y-2,(ushort)BlockId.KapokWood, TextureKapokWood);
				TerrainSetBackground(x-1, y-2,(ushort)BlockId.KapokWood, TextureKapokWood);
			}

			TerrainSetBackground(x,   y-2,  (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-3,  (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-4,  (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-5,  (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-6,  (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-7,  (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-8,  (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-9,  (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-10, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-11, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-12, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-13, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-14, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-15, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-16, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x,   y-17, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x-1, y-14, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x-2, y-15, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x-1, y-13, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x-1, y-14, (ushort)BlockId.KapokWood, TextureKapokWood);
			TerrainSetBackground(x-2, y-15, (ushort)BlockId.KapokWood, TextureKapokWood);

			TerrainSetTopBlockNormal(x-3, y-15, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x-2, y-15, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x-1, y-15, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x+1, y-15, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x+2, y-15, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x+3, y-15, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x-3, y-16, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x-2, y-16, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x-1, y-16, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x,   y-16, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x+1, y-16, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x+2, y-16, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x+3, y-16, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x-3, y-17, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x-2, y-17, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x-1, y-17, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x,   y-17, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x+1, y-17, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x+2, y-17, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x+3, y-17, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x,   y-18, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x-1, y-18, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);
			TerrainSetTopBlockNormal(x+1, y-18, (ushort)BlockId.KapokLeaves, TextureKapokLeaves);

			Terrain 
				chunkM3=terrain[x-3],
				chunkM2=terrain[x-2],
				chunkM1=terrain[x-1],
				chunk0 =terrain[x  ],
				chunkP1=terrain[x+1],
				chunkP2=terrain[x+2],
				chunkP3=terrain[x+3];

			if (chunkM3.StartSomething>y-17) chunkM3.StartSomething=y-17;
			if (chunkM2.StartSomething>y-17) chunkM2.StartSomething=y-17;
			if (chunkM1.StartSomething>y-18) chunkM1.StartSomething=y-18;
			if (chunk0. StartSomething>y-18) chunk0. StartSomething=y-18;
			if (chunkP1.StartSomething>y-18) chunkP1.StartSomething=y-18;
			if (chunkP2.StartSomething>y-17) chunkP2.StartSomething=y-17;
			if (chunkP3.StartSomething>y-17) chunkP3.StartSomething=y-17;
		}

		void TreeApple(int x, int y) {
			TerrainSetBackground(x,   y-1, (ushort)BlockId.AppleWood, TextureAppleWood);
			TerrainSetBackground(x,   y-2, (ushort)BlockId.AppleWood, TextureAppleWood);
			TerrainSetBackground(x,   y-3, (ushort)BlockId.AppleWood, TextureAppleWood);
			TerrainSetBackground(x+1, y-3, (ushort)BlockId.AppleWood, TextureAppleWood);
			TerrainSetBackground(x,   y-4, (ushort)BlockId.AppleWood, TextureAppleWood);
			TerrainSetBackground(x+1, y-5, (ushort)BlockId.AppleWood, TextureAppleWood);
			TerrainSetBackground(x-1, y-5, (ushort)BlockId.AppleWood, TextureAppleWood);
			TerrainSetBackground(x+1, y-6, (ushort)BlockId.AppleWood, TextureAppleWood);
			
			TerrainSetTopBlockNormal(x+2, y-3,(ushort)BlockId.AppleLeavesWithApples, TextureAppleLeavesWithApples);
			TerrainSetTopBlockNormal(x-2, y-3,(ushort)BlockId.AppleLeaves, TextureAppleLeaves);
			TerrainSetTopBlockNormal(x+1, y-3,(ushort)BlockId.AppleLeavesWithApples, TextureAppleLeavesWithApples);
			TerrainSetTopBlockNormal(x-1, y-3,(ushort)BlockId.AppleLeaves, TextureAppleLeaves);
			TerrainSetTopBlockNormal(x,   y-3,(ushort)BlockId.AppleLeavesWithApples, TextureAppleLeavesWithApples);
			TerrainSetTopBlockNormal(x+2, y-4,(ushort)BlockId.AppleLeavesWithApples, TextureAppleLeavesWithApples);
			TerrainSetTopBlockNormal(x-2, y-4,(ushort)BlockId.AppleLeaves, TextureAppleLeaves);
			TerrainSetTopBlockNormal(x+1, y-4,(ushort)BlockId.AppleLeavesWithApples, TextureAppleLeavesWithApples);
			TerrainSetTopBlockNormal(x-1, y-4,(ushort)BlockId.AppleLeaves, TextureAppleLeaves);
			TerrainSetTopBlockNormal(x,   y-4,(ushort)BlockId.AppleLeavesWithApples, TextureAppleLeavesWithApples);
			TerrainSetTopBlockNormal(x+1, y-5,(ushort)BlockId.AppleLeaves, TextureAppleLeaves);
			TerrainSetTopBlockNormal(x-1, y-5,(ushort)BlockId.AppleLeavesWithApples, TextureAppleLeavesWithApples);
			TerrainSetTopBlockNormal(x,   y-5,(ushort)BlockId.AppleLeaves, TextureAppleLeaves);
			TerrainSetTopBlockNormal(x+1, y-6,(ushort)BlockId.AppleLeavesWithApples, TextureAppleLeavesWithApples);
			TerrainSetTopBlockNormal(x-1, y-6,(ushort)BlockId.AppleLeavesWithApples, TextureAppleLeavesWithApples);
			TerrainSetTopBlockNormal(x,   y-6,(ushort)BlockId.AppleLeaves, TextureAppleLeaves);
	
			Terrain 
				chunk0 =terrain[x   ],
				chunkM1=terrain[x- 1],
				chunkM2=terrain[x- 2],
				chunkP1=terrain[x+ 1],
				chunkP2=terrain[x+ 2];

			if (chunkM2.StartSomething>y-4) chunkM2.StartSomething=y-4;
			if (chunkM1.StartSomething>y-6) chunkM1.StartSomething=y-6;
			if (chunk0. StartSomething>y-6) chunk0. StartSomething=y-6;
			if (chunkP1.StartSomething>y-6) chunkP1.StartSomething=y-6;
			if (chunkP2.StartSomething>y-4) chunkP2.StartSomething=y-4;
		}

		void TreeOrange(int x, int y) {
			TerrainSetBackground(x, y-1, (ushort)BlockId.OrangeWood, TextureOrangeWood);
			TerrainSetBackground(x, y-2, (ushort)BlockId.OrangeWood, TextureOrangeWood);
			TerrainSetBackground(x, y-3, (ushort)BlockId.OrangeWood, TextureOrangeWood);
			TerrainSetBackground(x, y-4, (ushort)BlockId.OrangeWood, TextureOrangeWood);
			TerrainSetBackground(x, y-5, (ushort)BlockId.OrangeWood, TextureOrangeWood);
			TerrainSetBackground(x, y-6, (ushort)BlockId.OrangeWood, TextureOrangeWood);

			if (random.Bool()) TerrainSetBackground(x-1, y-4, (ushort)BlockId.OrangeWood, TextureOrangeWood);
			if (random.Bool()) TerrainSetBackground(x+1, y-5, (ushort)BlockId.OrangeWood, TextureOrangeWood);
			if (random.Bool()) TerrainSetBackground(x-1, y-7, (ushort)BlockId.OrangeWood, TextureOrangeWood);
			if (random.Bool()) {
				TerrainSetBackground(x+1, y-7, (ushort)BlockId.OrangeWood, TextureOrangeWood);

				if (random.Bool()) TerrainSetBackground(x+1, y-8, (ushort)BlockId.OrangeWood, TextureOrangeWood);
			}

			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.OrangeLeaves, TextureOrangeLeavesWithOranges);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x+2, y-5, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x-2, y-5, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x,   y-6, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x+2, y-6, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x-2, y-6, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x+1, y-6, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x-1, y-6, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x,   y-7, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x+2, y-7, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x-2, y-7, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x+1, y-7, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x-1, y-7, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x,   y-8, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x+2, y-8, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x-2, y-8, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x+1, y-8, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x-1, y-8, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x+1, y-9, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x-1, y-9, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
			TerrainSetTopBlockNormal(x,   y-9, (ushort)BlockId.OrangeLeaves, TextureOrangeLeaves);
	
			Terrain 
				chunkM2=terrain[x-2],
				chunkM1=terrain[x-1],
				chunk0 =terrain[x  ],
				chunkP1=terrain[x+1],
				chunkP2=terrain[x+2];

			if (chunkM2.StartSomething>y-8) chunkM2.StartSomething=y-8;
			if (chunkM1.StartSomething>y-9) chunkM1.StartSomething=y-9;
			if (chunk0. StartSomething>y-9) chunk0.StartSomething =y-9;
			if (chunkP1.StartSomething>y-9) chunkP1.StartSomething=y-9;
			if (chunkP2.StartSomething>y-8) chunkP2.StartSomething=y-8;
		}

		void TreeLemon(int x, int y) {
			TerrainSetBackground(0, y-1, (ushort)BlockId.LemonWood, TextureLemonWood);
			TerrainSetBackground(0, y-2, (ushort)BlockId.LemonWood, TextureLemonWood);
			TerrainSetBackground(0, y-3, (ushort)BlockId.LemonWood, TextureLemonWood);
			TerrainSetBackground(0, y-4, (ushort)BlockId.LemonWood, TextureLemonWood);

			if (random.Bool()) TerrainSetBackground(x-1, y-4,(ushort)BlockId.LemonWood, TextureLemonWood);
			else TerrainSetBackground(x+1, y-5, (ushort)BlockId.LemonWood, TextureLemonWood);

			TerrainSetTopBlockNormal(x+1, y-3, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x-1, y-3, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x,   y-3, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x+2, y-4, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x-2, y-4, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x+2, y-5, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x-2, y-5, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x,   y-6, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x+1, y-6, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
			TerrainSetTopBlockNormal(x-1, y-6, (ushort)BlockId.LemonLeaves, TextureLemonLeaves);
		

			Terrain 
				chunkM2=terrain[x- 2],
				chunkM1=terrain[x- 1],
				chunk0 =terrain[x   ],
				chunkP1=terrain[x+ 1],
				chunkP2=terrain[x+ 2];

			if (chunkM2.StartSomething>y-5) chunkM2.StartSomething=y-5;
			if (chunkM1.StartSomething>y-6) chunkM1.StartSomething=y-6;
			if (chunk0. StartSomething>y-6) chunk0. StartSomething=y-6;
			if (chunkP1.StartSomething>y-6) chunkP1.StartSomething=y-6;
			if (chunkP2.StartSomething>y-5) chunkP2.StartSomething=y-5;
		}

		void TreeCherry(int x, int y) {
			TerrainSetBackground(x,   y-1, (ushort)BlockId.CherryWood, cherryWoodTexture);
			TerrainSetBackground(x,   y-2, (ushort)BlockId.CherryWood, cherryWoodTexture);
			TerrainSetBackground(x,   y-3, (ushort)BlockId.CherryWood, cherryWoodTexture);
			TerrainSetBackground(x-1, y-3, (ushort)BlockId.CherryWood, cherryWoodTexture);
			TerrainSetBackground(x,   y-4, (ushort)BlockId.CherryWood, cherryWoodTexture);
			TerrainSetBackground(x-1, y-5, (ushort)BlockId.CherryWood, cherryWoodTexture);
			TerrainSetBackground(x+1, y-5, (ushort)BlockId.CherryWood, cherryWoodTexture);
			TerrainSetBackground(x-1, y-6, (ushort)BlockId.CherryWood, cherryWoodTexture);

			TerrainSetTopBlockNormal(x+1, y-3, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x-1, y-3, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x,   y-3, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x+2, y-4, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x-2, y-4, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x+2, y-5, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x-2, y-5, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x+1, y-6, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x-1, y-6, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x,   y-6, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x+1, y-7, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x-1, y-7, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);
			TerrainSetTopBlockNormal(x,   y-7, (ushort)BlockId.CherryLeaves, TextureCherryLeaves);

			Terrain 
				chunkM2=terrain[x-2],
				chunkM1=terrain[x-1],
				chunk0 =terrain[x  ],
				chunkP1=terrain[x+1],
				chunkP2=terrain[x+2];

			if (chunkM2.StartSomething>y-5) chunkM2.StartSomething=y-5;
			if (chunkM1.StartSomething>y-7) chunkM1.StartSomething=y-7;
			if (chunk0. StartSomething>y-7) chunk0. StartSomething=y-7;
			if (chunkP1.StartSomething>y-7) chunkP1.StartSomething=y-7;
			if (chunkP2.StartSomething>y-5) chunkP2.StartSomething=y-5;
		}

		void TreePlum(int x, int y) {
			TerrainSetBackground(x,   y-1, (ushort)BlockId.PlumWood, TexturePlumWood);
			TerrainSetBackground(x,   y-2, (ushort)BlockId.PlumWood, TexturePlumWood);
			TerrainSetBackground(x,   y-3, (ushort)BlockId.PlumWood, TexturePlumWood);
			TerrainSetBackground(x-1, y-3, (ushort)BlockId.PlumWood, TexturePlumWood);
			TerrainSetBackground(x,   y-4, (ushort)BlockId.PlumWood, TexturePlumWood);
			TerrainSetBackground(x-1, y-5, (ushort)BlockId.PlumWood, TexturePlumWood);
			TerrainSetBackground(x+1, y-5, (ushort)BlockId.PlumWood, TexturePlumWood);
			TerrainSetBackground(x-1, y-6, (ushort)BlockId.PlumWood, TexturePlumWood);
			
			TerrainSetTopBlockNormal(x+1, y-3, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x-1, y-3, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x,   y-3, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x+2, y-4, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x-2, y-4, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x+2, y-5, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x-2, y-5, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x+1, y-6, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x-1, y-6, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x,   y-6, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);
			TerrainSetTopBlockNormal(x,   y-7, (ushort)BlockId.PlumLeaves, TexturePlumLeaves);

			Terrain 
				chunkM2=terrain[x-2],
				chunkM1=terrain[x-1],
				chunk0 =terrain[x  ],
				chunkP1=terrain[x+1],
				chunkP2=terrain[x+2];

			if (chunkM2.StartSomething>y-5) chunkM2.StartSomething=y-5;
			if (chunkM1.StartSomething>y-7) chunkM1.StartSomething=y-7;
			if (chunk0. StartSomething>y-7) chunk0. StartSomething=y-7;
			if (chunkP1.StartSomething>y-7) chunkP1.StartSomething=y-7;
			if (chunkP2.StartSomething>y-5) chunkP2.StartSomething=y-5;
		}

		void TreeOakMedium(int x, int y) {
			TerrainSetBackground(x,   y-1, (ushort)BlockId.OakWood, TextureOakWood);
			TerrainSetBackground(x,   y-2, (ushort)BlockId.OakWood, TextureOakWood);
			TerrainSetBackground(x,   y-3, (ushort)BlockId.OakWood, TextureOakWood);
			TerrainSetBackground(x,   y-4, (ushort)BlockId.OakWood, TextureOakWood);
			TerrainSetBackground(x,   y-6, (ushort)BlockId.OakWood, TextureOakWood);
			TerrainSetBackground(x,   y-5, (ushort)BlockId.OakWood, TextureOakWood);
			TerrainSetBackground(x-1, y-7, (ushort)BlockId.OakWood, TextureOakWood);
			TerrainSetBackground(x+1, y-7, (ushort)BlockId.OakWood, TextureOakWood);
			if (random.Bool()) TerrainSetBackground(x+1, y-4, (ushort)BlockId.OakWood, TextureOakWood);
			if (random.Bool()) TerrainSetBackground(x+1, y-8, (ushort)BlockId.OakWood, TextureOakWood);
			if (random.Bool()) TerrainSetBackground(x-1, y-8, (ushort)BlockId.OakWood, TextureOakWood);
			if (random.Bool_20Percent()) TerrainSetBackground(x-2, y-7, (ushort)BlockId.OakWood, TextureOakWood);

			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x+2, y-5, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-2, y-5, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x+1, y-6, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x,   y-6, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-1, y-6, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x+2, y-6, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-2, y-6, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x+1, y-7, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x,   y-7, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-1, y-7, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x+2, y-7, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-2, y-7, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x+1, y-8, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x,   y-8, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-1, y-8, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-2, y-8, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x+2, y-8, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x+1, y-9, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x,   y-9, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-1, y-9, (ushort)BlockId.OakLeaves, TextureOakLeaves);
				 
			Terrain 
				chunkM2=terrain[x-2],
				chunkM1=terrain[x-1],
				chunk0 =terrain[x  ],
				chunkP1=terrain[x+1],
				chunkP2=terrain[x+2];

			if (chunkM2.StartSomething>y-8) chunkM2.StartSomething=y-8;
			if (chunkM1.StartSomething>y-9) chunkM1.StartSomething=y-9;
			if (chunk0. StartSomething>y-9) chunk0. StartSomething=y-9;
			if (chunkP1.StartSomething>y-9) chunkP1.StartSomething=y-9;
			if (chunkP2.StartSomething>y-8) chunkP2.StartSomething=y-8;
		}

		void TreePine(int x, int y) {
			TerrainSetBackground(0, y-1,(ushort)BlockId.PineWood, pineWoodTexture);
			TerrainSetBackground(0, y-2,(ushort)BlockId.PineWood, pineWoodTexture);
			TerrainSetBackground(0, y-3,(ushort)BlockId.PineWood, pineWoodTexture);
			TerrainSetBackground(0, y-4,(ushort)BlockId.PineWood, pineWoodTexture);
			TerrainSetBackground(0, y-5,(ushort)BlockId.PineWood, pineWoodTexture);
			TerrainSetBackground(0, y-6,(ushort)BlockId.PineWood, pineWoodTexture);
			TerrainSetBackground(0, y-7,(ushort)BlockId.PineWood, pineWoodTexture);

			if (random.Bool())  TerrainSetBackground(0, y-8,(ushort)BlockId.PineWood, pineWoodTexture);

			TerrainSetTopBlockNormal(x+2, y-6,  (ushort)BlockId.PineLeaves, pineLeavesTexture);
			TerrainSetTopBlockNormal(x-2, y-6,  (ushort)BlockId.PineLeaves, pineLeavesTexture);
			TerrainSetTopBlockNormal(x+1, y-7,  (ushort)BlockId.PineLeaves, pineLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-7,  (ushort)BlockId.PineLeaves, pineLeavesTexture);
			TerrainSetTopBlockNormal(x-1, y-7,  (ushort)BlockId.PineLeaves, pineLeavesTexture);
			TerrainSetTopBlockNormal(x+2, y-8,  (ushort)BlockId.PineLeaves, pineLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-8,  (ushort)BlockId.PineLeaves, pineLeavesTexture);
			TerrainSetTopBlockNormal(x-2, y-8,  (ushort)BlockId.PineLeaves, pineLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-9,  (ushort)BlockId.PineLeaves, pineLeavesTexture);
			TerrainSetTopBlockNormal(x-1, y-10, (ushort)BlockId.PineLeaves, pineLeavesTexture);
			TerrainSetTopBlockNormal(x+1, y-10, (ushort)BlockId.PineLeaves, pineLeavesTexture);

			Terrain chunk0=terrain[x ],
				chunkM1=terrain[x- 1],
				chunkM2=terrain[x- 2],
				chunkP1=terrain[x+ 1],
				chunkP2=terrain[x+ 2];

			if (chunkM2.StartSomething>y-8 ) chunkM2.StartSomething=y-8;
			if (chunkM1.StartSomething>y-10) chunkM1.StartSomething=y-10;
			if (chunk0. StartSomething>y-9 ) chunk0. StartSomething=y-9;
			if (chunkP1.StartSomething>y-10) chunkP1.StartSomething=y-10;
			if (chunkP2.StartSomething>y-8 ) chunkP2.StartSomething=y-8;
		}

		void TreeSpruceBig(int x,int y) {
			TerrainSetBackground(x, y-1, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			TerrainSetBackground(x, y-2, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			TerrainSetBackground(x, y-3, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			TerrainSetBackground(x, y-4, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			TerrainSetBackground(x, y-5, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			TerrainSetBackground(x, y-6, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			TerrainSetBackground(x, y-8, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			if (random.Bool()) TerrainSetBackground(x+1, y-4, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			if (random.Bool()) TerrainSetBackground(x-1, y-4, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			if (random.Bool()) TerrainSetBackground(x+1, y-6, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			if (random.Bool()) TerrainSetBackground(x-1, y-6, (ushort)BlockId.SpruceWood, spruceWoodTexture);

			TerrainSetTopBlockNormal(x+2, y-3,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x+1, y-3,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-3,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-1, y-3,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-2, y-3,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x+2, y-4,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x+1, y-4,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-4,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-1, y-4,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-2, y-4,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-2, y-5,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x+1, y-5,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-5,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-1, y-5,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x+2, y-5,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x+1, y-6,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-6,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-1, y-6,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-7,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x+1, y-7,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-1, y-7,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x+1, y-8,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-8,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-1, y-8,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-9,  (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-10, (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);

			Terrain 
				chunkM2=terrain[x-2],
				chunkM1=terrain[x-1],
				chunk0 =terrain[x  ],
				chunkP1=terrain[x+1],
				chunkP2=terrain[x+2];

			if (chunkM2.StartSomething>y-5 ) chunkM2.StartSomething=y-5;
			if (chunkM1.StartSomething>y-8 ) chunkM1.StartSomething=y-8;
			if (chunk0. StartSomething>y-10) chunk0. StartSomething=y-10;
			if (chunkP1.StartSomething>y-8 ) chunkP1.StartSomething=y-8;
			if (chunkP2.StartSomething>y-5 ) chunkP2.StartSomething=y-5;
		}

		void TreeLinden(int x, int y) {
			TerrainSetBackground(0, y-1, (ushort)BlockId.LindenWood, TextureLindenWood);
			TerrainSetBackground(0, y-2, (ushort)BlockId.LindenWood, TextureLindenWood);
			TerrainSetBackground(0, y-3, (ushort)BlockId.LindenWood, TextureLindenWood);
			TerrainSetBackground(0, y-4, (ushort)BlockId.LindenWood, TextureLindenWood);
			TerrainSetBackground(0, y-5, (ushort)BlockId.LindenWood, TextureLindenWood);

			if (random.Bool()) TerrainSetBackground(x+1, y-4, (ushort)BlockId.LindenWood, TextureLindenWood);
			if (random.Bool()) TerrainSetBackground(x-1, y-4, (ushort)BlockId.LindenWood, TextureLindenWood);
			if (random.Bool()) TerrainSetBackground(x-1, y-5, (ushort)BlockId.LindenWood, TextureLindenWood);
			if (random.Bool()) TerrainSetBackground(x+1, y-5, (ushort)BlockId.LindenWood, TextureLindenWood);

			TerrainSetBackground(x,   y-6, (ushort)BlockId.LindenWood, TextureLindenWood);
			TerrainSetBackground(x,   y-7, (ushort)BlockId.LindenWood, TextureLindenWood);
			TerrainSetBackground(x,   y-8, (ushort)BlockId.LindenWood, TextureLindenWood);
			TerrainSetBackground(x-2, y-6, (ushort)BlockId.LindenWood, TextureLindenWood);

			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x+1, y-5, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x-1, y-5, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x+2, y-5, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x-2, y-5, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x+1, y-6, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x,   y-6, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x-1, y-6, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x+2, y-6, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x-2, y-6, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x+1, y-7, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x,   y-7, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x-1, y-7, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x+2, y-7, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x-2, y-7, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x+1, y-8, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x,   y-8, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x-1, y-8, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x+1, y-9, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x,   y-9, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x-1, y-9, (ushort)BlockId.LindenLeaves, TextureLindenLeaves);
			TerrainSetTopBlockNormal(x,   y-10,(ushort)BlockId.LindenLeaves, TextureLindenLeaves);

			Terrain 
				chunkM2=terrain[x- 2],
				chunkM1=terrain[x- 1],
				chunk0 =terrain[x   ],
				chunkP1=terrain[x+ 1],
				chunkP2=terrain[x+ 2];

			if (chunkM2.StartSomething>y-7 ) chunkM2.StartSomething=y-7;
			if (chunkM1.StartSomething>y-9 ) chunkM1.StartSomething=y-9;
			if (chunk0. StartSomething>y-10) chunk0. StartSomething=y-10;
			if (chunkP1.StartSomething>y-9 ) chunkP1.StartSomething=y-9;
			if (chunkP2.StartSomething>y-7 ) chunkP2.StartSomething=y-7;
		}

		void TreeOakLittle(int x, int y) {
			TerrainSetBackground(x, y-1, (ushort)BlockId.OakWood, TextureOakWood);
			TerrainSetBackground(x, y-2, (ushort)BlockId.OakWood, TextureOakWood);
			TerrainSetBackground(x, y-3, (ushort)BlockId.OakWood, TextureOakWood);

			TerrainSetTopBlockNormal(x+1, y-3, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x,   y-3, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-1, y-3, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x+1, y-4, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x-1, y-4, (ushort)BlockId.OakLeaves, TextureOakLeaves);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.OakLeaves, TextureOakLeaves);
		
			Terrain 
				chunkM1=terrain[x-1],
				chunk0 =terrain[x  ],
				chunkP1=terrain[x+1];

			if (chunkM1.StartSomething>y-4) chunkM1.StartSomething=y-4;
			if (chunk0. StartSomething>y-5) chunk0. StartSomething=y-5;
			if (chunkP1.StartSomething>y-4) chunkP1.StartSomething=y-4;
		}

		void TreeSpruceLittle(int x, int y) {
			TerrainSetBackground(x, y-1, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			TerrainSetBackground(x, y-2, (ushort)BlockId.SpruceWood, spruceWoodTexture);
			TerrainSetBackground(x, y-3, (ushort)BlockId.SpruceWood, spruceWoodTexture);

			TerrainSetTopBlockNormal(x+1, y-2, (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-2, (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-1, y-2, (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x+1, y-3, (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-3, (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x-1, y-3, (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-4, (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
			TerrainSetTopBlockNormal(x,   y-5, (ushort)BlockId.SpruceLeaves, spruceLeavesTexture);
		
			Terrain 
				chunkM1=terrain[x-1],
				chunk0 =terrain[x  ],
				chunkP1=terrain[x+1];

			if (chunkM1.StartSomething>y-3) chunkM1.StartSomething=y-3;
			if (chunk0. StartSomething>y-5) chunk0. StartSomething=y-5;
			if (chunkP1.StartSomething>y-3) chunkP1.StartSomething=y-3;
		}
		#endregion

		#region Inventory positions
		static DInt InventoryGetPosClothes(int ix) {
			if (ix<4) return new DInt{ X=Global.WindowWidthHalf-300+4+60+4,    Y=Global.WindowHeightHalf-200+2+4+4+ix*40     };
			else      return new DInt{ X=Global.WindowWidthHalf-300+4+60+4+40, Y=Global.WindowHeightHalf-200+2+4+4+40*(ix-4) };
		}

		static Vector2 InventoryGetPosClothesVector2(int ix) {
			if (ix<4) return new Vector2{ X=Global.WindowWidthHalf-300+4+60+4,    Y=Global.WindowHeightHalf-200+2+4+4+ix*40     };
			else      return new Vector2{ X=Global.WindowWidthHalf-300+4+60+4+40, Y=Global.WindowHeightHalf-200+2+4+4+40*(ix-4) };
		}

		DInt InventoryGetPosNormalInv(int ix) {
			int xx=0, yh=0;

			for (int i=(inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
				if (i>maxInvCount) break;

				if (ix==i) return new DInt{X= Global.WindowWidthHalf-300+4+200+4+4+xx+4,Y=Global.WindowHeightHalf-200+2+4+yh+4 };
				
				xx+=40;

				if (xx==9*40) {
					xx=0;
					yh+=40;
				}
			}
			return null/*DInt.NotDefined*/;
		}

		Vector2 InventoryGetPosNormalInvVector2(int ix) {
			int xx=0, yh=0;

			for (int i=(inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
				if (i>maxInvCount) break;

				if (ix==i) return new Vector2{ X=Global.WindowWidthHalf-300+4+200+4+4+xx+4, Y=Global.WindowHeightHalf-200+2+4+yh+4 };
				
				xx+=40;

				if (xx==9*40) {
					xx=0;
					yh+=40;
				}
			}
			return Vector2.Zero;
		}

		static DInt InventoryGetPosNormal5(int ix) => new DInt{ X=Global.WindowWidth-36, Y=Global.WindowHeightHalf-80+ix*40+4 };

		static Vector2 InventoryGetPosNormal5Vector2(int ix) => new Vector2{ X=Global.WindowWidth-36, Y=Global.WindowHeightHalf-80+ix*40+4 };

		static DInt InventoryGetPosAdvBox(int i) {
			int row=i/12;
			return new DInt{ X=Global.WindowWidthHalf-300+10+5+5+row*40+4, Y=Global.WindowHeightHalf+23+(i-row*3)*40+4 };
		}

		static DInt InventoryGetPosBoxWooden(int i) {
			int row=i/12;
			return new DInt{ X=Global.WindowWidthHalf-300+59+row*40+4, Y=Global.WindowHeightHalf+59+(i-row*12)*40+4 };
		}

		static DInt InventoryGetPosShelf(int i) {
			int row=i/3;
			return new DInt{X=Global.WindowWidthHalf-300+38+(i-row*3)*40+4, Y=Global.WindowHeightHalf+20-2+25+row*40+4 };
		}

		static DInt InventoryGetPosBarrel(int i) {
			if (i==0) return new DInt{ X=Global.WindowWidthHalf-300+119+4, Y=Global.WindowHeightHalf-198+250+4    };
			else      return new DInt{ X=Global.WindowWidthHalf-300+119+4, Y=Global.WindowHeightHalf-198+250+64+4 };
		}

		static Vector2 InventoryGetPosBarrelVector2(int i) {
			if (i==0) return new Vector2{ X=Global.WindowWidthHalf-300+119+4, Y=Global.WindowHeightHalf-198+250+4    };
			else      return new Vector2{ X=Global.WindowWidthHalf-300+119+4, Y=Global.WindowHeightHalf-198+250+64+4 };
		}

		DInt InventoryGetPosNormal(int ix) {
			if (ix<5) return InventoryGetPosNormal5(ix);
			return InventoryGetPosNormalInv(ix);
		}

		Vector2 InventoryGetPosNormalVector2(int ix) {
			if (ix<5) return InventoryGetPosNormal5Vector2(ix);
			return InventoryGetPosNormalInvVector2(ix);
		}
		#endregion

		void ShowPopUpWindow() => textChooseItemWindow=new Text(Lang.Texts[160], Global.WindowWidthHalf-150-2+10, Global.WindowHeightHalf-134+10,BitmapFont.bitmapFont18);

		void DrawChooseItemWindow() {
			spriteBatch.Draw(pixel, new Rectangle(0,0, Global.WindowWidth, Global.WindowHeight), color_r0_g0_b0_a100);

			DrawFrame(Global.WindowWidthHalf-150-2, Global.WindowHeightHalf-134,304,234+2,1, color_r0_g0_b0_a100);
			DrawFrame(Global.WindowWidthHalf-150-1, Global.WindowHeightHalf-133,302,234,1, color_r0_g0_b0_a200);
			spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-132,300,34), color_r10_g140_b255);
			spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-100+2,300,200-2), ColorLightBlue);

			buttonClosePopUp.Position=new Vector2(Global.WindowWidthHalf+150-32,Global.WindowHeightHalf-132+1);
			buttonClosePopUp.ButtonDraw(/*spriteBatch,newMouseState.X,newMouseState.Y,Global.WindowWidthHalf+150-32,Global.WindowHeightHalf-132+1,mouseLeftDown*/);

			textChooseItemWindow.Draw(spriteBatch);

			CraftingIn[] slots=CurrentDeskCrafting[SelectedCraftingRecipe].Input;
			ItemNonInv[] items=slots[PopUpWindowChoosingPotencialdItem].ItemSlot;
			int i=0;

			for (int y=0; y<4; y++) {
				for (int x=0; x<7; x++) {

					if (items.Length==i) break;
					bool hasItem=HasItem();

					bool HasItem() {
						switch (items[i]) {
							case ItemNonInvBasic t: return TotalItemsInInventoryForAllTypes(items[i].Id)>=t.Count;
							case ItemNonInvTool t: return TotalItemsInInventoryForAllTypes(items[i].Id)>=t.Count;
							case ItemNonInvFood t: return TotalItemsInInventoryForAllTypes(items[i].Id)>=t.Count;
							//case ItemNonInvNonStackable t: return TotalItemsInInventoryForAllTypes(items[i].Id)>=1;
							//case ItemNonInvBasicColoritzedNonStackable t: return TotalItemsInInventoryForAllTypes(items[i].Id)>=1;
							default:return TotalItemsInInventoryForAllTypes(items[i].Id)>=1;
						}
						//return false;
					}

					if (In40(Global.WindowWidthHalf-150+10+x*40, Global.WindowHeightHalf-100+y*40+20)) {
						if (mouseLeftDown) {
							displayPopUpWindow=false;
							PopUpWindowSelectedItem=i;
							CraftingIn slot=slots[PopUpWindowChoosingPotencialdItem];
							slot.SelectedItem=slot.TmpSelected=i;
							slot.Texture=ItemIdToTexture(items[i].Id);
							slot.HaveItemInInventory=hasItem;
							return;
						}
						if (hasItem) spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-150+10+x*40, Global.WindowHeightHalf-100+y*40+20), Color.DarkGray);
						else spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-150+10+x*40, Global.WindowHeightHalf-100+y*40+20), Color.Red);
					} else {
						if (hasItem) spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-150+10+x*40, Global.WindowHeightHalf-100+y*40+20), ColorWhite);
						else spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-150+10+x*40, Global.WindowHeightHalf-100+y*40+20), new Color(255,150,150));
					}

					/*GameDraw.DrawItemInInventory*/DrawItem(/*ItemIdToTexture(items[i].Id),*/ items[i], Global.WindowWidthHalf-150+10+x*40+4, Global.WindowHeightHalf-100+y*40+20+4);

					i++;
				}
			}

		}

		static bool In40(int x, int y) {
			if (mouseRealPosY < y)      return false;
			if (mouseRealPosX < x)      return false;
			if (mouseRealPosX > x + 39) return false;
			if (mouseRealPosY > y + 39) return false;
			return true;
		}

		static bool In(int x, int y, int x2, int y2) {
			if (mouseRealPosY < y)  return false;
			if (mouseRealPosX < x)  return false;
			if (mouseRealPosX > x2) return false;
			if (mouseRealPosY > y2) return false;
			return true;
		}

		void SetCaptionInventory() {
			if (Constants.AnimationsControls) animationInvBack=0;
			else animationInvBack=100;
			inventoryScrollbarValueCrafting=0;

			switch (inventory) {
				case InventoryType.Normal:
					textOpenInventory=null;
					return;

				case InventoryType.BoxWooden:
					textOpenInventory=new Text(Lang.Texts[172], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.Barrel:
					textOpenInventory=new Text(Lang.Texts[1433], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.SewingMachine:
					textOpenInventory=new Text(Lang.Texts[168], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.Charger:
					textOpenInventory=new Text(Lang.Texts[176],Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.Creative:
					textOpenInventory=new Text(Lang.Texts[183],Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.Desk:
					textOpenInventory=new Text(Lang.Texts[158],Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.FurnaceStone:
					textOpenInventory=new Text(Lang.Texts[170],Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.FurnaceElectric:
					textOpenInventory=new Text(Lang.Texts[159], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.Macerator:
					textOpenInventory=new Text(Lang.Texts[169], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.BasicInv:
					textOpenInventory=new Text(Lang.Texts[157], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.Rocket:
					textOpenInventory=new Text(Lang.Texts[175], Global.WindowWidthHalf-150-2+12, Global.WindowHeightHalf-225-3, BitmapFont.bitmapFont18);
					return;

				case InventoryType.Miner:
					textOpenInventory=new Text(Lang.Texts[177], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.Shelf:
					textOpenInventory=new Text(Lang.Texts[180] , Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.Mobile:
					textOpenInventory=new Text(Lang.Texts[174], Global.WindowWidthHalf-150-2+12, Global.WindowHeightHalf-225-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.Radio:
					textOpenInventory=new Text(Lang.Texts[178], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.Composter:
					textOpenInventory=new Text(Lang.Texts[181], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.BoxAdv:
					textOpenInventory=new Text(Lang.Texts[173], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;

				case InventoryType.OxygenMachine:
					textOpenInventory=new Text(Lang.Texts[298], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;
					
				case InventoryType.GameMenu:
					textOpenInventory=new Text(Lang.Texts[114], Global.WindowWidthHalf-300-2+10, Global.WindowHeightHalf-234+10-3,BitmapFont.bitmapFont18);
					return;
			}
		}

		void DrawCreative() {
			creativeScrollbar.ButtonDraw(/*mouseRealPosX,mouseRealPosY,mouseLeftDown,*/Global.WindowWidthHalf-300+4+60+4-16+13*40+3, Global.WindowHeightHalf-200+2+4+4+243);
		   // int z;
			int i=((int)(creativeScrollbar.scale*(inventoryScrollbarValueCraftingMax-13*3))/13)*13;
		 //  z=i;
			for (int y=0; y<4*40; y+=40) {
				for (int x=0; x<13*40; x+=40) {
					if (inventoryScrollbarValueCraftingMax<=i)return;
					if (In40(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243)) {
						if (mouseLeftDown) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243), Color.LightGray);
						else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243), ColorSmokeWhite);
					} else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243), ColorWhite);

				   // if (!invMove || (invMove && invStartInventory[invStartId]!=InventoryCreative[i])) {
					   InventoryCreative[i].Draw();
				   // }
					i++;
				}
			}
		}

		void CreativeGetItems() {
			creativeScrollbar.maxheight=(inventoryScrollbarValueCraftingMax/13+1)*40;
			creativeScrollbar.height=4*40;

			if (mouseLeftRelease) {
			   // int max=((inventoryScrollbarValueCraftingMax+1)/13)*40;

				int i=((int)(creativeScrollbar.scale*(inventoryScrollbarValueCraftingMax-13*3))/13)*13;

				for (int y=0; y<4*40; y+=40) {
					for (int x=0; x<13*40; x+=40) {
						if (inventoryScrollbarValueCraftingMax<i)return;
						if (In40(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243)) {
							AddItemToPlayer(InventoryCreative[i].ToNon());
							return;
						}
						i++;
					}
				}
			}
		}

		void UpdateLiquid(ushort id) {
			int blocks=((int)(Global.WindowWidthHalf*1.25f))/16;
			int max=(int)PlayerX/16+2*blocks;
			if (max>=TerrainLength)max=TerrainLength;
			int start=(int)PlayerX/16-blocks;
			if (start<0)start=0;

			for (int ix=start; ix<max; ix++) {
				Terrain chunk=terrain[ix];

				for (int iy=chunk.StartSomething; iy<100; iy++) {
					if (chunk.IsTopBlocks[iy]) {
						if (chunk.TopBlocks[iy].Id==id) {

							// Nastav zda se jedná o vlnu
							if (iy!=0) {
								if (chunk.IsTopBlocks[iy-1]) {
									if (chunk.TopBlocks[iy-1].Id==id) {

										if (rain) {
											Water w=(Water)chunk.TopBlocks[iy];
											if (w.GetMass<255) {
												if (random.Bool_1Percent())w.Mass(w.GetMass+1);
											}
										}
									}
								}
							}

						   // padat dolů
							if (!chunk.IsSolidBlocks[iy+1]) {
								if (chunk.IsTopBlocks[iy+1]) {

									// Pokud zde něco je rozbij to
									if (chunk.TopBlocks[iy+1].Id!=id) {
										GetItemsFromBlock(chunk.TopBlocks[iy+1].Id,ix,iy+1);
										/*((AirSolidBlock)chunk.SolidBlocks[iy+1]).Top=*/chunk.TopBlocks[iy+1]=new Water(waterTexture,id,new Vector2(ix*16,iy*16+16));
									}

									// Voda padá na vodu
									Water down = (Water)chunk.TopBlocks[iy+1];

									if (down.GetMass<255) {
										Water current = (Water)chunk.TopBlocks[iy];

										int totalMass=current.GetMass+down.GetMass;

										if (totalMass>255) {
											current.Mass(totalMass-255);
											down.Fill=true;
											down.Mass(255);
										} else {
											down.Mass(totalMass);
											down.Fill=true;//?????
											chunk.IsTopBlocks[iy]=false;
											/*((AirSolidBlock)chunk.SolidBlocks[iy]).Top=*/chunk.TopBlocks[iy]=null;
											continue;
										}
									}
								} else {

									// Voda padá na prázdné místo
									Water w=new Water(waterTexture,id,new Vector2(ix*16,iy*16+16),((Water)chunk.TopBlocks[iy]).GetMass);
									//if (chunk.IsBackground[iy+1]) ((AirSolidBlock)chunk.SolidBlocks[iy+1]).Top=w;
									//else chunk.SolidBlocks[iy+1]=new AirSolidBlock{ Top=w };
									chunk.TopBlocks[iy+1]=w;
									chunk.IsTopBlocks[iy+1]=true;

								  //  if (chunk.IsBackground[iy]) {
									  //  ((AirSolidBlock)chunk.SolidBlocks[iy]).Top=null;
										chunk.Background[iy]=null;
								  //  } else {
									 //   chunk.SolidBlocks[iy]=null;
									//    chunk.Background[iy]=null;
								   // }

									chunk.IsTopBlocks[iy]=false;
									continue;
								}
							}

							bool left=false, right=false;

							Terrain leftChunk=null, rightChunk=null;
							if (ix>0){ 
								leftChunk=terrain[ix-1]; 

								if (leftChunk.IsTopBlocks[iy]) {
									if (leftChunk.TopBlocks[iy].Id==id) left=true;
								}

								if (!left) {
									if (!leftChunk.IsSolidBlocks[iy]) {
										Water w=new Water(waterTexture, id, new Vector2(ix*16-16, iy*16));
									  //  if (leftChunk.IsBackground[iy]) ((AirSolidBlock)leftChunk.SolidBlocks[iy]).Top=w;
									   // else leftChunk.SolidBlocks[iy]=new AirSolidBlock{ Top=w };

										leftChunk.TopBlocks[iy]=w;

										if (leftChunk.StartSomething>iy)leftChunk.StartSomething=/*(byte)*/iy;
										leftChunk.IsTopBlocks[iy]=true;
										left=true;
									}
								}
							}

							if (ix<TerrainLength-1) { 
								rightChunk=terrain[ix+1];

								if (rightChunk.IsTopBlocks[iy]) {
									if (rightChunk.TopBlocks[iy].Id==id) right=true;
								}

								if (!right) {
									if (!rightChunk.IsSolidBlocks[iy]) {
										Water w=new Water(waterTexture, id, new Vector2(ix*16+16, iy*16));
									 //   if (rightChunk.IsBackground[iy]) ((AirSolidBlock)rightChunk.SolidBlocks[iy]).Top=w;
									  //  else rightChunk.SolidBlocks[iy]=new AirSolidBlock{ Top=w };

										rightChunk.TopBlocks[iy]=w;

										if (rightChunk.StartSomething>iy)rightChunk.StartSomething=/*(byte)*/iy;
										rightChunk.IsTopBlocks[iy]=true;
										right=true;
									}
								}
							}

							//if (((Water)chunk.TopBlocks[iy]).mass==0) {
							//    if (!left && !right) continue;
							//}

							// Podud na stranách nic není, vytvoř tam vodu, jestliže bude zbytečná, pak se zničí


							// On both sides
							if (left && right) {
								bool waterUp=false, waterLUp=false, waterRUp=false;

								if (chunk.IsTopBlocks[iy-1]) waterUp=chunk.TopBlocks[iy-1].Id==id;
								if (rightChunk.IsTopBlocks[iy-1]) waterRUp=rightChunk.TopBlocks[iy-1].Id==id;
								if (leftChunk.IsTopBlocks[iy-1]) waterLUp=leftChunk.TopBlocks[iy-1].Id==id;

								Water waterL=(Water)leftChunk.TopBlocks[iy],
									water=(Water)chunk.TopBlocks[iy],
									waterR=(Water)rightChunk.TopBlocks[iy];

								int massL=waterL.GetMass,
									mass=water.GetMass,
									massR=waterR.GetMass;

								if (massL!=mass || massR!=mass) {
									int totalMass=massL+mass+massR;
									if (totalMass==255*3) continue;

									if (totalMass==1) {
										if (random.Bool()) {
											leftChunk.IsTopBlocks[iy]=false;
											/*((AirSolidBlock)leftChunk.SolidBlocks[iy]).Top=*/leftChunk.TopBlocks[iy]=null;
										   // waterR.Fill=false;
											waterR.MassNoFill(1);
										} else {
										   // waterL.Fill=false;
											waterL.MassNoFill(1);

											rightChunk.IsTopBlocks[iy]=false;
											/*((AirSolidBlock)rightChunk.SolidBlocks[iy]).Top=*/rightChunk.TopBlocks[iy]=null;
										}

										chunk.IsTopBlocks[iy]=false;
										/*((AirSolidBlock)chunk.SolidBlocks[iy]).Top=*/chunk.TopBlocks[iy]=null;


									} else if (totalMass==2) {
									   // waterL.Fill=false;
										waterL.MassNoFill(1);

									   // waterR.Fill=false;
										waterR.MassNoFill(1);

										chunk.IsTopBlocks[iy]=false;
										/*((AirSolidBlock)chunk.SolidBlocks[iy]).Top=*/chunk.TopBlocks[iy]=null;

									} else {
										int rMass=totalMass/3;
										int d=totalMass-3*rMass;

										if (d==0) {
											waterL.Mass(rMass);
											waterR.Mass(rMass);
											water.Mass(rMass);

											water.Fill=waterUp;
											waterL.Fill=waterLUp;
											waterR.Fill=waterRUp;
										} else if (d==1) {
											waterL.Mass(rMass);
											waterR.Mass(rMass);
											water.Mass(rMass+1);

											water.Fill=waterUp;
											waterL.Fill=waterLUp;
											waterR.Fill=waterRUp;
										} else if (d==2) {
											waterL.Mass(rMass+1);
											waterR.Mass(rMass+1);
											water.Mass(rMass);

											water.Fill=waterUp;
											waterL.Fill=waterLUp;
											waterR.Fill=waterRUp;
										}
									}
								}

							// Jen vlevo
							} else if (left && !right) {
								bool waterUp=false, waterLUp=false;

								if (chunk.IsTopBlocks[iy-1]) waterUp=chunk.TopBlocks[iy-1].Id==id;
								if (leftChunk.IsTopBlocks[iy-1]) waterLUp=leftChunk.TopBlocks[iy-1].Id==id;

								Water waterL=(Water)leftChunk.TopBlocks[iy],
									water=(Water)chunk.TopBlocks[iy];

								int massL=waterL.GetMass,
									mass=water.GetMass;

								if (massL!=mass) {
									int totalMass=massL+mass;
									if (totalMass==0) {

									} else if (totalMass==1) {
										if (random.Bool()) {
										   // waterL.Fill=false;
											waterL.MassNoFill(1);
											chunk.IsTopBlocks[iy]=false;
											/*((AirSolidBlock)chunk.SolidBlocks[iy]).Top=*/chunk.TopBlocks[iy]=null;
										}else{
											leftChunk.IsTopBlocks[iy]=false;
											/*((AirSolidBlock)leftChunk.SolidBlocks[iy]).Top=*/leftChunk.TopBlocks[iy]=null;
											water.MassNoFill(1);
										}
									} else {
										int halfMass=totalMass/2;
										waterL.Mass(halfMass);
										water.Mass(totalMass-halfMass);

										waterL.Fill=waterLUp;
										water.Fill=waterUp;
									}
								}

							// Jen vpravo
							} else if (!left && right) {
								Water water=(Water)chunk.TopBlocks[iy],
									waterR=(Water)rightChunk.TopBlocks[iy];

								bool waterUp=false, waterRUp=false;

								if (chunk.IsTopBlocks[iy-1]) waterUp=chunk.TopBlocks[iy-1].Id==id;
								if (rightChunk.IsTopBlocks[iy-1]) waterRUp=rightChunk.TopBlocks[iy-1].Id==id;

								int massR = waterR.GetMass,
									mass= water.GetMass;

								if (massR!=mass) {
									int totalMass=massR+mass;
									if (totalMass==0) {

									} else if (totalMass==1) {
										if (random.Bool()) {
											waterR.MassNoFill(1);
											chunk.IsTopBlocks[iy]=false;
											/*((AirSolidBlock)chunk.SolidBlocks[iy]).Top=*/chunk.TopBlocks[iy]=null;
										} else {
											rightChunk.IsTopBlocks[iy]=false;
											/*((AirSolidBlock)rightChunk.SolidBlocks[iy]).Top=*/rightChunk.TopBlocks[iy]=null;
											water.MassNoFill(1);
										}
									} else {
										int rMass=totalMass/2;
										waterR.Mass(rMass);
										water.Mass(totalMass-rMass);

										waterR.Fill=waterRUp;
										water.Fill=waterUp;
									}
								}
							}
						}
					}
				}
			}
		}

		static bool IsEaster() {
			DateTime now=DateTime.Now;//new DateTime(2020,3,12+3,1,1,1);

			DateTime easter = EasterTime();
			int dayDelta=(now-easter).Days;

			return dayDelta>=0 && dayDelta<7;

			DateTime EasterTime() {
				int year=now.Year;

				int goldenNumber = year % 19;
				//int constant = year % 4;
				//int dayInWeek = year % 7;
				int k = year / 100;
				int p = (13 + 8 * k) / 25;
				int leapYear = k / 4;
				int M = (15 - p + k - leapYear) % 30;
				//int sunRepair = (4 + k - leapYear) % 7;
				int d = (19 * goldenNumber + M) % 30;
				int e = (2 * (year % 4) + 4 * (year % 7) + 6 * d + ((4 + k - leapYear) % 7)) % 7;
				if ((d + e + 22) < 32) return new DateTime(year,3,d + e + 22);
				if (d == 29 && e == 6) return new DateTime(year,4,19);
				if (d == 28 && e == 6 && goldenNumber > 10) {
					return new DateTime(year,3,18);
				}
				return new DateTime(year,3,d + e - 9);
			}
		}

		void CreateShot() {
			SoundEffects.Shot.Play();
			GunShots.Add(new GunShot{
				Angle=(float)Math.Atan2(mousePos.Y-PlayerY, mousePos.X-PlayerX),
				X=PlayerX,
				Y=PlayerY
			});
		}

		void SetItemCreative(ItemInv[] inv, int i, ushort id) {
			if (GameMethods.IsItemInvBasic16(id)) {
				inv[i]=new ItemInvBasic16(ItemIdToTexture(id), id, 99, 0, 0);
				return;
			}

			if (GameMethods.IsItemInvBasic32(id)) {
				inv[i]=new ItemInvBasic32(ItemIdToTexture(id), id, 99, 0, 0);
				return;
			}

			if (GameMethods.IsItemInvTool32(id)) {
				int max=GameMethods.ToolMax(id);
				inv[i]=new ItemInvTool32(ItemIdToTexture(id), id, max, max, 0, 0);
				return;
			}

			if (GameMethods.IsItemInvFood16(id)) {
				int max=GameMethods.FoodMaxCount(id);
				float des=GameMethods.FoodMaxDescay(id);
				inv[i]=new ItemInvFood16(ItemIdToTexture(id), id, max, max, des, des, 0, 0);
				return;
			}

			if (GameMethods.IsItemInvFood32(id)) {
				int max=GameMethods.FoodMaxCount(id);
				float des=GameMethods.FoodMaxDescay(id);
				inv[i]=new ItemInvFood32(ItemIdToTexture(id), id, max, max, des, des, 0, 0);
				return;
			}

			if (GameMethods.IsItemInvBasicColoritzed32NonStackable(id)) {
				inv[i]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(id), id, ColorWhite, 0, 0);
				return;
			}
			if (GameMethods.IsItemInvNonStackable32(id)) {
				inv[i]=new ItemInvNonStackable32(ItemIdToTexture(id), id, 0, 0);
				return;
			}

			if (GameMethods.IsItemInvTool16(id)) {
				int max=GameMethods.ToolMax(id);
				inv[i]=new ItemInvTool16(ItemIdToTexture(id), id, max, max/*, 0, 0*/);
				return;
			}

			#if DEBUG
			throw new Exception("Missing item or caterory (Item: "+(Items)id+")");
			#endif
		}

		void SetItemCrafting(ItemInv[] inv, int i, ushort id) {
			if (GameMethods.IsItemInvBasic16(id)) {
				inv[i]=new ItemInvBasic16(ItemIdToTexture(id), id, 1/*, 0, 0*/);
				return;
			}

			if (GameMethods.IsItemInvBasic32(id)) {
				inv[i]=new ItemInvBasic32(ItemIdToTexture(id), id, 1/*, 0, 0*/);
				return;
			}

			if (GameMethods.IsItemInvTool32(id)) {
				inv[i]=new ItemInvTool32(ItemIdToTexture(id), id/*, 0, 0*/);
				return;
			}

			if (GameMethods.IsItemInvFood16(id)) {
				inv[i]=new ItemInvFood16(ItemIdToTexture(id), id, 1, 0/*, 0, 0*/);
				return;
			}

			if (GameMethods.IsItemInvFood32(id)) {
				inv[i]=new ItemInvFood32(ItemIdToTexture(id), id, 1, 0/*, 0, 0*/);
				return;
			}

			if (GameMethods.IsItemInvBasicColoritzed32NonStackable(id)) {
				inv[i]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(id), id, ColorWhite/*, 0, 0*/);
				return;
			}
			if (GameMethods.IsItemInvNonStackable32(id)) {
				inv[i]=new ItemInvNonStackable32(ItemIdToTexture(id), id/*, 0, 0*/);
				return;
			}

			if (GameMethods.IsItemInvTool16(id)) {
				inv[i]=new ItemInvTool16(ItemIdToTexture(id), id/*, max, max*//*, 0, 0*/);
				return;
			}

			#if DEBUG
			throw new Exception("Missing item or caterory (Item: "+(Items)id+")");
			#endif
		}

		void AddItemToPlayer(ItemNonInv it) {
			ItemNonInv remain=InventoryAdd(it);
			if (remain!=null) ItemDrop(remain,(int)PlayerX,(int)PlayerY);
		}

		void SaveInventory(string name, ItemInv[] inv) {
			List<byte> bytes=new List<byte>();
			foreach (ItemInv x in inv) x.SaveBytes(bytes);
			File.WriteAllBytes(pathToWorld+@"\"+name+".bin", bytes.ToArray());
		}

		void ReSetCraftingInventoryPositions() {
			int xx = 0, yh = 0;

			if (Global.WorldDifficulty==2) {
				if (inventory==InventoryType.Creative) yh+=35;
			}

			for (int i=inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
				if (i>inventoryScrollbarValueCraftingMax) return;

				InventoryCrafting[i].SetPos(Global.WindowWidthHalf-300+4+40+xx+4+4, Global.WindowHeightHalf-200+2+4+200+8+yh+4+8);

				xx+=40;

				if (xx==6*40) {
					xx=0;
					yh+=40;
				}
			}
		}

		int GetCraftingInventoryId() {
			int xx = 0, yh = 0;

			if (Global.WorldDifficulty==2) {
				if (inventory==InventoryType.Creative) yh+=35;
			}

			for (int i=inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
				if (i>inventoryScrollbarValueCraftingMax) return -1;
				if (In40(Global.WindowWidthHalf-300+4+40+xx+4+4, Global.WindowHeightHalf-200+2+4+200+8+yh+4+8)) return i;

				xx+=40;

				if (xx==6*40) {
					xx=0;
					yh+=40;
				}
			}
			return -1;
		}

		void ReSetInventoryCreativePositions() {

			int i=((int)(creativeScrollbar.scale*(inventoryScrollbarValueCraftingMax-13*3))/13)*13;

			for (int y=0; y<4*40; y+=40) {
				for (int x=0; x<13*40; x+=40) {
					if (inventoryScrollbarValueCraftingMax<=i)return;
					//if (In40(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243)) {
					//    if (mouseLeftDown) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243), Color.LightGray);
					//    else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243), ColorSmokeWhite);
					//} else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243), ColorWhite);

				   // if (!invMove || (invMove && invStartInventory[invStartId]!=InventoryCreative[i])) {
						InventoryCreative[i].SetPos(Global.WindowWidthHalf-300+4+60+x+4-16+4, Global.WindowHeightHalf-200+2+4+y+4+243+4);
				   // }
					i++;
				}
			}
		}

		int GetInventoryIdCreative() {
			int i=((int)(creativeScrollbar.scale*(inventoryScrollbarValueCraftingMax-13*3))/13)*13;

			for (int y=0; y<4*40; y+=40) {
				for (int x=0; x<13*40; x+=40) {
					if (inventoryScrollbarValueCraftingMax<=i) return -1;
					if (In40(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243)) return i;
					i++;
				}
			}
			return -1;
		}

		void DrawItemMouse() {
			if (mouseDrawItemTextInfo) {
				int cursorWidth = 15;

				if (mouseRealPosX+cursorWidth+mouseItemNameWidth<Global.WindowWidth) {
					Rabcr.spriteBatch.Draw(pixel, new Rectangle(mouseRealPosX+cursorWidth, mouseRealPosY,mouseItemNameWidth,30), ColorWhite);
					itemText.ChangePosition(mouseRealPosX+cursorWidth, mouseRealPosY);
				} else {
					Rabcr.spriteBatch.Draw(pixel, new Rectangle(mouseRealPosX-cursorWidth-mouseItemNameWidth, mouseRealPosY,mouseItemNameWidth,30), ColorWhite);
					itemText.ChangePosition(mouseRealPosX-cursorWidth-mouseItemNameWidth, mouseRealPosY);
				}
				itemText.Draw(spriteBatch);
			}
		}

		void MouseItemNameEvent(ushort newId) {
			if (newId!=0)mouseDrawItemTextInfo=true;
			if (mouseItemId!=newId) {
				if (newId==0) {
					mouseItemId=newId;
					mouseDrawItemTextInfo=false;
					return;
				}

				int langid=GameMethods.GetItemNameId(newId);

				if (langid==-1) {
					#if DEBUG
					mouseDrawItemTextInfo=true;
					mouseItemId=newId;
					mouseItemName=Lang.Texts[999];
				   // mouseItemNameWidth=(int)spriteFont_small.MeasureString(mouseItemName).X;

					itemText=new Text(mouseItemName,0,0,BitmapFont.bitmapFont18);
					mouseItemNameWidth=(int)itemText.MeasureX();
					#else
					mouseDrawItemTextInfo=false;
					#endif
				}else{
					mouseDrawItemTextInfo=true;
					mouseItemId=newId;
					mouseItemName=Lang.Texts[langid];
				   // mouseItemNameWidth=(int)spriteFont_small.MeasureString(mouseItemName).X;

					itemText=new Text(mouseItemName,0,0,BitmapFont.bitmapFont18);
					mouseItemNameWidth=(int)itemText.MeasureX();
				}
			}
		}

		float DetectSolidBlocksLeft(float npx, float npy) {
			int to=((int)npy+20)/16;

			// Upper terrain
			if (to<3) return int.MinValue;

			// Near up terrain
			if (to<0) to=0;

			// Under terrain
			if (to>124+3)return int.MinValue;

			// Bottom terrain
			if (to>124)to=124;

			float chunkX=npx-11;
			int chunkX16=((int)chunkX)/16;
			Terrain chunk=terrain[chunkX16];

			for (int y=((int)npy-20-1)/16; y<to; y++) {
				if (chunk.IsSolidBlocks[y]) return chunkX16*16-chunkX;
			}

			return int.MinValue;
		}

		float DetectSolidBlocksRight(float npx, float npy) {
			int start=((int)npy-20-1)/16;
			if (start<0)start=0;

			int to=((int)npy+20)/16;

			// Upper terrain
			if (to<-3) return int.MinValue;

			// Near up terrain
			if (to<0) to=0;

			// Under terrain
			if (to>124+3)return int.MinValue;

			// Bottom terrain
			if (to>124)to=124;

			float chunkX=npx+11;
			int chunkX16=((int)Math.Ceiling(chunkX))/16;
			Terrain chunk=terrain[chunkX16];

			for (int y=start; y<to; y++) {
				if (chunk.IsSolidBlocks[y]) return chunkX-chunkX16*16;
			}

			return int.MinValue;
		}

		//void UpdateFallingBlocks() {
		//    for (int i=0; i<fallingBlocks.Count;) {
		//        FallingBlockInfo d = fallingBlocks[i];
		//        NormalBlock block=d.block;

		//        // Only down
		//        block.Position.Y++;
		//        if (d.side) {
		//            if (block.Position.X<d.to16.X) block.Position.X++;
		//            else block.Position.X--;
		//        }

		//        if (block.Position.Y==d.to16.X) {
		//            fallingBlocks.RemoveAt(i);
		//        } else i++;

		//    }
		//}

		//void CheckBlocksAfterRemove(int x, int y) {
		//    if (y>0) {
		//        if (terrain[x].IsSolidBlocks[y-1]) {
		//            Block b =terrain[x].SolidBlocks[y-1];
		//            if (b is NormalBlock n) {
		//                terrain[x].SolidBlocks[y]=n;
		//                terrain[x].SolidBlocks[y-1]=null;

		//                fallingBlocks.Add(new FallingBlockInfo {
		//                    block=n,
		//                    to=new DInt{X=x, Y=y-1 },
		//                    to16=new DInt{X=x*16, Y=(y-1)*16 }
		//                });
		//                return;
		//            }
		//        }

		//        if (random.Bool()) {
		//            if (terrain[x-1].IsSolidBlocks[y-1]) {
		//                Block b =terrain[x-1].SolidBlocks[y-1];
		//                if (b is NormalBlock n) {
		//                    terrain[x].SolidBlocks[y]=n;
		//                    terrain[x-1].SolidBlocks[y-1]=null;

		//                    fallingBlocks.Add(new FallingBlockInfo {
		//                        block=n,
		//                        to=new DInt{X=x, Y=y-1 },
		//                        to16=new DInt{X=(x-1)*16, Y=(y-1)*16 }
		//                    });
		//                    return;
		//                }
		//            }

		//            if (terrain[x+1].IsSolidBlocks[y-1]) {
		//                Block b =terrain[x+1].SolidBlocks[y-1];
		//                if (b is NormalBlock n) {
		//                    terrain[x].SolidBlocks[y]=n;
		//                    terrain[x+1].SolidBlocks[y-1]=null;

		//                    fallingBlocks.Add(new FallingBlockInfo {
		//                        block=n,
		//                        to=new DInt{X=x, Y=y-1 },
		//                        to16=new DInt{X=(x+1)*16, Y=(y-1)*16 }
		//                    });
		//                    return;
		//                }
		//            }
		//        }else{
		//            if (terrain[x+1].IsSolidBlocks[y-1]) {
		//                Block b =terrain[x+1].SolidBlocks[y-1];
		//                if (b is NormalBlock n) {
		//                    terrain[x].SolidBlocks[y]=n;
		//                    terrain[x+1].SolidBlocks[y-1]=null;

		//                    fallingBlocks.Add(new FallingBlockInfo {
		//                        block=n,
		//                        to=new DInt{X=x, Y=y-1 },
		//                        to16=new DInt{X=(x+1)*16, Y=(y-1)*16 }
		//                    });
		//                    return;
		//                }
		//            }

		//            if (terrain[x-1].IsSolidBlocks[y-1]) {
		//                Block b =terrain[x-1].SolidBlocks[y-1];
		//                if (b is NormalBlock n) {
		//                    terrain[x].SolidBlocks[y]=n;
		//                    terrain[x-1].SolidBlocks[y-1]=null;

		//                    fallingBlocks.Add(new FallingBlockInfo {
		//                        block=n,
		//                        to=new DInt{X=x, Y=y-1 },
		//                        to16=new DInt{X=(x-1)*16, Y=(y-1)*16 }
		//                    });
		//                    return;
		//                }
		//            }
		//        }
		//    }
		//}

		static bool IsSameArray(ItemInv[] a1, ItemInv[] a2) {
			if (a1==a2) return true;
			if (a1.Length!=a2.Length) return false;

			int a1Len=a1.Length;
			for (int i=0; i<a1Len; i++) {
				if (a1[i]!=a2[i]) return false;
			}
			return true;
		}

		void InventoryBarrelInSlotEvent(){
			Barrel barrel=(Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y];
			if (barrel.Inv[0].Id!=0)  AddToBarrel(barrel);
			if (barrel.Inv[1].Id!=0)  RemoveFromBarrel(barrel);
		}

		bool AddToBarrel(Barrel barrel){
			ItemInv item=barrel.Inv[0];
			(byte, int, ushort) convert=GameMethods.ItemsIdToLiquid(item.Id);

			if (convert.Item1!=(byte)LiquidId.None) {
				if (barrel.LiquidId==convert.Item1 || barrel.LiquidId==0) {
					if (barrel.LiquidAmount<Barrel.LiquidAmountMax) {
						if (GameMethods.HasLiquid(barrel.Inv[0].Id)) {
							switch (barrel.Inv[0]) {
								case ItemInvBasic16 i:
									if (i.GetCount==1){
										barrel.Inv[0]=itemBlank;
									} else {
										i.RemoveOne();
									}
									barrel.LiquidId=convert.Item1;
									barrel.LiquidAmount+=convert.Item2;
									if (barrel.LiquidAmount>Barrel.LiquidAmountMax) barrel.LiquidAmount=Barrel.LiquidAmountMax;
									break;

								//case ItemInvBasicColoritzed32NonStackable i:
								//    if (barrel.Inv[1].Id==0) {
								//        if (barrel.LiquidAmount>=50){
								//            Color c=GameMethods.DyeToColor(barrel.LiquidId);
								//            if (c!=Color.Transparent) {
								//                i.color=c;
								//                barrel.Inv[1]=i;
								//                barrel.Inv[0]=itemBlank;
								//                barrel.LiquidAmount-=50;
								//                if (barrel.LiquidAmount==0) barrel.LiquidId=0;
								//            }
								//        }
								//    }
								//    break;

								case ItemInvBasic32 i:
									if (i.GetCount==1) {
										barrel.Inv[0]=itemBlank;
									} else {
										i.RemoveOne();
									}
									barrel.LiquidId=convert.Item1;
									barrel.LiquidAmount+=convert.Item2;
									if (barrel.LiquidAmount>Barrel.LiquidAmountMax) barrel.LiquidAmount=Barrel.LiquidAmountMax;
									break;

								case ItemInvFood16 i:
									//if (i.GetCount<99){
										i.SetCount=i.GetCount+1;
										barrel.LiquidAmount+=convert.Item2;
										barrel.LiquidId=convert.Item1;
								   // }
									break;

								case ItemInvFood32 i:
								   // if (i.GetCount<99){
										i.SetCount=i.GetCount+1;
										barrel.LiquidAmount+=convert.Item2;
										barrel.LiquidId=convert.Item1;
								   // }
									break;

								case ItemInvTool16 i:
									if (i.GetCount==1) {
										ushort newId=convert.Item3;//GameMethods.ToolToBasic(i.Id);
										if (newId==0) barrel.Inv[0]=itemBlank;
										else SetNewItem(newId);
									} else {
										i.SetCount=i.GetCount-1;
									}
									barrel.LiquidAmount++;
									barrel.LiquidId=convert.Item1;
									if (barrel.LiquidAmount>Barrel.LiquidAmountMax) barrel.LiquidAmount=Barrel.LiquidAmountMax;
									break;

								case ItemInvTool32 i:
									if (i.GetCount==1) {
										ushort newId=convert.Item3;//GameMethods.ToolToBasic(i.Id);
										if (newId==0) barrel.Inv[0]=itemBlank;
										else SetNewItem(newId);
									} else {
										i.SetCount=i.GetCount-1;
									}
									barrel.LiquidAmount++;
									barrel.LiquidId=convert.Item1;
									if (barrel.LiquidAmount>Barrel.LiquidAmountMax) barrel.LiquidAmount=Barrel.LiquidAmountMax;
									break;

								void SetNewItem(ushort newId) {
									if (GameMethods.IsItemInvTool32(newId)) {
										DInt p=InventoryGetPosBarrel(0);
										barrel.Inv[0]=new ItemInvTool32(ItemIdToTexture(newId), newId, 1, p.X, p.Y);
										return;
									}
									if (GameMethods.IsItemInvTool16(newId)) {
										DInt p=InventoryGetPosBarrel(0);
										barrel.Inv[0]=new ItemInvTool16(ItemIdToTexture(newId), newId, 1, p.X, p.Y);
										return;
									}
									if (GameMethods.IsItemInvBasic16(newId)) {
										DInt p=InventoryGetPosBarrel(0);
										barrel.Inv[0]=new ItemInvBasic16(ItemIdToTexture(newId), newId, 1, p.X, p.Y);
										return;
									}
									if (GameMethods.IsItemInvBasic32(newId)) {
										barrel.Inv[0]=new ItemInvBasic32(ItemIdToTexture(newId), newId, 1,InventoryGetPosBarrelVector2(0));
										return;
									}
								}
							}
						}
						return true;

						}
					   // if (barrel.Inv[1].Id==(ushort)Items.None) {
						//    barrel.LiquidAmount+=convert.Item2;
					  //      barrel.Inv[0]=
					   // } else if (barrel.Inv[1].Id==convert.Item3) {
						//    switch (barrel.Inv[0]) {
						//        case ItemInvBasic16 i:
						//            if (i.GetCount<99){

						//                i.SetCount=i.GetCount+1;
						//                barrel.LiquidAmount+=convert.Item2;
						//            }
						//            break;

						//        case ItemInvBasic32 i:
						//            if (i.GetCount<99){
						//                i.SetCount=i.GetCount+1;
						//                barrel.LiquidAmount+=convert.Item2;
						//            }
						//            break;

						//        case ItemInvFood16 i:
						//            if (i.GetCount<99){
						//                i.SetCount=i.GetCount+1;
						//                barrel.LiquidAmount+=convert.Item2;
						//            }
						//            break;

						//        case ItemInvFood32 i:
						//            if (i.GetCount<99){
						//                i.SetCount=i.GetCount+1;
						//                barrel.LiquidAmount+=convert.Item2;
						//            }
						//            break;

						//        case ItemInvTool16 i:
						//            if (i.GetCount<99) {
						//                i.SetCount=i.GetCount+1;
						//                barrel.LiquidAmount+=convert.Item2;
						//            }
						//            break;

						//        case ItemInvTool32 i:
						//            if (i.GetCount<99){
						//                i.SetCount=i.GetCount+1;
						//                barrel.LiquidAmount+=convert.Item2;
						//            }
						//            break;
						//    }
						//}
						//return true;
					//}
				}

				//if (barrel.LiquidId==0) {
				//    if (barrel.Inv[1].Id==(ushort)Items.None) {
				//        ushort id=convert.Item3;
				//        if (GameMethods.IsItemInvBasic16(id)) {
				//            barrel.LiquidAmount=convert.Item2;
				//            barrel.LiquidId=convert.Item1;
				//            barrel.Inv[1]=new ItemInvBasic16(ItemIdToTexture(id), id, 1);
				//            return true;
				//        }
				//        if (GameMethods.IsItemInvBasic32(id)) {
				//            barrel.LiquidAmount=convert.Item2;
				//            barrel.LiquidId=convert.Item1;
				//            barrel.Inv[1]=new ItemInvBasic32(ItemIdToTexture(id), id, 1);
				//            return true;
				//        }
				//        //if (GameMethods.IsItemInvBasicColoritzed32NonStackable(id)) {
				//        //    barrel.LiquidAmount=convert.Item2;
				//        //    barrel.LiquidId=convert.Item1;
				//        //    barrel.Inv[1]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(id), id, 1);
				//        //    return true;
				//        //}
				//    }

				//}
			}

			if (barrel.Inv[1].Id==0) {
				switch (barrel.Inv[0]){
					case ItemInvBasicColoritzed32NonStackable i:
						if (barrel.LiquidAmount>=50) {
							Color c = GameMethods.DyeToColor(barrel.LiquidId);
							if (c!=Color.Transparent) {
								i.color=c;
								i.SetPos(InventoryGetPosBarrelVector2(1));
								barrel.Inv[1]=i;
								barrel.Inv[0]=itemBlank;
								barrel.LiquidAmount-=50;
								if (barrel.LiquidAmount==0) barrel.LiquidId=0;
								return true;
							}
						}
						break;
				}
			}

			return false;
		}

		void RemoveFromBarrel(Barrel barrel){
			ItemInv item=barrel.Inv[1];

			int max=0;
			ushort newId=0;
			bool canBeConvert=GameMethods.ItemsCanBeFill(item.Id, barrel.LiquidId, ref max, ref newId);

			if (canBeConvert) {
				switch (barrel.Inv[1]) {
					case ItemInvBasic16 i:
						if (barrel.LiquidAmount-max+i.GetCount>=0) {
							if (newId==i.Id) {
								if (i.GetCount<99) {
									i.SetCount=i.GetCount+1;
									barrel.LiquidAmount--;
									if (barrel.LiquidAmount<=0) barrel.LiquidId=0;
								}
							} else {
								if (i.GetCount==1) {
									DInt p=InventoryGetPosBarrel(1);
									barrel.Inv[1]=new ItemInvTool16(ItemIdToTexture(newId), newId, 1, p.X, p.Y);
									barrel.LiquidAmount--;
									if (barrel.LiquidAmount<=0) barrel.LiquidId=0;
								}
							}
						}
						break;

					case ItemInvBasic32 i:
						if (GameMethods.IsItemInvBasic32(newId)) { 
							if (barrel.LiquidAmount-max>=0) {
								DInt p=InventoryGetPosBarrel(1);
								barrel.Inv[1]=new ItemInvBasic32(ItemIdToTexture(newId), newId, 1, p.X, p.Y);
								barrel.LiquidAmount-=50;
							}
						} else {
							if (barrel.LiquidAmount-max+i.GetCount>=0) {
								if (newId==i.Id) {
									if (i.GetCount<99) {
										i.SetCount=i.GetCount+1;
										barrel.LiquidAmount--;
										if (barrel.LiquidAmount<=0) barrel.LiquidId=0;
									}
								} else {
									if (i.GetCount==1) {
										DInt p=InventoryGetPosBarrel(1);
										barrel.Inv[1]=new ItemInvTool32(ItemIdToTexture(newId), newId, 1, p.X, p.Y);
										barrel.LiquidAmount--;
										if (barrel.LiquidAmount<=0) barrel.LiquidId=0;
									}
								}
							}
						}
						break;

					case ItemInvTool16 i:
						if (barrel.LiquidAmount-max+i.GetCount>=0) {
							if (i.GetCount<i.Maximum) {
								if (newId==i.Id){
									i.SetCount=i.GetCount+1;
								} else {
									DInt p=InventoryGetPosBarrel(1);
									barrel.Inv[1]=new ItemInvTool16(ItemIdToTexture(newId), newId, 1, p.X, p.Y);
								}
								barrel.LiquidAmount--;
								if (barrel.LiquidAmount<=0) barrel.LiquidId=0;
							}
						}
						break;

					case ItemInvTool32 i:
						if (barrel.LiquidAmount-max+i.GetCount>=0) {
							if (i.GetCount<i.Maximum) {
								if (newId==i.Id){
									i.SetCount=i.GetCount+1;
								} else {
									DInt p=InventoryGetPosBarrel(1);
									barrel.Inv[1]=new ItemInvTool16(ItemIdToTexture(newId), newId, 1, p.X, p.Y);
								}
								barrel.LiquidAmount--;
								if (barrel.LiquidAmount<=0) barrel.LiquidId=0;
							}
						}
						break;
				}
			} else {
				ushort id=barrel.Inv[1].Id;
				if (GameMethods.HasLiquid(id)) {
					switch (barrel.Inv[1]) {
						case ItemInvTool32 i:
							if (i.GetCount < i.Maximum) {
								i.SetCount=i.GetCount+1;
								barrel.LiquidAmount--;
								if (barrel.LiquidAmount<=0) barrel.LiquidId=0;
							}
							return;

						case ItemInvTool16 i:
							if (i.GetCount < i.Maximum) {
								i.SetCount=i.GetCount+1;
								barrel.LiquidAmount--;
								if (barrel.LiquidAmount<=0) barrel.LiquidId=0;
							}
							return;
					}
				}
			}
		}

		void CreateGradientTexture() { 
			TextureSunGradient?.Dispose();

			int height=Global.WindowHeight;

			int start=0;
			Color[] colors=new Color[height];
			Color ColorBef;

			for (int p=1; p<Gradient.Count; p++) { 
				(Color, float) gradientPoint=Gradient[p];
				int end= (int)(gradientPoint.Item2*height);
				
				ColorBef=Gradient[p-1].Item1;

				for (int i=start; i<end; i++) { 
					colors[i]=FastMath.Lerp(ColorBef, gradientPoint.Item1, (i-start)/(float)(end-start));
				}

				start=end;
			}
			TextureSunGradient=new Texture2D(Graphics, 1, height);
			TextureSunGradient.SetData(colors);
		}

		BiomeData GetBiomeByPos(int pos) { 
			int len=Biomes.Length;
			int half=len/2;

			if (Biomes[half].End>pos) {
				for (int i = 0; i<half; i++) {
					if (Biomes[i].End>pos) { 
						return Biomes[i]/*.Name*/;
					}
				}
			} else { 
				for (int i = half; i<len; i++) {
					if (Biomes[i].End>pos) { 
						return Biomes[i]/*.Name*/;
					}
				}
			}

			return new BiomeData();
		}

		Color BiomeColor(Biome biome) { 
			switch (biome) { 
				case Biome.Desert: return Color.Yellow;
				case Biome.Savanna: return new Color(110,85,32);
				case Biome.SaltOcean: return new Color(10,48,96);
				case Biome.Arctic: return Color.White;
				case Biome.Bog: return new Color(111,81,14);
				case Biome.ColdTaiga: return new Color(25,21,3);
				case Biome.Taiga: return new Color(47,59,11);
				case Biome.Tundra: return new Color(188,7,1);
				case Biome.WetTundra: return new Color(20,16,3);
				case Biome.Swamp: return new Color(26,46,12);
				case Biome.TropicalRainforest: return new Color(3,36,2);
				case Biome.Subtropics: return new Color(39,42,14);
				case Biome.ArcticPlains: return new Color(163,169,186);
				case Biome.Beach: return new Color(213,159,109);
				case Biome.BothForest: return new Color(107,146,15);
				case Biome.DryTundra: return new Color(9,8,5);
				case Biome.Fen: return new Color(61,84,21);
				case Biome.HotPlains: return new Color(128,54,8);
				case Biome.HumidSubtropical: return new Color(28,59,13);
				case Biome.LeaveForest: return new Color(11,57,10);
				case Biome.Mangrove: return new Color(60,85,16);
				case Biome.Plains: return new Color(57,59,9);
				case Biome.SpruceForest: return new Color(53,54,13);
				case Biome.Jungle: return new Color(2,61,0);
			}
			//#if DEBUG
			//throw new Exception("Missing biome color");
			//#else
			return Color.Green;
		   // #endif
		}

		void SaveSettings(){ 
			#if DEBUG
			Debug.WriteLine("Saved Settings.txt");
			#endif
			 File.WriteAllText(pathToWorld+@"\Settings.txt",
				Release.VersionString+"\r\n"+
				debug+"\r\n"+
				fly+"\r\n"+
				time+"\r\n"+
			   // dayAlpha+"\r\n"+

				barWater+"\r\n"+
				barEat+"\r\n"+
				barHeart+"\r\n"+
				barOxygen+"\r\n"+

				(int)PlayerX+"\r\n"+
				(int)PlayerY+"\r\n"+

				windForce+"\r\n"+
				wind+"\r\n"+
				rain+"\r\n"+
				windRirectionRight+"\r\n"+
				timeToChageWind+"\r\n"+

				changeRain+"\r\n"+
				day+"\r\n"+
				year+"\r\n"+

				moonSpeed+"\r\n"+
				AchievementStoneAge+"\r\n"+
				AchievementBronzeAge+"\r\n"+
				AchievementIronAge+"\r\n"+
				AchievementFutureAge);
			}

		void CreateJumpMess(List<DInt> blocks) {
			if (blocks.Count==2){
				DInt d=blocks[0].Y<blocks[1].Y ? blocks[0] : blocks[1]; 
				Block block=terrain[d.X].SolidBlocks[d.Y];
				Particles.Clear();

				if (block is NormalBlock b) {
					Texture2D tex = b.Texture;

					for (int i=0; i<8; i++) { 
						float x=PlayerX+(i-4);
						float z=random.Float();
						Particles.Add(new ParticleMess {
							Disepeard=50,
							Texture=tex,
							Position=new Vector2(x, d.Y*16-1f),
							Source=new Rectangle(i, 0, z>0.5f ? 2 : 1, z>0.5f ? 2 : 1),
							HSpeed=-1.5f-z,
							VSpeed=(i-4+random.Float()*0.5f)*0.1f,
							LimitY=(x<blocks[1].X*16) ? blocks[0].Y*16-2 : blocks[1].Y*16-2,
							Color=(random.Bool() ? ColorWhite : Color.LightGray) * ((random.Float()+1)*0.5f)
						});
					}
				}
			} else {
				DInt d = blocks[0];
				Block block=terrain[d.X].SolidBlocks[d.Y];
				Particles.Clear();

				if (block is NormalBlock b) {
					Texture2D tex = b.Texture;

					for (int i=0; i<8; i++) { 
						float z=random.Float();
						Particles.Add(new ParticleMess {
							Disepeard=50,
							Texture=tex,
							Position=new Vector2(PlayerX+(i-4), d.Y*16-1f),
							Source=new Rectangle(i, 0, z>0.5f ? 2 : 1, z>0.5f ? 2 : 1),
							HSpeed=-1.5f-z,
							VSpeed=(i-4)*0.1f,
							LimitY=d.Y*16-2,
							Color=(random.Bool() ? ColorWhite : Color.LightGray)* ((random.Float()+1)*0.5f)
						});
					}
				}
			}
		}

		void FindPlants(){
			int x=(int)PlayerX/16, 
				y=(int)(PlayerY+22-16)/16;

			Terrain chunk=terrain[x];
			if (chunk.IsTopBlocks[y]) { 
				switch (chunk.TopBlocks[y].Id) { 
					case (ushort)BlockId.GrassDesert:
					case (ushort)BlockId.GrassForest:
					case (ushort)BlockId.GrassHills:
					case (ushort)BlockId.GrassJungle:
					case (ushort)BlockId.GrassPlains:
					case (ushort)BlockId.Violet:
					case (ushort)BlockId.Dandelion:
					case (ushort)BlockId.Heather:
					case (ushort)BlockId.Orchid:
					case (ushort)BlockId.Alore:
					case (ushort)BlockId.Rose:
						{
							if (chunk.TopBlocks[y] is NormalBlock n){
								BasicWavingPlant p=new BasicWavingPlant(n.Texture, n.Id, n.Position, speedDir==1);
								chunk.TopBlocks[y]=p;
								WavingPlants.Add(p);
								return;
							}
						}
						break;
				}
			}

            for (int i = 0; i<chunk.Plants.Count; i++) {
				Plant p=chunk.Plants[i];

				if (!(p is FruitPlantWaving)) {
					FruitPlantWaving z=p.TurnToWavingPlant(speedDir==1);
					chunk.Plants[i]=z;
					WavingPlants.Add(z);
					return;
				}
            }
		}

		void StopWavingTrees() { 
			 if (wind) {
				for (int i = 0; i<LiveObjects.Length; i++) {
					LiveObjects[i].angle=0;
				}
			} 
		}

		void WaveGrassDuringWind(){ 
			if (!Constants.AnimationsGame) return;
			if (waveGrassIndex<terrainStartIndexX-20)waveGrassIndex=(terrainStartIndexX-10<0) ? 0 : terrainStartIndexX-10;
			waveGrassIndex++;
			if (waveGrassIndex>terrainStartIndexW+10) waveGrassIndex=terrainStartIndexX-10<0 ? 0 : terrainStartIndexX-10;

			Terrain chunk=terrain[waveGrassIndex];
			for (int y=chunk.StartSomething; y<125; y++) { 
				if (chunk.IsTopBlocks[y]){
					switch (chunk.TopBlocks[y].Id) { 
						case (ushort)BlockId.GrassDesert:
						case (ushort)BlockId.GrassForest:
						case (ushort)BlockId.GrassHills:
						case (ushort)BlockId.GrassJungle:
						case (ushort)BlockId.GrassPlains:
						case (ushort)BlockId.Violet:
						case (ushort)BlockId.Dandelion:
						case (ushort)BlockId.Heather:
						case (ushort)BlockId.Orchid:
						case (ushort)BlockId.Alore:
						case (ushort)BlockId.Rose:
							{
								if (chunk.TopBlocks[y] is NormalBlock n) {
									BasicWavingPlant p=new BasicWavingPlant(n.Texture, n.Id, n.Position, true);
									chunk.TopBlocks[y]=p;
									WavingPlants.Add(p);
									return;
								}
							}
							break;
					}
				}
			}

			for (int i=0; i< chunk.Plants.Count; i++) {
				Plant p = chunk.Plants[i];

				if (!(p is FruitPlantWaving)) {
					if (p.Height<=chunk.LightPosFull) {
						
						FruitPlantWaving z=p.TurnToWavingPlant(true);
						//	chunk.TopBlocks[y]=p;
						chunk.Plants[i]=z;
						WavingPlants.Add(z);
						return;
						
					}
				}
			}
		}

		void DescayInventory(ItemInv[] inv) {
			for (int i = 0; i<inv.Length; i++) {
				switch (inv[i]) {
					case ItemInvFood16 food:
						if (food.GetDescay<DescaySpeed) InventoryNormal[i]=itemBlank;
						else food.SetDescay=food.GetDescay+DescaySpeed;
						break;

					case ItemInvFood32 food:
						if (food.GetDescay<DescaySpeed) InventoryNormal[i]=itemBlank;
						else food.SetDescay=food.GetDescay+DescaySpeed;
						break;
				}
			}
		}

		//bool IsSelectedShears() { 
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.ShearsCopper) return true;
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.ShearsBronze) return true;
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.ShearsGold) return true;
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.ShearsIron) return true;
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.ShearsSteel) return true;
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.ShearsAluminium) return true;
		//	return false;
		//}

		//bool IsSelectedKnife() { 
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.KnifeCopper) return true;
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.KnifeBronze) return true;
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.KnifeGold) return true;
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.KnifeIron) return true;
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.KnifeSteel) return true;
		//	if (InventoryNormal[boxSelected].Id==(ushort)Items.KnifeAluminium) return true;
		//	return false;
		//}

		float GetTemperature(Biome biome) { 
			switch (biome) {
				case Biome.ArcticPlains: return TemperatureFromTo(-5,-15, -50,-60);
				case Biome.Arctic: return TemperatureFromTo(0,-6, -24,-32);
				case Biome.DryTundra: return TemperatureFromTo(20,-2, -30,-50);
				case Biome.Tundra: return TemperatureFromTo(13,-2, -15,-40);
				case Biome.WetTundra: return TemperatureFromTo(18,1, -20,-35);
				case Biome.ColdTaiga: return TemperatureFromTo(20,1,-30,-54);
				case Biome.Taiga: return TemperatureFromTo(22,8, -20,-45);
				case Biome.SpruceForest: return TemperatureFromTo(15,9, -2,-7);
				case Biome.BothForest: return TemperatureFromTo(25,15, -1,-6);
				case Biome.Plains: return TemperatureFromTo(29,16, -2,-7);
				case Biome.LeaveForest: return TemperatureFromTo(26,19, 5,-1);
				case Biome.Swamp: return TemperatureFromTo(29,24, 16,6);
				case Biome.Fen: return TemperatureFromTo(24,16, -2,-4);
				case Biome.Bog: return TemperatureFromTo(19,11,7,1);
				case Biome.SaltOcean: return TemperatureFromTo(28,24, 15,8);
				case Biome.ExtremeColdBeach: return TemperatureFromTo(2,-1, 1,-3);
				case Biome.ColdBeach: return TemperatureFromTo(16,12, 1,-3);
				case Biome.Beach: return TemperatureFromTo(26,23, 10,8);
				case Biome.HotBeach: return TemperatureFromTo(27,24, 21,16);
				case Biome.HotPlains: return TemperatureFromTo(33,21, 14,2);
				case Biome.Mangrove: return TemperatureFromTo(24,20, 22,18);
				case Biome.HumidSubtropical: return TemperatureFromTo(28,24, 18,6);
				case Biome.Subtropics: return TemperatureFromTo(29,18, 20,9);
				case Biome.Desert: return TemperatureFromTo(39,25, 19,6);
				case Biome.Savanna: return TemperatureFromTo(33,24, 17,6);
				case Biome.Jungle: return TemperatureFromTo(32,24, 29,23);
				case Biome.TropicalRainforest: return TemperatureFromTo(32,24, 29,23);
				case Biome.None: return 0;
			}
			#if DEBUG
			throw new Exception("Missing biome color");
			#else
			return 0;
			#endif
		}

		/// <param name="temperatureSpeedChange">From 1 to 8, bigger for more humid</param>
		/// <returns></returns>
		float TemperatureFromTo(int daySummerTemperature, int nightSummerTemperature, int dayWinterTemperature, int nightWinterTemperature, float temperatureSpeedChange=6) { 
			float tempDay, tempNight;

			if (day>22 && day<200){ 
				tempDay=FastMath.Smooth((day-22)/178f)*(daySummerTemperature-dayWinterTemperature)+dayWinterTemperature;
				tempNight=FastMath.Smooth((day-22)/178f)*(nightSummerTemperature-nightWinterTemperature)+nightWinterTemperature;
			} else if (day<22) { 
				tempDay=(1-FastMath.Smooth((day+156)/178f))*(daySummerTemperature-dayWinterTemperature)+dayWinterTemperature;
				tempNight=(1-FastMath.Smooth((day+156)/178f))*(nightSummerTemperature-nightWinterTemperature)+nightWinterTemperature;
			} else { 
				tempDay=(1-FastMath.Smooth((day-200)/178))*(daySummerTemperature-dayWinterTemperature)+dayWinterTemperature;
				tempNight=(1-FastMath.Smooth((day-200)/178))*(nightSummerTemperature-nightWinterTemperature)+nightWinterTemperature;
			}

			float noon=(dayEnd-(dayStart+1))*hour;

			// Rising temp
			if (time>dayStart*hour && time<noon) return FastMath.Smooth((time-dayStart*hour)/(noon-dayStart*hour))*(tempDay-tempNight)+tempNight;
			//aftenoon
			else if (time>noon) return FastMath.Smooth((time-noon)/(noon-dayStart*hour))*(tempDay-tempNight)+tempNight;
			//before sun rise
			else return FastMath.Smooth((time-(noon-dayStart*hour))/(noon-dayStart*hour))*(tempDay-tempNight)+tempNight;
		}

		void ChangeLeavesForceEverything() { 

			// Spring: branches -> flowering leaves or leaves
			if (day>=80 && day<=100) { 
				for (int x=0; x<TerrainLength; x++) { 
					Terrain chunk=terrain[x];
								
					for (int y=chunk.StartSomething; y<125; y++) {
						if (chunk.IsTopBlocks[y]) { 
							if (chunk.TopBlocks[y] is LeavesBlock leaves) { 
								switch (leaves.Id){
                                    #region Apple -> Blossom
									case (ushort)BlockId.AppleBranches:
										leaves.Id=(ushort)BlockId.AppleLeavesBlossom;
										leaves.Texture=TextureAppleBlossom;
										leaves.Color=ColorWhite;
										continue;

                                    case (ushort)BlockId.AppleLeaves:
										leaves.Id=(ushort)BlockId.AppleLeavesBlossom;
										leaves.Texture=TextureAppleBlossom;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.AppleLeavesWithApples:
										leaves.Id=(ushort)BlockId.AppleLeavesBlossom;
										leaves.Texture=TextureAppleBlossom;
										leaves.Color=ColorWhite;
										continue;
                                    #endregion

									#region Plum -> Blossom
									case (ushort)BlockId.PlumBranches:
										leaves.Id=(ushort)BlockId.PlumLeavesBlossom;
										leaves.Texture=TexturePlumBlossom;
										leaves.Color=ColorWhite;
										continue;

                                    case (ushort)BlockId.PlumLeaves:
										leaves.Id=(ushort)BlockId.PlumLeavesBlossom;
										leaves.Texture=TexturePlumBlossom;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.PlumLeavesWithPlums:
										leaves.Id=(ushort)BlockId.PlumLeaves;
										leaves.Texture=TexturePlumBlossom;
										leaves.Color=ColorWhite;
										continue;
									#endregion

									#region Cherry -> Blossom
									case (ushort)BlockId.CherryBranches:
										leaves.Id=(ushort)BlockId.CherryLeavesBlossom;
										leaves.Texture=TextureCherryBlossom;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.CherryLeaves:
										leaves.Id=(ushort)BlockId.CherryLeavesBlossom;
										leaves.Texture=TextureCherryBlossom;
										continue;

									case (ushort)BlockId.CherryLeavesWithCherries:
										leaves.Id=(ushort)BlockId.CherryLeavesBlossom;
										leaves.Texture=TextureCherryBlossom;
										leaves.Color=ColorWhite;
										continue;
									#endregion

									#region Oak, linden branches -> leaves
									case (ushort)BlockId.OakBranches:
										leaves.Id=(ushort)BlockId.OakLeaves;
										leaves.Texture=TextureOakLeaves;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.LindenBranches:
										leaves.Id=(ushort)BlockId.LindenLeaves;
										leaves.Texture=TextureLindenLeaves;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.WillowBranches:
										leaves.Id=(ushort)BlockId.WillowLeaves;
										leaves.Texture=TextureWillowLeaves;
										leaves.Color=ColorWhite;
										continue;
									#endregion
								}
							}
						}
					}
				}
				return;
			}

			// Summer: set leaves
			if (day>=100 && day<=280) { 
				for (int x=0; x<TerrainLength; x++) { 
					Terrain chunk=terrain[x];
					
					for (int y=chunk.StartSomething; y<125; y++) {
						if (chunk.IsTopBlocks[y]) { 
							if (chunk.TopBlocks[y] is LeavesBlock leaves) { 
								switch (leaves.Id) {
                                    #region Apple
                                    case (ushort)BlockId.AppleBranches:
										leaves.Id=(ushort)BlockId.AppleLeaves;
										leaves.Texture=TextureAppleLeaves;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.AppleLeavesBlossom:
										leaves.Id=(ushort)BlockId.AppleLeaves;
										leaves.Texture=TextureAppleLeaves;
										leaves.Color=ColorWhite;
										continue;
                                    #endregion

                                    #region Plum
                                    case (ushort)BlockId.PlumBranches:
										leaves.Id=(ushort)BlockId.PlumLeaves;
										leaves.Texture=TexturePlumLeaves;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.PlumLeavesBlossom:
										leaves.Id=(ushort)BlockId.PlumLeaves;
										leaves.Texture=TexturePlumLeaves;
										leaves.Color=ColorWhite;
										continue;
                                    #endregion

                                    #region Cherry
									case (ushort)BlockId.CherryLeavesBlossom:
										leaves.Id=(ushort)BlockId.CherryLeaves;
										leaves.Texture=TextureCherryLeaves;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.CherryBranches:
										leaves.Id=(ushort)BlockId.CherryLeaves;
										leaves.Texture=TextureCherryLeaves;
										leaves.Color=ColorWhite;
										continue;
                                    #endregion

                                    case (ushort)BlockId.LindenBranches:
										leaves.Id=(ushort)BlockId.LindenLeaves;
										leaves.Texture=TextureLindenLeaves;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.OakBranches:
										leaves.Id=(ushort)BlockId.OakLeaves;
										leaves.Texture=TextureOakLeaves;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.WillowBranches:
										leaves.Id=(ushort)BlockId.WillowLeaves;
										leaves.Texture=TextureWillowLeaves;
										leaves.Color=ColorWhite;
										continue;
								}
							}
						}
					}
				}
				return;
			} 

			// Autumn: leaves -> Colorful
			if (day>=280 && day<=340) { 
				Color[] colors=new Color[]{ 
		
					new Color(144, 170, 6),
					new Color(162, 163, 3),
					new Color(212, 103, 25),
					new Color(218, 120, 27),
					new Color(254, 255, 74),
				};

				for (int x=0; x<TerrainLength; x++) { 
					Terrain chunk=terrain[x];
								
					for (int y=chunk.StartSomething; y<125; y++) {
						if (chunk.IsTopBlocks[y]) { 
							if (chunk.TopBlocks[y] is LeavesBlock leaves) { 
								switch (leaves.Id) {
									#region Apple
                                    case (ushort)BlockId.AppleBranches:
										leaves.Id=(ushort)BlockId.AppleLeaves;
										leaves.Texture=TextureAppleLeaves;
										goto case (ushort)BlockId.AppleLeaves;

									case (ushort)BlockId.AppleLeavesBlossom:
										leaves.Id=(ushort)BlockId.AppleLeaves;
										leaves.Texture=TextureAppleLeaves;
										goto case (ushort)BlockId.AppleLeaves;

									case (ushort)BlockId.AppleLeavesWithApples:
										leaves.Id=(ushort)BlockId.AppleLeaves;
										leaves.Texture=TextureAppleLeaves;
										goto case (ushort)BlockId.AppleLeaves;
                                  
                                    case (ushort)BlockId.AppleLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
									#endregion

									#region Plum
                                    case (ushort)BlockId.PlumBranches:
										leaves.Id=(ushort)BlockId.PlumLeaves;
										leaves.Texture=TexturePlumLeaves;
										goto case (ushort)BlockId.PlumLeaves;
																			
									case (ushort)BlockId.PlumLeavesBlossom:
										leaves.Id=(ushort)BlockId.PlumLeaves;
										leaves.Texture=TexturePlumLeaves;
										goto case (ushort)BlockId.PlumLeaves;

									case (ushort)BlockId.PlumLeavesWithPlums:
										leaves.Id=(ushort)BlockId.PlumLeaves;
										leaves.Texture=TexturePlumLeaves;
										goto case (ushort)BlockId.PlumLeaves;

                                    case (ushort)BlockId.PlumLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
                                    #endregion

									#region Cherry
									case (ushort)BlockId.CherryLeavesBlossom:
										leaves.Id=(ushort)BlockId.CherryLeaves;
										leaves.Texture=TextureCherryLeaves;
										goto case (ushort)BlockId.CherryLeaves;

                                    case (ushort)BlockId.CherryBranches:
										leaves.Id=(ushort)BlockId.CherryLeaves;
										leaves.Texture=TextureCherryLeaves;
										goto case (ushort)BlockId.CherryLeaves;

									case (ushort)BlockId.CherryLeavesWithCherries:
										leaves.Id=(ushort)BlockId.CherryLeaves;
										leaves.Texture=TextureCherryLeaves;
										goto case (ushort)BlockId.CherryLeaves;

									case (ushort)BlockId.CherryLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
                                    #endregion

                                    #region Oak
                                    case (ushort)BlockId.OakBranches:
										leaves.Id=(ushort)BlockId.OakLeaves;
										leaves.Texture=TextureCherryLeaves;
										leaves.Color=colors[random.Int(5)];
										continue;

									case (ushort)BlockId.OakLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
                                    #endregion

                                    #region Linden
                                    case (ushort)BlockId.LindenBranches:
										leaves.Id=(ushort)BlockId.LindenLeaves;
										leaves.Texture=TextureLindenLeaves;
										leaves.Color=colors[random.Int(5)];
										continue;

									case (ushort)BlockId.LindenLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
                                    #endregion

									#region Willow
                                    case (ushort)BlockId.WillowBranches:
										leaves.Id=(ushort)BlockId.WillowLeaves;
										leaves.Texture=TextureWillowLeaves;
										leaves.Color=colors[random.Int(5)];
										continue;

									case (ushort)BlockId.WillowLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
                                    #endregion
                                }
                            }
						}
					}
				}
				return;
			}

			// Winter: Leaves -> Branches
			if (day<=80 || day>=340) { 
				for (int x=0; x<TerrainLength; x++) { 
					Terrain chunk=terrain[x];
								
					for (int y=chunk.StartSomething; y<125; y++) {
						if (chunk.IsTopBlocks[y]) { 
							if (chunk.TopBlocks[y] is LeavesBlock leaves) { 
								switch (leaves.Id){
                                    #region Apple
									case (ushort)BlockId.AppleLeaves:
										leaves.Id=(ushort)BlockId.AppleBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;

                                    case (ushort)BlockId.AppleLeavesBlossom:
										leaves.Id=(ushort)BlockId.AppleBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.AppleLeavesWithApples:
										leaves.Id=(ushort)BlockId.AppleBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;
                                    #endregion

                                    #region Plum
                                    case (ushort)BlockId.PlumLeaves:
										leaves.Id=(ushort)BlockId.PlumBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.PlumLeavesBlossom:
										leaves.Id=(ushort)BlockId.PlumBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;
										
									case (ushort)BlockId.PlumLeavesWithPlums:
										leaves.Id=(ushort)BlockId.PlumBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;
                                    #endregion

									#region Cherry
									case (ushort)BlockId.CherryLeaves:
										leaves.Id=(ushort)BlockId.CherryBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;
																		
                                    case (ushort)BlockId.CherryLeavesBlossom:
										leaves.Id=(ushort)BlockId.CherryBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.CherryLeavesWithCherries:
										leaves.Id=(ushort)BlockId.CherryBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;
                                    #endregion

                                    case (ushort)BlockId.LindenLeaves:
										leaves.Id=(ushort)BlockId.LindenBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.OakLeaves:
										leaves.Id=(ushort)BlockId.OakBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.WillowLeaves:
										leaves.Id=(ushort)BlockId.WillowBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;
								}
							}
						}
					}
				}
			}
		}

		void ChangeLeavesSomething() { 

			// Spring: branches -> flowering leaves or leaves
			if (day>=80 && day<=100) { 
				for (int x=0; x<TerrainLength; x++) { 
					Terrain chunk=terrain[x];
								
					for (int y=chunk.StartSomething; y<125; y++) {
						if (chunk.IsTopBlocks[y]) { 
							if (chunk.TopBlocks[y] is LeavesBlock leaves) { 
								switch (leaves.Id){
									case (ushort)BlockId.AppleBranches:
										leaves.Id=(ushort)BlockId.AppleLeavesBlossom;
										leaves.Texture=TextureAppleBlossom;
										continue;

									case (ushort)BlockId.PlumBranches:
										leaves.Id=(ushort)BlockId.PlumLeavesBlossom;
										leaves.Texture=TexturePlumBlossom;
										continue;

									case (ushort)BlockId.CherryBranches:
										leaves.Id=(ushort)BlockId.CherryLeavesBlossom;
										leaves.Texture=TextureCherryBlossom;
										continue;

									case (ushort)BlockId.OakBranches:
										leaves.Id=(ushort)BlockId.OakLeaves;
										leaves.Texture=TextureOakLeaves;
										continue;

									case (ushort)BlockId.LindenBranches:
										leaves.Id=(ushort)BlockId.LindenLeaves;
										leaves.Texture=TextureLindenLeaves;
										continue;

									case (ushort)BlockId.WillowBranches:
										leaves.Id=(ushort)BlockId.WillowLeaves;
										leaves.Texture=TextureWillowLeaves;
										continue;
								}
							}
						}
					}
				}
				return;
			}

			// Summer: set leaves
			if (day>=100 && day<=280) { 
				for (int x=0; x<TerrainLength; x++) { 
					Terrain chunk=terrain[x];
					
					for (int y=chunk.StartSomething; y<125; y++) {
						if (chunk.IsTopBlocks[y]) { 
							if (chunk.TopBlocks[y] is LeavesBlock leaves) { 
								switch (leaves.Id) {
                                    case (ushort)BlockId.AppleBranches:
										leaves.Id=(ushort)BlockId.AppleLeaves;
										leaves.Texture=TextureAppleLeaves;
										continue;
																		
                                    case (ushort)BlockId.PlumBranches:
										leaves.Id=(ushort)BlockId.PlumLeaves;
										leaves.Texture=TexturePlumLeaves;
										continue;
																			
									case (ushort)BlockId.CherryLeavesBlossom:
										leaves.Id=(ushort)BlockId.CherryLeaves;
										leaves.Texture=TextureCherryLeaves;
										continue;
								}
							}
						}
					}
				}
				return;
			} 

			// Autumn: leaves -> Colorful
			if (day>=280 && day<=340) { 
				Color[] colors=new Color[]{ 
		
					new Color(144, 170, 6),
					new Color(162, 163, 3),
					new Color(212, 103, 25),
					new Color(218, 120, 27),
					new Color(254, 255, 74),
				};

				for (int x=0; x<TerrainLength; x++) { 
					Terrain chunk=terrain[x];
								
					for (int y=chunk.StartSomething; y<125; y++) {
						if (chunk.IsTopBlocks[y]) { 
							if (chunk.TopBlocks[y] is LeavesBlock leaves) { 
								switch (leaves.Id) {
								
									case (ushort)BlockId.AppleLeavesWithApples:
										leaves.Id=(ushort)BlockId.AppleLeaves;
										leaves.Texture=TextureAppleLeaves;
										goto case (ushort)BlockId.AppleLeaves;
                                  
                                    case (ushort)BlockId.AppleLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
									
									case (ushort)BlockId.PlumLeavesWithPlums:
										leaves.Id=(ushort)BlockId.PlumLeaves;
										leaves.Texture=TexturePlumLeaves;
										goto case (ushort)BlockId.PlumLeaves;

                                    case (ushort)BlockId.PlumLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
                                  
									case (ushort)BlockId.CherryLeavesWithCherries:
										leaves.Id=(ushort)BlockId.CherryLeaves;
										leaves.Texture=TextureCherryLeaves;
										goto case (ushort)BlockId.CherryLeaves;

									case (ushort)BlockId.CherryLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
                                   

									case (ushort)BlockId.OakLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
                                   
									case (ushort)BlockId.LindenLeaves:
										leaves.Color=colors[random.Int(5)];
										continue;
                                }
                            }
						}
					}
				}
				return;
			}

			// Winter: Leaves -> Branches
			if (day<=80 || day>=340) { 
				for (int x=0; x<TerrainLength; x++) { 
					Terrain chunk=terrain[x];
								
					for (int y=chunk.StartSomething; y<125; y++) {
						if (chunk.IsTopBlocks[y]) { 
							if (chunk.TopBlocks[y] is LeavesBlock leaves) { 
								switch (leaves.Id){
                                   
									case (ushort)BlockId.AppleLeaves:
										leaves.Id=(ushort)BlockId.AppleBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;

                                    case (ushort)BlockId.PlumLeaves:
										leaves.Id=(ushort)BlockId.PlumBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.CherryLeaves:
										leaves.Id=(ushort)BlockId.CherryBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;
											
                                    case (ushort)BlockId.LindenLeaves:
										leaves.Id=(ushort)BlockId.LindenBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.OakLeaves:
										leaves.Id=(ushort)BlockId.OakBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;

									case (ushort)BlockId.WillowLeaves:
										leaves.Id=(ushort)BlockId.WillowBranches;
										leaves.Texture=TextureBranches;
										leaves.Color=ColorWhite;
										continue;
								}
							}
						}
					}
				}
			}
		}

		Color GetColorBackNoRain() { 
			// Day
			if (time>=(dayStart+1)*hour && time<=dayEnd*hour) {
				return Color.LightSkyBlue; 

			// Night
			} else if (time<=dayStart*hour || time>=(dayEnd+1)*hour) {
				return ColorNightColorBack;

			// Sun rising (before sun)
			} else if (time>=dayStart*hour && time<=(dayStart+0.5f)*hour) { 
				if (Constants.AnimationsGame) {
					float a=-(dayStart*hour-time)/(hour);
					return FastMath.Lerp(ColorNightColorBack, Color.LightSkyBlue, a);
				} else return FastMath.Lerp(ColorNightColorBack, Color.LightSkyBlue, -(dayStart*hour-time)/(hour));

			} else if (time>=(dayStart+0.5f)*hour && time<=(dayStart+1)*hour) { 

				// Sun rising (before sun)
				if (Constants.AnimationsGame) {
					float a=0.5f+((dayStart+0.5f)*hour-time)/hour;
					return FastMath.Lerp(Color.LightSkyBlue, ColorNightColorBack, a);
				} else return FastMath.Lerp(Color.LightSkyBlue, ColorNightColorBack, 0.5f+((dayStart+0.5f)*hour-time)/hour);

			} else if (time>=dayEnd*hour && time<=(dayEnd+0.5f)*hour) { 

				// Sun setting
				if (Constants.AnimationsGame) {
					float a=0.5f-((dayEnd+0.5f)*hour-time)/(hour*2);
					return FastMath.Lerp(Color.LightSkyBlue, ColorNightColorBack, a);
				} else return FastMath.Lerp(Color.LightSkyBlue, ColorNightColorBack, 0.5f-((dayEnd+0.5f)*hour-time)/(hour*2));

			} else if (time>=(dayEnd+0.5f)*hour && time<=(dayEnd+1)*hour) { 

				// Sun setting
				if (Constants.AnimationsGame) {
					float a=((dayEnd+1)*hour-time)/(hour*2);
					return FastMath.Lerp(ColorNightColorBack, Color.LightSkyBlue, a);
				} else return FastMath.Lerp(ColorNightColorBack, Color.LightSkyBlue, ((dayEnd+1)*hour-time)/(hour*2));

			}
			return Color.LightSkyBlue; 
		}

		Color GetColorBackRain() { 
			// Day
			if (time>=(dayStart+1)*hour && time<=dayEnd*hour) {
				return ColorDayRainBack; 

			// Night
			} else if (time<=dayStart*hour || time>=(dayEnd+1)*hour) {
				return ColorNightColorBackRain;

			// Sun rising (before sun)
			} else if (time>=dayStart*hour && time<=(dayStart+0.5f)*hour) { 
				if (Constants.AnimationsGame) {
					float a=-(dayStart*hour-time)/(hour);
					return FastMath.Lerp(ColorNightColorBackRain, ColorDayRainBack, a);
				} else return FastMath.Lerp(ColorNightColorBackRain, ColorDayRainBack, -(dayStart*hour-time)/(hour));

			} else if (time>=(dayStart+0.5f)*hour && time<=(dayStart+1)*hour) { 

				// Sun rising (before sun)
				if (Constants.AnimationsGame) {
					float a=0.5f+((dayStart+0.5f)*hour-time)/hour;
					return FastMath.Lerp(ColorDayRainBack, ColorNightColorBackRain, a);
				} else return FastMath.Lerp(ColorDayRainBack, ColorNightColorBackRain, 0.5f+((dayStart+0.5f)*hour-time)/hour);

			} else if (time>=dayEnd*hour && time<=(dayEnd+0.5f)*hour) { 

				// Sun setting
				if (Constants.AnimationsGame) {
					float a=0.5f-((dayEnd+0.5f)*hour-time)/(hour*2);
					return FastMath.Lerp(ColorDayRainBack, ColorNightColorBackRain, a);
				} else return FastMath.Lerp(ColorDayRainBack, ColorNightColorBackRain, 0.5f-((dayEnd+0.5f)*hour-time)/(hour*2));

			} else if (time>=(dayEnd+0.5f)*hour && time<=(dayEnd+1)*hour) { 

				// Sun setting
				if (Constants.AnimationsGame) {
					float a=((dayEnd+1)*hour-time)/(hour*2);
					return FastMath.Lerp(ColorNightColorBackRain, ColorDayRainBack, a);
				} else return FastMath.Lerp(ColorNightColorBackRain, ColorDayRainBack, ((dayEnd+1)*hour-time)/(hour*2));

			}
			return ColorDayRainBack; 
		}

		bool Command() { 
			if (text.StartsWith("*time-set ")) {
				if (int.TryParse(text.Substring("*time-set ".Length), out int num)) {
					time=num*hour; 
				} else if (float.TryParse(text.Substring("*time-set ".Length), out float num2)) {
					time=(int)(num2*hour); 
				}
				text="";
				diserpeard=0;
				return true;
			} 
			if (text.StartsWith("*day-set ")){
				if (int.TryParse(text.Substring("*day-set ".Length), out int num)){
					day=num; 
					ChangeLeavesForceEverything();
				}
				text="";
				diserpeard=0;
				return true;
			} 
			if (text=="*time-set early morning"){
				time=(int)(5.5f*hour); 
				ChangeLeavesForceEverything();
				text="";
				diserpeard=0;
				return true;
			} 

			if (text=="*time-set late morning"){
				time=(int)(9.5f*hour); 
				ChangeLeavesForceEverything();
				text="";
				diserpeard=0;
				return true;
			} 
						
			if (text=="*time-set morning"){
				time=(int)(7f*hour); 
				ChangeLeavesForceEverything();
				text="";
				diserpeard=0;
				return true;
			} 

			if (text=="*time-set noon"){
				time=(int)(12f*hour); 
				ChangeLeavesForceEverything();
				text="";
				diserpeard=0;
				return true;
			} 

			if (text=="*time-set night"){
				time=(int)(20f*hour); 
				ChangeLeavesForceEverything();
				text="";
				diserpeard=0;
				return true;
			} 

			if (text=="*time-set afternoon"){
				time=(int)(14f*hour); 
				ChangeLeavesForceEverything();
				text="";
				diserpeard=0;
				return true;
			} 

			if (text=="*time-set evening"){
				time=(int)(16f*hour); 
				ChangeLeavesForceEverything();
				text="";
				diserpeard=0;
				return true;
			} 

			if (text=="*time-set midnight"){
				time=0; 
				ChangeLeavesForceEverything();
				text="";
				diserpeard=0;
				return true;
			} 

			if (text=="*give-mobile") {
				InventoryAddOne((ushort)Items.Mobile);
				text="";
				diserpeard=0;text="";diserpeard=0;
				return true;
			} 
			if (text=="*wd0") {
				Global.WorldDifficulty=0;text="";diserpeard=0;
				return true;
			} 
			if (text=="*wd1") {
				Global.WorldDifficulty=1;text="";diserpeard=0;
				return true;
			} 
			if (text=="*wd2") {
				Global.WorldDifficulty=2;text="";diserpeard=0;
				return true;
			} 
			if (text=="*rain-change") {
				changeRain=1;
				text="";diserpeard=0;
				return true;
			} 
			if (text=="*wind-change") {
				timeToChageWind=1;
				text="";diserpeard=0;
				return true;
			}
			if (text.StartsWith("*error")) {
				throw new Exception("Manual error");
			} 
			return false;
		}

		 class ParticleMess {
            public Vector2 Position;
            public Rectangle Source;
            public Texture2D Texture;
            public int Disepeard;

            public float LimitY;
            public float HSpeed;
            public float VSpeed;
            public Color Color;

            public void Update() {
                HSpeed+=gravity*0.5f;
                Position.Y+=HSpeed;

                Position.X+=VSpeed;

                if (Position.Y>=LimitY) Position.Y=LimitY;
            }

            public void Draw() => Rabcr.spriteBatch.Draw(Texture, Position, Source, Color*(Disepeard/50f));
        }

        class ParticleRain {
            public Vector2 Position;

            public float HSpeed;
            public float VSpeed;
            public Color Color;
            //	public float Angle;

            public float Size;

            public ParticleRain(float size, float vSpeed) {
                Color=Color.Blue*(Size=size);
                VSpeed=vSpeed*(size*0.5f+0.5f);
            }

            public void Update() {
                Position.X+=HSpeed*Size;
                Position.Y+=VSpeed;
            }

            public void Draw(float x, float y,float a) => Rabcr.spriteBatch.Draw(
                    texture: Rabcr.Pixel,
                    destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y), 1, Size<0.5f ? 2 : 3),
                    //sourceRectangle: null,
                    //effects:SpriteEffects.None,
                    color: Color*a/*,*/
                //rotation: Angle,
                //origin: Vector2.Zero,
                //layerDepth: 1f
                );
        }

        class ParticleSnow {
            public Vector2 Position;

            public float HSpeed;
            public float VSpeed;
            public Color Color;
            //	public float Angle;
            int time;
            public float Size;

            public ParticleSnow(float size, float vSpeed) {
                Color=Color.White*(Size=size);
                VSpeed=vSpeed*size;
            }

            public void Update() {
                time++;
                Position.X+=HSpeed+((float)Math.Cos(time/10f))*0.25f;
                Position.Y+=VSpeed+((float)Math.Sin(time/10f))*HSpeed*0.5f/*+0.2f*/;
            }

            public void Draw(float x, float y,float A) => Rabcr.spriteBatch.Draw(
                    texture: Rabcr.Pixel,
                    destinationRectangle: new Rectangle((int)(Position.X+0.5f+x), (int)(Position.Y+0.5f+y), Size>0.5f ? 2 : 1, Size>0.5f ? 2 : 1),
                    //sourceRectangle: null,
                    //effects:SpriteEffects.None,
                    color: Color*A//,
                                //rotation: Angle,
                                //origin: Vector2.Zero,
                                //layerDepth: 1f
                );

        }

        class FallingLeave {
            public Texture2D texture;
            public Vector2 Position;
            public float angle;
            public float time;
            //	public float size;
            Vector2 vecOrigin;
            public float VSpeed;
            public Rectangle srcrec;
            public Color Color = Color.White;
            public FallingLeave(int x, int y, float size, bool leftWind, bool rain, Rectangle src) {
                Position=new Vector2(x, y);
                vecOrigin=new Vector2(size, size);
                if (rain) {
                    if (leftWind) VSpeed=-0.01f; else VSpeed=0.01f;
                } else {
                    if (leftWind) VSpeed=-0.09f; else VSpeed=0.09f;
                }
                srcrec=src;
            }

            public void Update() {
                time+=0.07f;
                Position.X+=VSpeed;
                Position.Y+=(float)Math.Cos(time)*0.125f+0.35f;
                angle=(float)Math.Cos(time)*0.3f+FastMath.PI/2f;
            }

            public void Draw() {
                Rabcr.spriteBatch.Draw(
                    texture: texture,		
                    position: new Vector2(Position.X, Position.Y/*, srcrec.Width, srcrec.Height*/),
                //    destinationRectangle: new Rectangle((int)Position.X, (int)Position.Y, srcrec.Width, srcrec.Height),
                    sourceRectangle: srcrec/*new Rectangle(0,0,2,3)*/,
                    effects: SpriteEffects.None,
                    color: Color,
					scale: 1f,
                    rotation: angle,
                    origin: vecOrigin,
                    layerDepth: 1f);
            }
        }
	}
}