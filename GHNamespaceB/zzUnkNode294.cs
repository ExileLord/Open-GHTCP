using System.Drawing;
using GHNamespace9;
using GHNamespaceE;

namespace GHNamespaceB
{
    public abstract class ZzUnkNode294 : AbstractTreeNode1
    {
        public int Int0;

        public override int CompareTo(object target)
        {
            if (!target.GetType().Equals(GetType()) || (((ZzUnkNode294) target).Nodes.Count != 0 &&
                                                        !((ZzUnkNode294) target).Nodes[0].Equals(Nodes[0])))
            {
                return -1;
            }
            if (((ZzUnkNode294) target).Int0 == Int0)
            {
                return 0;
            }
            return 1;
        }

        public override string GetText()
        {
            var str = (Nodes.Count > 0) ? method_2(0).GetText() : "NULL";
            if (QbSongClass1.ContainsKey(Int0))
            {
                return QbSongClass1.GetDictString(Int0) + " = " + str;
            }
            return KeyGenerator.ValToHex32Bit(Int0) + " (Tag) = " + str;
        }

        public override Color GetColor()
        {
            if (Parent != null && method_7() != null && method_7().GetColor().Equals(Color.Gold))
            {
                return Color.Yellow;
            }
            return Color.Gold;
        }

        public override object Clone()
        {
            var @class = (ZzUnkNode294) base.Clone();
            @class.Int0 = Int0;
            return @class;
        }

        public AbstractTreeNode1 method_7()
        {
            return (AbstractTreeNode1) PrevNode;
        }
    }
}