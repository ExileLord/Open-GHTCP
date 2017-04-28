using System;
using System.Collections.Generic;
using System.IO;
using ns12;

namespace ns13
{
	public static class ZipManager
	{
		public static void smethod_0(IEnumerable<string> fileNameList, string saveLocation, string password, Stream[] fileStreamList)
		{
			CheckFileDirectory(fileNameList, saveLocation, 9, password, fileStreamList);
		}

		public static void CheckFileDirectory(IEnumerable<string> fileNameList, string saveLocation, int nine, string password, Stream[] fileStreamList)
		{
			if (!Directory.Exists(new FileInfo(saveLocation).Directory.ToString()))
			{
				throw new ArgumentException("The Path does not exist.");
			}
			ProcessFile(fileNameList, File.Create(saveLocation), nine, password, fileStreamList);
		}

		public static void ProcessFile(IEnumerable<string> fileNameList, Stream zipFile, int compressionAmount, string password, Stream[] fileStreamList)
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

		public static void ExtractBytesFrom(string zipFilePath, out byte[] bytes, string fileName, string password)
		{
			ExtractBytes(File.OpenRead(zipFilePath), out bytes, fileName, password);
		}

		public static void smethod_4(string string0, string string1, string string2)
		{
			smethod_9(File.OpenRead(string0), File.Create(string1), string2);
		}

		public static byte[] smethod_5(byte[] byte0, string string0)
		{
			return smethod_6(new MemoryStream(byte0), string0);
		}

		public static byte[] smethod_6(Stream stream0, string string0)
		{
			var memoryStream = new MemoryStream();
			smethod_9(stream0, memoryStream, string0);
			return memoryStream.ToArray();
		}

		public static void ExtractBytes(Stream streamIn, out byte[] bytes, string fileName, string password)
		{
			var memoryStream = new MemoryStream();
			smethod_10(streamIn, memoryStream, fileName, password);
			bytes = memoryStream.ToArray();
		}

		public static void smethod_8(Stream stream0, string string0, string string1)
		{
			smethod_10(stream0, File.Create(string0), string1, null);
		}

		public static void smethod_9(Stream stream0, Stream stream1, string string0)
		{
			smethod_10(stream0, stream1, string0, null);
		}

		public static void smethod_10(Stream zipFile, Stream memoryStream, string fileName, string password)
		{
            var zipManager = new ZipCompressor(zipFile);
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

		public static void smethod_11(string string0, List<string> list0, List<string> list1, string string1)
		{
			Stream stream = File.OpenRead(string0);
            var stream2 = new ZipCompressor(stream);
			if (string1 != null)
			{
				stream2.method_3(string1);
			}
			var array = new byte[2048];
			Class193 @class;
			while ((@class = stream2.method_5()) != null)
			{
				if (list1.Contains(@class.method_20()))
				{
					var index = list1.IndexOf(@class.method_20());
					using (Stream stream3 = File.Create(list0[index]))
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
