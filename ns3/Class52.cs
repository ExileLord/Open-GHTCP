using System;

namespace ns3
{
	public class Class52
	{
		public byte[] byte_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private readonly Class48 class48_0 = new Class48();

		private readonly byte[] byte_1 = new byte[4];

		public int method_0()
		{
			this.byte_0 = null;
			return 0;
		}

		public int method_1(int int_6)
		{
			if (this.int_2 != 0)
			{
				this.int_1 -= this.int_2;
				if (this.int_1 > 0)
				{
					Buffer.BlockCopy(this.byte_0, this.int_2, this.byte_0, 0, this.int_1);
				}
				this.int_2 = 0;
			}
			if (int_6 > this.int_0 - this.int_1)
			{
				int num = int_6 + this.int_1 + 4096;
				if (this.byte_0 != null)
				{
					byte[] dst = new byte[num];
					Buffer.BlockCopy(this.byte_0, 0, dst, 0, this.byte_0.Length);
					this.byte_0 = dst;
				}
				else
				{
					this.byte_0 = new byte[num];
				}
				this.int_0 = num;
			}
			return this.int_1;
		}

		public int method_2(int int_6)
		{
			if (this.int_1 + int_6 > this.int_0)
			{
				return -1;
			}
			this.int_1 += int_6;
			return 0;
		}

		public int method_3(Class48 class48_1)
		{
			int num = this.int_2;
			int num2 = this.int_1 - this.int_2;
			if (this.int_4 == 0)
			{
				if (num2 < 27)
				{
					return 0;
				}
				if (this.byte_0[num] == 79 && this.byte_0[num + 1] == 103 && this.byte_0[num + 2] == 103)
				{
					if (this.byte_0[num + 3] == 83)
					{
						int num3 = (int)((this.byte_0[num + 26] & 255) + 27);
						if (num2 < num3)
						{
							return 0;
						}
						for (int i = 0; i < (int)(this.byte_0[num + 26] & 255); i++)
						{
							this.int_5 += (int)(this.byte_0[num + 27 + i] & 255);
						}
						this.int_4 = num3;
						goto IL_11E;
					}
				}
				this.int_4 = 0;
				this.int_5 = 0;
				int num4 = 0;
				for (int j = 0; j < num2 - 1; j++)
				{
					if (this.byte_0[num + 1 + j] == 79)
					{
						num4 = num + 1 + j;
                        goto IL_108;
					}
				}
            IL_108:
                if (num4 == 0)
                {
                    num4 = this.int_1;
                }
                this.int_2 = num4;
                return -(num4 - num);
			}
			IL_11E:
			if (this.int_5 + this.int_4 > num2)
			{
				return 0;
			}
			lock (this.byte_1)
			{
				Buffer.BlockCopy(this.byte_0, num + 22, this.byte_1, 0, 4);
				this.byte_0[num + 22] = 0;
				this.byte_0[num + 23] = 0;
				this.byte_0[num + 24] = 0;
				this.byte_0[num + 25] = 0;
				Class48 @class = this.class48_0;
				@class.byte_0 = this.byte_0;
				@class.int_0 = num;
				@class.int_1 = this.int_4;
				@class.byte_1 = this.byte_0;
				@class.int_2 = num + this.int_4;
				@class.int_3 = this.int_5;
				@class.method_7();
				if (this.byte_1[0] == this.byte_0[num + 22] && this.byte_1[1] == this.byte_0[num + 23] && this.byte_1[2] == this.byte_0[num + 24])
				{
					if (this.byte_1[3] == this.byte_0[num + 25])
					{
						goto IL_2B0;
					}
				}
				Buffer.BlockCopy(this.byte_1, 0, this.byte_0, num + 22, 4);
				this.int_4 = 0;
				this.int_5 = 0;
				int num4 = 0;
				for (int k = 0; k < num2 - 1; k++)
				{
					if (this.byte_0[num + 1 + k] == 79)
					{
						num4 = num + 1 + k;
                        goto IL_28C;
					}
				}
            IL_28C:
                if (num4 == 0)
                {
                    num4 = this.int_1;
                }
                this.int_2 = num4;
                return -(num4 - num);
			}
			IL_2B0:
			num = this.int_2;
			if (class48_1 != null)
			{
				class48_1.byte_0 = this.byte_0;
				class48_1.int_0 = num;
				class48_1.int_1 = this.int_4;
				class48_1.byte_1 = this.byte_0;
				class48_1.int_2 = num + this.int_4;
				class48_1.int_3 = this.int_5;
			}
			this.int_3 = 0;
			this.int_2 += (num2 = this.int_4 + this.int_5);
			this.int_4 = 0;
			this.int_5 = 0;
			return num2;
		}

		public int method_4()
		{
			this.int_1 = 0;
			this.int_2 = 0;
			this.int_3 = 0;
			this.int_4 = 0;
			this.int_5 = 0;
			return 0;
		}

		public void method_5()
		{
		}
	}
}
