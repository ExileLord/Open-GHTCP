using ns16;
using ns18;
using System;

namespace ns21
{
	public class Class285 : Class277<Class315>
	{
		public string this[int int_0]
		{
			get
			{
				return ((Class315)base.Nodes[int_0]).string_0;
			}
			set
			{
				((Class315)base.Nodes[int_0]).string_0 = value;
			}
		}

		public Class285()
		{
			this.vmethod_0();
		}

		public override int vmethod_1()
		{
			return 10;
		}

		public override void vmethod_13(Stream26 stream26_0)
		{
			int num = stream26_0.method_19();
			if (num == 0)
			{
				return;
			}
			int[] array = new int[num];
			if (num > 1)
			{
				stream26_0.Position = (long)stream26_0.method_19();
				for (int i = 0; i < num; i++)
				{
					array[i] = stream26_0.method_19();
				}
			}
			else
			{
				array[0] = stream26_0.method_19();
			}
			int[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				int int_ = array2[j];
				base.Nodes.Add(new Class315(stream26_0.method_45(int_)));
			}
			stream26_0.Position += (long)Class259.smethod_0(stream26_0.Position);
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
			array[1] = 1;
			array[2] = 3;
			stream26_0.method_16(array, false);
			stream26_0.method_5(base.Nodes.Count);
			if (base.Nodes.Count == 0)
			{
				return;
			}
			if (base.Nodes.Count > 1)
			{
				stream26_0.method_5((int)stream26_0.Position + 4);
			}
			int num = (int)stream26_0.Position + 4 * base.Nodes.Count;
			Stream26 stream = new Stream26();
			foreach (Class315 @class in base.Nodes)
			{
				stream26_0.method_5(num);
				stream.method_13(@class.string_0);
				stream.method_3(0);
				num += @class.string_0.Length + 1;
			}
			stream26_0.method_16(stream.method_1(), false);
			stream26_0.method_4(0, Class259.smethod_0(stream26_0.Position));
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 8;
			if (base.Nodes.Count == 0)
			{
				return;
			}
			if (base.Nodes.Count > 1)
			{
				int_0 += 4;
			}
			int_0 += 4 * base.Nodes.Count;
			foreach (Class315 @class in base.Nodes)
			{
				@class.vmethod_2(ref int_0);
				int_0++;
			}
			int_0 += Class259.smethod_0((long)int_0);
		}

		public override string vmethod_5()
		{
			return "Ascii Array";
		}
	}
}
