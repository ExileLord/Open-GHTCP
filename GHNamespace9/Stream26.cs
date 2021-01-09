using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GHNamespace9
{
    public class Stream26 : Stream, IDisposable
    {
        public Stream Stream;

        public bool ReverseEndianness;

        public bool Bool1;

        public override bool CanRead => Stream.CanRead;

        public override bool CanSeek => Stream.CanSeek;

        public override bool CanWrite => Stream.CanWrite;

        public override long Length => Stream.Length;

        public override long Position
        {
            get => Stream.Position;
            set => Stream.Position = value;
        }

        public void SetEndianness(EndiannessEnum enum330)
        {
            switch (enum330)
            {
                case EndiannessEnum.Const1:
                    ReverseEndianness = false;
                    return;
                case EndiannessEnum.Const2:
                    ReverseEndianness = true;
                    return;
                default:
                    ReverseEndianness = false;
                    Bool1 = true;
                    return;
            }
        }

        public Stream26() : this(EndiannessEnum.Const0)
        {
        }

        public Stream26(bool bool2) : this(bool2 ? EndiannessEnum.Const2 : EndiannessEnum.Const1)
        {
        }

        public Stream26(EndiannessEnum enum330)
        {
            Stream = new Stream27();
            Bool1 = false;
            SetEndianness(enum330);
        }

        public Stream26(Stream stream1) : this(stream1, EndiannessEnum.Const0)
        {
        }

        public Stream26(Stream stream1, bool bool2) : this(stream1,
            bool2 ? EndiannessEnum.Const2 : EndiannessEnum.Const1)
        {
        }

        public Stream26(Stream stream1, EndiannessEnum enum330)
        {
            Stream = stream1;
            SetEndianness(enum330);
        }

        public Stream26(byte[] byte0) : this(byte0, EndiannessEnum.Const0)
        {
        }

        public Stream26(byte[] byte0, bool bool2) : this(byte0, bool2 ? EndiannessEnum.Const2 : EndiannessEnum.Const1)
        {
        }

        public Stream26(byte[] byte0, EndiannessEnum enum330)
        {
            Stream = new Stream27(byte0);
            SetEndianness(enum330);
        }

        public byte[] ReadEverything()
        {
            if (Stream is Stream27)
            {
                return ((Stream27) Stream).ToArray();
            }
            if (!CanRead)
            {
                throw new Exception("Can't read from hexstream!");
            }
            return KeyGenerator.ReadBytes(Stream);
        }

        public void WriteEverythingToFile(string fileName)
        {
            if (Stream is Stream27)
            {
                KeyGenerator.WriteAllBytes(fileName, ((Stream27) Stream).ToArray());
                return;
            }
            if (!CanRead)
            {
                throw new Exception("Can't read from hexstream!");
            }
            KeyGenerator.smethod_46(Stream, fileName);
        }

        public void WriteByte2(byte value)
        {
            Stream.WriteByte(value);
        }

        public void WriteNBytes(byte value, int count)
        {
            while (count-- != 0)
            {
                Stream.WriteByte(value);
            }
        }

        public void WriteInt(int value)
        {
            WriteInt(value, ReverseEndianness);
        }

        public void WriteInt(int value, bool reverseEndianness)
        {
            WriteByteArray(BitConverter.GetBytes(value), !(reverseEndianness ^ BitConverter.IsLittleEndian));
        }

        public void WriteUInt(uint value)
        {
            WriteUInt(value, ReverseEndianness);
        }

        public void WriteUInt(uint value, bool reverseEndianness)
        {
            WriteByteArray(BitConverter.GetBytes(value), !(reverseEndianness ^ BitConverter.IsLittleEndian));
        }

        public void WriteFloat(float value)
        {
            WriteFloat(value, ReverseEndianness);
        }

        public void WriteFloat(float value, bool reverseEndianness)
        {
            WriteByteArray(BitConverter.GetBytes(value), !(reverseEndianness ^ BitConverter.IsLittleEndian));
        }

        public void WriteShort(short value)
        {
            WriteShort(value, ReverseEndianness);
        }

        public void WriteShort(short value, bool reverseEndianness)
        {
            WriteByteArray(BitConverter.GetBytes(value), !(reverseEndianness ^ BitConverter.IsLittleEndian));
        }

        public void WriteString(string value)
        {
            WriteByteArray(Encoding.ASCII.GetBytes(value), false);
        }

        public void WriteString(string value, bool reverseEndianness)
        {
            if (reverseEndianness)
            {
                WriteByteArray(Encoding.BigEndianUnicode.GetBytes(value), false);
                return;
            }
            WriteByteArray(Encoding.Unicode.GetBytes(value), false);
        }

        public void WriteByteArray(byte[] byte0)
        {
            WriteByteArray(byte0, ReverseEndianness);
        }

        public void WriteByteArray(byte[] array, bool writeBackwards)
        {
            if (writeBackwards)
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    Stream.WriteByte(array[i]);
                }
                return;
            }
            Stream.Write(array, 0, array.Length);
        }

        public void WriteEnumerableInts(IEnumerable<int> values, bool reverseEndianness)
        {
            foreach (int current in values)
            {
                WriteInt(current, reverseEndianness);
            }
        }

        public byte ReadByte2()
        {
            return (byte) ReadByte();
        }

        public int ReadInt()
        {
            return ReadInt(ReverseEndianness);
        }

        public int ReadInt(bool reverseEndianness)
        {
            byte[] array = ReadBytes(4, false);
            if (!(reverseEndianness ^ BitConverter.IsLittleEndian))
            {
                return KeyGenerator.BytesToInt(array);
            }
            return BitConverter.ToInt32(array, 0);
        }

        public float ReadFloat()
        {
            return ReadFloat(ReverseEndianness);
        }

        public float ReadFloat(bool reverseEndianness)
        {
            byte[] array = ReadBytes(4, false);
            if (!(reverseEndianness ^ BitConverter.IsLittleEndian))
            {
                byte[] array2 = array;
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
            return ReadShort(ReverseEndianness);
        }

        public short ReadShort(bool reverseEndianness)
        {
            byte[] array = ReadBytes(2, false);
            if (!(reverseEndianness ^ BitConverter.IsLittleEndian))
            {
                return KeyGenerator.BytesToShort(array);
            }
            return BitConverter.ToInt16(array, 0);
        }

        public ushort ReadUShort()
        {
            return ReadUShort(ReverseEndianness);
        }

        public ushort ReadUShort(bool reverseEndianness)
        {
            byte[] array = ReadBytes(2, false);
            if (!(reverseEndianness ^ BitConverter.IsLittleEndian))
            {
                return (ushort) KeyGenerator.BytesToShort(array);
            }
            return BitConverter.ToUInt16(array, 0);
        }

        public string ReadAsciiString()
        {
            List<byte> list = new List<byte>();
            for (byte item = ReadByte2(); item != 0; item = ReadByte2())
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
            return ReadUnicodeString(ReverseEndianness);
        }

        public string ReadUnicodeString(bool reverseEndianness)
        {
            List<byte> list = new List<byte>();
            byte b = ReadByte2();
            byte b2 = ReadByte2();
            while (b != 0 || b2 != 0)
            {
                list.Add(b);
                list.Add(b2);
                b = ReadByte2();
                b2 = ReadByte2();
            }
            if (!reverseEndianness)
            {
                return Encoding.Unicode.GetString(list.ToArray());
            }
            return Encoding.BigEndianUnicode.GetString(list.ToArray());
        }

        public byte[] ReadBytes(int count)
        {
            return ReadBytes(count, ReverseEndianness);
        }

        public byte[] ReadBytes(int count, bool reverseEndianness)
        {
            byte[] array = new byte[count];
            if (Stream.Read(array, 0, count) == 0)
            {
                throw new EndOfStreamException();
            }
            if (reverseEndianness)
            {
                Array.Reverse(array);
            }
            return array;
        }

        public void WriteIntAt(int int0, int int1)
        {
            WriteIntAt(int0, int1, ReverseEndianness);
        }

        public void WriteIntAt(int int0, int int1, bool bool2)
        {
            Stream.Seek(int0, SeekOrigin.Begin);
            WriteInt(int1, bool2);
        }

        public void WriteShortAt(int int0, short short0)
        {
            WriteShortAt(int0, short0, ReverseEndianness);
        }

        public void WriteShortAt(int int0, short short0, bool bool2)
        {
            Stream.Seek(int0, SeekOrigin.Begin);
            WriteShort(short0, bool2);
        }

        public void WriteByteArrayAt(int int0, byte[] byte0, bool bool2)
        {
            Stream.Seek(int0, SeekOrigin.Begin);
            WriteByteArray(byte0, bool2);
        }

        public void WriteEnumerableIntsAt(int int0, IEnumerable<int> ienumerable0)
        {
            WriteEnumerableIntsAt(int0, ienumerable0, ReverseEndianness);
        }

        public void WriteEnumerableIntsAt(int int0, IEnumerable<int> ienumerable0, bool bool2)
        {
            Stream.Seek(int0, SeekOrigin.Begin);
            WriteEnumerableInts(ienumerable0, bool2);
        }

        public byte ReadByteAt(int int0)
        {
            Stream.Seek(int0, SeekOrigin.Begin);
            return ReadByte2();
        }

        public int ReadIntAt(int int0)
        {
            return ReadIntAt(int0, ReverseEndianness);
        }

        public int ReadIntAt(int int0, bool bool2)
        {
            Stream.Seek(int0, SeekOrigin.Begin);
            return ReadInt(bool2);
        }

        public short ReadShortAt(int int0)
        {
            return ReadShortAt(int0, ReverseEndianness);
        }

        public short ReadShortAt(int int0, bool bool2)
        {
            Stream.Seek(int0, SeekOrigin.Begin);
            return ReadShort(bool2);
        }

        public string ReadAsciiStringAt(int int0)
        {
            Stream.Seek(int0, SeekOrigin.Begin);
            return ReadAsciiString();
        }

        public string ReadUnicodeStringAt(int int0)
        {
            Stream.Seek(int0, SeekOrigin.Begin);
            return ReadUnicodeString();
        }

        public byte[] ReadBytesAt(int position, int count, bool reverseEndianness)
        {
            Stream.Seek(position, SeekOrigin.Begin);
            return ReadBytes(count, reverseEndianness);
        }

        public override void Flush()
        {
            Stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return Stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return Stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            Stream.SetLength(value);
        }

        public override int ReadByte()
        {
            return Stream.ReadByte();
        }

        public override void WriteByte(byte value)
        {
            Stream.WriteByte(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Stream.Write(buffer, offset, count);
        }

        public override void Close()
        {
            Stream.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Stream.Dispose();
            }
        }

        public new void Dispose()
        {
            Close();
            Dispose(true);
            Stream = null;
        }
    }
}