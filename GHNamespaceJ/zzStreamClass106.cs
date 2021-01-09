using System;
using System.IO;
using SharpAudio.ASC.Mp3.Decoding;

namespace GHNamespaceJ
{
    public class ZzStreamClass106
    {
        private readonly Stream _stream;

        private readonly int _int0;

        private int _int1;

        private readonly byte[] _buffer;

        private readonly CircularByteBuffer _circBuffer;

        public ZzStreamClass106(Stream stream1, int int2)
        {
            _stream = stream1;
            _int0 = int2;
            _buffer = new byte[_int0];
            _circBuffer = new CircularByteBuffer(_int0);
        }

        public Stream method_0()
        {
            return _stream;
        }

        public int method_1(byte[] byte1, int int2, int int3)
        {
            int num = 0;
            bool flag = true;
            while (num < int3 && flag)
            {
                if (_int1 > 0)
                {
                    _int1--;
                    byte1[int2 + num] = _circBuffer[_int1];
                    num++;
                }
                else
                {
                    int num2 = int3 - num;
                    int num3 = _stream.Read(_buffer, 0, num2);
                    flag = (num3 >= num2);
                    for (int i = 0; i < num3; i++)
                    {
                        _circBuffer.method_0(_buffer[i]);
                        byte1[int2 + num + i] = _buffer[i];
                    }
                    num += num3;
                }
            }
            return num;
        }

        public void IncrementSomeVariableAndCheckIfTheBackStreamIsFisted(int int2)
        {
            _int1 += int2;
            if (_int1 > _int0)
            {
                Console.WriteLine("YOUR BACKSTREAM IS FISTED!");
            }
        }

        public void method_3()
        {
            _stream.Close();
        }
    }
}