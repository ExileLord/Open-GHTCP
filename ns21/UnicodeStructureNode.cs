using ns16;
using ns18;
using ns19;
using ns20;

namespace ns21
{
	public class UnicodeStructureNode : zzUnkNode294
	{
		public UnicodeStructureNode()
		{
			vmethod_0();
		}

		public UnicodeStructureNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public UnicodeStructureNode(int int_1)
		{
			int_0 = int_1;
			vmethod_0();
		}

		public UnicodeStructureNode(string string_0, string string_1) : this(QbSongClass1.AddKeyToDictionary(string_0), string_1)
		{
		}

		public UnicodeStructureNode(int int_1, string string_0)
		{
			int_0 = int_1;
			Nodes.Add(new UnicodeValueNode(string_0));
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 22;
		}

		public string method_8()
		{
			if (Nodes.Count != 0)
			{
				return ((UnicodeValueNode)FirstNode).string_0;
			}
			return null;
		}

		public void method_9(string string_0)
		{
			if (Nodes.Count != 0)
			{
				((UnicodeValueNode)FirstNode).string_0 = string_0;
				return;
			}
			Nodes.Add(new UnicodeValueNode(string_0));
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			int_0 = stream26_0.ReadInt();
			var num = stream26_0.ReadInt();
			var num2 = stream26_0.ReadInt();
			if (num != 0)
			{
				Nodes.Add(new UnicodeValueNode(stream26_0.ReadUnicodeStringAt(num)));
				stream26_0.Position += smethod_0(stream26_0.Position);
			}
			if (num2 != 0)
			{
				var @class = (Parent is StructureHeaderNode) ? (Parent as StructureHeaderNode).method_11(stream26_0.ReadIntAt(num2)) : vmethod_12(stream26_0.ReadIntAt(num2, true));
				method_1().Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			if (vmethod_8())
			{
				var array = new byte[4];
				array[1] = 1;
				array[2] = 4;
				stream26_0.WriteByteArray(array, false);
			}
			else
			{
				var array2 = new byte[4];
                array2[1] = (vmethod_7() ? (byte)132 : (byte)9);
				stream26_0.WriteByteArray(array2, false);
			}
			stream26_0.WriteInt(int_0);
			var int_ = (int)stream26_0.Position + 4;
			if (Nodes.Count != 0)
			{
				stream26_0.WriteInt((int)stream26_0.Position + 8);
				stream26_0.WriteInt(0);
				stream26_0.WriteString(method_8(), stream26_0._reverseEndianness);
				stream26_0.WriteNBytes(0, 2);
				stream26_0.WriteNBytes(0, smethod_0(stream26_0.Position));
			}
			else
			{
				stream26_0.WriteInt(0);
			}
			var num = (int)stream26_0.Position;
			if (method_1().Nodes.IndexOf(this) < method_1().Nodes.Count - 1)
			{
				stream26_0.WriteIntAt(int_, num);
			}
			else
			{
				stream26_0.WriteIntAt(int_, 0);
			}
			stream26_0.Position = num;
		}

		public override string GetNodeText()
		{
			return "Unicode Structure";
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 16;
			if (Nodes.Count != 0)
			{
				((UnicodeValueNode)Nodes[0]).vmethod_2(ref int_1);
				int_1 += 2;
				int_1 += smethod_0(int_1);
			}
		}
	}
}
