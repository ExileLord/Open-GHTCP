using ns16;
using ns18;
using ns19;
using System;

namespace ns20
{
	public class TextArrayNode : AbsTreeNode1_1_<Class311>
	{
		public string this[int int_0]
		{
			get
			{
				return ((Class311)base.Nodes[int_0]).method_2();
			}
			set
			{
				((Class311)base.Nodes[int_0]).method_3(value);
			}
		}

		public TextArrayNode()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 11;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			int num = stream26_0.method_19();
			if (num == 0)
			{
				return;
			}
			if (num > 1)
			{
				stream26_0.Position = (long)stream26_0.method_19();
			}
			for (int i = 0; i < num; i++)
			{
				base.Nodes.Add(new Class311(stream26_0.method_19(), this.vmethod_10()));
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			this.vmethod_9(true);
			byte[] array = new byte[4];
			array[1] = 1;
			array[2] = 28;
			stream26_0.method_16(array, false);
			stream26_0.method_5(base.Nodes.Count);
			if (base.Nodes.Count == 0)
			{
				return;
			}
			if (base.Nodes.Count > 1)
			{
				stream26_0.method_5((int)stream26_0.Position + 4);
			}
			foreach (Class311 @class in base.Nodes)
			{
				stream26_0.method_15(@class.vmethod_8());
				if (@class.method_2() != null)
				{
					this.vmethod_10()[@class.int_0] = @class.method_2();
				}
			}
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
		}

		public override string GetNodeText()
		{
			return "Text Array";
		}
	}
}
