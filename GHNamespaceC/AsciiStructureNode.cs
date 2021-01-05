using GHNamespace9;
using GHNamespaceB;
using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespaceC
{
    public class AsciiStructureNode : ZzUnkNode294
    {
        public AsciiStructureNode()
        {
            vmethod_0();
        }

        public AsciiStructureNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
        {
        }

        public AsciiStructureNode(int int1)
        {
            Int0 = int1;
            vmethod_0();
        }

        public AsciiStructureNode(string string0, string string1) : this(QbSongClass1.AddKeyToDictionary(string0),
            string1)
        {
        }

        public AsciiStructureNode(int int1, string string0)
        {
            Int0 = int1;
            Nodes.Add(new AsciiValueNode(string0));
            vmethod_0();
        }

        public override int vmethod_1()
        {
            return 21;
        }

        public string method_8()
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
            var num = stream260.ReadInt();
            var num2 = stream260.ReadInt();
            if (num != 0)
            {
                Nodes.Add(new AsciiValueNode(stream260.ReadAsciiStringAt(num)));
                stream260.Position += smethod_0(stream260.Position);
            }
            if (num2 != 0)
            {
                var @class = (Parent is StructureHeaderNode)
                    ? (Parent as StructureHeaderNode).method_11(stream260.ReadIntAt(num2))
                    : vmethod_12(stream260.ReadIntAt(num2, true));
                method_1().Nodes.Add(@class);
                @class.method_4(stream260);
            }
        }

        public override void vmethod_14(Stream26 stream260)
        {
            if (vmethod_8())
            {
                var array = new byte[4];
                array[1] = 1;
                array[2] = 3;
                stream260.WriteByteArray(array, false);
            }
            else
            {
                var array2 = new byte[4];
                array2[1] = (byte) (vmethod_7() ? 131 : 7);
                stream260.WriteByteArray(array2, false);
            }
            stream260.WriteInt(Int0);
            var int_ = (int) stream260.Position + 4;
            if (Nodes.Count != 0)
            {
                stream260.WriteInt((int) stream260.Position + 8);
                stream260.WriteInt(0);
                stream260.WriteString(method_8());
                stream260.WriteByte2(0);
                stream260.WriteNBytes(0, smethod_0(stream260.Position));
            }
            else
            {
                stream260.WriteInt(0);
            }
            var num = (int) stream260.Position;
            if (method_1().Nodes.IndexOf(this) < method_1().Nodes.Count - 1)
            {
                stream260.WriteIntAt(int_, num);
            }
            else
            {
                stream260.WriteIntAt(int_, 0);
            }
            stream260.Position = num;
        }

        public override string GetNodeText()
        {
            return "Ascii Structure";
        }

        public override void vmethod_2(ref int int1)
        {
            int1 += 16;
            if (Nodes.Count != 0)
            {
                ((AsciiValueNode) Nodes[0]).vmethod_2(ref int1);
                int1++;
                int1 += smethod_0(int1);
            }
        }
    }
}