using NeversoftTools.Texture.DDS;
using ns16;
using ns21;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ns19
{
	public class TexFile : IDisposable
	{
		public List<TextureMetadata> TextureList = new List<TextureMetadata>();

		private Stream26 _fileStream;

		private string _fileName;

		private bool _unkFlag0 = true;

		public DDSTexture this[int index]
		{
			get
			{
				if (this.TextureList[index].Data != null)
				{
					return new DDSTexture(new MemoryStream(this.TextureList[index].Data));
				}
				this._fileStream.Position = (long)this.TextureList[index].StartIndex;
				return new DDSTexture(this._fileStream._stream, true);
			}
		}

		public TexFile()
		{
		}

		public TexFile(string string_1)
		{
			this._fileName = string_1;
			this.Initialize();
		}

		public TexFile(byte[] byte_0)
		{
			this._fileStream = new Stream26(byte_0, true);
			this.Initialize();
		}

		public void Initialize()
		{
			if (this._fileName != null)
			{
				this._fileStream = new Stream26(File.Open(this._fileName, FileMode.Open, FileAccess.Read, FileShare.Read), true);
			}
			int num = 1;
			ushort num2 = this._fileStream.ReadUShort();
			int num3 = 0;
			if (num2 == 0xFACE) // Hey man he was in my face
			{
				this._unkFlag0 = false;
				num = (int)this._fileStream.ReadShortAt(6);
				num3 = this._fileStream.ReadInt();
			}
			else if (num2 != 2600) // Appears to be flags at the beginning of certain types of texture metadata?
			{
				throw new Exception();
			}
			while (num-- != 0)
			{
				this.TextureList.Add(
                    new TextureMetadata(
                        this._fileStream.ReadShortAt(num3 + 2), 
                        this._fileStream.ReadInt(), 
                        this._fileStream.ReadShort(), 
                        this._fileStream.ReadShort(), 
                        this._fileStream.ReadShort(), 
                        this._fileStream.ReadByteAt(num3 + 20), 
                        this._fileStream.ReadShort(), 
                        this._fileStream.ReadIntAt(num3 + 28), 
                        this._fileStream.ReadInt()));
				num3 += 40;
			}
			this._fileStream._reverseEndianness = false;
		}

		public void ReplaceTexture(int index, Image img, IMGPixelFormat format)
		{
			TextureMetadata texMetaData = this.TextureList[index];
			texMetaData.Height = (short)img.Height;
			texMetaData.Width = (short)img.Width;
			texMetaData.Data = new DDSTexture(img, (int)texMetaData.MipMapCount, format).ToByteArray();
		}

		public byte[] GetRawTextureData(int index)
		{
			if (this.TextureList[index].Data != null)
			{
				return this.TextureList[index].Data;
			}
			this._fileStream.Position = (long)this.TextureList[index].StartIndex;
			return this._fileStream.ReadBytes(this.TextureList[index].Length);
		}

		public void WriteBytes(int index, string fileName)
		{
			KeyGenerator.WriteAllBytes(fileName, this.GetRawTextureData(index));
		}

		public int TextureCount()
		{
			return this.TextureList.Count;
		}

		public bool CanWrite()
		{
			return this._fileStream != null && this._fileName != null;
		}

		public void WriteEverythingToFile()
		{
			if (this._fileStream == null || this._fileName == null)
			{
				throw new IOException("Tex File was never parsed");
			}
			this.WriteEverythingToFile(this._fileName);
		}

		public Stream26 ToStream()
		{
			Stream26 stream = new Stream26(true);
			int textureCount = this.TextureCount();
			int textureMetaDataOffset = 0;
			if (!this._unkFlag0)
			{
				stream.WriteUInt(0xFACECAA7); //meow
				stream.WriteShort(284);
				stream.WriteShort((short)textureCount);
				stream.WriteInt(0);
				stream.WriteInt(0);
				stream.WriteInt(-1);

				int num3 = 2;
				while ((double)textureCount / Math.Pow(2.0, (double)(num3 - 2)) > 1.0)
				{
					num3++;
				}
				num3--;
				stream.WriteInt(num3); //logarithm of textureCount?..
				stream.WriteInt(28);
				stream.WriteNBytes(0xEF, (int)(Math.Pow(2.0, (double)num3) * 12.0 + 28.0));

				textureMetaDataOffset = (int)stream.Position;
				stream.WriteIntAt(8, textureMetaDataOffset);
				stream.WriteInt(textureMetaDataOffset + textureCount * 44);
				stream.Position = (long)textureMetaDataOffset;
			}
			stream.WriteNBytes(0, 40 * textureCount);
			for (int i = 0; i < textureCount; i++)
			{
				TextureMetadata tex = this.TextureList[i];
				byte[] array = this.GetRawTextureData(i);
				stream.WriteShortAt(textureMetaDataOffset + 40 * i, 2600);
				stream.WriteShort(tex.unkFlags);
				stream.WriteInt(tex.Key);
				stream.WriteShort(tex.Width);
				stream.WriteShort(tex.Height);
				stream.WriteShort(tex.unkShort3);
				stream.WriteShort(tex.Width);
				stream.WriteShort(tex.Height);
				stream.WriteShort(tex.unkShort3);
				stream.WriteByte2(tex.MipMapCount);
				stream.WriteShort(tex.unkShort4);
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
			Stream26 stream = this.ToStream();
			if (this._fileStream != null && this._fileName == fileName)
			{
				this._fileStream.Close();
			}
			stream.WriteEverythingToFile(fileName);
			if (this._fileStream != null && this._fileName == fileName)
			{
				this.Dispose();
				this.Initialize();
				GC.Collect();
			}
		}

		public void Dispose()
		{
			this._fileStream.Close();
			this._fileStream.Dispose();
			this._fileStream = null;
			this.TextureList.Clear();
		}

        public int CloneTextureElement(int index)
        {
            TextureMetadata original = TextureList[index];
            TextureMetadata newMeta = new TextureMetadata(original.unkFlags, original.Key, original.Width, original.Height, original.unkShort3, original.MipMapCount, original.unkShort4, original.StartIndex, original.Length);
            TextureList.Add(newMeta);
            return TextureList.Count-1;
        }

	}
}
