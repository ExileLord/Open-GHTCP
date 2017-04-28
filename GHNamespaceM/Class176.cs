using GHNamespace1;
using GHNamespace2;

namespace GHNamespaceM
{
    public abstract class Class176 : INterface5
    {
        public abstract void vmethod_0(Class13 class130, Class13 class131);

        public void imethod_0(Class13[] class130)
        {
            for (var i = 0; i < class130.Length; i += 2)
            {
                vmethod_0(class130[i], class130[i + 1]);
            }
        }
    }
}