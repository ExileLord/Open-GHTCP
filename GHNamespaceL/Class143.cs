namespace GHNamespaceL
{
    public class Class143
    {
        public int[] Int0;

        public int[] Int1;

        public int Int2;

        public virtual void vmethod_0(int int3)
        {
            if (Int2 >= int3)
            {
                return;
            }
            Int0 = new int[1 << int3];
            Int1 = new int[1 << int3];
            Int2 = int3;
        }
    }
}