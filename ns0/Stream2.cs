using ns1;
using SharpAudio.ASC;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ns0
{
	public class Stream2 : Stream1
	{
		private readonly List<Stream1> list_0;

		private readonly Class12 class12_0;

		private readonly long long_0;

		private long long_1;

		private readonly bool bool_0;

		private readonly int int_2;

		private readonly Enum2 enum2_0;

		private readonly bool bool_1;

		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return true;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		public override long Length
		{
			get
			{
				return this.long_0;
			}
		}

		public override long Position
		{
			get
			{
				return this.long_1;
			}
			set
			{
				double num = (double)value / (double)(this.waveFormat_0.int_0 * (int)this.waveFormat_0.short_1);
				for (int i = 0; i < this.list_0.Count; i++)
				{
					long num2 = Convert.ToInt64((double)(this.list_0[i].vmethod_0().int_0 * (int)this.list_0[i].vmethod_0().short_1) * num);
					this.list_0[i].Position = ((this.list_0[i].Length < num2) ? this.list_0[i].Length : num2);
				}
				this.long_1 = value;
			}
		}

		public Stream2(Stream1[] stream1_0) : this(Enum2.flag_26, stream1_0)
		{
		}

		public Stream2(Enum2 enum2_1, Stream1[] stream1_0) : this(enum2_1, 0, false, stream1_0)
		{
		}

		public Stream2(Enum2 enum2_1, ushort ushort_0, bool bool_2, Stream1[] stream1_0) : base()
		{
			this.list_0 = new List<Stream1>();
			this.class12_0 = new Class12(new Interface5[0]);
			//base..ctor();
			this.enum2_0 = enum2_1;
			this.bool_1 = bool_2;
			this.list_0.AddRange(stream1_0);
			this.bool_0 = (stream1_0.Length == 1 && stream1_0[0].vmethod_0().short_0 == 1 && ushort_0 < 2);
			this.long_1 = 0L;
			this.long_0 = stream1_0[0].Length;
			int val = 0;
			int num = 0;
			for (int i = 0; i < stream1_0.Length; i++)
			{
				Stream1 stream = stream1_0[i];
				val = Math.Max(val, stream.vmethod_0().int_0);
				if (this.bool_1)
				{
					num += (int)stream.vmethod_0().short_0;
				}
				else
				{
					num = Math.Max(num, (int)stream.vmethod_0().short_0);
				}
				stream.Position = this.long_1;
			}
			this.waveFormat_0 = new WaveFormat(val, (ushort_0 != 0) ? ((int)ushort_0) : Math.Min(num, Stream2.smethod_0(this.enum2_0) * (this.bool_1 ? stream1_0.Length : 1)));
			for (int j = 0; j < stream1_0.Length; j++)
			{
				Stream1 stream2 = stream1_0[j];
				this.long_0 = Math.Max(this.long_0, Convert.ToInt64((double)(this.waveFormat_0.int_0 * (int)this.waveFormat_0.short_1) * stream2.vmethod_1().timeSpan_0.TotalSeconds));
			}
			this.int_2 = (int)this.waveFormat_0.short_0 << 2;
		}

		public Stream2(Stream1 stream1_0, Interface5[] interface5_0) : this(Enum2.flag_26, stream1_0, interface5_0)
		{
		}

		public Stream2(Enum2 enum2_1, Stream1 stream1_0, Interface5[] interface5_0) : this(enum2_1, 0, stream1_0, interface5_0)
		{
		}

		public Stream2(Enum2 enum2_1, ushort ushort_0, Stream1 stream1_0, Interface5[] interface5_0) : base()
		{
			this.list_0 = new List<Stream1>();
			this.class12_0 = new Class12(new Interface5[0]);
			//base..ctor();
			this.enum2_0 = enum2_1;
			this.bool_1 = false;
			this.waveFormat_0 = new WaveFormat(stream1_0.vmethod_0().int_0, (ushort_0 != 0) ? ((int)ushort_0) : Math.Min((int)stream1_0.vmethod_0().short_0, Stream2.smethod_0(this.enum2_0)));
			this.list_0.Add(stream1_0);
			this.long_1 = 0L;
			stream1_0.Position = 0L;
			this.long_0 = Convert.ToInt64((double)(this.waveFormat_0.int_0 * (int)this.waveFormat_0.short_1) * stream1_0.vmethod_1().timeSpan_0.TotalSeconds);
			this.method_0(interface5_0);
			this.bool_0 = (stream1_0.vmethod_0().short_0 == 1 && ushort_0 < 2);
			this.int_2 = (int)this.waveFormat_0.short_0 << 2;
		}

		public void method_0(Interface5[] interface5_0)
		{
			this.class12_0.AddRange(interface5_0);
		}

		public override int vmethod_3(IntPtr intptr_0, int int_3)
		{
			int_3 >>= 2;
			float[] array = new float[int_3];
			int num = this.vmethod_4(array, 0, int_3);
			Marshal.Copy(array, 0, intptr_0, num);
			return num << 2;
		}

		public override int vmethod_4(float[] float_0, int int_3, int int_4)
		{
			if (this.long_1 >= this.long_0)
			{
				return 0;
			}
			int num = 0;
			int int_5 = (int)(this.long_1 >> 2);
			if (this.bool_0)
			{
				num = this.list_0[0].vmethod_4(float_0, int_3, int_4);
				if (num == 0)
				{
					this.long_1 = this.long_0;
					return 0;
				}
				this.class12_0.imethod_0(new Class13[]
				{
					new Class13(int_5, float_0, int_3, num)
				});
				this.long_1 += (long)((long)num << 2);
				return num;
			}
			else
			{
				float[][] array = this.vmethod_5(int_4 / (int)this.waveFormat_0.short_0);
				if (array == null)
				{
					return 0;
				}
				float[][] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					float[] array3 = array2[i];
					num = Math.Max(array3.Length, num);
				}
				num *= (int)this.waveFormat_0.short_0;
				int num2 = array.Length;
				for (int j = 0; j < num2; j++)
				{
					float[] array4 = array[j];
					int k = 0;
					int num3 = int_3 + j;
					while (k < array4.Length)
					{
						float_0[num3] = array4[k];
						k++;
						num3 += num2;
					}
				}
				return num;
			}
		}

		public override float[][] vmethod_5(int int_3)
		{
			if (this.long_1 >= this.long_0)
			{
				return null;
			}
			int num = (int)(this.long_1 >> 2);
			if (this.bool_0)
			{
				float[][] array = this.list_0[0].vmethod_5(int_3);
				if (array == null)
				{
					this.long_1 = this.long_0;
					return null;
				}
				this.class12_0.imethod_0(new Class13[]
				{
					new Class13(num, array[0])
				});
				this.long_1 += (long)(array[0].Length * this.int_2);
				return array;
			}
			else
			{
				int num2 = 0;
				int num3 = 0;
				List<Class13> list = new List<Class13>();
				List<int> list2 = new List<int>();
				int i = 0;
				while (i < this.list_0.Count)
				{
					float[][] array2;
					if (this.list_0[i].vmethod_0().int_0 < this.waveFormat_0.int_0)
					{
						array2 = this.list_0[i].vmethod_5((int)((double)int_3 * ((double)this.list_0[i].vmethod_0().int_0 / (double)this.waveFormat_0.int_0)));
						if (array2 != null)
						{
							float float_ = (float)this.list_0[i].vmethod_0().int_0 / (float)this.waveFormat_0.int_0;
							for (int j = 0; j < array2.Length; j++)
							{
								if ((this.enum2_0 & (Enum2)(1 << j)) != (Enum2)0)
								{
									Class13 @class = new Class13(num / (int)this.waveFormat_0.short_0, array2[j]);
									Stream2.smethod_1(@class, float_);
									array2[j] = @class.float_0;
								}
							}
							goto IL_19F;
						}
					}
					else
					{
						array2 = this.list_0[i].vmethod_5(int_3);
						if (array2 != null)
						{
							goto IL_19F;
						}
					}
					IL_32F:
					i++;
					continue;
					IL_19F:
					if (!this.bool_1)
					{
						if (array2.Length < (int)this.waveFormat_0.short_0)
						{
							float[][] array3 = new float[(int)this.waveFormat_0.short_0][];
							Array.Copy(array2, array3, array2.Length);
							int k = array2.Length;
							int num4 = 0;
							while (k < array3.Length)
							{
								if ((this.enum2_0 & (Enum2)(1 << k - array2.Length)) != (Enum2)0)
								{
									array3[k] = new float[array2[num4].Length];
									Buffer.BlockCopy(array2[num4], 0, array3[k], 0, array2[num4].Length << 2);
								}
								k++;
								num4 = (num4 + 1) % array2.Length;
							}
							array2 = array3;
						}
						num3 = 0;
					}
					for (int l = 0; l < array2.Length; l++)
					{
						if ((this.enum2_0 & (Enum2)(1 << l)) != (Enum2)0)
						{
							if (num3 >= list.Count)
							{
								list.Add(new Class13(num / (int)this.waveFormat_0.short_0, array2[l]));
								list2.Add(1);
								num2 = Math.Max(num2, array2[l].Length);
							}
							else
							{
								List<int> list3;
								int index;
								(list3 = list2)[index = num3] = list3[index] + 1;
								Class13 class2 = list[num3];
								Class13 class3 = new Class13(num / (int)this.waveFormat_0.short_0, array2[l]);
								if (num2 < array2[l].Length)
								{
									Stream2.smethod_2(class3, class2);
									list[num3] = class3;
									num2 = array2[l].Length;
								}
								else
								{
									Stream2.smethod_2(class2, class3);
								}
							}
							num3 = (num3 + 1) % (int)this.waveFormat_0.short_0;
						}
					}
					goto IL_32F;
				}
				if (list.Count == 0)
				{
					this.long_1 = this.long_0;
					return null;
				}
				int num5 = 0;
				while (num5 < list.Count && list2[num5] > 1)
				{
					Stream2.smethod_3(list[num5], 1f / (float)list2[num5]);
					num5++;
				}
				this.class12_0.imethod_0(list.ToArray());
				float[][] array4 = new float[list.Count][];
				for (int m = 0; m < array4.Length; m++)
				{
					array4[m] = list[m].float_0;
				}
				this.long_1 += (long)(num2 * this.int_2);
				return array4;
			}
		}

		private static int smethod_0(Enum2 enum2_1)
		{
			int num = 0;
			for (int num2 = (int)enum2_1; num2 != 0; num2 &= num2 - 1)
			{
				num++;
			}
			return num;
		}

		private static void smethod_1(Class13 class13_0, float float_0)
		{
			float[] float_ = class13_0.float_0;
			int num = class13_0.method_0();
			int num2 = class13_0.method_2();
			int num3 = (int)((float)num2 / float_0);
			float[] array = new float[float_.Length - num2 + num3];
			Buffer.BlockCopy(float_, 0, array, 0, num << 2);
			double num4 = (double)num;
			int num5 = num;
			while (num5 < num + num3 && (int)num4 + 1 < float_.Length)
			{
				array[num5] = Class15.smethod_2(float_, (float)num4);
				num4 += (double)float_0;
				num5++;
			}
			Buffer.BlockCopy(float_, num + num2 << 2, array, num + num3 << 2, float_.Length - num - num2 << 2);
			class13_0.float_0 = array;
		}

		private static void smethod_2(Class13 class13_0, Class13 class13_1)
		{
			int num = class13_0.method_0();
			int num2 = class13_0.method_2();
			int num3 = class13_1.method_0();
			if (class13_1.bool_0)
			{
				try
				{
					for (int i = 0; i < num2; i++)
					{
						class13_0.vmethod_3(class13_0.vmethod_4(num + i) + class13_1.vmethod_4(num3 + i), num + i);
					}
				}
				catch (IndexOutOfRangeException)
				{
				}
			}
		}

		private static void smethod_3(Class13 class13_0, float float_0)
		{
			float[] float_ = class13_0.float_0;
			int num = class13_0.method_0();
			int num2 = class13_0.method_2();
			try
			{
				for (int i = num; i < num + num2; i++)
				{
					float_[i] = class13_0.vmethod_1(i, float_[i], float_0 * float_[i]);
				}
				Class15.smethod_8(float_, num);
				Class15.smethod_8(float_, num + num2);
			}
			catch (IndexOutOfRangeException)
			{
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			count >>= 2;
			float[] array = new float[count];
			int num = this.vmethod_4(array, 0, count);
			Buffer.BlockCopy(array, 0, buffer, offset, num);
			return num << 2;
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override void Close()
		{
			foreach (Stream1 current in this.list_0)
			{
				current.Close();
			}
			this.class12_0.Clear();
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.class12_0.Clear();
				foreach (Stream1 current in this.list_0)
				{
					current.Dispose();
				}
			}
		}

		public override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		~Stream2()
		{
			this.Dispose(false);
		}
	}
}
