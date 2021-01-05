using GHNamespace9;
using GHNamespaceC;

namespace GHNamespaceB
{
    public class TextRootNode : ZzUnkNode260
    {
        public TextRootNode()
        {
            vmethod_0();
        }

        public override int vmethod_1()
        {
            return 1;
        }

        public string method_7()
        {
            if (Nodes.Count != 0)
            {
                return ((TextValueNode) FirstNode).method_2();
            }
            return null;
        }

        public int method_8()
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
            Int1 = stream260.ReadInt();
            Nodes.Add(new TextValueNode(stream260.ReadInt(), vmethod_10()));
            stream260.ReadInt();
        }

        public override void vmethod_14(Stream26 stream260)
        {
            vmethod_9(true);
            var array = new byte[4];
            array[1] = (vmethod_7() ? (byte) 32 : (byte) 4);
            array[2] = 28;
            stream260.WriteByteArray(array, false);
            stream260.WriteInt(Int0);
            stream260.WriteInt(Int1);
            if (Nodes.Count != 0)
            {
                stream260.WriteInt(method_8());
                if (method_7() != null)
                {
                    vmethod_10()[method_8()] = method_7();
                }
            }
            else
            {
                stream260.WriteInt(0);
            }
            stream260.WriteInt(0);
        }

        public override string GetNodeText()
        {
            return "Text Root";
        }

        public override void vmethod_2(ref int int2)
        {
            int2 += 20;
        }
    }
}