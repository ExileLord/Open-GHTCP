using System.Collections;
using System.Collections.Generic;

namespace GHNamespaceG
{
	public class ZzPairKeyDictionary : IEnumerable, IEnumerable<KeyValuePair<string, EmptyAbstractClass1>>
	{
		private readonly Dictionary<string, EmptyAbstractClass1> _dictionary0;

		public EmptyAbstractClass1 this[string string0] => _dictionary0[string0.ToLower()];

	    public IEnumerator GetEnumerator()
		{
			return _dictionary0.GetEnumerator();
		}

		IEnumerator<KeyValuePair<string, EmptyAbstractClass1>> IEnumerable<KeyValuePair<string, EmptyAbstractClass1>>.GetEnumerator()
		{
			return _dictionary0.GetEnumerator();
		}
	}
}
