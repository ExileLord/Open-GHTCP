using ns16;
using ns18;
using ns19;
using ns20;
using System;

namespace ns21
{
	public class UnicodeRootNode : zzUnkNode260
	{
		public UnicodeRootNode()
		{
			this.vmethod_0();
		}

		public UnicodeRootNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public UnicodeRootNode(int int_2)
		{
			this.int_0 = int_2;
			this.vmethod_0();
		}

		public UnicodeRootNode(string string_0, string string_1, string string_2) : this(QbSongClass1.AddKeyToDictionary(string_0), QbSongClass1.AddKeyToDictionary(string_1), string_2)
		{
		}

		public UnicodeRootNode(int int_2, int int_3, string string_0)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			base.Nodes.Add(new UnicodeValueNode(string_0));
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 1;
		}

		public string method_7()
		{
			if (base.Nodes.Count != 0)
			{
				return ((UnicodeValueNode)base.FirstNode).string_0;
			}
			return null;
		}

		public void method_8(string string_0)
		{
			if (base.Nodes.Count != 0)
			{
				((UnicodeValueNode)base.FirstNode).string_0 = string_0;
				return;
			}
			base.Nodes.Add(new UnicodeValueNode(string_0));
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.ReadInt();
			this.int_1 = stream26_0.ReadInt();
			int num = stream26_0.ReadInt();
			stream26_0.ReadInt();
			if (num != 0)
			{
				base.Nodes.Add(new UnicodeValueNode(stream26_0.ReadUnicodeStringAt(num)));
				stream26_0.Position += (long)AbstractTreeNode1.smethod_0(stream26_0.Position);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
            array[1] = (this.vmethod_7() ? (byte)32 : (byte)4);
			array[2] = 4;
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(this.int_0);
			stream26_0.WriteInt(this.int_1);
			if (base.Nodes.Count != 0)
			{
				stream26_0.WriteInt((int)stream26_0.Position + 8);
				stream26_0.WriteInt(0);
				stream26_0.WriteString(this.method_7(), stream26_0._reverseEndianness);
				stream26_0.WriteNBytes(0, 2);
				stream26_0.WriteNBytes(0, AbstractTreeNode1.smethod_0(stream26_0.Position));
				return;
			}
			stream26_0.WriteNBytes(0, 8);
		}

		public override string GetNodeText()
		{
			return "Unicode Root";
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
			if (base.Nodes.Count != 0)
			{
				((UnicodeValueNode)base.Nodes[0]).vmethod_2(ref int_2);
				int_2 += 2;
				int_2 += AbstractTreeNode1.smethod_0((long)int_2);
			}
		}
	}
}
