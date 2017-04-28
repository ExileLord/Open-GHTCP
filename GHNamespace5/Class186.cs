using System.Text;
using System.Threading;

namespace GHNamespace5
{
	public class Class186
	{
		private static readonly int Int0 = Thread.CurrentThread.CurrentCulture.TextInfo.OEMCodePage;

		public static int smethod_0()
		{
			return Int0;
		}

		public static string smethod_1(byte[] byte0, int int1)
		{
			if (byte0 == null)
			{
				return string.Empty;
			}
			return Encoding.GetEncoding(smethod_0()).GetString(byte0, 0, int1);
		}

		public static string smethod_2(int int1, byte[] byte0)
		{
			if (byte0 == null)
			{
				return string.Empty;
			}
			if ((int1 & 2048) != 0)
			{
				return Encoding.UTF8.GetString(byte0, 0, byte0.Length);
			}
			return smethod_1(byte0, byte0.Length);
		}

		public static byte[] smethod_3(string string0)
		{
			if (string0 == null)
			{
				return new byte[0];
			}
			return Encoding.GetEncoding(smethod_0()).GetBytes(string0);
		}

		public static byte[] smethod_4(int int1, string string0)
		{
			if (string0 == null)
			{
				return new byte[0];
			}
			if ((int1 & 2048) != 0)
			{
				return Encoding.UTF8.GetBytes(string0);
			}
			return smethod_3(string0);
		}

		private Class186()
		{
		}
	}
}
