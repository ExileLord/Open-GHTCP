using System;
using System.Text;

namespace ns9
{
	public class Class361 : IFormatProvider, ICustomFormatter
	{
		public object GetFormat(Type formatType)
		{
			if (formatType == typeof(ICustomFormatter))
			{
				return this;
			}
			return null;
		}

		public string Format(string format, object arg, IFormatProvider formatProvider)
		{
			if (!(arg is TimeSpan))
			{
				throw new ArgumentNullException();
			}
			TimeSpan timeSpan_ = (TimeSpan)arg;
			return Class361.smethod_0(timeSpan_, format);
		}

		private static string smethod_0(TimeSpan timeSpan_0, string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			int length = string_0.Length;
			int i = 0;
			while (i < length)
			{
				char c = string_0[i];
				if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
				{
					int j;
					for (j = i + 1; j < length; j++)
					{
						if (string_0[j] != c)
						{
							break;
						}
					}
					Class361.smethod_1(stringBuilder, c, j - i, timeSpan_0);
					i = j;
				}
				else if (c == '\'')
				{
					i++;
					if (i < length && string_0[i] == '\'')
					{
						stringBuilder.Append('\'');
						i++;
					}
					else
					{
						bool flag = false;
						while (!flag)
						{
							int j;
							for (j = i; j < length; j++)
							{
								if (string_0[j] == '\'')
								{
									break;
								}
							}
							if (j >= length)
							{
								throw new ArgumentException("Missing trailing '");
							}
							if (j + 1 < length && string_0[j + 1] == '\'')
							{
								j++;
							}
							else
							{
								flag = true;
							}
							stringBuilder.Append(string_0.Substring(i, j));
							i = j + 1;
						}
					}
				}
				else
				{
					stringBuilder.Append(c);
					i++;
				}
			}
			return stringBuilder.ToString();
		}

		private static bool smethod_1(StringBuilder stringBuilder_0, char char_0, int int_0, TimeSpan timeSpan_0)
		{
			if (char_0 <= 'd')
			{
				if (char_0 == 'S')
				{
					Class361.smethod_2(stringBuilder_0, timeSpan_0.Milliseconds, int_0);
					return true;
				}
				if (char_0 == 'd')
				{
					Class361.smethod_2(stringBuilder_0, timeSpan_0.Days, int_0);
					return true;
				}
			}
			else
			{
				if (char_0 == 'h')
				{
					Class361.smethod_2(stringBuilder_0, timeSpan_0.Hours, int_0);
					return true;
				}
				if (char_0 == 'm')
				{
					Class361.smethod_2(stringBuilder_0, timeSpan_0.Minutes, int_0);
					return true;
				}
				if (char_0 == 's')
				{
					Class361.smethod_2(stringBuilder_0, timeSpan_0.Seconds, int_0);
					return true;
				}
			}
			return false;
		}

		private static void smethod_2(StringBuilder stringBuilder_0, int int_0, int int_1)
		{
			int num = 10;
			for (int i = 0; i < int_1 - 1; i++)
			{
				if (int_0 < num)
				{
					stringBuilder_0.Append('0');
				}
				num *= 10;
			}
			stringBuilder_0.Append(int_0);
		}
	}
}
