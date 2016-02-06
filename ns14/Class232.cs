using ns16;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ns14
{
	public class Class232
	{
		public delegate void Delegate6(object sender, EventArgs0 e);

		private Class232.Delegate6 delegate6_0;

		private List<Class245> list_0;

		public void method_0(Class232.Delegate6 delegate6_1)
		{
			Class232.Delegate6 @delegate = this.delegate6_0;
			Class232.Delegate6 delegate2;
			do
			{
				delegate2 = @delegate;
				Class232.Delegate6 value = (Class232.Delegate6)Delegate.Combine(delegate2, delegate6_1);
				@delegate = Interlocked.CompareExchange<Class232.Delegate6>(ref this.delegate6_0, value, delegate2);
			}
			while (@delegate != delegate2);
		}

		public Class232(List<Class245> list_1)
		{
			this.list_0 = list_1;
		}

		public void method_1()
		{
			EventArgs0 e;
			foreach (Class245 current in this.list_0)
			{
				int int_ = 100 * this.list_0.IndexOf(current) / this.list_0.Count;
				e = new EventArgs0(current.ToString() + " Processing...", int_);
				this.delegate6_0(this, e);
				string string_;
				using (new Class217(current.ToString()))
				{
					if (current.method_0())
					{
						string_ = "DONE!\n";
					}
					else
					{
						string_ = "FAILED!\n";
					}
				}
				e = new EventArgs0(string_, int_);
				this.delegate6_0(this, e);
			}
			e = new EventArgs0("", 100);
			this.delegate6_0(this, e);
		}
	}
}
