using System;
using GHNamespaceN;

namespace GHNamespaceG
{
    public class MidiNote : AbstractNoteClass
    {
        private readonly int _midiMask;

        private readonly byte _byte0;

        private readonly bool _bool0 = true;

        public MidiNote(int int2, int int3, byte byte1, bool bool1)
        {
            Int0 = int2;
            _midiMask = int3;
            _byte0 = byte1;
            _bool0 = bool1;
        }

        public Difficulty GetDifficulty()
        {
            if (_midiMask >= 60 && _midiMask <= 106)
            {
                return (Difficulty) ((_midiMask - 60) / 12);
            }
            return Difficulty.Invalid;
        }

        public MidiNoteMask method_2()
        {
            if (_midiMask == 108)
            {
                return MidiNoteMask.Unk108;
            }
            //SP
            if (_midiMask == 116)
            {
                return MidiNoteMask.StarPower;
            }
            //I assume nothing
            if (_midiMask < 60 || _midiMask > 106)
            {
                return MidiNoteMask.Invalid;
            }
            //Gets note type
            var num = (_midiMask - 60) % 12;
            if (Enum.IsDefined(typeof(MidiNoteMask), num))
            {
                return (MidiNoteMask) num;
            }
            return MidiNoteMask.Invalid;
        }

        public Fret method_3()
        {
            if (_midiMask < 60 || _midiMask > 106)
            {
                return Fret.Invalid;
            }
            var @enum = (Fret) ((_midiMask - 60) % 12);
            if (@enum >= Fret.Green && @enum <= Fret.Orange)
            {
                return @enum;
            }
            return Fret.Invalid;
        }

        public int method_4()
        {
            return _midiMask;
        }

        public bool method_5()
        {
            return _byte0 > 0 && _bool0;
        }

        public override string ToString()
        {
            return string.Format("{0}: NoteId {1} ({2} {3})", method_0(), _midiMask, _byte0, _bool0 ? "On" : "Off");
        }
    }
}