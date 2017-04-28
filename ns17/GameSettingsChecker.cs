using System;
using System.Reflection;
using System.Windows.Forms;
using ns16;
using ns18;
using ns19;
using ns20;
using ns21;

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

		private static readonly string _hashPath = "script\\ghtcp\\ghtcp.hash";

		public bool GameSettingsAreValid()
		{
			return _LoadedSuccessfully && _AssemblyVersionMatches && _GameSettingsUntampered;
		}

		public GameSettingsChecker(bool AlreadyLoaded)
		{
			_LoadedSuccessfully = AlreadyLoaded;
			_AssemblyVersionMatches = AlreadyLoaded;
			_GameSettingsUntampered = AlreadyLoaded;
		}

		public GameSettingsChecker(zzPakNode2 class318_0)
		{
			if (!class318_0.method_6(_hashPath))
			{
				return;
			}
			var @class = new zzGenericNode1(_hashPath, KeyGenerator.smethod_8(class318_0.method_12(_hashPath), "MaC39SubInfo1245"));
			version = new Version(@class.method_5(new UnicodeRootNode("version")).method_7());
			var array = @class.method_5(new ArrayPointerRootNode("date")).method_7().method_7<float>();
			date = new DateTime((int)array[0], (int)array[1], (int)array[2]);
			unkBuffer = @class.method_5(new ArrayPointerRootNode("hash")).method_7().method_7<int>();
			class318_0.method_7(_hashPath);
			using (var stream = class318_0.method_17())
			{
				stream.Position = 0L;
                // Ignore checks for external tools modifying game settings because we're not children who will dictate how people can play their game
                // Possibly turn this on later softly for warning the player of possible data integrity issues
                // this._GameSettingsUntampered = Class244.smethod_53<int>(Class244.smethod_21(Class244.smethod_43(stream.stream_0)), this.int_0);
                _GameSettingsUntampered = true;
			}
			GC.Collect();
			_AssemblyVersionMatches = (Assembly.GetExecutingAssembly().GetName().Version.CompareTo(version) == 0);
			_LoadedSuccessfully = true;
			if (!_AssemblyVersionMatches)
			{
				MessageBox.Show("The game settings were created under a different version.");
			}
			if (!_GameSettingsUntampered)
			{
				MessageBox.Show("The game settings were modified by an external tool!"); 
			}
		}

		public static void SignHash(zzPakNode2 pakNode)
		{
			if (pakNode.method_6(_hashPath))
			{
				pakNode.method_7(_hashPath);
			}
			var @class = new zzGenericNode1();
			@class.method_3(new UnicodeRootNode("version", _hashPath, Assembly.GetExecutingAssembly().GetName().Version.ToString()));
			using (var stream = pakNode.method_17())
			{
				stream.Position = 0L;
				@class.method_3(new ArrayPointerRootNode("hash", _hashPath, new IntegerArrayNode(KeyGenerator.smethod_21(KeyGenerator.HashStream(stream._stream)))));
			}
			GC.Collect();
			var now = DateTime.Now;
			@class.method_3(new ArrayPointerRootNode("date", _hashPath, new FloatArrayNode(new[]
			{
				now.Year,
				now.Month,
				(float)now.Day
			})));
			pakNode.method_1(_hashPath, new zzCocoaNode12(_hashPath, KeyGenerator.smethod_2(@class.method_8(), "MaC39SubInfo1245")));
		}
	}
}
