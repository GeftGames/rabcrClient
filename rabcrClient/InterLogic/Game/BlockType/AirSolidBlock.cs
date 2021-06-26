namespace rabcrClient {
    public class AirSolidBlock: Block{

        public Block Top, Back;

        public AirSolidBlock() {
            Id = (byte)BlockId.None;
        }

        //public void SetTopBack(Terrain chunk, int h){
        //    Top=chunk.TopBlocks[h];
        //    Back=chunk.Background[h];
        //}

        public override void Draw() {
            //Back?.Draw();
            //Top?.Draw();
        }

        public override Block CloneDown() => new AirSolidBlock{
            Back=Back?.CloneDown(),
            Top=Top?.CloneDown()
        };
    }
}