using NeversoftTools.Texture.DDS;
using ns14;
using ns16;
using ns19;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ns21
{
	public class DDSClass1
	{
		public struct Struct89
		{
			public uint uint_0;

			public uint uint_1;

			public uint uint_2;

			public uint uint_3;

			public uint uint_4;

			public uint uint_5;

			public uint uint_6;

			public uint uint_7;
		}

		public struct Struct90
		{
			public uint uint_0;

			public uint uint_1;

			public uint uint_2;

			public uint uint_3;

			public uint uint_4;

			public uint uint_5;

			public uint uint_6;

			public DDSClass1.Struct89 struct89_0;

			public uint uint_7;

			public uint uint_8;
		}

		public IMGPixelFormat imgpixelFormat_0;

		public int int_0;

		public int int_1;

		public Size size_0;

		public byte[] byte_0;

		public DDSClass1(string string_0) : this(File.OpenRead(string_0), false)
		{
		}

		public DDSClass1(Stream stream_0) : this(stream_0, false)
		{
		}

		public DDSClass1(Stream stream_0, bool bool_0)
		{
			this.method_0(stream_0, bool_0);
		}

		public DDSClass1(Image image_0, int int_2, IMGPixelFormat imgpixelFormat_1) : this(image_0, int_2, imgpixelFormat_1, true)
		{
		}

		public DDSClass1(Image image_0, int int_2, IMGPixelFormat imgpixelFormat_1, bool bool_0)
		{
			this.int_1 = int_2;
			this.imgpixelFormat_0 = imgpixelFormat_1;
			this.size_0 = image_0.Size;
			this.method_2(image_0, int_2, imgpixelFormat_1, bool_0);
		}

		private void method_0(Stream stream_0, bool bool_0)
		{
			BinaryReader binaryReader = new BinaryReader(stream_0);
			if (new string(binaryReader.ReadChars(4)) != "DDS ")
			{
				throw new FileLoadException("Invalid DDS file");
			}
			DDSClass1.Struct90 @struct;
			@struct.uint_0 = binaryReader.ReadUInt32();
			@struct.uint_1 = binaryReader.ReadUInt32();
			@struct.uint_2 = binaryReader.ReadUInt32();
			@struct.uint_3 = binaryReader.ReadUInt32();
			@struct.uint_4 = binaryReader.ReadUInt32();
			@struct.uint_5 = binaryReader.ReadUInt32();
			@struct.uint_6 = binaryReader.ReadUInt32();
			binaryReader.ReadBytes(44);
			@struct.struct89_0.uint_0 = binaryReader.ReadUInt32();
			@struct.struct89_0.uint_1 = binaryReader.ReadUInt32();
			@struct.struct89_0.uint_2 = binaryReader.ReadUInt32();
			@struct.struct89_0.uint_3 = binaryReader.ReadUInt32();
			@struct.struct89_0.uint_4 = binaryReader.ReadUInt32();
			@struct.struct89_0.uint_5 = binaryReader.ReadUInt32();
			@struct.struct89_0.uint_6 = binaryReader.ReadUInt32();
			@struct.struct89_0.uint_7 = binaryReader.ReadUInt32();
			@struct.uint_7 = binaryReader.ReadUInt32();
			@struct.uint_8 = binaryReader.ReadUInt32();
			binaryReader.ReadBytes(12);
			if (@struct.uint_0 == 124u)
			{
				if (@struct.struct89_0.uint_0 == 32u)
				{
					if ((@struct.uint_1 & 131072u) != 0u)
					{
						this.int_1 = (int)@struct.uint_6;
					}
					else
					{
						this.int_1 = 1;
					}
					this.size_0 = new Size((int)@struct.uint_3, (int)@struct.uint_2);
					if ((@struct.struct89_0.uint_1 & 4u) != 0u)
					{
						uint uint_ = @struct.struct89_0.uint_2;
						if (uint_ > 116u)
						{
							if (uint_ <= 844388420u)
							{
								if (uint_ == 827611204u)
								{
									this.imgpixelFormat_0 = IMGPixelFormat.Dxt1;
									this.int_0 = 8;
									goto IL_3BE;
								}
								if (uint_ != 844388420u)
								{
									goto IL_2D5;
								}
							}
							else if (uint_ != 861165636u)
							{
								if (uint_ != 877942852u && uint_ != 894720068u)
								{
									goto IL_2D5;
								}
								this.imgpixelFormat_0 = IMGPixelFormat.Dxt5;
								this.int_0 = 16;
								goto IL_3BE;
							}
							this.imgpixelFormat_0 = IMGPixelFormat.Dxt3;
							this.int_0 = 16;
							goto IL_3BE;
						}
						if (uint_ <= 28u)
						{
							switch (uint_)
							{
							case 20u:
								this.imgpixelFormat_0 = IMGPixelFormat.Bgr24;
								this.int_0 = 3;
								goto IL_3BE;
							case 21u:
								this.imgpixelFormat_0 = IMGPixelFormat.Bgra32;
								this.int_0 = 4;
								goto IL_3BE;
							case 22u:
								break;
							case 23u:
								this.imgpixelFormat_0 = IMGPixelFormat.Bgr16;
								this.int_0 = 2;
								goto IL_3BE;
							default:
								if (uint_ == 28u)
								{
									this.imgpixelFormat_0 = IMGPixelFormat.Alpha8;
									this.int_0 = 1;
									goto IL_3BE;
								}
								break;
							}
						}
						else
						{
							if (uint_ == 50u)
							{
								this.imgpixelFormat_0 = IMGPixelFormat.Luminance8;
								this.int_0 = 1;
								goto IL_3BE;
							}
							if (uint_ == 113u)
							{
								this.imgpixelFormat_0 = IMGPixelFormat.Rgba64Float;
								this.int_0 = 8;
								goto IL_3BE;
							}
							if (uint_ == 116u)
							{
								this.imgpixelFormat_0 = IMGPixelFormat.Rgba128Float;
								this.int_0 = 16;
								goto IL_3BE;
							}
						}
						IL_2D5:
						this.imgpixelFormat_0 = IMGPixelFormat.Bgra32;
						this.int_0 = 4;
					}
					else
					{
						if (@struct.struct89_0.uint_3 == 8u && @struct.struct89_0.uint_7 == 255u)
						{
							this.imgpixelFormat_0 = IMGPixelFormat.Alpha8;
							this.int_0 = 1;
						}
						if (@struct.struct89_0.uint_3 == 32u && @struct.struct89_0.uint_4 == 16711680u && @struct.struct89_0.uint_5 == 65280u && @struct.struct89_0.uint_6 == 255u && @struct.struct89_0.uint_7 == 4278190080u)
						{
							this.imgpixelFormat_0 = IMGPixelFormat.Bgra32;
							this.int_0 = 4;
						}
						if (this.int_0 == 0)
						{
							throw new FileLoadException("Invalid Texture Format");
						}
					}
					IL_3BE:
					byte[] array = new byte[@struct.uint_3 * @struct.uint_2 * (uint)this.int_0];
					stream_0.Read(array, 0, array.Length);
					this.byte_0 = array;
					if (bool_0)
					{
						return;
					}
					stream_0.Close();
					stream_0.Dispose();
					return;
				}
			}
			throw new FileLoadException("Unable to read DDS file: wrong format");
		}

		public Image method_1()
		{
			Bitmap bitmap = new Bitmap(this.size_0.Width, this.size_0.Height, PixelFormat.Format32bppArgb);
			if (this.imgpixelFormat_0 == IMGPixelFormat.Bgra32)
			{
				BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
				Marshal.Copy(this.byte_0, 0, bitmapData.Scan0, bitmapData.Stride * bitmap.Height);
				bitmap.UnlockBits(bitmapData);
				MemoryStream stream = new MemoryStream();
				bitmap.Save(stream, ImageFormat.Bmp);
				return Image.FromStream(stream);
			}
			if (this.imgpixelFormat_0 != IMGPixelFormat.Dxt1 && this.imgpixelFormat_0 != IMGPixelFormat.Dxt3)
			{
				if (this.imgpixelFormat_0 != IMGPixelFormat.Dxt5)
				{
					throw new Exception("Can't decode DDS, Unknown format: " + this.imgpixelFormat_0.ToString());
				}
			}
			Class219 @class = new Class219(bitmap);
			@class.method_4();
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(this.byte_0));
			Class326.smethod_17(binaryReader, @class, this.imgpixelFormat_0);
			binaryReader.Close();
			@class.method_5(true);
			MemoryStream stream2 = new MemoryStream();
			bitmap.Save(stream2, ImageFormat.Bmp);
			return Image.FromStream(stream2);
		}

		public void method_2(Image image_0, int int_2, IMGPixelFormat imgpixelFormat_1, bool bool_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			for (int i = 0; i < int_2; i++)
			{
				Bitmap bitmap = KeyGenerator.smethod_49(image_0, Math.Max(1, image_0.Width >> i), Math.Max(1, image_0.Height >> i));
				if (imgpixelFormat_1 == IMGPixelFormat.Bgra32)
				{
					BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
					byte[] array = new byte[bitmapData.Stride * bitmap.Height];
					Marshal.Copy(bitmapData.Scan0, array, 0, array.Length);
					bitmap.UnlockBits(bitmapData);
					binaryWriter.Write(array);
				}
				else
				{
					Class326.smethod_16(bitmap, binaryWriter, imgpixelFormat_1, bool_0);
				}
			}
			this.int_1 = int_2;
			this.imgpixelFormat_0 = imgpixelFormat_1;
			this.byte_0 = memoryStream.ToArray();
		}

		public byte[] method_3()
		{
			MemoryStream memoryStream = new MemoryStream();
			this.method_4(memoryStream);
			return memoryStream.ToArray();
		}

		public void method_4(Stream stream_0)
		{
			this.method_5(stream_0, false);
		}

		public void method_5(Stream stream_0, bool bool_0)
		{
			BinaryWriter binaryWriter = new BinaryWriter(stream_0);
			binaryWriter.Write(542327876);
			binaryWriter.Write(124);
			binaryWriter.Write(135175);
			binaryWriter.Write(this.size_0.Height);
			binaryWriter.Write(this.size_0.Width);
			binaryWriter.Write(new byte[8]);
			binaryWriter.Write(this.int_1);
			binaryWriter.Write(new byte[44]);
			binaryWriter.Write(32);
			if (this.imgpixelFormat_0 == IMGPixelFormat.Bgra32)
			{
				binaryWriter.Write(65);
				binaryWriter.Write(new byte[4]);
				binaryWriter.Write(32);
				binaryWriter.Write(16711680);
				binaryWriter.Write(65280);
				binaryWriter.Write(255);
				binaryWriter.Write(4278190080u);
				binaryWriter.Write(4198410);
				binaryWriter.Write(65280);
				binaryWriter.Write(new byte[12]);
			}
			else
			{
				binaryWriter.Write(4);
				switch (this.imgpixelFormat_0)
				{
				case IMGPixelFormat.Dxt1:
					binaryWriter.Write(827611204);
					break;
				case IMGPixelFormat.Dxt3:
					binaryWriter.Write(861165636);
					break;
				case IMGPixelFormat.Dxt5:
					binaryWriter.Write(894720068);
					break;
				default:
					throw new Exception("DDS Creation: Format unknown");
				}
				binaryWriter.Write(new byte[20]);
				binaryWriter.Write(4198408);
				binaryWriter.Write(new byte[16]);
			}
			binaryWriter.Write(this.byte_0);
			if (!bool_0)
			{
				binaryWriter.Close();
			}
		}
	}
}
