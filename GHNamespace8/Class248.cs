using System;
using System.Collections.Generic;
using System.IO;
using GHNamespace1;
using GHNamespace2;
using GHNamespace5;
using GHNamespace9;
using GHNamespaceC;
using GHNamespaceE;
using GHNamespaceM;
using GHNamespaceN;

namespace GHNamespace8
{
    public class Class248 : QbEditor
    {
        private readonly ZzQbSongObject _class3230;

        public bool Bool0;

        public bool Bool1;

        private readonly string[] _string0;

        private readonly TimeSpan _timeSpan0;

        private readonly TimeSpan _timeSpan1;

        public string String1;

        private readonly string _string2;

        private readonly string _string3;

        public static bool Bool2;

        public static bool Bool3;

        public Class248(ZzQbSongObject class3231, string string4, string string5)
        {
            _class3230 = class3231;
            String1 = _class3230.FileName;
            _string3 = string4;
            _string2 = string5;
            var array = _class3230.String1;
            for (var i = 0; i < array.Length; i++)
            {
                var text = array[i];
                if (text.Equals(_class3230.FileName + "_rhythm"))
                {
                    Bool0 = true;
                }
                else if (text.Contains(_class3230.FileName + "_coop_"))
                {
                    Bool1 = true;
                }
            }
        }

        public Class248(string string4, string[] string5, TimeSpan timeSpan2, TimeSpan timeSpan3, string string6)
        {
            String1 = string4;
            _string0 = string5;
            _timeSpan0 = timeSpan2;
            _timeSpan1 = timeSpan3;
            _string2 = string6;
            Bool0 = (_string0.Length > 2 && !_string0[2].Equals(""));
            Bool1 = (_string0.Length == 6);
        }

        public override void vmethod_0()
        {
            if (_class3230 != null)
            {
                KeyGenerator.WriteAllBytes(_string2 + "music\\" + String1 + ".dat.xen", _class3230.Data);
                KeyGenerator.smethod_19(_string3, _string2 + "music\\" + String1 + ".fsb.xen", true);
            }
            else
            {
                var list = new List<string>();
                var list2 = new List<Stream>();
                GenericAudioStream stream3;
                if (_string0.Length == 1)
                {
                    Stream stream;
                    if (!Bool3 && AudioManager.smethod_1(_string0[0]) == AudioTypeEnum.Const1)
                    {
                        stream = File.OpenRead(_string0[0]);
                    }
                    else
                    {
                        stream = new Stream27();
                        Stream16.smethod_0(AudioManager.GetAudioStream(_string0[0]), stream, 44100, 128);
                    }
                    stream.Position = 0L;
                    list.Add(String1 + "_song");
                    list2.Add(stream);
                    list.Add(String1 + "_guitar");
                    if (Bool2)
                    {
                        Stream stream2 = new Stream27();
                        Stream16.smethod_1(stream2, AudioManager.smethod_2(_string0[0]), 128);
                        list2.Add(stream2);
                    }
                    else
                    {
                        list2.Add(stream);
                    }
                    stream3 = AudioManager.smethod_5(stream);
                }
                else
                {
                    var list3 = new List<GenericAudioStream>();
                    string[] array =
                    {
                        "_song",
                        "_guitar",
                        "_rhythm",
                        "_coop_song",
                        "_coop_guitar",
                        "_coop_rhythm"
                    };
                    for (var i = 0; i < _string0.Length; i++)
                    {
                        if (_string0[i] != null && !_string0[i].Equals("") && File.Exists(_string0[i]))
                        {
                            Stream stream4;
                            if (!Bool3 && AudioManager.smethod_1(_string0[i]) == AudioTypeEnum.Const1)
                            {
                                stream4 = File.OpenRead(_string0[i]);
                            }
                            else
                            {
                                stream4 = new Stream27();
                                Stream16.smethod_0(AudioManager.GetAudioStream(_string0[i]), stream4, 44100, 128);
                            }
                            stream4.Position = 0L;
                            list.Add(String1 + array[i]);
                            list2.Add(stream4);
                            if ((_string0.Length == 6) ? (i >= 3) : (i < 3))
                            {
                                list3.Add(AudioManager.smethod_5(stream4));
                            }
                        }
                    }
                    stream3 = new Stream2(list3.ToArray());
                    var num = 0f;
                    var stream5 = new Stream3(stream3, _timeSpan0, _timeSpan1);
                    var array2 = stream5.vmethod_5(100);
                    while (array2 != null && array2.Length > 0)
                    {
                        var array3 = array2;
                        for (var j = 0; j < array3.Length; j++)
                        {
                            var array4 = array3[j];
                            var array5 = array4;
                            for (var k = 0; k < array5.Length; k++)
                            {
                                var value = array5[k];
                                var num2 = Math.Abs(value);
                                if (num2 > num)
                                {
                                    num = num2;
                                }
                            }
                        }
                        array2 = stream5.vmethod_5(100);
                    }
                    (stream3 as Stream2).method_0(new INterface5[]
                    {
                        new Class174(3, 1f / num)
                    });
                }
                var waveFormat = stream3.vmethod_0();
                var t = new TimeSpan(0, 0, 1);
                Stream stream6 = new Stream27();
                Stream16.smethod_0(new Stream2(new Stream3(stream3, _timeSpan0, _timeSpan1), new INterface5[]
                {
                    new Class173(Class173.Enum26.Const0, new[]
                    {
                        new Struct11(0, waveFormat.method_1(t))
                    }),
                    new Class173(Class173.Enum26.Const1, new[]
                    {
                        new Struct11(waveFormat.method_1(_timeSpan1 - _timeSpan0 - t),
                            waveFormat.method_1(_timeSpan1 - _timeSpan0))
                    })
                }), stream6, 44100, 128);
                list.Add(String1 + "_preview");
                list2.Add(stream6);
                new ZzQbSongObject(
                    (int) FsbClass3.smethod_0(_string2 + "music\\" + String1 + ".fsb.xen", list2.ToArray()),
                    list.ToArray()).method_2(_string2 + "music\\" + String1 + ".dat.xen");
            }
            GC.Collect();
        }

        public override string ToString()
        {
            return "Create Music Track: " + String1;
        }

        public override bool Equals(QbEditor other)
        {
            return other is Class248 && (other as Class248).String1 == String1;
        }
    }
}