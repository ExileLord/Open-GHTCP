using ns12;
using System;
using System.Collections.Generic;
using System.IO;

namespace ns13
{
	public static class Class199
	{
		public static void smethod_0(IEnumerable<string> ienumerable_0, string string_0, string string_1, Stream[] stream_0)
		{
			Class199.smethod_1(ienumerable_0, string_0, 9, string_1, stream_0);
		}

		public static void smethod_1(IEnumerable<string> ienumerable_0, string string_0, int int_0, string string_1, Stream[] stream_0)
		{
			if (!Directory.Exists(new FileInfo(string_0).Directory.ToString()))
			{
				throw new ArgumentException("The Path does not exist.");
			}
			Class199.smethod_2(ienumerable_0, File.Create(string_0), int_0, string_1, stream_0);
		}

		public static void smethod_2(IEnumerable<string> ienumerable_0, Stream stream_0, int int_0, string string_0, Stream[] stream_1)
		{
			if (int_0 >= 0 && int_0 <= 9)
			{
				Class192 @class = new Class192();
				Stream23 stream = new Stream23(stream_0);
				stream.method_6(int_0);
				if (string_0 != null)
				{
					stream.method_2(string_0);
				}
				int num = 0;
				using (IEnumerator<string> enumerator = ienumerable_0.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						string current = enumerator.Current;
						Class193 class2 = new Class193(current);
						class2.method_19(DateTime.Now);
						Stream stream2 = stream_1[num++];
						byte[] array;
						if (stream2 is MemoryStream)
						{
							array = (stream2 as MemoryStream).ToArray();
						}
						else
						{
							array = new byte[stream2.Length];
							int num2 = stream2.Read(array, 0, array.Length);
							if (num2 < array.Length)
							{
								Array.Resize<byte>(ref array, num2);
							}
						}
						class2.method_22((long)array.Length);
						@class.vmethod_1();
						@class.vmethod_2(array);
						class2.method_26(@class.vmethod_0());
						stream.method_10(class2);
						stream.Write(array, 0, array.Length);
					}
					goto IL_10D;
				}
				goto IL_102;
				IL_10D:
				stream.vmethod_0();
				stream.Close();
				return;
			}
			IL_102:
			throw new ArgumentException("Invalid compression rate.");
		}

		public static void smethod_3(string ZipFilePath, out byte[] bytes, string FileName, string Password)
		{
			Class199.smethod_7(File.OpenRead(ZipFilePath), out bytes, FileName, Password);
		}

		public static void smethod_4(string string_0, string string_1, string string_2)
		{
			Class199.smethod_9(File.OpenRead(string_0), File.Create(string_1), string_2);
		}

		public static byte[] smethod_5(byte[] byte_0, string string_0)
		{
			return Class199.smethod_6(new MemoryStream(byte_0), string_0);
		}

		public static byte[] smethod_6(Stream stream_0, string string_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			Class199.smethod_9(stream_0, memoryStream, string_0);
			return memoryStream.ToArray();
		}

		public static void smethod_7(Stream StreamIn, out byte[] bytes, string FileName, string Password)
		{
			MemoryStream memoryStream = new MemoryStream();
			Class199.smethod_10(StreamIn, memoryStream, FileName, Password);
			bytes = memoryStream.ToArray();
		}

		public static void smethod_8(Stream stream_0, string string_0, string string_1)
		{
			Class199.smethod_10(stream_0, File.Create(string_0), string_1, null);
		}

		public static void smethod_9(Stream stream_0, Stream stream_1, string string_0)
		{
			Class199.smethod_10(stream_0, stream_1, string_0, null);
		}

		public static void smethod_10(Stream stream_0, Stream stream_1, string string_0, string string_1)
		{
			Stream20 stream = new Stream20(stream_0);
			if (string_1 != null)
			{
				stream.method_3(string_1);
			}
			byte[] array = new byte[2048];
			Class193 @class;
			while ((@class = stream.method_5()) != null)
			{
				if (@class.method_20() == string_0)
				{
					int num;
					do
					{
						num = stream.Read(array, 0, array.Length);
						stream_1.Write(array, 0, num);
					}
					while (num > 0);
					stream.Close();
					stream_1.Close();
					stream_0.Close();
					return;
				}
			}
		}

		public static void smethod_11(string string_0, List<string> list_0, List<string> list_1, string string_1)
		{
			Stream stream = File.OpenRead(string_0);
			Stream20 stream2 = new Stream20(stream);
			if (string_1 != null)
			{
				stream2.method_3(string_1);
			}
			byte[] array = new byte[2048];
			Class193 @class;
			while ((@class = stream2.method_5()) != null)
			{
				if (list_1.Contains(@class.method_20()))
				{
					int index = list_1.IndexOf(@class.method_20());
					using (Stream stream3 = File.Create(list_0[index]))
					{
						if (stream3.CanWrite)
						{
							int num;
							do
							{
								num = stream2.Read(array, 0, array.Length);
								stream3.Write(array, 0, num);
							}
							while (num > 0);
						}
					}
				}
			}
			stream2.Close();
			stream.Close();
		}
	}
}
