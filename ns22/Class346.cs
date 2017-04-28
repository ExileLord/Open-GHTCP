using System;

namespace ns22
{
	public class Class346<T> : IDisposable
	{
		public T[] gparam_0;

		public int int_0;

		public int int_1;

		public Class346() : this(65536) 
		{
		}

		public Class346(int int_2)
		{
			gparam_0 = new T[int_2];
		}

		public void Dispose()
		{
			int_0 = 0;
			int_1 = 0;
			gparam_0 = new T[0];
		}
	}
}
