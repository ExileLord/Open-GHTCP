using Compression.Zip;
using ns13;
using ns14;
using System;
using System.IO;

namespace ns12
{
	public class Stream20 : Stream19
	{
		private delegate int Delegate5(byte[] b, int offset, int length);

		private Stream20.Delegate5 delegate5_0;

		private Class192 class192_0 = new Class192();

		private Class193 class193_0;

		private long long_1;

		private int int_0;

		private int int_1;

		private string string_0;

		public override long Length
		{
			get
			{
				if (this.class193_0 == null)
				{
					throw new InvalidOperationException("No current entry");
				}
				if (this.class193_0.method_21() < 0L)
				{
					throw new ZipException("Length not available for the current entry");
				}
				return this.class193_0.method_21();
			}
		}

		public Stream20(Stream stream_1) : base(stream_1, new Class196(true))
		{
			this.delegate5_0 = new Stream20.Delegate5(this.method_9);
		}

		public void method_3(string string_1)
		{
			this.string_0 = string_1;
		}

		public bool method_4()
		{
			return this.class193_0 != null && this.class193_0.method_12();
		}

		public Class193 method_5()
		{
			if (this.class192_0 == null)
			{
				throw new InvalidOperationException("Closed.");
			}
			if (this.class193_0 != null)
			{
				this.method_8();
			}
			int num = this.class201_0.method_10();
			if (num != 33639248 && num != 101010256 && num != 84233040 && num != 117853008)
			{
				if (num != 101075792)
				{
					if (num == 808471376 || num == 134695760)
					{
						num = this.class201_0.method_10();
					}
					if (num != 67324752)
					{
						throw new ZipException("Wrong Local header signature: 0x" + string.Format("{0:X}", num));
					}
					short int_ = (short)this.class201_0.method_9();
					this.int_1 = this.class201_0.method_9();
					this.int_0 = this.class201_0.method_9();
					uint num2 = (uint)this.class201_0.method_10();
					int num3 = this.class201_0.method_10();
					this.long_0 = (long)this.class201_0.method_10();
					this.long_1 = (long)this.class201_0.method_10();
					int num4 = this.class201_0.method_9();
					int num5 = this.class201_0.method_9();
					bool flag = (this.int_1 & 1) == 1;
					byte[] array = new byte[num4];
					this.class201_0.method_5(array);
					string string_ = Class186.smethod_2(this.int_1, array);
					this.class193_0 = new Class193(string_, (int)int_);
					this.class193_0.method_5(this.int_1);
					this.class193_0.method_28((Enum31)this.int_0);
					if ((this.int_1 & 8) == 0)
					{
						this.class193_0.method_26((long)num3 & 4294967295L);
						this.class193_0.method_22(this.long_1 & 4294967295L);
						this.class193_0.method_24(this.long_0 & 4294967295L);
						this.class193_0.method_3((byte)(num3 >> 24 & 255));
					}
					else
					{
						if (num3 != 0)
						{
							this.class193_0.method_26((long)num3 & 4294967295L);
						}
						if (this.long_1 != 0L)
						{
							this.class193_0.method_22(this.long_1 & 4294967295L);
						}
						if (this.long_0 != 0L)
						{
							this.class193_0.method_24(this.long_0 & 4294967295L);
						}
						this.class193_0.method_3((byte)(num2 >> 8 & 255u));
					}
					this.class193_0.method_18((long)((ulong)num2));
					if (num5 > 0)
					{
						byte[] array2 = new byte[num5];
						this.class201_0.method_5(array2);
						this.class193_0.method_30(array2);
					}
					this.class193_0.method_31(true);
					if (this.class193_0.method_23() >= 0L)
					{
						this.long_0 = this.class193_0.method_23();
					}
					if (this.class193_0.method_21() >= 0L)
					{
						this.long_1 = this.class193_0.method_21();
					}
					if (this.int_0 == 0 && ((!flag && this.long_0 != this.long_1) || (flag && this.long_0 - 12L != this.long_1)))
					{
						throw new ZipException("Stored, but compressed != uncompressed");
					}
					if (this.class193_0.method_34())
					{
						this.delegate5_0 = new Stream20.Delegate5(this.method_11);
					}
					else
					{
						this.delegate5_0 = new Stream20.Delegate5(this.method_10);
					}
					return this.class193_0;
				}
			}
			this.Close();
			return null;
		}

		private void method_6()
		{
			if (this.class201_0.method_10() != 134695760)
			{
				throw new ZipException("Data descriptor signature not found");
			}
			this.class193_0.method_26((long)this.class201_0.method_10() & 4294967295L);
			if (this.class193_0.method_15())
			{
				this.long_0 = this.class201_0.method_11();
				this.long_1 = this.class201_0.method_11();
			}
			else
			{
				this.long_0 = (long)this.class201_0.method_10();
				this.long_1 = (long)this.class201_0.method_10();
			}
			this.class193_0.method_24(this.long_0);
			this.class193_0.method_22(this.long_1);
		}

		private void method_7(bool bool_2)
		{
			base.method_1();
			if ((this.int_1 & 8) != 0)
			{
				this.method_6();
			}
			this.long_1 = 0L;
			if (bool_2 && (this.class192_0.vmethod_0() & 4294967295L) != this.class193_0.method_25() && this.class193_0.method_25() != -1L)
			{
				throw new ZipException("CRC mismatch");
			}
			this.class192_0.vmethod_1();
			if (this.int_0 == 8)
			{
				this.class196_0.method_0();
			}
			this.class193_0 = null;
		}

