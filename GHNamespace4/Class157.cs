using System;
using GHNamespace2;

namespace GHNamespace4
{
	public class Class157 : IDisposable
	{
		private Class154 _class1540;

		public Stream14 Stream140;

		~Class157()
		{
			Dispose();
		}

		public void method_0()
		{
			if (_class1540 != null)
			{
				try
				{
					_class1540.Dispose();
				}
				finally
				{
					_class1540 = null;
				}
			}
		}

		public void Dispose()
		{
			method_0();
			if (Stream140 != null)
			{
				try
				{
					Stream140.Close();
				}
				finally
				{
					Stream140 = null;
				}
			}
		}
	}
}
