using System;

namespace ns15
{
	public class NotesAtOffset
	{
		public bool[] noteValues;

		public int sustainLength;

        public NotesAtOffset()
        {
            noteValues = new bool[32];
            sustainLength = 0;
        }

        public NotesAtOffset(bool[] bool_1, int sL)
		{
			this.noteValues = bool_1;
			this.sustainLength = sL;
		}

		public NotesAtOffset(int int_1, int int_2)
		{
			this.setNote(int_1);
			this.sustainLength = int_2;
		}

		public int method_0()
		{
			uint num = 0u;//0
			for (int i = 0; i < this.noteValues.Length; i++)
			{
				if (this.noteValues[i])
				{
					num |= 1u << i;
				}
			}
			return (int)num;
		}

		public void setNote(int int_1)
		{
            this.noteValues = new bool[32];
			for (int i = 0; i < 32; i++)
			{
				if ((int_1 >> i & 1) != 0)
				{
					this.noteValues[i] = true;
				}
			}
		}
	}
}
