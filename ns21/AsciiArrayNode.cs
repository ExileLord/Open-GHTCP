using ns16;
using ns18;

namespace ns21
{
	public class AsciiArrayNode : AbsTreeNode1_1_<AsciiValueNode>
	{
		public string this[int int_0]
		{
			get
			{
				return ((AsciiValueNode)Nodes[int_0]).string_0;
			}
			set
			{
				((AsciiValueNode)Nodes[int_0]).string_0 = value;
			}
		}

		public AsciiArrayNode()
		{
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 10;
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
				Nodes.Add(new AsciiValueNode(stream26_0.ReadAsciiStringAt(int_)));
			}
			stream26_0.Position += smethod_0(stream26_0.Position);
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			var array = new byte[4];
			array[1] = 1;
			array[2] = 3;
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
			foreach (AsciiValueNode @class in Nodes)
			{
				stream26_0.WriteInt(num);
				stream.WriteString(@class.string_0);
				stream.WriteByte2(0);
				num += @class.string_0.Length + 1;
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
			foreach (AsciiValueNode @class in Nodes)
			{
				@class.vmethod_2(ref int_0);
				int_0++;
			}
			int_0 += smethod_0(int_0);
		}

		public override string GetNodeText()
		{
			return "Ascii Array";
		}
	}
}
