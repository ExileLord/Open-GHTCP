using System;
using System.Collections;
using System.IO;
using Compression.Zip;
using GHNamespace5;

namespace GHNamespace6
{
    public class Stream23 : Stream22
    {
        private ArrayList _arrayList0 = new ArrayList();

        private readonly Class192 _class1920 = new Class192();

        private Class193 _class1930;

        private int _int0 = -1;

        private Enum31 _enum310 = Enum31.Const1;

        private long _long0;

        private long _long1;

        private readonly byte[] _byte1 = new byte[0];

        private bool _bool2;

        private long _long2 = -1L;

        private long _long3 = -1L;

        private readonly Enum30 _enum300 = Enum30.Const2;

        public Stream23(Stream stream1) : base(stream1, new Class194(-1, true))
        {
        }

        public void method_6(int int1)
        {
            Class1940.method_7(int1);
            _int0 = int1;
        }

        private void method_7(int int1)
        {
            Stream0.WriteByte((byte) (int1 & 255));
            Stream0.WriteByte((byte) (int1 >> 8 & 255));
        }

        private void method_8(int int1)
        {
            method_7(int1);
            method_7(int1 >> 16);
        }

        private void method_9(long long4)
        {
            method_8((int) long4);
            method_8((int) (long4 >> 32));
        }

        public void method_10(Class193 class1931)
        {
            if (class1931 == null)
            {
                throw new ArgumentNullException("entry");
            }
            if (_arrayList0 == null)
            {
                throw new InvalidOperationException("ZipOutputStream was finished");
            }
            if (_class1930 != null)
            {
                method_11();
            }
            if (_arrayList0.Count == 2147483647)
            {
                throw new ZipException("Too many entries for Zip file");
            }
            var @enum = class1931.method_27();
            var int_ = _int0;
            class1931.method_5(class1931.method_4() & 2048);
            _bool2 = false;
            var flag = true;
            if (@enum == Enum31.Const0)
            {
                class1931.method_5(class1931.method_4() & -9);
                if (class1931.method_23() >= 0L)
                {
                    if (class1931.method_21() < 0L)
                    {
                        class1931.method_22(class1931.method_23());
                    }
                    else if (class1931.method_21() != class1931.method_23())
                    {
                        throw new ZipException("Method STORED, but compressed size != size");
                    }
                }
                else if (class1931.method_21() >= 0L)
                {
                    class1931.method_24(class1931.method_21());
                }
                if (class1931.method_21() < 0L || class1931.method_25() < 0L)
                {
                    if (method_0())
                    {
                        flag = false;
                    }
                    else
                    {
                        @enum = Enum31.Const1;
                        int_ = 0;
                    }
                }
            }
            if (@enum == Enum31.Const1)
            {
                if (class1931.method_21() == 0L)
                {
                    class1931.method_24(class1931.method_21());
                    class1931.method_26(0L);
                    @enum = Enum31.Const0;
                }
                else if (class1931.method_23() < 0L || class1931.method_21() < 0L || class1931.method_25() < 0L)
                {
                    flag = false;
                }
            }
            if (!flag)
            {
                if (!method_0())
                {
                    class1931.method_5(class1931.method_4() | 8);
                }
                else
                {
                    _bool2 = true;
                }
            }
            if (method_1() != null)
            {
                class1931.method_1(true);
                if (class1931.method_25() < 0L)
                {
                    class1931.method_5(class1931.method_4() | 8);
                }
            }
            class1931.method_7(_long1);
            class1931.method_28(@enum);
            _enum310 = @enum;
            _long3 = -1L;
            if (_enum300 == Enum30.Const1 || (class1931.method_21() < 0L && _enum300 == Enum30.Const2))
            {
                class1931.method_13();
            }
            method_8(67324752);
            method_7(class1931.method_11());
            method_7(class1931.method_4());
            method_7((byte) @enum);
            method_8((int) class1931.method_17());
            if (flag)
            {
                method_8((int) class1931.method_25());
                if (class1931.method_15())
                {
                    method_8(-1);
                    method_8(-1);
                }
                else
                {
                    method_8(class1931.method_0() ? ((int) class1931.method_23() + 12) : ((int) class1931.method_23()));
                    method_8((int) class1931.method_21());
                }
            }
            else
            {
                if (_bool2)
                {
                    _long2 = Stream0.Position;
                }
                method_8(0);
                if (_bool2)
                {
                    _long3 = Stream0.Position;
                }
                if (class1931.method_15() && _bool2)
                {
                    method_8(-1);
                    method_8(-1);
                }
                else
                {
                    method_8(0);
                    method_8(0);
                }
            }
            var array = Class186.smethod_4(class1931.method_4(), class1931.method_20());
            if (array.Length > 65535)
            {
                throw new ZipException("Entry name too long.");
            }
            var @class = new Class202(class1931.method_29());
            if (class1931.method_15() && (flag || _bool2))
            {
                @class.method_8();
                if (flag)
                {
                    @class.method_12(class1931.method_21());
                    @class.method_12(class1931.method_23());
                }
                else
                {
                    @class.method_12(-1L);
                    @class.method_12(-1L);
                }
                @class.method_9(1);
                if (!@class.method_6(1))
                {
                    throw new ZipException("Internal error cant find extra data");
                }
                if (_bool2)
                {
                    _long3 = @class.method_4();
                }
            }
            else
            {
                @class.method_13(1);
            }
            var array2 = @class.method_0();
            method_7(array.Length);
            method_7(array2.Length);
            if (array.Length > 0)
            {
                Stream0.Write(array, 0, array.Length);
            }
            if (class1931.method_15() && _bool2)
            {
                _long3 += Stream0.Position;
            }
            if (array2.Length > 0)
            {
                Stream0.Write(array2, 0, array2.Length);
            }
            _long1 += 30 + array.Length + array2.Length;
            _class1930 = class1931;
            _class1920.vmethod_1();
            if (@enum == Enum31.Const1)
            {
                Class1940.method_0();
                Class1940.method_7(int_);
            }
            _long0 = 0L;
            if (class1931.method_0())
            {
                if (class1931.method_25() < 0L)
                {
                    method_12(class1931.method_17() << 16);
                    return;
                }
                method_12(class1931.method_25());
            }
        }

