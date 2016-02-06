using ns16;
using ns18;
using ns20;
using System;
using System.Drawing;

namespace ns21
{
	public class Class274 : Class260
	{
		public Class274()
		{
			this.vmethod_0();
		}

		public Class274(string string_0) : this(Class327.smethod_9(string_0))
		{
		}

		public Class274(int int_2)
		{
			this.int_0 = int_2;
			this.vmethod_0();
		}

		public Class274(string string_0, string string_1, Class275 class275_0) : this(Class327.smethod_9(string_0), Class327.smethod_9(string_1), class275_0)
		{
		}

		public Class274(int int_2, int int_3, Class275 class275_0)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			base.Nodes.Add(class275_0);
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 5;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.method_19();
			this.int_1 = stream26_0.method_19();
			int num = stream26_0.method_19();
			stream26_0.method_19();
			if (num != 0)
			{
				stream26_0.Position = (long)num;
				Class275 @class = new Class275();
				base.Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
            array[1] = (byte)(this.vmethod_7() ? 32 : 4);
			array[2] = 7;
			stream26_0.method_16(array, false);
			stream26_0.method_5(this.int_0);
			stream26_0.method_5(this.int_1);
			stream26_0.method_5((base.Nodes.Count != 0) ? ((int)stream26_0.Position + 8) : 0);
			stream26_0.method_5(0);
			foreach (Class259 @class in base.Nodes)
			{
				@class.vmethod_14(stream26_0);
			}
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
			foreach (Class259 @class in base.Nodes)
			{
				@class.vmethod_2(ref int_2);
			}
		}

		public override string vmethod_5()
		{
			return "Script Root";
		}

		public Class275 method_7()
		{
			return (Class275)base.Nodes[0];
		}

		public override Color vmethod_15()
		{
			return base.method_0(Color.BlanchedAlmond, Color.Cornsilk);
		}
	}
}
