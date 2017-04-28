using System;
using System.IO;

namespace ns19
{
	public class Class320
	{
		private static readonly int Int0 = 4096;

		private static readonly int Int1 = 18;

		private static readonly int Int2 = 2;

		private int _int3;

		private int _int4;

		private readonly int[] _int5 = new int[Int0 + 1];

		private readonly int[] _int6 = new int[Int0 + 257];

		private readonly int[] _int7 = new int[Int0 + 1];

		private readonly byte[] _byte0 = new byte[Int0 + Int1 - 1];

		public byte[] method_0(byte[] byte1)
		{
			MemoryStream memoryStream2;
			using (var memoryStream = new MemoryStream(byte1))
			{
				MemoryStream memoryStream3;
				memoryStream2 = (memoryStream3 = new MemoryStream());
				try
				{
					method_1(memoryStream, memoryStream2);
				}
				finally
				{
					if (memoryStream3 != null)
					{
						((IDisposable)memoryStream3).Dispose();
					}
				}
			}
			return memoryStream2.ToArray();
		}

		public void method_1(Stream stream0, Stream stream1)
		{
			if (!stream0.CanRead)
			{
				throw new IOException("Input stream is not readable.");
			}
			if (!stream1.CanWrite)
			{
				throw new IOException("Output stream is not writable.");
			}
			var num = Int0 - Int1;
			var num2 = 0;
			var num3 = 1;
			var array = new byte[17];
			byte b = 1;
			var num4 = stream0.Length - stream0.Position;
			for (var i = Int0 + 1; i <= Int0 + 256; i++)
			{
				_int6[i] = Int0;
			}
			for (var i = 0; i < Int0; i++)
			{
				_int7[i] = Int0;
			}
			array[0] = 0;
			for (var i = num2; i < _byte0.Length; i++)
			{
				_byte0[i] = 32;
			}
			int j;
			for (j = 0; j < Int1; j++)
			{
				var exprC0 = num4;
				num4 = exprC0 - 1L;
				if (exprC0 <= 0L)
				{
					break;
				}
				_byte0[num + j] = (byte)stream0.ReadByte();
			}
			for (var i = 1; i <= Int1; i++)
			{
				method_2(num - i);
			}
			method_2(num);
			do
			{
				if (_int4 > j)
				{
					_int4 = j;
				}
				if (_int4 <= Int2)
				{
					_int4 = 1;
					var expr136Cp0 = array;
					var expr136Cp1 = 0;
					expr136Cp0[expr136Cp1] |= b;
					array[num3++] = _byte0[num];
				}
				else
				{
					array[num3++] = (byte)_int3;
					array[num3++] = (byte)((_int3 >> 4 & 240) | _int4 - (Int2 + 1));
				}
				int i;
				if ((b = (byte)(b << 1)) == 0)
				{
					for (i = 0; i < num3; i++)
					{
						stream1.WriteByte(array[i]);
					}
					array[0] = 0;
					var arg_1Bc0 = 1;
					b = 1;
					num3 = arg_1Bc0;
				}
				var num5 = _int4;
				for (i = 0; i < num5; i++)
				{
					var expr_1Cc = num4;
					num4 = expr_1Cc - 1L;
					if (expr_1Cc <= 0L)
					{
						break;
					}
					method_3(num2);
					_byte0[num2] = (byte)stream0.ReadByte();
					if (num2 < Int1 - 1)
					{
						_byte0[num2 + Int0] = _byte0[num2];
					}
					num2 = (num2 + 1 & Int0 - 1);
					num = (num + 1 & Int0 - 1);
					method_2(num);
				}
				while (i++ < num5)
				{
					method_3(num2);
					num2 = (num2 + 1 & Int0 - 1);
					num = (num + 1 & Int0 - 1);
					if (--j != 0)
					{
						method_2(num);
					}
				}
			}
			while (j > 0);
			if (num3 > 1)
			{
				for (var i = 0; i < num3; i++)
				{
					stream1.WriteByte(array[i]);
				}
			}
		}

