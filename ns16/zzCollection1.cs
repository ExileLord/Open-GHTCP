using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;

namespace ns16
{
	[HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
	public class zzCollection1<T> : IEnumerable, ICollection<T>, IEnumerable<T>
	{
		public struct Struct81
		{
			public int int_0;

			public int int_1;
		}

		public struct Struct82 : IEnumerator, IEnumerator<T>, IDisposable
		{
			private zzCollection1<T> class236_0;

			private int int_0;

			private readonly int int_1;

			private T gparam_0;

			public T Current
			{
				get
				{
					return gparam_0;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					method_0();
					if (int_0 <= 0)
					{
						throw new InvalidOperationException("Current is not valid");
					}
					return gparam_0;
				}
			}

			public Struct82(zzCollection1<T> class236_1)
			{
				this = default(Struct82);
				class236_0 = class236_1;
				int_1 = class236_1.int_5;
			}

			public bool MoveNext()
			{
				method_0();
				if (int_0 < 0)
				{
					return false;
				}
				while (int_0 < class236_0.int_1)
				{
					var num = int_0++;
					if (class236_0.method_4(num) != 0)
					{
						gparam_0 = class236_0.gparam_0[num];
						return true;
					}
				}
				int_0 = -1;
				return false;
			}

			void IEnumerator.Reset()
			{
				method_0();
				int_0 = 0;
			}

			public void Dispose()
			{
				class236_0 = null;
			}

			private void method_0()
			{
				if (class236_0 == null)
				{
					throw new ObjectDisposedException(null);
				}
				if (class236_0.int_5 != int_1)
				{
					throw new InvalidOperationException("HashSet have been modified while it was iterated over");
				}
			}
		}

		private static class Class237
		{
			private static readonly int[] oddPrimeSequence = {
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
					var num = (int)Math.Sqrt(int_1);
					for (var i = 3; i < num; i += 2)
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
				for (var i = (int_1 & -2) - 1; i < Int32.MaxValue; i += 2)
				{
					if (smethod_0(i))
					{
						return i;
					}
				}
				return int_1;
			}

			public static int smethod_2(int int_1)
			{
				for (var i = 0; i < oddPrimeSequence.Length; i++)
				{
					if (int_1 <= oddPrimeSequence[i])
					{
						return oddPrimeSequence[i];
					}
				}
				return smethod_1(int_1);
			}
		}

		private int[] int_0;

		private Struct81[] struct81_0;

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
				return int_3;
			}
		}

		bool ICollection<T>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public zzCollection1()
		{
			method_0(10, null);
		}

		public zzCollection1(IEqualityComparer<T> iequalityComparer_1)
		{
			method_0(10, iequalityComparer_1);
		}

		public zzCollection1(IEnumerable<T> ienumerable_0) : this(ienumerable_0, null)
		{
		}

		public zzCollection1(IEnumerable<T> ienumerable_0, IEqualityComparer<T> iequalityComparer_1)
		{
			if (ienumerable_0 == null)
			{
				throw new ArgumentNullException("collection");
			}
			var int_ = 0;
			var collection = ienumerable_0 as ICollection<T>;
			if (collection != null)
			{
				int_ = collection.Count;
			}
			method_0(int_, iequalityComparer_1);
			foreach (var current in ienumerable_0)
			{
				vmethod_0(current);
			}
		}

