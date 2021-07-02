namespace rabcrClient {
    static class Global {
        public static int WindowWidth=300;
        public static float ItemAnimation, ItemAnimation2,itemAnimationPos;
        public static int WindowHeight=250;

        public static int WindowWidthHalf=300;

        public static int WindowHeightHalf=250;
        public static int WorldDifficulty;
        public static bool HasSoundGraphics=true;

        public static bool ChangedSettings;
        public static bool YoungPlayer=true;
       // public static bool OnlineAccount;
      //  public static bool Logged;
      //  public static string Pass;

        public const float ScaleBigToMedium=0.4523809523809524f;
        public const float ScaleMediumToSmall=0.8421052631578947f;
        public const float ScaleBiggestToBig=0.525f;

        public static string GameName;//="Rabigoncraft the Most of My World";//Omicronecraft

        public static string MessageGedoInfo="/Message \"<Bold>Informace o GeDo tagech</Bold>" +
            "<NewLine>"+

            "<Spoiler|show=Informace o tagách|hide=Skrýt informace o tagách>"+
            "Použití: &l;xxx&g;Text&l;/xxx&g; (za xxx dosaďte typy stylů)"+
            "<NewLine>Tagy se nesmí překrývat &l;Bold&g;1&l;Italic&g;2&l;/Bold&g;3&l;/Italic&g;4 &l;- špatně"+
            "<NewLine>V tagu se nesmí být tag &l;Bold&g;&l;Italic&g;bla&l;/Italic&g;&l;/Bold&g; &;- špatně"+
            "<NewLine>Výše udedené neplatí pro Article a Spoiler"+
            "<NewLine>Mezi tagy nesmí být symbol nového řádku: bla&l;Bold&g;bla(Nový řádek)bla&l;/Bold&g;bla &l;- špatně"+
            "<NewLine>Text v tagách by neměl obsahovat symboly &l; a &g;, můžete je napsat pomocí &...;"+
            "</Spoiler>"+

            "<Spoiler|show=Všechny typy tagů|hide=Skrýt typy tagů>"+
            "Barvy: <White>White</White> (White, bílá na bílé je špatně vidět), <Yellow>Yellow</Yellow>, <Gold>Gold</Gold>, <Orange>Orange</Orange>, <Red>Red</Red>," +
            "<NewLine><DarkRed>DarkRed</DarkRed>, <Purple>Purple</Purple>, <Pink>Pink</Pink>, <LightBlue>LightBlue</LightBlue>, <Blue>Blue</Blue>, <DarkBlue>DarkBlue</DarkBlue>, <Teal>Teal</Teal>, <LightGreen>LightGreen</LightGreen>, <Green>Green</Green>," +
            "<NewLine><DarkGreen>DarkGreen</DarkGreen>, <Brown>Brown</Brown>, <Gray>Gray</Gray>, <DarkGray>DarkGray</DarkGray>, <Black>Black</Black>"+
            "<NewLine>Barevné efekty: <Mark>Mark</Mark>, <Animated>Animated</Animated>, <Random>Random</Random>"+
            "<NewLine>Typ textu: <Bold>Bold</Bold>, <Italic>Italic</Italic>, <Underline>Underline</Underline>, <Link>Link</Link>, <Subscript>Subscript</Subscript>"+
            "<NewLine>Složitější co povolují sub-tagy: &l;Spoiler&g; a &l;Article&g;"+
            "</Spoiler>"+

            "<Spoiler|show=Rozšíření tagů|hide=Skrýt rozšíření tagů>"+
            "Link-url: &l;Link<Red>|</Red><Blue>url</Blue>=<Green>https://geftgames.ga/</Green>&g;web&l;/Link&g;  <Link|url=https://geftgames.ga/>web</Link>"+
            "<NewLine>Link-run: &l;Link<Red>|</Red><Blue>run</Blue>=<Green>cmd</Green><Red>|</Red><Blue>args</Blue>=<Green>/k echo Hello</Green>&g;Hello&l;/Link&g;  <Link|run=cmd|args=/k echo Hello>Hello</Link>"+
            "<NewLine>Animated: &l;Animated<Red>|</Red><Blue>back</Blue>=<Green>Green</Green><Red>|</Red><Blue>fore</Blue>=<Green>Yellow</Green>&g;blabla&l;/Animated&g;  <Animated|back=Green|fore=Yellow>blabla</Animated>"+
            "<NewLine>Mark: &l;Mark<Red>|</Red><Blue>color</Blue>=<Green>LightGreen</Green>&g;blabla&l;/Mark&g;  <Mark|color=LightGreen>blabla</Mark>"+
            "<NewLine>Červeně označený symbol je svislá čára (pravý Alt + W)</Spoiler>"+

            "<Spoiler|show=Více o rozšíření Link|hide=Skrýt více o rozšíření Link>" +
            "Nebezpečná url: &l;Link<Red>|</Red><Blue>url</Blue>=<Green>cmd.exe</Green>&g;url&l;/Link&g;  <Link|url=cmd.exe>odkaz</Link>"+
            "<NewLine>Nebezpečná url se tváří jako odkaz na stránku, ale může spustit soubor v počítači"+
            "<NewLine>Chybně napsaná url (chybí http): &l;Link<Red>|</Red><Blue>url</Blue>=<Green>google.com</Green>&g;url&l;/Link&g;  <Link|url=google.com>odkaz</Link>"+
            "<NewLine>Link-event (jen pro systémové účely, nefunguje běžně): &l;Link<Red>|</Red><Blue>event</Blue>=<Green>1</Green>&g;url&l;/Link&g;  <Link|event=1>web</Link>"+
            "</Spoiler>" +

            "<Spoiler|show=Symboly|hide=Skrýt symboly>" +
            "<NewLine><Black>&</Black>t; <Green>Tab (5 mezer)</Green>" +
            "<NewLine>&g<Black>;</Black> <Green>&g;</Green>"+
            "<NewLine>&l<Black>;</Black> <Green>&l;</Green>" +
            "</Spoiler>" +

            "<Spoiler|show=Jak spustit?|hide=Skrýt jak spustit>" +
            "Standartně:"+
            "<NewLine><Green>\"...\\rabcr.exe\"</Green> <Blue>/MessageCZ</Blue> <Red>\"bla&l;Bold&g;bla&l;/Bold&g;bla\"</Red>" +
            "<NewLine>Tohle okno:"+
            "<NewLine><Green>\"...\\rabcr.exe\"</Green> <Blue>/MessageCZ</Blue> <Red>Info</Red>" +
            "</Spoiler>"+

            "<Spoiler|show=Co nemám používat v jednořádkovém GeDo?|hide=Skrýt co nemám používat v jednořádkovém GeDo>" +
            "Týká se např. ve hře <Green>Názvu světa</Green>"+
            "<NewLine><Red>&l;Spoiler&g;</Red>, <Red>&l;Article&g;</Red> a <Red>&l;NewLine&g;</Red>" +
            "</Spoiler>\"";
    }
}