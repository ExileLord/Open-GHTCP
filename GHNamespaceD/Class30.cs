using System;
using GHNamespace3;
using GHNamespaceH;

namespace GHNamespaceD
{
	public class Class30 : Class28
	{
		private readonly object _object0 = new object();

		public override object vmethod_0(OggClass5 class490, OggClass3 class380)
		{
			var @class = new Class36();
			@class.Int0 = class380.method_6(8);
			@class.Int1 = class380.method_6(16);
			@class.Int2 = class380.method_6(16);
			@class.Int3 = class380.method_6(6);
			@class.Int4 = class380.method_6(8);
			@class.Int5 = class380.method_6(4) + 1;
			if (@class.Int0 >= 1 && @class.Int1 >= 1 && @class.Int2 >= 1 && @class.Int5 >= 1)
			{
				for (var i = 0; i < @class.Int5; i++)
				{
					@class.Int6[i] = class380.method_6(8);
					if (@class.Int6[i] < 0 || @class.Int6[i] >= class490.Int19)
					{
						return null;
					}
				}
				return @class;
			}
			return null;
		}

		public override object vmethod_1(OggClass1 class660, Class27 class270, object object1)
		{
			var class49 = class660.OggClass5;
			var @class = (Class36)object1;
			var class2 = new Class37();
			class2.Int2 = @class.Int0;
			class2.Int0 = class49.Int13[class270.Int0] / 2;
			class2.Int1 = @class.Int2;
			class2.Class360 = @class;
			class2.Class630.method_0(class2.Int1, class2.Int2);
			var num = class2.Int1 / (float)smethod_0((float)(@class.Int1 / 2.0));
			class2.Int3 = new int[class2.Int0];
			for (var i = 0; i < class2.Int0; i++)
			{
				var num2 = (int)Math.Floor(smethod_0((float)(@class.Int1 / 2.0 / class2.Int0 * i)) * num);
				if (num2 >= class2.Int1)
				{
					num2 = class2.Int1;
				}
				class2.Int3[i] = num2;
			}
			return class2;
		}

		private static double smethod_0(float float0)
		{
			var num = 13.1 * Math.Atan(0.00074 * float0);
			var num2 = 2.24 * Math.Atan(float0 * float0 * 1.85E-08);
			var num3 = 0.0001 * float0;
			return num + num2 + num3;
		}

		public override void vmethod_2(object object1)
		{
		}

		public override object vmethod_3(OggClass6 class710, object object1, object object2)
		{
			var @class = (Class37)object1;
			var class36 = @class.Class360;
			float[] array = null;
			if (object2 is float[])
			{
				array = (float[])object2;
			}
			var num = class710.OggClass3.method_6(class36.Int3);
			if (num > 0)
			{
				var num2 = (1 << class36.Int3) - 1;
				var num3 = num / (float)num2 * class36.Int4;
				var num4 = class710.OggClass3.method_6(smethod_1(class36.Int5));
				if (num4 != -1 && num4 < class36.Int5)
				{
					var class2 = class710.OggClass1.OggClass4[class36.Int6[num4]];
					var num5 = 0f;
					if (array != null && array.Length >= @class.Int2 + 1)
					{
						for (var i = 0; i < array.Length; i++)
						{
							array[i] = 0f;
						}
					}
					else
					{
						array = new float[@class.Int2 + 1];
					}
					for (var j = 0; j < @class.Int2; j += class2.Int0)
					{
						if (class2.method_2(array, j, class710.OggClass3, class2.Int0) == -1)
						{
							return null;
						}
					}
					var k = 0;
					while (k < @class.Int2)
					{
						var l = 0;
						while (l < class2.Int0)
						{
							array[k] += num5;
							l++;
							k++;
						}
						num5 = array[k - 1];
					}
					array[@class.Int2] = num3;
					return array;
				}
			}
			return null;
		}

		public override int vmethod_4(OggClass6 class710, object object1, object object2, float[] float0)
		{
			var @class = (Class37)object1;
			var class36 = @class.Class360;
			if (object2 != null)
			{
				var array = (float[])object2;
				var float_ = array[@class.Int2];
				Class77.smethod_0(float0, @class.Int3, @class.Int0, @class.Int1, array, @class.Int2, float_, class36.Int4);
				return 1;
			}
			for (var i = 0; i < @class.Int0; i++)
			{
				float0[i] = 0f;
			}
			return 0;
		}

		private static int smethod_1(int int0)
		{
			var num = 0;
			while (int0 != 0)
			{
				num++;
				int0 = (int)((uint)int0 >> 1);
			}
			return num;
		}
	}
}
