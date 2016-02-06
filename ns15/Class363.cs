using ns14;
using System;

namespace ns15
{
	public class Class363
	{
		public Track<int, int> class228_0 = new Track<int, int>();

		public Track<int, int> class228_1 = new Track<int, int>();

		public Class363()
		{
		}

		public Class363(string[] string_0)
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
				int num = ChartParser.smethod_0(array[0]);
				int num2 = Convert.ToInt32(array[2]);
				string a;
				if ((a = array[1]) != null)
				{
					if (!(a == "TS"))
					{
						if (a == "B" && (this.class228_1.Count == 0 || this.class228_1[num] != num2))
						{
							this.class228_1.Add(num, num2);
						}
					}
					else if (this.class228_0.Count == 0 || this.class228_0[num] != num2)
					{
						this.class228_0.Add(num, num2);
					}
				}
			}
			if (!this.class228_0.ContainsKey(0))
			{
				this.class228_0.Add(0, 4);
			}
		}
	}
}
