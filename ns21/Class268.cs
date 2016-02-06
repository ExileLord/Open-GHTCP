using ns16;
using ns18;
using ns20;
using ns22;
using System;
using System.Collections;

namespace ns21
{
	public abstract class Class268 : Class260
	{
		public abstract byte vmethod_16();

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.method_19();
			this.int_1 = stream26_0.method_19();
			if (this is Class271)
			{
				base.Nodes.Add(new Class313(stream26_0.method_21()));
			}
			else if (this is Class269)
			{
				base.Nodes.Add(new Class314(stream26_0.method_19()));
			}
			else if (this is Class272 || this is Class270)
			{
				base.Nodes.Add(new Class316(stream26_0.method_19()));
			}
			stream26_0.method_19();
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			byte[] array = new byte[4];
            array[1] = (this.vmethod_7() ? (byte)32 : (byte)4);
			array[2] = this.vmethod_16();
			stream26_0.method_16(array, false);
			stream26_0.method_5(this.int_0);
			stream26_0.method_5(this.int_1);
			if (base.Nodes.Count != 0)
			{
				IEnumerator enumerator = base.Nodes.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						Class310 @class = (Class310)enumerator.Current;
						stream26_0.method_15(@class.vmethod_8());
					}
					goto IL_97;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			stream26_0.method_5(0);
			IL_97:
			stream26_0.method_5(0);
		}

		public override void vmethod_2(ref int int_2)
		{
			int_2 += 20;
		}
	}
}
