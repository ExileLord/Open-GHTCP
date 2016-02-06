using ns13;
using System;
using System.Security.Cryptography;

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
				if (this.byte_0 == null)
				{
					this.GenerateKey();
				}
				return (byte[])this.byte_0.Clone();
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
				this.byte_0 = (byte[])value.Clone();
			}
		}

		public override KeySizes[] LegalBlockSizes
		{
			get
			{
				return new KeySizes[]
				{
					new KeySizes(8, 8, 0)
				};
			}
		}

		public override KeySizes[] LegalKeySizes
		{
			get
			{
				return new KeySizes[]
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
			this.byte_0 = new byte[12];
			Random random = new Random();
			random.NextBytes(this.byte_0);
		}

		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIV)
		{
			this.byte_0 = rgbKey;
			return new Class210(this.Key);
		}

		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIV)
		{
			this.byte_0 = rgbKey;
			return new Class211(this.Key);
		}
	}
}
