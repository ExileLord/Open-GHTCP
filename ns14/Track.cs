using System;
using System.Collections.Generic;

namespace ns14
{
	public class Track<TKey, TValue> : SortedList<TKey, TValue> where TKey : IComparable<TKey>
	{
		public new TValue this[TKey gparam_0]
		{
			get
			{
                if (!base.ContainsKey(gparam_0))
				{
					return base[base.Keys[this.method_1(gparam_0)]];
				}
				return base[gparam_0];
			}
			set
			{
				if (base.ContainsKey(gparam_0))
				{
					base[gparam_0] = value;
					return;
				}
				base.Add(gparam_0, value);
			}
		}

        private bool method_0(ref int int_0, ref int int_1, ref int int_2, TKey offset)
		{
            while (int_0 <= int_1)
			{
				int_2 = (int_0 + int_1) / 2;
                TKey tKey = base.Keys[int_2];
                if (tKey.CompareTo(offset) < 0)
				{
                    int_0 = int_2 + 1;
                }
				else
				{
                    TKey tKey2 = base.Keys[int_2];
                    if (tKey2.CompareTo(offset) <= 0)
					{
                        return true;
					}
					int_1 = int_2 - 1;
				}
			}
            return false;
		}

        //Always takes a number
        //Not the problem
		public int method_1(TKey offset)
		{
            int num = 0;
			int num2 = base.Count - 1;
			int num3 = 0;
            if(this.method_0(ref num, ref num2, ref num3, offset))
            {
            }
            else
            {
                num3 = num2;
            }
            //num3 = (this.method_0(ref num, ref num2, ref num3, offset) ? num3 : num2);
            if (num3 >= 0)
			{
                return num3;
			}
            return 0;
		}

		public int method_2(TKey offset)
		{
			int num = 0;
			int num2 = base.Count - 1;
			int num3 = 0;
			num3 = (this.method_0(ref num, ref num2, ref num3, offset) ? num3 : num);
			if (num3 < base.Count)
			{
				return num3;
			}
			return base.Count - 1;
		}

		public int method_3(TKey gparam_0, TKey gparam_1)
		{
			int num = 0;
			int num2 = base.Count - 1;
			int num3 = 0;
			int num4 = this.method_0(ref num, ref num2, ref num3, gparam_0) ? num3 : num;
			num = num4;
			num2 = base.Count - 1;
			num3 = 0;
			int num5 = this.method_0(ref num, ref num2, ref num3, gparam_1) ? (num3 + 1) : num;
			return num5 - num4;
		}

		public bool method_4(TKey gparam_0)
		{
			return base.ContainsKey(gparam_0);
		}
	}
}
