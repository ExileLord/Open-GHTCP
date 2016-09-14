using ns5;
using SharpAudio.ASC.Mp3.Decoding;
using System;

namespace ns4
{
	public class Class92 : Interface7
	{
		public abstract class Class94
		{
			public static readonly float[] float_0 = new float[]
			{
				2f,
				1.587401f,
				1.25992107f,
				1f,
				0.7937005f,
				0.629960537f,
				0.5f,
				0.396850258f,
				0.314980268f,
				0.25f,
				0.198425129f,
				0.157490134f,
				0.125f,
				0.0992125645f,
				0.07874507f,
				0.0625f,
				0.0496062823f,
				0.0393725336f,
				0.03125f,
				0.0248031411f,
				0.0196862668f,
				0.015625f,
				0.0124015706f,
				0.009843133f,
				0.0078125f,
				0.00620078528f,
				0.00492156669f,
				0.00390625f,
				0.00310039264f,
				0.00246078335f,
				0.001953125f,
				0.00155019632f,
				0.00123039167f,
				0.0009765625f,
				0.00077509816f,
				0.000615195837f,
				0.00048828125f,
				0.00038754908f,
				0.000307597918f,
				0.000244140625f,
				0.00019377454f,
				0.000153798959f,
				0.000122070313f,
				9.688727E-05f,
				7.689948E-05f,
				6.10351563E-05f,
				4.8443635E-05f,
				3.844974E-05f,
				3.05175781E-05f,
				2.42218175E-05f,
				1.922487E-05f,
				1.52587891E-05f,
				1.21109088E-05f,
				9.612435E-06f,
				7.62939453E-06f,
				6.05545438E-06f,
				4.80621748E-06f,
				3.81469727E-06f,
				3.02772719E-06f,
				2.40310874E-06f,
				1.90734863E-06f,
				1.51386359E-06f,
				1.20155437E-06f,
				0f
			};

			public abstract void vmethod_0(Class82 class82_0, zzSoundClass class107_0, Class101 class101_0);

			public abstract void vmethod_1(Class82 class82_0, zzSoundClass class107_0);

			public abstract bool vmethod_2(Class82 class82_0);

			public abstract bool vmethod_3(Enum4 enum4_0, Class80 class80_0, Class80 class80_1);
		}

		public class Class95 : Class92.Class94
		{
			public static readonly float[] float_1 = new float[]
			{
				0f,
				0.6666667f,
				0.2857143f,
				0.13333334f,
				0.06451613f,
				0.0317460336f,
				0.0157480314f,
				0.007843138f,
				0.0039138943f,
				0.00195503421f,
				0.0009770396f,
				0.0004884005f,
				0.000244170427f,
				0.000122077763f,
				6.103702E-05f
			};

			public static readonly float[] float_2 = new float[]
			{
				0f,
				-0.6666667f,
				-0.857142866f,
				-0.933333337f,
				-0.9677419f,
				-0.984127f,
				-0.992126f,
				-0.996078432f,
				-0.99804306f,
				-0.9990225f,
				-0.9995115f,
				-0.9997558f,
				-0.9998779f,
				-0.999938965f,
				-0.9999695f
			};

			public readonly int int_0;

			public int int_1;

			public int int_2;

			public float float_3;

			public int int_3;

			public float float_4;

			public float float_5;

			public float float_6;

			public Class95(int int_4)
			{
				this.int_0 = int_4;
				this.int_1 = 0;
			}

			public override void vmethod_0(Class82 class82_0, zzSoundClass class107_0, Class101 class101_0)
			{
				if ((this.int_2 = class82_0.method_13(4)) == 15)
				{
					throw new DecoderException(DecoderError.IllegalSubbandAllocation, null);
				}
				if (class101_0 != null)
				{
					class101_0.method_0(this.int_2, 4);
				}
				if (this.int_2 != 0)
				{
					this.int_3 = this.int_2 + 1;
					this.float_5 = Class92.Class95.float_1[this.int_2];
					this.float_6 = Class92.Class95.float_2[this.int_2];
				}
			}

