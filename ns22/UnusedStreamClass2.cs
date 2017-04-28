using System;
using System.IO;
using ns9;

namespace ns22
{
	public class UnusedStreamClass2 : IDisposable, EmptyInterface1
	{
		private static readonly double[,] double_0 = {
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
			stream_0.Dispose();
			for (int i = 0; i < class352_0.Length; i++)
			{
				class352_0[i].Dispose();
			}
		}
	}
}
