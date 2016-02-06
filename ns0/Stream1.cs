using ns1;
using SharpAudio.ASC;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ns0
{
	public abstract class Stream1 : Stream
	{
		public Stream stream_0;

		public WaveFormat waveFormat_0;

		private static int int_0 = 368;

		private static int int_1 = 264;

		public virtual WaveFormat vmethod_0()
		{
			return this.waveFormat_0;
		}

		public virtual Class16 vmethod_1()
		{
			return new Class16(this.waveFormat_0, (uint)this.Position, (uint)this.Length);
		}

		public virtual Stream vmethod_2()
		{
			return this.stream_0;
		}

		public virtual int vmethod_3(IntPtr intptr_0, int int_2)
		{
			byte[] array = new byte[int_2];
			int num = this.Read(array, 0, int_2);
			Marshal.Copy(array, 0, intptr_0, num);
			return num;
		}

		public virtual int vmethod_4(float[] float_0, int int_2, int int_3)
		{
			int num = this.vmethod_0().short_2 + 7 >> 3;
			byte[] array = new byte[num * int_3];
			int num2 = this.Read(array, num * int_2, array.Length) / num;
			int num3 = int_2 + num2;
			short short_ = this.vmethod_0().short_2;
			if (short_ <= 16)
			{
				if (short_ == 8)
				{
					for (int i = 0; i < num3; i++)
					{
						float_0[int_2 + i] = Class11.smethod_3(array[i]);
					}
					return num2;
				}
				if (short_ == 16)
				{
					int num4 = 0;
					while (int_2 < num3)
					{
						float_0[int_2] = Class11.smethod_7(BitConverter.ToInt16(array, num4));
						num4 += num;
						int_2++;
					}
					return num2;
				}
			}
			else
			{
				if (short_ == 24)
				{
					int num5 = 0;
					while (int_2 < num3)
					{
						float_0[int_2] = Class11.smethod_11(Struct8.smethod_2(array, num5));
						num5 += num;
						int_2++;
					}
					return num2;
				}
				if (short_ != 32)
				{
					if (short_ == 64)
					{
						if (this.vmethod_0().waveFormatTag_0 == WaveFormatTag.IEEEFloat)
						{
							int num6 = 0;
							while (int_2 < num3)
							{
								float_0[int_2] = Class11.smethod_26(BitConverter.ToDouble(array, num6));
								num6 += num;
								int_2++;
							}
							return num2;
						}
					}
				}
				else
				{
					if (this.vmethod_0().waveFormatTag_0 == WaveFormatTag.IEEEFloat)
					{
						Buffer.BlockCopy(array, 0, float_0, int_2 << 2, num2);
						return num2;
					}
					int num7 = 0;
					while (int_2 < num3)
					{
						float_0[int_2] = Class11.smethod_15(BitConverter.ToInt32(array, num7));
						num7 += num;
						int_2++;
					}
					return num2;
				}
			}
			throw new ArrayTypeMismatchException();
		}

		public virtual float[][] vmethod_5(int int_2)
		{
			int num = this.vmethod_0().short_2 + 7 >> 3;
			byte[] array = new byte[num * int_2 * (int)this.waveFormat_0.short_0];
			int num2 = this.Read(array, 0, array.Length) / num / (int)this.waveFormat_0.short_0;
			if (num2 <= 0)
			{
				return null;
			}
			int short_ = (int)this.waveFormat_0.short_0;
			int num3 = num * short_;
			float[][] array2 = new float[short_][];
			short short_2 = this.vmethod_0().short_2;
			if (short_2 <= 16)
			{
				if (short_2 == 8)
				{
					for (int i = 0; i < short_; i++)
					{
						float[] array3 = array2[i] = new float[num2];
						int j = 0;
						int num4 = i;
						while (j < array3.Length)
						{
							array3[j] = Class11.smethod_3(array[num4]);
							j++;
							num4 += short_;
						}
					}
					return array2;
				}
				if (short_2 == 16)
				{
					for (int k = 0; k < short_; k++)
					{
						float[] array4 = array2[k] = new float[num2];
						int l = 0;
						int num5 = num * k;
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
				if (short_2 == 24)
				{
					for (int m = 0; m < short_; m++)
					{
						float[] array5 = array2[m] = new float[num2];
						int n = 0;
						int num6 = num * m;
						while (n < array5.Length)
						{
							array5[n] = Class11.smethod_11(Struct8.smethod_2(array, num6));
							n++;
							num6 += num3;
						}
					}
					return array2;
				}
				if (short_2 != 32)
				{
					if (short_2 == 64)
					{
						if (this.vmethod_0().waveFormatTag_0 == WaveFormatTag.IEEEFloat)
						{
							for (int num7 = 0; num7 < short_; num7++)
							{
								float[] array6 = array2[num7] = new float[num2];
								int num8 = 0;
								int num9 = num * num7;
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
					if (this.vmethod_0().waveFormatTag_0 != WaveFormatTag.IEEEFloat)
					{
						for (int num10 = 0; num10 < short_; num10++)
						{
							float[] array7 = array2[num10] = new float[num2];
							int num11 = 0;
							int num12 = num * num10;
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
					for (int num13 = 0; num13 < short_; num13++)
					{
						float[] array8 = array2[num13] = new float[num2];
						int num14 = 0;
						int num15 = num * num13;
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
				this.Position = offset;
				return offset;
			case SeekOrigin.Current:
				return this.Position += offset;
			case SeekOrigin.End:
				return this.Position = this.Length + offset;
			default:
				throw new NotSupportedException();
			}
		}

		public override void Close()
		{
			this.Dispose();
		}

		public override void Flush()
		{
			this.stream_0.Flush();
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.stream_0.Close();
			}
		}

		public new virtual void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
