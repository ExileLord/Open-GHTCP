using ns2;
using ns3;
using System;

namespace ns10
{
	public class Class71
	{
		public float[][] float_0 = new float[0][];

		public Class38 class38_0 = new Class38();

		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public int int_4;

		public int int_5;

		public long long_0;

		public long long_1;

		public Class66 class66_0;

		public int int_6;

		public int int_7;

		public int int_8;

		public int int_9;

		public Class71(Class66 class66_1)
		{
			this.class66_0 = class66_1;
			if (class66_1.int_2 != 0)
			{
				this.class38_0.method_0();
			}
		}

		public void method_0(Class66 class66_1)
		{
			this.class66_0 = class66_1;
		}

		public int method_1()
		{
			if (this.class66_0 != null && this.class66_0.int_2 != 0)
			{
				this.class38_0.method_1();
			}
			return 0;
		}

		public int method_2(Class67 class67_0)
		{
			Class49 class49_ = this.class66_0.class49_0;
			this.class38_0.method_4(class67_0.byte_0, class67_0.int_0, class67_0.int_1);
			if (this.class38_0.method_6(1) != 0)
			{
				return -1;
			}
			int num = this.class38_0.method_6(this.class66_0.int_3);
			if (num == -1)
			{
				return -1;
			}
			this.int_4 = num;
			this.int_1 = class49_.class27_0[this.int_4].int_0;
			if (this.int_1 != 0)
			{
				this.int_0 = this.class38_0.method_6(1);
				this.int_2 = this.class38_0.method_6(1);
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
			this.int_3 = class49_.int_13[this.int_1];
			if (this.float_0.Length < class49_.int_8)
			{
				this.float_0 = new float[class49_.int_8][];
			}
			for (int i = 0; i < class49_.int_8; i++)
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
			int num2 = class49_.int_21[class49_.class27_0[this.int_4].int_3];
			return Class34.class34_0[num2].vmethod_3(this, this.class66_0.object_1[this.int_4]);
		}
	}
}
