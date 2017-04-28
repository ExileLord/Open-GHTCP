using GHNamespaceL;

namespace GHNamespaceK
{
	public class Class124 : Class121
	{
		private readonly byte[] _byte0 = new byte[4];

		private readonly byte[] _byte1;

		public Class124(Class144 class1440, int int0, bool bool1) : base(bool1)
		{
			class1440.vmethod_15(_byte0, 4);
			int0 -= 4;
			if (int0 > 0)
			{
				_byte1 = new byte[int0];
				class1440.vmethod_15(_byte1, int0);
			}
		}
	}
}
