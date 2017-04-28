using System;
using System.Collections;
using System.Collections.Generic;

namespace ns14
{
	public class Class225 : IEnumerable, IEnumerable<Class225.Class226>
	{
		public struct Struct77 : IEnumerator, IDisposable, IEnumerator<Class226>
		{
			private Class225 class225_0;

			private uint uint_0;

			private Stack<Class226> stack_0;

			private Stack<Class226> stack_1;

			public Class226 Current
			{
				get
				{
					return stack_0.Peek();
				}
			}

			object IEnumerator.Current
			{
				get
				{
					method_1();
					return Current;
				}
			}

			public Struct77(Class225 class225_1)
			{
				this = default(Struct77);
				class225_0 = class225_1;
				uint_0 = class225_1.uint_0;
			}

			public Struct77(Class225 class225_1, Stack<Class226> stack_2)
			{
				this = new Struct77(class225_1);
				stack_1 = stack_2;
			}

			public void Reset()
			{
				method_0();
				stack_0 = null;
			}

			public bool MoveNext()
			{
				method_0();
				Class226 @class;
				if (stack_0 == null)
				{
					if (class225_0.class226_0 == null)
					{
						return false;
					}
					if (stack_1 != null)
					{
						stack_0 = stack_1;
						stack_1 = null;
						return stack_0.Count != 0;
					}
					stack_0 = new Stack<Class226>();
					@class = class225_0.class226_0;
				}
				else
				{
					if (stack_0.Count == 0)
					{
						return false;
					}
					var class2 = stack_0.Pop();
					@class = class2.class226_1;
				}
				while (@class != null)
				{
					stack_0.Push(@class);
					@class = @class.class226_0;
				}
				return stack_0.Count != 0;
			}

			public void Dispose()
			{
				class225_0 = null;
				stack_0 = null;
			}

			private void method_0()
			{
				if (class225_0 == null)
				{
					throw new ObjectDisposedException("enumerator");
				}
				if (uint_0 != class225_0.uint_0)
				{
					throw new InvalidOperationException("tree modified");
				}
			}

			public void method_1()
			{
				method_0();
				if (stack_0 == null)
				{
					throw new InvalidOperationException("state invalid before the first MoveNext()");
				}
			}
		}

		public interface Interface10<T>
		{
			int imethod_0(T gparam_0, Class226 class226_0);

			Class226 imethod_1(T gparam_0);
		}

		public abstract class Class226
		{
			public Class226 class226_0;

			public Class226 class226_1;

			private uint uint_0;

			public bool method_0()
			{
				return (uint_0 & 1u) == 1u;
			}

			public void method_1(bool bool_0)
			{
				uint_0 = (bool_0 ? (uint_0 | 1u) : (uint_0 & 4294967294u));
			}

			public uint method_2()
			{
				return uint_0 >> 1;
			}

			public void method_3(uint uint_1)
			{
				uint_0 = (uint_1 << 1 | (uint_0 & 1u));
			}

			public uint method_4()
			{
				method_3(1u);
				if (class226_0 != null)
				{
					method_3(method_2() + class226_0.method_2());
				}
				if (class226_1 != null)
				{
					method_3(method_2() + class226_1.method_2());
				}
				return method_2();
			}

			public Class226()
			{
				uint_0 = 2u;
			}

			public abstract void vmethod_0(Class226 class226_2);
		}

		private Class226 class226_0;

		private object object_0;

		private uint uint_0;

