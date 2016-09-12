using ns16;
using System;
using System.Collections.Generic;

namespace ns19
{
	public class Class323
	{
		public byte[] byte_0;

		public int int_0;

		public string string_0;

		public string[] string_1;

		public Class323(string string_2) : this(KeyGenerator.smethod_11(string_2, -1).ToLower(), KeyGenerator.smethod_30(string_2))
		{
		}

		public Class323(string string_2, byte[] byte_1)
		{
			this.byte_0 = byte_1;
			List<byte> list = new List<byte>(this.byte_0);
			this.string_0 = string_2;
			this.string_1 = new string[KeyGenerator.smethod_24(list.GetRange(0, 4).ToArray(), true)];
			this.int_0 = KeyGenerator.smethod_24(list.GetRange(4, 4).ToArray(), true);
			string[] array = new string[]
			{
				this.string_0 + "_song",
				this.string_0 + "_guitar",
				this.string_0 + "_preview",
				this.string_0 + "_rhythm",
				this.string_0 + "_coop_song",
				this.string_0 + "_coop_guitar",
				this.string_0 + "_coop_rhythm"
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
						this.string_0,
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
				this.string_1[i] = this.string_1[i].Replace(this.string_0, string_2);
			}
			this.string_0 = string_2;
			this.method_1();
		}

		public Class323(int int_1, string[] string_2)
		{
			this.int_0 = int_1;
			this.string_1 = string_2;
			this.string_0 = this.string_1[0].Remove(this.string_1[0].IndexOf('_'));
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
			this.byte_0 = list.ToArray();
		}

		public void method_2(string string_2)
		{
			KeyGenerator.smethod_9(string_2, this.byte_0);
		}
	}
}
