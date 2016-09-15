using ns16;
using ns20;
using ns21;
using System;

namespace ns18
{
	public abstract class zzUnkNode278<T> : AbsTreeNode1_1_<T> where T : AbstractBaseTreeNode1
	{
		public abstract byte vmethod_15();

		public override void vmethod_13(Stream26 stream26_0)
		{
			int num = stream26_0.ReadInt();
			if (num == 0)
			{
				return;
			}
			if (num > 1)
			{
				stream26_0.Position = (long)stream26_0.ReadInt();
			}
			if (this is FloatArrayNode)
			{
				for (int i = 0; i < num; i++)
				{
					base.Nodes.Add(new FloatValueNode(stream26_0.ReadFloat()));
				}
				return;
			}
			if (this is IntegerArrayNode)
			{
				for (int j = 0; j < num; j++)
				{
					base.Nodes.Add(new IntegerValueNode(stream26_0.ReadInt()));
				}
				return;
			}
			if (this is TagArray || this is FileTagArrayNode)
			{
				for (int k = 0; k < num; k++)
				{
					base.Nodes.Add(new TagValueNode(stream26_0.ReadInt()));
				}
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
			array[1] = 1;
			array[2] = this.vmethod_15();
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
			foreach (AbstractTreeNode2 @class in base.Nodes)
			{
				stream26_0.WriteByteArray(@class.vmethod_8());
			}
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 8;
			if (base.Nodes.Count > 1)
			{
				int_0 += 4;
			}
			int_0 += 4 * base.Nodes.Count;
		}
	}
}
