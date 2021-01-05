using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using GHNamespace7;
using GHNamespace9;
using GHNamespaceC;
using NeversoftTools.Texture.DDS;

namespace GHNamespaceF
{
    public class DdsTexture
    {
        public struct DdsPixelFormat
        {
            public uint size;

            public uint Flags;

            public uint FourCc;

            public uint RgbBitCount;

            public uint RedBitMask;

            public uint GreenBitMask;

            public uint BlueBitMask;

            public uint AlphaBitMask;
        }

        public struct DdsHeader
        {
            public uint size;

            public uint Flags;

            public uint Height;

            public uint Width;

            public uint PitchOrLinearSize;

            public uint Depth;

            public uint mipMapCount;

            public DdsPixelFormat pixelFormat;

            public uint Unk1;

            public uint Unk2;
        }

        public ImgPixelFormat PixelFormat;

        public int Bpp;

        public int MipMapCount;

        public Size Size;

        public byte[] Data;

        public DdsTexture(string string0) : this(File.OpenRead(string0), false)
        {
        }

        public DdsTexture(Stream stream0) : this(stream0, false)
        {
        }

        public DdsTexture(Stream stream, bool leaveOpen)
        {
            Load(stream, leaveOpen);
        }

        public DdsTexture(Image image0, int int2, ImgPixelFormat imgpixelFormat1) : this(image0, int2, imgpixelFormat1,
            true)
        {
        }

        public DdsTexture(Image image, int mipMapCount, ImgPixelFormat pixelFormat, bool unkBool1)
        {
            MipMapCount = mipMapCount;
            PixelFormat = pixelFormat;
            Size = image.Size;
            ChangeImageProbably(image, mipMapCount, pixelFormat, unkBool1);
        }

