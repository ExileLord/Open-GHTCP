using System;

namespace ns5
{
	public class Class105
	{
		public static readonly float float_0 = float.NegativeInfinity;

		public static readonly Class105 class105_0 = new Class105();

		private readonly float[] float_1 = new float[32];

		public float[] method_0()
		{
			float[] array = new float[32];
			int i = 0;
			int num = 32;
			while (i < num)
			{
				array[i] = Class105.smethod_1(this.float_1[i]);
				i++;
			}
			return array;
		}

		public void method_1(float[] float_2)
		{
			this.method_3();
			int num = (float_2.Length > 32) ? 32 : float_2.Length;
			for (int i = 0; i < num; i++)
			{
				this.float_1[i] = Class105.smethod_0(float_2[i]);
			}
		}

		public void method_2(Class105 class105_1)
		{
			if (class105_1 != this)
			{
				this.method_1(class105_1.float_1);
			}
		}

		public void method_3()
		{
			for (int i = 0; i < 32; i++)
			{
				this.float_1[i] = 0f;
			}
		}

		private static float smethod_0(float float_2)
		{
			if (float_2 == Class105.float_0)
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
			if (float_2 == Class105.float_0)
			{
				return 0f;
			}
			return (float)Math.Pow(2.0, (double)float_2);
		}
	}
}
