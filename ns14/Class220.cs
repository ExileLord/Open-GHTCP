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
				return method_0();
			}
		}

		public bool MoveNext()
		{
			var array = vmethod_0(false);
			return array.Length > 0;
		}

		public void Reset()
		{
			bool_0 = false;
		}

		public abstract int[] vmethod_0(bool bool_1);

		public Array method_0()
		{
			if (!bool_0)
			{
				throw new InvalidOperationException("CombinatorialBase collection must be Reset() before usage");
			}
			for (var i = 0; i < int_0.Length; i++)
			{
				var index = int_0[i];
				array_1.SetValue(array_0.GetValue(index), i);
			}
			return array_1;
		}
	}
}
