using System;
using System.IO;

namespace GHNamespaceM
{
    public class FsbClass2 : Stream
    {
        public Stream Stream0;

        public byte[] Byte0;

        private static readonly byte[] Byte1 =
        {
            0,
            128,
            64,
            192,
            32,
            160,
            96,
            224,
            16,
            144,
            80,
            208,
            48,
            176,
            112,
            240,
            8,
            136,
            72,
            200,
            40,
            168,
            104,
            232,
            24,
            152,
            88,
            216,
            56,
            184,
            120,
            248,
            4,
            132,
            68,
            196,
            36,
            164,
            100,
            228,
            20,
            148,
            84,
            212,
            52,
            180,
            116,
            244,
            12,
            140,
            76,
            204,
            44,
            172,
            108,
            236,
            28,
            156,
            92,
            220,
            60,
            188,
            124,
            252,
            2,
            130,
            66,
            194,
            34,
            162,
            98,
            226,
            18,
            146,
            82,
            210,
            50,
            178,
            114,
            242,
            10,
            138,
            74,
            202,
            42,
            170,
            106,
            234,
            26,
            154,
            90,
            218,
            58,
            186,
            122,
            250,
            6,
            134,
            70,
            198,
            38,
            166,
            102,
            230,
            22,
            150,
            86,
            214,
            54,
            182,
            118,
            246,
            14,
            142,
            78,
            206,
            46,
            174,
            110,
            238,
            30,
            158,
            94,
            222,
            62,
            190,
            126,
            254,
            1,
            129,
            65,
            193,
            33,
            161,
            97,
            225,
            17,
            145,
            81,
            209,
            49,
            177,
            113,
            241,
            9,
            137,
            73,
            201,
            41,
            169,
            105,
            233,
            25,
            153,
            89,
            217,
            57,
            185,
            121,
            249,
            5,
            133,
            69,
            197,
            37,
            165,
            101,
            229,
            21,
            149,
            85,
            213,
            53,
            181,
            117,
            245,
            13,
            141,
            77,
            205,
            45,
            173,
            109,
            237,
            29,
            157,
            93,
            221,
            61,
            189,
            125,
            253,
            3,
            131,
            67,
            195,
            35,
            163,
            99,
            227,
            19,
            147,
            83,
            211,
            51,
            179,
            115,
            243,
            11,
            139,
            75,
            203,
            43,
            171,
            107,
            235,
            27,
            155,
            91,
            219,
            59,
            187,
            123,
            251,
            7,
            135,
            71,
            199,
            39,
            167,
            103,
            231,
            23,
            151,
            87,
            215,
            55,
            183,
            119,
            247,
            15,
            143,
            79,
            207,
            47,
            175,
            111,
            239,
            31,
            159,
            95,
            223,
            63,
            191,
            127,
            255
        };

        public override bool CanRead => Stream0.CanRead;

        public override bool CanSeek => Stream0.CanSeek;

        public override bool CanWrite => Stream0.CanWrite;

        public override long Length => Stream0.Length;

        public override long Position
        {
            get => Stream0.Position;
            set => Stream0.Position = value;
        }

        public long method_0()
        {
            return Stream0.Position % Byte0.LongLength;
        }

        public FsbClass2(Stream stream1, byte[] byte2)
        {
            Stream0 = stream1 ?? throw new ArgumentNullException("BaseStream", "Fsb Encryption");
            Byte0 = byte2 ?? throw new ArgumentNullException("Key", "Fsb Encryption");
        }

        public FsbClass2(Stream stream1) : this(stream1, smethod_0(stream1))
        {
        }

        private static byte[] smethod_0(Stream stream1)
        {
            long position = stream1.Position;
            byte[] array = new byte[65536];
            int num = stream1.Read(array, 0, array.Length);
            Array.Resize(ref array, num);
            int i = 2;
            while (i < 50)
            {
                byte[] result = smethod_1(array, i);
                stream1.Position = position;
                try
                {
                    FsbClass1.smethod_1(stream1, result);
                    goto IL_FD;
                }
                catch
                {
                }
                i++;
                continue;
                IL_FD:
                stream1.Position = position;
                return result;
            }
            if (num > 1000)
            {
                Array.Resize(ref array, 1000);
                int j = 2;
                while (j < 50)
                {
                    byte[] result2 = smethod_1(array, j);
                    stream1.Position = position;
                    try
                    {
                        FsbClass1.smethod_1(stream1, result2);
                        goto IL_9A;
                    }
                    catch
                    {
                    }
                    j++;
                    continue;
                    IL_9A:
                    stream1.Position = position;
                    return result2;
                }
            }
            if (num > 500)
            {
                Array.Resize(ref array, 500);
                int k = 2;
                while (k < 50)
                {
                    byte[] result3 = smethod_1(array, k);
                    stream1.Position = position;
                    try
                    {
                        FsbClass1.smethod_1(stream1, result3);
                        goto IL_EA;
                    }
                    catch
                    {
                    }
                    k++;
                    continue;
                    IL_EA:
                    stream1.Position = position;
                    return result3;
                }
            }
            stream1.Position = position;
            return null;
        }

        private static byte[] smethod_1(byte[] byte2, int int0)
        {
            byte[] array = new byte[int0];
            uint[] array2 = new uint[256];
            for (int i = 0; i < int0; i++)
            {
                Array.Clear(array2, 0, array2.Length);
                int num = 0;
                while (i + num < byte2.Length)
                {
                    array2[byte2[i + num]] += 1u;
                    num += int0;
                }
                int num2 = 0;
                for (int j = 0; j < array2.Length; j++)
                {
                    if (array2[j] >= array2[num2])
                    {
                        num2 = j;
                    }
                }
                array[i] = (byte) num2;
            }
            return array;
        }

        public byte method_1(byte byte2, ref long long0)
        {
            byte arg_1A0 = byte2;
            byte[] arg190 = Byte0;
            long num;
            long0 = (num = long0) + 1L;
            byte2 = (byte) (arg_1A0 ^ arg190[(int) ((IntPtr) num)]);
            if (long0 == Byte0.LongLength)
            {
                long0 = 0L;
            }
            return byte2;
        }

        public byte method_2(byte byte2, ref long long0)
        {
            return method_1(Byte1[byte2], ref long0);
        }

        public byte method_3(byte byte2, ref long long0)
        {
            return Byte1[method_1(byte2, ref long0)];
        }

        public void method_4(byte[] byte2, int int0, int int1, long long0)
        {
            for (int i = int0; i < int1; i++)
            {
                byte2[i] = method_2(byte2[i], ref long0);
            }
        }

        public void method_5(byte[] byte2, int int0, int int1, long long0)
        {
            for (int i = int0; i < int1; i++)
            {
                byte2[i] = method_3(byte2[i], ref long0);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            long long_ = method_0();
            int num = Stream0.Read(buffer, offset, count);
            method_5(buffer, offset, num, long_);
            return num;
        }

        public override int ReadByte()
        {
            long num = method_0();
            return method_3(Byte0[(int) ((IntPtr) method_0())], ref num);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            method_4(buffer, offset, count, method_0());
            Stream0.Write(buffer, offset, count);
        }

        public override void WriteByte(byte value)
        {
            long num = method_0();
            Stream0.WriteByte(method_2(value, ref num));
        }

        public override void Flush()
        {
            Stream0.Flush();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return Stream0.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            Stream0.SetLength(value);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Stream0.Close();
            }
            base.Dispose(disposing);
        }
    }
}