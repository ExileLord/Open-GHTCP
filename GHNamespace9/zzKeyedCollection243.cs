using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GHNamespace9
{
	public class ZzMap243<TKey, TValue> : KeyedCollection<TKey, KeyValuePair<TKey, TValue>>
	{
        protected override TKey GetKeyForItem(KeyValuePair<TKey, TValue> item)
		{
			return item.Key;
		}
	}
}
