using NeversoftTools.Texture.DDS;
using ns16;
using ns21;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ns19
{
	public class Class322 : IDisposable
	{
		public List<Class331> list_0 = new List<Class331>();

		private Stream26 stream26_0;

		private string string_0;

		private bool bool_0 = true;

		public Class330 this[int int_0]
		{
			get
			{
				if (this.list_0[int_0].byte_1 != null)
				{
					return new Class330(new MemoryStream(this.list_0[int_0].byte_1));
				}
				this.stream26_0.Position = (long)this.list_0[int_0].int_1;
				return new Class330(this.stream26_0.stream_0, true);
			}
		}

		public Class322()
		{
		}

		public Class322(string string_1)
		{
			this.string_0 = string_1;
			this.method_0();
		}

		public Class322(byte[] byte_0)
		{
			this.stream26_0 = new Stream26(byte_0, true);
			this.method_0();
		}

		public void method_0()
		{
			if (this.string_0 != null)
			{
				this.stream26_0 = new Stream26(File.Open(this.string_0, FileMode.Open, FileAccess.Read, FileShare.Read), true);
			}
			int num = 1;
			ushort num2 = this.stream26_0.method_25();
			int num3 = 0;
			if (num2 == 64206)
			{
				this.bool_0 = false;
				num = (int)this.stream26_0.method_43(6);
				num3 = this.stream26_0.method_19();
			}
			else if (num2 != 2600)
			{
				throw new Exception();
			}
			while (num-- != 0)
			{
				this.list_0.Add(new Class331(this.stream26_0.method_43(num3 + 2), this.stream26_0.method_19(), this.stream26_0.method_23(), this.stream26_0.method_23(), this.stream26_0.method_23(), this.stream26_0.method_40(num3 + 20), this.stream26_0.method_23(), this.stream26_0.method_41(num3 + 28), this.stream26_0.method_19()));
				num3 += 40;
			}
			this.stream26_0.bool_0 = false;
		}

		public void method_1(int int_0, Image image_0, IMGPixelFormat imgpixelFormat_0)
		{
			Class331 @class = this.list_0[int_0];
			@class.short_2 = (short)image_0.Height;
			@class.short_1 = (short)image_0.Width;
			@class.byte_1 = new Class330(image_0, (int)@class.byte_0, imgpixelFormat_0).method_3();
		}

		public byte[] method_2(int int_0)
		{
			if (this.list_0[int_0].byte_1 != null)
			{
				return this.list_0[int_0].byte_1;
			}
			this.stream26_0.Position = (long)this.list_0[int_0].int_1;
			return this.stream26_0.method_31(this.list_0[int_0].int_2);
		}

		public void method_3(int int_0, string string_1)
		{
			KeyGenerator.smethod_9(string_1, this.method_2(int_0));
		}

		public int method_4()
		{
			return this.list_0.Count;
		}

		public bool method_5()
		{
			return this.stream26_0 != null && this.string_0 != null;
		}

		public void method_6()
		{
			if (this.stream26_0 == null || this.string_0 == null)
			{
				throw new IOException("Tex File was never parsed");
			}
			this.method_8(this.string_0);
		}

		public Stream26 method_7()
		{
			Stream26 stream = new Stream26(true);
			int num = this.method_4();
			int num2 = 0;
			if (!this.bool_0)
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
				Class331 @class = this.list_0[i];
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
			if (this.stream26_0 != null && this.string_0 == string_1)
			{
				this.stream26_0.Close();
			}
			stream.method_2(string_1);
			if (this.stream26_0 != null && this.string_0 == string_1)
			{
				this.Dispose();
				this.method_0();
				GC.Collect();
			}
		}

		public void Dispose()
		{
			this.stream26_0.Close();
			this.stream26_0.Dispose();
			this.stream26_0 = null;
			this.list_0.Clear();
		}
	}
}
