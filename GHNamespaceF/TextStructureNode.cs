using GHNamespace9;
using GHNamespaceB;
using GHNamespaceC;

namespace GHNamespaceF
{
    public class TextStructureNode : ZzUnkNode294
    {
        public TextStructureNode()
        {
            vmethod_0();
        }

        public override int vmethod_1()
        {
            return 22;
        }

        public string method_8()
        {
            if (Nodes.Count != 0)
            {
                return ((TextValueNode) FirstNode).method_2();
            }
            return null;
        }

        public int method_9()
        {
            if (Nodes.Count != 0)
            {
                return ((TextValueNode) FirstNode).Int0;
            }
            return 0;
        }

        public override void vmethod_13(Stream26 stream260)
        {
            Int0 = stream260.ReadInt();
            Nodes.Add(new TextValueNode(stream260.ReadInt(), vmethod_10()));
            var num = stream260.ReadInt();
            if (num != 0)
            {
                var @class = (Parent is StructureHeaderNode)
                    ? (Parent as StructureHeaderNode).method_11(stream260.ReadIntAt(num))
                    : vmethod_12(stream260.ReadIntAt(num, true));
                method_1().Nodes.Add(@class);
                @class.method_4(stream260);
            }
        }

        public override void vmethod_14(Stream26 stream260)
        {
            vmethod_9(true);
            var array = new byte[4];
            array[1] = 1;
            array[2] = 28;
            stream260.WriteByteArray(array, false);
            stream260.WriteInt(Int0);
            if (Nodes.Count != 0)
            {
                stream260.WriteInt(method_9());
                if (method_8() != null)
                {
                    vmethod_10()[method_9()] = method_8();
                }
            }
            else
            {
                stream260.WriteInt(0);
            }
            if (method_1().Nodes.IndexOf(this) < method_1().Nodes.Count - 1)
            {
                stream260.WriteInt((int) stream260.Position + 4);
                return;
            }
            stream260.WriteInt(0);
        }

        public override string GetNodeText()
        {
            return "Text Structure";
        }

        public override void vmethod_2(ref int int1)
        {
            int1 += 16;
        }
    }
}