using ns0;
using ns1;
using ns11;
using ns3;
using ns4;
using ns5;
using ns6;
using ns7;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ns8
{
	public class AudioManager : IDisposable
	{
		private List<Interface6> list_0;

		public AudioManager()
		{
			this.list_0 = new List<Interface6>();
		}

		public static Interface6 smethod_0(Enum25 enum25_0, GenericAudioStream audioStream)
		{
            switch (enum25_0)
			{
			case Enum25.const_1:
				return new Class163(audioStream);
			case Enum25.const_2:
				return new Class155(audioStream);
			case Enum25.const_3:
				return new Class163(audioStream);
			case Enum25.const_5:
				return new Class163(audioStream);
			}
            bool flag = Type.GetType("Mono.Runtime") != null;
			int platform = (int)Environment.OSVersion.Platform;
            switch (platform)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			{
				Interface6 result;
				try
				{
					result = new Class163(audioStream);
				}
				catch
				{
					result = new Class109(audioStream);
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
			throw new PlatformNotSupportedException(string.Concat(new object[]
			{
				flag ? "" : "Not ",
				"Running Mono. PlatformID: ",
				(int)Environment.OSVersion.Platform,
				" | ",
				Environment.OSVersion.Platform
			}));
        IL_F4:
			return new Class117(audioStream);
		}

		public static AudioTypeEnum smethod_1(string fileName)
		{
			FileInfo fileInfo = new FileInfo(fileName);
			string fileExtension;
			switch (fileExtension = fileInfo.Extension.ToLower())
			{
			case ".mp3":
				return AudioTypeEnum.const_1;
			case ".ogg":
				return AudioTypeEnum.const_2;
			case ".wav":
				return AudioTypeEnum.const_3;
			case ".flac":
				return AudioTypeEnum.const_4;
			case ".ac3":
				return AudioTypeEnum.const_5;
			case ".fsb":
				return AudioTypeEnum.const_6;
			case ".vgs":
				return AudioTypeEnum.const_7;
			case ".vag":
				return AudioTypeEnum.const_8;
			case ".msv":
				return AudioTypeEnum.const_9;
			case ".imf":
				return AudioTypeEnum.const_10;
			}
			return AudioTypeEnum.const_0;
		}

		public static Class16 smethod_2(string string_0)
		{
			Class16 result;
			using (GenericAudioStream stream = AudioManager.getAudioStream(string_0))
			{
				result = stream.vmethod_1();
			}
			return result;
		}

		public static Class16 smethod_3(Stream stream_0)
		{
			long position = stream_0.Position;
			Class16 result;
			try
			{
				result = AudioManager.smethod_5(stream_0).vmethod_1();
			}
			finally
			{
				stream_0.Position = position;
			}
			return result;
		}

		public static GenericAudioStream getAudioStream(string fileName)
		{
            FileInfo fileInfo = new FileInfo(fileName);
			string fileExtension;
            if ((fileExtension = fileInfo.Extension.ToLower()) != null)
			{
				if (fileExtension == ".mp3")
				{
					return new MP3Stream(fileName);
				}
				if (fileExtension == ".ogg")
				{
                    return new OGGStream(fileName);
                }
				if (fileExtension == ".wav")
				{
					return new WAVStream(fileName);
				}
				if (fileExtension == ".flac")
				{
                    MessageBox.Show("FLACs are current broken, will fix later", "FLAC Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
				}
				if (fileExtension == ".ac3")
				{
					return new AC3Stream(fileName);
				}
				if (fileExtension == ".fsb")
				{
					return new FSBStream(fileName);
				}
			}
            throw new NotSupportedException("Audio Engine: " + fileName);
		}

		public static GenericAudioStream smethod_5(Stream audioStream)
		{
			long position = audioStream.Position;
			byte[] array = new byte[4];
			audioStream.Read(array, 0, 4);
			audioStream.Position = position;
			if (array[0] == 255 && array[1] >= 240)
			{
				return new MP3Stream(audioStream);
			}
			if (array[0] == 11 && array[1] == 119)
			{
				return new AC3Stream(audioStream);
			}
			string @string;
			if ((@string = Encoding.UTF8.GetString(array, 0, 3)) != null)
			{
				if (@string == "Ogg")
				{
					return new OGGStream(audioStream);
				}
				if (@string == "RIF")
				{
					return new WAVStream(audioStream);
				}
				if (@string == "ID3")
				{
					return new MP3Stream(audioStream);
				}
				if (@string == "fLa")
				{
					return new FLACStream(audioStream);
				}
				if (@string == "FSB")
				{
					return new FSBStream(audioStream);
				}
			}
			try
			{
				return new FSBStream(audioStream);
			}
			catch
			{
				audioStream.Position = position;
			}
			throw new NotSupportedException("Audio Engine: " + audioStream);
		}

		~AudioManager()
		{
			this.method_0(false);
		}

		public void method_0(bool bool_0)
		{
			foreach (Interface6 current in this.list_0)
			{
				current.Dispose();
			}
		}

		public void Dispose()
		{
			this.method_0(true);
			GC.SuppressFinalize(this);
		}
	}
}
