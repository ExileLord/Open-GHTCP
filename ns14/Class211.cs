using System;
using System.Security.Cryptography;

namespace ns14
{
	public class Class211 : Class209, IDisposable, ICryptoTransform
	{
		public int InputBlockSize
		{
			get
			{
				return 1;
			}
		}

		public int OutputBlockSize
		{
			get
			{
				return 1;
			}
		}

		public bool CanTransformMultipleBlocks
		{
			get
			{
				return true;
			}
		}

		public bool CanReuseTransform
		{
			get
			{
				return true;
			}
		}

		public Class211(byte[] byte0)
		{
			method_1(byte0);
		}

		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			var array = new byte[inputCount];
			TransformBlock(inputBuffer, inputOffset, inputCount, array, 0);
			return array;
		}

		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			for (var i = inputOffset; i < inputOffset + inputCount; i++)
			{
                var b = (byte)(inputBuffer[i] ^ method_0());
				outputBuffer[outputOffset++] = b;
				method_2(b);
			}
			return inputCount;
		}

		public void Dispose()
		{
			method_3();
		}
	}
}
