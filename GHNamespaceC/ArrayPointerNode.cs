using GHNamespaceB;
using GHNamespaceE;

namespace GHNamespaceC
{
    public class ArrayPointerNode : ZzUnkNode300
    {
        public ArrayPointerNode()
        {
            vmethod_0();
        }

        public ArrayPointerNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
        {
        }

        public ArrayPointerNode(int int1)
        {
            Int0 = int1;
            vmethod_0();
        }

        public ArrayPointerNode(string string0, AbsTreeNode11 class2760) : this(
            QbSongClass1.AddKeyToDictionary(string0), class2760)
        {
        }

        public ArrayPointerNode(int int1, AbsTreeNode11 class2760)
        {
            Int0 = int1;
            Nodes.Add(class2760);
            vmethod_0();
        }

        public override int vmethod_1()
        {
            return 28;
        }

        public AbsTreeNode11 method_8()
        {
            if (Nodes.Count != 0)
            {
                return (AbsTreeNode11) FirstNode;
            }
            return null;
        }

        public override string GetNodeText()
        {
            return "Array Pointer";
        }

        public override byte vmethod_15()
        {
            if (!vmethod_7())
            {
                return 25;
            }
            return 140;
        }
    }
}