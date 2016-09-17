using ns16;
using ns18;
using System;
using System.Drawing;

namespace ns19
{
	public abstract class ProbablyRootNode : zzUnkNode260
	{
		public abstract byte vmethod_16();

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.ReadInt();
			this.int_1 = stream26_0.ReadInt();
			int num = stream26_0.ReadInt();
			stream26_0.ReadInt();
			if (num != 0)
			{
				AbstractTreeNode1 @class = this.vmethod_12(stream26_0.ReadIntAt(num, true));
				base.Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
            array[1] = (this.vmethod_7() ? (byte)32 : (byte)4);
			array[2] = this.vmethod_16();
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(this.int_0);
			stream26_0.WriteInt(this.int_1);
			stream26_0.WriteInt((base.Nodes.Count != 0) ? ((int)stream26_0.Position + 8) : 0);
			stream26_0.WriteInt(0);
			foreach (AbstractTreeNode1 @class in base.Nodes)
			{
				@class.vmethod_14(stream26_0);
			}
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
			foreach (AbstractTreeNode1 @class in base.Nodes)
			{
				@class.vmethod_2(ref int_2);
			}
		}

		public override Color vmethod_15()
		{
			return base.GetColor2IfPrevNodeIsColor1(Color.Lime, Color.SpringGreen);
		}
	}
}
