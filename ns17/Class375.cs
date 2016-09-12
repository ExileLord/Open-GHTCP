using ns16;
using ns18;
using ns19;
using ns20;
using ns21;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ns17
{
	public class Class375
	{
		public readonly DateTime dateTime_0;

		public readonly Version version_0;

		public readonly int[] int_0;

		public readonly bool bool_0;

		public readonly bool bool_1;

		public readonly bool bool_2;

		private static string string_0 = "script\\ghtcp\\ghtcp.hash";

		public bool method_0()
		{
			return this.bool_2 && this.bool_1 && this.bool_0;
		}

		public Class375(bool bool_3)
		{
			this.bool_2 = bool_3;
			this.bool_1 = bool_3;
			this.bool_0 = bool_3;
		}

		public Class375(Class318 class318_0)
		{
			if (!class318_0.method_6(Class375.string_0))
			{
				return;
			}
			Class308 @class = new Class308(Class375.string_0, KeyGenerator.smethod_8(class318_0.method_12(Class375.string_0), "MaC39SubInfo1245"));
			this.version_0 = new Version(@class.method_5<Class273>(new Class273("version")).method_7());
			float[] array = @class.method_5<Class267>(new Class267("date")).method_7().method_7<float>();
			this.dateTime_0 = new DateTime((int)array[0], (int)array[1], (int)array[2]);
			this.int_0 = @class.method_5<Class267>(new Class267("hash")).method_7().method_7<int>();
			class318_0.method_7(Class375.string_0);
			using (Stream26 stream = class318_0.method_17())
			{
				stream.Position = 0L;
				//this.bool_0 = Class244.smethod_53<int>(Class244.smethod_21(Class244.smethod_43(stream.stream_0)), this.int_0);
                this.bool_0 = true;
			}
			GC.Collect();
			this.bool_1 = (Assembly.GetExecutingAssembly().GetName().Version.CompareTo(this.version_0) == 0);
			this.bool_2 = true;
			if (!this.bool_1)
			{
				MessageBox.Show("The game settings were created under a different version.");
			}
			if (!this.bool_0)
			{
				MessageBox.Show("The game settings were modified by an external tool!"); // Fuck you max!
			}
		}

		public static void smethod_0(Class318 class318_0)
		{
			if (class318_0.method_6(Class375.string_0))
			{
				class318_0.method_7(Class375.string_0);
			}
			Class308 @class = new Class308();
			@class.method_3(new Class273("version", Class375.string_0, Assembly.GetExecutingAssembly().GetName().Version.ToString()));
			using (Stream26 stream = class318_0.method_17())
			{
				stream.Position = 0L;
				@class.method_3(new Class267("hash", Class375.string_0, new Class280(KeyGenerator.smethod_21(KeyGenerator.smethod_43(stream.stream_0)))));
			}
			GC.Collect();
			DateTime now = DateTime.Now;
			@class.method_3(new Class267("date", Class375.string_0, new Class279(new float[]
			{
				(float)now.Year,
				(float)now.Month,
				(float)now.Day
			})));
			class318_0.method_1<Class332>(Class375.string_0, new Class332(Class375.string_0, KeyGenerator.smethod_2(@class.method_8(), "MaC39SubInfo1245")));
		}
	}
}
