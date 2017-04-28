using System;
using System.Collections;
using System.Collections.Generic;
using ns16;

namespace ns18
{
	public abstract class AbstractTreeNode1 : AbstractBaseTreeNode1, IComparable
	{
		public AbstractTreeNode1 method_1()
		{
			return (AbstractTreeNode1)Parent;
		}

		public virtual bool vmethod_7()
		{
			return method_1().vmethod_7();
		}

		public static int smethod_0(long long_0)
		{
			return (int)(4L - (long_0 & 3L)) & 3;
		}

		public virtual bool vmethod_8()
		{
			return method_1().vmethod_8();
		}

		public virtual void vmethod_9(bool bool_1)
		{
			method_1().vmethod_9(bool_1);
		}

		public virtual Dictionary<int, string> vmethod_10()
		{
			return method_1().vmethod_10();
		}

		public virtual void vmethod_11(Dictionary<int, string> dictionary_0)
		{
			method_1().vmethod_11(dictionary_0);
		}

		public AbstractBaseTreeNode1 method_2(int int_0)
		{
			return (AbstractBaseTreeNode1)Nodes[int_0];
		}

		public int method_3(AbstractBaseTreeNode1 class258_0)
		{
			return Nodes.Add(class258_0);
		}

		public virtual AbstractTreeNode1 vmethod_12(int int_0)
		{
			return method_1().vmethod_12(int_0);
		}

		public void method_4(Stream26 stream26_0)
		{
			vmethod_13(stream26_0);
			vmethod_0();
		}

		public abstract void vmethod_13(Stream26 stream26_0);

		public abstract void vmethod_14(Stream26 stream26_0);

		public T method_5<T>(T gparam_0) where T : AbstractTreeNode1
		{
			if (CompareTo(gparam_0) == 0)
			{
				return (T)this;
			}
			if (Nodes.Count != 0 && Nodes[0] is AbstractTreeNode1)
			{
				IEnumerator enumerator = Nodes.GetEnumerator();
				T result;
				try
				{
					while (enumerator.MoveNext())
					{
						AbstractTreeNode1 @class = (AbstractTreeNode1)enumerator.Current;
						T t;
						if ((t = @class.method_5(gparam_0)) != null)
						{
							result = t;
							return result;
						}
					}
					goto IL_84;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return result;
			}
			IL_84:
			return default(T);
		}

		public bool method_6<T>(ref T gparam_0) where T : AbstractTreeNode1
		{
			if (CompareTo(gparam_0) == 0)
			{
				gparam_0 = (T)this;
				return true;
			}
			if (Nodes.Count != 0 && Nodes[0] is AbstractTreeNode1)
			{
				IEnumerator enumerator = Nodes.GetEnumerator();
				bool result;
				try
				{
					while (enumerator.MoveNext())
					{
						AbstractTreeNode1 @class = (AbstractTreeNode1)enumerator.Current;
						if (@class.method_6(ref gparam_0))
						{
							result = true;
							return result;
						}
					}
					return false;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
				return result;
			}
			return false;
		}

		public abstract int CompareTo(object target);
	}
}
