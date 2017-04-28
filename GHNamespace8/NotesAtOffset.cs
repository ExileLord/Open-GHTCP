namespace GHNamespace8
{
    public class NotesAtOffset
    {
        public bool[] NoteValues;

        public int SustainLength;

        public NotesAtOffset(bool[] bool1, int sL)
        {
            NoteValues = bool1;
            SustainLength = sL;
        }

        public NotesAtOffset(int int1, int int2)
        {
            SetNote(int1);
            SustainLength = int2;
        }

        public int method_0()
        {
            var num = 0u; //0
            for (var i = 0; i < NoteValues.Length; i++)
            {
                if (NoteValues[i])
                {
                    num |= 1u << i;
                }
            }
            return (int) num;
        }

        public void SetNote(int int1)
        {
            NoteValues = new bool[32];
            for (var i = 0; i < 32; i++)
            {
                if ((int1 >> i & 1) != 0)
                {
                    NoteValues[i] = true;
                }
            }
        }
    }
}