using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ns18
{
	public abstract class Class276 : Class259
	{
		public override int CompareTo(object target)
		{
			if (!target.GetType().Equals(base.GetType()))
			{
				return -1;
			}
			if (((Class276)target).Text == base.Text)
			{
				return 0;
			}
			return 1;
		}

		public T[] method_7<T>()
		{
			return this.method_8<T>().ToArray();
		}

		public List<T> method_8<T>()
		{
			List<T> list = new List<T>();
			if (base.Nodes[0] is Class259)
			{
				IEnumerator enumerator = base.Nodes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						T item = (T)((object)enumerator.Current);
						list.Add(item);
					}
					return list;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			foreach (Class310 @class in base.Nodes)
			{
				list.Add((T)((object)@class.vmethod_7()));
			}
			return list;
		}

		public override Color vmethod_6()
		{
			return base.method_0(Color.PowderBlue, Color.PaleTurquoise);
		}

		public override string vmethod_3()
		{
			return string.Concat(new object[]
			{
				this.vmethod_5(),
				" (",
				base.Nodes.Count,
				")"
			});
		}
	}
}
