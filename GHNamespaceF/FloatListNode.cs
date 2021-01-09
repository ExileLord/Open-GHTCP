using System.Collections.Generic;
using System.Drawing;
using GHNamespace9;
using GHNamespaceB;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceG;

namespace GHNamespaceF
{
    public class FloatListNode : AbsTreeNode11<FloatValueNode>
    {
        public FloatListNode()
        {
            vmethod_0();
        }

        public FloatListNode(bool bool1) : this()
        {
            if (bool1)
            {
                float[] ienumerable = new float[2];
                method_11(ienumerable);
            }
        }

        public override int vmethod_1()
        {
            return 20;
        }

        public void method_11(IEnumerable<float> ienumerable0)
        {
            foreach (float float_ in ienumerable0)
            {
                Nodes.Add(new FloatValueNode(float_));
            }
            vmethod_0();
        }

        public override void vmethod_13(Stream26 stream260)
        {
            Nodes.Add(new FloatValueNode(stream260.ReadFloat()));
            Nodes.Add(new FloatValueNode(stream260.ReadFloat()));
            if (method_1() is VectorArrayNode || method_1() is VectorPointerRootNode || method_1() is VectorPointerNode)
            {
                Nodes.Add(new FloatValueNode(stream260.ReadFloat()));
            }
            method_1().BackColor = Color.Gray;
        }

        public override void vmethod_14(Stream26 stream260)
        {
            byte[] array = new byte[4];
            array[1] = 1;
            stream260.WriteByteArray(array, false);
            foreach (FloatValueNode class313 in Nodes)
            {
                stream260.WriteFloat(FloatValueNode.smethod_0(class313));
            }
        }

        public override void vmethod_2(ref int int0)
        {
            int0 += 4 + 4 * Nodes.Count;
        }

        public override string GetNodeText()
        {
            return "Float List";
        }
    }
}