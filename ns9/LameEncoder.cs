using System;
using System.Runtime.InteropServices;
using SharpAudio.ASC.Mp3.Lame;

namespace ns9
{
	public class LameEncoder
	{
		[DllImport("Lame_enc.dll")]
		public static extern uint beInitStream(BE_CONFIG be_CONFIG_0, ref uint uint_0, ref uint uint_1, ref uint uint_2);

		[DllImport("Lame_enc.dll")]
		public static extern uint beEncodeChunk(uint hbeStream, uint nSamples, IntPtr pSamples, [In] [Out] byte[] pOutput, ref uint pdwOutput);

		public static uint smethod_0(uint uint_0, byte[] byte_0, int int_0, uint uint_1, byte[] byte_1, ref uint uint_2)
		{
			var gCHandle = GCHandle.Alloc(byte_0, GCHandleType.Pinned);
			uint result;
			try
			{
				var pSamples = (IntPtr)(gCHandle.AddrOfPinnedObject().ToInt32() + int_0);
				result = beEncodeChunk(uint_0, uint_1 / 2u, pSamples, byte_1, ref uint_2);
			}
			finally
			{
				gCHandle.Free();
			}
			return result;
		}

		public static uint smethod_1(uint uint_0, byte[] byte_0, byte[] byte_1, ref uint uint_1)
		{
			return smethod_0(uint_0, byte_0, 0, (uint)byte_0.Length, byte_1, ref uint_1);
		}

		[DllImport("Lame_enc.dll")]
		public static extern uint beDeinitStream(uint hbeStream, [In] [Out] byte[] pOutput, ref uint pdwOutput);

		[DllImport("Lame_enc.dll")]
		public static extern uint beCloseStream(uint uint_0);
	}
}
