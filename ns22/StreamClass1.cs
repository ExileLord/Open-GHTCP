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
			private static readonly double[,] Double0 = {
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

			private long _long0;

			public long method_0()
			{
				return _long0;
			}
		}

		private readonly Class346<short> _class3460;

		private readonly INterface14[] _interface140;

		private readonly Class343[] _class3430;

		private readonly Stream _stream0;

		public void Dispose()
		{
			if (smethod_0(_stream0))
			{
				UpdateFinalBlocks(_stream0, _interface140.Length, 0L);
				var array = new int[_interface140.Length];
				var array2 = new int[_interface140.Length];
				for (var i = 0; i < _interface140.Length; i++)
				{
					array[i] = (int)_class3430[i].method_0() * 28;
					array2[i] = _interface140[i].imethod_0();
				}
				UpdateFinalBlocks(_stream0, array, array2, 0L);
			}
			_class3460.Dispose();
		}

		public static bool smethod_0(Stream stream1)
		{
			return stream1.CanSeek && stream1.CanRead;
		}

		public static void UpdateFinalBlocks(Stream stream1, int int0, long long0)
		{
			if (!smethod_0(stream1))
			{
				throw new ApplicationException("UpdateFinalBlocks called with non-updateable stream");
			}
			var position = stream1.Position;
			var num = long0 + 128L;
			var array = new bool[int0];
			var num2 = 0;
			var array2 = new byte[16];
			stream1.Seek(array2.Length * -1, SeekOrigin.Current);
			while (stream1.Position - num >= 16L && num2 < array.Length)
			{
				if (stream1.Read(array2, 0, array2.Length) != array2.Length)
				{
					Class355.Interface150.imethod_1("Unexpected end of stream trying to read final blocks");
				}
				var num3 = array2[1] & -129;
				if (num3 < 0 || num3 > int0)
				{
					Class355.Interface150.imethod_1(string.Format("Found reference to channel {0}, but only {1} channels expected", num3, int0));
				}
				if ((array2[1] & 128) != 0)
				{
					if (array[num3])
					{
						Class355.Interface150.imethod_0(string.Format("Found end flag for channel {0}, but it is already marked as flagged.  This VGS may be corrupt.", num3));
					}
					else
					{
						array[num3] = true;
						num2++;
					}
				}
				else if (!array[num3])
				{
					var exprF6Cp0 = array2;
					var exprF6Cp1 = 1;
					exprF6Cp0[exprF6Cp1] |= 128;
					stream1.Seek(array2.Length * -1, SeekOrigin.Current);
					stream1.Write(array2, 0, array2.Length);
					array[num3] = true;
					num2++;
				}
				stream1.Seek(array2.Length * -2, SeekOrigin.Current);
			}
			stream1.Seek(position, SeekOrigin.Begin);
		}

		public static void UpdateFinalBlocks(Stream stream1, int[] int0, int[] int1, long long0)
		{
			if (!smethod_0(stream1))
			{
				throw new ApplicationException("UpdateFinalBlocks called with non-updateable stream");
			}
			var position = stream1.Position;
			stream1.Seek(long0, SeekOrigin.Begin);
			smethod_3(stream1, int0, int1);
			stream1.Seek(position, SeekOrigin.Begin);
		}

		public static void smethod_3(Stream stream1, int[] int0, int[] int1)
		{
			if (int0.Length != int1.Length)
			{
				Class355.Interface150.imethod_1(string.Format("sampleCount length {0} does not match sampleRate length {1}", int0.Length, int1.Length));
			}
			if (!smethod_0(stream1))
			{
				for (var i = 0; i < int0.Length; i++)
				{
					if (int0[i] < 1)
					{
						throw new ApplicationException("Writing a VGS header requires knowing the data length ahead of time, or a stream that is capable of seeking and reading.");
					}
				}
			}
			var binaryWriter = new BinaryWriter(stream1);
			binaryWriter.Write(Encoding.ASCII.GetBytes("VgS!"));
			binaryWriter.Write(2);
			for (var j = 0; j < 15; j++)
			{
				if (j < int0.Length)
				{
					binaryWriter.Write((uint)int1[j]);
					binaryWriter.Write((uint)(int0[j] / 28));
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
