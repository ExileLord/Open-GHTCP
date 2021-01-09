using System;
using System.Collections.Generic;
using System.IO;

namespace GHNamespace7
{
    public static class Class216
    {
        public static SortedDictionary<string, string> SortedDictionary0 = new SortedDictionary<string, string>();

        private static readonly string String0 = "MM/dd/yyyy hh:mm:ss tt";

        private static readonly string String1 = "MM_dd_yy hh_mm_ss tt";

        private static readonly bool Bool0 = true;

        public static void smethod_0(string string2)
        {
            if (SortedDictionary0.Count != 0)
            {
                using (StreamWriter streamWriter = File.CreateText(string2 + DateTime.Now.ToString(String1) + ".log"))
                {
                    foreach (string current in SortedDictionary0.Keys)
                    {
                        streamWriter.WriteLine("[" + current + "]");
                        streamWriter.WriteLine("{");
                        streamWriter.WriteLine(SortedDictionary0[current]);
                        streamWriter.WriteLine("}");
                    }
                }
            }
        }

        public static void smethod_1(string string2, string string3)
        {
            SortedDictionary0.Add(DateTime.Now.ToString(String0) + " :: " + string2, string3 ?? "");
            if (Bool0)
            {
                Console.WriteLine(string.Concat("\n", DateTime.Now.ToString(String0), "\n-=- ", string2, " -=-\n"));
                Console.WriteLine(string3 + "\n-=- ENTRY LOG END -=-\n");
            }
        }

        public static void smethod_2()
        {
            SortedDictionary0.Clear();
        }
    }
}