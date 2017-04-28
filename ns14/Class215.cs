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
				return new KeyValuePair<TKey, TValue>(list_0[int_0], list_1[int_0]);
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		public Class215(List<TKey> list_2, List<TValue> list_3)
		{
			list_0 = list_2;
			list_1 = list_3;
		}

		public void Dispose()
		{
			list_0 = null;
			list_1 = null;
		}

		public bool MoveNext()
		{
			int_0++;
			return int_0 < list_0.Count;
		}

		public void Reset()
		{
			int_0 = -1;
		}
	}
}
