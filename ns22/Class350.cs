using System;
using System.Collections;
using System.Collections.Generic;

namespace ns22
{
	public class Class350 : IEnumerable, IEnumerable<KeyValuePair<string, Class341>>
	{
		private readonly Dictionary<string, Class341> dictionary_0;

		public Class341 this[string string_0]
		{
			get
			{
				return this.dictionary_0[string_0.ToLower()];
			}
		}

		public IEnumerator GetEnumerator()
		{
			return this.dictionary_0.GetEnumerator();
		}

		IEnumerator<KeyValuePair<string, Class341>> IEnumerable<KeyValuePair<string, Class341>>.GetEnumerator()
		{
			return this.dictionary_0.GetEnumerator();
		}
	}
}
