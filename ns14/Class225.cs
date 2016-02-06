using System;
using System.Collections;
using System.Collections.Generic;

namespace ns14
{
	public class Class225 : IEnumerable, IEnumerable<Class225.Class226>
	{
		public struct Struct77 : IEnumerator, IDisposable, IEnumerator<Class225.Class226>
		{
			private Class225 class225_0;

			private uint uint_0;

			private Stack<Class225.Class226> stack_0;

			private Stack<Class225.Class226> stack_1;

			public Class225.Class226 Current
			{
				get
				{
					return this.stack_0.Peek();
				}
			}

			object IEnumerator.Current
			{
				get
				{
					this.method_1();
					return this.Current;
				}
			}

			public Struct77(Class225 class225_1)
			{
				this = default(Class225.Struct77);
				this.class225_0 = class225_1;
				this.uint_0 = class225_1.uint_0;
			}

			public Struct77(Class225 class225_1, Stack<Class225.Class226> stack_2)
			{
				this = new Class225.Struct77(class225_1);
				this.stack_1 = stack_2;
			}

			public void Reset()
			{
				this.method_0();
				this.stack_0 = null;
			}

			public bool MoveNext()
			{
				this.method_0();
				Class225.Class226 @class;
				if (this.stack_0 == null)
				{
					if (this.class225_0.class226_0 == null)
					{
						return false;
					}
					if (this.stack_1 != null)
					{
						this.stack_0 = this.stack_1;
						this.stack_1 = null;
						return this.stack_0.Count != 0;
					}
					this.stack_0 = new Stack<Class225.Class226>();
					@class = this.class225_0.class226_0;
				}
				else
				{
					if (this.stack_0.Count == 0)
					{
						return false;
					}
					Class225.Class226 class2 = this.stack_0.Pop();
					@class = class2.class226_1;
				}
				while (@class != null)
				{
					this.stack_0.Push(@class);
					@class = @class.class226_0;
				}
				return this.stack_0.Count != 0;
			}

			public void Dispose()
			{
				this.class225_0 = null;
				this.stack_0 = null;
			}

			private void method_0()
			{
				if (this.class225_0 == null)
				{
					throw new ObjectDisposedException("enumerator");
				}
				if (this.uint_0 != this.class225_0.uint_0)
				{
					throw new InvalidOperationException("tree modified");
				}
			}

			public void method_1()
			{
				this.method_0();
				if (this.stack_0 == null)
				{
					throw new InvalidOperationException("state invalid before the first MoveNext()");
				}
			}
		}

		public interface Interface10<T>
		{
			int imethod_0(T gparam_0, Class225.Class226 class226_0);

			Class225.Class226 imethod_1(T gparam_0);
		}

		public abstract class Class226
		{
			public Class225.Class226 class226_0;

			public Class225.Class226 class226_1;

			private uint uint_0;

			public bool method_0()
			{
				return (this.uint_0 & 1u) == 1u;
			}

			public void method_1(bool bool_0)
			{
				this.uint_0 = (bool_0 ? (this.uint_0 | 1u) : (this.uint_0 & 4294967294u));
			}

			public uint method_2()
			{
				return this.uint_0 >> 1;
			}

			public void method_3(uint uint_1)
			{
				this.uint_0 = (uint_1 << 1 | (this.uint_0 & 1u));
			}

			public uint method_4()
			{
				this.method_3(1u);
				if (this.class226_0 != null)
				{
					this.method_3(this.method_2() + this.class226_0.method_2());
				}
				if (this.class226_1 != null)
				{
					this.method_3(this.method_2() + this.class226_1.method_2());
				}
				return this.method_2();
			}

			public Class226()
			{
				this.uint_0 = 2u;
			}

			public abstract void vmethod_0(Class225.Class226 class226_2);
		}

		private Class225.Class226 class226_0;

		private object object_0;

		private uint uint_0;

		public Class225.Class226 this[int int_0]
		{
			get
			{
				if (int_0 >= 0 && int_0 < this.method_4())
				{
					Class225.Class226 class226_ = this.class226_0;
					while (class226_ != null)
					{
						int num = (int)((class226_.class226_0 == null) ? 0u : class226_.class226_0.method_2());
						if (int_0 == num)
						{
							return class226_;
						}
						if (int_0 < num)
						{
							class226_ = class226_.class226_0;
						}
						else
						{
							int_0 -= num + 1;
							class226_ = class226_.class226_1;
						}
					}
					throw new SystemException("Internal Error: index calculation");
				}
				throw new IndexOutOfRangeException("index");
			}
		}

