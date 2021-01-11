using System;
using System.Runtime.CompilerServices;
using GHNamespace3;

namespace GHNamespaceD
{
    public class OggClass4
    {
        public int Int0;

        public int Int1;

        public OggClass2 OggClass2 = new OggClass2();

        public float[] Float0;

        public OggData OggData;

        public int[] Int2 = new int[15];

        [MethodImpl(MethodImplOptions.Synchronized)]
        public int method_0(float[] float1, int int3, OggClass3 oggClass3, int int4)
        {
            int num = int4 / Int0;
            if (Int2.Length < num)
            {
                Int2 = new int[num];
            }
            int i;
            for (i = 0; i < num; i++)
            {
                int num2 = method_4(oggClass3);
                if (num2 == -1)
                {
                    return -1;
                }
                Int2[i] = num2 * Int0;
            }
            i = 0;
            int num3 = 0;
            while (i < Int0)
            {
                for (int j = 0; j < num; j++)
                {
                    float1[int3 + num3 + j] += Float0[Int2[j] + i];
                }
                i++;
                num3 += num;
            }
            return 0;
        }

        public int method_1(float[] float1, int int3, OggClass3 oggClass3, int int4)
        {
            if (Int0 > 8)
            {
                int i = 0;
                while (i < int4)
                {
                    int num = method_4(oggClass3);
                    if (num == -1)
                    {
                        return -1;
                    }
                    int num2 = num * Int0;
                    int j = 0;
                    while (j < Int0)
                    {
                        float1[int3 + i++] += Float0[num2 + j++];
                    }
                }
            }
            else
            {
                int i = 0;
                while (i < int4)
                {
                    int num = method_4(oggClass3);
                    if (num == -1)
                    {
                        return -1;
                    }
                    int num2 = num * Int0;
                    int j = 0;
                    for (int k = 0; k < Int0; k++)
                    {
                        float1[int3 + i++] += Float0[num2 + j++];
                    }
                }
            }
            return 0;
        }

        public int method_2(float[] float1, int int3, OggClass3 oggClass3, int int4)
        {
            int i = 0;
            while (i < int4)
            {
                int num = method_4(oggClass3);
                if (num == -1)
                {
                    return -1;
                }
                int num2 = num * Int0;
                int j = 0;
                while (j < Int0)
                {
                    float1[int3 + i++] = Float0[num2 + j++];
                }
            }
            return 0;
        }

        public int method_3(float[][] float1, int int3, int int4, OggClass3 oggClass3, int int5)
        {
            int num = 0;
            int i = int3 / int4;
            while (i < (int3 + int5) / int4)
            {
                int num2 = method_4(oggClass3);
                if (num2 == -1)
                {
                    return -1;
                }
                int num3 = num2 * Int0;
                for (int j = 0; j < Int0; j++)
                {
                    float1[num][i] += Float0[num3 + j];
                    num++;
                    if (num == int4)
                    {
                        num = 0;
                        i++;
                    }
                }
            }
            return 0;
        }

        public int method_4(OggClass3 oggClass3)
        {
            int num = 0;
            OggData @class = OggData;
            if (@class == null)
            {
                return num;
            }
            int num2 = oggClass3.method_2(@class.Int2);
            if (num2 >= 0)
            {
                num = @class.Int0[num2];
                oggClass3.method_3(@class.Int1[num2]);
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
                        num = @class.Int3[num];
                        goto IL_46;
                    case 1:
                        num = @class.Int4[num];
                        goto IL_46;
                }
                return -1;
                IL_46:
                ;
            } while (num > 0);
            return -num;
        }

        public void method_5()
        {
        }

        public int method_6(OggClass2 oggClass2)
        {
            OggClass2 = oggClass2;
            Int1 = oggClass2.Int1;
            Int0 = oggClass2.Int0;
            Float0 = oggClass2.method_3();
            OggData = GetOggData();
            if (OggData == null)
            {
                method_5();
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
                        if ((numArray1[num3] & 1) == 0)
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
                    for (int j = num1 + 1; j < 33 && (ulong) (numArray1[j] >> 1) == (ulong) num2; j++)
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

        public OggData GetOggData()
        {
            int num = 0;
            OggData oggData = new OggData();
            int[] array = oggData.Int3 = new int[Int1 * 2];
            int[] array2 = oggData.Int4 = new int[Int1 * 2];
            int[] array3 = smethod_0(OggClass2.Int2, OggClass2.Int1);
            if (array3 == null)
            {
                return null;
            }
            oggData.Int5 = Int1 * 2;
            for (int i = 0; i < Int1; i++)
            {
                if (OggClass2.Int2[i] > 0)
                {
                    int num2 = 0;
                    int j;
                    for (j = 0; j < OggClass2.Int2[i] - 1; j++)
                    {
                        if (((uint) array3[i] >> j & 1u) == 0u)
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
                    if (((uint) array3[i] >> j & 1u) == 0u)
                    {
                        array[num2] = -i;
                    }
                    else
                    {
                        array2[num2] = -i;
                    }
                }
            }
            oggData.Int2 = smethod_1(Int1) - 4;
            if (oggData.Int2 < 5)
            {
                oggData.Int2 = 5;
            }
            int num3 = 1 << oggData.Int2;
            oggData.Int0 = new int[num3];
            oggData.Int1 = new int[num3];
            for (int k = 0; k < num3; k++)
            {
                int num4 = 0;
                int num5 = 0;
                while (num5 < oggData.Int2 && (num4 > 0 || num5 == 0))
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
                oggData.Int0[k] = num4;
                oggData.Int1[k] = num5;
            }
            return oggData;
        }

        private void PrintArray(int[] array)
        {
            Console.Write("{");
            foreach (int i in array)
            {
                Console.Write(i + ", ");
            }
            Console.Write("}\n");
        }

        public static int smethod_1(int int3)
        {
            int num = 0;
            while (int3 != 0)
            {
                num++;
                int3 = (int) ((uint) int3 >> 1);
            }
            return num;
        }
    }
}