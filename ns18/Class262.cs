using ns16;
using ns19;
using System;

namespace ns18
{
	public class Class262 : Class260
	{
		public Class262()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 1;
		}

		public string method_7()
		{
			if (base.Nodes.Count != 0)
			{
				return ((Class311)base.FirstNode).method_2();
			}
			return null;
		}

		public int method_8()
		{
			if (base.Nodes.Count != 0)
			{
				return ((Class311)base.FirstNode).int_0;
			}
			return 0;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.method_19();
			this.int_1 = stream26_0.method_19();
			base.Nodes.Add(new Class311(stream26_0.method_19(), this.vmethod_10()));
			stream26_0.method_19();
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			this.vmethod_9(true);
			byte[] array = new byte[4];
            array[1] = (this.vmethod_7() ? (byte)32 : (byte)4);
			array[2] = 28;
			stream26_0.method_16(array, false);
			stream26_0.method_5(this.int_0);
			stream26_0.method_5(this.int_1);
			if (base.Nodes.Count != 0)
			{
				stream26_0.method_5(this.method_8());
				if (this.method_7() != null)
				{
					this.vmethod_10()[this.method_8()] = this.method_7();
				}
			}
			else
			{
				stream26_0.method_5(0);
			}
			stream26_0.method_5(0);
		}

		public override string GetNodeText()
		{
			return "Text Root";
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
		}
	}
}
