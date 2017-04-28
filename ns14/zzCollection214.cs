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
				if (dictionary_0.ContainsKey(key))
				{
					return dictionary_0[key];
				}
				return default(TValue);
			}
			set
			{
				if (dictionary_0.ContainsKey(key))
				{
					var arg_30_0 = list_1;
					var arg_30_1 = list_0.IndexOf(key);
					dictionary_0[key] = value;
					arg_30_0[arg_30_1] = value;
					return;
				}
				Add(key, value);
			}
		}

		public TValue this[int int_0]
		{
			get
			{
				if (dictionary_0.Count > int_0)
				{
					return list_1[int_0];
				}
				return default(TValue);
			}
			set
			{
				if (dictionary_0.Count > int_0)
				{
					var arg_30_0 = dictionary_0;
					var arg_30_1 = list_0[int_0];
					list_1[int_0] = value;
					arg_30_0[arg_30_1] = value;
				}
			}
		}

		public TKey this[TValue gparam_0]
		{
			get
			{
				return method_0(gparam_0);
			}
			set
			{
				if (dictionary_0.ContainsKey(value))
				{
					var arg_30_0 = list_1;
					var arg_30_1 = list_0.IndexOf(value);
					dictionary_0[value] = gparam_0;
					arg_30_0[arg_30_1] = gparam_0;
					return;
				}
				Add(value, gparam_0);
			}
		}

		public int Count
		{
			get
			{
				return dictionary_0.Count;
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
				return list_0;
			}
		}

		public ICollection<TValue> Values
		{
			get
			{
				return list_1;
			}
		}

		public bool ContainsKey(TKey key)
		{
			return dictionary_0.ContainsKey(key);
		}

		public void Add(TKey key, TValue value)
		{
			dictionary_0.Add(key, value);
			list_0.Add(key);
			list_1.Add(value);
		}

		public bool Remove(TKey key)
		{
			if (!dictionary_0.ContainsKey(key))
			{
				return false;
			}
			list_0.Remove(key);
			list_1.Remove(dictionary_0[key]);
			return dictionary_0.Remove(key);
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			if (!dictionary_0.ContainsKey(key))
			{
				value = default(TValue);
				return false;
			}
			value = dictionary_0[key];
			return true;
		}

		public TKey method_0(TValue gparam_0)
		{
			if (list_1.Contains(gparam_0))
			{
				return list_0[list_1.IndexOf(gparam_0)];
			}
			return default(TKey);
		}

		public IEnumerator GetEnumerator()
		{
			return new Class215<TKey, TValue>(list_0, list_1);
		}

		public void Add(KeyValuePair<TKey, TValue> item)
		{
			Add(item.Key, item.Value);
		}

		public void Add(ICollection<KeyValuePair<TKey, TValue>> icollection_0)
		{
			foreach (var current in icollection_0)
			{
				Add(current);
			}
		}

		public void Clear()
		{
			dictionary_0.Clear();
			list_0.Clear();
			list_1.Clear();
		}

		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			if (dictionary_0.ContainsKey(item.Key))
			{
				var tValue = dictionary_0[item.Key];
				return tValue.Equals(item.Value);
			}
			return false;
		}

		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
		{
			for (var i = 0; i < dictionary_0.Count; i++)
			{
				array[index + i] = new KeyValuePair<TKey, TValue>(list_0[i], list_1[i]);
			}
		}

		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return Contains(item) && Remove(item.Key);
		}

		IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
		{
			return new Class215<TKey, TValue>(list_0, list_1);
		}
	}
}
