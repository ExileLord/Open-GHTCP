using System;
using System.Collections.Generic;
using System.IO;
using ns16;

namespace ns19
{
	public class Class324
	{
		public readonly List<Class324> list_0 = new List<Class324>();

		public byte byte_0 = 10;

		public int[] int_0 = new int[0];

		public object object_0;

		public Class324()
		{
		}

		public Class324(int int_1)
		{
			int_0 = new[]
			{
				int_1
			};
		}

		public Class324(string string_0) : this(File.OpenRead(string_0))
		{
		}

		public Class324(Stream stream_0)
		{
			vmethod_0(new Stream26(stream_0));
		}

		public virtual void vmethod_0(Stream26 stream26_0)
		{
			byte_0 = stream26_0.ReadByte2();
			if (byte_0 != 10)
			{
				throw new Exception(string.Concat("Unknown : ", byte_0, " at position : ", stream26_0.Position));
			}
			int_0 = new[]
			{
				stream26_0.ReadInt()
			};
			while (stream26_0.Length > stream26_0.Position)
			{
				int num = stream26_0.ReadByte2();
				if (num == 10)
				{
					stream26_0.Position -= 1L;
					Class324 @class = new Class324();
					@class.vmethod_0(stream26_0);
					list_0.Add(@class);
				}
				else
				{
					if (num == 0)
					{
						break;
					}
					stream26_0.Position -= 1L;
					zzStreamClass325 class2 = new zzStreamClass325();
					class2.vmethod_0(stream26_0);
					list_0.Add(class2);
				}
			}
		}

		public virtual void vmethod_1(Stream26 stream26_0)
		{
			stream26_0.WriteByte2(10);
			stream26_0.WriteInt(int_0[0]);
			foreach (Class324 current in list_0)
			{
				current.vmethod_1(stream26_0);
			}
			stream26_0.WriteByte2(0);
		}

		public Class324 method_0(Class324 class324_0)
		{
			if (class324_0.byte_0 == byte_0 && class324_0.int_0[0] == int_0[0] && (class324_0.object_0 == null || class324_0.object_0 == object_0))
			{
				return this;
			}
			foreach (Class324 current in list_0)
			{
				Class324 @class = current.method_0(class324_0);
				if (@class != null)
				{
					return @class;
				}
			}
			return null;
		}

		public void method_1(string string_0)
		{
			using (Stream26 stream = new Stream26(File.Create(string_0 + "\\s000.d")))
			{
				vmethod_1(stream);
				stream.WriteByte2(0);
				using (Stream26 stream2 = new Stream26(File.Create(string_0 + "\\toc.dat")))
				{
					stream2.WriteInt(0);
					stream2.WriteByte2(4);
					stream2.WriteByte2(0);
					stream2.WriteByte2(0);
					stream2.WriteByte2(0);
					stream2.WriteUInt(3724414393u);
					stream2.WriteString("GH3Progress");
					stream2.WriteNBytes(0, 7);
					stream2.WriteByte2(48);
					stream2.WriteByte2(0);
					stream2.WriteInt((int)stream.Length);
					stream.Position = 0L;
					stream2.WriteInt(KeyGenerator.GetQbKey(stream, true));
					stream2.WriteNBytes(0, 40);
					stream2.WriteByte2(Convert.ToByte(DateTime.Now.Minute));
					stream2.WriteByte2(0);
					stream2.WriteShort((short)DateTime.Now.Year);
					stream2.WriteByte2(Convert.ToByte(DateTime.Now.Second));
					stream2.WriteByte2(Convert.ToByte(DateTime.Now.Month - 1));
					stream2.WriteByte2(Convert.ToByte(DateTime.Now.Day));
					stream2.WriteByte2(Convert.ToByte(DateTime.Now.Hour));
					stream2.WriteNBytes(0, 15120);
					stream2.WriteInt(756937245);
					stream2.WriteNBytes(0, 12);
					stream2.Position = 4L;
					int num = KeyGenerator.GetQbKey(stream2, true);
					stream2.Position = 0L;
					stream2.WriteInt(num);
					stream.Position = stream.Length;
					stream.WriteNBytes(0, 5242880 - (int)stream.Length);
				}
			}
		}
	}
}
