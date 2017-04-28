using System;
using System.IO;
using Compression.Zip;

namespace GHNamespace6
{
    public class Class202 : IDisposable
    {
        private int _int0;

        private int _int1;

        private int _int2;

        private MemoryStream _memoryStream0;

        private byte[] _byte0;

        public Class202()
        {
            method_1();
        }

        public Class202(byte[] byte1)
        {
            if (byte1 == null)
            {
                _byte0 = new byte[0];
                return;
            }
            _byte0 = byte1;
        }

        public byte[] method_0()
        {
            if (method_2() > 65535)
            {
                throw new ZipException("Data exceeds maximum length");
            }
            return (byte[]) _byte0.Clone();
        }

        public void method_1()
        {
            if (_byte0 == null || _byte0.Length != 0)
            {
                _byte0 = new byte[0];
            }
        }

        public int method_2()
        {
            return _byte0.Length;
        }

        public int method_3()
        {
            return _int2;
        }

        public int method_4()
        {
            return _int0;
        }

        public int method_5()
        {
            if (_int1 > _byte0.Length || _int1 < 4)
            {
                throw new ZipException("Find must be called before calling a Read method");
            }
            return _int1 + _int2 - _int0;
        }

        public bool method_6(int int3)
        {
            _int1 = _byte0.Length;
            _int2 = 0;
            _int0 = 0;
            var num = _int1;
            var num2 = int3 - 1;
            while (num2 != int3 && _int0 < _byte0.Length - 3)
            {
                num2 = method_20();
                num = method_20();
                if (num2 != int3)
                {
                    _int0 += num;
                }
            }
            bool result;
            if (result = (num2 == int3 && _int0 + num <= _byte0.Length))
            {
                _int1 = _int0;
                _int2 = num;
            }
            return result;
        }

        public void method_7(int int3, byte[] byte1)
        {
            if (int3 > 65535 || int3 < 0)
            {
                throw new ArgumentOutOfRangeException("headerID");
            }
            var num = (byte1 == null) ? 0 : byte1.Length;
            if (num > 65535)
            {
                throw new ArgumentOutOfRangeException("fieldData", "exceeds maximum length");
            }
            var num2 = _byte0.Length + num + 4;
            if (method_6(int3))
            {
                num2 -= method_3() + 4;
            }
            if (num2 > 65535)
            {
                throw new ZipException("Data exceeds maximum length");
            }
            method_13(int3);
            var array = new byte[num2];
            _byte0.CopyTo(array, 0);
            var index = _byte0.Length;
            _byte0 = array;
            method_21(ref index, int3);
            method_21(ref index, num);
            if (byte1 != null)
            {
                byte1.CopyTo(array, index);
            }
        }

        public void method_8()
        {
            _memoryStream0 = new MemoryStream();
        }

        public void method_9(int int3)
        {
            var byte_ = _memoryStream0.ToArray();
            _memoryStream0 = null;
            method_7(int3, byte_);
        }

        public void method_10(int int3)
        {
            _memoryStream0.WriteByte((byte) int3);
            _memoryStream0.WriteByte((byte) (int3 >> 8));
        }

        public void method_11(int int3)
        {
            method_10((short) int3);
            method_10((short) (int3 >> 16));
        }

        public void method_12(long long0)
        {
            method_11((int) (long0 & 4294967295L));
            method_11((int) (long0 >> 32));
        }

        public bool method_13(int int3)
        {
            var result = false;
            if (method_6(int3))
            {
                result = true;
                var num = _int1 - 4;
                var destinationArray = new byte[_byte0.Length - (method_3() + 4)];
                Array.Copy(_byte0, 0, destinationArray, 0, num);
                var num2 = num + method_3() + 4;
                Array.Copy(_byte0, num2, destinationArray, num, _byte0.Length - num2);
                _byte0 = destinationArray;
            }
            return result;
        }

        public long method_14()
        {
            method_19(8);
            return (method_15() & 4294967295L) | (long) method_15() << 32;
        }

        public int method_15()
        {
            method_19(4);
            var result = _byte0[_int0] + (_byte0[_int0 + 1] << 8) + (_byte0[_int0 + 2] << 16) +
                         (_byte0[_int0 + 3] << 24);
            _int0 += 4;
            return result;
        }

        public int method_16()
        {
            method_19(2);
            var result = _byte0[_int0] + (_byte0[_int0 + 1] << 8);
            _int0 += 2;
            return result;
        }

        public int method_17()
        {
            var result = -1;
            if (_int0 < _byte0.Length && _int1 + _int2 > _int0)
            {
                result = _byte0[_int0];
                _int0++;
            }
            return result;
        }

        public void method_18(int int3)
        {
            method_19(int3);
            _int0 += int3;
        }

        private void method_19(int int3)
        {
            if (_int1 > _byte0.Length || _int1 < 4)
            {
                throw new ZipException("Find must be called before calling a Read method");
            }
            if (_int0 > _int1 + _int2 - int3)
            {
                throw new ZipException("End of extra data");
            }
        }

        private int method_20()
        {
            if (_int0 > _byte0.Length - 2)
            {
                throw new ZipException("End of extra data");
            }
            var result = _byte0[_int0] + (_byte0[_int0 + 1] << 8);
            _int0 += 2;
            return result;
        }

        private void method_21(ref int int3, int int4)
        {
            _byte0[int3] = (byte) int4;
            _byte0[int3 + 1] = (byte) (int4 >> 8);
            int3 += 2;
        }

        public void Dispose()
        {
            if (_memoryStream0 != null)
            {
                _memoryStream0.Close();
            }
        }
    }
}