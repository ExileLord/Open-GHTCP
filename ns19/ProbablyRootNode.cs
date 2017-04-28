using System.Drawing;
using ns16;
using ns18;

namespace ns19
{
	public abstract class ProbablyRootNode : zzUnkNode260
	{
		public abstract byte vmethod_16();

		public override void vmethod_13(Stream26 stream26_0)
		{
			int_0 = stream26_0.ReadInt();
			int_1 = stream26_0.ReadInt();
			var num = stream26_0.ReadInt();
			stream26_0.ReadInt();
			if (num != 0)
			{
				var @class = vmethod_12(stream26_0.ReadIntAt(num, true));
				Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			var array = new byte[4];
            array[1] = (vmethod_7() ? (byte)32 : (byte)4);
			array[2] = vmethod_16();
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(int_0);
			stream26_0.WriteInt(int_1);
			stream26_0.WriteInt((Nodes.Count != 0) ? ((int)stream26_0.Position + 8) : 0);
			stream26_0.WriteInt(0);
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_14(stream26_0);
			}
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_2(ref int_2);
			}
		}

		public override Color vmethod_15()
		{
			return GetColor2IfPrevNodeIsColor1(Color.Lime, Color.SpringGreen);
		}
	}
}
