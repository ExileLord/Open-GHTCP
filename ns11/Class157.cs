using ns1;
using System;

namespace ns11
{
	public class Class157 : IDisposable
	{
		private Class154 class154_0;

		public Stream14 stream14_0;

		~Class157()
		{
			this.Dispose();
		}

		public void method_0()
		{
			if (this.class154_0 != null)
			{
				try
				{
					this.class154_0.Dispose();
				}
				finally
				{
					this.class154_0 = null;
				}
			}
		}

		public void Dispose()
		{
			this.method_0();
			if (this.stream14_0 != null)
			{
				try
				{
					this.stream14_0.Close();
				}
				finally
				{
					this.stream14_0 = null;
				}
			}
		}
	}
}
