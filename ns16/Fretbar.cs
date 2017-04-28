using System;
using System.Collections.Generic;

namespace ns16
{
	public class Fretbar<T> : List<T>, ICloneable where T : IComparable<T>
	{
		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		public new T this[int int_0]
		{
			get
			{
				return base[int_0];
			}
			set
			{
				if (method_5(value))
				{
					base[int_0] = value;
					if (int_0 > 0)
					{
						var t = base[int_0 - 1];
						if (t.CompareTo(value) > 0)
						{
							goto IL_54;
						}
					}
					if (int_0 >= Count - 1 || value.CompareTo(base[int_0 + 1]) <= 0)
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

		public Fretbar(int int_0) : base(int_0)
		{
			method_0();
		}

		public Fretbar(IEnumerable<T> ienumerable_0) : base(ienumerable_0)
		{
			Sort();
			method_0();
		}

		private void method_0()
		{
			bool_0 = true;
			bool_1 = true;
			bool_2 = true;
		}

		public void method_1(T gparam_0)
		{
			if (method_5(gparam_0))
			{
				if (bool_1)
				{
					var num = method_3(gparam_0);
					var num2 = (num >= 0) ? num : (-num - 1);
					if (num2 >= Count)
					{
						Add(gparam_0);
						return;
					}
					Insert(num2, gparam_0);
				}
				else
				{
					bool_0 = false;
					Add(gparam_0);
				}
			}
		}

		public bool method_2(T gparam_0)
		{
			if (!bool_0)
			{
				return Contains(gparam_0);
			}
			return BinarySearch(gparam_0) >= 0;
		}

		public int method_3(T gparam_0)
		{
			int i;
			if (bool_0)
			{
				for (i = BinarySearch(gparam_0); i > 0; i--)
				{
					var t = base[i - 1];
					if (!t.Equals(gparam_0))
					{
						break;
					}
				}
			}
			else
			{
				i = IndexOf(gparam_0);
			}
			return i;
		}

		public override string ToString()
		{
			var text = "{";
			for (var i = 0; i < Count; i++)
			{
				var arg_37_0 = text;
				var t = base[i];
				text = arg_37_0 + t + ((i != Count - 1) ? "; " : "}");
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
			if (bool_0)
			{
				return;
			}
			Sort();
			bool_0 = true;
		}

		private bool method_5(T gparam_0)
		{
			return bool_2 || !method_2(gparam_0);
		}

		public object Clone()
		{
			return new Fretbar<T>(this)
			{
				bool_2 = bool_2,
				bool_0 = bool_0,
				bool_1 = bool_1
			};
		}

		private bool method_6(ref int int_0, ref int int_1, ref int int_2, T gparam_0)
		{
			method_4();
			while (int_0 <= int_1)
			{
				int_2 = (int_0 + int_1) / 2;
				var t = base[int_2];
				if (t.CompareTo(gparam_0) < 0)
				{
					int_0 = int_2 + 1;
				}
				else
				{
					var t2 = base[int_2];
					if (t2.CompareTo(gparam_0) <= 0)
					{
						return true;
					}
					int_1 = int_2 - 1;
				}
			}
			return false;
		}

		public int method_7(T gparam_0)
		{
			var num = 0;
			var num2 = Count - 1;
			var num3 = 0;
			num3 = (method_6(ref num, ref num2, ref num3, gparam_0) ? num3 : num2);
			if (num3 >= 0)
			{
				return num3;
			}
			return 0;
		}
	}
}
