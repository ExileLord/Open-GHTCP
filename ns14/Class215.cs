using System;
using System.Collections;
using System.Collections.Generic;

namespace ns14
{
	public class Class215<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
	{
		private List<TKey> list_0;

		private List<TValue> list_1;

		private int int_0 = -1;

		public KeyValuePair<TKey, TValue> Current
		{
			get
			{
				return new KeyValuePair<TKey, TValue>(this.list_0[this.int_0], this.list_1[this.int_0]);
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return this.Current;
			}
		}

		public Class215(List<TKey> list_2, List<TValue> list_3)
		{
			this.list_0 = list_2;
			this.list_1 = list_3;
		}

		public void Dispose()
		{
			this.list_0 = null;
			this.list_1 = null;
		}

		public bool MoveNext()
		{
			this.int_0++;
			return this.int_0 < this.list_0.Count;
		}

		public void Reset()
		{
			this.int_0 = -1;
		}
	}
}
