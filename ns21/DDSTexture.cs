using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ns14;
using ns16;
using ns19;
using NeversoftTools.Texture.DDS;

namespace ns21
{
	public class DDSTexture
	{
		public struct DDSPixelFormat
		{
			public uint size;

			public uint flags;

			public uint fourCC;

			public uint rgbBitCount;

			public uint redBitMask;

			public uint greenBitMask;

			public uint BlueBitMask;

			public uint AlphaBitMask;
		}

		public struct DDSHeader
		{
			public uint size;

			public uint flags;

			public uint height;

			public uint width;

			public uint pitchOrLinearSize;

			public uint depth;

			public uint mipMapCount;

			public DDSPixelFormat pixelFormat;

			public uint unk1;

			public uint unk2;
		}

		public IMGPixelFormat PixelFormat;

		public int BPP;

		public int MipMapCount;

		public Size Size;

		public byte[] data;

		public DDSTexture(string string_0) : this(File.OpenRead(string_0), false)
		{
		}

		public DDSTexture(Stream stream_0) : this(stream_0, false)
		{
		}

		public DDSTexture(Stream stream, bool leaveOpen)
		{
			Load(stream, leaveOpen);
		}

		public DDSTexture(Image image_0, int int_2, IMGPixelFormat imgpixelFormat_1) : this(image_0, int_2, imgpixelFormat_1, true)
		{
		}

		public DDSTexture(Image image, int mipMapCount, IMGPixelFormat pixelFormat, bool unkBool1)
		{
			MipMapCount = mipMapCount;
			PixelFormat = pixelFormat;
			Size = image.Size;
			ChangeImageProbably(image, mipMapCount, pixelFormat, unkBool1);
		}

