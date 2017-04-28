using System;
using System.Collections.Generic;

namespace GHNamespace9
{
	public class ByteList : List<byte>, IDisposable
	{
		public void Dispose()
		{
			Clear();
		}
	}
}
