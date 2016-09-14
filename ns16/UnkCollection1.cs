using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;

namespace ns16
{
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public class UnkCollection1<T> : IEnumerable, ICollection<T>, IEnumerable<T>
	{
		public struct Struct81
		{
			public int int_0;

			public int int_1;
		}

		public struct Struct82 : IEnumerator, IEnumerator<T>, IDisposable
		{
			private UnkCollection1<T> class236_0;

			private int int_0;

			private int int_1;

			private T gparam_0;

			public T Current
			{
				get
				{
					return this.gparam_0;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					this.method_0();
					if (this.int_0 <= 0)
					{
						throw new InvalidOperationException("Current is not valid");
					}
					return this.gparam_0;
				}
			}

			public Struct82(UnkCollection1<T> class236_1)
			{
				this = default(UnkCollection1<T>.Struct82);
				this.class236_0 = class236_1;
				this.int_1 = class236_1.int_5;
			}

			public bool MoveNext()
			{
				this.method_0();
				if (this.int_0 < 0)
				{
					return false;
				}
				while (this.int_0 < this.class236_0.int_1)
				{
					int num = this.int_0++;
					if (this.class236_0.method_4(num) != 0)
					{
						this.gparam_0 = this.class236_0.gparam_0[num];
						return true;
					}
				}
				this.int_0 = -1;
				return false;
			}

			void IEnumerator.Reset()
			{
				this.method_0();
				this.int_0 = 0;
			}

			public void Dispose()
			{
				this.class236_0 = null;
			}

			private void method_0()
			{
				if (this.class236_0 == null)
				{
					throw new ObjectDisposedException(null);
				}
				if (this.class236_0.int_5 != this.int_1)
				{
					throw new InvalidOperationException("HashSet have been modified while it was iterated over");
				}
			}
		}

		private static class Class237
		{
			private static readonly int[] oddPrimeSequence = new int[]
			{
				11,
				19,
				37,
				73,
				109,
				163,
				251,
				367,
				557,
				823,
				1237,
				1861,
				2777,
				4177,
				6247,
				9371,
				14057,
				21089,
				31627,
				47431,
				71143,
				106721,
				160073,
				240101,
				360163,
				540217,
				810343,
				1215497,
				1823231,
				2734867,
				4102283,
				6153409,
				9230113,
				13845163
			};

			private static bool smethod_0(int int_1)
			{
				if ((int_1 & 1) != 0)
				{
					int num = (int)Math.Sqrt((double)int_1);
					for (int i = 3; i < num; i += 2)
					{
						if (int_1 % i == 0)
						{
							return false;
						}
					}
					return true;
				}
				return int_1 == 2;
			}

			private static int smethod_1(int int_1)
			{
				for (int i = (int_1 & -2) - 1; i < Int32.MaxValue; i += 2)
				{
					if (UnkCollection1<T>.Class237.smethod_0(i))
					{
						return i;
					}
				}
				return int_1;
			}

			public static int smethod_2(int int_1)
			{
				for (int i = 0; i < UnkCollection1<T>.Class237.oddPrimeSequence.Length; i++)
				{
					if (int_1 <= UnkCollection1<T>.Class237.oddPrimeSequence[i])
					{
						return UnkCollection1<T>.Class237.oddPrimeSequence[i];
					}
				}
				return UnkCollection1<T>.Class237.smethod_1(int_1);
			}
		}

		private int[] int_0;

		private UnkCollection1<T>.Struct81[] struct81_0;

		private T[] gparam_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private IEqualityComparer<T> iequalityComparer_0;

		private int int_5;

		public int Count
		{
			get
			{
				return this.int_3;
			}
		}

		bool ICollection<T>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public UnkCollection1()
		{
			this.method_0(10, null);
		}

		public UnkCollection1(IEqualityComparer<T> iequalityComparer_1)
		{
			this.method_0(10, iequalityComparer_1);
		}

		public UnkCollection1(IEnumerable<T> ienumerable_0) : this(ienumerable_0, null)
		{
		}

		public UnkCollection1(IEnumerable<T> ienumerable_0, IEqualityComparer<T> iequalityComparer_1)
		{
			if (ienumerable_0 == null)
			{
				throw new ArgumentNullException("collection");
			}
			int int_ = 0;
			ICollection<T> collection = ienumerable_0 as ICollection<T>;
			if (collection != null)
			{
				int_ = collection.Count;
			}
			this.method_0(int_, iequalityComparer_1);
			foreach (T current in ienumerable_0)
			{
				this.vmethod_0(current);
			}
		}

		private void method_0(int int_6, IEqualityComparer<T> iequalityComparer_1)
		{
			if (int_6 < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			this.iequalityComparer_0 = (iequalityComparer_1 ?? EqualityComparer<T>.Default);
			if (int_6 == 0)
			{
				int_6 = 10;
			}
			int_6 = (int)((float)int_6 / 0.9f) + 1;
			this.method_1(int_6);
			this.int_5 = 0;
		}

		private void method_1(int int_6)
		{
			this.int_0 = new int[int_6];
			this.struct81_0 = new UnkCollection1<T>.Struct81[int_6];
			this.int_2 = -1;
			this.gparam_0 = new T[int_6];
			this.int_1 = 0;
			this.int_4 = (int)((float)this.int_0.Length * 0.9f);
			if (this.int_4 == 0 && this.int_0.Length > 0)
			{
				this.int_4 = 1;
			}
		}

		public void CopyTo(T[] gparam_1, int int_6)
		{
			this.method_2(gparam_1, int_6, this.int_3);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			this.CopyTo(array, arrayIndex);
		}

		public void method_2(T[] gparam_1, int int_6, int int_7)
		{
			if (gparam_1 == null)
			{
				throw new ArgumentNullException("array");
			}
			if (int_6 < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (int_6 > gparam_1.Length)
			{
				throw new ArgumentException("index larger than largest valid index of array");
			}
			if (gparam_1.Length - int_6 < int_7)
			{
				throw new ArgumentException("Destination array cannot hold the requested elements!");
			}
			int num = 0;
			int num2 = int_6 + int_7;
			while (num < this.int_1 && int_6 < num2)
			{
				if (this.method_4(num) != 0)
				{
					gparam_1[int_6++] = this.gparam_0[num];
				}
				num++;
			}
		}

		public void Clear()
		{
			this.int_3 = 0;
			Array.Clear(this.int_0, 0, this.int_0.Length);
			Array.Clear(this.gparam_0, 0, this.gparam_0.Length);
			Array.Clear(this.struct81_0, 0, this.struct81_0.Length);
			this.int_2 = -1;
			this.int_1 = 0;
			this.int_5++;
		}

		private void method_3()
		{
			int num = UnkCollection1<T>.Class237.smethod_2(this.int_0.Length << 1 | 1);
			int[] array = new int[num];
			UnkCollection1<T>.Struct81[] array2 = new UnkCollection1<T>.Struct81[num];
			for (int i = 0; i < this.int_0.Length; i++)
			{
				for (int num2 = this.int_0[i] - 1; num2 != -1; num2 = this.struct81_0[num2].int_1)
				{
					int num3 = array2[num2].int_0 = this.method_5(this.gparam_0[num2]);
					int num4 = (num3 & 2147483647) % num;
					array2[num2].int_1 = array[num4] - 1;
					array[num4] = num2 + 1;
				}
			}
			this.int_0 = array;
			this.struct81_0 = array2;
			T[] destinationArray = new T[num];
			Array.Copy(this.gparam_0, 0, destinationArray, 0, this.int_1);
			this.gparam_0 = destinationArray;
			this.int_4 = (int)((float)num * 0.9f);
		}

		public int method_4(int int_6)
		{
			return this.struct81_0[int_6].int_0 & -2147483648;
		}

		public int method_5(T gparam_1)
		{
			if (gparam_1 != null)
			{
				return this.iequalityComparer_0.GetHashCode(gparam_1) | -2147483648;
			}
			return -2147483648;
		}

		void ICollection<T>.Add(T item)
		{
			this.vmethod_0(item);
		}

		public bool vmethod_0(T gparam_1)
		{
			int num = this.method_5(gparam_1);
			int num2 = (num & 2147483647) % this.int_0.Length;
			if (this.method_6(num2, num, gparam_1))
			{
				return false;
			}
			if (++this.int_3 > this.int_4)
			{
				this.method_3();
				num2 = (num & 2147483647) % this.int_0.Length;
			}
			int num3 = this.int_2;
			if (num3 == -1)
			{
				num3 = this.int_1++;
			}
			else
			{
				this.int_2 = this.struct81_0[num3].int_1;
			}
			this.struct81_0[num3].int_0 = num;
			this.struct81_0[num3].int_1 = this.int_0[num2] - 1;
			this.int_0[num2] = num3 + 1;
			this.gparam_0[num3] = gparam_1;
			this.int_5++;
			return true;
		}

		public bool Contains(T item)
		{
			int num = this.method_5(item);
			int int_ = (num & 2147483647) % this.int_0.Length;
			return this.method_6(int_, num, item);
		}

		private bool method_6(int int_6, int int_7, T gparam_1)
		{
			UnkCollection1<T>.Struct81 @struct;
			for (int num = this.int_0[int_6] - 1; num != -1; num = @struct.int_1)
			{
				@struct = this.struct81_0[num];
				if (@struct.int_0 == int_7 && ((int_7 != -2147483648 || (gparam_1 != null && this.gparam_0[num] != null)) ? this.iequalityComparer_0.Equals(gparam_1, this.gparam_0[num]) : (gparam_1 == null && null == this.gparam_0[num])))
				{
					return true;
				}
			}
			return false;
		}

		public bool Remove(T item)
		{
			int num = this.method_5(item);
			int num2 = (num & 2147483647) % this.int_0.Length;
			int num3 = this.int_0[num2] - 1;
			if (num3 == -1)
			{
				return false;
			}
			int num4 = -1;
			do
			{
				UnkCollection1<T>.Struct81 @struct = this.struct81_0[num3];
				if (@struct.int_0 == num)
				{
					if ((num != -2147483648 || (item != null && this.gparam_0[num3] != null)) ? this.iequalityComparer_0.Equals(this.gparam_0[num3], item) : (item == null && null == this.gparam_0[num3]))
					{
						break;
					}
				}
				num4 = num3;
				num3 = @struct.int_1;
			}
			while (num3 != -1);
			if (num3 == -1)
			{
				return false;
			}
			this.int_3--;
			if (num4 == -1)
			{
				this.int_0[num2] = this.struct81_0[num3].int_1 + 1;
			}
			else
			{
				this.struct81_0[num4].int_1 = this.struct81_0[num3].int_1;
			}
			this.struct81_0[num3].int_1 = this.int_2;
			this.int_2 = num3;
			this.struct81_0[num3].int_0 = 0;
			this.gparam_0[num3] = default(T);
			this.int_5++;
			return true;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new UnkCollection1<T>.Struct82(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new UnkCollection1<T>.Struct82(this);
		}
	}
}
