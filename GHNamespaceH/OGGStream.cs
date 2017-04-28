using System;
using System.IO;
using System.Runtime.InteropServices;
using GHNamespace1;
using GHNamespace3;
using GHNamespaceD;
using SharpAudio.ASC;

namespace GHNamespaceH
{
	public class OggStream : GenericAudioStream
	{
		private static readonly int Int2 = 8500;

		private static int _int3;

		private static int _int4 = 1;

		private static readonly int Int5 = 2;

		private static readonly int Int6 = -1;

		private static readonly int Int7 = -2;

		private static int _int8 = -3;

		private static readonly int Int9 = -128;

		private static readonly int Int10 = -129;

		private static int _int11 = -130;

		private static int _int12 = -131;

		private static readonly int Int13 = -132;

		private static int _int14 = -133;

		private static int _int15 = -134;

		private static int _int16 = -135;

		private static int _int17 = -136;

		private static int _int18 = -137;

		private static int _int19 = -138;

		private bool _bool0;

		private long _long0;

		private readonly Class52 _class520 = new Class52();

		private int _int20;

		private long[] _long1;

		private long[] _long2;

		private int[] _int21;

		private long[] _long3;

		private OggClass5[] _oggClass5;

		private Class47[] _class470;

		private long _long4;

		private long _long5;

		private bool _bool1;

		private int _int22;

		private int _int23;

		private double _double0;

		private float _float0;

		private float _float1;

		private readonly Class56 _class560;

		private readonly OggClass1 _oggClass1;

		private readonly OggClass6 _oggClass6;

		public override bool CanRead => FileStream.CanRead;

	    public override bool CanSeek => FileStream.CanSeek;

	    public override bool CanWrite => FileStream.CanWrite;

	    public override long Length => _long5;

	    public override long Position
		{
			get
			{
				return method_19() * WaveFormat0.short_1;
			}
			set
			{
				try
				{
					if (method_18(value / WaveFormat0.short_1) < 0)
					{
						method_17(Convert.ToInt32(value / _double0));
					}
				}
				catch
				{
				}
			}
		}

		private OggStream()
		{
			_class560 = new Class56();
			_oggClass1 = new OggClass1();
			_oggClass6 = new OggClass6(_oggClass1);
		}

		public OggStream(string fileName) : this()
		{
			FileStream fileData = null;
			try
			{
                fileData = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            }
			catch (Exception ex)
			{
				throw new Exception0("OggStream: " + ex.Message);
			}
            var num = method_9(fileData, null, 0);
            if (num == -1)
			{
				throw new Exception0("OggStream: open return -1");
			}
		}

		public OggStream(Stream stream1) : this(stream1, null, 0)
		{
		}

		public OggStream(Stream stream1, byte[] byte0, int int24) : this()
		{
			var num = method_9(stream1, byte0, int24);
			if (num == -1)
			{
				throw new Exception0("OggStream: open return -1");
			}
		}

		private int method_0(Class48 class480, long long6)
		{
			if (long6 > 0L)
			{
				long6 += _long0;
			}
			while (long6 <= 0L || _long0 < long6)
			{
				var num = _class520.method_3(class480);
				if (num < 0)
				{
					_long0 -= num;
				}
				else
				{
					if (num != 0)
					{
						var result = (int)_long0;
						_long0 += num;
						return result;
					}
					if (long6 == 0L)
					{
						return Int6;
					}
					var num2 = method_7();
					if (num2 == 0)
					{
						return Int7;
					}
					if (num2 < 0)
					{
						return Int9;
					}
				}
			}
			return Int6;
		}

		private int method_1(Class48 class480)
		{
			var num = _long0;
			var num2 = -1;
			int num3;
			while (num2 == -1)
			{
				num -= Int2;
				if (num < 0L)
				{
					num = 0L;
				}
				method_8(num);
				while (_long0 < num + Int2)
				{
					num3 = method_0(class480, num + Int2 - _long0);
					if (num3 == Int9)
					{
						return Int9;
					}
					if (num3 < 0)
					{
						break;
					}
					num2 = num3;
				}
			}
			method_8(num2);
			num3 = method_0(class480, Int2);
			if (num3 < 0)
			{
				return Int10;
			}
			return num2;
		}

