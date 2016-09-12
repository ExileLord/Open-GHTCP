using ns16;
using ns18;
using ns19;
using ns20;
using System;

namespace ns21
{
	public class UnicodeStructureNode : zzUnkNode294
	{
		public UnicodeStructureNode()
		{
			this.vmethod_0();
		}

		public UnicodeStructureNode(string string_0) : this(QbSongClass1.smethod_9(string_0))
		{
		}

		public UnicodeStructureNode(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public UnicodeStructureNode(string string_0, string string_1) : this(QbSongClass1.smethod_9(string_0), string_1)
		{
		}

		public UnicodeStructureNode(int int_1, string string_0)
		{
			this.int_0 = int_1;
			base.Nodes.Add(new Class312(string_0));
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 22;
		}

		public string method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return ((Class312)base.FirstNode).string_0;
			}
			return null;
		}

		public void method_9(string string_0)
		{
			if (base.Nodes.Count != 0)
			{
				((Class312)base.FirstNode).string_0 = string_0;
				return;
			}
			base.Nodes.Add(new Class312(string_0));
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.method_19();
			int num = stream26_0.method_19();
			int num2 = stream26_0.method_19();
			if (num != 0)
			{
				base.Nodes.Add(new Class312(stream26_0.method_46(num)));
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
				array[2] = 4;
				stream26_0.method_16(array, false);
			}
			else
			{
				byte[] array2 = new byte[4];
                array2[1] = (this.vmethod_7() ? (byte)132 : (byte)9);
				stream26_0.method_16(array2, false);
			}
			stream26_0.method_5(this.int_0);
			int int_ = (int)stream26_0.Position + 4;
			if (base.Nodes.Count != 0)
			{
				stream26_0.method_5((int)stream26_0.Position + 8);
				stream26_0.method_5(0);
				stream26_0.method_14(this.method_8(), stream26_0.bool_0);
				stream26_0.method_4(0, 2);
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
			return "Unicode Structure";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 16;
			if (base.Nodes.Count != 0)
			{
				((Class312)base.Nodes[0]).vmethod_2(ref int_1);
				int_1 += 2;
				int_1 += AbstractTreeNode1.smethod_0((long)int_1);
			}
		}
	}
}
