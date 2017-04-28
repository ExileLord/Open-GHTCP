using System.IO;
using System.Text;

namespace ns7
{
	public class Class146
	{
		public byte[] byte_0;

		public Class146(Class144 class144_0)
		{
			int num = class144_0.vmethod_14();
			if (num == 0)
			{
				return;
			}
			byte_0 = new byte[num];
			class144_0.vmethod_15(byte_0, byte_0.Length);
		}

		public override string ToString()
		{
			string result;
			try
			{
				result = Encoding.GetEncoding("UTF-8").GetString(byte_0);
			}
			catch (IOException)
			{
				result = new StringBuilder("").ToString();
			}
			return result;
		}
	}
}
