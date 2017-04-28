using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using SystemTools.LowLevelHook;
using GHNamespaceB;

namespace GHNamespace9
{
	public class EventHandlerClass1 : IDisposable
	{
		private class HandlerBuddy : NativeWindow, IDisposable
		{
			private static readonly int Int0 = 786;

			private EventHandler<EventArgs1> _eventHandler0;

			public HandlerBuddy()
			{
				CreateHandle(new CreateParams());
			}

            protected override void WndProc(ref Message m)
			{
				base.WndProc(ref m);
				if (m.Msg == Int0)
				{
					var keys = (Keys)((int)m.LParam >> 16 & 65535);
					var modKeys = (ModKeys)((int)m.LParam & 65535);
					if (_eventHandler0 != null)
					{
						_eventHandler0(this, new EventArgs1(modKeys, keys));
					}
				}
			}

			public void method_0(EventHandler<EventArgs1> eventHandler1)
			{
				var eventHandler = _eventHandler0;
				EventHandler<EventArgs1> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					var value = (EventHandler<EventArgs1>)Delegate.Combine(eventHandler2, eventHandler1);
					eventHandler = Interlocked.CompareExchange(ref _eventHandler0, value, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}

			public void Dispose()
			{
				DestroyHandle();
			}
		}

		private readonly HandlerBuddy _class2340 = new HandlerBuddy();

		private readonly Dictionary<EventArgs1, int> _dictionary0 = new Dictionary<EventArgs1, int>();

		private EventHandler<EventArgs1> _eventHandler0;

		public EventHandlerClass1()
		{
			var arg320 = _class2340;
			EventHandler<EventArgs1> eventHandler = method_1;
			arg320.method_0(eventHandler);
		}

		[DllImport("user32.dll")]
		private static extern bool UnregisterHotKey(IntPtr intptr0, int int0);

		public void method_0()
		{
			foreach (var current in _dictionary0.Values)
			{
				UnregisterHotKey(_class2340.Handle, current);
			}
			_dictionary0.Clear();
		}

		public void Dispose()
		{
			method_0();
			_class2340.Dispose();
		}

		[CompilerGenerated]
		private void method_1(object sender, EventArgs1 e)
		{
			if (_eventHandler0 != null)
			{
				_eventHandler0(this, e);
			}
		}
	}
}
