using GuitarHero.Songlist;
using ns16;
using ns19;
using ns20;
using System;

namespace ns17
{
	public class Class255 : Class245
	{
		private GH3Songlist gh3Songlist_0;

		private Class318 class318_0;

		private string string_0;

		private int int_0;

		public Class255(int int_1, Class318 class318_1, GH3Songlist gh3Songlist_1)
		{
			this.string_0 = gh3Songlist_1.method_8(int_1);
			this.int_0 = int_1;
			this.class318_0 = class318_1;
			this.gh3Songlist_0 = gh3Songlist_1;
		}

		public override void vmethod_0()
		{
			Class308 @class = this.class318_0.method_8(this.gh3Songlist_0.gh3SetlistList[this.int_0].method_2());
			@class.method_5<Class266>(new Class266(this.int_0)).method_8(this.gh3Songlist_0.gh3SetlistList[this.int_0].method_6());
		}

		public override string ToString()
		{
			return "Update Setlist: " + this.string_0;
		}

		public override bool Equals(Class245 other)
		{
			return other is Class255 && (other as Class255).int_0 == this.int_0;
		}
	}
}
