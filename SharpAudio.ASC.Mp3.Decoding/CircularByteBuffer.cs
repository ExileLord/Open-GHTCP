using System;

namespace SharpAudio.ASC.Mp3.Decoding
{
	[Serializable]
	public class CircularByteBuffer
	{
		private readonly byte[] dataArray;

		private readonly int length = 1;

		private int index;

		private int numValid;

		private readonly object lockObj = new object();

		public byte this[int int_0]
		{
			get
			{
				return method_1(-1 - int_0);
			}
			set
			{
				method_2(-1 - int_0, value);
			}
		}

		public CircularByteBuffer(int int_0)
		{
			dataArray = new byte[int_0];
			length = int_0;
		}

		public byte method_0(byte byte_0)
		{
			byte result;
			lock (lockObj)
			{
				result = method_1(length);
				dataArray[index] = byte_0;
				numValid++;
				if (numValid > length)
				{
					numValid = length;
				}
				index++;
				index %= length;
			}
			return result;
		}

		private byte method_1(int int_0)
		{
			int i;
			for (i = index + int_0; i >= length; i -= length)
			{
			}
			while (i < 0)
			{
				i += length;
			}
			return dataArray[i];
		}

		private void method_2(int int_0, byte byte_0)
		{
			int i;
			for (i = index + int_0; i > length; i -= length)
			{
			}
			while (i < 0)
			{
				i += length;
			}
			dataArray[i] = byte_0;
		}

		public int method_3()
		{
			return numValid;
		}

		public override string ToString()
		{
			var text = "";
			for (var i = 0; i < dataArray.Length; i++)
			{
				text = text + dataArray[i] + " ";
			}
			object obj = text;
			return string.Concat(obj, "\n index = ", index, " numValid = ", method_3());
		}
	}
}
