namespace rabcrClient {
    public enum SaveType : byte{
        Unknown,

        Air,
        AirMultiple,

        // id <= 255
        SolidBlockWithLowId,
        SolidBlockWithLowIdMultiple,

        BackBlockWithLowId,
        BackBlockWithLowIdMultiple,

        TopBlockWithLowId,
        TopBlockWithLowIdMultiple,

        BackBlockWithLowIdAndTopBlockWithLowId,
        BackBlockWithLowIdAndTopBlockWithLowIdMultiple,

        TopBlockWithLowIdMoreLoad,
        TopBlockWithLowIdMoreLoadMultiple,

        BackBlockWithLowIdAndTopBlockWithLowIdMoreLoad,
        BackBlockWithLowIdAndTopBlockWithLowIdMoreLoadMultiple,

        // semi
        BackBlockAndTopBlockWithLowId,
        BackBlockAndTopBlockWithLowIdMultiple,

        BackBlockWithLowIdAndTopBlock,
        BackBlockWithLowIdAndTopBlockMultiple,

        BackBlockAndTopBlockWithLowIdMoreLoad,
        BackBlockAndTopBlockWithLowIdMoreLoadMultiple,

        BackBlockWithLowIdAndTopBlockMoreLoad,
        BackBlockWithLowIdAndTopBlockMoreLoadMultiple,

        // id >= 256
        SolidBlock,
        SolidBlockMultiple,

        BackBlock,
        BackBlockMultiple,

        TopBlock,
        TopBlockMultiple,

        BackBlockAndTopBlock,
        BackBlockAndTopBlockMultiple,

        TopBlockMoreLoad,
        TopBlockMoreLoadMultiple,

        BackBlockAndTopBlockMoreLoad,
        BackBlockAndTopBlockMoreLoadMultiple,
    }
}