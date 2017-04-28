using ns13;
using ns16;
using ns20;
using ns21;
using System;
using System.Reflection;

namespace ns17
{
	public static class zzQbScriptZipperClass
	{
		public static string GameName = "GH3";

		public static byte[] smethod_0(string string_1)
		{
			return ZIPManager.smethod_5(KeyGenerator.cryptoMethod(Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Concat(new object[]
			{
				"GHTCP.FileDB.QBS.",
				zzQbScriptZipperClass.GameName,
				'.',
				string_1
			})), "MinimizedScript1f2g4h"), string_1 + ".qbs");
		}

		public static void smethod_1(ScriptRootNode class274_0)
		{
			class274_0.method_7().method_7(zzQbScriptZipperClass.smethod_0(QbSongClass1.GetDictString(class274_0.int_0)));
		}

		public static byte[] smethod_2(string string_1)
		{
			return ZIPManager.smethod_5(KeyGenerator.cryptoMethod(Assembly.GetExecutingAssembly().GetManifestResourceStream("GHTCP.FileDB.QB." + string_1), "MinimizedQBFile4f4g9h"), string_1 + ".qb");
		}

		public static zzGenericNode1 smethod_3(string string_1)
		{
			return new zzGenericNode1(string_1, zzQbScriptZipperClass.smethod_2(string_1));
		}
	}
}
