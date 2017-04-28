using System;
using System.Collections.Generic;
using GHNamespace9;

namespace GHNamespaceB
{
    public abstract class AbstractTreeNode1 : AbstractBaseTreeNode1, IComparable
    {
        public AbstractTreeNode1 method_1()
        {
            return (AbstractTreeNode1) Parent;
        }

        public virtual bool vmethod_7()
        {
            return method_1().vmethod_7();
        }

        public static int smethod_0(long long0)
        {
            return (int) (4L - (long0 & 3L)) & 3;
        }

        public virtual bool vmethod_8()
        {
            return method_1().vmethod_8();
        }

        public virtual void vmethod_9(bool bool1)
        {
            method_1().vmethod_9(bool1);
        }

        public virtual Dictionary<int, string> vmethod_10()
        {
            return method_1().vmethod_10();
        }

        public virtual void vmethod_11(Dictionary<int, string> dictionary0)
        {
            method_1().vmethod_11(dictionary0);
        }

        public AbstractBaseTreeNode1 method_2(int int0)
        {
            return (AbstractBaseTreeNode1) Nodes[int0];
        }

        public int method_3(AbstractBaseTreeNode1 class2580)
        {
            return Nodes.Add(class2580);
        }

        public virtual AbstractTreeNode1 vmethod_12(int int0)
        {
            return method_1().vmethod_12(int0);
        }

        public void method_4(Stream26 stream260)
        {
            vmethod_13(stream260);
            vmethod_0();
        }

        public abstract void vmethod_13(Stream26 stream260);

        public abstract void vmethod_14(Stream26 stream260);

        public T method_5<T>(T gparam0) where T : AbstractTreeNode1
        {
            if (CompareTo(gparam0) == 0)
            {
                return (T) this;
            }
            if (Nodes.Count != 0 && Nodes[0] is AbstractTreeNode1)
            {
                var enumerator = Nodes.GetEnumerator();
                T result;
                try
                {
                    while (enumerator.MoveNext())
                    {
                        var @class = (AbstractTreeNode1) enumerator.Current;
                        T t;
                        if ((t = @class.method_5(gparam0)) != null)
                        {
                            result = t;
                            return result;
                        }
                    }
                    goto IL_84;
                }
                finally
                {
                    var disposable = enumerator as IDisposable;
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

        public bool method_6<T>(ref T gparam0) where T : AbstractTreeNode1
        {
            if (CompareTo(gparam0) == 0)
            {
                gparam0 = (T) this;
                return true;
            }
            if (Nodes.Count != 0 && Nodes[0] is AbstractTreeNode1)
            {
                var enumerator = Nodes.GetEnumerator();
                bool result;
                try
                {
                    while (enumerator.MoveNext())
                    {
                        var @class = (AbstractTreeNode1) enumerator.Current;
                        if (@class.method_6(ref gparam0))
                        {
                            result = true;
                            return result;
                        }
                    }
                    return false;
                }
                finally
                {
                    var disposable = enumerator as IDisposable;
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