using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns22;

namespace ns9
{
	public class MIDIReader
	{
		public readonly List<MIDILine> midiLineList = new List<MIDILine>();

		public int int_0;

		public static MIDIReader smethod_0(string fileLocation)
		{
			MIDIReader result;
			using (var fileStream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				result = new MIDIReader(fileStream);
			}
			return result;
		}

		public MIDIReader()
		{
		}

		public MIDIReader(Stream stream_0)
		{
			method_3(stream_0);
		}

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_1)
		{
			int_0 = int_1;
		}

		public List<MIDILine> getMidiLineList()
		{
			return midiLineList;
		}

		private void method_3(Stream midiStream)
		{
			var midiFile = new BinaryReader(midiStream);
			ByteFiddler.smethod_3("MIDI", midiFile, "MThd");
			ByteFiddler.RotateLeft(midiFile.ReadUInt32());
			ByteFiddler.RotateRight(midiFile.ReadUInt16());
			int num = ByteFiddler.RotateRight(midiFile.ReadUInt16());
			method_1(ByteFiddler.RotateRight(midiFile.ReadUInt16()));
			midiLineList.Clear();
			for (var i = 0; i < num; i++)
			{
				var midiLine = new MIDILine(method_0());
				midiLineList.Add(midiLine);
				var list = new List<AbstractNoteClass>();
				ByteFiddler.smethod_3("MIDI", midiFile, "MTrk");
				var num2 = ByteFiddler.RotateLeft(midiFile.ReadUInt32());
				var position = midiFile.BaseStream.Position;
				var num3 = 0;
				byte b = 0;
				while (midiFile.BaseStream.Position < position + num2)
				{
					var num4 = (int)method_4(midiFile);
					AbstractNoteClass midiNote = null;
					num3 += num4;
					var b2 = midiFile.ReadByte();
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
						var b3 = (byte)(b2 >> 4);
						switch (b3)
						{
						case 8:
							midiNote = new MIDINote(num3, int_, midiFile.ReadByte(), false);
							goto IL_298;
						case 9:
							midiNote = new MIDINote(num3, int_, midiFile.ReadByte(), true);
							goto IL_298;
						case 11:
						case 12:
						case 14:
							goto IL_298;
						}
						throw new NotImplementedException(string.Format("Unhandled MIDI command: {0} at position {1}", b3.ToString("X"), midiFile.BaseStream.Position));
					}
					var b4 = midiFile.ReadByte();
					var num5 = method_4(midiFile);
					var array = midiFile.ReadBytes((int)num5);
					var b5 = b4;
					if (b5 <= 47)
					{
						switch (b5)
						{
						case 1:
							midiNote = new zzNote1(num3, zzNote1.Enum37.const_0, Encoding.ASCII.GetString(array));
							break;
						case 2:
							break;
						case 3:
						{
							var text = Encoding.ASCII.GetString(array).ToUpper();
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
								Class355.interface15_0.imethod_1(string.Format("Expected time signature event to have data length of 4, but found instead {0}", num5));
							}
							midiNote = new zzNote338(num3, array[0], array[1], array[2], array[3]);
						}
					}
					else
					{
						if (num5 != 3L)
						{
							Class355.interface15_0.imethod_1(string.Format("Expected tempo event to have data length of 3, but found instead {0}", num5));
						}
						var num6 = array[0] << 16;
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

		private long method_4(BinaryReader binaryReader_0)
		{
			var num = 0L;
			byte b;
			do
			{
				b = binaryReader_0.ReadByte();
				num = (num << 7) + (b & 127);
			}
			while ((b & 128) != 0);
			return num;
		}
	}
}
