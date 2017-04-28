using GHNamespaceB;
using GHNamespaceC;

namespace GHNamespaceE
{
    public class ArrayPointerRootNode : ProbablyRootNode
    {
        public ArrayPointerRootNode()
        {
            vmethod_0();
        }

        public ArrayPointerRootNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
        {
        }

        public ArrayPointerRootNode(int int2)
        {
            Int0 = int2;
            vmethod_0();
        }

        public ArrayPointerRootNode(string string0, string string1, AbsTreeNode11 class2760) : this(
            QbSongClass1.AddKeyToDictionary(string0), QbSongClass1.AddKeyToDictionary(string1), class2760)
        {
        }

        public ArrayPointerRootNode(string string0, int int2, AbsTreeNode11 class2760) : this(
            QbSongClass1.AddKeyToDictionary(string0), int2, class2760)
        {
        }

        public ArrayPointerRootNode(int int2, int int3, AbsTreeNode11 class2760)
        {
            Int0 = int2;
            Int1 = int3;
            Nodes.Add(class2760);
            vmethod_0();
        }

        public override int vmethod_1()
        {
            return 7;
        }

        public AbsTreeNode11 method_7()
        {
            if (Nodes.Count != 0)
            {
                return (AbsTreeNode11) FirstNode;
            }
            return null;
        }

        public void method_8(AbsTreeNode11 class2760)
        {
            if (Nodes.Count != 0)
            {
                Nodes[0] = class2760;
                return;
            }
            Nodes.Add(class2760);
        }

        public override string GetNodeText()
        {
            return "Array Pointer Root";
        }

        public override byte vmethod_16()
        {
            return 12;
        }
    }
}