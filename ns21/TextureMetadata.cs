using System;

namespace ns21
{
	public class TextureMetadata
	{
		public short short_0;

		public int unkInt;

		public short short_1;

		public short short_2;

		public short short_3;

		public byte byte_0;

		public short short_4;

		public int StartIndex;

		public int Length; //Probably

		public byte[] Data;

		public TextureMetadata(short short_5, int int_3, short short_6, short short_7, short short_8, byte byte_2, short short_9, int int_4, int int_5)
		{
			this.short_0 = short_5;
			this.unkInt = int_3;
			this.short_1 = short_6;
			this.short_2 = short_7;
			this.short_3 = short_8;
			this.byte_0 = byte_2;
			this.short_4 = short_9;
			this.StartIndex = int_4;
			this.Length = int_5;
		}
	}
}
