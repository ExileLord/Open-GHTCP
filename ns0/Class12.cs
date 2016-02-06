using ns1;
using System;
using System.Collections.Generic;

namespace ns0
{
	public class Class12 : List<Interface5>, Interface5
	{
		public Class12(Interface5[] interface5_0)
		{
			base.AddRange(interface5_0);
		}

		public virtual void imethod_0(Class13[] class13_0)
		{
			foreach (Interface5 current in this)
			{
				current.imethod_0(class13_0);
			}
		}
	}
}
