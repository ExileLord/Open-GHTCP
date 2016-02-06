using ns9;
using System;
using System.IO;

namespace ns22
{
	public class Class344 : IDisposable, Interface13
	{
		private static readonly double[,] double_0 = new double[,]
		{
			{
				0.0,
				0.0
			},
			{
				0.9375,
				0.0
			},
			{
				1.796875,
				-0.8125
			},
			{
				1.53125,
				-0.859375
			},
			{
				1.90625,
				-0.9375
			}
		};

		private Class352[] class352_0;

		private Stream stream_0;

		public void Dispose()
		{
			this.stream_0.Dispose();
			for (int i = 0; i < this.class352_0.Length; i++)
			{
				this.class352_0[i].Dispose();
			}
		}
	}
}
