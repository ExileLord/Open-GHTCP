using System;

namespace SharpAudio.ASC.Mp3.Decoding
{
	[Serializable]
	public class CircularByteBuffer
	{
		private readonly byte[] _dataArray;

		private readonly int _length = 1;

		private int _index;

		private int _numValid;

		private readonly object _lockObj = new object();

		public byte this[int int0]
		{
			get
			{
				return method_1(-1 - int0);
			}
			set
			{
				method_2(-1 - int0, value);
			}
		}

		public CircularByteBuffer(int int0)
		{
			_dataArray = new byte[int0];
			_length = int0;
		}

		public byte method_0(byte byte0)
		{
			byte result;
			lock (_lockObj)
			{
				result = method_1(_length);
				_dataArray[_index] = byte0;
				_numValid++;
				if (_numValid > _length)
				{
					_numValid = _length;
				}
				_index++;
				_index %= _length;
			}
			return result;
		}

		private byte method_1(int int0)
		{
			int i;
			for (i = _index + int0; i >= _length; i -= _length)
			{
			}
			while (i < 0)
			{
				i += _length;
			}
			return _dataArray[i];
		}

		private void method_2(int int0, byte byte0)
		{
			int i;
			for (i = _index + int0; i > _length; i -= _length)
			{
			}
			while (i < 0)
			{
				i += _length;
			}
			_dataArray[i] = byte0;
		}

		public int method_3()
		{
			return _numValid;
		}

		public override string ToString()
		{
			var text = "";
			for (var i = 0; i < _dataArray.Length; i++)
			{
				text = text + _dataArray[i] + " ";
			}
			object obj = text;
			return string.Concat(obj, "\n index = ", _index, " numValid = ", method_3());
		}
	}
}
