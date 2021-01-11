using System.Text;
using GHNamespaceK;

namespace GHNamespaceL
{
    public class Class129 : Class121
    {
        public byte[] Byte0 = new byte[0];

        public int Int0;

        public Class146[] Class1460;

        public Class129(Class144 class1440, int int1, bool bool1) : base(bool1)
        {
            int num = class1440.vmethod_14();
            Byte0 = new byte[num];
            class1440.vmethod_15(Byte0, Byte0.Length);
            Int0 = class1440.vmethod_14();
            if (Int0 > 0)
            {
                Class1460 = new Class146[Int0];
            }
            for (int i = 0; i < Int0; i++)
            {
                Class1460[i] = new Class146(class1440);
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("VendorString '" + Byte0 + "'\n");
            stringBuilder.Append("VorbisComment (count=" + Int0 + ")");
            for (int i = 0; i < Int0; i++)
            {
                stringBuilder.Append("\n\t" + Class1460[i]);
            }
            return stringBuilder.ToString();
        }
    }
}