			public override void vmethod_1(Class82 class82_0, zzSoundClass class107_0)
			{
				if (this.int_2 != 0)
				{
					this.float_3 = Class92.Class94.float_0[class82_0.method_13(6)];
				}
			}

			public override bool vmethod_2(Class82 class82_0)
			{
				if (this.int_2 != 0)
				{
					this.float_4 = (float)class82_0.method_13(this.int_3);
				}
				if (++this.int_1 == 12)
				{
					this.int_1 = 0;
					return true;
				}
				return false;
			}

			public override bool vmethod_3(Enum4 enum4_0, Class80 class80_0, Class80 class80_1)
			{
				if (this.int_2 != 0 && enum4_0 != Enum4.const_2)
				{
					float float_ = (this.float_4 * this.float_5 + this.float_6) * this.float_3;
					class80_0.method_2(float_, this.int_0);
				}
				return true;
			}
		}

		public class Class96 : Class92.Class95
		{
			public float float_7;

			public Class96(int int_4) : base(int_4)
			{
			}

			public override void vmethod_0(Class82 class82_0, zzSoundClass class107_0, Class101 class101_0)
			{
				base.vmethod_0(class82_0, class107_0, class101_0);
			}

			public override void vmethod_1(Class82 class82_0, zzSoundClass class107_0)
			{
				if (this.int_2 == 0)
				{
					return;
				}
				this.float_3 = Class92.Class94.float_0[class82_0.method_13(6)];
				this.float_7 = Class92.Class94.float_0[class82_0.method_13(6)];
			}

			public override bool vmethod_2(Class82 class82_0)
			{
				return base.vmethod_2(class82_0);
			}

			public override bool vmethod_3(Enum4 enum4_0, Class80 class80_0, Class80 class80_1)
			{
				if (this.int_2 != 0)
				{
					this.float_4 = this.float_4 * this.float_5 + this.float_6;
					switch (enum4_0)
					{
					case Enum4.const_0:
						class80_0.method_2(this.float_4 * this.float_3, this.int_0);
						class80_1.method_2(this.float_4 * this.float_7, this.int_0);
						break;
					case Enum4.const_1:
						class80_0.method_2(this.float_4 * this.float_3, this.int_0);
						break;
					default:
						class80_0.method_2(this.float_4 * this.float_7, this.int_0);
						break;
					}
				}
				return true;
			}
		}

		public class Class97 : Class92.Class95
		{
			public int int_4;

			public float float_7;

			public int int_5;

			public float float_8;

			public float float_9;

			public float float_10;

			public Class97(int int_6) : base(int_6)
			{
			}

			public override void vmethod_0(Class82 class82_0, zzSoundClass class107_0, Class101 class101_0)
			{
				this.int_2 = class82_0.method_13(4);
				this.int_4 = class82_0.method_13(4);
				if (class101_0 != null)
				{
					class101_0.method_0(this.int_2, 4);
					class101_0.method_0(this.int_4, 4);
				}
				if (this.int_2 != 0)
				{
					this.int_3 = this.int_2 + 1;
					this.float_5 = Class92.Class95.float_1[this.int_2];
					this.float_6 = Class92.Class95.float_2[this.int_2];
				}
				if (this.int_4 != 0)
				{
					this.int_5 = this.int_4 + 1;
					this.float_9 = Class92.Class95.float_1[this.int_4];
					this.float_10 = Class92.Class95.float_2[this.int_4];
				}
			}

			public override void vmethod_1(Class82 class82_0, zzSoundClass class107_0)
			{
				if (this.int_2 != 0)
				{
					this.float_3 = Class92.Class94.float_0[class82_0.method_13(6)];
				}
				if (this.int_4 != 0)
				{
					this.float_7 = Class92.Class94.float_0[class82_0.method_13(6)];
				}
			}

