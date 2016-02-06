using ns18;
using ns20;
using System;

namespace ns21
{
	public class Class316 : Class310
	{
		public int int_0;

		public Class316()
		{
			this.vmethod_0();
		}

		public Class316(int int_1)
		{
			this.int_0 = int_1;
			this.vmethod_0();
		}

		public Class316(string string_0)
		{
			this.method_3(string_0);
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 35;
		}

		public override object vmethod_7()
		{
			return this.method_2();
		}

		public override byte[] vmethod_8()
		{
			return BitConverter.GetBytes(this.int_0);
		}

		public override void vmethod_9(byte[] byte_0)
		{
			this.int_0 = BitConverter.ToInt32(byte_0, 0);
		}

		public override string vmethod_3()
		{
			return this.method_2();
		}

		public string method_2()
		{
			if (Class327.smethod_3(this.int_0))
			{
				return Class327.smethod_5(this.int_0);
			}
			return "0x" + base.method_1(this.int_0);
		}

		public void method_3(string string_0)
		{
			this.int_0 = Class327.smethod_9(string_0);
		}

		public override string vmethod_5()
		{
			return "Tag Value";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 4;
		}
	}
}
