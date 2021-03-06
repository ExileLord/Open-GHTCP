using ns22;
using System;
using System.Collections.Generic;

namespace ns9
{
	public class MIDILine
	{
		public string string_0;

		public int int_0;

		public List<AbstractNoteClass> list_0;

		public MIDILine(int int_1) : this("", int_1, null)
		{
		}

		public MIDILine(string string_1, int int_1, IEnumerable<AbstractNoteClass> ienumerable_0)
		{
			this.string_0 = string_1;
			this.int_0 = int_1;
			if (ienumerable_0 == null)
			{
				this.list_0 = new List<AbstractNoteClass>();
				return;
			}
			this.list_0 = new List<AbstractNoteClass>(ienumerable_0);
		}

		public List<AbstractNoteClass> method_0()
		{
			return this.list_0;
		}

		public void method_1(List<AbstractNoteClass> list_1)
		{
			this.list_0 = list_1;
		}

		public string method_2()
		{
			return this.string_0;
		}

		public void method_3(string string_1)
		{
			this.string_0 = string_1;
		}

		public override string ToString()
		{
			return this.string_0;
		}
	}
}
