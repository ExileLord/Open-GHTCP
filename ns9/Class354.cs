using ns22;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns9
{
	public class Class354
	{
		public readonly List<Class353> list_0 = new List<Class353>();

		public int int_0;

		public static Class354 smethod_0(string string_0)
		{
			Class354 result;
			using (FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				result = new Class354(fileStream);
			}
			return result;
		}

		public Class354()
		{
		}

		public Class354(Stream stream_0)
		{
			this.method_3(stream_0);
		}

		public int method_0()
		{
			return this.int_0;
		}

		public void method_1(int int_1)
		{
			this.int_0 = int_1;
		}

		public List<Class353> method_2()
		{
			return this.list_0;
		}

		private void method_3(Stream stream_0)
		{
			BinaryReader binaryReader = new BinaryReader(stream_0);
			Class348.smethod_3("MIDI", binaryReader, "MThd");
			Class348.smethod_1(binaryReader.ReadUInt32());
			Class348.smethod_0(binaryReader.ReadUInt16());
			int num = (int)Class348.smethod_0(binaryReader.ReadUInt16());
			this.method_1((int)Class348.smethod_0(binaryReader.ReadUInt16()));
			this.list_0.Clear();
			for (int i = 0; i < num; i++)
			{
				Class353 @class = new Class353(this.method_0());
				this.list_0.Add(@class);
				List<Class335> list = new List<Class335>();
				Class348.smethod_3("MIDI", binaryReader, "MTrk");
				uint num2 = Class348.smethod_1(binaryReader.ReadUInt32());
				long position = binaryReader.BaseStream.Position;
				int num3 = 0;
				byte b = 0;
				while (binaryReader.BaseStream.Position < position + (long)((ulong)num2))
				{
					int num4 = (int)this.method_4(binaryReader);
					Class335 class2 = null;
					num3 += num4;
					byte b2 = binaryReader.ReadByte();
					if (b2 != 255)
					{
						byte int_;
						if ((b2 & 128) == 128)
						{
							int_ = binaryReader.ReadByte();
							b = b2;
						}
						else
						{
							int_ = b2;
							b2 = b;
						}
						byte b3 = (byte)(b2 >> 4);
						switch (b3)
						{
						case 8:
							class2 = new Class336(num3, (int)int_, binaryReader.ReadByte(), false);
							goto IL_298;
						case 9:
							class2 = new Class336(num3, (int)int_, binaryReader.ReadByte(), true);
							goto IL_298;
						case 11:
						case 12:
						case 14:
							goto IL_298;
						}
						throw new NotImplementedException(string.Format("Unhandled MIDI command: {0} at position {1}", b3.ToString("X"), binaryReader.BaseStream.Position));
					}
					byte b4 = binaryReader.ReadByte();
					long num5 = this.method_4(binaryReader);
					byte[] array = binaryReader.ReadBytes((int)num5);
					byte b5 = b4;
					if (b5 <= 47)
					{
						switch (b5)
						{
						case 1:
							class2 = new Class337(num3, Class337.Enum37.const_0, Encoding.ASCII.GetString(array));
							break;
						case 2:
							break;
						case 3:
						{
							string text = Encoding.ASCII.GetString(array).ToUpper();
							if (!string.IsNullOrEmpty(text))
							{
								@class.method_3(text);
							}
							break;
						}
						default:
							if (b5 != 47)
							{
							}
							break;
						}
					}
					else if (b5 != 81)
					{
						if (b5 == 88)
						{
							if (num5 != 4L)
							{
								Class355.interface15_0.imethod_1(string.Format("Expected time signature event to have data length of 4, but found instead {0}", num5));
							}
							class2 = new Class338(num3, (int)array[0], (int)array[1], (int)array[2], (int)array[3]);
						}
					}
					else
					{
						if (num5 != 3L)
						{
							Class355.interface15_0.imethod_1(string.Format("Expected tempo event to have data length of 3, but found instead {0}", num5));
						}
						int num6 = (int)array[0] << 16;
						num6 |= (int)array[1] << 8;
						num6 |= (int)array[2];
						class2 = new Class339(num3, num6);
					}
					IL_298:
					if (class2 != null)
					{
						list.Add(class2);
					}
				}
				list.Sort(new Comparison<Class335>(Class335.smethod_0));
				@class.method_1(list);
				binaryReader.BaseStream.Seek(position + (long)((ulong)num2), SeekOrigin.Begin);
			}
		}

		private long method_4(BinaryReader binaryReader_0)
		{
			long num = 0L;
			byte b;
			do
			{
				b = binaryReader_0.ReadByte();
				num = (num << 7) + (long)(b & 127);
			}
			while ((b & 128) != 0);
			return num;
		}
	}
}
