using ns16;
using ns18;
using ns19;
using System;

namespace ns21
{
	public class Class306 : Class294
	{
		public Class306()
		{
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
				return ((Class311)base.FirstNode).method_2();
			}
			return null;
		}

		public int method_9()
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
			base.Nodes.Add(new Class311(stream26_0.method_19(), this.vmethod_10()));
			int num = stream26_0.method_19();
			if (num != 0)
			{
				Class259 @class = (base.Parent is Class286) ? (base.Parent as Class286).method_11(stream26_0.method_41(num)) : this.vmethod_12(stream26_0.method_42(num, true));
				base.method_1().Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			this.vmethod_9(true);
			byte[] array = new byte[4];
			array[1] = 1;
			array[2] = 28;
			stream26_0.method_16(array, false);
			stream26_0.method_5(this.int_0);
			if (base.Nodes.Count != 0)
			{
				stream26_0.method_5(this.method_9());
				if (this.method_8() != null)
				{
					this.vmethod_10()[this.method_9()] = this.method_8();
				}
			}
			else
			{
				stream26_0.method_5(0);
			}
			if (base.method_1().Nodes.IndexOf(this) < base.method_1().Nodes.Count - 1)
			{
				stream26_0.method_5((int)stream26_0.Position + 4);
				return;
			}
			stream26_0.method_5(0);
		}

		public override string vmethod_5()
		{
			return "Text Structure";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 16;
		}
	}
}
