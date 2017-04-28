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
			if (!target.GetType().Equals(GetType()))
			{
				return -1;
			}
			if (((AbsTreeNode1_1)target).Text == Text)
			{
				return 0;
			}
			return 1;
		}

		public T[] method_7<T>()
		{
			return method_8<T>().ToArray();
		}

		public List<T> method_8<T>()
		{
			var list = new List<T>();
			if (Nodes[0] is AbstractTreeNode1)
			{
				var enumerator = Nodes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						var item = (T)enumerator.Current;
						list.Add(item);
					}
					return list;
				}
				finally
				{
					var disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			foreach (AbstractTreeNode2 @class in Nodes)
			{
				list.Add((T)@class.vmethod_7());
			}
			return list;
		}

		public override Color GetColor()
		{
			return GetColor2IfPrevNodeIsColor1(Color.PowderBlue, Color.PaleTurquoise);
		}

		public override string GetText()
		{
			return string.Concat(GetNodeText(), " (", Nodes.Count, ")");
		}
	}
}
