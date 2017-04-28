using System;
using System.IO;
using GHNamespace1;

namespace GHNamespace2
{
	public class Stream3 : GenericAudioStream
	{
		private readonly GenericAudioStream _stream10;

		private readonly long _long0;

		private readonly long _long1;

		private long _long2;

		public override bool CanRead => _stream10.CanRead;

	    public override bool CanSeek => _stream10.CanSeek;

	    public override bool CanWrite => _stream10.CanWrite;

	    public override long Length => _long1;

	    public override long Position
		{
			get => _long2 - _long0;
	        set
			{
				if (value < 0L || value >= _long1)
				{
					throw new IOException("Seeking position out of range.");
				}
				_stream10.Position = (_long2 = _long0 + value);
			}
		}

		private long method_0()
		{
			return Math.Max(_long0 + _long1 - _long2, 0L);
		}

		private Stream3(GenericAudioStream stream11)
		{
			_stream10 = stream11;
			FileStream = stream11;
			WaveFormat0 = stream11.vmethod_0();
		}

		public Stream3(GenericAudioStream stream11, long long3, long long4) : this(stream11)
		{
			if (0L > long3)
			{
				throw new ArgumentException("Start Offset is out of range.");
			}
			if (stream11.Length < long4)
			{
				throw new ArgumentException("End Offset is out of range.");
			}
			if (long3 >= long4)
			{
				throw new ArgumentException("Start/End Offset are out of range.");
			}
			_long1 = long4 - long3;
			Stream arg630 = _stream10;
			_long0 = long3;
			_long2 = long3;
			arg630.Position = long3;
		}

		public Stream3(GenericAudioStream stream11, TimeSpan timeSpan0, TimeSpan timeSpan1) : this(stream11, Convert.ToInt32(stream11.vmethod_0().int_0 * stream11.vmethod_0().short_1 * timeSpan0.TotalSeconds), Convert.ToInt32(stream11.vmethod_0().int_0 * stream11.vmethod_0().short_1 * timeSpan1.TotalSeconds))
		{
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override int vmethod_3(IntPtr intptr0, int int2)
		{
			int result;
			lock (_stream10)
			{
				if (vmethod_2().Position != _long2)
				{
					vmethod_2().Position = _long2;
				}
				int2 = (int)Math.Min(int2, method_0());
				var num = _stream10.vmethod_3(intptr0, int2);
				_long2 += num;
				result = num;
			}
			return result;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int result;
			lock (_stream10)
			{
				if (vmethod_2().Position != _long2)
				{
					vmethod_2().Position = _long2;
				}
				count = (int)Math.Min(count, method_0());
				var num = _stream10.Read(buffer, offset, count);
				_long2 += num;
				result = num;
			}
			return result;
		}

		public override int vmethod_4(float[] float0, int int2, int int3)
		{
			int result;
			lock (_stream10)
			{
				if (vmethod_2().Position != _long2)
				{
					vmethod_2().Position = _long2;
				}
				int3 = (int)Math.Min(int3, method_0() >> 2);
				var num = _stream10.vmethod_4(float0, int2, int3);
				_long2 += (long)num << 2;
				result = num;
			}
			return result;
		}

		public override float[][] vmethod_5(int int2)
		{
			float[][] result;
			lock (_stream10)
			{
				if (vmethod_2().Position != _long2)
				{
					vmethod_2().Position = _long2;
				}
				int2 = (int)Math.Min(int2, (method_0() >> 2) / WaveFormat0.short_0);
				if (int2 == 0)
				{
					result = null;
				}
				else
				{
					var array = _stream10.vmethod_5(int2);
					if (array != null && array.Length >= 1)
					{
						_long2 += (array[0].Length << 2) * array.Length;
						result = array;
					}
					else
					{
						result = null;
					}
				}
			}
			return result;
		}
	}
}
