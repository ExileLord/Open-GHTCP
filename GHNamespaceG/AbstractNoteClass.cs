namespace GHNamespaceG
{
    public abstract class AbstractNoteClass
    {
        public int Int0;

        public int method_0()
        {
            return Int0;
        }

        public static int smethod_0(AbstractNoteClass class3350, AbstractNoteClass class3351)
        {
            if (!(class3350 is MidiNote) || !(class3351 is MidiNote) || class3350.method_0() != class3351.method_0())
            {
                return class3350.method_0() - class3351.method_0();
            }
            bool flag = ((MidiNote) class3350).method_5();
            bool flag2 = ((MidiNote) class3351).method_5();
            if (flag && !flag2)
            {
                return 1;
            }
            if (flag2 && !flag)
            {
                return -1;
            }
            return 0;
        }
    }
}