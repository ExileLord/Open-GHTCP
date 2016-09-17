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
				IComparable comparable = x as IComparable;
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
				if (index >= this.arrayList_0.Count || index < 0)
				{
					throw new ArgumentOutOfRangeException("Index is less than zero or Index is greater than Count.");
				}
				return this.arrayList_0[index];
			}
			set
			{
				if (this.bool_2)
				{
					throw new InvalidOperationException("[] operator cannot be used to set a value if KeepSorted property is set to true.");
				}
				if (index < this.arrayList_0.Count && index >= 0)
				{
					if (this.method_0(value))
					{
						object obj = (index > 0) ? this.arrayList_0[index - 1] : null;
						object obj2 = (index < this.Count - 1) ? this.arrayList_0[index + 1] : null;
						if ((obj != null && this.icomparer_0.Compare(obj, value) > 0) || (obj2 != null && this.icomparer_0.Compare(value, obj2) > 0))
						{
							this.bool_1 = false;
						}
						this.arrayList_0[index] = value;
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
				return this.arrayList_0.Count;
			}
		}

		public object SyncRoot
		{
			get
			{
				return this.arrayList_0.SyncRoot;
			}
		}

		public bool IsSynchronized
		{
			get
			{
				return this.arrayList_0.IsSynchronized;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return this.arrayList_0.IsReadOnly;
			}
		}

		public bool IsFixedSize
		{
			get
			{
				return this.arrayList_0.IsFixedSize;
			}
		}

		public zzList240()
		{
			this.method_1(null, 0);
		}

		public zzList240(IComparer icomparer_1, int int_0)
		{
			this.method_1(icomparer_1, int_0);
		}

		public int Add(object value)
		{
			int result = -1;
			if (this.method_0(value))
			{
				if (this.bool_2)
				{
					int num = this.IndexOf(value);
					int num2 = (num >= 0) ? num : (-num - 1);
					if (num2 >= this.Count)
					{
						this.arrayList_0.Add(value);
					}
					else
					{
						this.arrayList_0.Insert(num2, value);
					}
					result = num2;
				}
				else
				{
					this.bool_1 = false;
					result = this.arrayList_0.Add(value);
				}
			}
			return result;
		}

		public bool Contains(object value)
		{
			if (!this.bool_1)
			{
				return this.arrayList_0.Contains(value);
			}
			return this.arrayList_0.BinarySearch(value, this.icomparer_0) >= 0;
		}

		public int IndexOf(object value)
		{
			int num;
			if (this.bool_1)
			{
				num = this.arrayList_0.BinarySearch(value, this.icomparer_0);
				while (num > 0 && this.arrayList_0[num - 1].Equals(value))
				{
					num--;
				}
			}
			else
			{
				num = this.arrayList_0.IndexOf(value);
			}
			return num;
		}

		public void Insert(int index, object value)
		{
			if (this.bool_2)
			{
				throw new InvalidOperationException("Insert method cannot be called if KeepSorted property is set to true.");
			}
			if (index < this.arrayList_0.Count && index >= 0)
			{
				if (this.method_0(value))
				{
					object obj = this.arrayList_0[index];
					object obj2 = (index > 0) ? this.arrayList_0[index - 1] : null;
					if ((obj2 != null && this.icomparer_0.Compare(obj2, value) > 0) || (obj != null && this.icomparer_0.Compare(value, obj) > 0))
					{
						this.bool_1 = false;
					}
					this.arrayList_0.Insert(index, value);
				}
				return;
			}
			throw new ArgumentOutOfRangeException("index is less than zero or index is greater than Count.");
		}

		public void Remove(object value)
		{
			this.arrayList_0.Remove(value);
		}

		public void RemoveAt(int index)
		{
			this.arrayList_0.RemoveAt(index);
		}

		public void CopyTo(Array array, int index)
		{
			this.arrayList_0.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return this.arrayList_0.GetEnumerator();
		}

		public void Clear()
		{
			this.arrayList_0.Clear();
		}

		public object Clone()
		{
			return new zzList240(this.icomparer_0, this.arrayList_0.Capacity)
			{
				arrayList_0 = (ArrayList)this.arrayList_0.Clone(),
				bool_3 = this.bool_3,
				bool_1 = this.bool_1,
				bool_2 = this.bool_2
			};
		}

		public override string ToString()
		{
			string text = "{";
			for (int i = 0; i < this.arrayList_0.Count; i++)
			{
				text = text + this.arrayList_0[i].ToString() + ((i != this.arrayList_0.Count - 1) ? "; " : "}");
			}
			return text;
		}

		public override bool Equals(object obj)
		{
			zzList240 @class = (zzList240)obj;
			if (@class.Count != this.Count)
			{
				return false;
			}
			for (int i = 0; i < this.Count; i++)
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
			return this.arrayList_0.GetHashCode();
		}

		private bool method_0(object object_0)
		{
			if (this.bool_0 && !(object_0 is IComparable))
			{
				throw new ArgumentException("The SortableArrayList is set to use the IComparable interface of objects, and the object to add does not implement the IComparable interface.");
			}
			return this.bool_3 || !this.Contains(object_0);
		}

		private void method_1(IComparer icomparer_1, int int_0)
		{
			if (icomparer_1 != null)
			{
				this.icomparer_0 = icomparer_1;
				this.bool_0 = false;
			}
			else
			{
				this.icomparer_0 = new zzList240.MyComparer();
				this.bool_0 = true;
			}
			this.arrayList_0 = ((int_0 > 0) ? new ArrayList(int_0) : new ArrayList());
			this.bool_1 = true;
			this.bool_2 = true;
			this.bool_3 = true;
		}
	}
}
