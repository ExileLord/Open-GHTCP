using System;
using System.Collections.Generic;

namespace ns9
{
	public class Class356 : Interface15
	{
		private DateTime dateTime_0 = DateTime.MinValue;

		private int int_0 = -1;

		private DateTime dateTime_1 = DateTime.MinValue;

		private Dictionary<string, bool> dictionary_0 = new Dictionary<string, bool>();

		private Dictionary<string, bool> dictionary_1 = new Dictionary<string, bool>();

		public void imethod_0(string string_0)
		{
			Console.WriteLine(string_0);
		}

		public void imethod_1(string string_0)
		{
			string stackTrace = Environment.StackTrace;
			Console.WriteLine("WARNING: " + string_0);
			Console.WriteLine(stackTrace);
			if (this.dictionary_1.ContainsKey(stackTrace))
			{
				return;
			}
			while (true)
			{
				Console.Write("\tContinue? This can be dangerous, corrupt your files, etc! (y/n/y!): ");
				string text = Console.ReadLine();
				string a;
				if ((a = text.ToLower()) != null)
				{
					if (a == "y")
					{
						return;
					}
					if (!(a == "n"))
					{
						if (a == "y!")
						{
							break;
						}
					}
					else
					{
						Environment.Exit(-1);
					}
				}
			}
			this.dictionary_1[stackTrace] = true;
		}
	}
}
