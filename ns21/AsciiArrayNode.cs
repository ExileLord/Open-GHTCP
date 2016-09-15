using ns16;
using ns18;
using System;

namespace ns21
{
	public class AsciiArrayNode : AbsTreeNode1_1_<AsciiValueNode>
	{
		public string this[int int_0]
		{
			get
			{
				return ((AsciiValueNode)base.Nodes[int_0]).string_0;
			}
			set
			{
				((AsciiValueNode)base.Nodes[int_0]).string_0 = value;
			}
		}

		public AsciiArrayNode()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 10;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			int num = stream26_0.method_19();
			if (num == 0)
			{
				return;
			}
			int[] array = new int[num];
			if (num > 1)
			{
				stream26_0.Position = (long)stream26_0.method_19();
				for (int i = 0; i < num; i++)
				{
					array[i] = stream26_0.method_19();
				}
			}
			else
			{
				array[0] = stream26_0.method_19();
			}
			int[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				int int_ = array2[j];
				base.Nodes.Add(new AsciiValueNode(stream26_0.ReadAsciiStringAt(int_)));
			}
			stream26_0.Position += (long)AbstractTreeNode1.smethod_0(stream26_0.Position);
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
			array[1] = 1;
			array[2] = 3;
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(base.Nodes.Count);
			if (base.Nodes.Count == 0)
			{
				return;
			}
			if (base.Nodes.Count > 1)
			{
				stream26_0.WriteInt((int)stream26_0.Position + 4);
			}
			int num = (int)stream26_0.Position + 4 * base.Nodes.Count;
			Stream26 stream = new Stream26();
			foreach (AsciiValueNode @class in base.Nodes)
			{
				stream26_0.WriteInt(num);
				stream.WriteString(@class.string_0);
				stream.WriteByte2(0);
				num += @class.string_0.Length + 1;
			}
			stream26_0.WriteByteArray(stream.method_1(), false);
			stream26_0.WriteNBytes(0, AbstractTreeNode1.smethod_0(stream26_0.Position));
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 8;
			if (base.Nodes.Count == 0)
			{
				return;
			}
			if (base.Nodes.Count > 1)
			{
				int_0 += 4;
			}
			int_0 += 4 * base.Nodes.Count;
			foreach (AsciiValueNode @class in base.Nodes)
			{
				@class.vmethod_2(ref int_0);
				int_0++;
			}
			int_0 += AbstractTreeNode1.smethod_0((long)int_0);
		}

		public override string GetNodeText()
		{
			return "Ascii Array";
		}
	}
}
