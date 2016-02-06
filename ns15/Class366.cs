using ns14;
using System;
using System.Collections.Generic;

namespace ns15
{
	public class Class366
	{
		public Track<int, Class364> class228_0 = new Track<int, Class364>();

		public Track<int, int> class228_1 = new Track<int, int>();

		public Track<int, int> class228_2 = new Track<int, int>();

		public Track<int, int> class228_3 = new Track<int, int>();

		public Track<int, int> class228_4 = new Track<int, int>();

		public Track<int, int> class228_5 = new Track<int, int>();

		public Track<int, int> class228_6 = new Track<int, int>();

		public Track<int, List<string>> class228_7 = new Track<int, List<string>>();

		public bool bool_0 = true;

		private string string_0;

		public Class366()
		{
		}

		public Class366(string[] string_1, int int_0)
		{
			if (!(this.bool_0 = (string_1.Length == 0)))
			{
				for (int i = 0; i < string_1.Length; i++)
				{
					string text = string_1[i];
					string[] array = text.Split(new char[]
					{
						' ',
						'\t',
						'='
					}, StringSplitOptions.RemoveEmptyEntries);
					int num = ChartParser.smethod_0(array[0]);
					string a;
					if ((a = array[1]) != null)
					{
						if (!(a == "N"))
						{
							if (!(a == "S"))
							{
								if (a == "E")
								{
									if (this.class228_7.ContainsKey(num))
									{
										this.string_0 = array[2];
										for (int j = 3; j < array.Length; j++)
										{
											this.string_0 = this.string_0 + " " + array[j];
										}
										this.class228_7[num].Add(this.string_0);
									}
									else
									{
										this.string_0 = array[2];
										for (int k = 3; k < array.Length; k++)
										{
											this.string_0 = this.string_0 + " " + array[k];
										}
										this.class228_7.Add(num, new List<string>());
										this.class228_7[num].Add(this.string_0);
									}
								}
							}
							else
							{
								switch (Convert.ToInt32(array[2]))
								{
								case 0:
									if (!this.class228_2.ContainsKey(num))
									{
										this.class228_2.Add(num, ChartParser.smethod_0(array[3]));
									}
									break;
								case 1:
									if (!this.class228_3.ContainsKey(num))
									{
										this.class228_3.Add(num, ChartParser.smethod_0(array[3]));
									}
									break;
								case 2:
									if (!this.class228_1.ContainsKey(num))
									{
										this.class228_1.Add(num, ChartParser.smethod_0(array[3]));
									}
									break;
								case 3:
									if (!this.class228_4.ContainsKey(num))
									{
										this.class228_4.Add(num, ChartParser.smethod_0(array[3]));
									}
									break;
								case 4:
									if (!this.class228_5.ContainsKey(num))
									{
										this.class228_5.Add(num, ChartParser.smethod_0(array[3]));
									}
									break;
								case 5:
									if (!this.class228_6.ContainsKey(num))
									{
										this.class228_6.Add(num, ChartParser.smethod_0(array[3]));
									}
									break;
								}
							}
						}
						else
						{
							bool[] bool_ = new bool[6];
							int num2 = ChartParser.smethod_0(array[3]);
							if (num2 <= int_0 / 4)
							{
								num2 = 0;
							}
							if (!this.class228_0.ContainsKey(num))
							{
								this.class228_0.Add(num, new Class364(bool_, num2));
							}
							else
							{
								int int_ = this.class228_0[num].int_0;
								if (int_ < num2)
								{
									this.class228_0[num].int_0 = num2;
								}
							}
							this.class228_0[num].bool_0[Convert.ToInt32(array[2])] = true;
						}
					}
				}
			}
		}
	}
}
