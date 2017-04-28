using System;
using System.Security.Cryptography;
using GHNamespace6;

namespace GHNamespace7
{
	public class Class208 : Class207
	{
		private byte[] _byte0;

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
				if (_byte0 == null)
				{
					GenerateKey();
				}
				return (byte[])_byte0.Clone();
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
				_byte0 = (byte[])value.Clone();
			}
		}

		public override KeySizes[] LegalBlockSizes => new[]
		{
		    new KeySizes(8, 8, 0)
		};

	    public override KeySizes[] LegalKeySizes => new[]
	    {
	        new KeySizes(96, 96, 0)
	    };

	    public override void GenerateIV()
		{
		}

		public override void GenerateKey()
		{
			_byte0 = new byte[12];
			var random = new Random();
			random.NextBytes(_byte0);
		}

		public override ICryptoTransform CreateEncryptor(byte[] rgbKey, byte[] rgbIv)
		{
			_byte0 = rgbKey;
			return new Class210(Key);
		}

		public override ICryptoTransform CreateDecryptor(byte[] rgbKey, byte[] rgbIv)
		{
			_byte0 = rgbKey;
			return new Class211(Key);
		}
	}
}
