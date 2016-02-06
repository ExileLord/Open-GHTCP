using Compression.Zip;
using ns12;
using System;
using System.Collections;
using System.IO;

namespace ns13
{
	public class Stream23 : Stream22
	{
		private ArrayList arrayList_0 = new ArrayList();

		private Class192 class192_0 = new Class192();

		private Class193 class193_0;

		private int int_0 = -1;

		private Enum31 enum31_0 = Enum31.const_1;

		private long long_0;

		private long long_1;

		private byte[] byte_1 = new byte[0];

		private bool bool_2;

		private long long_2 = -1L;

		private long long_3 = -1L;

		private Enum30 enum30_0 = Enum30.const_2;

		public Stream23(Stream stream_1) : base(stream_1, new Class194(-1, true))
		{
		}

		public void method_6(int int_1)
		{
			this.class194_0.method_7(int_1);
			this.int_0 = int_1;
		}

		private void method_7(int int_1)
		{
			this.stream_0.WriteByte((byte)(int_1 & 255));
			this.stream_0.WriteByte((byte)(int_1 >> 8 & 255));
		}

		private void method_8(int int_1)
		{
			this.method_7(int_1);
			this.method_7(int_1 >> 16);
		}

		private void method_9(long long_4)
		{
			this.method_8((int)long_4);
			this.method_8((int)(long_4 >> 32));
		}

		public void method_10(Class193 class193_1)
		{
			if (class193_1 == null)
			{
				throw new ArgumentNullException("entry");
			}
			if (this.arrayList_0 == null)
			{
				throw new InvalidOperationException("ZipOutputStream was finished");
			}
			if (this.class193_0 != null)
			{
				this.method_11();
			}
			if (this.arrayList_0.Count == 2147483647)
			{
				throw new ZipException("Too many entries for Zip file");
			}
			Enum31 @enum = class193_1.method_27();
			int int_ = this.int_0;
			class193_1.method_5(class193_1.method_4() & 2048);
			this.bool_2 = false;
			bool flag = true;
			if (@enum == Enum31.const_0)
			{
				class193_1.method_5(class193_1.method_4() & -9);
				if (class193_1.method_23() >= 0L)
				{
					if (class193_1.method_21() < 0L)
					{
						class193_1.method_22(class193_1.method_23());
					}
					else if (class193_1.method_21() != class193_1.method_23())
					{
						throw new ZipException("Method STORED, but compressed size != size");
					}
				}
				else if (class193_1.method_21() >= 0L)
				{
					class193_1.method_24(class193_1.method_21());
				}
				if (class193_1.method_21() < 0L || class193_1.method_25() < 0L)
				{
					if (base.method_0())
					{
						flag = false;
					}
					else
					{
						@enum = Enum31.const_1;
						int_ = 0;
					}
				}
			}
			if (@enum == Enum31.const_1)
			{
				if (class193_1.method_21() == 0L)
				{
					class193_1.method_24(class193_1.method_21());
					class193_1.method_26(0L);
					@enum = Enum31.const_0;
				}
				else if (class193_1.method_23() < 0L || class193_1.method_21() < 0L || class193_1.method_25() < 0L)
				{
					flag = false;
				}
			}
			if (!flag)
			{
				if (!base.method_0())
				{
					class193_1.method_5(class193_1.method_4() | 8);
				}
				else
				{
					this.bool_2 = true;
				}
			}
			if (base.method_1() != null)
			{
				class193_1.method_1(true);
				if (class193_1.method_25() < 0L)
				{
					class193_1.method_5(class193_1.method_4() | 8);
				}
			}
			class193_1.method_7(this.long_1);
			class193_1.method_28(@enum);
			this.enum31_0 = @enum;
			this.long_3 = -1L;
			if (this.enum30_0 == Enum30.const_1 || (class193_1.method_21() < 0L && this.enum30_0 == Enum30.const_2))
			{
				class193_1.method_13();
			}
			this.method_8(67324752);
			this.method_7(class193_1.method_11());
			this.method_7(class193_1.method_4());
			this.method_7((int)((byte)@enum));
			this.method_8((int)class193_1.method_17());
			if (flag)
			{
				this.method_8((int)class193_1.method_25());
				if (class193_1.method_15())
				{
					this.method_8(-1);
					this.method_8(-1);
				}
				else
				{
					this.method_8(class193_1.method_0() ? ((int)class193_1.method_23() + 12) : ((int)class193_1.method_23()));
					this.method_8((int)class193_1.method_21());
				}
			}
			else
			{
				if (this.bool_2)
				{
					this.long_2 = this.stream_0.Position;
				}
				this.method_8(0);
				if (this.bool_2)
				{
					this.long_3 = this.stream_0.Position;
				}
				if (class193_1.method_15() && this.bool_2)
				{
					this.method_8(-1);
					this.method_8(-1);
				}
				else
				{
					this.method_8(0);
					this.method_8(0);
				}
			}
			byte[] array = Class186.smethod_4(class193_1.method_4(), class193_1.method_20());
			if (array.Length > 65535)
			{
				throw new ZipException("Entry name too long.");
			}
			Class202 @class = new Class202(class193_1.method_29());
			if (class193_1.method_15() && (flag || this.bool_2))
			{
				@class.method_8();
				if (flag)
				{
					@class.method_12(class193_1.method_21());
					@class.method_12(class193_1.method_23());
				}
				else
				{
					@class.method_12(-1L);
					@class.method_12(-1L);
				}
				@class.method_9(1);
				if (!@class.method_6(1))
				{
					throw new ZipException("Internal error cant find extra data");
				}
				if (this.bool_2)
				{
					this.long_3 = (long)@class.method_4();
				}
			}
			else
			{
				@class.method_13(1);
			}
			byte[] array2 = @class.method_0();
			this.method_7(array.Length);
			this.method_7(array2.Length);
			if (array.Length > 0)
			{
				this.stream_0.Write(array, 0, array.Length);
			}
			if (class193_1.method_15() && this.bool_2)
			{
				this.long_3 += this.stream_0.Position;
			}
			if (array2.Length > 0)
			{
				this.stream_0.Write(array2, 0, array2.Length);
			}
			this.long_1 += (long)(30 + array.Length + array2.Length);
			this.class193_0 = class193_1;
			this.class192_0.vmethod_1();
			if (@enum == Enum31.const_1)
			{
				this.class194_0.method_0();
				this.class194_0.method_7(int_);
			}
			this.long_0 = 0L;
			if (class193_1.method_0())
			{
				if (class193_1.method_25() < 0L)
				{
					this.method_12(class193_1.method_17() << 16);
					return;
				}
				this.method_12(class193_1.method_25());
			}
		}

