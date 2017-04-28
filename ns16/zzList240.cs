using System;
using System.Collections;

namespace ns16
{
	public class zzList240 : IEnumerable, ICloneable, ICollection, IList
	{
		private class MyComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				var comparable = x as IComparable;
				return comparable.CompareTo(y);
			}
		}

		private ArrayList arrayList_0;

		private IComparer icomparer_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		public object this[int index]
		{
			get
			{
				if (index >= arrayList_0.Count || index < 0)
				{
					throw new ArgumentOutOfRangeException("Index is less than zero or Index is greater than Count.");
				}
				return arrayList_0[index];
			}
			set
			{
				if (bool_2)
				{
					throw new InvalidOperationException("[] operator cannot be used to set a value if KeepSorted property is set to true.");
				}
				if (index < arrayList_0.Count && index >= 0)
				{
					if (method_0(value))
					{
						var obj = (index > 0) ? arrayList_0[index - 1] : null;
						var obj2 = (index < Count - 1) ? arrayList_0[index + 1] : null;
						if ((obj != null && icomparer_0.Compare(obj, value) > 0) || (obj2 != null && icomparer_0.Compare(value, obj2) > 0))
						{
							bool_1 = false;
						}
						arrayList_0[index] = value;
					}
					return;
				}
				throw new ArgumentOutOfRangeException("Index is less than zero or Index is greater than Count.");
			}
		}

		public int Count
		{
			get
			{
				return arrayList_0.Count;
			}
		}

		public object SyncRoot
		{
			get
			{
				return arrayList_0.SyncRoot;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return arrayList_0.IsSynchronized;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return arrayList_0.IsReadOnly;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				return arrayList_0.IsFixedSize;
			}
		}

		public zzList240()
		{
			method_1(null, 0);
		}

		public zzList240(IComparer icomparer_1, int int_0)
		{
			method_1(icomparer_1, int_0);
		}

		public int Add(object value)
		{
			var result = -1;
			if (method_0(value))
			{
				if (bool_2)
				{
					var num = IndexOf(value);
					var num2 = (num >= 0) ? num : (-num - 1);
					if (num2 >= Count)
					{
						arrayList_0.Add(value);
					}
					else
					{
						arrayList_0.Insert(num2, value);
					}
					result = num2;
				}
				else
				{
					bool_1 = false;
					result = arrayList_0.Add(value);
				}
			}
			return result;
		}

		public bool Contains(object value)
		{
			if (!bool_1)
			{
				return arrayList_0.Contains(value);
			}
			return arrayList_0.BinarySearch(value, icomparer_0) >= 0;
		}

		public int IndexOf(object value)
		{
			int num;
			if (bool_1)
			{
				num = arrayList_0.BinarySearch(value, icomparer_0);
				while (num > 0 && arrayList_0[num - 1].Equals(value))
				{
					num--;
				}
			}
			else
			{
				num = arrayList_0.IndexOf(value);
			}
			return num;
		}

		public void Insert(int index, object value)
		{
			if (bool_2)
			{
				throw new InvalidOperationException("Insert method cannot be called if KeepSorted property is set to true.");
			}
			if (index < arrayList_0.Count && index >= 0)
			{
				if (method_0(value))
				{
					var obj = arrayList_0[index];
					var obj2 = (index > 0) ? arrayList_0[index - 1] : null;
					if ((obj2 != null && icomparer_0.Compare(obj2, value) > 0) || (obj != null && icomparer_0.Compare(value, obj) > 0))
					{
						bool_1 = false;
					}
					arrayList_0.Insert(index, value);
				}
				return;
			}
			throw new ArgumentOutOfRangeException("index is less than zero or index is greater than Count.");
		}

		public void Remove(object value)
		{
			arrayList_0.Remove(value);
		}

		public void RemoveAt(int index)
		{
			arrayList_0.RemoveAt(index);
		}

		public void CopyTo(Array array, int index)
		{
			arrayList_0.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return arrayList_0.GetEnumerator();
		}

		public void Clear()
		{
			arrayList_0.Clear();
		}

		public object Clone()
		{
			return new zzList240(icomparer_0, arrayList_0.Capacity)
			{
				arrayList_0 = (ArrayList)arrayList_0.Clone(),
				bool_3 = bool_3,
				bool_1 = bool_1,
				bool_2 = bool_2
			};
		}

		public override string ToString()
		{
			var text = "{";
			for (var i = 0; i < arrayList_0.Count; i++)
			{
				text = text + arrayList_0[i] + ((i != arrayList_0.Count - 1) ? "; " : "}");
			}
			return text;
		}

		public override bool Equals(object obj)
		{
			var @class = (zzList240)obj;
			if (@class.Count != Count)
			{
				return false;
			}
			for (var i = 0; i < Count; i++)
			{
				if (!@class[i].Equals(this[i]))
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return arrayList_0.GetHashCode();
		}

		private bool method_0(object object_0)
		{
			if (bool_0 && !(object_0 is IComparable))
			{
				throw new ArgumentException("The SortableArrayList is set to use the IComparable interface of objects, and the object to add does not implement the IComparable interface.");
			}
			return bool_3 || !Contains(object_0);
		}

		private void method_1(IComparer icomparer_1, int int_0)
		{
			if (icomparer_1 != null)
			{
				icomparer_0 = icomparer_1;
				bool_0 = false;
			}
			else
			{
				icomparer_0 = new MyComparer();
				bool_0 = true;
			}
			arrayList_0 = ((int_0 > 0) ? new ArrayList(int_0) : new ArrayList());
			bool_1 = true;
			bool_2 = true;
			bool_3 = true;
		}
	}
}
