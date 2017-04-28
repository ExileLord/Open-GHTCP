using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SystemTools
{
	[Serializable]
	public class BitList : IEnumerable, IList<bool>, ICloneable, IEnumerable<bool>, ICollection<bool>
	{
		[Serializable]
		private class BitListEnumerator : IEnumerator, IDisposable, ICloneable, IEnumerator<bool>
		{
			private BitList _bitList;

			private bool _current;

			private int _index;

			private int _max;

			public bool Current
			{
				get
				{
					if (_index == -1)
					{
						throw new InvalidOperationException("Enum not started");
					}
					if (_index >= _bitList.Count)
					{
						throw new InvalidOperationException("Enum Ended");
					}
					return _current;
				}
			}

			object IEnumerator.Current => Current;

		    public object Clone()
			{
				return MemberwiseClone();
			}

			public BitListEnumerator(BitList bitList0)
			{
				_index = -1;
				_bitList = bitList0;
				_max = bitList0._bitLength;
			}

			public bool MoveNext()
			{
				if (_index < _bitList.Count - 1)
				{
					_current = _bitList[++_index];
					return true;
				}
				_index = _bitList.Count;
				return false;
			}

			public void Reset()
			{
				_index = -1;
			}

			public void Dispose()
			{
				_bitList = null;
				_max = 0;
				_index = 0;
			}
		}

		private readonly List<byte> _data = new List<byte>();

		private int _bitLength;

		public bool this[int index]
		{
			get
			{
				if (index < 0 || index >= _bitLength)
				{
					throw new ArgumentOutOfRangeException();
				}
				return (_data[index >> 3] & 1 << (index & 7)) != 0;
			}
			set
			{
				if (index < 0 || index >= _bitLength)
				{
					throw new ArgumentOutOfRangeException();
				}
				var num = index >> 3;
				var num2 = index & 7;
				if (value)
				{
					List<byte> list;
					int index2;
                    (list = _data)[index2 = num] = (byte)(list[index2] | (byte)(1 << num2));
					return;
				}
				List<byte> list2;
				int index3;
                (list2 = _data)[index3 = num] = (byte)(list2[index3] & (byte)(~(byte)(1 << num2)));
			}
		}

		public int Count => _bitLength;

	    public bool IsReadOnly => false;

	    public BitList()
		{
		}

		public BitList(BitList bitList0)
		{
			_data.AddRange(bitList0._data);
			_bitLength = bitList0._bitLength;
		}

		public static byte[] smethod_0<T>(T gparam0) where T : struct
		{
			var array = new byte[Marshal.SizeOf(gparam0)];
			try
			{
				T[] src = {
					gparam0
				};
				Buffer.BlockCopy(src, 0, array, 0, array.Length);
				return array;
			}
			catch
			{
			}
			var gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			try
			{
				Marshal.StructureToPtr(gparam0, gCHandle.AddrOfPinnedObject(), false);
			}
			finally
			{
				gCHandle.Free();
			}
			return array;
		}

		public void method_0(int int0, byte byte0)
		{
			var num = int0 >> 3;
			var num2 = int0 & 7;
			if (num2 == 0)
			{
				_data[num] = byte0;
			}
			List<byte> list;
			int index;
            (list = _data)[index = num] = (byte)(list[index] & (byte)(~(byte)(255 << num2)));
			List<byte> list2;
			int index2;
            (list2 = _data)[index2 = num] = (byte)(list2[index2] | (byte)(byte0 << num2));
			if (num + 1 == _data.Count)
			{
				_data.Add(0);
				_bitLength += num2;
			}
			List<byte> list3;
			int index3;
            (list3 = _data)[index3 = num + 1] = (byte)(list3[index3] & (byte)(~(byte)(255 >> 8 - num2)));
			List<byte> list4;
			int index4;
            (list4 = _data)[index4 = num + 1] = (byte)(list4[index4] | (byte)(byte0 >> 8 - num2));
		}

		public void Add<T>(T gparam0) where T : struct
		{
			if (typeof(T).Equals(typeof(byte)))
			{
				method_0(_bitLength, (byte)((object)gparam0));
				return;
			}
			method_1(smethod_0(gparam0));
		}

		public void method_1(IEnumerable<byte> ienumerable0)
		{
			if (_bitLength != 0 && (_bitLength & 7) != 0)
			{
				foreach (var current in ienumerable0)
				{
					method_0(_bitLength, current);
				}
				return;
			}
			_data.AddRange(ienumerable0);
			_bitLength = _data.Count << 3;
		}

		public override string ToString()
		{
			var text = string.Empty;
			using (var enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					text = (enumerator.Current ? '1' : '0') + text;
				}
			}
			return text;
		}

		public override bool Equals(object obj)
		{
			var bitList = (BitList)obj;
			if (_bitLength != bitList._bitLength)
			{
				return false;
			}
			var num = (_bitLength >> 3) + 1;
			for (var i = 0; i < num; i++)
			{
				if (_data[i] != bitList._data[i])
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public int IndexOf(bool item)
		{
			for (var i = 0; i < _bitLength; i++)
			{
				if (this[i] == item)
				{
					return i;
				}
			}
			return -1;
		}

		public void Insert(int index, bool item)
		{
			if (index < 0 || index > _bitLength)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (index == _bitLength)
			{
				Add(item);
				return;
			}
			if ((_data.Count << 3) - _bitLength == 0)
			{
				_data.Add(0);
			}
			var num = 1;
			var num2 = 7;
			var num3 = _data.Count - 1;
			var num4 = index >> 3;
			var num5 = index - (num4 << 3);
			for (var i = num3; i > num4; i--)
			{
				_data[i] = (byte)(_data[i] << num | _data[i - 1] >> num2);
			}
			_data[num4] = (byte)((_data[num4] << num & 255 << num5 + 1) | (_data[num4] & ~(255 << num5)));
			if (item)
			{
				List<byte> list;
				int index2;
                (list = _data)[index2 = num4] = (byte)(list[index2] | (byte)(1 << num5));
			}
			_bitLength++;
		}

		public void RemoveAt(int index)
		{
			if (index >= 0 && index < _bitLength)
			{
				var num = 1;
				var num2 = 7;
				var num3 = _data.Count - 1;
				var num4 = index >> 3;
				var num5 = index - (num4 << 3);
				var b = _data[num4];
				for (var i = num4; i < num3; i++)
				{
					_data[i] = (byte)(_data[i] >> num | _data[i + 1] << num2);
				}
				List<byte> list;
				int index2;
				(list = _data)[index2 = num3] = (byte)(list[index2] >> num);
				_data[num4] = (byte)((_data[num4] & 255 << num5) | (b & ~(255 << num5)));
				if ((_data.Count << 3) - _bitLength == 7)
				{
					_data.RemoveAt(num3);
				}
				_bitLength--;
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		public void Add(bool item)
		{
			var num = (_data.Count << 3) - _bitLength;
			if (num > 0)
			{
				if (item)
				{
					List<byte> list;
					int index;
                    (list = _data)[index = _data.Count - 1] = (byte)(list[index] | (byte)(1 << num));
				}
				else
				{
					List<byte> list2;
					int index2;
                    (list2 = _data)[index2 = _data.Count - 1] = (byte)(list2[index2] & (byte)(~(byte)(1 << num)));
				}
			}
			else
			{
				_data.Add(item ? (byte)1 : (byte)0);
			}
			_bitLength++;
		}

		public void Clear()
		{
			_data.Clear();
			_bitLength = 0;
		}

		public bool Contains(bool item)
		{
			foreach (var current in _data)
			{
				if (item ? (current != 0) : (current != 255))
				{
					return true;
				}
			}
			return false;
		}

		public void CopyTo(bool[] array, int index)
		{
			if (index >= 0 && index + _bitLength < array.Length)
			{
				for (var i = 0; i < _bitLength; i++)
				{
					array[index + i] = this[i];
				}
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		public bool Remove(bool item)
		{
			var num = IndexOf(item);
			if (num < 0)
			{
				return false;
			}
			RemoveAt(num);
			return true;
		}

		public IEnumerator<bool> GetEnumerator()
		{
			return new BitListEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public object Clone()
		{
			return new BitList(this);
		}
	}
}