        private void Load(Stream stream, bool leaveOpen)
        {
            var binaryReader = new BinaryReader(stream);
            if (new string(binaryReader.ReadChars(4)) != "DDS ")
            {
                throw new FileLoadException("Invalid DDS file");
            }
            DdsHeader header;
            header.size = binaryReader.ReadUInt32();
            header.Flags = binaryReader.ReadUInt32();
            header.Height = binaryReader.ReadUInt32();
            header.Width = binaryReader.ReadUInt32();
            header.PitchOrLinearSize = binaryReader.ReadUInt32();
            header.Depth = binaryReader.ReadUInt32();
            header.mipMapCount = binaryReader.ReadUInt32();

            binaryReader.ReadBytes(44);
            header.pixelFormat.size = binaryReader.ReadUInt32();
            header.pixelFormat.Flags = binaryReader.ReadUInt32();
            header.pixelFormat.FourCc = binaryReader.ReadUInt32();
            header.pixelFormat.RgbBitCount = binaryReader.ReadUInt32();
            header.pixelFormat.RedBitMask = binaryReader.ReadUInt32();
            header.pixelFormat.GreenBitMask = binaryReader.ReadUInt32();
            header.pixelFormat.BlueBitMask = binaryReader.ReadUInt32();
            header.pixelFormat.AlphaBitMask = binaryReader.ReadUInt32();
            header.Unk1 = binaryReader.ReadUInt32();
            header.Unk2 = binaryReader.ReadUInt32();
            binaryReader.ReadBytes(12);

            if (header.size == 124u)
            {
                if (header.pixelFormat.size == 32u)
                {
                    if ((header.Flags & 131072u) != 0u)
                    {
                        MipMapCount = (int) header.mipMapCount;
                    }
                    else
                    {
                        MipMapCount = 1;
                    }
                    Size = new Size((int) header.Width, (int) header.Height);
                    if ((header.pixelFormat.Flags & 4u) != 0u)
                    {
                        var uint_ = header.pixelFormat.FourCc;
                        if (uint_ > 116u)
                        {
                            if (uint_ <= 844388420u)
                            {
                                if (uint_ == 827611204u)
                                {
                                    PixelFormat = ImgPixelFormat.Dxt1;
                                    Bpp = 8;
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
                                PixelFormat = ImgPixelFormat.Dxt5;
                                Bpp = 16;
                                goto IL_3BE;
                            }
                            PixelFormat = ImgPixelFormat.Dxt3;
                            Bpp = 16;
                            goto IL_3BE;
                        }
                        if (uint_ <= 28u)
                        {
                            switch (uint_)
                            {
                                case 20u:
                                    PixelFormat = ImgPixelFormat.Bgr24;
                                    Bpp = 3;
                                    goto IL_3BE;
                                case 21u:
                                    PixelFormat = ImgPixelFormat.Bgra32;
                                    Bpp = 4;
                                    goto IL_3BE;
                                case 22u:
                                    break;
                                case 23u:
                                    PixelFormat = ImgPixelFormat.Bgr16;
                                    Bpp = 2;
                                    goto IL_3BE;
                                default:
                                    if (uint_ == 28u)
                                    {
                                        PixelFormat = ImgPixelFormat.Alpha8;
                                        Bpp = 1;
                                        goto IL_3BE;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            if (uint_ == 50u)
                            {
                                PixelFormat = ImgPixelFormat.Luminance8;
                                Bpp = 1;
                                goto IL_3BE;
                            }
                            if (uint_ == 113u)
                            {
                                PixelFormat = ImgPixelFormat.Rgba64Float;
                                Bpp = 8;
                                goto IL_3BE;
                            }
                            if (uint_ == 116u)
                            {
                                PixelFormat = ImgPixelFormat.Rgba128Float;
                                Bpp = 16;
                                goto IL_3BE;
                            }
                        }
                        IL_2D5:
                        PixelFormat = ImgPixelFormat.Bgra32;
                        Bpp = 4;
                    }
                    else
                    {
                        if (header.pixelFormat.RgbBitCount == 8u && header.pixelFormat.AlphaBitMask == 255u)
                        {
                            PixelFormat = ImgPixelFormat.Alpha8;
                            Bpp = 1;
                        }
                        if (header.pixelFormat.RgbBitCount == 32u && header.pixelFormat.RedBitMask == 16711680u &&
                            header.pixelFormat.GreenBitMask == 65280u && header.pixelFormat.BlueBitMask == 255u &&
                            header.pixelFormat.AlphaBitMask == 4278190080u)
                        {
                            PixelFormat = ImgPixelFormat.Bgra32;
                            Bpp = 4;
                        }
                        if (Bpp == 0)
                        {
                            throw new FileLoadException("Invalid Texture Format");
                        }
                    }
                    IL_3BE:
                    var array = new byte[header.Width * header.Height * (uint) Bpp];
                    stream.Read(array, 0, array.Length);
                    Data = array;
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
            var bitmap = new Bitmap(Size.Width, Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            if (PixelFormat == ImgPixelFormat.Bgra32)
            {
                var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadWrite, bitmap.PixelFormat);
                Marshal.Copy(Data, 0, bitmapData.Scan0, bitmapData.Stride * bitmap.Height);
                bitmap.UnlockBits(bitmapData);
                var stream = new MemoryStream();
                bitmap.Save(stream, ImageFormat.Bmp);
                return Image.FromStream(stream);
            }
            if (PixelFormat != ImgPixelFormat.Dxt1 && PixelFormat != ImgPixelFormat.Dxt3)
            {
                if (PixelFormat != ImgPixelFormat.Dxt5)
                {
                    throw new Exception("Can't decode DDS, Unknown format: " + PixelFormat);
                }
            }
            var unk = new ImageRelatedClass(bitmap);
            unk.method_4();
            var binaryReader = new BinaryReader(new MemoryStream(Data));
            ZzTextureClass.smethod_17(binaryReader, unk, PixelFormat);
            binaryReader.Close();
            unk.method_5(true);
            var stream2 = new MemoryStream();
            bitmap.Save(stream2, ImageFormat.Bmp);
            return Image.FromStream(stream2);
        }

        int ClampMipMaps(int mipMapCount, int width, int height)
        {
            var minDimension = Math.Min(width, height);

            while ((1 << mipMapCount) > minDimension)
                --mipMapCount;

            return mipMapCount;
        }


        public void ChangeImageProbably(Image img, int mipMaps, ImgPixelFormat imgpixelFormat1, bool bool0)
        {
            var memoryStream = new MemoryStream();
            var binaryWriter = new BinaryWriter(memoryStream);

            mipMaps = ClampMipMaps(MipMapCount, img.Width, img.Height);

            //Generate mipmaps
            for (var i = 0; i < mipMaps; i++)
            {
                var bitmap =
                    KeyGenerator.ScaleImageFixedRatio(img, Math.Max(1, img.Width >> i), Math.Max(1, img.Height >> i));
                if (imgpixelFormat1 == ImgPixelFormat.Bgra32)
                {
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        ImageLockMode.ReadWrite, bitmap.PixelFormat);
                    var array = new byte[bitmapData.Stride * bitmap.Height];
                    Marshal.Copy(bitmapData.Scan0, array, 0, array.Length);
                    bitmap.UnlockBits(bitmapData);
                    binaryWriter.Write(array);
                }
                else
                {
                    ZzTextureClass.smethod_16(bitmap, binaryWriter, imgpixelFormat1, bool0);
                }
            }
            MipMapCount = mipMaps;
            PixelFormat = imgpixelFormat1;
            Data = memoryStream.ToArray();
        }

        public byte[] ToByteArray()
        {
            var memoryStream = new MemoryStream();
            WriteDds(memoryStream);
            return memoryStream.ToArray();
        }

        public void WriteDds(Stream stream, bool leaveOpen = false)
        {
            var binaryWriter = new BinaryWriter(stream);
            binaryWriter.Write(0x20534444); // DDS Magic word
            binaryWriter.Write(124); // size (why is this a constant?..)
            binaryWriter.Write(135175); // flags
            binaryWriter.Write(Size.Height); // height
            binaryWriter.Write(Size.Width); // width
            binaryWriter.Write(new byte[8]); // pitchOrLinearSize, Depth
            binaryWriter.Write(MipMapCount); // Mip maps
            binaryWriter.Write(new byte[44]); // reserved

            //Pixel Format
            binaryWriter.Write(32); //size 
            if (PixelFormat == ImgPixelFormat.Bgra32)
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
                    case ImgPixelFormat.Dxt1:
                        binaryWriter.Write(827611204);
                        break;
                    case ImgPixelFormat.Dxt3:
                        binaryWriter.Write(861165636);
                        break;
                    case ImgPixelFormat.Dxt5:
                        binaryWriter.Write(894720068);
                        break;
                    default:
                        throw new Exception("DDS Creation: Format unknown");
                }
                binaryWriter.Write(new byte[20]);
                binaryWriter.Write(4198408);
                binaryWriter.Write(new byte[16]);
            }
            binaryWriter.Write(Data);
            if (!leaveOpen)
            {
                binaryWriter.Close();
            }
        }
    }
}