		public void method_11()
		{
			if (this.class193_0 == null)
			{
				throw new InvalidOperationException("No open entry");
			}
			if (this.enum31_0 == Enum31.const_1)
			{
				base.vmethod_0();
			}
			long num = (this.enum31_0 == Enum31.const_1) ? this.class194_0.method_1() : this.long_0;
			if (this.class193_0.method_21() < 0L)
			{
				this.class193_0.method_22(this.long_0);
			}
			else if (this.class193_0.method_21() != this.long_0)
			{
				throw new ZipException(string.Concat(new object[]
				{
					"size was ",
					this.long_0,
					", but I expected ",
					this.class193_0.method_21()
				}));
			}
			if (this.class193_0.method_23() < 0L)
			{
				this.class193_0.method_24(num);
			}
			else if (this.class193_0.method_23() != num)
			{
				throw new ZipException(string.Concat(new object[]
				{
					"compressed size was ",
					num,
					", but I expected ",
					this.class193_0.method_23()
				}));
			}
			if (this.class193_0.method_25() < 0L)
			{
				this.class193_0.method_26(this.class192_0.vmethod_0());
			}
			else if (this.class193_0.method_25() != this.class192_0.vmethod_0())
			{
				throw new ZipException(string.Concat(new object[]
				{
					"crc was ",
					this.class192_0.vmethod_0(),
					", but I expected ",
					this.class193_0.method_25()
				}));
			}
			this.long_1 += num;
			if (this.class193_0.method_0())
			{
				Class193 expr_1E6 = this.class193_0;
				expr_1E6.method_24(expr_1E6.method_23() + 12L);
			}
			if (this.bool_2)
			{
				this.bool_2 = false;
				long position = this.stream_0.Position;
				this.stream_0.Seek(this.long_2, SeekOrigin.Begin);
				this.method_8((int)this.class193_0.method_25());
				if (this.class193_0.method_15())
				{
					if (this.long_3 == -1L)
					{
						throw new ZipException("Entry requires zip64 but this has been turned off");
					}
					this.stream_0.Seek(this.long_3, SeekOrigin.Begin);
					this.method_9(this.class193_0.method_21());
					this.method_9(this.class193_0.method_23());
				}
				else
				{
					this.method_8((int)this.class193_0.method_23());
					this.method_8((int)this.class193_0.method_21());
				}
				this.stream_0.Seek(position, SeekOrigin.Begin);
			}
			if ((this.class193_0.method_4() & 8) != 0)
			{
				this.method_8(134695760);
				this.method_8((int)this.class193_0.method_25());
				if (this.class193_0.method_15())
				{
					this.method_9(this.class193_0.method_23());
					this.method_9(this.class193_0.method_21());
					this.long_1 += 24L;
				}
				else
				{
					this.method_8((int)this.class193_0.method_23());
					this.method_8((int)this.class193_0.method_21());
					this.long_1 += 16L;
				}
			}
			this.arrayList_0.Add(this.class193_0);
			this.class193_0 = null;
		}

