using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace rabcrClient {
    public class FallingBlockInfo{
        public NormalBlock block;
        public DInt to, to16;
        public bool side;
    }

    public class ClothesTypeUnderwearDown {
        public Texture2D TextureStatic, TextureWalking, TextureSwimming;
        public bool Colorize;
        public Color Color;
    }

    public class ClothesTypeUnderwearUp {
        public Texture2D TextureStatic, TextureWalking, TextureSwimming;
        public bool Colorize;
        public Color Color;
    }

    public class ClothesTypeTShirt{
        public Texture2D
            TextureStatic,
            TextureWalking,
            Texture2DClothHand;
        public HandClothSize handSize;
        public bool Colorize;
        public bool ShowBodyChest;
        public bool IsDress;
        public Color Color;
    }

    public class ClothesTypeCoat{
        public Texture2D
            TextureStatic,
            TextureWalking,
            Texture2DClothHand;
        public HandClothSize handSize;
        public bool Colorize;
        public bool ShowTShirt;
        public Color Color;
    }

    public class ClothesTypeTrousers{
        public Texture2D TextureStatic, TextureWalking, TextureSwimming;
        public bool Colorize;
        public bool ShowBodyLegs;
        public Color Color;
    }

    public class ClothesTypeBoots{
        public Texture2D TextureStatic, TextureWalking, TextureSwimming;
        public bool Colorize;
        public bool ShowBodyFeet;
        public Color Color;
    }

    public class ClothesTypeHelmet{
        public Texture2D TextureStatic, TextureWalkingOrSwimming;
        public bool Colorize;
        public bool ShinkHair;
        public Color Color;
    }
    public enum HandClothSize : byte{
        None=0,
        Half=18/2,
        NearlyFull=18-4,
        Full=18,
    }
}
