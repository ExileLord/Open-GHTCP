using System;
using System.IO;
using GHNamespaceJ;
using SharpAudio.ASC.Mp3.Decoding;

namespace GHNamespaceI
{
	public class Class82
	{
		private int _int0;

		private byte[] _byte0;

		public static byte Byte1;

		public static byte Byte2 = 1;

		private int[] _int1;

		private int _int2;

		private byte[] _byte3;

		private int _int3;

		private int _int4;

		private int _int5;

		private bool _bool0;

		private readonly int[] _int6 = {
			0,
			1,
			3,
			7,
			15,
			31,
			63,
			127,
			255,
			511,
			1023,
			2047,
			4095,
			8191,
			16383,
			32767,
			65535,
			131071
		};

		private readonly ZzStreamClass106 _class1060;

		private ZzSoundClass _class1070;

		private byte[] _byte4;

		private Class101[] _class1010;

		private bool _bool1 = true;

		private void method_0()
		{
			_class1010 = new Class101[1];
			_byte4 = new byte[4];
			_byte3 = new byte[1732];
			_int1 = new int[433];
			_class1070 = new ZzSoundClass();
		}

		public Class82(Stream stream0, int int7) : this(new ZzStreamClass106(stream0, int7))
		{
		}

		public Class82(ZzStreamClass106 class1061)
		{
			method_0();
			if (class1061 == null)
			{
				throw new NullReferenceException("in");
			}
			method_17(class1061.method_0());
			_class1060 = class1061;
			method_7();
		}

		public void method_1()
		{
			try
			{
				_class1060.method_3();
			}
			catch (IOException exception)
			{
				throw new BitstreamException(BitstreamError.StreamError, exception);
			}
		}

		public int method_2()
		{
			return _int0;
		}

		public ZzSoundClass method_3()
		{
			ZzSoundClass @class = null;
			try
			{
				@class = method_4();
				if (_bool1)
				{
					@class.method_2(_byte3);
					_bool1 = false;
				}
			}
			catch (BitstreamException ex)
			{
				if (ex.Error == BitstreamError.InvalidFrame)
				{
					try
					{
						method_7();
						@class = method_4();
						goto IL_7A;
					}
					catch (BitstreamException ex2)
					{
						if (ex2.Error != BitstreamError.StreamEof)
						{
							throw new BitstreamException(ex2.Error, ex2);
						}
						goto IL_7A;
					}
				}
				if (ex.Error != BitstreamError.StreamEof)
				{
					throw new BitstreamException(ex.Error, ex);
				}
				IL_7A:;
			}
			return @class;
		}

		private ZzSoundClass method_4()
		{
			if (_int2 == -1)
			{
				method_5();
			}
			return _class1070;
		}

		private void method_5()
		{
			_class1070.method_1(this, _class1010);
		}

		public void method_6()
		{
			if (_int3 == -1 && _int4 == -1 && _int2 > 0)
			{
				try
				{
					_class1060.IncrementSomeVariableAndCheckIfTheBackStreamIsFisted(_int2);
				}
				catch (IOException)
				{
					throw new BitstreamException(BitstreamError.StreamError);
				}
			}
		}

		public void method_7()
		{
			_int2 = -1;
			_int3 = -1;
			_int4 = -1;
		}

