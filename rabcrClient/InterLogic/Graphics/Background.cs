﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO;

namespace rabcrClient {
    enum BackBlockId:ushort {
        None,
        Skip,

        StoneGneiss,
        StoneDolomite,
        StoneRhyolite,
        StoneLimestone,
        StoneSchist,
        StoneBasalt,
        StoneDiorit,
        StoneSandstone,
        StoneGabbro,

        Cobblestone,
        Gravel,
        Sand,
        Dirt,

        GrassBlockPlains,
        GrassBlockHills,
        GrassBlockDesert,
        GrassBlockForest,
        GrassBlockJungle,

        Violet,
        Rose,
        Orchid,
        Dandelion,
        Alore,
        Heather,

        CactusBig,
        CactusSmall,

        Strawberry,
        Rashberry,
        Blueberry,

        Flax1,
        Flax2,
        Wheat1,
        Wheat2,

        Toadstool,
        Champignon,
        Boletus,

        Ice,
        Snow,
        SnowTop,
        Water,

        OakLeaves,
        OakWood,

        SpruceLeaves,
        SpruceWood,

        PineLeaves,
        PineWood,

        LindenLeaves,
        LindenWood,

        AppleLeaves,
        AppleLeavesWithApples,
        AppleWood,

        CherryLeaves,
        CherryLeavesWithCherries,
        CherryWood,

        PlumLeaves,
        PlumLeavesWithPlums,
        PlumWood,

        LemonWood,
        LemonLeaves,
        LemonLeavesWithLemons,

        OrangeWood,
        OrangeLeaves,
        OrangeLeavesWithOranges,

        //Grass
        GrassDesert,
        GrassJungle,
        GrassForest,
        GrassHills,
        GrassPlains,

        //Decorations
        Rocks,
        BranchWithout,
        BranchFull,
        BranchALittle,
    }

    class Background :IDisposable {
        public const int MaxIndex=25;
        readonly BlendState Multiply = new BlendState() {
            AlphaSourceBlend=Blend.Zero,
            AlphaDestinationBlend=Blend.SourceColor,
            ColorSourceBlend=Blend.Zero,
            ColorDestinationBlend=Blend.SourceColor
        };
        Rectangle[] lights;
        Matrix MatrixZoom;
        #region Varibles
        readonly GraphicsDevice Graphics;
        RenderTarget2D fogTarget;
Texture2D[] rocksTexture;
        #region Textures
        readonly Texture2D
            orangeWoodTexture,lightMaskLineTexture,
            lemonWoodTexture,
            orangeLeavesTexture,
            orangeLeavesWithOrangesTexture,
            lemonLeavesTexture,
            lemonLeavesWithLemonsTexture,
            branchWithoutTexture,
            branchALittle1Texture,
            branchFullTexture,
			snowTopTexture,
           // rocks1Texture,
           // rocks2Texture,
           // rocks3Texture,
            dirtTexture,
			gravelTexture,
			sandTexture,
			waterTexture,
			snowTexture,
			iceTexture,
			cobblestoneTexture,

			//Oak
			oakWoodTexture,
			oakLeavesTexture,

			//Pine
			pineWoodTexture,
			pineLeavesTexture,

			//Spruce
			spruceWoodTexture,
			spruceLeavesTexture,

			//Linden
			lindenWoodTexture,
			lindenLeavesTexture,

			//Apple
			appleWoodTexture,
			appleLeavesTexture,
			appleLeavesWithApplesTexture,

			//Plum
			plumWoodTexture,
			plumLeavesTexture,
			plumLeavesWithPlumsTexture,

			//Cherry
			cherryWoodTexture,
			cherryLeavesTexture,
			cherryLeavesWithCherriesTexture,

			//GrassBlock
			grassBlockPlainsTexture,
			grassBlockHillsTexture,
			grassBlockForestTexture,
			grassBlockDesertTexture,
			grassBlockJungleTexture,

			// Plants
			plantAloreTexture,

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

            lightmap,

            boletusTexture,

            toadstoolTexture,
            champignonTexture,

            heatherTexture,


            dolomiteTexture,
            basaltTexture,
            limestoneTexture,
            rhyoliteTexture,
            gneissTexture,
            sandstoneTexture,
            schistTexture,
            gabbroTexture,
            dioritTexture;
        #endregion

        int startIndex ,endIndex;

        Matrix Translation;

        float WindowX;
        int WindowY;
        float WindowCenterX;
        int WindowCenterY;
        int lastWindowW, lastWindowH;
        readonly BTerrain[] terrain;
        readonly int BGChunkLenght;
        #endregion

        public Background(GraphicsDevice Graphics) {
            this.Graphics=Graphics;
            lights=new Rectangle[0];
            MatrixZoom=Matrix.CreateScale(Setting.Zoom, Setting.Zoom, 0);
            Translation = MatrixZoom * Matrix.CreateTranslation(new Vector3(Global.WindowWidthHalf, Global.WindowHeightHalf, 0));

            BGChunkLenght=int.Parse(File.ReadAllText(Setting.Path+"\\MenuBackgroundChunks.txt"));
            terrain =new BTerrain[BGChunkLenght];

            WindowX=Rabcr.random.Int(BGChunkLenght*16);
            WindowY =848-Global.WindowHeightHalf-150;
            WindowCenterY=WindowY+Global.WindowHeightHalf;

            if (Global.WindowWidth==0 || Global.WindowHeight==0){
                fogTarget =new RenderTarget2D(Graphics, 1, 1);
            } else {
                fogTarget =new RenderTarget2D(Graphics, Global.WindowWidth, Global.WindowHeight);
            }

            lightMaskLineTexture=GetDataTexture("Particles/lightMaskLine");

            heatherTexture=GetDataTexture("Plants/Flowers/Heather");
            toadstoolTexture=GetDataTexture("Plants/Mushrooms/Toadstoll");
            champignonTexture=GetDataTexture("Plants/Mushrooms/Champignon");
            lightmap=GetDataTexture("Particles/lightMask");
            boletusTexture=GetDataTexture("Plants/Mushrooms/Boletus");

            orangeLeavesTexture=GetDataTexture("Blocks/TreeBlocks/Orange/Leaves");
            orangeLeavesWithOrangesTexture=GetDataTexture("Blocks/TreeBlocks/Orange/LeavesWithOranges");
            orangeWoodTexture=GetDataTexture("Blocks/TreeBlocks/Orange/Wood");
            lemonWoodTexture=GetDataTexture("Blocks/TreeBlocks/Lemon/Wood");
            lemonLeavesTexture=GetDataTexture("Blocks/TreeBlocks/Lemon/Leaves");
            lemonLeavesWithLemonsTexture=GetDataTexture("Blocks/TreeBlocks/Lemon/LeavesWithLemons");

			dirtTexture = GetDataTexture("Blocks/BasicBlocks/Dirt");
			gravelTexture = GetDataTexture("Blocks/BasicBlocks/Gravel");

			sandTexture = GetDataTexture("Blocks/BasicBlocks/Sand");
			waterTexture = GetDataTexture("Blocks/BasicBlocks/Water");
			iceTexture = GetDataTexture("Blocks/BasicBlocks/Ice");
			snowTexture = GetDataTexture("Blocks/BasicBlocks/Snow");
			snowTopTexture = GetDataTexture("Blocks/BasicBlocks/SnowTop");
			cobblestoneTexture = GetDataTexture("Blocks/BasicBlocks/Cobblestone");

			grassBlockPlainsTexture = GetDataTexture("Blocks/GrassBlocks/Plains");
			grassBlockHillsTexture = GetDataTexture("Blocks/GrassBlocks/Hills");
			grassBlockJungleTexture = GetDataTexture("Blocks/GrassBlocks/Jungle");
			grassBlockForestTexture = GetDataTexture("Blocks/GrassBlocks/Forest");
			grassBlockDesertTexture = GetDataTexture("Blocks/GrassBlocks/Desert");
			plantAloreTexture = GetDataTexture("Plants/Flowers/Alore");
			grassForestTexture = GetDataTexture("Plants/Grass/Forest");
			grassPlainsTexture = GetDataTexture("Plants/Grass/Plains");
			grassJungleTexture = GetDataTexture("Plants/Grass/Jungle");
			grassDesertTexture = GetDataTexture("Plants/Grass/Desert");
			grassHillsTexture = GetDataTexture("Plants/Grass/Hills");

			plantDandelionTexture = GetDataTexture("Plants/Flowers/Dandelion");
			plantOrchidTexture = GetDataTexture("Plants/Flowers/Orchid");
			plantRoseTexture = GetDataTexture("Plants/Flowers/Rose");
			plantVioletTexture = GetDataTexture("Plants/Flowers/Violet");
			cactusLittleTexture = GetDataTexture("Plants/Cactus/Small");
			cactusBigTexture = GetDataTexture("Plants/Cactus/Big");

            rocksTexture=new Texture2D[]{
                GetDataTexture("Blocks/BasicBlocks/Rocks1"),
                GetDataTexture("Blocks/BasicBlocks/Rocks2"),
                GetDataTexture("Blocks/BasicBlocks/Rocks3"),
            };
            oakWoodTexture = GetDataTexture("Blocks/TreeBlocks/Oak/Wood");
			oakLeavesTexture = GetDataTexture("Blocks/TreeBlocks/Oak/Leaves");
			pineWoodTexture = GetDataTexture("Blocks/TreeBlocks/Pine/Wood");
			pineLeavesTexture = GetDataTexture("Blocks/TreeBlocks/Pine/Leaves");
			spruceWoodTexture = GetDataTexture("Blocks/TreeBlocks/Spruce/Wood");
			spruceLeavesTexture = GetDataTexture("Blocks/TreeBlocks/Spruce/Leaves");
			lindenWoodTexture = GetDataTexture("Blocks/TreeBlocks/Linden/Wood");
			lindenLeavesTexture = GetDataTexture("Blocks/TreeBlocks/Linden/Leaves");
			appleWoodTexture = GetDataTexture("Blocks/TreeBlocks/Apple/Wood");
			appleLeavesTexture = GetDataTexture("Blocks/TreeBlocks/Apple/Leaves");
			appleLeavesWithApplesTexture = GetDataTexture("Blocks/TreeBlocks/Apple/LeavesWithApples");
			plumWoodTexture = GetDataTexture("Blocks/TreeBlocks/Plum/Wood");
			plumLeavesTexture = GetDataTexture("Blocks/TreeBlocks/Plum/Leaves");
			plumLeavesWithPlumsTexture = GetDataTexture("Blocks/TreeBlocks/Plum/LeavesWithPlums");
			cherryWoodTexture = GetDataTexture("Blocks/TreeBlocks/Cherry/Wood");
			cherryLeavesTexture = GetDataTexture("Blocks/TreeBlocks/Cherry/Leaves");
			cherryLeavesWithCherriesTexture = GetDataTexture("Blocks/TreeBlocks/Cherry/LeavesWithCherries");

            dolomiteTexture=GetDataTexture("Blocks/BasicBlocks/Dolomite");
            basaltTexture=GetDataTexture("Blocks/BasicBlocks/Basalt");
            limestoneTexture=GetDataTexture("Blocks/BasicBlocks/Limestone");
            rhyoliteTexture=GetDataTexture("Blocks/BasicBlocks/Rhyolite");
            gneissTexture=GetDataTexture("Blocks/BasicBlocks/Gneiss");
            sandstoneTexture=GetDataTexture("Blocks/BasicBlocks/Sandstone");
            schistTexture=GetDataTexture("Blocks/BasicBlocks/Schist");
            gabbroTexture=GetDataTexture("Blocks/BasicBlocks/Gabbro");
            dioritTexture=GetDataTexture("Blocks/BasicBlocks/Diorit");

            branchWithoutTexture=GetDataTexture("Plants/Branch/Without");
            branchALittle1Texture=GetDataTexture("Plants/Branch/Little1");

            branchFullTexture=GetDataTexture("Plants/Branch/Full");

            Load();
        }

