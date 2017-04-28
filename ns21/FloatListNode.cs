using System.Collections.Generic;
using System.Drawing;
using ns16;
using ns18;
using ns19;
using ns20;
using ns22;

namespace ns21
{
	public class FloatListNode : AbsTreeNode1_1_<FloatValueNode>
	{
		public FloatListNode()
		{
			vmethod_0();
		}

		public FloatListNode(bool bool_1) : this()
		{
			if (bool_1)
			{
				float[] ienumerable_ = new float[2];
				method_11(ienumerable_);
			}
		}

		public override int vmethod_1()
		{
			return 20;
		}

		public void method_11(IEnumerable<float> ienumerable_0)
		{
			foreach (float float_ in ienumerable_0)
			{
				Nodes.Add(new FloatValueNode(float_));
			}
			vmethod_0();
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			Nodes.Add(new FloatValueNode(stream26_0.ReadFloat()));
			Nodes.Add(new FloatValueNode(stream26_0.ReadFloat()));
			if (method_1() is VectorArrayNode || method_1() is VectorPointerRootNode || method_1() is VectorPointerNode)
			{
				Nodes.Add(new FloatValueNode(stream26_0.ReadFloat()));
			}
			method_1().BackColor = Color.Gray;
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
			array[1] = 1;
			stream26_0.WriteByteArray(array, false);
			foreach (FloatValueNode class313_ in Nodes)
			{
				stream26_0.WriteFloat(FloatValueNode.smethod_0(class313_));
			}
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 4 + 4 * Nodes.Count;
		}

		public override string GetNodeText()
		{
			return "Float List";
		}
	}
}
