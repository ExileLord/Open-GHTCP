using System;
using System.Runtime.InteropServices;
using SharpAudio.ASC;

namespace ns1
{
	public class Class18 : ICustomMarshaler
	{
		public void CleanUpManagedData(object ManagedObj)
		{
		}

		public void CleanUpNativeData(IntPtr pNativeData)
		{
			Marshal.FreeHGlobal(pNativeData);
		}

		public int GetNativeDataSize()
		{
			throw new NotImplementedException();
		}

		public IntPtr MarshalManagedToNative(object ManagedObj)
		{
			return WaveFormat.smethod_1((WaveFormat)ManagedObj);
		}

		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			return WaveFormat.smethod_0(pNativeData);
		}
	}
}