        public void method_11()
        {
            if (_class1930 == null)
            {
                throw new InvalidOperationException("No open entry");
            }
            if (_enum310 == Enum31.Const1)
            {
                base.vmethod_0();
            }
            var num = (_enum310 == Enum31.Const1) ? Class1940.method_1() : _long0;
            if (_class1930.method_21() < 0L)
            {
                _class1930.method_22(_long0);
            }
            else if (_class1930.method_21() != _long0)
            {
                throw new ZipException(string.Concat("size was ", _long0, ", but I expected ", _class1930.method_21()));
            }
            if (_class1930.method_23() < 0L)
            {
                _class1930.method_24(num);
            }
            else if (_class1930.method_23() != num)
            {
                throw new ZipException(string.Concat("compressed size was ", num, ", but I expected ",
                    _class1930.method_23()));
            }
            if (_class1930.method_25() < 0L)
            {
                _class1930.method_26(_class1920.vmethod_0());
            }
            else if (_class1930.method_25() != _class1920.vmethod_0())
            {
                throw new ZipException(string.Concat("crc was ", _class1920.vmethod_0(), ", but I expected ",
                    _class1930.method_25()));
            }
            _long1 += num;
            if (_class1930.method_0())
            {
                var expr_1E6 = _class1930;
                expr_1E6.method_24(expr_1E6.method_23() + 12L);
            }
            if (_bool2)
            {
                _bool2 = false;
                var position = Stream0.Position;
                Stream0.Seek(_long2, SeekOrigin.Begin);
                method_8((int) _class1930.method_25());
                if (_class1930.method_15())
                {
                    if (_long3 == -1L)
                    {
                        throw new ZipException("Entry requires zip64 but this has been turned off");
                    }
                    Stream0.Seek(_long3, SeekOrigin.Begin);
                    method_9(_class1930.method_21());
                    method_9(_class1930.method_23());
                }
                else
                {
                    method_8((int) _class1930.method_23());
                    method_8((int) _class1930.method_21());
                }
                Stream0.Seek(position, SeekOrigin.Begin);
            }
            if ((_class1930.method_4() & 8) != 0)
            {
                method_8(134695760);
                method_8((int) _class1930.method_25());
                if (_class1930.method_15())
                {
                    method_9(_class1930.method_23());
                    method_9(_class1930.method_21());
                    _long1 += 24L;
                }
                else
                {
                    method_8((int) _class1930.method_23());
                    method_8((int) _class1930.method_21());
                    _long1 += 16L;
                }
            }
            _arrayList0.Add(_class1930);
            _class1930 = null;
        }

