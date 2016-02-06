using System;
using System.Collections;

namespace ns14
{
	public abstract class Class220 : IEnumerator
	{
		public Array array_0;

		public int[] int_0;

		public Array array_1;

		public bool bool_0;

		public object Current
		{
			get
			{
				return this.method_0();
			}
		}

		public bool MoveNext()
		{
			int[] array = this.vmethod_0(false);
			return array.Length > 0;
		}

		public void Reset()
		{
			this.bool_0 = false;
		}

		public abstract int[] vmethod_0(bool bool_1);

		public Array method_0()
		{
			if (!this.bool_0)
			{
				throw new InvalidOperationException("CombinatorialBase collection must be Reset() before usage");
			}
			for (int i = 0; i < this.int_0.Length; i++)
			{
				int index = this.int_0[i];
				this.array_1.SetValue(this.array_0.GetValue(index), i);
			}
			return this.array_1;
		}
	}
}
