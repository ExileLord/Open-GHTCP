using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GHNamespace9;
using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespaceC
{
    public class ZzPakNode2 : ZzPakNode1, IEnumerable, IDisposable, IEnumerable<INterface12>
    {
        public string String0;

        public string String1;

        public ZzPakNode1 Class3170; //Parent?

        public List<INterface12> List0;

        public ZzPakNode2 Class3180; //Linked List?..

        public Dictionary<int, int[]> Dictionary0;

        public bool Bool1;

        public bool Bool2;

        public bool Bool3;

        public int Int0;

        public Stream26 Stream260;

        public bool Bool4;

        public ZzPakNode2() : this(true)
        {
        }

        public ZzPakNode2(bool bool5) : this(bool5, true, 0)
        {
        }

        public ZzPakNode2(bool bool5, bool bool6, int int1) : base("PakFile")
        {
            Class3170 = new ZzPakNode1(true);
            List0 = new List<INterface12>();
            Dictionary0 = new Dictionary<int, int[]>();
            Bool1 = true;
            Bool2 = true;
            Bool4 = true;
            //base..ctor("PakFile");
            Bool2 = bool5;
            Bool1 = bool6;
            Int0 = int1;
            ImageIndex = 37;
            SelectedImageIndex = 37;
        }

        public ZzPakNode2(string string2, bool bool5) : this(string2, null, bool5)
        {
        }

        public ZzPakNode2(string string2, string string3, bool bool5)
        {
            Class3170 = new ZzPakNode1(true);
            List0 = new List<INterface12>();
            Dictionary0 = new Dictionary<int, int[]>();
            Bool1 = true;
            Bool2 = true;
            Bool4 = true;
            //base..ctor();
            Text = KeyGenerator.GetFileName(string2);
            String0 = string2;
            String1 = string3;
            Bool4 = bool5;
            if (File.Exists(string2))
            {
                method_4();
            }
            ImageIndex = 37;
            SelectedImageIndex = 37;
        }

        private void method_4()
        {
            if (Stream260 == null)
            {
                Stream260 = new Stream26(File.Open(String0, FileMode.Open, FileAccess.Read, FileShare.Read));
            }
            Class3180 = ((String1 != null) ? new ZzPakNode2(String1, false) : this);
            if (Stream260.Length == 0L)
            {
                throw new Exception("Pak File is empty!");
            }
            var num = 0;
            var num2 = Stream260.ReadInt();
            Stream260.ReverseEndianness = (Bool2 = (!QbSongClass1.ContainsKey(num2) ||
                                                    !QbSongClass1.GetDictString(num2).StartsWith(".")));
            var @enum = (Enum35) Stream260.ReadIntAt(28);
            Bool1 = ((@enum & Enum35.Flag3) == Enum35.Flag0);
            Int0 = Stream260.ReadIntAt(Bool1 ? 12 : 16,
                Bool2 && (@enum & Enum35.Flag4) == Enum35.Flag0 && (@enum & Enum35.Flag5) == Enum35.Flag0);
            if (Bool4 && String0 != null)
            {
                var text = KeyGenerator.GetFileName(String0);
                if (text.Contains("_song"))
                {
                    QbSongClass1.GenerateSongTrackStuff(text.Substring(0, text.LastIndexOf("_song.pak")).ToLower());
                }
                else if (!Bool1)
                {
                    QbSongClass1.GenerateSongTrackStuff(text.Substring(0, text.LastIndexOf(".pak")).ToLower());
                }
            }
            while (true)
            {
                var enum2 = (Enum35) Stream260.ReadIntAt(num + 28);
                var flag = Bool2 && (enum2 & Enum35.Flag4) == Enum35.Flag0 && (enum2 & Enum35.Flag5) == Enum35.Flag0;
                var int_ = Stream260.ReadIntAt(num, flag);
                if (QbSongClass1.ContainsKey(int_))
                {
                    if (QbSongClass1.GetDictString(int_).Equals(".last"))
                    {
                        return;
                    }
                    if (QbSongClass1.GetDictString(int_).Equals("last"))
                    {
                        break;
                    }
                }
                var int2 = Stream260.ReadInt(flag) + num;
                var int3 = Stream260.ReadInt(flag);
                var num3 = Stream260.ReadIntAt(num + (Bool1 ? 16 : 12), flag);
                var num4 = Stream260.ReadIntAt(num + 20, flag);
                var int4 = Stream260.ReadInt(flag);
                Stream260.Position += 4L;
                if ((enum2 & Enum35.Flag3) != Enum35.Flag0)
                {
                    Bool1 = false;
                    var text2 = Stream260.ReadString(160);
                    var num5 = text2.IndexOf('\0');
                    if (num5 >= 0)
                    {
                        text2 = text2.Substring(0, num5);
                    }
                    if (QbSongClass1.ContainsKey(int_) && !QbSongClass1.GetDictString(int_).EndsWith(".qb.ngc") &&
                        !QbSongClass1.GetDictString(int_).EndsWith(".qb.ps2"))
                    {
                        if (!Bool2)
                        {
                            if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".ps2", ""),
                                    true))
                            {
                                QbSongClass1.AddKeyToDictionary(text2);
                            }
                            else if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".qb", ""),
                                         true))
                            {
                                QbSongClass1.AddKeyToDictionary(text2);
                            }
                        }
                        else if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".ngc", ""),
                                     true))
                        {
                            QbSongClass1.AddKeyToDictionary(text2);
                        }
                        else if (num3 == KeyGenerator.GetQbKey(text2 = text2.Replace("/", "\\").Replace(".qb", ""),
                                     true))
                        {
                            QbSongClass1.AddKeyToDictionary(text2);
                        }
                    }
                    else
                    {
                        var text3 = "abcdefghijklmnopqrstuvwxyz";
                        for (var i = 0; i < text3.Length; i++)
                        {
                            var c = text3[i];
                            if (num3 == KeyGenerator.GetQbKey(c + text2, true))
                            {
                                QbSongClass1.AddKeyToDictionary(c + text2);
                            }
                        }
                    }
                    if (num4 == KeyGenerator.GetQbKey(text2 = KeyGenerator.GetFileNameNoExt(text2), true))
                    {
                        QbSongClass1.AddKeyToDictionary(text2);
                    }
                }
                TreeNode treeNode;
                if (QbSongClass1.ContainsKey(int_) && QbSongClass1.GetDictString(int_).Contains("qb"))
                {
                    treeNode = new Class309(int_, int2, int3, num3, num4, int4, enum2);
                }
                else if (QbSongClass1.ContainsKey(int_) && QbSongClass1.GetDictString(int_).Contains("qs"))
                {
                    treeNode = new Class328(int_, int2, int3, num3, num4, int4, enum2);
                }
                else
                {
                    treeNode = new ZzCocoaNode12(int_, int2, int3, num3, num4, int4, enum2);
                }
                if (Bool4)
                {
                    if (QbSongClass1.ContainsKey(num3))
                    {
                        method_1(QbSongClass1.GetDictString(num3), treeNode);
                    }
                    else
                    {
                        method_5(num3, (INterface12) treeNode);
                    }
                }
                else
                {
                    List0.Add((INterface12) treeNode);
                }
                num += (((enum2 & Enum35.Flag3) != Enum35.Flag0) ? 192 : 32);
            }
        }

        public void method_5(int int1, INterface12 interface120)
        {
            Class3170.Nodes.Add((TreeNode) interface120);
            if (!Nodes.Contains(Class3170))
            {
                Nodes.Add(Class3170);
            }
            var @interface = method_11(int1);
            if (@interface == null)
            {
                List0.Add(interface120);
                return;
            }
            List0[List0.IndexOf(@interface)] = interface120;
        }

        public override string vmethod_0()
        {
            return "";
        }

        public bool zzQbFileExists(string string2)
        {
            return method_10(string2) != null;
        }

        public bool method_7(string string2)
        {
            var @interface = method_10(string2);
            ((TreeNode) @interface).Remove();
            return @interface != null && List0.Remove(@interface);
        }

        public Class309 ZzGetNode1(string string2)
        {
            var @interface = method_10(string2);
            if (@interface == null)
            {
                return null;
            }
            if (@interface is Class309)
            {
                return (Class309) method_15(@interface);
            }
            var @class = @interface.imethod_20(new Class309());
            if (Bool4)
            {
                ((TreeNode) @interface).Remove();
                method_1(string2, @class);
            }
            else
            {
                List0[List0.IndexOf(@interface)] = @class;
            }
            return method_15(@class);
        }

        public Class328 method_9(string string2)
        {
            var @interface = method_10(string2);
            if (@interface == null)
            {
                return null;
            }
            if (@interface is Class328)
            {
                return (Class328) method_15(@interface);
            }
            var @class = @interface.imethod_20(new Class328());
            if (Bool4)
            {
                ((TreeNode) @interface).Remove();
                method_1(string2, @class);
            }
            else
            {
                List0[List0.IndexOf(@interface)] = @class;
            }
            return method_15(@class);
        }

        public INterface12 method_10(string string2)
        {
            return method_11(QbSongClass1.AddKeyToDictionary(string2));
        }

        public INterface12 method_11(int int1)
        {
            foreach (var current in List0)
            {
                if (current.imethod_7() == int1)
                {
                    return current;
                }
            }
            return null;
        }

        public byte[] method_12(string string2)
        {
            return method_14(method_10(string2));
        }

        public byte[] method_13(int int1)
        {
            return method_14(method_11(int1));
        }

        public byte[] method_14(INterface12 interface120)
        {
            if (interface120 == null)
            {
                return null;
            }
            if (interface120.imethod_18())
            {
                return Stream260.ReadBytesAt(interface120.imethod_0(), interface120.imethod_2(), false);
            }
            return interface120.imethod_16();
        }

        public T method_15<T>(T gparam0) where T : class, INterface12
        {
            if (gparam0 == null)
            {
                return default(T);
            }
            if (gparam0.imethod_18())
            {
                gparam0.imethod_17(Stream260.ReadBytesAt(gparam0.imethod_0(), gparam0.imethod_2(), false));
            }
            return gparam0;
        }

        public virtual void vmethod_1()
        {
            if (Stream260 == null)
            {
                throw new IOException("Pak File was never parsed");
            }
            method_16(String0);
        }

        public void method_16(string string2)
        {
            var stream = method_17();
            if (Stream260 != null && String0 == string2)
            {
                Stream260.Close();
            }
            KeyGenerator.WriteAllBytes(string2, stream.ReadEverything());
            stream.Dispose();
            if (Stream260 != null && String0 == string2)
            {
                if (Class3180 != null && Class3180 != this)
                {
                    Class3180.vmethod_1();
                }
                Dispose();
                method_4();
                GC.Collect();
            }
        }

        public Stream26 method_17()
        {
            var stream = new Stream26(Bool2);
            var stream2 = new Stream26();
            method_18(stream, stream2);
            stream.WriteByteArray(stream2.ReadEverything(), false);
            stream2.Dispose();
            return stream;
        }

        private static int smethod_0(long long0, int int1)
        {
            var num = 1 << int1;
            var num2 = num - 1;
            return (int) (num - (long0 & num2) & num2);
        }

        public void method_18(Stream26 stream261, Stream26 stream262)
        {
            var num = 0;
            foreach (var current in List0)
            {
                num += (((current.imethod_14() & Enum35.Flag3) == Enum35.Flag0 ||
                         !QbSongClass1.ContainsKey(current.imethod_7()))
                    ? 32
                    : 192);
            }
            if (Bool1)
            {
                num = (num + 32 + 4095 & -4096);
            }
            else
            {
                num += (Bool2 ? 64 : 48);
            }
            var num2 = 0;
            var list = new List<INterface12>();
            foreach (var current2 in List0)
            {
                if (current2 is Class309 && (current2 as Class309).vmethod_8())
                {
                    var string_ = current2.imethod_9().Replace(".qb", ".qs");
                    if (!Class3180.zzQbFileExists(string_))
                    {
                        if (!current2.imethod_18())
                        {
                            list.Add(new Class328(string_, (current2 as Class309).vmethod_10()));
                        }
                        else
                        {
                            list.Add(new Class328(string_));
                        }
                    }
                    else
                    {
                        var @interface = Class3180.method_10(string_);
                        if (@interface.imethod_18() || ((Class328) @interface).Dictionary0 !=
                            (current2 as Class309).vmethod_10())
                        {
                            ((Class328) @interface).Dictionary0 = (current2 as Class309).vmethod_10();
                        }
                    }
                }
            }
            if (list.Count != 0)
            {
                Class3180.List0.AddRange(list);
            }
            int num4;
            foreach (var current3 in List0)
            {
                var flag = Bool2 && (current3.imethod_14() & Enum35.Flag4) == Enum35.Flag0 &&
                           (current3.imethod_14() & Enum35.Flag5) == Enum35.Flag0;
                var num3 = current3.imethod_7();
                if (current3.imethod_4() != 0)
                {
                    stream261.WriteInt(current3.imethod_4(), flag);
                }
                else
                {
                    var text = QbSongClass1.GetDictString(num3);
                    if (!Bool1 && !text.EndsWith(".qb.ngc") && !text.EndsWith(".qb.ps2"))
                    {
                        stream261.WriteInt(1270999134, flag);
                    }
                    else if (text.Contains(".qb"))
                    {
                        stream261.WriteUInt(2817852868u, flag);
                    }
                    else
                    {
                        stream261.WriteInt(1952304453, flag);
                    }
                }
                if (this is ZzPabNode && Bool3)
                {
                    stream261.WriteInt((int) stream262.Length, flag);
                }
                else
                {
                    stream261.WriteInt(num - num2 + (int) stream262.Length, flag);
                }
                stream261.WriteInt(current3.imethod_2(), flag);
                if (Bool1)
                {
                    stream261.WriteInt(Int0, flag);
                }
                stream261.WriteInt(num3, flag);
                if (!Bool1)
                {
                    stream261.WriteInt(Int0, flag);
                }
                stream261.WriteInt(current3.imethod_10(), flag);
                stream261.WriteInt(current3.imethod_12(), flag);
                stream261.WriteInt((int) current3.imethod_14(), false);
                var flag2 = false;
                if ((current3.imethod_14() & Enum35.Flag3) != Enum35.Flag0 && QbSongClass1.ContainsKey(num3))
                {
                    flag2 = true;
                    var text2 = QbSongClass1.GetDictString(num3);
                    if (!current3.imethod_6().EndsWith(".qb.ngc") && !current3.imethod_6().EndsWith(".qb.ps2"))
                    {
                        if (Bool1)
                        {
                            text2 = text2.Replace("\\", "/");
                        }
                        else if (!Bool2)
                        {
                            text2 = text2.Replace("\\", "/") + (current3.imethod_6().EndsWith(".qb") ? "" : ".qb") +
                                    ".ps2";
                        }
                        else
                        {
                            text2 = text2.Replace("\\", "/") + (current3.imethod_6().EndsWith(".qb") ? "" : ".qb") +
                                    ".ngc";
                        }
                    }
                    else
                    {
                        text2 = text2.Substring(1);
                    }
                    stream261.WriteString(text2);
                    stream261.WriteNBytes(0, 160 - text2.Length);
                }
                stream262.WriteByteArray(method_14(current3));
                num4 = ((Bool2 || Bool1) ? smethod_0(stream262.Length, 5) : smethod_0(stream262.Length, 4));
                stream262.WriteNBytes(0, num4);
                num2 += (flag2 ? 192 : 32);
            }
            stream261.WriteUInt(Bool1 ? 749989691u : 3039057503u);
            if (this is ZzPabNode && Bool3)
            {
                stream261.WriteInt((int) stream262.Length);
            }
            else
            {
                stream261.WriteInt(num - num2 + (int) stream262.Length);
            }
            stream261.WriteInt(4);
            if (Bool1)
            {
                stream261.WriteInt(Int0);
                stream261.WriteUInt(2306521930u);
                stream261.WriteInt(1794739921);
                stream261.WriteNBytes(0, 8);
            }
            else
            {
                stream261.WriteNBytes(0, 4);
                stream261.WriteInt(Int0);
                stream261.WriteNBytes(0, 12);
            }
            num4 = (Bool1 ? smethod_0(stream261.Length, 12) : (Bool2 ? 32 : 16));
            stream261.WriteNBytes(0, num4);
            stream262.WriteNBytes(171, 4);
            stream262.WriteNBytes(0, 12);
            num4 = (Bool1 ? smethod_0(stream262.Length, 12) : ((int) stream262.Length % (Bool2 ? 32 : 16)));
            stream262.WriteNBytes(171, num4);
        }

        public IEnumerator<INterface12> GetEnumerator()
        {
            return List0.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return List0.GetEnumerator();
        }

        public void Dispose()
        {
            if (Stream260 != null)
            {
                Stream260.Close();
                Stream260.Dispose();
                Stream260 = null;
            }
            Class3170.Nodes.Clear();
            List0.Clear();
            Nodes.Clear();
            Dictionary0.Clear();
            if (Class3180 != null && Class3180 != this)
            {
                Class3180.Dispose();
            }
        }
    }
}