using System;
using System.Diagnostics;
using System.Threading;
using ns9;

namespace ns22
{
	public class UnusedProcessOrThreadClass : IDisposable
	{
		private readonly string string_0;

		private readonly Process process_0;

		private bool bool_0;

		private readonly Thread thread_0;

		public void Dispose()
		{
			if (bool_0)
			{
				return;
			}
			bool_0 = true;
			process_0.StandardInput.Close();
			if (!thread_0.Join(10000))
			{
				Class355.interface15_0.imethod_1(string.Format("Failed to join '{0}'", string_0));
			}
			process_0.Dispose();
		}
	}
}
