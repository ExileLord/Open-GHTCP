using System;
using System.Collections;
using System.Collections.Generic;

namespace ns1
{
	public class Class13 : IEnumerable<float>, IEnumerable
	{
		public enum Enum0
		{
			const_0 = 1,
			const_1,
			const_2,
			const_3 = -1
		}

		public class Class14 : IEnumerator<float>, IEnumerator, IDisposable
		{
			private Class13 class13_0;

			private int int_0;

			private int int_1;

			public float Current
			{
				get
				{
					return class13_0.float_0[int_0];
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return Current;
				}
			}

			public Class14(Class13 class13_1)
			{
				class13_0 = class13_1;
				Reset();
			}

			public void Dispose()
			{
				class13_0 = null;
			}

			public bool MoveNext()
			{
				return int_0++ < int_1;
			}

			public void Reset()
			{
				int_0 = class13_0.int_1 - 1;
				int_1 = class13_0.int_1 + class13_0.int_2;
			}
		}

		public float[] float_0;

		public int int_0;

		private int int_1;

		private int int_2;

		public bool bool_0 = true;

		private List<Struct9> list_0;

		private bool bool_1;

		private int int_3 = -1;

		private float[] float_1;

		private float[] float_2;

		private bool bool_2;

		private static Enum0 enum0_0 = Enum0.const_0;

		public float this[int int_4]
		{
			get
			{
				return float_0[int_1 + int_4];
			}
			set
			{
				float_0[int_1 + int_4] = value;
			}
		}

		public int method_0()
		{
			return int_1;
		}

		public void method_1(int int_4)
		{
			if (int_4 < 0 || int_4 >= float_0.Length)
			{
				throw new IndexOutOfRangeException("Channel: Offset is out of range -> " + int_4 + ".");
			}
			int_1 = int_4;
		}

		public int method_2()
		{
			return int_2;
		}

		public void method_3(int int_4)
		{
			if (int_4 <= 0 || int_1 + int_4 > float_0.Length)
			{
				throw new IndexOutOfRangeException("Channel: Length is out of range -> " + int_4 + ".");
			}
			int_2 = int_4;
		}

		public Class13(int int_4, float[] float_3) : this(int_4, float_3, 0, float_3.Length)
		{
		}

		public Class13(int int_4, float[] float_3, int int_5, int int_6)
		{
			int_0 = int_4;
			float_0 = float_3;
			method_1(int_5);
			method_3(int_6);
			method_4();
		}

		public virtual float vmethod_0(int int_4)
		{
			if (!bool_1)
			{
				return 1f;
			}
			if (bool_2)
			{
				float_1 = new float[list_0.Count];
				float_2 = new float[list_0.Count];
				for (var i = 0; i < list_0.Count; i++)
				{
					float_1[i] = list_0[i].float_0;
					float_2[i] = list_0[i].float_1;
				}
				bool_2 = false;
			}
			var num = Class15.smethod_3(float_1, float_2, (int_4 - (float)method_0()) / method_2());
			switch (enum0_0)
			{
			case Enum0.const_3:
				return (float)Math.Sqrt(num);
			case Enum0.const_1:
				return num * num;
			case Enum0.const_2:
				return num * num * num;
			}
			return num;
		}

		public virtual float vmethod_1(int int_4, float float_3, float float_4)
		{
			var num = vmethod_0(int_4);
			return float_4 * num + float_3 * (1f - num);
		}

		private void method_4()
		{
			if (list_0 == null)
			{
				list_0 = new List<Struct9>();
				vmethod_2();
			}
		}

		public virtual void vmethod_2()
		{
			list_0.Clear();
			list_0.Add(new Struct9(0f, 1f));
			list_0.Add(new Struct9(1f, 1f));
			bool_2 = true;
			bool_1 = false;
		}

		public bool method_5(int int_4)
		{
			return int_4 >= 0 && int_4 < method_2();
		}

		public virtual void vmethod_3(float float_3, int int_4)
		{
			if (method_5(int_4))
			{
				float_0[int_4] = float_3;
			}
		}

		public virtual float vmethod_4(int int_4)
		{
			if (method_5(int_4) && bool_0)
			{
				return float_0[int_4];
			}
			return 0f;
		}

		public IEnumerator<float> GetEnumerator()
		{
			return new Class14(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
