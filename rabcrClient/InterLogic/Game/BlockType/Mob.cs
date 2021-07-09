using Microsoft.Xna.Framework;

namespace rabcrClient {
    public abstract class Mob {
        public byte Height{
            get { return (byte)(Position.Y/16);}
            set{ Position.Y=((float)value)*16;}
        }
        public ushort Id;
        public Vector2 Position;
        public bool Dir;


        protected Mob() { }

        public abstract byte[] Save();

        public virtual void Update(){ }

        public virtual void Draw(){ }
    }

    public abstract class MMob {
        public byte Height { get { return (byte)(Position.Y/16); } set { Position.Y=((float)value)*16; } }
        public byte Id;
        public Vector2 Position;
        public bool Dir;

        public bool Exists = true;

        protected MMob() { }

        public virtual void Update() { }

        public virtual void Draw() { }
    }
}