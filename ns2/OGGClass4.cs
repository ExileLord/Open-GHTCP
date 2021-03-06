using ns10;
using System;
using System.Runtime.CompilerServices;

namespace ns2
{
	public class OGGClass4
	{
		public int int_0;

		public int int_1;

		public OGGClass2 oggClass2 = new OGGClass2();

		public float[] float_0;

		public OGGData oggData;

		public int[] int_2 = new int[15];

		[MethodImpl(MethodImplOptions.Synchronized)]
		public int method_0(float[] float_1, int int_3, OGGClass3 oggClass3, int int_4)
		{
			int num = int_4 / this.int_0;
			if (this.int_2.Length < num)
			{
				this.int_2 = new int[num];
			}
			int i;
			for (i = 0; i < num; i++)
			{
				int num2 = this.method_4(oggClass3);
				if (num2 == -1)
				{
					return -1;
				}
				this.int_2[i] = num2 * this.int_0;
			}
			i = 0;
			int num3 = 0;
			while (i < this.int_0)
			{
				for (int j = 0; j < num; j++)
				{
					float_1[int_3 + num3 + j] += this.float_0[this.int_2[j] + i];
				}
				i++;
				num3 += num;
			}
			return 0;
		}

		public int method_1(float[] float_1, int int_3, OGGClass3 oggClass3, int int_4)
		{
			if (this.int_0 > 8)
			{
				int i = 0;
				while (i < int_4)
				{
					int num = this.method_4(oggClass3);
					if (num == -1)
					{
						return -1;
					}
					int num2 = num * this.int_0;
					int j = 0;
					while (j < this.int_0)
					{
						float_1[int_3 + i++] += this.float_0[num2 + j++];
					}
				}
			}
			else
			{
				int i = 0;
				while (i < int_4)
				{
					int num = this.method_4(oggClass3);
					if (num == -1)
					{
						return -1;
					}
					int num2 = num * this.int_0;
					int j = 0;
					for (int k = 0; k < this.int_0; k++)
					{
						float_1[int_3 + i++] += this.float_0[num2 + j++];
					}
				}
			}
			return 0;
		}

		public int method_2(float[] float_1, int int_3, OGGClass3 oggClass3, int int_4)
		{
			int i = 0;
			while (i < int_4)
			{
				int num = this.method_4(oggClass3);
				if (num == -1)
				{
					return -1;
				}
				int num2 = num * this.int_0;
				int j = 0;
				while (j < this.int_0)
				{
					float_1[int_3 + i++] = this.float_0[num2 + j++];
				}
			}
			return 0;
		}

		public int method_3(float[][] float_1, int int_3, int int_4, OGGClass3 oggClass3, int int_5)
		{
            int num = 0;
			int i = int_3 / int_4;
			while (i < (int_3 + int_5) / int_4)
			{
				int num2 = this.method_4(oggClass3);
				if (num2 == -1)
				{
					return -1;
				}
				int num3 = num2 * this.int_0;
				for (int j = 0; j < this.int_0; j++)
				{
					float_1[num][i] += this.float_0[num3 + j];
					num++;
					if (num == int_4)
					{
						num = 0;
						i++;
					}
				}
			}
			return 0;
		}

		public int method_4(OGGClass3 oggClass3)
		{
            int num = 0;
			OGGData @class = this.oggData;
			if (@class == null)
			{
				return num;
			}
			int num2 = oggClass3.method_2(@class.int_2);
			if (num2 >= 0)
			{
				num = @class.int_0[num2];
				oggClass3.method_3(@class.int_1[num2]);
				if (num <= 0)
				{
					return -num;
				}
			}
			do
			{
				switch (oggClass3.method_7())
				{
				case 0:
					num = @class.int_3[num];
					goto IL_46;
				case 1:
					num = @class.int_4[num];
					goto IL_46;
				}
				return -1;
				IL_46:;
			}
			while (num > 0);
			return -num;
		}

		public void method_5()
		{
		}
		public int method_6(OGGClass2 oggClass2)
		{
            this.oggClass2 = oggClass2;
			this.int_1 = oggClass2.int_1;
			this.int_0 = oggClass2.int_0;
            this.float_0 = oggClass2.method_3();
            this.oggData = this.getOGGData();
            if (this.oggData == null)
			{
                this.method_5();
                return -1;
			}
            return 0;
		}
        