        public void Update(GameTime gameTime) {
            if (lastWindowW!=Global.WindowWidth || lastWindowH!=Global.WindowHeight) {
                lastWindowW=Global.WindowWidth;
                lastWindowH=Global.WindowHeight;

                WindowY=240 - Global.WindowHeightHalf;
                WindowCenterY=WindowY+Global.WindowHeightHalf;

                fogTarget?.Dispose();

                if (Global.WindowWidth==0 || Global.WindowHeight==0) {
                    fogTarget =new RenderTarget2D(Graphics, 1, 1);
                } else {
                    fogTarget =new RenderTarget2D(Graphics, Global.WindowWidth, Global.WindowHeight);
                }

                Translation = MatrixZoom * Matrix.CreateTranslation(new Vector3(Global.WindowWidthHalf, Global.WindowHeightHalf, 0));
            }

            if (WindowX>BGChunkLenght*16-100-Global.WindowWidth) WindowX=10;

            WindowX+=(float)(gameTime.ElapsedGameTime.TotalMilliseconds/1000*60);
            WindowCenterX = WindowX+Global.WindowWidthHalf;

            int delta = (int)((Global.WindowWidth-Global.WindowWidth/Setting.Zoom)/2f);
            if (delta<0)delta=0;

            int start = ((int)WindowX)/16-1;
            if (start<0) start=0;
            startIndex=start+delta/16;
            endIndex=start+(Global.WindowWidth-delta)/16+3;
            if (endIndex>=terrain.Length)endIndex=0;
            
            lights=new Rectangle[endIndex-startIndex];
            for (int x=startIndex; x<endIndex; x++)  {
                int l16=terrain[x].LightPos16;
                if (WindowY<l16+8) lights[x-startIndex]=new Rectangle(x*16-40, WindowY, 16+40+40, l16-WindowY);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {

            #region Set draw vars
            Matrix camera = CameraMatrix();
            Rabcr.spriteBatch=spriteBatch;
            #endregion

            if (startIndex>=0 && startIndex<terrain.Length){
            if (terrain[startIndex]!=null) {

                #region Draw lighting
                Graphics.SetRenderTarget(fogTarget);
                Graphics.Clear(Color.Black);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive,SamplerState.PointClamp, null, null, null, camera);

                for (int x= startIndex; x<endIndex; x++) spriteBatch.Draw(lightmap, terrain[x].LightVec, Color.White);

                for (int i = 0; i<lights.Length; i++) spriteBatch.Draw(lightMaskLineTexture, lights[i], Color.White); 

                spriteBatch.End();
                #endregion

                #region Draw game
                Graphics.SetRenderTarget(null);
                Graphics.Clear(Color.LightSkyBlue);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera);

                for (int x = startIndex; x<endIndex; x++) {
                    BTerrain chunk=terrain[x];
                    for (int y =chunk.StartSomething; y<chunk.LightPos+4; y++) {

                        if (chunk.IsSolidBlocks[y]) chunk.SolidBlocks[y].Draw();
                        else{
                            if (chunk.IsBackground[y]) chunk.Background[y].Draw();
                            if (chunk.IsTopBlocks[y]) chunk.TopBlocks[y].Draw();
                        }
                    }
                }
                spriteBatch.End();

                // Draw lighting on game
                spriteBatch.Begin(SpriteSortMode.Deferred, Multiply);
                spriteBatch.Draw(fogTarget, Vector2.Zero, Color.White);
                spriteBatch.End();
            }
            #endregion

            } else {
                WindowX=0;
            }
        }

        public void Refresh() {
            MatrixZoom=Matrix.CreateScale(Setting.Zoom, Setting.Zoom, 0);
            Translation=MatrixZoom*Matrix.CreateTranslation(new Vector3(Global.WindowWidthHalf, Global.WindowHeightHalf, 0));
        }

        BBlock BackBlockFromId(byte type, Vector2 pos) {
            switch ((BackBlockId)type) {
                case BackBlockId.AppleWood: return new BBlockNormal{Texture=appleWoodTexture, Pos=pos };
                case BackBlockId.CherryWood: return new BBlockNormal{Texture=cherryWoodTexture, Pos=pos };
                case BackBlockId.LemonWood: return new BBlockNormal{Texture=lemonWoodTexture, Pos=pos };
                case BackBlockId.LindenWood: return new BBlockNormal{Texture=lindenWoodTexture, Pos=pos };
                case BackBlockId.OakWood: return new BBlockNormal{Texture=oakWoodTexture, Pos=pos };
                case BackBlockId.OrangeWood: return new BBlockNormal{Texture=orangeWoodTexture, Pos=pos };
                case BackBlockId.PineWood: return new BBlockNormal{Texture=pineWoodTexture, Pos=pos };
                case BackBlockId.PlumWood: return new BBlockNormal{Texture=plumWoodTexture, Pos=pos };
                case BackBlockId.SpruceWood: return new BBlockNormal{Texture=spruceWoodTexture, Pos=pos };
            }

            return null;
        }

        BBlock SolidBlockFromId(byte type, Vector2 pos) {
            switch ((BackBlockId)type) {
                case BackBlockId.StoneBasalt: return new BBlockNormal{ Texture=basaltTexture, Pos=pos };
                case BackBlockId.StoneDiorit: return new BBlockNormal{ Texture=dioritTexture, Pos=pos };
                case BackBlockId.StoneDolomite: return new BBlockNormal{ Texture=dolomiteTexture, Pos=pos };
                case BackBlockId.StoneGabbro: return new BBlockNormal{ Texture=gabbroTexture, Pos=pos };
                case BackBlockId.StoneGneiss: return new BBlockNormal{ Texture=gneissTexture, Pos=pos };
                case BackBlockId.StoneLimestone: return new BBlockNormal{ Texture=limestoneTexture, Pos=pos };
                case BackBlockId.StoneRhyolite: return new BBlockNormal{ Texture=rhyoliteTexture, Pos=pos };
                case BackBlockId.StoneSandstone: return new BBlockNormal{ Texture=sandstoneTexture, Pos=pos };
                case BackBlockId.StoneSchist: return new BBlockNormal{ Texture=schistTexture, Pos=pos };

                case BackBlockId.Cobblestone: return new BBlockNormal{ Texture=cobblestoneTexture, Pos=pos };
                case BackBlockId.Gravel: return new BBlockNormal{ Texture=gravelTexture, Pos=pos };
                case BackBlockId.Sand: return new BBlockNormal{ Texture=sandTexture, Pos=pos };
                case BackBlockId.Dirt: return new BBlockNormal{ Texture=dirtTexture, Pos=pos };

                case BackBlockId.Ice: return new BBlockNormal{ Texture=iceTexture, Pos=pos };

                case BackBlockId.GrassBlockDesert: return new BBlockNormal{Texture=grassBlockDesertTexture, Pos=pos };
                case BackBlockId.GrassBlockForest: return new BBlockNormal{ Texture=grassBlockForestTexture, Pos=pos };
                case BackBlockId.GrassBlockHills: return new BBlockNormal{ Texture=grassBlockHillsTexture, Pos=pos };
                case BackBlockId.GrassBlockJungle: return new BBlockNormal{ Texture=grassBlockJungleTexture, Pos=pos };
                case BackBlockId.GrassBlockPlains: return new BBlockNormal{ Texture=grassBlockPlainsTexture, Pos=pos };

                case BackBlockId.Snow: return new BBlockNormal{ Texture=snowTexture, Pos=pos };
            }
            return null;
        }

        BBlock TopBlockFromId(byte type, Vector2 pos) {
            switch ((BackBlockId)type) {
                case BackBlockId.Water: return new BBlockNormal{ Texture=waterTexture, Pos=pos };
                case BackBlockId.OakLeaves: return new BBlockNormal{ Texture=oakLeavesTexture, Pos=pos };
                case BackBlockId.SpruceLeaves: return new BBlockNormal{ Texture=spruceLeavesTexture, Pos=pos };
                case BackBlockId.PineLeaves: return new BBlockNormal{ Texture=pineLeavesTexture, Pos=pos };
                case BackBlockId.SnowTop: return new BBlockNormal{ Texture=snowTopTexture, Pos=pos };
                case BackBlockId.AppleLeaves: return new BBlockNormal{ Texture=appleLeavesTexture, Pos=pos };
                case BackBlockId.LemonLeavesWithLemons: return new BBlockNormal{ Texture=lemonLeavesWithLemonsTexture, Pos=pos };
                case BackBlockId.LindenLeaves: return new BBlockNormal{ Texture=lindenLeavesTexture, Pos=pos };

                case BackBlockId.OrangeLeaves: return new BBlockNormal{ Texture=orangeLeavesTexture, Pos=pos };

                case BackBlockId.PlumLeavesWithPlums: return new BBlockNormal{ Texture=plumLeavesWithPlumsTexture, Pos=pos };
                case BackBlockId.PlumLeaves: return new BBlockNormal{ Texture=plumLeavesTexture, Pos=pos };

                case BackBlockId.OrangeLeavesWithOranges: return new BBlockNormal{ Texture=orangeLeavesWithOrangesTexture, Pos=pos };
                case BackBlockId.AppleLeavesWithApples: return new BBlockNormal{ Texture=appleLeavesWithApplesTexture, Pos=pos };
                case BackBlockId.CherryLeaves: return new BBlockNormal{ Texture=cherryLeavesTexture, Pos=pos };
                case BackBlockId.CherryLeavesWithCherries: return new BBlockNormal{ Texture=cherryLeavesWithCherriesTexture, Pos=pos };
                case BackBlockId.LemonLeaves: return new BBlockNormal{ Texture=lemonLeavesTexture, Pos=pos };


                case BackBlockId.GrassDesert: return new BBlockNormal{ Texture=grassDesertTexture, Pos=pos };
                case BackBlockId.GrassForest: return new BBlockNormal{ Texture=grassForestTexture, Pos=pos };
                case BackBlockId.GrassHills: return new BBlockNormal{ Texture=grassHillsTexture, Pos=pos };
                case BackBlockId.GrassJungle: return new BBlockNormal{ Texture=grassJungleTexture, Pos=pos };
                case BackBlockId.GrassPlains: return new BBlockNormal{ Texture=grassPlainsTexture, Pos=pos };


                case BackBlockId.Violet: return new BBlockNormal{ Texture=plantVioletTexture, Pos=pos };
                case BackBlockId.Dandelion: return new BBlockNormal{ Texture=plantDandelionTexture, Pos=pos };
                case BackBlockId.Heather: return new BBlockNormal{ Texture=heatherTexture, Pos=pos };
                case BackBlockId.Alore: return new BBlockNormal{ Texture=plantAloreTexture, Pos=pos };
                case BackBlockId.CactusBig: return new BBlockNormal{ Texture=cactusBigTexture, Pos=pos };
                case BackBlockId.CactusSmall: return new BBlockNormal{ Texture=cactusLittleTexture, Pos=pos };


                case BackBlockId.BranchALittle: return new BBlockNormal{ Texture=branchALittle1Texture, Pos=pos };

                case BackBlockId.Orchid: return new BBlockNormal{ Texture=plantOrchidTexture, Pos=pos };

                case BackBlockId.Rose: return new BBlockNormal{ Texture=plantRoseTexture, Pos=pos };


                case BackBlockId.Boletus: return new BBlockNormal{ Texture=boletusTexture, Pos=pos };

                case BackBlockId.BranchFull: return new BBlockNormal{ Texture=branchFullTexture, Pos=pos };
                case BackBlockId.BranchWithout: return new BBlockNormal{ Texture=branchWithoutTexture, Pos=pos };
                case BackBlockId.Champignon: return new BBlockNormal{ Texture=champignonTexture, Pos=pos };

                case BackBlockId.Toadstool: return new BBlockNormal{ Texture=toadstoolTexture,  Pos=pos };

                case BackBlockId.Rocks:return new BBlockNormal{ Texture=rocksTexture[Rabcr.random.Int(3)], Pos=pos };
            }
            return null;
        }

