using System.Collections;
using System.Collections.Generic;

namespace ns22
{
	public class zzPairKeyDictionary : IEnumerable, IEnumerable<KeyValuePair<string, EmptyAbstractClass1>>
	{
		private readonly Dictionary<string, EmptyAbstractClass1> dictionary_0;

		public EmptyAbstractClass1 this[string string_0]
		{
			get
			{
				return dictionary_0[string_0.ToLower()];
			}
		}

		public IEnumerator GetEnumerator()
		{
			return dictionary_0.GetEnumerator();
		}

		IEnumerator<KeyValuePair<string, EmptyAbstractClass1>> IEnumerable<KeyValuePair<string, EmptyAbstractClass1>>.GetEnumerator()
		{
			return dictionary_0.GetEnumerator();
		}
	}
}
