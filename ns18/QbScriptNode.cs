using System;
using System.Drawing;
using ns16;
using ns19;
using ns20;

namespace ns18
{
	public class QbScriptNode : AbstractTreeNode1
	{
		public byte[] byte_0;

		public int int_0;

		public QbScriptNode()
		{
			int_0 = -1;
			byte_0 = new byte[]
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

		public override void vmethod_13(Stream26 stream26_0)
		{
			int_0 = stream26_0.ReadInt();
			int num = stream26_0.ReadInt();
			int num2 = stream26_0.ReadInt();
			byte[] byte_ = stream26_0.ReadBytes(num2, false);
			if (num == num2)
			{
				byte_0 = byte_;
			}
			else
			{
				byte_0 = new Class320().method_4(byte_);
			}
			stream26_0.Position += smethod_0(stream26_0.Position);
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			stream26_0.WriteInt(int_0);
			stream26_0.WriteInt(byte_0.Length);
			byte[] array = new Class320().method_0(byte_0);
			if (byte_0.Length <= array.Length)
			{
				array = byte_0;
			}
			stream26_0.WriteInt(array.Length);
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteNBytes(0, smethod_0(stream26_0.Position));
		}

		public override int CompareTo(object target)
		{
			if (!(target is QbScriptNode))
			{
				return -1;
			}
			if (((QbScriptNode)target).int_0 == int_0)
			{
				return 0;
			}
			return 1;
		}

		public override string GetText()
		{
			if (QbSongClass1.ContainsKey(int_0))
			{
				return QbSongClass1.GetDictString(int_0) + " (Script)";
			}
			return KeyGenerator.ValToHex32bit(int_0) + " (Script Tag)";
		}

		public void method_7(byte[] byte_1)
		{
			byte_0 = byte_1;
		}

		public override string GetNodeText()
		{
			return "QB Script";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 12;
			if (byte_0 != null)
			{
				byte[] array = new Class320().method_0(byte_0);
				if (byte_0.Length <= array.Length)
				{
					array = byte_0;
				}
				int_1 += array.Length;
			}
			int_1 += smethod_0(int_1);
		}

		public override object Clone()
		{
			QbScriptNode @class = (QbScriptNode)base.Clone();
			@class.int_0 = int_0;
			@class.byte_0 = new byte[byte_0.Length];
			Buffer.BlockCopy(byte_0, 0, @class.byte_0, 0, byte_0.Length);
			return @class;
		}

		public override Color GetColor()
		{
			return Color.Pink;
		}

		public override string GetToolTipText()
		{
			if (byte_0 != null)
			{
				return byte_0.Length + " QB Script Bytes";
			}
			return "No QB Script Bytes";
		}
	}
}
