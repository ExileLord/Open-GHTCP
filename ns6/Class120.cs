using System;
using System.Collections.Generic;
using ns5;
using SharpAudio.ADI.OpenAL;

namespace ns6
{
	public class Class120 : IDisposable
	{
		private enum Enum13
		{
			const_0,
			const_1
		}

		private bool bool_0;

		private bool bool_1;

		private IntPtr intptr_0;

		private Struct62 struct62_0;

		private bool bool_2;

		private string string_0;

		private static readonly object object_0;

		private static readonly List<string> list_0;

		private static readonly Dictionary<Struct62, Class120> dictionary_0;

		private static bool bool_3;

		private static Enum13 enum13_0;

		static Class120()
		{
			object_0 = new object();
			list_0 = new List<string>();
			dictionary_0 = new Dictionary<Struct62, Class120>();
			bool_3 = true;
			smethod_0();
		}

		public Class120() : this(null, 0, 0, false, true)
		{
		}

		public Class120(string string_1, int int_0, int int_1, bool bool_4, bool bool_5)
		{
			method_0(string_1, int_0, int_1, bool_4, bool_5);
		}

		private static void smethod_0()
		{
			lock (object_0)
			{
				if (list_0.Count == 0)
				{
					try
					{
						if (OpenAL.alcIsExtensionPresent(IntPtr.Zero, "ALC_ENUMERATION_EXT"))
						{
							enum13_0 = Enum13.const_1;
							list_0.AddRange(OpenAL.smethod_1(IntPtr.Zero, Enum8.const_1));
						}
						else
						{
							enum13_0 = Enum13.const_0;
						}
						foreach (string arg_65_0 in list_0)
						{
						}
					}
					catch (DllNotFoundException)
					{
						bool_3 = false;
					}
				}
			}
		}

		private void method_0(string string_1, int int_0, int int_1, bool bool_4, bool bool_5)
		{
			if (!bool_3)
			{
				throw new DllNotFoundException("openal32.dll");
			}
			if (enum13_0 == Enum13.const_1 && list_0.Count == 0)
			{
				throw new NotSupportedException("No audio hardware is available.");
			}
			if (bool_2)
			{
				throw new NotSupportedException("Multiple AudioContexts are not supported.");
			}
			if (int_0 < 0)
			{
				throw new ArgumentOutOfRangeException("freq", int_0, "Should be greater than zero.");
			}
			if (int_1 < 0)
			{
				throw new ArgumentOutOfRangeException("refresh", int_1, "Should be greater than zero.");
			}
			if (!string.IsNullOrEmpty(string_1))
			{
				intptr_0 = OpenAL.alcOpenDevice(string_1);
			}
			if (intptr_0 == IntPtr.Zero)
			{
				intptr_0 = OpenAL.alcOpenDevice(null);
			}
			if (intptr_0 == IntPtr.Zero)
			{
				OpenAL.alcOpenDevice(OpenAL.smethod_0(IntPtr.Zero, Enum7.const_0));
			}
			if (intptr_0 == IntPtr.Zero && list_0.Count > 0)
			{
				intptr_0 = OpenAL.alcOpenDevice(list_0[0]);
			}
			if (intptr_0 == IntPtr.Zero)
			{
				throw new Exception2(string.Format("Audio device '{0}' does not exist or is tied up by another application.", string.IsNullOrEmpty(string_1) ? "default" : string_1));
			}
			method_1();
			List<int> list = new List<int>();
			if (int_0 != 0)
			{
				list.Add(4103);
				list.Add(int_0);
			}
			if (int_1 != 0)
			{
				list.Add(4104);
				list.Add(int_1);
			}
			list.Add(4105);
			list.Add(bool_4 ? 1 : 0);
			if (bool_5 && OpenAL.alcIsExtensionPresent(intptr_0, "ALC_EXT_EFX"))
			{
				int item;
				OpenAL.alcGetIntegerv(intptr_0, Enum9.const_7, 1, out item);
				list.Add(131075);
				list.Add(item);
			}
			list.Add(0);
			struct62_0 = OpenAL.alcCreateContext(intptr_0, list.ToArray());
			if (Struct62.smethod_1(struct62_0, Struct62.struct62_0))
			{
				OpenAL.alcCloseDevice(intptr_0);
				throw new Exception3("The audio context could not be created with the specified parameters.");
			}
			method_1();
			if (list_0.Count > 0)
			{
				method_4();
			}
			method_1();
			string_0 = OpenAL.smethod_0(intptr_0, Enum7.const_5);
			int num;
			OpenAL.alcGetIntegerv(intptr_0, Enum9.const_2, 4, out num);
			if (num > 0)
			{
				int[] array = new int[num];
				OpenAL.alcGetIntegerv(intptr_0, Enum9.const_3, array.Length * 4, out array[0]);
				int[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					int num2 = array2[i];
					Enum6 @enum = (Enum6)num2;
					if (@enum == Enum6.const_2)
					{
						method_5(true);
					}
				}
			}
			lock (object_0)
			{
				dictionary_0.Add(struct62_0, this);
				bool_2 = true;
			}
		}

		private void method_1()
		{
			AlcError alcError = OpenAL.alcGetError(intptr_0);
			if (alcError != AlcError.NoError)
			{
				throw new Exception3(alcError.ToString());
			}
		}

		private static void smethod_1(Class120 class120_0)
		{
			lock (object_0)
			{
				if (!OpenAL.alcMakeContextCurrent((class120_0 != null) ? class120_0.struct62_0 : Struct62.struct62_0))
				{
					//Delegate129.delegate129_0;
					//"ALC {0} error detected at {1}.";
					OpenAL.alcGetError((class120_0 != null) ? Struct62.smethod_0(class120_0.struct62_0) : IntPtr.Zero).ToString();
					if (class120_0 == null)
					{
						//"null";
					}
					else
					{
						class120_0.ToString();
					}
					throw null;
				}
			}
		}

		public bool method_2()
		{
			bool result;
			lock (object_0)
			{
				if (dictionary_0.Count == 0)
				{
					result = false;
				}
				else
				{
					result = (smethod_2() == this);
				}
			}
			return result;
		}

		public void method_3(bool bool_4)
		{
			if (bool_4)
			{
				smethod_1(this);
				return;
			}
			smethod_1(null);
		}

		public void method_4()
		{
			smethod_1(this);
		}

		private void method_5(bool bool_4)
		{
			bool_1 = bool_4;
		}

		public static Class120 smethod_2()
		{
			Class120 result;
			lock (object_0)
			{
				if (dictionary_0.Count == 0)
				{
					result = null;
				}
				else
				{
					Class120 @class;
					dictionary_0.TryGetValue(OpenAL.alcGetCurrentContext(), out @class);
					result = @class;
				}
			}
			return result;
		}

		public void Dispose()
		{
			method_6(true);
			GC.SuppressFinalize(this);
		}

		private void method_6(bool bool_4)
		{
			if (!bool_0)
			{
				if (method_2())
				{
					method_3(false);
				}
				if (Struct62.smethod_2(struct62_0, Struct62.struct62_0))
				{
					dictionary_0.Remove(struct62_0);
					OpenAL.alcDestroyContext(struct62_0);
				}
				if (intptr_0 != IntPtr.Zero)
				{
					OpenAL.alcCloseDevice(intptr_0);
				}
				bool_0 = true;
			}
		}

		~Class120()
		{
			method_6(false);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override string ToString()
		{
			return string.Format("{0} (handle: {1}, device: {2})", string_0, struct62_0, intptr_0);
		}
	}
}