		Texture2D GetDataTexture(string path) => Rabcr.Game.Content.Load<Texture2D>(Setting.StyleName+"\\Textures\\"+path);

        Matrix CameraMatrix() {
            if (Setting.Scale.Without == Setting.currentScale) return Matrix.CreateTranslation(new Vector3(-WindowCenterX, -WindowCenterY, 0)) * Translation;

            if (Setting.Scale.Proportions == Setting.currentScale) {
                float _screenScaleW = Global.WindowWidth / 848f;
                float _screenScaleH = Global.WindowHeight / 560f;

                if (_screenScaleH > _screenScaleW) {
                    return Matrix.CreateTranslation(new Vector3(-WindowCenterX, -WindowCenterY, 0)) *
                        MatrixZoom*
                        Matrix.CreateScale(_screenScaleW, _screenScaleW, 0) *
                        Matrix.CreateTranslation(new Vector3(Global.WindowWidthHalf, Global.WindowHeightHalf, 0));
                } else {
                    return Matrix.CreateTranslation(new Vector3(-WindowCenterX, -WindowCenterY, 0)) *
                        MatrixZoom*
                        Matrix.CreateScale(_screenScaleH, _screenScaleH, 0) *
                        Matrix.CreateTranslation(new Vector3(Global.WindowWidthHalf, Global.WindowHeightHalf, 0));
                }
            }

            return Matrix.CreateTranslation(new Vector3(-WindowCenterX, -WindowCenterY, 0)) *
                Matrix.CreateScale(new Vector3(Global.WindowWidth / 848f, Global.WindowHeight / 560f, 0)) *
                MatrixZoom *
                Matrix.CreateTranslation(new Vector3(Global.WindowWidthHalf, Global.WindowHeightHalf, 0));
        }

        bool isDisposed;

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing){
            if (isDisposed) return;

            Multiply?.Dispose();
            fogTarget?.Dispose();

            isDisposed = true;
        }

        ~Background() => Dispose(false);

