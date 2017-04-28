using System;
using System.IO;
using System.Text;
using ns9;

namespace ns22
{
	public class StreamClass1 : IDisposable
	{
		private class Class343
		{
			private static readonly double[,] double_0 = {
				{
					0.0,
					0.0
				},
				{
					-0.9375,
					0.0
				},
				{
					-1.796875,
					0.8125
				},
				{
					-1.53125,
					0.859375
				},
				{
					-1.90625,
					0.9375
				}
			};

			private long long_0;

			public long method_0()
			{
				return long_0;
			}
		}

		private readonly Class346<short> class346_0;

		private readonly Interface14[] interface14_0;

		private readonly Class343[] class343_0;

		private readonly Stream stream_0;

		public void Dispose()
		{
			if (smethod_0(stream_0))
			{
				UpdateFinalBlocks(stream_0, interface14_0.Length, 0L);
				int[] array = new int[interface14_0.Length];
				int[] array2 = new int[interface14_0.Length];
				for (int i = 0; i < interface14_0.Length; i++)
				{
					array[i] = (int)class343_0[i].method_0() * 28;
					array2[i] = interface14_0[i].imethod_0();
				}
				UpdateFinalBlocks(stream_0, array, array2, 0L);
			}
			class346_0.Dispose();
		}

		public static bool smethod_0(Stream stream_1)
		{
			return stream_1.CanSeek && stream_1.CanRead;
		}

		public static void UpdateFinalBlocks(Stream stream_1, int int_0, long long_0)
		{
			if (!smethod_0(stream_1))
			{
				throw new ApplicationException("UpdateFinalBlocks called with non-updateable stream");
			}
			long position = stream_1.Position;
			long num = long_0 + 128L;
			bool[] array = new bool[int_0];
			int num2 = 0;
			byte[] array2 = new byte[16];
			stream_1.Seek(array2.Length * -1, SeekOrigin.Current);
			while (stream_1.Position - num >= 16L && num2 < array.Length)
			{
				if (stream_1.Read(array2, 0, array2.Length) != array2.Length)
				{
					Class355.interface15_0.imethod_1("Unexpected end of stream trying to read final blocks");
				}
				int num3 = array2[1] & -129;
				if (num3 < 0 || num3 > int_0)
				{
					Class355.interface15_0.imethod_1(string.Format("Found reference to channel {0}, but only {1} channels expected", num3, int_0));
				}
				if ((array2[1] & 128) != 0)
				{
					if (array[num3])
					{
						Class355.interface15_0.imethod_0(string.Format("Found end flag for channel {0}, but it is already marked as flagged.  This VGS may be corrupt.", num3));
					}
					else
					{
						array[num3] = true;
						num2++;
					}
				}
				else if (!array[num3])
				{
					byte[] expr_F6_cp_0 = array2;
					int expr_F6_cp_1 = 1;
					expr_F6_cp_0[expr_F6_cp_1] |= 128;
					stream_1.Seek(array2.Length * -1, SeekOrigin.Current);
					stream_1.Write(array2, 0, array2.Length);
					array[num3] = true;
					num2++;
				}
				stream_1.Seek(array2.Length * -2, SeekOrigin.Current);
			}
			stream_1.Seek(position, SeekOrigin.Begin);
		}

		public static void UpdateFinalBlocks(Stream stream_1, int[] int_0, int[] int_1, long long_0)
		{
			if (!smethod_0(stream_1))
			{
				throw new ApplicationException("UpdateFinalBlocks called with non-updateable stream");
			}
			long position = stream_1.Position;
			stream_1.Seek(long_0, SeekOrigin.Begin);
			smethod_3(stream_1, int_0, int_1);
			stream_1.Seek(position, SeekOrigin.Begin);
		}

		public static void smethod_3(Stream stream_1, int[] int_0, int[] int_1)
		{
			if (int_0.Length != int_1.Length)
			{
				Class355.interface15_0.imethod_1(string.Format("sampleCount length {0} does not match sampleRate length {1}", int_0.Length, int_1.Length));
			}
			if (!smethod_0(stream_1))
			{
				for (int i = 0; i < int_0.Length; i++)
				{
					if (int_0[i] < 1)
					{
						throw new ApplicationException("Writing a VGS header requires knowing the data length ahead of time, or a stream that is capable of seeking and reading.");
					}
				}
			}
			BinaryWriter binaryWriter = new BinaryWriter(stream_1);
			binaryWriter.Write(Encoding.ASCII.GetBytes("VgS!"));
			binaryWriter.Write(2);
			for (int j = 0; j < 15; j++)
			{
				if (j < int_0.Length)
				{
					binaryWriter.Write((uint)int_1[j]);
					binaryWriter.Write((uint)(int_0[j] / 28));
				}
				else
				{
					binaryWriter.Write(0u);
					binaryWriter.Write(0u);
				}
			}
		}
	}
}
