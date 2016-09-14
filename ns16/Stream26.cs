using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns16
{
	public class Stream26 : Stream, IDisposable
	{
		public Stream stream_0;

		public bool bool_0;

		public bool bool_1;

		public override bool CanRead
		{
			get
			{
				return this.stream_0.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return this.stream_0.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return this.stream_0.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return this.stream_0.Length;
			}
		}

		public override long Position
		{
			get
			{
				return this.stream_0.Position;
			}
			set
			{
				this.stream_0.Position = value;
			}
		}

		public void method_0(Enum33 enum33_0)
		{
			switch (enum33_0)
			{
			case Enum33.const_1:
				this.bool_0 = false;
				return;
			case Enum33.const_2:
				this.bool_0 = true;
				return;
			default:
				this.bool_0 = false;
				this.bool_1 = true;
				return;
			}
		}

		public Stream26() : this(Enum33.const_0)
		{
		}

		public Stream26(bool bool_2) : this(bool_2 ? Enum33.const_2 : Enum33.const_1)
		{
		}

		public Stream26(Enum33 enum33_0)
		{
			this.stream_0 = new Stream27();
			this.bool_1 = false;
			this.method_0(enum33_0);
		}

		public Stream26(Stream stream_1) : this(stream_1, Enum33.const_0)
		{
		}

		public Stream26(Stream stream_1, bool bool_2) : this(stream_1, bool_2 ? Enum33.const_2 : Enum33.const_1)
		{
		}

		public Stream26(Stream stream_1, Enum33 enum33_0)
		{
			this.stream_0 = stream_1;
			this.method_0(enum33_0);
		}

		public Stream26(byte[] byte_0) : this(byte_0, Enum33.const_0)
		{
		}

		public Stream26(byte[] byte_0, bool bool_2) : this(byte_0, bool_2 ? Enum33.const_2 : Enum33.const_1)
		{
		}

		public Stream26(byte[] byte_0, Enum33 enum33_0)
		{
			this.stream_0 = new Stream27(byte_0);
			this.method_0(enum33_0);
		}

		public byte[] method_1()
		{
			if (this.stream_0 is Stream27)
			{
				return ((Stream27)this.stream_0).ToArray();
			}
			if (!this.CanRead)
			{
				throw new Exception("Can't read from hexstream!");
			}
			return KeyGenerator.ReadBytes(this.stream_0);
		}

		public void method_2(string string_0)
		{
			if (this.stream_0 is Stream27)
			{
				KeyGenerator.smethod_9(string_0, ((Stream27)this.stream_0).ToArray());
				return;
			}
			if (!this.CanRead)
			{
				throw new Exception("Can't read from hexstream!");
			}
			KeyGenerator.smethod_46(this.stream_0, string_0);
		}

		public void method_3(byte byte_0)
		{
			this.stream_0.WriteByte(byte_0);
		}

		public void method_4(byte byte_0, int int_0)
		{
			while (int_0-- != 0)
			{
				this.stream_0.WriteByte(byte_0);
			}
		}

		public void method_5(int int_0)
		{
			this.method_6(int_0, this.bool_0);
		}

		public void method_6(int int_0, bool bool_2)
		{
			this.method_16(BitConverter.GetBytes(int_0), !(bool_2 ^ BitConverter.IsLittleEndian));
		}

		public void method_7(uint uint_0)
		{
			this.method_8(uint_0, this.bool_0);
		}

		public void method_8(uint uint_0, bool bool_2)
		{
			this.method_16(BitConverter.GetBytes(uint_0), !(bool_2 ^ BitConverter.IsLittleEndian));
		}

		public void method_9(float float_0)
		{
			this.method_10(float_0, this.bool_0);
		}

		public void method_10(float float_0, bool bool_2)
		{
			this.method_16(BitConverter.GetBytes(float_0), !(bool_2 ^ BitConverter.IsLittleEndian));
		}

		public void method_11(short short_0)
		{
			this.method_12(short_0, this.bool_0);
		}

		public void method_12(short short_0, bool bool_2)
		{
			this.method_16(BitConverter.GetBytes(short_0), !(bool_2 ^ BitConverter.IsLittleEndian));
		}

		public void method_13(string string_0)
		{
			this.method_16(Encoding.ASCII.GetBytes(string_0), false);
		}

		public void method_14(string string_0, bool bool_2)
		{
			if (bool_2)
			{
				this.method_16(Encoding.BigEndianUnicode.GetBytes(string_0), false);
				return;
			}
			this.method_16(Encoding.Unicode.GetBytes(string_0), false);
		}

		public void method_15(byte[] byte_0)
		{
			this.method_16(byte_0, this.bool_0);
		}

		public void method_16(byte[] byte_0, bool bool_2)
		{
			if (bool_2)
			{
				for (int i = byte_0.Length - 1; i >= 0; i--)
				{
					this.stream_0.WriteByte(byte_0[i]);
				}
				return;
			}
			this.stream_0.Write(byte_0, 0, byte_0.Length);
		}

		public void method_17(IEnumerable<int> ienumerable_0, bool bool_2)
		{
			foreach (int current in ienumerable_0)
			{
				this.method_6(current, bool_2);
			}
		}

		public byte method_18()
		{
			return (byte)this.ReadByte();
		}

		public int method_19()
		{
			return this.method_20(this.bool_0);
		}

		public int method_20(bool bool_2)
		{
			byte[] array = this.method_32(4, false);
			if (!(bool_2 ^ BitConverter.IsLittleEndian))
			{
				return KeyGenerator.BytesToInt(array);
			}
			return BitConverter.ToInt32(array, 0);
		}

		public float method_21()
		{
			return this.method_22(this.bool_0);
		}

		public float method_22(bool bool_2)
		{
			byte[] array = this.method_32(4, false);
			if (!(bool_2 ^ BitConverter.IsLittleEndian))
			{
				byte[] array2 = array;
				array = new byte[]
				{
					array2[3],
					array2[2],
					array2[1],
					array2[0]
				};
			}
			return BitConverter.ToSingle(array, 0);
		}

		public short method_23()
		{
			return this.method_24(this.bool_0);
		}

		public short method_24(bool bool_2)
		{
			byte[] array = this.method_32(2, false);
			if (!(bool_2 ^ BitConverter.IsLittleEndian))
			{
				return KeyGenerator.BytesToShort(array);
			}
			return BitConverter.ToInt16(array, 0);
		}

		public ushort method_25()
		{
			return this.method_26(this.bool_0);
		}

		public ushort method_26(bool bool_2)
		{
			byte[] array = this.method_32(2, false);
			if (!(bool_2 ^ BitConverter.IsLittleEndian))
			{
				return (ushort)KeyGenerator.BytesToShort(array);
			}
			return BitConverter.ToUInt16(array, 0);
		}

		public string method_27()
		{
			List<byte> list = new List<byte>();
			for (byte item = this.method_18(); item != 0; item = this.method_18())
			{
				list.Add(item);
			}
			return Encoding.ASCII.GetString(list.ToArray());
		}

		public string method_28(int int_0)
		{
			return Encoding.ASCII.GetString(this.method_32(int_0, false));
		}

		public string method_29()
		{
			return this.method_30(this.bool_0);
		}

		public string method_30(bool bool_2)
		{
			List<byte> list = new List<byte>();
			byte b = this.method_18();
			byte b2 = this.method_18();
			while (b != 0 || b2 != 0)
			{
				list.Add(b);
				list.Add(b2);
				b = this.method_18();
				b2 = this.method_18();
			}
			if (!bool_2)
			{
				return Encoding.Unicode.GetString(list.ToArray());
			}
			return Encoding.BigEndianUnicode.GetString(list.ToArray());
		}

		public byte[] method_31(int int_0)
		{
			return this.method_32(int_0, this.bool_0);
		}

		public byte[] method_32(int int_0, bool bool_2)
		{
			byte[] array = new byte[int_0];
			if (this.stream_0.Read(array, 0, int_0) == 0)
			{
				throw new EndOfStreamException();
			}
			if (bool_2)
			{
				Array.Reverse(array);
			}
			return array;
		}

		public void method_33(int int_0, int int_1)
		{
			this.method_34(int_0, int_1, this.bool_0);
		}

		public void method_34(int int_0, int int_1, bool bool_2)
		{
			this.stream_0.Seek((long)int_0, SeekOrigin.Begin);
			this.method_6(int_1, bool_2);
		}

		public void method_35(int int_0, short short_0)
		{
			this.method_36(int_0, short_0, this.bool_0);
		}

		public void method_36(int int_0, short short_0, bool bool_2)
		{
			this.stream_0.Seek((long)int_0, SeekOrigin.Begin);
			this.method_12(short_0, bool_2);
		}

		public void method_37(int int_0, byte[] byte_0, bool bool_2)
		{
			this.stream_0.Seek((long)int_0, SeekOrigin.Begin);
			this.method_16(byte_0, bool_2);
		}

		public void method_38(int int_0, IEnumerable<int> ienumerable_0)
		{
			this.method_39(int_0, ienumerable_0, this.bool_0);
		}

		public void method_39(int int_0, IEnumerable<int> ienumerable_0, bool bool_2)
		{
			this.stream_0.Seek((long)int_0, SeekOrigin.Begin);
			this.method_17(ienumerable_0, bool_2);
		}

		public byte method_40(int int_0)
		{
			this.stream_0.Seek((long)int_0, SeekOrigin.Begin);
			return this.method_18();
		}

		public int method_41(int int_0)
		{
			return this.method_42(int_0, this.bool_0);
		}

		public int method_42(int int_0, bool bool_2)
		{
			this.stream_0.Seek((long)int_0, SeekOrigin.Begin);
			return this.method_20(bool_2);
		}

		public short method_43(int int_0)
		{
			return this.method_44(int_0, this.bool_0);
		}

		public short method_44(int int_0, bool bool_2)
		{
			this.stream_0.Seek((long)int_0, SeekOrigin.Begin);
			return this.method_24(bool_2);
		}

		public string method_45(int int_0)
		{
			this.stream_0.Seek((long)int_0, SeekOrigin.Begin);
			return this.method_27();
		}

		public string method_46(int int_0)
		{
			this.stream_0.Seek((long)int_0, SeekOrigin.Begin);
			return this.method_29();
		}

		public byte[] method_47(int int_0, int int_1, bool bool_2)
		{
			this.stream_0.Seek((long)int_0, SeekOrigin.Begin);
			return this.method_32(int_1, bool_2);
		}

		public override void Flush()
		{
			this.stream_0.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return this.stream_0.Read(buffer, offset, count);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return this.stream_0.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			this.stream_0.SetLength(value);
		}

		public override int ReadByte()
		{
			return this.stream_0.ReadByte();
		}

		public override void WriteByte(byte value)
		{
			this.stream_0.WriteByte(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			this.stream_0.Write(buffer, offset, count);
		}

		public override void Close()
		{
			this.stream_0.Close();
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.stream_0.Dispose();
			}
		}

		public new void Dispose()
		{
			this.Close();
			this.Dispose(true);
			this.stream_0 = null;
		}
	}
}
