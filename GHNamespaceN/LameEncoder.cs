using System;
using System.Runtime.InteropServices;
using SharpAudio.ASC.Mp3.Lame;

namespace GHNamespaceN
{
    public class LameEncoder
    {
        [DllImport("Lame_enc.dll")]
        public static extern uint beInitStream(BeConfig beConfig0, ref uint uint0, ref uint uint1, ref uint uint2);

        [DllImport("Lame_enc.dll")]
        public static extern uint beEncodeChunk(uint hbeStream, uint nSamples, IntPtr pSamples,
            [In] [Out] byte[] pOutput, ref uint pdwOutput);

        public static uint smethod_0(uint uint0, byte[] byte0, int int0, uint uint1, byte[] byte1, ref uint uint2)
        {
            var gCHandle = GCHandle.Alloc(byte0, GCHandleType.Pinned);
            uint result;
            try
            {
                var pSamples = (IntPtr) (gCHandle.AddrOfPinnedObject().ToInt32() + int0);
                result = beEncodeChunk(uint0, uint1 / 2u, pSamples, byte1, ref uint2);
            }
            finally
            {
                gCHandle.Free();
            }
            return result;
        }

        public static uint smethod_1(uint uint0, byte[] byte0, byte[] byte1, ref uint uint1)
        {
            return smethod_0(uint0, byte0, 0, (uint) byte0.Length, byte1, ref uint1);
        }

        [DllImport("Lame_enc.dll")]
        public static extern uint beDeinitStream(uint hbeStream, [In] [Out] byte[] pOutput, ref uint pdwOutput);

        [DllImport("Lame_enc.dll")]
        public static extern uint beCloseStream(uint uint0);
    }
}