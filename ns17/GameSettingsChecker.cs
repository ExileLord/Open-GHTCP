using ns16;
using ns18;
using ns19;
using ns20;
using ns21;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace ns17
{
	public class GameSettingsChecker
	{
		public readonly DateTime date;

		public readonly Version version;

		public readonly int[] unkBuffer;

		public readonly bool _GameSettingsUntampered;

		public readonly bool _AssemblyVersionMatches;

		public readonly bool _LoadedSuccessfully;

		private static string _hashPath = "script\\ghtcp\\ghtcp.hash";

		public bool GameSettingsAreValid()
		{
			return this._LoadedSuccessfully && this._AssemblyVersionMatches && this._GameSettingsUntampered;
		}

		public GameSettingsChecker(bool AlreadyLoaded)
		{
			this._LoadedSuccessfully = AlreadyLoaded;
			this._AssemblyVersionMatches = AlreadyLoaded;
			this._GameSettingsUntampered = AlreadyLoaded;
		}

		public GameSettingsChecker(zzPakNode2 class318_0)
		{
			if (!class318_0.method_6(GameSettingsChecker._hashPath))
			{
				return;
			}
			zzGenericNode1 @class = new zzGenericNode1(GameSettingsChecker._hashPath, KeyGenerator.smethod_8(class318_0.method_12(GameSettingsChecker._hashPath), "MaC39SubInfo1245"));
			this.version = new Version(@class.method_5<UnicodeRootNode>(new UnicodeRootNode("version")).method_7());
			float[] array = @class.method_5<ArrayPointerRootNode>(new ArrayPointerRootNode("date")).method_7().method_7<float>();
			this.date = new DateTime((int)array[0], (int)array[1], (int)array[2]);
			this.unkBuffer = @class.method_5<ArrayPointerRootNode>(new ArrayPointerRootNode("hash")).method_7().method_7<int>();
			class318_0.method_7(GameSettingsChecker._hashPath);
			using (Stream26 stream = class318_0.method_17())
			{
				stream.Position = 0L;
                // Ignore checks for external tools modifying game settings because we're not children who will dictate how people can play their game
                // Possibly turn this on later softly for warning the player of possible data integrity issues
                // this._GameSettingsUntampered = Class244.smethod_53<int>(Class244.smethod_21(Class244.smethod_43(stream.stream_0)), this.int_0);
                this._GameSettingsUntampered = true;
			}
			GC.Collect();
			this._AssemblyVersionMatches = (Assembly.GetExecutingAssembly().GetName().Version.CompareTo(this.version) == 0);
			this._LoadedSuccessfully = true;
			if (!this._AssemblyVersionMatches)
			{
				MessageBox.Show("The game settings were created under a different version.");
			}
			if (!this._GameSettingsUntampered)
			{
				MessageBox.Show("The game settings were modified by an external tool!"); 
			}
		}

		public static void SignHash(zzPakNode2 pakNode)
		{
			if (pakNode.method_6(GameSettingsChecker._hashPath))
			{
				pakNode.method_7(GameSettingsChecker._hashPath);
			}
			zzGenericNode1 @class = new zzGenericNode1();
			@class.method_3(new UnicodeRootNode("version", GameSettingsChecker._hashPath, Assembly.GetExecutingAssembly().GetName().Version.ToString()));
			using (Stream26 stream = pakNode.method_17())
			{
				stream.Position = 0L;
				@class.method_3(new ArrayPointerRootNode("hash", GameSettingsChecker._hashPath, new IntegerArrayNode(KeyGenerator.smethod_21(KeyGenerator.HashStream(stream.stream_0)))));
			}
			GC.Collect();
			DateTime now = DateTime.Now;
			@class.method_3(new ArrayPointerRootNode("date", GameSettingsChecker._hashPath, new FloatArrayNode(new float[]
			{
				(float)now.Year,
				(float)now.Month,
				(float)now.Day
			})));
			pakNode.method_1<zzCocoaNode12>(GameSettingsChecker._hashPath, new zzCocoaNode12(GameSettingsChecker._hashPath, KeyGenerator.smethod_2(@class.method_8(), "MaC39SubInfo1245")));
		}
	}
}
