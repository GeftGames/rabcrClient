namespace rabcrClient{
    static class Release {

        // Name of version
        public const int
            VersionMajor    = 0,
            VersionMinor    = 1,
            VersionBuild    = 26,
            VersionRevision = 0;

        public const string VersionString = "0.1.26.0";

        // Special name of version
        public const string VersionSpecialName = "";

        // Release date
        public const string Date="22.01.2022";



        // Full def name of game
        public const string GameName = "RabigonCraft The most of my World";

        // Short name of game
        public const string ShortGameName = "rabcr";



        // Authors
        public const string Authors="Geft";

        // Company
        public const string Company="GeftGames";

        // Contact
        public const string WebShort="geftgames.ga";
        public const string WebFull="https://geftgames.ga/";
        public const string WebShortGame="rabcr.ga";
        public const string WebFullGame="https://rabcr.ga/";
        public const string Email="geftgames@gmail.com";

        #region Limitation for some countries
        // Banned states
        // - No flag in languages
        // - If live in these states (system detection: System.Globalization.RegionInfo.CurrentRegion), switch to english (only first run and if is supported language)
        // - Show message on startup - not supported in your region, hovever allow users to run game (10% chance in normal days and 100% show in some days)
        // - Cannot log in
        //public static string[] BannedStates={
        //    "KP", // North Korea
        //    "RU", // Russia
        //    "CN", // China
        //    "BY", // Belarus
        //    "SA", // Saudi Arabia
        //    "SY", // Syria
        //    "TM", // Turkmenistan
        //    "ER", // Eritrea
        //    "EG", // Egypt
        //    "ET", // Ethiopia
        //    "CU", // Cuba
        //    "SD", // Sudan
        //    "TD", // Chad
        //    "CG", // Republic of the Congo
        //    "SS", // South Sudan
        //    "AE"   // United Arab Emirates
        //};

        // Limited states (low banned)
        // - In some days show message - not supported in your region, however allow users to run game (33%)
        // - Don't show flag in languages
        //public static string[] LimitedStates={
        //    "AO", // Angola
        //    "SV", // El salvador
        //    "KG", // Kyrgyzstan
        //    "PK", // Pakistan
        //    "VN", // Vietnam
        //    "PG", // Papua New Guinea
        //    "AZ", // Azerbaijan
        //    "BH", // Bahrain
        //    "KH", // Cambodia
        //    "MM", // Myanmar
        //    "CM", // Cameroon
        //    "CD", // Democratic Republic of the Congo
        //    "LA", // Laos
        //    "TJ", // Tajikistan
        //    "KZ", // Kazakhstan
        //    "CF", // Central African Republic
        //    "GA", // Gabon
        //    "BI", // Burundi
        //    "VE", // Venezuela
        //    "SZ", // Eswatini
        //    "YE", // Yemen
        //    "SO", // Somalia
        //    "BN"  // Brunei
        //};

        // "in some days" meaning
        //public static GDay[] Sometime = {
        //    new GDay { Day=12, Month=2,  Name="Red Hand Day" },
        //    new GDay { Day=3,  Month=5,  Name="World Press Freedom Day" },
        //    new GDay { Day=10, Month=10, Name="World Day Against the Death Penalty" },
        //    new GDay { Day=15, Month=10, Name="International Day of Democracy" },
        //    new GDay { Day=17, Month=10, Name="International Students' Day" },
        //    new GDay { Day=9,  Month=12, Name="International Anti-Corruption Day" },
        //    new GDay { Day=10, Month=12, Name="Human Rights Day" },
        //};

        //public class GDay{
        //    public int Day, Month;
        //    public string Name;
        //}
        #endregion

        // StartUp Items
        public static ItemNonInv[] StartUpItemsBasic=new ItemNonInv[]{
            new ItemNonInvBasic((ushort)Items.StoneHead,1),
            new ItemNonInvFood((ushort)Items.Apple,1,0),
        };

        public static ItemNonInv[] StartUpItemsMedium=new ItemNonInv[]{
            new ItemNonInvTool((ushort)Items.AxeCopper),
            new ItemNonInvTool((ushort)Items.PickaxeCopper),
            new ItemNonInvTool((ushort)Items.KnifeCopper),
            new ItemNonInvFood((ushort)Items.Apple,5,0),
            new ItemNonInvTool((ushort)Items.BucketWater),
        };

        public static ItemNonInv[] StartUpItemsAdvanced=new ItemNonInv[]{
            new ItemNonInvTool((ushort)Items.ElectricDrill),
            new ItemNonInvTool((ushort)Items.ElectricSaw),
            new ItemNonInvTool((ushort)Items.TorchElectricON),
            new ItemNonInvFood((ushort)Items.Bread,5,0),
            new ItemNonInvTool((ushort)Items.BottleWater),
        };


        #region Links
        public const string
            // Report error
            stringRRE="https://***.php",

            stringBadTranslate ="https://***.php",

            // Send date through the anonymization gateway (hide ip) and check trolls
            // ... or it can go direct if you don't want to do, but its better to have gamejolt api code safe on the sever, because code its hidden!
            stringGameJoltServerGate="https://***.php?";
        #endregion
    }
} 