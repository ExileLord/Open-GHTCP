namespace ns2
{
	public class Class31
	{
		public int Int0;

		public int[] Int1 = new int[31];

		public int[] Int2 = new int[16];

		public int[] Int3 = new int[16];

		public int[] Int4 = new int[16];

		public int[][] Int5 = new int[16][];

		public int Int6;

		public int[] Int7 = new int[65];

		public Class31()
		{
			for (var i = 0; i < Int5.Length; i++)
			{
				Int5[i] = new int[8];
			}
		}

		public void method_0()
		{
			Int1 = null;
			Int2 = null;
			Int3 = null;
			Int4 = null;
			Int5 = null;
			Int7 = null;
		}
	}
}
