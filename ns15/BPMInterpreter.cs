using System;
using ns14;

namespace ns15
{
	public class BpmInterpreter
	{
		public Track<int, int> TsList = new Track<int, int>();

		public Track<int, int> BpmList = new Track<int, int>();

		public BpmInterpreter()
		{
		}

		public BpmInterpreter(string[] string0)
		{
			for (var i = 0; i < string0.Length; i++)
			{
				var text = string0[i];
				var array = text.Split(new[]
				{
					' ',
					'\t',
					'='
				}, StringSplitOptions.RemoveEmptyEntries);
				var num = ChartParser.GetNoteFromResolution(array[0]);
				var num2 = Convert.ToInt32(array[2]);
				string a;
				if ((a = array[1]) != null)
				{
					if (!(a == "TS"))
					{
						if (a == "B" && (BpmList.Count == 0 || BpmList[num] != num2))
						{
							BpmList.Add(num, num2);
						}
					}
					else if (TsList.Count == 0 || TsList[num] != num2)
					{
						TsList.Add(num, num2);
					}
				}
			}
			if (!TsList.ContainsKey(0))
			{
				TsList.Add(0, 4);
			}
		}
	}
}
