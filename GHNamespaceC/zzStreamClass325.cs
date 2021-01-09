using GHNamespace9;

namespace GHNamespaceC
{
    public class ZzStreamClass325 : Class324
    {
        public override void vmethod_0(Stream26 stream260)
        {
            Byte0 = stream260.ReadByte2();
            Int0 = new[]
            {
                stream260.ReadInt()
            };
            byte byte_ = Byte0;
            switch (byte_)
            {
                case 1:
                    Object0 = stream260.ReadInt();
                    return;
                case 2:
                    Object0 = stream260.ReadFloat();
                    return;
                case 3:
                    break;
                case 4:
                    Object0 = stream260.ReadUnicodeString();
                    return;
                default:
                    switch (byte_)
                    {
                        case 13:
                            Int0 = new[]
                            {
                                Int0[0],
                                stream260.ReadInt()
                            };
                            return;
                        case 14:
                        case 16:
                            Object0 = stream260.ReadByte2();
                            return;
                        case 15:
                            break;
                        case 17:
                            Object0 = stream260.ReadShort();
                            break;
                        default:
                            return;
                    }
                    break;
            }
        }

        public override void vmethod_1(Stream26 stream260)
        {
            stream260.WriteByte2(Byte0);
            stream260.WriteInt(Int0[0]);
            byte byte_ = Byte0;
            switch (byte_)
            {
                case 1:
                    stream260.WriteInt((int) Object0);
                    return;
                case 2:
                    stream260.WriteFloat((float) Object0);
                    return;
                case 3:
                    break;
                case 4:
                    stream260.WriteString((string) Object0, false);
                    stream260.WriteByte2(0);
                    stream260.WriteByte2(0);
                    return;
                default:
                    switch (byte_)
                    {
                        case 13:
                            stream260.WriteInt(Int0[1]);
                            return;
                        case 14:
                        case 16:
                            stream260.WriteByte2((byte) Object0);
                            return;
                        case 15:
                            break;
                        case 17:
                            stream260.WriteShort((short) Object0);
                            break;
                        default:
                            return;
                    }
                    break;
            }
        }
    }
}