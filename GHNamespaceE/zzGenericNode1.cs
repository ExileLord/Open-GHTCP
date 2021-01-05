using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using GHNamespace9;
using GHNamespaceB;
using GHNamespaceC;
using GHNamespaceF;
using GHNamespaceG;

namespace GHNamespaceE
{
    public class ZzGenericNode1 : AbstractTreeNode1
    {
        public bool Bool1 = true;

        private bool _bool2;

        private Dictionary<int, string> _dictionary0;

        public byte[] Byte0 =
        {
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            28,
            8,
            2,
            4,
            16,
            4,
            8,
            12,
            12,
            8,
            2,
            4,
            20,
            2,
            4,
            12,
            16,
            16,
            12,
            0
        };

        public override bool vmethod_7()
        {
            return Bool1;
        }

        public override bool vmethod_8()
        {
            return _bool2;
        }

        public override void vmethod_9(bool bool3)
        {
            _bool2 = bool3;
        }

        public override Dictionary<int, string> vmethod_10()
        {
            Dictionary<int, string> arg180;
            if ((arg180 = _dictionary0) == null)
            {
                arg180 = (_dictionary0 = new Dictionary<int, string>());
            }
            return arg180;
        }

        public override void vmethod_11(Dictionary<int, string> dictionary1)
        {
            _bool2 = true;
            _dictionary0 = dictionary1;
        }

        public ZzGenericNode1()
        {
        }

        public ZzGenericNode1(string string0, AbstractTreeNode1 class2590)
        {
            Text = KeyGenerator.GetFileName(string0);
            Nodes.Add(class2590);
        }

        public ZzGenericNode1(string string0, IEnumerable<AbstractTreeNode1> ienumerable0)
        {
            Text = KeyGenerator.GetFileName(string0);
            Nodes.AddRange(new List<AbstractTreeNode1>(ienumerable0).ToArray());
        }

        public ZzGenericNode1(string string0, byte[] byte1) : this(string0, new Stream26(byte1))
        {
        }

        public ZzGenericNode1(string string0, Stream26 stream260)
        {
            Text = KeyGenerator.GetFileName(string0);
            stream260.Position = 28L;
            method_4(stream260);
        }

        public ZzGenericNode1(string string0, Stream26 stream260, Dictionary<int, string> dictionary1)
        {
            Text = KeyGenerator.GetFileName(string0);
            if (dictionary1 != null)
            {
                _dictionary0 = dictionary1;
                _bool2 = true;
            }
            stream260.Position = 28L;
            method_4(stream260);
        }

        public override void vmethod_13(Stream26 stream260)
        {
            while (stream260.Length > stream260.Position)
            {
                var num = stream260.ReadInt(true);
                if (num != 0)
                {
                    var @class = vmethod_12(num);
                    stream260.ReverseEndianness = vmethod_7();
                    Nodes.Add(@class);
                    @class.method_4(stream260);
                }
                else
                {
                    stream260.Position += 4L;
                }
            }
        }

        public override void vmethod_14(Stream26 stream260)
        {
            stream260.ReverseEndianness = vmethod_7();
            foreach (AbstractTreeNode1 @class in Nodes)
            {
                @class.vmethod_14(stream260);
            }
        }

