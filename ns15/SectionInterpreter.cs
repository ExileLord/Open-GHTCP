using System;
using System.Collections.Generic;
using System.Globalization;
using ns14;

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
			for (var i = 0; i < string_0.Length; i++)
			{
				var text = string_0[i];
				var array = text.Split(new[]
				{
					'=',
					'"'
				}, 3, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 3 && !(array[1].Trim() != "E"))
				{
					array[2] = array[2].TrimEnd(' ', '\t');
					if (array[2].EndsWith("\""))
					{
						array[2] = array[2].Substring(0, array[2].Length - 1);
					}
					var num = ChartParser.getNoteFromResolution(array[0].Trim());
					if (array[2].StartsWith("section "))
					{
						sectionList.Add(num, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(array[2].Substring("section ".Length).Replace('_', ' ')));
					}
					else if (otherList.ContainsKey(num))
					{
						otherList[num].Add(array[2]);
					}
					else
					{
						otherList.Add(num, new List<string>());
						otherList[num].Add(array[2]);
					}
				}
			}
		}
	}
}
