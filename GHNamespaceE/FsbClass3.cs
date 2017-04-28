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
			using (var @class = new FsbClass1())
			{
				@class.Byte0 = FsbEncryptionKey;
				@class.Enum200 = FsbEnum1.Const3;
				@class.Enum210 = FsbFlags1.Flag0;
				for (var i = 0; i < stream0.Length; i++)
				{
					var stream = stream0[i];
					stream.Position = 0L;
					var class2 = AudioManager.smethod_3(stream);
					var class3 = new Class168();
					class3.FileName = i + ".mp3";
					class3.Enum220 = (((class2.method_0() == 1) ? FsbFlags2.Flag6 : FsbFlags2.Flag7) | FsbFlags2.Flag10);
					class3.Int0 = class2.method_3();
					class3.Ushort0 = 255;
					class3.Short0 = 0;
					class3.Ushort1 = 255;
					class3.Uint3 = (uint)class2.method_0();
					class3.Uint0 = class2.Uint0;
					class3.Uint1 = 0u;
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
