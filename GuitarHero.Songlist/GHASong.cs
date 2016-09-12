using ns15;
using ns18;
using ns19;
using ns20;
using ns21;
using System;

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
			this.vmethod_4(class302_0);
		}

		public GHASong(string string_0)
		{
			this.title = string_0;
			this.name = string_0;
			this.leaderboard = true;
			this.editable = true;
		}

		public override void vmethod_0(Interface16 interface16_0)
		{
			base.vmethod_0(interface16_0);
			if (interface16_0 is GHASong)
			{
				GHASong gHASong = interface16_0 as GHASong;
				gHASong.covered_by = this.covered_by;
				gHASong.band = this.band;
				gHASong.guitarist_checksum = this.guitarist_checksum;
				gHASong.singer_anim_pak = this.singer_anim_pak;
				gHASong.thin_fretbar_8note_params_high_bpm = this.thin_fretbar_8note_params_high_bpm;
				gHASong.perry_mic_stand = this.perry_mic_stand;
			}
		}

		public override void vmethod_4(StructurePointerNode class302_0)
		{
			base.vmethod_4(class302_0);
			UnicodeStructureNode @class;
			this.covered_by = (((@class = class302_0.method_5<UnicodeStructureNode>(new UnicodeStructureNode("covered_by"))) != null) ? @class.method_8() : "");
			TagStructureNode class2;
			this.band = (((class2 = class302_0.method_5<TagStructureNode>(new TagStructureNode("band"))) != null) ? class2.method_8() : "default_band");
			this.guitarist_checksum = ((class2 = class302_0.method_5<TagStructureNode>(new TagStructureNode("guitarist_checksum"))) != null && class2.method_8() == "aerosmith");
			Class305 class3;
			this.singer_anim_pak = (((class3 = class302_0.method_5<Class305>(new Class305("singer_anim_pak"))) != null) ? class3.method_8() : "");
			IntegerStructureNode class4;
			this.thin_fretbar_8note_params_high_bpm = (((class4 = class302_0.method_5<IntegerStructureNode>(new IntegerStructureNode("thin_fretbar_8note_params_high_bpm"))) != null) ? class4.method_8() : 0);
			this.perry_mic_stand = ((class4 = class302_0.method_5<IntegerStructureNode>(new IntegerStructureNode("perry_mic_stand"))) != null && class4.method_8() == 1);
		}

		public override StructurePointerNode vmethod_5()
		{
			StructurePointerNode @class = base.vmethod_5();
			StructureHeaderNode class2 = @class.method_8();
			if (!this.covered_by.Equals(""))
			{
				class2.method_3(new UnicodeStructureNode("covered_by", this.covered_by));
			}
			class2.method_3(new TagStructureNode("band", this.band));
			if (this.guitarist_checksum)
			{
				class2.method_3(new TagStructureNode("guitarist_checksum", "aerosmith"));
			}
			if (!this.singer_anim_pak.Equals(""))
			{
				class2.method_3(new Class305("singer_anim_pak", this.singer_anim_pak));
			}
			if (this.thin_fretbar_8note_params_high_bpm != 0)
			{
				class2.method_3(new IntegerStructureNode("band_playback_volume", this.thin_fretbar_8note_params_high_bpm));
			}
			if (this.perry_mic_stand)
			{
				class2.method_3(new IntegerStructureNode("band_playback_volume", 1));
			}
			return @class;
		}
	}
}