		public Class226 this[int int_0]
		{
			get
			{
				if (int_0 >= 0 && int_0 < method_4())
				{
					var class226_ = class226_0;
					while (class226_ != null)
					{
						var num = (int)((class226_.class226_0 == null) ? 0u : class226_.class226_0.method_2());
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

		private static List<Class226> smethod_0()
		{
			return new List<Class226>();
		}

		private static void smethod_1(List<Class226> list_0)
		{
		}

		public Class225(object object_1)
		{
			object_0 = object_1;
		}

		public void method_0()
		{
			class226_0 = null;
			uint_0 += 1u;
		}

		public Class226 method_1<T>(T gparam_0, Class226 class226_1)
		{
			if (class226_0 == null)
			{
				if (class226_1 == null)
				{
					class226_1 = ((Interface10<T>)object_0).imethod_1(gparam_0);
				}
				class226_0 = class226_1;
				class226_0.method_1(true);
				uint_0 += 1u;
				return class226_0;
			}
			var list = smethod_0();
			var int_ = method_5(gparam_0, list);
			var @class = list[list.Count - 1];
			if (@class == null)
			{
				if (class226_1 == null)
				{
					class226_1 = ((Interface10<T>)object_0).imethod_1(gparam_0);
				}
				@class = method_6(int_, class226_1, list);
			}
			smethod_1(list);
			return @class;
		}

		public Class226 method_2<T>(T gparam_0)
		{
			if (class226_0 == null)
			{
				return null;
			}
			var list_ = smethod_0();
			var num = method_5(gparam_0, list_);
			Class226 result = null;
			if (num == 0)
			{
				result = method_7(list_);
			}
			smethod_1(list_);
			return result;
		}

		public Class226 method_3<T>(T gparam_0)
		{
			var @interface = (Interface10<T>)object_0;
			Class226 @class;
			int num;
			for (@class = class226_0; @class != null; @class = ((num < 0) ? @class.class226_0 : @class.class226_1))
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
			if (class226_0 != null)
			{
				return (int)class226_0.method_2();
			}
			return 0;
		}

		private int method_5<T>(T gparam_0, List<Class226> list_0)
		{
			var @interface = (Interface10<T>)object_0;
			var num = 0;
			var class226_ = class226_0;
			if (list_0 != null)
			{
				list_0.Add(class226_0);
			}
			while (class226_ != null)
			{
				num = @interface.imethod_0(gparam_0, class226_);
				if (num == 0)
				{
					return num;
				}
				Class226 class226_2;
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

		private Class226 method_6(int int_0, Class226 class226_1, List<Class226> list_0)
		{
			list_0[list_0.Count - 1] = class226_1;
			var @class = list_0[list_0.Count - 3];
			if (int_0 < 0)
			{
				@class.class226_0 = class226_1;
			}
			else
			{
				@class.class226_1 = class226_1;
			}
			for (var i = 0; i < list_0.Count - 2; i += 2)
			{
				var expr_3D = list_0[i];
				expr_3D.method_3(expr_3D.method_2() + 1u);
			}
			if (!@class.method_0())
			{
				method_8(list_0);
			}
			if (!class226_0.method_0())
			{
				throw new SystemException("Internal error: root is not black");
			}
			uint_0 += 1u;
			return class226_1;
		}

		private Class226 method_7(List<Class226> list_0)
		{
			var num = list_0.Count - 1;
			var @class = list_0[num];
			if (@class.class226_0 != null)
			{
				var class2 = smethod_2(@class.class226_0, @class.class226_1, list_0);
				@class.vmethod_0(class2);
				if (class2.class226_0 != null)
				{
					var class3 = class2.class226_0;
					list_0.Add(null);
					list_0.Add(class3);
					class2.vmethod_0(class3);
				}
			}
			else if (@class.class226_1 != null)
			{
				var class226_ = @class.class226_1;
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
			method_13((num == 0) ? null : list_0[num - 2], @class, 0u, null);
			for (var i = 0; i < list_0.Count - 2; i += 2)
			{
				var expr_D2 = list_0[i];
				expr_D2.method_3(expr_D2.method_2() - 1u);
			}
			if (@class.method_0())
			{
				@class.method_1(false);
				if (num != 0)
				{
					method_9(list_0);
				}
			}
			if (class226_0 != null && !class226_0.method_0())
			{
				throw new SystemException("Internal Error: root is not black");
			}
			uint_0 += 1u;
			return @class;
		}

		private void method_8(List<Class226> list_0)
		{
			var num = list_0.Count - 1;
			while (list_0[num - 3] != null && !list_0[num - 3].method_0())
			{
				var arg_34_0 = list_0[num - 2];
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
			method_10(num, list_0);
		}

		private void method_9(List<Class226> list_0)
		{
			var num = list_0.Count - 1;
			do
			{
				var @class = list_0[num - 1];
				if (!@class.method_0())
				{
					num = method_12(num, list_0);
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
			method_11(num, list_0);
		}

		private void method_10(int int_0, List<Class226> list_0)
		{
			var @class = list_0[int_0];
			var class2 = list_0[int_0 - 2];
			var class3 = list_0[int_0 - 4];
			var uint_ = class3.method_2();
			var flag = class2 == class3.class226_0;
			var flag2 = @class == class2.class226_0;
			Class226 class4;
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
			method_13((int_0 == 4) ? null : list_0[int_0 - 6], class3, uint_, class4);
		}

		private void method_11(int int_0, List<Class226> list_0)
		{
			var @class = list_0[int_0 - 1];
			var class2 = list_0[int_0 - 2];
			var uint_ = class2.method_2();
			var bool_ = class2.method_0();
			Class226 class3;
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
					var class4 = @class.class226_0;
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
				var class226_ = @class.class226_1;
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
			method_13((int_0 == 2) ? null : list_0[int_0 - 4], class2, uint_, class3);
		}

		private int method_12(int int_0, List<Class226> list_0)
		{
			var value = list_0[int_0];
			var @class = list_0[int_0 - 1];
			var class2 = list_0[int_0 - 2];
			var uint_ = class2.method_2();
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
			method_13((int_0 == 2) ? null : list_0[int_0 - 4], class2, uint_, @class);
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

		private void method_13(Class226 class226_1, Class226 class226_2, uint uint_1, Class226 class226_3)
		{
			if (class226_3 != null && class226_3.method_4() != uint_1)
			{
				throw new SystemException("Internal error: rotation");
			}
			if (class226_2 == class226_0)
			{
				class226_0 = class226_3;
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

		private static Class226 smethod_2(Class226 class226_1, Class226 class226_2, List<Class226> list_0)
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

		public Struct77 method_14()
		{
			return new Struct77(this);
		}

		public Struct77 method_15<T>(T gparam_0)
		{
			var stack = new Stack<Class226>();
			var @interface = (Interface10<T>)object_0;
			int num;
			for (var @class = class226_0; @class != null; @class = ((num < 0) ? @class.class226_0 : @class.class226_1))
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
			return new Struct77(this, stack);
		}

		IEnumerator<Class226> IEnumerable<Class226>.GetEnumerator()
		{
			return method_14();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return method_14();
		}
	}
}
