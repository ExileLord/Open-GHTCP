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
			return Difficulty.const_4;
		}

		public MIDINoteMask method_2()
		{
			if (this.midiMask == 108)
			{
				return MIDINoteMask.const_9;
			}
            //SP
			if (this.midiMask == 116)
			{
				return MIDINoteMask.SP;
			}
            //I assume nothing
			if (this.midiMask < 60 || this.midiMask > 106)
			{
				return MIDINoteMask.const_10;
			}
            //Gets note type
			int num = (this.midiMask - 60) % 12;
			if (Enum.IsDefined(typeof(MIDINoteMask), num))
			{
				return (MIDINoteMask)num;
			}
			return MIDINoteMask.const_10;
		}

		public Enum39 method_3()
		{
			if (this.midiMask < 60 || this.midiMask > 106)
			{
				return Enum39.const_5;
			}
			Enum39 @enum = (Enum39)((this.midiMask - 60) % 12);
			if (@enum >= Enum39.const_0 && @enum <= Enum39.const_4)
			{
				return @enum;
			}
			return Enum39.const_5;
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
