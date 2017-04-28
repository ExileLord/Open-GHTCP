using System.Collections.Generic;
using ns1;

namespace ns0
{
	public class Class12 : List<Interface5>, Interface5
	{
		public Class12(Interface5[] interface5_0)
		{
			AddRange(interface5_0);
		}

		public virtual void imethod_0(Class13[] class13_0)
		{
			foreach (var current in this)
			{
				current.imethod_0(class13_0);
			}
		}
	}
}
