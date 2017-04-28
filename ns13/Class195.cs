using System;
using ns12;

namespace ns13
{
	public class Class195 : IDisposable
	{
		private string string_0 = string.Empty;

		private string string_1 = string.Empty;

		private Stream21 stream21_0;

		private Stream24 stream24_0;

		private bool bool_0;

	    public virtual void vmethod_0(bool bool_1)
		{
			if (!bool_0)
			{
				bool_0 = true;
				if (bool_1)
				{
					if (stream24_0 != null)
					{
						stream24_0.Flush();
						stream24_0.Close();
					}
					if (stream21_0 != null)
					{
						stream21_0.Close();
					}
				}
			}
		}

		public virtual void vmethod_1()
		{
			vmethod_0(true);
			GC.SuppressFinalize(this);
		}

		~Class195()
		{
			vmethod_0(false);
		}

		void IDisposable.Dispose()
		{
			vmethod_1();
		}
	}
}
