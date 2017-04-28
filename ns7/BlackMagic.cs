namespace ns7
{
	public class BlackMagic
	{
		public static void CopyArrayOffset(int[] source, int sourceSize, int int_2, int[] destination, int offset)
		{
            //This is black magic. Not sure what it's used for yet
			switch (int_2)
			{
			case 0:
				for (int i = 0; i < sourceSize; i++)
				{
					destination[i + offset] = source[i];
				}
				return;
			case 1:
				for (int j = 0; j < sourceSize; j++)
				{
					destination[j + offset] = source[j] + destination[j + offset - 1];
				}
				return;
			case 2:
				for (int k = 0; k < sourceSize; k++)
				{
					destination[k + offset] = source[k] + (destination[k + offset - 1] << 1) - destination[k + offset - 2];
				}
				return;
			case 3:
				for (int l = 0; l < sourceSize; l++)
				{
					destination[l + offset] = source[l] + ((destination[l + offset - 1] - destination[l + offset - 2] << 1) + (destination[l + offset - 1] - destination[l + offset - 2])) + destination[l + offset - 3];
				}
				return;
			case 4:
				for (int m = 0; m < sourceSize; m++)
				{
					destination[m + offset] = source[m] + (destination[m + offset - 1] + destination[m + offset - 3] << 2) - ((destination[m + offset - 2] << 2) + (destination[m + offset - 2] << 1)) - destination[m + offset - 4];
				}
				return;
			default:
				return;
			}
		}
	}
}
