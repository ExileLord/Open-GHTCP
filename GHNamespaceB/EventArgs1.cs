using System;
using System.Windows.Forms;
using SystemTools.LowLevelHook;

namespace GHNamespaceB
{
	public class EventArgs1 : EventArgs
	{
		public ModKeys ModKeys0;

		public Keys Keys0;

		public EventArgs1(ModKeys modKeys1, Keys keys1)
		{
			ModKeys0 = modKeys1;
			Keys0 = keys1;
		}

		public override bool Equals(object obj)
		{
			return ModKeys0 == ((EventArgs1)obj).ModKeys0 && Keys0 == ((EventArgs1)obj).Keys0;
		}

		public override int GetHashCode()
		{
			return 1;
		}

		public override string ToString()
		{
			return ModKeys0 + " + " + Keys0;
		}
	}
}
