using System;

namespace ns5
{
	public class Class112 : ICloneable
	{
		public long long_0 = -1L;

		public long long_1 = -1L;

		public int int_0;

		public object object_0;

		public object object_1;

		public int int_1;

		public int int_2;

		public long long_2 = Class112.long_3;

		public static readonly long long_3 = 9223372036854775806L;

		public virtual object Clone()
		{
			return new Class112
			{
				long_1 = this.long_1,
				int_0 = this.int_0,
				object_1 = Class112.smethod_0(this.object_1, true),
				int_1 = this.int_1,
				int_2 = this.int_2,
				long_2 = this.long_2,
				long_0 = this.long_0,
				object_0 = Class112.smethod_0(this.object_0, true)
			};
		}

		private static object smethod_0(object object_2, bool bool_0)
		{
			if (object_2 == null)
			{
				return null;
			}
			if (!object_2.GetType().IsArray)
			{
				throw new ArgumentException();
			}
			int num;
			object obj;
			if (object_2.GetType() == typeof(byte[]))
			{
				num = ((byte[])object_2).Length;
				obj = new byte[num];
			}
			else if (object_2.GetType() == typeof(int[]))
			{
				num = ((int[])object_2).Length;
				obj = new int[num];
			}
			else if (object_2.GetType() == typeof(short[]))
			{
				num = ((short[])object_2).Length;
				obj = new short[num];
			}
			else if (!bool_0 && object_2.GetType() == typeof(float[]))
			{
				num = ((float[])object_2).Length;
				obj = new float[num];
			}
			else if (!bool_0 && object_2.GetType() == typeof(double[]))
			{
				num = ((double[])object_2).Length;
				obj = new double[num];
			}
			else if (!bool_0 && object_2.GetType() == typeof(bool[]))
			{
				num = ((bool[])object_2).Length;
				obj = new bool[num];
			}
			else if (!bool_0 && object_2.GetType() == typeof(long[]))
			{
				num = ((long[])object_2).Length;
				obj = new long[num];
			}
			else
			{
				if (bool_0 || object_2.GetType() != typeof(char[]))
				{
					return object_2;
				}
				num = ((char[])object_2).Length;
				obj = new char[num];
			}
			Array.Copy((Array)object_2, 0, (Array)obj, 0, num);
			return obj;
		}
	}
}
