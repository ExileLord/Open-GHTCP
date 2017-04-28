using System.IO;
using System.Text;

namespace ns7
{
	public class Class146
	{
		public byte[] Byte0;

		public Class146(Class144 class1440)
		{
			var num = class1440.vmethod_14();
			if (num == 0)
			{
				return;
			}
			Byte0 = new byte[num];
			class1440.vmethod_15(Byte0, Byte0.Length);
		}

		public override string ToString()
		{
			string result;
			try
			{
				result = Encoding.GetEncoding("UTF-8").GetString(Byte0);
			}
			catch (IOException)
			{
				result = new StringBuilder("").ToString();
			}
			return result;
		}
	}
}