		private void method_2(int int8)
		{
			var num = 1;
			var num2 = Int0 + 1 + _byte0[int8];
			_int6[int8] = (_int5[int8] = Int0);
			_int4 = 0;
			while (true)
			{
				if (num >= 0)
				{
					if (_int6[num2] == Int0)
					{
						goto IL_C3;
					}
					num2 = _int6[num2];
				}
				else
				{
					if (_int5[num2] == Int0)
					{
						goto IL_168;
					}
					num2 = _int5[num2];
				}
				var num3 = 1;
				while (num3 < Int1 && (num = _byte0[int8 + num3] - _byte0[num2 + num3]) == 0)
				{
					num3++;
				}
				if (num3 > _int4)
				{
					_int3 = num2;
					if ((_int4 = num3) >= Int1)
					{
						break;
					}
				}
			}
			_int7[int8] = _int7[num2];
			_int5[int8] = _int5[num2];
			_int6[int8] = _int6[num2];
			_int7[_int5[num2]] = int8;
			_int7[_int6[num2]] = int8;
			if (_int6[_int7[num2]] == num2)
			{
				_int6[_int7[num2]] = int8;
			}
			else
			{
				_int5[_int7[num2]] = int8;
			}
			_int7[num2] = Int0;
			return;
			IL_C3:
			_int6[num2] = int8;
			_int7[int8] = num2;
			return;
			IL_168:
			_int5[num2] = int8;
			_int7[int8] = num2;
		}

		private void method_3(int int8)
		{
			if (_int7[int8] == Int0)
			{
				return;
			}
			int num;
			if (_int6[int8] == Int0)
			{
				num = _int5[int8];
			}
			else if (_int5[int8] == Int0)
			{
				num = _int6[int8];
			}
			else
			{
				num = _int5[int8];
				if (_int6[num] != Int0)
				{
					do
					{
						num = _int6[num];
					}
					while (_int6[num] != Int0);
					_int6[_int7[num]] = _int5[num];
					_int7[_int5[num]] = _int7[num];
					_int5[num] = _int5[int8];
					_int7[_int5[int8]] = num;
				}
				_int6[num] = _int6[int8];
				_int7[_int6[int8]] = num;
			}
			_int7[num] = _int7[int8];
			if (_int6[_int7[int8]] == int8)
			{
				_int6[_int7[int8]] = num;
			}
			else
			{
				_int5[_int7[int8]] = num;
			}
			_int7[int8] = Int0;
		}

		public byte[] method_4(byte[] byte1)
		{
			MemoryStream memoryStream2;
			using (var memoryStream = new MemoryStream(byte1))
			{
				MemoryStream memoryStream3;
				memoryStream2 = (memoryStream3 = new MemoryStream());
				try
				{
					method_5(memoryStream, memoryStream2);
				}
				finally
				{
					if (memoryStream3 != null)
					{
						((IDisposable)memoryStream3).Dispose();
					}
				}
			}
			return memoryStream2.ToArray();
		}

		public void method_5(Stream stream0, Stream stream1)
		{
			if (!stream0.CanRead)
			{
				throw new IOException("Input stream is not readable.");
			}
			if (!stream1.CanWrite)
			{
				throw new IOException("Output stream is not writable.");
			}
			var num = Int0 - Int1;
			var num2 = 0;
			var num3 = stream0.Length - stream0.Position;
			for (var i = 0; i < _byte0.Length; i++)
			{
				_byte0[i] = 32;
			}
			while (num3 > 0L)
			{
				if (((num2 >>= 1) & 256) == 0)
				{
					num3 -= 1L;
					num2 = (stream0.ReadByte() | 65280);
				}
				if ((num2 & 1) != 0)
				{
					num3 -= 1L;
					stream1.WriteByte(_byte0[num++] = (byte)stream0.ReadByte());
					num &= Int0 - 1;
				}
				else
				{
					num3 -= 2L;
					int num4 = (byte)stream0.ReadByte();
					int num5 = (byte)stream0.ReadByte();
					num4 |= (num5 & 240) << 4;
					num5 = (num5 & 15) + Int2;
					for (var j = 0; j <= num5; j++)
					{
						stream1.WriteByte(_byte0[num++] = _byte0[num4 + j & Int0 - 1]);
						num &= Int0 - 1;
					}
				}
			}
		}
	}
}
