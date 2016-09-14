using SharpAudio.ASC.Mp3.Decoding;
using System;
using System.IO;

namespace ns5
{
	public class zzStreamClass106
	{
		private readonly Stream _stream;

		private readonly int int_0;

		private int int_1;

		private readonly byte[] _buffer;

		private readonly CircularByteBuffer _circBuffer;

		public zzStreamClass106(Stream stream_1, int int_2)
		{
			this._stream = stream_1;
			this.int_0 = int_2;
			this._buffer = new byte[this.int_0];
			this._circBuffer = new CircularByteBuffer(this.int_0);
		}

		public Stream method_0()
		{
			return this._stream;
		}

		public int method_1(byte[] byte_1, int int_2, int int_3)
		{
			int num = 0;
			bool flag = true;
			while (num < int_3 && flag)
			{
				if (this.int_1 > 0)
				{
					this.int_1--;
					byte_1[int_2 + num] = this._circBuffer[this.int_1];
					num++;
				}
				else
				{
					int num2 = int_3 - num;
					int num3 = this._stream.Read(this._buffer, 0, num2);
					flag = (num3 >= num2);
					for (int i = 0; i < num3; i++)
					{
						this._circBuffer.method_0(this._buffer[i]);
						byte_1[int_2 + num + i] = this._buffer[i];
					}
					num += num3;
				}
			}
			return num;
		}

		public void IncrementSomeVariableAndCheckIfTheBackStreamIsFisted(int int_2)
		{
			this.int_1 += int_2;
			if (this.int_1 > this.int_0)
			{
				Console.WriteLine("YOUR BACKSTREAM IS FISTED!");
			}
		}

		public void method_3()
		{
			this._stream.Close();
		}
	}
}
