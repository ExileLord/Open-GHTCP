using System.Text;
using GHNamespaceK;

namespace GHNamespaceL
{
    public class Class127 : Class121
    {
        public Class142[] Class1420;

        public Class127(Class144 class1440, int int0, bool bool1) : base(bool1)
        {
            int num = int0 / 18;
            Class1420 = new Class142[num];
            for (int i = 0; i < Class1420.Length; i++)
            {
                Class1420[i] = new Class142(class1440);
            }
            int0 -= int0 * 18;
            if (int0 > 0)
            {
                class1440.vmethod_15(null, int0);
            }
        }

        public virtual int vmethod_1()
        {
            return Class1420.Length;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SeekTable: points=" + Class1420.Length + "\n");
            for (int i = 0; i < Class1420.Length; i++)
            {
                stringBuilder.Append("\tPoint " + Class1420[i] + "\n");
            }
            return stringBuilder.ToString();
        }
    }
}