using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace ns18
{
	public abstract class AbsTreeNode1_1 : AbstractTreeNode1
	{
		public override int CompareTo(object target)
		{
			if (!target.GetType().Equals(base.GetType()))
			{
				return -1;
			}
			if (((AbsTreeNode1_1)target).Text == base.Text)
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
			if (base.Nodes[0] is AbstractTreeNode1)
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
			foreach (AbstractTreeNode2 @class in base.Nodes)
			{
				list.Add((T)((object)@class.vmethod_7()));
			}
			return list;
		}

		public override Color GetColor()
		{
			return base.GetColor2IfPrevNodeIsColor1(Color.PowderBlue, Color.PaleTurquoise);
		}

		public override string GetText()
		{
			return string.Concat(new object[]
			{
				this.GetNodeText(),
				" (",
				base.Nodes.Count,
				")"
			});
		}
	}
}
