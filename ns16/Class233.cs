using ns18;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using SystemTools.LowLevelHook;

namespace ns16
{
	public class Class233 : IDisposable
	{
		private class Class234 : NativeWindow, IDisposable
		{
			private static int int_0 = 786;

			private EventHandler<EventArgs1> eventHandler_0;

			public Class234()
			{
				this.CreateHandle(new CreateParams());
			}

            protected override void WndProc(ref Message m)
			{
				base.WndProc(ref m);
				if (m.Msg == Class233.Class234.int_0)
				{
					Keys keys_ = (Keys)((int)m.LParam >> 16 & 65535);
					ModKeys modKeys_ = (ModKeys)((int)m.LParam & 65535);
					if (this.eventHandler_0 != null)
					{
						this.eventHandler_0(this, new EventArgs1(modKeys_, keys_));
					}
				}
			}

			public void method_0(EventHandler<EventArgs1> eventHandler_1)
			{
				EventHandler<EventArgs1> eventHandler = this.eventHandler_0;
				EventHandler<EventArgs1> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs1> value = (EventHandler<EventArgs1>)Delegate.Combine(eventHandler2, eventHandler_1);
					eventHandler = Interlocked.CompareExchange<EventHandler<EventArgs1>>(ref this.eventHandler_0, value, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}

			public void Dispose()
			{
				this.DestroyHandle();
			}
		}

		private Class233.Class234 class234_0 = new Class233.Class234();

		private Dictionary<EventArgs1, int> dictionary_0 = new Dictionary<EventArgs1, int>();

		private EventHandler<EventArgs1> eventHandler_0;

		public Class233()
		{
			Class233.Class234 arg_32_0 = this.class234_0;
			EventHandler<EventArgs1> eventHandler_ = new EventHandler<EventArgs1>(this.method_1);
			arg_32_0.method_0(eventHandler_);
		}

		[DllImport("user32.dll")]
		private static extern bool UnregisterHotKey(IntPtr intptr_0, int int_0);

		public void method_0()
		{
			foreach (int current in this.dictionary_0.Values)
			{
				Class233.UnregisterHotKey(this.class234_0.Handle, current);
			}
			this.dictionary_0.Clear();
		}

		public void Dispose()
		{
			this.method_0();
			this.class234_0.Dispose();
		}

		[CompilerGenerated]
		private void method_1(object sender, EventArgs1 e)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, e);
			}
		}
	}
}
