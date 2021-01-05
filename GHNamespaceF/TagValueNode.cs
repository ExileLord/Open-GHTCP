using System;
using GHNamespaceB;
using GHNamespaceE;

namespace GHNamespaceF
{
    public class TagValueNode : AbstractTreeNode2
    {
        public int Int0;

        public TagValueNode()
        {
            vmethod_0();
        }

        public TagValueNode(int int1)
        {
            Int0 = int1;
            vmethod_0();
        }

        public TagValueNode(string string0)
        {
            method_3(string0);
            vmethod_0();
        }

        public override int vmethod_1()
        {
            return 35;
        }

        public override object vmethod_7()
        {
            return method_2();
        }

        public override byte[] vmethod_8()
        {
            return BitConverter.GetBytes(Int0);
        }

        public override void vmethod_9(byte[] byte0)
        {
            Int0 = BitConverter.ToInt32(byte0, 0);
        }

        public override string GetText()
        {
            return method_2();
        }

        public string method_2()
        {
            if (QbSongClass1.ContainsKey(Int0))
            {
                return QbSongClass1.GetDictString(Int0);
            }
            return "0x" + IntToHex32Bit(Int0);
        }

        public void method_3(string string0)
        {
            Int0 = QbSongClass1.AddKeyToDictionary(string0);
        }

        public override string GetNodeText()
        {
            return "Tag Value";
        }

        public override void vmethod_2(ref int int1)
        {
            int1 += 4;
        }
    }
}