        internal static int[] smethod_0(int[] numArray, int num)
        {
            int[] numArray1 = new int[33];
            int[] numArray2 = new int[num];
            for (int i = 0; i < num; i++)
            {
                int num1 = numArray[i];
                if (num1 > 0)
                {
                    int num2 = numArray1[num1];
                    if (num1 < 32 && num2 >> (num1 & 31) != 0)
                    {
                        return null;
                    }
                    numArray2[i] = num2;
                    int num3 = num1;
                    while (true)
                    {
                        if (num3 <= 0)
                        {
                            break;
                        }
                        else if ((numArray1[num3] & 1) == 0)
                        {
                            numArray1[num3] = numArray1[num3] + 1;
                            num3--;
                        }
                        else if (num3 != 1)
                        {
                            numArray1[num3] = numArray1[num3 - 1] << 1;
                            break;
                        }
                        else
                        {
                            numArray1[1] = numArray1[1] + 1;
                            break;
                        }
                    }
                    for (int j = num1 + 1; j < 33 && (ulong)(numArray1[j] >> 1) == (ulong)num2; j++)
                    {
                        num2 = numArray1[j];
                        numArray1[j] = numArray1[j - 1] << 1;
                    }
                }
            }
            for (int k = 0; k < num; k++)
            {
                int num4 = 0;
                for (int l = 0; l < numArray[k]; l++)
                {
                    num4 = num4 << 1;
                    num4 = num4 | numArray2[k] >> (l & 31) & 1;
                }
                numArray2[k] = num4;
            }
            return numArray2;
        }

        public OGGData getOGGData()
		{
            int num = 0;
			OGGData oggData = new OGGData();
			int[] array = oggData.int_3 = new int[this.int_1 * 2];
			int[] array2 = oggData.int_4 = new int[this.int_1 * 2];
			int[] array3 = OGGClass4.smethod_0(this.oggClass2.int_2, this.oggClass2.int_1);
            if (array3 == null)
			{
				return null;
			}
            oggData.int_5 = this.int_1 * 2;
            for (int i = 0; i < this.int_1; i++)
			{
				if (this.oggClass2.int_2[i] > 0)
				{
					int num2 = 0;
					int j;
                    for (j = 0; j < this.oggClass2.int_2[i] - 1; j++)
					{
                        if (((uint)array3[i] >> j & 1u) == 0u)
						{
                            if (array[num2] == 0)
							{
                                num = (array[num2] = num + 1);
							}
                            num2 = array[num2];
                        }
						else
						{
                            if (array2[num2] == 0)
							{
                                num = (array2[num2] = num + 1);
							}
							num2 = array2[num2];
                        }
					}
                    if (((uint)array3[i] >> j & 1u) == 0u)
					{
						array[num2] = -i;
					}
					else
					{
						array2[num2] = -i;
					}
                }
			}
            oggData.int_2 = OGGClass4.smethod_1(this.int_1) - 4;
			if (oggData.int_2 < 5)
			{
				oggData.int_2 = 5;
			}
			int num3 = 1 << oggData.int_2;
			oggData.int_0 = new int[num3];
			oggData.int_1 = new int[num3];
			for (int k = 0; k < num3; k++)
			{
				int num4 = 0;
				int num5 = 0;
				while (num5 < oggData.int_2 && (num4 > 0 || num5 == 0))
				{
					if ((k & 1 << num5) != 0)
					{
						num4 = array2[num4];
					}
					else
					{
						num4 = array[num4];
					}
					num5++;
				}
				oggData.int_0[k] = num4;
				oggData.int_1[k] = num5;
			}
			return oggData;
		}

        private void printArray(int[] array)
        {
            Console.Write("{");
            foreach(int i in array)
            {
                Console.Write(i + ", ");
            }
            Console.Write("}\n");
        }

		public static int smethod_1(int int_3)
		{
			int num = 0;
			while (int_3 != 0)  
			{
				num++;
				int_3 = (int)((uint)int_3 >> 1);
			}
			return num;
		}
	}
}
