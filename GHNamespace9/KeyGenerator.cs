using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GHNamespace9
{
	public class KeyGenerator
	{
		public static bool Flag0 = false;

		public static bool Flag1 = false;

        //Who the hell is Ivan Medvedev
		private static readonly byte[] PwByteArray = {
			73,   //I
			118,  //v
			97,   //a
			110,  //n
			32,   // 
			77,   //M
			101,  //e
			100,  //d
			118,  //v
			101,  //e
			100,  //d
			101,  //e
			118   //v
		};

		private static uint _key;

		private static readonly uint XorMask = 4294967295u;

		public static readonly uint[] Crc32 = {
			0u,
			1996959894u, // Magic
			3993919788u, // Do not touch
			2567524794u,
			124634137u,
			1886057615u,
			3915621685u,
			2657392035u,
			249268274u,
			2044508324u,
			3772115230u,
			2547177864u,
			162941995u,
			2125561021u,
			3887607047u,
			2428444049u,
			498536548u,
			1789927666u,
			4089016648u,
			2227061214u,
			450548861u,
			1843258603u,
			4107580753u,
			2211677639u,
			325883990u,
			1684777152u,
			4251122042u,
			2321926636u,
			335633487u,
			1661365465u,
			4195302755u,
			2366115317u,
			997073096u,
			1281953886u,
			3579855332u,
			2724688242u,
			1006888145u,
			1258607687u,
			3524101629u,
			2768942443u,
			901097722u,
			1119000684u,
			3686517206u,
			2898065728u,
			853044451u,
			1172266101u,
			3705015759u,
			2882616665u,
			651767980u,
			1373503546u,
			3369554304u,
			3218104598u,
			565507253u,
			1454621731u,
			3485111705u,
			3099436303u,
			671266974u,
			1594198024u,
			3322730930u,
			2970347812u,
			795835527u,
			1483230225u,
			3244367275u,
			3060149565u,
			1994146192u,
			31158534u,
			2563907772u,
			4023717930u,
			1907459465u,
			112637215u,
			2680153253u,
			3904427059u,
			2013776290u,
			251722036u,
			2517215374u,
			3775830040u,
			2137656763u,
			141376813u,
			2439277719u,
			3865271297u,
			1802195444u,
			476864866u,
			2238001368u,
			4066508878u,
			1812370925u,
			453092731u,
			2181625025u,
			4111451223u,
			1706088902u,
			314042704u,
			2344532202u,
			4240017532u,
			1658658271u,
			366619977u,
			2362670323u,
			4224994405u,
			1303535960u,
			984961486u,
			2747007092u,
			3569037538u,
			1256170817u,
			1037604311u,
			2765210733u,
			3554079995u,
			1131014506u,
			879679996u,
			2909243462u,
			3663771856u,
			1141124467u,
			855842277u,
			2852801631u,
			3708648649u,
			1342533948u,
			654459306u,
			3188396048u,
			3373015174u,
			1466479909u,
			544179635u,
			3110523913u,
			3462522015u,
			1591671054u,
			702138776u,
			2966460450u,
			3352799412u,
			1504918807u,
			783551873u,
			3082640443u,
			3233442989u,
			3988292384u,
			2596254646u,
			62317068u,
			1957810842u,
			3939845945u,
			2647816111u,
			81470997u,
			1943803523u,
			3814918930u,
			2489596804u,
			225274430u,
			2053790376u,
			3826175755u,
			2466906013u,
			167816743u,
			2097651377u,
			4027552580u,
			2265490386u,
			503444072u,
			1762050814u,
			4150417245u,
			2154129355u,
			426522225u,
			1852507879u,
			4275313526u,
			2312317920u,
			282753626u,
			1742555852u,
			4189708143u,
			2394877945u,
			397917763u,
			1622183637u,
			3604390888u,
			2714866558u,
			953729732u,
			1340076626u,
			3518719985u,
			2797360999u,
			1068828381u,
			1219638859u,
			3624741850u,
			2936675148u,
			906185462u,
			1090812512u,
			3747672003u,
			2825379669u,
			829329135u,
			1181335161u,
			3412177804u,
			3160834842u,
			628085408u,
			1382605366u,
			3423369109u,
			3138078467u,
			570562233u,
			1426400815u,
			3317316542u,
			2998733608u,
			733239954u,
			1555261956u,
			3268935591u,
			3050360625u,
			752459403u,
			1541320221u,
			2607071920u,
			3965973030u,
			1969922972u,
			40735498u,
			2617837225u,
			3943577151u,
			1913087877u,
			83908371u,
			2512341634u,
			3803740692u,
			2075208622u,
			213261112u,
			2463272603u,
			3855990285u,
			2094854071u,
			198958881u,
			2262029012u,
			4057260610u,
			1759359992u,
			534414190u,
			2176718541u,
			4139329115u,
			1873836001u,
			414664567u,
			2282248934u,
			4279200368u,
			1711684554u,
			285281116u,
			2405801727u,
			4167216745u,
			1634467795u,
			376229701u,
			2685067896u,
			3608007406u,
			1308918612u,
			956543938u,
			2808555105u,
			3495958263u,
			1231636301u,
			1047427035u,
			2932959818u,
			3654703836u,
			1088359270u,
			936918000u,
			2847714899u,
			3736837829u,
			1202900863u,
			817233897u,
			3183342108u,
			3401237130u,
			1404277552u,
			615818150u,
			3134207493u,
			3453421203u,
			1423857449u,
			601450431u,
			3009837614u,
			3294710456u,
			1567103746u,
			711928724u,
			3020668471u,
			3272380065u,
			1510334235u,
			755167117u
		};

		private static readonly Random Random0 = new Random();

		public static void smethod_0(Stream stream0, Stream stream1, byte[] byte1, byte[] byte2)
		{
			if ((byte1.Length != 16 && byte1.Length != 24 && byte1.Length != 32) || byte2.Length != 16)
			{
				return;
			}
			var rijndael = Rijndael.Create();
			rijndael.Key = byte1;
			rijndael.IV = byte2;
			var cryptoStream = new CryptoStream(stream1, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
			var array = new byte[4096];
			int count;
			while ((count = stream0.Read(array, 0, array.Length)) > 0)
			{
				cryptoStream.Write(array, 0, count);
			}
			cryptoStream.Close();
		}

		public static void smethod_1(Stream stream0, Stream stream1, string string0)
		{
			var passwordDeriveBytes = new PasswordDeriveBytes(string0, PwByteArray);
			smethod_0(stream0, stream1, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
		}

		public static byte[] smethod_2(Stream stream0, string string0)
		{
			var memoryStream = new MemoryStream();
			smethod_1(stream0, memoryStream, string0);
			return memoryStream.ToArray();
		}

		private static void CryptoMethod(Stream stream0, Stream stream1, byte[] byte1, byte[] byte2)
		{
			if ((byte1.Length != 16 && byte1.Length != 24 && byte1.Length != 32) || byte2.Length != 16)
			{
				return;
			}
			var rijndael = Rijndael.Create();
			rijndael.Key = byte1;
			rijndael.IV = byte2;
			var cryptoStream = new CryptoStream(stream1, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
			var array = new byte[4096];
			int count;
			while ((count = stream0.Read(array, 0, array.Length)) > 0)
			{
				cryptoStream.Write(array, 0, count);
			}
			cryptoStream.Close();
		}

		private static void CryptoMethod(Stream stream0, Stream stream1, string string0)
		{
			var passwordDeriveBytes = new PasswordDeriveBytes(string0, PwByteArray);
			CryptoMethod(stream0, stream1, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
		}

		public static byte[] CryptoMethod(Stream stream0, string string0)
		{
			var memoryStream = new MemoryStream();
			CryptoMethod(stream0, memoryStream, string0);
			return memoryStream.ToArray();
		}

		public static void smethod_6(byte[] byte1, Stream stream0, byte[] key, byte[] initializationVector)
		{
			if ((key.Length != 16 && key.Length != 24 && key.Length != 32) || initializationVector.Length != 16)
			{
				return;
			}
			var rijndael = Rijndael.Create();
			rijndael.Key = key;
			rijndael.IV = initializationVector;
			var cryptoStream = new CryptoStream(stream0, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(byte1, 0, byte1.Length);
			cryptoStream.Close();
		}

		public static void smethod_7(byte[] byte1, Stream stream0, string string0)
		{
			var passwordDeriveBytes = new PasswordDeriveBytes(string0, PwByteArray);
			smethod_6(byte1, stream0, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
		}

		public static byte[] smethod_8(byte[] byte1, string string0)
		{
			var memoryStream = new MemoryStream();
			smethod_7(byte1, memoryStream, string0);
			return memoryStream.ToArray();
		}

		public static void WriteAllBytes(string fileName, byte[] bytes)
		{
			if (File.Exists(fileName) && (File.GetAttributes(fileName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				File.SetAttributes(fileName, FileAttributes.Normal);
			}
			File.WriteAllBytes(fileName, bytes);
		}

		public static string smethod_10(string string0)
		{
			var length = string0.LastIndexOfAny(new[] { '\\', '/' }) + 1;
			return string0.Substring(0, length);
		}

		public static string GetFileName(string path, int dotsInExtension)
		{
			var i = path.LastIndexOfAny(new[] { '\\', '/' }) + 1;
			var text = path.Substring(i);
			try
			{
				if (dotsInExtension == -1)
				{
					text = text.Substring(0, text.IndexOf('.'));
				}
				else
				{
					for (i = 0; i < dotsInExtension; i++)
					{
						text = text.Substring(0, text.LastIndexOf('.'));
					}
				}
			}
			catch
			{
			}
			return text;
		}

		public static string GetFileNameNoExt(string path)
		{
			return GetFileName(path, -1);
		}

		public static string GetFileName(string string0)
		{
			return GetFileName(string0, 0);
		}

		public static string GetExtension(string string0, int int0)
		{
			string result;
			try
			{
				var text = string0.Substring(string0.IndexOf('.') + 1);
				if (int0 != 0)
				{
					var array = text.Split(new[]
					{
						'.'
					}, StringSplitOptions.RemoveEmptyEntries);
					text = array[array.Length - int0];
				}
				result = text;
			}
			catch
			{
				result = "";
			}
			return result;
		}

		public static string OpenOrSaveFile(string title, string filter, bool isOpenDialog, string fileName = "")
		{
		    var fileDialog = isOpenDialog ? (FileDialog) new OpenFileDialog() : new SaveFileDialog();
		    fileDialog.Title = title;
			fileDialog.FileName = fileName;
			fileDialog.CheckPathExists = true;
			if (!filter.Equals(""))
			{
				fileDialog.Filter = filter;
			}
			return fileDialog.ShowDialog() == DialogResult.OK ? fileDialog.FileName : "";
		}

		public static string OpenFile(string title, string filter)
		{
			return OpenOrSaveFile(title, filter, true);
		}

		public static List<string> CheckFile(string string0, string string1, bool bool2)
		{
			var array = string1.Split(new[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries);
			var fileList = new List<string>();
			var array2 = array;
			foreach (var searchPattern in array2)
			{
			    fileList.AddRange(Directory.GetFiles(string0, searchPattern, bool2 ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories));
			}
			return fileList;
		}

		public static void smethod_19(string string0, string string1, bool bool2)
		{
			if (string0.ToLower().Equals(string1.ToLower()))
			{
				return;
			}
			if (bool2 && File.Exists(string1) && (File.GetAttributes(string1) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				File.SetAttributes(string1, FileAttributes.Normal);
			}
			File.Copy(string0, string1, bool2);
		}

		public static void smethod_20(string string0)
		{
			if (File.Exists(string0))
			{
				if ((File.GetAttributes(string0) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
				{
					File.SetAttributes(string0, FileAttributes.Normal);
				}
				File.Delete(string0);
			}
		}

		public static int[] smethod_21(ICollection<byte> icollection0)
		{
			return smethod_22(new List<byte>(icollection0));
		}

		public static int[] smethod_22(List<byte> list0)
		{
			var array = new int[list0.Count / 4];
			for (var i = 0; i < array.Length; i++)
			{
				array[i] = smethod_25(list0.GetRange(i * 4, 4).ToArray());
			}
			return array;
		}

		public static int HexStringToInt(string hexidecimalInteger)
		{
			return Convert.ToInt32(hexidecimalInteger.Replace(" ", ""), 16);
		}

		public static int smethod_24(byte[] byte1, bool bool2)
		{
			if (!(bool2 ^ BitConverter.IsLittleEndian))
			{
				return BytesToInt(byte1);
			}
			var num = byte1.Length;
			switch (num)
			{
			case 2:
				return BitConverter.ToInt16(byte1, 0);
			case 3:
				break;
			case 4:
				return BitConverter.ToInt32(byte1, 0);
			default:
				if (num == 8) //i am pretty sure this should just be another switch case but I'm not going to touch it for now
				{
					return (int)BitConverter.ToInt64(byte1, 0);
				}
				break;
			}
			throw new Exception();
		}

		public static int smethod_25(byte[] byte1)
		{
			return smethod_24(byte1, Flag0);
		}

		public static int ReverseEndianness(int int0)
		{
			return (int0 >> 24 & 255) | (int0 >> 8 & 65280) | (int0 << 8 & 16711680) | (int0 << 24 & -16777216);
		}

		public static short BytesToShort(byte[] byte1)
		{
			short num = 0;
			var num2 = Math.Min(2, byte1.Length);
			for (var i = 0; i < num2; i++)
			{
				num |= (short)(byte1[i] << 8 - 8 * i);
			}
			return num;
		}

		public static int BytesToInt(byte[] byte1)
		{
			var num = 0;
			var num2 = Math.Min(4, byte1.Length);
			for (var i = 0; i < num2; i++)
			{
				num |= byte1[i] << 24 - 8 * i;
			}
			return num;
		}

		public static byte[] IntToBytes(int int0)
		{
			return new[]
			{
				(byte)(int0 >> 24 & 255),
				(byte)(int0 >> 16 & 255),
				(byte)(int0 >> 8 & 255),
				(byte)(int0 & 255)
			};
		}

		public static byte[] ReadBytes(string path)
		{
			return File.ReadAllBytes(path);
		}

		public static byte[] ReadBytes(Stream stream0)
		{
			var binaryReader = new BinaryReader(stream0);
			var result = binaryReader.ReadBytes((int)stream0.Length);
			binaryReader.Close();
			return result;
		}

		public static byte[] smethod_32(int int0, bool bool2)
		{
			if (!(bool2 ^ BitConverter.IsLittleEndian))
			{
				return IntToBytes(int0);
			}
			return BitConverter.GetBytes(int0);
		}

		public static byte[] StringToBytes(string string0)
		{
			return Encoding.Default.GetBytes(string0);
		}

		public static string ValToHex32Bit(int int0)
		{
			return ValToPaddedHex(int0, 4);
		}

		public static string ValToPaddedHex(int val, int halfPadding)
		{
			var text = val.ToString("x");
			while (text.Length < halfPadding * 2)
			{
				text = "0" + text;
			}
			return text;
		}

		public static int GetQbKey(string text, bool negativeCrc = true)
		{
            //bool_0 is always false;
			return GetQbKey(new MemoryStream(StringToBytes(text)), negativeCrc, Flag0);
		}

		public static int GetQbKey(byte[] byte1, bool bool2)
		{
			return GetQbKey(new MemoryStream(byte1), bool2, Flag0);
		}

		public static int GetQbKey(Stream stream, bool negateCrc, bool reverseEndianness)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				throw new ArgumentException("stream is not readable.");
			}
			stream.Position = 0L;
			ResetKey();
			var array = new byte[4096];
			int int_;
			while ((int_ = stream.Read(array, 0, array.Length)) != 0)
			{
				CrcVerifyMethod1(array, 0, int_);
			}
			stream.Position = 0L;
			if (negateCrc && reverseEndianness)
			{
                return ReverseEndianness((int)(_key ^ 4294967295u));
			}
			if (negateCrc)
			{
                return (int)(_key ^ 4294967295u);
			}
			if (reverseEndianness)
			{
				return ReverseEndianness((int)_key);
			}
			return (int)_key;
		}

		public static int GetQbKey(Stream stream0, bool bool2)
		{
			return GetQbKey(stream0, bool2, Flag0);
		}

		private static void ResetKey()
		{
			_key = 0u;
		}

		private static void CrcVerifyMethod1(byte[] byte1, int int0, int int1)
		{
			if (byte1 == null)
			{
				throw new ArgumentNullException("Crc buffer");
			}
			if (int0 >= 0 && int1 >= 0 && int0 + int1 <= byte1.Length)
			{
				_key ^= XorMask;
				while (--int1 >= 0)
				{
					_key = (Crc32[(int)((UIntPtr)((_key ^ byte1[int0++]) & 255u))] ^ _key >> 8);
				}
				_key ^= XorMask;
				return;
			}
			throw new ArgumentOutOfRangeException("Crc buffer");
		}

		public static byte[] HashStream(string string0)
		{
			return HashStream(File.OpenRead(string0));
		}

		public static byte[] HashStream(Stream stream0)
		{
			return HashStream(SHA512.Create(), stream0);
		}

		public static byte[] HashStream(HashAlgorithm hashAlgorithm0, Stream stream0)
		{
			var result = hashAlgorithm0.ComputeHash(stream0);
			hashAlgorithm0.Clear();
			stream0.Close();
			return result;
		}

		public static FileStream smethod_45(string string0)
		{
			if (File.Exists(string0) && (File.GetAttributes(string0) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				File.SetAttributes(string0, FileAttributes.Normal);
			}
			return File.Create(string0);
		}

		public static void smethod_46(Stream stream0, string string0)
		{
			smethod_47(stream0, smethod_45(string0));
		}

		public static void smethod_47(Stream stream0, Stream stream1)
		{
			var count = 256;
			var buffer = new byte[256];
			if (stream0.CanSeek && stream0.Position != 0L)
			{
				stream0.Position = 0L;
			}
			for (var i = stream0.Read(buffer, 0, count); i > 0; i = stream0.Read(buffer, 0, count))
			{
				stream1.Write(buffer, 0, i);
			}
			stream0.Close();
			stream1.Close();
		}

		public static Bitmap ScaleImageFixedRatio(Image image, Size size)
		{
			return ScaleImageFixedRatio(image, size.Width, size.Height);
		}

		public static Bitmap ScaleImageFixedRatio(Image image, int width, int height)
		{
			var size = ScaleDimensions(image.Width, image.Height, width, height);
			return ScaleImage(image, size.Width, size.Height);
		}

		public static Bitmap ScaleImage(Image image, Size size)
		{
			return ScaleImage(image, size.Width, size.Height);
		}

		public static Bitmap ScaleImage(Image image, int width, int height)
		{
			var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
			var graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			var destRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
			return bitmap;
		}

		private static Size ScaleDimensions(int width1, int height1, int width2, int height2)
		{
			var num = ((decimal)height1) / width1;
			if (height2 > width2)
			{
				width2 = decimal.ToInt32(height2 / num);
			}
			else
			{
				height2 = decimal.ToInt32(num * width2);
			}
			return new Size(width2, height2);
		}

		public static bool smethod_53<T>(ICollection<T> icollection0, ICollection<T> icollection1) where T : IComparable
		{
			return smethod_54(icollection0, icollection1, Math.Max(icollection0.Count, icollection1.Count));
		}

		public static bool smethod_54<T>(ICollection<T> icollection0, ICollection<T> icollection1, int int0) where T : IComparable
		{
			return smethod_55(icollection0, icollection1, int0, false);
		}

		public static bool smethod_55<T>(ICollection<T> icollection0, ICollection<T> icollection1, int int0, bool bool2) where T : IComparable
		{
			if (!bool2 && (int0 > icollection0.Count || int0 > icollection1.Count))
			{
				return false;
			}
			var enumerator = icollection0.GetEnumerator();
			var enumerator2 = icollection1.GetEnumerator();
			enumerator.Reset();
			enumerator2.Reset();
			var num = 0;
			while (num < int0 && enumerator.MoveNext() && enumerator2.MoveNext())
			{
				var current = enumerator.Current;
				if (current.CompareTo(enumerator2.Current) != 0 ^ bool2)
				{
					return false;
				}
				num++;
			}
			return true;
		}

		public static void smethod_56(IList ilist0)
		{
			var arrayList = new ArrayList(ilist0);
			var num = 0;
			while (arrayList.Count != 0)
			{
				var obj = arrayList[Random0.Next(0, arrayList.Count)];
				ilist0[num++] = obj;
				arrayList.Remove(obj);
			}
		}
	}
}