		private int method_2(OggClass5 oggClass5, Class47 class471, int[] int24, Class48 class480)
		{
			var @class = new Class48();
			var class67 = new Class67();
			if (class480 == null)
			{
				var num = method_0(@class, Int2);
				if (num == Int9)
				{
					return Int9;
				}
				if (num < 0)
				{
					return Int13;
				}
				class480 = @class;
			}
			if (int24 != null)
			{
				int24[0] = class480.method_5();
			}
			_class560.method_1(class480.method_5());
			oggClass5.method_0();
			class471.method_0();
			var i = 0;
			while (i < 3)
			{
				_class560.method_6(class480);
				while (i < 3)
				{
					var num2 = _class560.method_5(class67);
					if (num2 == 0)
					{
						break;
					}
					if (num2 == -1)
					{
						Console.Error.WriteLine("Corrupt header in logical bitstream.");
						oggClass5.method_1();
						class471.method_2();
						_class560.method_2();
						return -1;
					}
					if (oggClass5.method_4(class471, class67) != 0)
					{
						Console.Error.WriteLine("Illegal header in logical bitstream.");
						oggClass5.method_1();
						class471.method_2();
						_class560.method_2();
						return -1;
					}
					i++;
				}
				if (i < 3 && method_0(class480, 1L) < 0)
				{
					Console.Error.WriteLine("Missing header in logical bitstream.");
					oggClass5.method_1();
					class471.method_2();
					_class560.method_2();
					return -1;
				}
			}
			return 0;
		}

		private void method_3(OggClass5 class491, Class47 class471, int int24)
		{
			var @class = new Class48();
            _oggClass5 = new OggClass5[_int20];
			_class470 = new Class47[_int20];
			_long2 = new long[_int20];
			_long3 = new long[_int20];
			_int21 = new int[_int20];
			var i = 0;
			while (i < _int20)
			{
                if (class491 != null && class471 != null && i == 0)
				{
					_oggClass5[i] = class491;
					_class470[i] = class471;
					_long2[i] = int24;
				}
				else
				{
					method_8(_long1[i]);
					if (method_2(_oggClass5[i], _class470[i], null, null) == -1)
					{
						Console.Error.WriteLine("Error opening logical bitstream #" + (i + 1) + "\n");
						_long2[i] = -1L;
					}
					else
					{
						_long2[i] = _long0;
						_class560.method_2();
					}
				}
                var long_ = _long1[i + 1];
				method_8(long_);
				long num2;
                while (true)
				{
                    var num = method_1(@class);
                    if (num == -1)
					{
						goto Block_6;
					}
                    num2 = @class.method_4();
                    if (num2 != -1L)
					{
						goto Block_5;
					}
                }
            IL_189:
				i++;
                continue;
				Block_5:
                _int21[i] = @class.method_5();
                _long3[i] = num2;
				goto IL_189;
				Block_6:
				Console.Error.WriteLine("Could not find last page of logical bitstream #" + i + "\n");
                _oggClass5[i].method_1();
				_class470[i].method_2();
				goto IL_189;
			}
		}

		private int method_4()
		{
			if (_bool1)
			{
				return 1;
			}
            _oggClass1.method_1(_oggClass5[0]);
            _oggClass6.method_0(_oggClass1);
            _bool1 = true;
			return 0;
		}

		private void method_5()
		{
			_class560.method_2();
			_oggClass1.method_7();
			_oggClass6.method_1();
			_bool1 = false;
			_float0 = 0f;
			_float1 = 0f;
		}

		private int method_6(int int24)
		{
            var @class = new Class48();
			Class67 class2;
			long num2;
			while (true)
			{
                if (_bool1)
				{
                    class2 = new Class67();
					var num = _class560.method_5(class2);
					if (num > 0)
					{
						num2 = class2.Long0;
						if (_oggClass6.method_2(class2) == 0)
						{
							goto Block_11;
						}
					}
				}
                if (int24 == 0)
				{
					return 0;
				}
				if (method_0(@class, -1L) < 0)
				{
					return 0;
				}
                _float0 += @class.Int1 << 3;
				if (_bool1 && _int22 != @class.method_5())
				{
                    method_5();
				}
                if (!_bool1)
				{
                    if (_bool0)
					{
                        _int22 = @class.method_5();
						var num3 = 0;
						while (num3 < _int20 && _int21[num3] != _int22)
						{
							num3++;
						}
						if (num3 == _int20)
						{
							break;
						}
						_int23 = num3;
						_class560.method_1(_int22);
						_class560.method_7();
                    }
					else
					{
                        var array = new int[1];
						var num4 = method_2(_oggClass5[0], _class470[0], array, @class);
						_int22 = array[0];
						if (num4 != 0)
						{
							return num4;
						}
						_int23++;
                    }
                    method_4();
                }
                _class560.method_6(@class);
            }
			return -1;
			Block_11:
            var num5 = _oggClass1.method_3();
			_oggClass1.method_2(_oggClass6);
			_float1 += _oggClass1.method_3() - num5;
			_float0 += class2.Int1 * 8;
            if (num2 != -1L && class2.Int3 == 0)
			{
				var num6 = _bool0 ? _int23 : 0;
				var num7 = _oggClass1.method_3();
				num2 -= num7;
				for (var i = 0; i < num6; i++)
				{
					num2 += _long3[i];
				}
				_long4 = num2;
			}
			return 1;
		}

