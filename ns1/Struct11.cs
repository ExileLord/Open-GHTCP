using System;

namespace ns1
{
	public struct Struct11
	{
		private readonly int int_0;

		private readonly int int_1;

		public Struct11(int int_2, int int_3)
		{
			int_0 = int_2;
			int_1 = int_3;
		}

		public Struct11 method_0(Struct11 struct11_0)
		{
			int num = Math.Max(int_0, struct11_0.int_0);
			int num2 = Math.Min(int_1, struct11_0.int_1);
			if (num2 > num)
			{
				return new Struct11(num, num2);
			}
			return new Struct11(-1, -1);
		}

		public bool method_1()
		{
			return int_0 == -1 || int_1 == -1;
		}

		public int method_2()
		{
			return int_0;
		}

		public int method_3()
		{
			return int_1 - int_0;
		}
	}
}
