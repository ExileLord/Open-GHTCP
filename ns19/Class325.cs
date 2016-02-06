using ns16;
using System;

namespace ns19
{
	public class Class325 : Class324
	{
		public override void vmethod_0(Stream26 stream26_0)
		{
			this.byte_0 = stream26_0.method_18();
			this.int_0 = new int[]
			{
				stream26_0.method_19()
			};
			byte byte_ = this.byte_0;
			switch (byte_)
			{
			case 1:
				this.object_0 = stream26_0.method_19();
				return;
			case 2:
				this.object_0 = stream26_0.method_21();
				return;
			case 3:
				break;
			case 4:
				this.object_0 = stream26_0.method_29();
				return;
			default:
				switch (byte_)
				{
				case 13:
					this.int_0 = new int[]
					{
						this.int_0[0],
						stream26_0.method_19()
					};
					return;
				case 14:
				case 16:
					this.object_0 = stream26_0.method_18();
					return;
				case 15:
					break;
				case 17:
					this.object_0 = stream26_0.method_23();
					break;
				default:
					return;
				}
				break;
			}
		}

		public override void vmethod_1(Stream26 stream26_0)
		{
			stream26_0.method_3(this.byte_0);
			stream26_0.method_5(this.int_0[0]);
			byte byte_ = this.byte_0;
			switch (byte_)
			{
			case 1:
				stream26_0.method_5((int)this.object_0);
				return;
			case 2:
				stream26_0.method_9((float)this.object_0);
				return;
			case 3:
				break;
			case 4:
				stream26_0.method_14((string)this.object_0, false);
				stream26_0.WriteByte(0);
				stream26_0.WriteByte(0);
				return;
			default:
				switch (byte_)
				{
				case 13:
					stream26_0.method_5(this.int_0[1]);
					return;
				case 14:
				case 16:
					stream26_0.method_3((byte)this.object_0);
					return;
				case 15:
					break;
				case 17:
					stream26_0.method_11((short)this.object_0);
					break;
				default:
					return;
				}
				break;
			}
		}
	}
}
