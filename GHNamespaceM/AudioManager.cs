using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using GHNamespace1;
using GHNamespace2;
using GHNamespace4;
using GHNamespaceH;
using GHNamespaceI;
using GHNamespaceJ;
using GHNamespaceK;
using GHNamespaceL;

namespace GHNamespaceM
{
    public class AudioManager : IDisposable
    {
        private readonly List<IPlayableAudio> _list0;

        public AudioManager()
        {
            _list0 = new List<IPlayableAudio>();
        }

        public static IPlayableAudio LoadPlayableAudio(Enum25 enum250, GenericAudioStream audioStream)
        {
            switch (enum250)
            {
                case Enum25.Const1:
                    return new WaveOutput(audioStream);
                case Enum25.Const2:
                    return new Mp3Output(audioStream);
                case Enum25.Const3:
                    return new WaveOutput(audioStream);
                case Enum25.Const5:
                    return new WaveOutput(audioStream);
            }
            var flag = Type.GetType("Mono.Runtime") != null;
            var platform = (int) Environment.OSVersion.Platform;
            switch (platform)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                {
                    IPlayableAudio result;
                    try
                    {
                        result = new WaveOutput(audioStream);
                    }
                    catch
                    {
                        result = new OggOutput(audioStream);
                    }
                    return result;
                }
                case 4:
                case 6:
                    goto IL_F4;
                case 5:
                    break;
                default:
                    if (platform == 128)
                    {
                        goto IL_F4;
                    }
                    break;
            }
            throw new PlatformNotSupportedException(string.Concat(flag ? "" : "Not ", "Running Mono. PlatformID: ",
                (int) Environment.OSVersion.Platform, " | ", Environment.OSVersion.Platform));
            IL_F4:
            return new Class117(audioStream);
        }

        public static AudioTypeEnum smethod_1(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            string fileExtension;
            switch (fileExtension = fileInfo.Extension.ToLower())
            {
                case ".mp3":
                    return AudioTypeEnum.Const1;
                case ".ogg":
                    return AudioTypeEnum.Const2;
                case ".wav":
                    return AudioTypeEnum.Const3;
                case ".flac":
                    return AudioTypeEnum.Const4;
                case ".ac3":
                    return AudioTypeEnum.Const5;
                case ".fsb":
                    return AudioTypeEnum.Const6;
                case ".vgs":
                    return AudioTypeEnum.Const7;
                case ".vag":
                    return AudioTypeEnum.Const8;
                case ".msv":
                    return AudioTypeEnum.Const9;
                case ".imf":
                    return AudioTypeEnum.Const10;
            }
            return AudioTypeEnum.Const0;
        }

        public static Class16 smethod_2(string string0)
        {
            Class16 result;
            using (var stream = GetAudioStream(string0))
            {
                result = stream.vmethod_1();
            }
            return result;
        }

        public static Class16 smethod_3(Stream stream0)
        {
            var position = stream0.Position;
            Class16 result;
            try
            {
                result = smethod_5(stream0).vmethod_1();
            }
            finally
            {
                stream0.Position = position;
            }
            return result;
        }

        public static GenericAudioStream GetAudioStream(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            string fileExtension;
            if ((fileExtension = fileInfo.Extension.ToLower()) != null)
            {
                if (fileExtension == ".mp3")
                {
                    return new Mp3Stream(fileName);
                }
                if (fileExtension == ".ogg")
                {
                    return new OggStream(fileName);
                }
                if (fileExtension == ".wav")
                {
                    return new WavStream(fileName);
                }
                if (fileExtension == ".flac")
                {
                    return new FlacStream(fileName);
                }
                if (fileExtension == ".ac3")
                {
                    return new Ac3Stream(fileName);
                }
                if (fileExtension == ".fsb")
                {
                    return new FsbStream(fileName);
                }
            }
            throw new NotSupportedException("Audio Engine: " + fileName);
        }

        public static GenericAudioStream smethod_5(Stream audioStream)
        {
            var position = audioStream.Position;
            var array = new byte[4];
            audioStream.Read(array, 0, 4);
            audioStream.Position = position;
            if (array[0] == 255 && array[1] >= 240)
            {
                return new Mp3Stream(audioStream);
            }
            if (array[0] == 11 && array[1] == 119)
            {
                return new Ac3Stream(audioStream);
            }
            string @string;
            if ((@string = Encoding.UTF8.GetString(array, 0, 3)) != null)
            {
                if (@string == "Ogg")
                {
                    return new OggStream(audioStream);
                }
                if (@string == "RIF")
                {
                    return new WavStream(audioStream);
                }
                if (@string == "ID3")
                {
                    return new Mp3Stream(audioStream);
                }
                if (@string == "fLa")
                {
                    return new FlacStream(audioStream);
                }
                if (@string == "FSB")
                {
                    return new FsbStream(audioStream);
                }
            }
            try
            {
                return new FsbStream(audioStream);
            }
            catch
            {
                audioStream.Position = position;
            }
            throw new NotSupportedException("Audio Engine: " + audioStream);
        }

        ~AudioManager()
        {
            method_0(false);
        }

        public void method_0(bool bool0)
        {
            foreach (var current in _list0)
            {
                current.Dispose();
            }
        }

        public void Dispose()
        {
            method_0(true);
            GC.SuppressFinalize(this);
        }
    }
}