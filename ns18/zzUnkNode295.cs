using System;
using System.Collections;
using ns16;
using ns20;
using ns21;

namespace ns18
{
	public abstract class zzUnkNode295 : zzUnkNode294
	{
		public abstract byte vmethod_15();

		public override void vmethod_13(Stream26 stream26_0)
		{
			int_0 = stream26_0.ReadInt();
			if (this is FloatStructureNode)
			{
				Nodes.Add(new FloatValueNode(stream26_0.ReadFloat()));
			}
			else if (this is IntegerStructureNode)
			{
				Nodes.Add(new IntegerValueNode(stream26_0.ReadInt()));
			}
			else if (this is TagStructureNode || this is FileTagStructureNode)
			{
				Nodes.Add(new TagValueNode(stream26_0.ReadInt()));
			}
			int num = stream26_0.ReadInt();
			if (num != 0)
			{
				AbstractTreeNode1 @class = (Parent is StructureHeaderNode) ? (Parent as StructureHeaderNode).method_11(stream26_0.ReadIntAt(num)) : vmethod_12(stream26_0.ReadIntAt(num, true));
				method_1().Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			if (vmethod_8())
			{
				byte[] array = new byte[4];
				array[1] = 1;
                array[2] = (byte)(vmethod_15() - 128);
				stream26_0.WriteByteArray(array, false);
			}
			else
			{
				byte[] array2 = new byte[4];
				array2[1] = vmethod_15();
				stream26_0.WriteByteArray(array2, false);
			}
			stream26_0.WriteInt(int_0);
			if (Nodes.Count != 0)
			{
				IEnumerator enumerator = Nodes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						AbstractTreeNode2 @class = (AbstractTreeNode2)enumerator.Current;
						stream26_0.WriteByteArray(@class.vmethod_8());
					}
					goto IL_AA;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			stream26_0.WriteInt(0);
			IL_AA:
			if (method_1().Nodes.IndexOf(this) < method_1().Nodes.Count - 1)
			{
				stream26_0.WriteInt((int)stream26_0.Position + 4);
				return;
			}
			stream26_0.WriteInt(0);
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 16;
		}
	}
}
