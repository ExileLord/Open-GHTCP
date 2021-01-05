using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using GHNamespaceJ;
using SharpAudio.ADI.OpenAL;

namespace GHNamespaceK
{
    public static class OpenAl
    {
        [SuppressUnmanagedCodeSecurity]
        [DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Struct62 alcCreateContext([In] IntPtr device, [In] int[] attrlist);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern bool alcMakeContextCurrent([In] Struct62 context);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void alcDestroyContext([In] Struct62 context);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern Struct62 alcGetCurrentContext();

        [SuppressUnmanagedCodeSecurity]
        [DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi,
            ExactSpelling = true)]
        public static extern IntPtr alcOpenDevice([In] string devicename);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern bool alcCloseDevice([In] IntPtr device);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern AlcError alcGetError([In] IntPtr device);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi,
            ExactSpelling = true)]
        public static extern bool alcIsExtensionPresent([In] IntPtr device, [In] string extname);

        [SuppressUnmanagedCodeSecurity]
        [DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi,
            ExactSpelling = true)]
        private static extern IntPtr alcGetString([In] IntPtr device, Enum7 param);

        public static string smethod_0(IntPtr intptr0, Enum7 enum70)
        {
            return Marshal.PtrToStringAnsi(alcGetString(intptr0, enum70));
        }

        public static IList<string> smethod_1(IntPtr intptr0, Enum8 enum80)
        {
            var list = new List<string>();
            var ptr = alcGetString(IntPtr.Zero, (Enum7) enum80);
            var stringBuilder = new StringBuilder();
            var ofs = 0;
            while (true)
            {
                var b = Marshal.ReadByte(ptr, ofs++);
                if (b != 0)
                {
                    stringBuilder.Append((char) b);
                }
                if (b == 0)
                {
                    list.Add(stringBuilder.ToString());
                    if (Marshal.ReadByte(ptr, ofs) == 0)
                    {
                        break;
                    }
                    stringBuilder.Remove(0, stringBuilder.Length);
                }
            }
            return list;
        }

        [SuppressUnmanagedCodeSecurity]
        [DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi,
            ExactSpelling = true)]
        public static extern void alcGetIntegerv([In] IntPtr device, Enum9 param, int size, out int data);
    }
}