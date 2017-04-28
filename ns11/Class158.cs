using System;
using System.Runtime.InteropServices;
using ns0;
using ns1;
using ns8;

namespace ns11
{
	public class Class158 : IDisposable
	{
		private Struct66 struct66_0;

		private readonly int int_0;

		private readonly Class17 class17_0;

		private GCHandle gchandle_0;

		private IntPtr intptr_0;

		private GCHandle gchandle_1;

		private GCHandle gchandle_2;

		private readonly GenericAudioStream stream1_0;

		private readonly object object_0;

		public Class158(IntPtr intptr_1, int int_1, GenericAudioStream stream1_1, object object_1)
		{
			int_0 = int_1;
			class17_0 = new Class17(int_1);
			gchandle_0 = GCHandle.Alloc(class17_0.method_0(), GCHandleType.Pinned);
			intptr_0 = intptr_1;
			stream1_0 = stream1_1;
			object_0 = object_1;
			struct66_0 = default(Struct66);
			gchandle_1 = GCHandle.Alloc(struct66_0);
			struct66_0.intptr_0 = gchandle_0.AddrOfPinnedObject();
			struct66_0.int_0 = int_1;
			struct66_0.int_2 = 1;
			gchandle_2 = GCHandle.Alloc(this);
			struct66_0.intptr_1 = (IntPtr)gchandle_2;
			lock (object_1)
			{
				Exception4.smethod_1(Class162.waveOutPrepareHeader(intptr_1, ref struct66_0, Marshal.SizeOf(struct66_0)), "waveOutPrepareHeader");
			}
		}

		~Class158()
		{
			method_0(false);
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
			method_0(true);
		}

		public void method_0(bool bool_0)
		{
			if (gchandle_1.IsAllocated)
			{
				gchandle_1.Free();
			}
			if (gchandle_0.IsAllocated)
			{
				gchandle_0.Free();
			}
			if (gchandle_2.IsAllocated)
			{
				gchandle_2.Free();
			}
			if (intptr_0 != IntPtr.Zero)
			{
				lock (object_0)
				{
					Class162.waveOutUnprepareHeader(intptr_0, ref struct66_0, Marshal.SizeOf(struct66_0));
				}
				intptr_0 = IntPtr.Zero;
			}
		}

		public bool method_1()
		{
			int num;
			lock (stream1_0)
			{
				GenericAudioStream arg_39_0 = stream1_0;
				IntPtr arg_39_1 = struct66_0.intptr_0;
				int int_;
				class17_0.method_4(int_ = class17_0.method_0().Length);
				num = arg_39_0.vmethod_3(arg_39_1, int_);
			}
			if (num == 0)
			{
				return false;
			}
			Array.Clear(class17_0.method_0(), num, class17_0.method_3() - num);
			method_4();
			return true;
		}

		public bool method_2()
		{
			return (struct66_0.enum15_0 & Enum15.flag_3) == Enum15.flag_3;
		}

		public Class17 method_3()
		{
			return class17_0;
		}

		private void method_4()
		{
			Enum18 @enum;
			lock (object_0)
			{
				@enum = Class162.waveOutWrite(intptr_0, ref struct66_0, Marshal.SizeOf(struct66_0));
			}
			if (@enum != Enum18.const_0)
			{
				throw new Exception4(@enum, "waveOutWrite");
			}
			GC.KeepAlive(this);
		}
	}
}
