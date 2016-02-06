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
			this.Dispose();
		}

		public void Dispose()
		{
			if (this.thread_0 != null)
			{
				try
				{
					this.bool_0 = true;
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class162.waveInReset(this.intptr_0);
					}
					this.method_1();
					this.thread_0.Join();
					this.delegate2_0 = null;
					this.method_0();
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class162.waveInClose(this.intptr_0);
					}
				}
				finally
				{
					this.thread_0 = null;
					this.intptr_0 = IntPtr.Zero;
				}
			}
			GC.SuppressFinalize(this);
		}

		private void method_0()
		{
			this.class156_1 = null;
			if (this.class156_0 != null)
			{
				Class156 @class = this.class156_0;
				this.class156_0 = null;
				Class156 class2 = @class;
				do
				{
					Class156 class3 = class2.class156_0;
					class2.Dispose();
					class2 = class3;
				}
				while (class2 != @class);
			}
		}

		private void method_1()
		{
			Class156 @class = this.class156_0;
			while (@class.class156_0 != this.class156_0)
			{
				@class.method_0();
				@class = @class.class156_0;
			}
		}
	}
}
