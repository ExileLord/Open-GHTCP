using System;
using System.Collections.Generic;
using System.Threading;
using ns16;

namespace ns14
{
	public class ActionList
	{
		public delegate void Delegate6(object sender, EventArgs0 e);

		private Delegate6 delegate6_0;

		private readonly List<QbEditor> actionList;

		public void method_0(Delegate6 delegate6_1)
		{
			var @delegate = delegate6_0;
			Delegate6 delegate2;
			do
			{
				delegate2 = @delegate;
				var value = (Delegate6)Delegate.Combine(delegate2, delegate6_1);
				@delegate = Interlocked.CompareExchange(ref delegate6_0, value, delegate2);
			}
			while (@delegate != delegate2);
		}

		public ActionList(List<QbEditor> actionList)
		{
			this.actionList = actionList;
		}

		public void method_1()
		{
			EventArgs0 e;
            foreach (var current in actionList)
			{
				var int_ = 100 * actionList.IndexOf(current) / actionList.Count;
				e = new EventArgs0(current + " Processing...", int_);
				delegate6_0(this, e);
                string finalStatus;
                using (new Class217(current.ToString()))
				{
					if (current.method_0())
					{
						finalStatus = "DONE!\n";
					}
					else
					{
						finalStatus = "FAILED!\n";
					}
				}
				e = new EventArgs0(finalStatus, int_);
				delegate6_0(this, e);
			}
			e = new EventArgs0("", 100);
            delegate6_0(this, e);
        }
	}
}
