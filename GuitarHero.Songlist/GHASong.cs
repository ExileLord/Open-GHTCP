using System;
using ns15;
using ns18;
using ns19;
using ns20;
using ns21;

namespace GuitarHero.Songlist
{
	[Serializable]
	public class GHASong : GH3Song
	{
		public string covered_by = "Wavegroup";

		public string band = "default_band";

		public string singer_anim_pak = "";

		public int thin_fretbar_8note_params_high_bpm;

		public bool perry_mic_stand;

		public bool guitarist_checksum;

		public GHASong()
		{
		}

		public GHASong(StructurePointerNode class302_0)
		{
			vmethod_4(class302_0);
		}

		public GHASong(string string_0)
		{
			title = string_0;
			name = string_0;
			leaderboard = true;
			editable = true;
		}

		public override void vmethod_0(Interface16 interface16_0)
		{
			base.vmethod_0(interface16_0);
			if (interface16_0 is GHASong)
			{
				GHASong gHASong = interface16_0 as GHASong;
				gHASong.covered_by = covered_by;
				gHASong.band = band;
				gHASong.guitarist_checksum = guitarist_checksum;
				gHASong.singer_anim_pak = singer_anim_pak;
				gHASong.thin_fretbar_8note_params_high_bpm = thin_fretbar_8note_params_high_bpm;
				gHASong.perry_mic_stand = perry_mic_stand;
			}
		}

		public override void vmethod_4(StructurePointerNode class302_0)
		{
			base.vmethod_4(class302_0);
			UnicodeStructureNode @class;
			covered_by = (((@class = class302_0.method_5(new UnicodeStructureNode("covered_by"))) != null) ? @class.method_8() : "");
			TagStructureNode class2;
			band = (((class2 = class302_0.method_5(new TagStructureNode("band"))) != null) ? class2.method_8() : "default_band");
			guitarist_checksum = ((class2 = class302_0.method_5(new TagStructureNode("guitarist_checksum"))) != null && class2.method_8() == "aerosmith");
			AsciiStructureNode class3;
			singer_anim_pak = (((class3 = class302_0.method_5(new AsciiStructureNode("singer_anim_pak"))) != null) ? class3.method_8() : "");
			IntegerStructureNode class4;
			thin_fretbar_8note_params_high_bpm = (((class4 = class302_0.method_5(new IntegerStructureNode("thin_fretbar_8note_params_high_bpm"))) != null) ? class4.method_8() : 0);
			perry_mic_stand = ((class4 = class302_0.method_5(new IntegerStructureNode("perry_mic_stand"))) != null && class4.method_8() == 1);
		}

		public override StructurePointerNode vmethod_5()
		{
			StructurePointerNode @class = base.vmethod_5();
			StructureHeaderNode class2 = @class.method_8();
			if (!covered_by.Equals(""))
			{
				class2.method_3(new UnicodeStructureNode("covered_by", covered_by));
			}
			class2.method_3(new TagStructureNode("band", band));
			if (guitarist_checksum)
			{
				class2.method_3(new TagStructureNode("guitarist_checksum", "aerosmith"));
			}
			if (!singer_anim_pak.Equals(""))
			{
				class2.method_3(new AsciiStructureNode("singer_anim_pak", singer_anim_pak));
			}
			if (thin_fretbar_8note_params_high_bpm != 0)
			{
				class2.method_3(new IntegerStructureNode("band_playback_volume", thin_fretbar_8note_params_high_bpm));
			}
			if (perry_mic_stand)
			{
				class2.method_3(new IntegerStructureNode("band_playback_volume", 1));
			}
			return @class;
		}
	}
}
