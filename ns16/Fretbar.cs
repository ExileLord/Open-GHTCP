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
				if (this.method_5(value))
				{
					base[int_0] = value;
					if (int_0 > 0)
					{
						T t = base[int_0 - 1];
						if (t.CompareTo(value) > 0)
						{
							goto IL_54;
						}
					}
					if (int_0 >= base.Count - 1 || value.CompareTo(base[int_0 + 1]) <= 0)
					{
						return;
					}
					IL_54:
					base.Sort();
				}
			}
		}

		public Fretbar()
		{
			this.method_0();
		}

		public Fretbar(int int_0) : base(int_0)
		{
			this.method_0();
		}

		public Fretbar(IEnumerable<T> ienumerable_0) : base(ienumerable_0)
		{
			base.Sort();
			this.method_0();
		}

		private void method_0()
		{
			this.bool_0 = true;
			this.bool_1 = true;
			this.bool_2 = true;
		}

		public void method_1(T gparam_0)
		{
			if (this.method_5(gparam_0))
			{
				if (this.bool_1)
				{
					int num = this.method_3(gparam_0);
					int num2 = (num >= 0) ? num : (-num - 1);
					if (num2 >= base.Count)
					{
						base.Add(gparam_0);
						return;
					}
					base.Insert(num2, gparam_0);
					return;
				}
				else
				{
					this.bool_0 = false;
					base.Add(gparam_0);
				}
			}
		}

		public bool method_2(T gparam_0)
		{
			if (!this.bool_0)
			{
				return base.Contains(gparam_0);
			}
			return base.BinarySearch(gparam_0) >= 0;
		}

		public int method_3(T gparam_0)
		{
			int i;
			if (this.bool_0)
			{
				for (i = base.BinarySearch(gparam_0); i > 0; i--)
				{
					T t = base[i - 1];
					if (!t.Equals(gparam_0))
					{
						break;
					}
				}
			}
			else
			{
				i = base.IndexOf(gparam_0);
			}
			return i;
		}

		public override string ToString()
		{
			string text = "{";
			for (int i = 0; i < base.Count; i++)
			{
				string arg_37_0 = text;
				T t = base[i];
				text = arg_37_0 + t.ToString() + ((i != base.Count - 1) ? "; " : "}");
			}
			return text;
		}

		public override bool Equals(object obj)
		{
			Fretbar<T> @class = (Fretbar<T>)obj;
			if (@class.Count != base.Count)
			{
				return false;
			}
			for (int i = 0; i < base.Count; i++)
			{
				T t = @class[i];
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
			if (this.bool_0)
			{
				return;
			}
			base.Sort();
			this.bool_0 = true;
		}

		private bool method_5(T gparam_0)
		{
			return this.bool_2 || !this.method_2(gparam_0);
		}

		public object Clone()
		{
			return new Fretbar<T>(this)
			{
				bool_2 = this.bool_2,
				bool_0 = this.bool_0,
				bool_1 = this.bool_1
			};
		}

		private bool method_6(ref int int_0, ref int int_1, ref int int_2, T gparam_0)
		{
			this.method_4();
			while (int_0 <= int_1)
			{
				int_2 = (int_0 + int_1) / 2;
				T t = base[int_2];
				if (t.CompareTo(gparam_0) < 0)
				{
					int_0 = int_2 + 1;
				}
				else
				{
					T t2 = base[int_2];
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
			int num = 0;
			int num2 = base.Count - 1;
			int num3 = 0;
			num3 = (this.method_6(ref num, ref num2, ref num3, gparam_0) ? num3 : num2);
			if (num3 >= 0)
			{
				return num3;
			}
			return 0;
		}
	}
}
