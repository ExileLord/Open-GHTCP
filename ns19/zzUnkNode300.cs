using ns16;
using ns18;
using ns21;

namespace ns19
{
	public abstract class zzUnkNode300 : zzUnkNode294
	{
		public abstract byte vmethod_15();

		public override void vmethod_13(Stream26 stream26_0)
		{
			int_0 = stream26_0.ReadInt();
			var num = stream26_0.ReadInt();
			var num2 = stream26_0.ReadInt();
			if (num != 0)
			{
				var @class = vmethod_12(stream26_0.ReadIntAt(num, true));
				Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
			if (num2 != 0)
			{
				var class2 = (Parent is StructureHeaderNode) ? (Parent as StructureHeaderNode).method_11(stream26_0.ReadIntAt(num2)) : vmethod_12(stream26_0.ReadIntAt(num2, true));
				method_1().Nodes.Add(class2);
				class2.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			if (vmethod_8())
			{
				var array = new byte[4];
				array[1] = 1;
                array[2] = (byte)(vmethod_15() - 128);
				stream26_0.WriteByteArray(array, false);
			}
			else
			{
				var array2 = new byte[4];
				array2[1] = vmethod_15();
				stream26_0.WriteByteArray(array2, false);
			}
			stream26_0.WriteInt(int_0);
			stream26_0.WriteInt((Nodes.Count != 0) ? ((int)stream26_0.Position + 8) : 0);
			var int_ = (int)stream26_0.Position;
			stream26_0.WriteInt(0);
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_14(stream26_0);
			}
			var num = (int)stream26_0.Position;
			if (method_1().Nodes.IndexOf(this) < method_1().Nodes.Count - 1)
			{
				stream26_0.WriteIntAt(int_, num);
			}
			else
			{
				stream26_0.WriteIntAt(int_, 0);
			}
			stream26_0.Position = num;
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 16;
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_2(ref int_1);
			}
		}
	}
}
