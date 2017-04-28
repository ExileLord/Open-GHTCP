using System;
using System.Collections.Generic;

namespace ns16
{
	public class ByteList : List<byte>, IDisposable
	{
		public void Dispose()
		{
			Clear();
		}
	}
}
