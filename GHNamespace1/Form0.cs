using System.Runtime.InteropServices;
using SharpAudio.ASC;

namespace GHNamespace1
{
    [StructLayout(LayoutKind.Sequential)]
    public class Form0 : WaveFormat
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)] public readonly byte[] byte_0 = new byte[100];
    }
}