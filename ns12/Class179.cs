using System;
using System.Collections;
using System.IO;
using ns13;
using ns14;

namespace ns12
{
	public class Class179 : IEnumerable, IDisposable
	{
		private enum Enum28
		{
			const_0,
			const_1,
			const_2
		}

		private class Class180 : IComparer
		{
			public int Compare(object x, object y)
			{
				Class181 @class = x as Class181;
				Class181 class2 = y as Class181;
				int num;
				if (@class == null)
				{
					if (class2 == null)
					{
						num = 0;
					}
					else
					{
						num = -1;
					}
				}
				else if (class2 == null)
				{
					num = 1;
				}
				else
				{
					int num2 = (@class.method_1() == Enum28.const_0 || @class.method_1() == Enum28.const_1) ? 0 : 1;
					int num3 = (class2.method_1() == Enum28.const_0 || class2.method_1() == Enum28.const_1) ? 0 : 1;
					num = num2 - num3;
					if (num == 0)
					{
						long num4 = @class.method_0().method_6() - class2.method_0().method_6();
						if (num4 < 0L)
						{
							num = -1;
						}
						else if (num4 == 0L)
						{
							num = 0;
						}
						else
						{
							num = 1;
						}
					}
				}
				return num;
			}
		}

		private class Class181
		{
			private Class193 class193_0;

			private Enum28 enum28_0;

			public Class193 method_0()
			{
				return class193_0;
			}

			public Enum28 method_1()
			{
				return enum28_0;
			}
		}

		private class Class182 : IEnumerator
		{
			private Class193[] class193_0;

			private int int_0 = -1;

			public object Current
			{
				get
				{
					return class193_0[int_0];
				}
			}

			public Class182(Class193[] class193_1)
			{
				class193_0 = class193_1;
			}

			public void Reset()
			{
				int_0 = -1;
			}

			public bool MoveNext()
			{
				return ++int_0 < class193_0.Length;
			}
		}

		private bool bool_0;

		private Stream stream_0;

		private bool bool_1;

		private Class193[] class193_0;

		private bool bool_2;

		private Enum30 enum30_0 = Enum30.const_2;

		private int int_0 = 4096;

		private Interface9 interface9_0 = new Class212();

		private string string_0 = string.Empty;

		public Class193 this[int int_1]
		{
			get
			{
				return (Class193)class193_0[int_1].Clone();
			}
		}

		public Class179()
		{
			class193_0 = new Class193[0];
			bool_2 = true;
		}

		~Class179()
		{
			vmethod_0(false);
		}

		public void method_0()
		{
			method_2(true);
			GC.SuppressFinalize(this);
		}

		public bool method_1()
		{
			return bool_1;
		}

		public IEnumerator GetEnumerator()
		{
			if (class193_0 == null)
			{
				throw new InvalidOperationException("ZipFile has closed");
			}
			return new Class182(class193_0);
		}

		void IDisposable.Dispose()
		{
			method_0();
		}

		private void method_2(bool bool_3)
		{
			if (!bool_0)
			{
				bool_0 = true;
				class193_0 = null;
				if (method_1() && stream_0 != null)
				{
					lock (stream_0)
					{
						stream_0.Close();
					}
				}
			}
		}

		public virtual void vmethod_0(bool bool_3)
		{
			method_2(bool_3);
		}
	}
}
