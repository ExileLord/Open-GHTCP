using GHNamespace9;
using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespaceB
{
    public abstract class ZzUnkNode278<T> : AbsTreeNode11<T> where T : AbstractBaseTreeNode1
    {
        public abstract byte vmethod_15();

        public override void vmethod_13(Stream26 stream260)
        {
            int num = stream260.ReadInt();
            if (num == 0)
            {
                return;
            }
            if (num > 1)
            {
                stream260.Position = stream260.ReadInt();
            }
            if (this is FloatArrayNode)
            {
                for (int i = 0; i < num; i++)
                {
                    Nodes.Add(new FloatValueNode(stream260.ReadFloat()));
                }
                return;
            }
            if (this is IntegerArrayNode)
            {
                for (int j = 0; j < num; j++)
                {
                    Nodes.Add(new IntegerValueNode(stream260.ReadInt()));
                }
                return;
            }
            if (this is TagArray || this is FileTagArrayNode)
            {
                for (int k = 0; k < num; k++)
                {
                    Nodes.Add(new TagValueNode(stream260.ReadInt()));
                }
            }
        }

        public override void vmethod_14(Stream26 stream260)
        {
            byte[] array = new byte[4];
            array[1] = 1;
            array[2] = vmethod_15();
            stream260.WriteByteArray(array, false);
            stream260.WriteInt(Nodes.Count);
            if (Nodes.Count == 0)
            {
                return;
            }
            if (Nodes.Count > 1)
            {
                stream260.WriteInt((int) stream260.Position + 4);
            }
            foreach (AbstractTreeNode2 @class in Nodes)
            {
                stream260.WriteByteArray(@class.vmethod_8());
            }
        }

        public override void vmethod_2(ref int int0)
        {
            int0 += 8;
            if (Nodes.Count > 1)
            {
                int0 += 4;
            }
            int0 += 4 * Nodes.Count;
        }
    }
}