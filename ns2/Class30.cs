using ns10;
using ns3;
using System;

namespace ns2
{
	public class Class30 : Class28
	{
		private readonly object object_0 = new object();

		public override object vmethod_0(Class49 class49_0, Class38 class38_0)
		{
			Class36 @class = new Class36();
			@class.int_0 = class38_0.method_6(8);
			@class.int_1 = class38_0.method_6(16);
			@class.int_2 = class38_0.method_6(16);
			@class.int_3 = class38_0.method_6(6);
			@class.int_4 = class38_0.method_6(8);
			@class.int_5 = class38_0.method_6(4) + 1;
			if (@class.int_0 >= 1 && @class.int_1 >= 1 && @class.int_2 >= 1 && @class.int_5 >= 1)
			{
				for (int i = 0; i < @class.int_5; i++)
				{
					@class.int_6[i] = class38_0.method_6(8);
					if (@class.int_6[i] < 0 || @class.int_6[i] >= class49_0.int_19)
					{
						return null;
					}
				}
				return @class;
			}
			return null;
		}

		public override object vmethod_1(Class66 class66_0, Class27 class27_0, object object_1)
		{
			Class49 class49_ = class66_0.class49_0;
			Class36 @class = (Class36)object_1;
			Class37 class2 = new Class37();
			class2.int_2 = @class.int_0;
			class2.int_0 = class49_.int_13[class27_0.int_0] / 2;
			class2.int_1 = @class.int_2;
			class2.class36_0 = @class;
			class2.class63_0.method_0(class2.int_1, class2.int_2);
			float num = (float)class2.int_1 / (float)Class30.smethod_0((float)((double)@class.int_1 / 2.0));
			class2.int_3 = new int[class2.int_0];
			for (int i = 0; i < class2.int_0; i++)
			{
				int num2 = (int)Math.Floor(Class30.smethod_0((float)((double)@class.int_1 / 2.0 / (double)class2.int_0 * (double)i)) * (double)num);
				if (num2 >= class2.int_1)
				{
					num2 = class2.int_1;
				}
				class2.int_3[i] = num2;
			}
			return class2;
		}

		private static double smethod_0(float float_0)
		{
			double num = 13.1 * Math.Atan(0.00074 * (double)float_0);
			double num2 = 2.24 * Math.Atan((double)(float_0 * float_0) * 1.85E-08);
			double num3 = 0.0001 * (double)float_0;
			return num + num2 + num3;
		}

		public override void vmethod_2(object object_1)
		{
		}

		public override object vmethod_3(Class71 class71_0, object object_1, object object_2)
		{
			Class37 @class = (Class37)object_1;
			Class36 class36_ = @class.class36_0;
			float[] array = null;
			if (object_2 is float[])
			{
				array = (float[])object_2;
			}
			int num = class71_0.class38_0.method_6(class36_.int_3);
			if (num > 0)
			{
				int num2 = (1 << class36_.int_3) - 1;
				float num3 = (float)num / (float)num2 * (float)class36_.int_4;
				int num4 = class71_0.class38_0.method_6(Class30.smethod_1(class36_.int_5));
				if (num4 != -1 && num4 < class36_.int_5)
				{
					Class21 class2 = class71_0.class66_0.class21_0[class36_.int_6[num4]];
					float num5 = 0f;
					if (array != null && array.Length >= @class.int_2 + 1)
					{
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = 0f;
						}
					}
					else
					{
						array = new float[@class.int_2 + 1];
					}
					for (int j = 0; j < @class.int_2; j += class2.int_0)
					{
						if (class2.method_2(array, j, class71_0.class38_0, class2.int_0) == -1)
						{
							return null;
						}
					}
					int k = 0;
					while (k < @class.int_2)
					{
						int l = 0;
						while (l < class2.int_0)
						{
							array[k] += num5;
							l++;
							k++;
						}
						num5 = array[k - 1];
					}
					array[@class.int_2] = num3;
					return array;
				}
			}
			return null;
		}

		public override int vmethod_4(Class71 class71_0, object object_1, object object_2, float[] float_0)
		{
			Class37 @class = (Class37)object_1;
			Class36 class36_ = @class.class36_0;
			if (object_2 != null)
			{
				float[] array = (float[])object_2;
				float float_ = array[@class.int_2];
				Class77.smethod_0(float_0, @class.int_3, @class.int_0, @class.int_1, array, @class.int_2, float_, (float)class36_.int_4);
				return 1;
			}
			for (int i = 0; i < @class.int_0; i++)
			{
				float_0[i] = 0f;
			}
			return 0;
		}

		private static int smethod_1(int int_0)
		{
			int num = 0;
			while (int_0 != 0)
			{
				num++;
				int_0 = (int)((uint)int_0 >> 1);
			}
			return num;
		}
	}
}
