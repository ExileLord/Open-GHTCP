using ns16;
using ns21;

namespace ns18
{
	public class AsciiRootNode : zzUnkNode260
	{
		public AsciiRootNode()
		{
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 0;
		}

		public string method_7()
		{
			if (Nodes.Count != 0)
			{
				return ((AsciiValueNode)FirstNode).string_0;
			}
			return null;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			int_0 = stream26_0.ReadInt();
			int_1 = stream26_0.ReadInt();
			var num = stream26_0.ReadInt();
			stream26_0.ReadInt();
			if (num != 0)
			{
				Nodes.Add(new AsciiValueNode(stream26_0.ReadAsciiStringAt(num)));
				stream26_0.Position += smethod_0(stream26_0.Position);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			var array = new byte[4];
            array[1] = (vmethod_7() ? (byte)32 : (byte)4);
			array[2] = 3;
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(int_0);
			stream26_0.WriteInt(int_1);
			if (Nodes.Count != 0)
			{
				stream26_0.WriteInt((int)stream26_0.Position + 8);
				stream26_0.WriteInt(0);
				stream26_0.WriteString(method_7());
				stream26_0.WriteByte2(0);
				stream26_0.WriteNBytes(0, smethod_0(stream26_0.Position));
				return;
			}
			stream26_0.WriteNBytes(0, 8);
		}

		public override string GetNodeText()
		{
			return "Ascii Root";
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
			if (Nodes.Count != 0)
			{
				((AsciiValueNode)Nodes[0]).vmethod_2(ref int_2);
				int_2++;
				int_2 += smethod_0(int_2);
			}
		}
	}
}
