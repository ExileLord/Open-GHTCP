namespace ns21
{
	public class TextureMetadata
	{
		public short unkFlags; // Only used on loading and saving. Value of 0x200 (512) for green note

		public int Key;      // Only used on loading and saving. Value of 0x151ee874 for green note

        public short Width;

		public short Height;

		public short unkShort3; // Only used on loading and saving. Value of 0x01 for green note. Maybe number of frames?

		public byte MipMapCount;    

		public short unkShort4; // Only used on loading and saving. Value of 0x0805 for green note

		public int StartIndex;

		public int Length; //Probably

		public byte[] Data;

		public TextureMetadata(short unkFlags, int key, short Width, short Height, short unkShort3, byte MipMapCount, short unkShort4, int StartIndex, int Length)
		{
			this.unkFlags = unkFlags;
			Key = key;
			this.Width = Width;
			this.Height = Height;
			this.unkShort3 = unkShort3;
			this.MipMapCount = MipMapCount;
			this.unkShort4 = unkShort4;
			this.StartIndex = StartIndex;
			this.Length = Length;
		}
	}
}
