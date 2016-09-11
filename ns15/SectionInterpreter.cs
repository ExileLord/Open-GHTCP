using ns14;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ns15
{
	public class SectionInterpreter
	{
		public Track<int, List<string>> otherList = new Track<int, List<string>>();

		public Track<int, string> sectionList = new Track<int, string>();

		public SectionInterpreter()
		{
		}

		public SectionInterpreter(string[] string_0)
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
					int num = ChartParser.getNoteFromResolution(array[0].Trim());
					if (array[2].StartsWith("section "))
					{
						this.sectionList.Add(num, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(array[2].Substring("section ".Length).Replace('_', ' ')));
					}
					else if (this.otherList.ContainsKey(num))
					{
						this.otherList[num].Add(array[2]);
					}
					else
					{
						this.otherList.Add(num, new List<string>());
						this.otherList[num].Add(array[2]);
					}
				}
			}
		}
	}
}
