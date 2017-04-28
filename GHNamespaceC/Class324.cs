using System;
using System.Collections.Generic;
using System.IO;
using GHNamespace9;

namespace GHNamespaceC
{
	public class Class324
	{
		public readonly List<Class324> List0 = new List<Class324>();

		public byte Byte0 = 10;

		public int[] Int0 = new int[0];

		public object Object0;

		public Class324()
		{
		}

		public Class324(int int1)
		{
			Int0 = new[]
			{
				int1
			};
		}

		public Class324(string string0) : this(File.OpenRead(string0))
		{
		}

		public Class324(Stream stream0)
		{
			vmethod_0(new Stream26(stream0));
		}

		public virtual void vmethod_0(Stream26 stream260)
		{
			Byte0 = stream260.ReadByte2();
			if (Byte0 != 10)
			{
				throw new Exception(string.Concat("Unknown : ", Byte0, " at position : ", stream260.Position));
			}
			Int0 = new[]
			{
				stream260.ReadInt()
			};
			while (stream260.Length > stream260.Position)
			{
				int num = stream260.ReadByte2();
				if (num == 10)
				{
					stream260.Position -= 1L;
					var @class = new Class324();
					@class.vmethod_0(stream260);
					List0.Add(@class);
				}
				else
				{
					if (num == 0)
					{
						break;
					}
					stream260.Position -= 1L;
					var class2 = new ZzStreamClass325();
					class2.vmethod_0(stream260);
					List0.Add(class2);
				}
			}
		}

		public virtual void vmethod_1(Stream26 stream260)
		{
			stream260.WriteByte2(10);
			stream260.WriteInt(Int0[0]);
			foreach (var current in List0)
			{
				current.vmethod_1(stream260);
			}
			stream260.WriteByte2(0);
		}

		public Class324 method_0(Class324 class3240)
		{
			if (class3240.Byte0 == Byte0 && class3240.Int0[0] == Int0[0] && (class3240.Object0 == null || class3240.Object0 == Object0))
			{
				return this;
			}
			foreach (var current in List0)
			{
				var @class = current.method_0(class3240);
				if (@class != null)
				{
					return @class;
				}
			}
			return null;
		}

		public void method_1(string string0)
		{
			using (var stream = new Stream26(File.Create(string0 + "\\s000.d")))
			{
				vmethod_1(stream);
				stream.WriteByte2(0);
				using (var stream2 = new Stream26(File.Create(string0 + "\\toc.dat")))
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
					var num = KeyGenerator.GetQbKey(stream2, true);
					stream2.Position = 0L;
					stream2.WriteInt(num);
					stream.Position = stream.Length;
					stream.WriteNBytes(0, 5242880 - (int)stream.Length);
				}
			}
		}
	}
}
