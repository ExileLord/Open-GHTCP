namespace GHNamespaceG
{
	public class ZzNote1 : AbstractNoteClass
	{
		public enum Enum37
		{
			Const0 = 1,
			Const1,
			Const2
		}

		private readonly Enum37 _enum370;

		private readonly string _string0;

		public ZzNote1(int int1, Enum37 enum371, string string1)
		{
			Int0 = int1;
			_enum370 = enum371;
			_string0 = string1;
		}

		public string method_1()
		{
			return _string0;
		}

		public Enum37 method_2()
		{
			return _enum370;
		}

		public override string ToString()
		{
			return string.Format("{0}: \"{1}\"", method_0(), _string0);
		}
	}
}
