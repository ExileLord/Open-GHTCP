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

		private int[] int_5 = new int[int_0 + 1];

		private int[] int_6 = new int[int_0 + 257];

		private int[] int_7 = new int[int_0 + 1];

		private byte[] byte_0 = new byte[int_0 + int_1 - 1];

		public byte[] method_0(byte[] byte_1)
		{
			MemoryStream memoryStream2;
			using (var memoryStream = new MemoryStream(byte_1))
			{
				MemoryStream memoryStream3;
				memoryStream2 = (memoryStream3 = new MemoryStream());
				try
				{
					method_1(memoryStream, memoryStream2);
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
			var num = int_0 - int_1;
			var num2 = 0;
			var num3 = 1;
			var array = new byte[17];
			byte b = 1;
			var num4 = stream_0.Length - stream_0.Position;
			for (var i = int_0 + 1; i <= int_0 + 256; i++)
			{
				int_6[i] = int_0;
			}
			for (var i = 0; i < int_0; i++)
			{
				int_7[i] = int_0;
			}
			array[0] = 0;
			for (var i = num2; i < byte_0.Length; i++)
			{
				byte_0[i] = 32;
			}
			int j;
			for (j = 0; j < int_1; j++)
			{
				var expr_C0 = num4;
				num4 = expr_C0 - 1L;
				if (expr_C0 <= 0L)
				{
					break;
				}
				byte_0[num + j] = (byte)stream_0.ReadByte();
			}
			for (var i = 1; i <= int_1; i++)
			{
				method_2(num - i);
			}
			method_2(num);
			do
			{
				if (int_4 > j)
				{
					int_4 = j;
				}
				if (int_4 <= int_2)
				{
					int_4 = 1;
					var expr_136_cp_0 = array;
					var expr_136_cp_1 = 0;
					expr_136_cp_0[expr_136_cp_1] |= b;
					array[num3++] = byte_0[num];
				}
				else
				{
					array[num3++] = (byte)int_3;
					array[num3++] = (byte)((int_3 >> 4 & 240) | int_4 - (int_2 + 1));
				}
				int i;
				if ((b = (byte)(b << 1)) == 0)
				{
					for (i = 0; i < num3; i++)
					{
						stream_1.WriteByte(array[i]);
					}
					array[0] = 0;
					var arg_1BC_0 = 1;
					b = 1;
					num3 = arg_1BC_0;
				}
				var num5 = int_4;
				for (i = 0; i < num5; i++)
				{
					var expr_1CC = num4;
					num4 = expr_1CC - 1L;
					if (expr_1CC <= 0L)
					{
						break;
					}
					method_3(num2);
					byte_0[num2] = (byte)stream_0.ReadByte();
					if (num2 < int_1 - 1)
					{
						byte_0[num2 + int_0] = byte_0[num2];
					}
					num2 = (num2 + 1 & int_0 - 1);
					num = (num + 1 & int_0 - 1);
					method_2(num);
				}
				while (i++ < num5)
				{
					method_3(num2);
					num2 = (num2 + 1 & int_0 - 1);
					num = (num + 1 & int_0 - 1);
					if (--j != 0)
					{
						method_2(num);
					}
				}
			}
			while (j > 0);
			if (num3 > 1)
			{
				for (var i = 0; i < num3; i++)
				{
					stream_1.WriteByte(array[i]);
				}
			}
		}

		private void method_2(int int_8)
		{
			var num = 1;
			var num2 = int_0 + 1 + byte_0[int_8];
			int_6[int_8] = (int_5[int_8] = int_0);
			int_4 = 0;
			while (true)
			{
				if (num >= 0)
				{
					if (int_6[num2] == int_0)
					{
						goto IL_C3;
					}
					num2 = int_6[num2];
				}
				else
				{
					if (int_5[num2] == int_0)
					{
						goto IL_168;
					}
					num2 = int_5[num2];
				}
				var num3 = 1;
				while (num3 < int_1 && (num = byte_0[int_8 + num3] - byte_0[num2 + num3]) == 0)
				{
					num3++;
				}
				if (num3 > int_4)
				{
					int_3 = num2;
					if ((int_4 = num3) >= int_1)
					{
						break;
					}
				}
			}
			int_7[int_8] = int_7[num2];
			int_5[int_8] = int_5[num2];
			int_6[int_8] = int_6[num2];
			int_7[int_5[num2]] = int_8;
			int_7[int_6[num2]] = int_8;
			if (int_6[int_7[num2]] == num2)
			{
				int_6[int_7[num2]] = int_8;
			}
			else
			{
				int_5[int_7[num2]] = int_8;
			}
			int_7[num2] = int_0;
			return;
			IL_C3:
			int_6[num2] = int_8;
			int_7[int_8] = num2;
			return;
			IL_168:
			int_5[num2] = int_8;
			int_7[int_8] = num2;
		}

		private void method_3(int int_8)
		{
			if (int_7[int_8] == int_0)
			{
				return;
			}
			int num;
			if (int_6[int_8] == int_0)
			{
				num = int_5[int_8];
			}
			else if (int_5[int_8] == int_0)
			{
				num = int_6[int_8];
			}
			else
			{
				num = int_5[int_8];
				if (int_6[num] != int_0)
				{
					do
					{
						num = int_6[num];
					}
					while (int_6[num] != int_0);
					int_6[int_7[num]] = int_5[num];
					int_7[int_5[num]] = int_7[num];
					int_5[num] = int_5[int_8];
					int_7[int_5[int_8]] = num;
				}
				int_6[num] = int_6[int_8];
				int_7[int_6[int_8]] = num;
			}
			int_7[num] = int_7[int_8];
			if (int_6[int_7[int_8]] == int_8)
			{
				int_6[int_7[int_8]] = num;
			}
			else
			{
				int_5[int_7[int_8]] = num;
			}
			int_7[int_8] = int_0;
		}

		public byte[] method_4(byte[] byte_1)
		{
			MemoryStream memoryStream2;
			using (var memoryStream = new MemoryStream(byte_1))
			{
				MemoryStream memoryStream3;
				memoryStream2 = (memoryStream3 = new MemoryStream());
				try
				{
					method_5(memoryStream, memoryStream2);
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
			var num = int_0 - int_1;
			var num2 = 0;
			var num3 = stream_0.Length - stream_0.Position;
			for (var i = 0; i < byte_0.Length; i++)
			{
				byte_0[i] = 32;
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
					stream_1.WriteByte(byte_0[num++] = (byte)stream_0.ReadByte());
					num &= int_0 - 1;
				}
				else
				{
					num3 -= 2L;
					int num4 = (byte)stream_0.ReadByte();
					int num5 = (byte)stream_0.ReadByte();
					num4 |= (num5 & 240) << 4;
					num5 = (num5 & 15) + int_2;
					for (var j = 0; j <= num5; j++)
					{
						stream_1.WriteByte(byte_0[num++] = byte_0[num4 + j & int_0 - 1]);
						num &= int_0 - 1;
					}
				}
			}
		}
	}
}
