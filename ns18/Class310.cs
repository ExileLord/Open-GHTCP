using System;
using System.Drawing;

namespace ns18
{
	public abstract class Class310 : Class258
	{
		private static bool bool_1;

		public abstract object vmethod_7();

		public abstract byte[] vmethod_8();

		public abstract void vmethod_9(byte[] byte_0);

		public string method_1(int int_0)
		{
			string text = int_0.ToString("x");
			while (text.Length < 8)
			{
				text = "0" + text;
			}
			return text;
		}

		public override Color vmethod_6()
		{
			if (Class310.bool_1 = !Class310.bool_1)
			{
				return Color.Ivory;
			}
			return Color.Khaki;
		}

		public override object Clone()
		{
			Class310 @class = (Class310)base.Clone();
			@class.vmethod_9(this.vmethod_8());
			return @class;
		}

		public override bool Equals(object obj)
		{
			return obj is Class310 && ((Class310)obj).vmethod_7().Equals(this.vmethod_7());
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
