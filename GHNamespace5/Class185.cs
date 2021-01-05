using System;
using System.IO;

namespace GHNamespace5
{
    public class Class185 : INterface8
    {
        private static readonly char[] Char0;

        private static readonly char[] Char1;

        static Class185()
        {
            var invalidPathChars = Path.GetInvalidPathChars();
            var num = invalidPathChars.Length + 2;
            Char1 = new char[num];
            Array.Copy(invalidPathChars, 0, Char1, 0, invalidPathChars.Length);
            Char1[num - 1] = '*';
            Char1[num - 2] = '?';
            num = invalidPathChars.Length + 4;
            Char0 = new char[num];
            Array.Copy(invalidPathChars, 0, Char0, 0, invalidPathChars.Length);
            Char0[num - 1] = ':';
            Char0[num - 2] = '\\';
            Char0[num - 3] = '*';
            Char0[num - 4] = '?';
        }
    }
}