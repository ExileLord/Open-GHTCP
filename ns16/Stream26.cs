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
				return _stream.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return _stream.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return _stream.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return _stream.Length;
			}
		}

		public override long Position
		{
			get
			{
				return _stream.Position;
			}
			set
			{
				_stream.Position = value;
			}
		}

		public void SetEndianness(EndiannessEnum enum33_0)
		{
			switch (enum33_0)
			{
			case EndiannessEnum.const_1:
				_reverseEndianness = false;
				return;
			case EndiannessEnum.const_2:
				_reverseEndianness = true;
				return;
			default:
				_reverseEndianness = false;
				bool_1 = true;
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
			_stream = new Stream27();
			bool_1 = false;
			SetEndianness(enum33_0);
		}

		public Stream26(Stream stream_1) : this(stream_1, EndiannessEnum.const_0)
		{
		}

		public Stream26(Stream stream_1, bool bool_2) : this(stream_1, bool_2 ? EndiannessEnum.const_2 : EndiannessEnum.const_1)
		{
		}

		public Stream26(Stream stream_1, EndiannessEnum enum33_0)
		{
			_stream = stream_1;
			SetEndianness(enum33_0);
		}

		public Stream26(byte[] byte_0) : this(byte_0, EndiannessEnum.const_0)
		{
		}

		public Stream26(byte[] byte_0, bool bool_2) : this(byte_0, bool_2 ? EndiannessEnum.const_2 : EndiannessEnum.const_1)
		{
		}

		public Stream26(byte[] byte_0, EndiannessEnum enum33_0)
		{
			_stream = new Stream27(byte_0);
			SetEndianness(enum33_0);
		}

		public byte[] ReadEverything()
		{
			if (_stream is Stream27)
			{
				return ((Stream27)_stream).ToArray();
			}
			if (!CanRead)
			{
				throw new Exception("Can't read from hexstream!");
			}
			return KeyGenerator.ReadBytes(_stream);
		}

		public void WriteEverythingToFile(string fileName)
		{
			if (_stream is Stream27)
			{
				KeyGenerator.WriteAllBytes(fileName, ((Stream27)_stream).ToArray());
				return;
			}
			if (!CanRead)
			{
				throw new Exception("Can't read from hexstream!");
			}
			KeyGenerator.smethod_46(_stream, fileName);
		}

		public void WriteByte2(byte value)
		{
			_stream.WriteByte(value);
		}

		public void WriteNBytes(byte value, int count)
		{
			while (count-- != 0)
			{
				_stream.WriteByte(value);
			}
		}

		public void WriteInt(int value)
		{
			WriteInt(value, _reverseEndianness);
		}

		public void WriteInt(int value, bool ReverseEndianness)
		{
			WriteByteArray(BitConverter.GetBytes(value), !(ReverseEndianness ^ BitConverter.IsLittleEndian));
		}

		public void WriteUInt(uint value)
		{
			WriteUInt(value, _reverseEndianness);
		}

		public void WriteUInt(uint value, bool ReverseEndianness)
		{
			WriteByteArray(BitConverter.GetBytes(value), !(ReverseEndianness ^ BitConverter.IsLittleEndian));
		}

		public void WriteFloat(float value)
		{
			WriteFloat(value, _reverseEndianness);
		}

		public void WriteFloat(float value, bool ReverseEndianness)
		{
			WriteByteArray(BitConverter.GetBytes(value), !(ReverseEndianness ^ BitConverter.IsLittleEndian));
		}

		public void WriteShort(short value)
		{
			WriteShort(value, _reverseEndianness);
		}

		public void WriteShort(short value, bool ReverseEndianness)
		{
			WriteByteArray(BitConverter.GetBytes(value), !(ReverseEndianness ^ BitConverter.IsLittleEndian));
		}

		public void WriteString(string value)
		{
			WriteByteArray(Encoding.ASCII.GetBytes(value), false);
		}

		public void WriteString(string value, bool ReverseEndianness)
		{
			if (ReverseEndianness)
			{
				WriteByteArray(Encoding.BigEndianUnicode.GetBytes(value), false);
				return;
			}
			WriteByteArray(Encoding.Unicode.GetBytes(value), false);
		}

		public void WriteByteArray(byte[] byte_0)
		{
			WriteByteArray(byte_0, _reverseEndianness);
		}

		public void WriteByteArray(byte[] array, bool WriteBackwards)
		{
			if (WriteBackwards)
			{
				for (var i = array.Length - 1; i >= 0; i--)
				{
					_stream.WriteByte(array[i]);
				}
				return;
			}
			_stream.Write(array, 0, array.Length);
		}

		public void WriteEnumerableInts(IEnumerable<int> values, bool ReverseEndianness)
		{
			foreach (var current in values)
			{
				WriteInt(current, ReverseEndianness);
			}
		}

		public byte ReadByte2()
		{
			return (byte)ReadByte();
		}

		public int ReadInt()
		{
			return ReadInt(_reverseEndianness);
		}

		public int ReadInt(bool ReverseEndianness)
		{
			var array = ReadBytes(4, false);
			if (!(ReverseEndianness ^ BitConverter.IsLittleEndian))
			{
				return KeyGenerator.BytesToInt(array);
			}
			return BitConverter.ToInt32(array, 0);
		}

		public float ReadFloat()
		{
			return ReadFloat(_reverseEndianness);
		}

		public float ReadFloat(bool ReverseEndianness)
		{
			var array = ReadBytes(4, false);
			if (!(ReverseEndianness ^ BitConverter.IsLittleEndian))
			{
				var array2 = array;
				array = new[]
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
			return ReadShort(_reverseEndianness);
		}

		public short ReadShort(bool ReverseEndianness)
		{
			var array = ReadBytes(2, false);
			if (!(ReverseEndianness ^ BitConverter.IsLittleEndian))
			{
				return KeyGenerator.BytesToShort(array);
			}
			return BitConverter.ToInt16(array, 0);
		}

		public ushort ReadUShort()
		{
			return ReadUShort(_reverseEndianness);
		}

		public ushort ReadUShort(bool ReverseEndianness)
		{
			var array = ReadBytes(2, false);
			if (!(ReverseEndianness ^ BitConverter.IsLittleEndian))
			{
				return (ushort)KeyGenerator.BytesToShort(array);
			}
			return BitConverter.ToUInt16(array, 0);
		}

		public string ReadAsciiString()
		{
			var list = new List<byte>();
			for (var item = ReadByte2(); item != 0; item = ReadByte2())
			{
				list.Add(item);
			}
			return Encoding.ASCII.GetString(list.ToArray());
		}

		public string ReadString(int length)
		{
			return Encoding.ASCII.GetString(ReadBytes(length, false));
		}

		public string ReadUnicodeString()
		{
			return ReadUnicodeString(_reverseEndianness);
		}

		public string ReadUnicodeString(bool ReverseEndianness)
		{
			var list = new List<byte>();
			var b = ReadByte2();
			var b2 = ReadByte2();
			while (b != 0 || b2 != 0)
			{
				list.Add(b);
				list.Add(b2);
				b = ReadByte2();
				b2 = ReadByte2();
			}
			if (!ReverseEndianness)
			{
				return Encoding.Unicode.GetString(list.ToArray());
			}
			return Encoding.BigEndianUnicode.GetString(list.ToArray());
		}

		public byte[] ReadBytes(int count)
		{
			return ReadBytes(count, _reverseEndianness);
		}

		public byte[] ReadBytes(int count, bool ReverseEndianness)
		{
			var array = new byte[count];
			if (_stream.Read(array, 0, count) == 0)
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
			WriteIntAt(int_0, int_1, _reverseEndianness);
		}

		public void WriteIntAt(int int_0, int int_1, bool bool_2)
		{
			_stream.Seek(int_0, SeekOrigin.Begin);
			WriteInt(int_1, bool_2);
		}

		public void WriteShortAt(int int_0, short short_0)
		{
			WriteShortAt(int_0, short_0, _reverseEndianness);
		}

		public void WriteShortAt(int int_0, short short_0, bool bool_2)
		{
			_stream.Seek(int_0, SeekOrigin.Begin);
			WriteShort(short_0, bool_2);
		}

		public void WriteByteArrayAt(int int_0, byte[] byte_0, bool bool_2)
		{
			_stream.Seek(int_0, SeekOrigin.Begin);
			WriteByteArray(byte_0, bool_2);
		}

		public void WriteEnumerableIntsAt(int int_0, IEnumerable<int> ienumerable_0)
		{
			WriteEnumerableIntsAt(int_0, ienumerable_0, _reverseEndianness);
		}

		public void WriteEnumerableIntsAt(int int_0, IEnumerable<int> ienumerable_0, bool bool_2)
		{
			_stream.Seek(int_0, SeekOrigin.Begin);
			WriteEnumerableInts(ienumerable_0, bool_2);
		}

		public byte ReadByteAt(int int_0)
		{
			_stream.Seek(int_0, SeekOrigin.Begin);
			return ReadByte2();
		}

		public int ReadIntAt(int int_0)
		{
			return ReadIntAt(int_0, _reverseEndianness);
		}

		public int ReadIntAt(int int_0, bool bool_2)
		{
			_stream.Seek(int_0, SeekOrigin.Begin);
			return ReadInt(bool_2);
		}

		public short ReadShortAt(int int_0)
		{
			return ReadShortAt(int_0, _reverseEndianness);
		}

		public short ReadShortAt(int int_0, bool bool_2)
		{
			_stream.Seek(int_0, SeekOrigin.Begin);
			return ReadShort(bool_2);
		}

		public string ReadAsciiStringAt(int int_0)
		{
			_stream.Seek(int_0, SeekOrigin.Begin);
			return ReadAsciiString();
		}

		public string ReadUnicodeStringAt(int int_0)
		{
			_stream.Seek(int_0, SeekOrigin.Begin);
			return ReadUnicodeString();
		}

		public byte[] ReadBytesAt(int position, int count, bool ReverseEndianness)
		{
			_stream.Seek(position, SeekOrigin.Begin);
			return ReadBytes(count, ReverseEndianness);
		}

		public override void Flush()
		{
			_stream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return _stream.Read(buffer, offset, count);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return _stream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			_stream.SetLength(value);
		}

		public override int ReadByte()
		{
			return _stream.ReadByte();
		}

		public override void WriteByte(byte value)
		{
			_stream.WriteByte(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			_stream.Write(buffer, offset, count);
		}

		public override void Close()
		{
			_stream.Close();
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_stream.Dispose();
			}
		}

		public new void Dispose()
		{
			Close();
			Dispose(true);
			_stream = null;
		}
	}
}
