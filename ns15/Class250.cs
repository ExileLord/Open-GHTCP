using ns16;
using ns19;
using ns9;
using System;

namespace ns15
{
	public class Class250 : Class245
	{
		public QBCParser class362_0;

		private zzPakNode2 class318_0;

		private string string_0;

		private string string_1;

		public Class250(string string_2, QBCParser class362_1, zzPakNode2 class318_1, string string_3)
		{
			this.string_0 = string_2;
			this.class318_0 = class318_1;
			this.class362_0 = class362_1;
			this.string_1 = string_3;
		}

		public override void vmethod_0()
		{
			using (zzPakNode2 @class = new zzPakNode2())
			{
				@class.method_0("songs\\" + this.string_0 + ".mid.qb", this.class362_0.method_4(this.string_0));
				@class.method_16(this.string_1 + "songs\\" + this.string_0 + "_song.pak.xen");
			}
		}

		public override string ToString()
		{
			return "Create Game Track: " + this.string_0;
		}

		public override bool Equals(Class245 other)
		{
			return other is Class250 && (other as Class250).string_0 == this.string_0;
		}
	}
}
