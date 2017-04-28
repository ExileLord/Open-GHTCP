using System;
using System.Threading;

namespace ns11
{
	public class Class154 : IDisposable
	{
		private IntPtr intptr_0;

		private Class156 class156_0;

		private Class156 class156_1;

		private Thread thread_0;

		private Delegate2 delegate2_0;

		private bool bool_0;

		~Class154()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (thread_0 != null)
			{
				try
				{
					bool_0 = true;
					if (intptr_0 != IntPtr.Zero)
					{
						Class162.waveInReset(intptr_0);
					}
					method_1();
					thread_0.Join();
					delegate2_0 = null;
					method_0();
					if (intptr_0 != IntPtr.Zero)
					{
						Class162.waveInClose(intptr_0);
					}
				}
				finally
				{
					thread_0 = null;
					intptr_0 = IntPtr.Zero;
				}
			}
			GC.SuppressFinalize(this);
		}

		private void method_0()
		{
			class156_1 = null;
			if (class156_0 != null)
			{
				var @class = class156_0;
				class156_0 = null;
				var class2 = @class;
				do
				{
					var class3 = class2.class156_0;
					class2.Dispose();
					class2 = class3;
				}
				while (class2 != @class);
			}
		}

		private void method_1()
		{
			var @class = class156_0;
			while (@class.class156_0 != class156_0)
			{
				@class.method_0();
				@class = @class.class156_0;
			}
		}
	}
}
