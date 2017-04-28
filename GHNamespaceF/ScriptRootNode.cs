using System.Drawing;
using GHNamespace9;
using GHNamespaceB;
using GHNamespaceE;

namespace GHNamespaceF
{
	public class ScriptRootNode : ZzUnkNode260
	{
		public ScriptRootNode()
		{
			vmethod_0();
		}

		public ScriptRootNode(string string0) : this(QbSongClass1.AddKeyToDictionary(string0))
		{
		}

		public ScriptRootNode(int int2)
		{
			Int0 = int2;
			vmethod_0();
		}

		public ScriptRootNode(string string0, string string1, QbScriptNode class2750) : this(QbSongClass1.AddKeyToDictionary(string0), QbSongClass1.AddKeyToDictionary(string1), class2750)
		{
		}

		public ScriptRootNode(int int2, int int3, QbScriptNode class2750)
		{
			Int0 = int2;
			Int1 = int3;
			Nodes.Add(class2750);
			vmethod_0();
		}

		public override int vmethod_1()
		{
			return 5;
		}

		public override void vmethod_13(Stream26 stream260)
		{
			Int0 = stream260.ReadInt();
			Int1 = stream260.ReadInt();
			var num = stream260.ReadInt();
			stream260.ReadInt();
			if (num != 0)
			{
				stream260.Position = num;
				var @class = new QbScriptNode();
				Nodes.Add(@class);
				@class.method_4(stream260);
			}
		}

		public override void vmethod_14(Stream26 stream260)
		{
			var array = new byte[4];
            array[1] = (byte)(vmethod_7() ? 32 : 4);
			array[2] = 7;
			stream260.WriteByteArray(array, false);
			stream260.WriteInt(Int0);
			stream260.WriteInt(Int1);
			stream260.WriteInt((Nodes.Count != 0) ? ((int)stream260.Position + 8) : 0);
			stream260.WriteInt(0);
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_14(stream260);
			}
		}

		public override void vmethod_2(ref int int2)
		{
			int2 += 20;
			foreach (AbstractTreeNode1 @class in Nodes)
			{
				@class.vmethod_2(ref int2);
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
