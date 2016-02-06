using ns9;
using System;

namespace ns22
{
	public class Class336 : Class335
	{
		private readonly int int_1;

		private readonly byte byte_0;

		private readonly bool bool_0 = true;

		public Class336(int int_2, int int_3, byte byte_1, bool bool_1)
		{
			this.int_0 = int_2;
			this.int_1 = int_3;
			this.byte_0 = byte_1;
			this.bool_0 = bool_1;
		}

		public Enum38 method_1()
		{
			if (this.int_1 >= 60 && this.int_1 <= 106)
			{
				return (Enum38)((this.int_1 - 60) / 12);
			}
			return Enum38.const_4;
		}

		public Enum36 method_2()
		{
			if (this.int_1 == 108)
			{
				return Enum36.const_9;
			}
			if (this.int_1 == 116)
			{
				return Enum36.const_8;
			}
			if (this.int_1 < 60 || this.int_1 > 106)
			{
				return Enum36.const_10;
			}
			int num = (this.int_1 - 60) % 12;
			if (Enum.IsDefined(typeof(Enum36), num))
			{
				return (Enum36)num;
			}
			return Enum36.const_10;
		}

		public Enum39 method_3()
		{
			if (this.int_1 < 60 || this.int_1 > 106)
			{
				return Enum39.const_5;
			}
			Enum39 @enum = (Enum39)((this.int_1 - 60) % 12);
			if (@enum >= Enum39.const_0 && @enum <= Enum39.const_4)
			{
				return @enum;
			}
			return Enum39.const_5;
		}

		public int method_4()
		{
			return this.int_1;
		}

		public bool method_5()
		{
			return this.byte_0 > 0 && this.bool_0;
		}

		public override string ToString()
		{
			return string.Format("{0}: NoteId {1} ({2} {3})", new object[]
			{
				base.method_0(),
				this.int_1,
				this.byte_0,
				this.bool_0 ? "On" : "Off"
			});
		}
	}
}
