using SharpAudio.ASC.Mp3.Decoding;
using System;
using System.IO;

namespace ns5
{
	public class Class106
	{
		private readonly Stream stream_0;

		private readonly int int_0;

		private int int_1;

		private readonly byte[] byte_0;

		private readonly CircularByteBuffer circularByteBuffer_0;

		public Class106(Stream stream_1, int int_2)
		{
			this.stream_0 = stream_1;
			this.int_0 = int_2;
			this.byte_0 = new byte[this.int_0];
			this.circularByteBuffer_0 = new CircularByteBuffer(this.int_0);
		}

		public Stream method_0()
		{
			return this.stream_0;
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
					byte_1[int_2 + num] = this.circularByteBuffer_0[this.int_1];
					num++;
				}
				else
				{
					int num2 = int_3 - num;
					int num3 = this.stream_0.Read(this.byte_0, 0, num2);
					flag = (num3 >= num2);
					for (int i = 0; i < num3; i++)
					{
						this.circularByteBuffer_0.method_0(this.byte_0[i]);
						byte_1[int_2 + num + i] = this.byte_0[i];
					}
					num += num3;
				}
			}
			return num;
		}

		public void method_2(int int_2)
		{
			this.int_1 += int_2;
			if (this.int_1 > this.int_0)
			{
				Console.WriteLine("YOUR BACKSTREAM IS FISTED!");
			}
		}

		public void method_3()
		{
			this.stream_0.Close();
		}
	}
}
