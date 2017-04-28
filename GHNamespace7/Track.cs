using System;
using System.Collections.Generic;

namespace GHNamespace7
{
    public class Track<TKey, TValue> : SortedList<TKey, TValue> where TKey : IComparable<TKey>
    {
        public new TValue this[TKey gparam0]
        {
            get
            {
                if (!ContainsKey(gparam0))
                {
                    return base[Keys[method_1(gparam0)]];
                }
                return base[gparam0];
            }
            set
            {
                if (ContainsKey(gparam0))
                {
                    base[gparam0] = value;
                    return;
                }
                Add(gparam0, value);
            }
        }

        private bool method_0(ref int int0, ref int int1, ref int int2, TKey offset)
        {
            while (int0 <= int1)
            {
                int2 = (int0 + int1) / 2;
                var tKey = Keys[int2];
                if (tKey.CompareTo(offset) < 0)
                {
                    int0 = int2 + 1;
                }
                else
                {
                    var tKey2 = Keys[int2];
                    if (tKey2.CompareTo(offset) <= 0)
                    {
                        return true;
                    }
                    int1 = int2 - 1;
                }
            }
            return false;
        }

        //Always takes a number
        //Not the problem
        public int method_1(TKey offset)
        {
            var num = 0;
            var num2 = Count - 1;
            var num3 = 0;
            if (method_0(ref num, ref num2, ref num3, offset))
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
            var num = 0;
            var num2 = Count - 1;
            var num3 = 0;
            num3 = (method_0(ref num, ref num2, ref num3, offset) ? num3 : num);
            if (num3 < Count)
            {
                return num3;
            }
            return Count - 1;
        }

        public int method_3(TKey gparam0, TKey gparam1)
        {
            var num = 0;
            var num2 = Count - 1;
            var num3 = 0;
            var num4 = method_0(ref num, ref num2, ref num3, gparam0) ? num3 : num;
            num = num4;
            num2 = Count - 1;
            num3 = 0;
            var num5 = method_0(ref num, ref num2, ref num3, gparam1) ? (num3 + 1) : num;
            return num5 - num4;
        }

        public bool method_4(TKey gparam0)
        {
            return ContainsKey(gparam0);
        }
    }
}