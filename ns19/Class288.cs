using ns16;
using ns18;
using System;
using System.Collections.Generic;

namespace ns19
{
	public abstract class Class288 : AbsTreeNode1_1
	{
		public abstract byte vmethod_15();

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
				AbstractTreeNode1 @class = this.vmethod_12(stream26_0.method_42(int_, true));
				base.Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
			array[1] = 1;
			array[2] = this.vmethod_15();
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
			int int_ = (int)stream26_0.Position;
			List<int> list = new List<int>(base.Nodes.Count);
			stream26_0.method_4(0, 4 * base.Nodes.Count);
			foreach (AbstractTreeNode1 @class in base.Nodes)
			{
				list.Add((int)stream26_0.Position);
				@class.vmethod_14(stream26_0);
			}
			int num = (int)stream26_0.Position;
			stream26_0.method_38(int_, list);
			stream26_0.Position = (long)num;
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
			foreach (AbstractTreeNode1 @class in base.Nodes)
			{
				@class.vmethod_2(ref int_0);
			}
		}
	}
}
