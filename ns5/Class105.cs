using System;

namespace ns5
{
	public class Class105
	{
		public static readonly float float_0 = float.NegativeInfinity;

		public static readonly Class105 class105_0 = new Class105();

        public static readonly int num_1 = 32;

		private readonly float[] float_1 = new float[num_1];

		public float[] method_0()
		{
			var array = new float[num_1];
			var i = 0;
			var num = num_1;
			while (i < num)
			{
				array[i] = smethod_1(float_1[i]);
				i++;
			}
			return array;
		}

		public void method_1(float[] float_2)
		{
			method_3();
			var num = (float_2.Length > num_1) ? num_1 : float_2.Length;
			for (var i = 0; i < num; i++)
			{
				float_1[i] = smethod_0(float_2[i]);
			}
		}

		public void method_2(Class105 class105_1)
		{
			if (class105_1 != this)
			{
				method_1(class105_1.float_1);
			}
		}

		public void method_3()
		{
			for (var i = 0; i < num_1; i++)
			{
				float_1[i] = 0f;
			}
		}

		private static float smethod_0(float float_2)
		{
			if (float_2 == float_0)
			{
				return float_2;
			}
			if (float_2 > 1f)
			{
				return 1f;
			}
			if (float_2 < -1f)
			{
				return -1f;
			}
			return float_2;
		}

		public static float smethod_1(float float_2)
		{
			if (float_2 == float_0)
			{
				return 0f;
			}
			return (float)Math.Pow(2.0, float_2);
		}
	}
}
