using System;
using System.Windows.Forms;
using SystemTools.LowLevelHook;

namespace ns18
{
	public class EventArgs1 : EventArgs
	{
		public ModKeys modKeys_0;

		public Keys keys_0;

		public EventArgs1(ModKeys modKeys_1, Keys keys_1)
		{
			this.modKeys_0 = modKeys_1;
			this.keys_0 = keys_1;
		}

		public override bool Equals(object obj)
		{
			return this.modKeys_0 == ((EventArgs1)obj).modKeys_0 && this.keys_0 == ((EventArgs1)obj).keys_0;
		}

		public override int GetHashCode()
		{
			return 1;
		}

		public override string ToString()
		{
			return this.modKeys_0.ToString() + " + " + this.keys_0.ToString();
		}
	}
}
