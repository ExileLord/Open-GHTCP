using ns16;
using ns18;
using ns21;
using System;

namespace ns19
{
	public abstract class Class300 : zzUnkNode294
	{
		public abstract byte vmethod_15();

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.method_19();
			int num = stream26_0.method_19();
			int num2 = stream26_0.method_19();
			if (num != 0)
			{
				AbstractTreeNode1 @class = this.vmethod_12(stream26_0.method_42(num, true));
				base.Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
			if (num2 != 0)
			{
				AbstractTreeNode1 class2 = (base.Parent is StructureHeaderNode) ? (base.Parent as StructureHeaderNode).method_11(stream26_0.method_41(num2)) : this.vmethod_12(stream26_0.method_42(num2, true));
				base.method_1().Nodes.Add(class2);
				class2.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			if (this.vmethod_8())
			{
				byte[] array = new byte[4];
				array[1] = 1;
                array[2] = (byte)(this.vmethod_15() - 128);
				stream26_0.method_16(array, false);
			}
			else
			{
				byte[] array2 = new byte[4];
				array2[1] = this.vmethod_15();
				stream26_0.method_16(array2, false);
			}
			stream26_0.method_5(this.int_0);
			stream26_0.method_5((base.Nodes.Count != 0) ? ((int)stream26_0.Position + 8) : 0);
			int int_ = (int)stream26_0.Position;
			stream26_0.method_5(0);
			foreach (AbstractTreeNode1 @class in base.Nodes)
			{
				@class.vmethod_14(stream26_0);
			}
			int num = (int)stream26_0.Position;
			if (base.method_1().Nodes.IndexOf(this) < base.method_1().Nodes.Count - 1)
			{
				stream26_0.method_33(int_, num);
			}
			else
			{
				stream26_0.method_33(int_, 0);
			}
			stream26_0.Position = (long)num;
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 16;
			foreach (AbstractTreeNode1 @class in base.Nodes)
			{
				@class.vmethod_2(ref int_1);
			}
		}
	}
}
