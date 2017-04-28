using System;
using System.Collections;
using System.Collections.Generic;

namespace GHNamespace2
{
	public class Class13 : IEnumerable<float>, IEnumerable
	{
		public enum Enum0
		{
			Const0 = 1,
			Const1,
			Const2,
			Const3 = -1
		}

		public class Class14 : IEnumerator<float>, IEnumerator, IDisposable
		{
			private Class13 _class130;

			private int _int0;

			private int _int1;

			public float Current => _class130.Float0[_int0];

		    object IEnumerator.Current => Current;

		    public Class14(Class13 class131)
			{
				_class130 = class131;
				Reset();
			}

			public void Dispose()
			{
				_class130 = null;
			}

			public bool MoveNext()
			{
				return _int0++ < _int1;
			}

			public void Reset()
			{
				_int0 = _class130._int1 - 1;
				_int1 = _class130._int1 + _class130._int2;
			}
		}

		public float[] Float0;

		public int Int0;

		private int _int1;

		private int _int2;

		public bool Bool0 = true;

		private List<Struct9> _list0;

		private bool _bool1;

		private int _int3 = -1;

		private float[] _float1;

		private float[] _float2;

		private bool _bool2;

		private static readonly Enum0 Enum00 = Enum0.Const0;

		public float this[int int4]
		{
			get => Float0[_int1 + int4];
		    set => Float0[_int1 + int4] = value;
		}

		public int method_0()
		{
			return _int1;
		}

		public void method_1(int int4)
		{
			if (int4 < 0 || int4 >= Float0.Length)
			{
				throw new IndexOutOfRangeException("Channel: Offset is out of range -> " + int4 + ".");
			}
			_int1 = int4;
		}

		public int method_2()
		{
			return _int2;
		}

		public void method_3(int int4)
		{
			if (int4 <= 0 || _int1 + int4 > Float0.Length)
			{
				throw new IndexOutOfRangeException("Channel: Length is out of range -> " + int4 + ".");
			}
			_int2 = int4;
		}

		public Class13(int int4, float[] float3) : this(int4, float3, 0, float3.Length)
		{
		}

		public Class13(int int4, float[] float3, int int5, int int6)
		{
			Int0 = int4;
			Float0 = float3;
			method_1(int5);
			method_3(int6);
			method_4();
		}

		public virtual float vmethod_0(int int4)
		{
			if (!_bool1)
			{
				return 1f;
			}
			if (_bool2)
			{
				_float1 = new float[_list0.Count];
				_float2 = new float[_list0.Count];
				for (var i = 0; i < _list0.Count; i++)
				{
					_float1[i] = _list0[i].Float0;
					_float2[i] = _list0[i].Float1;
				}
				_bool2 = false;
			}
			var num = Class15.smethod_3(_float1, _float2, (int4 - (float)method_0()) / method_2());
			switch (Enum00)
			{
			case Enum0.Const3:
				return (float)Math.Sqrt(num);
			case Enum0.Const1:
				return num * num;
			case Enum0.Const2:
				return num * num * num;
			}
			return num;
		}

		public virtual float vmethod_1(int int4, float float3, float float4)
		{
			var num = vmethod_0(int4);
			return float4 * num + float3 * (1f - num);
		}

		private void method_4()
		{
			if (_list0 == null)
			{
				_list0 = new List<Struct9>();
				vmethod_2();
			}
		}

		public virtual void vmethod_2()
		{
			_list0.Clear();
			_list0.Add(new Struct9(0f, 1f));
			_list0.Add(new Struct9(1f, 1f));
			_bool2 = true;
			_bool1 = false;
		}

		public bool method_5(int int4)
		{
			return int4 >= 0 && int4 < method_2();
		}

		public virtual void vmethod_3(float float3, int int4)
		{
			if (method_5(int4))
			{
				Float0[int4] = float3;
			}
		}

		public virtual float vmethod_4(int int4)
		{
			if (method_5(int4) && Bool0)
			{
				return Float0[int4];
			}
			return 0f;
		}

		public IEnumerator<float> GetEnumerator()
		{
			return new Class14(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
