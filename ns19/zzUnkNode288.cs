using System.Collections.Generic;
using ns16;
using ns18;

namespace ns19
{
	public abstract class zzUnkNode288 : AbsTreeNode1_1
	{
		public abstract byte vmethod_15();

		public override void vmethod_13(Stream26 stream26_0)
		{
			int num = stream26_0.ReadInt();
			if (num == 0)
			{
				return;
			}
			int[] array = new int[num];
			if (num > 1)
			{
				stream26_0.Position = stream26_0.ReadInt();
				for (int i = 0; i < num; i++)
				{
					array[i] = stream26_0.ReadInt();
				}
			}
			else
			{
				array[0] = stream26_0.ReadInt();
			}
			int[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				int int_ = array2[j];
				AbstractTreeNode1 @class = vmethod_12(stream26_0.ReadIntAt(int_, true));
				Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
			array[1] = 1;
			array[2] = vmethod_15();
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
			int int_ = (int)stream26_0.Position;
			List<int> list = new List<int>(Nodes.Count);
			stream26_0.WriteNBytes(0, 4 * Nodes.Count);
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				list.Add((int)stream26_0.Position);
				@class.vmethod_14(stream26_0);
			}
			int num = (int)stream26_0.Position;
			stream26_0.WriteEnumerableIntsAt(int_, list);
			stream26_0.Position = num;
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
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_2(ref int_0);
			}
		}
	}
}
