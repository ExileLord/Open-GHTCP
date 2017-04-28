using System;
using System.IO;

namespace GHNamespaceG
{
    public class UnusedStreamClass : IDisposable
    {
        private static readonly byte[] Byte0 =
        {
            0,
            0,
            1,
            186
        };

        private static readonly byte[] Byte1 =
        {
            0,
            0,
            1,
            187
        };

        private static readonly byte[] Byte2 =
        {
            0,
            0,
            1,
            224
        };

        private static readonly byte[] Byte3 =
        {
            0,
            0,
            1,
            189
        };

        private static readonly byte[] Byte4 =
        {
            0,
            0,
            1,
            190
        };

        private static readonly byte[] Byte5 =
        {
            0,
            0,
            1,
            185
        };

        private bool _bool0;

        private readonly Stream _stream0;

        public void Dispose()
        {
            try
            {
                _stream0.Close();
            }
            catch
            {
            }
            _bool0 = true;
        }
    }
}