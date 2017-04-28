using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ns16
{
	public class GhtcpToolStripControlHost : ToolStripControlHost
	{
		private EventHandler eventHandler_0;

        protected override Size DefaultSize
		{
			get
			{
				return new Size(200, 16);
			}
		}

		public GhtcpToolStripControlHost() : base(smethod_0())
		{
		}

		public TrackBar method_0()
		{
			return Control as TrackBar;
		}

		private static Control smethod_0()
		{
			return new TrackBar
			{
				AutoSize = false,
				Height = 16
			};
		}

		public int method_1()
		{
			return method_0().Minimum;
		}

		public void method_2(int int_0)
		{
			method_0().Minimum = int_0;
		}

		public void method_3(int int_0)
		{
			method_0().Maximum = int_0;
		}

		public int method_4()
		{
			return method_0().Value;
		}

		public void method_5(int int_0)
		{
			method_0().Value = int_0;
		}

        protected override void OnSubscribeControlEvents(Control control)
		{
			base.OnSubscribeControlEvents(control);
			TrackBar trackBar = control as TrackBar;
			if (trackBar != null)
			{
				trackBar.ValueChanged += method_6;
			}
		}

        protected override void OnUnsubscribeControlEvents(Control control)
		{
			base.OnUnsubscribeControlEvents(control);
			TrackBar trackBar = control as TrackBar;
			if (trackBar != null)
			{
				trackBar.ValueChanged -= method_6;
			}
		}

		private void method_6(object sender, EventArgs e)
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(sender, e);
			}
		}

		public void method_7(EventHandler eventHandler_1)
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value = (EventHandler)Delegate.Combine(eventHandler2, eventHandler_1);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}
}
