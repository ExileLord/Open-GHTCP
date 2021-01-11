using GHNamespace9;
using GHNamespaceB;
using GHNamespaceC;
using GHNamespaceE;

namespace GHNamespaceF
{
    public class UnicodeStructureNode : ZzUnkNode294
    {
        public UnicodeStructureNode()
        {
            vmethod_0();
        }

        public UnicodeStructureNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
        {
        }

        public UnicodeStructureNode(int int1)
        {
            Int0 = int1;
            vmethod_0();
        }

        public UnicodeStructureNode(string string0, string string1) : this(QbSongClass1.AddKeyToDictionary(string0),
            string1)
        {
        }

        public UnicodeStructureNode(int int1, string string0)
        {
            Int0 = int1;
            Nodes.Add(new UnicodeValueNode(string0));
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
                return ((UnicodeValueNode) FirstNode).String0;
            }
            return null;
        }

        public void method_9(string string0)
        {
            if (Nodes.Count != 0)
            {
                ((UnicodeValueNode) FirstNode).String0 = string0;
                return;
            }
            Nodes.Add(new UnicodeValueNode(string0));
        }

        public override void vmethod_13(Stream26 stream260)
        {
            Int0 = stream260.ReadInt();
            int num = stream260.ReadInt();
            int num2 = stream260.ReadInt();
            if (num != 0)
            {
                Nodes.Add(new UnicodeValueNode(stream260.ReadUnicodeStringAt(num)));
                stream260.Position += smethod_0(stream260.Position);
            }
            if (num2 != 0)
            {
                AbstractTreeNode1 @class = (Parent is StructureHeaderNode)
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
                byte[] array = new byte[4];
                array[1] = 1;
                array[2] = 4;
                stream260.WriteByteArray(array, false);
            }
            else
            {
                byte[] array2 = new byte[4];
                array2[1] = (vmethod_7() ? (byte) 132 : (byte) 9);
                stream260.WriteByteArray(array2, false);
            }
            stream260.WriteInt(Int0);
            int int_ = (int) stream260.Position + 4;
            if (Nodes.Count != 0)
            {
                stream260.WriteInt((int) stream260.Position + 8);
                stream260.WriteInt(0);
                stream260.WriteString(method_8(), stream260.ReverseEndianness);
                stream260.WriteNBytes(0, 2);
                stream260.WriteNBytes(0, smethod_0(stream260.Position));
            }
            else
            {
                stream260.WriteInt(0);
            }
            int num = (int) stream260.Position;
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
            return "Unicode Structure";
        }

        public override void vmethod_2(ref int int1)
        {
            int1 += 16;
            if (Nodes.Count != 0)
            {
                ((UnicodeValueNode) Nodes[0]).vmethod_2(ref int1);
                int1 += 2;
                int1 += smethod_0(int1);
            }
        }
    }
}