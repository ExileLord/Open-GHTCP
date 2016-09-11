using ns10;
using ns2;
using System;

namespace ns3
{
	public class Class35 : Class34
	{
		private readonly object object_0 = new object();

		private float[][] float_0;

		private int[] int_0;

		private int[] int_1;

		private object[] object_1;

		public override void vmethod_2(object object_2)
		{
		}

		public override object vmethod_1(OGGClass1 class66_0, Class27 class27_0, object object_2)
		{
			OGGClass5 class49_ = class66_0.oggClass5;
			Class55 @class = new Class55();
			Class54 class2 = @class.class54_0 = (Class54)object_2;
			@class.class27_0 = class27_0;
			@class.object_0 = new object[class2.int_0];
			@class.object_1 = new object[class2.int_0];
			@class.object_2 = new object[class2.int_0];
			@class.class50_0 = new Class50[class2.int_0];
			@class.class28_0 = new Class28[class2.int_0];
			@class.class23_0 = new Class23[class2.int_0];
			for (int i = 0; i < class2.int_0; i++)
			{
				int num = class2.int_2[i];
				int num2 = class2.int_3[i];
				int num3 = class2.int_4[i];
				@class.class50_0[i] = Class50.class50_0[class49_.int_22[num]];
				@class.object_0[i] = @class.class50_0[i].vmethod_1(class66_0, class27_0, class49_.object_1[num]);
				@class.class28_0[i] = Class28.class28_0[class49_.int_23[num2]];
				@class.object_1[i] = @class.class28_0[i].vmethod_1(class66_0, class27_0, class49_.object_2[num2]);
				@class.class23_0[i] = Class23.class23_0[class49_.int_24[num3]];
				@class.object_2[i] = @class.class23_0[i].vmethod_1(class66_0, class27_0, class49_.object_3[num3]);
			}
			if (class49_.int_20 == 0)
			{
			}
			@class.int_0 = class49_.int_8;
			return @class;
		}

		public override object vmethod_0(OGGClass5 class49_0, OGGClass3 class38_0)
		{
			Class54 @class = new Class54();
			if (class38_0.method_6(1) != 0)
			{
				@class.int_0 = class38_0.method_6(4) + 1;
			}
			else
			{
				@class.int_0 = 1;
			}
			if (class38_0.method_6(1) != 0)
			{
				@class.int_6 = class38_0.method_6(8) + 1;
				for (int i = 0; i < @class.int_6; i++)
				{
					int num = @class.int_7[i] = class38_0.method_6(Class35.smethod_0(class49_0.int_8));
					int num2 = @class.int_8[i] = class38_0.method_6(Class35.smethod_0(class49_0.int_8));
					if (num < 0 || num2 < 0 || num == num2 || num >= class49_0.int_8 || num2 >= class49_0.int_8)
					{
						@class.method_0();
						return null;
					}
				}
			}
			if (class38_0.method_6(2) > 0)
			{
				@class.method_0();
				return null;
			}
			if (@class.int_0 > 1)
			{
				for (int j = 0; j < class49_0.int_8; j++)
				{
					@class.int_1[j] = class38_0.method_6(4);
					if (@class.int_1[j] >= @class.int_0)
					{
						@class.method_0();
						return null;
					}
				}
			}
			for (int k = 0; k < @class.int_0; k++)
			{
				@class.int_2[k] = class38_0.method_6(8);
				if (@class.int_2[k] >= class49_0.int_16)
				{
					@class.method_0();
					return null;
				}
				@class.int_3[k] = class38_0.method_6(8);
				if (@class.int_3[k] >= class49_0.int_17)
				{
					@class.method_0();
					return null;
				}
				@class.int_4[k] = class38_0.method_6(8);
				if (@class.int_4[k] >= class49_0.int_18)
				{
					@class.method_0();
					return null;
				}
			}
			return @class;
		}

