using System;
using System.Collections.Generic;
using GHNamespace7;

namespace GHNamespace8
{
	public class InstrumentType : Track<int, List<string>>
	{
		public InstrumentType()
		{
		}

		public InstrumentType(string[] string0) : this()
		{
			if (string0.Length != 0)
			{
				for (var i = 0; i < string0.Length; i++)
				{
					var text = string0[i];
					var array = text.Split(new[]
					{
						' ',
						'\t',
						'=',
						'"',
						'E'
					}, StringSplitOptions.RemoveEmptyEntries);
                    method_5(ChartParser.GetNoteFromResolution(array[0]), array[1]);
				}
			}
		}

		public void method_5(int int0, string string0)
		{
			if (ContainsKey(int0))
			{
				base[int0].Add(string0);
				return;
			}
			Add(int0, new List<string>(new[]
			{
				string0
			}));
		}
	}
}