		public bool method_8(int int7)
		{
			var num = method_16(_byte4, 0, 4);
			var int8 = (_byte4[0] << 24 & -16777216) | (_byte4[1] << 16 & 16711680) | (_byte4[2] << 8 & 65280) | _byte4[3] & 255;
			try
			{
				_class1060.IncrementSomeVariableAndCheckIfTheBackStreamIsFisted(num);
			}
			catch (IOException)
			{
			}
			var result = false;
			var num2 = num;
			if (num2 != 0)
			{
				if (num2 == 4)
				{
					result = method_10(int8, int7, _int5);
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		public int method_9(byte byte5)
		{
			var num = method_16(_byte4, 0, 3);
			if (num != 3)
			{
				throw new BitstreamException(BitstreamError.StreamEof, null);
			}
			var num2 = (_byte4[0] << 16 & 16711680) | (_byte4[1] << 8 & 65280) | _byte4[2] & 255;
			while (true)
			{
				num2 <<= 8;
				if (method_16(_byte4, 3, 1) != 1)
				{
					break;
				}
				num2 |= _byte4[3] & 255;
				if (method_10(num2, byte5, _int5))
				{
					return num2;
				}
			}
			throw new BitstreamException(BitstreamError.StreamEof, null);
		}

		public bool method_10(int int7, int int8, int int9)
		{
			bool flag;
			if (int8 == Byte1)
			{
				flag = ((int7 & 4292870144L) == 4292870144L);
			}
			else
			{
				flag = ((int7 & 4292870144L) == 4292870144L && (int7 & 192) == 192 == _bool0);
			}
			if (flag)
			{
				flag = ((int7 >> 10 & 3) != 3);
			}
			if (flag)
			{
				flag = ((int7 >> 17 & 3) != 0);
			}
			if (flag)
			{
				flag = ((int7 >> 19 & 3) != 1);
			}
			return flag;
		}

		public int method_11(int int7)
		{
			var result = method_15(_byte3, 0, int7);
			_int2 = int7;
			_int3 = -1;
			_int4 = -1;
			return result;
		}

		public void method_12()
		{
			var num = 0;
			var array = _byte3;
			var num2 = _int2;
			for (var i = 0; i < num2; i += 4)
			{
				byte b = 0;
				byte b2 = 0;
				byte b3 = 0;
				var b4 = array[i];
				if (i + 1 < num2)
				{
					b = array[i + 1];
				}
				if (i + 2 < num2)
				{
					b2 = array[i + 2];
				}
				if (i + 3 < num2)
				{
					b3 = array[i + 3];
				}
				_int1[num++] = ((b4 << 24 & -16777216) | (b << 16 & 16711680) | (b2 << 8 & 65280) | b3 & 255);
			}
			_int3 = 0;
			_int4 = 0;
		}

		public int method_13(int int7)
		{
			var num = _int4 + int7;
			if (_int3 < 0)
			{
				_int3 = 0;
			}
			int num4;
			if (num <= 32)
			{
				var num2 = _int1[_int3];
				var num3 = 32 - num;
				num4 = (num2 >> num3 & _int6[int7]);
				if ((_int4 += int7) == 32)
				{
					_int4 = 0;
					_int3++;
				}
				return num4;
			}
			var num5 = _int1[_int3] & 65535;
			_int3++;
			var num6 = _int1[_int3] & -65536;
			num4 = ((num5 << 16 & -65536) | (num6 >> 16 & 65535));
			var num7 = 48 - num;
			num4 >>= num7;
			num4 &= _int6[int7];
			_int4 = num - 32;
			return num4;
		}

		public void method_14(int int7)
		{
			_int5 = (int7 & -193);
			_bool0 = ((int7 & 192) == 192);
		}

		private int method_15(byte[] byte5, int int7, int int8)
		{
			var num = 0;
			try
			{
				while (int8 > 0)
				{
					var num2 = _class1060.method_1(byte5, int7, int8);
					if (num2 == -1 || num2 == 0)
					{
						while (int8-- > 0)
						{
							byte5[int7++] = 0;
						}
						break;
					}
					num += num2;
					int7 += num2;
					int8 -= num2;
				}
			}
			catch (IOException exception)
			{
				throw new BitstreamException(BitstreamError.StreamError, exception);
			}
			return num;
		}

		private int method_16(byte[] byte5, int int7, int int8)
		{
			var num = 0;
			try
			{
				while (int8 > 0)
				{
					var num2 = _class1060.method_1(byte5, int7, int8);
					if (num2 == -1 || num2 == 0)
					{
						break;
					}
					num += num2;
					int7 += num2;
					int8 -= num2;
				}
			}
			catch (IOException exception)
			{
				throw new BitstreamException(BitstreamError.StreamError, exception);
			}
			return num;
		}

		private void method_17(Stream stream0)
		{
			var position = 0L;
			var num = -1;
			try
			{
				position = stream0.Position;
				num = smethod_0(stream0);
				_int0 = num;
			}
			catch (IOException)
			{
			}
			finally
			{
				try
				{
					stream0.Position = position;
				}
				catch (IOException)
				{
				}
			}
			try
			{
				if (num > 0)
				{
					_byte0 = new byte[num];
					stream0.Read(_byte0, 0, _byte0.Length);
				}
			}
			catch (IOException)
			{
			}
		}

		private static int smethod_0(Stream stream0)
		{
			var array = new byte[4];
			var num = -10;
			stream0.Read(array, 0, 3);
			if (array[0] == 73 && array[1] == 68 && array[2] == 51)
			{
				stream0.Read(array, 0, 3);
				stream0.Read(array, 0, 4);
				num = (array[0] << 21) + (array[1] << 14) + (array[2] << 7) + array[3];
			}
			return num + 10;
		}
	}
}