		private static List<Class225.Class226> smethod_0()
		{
			return new List<Class225.Class226>();
		}

		private static void smethod_1(List<Class225.Class226> list_0)
		{
		}

		public Class225(object object_1)
		{
			this.object_0 = object_1;
		}

		public void method_0()
		{
			this.class226_0 = null;
			this.uint_0 += 1u;
		}

		public Class225.Class226 method_1<T>(T gparam_0, Class225.Class226 class226_1)
		{
			if (this.class226_0 == null)
			{
				if (class226_1 == null)
				{
					class226_1 = ((Class225.Interface10<T>)this.object_0).imethod_1(gparam_0);
				}
				this.class226_0 = class226_1;
				this.class226_0.method_1(true);
				this.uint_0 += 1u;
				return this.class226_0;
			}
			List<Class225.Class226> list = Class225.smethod_0();
			int int_ = this.method_5<T>(gparam_0, list);
			Class225.Class226 @class = list[list.Count - 1];
			if (@class == null)
			{
				if (class226_1 == null)
				{
					class226_1 = ((Class225.Interface10<T>)this.object_0).imethod_1(gparam_0);
				}
				@class = this.method_6(int_, class226_1, list);
			}
			Class225.smethod_1(list);
			return @class;
		}

		public Class225.Class226 method_2<T>(T gparam_0)
		{
			if (this.class226_0 == null)
			{
				return null;
			}
			List<Class225.Class226> list_ = Class225.smethod_0();
			int num = this.method_5<T>(gparam_0, list_);
			Class225.Class226 result = null;
			if (num == 0)
			{
				result = this.method_7(list_);
			}
			Class225.smethod_1(list_);
			return result;
		}

		public Class225.Class226 method_3<T>(T gparam_0)
		{
			Class225.Interface10<T> @interface = (Class225.Interface10<T>)this.object_0;
			Class225.Class226 @class;
			int num;
			for (@class = this.class226_0; @class != null; @class = ((num < 0) ? @class.class226_0 : @class.class226_1))
			{
				num = @interface.imethod_0(gparam_0, @class);
				if (num == 0)
				{
					break;
				}
			}
			return @class;
		}

		public int method_4()
		{
			if (this.class226_0 != null)
			{
				return (int)this.class226_0.method_2();
			}
			return 0;
		}

		private int method_5<T>(T gparam_0, List<Class225.Class226> list_0)
		{
			Class225.Interface10<T> @interface = (Class225.Interface10<T>)this.object_0;
			int num = 0;
			Class225.Class226 class226_ = this.class226_0;
			if (list_0 != null)
			{
				list_0.Add(this.class226_0);
			}
			while (class226_ != null)
			{
				num = @interface.imethod_0(gparam_0, class226_);
				if (num == 0)
				{
					return num;
				}
				Class225.Class226 class226_2;
				if (num < 0)
				{
					class226_2 = class226_.class226_1;
					class226_ = class226_.class226_0;
				}
				else
				{
					class226_2 = class226_.class226_0;
					class226_ = class226_.class226_1;
				}
				if (list_0 != null)
				{
					list_0.Add(class226_2);
					list_0.Add(class226_);
				}
			}
			return num;
		}

		private Class225.Class226 method_6(int int_0, Class225.Class226 class226_1, List<Class225.Class226> list_0)
		{
			list_0[list_0.Count - 1] = class226_1;
			Class225.Class226 @class = list_0[list_0.Count - 3];
			if (int_0 < 0)
			{
				@class.class226_0 = class226_1;
			}
			else
			{
				@class.class226_1 = class226_1;
			}
			for (int i = 0; i < list_0.Count - 2; i += 2)
			{
				Class225.Class226 expr_3D = list_0[i];
				expr_3D.method_3(expr_3D.method_2() + 1u);
			}
			if (!@class.method_0())
			{
				this.method_8(list_0);
			}
			if (!this.class226_0.method_0())
			{
				throw new SystemException("Internal error: root is not black");
			}
			this.uint_0 += 1u;
			return class226_1;
		}

