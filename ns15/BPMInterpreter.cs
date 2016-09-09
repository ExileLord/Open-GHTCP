using ns14;
using System;

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
				string[] array = text.Split(new char[]
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
						if (a == "B" && (this.bpmList.Count == 0 || this.bpmList[num] != num2))
						{
							this.bpmList.Add(num, num2);
						}
					}
					else if (this.TSList.Count == 0 || this.TSList[num] != num2)
					{
						this.TSList.Add(num, num2);
					}
				}
			}
			if (!this.TSList.ContainsKey(0))
			{
				this.TSList.Add(0, 4);
			}
		}
	}
}
