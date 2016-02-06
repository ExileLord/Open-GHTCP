using System;
using System.IO;

namespace ns19
{
	public class Class320
	{
		private static int int_0 = 4096;

		private static int int_1 = 18;

		private static int int_2 = 2;

		private int int_3;

		private int int_4;

		private int[] int_5 = new int[Class320.int_0 + 1];

		private int[] int_6 = new int[Class320.int_0 + 257];

		private int[] int_7 = new int[Class320.int_0 + 1];

		private byte[] byte_0 = new byte[Class320.int_0 + Class320.int_1 - 1];

		public byte[] method_0(byte[] byte_1)
		{
			MemoryStream memoryStream2;
			using (MemoryStream memoryStream = new MemoryStream(byte_1))
			{
				MemoryStream memoryStream3;
				memoryStream2 = (memoryStream3 = new MemoryStream());
				try
				{
					this.method_1(memoryStream, memoryStream2);
				}
				finally
				{
					if (memoryStream3 != null)
					{
						((IDisposable)memoryStream3).Dispose();
					}
				}
			}
			return memoryStream2.ToArray();
		}

		public void method_1(Stream stream_0, Stream stream_1)
		{
			if (!stream_0.CanRead)
			{
				throw new IOException("Input stream is not readable.");
			}
			if (!stream_1.CanWrite)
			{
				throw new IOException("Output stream is not writable.");
			}
			int num = Class320.int_0 - Class320.int_1;
			int num2 = 0;
			int num3 = 1;
			byte[] array = new byte[17];
			byte b = 1;
			long num4 = stream_0.Length - stream_0.Position;
			for (int i = Class320.int_0 + 1; i <= Class320.int_0 + 256; i++)
			{
				this.int_6[i] = Class320.int_0;
			}
			for (int i = 0; i < Class320.int_0; i++)
			{
				this.int_7[i] = Class320.int_0;
			}
			array[0] = 0;
			for (int i = num2; i < this.byte_0.Length; i++)
			{
				this.byte_0[i] = 32;
			}
			int j;
			for (j = 0; j < Class320.int_1; j++)
			{
				long expr_C0 = num4;
				num4 = expr_C0 - 1L;
				if (expr_C0 <= 0L)
				{
					break;
				}
				this.byte_0[num + j] = (byte)stream_0.ReadByte();
			}
			for (int i = 1; i <= Class320.int_1; i++)
			{
				this.method_2(num - i);
			}
			this.method_2(num);
			do
			{
				if (this.int_4 > j)
				{
					this.int_4 = j;
				}
				if (this.int_4 <= Class320.int_2)
				{
					this.int_4 = 1;
					byte[] expr_136_cp_0 = array;
					int expr_136_cp_1 = 0;
					expr_136_cp_0[expr_136_cp_1] |= b;
					array[num3++] = this.byte_0[num];
				}
				else
				{
					array[num3++] = (byte)this.int_3;
					array[num3++] = (byte)((this.int_3 >> 4 & 240) | this.int_4 - (Class320.int_2 + 1));
				}
				int i;
				if ((b = (byte)(b << 1)) == 0)
				{
					for (i = 0; i < num3; i++)
					{
						stream_1.WriteByte(array[i]);
					}
					array[0] = 0;
					int arg_1BC_0 = 1;
					b = 1;
					num3 = arg_1BC_0;
				}
				int num5 = this.int_4;
				for (i = 0; i < num5; i++)
				{
					long expr_1CC = num4;
					num4 = expr_1CC - 1L;
					if (expr_1CC <= 0L)
					{
						break;
					}
					this.method_3(num2);
					this.byte_0[num2] = (byte)stream_0.ReadByte();
					if (num2 < Class320.int_1 - 1)
					{
						this.byte_0[num2 + Class320.int_0] = this.byte_0[num2];
					}
					num2 = (num2 + 1 & Class320.int_0 - 1);
					num = (num + 1 & Class320.int_0 - 1);
					this.method_2(num);
				}
				while (i++ < num5)
				{
					this.method_3(num2);
					num2 = (num2 + 1 & Class320.int_0 - 1);
					num = (num + 1 & Class320.int_0 - 1);
					if (--j != 0)
					{
						this.method_2(num);
					}
				}
			}
			while (j > 0);
			if (num3 > 1)
			{
				for (int i = 0; i < num3; i++)
				{
					stream_1.WriteByte(array[i]);
				}
			}
		}

