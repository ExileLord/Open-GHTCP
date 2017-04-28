using System.Collections.Generic;
using ns22;

namespace ns9
{
	public class MidiLine
	{
		public string String0;

		public int Int0;

		public List<AbstractNoteClass> List0;

		public MidiLine(int int1) : this("", int1, null)
		{
		}

		public MidiLine(string string1, int int1, IEnumerable<AbstractNoteClass> ienumerable0)
		{
			String0 = string1;
			Int0 = int1;
			if (ienumerable0 == null)
			{
				List0 = new List<AbstractNoteClass>();
				return;
			}
			List0 = new List<AbstractNoteClass>(ienumerable0);
		}

		public List<AbstractNoteClass> method_0()
		{
			return List0;
		}

		public void method_1(List<AbstractNoteClass> list1)
		{
			List0 = list1;
		}

		public string method_2()
		{
			return String0;
		}

		public void method_3(string string1)
		{
			String0 = string1;
		}

		public override string ToString()
		{
			return String0;
		}
	}
}
