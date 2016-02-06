using System;

namespace SharpAudio.ASC.Mp3.Decoding
{
	[Serializable]
	public class CircularByteBuffer
	{
		private byte[] dataArray;

		private int length = 1;

		private int index;

		private int numValid;

		private readonly object lockObj = new object();

		public byte this[int int_0]
		{
			get
			{
				return this.method_1(-1 - int_0);
			}
			set
			{
				this.method_2(-1 - int_0, value);
			}
		}

		public CircularByteBuffer(int int_0)
		{
			this.dataArray = new byte[int_0];
			this.length = int_0;
		}

		public byte method_0(byte byte_0)
		{
			byte result;
			lock (this.lockObj)
			{
				result = this.method_1(this.length);
				this.dataArray[this.index] = byte_0;
				this.numValid++;
				if (this.numValid > this.length)
				{
					this.numValid = this.length;
				}
				this.index++;
				this.index %= this.length;
			}
			return result;
		}

		private byte method_1(int int_0)
		{
			int i;
			for (i = this.index + int_0; i >= this.length; i -= this.length)
			{
			}
			while (i < 0)
			{
				i += this.length;
			}
			return this.dataArray[i];
		}

		private void method_2(int int_0, byte byte_0)
		{
			int i;
			for (i = this.index + int_0; i > this.length; i -= this.length)
			{
			}
			while (i < 0)
			{
				i += this.length;
			}
			this.dataArray[i] = byte_0;
		}

		public int method_3()
		{
			return this.numValid;
		}

		public override string ToString()
		{
			string text = "";
			for (int i = 0; i < this.dataArray.Length; i++)
			{
				text = text + this.dataArray[i] + " ";
			}
			object obj = text;
			return string.Concat(new object[]
			{
				obj,
				"\n index = ",
				this.index,
				" numValid = ",
				this.method_3()
			});
		}
	}
}
