namespace rabcrClient {
    public class AirBlock: Block{

        public AirBlock() {
            Id = (ushort)BlockId.None;
        }

        public override Block CloneDown() => new AirBlock();

        public override void Draw() { }
    }
}