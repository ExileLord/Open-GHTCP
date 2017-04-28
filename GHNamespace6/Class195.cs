using System;
using GHNamespace5;

namespace GHNamespace6
{
	public class Class195 : IDisposable
	{
		private string _string0 = string.Empty;

		private string _string1 = string.Empty;

		private Stream21 _stream210;

		private Stream24 _stream240;

		private bool _bool0;

	    public virtual void vmethod_0(bool bool1)
		{
			if (!_bool0)
			{
				_bool0 = true;
				if (bool1)
				{
					if (_stream240 != null)
					{
						_stream240.Flush();
						_stream240.Close();
					}
					if (_stream210 != null)
					{
						_stream210.Close();
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
