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
					if (this._index == -1)
					{
						throw new InvalidOperationException("Enum not started");
					}
					if (this._index >= this._bitList.Count)
					{
						throw new InvalidOperationException("Enum Ended");
					}
					return this._current;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					return this.Current;
				}
			}

			public object Clone()
			{
				return base.MemberwiseClone();
			}

			public BitListEnumerator(BitList bitList_0)
			{
				this._index = -1;
				this._bitList = bitList_0;
				this._max = bitList_0.bitLength;
			}

			public bool MoveNext()
			{
				if (this._index < this._bitList.Count - 1)
				{
					this._current = this._bitList[++this._index];
					return true;
				}
				this._index = this._bitList.Count;
				return false;
			}

			public void Reset()
			{
				this._index = -1;
			}

			public void Dispose()
			{
				this._bitList = null;
				this._max = 0;
				this._index = 0;
			}
		}

		private readonly List<byte> data = new List<byte>();

		private int bitLength;

		public bool this[int index]
		{
			get
			{
				if (index < 0 || index >= this.bitLength)
				{
					throw new ArgumentOutOfRangeException();
				}
				return ((int)this.data[index >> 3] & 1 << (index & 7)) != 0;
			}
			set
			{
				if (index < 0 || index >= this.bitLength)
				{
					throw new ArgumentOutOfRangeException();
				}
				int num = index >> 3;
				int num2 = index & 7;
				if (value)
				{
					List<byte> list;
					int index2;
                    (list = this.data)[index2 = num] = (byte)(list[index2] | (byte)(1 << num2));
					return;
				}
				List<byte> list2;
				int index3;
                (list2 = this.data)[index3 = num] = (byte)(list2[index3] & (byte)(~(byte)(1 << num2)));
			}
		}

		public int Count
		{
			get
			{
				return this.bitLength;
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
			this.data.AddRange(bitList_0.data);
			this.bitLength = bitList_0.bitLength;
		}

		public static byte[] smethod_0<T>(T gparam_0) where T : struct
		{
			byte[] array = new byte[Marshal.SizeOf(gparam_0)];
			try
			{
				T[] src = new T[]
				{
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
				this.data[num] = byte_0;
			}
			List<byte> list;
			int index;
            (list = this.data)[index = num] = (byte)(list[index] & (byte)(~(byte)(255 << num2)));
			List<byte> list2;
			int index2;
            (list2 = this.data)[index2 = num] = (byte)(list2[index2] | (byte)(byte_0 << num2));
			if (num + 1 == this.data.Count)
			{
				this.data.Add(0);
				this.bitLength += num2;
			}
			List<byte> list3;
			int index3;
            (list3 = this.data)[index3 = num + 1] = (byte)(list3[index3] & (byte)(~(byte)(255 >> 8 - num2)));
			List<byte> list4;
			int index4;
            (list4 = this.data)[index4 = num + 1] = (byte)(list4[index4] | (byte)(byte_0 >> 8 - num2));
		}

		public void Add<T>(T gparam_0) where T : struct
		{
			if (typeof(T).Equals(typeof(byte)))
			{
				this.method_0(this.bitLength, (byte)((object)gparam_0));
				return;
			}
			this.method_1(BitList.smethod_0<T>(gparam_0));
		}

		public void method_1(IEnumerable<byte> ienumerable_0)
		{
			if (this.bitLength != 0 && (this.bitLength & 7) != 0)
			{
				foreach (byte current in ienumerable_0)
				{
					this.method_0(this.bitLength, current);
				}
				return;
			}
			this.data.AddRange(ienumerable_0);
			this.bitLength = this.data.Count << 3;
		}

		public override string ToString()
		{
			string text = string.Empty;
			using (IEnumerator<bool> enumerator = this.GetEnumerator())
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
			if (this.bitLength != bitList.bitLength)
			{
				return false;
			}
			int num = (this.bitLength >> 3) + 1;
			for (int i = 0; i < num; i++)
			{
				if (this.data[i] != bitList.data[i])
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return this.ToString().GetHashCode();
		}

		public int IndexOf(bool item)
		{
			for (int i = 0; i < this.bitLength; i++)
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
			if (index < 0 || index > this.bitLength)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (index == this.bitLength)
			{
				this.Add(item);
				return;
			}
			if ((this.data.Count << 3) - this.bitLength == 0)
			{
				this.data.Add(0);
			}
			int num = 1;
			int num2 = 7;
			int num3 = this.data.Count - 1;
			int num4 = index >> 3;
			int num5 = index - (num4 << 3);
			for (int i = num3; i > num4; i--)
			{
				this.data[i] = (byte)((int)this.data[i] << num | this.data[i - 1] >> num2);
			}
			this.data[num4] = (byte)(((int)this.data[num4] << num & 255 << num5 + 1) | ((int)this.data[num4] & ~(255 << num5)));
			if (item)
			{
				List<byte> list;
				int index2;
                (list = this.data)[index2 = num4] = (byte)(list[index2] | (byte)(1 << num5));
			}
			this.bitLength++;
		}

		public void RemoveAt(int index)
		{
			if (index >= 0 && index < this.bitLength)
			{
				int num = 1;
				int num2 = 7;
				int num3 = this.data.Count - 1;
				int num4 = index >> 3;
				int num5 = index - (num4 << 3);
				byte b = this.data[num4];
				for (int i = num4; i < num3; i++)
				{
					this.data[i] = (byte)(this.data[i] >> num | (int)this.data[i + 1] << num2);
				}
				List<byte> list;
				int index2;
				(list = this.data)[index2 = num3] = (byte)(list[index2] >> num);
				this.data[num4] = (byte)(((int)this.data[num4] & 255 << num5) | ((int)b & ~(255 << num5)));
				if ((this.data.Count << 3) - this.bitLength == 7)
				{
					this.data.RemoveAt(num3);
				}
				this.bitLength--;
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		public void Add(bool item)
		{
			int num = (this.data.Count << 3) - this.bitLength;
			if (num > 0)
			{
				if (item)
				{
					List<byte> list;
					int index;
                    (list = this.data)[index = this.data.Count - 1] = (byte)(list[index] | (byte)(1 << num));
				}
				else
				{
					List<byte> list2;
					int index2;
                    (list2 = this.data)[index2 = this.data.Count - 1] = (byte)(list2[index2] & (byte)(~(byte)(1 << num)));
				}
			}
			else
			{
				this.data.Add(item ? (byte)1 : (byte)0);
			}
			this.bitLength++;
		}

		public void Clear()
		{
			this.data.Clear();
			this.bitLength = 0;
		}

		public bool Contains(bool item)
		{
			foreach (byte current in this.data)
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
			if (index >= 0 && index + this.bitLength < array.Length)
			{
				for (int i = 0; i < this.bitLength; i++)
				{
					array[index + i] = this[i];
				}
				return;
			}
			throw new ArgumentOutOfRangeException();
		}

		public bool Remove(bool item)
		{
			int num = this.IndexOf(item);
			if (num < 0)
			{
				return false;
			}
			this.RemoveAt(num);
			return true;
		}

		public IEnumerator<bool> GetEnumerator()
		{
			return new BitList.BitListEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public object Clone()
		{
			return new BitList(this);
		}
	}
}
