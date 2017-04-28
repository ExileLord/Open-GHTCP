using System.Text;
using System.Threading;

namespace ns12
{
	public class Class186
	{
		private static int int_0 = Thread.CurrentThread.CurrentCulture.TextInfo.OEMCodePage;

		public static int smethod_0()
		{
			return int_0;
		}

		public static string smethod_1(byte[] byte_0, int int_1)
		{
			if (byte_0 == null)
			{
				return string.Empty;
			}
			return Encoding.GetEncoding(smethod_0()).GetString(byte_0, 0, int_1);
		}

		public static string smethod_2(int int_1, byte[] byte_0)
		{
			if (byte_0 == null)
			{
				return string.Empty;
			}
			if ((int_1 & 2048) != 0)
			{
				return Encoding.UTF8.GetString(byte_0, 0, byte_0.Length);
			}
			return smethod_1(byte_0, byte_0.Length);
		}

		public static byte[] smethod_3(string string_0)
		{
			if (string_0 == null)
			{
				return new byte[0];
			}
			return Encoding.GetEncoding(smethod_0()).GetBytes(string_0);
		}

		public static byte[] smethod_4(int int_1, string string_0)
		{
			if (string_0 == null)
			{
				return new byte[0];
			}
			if ((int_1 & 2048) != 0)
			{
				return Encoding.UTF8.GetBytes(string_0);
			}
			return smethod_3(string_0);
		}

		private Class186()
		{
		}
	}
}
