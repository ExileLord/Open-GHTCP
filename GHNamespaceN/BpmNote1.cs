using GHNamespaceG;

namespace GHNamespaceN
{
    public class BpmNote1 : AbstractNoteClass
    {
        private readonly int _int1;

        public BpmNote1(int int2, int int3)
        {
            Int0 = int2;
            _int1 = int3;
        }

        public int method_1()
        {
            return _int1;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} BPM", method_0(), ByteFiddler.DivideSixtyMillionBy(_int1));
        }
    }
}