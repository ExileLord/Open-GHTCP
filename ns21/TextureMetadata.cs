using System;

namespace ns21
{
	public class TextureMetadata
	{
		public short unkShort0; // Only used on loading and saving. Value of 0x200 (512) for green note

		public int unkInt;      // Only used on loading and saving. Value of 0x151ee874 for green note

        public short Width;

		public short Height;

		public short unkShort3; // Only used on loading and saving. Value of 0x01 for green note. Maybe number of frames?

		public byte MipMapCount;    

		public short unkShort4; // Only used on loading and saving. Value of 0x0805 for green note

		public int StartIndex;

		public int Length; //Probably

		public byte[] Data;

		public TextureMetadata(short short_5, int int_3, short short_6, short short_7, short short_8, byte byte_2, short short_9, int int_4, int int_5)
		{
			this.unkShort0 = short_5;
			this.unkInt = int_3;
			this.Width = short_6;
			this.Height = short_7;
			this.unkShort3 = short_8;
			this.MipMapCount = byte_2;
			this.unkShort4 = short_9;
			this.StartIndex = int_4;
			this.Length = int_5;
		}
	}
}
