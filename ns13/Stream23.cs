using System;
using System.Collections;
using System.IO;
using Compression.Zip;
using ns12;

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
			class194_0.method_7(int_1);
			int_0 = int_1;
		}

		private void method_7(int int_1)
		{
			stream_0.WriteByte((byte)(int_1 & 255));
			stream_0.WriteByte((byte)(int_1 >> 8 & 255));
		}

		private void method_8(int int_1)
		{
			method_7(int_1);
			method_7(int_1 >> 16);
		}

		private void method_9(long long_4)
		{
			method_8((int)long_4);
			method_8((int)(long_4 >> 32));
		}

		public void method_10(Class193 class193_1)
		{
			if (class193_1 == null)
			{
				throw new ArgumentNullException("entry");
			}
			if (arrayList_0 == null)
			{
				throw new InvalidOperationException("ZipOutputStream was finished");
			}
			if (class193_0 != null)
			{
				method_11();
			}
			if (arrayList_0.Count == 2147483647)
			{
				throw new ZipException("Too many entries for Zip file");
			}
			Enum31 @enum = class193_1.method_27();
			int int_ = int_0;
			class193_1.method_5(class193_1.method_4() & 2048);
			bool_2 = false;
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
					if (method_0())
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
				if (!method_0())
				{
					class193_1.method_5(class193_1.method_4() | 8);
				}
				else
				{
					bool_2 = true;
				}
			}
			if (method_1() != null)
			{
				class193_1.method_1(true);
				if (class193_1.method_25() < 0L)
				{
					class193_1.method_5(class193_1.method_4() | 8);
				}
			}
			class193_1.method_7(long_1);
			class193_1.method_28(@enum);
			enum31_0 = @enum;
			long_3 = -1L;
			if (enum30_0 == Enum30.const_1 || (class193_1.method_21() < 0L && enum30_0 == Enum30.const_2))
			{
				class193_1.method_13();
			}
			method_8(67324752);
			method_7(class193_1.method_11());
			method_7(class193_1.method_4());
			method_7((byte)@enum);
			method_8((int)class193_1.method_17());
			if (flag)
			{
				method_8((int)class193_1.method_25());
				if (class193_1.method_15())
				{
					method_8(-1);
					method_8(-1);
				}
				else
				{
					method_8(class193_1.method_0() ? ((int)class193_1.method_23() + 12) : ((int)class193_1.method_23()));
					method_8((int)class193_1.method_21());
				}
			}
			else
			{
				if (bool_2)
				{
					long_2 = stream_0.Position;
				}
				method_8(0);
				if (bool_2)
				{
					long_3 = stream_0.Position;
				}
				if (class193_1.method_15() && bool_2)
				{
					method_8(-1);
					method_8(-1);
				}
				else
				{
					method_8(0);
					method_8(0);
				}
			}
			byte[] array = Class186.smethod_4(class193_1.method_4(), class193_1.method_20());
			if (array.Length > 65535)
			{
				throw new ZipException("Entry name too long.");
			}
			Class202 @class = new Class202(class193_1.method_29());
			if (class193_1.method_15() && (flag || bool_2))
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
				if (bool_2)
				{
					long_3 = @class.method_4();
				}
			}
			else
			{
				@class.method_13(1);
			}
			byte[] array2 = @class.method_0();
			method_7(array.Length);
			method_7(array2.Length);
			if (array.Length > 0)
			{
				stream_0.Write(array, 0, array.Length);
			}
			if (class193_1.method_15() && bool_2)
			{
				long_3 += stream_0.Position;
			}
			if (array2.Length > 0)
			{
				stream_0.Write(array2, 0, array2.Length);
			}
			long_1 += 30 + array.Length + array2.Length;
			class193_0 = class193_1;
			class192_0.vmethod_1();
			if (@enum == Enum31.const_1)
			{
				class194_0.method_0();
				class194_0.method_7(int_);
			}
			long_0 = 0L;
			if (class193_1.method_0())
			{
				if (class193_1.method_25() < 0L)
				{
					method_12(class193_1.method_17() << 16);
					return;
				}
				method_12(class193_1.method_25());
			}
		}

		public void method_11()
		{
			if (class193_0 == null)
			{
				throw new InvalidOperationException("No open entry");
			}
			if (enum31_0 == Enum31.const_1)
			{
				base.vmethod_0();
			}
			long num = (enum31_0 == Enum31.const_1) ? class194_0.method_1() : long_0;
			if (class193_0.method_21() < 0L)
			{
				class193_0.method_22(long_0);
			}
			else if (class193_0.method_21() != long_0)
			{
				throw new ZipException(string.Concat("size was ", long_0, ", but I expected ", class193_0.method_21()));
			}
			if (class193_0.method_23() < 0L)
			{
				class193_0.method_24(num);
			}
			else if (class193_0.method_23() != num)
			{
				throw new ZipException(string.Concat("compressed size was ", num, ", but I expected ", class193_0.method_23()));
			}
			if (class193_0.method_25() < 0L)
			{
				class193_0.method_26(class192_0.vmethod_0());
			}
			else if (class193_0.method_25() != class192_0.vmethod_0())
			{
				throw new ZipException(string.Concat("crc was ", class192_0.vmethod_0(), ", but I expected ", class193_0.method_25()));
			}
			long_1 += num;
			if (class193_0.method_0())
			{
				Class193 expr_1E6 = class193_0;
				expr_1E6.method_24(expr_1E6.method_23() + 12L);
			}
			if (bool_2)
			{
				bool_2 = false;
				long position = stream_0.Position;
				stream_0.Seek(long_2, SeekOrigin.Begin);
				method_8((int)class193_0.method_25());
				if (class193_0.method_15())
				{
					if (long_3 == -1L)
					{
						throw new ZipException("Entry requires zip64 but this has been turned off");
					}
					stream_0.Seek(long_3, SeekOrigin.Begin);
					method_9(class193_0.method_21());
					method_9(class193_0.method_23());
				}
				else
				{
					method_8((int)class193_0.method_23());
					method_8((int)class193_0.method_21());
				}
				stream_0.Seek(position, SeekOrigin.Begin);
			}
			if ((class193_0.method_4() & 8) != 0)
			{
				method_8(134695760);
				method_8((int)class193_0.method_25());
				if (class193_0.method_15())
				{
					method_9(class193_0.method_23());
					method_9(class193_0.method_21());
					long_1 += 24L;
				}
				else
				{
					method_8((int)class193_0.method_23());
					method_8((int)class193_0.method_21());
					long_1 += 16L;
				}
			}
			arrayList_0.Add(class193_0);
			class193_0 = null;
		}

		private void method_12(long long_4)
		{
			long_1 += 12L;
			method_4(method_1());
			byte[] array = new byte[12];
			Random random = new Random();
			random.NextBytes(array);
			array[11] = (byte)(long_4 >> 24);
			method_3(array, 0, array.Length);
			stream_0.Write(array, 0, array.Length);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (class193_0 == null)
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
			class192_0.vmethod_3(buffer, offset, count);
			long_0 += count;
			Enum31 @enum = enum31_0;
			if (@enum != Enum31.const_0)
			{
				if (@enum != Enum31.const_1)
				{
					return;
				}
				base.Write(buffer, offset, count);
			}
			else
			{
				if (method_1() != null)
				{
					method_13(buffer, offset, count);
					return;
				}
				stream_0.Write(buffer, offset, count);
			}
		}

		private void method_13(byte[] byte_2, int int_1, int int_2)
		{
			byte[] array = new byte[4096];
			while (int_2 > 0)
			{
				int num = (int_2 < 4096) ? int_2 : 4096;
				Array.Copy(byte_2, int_1, array, 0, num);
				method_3(array, 0, num);
				stream_0.Write(array, 0, num);
				int_2 -= num;
				int_1 += num;
			}
		}

		public override void vmethod_0()
		{
			if (arrayList_0 == null)
			{
				return;
			}
			if (class193_0 != null)
			{
				method_11();
			}
			long num = arrayList_0.Count;
			long num2 = 0L;
			foreach (Class193 @class in arrayList_0)
			{
				method_8(33639248);
				method_7(45);
				method_7(@class.method_11());
				method_7(@class.method_4());
				method_7((short)@class.method_27());
				method_8((int)@class.method_17());
				method_8((int)@class.method_25());
				if (!@class.method_14() && @class.method_23() < 4294967295L)
				{
					method_8((int)@class.method_23());
				}
				else
				{
					method_8(-1);
				}
				if (!@class.method_14() && @class.method_21() < 4294967295L)
				{
					method_8((int)@class.method_21());
				}
				else
				{
					method_8(-1);
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
				method_7(array.Length);
				method_7(array2.Length);
				method_7(array3.Length);
				method_7(0);
				method_7(0);
				if (@class.method_8() != -1)
				{
					method_8(@class.method_8());
				}
				else if (@class.method_33())
				{
					method_8(16);
				}
				else
				{
					method_8(0);
				}
				if (@class.method_6() >= 4294967295L)
				{
					method_8(-1);
				}
				else
				{
					method_8((int)@class.method_6());
				}
				if (array.Length > 0)
				{
					stream_0.Write(array, 0, array.Length);
				}
				if (array2.Length > 0)
				{
					stream_0.Write(array2, 0, array2.Length);
				}
				if (array3.Length > 0)
				{
					stream_0.Write(array3, 0, array3.Length);
				}
				num2 += 46 + array.Length + array2.Length + array3.Length;
			}
			using (Stream25 stream = new Stream25(stream_0))
			{
				stream.method_1(num, num2, long_1, byte_1);
			}
			arrayList_0 = null;
		}
	}
}
