namespace ns15
{
	public class NotesAtOffset
	{
		public bool[] noteValues;

		public int sustainLength;

		public NotesAtOffset(bool[] bool_1, int sL)
		{
			noteValues = bool_1;
			sustainLength = sL;
		}

		public NotesAtOffset(int int_1, int int_2)
		{
			setNote(int_1);
			sustainLength = int_2;
		}

		public int method_0()
		{
			uint num = 0u;//0
			for (int i = 0; i < noteValues.Length; i++)
			{
				if (noteValues[i])
				{
					num |= 1u << i;
				}
			}
			return (int)num;
		}

		public void setNote(int int_1)
		{
            noteValues = new bool[32];
			for (int i = 0; i < 32; i++)
			{
				if ((int_1 >> i & 1) != 0)
				{
					noteValues[i] = true;
				}
			}
		}
	}
}