        private void method_12(long long4)
        {
            _long1 += 12L;
            method_4(method_1());
            var array = new byte[12];
            var random = new Random();
            random.NextBytes(array);
            array[11] = (byte) (long4 >> 24);
            method_3(array, 0, array.Length);
            Stream0.Write(array, 0, array.Length);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (_class1930 == null)
            {
                throw new InvalidOperationException("No open entry.");
            }
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "Cannot be negative");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Cannot be negative");
            }
            if (buffer.Length - offset < count)
            {
                throw new ArgumentException("Invalid offset/count combination");
            }
            _class1920.vmethod_3(buffer, offset, count);
            _long0 += count;
            var @enum = _enum310;
            if (@enum != Enum31.Const0)
            {
                if (@enum != Enum31.Const1)
                {
                    return;
                }
                base.Write(buffer, offset, count);
            }
            else
            {
                if (method_1() != null)
                {
                    method_13(buffer, offset, count);
                    return;
                }
                Stream0.Write(buffer, offset, count);
            }
        }

        private void method_13(byte[] byte2, int int1, int int2)
        {
            var array = new byte[4096];
            while (int2 > 0)
            {
                var num = (int2 < 4096) ? int2 : 4096;
                Array.Copy(byte2, int1, array, 0, num);
                method_3(array, 0, num);
                Stream0.Write(array, 0, num);
                int2 -= num;
                int1 += num;
            }
        }

        public override void vmethod_0()
        {
            if (_arrayList0 == null)
            {
                return;
            }
            if (_class1930 != null)
            {
                method_11();
            }
            long num = _arrayList0.Count;
            var num2 = 0L;
            foreach (Class193 @class in _arrayList0)
            {
                method_8(33639248);
                method_7(45);
                method_7(@class.method_11());
                method_7(@class.method_4());
                method_7((short) @class.method_27());
                method_8((int) @class.method_17());
                method_8((int) @class.method_25());
                if (!@class.method_14() && @class.method_23() < 4294967295L)
                {
                    method_8((int) @class.method_23());
                }
                else
                {
                    method_8(-1);
                }
                if (!@class.method_14() && @class.method_21() < 4294967295L)
                {
                    method_8((int) @class.method_21());
                }
                else
                {
                    method_8(-1);
                }
                var array = Class186.smethod_4(@class.method_4(), @class.method_20());
                if (array.Length > 65535)
                {
                    throw new ZipException("Name too long.");
                }
                var class2 = new Class202(@class.method_29());
                if (@class.method_16())
                {
                    class2.method_8();
                    if (@class.method_14() || @class.method_21() >= 4294967295L)
                    {
                        class2.method_12(@class.method_21());
                    }
                    if (@class.method_14() || @class.method_23() >= 4294967295L)
                    {
                        class2.method_12(@class.method_23());
                    }
                    if (@class.method_6() >= 4294967295L)
                    {
                        class2.method_12(@class.method_6());
                    }
                    class2.method_9(1);
                }
                else
                {
                    class2.method_13(1);
                }
                var array2 = class2.method_0();
                var array3 = (@class.method_32() != null)
                    ? Class186.smethod_4(@class.method_4(), @class.method_32())
                    : new byte[0];
                if (array3.Length > 65535)
                {
                    throw new ZipException("Comment too long.");
                }
                method_7(array.Length);
                method_7(array2.Length);
                method_7(array3.Length);
                method_7(0);
                method_7(0);
                if (@class.method_8() != -1)
                {
                    method_8(@class.method_8());
                }
                else if (@class.method_33())
                {
                    method_8(16);
                }
                else
                {
                    method_8(0);
                }
                if (@class.method_6() >= 4294967295L)
                {
                    method_8(-1);
                }
                else
                {
                    method_8((int) @class.method_6());
                }
                if (array.Length > 0)
                {
                    Stream0.Write(array, 0, array.Length);
                }
                if (array2.Length > 0)
                {
                    Stream0.Write(array2, 0, array2.Length);
                }
                if (array3.Length > 0)
                {
                    Stream0.Write(array3, 0, array3.Length);
                }
                num2 += 46 + array.Length + array2.Length + array3.Length;
            }
            using (var stream = new Stream25(Stream0))
            {
                stream.method_1(num, num2, _long1, _byte1);
            }
            _arrayList0 = null;
        }
    }
}