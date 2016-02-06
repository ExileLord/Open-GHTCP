using ns0;
using ns1;
using ns11;
using ns3;
using ns4;
using ns5;
using ns6;
using ns7;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns8
{
	public class Class170 : IDisposable
	{
		private List<Interface6> list_0;

		public Class170()
		{
			this.list_0 = new List<Interface6>();
		}

		public static Interface6 smethod_0(Enum25 enum25_0, Stream1 stream1_0)
		{
			switch (enum25_0)
			{
			case Enum25.const_1:
				return new Class163(stream1_0);
			case Enum25.const_2:
				return new Class155(stream1_0);
			case Enum25.const_3:
				return new Class163(stream1_0);
			case Enum25.const_5:
				return new Class163(stream1_0);
			}
			bool flag = Type.GetType("Mono.Runtime") != null;
			int platform = (int)Environment.OSVersion.Platform;
			switch (platform)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			{
				Interface6 result;
				try
				{
					result = new Class163(stream1_0);
				}
				catch
				{
					result = new Class109(stream1_0);
				}
				return result;
			}
			case 4:
			case 6:
				goto IL_F4;
			case 5:
				break;
			default:
				if (platform == 128)
				{
					goto IL_F4;
				}
				break;
			}
			throw new PlatformNotSupportedException(string.Concat(new object[]
			{
				flag ? "" : "Not ",
				"Running Mono. PlatformID: ",
				(int)Environment.OSVersion.Platform,
				" | ",
				Environment.OSVersion.Platform
			}));
			IL_F4:
			return new Class117(stream1_0);
		}

		public static Enum24 smethod_1(string string_0)
		{
			FileInfo fileInfo = new FileInfo(string_0);
			string key;
			switch (key = fileInfo.Extension.ToLower())
			{
			case ".mp3":
				return Enum24.const_1;
			case ".ogg":
				return Enum24.const_2;
			case ".wav":
				return Enum24.const_3;
			case ".flac":
				return Enum24.const_4;
			case ".ac3":
				return Enum24.const_5;
			case ".fsb":
				return Enum24.const_6;
			case ".vgs":
				return Enum24.const_7;
			case ".vag":
				return Enum24.const_8;
			case ".msv":
				return Enum24.const_9;
			case ".imf":
				return Enum24.const_10;
			}
			return Enum24.const_0;
		}

		public static Class16 smethod_2(string string_0)
		{
			Class16 result;
			using (Stream1 stream = Class170.smethod_4(string_0))
			{
				result = stream.vmethod_1();
			}
			return result;
		}

		public static Class16 smethod_3(Stream stream_0)
		{
			long position = stream_0.Position;
			Class16 result;
			try
			{
				result = Class170.smethod_5(stream_0).vmethod_1();
			}
			finally
			{
				stream_0.Position = position;
			}
			return result;
		}

		public static Stream1 smethod_4(string string_0)
		{
			FileInfo fileInfo = new FileInfo(string_0);
			string a;
			if ((a = fileInfo.Extension.ToLower()) != null)
			{
				if (a == ".mp3")
				{
					return new Stream9(string_0);
				}
				if (a == ".ogg")
				{
					return new Stream7(string_0);
				}
				if (a == ".wav")
				{
					return new Stream11(string_0);
				}
				if (a == ".flac")
				{
					return new Stream12(string_0);
				}
				if (a == ".ac3")
				{
					return new Stream10(string_0);
				}
				if (a == ".fsb")
				{
					return new Stream13(string_0);
				}
			}
			throw new NotSupportedException("Audio Engine: " + string_0);
		}

		public static Stream1 smethod_5(Stream stream_0)
		{
			long position = stream_0.Position;
			byte[] array = new byte[4];
			stream_0.Read(array, 0, 4);
			stream_0.Position = position;
			if (array[0] == 255 && array[1] >= 240)
			{
				return new Stream9(stream_0);
			}
			if (array[0] == 11 && array[1] == 119)
			{
				return new Stream10(stream_0);
			}
			string @string;
			if ((@string = Encoding.UTF8.GetString(array, 0, 3)) != null)
			{
				if (@string == "Ogg")
				{
					return new Stream7(stream_0);
				}
				if (@string == "RIF")
				{
					return new Stream11(stream_0);
				}
				if (@string == "ID3")
				{
					return new Stream9(stream_0);
				}
				if (@string == "fLa")
				{
					return new Stream12(stream_0);
				}
				if (@string == "FSB")
				{
					return new Stream13(stream_0);
				}
			}
			try
			{
				return new Stream13(stream_0);
			}
			catch
			{
				stream_0.Position = position;
			}
			throw new NotSupportedException("Audio Engine: " + stream_0);
		}

		~Class170()
		{
			this.method_0(false);
		}

		public void method_0(bool bool_0)
		{
			foreach (Interface6 current in this.list_0)
			{
				current.Dispose();
			}
		}

		public void Dispose()
		{
			this.method_0(true);
			GC.SuppressFinalize(this);
		}
	}
}
