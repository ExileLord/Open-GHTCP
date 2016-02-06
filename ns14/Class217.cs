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
			this.string_0 = string_1;
			this.textWriter_0 = Console.Out;
			this.stringWriter_0 = new StringWriter();
			Console.SetOut(this.stringWriter_0);
		}

		public void Dispose()
		{
			Console.SetOut(this.textWriter_0);
			Class216.smethod_1(this.string_0, this.stringWriter_0.GetStringBuilder().ToString());
			this.stringWriter_0.Close();
		}
	}
}
