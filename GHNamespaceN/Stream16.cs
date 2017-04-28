using System;
using System.IO;
using GHNamespace1;
using GHNamespace2;
using SharpAudio.ASC;
using SharpAudio.ASC.Mp3.Lame;

namespace GHNamespaceN
{
	public class Stream16 : Stream15
	{
		private bool _bool0;

		private readonly BeConfig _beConfig0;

		private readonly uint _uint0;

		private readonly uint _uint1;

		private readonly uint _uint2;

		private readonly byte[] _byte0;

		private int _int2;

		private readonly byte[] _byte1;

		public Stream16(Stream stream1, WaveFormat waveFormat1, BeConfig beConfig1) : base(stream1, waveFormat1)
		{
			try
			{
				_beConfig0 = beConfig1;
				var num = LameEncoder.beInitStream(_beConfig0, ref _uint1, ref _uint2, ref _uint0);
				if (num != 0u)
				{
					throw new ApplicationException(string.Format("Lame_encDll.beInitStream failed with the error code {0}", num));
				}
				_byte0 = new byte[_uint1 * 2u];
				_byte1 = new byte[_uint2];
			}
			catch
			{
				base.Close();
				throw;
			}
		}

		public override int vmethod_0()
		{
			return _byte0.Length;
		}

		public void method_1()
		{
			if (!_bool0)
			{
				try
				{
					var num = 0u;
					if (_int2 > 0 && LameEncoder.smethod_0(_uint0, _byte0, 0, (uint)_int2, _byte1, ref num) == 0u && num > 0u)
					{
						base.Write(_byte1, 0, (int)num);
					}
					num = 0u;
					if (LameEncoder.beDeinitStream(_uint0, _byte1, ref num) == 0u && num > 0u)
					{
						base.Write(_byte1, 0, (int)num);
					}
				}
				finally
				{
					LameEncoder.beCloseStream(_uint0);
				}
			}
			_bool0 = true;
		}

		public override void Close()
		{
			method_1();
			base.Close();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			var num = 0u;
			while (count > 0)
			{
				if (_int2 > 0)
				{
					var num2 = Math.Min(count, _byte0.Length - _int2);
					Buffer.BlockCopy(buffer, offset, _byte0, _int2, num2);
					_int2 += num2;
					offset += num2;
					count -= num2;
					if (_int2 >= _byte0.Length)
					{
						_int2 = 0;
						var num3 = LameEncoder.smethod_1(_uint0, _byte0, _byte1, ref num);
						if (num3 != 0u)
						{
							throw new ApplicationException("Lame_encDll.EncodeChunk failed with the error code " + num3);
						}
						if (num > 0u)
						{
							Stream0.Write(_byte1, 0, (int)num);
						}
					}
				}
				else if (count >= _byte0.Length)
				{
					var num3 = LameEncoder.smethod_0(_uint0, buffer, offset, (uint)_byte0.Length, _byte1, ref num);
					if (num3 != 0u)
					{
						throw new ApplicationException("Lame_encDll.EncodeChunk failed with the error code " + num3);
					}
					if (num > 0u)
					{
						Stream0.Write(_byte1, 0, (int)num);
					}
					count -= _byte0.Length;
					offset += _byte0.Length;
				}
				else
				{
					Buffer.BlockCopy(buffer, offset, _byte0, 0, count);
					_int2 = count;
					offset += count;
					count = 0;
				}
			}
		}

		public static Class16 smethod_0(GenericAudioStream stream10, Stream stream1, int int3, int int4)
		{
			var waveFormat = stream10.vmethod_0();
			if (waveFormat.waveFormatTag_0 != WaveFormatTag.Pcm || waveFormat.short_2 != 16)
			{
				stream10 = new Stream4(stream10, 16);
				waveFormat = stream10.vmethod_0();
			}
			var stream = new Stream16(stream1, waveFormat, (waveFormat.int_0 == int3) ? new BeConfig(waveFormat, (uint)int4) : new BeConfig(waveFormat, (uint)int4, (uint)int3));
			var uint_ = (uint)stream.vmethod_1().Position;
			var array = new byte[stream.method_0() * 2];
			Class16 result;
			try
			{
				int count;
				while ((count = stream10.Read(array, 0, array.Length)) > 0)
				{
					stream.Write(array, 0, count);
				}
				result = new Class16(new WaveFormat(int3, waveFormat.short_0), uint_, (uint)stream.vmethod_1().Length, int4 * 1000);
			}
			finally
			{
				stream.method_1();
			}
			return result;
		}

		public static Class16 smethod_1(Stream stream1, Class16 class160, int int3)
		{
			return smethod_2(stream1, class160.TimeSpan0, class160.method_3(), int3, false);
		}

		public static Class16 smethod_2(Stream stream1, TimeSpan timeSpan0, int int3, int int4, bool bool1)
		{
			var waveFormat = new WaveFormat(int3, 16, bool1 ? 2 : 1);
			var stream = new Stream16(stream1, waveFormat, new BeConfig(waveFormat, (uint)int4));
			var uint_ = (uint)stream.vmethod_1().Position;
			var array = new byte[stream.method_0() * 2];
			Class16 result;
			try
			{
				var num = 0;
				var num2 = (int)(timeSpan0.TotalSeconds * waveFormat.int_1);
				int count;
				while ((count = Math.Min(num2 - num - array.Length, array.Length)) > 0)
				{
					stream.Write(array, 0, count);
					num += array.Length;
				}
				result = new Class16(waveFormat, uint_, (uint)stream.vmethod_1().Length, int4 * 1000);
			}
			finally
			{
				stream.method_1();
			}
			return result;
		}
	}
}
