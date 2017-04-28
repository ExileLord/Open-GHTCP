using System;
using System.Runtime.InteropServices;
using System.Security;
using SharpAudio.ASC;

namespace GHNamespaceK
{
	public static class Class119
	{
		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, ExactSpelling = true)]
		public static extern bool alIsExtensionPresent([In] string extname);

		public static bool smethod_0()
		{
			return alIsExtensionPresent("AL_EXT_FLOAT32");
		}

		public static bool smethod_1()
		{
			return alIsExtensionPresent("AL_EXT_MCFORMATS");
		}

		[CLSCompliant(true), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alGenSources(int n, out IntPtr sources);

		[CLSCompliant(true)]
		public static IntPtr smethod_2()
		{
			IntPtr result;
			alGenSources(1, out result);
			return result;
		}

		[CLSCompliant(true), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alDeleteSources(int int0, ref IntPtr intptr0);

		[CLSCompliant(true)]
		public static void smethod_3(IntPtr intptr0)
		{
			alDeleteSources(1, ref intptr0);
		}

		[CLSCompliant(false), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alSourcef(IntPtr intptr0, Enum10 enum100, float float0);

		[CLSCompliant(true), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alGetSourcei(IntPtr sid, Enum11 param, out int value);

		public static int smethod_4(IntPtr intptr0, Enum11 enum110)
		{
			int result;
			alGetSourcei(intptr0, enum110, out result);
			return result;
		}

		[CLSCompliant(true), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alSourcePlay(IntPtr intptr0);

		[CLSCompliant(true), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alSourceStop(IntPtr intptr0);

		[CLSCompliant(true), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alSourcePause(IntPtr intptr0);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alSourceQueueBuffers(IntPtr intptr0, int int0, IntPtr[] intptr1);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSourceQueueBuffers", ExactSpelling = true)]
		public static extern void alSourceQueueBuffers_1(IntPtr intptr0, int int0, ref IntPtr intptr1);

		public static void smethod_5(IntPtr intptr0, ref IntPtr intptr1)
		{
			alSourceQueueBuffers_1(intptr0, 1, ref intptr1);
		}

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll")]
		public static extern void alSourceUnqueueBuffers(IntPtr sid, int numEntries, [Out] IntPtr[] bids);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", EntryPoint = "alSourceUnqueueBuffers")]
		public static extern void alSourceUnqueueBuffers_1(IntPtr sid, int numEntries, out IntPtr bids);

		public static IntPtr smethod_6(IntPtr intptr0)
		{
			IntPtr result;
			alSourceUnqueueBuffers_1(intptr0, 1, out result);
			return result;
		}

		public static IntPtr[] smethod_7(IntPtr intptr0, int int0)
		{
			if (int0 <= 0)
			{
				throw new ArgumentOutOfRangeException("numEntries", "Must be greater than zero.");
			}
			var array = new IntPtr[int0];
			alSourceUnqueueBuffers(intptr0, int0, array);
			return array;
		}

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alGenBuffers(int n, [Out] IntPtr[] buffers);

		[CLSCompliant(true)]
		public static IntPtr[] smethod_8(int int0)
		{
			var array = new IntPtr[int0];
			alGenBuffers(array.Length, array);
			return array;
		}

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alDeleteBuffers(int n, [In] IntPtr[] buffers);

		[CLSCompliant(true)]
		public static void smethod_9(IntPtr[] intptr0)
		{
			if (intptr0 == null)
			{
				throw new ArgumentNullException();
			}
			if (intptr0.Length == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			alDeleteBuffers(intptr0.Length, intptr0);
		}

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alBufferData(IntPtr intptr0, Enum12 enum120, IntPtr intptr1, int int0, int int1);

		public static Enum12 smethod_10(WaveFormat waveFormat0)
		{
			switch (waveFormat0.waveFormatTag_0)
			{
			case WaveFormatTag.Pcm:
				switch (waveFormat0.short_0)
				{
				case 1:
				{
					var short_ = waveFormat0.short_2;
					if (short_ == 8)
					{
						return Enum12.Const0;
					}
					if (short_ == 16)
					{
						return Enum12.Const1;
					}
					break;
				}
				case 2:
				{
					var short2 = waveFormat0.short_2;
					if (short2 == 8)
					{
						return Enum12.Const2;
					}
					if (short2 == 16)
					{
						return Enum12.Const3;
					}
					break;
				}
				default:
					if (smethod_1())
					{
						switch (waveFormat0.short_0)
						{
						case 4:
						{
							var short3 = waveFormat0.short_2;
							if (short3 == 8)
							{
								return Enum12.Const6;
							}
							if (short3 == 16)
							{
								return Enum12.Const7;
							}
							if (short3 == 32)
							{
								return Enum12.Const8;
							}
							break;
						}
						case 5:
						{
							var short4 = waveFormat0.short_2;
							if (short4 == 8)
							{
								return Enum12.Const9;
							}
							if (short4 == 16)
							{
								return Enum12.Const10;
							}
							if (short4 == 32)
							{
								return Enum12.Const11;
							}
							break;
						}
						case 6:
						{
							var short5 = waveFormat0.short_2;
							if (short5 == 8)
							{
								return Enum12.Const12;
							}
							if (short5 == 16)
							{
								return Enum12.Const13;
							}
							if (short5 == 32)
							{
								return Enum12.Const14;
							}
							break;
						}
						case 7:
						{
							var short6 = waveFormat0.short_2;
							if (short6 == 8)
							{
								return Enum12.Const15;
							}
							if (short6 == 16)
							{
								return Enum12.Const16;
							}
							if (short6 == 32)
							{
								return Enum12.Const17;
							}
							break;
						}
						case 8:
						{
							var short7 = waveFormat0.short_2;
							if (short7 == 8)
							{
								return Enum12.Const18;
							}
							if (short7 == 16)
							{
								return Enum12.Const19;
							}
							if (short7 == 32)
							{
								return Enum12.Const20;
							}
							break;
						}
						}
					}
					break;
				}
				break;
			case WaveFormatTag.IeeeFloat:
				if (smethod_0())
				{
					switch (waveFormat0.short_0)
					{
					case 1:
						return Enum12.Const4;
					case 2:
						return Enum12.Const5;
					}
				}
				break;
			}
			throw new NotSupportedException(string.Concat("OpenAL does not support this format: ", waveFormat0.waveFormatTag_0, " | ", (int)waveFormat0.waveFormatTag_0));
		}
	}
}
