using System;

namespace ns5
{
	public class Class112 : ICloneable
	{
		public long Long0 = -1L;

		public long Long1 = -1L;

		public int Int0;

		public object Object0;

		public object Object1;

		public int Int1;

		public int Int2;

		public long Long2 = Long3;

		public static readonly long Long3 = 9223372036854775806L;

		public virtual object Clone()
		{
			return new Class112
			{
				Long1 = Long1,
				Int0 = Int0,
				Object1 = smethod_0(Object1, true),
				Int1 = Int1,
				Int2 = Int2,
				Long2 = Long2,
				Long0 = Long0,
				Object0 = smethod_0(Object0, true)
			};
		}

		private static object smethod_0(object object2, bool bool0)
		{
			if (object2 == null)
			{
				return null;
			}
			if (!object2.GetType().IsArray)
			{
				throw new ArgumentException();
			}
			int num;
			object obj;
			if (object2.GetType() == typeof(byte[]))
			{
				num = ((byte[])object2).Length;
				obj = new byte[num];
			}
			else if (object2.GetType() == typeof(int[]))
			{
				num = ((int[])object2).Length;
				obj = new int[num];
			}
			else if (object2.GetType() == typeof(short[]))
			{
				num = ((short[])object2).Length;
				obj = new short[num];
			}
			else if (!bool0 && object2.GetType() == typeof(float[]))
			{
				num = ((float[])object2).Length;
				obj = new float[num];
			}
			else if (!bool0 && object2.GetType() == typeof(double[]))
			{
				num = ((double[])object2).Length;
				obj = new double[num];
			}
			else if (!bool0 && object2.GetType() == typeof(bool[]))
			{
				num = ((bool[])object2).Length;
				obj = new bool[num];
			}
			else if (!bool0 && object2.GetType() == typeof(long[]))
			{
				num = ((long[])object2).Length;
				obj = new long[num];
			}
			else
			{
				if (bool0 || object2.GetType() != typeof(char[]))
				{
					return object2;
				}
				num = ((char[])object2).Length;
				obj = new char[num];
			}
			Array.Copy((Array)object2, 0, (Array)obj, 0, num);
			return obj;
		}
	}
}
