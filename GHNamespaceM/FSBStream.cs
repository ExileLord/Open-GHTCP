using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GHNamespace1;
using GHNamespace2;
using GHNamespaceH;
using GHNamespaceI;
using SharpAudio.ASC;

namespace GHNamespaceM
{
    public class FsbStream : GenericAudioStream
    {
        private readonly GenericAudioStream _stream10;

        public override bool CanRead => _stream10.CanRead;

        public override bool CanSeek => _stream10.CanSeek;

        public override bool CanWrite => _stream10.CanWrite;

        public override long Length => _stream10.Length;

        public override long Position
        {
            get => _stream10.Position;
            set => _stream10.Position = value;
        }

        public FsbStream(string string0) : this(File.OpenRead(string0))
        {
        }

        public FsbStream(Stream stream1) : this(FsbClass1.smethod_0(stream1))
        {
        }

        public FsbStream(FsbClass1 class1670)
        {
            switch (class1670.method_33().Count)
            {
                case 0:
                    throw new Exception5("FSB Stream: No subfiles.");
                case 1:
                    FileStream = (_stream10 = smethod_0(class1670.method_33()[0]));
                    break;
                default:
                {
                    var list = new List<GenericAudioStream>();
                    foreach (var current in class1670.method_33())
                    {
                        list.Add(smethod_0(current));
                    }
                    FileStream = (_stream10 = new Stream2(list.ToArray()));
                    break;
                }
            }
            WaveFormat0 = _stream10.vmethod_0();
        }

        private static GenericAudioStream smethod_0(Class168 class1680)
        {
            var flag = (class1680.Enum220 & FsbFlags2.Flag19) != FsbFlags2.Flag0;
            var stream = class1680.Stream1;
            var position = stream.Position;
            var array = new byte[4];
            stream.Read(array, 0, 4);
            stream.Position = position;
            if (array[0] == 255 && array[1] >= 240)
            {
                if ((class1680.Enum220 & FsbFlags2.Flag27) != FsbFlags2.Flag0 && class1680.Uint3 > 2u)
                {
                    return new Mp3Class(class1680.Stream1, (int) (class1680.Uint3 / 2u),
                        flag ? Enum4.Const3 : Enum4.Const0);
                }
                return new Mp3Stream(class1680.Stream1, flag ? Enum4.Const3 : Enum4.Const0);
            }
            string @string;
            if ((@string = Encoding.UTF8.GetString(array, 0, 3)) != null && @string == "Ogg")
            {
                return new OggStream(class1680.Stream1);
            }
            if ((class1680.Enum220 & FsbFlags2.Flag17) != FsbFlags2.Flag0)
            {
                return new Stream5(class1680.Stream1,
                    new WaveFormat(class1680.Int0, ((class1680.Enum220 & FsbFlags2.Flag4) != FsbFlags2.Flag0) ? 8 : 16,
                        (int) class1680.Uint3));
            }
            throw new Exception5("FSB SubFile: Data not supported.");
        }

        public override int vmethod_3(IntPtr intptr0, int int2)
        {
            return _stream10.vmethod_3(intptr0, int2);
        }

        public override int vmethod_4(float[] float0, int int2, int int3)
        {
            return _stream10.vmethod_4(float0, int2, int3);
        }

        public override float[][] vmethod_5(int int2)
        {
            return _stream10.vmethod_5(int2);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _stream10.Read(buffer, offset, count);
        }

        public override void SetLength(long value)
        {
            _stream10.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}