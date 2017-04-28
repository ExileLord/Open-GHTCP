using System;
using System.Reflection;
using System.Windows.Forms;
using GHNamespace9;
using GHNamespaceB;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespaceA
{
    public class GameSettingsChecker
    {
        public readonly DateTime Date;

        public readonly Version Version;

        public readonly int[] UnkBuffer;

        public readonly bool GameSettingsUntampered;

        public readonly bool AssemblyVersionMatches;

        public readonly bool LoadedSuccessfully;

        private static readonly string HashPath = "script\\ghtcp\\ghtcp.hash";

        public bool GameSettingsAreValid()
        {
            return LoadedSuccessfully && AssemblyVersionMatches && GameSettingsUntampered;
        }

        public GameSettingsChecker(bool alreadyLoaded)
        {
            LoadedSuccessfully = alreadyLoaded;
            AssemblyVersionMatches = alreadyLoaded;
            GameSettingsUntampered = alreadyLoaded;
        }

        public GameSettingsChecker(ZzPakNode2 class3180)
        {
            if (!class3180.method_6(HashPath))
            {
                return;
            }
            var @class = new ZzGenericNode1(HashPath,
                KeyGenerator.smethod_8(class3180.method_12(HashPath), "MaC39SubInfo1245"));
            Version = new Version(@class.method_5(new UnicodeRootNode("version")).method_7());
            var array = @class.method_5(new ArrayPointerRootNode("date")).method_7().method_7<float>();
            Date = new DateTime((int) array[0], (int) array[1], (int) array[2]);
            UnkBuffer = @class.method_5(new ArrayPointerRootNode("hash")).method_7().method_7<int>();
            class3180.method_7(HashPath);
            using (var stream = class3180.method_17())
            {
                stream.Position = 0L;
                // Ignore checks for external tools modifying game settings because we're not children who will dictate how people can play their game
                // Possibly turn this on later softly for warning the player of possible data integrity issues
                // this._GameSettingsUntampered = Class244.smethod_53<int>(Class244.smethod_21(Class244.smethod_43(stream.stream_0)), this.int_0);
                GameSettingsUntampered = true;
            }
            GC.Collect();
            AssemblyVersionMatches = (Assembly.GetExecutingAssembly().GetName().Version.CompareTo(Version) == 0);
            LoadedSuccessfully = true;
            if (!AssemblyVersionMatches)
            {
                MessageBox.Show("The game settings were created under a different version.");
            }
            if (!GameSettingsUntampered)
            {
                MessageBox.Show("The game settings were modified by an external tool!");
            }
        }

        public static void SignHash(ZzPakNode2 pakNode)
        {
            if (pakNode.method_6(HashPath))
            {
                pakNode.method_7(HashPath);
            }
            var @class = new ZzGenericNode1();
            @class.method_3(new UnicodeRootNode("version", HashPath,
                Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            using (var stream = pakNode.method_17())
            {
                stream.Position = 0L;
                @class.method_3(new ArrayPointerRootNode("hash", HashPath,
                    new IntegerArrayNode(KeyGenerator.smethod_21(KeyGenerator.HashStream(stream.Stream)))));
            }
            GC.Collect();
            var now = DateTime.Now;
            @class.method_3(new ArrayPointerRootNode("date", HashPath, new FloatArrayNode(new[]
            {
                now.Year,
                now.Month,
                (float) now.Day
            })));
            pakNode.method_1(HashPath,
                new ZzCocoaNode12(HashPath, KeyGenerator.smethod_2(@class.method_8(), "MaC39SubInfo1245")));
        }
    }
}