using System;
using System.Collections.Generic;
using ns22;

namespace ns9
{
	public class Class357 : IDisposable, EmptyInterface1
	{
		private Class352[] class352_0;

		private readonly List<EmptyInterface1> list_0;

		public void Dispose()
		{
			foreach (EmptyInterface1 current in list_0)
			{
				current.Dispose();
			}
			for (int i = 0; i < class352_0.Length; i++)
			{
				class352_0[i].Dispose();
			}
		}
	}
}
