using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GHNamespaceG;

namespace GHNamespaceN
{
    public class MidiReader
    {
        public readonly List<MidiLine> MidiLineList = new List<MidiLine>();

        public int Int0;

        public static MidiReader smethod_0(string fileLocation)
        {
            MidiReader result;
            using (FileStream fileStream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                result = new MidiReader(fileStream);
            }
            return result;
        }

        public MidiReader()
        {
        }

        public MidiReader(Stream stream0)
        {
            method_3(stream0);
        }

        public int method_0()
        {
            return Int0;
        }

        public void method_1(int int1)
        {
            Int0 = int1;
        }

        public List<MidiLine> GetMidiLineList()
        {
            return MidiLineList;
        }

        private void method_3(Stream midiStream)
        {
            BinaryReader midiFile = new BinaryReader(midiStream);
            ByteFiddler.smethod_3("MIDI", midiFile, "MThd");
            ByteFiddler.RotateLeft(midiFile.ReadUInt32());
            ByteFiddler.RotateRight(midiFile.ReadUInt16());
            int num = ByteFiddler.RotateRight(midiFile.ReadUInt16());
            method_1(ByteFiddler.RotateRight(midiFile.ReadUInt16()));
            MidiLineList.Clear();
            for (int i = 0; i < num; i++)
            {
                MidiLine midiLine = new MidiLine(method_0());
                MidiLineList.Add(midiLine);
                List<AbstractNoteClass> list = new List<AbstractNoteClass>();
                ByteFiddler.smethod_3("MIDI", midiFile, "MTrk");
                uint num2 = ByteFiddler.RotateLeft(midiFile.ReadUInt32());
                long position = midiFile.BaseStream.Position;
                int num3 = 0;
                byte b = 0;
                while (midiFile.BaseStream.Position < position + num2)
                {
                    int num4 = (int) method_4(midiFile);
                    AbstractNoteClass midiNote = null;
                    num3 += num4;
                    byte b2 = midiFile.ReadByte();
                    if (b2 != 255)
                    {
                        byte int_;
                        if ((b2 & 128) == 128)
                        {
                            int_ = midiFile.ReadByte();
                            b = b2;
                        }
                        else
                        {
                            int_ = b2;
                            b2 = b;
                        }
                        byte b3 = (byte) (b2 >> 4);
                        switch (b3)
                        {
                            case 8:
                                midiNote = new MidiNote(num3, int_, midiFile.ReadByte(), false);
                                goto IL_298;
                            case 9:
                                midiNote = new MidiNote(num3, int_, midiFile.ReadByte(), true);
                                goto IL_298;
                            case 11:
                            case 12:
                            case 14:
                                goto IL_298;
                        }
                        throw new NotImplementedException(string.Format("Unhandled MIDI command: {0} at position {1}",
                            b3.ToString("X"), midiFile.BaseStream.Position));
                    }
                    byte b4 = midiFile.ReadByte();
                    long num5 = method_4(midiFile);
                    byte[] array = midiFile.ReadBytes((int) num5);
                    byte b5 = b4;
                    if (b5 <= 47)
                    {
                        switch (b5)
                        {
                            case 1:
                                midiNote = new ZzNote1(num3, ZzNote1.Enum37.Const0, Encoding.ASCII.GetString(array));
                                break;
                            case 2:
                                break;
                            case 3:
                            {
                                    string text = Encoding.ASCII.GetString(array).ToUpper();
                                if (!string.IsNullOrEmpty(text))
                                {
                                    midiLine.method_3(text);
                                }
                                break;
                            }
                            default:
                                if (b5 != 47)
                                {
                                }
                                break;
                        }
                    }
                    else if (b5 != 81)
                    {
                        if (b5 == 88)
                        {
                            if (num5 != 4L)
                            {
                                Class355.Interface150.imethod_1(string.Format(
                                    "Expected time signature event to have data length of 4, but found instead {0}",
                                    num5));
                            }
                            midiNote = new ZzNote338(num3, array[0], array[1], array[2], array[3]);
                        }
                    }
                    else
                    {
                        if (num5 != 3L)
                        {
                            Class355.Interface150.imethod_1(
                                string.Format("Expected tempo event to have data length of 3, but found instead {0}",
                                    num5));
                        }
                        int num6 = array[0] << 16;
                        num6 |= array[1] << 8;
                        num6 |= array[2];
                        midiNote = new BpmNote1(num3, num6);
                    }
                    IL_298:
                    if (midiNote != null)
                    {
                        list.Add(midiNote);
                    }
                }
                list.Sort(AbstractNoteClass.smethod_0);
                midiLine.method_1(list);
                midiFile.BaseStream.Seek(position + num2, SeekOrigin.Begin);
            }
        }

        private long method_4(BinaryReader binaryReader0)
        {
            long num = 0L;
            byte b;
            do
            {
                b = binaryReader0.ReadByte();
                num = (num << 7) + (b & 127);
            } while ((b & 128) != 0);
            return num;
        }
    }
}