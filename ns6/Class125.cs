using ns7;

namespace ns6
{
	public class Class125 : Class121
	{
		public byte[] Byte0 = new byte[129];

		public long Long0;

		public bool Bool1;

		public int Int0;

		public Class147[] Class1470;

		public Class125(Class144 class1440, int int1, bool bool2) : base(bool2)
		{
			class1440.vmethod_15(Byte0, 128);
			Long0 = class1440.vmethod_13(64);
			Bool1 = (class1440.vmethod_10(1) != 0);
			class1440.vmethod_5(2071);
			Int0 = class1440.vmethod_10(8);
			if (Int0 > 0)
			{
				Class1470 = new Class147[Int0];
				for (var i = 0; i < Int0; i++)
				{
					Class1470[i] = new Class147(class1440);
				}
			}
		}
	}
}
