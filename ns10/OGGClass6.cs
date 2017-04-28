using ns2;
using ns3;

namespace ns10
{
	public class OggClass6
	{
		public float[][] Float0 = new float[0][];

		public OggClass3 OggClass3 = new OggClass3();

		public int Int0;

		public int Int1;

		public int Int2;

		public int Int3;

		public int Int4;

		public int Int5;

		public long Long0;

		public long Long1;

		public OggClass1 OggClass1;

		public int Int6;

		public int Int7;

		public int Int8;

		public int Int9;

		public OggClass6(OggClass1 oggClass1)
		{
			this.OggClass1 = oggClass1;
			if (oggClass1.Int2 != 0)
			{
				OggClass3.method_0();
			}
		}

		public void method_0(OggClass1 oggClass1)
		{
			this.OggClass1 = oggClass1;
		}

		public int method_1()
		{
			if (OggClass1 != null && OggClass1.Int2 != 0)
			{
				OggClass3.method_1();
			}
			return 0;
		}

		public int method_2(Class67 class670)
		{
			var oggClass5 = OggClass1.OggClass5;
			OggClass3.method_4(class670.Byte0, class670.Int0, class670.Int1);
			if (OggClass3.method_6(1) != 0)
			{
				return -1;
			}
			var num = OggClass3.method_6(OggClass1.Int3);
			if (num == -1)
			{
				return -1;
			}
			Int4 = num;
			Int1 = oggClass5.Class270[Int4].Int0;
			if (Int1 != 0)
			{
				Int0 = OggClass3.method_6(1);
				Int2 = OggClass3.method_6(1);
				if (Int2 == -1)
				{
					return -1;
				}
			}
			else
			{
				Int0 = 0;
				Int2 = 0;
			}
			Long0 = class670.Long0;
			Long1 = class670.Long1 - 3L;
			Int5 = class670.Int3;
			Int3 = oggClass5.Int13[Int1];
			if (Float0.Length < oggClass5.Int8)
			{
				Float0 = new float[oggClass5.Int8][];
			}
			for (var i = 0; i < oggClass5.Int8; i++)
			{
				if (Float0[i] != null && Float0[i].Length >= Int3)
				{
					for (var j = 0; j < Int3; j++)
					{
						Float0[i][j] = 0f;
					}
				}
				else
				{
					Float0[i] = new float[Int3];
				}
			}
			var num2 = oggClass5.Int21[oggClass5.Class270[Int4].Int3];
			return Class34.Class340[num2].vmethod_3(this, OggClass1.Object1[Int4]);
		}
	}
}
