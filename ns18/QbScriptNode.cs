using System;
using System.Drawing;
using ns16;
using ns19;
using ns20;

namespace ns18
{
	public class QbScriptNode : AbstractTreeNode1
	{
		public byte[] Byte0;

		public int Int0;

		public QbScriptNode()
		{
			Int0 = -1;
			Byte0 = new byte[]
			{
				1,
				36
			};
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 36;
		}

		public override void vmethod_13(Stream26 stream260)
		{
			Int0 = stream260.ReadInt();
			var num = stream260.ReadInt();
			var num2 = stream260.ReadInt();
			var byte_ = stream260.ReadBytes(num2, false);
			if (num == num2)
			{
				Byte0 = byte_;
			}
			else
			{
				Byte0 = new Class320().method_4(byte_);
			}
			stream260.Position += smethod_0(stream260.Position);
		}

		public override void vmethod_14(Stream26 stream260)
		{
			stream260.WriteInt(Int0);
			stream260.WriteInt(Byte0.Length);
			var array = new Class320().method_0(Byte0);
			if (Byte0.Length <= array.Length)
			{
				array = Byte0;
			}
			stream260.WriteInt(array.Length);
			stream260.WriteByteArray(array, false);
			stream260.WriteNBytes(0, smethod_0(stream260.Position));
		}

		public override int CompareTo(object target)
		{
			if (!(target is QbScriptNode))
			{
				return -1;
			}
			if (((QbScriptNode)target).Int0 == Int0)
			{
				return 0;
			}
			return 1;
		}

		public override string GetText()
		{
			if (QbSongClass1.ContainsKey(Int0))
			{
				return QbSongClass1.GetDictString(Int0) + " (Script)";
			}
			return KeyGenerator.ValToHex32Bit(Int0) + " (Script Tag)";
		}

		public void method_7(byte[] byte1)
		{
			Byte0 = byte1;
		}

		public override string GetNodeText()
		{
			return "QB Script";
		}

		public override void vmethod_2(ref int int1)
		{
			int1 += 12;
			if (Byte0 != null)
			{
				var array = new Class320().method_0(Byte0);
				if (Byte0.Length <= array.Length)
				{
					array = Byte0;
				}
				int1 += array.Length;
			}
			int1 += smethod_0(int1);
		}

		public override object Clone()
		{
			var @class = (QbScriptNode)base.Clone();
			@class.Int0 = Int0;
			@class.Byte0 = new byte[Byte0.Length];
			Buffer.BlockCopy(Byte0, 0, @class.Byte0, 0, Byte0.Length);
			return @class;
		}

		public override Color GetColor()
		{
			return Color.Pink;
		}

		public override string GetToolTipText()
		{
			if (Byte0 != null)
			{
				return Byte0.Length + " QB Script Bytes";
			}
			return "No QB Script Bytes";
		}
	}
}