		private void method_2(int int_8)
		{
			int num = 1;
			int num2 = Class320.int_0 + 1 + (int)this.byte_0[int_8];
			this.int_6[int_8] = (this.int_5[int_8] = Class320.int_0);
			this.int_4 = 0;
			while (true)
			{
				if (num >= 0)
				{
					if (this.int_6[num2] == Class320.int_0)
					{
						goto IL_C3;
					}
					num2 = this.int_6[num2];
				}
				else
				{
					if (this.int_5[num2] == Class320.int_0)
					{
						goto IL_168;
					}
					num2 = this.int_5[num2];
				}
				int num3 = 1;
				while (num3 < Class320.int_1 && (num = (int)(this.byte_0[int_8 + num3] - this.byte_0[num2 + num3])) == 0)
				{
					num3++;
				}
				if (num3 > this.int_4)
				{
					this.int_3 = num2;
					if ((this.int_4 = num3) >= Class320.int_1)
					{
						break;
					}
				}
			}
			this.int_7[int_8] = this.int_7[num2];
			this.int_5[int_8] = this.int_5[num2];
			this.int_6[int_8] = this.int_6[num2];
			this.int_7[this.int_5[num2]] = int_8;
			this.int_7[this.int_6[num2]] = int_8;
			if (this.int_6[this.int_7[num2]] == num2)
			{
				this.int_6[this.int_7[num2]] = int_8;
			}
			else
			{
				this.int_5[this.int_7[num2]] = int_8;
			}
			this.int_7[num2] = Class320.int_0;
			return;
			IL_C3:
			this.int_6[num2] = int_8;
			this.int_7[int_8] = num2;
			return;
			IL_168:
			this.int_5[num2] = int_8;
			this.int_7[int_8] = num2;
		}

		private void method_3(int int_8)
		{
			if (this.int_7[int_8] == Class320.int_0)
			{
				return;
			}
			int num;
			if (this.int_6[int_8] == Class320.int_0)
			{
				num = this.int_5[int_8];
			}
			else if (this.int_5[int_8] == Class320.int_0)
			{
				num = this.int_6[int_8];
			}
			else
			{
				num = this.int_5[int_8];
				if (this.int_6[num] != Class320.int_0)
				{
					do
					{
						num = this.int_6[num];
					}
					while (this.int_6[num] != Class320.int_0);
					this.int_6[this.int_7[num]] = this.int_5[num];
					this.int_7[this.int_5[num]] = this.int_7[num];
					this.int_5[num] = this.int_5[int_8];
					this.int_7[this.int_5[int_8]] = num;
				}
				this.int_6[num] = this.int_6[int_8];
				this.int_7[this.int_6[int_8]] = num;
			}
			this.int_7[num] = this.int_7[int_8];
			if (this.int_6[this.int_7[int_8]] == int_8)
			{
				this.int_6[this.int_7[int_8]] = num;
			}
			else
			{
				this.int_5[this.int_7[int_8]] = num;
			}
			this.int_7[int_8] = Class320.int_0;
		}

		public byte[] method_4(byte[] byte_1)
		{
			MemoryStream memoryStream2;
			using (MemoryStream memoryStream = new MemoryStream(byte_1))
			{
				MemoryStream memoryStream3;
				memoryStream2 = (memoryStream3 = new MemoryStream());
				try
				{
					this.method_5(memoryStream, memoryStream2);
				}
				finally
				{
					if (memoryStream3 != null)
					{
						((IDisposable)memoryStream3).Dispose();
					}
				}
			}
			return memoryStream2.ToArray();
		}

		public void method_5(Stream stream_0, Stream stream_1)
		{
			if (!stream_0.CanRead)
			{
				throw new IOException("Input stream is not readable.");
			}
			if (!stream_1.CanWrite)
			{
				throw new IOException("Output stream is not writable.");
			}
			int num = Class320.int_0 - Class320.int_1;
			int num2 = 0;
			long num3 = stream_0.Length - stream_0.Position;
			for (int i = 0; i < this.byte_0.Length; i++)
			{
				this.byte_0[i] = 32;
			}
			while (num3 > 0L)
			{
				if (((num2 >>= 1) & 256) == 0)
				{
					num3 -= 1L;
					num2 = (stream_0.ReadByte() | 65280);
				}
				if ((num2 & 1) != 0)
				{
					num3 -= 1L;
					stream_1.WriteByte(this.byte_0[num++] = (byte)stream_0.ReadByte());
					num &= Class320.int_0 - 1;
				}
				else
				{
					num3 -= 2L;
					int num4 = (int)((byte)stream_0.ReadByte());
					int num5 = (int)((byte)stream_0.ReadByte());
					num4 |= (num5 & 240) << 4;
					num5 = (num5 & 15) + Class320.int_2;
					for (int j = 0; j <= num5; j++)
					{
						stream_1.WriteByte(this.byte_0[num++] = this.byte_0[num4 + j & Class320.int_0 - 1]);
						num &= Class320.int_0 - 1;
					}
				}
			}
		}
	}
}
