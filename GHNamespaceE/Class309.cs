using System;
using System.Windows.Forms;
using GHNamespace9;
using GHNamespaceB;
using GHNamespaceC;

namespace GHNamespaceE
{
    public class Class309 : ZzGenericNode1, IDisposable, INterface12
    {
        private int _int0;

        private int _int1;

        private int _int2;

        private int _int3;

        private int _int4;

        private int _int5;

        private Enum35 _enum350;

        private bool _bool3;

        public Class309() : this("newfile.qb")
        {
        }

        public Class309(string string0)
        {
            Text = KeyGenerator.GetFileName(string0);
            _int2 = QbSongClass1.AddKeyToDictionary(string0.Substring(string0.LastIndexOf('.')));
            _int3 = QbSongClass1.AddKeyToDictionary(string0);
            _int4 = QbSongClass1.AddKeyToDictionary(KeyGenerator.GetFileNameNoExt(string0));
            ImageIndex = 40;
            SelectedImageIndex = 40;
            _bool3 = true;
        }

        public Class309(string string0, ZzGenericNode1 class3080) : this(string0)
        {
            foreach (AbstractTreeNode1 node in class3080.Nodes)
            {
                Nodes.Add(node);
            }
        }

        public Class309(int int6, int int7, int int8, int int9, int int10, int int11, Enum35 enum351)
        {
            Text = (QbSongClass1.ContainsKey(int9)
                ? KeyGenerator.GetFileName(QbSongClass1.GetDictString(int9))
                : ("0x" + KeyGenerator.ValToHex32Bit(int9)));
            _int2 = int6;
            _int0 = int7;
            _int1 = int8;
            _int3 = int9;
            _int4 = int10;
            _int5 = int11;
            _enum350 = enum351;
            ImageIndex = 40;
            SelectedImageIndex = 40;
            _bool3 = false;
        }

        public int imethod_0()
        {
            return _int0;
        }

        public void imethod_1(int int6)
        {
            _int0 = int6;
        }

        public int imethod_2()
        {
            if (!imethod_18())
            {
                return method_11();
            }
            return _int1;
        }

        public void imethod_3(int int6)
        {
            _int1 = int6;
        }

        public int imethod_4()
        {
            return _int2;
        }

        public void imethod_5(int int6)
        {
            _int2 = int6;
        }

        public string imethod_6()
        {
            if (!QbSongClass1.ContainsKey(imethod_4()))
            {
                return "0x" + KeyGenerator.ValToHex32Bit(imethod_4());
            }
            return QbSongClass1.GetDictString(imethod_4());
        }

        public int imethod_7()
        {
            if (Parent != null && Parent is ZzPakNode1 && !(Parent as ZzPakNode1).Bool0)
            {
                return QbSongClass1.AddKeyToDictionary((Parent as ZzPakNode1).vmethod_0() + Text);
            }
            return _int3;
        }

        public void imethod_8(int int6)
        {
            _int3 = int6;
        }

        public string imethod_9()
        {
            if (!QbSongClass1.ContainsKey(imethod_7()))
            {
                return "0x" + KeyGenerator.ValToHex32Bit(imethod_7());
            }
            return QbSongClass1.GetDictString(imethod_7());
        }

        public int imethod_10()
        {
            return _int4;
        }

        public void imethod_11(int int6)
        {
            _int4 = int6;
        }

        public int imethod_12()
        {
            return _int5;
        }

        public void imethod_13(int int6)
        {
            _int5 = int6;
        }

        public Enum35 imethod_14()
        {
            return _enum350;
        }

        public void imethod_15(Enum35 enum351)
        {
            _enum350 = enum351;
        }

        public byte[] imethod_16()
        {
            return method_7();
        }

        public void imethod_17(byte[] byte1)
        {
            var stream26 = new Stream26(byte1);
            ZzGenericNode1 @class;
            if (Parent != null && Parent is ZzPakNode1 && !(Parent as ZzPakNode1).Bool0)
            {
                TreeNode treeNode = this;
                var level = treeNode.Level;
                while (level-- != 0)
                {
                    treeNode = treeNode.Parent;
                }
                if (treeNode is ZzPakNode2 && (treeNode as ZzPakNode2).Class3180 != null)
                {
                    var string_ = imethod_9().Contains(".qb")
                        ? imethod_9().Replace(".qb", ".qs")
                        : (imethod_9() + ".qs");
                    if ((treeNode as ZzPakNode2).Class3180.zzQbFileExists(string_))
                    {
                        @class = new ZzGenericNode1("TempFile", stream26,
                            (treeNode as ZzPakNode2).Class3180.method_9(string_).Dictionary0);
                    }
                    else
                    {
                        @class = new ZzGenericNode1("TempFile", stream26);
                    }
                }
                else
                {
                    @class = new ZzGenericNode1("TempFile", stream26);
                }
            }
            else
            {
                @class = new ZzGenericNode1("TempFile", stream26);
            }
            Nodes.Clear();
            foreach (AbstractTreeNode1 node in @class.Nodes)
            {
                Nodes.Add(node);
            }
            bool flag;
            vmethod_9(flag = @class.vmethod_8());
            if (flag)
            {
                vmethod_11(@class.vmethod_10());
            }
            Bool1 = @class.vmethod_7();
            _bool3 = true;
        }

        public bool imethod_18()
        {
            return !_bool3 && Nodes.Count == 0;
        }

        public void imethod_19()
        {
            Nodes.Clear();
            _bool3 = false;
        }

        public T imethod_20<T>(T gparam0) where T : INterface12
        {
            gparam0.imethod_1(_int0);
            gparam0.imethod_3(_int1);
            gparam0.imethod_5(_int2);
            gparam0.imethod_8(_int3);
            gparam0.imethod_11(_int4);
            gparam0.imethod_13(_int5);
            gparam0.imethod_15(_enum350);
            if (!imethod_18())
            {
                gparam0.imethod_17(imethod_16());
            }
            else
            {
                gparam0.imethod_19();
            }
            return gparam0;
        }

        public void Dispose()
        {
            imethod_19();
        }

        public override object Clone()
        {
            var @interface = (INterface12) base.Clone();
            @interface.imethod_1(_int0);
            @interface.imethod_3(_int1);
            @interface.imethod_5(_int2);
            @interface.imethod_8(_int3);
            @interface.imethod_11(_int4);
            @interface.imethod_13(_int5);
            @interface.imethod_15(_enum350);
            if (imethod_18())
            {
                @interface.imethod_19();
            }
            return @interface;
        }
    }
}