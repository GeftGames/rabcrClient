namespace rabcrClient {
    static unsafe class FastBitConverter {
        public unsafe static byte[] GetBytes(int value) {
            byte* pointer=(byte*)&value;
            return new byte[]{ *pointer++, *pointer++, *pointer++, *pointer };

            /*
            byte[] bytes = new byte[4];
            fixed (byte* b = bytes) *(int*)b = value;
            return bytes;
            */
        }

        public unsafe static byte[] GetBytes(float value) {
           /*  byte* pointer=(byte*)&value;
            return new byte[]{ *pointer++, *pointer++, *pointer++, *pointer };
 */
           
            byte[] bytes = new byte[4];
            fixed (byte* b = bytes) *(float*)b = value;
            return bytes;

        }
    }
}
