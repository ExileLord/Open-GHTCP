using ns14;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ns15
{
	public class Class368
	{
		public Track<int, List<string>> class228_0 = new Track<int, List<string>>();

		public Track<int, string> class228_1 = new Track<int, string>();

		public Class368()
		{
		}

		public Class368(string[] string_0)
		{
			for (int i = 0; i < string_0.Length; i++)
			{
				string text = string_0[i];
				string[] array = text.Split(new char[]
				{
					'=',
					'"'
				}, 3, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 3 && !(array[1].Trim() != "E"))
				{
					array[2] = array[2].TrimEnd(new char[]
					{
						' ',
						'\t'
					});
					if (array[2].EndsWith("\""))
					{
						array[2] = array[2].Substring(0, array[2].Length - 1);
					}
					int num = ChartParser.smethod_0(array[0].Trim());
					if (array[2].StartsWith("section "))
					{
						this.class228_1.Add(num, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(array[2].Substring("section ".Length).Replace('_', ' ')));
					}
					else if (this.class228_0.ContainsKey(num))
					{
						this.class228_0[num].Add(array[2]);
					}
					else
					{
						this.class228_0.Add(num, new List<string>());
						this.class228_0[num].Add(array[2]);
					}
				}
			}
		}
	}
}
