using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns8
{
	public class FsbClass1 : IDisposable
	{
		private enum Enum23
		{
			Const0,
			Const1,
			Const2,
			Const3
		}

		private List<Class168> _list0;

		public FsbEnum1 Enum200;

		public FsbFlags1 Enum210;

		public byte[] Byte0;

		private Stream _stream0;

		private Enum23 method_0(int int0)
		{
			if (Enum200 == FsbEnum1.Const0)
			{
				return Enum23.Const0;
			}
			if (Enum200 == FsbEnum1.Const1)
			{
				return Enum23.Const1;
			}
			if ((Enum210 & FsbFlags1.Flag2) != FsbFlags1.Flag0 && int0 != 0)
			{
				return Enum23.Const3;
			}
			if (Enum200 == FsbEnum1.Const2)
			{
				return Enum23.Const1;
			}
			if (Enum200 != FsbEnum1.Const3)
			{
				if (Enum200 != FsbEnum1.Const4)
				{
					throw new Exception5("Unknown version \"" + Enum200 + "\"");
				}
			}
			return Enum23.Const2;
		}

		public static FsbClass1 smethod_0(Stream stream1)
		{
			var @class = new FsbClass1();
			var position = stream1.Position;
			try
			{
				@class.method_1(stream1);
			}
			catch
			{
				stream1.Position = position;
				var stream = new FsbClass2(stream1);
				@class = new FsbClass1();
				@class.method_1(stream);
				@class.Byte0 = stream.Byte0;
			}
			@class._stream0 = stream1;
			return @class;
		}

		public static FsbClass1 smethod_1(Stream stream1, byte[] byte1)
		{
			var @class = new FsbClass1();
			@class.method_1(new FsbClass2(stream1, byte1));
			@class.Byte0 = byte1;
			@class._stream0 = stream1;
			return @class;
		}

		private void method_1(Stream stream1)
		{
			var binaryReader = new BinaryReader(stream1);
			int int_;
			long long_;
			uint num;
			method_2(binaryReader, out int_, out long_, out num);
			method_7(binaryReader, int_, long_);
		}

		private void method_2(BinaryReader inputBin, out int numSubFiles, out long dataOffset, out uint allDataSize)
		{
			var @string = Encoding.UTF8.GetString(inputBin.ReadBytes(4));
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
							method_6(inputBin, out numSubFiles, out num, out allDataSize);
						}
						else
						{
							method_5(inputBin, out numSubFiles, out num, out allDataSize);
						}
					}
					else
					{
						method_4(inputBin, out numSubFiles, out num, out allDataSize);
					}
				}
				else
				{
					method_3(inputBin, out numSubFiles, out num, out allDataSize);
				}
				dataOffset = inputBin.BaseStream.Position + num;
				return;
			}
			IL_83:
			throw new Exception5("Invalid Fsb version magic string.");
		}

		private void method_3(BinaryReader inputBin, out int numSubFiles, out uint subFileHdrsSize, out uint allDataSize)
		{
			Enum200 = FsbEnum1.Const0;
			allDataSize = inputBin.ReadUInt32();
			numSubFiles = inputBin.ReadInt32();
			inputBin.ReadInt32();
			Enum210 = FsbFlags1.Flag0;
			subFileHdrsSize = (uint)(numSubFiles * 64);
		}

		private void method_4(BinaryReader inputBin, out int numSubFiles, out uint subFileHdrsSize, out uint allDataSize)
		{
			Enum200 = FsbEnum1.Const1;
			numSubFiles = inputBin.ReadInt32();
			subFileHdrsSize = inputBin.ReadUInt32();
			allDataSize = inputBin.ReadUInt32();
		}

		private void method_5(BinaryReader inputBin, out int numSubFiles, out uint subFileHdrsSize, out uint allDataSize)
		{
			method_4(inputBin, out numSubFiles, out subFileHdrsSize, out allDataSize);
			Enum200 = method_15(inputBin.ReadUInt32());
			Enum210 = (FsbFlags1)inputBin.ReadUInt32();
		}

		private void method_6(BinaryReader inputBin, out int numSubFiles, out uint subFileHdrsSize, out uint allDataSize)
		{
			method_5(inputBin, out numSubFiles, out subFileHdrsSize, out allDataSize);
			inputBin.ReadBytes(8);
			inputBin.ReadBytes(16);
		}

		private void method_7(BinaryReader binaryReader0, int int0, long long0)
		{
			var num = long0;
			for (var i = 0; i < int0; i++)
			{
				Class168 @class = null;
				var num2 = 0u;
				switch (method_0(i))
				{
				case Enum23.Const0:
					@class = method_8(binaryReader0, out num2);
					break;
				case Enum23.Const1:
					@class = method_9(binaryReader0, out num2);
					break;
				case Enum23.Const2:
					@class = method_12(binaryReader0, out num2);
					break;
				case Enum23.Const3:
					@class = smethod_2(binaryReader0, out num2, method_33()[0]);
					break;
				}
				method_33().Add(@class);
				@class.Stream1 = new Stream18(binaryReader0.BaseStream, num, num2);
				num += num2;
			}
		}

		private Class168 method_8(BinaryReader inputBin, out uint dataSize)
		{
			var @class = new Class168();
			@class.FileName = method_14(inputBin.ReadBytes(32));
			@class.Uint0 = inputBin.ReadUInt32();
			dataSize = inputBin.ReadUInt32();
			@class.Int0 = inputBin.ReadInt32();
			@class.Ushort1 = inputBin.ReadUInt16();
			@class.Uint3 = inputBin.ReadUInt16();
			@class.Ushort0 = inputBin.ReadUInt16();
			@class.Short0 = inputBin.ReadInt16();
			@class.Enum220 = (FsbFlags2)inputBin.ReadUInt32();
			@class.Uint1 = inputBin.ReadUInt32();
			@class.Uint2 = inputBin.ReadUInt32();
			return @class;
		}

		private Class168 method_9(BinaryReader inputBin, out uint dataSize)
		{
			uint num;
			var @class = method_10(inputBin, out dataSize, out num);
			method_11(inputBin, @class, num - 64u);
			return @class;
		}

		private Class168 method_10(BinaryReader inputBin, out uint dataSize, out uint hdrSize)
		{
			var @class = new Class168();
			hdrSize = inputBin.ReadUInt16();
			@class.FileName = method_14(inputBin.ReadBytes(30));
			@class.Uint0 = inputBin.ReadUInt32();
			dataSize = inputBin.ReadUInt32();
			@class.Uint1 = inputBin.ReadUInt32();
			@class.Uint2 = inputBin.ReadUInt32();
			@class.Enum220 = (FsbFlags2)inputBin.ReadUInt32();
			@class.Int0 = inputBin.ReadInt32();
			@class.Ushort0 = inputBin.ReadUInt16();
			@class.Short0 = inputBin.ReadInt16();
			@class.Ushort1 = inputBin.ReadUInt16();
			@class.Uint3 = inputBin.ReadUInt16();
			return @class;
		}

		private void method_11(BinaryReader binaryReader0, Class168 class1680, uint uint0)
		{
			class1680.Stream0 = new Stream18(binaryReader0.BaseStream, binaryReader0.BaseStream.Position, uint0);
		}

		private Class168 method_12(BinaryReader inputBin, out uint dataSize)
		{
			uint num;
			var @class = method_13(inputBin, out dataSize, out num);
			method_11(inputBin, @class, num - 80u);
			return @class;
		}

		private Class168 method_13(BinaryReader inputBin, out uint dataSize, out uint hdrSize)
		{
			var @class = method_10(inputBin, out dataSize, out hdrSize);
			@class.Float2 = inputBin.ReadSingle();
			@class.Float3 = inputBin.ReadSingle();
			Console.WriteLine(inputBin.BaseStream.Position);
			@class.Int1 = inputBin.ReadInt32();
			Console.WriteLine(@class.Int1);
			@class.Short1 = inputBin.ReadInt16();
			@class.Short2 = inputBin.ReadInt16();
			return @class;
		}

		private static Class168 smethod_2(BinaryReader inputBin, out uint dataSize, Class168 firstFile)
		{
			var @class = new Class168();
			@class.Uint0 = inputBin.ReadUInt32();
			dataSize = inputBin.ReadUInt32();
			Console.WriteLine(inputBin.BaseStream.Position);
			@class.FileName = firstFile.FileName;
			@class.Uint1 = firstFile.Uint1;
			@class.Uint2 = firstFile.Uint2;
			@class.Enum220 = firstFile.Enum220;
			@class.Int0 = firstFile.Int0;
			@class.Ushort0 = firstFile.Ushort0;
			@class.Short0 = firstFile.Short0;
			@class.Ushort1 = firstFile.Ushort1;
			@class.Uint3 = firstFile.Uint3;
			@class.Float2 = firstFile.Float2;
			@class.Float3 = firstFile.Float3;
			@class.Int1 = firstFile.Int1;
			@class.Short1 = firstFile.Short1;
			@class.Short2 = firstFile.Short2;
			@class.Stream0 = firstFile.Stream0;
			return @class;
		}

		private string method_14(byte[] byte1)
		{
			var num = Array.IndexOf<byte>(byte1, 0);
			if (num == -1)
			{
				num = byte1.Length;
			}
			return Encoding.UTF8.GetString(byte1, 0, num);
		}

		private FsbEnum1 method_15(uint uint0)
		{
			switch (uint0)
			{
			case 196608u:
				return FsbEnum1.Const2;
			case 196609u:
				return FsbEnum1.Const3;
			default:
				if (uint0 != 262144u)
				{
					throw new Exception5("Invalid FsbFileVersion integer.");
				}
				return FsbEnum1.Const4;
			}
		}

		public void method_16(string string0)
		{
			using (Stream stream = File.OpenWrite(string0))
			{
				method_17(stream);
			}
		}

		public void method_17(Stream stream1)
		{
			if (Byte0 != null)
			{
				stream1 = new FsbClass2(stream1, Byte0);
			}
			var binaryWriter = new BinaryWriter(stream1);
			method_18(binaryWriter);
			method_24(binaryWriter);
			method_32(binaryWriter);
		}

		private void method_18(BinaryWriter binaryWriter0)
		{
			switch (Enum200)
			{
			case FsbEnum1.Const0:
				binaryWriter0.Write(smethod_8("FSB1", 4));
				method_19(binaryWriter0);
				return;
			case FsbEnum1.Const1:
				binaryWriter0.Write(smethod_8("FSB2", 4));
				method_20(binaryWriter0);
				return;
			case FsbEnum1.Const2:
			case FsbEnum1.Const3:
				binaryWriter0.Write(smethod_8("FSB3", 4));
				method_21(binaryWriter0);
				return;
			case FsbEnum1.Const4:
				binaryWriter0.Write(smethod_8("FSB4", 4));
				method_22(binaryWriter0);
				return;
			default:
				return;
			}
		}

		private void method_19(BinaryWriter binaryWriter0)
		{
			binaryWriter0.Write(method_33().Count);
			binaryWriter0.Write(method_31());
			binaryWriter0.Write(0);
		}

		private void method_20(BinaryWriter binaryWriter0)
		{
			binaryWriter0.Write(method_33().Count);
			binaryWriter0.Write(method_30());
			binaryWriter0.Write(method_31());
		}

		private void method_21(BinaryWriter binaryWriter0)
		{
			method_20(binaryWriter0);
			binaryWriter0.Write(smethod_9(Enum200));
			binaryWriter0.Write((uint)Enum210);
		}

		private void method_22(BinaryWriter binaryWriter0)
		{
			method_21(binaryWriter0);
			var buffer = new byte[8];
			var bytes = Encoding.UTF8.GetBytes("CreatedByFSBTool");
			binaryWriter0.Write(buffer);
			binaryWriter0.Write(bytes);
		}

		private int method_23()
		{
			switch (Enum200)
			{
			case FsbEnum1.Const0:
				return 16;
			case FsbEnum1.Const1:
				return 16;
			case FsbEnum1.Const2:
			case FsbEnum1.Const3:
				return 24;
			case FsbEnum1.Const4:
				return 48;
			default:
				throw new Exception5("Invalid Fsb Version.");
			}
		}

		private void method_24(BinaryWriter binaryWriter0)
		{
			for (var i = 0; i < method_33().Count; i++)
			{
				switch (method_0(i))
				{
				case Enum23.Const0:
					method_25(binaryWriter0, method_33()[i]);
					break;
				case Enum23.Const1:
					method_26(binaryWriter0, method_33()[i]);
					break;
				case Enum23.Const2:
					method_28(binaryWriter0, method_33()[i]);
					break;
				case Enum23.Const3:
					smethod_3(binaryWriter0, method_33()[i]);
					break;
				}
			}
			while ((binaryWriter0.BaseStream.Position & 15L) != 0L)
			{
				binaryWriter0.Write(0);
			}
		}

		private void method_25(BinaryWriter binaryWriter0, Class168 class1680)
		{
			binaryWriter0.Write(smethod_8(class1680.FileName, 32));
			binaryWriter0.Write(class1680.Uint0);
			binaryWriter0.Write((uint)class1680.Stream1.Length);
			binaryWriter0.Write(class1680.Int0);
			binaryWriter0.Write(class1680.Ushort1);
			binaryWriter0.Write((ushort)class1680.Uint3);
			binaryWriter0.Write(class1680.Ushort0);
			binaryWriter0.Write(class1680.Short0);
			binaryWriter0.Write((uint)class1680.Enum220);
			binaryWriter0.Write(class1680.Uint1);
			binaryWriter0.Write(class1680.Uint2);
		}

		private void method_26(BinaryWriter binaryWriter0, Class168 class1680)
		{
			method_27(binaryWriter0, class1680, smethod_5(class1680));
			StreamHelper.CopyStream(binaryWriter0.BaseStream, class1680.Stream0);
		}

		private void method_27(BinaryWriter binaryWriter0, Class168 class1680, int int0)
		{
			binaryWriter0.Write((ushort)int0);
			binaryWriter0.Write(smethod_8(class1680.FileName, 30));
			binaryWriter0.Write(class1680.Uint0);
			binaryWriter0.Write((uint)class1680.Stream1.Length);
			binaryWriter0.Write(class1680.Uint1);
			binaryWriter0.Write(class1680.Uint2);
			binaryWriter0.Write((uint)class1680.Enum220);
			binaryWriter0.Write(class1680.Int0);
			binaryWriter0.Write(class1680.Ushort0);
			binaryWriter0.Write(class1680.Short0);
			binaryWriter0.Write(class1680.Ushort1);
			binaryWriter0.Write((ushort)class1680.Uint3);
		}

		private void method_28(BinaryWriter binaryWriter0, Class168 class1680)
		{
			method_29(binaryWriter0, class1680, smethod_6(class1680));
			StreamHelper.CopyStream(binaryWriter0.BaseStream, class1680.Stream0);
		}

		private void method_29(BinaryWriter binaryWriter0, Class168 class1680, int int0)
		{
			method_27(binaryWriter0, class1680, int0);
			binaryWriter0.Write(class1680.Float2);
			binaryWriter0.Write(class1680.Float3);
			binaryWriter0.Write(class1680.Int1);
			binaryWriter0.Write(class1680.Short1);
			binaryWriter0.Write(class1680.Short2);
		}

		private static void smethod_3(BinaryWriter binaryWriter0, Class168 class1680)
		{
			binaryWriter0.Write(class1680.Uint0);
			binaryWriter0.Write((uint)class1680.Stream1.Length);
		}

		private static int smethod_4(Class168 class1680)
		{
			return 64;
		}

		private static int smethod_5(Class168 class1680)
		{
			return 64 + (int)class1680.Stream0.Length;
		}

		private static int smethod_6(Class168 class1680)
		{
			return 80 + (int)class1680.Stream0.Length;
		}

		private static int smethod_7(Class168 class1680)
		{
			return 8;
		}

		private int method_30()
		{
			var num = method_23();
			for (var i = 0; i < method_33().Count; i++)
			{
				switch (method_0(i))
				{
				case Enum23.Const0:
					num += smethod_4(method_33()[i]);
					break;
				case Enum23.Const1:
					num += smethod_5(method_33()[i]);
					break;
				case Enum23.Const2:
					num += smethod_6(method_33()[i]);
					break;
				case Enum23.Const3:
					num += smethod_7(method_33()[i]);
					break;
				}
			}
			num = (num + 15 & -16);
			return num - method_23();
		}

		private int method_31()
		{
			var num = 0;
			for (var i = 0; i < method_33().Count; i++)
			{
				num += (int)method_33()[i].Stream1.Length;
			}
			return num;
		}

		private static byte[] smethod_8(string string0, int int0)
		{
			if (int0 < 0)
			{
				int0 = string0.Length + 1;
			}
			var bytes = Encoding.UTF8.GetBytes(string0);
			Array.Resize(ref bytes, int0);
			return bytes;
		}

		private static uint smethod_9(FsbEnum1 enum201)
		{
			switch (enum201)
			{
			case FsbEnum1.Const2:
				return 196608u;
			case FsbEnum1.Const3:
				return 196609u;
			case FsbEnum1.Const4:
				return 262144u;
			default:
				throw new Exception5("Invalid FsbFileVersion");
			}
		}

		private void method_32(BinaryWriter binaryWriter0)
		{
			for (var i = 0; i < method_33().Count; i++)
			{
				StreamHelper.CopyStream(binaryWriter0.BaseStream, method_33()[i].Stream1);
			}
		}

		public List<Class168> method_33()
		{
			return _list0;
		}

		private void method_34(List<Class168> list1)
		{
			_list0 = list1;
		}

		public FsbClass1()
		{
			method_34(new List<Class168>());
			Enum200 = FsbEnum1.Const3;
			Enum210 = FsbFlags1.Flag0;
		}

		public override string ToString()
		{
			var text = string.Concat("FsbFile:\nVersion = ", Enum200, "\nFlags = ", Enum210, "\nSubFiles.Count = ", method_33().Count, "\n");
			foreach (var current in method_33())
			{
				text += current;
			}
			return text;
		}

		~FsbClass1()
		{
			method_35(false);
		}

		public void Dispose()
		{
			method_35(true);
			GC.SuppressFinalize(this);
		}

		public void method_35(bool bool0)
		{
			if (!bool0)
			{
				return;
			}
			if (_stream0 != null)
			{
				_stream0.Close();
			}
			foreach (var current in method_33())
			{
				current.Dispose();
			}
		}
	}
}