		public override int vmethod_3(OGGClass6 class71_0, object object_2)
		{
			int result;
			lock (this.object_0)
			{
				OGGClass1 class66_ = class71_0.oggClass1;
				OGGClass5 class49_ = class66_.oggClass5;
				Class55 @class = (Class55)object_2;
				Class54 class54_ = @class.class54_0;
				Class27 class27_ = @class.class27_0;
				int num = class71_0.int_3 = class49_.int_13[class71_0.int_1];
				float[] array = class66_.float_2[class71_0.int_1][class71_0.int_0][class71_0.int_2][class27_.int_1];
				if (this.float_0 == null || this.float_0.Length < class49_.int_8)
				{
					this.float_0 = new float[class49_.int_8][];
					this.int_1 = new int[class49_.int_8];
					this.int_0 = new int[class49_.int_8];
					this.object_1 = new object[class49_.int_8];
				}
				for (int i = 0; i < class49_.int_8; i++)
				{
					float[] array2 = class71_0.float_0[i];
					int num2 = class54_.int_1[i];
					this.object_1[i] = @class.class28_0[num2].vmethod_3(class71_0, @class.object_1[num2], this.object_1[i]);
					if (this.object_1[i] != null)
					{
						this.int_1[i] = 1;
					}
					else
					{
						this.int_1[i] = 0;
					}
					for (int j = 0; j < num / 2; j++)
					{
						array2[j] = 0f;
					}
				}
				for (int k = 0; k < class54_.int_6; k++)
				{
					if (this.int_1[class54_.int_7[k]] != 0 || this.int_1[class54_.int_8[k]] != 0)
					{
						this.int_1[class54_.int_7[k]] = 1;
						this.int_1[class54_.int_8[k]] = 1;
					}
				}
				for (int l = 0; l < class54_.int_0; l++)
				{
					int num3 = 0;
					for (int m = 0; m < class49_.int_8; m++)
					{
						if (class54_.int_1[m] == l)
						{
							if (this.int_1[m] != 0)
							{
								this.int_0[num3] = 1;
							}
							else
							{
								this.int_0[num3] = 0;
							}
							this.float_0[num3++] = class71_0.float_0[m];
						}
					}
					@class.class23_0[l].vmethod_3(class71_0, @class.object_2[l], this.float_0, this.int_0, num3);
				}
				for (int n = class54_.int_6 - 1; n >= 0; n--)
				{
					float[] array3 = class71_0.float_0[class54_.int_7[n]];
					float[] array4 = class71_0.float_0[class54_.int_8[n]];
					for (int num4 = 0; num4 < num / 2; num4++)
					{
						float num5 = array3[num4];
						float num6 = array4[num4];
						if (num5 > 0f)
						{
							if (num6 > 0f)
							{
								array3[num4] = num5;
								array4[num4] = num5 - num6;
							}
							else
							{
								array4[num4] = num5;
								array3[num4] = num5 + num6;
							}
						}
						else if (num6 > 0f)
						{
							array3[num4] = num5;
							array4[num4] = num5 + num6;
						}
						else
						{
							array4[num4] = num5;
							array3[num4] = num5 - num6;
						}
					}
				}
				for (int num7 = 0; num7 < class49_.int_8; num7++)
				{
					float[] array5 = class71_0.float_0[num7];
					int num8 = class54_.int_1[num7];
					@class.class28_0[num8].vmethod_4(class71_0, @class.object_1[num8], this.object_1[num7], array5);
				}
				for (int num9 = 0; num9 < class49_.int_8; num9++)
				{
					float[] array6 = class71_0.float_0[num9];
					((Class68)class66_.object_0[class71_0.int_1][0]).method_1(array6, array6);
				}
				for (int num10 = 0; num10 < class49_.int_8; num10++)
				{
					float[] array7 = class71_0.float_0[num10];
					if (this.int_1[num10] != 0)
					{
						for (int num11 = 0; num11 < num; num11++)
						{
							array7[num11] *= array[num11];
						}
					}
					else
					{
						for (int num12 = 0; num12 < num; num12++)
						{
							array7[num12] = 0f;
						}
					}
				}
				result = 0;
			}
			return result;
		}

		private static int smethod_0(int int_2)
		{
			int num = 0;
			while (int_2 > 1)
			{
				num++;
				int_2 = (int)((uint)int_2 >> 1);
			}
			return num;
		}
	}
}
