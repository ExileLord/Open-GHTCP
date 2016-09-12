using ns13;
using ns16;
using ns20;
using ns21;
using System;
using System.Reflection;

namespace ns17
{
	public static class Class372
	{
		public static string string_0 = "GH3";

		public static byte[] smethod_0(string string_1)
		{
			return ZIPManager.smethod_5(KeyGenerator.smethod_5(Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Concat(new object[]
			{
				"GHTCP.FileDB.QBS.",
				Class372.string_0,
				'.',
				string_1
			})), "MinimizedScript1f2g4h"), string_1 + ".qbs");
		}

		public static void smethod_1(Class274 class274_0)
		{
			class274_0.method_7().method_7(Class372.smethod_0(QbSongClass1.smethod_5(class274_0.int_0)));
		}

		public static byte[] smethod_2(string string_1)
		{
			return ZIPManager.smethod_5(KeyGenerator.smethod_5(Assembly.GetExecutingAssembly().GetManifestResourceStream("GHTCP.FileDB.QB." + string_1), "MinimizedQBFile4f4g9h"), string_1 + ".qb");
		}

		public static Class308 smethod_3(string string_1)
		{
			return new Class308(string_1, Class372.smethod_2(string_1));
		}
	}
}
