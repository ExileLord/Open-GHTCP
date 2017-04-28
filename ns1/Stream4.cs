using System;
using System.Runtime.InteropServices;
using GHNamespace1;
using SharpAudio.ASC;

namespace ns1
{
	public class Stream4 : GenericAudioStream
	{
		private delegate byte[] Delegate0(byte[] buffer, int index);

		private delegate int Delegate1(byte[] buffer, int index, int count);

		private readonly GenericAudioStream _stream10;

		private readonly int _int2;

		private readonly int _int3;

		private readonly long _long0;

		private readonly double _double0 = 1.0;

		private readonly bool _bool0;

		private readonly bool _bool1;

		private readonly Delegate0 _delegate00;

		private readonly Delegate1 _delegate10;

		public override bool CanRead => _stream10.CanRead;

	    public override bool CanSeek => _stream10.CanSeek;

	    public override bool CanWrite => _stream10.CanWrite;

	    public override long Length => _long0;

	    public override long Position
		{
			get
			{
				var position = _stream10.Position;
				if (!_bool0)
				{
					return position;
				}
				return (long)(position * _double0);
			}
			set => _stream10.Position = (_bool0 ? ((long)(value / _double0)) : value);
	    }

		public Stream4(GenericAudioStream stream11, int int4)
		{
			_stream10 = stream11;
			FileStream = stream11;
			WaveFormat0 = stream11.vmethod_0();
			_int3 = int4 + 7 >> 3;
			_int2 = WaveFormat0.short_2 + 7 >> 3;
			_bool1 = (WaveFormat0.waveFormatTag_0 == WaveFormatTag.IeeeFloat);
			_bool0 = (WaveFormat0.waveFormatTag_0 != WaveFormatTag.Pcm || _int2 != _int3);
			if (!_bool0)
			{
				_delegate10 = _stream10.Read;
				_long0 = stream11.Length;
				return;
			}
			WaveFormat0 = new WaveFormat(stream11.vmethod_0().int_0, int4, stream11.vmethod_0().short_0);
			_double0 = _int3 / (double)_int2;
			_long0 = (long)(stream11.Length * _double0);
			if (!_bool1)
			{
				switch (_int3)
				{
				case 1:
					switch (_int2)
					{
					case 2:
						_delegate10 = method_2;
						return;
					case 3:
						_delegate10 = method_1;
						return;
					case 4:
						_delegate10 = method_0;
						return;
					default:
						return;
					}
					break;
				case 2:
					switch (_int2)
					{
					case 1:
						_delegate00 = smethod_8;
						break;
					case 3:
						_delegate00 = smethod_7;
						break;
					case 4:
						_delegate00 = smethod_6;
						break;
					}
					break;
				case 3:
					switch (_int2)
					{
					case 1:
						_delegate00 = smethod_5;
						break;
					case 2:
						_delegate00 = smethod_4;
						break;
					case 4:
						_delegate00 = smethod_3;
						break;
					}
					break;
				case 4:
					switch (_int2)
					{
					case 1:
						_delegate00 = smethod_2;
						break;
					case 2:
						_delegate00 = smethod_1;
						break;
					case 3:
						_delegate00 = smethod_0;
						break;
					}
					break;
				}
				_delegate10 = method_3;
				return;
			}
			switch (_int3)
			{
			case 1:
				_delegate10 = method_7;
				return;
			case 2:
				_delegate10 = method_6;
				return;
			case 3:
				_delegate10 = method_5;
				return;
			case 4:
				_delegate10 = method_4;
				return;
			default:
				return;
			}
		}

		private int method_0(byte[] byte0, int int4, int int5)
		{
			var array = new byte[int5 << 2];
			var num = _stream10.Read(array, 0, array.Length);
			var i = 0;
			while (i < num)
			{
				byte0[int4] = Class11.smethod_12(BitConverter.ToInt32(byte0, i));
				i += 4;
				int4++;
			}
			return num >> 2;
		}

		private int method_1(byte[] byte0, int int4, int int5)
		{
			var array = new byte[int5 + int5 + int5];
			var num = _stream10.Read(array, 0, array.Length);
			var i = 0;
			while (i < num)
			{
				byte0[int4] = Class11.smethod_8(Struct8.smethod_2(byte0, i));
				i += 3;
				int4++;
			}
			return num / 3;
		}

