namespace GHNamespaceL
{
	public class Class147
	{
		public long Long0;

		public byte Byte0;

		public byte[] Byte1 = new byte[13];

		public int Int0;

		public int Int1;

		public byte Byte2;

		public Class148[] Class1480;

		public Class147(Class144 class1440)
		{
			Long0 = class1440.vmethod_13(64);
			Byte0 = (byte)class1440.vmethod_10(8);
			class1440.vmethod_15(Byte1, 12);
			Int0 = class1440.vmethod_10(1);
			Int1 = class1440.vmethod_10(1);
			class1440.vmethod_5(110);
			Byte2 = (byte)class1440.vmethod_10(8);
			if (Byte2 > 0)
			{
				Class1480 = new Class148[Byte2];
				for (var i = 0; i < (int)Byte2; i++)
				{
					Class1480[i] = new Class148(class1440);
				}
			}
		}
	}
}
