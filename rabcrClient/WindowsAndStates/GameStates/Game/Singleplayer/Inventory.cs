using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace rabcrClient {
    partial class SinglePlayer : Screen{
        #region Drop item
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
		//void ItemDrop(ItemNonInv item, int x, int y) {
		//	DroppedItems.Add(new Item {
		//		X=x,
		//		Y=y,
		//		item=item,
		//		Texture=ItemIdToTexture(item.Id),
		//	});
		//}
		void DropItemToPos(ItemNonInv i, float x, float y) {
			DroppedItems.Add(new Item {
				X=(int)x,
				Y=(int)y,
				item=i,
				Texture=ItemIdToTexture(i.Id)
			});
		}
        #endregion

        void UpdateItem(List<Item> list) {
			foreach (Item i in list) {
				if (i.X>PlayerXInt-11-16) {
					if (i.X<PlayerXInt+11) {
						if (i.Y>PlayerYInt-20) {
							if (i.Y<PlayerYInt+20) {
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
			if (barEat.Value>1f) {
			switch (InventoryNormal[boxSelected].Id) {
				case (ushort)Items.Banana:
					barEat.Value -=10f;
					barWater.Value -=1f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Olive:
					barEat.Value -=2f;
					barWater.Value -=0.1f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Toadstool:
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					Die(Lang.Texts[166]);
					break;

				case (ushort)Items.Boletus:
					barEat.Value -=1.5f;
					barWater.Value -=0.1f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Champignon:
					barEat .Value-=1.5f;
					barWater.Value -=0.1f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Lemon:
					barEat.Value -=5f;
					barWater.Value -=3f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Orange:
					barEat.Value -=9f;
					barWater.Value -=3f;
					InventoryRemoveSelectedItem();
				 if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Cherry:
					barEat.Value -=2f;
					barWater.Value -=0.1f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics)  SoundEffects.Eat.Play();
					break;

				case (ushort)Items.BucketWater:
					barEat.Value -=0.01f;
					barWater.Value -=20f;
					DropItemToPos(new ItemNonInvBasic((ushort)Items.Bucket,1), PlayerXInt, PlayerYInt);
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics)  SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Dandelion:
					barEat.Value -=2f;
					barWater.Value -=0.01f;
					InventoryRemoveSelectedItem();
				   if (Global.HasSoundGraphics)  SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Plum:
					barEat.Value -=5f;
					barWater.Value -=0.05f;
					InventoryRemoveSelectedItem();
				  if (Global.HasSoundGraphics)   SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Rashberry:
					barEat.Value -=2f;
					barWater.Value -=0.3f;
					InventoryRemoveSelectedItem();
				  if (Global.HasSoundGraphics)   SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Apple:
					barEat.Value -=12f;
					barWater.Value--;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics)SoundEffects.Eat.Play();
					break;

				case (ushort)Items.RabbitMeatCooked:
					barEat.Value -=30f;
					barWater.Value -=2f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.RabbitMeat:
					barEat.Value -=10;
					barWater.Value -=1;
					if (FastRandom.Bool_20Percent()) {
						barHeart.Value +=5f;
						if (barHeart.Value>32f)barHeart.Value=32f;
					}
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Strawberry:
					barEat.Value -=3f;
					barWater.Value -=0.5f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.WheatSeeds:
					barEat.Value--;
					barWater.Value -=0.002f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.Blueberries:
					barEat.Value-=2f;
					barWater.Value -=0.2f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.boiledEgg:
					barEat.Value-=2f;
					barWater.Value -=0.2f;
					InventoryRemoveSelectedItem();
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.BowlWithMushrooms:
					barEat.Value-=15f;
					barWater.Value -=5f;
					InventoryRemoveSelectedItem();
					AddItemToPlayer(new ItemNonInvBasic((ushort)Items.BowlEmpty,1));
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;

				case (ushort)Items.BowlWithVegetables:
					barEat.Value-=15;
					barWater.Value -=5f;
					InventoryRemoveSelectedItem();
					AddItemToPlayer(new ItemNonInvBasic((ushort)Items.BowlEmpty,1));
					if (Global.HasSoundGraphics) SoundEffects.Eat.Play();
					break;
				}
			}

			//drink
			if (barWater.Value>1f) {
				switch (InventoryNormal[boxSelected].Id) {
					case (ushort)Items.BottleWater:
						{
							ItemInvTool32 bottle=(ItemInvTool32)InventoryNormal[boxSelected];
							float d=barWater.Value-bottle.GetCount/3f;
							if (d<0) {
								barWater.Value=0f;
								InventoryNormal[boxSelected]=new ItemInvBasic32(bottleEmptyTexture,(ushort)Items.Bottle,1,(int)bottle.posTex.X,(int)bottle.posTex.Y);
							}else{
								bottle.SetCount=bottle.GetCount-(int)(barWater.Value*3);
								barWater.Value=d;
							}
						}
						break;

					case (ushort)Items.BucketWater:
						{
							ItemInvTool32 bottle=(ItemInvTool32)InventoryNormal[boxSelected];
							float d=barWater.Value-bottle.GetCount/3f;
							if (d<0) {
								barWater.Value=0f;
								InventoryNormal[boxSelected]=new ItemInvBasic32(ItemBucketTexture,(ushort)Items.Bucket,1,(int)bottle.posTex.X,(int)bottle.posTex.Y);
							}else{
								bottle.SetCount=bottle.GetCount-(int)(barWater.Value*3);
								barWater.Value=d;
							}
						}
						break;
				}
			}

			if (barEat.Value>32)barEat.Value=32f;
			if (barWater.Value>32)barWater.Value=32f;
			if (barEat.Value<0)barEat.Value=0f;
			if (barWater.Value<0)barWater.Value=0f;
		}

		#region Crafting basic
		void SetInvCraftingBlocks() {
			ushort[] items={
				(ushort)Items.Gravel,
				(ushort)Items.HayBlock,
			};
			inventoryScrollbarValueCraftingMax=items.Length-1;
			inventoryScrollbarValueCrafting=0;
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
			inventoryScrollbarValueCrafting=0;
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
			inventoryScrollbarValueCrafting=0;
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
			inventoryScrollbarValueCrafting=0;
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
			inventoryScrollbarValueCrafting=0;
			for (int i=0; i<items.Length; i++) SetItemCrafting(InventoryCrafting, i, items[i]);
			for (int j = items.Length; j<InventoryCrafting.Length; j++) InventoryCrafting[j]=itemBlank;
			ReSetCraftingInventoryPositions();
		}
        #endregion

        #region Crafting adv
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
				(ushort)Items.PickaxeBronze,
				(ushort)Items.AxeBronze,
				(ushort)Items.ShovelBronze,
				(ushort)Items.HoeBronze,
				(ushort)Items.KnifeBronze,
				(ushort)Items.ShearsBronze,
				(ushort)Items.SawBronze,
				(ushort)Items.HammerBronze,

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
        #endregion

        #region Creative
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
				(ushort)Items.SpruceLeavesWithSnow,
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
				(ushort)Items.PlantBlueberry,
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
        #endregion

        #region Bake
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
        #endregion

        #region toDust
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
        #endregion

        #region sewing
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
        #endregion

        Texture2D ItemIdToTexture(ushort id) {
            return id switch{
				 (ushort)Items.ChristmasBallGray => TextureChristmasBall,
				 (ushort)Items.ChristmasBallYellow => TextureChristmasBallYellow,
				 (ushort)Items.ChristmasBallOrange => TextureChristmasBallOrange,
				 (ushort)Items.ChristmasBallRed => TextureChristmasBallRed,
				 (ushort)Items.ChristmasBallPurple => TextureChristmasBallPurple,
				 (ushort)Items.ChristmasBallPink => TextureChristmasBallPink,
				 (ushort)Items.ChristmasBallLightGreen => TextureChristmasBallLightGreen,
				 (ushort)Items.ChristmasBallBlue => TextureChristmasBallBlue,
				 (ushort)Items.ChristmasBallTeal => TextureChristmasBallTeal,
				 (ushort)Items.AngelHair => TextureAngelHair,

				 (ushort)Items.ChristmasStar => TextureChristmasStar,
				 (ushort)Items.AirTank => TextureAirTank,
				 (ushort)Items.AirTank2 => TextureAirTank2,
				 (ushort)Items.OxygenMachine => TextureOxygenMachine,
				 (ushort)Items.BackSulfur => TextureBackSulfurOre,
				 (ushort)Items.BackSaltpeter => TextureBackSaltpeterOre,
				 (ushort)Items.Ammo => TextureAmmo,
				 (ushort)Items.Gun => TextureGun,
				 (ushort)Items.Saltpeter => TextureSaltpeter,
				 (ushort)Items.SulfurDust => TextureSulfur,
				 (ushort)Items.OreSaltpeter => TextureOreSaltpeter,
				 (ushort)Items.OreSulfur => TextureOreSulfur,
				 (ushort)Items.Gunpowder => TextureGunpowder,

				 (ushort)Items.BucketForRubber => TextureBucketForRubber,
				 (ushort)Items.Resin =>  TextureResin,
				 (ushort)Items.Aluminium => ItemAluminiumTexture,
				 (ushort)Items.TorchOFF => TextureTorchOff,
				 //(ushort)Items.BronzeHeadHoe => TextureHoeHeadBronze,
				 //(ushort)Items.CopperHeadHoe => TextureHoeHeadCopper,
				 (ushort)Items.HoeHeadIron => TextureHoeHeadIron,
				 (ushort)Items.HoeCopper => TextureHoeCopper,

				(ushort)Items.Mobile => mobileTexture,
				(ushort)Items.SewingMachine => sewingMachineTexture,
				(ushort)Items.BucketOil => bucketOilTexture,
				(ushort)Items.TorchON => torchInvTexture,

				(ushort)Items.BottleOil => bottleOilTexture,
				(ushort)Items.BoxAdv => boxAdvTexture,
				(ushort)Items.BoxWooden => boxWoodenTexture,
				(ushort)Items.Shelf => shelfTexture,
				(ushort)Items.Heater => heatherTexture,
				(ushort)Items.WoodDust => ItemWoodDustTexture,
				(ushort)Items.AluminiumDust => ItemAluminiumDustTexture,
				(ushort)Items.FlaxSeeds => flaxSeedsTexture,
				(ushort)Items.MudIngot => oneMudBrickTexture,
				(ushort)Items.AluminiumIngot => ItemAluminiumIngotTexture,
				(ushort)Items.Nail => nailTexture,
				(ushort)Items.Silicium => siliciumTexture,
				(ushort)Items.StoneBasalt => basaltTexture,
				(ushort)Items.StoneLimestone => limestoneTexture,
				(ushort)Items.StoneRhyolite => rhyoliteTexture,
				(ushort)Items.StoneGneiss => gneissTexture,
				(ushort)Items.StoneSandstone => sandstoneTexture,
				(ushort)Items.StoneSchist => schistTexture,
				(ushort)Items.StoneGabbro => gabbroTexture,
				(ushort)Items.StoneDiorit => dioritTexture,
				(ushort)Items.StoneDolomite => dolomiteTexture,
				(ushort)Items.Flax => flaxInvTexture,
				(ushort)Items.Dirt => TextureDirt,
				(ushort)Items.Sand => sandTexture,
				(ushort)Items.Lava => lavaTexture,
				(ushort)Items.Stonerubble => cobblestoneTexture,
				(ushort)Items.Gravel => gravelTexture,

				(ushort)Items.WoodOak => TextureOakWood,
				(ushort)Items.WoodSpruce => spruceWoodTexture,
				(ushort)Items.WoodLinden => TextureLindenWood,
				(ushort)Items.WoodPine => pineWoodTexture,
				(ushort)Items.WoodApple => TextureAppleWood,
				(ushort)Items.WoodCherry => cherryWoodTexture,
				(ushort)Items.WoodPlum => TexturePlumWood,
				(ushort)Items.WoodLemon => TextureLemonWood,
				(ushort)Items.WoodOrange => TextureOrangeWood,

				(ushort)Items.OakLeaves => TextureOakLeaves,

				(ushort)Items.GrassBlockDesert => TextureGrassBlockDesert,
				(ushort)Items.GrassBlockForest => TextureGrassBlockForest,
				(ushort)Items.GrassBlockHills => TextureGrassBlockHills,
				(ushort)Items.GrassBlockJungle => TextureGrassBlockJungle,
				(ushort)Items.GrassBlockPlains => TextureGrassBlockPlains,
				(ushort)Items.GrassBlockCompost => TextureGrassBlockCompost,

				//Crafted
				(ushort)Items.Glass => glassTexture,
				(ushort)Items.Bricks => bricksTexture,

				(ushort)Items.Planks => planksTexture,

				(ushort)Items.Desk => deskTexture,
				(ushort)Items.Door => ItemDoorTexture,
				(ushort)Items.Ladder => ladderTexture,
				(ushort)Items.Flag => ItemFlagTexture,

				(ushort)Items.Rope => ItemRopeTexture,

				(ushort)Items.HayBlock => hayBlockTexture,

				(ushort)Items.Roof1 => roof1Texture,
				(ushort)Items.Roof2 => roof2Texture,

				//Mashines
				(ushort)Items.AdvancedSpaceBack => advancedSpaceBackTexture,
				(ushort)Items.AdvancedSpaceWindow => advancedSpaceWindowTexture,
				(ushort)Items.AdvancedSpaceBlock => advancedSpaceBlockTexture,
				(ushort)Items.AdvancedSpaceFloor => advancedSpaceFloorTexture,
				(ushort)Items.AdvancedSpacePart1 => advancedSpacePart1Texture,
				(ushort)Items.AdvancedSpacePart2 => advancedSpacePart2Texture,
				(ushort)Items.AdvancedSpacePart3 => advancedSpacePart3Texture,
				(ushort)Items.AdvancedSpacePart4 => advancedSpacePart4Texture,

				(ushort)Items.WindMill => ItemWindMillTexture,
				(ushort)Items.WaterMill => ItemWaterMillTexture,
				(ushort)Items.SolarPanel => solarPanelTexture,

				(ushort)Items.Miner => minerTexture,
				(ushort)Items.Macerator => maceratorOneTexture,
				(ushort)Items.Lamp => lampTexture,
				(ushort)Items.Radio => radioInvTexture,
				(ushort)Items.Label => labelOneTexture,
				(ushort)Items.Rocket => ItemRocketTexture,
				(ushort)Items.FurnaceElectric => furnaceElectricOneTexture,
				(ushort)Items.FurnaceStone => furnaceStoneOneTexture,
				(ushort)Items.Barrel => TextureBarrel,

				//Food
				(ushort)Items.Banana => ItemBananaTexture,
				(ushort)Items.Cherry => ItemCherryTexture,
				(ushort)Items.Lemon => ItemLemonTexture,
				(ushort)Items.Orange => ItemOrangeTexture,
				(ushort)Items.Plum => ItemPlumTexture,
				(ushort)Items.Apple => ItemAppleTexture,
				(ushort)Items.Rashberry => rashberryTexture,
				(ushort)Items.Strawberry => strawberryTexture,
				(ushort)Items.Blueberries => blueberryTexture,

				(ushort)Items.RabbitMeatCooked => ItemRabbtCookedMeatTexture,
				(ushort)Items.RabbitMeat => ItemRabbitMeatTexture,

				(ushort)Items.AnimalFish => fishTexture0,
				(ushort)Items.FishMeatCooked => fishCookedTexture,

				(ushort)Items.Egg => TextureItemEgg,
				(ushort)Items.boiledEgg => TextureItemBoiledEgg,

				//Clothes
				(ushort)Items.Backpack => ItemBackpackTexture,

				//Items
				(ushort)Items.CoalDust => ItemCoalDustTexture,
				(ushort)Items.BronzeDust => ItemBronzeDustTexture,
				(ushort)Items.GoldDust => ItemGoldDustTexture,
				(ushort)Items.IronDust => ItemIronDustTexture,
				(ushort)Items.SilverDust => ItemSilverDustTexture,
				(ushort)Items.CopperDust => ItemCopperDustTexture,
				(ushort)Items.TinDust => ItemTinDustTexture,

				(ushort)Items.BronzeIngot => ItemBronzeIngotTexture,
				(ushort)Items.SteelIngot => TextureIngotSteel,
				(ushort)Items.GoldIngot => ItemGoldIngotTexture,
				(ushort)Items.IronIngot => ItemIronIngotTexture,
				(ushort)Items.TinIngot => ItemTinIngotTexture,
				(ushort)Items.SilverIngot => ItemSilverIngotTexture,
				(ushort)Items.CopperIngot => ItemCopperIngotTexture,

				(ushort)Items.PlateIron => plateIronTexture,
				(ushort)Items.PlateBronze => plateBronzeTexture,
				(ushort)Items.plateAluminium => plateAluminiumTexture,
				(ushort)Items.PlateCopper => plateCopperTexture,
				(ushort)Items.PlateGold => plateGoldTexture,

				(ushort)Items.OreCoal => TextureOreCoal,
				(ushort)Items.ItemCoal => ItemCoalTexture,
				(ushort)Items.ItemGold => ItemGoldTexture,
				(ushort)Items.ItemTin => ItemTinTexture,
				(ushort)Items.ItemSilver => ItemSilverTexture,
				(ushort)Items.ItemIron => ItemIronTexture,
				(ushort)Items.ItemCopper => ItemCopperTexture,
				(ushort)Items.Ash => ashTexture,
				(ushort)Items.CoalWood => coalWoodTexture,

				(ushort)Items.Saphirite => ItemSaphiriteTexture,
				(ushort)Items.Diamond => ItemDiamondTexture,
				(ushort)Items.Smaragd => ItemSmaragdTexture,
				(ushort)Items.Ruby => ItemRubyTexture,
				(ushort)Items.SmallStone => ItemSmallStoneTexture,
				(ushort)Items.BigStone => ItemBigStoneTexture,
				(ushort)Items.MediumStone => ItemMediumStoneTexture,

				(ushort)Items.Bulb => ItemBulbTexture,
				(ushort)Items.Circuit => ItemCircuitTexture,
				(ushort)Items.ItemBattery => ItemBatteryTexture,
				(ushort)Items.BigCircuit => ItemBigCircuitTexture,
				(ushort)Items.OneBrick => oneBrickTexture,

				(ushort)Items.Cloth => clothTexture,
				(ushort)Items.Yarn => yarnTexture,

				(ushort)Items.Condenser => condenserTexture,
				(ushort)Items.Diode => diodeTexture,
				(ushort)Items.Tranzistor => tranzistorTexture,
				(ushort)Items.Rezistance => resistanceTexture,
				(ushort)Items.Motor => motorTexture,
				(ushort)Items.BareLabel => bareLabelTexture,

				//Plants
				(ushort)Items.OakSapling => oakSaplingTexture,
				(ushort)Items.LindenSapling => TextureLindenSapling,
				(ushort)Items.PineSapling => pineSaplingTexture,
				(ushort)Items.AppleSapling => TextureAppleSapling,
				(ushort)Items.LemonSapling => lemonSaplingTexture,
				(ushort)Items.CherrySapling => cherrySaplingTexture,
				(ushort)Items.PlumSapling => plumSaplingTexture,
				(ushort)Items.SpruceSapling => spruceSaplingTexture,
				(ushort)Items.OrangeSapling => orangeSaplingTexture,

				(ushort)Items.Dandelion => plantDandelionTexture,
				(ushort)Items.PlantRose => plantRoseTexture,
				(ushort)Items.PlantOrchid => plantOrchidTexture,
				(ushort)Items.PlantViolet => plantVioletTexture,

				(ushort)Items.PlantStrawberry => invStrawberryTexture,
				(ushort)Items.PlantRashberry => invRashberryTexture,
				(ushort)Items.PlantBlueberry => invBlueberryTexture,

				(ushort)Items.CactusBig => cactusBigTexture,
				(ushort)Items.CactusSmall => cactusLittleTexture,

				(ushort)Items.SugarCane => sugarCaneTexture,
				(ushort)Items.Onion => ItemOnionTexture,

				(ushort)Items.Toadstool => toadstoolTexture,
				(ushort)Items.Boletus => boletusTexture,
				(ushort)Items.Champignon => champignonTexture,

				(ushort)Items.Coral => coralTexture,
				(ushort)Items.Seaweed => seaweedTexture,
				(ushort)Items.PlantSeaweed => seaweedTexture,
				(ushort)Items.PlantOnion => plantOnionTexture,

				//Nature
				(ushort)Items.WheatSeeds => ItemWheatSeedsTexture,
				(ushort)Items.Seeds => ItemSeedsTexture,

				(ushort)Items.WheatStraw => ItemWheatStrawTexture,
				(ushort)Items.Hay => ItemHayTexture,

				(ushort)Items.Leave => ItemLeaveTexture,
				(ushort)Items.Stick => ItemStickTexture,
				(ushort)Items.Sticks => ItemSticksTexture,
				(ushort)Items.Rubber => ItemRubberTexture,

				//Tools
				(ushort)Items.Bucket => ItemBucketTexture,
				(ushort)Items.BucketWater => ItemBucketWaterTexture,

				(ushort)Items.StoneHead => stoneHeadTexture,

				//(ushort)Items.AxeHeadIron => TextureHeadAxeIron,
				//(ushort)Items.ShovelHeadIron => TextureHeadShovelIron,
				//(ushort)Items.PickaxeHeadIron => TextureHeadPickaxeIron,

				//Shovel
				(ushort)Items.ShovelStone => TextureShovelStone,
				(ushort)Items.ShovelCopper => TextureShovelCopper,
				(ushort)Items.ShovelBronze => TextureShovelBronze,
				(ushort)Items.ShovelGold => TextureShovelGold,
				(ushort)Items.ShovelIron => TextureShovelIron,
				(ushort)Items.ShovelSteel => TextureShovelSteel,
				(ushort)Items.ShovelAluminium => TextureShovelAluminium,

				// Pickaxe
				(ushort)Items.PickaxeStone => TexturePickaxeStone,
				(ushort)Items.PickaxeCopper => TexturePickaxeCopper,
				(ushort)Items.PickaxeBronze => TexturePickaxeBronze,
				(ushort)Items.PickaxeGold => TexturePickaxeGold,
				(ushort)Items.PickaxeIron => TexturePickaxeIron,
				(ushort)Items.PickaxeSteel => TexturePickaxeSteel,
				(ushort)Items.PickaxeAluminium => TexturePickaxeAluminium,

				// Axe
				(ushort)Items.AxeStone => TextureAxeStone,
				(ushort)Items.AxeCopper => TextureAxeCopper,
				(ushort)Items.AxeBronze => TextureAxeBronze,
				(ushort)Items.AxeGold => TextureAxeGold,
				(ushort)Items.AxeIron => TextureAxeIron,
				(ushort)Items.AxeSteel => TextureAxeSteel,
				(ushort)Items.AxeAluminium => TextureAxeAluminium,

				// Hammers
				(ushort)Items.HammerCopper => TextureHammerCopper,
				(ushort)Items.HammerBronze => TextureHammerBronze,
				(ushort)Items.HammerIron => TextureHammerIron,
				(ushort)Items.HammerGold => TextureHammerGold,
				(ushort)Items.HammerSteel => TextureHammerSteel,
				(ushort)Items.HammerAluminium => TextureHammerAluminium,

				// Shears
				(ushort)Items.ShearsCopper => TextureShearsCopper,
				(ushort)Items.ShearsBronze => TextureShearsBronze,
				(ushort)Items.ShearsGold => TextureShearsGold,
				(ushort)Items.ShearsIron => TextureShearsIron,
				(ushort)Items.ShearsSteel => TextureShearsSteel,
				(ushort)Items.ShearsAluminium => TextureShearsAluminium,

				// Saw
				(ushort)Items.SawCopper => TextureSawCopper,
				(ushort)Items.SawBronze => TextureSawBronze,
				(ushort)Items.SawGold => TextureSawGold,
				(ushort)Items.SawIron => TextureSawIron,
				(ushort)Items.SawSteel => TextureSawSteel,
				(ushort)Items.SawAluminium => TextureSawAluminium,

				(ushort)Items.ElectricDrill => TextureDrillElectric,
				(ushort)Items.ElectricSaw => electricSawTexture,

				(ushort)Items.OreAluminium => TextureOreAluminium,
				(ushort)Items.OreCopper => TextureOreCopper,
				(ushort)Items.OreGold => TextureOreGold,
				(ushort)Items.OreIron => TextureOreIron,
				(ushort)Items.OreSilver => TextureOreSilver,
				(ushort)Items.OreTin => TextureOreTin,

				(ushort)Items.AppleLeaves => TextureAppleLeaves,
				(ushort)Items.AppleLeavesWithApples => TextureAppleLeavesWithApples,
				(ushort)Items.OrangeLeaves => TextureOrangeLeaves,
				(ushort)Items.OrangeLeavesWithOranges => TextureOrangeLeavesWithOranges,
				(ushort)Items.PlumLeaves => TexturePlumLeaves,
				(ushort)Items.PlumLeavesWithPlums => TexturePlumLeavesWithPlums,
				(ushort)Items.CherryLeaves => TextureCherryLeaves,
				(ushort)Items.CherryLeavesWithCherries => TextureCherryLeavesWithCherries,
				(ushort)Items.LemonLeaves => TextureLemonLeaves,
				(ushort)Items.LemonLeavesWithLemons => lemonLeavesWithLemonsTexture,
				(ushort)Items.LindenLeaves => TextureLindenLeaves,
				(ushort)Items.SpruceLeaves => spruceLeavesTexture,
				(ushort)Items.SpruceLeavesWithSnow => spruceLeavesWithSnowTexture,
				(ushort)Items.PineLeaves => pineLeavesTexture,

				(ushort)Items.Snow => snowTexture,
				(ushort)Items.SnowTop => snowTopTexture,
				(ushort)Items.Ice => iceTexture,

				(ushort)Items.GrassDesert => grassDesertTexture,
				(ushort)Items.GrassForest => grassForestTexture,
				(ushort)Items.GrassHills => grassHillsTexture,
				(ushort)Items.GrassJungle => grassJungleTexture,
				(ushort)Items.GrassPlains => grassPlainsTexture,

				(ushort)Items.Alore => plantAloreTexture,
				(ushort)Items.Plastic => ItemPlasticTexture,

				(ushort)Items.Carrot => ItemCarrotTexture,
				(ushort)Items.PlantCarrot => plantCarrotTexture,
				(ushort)Items.Peas => ItemPeasTexture,
				(ushort)Items.PlantPeas => plantPeasTexture,

				(ushort)Items.Battery => ItemBatteryTexture,

				(ushort)Items.BottleWater => bottleWaterTexture,
				(ushort)Items.Bottle => bottleEmptyTexture,
				(ushort)Items.BowlEmpty => bowlEmptyTexture,
				(ushort)Items.BowlWithMushrooms => bowlMushroomsTexture,
				(ushort)Items.BowlWithVegetables => bowlVegetablesTexture,

				(ushort)Items.ElectricDrillOff => TextureDrillElectric,
				(ushort)Items.ElectricSawOff => electricSawTexture,

				(ushort)Items.HoeStone => TextureHoeStone,
				(ushort)Items.HoeBronze => TextureHoeBronze,
				(ushort)Items.HoeIron => TextureHoeIron,

				(ushort)Items.Charger => chargerTexture,

				(ushort)Items.Clay => clayTexture,
				(ushort)Items.GrassBlockClay => TextureGrassBlockClay,
				(ushort)Items.BackDirt => backgroundDirtTexture,
				(ushort)Items.BackSand => backgroundSandTexture,
				(ushort)Items.BackClay => backgroundClayTexture,
				(ushort)Items.BackCobblestone => backgroundCobblestoneTexture,
				(ushort)Items.BackGravel => backgroundGravelTexture,
				(ushort)Items.BackRedSand => backgroundRedSandTexture,
				(ushort)Items.BackRegolite => backgroundRegoliteTexture,

				(ushort)Items.BackCoal => backgroundCoalTexture,
				(ushort)Items.BackAluminium => backgroundAluminiumTexture,
				(ushort)Items.BackCopper => backgroundCopperTexture,
				(ushort)Items.BackGold => backgroundGoldTexture,
				(ushort)Items.BackIron => backgroundIronTexture,
				(ushort)Items.BackTin => backgroundTinTexture,
				(ushort)Items.BackSilver => backgroundSilverTexture,


				(ushort)Items.BackAnorthosite => backgroundAnorthositeTexture,
				(ushort)Items.BackBasalt => backgroundBasaltTexture,
				(ushort)Items.BackDiorit => backgroundDioritTexture,
				(ushort)Items.BackDolomite => backgroundDolomiteTexture,
				(ushort)Items.BackFlint => backgroundFlintTexture,
				(ushort)Items.BackGabbro => backgroundGabbroTexture,
				(ushort)Items.BackGneiss => backgroundGneissTexture,
				(ushort)Items.BackLimestone => backgroundLimestoneTexture,
				(ushort)Items.BackMudstone => backgroundMudstoneTexture,
				(ushort)Items.BackSandstone => backgroundSandstoneTexture,
				(ushort)Items.BackSchist => backgroundSchistTexture,
				(ushort)Items.BackRhyolite => backgroundRhyoliteTexture,

				(ushort)Items.StoneFlint => flintTexture,
				(ushort)Items.StoneMudstone => mudstoneTexture,
				(ushort)Items.StoneAnorthosite => anorthositeTexture,
				(ushort)Items.AnimalRabbit => rabbitStillTexture,
				(ushort)Items.AnimalParrot => TextureParrotStill,
				(ushort)Items.AnimalChicken => chickenStillTexture,
				(ushort)Items.Rod => RodTexture,
				(ushort)Items.TorchElectricOFF => LightElectricTexture,
				(ushort)Items.TorchElectricON => LightElectricTexture,
				(ushort)Items.Compost => CompostTexture,
				(ushort)Items.Composter => ComposterTexture,

				(ushort)Items.FormalShoes => TextureItemFormalShoes,
				(ushort)Items.Pumps => TextureItemPumps,
				(ushort)Items.Sneakers => TextureItemSneakers,
				(ushort)Items.SpaceBoots => TextureItemSpaceBoots,

				(ushort)Items.Jeans => TextureItemJeans,
				(ushort)Items.Shorts => TextureItemShorts,
				(ushort)Items.SpaceTrousers => TextureItemSpaceTrousers,
				(ushort)Items.ArmyTrousers => TextureItemArmyTrousers,
				(ushort)Items.Skirt => TextureItemSkirt,

				(ushort)Items.TShirt => TextureItemTShirt,
				(ushort)Items.SpaceSuit => TextureItemSpaceSuit,
				(ushort)Items.Dress => TextureItemDress,
				(ushort)Items.Shirt => TextureItemShirt,

				(ushort)Items.Cap => TextureItemCap,
				(ushort)Items.Hat => TextureItemHat,
				(ushort)Items.Crown => TextureItemCrown,
				(ushort)Items.SpaceHelmet => TextureItemSpaceHelmet,

				(ushort)Items.Underpants => TextureItemUnderpants,
				(ushort)Items.BoxerShorts => TextureItemBoxerShorts,
				(ushort)Items.Panties => TextureItemPanties,
				(ushort)Items.Swimsuit => TextureItemSwimsuit,
				(ushort)Items.BikiniDown => TextureItemBikiniDown,

				(ushort)Items.Bra => TextureItemBra,
				(ushort)Items.BikiniTop => TextureItemBikiniTop,

				(ushort)Items.CoatArmy => TextureItemCoatArmy,
				(ushort)Items.Coat => TextureItemCoat,
				(ushort)Items.JacketDenim => ItemJacketDenimTexture,
				(ushort)Items.JacketFormal => ItemJacketFormalTexture,
				(ushort)Items.JacketShort => TextureItemJacketShort,

				(ushort)Items.AcaciaLeaves => TextureAcaciaLeaves,
				(ushort)Items.AcaciaWood => TextureAcaciaWood,
				(ushort)Items.AcaciaSapling => TextureAcaciaSapling,
				(ushort)Items.MangroveLeaves => TextureMangroveLeaves,
				(ushort)Items.MangroveWood => TextureMangroveWood,
				(ushort)Items.MangroveSapling => TextureMangroveSapling,
				(ushort)Items.WillowLeaves => TextureWillowLeaves,
				(ushort)Items.WillowWood => TextureWillowWood,
				(ushort)Items.WillowSapling => TextureWillowSapling,
				(ushort)Items.Olive => ItemOliveTexture,
				(ushort)Items.OliveLeaves => TextureOliveLeaves,
				(ushort)Items.OliveLeavesWithOlives => TextureOliveLeavesWithOlives,
				(ushort)Items.OliveWood => TextureOliveWood,
				(ushort)Items.OliveSapling => TextureOliveSapling,
				(ushort)Items.EucalyptusLeaves => TextureEucalyptusLeaves,
				(ushort)Items.EucalyptusSapling => TextureEucalyptusSapling,
				(ushort)Items.EucalyptusWood => TextureEucalyptusWood,
				(ushort)Items.RubberTreeLeaves => TextureRubberTreeLeaves,
				(ushort)Items.RubberTreeSapling => TextureRubberTreeSapling,
				(ushort)Items.RubberTreeWood => TextureRubberTreeWood,
				(ushort)Items.KapokLeaves => TextureKapokLeaves,
				(ushort)Items.KapokLeavesFibre => TextureKapokLeavesFibre,
				(ushort)Items.KapokLeacesFlowering => TextureKapokBlossom,
				(ushort)Items.KapokSapling => TextureKapokSapling,
				(ushort)Items.KapokWood => TextureKapokWood,
				(ushort)Items.KapokFibre => ItemKapokFibreTexture,
				(ushort)Items.KnifeCopper => TextureKnifeCopper,
				(ushort)Items.KnifeBronze => TextureKnifeBronze,
				(ushort)Items.KnifeGold => TextureKnifeGold,
				(ushort)Items.KnifeIron => TextureKnifeIron,
				(ushort)Items.KnifeSteel => TextureKnifeSteel,
				(ushort)Items.KnifeAluminium => TextureKnifeAluminium,

				(ushort)Items.HoeGold => TextureHoeGold,
				(ushort)Items.HoeSteel => TextureHoeSteel,
				(ushort)Items.HoeAluminium => TextureHoeAluminium,
				(ushort)Items.DyeGold => TextureDyeGold,
				(ushort)Items.DyeWhite => TextureDyeWhite,
				(ushort)Items.DyeYellow => TextureDyeYellow,
				(ushort)Items.DyeOrange => TextureDyeOrange,
				(ushort)Items.DyeRed => TextureDyeRed,
				(ushort)Items.DyeDarkRed => TextureDyeDarkRed,
				(ushort)Items.DyeOlive => TextureDyeOlive,
				(ushort)Items.DyePurple => TextureDyePurple,
				(ushort)Items.DyePink => TextureDyePink,
				(ushort)Items.DyeTeal => TextureDyeTeal,
				(ushort)Items.DyeLightBlue => TextureDyeLightBlue,
				(ushort)Items.DyeBlue => TextureDyeBlue,
				(ushort)Items.DyeMagenta => TextureDyeMagenta,
				(ushort)Items.DyeDarkBlue => TextureDyeDarkBlue,
				(ushort)Items.DyeBlack => TextureDyeBlack,
				(ushort)Items.DyeBrown => TextureDyeBrown,
				(ushort)Items.DyeLightGray => TextureDyeLightGray,
				(ushort)Items.DyeGray => TextureDyeGray,
				(ushort)Items.DyeDarkGray => TextureDyeDarkGray,
				(ushort)Items.DyeViolet => TextureDyeViolet,
				(ushort)Items.DyeSpringGreen => TextureDyeSpringGreen,
				(ushort)Items.DyeRoseQuartz => TextureDyeRoseQuartz,
				(ushort)Items.TestTube => TextureTestTube,
				(ushort)Items.DyeLightGreen => TextureDyeLightGreen,
				(ushort)Items.DyeGreen => TextureDyeGreen,
				(ushort)Items.DyeArmy => TextureDyeArmy,
				(ushort)Items.DyeDarkGreen => TextureDyeDarkGreen,

					 //Shovel
				(ushort)Items.ShovelHeadCopper => TextureShovelHeadCopper,
				(ushort)Items.ShovelHeadBronze => TextureShovelHeadBronze,
				(ushort)Items.ShovelHeadGold => TextureShovelHeadGold,
				(ushort)Items.ShovelHeadIron => TextureShovelHeadIron,
				(ushort)Items.ShovelHeadSteel => TextureShovelHeadSteel,
				(ushort)Items.ShovelHeadAluminium => TextureShovelHeadAluminium,

				// Pickaxe
				(ushort)Items.PickaxeHeadCopper => TexturePickaxeHeadCopper,
				(ushort)Items.PickaxeHeadBronze => TexturePickaxeHeadBronze,
				(ushort)Items.PickaxeHeadGold => TexturePickaxeHeadGold,
				(ushort)Items.PickaxeHeadIron => TexturePickaxeHeadIron,
				(ushort)Items.PickaxeHeadSteel => TexturePickaxeHeadSteel,
				(ushort)Items.PickaxeHeadAluminium => TexturePickaxeHeadAluminium,

				// Axe
				(ushort)Items.AxeHeadCopper => TextureAxeHeadCopper,
				(ushort)Items.AxeHeadBronze => TextureAxeHeadBronze,
				(ushort)Items.AxeHeadGold => TextureAxeHeadGold,
				(ushort)Items.AxeHeadIron => TextureAxeHeadIron,
				(ushort)Items.AxeHeadSteel => TextureAxeHeadSteel,
				(ushort)Items.AxeHeadAluminium => TextureAxeHeadAluminium,

				// Shears
				(ushort)Items.ShearsHeadCopper => TextureShearsHeadCopper,
				(ushort)Items.ShearsHeadBronze => TextureShearsHeadBronze,
				(ushort)Items.ShearsHeadGold => TextureShearsHeadGold,
				(ushort)Items.ShearsHeadIron => TextureShearsHeadIron,
				(ushort)Items.ShearsHeadSteel => TextureShearsHeadSteel,
				(ushort)Items.ShearsHeadAluminium => TextureShearsHeadAluminium,

				(ushort)Items.KnifeHeadCopper => TextureKnifeHeadCopper,
				(ushort)Items.KnifeHeadBronze => TextureKnifeHeadBronze,
				(ushort)Items.KnifeHeadGold => TextureKnifeHeadGold,
				(ushort)Items.KnifeHeadIron => TextureKnifeHeadIron,
				(ushort)Items.KnifeHeadSteel => TextureKnifeHeadSteel,
				(ushort)Items.KnifeHeadAluminium => TextureKnifeHeadAluminium,

				(ushort)Items.HoeHeadCopper => TextureHoeHeadCopper,
				(ushort)Items.HoeHeadBronze => TextureHoeHeadBronze,
				(ushort)Items.HoeHeadGold => TextureHoeHeadGold,
				//(ushort)Items.HoeHeadIron => TextureHoeHeadIron,
				(ushort)Items.HoeHeadSteel => TextureHoeHeadSteel,
				(ushort)Items.HoeHeadAluminium => TextureHoeHeadAluminium,

				(ushort)Items.RedSand => TextureRedSand,
				(ushort)Items.FishMeat => fishTexture0,

				_=>
					#if DEBUG
					throw new Exception("Missing texture for item "+(Items)id),
					#else
					null,
					#endif
			};
		}

		void MobileON() => ( mobileOS=new Mobile.System { Content=Rabcr.content } ).Init();

		#region Jobs
		//void ChargerJob(ShortAndByte ch) {
		//	 MashineBlockBasic charger=(MashineBlockBasic)terrain[ch.X].TopBlocks[ch.Y];
		//	if (charger.Inv[0].Id!=0) {
		//		if (charger.Energy>5) {
		//			switch (charger.Inv[0].Id) {
		//				case (ushort)Items.ElectricDrillOff:
		//					{
		//						ItemInvTool32 tool =(ItemInvTool32)charger.Inv[0];
		//						if (tool.GetCount==1) {
		//							charger.Inv[0]=new ItemInvTool32(
		//								ItemIdToTexture((ushort)Items.ElectricDrill),
		//								(ushort)Items.ElectricDrill,
		//								1,
		//								GameMethods.ToolMax((ushort)Items.ElectricDrill),
		//								(int)tool.posTex.X,
		//								(int)tool.posTex.Y
		//								);
		//						} else {
		//							if (tool.GetCount<99) {
		//								tool.SetCount=tool.GetCount+1;
		//							}
		//						}
		//					}
		//					return;

		//				case (ushort)Items.ElectricSawOff:
		//					{
		//						ItemInvTool32 tool =(ItemInvTool32)charger.Inv[0];
		//						if (tool.GetCount==1) {
		//							charger.Inv[0]=new ItemInvTool32(
		//								ItemIdToTexture((ushort)Items.ElectricSaw),
		//								(ushort)Items.ElectricSaw,
		//								1,
		//								GameMethods.ToolMax((ushort)Items.ElectricSaw),
		//								(int)tool.posTex.X,
		//								(int)tool.posTex.Y
		//								);
		//						} else {
		//							if (tool.GetCount<99) {
		//								tool.SetCount=tool.GetCount+1;
		//							}
		//						}
		//					}
		//					return;

		//				case (ushort)Items.TorchElectricOFF:
		//					{
		//						ItemInvTool32 tool =(ItemInvTool32)charger.Inv[0];
		//						if (tool.GetCount==1) {
		//							charger.Inv[0]=new ItemInvTool32(
		//								ItemIdToTexture((ushort)Items.TorchElectricON),
		//								(ushort)Items.TorchElectricON,
		//								1,
		//								GameMethods.ToolMax((ushort)Items.TorchElectricON),
		//								(int)tool.posTex.X,
		//								(int)tool.posTex.Y
		//							);
		//						} else {
		//							if (tool.GetCount<99) {
		//								tool.SetCount=tool.GetCount+1;
		//							}
		//						}
		//					}
		//					return;

		//				case (ushort)Items.AirTank:
		//					{
		//						if (notNeedScafander) {
		//							ItemInvTool32 tool =(ItemInvTool32)charger.Inv[0];
		//							if (tool.GetCount<99) {
		//								tool.SetCount=tool.GetCount+1;
		//							}
		//						}
		//					}
		//					return;

		//				case (ushort)Items.AirTank2:
		//					{
		//						if (notNeedScafander) {
		//							ItemInvTool32 tool =(ItemInvTool32)charger.Inv[0];
		//							if (tool.GetCount<99) {
		//								tool.SetCount=tool.GetCount+1;
		//							}
		//						}
		//					}
		//					return;
		//			}
		//		}
		//	}
		//}

		//void OxygenMachineJob(ShortAndByte ch) {
		//	MashineBlockBasic oxygenMachine=(MashineBlockBasic)terrain[ch.X].TopBlocks[ch.Y];
		//	if (dayAlpha>0.5f) {
		//		if (FastRandom.Bool_10Percent())oxygenMachine.AddEnergy();
		//	}

		//	if (oxygenMachine.Inv[0].Id!=0) {
		//		if (oxygenMachine.Energy>5) {
		//			switch (oxygenMachine.Inv[0].Id) {
		//				case (ushort)Items.AirTank:
		//					{
		//						ItemInvTool32 tool =(ItemInvTool32)oxygenMachine.Inv[0];
		//						if (tool.GetCount<99) {
		//							tool.SetCount=tool.GetCount+1;
		//						}
		//					}
		//					return;

		//				case (ushort)Items.AirTank2:
		//					{
		//						ItemInvTool32 tool =(ItemInvTool32)oxygenMachine.Inv[0];
		//						if (tool.GetCount<99) {
		//							tool.SetCount=tool.GetCount+1;
		//						}
		//					}
		//					return;
		//			}
		//		}
		//	}
		//}

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

		//void MinerJob(ShortAndByte ch) {
		//	MashineBlockBasic miner=(MashineBlockBasic)terrain[ch.X].TopBlocks[ch.Y];

		//	if (miner.Energy>5) {
		//		for (int i = 0; i<DroppedItems.Count; i++) {
		//			if (DroppedItems[i].X==ch.X*16) {
		//				Item item = DroppedItems[i];
		//				if (item.Y>ch.Y*16) {
		//					ItemNonInv remain = MinerAddItem(item.item, miner);
		//					if (remain==null) return;
		//					if (item!=null) {
		//						DropItemToPos(remain, item.X, item.Y);
		//					}
		//					DroppedItems.RemoveAt(i);
		//					return;
		//				}
		//			}
		//		}
		//		Terrain chunk=terrain[ch.X];
		//		for (int y=ch.Y+1; y<100; y++) {
		//			if (chunk.IsSolidBlocks[y]) {
		//				destroyBlockX=ch.X;
		//				destroyBlockY=y;
		//				GetItemsFromBlock(chunk.SolidBlocks[y].Id, ch.X, y);
		//				chunk.SolidBlocks[y]=null;
		//				chunk.IsSolidBlocks[y]=false;
		//				return;
		//			}
		//		}
		//	}
		//}

		//bool BucketsForRubberJob(ShortAndByte ch) {
		//  //  Block bucket=terrain[ch.X].TopBlocks[ch.Y];

		//	for (int y=ch.Y+1; y<100; y++) {
		//		if (terrain[ch.X].IsBackground[y]) {
		//			if (terrain[ch.X].Background[y].Id==(ushort)BlockId.RubberTreeWood) {
		//				if (FastRandom.Int(2000)==1) {
		//					RemovefromBucketsForRubber(ch.X,ch.Y);
		//					TerrainSetTopBlockNormal(ch.X,ch.Y,(ushort)BlockId.BucketWithLatex,TextureBucketWithLatex);
		//					return true;
		//				}
		//			}
		//		}
		//	}
		//	return false;
		//}
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

		#region Inventory positions
		static DInt InventoryGetPosClothes(int ix) {
			if (ix<4) return new DInt{ X=Global.WindowWidthHalf-300+4+60+4,    Y=Global.WindowHeightHalf-200+2+4+4+ix*40     };
			else      return new DInt{ X=Global.WindowWidthHalf-300+4+60+4+40, Y=Global.WindowHeightHalf-200+2+4+4+40*(ix-4) };
		}

		static DInt InventoryGetPosFurnaceStone(int ix) {
            return ix switch {
                0 => new DInt { X = Global.WindowWidthHalf - 300 + 4 + 1 + 40 + 4, Y = Global.WindowHeightHalf - 200 + 2 + 4 + 60 + 4 },
                1 => new DInt { X = Global.WindowWidthHalf - 300 + 4 + 1 + 40 + 40 + 4, Y = Global.WindowHeightHalf - 200 + 2 + 4 + 60 + 4 },
                2 => new DInt { X = Global.WindowWidthHalf - 300 + 4 + 1 + 40 * 2 + 40 + 4, Y = Global.WindowHeightHalf - 200 + 2 + 4 + 60 + 4 },
                3 => new DInt { X = Global.WindowWidthHalf - 300 + 4 + 1 + 40 + 40 + 4, Y = Global.WindowHeightHalf - 200 + 2 + 4 + 60 + 40 + 8 + 4 },
				#if DEBUG
                _ => throw new Exception("Unknown pos id of stone frurnace inv"),
				#else
				_ => new DInt(0,0)
				#endif
            };
        }

		static Vector2 InventoryGetPosFurnaceStoneVector2(int ix) {
            return ix switch {
                0 => new Vector2 { X = Global.WindowWidthHalf - 300 + 4 + 1 + 40 + 4, Y = Global.WindowHeightHalf - 200 + 2 + 4 + 60 + 4 },
                1 => new Vector2 { X = Global.WindowWidthHalf - 300 + 4 + 1 + 40 + 40 + 4, Y = Global.WindowHeightHalf - 200 + 2 + 4 + 60 + 4 },
                2 => new Vector2 { X = Global.WindowWidthHalf - 300 + 4 + 1 + 40 * 2 + 40 + 4, Y = Global.WindowHeightHalf - 200 + 2 + 4 + 60 + 4 },
                3 => new Vector2 { X = Global.WindowWidthHalf - 300 + 4 + 1 + 40 + 40 + 4, Y = Global.WindowHeightHalf - 200 + 2 + 4 + 60 + 40 + 8 + 4 },
				#if DEBUG
                _ => throw new Exception("Unknown pos id of stone frurnace inv"),
				#else
				_=> Vector2.Zero
				#endif
            };
        }

		static Vector2 InventoryGetPosClothesVector2(int ix) {
			if (ix<4) return new Vector2{ X=Global.WindowWidthHalf-300+4+60+4,    Y=Global.WindowHeightHalf-200+2+4+4+ix*40     };
			else      return new Vector2{ X=Global.WindowWidthHalf-300+4+60+4+40, Y=Global.WindowHeightHalf-200+2+4+4+40*(ix-4) };
		}

		DInt InventoryGetPosNormalInv(int ix) {
			int xx=0, yh=0;

			for (int i=(inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
				if (i>maxInvCount) break;

				if (ix==i) return new DInt{ X= Global.WindowWidthHalf-300+4+200+4+4+xx+4, Y=Global.WindowHeightHalf-200+2+4+yh+4 };

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

		static DInt InventoryGetPosNormal5(int ix) => new() { X=Global.WindowWidth-36, Y=Global.WindowHeightHalf-80+ix*40+4 };

		static Vector2 InventoryGetPosNormal5Vector2(int ix) => new() { X=Global.WindowWidth-36, Y=Global.WindowHeightHalf-80+ix*40+4 };

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
			spriteBatch.Draw(pixel, Fullscreen, color_r0_g0_b0_a100);

			DrawFrame(Global.WindowWidthHalf-150-2, Global.WindowHeightHalf-134,304,234+2,1, color_r0_g0_b0_a100);
			DrawFrame(Global.WindowWidthHalf-150-1, Global.WindowHeightHalf-133,302,234,1, color_r0_g0_b0_a200);
			spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-132,300,34), color_r10_g140_b255);
			spriteBatch.Draw(pixel,new Rectangle(Global.WindowWidthHalf-150, Global.WindowHeightHalf-100+2,300,200-2), Color.LightBlue);

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
                        return items[i] switch {
                            ItemNonInvBasic t => TotalItemsInInventoryForAllTypes(items[i].Id) >= t.Count,
                            ItemNonInvTool t => TotalItemsInInventoryForAllTypes(items[i].Id) >= t.Count,
                            ItemNonInvFood t => TotalItemsInInventoryForAllTypes(items[i].Id) >= t.Count,
                            //case ItemNonInvNonStackable t: return TotalItemsInInventoryForAllTypes(items[i].Id)>=1;
                            //case ItemNonInvBasicColoritzedNonStackable t: return TotalItemsInInventoryForAllTypes(items[i].Id)>=1;
                            _ => TotalItemsInInventoryForAllTypes(items[i].Id) >= 1,
                        };
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
						if (hasItem) spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-150+10+x*40, Global.WindowHeightHalf-100+y*40+20), Color.White);
						else spriteBatch.Draw(inventorySlotTexture,new Vector2(Global.WindowWidthHalf-150+10+x*40, Global.WindowHeightHalf-100+y*40+20), new Color(255,150,150));
					}

					/*GameDraw.DrawItemInInventory*/DrawItem(/*ItemIdToTexture(items[i].Id),*/ items[i], Global.WindowWidthHalf-150+10+x*40+4, Global.WindowHeightHalf-100+y*40+20+4);

					i++;
				}
			}

		}

        void DrawItem(ItemNonInv item, int x, int y) {
            ushort id = item.Id;
            if (id==0) return;
            switch (item) {
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
					//for (int i=0; i<4; i++) {
					//	((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i].SetPos(InventoryGetPosFurnaceStone(i));
					//}
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
					} else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243), Color.White);

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
				inv[i]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(id), id, Color.White, 0, 0);
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
				inv[i]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(id), id, Color.White/*, 0, 0*/);
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
			if (remain!=null) DropItemToPos(remain, PlayerXInt, PlayerYInt);
		}

		void SaveInventory(string name, ItemInv[] inv) {
			List<byte> bytes=new();
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
					//} else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+60+x+4-16, Global.WindowHeightHalf-200+2+4+y+4+243), Color.White);

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
					Rabcr.spriteBatch.Draw(pixel, new Rectangle(mouseRealPosX+cursorWidth, mouseRealPosY,mouseItemNameWidth+6,30), Color.White*0.9f);
					itemText.ChangePosition(mouseRealPosX+cursorWidth, mouseRealPosY);
				} else {
					Rabcr.spriteBatch.Draw(pixel, new Rectangle(mouseRealPosX-cursorWidth-mouseItemNameWidth-6, mouseRealPosY,mouseItemNameWidth+6,30), Color.White*0.9f);
					itemText.ChangePosition(mouseRealPosX-cursorWidth-mouseItemNameWidth-6, mouseRealPosY);
				}
				itemText.Draw(spriteBatch);
			}
		}

		//void MouseItemNameEvent(ushort newId) {
		//	if (newId!=0)mouseDrawItemTextInfo=true;
		//	if (mouseItemId!=newId) {
		//		if (newId==0) {
		//			mouseItemId=newId;
		//			mouseDrawItemTextInfo=false;
		//			return;
		//		}

		//		int langid=GameMethods.GetItemNameId(newId);

		//		if (langid==-1) {
		//			#if DEBUG
		//			mouseDrawItemTextInfo=true;
		//			mouseItemId=newId;
		//			mouseItemName=Lang.Texts[999];
		//		   // mouseItemNameWidth=(int)spriteFont_small.MeasureString(mouseItemName).X;

		//			itemText=new Text(mouseItemName,0,0,BitmapFont.bitmapFont18);
		//			mouseItemNameWidth=(int)itemText.MeasureX();
		//			#else
		//			mouseDrawItemTextInfo=false;
		//			#endif
		//		}else{
		//			mouseDrawItemTextInfo=true;
		//			mouseItemId=newId;
		//			mouseItemName=Lang.Texts[langid];
		//		   // mouseItemNameWidth=(int)spriteFont_small.MeasureString(mouseItemName).X;

		//			itemText=new Text(mouseItemName,0,0,BitmapFont.bitmapFont18);
		//			mouseItemNameWidth=(int)itemText.MeasureX();
		//		}
		//	}
		//}

		void MouseItemNameEvent(ItemInv item) {
			if (item==null) return;
			ushort id= item.Id;
			if (id!=0) mouseDrawItemTextInfo=true;

			if (mouseItemId!=id) {
				if (id==0) {
					mouseItemId=id;
					mouseDrawItemTextInfo=false;
					return;
				}

				int langid=GameMethods.GetItemNameId(id);

				if (langid==-1) {
					#if DEBUG
					mouseDrawItemTextInfo=true;
					mouseItemId=id;
					mouseItemName=Lang.Texts[999];
				   // mouseItemNameWidth=(int)spriteFont_small.MeasureString(mouseItemName).X;

					itemText=new Text(mouseItemName,0,0,BitmapFont.bitmapFont18);
					mouseItemNameWidth=(int)itemText.MeasureX();
					#else
					mouseDrawItemTextInfo=false;
					#endif
				} else {
					mouseDrawItemTextInfo=true;
					mouseItemId=id;
					mouseItemName=Lang.Texts[langid];
				   // mouseItemNameWidth=(int)spriteFont_small.MeasureString(mouseItemName).X;
				    if (debug) {
					   string add="";
						switch (item) {
							case ItemInvFood16 food16:
								add="ItemInvFood16";
								add+='\n';
								add=food16.GetCount+"/"+food16.CountMaximum;
								add+='\n';
								add+=food16.GetDescay+"/"+food16.DescayMaximum;
								break;

							case ItemInvFood32 food32:
								add="ItemInvFood32";
								add+='\n';
								add=food32.GetCount+"/"+food32.CountMaximum;
								add+='\n';
								add+=food32.GetDescay+"/"+food32.DescayMaximum;
								break;
						}
						itemText=new Text(mouseItemName+'\n'+add, 0, 0, BitmapFont.bitmapFont18);
					} else {
						itemText=new Text(mouseItemName, 0, 0, BitmapFont.bitmapFont18);
					}
					mouseItemNameWidth=(int)itemText.MeasureX();
				}
			}
		}
		
     
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

        //        if (FastRandom.Bool()) {
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


		// Dev commands / vévojařsky přékaze
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
			if (text.StartsWith("*pos-y ")) {
				if (float.TryParse(text.Substring("*pos-y ".Length), out float num)) {
					PlayerY=num;
				} 
				text="";
				diserpeard=0;
				return true;
			}
			if (text.StartsWith("*pos-x ")) {
				if (float.TryParse(text.Substring("*pos-x ".Length), out float num)) {
					PlayerX=num;
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
			if (text=="*rain-start") {
				CurrentPrecipitation.Rain=true;
				CurrentPrecipitation.RainForce=1;
				text="";diserpeard=0;
				return true;
			}
			if (text=="*snow-start") {
				CurrentPrecipitation.Snow=true;
				CurrentPrecipitation.SnowForce=1;
				text="";diserpeard=0;
				return true;
			}
			if (text=="*snow-stop") {
				CurrentPrecipitation.Snow=false;
				CurrentPrecipitation.SnowForce=0;
				text="";diserpeard=0;
				return true;
			}
			if (text=="*rain-stop") {
				CurrentPrecipitation.Rain=false;
				CurrentPrecipitation.RainForce=0;
				text="";diserpeard=0;
				return true;
			}
			if (text=="*wind-start") {
				CurrentPrecipitation.WindForce=1;
				text="";diserpeard=0;
				return true;
			}
			if (text=="*wind-stop") {
				CurrentPrecipitation.WindForce=0;
				text="";diserpeard=0;
				return true;
			}	
			if (text=="*sand-start") {
				CurrentPrecipitation.SandForce=1;
				CurrentPrecipitation.Sand=true;
				text="";diserpeard=0;
				return true;
			}
			if (text=="*sand-stop") {
				CurrentPrecipitation.SandForce=0;
				CurrentPrecipitation.Sand=false;
				text="";diserpeard=0;
				return true;
			}
			if (text.StartsWith("*error")) {
				throw new Exception("Manual error");
			}
			return false;
		}

        bool InventoryAddOne(ushort index) {

            #region Nonstackable
            if (GameMethods.IsItemInvNonStackable32(index)) {
                for (int i = 0; i<maxInvCount; i++) {
                    if (InventoryNormal[i].Id == 0) {
                        DInt pos;
                        if (i<5) pos=InventoryGetPosNormal(i);
                        else pos=InventoryGetPosNormalInv(i);
                        InventoryNormal[i]=new ItemInvNonStackable32(ItemIdToTexture(index), index, pos.X, pos.Y);
                        return true;
                    }
                }
                return false;
            }
            if (GameMethods.IsItemInvFood16(index)) {
                for (int i = 0; i<maxInvCount; i++) {
                    if (InventoryNormal[i].Id == 0) {
                        DInt pos;
                        if (i<5) pos=InventoryGetPosNormal(i);
                        else pos=InventoryGetPosNormalInv(i);
                        InventoryNormal[i]=new ItemInvFood16(ItemIdToTexture(index), index, pos.X, pos.Y);
                        return true;
                    }
                }
                return false;
            }
            if (GameMethods.IsItemInvFood32(index)) {
                for (int i = 0; i<maxInvCount; i++) {
                    if (InventoryNormal[i].Id == 0) {
                        DInt pos;
                        if (i<5) pos=InventoryGetPosNormal(i);
                        else pos=InventoryGetPosNormalInv(i);
                        InventoryNormal[i]=new ItemInvFood32(ItemIdToTexture(index), index, pos.X, pos.Y);
                        return true;
                    }
                }
                return false;
            }
            #endregion

            #region Stackable
            if (GameMethods.IsItemInvBasic16(index)) {
                for (int i = 0; i<maxInvCount; i++) {
                    if (InventoryNormal[i].Id == 0) {
                        DInt pos;
                        if (i<5) pos=InventoryGetPosNormal(i);
                        else pos=InventoryGetPosNormalInv(i);
                        InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(index), index, 1, pos.X, pos.Y);
                        return true;
                    }
                }

                for (int i = 0; i<maxInvCount; i++) {
                    if (InventoryNormal[i].Id == index) {
                        ItemInvBasic16 item = (ItemInvBasic16)InventoryNormal[i];
                        if (item.GetCount<99) {
                            item.SetCount=item.GetCount+1;
                            return true;
                        }
                    }
                }
                return false;
            }

            if (GameMethods.IsItemInvBasic32(index)) {
                for (int i = 0; i<maxInvCount; i++) {
                    if (InventoryNormal[i].Id == 0) {
                        DInt pos;
                        if (i<5) pos=InventoryGetPosNormal(i);
                        else pos=InventoryGetPosNormalInv(i);
                        InventoryNormal[i]=new ItemInvBasic32(ItemIdToTexture(index), index, 1, pos.X, pos.Y);
                        return true;
                    }
                }

                for (int i = 0; i<maxInvCount; i++) {
                    if (InventoryNormal[i].Id == index) {
                        ItemInvBasic32 item = (ItemInvBasic32)InventoryNormal[i];
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

        void InventoryDrawClothes() {
            for (int i = 0; i<8; i++) InventoryClothes[i].Draw();
        }
        void DrawInventoryWithMoving() {
            int xx = 0, yh = 0;
            for (int i = (inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
                if (i>maxInvCount) break;
                spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+200+4+4+xx, Global.WindowHeightHalf-200+2+4+yh), Color.White);

                xx+=40;

                if (xx==9*40) {
                    xx=0;
                    yh+=40;
                }
            }
            xx=0;
            yh=0;

            for (int i = (inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
                if (i>maxInvCount) break;

                if (InventoryNormal[i].Id!=0) {
                    InventoryNormal[i].Draw();

                    if (In40(Global.WindowWidthHalf-300+4+200+4+4+xx, Global.WindowHeightHalf-200+2+4+yh)) MouseItemNameEvent(InventoryNormal[i]/*.Id*/);
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
                spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+200+4+4+8*40, Global.WindowHeightHalf-200+2+4+40*5), Color.White);
                spriteBatch.Draw(TextureBin, new Vector2(Global.WindowWidthHalf-300+4+200+4+4+8*40+4, Global.WindowHeightHalf-200+2+4+40*5+4), Color.White);
            }
        }

        //void DrawRightInventoryNormal() {

        //    // Slots
        //    for (int i = 0; i<5; i++) {
        //        if (boxSelected==i) spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidth-40, Global.WindowHeightHalf-80+i*40), Color.LightBlue);
        //        else spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidth-40, Global.WindowHeightHalf-80+i*40), Color.White);
        //    }

        //    // Items
        //    for (int i = 0; i<5; i++) {
        //        invStartInventory[i].Draw();
        //    }
        //}

        void DrawSideInventory() {
            //int x=;
            //int y=;
            Vector2 vec = new(Global.WindowWidth-40, Global.WindowHeightHalf-80);
            //slots
            for (int i = 0; i<5; i++) {
                //	Vector2 vec=new(x, y);

                if (boxSelected==i) spriteBatch.Draw(inventorySlotTexture, vec/*new Vector2(x, y)*/, Color.LightBlue);
                else spriteBatch.Draw(inventorySlotTexture, vec/*new Vector2(x, y)*/, Global.ColorWhite);
                vec.Y+=40;
            }

            //items
            for (int i = 0; i<5; i++) InventoryNormal[i].Draw();
        }

        void InvMouseDraw() {
            mouseItem.SetPos(mouseRealPosX-16, mouseRealPosY-16);
            mouseItem.Draw();
        }

        void InventoryDrawItems() {
            for (int i = 0; i<5; i++) InventoryNormal[i].Draw();
        }
        void DrawNeed() {
            if (CurrentDeskCrafting==null) return;
            if (selectedCraftingItem==-1) return;
            if (SelectedCraftingRecipe==-1) return;
            spriteBatch.Draw(inventoryNeedTexture, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8, Global.WindowHeightHalf-200+2+4+200+8+8), Color.White);
            CraftingIn[] slots = CurrentDeskCrafting[SelectedCraftingRecipe].Input;



            int i = 0;
            for (int y = 0; y<2; y++) {
                for (int x = 0; x<6; x++) {
                    if (slots.Length==i) break;

                    CraftingIn slot = slots[i];
                    ItemNonInv[] item = slot.ItemSlot;
                    if (slot.SelectedItem==-1) {
                        if (!slot.HaveItemInInventory)
                            spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8, 40, 40), color_r255_g0_b0_a100);

                        /*GameDraw.DrawItemInInventory*/
                        DrawItem(/*ItemIdToTexture(item[slot.TmpSelected].Id),*/ item[slot.TmpSelected], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8);
                        
                        if (In40(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8)){
                            MouseItemNameEvent(ItemInvFromItemNonInv(item[slot.TmpSelected]));
                          //  InvMouseDraw();
                        }

                        spriteBatch.Draw(TextureSelectCrafting, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8+x*40+40-16, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+40-16), Color.White);
                    }
                    else {
                        //  ItemNonInv selectedSlot=item[slot.SelectedItem];

                        if (item.Length==1) {
                            if (!slot.HaveItemInInventory)
                                spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8, 40, 40), color_r255_g0_b0_a100);

                            if (slot.Texture!=null) /*GameDraw.DrawItemInInventory*/DrawItem(/*slot.Texture,*/ item[slot.SelectedItem], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8);
                                                       
                        }
                        else {
                            if (!slot.HaveItemInInventory)
                                spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8, 40, 40), color_r255_g0_b0_a100);

                            if (slots[i].SelectedItem==-1) {
                                /*GameDraw.DrawItemInInventory*/
                                DrawItem(/*ItemIdToTexture(item[slot.TmpSelected].Id),*/ item[slot.TmpSelected], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8);
                            }
                            else {
                                /*GameDraw.DrawItemInInventory*/
                                DrawItem(/*slot.Texture, */item[slot.SelectedItem], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8);
                            }
                            spriteBatch.Draw(TextureSelectCrafting, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8+x*40+40-16, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+40-16), Color.White);
                        }
                        if (In40(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8)){
                            MouseItemNameEvent(ItemInvFromItemNonInv(item[slot.SelectedItem]));
                          //  InvMouseDraw();
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
                }
                else {
                    buttonCraft10x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
                    buttonCraft100x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
                }
            }
            else {
                buttonCraft1x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
                buttonCraft10x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
                buttonCraft100x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
            }
        }

        void DrawNeedNewPlus() {
            int AddH = 35;
            if (CurrentDeskCrafting==null) return;
            if (selectedCraftingItem==-1) return;
            if (SelectedCraftingRecipe==-1) return;
            spriteBatch.Draw(inventoryNeedTexture, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8, Global.WindowHeightHalf-200+2+4+200+8+8+AddH), Color.White);
            CraftingIn[] slots = CurrentDeskCrafting[SelectedCraftingRecipe].Input;

            int i = 0;
            for (int y = 0; y<2; y++) {
                for (int x = 0; x<6; x++) {
                    if (slots.Length==i) break;

                    CraftingIn slot = slots[i];
                    ItemNonInv[] item = slot.ItemSlot;
                    if (slot.SelectedItem==-1) {
                        if (!slot.HaveItemInInventory) spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH, 40, 40), color_r255_g0_b0_a100);

                        DrawItem(item[slot.TmpSelected], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH);

                        // GameDraw.DrawItemInInventory(ItemIdToTexture(item[slot.TmpSelected].Id), , Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH);

                        spriteBatch.Draw(TextureSelectCrafting, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8+x*40+40-16, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+40-16+AddH), Color.White);
                    }
                    else {
                        //   ItemNonInv selectedSlot=item[slot.SelectedItem];

                        if (item.Length==1) {
                            if (!slot.HaveItemInInventory) spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH, 40, 40), color_r255_g0_b0_a100);

                            if (slot.Texture!=null) DrawItem(/*slot.Texture,*/ item[slot.SelectedItem], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH);
                        }
                        else {
                            if (!slot.HaveItemInInventory)
                                spriteBatch.Draw(pixel, new Rectangle(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH, 40, 40), color_r255_g0_b0_a100);

                            if (slots[i].SelectedItem==-1) {
                                /*GameDraw.DrawItemInInventory*/
                                DrawItem(/*ItemIdToTexture(item[slot.TmpSelected].Id),*/ item[slot.TmpSelected], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH);
                            }
                            else {
                                /*GameDraw.DrawItemInInventory*/
                                DrawItem(/*slot.Texture,*/ item[slot.SelectedItem], Global.WindowWidthHalf-300+4+200+80+40+8+x*40+4, 4+y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH);
                            }
                            spriteBatch.Draw(TextureSelectCrafting, new Vector2(Global.WindowWidthHalf-300+4+200+80+40+8+x*40+40-16, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+40-16+AddH), Color.White);
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
                }
                else {
                    buttonCraft10x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
                    buttonCraft100x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
                }
            }
            else {
                buttonCraft1x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
                buttonCraft10x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
                buttonCraft100x.ButtonDrawRed(/*spriteBatch, mouseLeftDown, mouseRealPos*/);
            }
        }

        void DrawInventoryNormal() {
            int xx = 0, yh = 0;

            //Slots
            for (int i = (inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
                if (i>maxInvCount) break;
                spriteBatch.Draw(inventorySlotTexture, new Vector2(Global.WindowWidthHalf-300+4+200+4+4+xx, Global.WindowHeightHalf-200+2+4+yh), Color.White);

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

            for (int i = (inventoryScrollbarValue/9)*9+5; i<(inventoryScrollbarValue/9)*9+45+5; i++) {
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

        bool CanCraft(int c) {
            foreach (CraftingIn n in CurrentDeskCrafting[SelectedCraftingRecipe].Input) {
                if (n.SelectedItem==-1) return false;
                ItemNonInv item = n.ItemSlot[n.SelectedItem];
                switch (item) {
                    case ItemNonInvTool t:
                        if (TotalItemsInInventoryForAllTypes(item.Id)<t.Count*c) return false;
                        break;

                    case ItemNonInvNonStackable t:
                        if (TotalItemsInInventoryForAllTypes(item.Id)<1*c) return false;
                        break;

                    case ItemNonInvBasicColoritzedNonStackable t:
                        if (TotalItemsInInventoryForAllTypes(item.Id)<1*c) return false;
                        break;

                    case ItemNonInvFood t:
                        if (TotalItemsInInventoryForAllTypes(item.Id)<t.Count*c) return false;
                        break;

                    case ItemNonInvBasic t:
                        if (TotalItemsInInventoryForAllTypes(item.Id)<t.Count*c) return false;
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

        void InventoryRemoveSelectedItem() {
            ItemInv i = InventoryNormal[boxSelected];
            switch (i) {
                case ItemInvTool32 s:
                    // s.SetCount=s.GetCount-1;
                    if (s.GetCount==1) {
                        InventoryNormal[boxSelected]=itemBlank;
                    }
                    else {
                        s.SetCount=s.GetCount-1;
                    }
                    break;

                case ItemInvTool16 s:
                    if (s.GetCount==1) {
                        InventoryNormal[boxSelected]=itemBlank;
                    }
                    else {
                        s.SetCount=s.GetCount-1;
                    }
                    break;

                case ItemInvBasic16 s:
                    if (s.GetCount==1) {
                        InventoryNormal[boxSelected]=itemBlank;
                    }
                    else {
                        s.SetCount=s.GetCount-1;
                    }
                    break;

                case ItemInvBasic32 s:
                    if (s.GetCount==1) {
                        InventoryNormal[boxSelected]=itemBlank;
                    }
                    else {
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
                    }
                    else {
                        s.SetCount=s.GetCount-1;
                    }
                    break;

                default:
                    InventoryNormal[boxSelected]=itemBlank;
                    break;

            }
        }

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
                        for (int i = 0; i<4; i++) {
                            ((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i].SetPos(InventoryGetPosFurnaceStone(i));
                        }
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

        void SetNeed() {
            if (SelectedCraftingRecipe==-1) return;
            if (CurrentDeskCrafting==null) return;
            CraftingIn[] slots = CurrentDeskCrafting[SelectedCraftingRecipe].Input;

            int i = 0;
            for (int y = 0; y<2; y++) {
                for (int x = 0; x<6; x++) {
                    if (slots.Length==i) break;
                    CraftingIn slot = slots[i];
                    ItemNonInv[] item = slot.ItemSlot;

                    if (slot.SelectedItem==-1) {
                        slot.TmpSelected=FastRandom.Int(item.Length);
                        slot.Texture=ItemIdToTexture(item[slot.TmpSelected].Id);
                    }
                    else {
                        // ItemNonInv selectedSlot=item[slot.SelectedItem];
                        if (item.Length==1) {
                            switch (slot.ItemSlot[0]) {
                                case ItemNonInvTool t:
                                    slot.Texture=ItemIdToTexture(item[0].Id);
                                    if (t.Count==-1) {
                                        slot.HaveItemInInventory=TotalItemsInInventoryForAllTypes(slot.ItemSlot[0].Id)>0;
                                    }
                                    else {
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

                        }
                        else {
                            slot.Texture=ItemIdToTexture(item[slot.SelectedItem].Id);
                        }
                    }

                    i++;


                }
            }
        }

        void ChangeInventory() {
            if (invMove) {
                if (leftMove) {
                    if (mouseRightRelease) {
                        int i;

                        // Basic right inventory
                        if ((i=InvSideMoveId())>=0) {
                            InvMoveOne(InventoryNormal, i);
                            return;
                        }

                        // Inventory
                        if ((i=InvMoveId())>=0) {
                            InvMoveOne(InventoryNormal, i);
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

                        // FurnaceStone
                        if (inventory==InventoryType.FurnaceStone) {
                            if ((i=InvFurnaceStoneMoveId())>=0) {
                                InvMoveOne(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
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
                            if (In40(Global.WindowWidthHalf-300+38+40, Global.WindowHeightHalf+20-2+40+25)) {
                                InvMoveOne(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                                return;
                            }
                        }

                        if (inventory==InventoryType.Barrel) {
                            if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250)) {
                                InvMoveOne(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                                return;
                            }

                            if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250+64)) {
                                InvMoveOne(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 1);
                                return;
                            }
                        }

                        InvDrop();

                    }
                    else if (mouseLeftRelease) {
                        int i;

                        // Basic right inventory
                        if ((i=InvSideMoveId())>=0) {
                            InvMove(InventoryNormal, i);
                            return;
                        }

                        // Inventory
                        if ((i=InvMoveId())>=0) {
                            InvMove(InventoryNormal, i);
                            return;
                        }

                        // Clothes
                        if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
                            if ((i=InvClothesMoveId())>=0) {
                                InvMove(InventoryClothes, i);
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

                        // FurnaceStone
                        if (inventory==InventoryType.FurnaceStone) {
                            if ((i=InvFurnaceStoneMoveId())>=0) {
                                InvMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
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
                            if (In40(Global.WindowWidthHalf-300+38+40, Global.WindowHeightHalf+20-2+40+25)) {
                                InvMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                                return;
                            }
                        }

                        if (inventory==InventoryType.Barrel) {
                            if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250)) {
                                InvMove(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                                return;
                            }

                            if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250+64)) {
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
                else {
                    if (mouseLeftRelease) {
                        int i;

                        // Basic right inventory
                        if ((i=InvSideMoveId())>=0) {
                            InvMoveHalf(InventoryNormal, i);
                            return;
                        }

                        // Inventory
                        if ((i=InvMoveId())>=0) {
                            InvMoveHalf(InventoryNormal, i);
                            return;
                        }

                        // Clothes
                        if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
                            if ((i=InvClothesMoveId())>=0) {
                                InvMoveHalf(InventoryClothes, i);
                                return;
                            }
                        }

                        // FurnaceStone
                        if (inventory==InventoryType.FurnaceStone) {
                            if ((i=InvFurnaceStoneMoveId())>=0) {
                                InvMoveHalf(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
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
                            if (In40(Global.WindowWidthHalf-300+38+40, Global.WindowHeightHalf+20-2+40+25)) {
                                InvMoveHalf(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                                return;
                            }
                        }

                        if (inventory==InventoryType.Barrel) {
                            if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250)) {
                                InvMoveHalf(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                                return;
                            }

                            if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250+64)) {
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

                    }
                    else {
                        if (mouseRightRelease) {
                            int i;

                            // Basic right inventory
                            if ((i=InvSideMoveId())>=0) {
                                InvMove(InventoryNormal, i);
                                return;
                            }

                            // Inventory
                            if ((i=InvMoveId())>=0) {
                                InvMove(InventoryNormal, i);
                                return;
                            }

                            // Clothes
                            if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
                                if ((i=InvClothesMoveId())>=0) {
                                    InvMove(InventoryClothes, i);
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

                            // FurnaceStone
                            if (inventory==InventoryType.FurnaceStone) {
                                if ((i=InvFurnaceStoneMoveId())>=0) {
                                    InvMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
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
                                if (In40(Global.WindowWidthHalf-300+38+40, Global.WindowHeightHalf+20-2+40+25)) {
                                    InvMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                                    return;
                                }
                            }

                            if (inventory==InventoryType.Barrel) {
                                if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250)) {
                                    InvMove(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                                    return;
                                }

                                if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250+64)) {
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
            }
            else {
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

                    // FurnaceStone
                    if (inventory==InventoryType.FurnaceStone) {
                        if ((i=InvFurnaceStoneMoveId())>=0) {
                            StartItemMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
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
                        if (In40(Global.WindowWidthHalf-300+38+40, Global.WindowHeightHalf+20-2+40+25)) {
                            StartItemMove(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                            leftMove = true;
                            return;
                        }
                    }

                    if (inventory==InventoryType.Barrel) {
                        if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250)) {
                            StartItemMove(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                            leftMove = true;
                            return;
                        }

                        if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250+64)) {
                            StartItemMove(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 1);
                            leftMove = true;
                            return;
                        }
                    }

                }
                else {
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
                                if (i<8) {
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

                        // FurnaceStone
                        if (inventory==InventoryType.FurnaceStone) {
                            if ((i=InvFurnaceStoneMoveId())>=0) {
                                StartItemMoveHalf(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, i);
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
                            if (In40(Global.WindowWidthHalf-300+38+40, Global.WindowHeightHalf+20-2+40+25)) {
                                StartItemMoveHalf(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                                leftMove = false;
                                return;
                            }
                        }

                        if (inventory==InventoryType.Barrel) {
                            if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250)) {
                                StartItemMoveHalf(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 0);
                                leftMove = false;
                                return;
                            }

                            if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250+64)) {
                                StartItemMoveHalf(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv, 1);
                                leftMove = false;
                                return;
                            }
                        }
                    }
                    else {
                        if (mousePosChanged) {
                            int i;
                            mouseDrawItemTextInfo=false;
                            // Basic right inventory
                            if ((i=InvSideMoveId())>=0) {
                                MouseItemNameEvent(InventoryNormal[i]);
                                return;
                            }

                            // Inventory
                            if ((i=InvMoveId())>=0) {
                                MouseItemNameEvent(InventoryNormal[i]);
                                return;
                            }

                            // Clothes
                            if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
                                if ((i=InvClothesMoveId())>=0) {
                                    if (i<8) MouseItemNameEvent(InventoryClothes[i]);
                                    return;
                                }
                            }

                            // Shelf
                            if (inventory==InventoryType.Shelf || inventory==InventoryType.Composter) {
                                if ((i=InvShelfMoveId())>=0) {
                                    MouseItemNameEvent(((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i]);
                                    return;
                                }
                            }

                            // FurnaceStone
                            if (inventory==InventoryType.FurnaceStone) {
                                if ((i=InvFurnaceStoneMoveId())>=0) {
                                    MouseItemNameEvent(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i]);
                                    return;
                                }
                            }

                            // BoxWooden
                            if (inventory==InventoryType.BoxWooden) {
                                if ((i=InvWoodenBoxMoveId())>=0) {
                                    MouseItemNameEvent(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i]);
                                    return;
                                }
                            }

                            // Adv box
                            if (inventory==InventoryType.BoxAdv) {
                                if ((i=InvAdvBoxMoveId())>=0) {
                                    MouseItemNameEvent(((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i]);
                                    return;
                                }
                            }

                            // Miner
                            if (inventory==InventoryType.Miner) {
                                if ((i=InvWoodenBoxMoveId())>=0) {
                                    MouseItemNameEvent(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[i]);
                                    return;
                                }
                            }

                            // Charger || OxygenMachine
                            if (inventory==InventoryType.Charger || inventory==InventoryType.OxygenMachine) {
                                if (In40(Global.WindowWidthHalf-300+38+40, Global.WindowHeightHalf+20-2+40+25)) {
                                    MouseItemNameEvent(((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[0]);
                                    return;
                                }
                            }

                            if (inventory==InventoryType.Barrel) {
                                if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250)) {
                                    MouseItemNameEvent(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[0]);
                                    return;
                                }

                                if (In40(Global.WindowWidthHalf-300+119, Global.WindowHeightHalf-198+250+64)) {
                                    MouseItemNameEvent(((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv[1]);
                                    return;
                                }
                            }

                            // Creative
                            if (inventory==InventoryType.Creative) {
                                if (!creativeTabCrafting) {
                                    if ((i=GetInventoryIdCreative())>=0) {
                                        MouseItemNameEvent(InventoryCreative[i]);
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
                                    MouseItemNameEvent(InventoryCrafting[i]);
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
                int xx = 0, yh = 0;

                for (int i = inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
                    if (i>inventoryScrollbarValueCraftingMax) break;

                    if (In40(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {
                        selectedCraftingItem=i;
                        ItemInv itemToCraft = InventoryCrafting[i];

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
        void SelectItemToDust() {
            if (mouseLeftRelease) {
                int xx = 0, yh = 0;

                for (int i = inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
                    if (i>inventoryScrollbarValueCraftingMax) break;

                    if (In40(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {

                        selectedCraftingItem=i;

                        SelectedCraftingRecipe=0;

                        ItemInv itemToCraft = InventoryCrafting[i];

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
        void SelectItemClothes() {
            if (mouseLeftRelease) {
                int xx = 0, yh = 0;

                for (int i = inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
                    if (i>inventoryScrollbarValueCraftingMax) break;

                    if (In40(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {
                        selectedCraftingItem=i;

                        ItemInv itemToCraft = InventoryCrafting[i];
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
        void CraftingEventsPlus() {
            int AddH = 35;
            if (SelectedCraftingRecipe!=-1) {
#if DEBUG
                if (CurrentDeskCrafting==null) throw new Exception("Pravděpodobně chybí recept - doplň v GameMethods");
#endif

                CraftingIn[] slots = CurrentDeskCrafting[SelectedCraftingRecipe].Input;
                if (CurrentDeskCrafting!=null) {
                    if (CurrentDeskCrafting.Length!=1) {
                        if (buttonNext.Update()) {
                            SelectedCraftingRecipe++;
                            if (SelectedCraftingRecipe==CurrentDeskCrafting.Length) SelectedCraftingRecipe=0;
                            SetNeed();
                        }

                        if (buttonPrev.Update()) {
                            SelectedCraftingRecipe--;
                            if (SelectedCraftingRecipe==-1) SelectedCraftingRecipe=CurrentDeskCrafting.Length-1;
                            SetNeed();
                        }
                    }
                }

                int i = 0;
                for (int y = 0; y<2; y++) {
                    for (int x = 0; x<6; x++) {
                        if (slots.Length==i) break;
                        CraftingIn slot = slots[i];
                        ItemNonInv[] item = slot.ItemSlot;
                        if (item.Length>1) {
                            if (mouseLeftDown) {
                                if (In40(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8+AddH)) {
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

        void SelectItemBake() {
            if (mouseLeftRelease) {
                int xx = 0, yh = 0;

                for (int i = inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
                    if (i>inventoryScrollbarValueCraftingMax) break;

                    if (In40(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8)) {
                        selectedCraftingItem=i;
                        ItemInv itemToCraft = InventoryCrafting[i];

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

        void CraftingEvents() {
            if (SelectedCraftingRecipe!=-1) {
#if DEBUG
                if (CurrentDeskCrafting==null) throw new Exception("Pravděpodobně chybí recept - doplň v GameMethods ("+((Items)InventoryCrafting[selectedCraftingItem].Id)+")");
#endif

                CraftingIn[] slots = CurrentDeskCrafting[SelectedCraftingRecipe].Input;
                if (CurrentDeskCrafting!=null) {
                    if (CurrentDeskCrafting.Length!=1) {
                        if (buttonNext.Update()) {
                            SelectedCraftingRecipe++;
                            if (SelectedCraftingRecipe==CurrentDeskCrafting.Length) SelectedCraftingRecipe=0;
                            SetNeed();
                        }

                        if (buttonPrev.Update()) {
                            SelectedCraftingRecipe--;
                            if (SelectedCraftingRecipe==-1) SelectedCraftingRecipe=CurrentDeskCrafting.Length-1;
                            SetNeed();
                        }
                    }
                }

                int i = 0;
                for (int y = 0; y<2; y++) {
                    for (int x = 0; x<6; x++) {
                        if (slots.Length==i) break;
                        CraftingIn slot = slots[i];
                        ItemNonInv[] item = slot.ItemSlot;
                        if (item.Length>1) {
                            if (mouseLeftDown) {
                                if (In40(Global.WindowWidthHalf-300+4+200+80+40+8+x*40, y*40+Global.WindowHeightHalf-200+2+4+200+8+8)) {
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
        void SelectItemCraftPlus() {
            int AddH = 35;
            if (mouseLeftRelease) {
                int xx = 0, yh = 0;

                for (int i = inventoryScrollbarValueCrafting; i<inventoryScrollbarValueCrafting+6*4; i++) {
                    if (i>inventoryScrollbarValueCraftingMax) break;

                    if (In40(Global.WindowWidthHalf-300+4+40+4+xx, Global.WindowHeightHalf-200+2+4+200+8+yh+8+AddH)) {

                        selectedCraftingItem=i;

                        ItemInv itemToCraft = InventoryCrafting[i];

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

        ItemNonInv InventoryAdd(ItemNonInv it) {

            switch (it) {
                #region Nonstackable
                case ItemNonInvNonStackable item:
                    if (GameMethods.IsItemInvNonStackable32(it.Id)) {
                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i].Id == 0) {
                                DInt pos = InventoryGetPosNormal(i);
                                //if (i<5) pos
                                //else pos=InventoryGetPosNormalInv(i);
                                InventoryNormal[i]=new ItemInvNonStackable32(ItemIdToTexture(it.Id), it.Id, pos.X, pos.Y);
                                return null;
                            }
                        }
                    }
                    else {
                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i].Id == 0) {
                                DInt pos = InventoryGetPosNormal(i);
                                //if (i<5) pos
                                //else pos=InventoryGetPosNormalInv(i);
                                InventoryNormal[i]=new ItemInvNonStackable16(ItemIdToTexture(it.Id), it.Id, pos.X, pos.Y);
                                return null;
                            }
                        }
                    }
                    return it;

                case ItemNonInvBasicColoritzedNonStackable item:
                    if (GameMethods.IsItemInvBasicColoritzed32NonStackable(it.Id)) {
                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i].Id == 0) {
                                DInt pos = InventoryGetPosNormal(i);
                                //if (i<5) pos
                                //else pos=InventoryGetPosNormalInv(i);
                                InventoryNormal[i]=new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(it.Id), it.Id, item.color, pos.X, pos.Y);
                                return null;
                            }
                        }
                    }
                    return it;

                #endregion

                #region stackable
                case ItemNonInvBasic item:
                    if (GameMethods.IsItemInvBasic16(it.Id)) {
                        int remain = item.Count;
                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i].Id == it.Id) {
                                ItemInvBasic16 item2 = (ItemInvBasic16)InventoryNormal[i];
                                if (item2.GetCount<99) {
                                    int needToAdd = 99-item2.GetCount;
                                    if (needToAdd>remain) {
                                        item2.SetCount=item2.GetCount+remain;
                                        return null;
                                    }
                                    else if (needToAdd==remain) {
                                        item2.SetCount=item2.GetCount+remain;
                                        return null;
                                    }
                                    else {
                                        item2.SetCount=99;
                                        remain-=needToAdd;
                                    }
                                }
                            }
                        }

                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i].Id == 0) {
                                DInt pos = InventoryGetPosNormal(i);
                                //if (i<5) pos
                                //else pos=InventoryGetPosNormalInv(i);
                                if (remain<=99) {
                                    InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, remain, pos.X, pos.Y);
                                    return null;
                                }
                                else {
                                    InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, 99, pos.X, pos.Y);
                                    remain-=99;
                                }
                            }
                        }

                        return new ItemNonInvBasic(it.Id, remain);
                    }
                    else {
                        int remain = item.Count;

                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i]!=null) {
                                if (InventoryNormal[i].Id == it.Id) {
                                    ItemInvBasic32 item2 = (ItemInvBasic32)InventoryNormal[i];
                                    if (item2.GetCount<99) {
                                        int needToAdd = 99-item2.GetCount;
                                        if (needToAdd>remain) {
                                            item2.SetCount=item2.GetCount+remain;
                                            return null;
                                        }
                                        else if (needToAdd==remain) {
                                            item2.SetCount=item2.GetCount+remain;
                                            return null;
                                        }
                                        else {
                                            item2.SetCount=99;
                                            remain-=needToAdd;
                                        }
                                    }
                                }
                            }
                        }

                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i]!=null) {

                                if (InventoryNormal[i].Id == 0) {
                                    DInt pos;
                                    if (i<5) pos=InventoryGetPosNormal(i);
                                    else pos=InventoryGetPosNormalInv(i);
                                    if (remain<=99) {
                                        InventoryNormal[i]=new ItemInvBasic32(ItemIdToTexture(it.Id), it.Id, remain, pos.X, pos.Y);
                                        return null;
                                    }
                                    else {
                                        InventoryNormal[i]=new ItemInvBasic32(ItemIdToTexture(it.Id), it.Id, 99, pos.X, pos.Y);
                                        remain-=99;
                                    }
                                }
                            }
                        }
                        return new ItemNonInvBasic(it.Id, remain);
                    }

                case ItemNonInvFood item:
                    if (GameMethods.IsItemInvFood16(it.Id)) {
                        int remain = item.Count;
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

                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i]!=null) {

                                if (InventoryNormal[i].Id == 0) {
                                    DInt pos = InventoryGetPosNormal(i);
                                    if (remain<=item.CountMaximum) {
                                        InventoryNormal[i]=new ItemInvFood16(ItemIdToTexture(it.Id), it.Id, remain, item.CountMaximum, item.Descay, item.DescayMaximum, pos.X, pos.Y);
                                        //   InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, remain, pos.X, pos.Y);
                                        return null;
                                    }
                                    else {
                                        InventoryNormal[i]=new ItemInvFood16(ItemIdToTexture(it.Id), it.Id, remain, item.CountMaximum, item.Descay, item.DescayMaximum, pos.X, pos.Y);
                                        //  InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, 99, pos.X, pos.Y);
                                        remain-=item.CountMaximum;
                                    }
                                }
                            }
                        }
                        return new ItemNonInvFood(it.Id, remain, item.CountMaximum, item.Descay, item.DescayMaximum);
                    }
                    else {
                        int remain = item.Count;
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

                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i]!=null) {

                                if (InventoryNormal[i].Id == 0) {
                                    DInt pos = InventoryGetPosNormal(i);
                                    if (remain<=item.CountMaximum) {
                                        InventoryNormal[i]=new ItemInvFood32(ItemIdToTexture(it.Id), it.Id, remain, item.CountMaximum, item.Descay, item.DescayMaximum, pos.X, pos.Y);
                                        //   InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, remain, pos.X, pos.Y);
                                        return null;
                                    }
                                    else {
                                        InventoryNormal[i]=new ItemInvFood32(ItemIdToTexture(it.Id), it.Id, remain, item.CountMaximum, item.Descay, item.DescayMaximum, pos.X, pos.Y);
                                        //  InventoryNormal[i]=new ItemInvBasic16(ItemIdToTexture(it.Id), it.Id, 99, pos.X, pos.Y);
                                        remain-=item.CountMaximum;
                                    }
                                }
                            }
                        }

                        return new ItemNonInvFood(it.Id, remain, item.CountMaximum, item.Descay, item.DescayMaximum);
                    }

                case ItemNonInvTool item:
                    if (GameMethods.IsItemInvTool32(it.Id)) {
                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i]!=null) {

                                if (InventoryNormal[i].Id == 0) {
                                    DInt pos;
                                    if (i<5) pos=InventoryGetPosNormal(i);
                                    else pos=InventoryGetPosNormalInv(i);
                                    InventoryNormal[i]=new ItemInvTool32(ItemIdToTexture(it.Id), it.Id, item.Count, item.Maximum, pos.X, pos.Y);
                                    return null;
                                }
                            }
                        }

                        return item;//new ItemNonInvTool(item.Id, item.Count, item.Maximum);
                    }
                    else {
                        for (int i = 0; i<maxInvCount; i++) {
                            if (InventoryNormal[i]!=null) {

                                if (InventoryNormal[i].Id == 0) {
                                    DInt pos;
                                    if (i<5) pos=InventoryGetPosNormal(i);
                                    else pos=InventoryGetPosNormalInv(i);
                                    InventoryNormal[i]=new ItemInvTool16(ItemIdToTexture(it.Id), it.Id, item.Count, item.Maximum, pos.X, pos.Y);
                                    return null;
                                }
                            }
                        }

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

        int InvSideMoveId() {
            // Basic right inventory
            if (In(Global.WindowWidth-40, Global.WindowHeightHalf-80, Global.WindowWidth, Global.WindowHeightHalf-80+5*40)) {
                //  Debug.WriteLine((newMouseState.Y-(Global.WindowHeightHalf-80))/40);
                return (newMouseState.Y-(Global.WindowHeightHalf-80))/40;
            }
            return -1;
        }

        int InvMoveId() {
            // Inventory
            if (In(Global.WindowWidthHalf-300+4+200+4+4, Global.WindowHeightHalf-200+2+4, Global.WindowWidthHalf-300+4+200+4+4+(9*40), Global.WindowHeightHalf-200+2+4+(5*40))) {
                int row = (mouseRealPosY-(Global.WindowHeightHalf-200+2+4))/40;
                int col = (mouseRealPosX-(Global.WindowWidthHalf-300+4+200+4+4))/40;
                // Debug.WriteLine(row*9+" "+col+" "+inventoryScrollbarValue+" "+4);
                return row*9+col+inventoryScrollbarValue+5;
            }
            return -1;
        }

        int InvShelfMoveId() {
            // Shelf
            if (In(Global.WindowWidthHalf-300+38, Global.WindowHeightHalf+20-2+25, Global.WindowWidthHalf-300+38+40*3-1, Global.WindowHeightHalf+20-2+3*40+25-1)) {
                int row = (mouseRealPosX-(Global.WindowWidthHalf-300+38))/40;
                int col = (mouseRealPosY-(Global.WindowHeightHalf+20-2+25))/40;
                return row+col*3;
            }

            return -1;
        }

        void InvMoveOne(ItemInv[] toA, int toI) {
            Debug.WriteLine("InvMoveOne");
            if (mouseItem.Id==toA[toI].Id) {
                switch (mouseItem) {
                    case ItemInvBasic16 f: {
                        ItemInvBasic16 t = (ItemInvBasic16)toA[toI];
                        if (t.GetCount==99) return;

                        if (f.GetCount==1) {
                            t.SetCount=t.GetCount+1;
                            invStartInventory[invStartId]=itemBlank;
                        }
                        else {
                            t.SetCount=t.GetCount+1;
                            //	t.SetCount=t.GetCount-1;
                        }
                        return;
                    }


                    case ItemInvBasic32 f: {
                        ItemInvBasic32 t = (ItemInvBasic32)toA[toI];
                        if (t.GetCount==99) return;

                        if (f.GetCount==1) {
                            t.SetCount=t.GetCount+1;
                            invStartInventory[invStartId]=itemBlank;
                        }
                        else {
                            t.SetCount=t.GetCount+1;
                            //t.SetCount=t.GetCount-1;
                        }
                        return;
                    }

                    case ItemInvFood16 f: {
                        ItemInvFood16 t = (ItemInvFood16)toA[toI];
                        int max = t.CountMaximum;
                        if (t.GetCount==max) return;

                        if (f.GetCount==1) {
                            t.SetCount=t.GetCount+1;
                            invStartInventory[invStartId]=itemBlank;
                        }
                        else {
                            t.SetCount=t.GetCount+1;
                            t.SetCount=t.GetCount-1;
                        }
                        return;
                    }
                }
            }
            else if (toA[toI].Id==(ushort)BlockId.None) {
                switch (mouseItem) {
                    case ItemInvBasic16 f: {
                        if (f.GetCount==1) {
                            DInt p = GetPosOfItemInInventories(toA, toI);
                            toA[toI]=new ItemInvBasic16(f.Texture, f.Id, 1, p.X, p.Y);
                            mouseItem=itemBlank;
                        }
                        else {
                            int half = f.GetCount/2;
                            DInt p = GetPosOfItemInInventories(toA, toI);
                            toA[toI]=new ItemInvBasic16(f.Texture, f.Id, f.GetCount-half, p.X, p.Y);
                            f.SetCount=half;
                        }
                        return;
                    }

                    case ItemInvBasic32 f: {
                        if (f.GetCount==1) {
                            DInt p = GetPosOfItemInInventories(toA, toI);
                            toA[toI]=new ItemInvBasic32(f.Texture, f.Id, 1, p.X, p.Y);
                            mouseItem=itemBlank;
                        }
                        else {
                            int half = f.GetCount/2;
                            DInt p = GetPosOfItemInInventories(toA, toI);
                            toA[toI]=new ItemInvBasic32(f.Texture, f.Id, f.GetCount-half, p.X, p.Y);
                            f.SetCount=half;
                        }
                        return;
                    }

#if DEBUG
                    default: throw new Exception("Missing ItemInv category in switch");
#endif
                }
            }
            else {
                switch (mouseItem) {
                    case ItemInvBasicColoritzed32NonStackable f:
                        invMove=false;
                        Vector2 toPos = toA[toI].GetPosVector2();
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

        int InvWoodenBoxMoveId() {
            // Wooden box
            if (In(Global.WindowWidthHalf-300+59, Global.WindowHeightHalf+59, Global.WindowWidthHalf-300+59+(12*40), Global.WindowHeightHalf+59+40*2)) {
                int row = (mouseRealPosX-(Global.WindowWidthHalf-300+59))/40;
                int col = (mouseRealPosY-(Global.WindowHeightHalf+59))/40;
                //Debug.WriteLine("[wooden] row: "+row+", col:"+col+", id: "+(row+col*12));
                return row+col*12;
            }

            return -1;
        }

        void InvDrop() {
            if (mouseRealPosX<Global.WindowWidthHalf) {
                if (terrain[(PlayerXInt-30)/16].IsSolidBlocks[PlayerYInt/16]) AddItemToPlayer(mouseItem.ToNon());
                else DropItemToPos(mouseItem.ToNon(), PlayerXInt-30, PlayerYInt);
            }
            else {
                if (terrain[(PlayerXInt+20)/16].IsSolidBlocks[PlayerYInt/16]) AddItemToPlayer(mouseItem.ToNon());
                else DropItemToPos(mouseItem.ToNon(), PlayerXInt+20, PlayerYInt);
            }
            invMove=false;
            mouseItem=itemBlank;
            mouseItemId=0;
            showMouseItemWhileMooving=false;
            mouseDrawItemTextInfo=true;
        }

        void InvMove(ItemInv[] toA, int toI) {
            Debug.WriteLine("InvMove");
            showMouseItemWhileMooving=false;
            mouseDrawItemTextInfo=true;
            invMove=false;
            // Debug.WriteLine("dest: "+toI);
            if (mouseItem.Id==toA[toI].Id) {
                switch (mouseItem) {
                    case ItemInvBasic16 f: {
                        ItemInvBasic16 t = (ItemInvBasic16)toA[toI];
                        int total = f.GetCount+t.GetCount;
                        if (total>100) {
                            t.SetCount=99;
                            f.SetCount=total-99;
                            invStartInventory[invStartId]=mouseItem;
                        }
                        else {
                            t.SetCount=total;
                        }
                    }
                    return;

                    case ItemInvBasic32 f: {
                        ItemInvBasic32 t = (ItemInvBasic32)toA[toI];
                        int total = f.GetCount+t.GetCount;

                        if (total>100) {
                            t.SetCount=99;
                            f.SetCount=total-99;
                            invStartInventory[invStartId]=mouseItem;
                        }
                        else {
                            t.SetCount=total;
                        }
                    }
                    return;

                    case ItemInvFood16 f: {
                        ItemInvFood16 t = (ItemInvFood16)toA[toI];
                        int max = f.CountMaximum;
                        int total = f.GetCount+t.GetCount;

                        if (total>max) {
                            t.SetCount=max;
                            f.SetCount=total-max;
                            invStartInventory[invStartId]=mouseItem;
                        }
                        else {
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

                    default: {
                        ItemInv t = toA[toI];
                        toA[toI]=mouseItem;
                        invStartInventory[invStartId]=t;
                    }
                    return;
                }
            }
            else {
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
                    DInt p = GetPosOfItemInInventories(toA, toI);
                    toA[toI]=mouseItem;
                    toA[toI].SetPos(p.X, p.Y);
                    mouseItem=itemBlank;
                    return;
                }
                else {
                    ItemInv t = toA[toI];
                    DInt destinationPos = t.GetPos();
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

        int InvFurnaceStoneMoveId() {
            if (In40(Global.WindowWidthHalf-300+4+1+40, Global.WindowHeightHalf-200+2+4+60)) return 0;
            if (In40(Global.WindowWidthHalf-300+4+1+40+40, Global.WindowHeightHalf-200+2+4+60)) return 1;
            if (In40(Global.WindowWidthHalf-300+4+1+40*2+40, Global.WindowHeightHalf-200+2+4+60)) return 2;
            if (In40(Global.WindowWidthHalf-300+4+1+40+40, Global.WindowHeightHalf-200+2+4+60+40+8)) return 3;

            return -1;
        }

        int InvClothesMoveId() {
            if (mouseRealPosY>Global.WindowHeightHalf-200+2+4+4+(4*40)) return -1;
            if (mouseRealPosY<Global.WindowHeightHalf-200+2+4+4) return -1;

            // Clothes
            if (mouseRealPosX>Global.WindowWidthHalf-300+4+60+4) {

                if (mouseRealPosX<Global.WindowWidthHalf-300+4+60+4+40) {
                    return (newMouseState.Y-(Global.WindowHeightHalf-200+2+4+4))/40;
                }
                else if (mouseRealPosX<Global.WindowWidthHalf-300+4+60+4+40+40) {
                    return (newMouseState.Y-(Global.WindowHeightHalf-200+2+4+4))/40+4;
                }
            }
            return -1;
        }

        void InvMoveHalf(ItemInv[] toA, int toI) {
            Debug.WriteLine("InvMoveHalf");
            //if (fromA[fromI].Id!=0 && toA[toI].Id==0) {
            switch (invStartInventory[invStartId]) {
                case ItemInvBasic16 item: {
                    if (item.GetCount>1) {
                        int half = (int)((float)item.GetCount/2);
                        int fromY = item.GetCount-half;
                        // DInt p=GetPosOfItemInInventories(invStartInventory,invStartId);
                        // InventoryGetPosNormal(toI);
                        toA[toI]=new ItemInvBasic16(item.Texture, item.Id, half, startMovePos.X, startMovePos.Y);
                        ((ItemInvBasic16)invStartInventory[invStartId]).SetCount=fromY;
                        return;
                    }
                }
                break;

                case ItemInvBasic32 item: {
                    if (item.GetCount>1) {
                        int half = (int)((float)item.GetCount/2);
                        int fromY = item.GetCount-half;
                        DInt p = InventoryGetPosNormal(toI);
                        toA[toI]=new ItemInvBasic32(item.Texture, item.Id, half, p.X, p.Y);
                        ((ItemInvBasic32)invStartInventory[invStartId]).SetCount=fromY;
                        return;
                    }
                }
                break;
            }
            // }
            invMove=false;
        }

        int InvAdvBoxMoveId() {
            // Adv box
            if (In(Global.WindowWidthHalf-300+20, Global.WindowHeightHalf+23, Global.WindowWidthHalf-300+20+12*40, Global.WindowHeightHalf+23+40*4)) {
                int row = (mouseRealPosX-(Global.WindowWidthHalf-300+20))/40;
                int col = (mouseRealPosY-(Global.WindowHeightHalf+23))/40;
                //  Debug.WriteLine("[adv] row: "+row+", col:"+col+", id: "+(row+col*12));
                return row+col*12;
            }

            return -1;
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
                    case ItemInvBasic16 i: {
                        int c = i.GetCount;
                        if (c==1) {
                            mouseItem=new ItemInvBasic16(i.Texture, i.Id, 1, mouseRealPosX, mouseRealPosY);
                            inv[id]=itemBlank;
                        }
                        else {
                            int stay = c/2;
                            DInt z = GetPosOfItemInInventories(inv, id);
                            inv[id]=new ItemInvBasic16(i.Texture, i.Id, stay, z.X, z.Y);
                            mouseItem=new ItemInvBasic16(i.Texture, i.Id, c-stay, mouseRealPosX, mouseRealPosY);
                        }
                    }
                    return;

                    case ItemInvBasic32 i: {
                        int c = i.GetCount;
                        if (c==1) {
                            mouseItem=new ItemInvBasic32(i.Texture, i.Id, 1, mouseRealPosX, mouseRealPosY);
                            inv[id]=itemBlank;
                        }
                        else {
                            int stay = c/2;
                            ((ItemInvBasic32)inv[id]).SetCount=stay;
                            //	inv[id]=new ItemInvBasic32(i.Texture, i.Id, stay, mouseRealPosX, mouseRealPosY);
                            mouseItem=new ItemInvBasic32(i.Texture, i.Id, c-stay, mouseRealPosX, mouseRealPosY);
                        }
                    }
                    return;

                    case ItemInvFood16 i: {
                        int c = i.GetCount;
                        if (c==1) {
                            mouseItem=new ItemInvFood16(i.Texture, i.Id, 1, i.CountMaximum, i.GetDescay, i.DescayMaximum, mouseRealPosX, mouseRealPosY);
                            inv[id]=itemBlank;
                        }
                        else {
                            int stay = c/2;
                            inv[id]=new ItemInvFood16(i.Texture, i.Id, stay, i.CountMaximum, i.GetDescay, i.DescayMaximum, mouseRealPosX, mouseRealPosY);
                            mouseItem=new ItemInvFood16(i.Texture, i.Id, c-stay, i.CountMaximum, i.GetDescay, i.DescayMaximum, mouseRealPosX, mouseRealPosY);
                        }
                    }
                    return;

                    case ItemInvTool16 i: {
                        mouseItem=new ItemInvTool16(i.Texture, i.Id, 1, i.Maximum, mouseRealPosX, mouseRealPosY);
                        inv[id]=itemBlank;
                    }
                    return;

                    case ItemInvTool32 i: {
                        mouseItem=new ItemInvTool32(i.Texture, i.Id, 1, i.Maximum, mouseRealPosX, mouseRealPosY);
                        inv[id]=itemBlank;
                    }
                    return;

                    case ItemInvNonStackable16 i: {
                        mouseItem=new ItemInvNonStackable16(i.Texture, i.Id, mouseRealPosX, mouseRealPosY);
                        inv[id]=itemBlank;
                    }
                    return;

                    case ItemInvNonStackable32 i: {
                        mouseItem=new ItemInvNonStackable32(i.Texture, i.Id, mouseRealPosX, mouseRealPosY);
                        inv[id]=itemBlank;
                    }
                    return;

                    case ItemInvBasicColoritzed32NonStackable i: {
                        mouseItem=new ItemInvBasicColoritzed32NonStackable(i.Texture, i.Id, i.color, mouseRealPosX, mouseRealPosY);
                        inv[id]=itemBlank;
                    }
                    return;
                }
            }
        }
        void MakeCrafting(int c) {
            if (CanCraft(c)) {
                for (int g = 0; g<c; g++) {

                    CraftingIn[] slots = CurrentDeskCrafting[SelectedCraftingRecipe].Input;//selectedCraftingItem

                    foreach (CraftingIn d in slots) {
                        if (d.SelectedItem==-1) return;
                    }

                    foreach (CraftingIn d in slots) {
                        ItemNonInv item = d.ItemSlot[d.SelectedItem];
                        ushort id = item.Id;

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
                                    int remain = it.Count;
                                    for (int i = 0; i<maxInvCount; i++) {
                                        if (InventoryNormal[i].Id==id) {
                                            ItemInvBasic16 ininv = (ItemInvBasic16)InventoryNormal[i];
                                            if (ininv.GetCount<=remain) {
                                                remain-=ininv.GetCount;
                                                InventoryNormal[i]=itemBlank;
                                            }
                                            else {
                                                ininv.SetCount=ininv.GetCount-remain;
                                                remain=0;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else {
                                    int remain = it.Count;
                                    for (int i = 0; i<maxInvCount; i++) {
                                        if (InventoryNormal[i].Id==id) {
                                            ItemInvBasic32 ininv = (ItemInvBasic32)InventoryNormal[i];
                                            if (ininv.GetCount<=remain) {
                                                remain-=ininv.GetCount;
                                                InventoryNormal[i]=itemBlank;
                                            }
                                            else {
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
                                    for (int i = 0; i<maxInvCount; i++) {
                                        if (InventoryNormal[i].Id==id) {
                                            ItemInvNonStackable32 ininv = (ItemInvNonStackable32)InventoryNormal[i];
                                            InventoryNormal[i]=itemBlank;
                                        }
                                    }
                                }
                                break;

                            case ItemNonInvBasicColoritzedNonStackable it:
                                if (GameMethods.IsItemInvNonStackable32(id)) {
                                    for (int i = 0; i<maxInvCount; i++) {
                                        if (InventoryNormal[i].Id==id) {
                                            ItemInvBasicColoritzed32NonStackable ininv = (ItemInvBasicColoritzed32NonStackable)InventoryNormal[i];
                                            InventoryNormal[i]=itemBlank;
                                        }
                                    }
                                }
                                break;

                            case ItemNonInvTool it:
                                if (GameMethods.IsItemInvTool16(id)) {
                                    int remain = it.Count;
                                    for (int i = 0; i<maxInvCount; i++) {
                                        if (InventoryNormal[i].Id==id) {
                                            ItemInvTool16 ininv = (ItemInvTool16)InventoryNormal[i];
                                            if (ininv.GetCount<=remain) {
                                                remain-=ininv.GetCount;
                                                ushort newid = GameMethods.ToolToBasic(id);
                                                if (newid==0) InventoryNormal[i]=itemBlank;
                                                else InventoryNormal[i]=new ItemInvTool16(
                                                    ItemIdToTexture(id),
                                                    newid,
                                                    1,
                                                    //   GameMethods.ToolMax(id),
                                                    (int)ininv.posTex.X,
                                                    (int)ininv.posTex.Y
                                                );
                                            }
                                            else {
                                                ininv.SetCount=ininv.GetCount-remain;
                                                remain=0;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else {
                                    int remain = it.Count;
                                    for (int i = 0; i<maxInvCount; i++) {
                                        if (InventoryNormal[i].Id==id) {
                                            ItemInvTool32 ininv = (ItemInvTool32)InventoryNormal[i];
                                            if (ininv.GetCount<=remain) {
                                                remain-=ininv.GetCount;
                                                ushort newid = GameMethods.ToolToBasic(id);
                                                if (newid==0) InventoryNormal[i]=itemBlank;
                                                else InventoryNormal[i]=new ItemInvTool32(
                                                    ItemIdToTexture(id),
                                                    newid,
                                                    1,
                                                    //   GameMethods.ToolMax(id),
                                                    (int)ininv.posTex.X,
                                                    (int)ininv.posTex.Y
                                                );
                                            }
                                            else {
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

                    foreach (CraftingOut d in CurrentDeskCrafting[SelectedCraftingRecipe].Output) {//selectedCraftingItem
                        if (d.EveryTime) AddItemToPlayer(d.Item);
                        else {
                            if (FastRandom.Double()<d.ChanceToDrop) AddItemToPlayer(d.Item);
                        }
                        //if (d.EveryTime) ItemDrop(d.Item.X,d.Item.Y, PlayerX-11, PlayerY-16);
                        //else ItemDrop(d.Item.X,FastRandom.RandomInt(d.ChanceMin,d.ChanceMax), PlayerX-11, PlayerY-16);
                    }
                }
            }
            SetNeed();
        }

        DInt GetPosOfItemInInventories(ItemInv[] inv, int i) {
            if (IsSameArray(inv, InventoryNormal)) {
                DInt p = InventoryGetPosNormal(i);
                if (p is not null) return p;
            }
            if (inventory==InventoryType.BasicInv || inventory==InventoryType.Creative) {
                if (IsSameArray(inv, InventoryClothes)) {
                    DInt p = InventoryGetPosClothes(i);
                    if (p is not null) return p;
                }
            }
            if (inventory==InventoryType.BoxWooden) {
                if (IsSameArray(inv, ((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
                    DInt p = InventoryGetPosBoxWooden(i);
                    if (p is not null) return p;
                }
            }
            if (inventory==InventoryType.FurnaceStone) {
                if (IsSameArray(inv, ((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
                    DInt p = InventoryGetPosFurnaceStone(i);
                    if (p is not null) return p;
                }
            }
            if (inventory==InventoryType.BoxAdv) {
                if (IsSameArray(inv, ((BoxBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
                    DInt p = InventoryGetPosAdvBox(i);
                    if (p is not null) return p;
                }
            }
            if (inventory==InventoryType.Miner) {
                if (IsSameArray(inv, ((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
                    DInt p = InventoryGetPosBoxWooden(i);
                    if (p is not null) return p;
                }
            }
            if (inventory==InventoryType.Shelf || inventory==InventoryType.Composter) {
                if (IsSameArray(inv, ((ShelfBlock)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
                    DInt p = InventoryGetPosShelf(i);
                    if (p is not null) return p;
                }
            }
            if (inventory==InventoryType.Charger || inventory==InventoryType.OxygenMachine) {
                if (IsSameArray(inv, ((MashineBlockBasic)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
                    return new DInt { X=Global.WindowWidthHalf-300+38+40+4, Y=Global.WindowHeightHalf+20-2+40+25+4 };
                }
            }
            if (inventory==InventoryType.Barrel) {
                if (IsSameArray(inv, ((Barrel)terrain[selectedMashine.X].TopBlocks[selectedMashine.Y]).Inv)) {
                    DInt p = InventoryGetPosBarrel(i);
                    if (p is not null) return p;
                }
            }
#if DEBUG
            throw new Exception("Unknown move to position");
#else
        	return null;
#endif
        }


        void InvRemove() {
            //   invStartInventory[invStartId]=itemBlank;
            invMove=false;
            showMouseItemWhileMooving=false;
            mouseItem=itemBlank;
        }

        ItemInv ItemInvFromItemNonInv(ItemNonInv item) { 
            switch (item) { 
                case ItemNonInvBasic it: {
                    ushort id=it.Id;
                    if (GameMethods.IsItemInvBasic16(id)) return new ItemInvBasic16(ItemIdToTexture(id), id, it.Count);
                    else return new ItemInvBasic16(ItemIdToTexture(id), id, it.Count);
                }

                case ItemNonInvBasicColoritzedNonStackable it:{
                    ushort id=it.Id;
                    return new ItemInvBasicColoritzed32NonStackable(ItemIdToTexture(id), id, it.color);
                }

                case ItemNonInvFood it:{
                    ushort id=it.Id;
                    if (GameMethods.IsItemInvFood32(id)) return new ItemInvFood32(ItemIdToTexture(id), id, it.Count, it.CountMaximum, it.Descay, it.DescayMaximum,0,0);
                    else return new ItemInvFood16(ItemIdToTexture(id), id, it.Count, it.CountMaximum, it.Descay, it.DescayMaximum);
                }

                case ItemNonInvNonStackable it:{
                    ushort id=it.Id;
                    return new ItemInvNonStackable32(ItemIdToTexture(id), id);
                }

                case ItemNonInvTool it:{
                    ushort id=it.Id;
                    if (GameMethods.IsItemInvTool16(id)) return new ItemInvTool16(ItemIdToTexture(id), id, it.Count, it.Maximum);
                    else return new ItemInvTool32(ItemIdToTexture(id), id, it.Count, it.Maximum);
                }
            }            

            #if DFBUG
            throw new Exception();
            #else
            return new ItemInvBlank();
            #endif
        }
    }
}