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

			object IEnumerator.Current
			{
				get
				{
					return Current;
				}
			}

			public object Clone()
			{
				return MemberwiseClone();
			}

			public BitListEnumerator(BitList bitList_0)
			{
				_index = -1;
				_bitList = bitList_0;
				_max = bitList_0.bitLength;
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

		private readonly List<byte> data = new List<byte>();

		private int bitLength;

		public bool this[int index]
		{
			get
			{
				if (index < 0 || index >= bitLength)
				{
					throw new ArgumentOutOfRangeException();
				}
				return (data[index >> 3] & 1 << (index & 7)) != 0;
			}
			set
			{
				if (index < 0 || index >= bitLength)
				{
					throw new ArgumentOutOfRangeException();
				}
				int num = index >> 3;
				int num2 = index & 7;
				if (value)
				{
					List<byte> list;
					int index2;
                    (list = data)[index2 = num] = (byte)(list[index2] | (byte)(1 << num2));
					return;
				}
				List<byte> list2;
				int index3;
                (list2 = data)[index3 = num] = (byte)(list2[index3] & (byte)(~(byte)(1 << num2)));
			}
		}

		public int Count
		{
			get
			{
				return bitLength;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		public BitList()
		{
		}

		public BitList(BitList bitList_0)
		{
			data.AddRange(bitList_0.data);
			bitLength = bitList_0.bitLength;
		}

		public static byte[] smethod_0<T>(T gparam_0) where T : struct
		{
			byte[] array = new byte[Marshal.SizeOf(gparam_0)];
			try
			{
				T[] src = {
					gparam_0
				};
				Buffer.BlockCopy(src, 0, array, 0, array.Length);
				return array;
			}
			catch
			{
			}
			GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			try
			{
				Marshal.StructureToPtr(gparam_0, gCHandle.AddrOfPinnedObject(), false);
			}
			finally
			{
				gCHandle.Free();
			}
			return array;
		}

		public void method_0(int int_0, byte byte_0)
		{
			int num = int_0 >> 3;
			int num2 = int_0 & 7;
			if (num2 == 0)
			{
				data[num] = byte_0;
			}
			List<byte> list;
			int index;
            (list = data)[index = num] = (byte)(list[index] & (byte)(~(byte)(255 << num2)));
			List<byte> list2;
			int index2;
            (list2 = data)[index2 = num] = (byte)(list2[index2] | (byte)(byte_0 << num2));
			if (num + 1 == data.Count)
			{
				data.Add(0);
				bitLength += num2;
			}
			List<byte> list3;
			int index3;
            (list3 = data)[index3 = num + 1] = (byte)(list3[index3] & (byte)(~(byte)(255 >> 8 - num2)));
			List<byte> list4;
			int index4;
            (list4 = data)[index4 = num + 1] = (byte)(list4[index4] | (byte)(byte_0 >> 8 - num2));
		}

		public void Add<T>(T gparam_0) where T : struct
		{
			if (typeof(T).Equals(typeof(byte)))
			{
				method_0(bitLength, (byte)((object)gparam_0));
				return;
			}
			method_1(smethod_0(gparam_0));
		}

		public void method_1(IEnumerable<byte> ienumerable_0)
		{
			if (bitLength != 0 && (bitLength & 7) != 0)
			{
				foreach (byte current in ienumerable_0)
				{
					method_0(bitLength, current);
				}
				return;
			}
			data.AddRange(ienumerable_0);
			bitLength = data.Count << 3;
		}

		public override string ToString()
		{
			string text = string.Empty;
			using (IEnumerator<bool> enumerator = GetEnumerator())
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
			BitList bitList = (BitList)obj;
			if (bitLength != bitList.bitLength)
			{
				return false;
			}
			int num = (bitLength >> 3) + 1;
			for (int i = 0; i < num; i++)
			{
				if (data[i] != bitList.data[i])
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
			for (int i = 0; i < bitLength; i++)
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
			if (index < 0 || index > bitLength)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (index == bitLength)
			{
				Add(item);
				return;
			}
			if ((data.Count << 3) - bitLength == 0)
			{
				data.Add(0);
			}
			int num = 1;
			int num2 = 7;
			int num3 = data.Count - 1;
			int num4 = index >> 3;
			int num5 = index - (num4 << 3);
			for (int i = num3; i > num4; i--)
			{
				data[i] = (byte)(data[i] << num | data[i - 1] >> num2);
			}
			data[num4] = (byte)((data[num4] << num & 255 << num5 + 1) | (data[num4] & ~(255 << num5)));
			if (item)
			{
				List<byte> list;
				int index2;
                (list = data)[index2 = num4] = (byte)(list[index2] | (byte)(1 << num5));
			}
			bitLength++;
		}

		public void RemoveAt(int index)
		{
			if (index >= 0 && index < bitLength)
			{
				int num = 1;
				int num2 = 7;
				int num3 = data.Count - 1;
				int num4 = index >> 3;
				int num5 = index - (num4 << 3);
				byte b = data[num4];
				for (int i = num4; i < num3; i++)
				{
					data[i] = (byte)(data[i] >> num | data[i + 1] << num2);
				}
				List<byte> list;
				int index2;
				(list = data)[index2 = num3] = (byte)(list[index2] >> num);
				data[num4] = (byte)((data[num4] & 255 << num5) | (b & ~(255 << num5)));
				if ((data.Count << 3) - bitLength == 7)
				{
					data.RemoveAt(num3);
				}
				bitLength--;
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		public void Add(bool item)
		{
			int num = (data.Count << 3) - bitLength;
			if (num > 0)
			{
				if (item)
				{
					List<byte> list;
					int index;
                    (list = data)[index = data.Count - 1] = (byte)(list[index] | (byte)(1 << num));
				}
				else
				{
					List<byte> list2;
					int index2;
                    (list2 = data)[index2 = data.Count - 1] = (byte)(list2[index2] & (byte)(~(byte)(1 << num)));
				}
			}
			else
			{
				data.Add(item ? (byte)1 : (byte)0);
			}
			bitLength++;
		}

		public void Clear()
		{
			data.Clear();
			bitLength = 0;
		}

		public bool Contains(bool item)
		{
			foreach (byte current in data)
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
			if (index >= 0 && index + bitLength < array.Length)
			{
				for (int i = 0; i < bitLength; i++)
				{
					array[index + i] = this[i];
				}
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		public bool Remove(bool item)
		{
			int num = IndexOf(item);
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
