using System.Collections.Generic;
using GHNamespace2;

namespace GHNamespace1
{
    public class Class12 : List<INterface5>, INterface5
    {
        public Class12(INterface5[] interface50)
        {
            AddRange(interface50);
        }

        public virtual void imethod_0(Class13[] class130)
        {
            foreach (var current in this)
            {
                current.imethod_0(class130);
            }
        }
    }
}