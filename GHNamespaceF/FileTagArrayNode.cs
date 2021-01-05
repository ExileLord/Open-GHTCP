using GHNamespaceB;

namespace GHNamespaceF
{
    public class FileTagArrayNode : ZzUnkNode278<TagValueNode>
    {
        public int this[int int0]
        {
            get => ((TagValueNode) Nodes[int0]).Int0;
            set => ((TagValueNode) Nodes[int0]).Int0 = value;
        }

        public FileTagArrayNode()
        {
            vmethod_0();
        }

        public override int vmethod_1()
        {
            return 14;
        }

        public override byte vmethod_15()
        {
            return 26;
        }

        public override string GetNodeText()
        {
            return "File Tag Array";
        }
    }
}