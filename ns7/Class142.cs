namespace ns7
{
	public class Class142
	{
		public long long_0;

		public long long_1;

		public int int_0;

		public Class142(Class144 class144_0)
		{
			long_0 = class144_0.vmethod_13(64);
			long_1 = class144_0.vmethod_13(64);
			int_0 = class144_0.vmethod_10(16);
		}

		public override string ToString()
		{
			return string.Concat("sampleNumber=", long_0, " streamOffset=", long_1, " frameSamples=", int_0);
		}
	}
}