		private void Load(Stream stream, bool leaveOpen)
		{
			BinaryReader binaryReader = new BinaryReader(stream);
			if (new string(binaryReader.ReadChars(4)) != "DDS ")
			{
				throw new FileLoadException("Invalid DDS file");
			}
			DDSHeader header;
			header.size = binaryReader.ReadUInt32();
			header.flags = binaryReader.ReadUInt32();
			header.height = binaryReader.ReadUInt32();
			header.width = binaryReader.ReadUInt32();
			header.pitchOrLinearSize = binaryReader.ReadUInt32();
			header.depth = binaryReader.ReadUInt32();
			header.mipMapCount = binaryReader.ReadUInt32();

			binaryReader.ReadBytes(44);
			header.pixelFormat.size = binaryReader.ReadUInt32();
			header.pixelFormat.flags = binaryReader.ReadUInt32();
			header.pixelFormat.fourCC = binaryReader.ReadUInt32();
			header.pixelFormat.rgbBitCount = binaryReader.ReadUInt32();
			header.pixelFormat.redBitMask = binaryReader.ReadUInt32();
			header.pixelFormat.greenBitMask = binaryReader.ReadUInt32();
			header.pixelFormat.BlueBitMask = binaryReader.ReadUInt32();
			header.pixelFormat.AlphaBitMask = binaryReader.ReadUInt32();
			header.unk1 = binaryReader.ReadUInt32();
			header.unk2 = binaryReader.ReadUInt32();
			binaryReader.ReadBytes(12);

			if (header.size == 124u)
			{
				if (header.pixelFormat.size == 32u)
				{
					if ((header.flags & 131072u) != 0u)
					{
						MipMapCount = (int)header.mipMapCount;
					}
					else
					{
						MipMapCount = 1;
					}
					Size = new Size((int)header.width, (int)header.height);
					if ((header.pixelFormat.flags & 4u) != 0u)
					{
						uint uint_ = header.pixelFormat.fourCC;
						if (uint_ > 116u)
						{
							if (uint_ <= 844388420u)
							{
								if (uint_ == 827611204u)
								{
									PixelFormat = IMGPixelFormat.Dxt1;
									BPP = 8;
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
								PixelFormat = IMGPixelFormat.Dxt5;
								BPP = 16;
								goto IL_3BE;
							}
							PixelFormat = IMGPixelFormat.Dxt3;
							BPP = 16;
							goto IL_3BE;
						}
						if (uint_ <= 28u)
						{
							switch (uint_)
							{
							case 20u:
								PixelFormat = IMGPixelFormat.Bgr24;
								BPP = 3;
								goto IL_3BE;
							case 21u:
								PixelFormat = IMGPixelFormat.Bgra32;
								BPP = 4;
								goto IL_3BE;
							case 22u:
								break;
							case 23u:
								PixelFormat = IMGPixelFormat.Bgr16;
								BPP = 2;
								goto IL_3BE;
							default:
								if (uint_ == 28u)
								{
									PixelFormat = IMGPixelFormat.Alpha8;
									BPP = 1;
									goto IL_3BE;
								}
								break;
							}
						}
						else
						{
							if (uint_ == 50u)
							{
								PixelFormat = IMGPixelFormat.Luminance8;
								BPP = 1;
								goto IL_3BE;
							}
							if (uint_ == 113u)
							{
								PixelFormat = IMGPixelFormat.Rgba64Float;
								BPP = 8;
								goto IL_3BE;
							}
							if (uint_ == 116u)
							{
								PixelFormat = IMGPixelFormat.Rgba128Float;
								BPP = 16;
								goto IL_3BE;
							}
						}
						IL_2D5:
						PixelFormat = IMGPixelFormat.Bgra32;
						BPP = 4;
					}
					else
					{
						if (header.pixelFormat.rgbBitCount == 8u && header.pixelFormat.AlphaBitMask == 255u)
						{
							PixelFormat = IMGPixelFormat.Alpha8;
							BPP = 1;
						}
						if (header.pixelFormat.rgbBitCount == 32u && header.pixelFormat.redBitMask == 16711680u && header.pixelFormat.greenBitMask == 65280u && header.pixelFormat.BlueBitMask == 255u && header.pixelFormat.AlphaBitMask == 4278190080u)
						{
							PixelFormat = IMGPixelFormat.Bgra32;
							BPP = 4;
						}
						if (BPP == 0)
						{
							throw new FileLoadException("Invalid Texture Format");
						}
					}
					IL_3BE:
					byte[] array = new byte[header.width * header.height * (uint)BPP];
					stream.Read(array, 0, array.Length);
					data = array;
					if (leaveOpen)
					{
						return;
					}
					stream.Close();
					stream.Dispose();
					return;
				}
			}
			throw new FileLoadException("Unable to read DDS file: wrong format");
		}

		public Image GetImage()
		{
            Bitmap bitmap = new Bitmap(Size.Width, Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			if (PixelFormat == IMGPixelFormat.Bgra32)
			{
				BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
				Marshal.Copy(data, 0, bitmapData.Scan0, bitmapData.Stride * bitmap.Height);
				bitmap.UnlockBits(bitmapData);
				MemoryStream stream = new MemoryStream();
				bitmap.Save(stream, ImageFormat.Bmp);
				return Image.FromStream(stream);
			}
			if (PixelFormat != IMGPixelFormat.Dxt1 && PixelFormat != IMGPixelFormat.Dxt3)
			{
				if (PixelFormat != IMGPixelFormat.Dxt5)
				{
					throw new Exception("Can't decode DDS, Unknown format: " + PixelFormat);
				}
			}
			ImageRelatedClass unk = new ImageRelatedClass(bitmap);
			unk.method_4();
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(data));
			zzTextureClass.smethod_17(binaryReader, unk, PixelFormat);
			binaryReader.Close();
			unk.method_5(true);
			MemoryStream stream2 = new MemoryStream();
			bitmap.Save(stream2, ImageFormat.Bmp);
			return Image.FromStream(stream2);
		}

        int ClampMipMaps(int MipMapCount, int Width, int Height)
        {
            int minDimension = Math.Min(Width, Height);

            while ((1 << MipMapCount) > minDimension)
                --MipMapCount;

            return MipMapCount;
        }

   


		public void ChangeImageProbably(Image img, int MipMaps, IMGPixelFormat imgpixelFormat_1, bool bool_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            MipMaps = ClampMipMaps(MipMapCount, img.Width, img.Height);

            //Generate mipmaps
            for (int i = 0; i < MipMaps; i++)
			{
				Bitmap bitmap = KeyGenerator.ScaleImageFixedRatio(img, Math.Max(1, img.Width >> i), Math.Max(1, img.Height >> i));
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
					zzTextureClass.smethod_16(bitmap, binaryWriter, imgpixelFormat_1, bool_0);
				}
			}
			MipMapCount = MipMaps;
			PixelFormat = imgpixelFormat_1;
			data = memoryStream.ToArray();
		}

		public byte[] ToByteArray()
		{
			MemoryStream memoryStream = new MemoryStream();
			WriteDDS(memoryStream);
			return memoryStream.ToArray();
		}

		public void WriteDDS(Stream stream, bool leaveOpen = false)
		{
			BinaryWriter binaryWriter = new BinaryWriter(stream);
			binaryWriter.Write(0x20534444);           // DDS Magic word
			binaryWriter.Write(124);                  // size (why is this a constant?..)
			binaryWriter.Write(135175);               // flags
			binaryWriter.Write(Size.Height);     // height
			binaryWriter.Write(Size.Width);      // width
			binaryWriter.Write(new byte[8]);          // pitchOrLinearSize, Depth
			binaryWriter.Write(MipMapCount);     // Mip maps
			binaryWriter.Write(new byte[44]);         // reserved

            //Pixel Format
			binaryWriter.Write(32); //size 
			if (PixelFormat == IMGPixelFormat.Bgra32)
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
				switch (PixelFormat)
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
			binaryWriter.Write(data);
			if (!leaveOpen)
			{
				binaryWriter.Close();
			}
		}
	}
}
