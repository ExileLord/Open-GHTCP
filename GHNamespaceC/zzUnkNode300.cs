using GHNamespace9;
using GHNamespaceB;
using GHNamespaceF;

namespace GHNamespaceC
{
    public abstract class ZzUnkNode300 : ZzUnkNode294
    {
        public abstract byte vmethod_15();

        public override void vmethod_13(Stream26 stream260)
        {
            Int0 = stream260.ReadInt();
            var num = stream260.ReadInt();
            var num2 = stream260.ReadInt();
            if (num != 0)
            {
                var @class = vmethod_12(stream260.ReadIntAt(num, true));
                Nodes.Add(@class);
                @class.method_4(stream260);
            }
            if (num2 != 0)
            {
                var class2 = (Parent is StructureHeaderNode)
                    ? (Parent as StructureHeaderNode).method_11(stream260.ReadIntAt(num2))
                    : vmethod_12(stream260.ReadIntAt(num2, true));
                method_1().Nodes.Add(class2);
                class2.method_4(stream260);
            }
        }

        public override void vmethod_14(Stream26 stream260)
        {
            if (vmethod_8())
            {
                var array = new byte[4];
                array[1] = 1;
                array[2] = (byte) (vmethod_15() - 128);
                stream260.WriteByteArray(array, false);
            }
            else
            {
                var array2 = new byte[4];
                array2[1] = vmethod_15();
                stream260.WriteByteArray(array2, false);
            }
            stream260.WriteInt(Int0);
            stream260.WriteInt((Nodes.Count != 0) ? ((int) stream260.Position + 8) : 0);
            var int_ = (int) stream260.Position;
            stream260.WriteInt(0);
            foreach (AbstractTreeNode1 @class in Nodes)
            {
                @class.vmethod_14(stream260);
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

        public override void vmethod_2(ref int int1)
        {
            int1 += 16;
            foreach (AbstractTreeNode1 @class in Nodes)
            {
                @class.vmethod_2(ref int1);
            }
        }
    }
}