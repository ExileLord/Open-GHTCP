using System.Collections.Generic;
using ns20;

namespace ns18
{
	public class FloatArrayNode : zzUnkNode278<FloatValueNode>
	{
		public float this[int int_0]
		{
			get
			{
				return ((FloatValueNode)Nodes[int_0]).float_0;
			}
			set
			{
				((FloatValueNode)Nodes[int_0]).float_0 = value;
			}
		}

		public FloatArrayNode()
		{
			vmethod_0();
		}

		public FloatArrayNode(IEnumerable<float> ienumerable_0)
		{
			method_11(ienumerable_0);
		}

		public override int vmethod_1()
		{
			return 13;
		}

		public void method_11(IEnumerable<float> ienumerable_0)
		{
			foreach (float float_ in ienumerable_0)
			{
				Nodes.Add(new FloatValueNode(float_));
			}
			vmethod_0();
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
