using ns12;
using System;

namespace ns13
{
	public class Class195 : IDisposable
	{
		private string string_0 = string.Empty;

		private string string_1 = string.Empty;

		private Stream21 stream21_0;

		private Stream24 stream24_0;

		private bool bool_0;

		public Class195()
		{
		}

		public virtual void vmethod_0(bool bool_1)
		{
			if (!this.bool_0)
			{
				this.bool_0 = true;
				if (bool_1)
				{
					if (this.stream24_0 != null)
					{
						this.stream24_0.Flush();
						this.stream24_0.Close();
					}
					if (this.stream21_0 != null)
					{
						this.stream21_0.Close();
					}
				}
			}
		}

		public virtual void vmethod_1()
		{
			this.vmethod_0(true);
			GC.SuppressFinalize(this);
		}

		~Class195()
		{
			this.vmethod_0(false);
		}

		void IDisposable.Dispose()
		{
			this.vmethod_1();
		}
	}
}
