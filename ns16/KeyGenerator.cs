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

namespace ns16
{
	public class KeyGenerator
	{
		public static bool bool_0 = false;

		public static bool bool_1 = false;

        //Who the hell is Ivan Medvedev
		private static readonly byte[] pwByteArray = new byte[] //seed?
		{
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

		private static uint uint_0 = 0u;

		private static readonly uint xorMask = 4294967295u;

		public static readonly uint[] crc32 = new uint[]
		{
			0u,
			1996959894u,
			3993919788u,
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

		private static Random random_0 = new Random();

		public static void smethod_0(Stream stream_0, Stream stream_1, byte[] byte_1, byte[] byte_2)
		{
			if ((byte_1.Length != 16 && byte_1.Length != 24 && byte_1.Length != 32) || byte_2.Length != 16)
			{
				return;
			}
			Rijndael rijndael = Rijndael.Create();
			rijndael.Key = byte_1;
			rijndael.IV = byte_2;
			CryptoStream cryptoStream = new CryptoStream(stream_1, rijndael.CreateEncryptor(), CryptoStreamMode.Write);
			byte[] array = new byte[4096];
			int count;
			while ((count = stream_0.Read(array, 0, array.Length)) > 0)
			{
				cryptoStream.Write(array, 0, count);
			}
			cryptoStream.Close();
		}

		public static void smethod_1(Stream stream_0, Stream stream_1, string string_0)
		{
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(string_0, KeyGenerator.pwByteArray);
			KeyGenerator.smethod_0(stream_0, stream_1, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
		}

		public static byte[] smethod_2(Stream stream_0, string string_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			KeyGenerator.smethod_1(stream_0, memoryStream, string_0);
			return memoryStream.ToArray();
		}

		public static void smethod_3(Stream stream_0, Stream stream_1, byte[] byte_1, byte[] byte_2)
		{
			if ((byte_1.Length != 16 && byte_1.Length != 24 && byte_1.Length != 32) || byte_2.Length != 16)
			{
				return;
			}
			Rijndael rijndael = Rijndael.Create();
			rijndael.Key = byte_1;
			rijndael.IV = byte_2;
			CryptoStream cryptoStream = new CryptoStream(stream_1, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
			byte[] array = new byte[4096];
			int count;
			while ((count = stream_0.Read(array, 0, array.Length)) > 0)
			{
				cryptoStream.Write(array, 0, count);
			}
			cryptoStream.Close();
		}

		public static void smethod_4(Stream stream_0, Stream stream_1, string string_0)
		{
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(string_0, KeyGenerator.pwByteArray);
			KeyGenerator.smethod_3(stream_0, stream_1, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
		}

		public static byte[] smethod_5(Stream stream_0, string string_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			KeyGenerator.smethod_4(stream_0, memoryStream, string_0);
			return memoryStream.ToArray();
		}

		public static void smethod_6(byte[] byte_1, Stream stream_0, byte[] key, byte[] initializationVector)
		{
			if ((key.Length != 16 && key.Length != 24 && key.Length != 32) || initializationVector.Length != 16)
			{
				return;
			}
			Rijndael rijndael = Rijndael.Create();
			rijndael.Key = key;
			rijndael.IV = initializationVector;
			CryptoStream cryptoStream = new CryptoStream(stream_0, rijndael.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(byte_1, 0, byte_1.Length);
			cryptoStream.Close();
		}

		public static void smethod_7(byte[] byte_1, Stream stream_0, string string_0)
		{
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(string_0, KeyGenerator.pwByteArray);
			KeyGenerator.smethod_6(byte_1, stream_0, passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
		}

		public static byte[] smethod_8(byte[] byte_1, string string_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			KeyGenerator.smethod_7(byte_1, memoryStream, string_0);
			return memoryStream.ToArray();
		}

		public static void smethod_9(string string_0, byte[] byte_1)
		{
			if (File.Exists(string_0) && (File.GetAttributes(string_0) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				File.SetAttributes(string_0, FileAttributes.Normal);
			}
			File.WriteAllBytes(string_0, byte_1);
		}

		public static string smethod_10(string string_0)
		{
			int length = string_0.LastIndexOfAny(new char[]
			{
				'\\',
				'/'
			}) + 1;
			return string_0.Substring(0, length);
		}

		public static string smethod_11(string string_0, int int_0)
		{
			int i = string_0.LastIndexOfAny(new char[]
			{
				'\\',
				'/'
			}) + 1;
			string text = string_0.Substring(i);
			try
			{
				if (int_0 == -1)
				{
					text = text.Substring(0, text.IndexOf('.'));
				}
				else
				{
					for (i = 0; i < int_0; i++)
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

		public static string smethod_12(string string_0)
		{
			return KeyGenerator.smethod_11(string_0, -1);
		}

		public static string smethod_13(string string_0)
		{
			return KeyGenerator.smethod_11(string_0, 0);
		}

		public static string smethod_14(string string_0, int int_0)
		{
			string result;
			try
			{
				string text = string_0.Substring(string_0.IndexOf('.') + 1);
				if (int_0 != 0)
				{
					string[] array = text.Split(new char[]
					{
						'.'
					}, StringSplitOptions.RemoveEmptyEntries);
					text = array[array.Length - int_0];
				}
				result = text;
			}
			catch
			{
				result = "";
			}
			return result;
		}

		public static string smethod_15(string string_0, string string_1, bool bool_2, string string_2)
		{
			FileDialog fileDialog;
			if (bool_2)
			{
				fileDialog = new OpenFileDialog();
			}
			else
			{
				fileDialog = new SaveFileDialog();
			}
			fileDialog.Title = string_0;
			fileDialog.FileName = string_2;
			fileDialog.CheckPathExists = true;
			if (!string_1.Equals(""))
			{
				fileDialog.Filter = string_1;
			}
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				return fileDialog.FileName;
			}
			return "";
		}

		public static string smethod_16(string string_0, string string_1, bool bool_2)
		{
			return KeyGenerator.smethod_15(string_0, string_1, bool_2, "");
		}

		public static string smethod_17(string string_0, string string_1)
		{
			return KeyGenerator.smethod_16(string_0, string_1, true);
		}

		public static List<string> checkFile(string string_0, string string_1, bool bool_2)
		{
			string[] array = string_1.Split(new char[]
			{
				';'
			}, StringSplitOptions.RemoveEmptyEntries);
			List<string> fileList = new List<string>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string searchPattern = array2[i];
				fileList.AddRange(Directory.GetFiles(string_0, searchPattern, bool_2 ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories));
			}
			return fileList;
		}

		public static void smethod_19(string string_0, string string_1, bool bool_2)
		{
			if (string_0.ToLower().Equals(string_1.ToLower()))
			{
				return;
			}
			if (bool_2 && File.Exists(string_1) && (File.GetAttributes(string_1) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				File.SetAttributes(string_1, FileAttributes.Normal);
			}
			File.Copy(string_0, string_1, bool_2);
		}

		public static void smethod_20(string string_0)
		{
			if (File.Exists(string_0))
			{
				if ((File.GetAttributes(string_0) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
				{
					File.SetAttributes(string_0, FileAttributes.Normal);
				}
				File.Delete(string_0);
			}
		}

		public static int[] smethod_21(ICollection<byte> icollection_0)
		{
			return KeyGenerator.smethod_22(new List<byte>(icollection_0));
		}

		public static int[] smethod_22(List<byte> list_0)
		{
			int[] array = new int[list_0.Count / 4];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = KeyGenerator.smethod_25(list_0.GetRange(i * 4, 4).ToArray());
			}
			return array;
		}

		public static int smethod_23(string string_0)
		{
			return Convert.ToInt32(string_0.Replace(" ", ""), 16);
		}

		public static int smethod_24(byte[] byte_1, bool bool_2)
		{
			if (!(bool_2 ^ BitConverter.IsLittleEndian))
			{
				return KeyGenerator.smethod_28(byte_1);
			}
			int num = byte_1.Length;
			switch (num)
			{
			case 2:
				return (int)BitConverter.ToInt16(byte_1, 0);
			case 3:
				break;
			case 4:
				return BitConverter.ToInt32(byte_1, 0);
			default:
				if (num == 8)
				{
					return (int)BitConverter.ToInt64(byte_1, 0);
				}
				break;
			}
			throw new Exception();
		}

		public static int smethod_25(byte[] byte_1)
		{
			return KeyGenerator.smethod_24(byte_1, KeyGenerator.bool_0);
		}

		public static int smethod_26(int int_0)
		{
			return (int_0 >> 24 & 255) | (int_0 >> 8 & 65280) | (int_0 << 8 & 16711680) | (int_0 << 24 & -16777216);
		}

		public static short smethod_27(byte[] byte_1)
		{
			short num = 0;
			int num2 = Math.Min(2, byte_1.Length);
			for (int i = 0; i < num2; i++)
			{
				num |= (short)(byte_1[i] << 8 - 8 * i);
			}
			return num;
		}

		public static int smethod_28(byte[] byte_1)
		{
			int num = 0;
			int num2 = Math.Min(4, byte_1.Length);
			for (int i = 0; i < num2; i++)
			{
				num |= (int)byte_1[i] << 24 - 8 * i;
			}
			return num;
		}

		public static byte[] smethod_29(int int_0)
		{
			return new byte[]
			{
				(byte)(int_0 >> 24 & 255),
				(byte)(int_0 >> 16 & 255),
				(byte)(int_0 >> 8 & 255),
				(byte)(int_0 & 255)
			};
		}

		public static byte[] smethod_30(string string_0)
		{
			return File.ReadAllBytes(string_0);
		}

		public static byte[] smethod_31(Stream stream_0)
		{
			BinaryReader binaryReader = new BinaryReader(stream_0);
			byte[] result = binaryReader.ReadBytes((int)stream_0.Length);
			binaryReader.Close();
			return result;
		}

		public static byte[] smethod_32(int int_0, bool bool_2)
		{
			if (!(bool_2 ^ BitConverter.IsLittleEndian))
			{
				return KeyGenerator.smethod_29(int_0);
			}
			return BitConverter.GetBytes(int_0);
		}

		public static byte[] stringToBytes(string string_0)
		{
			return Encoding.Default.GetBytes(string_0);
		}

		public static string smethod_34(int int_0)
		{
			return KeyGenerator.smethod_35(int_0, 4);
		}

		public static string smethod_35(int int_0, int int_1)
		{
			string text = int_0.ToString("x");
			while (text.Length < int_1 * 2)
			{
				text = "0" + text;
			}
			return text;
		}

		public static int GetQbKey(string gbName, bool alwaysTrue)
		{
            //bool_0 is always false;
			return KeyGenerator.GetQbKey(new MemoryStream(KeyGenerator.stringToBytes(gbName)), alwaysTrue, KeyGenerator.bool_0);
		}

		public static int GetQbKey(byte[] byte_1, bool bool_2)
		{
			return KeyGenerator.GetQbKey(new MemoryStream(byte_1), bool_2, KeyGenerator.bool_0);
		}

		public static int GetQbKey(Stream stream_0, bool bool_2, bool bool_3)
		{
			if (stream_0 == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream_0.CanRead)
			{
				throw new ArgumentException("stream is not readable.");
			}
			stream_0.Position = 0L;
			KeyGenerator.smethod_40();
			byte[] array = new byte[4096];
			int int_;
			while ((int_ = stream_0.Read(array, 0, array.Length)) != 0)
			{
				KeyGenerator.CrcVerifyMethod1(array, 0, int_);
			}
			stream_0.Position = 0L;
			if (bool_2 && bool_3)
			{
                return KeyGenerator.smethod_26((int)(KeyGenerator.uint_0 ^ 4294967295u));
			}
			if (bool_2)
			{
                return (int)(KeyGenerator.uint_0 ^ 4294967295u);
			}
			if (bool_3)
			{
				return KeyGenerator.smethod_26((int)KeyGenerator.uint_0);
			}
			return (int)KeyGenerator.uint_0;
		}

		public static int GetQbKey(Stream stream_0, bool bool_2)
		{
			return KeyGenerator.GetQbKey(stream_0, bool_2, KeyGenerator.bool_0);
		}

		private static void smethod_40()
		{
			KeyGenerator.uint_0 = 0u;
		}

		private static void CrcVerifyMethod1(byte[] byte_1, int int_0, int int_1)
		{
			if (byte_1 == null)
			{
				throw new ArgumentNullException("Crc buffer");
			}
			if (int_0 >= 0 && int_1 >= 0 && int_0 + int_1 <= byte_1.Length)
			{
				KeyGenerator.uint_0 ^= KeyGenerator.xorMask;
				while (--int_1 >= 0)
				{
					KeyGenerator.uint_0 = (KeyGenerator.crc32[(int)((UIntPtr)((KeyGenerator.uint_0 ^ (uint)byte_1[int_0++]) & 255u))] ^ KeyGenerator.uint_0 >> 8);
				}
				KeyGenerator.uint_0 ^= KeyGenerator.xorMask;
				return;
			}
			throw new ArgumentOutOfRangeException("Crc buffer");
		}

		public static byte[] smethod_42(string string_0)
		{
			return KeyGenerator.smethod_43(File.OpenRead(string_0));
		}

		public static byte[] smethod_43(Stream stream_0)
		{
			return KeyGenerator.smethod_44(SHA512.Create(), stream_0);
		}

		public static byte[] smethod_44(HashAlgorithm hashAlgorithm_0, Stream stream_0)
		{
			byte[] result = hashAlgorithm_0.ComputeHash(stream_0);
			hashAlgorithm_0.Clear();
			stream_0.Close();
			return result;
		}

		public static FileStream smethod_45(string string_0)
		{
			if (File.Exists(string_0) && (File.GetAttributes(string_0) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
			{
				File.SetAttributes(string_0, FileAttributes.Normal);
			}
			return File.Create(string_0);
		}

		public static void smethod_46(Stream stream_0, string string_0)
		{
			KeyGenerator.smethod_47(stream_0, KeyGenerator.smethod_45(string_0));
		}

		public static void smethod_47(Stream stream_0, Stream stream_1)
		{
			int count = 256;
			byte[] buffer = new byte[256];
			if (stream_0.CanSeek && stream_0.Position != 0L)
			{
				stream_0.Position = 0L;
			}
			for (int i = stream_0.Read(buffer, 0, count); i > 0; i = stream_0.Read(buffer, 0, count))
			{
				stream_1.Write(buffer, 0, i);
			}
			stream_0.Close();
			stream_1.Close();
		}

		public static Bitmap smethod_48(Image image_0, Size size_0)
		{
			return KeyGenerator.smethod_49(image_0, size_0.Width, size_0.Height);
		}

		public static Bitmap smethod_49(Image image_0, int int_0, int int_1)
		{
			Size size = KeyGenerator.smethod_52(image_0.Width, image_0.Height, int_0, int_1);
			return KeyGenerator.smethod_51(image_0, size.Width, size.Height);
		}

		public static Bitmap smethod_50(Image image_0, Size size_0)
		{
			return KeyGenerator.smethod_51(image_0, size_0.Width, size_0.Height);
		}

		public static Bitmap smethod_51(Image image_0, int int_0, int int_1)
		{
			Bitmap bitmap = new Bitmap(int_0, int_1, PixelFormat.Format32bppArgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			Rectangle destRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
			graphics.DrawImage(image_0, destRect, 0, 0, image_0.Width, image_0.Height, GraphicsUnit.Pixel);
			return bitmap;
		}

		public static Size smethod_52(int int_0, int int_1, int int_2, int int_3)
		{
			decimal num = int_1 / int_0;
			if (int_3 > int_2)
			{
				int_2 = decimal.ToInt32(int_3 / num);
			}
			else
			{
				int_3 = decimal.ToInt32(num * int_2);
			}
			return new Size(int_2, int_3);
		}

		public static bool smethod_53<T>(ICollection<T> icollection_0, ICollection<T> icollection_1) where T : IComparable
		{
			return KeyGenerator.smethod_54<T>(icollection_0, icollection_1, Math.Max(icollection_0.Count, icollection_1.Count));
		}

		public static bool smethod_54<T>(ICollection<T> icollection_0, ICollection<T> icollection_1, int int_0) where T : IComparable
		{
			return KeyGenerator.smethod_55<T>(icollection_0, icollection_1, int_0, false);
		}

		public static bool smethod_55<T>(ICollection<T> icollection_0, ICollection<T> icollection_1, int int_0, bool bool_2) where T : IComparable
		{
			if (!bool_2 && (int_0 > icollection_0.Count || int_0 > icollection_1.Count))
			{
				return false;
			}
			IEnumerator<T> enumerator = icollection_0.GetEnumerator();
			IEnumerator<T> enumerator2 = icollection_1.GetEnumerator();
			enumerator.Reset();
			enumerator2.Reset();
			int num = 0;
			while (num < int_0 && enumerator.MoveNext() && enumerator2.MoveNext())
			{
				T current = enumerator.Current;
				if (current.CompareTo(enumerator2.Current) != 0 ^ bool_2)
				{
					return false;
				}
				num++;
			}
			return true;
		}

		public static void smethod_56(IList ilist_0)
		{
			ArrayList arrayList = new ArrayList(ilist_0);
			int num = 0;
			while (arrayList.Count != 0)
			{
				object obj = arrayList[KeyGenerator.random_0.Next(0, arrayList.Count)];
				ilist_0[num++] = obj;
				arrayList.Remove(obj);
			}
		}
	}
}
