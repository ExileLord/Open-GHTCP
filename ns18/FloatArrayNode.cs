using ns20;
using System;
using System.Collections.Generic;

namespace ns18
{
	public class FloatArrayNode : zzUnkNode278<FloatValueNode>
	{
		public float this[int int_0]
		{
			get
			{
				return ((FloatValueNode)base.Nodes[int_0]).float_0;
			}
			set
			{
				((FloatValueNode)base.Nodes[int_0]).float_0 = value;
			}
		}

		public FloatArrayNode()
		{
			this.vmethod_0();
		}

		public FloatArrayNode(IEnumerable<float> ienumerable_0)
		{
			this.method_11(ienumerable_0);
		}

		public override int vmethod_1()
		{
			return 13;
		}

		public void method_11(IEnumerable<float> ienumerable_0)
		{
			foreach (float float_ in ienumerable_0)
			{
				base.Nodes.Add(new FloatValueNode(float_));
			}
			this.vmethod_0();
		}

		public override byte vmethod_15()
		{
			return 2;
		}

		public override string GetNodeText()
		{
			return "Float Array";
		}
	}
}
