using ns5;
using SharpAudio.ADI.OpenAL;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace ns6
{
	public static class OpenAL
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
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
		public static extern IntPtr alcOpenDevice([In] string devicename);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern bool alcCloseDevice([In] IntPtr device);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern AlcError alcGetError([In] IntPtr device);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
		public static extern bool alcIsExtensionPresent([In] IntPtr device, [In] string extname);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
		private static extern IntPtr alcGetString([In] IntPtr device, Enum7 param);

		public static string smethod_0(IntPtr intptr_0, Enum7 enum7_0)
		{
			return Marshal.PtrToStringAnsi(OpenAL.alcGetString(intptr_0, enum7_0));
		}

		public static IList<string> smethod_1(IntPtr intptr_0, Enum8 enum8_0)
		{
			List<string> list = new List<string>();
			IntPtr ptr = OpenAL.alcGetString(IntPtr.Zero, (Enum7)enum8_0);
			StringBuilder stringBuilder = new StringBuilder();
			int ofs = 0;
			while (true)
			{
				byte b = Marshal.ReadByte(ptr, ofs++);
				if (b != 0)
				{
					stringBuilder.Append((char)b);
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
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
		public static extern void alcGetIntegerv([In] IntPtr device, Enum9 param, int size, out int data);
	}
}
