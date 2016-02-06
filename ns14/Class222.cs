using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ns14
{
	public class Class222<T> : IEnumerable, ICollection<T>, IEnumerable<T>, ICollection
	{
		public struct Struct76 : IEnumerator, IEnumerator<T>, IDisposable
		{
			private Class225.Struct77 struct77_0;

			private IComparer<T> icomparer_0;

			private T gparam_0;

			private T gparam_1;

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
					this.struct77_0.method_1();
					return ((Class222<T>.Class227)this.struct77_0.Current).gparam_0;
				}
			}

			public Struct76(Class222<T> class222_0)
			{
				this = default(Class222<T>.Struct76);
				this.struct77_0 = class222_0.class225_0.method_14();
			}

			public Struct76(Class222<T> class222_0, T gparam_2, T gparam_3)
			{
				this = default(Class222<T>.Struct76);
				this.struct77_0 = class222_0.class225_0.method_15<T>(gparam_2);
				this.icomparer_0 = class222_0.method_1();
				this.gparam_1 = gparam_3;
			}

			public bool MoveNext()
			{
				if (!this.struct77_0.MoveNext())
				{
					return false;
				}
				this.gparam_0 = ((Class222<T>.Class227)this.struct77_0.Current).gparam_0;
				return this.icomparer_0 == null || this.icomparer_0.Compare(this.gparam_1, this.gparam_0) >= 0;
			}

			public void Dispose()
			{
				this.struct77_0.Dispose();
			}

			void IEnumerator.Reset()
			{
				this.struct77_0.Reset();
			}
		}

		private class Class227 : Class225.Class226
		{
			public T gparam_0;

			public Class227(T gparam_1)
			{
				this.gparam_0 = gparam_1;
			}

			public override void vmethod_0(Class225.Class226 class226_2)
			{
				Class222<T>.Class227 @class = (Class222<T>.Class227)class226_2;
				T t = this.gparam_0;
				this.gparam_0 = @class.gparam_0;
				@class.gparam_0 = t;
			}
		}

		private class Class223 : Class225.Interface10<T>
		{
			private static Class222<T>.Class223 class223_0 = new Class222<T>.Class223(Comparer<T>.Default);

			public IComparer<T> icomparer_0;

			public int imethod_0(T gparam_0, Class225.Class226 class226_0)
			{
				return this.icomparer_0.Compare(gparam_0, ((Class222<T>.Class227)class226_0).gparam_0);
			}

			public Class225.Class226 imethod_1(T gparam_0)
			{
				return new Class222<T>.Class227(gparam_0);
			}

			private Class223(IComparer<T> icomparer_1)
			{
				this.icomparer_0 = icomparer_1;
			}

			public static Class222<T>.Class223 smethod_0(IComparer<T> icomparer_1)
			{
				if (icomparer_1 != null)
				{
					if (icomparer_1 != Comparer<T>.Default)
					{
						return new Class222<T>.Class223(icomparer_1);
					}
				}
				return Class222<T>.Class223.class223_0;
			}
		}

		private object object_0;

		private Class225 class225_0;

		private Class222<T>.Class223 class223_0;

		public int Count
		{
			get
			{
				return this.vmethod_0();
			}
		}

		bool ICollection<T>.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		bool ICollection.IsSynchronized
		{
			get
			{
				return false;
			}
		}

		object ICollection.SyncRoot
		{
			get
			{
				if (this.object_0 == null)
				{
					Interlocked.CompareExchange(ref this.object_0, new object(), null);
				}
				return this.object_0;
			}
		}

		public Class222() : this(Comparer<T>.Default)
		{
		}

		public Class222(IEnumerable<T> ienumerable_0) : this(ienumerable_0, Comparer<T>.Default)
		{
		}

		public Class222(IEnumerable<T> ienumerable_0, IComparer<T> icomparer_0) : this(icomparer_0)
		{
			if (ienumerable_0 == null)
			{
				throw new ArgumentNullException("collection");
			}
			foreach (T current in ienumerable_0)
			{
				this.vmethod_1(current);
			}
		}

		public Class222(IComparer<T> icomparer_0)
		{
			this.class223_0 = Class222<T>.Class223.smethod_0(icomparer_0);
			this.class225_0 = new Class225(this.class223_0);
		}

		public virtual int vmethod_0()
		{
			return this.class225_0.method_4();
		}

		private T method_0(int int_0)
		{
			return ((Class222<T>.Class227)this.class225_0[int_0]).gparam_0;
		}

		public virtual void Clear()
		{
			this.class225_0.method_0();
		}

		void ICollection<T>.Add(T item)
		{
			this.vmethod_1(item);
		}

		public bool vmethod_1(T gparam_0)
		{
			return this.vmethod_2(gparam_0);
		}

		public virtual bool vmethod_2(T gparam_0)
		{
			Class222<T>.Class227 @class = new Class222<T>.Class227(gparam_0);
			return this.class225_0.method_1<T>(gparam_0, @class) == @class;
		}

		public virtual bool Contains(T item)
		{
			return this.class225_0.method_3<T>(item) != null;
		}

		public bool Remove(T item)
		{
			return this.vmethod_3(item);
		}

		public virtual bool vmethod_3(T gparam_0)
		{
			return this.class225_0.method_2<T>(gparam_0) != null;
		}

		public IComparer<T> method_1()
		{
			return this.class223_0.icomparer_0;
		}

		public void method_2(T[] gparam_0, int int_0, int int_1)
		{
			if (gparam_0 == null)
			{
				throw new ArgumentNullException("array");
			}
			if (int_0 < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (int_0 > gparam_0.Length)
			{
				throw new ArgumentException("index larger than largest valid index of array");
			}
			if (gparam_0.Length - int_0 < int_1)
			{
				throw new ArgumentException("destination array cannot hold the requested elements");
			}
			using (Class225.Struct77 @struct = this.class225_0.method_14())
			{
				while (@struct.MoveNext())
				{
					Class222<T>.Class227 @class = (Class222<T>.Class227)@struct.Current;
					if (int_1-- == 0)
					{
						break;
					}
					gparam_0[int_0++] = @class.gparam_0;
				}
			}
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			this.method_2(array, arrayIndex, this.Count);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (this.Count == 0)
			{
				return;
			}
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index >= 0 && array.Length > index)
			{
				if (array.Length - index < this.Count)
				{
					throw new ArgumentException();
				}
				using (Class225.Struct77 @struct = this.class225_0.method_14())
				{
					while (@struct.MoveNext())
					{
						Class222<T>.Class227 @class = (Class222<T>.Class227)@struct.Current;
						array.SetValue(@class.gparam_0, index++);
					}
					return;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		public Class222<T>.Struct76 method_3()
		{
			return this.vmethod_4();
		}

		public virtual Class222<T>.Struct76 vmethod_4()
		{
			return new Class222<T>.Struct76(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return this.method_3();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.method_3();
		}
	}
}