		private Class225.Class226 method_7(List<Class225.Class226> list_0)
		{
			int num = list_0.Count - 1;
			Class225.Class226 @class = list_0[num];
			if (@class.class226_0 != null)
			{
				Class225.Class226 class2 = Class225.smethod_2(@class.class226_0, @class.class226_1, list_0);
				@class.vmethod_0(class2);
				if (class2.class226_0 != null)
				{
					Class225.Class226 class3 = class2.class226_0;
					list_0.Add(null);
					list_0.Add(class3);
					class2.vmethod_0(class3);
				}
			}
			else if (@class.class226_1 != null)
			{
				Class225.Class226 class226_ = @class.class226_1;
				list_0.Add(null);
				list_0.Add(class226_);
				@class.vmethod_0(class226_);
			}
			num = list_0.Count - 1;
			@class = list_0[num];
			if (@class.method_2() != 1u)
			{
				throw new SystemException("Internal Error: red-black violation somewhere");
			}
			list_0[num] = null;
			this.method_13((num == 0) ? null : list_0[num - 2], @class, 0u, null);
			for (int i = 0; i < list_0.Count - 2; i += 2)
			{
				Class225.Class226 expr_D2 = list_0[i];
				expr_D2.method_3(expr_D2.method_2() - 1u);
			}
			if (@class.method_0())
			{
				@class.method_1(false);
				if (num != 0)
				{
					this.method_9(list_0);
				}
			}
			if (this.class226_0 != null && !this.class226_0.method_0())
			{
				throw new SystemException("Internal Error: root is not black");
			}
			this.uint_0 += 1u;
			return @class;
		}

		private void method_8(List<Class225.Class226> list_0)
		{
			int num = list_0.Count - 1;
			while (list_0[num - 3] != null && !list_0[num - 3].method_0())
			{
				Class225.Class226 arg_34_0 = list_0[num - 2];
				list_0[num - 3].method_1(true);
				arg_34_0.method_1(true);
				num -= 4;
				if (num == 0)
				{
					return;
				}
				list_0[num].method_1(false);
				if (list_0[num - 2].method_0())
				{
					return;
				}
			}
			this.method_10(num, list_0);
		}

		private void method_9(List<Class225.Class226> list_0)
		{
			int num = list_0.Count - 1;
			do
			{
				Class225.Class226 @class = list_0[num - 1];
				if (!@class.method_0())
				{
					num = this.method_12(num, list_0);
					@class = list_0[num - 1];
				}
				if ((@class.class226_0 != null && !@class.class226_0.method_0()) || (@class.class226_1 != null && !@class.class226_1.method_0()))
				{
					goto IL_7C;
				}
				@class.method_1(false);
				num -= 2;
				if (num == 0)
				{
					return;
				}
			}
			while (list_0[num].method_0());
			list_0[num].method_1(true);
			return;
			IL_7C:
			this.method_11(num, list_0);
		}

		private void method_10(int int_0, List<Class225.Class226> list_0)
		{
			Class225.Class226 @class = list_0[int_0];
			Class225.Class226 class2 = list_0[int_0 - 2];
			Class225.Class226 class3 = list_0[int_0 - 4];
			uint uint_ = class3.method_2();
			bool flag = class2 == class3.class226_0;
			bool flag2 = @class == class2.class226_0;
			Class225.Class226 class4;
			if (flag && flag2)
			{
				class3.class226_0 = class2.class226_1;
				class2.class226_1 = class3;
				class4 = class2;
			}
			else if (flag && !flag2)
			{
				class3.class226_0 = @class.class226_1;
				@class.class226_1 = class3;
				class2.class226_1 = @class.class226_0;
				@class.class226_0 = class2;
				class4 = @class;
			}
			else if (!flag && flag2)
			{
				class3.class226_1 = @class.class226_0;
				@class.class226_0 = class3;
				class2.class226_0 = @class.class226_1;
				@class.class226_1 = class2;
				class4 = @class;
			}
			else
			{
				class3.class226_1 = class2.class226_0;
				class2.class226_0 = class3;
				class4 = class2;
			}
			class3.method_4();
			class3.method_1(false);
			if (class4 != class2)
			{
				class2.method_4();
			}
			class4.method_1(true);
			this.method_13((int_0 == 4) ? null : list_0[int_0 - 6], class3, uint_, class4);
		}

