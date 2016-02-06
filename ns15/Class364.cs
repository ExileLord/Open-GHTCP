using System;

namespace ns15
{
	public class Class364
	{
		public bool[] bool_0;

		public int int_0;

		public Class364(bool[] bool_1, int int_1)
		{
			this.bool_0 = bool_1;
			this.int_0 = int_1;
		}

		public Class364(int int_1, int int_2)
		{
			this.method_1(int_1);
			this.int_0 = int_2;
		}

		public int method_0()
		{
			uint num = 0u;
			for (int i = 0; i < this.bool_0.Length; i++)
			{
				if (this.bool_0[i])
				{
					num |= 1u << i;
				}
			}
			return (int)num;
		}

		public void method_1(int int_1)
		{
			this.bool_0 = new bool[32];
			for (int i = 0; i < 32; i++)
			{
				if ((int_1 >> i & 1) != 0)
				{
					this.bool_0[i] = true;
				}
			}
		}
	}
}
