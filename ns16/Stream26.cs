using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns16
{
	public class Stream26 : Stream, IDisposable
	{
		public Stream _stream;

		public bool _reverseEndianness;

		public bool bool_1;

		public override bool CanRead
		{
			get
			{
				return this._stream.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return this._stream.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return this._stream.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return this._stream.Length;
			}
		}

		public override long Position
		{
			get
			{
				return this._stream.Position;
			}
			set
			{
				this._stream.Position = value;
			}
		}

		public void SetEndianness(EndiannessEnum enum33_0)
		{
			switch (enum33_0)
			{
			case EndiannessEnum.const_1:
				this._reverseEndianness = false;
				return;
			case EndiannessEnum.const_2:
				this._reverseEndianness = true;
				return;
			default:
				this._reverseEndianness = false;
				this.bool_1 = true;
				return;
			}
		}

		public Stream26() : this(EndiannessEnum.const_0)
		{
		}

		public Stream26(bool bool_2) : this(bool_2 ? EndiannessEnum.const_2 : EndiannessEnum.const_1)
		{
		}

		public Stream26(EndiannessEnum enum33_0)
		{
			this._stream = new Stream27();
			this.bool_1 = false;
			this.SetEndianness(enum33_0);
		}

		public Stream26(Stream stream_1) : this(stream_1, EndiannessEnum.const_0)
		{
		}

		public Stream26(Stream stream_1, bool bool_2) : this(stream_1, bool_2 ? EndiannessEnum.const_2 : EndiannessEnum.const_1)
		{
		}

		public Stream26(Stream stream_1, EndiannessEnum enum33_0)
		{
			this._stream = stream_1;
			this.SetEndianness(enum33_0);
		}

		public Stream26(byte[] byte_0) : this(byte_0, EndiannessEnum.const_0)
		{
		}

		public Stream26(byte[] byte_0, bool bool_2) : this(byte_0, bool_2 ? EndiannessEnum.const_2 : EndiannessEnum.const_1)
		{
		}

		public Stream26(byte[] byte_0, EndiannessEnum enum33_0)
		{
			this._stream = new Stream27(byte_0);
			this.SetEndianness(enum33_0);
		}

		public byte[] ReadEverything()
		{
			if (this._stream is Stream27)
			{
				return ((Stream27)this._stream).ToArray();
			}
			if (!this.CanRead)
			{
				throw new Exception("Can't read from hexstream!");
			}
			return KeyGenerator.ReadBytes(this._stream);
		}

		public void zzUnknownReadMethod(string string_0)
		{
			if (this._stream is Stream27)
			{
				KeyGenerator.smethod_9(string_0, ((Stream27)this._stream).ToArray());
				return;
			}
			if (!this.CanRead)
			{
				throw new Exception("Can't read from hexstream!");
			}
			KeyGenerator.smethod_46(this._stream, string_0);
		}

		public void WriteByte2(byte value)
		{
			this._stream.WriteByte(value);
		}

		public void WriteNBytes(byte value, int count)
		{
			while (count-- != 0)
			{
				this._stream.WriteByte(value);
			}
		}

		public void WriteInt(int value)
		{
			this.WriteInt(value, this._reverseEndianness);
		}

		public void WriteInt(int value, bool ReverseEndianness)
		{
			this.WriteByteArray(BitConverter.GetBytes(value), !(ReverseEndianness ^ BitConverter.IsLittleEndian));
		}

		public void WriteUInt(uint value)
		{
			this.WriteUInt(value, this._reverseEndianness);
		}

		public void WriteUInt(uint value, bool ReverseEndianness)
		{
			this.WriteByteArray(BitConverter.GetBytes(value), !(ReverseEndianness ^ BitConverter.IsLittleEndian));
		}

		public void WriteFloat(float value)
		{
			this.WriteFloat(value, this._reverseEndianness);
		}

		public void WriteFloat(float value, bool ReverseEndianness)
		{
			this.WriteByteArray(BitConverter.GetBytes(value), !(ReverseEndianness ^ BitConverter.IsLittleEndian));
		}

		public void WriteShort(short value)
		{
			this.WriteShort(value, this._reverseEndianness);
		}

		public void WriteShort(short value, bool ReverseEndianness)
		{
			this.WriteByteArray(BitConverter.GetBytes(value), !(ReverseEndianness ^ BitConverter.IsLittleEndian));
		}

		public void WriteString(string value)
		{
			this.WriteByteArray(Encoding.ASCII.GetBytes(value), false);
		}

		public void WriteString(string value, bool ReverseEndianness)
		{
			if (ReverseEndianness)
			{
				this.WriteByteArray(Encoding.BigEndianUnicode.GetBytes(value), false);
				return;
			}
			this.WriteByteArray(Encoding.Unicode.GetBytes(value), false);
		}

		public void WriteByteArray(byte[] byte_0)
		{
			this.WriteByteArray(byte_0, this._reverseEndianness);
		}

		public void WriteByteArray(byte[] array, bool WriteBackwards)
		{
			if (WriteBackwards)
			{
				for (int i = array.Length - 1; i >= 0; i--)
				{
					this._stream.WriteByte(array[i]);
				}
				return;
			}
			this._stream.Write(array, 0, array.Length);
		}

		public void WriteEnumerableInts(IEnumerable<int> values, bool ReverseEndianness)
		{
			foreach (int current in values)
			{
				this.WriteInt(current, ReverseEndianness);
			}
		}

		public byte ReadByte2()
		{
			return (byte)this.ReadByte();
		}

		public int ReadInt()
		{
			return this.ReadInt(this._reverseEndianness);
		}

		public int ReadInt(bool ReverseEndianness)
		{
			byte[] array = this.ReadBytes(4, false);
			if (!(ReverseEndianness ^ BitConverter.IsLittleEndian))
			{
				return KeyGenerator.BytesToInt(array);
			}
			return BitConverter.ToInt32(array, 0);
		}

		public float ReadFloat()
		{
			return this.ReadFloat(this._reverseEndianness);
		}

		public float ReadFloat(bool ReverseEndianness)
		{
			byte[] array = this.ReadBytes(4, false);
			if (!(ReverseEndianness ^ BitConverter.IsLittleEndian))
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

		public short ReadShort()
		{
			return this.ReadShort(this._reverseEndianness);
		}

		public short ReadShort(bool ReverseEndianness)
		{
			byte[] array = this.ReadBytes(2, false);
			if (!(ReverseEndianness ^ BitConverter.IsLittleEndian))
			{
				return KeyGenerator.BytesToShort(array);
			}
			return BitConverter.ToInt16(array, 0);
		}

		public ushort ReadUShort()
		{
			return this.ReadUShort(this._reverseEndianness);
		}

		public ushort ReadUShort(bool ReverseEndianness)
		{
			byte[] array = this.ReadBytes(2, false);
			if (!(ReverseEndianness ^ BitConverter.IsLittleEndian))
			{
				return (ushort)KeyGenerator.BytesToShort(array);
			}
			return BitConverter.ToUInt16(array, 0);
		}

		public string ReadAsciiString()
		{
			List<byte> list = new List<byte>();
			for (byte item = this.ReadByte2(); item != 0; item = this.ReadByte2())
			{
				list.Add(item);
			}
			return Encoding.ASCII.GetString(list.ToArray());
		}

		public string ReadString(int length)
		{
			return Encoding.ASCII.GetString(this.ReadBytes(length, false));
		}

		public string ReadUnicodeString()
		{
			return this.ReadUnicodeString(this._reverseEndianness);
		}

		public string ReadUnicodeString(bool ReverseEndianness)
		{
			List<byte> list = new List<byte>();
			byte b = this.ReadByte2();
			byte b2 = this.ReadByte2();
			while (b != 0 || b2 != 0)
			{
				list.Add(b);
				list.Add(b2);
				b = this.ReadByte2();
				b2 = this.ReadByte2();
			}
			if (!ReverseEndianness)
			{
				return Encoding.Unicode.GetString(list.ToArray());
			}
			return Encoding.BigEndianUnicode.GetString(list.ToArray());
		}

		public byte[] ReadBytes(int count)
		{
			return this.ReadBytes(count, this._reverseEndianness);
		}

		public byte[] ReadBytes(int count, bool ReverseEndianness)
		{
			byte[] array = new byte[count];
			if (this._stream.Read(array, 0, count) == 0)
			{
				throw new EndOfStreamException();
			}
			if (ReverseEndianness)
			{
				Array.Reverse(array);
			}
			return array;
		}

		public void WriteIntAt(int int_0, int int_1)
		{
			this.WriteIntAt(int_0, int_1, this._reverseEndianness);
		}

		public void WriteIntAt(int int_0, int int_1, bool bool_2)
		{
			this._stream.Seek((long)int_0, SeekOrigin.Begin);
			this.WriteInt(int_1, bool_2);
		}

		public void WriteShortAt(int int_0, short short_0)
		{
			this.WriteShortAt(int_0, short_0, this._reverseEndianness);
		}

		public void WriteShortAt(int int_0, short short_0, bool bool_2)
		{
			this._stream.Seek((long)int_0, SeekOrigin.Begin);
			this.WriteShort(short_0, bool_2);
		}

		public void WriteByteArrayAt(int int_0, byte[] byte_0, bool bool_2)
		{
			this._stream.Seek((long)int_0, SeekOrigin.Begin);
			this.WriteByteArray(byte_0, bool_2);
		}

		public void WriteEnumerableIntsAt(int int_0, IEnumerable<int> ienumerable_0)
		{
			this.WriteEnumerableIntsAt(int_0, ienumerable_0, this._reverseEndianness);
		}

		public void WriteEnumerableIntsAt(int int_0, IEnumerable<int> ienumerable_0, bool bool_2)
		{
			this._stream.Seek((long)int_0, SeekOrigin.Begin);
			this.WriteEnumerableInts(ienumerable_0, bool_2);
		}

		public byte ReadByteAt(int int_0)
		{
			this._stream.Seek((long)int_0, SeekOrigin.Begin);
			return this.ReadByte2();
		}

		public int ReadIntAt(int int_0)
		{
			return this.ReadIntAt(int_0, this._reverseEndianness);
		}

		public int ReadIntAt(int int_0, bool bool_2)
		{
			this._stream.Seek((long)int_0, SeekOrigin.Begin);
			return this.ReadInt(bool_2);
		}

		public short ReadShortAt(int int_0)
		{
			return this.ReadShortAt(int_0, this._reverseEndianness);
		}

		public short ReadShortAt(int int_0, bool bool_2)
		{
			this._stream.Seek((long)int_0, SeekOrigin.Begin);
			return this.ReadShort(bool_2);
		}

		public string ReadAsciiStringAt(int int_0)
		{
			this._stream.Seek((long)int_0, SeekOrigin.Begin);
			return this.ReadAsciiString();
		}

		public string ReadUnicodeStringAt(int int_0)
		{
			this._stream.Seek((long)int_0, SeekOrigin.Begin);
			return this.ReadUnicodeString();
		}

		public byte[] ReadBytesAt(int position, int count, bool ReverseEndianness)
		{
			this._stream.Seek((long)position, SeekOrigin.Begin);
			return this.ReadBytes(count, ReverseEndianness);
		}

		public override void Flush()
		{
			this._stream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return this._stream.Read(buffer, offset, count);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return this._stream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			this._stream.SetLength(value);
		}

		public override int ReadByte()
		{
			return this._stream.ReadByte();
		}

		public override void WriteByte(byte value)
		{
			this._stream.WriteByte(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			this._stream.Write(buffer, offset, count);
		}

		public override void Close()
		{
			this._stream.Close();
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this._stream.Dispose();
			}
		}

		public new void Dispose()
		{
			this.Close();
			this.Dispose(true);
			this._stream = null;
		}
	}
}
