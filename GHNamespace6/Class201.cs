using System;
using System.IO;
using System.Security.Cryptography;
using Compression;
using Compression.Zip;

namespace GHNamespace6
{
    public class Class201
    {
        private int _int0;

        private readonly byte[] _byte0;

        private int _int1;

        private byte[] _byte1;

        private byte[] _byte2;

        private int _int2;

        private ICryptoTransform _icryptoTransform0;

        private readonly Stream _stream0;

        public Class201(Stream stream1, int int3)
        {
            _stream0 = stream1;
            if (int3 < 1024)
            {
                int3 = 1024;
            }
            _byte0 = new byte[int3];
            _byte1 = _byte0;
        }

        public int method_0()
        {
            return _int0;
        }

        public int method_1()
        {
            return _int2;
        }

        public void method_2(int int3)
        {
            _int2 = int3;
        }

        public void method_3(Class196 class1960)
        {
            if (_int2 > 0)
            {
                class1960.method_6(_byte1, _int1 - _int2, _int2);
                _int2 = 0;
            }
        }

        public void method_4()
        {
            _int0 = 0;
            var i = _byte0.Length;
            while (i > 0)
            {
                var num = _stream0.Read(_byte0, _int0, i);
                if (num > 0)
                {
                    _int0 += num;
                    i -= num;
                }
                else
                {
                    if (_int0 == 0)
                    {
                        throw new SharpZipBaseException("Unexpected EOF");
                    }
                    goto IL_5A;
                }
            }
            IL_5A:
            if (_icryptoTransform0 != null)
            {
                _int1 = _icryptoTransform0.TransformBlock(_byte0, 0, _int0, _byte1, 0);
            }
            else
            {
                _int1 = _int0;
            }
            _int2 = _int1;
        }

        public int method_5(byte[] byte3)
        {
            return method_6(byte3, 0, byte3.Length);
        }

        public int method_6(byte[] byte3, int int3, int int4)
        {
            if (int4 < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            var num = int3;
            var i = int4;
            while (i > 0)
            {
                if (_int2 <= 0)
                {
                    method_4();
                    if (_int2 <= 0)
                    {
                        return 0;
                    }
                }
                var num2 = Math.Min(i, _int2);
                Array.Copy(_byte0, _int0 - _int2, byte3, num, num2);
                num += num2;
                i -= num2;
                _int2 -= num2;
            }
            return int4;
        }

        public int method_7(byte[] byte3, int int3, int int4)
        {
            if (int4 < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            var num = int3;
            var i = int4;
            while (i > 0)
            {
                if (_int2 <= 0)
                {
                    method_4();
                    if (_int2 <= 0)
                    {
                        return 0;
                    }
                }
                var num2 = Math.Min(i, _int2);
                Array.Copy(_byte1, _int1 - _int2, byte3, num, num2);
                num += num2;
                i -= num2;
                _int2 -= num2;
            }
            return int4;
        }

        public int method_8()
        {
            if (_int2 <= 0)
            {
                method_4();
                if (_int2 <= 0)
                {
                    throw new ZipException("EOF in header");
                }
            }
            var result = (byte) (_byte0[_int0 - _int2] & 255);
            _int2--;
            return result;
        }

        public int method_9()
        {
            return method_8() | method_8() << 8;
        }

        public int method_10()
        {
            return method_9() | method_9() << 16;
        }

        public long method_11()
        {
            return (long) ((ulong) method_10() | (ulong) method_10() << 32);
        }

        public void method_12(ICryptoTransform icryptoTransform1)
        {
            _icryptoTransform0 = icryptoTransform1;
            if (_icryptoTransform0 != null)
            {
                if (_byte0 == _byte1)
                {
                    if (_byte2 == null)
                    {
                        _byte2 = new byte[4096];
                    }
                    _byte1 = _byte2;
                }
                _int1 = _int0;
                if (_int2 > 0)
                {
                    _icryptoTransform0.TransformBlock(_byte0, _int0 - _int2, _int2, _byte1, _int0 - _int2);
                }
            }
            else
            {
                _byte1 = _byte0;
                _int1 = _int0;
            }
        }
    }
}