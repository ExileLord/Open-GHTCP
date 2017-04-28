using System;
using System.Security.Cryptography;
using ns13;

namespace ns14
{
	public class Class208 : Class207
	{
		private byte[] byte_0;

		public override int BlockSize
		{
			get
			{
				return 8;
			}
			set
			{
				if (value != 8)
				{
					throw new CryptographicException("Block size is invalid");
				}
			}
		}

		public override byte[] Key
		{
			get
			{
				if (byte_0 == null)
				{
					GenerateKey();
				}
				return (byte[])byte_0.Clone();
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.Length != 12)
				{
					throw new CryptographicException("Key size is illegal");
				}
				byte_0 = (byte[])value.Clone();
			}
		}

		public override KeySizes[] LegalBlockSizes
		{
			get
			{
				return new[]
				{
					new KeySizes(8, 8, 0)
				};
			}
		}

		public override KeySizes[] LegalKeySizes
		{
			get
			{
				return new[]
				{
					new KeySizes(96, 96, 0)
				};
			}
		}

		public override void GenerateIV()
		{
		}

		public override void GenerateKey()
		{
			byte_0 = new byte[12];
			Random random = new Random();
			random.NextBytes(byte_0);
		}

		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			byte_0 = rgbKey;
			return new Class210(Key);
		}

		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			byte_0 = rgbKey;
			return new Class211(Key);
		}
	}
}