		private void method_12(long long_4)
		{
			this.long_1 += 12L;
			base.method_4(base.method_1());
			byte[] array = new byte[12];
			Random random = new Random();
			random.NextBytes(array);
			array[11] = (byte)(long_4 >> 24);
			base.method_3(array, 0, array.Length);
			this.stream_0.Write(array, 0, array.Length);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (this.class193_0 == null)
			{
				throw new InvalidOperationException("No open entry.");
			}
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "Cannot be negative");
			}
			if (buffer.Length - offset < count)
			{
				throw new ArgumentException("Invalid offset/count combination");
			}
			this.class192_0.vmethod_3(buffer, offset, count);
			this.long_0 += (long)count;
			Enum31 @enum = this.enum31_0;
			if (@enum != Enum31.const_0)
			{
				if (@enum != Enum31.const_1)
				{
					return;
				}
				base.Write(buffer, offset, count);
				return;
			}
			else
			{
				if (base.method_1() != null)
				{
					this.method_13(buffer, offset, count);
					return;
				}
				this.stream_0.Write(buffer, offset, count);
				return;
			}
		}

		private void method_13(byte[] byte_2, int int_1, int int_2)
		{
			byte[] array = new byte[4096];
			while (int_2 > 0)
			{
				int num = (int_2 < 4096) ? int_2 : 4096;
				Array.Copy(byte_2, int_1, array, 0, num);
				base.method_3(array, 0, num);
				this.stream_0.Write(array, 0, num);
				int_2 -= num;
				int_1 += num;
			}
		}

		public override void vmethod_0()
		{
			if (this.arrayList_0 == null)
			{
				return;
			}
			if (this.class193_0 != null)
			{
				this.method_11();
			}
			long num = (long)this.arrayList_0.Count;
			long num2 = 0L;
			foreach (Class193 @class in this.arrayList_0)
			{
				this.method_8(33639248);
				this.method_7(45);
				this.method_7(@class.method_11());
				this.method_7(@class.method_4());
				this.method_7((int)((short)@class.method_27()));
				this.method_8((int)@class.method_17());
				this.method_8((int)@class.method_25());
				if (!@class.method_14() && @class.method_23() < 4294967295L)
				{
					this.method_8((int)@class.method_23());
				}
				else
				{
					this.method_8(-1);
				}
				if (!@class.method_14() && @class.method_21() < 4294967295L)
				{
					this.method_8((int)@class.method_21());
				}
				else
				{
					this.method_8(-1);
				}
				byte[] array = Class186.smethod_4(@class.method_4(), @class.method_20());
				if (array.Length > 65535)
				{
					throw new ZipException("Name too long.");
				}
				Class202 class2 = new Class202(@class.method_29());
				if (@class.method_16())
				{
					class2.method_8();
					if (@class.method_14() || @class.method_21() >= 4294967295L)
					{
						class2.method_12(@class.method_21());
					}
					if (@class.method_14() || @class.method_23() >= 4294967295L)
					{
						class2.method_12(@class.method_23());
					}
					if (@class.method_6() >= 4294967295L)
					{
						class2.method_12(@class.method_6());
					}
					class2.method_9(1);
				}
				else
				{
					class2.method_13(1);
				}
				byte[] array2 = class2.method_0();
				byte[] array3 = (@class.method_32() != null) ? Class186.smethod_4(@class.method_4(), @class.method_32()) : new byte[0];
				if (array3.Length > 65535)
				{
					throw new ZipException("Comment too long.");
				}
				this.method_7(array.Length);
				this.method_7(array2.Length);
				this.method_7(array3.Length);
				this.method_7(0);
				this.method_7(0);
				if (@class.method_8() != -1)
				{
					this.method_8(@class.method_8());
				}
				else if (@class.method_33())
				{
					this.method_8(16);
				}
				else
				{
					this.method_8(0);
				}
				if (@class.method_6() >= 4294967295L)
				{
					this.method_8(-1);
				}
				else
				{
					this.method_8((int)@class.method_6());
				}
				if (array.Length > 0)
				{
					this.stream_0.Write(array, 0, array.Length);
				}
				if (array2.Length > 0)
				{
					this.stream_0.Write(array2, 0, array2.Length);
				}
				if (array3.Length > 0)
				{
					this.stream_0.Write(array3, 0, array3.Length);
				}
				num2 += (long)(46 + array.Length + array2.Length + array3.Length);
			}
			using (Stream25 stream = new Stream25(this.stream_0))
			{
				stream.method_1(num, num2, this.long_1, this.byte_1);
			}
			this.arrayList_0 = null;
		}
	}
}
