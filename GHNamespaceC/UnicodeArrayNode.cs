using GHNamespace9;
using GHNamespaceB;

namespace GHNamespaceC
{
    public class UnicodeArrayNode : AbsTreeNode11<UnicodeValueNode>
    {
        public string this[int int0]
        {
            get => ((UnicodeValueNode) Nodes[int0]).String0;
            set => ((UnicodeValueNode) Nodes[int0]).String0 = value;
        }

        public UnicodeArrayNode()
        {
            vmethod_0();
        }

        public override int vmethod_1()
        {
            return 11;
        }

        public override void vmethod_13(Stream26 stream260)
        {
            int num = stream260.ReadInt();
            if (num == 0)
            {
                return;
            }
            int[] array = new int[num];
            if (num > 1)
            {
                stream260.Position = stream260.ReadInt();
                for (int i = 0; i < num; i++)
                {
                    array[i] = stream260.ReadInt();
                }
            }
            else
            {
                array[0] = stream260.ReadInt();
            }
            int[] array2 = array;
            for (int j = 0; j < array2.Length; j++)
            {
                int int_ = array2[j];
                Nodes.Add(new UnicodeValueNode(stream260.ReadUnicodeStringAt(int_)));
            }
            stream260.Position += smethod_0(stream260.Position);
        }

        public override void vmethod_14(Stream26 stream260)
        {
            byte[] array = new byte[4];
            array[1] = 1;
            array[2] = 4;
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
            int num = (int) stream260.Position + 4 * Nodes.Count;
            Stream26 stream = new Stream26();
            foreach (UnicodeValueNode @class in Nodes)
            {
                stream260.WriteInt(num);
                stream.WriteString(@class.String0, stream260.ReverseEndianness);
                stream.WriteNBytes(0, 2);
                num += @class.String0.Length * 2 + 2;
            }
            stream260.WriteByteArray(stream.ReadEverything(), false);
            stream260.WriteNBytes(0, smethod_0(stream260.Position));
        }

        public override void vmethod_2(ref int int0)
        {
            int0 += 8;
            if (Nodes.Count == 0)
            {
                return;
            }
            if (Nodes.Count > 1)
            {
                int0 += 4;
            }
            int0 += 4 * Nodes.Count;
            foreach (UnicodeValueNode @class in Nodes)
            {
                @class.vmethod_2(ref int0);
                int0 += 2;
            }
            int0 += smethod_0(int0);
        }

        public override string GetNodeText()
        {
            return "Unicode Array";
        }
    }
}