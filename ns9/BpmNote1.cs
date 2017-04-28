using ns22;

namespace ns9
{
	public class BpmNote1 : AbstractNoteClass
	{
		private readonly int int_1;

		public BpmNote1(int int_2, int int_3)
		{
			int_0 = int_2;
			int_1 = int_3;
		}

		public int method_1()
		{
			return int_1;
		}

		public override string ToString()
		{
			return string.Format("{0}: {1} BPM", method_0(), ByteFiddler.DivideSixtyMillionBy(int_1));
		}
	}
}