			public override bool vmethod_2(Class82 class82_0)
			{
				bool result = base.vmethod_2(class82_0);
				if (this.int_4 != 0)
				{
					this.float_8 = (float)class82_0.method_13(this.int_5);
				}
				return result;
			}

			public override bool vmethod_3(Enum4 enum4_0, Class80 class80_0, Class80 class80_1)
			{
				base.vmethod_3(enum4_0, class80_0, class80_1);
				if (this.int_4 != 0 && enum4_0 != Enum4.const_1)
				{
					float num = (this.float_8 * this.float_9 + this.float_10) * this.float_7;
					if (enum4_0 == Enum4.const_0)
					{
						class80_1.method_2(num, this.int_0);
					}
					else
					{
						class80_0.method_2(num, this.int_0);
					}
				}
				return true;
			}
		}

		public Class82 class82_0;

		public zzSoundClass class107_0;

		public Class80 class80_0;

		public Class80 class80_1;

		public Class84 class84_0;

		public Enum4 enum4_0;

		public Enum5 enum5_0;

		public int int_0;

		public Class92.Class94[] class94_0;

		public readonly Class101 class101_0;

		public Class92()
		{
			this.class101_0 = new Class101();
		}

		public virtual void vmethod_0(Class82 class82_1, zzSoundClass class107_1, Class80 class80_2, Class80 class80_3, Class84 class84_1, Enum4 enum4_1)
		{
			this.class82_0 = class82_1;
			this.class107_0 = class107_1;
			this.class80_0 = class80_2;
			this.class80_1 = class80_3;
			this.class84_0 = class84_1;
			this.enum4_0 = enum4_1;
		}

		public virtual void imethod_0()
		{
			try
			{
				this.int_0 = this.class107_0.method_25();
				this.class94_0 = new Class92.Class94[32];
				this.enum5_0 = this.class107_0.method_8();
				this.vmethod_1();
				this.vmethod_2();
				this.vmethod_3();
				if (this.class101_0 != null || this.class107_0.method_12())
				{
					this.vmethod_4();
					this.vmethod_5();
				}
			}
			catch
			{
			}
		}

		public virtual void vmethod_1()
		{
			if (this.enum5_0 == Enum5.const_3)
			{
				for (int i = 0; i < this.int_0; i++)
				{
					this.class94_0[i] = new Class92.Class95(i);
				}
				return;
			}
			if (this.enum5_0 == Enum5.const_1)
			{
				int i;
				for (i = 0; i < this.class107_0.method_26(); i++)
				{
					this.class94_0[i] = new Class92.Class97(i);
				}
				while (i < this.int_0)
				{
					this.class94_0[i] = new Class92.Class96(i);
					i++;
				}
				return;
			}
			for (int i = 0; i < this.int_0; i++)
			{
				this.class94_0[i] = new Class92.Class97(i);
			}
		}

		public virtual void vmethod_2()
		{
			for (int i = 0; i < this.int_0; i++)
			{
				this.class94_0[i].vmethod_0(this.class82_0, this.class107_0, this.class101_0);
			}
		}

		public virtual void vmethod_3()
		{
		}

		public virtual void vmethod_4()
		{
			for (int i = 0; i < this.int_0; i++)
			{
				this.class94_0[i].vmethod_1(this.class82_0, this.class107_0);
			}
		}

		public virtual void vmethod_5()
		{
			bool flag = false;
			bool flag2 = false;
			Enum5 @enum = this.class107_0.method_8();
			do
			{
				for (int i = 0; i < this.int_0; i++)
				{
					flag = this.class94_0[i].vmethod_2(this.class82_0);
				}
				do
				{
					for (int i = 0; i < this.int_0; i++)
					{
						flag2 = this.class94_0[i].vmethod_3(this.enum4_0, this.class80_0, this.class80_1);
					}
					this.class80_0.method_22(this.class84_0);
					if (this.enum4_0 == Enum4.const_0 && @enum != Enum5.const_3)
					{
						this.class80_1.method_22(this.class84_0);
					}
				}
				while (!flag2);
			}
			while (!flag);
		}
	}
}
