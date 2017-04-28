using System;
using System.Collections.Generic;

namespace GHNamespace9
{
	public class Fretbar<T> : List<T>, ICloneable where T : IComparable<T>
	{
		private bool _bool0;

		private bool _bool1;

		private bool _bool2;

		public new T this[int int0]
		{
			get
			{
				return base[int0];
			}
			set
			{
				if (method_5(value))
				{
					base[int0] = value;
					if (int0 > 0)
					{
						var t = base[int0 - 1];
						if (t.CompareTo(value) > 0)
						{
							goto IL_54;
						}
					}
					if (int0 >= Count - 1 || value.CompareTo(base[int0 + 1]) <= 0)
					{
						return;
					}
					IL_54:
					Sort();
				}
			}
		}

		public Fretbar()
		{
			method_0();
		}

		public Fretbar(int int0) : base(int0)
		{
			method_0();
		}

		public Fretbar(IEnumerable<T> ienumerable0) : base(ienumerable0)
		{
			Sort();
			method_0();
		}

		private void method_0()
		{
			_bool0 = true;
			_bool1 = true;
			_bool2 = true;
		}

		public void method_1(T gparam0)
		{
			if (method_5(gparam0))
			{
				if (_bool1)
				{
					var num = method_3(gparam0);
					var num2 = (num >= 0) ? num : (-num - 1);
					if (num2 >= Count)
					{
						Add(gparam0);
						return;
					}
					Insert(num2, gparam0);
				}
				else
				{
					_bool0 = false;
					Add(gparam0);
				}
			}
		}

		public bool method_2(T gparam0)
		{
			if (!_bool0)
			{
				return Contains(gparam0);
			}
			return BinarySearch(gparam0) >= 0;
		}

		public int method_3(T gparam0)
		{
			int i;
			if (_bool0)
			{
				for (i = BinarySearch(gparam0); i > 0; i--)
				{
					var t = base[i - 1];
					if (!t.Equals(gparam0))
					{
						break;
					}
				}
			}
			else
			{
				i = IndexOf(gparam0);
			}
			return i;
		}

		public override string ToString()
		{
			var text = "{";
			for (var i = 0; i < Count; i++)
			{
				var arg370 = text;
				var t = base[i];
				text = arg370 + t + ((i != Count - 1) ? "; " : "}");
			}
			return text;
		}

		public override bool Equals(object obj)
		{
			var @class = (Fretbar<T>)obj;
			if (@class.Count != Count)
			{
				return false;
			}
			for (var i = 0; i < Count; i++)
			{
				var t = @class[i];
				if (!t.Equals(this[i]))
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public void method_4()
		{
			if (_bool0)
			{
				return;
			}
			Sort();
			_bool0 = true;
		}

		private bool method_5(T gparam0)
		{
			return _bool2 || !method_2(gparam0);
		}

		public object Clone()
		{
			return new Fretbar<T>(this)
			{
				_bool2 = _bool2,
				_bool0 = _bool0,
				_bool1 = _bool1
			};
		}

		private bool method_6(ref int int0, ref int int1, ref int int2, T gparam0)
		{
			method_4();
			while (int0 <= int1)
			{
				int2 = (int0 + int1) / 2;
				var t = base[int2];
				if (t.CompareTo(gparam0) < 0)
				{
					int0 = int2 + 1;
				}
				else
				{
					var t2 = base[int2];
					if (t2.CompareTo(gparam0) <= 0)
					{
						return true;
					}
					int1 = int2 - 1;
				}
			}
			return false;
		}

		public int method_7(T gparam0)
		{
			var num = 0;
			var num2 = Count - 1;
			var num3 = 0;
			num3 = (method_6(ref num, ref num2, ref num3, gparam0) ? num3 : num2);
			if (num3 >= 0)
			{
				return num3;
			}
			return 0;
		}
	}
}