		private static int smethod_0(Stream stream1, long long6, int int24)
		{
			if (stream1.CanSeek)
			{
				try
				{
					if (int24 == _int3)
					{
						stream1.Seek(long6, SeekOrigin.Begin);
					}
					else if (int24 == Int5)
					{
						stream1.Seek(stream1.Length - long6, SeekOrigin.Begin);
					}
					else
					{
						Console.Error.WriteLine("seek: " + int24 + " is not supported");
					}
				}
				catch (Exception ex)
				{
					Console.Error.WriteLine(ex.Message);
				}
				return 0;
			}
			int result;
			try
			{
				if (int24 == 0)
				{
					stream1.Seek(0L, SeekOrigin.Begin);
				}
				stream1.Seek(long6, SeekOrigin.Begin);
				return 0;
			}
			catch (Exception ex2)
			{
				Console.Error.WriteLine(ex2.Message);
				result = -1;
			}
			return result;
		}

		private static long smethod_1(Stream stream1)
		{
			try
			{
				if (stream1.CanSeek)
				{
					return stream1.Position;
				}
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
			return 0L;
		}

		private int method_7()
		{
			var offset = _class520.method_1(Int2);
			var byte_ = _class520.Byte0;
			var num = 0;
			int result;
			try
			{
				num = FileStream.Read(byte_, offset, Int2);
				goto IL_51;
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.Message);
				result = Int9;
			}
			return result;
			IL_51:
			_class520.method_2(num);
			if (num == -1)
			{
				num = 0;
			}
			return num;
		}

		private void method_8(long long6)
		{
			smethod_0(FileStream, long6, _int3);
			_long0 = long6;
			_class520.method_4();
		}

		private int method_9(Stream fileStream, byte[] nullArray, int zero)
		{
			return method_10(fileStream, nullArray, zero);
		}

		private int method_10(Stream fileStream, byte[] nullArray, int zero)
		{
            FileStream = fileStream;
            _class520.method_5();
            if (nullArray != null)
			{
                var dstOffset = _class520.method_1(zero);
                Buffer.BlockCopy(nullArray, 0, _class520.Byte0, dstOffset, zero);
				_class520.method_2(zero);
			}
            int num;
            if (fileStream.CanSeek)
            {
                num = method_11();
            }
            else
            {
                num = method_12();
            }
            //int num = stream_1.CanSeek ? this.method_11() : this.method_12();
            var @class = method_21(-1);
            WaveFormat0 = new WaveFormat(@class.Int9, @class.Int8);
			_double0 = WaveFormat0.int_0 * WaveFormat0.short_1 / (method_20(-1) / 8.0);
            _long5 = method_15(-1) * WaveFormat0.short_1;
            if (_long5 <= 0L)
			{
				_long5 = Convert.ToInt64(method_14(-1) * _double0);
			}
            if (num != 0)
			{
				FileStream = null;
				method_22();
			}
            return num;
		}

		private int method_11()
		{
			var oggClass5 = new OggClass5();
			var class47 = new Class47();
			var @class = new Class48();
			var array = new int[1];
            var num = method_2(oggClass5, class47, array, null);
            var num2 = array[0];
			var int_ = (int)_long0;
			_class560.method_2();
            if (num == -1)
			{
				return -1;
			}
			_bool0 = true;
            smethod_0(FileStream, 0L, Int5);
            _long0 = smethod_1(FileStream);
			var num3 = _long0;
            num3 = method_1(@class);
            if (@class.method_5() != num2)
			{
				if (method_13(0L, 0L, num3 + 1L, num2, 0) < 0)
				{
					method_22();
					return Int9;
				}
			}
			else if (method_13(0L, num3, num3 + 1L, num2, 0) < 0)
			{
				method_22();
				return Int9;
			}
            method_3(oggClass5, class47, int_);
            return method_17(0);
		}

		private int method_12()
		{
			_int20 = 1;
			_oggClass5 = new OggClass5[_int20];
			_oggClass5[0] = new OggClass5();
			_class470 = new Class47[_int20];
			_class470[0] = new Class47();
			var array = new int[1];
			if (method_2(_oggClass5[0], _class470[0], array, null) == -1)
			{
				return -1;
			}
			_int22 = array[0];
			method_4();
			return 0;
		}