        public override AbstractTreeNode1 vmethod_12(int int0)
        {
            if (int0 == 256)
            {
                return new StructureHeaderNode();
            }
            var num = int0 >> 16 & 255;
            var num2 = int0 >> 8 & 255;
            if (num == 32)
            {
                Bool1 = true;
            }
            else if (num == 4)
            {
                Bool1 = false;
            }
            var ex = new Exception("No QB Node class found for : " + KeyGenerator.ValToHex32Bit(int0));
            if (num != 32)
            {
                if (num != 4)
                {
                    if (num == 1)
                    {
                        if (num2 == 0)
                        {
                            return new FloatListNode();
                        }
                        if (num2 == 1)
                        {
                            return new IntegerArrayNode();
                        }
                        if (num2 == 2)
                        {
                            return new FloatArrayNode();
                        }
                        if (num2 == 3)
                        {
                            return new AsciiArrayNode();
                        }
                        if (num2 == 4)
                        {
                            return new UnicodeArrayNode();
                        }
                        if (num2 == 5)
                        {
                            return new PairArrayNode();
                        }
                        if (num2 == 6)
                        {
                            return new VectorArrayNode();
                        }
                        if (num2 == 10)
                        {
                            return new StructureArrayNode();
                        }
                        if (num2 == 12)
                        {
                            return new ListArrayNode();
                        }
                        if (num2 == 13)
                        {
                            return new TagArray();
                        }
                        if (num2 == 26)
                        {
                            _bool2 = true;
                            return new FileTagArrayNode();
                        }
                        if (num2 == 28)
                        {
                            _bool2 = true;
                            return new TextArrayNode();
                        }
                        throw ex;
                    }
                    if (!Bool1)
                    {
                        if (num == 3)
                        {
                            return new IntegerStructureNode();
                        }
                        if (num == 5)
                        {
                            return new FloatStructureNode();
                        }
                        if (num == 7)
                        {
                            return new AsciiStructureNode();
                        }
                        if (num == 9)
                        {
                            return new UnicodeStructureNode();
                        }
                        if (num == 11)
                        {
                            return new PairPointerNode();
                        }
                        if (num == 13)
                        {
                            return new VectorPointerNode();
                        }
                        if (num == 21)
                        {
                            return new StructurePointerNode();
                        }
                        if (num == 25)
                        {
                            return new ArrayPointerNode();
                        }
                        if (num == 27)
                        {
                            return new TagStructureNode();
                        }
                        if (num == 53)
                        {
                            return new FileTagStructureNode();
                        }
                        throw ex;
                    }
                    if (num == 154)
                    {
                        return new FileTagStructureNode();
                    }
                    if ((num & 240) != 128 || (num2 = (num & 15)) == 0)
                    {
                        return null;
                    }
                    if (num2 == 1)
                    {
                        return new IntegerStructureNode();
                    }
                    if (num2 == 2)
                    {
                        return new FloatStructureNode();
                    }
                    if (num2 == 3)
                    {
                        return new AsciiStructureNode();
                    }
                    if (num2 == 4)
                    {
                        return new UnicodeStructureNode();
                    }
                    if (num2 == 5)
                    {
                        return new PairPointerNode();
                    }
                    if (num2 == 6)
                    {
                        return new VectorPointerNode();
                    }
                    if (num2 == 10)
                    {
                        return new StructurePointerNode();
                    }
                    if (num2 == 12)
                    {
                        return new ArrayPointerNode();
                    }
                    if (num2 == 13)
                    {
                        return new TagStructureNode();
                    }
                    throw ex;
                }
            }
            if (num2 == 1)
            {
                return new IntegerRootNode();
            }
            if (num2 == 2)
            {
                return new FloatRootNode();
            }
            if (num2 == 3)
            {
                return new AsciiRootNode();
            }
            if (num2 == 4)
            {
                return new UnicodeRootNode();
            }
            if (num2 == 5)
            {
                return new PairPointerRootNode();
            }
            if (num2 == 6)
            {
                return new VectorPointerRootNode();
            }
            if (num2 == 7)
            {
                return new ScriptRootNode();
            }
            if (num2 == 10)
            {
                return new StructurePointerRootNode();
            }
            if (num2 == 12)
            {
                return new ArrayPointerRootNode();
            }
            if (num2 == 13)
            {
                return new TagRootNode();
            }
            if (num2 == 26)
            {
                _bool2 = true;
                return new FileTagRootNode();
            }
            if (num2 == 28)
            {
                _bool2 = true;
                return new TextRootNode();
            }
            throw ex;
        }

        public byte[] method_7()
        {
            return method_8().ToArray();
        }

        public MemoryStream method_8()
        {
            var memoryStream = new MemoryStream();
            method_9(memoryStream);
            memoryStream.Position = 0L;
            return memoryStream;
        }

        public void method_9(Stream stream0)
        {
            method_10(new Stream26(stream0, Bool1));
        }

        public void method_10(Stream26 stream260)
        {
            stream260.WriteByteArray(Byte0, false);
            vmethod_14(stream260);
            stream260.WriteIntAt(4, (int) stream260.Length);
            stream260.Position = stream260.Length;
        }

        public int method_11()
        {
            var result = 28;
            vmethod_2(ref result);
            return result;
        }

        public override void vmethod_2(ref int int0)
        {
            foreach (AbstractTreeNode1 @class in Nodes)
            {
                @class.vmethod_2(ref int0);
            }
        }

        public override int vmethod_1()
        {
            return 40;
        }

        public override void vmethod_0()
        {
            if (!Bool0)
            {
                return;
            }
            ToolTipText = GetToolTipText();
            BackColor = GetColor();
            ImageIndex = 40;
            SelectedImageIndex = 40;
        }

        public override string GetNodeText()
        {
            return "QB File";
        }

        public override Color GetColor()
        {
            return Color.LightCyan;
        }

        public override int CompareTo(object target)
        {
            if (!(target is ZzGenericNode1))
            {
                return -1;
            }
            if (((ZzGenericNode1) target).Text == Text)
            {
                return 0;
            }
            return 1;
        }
    }
}