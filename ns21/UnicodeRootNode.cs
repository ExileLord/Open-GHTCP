using ns16;
using ns18;
using ns19;
using ns20;

namespace ns21
{
	public class UnicodeRootNode : ZzUnkNode260
	{
		public UnicodeRootNode()
		{
			vmethod_0();
		}

		public UnicodeRootNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
		{
		}

		public UnicodeRootNode(int int2)
		{
			Int0 = int2;
			vmethod_0();
		}

		public UnicodeRootNode(string string0, string string1, string string2) : this(QbSongClass1.AddKeyToDictionary(string0), QbSongClass1.AddKeyToDictionary(string1), string2)
		{
		}

		public UnicodeRootNode(int int2, int int3, string string0)
		{
			Int0 = int2;
			Int1 = int3;
			Nodes.Add(new UnicodeValueNode(string0));
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 1;
		}

		public string method_7()
		{
			if (Nodes.Count != 0)
			{
				return ((UnicodeValueNode)FirstNode).String0;
			}
			return null;
		}

		public void method_8(string string0)
		{
			if (Nodes.Count != 0)
			{
				((UnicodeValueNode)FirstNode).String0 = string0;
				return;
			}
			Nodes.Add(new UnicodeValueNode(string0));
		}

		public override void vmethod_13(Stream26 stream260)
		{
			Int0 = stream260.ReadInt();
			Int1 = stream260.ReadInt();
			var num = stream260.ReadInt();
			stream260.ReadInt();
			if (num != 0)
			{
				Nodes.Add(new UnicodeValueNode(stream260.ReadUnicodeStringAt(num)));
				stream260.Position += smethod_0(stream260.Position);
			}
		}

		public override void vmethod_14(Stream26 stream260)
		{
			var array = new byte[4];
            array[1] = (vmethod_7() ? (byte)32 : (byte)4);
			array[2] = 4;
			stream260.WriteByteArray(array, false);
			stream260.WriteInt(Int0);
			stream260.WriteInt(Int1);
			if (Nodes.Count != 0)
			{
				stream260.WriteInt((int)stream260.Position + 8);
				stream260.WriteInt(0);
				stream260.WriteString(method_7(), stream260.ReverseEndianness);
				stream260.WriteNBytes(0, 2);
				stream260.WriteNBytes(0, smethod_0(stream260.Position));
				return;
			}
			stream260.WriteNBytes(0, 8);
		}

		public override string GetNodeText()
		{
			return "Unicode Root";
		}

		public override void vmethod_2(ref int int2)
		{
			int2 += 20;
			if (Nodes.Count != 0)
			{
				((UnicodeValueNode)Nodes[0]).vmethod_2(ref int2);
				int2 += 2;
				int2 += smethod_0(int2);
			}
		}
	}
}
