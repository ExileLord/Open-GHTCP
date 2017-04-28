using System;
using System.Collections.Generic;
using System.IO;
using ns12;

namespace ns13
{
	public static class ZIPManager
	{
		public static void smethod_0(IEnumerable<string> fileNameList, string saveLocation, string password, Stream[] fileStreamList)
		{
			checkFileDirectory(fileNameList, saveLocation, 9, password, fileStreamList);
		}

		public static void checkFileDirectory(IEnumerable<string> fileNameList, string saveLocation, int nine, string password, Stream[] fileStreamList)
		{
			if (!Directory.Exists(new FileInfo(saveLocation).Directory.ToString()))
			{
				throw new ArgumentException("The Path does not exist.");
			}
			processFile(fileNameList, File.Create(saveLocation), nine, password, fileStreamList);
		}

		public static void processFile(IEnumerable<string> fileNameList, Stream zipFile, int compressionAmount, string password, Stream[] fileStreamList)
		{
			if (compressionAmount >= 0 && compressionAmount <= 9)
			{
				var @class = new Class192();
				var stream = new Stream23(zipFile);
				stream.method_6(compressionAmount);
				if (password != null)
				{
					stream.method_2(password);
				}
				var num = 0;
				using (var enumerator = fileNameList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						var current = enumerator.Current;
						var class2 = new Class193(current);
						class2.method_19(DateTime.Now);
						var stream2 = fileStreamList[num++];
						byte[] array;
						if (stream2 is MemoryStream)
						{
							array = (stream2 as MemoryStream).ToArray();
						}
						else
						{
							array = new byte[stream2.Length];
							var num2 = stream2.Read(array, 0, array.Length);
							if (num2 < array.Length)
							{
								Array.Resize(ref array, num2);
							}
						}
						class2.method_22(array.Length);
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
			smethod_7(File.OpenRead(ZipFilePath), out bytes, FileName, Password);
		}

		public static void smethod_4(string string_0, string string_1, string string_2)
		{
			smethod_9(File.OpenRead(string_0), File.Create(string_1), string_2);
		}

		public static byte[] smethod_5(byte[] byte_0, string string_0)
		{
			return smethod_6(new MemoryStream(byte_0), string_0);
		}

		public static byte[] smethod_6(Stream stream_0, string string_0)
		{
			var memoryStream = new MemoryStream();
			smethod_9(stream_0, memoryStream, string_0);
			return memoryStream.ToArray();
		}

		public static void smethod_7(Stream StreamIn, out byte[] bytes, string FileName, string Password)
		{
			var memoryStream = new MemoryStream();
			smethod_10(StreamIn, memoryStream, FileName, Password);
			bytes = memoryStream.ToArray();
		}

		public static void smethod_8(Stream stream_0, string string_0, string string_1)
		{
			smethod_10(stream_0, File.Create(string_0), string_1, null);
		}

		public static void smethod_9(Stream stream_0, Stream stream_1, string string_0)
		{
			smethod_10(stream_0, stream_1, string_0, null);
		}

		public static void smethod_10(Stream zipFile, Stream memoryStream, string fileName, string password)
		{
            var zipManager = new ZIPCompressor(zipFile);
			if (password != null)
			{
				zipManager.method_3(password);
			}
			var buffer = new byte[2048];
			Class193 @class;
			while ((@class = zipManager.method_5()) != null)
			{
				if (@class.method_20() == fileName)
				{
					int num;
					do
					{
						num = zipManager.Read(buffer, 0, buffer.Length);
						memoryStream.Write(buffer, 0, num);
					}
					while (num > 0);
					zipManager.Close();
					memoryStream.Close();
					zipFile.Close();
					return;
				}
			}
		}

		public static void smethod_11(string string_0, List<string> list_0, List<string> list_1, string string_1)
		{
			Stream stream = File.OpenRead(string_0);
            var stream2 = new ZIPCompressor(stream);
			if (string_1 != null)
			{
				stream2.method_3(string_1);
			}
			var array = new byte[2048];
			Class193 @class;
			while ((@class = stream2.method_5()) != null)
			{
				if (list_1.Contains(@class.method_20()))
				{
					var index = list_1.IndexOf(@class.method_20());
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
