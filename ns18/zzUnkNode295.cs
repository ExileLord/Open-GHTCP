using ns16;
using ns20;
using ns21;
using System;
using System.Collections;

namespace ns18
{
	public abstract class zzUnkNode295 : zzUnkNode294
	{
		public abstract byte vmethod_15();

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.ReadInt();
			if (this is FloatStructureNode)
			{
				base.Nodes.Add(new FloatValueNode(stream26_0.ReadFloat()));
			}
			else if (this is IntegerStructureNode)
			{
				base.Nodes.Add(new IntegerValueNode(stream26_0.ReadInt()));
			}
			else if (this is TagStructureNode || this is FileTagStructureNode)
			{
				base.Nodes.Add(new TagValueNode(stream26_0.ReadInt()));
			}
			int num = stream26_0.ReadInt();
			if (num != 0)
			{
				AbstractTreeNode1 @class = (base.Parent is StructureHeaderNode) ? (base.Parent as StructureHeaderNode).method_11(stream26_0.ReadIntAt(num)) : this.vmethod_12(stream26_0.ReadIntAt(num, true));
				base.method_1().Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			if (this.vmethod_8())
			{
				byte[] array = new byte[4];
				array[1] = 1;
                array[2] = (byte)(this.vmethod_15() - 128);
				stream26_0.WriteByteArray(array, false);
			}
			else
			{
				byte[] array2 = new byte[4];
				array2[1] = this.vmethod_15();
				stream26_0.WriteByteArray(array2, false);
			}
			stream26_0.WriteInt(this.int_0);
			if (base.Nodes.Count != 0)
			{
				IEnumerator enumerator = base.Nodes.GetEnumerator();
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
			if (base.method_1().Nodes.IndexOf(this) < base.method_1().Nodes.Count - 1)
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
