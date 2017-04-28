using System;
using System.Collections;
using System.Collections.Generic;

namespace GHNamespace7
{
	public class Class225 : IEnumerable, IEnumerable<Class225.Class226>
	{
		public struct Struct77 : IEnumerator, IDisposable, IEnumerator<Class226>
		{
			private Class225 _class2250;

			private readonly uint _uint0;

			private Stack<Class226> _stack0;

			private Stack<Class226> _stack1;

			public Class226 Current => _stack0.Peek();

		    object IEnumerator.Current
			{
				get
				{
					method_1();
					return Current;
				}
			}

			public Struct77(Class225 class2251)
			{
				this = default(Struct77);
				_class2250 = class2251;
				_uint0 = class2251._uint0;
			}

			public Struct77(Class225 class2251, Stack<Class226> stack2)
			{
				this = new Struct77(class2251);
				_stack1 = stack2;
			}

			public void Reset()
			{
				method_0();
				_stack0 = null;
			}

			public bool MoveNext()
			{
				method_0();
				Class226 @class;
				if (_stack0 == null)
				{
					if (_class2250._class2260 == null)
					{
						return false;
					}
					if (_stack1 != null)
					{
						_stack0 = _stack1;
						_stack1 = null;
						return _stack0.Count != 0;
					}
					_stack0 = new Stack<Class226>();
					@class = _class2250._class2260;
				}
				else
				{
					if (_stack0.Count == 0)
					{
						return false;
					}
					var class2 = _stack0.Pop();
					@class = class2.Class2261;
				}
				while (@class != null)
				{
					_stack0.Push(@class);
					@class = @class.Class2260;
				}
				return _stack0.Count != 0;
			}

			public void Dispose()
			{
				_class2250 = null;
				_stack0 = null;
			}

			private void method_0()
			{
				if (_class2250 == null)
				{
					throw new ObjectDisposedException("enumerator");
				}
				if (_uint0 != _class2250._uint0)
				{
					throw new InvalidOperationException("tree modified");
				}
			}

			public void method_1()
			{
				method_0();
				if (_stack0 == null)
				{
					throw new InvalidOperationException("state invalid before the first MoveNext()");
				}
			}
		}

		public interface INterface10<T>
		{
			int imethod_0(T gparam0, Class226 class2260);

			Class226 imethod_1(T gparam0);
		}

		public abstract class Class226
		{
			public Class226 Class2260;

			public Class226 Class2261;

			private uint _uint0;

			public bool method_0()
			{
				return (_uint0 & 1u) == 1u;
			}

			public void method_1(bool bool0)
			{
				_uint0 = (bool0 ? (_uint0 | 1u) : (_uint0 & 4294967294u));
			}

			public uint method_2()
			{
				return _uint0 >> 1;
			}

			public void method_3(uint uint1)
			{
				_uint0 = (uint1 << 1 | (_uint0 & 1u));
			}

			public uint method_4()
			{
				method_3(1u);
				if (Class2260 != null)
				{
					method_3(method_2() + Class2260.method_2());
				}
				if (Class2261 != null)
				{
					method_3(method_2() + Class2261.method_2());
				}
				return method_2();
			}

			public Class226()
			{
				_uint0 = 2u;
			}

			public abstract void vmethod_0(Class226 class2262);
		}

		private Class226 _class2260;

		private readonly object _object0;

		private uint _uint0;

