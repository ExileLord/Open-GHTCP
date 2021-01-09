using System;
using GHNamespace9;
using GHNamespaceB;
using GHNamespaceE;
using GHNamespaceG;

namespace GHNamespaceF
{
    public abstract class Class268 : ZzUnkNode260
    {
        public abstract byte vmethod_16();

        public override void vmethod_13(Stream26 stream260)
        {
            Int0 = stream260.ReadInt();
            Int1 = stream260.ReadInt();
            if (this is FloatRootNode)
            {
                Nodes.Add(new FloatValueNode(stream260.ReadFloat()));
            }
            else if (this is IntegerRootNode)
            {
                Nodes.Add(new IntegerValueNode(stream260.ReadInt()));
            }
            else if (this is TagRootNode || this is FileTagRootNode)
            {
                Nodes.Add(new TagValueNode(stream260.ReadInt()));
            }
            stream260.ReadInt();
        }

        public override void vmethod_14(Stream26 stream260)
        {
            byte[] array = new byte[4];
            array[1] = (vmethod_7() ? (byte) 32 : (byte) 4);
            array[2] = vmethod_16();
            stream260.WriteByteArray(array, false);
            stream260.WriteInt(Int0);
            stream260.WriteInt(Int1);
            if (Nodes.Count != 0)
            {
                System.Collections.IEnumerator enumerator = Nodes.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        AbstractTreeNode2 @class = (AbstractTreeNode2) enumerator.Current;
                        stream260.WriteByteArray(@class.vmethod_8());
                    }
                    goto IL_97;
                }
                finally
                {
                    if (enumerator is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                }
            }
            stream260.WriteInt(0);
            IL_97:
            stream260.WriteInt(0);
        }

        public override void vmethod_2(ref int int2)
        {
            int2 += 20;
        }
    }
}