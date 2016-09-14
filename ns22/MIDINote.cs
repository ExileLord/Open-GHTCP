using ns9;
using System;

namespace ns22
{
	public class MIDINote : AbstractNoteClass
	{
		private readonly int midiMask;

		private readonly byte byte_0;

		private readonly bool bool_0 = true;

		public MIDINote(int int_2, int int_3, byte byte_1, bool bool_1)
		{
			this.int_0 = int_2;
			this.midiMask = int_3;
			this.byte_0 = byte_1;
			this.bool_0 = bool_1;
		}

		public Difficulty getDifficulty()
		{
			if (this.midiMask >= 60 && this.midiMask <= 106)
			{
				return (Difficulty)((this.midiMask - 60) / 12);
			}
			return Difficulty.Invalid;
		}

		public MIDINoteMask method_2()
		{
			if (this.midiMask == 108)
			{
				return MIDINoteMask.Unk108;
			}
            //SP
			if (this.midiMask == 116)
			{
				return MIDINoteMask.StarPower;
			}
            //I assume nothing
			if (this.midiMask < 60 || this.midiMask > 106)
			{
				return MIDINoteMask.Invalid;
			}
            //Gets note type
			int num = (this.midiMask - 60) % 12;
			if (Enum.IsDefined(typeof(MIDINoteMask), num))
			{
				return (MIDINoteMask)num;
			}
			return MIDINoteMask.Invalid;
		}

		public Fret method_3()
		{
			if (this.midiMask < 60 || this.midiMask > 106)
			{
				return Fret.Invalid;
			}
			Fret @enum = (Fret)((this.midiMask - 60) % 12);
			if (@enum >= Fret.Green && @enum <= Fret.Orange)
			{
				return @enum;
			}
			return Fret.Invalid;
		}

		public int method_4()
		{
			return this.midiMask;
		}

		public bool method_5()
		{
			return this.byte_0 > 0 && this.bool_0;
		}

		public override string ToString()
		{
			return string.Format("{0}: NoteId {1} ({2} {3})", new object[]
			{
				base.method_0(),
				this.midiMask,
				this.byte_0,
				this.bool_0 ? "On" : "Off"
			});
		}
	}
}
