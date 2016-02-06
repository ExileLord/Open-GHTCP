using System;
using System.Collections.Generic;

namespace ns16
{
	public class Class235 : List<byte>, IDisposable
	{
		public void Dispose()
		{
			base.Clear();
		}
	}
}
