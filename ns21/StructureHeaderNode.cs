using System;
using System.Collections.Generic;
using ns16;
using ns18;
using ns19;
using ns20;
using ns22;

namespace ns21
{
	public class StructureHeaderNode : AbsTreeNode11<ZzUnkNode294>
	{
		public ZzUnkNode294 this[int int0]
		{
			get
			{
				return (ZzUnkNode294)Nodes[int0];
			}
			set
			{
				Nodes[int0] = value;
			}
		}

		public StructureHeaderNode()
		{
			vmethod_0();
		}

		public StructureHeaderNode(IEnumerable<ZzUnkNode294> ienumerable0)
		{
			method_10(ienumerable0);
		}

		public override int vmethod_1()
		{
			return 19;
		}

		public override void vmethod_13(Stream26 stream260)
		{
			var num = stream260.ReadInt();
			if (num != 0)
			{
				stream260.Position = num;
				var @class = method_11(stream260.ReadInt());
				Nodes.Add(@class);
				@class.method_4(stream260);
			}
		}

		public override void vmethod_14(Stream26 stream260)
		{
			var array = new byte[4];
			array[2] = 1;
			stream260.WriteByteArray(array, false);
			if (Nodes.Count != 0)
			{
				stream260.WriteInt((int)stream260.Position + 4);
			}
			else
			{
				stream260.WriteInt(0);
			}
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_14(stream260);
			}
		}

		public AbstractTreeNode1 method_11(int int0)
		{
			if (int0 == 256)
			{
				return new StructureHeaderNode();
			}
			var num = int0 >> 16 & 255;
			var num2 = int0 >> 8 & 255;
			var ex = new Exception("No QB Node class found for : " + KeyGenerator.ValToHex32Bit(int0));
			if (num == 1)
			{
				vmethod_9(true);
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
		    if (!vmethod_7())
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

		public override void vmethod_2(ref int int0)
		{
			int0 += 8;
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_2(ref int0);
			}
		}

		public override string GetNodeText()
		{
			return "Structure Header";
		}
	}
}
