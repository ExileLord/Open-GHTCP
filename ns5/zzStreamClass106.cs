using System;
using System.IO;
using SharpAudio.ASC.Mp3.Decoding;

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
			_stream = stream_1;
			int_0 = int_2;
			_buffer = new byte[int_0];
			_circBuffer = new CircularByteBuffer(int_0);
		}

		public Stream method_0()
		{
			return _stream;
		}

		public int method_1(byte[] byte_1, int int_2, int int_3)
		{
			int num = 0;
			bool flag = true;
			while (num < int_3 && flag)
			{
				if (int_1 > 0)
				{
					int_1--;
					byte_1[int_2 + num] = _circBuffer[int_1];
					num++;
				}
				else
				{
					int num2 = int_3 - num;
					int num3 = _stream.Read(_buffer, 0, num2);
					flag = (num3 >= num2);
					for (int i = 0; i < num3; i++)
					{
						_circBuffer.method_0(_buffer[i]);
						byte_1[int_2 + num + i] = _buffer[i];
					}
					num += num3;
				}
			}
			return num;
		}

		public void IncrementSomeVariableAndCheckIfTheBackStreamIsFisted(int int_2)
		{
			int_1 += int_2;
			if (int_1 > int_0)
			{
				Console.WriteLine("YOUR BACKSTREAM IS FISTED!");
			}
		}

		public void method_3()
		{
			_stream.Close();
		}
	}
}
