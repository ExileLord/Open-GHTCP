using System;
using System.Collections.Generic;

namespace ns14
{
	public class Class221<T> : List<T>
	{
		public Class221()
		{
		}

		public Class221(IEnumerable<T> ienumerable_0) : base(ienumerable_0)
		{
		}

		public Class221(int int_0) : base(int_0)
		{
		}

		public virtual bool vmethod_0(T gparam_0)
		{
			if (base.Contains(gparam_0))
			{
				return false;
			}
			base.Add(gparam_0);
			return true;
		}

		public virtual bool vmethod_1(ICollection<T> icollection_0)
		{
			bool result = false;
			if (icollection_0 != null)
			{
				foreach (T current in icollection_0)
				{
					result = this.vmethod_0(current);
				}
			}
			return result;
		}
	}
}
