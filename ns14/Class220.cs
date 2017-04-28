using System;
using System.Collections;

namespace ns14
{
	public abstract class Class220 : IEnumerator
	{
		public Array Array0;

		public int[] Int0;

		public Array Array1;

		public bool Bool0;

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
			Bool0 = false;
		}

		public abstract int[] vmethod_0(bool bool1);

		public Array method_0()
		{
			if (!Bool0)
			{
				throw new InvalidOperationException("CombinatorialBase collection must be Reset() before usage");
			}
			for (var i = 0; i < Int0.Length; i++)
			{
				var index = Int0[i];
				Array1.SetValue(Array0.GetValue(index), i);
			}
			return Array1;
		}
	}
}
