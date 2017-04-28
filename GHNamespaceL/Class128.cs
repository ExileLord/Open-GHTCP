using GHNamespaceK;

namespace GHNamespaceL
{
	public class Class128 : Class121
	{
		private readonly int _int0;

		public Class128(Class144 class1440, int int1, bool bool1) : base(bool1)
		{
			_int0 = int1;
			class1440.vmethod_15(null, int1);
		}

		public override string ToString()
		{
			return "Padding (Length=" + _int0 + ")";
		}
	}
}