		private int method_13(long long6, long long7, long long8, int int24, int int25)
		{
			var num = long8;
			var long9 = long8;
			var @class = new Class48();
			int num3;
			while (long7 < num)
			{
				long num2;
				if (num - long7 < Int2)
				{
					num2 = long7;
				}
				else
				{
					num2 = (long7 + num) / 2L;
				}
				method_8(num2);
				num3 = method_0(@class, -1L);
				if (num3 == Int9)
				{
					return Int9;
				}
				if (num3 >= 0)
				{
					if (@class.method_5() == int24)
					{
						long7 = num3 + @class.Int1 + @class.Int3;
						continue;
					}
				}
				num = num2;
				if (num3 >= 0)
				{
					long9 = num3;
				}
			}
			method_8(long9);
			num3 = method_0(@class, -1L);
			if (num3 == Int9)
			{
				return Int9;
			}
			if (long7 < long8)
			{
				if (num3 != -1)
				{
					num3 = method_13(long9, _long0, long8, @class.method_5(), int25 + 1);
					if (num3 == Int9)
					{
						return Int9;
					}
					goto IL_FF;
				}
			}
			_int20 = int25 + 1;
			_long1 = new long[int25 + 2];
			_long1[int25 + 1] = long7;
			IL_FF:
			_long1[int25] = long6;
			return 0;
		}

		public long method_14(int int24)
		{
			if (!_bool0 || int24 >= _int20)
			{
				return -1L;
			}
			if (int24 < 0)
			{
				var num = 0L;
				for (var i = 0; i < _int20; i++)
				{
					num += method_14(i);
				}
				return num;
			}
			return _long1[int24 + 1] - _long1[int24];
		}

		public long method_15(int int24)
		{
			if (!_bool0 || int24 >= _int20)
			{
				return -1L;
			}
			if (int24 < 0)
			{
				var num = 0L;
				for (var i = 0; i < _int20; i++)
				{
					num += method_15(i);
				}
				return num;
			}
			return _long3[int24];
		}

		public float method_16(int int24)
		{
			if (!_bool0 || int24 >= _int20)
			{
				return -1f;
			}
			if (int24 < 0)
			{
				var num = 0f;
				for (var i = 0; i < _int20; i++)
				{
					num += method_16(i);
				}
				return num;
			}
			return _long3[int24] / (float)_oggClass5[int24].Int9;
		}

		public int method_17(int int24)
		{
            if (!_bool0)
			{
				return -1;
			}
			if (int24 < 0 || int24 > _long1[_int20])
			{
				_long4 = -1L;
				method_5();
				return -1;
			}
			_long4 = -1L;
			method_5();
			method_8(int24);
            switch (method_6(1))
			{
			case -1:
				_long4 = -1L;
				method_5();
				return -1;
			case 0:
				_long4 = method_15(-1);
				return 0;
			default:
				while (true)
				{
					switch (method_6(0))
					{
					case -1:
						goto IL_77;
					case 0:
						return 0;
					}
				}

				IL_77:
				_long4 = -1L;
				method_5();
				return -1;
			}
		}

		public int method_18(long long6)
		{
			var num = method_15(-1);
			if (!_bool0)
			{
				return -1;
			}
			if (long6 < 0L || long6 > num)
			{
				_long4 = -1L;
				method_5();
				return -1;
			}
			int i;
			for (i = _int20 - 1; i >= 0; i--)
			{
				num -= _long3[i];
				if (long6 >= num)
				{
					break;
				}
			}
			var num2 = long6 - num;
			var num3 = _long1[i + 1];
			var num4 = _long1[i];
			var int_ = (int)num4;
			var @class = new Class48();
			while (num4 < num3)
			{
				long num5;
				if (num3 - num4 < Int2)
				{
					num5 = num4;
				}
				else
				{
					num5 = (num3 + num4) / 2L;
				}
				method_8(num5);
				var num6 = method_0(@class, num3 - num5);
				if (num6 == -1)
				{
					num3 = num5;
				}
				else
				{
					var num7 = @class.method_4();
					if (num7 < num2)
					{
						int_ = num6;
						num4 = _long0;
					}
					else
					{
						num3 = num5;
					}
				}
			}
			if (method_17(int_) != 0)
			{
				_long4 = -1L;
				method_5();
				return -1;
			}
			if (_long4 >= long6)
			{
				_long4 = -1L;
				method_5();
				return -1;
			}
			if (long6 > method_15(-1))
			{
				_long4 = -1L;
				method_5();
				return -1;
			}
			while (_long4 < long6)
			{
				var num8 = (int)(long6 - _long4);
				var num9 = _oggClass1.method_3();
				if (num9 > num8)
				{
					num9 = num8;
				}
				_oggClass1.method_6(num9);
				_long4 += num9;
				if (num9 < num8 && method_6(1) == 0)
				{
					_long4 = method_15(-1);
				}
			}
			return 0;
		}

