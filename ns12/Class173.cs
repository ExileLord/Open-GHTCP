using System;
using ns1;
using ns8;

namespace ns12
{
	public class Class173 : Class172
	{
		public enum Enum26
		{
			const_0 = 1,
			const_1,
			const_2
		}

		public enum Enum27
		{
			const_0 = -2,
			const_1 = 1,
			const_2,
			const_3
		}

		private readonly Enum26 enum26_0;

		private readonly Enum27 enum27_0;

		private readonly bool bool_0;

		private readonly float float_0;

		private readonly float float_1;

		private readonly Struct11[] struct11_0;

		public Class173(Enum26 enum26_1, Enum27 enum27_1, float float_2, bool bool_1, Struct11[] struct11_1)
		{
			enum26_0 = enum26_1;
			enum27_0 = enum27_1;
			float_0 = float_2;
			float_1 = 1f - float_2;
			bool_0 = bool_1;
			struct11_0 = struct11_1;
		}

		public Class173(Enum26 enum26_1, Struct11[] struct11_1) : this(enum26_1, Enum27.const_1, 0f, false, struct11_1)
		{
		}

		private float method_0(float float_2)
		{
			switch (enum27_0)
			{
			case Enum27.const_0:
				return (float)Math.Sqrt(float_2);
			case Enum27.const_1:
				return float_2;
			case Enum27.const_2:
				return float_2 * float_2;
			case Enum27.const_3:
				return float_2 * float_2 * float_2;
			}
			return float_2;
		}

		public override void vmethod_0(Class13 class13_0)
		{
			var @struct = new Struct11(class13_0.int_0 + class13_0.method_0(), class13_0.int_0 + class13_0.method_0() + class13_0.method_2());
			if (struct11_0.Length != 0)
			{
				var array = struct11_0;
				for (var i = 0; i < array.Length; i++)
				{
					var struct2 = array[i];
					var struct3 = struct2.method_0(@struct);
					if (!struct3.method_1())
					{
						method_1(ref class13_0.float_0, struct3.method_2() - class13_0.int_0, struct3.method_3(), struct3.method_2() - struct2.method_2(), struct2.method_3());
					}
				}
				return;
			}
			method_1(ref class13_0.float_0, class13_0.method_0(), class13_0.method_2(), 0, class13_0.method_2());
		}

		private void method_1(ref float[] float_2, int int_0, int int_1, int int_2, float float_3)
		{
			switch (enum26_0)
			{
			case Enum26.const_0:
				try
				{
					for (var i = 0; i < int_1; i++)
					{
						float_2[int_0 + i] *= method_0((int_2 + i) / float_3) * float_1 + float_0;
					}
					if (bool_0)
					{
						for (var j = 0; j < int_0; j++)
						{
							float_2[j] *= float_0;
						}
					}
					return;
				}
				catch (IndexOutOfRangeException)
				{
					return;
				}
				break;
			case Enum26.const_1:
				break;
			case Enum26.const_2:
				goto IL_117;
			default:
				return;
			}
			try
			{
				for (var k = 0; k < int_1; k++)
				{
					float_2[int_0 + k] *= method_0(1f - (int_2 + k) / float_3) * float_1 + float_0;
				}
				if (bool_0)
				{
					for (var l = int_0 + int_1; l < float_2.Length; l++)
					{
						float_2[l] *= float_0;
					}
				}
				return;
			}
			catch (IndexOutOfRangeException)
			{
				return;
			}
			IL_117:
			var num = int_1 / 2;
			float_3 = num;
			var array = new float[float_2.Length - num];
			try
			{
				for (var m = 0; m < num; m++)
				{
					float_2[int_0 + m] = method_0((num - m) / float_3) * float_2[int_0 + m] + method_0(m / float_3) * float_2[int_0 + num + m];
				}
				for (var n = 0; n < int_0 + num; n++)
				{
					array[n] = float_2[n];
				}
				for (var num2 = int_0 + int_1; num2 < float_2.Length; num2++)
				{
					array[num2 - num] = float_2[num2];
				}
			}
			catch (IndexOutOfRangeException)
			{
			}
			float_2 = array;
		}
	}
}
