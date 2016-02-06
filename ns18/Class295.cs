using ns16;
using ns20;
using ns21;
using System;
using System.Collections;

namespace ns18
{
	public abstract class Class295 : Class294
	{
		public abstract byte vmethod_15();

		public override void vmethod_13(Stream26 stream26_0)
		{
			this.int_0 = stream26_0.method_19();
			if (this is Class297)
			{
				base.Nodes.Add(new Class313(stream26_0.method_21()));
			}
			else if (this is Class299)
			{
				base.Nodes.Add(new Class314(stream26_0.method_19()));
			}
			else if (this is Class296 || this is Class298)
			{
				base.Nodes.Add(new Class316(stream26_0.method_19()));
			}
			int num = stream26_0.method_19();
			if (num != 0)
			{
				Class259 @class = (base.Parent is Class286) ? (base.Parent as Class286).method_11(stream26_0.method_41(num)) : this.vmethod_12(stream26_0.method_42(num, true));
				base.method_1().Nodes.Add(@class);
				@class.method_4(stream26_0);
			}
		}

		public override void vmethod_14(Stream26 stream26_0)
		{
			if (this.vmethod_8())
			{
				byte[] array = new byte[4];
				array[1] = 1;
                array[2] = (byte)(this.vmethod_15() - 128);
				stream26_0.method_16(array, false);
			}
			else
			{
				byte[] array2 = new byte[4];
				array2[1] = this.vmethod_15();
				stream26_0.method_16(array2, false);
			}
			stream26_0.method_5(this.int_0);
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
					goto IL_AA;
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
			IL_AA:
			if (base.method_1().Nodes.IndexOf(this) < base.method_1().Nodes.Count - 1)
			{
				stream26_0.method_5((int)stream26_0.Position + 4);
				return;
			}
			stream26_0.method_5(0);
		}

		public override void vmethod_2(ref int int_1)
		{
			int_1 += 16;
		}
	}
}
