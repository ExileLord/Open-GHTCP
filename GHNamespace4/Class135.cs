using System;
using System.IO;
using System.Text;
using GHNamespaceK;
using GHNamespaceL;

namespace GHNamespace4
{
    public class Class135 : Class131
    {
        private readonly Class137 _class1370;

        private readonly int _int1;

        private readonly int _int2;

        private readonly int _int3;

        private readonly int[] _int4 = new int[32];

        private readonly int[] _int5 = new int[32];

        private int[] _int6;

        public Class135(Class144 class1440, Class140 class1401, Class136 class1360, int int7, int int8,
            int int9) : base(class1401, int8)
        {
            _int6 = class1360.vmethod_2();
            _int1 = int9;
            for (var i = 0; i < int9; i++)
            {
                _int5[i] = class1440.vmethod_12(int7);
            }
            var num = class1440.vmethod_10(4);
            if (num == 15)
            {
                throw new IOException("STREAM_DECODER_ERROR_STATUS_LOST_SYNC");
            }
            _int2 = num + 1;
            _int3 = class1440.vmethod_12(5);
            for (var j = 0; j < int9; j++)
            {
                _int4[j] = class1440.vmethod_12(_int2);
            }
            var num2 = class1440.vmethod_10(2);
            var num3 = num2;
            if (num3 != 0)
            {
                throw new IOException("STREAM_DECODER_UNPARSEABLE_STREAM");
            }
            _class1370 = new Class138();
            ((Class138) _class1370).Int0 = class1440.vmethod_10(4);
            ((Class138) _class1370).Class1430 = class1360.vmethod_1();
            if (_class1370 is Class138)
            {
                ((Class138) _class1370).vmethod_0(class1440, int9, ((Class138) _class1370).Int0, class1401,
                    class1360.vmethod_2());
            }
            Buffer.BlockCopy(_int5, 0, class1360.vmethod_0(), 0, int9 << 2);
            if (int7 + _int2 + Class141.smethod_0(int9) > 32)
            {
                Class130.smethod_1(class1360.vmethod_2(), class1401.Int0 - int9, _int4, int9, _int3,
                    class1360.vmethod_0(), int9);
                return;
            }
            if (int7 <= 16 && _int2 <= 16)
            {
                Class130.smethod_0(class1360.vmethod_2(), class1401.Int0 - int9, _int4, int9, _int3,
                    class1360.vmethod_0(), int9);
                return;
            }
            Class130.smethod_0(class1360.vmethod_2(), class1401.Int0 - int9, _int4, int9, _int3, class1360.vmethod_0(),
                int9);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder(string.Concat("ChannelLPC: Order=", _int1, " WastedBits=", Int0));
            stringBuilder.Append(string.Concat(" qlpCoeffPrecision=", _int2, " quantizationLevel=", _int3));
            stringBuilder.Append("\n\t\tqlpCoeff: ");
            for (var i = 0; i < _int1; i++)
            {
                stringBuilder.Append(_int4[i] + " ");
            }
            stringBuilder.Append("\n\t\tWarmup: ");
            for (var j = 0; j < _int1; j++)
            {
                stringBuilder.Append(_int5[j] + " ");
            }
            stringBuilder.Append("\n\t\tParameter: ");
            for (var k = 0; k < 1 << ((Class138) _class1370).Int0; k++)
            {
                stringBuilder.Append(((Class138) _class1370).Class1430.Int0[k] + " ");
            }
            return stringBuilder.ToString();
        }
    }
}