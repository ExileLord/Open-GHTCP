using System.IO;
using System.Text;
using GHNamespaceM;

namespace GHNamespaceE
{
    public class FsbClass3
    {
        private static readonly byte[] FsbEncryptionKey = Encoding.ASCII.GetBytes("5atu6w4zaw");

        public static long smethod_0(string string0, Stream[] stream0)
        {
            long length;
            using (FsbClass1 @class = new FsbClass1())
            {
                @class.Byte0 = FsbEncryptionKey;
                @class.Enum200 = FsbEnum1.Const3;
                @class.Enum210 = FsbFlags1.Flag0;
                for (int i = 0; i < stream0.Length; i++)
                {
                    Stream stream = stream0[i];
                    stream.Position = 0L;
                    GHNamespace2.Class16 class2 = AudioManager.smethod_3(stream);
                    Class168 class3 = new Class168
                    {
                        FileName = i + ".mp3",
                        Enum220 = (((class2.method_0() == 1) ? FsbFlags2.Flag6 : FsbFlags2.Flag7) |
                                      FsbFlags2.Flag10),
                        Int0 = class2.method_3(),
                        Ushort0 = 255,
                        Short0 = 0,
                        Ushort1 = 255,
                        Uint3 = (uint)class2.method_0(),
                        Uint0 = class2.Uint0,
                        Uint1 = 0u
                    };
                    class3.Uint2 = class3.Uint0 - 1u;
                    class3.Float2 = 1f;
                    class3.Float3 = 10000f;
                    class3.Int1 = 0;
                    class3.Short1 = 0;
                    class3.Short2 = -1;
                    class3.Stream1 = stream;
                    @class.method_33().Add(class3);
                }
                @class.method_16(string0);
                length = new FileInfo(string0).Length;
            }
            return length;
        }
    }
}