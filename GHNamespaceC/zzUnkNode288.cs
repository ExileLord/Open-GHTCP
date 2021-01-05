using System.Collections.Generic;
using GHNamespace9;
using GHNamespaceB;

namespace GHNamespaceC
{
    public abstract class ZzUnkNode288 : AbsTreeNode11
    {
        public abstract byte vmethod_15();

        public override void vmethod_13(Stream26 stream260)
        {
            var num = stream260.ReadInt();
            if (num == 0)
            {
                return;
            }
            var array = new int[num];
            if (num > 1)
            {
                stream260.Position = stream260.ReadInt();
                for (var i = 0; i < num; i++)
                {
                    array[i] = stream260.ReadInt();
                }
            }
            else
            {
                array[0] = stream260.ReadInt();
            }
            var array2 = array;
            for (var j = 0; j < array2.Length; j++)
            {
                var int_ = array2[j];
                var @class = vmethod_12(stream260.ReadIntAt(int_, true));
                Nodes.Add(@class);
                @class.method_4(stream260);
            }
        }

        public override void vmethod_14(Stream26 stream260)
        {
            var array = new byte[4];
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
            var int_ = (int) stream260.Position;
            var list = new List<int>(Nodes.Count);
            stream260.WriteNBytes(0, 4 * Nodes.Count);
            foreach (AbstractTreeNode1 @class in Nodes)
            {
                list.Add((int) stream260.Position);
                @class.vmethod_14(stream260);
            }
            var num = (int) stream260.Position;
            stream260.WriteEnumerableIntsAt(int_, list);
            stream260.Position = num;
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
            foreach (AbstractTreeNode1 @class in Nodes)
            {
                @class.vmethod_2(ref int0);
            }
        }
    }
}