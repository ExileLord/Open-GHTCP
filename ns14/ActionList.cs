using ns16;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ns14
{
	public class ActionList
	{
		public delegate void Delegate6(object sender, EventArgs0 e);

		private ActionList.Delegate6 delegate6_0;

		private List<QbEditor> actionList;

		public void method_0(ActionList.Delegate6 delegate6_1)
		{
			ActionList.Delegate6 @delegate = this.delegate6_0;
			ActionList.Delegate6 delegate2;
			do
			{
				delegate2 = @delegate;
				ActionList.Delegate6 value = (ActionList.Delegate6)Delegate.Combine(delegate2, delegate6_1);
				@delegate = Interlocked.CompareExchange<ActionList.Delegate6>(ref this.delegate6_0, value, delegate2);
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
            foreach (QbEditor current in this.actionList)
			{
				int int_ = 100 * this.actionList.IndexOf(current) / this.actionList.Count;
				e = new EventArgs0(current.ToString() + " Processing...", int_);
				this.delegate6_0(this, e);
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
				this.delegate6_0(this, e);
			}
			e = new EventArgs0("", 100);
            this.delegate6_0(this, e);
        }
	}
}