		private int method_2(byte[] byte0, int int4, int int5)
		{
			var array = new byte[int5 << 1];
			var num = _stream10.Read(array, 0, array.Length);
			var i = 0;
			while (i < num)
			{
				byte0[int4] = Class11.smethod_4(BitConverter.ToInt16(byte0, i));
				i += 2;
				int4++;
			}
			return num >> 1;
		}

		private static byte[] smethod_0(byte[] byte0, int int4)
		{
			return BitConverter.GetBytes(Class11.smethod_10(Struct8.smethod_2(byte0, int4)));
		}

		private static byte[] smethod_1(byte[] byte0, int int4)
		{
			return BitConverter.GetBytes(Class11.smethod_6(BitConverter.ToInt16(byte0, int4)));
		}

		private static byte[] smethod_2(byte[] byte0, int int4)
		{
			return BitConverter.GetBytes(Class11.smethod_2(byte0[int4]));
		}

		private static byte[] smethod_3(byte[] byte0, int int4)
		{
			return Struct8.smethod_4(Class11.smethod_14(BitConverter.ToInt32(byte0, int4)));
		}

		private static byte[] smethod_4(byte[] byte0, int int4)
		{
			return Struct8.smethod_4(Class11.smethod_5(BitConverter.ToInt16(byte0, int4)));
		}

		private static byte[] smethod_5(byte[] byte0, int int4)
		{
			return Struct8.smethod_4(Class11.smethod_1(byte0[int4]));
		}

		private static byte[] smethod_6(byte[] byte0, int int4)
		{
			return BitConverter.GetBytes(Class11.smethod_13(BitConverter.ToInt32(byte0, int4)));
		}

		private static byte[] smethod_7(byte[] byte0, int int4)
		{
			return BitConverter.GetBytes(Class11.smethod_9(Struct8.smethod_2(byte0, int4)));
		}

		private static byte[] smethod_8(byte[] byte0, int int4)
		{
			return BitConverter.GetBytes(Class11.smethod_0(byte0[int4]));
		}

		private int method_3(byte[] byte0, int int4, int int5)
		{
			var array = new byte[(int)(int5 / _double0)];
			var num = _stream10.Read(array, 0, array.Length);
			var i = 0;
			while (i < num)
			{
				Buffer.BlockCopy(_delegate00(array, i), 0, byte0, int4, _int3);
				i += _int2;
				int4 += _int3;
			}
			return (int)(num * _double0);
		}

		private int method_4(byte[] byte0, int int4, int int5)
		{
			var array = new float[int5 >> 2];
			var num = _stream10.vmethod_4(array, 0, array.Length);
			var i = 0;
			while (i < num)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(Class11.smethod_25(array[i])), 0, byte0, int4, 4);
				i++;
				int4 += 4;
			}
			return num << 2;
		}

		private int method_5(byte[] byte0, int int4, int int5)
		{
			var array = new float[int5 / 3];
			var num = _stream10.vmethod_4(array, 0, array.Length);
			var i = 0;
			while (i < num)
			{
				Buffer.BlockCopy(Struct8.smethod_4(Class11.smethod_23(array[i])), 0, byte0, int4, 3);
				i++;
				int4 += 3;
			}
			return num + num + num;
		}

		private int method_6(byte[] byte0, int int4, int int5)
		{
			var array = new float[int5 >> 1];
			var num = _stream10.vmethod_4(array, 0, array.Length);
			var i = 0;
			while (i < num)
			{
				Buffer.BlockCopy(BitConverter.GetBytes(Class11.smethod_21(array[i])), 0, byte0, int4, 2);
				i++;
				int4 += 2;
			}
			return num << 1;
		}

		private int method_7(byte[] byte0, int int4, int int5)
		{
			var array = new float[int5];
			var num = _stream10.vmethod_4(array, 0, array.Length);
			var i = 0;
			while (i < num)
			{
				byte0[int4] = Class11.smethod_17(array[i]);
				i++;
				int4++;
			}
			return num;
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override int vmethod_3(IntPtr intptr0, int int4)
		{
			var array = new byte[int4];
			var num = Read(array, 0, int4);
			Marshal.Copy(array, 0, intptr0, num);
			return num;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return _delegate10(buffer, offset, count);
		}

		public override int vmethod_4(float[] float0, int int4, int int5)
		{
			return _stream10.vmethod_4(float0, int4, int5);
		}

		public override float[][] vmethod_5(int int4)
		{
			return _stream10.vmethod_5(int4);
		}
	}
}
