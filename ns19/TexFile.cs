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
		public List<zzCocoaStruct12> textureList = new List<zzCocoaStruct12>();

		private Stream26 _fileStream;

		private string _fileName;

		private bool _unkFlag0 = true;

		public DDSTexture this[int int_0]
		{
			get
			{
				if (this.textureList[int_0].byte_1 != null)
				{
					return new DDSTexture(new MemoryStream(this.textureList[int_0].byte_1));
				}
				this._fileStream.Position = (long)this.textureList[int_0].int_1;
				return new DDSTexture(this._fileStream.stream_0, true);
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
			ushort num2 = this._fileStream.method_25();
			int num3 = 0;
			if (num2 == 64206)
			{
				this._unkFlag0 = false;
				num = (int)this._fileStream.method_43(6);
				num3 = this._fileStream.method_19();
			}
			else if (num2 != 2600)
			{
				throw new Exception();
			}
			while (num-- != 0)
			{
				this.textureList.Add(new zzCocoaStruct12(this._fileStream.method_43(num3 + 2), this._fileStream.method_19(), this._fileStream.method_23(), this._fileStream.method_23(), this._fileStream.method_23(), this._fileStream.method_40(num3 + 20), this._fileStream.method_23(), this._fileStream.method_41(num3 + 28), this._fileStream.method_19()));
				num3 += 40;
			}
			this._fileStream.bool_0 = false;
		}

		public void method_1(int int_0, Image image_0, IMGPixelFormat imgpixelFormat_0)
		{
			zzCocoaStruct12 @class = this.textureList[int_0];
			@class.short_2 = (short)image_0.Height;
			@class.short_1 = (short)image_0.Width;
			@class.byte_1 = new DDSTexture(image_0, (int)@class.byte_0, imgpixelFormat_0).method_3();
		}

		public byte[] method_2(int int_0)
		{
			if (this.textureList[int_0].byte_1 != null)
			{
				return this.textureList[int_0].byte_1;
			}
			this._fileStream.Position = (long)this.textureList[int_0].int_1;
			return this._fileStream.method_31(this.textureList[int_0].int_2);
		}

		public void method_3(int int_0, string string_1)
		{
			KeyGenerator.smethod_9(string_1, this.method_2(int_0));
		}

		public int method_4()
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

		public Stream26 method_7()
		{
			Stream26 stream = new Stream26(true);
			int num = this.method_4();
			int num2 = 0;
			if (!this._unkFlag0)
			{
				stream.method_7(4207856295u);
				stream.method_11(284);
				stream.method_11((short)num);
				stream.method_5(0);
				stream.method_5(0);
				stream.method_5(-1);
				int num3 = 2;
				while ((double)num / Math.Pow(2.0, (double)(num3 - 2)) > 1.0)
				{
					num3++;
				}
				num3--;
				stream.method_5(num3);
				stream.method_5(28);
				stream.method_4(239, (int)(Math.Pow(2.0, (double)num3) * 12.0 + 28.0));
				num2 = (int)stream.Position;
				stream.method_33(8, num2);
				stream.method_5(num2 + num * 44);
				stream.Position = (long)num2;
			}
			stream.method_4(0, 40 * num);
			for (int i = 0; i < num; i++)
			{
				zzCocoaStruct12 @class = this.textureList[i];
				byte[] array = this.method_2(i);
				stream.method_35(num2 + 40 * i, 2600);
				stream.method_11(@class.short_0);
				stream.method_5(@class.int_0);
				stream.method_11(@class.short_1);
				stream.method_11(@class.short_2);
				stream.method_11(@class.short_3);
				stream.method_11(@class.short_1);
				stream.method_11(@class.short_2);
				stream.method_11(@class.short_3);
				stream.method_3(@class.byte_0);
				stream.method_11(@class.short_4);
				stream.method_4(0, 5);
				stream.method_5((int)stream.Length);
				stream.method_5(array.Length);
				stream.method_5(0);
				stream.method_37((int)stream.Length, array, false);
			}
			return stream;
		}

		public void method_8(string string_1)
		{
			Stream26 stream = this.method_7();
			if (this._fileStream != null && this._fileName == string_1)
			{
				this._fileStream.Close();
			}
			stream.method_2(string_1);
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
