using System;
using ns9;

namespace ns22
{
	public class MIDINote : AbstractNoteClass
	{
		private readonly int midiMask;

		private readonly byte byte_0;

		private readonly bool bool_0 = true;

		public MIDINote(int int_2, int int_3, byte byte_1, bool bool_1)
		{
			int_0 = int_2;
			midiMask = int_3;
			byte_0 = byte_1;
			bool_0 = bool_1;
		}

		public Difficulty getDifficulty()
		{
			if (midiMask >= 60 && midiMask <= 106)
			{
				return (Difficulty)((midiMask - 60) / 12);
			}
			return Difficulty.Invalid;
		}

		public MIDINoteMask method_2()
		{
			if (midiMask == 108)
			{
				return MIDINoteMask.Unk108;
			}
            //SP
			if (midiMask == 116)
			{
				return MIDINoteMask.StarPower;
			}
            //I assume nothing
			if (midiMask < 60 || midiMask > 106)
			{
				return MIDINoteMask.Invalid;
			}
            //Gets note type
			int num = (midiMask - 60) % 12;
			if (Enum.IsDefined(typeof(MIDINoteMask), num))
			{
				return (MIDINoteMask)num;
			}
			return MIDINoteMask.Invalid;
		}

		public Fret method_3()
		{
			if (midiMask < 60 || midiMask > 106)
			{
				return Fret.Invalid;
			}
			Fret @enum = (Fret)((midiMask - 60) % 12);
			if (@enum >= Fret.Green && @enum <= Fret.Orange)
			{
				return @enum;
			}
			return Fret.Invalid;
		}

		public int method_4()
		{
			return midiMask;
		}

		public bool method_5()
		{
			return byte_0 > 0 && bool_0;
		}

		public override string ToString()
		{
			return string.Format("{0}: NoteId {1} ({2} {3})", method_0(), midiMask, byte_0, bool_0 ? "On" : "Off");
		}
	}
}
