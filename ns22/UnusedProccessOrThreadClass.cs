using System;
using System.Diagnostics;
using System.Threading;
using ns9;

namespace ns22
{
	public class UnusedProcessOrThreadClass : IDisposable
	{
		private readonly string _string0;

		private readonly Process _process0;

		private bool _bool0;

		private readonly Thread _thread0;

		public void Dispose()
		{
			if (_bool0)
			{
				return;
			}
			_bool0 = true;
			_process0.StandardInput.Close();
			if (!_thread0.Join(10000))
			{
				Class355.Interface150.imethod_1(string.Format("Failed to join '{0}'", _string0));
			}
			_process0.Dispose();
		}
	}
}
