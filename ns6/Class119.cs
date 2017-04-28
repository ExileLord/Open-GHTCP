using System;
using System.Runtime.InteropServices;
using System.Security;
using SharpAudio.ASC;

namespace ns6
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
		public static extern void alDeleteSources(int int_0, ref IntPtr intptr_0);

		[CLSCompliant(true)]
		public static void smethod_3(IntPtr intptr_0)
		{
			alDeleteSources(1, ref intptr_0);
		}

		[CLSCompliant(false), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alSourcef(IntPtr intptr_0, Enum10 enum10_0, float float_0);

		[CLSCompliant(true), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alGetSourcei(IntPtr sid, Enum11 param, out int value);

		public static int smethod_4(IntPtr intptr_0, Enum11 enum11_0)
		{
			int result;
			alGetSourcei(intptr_0, enum11_0, out result);
			return result;
		}

		[CLSCompliant(true), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alSourcePlay(IntPtr intptr_0);

		[CLSCompliant(true), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alSourceStop(IntPtr intptr_0);

		[CLSCompliant(true), SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alSourcePause(IntPtr intptr_0);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alSourceQueueBuffers(IntPtr intptr_0, int int_0, IntPtr[] intptr_1);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "alSourceQueueBuffers", ExactSpelling = true)]
		public static extern void alSourceQueueBuffers_1(IntPtr intptr_0, int int_0, ref IntPtr intptr_1);

		public static void smethod_5(IntPtr intptr_0, ref IntPtr intptr_1)
		{
			alSourceQueueBuffers_1(intptr_0, 1, ref intptr_1);
		}

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll")]
		public static extern void alSourceUnqueueBuffers(IntPtr sid, int numEntries, [Out] IntPtr[] bids);

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", EntryPoint = "alSourceUnqueueBuffers")]
		public static extern void alSourceUnqueueBuffers_1(IntPtr sid, int numEntries, out IntPtr bids);

		public static IntPtr smethod_6(IntPtr intptr_0)
		{
			IntPtr result;
			alSourceUnqueueBuffers_1(intptr_0, 1, out result);
			return result;
		}

		public static IntPtr[] smethod_7(IntPtr intptr_0, int int_0)
		{
			if (int_0 <= 0)
			{
				throw new ArgumentOutOfRangeException("numEntries", "Must be greater than zero.");
			}
			IntPtr[] array = new IntPtr[int_0];
			alSourceUnqueueBuffers(intptr_0, int_0, array);
			return array;
		}

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alGenBuffers(int n, [Out] IntPtr[] buffers);

		[CLSCompliant(true)]
		public static IntPtr[] smethod_8(int int_0)
		{
			IntPtr[] array = new IntPtr[int_0];
			alGenBuffers(array.Length, array);
			return array;
		}

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alDeleteBuffers(int n, [In] IntPtr[] buffers);

		[CLSCompliant(true)]
		public static void smethod_9(IntPtr[] intptr_0)
		{
			if (intptr_0 == null)
			{
				throw new ArgumentNullException();
			}
			if (intptr_0.Length == 0)
			{
				throw new ArgumentOutOfRangeException();
			}
			alDeleteBuffers(intptr_0.Length, intptr_0);
		}

		[SuppressUnmanagedCodeSecurity]
		[DllImport("openal32.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
		public static extern void alBufferData(IntPtr intptr_0, Enum12 enum12_0, IntPtr intptr_1, int int_0, int int_1);

		public static Enum12 smethod_10(WaveFormat waveFormat_0)
		{
			switch (waveFormat_0.waveFormatTag_0)
			{
			case WaveFormatTag.PCM:
				switch (waveFormat_0.short_0)
				{
				case 1:
				{
					short short_ = waveFormat_0.short_2;
					if (short_ == 8)
					{
						return Enum12.const_0;
					}
					if (short_ == 16)
					{
						return Enum12.const_1;
					}
					break;
				}
				case 2:
				{
					short short_2 = waveFormat_0.short_2;
					if (short_2 == 8)
					{
						return Enum12.const_2;
					}
					if (short_2 == 16)
					{
						return Enum12.const_3;
					}
					break;
				}
				default:
					if (smethod_1())
					{
						switch (waveFormat_0.short_0)
						{
						case 4:
						{
							short short_3 = waveFormat_0.short_2;
							if (short_3 == 8)
							{
								return Enum12.const_6;
							}
							if (short_3 == 16)
							{
								return Enum12.const_7;
							}
							if (short_3 == 32)
							{
								return Enum12.const_8;
							}
							break;
						}
						case 5:
						{
							short short_4 = waveFormat_0.short_2;
							if (short_4 == 8)
							{
								return Enum12.const_9;
							}
							if (short_4 == 16)
							{
								return Enum12.const_10;
							}
							if (short_4 == 32)
							{
								return Enum12.const_11;
							}
							break;
						}
						case 6:
						{
							short short_5 = waveFormat_0.short_2;
							if (short_5 == 8)
							{
								return Enum12.const_12;
							}
							if (short_5 == 16)
							{
								return Enum12.const_13;
							}
							if (short_5 == 32)
							{
								return Enum12.const_14;
							}
							break;
						}
						case 7:
						{
							short short_6 = waveFormat_0.short_2;
							if (short_6 == 8)
							{
								return Enum12.const_15;
							}
							if (short_6 == 16)
							{
								return Enum12.const_16;
							}
							if (short_6 == 32)
							{
								return Enum12.const_17;
							}
							break;
						}
						case 8:
						{
							short short_7 = waveFormat_0.short_2;
							if (short_7 == 8)
							{
								return Enum12.const_18;
							}
							if (short_7 == 16)
							{
								return Enum12.const_19;
							}
							if (short_7 == 32)
							{
								return Enum12.const_20;
							}
							break;
						}
						}
					}
					break;
				}
				break;
			case WaveFormatTag.IEEEFloat:
				if (smethod_0())
				{
					switch (waveFormat_0.short_0)
					{
					case 1:
						return Enum12.const_4;
					case 2:
						return Enum12.const_5;
					}
				}
				break;
			}
			throw new NotSupportedException(string.Concat("OpenAL does not support this format: ", waveFormat_0.waveFormatTag_0, " | ", (int)waveFormat_0.waveFormatTag_0));
		}
	}
}
