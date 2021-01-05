using System;
using System.Collections.Generic;
using GHNamespace9;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceF;

namespace GHNamespaceA
{
    //Changes default high score names + a few other things like mem card limit

    public class QbDatabaseInitialModifier : QbEditor
    {
        private readonly ZzPakNode2 _pakNode;

        private bool _qbDatabaseAlreadyEdited;

        private readonly bool _bool1;

        public QbDatabaseInitialModifier(ZzPakNode2 class3181, bool bool2)
        {
            _pakNode = class3181;
            _bool1 = bool2;
        }

        public override void CreateCustomMenu()
        {
            Console.WriteLine("-=- " + ToString() + " -=-");
            ZzGenericNode1 @class = _pakNode.ZzGetNode1("scripts\\guitar\\guitar_globaltags.qb");
            string[] array =
            {
                "Invo",
                "tma",
                "TomPudding",
                "MaXKilleR",
                "GameZelda"
            };
            string[] array2 =
            {
                "D. Stowater",
                "Ginkel",
                "Bunny",
                "BMarvs",
                "CVance"
            };
            string[] array3 =
            {
                "C. Ward",
                "Riggs",
                "davidicus",
                "B. Wiuff",
                "Pam D."
            };
            KeyGenerator.smethod_56(array);
            Console.WriteLine("Randomized Names:");
            var num = 0;
            while (num < 5 && !_qbDatabaseAlreadyEdited)
            {
                Console.WriteLine(array[num]);
                var class2 = @class.zzFindNode(new UnicodeStructureNode("name" + (num + 1)));
                if (class2.method_8().Equals(_bool1 ? array3[num] : array2[num]))
                {
                    class2.method_9(array[num]);
                }
                else
                {
                    _qbDatabaseAlreadyEdited = true;
                    Console.WriteLine("QB Database is already edited.");
                }
                num++;
            }
            if (!_qbDatabaseAlreadyEdited)
            {
                ZzGenericNode1 class3 = _pakNode.ZzGetNode1("scripts\\guitar\\guitar_memcard.qb");
                Console.WriteLine("Changing Save File Size to 5MB.");
                class3.zzFindNode(new IntegerStructureNode("fixed_size")).method_9(5242880);
                Console.WriteLine("Changing Save Folder Name.");
                class3.zzFindNode(new UnicodeRootNode("memcard_content_name"))
                    .method_8(string.Format("Progress{0}", (new[]
                    {
                        "A",
                        "B",
                        "C",
                        "D",
                        "E",
                        "F"
                    })[new List<string>(new[]
                    {
                        "qb",
                        "qb_f",
                        "qb_i",
                        "qb_s",
                        "qb_g",
                        "qb_k"
                    }).IndexOf(KeyGenerator.GetFileNameNoExt(_pakNode.String0))]));
            }
            if (!_qbDatabaseAlreadyEdited)
            {
                ZzGenericNode1 class4 = _pakNode.ZzGetNode1("scripts\\guitar\\menu\\menu_setlist.qb");
                Console.WriteLine("Changing Setlist Scroller.");
                zzEmbeddedResourceDB.unpackQbScriptTo(class4.zzFindNode(new ScriptRootNode("setlist_scroll")));
                Console.WriteLine("Changing Tier Name Display.");
                zzEmbeddedResourceDB.unpackQbScriptTo(class4.zzFindNode(new ScriptRootNode("create_sl_assets")));
            }
            if (!_qbDatabaseAlreadyEdited)
            {
                ZzGenericNode1 node = _pakNode.ZzGetNode1("scripts\\guitar\\guitar.qb");
                node.zzFindNode(new StructurePointerNode("load_z_soundcheck"))
                    .zzFindNode(new UnicodeStructureNode("title"))
                    .method_9("Sound Check");
                node.zzFindNode(new StructurePointerNode("load_z_credits"))
                    .zzFindNode(new UnicodeStructureNode("title"))
                    .method_9("Guitar Hero Tower");
                node.zzFindNode(new StructurePointerNode("viewer"))
                    .zzFindNode(new UnicodeStructureNode("title"))
                    .method_9("Black Background");
                node.zzFindNode(new StructurePointerNode("load_z_viewer"))
                    .zzFindNode(new UnicodeStructureNode("title"))
                    .method_9("Black Background");
            }
        }

        public override string ToString()
        {
            return "Modify Default Data";
        }

        public override bool Equals(QbEditor other)
        {
            return other is QbDatabaseInitialModifier;
        }
    }
}