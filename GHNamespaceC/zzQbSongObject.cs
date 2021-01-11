using System;
using System.Collections.Generic;
using GHNamespace9;

namespace GHNamespaceC
{
    public class ZzQbSongObject
    {
        public byte[] Data;

        public int Int0;

        public string FileName;

        public string[] String1;

        public ZzQbSongObject(string path) : this(KeyGenerator.GetFileName(path, -1).ToLower(),
            KeyGenerator.ReadBytes(path))
        {
        }

        public ZzQbSongObject(string newFileName, byte[] newData)
        {
            Data = newData;
            List<byte> list = new List<byte>(Data);
            FileName = newFileName;
            String1 = new string[KeyGenerator.smethod_24(list.GetRange(0, 4).ToArray(), true)];
            Int0 = KeyGenerator.smethod_24(list.GetRange(4, 4).ToArray(), true);
            string[] array =
            {
                FileName + "_song",
                FileName + "_guitar",
                FileName + "_preview",
                FileName + "_rhythm",
                FileName + "_coop_song",
                FileName + "_coop_guitar",
                FileName + "_coop_rhythm"
            };
            List<int> list2 = new List<int>();
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string text = array2[i];
                list2.Add(KeyGenerator.GetQbKey(text, true));
            }
            int num = 8;
            for (int j = 0; j < String1.Length; j++)
            {
                int num2 = KeyGenerator.smethod_24(list.GetRange(num, 4).ToArray(), true);
                if (!list2.Contains(num2))
                {
                    throw new Exception(string.Concat("Dat File Corrupted: unperdictable CRC value (", num2,
                        ") for song \"", FileName, "\""));
                }
                String1[KeyGenerator.smethod_24(list.GetRange(num + 4, 4).ToArray(), true)] =
                    array[list2.IndexOf(num2)];
                num += 20;
            }
        }

        public void method_0(string string2)
        {
            for (int i = 0; i < String1.Length; i++)
            {
                String1[i] = String1[i].Replace(FileName, string2);
            }
            FileName = string2;
            method_1();
        }

        public ZzQbSongObject(int int1, string[] string2)
        {
            Int0 = int1;
            String1 = string2;
            FileName = String1[0].Remove(String1[0].IndexOf('_'));
            method_1();
        }

        public void method_1()
        {
            List<byte> list = new List<byte>();
            list.AddRange(KeyGenerator.smethod_32(String1.Length, true));
            list.AddRange(KeyGenerator.smethod_32(Int0, true));
            for (int i = 0; i < String1.Length; i++)
            {
                list.AddRange(KeyGenerator.smethod_32(KeyGenerator.GetQbKey(String1[i], true), true));
                list.AddRange(KeyGenerator.smethod_32(i, true));
                for (int j = 0; j < 12; j++)
                {
                    list.Add(0);
                }
            }
            Data = list.ToArray();
        }

        public void method_2(string string2)
        {
            KeyGenerator.WriteAllBytes(string2, Data);
        }
    }
}