using System;
using System.Text;

namespace GHNamespaceN
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
            TimeSpan timeSpan = (TimeSpan) arg;
            return smethod_0(timeSpan, format);
        }

        private static string smethod_0(TimeSpan timeSpan0, string string0)
        {
            StringBuilder stringBuilder = new StringBuilder(64);
            int length = string0.Length;
            int i = 0;
            while (i < length)
            {
                char c = string0[i];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    int j;
                    for (j = i + 1; j < length; j++)
                    {
                        if (string0[j] != c)
                        {
                            break;
                        }
                    }
                    smethod_1(stringBuilder, c, j - i, timeSpan0);
                    i = j;
                }
                else if (c == '\'')
                {
                    i++;
                    if (i < length && string0[i] == '\'')
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
                                if (string0[j] == '\'')
                                {
                                    break;
                                }
                            }
                            if (j >= length)
                            {
                                throw new ArgumentException("Missing trailing '");
                            }
                            if (j + 1 < length && string0[j + 1] == '\'')
                            {
                                j++;
                            }
                            else
                            {
                                flag = true;
                            }
                            stringBuilder.Append(string0.Substring(i, j));
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

        private static bool smethod_1(StringBuilder stringBuilder0, char char0, int int0, TimeSpan timeSpan0)
        {
            if (char0 <= 'd')
            {
                if (char0 == 'S')
                {
                    smethod_2(stringBuilder0, timeSpan0.Milliseconds, int0);
                    return true;
                }
                if (char0 == 'd')
                {
                    smethod_2(stringBuilder0, timeSpan0.Days, int0);
                    return true;
                }
            }
            else
            {
                if (char0 == 'h')
                {
                    smethod_2(stringBuilder0, timeSpan0.Hours, int0);
                    return true;
                }
                if (char0 == 'm')
                {
                    smethod_2(stringBuilder0, timeSpan0.Minutes, int0);
                    return true;
                }
                if (char0 == 's')
                {
                    smethod_2(stringBuilder0, timeSpan0.Seconds, int0);
                    return true;
                }
            }
            return false;
        }

        private static void smethod_2(StringBuilder stringBuilder0, int int0, int int1)
        {
            int num = 10;
            for (int i = 0; i < int1 - 1; i++)
            {
                if (int0 < num)
                {
                    stringBuilder0.Append('0');
                }
                num *= 10;
            }
            stringBuilder0.Append(int0);
        }
    }
}