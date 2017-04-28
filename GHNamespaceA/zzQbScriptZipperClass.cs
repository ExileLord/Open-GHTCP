using System.Reflection;
using GHNamespace6;
using GHNamespace9;
using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespaceA
{
    public static class ZzQbScriptZipperClass
    {
        public static string GameName = "GH3";

        public static byte[] smethod_0(string string1)
        {
            return ZipManager.smethod_5(
                KeyGenerator.CryptoMethod(
                    Assembly.GetExecutingAssembly()
                        .GetManifestResourceStream(string.Concat("GHTCP.FileDB.QBS.", GameName, '.', string1)),
                    "MinimizedScript1f2g4h"), string1 + ".qbs");
        }

        public static void smethod_1(ScriptRootNode class2740)
        {
            class2740.method_7().method_7(smethod_0(QbSongClass1.GetDictString(class2740.Int0)));
        }

        public static byte[] smethod_2(string string1)
        {
            return ZipManager.smethod_5(
                KeyGenerator.CryptoMethod(
                    Assembly.GetExecutingAssembly().GetManifestResourceStream("GHTCP.FileDB.QB." + string1),
                    "MinimizedQBFile4f4g9h"), string1 + ".qb");
        }

        public static ZzGenericNode1 smethod_3(string string1)
        {
            return new ZzGenericNode1(string1, smethod_2(string1));
        }
    }
}