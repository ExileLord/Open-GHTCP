using System;
using System.IO;
using System.Text;

namespace ns22
{
	public class ByteFiddler
	{
		public static ushort RotateRight(ushort ushort_0)
		{
			return (ushort)((ushort_0 >> 8 | (int)ushort_0 << 8) & 65535);
		}

		public static uint RotateLeft(uint uint_0)
		{
			return uint_0 >> 24 | uint_0 << 24 | (uint_0 >> 8 & 65280u) | (uint_0 << 8 & 16711680u);
		}

		public static int DivideSixtyMillionBy(float float_0)
		{
			return (int)(6E+07f / float_0);
		}

		public static string smethod_3(string string_0, BinaryReader binaryReader_0, string string_1)
		{
			long position = binaryReader_0.BaseStream.Position;
			string @string = Encoding.ASCII.GetString(binaryReader_0.ReadBytes(string_1.Length));
			if (@string != string_1)
			{
				Console.WriteLine(string.Format("Reading {0} at position {1}: expected {2}, found {3}", new object[]
				{
					string_0,
					position,
					string_1,
					@string
				}));
			}
			return @string;
		}
	}
}
