using ns16;
using ns18;
using ns19;
using ns20;
using ns22;
using System;
using System.Collections.Generic;

namespace ns21
{
	public class StructureHeaderNode : AbsTreeNode1_1_<zzUnkNode294>
	{
		public zzUnkNode294 this[int int_0]
		{
			get
			{
				return (zzUnkNode294)base.Nodes[int_0];
			}
			set
			{
				base.Nodes[int_0] = value;
			}
		}

		public StructureHeaderNode()
		{
			this.vmethod_0();
		}

		public StructureHeaderNode(IEnumerable<zzUnkNode294> ienumerable_0)
		{
			base.method_10(ienumerable_0);
		}

		public override int vmethod_1()
		{
			return 19;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			int num = stream26_0.method_19();
			if (num != 0)
			{
				stream26_0.Position = (long)num;
				AbstractTreeNode1 @class = this.method_11(stream26_0.method_19());
				base.Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
			array[2] = 1;
			stream26_0.method_16(array, false);
			if (base.Nodes.Count != 0)
			{
				stream26_0.method_5((int)stream26_0.Position + 4);
			}
			else
			{
				stream26_0.method_5(0);
			}
			foreach (AbstractTreeNode1 @class in base.Nodes)
			{
				@class.vmethod_14(stream26_0);
			}
		}

		public AbstractTreeNode1 method_11(int int_0)
		{
			if (int_0 == 256)
			{
				return new StructureHeaderNode();
			}
			int num = int_0 >> 16 & 255;
			int num2 = int_0 >> 8 & 255;
			Exception ex = new Exception("No QB Node class found for : " + KeyGenerator.ValToHex32bit(int_0));
			if (num == 1)
			{
				this.vmethod_9(true);
				if (num2 == 1)
				{
					return new IntegerStructureNode();
				}
				if (num2 == 2)
				{
					return new FloatStructureNode();
				}
				if (num2 == 3)
				{
					return new AsciiStructureNode();
				}
				if (num2 == 4)
				{
					return new UnicodeStructureNode();
				}
				if (num2 == 5)
				{
					return new PairPointerNode();
				}
				if (num2 == 6)
				{
					return new VectorPointerNode();
				}
				if (num2 == 10)
				{
					return new StructurePointerNode();
				}
				if (num2 == 12)
				{
					return new ArrayPointerNode();
				}
				if (num2 == 13)
				{
					return new TagStructureNode();
				}
				if (num2 == 26)
				{
					return new FileTagStructureNode();
				}
				if (num2 == 28)
				{
					return new TextStructureNode();
				}
				throw ex;
			}
			else if (!this.vmethod_7())
			{
				if (num == 3)
				{
					return new IntegerStructureNode();
				}
				if (num == 5)
				{
					return new FloatStructureNode();
				}
				if (num == 7)
				{
					return new AsciiStructureNode();
				}
				if (num == 9)
				{
					return new UnicodeStructureNode();
				}
				if (num == 11)
				{
					return new PairPointerNode();
				}
				if (num == 13)
				{
					return new VectorPointerNode();
				}
				if (num == 21)
				{
					return new StructurePointerNode();
				}
				if (num == 25)
				{
					return new ArrayPointerNode();
				}
				if (num == 27)
				{
					return new TagStructureNode();
				}
				if (num == 53)
				{
					return new FileTagStructureNode();
				}
				throw ex;
			}
			else
			{
				if (num == 154)
				{
					return new FileTagStructureNode();
				}
				if ((num & 240) != 128 || (num2 = (num & 15)) == 0)
				{
					return null;
				}
				if (num2 == 1)
				{
					return new IntegerStructureNode();
				}
				if (num2 == 2)
				{
					return new FloatStructureNode();
				}
				if (num2 == 3)
				{
					return new AsciiStructureNode();
				}
				if (num2 == 4)
				{
					return new UnicodeStructureNode();
				}
				if (num2 == 5)
				{
					return new PairPointerNode();
				}
				if (num2 == 6)
				{
					return new VectorPointerNode();
				}
				if (num2 == 10)
				{
					return new StructurePointerNode();
				}
				if (num2 == 12)
				{
					return new ArrayPointerNode();
				}
				if (num2 == 13)
				{
					return new TagStructureNode();
				}
				throw ex;
			}
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 8;
			foreach (AbstractTreeNode1 @class in base.Nodes)
			{
				@class.vmethod_2(ref int_0);
			}
		}

		public override string GetNodeText()
		{
			return "Structure Header";
		}
	}
}