		private void method_11(int int_0, List<Class225.Class226> list_0)
		{
			Class225.Class226 @class = list_0[int_0 - 1];
			Class225.Class226 class2 = list_0[int_0 - 2];
			uint uint_ = class2.method_2();
			bool bool_ = class2.method_0();
			Class225.Class226 class3;
			if (class2.class226_1 == @class)
			{
				if (@class.class226_1 != null && !@class.class226_1.method_0())
				{
					class2.class226_1 = @class.class226_0;
					@class.class226_0 = class2;
					@class.class226_1.method_1(true);
					class3 = @class;
				}
				else
				{
					Class225.Class226 class4 = @class.class226_0;
					class2.class226_1 = class4.class226_0;
					class4.class226_0 = class2;
					@class.class226_0 = class4.class226_1;
					class4.class226_1 = @class;
					class3 = class4;
				}
			}
			else if (@class.class226_0 != null && !@class.class226_0.method_0())
			{
				class2.class226_0 = @class.class226_1;
				@class.class226_1 = class2;
				@class.class226_0.method_1(true);
				class3 = @class;
			}
			else
			{
				Class225.Class226 class226_ = @class.class226_1;
				class2.class226_0 = class226_.class226_1;
				class226_.class226_1 = class2;
				@class.class226_1 = class226_.class226_0;
				class226_.class226_0 = @class;
				class3 = class226_;
			}
			class2.method_4();
			class2.method_1(true);
			if (class3 != @class)
			{
				@class.method_4();
			}
			class3.method_1(bool_);
			this.method_13((int_0 == 2) ? null : list_0[int_0 - 4], class2, uint_, class3);
		}

		private int method_12(int int_0, List<Class225.Class226> list_0)
		{
			Class225.Class226 value = list_0[int_0];
			Class225.Class226 @class = list_0[int_0 - 1];
			Class225.Class226 class2 = list_0[int_0 - 2];
			uint uint_ = class2.method_2();
			bool flag;
			if (class2.class226_1 == @class)
			{
				class2.class226_1 = @class.class226_0;
				@class.class226_0 = class2;
				flag = true;
			}
			else
			{
				class2.class226_0 = @class.class226_1;
				@class.class226_1 = class2;
				flag = false;
			}
			class2.method_4();
			class2.method_1(false);
			@class.method_1(true);
			this.method_13((int_0 == 2) ? null : list_0[int_0 - 4], class2, uint_, @class);
			if (int_0 + 1 == list_0.Count)
			{
				list_0.Add(null);
				list_0.Add(null);
			}
			list_0[int_0 - 2] = @class;
			list_0[int_0 - 1] = (flag ? @class.class226_1 : @class.class226_0);
			list_0[int_0] = class2;
			list_0[int_0 + 1] = (flag ? class2.class226_1 : class2.class226_0);
			list_0[int_0 + 2] = value;
			return int_0 + 2;
		}

		private void method_13(Class225.Class226 class226_1, Class225.Class226 class226_2, uint uint_1, Class225.Class226 class226_3)
		{
			if (class226_3 != null && class226_3.method_4() != uint_1)
			{
				throw new SystemException("Internal error: rotation");
			}
			if (class226_2 == this.class226_0)
			{
				this.class226_0 = class226_3;
				return;
			}
			if (class226_2 == class226_1.class226_0)
			{
				class226_1.class226_0 = class226_3;
				return;
			}
			if (class226_2 == class226_1.class226_1)
			{
				class226_1.class226_1 = class226_3;
				return;
			}
			throw new SystemException("Internal error: path error");
		}

		private static Class225.Class226 smethod_2(Class225.Class226 class226_1, Class225.Class226 class226_2, List<Class225.Class226> list_0)
		{
			while (true)
			{
				list_0.Add(class226_2);
				list_0.Add(class226_1);
				if (class226_1.class226_1 == null)
				{
					break;
				}
				class226_2 = class226_1.class226_0;
				class226_1 = class226_1.class226_1;
			}
			return class226_1;
		}

		public Class225.Struct77 method_14()
		{
			return new Class225.Struct77(this);
		}

		public Class225.Struct77 method_15<T>(T gparam_0)
		{
			Stack<Class225.Class226> stack = new Stack<Class225.Class226>();
			Class225.Interface10<T> @interface = (Class225.Interface10<T>)this.object_0;
			int num;
			for (Class225.Class226 @class = this.class226_0; @class != null; @class = ((num < 0) ? @class.class226_0 : @class.class226_1))
			{
				num = @interface.imethod_0(gparam_0, @class);
				if (num <= 0)
				{
					stack.Push(@class);
				}
				if (num == 0)
				{
					break;
				}
			}
			return new Class225.Struct77(this, stack);
		}

		IEnumerator<Class225.Class226> IEnumerable<Class225.Class226>.GetEnumerator()
		{
			return this.method_14();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.method_14();
		}
	}
}