        void Load() {
            if (File.Exists(Setting.Path+"\\MenuBackground.ter")) {
                using (StreamReader sr = new StreamReader(Setting.Path+"\\MenuBackground.ter")) {
                    for (int pos=0; pos<terrain.Length; pos++) {
                        BinaryReader br = new BinaryReader(sr.BaseStream);

                        BTerrain chunk=terrain[pos]=new BTerrain() {
                            LightPos=br.ReadByte(),
                        };

                        chunk.LightVec=new Vector2(pos*16-48+8,chunk.LightPos*16-48+8+40);
                        chunk.LightPos16=chunk.LightPos*16;
                        int ss=MaxIndex;

                        //0=nic
                        //1=připrav se, další byte o přeskočení

                        // BackBlocks
                        for (int lenght=0; lenght<MaxIndex; lenght++) {
                            byte input = br.ReadByte();

                            if (input>1){
                                BBlock block=BackBlockFromId(input, new Vector2(pos*16, lenght*16));
                                if (block!=null){
                                    if (ss>lenght) ss=lenght;
                                    chunk.Background[lenght]=block;
                                    chunk.IsBackground[lenght]=true;
                                }else chunk.Background[lenght]=new BBlockEmpty();
                            } else if (input==1) {
                                int skip=br.ReadByte();
                                int to=lenght+skip;
                                for (int i=lenght; i<to; i++) chunk.Background[i]=new BBlockEmpty();
                                lenght+=skip-1;
                            } else if (input==0) chunk.Background[lenght]=new BBlockEmpty();
                        }

                        // TopBlocks
                        for (int lenght=0; lenght<MaxIndex; lenght++) {
                            byte input = br.ReadByte();

                            if (input>1){
                                BBlock block=TopBlockFromId(input, new Vector2(pos*16, lenght*16));
                                if (block!=null){
                                    if (ss>lenght) ss=lenght;
                                    chunk.IsTopBlocks[lenght]=true;
                                    chunk.TopBlocks[lenght]=block;
                                } else {
                                    chunk.TopBlocks[lenght]=new BBlockEmpty();
                                }
                            } else if (input==1) {
                                int skip=br.ReadByte();
                                int to=lenght+skip;
                                for (int i=lenght; i<to; i++) chunk.TopBlocks[i]=new BBlockEmpty();
                                lenght+=skip-1;
                            } else if (input==0) chunk.TopBlocks[lenght]=new BBlockEmpty();
                        }

                        // SolidBlocks
                        for (int lenght=0; lenght<MaxIndex; lenght++) {
                            byte input = br.ReadByte();

                            if (input>1){
                                BBlock block=SolidBlockFromId(input, new Vector2(pos*16, lenght*16));
                                if (block!=null){
                                    if (ss>lenght) ss=lenght;
                                    chunk.SolidBlocks[lenght]=block;
                                    chunk.IsSolidBlocks[lenght]=true;
                                } else {
                                   // chunk.SolidBlocks[lenght]=new BBlockEmptySolid(){
                                      //  /*Back=*/chunk.Background[lenght];
                                      //  /*Top=*/chunk.TopBlocks[lenght];
                                    //};
                                }
                            } else if (input==1){
                                int skip=br.ReadByte();
                               // int to=lenght+skip;
                                //for (int i=lenght; i<to; i++) chunk.SolidBlocks[i]=new BBlockEmptySolid(){
                                //    Back=chunk.Background[i],
                                //    Top=chunk.TopBlocks[i]
                                //};
                                lenght+=skip-1;
                            } else if (input==0){
                                //chunk.SolidBlocks[lenght]=new BBlockEmptySolid(){
                                //    Back=chunk.Background[lenght],
                                //    Top=chunk.TopBlocks[lenght]
                                //};
                            }
                        }

                        if (sr.BaseStream.Position==sr.BaseStream.Length)break;

                        chunk.StartSomething=(byte)ss;
                    }
                }
            }
        }
    }

    public class BGenerateWorld {

        #region Varibles
        readonly List<BGChunk> terrain = new List<BGChunk>();
        List<byte> biomes;

        bool seabedSand;
        int seabedChange = 10;
        byte terrainHeight = 18;
        int terrainChange = 2;
        int pos = 0;
        int generatePos;

        int dirtChange = 2;

        int level1Type = 0;

        int level1Lenght = 0;

        byte dirtHeight = 4;

        bool grass = true;
      //  bool hill = true;
        int treeChange = 9;
        readonly FastRandom random;
       // int state;
        int biomeSize;
 const int waterHeight=20;
        public bool Finish = false;
        public bool NotStarted = true;
        #endregion

        public BGenerateWorld() {
            //pathWorld=Setting.Path+"MenuWorld";
         //   state=0;
            //type=ntype;
            random=Rabcr.random;
        }

        public void Action() {
            GenerateEarth();
        }

        void GenerateEarth() {
          //  state++;
            #if DEBUG
            DateTime now = DateTime.Now;
            #endif

           // if (!Directory.Exists(Setting.Path+"MenuWorld")) Directory.CreateDirectory(Setting.Path+"MenuWorld");
            generatePos=0;

            // Biomes
            biomes=new List<byte>();
            for (byte i = 1; i<11; i++) {
                byte DInt;
                if (random.Int(11)==1) DInt=0;
                else DInt=i;
                biomes.Add(DInt);
            }

            for (byte i = 11; i>0; i--) {
                byte DInt;
                if (random.Int(11)==1) DInt=0;
                else DInt=i;
                biomes.Add(DInt);
            }

            for (byte i = 0; i<11; i++) {
                byte DInt;
                if (random.Int(11)==1) DInt=0;
                else DInt=i;
                biomes.Add(DInt);
            }

            for (byte i = 11; i>0; i--) {
                byte DInt;
                if (random.Int(11)==1) DInt=0;
                else DInt=i;
                biomes.Add(DInt);
            }
          //  state++;

            terrain.Add(new BGChunk());
            terrain.Add(new BGChunk());
            terrain.Add(new BGChunk());
            terrain.Add(new BGChunk());
            terrain.Add(new BGChunk());
            terrain.Add(new BGChunk());
            terrain.Add(new BGChunk());

            //state++;
            biomeSize=100;

            // generate
            foreach (byte biome in biomes) {
                switch (biome) {
                    case 0:
                        BiomeBeachDown();
                        BiomeOcean();
                        BiomeOceanUp();
                        BiomeBeachUp();
                        break;

                    case 1:
                        BiomePoles();
                        break;

                    case 2:
                        BiomeTundra();
                        break;

                    case 3:
                        BiomeTaiga();
                        break;

                    case 4:
                        BiomeSpruceForest();
                        break;

                    case 5:
                        BiomeBothForest();
                        break;

                    case 6:
                        BiomeLeaveForest();
                        break;

                    case 7:
                        BiomePlains();
                        break;

                    case 8:
                        BiomeSubtropics();
                        break;

                    case 9:
                        BiomeDesert();
                        break;

                    case 10:
                        BiomeSavana();
                        break;

                    case 11:
                        BiomeJungle();
                        break;
                }
            }


            // Save
            Save();
            File.WriteAllText(Setting.Path+"\\MenuBackgroundChunks.txt", (terrain.Count-7).ToString());
            Finish=true;
            #if DEBUG
            Console.WriteLine("Vygenerováno za "+(((DateTime.Now-now).TotalMilliseconds)/1000f).ToString(".000")+"s");
            #endif
        }

        #region Biomes
        void BiomeOcean() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight+3) terrainHeight--;
                    else if (terrainHeight<waterHeight+6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=4+random.Int(5);
                } else terrainChange--;

                if (seabedChange<0) {
                    seabedSand=!seabedSand;
                    seabedChange=10+random.Int(20);
                } else seabedChange--;

                chunk.LightPos=waterHeight;

                // Water
                for (int yy = waterHeight; yy<terrainHeight; yy++) {
                    chunk.TopBlocks[yy]=(byte)BackBlockId.Water;
                    //if (random.Int(10)==1) chunk.Blocks[yy]=(byte)BackBlockId.Fish;
                }

                // Seabed
                if (seabedSand) chunk.Blocks[terrainHeight]=(byte)BackBlockId.Sand;
                else chunk.Blocks[terrainHeight]=(byte)BackBlockId.Gravel;

                // Lithosphere
                GenerateUnderSurface(chunk, terrainHeight+1);
            }
            generatePos+=biomeSize;
        }

        void BiomeOceanUp() {
            for (; terrainHeight>waterHeight; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];
                generatePos++;

                // BGChunk height
                if (terrainChange<0) {
                    terrainHeight--;
                    terrainChange=3+random.Int(3);
                } else terrainChange--;

                chunk.LightPos=waterHeight;

                // Water
                for (int yy = waterHeight; yy<terrainHeight; yy++) {
                    chunk.TopBlocks[yy]=(byte)BackBlockId.Water;
                    //if (random.Int(10)==1) chunk.TopBlocks[yy]=(byte)BackBlockId.Fish;
                }


                // Seabed
                if (seabedSand) chunk.Blocks[terrainHeight]=(byte)BackBlockId.Sand;
                else chunk.Blocks[terrainHeight]=(byte)BackBlockId.Gravel;

                if (seabedChange<0) {
                    seabedSand=!seabedSand;
                    seabedChange=10+random.Int(20);
                } else seabedChange--;

                // Lithosphere
                GenerateUnderSurface(chunk, terrainHeight+1);
            }
        }

        void BiomeBeachDown() {
            for (; terrainHeight/*+2*/<waterHeight; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];
                generatePos++;

                // BGChunk height
                if (terrainChange<0) {
                    terrainHeight++;
                    terrainChange=1+random.Int(3);
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                // Sand
                if (seabedSand) {
                    for (int yy = terrainHeight; yy<terrainHeight+dirtHeight; yy++) chunk.Blocks[yy]=(byte)BackBlockId.Sand;
                } else {
                    for (int yy = terrainHeight; yy<terrainHeight+dirtHeight; yy++) chunk.Blocks[yy]=(byte)BackBlockId.Gravel;
                }

                GenerateUnderSurface(chunk, dirtHeight+terrainHeight);
            }
        }

        void BiomeBeachUp() {
            for (; terrainHeight>waterHeight; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];
                generatePos++;

                // BGChunk height
                if (terrainChange<0) {
                    terrainHeight--;

                    terrainChange=1+random.Int(3);
                } else terrainChange--;

                // Sand height
                if (dirtHeight<0) {
                    if (dirtHeight>waterHeight+1) terrainHeight--;
                    else if (terrainHeight>waterHeight+4) terrainHeight--;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                // Sand
                if (seabedSand) {
                    for (int yy = terrainHeight; yy<terrainHeight+dirtHeight; yy++) chunk.BackBlocks[yy]=(byte)BackBlockId.Sand;
                } else {
                    for (int yy = terrainHeight; yy<terrainHeight+dirtHeight; yy++) chunk.BackBlocks[yy]=(byte)BackBlockId.Gravel; ;
                }

                // Lithosphere
                GenerateUnderSurface(chunk, dirtHeight+terrainHeight);
            }
        }

        void BiomePoles() {
            for (; pos<generatePos+biomeSize; pos++) {
                terrain.Add(new BGChunk());
                BGChunk BGChunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+random.Int(3);
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                BGChunk.LightPos=terrainHeight;

                BGChunk.Blocks[terrainHeight]=(byte)BackBlockId.Snow;

                if (random.Bool_33_333Percent()) BGChunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.SnowTop;

                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) BGChunk.Blocks[b]=(byte)BackBlockId.Ice;

                GenerateUnderSurface(BGChunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeTundra() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }
                    terrainChange=4+random.Int(5);
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                if (random.Bool()) {
                    chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockHills;
                    if (random.Int(5)==1) {
                        if (random.Bool()) chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Heather;
                        else chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassHills;
                    }
                } else {
                    if (random.Bool()) chunk.Blocks[terrainHeight]=(byte)BackBlockId.Ice;
                    else chunk.TopBlocks[terrainHeight]=(byte)BackBlockId.Snow;

                    if (random.Int(3)==1) chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.SnowTop;
                }

                for (int b = terrainHeight+1; b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Ice;

                // Lithosphere
                if (random.Bool()) {
                    chunk.Blocks[dirtHeight+terrainHeight]=(byte)BackBlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeTaiga() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                // BGChunk BGChunk=terrain[pos];
                BGChunk chunk = terrain[pos];
                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-5) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=4+random.Int(5);
                } else terrainChange--;

                // Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockHills;

                if (random.Bool()) {
                    switch (random.Int(9)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Heather;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassHills;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassHills;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.BranchFull;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassHills;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassHills;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Blueberry;
                            break;


                        case 9:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassHills;
                            break;
                    }
                }

                if (treeChange<0) {
                    if (random.Bool_20Percent()) TreeSpruceLittle(pos, terrainHeight);
                    else TreeSpruceBig(pos, terrainHeight);
                } else treeChange--;

                for (int b = terrainHeight+1; b<dirtHeight+terrainHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Dirt;

                // Lithosphere
                if (random.Bool()) {
                    chunk.Blocks[dirtHeight+terrainHeight]=(byte)BackBlockId.Cobblestone;
                    GenerateUnderSurface(chunk, dirtHeight+1+terrainHeight);
                } else GenerateUnderSurface(chunk, dirtHeight+terrainHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeSpruceForest() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+random.Int(3);
                } else terrainChange--;

                //Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockForest;

                if (random.Bool()) {
                    switch (random.Int(9)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Blueberry;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Dandelion;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rashberry;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                            break;

                        case 9:
                            switch (random.Int4()) {
                                case 2:
                                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Toadstool;
                                    break;
                            }
                            break;
                    }
                }

                if (treeChange<0) {
                    switch (random.Int(3)) {
                        case 1:
                            TreeSpruceLittle(pos, terrainHeight);
                            break;
                        //case 2:
                        //    TreeOakLittle(pos, terrainHeight);
                        //    break;
                        case 2:
                            TreeSpruceBig(pos, terrainHeight);
                            break;
                            //case 4:
                            //    TreeOakMedium(pos, terrainHeight);
                            //    break;
                            //case 5:
                            //    TreeOakMedium(pos, terrainHeight);
                            //    break;
                            //case 6:
                            //    TreeSpruceBig(pos, terrainHeight);
                            //    break;
                            //case 7:
                            //    TreeLinden(pos, terrainHeight);
                            //    break;
                            //case 8:
                            //    TreeApple(pos, terrainHeight);
                            //    break;
                    }
                } else treeChange--;

                for (byte b = (byte)(terrainHeight+1); b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Dirt;

                // Lithosphere
                if (random.Bool()) {
                    chunk.Blocks[terrainHeight+dirtHeight]=(byte)BackBlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeBothForest() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+random.Int(3);
                } else terrainChange--;

                //Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockForest;

                if (random.Bool()) {
                    switch (random.Int(11)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rashberry;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Strawberry;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.BranchFull;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Blueberry;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                            break;

                        case 9:
                            switch (random.Int4()) {
                                case 1: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax1; break;
                                case 2: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax2; break;
                            }
                            break;

                        case 10:
                            switch (random.Int4()) {
                                case 1:
                                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Boletus;
                                    break;
                                case 2:
                                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Toadstool;
                                    break;
                                case 3:
                                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Champignon;
                                    break;
                            }
                            break;
                    }
                }

                if (treeChange<0) {
                    switch (random.Int(9)) {
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

                for (byte b = (byte)(terrainHeight+1); b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Dirt;

                // Lithosphere
                if (random.Bool()) {
                    chunk.Blocks[terrainHeight+dirtHeight]=(byte)BackBlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeLeaveForest() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+random.Int(3);
                } else terrainChange--;

                //Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockForest;

                if (random.Bool()) {
                    //if (random.Int(12)==1) chunk.Blocks[terrainHeight-1]=(byte)BackBlockId.Rabbit;
                    switch (random.Int(11)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rashberry;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Strawberry;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.BranchALittle;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Blueberry;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                            break;

                        case 10:
                            switch (random.Int4()) {
                                case 1: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax1; break;
                                case 2: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax2; break;
                                //case 3: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax3; break;
                            }
                            break;

                        case 9:
                            switch (random.Int4()) {
                                case 1:
                                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Boletus;
                                    break;
                                case 2:
                                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Toadstool;
                                    break;
                                case 3:
                                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Champignon;
                                    break;
                            }
                            break;
                    }
                }

                if (treeChange<0) {
                    switch (random.Int(9)) {
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

                for (byte b = (byte)(terrainHeight+1); b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Dirt;

                // Lithosphere
                if (random.Bool()) {
                    chunk.Blocks[terrainHeight+dirtHeight]=(byte)BackBlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomePlains() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+random.Int(3);
                } else terrainChange--;

                //Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockPlains;

                if (random.Bool()) {
                    //if (random.Int(12)==1) chunk.Blocks[terrainHeight-1]=(byte)BackBlockId.Rabbit;
                    switch (random.Int(10)) {
                        case 1:
                         //   chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Onion;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassPlains;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Dandelion;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.BranchFull;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassPlains;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassPlains;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Violet;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                            break;

                        case 9:
                            switch (random.Int4()) {
                                case 1: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax1; break;
                                case 2: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax2; break;
                                //case 3: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax3; break;
                            }
                            break;
                    }
                }

                for (byte b = (byte)(terrainHeight+1); b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Dirt;

                // Lithosphere
                if (random.Bool()) {
                    chunk.Blocks[terrainHeight+dirtHeight]=(byte)BackBlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeSubtropics() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+random.Int(3);
                } else terrainChange--;

                //Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                //Sub
                if (seabedChange<0) {
                    grass=!grass;
                    seabedChange=5+random.Int(10);
                } else seabedChange--;

                chunk.LightPos=terrainHeight;

                if (grass) {
                    chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockDesert;

                    //if (random.Int(12)==1) chunk.Blocks[terrainHeight-1]=(byte)BackBlockId.Rabbit;
                    //else if (random.Int(12)==1) chunk.Blocks[terrainHeight-1]=(byte)BackBlockId.Chicken;

                    if (random.Bool()) {
                        switch (random.Int(10)) {
                            case 1:
                                switch (random.Int4()) {
                                    case 1: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Wheat1; break;
                                    case 2: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Wheat2; break;
                                    //case 3: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Wheat3; break;
                                }
                                break;

                            case 2:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassDesert;
                                break;

                            case 3:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Dandelion;
                                break;

                            case 4:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.BranchALittle;
                                break;

                            case 5:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                                break;

                            case 6:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassDesert;
                                break;

                            case 7:
                            //    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Onion;
                                break;

                            case 8:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                                break;

                            case 9:
                                switch (random.Int4()) {
                                    case 1: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax1; break;
                                    case 2: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax2; break;
                                    //case 3: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax3; break;
                                }
                                break;
                        }
                    }
                } else {
                    chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockForest;
                    //if (random.Int(12)==1) chunk.Blocks[terrainHeight-1]=(byte)BackBlockId.Rabbit;
                    //else if (random.Int(12)==1) chunk.Blocks[ terrainHeight-1]=(byte)BackBlockId.Chicken;
                    if (random.Bool()) {
                        switch (random.Int(11)) {
                            case 1:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Strawberry;
                                break;

                            case 2:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassPlains;
                                break;

                            case 3:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Dandelion;
                                break;

                            case 4:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.BranchALittle;
                                break;

                            case 5:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassDesert;
                                break;

                            case 6:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassForest;
                                break;

                            case 7:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rose;
                                break;

                            case 8:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                                break;

                            case 9:
                                switch (random.Int4()) {
                                    case 1: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax1; break;
                                    case 2: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax2; break;
                                    //case 3: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Flax3; break;
                                }
                                break;

                            case 10:
                                switch (random.Int4()) {
                                    case 1: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Wheat1; break;
                                    case 2: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Wheat2; break;
                                    //case 3: chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Wheat3; break;
                                }
                                break;
                        }
                    }
                }



                if (treeChange<0) {
                    switch (random.Int(9)) {
                        case 1:
                            TreeSpruceLittle(pos, terrainHeight);
                            break;
                        case 2:
                            TreeOakLittle(pos, terrainHeight);
                            break;
                        case 3:
                            TreePine(pos, terrainHeight);
                            break;
                        case 4:
                            TreeOakMedium(pos, terrainHeight);
                            break;
                        case 5:
                            TreeOakMedium(pos, terrainHeight);
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
                } else
                    treeChange--;

                for (byte b = (byte)(terrainHeight+1); b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Dirt;

                // Lithosphere
                if (random.Bool()) {
                    chunk.Blocks[terrainHeight+dirtHeight]=(byte)BackBlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeDesert() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+random.Int(3);
                } else terrainChange--;

                //Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                if (seabedChange<0) {
                    if (grass) seabedChange=20+random.Int(50);
                    else seabedChange=3+random.Int(5);
                    grass=!grass;
                } else seabedChange--;

                if (grass) {
                    chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockDesert;
                    for (byte b = (byte)(terrainHeight+1); b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Sand;

                    if (random.Bool()) {
                        switch (random.Int(9)) {
                            case 1:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Alore;
                                break;

                            case 2:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassDesert;
                                break;

                            case 3:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Dandelion;
                                break;

                            case 4:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.BranchFull;
                                break;

                            case 8:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                                break;
                        }
                    }
                } else {
                    for (byte b = terrainHeight; b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Sand;
                    if (random.Int(20)==1) {
                        switch (random.Int(9)) {
                            case 1:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Alore;
                                break;

                            case 2:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassDesert;
                                break;

                            case 5:
                                for (int x = terrainHeight-1; x>terrainHeight+random.Int(6); x--) chunk.TopBlocks[x]=(byte)BackBlockId.CactusBig;
                                break;

                            case 6:
                                for (int x = terrainHeight-1; x>terrainHeight+random.Int(5); x--) chunk.TopBlocks[x]=(byte)BackBlockId.CactusSmall;
                                break;

                            case 8:
                                chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                                break;
                        }
                    }
                }

                // Lithosphere
                if (random.Bool()) {
                    chunk.Blocks[terrainHeight+dirtHeight]=(byte)BackBlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeSavana() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+random.Int(3);
                } else terrainChange--;

                //Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                if (seabedChange<0) {
                    if (grass) seabedChange=20+random.Int(50);
                    else seabedChange=3+random.Int(5);
                    grass=!grass;
                } else seabedChange--;

                if (grass) {
                    chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockDesert;
                    for (byte b = (byte)(terrainHeight+1); b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Dirt;

                    //if (random.Bool()) {
                    switch (random.Int(6)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Alore;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassDesert;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassPlains;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.BranchFull;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                            break;
                    }
                    //}
                } else {
                    chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockPlains;
                    for (byte b = (byte)(terrainHeight+1); b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Dirt;

                    if (treeChange<0) {
                        if (random.Int(5)==1) TreePine(pos, terrainHeight);
                    } else treeChange--;

                    //if (random.Int(20)==1) {
                    switch (random.Int(9)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Alore;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassDesert;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassPlains;
                            break;

                        case 5:
                            for (int x = terrainHeight-1; x>terrainHeight+random.Int(6); x--) chunk.TopBlocks[x]=(byte)BackBlockId.CactusBig;
                            break;

                        case 6:
                            for (int x = terrainHeight-1; x>terrainHeight+random.Int(5); x--) chunk.TopBlocks[x]=(byte)BackBlockId.CactusSmall;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                            break;
                    }
                    //}
                }

                // Lithosphere
                if (random.Bool()) {
                    chunk.Blocks[terrainHeight+dirtHeight]=(byte)BackBlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        void BiomeJungle() {
            for (; pos<biomeSize+generatePos; pos++) {
                terrain.Add(new BGChunk());
                BGChunk chunk = terrain[pos];

                // BGChunk height
                if (terrainChange<0) {
                    if (terrainHeight>waterHeight-1) terrainHeight--;
                    else if (terrainHeight<waterHeight-6) terrainHeight++;
                    else {
                        if (random.Bool()) terrainHeight++;
                        else terrainHeight--;
                    }

                    terrainChange=2+random.Int(3);
                } else terrainChange--;

                //Height dirt
                if (dirtChange<0) {
                    if (dirtHeight>3) dirtHeight--;
                    else if (dirtHeight<2) dirtHeight++;
                    else {
                        if (random.Bool()) dirtHeight++;
                        else dirtHeight--;
                    }
                    dirtChange=1+random.Int(3);
                } else dirtChange--;

                chunk.LightPos=terrainHeight;

                chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockForest;

                if (random.Bool()) {
                    switch (random.Int(9)) {
                        case 1:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Orchid;
                            break;

                        case 2:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassJungle;
                            break;

                        case 3:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassJungle;
                            break;

                        case 4:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.BranchFull;
                            break;

                        case 5:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassJungle;
                            break;

                        case 6:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassJungle;
                            break;

                        case 7:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassJungle;
                            break;

                        case 8:
                            chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
                            break;
                    }
                }

                if (treeChange<0) {
                    if (random.Bool()) TreePineJunle(pos, terrainHeight);
                } else treeChange--;

                for (byte b = (byte)(terrainHeight+1); b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Dirt;

                // Lithosphere
                if (random.Bool()) {
                    chunk.Blocks[terrainHeight+dirtHeight]=(byte)BackBlockId.Cobblestone;
                    GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
                } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
            }
            generatePos+=biomeSize;
        }

        //void BiomeMountains() {
        //    for (; pos<biomeSize+generatePos; pos++) {
        //        terrain.Add(new BGChunk());
        //        BGChunk chunk = terrain[pos];

        //        // BGChunk height
        //        if (terrainChange<0) {
        //            if (terrainHeight>waterHeight-1) {
        //                terrainHeight--;
        //                hill=false;
        //            } else if (terrainHeight<waterHeight-10) {
        //                terrainHeight++;
        //                hill=true;
        //            } else {
        //                if (hill) terrainHeight++;
        //                else terrainHeight--;
        //            }

        //            terrainChange=1+random.Int(3);
        //        } else terrainChange--;

        //        //Height dirt
        //        if (dirtChange<0) {
        //            if (dirtHeight>3) dirtHeight--;
        //            else if (dirtHeight<2) dirtHeight++;
        //            else {
        //                if (random.Bool()) dirtHeight++;
        //                else dirtHeight--;
        //            }
        //            dirtChange=1+random.Int(3);
        //        } else dirtChange--;

        //        chunk.LightPos=terrainHeight;

        //        chunk.Blocks[terrainHeight]=(byte)BackBlockId.GrassBlockHills;

        //        if (random.Bool()) {
        //            switch (random.Int(9)) {
        //                case 1:
        //                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassHills;
        //                    break;

        //                case 2:
        //                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassHills;
        //                    break;

        //                case 3:
        //                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.GrassHills;
        //                    break;

        //                case 4:
        //                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.BranchALittle;
        //                    break;

        //                case 5:
        //                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Violet;
        //                    break;

        //                case 6:
        //                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
        //                    break;

        //                case 7:
        //                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Dandelion;
        //                    break;

        //                case 8:
        //                    chunk.TopBlocks[terrainHeight-1]=(byte)BackBlockId.Rocks;
        //                    break;
        //            }
        //        }

        //        if (treeChange<0) {
        //            if (random.Int(10)==1) {
        //                if (random.Bool()) TreeSpruceLittle(pos, terrainHeight);
        //                else TreeOakLittle(pos, terrainHeight);
        //            }
        //        } else treeChange--;

        //        for (byte b = (byte)(terrainHeight+1); b<terrainHeight+dirtHeight; b++) chunk.Blocks[b]=(byte)BackBlockId.Dirt;

        //        // Lithosphere
        //        if (random.Bool()) {
        //            chunk.Blocks[terrainHeight+dirtHeight]=(byte)BackBlockId.Cobblestone;
        //            GenerateUnderSurface(chunk, terrainHeight+dirtHeight+1);
        //        } else GenerateUnderSurface(chunk, terrainHeight+dirtHeight);
        //    }
        //    generatePos+=biomeSize;
        //}
        #endregion
        byte block1;
        void GenerateUnderSurface(BGChunk chunk, int height) {

            //Type
            if (level1Lenght==0) {
                level1Type=random.Int(10);
                block1 = GetByIdHeight1(level1Type);
                level1Lenght=random.Int(12)+8+8;
            } else {
                level1Lenght--;
            }

            for (int y = 0; y<5 && height+y<Background.MaxIndex; y++) chunk.Blocks[height+y]=block1;

            int rdn=height+random.Int(10);
            if (rdn<Background.MaxIndex)chunk.Blocks[rdn]=(byte)BackBlockId.Cobblestone;
        }

        byte GetByIdHeight1(int v) {
            switch (v) {
                case 1: return (byte)BackBlockId.StoneSandstone;
                case 2: return (byte)BackBlockId.StoneLimestone;
                case 3: return (byte)BackBlockId.StoneSchist;
                case 4: return (byte)BackBlockId.StoneGneiss;
                case 5: return (byte)BackBlockId.StoneDolomite;

                case 11: return (byte)BackBlockId.StoneSandstone;
                case 12: return (byte)BackBlockId.StoneLimestone;
                case 13: return (byte)BackBlockId.StoneSchist;
                case 14: return (byte)BackBlockId.StoneDolomite;
                case 15: return (byte)BackBlockId.StoneDolomite;

                case 6: return (byte)BackBlockId.StoneDiorit;
                case 7: return (byte)BackBlockId.StoneGabbro;
                case 8: return (byte)BackBlockId.StoneGneiss;
                case 9: return (byte)BackBlockId.StoneBasalt;
                case 10: return (byte)BackBlockId.StoneRhyolite;

                default: return (byte)BackBlockId.StoneDolomite;
            }
        }

        void Save() {
            using (FileStream stream= new FileStream(Setting.Path+"\\MenuBackground.ter",FileMode.Create,FileAccess.Write)) {
                for (int x=0; x<terrain.Count-7; x++) {
                    BGChunk chunk=terrain[x];
                    List<byte>
                        backBlocks=new List<byte>(),
                        solidBlocks= new List<byte>(),
                        topBlocks= new List<byte>();

                    byte
                        backblockzeros = 0,
                        topblockzeros = 0,
                        solidblockzeros = 0;

                    for (int i=0; i<Background.MaxIndex; i++) {

                        //Back blocks
                        if (chunk.BackBlocks[i]!=0) {

                            if (backblockzeros!=0) {
                                if (backblockzeros>2) {
                                    backBlocks.Add(1);
                                    backBlocks.Add(backblockzeros);
                                } else {
                                    for (int j = 0; j<backblockzeros; j++) backBlocks.Add(0);
                                }
                                backblockzeros=0;
                            }

                            backBlocks.Add(chunk.BackBlocks[i]);

                        } else backblockzeros++;

                        //Solid blocks
                        if (chunk.Blocks[i]!=0) {
                            if (solidblockzeros!=0) {
                                if (solidblockzeros>2) {
                                    solidBlocks.Add(1);
                                    solidBlocks.Add(solidblockzeros);
                                } else {
                                    for (int j = 0; j<solidblockzeros; j++) solidBlocks.Add(0);
                                }
                                solidblockzeros=0;
                            }
                            solidBlocks.Add(chunk.Blocks[i]);
                        } else solidblockzeros++;

                        //Top blocks
                        if (chunk.TopBlocks[i]!=0) {

                            if (topblockzeros!=0) {
                                if (topblockzeros>2) {
                                    topBlocks.Add(1);
                                    topBlocks.Add(topblockzeros);
                                } else {
                                    for (int j = 0; j<topblockzeros; j++) topBlocks.Add(0);
                                }
                                topblockzeros=0;
                            }

                            topBlocks.Add(chunk.TopBlocks[i]);
                        } else  topblockzeros++;
                    }

                    if (backblockzeros>2) {
                        backBlocks.Add(1);
                        backBlocks.Add(backblockzeros);
                    } else {
                        for (int j = 0; j<backblockzeros; j++) backBlocks.Add(0);
                    }

                    if (solidblockzeros>2) {
                        solidBlocks.Add(1);
                        solidBlocks.Add(solidblockzeros);
                    } else {
                        for (int j = 0; j<solidblockzeros; j++) solidBlocks.Add(0);
                    }

                    if (topblockzeros>2) {
                        topBlocks.Add(1);
                        topBlocks.Add(topblockzeros);
                    } else {
                        for (int j = 0; j<topblockzeros; j++) topBlocks.Add(0);
                    }

                    stream.WriteByte(chunk.LightPos);

                    stream.Write(backBlocks.ToArray(), 0, backBlocks.Count);
                    stream.Write(topBlocks.ToArray(), 0, topBlocks.Count);
                    stream.Write(solidBlocks.ToArray(), 0, solidBlocks.Count);

                    //state++;
                }
            }
        }

        #region Structures
        void TreeApple(int x, int y) {
            treeChange=2+random.Int(2);
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.AppleWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.AppleWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.AppleWood;
            terrain[x+1].BackBlocks[y-3]=(byte)BackBlockId.AppleWood;
            terrain[x].BackBlocks[y-4]=(byte)BackBlockId.AppleWood;
            terrain[x+1].BackBlocks[y-5]=(byte)BackBlockId.AppleWood;
            terrain[x-1].BackBlocks[y-5]=(byte)BackBlockId.AppleWood;
            terrain[x+1].BackBlocks[y-6]=(byte)BackBlockId.AppleWood;
            terrain[x+2].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x-2].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x+1].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x-1].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x+2].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x-2].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x+1].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x-1].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x+1].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x-1].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x+1].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x-1].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
            terrain[x].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.AppleLeavesWithApples : (byte)BackBlockId.AppleLeaves;
        }

        void TreeOrange(int x, int y) {
            treeChange=2+random.Int(2);
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.OrangeWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.OrangeWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.OrangeWood;

            terrain[x].BackBlocks[y-4]=(byte)BackBlockId.OrangeWood;
            terrain[x].BackBlocks[y-5]=(byte)BackBlockId.OrangeWood;
            terrain[x].BackBlocks[y-6]=(byte)BackBlockId.OrangeWood;

            if (random.Bool()) terrain[x-1].BackBlocks[y-4]=(byte)BackBlockId.OrangeWood;
            if (random.Bool()) terrain[x+1].BackBlocks[y-5]=(byte)BackBlockId.OrangeWood;
            if (random.Bool()) terrain[x-1].BackBlocks[y-7]=(byte)BackBlockId.OrangeWood;

            if (random.Bool()) {
                terrain[x+1].BackBlocks[y-7]=(byte)BackBlockId.OrangeWood;
                if (random.Bool()) terrain[x+1].BackBlocks[y-8]=(byte)BackBlockId.OrangeWood;
            }
            terrain[x+1].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x-1].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;

            terrain[x].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x+2].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x-2].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x+1].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x-1].TopBlocks[y-5]=(byte)BackBlockId.OrangeLeaves;

            terrain[x].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x+2].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x-2].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x+1].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x-1].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;

            terrain[x].TopBlocks[y-7]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x+2].TopBlocks[y-7]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x-2].TopBlocks[y-7]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x+1].TopBlocks[y-7]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x-1].TopBlocks[y-7]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;

            terrain[x].TopBlocks[y-8]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x+2].TopBlocks[y-8]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x-2].TopBlocks[y-8]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x+1].TopBlocks[y-8]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x-1].TopBlocks[y-8]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;

            terrain[x+1].TopBlocks[y-9]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x-1].TopBlocks[y-9]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
            terrain[x].TopBlocks[y-9]=random.Int(3)==1 ? (byte)BackBlockId.OrangeLeavesWithOranges : (byte)BackBlockId.OrangeLeaves;
        }

        void TreeLemon(int x, int y) {
            treeChange=2+random.Int(2);
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.LemonWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.LemonWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.LemonWood;
            terrain[x].BackBlocks[y-4]=(byte)BackBlockId.LemonWood;

            if (random.Bool()) terrain[x-1].BackBlocks[y-4]=(byte)BackBlockId.LemonWood;
            else terrain[x+1].BackBlocks[y-5]=(byte)BackBlockId.LemonWood;

            terrain[x+1].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x-1].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;

            terrain[x].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x+2].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x-2].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x+1].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x-1].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;

            terrain[x].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x+2].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x-2].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x+1].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x-1].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;

            terrain[x].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x+1].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
            terrain[x-1].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.LemonLeavesWithLemons : (byte)BackBlockId.LemonLeaves;
        }

        void TreeCherry(int x, int y) {
            treeChange=2+random.Int(2);
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.CherryWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.CherryWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.CherryWood;
            terrain[x-1].BackBlocks[y-3]=(byte)BackBlockId.CherryWood;
            terrain[x].BackBlocks[y-4]=(byte)BackBlockId.CherryWood;
            terrain[x-1].BackBlocks[y-5]=(byte)BackBlockId.CherryWood;
            terrain[x+1].BackBlocks[y-5]=(byte)BackBlockId.CherryWood;
            terrain[x-1].BackBlocks[y-6]=(byte)BackBlockId.CherryWood;
            terrain[x+1].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x-1].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x+2].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x-2].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x+1].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x-1].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x+2].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x-2].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x+1].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x-1].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x+1].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x-1].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x+1].TopBlocks[y-7]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x-1].TopBlocks[y-7]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
            terrain[x].TopBlocks[y-7]=random.Int(3)==1 ? (byte)BackBlockId.CherryLeavesWithCherries : (byte)BackBlockId.CherryLeaves;
        }

        void TreePlum(int x, int y) {
            treeChange=2+random.Int(2);
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.PlumWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.PlumWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.PlumWood;
            terrain[x-1].BackBlocks[y-3]=(byte)BackBlockId.PlumWood;
            terrain[x].BackBlocks[y-4]=(byte)BackBlockId.PlumWood;
            terrain[x-1].BackBlocks[y-5]=(byte)BackBlockId.PlumWood;
            terrain[x+1].BackBlocks[y-5]=(byte)BackBlockId.PlumWood;
            terrain[x-1].BackBlocks[y-6]=(byte)BackBlockId.PlumWood;
            terrain[x+1].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x-1].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x].TopBlocks[y-3]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x+2].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x-2].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x+1].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x-1].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x].TopBlocks[y-4]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x+2].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x-2].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x+1].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x-1].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x].TopBlocks[y-5]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x+1].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x-1].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x].TopBlocks[y-6]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums : (byte)BackBlockId.PlumLeaves;
            terrain[x].TopBlocks[y-7]=random.Int(3)==1 ? (byte)BackBlockId.PlumLeavesWithPlums: (byte)BackBlockId.PlumLeaves;
        }

        void TreeOakMedium(int x, int y) {
            treeChange=2+random.Int(2);
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.OakWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.OakWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.OakWood;
            terrain[x].BackBlocks[y-4]=(byte)BackBlockId.OakWood;
            if (random.Bool()) terrain[x+1].BackBlocks[y-4]=(byte)BackBlockId.OakWood;
            terrain[x].BackBlocks[y-6]=(byte)BackBlockId.OakWood;
            terrain[x].BackBlocks[y-5]=(byte)BackBlockId.OakWood;
            terrain[x-1].BackBlocks[y-7]=(byte)BackBlockId.OakWood;
            terrain[x+1].BackBlocks[y-7]=(byte)BackBlockId.OakWood;
            if (random.Bool()) terrain[x+1].BackBlocks[y-8]=(byte)BackBlockId.OakWood;
            if (random.Bool()) terrain[x-1].BackBlocks[y-8]=(byte)BackBlockId.OakWood;
            if (random.Bool_20Percent()) terrain[x-2].BackBlocks[y-7]=(byte)BackBlockId.OakWood;
            terrain[x+1].TopBlocks[y-4]=(byte)BackBlockId.OakLeaves;
            terrain[x].TopBlocks[y-4]=(byte)BackBlockId.OakLeaves;
            terrain[x-1].TopBlocks[y-4]=(byte)BackBlockId.OakLeaves;
            terrain[x+1].TopBlocks[y-5]=(byte)BackBlockId.OakLeaves;
            terrain[x].TopBlocks[y-5]=(byte)BackBlockId.OakLeaves;
            terrain[x-1].TopBlocks[y-5]=(byte)BackBlockId.OakLeaves;
            terrain[x+2].TopBlocks[y-5]=(byte)BackBlockId.OakLeaves;
            terrain[x-2].TopBlocks[y-5]=(byte)BackBlockId.OakLeaves;
            terrain[x+1].TopBlocks[y-6]=(byte)BackBlockId.OakLeaves;
            terrain[x].TopBlocks[y-6]=(byte)BackBlockId.OakLeaves;
            terrain[x-1].TopBlocks[y-6]=(byte)BackBlockId.OakLeaves;
            terrain[x+2].TopBlocks[y-6]=(byte)BackBlockId.OakLeaves;
            terrain[x-2].TopBlocks[y-6]=(byte)BackBlockId.OakLeaves;
            terrain[x+1].TopBlocks[y-7]=(byte)BackBlockId.OakLeaves;
            terrain[x].TopBlocks[y-7]=(byte)BackBlockId.OakLeaves;
            terrain[x-1].TopBlocks[y-7]=(byte)BackBlockId.OakLeaves;
            terrain[x+2].TopBlocks[y-7]=(byte)BackBlockId.OakLeaves;
            terrain[x-2].TopBlocks[y-7]=(byte)BackBlockId.OakLeaves;
            terrain[x+1].TopBlocks[y-8]=(byte)BackBlockId.OakLeaves;
            terrain[x].TopBlocks[y-8]=(byte)BackBlockId.OakLeaves;
            terrain[x-1].TopBlocks[y-8]=(byte)BackBlockId.OakLeaves;
            terrain[x-2].TopBlocks[y-8]=(byte)BackBlockId.OakLeaves;
            terrain[x+2].TopBlocks[y-8]=(byte)BackBlockId.OakLeaves;
            terrain[x+1].TopBlocks[y-9]=(byte)BackBlockId.OakLeaves;
            terrain[x].TopBlocks[y-9]=(byte)BackBlockId.OakLeaves;
            terrain[x-1].TopBlocks[y-9]=(byte)BackBlockId.OakLeaves;
        }

        void TreePine(int x, int y) {
            treeChange=3+random.Int(2);
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-4]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-5]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-6]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-7]=(byte)BackBlockId.PineWood;
            if (random.Bool()) terrain[x].BackBlocks[y-8]=(byte)BackBlockId.PineWood;
            terrain[x+2].TopBlocks[y-6]=(byte)BackBlockId.PineLeaves;
            terrain[x-2].TopBlocks[y-6]=(byte)BackBlockId.PineLeaves;
            terrain[x+1].TopBlocks[y-7]=(byte)BackBlockId.PineLeaves;
            terrain[x].TopBlocks[y-7]=(byte)BackBlockId.PineLeaves;
            terrain[x-1].TopBlocks[y-7]=(byte)BackBlockId.PineLeaves;
            terrain[x+2].TopBlocks[y-8]=(byte)BackBlockId.PineLeaves;
            terrain[x].TopBlocks[y-8]=(byte)BackBlockId.PineLeaves;
            terrain[x-2].TopBlocks[y-8]=(byte)BackBlockId.PineLeaves;
            terrain[x].TopBlocks[y-9]=(byte)BackBlockId.PineLeaves;
            terrain[x-1].TopBlocks[y-10]=(byte)BackBlockId.PineLeaves;
            terrain[x+1].TopBlocks[y-10]=(byte)BackBlockId.PineLeaves;
        }

        void TreePineJunle(int x, int y) {
            treeChange=3+random.Int(2);
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-4]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-5]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-6]=(byte)BackBlockId.PineWood;
            terrain[x].BackBlocks[y-7]=(byte)BackBlockId.PineWood;
            terrain[x+2].TopBlocks[y-6]=(byte)BackBlockId.PineLeaves;
            terrain[x-2].TopBlocks[y-6]=(byte)BackBlockId.PineLeaves;
            terrain[x+1].TopBlocks[y-7]=(byte)BackBlockId.PineLeaves;
            terrain[x].TopBlocks[y-7]=(byte)BackBlockId.PineLeaves;
            terrain[x-1].TopBlocks[y-7]=(byte)BackBlockId.PineLeaves;
            terrain[x].TopBlocks[y-8]=(byte)BackBlockId.PineLeaves;
            terrain[x+2].TopBlocks[y-8]=(byte)BackBlockId.PineLeaves;
            terrain[x].TopBlocks[y-8]=(byte)BackBlockId.PineLeaves;
            terrain[x-2].TopBlocks[y-8]=(byte)BackBlockId.PineLeaves;
            terrain[x].TopBlocks[y-9]=(byte)BackBlockId.PineLeaves;
            terrain[x-1].TopBlocks[y-10]=(byte)BackBlockId.PineLeaves;
            terrain[x+1].TopBlocks[y-10]=(byte)BackBlockId.PineLeaves;
            //if (random.Int(3)==1) {
            //    terrain[x-2].BackBlocks[y-6]=(byte)BackBlockId.Liana;
            //    terrain[x-2].BackBlocks[y-6+1]=(byte)BackBlockId.Liana;
            //    if (random.Bool()) terrain[x-2].BackBlocks[y-6+2]=(byte)BackBlockId.Liana;
            //}
            //if (random.Int(3)==1) {
            //    terrain[x+2].BackBlocks[y-6]=(byte)BackBlockId.Liana;
            //    terrain[x+2].BackBlocks[y-6+1]=(byte)BackBlockId.Liana;
            //    if (random.Bool()) terrain[x+2].BackBlocks[y-6+2]=(byte)BackBlockId.Liana;
            //}
            //if (random.Int(3)==1) {
            //    //terrain[x+1].BackBlocks[y-122]=(byte)BackBlockId.Liana;
            //    //terrain[x+1].BackBlocks[y-122+1]=(byte)BackBlockId.Liana;
            //    if (random.Bool()) terrain[x+1].BackBlocks[y-7+2]=(byte)BackBlockId.Liana;
            //}
            //if (random.Int(3)==1) {
            //    terrain[x-1].BackBlocks[y-7]=(byte)BackBlockId.Liana;
            //    terrain[x-1].BackBlocks[y-7+1]=(byte)BackBlockId.Liana;
            //    if (random.Bool()) terrain[x-1].BackBlocks[y-7+2]=(byte)BackBlockId.Liana;
            //}
            //if (random.Int(3)==1) {
            //    terrain[x].BackBlocks[y-9]=(byte)BackBlockId.Liana;
            //    terrain[x].BackBlocks[y-9+1]=(byte)BackBlockId.Liana;
            //    if (random.Bool()) terrain[x].BackBlocks[y-9+2]=(byte)BackBlockId.Liana;
            //}
        }

        void TreeSpruceBig(int x, int y) {
            treeChange=3+random.Int(2);

            terrain[x].BackBlocks[y]=(byte)BackBlockId.SpruceWood;
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.SpruceWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.SpruceWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.SpruceWood;
            terrain[x].BackBlocks[y-4]=(byte)BackBlockId.SpruceWood;
            if (random.Bool()) terrain[x+1].BackBlocks[y-4]=(byte)BackBlockId.SpruceWood;
            if (random.Bool()) terrain[x-1].BackBlocks[y-4]=(byte)BackBlockId.SpruceWood;
            terrain[x].BackBlocks[y-5]=(byte)BackBlockId.SpruceWood;
            terrain[x].BackBlocks[y-6]=(byte)BackBlockId.SpruceWood;
            if (random.Bool()) terrain[x+1].BackBlocks[y-6]=(byte)BackBlockId.SpruceWood;
            if (random.Bool()) terrain[x-1].BackBlocks[y-6]=(byte)BackBlockId.SpruceWood;
            terrain[x].BackBlocks[y-8]=(byte)BackBlockId.SpruceWood;
            terrain[x+2].TopBlocks[y-3]=(byte)BackBlockId.SpruceLeaves;
            terrain[x+1].TopBlocks[y-3]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-3]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-1].TopBlocks[y-3]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-2].TopBlocks[y-3]=(byte)BackBlockId.SpruceLeaves;
            terrain[x+2].TopBlocks[y-4]=(byte)BackBlockId.SpruceLeaves;
            terrain[x+1].TopBlocks[y-4]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-4]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-1].TopBlocks[y-4]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-2].TopBlocks[y-4]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-2].TopBlocks[y-5]=(byte)BackBlockId.SpruceLeaves;
            terrain[x+1].TopBlocks[y-5]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-5]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-1].TopBlocks[y-5]=(byte)BackBlockId.SpruceLeaves;
            terrain[x+2].TopBlocks[y-5]=(byte)BackBlockId.SpruceLeaves;
            terrain[x+1].TopBlocks[y-6]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-6]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-1].TopBlocks[y-6]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-7]=(byte)BackBlockId.SpruceLeaves;
            terrain[x+1].TopBlocks[y-7]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-1].TopBlocks[y-7]=(byte)BackBlockId.SpruceLeaves;
            terrain[x+1].TopBlocks[y-8]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-8]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-1].TopBlocks[y-8]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-9]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-10]=(byte)BackBlockId.SpruceLeaves;
        }

        void TreeLinden(int x, int y) {
            treeChange=3+random.Int(2);
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.LindenWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.LindenWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.LindenWood;
            terrain[x].BackBlocks[y-4]=(byte)BackBlockId.LindenWood;
            terrain[x].BackBlocks[y-5]=(byte)BackBlockId.LindenWood;

            if (random.Bool()) terrain[x+1].BackBlocks[y-4]=(byte)BackBlockId.LindenWood;
            if (random.Bool()) terrain[x-1].BackBlocks[y-4]=(byte)BackBlockId.LindenWood;
            if (random.Bool()) {
                terrain[x-1].BackBlocks[y-5]=(byte)BackBlockId.LindenWood;
                if (random.Bool()) terrain[x-1].BackBlocks[y-5]=(byte)BackBlockId.LindenWood;
            }
            if (random.Bool()) {
                terrain[x+1].BackBlocks[y-5]=(byte)BackBlockId.LindenWood;
                if (random.Bool()) terrain[x+1].BackBlocks[y-5]=(byte)BackBlockId.LindenWood;
            }
            terrain[x].BackBlocks[y-6]=(byte)BackBlockId.LindenWood;
            terrain[x].BackBlocks[y-7]=(byte)BackBlockId.LindenWood;
            terrain[x].BackBlocks[y-8]=(byte)BackBlockId.LindenWood;
            terrain[x-2].BackBlocks[y-6]=(byte)BackBlockId.LindenWood;
            terrain[x+1].TopBlocks[y-4]=(byte)BackBlockId.LindenLeaves;
            terrain[x].TopBlocks[y-4]=(byte)BackBlockId.LindenLeaves;
            terrain[x-1].TopBlocks[y-4]=(byte)BackBlockId.LindenLeaves;
            terrain[x+1].TopBlocks[y-5]=(byte)BackBlockId.LindenLeaves;
            terrain[x].TopBlocks[y-5]=(byte)BackBlockId.LindenLeaves;
            terrain[x-1].TopBlocks[y-5]=(byte)BackBlockId.LindenLeaves;
            terrain[x+2].TopBlocks[y-5]=(byte)BackBlockId.LindenLeaves;
            terrain[x-2].TopBlocks[y-5]=(byte)BackBlockId.LindenLeaves;
            terrain[x+1].TopBlocks[y-6]=(byte)BackBlockId.LindenLeaves;
            terrain[x].TopBlocks[y-6]=(byte)BackBlockId.LindenLeaves;
            terrain[x-1].TopBlocks[y-6]=(byte)BackBlockId.LindenLeaves;
            terrain[x+2].TopBlocks[y-6]=(byte)BackBlockId.LindenLeaves;
            terrain[x-2].TopBlocks[y-6]=(byte)BackBlockId.LindenLeaves;
            terrain[x+1].TopBlocks[y-7]=(byte)BackBlockId.LindenLeaves;
            terrain[x].TopBlocks[y-7]=(byte)BackBlockId.LindenLeaves;
            terrain[x-1].TopBlocks[y-7]=(byte)BackBlockId.LindenLeaves;
            terrain[x+2].TopBlocks[y-7]=(byte)BackBlockId.LindenLeaves;
            terrain[x-2].TopBlocks[y-7]=(byte)BackBlockId.LindenLeaves;
            terrain[x+1].TopBlocks[y-8]=(byte)BackBlockId.LindenLeaves;
            terrain[x].TopBlocks[y-8]=(byte)BackBlockId.LindenLeaves;
            terrain[x-1].TopBlocks[y-8]=(byte)BackBlockId.LindenLeaves;
            terrain[x+1].TopBlocks[y-9]=(byte)BackBlockId.LindenLeaves;
            terrain[x].TopBlocks[y-9]=(byte)BackBlockId.LindenLeaves;
            terrain[x-1].TopBlocks[y-9]=(byte)BackBlockId.LindenLeaves;
            terrain[x].TopBlocks[y-10]=(byte)BackBlockId.LindenLeaves;
        }

        void TreeOakLittle(int x, int y) {
            treeChange=1+random.Int(2);
            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.OakWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.OakWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.OakWood;
            terrain[x+1].TopBlocks[y-3]=(byte)BackBlockId.OakLeaves;
            terrain[x].TopBlocks[y-3]=(byte)BackBlockId.OakLeaves;
            terrain[x-1].TopBlocks[y-3]=(byte)BackBlockId.OakLeaves;
            terrain[x+1].TopBlocks[y-4]=(byte)BackBlockId.OakLeaves;
            terrain[x].TopBlocks[y-4]=(byte)BackBlockId.OakLeaves;
            terrain[x-1].TopBlocks[y-4]=(byte)BackBlockId.OakLeaves;
            terrain[x].TopBlocks[y-5]=(byte)BackBlockId.OakLeaves;
        }

        void TreeSpruceLittle(int x, int y) {
            treeChange=1+random.Int(2);

            terrain[x].BackBlocks[y-1]=(byte)BackBlockId.SpruceWood;
            terrain[x].BackBlocks[y-2]=(byte)BackBlockId.SpruceWood;
            terrain[x].BackBlocks[y-3]=(byte)BackBlockId.SpruceWood;
            terrain[x+1].TopBlocks[y-2]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-2]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-1].TopBlocks[y-2]=(byte)BackBlockId.SpruceLeaves;
            terrain[x+1].TopBlocks[y-3]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-3]=(byte)BackBlockId.SpruceLeaves;
            terrain[x-1].TopBlocks[y-3]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-4]=(byte)BackBlockId.SpruceLeaves;
            terrain[x].TopBlocks[y-5]=(byte)BackBlockId.SpruceLeaves;
        }

        //void OreCoal(int y) {
        //    terrain[pos-10].Blocks[y-1]=(byte)BackBlockId.Coal;
        //    terrain[pos-10].Blocks[y]=(byte)BackBlockId.Coal;
        //    terrain[pos-10].Blocks[y+1]=(byte)BackBlockId.Coal;

        //    terrain[pos-10+1].Blocks[y]=(byte)BackBlockId.Coal;
        //    terrain[pos-10+1].Blocks[y+1]=(byte)BackBlockId.Coal;

        //    terrain[pos-10+2].Blocks[y]=(byte)BackBlockId.Coal;
        //    terrain[pos-10+2].Blocks[y+1]=(byte)BackBlockId.Coal;

        //    terrain[pos-10+3].Blocks[y]=(byte)BackBlockId.Coal;
        //    terrain[pos-10+3].Blocks[y+1]=(byte)BackBlockId.Coal;

        //    terrain[pos-10+4].Blocks[y]=(byte)BackBlockId.Coal;
        //    terrain[pos-10+5].Blocks[y]=(byte)BackBlockId.Coal;

        //    terrain[pos-10-1].Blocks[y+1]=(byte)BackBlockId.Coal;
        //    terrain[pos-10-1].Blocks[y]=(byte)BackBlockId.Coal;
        //    terrain[pos-10-1].Blocks[y-1]=(byte)BackBlockId.Coal;

        //    terrain[pos-10-2].Blocks[y+1]=(byte)BackBlockId.Coal;
        //    terrain[pos-10-2].Blocks[y]=(byte)BackBlockId.Coal;
        //    terrain[pos-10-2].Blocks[y-1]=(byte)BackBlockId.Coal;

        //    terrain[pos-10-3].Blocks[y]=(byte)BackBlockId.Coal;
        //    terrain[pos-10-3].Blocks[y-1]=(byte)BackBlockId.Coal;

        //    terrain[pos-10-4].Blocks[y]=(byte)BackBlockId.Coal;
        //    terrain[pos-10-4].Blocks[y-1]=(byte)BackBlockId.Coal;

        //    terrain[pos-10-5].Blocks[y]=(byte)BackBlockId.Coal;
        //}

        //void OreIron(int y) {
        //    terrain[pos-10].Blocks[y]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10].Blocks[y-1]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10-1].Blocks[y]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10-1].Blocks[y-1]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10-1].Blocks[y-2]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10-1].Blocks[y-3]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10-1].Blocks[y-4]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10-1].Blocks[y-5]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10].Blocks[y+1]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10].Blocks[y+2]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10].Blocks[y+3]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10].Blocks[y+4]=(byte)BackBlockId.OreIron;
        //    terrain[pos-10].Blocks[y+5]=(byte)BackBlockId.OreIron;
        //}

        //void OreGold(int y) {
        //    terrain[pos-10].Blocks[y]=(byte)BackBlockId.OreGold;
        //    terrain[pos-10+1].Blocks[y]=(byte)BackBlockId.OreGold;
        //    terrain[pos-10+2].Blocks[y]=(byte)BackBlockId.OreGold;
        //    terrain[pos-10-3].Blocks[y]=(byte)BackBlockId.OreGold;
        //    terrain[pos-10-5].Blocks[y-1]=(byte)BackBlockId.OreGold;
        //    terrain[pos-10-6].Blocks[y-1]=(byte)BackBlockId.OreGold;
        //}

        //void OreCopper(int y) {
        //    terrain[pos-10].Blocks[y]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10].Blocks[y+1]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10].Blocks[y+2]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10+1].Blocks[y+2]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10+1].Blocks[y+3]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10+2].Blocks[y+3]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10+3].Blocks[y+4]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10-1].Blocks[y-1]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10-1].Blocks[y-2]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10-2].Blocks[y-2]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10-2].Blocks[y-3]=(byte)BackBlockId.OreCopper;
        //    terrain[pos-10-3].Blocks[y-4]=(byte)BackBlockId.OreCopper;
        //}

        //void OreTin(int y) {
        //    terrain[pos-10].Blocks[y]=(byte)BackBlockId.OreTin;
        //    terrain[pos-10].Blocks[y-1]=(byte)BackBlockId.OreTin;
        //    terrain[pos-10-1].Blocks[y+1]=(byte)BackBlockId.OreTin;
        //    terrain[pos-10-1].Blocks[y+2]=(byte)BackBlockId.OreTin;
        //}

        //void OreSilver(int y) {
        //    terrain[pos-10].Blocks[y]=(byte)BackBlockId.OreSilver; ;
        //    terrain[pos-10+1].Blocks[y]=(byte)BackBlockId.OreSilver; ;
        //    terrain[pos-10+2].Blocks[y]=(byte)BackBlockId.OreSilver; ;
        //    terrain[pos-10-3].Blocks[y]=(byte)BackBlockId.OreSilver; ;
        //    terrain[pos-10-4].Blocks[y-1]=(byte)BackBlockId.OreSilver; ;
        //    terrain[pos-10-6].Blocks[y-1]=(byte)BackBlockId.OreSilver; ;
        //}

        //void OreAliminium(int y) {
        //    terrain[pos-10].Blocks[y]=(byte)BackBlockId.OreAluminium;
        //    terrain[pos-10+1].Blocks[y]=(byte)BackBlockId.OreAluminium;
        //    terrain[pos-10+1].Blocks[y+1]=(byte)BackBlockId.OreAluminium;
        //    terrain[pos-10+3].Blocks[y+1]=(byte)BackBlockId.OreAluminium;
        //    terrain[pos-10+2].Blocks[y]=(byte)BackBlockId.OreAluminium;
        //    terrain[pos-10-3].Blocks[y]=(byte)BackBlockId.OreAluminium;
        //    terrain[pos-10-4].Blocks[y-1]=(byte)BackBlockId.OreAluminium;
        //    terrain[pos-10-6].Blocks[y]=(byte)BackBlockId.OreAluminium;
        //}

        //void OreOil(int y) {
        //    if (random.Bool()) {
        //        terrain[pos-10+6].TopBlocks[y]=(byte)BackBlockId.Oil;
        //        terrain[pos-10+5].TopBlocks[y-1]=(byte)BackBlockId.Oil;
        //    }

        //    terrain[pos-10+5].TopBlocks[y]=(byte)BackBlockId.Oil;

        //    terrain[pos-10+4].TopBlocks[y]=(byte)BackBlockId.Oil;
        //    terrain[pos-10+4].TopBlocks[y-1]=(byte)BackBlockId.Oil;

        //    terrain[pos-10+3].TopBlocks[y]=(byte)BackBlockId.Oil;
        //    terrain[pos-10+3].TopBlocks[y-1]=(byte)BackBlockId.Oil;

        //    terrain[pos-10+2].TopBlocks[y]=(byte)BackBlockId.Oil;
        //    terrain[pos-10+2].TopBlocks[y-1]=(byte)BackBlockId.Oil;
        //    if (random.Bool()) terrain[pos-10+2].TopBlocks[y+1]=(byte)BackBlockId.Oil;

        //    terrain[pos-10+1].TopBlocks[y]=(byte)BackBlockId.Oil;
        //    terrain[pos-10+1].TopBlocks[y-1]=(byte)BackBlockId.Oil;
        //    terrain[pos-10+1].TopBlocks[y+1]=(byte)BackBlockId.Oil;

        //    terrain[pos-10].TopBlocks[y-1]=(byte)BackBlockId.Oil;
        //    terrain[pos-10].TopBlocks[y]=(byte)BackBlockId.Oil;
        //    terrain[pos-10].TopBlocks[y+1]=(byte)BackBlockId.Oil;

        //    terrain[pos-10-2].TopBlocks[y]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-2].TopBlocks[y+1]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-2].TopBlocks[y+1]=(byte)BackBlockId.Oil;

        //    terrain[pos-10-1].TopBlocks[y]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-1].TopBlocks[y-1]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-1].TopBlocks[y-2]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-1].TopBlocks[y+1]=(byte)BackBlockId.Oil;

        //    terrain[pos-10-2].TopBlocks[y]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-2].TopBlocks[y-1]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-2].TopBlocks[y-2]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-2].TopBlocks[y+1]=(byte)BackBlockId.Oil;

        //    terrain[pos-10-3].TopBlocks[y-1]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-3].TopBlocks[y+1]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-3].TopBlocks[y]=(byte)BackBlockId.Oil;

        //    terrain[pos-10-4].TopBlocks[y-1]=(byte)BackBlockId.Oil;
        //    terrain[pos-10-4].TopBlocks[y]=(byte)BackBlockId.Oil;

        //    if (random.Bool()) terrain[pos-10-5].TopBlocks[y]=(byte)BackBlockId.Oil;
        //}
        #endregion
    }

    public class BGChunk {
        public byte[] Blocks = new byte[Background.MaxIndex];
        public byte[] TopBlocks = new byte[Background.MaxIndex];
        public byte[] BackBlocks = new byte[Background.MaxIndex];
        public byte LightPos;
    }

    public class BTerrain {
        public BBlock[] SolidBlocks = new BBlock[rabcrClient.Background.MaxIndex];
        public BBlock[] TopBlocks = new BBlock[rabcrClient.Background.MaxIndex];
        public BBlock[] Background = new BBlock[rabcrClient.Background.MaxIndex];

        public bool[] IsSolidBlocks = new bool[rabcrClient.Background.MaxIndex];
        public bool[] IsTopBlocks = new bool[rabcrClient.Background.MaxIndex];
        public bool[] IsBackground = new bool[rabcrClient.Background.MaxIndex];

        public byte LightPos;

        public Vector2 LightVec;
        public byte StartSomething;

        public int LightPos16;
    }

    public abstract class BBlock {
        public abstract void Draw();
    }

    public class BBlockNormal : BBlock{

        public Texture2D Texture;
        public Vector2 Pos;
        public static Color White= Color.White;
        
        public BBlockNormal(){ }
        
        public BBlockNormal(Texture2D texture, Vector2 pos) {
            Texture=texture;
            Pos=pos;
        }

        public override void Draw() => Rabcr.spriteBatch.Draw(Texture, Pos, White);
    }

    // Top and Back
    public class BBlockEmpty: BBlock {
        public override void Draw() { }
    }

    // Only solid
    //public class BBlockEmptySolid : BBlock{

    //    public BBlock Top, Back;

    //    public override void Draw() {
    //        Back.Draw();
    //        Top.Draw();
    //    }
    //}
}