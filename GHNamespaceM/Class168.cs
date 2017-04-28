using System;
using System.IO;

namespace GHNamespaceM
{
    public class Class168 : IDisposable
    {
        public string FileName;

        public uint Uint0;

        public uint Uint1;

        public uint Uint2;

        public FsbFlags2 Enum220;

        public int Int0;

        public ushort Ushort0;

        public short Short0;

        public float Float0 = -1f;

        public float Float1 = 1f;

        public ushort Ushort1;

        public uint Uint3;

        public float Float2;

        public float Float3;

        public int Int1;

        public short Short1;

        public short Short2;

        public Stream Stream0;

        public Stream Stream1;

        public Class168()
        {
            FileName = "";
            Uint0 = 0u;
            Uint1 = 0u;
            Uint2 = 0u;
            Enum220 = FsbFlags2.Flag33;
            Int0 = 0;
            Ushort0 = 255;
            Short0 = -1;
            Ushort1 = 128;
            Uint3 = 2u;
            Float2 = 1f;
            Float3 = 10000f;
            Int1 = 0;
            Short1 = 0;
            Short2 = 0;
            Stream0 = Stream.Null;
            Stream1 = Stream.Null;
        }

        public override string ToString()
        {
            return string.Concat("FsbSubFile:\nName = ", FileName, "\nNumSamples = ", Uint0, "\nLoopStartPoint = ",
                Uint1, "\nLoopEndPoint = ", Uint2, "\nFlags = ", Enum220, "\nFrequency = ", Int0, "\nVolume = ",
                Ushort0, "\nPan = ", Short0, "\nPriority = ", Ushort1, "\nNumChannels = ", Uint3, "\nMinDistance = ",
                Float2, "\nMaxDistance = ", Float3, "\nFrequencyVariation = ", Int1, "\nVolumeVariation = ", Short1,
                "\nPanVariation = ", Short2, "\nExtraData.Length = ", Stream0.Length, "\nAudioData.Length = ",
                Stream1.Length, "\n");
        }

        ~Class168()
        {
            method_0(false);
        }

        public void Dispose()
        {
            method_0(true);
            GC.SuppressFinalize(this);
        }

        public void method_0(bool bool0)
        {
            if (bool0)
            {
                Stream0.Dispose();
                Stream1.Dispose();
            }
        }
    }
}