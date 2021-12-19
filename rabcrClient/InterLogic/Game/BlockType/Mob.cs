using Microsoft.Xna.Framework;

namespace rabcrClient {
    public abstract class Mob {

        public byte Height {
            get { return (byte)(Position.Y/16); }
            set { Position.Y=((float)value)*16; }
        }

        public ushort Id;
        public Vector2 Position;
        public bool Dir;
        public float Lives;
        public float MaxLives;

        protected Mob() { }

        public virtual byte[] Save() => null;

        public virtual void Update() { }

        public virtual void Draw() { }
    }

    public abstract class MMob {
        public byte Height {
            get { return (byte)(Position.Y/16); }
            set { Position.Y=((float)value)*16; }
        }
        public ushort Id;
        public Vector2 Position;
        public bool Dir;

        public MBlockState Exists;

        protected MMob() { }

        public virtual byte[] Save() => null;

        public virtual void Update() { }

        public virtual void Draw() { }
    }
}