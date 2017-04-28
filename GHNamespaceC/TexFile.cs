using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using GHNamespace9;
using GHNamespaceF;
using NeversoftTools.Texture.DDS;

namespace GHNamespaceC
{
	public class TexFile : IDisposable
	{
		public List<TextureMetadata> TextureList = new List<TextureMetadata>();

		private Stream26 _fileStream;

		private readonly string _fileName;

		private bool _unkFlag0 = true;

		public DdsTexture this[int index]
		{
			get
			{
				if (TextureList[index].Data != null)
				{
					return new DdsTexture(new MemoryStream(TextureList[index].Data));
				}
				_fileStream.Position = TextureList[index].StartIndex;
				return new DdsTexture(_fileStream.Stream, true);
			}
		}

		public TexFile()
		{
		}

		public TexFile(string string1)
		{
			_fileName = string1;
			Initialize();
		}

		public TexFile(byte[] byte0)
		{
			_fileStream = new Stream26(byte0, true);
			Initialize();
		}

		public void Initialize()
		{
			if (_fileName != null)
			{
				_fileStream = new Stream26(File.Open(_fileName, FileMode.Open, FileAccess.Read, FileShare.Read), true);
			}
			var num = 1;
			var num2 = _fileStream.ReadUShort();
			var num3 = 0;
			if (num2 == 0xFACE) // Hey man he was in my face
			{
				_unkFlag0 = false;
				num = _fileStream.ReadShortAt(6);
				num3 = _fileStream.ReadInt();
			}
			else if (num2 != 2600) // Appears to be flags at the beginning of certain types of texture metadata?
			{
				throw new Exception();
			}
			while (num-- != 0)
			{
				TextureList.Add(
                    new TextureMetadata(
                        _fileStream.ReadShortAt(num3 + 2), 
                        _fileStream.ReadInt(), 
                        _fileStream.ReadShort(), 
                        _fileStream.ReadShort(), 
                        _fileStream.ReadShort(), 
                        _fileStream.ReadByteAt(num3 + 20), 
                        _fileStream.ReadShort(), 
                        _fileStream.ReadIntAt(num3 + 28), 
                        _fileStream.ReadInt()));
				num3 += 40;
			}
			_fileStream.ReverseEndianness = false;
		}

		public void ReplaceTexture(int index, Image img, ImgPixelFormat format)
		{
			var texMetaData = TextureList[index];
			texMetaData.Height = (short)img.Height;
			texMetaData.Width = (short)img.Width;
			texMetaData.Data = new DdsTexture(img, texMetaData.MipMapCount, format).ToByteArray();
		}

		public byte[] GetRawTextureData(int index)
		{
			if (TextureList[index].Data != null)
			{
				return TextureList[index].Data;
			}
			_fileStream.Position = TextureList[index].StartIndex;
			return _fileStream.ReadBytes(TextureList[index].Length);
		}

		public void WriteBytes(int index, string fileName)
		{
			KeyGenerator.WriteAllBytes(fileName, GetRawTextureData(index));
		}

		public int TextureCount()
		{
			return TextureList.Count;
		}

		public bool CanWrite()
		{
			return _fileStream != null && _fileName != null;
		}

		public void WriteEverythingToFile()
		{
			if (_fileStream == null || _fileName == null)
			{
				throw new IOException("Tex File was never parsed");
			}
			WriteEverythingToFile(_fileName);
		}

		public Stream26 ToStream()
		{
			var stream = new Stream26(true);
			var textureCount = TextureCount();
			var textureMetaDataOffset = 0;
			if (!_unkFlag0)
			{
				stream.WriteUInt(0xFACECAA7); //meow
				stream.WriteShort(284);
				stream.WriteShort((short)textureCount);
				stream.WriteInt(0);
				stream.WriteInt(0);
				stream.WriteInt(-1);

				var num3 = 2;
				while (textureCount / Math.Pow(2.0, num3 - 2) > 1.0)
				{
					num3++;
				}
				num3--;
				stream.WriteInt(num3); //logarithm of textureCount?..
				stream.WriteInt(28);
				stream.WriteNBytes(0xEF, (int)(Math.Pow(2.0, num3) * 12.0 + 28.0));

				textureMetaDataOffset = (int)stream.Position;
				stream.WriteIntAt(8, textureMetaDataOffset);
				stream.WriteInt(textureMetaDataOffset + textureCount * 44);
				stream.Position = textureMetaDataOffset;
			}
			stream.WriteNBytes(0, 40 * textureCount);
			for (var i = 0; i < textureCount; i++)
			{
				var tex = TextureList[i];
				var array = GetRawTextureData(i);
				stream.WriteShortAt(textureMetaDataOffset + 40 * i, 2600);
				stream.WriteShort(tex.UnkFlags);
				stream.WriteInt(tex.Key);
				stream.WriteShort(tex.Width);
				stream.WriteShort(tex.Height);
				stream.WriteShort(tex.UnkShort3);
				stream.WriteShort(tex.Width);
				stream.WriteShort(tex.Height);
				stream.WriteShort(tex.UnkShort3);
				stream.WriteByte2(tex.MipMapCount);
				stream.WriteShort(tex.UnkShort4);
				stream.WriteNBytes(0, 5);
				stream.WriteInt((int)stream.Length);
				stream.WriteInt(array.Length);
				stream.WriteInt(0);
				stream.WriteByteArrayAt((int)stream.Length, array, false);
			}
			return stream;
		}

		public void WriteEverythingToFile(string fileName)
		{
			var stream = ToStream();
			if (_fileStream != null && _fileName == fileName)
			{
				_fileStream.Close();
			}
			stream.WriteEverythingToFile(fileName);
			if (_fileStream != null && _fileName == fileName)
			{
				Dispose();
				Initialize();
				GC.Collect();
			}
		}

		public void Dispose()
		{
			_fileStream.Close();
			_fileStream.Dispose();
			_fileStream = null;
			TextureList.Clear();
		}

        public int CloneTextureElement(int index)
        {
            var original = TextureList[index];
            var newMeta = new TextureMetadata(original.UnkFlags, original.Key, original.Width, original.Height, original.UnkShort3, original.MipMapCount, original.UnkShort4, original.StartIndex, original.Length);
            TextureList.Add(newMeta);
            return TextureList.Count-1;
        }

	}
}
