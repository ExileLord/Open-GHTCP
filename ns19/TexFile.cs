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
		public List<TextureMetadata> textureList = new List<TextureMetadata>();

		private Stream26 _fileStream;

		private string _fileName;

		private bool _unkFlag0 = true;

		public DDSTexture this[int index]
		{
			get
			{
				if (this.textureList[index].Data != null)
				{
					return new DDSTexture(new MemoryStream(this.textureList[index].Data));
				}
				this._fileStream.Position = (long)this.textureList[index].StartIndex;
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
			else if (num2 != 2600)
			{
				throw new Exception();
			}
			while (num-- != 0)
			{
				this.textureList.Add(
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

		public void method_1(int int_0, Image image_0, IMGPixelFormat imgpixelFormat_0)
		{
			TextureMetadata @class = this.textureList[int_0];
			@class.Height = (short)image_0.Height;
			@class.Width = (short)image_0.Width;
			@class.Data = new DDSTexture(image_0, (int)@class.MipMapCount, imgpixelFormat_0).ToByteArray();
		}

		public byte[] method_2(int int_0)
		{
			if (this.textureList[int_0].Data != null)
			{
				return this.textureList[int_0].Data;
			}
			this._fileStream.Position = (long)this.textureList[int_0].StartIndex;
			return this._fileStream.ReadBytes(this.textureList[int_0].Length);
		}

		public void method_3(int int_0, string string_1)
		{
			KeyGenerator.smethod_9(string_1, this.method_2(int_0));
		}

		public int TextureCount()
		{
			return this.textureList.Count;
		}

		public bool method_5()
		{
			return this._fileStream != null && this._fileName != null;
		}

		public void method_6()
		{
			if (this._fileStream == null || this._fileName == null)
			{
				throw new IOException("Tex File was never parsed");
			}
			this.method_8(this._fileName);
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
				TextureMetadata tex = this.textureList[i];
				byte[] array = this.method_2(i);
				stream.WriteShortAt(textureMetaDataOffset + 40 * i, 2600);
				stream.WriteShort(tex.unkShort0);
				stream.WriteInt(tex.unkInt);
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

		public void method_8(string string_1)
		{
			Stream26 stream = this.ToStream();
			if (this._fileStream != null && this._fileName == string_1)
			{
				this._fileStream.Close();
			}
			stream.zzUnknownReadMethod(string_1);
			if (this._fileStream != null && this._fileName == string_1)
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
			this.textureList.Clear();
		}
	}
}
