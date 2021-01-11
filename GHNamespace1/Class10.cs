using System;
using System.Runtime.InteropServices;

namespace GHNamespace1
{
    public class Class10
    {
        public struct Struct6
        {
            public int Int0;

            public int Int1;
        }

        public struct Struct7
        {
            public Struct6 Struct60;

            public long Long0;

            public Guid Guid0;

            public Struct6 Struct61;

            public int Int0;

            public int Int1;

            public int Int2;

            public Struct6 Struct62;

            public string String0;

            public int Int3;

            public int Int4;
        }

        [Guid("0000000c-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface INterface0
        {
            void imethod_0(IntPtr pv, uint cb, out uint pcbRead);

            void imethod_1(IntPtr pv, uint cb, out uint pcbWritten);

            void imethod_2(long dlibMove, uint dwOrigin, out ulong plibNewPosition);

            void imethod_3(ulong libNewSize);

            void imethod_4(INterface0 pstm, ulong cb, out ulong pcbRead, out ulong pcbWritten);

            void imethod_5(uint grfCommitFlags);

            void imethod_6();

            void imethod_7(ulong libOffset, ulong cb, uint dwLockType);

            void imethod_8(ulong libOffset, ulong cb, uint dwLockType);

            void imethod_9(out Struct7 pstatstg, uint grfStatFlag);

            void imethod_10(out INterface0 ppstm);
        }

        [Guid("7c23ff90-33af-11d3-95da-00a024a85b51"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface INterface1
        {
            void imethod_0(INterface2 pName);

            void imethod_1(out INterface2 ppName);

            void imethod_2([MarshalAs(UnmanagedType.LPWStr)] string szName, int pvValue, uint cbValue, uint dwFlags);

            void imethod_3([MarshalAs(UnmanagedType.LPWStr)] string szName, out int pvValue, ref uint pcbValue,
                uint dwFlags);

            void imethod_4(out int wzDynamicDir, ref uint pdwSize);
        }

        [Guid("CD193BC0-B4BC-11d2-9833-00C04FC31D2E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface INterface2
        {
            [PreserveSig]
            int imethod_0(uint propertyId, IntPtr pvProperty, uint cbProperty);

            [PreserveSig]
            int imethod_1(uint propertyId, IntPtr pvProperty, ref uint pcbProperty);

            [PreserveSig]
            int imethod_2();

            [PreserveSig]
            int imethod_3(IntPtr szDisplayName, ref uint pccDisplayName, uint dwDisplayFlags);

            [PreserveSig]
            int imethod_4(object refIid, object pAsmBindSink, INterface1 pApplicationContext,
                [MarshalAs(UnmanagedType.LPWStr)] string szCodeBase, long llFlags, int pvReserved, uint cbReserved,
                out int ppv);

            [PreserveSig]
            int imethod_5(out uint lpcwBuffer, out int pwzName);

            [PreserveSig]
            int imethod_6(out uint pdwVersionHi, out uint pdwVersionLow);

            [PreserveSig]
            int imethod_7(INterface2 pName, uint dwCmpFlags);

            [PreserveSig]
            int imethod_8(out INterface2 pName);
        }

        [Guid("9e3aaeb4-d1cd-11d2-bab9-00c04f8eceae"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface INterface3
        {
            void imethod_0([MarshalAs(UnmanagedType.LPWStr)] string pszName, uint dwFormat, uint dwFlags,
                uint dwMaxSize, out INterface0 ppStream);

            void imethod_1(INterface2 pName);

            void imethod_2(uint dwFlags);

            void imethod_3(uint dwFlags);
        }

        [Guid("e707dcde-d1cd-11d2-bab9-00c04f8eceae"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [ComImport]
        public interface INterface4
        {
            [PreserveSig]
            int imethod_0(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszAssemblyName, IntPtr pvReserved,
                out uint pulDisposition);

            [PreserveSig]
            int imethod_1(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszAssemblyName, IntPtr pAsmInfo);

            [PreserveSig]
            int imethod_2(uint dwFlags, IntPtr pvReserved, out INterface3 ppAsmItem,
                [MarshalAs(UnmanagedType.LPWStr)] string pszAssemblyName);

            [PreserveSig]
            int imethod_3(out object ppAsmScavenger);

            [PreserveSig]
            int imethod_4(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszManifestFilePath,
                IntPtr pvReserved);
        }

        [DllImport("fusion", CharSet = CharSet.Auto)]
        public static extern int CreateAssemblyCache(out INterface4 ppAsmCache, uint dwReserved);

        public static bool smethod_0(string string0)
        {
            int num = CreateAssemblyCache(out INterface4 @interface, 0u);
            if (num != 0)
            {
                return false;
            }
            num = @interface.imethod_4(0u, string0, IntPtr.Zero);
            return num == 0;
        }
    }
}