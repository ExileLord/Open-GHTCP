using System;
using System.Collections;
using System.Collections.Generic;

namespace ns14
{
	public class zzCollection214<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, ICollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, IEnumerable
	{
		private readonly Dictionary<TKey, TValue> dictionary_0 = new Dictionary<TKey, TValue>();

		private readonly List<TKey> list_0 = new List<TKey>();

		private readonly List<TValue> list_1 = new List<TValue>();

		public TValue this[TKey key]
		{
			get
			{
				if (this.dictionary_0.ContainsKey(key))
				{
					return this.dictionary_0[key];
				}
				return default(TValue);
			}
			set
			{
				if (this.dictionary_0.ContainsKey(key))
				{
					List<TValue> arg_30_0 = this.list_1;
					int arg_30_1 = this.list_0.IndexOf(key);
					this.dictionary_0[key] = value;
					arg_30_0[arg_30_1] = value;
					return;
				}
				this.Add(key, value);
			}
		}

		public TValue this[int int_0]
		{
			get
			{
				if (this.dictionary_0.Count > int_0)
				{
					return this.list_1[int_0];
				}
				return default(TValue);
			}
			set
			{
				if (this.dictionary_0.Count > int_0)
				{
					Dictionary<TKey, TValue> arg_30_0 = this.dictionary_0;
					TKey arg_30_1 = this.list_0[int_0];
					this.list_1[int_0] = value;
					arg_30_0[arg_30_1] = value;
				}
			}
		}

		public TKey this[TValue gparam_0]
		{
			get
			{
				return this.method_0(gparam_0);
			}
			set
			{
				if (this.dictionary_0.ContainsKey(value))
				{
					List<TValue> arg_30_0 = this.list_1;
					int arg_30_1 = this.list_0.IndexOf(value);
					this.dictionary_0[value] = gparam_0;
					arg_30_0[arg_30_1] = gparam_0;
					return;
				}
				this.Add(value, gparam_0);
			}
		}

		public int Count
		{
			get
			{
				return this.dictionary_0.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public ICollection<TKey> Keys
		{
			get
			{
				return this.list_0;
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				return this.list_1;
			}
		}

		public bool ContainsKey(TKey key)
		{
			return this.dictionary_0.ContainsKey(key);
		}

		public void Add(TKey key, TValue value)
		{
			this.dictionary_0.Add(key, value);
			this.list_0.Add(key);
			this.list_1.Add(value);
		}

		public bool Remove(TKey key)
		{
			if (!this.dictionary_0.ContainsKey(key))
			{
				return false;
			}
			this.list_0.Remove(key);
			this.list_1.Remove(this.dictionary_0[key]);
			return this.dictionary_0.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!this.dictionary_0.ContainsKey(key))
			{
				value = default(TValue);
				return false;
			}
			value = this.dictionary_0[key];
			return true;
		}

		public TKey method_0(TValue gparam_0)
		{
			if (this.list_1.Contains(gparam_0))
			{
				return this.list_0[this.list_1.IndexOf(gparam_0)];
			}
			return default(TKey);
		}

		public IEnumerator GetEnumerator()
		{
			return new Class215<TKey, TValue>(this.list_0, this.list_1);
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			this.Add(item.Key, item.Value);
		}

		public void Add(ICollection<KeyValuePair<TKey, TValue>> icollection_0)
		{
			foreach (KeyValuePair<TKey, TValue> current in icollection_0)
			{
				this.Add(current);
			}
		}

		public void Clear()
		{
			this.dictionary_0.Clear();
			this.list_0.Clear();
			this.list_1.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			if (this.dictionary_0.ContainsKey(item.Key))
			{
				TValue tValue = this.dictionary_0[item.Key];
				return tValue.Equals(item.Value);
			}
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			for (int i = 0; i < this.dictionary_0.Count; i++)
			{
				array[index + i] = new KeyValuePair<TKey, TValue>(this.list_0[i], this.list_1[i]);
			}
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return this.Contains(item) && this.Remove(item.Key);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return new Class215<TKey, TValue>(this.list_0, this.list_1);
		}
	}
}
