 enum BlockId: ushort {
    None,
    _SkipNone,
    _SkipBlock,

    Flag,
    Windmill,

    Label,

    Shelf,
    BoxAdv,
    BoxWooden,

    FurnaceStone,
    Miner,
    Charger,
    OxygenMachine,
    Composter,

    BucketForRubber,

    WaterBlock,
    WaterSalt,
        
    Barrel, 
        

    _MoreInLoad,  
        
    Lava,
        
    #region Trees
    OakLeaves,
    OakWood,
    OakBranches,

    SpruceLeaves,
    SpruceWood,

    PineLeaves,
    PineWood,

    LindenLeaves,
    LindenWood,
    LindenBranches,

    AppleLeaves,
    AppleLeavesWithApples,
    AppleLeavesBlossom,
    AppleWood,
    AppleBranches,

    CherryLeaves,
    CherryLeavesWithCherries,
    CherryLeavesBlossom,
    CherryWood,
    CherryBranches,

    PlumLeaves,
    PlumLeavesWithPlums,
    PlumLeavesBlossom,
    PlumWood,
    PlumBranches,

    LemonWood,
    LemonLeaves,
    LemonLeavesWithLemons,

    OrangeWood,
    OrangeLeaves,
    OrangeLeavesWithOranges,

    WillowLeaves,
    WillowWood,
    WillowBranches,

    MangroveLeaves,
    MangroveWood,

    EucalyptusLeaves,
    EucalyptusWood,

    OliveLeavesWithOlives,
    OliveLeaves,
    OliveWood,

    RubberTreeLeaves,
    RubberTreeWood,

    AcaciaLeaves,
    AcaciaWood,

    KapokLeacesFlowering,
    KapokLeacesFibre,
    KapokLeaves,
    KapokWood,
    #endregion

    #region Stone
    StoneGneiss,
    StoneDolomite,
    StoneRhyolite,
    StoneLimestone,
    StoneSchist,
    StoneBasalt,
    StoneDiorit,
    StoneSandstone,
    StoneGabbro,
    #endregion

    #region Background
    BackDirt,
    BackSand,
    BackCobblestone,
    BackGravel,

    BackAnorthosite,
    BackBasalt,
    BackClay,
    BackDiorit,
    BackDolomite,
    BackFlint,
    BackGabbro,
    BackGneiss,
    BackLimestone,
    BackMudstone,
    BackRedSand,
    BackRegolite,
    BackRhyolite,
    BackSandstone,
    BackSchist,

    BackCoal,
    BackCopper,
    BackTin,
    BackIron,
    BackAluminium,
    BackSilver,
    BackGold,
    BackSulfur,
    BackSaltpeter,
    #endregion

    #region Ore
    Oil,
    OreCoal,
    OreCopper,
    OreTin,
    OreGold,
    OreSilver,
    OreIron,
    OreAluminium,
    OreSulfur,
    OreSaltpeter,
    #endregion

    Cobblestone,
    Gravel,
    Sand,
    Dirt,
    Clay,

    GrassBlockPlains,
    GrassBlockHills,
    GrassBlockDesert,
    GrassBlockForest,
    GrassBlockJungle,
    GrassBlockClay,
    GrassBlockCompost,

    GrassBlockSnowPlains,
    GrassBlockSnowHills,
    GrassBlockSnowDesert,
    GrassBlockSnowForest,
    GrassBlockSnowJungle,
    GrassBlockSnowClay,
    GrassBlockSnowCompost,

    #region Plants
    Violet,
    Rose,
    Orchid,
    Dandelion,
    Alore,
    Heather,

    Strawberry,
    Rashberry,
    Blueberry,
    Fish,
    //  Flax,
    Wheat,
    SugarCane,
    Onion,
    Peas,
    Carrot,
    Toadstool,
    Champignon,
    Boletus,

    Coral,
    Seaweed,
    #endregion

    CactusBig,
    CactusSmall,

    //   Liana,



    //water
    Ice,
    Snow,
    SnowTop,

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
    BranchALittle1,
    BranchALittle2,

    //Animals
    Bird,
    Rabbit,
    Flax,
    Chicken,

    //Saplings
    OrangeSapling,
    LemonSapling,
    AppleSapling,
    PlumSapling,
    CherrySapling,
    OakSapling,
    CinchonaSapling,
    LindenSapling,
    SpruceSapling,
    PineSapling,
    WillowSapling,
    MangroveSapling,
    EucalyptusSapling,
    OliveSapling,
    RubberTreeSapling,
    AcaciaSapling,
    KapokSapling,


    //Mashines
    Desk,
    SewingMachine,
    Ladder,
    DoorOpen,
    DoorClose,

    EggDrop,

    Bricks,
    Roof1,
    Roof2,

    Glass,


    //Adv mashines

    SolarPanel,
    Watermill,



    Lamp,
    FurnaceElectric,
    Macerator,

    Rocket,
    Radio,
    //   Batery,

    //Adv blocks
    AdvancedSpaceBlock,
    AdvancedSpaceBack,
    AdvancedSpaceWindow,
    AdvancedSpaceFloor,
    AdvancedSpacePart1,
    AdvancedSpacePart2,
    AdvancedSpacePart3,
    AdvancedSpacePart4,

    RocketBase,
    MainRocketController,
    TankNottle,

    Fireplace,

    //DolomiteBricks,
    //BasaltBricks,
    //LimestoneBricks,
    //RhyoliteBricks,
    //GneissBricks,
    //SandstoneBricks,
    //SchistBricks,
    //GabbroBricks,
    //DioritBricks,

    Planks,

    BurningTorch,
    NotBurningTorch,
    Anorthosite,
    Regolite,
    RedSand,
    MudStone,
    Compost,

    Mud,


    BucketWithLatex,

    ChristmasStar,
    AngelHair,
    ChristmasBall,
    ChristmasBallYellow,
    ChristmasBallBlue,
    ChristmasBallTeal,
    ChristmasBallOrange,
    ChristmasBallRed,
    ChristmasBallPink,
    ChristmasBallPurple,
    ChristmasBallLightGreen,
}