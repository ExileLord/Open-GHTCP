using System;
using GHNamespace9;
using GHNamespaceB;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespace8
{
    public class Class249 : QbEditor
    {
        private readonly ZzPakNode2 _class3180;

        public Class249(ZzPakNode2 class3181)
        {
            _class3180 = class3181;
        }

        public override void CreateCustomMenu()
        {
            Console.WriteLine("-=- " + ToString() + " -=-");
            ZzGenericNode1 @class = _class3180.ZzGetNode1("scripts\\guitar\\menu\\menu_cheats.qb");
            foreach (var current in @class.zzFindNode(new ArrayPointerRootNode("guitar_hero_cheats"))
                .method_7()
                .method_8<StructureHeaderNode>())
            {
                var flag = current.zzFindNode(new StructItemQbKey("name", "unlockall")) != null;
                var flag2 = current.zzFindNode(new StructItemQbKey("name", "unlockalleverything")) != null;
                var class2 = current.zzFindNode(new ArrayPointerNode("unlock_pattern")).GetFirstChild() as IntegerArrayNode;
                if (class2.Nodes.Count == 1)
                {
                    Console.WriteLine("QB Database is already edited.");
                    break;
                }
                class2.method_12(new[]
                {
                    flag ? 4096 : (flag2 ? 256 : 65536)
                });
            }
        }

        public override string ToString()
        {
            return "Modify Cheats";
        }

        public override bool Equals(QbEditor other)
        {
            return other is Class249;
        }
    }
}