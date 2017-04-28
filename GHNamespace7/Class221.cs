using System.Collections.Generic;

namespace GHNamespace7
{
	public class Class221<T> : List<T>
	{
		public Class221()
		{
		}

		public Class221(IEnumerable<T> ienumerable0) : base(ienumerable0)
		{
		}

		public Class221(int int0) : base(int0)
		{
		}

		public virtual bool vmethod_0(T gparam0)
		{
			if (Contains(gparam0))
			{
				return false;
			}
			Add(gparam0);
			return true;
		}

		public virtual bool vmethod_1(ICollection<T> icollection0)
		{
			var result = false;
			if (icollection0 != null)
			{
				foreach (var current in icollection0)
				{
					result = vmethod_0(current);
				}
			}
			return result;
		}
	}
}
