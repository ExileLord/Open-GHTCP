using ns16;
using ns20;
using ns21;
using System;

namespace ns18
{
	public abstract class Class278<T> : Class277<T> where T : Class258
	{
		public abstract byte vmethod_15();

		public override void vmethod_13(Stream26 stream26_0)
		{
			int num = stream26_0.method_19();
			if (num == 0)
			{
				return;
			}
			if (num > 1)
			{
				stream26_0.Position = (long)stream26_0.method_19();
			}
			if (this is Class279)
			{
				for (int i = 0; i < num; i++)
				{
					base.Nodes.Add(new Class313(stream26_0.method_21()));
				}
				return;
			}
			if (this is Class280)
			{
				for (int j = 0; j < num; j++)
				{
					base.Nodes.Add(new Class314(stream26_0.method_19()));
				}
				return;
			}
			if (this is Class281 || this is Class282)
			{
				for (int k = 0; k < num; k++)
				{
					base.Nodes.Add(new Class316(stream26_0.method_19()));
				}
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
			array[1] = 1;
			array[2] = this.vmethod_15();
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
			foreach (Class310 @class in base.Nodes)
			{
				stream26_0.method_15(@class.vmethod_8());
			}
		}

		public override void vmethod_2(ref int int_0)
		{
			int_0 += 8;
			if (base.Nodes.Count > 1)
			{
				int_0 += 4;
			}
			int_0 += 4 * base.Nodes.Count;
		}
	}
}
