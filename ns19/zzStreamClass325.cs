using ns16;
using System;

namespace ns19
{
	public class zzStreamClass325 : Class324
	{
		public override void vmethod_0(Stream26 stream26_0)
		{
			this.byte_0 = stream26_0.ReadByte2();
			this.int_0 = new int[]
			{
				stream26_0.ReadInt()
			};
			byte byte_ = this.byte_0;
			switch (byte_)
			{
			case 1:
				this.object_0 = stream26_0.ReadInt();
				return;
			case 2:
				this.object_0 = stream26_0.ReadFloat();
				return;
			case 3:
				break;
			case 4:
				this.object_0 = stream26_0.ReadUnicodeString();
				return;
			default:
				switch (byte_)
				{
				case 13:
					this.int_0 = new int[]
					{
						this.int_0[0],
						stream26_0.ReadInt()
					};
					return;
				case 14:
				case 16:
					this.object_0 = stream26_0.ReadByte2();
					return;
				case 15:
					break;
				case 17:
					this.object_0 = stream26_0.ReadShort();
					break;
				default:
					return;
				}
				break;
			}
		}

		public override void vmethod_1(Stream26 stream26_0)
		{
			stream26_0.WriteByte2(this.byte_0);
			stream26_0.WriteInt(this.int_0[0]);
			byte byte_ = this.byte_0;
			switch (byte_)
			{
			case 1:
				stream26_0.WriteInt((int)this.object_0);
				return;
			case 2:
				stream26_0.WriteFloat((float)this.object_0);
				return;
			case 3:
				break;
			case 4:
				stream26_0.WriteString((string)this.object_0, false);
				stream26_0.WriteByte2(0);
				stream26_0.WriteByte2(0);
				return;
			default:
				switch (byte_)
				{
				case 13:
					stream26_0.WriteInt(this.int_0[1]);
					return;
				case 14:
				case 16:
					stream26_0.WriteByte2((byte)this.object_0);
					return;
				case 15:
					break;
				case 17:
					stream26_0.WriteShort((short)this.object_0);
					break;
				default:
					return;
				}
				break;
			}
		}
	}
}
