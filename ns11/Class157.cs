using System;
using ns1;

namespace ns11
{
	public class Class157 : IDisposable
	{
		private Class154 class154_0;

		public Stream14 stream14_0;

		~Class157()
		{
			Dispose();
		}

		public void method_0()
		{
			if (class154_0 != null)
			{
				try
				{
					class154_0.Dispose();
				}
				finally
				{
					class154_0 = null;
				}
			}
		}

		public void Dispose()
		{
			method_0();
			if (stream14_0 != null)
			{
				try
				{
					stream14_0.Close();
				}
				finally
				{
					stream14_0 = null;
				}
			}
		}
	}
}
