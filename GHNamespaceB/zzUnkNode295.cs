using System;
using GHNamespace9;
using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespaceB
{
	public abstract class ZzUnkNode295 : ZzUnkNode294
	{
		public abstract byte vmethod_15();

		public override void vmethod_13(Stream26 stream260)
		{
			Int0 = stream260.ReadInt();
			if (this is FloatStructureNode)
			{
				Nodes.Add(new FloatValueNode(stream260.ReadFloat()));
			}
			else if (this is IntegerStructureNode)
			{
				Nodes.Add(new IntegerValueNode(stream260.ReadInt()));
			}
			else if (this is TagStructureNode || this is FileTagStructureNode)
			{
				Nodes.Add(new TagValueNode(stream260.ReadInt()));
			}
			var num = stream260.ReadInt();
			if (num != 0)
			{
				var @class = (Parent is StructureHeaderNode) ? (Parent as StructureHeaderNode).method_11(stream260.ReadIntAt(num)) : vmethod_12(stream260.ReadIntAt(num, true));
				method_1().Nodes.Add(@class);
				@class.method_4(stream260);
			}
		}

		public override void vmethod_14(Stream26 stream260)
		{
			if (vmethod_8())
			{
				var array = new byte[4];
				array[1] = 1;
                array[2] = (byte)(vmethod_15() - 128);
				stream260.WriteByteArray(array, false);
			}
			else
			{
				var array2 = new byte[4];
				array2[1] = vmethod_15();
				stream260.WriteByteArray(array2, false);
			}
			stream260.WriteInt(Int0);
			if (Nodes.Count != 0)
			{
				var enumerator = Nodes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						var @class = (AbstractTreeNode2)enumerator.Current;
						stream260.WriteByteArray(@class.vmethod_8());
					}
					goto IL_AA;
				}
				finally
				{
					var disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			stream260.WriteInt(0);
			IL_AA:
			if (method_1().Nodes.IndexOf(this) < method_1().Nodes.Count - 1)
			{
				stream260.WriteInt((int)stream260.Position + 4);
				return;
			}
			stream260.WriteInt(0);
		}

		public override void vmethod_2(ref int int1)
		{
			int1 += 16;
		}
	}
}