		public void method_8()
		{
			if (this.class192_0 == null)
			{
				throw new InvalidOperationException("Closed");
			}
			if (this.class193_0 == null)
			{
				return;
			}
			if (this.int_0 == 8)
			{
				if ((this.int_1 & 8) != 0)
				{
					byte[] array = new byte[2048];
					while (this.Read(array, 0, array.Length) > 0)
					{
					}
					return;
				}
				this.long_0 -= this.class196_0.method_12();
				Class201 expr_67 = this.class201_0;
				expr_67.method_2(expr_67.method_1() + this.class196_0.method_13());
			}
			if ((long)this.class201_0.method_1() > this.long_0 && this.long_0 >= 0L)
			{
				this.class201_0.method_2((int)((long)this.class201_0.method_1() - this.long_0));
			}
			else
			{
				this.long_0 -= (long)this.class201_0.method_1();
				this.class201_0.method_2(0);
				while (this.long_0 != 0L)
				{
					int num = (int)base.method_0(this.long_0 & 4294967295L);
					if (num <= 0)
					{
						throw new ZipException("Zip archive ends early.");
					}
					this.long_0 -= (long)num;
				}
			}
			this.method_7(false);
		}

		public override int ReadByte()
		{
			byte[] array = new byte[1];
			if (this.Read(array, 0, 1) <= 0)
			{
				return -1;
			}
			return (int)(array[0] & 255);
		}

		private int method_9(byte[] byte_0, int int_2, int int_3)
		{
			throw new InvalidOperationException("Unable to read from this stream");
		}

		private int method_10(byte[] byte_0, int int_2, int int_3)
		{
			throw new ZipException("The compression method for this entry is not supported");
		}

		private int method_11(byte[] byte_0, int int_2, int int_3)
		{
			if (!this.method_4())
			{
				throw new ZipException("Library cannot extract this entry. Version required is (" + this.class193_0.method_11().ToString() + ")");
			}
			if (this.class193_0.method_0())
			{
				if (this.string_0 == null)
				{
					throw new ZipException("No password set.");
				}
				Class208 @class = new Class208();
				byte[] rgbKey = Class207.smethod_0(Class186.smethod_3(this.string_0));
				this.class201_0.method_12(@class.CreateDecryptor(rgbKey, null));
				byte[] array = new byte[12];
				this.class201_0.method_7(array, 0, 12);
				if (array[11] != this.class193_0.method_2())
				{
					throw new ZipException("Invalid password");
				}
				if (this.long_0 >= 12L)
				{
					this.long_0 -= 12L;
				}
				else if ((this.class193_0.method_4() & 8) == 0)
				{
					throw new ZipException(string.Format("Entry compressed size {0} too small for encryption", this.long_0));
				}
			}
			else
			{
				this.class201_0.method_12(null);
			}
			if (this.int_0 == 8 && this.class201_0.method_1() > 0)
			{
				this.class201_0.method_3(this.class196_0);
			}
			this.delegate5_0 = new Stream20.Delegate5(this.method_12);
			return this.method_12(byte_0, int_2, int_3);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
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
			return this.delegate5_0(buffer, offset, count);
		}

		private int method_12(byte[] byte_0, int int_2, int int_3)
		{
			if (this.class192_0 == null)
			{
				throw new InvalidOperationException("Closed");
			}
			if (this.class193_0 == null || int_3 <= 0)
			{
				return 0;
			}
			if (int_2 + int_3 > byte_0.Length)
			{
				throw new ArgumentException("Offset + count exceeds buffer size");
			}
			bool flag = false;
			int num = this.int_0;
			if (num != 0)
			{
				if (num == 8)
				{
					int_3 = base.Read(byte_0, int_2, int_3);
					if (int_3 <= 0)
					{
						if (!this.class196_0.method_10())
						{
							throw new ZipException("Inflater not finished!");
						}
						this.class201_0.method_2(this.class196_0.method_13());
						if ((this.int_1 & 8) == 0 && (this.class196_0.method_12() != this.long_0 || this.class196_0.method_11() != this.long_1))
						{
							throw new ZipException(string.Concat(new object[]
							{
								"Size mismatch: ",
								this.long_0,
								";",
								this.long_1,
								" <-> ",
								this.class196_0.method_12(),
								";",
								this.class196_0.method_11()
							}));
						}
						this.class196_0.method_0();
						flag = true;
					}
				}
			}
			else
			{
				if ((long)int_3 > this.long_0 && this.long_0 >= 0L)
				{
					int_3 = (int)this.long_0;
				}
				if (int_3 > 0)
				{
					int_3 = this.class201_0.method_7(byte_0, int_2, int_3);
					if (int_3 > 0)
					{
						this.long_0 -= (long)int_3;
						this.long_1 -= (long)int_3;
					}
				}
				if (this.long_0 == 0L)
				{
					flag = true;
				}
				else if (int_3 < 0)
				{
					throw new ZipException("EOF in stored block");
				}
			}
			if (int_3 > 0)
			{
				this.class192_0.vmethod_3(byte_0, int_2, int_3);
			}
			if (flag)
			{
				this.method_7(true);
			}
			return int_3;
		}

		public override void Close()
		{
			this.delegate5_0 = new Stream20.Delegate5(this.method_9);
			this.class192_0 = null;
			this.class193_0 = null;
			base.Close();
		}
	}
}
