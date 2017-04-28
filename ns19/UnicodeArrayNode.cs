using ns16;
using ns18;

namespace ns19
{
	public class UnicodeArrayNode : AbsTreeNode1_1_<UnicodeValueNode>
	{
		public string this[int int_0]
		{
			get
			{
				return ((UnicodeValueNode)Nodes[int_0]).string_0;
			}
			set
			{
				((UnicodeValueNode)Nodes[int_0]).string_0 = value;
			}
		}

		public UnicodeArrayNode()
		{
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 11;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			var num = stream26_0.ReadInt();
			if (num == 0)
			{
				return;
			}
			var array = new int[num];
			if (num > 1)
			{
				stream26_0.Position = stream26_0.ReadInt();
				for (var i = 0; i < num; i++)
				{
					array[i] = stream26_0.ReadInt();
				}
			}
			else
			{
				array[0] = stream26_0.ReadInt();
			}
			var array2 = array;
			for (var j = 0; j < array2.Length; j++)
			{
				var int_ = array2[j];
				Nodes.Add(new UnicodeValueNode(stream26_0.ReadUnicodeStringAt(int_)));
			}
			stream26_0.Position += smethod_0(stream26_0.Position);
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			var array = new byte[4];
			array[1] = 1;
			array[2] = 4;
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(Nodes.Count);
			if (Nodes.Count == 0)
			{
				return;
			}
			if (Nodes.Count > 1)
			{
				stream26_0.WriteInt((int)stream26_0.Position + 4);
			}
			var num = (int)stream26_0.Position + 4 * Nodes.Count;
			var stream = new Stream26();
			foreach (UnicodeValueNode @class in Nodes)
			{
				stream26_0.WriteInt(num);
				stream.WriteString(@class.string_0, stream26_0._reverseEndianness);
				stream.WriteNBytes(0, 2);
				num += @class.string_0.Length * 2 + 2;
			}
			stream26_0.WriteByteArray(stream.ReadEverything(), false);
			stream26_0.WriteNBytes(0, smethod_0(stream26_0.Position));
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 8;
			if (Nodes.Count == 0)
			{
				return;
			}
			if (Nodes.Count > 1)
			{
				int_0 += 4;
			}
			int_0 += 4 * Nodes.Count;
			foreach (UnicodeValueNode @class in Nodes)
			{
				@class.vmethod_2(ref int_0);
				int_0 += 2;
			}
			int_0 += smethod_0(int_0);
		}

		public override string GetNodeText()
		{
			return "Unicode Array";
		}
	}
}
