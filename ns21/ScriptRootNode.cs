using System.Drawing;
using ns16;
using ns18;
using ns20;

namespace ns21
{
	public class ScriptRootNode : zzUnkNode260
	{
		public ScriptRootNode()
		{
			vmethod_0();
		}

		public ScriptRootNode(string string_0) : this(QbSongClass1.AddKeyToDictionary(string_0))
		{
		}

		public ScriptRootNode(int int_2)
		{
			int_0 = int_2;
			vmethod_0();
		}

		public ScriptRootNode(string string_0, string string_1, QbScriptNode class275_0) : this(QbSongClass1.AddKeyToDictionary(string_0), QbSongClass1.AddKeyToDictionary(string_1), class275_0)
		{
		}

		public ScriptRootNode(int int_2, int int_3, QbScriptNode class275_0)
		{
			int_0 = int_2;
			int_1 = int_3;
			Nodes.Add(class275_0);
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 5;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			int_0 = stream26_0.ReadInt();
			int_1 = stream26_0.ReadInt();
			var num = stream26_0.ReadInt();
			stream26_0.ReadInt();
			if (num != 0)
			{
				stream26_0.Position = num;
				var @class = new QbScriptNode();
				Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			var array = new byte[4];
            array[1] = (byte)(vmethod_7() ? 32 : 4);
			array[2] = 7;
			stream26_0.WriteByteArray(array, false);
			stream26_0.WriteInt(int_0);
			stream26_0.WriteInt(int_1);
			stream26_0.WriteInt((Nodes.Count != 0) ? ((int)stream26_0.Position + 8) : 0);
			stream26_0.WriteInt(0);
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_14(stream26_0);
			}
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_2(ref int_2);
			}
		}

		public override string GetNodeText()
		{
			return "Script Root";
		}

		public QbScriptNode method_7()
		{
			return (QbScriptNode)Nodes[0];
		}

		public override Color vmethod_15()
		{
			return GetColor2IfPrevNodeIsColor1(Color.BlanchedAlmond, Color.Cornsilk);
		}
	}
}
