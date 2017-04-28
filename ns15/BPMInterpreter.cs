using System;
using ns14;

namespace ns15
{
	public class BPMInterpreter
	{
		public Track<int, int> TSList = new Track<int, int>();

		public Track<int, int> bpmList = new Track<int, int>();

		public BPMInterpreter()
		{
		}

		public BPMInterpreter(string[] string_0)
		{
			for (int i = 0; i < string_0.Length; i++)
			{
				string text = string_0[i];
				string[] array = text.Split(new[]
				{
					' ',
					'\t',
					'='
				}, StringSplitOptions.RemoveEmptyEntries);
				int num = ChartParser.getNoteFromResolution(array[0]);
				int num2 = Convert.ToInt32(array[2]);
				string a;
				if ((a = array[1]) != null)
				{
					if (!(a == "TS"))
					{
						if (a == "B" && (bpmList.Count == 0 || bpmList[num] != num2))
						{
							bpmList.Add(num, num2);
						}
					}
					else if (TSList.Count == 0 || TSList[num] != num2)
					{
						TSList.Add(num, num2);
					}
				}
			}
			if (!TSList.ContainsKey(0))
			{
				TSList.Add(0, 4);
			}
		}
	}
}
