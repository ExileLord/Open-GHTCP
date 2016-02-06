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
					return this.class13_0.float_0[this.int_0];
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			public Class14(Class13 class13_1)
			{
				this.class13_0 = class13_1;
				this.Reset();
			}

			public void Dispose()
			{
				this.class13_0 = null;
			}

			public bool MoveNext()
			{
				return this.int_0++ < this.int_1;
			}

			public void Reset()
			{
				this.int_0 = this.class13_0.int_1 - 1;
				this.int_1 = this.class13_0.int_1 + this.class13_0.int_2;
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

		private static Class13.Enum0 enum0_0 = Class13.Enum0.const_0;

		public float this[int int_4]
		{
			get
			{
				return this.float_0[this.int_1 + int_4];
			}
			set
			{
				this.float_0[this.int_1 + int_4] = value;
			}
		}

		public int method_0()
		{
			return this.int_1;
		}

		public void method_1(int int_4)
		{
			if (int_4 < 0 || int_4 >= this.float_0.Length)
			{
				throw new IndexOutOfRangeException("Channel: Offset is out of range -> " + int_4 + ".");
			}
			this.int_1 = int_4;
		}

		public int method_2()
		{
			return this.int_2;
		}

		public void method_3(int int_4)
		{
			if (int_4 <= 0 || this.int_1 + int_4 > this.float_0.Length)
			{
				throw new IndexOutOfRangeException("Channel: Length is out of range -> " + int_4 + ".");
			}
			this.int_2 = int_4;
		}

		public Class13(int int_4, float[] float_3) : this(int_4, float_3, 0, float_3.Length)
		{
		}

		public Class13(int int_4, float[] float_3, int int_5, int int_6)
		{
			this.int_0 = int_4;
			this.float_0 = float_3;
			this.method_1(int_5);
			this.method_3(int_6);
			this.method_4();
		}

		public virtual float vmethod_0(int int_4)
		{
			if (!this.bool_1)
			{
				return 1f;
			}
			if (this.bool_2)
			{
				this.float_1 = new float[this.list_0.Count];
				this.float_2 = new float[this.list_0.Count];
				for (int i = 0; i < this.list_0.Count; i++)
				{
					this.float_1[i] = this.list_0[i].float_0;
					this.float_2[i] = this.list_0[i].float_1;
				}
				this.bool_2 = false;
			}
			float num = Class15.smethod_3(this.float_1, this.float_2, ((float)int_4 - (float)this.method_0()) / (float)this.method_2());
			switch (Class13.enum0_0)
			{
			case Class13.Enum0.const_3:
				return (float)Math.Sqrt((double)num);
			case Class13.Enum0.const_1:
				return num * num;
			case Class13.Enum0.const_2:
				return num * num * num;
			}
			return num;
		}

		public virtual float vmethod_1(int int_4, float float_3, float float_4)
		{
			float num = this.vmethod_0(int_4);
			return float_4 * num + float_3 * (1f - num);
		}

		private void method_4()
		{
			if (this.list_0 == null)
			{
				this.list_0 = new List<Struct9>();
				this.vmethod_2();
			}
		}

		public virtual void vmethod_2()
		{
			this.list_0.Clear();
			this.list_0.Add(new Struct9(0f, 1f));
			this.list_0.Add(new Struct9(1f, 1f));
			this.bool_2 = true;
			this.bool_1 = false;
		}

		public bool method_5(int int_4)
		{
			return int_4 >= 0 && int_4 < this.method_2();
		}

		public virtual void vmethod_3(float float_3, int int_4)
		{
			if (this.method_5(int_4))
			{
				this.float_0[int_4] = float_3;
			}
		}

		public virtual float vmethod_4(int int_4)
		{
			if (this.method_5(int_4) && this.bool_0)
			{
				return this.float_0[int_4];
			}
			return 0f;
		}

		public IEnumerator<float> GetEnumerator()
		{
			return new Class13.Class14(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
