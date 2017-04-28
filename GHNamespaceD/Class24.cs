using System;
using System.Runtime.CompilerServices;
using GHNamespace3;
using GHNamespaceH;

namespace GHNamespaceD
{
	public class Class24 : Class23
	{
		private static int[][][] _int0 = new int[2][][];

		public override object vmethod_0(OggClass5 class490, OggClass3 class380)
		{
			var num = 0;
			var @class = new Class40();
			@class.Int0 = class380.method_6(24);
			@class.Int1 = class380.method_6(24);
			@class.Int2 = class380.method_6(24) + 1;
			@class.Int3 = class380.method_6(6) + 1;
			@class.Int4 = class380.method_6(8);
			for (var i = 0; i < @class.Int3; i++)
			{
				var num2 = class380.method_6(3);
				if (class380.method_6(1) != 0)
				{
					num2 |= class380.method_6(5) << 3;
				}
				@class.Int5[i] = num2;
				num += smethod_3(num2);
			}
			for (var j = 0; j < num; j++)
			{
				@class.Int6[j] = class380.method_6(8);
			}
			if (@class.Int4 >= class490.Int19)
			{
				vmethod_2(@class);
				return null;
			}
			for (var k = 0; k < num; k++)
			{
				if (@class.Int6[k] >= class490.Int19)
				{
					vmethod_2(@class);
					return null;
				}
			}
			return @class;
		}

		public override object vmethod_1(OggClass1 class660, Class27 class270, object object0)
		{
			var @class = (Class40)object0;
			var class2 = new Class39();
			var num = 0;
			var num2 = 0;
			class2.Class400 = @class;
			class2.Int0 = class270.Int3;
			class2.Int1 = @class.Int3;
			class2.Class210 = class660.OggClass4;
			class2.Class211 = class660.OggClass4[@class.Int4];
			var num3 = class2.Class211.Int0;
			class2.Int3 = new int[class2.Int1][];
			for (var i = 0; i < class2.Int1; i++)
			{
				var num4 = smethod_2(@class.Int5[i]);
				if (num4 != 0)
				{
					if (num4 > num2)
					{
						num2 = num4;
					}
					class2.Int3[i] = new int[num4];
					for (var j = 0; j < num4; j++)
					{
						if ((@class.Int5[i] & 1 << j) != 0)
						{
							class2.Int3[i][j] = @class.Int6[num++];
						}
					}
				}
			}
			class2.Int4 = (int)Math.Round(Math.Pow(class2.Int1, num3));
			class2.Int2 = num2;
			class2.Int5 = new int[class2.Int4][];
			for (var k = 0; k < class2.Int4; k++)
			{
				var num5 = k;
				var num6 = class2.Int4 / class2.Int1;
				class2.Int5[k] = new int[num3];
				for (var l = 0; l < num3; l++)
				{
					var num7 = num5 / num6;
					num5 -= num7 * num6;
					num6 /= class2.Int1;
					class2.Int5[k][l] = num7;
				}
			}
			return class2;
		}

		public override void vmethod_2(object object0)
		{
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static int smethod_0(OggClass6 class710, object object0, float[][] float0, int int1, int int2)
		{
			var @class = (Class39)object0;
			var class40 = @class.Class400;
			var int3 = class40.Int2;
			var num = @class.Class211.Int0;
			var num2 = class40.Int1 - class40.Int0;
			var num3 = num2 / int3;
			var num4 = (num3 + num - 1) / num;
			if (_int0.Length < int1)
			{
				_int0 = new int[int1][][];
				for (var i = 0; i < int1; i++)
				{
					_int0[i] = new int[num4][];
				}
			}
			else
			{
				for (var i = 0; i < int1; i++)
				{
					if (_int0[i] == null || _int0[i].Length < num4)
					{
						_int0[i] = new int[num4][];
					}
				}
			}
			for (var j = 0; j < @class.Int2; j++)
			{
				var k = 0;
				var num5 = 0;
				while (k < num3)
				{
					if (j == 0)
					{
						for (var i = 0; i < int1; i++)
						{
							var num6 = @class.Class211.method_4(class710.OggClass3);
							if (num6 == -1)
							{
								return 0;
							}
							_int0[i][num5] = @class.Int5[num6];
							if (_int0[i][num5] == null)
							{
								return 0;
							}
						}
					}
					var num7 = 0;
					while (num7 < num && k < num3)
					{
						for (var i = 0; i < int1; i++)
						{
							var int4 = class40.Int0 + k * int3;
							if ((class40.Int5[_int0[i][num5][num7]] & 1 << j) != 0)
							{
								var class2 = @class.Class210[@class.Int3[_int0[i][num5][num7]][j]];
								if (class2 != null)
								{
									if (int2 == 0)
									{
										if (class2.method_0(float0[i], int4, class710.OggClass3, int3) == -1)
										{
											return 0;
										}
									}
									else if (int2 == 1 && class2.method_1(float0[i], int4, class710.OggClass3, int3) == -1)
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

		public static int smethod_1(OggClass6 class710, object object0, float[][] float0, int int1)
		{
			var @class = (Class39)object0;
			var class40 = @class.Class400;
			var int2 = class40.Int2;
			var num = @class.Class211.Int0;
			var num2 = class40.Int1 - class40.Int0;
			var num3 = num2 / int2;
			var num4 = (num3 + num - 1) / num;
			var array = new int[num4][];
			for (var i = 0; i < @class.Int2; i++)
			{
				var j = 0;
				var num5 = 0;
				while (j < num3)
				{
					if (i == 0)
					{
						var num6 = @class.Class211.method_4(class710.OggClass3);
						if (num6 == -1)
						{
							return 0;
						}
						array[num5] = @class.Int5[num6];
						if (array[num5] == null)
						{
							return 0;
						}
					}
					var num7 = 0;
					while (num7 < num && j < num3)
					{
						var int3 = class40.Int0 + j * int2;
						if ((class40.Int5[array[num5][num7]] & 1 << i) != 0)
						{
							var class2 = @class.Class210[@class.Int3[array[num5][num7]][i]];
							if (class2 != null && class2.method_3(float0, int3, int1, class710.OggClass3, int2) == -1)
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

		public override int vmethod_3(OggClass6 class710, object object0, float[][] float0, int[] int1, int int2)
		{
			var num = 0;
			for (var i = 0; i < int2; i++)
			{
				if (int1[i] != 0)
				{
					float0[num++] = float0[i];
				}
			}
			if (num != 0)
			{
				return smethod_0(class710, object0, float0, num, 0);
			}
			return 0;
		}

		public static int smethod_2(int int1)
		{
			var num = 0;
			while (int1 != 0)
			{
				num++;
				int1 = (int)((uint)int1 >> 1);
			}
			return num;
		}

		public static int smethod_3(int int1)
		{
			var num = 0;
			while (int1 != 0)
			{
				num += (int1 & 1);
				int1 = (int)((uint)int1 >> 1);
			}
			return num;
		}
	}
}
