using System;
using System.IO;
using System.Runtime.InteropServices;
using ns1;
using SharpAudio.ASC;

namespace ns0
{
	public abstract class GenericAudioStream : Stream
	{
		public Stream FileStream;

		public WaveFormat WaveFormat0;

		private static int _int0 = 368;

		private static int _int1 = 264;

		public virtual WaveFormat vmethod_0()
		{
			return WaveFormat0;
		}

		public virtual Class16 vmethod_1()
		{
			return new Class16(WaveFormat0, (uint)Position, (uint)Length);
		}

		public virtual Stream vmethod_2()
		{
			return FileStream;
		}

		public virtual int vmethod_3(IntPtr intptr0, int int2)
		{
			var array = new byte[int2];
			var num = Read(array, 0, int2);
			Marshal.Copy(array, 0, intptr0, num);
			return num;
		}

		public virtual int vmethod_4(float[] float0, int int2, int int3)
		{
			var num = vmethod_0().short_2 + 7 >> 3;
			var array = new byte[num * int3];
			var num2 = Read(array, num * int2, array.Length) / num;
			var num3 = int2 + num2;
			var short_ = vmethod_0().short_2;
			if (short_ <= 16)
			{
				if (short_ == 8)
				{
					for (var i = 0; i < num3; i++)
					{
						float0[int2 + i] = Class11.smethod_3(array[i]);
					}
					return num2;
				}
				if (short_ == 16)
				{
					var num4 = 0;
					while (int2 < num3)
					{
						float0[int2] = Class11.smethod_7(BitConverter.ToInt16(array, num4));
						num4 += num;
						int2++;
					}
					return num2;
				}
			}
			else
			{
				if (short_ == 24)
				{
					var num5 = 0;
					while (int2 < num3)
					{
						float0[int2] = Class11.smethod_11(Struct8.smethod_2(array, num5));
						num5 += num;
						int2++;
					}
					return num2;
				}
				if (short_ != 32)
				{
					if (short_ == 64)
					{
						if (vmethod_0().waveFormatTag_0 == WaveFormatTag.IeeeFloat)
						{
							var num6 = 0;
							while (int2 < num3)
							{
								float0[int2] = Class11.smethod_26(BitConverter.ToDouble(array, num6));
								num6 += num;
								int2++;
							}
							return num2;
						}
					}
				}
				else
				{
					if (vmethod_0().waveFormatTag_0 == WaveFormatTag.IeeeFloat)
					{
						Buffer.BlockCopy(array, 0, float0, int2 << 2, num2);
						return num2;
					}
					var num7 = 0;
					while (int2 < num3)
					{
						float0[int2] = Class11.smethod_15(BitConverter.ToInt32(array, num7));
						num7 += num;
						int2++;
					}
					return num2;
				}
			}
			throw new ArrayTypeMismatchException();
		}

		public virtual float[][] vmethod_5(int int2)
		{
			var num = vmethod_0().short_2 + 7 >> 3;
			var array = new byte[num * int2 * WaveFormat0.short_0];
			var num2 = Read(array, 0, array.Length) / num / WaveFormat0.short_0;
			if (num2 <= 0)
			{
				return null;
			}
			int short_ = WaveFormat0.short_0;
			var num3 = num * short_;
			var array2 = new float[short_][];
			var short2 = vmethod_0().short_2;
			if (short2 <= 16)
			{
				if (short2 == 8)
				{
					for (var i = 0; i < short_; i++)
					{
						var array3 = array2[i] = new float[num2];
						var j = 0;
						var num4 = i;
						while (j < array3.Length)
						{
							array3[j] = Class11.smethod_3(array[num4]);
							j++;
							num4 += short_;
						}
					}
					return array2;
				}
				if (short2 == 16)
				{
					for (var k = 0; k < short_; k++)
					{
						var array4 = array2[k] = new float[num2];
						var l = 0;
						var num5 = num * k;
						while (l < array4.Length)
						{
							array4[l] = Class11.smethod_7(BitConverter.ToInt16(array, num5));
							l++;
							num5 += num3;
						}
					}
					return array2;
				}
			}
			else
			{
				if (short2 == 24)
				{
					for (var m = 0; m < short_; m++)
					{
						var array5 = array2[m] = new float[num2];
						var n = 0;
						var num6 = num * m;
						while (n < array5.Length)
						{
							array5[n] = Class11.smethod_11(Struct8.smethod_2(array, num6));
							n++;
							num6 += num3;
						}
					}
					return array2;
				}
				if (short2 != 32)
				{
					if (short2 == 64)
					{
						if (vmethod_0().waveFormatTag_0 == WaveFormatTag.IeeeFloat)
						{
							for (var num7 = 0; num7 < short_; num7++)
							{
								var array6 = array2[num7] = new float[num2];
								var num8 = 0;
								var num9 = num * num7;
								while (num8 < array6.Length)
								{
									array6[num8] = Class11.smethod_26(BitConverter.ToDouble(array, num9));
									num8++;
									num9 += num3;
								}
							}
							return array2;
						}
					}
				}
				else
				{
					if (vmethod_0().waveFormatTag_0 != WaveFormatTag.IeeeFloat)
					{
						for (var num10 = 0; num10 < short_; num10++)
						{
							var array7 = array2[num10] = new float[num2];
							var num11 = 0;
							var num12 = num * num10;
							while (num11 < array7.Length)
							{
								array7[num11] = Class11.smethod_15(BitConverter.ToInt32(array, num12));
								num11++;
								num12 += num3;
							}
						}
						return array2;
					}
					if (short_ == 1)
					{
						Buffer.BlockCopy(array, 0, array2[0], 0, array.Length);
						return array2;
					}
					for (var num13 = 0; num13 < short_; num13++)
					{
						var array8 = array2[num13] = new float[num2];
						var num14 = 0;
						var num15 = num * num13;
						while (num14 < array8.Length)
						{
							array8[num14] = BitConverter.ToSingle(array, num15);
							num14++;
							num15 += num3;
						}
					}
					return array2;
				}
			}
			throw new ArrayTypeMismatchException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			switch (origin)
			{
			case SeekOrigin.Begin:
				Position = offset;
				return offset;
			case SeekOrigin.Current:
				return Position += offset;
			case SeekOrigin.End:
				return Position = Length + offset;
			default:
				throw new NotSupportedException();
			}
		}

		public override void Close()
		{
			Dispose();
		}

		public override void Flush()
		{
			FileStream.Flush();
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				FileStream.Close();
			}
		}

		public new virtual void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
