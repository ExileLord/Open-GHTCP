using System;
using System.Collections.Generic;
using System.IO;

namespace ns14
{
	public static class Class216
	{
		public static SortedDictionary<string, string> sortedDictionary_0 = new SortedDictionary<string, string>();

		private static string string_0 = "MM/dd/yyyy hh:mm:ss tt";

		private static string string_1 = "MM_dd_yy hh_mm_ss tt";

		private static bool bool_0 = true;

		public static void smethod_0(string string_2)
		{
			if (Class216.sortedDictionary_0.Count != 0)
			{
				using (StreamWriter streamWriter = File.CreateText(string_2 + DateTime.Now.ToString(Class216.string_1) + ".log"))
				{
					foreach (string current in Class216.sortedDictionary_0.Keys)
					{
						streamWriter.WriteLine("[" + current + "]");
						streamWriter.WriteLine("{");
						streamWriter.WriteLine(Class216.sortedDictionary_0[current]);
						streamWriter.WriteLine("}");
					}
				}
			}
		}

		public static void smethod_1(string string_2, string string_3)
		{
			Class216.sortedDictionary_0.Add(DateTime.Now.ToString(Class216.string_0) + " :: " + string_2, string_3 ?? "");
			if (Class216.bool_0)
			{
				Console.WriteLine(string.Concat(new string[]
				{
					"\n",
					DateTime.Now.ToString(Class216.string_0),
					"\n-=- ",
					string_2,
					" -=-\n"
				}));
				Console.WriteLine(string_3 + "\n-=- ENTRY LOG END -=-\n");
			}
		}

		public static void smethod_2()
		{
			Class216.sortedDictionary_0.Clear();
		}
	}
}