		public Class226 this[int int0]
		{
			get
			{
				if (int0 >= 0 && int0 < method_4())
				{
					var class226 = _class2260;
					while (class226 != null)
					{
						var num = (int)((class226.Class2260 == null) ? 0u : class226.Class2260.method_2());
						if (int0 == num)
						{
							return class226;
						}
						if (int0 < num)
						{
							class226 = class226.Class2260;
						}
						else
						{
							int0 -= num + 1;
							class226 = class226.Class2261;
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

		private static void smethod_1(List<Class226> list0)
		{
		}

		public Class225(object object1)
		{
			_object0 = object1;
		}

		public void method_0()
		{
			_class2260 = null;
			_uint0 += 1u;
		}

		public Class226 method_1<T>(T gparam0, Class226 class2261)
		{
			if (_class2260 == null)
			{
				if (class2261 == null)
				{
					class2261 = ((INterface10<T>)_object0).imethod_1(gparam0);
				}
				_class2260 = class2261;
				_class2260.method_1(true);
				_uint0 += 1u;
				return _class2260;
			}
			var list = smethod_0();
			var int_ = method_5(gparam0, list);
			var @class = list[list.Count - 1];
			if (@class == null)
			{
				if (class2261 == null)
				{
					class2261 = ((INterface10<T>)_object0).imethod_1(gparam0);
				}
				@class = method_6(int_, class2261, list);
			}
			smethod_1(list);
			return @class;
		}

		public Class226 method_2<T>(T gparam0)
		{
			if (_class2260 == null)
			{
				return null;
			}
			var list = smethod_0();
			var num = method_5(gparam0, list);
			Class226 result = null;
			if (num == 0)
			{
				result = method_7(list);
			}
			smethod_1(list);
			return result;
		}

		public Class226 method_3<T>(T gparam0)
		{
			var @interface = (INterface10<T>)_object0;
			Class226 @class;
			int num;
			for (@class = _class2260; @class != null; @class = ((num < 0) ? @class.Class2260 : @class.Class2261))
			{
				num = @interface.imethod_0(gparam0, @class);
				if (num == 0)
				{
					break;
				}
			}
			return @class;
		}

		public int method_4()
		{
			if (_class2260 != null)
			{
				return (int)_class2260.method_2();
			}
			return 0;
		}

		private int method_5<T>(T gparam0, List<Class226> list0)
		{
			var @interface = (INterface10<T>)_object0;
			var num = 0;
			var class226 = _class2260;
			if (list0 != null)
			{
				list0.Add(_class2260);
			}
			while (class226 != null)
			{
				num = @interface.imethod_0(gparam0, class226);
				if (num == 0)
				{
					return num;
				}
				Class226 class2262;
				if (num < 0)
				{
					class2262 = class226.Class2261;
					class226 = class226.Class2260;
				}
				else
				{
					class2262 = class226.Class2260;
					class226 = class226.Class2261;
				}
				if (list0 != null)
				{
					list0.Add(class2262);
					list0.Add(class226);
				}
			}
			return num;
		}

		private Class226 method_6(int int0, Class226 class2261, List<Class226> list0)
		{
			list0[list0.Count - 1] = class2261;
			var @class = list0[list0.Count - 3];
			if (int0 < 0)
			{
				@class.Class2260 = class2261;
			}
			else
			{
				@class.Class2261 = class2261;
			}
			for (var i = 0; i < list0.Count - 2; i += 2)
			{
				var expr_3D = list0[i];
				expr_3D.method_3(expr_3D.method_2() + 1u);
			}
			if (!@class.method_0())
			{
				method_8(list0);
			}
			if (!_class2260.method_0())
			{
				throw new SystemException("Internal error: root is not black");
			}
			_uint0 += 1u;
			return class2261;
		}

		private Class226 method_7(List<Class226> list0)
		{
			var num = list0.Count - 1;
			var @class = list0[num];
			if (@class.Class2260 != null)
			{
				var class2 = smethod_2(@class.Class2260, @class.Class2261, list0);
				@class.vmethod_0(class2);
				if (class2.Class2260 != null)
				{
					var class3 = class2.Class2260;
					list0.Add(null);
					list0.Add(class3);
					class2.vmethod_0(class3);
				}
			}
			else if (@class.Class2261 != null)
			{
				var class226 = @class.Class2261;
				list0.Add(null);
				list0.Add(class226);
				@class.vmethod_0(class226);
			}
			num = list0.Count - 1;
			@class = list0[num];
			if (@class.method_2() != 1u)
			{
				throw new SystemException("Internal Error: red-black violation somewhere");
			}
			list0[num] = null;
			method_13((num == 0) ? null : list0[num - 2], @class, 0u, null);
			for (var i = 0; i < list0.Count - 2; i += 2)
			{
				var exprD2 = list0[i];
				exprD2.method_3(exprD2.method_2() - 1u);
			}
			if (@class.method_0())
			{
				@class.method_1(false);
				if (num != 0)
				{
					method_9(list0);
				}
			}
			if (_class2260 != null && !_class2260.method_0())
			{
				throw new SystemException("Internal Error: root is not black");
			}
			_uint0 += 1u;
			return @class;
		}

		private void method_8(List<Class226> list0)
		{
			var num = list0.Count - 1;
			while (list0[num - 3] != null && !list0[num - 3].method_0())
			{
				var arg340 = list0[num - 2];
				list0[num - 3].method_1(true);
				arg340.method_1(true);
				num -= 4;
				if (num == 0)
				{
					return;
				}
				list0[num].method_1(false);
				if (list0[num - 2].method_0())
				{
					return;
				}
			}
			method_10(num, list0);
		}

		private void method_9(List<Class226> list0)
		{
			var num = list0.Count - 1;
			do
			{
				var @class = list0[num - 1];
				if (!@class.method_0())
				{
					num = method_12(num, list0);
					@class = list0[num - 1];
				}
				if ((@class.Class2260 != null && !@class.Class2260.method_0()) || (@class.Class2261 != null && !@class.Class2261.method_0()))
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
			while (list0[num].method_0());
			list0[num].method_1(true);
			return;
			IL_7C:
			method_11(num, list0);
		}

		private void method_10(int int0, List<Class226> list0)
		{
			var @class = list0[int0];
			var class2 = list0[int0 - 2];
			var class3 = list0[int0 - 4];
			var uint_ = class3.method_2();
			var flag = class2 == class3.Class2260;
			var flag2 = @class == class2.Class2260;
			Class226 class4;
			if (flag && flag2)
			{
				class3.Class2260 = class2.Class2261;
				class2.Class2261 = class3;
				class4 = class2;
			}
			else if (flag && !flag2)
			{
				class3.Class2260 = @class.Class2261;
				@class.Class2261 = class3;
				class2.Class2261 = @class.Class2260;
				@class.Class2260 = class2;
				class4 = @class;
			}
			else if (!flag && flag2)
			{
				class3.Class2261 = @class.Class2260;
				@class.Class2260 = class3;
				class2.Class2260 = @class.Class2261;
				@class.Class2261 = class2;
				class4 = @class;
			}
			else
			{
				class3.Class2261 = class2.Class2260;
				class2.Class2260 = class3;
				class4 = class2;
			}
			class3.method_4();
			class3.method_1(false);
			if (class4 != class2)
			{
				class2.method_4();
			}
			class4.method_1(true);
			method_13((int0 == 4) ? null : list0[int0 - 6], class3, uint_, class4);
		}

		private void method_11(int int0, List<Class226> list0)
		{
			var @class = list0[int0 - 1];
			var class2 = list0[int0 - 2];
			var uint_ = class2.method_2();
			var bool_ = class2.method_0();
			Class226 class3;
			if (class2.Class2261 == @class)
			{
				if (@class.Class2261 != null && !@class.Class2261.method_0())
				{
					class2.Class2261 = @class.Class2260;
					@class.Class2260 = class2;
					@class.Class2261.method_1(true);
					class3 = @class;
				}
				else
				{
					var class4 = @class.Class2260;
					class2.Class2261 = class4.Class2260;
					class4.Class2260 = class2;
					@class.Class2260 = class4.Class2261;
					class4.Class2261 = @class;
					class3 = class4;
				}
			}
			else if (@class.Class2260 != null && !@class.Class2260.method_0())
			{
				class2.Class2260 = @class.Class2261;
				@class.Class2261 = class2;
				@class.Class2260.method_1(true);
				class3 = @class;
			}
			else
			{
				var class226 = @class.Class2261;
				class2.Class2260 = class226.Class2261;
				class226.Class2261 = class2;
				@class.Class2261 = class226.Class2260;
				class226.Class2260 = @class;
				class3 = class226;
			}
			class2.method_4();
			class2.method_1(true);
			if (class3 != @class)
			{
				@class.method_4();
			}
			class3.method_1(bool_);
			method_13((int0 == 2) ? null : list0[int0 - 4], class2, uint_, class3);
		}

		private int method_12(int int0, List<Class226> list0)
		{
			var value = list0[int0];
			var @class = list0[int0 - 1];
			var class2 = list0[int0 - 2];
			var uint_ = class2.method_2();
			bool flag;
			if (class2.Class2261 == @class)
			{
				class2.Class2261 = @class.Class2260;
				@class.Class2260 = class2;
				flag = true;
			}
			else
			{
				class2.Class2260 = @class.Class2261;
				@class.Class2261 = class2;
				flag = false;
			}
			class2.method_4();
			class2.method_1(false);
			@class.method_1(true);
			method_13((int0 == 2) ? null : list0[int0 - 4], class2, uint_, @class);
			if (int0 + 1 == list0.Count)
			{
				list0.Add(null);
				list0.Add(null);
			}
			list0[int0 - 2] = @class;
			list0[int0 - 1] = (flag ? @class.Class2261 : @class.Class2260);
			list0[int0] = class2;
			list0[int0 + 1] = (flag ? class2.Class2261 : class2.Class2260);
			list0[int0 + 2] = value;
			return int0 + 2;
		}

		private void method_13(Class226 class2261, Class226 class2262, uint uint1, Class226 class2263)
		{
			if (class2263 != null && class2263.method_4() != uint1)
			{
				throw new SystemException("Internal error: rotation");
			}
			if (class2262 == _class2260)
			{
				_class2260 = class2263;
				return;
			}
			if (class2262 == class2261.Class2260)
			{
				class2261.Class2260 = class2263;
				return;
			}
			if (class2262 == class2261.Class2261)
			{
				class2261.Class2261 = class2263;
				return;
			}
			throw new SystemException("Internal error: path error");
		}

		private static Class226 smethod_2(Class226 class2261, Class226 class2262, List<Class226> list0)
		{
			while (true)
			{
				list0.Add(class2262);
				list0.Add(class2261);
				if (class2261.Class2261 == null)
				{
					break;
				}
				class2262 = class2261.Class2260;
				class2261 = class2261.Class2261;
			}
			return class2261;
		}

		public Struct77 method_14()
		{
			return new Struct77(this);
		}

		public Struct77 method_15<T>(T gparam0)
		{
			var stack = new Stack<Class226>();
			var @interface = (INterface10<T>)_object0;
			int num;
			for (var @class = _class2260; @class != null; @class = ((num < 0) ? @class.Class2260 : @class.Class2261))
			{
				num = @interface.imethod_0(gparam0, @class);
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
