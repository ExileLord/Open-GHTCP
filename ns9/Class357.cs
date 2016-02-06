using ns22;
using System;
using System.Collections.Generic;

namespace ns9
{
	public class Class357 : IDisposable, Interface13
	{
		private Class352[] class352_0;

		private readonly List<Interface13> list_0;

		public void Dispose()
		{
			foreach (Interface13 current in this.list_0)
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