		private void method_0(int int_6, IEqualityComparer<T> iequalityComparer_1)
		{
			if (int_6 < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			iequalityComparer_0 = (iequalityComparer_1 ?? EqualityComparer<T>.Default);
			if (int_6 == 0)
			{
				int_6 = 10;
			}
			int_6 = (int)(int_6 / 0.9f) + 1;
			method_1(int_6);
			int_5 = 0;
		}

		private void method_1(int int_6)
		{
			int_0 = new int[int_6];
			struct81_0 = new Struct81[int_6];
			int_2 = -1;
			gparam_0 = new T[int_6];
			int_1 = 0;
			int_4 = (int)(int_0.Length * 0.9f);
			if (int_4 == 0 && int_0.Length > 0)
			{
				int_4 = 1;
			}
		}

		public void CopyTo(T[] gparam_1, int int_6)
		{
			method_2(gparam_1, int_6, int_3);
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			CopyTo(array, arrayIndex);
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
			var num = 0;
			var num2 = int_6 + int_7;
			while (num < int_1 && int_6 < num2)
			{
				if (method_4(num) != 0)
				{
					gparam_1[int_6++] = gparam_0[num];
				}
				num++;
			}
		}

		public void Clear()
		{
			int_3 = 0;
			Array.Clear(int_0, 0, int_0.Length);
			Array.Clear(gparam_0, 0, gparam_0.Length);
			Array.Clear(struct81_0, 0, struct81_0.Length);
			int_2 = -1;
			int_1 = 0;
			int_5++;
		}

		private void method_3()
		{
			var num = Class237.smethod_2(int_0.Length << 1 | 1);
			var array = new int[num];
			var array2 = new Struct81[num];
			for (var i = 0; i < int_0.Length; i++)
			{
				for (var num2 = int_0[i] - 1; num2 != -1; num2 = struct81_0[num2].int_1)
				{
					var num3 = array2[num2].int_0 = method_5(gparam_0[num2]);
					var num4 = (num3 & 2147483647) % num;
					array2[num2].int_1 = array[num4] - 1;
					array[num4] = num2 + 1;
				}
			}
			int_0 = array;
			struct81_0 = array2;
			var destinationArray = new T[num];
			Array.Copy(gparam_0, 0, destinationArray, 0, int_1);
			gparam_0 = destinationArray;
			int_4 = (int)(num * 0.9f);
		}

		public int method_4(int int_6)
		{
			return struct81_0[int_6].int_0 & -2147483648;
		}

		public int method_5(T gparam_1)
		{
			if (gparam_1 != null)
			{
				return iequalityComparer_0.GetHashCode(gparam_1) | -2147483648;
			}
			return -2147483648;
		}

		void ICollection<T>.Add(T item)
		{
			vmethod_0(item);
		}

		public bool vmethod_0(T gparam_1)
		{
			var num = method_5(gparam_1);
			var num2 = (num & 2147483647) % int_0.Length;
			if (method_6(num2, num, gparam_1))
			{
				return false;
			}
			if (++int_3 > int_4)
			{
				method_3();
				num2 = (num & 2147483647) % int_0.Length;
			}
			var num3 = int_2;
			if (num3 == -1)
			{
				num3 = int_1++;
			}
			else
			{
				int_2 = struct81_0[num3].int_1;
			}
			struct81_0[num3].int_0 = num;
			struct81_0[num3].int_1 = int_0[num2] - 1;
			int_0[num2] = num3 + 1;
			gparam_0[num3] = gparam_1;
			int_5++;
			return true;
		}

		public bool Contains(T item)
		{
			var num = method_5(item);
			var int_ = (num & 2147483647) % int_0.Length;
			return method_6(int_, num, item);
		}

		private bool method_6(int int_6, int int_7, T gparam_1)
		{
			Struct81 @struct;
			for (var num = int_0[int_6] - 1; num != -1; num = @struct.int_1)
			{
				@struct = struct81_0[num];
				if (@struct.int_0 == int_7 && ((int_7 != -2147483648 || (gparam_1 != null && gparam_0[num] != null)) ? iequalityComparer_0.Equals(gparam_1, gparam_0[num]) : (gparam_1 == null && null == gparam_0[num])))
				{
					return true;
				}
			}
			return false;
		}

		public bool Remove(T item)
		{
			var num = method_5(item);
			var num2 = (num & 2147483647) % int_0.Length;
			var num3 = int_0[num2] - 1;
			if (num3 == -1)
			{
				return false;
			}
			var num4 = -1;
			do
			{
				var @struct = struct81_0[num3];
				if (@struct.int_0 == num)
				{
					if ((num != -2147483648 || (item != null && gparam_0[num3] != null)) ? iequalityComparer_0.Equals(gparam_0[num3], item) : (item == null && null == gparam_0[num3]))
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
			int_3--;
			if (num4 == -1)
			{
				int_0[num2] = struct81_0[num3].int_1 + 1;
			}
			else
			{
				struct81_0[num4].int_1 = struct81_0[num3].int_1;
			}
			struct81_0[num3].int_1 = int_2;
			int_2 = num3;
			struct81_0[num3].int_0 = 0;
			gparam_0[num3] = default(T);
			int_5++;
			return true;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new Struct82(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Struct82(this);
		}
	}
}
