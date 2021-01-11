using System.Collections.Generic;
using GHNamespaceE;

namespace GHNamespaceB
{
    public class FloatArrayNode : ZzUnkNode278<FloatValueNode>
    {
        public float this[int int0]
        {
            get => ((FloatValueNode) Nodes[int0]).Float0;
            set => ((FloatValueNode) Nodes[int0]).Float0 = value;
        }

        public FloatArrayNode()
        {
            vmethod_0();
        }

        public FloatArrayNode(IEnumerable<float> ienumerable0)
        {
            method_11(ienumerable0);
        }

        public override int vmethod_1()
        {
            return 13;
        }

        public void method_11(IEnumerable<float> ienumerable0)
        {
            foreach (float float_ in ienumerable0)
            {
                Nodes.Add(new FloatValueNode(float_));
            }
            vmethod_0();
        }

        public override byte vmethod_15()
        {
            return 2;
        }

        public override string GetNodeText()
        {
            return "Float Array";
        }
    }
}