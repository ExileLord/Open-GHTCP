using System;
using System.Collections.Generic;
using ns16;
using ns19;
using ns20;
using ns21;

namespace ns17
{
    //Changes default high score names + a few other things like mem card limit

	public class QbDatabaseInitialModifier : QbEditor
	{
		private readonly zzPakNode2 _pakNode;

		private bool QbDatabaseAlreadyEdited;

		private readonly bool bool_1;

		public QbDatabaseInitialModifier(zzPakNode2 class318_1, bool bool_2)
		{
			_pakNode = class318_1;
			bool_1 = bool_2;
		}

		public override void vmethod_0()
		{
			Console.WriteLine("-=- " + ToString() + " -=-");
			zzGenericNode1 @class = _pakNode.zzGetNode1("scripts\\guitar\\guitar_globaltags.qb");
			string[] array = {
				"Invo",
				"tma",
				"TomPudding",
				"MaXKilleR",
				"GameZelda"
			};
			string[] array2 = {
				"D. Stowater",
				"Ginkel",
				"Bunny",
				"BMarvs",
				"CVance"
			};
			string[] array3 = {
				"C. Ward",
				"Riggs",
				"davidicus",
				"B. Wiuff",
				"Pam D."
			};
			KeyGenerator.smethod_56(array);
			Console.WriteLine("Randomized Names:");
			var num = 0;
			while (num < 5 && !QbDatabaseAlreadyEdited)
			{
				Console.WriteLine(array[num]);
				var class2 = @class.method_5(new UnicodeStructureNode("name" + (num + 1)));
				if (class2.method_8().Equals(bool_1 ? array3[num] : array2[num]))
				{
					class2.method_9(array[num]);
				}
				else
				{
					QbDatabaseAlreadyEdited = true;
					Console.WriteLine("QB Database is already edited.");
				}
				num++;
			}
			if (!QbDatabaseAlreadyEdited)
			{
				zzGenericNode1 class3 = _pakNode.zzGetNode1("scripts\\guitar\\guitar_memcard.qb");
				Console.WriteLine("Changing Save File Size to 5MB.");
				class3.method_5(new IntegerStructureNode("fixed_size")).method_9(5242880);
				Console.WriteLine("Changing Save Folder Name.");
				class3.method_5(new UnicodeRootNode("memcard_content_name")).method_8(string.Format("Progress{0}", (new[]
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
				}).IndexOf(KeyGenerator.GetFileNameNoExt(_pakNode.string_0))]));
			}
			if (!QbDatabaseAlreadyEdited)
			{
				zzGenericNode1 class4 = _pakNode.zzGetNode1("scripts\\guitar\\menu\\menu_setlist.qb");
				Console.WriteLine("Changing Setlist Scroller.");
				zzQbScriptZipperClass.smethod_1(class4.method_5(new ScriptRootNode("setlist_scroll")));
				Console.WriteLine("Changing Tier Name Display.");
				zzQbScriptZipperClass.smethod_1(class4.method_5(new ScriptRootNode("create_sl_assets")));
			}
			if (!QbDatabaseAlreadyEdited)
			{
				zzGenericNode1 node = _pakNode.zzGetNode1("scripts\\guitar\\guitar.qb");
				node.method_5(new StructurePointerNode("load_z_soundcheck")).method_5(new UnicodeStructureNode("title")).method_9("Sound Check");
				node.method_5(new StructurePointerNode("load_z_credits")).method_5(new UnicodeStructureNode("title")).method_9("Guitar Hero Tower");
				node.method_5(new StructurePointerNode("viewer")).method_5(new UnicodeStructureNode("title")).method_9("Black Background");
				node.method_5(new StructurePointerNode("load_z_viewer")).method_5(new UnicodeStructureNode("title")).method_9("Black Background");
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
