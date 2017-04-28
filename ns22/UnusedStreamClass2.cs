using System;
using System.IO;
using ns9;

namespace ns22
{
	public class UnusedStreamClass2 : IDisposable, IEmptyInterface1
	{
		private static readonly double[,] Double0 = {
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

		private Class352[] _class3520;

		private Stream _stream0;

		public void Dispose()
		{
			_stream0.Dispose();
			for (var i = 0; i < _class3520.Length; i++)
			{
				_class3520[i].Dispose();
			}
		}
	}
}
