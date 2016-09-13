using ns16;
using System;
using System.Collections.Generic;

namespace ns19
{
	public class zzQbSongObject
	{
		public byte[] data;

		public int int_0;

		public string fileName;

		public string[] string_1;

		public zzQbSongObject(string path) : this(KeyGenerator.GetFileName(path, -1).ToLower(), KeyGenerator.ReadBytes(path))
		{
		}

		public zzQbSongObject(string newFileName, byte[] newData)
		{
			this.data = newData;
			List<byte> list = new List<byte>(this.data);
			this.fileName = newFileName;
			this.string_1 = new string[KeyGenerator.smethod_24(list.GetRange(0, 4).ToArray(), true)];
			this.int_0 = KeyGenerator.smethod_24(list.GetRange(4, 4).ToArray(), true);
			string[] array = new string[]
			{
				this.fileName + "_song",
				this.fileName + "_guitar",
				this.fileName + "_preview",
				this.fileName + "_rhythm",
				this.fileName + "_coop_song",
				this.fileName + "_coop_guitar",
				this.fileName + "_coop_rhythm"
			};
			List<int> list2 = new List<int>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				list2.Add(KeyGenerator.GetQbKey(text, true));
			}
			int num = 8;
			for (int j = 0; j < this.string_1.Length; j++)
			{
				int num2 = KeyGenerator.smethod_24(list.GetRange(num, 4).ToArray(), true);
				if (!list2.Contains(num2))
				{
					throw new Exception(string.Concat(new object[]
					{
						"Dat File Corrupted: unperdictable CRC value (",
						num2,
						") for song \"",
						this.fileName,
						"\""
					}));
				}
				this.string_1[KeyGenerator.smethod_24(list.GetRange(num + 4, 4).ToArray(), true)] = array[list2.IndexOf(num2)];
				num += 20;
			}
		}

		public void method_0(string string_2)
		{
			for (int i = 0; i < this.string_1.Length; i++)
			{
				this.string_1[i] = this.string_1[i].Replace(this.fileName, string_2);
			}
			this.fileName = string_2;
			this.method_1();
		}

		public zzQbSongObject(int int_1, string[] string_2)
		{
			this.int_0 = int_1;
			this.string_1 = string_2;
			this.fileName = this.string_1[0].Remove(this.string_1[0].IndexOf('_'));
			this.method_1();
		}

		public void method_1()
		{
			List<byte> list = new List<byte>();
			list.AddRange(KeyGenerator.smethod_32(this.string_1.Length, true));
			list.AddRange(KeyGenerator.smethod_32(this.int_0, true));
			for (int i = 0; i < this.string_1.Length; i++)
			{
				list.AddRange(KeyGenerator.smethod_32(KeyGenerator.GetQbKey(this.string_1[i], true), true));
				list.AddRange(KeyGenerator.smethod_32(i, true));
				for (int j = 0; j < 12; j++)
				{
					list.Add(0);
				}
			}
			this.data = list.ToArray();
		}

		public void method_2(string string_2)
		{
			KeyGenerator.smethod_9(string_2, this.data);
		}
	}
}
