using System;
using System.IO;

namespace ns14
{
	public class Class217 : IDisposable
	{
		private StringWriter stringWriter_0;

		private TextWriter textWriter_0;

		private string string_0;

		public Class217(string string_1)
		{
			string_0 = string_1;
			textWriter_0 = Console.Out;
			stringWriter_0 = new StringWriter();
			Console.SetOut(stringWriter_0);
		}

		public void Dispose()
		{
			Console.SetOut(textWriter_0);
			Class216.smethod_1(string_0, stringWriter_0.GetStringBuilder().ToString());
			stringWriter_0.Close();
		}
	}
}
