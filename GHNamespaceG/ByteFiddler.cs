using System;
using System.IO;
using System.Text;

namespace GHNamespaceG
{
    public class ByteFiddler
    {
        public static ushort RotateRight(ushort ushort0)
        {
            return (ushort) ((ushort0 >> 8 | ushort0 << 8) & 65535);
        }

        public static uint RotateLeft(uint uint0)
        {
            return uint0 >> 24 | uint0 << 24 | (uint0 >> 8 & 65280u) | (uint0 << 8 & 16711680u);
        }

        public static int DivideSixtyMillionBy(float float0)
        {
            return (int) (6E+07f / float0);
        }

        public static string smethod_3(string string0, BinaryReader binaryReader0, string string1)
        {
            long position = binaryReader0.BaseStream.Position;
            string @string = Encoding.ASCII.GetString(binaryReader0.ReadBytes(string1.Length));
            if (@string != string1)
            {
                Console.WriteLine("Reading {0} at position {1}: expected {2}, found {3}", string0, position, string1,
                    @string);
            }
            return @string;
        }
    }
}