using System;

namespace ns22
{
	public class Class346<T> : IDisposable
	{
		public T[] gparam_0;

		public int int_0;

		public int int_1;

		public Class346() : this(65536) //I think this is the size of GH3's hash map?..
		{
		}

		public Class346(int int_2)
		{
			this.gparam_0 = new T[int_2];
		}

		public void Dispose()
		{
			this.int_0 = 0;
			this.int_1 = 0;
			this.gparam_0 = new T[0];
		}
	}
}
