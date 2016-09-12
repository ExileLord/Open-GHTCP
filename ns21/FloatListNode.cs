using ns16;
using ns18;
using ns19;
using ns20;
using ns22;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ns21
{
	public class FloatListNode : AbsTreeNode1_1_<FloatValueNode>
	{
		public FloatListNode()
		{
			this.vmethod_0();
		}

		public FloatListNode(bool bool_1) : this()
		{
			if (bool_1)
			{
				float[] ienumerable_ = new float[2];
				this.method_11(ienumerable_);
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
				base.Nodes.Add(new FloatValueNode(float_));
			}
			this.vmethod_0();
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			base.Nodes.Add(new FloatValueNode(stream26_0.method_21()));
			base.Nodes.Add(new FloatValueNode(stream26_0.method_21()));
			if (base.method_1() is Class290 || base.method_1() is VectorPointerRootNode || base.method_1() is VectorPointerNode)
			{
				base.Nodes.Add(new FloatValueNode(stream26_0.method_21()));
			}
			base.method_1().BackColor = Color.Gray;
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
			array[1] = 1;
			stream26_0.method_16(array, false);
			foreach (FloatValueNode class313_ in base.Nodes)
			{
				stream26_0.method_9(FloatValueNode.smethod_0(class313_));
			}
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 4 + 4 * base.Nodes.Count;
		}

		public override string GetNodeText()
		{
			return "Float List";
		}
	}
}
