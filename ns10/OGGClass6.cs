using ns2;
using ns3;
using System;

namespace ns10
{
	public class OGGClass6
	{
		public float[][] float_0 = new float[0][];

		public OGGClass3 oggClass3 = new OGGClass3();

		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public int int_4;

		public int int_5;

		public long long_0;

		public long long_1;

		public OGGClass1 oggClass1;

		public int int_6;

		public int int_7;

		public int int_8;

		public int int_9;

		public OGGClass6(OGGClass1 oggClass1)
		{
			this.oggClass1 = oggClass1;
			if (oggClass1.int_2 != 0)
			{
				this.oggClass3.method_0();
			}
		}

		public void method_0(OGGClass1 oggClass1)
		{
			this.oggClass1 = oggClass1;
		}

		public int method_1()
		{
			if (this.oggClass1 != null && this.oggClass1.int_2 != 0)
			{
				this.oggClass3.method_1();
			}
			return 0;
		}

		public int method_2(Class67 class67_0)
		{
			OGGClass5 oggClass5 = this.oggClass1.oggClass5;
			this.oggClass3.method_4(class67_0.byte_0, class67_0.int_0, class67_0.int_1);
			if (this.oggClass3.method_6(1) != 0)
			{
				return -1;
			}
			int num = this.oggClass3.method_6(this.oggClass1.int_3);
			if (num == -1)
			{
				return -1;
			}
			this.int_4 = num;
			this.int_1 = oggClass5.class27_0[this.int_4].int_0;
			if (this.int_1 != 0)
			{
				this.int_0 = this.oggClass3.method_6(1);
				this.int_2 = this.oggClass3.method_6(1);
				if (this.int_2 == -1)
				{
					return -1;
				}
			}
			else
			{
				this.int_0 = 0;
				this.int_2 = 0;
			}
			this.long_0 = class67_0.long_0;
			this.long_1 = class67_0.long_1 - 3L;
			this.int_5 = class67_0.int_3;
			this.int_3 = oggClass5.int_13[this.int_1];
			if (this.float_0.Length < oggClass5.int_8)
			{
				this.float_0 = new float[oggClass5.int_8][];
			}
			for (int i = 0; i < oggClass5.int_8; i++)
			{
				if (this.float_0[i] != null && this.float_0[i].Length >= this.int_3)
				{
					for (int j = 0; j < this.int_3; j++)
					{
						this.float_0[i][j] = 0f;
					}
				}
				else
				{
					this.float_0[i] = new float[this.int_3];
				}
			}
			int num2 = oggClass5.int_21[oggClass5.class27_0[this.int_4].int_3];
			return Class34.class34_0[num2].vmethod_3(this, this.oggClass1.object_1[this.int_4]);
		}
	}
}
