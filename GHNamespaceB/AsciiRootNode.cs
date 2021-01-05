using GHNamespace9;
using GHNamespaceF;

namespace GHNamespaceB
{
    public class AsciiRootNode : ZzUnkNode260
    {
        public AsciiRootNode()
        {
            vmethod_0();
        }

        public override int vmethod_1()
        {
            return 0;
        }

        public string method_7()
        {
            if (Nodes.Count != 0)
            {
                return ((AsciiValueNode) FirstNode).String0;
            }
            return null;
        }

        public override void vmethod_13(Stream26 stream260)
        {
            Int0 = stream260.ReadInt();
            Int1 = stream260.ReadInt();
            var num = stream260.ReadInt();
            stream260.ReadInt();
            if (num != 0)
            {
                Nodes.Add(new AsciiValueNode(stream260.ReadAsciiStringAt(num)));
                stream260.Position += smethod_0(stream260.Position);
            }
        }

        public override void vmethod_14(Stream26 stream260)
        {
            var array = new byte[4];
            array[1] = (vmethod_7() ? (byte) 32 : (byte) 4);
            array[2] = 3;
            stream260.WriteByteArray(array, false);
            stream260.WriteInt(Int0);
            stream260.WriteInt(Int1);
            if (Nodes.Count != 0)
            {
                stream260.WriteInt((int) stream260.Position + 8);
                stream260.WriteInt(0);
                stream260.WriteString(method_7());
                stream260.WriteByte2(0);
                stream260.WriteNBytes(0, smethod_0(stream260.Position));
                return;
            }
            stream260.WriteNBytes(0, 8);
        }

        public override string GetNodeText()
        {
            return "Ascii Root";
        }

        public override void vmethod_2(ref int int2)
        {
            int2 += 20;
            if (Nodes.Count != 0)
            {
                ((AsciiValueNode) Nodes[0]).vmethod_2(ref int2);
                int2++;
                int2 += smethod_0(int2);
            }
        }
    }
}