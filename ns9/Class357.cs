using ns22;
using System;
using System.Collections.Generic;

namespace ns9
{
	public class Class357 : IDisposable, EmptyInterface1
	{
		private Class352[] class352_0;

		private readonly List<EmptyInterface1> list_0;

		public void Dispose()
		{
			foreach (EmptyInterface1 current in this.list_0)
			{
				current.Dispose();
			}
			for (int i = 0; i < this.class352_0.Length; i++)
			{
				this.class352_0[i].Dispose();
			}
		}
	}
}
