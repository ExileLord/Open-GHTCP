using System.Collections.Generic;
using GHNamespaceB;
using GHNamespaceF;

namespace GHNamespaceE
{
    public class TagArray : ZzUnkNode278<TagValueNode>
    {
        public int this[int int0]
        {
            get => ((TagValueNode) Nodes[int0]).Int0;
            set => ((TagValueNode) Nodes[int0]).Int0 = value;
        }

        public TagArray()
        {
            vmethod_0();
        }

        public TagArray(IEnumerable<int> ienumerable0)
        {
            method_11(ienumerable0);
        }

        public override int vmethod_1()
        {
            return 14;
        }

        public void method_11(IEnumerable<int> ienumerable0)
        {
            foreach (var current in ienumerable0)
            {
                Nodes.Add(new TagValueNode(current));
            }
            vmethod_0();
        }

        public void method_12(IEnumerable<int> ienumerable0)
        {
            Nodes.Clear();
            method_11(ienumerable0);
        }

        public override byte vmethod_15()
        {
            return 13;
        }

        public override string GetNodeText()
        {
            return "Tag Array";
        }
    }
}