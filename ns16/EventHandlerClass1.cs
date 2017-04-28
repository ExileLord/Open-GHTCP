using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using SystemTools.LowLevelHook;
using ns18;

namespace ns16
{
	public class EventHandlerClass1 : IDisposable
	{
		private class HandlerBuddy : NativeWindow, IDisposable
		{
			private static int int_0 = 786;

			private EventHandler<EventArgs1> eventHandler_0;

			public HandlerBuddy()
			{
				CreateHandle(new CreateParams());
			}

            protected override void WndProc(ref Message m)
			{
				base.WndProc(ref m);
				if (m.Msg == int_0)
				{
					Keys keys_ = (Keys)((int)m.LParam >> 16 & 65535);
					ModKeys modKeys_ = (ModKeys)((int)m.LParam & 65535);
					if (eventHandler_0 != null)
					{
						eventHandler_0(this, new EventArgs1(modKeys_, keys_));
					}
				}
			}

			public void method_0(EventHandler<EventArgs1> eventHandler_1)
			{
				EventHandler<EventArgs1> eventHandler = eventHandler_0;
				EventHandler<EventArgs1> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs1> value = (EventHandler<EventArgs1>)Delegate.Combine(eventHandler2, eventHandler_1);
					eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}

			public void Dispose()
			{
				DestroyHandle();
			}
		}

		private HandlerBuddy class234_0 = new HandlerBuddy();

		private Dictionary<EventArgs1, int> dictionary_0 = new Dictionary<EventArgs1, int>();

		private EventHandler<EventArgs1> eventHandler_0;

		public EventHandlerClass1()
		{
			HandlerBuddy arg_32_0 = class234_0;
			EventHandler<EventArgs1> eventHandler_ = method_1;
			arg_32_0.method_0(eventHandler_);
		}

		[DllImport("user32.dll")]
		private static extern bool UnregisterHotKey(IntPtr intptr_0, int int_0);

		public void method_0()
		{
			foreach (int current in dictionary_0.Values)
			{
				UnregisterHotKey(class234_0.Handle, current);
			}
			dictionary_0.Clear();
		}

		public void Dispose()
		{
			method_0();
			class234_0.Dispose();
		}

		[CompilerGenerated]
		private void method_1(object sender, EventArgs1 e)
		{
			if (eventHandler_0 != null)
			{
				eventHandler_0(this, e);
			}
		}
	}
}
