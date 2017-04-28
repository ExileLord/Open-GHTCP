using ns16;
using ns19;
using ns9;

namespace ns15
{
	public class Class250 : QbEditor
	{
		public QbcParser Class3620;

		private ZzPakNode2 _class3180;

		private readonly string _string0;

		private readonly string _string1;

		public Class250(string string2, QbcParser class3621, ZzPakNode2 class3181, string string3)
		{
			_string0 = string2;
			_class3180 = class3181;
			Class3620 = class3621;
			_string1 = string3;
		}

		public override void vmethod_0()
		{
			using (var @class = new ZzPakNode2())
			{
				@class.method_0("songs\\" + _string0 + ".mid.qb", Class3620.method_4(_string0));
				@class.method_16(_string1 + "songs\\" + _string0 + "_song.pak.xen");
			}
		}

		public override string ToString()
		{
			return "Create Game Track: " + _string0;
		}

		public override bool Equals(QbEditor other)
		{
			return other is Class250 && (other as Class250)._string0 == _string0;
		}
	}
}
