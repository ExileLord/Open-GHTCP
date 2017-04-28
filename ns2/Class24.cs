using System;
using System.Runtime.CompilerServices;
using ns10;
using ns3;

namespace ns2
{
	public class Class24 : Class23
	{
		private static int[][][] int_0 = new int[2][][];

		public override object vmethod_0(OGGClass5 class49_0, OGGClass3 class38_0)
		{
			int num = 0;
			Class40 @class = new Class40();
			@class.int_0 = class38_0.method_6(24);
			@class.int_1 = class38_0.method_6(24);
			@class.int_2 = class38_0.method_6(24) + 1;
			@class.int_3 = class38_0.method_6(6) + 1;
			@class.int_4 = class38_0.method_6(8);
			for (int i = 0; i < @class.int_3; i++)
			{
				int num2 = class38_0.method_6(3);
				if (class38_0.method_6(1) != 0)
				{
					num2 |= class38_0.method_6(5) << 3;
				}
				@class.int_5[i] = num2;
				num += smethod_3(num2);
			}
			for (int j = 0; j < num; j++)
			{
				@class.int_6[j] = class38_0.method_6(8);
			}
			if (@class.int_4 >= class49_0.int_19)
			{
				vmethod_2(@class);
				return null;
			}
			for (int k = 0; k < num; k++)
			{
				if (@class.int_6[k] >= class49_0.int_19)
				{
					vmethod_2(@class);
					return null;
				}
			}
			return @class;
		}

		public override object vmethod_1(OGGClass1 class66_0, Class27 class27_0, object object_0)
		{
			Class40 @class = (Class40)object_0;
			Class39 class2 = new Class39();
			int num = 0;
			int num2 = 0;
			class2.class40_0 = @class;
			class2.int_0 = class27_0.int_3;
			class2.int_1 = @class.int_3;
			class2.class21_0 = class66_0.oggClass4;
			class2.class21_1 = class66_0.oggClass4[@class.int_4];
			int num3 = class2.class21_1.int_0;
			class2.int_3 = new int[class2.int_1][];
			for (int i = 0; i < class2.int_1; i++)
			{
				int num4 = smethod_2(@class.int_5[i]);
				if (num4 != 0)
				{
					if (num4 > num2)
					{
						num2 = num4;
					}
					class2.int_3[i] = new int[num4];
					for (int j = 0; j < num4; j++)
					{
						if ((@class.int_5[i] & 1 << j) != 0)
						{
							class2.int_3[i][j] = @class.int_6[num++];
						}
					}
				}
			}
			class2.int_4 = (int)Math.Round(Math.Pow(class2.int_1, num3));
			class2.int_2 = num2;
			class2.int_5 = new int[class2.int_4][];
			for (int k = 0; k < class2.int_4; k++)
			{
				int num5 = k;
				int num6 = class2.int_4 / class2.int_1;
				class2.int_5[k] = new int[num3];
				for (int l = 0; l < num3; l++)
				{
					int num7 = num5 / num6;
					num5 -= num7 * num6;
					num6 /= class2.int_1;
					class2.int_5[k][l] = num7;
				}
			}
			return class2;
		}

		public override void vmethod_2(object object_0)
		{
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static int smethod_0(OGGClass6 class71_0, object object_0, float[][] float_0, int int_1, int int_2)
		{
			Class39 @class = (Class39)object_0;
			Class40 class40_ = @class.class40_0;
			int int_3 = class40_.int_2;
			int num = @class.class21_1.int_0;
			int num2 = class40_.int_1 - class40_.int_0;
			int num3 = num2 / int_3;
			int num4 = (num3 + num - 1) / num;
			if (int_0.Length < int_1)
			{
				int_0 = new int[int_1][][];
				for (int i = 0; i < int_1; i++)
				{
					int_0[i] = new int[num4][];
				}
			}
			else
			{
				for (int i = 0; i < int_1; i++)
				{
					if (int_0[i] == null || int_0[i].Length < num4)
					{
						int_0[i] = new int[num4][];
					}
				}
			}
			for (int j = 0; j < @class.int_2; j++)
			{
				int k = 0;
				int num5 = 0;
				while (k < num3)
				{
					if (j == 0)
					{
						for (int i = 0; i < int_1; i++)
						{
							int num6 = @class.class21_1.method_4(class71_0.oggClass3);
							if (num6 == -1)
							{
								return 0;
							}
							int_0[i][num5] = @class.int_5[num6];
							if (int_0[i][num5] == null)
							{
								return 0;
							}
						}
					}
					int num7 = 0;
					while (num7 < num && k < num3)
					{
						for (int i = 0; i < int_1; i++)
						{
							int int_4 = class40_.int_0 + k * int_3;
							if ((class40_.int_5[int_0[i][num5][num7]] & 1 << j) != 0)
							{
								OGGClass4 class2 = @class.class21_0[@class.int_3[int_0[i][num5][num7]][j]];
								if (class2 != null)
								{
									if (int_2 == 0)
									{
										if (class2.method_0(float_0[i], int_4, class71_0.oggClass3, int_3) == -1)
										{
											return 0;
										}
									}
									else if (int_2 == 1 && class2.method_1(float_0[i], int_4, class71_0.oggClass3, int_3) == -1)
									{
										return 0;
									}
								}
							}
						}
						num7++;
						k++;
					}
					num5++;
				}
			}
			return 0;
		}

		public static int smethod_1(OGGClass6 class71_0, object object_0, float[][] float_0, int int_1)
		{
			Class39 @class = (Class39)object_0;
			Class40 class40_ = @class.class40_0;
			int int_2 = class40_.int_2;
			int num = @class.class21_1.int_0;
			int num2 = class40_.int_1 - class40_.int_0;
			int num3 = num2 / int_2;
			int num4 = (num3 + num - 1) / num;
			int[][] array = new int[num4][];
			for (int i = 0; i < @class.int_2; i++)
			{
				int j = 0;
				int num5 = 0;
				while (j < num3)
				{
					if (i == 0)
					{
						int num6 = @class.class21_1.method_4(class71_0.oggClass3);
						if (num6 == -1)
						{
							return 0;
						}
						array[num5] = @class.int_5[num6];
						if (array[num5] == null)
						{
							return 0;
						}
					}
					int num7 = 0;
					while (num7 < num && j < num3)
					{
						int int_3 = class40_.int_0 + j * int_2;
						if ((class40_.int_5[array[num5][num7]] & 1 << i) != 0)
						{
							OGGClass4 class2 = @class.class21_0[@class.int_3[array[num5][num7]][i]];
							if (class2 != null && class2.method_3(float_0, int_3, int_1, class71_0.oggClass3, int_2) == -1)
							{
								return 0;
							}
						}
						num7++;
						j++;
					}
					num5++;
				}
			}
			return 0;
		}

		public override int vmethod_3(OGGClass6 class71_0, object object_0, float[][] float_0, int[] int_1, int int_2)
		{
			int num = 0;
			for (int i = 0; i < int_2; i++)
			{
				if (int_1[i] != 0)
				{
					float_0[num++] = float_0[i];
				}
			}
			if (num != 0)
			{
				return smethod_0(class71_0, object_0, float_0, num, 0);
			}
			return 0;
		}

		public static int smethod_2(int int_1)
		{
			int num = 0;
			while (int_1 != 0)
			{
				num++;
				int_1 = (int)((uint)int_1 >> 1);
			}
			return num;
		}

		public static int smethod_3(int int_1)
		{
			int num = 0;
			while (int_1 != 0)
			{
				num += (int_1 & 1);
				int_1 = (int)((uint)int_1 >> 1);
			}
			return num;
		}
	}
}