		public long method_19()
		{
			if (_long4 >= 0L)
			{
				return _long4;
			}
			return 0L;
		}

		public int method_20(int int24)
		{
			if (int24 >= _int20)
			{
				return -1;
			}
			if (!_bool0 && int24 != 0)
			{
				return method_20(0);
			}
			if (int24 < 0)
			{
				var num = 0L;
				for (var i = 0; i < _int20; i++)
				{
					num += (_long1[i + 1] - _long2[i]) * 8L;
				}
				return (int)Math.Round(num / method_16(-1));
			}
			if (_bool0)
			{
				return (int)Math.Round((_long1[int24 + 1] - _long2[int24]) * 8L / method_16(int24));
			}
			if (_oggClass5[int24].Int11 > 0)
			{
				return _oggClass5[int24].Int11;
			}
			if (_oggClass5[int24].Int10 <= 0)
			{
				return -1;
			}
			if (_oggClass5[int24].Int12 > 0)
			{
				return (_oggClass5[int24].Int10 + _oggClass5[int24].Int12) / 2;
			}
			return _oggClass5[int24].Int10;
		}

		public OggClass5 method_21(int int24)
		{
			if (_bool0)
			{
				if (int24 < 0)
				{
					if (!_bool1)
					{
						return null;
					}
					return _oggClass5[_int23];
				}
			    if (int24 >= _int20)
			    {
			        return null;
			    }
			    return _oggClass5[int24];
			}
		    if (!_bool1)
		    {
		        return null;
		    }
		    return _oggClass5[0];
		}

		private int method_22()
		{
			_oggClass6.method_1();
			_oggClass1.method_7();
			_class560.method_2();
			if (_oggClass5 != null && _int20 != 0)
			{
				for (var i = 0; i < _int20; i++)
				{
					_oggClass5[i].method_1();
					_class470[i].method_2();
				}
				_oggClass5 = null;
				_class470 = null;
			}
			if (_long2 != null)
			{
				_long2 = null;
			}
			if (_long3 != null)
			{
				_long3 = null;
			}
			if (_int21 != null)
			{
				_int21 = null;
			}
			if (_long1 != null)
			{
				_long1 = null;
			}
			_class520.method_0();
			return 0;
		}

		public override void Flush()
		{
			FileStream.Flush();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override void Close()
		{
			method_22();
			FileStream.Close();
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Close();
			}
		}

		public override void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public override int vmethod_3(IntPtr intptr0, int int24)
		{
			int24 >>= 2;
			var source = new float[int24];
			var num = vmethod_4(source, 0, int24);
			if (num == 0)
			{
				return 0;
			}
			Marshal.Copy(source, 0, intptr0, num);
			return num << 2;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			var array = new float[count >> 2];
			var num = vmethod_4(array, 0, array.Length) << 2;
			Buffer.BlockCopy(array, 0, buffer, offset, num);
			return num;
		}

		public override int vmethod_4(float[] float2, int int24, int int25)
		{
			var num = int24;
			var num2 = int24 + int25;
			int short_ = WaveFormat0.short_0;
			do
			{
				if (_bool1)
				{
					var num3 = _oggClass1.method_4(float2, num, num2);
					if (num3 != 0)
					{
						_oggClass1.method_6(num3);
						_long4 += num3;
						num += num3 * short_;
						if (num >= num2)
						{
							break;
						}
					}
				}
			}
			while (method_6(1) >= 1);
			return num - int24;
		}

		public override float[][] vmethod_5(int int24)
		{
			var array = new float[WaveFormat0.short_0][];
			for (var i = 0; i < array.Length; i++)
			{
				array[i] = new float[int24];
			}
			var num = 0;
			do
			{
				if (_bool1)
				{
					var num2 = _oggClass1.method_5(array, num, int24);
					if (num2 != 0)
					{
						num += num2;
						_long4 += num2;
						_oggClass1.method_6(num2);
						if (num >= int24)
						{
							break;
						}
					}
				}
			}
			while (method_6(1) >= 1);
			if (num == 0)
			{
				return null;
			}
			if (num < int24)
			{
				for (var j = 0; j < array.Length; j++)
				{
					Array.Resize(ref array[j], num);
				}
			}
			return array;
		}
	}
}
