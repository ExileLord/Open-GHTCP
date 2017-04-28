using System;
using System.Runtime.InteropServices;
using SharpAudio.ASC;

namespace GHNamespace2
{
	public class Class18 : ICustomMarshaler
	{
		public void CleanUpManagedData(object managedObj)
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

		public IntPtr MarshalManagedToNative(object managedObj)
		{
			return WaveFormat.smethod_1((WaveFormat)managedObj);
		}

		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			return WaveFormat.smethod_0(pNativeData);
		}
	}
}
