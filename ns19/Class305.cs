using ns16;
using ns18;
using ns20;
using ns21;
using System;

namespace ns19
{
	public class Class305 : zzUnkNode294
	{
		public Class305()
		{
			this.vmethod_0();
		}

		public Class305(string string_0) : this(QbSongClass1.smethod_9(string_0))
		{
		}

		public Class305(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public Class305(string string_0, string string_1) : this(QbSongClass1.smethod_9(string_0), string_1)
		{
		}

		public Class305(int int_1, string string_0)
		{
			this.int_0 = int_1;
			base.Nodes.Add(new AsciiValueNode(string_0));
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 21;
		}

		public string method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return ((AsciiValueNode)base.FirstNode).string_0;
			}
			return null;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.method_19();
			int num = stream26_0.method_19();
			int num2 = stream26_0.method_19();
			if (num != 0)
			{
				base.Nodes.Add(new AsciiValueNode(stream26_0.method_45(num)));
				stream26_0.Position += (long)AbstractTreeNode1.smethod_0(stream26_0.Position);
			}
			if (num2 != 0)
			{
				AbstractTreeNode1 @class = (base.Parent is StructureHeaderNode) ? (base.Parent as StructureHeaderNode).method_11(stream26_0.method_41(num2)) : this.vmethod_12(stream26_0.method_42(num2, true));
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
				array[2] = 3;
				stream26_0.method_16(array, false);
			}
			else
			{
				byte[] array2 = new byte[4];
                array2[1] = (byte)(this.vmethod_7() ? 131 : 7);
				stream26_0.method_16(array2, false);
			}
			stream26_0.method_5(this.int_0);
			int int_ = (int)stream26_0.Position + 4;
			if (base.Nodes.Count != 0)
			{
				stream26_0.method_5((int)stream26_0.Position + 8);
				stream26_0.method_5(0);
				stream26_0.method_13(this.method_8());
				stream26_0.method_3(0);
				stream26_0.method_4(0, AbstractTreeNode1.smethod_0(stream26_0.Position));
			}
			else
			{
				stream26_0.method_5(0);
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

		public override string GetNodeText()
		{
			return "Ascii Structure";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 16;
			if (base.Nodes.Count != 0)
			{
				((AsciiValueNode)base.Nodes[0]).vmethod_2(ref int_1);
				int_1++;
				int_1 += AbstractTreeNode1.smethod_0((long)int_1);
			}
		}
	}
}
