namespace rabcrClient {
    public class DoorBlock:Block {

        public int originalY;

        public DoorBlock() { }

        public DoorBlock(ushort id) {
            Id = id;
        }

        public override void Draw(){}

        public override Block CloneDown() => new DoorBlock{
            Id=Id,
        };
    }
}