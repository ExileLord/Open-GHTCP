using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns8
{
	public class FSBClass1 : IDisposable
	{
		private enum Enum23
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		private List<Class168> list_0;

		public FSBEnum1 enum20_0;

		public FSBFlags1 enum21_0;

		public byte[] byte_0;

		private Stream stream_0;

		private FSBClass1.Enum23 method_0(int int_0)
		{
			if (this.enum20_0 == FSBEnum1.const_0)
			{
				return FSBClass1.Enum23.const_0;
			}
			if (this.enum20_0 == FSBEnum1.const_1)
			{
				return FSBClass1.Enum23.const_1;
			}
			if ((this.enum21_0 & FSBFlags1.flag_2) != FSBFlags1.flag_0 && int_0 != 0)
			{
				return FSBClass1.Enum23.const_3;
			}
			if (this.enum20_0 == FSBEnum1.const_2)
			{
				return FSBClass1.Enum23.const_1;
			}
			if (this.enum20_0 != FSBEnum1.const_3)
			{
				if (this.enum20_0 != FSBEnum1.const_4)
				{
					throw new Exception5("Unknown version \"" + this.enum20_0 + "\"");
				}
			}
			return FSBClass1.Enum23.const_2;
		}

		public static FSBClass1 smethod_0(Stream stream_1)
		{
			FSBClass1 @class = new FSBClass1();
			long position = stream_1.Position;
			try
			{
				@class.method_1(stream_1);
			}
			catch
			{
				stream_1.Position = position;
				FSBClass2 stream = new FSBClass2(stream_1);
				@class = new FSBClass1();
				@class.method_1(stream);
				@class.byte_0 = stream.byte_0;
			}
			@class.stream_0 = stream_1;
			return @class;
		}

		public static FSBClass1 smethod_1(Stream stream_1, byte[] byte_1)
		{
			FSBClass1 @class = new FSBClass1();
			@class.method_1(new FSBClass2(stream_1, byte_1));
			@class.byte_0 = byte_1;
			@class.stream_0 = stream_1;
			return @class;
		}

		private void method_1(Stream stream_1)
		{
			BinaryReader binaryReader = new BinaryReader(stream_1);
			int int_;
			long long_;
			uint num;
			this.method_2(binaryReader, out int_, out long_, out num);
			this.method_7(binaryReader, int_, long_);
		}

		private void method_2(BinaryReader inputBin, out int numSubFiles, out long dataOffset, out uint allDataSize)
		{
			string @string = Encoding.UTF8.GetString(inputBin.ReadBytes(4));
			string a;
			if ((a = @string) != null)
			{
				uint num;
				if (!(a == "FSB1"))
				{
					if (!(a == "FSB2"))
					{
						if (!(a == "FSB3"))
						{
							if (!(a == "FSB4"))
							{
								goto IL_83;
							}
							this.method_6(inputBin, out numSubFiles, out num, out allDataSize);
						}
						else
						{
							this.method_5(inputBin, out numSubFiles, out num, out allDataSize);
						}
					}
					else
					{
						this.method_4(inputBin, out numSubFiles, out num, out allDataSize);
					}
				}
				else
				{
					this.method_3(inputBin, out numSubFiles, out num, out allDataSize);
				}
				dataOffset = inputBin.BaseStream.Position + (long)((ulong)num);
				return;
			}
			IL_83:
			throw new Exception5("Invalid Fsb version magic string.");
		}

		private void method_3(BinaryReader inputBin, out int numSubFiles, out uint subFileHdrsSize, out uint allDataSize)
		{
			this.enum20_0 = FSBEnum1.const_0;
			allDataSize = inputBin.ReadUInt32();
			numSubFiles = inputBin.ReadInt32();
			inputBin.ReadInt32();
			this.enum21_0 = FSBFlags1.flag_0;
			subFileHdrsSize = (uint)(numSubFiles * 64);
		}

		private void method_4(BinaryReader inputBin, out int numSubFiles, out uint subFileHdrsSize, out uint allDataSize)
		{
			this.enum20_0 = FSBEnum1.const_1;
			numSubFiles = inputBin.ReadInt32();
			subFileHdrsSize = inputBin.ReadUInt32();
			allDataSize = inputBin.ReadUInt32();
		}

		private void method_5(BinaryReader inputBin, out int numSubFiles, out uint subFileHdrsSize, out uint allDataSize)
		{
			this.method_4(inputBin, out numSubFiles, out subFileHdrsSize, out allDataSize);
			this.enum20_0 = this.method_15(inputBin.ReadUInt32());
			this.enum21_0 = (FSBFlags1)inputBin.ReadUInt32();
		}

		private void method_6(BinaryReader inputBin, out int numSubFiles, out uint subFileHdrsSize, out uint allDataSize)
		{
			this.method_5(inputBin, out numSubFiles, out subFileHdrsSize, out allDataSize);
			inputBin.ReadBytes(8);
			inputBin.ReadBytes(16);
		}

		private void method_7(BinaryReader binaryReader_0, int int_0, long long_0)
		{
			long num = long_0;
			for (int i = 0; i < int_0; i++)
			{
				Class168 @class = null;
				uint num2 = 0u;
				switch (this.method_0(i))
				{
				case FSBClass1.Enum23.const_0:
					@class = this.method_8(binaryReader_0, out num2);
					break;
				case FSBClass1.Enum23.const_1:
					@class = this.method_9(binaryReader_0, out num2);
					break;
				case FSBClass1.Enum23.const_2:
					@class = this.method_12(binaryReader_0, out num2);
					break;
				case FSBClass1.Enum23.const_3:
					@class = FSBClass1.smethod_2(binaryReader_0, out num2, this.method_33()[0]);
					break;
				}
				this.method_33().Add(@class);
				@class.stream_1 = new Stream18(binaryReader_0.BaseStream, num, (long)((ulong)num2));
				num += (long)((ulong)num2);
			}
		}

		private Class168 method_8(BinaryReader inputBin, out uint dataSize)
		{
			Class168 @class = new Class168();
			@class.FileName = this.method_14(inputBin.ReadBytes(32));
			@class.uint_0 = inputBin.ReadUInt32();
			dataSize = inputBin.ReadUInt32();
			@class.int_0 = inputBin.ReadInt32();
			@class.ushort_1 = inputBin.ReadUInt16();
			@class.uint_3 = (uint)inputBin.ReadUInt16();
			@class.ushort_0 = inputBin.ReadUInt16();
			@class.short_0 = inputBin.ReadInt16();
			@class.enum22_0 = (FSBFlags2)inputBin.ReadUInt32();
			@class.uint_1 = inputBin.ReadUInt32();
			@class.uint_2 = inputBin.ReadUInt32();
			return @class;
		}

		private Class168 method_9(BinaryReader inputBin, out uint dataSize)
		{
			uint num;
			Class168 @class = this.method_10(inputBin, out dataSize, out num);
			this.method_11(inputBin, @class, num - 64u);
			return @class;
		}

		private Class168 method_10(BinaryReader inputBin, out uint dataSize, out uint hdrSize)
		{
			Class168 @class = new Class168();
			hdrSize = (uint)inputBin.ReadUInt16();
			@class.FileName = this.method_14(inputBin.ReadBytes(30));
			@class.uint_0 = inputBin.ReadUInt32();
			dataSize = inputBin.ReadUInt32();
			@class.uint_1 = inputBin.ReadUInt32();
			@class.uint_2 = inputBin.ReadUInt32();
			@class.enum22_0 = (FSBFlags2)inputBin.ReadUInt32();
			@class.int_0 = inputBin.ReadInt32();
			@class.ushort_0 = inputBin.ReadUInt16();
			@class.short_0 = inputBin.ReadInt16();
			@class.ushort_1 = inputBin.ReadUInt16();
			@class.uint_3 = (uint)inputBin.ReadUInt16();
			return @class;
		}

		private void method_11(BinaryReader binaryReader_0, Class168 class168_0, uint uint_0)
		{
			class168_0.stream_0 = new Stream18(binaryReader_0.BaseStream, binaryReader_0.BaseStream.Position, (long)((ulong)uint_0));
		}

		private Class168 method_12(BinaryReader inputBin, out uint dataSize)
		{
			uint num;
			Class168 @class = this.method_13(inputBin, out dataSize, out num);
			this.method_11(inputBin, @class, num - 80u);
			return @class;
		}

		private Class168 method_13(BinaryReader inputBin, out uint dataSize, out uint hdrSize)
		{
			Class168 @class = this.method_10(inputBin, out dataSize, out hdrSize);
			@class.float_2 = inputBin.ReadSingle();
			@class.float_3 = inputBin.ReadSingle();
			Console.WriteLine(inputBin.BaseStream.Position);
			@class.int_1 = inputBin.ReadInt32();
			Console.WriteLine(@class.int_1);
			@class.short_1 = inputBin.ReadInt16();
			@class.short_2 = inputBin.ReadInt16();
			return @class;
		}

		private static Class168 smethod_2(BinaryReader inputBin, out uint dataSize, Class168 firstFile)
		{
			Class168 @class = new Class168();
			@class.uint_0 = inputBin.ReadUInt32();
			dataSize = inputBin.ReadUInt32();
			Console.WriteLine(inputBin.BaseStream.Position);
			@class.FileName = firstFile.FileName;
			@class.uint_1 = firstFile.uint_1;
			@class.uint_2 = firstFile.uint_2;
			@class.enum22_0 = firstFile.enum22_0;
			@class.int_0 = firstFile.int_0;
			@class.ushort_0 = firstFile.ushort_0;
			@class.short_0 = firstFile.short_0;
			@class.ushort_1 = firstFile.ushort_1;
			@class.uint_3 = firstFile.uint_3;
			@class.float_2 = firstFile.float_2;
			@class.float_3 = firstFile.float_3;
			@class.int_1 = firstFile.int_1;
			@class.short_1 = firstFile.short_1;
			@class.short_2 = firstFile.short_2;
			@class.stream_0 = firstFile.stream_0;
			return @class;
		}

		private string method_14(byte[] byte_1)
		{
			int num = Array.IndexOf<byte>(byte_1, 0);
			if (num == -1)
			{
				num = byte_1.Length;
			}
			return Encoding.UTF8.GetString(byte_1, 0, num);
		}

		private FSBEnum1 method_15(uint uint_0)
		{
			switch (uint_0)
			{
			case 196608u:
				return FSBEnum1.const_2;
			case 196609u:
				return FSBEnum1.const_3;
			default:
				if (uint_0 != 262144u)
				{
					throw new Exception5("Invalid FsbFileVersion integer.");
				}
				return FSBEnum1.const_4;
			}
		}

		public void method_16(string string_0)
		{
			using (Stream stream = File.OpenWrite(string_0))
			{
				this.method_17(stream);
			}
		}

		public void method_17(Stream stream_1)
		{
			if (this.byte_0 != null)
			{
				stream_1 = new FSBClass2(stream_1, this.byte_0);
			}
			BinaryWriter binaryWriter_ = new BinaryWriter(stream_1);
			this.method_18(binaryWriter_);
			this.method_24(binaryWriter_);
			this.method_32(binaryWriter_);
		}

		private void method_18(BinaryWriter binaryWriter_0)
		{
			switch (this.enum20_0)
			{
			case FSBEnum1.const_0:
				binaryWriter_0.Write(FSBClass1.smethod_8("FSB1", 4));
				this.method_19(binaryWriter_0);
				return;
			case FSBEnum1.const_1:
				binaryWriter_0.Write(FSBClass1.smethod_8("FSB2", 4));
				this.method_20(binaryWriter_0);
				return;
			case FSBEnum1.const_2:
			case FSBEnum1.const_3:
				binaryWriter_0.Write(FSBClass1.smethod_8("FSB3", 4));
				this.method_21(binaryWriter_0);
				return;
			case FSBEnum1.const_4:
				binaryWriter_0.Write(FSBClass1.smethod_8("FSB4", 4));
				this.method_22(binaryWriter_0);
				return;
			default:
				return;
			}
		}

		private void method_19(BinaryWriter binaryWriter_0)
		{
			binaryWriter_0.Write(this.method_33().Count);
			binaryWriter_0.Write(this.method_31());
			binaryWriter_0.Write(0);
		}

		private void method_20(BinaryWriter binaryWriter_0)
		{
			binaryWriter_0.Write(this.method_33().Count);
			binaryWriter_0.Write(this.method_30());
			binaryWriter_0.Write(this.method_31());
		}

		private void method_21(BinaryWriter binaryWriter_0)
		{
			this.method_20(binaryWriter_0);
			binaryWriter_0.Write(FSBClass1.smethod_9(this.enum20_0));
			binaryWriter_0.Write((uint)this.enum21_0);
		}

		private void method_22(BinaryWriter binaryWriter_0)
		{
			this.method_21(binaryWriter_0);
			byte[] buffer = new byte[8];
			byte[] bytes = Encoding.UTF8.GetBytes("CreatedByFSBTool");
			binaryWriter_0.Write(buffer);
			binaryWriter_0.Write(bytes);
		}

		private int method_23()
		{
			switch (this.enum20_0)
			{
			case FSBEnum1.const_0:
				return 16;
			case FSBEnum1.const_1:
				return 16;
			case FSBEnum1.const_2:
			case FSBEnum1.const_3:
				return 24;
			case FSBEnum1.const_4:
				return 48;
			default:
				throw new Exception5("Invalid Fsb Version.");
			}
		}

		private void method_24(BinaryWriter binaryWriter_0)
		{
			for (int i = 0; i < this.method_33().Count; i++)
			{
				switch (this.method_0(i))
				{
				case FSBClass1.Enum23.const_0:
					this.method_25(binaryWriter_0, this.method_33()[i]);
					break;
				case FSBClass1.Enum23.const_1:
					this.method_26(binaryWriter_0, this.method_33()[i]);
					break;
				case FSBClass1.Enum23.const_2:
					this.method_28(binaryWriter_0, this.method_33()[i]);
					break;
				case FSBClass1.Enum23.const_3:
					FSBClass1.smethod_3(binaryWriter_0, this.method_33()[i]);
					break;
				}
			}
			while ((binaryWriter_0.BaseStream.Position & 15L) != 0L)
			{
				binaryWriter_0.Write(0);
			}
		}

		private void method_25(BinaryWriter binaryWriter_0, Class168 class168_0)
		{
			binaryWriter_0.Write(FSBClass1.smethod_8(class168_0.FileName, 32));
			binaryWriter_0.Write(class168_0.uint_0);
			binaryWriter_0.Write((uint)class168_0.stream_1.Length);
			binaryWriter_0.Write(class168_0.int_0);
			binaryWriter_0.Write(class168_0.ushort_1);
			binaryWriter_0.Write((ushort)class168_0.uint_3);
			binaryWriter_0.Write(class168_0.ushort_0);
			binaryWriter_0.Write(class168_0.short_0);
			binaryWriter_0.Write((uint)class168_0.enum22_0);
			binaryWriter_0.Write(class168_0.uint_1);
			binaryWriter_0.Write(class168_0.uint_2);
		}

		private void method_26(BinaryWriter binaryWriter_0, Class168 class168_0)
		{
			this.method_27(binaryWriter_0, class168_0, FSBClass1.smethod_5(class168_0));
			StreamHelper.CopyStream(binaryWriter_0.BaseStream, class168_0.stream_0);
		}

		private void method_27(BinaryWriter binaryWriter_0, Class168 class168_0, int int_0)
		{
			binaryWriter_0.Write((ushort)int_0);
			binaryWriter_0.Write(FSBClass1.smethod_8(class168_0.FileName, 30));
			binaryWriter_0.Write(class168_0.uint_0);
			binaryWriter_0.Write((uint)class168_0.stream_1.Length);
			binaryWriter_0.Write(class168_0.uint_1);
			binaryWriter_0.Write(class168_0.uint_2);
			binaryWriter_0.Write((uint)class168_0.enum22_0);
			binaryWriter_0.Write(class168_0.int_0);
			binaryWriter_0.Write(class168_0.ushort_0);
			binaryWriter_0.Write(class168_0.short_0);
			binaryWriter_0.Write(class168_0.ushort_1);
			binaryWriter_0.Write((ushort)class168_0.uint_3);
		}

		private void method_28(BinaryWriter binaryWriter_0, Class168 class168_0)
		{
			this.method_29(binaryWriter_0, class168_0, FSBClass1.smethod_6(class168_0));
			StreamHelper.CopyStream(binaryWriter_0.BaseStream, class168_0.stream_0);
		}

		private void method_29(BinaryWriter binaryWriter_0, Class168 class168_0, int int_0)
		{
			this.method_27(binaryWriter_0, class168_0, int_0);
			binaryWriter_0.Write(class168_0.float_2);
			binaryWriter_0.Write(class168_0.float_3);
			binaryWriter_0.Write(class168_0.int_1);
			binaryWriter_0.Write(class168_0.short_1);
			binaryWriter_0.Write(class168_0.short_2);
		}

		private static void smethod_3(BinaryWriter binaryWriter_0, Class168 class168_0)
		{
			binaryWriter_0.Write(class168_0.uint_0);
			binaryWriter_0.Write((uint)class168_0.stream_1.Length);
		}

		private static int smethod_4(Class168 class168_0)
		{
			return 64;
		}

		private static int smethod_5(Class168 class168_0)
		{
			return 64 + (int)class168_0.stream_0.Length;
		}

		private static int smethod_6(Class168 class168_0)
		{
			return 80 + (int)class168_0.stream_0.Length;
		}

		private static int smethod_7(Class168 class168_0)
		{
			return 8;
		}

		private int method_30()
		{
			int num = this.method_23();
			for (int i = 0; i < this.method_33().Count; i++)
			{
				switch (this.method_0(i))
				{
				case FSBClass1.Enum23.const_0:
					num += FSBClass1.smethod_4(this.method_33()[i]);
					break;
				case FSBClass1.Enum23.const_1:
					num += FSBClass1.smethod_5(this.method_33()[i]);
					break;
				case FSBClass1.Enum23.const_2:
					num += FSBClass1.smethod_6(this.method_33()[i]);
					break;
				case FSBClass1.Enum23.const_3:
					num += FSBClass1.smethod_7(this.method_33()[i]);
					break;
				}
			}
			num = (num + 15 & -16);
			return num - this.method_23();
		}

		private int method_31()
		{
			int num = 0;
			for (int i = 0; i < this.method_33().Count; i++)
			{
				num += (int)this.method_33()[i].stream_1.Length;
			}
			return num;
		}

		private static byte[] smethod_8(string string_0, int int_0)
		{
			if (int_0 < 0)
			{
				int_0 = string_0.Length + 1;
			}
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			Array.Resize<byte>(ref bytes, int_0);
			return bytes;
		}

		private static uint smethod_9(FSBEnum1 enum20_1)
		{
			switch (enum20_1)
			{
			case FSBEnum1.const_2:
				return 196608u;
			case FSBEnum1.const_3:
				return 196609u;
			case FSBEnum1.const_4:
				return 262144u;
			default:
				throw new Exception5("Invalid FsbFileVersion");
			}
		}

		private void method_32(BinaryWriter binaryWriter_0)
		{
			for (int i = 0; i < this.method_33().Count; i++)
			{
				StreamHelper.CopyStream(binaryWriter_0.BaseStream, this.method_33()[i].stream_1);
			}
		}

		public List<Class168> method_33()
		{
			return this.list_0;
		}

		private void method_34(List<Class168> list_1)
		{
			this.list_0 = list_1;
		}

		public FSBClass1()
		{
			this.method_34(new List<Class168>());
			this.enum20_0 = FSBEnum1.const_3;
			this.enum21_0 = FSBFlags1.flag_0;
		}

		public override string ToString()
		{
			string text = string.Concat(new object[]
			{
				"FsbFile:\nVersion = ",
				this.enum20_0,
				"\nFlags = ",
				this.enum21_0,
				"\nSubFiles.Count = ",
				this.method_33().Count,
				"\n"
			});
			foreach (Class168 current in this.method_33())
			{
				text += current;
			}
			return text;
		}

		~FSBClass1()
		{
			this.method_35(false);
		}

		public void Dispose()
		{
			this.method_35(true);
			GC.SuppressFinalize(this);
		}

		public void method_35(bool bool_0)
		{
			if (!bool_0)
			{
				return;
			}
			if (this.stream_0 != null)
			{
				this.stream_0.Close();
			}
			foreach (Class168 current in this.method_33())
			{
				current.Dispose();
			}
		}
	}
}
