using System;
using System.IO;

namespace ns12
{
	public class Class185 : Interface8
	{
		private static readonly char[] char_0;

		private static readonly char[] char_1;

		static Class185()
		{
			char[] invalidPathChars = Path.GetInvalidPathChars();
			int num = invalidPathChars.Length + 2;
			Class185.char_1 = new char[num];
			Array.Copy(invalidPathChars, 0, Class185.char_1, 0, invalidPathChars.Length);
			Class185.char_1[num - 1] = '*';
			Class185.char_1[num - 2] = '?';
			num = invalidPathChars.Length + 4;
			Class185.char_0 = new char[num];
			Array.Copy(invalidPathChars, 0, Class185.char_0, 0, invalidPathChars.Length);
			Class185.char_0[num - 1] = ':';
			Class185.char_0[num - 2] = '\\';
			Class185.char_0[num - 3] = '*';
			Class185.char_0[num - 4] = '?';
		}
	}
}
